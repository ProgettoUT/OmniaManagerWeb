Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class Licenza
    Public CodiceCompagnia As String
    Public CodiceAgenzia As String
    Public Descrizione As String
    Public RagioneSociale As String
    Public IscrizioneRui As String
    Public Indirizzo As String
    Public Cap As String
    Public Localita As String
    Public Provincia As String
    Public Telefono As String
    Public Fax As String
    Public Email As String
    Public ProfiloAttivazione As String = ""
    Public LicenzaDataInizio As Date
    Public LicenzaDataFine As Date
    Public Blocco As Boolean
    Public Md5Hash As String

    <NonSerialized()> Public UID As String
    <NonSerialized()> Private Shared FileName As String

    Public Sub New()
        UID = getUID()
    End Sub

    Public Shared Function Load() As Licenza
        Try
            FileName = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "UniQuota.lic")

            If File.Exists(FileName) Then
                Dim fs As FileStream = File.Open(FileName, FileMode.Open)
                Dim bf As New BinaryFormatter()
                Dim newLicenza As Licenza = CType(bf.Deserialize(fs), Licenza)
                fs.Close()
                newLicenza.UID = newLicenza.getUID
                Return newLicenza
            End If
        Catch ex As Exception
        End Try

        Return New Licenza
    End Function

    Protected Overrides Sub Finalize()
        Dim fs As FileStream = File.Open(FileName, FileMode.Create)
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        bf.Serialize(fs, Me)
        fs.Close()
        MyBase.Finalize()
    End Sub

    Public Function IsAttiva() As Boolean
        If IsNullOrWhiteSpace(CodiceCompagnia) _
        Or IsNullOrWhiteSpace(CodiceAgenzia) _
        Or Blocco = True Then
            Return BloccaPostazione()
        Else
            Return True
        End If
    End Function

    Public Function ProdottoIsAttivo(ByVal prodotto As Integer) As Boolean
        If prodotto = TipoProdotto.Smart Then
            Return ProdottoIsAttivo("PSMART")
        Else
            Return ProdottoIsAttivo("P0" & prodotto)
        End If
    End Function

    Public Function ProdottoIsAttivo(ByVal prodotto As String) As Boolean
#If RELEASE Then
        If Blocco = True Then
            Return False
        ElseIf ProfiloAttivazione Is Nothing Then
            Return False
        Else
            Return ProfiloAttivazione.Contains(prodotto)
        End If
#Else
        Return True
