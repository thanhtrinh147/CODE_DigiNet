Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 13/08/2008 16:11:12 PM
'# Created User: Trần Thị Ái Trâm
'# Description: Làm số phiếu theo cách mới
'# Modify Date: 13/08/2008 16:11:12 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D99F1112

    Private _voucherNo As String
    Public Property VoucherNo() As String
        Get
            Return _voucherNo
        End Get
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private Sub D99F1112_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D99F1112_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLanguage()
        txtVoucherNo.Text = _voucherNo

        SetResolutionForm(Me)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtVoucherNo.Text <> _voucherNo Then
            _voucherNo = txtVoucherNo.Text
            gnManualVoucherNo = 1
        End If
        Me.Close()
    End Sub

    Private Sub LoadLanguage()
        If geLanguage = EnumLanguage.English Then
            Me.Text = "Update VoucherNo"
            btnOK.Text = "&OK"
            btnClose.Text = "&Close"
            lblVoucherNo.Text = "Voucher no"
        End If
    End Sub
     
End Class