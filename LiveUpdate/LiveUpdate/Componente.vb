Imports System.IO

Public Class Componente

    Private mDatiServer As DataRow
    Private mDeposito As DepositoLocale

    Sub New(ByRef Deposito As DepositoLocale,
            ByRef DatiRiferimento As DataRow)

        mDeposito = Deposito
        mDatiServer = DatiRiferimento

        'creo la cartella di destinazione del componente nel caso non esistesse
        Directory.CreateDirectory(Me.PathDestinazione)
    End Sub

    Public ReadOnly Property CartellaDeposito() As String
        Get
            'se il file non è per tutti ma per un ambiente specifico aggiungo l'ambiente
            Select Case mDatiServer("Ambiente")
                Case "DIR", "DIR2PP"
                    Return mDeposito.PathDepositoDIR
                Case "PP"
                    Return mDeposito.PathDepositoPP
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public ReadOnly Property UrlComponente() As String
        Get
            Return Path.Combine(Me.OrigineDownload, mDatiServer("Modulo")).Replace("\", "/")
        End Get
    End Property

    Public ReadOnly Property OrigineDownload() As String
        Get
            Return Path.Combine(DepositoServer.OrigineVersione, mDatiServer("Origine")).Replace("\", "/")
        End Get
    End Property

    Public ReadOnly Property NomeComponente() As String
        Get
            If mDatiServer("Modulo").EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase) Then
                'se finisce per zip tolgo l'estensione che è solo fittizia e utile per il download
                Return Path.ChangeExtension(mDatiServer("Modulo"), Nothing)
            Else
                Return mDatiServer("Modulo")
            End If
        End Get
    End Property

    Public ReadOnly Property PathDestinazione() As String
        Get
            If mDatiServer("PathDestinazione") Is DBNull.Value Then
                mDatiServer("PathDestinazione") = ""
            End If

            Select Case mDatiServer("Unita")
                Case "L" 'locale
                    Return Path.Combine(Utx.Globale.Paths.CartellaApp, mDatiServer("PathDestinazione"))
                Case "R" 'rete
                    Return Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, mDatiServer("PathDestinazione"))
                Case Else 'A=percorso assoluto
                    Return mDatiServer("PathDestinazione")
            End Select
        End Get
    End Property

    Public ReadOnly Property FullPathComponente() As String
        Get
            Return Path.Combine(Me.PathDestinazione, Me.NomeComponente)
        End Get
    End Property

    Public ReadOnly Property FullPathComponente2NomeFile() As String
        Get
            'notare che il nome del file contiene il path della posizione del file
            'con + al posto di : e = al posto di \
            Return Me.FullPathComponente.Replace("\", "=").Replace(":", "+")
        End Get
    End Property

    Public ReadOnly Property NomeFile2FullPathComponente() As String
        Get
            'notare che il nome del file contiene il path della posizione del file
            'con + al posto di : e = al posto di \
            Return Me.FullPathComponente.Replace("=", "\").Replace("+", ":")
        End Get
    End Property

    Public ReadOnly Property FullPathComponenteNelDeposito() As String
        Get
            'path del nuovo componente nel deposito
            Select Case mDatiServer("Ambiente")
                Case "DIR"
                    Return Path.Combine(mDeposito.PathDepositoDIR, Me.FullPathComponente2NomeFile)
                Case "PP"
                    Return Path.Combine(mDeposito.PathDepositoPP, Me.FullPathComponente2NomeFile)
                Case Else 'DIR/PP
                    Return Path.Combine(mDeposito.PathDeposito, Me.FullPathComponente2NomeFile)
            End Select
        End Get
    End Property

    Public ReadOnly Property FullPathComponenteNelleCorrezioni() As String
        Get
            'path del nuovo componente nella cartella correzioni
            Return Path.Combine(mDeposito.PathCorrezioni, Me.FullPathComponente2NomeFile)
        End Get
    End Property

    Public ReadOnly Property FullPathFlagZip() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaUpdateLocale, Path.GetFileNameWithoutExtension(Me.NomeComponente) & ".LIVEUP")
        End Get
    End Property

    Public ReadOnly Property EsisteComponenteNelDeposito() As Boolean
        Get
            'path del nuovo componente nella cartella correzioni
            Return File.Exists(Me.FullPathComponenteNelDeposito)
        End Get
    End Property

    Private mErroreInstallazione As Boolean = False
    Public Property ErroreInstallazione() As Boolean
        Get
            Return mErroreInstallazione
        End Get
        Set(value As Boolean)
            mErroreInstallazione = value
        End Set
    End Property

    Public Function VersioneInstallata(FullPathFile As String) As String
        Try
            Return Utx.NetFunc.FileToMD5(FullPathFile)
        Catch ex As Exception
            'in caso di errore il file potrebbe essere illegibile e lo sostituisco
            Log.Errore(ex)
            Return "?"
        End Try
    End Function

    Public Function VersioneRiferimento() As String
        Try
            Return mDatiServer("MD5")
        Catch ex As Exception
            Log.Errore(ex)
            Return "?"
        End Try
    End Function

    Private Sub CopiaNelDeposito()
        Try
            'se il file non esiste nel deposito ce lo metto
            If Not File.Exists(Me.FullPathComponenteNelDeposito) Then
                File.Copy(Me.FullPathComponente, Me.FullPathComponenteNelDeposito)
            End If

        Catch ex As Exception
            Log.Info(ex.Message)
        End Try
    End Sub

    Friend Sub AnalisiComponente()
        Try
