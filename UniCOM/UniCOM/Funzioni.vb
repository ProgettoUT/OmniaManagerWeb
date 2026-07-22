Imports System.IO

Module Funzioni

    ''' <summary>
    ''' Cartella dei documenti del cliente
    ''' </summary>
    ''' <returns>path assoluto della cartella dei documenti del cliente</returns>
    ''' <remarks></remarks>
    Friend Function CartellaDocumentiCliente(CF As String) As String
        Try
            'se il cf è vuoto
            If String.IsNullOrEmpty(CF) Then
                Return ""
            Else
                'aggiungo ultima lettera del CF e CF
                CartellaDocumentiCliente = Path.Combine(Utx.Globale.Paths.CartellaDocumenti, CF.Substring(CF.Length - 1))
                CartellaDocumentiCliente = Path.Combine(CartellaDocumentiCliente, CF)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Function UtentePc() As String
        Return System.Security.Principal.WindowsIdentity.GetCurrent.Name
    End Function

    Friend Function CriptaWin(Stringa As String, Optional Codice As Integer = 73) As String
        'cripta una stringa
        Try
            Codice += Stringa.Length

            CriptaWin = ""

            For k As Integer = 1 To Stringa.Length
                CriptaWin += Chr(Asc(Stringa.Chars(k - 1)) + Codice + k)
            Next k

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            CriptaWin = ""
        End Try
    End Function

    Friend Function DeCriptaWin(Stringa As String, Optional Codice As Integer = 73) As String
        'decripta una stringa criptata con CriptaWin
        Try
            If String.IsNullOrEmpty(Stringa) Then
                Return ""
            Else
                Codice += Stringa.Length

                DeCriptaWin = ""

                For k As Integer = 1 To Stringa.Length
                    DeCriptaWin += Chr(Asc(Stringa.Chars(k - 1)) - Codice - k)
                Next k
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Friend Function ConvertToUTF8(Testo As String) As String
        Try
            Dim bTesto As Byte() = System.Text.Encoding.UTF8.GetBytes(Testo)
            Return System.Text.Encoding.UTF8.GetString(bTesto)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Return ""
        End Try

    End Function

    Friend Function ContaRicorrenze(Stringa As String, Carattere As String) As Integer

        Return UBound(Split(Stringa, Carattere, , CompareMethod.Text))
    End Function
End Module
