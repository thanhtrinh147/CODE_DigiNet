Imports System
Public Class D25F2012

#Region "Const of tdbg"
    Private Const COL_RecDepartmentID As Integer = 0   ' Phòng ban
    Private Const COL_RecDepartmentName As Integer = 1 ' Phòng ban
    Private Const COL_RecTeamID As Integer = 2         ' Tổ nhóm
    Private Const COL_RecTeamName As Integer = 3       ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 4     ' Vị trí
    Private Const COL_RecPositionName As Integer = 5   ' Vị trí
    Private Const COL_CandidateID As Integer = 6       ' Mã
    Private Const COL_CandidateName As Integer = 7     ' Họ và tên
    Private Const COL_Sex As Integer = 8               ' Giới tính
    Private Const COL_BirthDate As Integer = 9         ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 10     ' Ngày nhận
    Private Const COL_FileReceiverName As Integer = 11 ' Nguười nhận HS
    Private Const COL_ReceivedPlace As Integer = 12    ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 13    ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 14       ' Loại tiền
    Private Const COL_RecSourceName As Integer = 15    ' Nguồn tuyển dụng
    Private Const COL_Suggester As Integer = 16        ' Nguười giới thiệu
    Private Const COL_IntDate As Integer = 17          ' Thời gian phỏng vấn
    Private Const COL_InterviewerName As Integer = 18  ' Người phỏng vấn
    Private Const COL_Content As Integer = 19          ' Nội dung phỏng vấn
    Private Const COL_Result As Integer = 20           ' Kết quả phỏng vấn
    Private Const COL_CreateUserID As Integer = 21     ' CreateUserID
    Private Const COL_CreateDate As Integer = 22       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 23 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 24   ' LastModifyDate
    Private Const COL_TransferedD09 As Integer = 25    ' TransferedD09
