''' <summary>
''' Liên quan đến thông tin hệ thống
''' </summary>
Public Class D99C0010

    Public Sub ShowSysInforForm(ByVal strCaptionFormSys As String, _
                                ByVal CreateUserValue As String, _
                                ByVal CreateDateValue As String, _
                                ByVal LastModifyUserValue As String, _
                                ByVal LastModifyDateValue As String, _
                                ByVal CreateUserCap As String, _
                                ByVal CreateDateCap As String, _
                                ByVal LastModifyUserCap As String, _
                                ByVal LastModifyDateCap As String, _
                                ByVal CloseCap As String)

        Dim Frm As New D99F0005

        Frm.Text = strCaptionFormSys
        Frm.TxtCreateUser.Text = CreateUserValue.ToString
        Frm.TxtCreateDate.Text = CreateDateValue.ToString
        Frm.TxtModifyUser.Text = LastModifyUserValue.ToString
        Frm.TxtModifyDate.Text = LastModifyDateValue.ToString

        Frm.LblCreateUser.Text = CreateUserCap
        Frm.LblCreateDate.Text = CreateDateCap
        Frm.LblModifyUser.Text = LastModifyUserCap
        Frm.LblModifyDate.Text = LastModifyDateCap
        Frm.BtnClose.Text = CloseCap
        Frm.ShowDialog()
        Frm.Dispose()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
