Option Explicit On

Module mgrExport
    Private Const sMODULENAME = "mgrExport"

    Public Function CreaListaInvio(ByRef recin As IDataReader) As IDataReader
        Try
            Dim Recout As New DataTable()

            'trovo corrispondenza campo codice fiscale
            Dim codiceFiscaleIndex As Long
            Dim i As Long

            If recin Is Nothing Then Return Nothing

            codiceFiscaleIndex = -1
            For i = 0 To recin.FieldCount - 1
                If UCase(Replace(recin.GetName(i), " ", "")) Like "*CODICEFISCALE*" Then
                    codiceFiscaleIndex = i
                    Exit For
                End If
            Next

            If codiceFiscaleIndex = -1 Then Return Nothing

            With Recout.Columns
                .Add(New DataColumn("Cognome", System.Type.GetType("System.String")))        '0
                .Add(New DataColumn("Nome", System.Type.GetType("System.String")))           '1
                .Add(New DataColumn("Scadenza", System.Type.GetType("System.String")))       '2
                .Add(New DataColumn("Telefono", System.Type.GetType("System.String")))       '3
                .Add(New DataColumn("Polizza", System.Type.GetType("System.String")))        '4
                .Add(New DataColumn("Importo", System.Type.GetType("System.String")))        '5
                .Add(New DataColumn("Note di invio", System.Type.GetType("System.String")))  '6
                .Add(New DataColumn("Codice fiscale", System.Type.GetType("System.String"))) '7
                .Add(New DataColumn("Note di blocco", System.Type.GetType("System.String"))) '8
                .Add(New DataColumn("Targa", System.Type.GetType("System.String")))          '9
                .Add(New DataColumn("Modello", System.Type.GetType("System.String")))        '10
                .Add(New DataColumn("Selezionato", System.Type.GetType("System.String")))    '11
            End With

            Dim sSql As String = "SELECT  CodiceFiscale"   '0
            sSql &= ",Cognome"         '1
            sSql &= ",Nome"            '2
            sSql &= ",Telefono1"       '3
            sSql &= ",Telefono2"       '4
            sSql &= ",Cellulare"       '5
            sSql &= ",TelAziendale"    '6
            sSql &= ",RisTelefono"     '7
            sSql &= ",RisCellulare"    '8
            sSql &= ",ConsensoPrivacy" '9
            sSql &= " FROM Clienti WHERE CodiceFiscale IN ('XXXXXXXXXXXXXXXX'"

            'crea output
            Do While recin.Read()
                sSql &= "," & Utx.FunzioniDb.TO_STRING(recin.GetString(codiceFiscaleIndex))
            Loop

            sSql &= ")"

            With Utx.FunzioniDb.CreaDataTableReader(sSql)
                Do While .Read
                    Dim dataRow As DataRow = Recout.NewRow()

                    dataRow(7) = .GetString(0)
                    dataRow(0) = .GetString(1)
                    dataRow(1) = .GetString(2)
                    dataRow(5) = "0,00"
                    dataRow(11) = "1"
                    dataRow(6) = "Privacy: " & .GetString(9)

                    If NumeroIsCellulare(.GetString(5)) Then
                        dataRow(3) = StripNumeroCellulare(.GetString(5))
                    ElseIf NumeroIsCellulare(.GetString(8)) Then
                        dataRow(3) = StripNumeroCellulare(.GetString(8))
                    Else
                        dataRow(8) = "/No telefono"
                        dataRow(11) = "0"
                    End If

                    Recout.Rows.Add(dataRow)
                Loop
            End With

            Return Recout.CreateDataReader

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function StripNumeroCellulare(sTel As String) As String
        Dim i As Long
        Dim s As String

        If sTel Is Nothing Then Return vbNullString

        StripNumeroCellulare = vbNullString

        For i = 1 To Len(sTel)
            s = Mid(sTel, i, 1)

            If s = "+" Then
                If StripNumeroCellulare = vbNullString Then
                    StripNumeroCellulare = "+"
                End If
            ElseIf s >= "0" And s <= "9" Then
                StripNumeroCellulare = StripNumeroCellulare & s
            End If
        Next
    End Function

    Private Function NumeroIsCellulare(sTel As String) As Boolean
        Return Not String.IsNullOrEmpty(StripNumeroCellulare(sTel))
    End Function

    Public Function CreaListaComunica(ByRef RecIn As IDataReader) As DataTable
        Try
            If RecIn Is Nothing Then Return Nothing

            Dim DataTableIn As New DataTable()
            DataTableIn.Load(RecIn)

            Dim DataTableOut As New DataTable()

            'trovo corrispondenza campo codice fiscale
            Dim codiceFiscaleFieldName As String = ""
            Dim codiceFiscaleIndex As Integer = -1
            Dim scadenzaIndex As Integer = -1
            Dim targaIndex As Integer = -1
            Dim modelloIndex As Integer = -1
            Dim infopolizzaIndex As Integer = -1
            Dim totaletitoloIndex As Integer = -1
            Dim ramoIndex As Integer = -1
            Dim polizzaIndex As Integer = -1

            For i As Integer = 0 To DataTableIn.Columns.Count - 1
                Dim nomecampo As String = UCase(Replace(DataTableIn.Columns(i).ColumnName, " ", ""))

                If codiceFiscaleIndex = -1 AndAlso nomecampo Like "*CODICEFISCALE*" Then
                    codiceFiscaleIndex = i
                    codiceFiscaleFieldName = DataTableIn.Columns(i).ColumnName
                ElseIf scadenzaIndex = -1 AndAlso nomecampo Like "*DATASCADENZA*" Then
                    scadenzaIndex = i
                ElseIf scadenzaIndex = -1 AndAlso nomecampo Like "*EFFETTOTITOLO*" Then
                    scadenzaIndex = i
                ElseIf targaIndex = -1 AndAlso nomecampo Like "*TARGA*" Then
                    targaIndex = i
                ElseIf modelloIndex = -1 AndAlso nomecampo Like "*MODELLO*" Then
                    modelloIndex = i
                ElseIf infopolizzaIndex = -1 AndAlso nomecampo Like "*INFOPOLIZZA*" Then
                    infopolizzaIndex = i
                ElseIf totaletitoloIndex = -1 AndAlso nomecampo Like "*TOTALETITOLO*" Then
                    totaletitoloIndex = i
                ElseIf ramoIndex = -1 AndAlso nomecampo = "RAMO" Then
                    ramoIndex = i
                ElseIf polizzaIndex = -1 AndAlso nomecampo = "POLIZZA" Then
                    polizzaIndex = i
                End If
            Next

            If codiceFiscaleIndex = -1 Then Return Nothing

            DataTableOut.Columns.Add(New DataColumn("CodiceFiscale", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Cognome", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Nome", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Telefono", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Email", System.Type.GetType("System.String")))
            'campi merge per il comunicatore
            DataTableOut.Columns.Add(New DataColumn("Scadenza", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Targa", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Modello", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("Infopolizza", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("totaletitolo", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("ramo", System.Type.GetType("System.String")))
            DataTableOut.Columns.Add(New DataColumn("polizza", System.Type.GetType("System.String")))

            Dim sSql As String = "SELECT  CodiceFiscale"   '0
            sSql &= ",Cognome"               '1
            sSql &= ",Nome"                  '2
            sSql &= ",Telefono1"             '3
            sSql &= ",Telefono2"             '4
            sSql &= ",Cellulare"             '5
            sSql &= ",TelAziendale"          '6
            sSql &= ",RisTelefono"           '7
            sSql &= ",RisCellulare"          '8
            sSql &= ",EMail"                 '9
            sSql &= ",RisMail"               '10
            sSql &= ",ConsensoPrivacy"       '11
            sSql &= " FROM Clienti WHERE CodiceFiscale IN ('XXXXXXXXXXXXXXXX'"

            'aggiungo i CF facendo un distinct sul codice fiscale
            For Each row As DataRow In DataTableIn.DefaultView.ToTable(True, DataTableIn.Columns(codiceFiscaleIndex).ColumnName).Rows
                sSql &= "," & Utx.FunzioniDb.TO_STRING(row(0).ToString.Trim)
            Next

            sSql &= ")"

            With Utx.FunzioniDb.CreaDataTableReader(sSql)
                Do While .Read
                    Try
                        Dim dataRow As DataRow = DataTableOut.NewRow()
                        'cf,cognome e nome
                        dataRow("CodiceFiscale") = .GetString(0)
                        dataRow("Cognome") = .GetString(1)
                        If Not IsDBNull(.GetValue(2)) Then
                            dataRow("Nome") = .GetString(2)
                        End If
                        'cellulare
                        If Not IsDBNull(.GetValue(5)) AndAlso NumeroIsCellulare(.GetString(5)) Then
                            dataRow("Telefono") = StripNumeroCellulare(.GetString(5))
                        ElseIf Not IsDBNull(.GetValue(8)) AndAlso NumeroIsCellulare(.GetString(8)) Then
                            dataRow("Telefono") = StripNumeroCellulare(.GetString(8))
                        Else
                            dataRow("Telefono") = ""
                        End If
                        'mail
                        If Not IsDBNull(.GetValue(9)) AndAlso IsEmail(.GetString(9)) Then
                            dataRow("Email") = .GetString(9)
                        ElseIf Not IsDBNull(.GetValue(10)) AndAlso IsEmail(.GetString(10)) Then
                            dataRow("Email") = .GetString(10)
                        Else
                            dataRow(4) = ""
                        End If

                        'inserisce scadenza, targa e modello se presenti nell'estrazione originale
                        Dim row() As DataRow = DataTableIn.Select(String.Format("[{0}] = '{1}'", codiceFiscaleFieldName, .GetString(0).ToString.Trim))
                        '05/04/18: se erano presenti più righe, non scriveva la data scadenza
                        'manda un solo sms per cliente, forse è il caso di rivedere il l'operatività
                        If row.Length > 0 Then
                            If scadenzaIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(scadenzaIndex)) AndAlso IsDate(row(0)(scadenzaIndex)) Then
                                dataRow(5) = CDate(row(0)(scadenzaIndex)).ToString("dd/MM/yyyy")
                            End If
                            If targaIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(targaIndex)) Then
                                dataRow(6) = row(0)(targaIndex)
                            End If
                            If modelloIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(modelloIndex)) Then
                                dataRow(7) = row(0)(modelloIndex)
                            End If
                            If infopolizzaIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(infopolizzaIndex)) Then
                                dataRow(8) = row(0)(infopolizzaIndex)
                            End If
                            If totaletitoloIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(totaletitoloIndex)) Then
                                dataRow(9) = row(0)(totaletitoloIndex)
                            End If
                            If ramoIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(ramoIndex)) Then
                                dataRow(10) = row(0)(ramoIndex)
                            End If
                            If polizzaIndex >= 0 AndAlso Not IsDBNull(row(0).IsNull(polizzaIndex)) Then
                                dataRow(11) = row(0)(polizzaIndex)
                            End If
                        End If
                        DataTableOut.Rows.Add(dataRow)

                    Catch ex As Exception
                        Utx.Globale.Log.Info(ex)
                    End Try
                Loop
            End With

            Return DataTableOut

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Private Function IsEmail(sTel As String) As Boolean
        If sTel IsNot Nothing Then
            sTel = sTel.Trim
            If sTel.Length > 0 Then
                If sTel.LastIndexOf("@") > 0 Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
End Module
