Imports System.IO

Public Class Documenti

    Private mFullPathDoc As String
    Private mNome As String
    Private mFormato As String
    Private mPratica As Pratiche

#Region "Costruttori"
    Public Sub New(Pratica As Pratiche, NomeDoc As String)
        Try
            mPratica = Pratica

            mFullPathDoc = Path.Combine(Pratica.FullPathPratica, NomeDoc)

            Dim f As New FileInfo(mFullPathDoc)
            mNome = f.Name
            mFormato = f.Extension.Substring(1).ToLower

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub New(Pratica As Pratiche, NomeDoc As String, Formato As String)
        Try
            mPratica = Pratica

            If NomeDoc.Trim.Length = 0 Then

                'se vuoto creo nome di default
                mNome = String.Format("Doc del {0}.{1}",
                                      Format(Now, "dd-MM-yyyy HH.mm.ss"),
                                      Formato.ToLower)
            Else
                mNome = String.Format("{0} del {1}.{2}",
                                      NomeDoc,
                                      Format(Now, "dd-MM-yyyy HH.mm.ss"),
                                      Formato.ToLower)
            End If

            mFullPathDoc = Path.Combine(Pratica.FullPathPratica, mNome)
            mFormato = Formato.ToLower

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

#Region "Proprietà"
    Public ReadOnly Property FullPathDoc() As String
        Get
            Return mFullPathDoc
        End Get
    End Property

    Public ReadOnly Property Nome() As String
        Get
            Return mNome
        End Get
    End Property

    Public ReadOnly Property NomeSenzaEstensione() As String
        Get
            Return Path.GetFileNameWithoutExtension(mNome)
        End Get
    End Property

    Public ReadOnly Property NomeSenzaProtocollo() As String
        Get
            If EsisteProtocollo() Then
                If Me.NomeSenzaEstensione.Length <= 23 Then
                    Return "Doc"
                Else
                    Return Me.NomeSenzaEstensione.Substring(0, Me.NomeSenzaEstensione.Length - 23).Trim
                End If
            Else
                Return Me.NomeSenzaEstensione
            End If
        End Get
    End Property

    Public ReadOnly Property NomeSenzaDataDocumento() As String
        Get
            Dim Data As String = DataDocumento

            If IsDate(DataDocumento) Then

                Dim Marcatore As String = String.Format("[{0}]", DataDocumento)

                Return Me.NomeSenzaProtocollo.Replace(Marcatore, "")
            Else
                Return Me.NomeSenzaProtocollo
            End If
        End Get
    End Property

    Public ReadOnly Property DataDocumento() As String
        Get
            Try
                Dim Pos1 As Integer = Me.Nome.IndexOf("[")
                Dim Pos2 As Integer = Me.Nome.IndexOf("]")

                Dim DataDoc As String = (Me.Nome.Substring(Pos1 + 1, Pos2 - Pos1 - 1))

                If IsDate(DataDoc) Then
                    Return DataDoc
                Else
                    Return ""
                End If

            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property DataDocumento(Doc As String) As String
        Get
            Try
                Dim Pos1 As Integer = Doc.IndexOf("[")
                Dim Pos2 As Integer = Doc.IndexOf("]")

                Dim DataDoc As String = (Doc.Substring(Pos1 + 1, Pos2 - Pos1 - 1))

                If IsDate(DataDoc) Then
                    Return DataDoc
                Else
                    Return ""
                End If

            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public ReadOnly Property Formato() As String
        Get
            Return mFormato.ToLower
        End Get
    End Property

    Public ReadOnly Property IsImmagine() As Boolean
        Get
            Return "TIF/TIFF/ICO/PNG/BMP/GIF/JPG/JPEG".Contains(mFormato.ToUpper)
        End Get
    End Property

    Public ReadOnly Property IsPdf() As Boolean
        Get
            Return (mFormato.ToUpper = "PDF")
        End Get
    End Property

    Public ReadOnly Property IsTiff() As Boolean
        Get
            Return (mFormato.ToUpper = "TIF") Or (mFormato.ToUpper = "TIFF")
        End Get
    End Property

    Public ReadOnly Property FormatoSertel() As Boolean
        Get
            Return Me.IsTiff OrElse Me.IsPdf
        End Get
    End Property

    Public ReadOnly Property Accodamento() As Boolean
        Get
            Return "TIF/TIFF".Contains(mFormato.ToUpper)
        End Get
    End Property

    Public ReadOnly Property Esiste() As Boolean
        Get
            Return File.Exists(mFullPathDoc)
        End Get
    End Property

    Public ReadOnly Property Dimensione() As String
        Get
            Dim fi As New FileInfo(mFullPathDoc)

            If fi.Length < 1000000 Then
                Return Format(fi.Length / 1024, "###0.0 KB")
            Else
                Return Format(fi.Length / 1048576, "###0.0 MB")
            End If
        End Get
    End Property
#End Region

