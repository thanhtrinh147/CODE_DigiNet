﻿Imports System
Public Class D25F1050
	Dim dtCaptionCols As DataTable

    Private _isMSS As Integer = 1
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Private _formPermission As String = "D25F1050"
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _moduleID As String = "25"
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Public Const EXEMODULE As String = "D25"
    Public Const EXECHILD As String = "D25E0140"

    
#Region "Const of tdbg - Total of Columns: 64"
Private Const COL_IsSelected As Integer = 0             ' Chon
Private Const COL_CandidateID As Integer = 1            ' Mã
Private Const COL_CandidateName As Integer = 2          ' Họ và tên
Private Const COL_SexName As Integer = 3                ' Giới tính
Private Const COL_BirthDate As Integer = 4              ' Ngày sinh
Private Const COL_IDCardNo As Integer = 5               ' CMND
Private Const COL_BirthPlace As Integer = 6             ' BirthPlace
Private Const COL_NativePlace As Integer = 7            ' NativePlace
Private Const COL_EthnicID As Integer = 8               ' EthnicID
Private Const COL_EthnicName As Integer = 9             ' EthnicName
Private Const COL_ReligionID As Integer = 10            ' ReligionID
Private Const COL_ReligionName As Integer = 11          ' ReligionName
Private Const COL_ContactAddress As Integer = 12        ' Địa chỉ
Private Const COL_Mobile As Integer = 13                ' Điện thoại
Private Const COL_Email As Integer = 14                 ' Email
Private Const COL_EducationLevelID As Integer = 15      ' Trinh do van hoa
Private Const COL_EducationLevelName As Integer = 16    ' EducationLevelName
Private Const COL_ProfessionalLevelID As Integer = 17   ' ProfessionalLevelID
Private Const COL_ProfessionalLevelName As Integer = 18 ' ProfessionalLevelName
Private Const COL_PoliticsID As Integer = 19            ' PoliticsID
Private Const COL_PoliticsName As Integer = 20          ' PoliticsName
Private Const COL_SchoolID As Integer = 21              ' SchoolID
Private Const COL_SchoolName As Integer = 22            ' SchoolName
Private Const COL_MajorID As Integer = 23               ' MajorID
Private Const COL_MajorName As Integer = 24             ' MajorName
Private Const COL_EducationFormID As Integer = 25       ' EducationFormID
Private Const COL_EducationFormName As Integer = 26     ' EducationFormName
Private Const COL_Certificates As Integer = 27          ' Certificates
Private Const COL_LanguageID As Integer = 28            ' LanguageID
Private Const COL_LanguageName As Integer = 29          ' LanguageName
Private Const COL_LongBusinesstrip As Integer = 30      ' LongBusinesstrip
Private Const COL_TransferedD09 As Integer = 31         ' TransferedD09
Private Const COL_TransferedNameD09 As Integer = 32     ' Chuyển sang HSNV
Private Const COL_CandidateStatus As Integer = 33       ' Trạng thái
Private Const COL_Disabled As Integer = 34              ' Không sử dụng
Private Const COL_CreateUserID As Integer = 35          ' CreateUserID
Private Const COL_CreateDate As Integer = 36            ' CreateDate
Private Const COL_LastModifyUserID As Integer = 37      ' LastModifyUserID
Private Const COL_LastModifyDate As Integer = 38        ' LastModifyDate
Private Const COL_ReceivedDate As Integer = 39          ' Ngày nhận
Private Const COL_DivisionName As Integer = 40          ' Đơn vị
Private Const COL_BlockID As Integer = 41               ' BlockID
Private Const COL_BlockName As Integer = 42             ' Khối
Private Const COL_RecDepartmentID As Integer = 43       ' RecDepartmentID
Private Const COL_RecDepartmentName As Integer = 44     ' Phòng ban
Private Const COL_RecTeamID As Integer = 45             ' RecTeamID
Private Const COL_RecTeamName As Integer = 46           ' Tổ nhóm
Private Const COL_RecPositionID As Integer = 47         ' RecPositionID
Private Const COL_RecPositionName As Integer = 48       ' Vị trí
Private Const COL_ExperienceYear As Integer = 49        ' Số năm kinh nghiệm
Private Const COL_ProjectID As Integer = 50             ' ProjectID
Private Const COL_ProjectName As Integer = 51           ' Dự án
Private Const COL_DesiredSalary As Integer = 52         ' Lương yêu cầu
Private Const COL_CurrencyID As Integer = 53            ' CurrencyID
Private Const COL_FileReceiverName As Integer = 54      ' Người nhận HS
Private Const COL_ReceivedPlace As Integer = 55         ' Nơi nhận HS
Private Const COL_RecSourceID As Integer = 56           ' RecSourceID
Private Const COL_RecSourceName As Integer = 57         ' Nguồn tuyển dụng
Private Const COL_Suggester As Integer = 58             ' Người giới thiệu
Private Const COL_RemarkBeforeInterview As Integer = 59 ' Ghi chú
Private Const COL_RemarkName As Integer = 60            ' Tình trạng xử lý hồ sơ
Private Const COL_Sex As Integer = 61                   ' Sex
Private Const COL_EmployeeID As Integer = 62            ' EmployeeID
Private Const COL_DivisionID As Integer = 63            ' DivisionID
#End Region

