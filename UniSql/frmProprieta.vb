Imports System.Drawing

Public Class frmProprieta

    Private Const sMODULENAME = "frmProprieta"
    Private m_manifesto As CManifesto

    Public Property Manifesto() As CManifesto
        Get
            Return m_manifesto
        End Get

        Set(value As CManifesto)
            Dim i As Integer
            m_manifesto = value

            With m_manifesto
                txtNome.Text = .DisplayNome
                Me.Text = "Proprietà di " & .DisplayNome
                txtDescription.Text = .Descrizione

                CmbType.Items.Add(.Tipo)
                CmbType.SelectedIndex = 0

                CmbDomain.Items.Add(.Dominio)
                CmbDomain.SelectedIndex = 0

                CmbOwner.Items.Add(.Proprietario)
                CmbOwner.SelectedIndex = 0

                CmbStatus.Items.Add(.Stato)
                CmbStatus.SelectedIndex = 0

                CmbCategory.Items.Add(.Categoria)
                CmbCategory.SelectedIndex = 0

                DTLastUpdate.Text = IIf(.UltAgg = "", Date.Today, .UltAgg)

                chkHidden.Checked = IIf(Not .Visibile, True, False)
            End With

            If TypeOf m_manifesto Is IProfilatore Then
                Dim profilatore As IProfilatore = m_manifesto

                For Each profilo As CProfilo In profilatore.Profili.Values
                    With lstProtezione.Items.Add(UCase(profilo.Nome))
                        .Font = New Font(.Font, FontStyle.Regular)
                    End With

                    Dim nAutType As EAutType
                    Dim sAutType As String = ""
                    For i = 0 To 5
                        Select Case i
                            Case 0 : nAutType = EAutType.AUT_LETTURA : sAutType = "Lettura"
                            Case 1 : nAutType = EAutType.AUT_SCRITTURA : sAutType = "Scrittura"
                            Case 2 : nAutType = EAutType.AUT_ELIMINAZIONE : sAutType = "Eliminazione"
                            Case 3 : nAutType = EAutType.AUT_ESECUZIONE : sAutType = "Esecuzione"
                            Case 4 : nAutType = EAutType.AUT_ESPORTAZIONE : sAutType = "Esportazione"
                            Case 5 : nAutType = EAutType.AUT_CONTROLLO_COMPLETO : sAutType = "Controllo completo"
                        End Select

                        With lstProtezione.Items.Add("        " & sAutType)
                            .SubItems.Add(IIf((profilo.Consenti And nAutType) = nAutType, "Si", "-"))
                            .SubItems.Add(IIf((profilo.Nega And nAutType) = nAutType, "Si", "-"))
                        End With
                    Next
                Next
            End If

            If TypeOf m_manifesto Is ICriterio Then
                Dim criterio As ICriterio = m_manifesto

                Dim s As String = "Nome [Etichetta, tipo, ""Valore Default""]" & vbNewLine & vbNewLine
                If criterio.Parametri IsNot Nothing Then
                    For Each parametro As CParametro In criterio.Parametri.Values
                        With parametro
                            s = s & .Nome & " [" & .Etichetta & ", " & .ParamTypeAsString & ", """ & .Valore & """]" & vbNewLine
                        End With
                    Next
                End If
                txtParametri.Text = s
            End If

            If Utente.IsAdmin And False Then
                txtNome.Enabled = True
                txtDescription.Enabled = True
                CmbType.Enabled = True
                CmbCategory.Enabled = True
                CmbDomain.Enabled = True
                CmbOwner.Enabled = True
                TxtNote.Enabled = True
                CmbStatus.Enabled = True
                DTLastUpdate.Enabled = True
                CmbCategory.Enabled = True
                TxtVersion.ReadOnly = True
                chkHidden.Enabled = True
                DTStatus.Enabled = True
            Else
                txtNome.Enabled = False
                txtDescription.Enabled = False
                CmbType.Enabled = False
                CmbCategory.Enabled = False
                CmbDomain.Enabled = False
                CmbOwner.Enabled = False
                TxtNote.Enabled = False
                CmbStatus.Enabled = False
                DTLastUpdate.Enabled = False
                CmbCategory.Enabled = False
                TxtVersion.Enabled = True
                chkHidden.Enabled = False
                DTStatus.Enabled = False
            End If

            setSchedaDescrizione()
        End Set
    End Property


    Private Sub setSchedaDescrizione()
        Dim sTitolo As String = ""
        Dim sDesc As String = ""
        Dim sProp As String = ""

        If Not m_manifesto Is Nothing Then
            sTitolo = m_manifesto.DisplayNome

            If m_manifesto.Descrizione <> "" Then
                sDesc = m_manifesto.Descrizione
            End If
            sProp = "Nome: " & m_manifesto.Nome & vbNewLine
            If m_manifesto.Gruppo <> "" Then
                sProp = sProp & "Libreria: " & m_manifesto.Gruppo
            End If
            If m_manifesto.Tipo <> "" Then
                sProp = sProp & ", Tipo: " & m_manifesto.Tipo & vbNewLine
            End If
            If m_manifesto.Categoria <> "" Then
                sProp = sProp & "Categoria: " & m_manifesto.Categoria
            End If
            If m_manifesto.Pacchetto <> "" Then
                sProp = sProp & ", Pacchetto: " & m_manifesto.Pacchetto & vbNewLine
            End If
            If m_manifesto.Stato <> "" Then
                sProp = sProp & "Stato: " & m_manifesto.Stato
            End If
            If m_manifesto.UltAgg <> "" Then
                sProp = sProp & ", Data ultima modifica: " & m_manifesto.UltAgg & vbNewLine & vbNewLine
            End If
            If m_manifesto.Note <> "" Then
                sProp = sProp & "Note: " & m_manifesto.Note
            End If
        End If

        lblTitolo.Text = sTitolo
        table.text = sDesc
        lblProperties.text = sProp
    End Sub

    Private Sub cmdChiudi_Click(sender As System.Object, e As System.EventArgs) Handles cmdChiudi.Click
        Me.Close()
    End Sub
End Class