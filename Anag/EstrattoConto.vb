Imports System.Text

Public Class EstrattoConto
    Inherits Utx.PaginaHtml

    Private mCodiceFiscale As String
    Private mLiquidatoTotale As Double
    Private mPremiTotale As Double


    Public Enum sezioniEnum
        SezioneDatiAnagrafici = &H1
        SezionePolizzeAuto = &H2
        SezionePolizzeRe = &H4
        SezionePolizzeVita = &H8
        SezioneIncassi = &H10
        SezioneArretrati = &H20
        SezioneSinistri = &H40
        SezioneRapportoSP = &H80
        SezioneAvvisi = &H100
        SezioneTutte = &HFFFF
    End Enum

    Public Sub New(CodiceFiscale As String)
        MyBase.New("EstrattoConto.html")
        mCodiceFiscale = CodiceFiscale
    End Sub

    Public Function StampaSintesi(Sezioni As sezioniEnum, annoIncassi As Integer, annoSinistri As Integer) As String

        StampaInizio()

        StampaSchedaCliente()

        If Sezioni And sezioniEnum.SezionePolizzeAuto Then
            StampaPolizzeAuto()
        End If
        If (Sezioni And sezioniEnum.SezionePolizzeRe) > 0 Or (Sezioni And sezioniEnum.SezionePolizzeVita) > 0 Then
            StampaAltrePolizze()
        End If
        If Sezioni And sezioniEnum.SezioneSinistri Then
            StampaSinistri(annoSinistri)
        End If
        If Sezioni And sezioniEnum.SezioneIncassi Then
            StampaIncassi(annoIncassi)
        End If

        If Sezioni And sezioniEnum.SezioneArretrati Then
            StampaArretrati()
        End If

        If Sezioni And sezioniEnum.SezioneRapportoSP Then
            StampaRapportoSinistriPremi()
        End If

        CreaFileHtml()

        Return NomeFile
    End Function

    Private Sub StampaInizio()
        AddHead("    <style>")
        AddHead("        body {font-family: Arial; font-size: 80%}")
        AddHead("        table {font-size:100%; border-collapse:separate; border-width:0; width: 100%;}")
        AddHead("        td {vertical-align:top; text-align:center}")
        AddHead("        th {background-color: rgb(243, 243, 243); text-align:center}")
        AddHead("        div { margin: 2px}")
        AddHead("    </style>")
    End Sub

    Private Sub StampaSchedaCliente()
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(255, 204, 51); text-align:center'><b>SCHEDA CLIENTE - AL {0}</b></div>", Today.ToString("dd/MM/yyyy"))

        Dim Query As String = String.Format("SELECT Cognome, Nome, Indirizzo, Cap, Localita, Provincia, TipoCliente/100 AS IdProfessione, 
            PR.Professione AS Professione, DataNascita, Sesso, Telefono1, Telefono2, Cellulare, Email, ConsensoPrivacy, 
            PremiTotale, LiquidatoTotale
            FROM Clienti AS C
            LEFT JOIN Professioni AS PR ON PR.IDProfessione  = C.TipoCliente/100
            LEFT JOIN TipoStatiCliente AS SC ON SC.IDStatoCliente = C.IDStatoCliente
            WHERE TRIM(CodiceFiscale) = '{0}'", mCodiceFiscale.Trim)

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        If dataCliente.Read Then
            If TypeOf dataCliente("LiquidatoTotale") Is Double Then
                mLiquidatoTotale = dataCliente("LiquidatoTotale")
            End If
            If TypeOf dataCliente("PremiTotale") Is Double Then
                mPremiTotale = dataCliente("PremiTotale")
            End If

            AddHtml("    <table>")
            AddHtml("        <tr>")
            AddHtml("            <td width='40%' style='border-style: solid; border-width: 1px; background-color: rgb(255, 255, 153); text-align:left'>")
            AddHtml("                <b>")
            AddHtml("                    {0} {1}<br/>", formato(dataCliente, "Cognome"), formato(dataCliente, "Nome"))
            AddHtml("                    {0}<br/>", formato(dataCliente, "Indirizzo"))
            AddHtml("                    {0} {1} {2}<br/>", formato(dataCliente, "Cap"), formato(dataCliente, "Localita"), formato(dataCliente, "Provincia"))
            AddHtml("                    <br/>{0} {1}", formato(dataCliente, "IdProfessione"), formato(dataCliente, "Professione"))
            AddHtml("                </b>")
            AddHtml("            </td>")
            AddHtml("            <td width='15%' style='text-align:right'>")
            AddHtml("                Codice Fiscale:<br/>")
            AddHtml("                Data di nascita:<br/>")
            AddHtml("                Sesso:")
            AddHtml("            </td>")
            AddHtml("            <td width='15%' style='text-align:left'><b>")
            AddHtml("                {0}<br/>", mCodiceFiscale)
            AddHtml("                {0}<br/>", formato(dataCliente, "DataNascita"))
            AddHtml("                {0}</b>", formato(dataCliente, "Sesso"))
            AddHtml("            </td>")
            AddHtml("            <td width='15%' style='text-align:right'>")
            AddHtml("                Telefono:<br/>")
            AddHtml("                Telefono:<br/>")
            AddHtml("                Cellulare:<br/>")
            AddHtml("                E-Mail:<br/>")
            AddHtml("                Consenso privacy:")
            AddHtml("            </td>")
            AddHtml("            <td width='15%' style='text-align:left'><b>")
            AddHtml("                {0}<br/>", formato(dataCliente, "Telefono1"))
            AddHtml("                {0}<br/>", formato(dataCliente, "Telefono2"))
            AddHtml("                {0}<br/>", formato(dataCliente, "Cellulare"))
            AddHtml("                {0}<br/>", formato(dataCliente, "Email"))
            AddHtml("                {0}</b>", formato(dataCliente, "ConsensoPrivacy"))
            AddHtml("            </td>")
            AddHtml("        </tr>")
            AddHtml("    </table>")
        End If
        dataCliente.Close()
    End Sub

    Private Sub StampaPolizzeAuto()
        Dim Query As String = String.Format("SELECT RIGHT('00000' + CodiceProdotto,5) AS CodiceProdotto, Ramo, Polizza, DataEffetto, DataScadenza, 
            Frazionamento, TotalePremioAnnuo, Targa, TipoTariffa, ClasseBonusMalus, AlimentazioneVeicolo, ImmatricVeicolo
            FROM Polizze
            WHERE RamoGestione IN (1, 2) AND TRIM(CodiceFiscale) = '{0}'", mCodiceFiscale.Trim)

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(102, 255, 255); text-align:center'><b>Polizze Auto</b></div>")

        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <th width='10%'>Prodotto</th>")
        AddHtml("            <th width='12%'>Polizza</th>")
        AddHtml("            <th width='12%'>Effetto</th>")
        AddHtml("            <th width='12%'>Scadenza</th>")
        AddHtml("            <th width='4%'>Fr</th>")
        AddHtml("            <th width='10%' style='text-align:right'>Tassabile</th>")
        AddHtml("            <th width='10%'>Targa</th>")
        AddHtml("            <th width='10%'>Tar+CM</th>")
        AddHtml("            <th width='10%'>Alim</th>")
        AddHtml("            <th width='10%'>Immatr.</th>")
        AddHtml("        </tr>")
        While dataCliente.Read
            AddHtml("        <tr>")
            AddHtml("          <td>{0}</td>", formato(dataCliente, "CodiceProdotto"))
            AddHtml("          <td>{0}/{1}</td>", formato(dataCliente, "Ramo"), formato(dataCliente, "Polizza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataEffetto"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataScadenza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Frazionamento"))
            AddHtml("          <td style='text-align:right; color: rgb(255, 0, 0)'>{0}</td>", formato(dataCliente, "TotalePremioAnnuo"))
            AddHtml("          <td style='color: rgb(51, 51, 255)'>{0}</td>", formato(dataCliente, "Targa"))
            AddHtml("          <td>{0} {1}</td>", formato(dataCliente, "TipoTariffa"), formato(dataCliente, "ClasseBonusMalus"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "AlimentazioneVeicolo"))
            Dim immatricolazione As String = formato(dataCliente, "ImmatricVeicolo")
            If String.IsNullOrEmpty(immatricolazione) Then
                AddHtml("          <td></td>")
            Else
                AddHtml("          <td>{0} {1}</td>", immatricolazione.Substring(0, 4), immatricolazione.Substring(4))
            End If
            AddHtml("        </tr>")
        End While
        AddHtml("    </table>")

        dataCliente.Close()
    End Sub

    Private Sub StampaAltrePolizze()
        Dim Query As String = String.Format("SELECT RIGHT('00000' + A.CodiceProdotto,5) AS CodiceProdotto, A.Ramo, A.Polizza, A.DataEffetto, 
            A.DataScadenza, A.Frazionamento, A.TotalePremioAnnuo,B.Prodotto
            FROM Polizze AS A
            LEFT JOIN Prodotti AS B ON A.CodiceProdotto = B.CodiceProdotto
            WHERE NOT A.RamoGestione IN (1, 2) AND TRIM(A.CodiceFiscale) = '{0}'", mCodiceFiscale.Trim)

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(153, 255, 153); text-align:center'><b>Altre Polizze</b></div>")

        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <th width='10%'>Prodotto</th>")
        AddHtml("            <th width='15%'>Polizza</th>")
        AddHtml("            <th width='10%'>Effetto</th>")
        AddHtml("            <th width='10%'>Scadenza</th>")
        AddHtml("            <th width='5%'>Fr</th>")
        AddHtml("            <th width='10%' style='text-align:right'>Tassabile</th>")
        AddHtml("            <th width='40%' style='text-align:left'>Descrizione Polizza</th>")
        AddHtml("        </tr>")
        While dataCliente.Read
            AddHtml("        <tr>")
            AddHtml("          <td>{0}</td>", formato(dataCliente, "CodiceProdotto"))
            AddHtml("          <td>{0}/{1}</td>", formato(dataCliente, "Ramo"), formato(dataCliente, "Polizza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataEffetto"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataScadenza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Frazionamento"))
            AddHtml("          <td style='text-align:right; color: rgb(255, 0, 0)'>{0}</td>", formato(dataCliente, "TotalePremioAnnuo"))
            AddHtml("          <td style='text-align:left'>{0}</td>", formato(dataCliente, "Prodotto"))
            AddHtml("        </tr>")
        End While
        AddHtml("    </table>")

        dataCliente.Close()
    End Sub

    Private Sub StampaSinistri(annoSinistri As Integer)
        Dim Query As String = String.Format("SELECT EsercizioSinistro, Ispettorato, S.RamoSinistro, DescTipoSin, NumeroSinistro, 
            DataSinistro, DataDenuncia, PagatoAl, StatoTecnico, StatoBilancistico, StatoAmministrativo
            FROM SinistriDP AS S
            LEFT JOIN TipoSinistro ON S.RamoSinistro = TipoSinistro.RamoSinistro AND
                      S.TipoSinistro = TipoSinistro.TipoSinistro
            WHERE TRIM(CodiceFiscContrPol) = '{0}'", mCodiceFiscale.Trim)
        If annoSinistri > 0 Then
            Query &= " AND EsercizioSinistro = " & annoSinistri
        End If

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(255, 255, 153); text-align:center'><b>Sinistri</b></div>")

        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <th width='5%'>Anno</th>")
        AddHtml("            <th width='5%'>Isp. Aper.</th>")
        AddHtml("            <th width='20%'>Ramo sinistro</th>")
        AddHtml("            <th width='10%'>Numero</th>")
        AddHtml("            <th width='10%'>Data sinistro</th>")
        AddHtml("            <th width='10%'>Data denuncia</th>")
        AddHtml("            <th width='10%' style='text-align:right'>Pagato</th>")
        AddHtml("            <th width='10%'>Stato Tecnico</th>")
        AddHtml("            <th width='10%'>Stato Bilan.co</th>")
        AddHtml("            <th width='10%'>Stato Ammin.vo</th>")
        AddHtml("        </tr>")
        While dataCliente.Read
            AddHtml("        <tr>")
            AddHtml("          <td>{0}</td>", formato(dataCliente, "EsercizioSinistro"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Ispettorato"))
            AddHtml("          <td>{0}.{1}</td>", formato(dataCliente, "RamoSinistro"), formato(dataCliente, "desctiposin"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "NumeroSinistro"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataSinistro"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataDenuncia"))
            AddHtml("          <td style='text-align:right;'>{0}</td>", formato(dataCliente, "PagatoAl"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "StatoTecnico"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "StatoBilancistico"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "StatoAmministrativo"))
            AddHtml("        </tr>")
        End While
        AddHtml("    </table>")

        dataCliente.Close()
    End Sub

    Private Sub StampaIncassi(annoIncassi As Integer)
        Dim Query As String = String.Format("SELECT DataFoglioCassa, Esito, Ramo, Polizza, DataEffettoTitolo, Frazionamento, 
            CodiceProdotto, ImportoIncassato + CanoneBox AS Pagato, Targa
            FROM Incassi
            WHERE TRIM(CodiceFiscInc) = '{0}'", mCodiceFiscale.Trim)
        If annoIncassi > 0 Then
            Query &= " AND YEAR(DataFoglioCassa) = " & annoIncassi
        End If

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(255, 204, 51); text-align:center'><b>Incassi</b></div>")

        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <th width='10%'>Esito</th>")
        AddHtml("            <th width='10%'>Incasso del</th>")
        AddHtml("            <th width='10%'>Effetto</th>")
        AddHtml("            <th width='10%'>Ramo</th>")
        AddHtml("            <th width='10%'>Polizza</th>")
        AddHtml("            <th width='10%'>Fr</th>")
        AddHtml("            <th width='10%'>Prodotto</th>")
        AddHtml("            <th width='10%' style='text-align:right'>Totale lordo</th>")
        AddHtml("            <th width='10%'>Targa</th>")
        AddHtml("        </tr>")
        While dataCliente.Read
            AddHtml("        <tr>")
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Esito"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataFoglioCassa"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "DataEffettoTitolo"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Ramo"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Polizza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Frazionamento"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "CodiceProdotto"))
            AddHtml("          <td style='text-align:right;'>{0}</td>", formato(dataCliente, "Pagato"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Targa"))
            AddHtml("        </tr>")
        End While
        AddHtml("    </table>")

        dataCliente.Close()
    End Sub

    Private Sub StampaArretrati()
        Dim Query As String = String.Format("SELECT Ramo, Polizza, EffettoTitolo, TipoCarico, Prodotto, Tassabile, Targa
            FROM Arretrati
            WHERE TRIM(CodiceFiscale) = '{0}'", mCodiceFiscale.Trim)

        Dim dataCliente As IDataReader = Utx.FunzioniDb.CreaDataTableReader(Query)

        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(204, 204, 255); text-align:center'><b>Arretrati</b></div>")

        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <th width='10%'>Ramo</th>")
        AddHtml("            <th width='10%'>Polizza</th>")
        AddHtml("            <th width='10%'>Effetto</th>")
        AddHtml("            <th width='10%'>Tipo Carico</th>")
        AddHtml("            <th width='10%'>Prodotto</th>")
        AddHtml("            <th width='10%' style='text-align:right'>Tassabile</th>")
        AddHtml("            <th width='10%'>Targa</th>")
        AddHtml("        </tr>")
        While dataCliente.Read
            AddHtml("        <tr>")
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Ramo"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Polizza"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "EffettoTitolo"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "TipoCarico"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Prodotto"))
            AddHtml("          <td style='text-align:right;'>{0}</td>", formato(dataCliente, "Tassabile"))
            AddHtml("          <td>{0}</td>", formato(dataCliente, "Targa"))
            AddHtml("        </tr>")
        End While
        AddHtml("    </table>")

        dataCliente.Close()
    End Sub

    Private Sub StampaRapportoSinistriPremi()
        AddHtml("    <div style='height:10px'>&nbsp;</div>")
        AddHtml("    <div style='border-style: solid; border-width: 1px; background-color: rgb(42, 185, 198); text-align:center'><b>Totale Premi e Sinistri</b></div>")
        AddHtml("    <table>")
        AddHtml("        <tr>")
        AddHtml("            <td width='20%' style='text-align:left;'><b>Liquidato totale<br/>Premi totali</b></td>")
        AddHtml("            <td width='80%' style='text-align:left;'>{0}<br/>{1}</td>", Utx.FunzioniFormato.FormatoEuro(mLiquidatoTotale), Utx.FunzioniFormato.FormatoEuro(mPremiTotale))
        AddHtml("        </tr>")
        AddHtml("    </table>")

    End Sub

    Private Function Formato(ByRef data As IDataReader, ByRef campo As String) As String
        Try
            Dim indice As Integer = data.GetOrdinal(campo)
            Dim oggetto As Object = data.GetValue(indice)

            If TypeOf oggetto Is DBNull Then
                Return Nothing
            ElseIf TypeOf oggetto Is String Then
                Return oggetto
            ElseIf TypeOf oggetto Is Date Then
                Return CDate(oggetto).ToString("dd/MM/yyyy")
            ElseIf TypeOf oggetto Is Double Then
                Return Utx.FunzioniFormato.FormatoEuro(oggetto)
            Else
                Return CStr(oggetto)
            End If
        Catch ex As Exception

        End Try
        Return vbNullString
    End Function
End Class
