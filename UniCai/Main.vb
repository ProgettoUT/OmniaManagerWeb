Imports System.IO

Public Class Modello

    Public Shared Sub StampaEtVisualizza(agenzia As Integer, ramo As Integer, polizza As Integer)
        Try
            If polizza = 0 Then
                Using f As New FormTargaPolizza
                    f.ShowDialog()
                    If f.DialogResult = Windows.Forms.DialogResult.No Then
                        Exit Try
                    ElseIf f.Polizza > 0 And f.Ramo > 0 Then
                        agenzia = CInt(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
                        ramo = f.Ramo
                        polizza = f.Polizza
                    ElseIf f.Targa.Length > 0 Then
                        Dim rs = Utx.FunzioniDb.CreaDataTableReader("SELECT Agenzia, Ramo, Polizza 
                            FROM Polizze WHERE Targa = " & Utx.FunzioniDb.TO_STRING(f.Targa.ToUpper))
                        With rs
                            If rs IsNot Nothing AndAlso .Read Then
                                agenzia = .GetInt32(0)
                                ramo = .GetInt16(1)
                                polizza = .GetInt32(2)
                            End If
                        End With
                    End If
                End Using
            End If

            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            Dim FileName As String = "CAI " & IIf(polizza = 0, Today.ToString("dd-MM-yyyy"), ramo & "-" & polizza & " (" & Today.ToString("dd-MM-yyyy") & ")") & ".pdf"
            Dim FilePath As String = System.IO.Path.Combine(path, FileName)

            If File.Exists(FilePath) Then
                If MsgBox("Il file """ & FileName & """ esiste già." & vbNewLine & "Vuoi sostituire il file?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Conferma nome file") = MsgBoxResult.No Then
                    Process.Start(FilePath)
                    Exit Sub
                End If
            End If

            'Creo un nuovo file, composto dalla prima parte non modificata e la parte modificata

            'preparo il dizionario dati
            Dim dizionario = PreparaDizionario(agenzia, ramo, polizza)

            'carico la seconda parte del pdf per sostituire i campi
            Dim pdfFields As Byte() = My.Resources.CAIE

            'sostituisco i campi nella stringa
            For Each chiaveValore In dizionario
                pdfFields = replace(pdfFields, System.Text.Encoding.UTF8.GetBytes(chiaveValore.Key), System.Text.Encoding.UTF8.GetBytes(chiaveValore.Value))
            Next

            Using objWriter As New BinaryWriter(File.Open(FilePath, FileMode.Create))
                objWriter.Write(pdfFields)
                objWriter.Close()
            End Using

            Process.Start(FilePath)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Shared Function PreparaDizionario(agenzia As Integer, ramo As Integer, polizza As Integer) As Dictionary(Of String, String)
        On Error Resume Next
        Dim dizionario As New Dictionary(Of String, String)

        Dim rs = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM ProfiloUtente")
        With rs
            If rs IsNot Nothing AndAlso .Read Then
                AddToDizionario(dizionario, "#AGENZIA###########################################", GetString(rs, "Agenzia"))
                AddToDizionario(dizionario, "#AGENZIA-DENOMINAZIONE#########")
                AddToDizionario(dizionario, "#AGENZIA-INDIRIZZO-1#####################", GetString(rs, "Indirizzo"))
                AddToDizionario(dizionario, "#AGENZIA-INDIRIZZO-2#", GetString(rs, "Localita"))
                AddToDizionario(dizionario, "#AGENZIA-STATO######", "I")
                AddToDizionario(dizionario, "#AGENZIA-TELEFONO-EMAIL#########")
            Else
                AddToDizionario(dizionario, "#AGENZIA###########################################")
                AddToDizionario(dizionario, "#AGENZIA-DENOMINAZIONE#########")
                AddToDizionario(dizionario, "#AGENZIA-INDIRIZZO-1#####################")
                AddToDizionario(dizionario, "#AGENZIA-INDIRIZZO-2#")
                AddToDizionario(dizionario, "#AGENZIA-STATO######")
                AddToDizionario(dizionario, "#AGENZIA-TELEFONO-EMAIL#########")
            End If
        End With

        Dim Sql As String = String.Format("SELECT P.CodiceFiscale, P.Polizza, P.Targa, P.DataEffetto, P.DataScadenza, C.Cognome, 
            C.Nome, C.Indirizzo, C.Cap, C.Telefono1, C.DataNascita
            FROM Polizze AS P
            INNER JOIN Clienti AS C ON C.CodiceFiscale = P.CodiceFiscale
            WHERE P.Agenzia = {0} AND P.Ramo = {1} AND P.Polizza = {2}", agenzia, ramo, polizza)

        rs = Utx.FunzioniDb.CreaDataTableReader(Sql)
        With rs
            If rs IsNot Nothing AndAlso .Read Then
                AddToDizionario(dizionario, "#ASSICURATO-COGNOME##################", GetString(rs, "Cognome"))
                AddToDizionario(dizionario, "#ASSICURATO-NOME##########################", GetString(rs, "Nome"))
                AddToDizionario(dizionario, "#ASSICURATO-CODICE-FISCALE#", GetString(rs, "CodiceFiscale"))
                AddToDizionario(dizionario, "#ASSICURATO-INDIRIZZO##################################", GetString(rs, "Indirizzo"))
                AddToDizionario(dizionario, "#ASSICTO-CAP#", GetString(rs, "Cap"))
                AddToDizionario(dizionario, "#ASSICURATO-STATO###", "I")
                AddToDizionario(dizionario, "#ASSICURATO-TELEFONO#############", GetString(rs, "Telefono1"))

                If ramo = 30 Then
                    AddToDizionario(dizionario, "#AUTO-TARGA###", GetString(rs, "Targa"))
                End If
                AddToDizionario(dizionario, "#AUTO-MARCA###")
                AddToDizionario(dizionario, "#AUTO-STATO###", "I")
                AddToDizionario(dizionario, "#POLIZZA-COMPAGNIA-NOME########", "Unipol")
                AddToDizionario(dizionario, "#POLIZZA-NUMERO####################", String.Format("{0}/{1}/{2}", agenzia, ramo, polizza))
                AddToDizionario(dizionario, "#NUMERO-CARTA-VERDE##########")
                AddToDizionario(dizionario, "#CA-VALIDO-DAL###", GetString(rs, "DataEffetto"))
                AddToDizionario(dizionario, "#CA-VALIDO-AL####", GetString(rs, "DataScadenza"))

                'Il conducende può essere l'assicurato solo se è una persona fisica
                If .GetString(.GetOrdinal("CodiceFiscale")).Length = 16 AndAlso
                    MsgBox("L'assicurato è anche il conducente", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    AddToDizionario(dizionario, "#CONDUCENTE-COGNOME#################", GetString(rs, "Cognome"))
                    AddToDizionario(dizionario, "#CONDUCENTE-NOME#########################", GetString(rs, "Nome"))
                    AddToDizionario(dizionario, "#CONDUCENTE-DATA-NASCITA#######", GetString(rs, "DataNascita"))
                    AddToDizionario(dizionario, "#CONDUCENTE-CODICE-FISCALE#####", GetString(rs, "CodiceFiscale"))
                    AddToDizionario(dizionario, "#CONDUCENTE-INDIRIZZO################################", GetString(rs, "Indirizzo"))
                    AddToDizionario(dizionario, "#CONDUCENTE-STATO#", "I")
                    AddToDizionario(dizionario, "#CONDUCENTE-TELEFONO###########", GetString(rs, "Telefono1"))
                Else
                    AddToDizionario(dizionario, "#CONDUCENTE-COGNOME#################")
                    AddToDizionario(dizionario, "#CONDUCENTE-NOME#########################")
                    AddToDizionario(dizionario, "#CONDUCENTE-DATA-NASCITA#######")
                    AddToDizionario(dizionario, "#CONDUCENTE-CODICE-FISCALE#####")
                    AddToDizionario(dizionario, "#CONDUCENTE-INDIRIZZO################################")
                    AddToDizionario(dizionario, "#CONDUCENTE-STATO#")
                    AddToDizionario(dizionario, "#CONDUCENTE-TELEFONO###########")
                End If
                AddToDizionario(dizionario, "#CONDUCENTE-PATENTE-NUMERO#########")
                AddToDizionario(dizionario, "#C#")
                AddToDizionario(dizionario, "#PATENTE-AL##")
            Else
                AddToDizionario(dizionario, "#ASSICURATO-COGNOME##################")
                AddToDizionario(dizionario, "#ASSICURATO-NOME##########################")
                AddToDizionario(dizionario, "#ASSICURATO-CODICE-FISCALE#")
                AddToDizionario(dizionario, "#ASSICURATO-INDIRIZZO##################################")
                AddToDizionario(dizionario, "#ASSICTO-CAP#")
                AddToDizionario(dizionario, "#ASSICURATO-STATO###")
                AddToDizionario(dizionario, "#ASSICURATO-TELEFONO#############")
                AddToDizionario(dizionario, "#AUTO-MARCA###")
                AddToDizionario(dizionario, "#AUTO-TARGA###")
                AddToDizionario(dizionario, "#AUTO-STATO###")
                AddToDizionario(dizionario, "#POLIZZA-COMPAGNIA-NOME########")
                AddToDizionario(dizionario, "#POLIZZA-NUMERO####################")
                AddToDizionario(dizionario, "#NUMERO-CARTA-VERDE##########")
                AddToDizionario(dizionario, "#CA-VALIDO-DAL###")
                AddToDizionario(dizionario, "#CA-VALIDO-AL####")
                AddToDizionario(dizionario, "#CONDUCENTE-COGNOME#################")
                AddToDizionario(dizionario, "#CONDUCENTE-NOME#########################")
                AddToDizionario(dizionario, "#CONDUCENTE-DATA-NASCITA#######")
                AddToDizionario(dizionario, "#CONDUCENTE-CODICE-FISCALE#####")
                AddToDizionario(dizionario, "#CONDUCENTE-INDIRIZZO################################")
                AddToDizionario(dizionario, "#CONDUCENTE-STATO#")
                AddToDizionario(dizionario, "#CONDUCENTE-TELEFONO###########")
                AddToDizionario(dizionario, "#CONDUCENTE-PATENTE-NUMERO#########")
                AddToDizionario(dizionario, "#C#")
                AddToDizionario(dizionario, "#PATENTE-AL##")
            End If
        End With

        Return dizionario
    End Function

    Private Shared Function GetString(rs As IDataReader, NomeCampo As String) As String
        Try
            With rs
                Dim ordinal As Integer = .GetOrdinal(NomeCampo)
                Dim tipo As System.Type = .GetFieldType(ordinal)

                If tipo Is GetType(String) Then
                    Return .GetString(ordinal)
                ElseIf tipo Is GetType(Int32) Then
                    Return .GetInt32(ordinal)
                ElseIf tipo Is GetType(DateTime) Then
                    Return .GetDateTime(ordinal)
                End If
            End With
        Catch ex As Exception
        End Try

        Return ""
    End Function

    Private Shared Sub AddToDizionario(dizionario As Dictionary(Of String, String), chiave As String)
        AddToDizionario(dizionario, chiave, Nothing)
    End Sub
    Private Shared Sub AddToDizionario(dizionario As Dictionary(Of String, String), chiave As String, valore As String)
        If chiave Is Nothing Then Exit Sub
        If valore Is Nothing Then valore = ""

        If valore.Length < chiave.Length Then
            valore = valore.PadRight(chiave.Length, " "c)
        ElseIf valore.Length > chiave.Length Then
            valore = valore.Substring(0, chiave.Length)
        End If
        dizionario.Add(chiave, valore)

        Dim chiavenew(2 * chiave.Length - 1) As Char
        Dim valorenew(2 * chiave.Length - 1) As Char

        For i As Integer = 0 To chiave.Length - 1
            chiavenew(2 * i) = Char.MinValue
            chiavenew(2 * i + 1) = chiave.Chars(i)

            valorenew(2 * i) = Char.MinValue
            valorenew(2 * i + 1) = valore.Chars(i)
        Next

        dizionario.Add(New String(chiavenew), New String(valorenew))
    End Sub

    Private Shared Function replace(arrayBytes As Byte(), searchBytes As Byte(), replaceBytes As Byte()) As Byte()
        Dim matchStart As Integer = -1
        Dim matchLength As Integer = 0

        For index = 0 To arrayBytes.Length - 1
            If arrayBytes(index) = searchBytes(matchLength) Then
                If matchLength = 0 Then matchStart = index
                matchLength += 1
                If matchLength = searchBytes.Length Then
                    For i = 0 To searchBytes.Length - 1
                        arrayBytes(matchStart + i) = replaceBytes(i)
                    Next
                    matchLength = 0
                End If
            Else
                matchLength = 0
            End If
        Next

        Return arrayBytes
    End Function
End Class