#Region "Const of tdbg1"
    Private Const COL1_ExperienceID As Integer = 0    ' ExperienceID
    Private Const COL1_CandidateID As Integer = 1     ' CandidateID
    Private Const COL1_EmployeeID As Integer = 2      ' EmployeeID
    Private Const COL1_SenAdjustName As Integer = 3     ' Tăng/Giảm thâm niên
    Private Const COL1_Description As Integer = 4     ' Diễn giải
    Private Const COL1_DateStarted As Integer = 5     ' Ngày bắt đầu
    Private Const COL1_DateEnded As Integer = 6       ' Ngày kết thúc
    Private Const COL1_HistoryDivID As Integer = 7    ' Mã công ty
    Private Const COL1_CompanyName As Integer = 8     ' Tên công ty
    Private Const COL1_DivEvaluatation As Integer = 9 ' Đánh giá của công ty
    Private Const COL1_CountryID As Integer = 10      ' Quốc gia
    Private Const COL1_Address As Integer = 11        ' Địa chỉ
    Private Const COL1_Title As Integer = 12          ' Công việc
    Private Const COL1_TitleID As Integer = 13        ' TitleID
    Private Const COL1_Duty As Integer = 14           ' Chức vụ
    Private Const COL1_DutyID As Integer = 15         ' DutyID
    Private Const COL1_BaseSalary As Integer = 16     ' Mức lương
    Private Const COL1_Allowance As Integer = 17      ' Phụ cấp
    Private Const COL1_CurrencyID As Integer = 18     ' Loại tiền
    Private Const COL1_LeavingReason As Integer = 19  ' Lý do thôi việc
    Private Const COL1_Reference As Integer = 20      ' Thông tin liên hệ
    Private Const COL1_Note As Integer = 21           ' Ghi chú
#End Region

#Region "Const of tdbg2"
    Private Const COL2_DivisionName As Integer = 0      ' Đơn vị
    Private Const COL2_DepartmentName As Integer = 1    ' Phòng ban
    Private Const COL2_TeamName As Integer = 2          ' Tổ nhóm
    Private Const COL2_EmpGroupName As Integer = 3      ' Nhóm nhân viên
    Private Const COL2_DutyName As Integer = 4          ' Chức vụ
    Private Const COL2_WorkName As Integer = 5          ' Công việc/ Vị trí ứng tuyển
    Private Const COL2_InterviewFileName As Integer = 6 ' Lịch phỏng vấn
    Private Const COL2_IntDate As Integer = 7           ' Ngày PV
    Private Const COL2_InterviewLevels As Integer = 8   ' Vòng PV
    Private Const COL2_Content As Integer = 9           ' Nội dung PV
    Private Const COL2_Result As Integer = 10           ' Kết quả PV
    Private Const COL2_StatusID As Integer = 11         ' Trạng thái