#If DEBUG Then
            'If Path.GetFileName(Me.NomeComponente).ToLower.StartsWith("anag") Then
            '    MsgBox(Me.NomeComponente)
            'End If
#End If
            If VersioneOk(Me.FullPathComponente) = True Then
                'la versione corrisponde e non è un pacchetto zip
                Log.Info($"- {Me.NomeComponente}: Ok ({mDatiServer("Livello")} - {mDatiServer("Versione")} - {Me.VersioneInstallata(Me.FullPathComponente)})")
                'se il file non esiste nel deposito ce lo metto
                Me.CopiaNelDeposito()
            Else
                'la versione NON corrisponde
                'per sicurezza cancello il file nelle correzioni se già esiste per sostituirlo
                File.Delete(Me.FullPathComponenteNelleCorrezioni)

                'controllo la versione del file nel deposito e se è sbagliata lo cancello
                If VersioneOk(Me.FullPathComponenteNelDeposito) = False Then
                    File.Delete(Me.FullPathComponenteNelDeposito)
                End If

                'se non esiste nel deposito 
                If Not Me.EsisteComponenteNelDeposito Then

                    'lo scarico da utools e lo metto nel deposito
                    If DownloadFile(Me.UrlComponente, Me.FullPathComponenteNelDeposito) = True Then

                        'se c'è l'MD5
                        If (mDatiServer("MD5").ToString.Length > 0) Then

                            'controllo che l'MD5 del file scaricato sia corretto
                            If (mDatiServer("MD5") <> Utx.NetFunc.FileToMD5(Me.FullPathComponenteNelDeposito)) Then

                                'cancello il file perchè MD5 non corrisponde
                                Log.Info("* Componente cancellato: valore MD5 del file scaricato non risulta corretto")
                                File.Delete(Me.FullPathComponenteNelDeposito)
                                Me.ErroreInstallazione = True
                            End If
                        End If
                    Else
                        'in caso di download non riuscito
                        'cancello il file perchè potrebbe essere rimasto un file parziale danneggiato
                        File.Delete(Me.FullPathComponenteNelDeposito)
                        Me.ErroreInstallazione = True
                    End If
                End If

                'se ora esiste nel deposito la versione è sicuramente corretta
                If Me.EsisteComponenteNelDeposito Then
                    If Path.GetExtension(Me.NomeComponente).ToLower = ".zip" Then
                        'per i pacchetti zip
                        If Utx.LibreriaZip.UnZipFileRename(Me.FullPathComponenteNelDeposito, Utx.Globale.Paths.CartellaApp).Count > 0 Then
                            Log.Info($"> {Me.NomeComponente}: installato ({mDatiServer("Versione")})", 3)
                            File.WriteAllText(Me.FullPathFlagZip, mDatiServer("MD5"))
                        End If
                        'cancello il pacchetto zippato dopo l'installazione
                        File.Delete(Me.FullPathComponente)
                    Else
                        'installo il componente o lo copio nelle correzioni da effettuare al riavvio
                        InstallaComponente()
                        'segna se è esplicitamente richiesto il riavvio
                        Versione.RiavvioRichiesto = (Versione.RiavvioRichiesto Or mDatiServer("Riavvio"))
