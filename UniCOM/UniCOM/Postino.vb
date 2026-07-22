Imports System.IO
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Runtime.Remoting.Messaging

Public Class Postino

    Public Property Mittente() As String
    Public Property NomeMittente() As String
    Public Property InviaA() As New ArrayList
    Public Property InviaCc() As New ArrayList
    Public Property InviaCcn() As New ArrayList
    Public Property Oggetto() As String
    Public Property Testo() As String
    Public Property Smtp() As SmtpClient
    Public Property CartellaAllegati() As String
    Public Property PesoAllegati() As Double

    Private ReadOnly mCartellaMail As String
    Private ReadOnly mTipoInvio As Integer
    Private mAllegati As New ArrayList

    Private Const Titolo As String = "Invio e-mail"
    Private Const HostAUA As String = "smtp-relay.brevo.com"

    Public Esito As New EsitoServizio

    Sub New()
        Try
            'imposta smtp
            Dim SmtpSetting As String = Utx.Servizi.LeggiSmtp

            Smtp = New SmtpClient
            With Smtp
                'se nelle impostazioni non è stato inpostato un server SMTP usa quello di AUA
                If String.IsNullOrEmpty(SmtpSetting) OrElse String.IsNullOrEmpty(SmtpSetting.Split(";")(0)) Then
                    .Host = HostAUA
                    .Port = "587"
                    .Credentials = New Net.NetworkCredential("879efb001@smtp-brevo.com", "xsmtpsib-794d822de60f79b1641cb04f816a9982c323d078ccd1bfd6dc768dfc33f79cb6-VKPj7yQ4wn1GpLcF")
                    .EnableSsl = True
                Else
                    .Host = SmtpSetting.Split(";")(0)
                    .Port = SmtpSetting.Split(";")(1)
                    .Credentials = New Net.NetworkCredential(SmtpSetting.Split(";")(2), SmtpSetting.Split(";")(3))
                    'SSL
                    If SmtpSetting.Split(";").Length = 5 Then
                        .EnableSsl = SmtpSetting.Split(";")(4)
                    Else
                        .EnableSsl = True
                    End If
                End If
                .Timeout = 20000
            End With
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Private _EmailAutomatica As Boolean = False
    Public Property EmailAutomatica() As Boolean
        Get
            Return _EmailAutomatica
        End Get
        Set(value As Boolean)
            _EmailAutomatica = value
        End Set
    End Property

    Public Shared Function CartellaMail() As String
        Dim Cartella As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, Guid.NewGuid.ToString + ".Mail")
        Directory.CreateDirectory(Cartella)
        Return Cartella
    End Function

    Public Shared Function MittenteAgenzia() As String
        Return String.Format("{0}@unipolsai.it", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
    End Function

    Public Sub ResetDestinatari()
        InviaA.Clear()
        InviaCc.Clear()
        InviaCcn.Clear()
    End Sub

    Public Sub Reset()
        Mittente = ""
        InviaA.Clear()
        InviaCc.Clear()
        InviaCcn.Clear()
        Oggetto = ""
        Testo = ""
        mAllegati.Clear()
    End Sub

    ''' <summary>
    ''' Trasforma la lista di destinatari in una stringa separata da ;
    ''' </summary>
    ''' <param name="Lista">ArrayList contenente la lista delle e.mail</param>
    ''' <returns>stringa dei destinatari</returns>
    ''' <remarks></remarks>
    Private Function Destinatari(Lista As ArrayList) As String
        Try
            Destinatari = ""
            For Each i As String In Lista
                If Destinatari = String.Empty Then
                    Destinatari = i
                Else
                    Destinatari += ";" + i
                End If
            Next
        Catch ex As Exception
            Destinatari = ""
            Globale.Log.Errore(ex)
        End Try
    End Function

    Public Sub AddAllegato(PathAllegato As String)
        Try
            'per le mail automatiche dove la cartella allegati non esiste la creo
            If Directory.Exists(CartellaAllegati) = False Then
                CartellaAllegati = Postino.CartellaMail
            End If

            'copio gli allegati nella cartella
            Dim CopiaAllegato As String = Path.Combine(CartellaAllegati, Path.GetFileName(PathAllegato))

            If File.Exists(CopiaAllegato) = False Then
                File.Copy(PathAllegato, CopiaAllegato)
            End If

            mAllegati.Add(CopiaAllegato)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function InviaMail() As EsitoServizio
        Try
            If PesoAllegati / 1048576 > 15 Then
                MsgBox("Consentito l'invio di allegati per un massimo di 15Mb. Provare a comprimere i file.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = "Allegati: consentito max 15Mb"
                Return Esito
            Else
                If _EmailAutomatica Then
                    Testo = String.Format("*** NON RISPONDERE A QUESTA E-MAIL. MESSAGGIO GENERATO AUTOMATICAMENTE.{0}{0}{1}", Environment.NewLine, Testo)
                End If

                InviaMailConSmtp() 'dal 13/01/2024 il servizio Unipol non funziona più
                Return Esito
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Return Esito
        Finally
            If (_EmailAutomatica = True) AndAlso (Directory.Exists(CartellaAllegati)) Then
                Directory.Delete(CartellaAllegati, True)
            End If
        End Try
    End Function

    Friend Sub InviaMailConSmtp()
        If Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.FORZA_SMTP_AUA, "False") = True Then
            'se c'è forzatura
            InviaMailConAUA()
        Else
            If Smtp.Host = HostAUA Then
                InviaMailConAUA()
            Else
                InviaMailConSmtpProprio()
            End If
        End If
    End Sub

    Friend Sub InviaMailConAUA()
        If Utx.FunzioniRete.PcInDominio Then
            InviaMailConWsAUA() 'se in dominio triangolo con il server
        Else
            InviaMailConSmtpAUA()
        End If
    End Sub

    Friend Sub InviaMailConSmtpAUA()
        Try
            'costruisco messaggio
            Using Msg As New MailMessage()
                Msg.From = New MailAddress("invioemail@auaonline.it", Me.NomeMittente)
                'A
                For Each i As String In InviaA
                    Msg.To.Add(New MailAddress(i))
                Next
                'Cc
                For Each i As String In InviaCc
                    Msg.CC.Add(New MailAddress(i))
                Next
                'Ccn
                For Each i As String In InviaCcn
                    Msg.Bcc.Add(New MailAddress(i))
                Next
                Msg.ReplyToList.Add(New MailAddress(Mittente))

                Msg.Subject = Oggetto

                If _EmailAutomatica = False Then
                    Msg.Body = String.Format("* La preghiamo, per rispondere, di utilizzare l'indirizzo mailto:{1}{0}{0}{2}", Environment.NewLine, Mittente, Testo)
                Else
                    Msg.Body = Testo
                End If

                'allegati
                For Each allegato As String In mAllegati
                    Msg.Attachments.Add(New Attachment(allegato))
                Next

                'invio
                Smtp.Send(Msg)
                Esito.EsitoChiamata = True
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        Finally
            mAllegati.Clear()
        End Try
    End Sub

    Friend Sub InviaMailConSmtpProprio()
        Try
            'costruisco messaggio
            Using Msg As New MailMessage()
                Msg.From = New MailAddress(Mittente, Me.NomeMittente)
                'A
                For Each i As String In InviaA
                    Msg.To.Add(New MailAddress(i))
                Next
                'Cc
                For Each i As String In InviaCc
                    Msg.CC.Add(New MailAddress(i))
                Next
                'Ccn
                For Each i As String In InviaCcn
                    Msg.Bcc.Add(New MailAddress(i))
                Next

                Msg.Subject = Oggetto
                Msg.Body = Testo

                'allegati
                For Each allegato As String In mAllegati
                    Msg.Attachments.Add(New Attachment(allegato))
                Next

                'invio
                Smtp.Send(Msg)
                Esito.EsitoChiamata = True
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        Finally
            mAllegati.Clear()
        End Try
    End Sub

    'Friend Sub InviaMailConWsUnipol()
    '    Try
    '        'funzione attivata attraverso BackgroundWorker1
    '        Const IDUnitools As String = "{FA591CC5-1C38-46c7-8250-D8B2512A2225}"

    '        Using Postino As New Utx.UnipolSendMailWS.Service1
    '            Postino.Timeout = 120000
    '            Postino.Credentials = Utx.Globale.UtenteCorrente.Credenziali

    '            Dim Risposta As String

    '            If mAllegati.Count = 0 Then
    '                'non ci sono allegati e invio
    '                Risposta = Postino.SendMail(IDUnitools, Mittente, Destinatari(InviaA), Destinatari(InviaCc), Destinatari(InviaCcn), Oggetto, Testo)
    '            Else
    '                'crea l'array di byte per passare l'allegato - se sono più di 5 allegati non arriva mai qui
    '                Dim NomeAllegato() As String = {"", "", "", "", ""}
    '                Dim o() As Object = {Nothing, Nothing, Nothing, Nothing, Nothing}

    '                For k As Integer = 0 To mAllegati.Count - 1
    '                    o(k) = File.ReadAllBytes(mAllegati.Item(k))
    '                    NomeAllegato(k) = Path.GetFileName(mAllegati.Item(k))
    '                Next

    '                'invio la mail
    '                Risposta = Postino.SendMailWithMultiAttachment(IDUnitools, Mittente, Destinatari(InviaA), Destinatari(InviaCc), Destinatari(InviaCcn),
    '                                                               Oggetto, Testo,
    '                                                               o(0), NomeAllegato(0), o(1), NomeAllegato(1), o(2), NomeAllegato(2),
    '                                                               o(3), NomeAllegato(3), o(4), NomeAllegato(4))
    '            End If

    '            'se è tutto ok il ws restituisce una stringa vuota
    '            If Risposta.Trim.Length = 0 Then
    '                Esito.EsitoChiamata = True
    '            Else
    '                Esito.EsitoChiamata = False
    '                Esito.MessaggioErrore = Risposta.Trim
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        If ex.Message.Contains("Maximum request length exceeded") Then
    '            MsgBox("Superata la dimensione massima consentita per gli allegati.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
    '            Globale.Log.Info(ex.Message)
    '            Esito.EsitoChiamata = False
    '            Esito.MessaggioErrore = ex.Message
    '        Else
    '            Globale.Log.Errore(ex)
    '            Esito.EsitoChiamata = False
    '            Esito.MessaggioErrore = ex.Message
    '        End If
    '    Finally
    '        mAllegati.Clear()
    '    End Try
    'End Sub

    Friend Sub InviaMailConWsAUA()
        Dim AllegatiZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, Guid.NewGuid.ToString & ".zip")
        Try
            'funzione attivata attraverso BackgroundWorker1
            Using PostinoAUA As New Utx.ServiziOMW.ServizioDatiOMW
                PostinoAUA.Proxy = Utx.Globale.UniProxy.Proxy
                PostinoAUA.Timeout = 120000

                'creo allegato zip contenente tutta la cartella allegati
                Dim Allegati As Byte()
                If CartellaAllegati Is Nothing Then
                    Allegati = New Byte() {}
                Else
                    'creo allegato zip contenente tutta la cartella allegati
                    File.Delete(AllegatiZip) 'per sicurezza
                    Utx.LibreriaZip.SevenZip.ZipFolder(CartellaAllegati, AllegatiZip)
                    Allegati = File.ReadAllBytes(AllegatiZip)
                End If

                Dim Risposta As String = PostinoAUA.InviaMailEx(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.Token,
                                                                Mittente, Me.NomeMittente,
                                                                Destinatari(InviaA), Destinatari(InviaCc), Destinatari(InviaCcn),
                                                                Oggetto, Testo,
                                                                Allegati,
                                                                _EmailAutomatica)

                'se è tutto ok
                If Risposta = "+OK" Then
                    Esito.EsitoChiamata = True
                Else
                    Esito.EsitoChiamata = False
                    Esito.MessaggioErrore = Risposta
                End If
            End Using

        Catch ex As Exception
            If ex.Message.Contains("Maximum request length exceeded") Then
                MsgBox("Superata la dimensione massima consentita per gli allegati.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Globale.Log.Info(ex.Message)
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = ex.Message
            Else
                Globale.Log.Errore(ex)
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = ex.Message
            End If
        Finally
            File.Delete(AllegatiZip)
            mAllegati.Clear()
        End Try
    End Sub
End Class