#End Region

    Dim sNewCandidateID As String = "" 'Dùng đặt Bookmark tại dòng vừa thêm mới

    Dim dt_Loadtdbg As DataTable
    Public EditPermission_D25F2012 As Boolean

    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _interviewFileID As String
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property

    Private _interviewFileName As String
    Public Property InterviewFileName() As String
        Get
            Return _interviewFileName
        End Get
        Set(ByVal Value As String)
            _interviewFileName = Value
        End Set
    End Property

    Private _voucherNo As String
    Public Property VoucherNo() As String
        Get
            Return _voucherNo
        End Get
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _fileDate As String
    Public Property FileDate() As String
        Get
            Return _fileDate
        End Get
        Set(ByVal Value As String)
            _fileDate = Value
        End Set
    End Property

    Private _recruitmentVoucherNo As String
    Public Property RecruitmentVoucherNo() As String
        Get
            Return _recruitmentVoucherNo
        End Get
        Set(ByVal Value As String)
            _recruitmentVoucherNo = Value
        End Set
    End Property

    Private _recruitPlanID As String
    Public Property RecruitPlanID() As String
        Get
            Return _recruitPlanID
        End Get
        Set(ByVal Value As String)
            _recruitPlanID = Value
        End Set
    End Property

    Private _recruitPlanVoucherNo As String
    Public Property RecruitPlanVoucherNo() As String
        Get
            Return _recruitPlanVoucherNo
        End Get
        Set(ByVal Value As String)
            _recruitPlanVoucherNo = Value
        End Set
    End Property

    Private _interviewLevel As String
    Public Property InterviewLevel() As String
        Get
            Return _interviewLevel
        End Get
        Set(ByVal Value As String)
            _interviewLevel = Value
        End Set
    End Property

    Private _levelName As String
    Public Property LevelName() As String
        Get
            Return _levelName
        End Get
        Set(ByVal Value As String)
            _levelName = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAction.Click
        Dim p As Point = btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top + 40))
        C1ContextMenu.ShowContextMenu(btnAction, p)
    End Sub

    Private Sub D25F2012_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
    End Sub

    Private Sub D25F2012_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        LoadTDBCombo()
        LoadData()
        LoadTDBGrid()
        tdbg_NumberFormat()
        SetShortcutPopupMenu(C1CommandHolder)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_ReceivedDate, COL_IntDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadData()
        txtVoucherNo.Text = VoucherNo
        txtInterviewFileName.Text = InterviewFileName
        txtFileDate.Text = FileDate
        txtRecruitmentVoucherNo.Text = RecruitmentVoucherNo
        txtLevelName.Text = LevelName
        txtRecruitPlanVoucherNo.Text = RecruitPlanVoucherNo
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_DesiredSalary).NumberFormat = D25Format.DefaultNumber2
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_lich_phong_van_-_D25F2012") 'Chi tiÕt lÜch phàng vÊn - D25F2012
        '================================================================ 
        lblVoucherNo.Text = rl3("Lich_phong_van") 'Lịch phỏng vấn
        lblRecruitmentVoucherNo.Text = rl3("Dot_tuyen_dung") 'Đợt tuyển dụng
        lblLevelName.Text = rl3("Vong_PV") 'Vòng PV
        lblRecruitPlanVoucherNo.Text = rl3("De_xuat") 'Đề xuất
        lblRecDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeam.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        '================================================================ 
        btnAction.Text = rl3("Thuc__hien") 'Thực &hiện
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnPrint.Text = rl3("_In")
        '================================================================ 
        tdbcRecDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcRecTeam.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeam.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("RecDepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        'tdbg.Columns("RecDepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("RecTeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        'tdbg.Columns("RecTeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Vi_tri") 'Vị trí
        'tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ReceivedDate").Caption = rl3("Ngay_nhan") 'Ngày nhận
        tdbg.Columns("FileReceiverName").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("Suggester").Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
        tdbg.Columns("InterviewerName").Caption = rl3("Nguoi_phong_van") 'Người phỏng vấn
        tdbg.Columns("Content").Caption = rl3("Noi_dung_phong_van") 'Nội dung phỏng vấn
        tdbg.Columns("Result").Caption = rl3("Ket_qua_phong_van") 'Kết quả phỏng vấn
        tdbg.Columns("IntDate").Caption = rl3("Ngay_phong_van") 'Ngày phỏng vấn
        tdbg.Columns("IntTime").Caption = rl3("Gio_phong_van") 'Giờ phỏng vấn
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
    End Sub



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2020
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 03/12/2007 03:13:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2020 "
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA '', " 'TranMonthFrom
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLString(InterviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString(RecruitPlanID) & COMMA 'RecruitPlanID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentID.SelectedValue) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentID.SelectedValue) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeam.SelectedValue) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeam.SelectedValue) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionID.SelectedValue) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionID.SelectedValue) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString(sFind) 'WhereClause, varchar[8000], NOT NULL
        Return sSQL
    End Function



#Region "Active Find - List All "
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
            LoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString(Me) & "And Language = " & SQLString(gsLanguage)
        ShowFindDialog(Finder, sSQL)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFind = ResultWhereClause.ToString()
        LoadTDBGrid()
    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        LoadTDBGrid()
    End Sub
#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P2020()
        dt_Loadtdbg = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt_Loadtdbg)
        If sNewCandidateID <> "" Then
            dt_Loadtdbg.DefaultView.Sort = "CandidateID"
            tdbg.Bookmark = dt_Loadtdbg.DefaultView.Find(sNewCandidateID)
            sNewCandidateID = ""
        End If
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg.Columns(COL_CandidateName).FooterText = rl3("Tong_cong_") & " " & tdbg.RowCount

        'Dim bAllowEdit As Boolean = AllowEdit_D25F3020(tdbg.Columns(col_re)

        mnuEdit.Enabled = mnuEdit.Enabled And EditPermission_D25F2012
        mnuAdd.Enabled = mnuAdd.Enabled And EditPermission_D25F2012
        mnuDelete.Enabled = mnuDelete.Enabled And EditPermission_D25F2012
        If tdbg.RowCount = 0 Then
            mnuUpdateResult.Enabled = False
            Exit Sub
        End If
        mnuUpdateResult.Enabled = ReturnPermission("D25F3040") = EnumPermission.DeleteEditAdd
        If mnuUpdateResult.Enabled Then
            mnuUpdateResult.Enabled = EnableMenu()
        End If
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case tdbg.Col
            Case COL_RecDepartmentID, COL_RecTeamID, COL_RecPositionID
                e.CellTip = tdbg.Columns(tdbg.Col + 1).Text
                'e.CellTip = tdbg.Columns(COL_RecDepartmentName).Text
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcRecDepartmentID
        sSQL = "Select 1 as DisplayOrder,DepartmentID, DepartmentName From D91T0012  WITH(NOLOCK) "
        sSQL &= "Where	Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union	" & vbCrLf
        sSQL &= "Select	0 as DisplayOrder,'%' as DepartmentID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as DepartmentName" & vbCrLf
        sSQL &= "Order by	DisplayOrder, DepartmentID"
        LoadDataSource(tdbcRecDepartmentID, sSQL)
        'Load tdbcRecTeam
        'LoadtdbcRecTeam("-1")
        'Load tdbcRecPositionID
        sSQL = "Select 1 as DisplayOrder,RecPositionID, RecPositionName From D25T1020  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where	Disabled = 0"
        sSQL &= " 	Union" & vbCrLf
        sSQL &= " 	Select	0 as DisplayOrder,'%' as RecPositionID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as RecPositionName" & vbCrLf
        sSQL &= " 	Order by	DisplayOrder, RecPositionID"
        LoadDataSource(tdbcRecPositionID, sSQL)
    End Sub

    Private Sub LoadtdbcRecTeam(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL &= " Select	1 as DisplayOrder,T1.TeamID, T1.TeamName,T1.DepartmentID"
        sSQL &= " From	D09T0227 T1 WITH(NOLOCK) "
        sSQL &= " Inner join 	D91T0012 T2  WITH(NOLOCK) On T2.DepartmentID=T1.DepartmentID" & vbCrLf
        sSQL &= " 	Where	T1.Disabled = 0  And T2.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " 	And T1.DepartmentID = " & SQLString(ID) & vbCrLf
        sSQL &= " 	Union" & vbCrLf
        sSQL &= " 	Select 	0 as DisplayOrder,'%'	as TeamID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as TeamName, '%' as DepartmentID" & vbCrLf
        sSQL &= " 	Order by	DisplayOrder, T1.DepartmentID,T1.TeamID"
        LoadDataSource(tdbcRecTeam, sSQL)
    End Sub

#Region "Events tdbcRecDepartmentID load tdbcRecTeam"

    Private Sub tdbcRecDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentID.LostFocus
        If tdbcRecDepartmentID.FindStringExact(tdbcRecDepartmentID.Text) = -1 Then tdbcRecDepartmentID.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentID.SelectedValueChanged
        If Not (tdbcRecDepartmentID.Tag Is Nothing OrElse tdbcRecDepartmentID.Tag.ToString = "") Then
            tdbcRecDepartmentID.Tag = ""
            Exit Sub
        End If
        If tdbcRecDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcRecTeam("-1")
            Exit Sub
        End If
        LoadtdbcRecTeam(tdbcRecDepartmentID.SelectedValue.ToString())
        tdbcRecTeam.SelectedValue = "%"
    End Sub


    Private Sub tdbcRecTeam_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeam.SelectedValueChanged
        If tdbcRecTeam.FindStringExact(tdbcRecTeam.Text) = -1 Then tdbcRecTeam.Text = ""
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.SelectedValueChanged
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeam.Close, tdbcRecDepartmentID.Close, tdbcRecPositionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeam.Validated, tdbcRecDepartmentID.Validated, tdbcRecPositionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        LoadTDBGrid()
        btnFilter.Enabled = True
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim f As New D25F2013
        f.RecruitmentFileID = RecruitmentFileID
        f.InterviewFileID = InterviewFileID
        f.InterviewLevel = InterviewLevel
        f.RecruitPlanID = RecruitPlanID
        f.RecDepartmentID = tdbcRecDepartmentID.SelectedValue.ToString
        f.RecTeamID = tdbcRecTeam.SelectedValue.ToString
        f.RecPositionID = tdbcRecPositionID.SelectedValue.ToString
        f.ShowDialog()
        If Not f.FormClose Then
            sNewCandidateID = f.Candidate
            LoadTDBGrid()
        End If
        f.Dispose()
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        'Mở D25F2014
        Dim f As New D25F2014
        f.InterviewFileID = InterviewFileID
        f.RecruitmentFileID = RecruitmentFileID
        f.RecTeamID = tdbg.Columns(COL_RecTeamID).Text
        f.Candidate = tdbg.Columns(COL_CandidateID).Text
        f.InterviewLevel = InterviewLevel
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        If f.bSaved Then
            Dim bm As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = bm
        End If
        f.Dispose()
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim f As New D25F2014
        f.InterviewFileID = InterviewFileID
        f.RecruitmentFileID = RecruitmentFileID
        f.RecTeamID = tdbg.Columns(COL_RecTeamID).Text
        f.Candidate = tdbg.Columns(COL_CandidateID).Text
        f.InterviewLevel = InterviewLevel
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Function AllowDelete() As Boolean
        Try
            Dim sSQL As String = ""
            sSQL = "Select 1 From D25T2011 WITH(NOLOCK)  Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
            sSQL &= " And InterviewFileID = " & SQLString(InterviewFileID) & " And isnull(IntStatusID,'') <>''" & vbCrLf
            sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)

            Dim sResult As String = ReturnScalar(sSQL)
            If sResult = "1" Then
                D99C0008.MsgCanNotDelete()
                Return False
            End If
            Return True
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2011
    '# Created User: 
    '# Created Date: 28/11/2007 03:06:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: Detail
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2011() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2011"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "InterviewFileID = " & SQLString(InterviewFileID)
        sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2010
    '# Created User: 
    '# Created Date: 28/11/2007 03:07:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: Master
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2010() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2010"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "InterviewFileID = " & SQLString(InterviewFileID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2013
    '# Created User: 
    '# Created Date: 28/11/2007 03:08:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2013() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2013"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "InterviewFileID = " & SQLString(InterviewFileID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2014
    '# Created User: 
    '# Created Date: 28/11/2007 03:08:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2014() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2014"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "InterviewFileID = " & SQLString(InterviewFileID)
        Return sSQL
    End Function

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        sSQL = SQLDeleteD25T2011() & vbCrLf

        'sSQL &= SQLDeleteD25T2010() & vbCrLf
        'sSQL &= SQLDeleteD25T2013() & vbCrLf
        'sSQL &= SQLDeleteD25T2014()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            DeleteOK()
            Dim bm As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = bm - 1
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(sender, Nothing)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4080
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow(Me, "D25D0340", "D25F4080")
    End Sub

    Private Sub C1Command1_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateResult.Click
        Dim f As New D25F2050
        f.InterviewFileID = _interviewFileID
        f.RecruitmentFileID = _recruitmentFileID
        f.CandidateID = tdbg.Columns(COL_CandidateID).Text
        f.InterviewLevel = _interviewLevel
        f.ShowDialog()
        f.Dispose()

        If f.bSaved Then
            Dim bm As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = bm
        End If

    End Sub

    Private Function EnableMenu() As Boolean
        If tdbg.Columns(COL_TransferedD09).Text = "1" Then
            Return False
        ElseIf tdbg.Columns(COL_TransferedD09).Text = "0" Then
            Return True
        End If
    End Function

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        mnuUpdateResult.Enabled = EnableMenu()
    End Sub

End Class