Module Funzioni

    Friend Function NumeroUSA(Numero As Double) As String
        NumeroUSA = Replace(Numero.ToString, ",", ".")
    End Function

    Public Function GetEnvironmentVar(VarName As String) As String
        If Environment.GetEnvironmentVariable(VarName) = Nothing Then
            GetEnvironmentVar = ""
        Else
            GetEnvironmentVar = Environment.GetEnvironmentVariable(VarName)
        End If
    End Function

    'Public Function IdFileAssegni(Giorno As Date) As String

    '    Try
    '        'cartella assegni
    '        IdFileAssegni = Path.Combine(Globale.Glo.CartellaAssegni, "Assegni")
    '        If Not Directory.Exists(IdFileAssegni) Then Directory.CreateDirectory(IdFileAssegni)
    '        'cartella anno
    '        IdFileAssegni = Path.Combine(IdFileAssegni, Giorno.Year.ToString) 'aggiungo l'anno
    '        If Not Directory.Exists(IdFileAssegni) Then Directory.CreateDirectory(IdFileAssegni)
    '        'cartella mese
    '        IdFileAssegni = Path.Combine(IdFileAssegni, Giorno.Month.ToString) 'aggiungo il mese
    '        If Not Directory.Exists(IdFileAssegni) Then Directory.CreateDirectory(IdFileAssegni)

    '        IdFileAssegni = Path.Combine(IdFileAssegni, _
    '                                     "Assegni del " + _
    '                                     Format(Giorno, "dd-MM-yyyy") + ".pdf") 'aggiungo nome file

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        IdFileAssegni = ""
    '    End Try

    'End Function

    Public Function ColonnaStileExcel(ColumnNumber As Integer) As String
        If ColumnNumber > 26 Then
            'colonne da AA in poi
            ' 1st character:  Subtract 1 to map the characters to 0-25,
            '                 but you don't have to remap back to 1-26
            '                 after the 'Int' operation since columns
            '                 1-26 have no prefix letter

            ' 2nd character:  Subtract 1 to map the characters to 0-25,
            '                 but then must remap back to 1-26 after
            '                 the 'Mod' operation by adding 1 back in
            '                 (included in the '65')

            ColonnaStileExcel = Chr(Int((ColumnNumber - 1) / 26) + 64) &
                                Chr(((ColumnNumber - 1) Mod 26) + 65)
        Else
            ' Columns A-Z
            ColonnaStileExcel = Chr(ColumnNumber + 64)
        End If
    End Function

    Friend Sub ImpostaTipoMovimento(ByRef c As ComboBox)
        With c
            .Items.Add("Assicurativi")
            .Items.Add("Extra")

            .SelectedIndex = 0
        End With
    End Sub

    Friend Sub ImpostaPuntoVendita(ByRef c As ComboBox, Optional ItemZero As String = "")
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM PuntiVendita")

            c.Items.Clear()

            'aggiungo l'eventuale item zero
            If Len(ItemZero) > 0 Then
                c.Items.Add(New PuntoVendita(0, ItemZero, 0))
            End If

            Do While dr.Read
                c.Items.Add(New PuntoVendita(dr("Codice"), dr("Descrizione"), dr("CodiceEssigReti")))
            Loop

            'visualizza la descrizione estesa
            c.DisplayMember = "DescrizioneEx"

            If c.Items.Count > 0 Then c.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Friend Sub ImpostaCassa(ByRef c As ComboBox, Optional ItemZero As String = "")
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT DISTINCT CodiceCassa FROM ChiusuraCassa")

            c.Items.Clear()

            If Len(ItemZero) > 0 Then c.Items.Add(ItemZero)

            Do While dr.Read
                c.Items.Add(dr("CodiceCassa"))
            Loop

            c.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Friend Sub ImpostaTipoPagamento(ByRef c As ComboBox, Misto As Boolean)
        Try
            Dim Query As String
            If Misto Then
                Query = "SELECT * FROM DB00000.dbo.Pagamento WHERE TipoPagamento = 'M'"
            Else
                Query = "SELECT * FROM DB00000.dbo.Pagamento ORDER BY TipoPagamento"
            End If

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            c.Items.Clear()

            Do While dr.Read
                c.Items.Add(dr("TipoPagamento") + " - " + dr("Desk"))
            Loop

            c.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Friend Sub ImpostaSezione(ByRef c As ComboBox, Optional ItemZero As String = "")
    '    With c
    '        If Len(ItemZero) > 0 Then .Items.Add(ItemZero)

    '        .Items.Add("Cassetto")
    '        .Items.Add("Banca")
    '        .Items.Add("CO")
    '        .Items.Add("Scoperti")
    '        .Items.Add("Direzione")

    '        .SelectedIndex = 0
    '    End With
    'End Sub
    Friend Sub ImpostaSezione(ByRef c As ComboBox, Optional ItemZero As String = "")
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM Sezioni")

            c.Items.Clear()

            'aggiungo l'eventuale item zero
            If Len(ItemZero) > 0 Then
                c.Items.Add(New Sezione("TT", ItemZero))
            End If

            Do While dr.Read
                c.Items.Add(New Sezione(dr("Codice"), dr("Sezione")))
            Loop

            'visualizza la descrizione estesa
            c.DisplayMember = "DescrizioneEx"

            If c.Items.Count > 0 Then c.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Friend Sub ImpostaCodiceMovimento(ByRef c As ComboBox, Tipo As Int16)
        'tipo contiene l'indice di tipo movimento assicurativo/extra
        Try
            Dim Query As String = String.Format("SELECT TipoMovimento 
                FROM ChiusuraCassa 
                WHERE Len(Trim(TipoMovimento)) > 0 And TipoRecord {0}
                GROUP BY TipoMovimento 
                ORDER BY TipoMovimento", IIf(Tipo = 0, "< 100 ", " >= 100 "))

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            c.Items.Clear()

            Do While dr.Read
                c.Items.Add(dr("TipoMovimento"))
            Loop

            c.SelectedIndex = 0

        Catch ex As Exception
            c.Items.Clear()
        End Try
    End Sub

    Friend Function CodicePvSelezionato(ByRef cbo As ComboBox) As Integer
        Return cbo.Items(cbo.SelectedIndex).Codice
    End Function

    Friend Function UltimaChiusura() As Date
        Try
            Dim Query As String = String.Format("SELECT MAX(DataEsito) 
            FROM ChiusuraCassa 
            WHERE TipoRecord = {0}", Globale.TipoRecord.Chiusura.ToString("D"))
            UltimaChiusura = Utx.WsCommand.ExecuteScalar(Query).Valore
        Catch ex As Exception
            UltimaChiusura = Nothing
        End Try
    End Function

    Friend Function DataFineDecade(DataRiferimento As Date) As Date
        Select Case DataRiferimento.Day
            Case Is < 11 : Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 10)
            Case Is < 21 : Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 20)
            Case Else : Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, GiorniNelMese(DataRiferimento))
        End Select
    End Function

    Friend Function GiorniNelMese(DataRiferimento As Date)
        Return DateTime.DaysInMonth(DataRiferimento.Year, DataRiferimento.Month)
    End Function

    Friend Function IDTransazione() As String
        Return Format(Now, "HHmmss")
    End Function

    Friend Function CodiciSubDaScaricare() As String
        'legge sul server eventuali config
        'per la sede 00 restituisce una stringa vuota "" che scarica tutto

        Dim Utente As New ProfiloUtente

        Try
            Using WsSetting As New Utx.SettingAgenzia.ConfiguraSede

#If DEBUG Then
                If Utente.Sede = "00" Then
                    CodiciSubDaScaricare = ""
                    'CodiciSubDaScaricare = WsSetting.CodiciSub(Utente.Compagnia, Utente.Agenzia, "02")
                Else
                    WsSetting.Timeout = 60000
                    CodiciSubDaScaricare = WsSetting.CodiciSub(Utente.Compagnia, Utente.Agenzia, Utente.Sede)
                End If
#Else
                If Utente.Sede = "00" Then
                    CodiciSubDaScaricare = ""
                Else
                    With WsSetting
                        'assegno il timeout, il proxy e le credenziali
                        .Timeout = 60000
                        .Proxy = Utx.Globale.UniProxy.Proxy
                    End With

                    CodiciSubDaScaricare = WsSetting.CodiciSub(Utente.Compagnia, Utente.Agenzia, Utente.Sede)
                End If
#End If
            End Using

            'nel caso in cui la configurazione non viene trovata sul server
            If CodiciSubDaScaricare Is Nothing Then Return "-ERR"

        Catch ex As Exception
            MsgBox(ex.Message)
            Return "-ERR"
        End Try
    End Function
End Module
