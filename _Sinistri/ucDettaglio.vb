Imports System.Windows.Forms

Public Class ucDettaglio

    Public Event StampaSinistro(StampaNote As Boolean)
    Public Event SinistroCollegato(AgenziaSinistro As Integer, Eserciosinistro As Integer, NumeroSinistro As Integer)

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = Windows.Forms.DockStyle.Fill

        ImpostaControlli()
    End Sub

    Private mSinistroCorrente As Sinistro
    Public WriteOnly Property SinistroCorrente() As Sinistro
        Set(value As Sinistro)
            mSinistroCorrente = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        With tlpMain
            .Padding = New Padding(5)
        End With

        'sinistro
        InizializzaControllo({LabelSinistro, LabelGestione, LabelPolizza, LabelStato, LabelCollegati})
        InizializzaControllo({LabelNumeroSinistro, LabelPosizioni})
        InizializzaControllo({LabelAssicurato, LabelTarga, LabelControparte, LabelTargaControparte})
        InizializzaControllo({LabelDataSinistro, LabelDataApertura})
        InizializzaControllo({LabelCompagniaControparte, LabelTipoCid, LabelRamoSinistro, LabelTipoSinistro})
        InizializzaControllo({LabelPersoneCose, LabelTipoApertura, LabelPresentatore, LabelDenunciante})
        InizializzaControllo({LabelCarrozzeria, LabelTipoCarrozzeria})
        'polizza
        InizializzaControllo({LabelRamoPolizza, LabelSub, LabelProdotto, LabelConvenzione, LabelQuota})
        InizializzaControllo({LabelFranchigia, LabelRamoGestione, LabelComparto})
        'gestione
        InizializzaControllo({LabelCLG, LabelLiquidatore, LabelInterventoLegale})
        'stato
        InizializzaControllo({LabelPagato, LabelPreventivo, LabelRiservaTecnica})
        InizializzaControllo({LabelStatoTecnico, LabelStatoBilancistico, LabelDataStatoTecnico, LabelDataStatoBilancistico, LabelUltimoPagamento})

        With dgvCollegati
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(0)
        End With
        Utx.NetFunc.DoppioBuffer(dgvCollegati)
    End Sub

    Public Sub InizializzaControllo(controlli() As Label)
        For Each c In controlli
            c.Font = Utx.AppFont.Bold
        Next
    End Sub

    Public Sub VisualizzaDettaglio()
        On Error Resume Next
        Do While mSinistroCorrente.Decodifica.LetturaDecodifiche = False : Loop

        'sinistro
        LabelSinistro.Text = String.Format("Sinistro {0}", mSinistroCorrente.Decodifica.TipoApplicativo)
        LabelNumeroSinistro.Text = mSinistroCorrente.IdSinistro
        LabelPosizioni.Text = mSinistroCorrente.Posizioni
        LabelDataSinistro.Text = mSinistroCorrente.DataSinistro
        LabelDataApertura.Text = mSinistroCorrente.DataApertura
        LabelAssicurato.Text = mSinistroCorrente.Assicurato
        LabelTarga.Text = mSinistroCorrente.TargaAssicurato
        LabelControparte.Text = mSinistroCorrente.Controparte
        LabelTargaControparte.Text = mSinistroCorrente.TargaControparte
        LabelCompagniaControparte.Text = mSinistroCorrente.CompagniaControparte
        If mSinistroCorrente.CompagniaControparte = 0 Then
            LabelCompagniaControparteDesk.Text = "Non disponibile"
        Else
            LabelCompagniaControparteDesk.Text = mSinistroCorrente.Decodifica.CompagniaControparte
        End If
        LabelTipoCid.Text = mSinistroCorrente.TipoCid
        LabelTipoCidDesk.Text = mSinistroCorrente.Decodifica.TipoCid
        LabelRamoSinistro.Text = mSinistroCorrente.RamoSinistro
        LabelRamoSinistroDesk.Text = mSinistroCorrente.Decodifica.RamoSinistro
        LabelTipoSinistro.Text = mSinistroCorrente.TipoSinistro
        LabelTipoSinistroDesk.Text = mSinistroCorrente.Decodifica.TipoSinistro
        LabelPersoneCose.Text = mSinistroCorrente.DanniPersoneCose
        LabelPersoneCoseDesk.Text = mSinistroCorrente.Decodifica.DanniPersoneCose
        LabelTipoApertura.Text = mSinistroCorrente.TipoApertura
        LabelTipoAperturaDesk.Text = mSinistroCorrente.Decodifica.TipoApertura
        LabelPresentatore.Text = mSinistroCorrente.Presentatore
        LabelPresentatoreDesk.Text = mSinistroCorrente.Decodifica.Presentatore
        LabelDenunciante.Text = mSinistroCorrente.Denunciante
        LabelDenuncianteDesk.Text = mSinistroCorrente.Decodifica.Denunciante
        LabelCarrozzeria.Text = mSinistroCorrente.Carrozzeria
        LabelCarrozzeriaDesk.Text = mSinistroCorrente.Decodifica.Carrozzeria
        LabelTipoCarrozzeria.Text = mSinistroCorrente.TipoCarrozzeria
        LabelTipoCarrozzeriaDesk.Text = mSinistroCorrente.Decodifica.TipoCarrozzeria
        'polizza
        LabelRamoPolizza.Text = mSinistroCorrente.IdPolizza
        LabelSub.Text = mSinistroCorrente.SubAgenzia
        LabelSubDesk.Text = mSinistroCorrente.Decodifica.Figura
        LabelProdotto.Text = mSinistroCorrente.CodiceProdotto
        LabelProdottoDesk.Text = mSinistroCorrente.Decodifica.Prodotto
        LabelConvenzione.Text = mSinistroCorrente.Convenzione
        LabelConvenzioneDesk.Text = mSinistroCorrente.Decodifica.Convenzione
        LabelQuota.Text = mSinistroCorrente.NostraQuota.ToString + "%"
        LabelFranchigia.Text = mSinistroCorrente.FranchigiaPTF
        LabelRamoGestione.Text = mSinistroCorrente.RamoGestione
        LabelRamoGestioneDesk.Text = mSinistroCorrente.Decodifica.RamoGestione
        LabelComparto.Text = mSinistroCorrente.Comparto
        LabelCompartoDesk.Text = mSinistroCorrente.Decodifica.Comparto
        'collegati
        LabelCollegati.Text = String.Format("Sinistri collegati - cartella {0}", mSinistroCorrente.Cartella)
        dgvCollegati.DataSource = mSinistroCorrente.SinistriCollegati
        dgvCollegati.AutoResizeColumns()
        'gestione
        LabelCLG.Text = mSinistroCorrente.Ispettorato
        LabelCLGDesk.Text = mSinistroCorrente.Decodifica.Ispettorato
        LabelLiquidatore.Text = mSinistroCorrente.CodiceLiquidatore
        LabelLiquidatoreDesk.Text = mSinistroCorrente.Decodifica.Liquidatore
        LabelInterventoLegale.Text = mSinistroCorrente.DataInterventoLegale
        LabelInterventoLegaleDesk.Text = mSinistroCorrente.Decodifica.InterventoLegale
        'stato
        LabelPagato.Text = mSinistroCorrente.Pagato
        LabelPreventivo.Text = mSinistroCorrente.PrimoPreventivo
        LabelRiservaTecnica.Text = mSinistroCorrente.RiservaTecnica
        LabelStatoTecnico.Text = mSinistroCorrente.StatoTecnico
        LabelDataStatoTecnico.Text = mSinistroCorrente.DataStatoTecnico
        LabelStatoTecnicoDesk.Text = Sinistro.Decodifiche.Stato(mSinistroCorrente.StatoTecnico)
        LabelStatoBilancistico.Text = mSinistroCorrente.StatoBilancistico
        LabelDataStatoBilancistico.Text = mSinistroCorrente.DataStatoBilancistico
        LabelStatoBilancisticoDesk.Text = Sinistro.Decodifiche.Stato(mSinistroCorrente.StatoBilancistico)
        LabelUltimoPagamento.Text = mSinistroCorrente.UltimoPagamento
    End Sub

    Private Sub ButtonContatti_Click(sender As Object, e As EventArgs) Handles ButtonContatti.Click
        Using f As New FormContatti
            f.Sinistro = mSinistroCorrente
            f.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonGuidaStati_Click(sender As Object, e As EventArgs) Handles ButtonGuidaStati.Click
        Process.Start("http://www.utools.it/Unitools/Doc/InfoStatiSinistro.htm")
    End Sub

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        RaiseEvent StampaSinistro(False)
    End Sub

    Private Sub ButtonStampaNote_Click(sender As Object, e As EventArgs) Handles ButtonStampaNote.Click
        RaiseEvent StampaSinistro(True)
    End Sub

    Private Sub dgvCollegati_DoubleClick(sender As Object, e As EventArgs) Handles dgvCollegati.DoubleClick
        If dgvCollegati.CurrentRow IsNot Nothing Then
            RaiseEvent SinistroCollegato(dgvCollegati.CurrentRow.Cells("Ente").Value,
                                         dgvCollegati.CurrentRow.Cells("Esercizio").Value,
                                         dgvCollegati.CurrentRow.Cells("Numero").Value)
        End If
    End Sub
End Class
