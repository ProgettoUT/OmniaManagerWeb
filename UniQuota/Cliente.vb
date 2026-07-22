<Serializable()> Public Class Cliente
    Public CodiceFiscale As String
    Public Cognome As String
    Public Nome As String

    'Public Nominativo As String
    Public Indirizzo As String
    Public Localita As String
    Public Cap As String
    Public Provincia As String
    Public Email As String
    Public Telefono As String
    Public Convivente As String
    Public DataNascita As Date

    Public ReadOnly Property Nominativo As String
        Get
            Return Trim(Cognome & " " & Nome)
        End Get
    End Property

    'codiceAteco, descrizioneAteco, tipoCliente1, descrizioneTipologiaCliente1, tipoCliente2, descrizioneTipologiaCliente2
    'flagComunicazioniContrattuali, numeroFax, numeroCellulare
    'delega, quota

    Public Function IsPersonaFisica() As Boolean
        Return CodiceFiscale.Length <> 11
    End Function

    Public Function IsPersonaGiudirica() As Boolean
        Return CodiceFiscale.Length = 11
    End Function

    Public ReadOnly Property CodiceAteco As String
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property TipoCliente1 As String
        Get
            Return "2"
        End Get
    End Property

    Public ReadOnly Property TipoCliente2 As String
        Get
            Return "00"
        End Get
    End Property

    Public ReadOnly Property FlagComunicazioniContrattuali As String
        Get
            Return "S"
        End Get
    End Property

    Public ReadOnly Property GetDataDiNascita() As Date
        Get
            If (DataNascita.Year = 1) And Not String.IsNullOrEmpty(CodiceFiscale) Then
                Dim ArrayMesi() As String = {"A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T"} 'Lettere che corrispondono al mese
                Dim sMese As String = CodiceFiscale.Substring(8, 1) 'Si trova nella posizione 9 del codice fiscale
                Dim sAnno As String = CodiceFiscale.Substring(6, 2) 'Si trova nella posizione 7 e 8 codice fiscale
                Dim sGiorno As String = CodiceFiscale.Substring(9, 2) 'Si trova nella posizione 10 e 11 codice fiscale

                Dim anno As Integer
                Dim mese As Integer
                Dim giorno As Integer

                Integer.TryParse(sAnno, anno)
                If 2000 + anno >= Today.Year Then
                    anno += 1900
                Else
                    anno += 2000
                End If

                Integer.TryParse(sGiorno, giorno)
                If giorno > 40 Then giorno -= 40

                For i As Integer = 0 To ArrayMesi.Length - 1
                    If ArrayMesi(i) = sMese Then
                        mese = 1 + i
                    End If
                Next

                DataNascita = New Date(anno, mese, giorno)
            End If

            Return DataNascita
        End Get
    End Property

End Class
