Imports System.Windows.Forms

Public Class ucClienti

    Public Event RowChanged(ByRef Cliente As DataGridViewRow)
    Public Event ClienteDouubleClick()
    Public Event Errore(ex As Exception, Procedura As String)

    Private Const MODULO As String = "ucClienti"
    Private mXmlSetting As String = "ElencoClienti"

    Friend FormFiltro As Utx.FormGestioneFiltro

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = Windows.Forms.DockStyle.Fill

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With dgvClienti
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With
        Utx.NetFunc.DoppioBuffer(dgvClienti)
    End Sub

    Private Sub dgvClienti_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClienti.CellDoubleClick
        RaiseEvent ClienteDouubleClick()
    End Sub

    Private Sub dgvClienti_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvClienti.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = mXmlSetting
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvClienti.Columns(e.ColumnIndex))

            RaiseEvent RowChanged(dgvClienti.CurrentRow)

        Catch ex As Exception
            RaiseError(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try

    End Sub

    Private Sub dgvClienti_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvClienti.CurrentCellChanged
        RaiseEvent RowChanged(dgvClienti.CurrentRow)
    End Sub

    Private Sub dgvClienti_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvClienti.DataError
        RaiseEvent Errore(e.Exception, "DataGridError")
    End Sub

    Private Sub dgvSinistri_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvClienti.DataSourceChanged
        dgvClienti.Refresh()
        RaiseEvent RowChanged(dgvClienti.CurrentRow)
    End Sub

    Private Sub RaiseError(ex As Exception, Procedura As String)
        RaiseEvent Errore(ex, String.Format("{0}.{1}", MODULO, Procedura))
    End Sub

    Public Sub ImpostaLayout()
        Try
            'cartella per salvataggio filtro
            With FormFiltro
                '.AppName = VistaCorrente.Layout
                .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                .TabVisibili(False, True)
                'visualizzo la finestra del layout. la colonna serve per passare indirettamente il datasource
                .Visualizza(dgvClienti.Columns(0))
            End With

        Catch ex As Exception
            RaiseError(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
    End Sub
End Class
