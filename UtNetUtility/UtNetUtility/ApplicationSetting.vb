Imports System.IO
Imports System.Xml.Serialization
Imports System.Text

Public Class ApplicationSetting

    Public Enum TipoSetting
        GLOBALE
        UTENTE
    End Enum

    Private mImpostazioni As New SerializableDictionary(Of String, String)

    Sub New(ByVal Tipo As TipoSetting)

        If Tipo = TipoSetting.GLOBALE Then
            mFileSetting = Path.Combine(UtNetUtility.Setting.Ambiente.CartellaSettingEmme, "Unitools.Setting.xml")
        Else
            mFileSetting = Path.Combine(UtNetUtility.Setting.Ambiente.CartellaSettingEmme,
                                        String.Format("{0}.Setting.xml", Environment.UserName))
        End If

        Me.Leggi()
    End Sub

    Private mFileSetting As String
    Public Property FileSetting() As String
        Get
            Return mFileSetting
        End Get
        Set(ByVal value As String)
            mFileSetting = value
        End Set
    End Property

    Public Function EsisteChiave(ByVal Chiave As String) As Boolean
        Return mImpostazioni.ContainsKey(Chiave)
    End Function

    Public Sub AggiungiModifica(ByVal Chiave As String, ByVal Valore As String)

        Try
            If mImpostazioni.ContainsKey(Chiave) Then
                mImpostazioni.Item(Chiave) = Valore
            Else
                mImpostazioni.Add(Chiave, Valore)
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Public Function LeggiValore(ByVal Chiave As String) As String
        Return mImpostazioni.Item(Chiave)
    End Function

    Public Sub Salva()

        Try
            'salvo dati 
            Dim xml_serializer As New XmlSerializer(GetType(SerializableDictionary(Of String, String)))

            Using fs As New FileStream(mFileSetting, FileMode.Create)
                xml_serializer.Serialize(fs, mImpostazioni)
            End Using

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Public Sub Leggi()

        Try
            If File.Exists(mFileSetting) Then

                'leggo le impostazioni
                Dim xml_serializer As New XmlSerializer(GetType(SerializableDictionary(Of String, String)))

                Using fs As New FileStream(mFileSetting, FileMode.Open)
                    mImpostazioni = DirectCast(xml_serializer.Deserialize(fs), SerializableDictionary(Of String, String))
                End Using
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub
End Class
