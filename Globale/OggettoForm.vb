Imports System.Windows.Forms

Public Class OggettoForm

    Public Enum TipoForm
        ANAG
        SINISTRI
        DOCUMENTI
    End Enum
    Public Enum ChiusuraForm
        NORMALE
        HIDE
    End Enum

    Public Shared ListaForm As New List(Of OggettoForm)

    Sub New(Tipo As TipoForm, Oggetto As Form, Stato As FormWindowState)
        mTipo = Tipo
        mOggetto = Oggetto
        mStato = Stato
    End Sub

    Private mTipo As String
    Public ReadOnly Property Tipo() As String
        Get
            Return mTipo
        End Get
    End Property

    Private mOggetto As Form
    Public ReadOnly Property Oggetto() As Form
        Get
            Return mOggetto
        End Get
    End Property

    Private mStato As FormWindowState
    Public ReadOnly Property Stato() As FormWindowState
        Get
            Return mStato
        End Get
    End Property

    Public Shared Sub Add(Tipo As TipoForm, Oggetto As Form)
        'il form non è nella lista. va aggiunto alla lista nel new della classe form
        ListaForm.Add(New OggettoForm(Tipo, Oggetto, Oggetto.WindowState))
    End Sub

    Public Shared Sub Close(Tipo As TipoForm, Oggetto As Form)
        If Oggetto IsNot Nothing Then
            For Each f As OggettoForm In ListaForm
                If f.Tipo = Tipo Then
                    f.mStato = Oggetto.WindowState
                    Oggetto.Hide()
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Shared Function Show(Tipo As TipoForm) As Boolean
        For Each f As OggettoForm In ListaForm
            If f.Tipo = Tipo Then
                f.Oggetto.Show()
                f.Oggetto.WindowState = f.Stato
                f.Oggetto.TopMost = True
                f.Oggetto.TopMost = False
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function ShowDialog(Tipo As TipoForm) As Boolean
        For Each f As OggettoForm In ListaForm
            If f.Tipo = Tipo Then
                f.Oggetto.ShowDialog()
                f.Oggetto.WindowState = f.Stato
                f.Oggetto.TopMost = True
                f.Oggetto.TopMost = False
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function Esiste(Tipo As TipoForm) As Form
        For Each f As OggettoForm In ListaForm
            If f.Tipo = Tipo Then
                Return f.Oggetto
            End If
        Next
        Return Nothing
    End Function

    Public Shared Sub Dispose(Tipo As TipoForm)
        For Each f As OggettoForm In ListaForm
            If f.Tipo = Tipo Then
                ListaForm.Remove(f)
                f.Oggetto.Dispose()
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub DisposeAll()
        If ListaForm.Count > 0 Then
            For k As Integer = ListaForm.Count - 1 To 0 Step -1
                Dim f As OggettoForm = ListaForm.Item(k)
                f.Oggetto.Close()
                f.Oggetto.Dispose()
            Next
            ListaForm.Clear()
        End If
    End Sub

    Public Shared Function FinestreVisibili() As Integer
        FinestreVisibili = 0
        For Each f As OggettoForm In ListaForm
            If f.Oggetto.Visible = True Then
                FinestreVisibili += 1
            End If
        Next
    End Function
End Class