#End If
    End Function

    Public Function Verifica() As Boolean
        Return Verifica(CodiceCompagnia, CodiceAgenzia)
    End Function

    Public Function Verifica(ByVal CodiceCompagnia As String, ByVal CodiceAgenzia As String) As Boolean
        Dim attivazione As New Uniarea.Uniquota
        Dim ServereRaggiungibile As Boolean
        Try

            With attivazione
                .Proxy = Utx.Globale.UniProxy.Proxy

                .Timeout = 30000 '30 secondi

                'verifica on line
                If .VerificaRete = "1" Then
                    ServereRaggiungibile = True
                End If
            End With
        Catch ex As Exception
            'MsgBox(My.Resources.E01 & vbNewLine & ex.Message, MsgBoxStyle.Information)
            'Return BloccaPostazione()
        End Try

        If ServereRaggiungibile = False Then
            If VerifyMd5Hash(GetSettingsMd5Hash) = False Then
                Me.Blocco = True
            End If

            If Today > Me.LicenzaDataFine Or Today < Me.LicenzaDataInizio Then
                Me.Blocco = True
            End If

            If Me.Blocco = True Then
                MsgBox(My.Resources.E01, MsgBoxStyle.Information)
                Return BloccaPostazione()
            End If

            With Me
                .LicenzaDataInizio = Today
                .Md5Hash = GetMd5Hash(GetSettingsMd5Hash)
            End With

            Return MessaggioSuDate()
        End If

        Try
            ''log.Debug("Uniarea.Esito 0")
            Dim esito As Uniarea.Esito = attivazione.Controlla(CodiceCompagnia, CodiceAgenzia, UID)
            ''log.Debug("Uniarea.Esito 1")
            'Uniarea.livelloErroreEnum.Success
            If esito.Errore Is Nothing OrElse esito.Errore = "0" Then
                With esito.Agenzia
                    Me.CodiceCompagnia = CodiceCompagnia
                    Me.CodiceAgenzia = CodiceAgenzia
                    Me.Descrizione = .Descrizione
                    Me.RagioneSociale = .RagioneSociale
                    Me.IscrizioneRui = .IscrizioneRui
                    Me.Indirizzo = .Indirizzo
                    Me.Cap = .Cap
                    Me.Localita = .Localita
                    Me.Provincia = .Provincia
                    Me.Telefono = .Telefono
                    Me.Fax = .Fax
                    Me.Email = .Email
                    Me.LicenzaDataInizio = Today
                    Date.TryParseExact(.LicenzaDataFine, "yyyyMMdd", Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, Me.LicenzaDataFine)
                    Me.ProfiloAttivazione = .ProfiloAttivazione
                    Me.Blocco = False
                    Me.Md5Hash = GetMd5Hash(GetSettingsMd5Hash)
                End With

                ''log.Debug("Uniarea.Esito 2")
                If Not IsNullOrWhiteSpace(esito.Messaggio) Then
                    MsgBox(esito.Messaggio, MsgBoxStyle.Information)
                End If

            ElseIf esito.Errore = "2" Then 'Uniarea.livelloErroreEnum.Errore
                ''log.Debug("Uniarea.Esito 3")
                MsgBox(esito.Messaggio, MsgBoxStyle.Critical)
                Return BloccaPostazione()
            Else
                ''log.Debug("Uniarea.Esito 4")
                MsgBox(esito.Messaggio, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(My.Resources.E02 & vbNewLine & ex.Message, MsgBoxStyle.Information)
            Return BloccaPostazione()
        End Try

        Return True
    End Function

    Private Function MessaggioSuDate() As Boolean
        If Today.AddDays(15) = Me.LicenzaDataFine Then
            MsgBox(My.Resources.W01, MsgBoxStyle.Information)
        ElseIf Today.AddDays(5) >= Me.LicenzaDataFine Then
            MsgBox(String.Format(My.Resources.W02, FormatDateTime(Me.LicenzaDataFine, DateFormat.ShortDate)), MsgBoxStyle.Information)
        End If

        Return True
    End Function

    Public Function Disattiva() As Boolean
        InizializzaCampi()
        Blocco = False
        Return True
    End Function

    Public Function BloccaPostazione() As Boolean
        InizializzaCampi()
        Blocco = True
        Return False
    End Function

    Private Function InizializzaCampi() As Boolean
        With Me
            .CodiceCompagnia = ""
            .CodiceAgenzia = ""
            .Descrizione = ""
            .RagioneSociale = ""
            .IscrizioneRui = ""
            .Indirizzo = ""
            .Cap = ""
            .Localita = ""
            .Provincia = ""
            .Telefono = ""
            .Fax = ""
            .Email = ""
            .LicenzaDataInizio = Nothing
            .LicenzaDataFine = Nothing
            .ProfiloAttivazione = ""
            .Md5Hash = ""
        End With
        Return True
    End Function

    Private Function getUID() As String
        Try
            Dim machine As String = ""
            Dim hdd As New Management.ManagementObjectSearcher("select * from Win32_processor")
            For Each hd In hdd.Get
                machine &= hd("processorId").ToString.Trim
            Next

            Dim mboard As New Management.ManagementObjectSearcher("select * from Win32_BaseBoard")
            For Each mb In mboard.Get
                machine &= mb("SerialNumber").ToString.Trim
            Next
            Return machine
        Catch ex As Exception
        End Try

        Try
            Return System.Environment.UserName.Trim
        Catch ex As Exception
        End Try

        Try
            Return System.Environment.MachineName.Trim
        Catch ex As Exception
        End Try

        Return "unknown"
    End Function

    Private Function GetSettingsMd5Hash() As String
        Dim sBuilder As New System.Text.StringBuilder()
        With Me
            sBuilder.Append(.CodiceCompagnia)
            sBuilder.Append(.CodiceAgenzia)
            sBuilder.Append(.Descrizione)
            sBuilder.Append(.RagioneSociale)
            sBuilder.Append(.IscrizioneRui)
            sBuilder.Append(.Indirizzo)
            sBuilder.Append(.Cap)
            sBuilder.Append(.Localita)
            sBuilder.Append(.Provincia)
            sBuilder.Append(.Telefono)
            sBuilder.Append(.Fax)
            sBuilder.Append(.Email)
            sBuilder.Append(.LicenzaDataInizio)
            sBuilder.Append(.LicenzaDataFine)
            sBuilder.Append(.Blocco)
            sBuilder.Append(.ProfiloAttivazione)
        End With
        Return sBuilder.ToString
    End Function


    Private Function GetMd5Hash(ByVal input As String) As String
        Using md5Hash As Security.Cryptography.MD5 = Security.Cryptography.MD5.Create()


            ' Convert the input string to a byte array and compute the hash.
            Dim data As Byte() = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input))

            ' Create a new Stringbuilder to collect the bytes
            ' and create a string.
            Dim sBuilder As New System.Text.StringBuilder()

            ' Loop through each byte of the hashed data 
            ' and format each one as a hexadecimal string.
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string.
            Return sBuilder.ToString()
        End Using

    End Function 'GetMd5Hash

    ' Verify a hash against a string.
    Private Function VerifyMd5Hash(ByVal input As String) As Boolean
        Using md5Hash As Security.Cryptography.MD5 = Security.Cryptography.MD5.Create()
            ' Hash the input.
            Dim hashOfInput As String = GetMd5Hash(input)

            ' Create a StringComparer an compare the hashes.
            Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

            If 0 = comparer.Compare(hashOfInput, Me.Md5Hash) Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function 'VerifyMd5Hash

    Public ReadOnly Property CodiceCompagniaEssig As String
        Get
            Return "1"
        End Get
    End Property
End Class
