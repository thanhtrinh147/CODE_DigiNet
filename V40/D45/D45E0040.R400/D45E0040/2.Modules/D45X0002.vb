''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D45X0002

    ''' <summary>
    ''' Tạo caption cho menu Period và kiểm tra tình trạng khóa, mở sổ cho biến gbClosed
    ''' </summary>
    '<DebuggerStepThrough()> _
    Public Function MakeMenuPeriod() As String
        Dim sRet As String
        sRet = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID

        Dim sSQL As String = ""
        sSQL = "Select Closing From D09T9999  WITH(NOLOCK) Where TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & " And DivisionID = " & SQLString(gsDivisionID)
        Dim sClosing As String = ReturnScalar(sSQL)
        gbClosed = Convert.ToBoolean(IIf(sClosing = "0", False, True))
        Return sRet
    End Function

    Public Sub IsUseBlock()
        Dim sSQL As String = ""
        sSQL = "Select IsUseBlock From D09T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            bIsUseBlock = Convert.ToBoolean(dt.Rows(0).Item("IsUseBlock"))
        Else
            bIsUseBlock = False
        End If
    End Sub

    Public Function CbVal(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.Text = "" Then Return ""

        Return tdbc.SelectedValue.ToString
    End Function

    'Public Sub RunEXEDxxExx40(ByVal sExeName As String, ByVal sFormActive As String, Optional ByVal sFormPermission As String = "", Optional ByVal sKey01ID As String = "")
    '    If sKey01ID = "" AndAlso sExeName = "D45E0140" Then sKey01ID = "D45"
    '    '***************************
    '    Dim exe As New DxxExx40(sExeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
    '    With exe
    '        .FormActive = sFormActive 'Form cần hiển thị
    '        .FormPermission = IIf(sFormPermission = "", sFormActive, sFormPermission).ToString 'Mã màn hình phân quyền
    '        .IDxx("ID01") = sKey01ID
    '        .Run()
    '    End With
    'End Sub



End Module
