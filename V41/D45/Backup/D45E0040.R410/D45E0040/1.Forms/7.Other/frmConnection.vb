Public Class frmConnection

    Private Sub LoadDefalut()
        txtServerName.Text = D99D0041.D99C0007.GetOthersSetting("D45", "D45E0040", "ServerName", "", CodeOption.lmCode)
        txtDBUserName.Text = D99D0041.D99C0007.GetOthersSetting("D45", "D45E0040", "ConnectionUserID", "", CodeOption.lmCode)
        txtDBPassword.Text = D99D0041.D99C0007.GetOthersSetting("D45", "D45E0040", "Password", "", CodeOption.lmCode)
        txtCompanyID.Text = D99D0041.D99C0007.GetOthersSetting("D45", "D45E0040", "Company", "", CodeOption.lmCode)
        txtUserLogin.Text = D99D0041.D99C0007.GetOthersSetting("D45", "D45E0040", "UserLogin", "", CodeOption.lmCode)
    End Sub

    Private Sub frmConnection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        LoadDefalut()
        btnYes.TabIndex = 0
        btnYes.Focus()
    End Sub

    Private Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        gsServer = txtServerName.Text
        gsConnectionUser = txtDBUserName.Text
        gsPassword = txtDBPassword.Text
        gsCompanyID = txtCompanyID.Text
        gsUserID = txtUserLogin.Text

        D99D0041.D99C0007.SaveOthersSetting("D45", "D45E0040", "ServerName", gsServer, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting("D45", "D45E0040", "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting("D45", "D45E0040", "Password", gsPassword, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting("D45", "D45E0040", "Company", gsCompanyID, CodeOption.lmCode)
        D99D0041.D99C0007.SaveOthersSetting("D45", "D45E0040", "UserLogin", gsUserID, CodeOption.lmCode)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub
End Class