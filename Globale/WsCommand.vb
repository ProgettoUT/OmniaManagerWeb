Imports System.IO
Imports System.Net

Public Class WsCommand

    Public Shared Function ExecuteNonQuery(CommandText As String(),
                                           Optional NomeTabella As String() = Nothing,
                                           Optional Agenzia As String = "",
                                           Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As ServiziOMW.Risposta
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqMulti(Agenzia, CommandText, NomeTabella, Token(Agenzia), Evento)
                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return Nothing
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return Nothing
                ElseIf Risposta.DataZip IsNot Nothing Then
                    Using inputStream As New MemoryStream(Risposta.DataZip)
                        Using decompressionStream As New Compression.DeflateStream(inputStream, Compression.CompressionMode.Decompress)
                            Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            Risposta.DataTable = DirectCast(formatter.Deserialize(decompressionStream), DataTable)
                        End Using
                    End Using
                    Return Risposta
                Else
                    'è stato restituito direttamente un datatable: non fare niente
                    Return Risposta
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteNonQueryRecord(CommandText As String,
                                                 Optional Agenzia As String = "",
                                                 Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As Integer
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqRecord(Agenzia, CommandText, Token(Agenzia), Evento)
                If Risposta Is Nothing Then
                    Return 0
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return 0
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return 0
                ElseIf Risposta.Errore = False Then
                    Return Risposta.Records
                Else
                    Return 0
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Public Shared Sub ExecuteNonQueryRecordAsync(CommandText As String,
                                                 Optional Agenzia As String = "",
                                                 Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO)
        Dim th As New Threading.Thread(Sub()
                                           Try
                                               If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

                                               Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                                                   s.ExqRecord(Agenzia, CommandText, Token(Agenzia), Evento)
                                               End Using
                                           Catch ex As Exception
                                               Utx.Globale.Log.Errore(ex)
                                           End Try
                                       End Sub)
        th.Start()
    End Sub

    Public Shared Function ExecuteNonQueryRecord(CommandText As String,
                                                 Parametri As String(),
                                                 Optional Agenzia As String = "",
                                                 Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As Integer
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqCmdRecord(Agenzia, CommandText, Parametri, Token(Agenzia), Evento)
                If Risposta Is Nothing Then
                    Return 0
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return 0
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return 0
                ElseIf Risposta.Errore = False Then
                    Return Risposta.Records
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Public Shared Function ExecuteNonQuery(CommandText As String,
                                           Optional Agenzia As String = "",
                                           Optional NomeTabella As String = "",
                                           Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As ServiziOMW.Risposta
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.Exq(Agenzia, CommandText, NomeTabella, Token(Agenzia), Evento)

                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return Nothing
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return Nothing
                ElseIf Risposta.DataZip IsNot Nothing Then
                    Using inputStream As New MemoryStream(Risposta.DataZip)
                        Using decompressionStream As New Compression.DeflateStream(inputStream, Compression.CompressionMode.Decompress)
                            Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            Risposta.DataTable = DirectCast(formatter.Deserialize(decompressionStream), DataTable)
                        End Using
                    End Using
                    Return Risposta
                ElseIf String.IsNullOrEmpty(Risposta.Link) = False Then
                    'da implementare...
                    Return Risposta
                Else
                    'è stato restituito direttamente un datatable: non fare niente
                    Return Risposta
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function
    'Public Shared Function ExecuteNonQueryLimita(CommandText As String,
    '                                       Optional Agenzia As String = "",
    '                                       Optional NomeTabella As String = "",
    '                                       Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO,
    '                                       Optional LimitaRecord As Boolean = True) As ServiziOMW.Risposta
    '    Try
    '        If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

    '        Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
    '            Dim Risposta As ServiziOMW.Risposta
    '            If LimitaRecord = True Then
    '                Risposta = s.Exq(Agenzia, CommandText, NomeTabella, Token(Agenzia), Evento)
    '            Else
    '                Risposta = s.ExqNoMax(Agenzia, CommandText, NomeTabella, Token(Agenzia), Evento)
    '            End If

    '            If Risposta Is Nothing Then
    '                Return Nothing
    '            ElseIf Risposta.Errore = True Then
    '                Utx.Globale.Log.Errore(Risposta.Messaggio)
    '                Return Nothing
    '            ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
    '                MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
    '                Return Nothing
    '            ElseIf Risposta.DataZip IsNot Nothing Then
    '                Using inputStream As New MemoryStream(Risposta.DataZip)
    '                    Using decompressionStream As New Compression.DeflateStream(inputStream, Compression.CompressionMode.Decompress)
    '                        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
    '                        Risposta.DataTable = DirectCast(formatter.Deserialize(decompressionStream), DataTable)
    '                    End Using
    '                End Using
    '                Return Risposta
    '            ElseIf String.IsNullOrEmpty(Risposta.Link) = False Then
    '                'da implementare...
    '                Return Risposta
    '            Else
    '                'è stato restituito direttamente un datatable: non fare niente
    '                Return Risposta
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        Utx.Globale.Log.Errore(ex)
    '        Return Nothing
    '    End Try
    'End Function

    Public Shared Function ExecuteNonQueryStored(QueryFile As String,
                                                 Parametri As String(),
                                                 Optional Agenzia As String = "",
                                                 Optional NomeTabella As String = "",
                                                 Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As ServiziOMW.Risposta
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqStored(Agenzia, QueryFile, Parametri, NomeTabella,
                                                                  Token(Agenzia), ServiziOMW.TipoEvento.NESSUNO)

                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return Nothing
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return Nothing
                ElseIf Risposta.DataZip IsNot Nothing Then
                    Using inputStream As New MemoryStream(Risposta.DataZip)
                        Using decompressionStream As New Compression.DeflateStream(inputStream, Compression.CompressionMode.Decompress)
                            Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            Risposta.DataTable = DirectCast(formatter.Deserialize(decompressionStream), DataTable)
                        End Using
                    End Using
                    Return Risposta
                ElseIf String.IsNullOrEmpty(Risposta.Link) = False Then
                    'da implementare...
                    Return Risposta
                Else
                    'è stato restituito direttamente un datatable: non fare niente
                    Return Risposta
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteScalar(CommandText As String,
                                         Optional Agenzia As String = "",
                                         Optional ValoreDefault As Object = Nothing) As ServiziOMW.Risposta
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqScalar(Agenzia, CommandText, Token(Agenzia))
                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return Nothing
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return Nothing
                Else
                    'è stato restituito direttamente un valore: non fare niente
                    If Risposta.Valore IsNot Nothing AndAlso Risposta.Valore.GetType.Name = "String" AndAlso Risposta.Valore = "NULL" Then
                        Risposta.Valore = DBNull.Value
                    End If
                    Return Risposta
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return New ServiziOMW.Risposta With {.Valore = ValoreDefault}
        End Try
    End Function

    Public Shared Function ExecuteNonQueryMA(CommandText As String(),
                                             Optional NomeTabella As String() = Nothing,
                                             Optional Agenzia As String = "",
                                             Optional Evento As EventiOMW.TipoEvento = EventiOMW.TipoEvento.NESSUNO) As ServiziOMW.Risposta
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.ExqMA(Agenzia, CommandText, NomeTabella, Token(Agenzia), Evento)

                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return Nothing
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return Nothing
                ElseIf Risposta.DataZip IsNot Nothing Then
                    Using inputStream As New MemoryStream(Risposta.DataZip)
                        Using decompressionStream As New Compression.DeflateStream(inputStream, Compression.CompressionMode.Decompress)
                            Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            Risposta.DataTable = DirectCast(formatter.Deserialize(decompressionStream), DataTable)
                        End Using
                    End Using
                    Return Risposta
                Else
                    'è stato restituito direttamente un dataset/datatable: non fare niente
                    Return Risposta
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetDataRow(CommandText As String, Optional Agenzia As String = "") As DataRow
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
            Dim Risposta As ServiziOMW.Risposta = WsCommand.ExecuteNonQuery(CommandText, Agenzia)
            If Risposta IsNot Nothing AndAlso Risposta.DataTable.Rows.Count > 0 Then
                Return Risposta.DataTable.Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function Eval(Espressione As String,
                                Optional ValoreDefault As Object = Nothing) As Object
        Try
            Using s As New Utx.ServiziOMW.ServizioDatiOMW With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Dim Risposta As ServiziOMW.Risposta = s.Eval(Espressione, Utx.Globale.Token)
                If Risposta Is Nothing Then
                    Return Nothing
                ElseIf Risposta.Errore = True Then
                    Utx.Globale.Log.Errore(Risposta.Messaggio)
                    Return ValoreDefault
                ElseIf String.IsNullOrEmpty(Risposta.Alert) = False Then
                    MsgBox(Risposta.Alert, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Return ValoreDefault
                Else
                    'è stato restituito direttamente un valore: non fare niente
                    If Risposta.Valore.GetType.Name = "String" AndAlso Risposta.Valore = "NULL" Then
                        Risposta.Valore = DBNull.Value
                    End If
                    Return Risposta.Valore
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ValoreDefault
        End Try
    End Function

    Private Shared Function Token(CodiceAgenzia As String) As String
        Token = Utx.Globale.Token
        If Utx.Globale.UtenteCorrente.Profilo.ElencoAgenzie.Length > 0 Then
            For Each pa As Utx.ServiziOMW.ProfiloAgenzia In Utx.Globale.UtenteCorrente.Profilo.ElencoAgenzie
                If pa.CodiceAgenzia = CodiceAgenzia Then
                    Return Token + "|" + pa.DbUtente
                End If
            Next
        End If
    End Function

    'Public Shared Function Lista2Array(Lista As List(Of String)) As String()
    '    If Lista Is Nothing Then
    '        Return Nothing
    '    Else
    '        Dim Str(Lista.Count - 1) As String
    '        For k = 0 To Lista.Count - 1
    '            Str(k) = Lista(k)
    '        Next
    '        Return Str
    '    End If
    'End Function
End Class
