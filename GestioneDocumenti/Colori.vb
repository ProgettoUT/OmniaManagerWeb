Imports System.Drawing

Public Class Colori

    Public Structure Pratiche
        Public Shared Bc As Color = Color.Ivory
        Public Shared Fc As Color = Color.Black
        Public Shared BcStorico As Color = Color.Bisque
        Public Shared BcBtnStoricoSi As Color = Color.DimGray
        Public Shared BcBtnStoricoNo As Color = SystemColors.Control
        Public Shared FcBtnStoricoSi As Color = Color.White
        Public Shared FcBtnStoricoNo As Color = SystemColors.WindowText
        Public Shared BcbtnPratica As Color = Color.NavajoWhite
        Public Shared BcSelezionata As Color = Color.GreenYellow
        Public Shared BcCorrente As Color = Color.Gold
        Public Shared FcCorrente As Color = Color.Black
    End Structure

    Public Structure Esci
        Public Shared BcPanelAttivo As Color = Color.DarkOrange
        Public Shared BcPanelDisattivo As Color = SystemColors.Control
    End Structure

    Public Structure Sertel
        Public Shared BcInvioSi As Color = Color.PaleGreen
        Public Shared BcInvioNo As Color = Color.LightSalmon
    End Structure

    Public Structure Trascina
        Public Shared BcLascia As Color = Color.Yellow
        Public Shared BcFatto As Color = Color.White
    End Structure

    Public Shared BcLabelStato As Color = Color.DodgerBlue
    Public Shared FcLabelStato As Color = Color.White
    Public Shared BcLabelDimensioneFile As Color = Color.LightYellow
    Public Shared BcFormRinomina As Color = Color.Orange
    Public Shared BcOpzioniScanner As Color = Color.Gainsboro
End Class