#End Region


    Dim dtTeamID, dtDepartmentID, dtBlockID As New DataTable
    Dim dtGrid As DataTable
    Dim skey As String = ""
    Dim Flag As Boolean = False
    Dim bSelected As Boolean = False ' Ban dau chua chon
    Dim bIsUseBlock As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, TableLayoutPanel1, tdbg, tabMain, tdbg1, tdbg2)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12, chkTransactionTypeID)

    End Sub

    Private Sub D25F1050_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "TransactionTypeID_Check", chkTransactionTypeID.Checked)
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F1050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
        Select Case e.KeyCode
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
        If e.Alt Then
            Select Case e.KeyCode
                Case Keys.NumPad1, Keys.D1
                    tabMain.SelectedTab = TabPage1
                Case Keys.NumPad2, Keys.D2
                    tabMain.SelectedTab = TabPage2
            End Select
        End If
    End Sub

    Private Sub D25F1050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WriteLogFile(Now.Date.ToString)

        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        Flag = True
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)

        SetBackColorObligatory()
        tdbg_NumberFormat()
        Loadlanguage()
        LoadTDBCombo()
        LoadDefault()
        bIsUseBlock = VisibleBlock()
        chkTransactionTypeID.Checked = CBool(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "TransactionTypeID_Check", "False"))
        ResetGrid()
        CallD99U1111()
        InputDateCustomFormat(c1dateReceivedDateFrom, c1dateReceivedDateTo, c1DateEditBirthDate)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_ReceivedDate)
        InputDateInTrueDBGrid(tdbg1, COL1_DateEnded, COL1_DateStarted)
        InputDateInTrueDBGrid(tdbg2, COL2_IntDate)
        ResetSplitDividerSize(tdbg2)
        ResetColorGrid(tdbg, tdbg1, tdbg2)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868("%", _formPermission, _isMSS)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868("%", _formPermission, _isMSS)
        'LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868("%", _formPermission, _isMSS)
        '  LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        'Load tdbcRecPositionID
        sSQL = "Select 0 as DisplayOrder,'%' as RecPositionID, " & sLanguage & " As RecPositionName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "SELECT	1 as DisplayOrder,DutyID as RecPositionID,DutyName" & sUnicode & " as RecPositionName FROM D09T0211  WITH(NOLOCK) WHERE(Disabled = 0) ORDER BY	DisplayOrder, RecPositionID"
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        LoadCboDivisionIDAll(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedValue = gsDivisionID
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P1010()
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_CandidateID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_ung_cu_vien_-_D25F1050") & UnicodeCaption(gbUnicode) 'Danh móc ÷ng cõ vi£n - D25F1050
        '================================================================ 
        lblReceivedDateFrom.Text = rl3("Ngay_nop_HS") 'Ngày nộp HS
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Vi_tri") 'Vị trí
        btnCollapse.Text = " " & rL3("Thong_tin_khac") 'Thông tin khác
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị ứng tuyển
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        chkTransactionTypeID.Text = rL3("Su_dung_loai_nghiep_vu_HSUV") 'Sử dụng loại nghiệp vụ HSUV
        '================================================================ 
        TabPage1.Text = "1. " & rL3("Kinh_nghiem_lam_viec")
        TabPage2.Text = "2. " & rL3("Lich_su_phong_vanU")
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" '&Lọc
        '************************
        'Tham ngay 16/1/2013 theo ID 50600 của Phương Thảo bởi Văn Vinh
        mnsAdd1.Text = rl3("Them")
        tsbAdd1.Text = mnsAdd1.Text
        tsmAdd1.Text = mnsAdd1.Text
        mnsAdds.Text = rl3("Them_hang_loat")
        tsmAdds.Text = mnsAdds.Text
        tsbAdds.Text = mnsAdds.Text
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_DivisionName).Caption = rL3("Don_vi")
        tdbg.Columns(COL_IsSelected).Caption = rL3("Chon")
        tdbg.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ContactAddress").Caption = rl3("Dia_chi") 'Địa chỉ
        tdbg.Columns("Mobile").Caption = rL3("Dien_thoai") 'Điện thoại
        tdbg.Columns(COL_EducationLevelID).Caption = rL3("Trinh_do_van_hoa_U")
        tdbg.Columns("TransferedNameD09").Caption = rl3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        tdbg.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng
        tdbg.Columns("ReceivedDate").Caption = rl3("Ngay_nhan") 'Ngày nhận
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("RecDepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("RecTeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns("FileReceiverName").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("Suggester").Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
        tdbg.Columns(COL_IDCardNo).Caption = rl3("CMND")
        tdbg.Columns(COL_ProjectName).Caption = rL3("Cong_trinh")
        tdbg.Columns(COL_CandidateStatus).Caption = rL3("Trang_thai")
        tdbg.Columns(COL_RemarkBeforeInterview).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_RemarkName).Caption = rL3("Tinh_trang_xu_ly_ho_so") 'Tình trạng xử lý hồ sơ
        '================================================================ 
        tdbg.Splits(0).Caption = rL3("Thong_tin_chung")
        tdbg.Splits(1).Caption = (rL3("Thong_tin_tuyen_dung"))
        '================================================================ 
        tdbg1.Columns(COL1_SenAdjustName).Caption = rL3("TangGiam_tham_nien") 'Tăng/Giảm thâm niên
        tdbg1.Columns(COL1_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg1.Columns(COL1_DateStarted).Caption = rL3("Ngay_bat_dau") 'Ngày bắt đầu
        tdbg1.Columns(COL1_DateEnded).Caption = rL3("Ngay_ket_thuc") 'Ngày kết thúc
        tdbg1.Columns(COL1_HistoryDivID).Caption = rL3("Ma_doi_tac") 'Mã công ty
        tdbg1.Columns(COL1_CompanyName).Caption = rL3("Ten_cong_ty") 'Tên công ty
        tdbg1.Columns(COL1_DivEvaluatation).Caption = rL3("Danh_gia_cua_cong_ty") 'Đánh giá của công ty
        tdbg1.Columns(COL1_CountryID).Caption = rL3("Quoc_gia") 'Quốc gia
        tdbg1.Columns(COL1_Address).Caption = rL3("Dia_chi") 'Địa chỉ
        tdbg1.Columns(COL1_Title).Caption = rL3("Cong_viec") 'Công việc
        tdbg1.Columns(COL1_Duty).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg1.Columns(COL1_BaseSalary).Caption = rL3("Muc_luong") 'Mức lương
        tdbg1.Columns(COL1_Allowance).Caption = rL3("Phu_cap") 'Phụ cấp
        tdbg1.Columns(COL1_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg1.Columns(COL1_LeavingReason).Caption = rL3("Ly_do_thoi_viec") 'Lý do thôi việc
        tdbg1.Columns(COL1_Reference).Caption = rL3("Thong_tin_lien_he") 'Thông tin liên hệ
        tdbg1.Columns(COL1_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        '================================================================ 
        tdbg2.Columns(COL2_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg2.Columns(COL2_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg2.Columns(COL2_EmpGroupName).Caption = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg2.Columns(COL2_DutyName).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg2.Columns(COL2_WorkName).Caption = rL3("Cong_viec_Vi_tri_ung_tuyen") 'Công việc/ Vị trí ứng tuyển
        tdbg2.Columns(COL2_InterviewFileName).Caption = rL3("Lich_phong_van") 'Lịch phỏng vấn
        tdbg2.Columns(COL2_IntDate).Caption = rL3("Ngay_PV") 'Ngày PV
        tdbg2.Columns(COL2_InterviewLevels).Caption = rL3("Vong_PV") 'Vòng PV
        tdbg2.Columns(COL2_Content).Caption = rL3("Noi_dung_PV") 'Nội dung PV
        tdbg2.Columns(COL2_Result).Caption = rL3("Ket_qua_PV") 'Kết quả PV
        tdbg2.Columns(COL2_StatusID).Caption = rL3("Trang_thai") 'Trạng thái
        tdbg2.Columns(COL2_DivisionName).Caption = rL3("Don_vi")
        '================================================================ 
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
    End Sub

    Private Sub LoadDefault()
        'tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateReceivedDateFrom.Value = "01/" & Format(giTranMonth, "00") & "/" & giTranYear
        Dim datenow As Date = New Date(giTranYear, giTranMonth, Date.DaysInMonth(giTranYear, giTranMonth))
        c1dateReceivedDateTo.Value = datenow
    End Sub

    Private Function VisibleBlock() As Boolean
        Dim sIsUseBlock As String = ReturnScalar("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If sIsUseBlock = "0" Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateReceivedDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateReceivedDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_DesiredSalary).NumberFormat = D25Format.DefaultNumber2
          tdbg.Columns(COL_ExperienceYear).NumberFormat = D25Format.DefaultNumber2
   
    End Sub

#Region "Combo Events"

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        'If tdbcBlockID.SelectedValue Is Nothing Then
        '    LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        'Else

        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        '  End If
        tdbcDepartmentID.SelectedIndex = 0
        'tdbcDepartmentID.AutoSelect = True
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown
    '    If gbUnicode Then Exit Sub
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcRecPositionID.Leave
    '    '  If gbUnicode Then Exit Sub 
    '    Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

    '    If tdbcName.SelectedIndex <> -1 Then
    '        tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
    '    End If
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

#Region "Active FilterChange "
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
             WriteLogFile(ex.Message)
        End Try
    End Sub
    '	Vào sự kiện tdbg_KeyPress viết code như sau:
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsSelected
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub
    '	Vào sự kiện tdbg_DoubleClick viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub
    '	Vào sự kiện tdbg_KeyDown viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(sender, Nothing)
        End If
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col) : Exit Sub
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsSelected
                L3HeadClick(tdbg, iCol, bSelect)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub


    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D25F5610")
        'tsbExportToExcel.Enabled = tdbg.RowCount > 0
        'tsmExportToExcel.Enabled = tdbg.RowCount > 0
        'tsbInherit.Enabled = tsbAdd.Enabled
        'tsmInherit.Enabled = tsbAdd.Enabled
        'mnsInherit.Enabled = tsbInherit.Enabled
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub
#End Region

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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        ' If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        gbEnabledUseFind = True
        'Dim sSQL As String
        'sSQL = "Select * From D90V1234 Where FormID = " & SQLString(Me.Name) & " And Language = " & SQLString(gsLanguage)
        'ShowFindDialog(Finder, sSQL)
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        '  End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
        '*****************************************

    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    'Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
    '    If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
    '    Dim sSQL As String = ""
    '    gbEnabledUseFind = True
    '    sSQL = "Select * From D25V1234 "
    '    sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
    '    ShowFindDialog(Finder, sSQL, gbUnicode)
    'End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    LoadTDBGrid()
    'End Sub

    'Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
    '    If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
    '    sFind = ""
    '    LoadTDBGrid()
    'End Sub
#End Region

    Private Sub tsbInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim sCandidateID As String = ""
        Dim f As New D25F1055
        f.ShowDialog()
        sCandidateID = f.skey
        If sCandidateID <> "" Then
            LoadTDBGrid(True, sCandidateID)
        End If
        f.Dispose()
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click

        'If chkTransactionTypeID.Checked Then
        '    If D25Options.TransTypeID = "" Then
        '        Dim ff As New SelectTransactionType
        '        ff.ShowDialog()
        '        ff.Dispose()
        '    End If

        '    If D25Options.TransTypeID = "" Then Exit Sub
        '    Dim f1 As New D25F1051_NN
        '    f1.CandidateID = tdbg.Columns(COL_CandidateID).Text
        '    f1.DivisionID = tdbg.Columns(COL_DivisionID).Text
        '    f1.ModuleID = _moduleID
        '    f1.FormState = EnumFormState.FormView
        '    f1.ShowDialog()
        '    f1.Dispose()
        'Else
        'End If

        'ID 84614 30/03/2016. Luôn gọi màn hình D25F1051, không quan tâm tới check Sử dụng loại nghiệp vụ HSUV
        Dim f1 As New D25F1051
        f1.CandidateID = tdbg.Columns(COL_CandidateID).Text
        f1.DivisionID = tdbg.Columns(COL_DivisionID).Text
        f1.ModuleID = _moduleID
        f1.FormState = EnumFormState.FormView
        f1.ShowDialog()
        f1.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        'If chkTransactionTypeID.Checked Then
        '    If D25Options.TransTypeID = "" Then
        '        Dim ff As New SelectTransactionType
        '        ff.ShowDialog()
        '        ff.Dispose()
        '    End If

        '    If D25Options.TransTypeID = "" Then Exit Sub

        '    Dim f1 As New D25F1051_NN
        '    f1.CandidateID = tdbg.Columns(COL_CandidateID).Text
        '    f1.DivisionID = tdbg.Columns(COL_DivisionID).Text
        '    f1.ModuleID = _moduleID
        '    f1.FormState = EnumFormState.FormEdit
        '    f1.ShowDialog()
        '    If f1.bSaved Then
        '        LoadTDBGrid(False, tdbg.Columns(COL_CandidateID).Text)
        '        'Dim bm As Integer = tdbg.Bookmark
        '        'tdbg.Bookmark = bm
        '    End If
        '    f1.Dispose()
        'Else
        'End If

        'ID 84614 30/03/2016. Luôn gọi màn hình D25F1051, không quan tâm tới check Sử dụng loại nghiệp vụ HSUV
        Dim f1 As New D25F1051
        f1.CandidateID = tdbg.Columns(COL_CandidateID).Text
        f1.DivisionID = tdbg.Columns(COL_DivisionID).Text
        f1.ModuleID = _moduleID
        f1.FormState = EnumFormState.FormEdit
        f1.ShowDialog()
        If f1.bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_CandidateID).Text)
        f1.Dispose()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        ' If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""

        'sSQL = " Delete D25T1041 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= "And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'sSQL &= " Delete D25T1042 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'sSQL &= " Delete D25T1050 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID =" & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'sSQL &= " Delete D25T1051 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'sSQL &= " Delete D25T1052 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        '' 27/3/2015 id 74269 - Rem code lại câu lệnh xóa. Chấp nhận tồn tại dữ liệu rác file đính kèm khi xóa dữ liệu.
        ''        sSQL &= " Delete D91T1010 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        ''        'sSQL &= " And CandidateID =" & tdbg.Columns(COL_CandidateID).Text & vbCrLf
        ''        sSQL &= " And TableName = 'D25T1041'" & vbCrLf

        ''add 15/01/08
        'sSQL &= " Delete D25T2011 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'sSQL &= " Delete D25T1054 Where DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        'sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        'ID 78629 1/10/215
        If Not CheckStore(SQLStoreD25P5555("D25F1050", tdbg.Columns(COL_CandidateID).Text, "", 0, 0)) Then Exit Sub

        sSQL = SQLStoreD25P5556(tdbg.Columns(COL_CandidateID).Text)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'Bổ sung AuditLog (10/04/2008), Analyst: Ngọc Lan

            Dim Decs1 As String = ""
            Dim Decs2 As String = ""
            Dim Decs3 As String = ""
            Dim Decs4 As String = ""
            Dim Decs5 As String = ""
            Decs1 = Trim(tdbg.Columns(COL_DivisionID).Text)
            Decs2 = Trim(tdbg.Columns(COL_CandidateID).Text)
            Decs3 = Trim(tdbg.Columns(COL_RecDepartmentID).Text)
            Decs4 = Trim(tdbg.Columns(COL_RecTeamID).Text)
            Decs5 = Trim(tdbg.Columns(COL_RecPositionID).Text)
            Call RunAuditLog("CandidateFiles", "03", Decs1, Decs2, Decs3, Decs4, Decs5)

            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            DeleteOK()
            'Dim bm As Integer = tdbg.Row
            'LoadTDBGrid(True)
            'tdbg.Row = bm - 1
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Dim dtCaptionCols As DataTable

        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , True, , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , True, , gbUnicode)

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        '       Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
	CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        'With frm
        '    .FormID = Me.Name
        '    .UseUnicode = gbUnicode
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With

    End Sub

    Private Sub tsbImportData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        '       Dim f As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D25, "D25F1050", "Candidate") Then
            'Load lại dữ liệu
            btnFilter_Click(Nothing, Nothing)
        End If
        'f.FormPermission = "D25F1050"
        'f.ModuleID = D25
        'f.TransTypeID = "Candidate"
        'f.sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        'f.ShowDialog()

        'If f.OutPut01 = True Then
        '    btnFilter_Click(Nothing, Nothing)
        'End If
        'f.Dispose()
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/03/2014 02:18:41
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal dr As DataRow) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(dr.Item("CandidateID")) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/03/2014 02:23:13
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        Dim dr() As DataRow = dtGrid.DefaultView.ToTable.Select("IsSelected=1")
        If dr.Length > 0 Then
            Dim sSQL As New StringBuilder
            sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
            For i As Integer = 0 To dr.Length - 1
                sSQL.Append(SQLInsertD09T6666(dr(i)).ToString & vbCrLf)
            Next
            ExecuteSQL(sSQL.ToString)
        End If

        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4000
        'f.FormPermission = "D25F4000"
        'f.ID01 = sFind
        'f.ID02 = "0"
        'f.ShowDialog()
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F4000")
        SetProperties(arrPro, "sFind", sFind)
        SetProperties(arrPro, "DivisionID", ReturnValueC1Combo(tdbcDivisionID))
        SetProperties(arrPro, "VisibleFilterButton", "0")
        CallFormShow(Me, "D25D0340", "D25F4000", arrPro)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        WriteLogFile(Now.Date.ToString)

        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
        If Not AllowFilter() Then Exit Sub

        If c1dateReceivedDateFrom.Text = "" Then c1dateReceivedDateFrom.Value = "01/" & Format(giTranMonth, "00") & "/" & giTranYear
        Dim datenow As Date = New Date(giTranYear, giTranMonth, Date.DaysInMonth(giTranYear, giTranMonth))
        If c1dateReceivedDateTo.Text = "" Then c1dateReceivedDateTo.Value = datenow

        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid(True, "")
    End Sub

    Private Sub btnImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tsbImportData_Click(Nothing, Nothing)
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" And bIsUseBlock Then
            D99C0008.MsgNotYetChoose(rL3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Vi_tri"))
            tdbcRecPositionID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function AllowDelete() As Boolean
        Dim sSQL As String = ""
        Dim dt As DataTable
        sSQL = SQLCheckApplyInfo()
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rL3("Ma_ung_vien_nay_da_duoc_su_dung_roi"))
            tdbg.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function SQLCheckApplyInfo() As String
        Dim sSQL As String = ""
        sSQL &= " Select  	CandidateID	"
        sSQL &= " 	From 	D25T1042 WITH(NOLOCK) "
        sSQL &= " 	Where	DivisionID = " & SQLString(tdbg.Columns(COL_DivisionID).Text)
        sSQL &= "And CandidateID =" & SQLString(tdbg.Columns(COL_CandidateID).Text)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1010
    '# Created User: Lê Thị Lành
    '# Created Date: 01/11/2007 08:20:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1010 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateFrom.Value) & COMMA 'ReceivedDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateTo.Value) & COMMA 'ReceivedDateTo, datetime, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D25F1050") 'FormID, varchar[50], NOT NULL
        sSQL &= COMMA & SQLString(ReturnValueC1Combo(tdbcBlockID))
        Return sSQL
    End Function


    Private Sub mnsAdd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsAdd1.Click, tsbAdd1.Click, tsmAdd1.Click
        Try
            'If chkTransactionTypeID.Checked Then
            '    If D25Options.TransTypeID = "" Then
            '        Dim ff As New SelectTransactionType
            '        ff.ShowDialog()
            '        ff.Dispose()
            '    End If
            '    If D25Options.TransTypeID = "" Then Exit Sub
            '    Dim f As New D25F1051_NN
            '    'Goi D09F0101 tu  Danh muc : sTransaction="0"; Goi D09F0101 tu  Nghiệp vụ : sTransaction="1"
            '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "sTransaction", "0")
            '    f.DivisionID = ReturnValueC1Combo(tdbcDivisionID)
            '    f.ModuleID = _moduleID
            '    f.FormState = EnumFormState.FormAdd
            '    f.ShowDialog()
            '    skey = f.CandidateID
            '    _bSaved = f.bSaved
            '    f.Dispose()
            'Else
            'End If

            'ID 84614 30/03/2016. Luôn gọi màn hình D25F1051, không quan tâm tới check Sử dụng loại nghiệp vụ HSUV
            Dim f As New D25F1051
            'Goi D09F0101 tu  Danh muc : sTransaction="0"; Goi D09F0101 tu  Nghiệp vụ : sTransaction="1"
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "sTransaction", "0")
            f.DivisionID = ReturnValueC1Combo(tdbcDivisionID)
            f.ModuleID = _moduleID
            f.FormState = EnumFormState.FormAdd
            f.ShowDialog()
            skey = f.CandidateID
            If f.bSaved Then LoadTDBGrid(True, skey)
            f.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub mnsAdds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsAdds.Click, tsbAdds.Click, tsmAdds.Click
        Try
            If chkTransactionTypeID.Checked Then
                If D25Options.TransTypeID = "" Then
                    Dim ff As New SelectTransactionType
                    ff.ShowDialog()
                    ff.Dispose()
                End If
                If D25Options.TransTypeID = "" Then Exit Sub
            End If

            Dim frm As New D25F1056
            With frm
                .ModuleID = _moduleID
                .AutoCandidateID = L3Int(IIf(D25Systems.AutoCandidateID, 1, 0))
                .IsMode = L3Int(IIf(chkTransactionTypeID.Checked, 1, 0))
                .TransTypeID = D25Options.TransTypeID
                .ShowDialog()
                skey = .candidateID
                If .bSaved Then LoadTDBGrid(True, skey)
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub


    Dim sFilter1 As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter1 As Boolean = False
    Private Sub C1TrueDBGrid2_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg1.FilterChange
        Try
            If (dtGrid1 Is Nothing) Then Exit Sub
            If bRefreshFilter1 Then Exit Sub
            FilterChangeGrid(tdbg1, sFilter1) 'Nếu có Lọc khi In
            ReLoadTDBGrid1()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub C1TrueDBGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg1, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1TrueDBGrid2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            'Case COL_OrderNum 'Chặn nhập liệu trên cột STT tăng tự động trong code
            '    e.Handled = CheckKeyPress(e.KeyChar, True)
            'Case COL_Disabled, COL_System 'Chặn Ctrl + V trên cột Check
            '    e.Handled = CheckKeyPress(e.KeyChar)
            Case COL1_BaseSalary, COL1_Allowance 'Chặn chỉ nhập Số  
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Dim sFilter2 As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter2 As Boolean = False
    Private Sub tdbg2_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.FilterChange
        Try
            If (dtGrid2 Is Nothing) Then Exit Sub
            If bRefreshFilter2 Then Exit Sub
            FilterChangeGrid(tdbg2, sFilter2) 'Nếu có Lọc khi In
            ReLoadTDBGrid2()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg2, e)
        Me.Cursor = Cursors.Default
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P0250
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/03/2014 12:03:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P0250() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi Kinh nghiem lam viec" & vbCrLf)
        sSQL &= "Exec D09P0250 "
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CandidateID).Text) & COMMA 'CandidateID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D25") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1054
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 26/03/2014 12:04:18
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1054() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi Lich su phong van" & vbCrLf)
        sSQL &= "Exec D25P1054 "
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CandidateID).Text) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Dim dtGrid1 As DataTable, dtGrid2 As DataTable
    Private Sub LoadTDBGrid1()
        ResetFilter(tdbg1, sFilter1, bRefreshFilter1)
        dtGrid1 = ReturnDataTable(SQLStoreD09P0250)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        ReLoadTDBGrid1()
    End Sub

    Private Sub ReLoadTDBGrid1()
        Dim strFind As String = ""
        If sFilter1.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter1.ToString

        dtGrid1.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbg1, COL1_SenAdjustName)
    End Sub

    Private Sub LoadTDBGrid2()
        ResetFilter(tdbg2, sFilter2, bRefreshFilter2)
        dtGrid2 = ReturnDataTable(SQLStoreD25P1054)
        LoadDataSource(tdbg2, dtGrid2, gbUnicode)
        ReLoadTDBGrid2()
    End Sub

    Private Sub ReLoadTDBGrid2()
        Dim strFind As String = ""
        If sFilter2.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter2.ToString

        dtGrid2.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbg2, COL2_DepartmentName)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount = 0 OrElse tdbg.Row < 0 Then Exit Sub
        If tdbg.Tag IsNot Nothing AndAlso tdbg.Tag.ToString = tdbg.Columns(COL_CandidateID).Text Then Exit Sub
        tdbg.Tag = tdbg.Columns(COL_CandidateID).Text
        LoadTDBGrid1()
        LoadTDBGrid2()
    End Sub

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_IsSelected, COL_CandidateID}
        'Dim arrColObligatory1() As Object = {COL_RecDepartmentName}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        'usrOption.AddColVisible(tdbg, SPLIT0, dtF12, , arrColObligatory) 'split0
        'usrOption.AddColVisible(tdbg, SPLIT1, dtF12, , arrColObligatory1) 'split1 
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Dim Tooltip As New ToolTip
    Private Sub btnCollasp_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.MouseHover
        Tooltip.SetToolTip(btnCollapse, IIf(L3Bool(btnCollapse.Tag), "Expand", "Collapse").ToString)
    End Sub

    Private Sub btnCollasp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.Click
        tabMain.Visible = L3Bool(btnCollapse.Tag)
        If tabMain.Visible Then
            btnCollapse.Image = imgDownUp.Images(0)
            pnlDetail.Location = New Point(pnlDetail.Location.X, pnlDetail.Location.Y - tabMain.Height)
            ' tdbg.Height -= tabMain.Height
            TableLayoutPanel1.RowStyles.Item(TableLayoutPanel1.RowCount - 1).Height = 45 'Khi design
        Else
            btnCollapse.Image = imgDownUp.Images(1)
            pnlDetail.Top = pnlDetail.Location.Y + tabMain.Height
            ' tdbg.Height += tabMain.Height
            TableLayoutPanel1.RowStyles.Item(TableLayoutPanel1.RowCount - 1).Height = 0
        End If
        btnCollapse.Tag = Not L3Bool(btnCollapse.Tag) '0: Collapse, 1: Expand
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        'Dim dtTemp As DataTable = ReturnTableFilter(dtBlockID, "DivisionID= '%' And DivisionID=" & SQLString(ReturnValueC1Combo(tdbcDivisionID)), True)
        LoadtdbcBlockID(tdbcBlockID, dtBlockID, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcBlockID.SelectedIndex = 0
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5556
    '# Created User: 
    '# Created Date: 01/10/2015 04:35:43
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5556(ByVal sCandidate As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu ung vien" & vbCrLf)
        sSQL &= "Exec D25P5556 "
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString("D25F1050") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(sCandidate) 'CandidateID, varchar[50], NOT NULL
        Return sSQL
    End Function


    Private Sub D25F1050_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WriteLogFile(Now.Date.ToString)
    End Sub


End Class