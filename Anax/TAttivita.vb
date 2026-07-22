Public Class TAttivita
    Inherits _TAttivita

    Private Shared mTipoAttivitaLista As Dictionary(Of String, String)

    Public ReadOnly Property TipoAttivitaDescrizione As String
        Get
            If mTipoAttivitaLista Is Nothing Then
                mTipoAttivitaLista = New Dictionary(Of String, String)
                With Utx.FunzioniDb.CreaDataTableReader("SELECT TipoAttivita, DesAttivita FROM Ana_AttivitaTipo")
                    Do While .Read
                        mTipoAttivitaLista.Add(.GetString(0), .GetString(1))
                    Loop
                End With
            End If
            Return mTipoAttivitaLista(TipoAttivita)
        End Get
    End Property

    Public ReadOnly Property Descrizione As String
        Get
            Dim s As String = ""
            If TipoAttivita <> "" Then
                s &= " " & TipoAttivitaDescrizione
            End If
            If ImpresaSettore <> "" Then
                s &= " " & ImpresaSettore
            End If
            If ImpresaPubblica Then
                s &= " (pubblico)"
            End If
            If s <> "" Then
                s = s.Substring(1)
            End If

            Return s
        End Get
    End Property

End Class
