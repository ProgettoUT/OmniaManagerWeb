Imports Utx.FunzioniDb

Public Enum TipoRecapitoEnum
    Telefono = &H1
    Cellulare = &H2
    Fax = &H4
    Email = &H8
    Voip = &H10
    SocialNet = &H20
    SitoWeb = &H40
    Voce = Telefono Or Cellulare Or Voip
    Tutti = Telefono Or Cellulare Or Fax Or Email Or Voip Or SocialNet Or SitoWeb
End Enum

Public Class Recapiti
    Inherits List(Of Recapito)

    Public Sub New()
    End Sub

    Public Sub New(recapiti As List(Of Recapito))
        AddRange(recapiti)
    End Sub

    Public Shared Function GetRecapitiCliente(CodiceFiscale As String) As Recapiti
        Try
            Dim recapiti As New Recapiti
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(
                "SELECT * FROM Clienti WHERE CodiceFiscale = " & TO_STRING(CodiceFiscale))
            Dim dr As DataRow
            If Risposta.DataTable.Rows.Count > 0 Then
                dr = Risposta.DataTable.Rows(0)
                With dr
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Telefono1")), TipoRecapitoEnum.Telefono))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Telefono2")), TipoRecapitoEnum.Telefono))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Email")), TipoRecapitoEnum.Email))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Fax")), TipoRecapitoEnum.Fax))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Cellulare")), TipoRecapitoEnum.Cellulare))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelReferente")), TipoRecapitoEnum.Telefono, NullToValue(.Item("NomeReferente"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelAziendale")), TipoRecapitoEnum.Telefono))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("RisTelefono")), TipoRecapitoEnum.Telefono, NullToValue(.Item("RisTelefonoNota"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("RisCellulare")), TipoRecapitoEnum.Cellulare, NullToValue(.Item("RisCellulareNota"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("RisMail")), TipoRecapitoEnum.Email, NullToValue(.Item("RisMailNota"))))
                End With
            End If
            Risposta = Utx.WsCommand.ExecuteNonQuery(
                "SELECT * FROM Ana_soggetto WHERE CodiceFiscale = " & TO_STRING(CodiceFiscale))
            If Risposta.DataTable.Rows.Count > 0 Then
                dr = Risposta.DataTable.Rows(0)
                With dr
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("Voip")), TipoRecapitoEnum.Voip))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("SocialNet")), TipoRecapitoEnum.SocialNet))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("SitoWeb")), TipoRecapitoEnum.SitoWeb))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelNumero1")), TipoRecapitoEnum.Telefono, NullToValue(.Item("TelNota1"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelNumero2")), TipoRecapitoEnum.Cellulare, NullToValue(.Item("TelNota2"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelNumero3")), TipoRecapitoEnum.Telefono, NullToValue(.Item("TelNota3"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelNumero4")), TipoRecapitoEnum.Cellulare, NullToValue(.Item("TelNota4"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("EmailIndirizzo1")), TipoRecapitoEnum.Email, NullToValue(.Item("EmailNota1"))))
                    AddIfOk(recapiti, New Recapito(NullToValue(.Item("EmailIndirizzo2")), TipoRecapitoEnum.Email, NullToValue(.Item("EmailNota2"))))
                End With
            End If
            Return recapiti
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return New Recapiti
        End Try
    End Function

    Public Shared Function GetRecapitiLiquidatori(CodiceLiquidatore As Integer) As Recapiti
        Dim recapiti As New Recapiti

        With CreaDataTableReader("SELECT * FROM Liquidatori WHERE Codice = " & TO_NUMBER(CodiceLiquidatore))
            If .Read Then
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("Telefono")), TipoRecapitoEnum.Telefono, .Item("Nome")))
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("TelefonoClg")), TipoRecapitoEnum.Telefono, .Item("Nome")))
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("Email")), TipoRecapitoEnum.Email, .Item("Nome")))
            End If
            .Close()
        End With

        Return recapiti
    End Function

    Public Shared Function GetRecapitiPeriti(CodicePerito As String) As Recapiti
        Dim recapiti As New Recapiti

        With CreaDataTableReader("SELECT * FROM PeritoIncaricato WHERE IdPeritoSAP = " & TO_STRING(CodicePerito))
            If .Read Then
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("Telefono")), TipoRecapitoEnum.Telefono, String.Format("{0} {1}", .Item("Cognome"), .Item("Nome"))))
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("Cellulare")), TipoRecapitoEnum.Cellulare, String.Format("{0} {1}", .Item("Cognome"), .Item("Nome"))))
                AddIfOk(recapiti, New Recapito(NullToValue(.Item("Email")), TipoRecapitoEnum.Email, String.Format("{0} {1}", .Item("Cognome"), .Item("Nome"))))
            End If
            .Close()
        End With

        Return recapiti
    End Function

    Public Shared Function GetRecapitiLiquido() As Recapiti
        Dim recapiti As New Recapiti

        AddIfOk(recapiti, New Recapito("nss@unipolsai.it", TipoRecapitoEnum.Email))

        Return recapiti
    End Function

    Private Shared Sub AddIfOk(Recapiti As Recapiti, Recapito As Recapito)
        If Recapito.IsOk Then
            Recapiti.Add(Recapito)
        End If
    End Sub

    Public Function Filtra(TipoRecapito As TipoRecapitoEnum) As Recapiti
        Return New Recapiti(Me.FindAll(Function(c) (c.TipoRecapito And TipoRecapito) = c.TipoRecapito))
    End Function

    Public Function Cellulari() As Recapiti
        Return Filtra(TipoRecapitoEnum.Cellulare)
    End Function

    Public Function Emails() As Recapiti
        Return Filtra(TipoRecapitoEnum.Email)
    End Function

    Public Function Telefoni() As Recapiti
        Return Filtra(TipoRecapitoEnum.Telefono Or TipoRecapitoEnum.Cellulare)
    End Function
End Class

Public Class Recapito
    Public TipoRecapito As TipoRecapitoEnum
    Public Contatto As String
    Public Nota As String

    Public Sub New(Contatto As String, TipoRecapito As TipoRecapitoEnum)
        Me.Contatto = Contatto
        Me.TipoRecapito = TipoRecapito
    End Sub

    Public Sub New(Contatto As String, TipoRecapito As TipoRecapitoEnum, Nota As String)
        Me.Contatto = Contatto
        Me.TipoRecapito = TipoRecapito
        Me.Nota = Nota
    End Sub

    Public Function IsOk() As Boolean
        If String.IsNullOrEmpty(Contatto) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
