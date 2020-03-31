'#-------------------------------------------------------------------------------------
'# Created Date: 06/12/2007 10:50:59 AM
'# Created User: Đoàn Như Thanh
'# Modify Date: 06/12/2007 10:050:59 AM
'# Modify User: Đoàn Như Thanh
'#-------------------------------------------------------------------------------------

Public Class D25F4020
	Dim report As D99C2003



    Private dtTeam As DataTable
    Private dtInterview As DataTable

    Private Sub D25F4020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If

        If e.Control Then
            If e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Then
                Application.DoEvents()
                tdbcVoucherNo.Focus()
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub D25F4020_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBComBo()
        SetDefaultValues()
InputDateCustomFormat(c1dateExamineDate)
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ket_qua_phong_van_-_D25F4020") 'KÕt qu¶ phàng vÊn - D25F4020
        '================================================================ 
        lblVoucherNo.Text = rl3("Dot_tuyen") 'Hồ sơ PV
        lblInterView.Text = rl3("Lich_PV") 'Lịch PV
        lblInterviewTurn.Text = rl3("Vong_PV") 'Vòng PV
        lblRecDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblRecteamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionIDFrom.Text = rl3("Vi_tri") 'Vị trí
        lblteExamineDate.Text = rl3("Ngay_lap")

        lblIntStatusID.Text = rl3("Ket_qua") 'Kết quả
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grpInfomation.Text = rl3("Thong_so_thiet_lap") 'Thông số thiết lập
        '================================================================ 
        tdbcRecteamIDFrom.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecteamIDFrom.Columns("TeamName").Caption = rl3("Ten") 'Tên 
        tdbcRecDepartmentIDTo.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDTo.Columns("DepartmentName").Caption = rl3("Ten") 'Tên 
        tdbcRecDepartmentIDFrom.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDFrom.Columns("DepartmentName").Caption = rl3("Ten") 'Tên 
        tdbcVoucherNo.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcVoucherNo.Columns("RecruitmentFileName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamIDTo.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamIDTo.Columns("TeamName").Caption = rl3("Ten") 'Tên 
        tdbcRecPositionIDTo.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDTo.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionIDFrom.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDFrom.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcIntStatusID.Columns("IntStatusID").Caption = rl3("Ma") 'Mã
        tdbcIntStatusID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải 
        tdbcInterView.Columns("VoucherNo").Caption = rl3("Ma")
        tdbcInterView.Columns("InterviewFileName").Caption = rl3("Ten")
        tdbcVoucherNo.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcVoucherNo.Columns("RecruitmentFileName").Caption = rl3("Ten") 'Tên

        lblPeriodFrom.Text = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ

        lblCustomReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn

        tdbcCustomReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcVoucherNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecDepartmentIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecDepartmentIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecteamIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecTeamIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcIntStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcInterView.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003

		'************************************ 'D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D25R2020"
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        If tdbcCustomReportID.Text = "" Then
            sReportName = txtReportID.Text
            sPathReport = gsApplicationSetup & "\XReports\" & sReportName & ".rpt" 'Application.StartupPath & "\XReports\" & sReportName & ".rpt"
        Else
            sReportName = tdbcCustomReportID.Text
            sPathReport = gsApplicationSetup & "\XCustom\" & sReportName & ".rpt" 'Application.StartupPath & "\XCustom\" & sReportName & ".rpt"
        End If

        sReportCaption = rL3("Ket_qua_phong_van_W") & " - " & sReportName
        sSQL = SQLStoreD25P2020()
        sSQLSub = " SELECT * FROM D09V0009 "
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcPeriodFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodFrom.Focus()
            Return False
        End If
        If tdbcPeriodTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodTo.Focus()
            Return False
        End If


        If tdbcVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Dot_tuyen"))
            tdbcVoucherNo.Focus()
            Return False
        End If

        If tdbcInterView.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Lich_PV"))
            tdbcInterView.Focus()
            Return False
        End If

        If tdbcRecDepartmentIDFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcRecDepartmentIDFrom.Focus()
            Return False
        End If
        If tdbcRecDepartmentIDTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcRecDepartmentIDTo.Focus()
            Return False
        End If
        If tdbcRecteamIDFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcRecteamIDFrom.Focus()
            Return False
        End If
        If tdbcRecTeamIDTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcRecTeamIDTo.Focus()
            Return False
        End If
        If tdbcRecPositionIDFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vi_tri"))
            tdbcRecPositionIDFrom.Focus()
            Return False
        End If
        If tdbcRecPositionIDTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vi_tri"))
            tdbcRecPositionIDTo.Focus()
            Return False
        End If
        If tdbcIntStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ket_qua"))
            tdbcIntStatusID.Focus()
            Return False
        End If

        Return True
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2020
    '# Created User: Đoàn Như Thanh
    '# Created Date: 06/12/2007 11:12:25
    '# Modified User: Đoàn Như Thanh
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLStoreD25P2020() As String
        Dim sSQL As String = ""
        sSQL &= " EXEC D25P2020 "
        sSQL &= SQLDateSave(c1dateExamineDate.Text) & COMMA
        'sSQL &= SQLString(txtTittle.Text) & COMMA
        sSQL &= SQLString(IIf(tdbcCustomReportID.Text <> "", txtCustomReportName.Text, txtReportName.Text)) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLString(tdbcInterView.Columns(0).Text) & COMMA
        sSQL &= SQLString(tdbcVoucherNo.Columns(3).Text) & COMMA
        sSQL &= SQLString(tdbcRecDepartmentIDFrom.SelectedValue) & COMMA
        sSQL &= SQLString(tdbcRecDepartmentIDTo.SelectedValue) & COMMA
        sSQL &= SQLString(tdbcRecteamIDFrom.SelectedValue) & COMMA
        sSQL &= SQLString(tdbcRecTeamIDTo.SelectedValue) & COMMA
        sSQL &= SQLString(tdbcRecPositionIDFrom.SelectedValue) & COMMA
        sSQL &= SQLString(tdbcRecPositionIDTo.SelectedValue) & COMMA
        sSQL &= SQLString("%") & COMMA
        sSQL &= SQLString(sFind) & COMMA
        sSQL &= SQLString(tdbcIntStatusID.Text)
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


#Region "Events tdbcVoucherNo with txtVoucherNoName"

    Private Sub tdbcVoucherNo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherNo.Close
        If tdbcVoucherNo.FindStringExact(tdbcVoucherNo.Text) = -1 Then
            tdbcVoucherNo.Text = ""
            txtVoucherNoName.Text = ""
            tdbcVoucherNo.Focus()
        End If
    End Sub

    Private Sub tdbcVoucherNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherNo.SelectedValueChanged
        txtVoucherNoName.Text = tdbcVoucherNo.Columns("RecruitmentFileName").Value.ToString
        LoadDataSource(tdbcInterView, ReturnTableFilter(dtInterview, " RecruitmentFileID=" & SQLString(tdbcVoucherNo.Columns(0).Text)))
    End Sub

    Private Sub tdbcVoucherNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherNo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcVoucherNo.Text = ""
            txtVoucherNoName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcRecDepartmentIDFrom"

    Private Sub tdbcRecDepartmentIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.LostFocus
        If tdbcRecDepartmentIDFrom.FindStringExact(tdbcRecDepartmentIDFrom.Text) = -1 Then
            tdbcRecDepartmentIDFrom.Text = ""
            tdbcRecDepartmentIDFrom.Focus()
        End If

    End Sub

    Private Sub tdbcRecDepartmentIDFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.SelectedValueChanged
        If tdbcRecDepartmentIDFrom.Columns(0).Text = "%" Then
            LoadDataSource(tdbcRecteamIDFrom, dtTeam.Copy)
        Else
            LoadDataSource(tdbcRecteamIDFrom, ReturnTableFilter(dtTeam, " DepartmentID='%' OR DepartmentID=" & SQLString(tdbcRecDepartmentIDFrom.SelectedValue.ToString)))
        End If
        tdbcRecteamIDFrom.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcRecDepartmentIDTo"

    Private Sub tdbcRecDepartmentIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.LostFocus
        If tdbcRecDepartmentIDTo.FindStringExact(tdbcRecDepartmentIDTo.Text) = -1 Then
            tdbcRecDepartmentIDTo.Text = ""
            tdbcRecDepartmentIDTo.Focus()
        End If

    End Sub

    Private Sub tdbcRecDepartmentIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.SelectedValueChanged
        If tdbcRecDepartmentIDTo.Columns(0).Text = "%" Then
            LoadDataSource(tdbcRecTeamIDTo, dtTeam.Copy)
        Else
            LoadDataSource(tdbcRecTeamIDTo, ReturnTableFilter(dtTeam, " DepartmentID='%' OR DepartmentID=" & SQLString(tdbcRecDepartmentIDTo.SelectedValue)))
        End If
        tdbcRecTeamIDTo.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcRecteamIDFrom"

    Private Sub tdbcRecteamIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecteamIDFrom.LostFocus
        If tdbcRecteamIDFrom.FindStringExact(tdbcRecteamIDFrom.Text) = -1 Then
            tdbcRecteamIDFrom.Text = ""
            tdbcRecteamIDFrom.Focus()
        End If

    End Sub
#End Region

#Region "Events tdbcRecTeamIDTo"

    Private Sub tdbcRecTeamIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDTo.LostFocus
        If tdbcRecTeamIDTo.FindStringExact(tdbcRecTeamIDTo.Text) = -1 Then
            tdbcRecTeamIDTo.Text = ""
            tdbcRecTeamIDTo.Focus()
        End If

    End Sub

#End Region

#Region "Events tdbcRecPositionIDFrom"

    Private Sub tdbcRecPositionIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.LostFocus
        If tdbcRecPositionIDFrom.FindStringExact(tdbcRecPositionIDFrom.Text) = -1 Then
            tdbcRecPositionIDFrom.Text = ""
            tdbcRecPositionIDFrom.Focus()
        End If

    End Sub

#End Region

#Region "Events tdbcRecPositionIDTo"

    Private Sub tdbcRecPositionIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDTo.LostFocus
        If tdbcRecPositionIDTo.FindStringExact(tdbcRecPositionIDTo.Text) = -1 Then
            tdbcRecPositionIDTo.Text = ""
            tdbcRecPositionIDTo.Focus()
        End If

    End Sub

#End Region

#Region "Events tdbcIntStatusID with txtIntStatusName"

    Private Sub tdbcIntStatusID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIntStatusID.Close
        If tdbcIntStatusID.FindStringExact(tdbcIntStatusID.Text) = -1 Then
            tdbcIntStatusID.Text = ""
            txtIntStatusName.Text = ""
            tdbcIntStatusID.Focus()
        End If
    End Sub

    Private Sub tdbcIntStatusID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIntStatusID.SelectedValueChanged
        txtIntStatusName.Text = tdbcIntStatusID.Columns(1).Value.ToString
    End Sub
#End Region

#Region "Events tdbcInterView"

    Private Sub tdbcInterView_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterView.Close
        If tdbcInterView.FindStringExact(tdbcInterView.Text) = -1 Then
            tdbcInterView.Text = ""
            tdbcInterView.Focus()
        End If

    End Sub

    Private Sub tdbcInterView_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterView.SelectedValueChanged
        If tdbcInterView.Columns("InterviewLevel").Text <> "FL" Then
            txtInterviewTurn.Text = tdbcInterView.Columns("InterviewLevel").Text
        Else
            txtInterviewTurn.Text = IIf(gsLanguage = "84", "Voøng cuoái", "Final Level").ToString
        End If
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.Close, tdbcRecPositionIDTo.Close, tdbcRecDepartmentIDFrom.Close, tdbcRecDepartmentIDTo.Close, tdbcRecteamIDFrom.Close, tdbcRecTeamIDTo.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.Validated, tdbcRecPositionIDTo.Validated, tdbcRecDepartmentIDFrom.Validated, tdbcRecDepartmentIDTo.Validated, tdbcRecteamIDFrom.Validated, tdbcRecTeamIDTo.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
            'ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
            btnPrint_Click(Nothing, Nothing)
		End Set
	End Property


    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        sSQL &= " ORDER BY No"
        ShowFindDialogClient(Finder, sSQL)
    End Sub


    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    btnPrint_Click(Nothing, Nothing)
    '    sFind = ""
    'End Sub

#End Region

    Private Sub SetDefaultValues()
        c1dateExamineDate.Value = Now
        tdbcVoucherNo.AutoSelect = True
        tdbcIntStatusID.AutoSelect = True
        tdbcInterView.AutoSelect = True
        tdbcRecDepartmentIDFrom.SelectedValue = "%"
        tdbcRecDepartmentIDTo.SelectedValue = "%"
        tdbcRecteamIDFrom.SelectedValue = "%"
        tdbcRecTeamIDTo.SelectedValue = "%"
        tdbcRecPositionIDFrom.SelectedValue = "%"
        tdbcRecPositionIDTo.SelectedValue = "%"
        txtReportName.Text = rl3("KET_QUA_PHONG_VAN_V")

        tdbcPeriodFrom.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
    End Sub




    Private Sub LoadTdbcRecruitmentFileID()
        'ComBo Đợt tuyển dụng
        Dim sSQL As New StringBuilder(344)
        sSQL.Append(" SELECT RecruitmentFileID,")
        sSQL.Append(" VoucherNo, ")
        sSQL.Append(" RecruitmentFileName,")
        sSQL.Append(" RecruitPlanID" & vbCrLf)
        sSQL.Append(" FROM	D25T1040 WITH(NOLOCK) " & vbCrLf)
        sSQL.Append(" WHERE	Disabled = 0")
        sSQL.Append(" AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("And (TranMonth + TranYear * 100) Between ( " & SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & " + " & SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & " * 100)" & vbCrLf)
        sSQL.Append("And (" & SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & " + " & SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & " * 100)" & vbCrLf)
        sSQL.Append(" ORDER BY	RecruitmentFileID DESC ")

        LoadDataSource(tdbcVoucherNo, sSQL.ToString)
    End Sub

    Private Sub LoadTDBComBo()
        Dim dt As DataTable
        Dim sSQL As New StringBuilder(2000)
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")

        'ComBo lịch phỏng vấn
        sSQL.Append(" SELECT InterviewFileID,")
        sSQL.Append(" VoucherNo,")
        sSQL.Append(" InterviewFileName,")
        sSQL.Append(" InterviewLevel,")
        sSQL.Append(" RecruitmentFileID ")
        sSQL.Append(" FROM	D25T2010 WITH(NOLOCK)  ")
        sSQL.Append(" WHERE	Disabled = 0 ")
        sSQL.Append(" AND DivisionID = " & SQLString(gsDivisionID))
        sSQL.Append(" ORDER BY	InterviewFileID DESC ")

        dtInterview = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbcInterView, dtInterview.Copy)

        'ComBo phòng ban
        sSQL.Remove(0, sSQL.Length)

        sSQL.Append(" SELECT 1 as DisplayOrder,DepartmentID,")
        sSQL.Append(" DepartmentName")
        sSQL.Append(" FROM	D91T0012 WITH(NOLOCK) ")
        sSQL.Append(" WHERE	Disabled = 0")
        sSQL.Append(" AND DivisionID = " & SQLString(gsDivisionID))
        sSQL.Append(" UNION	")
        sSQL.Append(" SELECT 0 as DisplayOrder,'%' AS DepartmentID,")
        sSQL.Append(" '" & rl3("Tat_ca") & "' AS DepartmentName")
        sSQL.Append(" ORDER BY	DisplayOrder, DepartmentID")

        dt = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbcRecDepartmentIDFrom, dt.Copy)
        LoadDataSource(tdbcRecDepartmentIDTo, dt.Copy)

        'ComBo tổ nhóm
        sSQL.Remove(0, sSQL.Length)
        dt.Clear()

        sSQL.Append(" SELECT 1 as DisplayOrder,T1.TeamID, ")
        sSQL.Append(" T1.TeamName,")
        sSQL.Append(" T1.DepartmentID ")
        sSQL.Append(" FROM	D09T0227 T1 WITH(NOLOCK) ")
        sSQL.Append(" INNER JOIN D91T0012 T2 WITH(NOLOCK)  ")
        sSQL.Append(" ON T2.DepartmentID=T1.DepartmentID ")
        sSQL.Append(" WHERE	T1.Disabled = 0 ")
        sSQL.Append(" AND T2.DivisionID= " & SQLString(gsDivisionID))
        sSQL.Append(" UNION ")
        sSQL.Append(" SELECT 0 as DisplayOrder,'%' AS TeamID, ")
        sSQL.Append(" '" & rl3("Tat_ca") & "'	AS TeamName, ")
        sSQL.Append(" '%' AS DepartmentID ")
        sSQL.Append(" ORDER BY	DisplayOrder, T1.DepartmentID,T1.TeamID ")

        dtTeam = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbcRecteamIDFrom, dtTeam.Copy)
        LoadDataSource(tdbcRecTeamIDTo, dtTeam.Copy)

        'ComBo vị trí
        sSQL.Remove(0, sSQL.Length)
        dt.Clear()

        sSQL.Append(" SELECT 1 as DisplayOrder,RecPositionID, ")
        sSQL.Append(" RecPositionName")
        sSQL.Append(" FROM	D25T1020 WITH(NOLOCK) ")
        sSQL.Append(" WHERE	Disabled = 0")
        sSQL.Append(" UNION	")
        sSQL.Append(" SELECT 0 as DisplayOrder,'%' AS RecPositionID,")
        sSQL.Append(" '" & rl3("Tat_ca") & "' AS RecPositionName")
        sSQL.Append(" ORDER BY	DisplayOrder, RecPositionID")

        dt = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbcRecPositionIDFrom, dt.Copy)
        LoadDataSource(tdbcRecPositionIDTo, dt.Copy)

        'ComBo kết quả
        sSQL.Remove(0, sSQL.Length)
        dt.Clear()
        Dim dr As DataRow
        dt.Columns.Add("IntStatusID", System.Type.GetType("System.String"))
        dt.Columns.Add("Description", System.Type.GetType("System.String"))

        'Tất cả
        dr = dt.NewRow
        dr.Item("IntStatusID") = "%"
        dr.Item("Description") = rl3("Tat_ca")
        dt.Rows.Add(dr)
        'Đạt
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00001"
        dr.Item("Description") = rl3("Dat_V")
        dt.Rows.Add(dr)

        'Không đạt
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00002"
        dr.Item("Description") = rl3("Khong_dat_V")
        dt.Rows.Add(dr)
        'Không tham gia phỏng vấn
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00003"
        dr.Item("Description") = rl3("Khong_tham_gia_phong_van_V")
        dt.Rows.Add(dr)

        LoadDataSource(tdbcIntStatusID, dt.Copy)
        dt.Dispose()

        sSQL.Remove(0, sSQL.Length)
        ''Load tdbcCustomReportID
        'sSQL.Append("Select ReportID, Title  From D89T1000 " & vbCrLf)
        'sSQL.Append("Where ModuleID='25' and ReportTypeID= " & SQLString(Me.Name))
        'sSQL.Append("ORDER BY ReportID")
        'LoadDataSource(tdbcCustomReportID, sSQL.ToString)
        MyLoadTdbcCustomizeReport(tdbcCustomReportID, Me.Name)
    End Sub



#Region "Events tdbcCustomReportID with txtCustomReportName"

    Private Sub tdbcCustomReportID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.Close
        If tdbcCustomReportID.FindStringExact(tdbcCustomReportID.Text) = -1 Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

    Private Sub tdbcCustomReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.SelectedValueChanged
        txtCustomReportName.Text = tdbcCustomReportID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcCustomReportID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCustomReportID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.Close
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriodFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriodFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.SelectedValueChanged
        LoadTdbcRecruitmentFileID()
    End Sub
#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.Close
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

    Private Sub tdbcPeriodTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriodTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriodTo.Text = ""
    End Sub


    Private Sub tdbcPeriodTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.SelectedValueChanged
        LoadTdbcRecruitmentFileID()
    End Sub
#End Region

End Class