#If DEBUG Then
                        Versione.RiavvioRichiesto = True
#End If
                    End If
                End If
            End If

        Catch ex As Exception
            Log.Info($"Errore nel controllo del componente {Me.NomeComponente}: {ex.Message}")
            Me.ErroreInstallazione = True
        End Try
    End Sub

    ''' <summary>
    ''' Confronta la versione del file installato con quella di riferimento
    ''' </summary>
    Private Function VersioneOk(FileDaControllare As String) As Boolean
        Try
            Dim VerInstallata, VerRiferimento, InfoInstallata As String

            If mDatiServer("SoloEsistenza") = True Then
                'devo solo controllare l'esistenza del file senza controllare la versione
                If File.Exists(FileDaControllare) = False Then
                    VerInstallata = "mancante"
                    InfoInstallata = "?"
                    VerRiferimento = Me.VersioneRiferimento()
                    VersioneOk = False
                Else
                    VerInstallata = ""
                    InfoInstallata = FileVersionInfo.GetVersionInfo(FileDaControllare).ProductVersion
                    VerRiferimento = ""
                    VersioneOk = True
                End If
            ElseIf Path.GetExtension(FileDaControllare).ToLower = ".zip" Then
                If File.Exists(Me.FullPathFlagZip) Then
                    VerInstallata = File.ReadAllText(Me.FullPathFlagZip)
                Else
                    'l'md5 non c'è
                    VerInstallata = ""
                End If
                'se l'md5 non inizia per -err ed è lungo 32 caratteri
                If (VerInstallata.ToUpper.StartsWith("-ERR") = False) AndAlso (VerInstallata.Length = 32) Then
                    'c'è l'md5 e faccio il confronto
                    VerRiferimento = Me.VersioneRiferimento
                    InfoInstallata = "zip"
                    VersioneOk = (VerInstallata = VerRiferimento)
                Else
                    'l'md5 non c'è
                    VerInstallata = "mancante"
                    InfoInstallata = "?"
                    VerRiferimento = Me.VersioneRiferimento()
                    VersioneOk = False
                End If

            ElseIf File.Exists(FileDaControllare) = False Then
                'il file non c'è
                VerInstallata = "mancante"
                InfoInstallata = "?"
                VerRiferimento = Me.VersioneRiferimento()
                VersioneOk = False
            Else
                VerInstallata = Me.VersioneInstallata(FileDaControllare)
                InfoInstallata = FileVersionInfo.GetVersionInfo(FileDaControllare).ProductVersion
                VerRiferimento = Me.VersioneRiferimento()
                VersioneOk = (VerInstallata = VerRiferimento)
            End If

            'scrivo il log
            If VersioneOk = False Then
                Log.Info(String.Format("* {0}: Correggere", Path.GetFileName(FileDaControllare)))
                Log.Info(String.Format("> Installato:  MD5({0}) Versione({1})", VerInstallata, InfoInstallata), 3)
                Log.Info(String.Format("> Riferimento: MD5({0}) Versione({1}) Livello({2})", VerRiferimento, mDatiServer("Versione"), mDatiServer("Livello")), 3)
            End If

        Catch ex As Exception
            Log.Info(String.Format("*** Errore in VersioneOk ({0})", FileDaControllare), ex)
            Return False
        End Try
    End Function

    Private Sub InstallaComponente()

        Dim DeskModulo As String = ""

        Try
            DeskModulo = String.Format("- {0} ({1}){2}",
                                       mDatiServer("Note"),
                                       mDatiServer("Versione"),
                                       Environment.NewLine)

            'sposto il file nella cartella di rollback
            If File.Exists(Me.FullPathComponente) Then
                File.Move(Me.FullPathComponente, Path.Combine(mDeposito.CartellaRollback, Me.NomeComponente))
            End If

            'copio la nuova versione
            File.Copy(Me.FullPathComponenteNelDeposito, Me.FullPathComponente)

            'copia ok: installato (altrimenti salta all'eccezione)
            Versione.ComponentiInstallati.Add(Me.FullPathComponente)

            If mDatiServer("Notifica") OrElse mDatiServer("Riavvio") Then
                Versione.VisualizzaNotifica = True
                Versione.ComponentiModificati += DeskModulo
            End If

            Log.Info(String.Format("> {0}: installato ({1})", Me.NomeComponente, mDatiServer("Versione")), 3)

        Catch ex As Exception
            InstallaComponenteConRinomina(DeskModulo)
        End Try
    End Sub

    Private Sub InstallaComponenteConRinomina(DeskModulo As String)
        Try
            'installo con la rinomina del file bloccato
            Dim NuovoNome As String = String.Format("UTOLD.{0}.{1}.{2}",
                                                    Environment.UserName,
                                                    Format(Now, "HHmmss"),
                                                    Path.GetFileName(Me.FullPathComponente))

            'rinomino il file bloccato
            My.Computer.FileSystem.RenameFile(Me.FullPathComponente, NuovoNome)

            'copio la nuova versione
            File.Copy(Me.FullPathComponenteNelDeposito, Me.FullPathComponente)

            'copia ok: aggiorno notifica
            Versione.ComponentiInstallati.Add(Me.FullPathComponente)
            'chiedo comunque il riavvio per agganciare il file nuovo
            Versione.RiavvioRichiesto = True

            If mDatiServer("Notifica") OrElse mDatiServer("Riavvio") Then
                Versione.VisualizzaNotifica = True
                Versione.ComponentiModificati += DeskModulo
            End If

            Log.Info(String.Format("> {0}: installato con rinomina ({1})", Me.NomeComponente, mDatiServer("Versione")))

        Catch ex As Exception
            Log.Info(ex)
            Me.ErroreInstallazione = True
        End Try
    End Sub

    Public Sub RollbackComponente()
        Try
            Dim FileOld As String = Path.Combine(mDeposito.CartellaRollback, Me.NomeComponente)

            If File.Exists(FileOld) Then
                'riporto il file nella posizione originale
                File.Copy(FileOld, Me.FullPathComponente)
                Log.Info(String.Format("> Effettuato rollback del file {0}", Me.NomeComponente))
            End If

        Catch ex As Exception
            'installo con la rinomina del file bloccato
            Dim NuovoNome As String = String.Format("UTOLD.{0}.{1}.{2}", Environment.UserName, Format(Now, "HHmmss"), Path.GetFileName(Me.FullPathComponente))
            'rinomino il file bloccato
            My.Computer.FileSystem.RenameFile(Me.FullPathComponente, NuovoNome)
            File.Copy(Path.Combine(mDeposito.CartellaRollback, Me.NomeComponente), Me.FullPathComponente)
            Log.Info(String.Format("> Effettuato rollback con rinomina del file {0}", Me.NomeComponente))
        End Try
    End Sub
End Class
