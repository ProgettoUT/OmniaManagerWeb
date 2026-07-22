Public MustInherit Class CManifesto

    Public Enum EStatoInterno
        ESI_DASCARICARE
        ESI_DAELIMINARE
        ESI_TEMPORANEO
        ESI_DAAGGIORNARE
        ESI_NORMALE
        ESI_ELIMINATO_DASERVER
        ESI_ELIMINATO_DACLIENT
        ESI_INMANUTENZIONE
    End Enum

    Private Const CSI_DASCARICARE As String = "da scaricare"
    Private Const CSI_DAELIMINARE As String = "da eliminare"
    Private Const CSI_TEMPORANEO As String = "temporaneo"
    Private Const CSI_DAAGGIORNARE As String = "da aggiornare"
    Private Const CSI_NORMALE As String = "utilizzabile"
    Private Const CSI_ELIMINATO_DASERVER As String = "eliminato da server"
    Private Const CSI_ELIMINATO_DACLIENT As String = "eliminato da client"
    Private Const CSI_INMANUTENZIONE As String = "in manutenzione"

    Public Property Pacchetto As String
    Public Property Gruppo As String
    Public Property Tipo As String
    Public Property Nome As String
    Public Property DisplayNome As String
    Public Property Descrizione As String
    Public Property Documentazione As String
    Public Property AltezzaDocumentazione As Long = 0
    Public Property Contenuto As String
    Public Property Note As String
    Public Property Dominio As String
    Public Property Categoria As String
    Public Property Proprietario As String
    Public Property Stato As String
    Public Property UltAgg As String
    Public Property Visibile As Boolean
    Public Property RootPath As String
    Public Property Applicazioni As String

    Private mPrefissoKey As String

    Public MustOverride Function Save() As Boolean
    Public MustOverride Function Rename(NewName As String) As Boolean
    Public MustOverride Function Clone() As CManifesto

    Public Function Delete() As Boolean
        My.Computer.FileSystem.DeleteDirectory(ObjPath, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
        Return True
    End Function

    Friend Sub CopiaManifesto(ByRef oMfs As CManifesto)
        With oMfs
            .Pacchetto = Pacchetto
            .Gruppo = Gruppo
            .Tipo = Tipo
            .Nome = Nome
            .DisplayNome = DisplayNome
            .Descrizione = Descrizione
            .Documentazione = Documentazione
            .AltezzaDocumentazione = AltezzaDocumentazione
            .Contenuto = Contenuto
            .Note = Note

            .Dominio = Dominio
            .Categoria = Categoria
            .Proprietario = Proprietario

            .Stato = Stato
            .UltAgg = UltAgg
            .Visibile = Visibile
            .RootPath = RootPath
            .Applicazioni = Applicazioni
        End With
    End Sub

    Public Sub New(PrefissoKey As String, Tipo As String)
        UltAgg = New Date().Date
        Visibile = True
        Me.mPrefissoKey = PrefissoKey
        Me.Tipo = Tipo
    End Sub

    Public ReadOnly Property ObjPath() As String
        Get
            Return RootPath & Gruppo & "\" & Nome
        End Get
    End Property

    Public ReadOnly Property Filename(Optional suffix As String = "") As String
        Get
            If suffix = "" Then
                Return ObjPath & "\" & Nome
            Else
                Return ObjPath & "\" & Nome & "." & suffix
            End If
        End Get
    End Property

    Public ReadOnly Property Key() As String
        Get
            'Return mPrefissoKey & Nome
            Return Nome
        End Get
    End Property

    Public Property StatoInterno() As EStatoInterno
        Get
            If _Stato = CSI_NORMALE Then
                Return EStatoInterno.ESI_NORMALE
            ElseIf _Stato = CSI_INMANUTENZIONE Then
                Return EStatoInterno.ESI_INMANUTENZIONE
            ElseIf _Stato = CSI_DAAGGIORNARE Then
                Return EStatoInterno.ESI_DAAGGIORNARE
            ElseIf _Stato = CSI_DAELIMINARE Then
                Return EStatoInterno.ESI_DAELIMINARE
            ElseIf _Stato = CSI_DASCARICARE Then
                Return EStatoInterno.ESI_DASCARICARE
            ElseIf _Stato = CSI_ELIMINATO_DACLIENT Then
                Return EStatoInterno.ESI_ELIMINATO_DACLIENT
            ElseIf _Stato = CSI_ELIMINATO_DASERVER Then
                Return EStatoInterno.ESI_ELIMINATO_DASERVER
            ElseIf _Stato = CSI_TEMPORANEO Then
                Return EStatoInterno.ESI_TEMPORANEO
            Else
                Return EStatoInterno.ESI_NORMALE
            End If

        End Get
        Set(value As EStatoInterno)
            If value = EStatoInterno.ESI_DAAGGIORNARE Then
                _Stato = CSI_DAAGGIORNARE
            ElseIf value = EStatoInterno.ESI_INMANUTENZIONE Then
                _Stato = CSI_INMANUTENZIONE
            ElseIf value = EStatoInterno.ESI_DAELIMINARE Then
                _Stato = CSI_DAELIMINARE
            ElseIf value = EStatoInterno.ESI_DASCARICARE Then
                _Stato = CSI_DASCARICARE
            ElseIf value = EStatoInterno.ESI_ELIMINATO_DACLIENT Then
                _Stato = CSI_ELIMINATO_DACLIENT
            ElseIf value = EStatoInterno.ESI_ELIMINATO_DASERVER Then
                _Stato = CSI_ELIMINATO_DASERVER
            ElseIf value = EStatoInterno.ESI_TEMPORANEO Then
                _Stato = CSI_TEMPORANEO
            Else
                _Stato = CSI_NORMALE
            End If
        End Set
    End Property
End Class
