'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:34:07 PM
'# Created User: Lê Văn Phước
'# Modify Date: 01/08/2006 4:34:07 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D25F5554

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub D25F5554_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        LoadEdit()
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Khoa_so_-_D25F5554") 'Khâa så - D25F5554
        '================================================================ 
        lblDivisionCaption.Text = rl3("Don_vi") 'Đơn vị:
        lblDivisionID.Text = rl3("gsDivisionID") 'gsDivisionID
        lblPeriodCaption.Text = rl3("Ky_ke_toan") 'Kỳ kế toán:
        lblPeriod.Text = rl3("Period") 'Period
        lblQuestion.Text = rl3("Ban_co_muon_khoa_so_ky_nay_khong") 'Bạn có muốn khóa sổ kỳ này không?
        '================================================================ 
        btnYes.Text = rl3("_Yes") '&Yes
        btnNo.Text = rl3("_No") '&No
    End Sub



    Private Sub LoadEdit()
        lblDivisionID.Text = gsDivisionID
        lblPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
    End Sub


    Private Function SQLUpdateD09T9999() As String
        Dim sSQL As String = ""
        sSQL &= "Update D09T9999 Set "
        sSQL &= "Closing = " & SQLNumber("1") 'Bit, NOT NULL
        sSQL &= " Where "
        sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
        sSQL &= "TranYear = " & SQLNumber(giTranYear) & " And "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID)
        Return sSQL
    End Function

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim sSQL As String = SQLUpdateD09T9999()
        If ExecuteSQL(sSQL) Then
            D99C0008.MsgCloseBook(lblPeriod.Text)
            'RunAuditLog(AuditCodeCloseBook, "01", lblPeriod.Text, "", "", "", "")
            gbClosed = True
        Else
            D99C0008.MsgL3("Khóa sổ không thành công cho kỳ " & lblPeriod.Text)
            gbClosed = False
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class