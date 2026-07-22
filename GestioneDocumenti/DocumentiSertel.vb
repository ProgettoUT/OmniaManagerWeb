
Public Class DocumentiSertel

    Private m_IdCartella As String
    Private m_IdFile As String
    Private m_Descrizione As String
    Private m_Mittente As String
    Private m_DataInvio As String
    Private m_FileExt As String
    Private m_Migrato As String

    Public Sub New(StringaDoc As String)

        Dim Sep() As Char = {"=", "~"}
        Dim DatiDoc() As String

        Try
            If StringaDoc.Length = 0 Then
                m_IdCartella = ""
                m_IdFile = ""
                m_Descrizione = "Non sono stati trovati documenti"
                m_Mittente = ""
                m_DataInvio = ""
                m_FileExt = ""
                m_Migrato = ""
            Else
                DatiDoc = StringaDoc.Split(Sep)

                m_IdCartella = DatiDoc(1)
                m_IdFile = DatiDoc(3) + "-" + DatiDoc(5) + "-" + DatiDoc(7)
                'sostituire / con - altrimenti le date  o la voce fattura/ricevuta fiscale
                'generano un errore in fase di salvataggio file
                m_Descrizione = Replace(DatiDoc(9), "/", "-", , , CompareMethod.Text)
                m_Mittente = DatiDoc(13)
                m_DataInvio = DatiDoc(15)
                m_FileExt = DatiDoc(17)
                m_Migrato = DatiDoc(19)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Public ReadOnly Property IdCartella() As String
        Get
            IdCartella = m_IdCartella
        End Get
    End Property

    Public ReadOnly Property IdFile() As String
        Get
            IdFile = m_IdFile
        End Get
    End Property

    Public ReadOnly Property FileExt() As String
        Get
            FileExt = m_FileExt
        End Get
    End Property

    Public ReadOnly Property Migrato() As String
        Get
            Migrato = m_Migrato
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return m_Descrizione
        End Get
    End Property

    Public ReadOnly Property DataInvio() As String
        Get
            Return m_DataInvio
        End Get
    End Property

    Public ReadOnly Property Mittente() As String
        Get
            Dim tmp() As String = m_Mittente.Split("-")
            Return tmp(UBound(tmp))
        End Get
    End Property

End Class