#Region "Metodi"

    Public Function EsisteProtocollo() As Boolean
        Try
            Dim Protocollo As String = Right(Path.GetFileNameWithoutExtension(mNome), 19)
            'sostituisco i punti con i :
            Protocollo = Protocollo.Replace(".", ":")

            Return IsDate(Protocollo)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function EsisteProtocollo(NomeFile As String) As Boolean
        Try
            Dim Protocollo As String = Right(Path.GetFileNameWithoutExtension(NomeFile), 19)
            'sostituisco i punti con i :
            Protocollo = Protocollo.Replace(".", ":")

            Return IsDate(Protocollo)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' restituisce il protocollo del doc se esiste
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Il protocollo viene restituito come stringa per evitare errore nei formati ora con punto</remarks>
    Public Function Protocollo() As String
        Try
            'sostituisco i punti con i :
            Dim Tmp As String = Right(Path.GetFileNameWithoutExtension(mNome), 19).Replace(".", ":")

            If IsDate(Tmp) Then
                Return Right(Path.GetFileNameWithoutExtension(mNome), 19)
            Else
                Return Format(Now, "dd-MM-yyyy HH.mm.ss")
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Format(Now, "dd-MM-yyyy HH.mm.ss")
        End Try
    End Function

    Public Sub AggiungiProtocollo()
        Try
            If Not EsisteProtocollo() Then
                'cambio nome e full path (il path contiene già il punto)
                mNome = String.Format("{0} del {1}{2}",
                                      Path.GetFileNameWithoutExtension(mNome),
                                      Format(Now, "dd-MM-yyyy HH.mm.ss"),
                                      Path.GetExtension(mNome))

                mFullPathDoc = Path.Combine(mPratica.FullPathPratica, mNome)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub AggiungiProtocollo(DataProtocollo As Date)
        Try
            If Not EsisteProtocollo() Then
                'cambio nome e full path (il path contiene già il punto)
                mNome = String.Format("{0} del {1}{2}",
                                      Path.GetFileNameWithoutExtension(mNome),
                                      Format(DataProtocollo, "dd-MM-yyyy HH.mm.ss"),
                                      Path.GetExtension(mNome))

                mFullPathDoc = Path.Combine(mPratica.FullPathPratica, mNome)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function AggiungiProtocollo(NomeFile As String) As String
        Try
            If EsisteProtocollo(NomeFile) Then
                Return NomeFile
            Else
                'aggiungo il protocollo
                Return String.Format("{0} del {1}{2}",
                                     Path.GetFileNameWithoutExtension(NomeFile),
                                     Format(Now, "dd-MM-yyyy HH.mm.ss"),
                                     Path.GetExtension(NomeFile))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return NomeFile
        End Try
    End Function

    Public Shared Function AggiungiProtocollo(NomeFile As String, DataProtocollo As Date) As String
        Try
            If EsisteProtocollo(NomeFile) Then
                Return NomeFile
            Else
                'aggiungo il protocollo
                Return String.Format("{0} del {1}{2}",
                                     Path.GetFileNameWithoutExtension(NomeFile),
                                     Format(DataProtocollo, "dd-MM-yyyy HH.mm.ss"),
                                     Path.GetExtension(NomeFile))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return NomeFile
        End Try
    End Function

    Public Sub CopiaDocumento(FullPathFileOrigine As String,
                              Optional Sovrascrivi As Boolean = False)
        Try
            If Sovrascrivi = True Then
                File.Copy(FullPathFileOrigine, mFullPathDoc, True)
            Else
                If Me.Esiste Then
                    If MsgBox("Il file già esiste: sovrascrivere?",
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Copia file") = MsgBoxResult.Yes Then

                        File.Copy(FullPathFileOrigine, mFullPathDoc, True)
                    End If
                Else
                    File.Copy(FullPathFileOrigine, mFullPathDoc)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub SpostaDocumento(FullPathFileOrigine As String,
                               Optional Sovrascrivi As Boolean = False)
        Try
            If Sovrascrivi = True Then
                File.Delete(FullPathFileOrigine)
                File.Move(FullPathFileOrigine, mFullPathDoc)
            Else
                If Me.Esiste Then
                    If MsgBox("Il file già esiste: sovrascrivere?",
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Copia file") = MsgBoxResult.Yes Then

                        File.Delete(FullPathFileOrigine)
                        File.Move(FullPathFileOrigine, mFullPathDoc)
                    End If
                Else
                    File.Move(FullPathFileOrigine, mFullPathDoc)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub RinominaDocumento(NuovoNome As String)
        Try
            NuovoNome = String.Format("{0} del {1}.{2}", NuovoNome.Replace("/", "-"), Me.Protocollo, mFormato)
            Dim NuovoFullPathDoc As String = Path.Combine(mPratica.FullPathPratica, NuovoNome)

            If File.Exists(NuovoFullPathDoc) Then
                MsgBox(String.Format("Non posso rinominare il documento.{0}Un file con il nome '{1}' esiste già.",
                                     Environment.NewLine, NuovoNome), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                My.Computer.FileSystem.RenameFile(mFullPathDoc, NuovoNome)

                'modifico nome e path
                mNome = NuovoNome
                mFullPathDoc = NuovoFullPathDoc
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function CancellaDocumento(Optional Conferma As Boolean = True) As Boolean
        Try
            If Conferma Then
                If MsgBox(String.Format("File: {0}{1}Confermate la cancellazione?",
                                        Me.Nome, vbNewLine + vbNewLine),
                        MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                    File.Delete(mFullPathDoc)

                    Return True
                Else
                    Return False
                End If
            Else
                File.Delete(mFullPathDoc)
                Return True
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
#End Region
End Class
