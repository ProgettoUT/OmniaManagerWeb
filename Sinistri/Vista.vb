Imports System.IO

Public Class Vista

    Public Enum ElencoViste
        NESSUNA
        NORMALE
        SOPRAVVENIENZE
        PERIZIE
        INDICATORE_CLIENTE
        APERTI_CONTROPARTE
        VARIAZIONE_COSTI_MESE_ANNO
    End Enum

    Public Event AfterVistaChange(TipoVista As ElencoViste)
    Public Event BeforeVistaChange(TipoVista As ElencoViste)

    Sub New()
    End Sub

    Private mTipoVista As ElencoViste
    Public Property TipoVista() As ElencoViste
        Get
            Return mTipoVista
        End Get
        Set(value As ElencoViste)
            'solo se la vista cambia
            If value <> mTipoVista OrElse value = ElencoViste.INDICATORE_CLIENTE Then

                RaiseEvent BeforeVistaChange(mTipoVista)

                mTipoVista = value

                If mTipoVista <> ElencoViste.NESSUNA Then
                    ImpostaLayout()
                    ImpostaCampiSomma()
                End If

                RaiseEvent AfterVistaChange(mTipoVista)
            End If
        End Set
    End Property

    Private mListaCampiSomma As New List(Of Totale)
    Public ReadOnly Property ListaCampiSomma() As List(Of Totale)
        Get
            Return mListaCampiSomma
        End Get
    End Property

    Private mLayout As String
    Public ReadOnly Property Layout() As String
        Get
            Return mLayout
        End Get
    End Property

    Private Sub ImpostaLayout()
        Select Case mTipoVista
            Case ElencoViste.NORMALE
                mLayout = "Sinistri"
            Case ElencoViste.SOPRAVVENIENZE
                mLayout = "Sopravvenienze"
            Case ElencoViste.PERIZIE
                mLayout = "Perizie"
            Case ElencoViste.INDICATORE_CLIENTE
                mLayout = "IndicatoreCliente"
            Case ElencoViste.APERTI_CONTROPARTE
                mLayout = "SinistriControparte"
            Case ElencoViste.VARIAZIONE_COSTI_MESE_ANNO
                mLayout = "VariazioneCostiMeseAnno"
            Case Else
                mLayout = ""
        End Select
    End Sub

    Private Sub ImpostaCampiSomma()
        mListaCampiSomma.Clear()

        'campi somma
        Select Case mTipoVista
            Case ElencoViste.NORMALE
                With mListaCampiSomma
                    .Add(New Totale("PrimoPreventivo"))
                    .Add(New Totale("PagatoDel"))
                    .Add(New Totale("PagatoAl"))
                    .Add(New Totale("RecuperoDel"))
                    .Add(New Totale("RecuperoAl"))
                    .Add(New Totale("PrevStat"))
                    .Add(New Totale("Riserva"))
                    .Add(New Totale("RiservaBilancio"))
                    .Add(New Totale("PagatoNoCardAl"))
                    .Add(New Totale("PagatoNoCardDel"))
                    .Add(New Totale("PagatoCardAl"))
                    .Add(New Totale("PagatoCardDel"))
                End With
            Case ElencoViste.SOPRAVVENIENZE
                With mListaCampiSomma
                    .Add(New Totale("Sopravvenienza"))
                    .Add(New Totale("Impatto"))
                    .Add(New Totale("CostoCorrente"))
                    .Add(New Totale("CostoPrecedentePlafonato"))
                    .Add(New Totale("CostoCorrentePlafonato"))
                End With
            Case ElencoViste.VARIAZIONE_COSTI_MESE_ANNO
                With mListaCampiSomma
                    .Add(New Totale("DifferenzaMese"))
                    .Add(New Totale("DifferenzaAnno"))
                    .Add(New Totale("ImpattoAnno"))
                End With
            Case ElencoViste.INDICATORE_CLIENTE
                With mListaCampiSomma
                    .Add(New Totale("PremiStoriciAuto"))
                    .Add(New Totale("PremiStoriciRE"))
                    .Add(New Totale("PremiStoriciTotali"))
                    .Add(New Totale("SinistriStoriciAuto"))
                    .Add(New Totale("SinistriStoriciRE"))
                    .Add(New Totale("SinistriStoriciTotali"))
                    .Add(New Totale("NumeroSinistriAuto"))
                    .Add(New Totale("NumeroSinistriRE"))
                    .Add(New Totale("NumeroSinistriTotale"))
                End With
        End Select
    End Sub

    Public Class Totale

        Sub New(Campo As String)
            _Campo = Campo
        End Sub

        Private _Campo As String
        Public ReadOnly Property Campo() As String
            Get
                Return _Campo
            End Get
        End Property

        Private _Valore As Double
        Public Property Valore() As Double
            Get
                Return _Valore
            End Get
            Set(value As Double)
                _Valore = value
            End Set
        End Property
    End Class

    Public Class Persistenza

        Private Shared _Tipo As ElencoViste
        Public Shared ReadOnly Property Tipo() As ElencoViste
            Get
                Return _Tipo
            End Get
        End Property

        Private Shared _FiltroCorrente As Utx.FormGestioneFiltro
        Public Shared ReadOnly Property FiltroCorrente() As Utx.FormGestioneFiltro
            Get
                Return _FiltroCorrente
            End Get
        End Property

        Private Shared _DataSource As DataTable
        Public Shared ReadOnly Property DataSource() As DataTable
            Get
                Return _DataSource
            End Get
        End Property

        Public Shared Sub Salva(Dati As DataTable, Tipo As ElencoViste, Filtro As Utx.FormGestioneFiltro)
            _Tipo = Tipo
            _DataSource = Dati
            _FiltroCorrente = Filtro
        End Sub

        Public Shared Sub Reset()
            _Tipo = ElencoViste.NESSUNA
            _DataSource = Nothing
        End Sub
    End Class
End Class
