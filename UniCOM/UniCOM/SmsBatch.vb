Public Class SmsBatch
    Private Const ListaPlaceholders As String = "#cognome#;#nome#;#scadenza#;#targa#;#modello#;#infopolizza#;#ramo#;#polizza#"

    Public Property gateway As Integer = 0
    Public Property username As String
    Public Property password As String
    Public Property sender As String
    Public Property async As Boolean = True
    Public Property max_sms_length As Integer = 10
    Public Property utf8_enabled As Boolean = True

    Private _text_template As String
    Public Property text_template() As String
        Get
            Return _text_template
        End Get
        Set(ByVal value As String)
            For Each t As String In ListaPlaceholders.Split(";")
                value = value.Replace(t, "{{ph_" + t.Replace("#", "") + "}}")
            Next
            _text_template = value
        End Set
    End Property

    Public Property destinations As New List(Of destination)
End Class

Public Class destination
    Public Property number As String
    Public Property placeholders As placeholders

    Sub New(Telefono As String)
        number = Telefono
    End Sub

    Sub New(Telefono As String, Token As placeholders)
        number = Telefono
        placeholders = Token
    End Sub
End Class

Public Class placeholders
    Public Property ph_cognome As String
    Public Property ph_nome As String
    Public Property ph_scadenza As String
    Public Property ph_targa As String
    Public Property ph_modello As String
    Public Property ph_infopolizza As String
    Public Property ph_ramo As String
    Public Property ph_polizza As String

    Sub New(Tokens As List(Of Token))
        For Each t As Token In Tokens
            Select Case t.Key
                Case "#cognome#" : ph_cognome = t.Valore
                Case "#nome#" : ph_nome = t.Valore
                Case "#scadenza#" : ph_scadenza = t.Valore
                Case "#targa#" : ph_targa = t.Valore
                Case "#modello#" : ph_modello = t.Valore
                Case "#infopolizza#" : ph_infopolizza = t.Valore
                Case "#ramo#" : ph_ramo = t.Valore
                Case "#polizza#" : ph_polizza = t.Valore
            End Select
        Next
    End Sub
End Class