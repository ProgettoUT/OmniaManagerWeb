Imports System.Data.OleDb
Imports System.Windows.Forms

Friend Class FormProfilazione
    Private lastPosition As Integer

    Dim WithEvents a As System.Windows.Forms.Binding
    Dim WithEvents b As System.Windows.Forms.Binding
    Dim WithEvents c As System.Windows.Forms.Binding

    Private Sub UtenteBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.UtenteBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.UProfiloDataSet)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(My.Settings.UProfiloConnectionString)

        Me.ColoniaTableAdapter.Fill(Me.UProfiloDataSet.Colonia)
        Me.UtenteTableAdapter.Fill(Me.UProfiloDataSet.Utente)

        a = New System.Windows.Forms.Binding("Checked", Me.UtenteBindingSource, "Autorizzazioni", True)
        b = New System.Windows.Forms.Binding("Checked", Me.UtenteBindingSource, "Autorizzazioni", True)
        c = New System.Windows.Forms.Binding("Checked", Me.UtenteBindingSource, "Autorizzazioni", True)
        chkAmministratore.DataBindings.Add(a)
        chkGestionale.DataBindings.Add(b)
        chkOperativo.DataBindings.Add(c)

        chkAmministratore.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        chkGestionale.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        chkOperativo.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        UtenteTextBox.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        ColoniaDataGridView.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        BindingNavigatorAddNewItem.Visible = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        BindingNavigatorDeleteItem.Visible = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
        UtenteBindingNavigatorSaveItem.Visible = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)

        Me.Text = Ut.Globale.UtenteCorrente.UniageUser
    End Sub

    Private Sub UtenteBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles UtenteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.UtenteBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.UProfiloDataSet)
    End Sub

    Private Sub cmdChiudi_Click(sender As Object, e As EventArgs) Handles cmdChiudi.Click
        Me.Close()
    End Sub

    Private Sub a_Format(sender As Object, e As ConvertEventArgs) Handles a.Format, b.Format, c.Format
        If Not TypeOf (e.Value) Is DBNull Then
            Dim c = DirectCast(sender.control, CheckBox)
            Dim i = CInt(c.Tag)
            e.Value = ((e.Value And i) = i)
        End If
    End Sub

    Private Sub a_Parse(sender As Object, e As ConvertEventArgs) Handles a.Parse, b.Parse, c.Parse
        Dim autorizzazioni As Integer = 0
        autorizzazioni += IIf(chkAmministratore.Checked, 1, 0)
        autorizzazioni += IIf(chkOperativo.Checked, 2, 0)
        autorizzazioni += IIf(chkGestionale.Checked, 4, 0)
        e.Value = autorizzazioni
    End Sub

    Private Sub BindingNavigatorDeleteItem_EnabledChanged(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.EnabledChanged
        BindingNavigatorDeleteItem.Enabled = Profilo.IsAuthorizzed(Profilo.CategoriaFunzione.Amministrativa)
    End Sub

End Class
