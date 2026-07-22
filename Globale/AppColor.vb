Imports System.Drawing

Public Class AppColor
    Public Shared GrigioAzzurro As Color = Color.FromArgb(214, 219, 240)
    Public Shared RossoScuro As Color = Color.FromArgb(202, 19, 38)
    Public Shared VerdeAcido As Color = Color.FromArgb(213, 255, 3)
    Public Shared VerdeOpaco As Color = Color.FromArgb(46, 159, 93)
    Public Shared AzzurroScuro As Color = Color.FromArgb(15, 106, 170)
    Public Shared RosaChiaro As Color = Color.FromArgb(255, 220, 220)
    Public Shared Antracite As Color = Color.FromArgb(41, 49, 51)
    Public Shared Omnia1 As Color = Color.FromArgb(140, 180, 255)
    Public Shared Omnia2 As Color = Color.FromArgb(91, 146, 194)
End Class

Public Class AppBrush
    Public Shared GrigioAzzurro As Brush = New SolidBrush(AppColor.GrigioAzzurro)
    Public Shared RossoScuro As Brush = New SolidBrush(AppColor.RossoScuro)
    Public Shared VerdeAcido As Brush = New SolidBrush(AppColor.VerdeAcido)
    Public Shared VerdeOpaco As Brush = New SolidBrush(AppColor.VerdeOpaco)
    Public Shared AzzurroScuro As Brush = New SolidBrush(AppColor.AzzurroScuro)
    Public Shared RosaChiaro As Brush = New SolidBrush(AppColor.RosaChiaro)
    Public Shared Antracite As Brush = New SolidBrush(AppColor.Antracite)
End Class
