Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 11/12/2008 11:49:51 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 11/12/2008 11:49:51 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D25F2060
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim dtNCodeID As DataTable
    Dim dtGrid, dtTeamID, dtDepartmentID As DataTable
    Dim iPerD25F2100 As Integer = ReturnPermission("D25F2100")

    Private Enum button
        HireInfo = 0
        SalaryInfo = 1
    End Enum


#Region "Const of tdbg - Total of Columns: 85"
    Private Const COL_TransID As Integer = 0              ' TransID
    Private Const COL_IsUsed As Integer = 1               ' Chọn
    Private Const COL_Approved As Integer = 2             ' Duyệt
    Private Const COL_CandidateID As Integer = 3          ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 4        ' Họ và tên
    Private Const COL_InterviewFileName As Integer = 5    ' Lịch PV
    Private Const COL_SexName As Integer = 6              ' Giới tính
    Private Const COL_Birthdate As Integer = 7            ' Ngày sinh
    Private Const COL_ContactAddress As Integer = 8       ' Địa chỉ
    Private Const COL_Telephone As Integer = 9            ' Điện thoại
    Private Const COL_Email As Integer = 10               ' Email
    Private Const COL_TransferedD09 As Integer = 11       ' Chuyển sang HSNV
    Private Const COL_PreparerID As Integer = 12          ' Người lập
    Private Const COL_PreparedDate As Integer = 13        ' Ngày lập
    Private Const COL_DivisionID As Integer = 14          ' Đơn vị
    Private Const COL_BlockID As Integer = 15             ' BlockID
    Private Const COL_BlockName As Integer = 16           ' Khối
    Private Const COL_DepartmentID As Integer = 17        ' DepartmentID
    Private Const COL_DepartmentName As Integer = 18      ' Phòng ban
    Private Const COL_TeamID As Integer = 19              ' TeamID
    Private Const COL_TeamName As Integer = 20            ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 21       ' RecPositionID
    Private Const COL_RecPositionName As Integer = 22     ' Vị trí
    Private Const COL_InterviewFileID As Integer = 23     ' InterviewFileID
    Private Const COL_DutyID As Integer = 24              ' Chức vụ
    Private Const COL_WorkID As Integer = 25              ' Công việc
    Private Const COL_ProjectID As Integer = 26           ' Dự án
    Private Const COL_DirectManagerID As Integer = 27     ' Người quản lý trực tiếp
    Private Const COL_BeginDate As Integer = 28           ' Ngày vào làm
    Private Const COL_WorkingPlace As Integer = 29        ' Địa điểm
    Private Const COL_WorkingStatusID As Integer = 30     ' Hình thức làm việc
    Private Const COL_WorkingHours As Integer = 31        ' Thời gian làm việc
    Private Const COL_TrialPeriod As Integer = 32         ' Thời gian thử việc
    Private Const COL_TrialDateFrom As Integer = 33       ' Ngày bắt đầu VT
    Private Const COL_TrialDateTo As Integer = 34         ' Ngày kết thúc VT
    Private Const COL_StatusID As Integer = 35            ' Trạng thái
    Private Const COL_OfferDate As Integer = 36           ' Ngày gửi thư thử việc
    Private Const COL_N01ID As Integer = 37               ' N01ID
    Private Const COL_N02ID As Integer = 38               ' N02ID
    Private Const COL_N03ID As Integer = 39               ' N03ID
    Private Const COL_N04ID As Integer = 40               ' N04ID
    Private Const COL_N05ID As Integer = 41               ' N05ID
    Private Const COL_N06ID As Integer = 42               ' N06ID
    Private Const COL_N07ID As Integer = 43               ' N07ID
    Private Const COL_N08ID As Integer = 44               ' N08ID
    Private Const COL_N09ID As Integer = 45               ' N09ID
    Private Const COL_N10ID As Integer = 46               ' N10ID
    Private Const COL_N11ID As Integer = 47               ' N11ID
    Private Const COL_N12ID As Integer = 48               ' N12ID
    Private Const COL_N13ID As Integer = 49               ' N13ID
    Private Const COL_N14ID As Integer = 50               ' N14ID
    Private Const COL_N15ID As Integer = 51               ' N15ID
    Private Const COL_N16ID As Integer = 52               ' N16ID
    Private Const COL_N17ID As Integer = 53               ' N17ID
    Private Const COL_N18ID As Integer = 54               ' N18ID
    Private Const COL_N19ID As Integer = 55               ' N19ID
    Private Const COL_N20ID As Integer = 56               ' N20ID
    Private Const COL_RecruitmentFileName As Integer = 57 ' Đề xuất tuyển dụng
    Private Const COL_RecruitmentFileID As Integer = 58   ' RecruitmentFileID
    Private Const COL_SalaryObjectID As Integer = 59      ' Đối tượng tính lương
    Private Const COL_BaseSalary01 As Integer = 60        ' BaseSalary01
    Private Const COL_BaseSalary02 As Integer = 61        ' BaseSalary02
    Private Const COL_BaseSalary03 As Integer = 62        ' BaseSalary03
    Private Const COL_BaseSalary04 As Integer = 63        ' BaseSalary04
    Private Const COL_SalCoefficient01 As Integer = 64    ' SalCoefficient01
    Private Const COL_SalCoefficient02 As Integer = 65    ' SalCoefficient02
    Private Const COL_SalCoefficient03 As Integer = 66    ' SalCoefficient03
    Private Const COL_SalCoefficient04 As Integer = 67    ' SalCoefficient04
    Private Const COL_SalCoefficient05 As Integer = 68    ' SalCoefficient05
    Private Const COL_SalCoefficient06 As Integer = 69    ' SalCoefficient06
    Private Const COL_SalCoefficient07 As Integer = 70    ' SalCoefficient07
    Private Const COL_SalCoefficient08 As Integer = 71    ' SalCoefficient08
    Private Const COL_SalCoefficient09 As Integer = 72    ' SalCoefficient09
    Private Const COL_SalCoefficient10 As Integer = 73    ' SalCoefficient10
    Private Const COL_SalCoefficient11 As Integer = 74    ' SalCoefficient11
    Private Const COL_SalCoefficient12 As Integer = 75    ' SalCoefficient12
    Private Const COL_SalCoefficient13 As Integer = 76    ' SalCoefficient13
    Private Const COL_SalCoefficient14 As Integer = 77    ' SalCoefficient14
    Private Const COL_SalCoefficient15 As Integer = 78    ' SalCoefficient15
    Private Const COL_SalCoefficient16 As Integer = 79    ' SalCoefficient16
    Private Const COL_SalCoefficient17 As Integer = 80    ' SalCoefficient17
    Private Const COL_SalCoefficient18 As Integer = 81    ' SalCoefficient18
    Private Const COL_SalCoefficient19 As Integer = 82    ' SalCoefficient19
    Private Const COL_SalCoefficient20 As Integer = 83    ' SalCoefficient20
    Private Const COL_DetailNotes As Integer = 84         ' Ghi chú
#End Region

#Region "UserControl D09U1111 (gồm 4 bước)"
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Private _transID As String = ""
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = value
        End Set
    End Property

    Private _divisionID As String = ""
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
            If _divisionID = "" Then _divisionID = gsDivisionID
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, pnlM)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter, btnHireInfo, btnSalaryInfo)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkIsUsed, btnF12, btnSalaryUpdate, btnChoose, btnToEmployeeFiles)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnNext, btnPrint, btnClose)

    End Sub

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()
            LoadNxxID()
            LoadDefault() 'Đặt sau load combo
            LoadTDBDropDown()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadAdd()
                Case EnumFormState.FormEdit
                    LoadEdit()
                    EnabledButton()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnToEmployeeFiles.Enabled = False
                    btnChoose.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D25F2060_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F2060_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab Then
            If e.KeyCode = Keys.Enter Then UseEnterAsTab(Me)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            If pnlM.Enabled Then btnFilter_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.picClose_Click(Nothing, Nothing)
        End If
        '***************************************
    End Sub

    Dim clsCheckValid As Lemon3.Controls.CheckEmptyGrid

    Private Sub D25F2060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _formState
        _bSaved = False
        ResetFooterGrid(tdbg, 0, 2)
        ResetSplitDividerSize(tdbg)
        SetShortcutPopupMenu(ContextMenuStrip1)
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        VisibleBlock()
        Column_Caption()
        tdbg_NumberFormat()
        '*************************************
        InputbyUnicode(Me, gbUnicode)
        '********************
        GetTextCreateByNew(tdbg, COL_PreparerID, 2)
        ResetGrid()
        clsCheckValid = New Lemon3.Controls.CheckEmptyGrid(tdbg, Me.Name)
        'clsCheckValid.MappingColumn(tdbg.Columns(COL_ProjectID).DataField, tdbg.Columns(COL_ProjectName).DataField, 2, btnHireInfo)
        'clsCheckValid.MappingColumn(tdbg.Columns(COL_DirectManagerID).DataField, tdbg.Columns(COL_DirectManagerName).DataField, 2, btnHireInfo)
        clsCheckValid.MappingColumn(tdbg.Columns(COL_RecruitmentFileID).DataField, tdbg.Columns(COL_RecruitmentFileName).DataField, 2, btnHireInfo)
        '********************
        dtF12 = Nothing
        CallD99U1111()
        '********************
        EnabledButton(button.HireInfo)
        'usrOption.GetButtonPress(0)
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        InputDateInTrueDBGrid(tdbg, COL_Birthdate, COL_PreparedDate, COL_BeginDate, COL_OfferDate, COL_TrialDateFrom, COL_TrialDateTo)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Quyet_dinh_tuyen_dungF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'QuyÕt ¢Ünh tuyÓn dóng
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Vi_tri") 'Vị trí
        lblFromDate.Text = rl3("Ngay_lap_lich_PV") 'Ngày lập lịch PV
        lblInterviewFileID.Text = rl3("Lich_PV") 'Lịch PV
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnChoose.Text = rl3("Chon_ung__vien") 'Chọn ứng &viên
        btnToEmployeeFiles.Text = rL3("C_huyen_sang_HSNV") 'C&huyển sang HSNV

        'ID 100088 19.09.2017
        'btnPrint.Text = rL3("_In") '&In
        '================================================================ 
        btnPrint.Text = rL3("_InGui_mail") '&In/Gửi mail

        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnHireInfo.Text = rl3("Thong_tin_tuyen_dung") 'Thông tin tuyển dụng
        btnSalaryInfo.Text = rL3("Thong_tin_luong") 'Thông tin lương
        btnSalaryUpdate.Text = rl3("Cap_nhat_thong_so_luong_theo_doi_tuong_tinh_luong") 'Cập nhật thông số lương theo đối tượng tính lương
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcInterviewFileID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcInterviewFileID.Columns("InterviewFileName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbdWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbdWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbdWorkID.Columns("WorkID").Caption = rl3("Ma") 'Mã
        tdbdWorkID.Columns("WorkName").Caption = rl3("Ten") 'Tên
        tdbdDutyID.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbdDutyID.Columns("DutyName").Caption = rl3("Ten") 'Tên
        tdbdStatusID.Columns("StatusID").Caption = rl3("Ma") 'Mã
        tdbdStatusID.Columns("StatusName").Caption = rl3("Ten") 'Tên
        tdbdDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbdDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdSalaryObjectID.Columns("SalaryObjectID").Caption = rl3("Ma") 'Mã
        tdbdSalaryObjectID.Columns("SalaryObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_Approved).Caption = rL3("Duyet") 'Duyệt
        tdbg.Columns(COL_CandidateID).Caption = rL3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_InterviewFileName).Caption = rL3("Lich_PV") 'Lịch PV
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_Birthdate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_ContactAddress).Caption = rL3("Dia_chi") 'Địa chỉ
        tdbg.Columns(COL_Telephone).Caption = rL3("Dien_thoai") 'Điện thoại
        tdbg.Columns(COL_TransferedD09).Caption = rL3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        tdbg.Columns(COL_PreparerID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_PreparedDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_DivisionID).Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_BlockName).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Vi_tri") 'Vị trí
        tdbg.Columns(COL_DutyID).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_DirectManagerID).Caption = rL3("Nguoi_quan_ly_truc_tiep") 'Người quản lý trực tiếp
        tdbg.Columns(COL_BeginDate).Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_WorkingPlace).Caption = rL3("Dia_diem") 'Địa điểm
        tdbg.Columns(COL_WorkingStatusID).Caption = rL3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        tdbg.Columns(COL_WorkingHours).Caption = rL3("Thoi_gian_lam_viec") 'Thời gian làm việc
        tdbg.Columns(COL_TrialPeriod).Caption = rL3("Thoi_gian_thu_viec") 'Thời gian thử việc
        tdbg.Columns(COL_TrialDateFrom).Caption = rL3("Ngay_bat_dau_TV") 'Ngày bắt đầu TV
        tdbg.Columns(COL_TrialDateTo).Caption = rL3("Ngay_ket_thuc_TV") 'Ngày kết thúc TV
        tdbg.Columns(COL_StatusID).Caption = rL3("Trang_thai") 'Trạng thái
        tdbg.Columns(COL_OfferDate).Caption = rL3("Ngay_gui_thu_thu_viec") 'Ngày gửi thư thử việc
        tdbg.Columns(COL_SalaryObjectID).Caption = rL3("Doi_tuong_tinh_luong") 'Đối tượng tính lương
        tdbg.Columns(COL_DetailNotes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_RecruitmentFileName).Caption = rL3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_InterviewFileName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Birthdate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ContactAddress).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Telephone).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Email).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TransferedD09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RecPositionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RecPositionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        If _FormState <> EnumFormState.FormAdd Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Approved).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Approved).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Approved).FetchStyle = False
        End If
    End Sub
    Private Sub LoadDefault()
        c1dateFrom.Value = Now.Date
        c1dateTo.Value = Now.Date
        tdbcDepartmentID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        tdbcInterviewFileID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)
        '  LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)
        ' LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", tdbcDepartmentID.Text, gbUnicode)

        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        sSQL = "SELECT		0 as DisplayOrder,'%' AS RecPositionID, " & sLanguage & " AS RecPositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder,DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionName" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)
        LoadtdbcInterviewFileID()
        'Load tdbcDivisionID
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedIndex = 0 'Value = _divisionID
    End Sub

    Private Sub LoadtdbcInterviewFileID()
        Dim sSQL As String = "-- Combo lịch PV" & vbCrLf
        sSQL &= "SELECT	 '%' AS  VoucherNo, " & AllName & " AS InterviewFileName, '' as InterviewFileID" & vbCrLf & _
            "UNION" & vbCrLf & _
            "SELECT    DISTINCT T10.VoucherNo, T10.InterviewFileName" & UnicodeJoin(gbUnicode) & " AS InterviewFileName, T10.InterviewFileID" & vbCrLf & _
            "FROM        D25T2010  T10 WITH (NOLOCK)" & vbCrLf & _
            "INNER JOIN	D25T2011 T11  WITH (NOLOCK) ON		T10.InterviewFileID=T11.InterviewFileID" & vbCrLf & _
            "WHERE     T10.VoucherDate BETWEEN " & SQLDateSave(c1dateFrom.Value) & " AND " & SQLDateSave(c1dateTo.Value) & vbCrLf & _
            "          	 AND T10.StatusID = 3 AND T11.InterviewLevels  = 'FL'" & vbCrLf & _
            "ORDER BY   InterviewFileID"
        LoadDataSource(tdbcInterviewFileID, sSQL, gbUnicode)
        tdbcInterviewFileID.SelectedIndex = 0
    End Sub

    Dim dtDepartmentID_DD, dtTeamID_DD As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdDivisionID
        sSQL = "Select Distinct T99.DivisionID as DivisionID, T16.DivisionName" & UnicodeJoin(gbUnicode) & " as DivisionName,1 as DisplayOrder" & vbCrLf
        sSQL &= "From D09T9999 T99" & vbCrLf
        sSQL &= "Inner Join D91T0016 T16 On T99.DivisionID = T16.DivisionID" & vbCrLf
        sSQL &= "Inner Join D91T0061 T60 On T99.DivisionID = T60.DivisionID" & vbCrLf
        sSQL &= "Where T16.Disabled = 0 And T60.UserID = 'LEMONADMIN'" & vbCrLf
        sSQL &= "Order By DisplayOrder, DivisionName"
        LoadDataSource(tdbdDivisionID, sSQL, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID_DD = ReturnTableDepartmentID(, False, gbUnicode)

        'Load tdbcTeamID
        dtTeamID_DD = ReturnTableTeamID(, False, gbUnicode)

        'Load tdbdPreparerID
        'LoadDataSource(tdbdPreparerID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadDataSource(tdbdPreparerID, ReturnTableCreateBy(gbUnicode), gbUnicode)

        'Load tdbdWorkingStatusID
        LoadDataSource(tdbdWorkingStatusID, ReturnTableWorkingStatusID(False, gbUnicode), gbUnicode)

        'Load tdbdWorkID
        sSQL = "SELECT WorkID, WorkName" & UnicodeJoin(gbUnicode) & " AS WorkName" & vbCrLf
        sSQL &= "FROM D09T0224  WITH (NOLOCK) WHERE Disabled = 0 ORDER BY 	WorkID"
        LoadDataSource(tdbdWorkID, sSQL, gbUnicode)

        'Load tdbdDutyID
        sSQL = "SELECT DutyID, DutyName" & UnicodeJoin(gbUnicode) & " AS DutyName" & vbCrLf
        sSQL &= "FROM D09T0211  WITH (NOLOCK)  WHERE Disabled = 0 ORDER BY DutyName"
        LoadDataSource(tdbdDutyID, sSQL, gbUnicode)

        sSQL = "SELECT 		'00001' As StatusID, "
        If gbUnicode Or geLanguage = EnumLanguage.English Then
            sSQL &= "N'" & rL3("Dat_co_nhan_viec") & "'"
        Else
            sSQL &= "'Ñaït coù nhaän vieäc'"
        End If
        sSQL &= " As StatusName " & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 	'00002' As StatusID, "
        If gbUnicode Or geLanguage = EnumLanguage.English Then
            sSQL &= "N'" & rL3("Dat_khong_nhan_viec") & "'"
        Else
            sSQL &= "'Ñaït khoâng nhaän vieäc'"
        End If
        sSQL &= " As StatusName " & vbCrLf
        sSQL &= " ORDER BY	StatusID"
        LoadDataSource(tdbdStatusID, sSQL, gbUnicode)

        'Load tdbdSalaryObjectID
        sSQL = "SELECT SalaryObjectID, SalaryObjectName" & UnicodeJoin(gbUnicode) & " as SalaryObjectName" & vbCrLf
        sSQL &= "FROM D13T1020" & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY SalaryObjectID"
        LoadDataSource(tdbdSalaryObjectID, sSQL, gbUnicode)

        'Load tdbdProjectID
        sSQL = "SELECT ProjectID, Description" & UnicodeJoin(gbUnicode) & " As ProjectName" & vbCrLf
        sSQL &= "FROM D09T1080 WITH (NOLOCK)" & vbCrLf
        sSQL &= "  WHERE (Disabled = 0)" & vbCrLf
        sSQL &= "ORDER BY ProjectName"
        LoadDataSource(tdbdProjectID, sSQL, gbUnicode)

        'Thêm 19/05/2015 id 72407
        'Load tdbdDirectManagerID
        sSQL = SQLStoreD09P1508()
        LoadDataSource(tdbdDirectManagerID, sSQL, gbUnicode)


    End Sub

    Private Sub LoadtdbdRecruitmentFileID(ByVal InterviewFileID As String)
        Dim sSQL As String = "--Load dropdown De xuat tuyen dung" & vbCrLf
        '"	SELECT  		T1.TransID,		N'Đề xuất ' + T3.DepartmentNameU + N' từ ngày ' + CONVERT(VARCHAR(10), 			T2.DateFrom, 103) + N' đến '	+  CONVERT(VARCHAR(10), T2.DateTo, 103) AS Description	" & vbCrLf & _
        '                    "FROM 		D25T2040 T1" & vbCrLf & _
        '                    "INNER JOIN 	D25T2001 T2 ON T1.TransID = T2.TransID" & vbCrLf & _
        '                    "INNER JOIN 	D91T0012 T3 ON T1.DepartmentID = T3.DepartmentID" & vbCrLf & _
        '                    "WHERE 		VoucherID = " & SQLString(InterviewFileID)

        sSQL = " SELECT         ID AS TransID, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " AS Description" & vbCrLf
        sSQL &= "FROM             D25N5555('D25F2060', " & SQLString(InterviewFileID) & ", '', '', '', '')"
        LoadDataSource(tdbdRecruitmentFileID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadEdit()
        pnlM.Enabled = False
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        btnChoose.Enabled = False
        LoadTDBGrid()
        tdbg.AllowDelete = False
    End Sub

    Private Sub LoadAdd()
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnPrint.Enabled = False

        btnToEmployeeFiles.Enabled = False
        btnChoose.Enabled = True
        If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2060
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 18/09/2013 03:23:32
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2060(ByVal mode As Object) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrLf)
        sSQL &= "Exec D25P2060 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'FromDate, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'ToDate, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcInterviewFileID)) & COMMA 'InterviewFileID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D25F3060") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[50], NOT NULL
        sSQL &= COMMA & SQLString(_transID)
        sSQL &= COMMA & SQLNumber(mode)
        Return sSQL
    End Function

    'Private Sub LoadTDBGrid()
    '    Dim dtTemp As DataTable = Nothing
    '    Dim sSQL As String = SQLStoreD25P2060(IIf(_FormState = EnumFormState.FormAdd, 0, 1))
    '    If dtGrid Is Nothing Then
    '        dtGrid = ReturnDataTable(sSQL)
    '    Else 'Giữ những dòng đã chọn khi nhấn lọc
    '        dtGrid.DefaultView.RowFilter = "IsUsed =1"
    '        dtGrid = dtGrid.DefaultView.ToTable
    '        If dtGrid.Rows.Count = 0 Then
    '            dtGrid = ReturnDataTable(sSQL)
    '        Else
    '            dtTemp = ReturnDataTable(sSQL)
    '            If dtTemp.Rows.Count > 0 Then
    '                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("CandidateID"), dtGrid.Columns("InterviewFileID")}
    '                dtGrid.Merge(dtTemp, True, MissingSchemaAction.AddWithKey)
    '            End If
    '        End If
    '    End If
    '    'dtGrid = ReturnTableFilter(dtD25F3060.Copy, "TransID=" & SQLString(_transID))
    '    gbEnabledUseFind = dtGrid.Rows.Count > 0
    '    LoadDataSource(tdbg, dtGrid, gbUnicode)
    '    ResetGrid()
    'End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P2060(IIf(_FormState = EnumFormState.FormAdd, 0, 1))
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dtTemp
        Else
            dtGrid = ReturnTableFilter(dtGrid, tdbg.Columns(COL_IsUsed).DataField & "=1")
            dtTemp.PrimaryKey = New DataColumn() {dtTemp.Columns("CandidateID"), dtTemp.Columns("InterviewFileID")}
            dtGrid.Merge(dtTemp, True, MissingSchemaAction.AddWithKey)
        End If

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dr() As DataRow = dtGrid.Select("IsUsed=1")
        If dr.Length <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim SQLD09T6666 As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If dr(i).Item("PreparerID").ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Nguoi_lap"))
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_PreparerID
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                tdbg.Focus()
                Return False
            End If
            If dr(i).Item("PreparedDate").ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay_lap"))
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_PreparedDate
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                tdbg.Focus()
                Return False
            End If
            If Not clsCheckValid.CheckEmpty(i) Then Return False
            '======================================
            If dr(i).Item("BeginDate").ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay_vao_lam"))
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_BeginDate
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                tdbg.Focus()
                Return False
            End If
            SQLD09T6666.Append(SQLInsertD09T6666(dr(i), Me.Name))
            SQLD09T6666.Append(vbCrLf)
        Next

        If SQLD09T6666.Length > 0 Then
            SQLD09T6666.Insert(0, SQLDeleteD09T6666(Me.Name) & vbCrLf)
            SQLD09T6666.Append(SQLStoreD25P5555(0, 0, Me.Name, "Kiem tra du lieu"))
            If Not CheckStore(SQLD09T6666.ToString) Then Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T2061s().ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T2061s.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnClose.Focus()
            _bSaved = True
            EnabledButton()

            _transID = tdbg.Columns(COL_TransID).Text

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnPrint.Enabled = True
                    btnNext.Enabled = True
                    btnChoose.Enabled = False
                    btnNext.Focus()

                Case EnumFormState.FormEdit
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        If dtGrid IsNot Nothing Then
            dtGrid.Clear()
            ResetGrid()
        End If
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        '************************
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", "D15F3060")
        Dim frm As Form = Me

        CallFormShowDialog("D25D0240", "D25F5600", arrPro)
        Dim dtTemp As DataTable = CType(GetProperties(frm, "DataTableGrid"), DataTable)
        If dtTemp IsNot Nothing Then
            If dtTemp.Rows.Count > 0 Then
                dtGrid = dtTemp.DefaultView.ToTable
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                ResetGrid()
            End If
        End If
    End Sub

    Private Sub btnToEmployeeFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToEmployeeFiles.Click
        Dim sSQL As String = SQLInsertD09T6666s.ToString
        Dim bRunSQL As Boolean = ExecuteSQLNoTransaction(sSQL)

        If bRunSQL Then
            Dim f As New D25F2053

            Select Case _FormState
                Case EnumFormState.FormAdd
                    If _bSaved Then f.IsOnlyView = False Else f.IsOnlyView = True
                Case EnumFormState.FormEdit
                    f.IsOnlyView = False
                Case EnumFormState.FormView
                    f.IsOnlyView = True
            End Select

            f.TransID = "%"
            f.Mode = 0
            f.ShowDialog()
            Dim bClose As Boolean = f.bClose
            f.Dispose()

            If bClose Then Me.Close()
        End If
    End Sub

    Private Function AllowPrinr(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        dr = dtGrid.Select("IsUsed = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Row = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dr() As DataRow = Nothing
        If Not AllowPrinr(dr) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.AppendLine(SQLDeleteD09T6666)
        sSQL.AppendLine(SQLInsertD09T6666s(dr).ToString)

        If Not ExecuteSQL(sSQL.ToString) Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim arrPro() As StructureProperties = Nothing

        'id 71427 12/6/2015
        SetProperties(arrPro, "DivisionID", ReturnValueC1Combo(tdbcDivisionID))
        SetProperties(arrPro, "InterviewFileID", ReturnValueC1Combo(tdbcInterviewFileID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        'Kim Yến yêu cầu
        SetProperties(arrPro, "DateFrom", c1dateFrom.Text)
        SetProperties(arrPro, "DateTo", c1dateTo.Text)
        SetProperties(arrPro, "FormCall", "D25F3060")
        CallFormShow(Me, "D25D0340", "D25F4080", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EnabledButton()
        Dim dt As DataTable = CType(tdbg.DataSource, DataTable)
        Dim dr() As DataRow = dt.Select("Approved= True")
        If dr.Length > 0 Then
            btnToEmployeeFiles.Enabled = True
        Else
            btnToEmployeeFiles.Enabled = False
        End If
    End Sub

    Private Sub VisibleBlock()
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            tdbg.Splits(2).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(2).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub CalTrialPeriod()
        If tdbg.Columns(COL_TrialDateFrom).Text <> "" AndAlso tdbg.Columns(COL_TrialDateTo).Text <> "" Then
            'Số tháng thử việc =  Round((Thời gian thử việc đến - Thời gian thử việc từ)/30 , 0)
            Dim iDay As Long = DateDiff(DateInterval.Day, CDate(tdbg.Columns(COL_TrialDateFrom).Text), CDate(tdbg.Columns(COL_TrialDateTo).Text))
            tdbg.Columns(COL_TrialPeriod).Text = Math.Round(iDay / 30, 0, MidpointRounding.AwayFromZero).ToString
        Else
            If tdbg.Columns(COL_TrialPeriod).Text <> "" Then 'Tính lại ngay tu hoac ngay den
                CalTrialDate()
            End If
        End If
    End Sub

    Private Sub CalTrialDate()
        '**************************************
        If tdbg.Columns(COL_TrialDateFrom).Text = "" AndAlso tdbg.Columns(COL_TrialDateTo).Text = "" Then Exit Sub
        '*******************************
        Dim dDate As Date
        If tdbg.Columns(COL_TrialDateFrom).Text <> "" Then 'Tính lại ngày đến
            'Thời gian thử việc đến = (Thời gian thử việc từ + Số tháng thử việc) – 1(ngày)
            dDate = DateAdd(DateInterval.Month, Number(tdbg.Columns(COL_TrialPeriod).Text), CDate(tdbg.Columns(COL_TrialDateFrom).Text))
            tdbg.Columns(COL_TrialDateTo).Text = SQLDateShow(DateAdd(DateInterval.Day, -1, dDate))
        Else 'Tính lại ngày từ
            'Thời gian thử việc từ = (Thời gian thử việc đến - Số tháng thử việc) + 1(ngày)
            dDate = DateAdd(DateInterval.Month, -Number(tdbg.Columns(COL_TrialPeriod).Text), CDate(tdbg.Columns(COL_TrialDateTo).Text))
            tdbg.Columns(COL_TrialDateFrom).Text = SQLDateShow(DateAdd(DateInterval.Day, 1, dDate))
        End If
    End Sub

#Region "tdbg"

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub
    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DepartmentName, COL_TeamName, COL_RecruitmentFileName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_PreparerID, COL_DivisionID, COL_DutyID, COL_WorkID, COL_ProjectID, COL_DirectManagerID, COL_WorkingStatusID, COL_StatusID, COL_N01ID To COL_N20ID, COL_SalaryObjectID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_IsUsed
                If L3Bool(tdbg.Columns(e.ColIndex).Text) = False Then tdbg.Columns(COL_Approved).Text = "0"
            Case COL_DivisionID
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_DepartmentName
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
            Case COL_Birthdate, COL_PreparedDate
                tdbg.Select()
            Case COL_PreparerID, COL_DutyID, COL_WorkID, COL_ProjectID, COL_DirectManagerID, COL_WorkingStatusID, COL_StatusID, COL_SalaryObjectID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_BeginDate 'Ngày vào làm
                If Number(tdbg.Columns(COL_TrialPeriod).Text) <> 0 Then
                    tdbg.Columns(COL_TrialDateFrom).Text = tdbg.Columns(COL_BeginDate).Text
                    CalTrialDate()
                End If
            Case COL_TrialPeriod
                If tdbg.Columns(COL_TrialPeriod).Text <> "" Then
                    tdbg.Columns(COL_TrialDateFrom).Text = tdbg.Columns(COL_BeginDate).Text
                    CalTrialDate()
                End If
                If tdbg.Columns(COL_TrialDateFrom).Text = "" AndAlso tdbg.Columns(COL_TrialDateTo).Text = "" AndAlso Number(tdbg.Columns(COL_TrialPeriod).Text) <> 0 Then
                    tdbg.Columns(COL_TrialDateFrom).Text = tdbg.Columns(COL_BeginDate).Text
                    CalTrialDate()
                End If
                If Number(tdbg.Columns(COL_TrialPeriod).Text) = 0 Then
                    tdbg.Columns(COL_TrialDateFrom).Text = ""
                    tdbg.Columns(COL_TrialDateTo).Text = ""
                End If
            Case COL_TrialDateFrom
                If tdbg.Columns(COL_TrialDateFrom).Text <> "" Then
                    tdbg.Columns(COL_BeginDate).Text = tdbg.Columns(COL_TrialDateFrom).Text
                    CalTrialPeriod()
                End If
            Case COL_RecruitmentFileName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecruitmentFileID).Text = ""
                    tdbg.Columns(COL_RecruitmentFileName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecruitmentFileID).Text = tdbdRecruitmentFileID.Columns("TransID").Text
                tdbg.Columns(COL_RecruitmentFileName).Text = tdbdRecruitmentFileID.Columns("Description").Text
            Case COL_TrialDateTo
                If tdbg.Columns(COL_TrialDateTo).Text <> "" Then CalTrialPeriod()
                'ID 81044 29/10/2015
                'Case COL_N01Name To COL_N20Name
                '    If tdbg.Columns(e.ColIndex).Text = "" Then
                '        tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = ""
                '        Exit Sub
                '    End If
                '    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = tdbg.Columns(e.ColIndex).DropDown.Columns(0).Text

                '    If tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = "+" Then
                '        tdbg.Columns(e.ColIndex).Text = ""
                '        tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = ""

                '        If ReturnPermission("D09F1010") < EnumPermission.Add Then
                '            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi"))
                '        Else
                '            Dim arrPro() As StructureProperties = Nothing
                '            SetProperties(arrPro, "TypeID", tdbg.Columns(tdbg.Col).DataField.Substring(3, 3))
                '            SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                '            Dim frm As Form = CallFormShowDialog("D09D0140", "D09F1011", arrPro)
                '            If L3Bool(GetProperties(frm, "bSaved")) Then
                '                Dim sOutput01 As String = GetProperties(frm, "NCodeID").ToString
                '                LoadTableNCodeID()
                '                Dim tdbdX As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(e.ColIndex).DropDown
                '                LoadTdbdNCodeID(tdbdX)
                '                tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = sOutput01
                '                tdbg.Columns(e.ColIndex).Text = ReturnValueC1DropDown(tdbdX, "Description", "NCodeID=" & SQLString(sOutput01)) 'GetValueDropdown(tdbdX, "NCodeID", sOutput01, "Description")
                '            End If
                '        End If
                '    End If
            Case COL_N01ID To COL_N20ID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
                If tdbg.Columns(e.ColIndex).Value.ToString = "+" Then
                    tdbg.Columns(e.ColIndex).Value = ""
                    If ReturnPermission("D09F1010") < EnumPermission.Add Then
                        D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi"))
                    Else
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "TypeID", tdbg.Columns(e.ColIndex).DataField.Substring(3, 3))
                        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F1011", arrPro)
                        If L3Bool(GetProperties(frm, "bSaved")) Then
                            Dim sOutput01 As String = GetProperties(frm, "NCodeID").ToString
                            LoadTableNCodeID()
                            LoadTdbdNCodeID(tdbg.Columns(e.ColIndex).DropDown)
                            tdbg.Columns(e.ColIndex).Value = sOutput01
                        End If
                    End If
                End If
        End Select
        '**************************
        If tdbg.Columns(e.ColIndex).DropDown IsNot Nothing AndAlso tdbg.Columns(e.ColIndex).DropDown.ValueTranslate Then 'ID 86394 28/04/2016
            Dim sFieldName As String = ""
            If tdbg.Columns(e.ColIndex).DataField = "Sex" Then
                sFieldName = "SexName"
            Else
                sFieldName = tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")
            End If
            If tdbg.Columns(e.ColIndex).Text = "" Then
                dtGrid.DefaultView(tdbg.Bookmark).Item(sFieldName) = ""
            Else
                dtGrid.DefaultView(tdbg.Bookmark).Item(sFieldName) = tdbg.Columns(e.ColIndex).Text
            End If
        End If
        '**************************
        tdbg.UpdateData()
        ResetGrid()
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.FilterActive Then HotKeyCtrlVOnGrid(tdbg, e) : Exit Sub

        Select Case tdbg.Col
            Case COL_PreparerID, COL_DutyID, COL_WorkID, COL_ProjectID, COL_DirectManagerID, COL_WorkingStatusID, COL_StatusID, COL_SalaryObjectID
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg)
            Case Keys.F8
                HotKeyF8(tdbg)
            Case Keys.Enter
                If tdbg.Col = COL_TrialPeriod Then
                    HotKeyEnterGrid(tdbg, COL_Approved, e, SPLIT0)
                End If
        End Select
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_Approved, 0, 2)
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        If tdbg.Columns(tdbg.Col).DropDown IsNot Nothing Then
            tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Button = L3Bool(tdbg.Columns(COL_IsUsed).Text)
            tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).AutoDropDown = Not tdbg.FilterActive
            tdbg.UpdateData()
        End If

        Select Case tdbg.Col
            'Case COL_DivisionID, COL_DutyID, COL_PreparerID, COL_WorkID, COL_WorkingStatusID, COL_StatusID, COL_SalaryObjectID, COL_ProjectID, COL_DirectManagerID, COL_N01ID To COL_N20ID
            '    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = (L3Bool(tdbg(tdbg.Row, COL_IsUsed).ToString) = True)
            '    tdbg.UpdateData()
            Case COL_DepartmentName
                LoadtdbdDepartmentID(tdbdDepartmentID, dtDepartmentID_DD, "%", tdbg(tdbg.Row, COL_DivisionID).ToString, gbUnicode)
                'tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = (L3Bool(tdbg(tdbg.Row, COL_IsUsed).ToString) = True)
                'tdbg.UpdateData()
            Case COL_TeamName
                LoadtdbdTeamID(tdbdTeamID, dtTeamID_DD, "%", tdbg(tdbg.Row, COL_DepartmentID).ToString, tdbg(tdbg.Row, COL_DivisionID).ToString, gbUnicode)
                'tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = (L3Bool(tdbg(tdbg.Row, COL_IsUsed).ToString) = True)
                'tdbg.UpdateData()
            Case COL_RecruitmentFileName
                ' tdbg.Splits(tdbg.SplitIndex).DisplayColumns(COL_RecruitmentFileName).Button = L3Bool(tdbg(tdbg.Row, COL_IsUsed))
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(COL_RecruitmentFileName).Button Then LoadtdbdRecruitmentFileID(L3String(tdbg(tdbg.Row, COL_InterviewFileID)))
        End Select
    End Sub
    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_Approved
                If iPerD25F2100 < 2 Then e.CellStyle.Locked = True
            Case COL_DivisionID, COL_DepartmentName, COL_TeamName, COL_DutyID, COL_PreparerID, COL_WorkID, COL_WorkingStatusID, COL_StatusID, COL_SalaryObjectID, COL_ProjectID, COL_DirectManagerID, COL_N01ID To COL_N20ID
                If L3Bool(tdbg(e.Row, COL_IsUsed).ToString) <> True Then
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    e.CellStyle.Locked = True
                End If
        End Select
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
#End Region

    Dim bSelect As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        tdbg.AllowSort = False
        Select Case iCol
            Case COL_IsUsed
                L3HeadClick(tdbg, iCol, bSelect)
            Case COL_Approved
                L3HeadClick(tdbg, iCol, bSelect, COL_IsUsed, "True")
            Case COL_PreparerID, COL_DutyID, COL_WorkID, COL_ProjectID, COL_DirectManagerID, COL_WorkingStatusID, COL_StatusID, COL_SalaryObjectID, COL_N01ID To COL_N20ID
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row, COL_IsUsed, "True")
            Case COL_RecruitmentFileName
                CopyColumns_RecruitmentFileID(tdbg, tdbg.Columns(iCol).Text, tdbg.Row, COL_IsUsed, "True")
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub
    Private Sub CopyColumns_RecruitmentFileID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sValue As String, ByVal RowCopy As Int32, ByVal Col_Where As Integer, ByVal sValueWhere As String)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(COL_RecruitmentFileName).Locked Then Exit Sub

            sValue = c1Grid(RowCopy, COL_RecruitmentFileName).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, Col_Where).ToString <> sValueWhere Then Continue For
                    If L3String(c1Grid(i, COL_InterviewFileID)) <> L3String(c1Grid(RowCopy, COL_InterviewFileID)) Then Continue For
                    If c1Grid(i, COL_RecruitmentFileName).ToString = "" OrElse c1Grid(i, COL_RecruitmentFileName).ToString = MaskFormatDateShort OrElse c1Grid(i, COL_RecruitmentFileName).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, COL_RecruitmentFileName).ToString) And Number(c1Grid(i, COL_RecruitmentFileName).ToString) = 0) Then
                        c1Grid(i, COL_RecruitmentFileName) = sValue
                        c1Grid(i, COL_RecruitmentFileID) = c1Grid(RowCopy, COL_RecruitmentFileID)
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, Col_Where).ToString <> sValueWhere Then Continue For
                    If L3String(c1Grid(i, COL_InterviewFileID)) <> L3String(c1Grid(RowCopy, COL_InterviewFileID)) Then Continue For
                    c1Grid(i, COL_RecruitmentFileName) = sValue
                    c1Grid(i, COL_RecruitmentFileID) = c1Grid(RowCopy, COL_RecruitmentFileID)
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32, ByVal Col_Where As Integer, ByVal sValueWhere As String)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(ColCopy).Locked Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, Col_Where).ToString <> sValueWhere Then Continue For
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, Col_Where).ToString <> sValueWhere Then Continue For
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True, Optional ByVal iButton As Object = 0)
        'Dim arrColObligatory() As Object = {COL_Approved, COL_CandidateID, COL_IsUsed}
        'usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        'If usrOption IsNot Nothing Then usrOption.Dispose()
        'usrOption = New D99U1111(Me, tdbg, dtF12)
        Dim arrColObligatory() As Object = {COL_Approved, COL_IsUsed}
        Dim arrColObligatory1() As Object = {COL_CandidateID}
        If bLoad Then
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, , arrColObligatory, COL_IsUsed, COL_Approved) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, , arrColObligatory1, COL_CandidateID, COL_TransferedD09) 'split0
            usrOption.AddColVisible(tdbg, SPLIT2, dtF12, , , COL_PreparerID, COL_RecruitmentFileName, , 0) 'split1
            usrOption.AddColVisible(tdbg, SPLIT2, dtF12, , , COL_SalaryObjectID, COL_DetailNotes, , 1) 'split2
            ''************Sử dụng nhóm kho
            'usrOption.EditModeColVisible(dtF12, 1, "PreparerID", "DetailNotes")
            ''************Không sử dụng nhóm kho
            'usrOption.EditModeColVisible(dtF12, iMode, "PreparerID", "DetailNotes")
            ''****************************
        End If
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, , , , iButton)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2061s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 05/01/2011 04:23:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2061s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim sTransID As String = ""
        Dim iCountIGE As Integer = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" And L3Bool(tdbg(i, COL_IsUsed)) Then
                iCountIGE += 1
            End If
        Next i

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) = False Then Continue For
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D25T2061", "TransID", "25", "TD", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D25T2061(")
            sSQL.Append("TransID, CandidateID, DepartmentID, TeamID, PositionID, TransferedD09, ")
            sSQL.Append("WorkingHours, WorkingHoursU, BlockID, ")
            sSQL.Append("TrialPeriod, LastModifyUserID, LastModifyDate, ")
            sSQL.Append("Approved, PreparerID, PreparedDate, WorkID, DutyID, ")
            sSQL.Append("BeginDate, WorkingStatusID, StatusID, WorkingPlace, WorkingPlaceU, CreateUserID, CreateDate, DivisionID,  OfferDate, RecruitmentFileID, InterviewFileID, ")
            sSQL.Append("SalaryObjectID, BaseSalary01, BaseSalary02, BaseSalary03, BaseSalary04, ")
            sSQL.Append("SalCoefficient01, SalCoefficient02, SalCoefficient03, SalCoefficient04, SalCoefficient05, ")
            sSQL.Append("SalCoefficient06, SalCoefficient07, SalCoefficient08, SalCoefficient09, SalCoefficient10, ")
            sSQL.Append("SalCoefficient11, SalCoefficient12, SalCoefficient13, SalCoefficient14, SalCoefficient15, ")
            sSQL.Append("SalCoefficient16, SalCoefficient17, SalCoefficient18, SalCoefficient19, SalCoefficient20, ")
            sSQL.Append("ProjectID, DirectManagerID, DetailNotes, DetailNotesU, TrialDateFrom, TrialDateTo,")

            'ID 81044 28/10/2015
            sSQL.Append("N01ID, N02ID, N03ID, N04ID, N05ID, N06ID, N07ID, N08ID, N09ID, N10ID,")
            sSQL.Append("N11ID, N12ID, N13ID, N14ID, N15ID, N16ID, N17ID, N18ID, N19ID, N20ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DutyID)) & COMMA) 'PositionID, varchar[20], NOT NULL			
            sSQL.Append(SQLNumber(tdbg(i, COL_TransferedD09)) & COMMA) 'TransferedD09, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_WorkingHours), gbUnicode, False) & COMMA) 'WorkingHours, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_WorkingHours), gbUnicode, True) & COMMA) 'WorkingHoursU, varchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL

            'ID 76007 05/08/2015
            sSQL.Append(SQLNumber(tdbg(i, COL_TrialPeriod)) & COMMA) 'TrialPeriod, int, NOT NULL
            'sSQL.Append(SQLStringUnicode(tdbg(i, COL_TrialPeriod), gbUnicode, False) & COMMA) 'TrialPeriod, varchar[500], NOT NULL
            'sSQL.Append(SQLStringUnicode(tdbg(i, COL_TrialPeriod), gbUnicode, True) & COMMA) 'TrialPeriodU, varchar[500], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Approved)) & COMMA) 'Approved, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PreparerID)) & COMMA) 'PreparerID, varchar[50], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_PreparedDate)) & COMMA) 'PreparedDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_WorkID)) & COMMA) 'WorkID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DutyID)) & COMMA) 'DuyID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_BeginDate)) & COMMA) 'BeginDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_WorkingStatusID)) & COMMA) 'WorkingStatusID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StatusID)) & COMMA) 'StatusID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_WorkingPlace), gbUnicode, False) & COMMA) 'WorkingPlace, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_WorkingPlace), gbUnicode, True) & COMMA) 'WorkingPlaceU, varchar[250], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DivisionID)) & COMMA) 'StatusID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_OfferDate)) & COMMA) 'BeginDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecruitmentFileID)) & COMMA) 'InterviewFileID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InterviewFileID)) & COMMA) 'InterviewFileID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_SalaryObjectID)) & COMMA) 'SalaryObjectID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary01), tdbg.Columns(COL_BaseSalary01).NumberFormat) & COMMA) 'BaseSalary01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary02), tdbg.Columns(COL_BaseSalary02).NumberFormat) & COMMA) 'BaseSalary02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary03), tdbg.Columns(COL_BaseSalary03).NumberFormat) & COMMA) 'BaseSalary03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary04), tdbg.Columns(COL_BaseSalary04).NumberFormat) & COMMA) 'BaseSalary04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient01), tdbg.Columns(COL_SalCoefficient01).NumberFormat) & COMMA) 'SalCoefficient01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient02), tdbg.Columns(COL_SalCoefficient02).NumberFormat) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient03), tdbg.Columns(COL_SalCoefficient03).NumberFormat) & COMMA) 'SalCoefficient03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient04), tdbg.Columns(COL_SalCoefficient04).NumberFormat) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient05), tdbg.Columns(COL_SalCoefficient05).NumberFormat) & COMMA) 'SalCoefficient05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient06), tdbg.Columns(COL_SalCoefficient06).NumberFormat) & COMMA) 'SalCoefficient06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient07), tdbg.Columns(COL_SalCoefficient07).NumberFormat) & COMMA) 'SalCoefficient07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient08), tdbg.Columns(COL_SalCoefficient08).NumberFormat) & COMMA) 'SalCoefficient08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient09), tdbg.Columns(COL_SalCoefficient09).NumberFormat) & COMMA) 'SalCoefficient09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient10), tdbg.Columns(COL_SalCoefficient10).NumberFormat) & COMMA) 'SalCoefficient10, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient11), tdbg.Columns(COL_SalCoefficient11).NumberFormat) & COMMA) 'SalCoefficient11, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient12), tdbg.Columns(COL_SalCoefficient12).NumberFormat) & COMMA) 'SalCoefficient12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient13), tdbg.Columns(COL_SalCoefficient13).NumberFormat) & COMMA) 'SalCoefficient13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient14), tdbg.Columns(COL_SalCoefficient14).NumberFormat) & COMMA) 'SalCoefficient14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient15), tdbg.Columns(COL_SalCoefficient15).NumberFormat) & COMMA) 'SalCoefficient15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient16), tdbg.Columns(COL_SalCoefficient16).NumberFormat) & COMMA) 'SalCoefficient16, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient17), tdbg.Columns(COL_SalCoefficient17).NumberFormat) & COMMA) 'SalCoefficient17, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient18), tdbg.Columns(COL_SalCoefficient18).NumberFormat) & COMMA) 'SalCoefficient18, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient19), tdbg.Columns(COL_SalCoefficient19).NumberFormat) & COMMA) 'SalCoefficient19, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient20), tdbg.Columns(COL_SalCoefficient20).NumberFormat) & COMMA) 'SalCoefficient20, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DirectManagerID)) & COMMA) 'DirectManagerID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DetailNotes), gbUnicode, False) & COMMA) 'DetailNotes, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DetailNotes), gbUnicode, True) & COMMA) 'DetailNotesU, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_TrialDateFrom)) & COMMA) 'TrialDateFrom, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_TrialDateTo)) & COMMA) 'TrialDateTo, datetime, NOT NULL


            'ID 81044 28/10/2015
            sSQL.Append(SQLString(tdbg(i, COL_N01ID)) & COMMA) 'N01ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N02ID)) & COMMA) 'N02ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N03ID)) & COMMA) 'N03ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N04ID)) & COMMA) 'N04ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N05ID)) & COMMA) 'N05ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N06ID)) & COMMA) 'N06ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N07ID)) & COMMA) 'N07ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N08ID)) & COMMA) 'N08ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N09ID)) & COMMA) 'N09ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N10ID)) & COMMA) 'N10ID, varchar[20], NOT NULL

            sSQL.Append(SQLString(tdbg(i, COL_N11ID)) & COMMA) 'N11ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N12ID)) & COMMA) 'N12ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N13ID)) & COMMA) 'N13ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N14ID)) & COMMA) 'N14ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N15ID)) & COMMA) 'N15ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N16ID)) & COMMA) 'N16ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N17ID)) & COMMA) 'N17ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N18ID)) & COMMA) 'N18ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N19ID)) & COMMA) 'N19ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_N20ID))) 'N20ID, varchar[20], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2061s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/01/2011 10:49:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2061s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) = False Then Continue For
            sSQL.Append("Update D25T2061 Set ")
            sSQL.Append("DivisionID = " & SQLString(tdbg(i, COL_DivisionID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("BlockID = " & SQLString(tdbg(i, COL_BlockID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DepartmentID = " & SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("TeamID = " & SQLString(tdbg(i, COL_TeamID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("PositionID = " & SQLString(tdbg(i, COL_DutyID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("PreparerID = " & SQLString(tdbg(i, COL_PreparerID)) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("PreparedDate = " & SQLDateSave(tdbg(i, COL_PreparedDate)) & COMMA) 'datetime, NOT NULL
            sSQL.Append("WorkID = " & SQLString(tdbg(i, COL_WorkID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DutyID = " & SQLString(tdbg(i, COL_DutyID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("BeginDate = " & SQLDateSave(tdbg(i, COL_BeginDate)) & COMMA) 'datetime, NOT NULL
            sSQL.Append("OfferDate = " & SQLDateSave(tdbg(i, COL_OfferDate)) & COMMA) 'datetime, NOT NULL
            sSQL.Append("RecruitmentFileID = " & SQLString(tdbg(i, COL_RecruitmentFileID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("WorkingPlace = " & SQLStringUnicode(tdbg(i, COL_WorkingPlace), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("WorkingPlaceU = " & SQLStringUnicode(tdbg(i, COL_WorkingPlace), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("WorkingStatusID = " & SQLString(tdbg(i, COL_WorkingStatusID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("WorkingHours = " & SQLStringUnicode(tdbg(i, COL_WorkingHours), gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
            sSQL.Append("WorkingHoursU = " & SQLStringUnicode(tdbg(i, COL_WorkingHours), gbUnicode, True) & COMMA) 'varchar[500], NOT NULL

            'ID 76007 05/08/2015
            sSQL.Append("TrialPeriod = " & SQLNumber(tdbg(i, COL_TrialPeriod)) & COMMA) 'int, NOT NULL
            'sSQL.Append("TrialPeriod = " & SQLStringUnicode(tdbg(i, COL_TrialPeriod), gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
            ' sSQL.Append("TrialPeriodU = " & SQLStringUnicode(tdbg(i, COL_TrialPeriod), gbUnicode, True) & COMMA) 'varchar[500], NOT NULL
            sSQL.Append("StatusID = " & SQLString(tdbg(i, COL_StatusID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("InterviewFileID = " & SQLString(tdbg(i, COL_InterviewFileID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("SalaryObjectID = " & SQLString(tdbg(i, COL_SalaryObjectID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("BaseSalary01 = " & SQLMoney(tdbg(i, COL_BaseSalary01), tdbg.Columns(COL_BaseSalary01).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("BaseSalary02 = " & SQLMoney(tdbg(i, COL_BaseSalary02), tdbg.Columns(COL_BaseSalary02).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("BaseSalary03 = " & SQLMoney(tdbg(i, COL_BaseSalary03), tdbg.Columns(COL_BaseSalary03).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("BaseSalary04 = " & SQLMoney(tdbg(i, COL_BaseSalary04), tdbg.Columns(COL_BaseSalary04).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient01 = " & SQLMoney(tdbg(i, COL_SalCoefficient01), tdbg.Columns(COL_SalCoefficient01).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient02 = " & SQLMoney(tdbg(i, COL_SalCoefficient02), tdbg.Columns(COL_SalCoefficient02).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient03 = " & SQLMoney(tdbg(i, COL_SalCoefficient03), tdbg.Columns(COL_SalCoefficient03).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient04 = " & SQLMoney(tdbg(i, COL_SalCoefficient04), tdbg.Columns(COL_SalCoefficient04).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient05 = " & SQLMoney(tdbg(i, COL_SalCoefficient05), tdbg.Columns(COL_SalCoefficient05).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient06 = " & SQLMoney(tdbg(i, COL_SalCoefficient06), tdbg.Columns(COL_SalCoefficient06).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient07 = " & SQLMoney(tdbg(i, COL_SalCoefficient07), tdbg.Columns(COL_SalCoefficient07).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient08 = " & SQLMoney(tdbg(i, COL_SalCoefficient08), tdbg.Columns(COL_SalCoefficient08).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient09 = " & SQLMoney(tdbg(i, COL_SalCoefficient09), tdbg.Columns(COL_SalCoefficient09).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient10 = " & SQLMoney(tdbg(i, COL_SalCoefficient10), tdbg.Columns(COL_SalCoefficient10).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient11 = " & SQLMoney(tdbg(i, COL_SalCoefficient11), tdbg.Columns(COL_SalCoefficient11).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient12 = " & SQLMoney(tdbg(i, COL_SalCoefficient12), tdbg.Columns(COL_SalCoefficient12).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient13 = " & SQLMoney(tdbg(i, COL_SalCoefficient13), tdbg.Columns(COL_SalCoefficient13).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient14 = " & SQLMoney(tdbg(i, COL_SalCoefficient14), tdbg.Columns(COL_SalCoefficient14).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient15 = " & SQLMoney(tdbg(i, COL_SalCoefficient15), tdbg.Columns(COL_SalCoefficient15).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient16 = " & SQLMoney(tdbg(i, COL_SalCoefficient16), tdbg.Columns(COL_SalCoefficient16).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient17 = " & SQLMoney(tdbg(i, COL_SalCoefficient17), tdbg.Columns(COL_SalCoefficient17).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient18 = " & SQLMoney(tdbg(i, COL_SalCoefficient18), tdbg.Columns(COL_SalCoefficient18).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient19 = " & SQLMoney(tdbg(i, COL_SalCoefficient19), tdbg.Columns(COL_SalCoefficient19).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("SalCoefficient20 = " & SQLMoney(tdbg(i, COL_SalCoefficient20), tdbg.Columns(COL_SalCoefficient20).NumberFormat) & COMMA) 'decimal, NOT NULL
            sSQL.Append("ProjectID = " & SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DirectManagerID = " & SQLString(tdbg(i, COL_DirectManagerID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DetailNotes = " & SQLStringUnicode(tdbg(i, COL_DetailNotes), gbUnicode, False) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DetailNotesU = " & SQLStringUnicode(tdbg(i, COL_DetailNotes), gbUnicode, True) & COMMA) 'varchar[20], NOT NULL
            '
            sSQL.Append("TrialDateFrom = " & SQLDateSave(tdbg(i, COL_TrialDateFrom)) & COMMA) 'datetime, NOT NULL
            sSQL.Append("TrialDateTo = " & SQLDateSave(tdbg(i, COL_TrialDateTo)) & COMMA) 'datetime, NOT NULL

            'ID 81044 28/10/2015
            sSQL.Append("N01ID = " & SQLString(tdbg(i, COL_N01ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N02ID = " & SQLString(tdbg(i, COL_N02ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N03ID = " & SQLString(tdbg(i, COL_N03ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N04ID = " & SQLString(tdbg(i, COL_N04ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N05ID = " & SQLString(tdbg(i, COL_N05ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N06ID = " & SQLString(tdbg(i, COL_N06ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N07ID = " & SQLString(tdbg(i, COL_N07ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N08ID = " & SQLString(tdbg(i, COL_N08ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N09ID = " & SQLString(tdbg(i, COL_N09ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N10ID = " & SQLString(tdbg(i, COL_N10ID)) & COMMA) 'varchar[20], NOT NULL

            sSQL.Append("N11ID = " & SQLString(tdbg(i, COL_N11ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N12ID = " & SQLString(tdbg(i, COL_N12ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N13ID = " & SQLString(tdbg(i, COL_N13ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N14ID = " & SQLString(tdbg(i, COL_N14ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N15ID = " & SQLString(tdbg(i, COL_N15ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N16ID = " & SQLString(tdbg(i, COL_N16ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N17ID = " & SQLString(tdbg(i, COL_N17ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N18ID = " & SQLString(tdbg(i, COL_N18ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N19ID = " & SQLString(tdbg(i, COL_N19ID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("N20ID = " & SQLString(tdbg(i, COL_N20ID))) 'varchar[20], NOT NULL

            sSQL.Append(" Where TransID = " & SQLString(tdbg(i, COL_TransID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 12/01/2011 03:23:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dr() As DataRow = dtGrid.Select("Approved = True")

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("TransID").ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("CandidateID").ToString)) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus, tdbcRecPositionID.LostFocus, tdbcInterviewFileID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", tdbcDepartmentID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcRecPositionID.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcRecPositionID.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        Dim arrColObligatory() As Integer = {COL_CandidateID, COL_Approved, COL_IsUsed}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region
    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If chkIsUsed.Checked Then
            strFind = "IsUsed=True"
        Else
            If strFind <> "" Then strFind = "IsUsed=True" & " Or " & strFind
        End If

        dtGrid.DefaultView.RowFilter = strFind '.Replace("StatusID", "StatusName")
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        mnsFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnsListAll.Enabled = mnsFind.Enabled
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateFrom, c1dateTo) Then Return False
        If tdbcInterviewFileID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Lich_PV"))
            tdbcInterviewFileID.Focus()
            Return False
        End If
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
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

    Dim dtValidMode As DataTable 'Bảng lưu các trường có kiểm tra bắt buộc nhập or Cảnh báo
    Private Sub SetBackColorObligatory()
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcInterviewFileID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_PreparerID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_PreparedDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_BeginDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
        If Not AllowFilter() Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Sub c1dateFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateFrom.Validated, c1dateTo.Validated
        LoadtdbcInterviewFileID()
    End Sub

    Private Sub chkShowSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub

#End Region

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_TrialPeriod).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary01).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary02).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary03).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary04).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient01).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient02).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient03).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient04).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient05).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient06).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient07).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient08).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient09).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient10).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient11).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient12).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient13).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient14).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient15).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient16).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient17).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient18).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient19).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient20).DataField, DxxFormat.DecimalPlaces, 28, 8)
        InputNumber(tdbg, arr)
    End Sub


    Dim dtBaseSalary As DataTable
    Dim dtSalCoefficient As DataTable
    Private Sub Column_Caption()
        Dim sSQL As String = ""
        Dim i As Integer = 0
        'Cac cot muc luong
        sSQL = "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short " & vbCrLf
        sSQL &= "FROM D13T9000 WITH(NOLOCK) WHERE Disabled = 0 And Type='SALBA' ORDER BY Code"
        dtBaseSalary = ReturnDataTable(sSQL)
        For i = 0 To dtBaseSalary.Rows.Count - 1
            Dim sField As String = dtBaseSalary.Rows(i).Item("Code").ToString
            sField = sField.Replace("BASE", "BaseSalary")
            tdbg.Columns(sField).Caption = dtBaseSalary.Rows(i).Item("Short").ToString
            tdbg.Splits(SPLIT2).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(SPLIT2).DisplayColumns(sField).Visible = True
            tdbg.Columns(sField).Tag = tdbg.Splits(SPLIT2).DisplayColumns(sField).Visible
        Next

        '------------------------------------------------------------------------------
        'Cac cot he so
        sSQL = "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short " & vbCrLf
        sSQL &= "FROM D13T9000 WITH(NOLOCK) WHERE Disabled = 0 And Type='SALCE' ORDER BY Code"
        dtSalCoefficient = ReturnDataTable(sSQL)
        For i = 0 To dtSalCoefficient.Rows.Count - 1
            Dim sField As String = dtSalCoefficient.Rows(i).Item("Code").ToString
            sField = sField.Replace("CE", "SalCoefficient")
            tdbg.Columns(sField).Caption = dtSalCoefficient.Rows(i).Item("Short").ToString
            tdbg.Splits(SPLIT2).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(SPLIT2).DisplayColumns(sField).Visible = True
            tdbg.Columns(sField).Tag = tdbg.Splits(SPLIT2).DisplayColumns(sField).Visible
        Next

    End Sub

    Private Sub EnabledButton(ByVal ID As Long)
        Dim i As Integer
        btnHireInfo.Enabled = Math.Abs(ID - 0) > 0
        btnSalaryInfo.Enabled = Math.Abs(ID - 1) > 0
        'Thong tin tuyen dung
        For i = COL_PreparerID To COL_RecruitmentFileName
            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = (Math.Abs(ID - button.HireInfo) = 0)
        Next
        For j As Integer = COL_N01ID To COL_N20ID '20 cột mã phân tích nhân sự
            If Not L3Bool(tdbg.Columns(j).Tag) Then tdbg.Splits(SPLIT2).DisplayColumns(j).Visible = False
        Next
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BlockID).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DepartmentID).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_TeamID).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RecPositionID).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RecPositionName).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_InterviewFileID).Visible = False
       
        'Thong tin luong
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryObjectID).Visible = (Math.Abs(ID - button.SalaryInfo) = 0)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DetailNotes).Visible = (Math.Abs(ID - button.SalaryInfo) = 0)
        '*******************************
        For i = COL_BaseSalary01 To COL_SalCoefficient20
            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = (Math.Abs(ID - button.SalaryInfo) = 0) And L3Bool(tdbg.Columns(i).Tag)
        Next        '*******************************
    End Sub

    Private Sub btnHireInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHireInfo.Click
        EnabledButton(button.HireInfo)
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT2
        tdbg.Col = COL_PreparerID
        'usrOption.GetButtonPress(0)
        CallD99U1111(False, 0)
    End Sub

    Private Sub btnSalaryInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryInfo.Click
        EnabledButton(button.SalaryInfo)
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT2
        tdbg.Col = COL_SalaryObjectID
        'usrOption.GetButtonPress(1)
        CallD99U1111(False, 1)
    End Sub

    Private Sub btnSalaryUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryUpdate.Click
        If D99C0008.MsgAsk(rL3("Ban_co_muon_gan_thong_so_luong_theo_doi_tuong_tinh_luong_khong")) = Windows.Forms.DialogResult.No Then Exit Sub
        '***********************************
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_SalaryObjectID).ToString = "" And L3Bool(tdbg(i, COL_IsUsed).ToString) = True Then
                If D99C0008.MsgAsk(rL3("Ton_tai_ung_vien_chua_chon_doi_tuong_tinh_luong_Ban_co_muon_tiep_tuc_khong")) = Windows.Forms.DialogResult.No Then
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_SalaryObjectID
                    tdbg.Row = i
                    tdbg.Focus()
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next
        '***********************************
        btnSalaryUpdate.Enabled = False
        'tdbg.UpdateData()
        'If tdbg.Splits(0).DisplayColumns(COL_CandidateID).Visible = False Then 'NV mới (hàng loạt)
        '    For i As Integer = 0 To tdbg.RowCount - 1
        '        tdbg(i, COL_CandidateID) = i + 1
        '    Next
        'End If
        tdbg.UpdateData()
        dtGrid.AcceptChanges()
        '***********************************
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLInsertD13T1030s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD13P1033.ToString & vbCrLf)
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        If dt.Rows.Count > 0 Then
            dt.PrimaryKey = New DataColumn() {dt.Columns("CandidateID"), dt.Columns("InterviewFileID")}
            'dt.PrimaryKey = New DataColumn() {dt.Columns("CandidateID")}
            dtGrid.Merge(dt, False, MissingSchemaAction.AddWithKey)
            
        End If
        tdbg.UpdateData()
        dtGrid.AcceptChanges()
        btnSalaryUpdate.Enabled = True
    End Sub

    Private Sub LoadNxxID()
        LoadTableNCodeID()
        'Load captions of N01ID->N20ID
        Dim dtNxxID As DataTable = ReturnDataTable("Select Description" & UnicodeJoin(gbUnicode) & " as Description, TypeID, Disabled From D09T0010  WITH(NOLOCK) Order by TypeID")
        If dtNxxID.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To 19
                    Dim tdbdX As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = CType(Me.Controls("tdbdN" & (i + 1).ToString("00")), C1.Win.C1TrueDBGrid.C1TrueDBDropdown)
                    LoadTdbdNCodeID(tdbdX)
                    tdbg.Columns(COL_N01ID + i).DropDown = tdbdX
                    '  End If

                    tdbg.Columns(COL_N01ID + i).Caption = dtNxxID.Rows(i).Item("Description").ToString
                    tdbg.Splits(2).DisplayColumns(COL_N01ID + i).Visible = Not L3Bool(dtNxxID.Rows(i).Item("Disabled"))
                    tdbg.Columns(COL_N01ID + i).Tag = Not L3Bool(dtNxxID.Rows(i).Item("Disabled"))
                    tdbg.Splits(2).DisplayColumns(COL_N01ID + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                    tdbg.Splits(2).DisplayColumns(COL_N01ID + i).AutoComplete = False
                    tdbg.Splits(2).DisplayColumns(COL_N01ID + i).AutoDropDown = True
                Next i
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub LoadTableNCodeID()
        Dim sSQL As String = ""

        'Load Table cho NCodeID dropdown
        sSQL = "Select '+'  as NCodeID,  " & NewName & " as Description, '' As TypeID , 0 as DisplayOrder" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select NCodeID, Description" & UnicodeJoin(gbUnicode) & " as Description, TypeID, 1 as DisplayOrder From D09T1010  WITH(NOLOCK) Order by DisplayOrder, TypeID"
        dtNCodeID = ReturnDataTable(sSQL)
    End Sub
    Private Sub LoadTdbdNCodeID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown)
        LoadDataSource(tdbd, ReturnTableFilter(dtNCodeID, "NCodeID = '+' Or TypeID = " & SQLString(tdbd.Name.Substring(4)), True), gbUnicode)
    End Sub

    Private Function SQLInsertD13T1030s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) = False Then Continue For
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Thuc hien Insert" & vbCrLf)
            sSQL.Append("Insert Into D13T1030(")
            sSQL.Append("Users, HostName, Key01ID, Key02ID, Key03ID, Key04ID," & vbCrLf)
            sSQL.Append("Num01, Num02, Num03, Num04, Num06, " & vbCrLf)
            sSQL.Append("Num07, Num08, Num09, Num10, Num11, " & vbCrLf)
            sSQL.Append("Num12, Num13, Num14, Num15, Num16, " & vbCrLf)
            sSQL.Append("Num17, Num18, Num19, Num20, Num21, " & vbCrLf)
            sSQL.Append("Num22, Num23, Num24, Num25")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'Users, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostName, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'Key01ID, varchar[250], NOT NULL  
            sSQL.Append(SQLString(tdbg(i, COL_SalaryObjectID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("D25F2060") & COMMA & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InterviewFileID)) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary01), tdbg.Columns(COL_BaseSalary01).NumberFormat) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary02), tdbg.Columns(COL_BaseSalary02).NumberFormat) & COMMA) 'Num02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary03), tdbg.Columns(COL_BaseSalary03).NumberFormat) & COMMA) 'Num03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary04), tdbg.Columns(COL_BaseSalary04).NumberFormat) & COMMA & vbCrLf) 'Num04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient01), tdbg.Columns(COL_SalCoefficient01).NumberFormat) & COMMA) 'Num06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient02), tdbg.Columns(COL_SalCoefficient02).NumberFormat) & COMMA) 'Num07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient03), tdbg.Columns(COL_SalCoefficient03).NumberFormat) & COMMA) 'Num08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient04), tdbg.Columns(COL_SalCoefficient04).NumberFormat) & COMMA & vbCrLf) 'Num09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient05), tdbg.Columns(COL_SalCoefficient05).NumberFormat) & COMMA) 'Num10, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient06), tdbg.Columns(COL_SalCoefficient06).NumberFormat) & COMMA) 'Num11, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient07), tdbg.Columns(COL_SalCoefficient07).NumberFormat) & COMMA) 'Num12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient08), tdbg.Columns(COL_SalCoefficient08).NumberFormat) & COMMA & vbCrLf) 'Num13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient09), tdbg.Columns(COL_SalCoefficient09).NumberFormat) & COMMA) 'Num14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient10), tdbg.Columns(COL_SalCoefficient10).NumberFormat) & COMMA) 'Num15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient11), tdbg.Columns(COL_SalCoefficient11).NumberFormat) & COMMA) 'Num16, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient12), tdbg.Columns(COL_SalCoefficient12).NumberFormat) & COMMA & vbCrLf) 'Num17, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient13), tdbg.Columns(COL_SalCoefficient13).NumberFormat) & COMMA) 'Num18, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient14), tdbg.Columns(COL_SalCoefficient14).NumberFormat) & COMMA) 'Num19, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient15), tdbg.Columns(COL_SalCoefficient15).NumberFormat) & COMMA) 'Num20, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient16), tdbg.Columns(COL_SalCoefficient16).NumberFormat) & COMMA & vbCrLf) 'Num21, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient17), tdbg.Columns(COL_SalCoefficient17).NumberFormat) & COMMA) 'Num22, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient18), tdbg.Columns(COL_SalCoefficient18).NumberFormat) & COMMA) 'Num23, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient19), tdbg.Columns(COL_SalCoefficient19).NumberFormat) & COMMA) 'Num24, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient20), tdbg.Columns(COL_SalCoefficient20).NumberFormat) & vbCrLf) 'Num25, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLStoreD13P1033() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh thong so luong" & vbCrLf)
        sSQL &= "Exec D13P1033 "
        sSQL &= SQLString(gsUserID) & COMMA 'Users, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostName, varchar[20], NOT NULL
        sSQL &= SQLString("D25F2060") & COMMA 'Form, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 12/04/2012 01:18:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666(Optional ByVal FormID As String = "D25F3060") As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID=" & SQLString(gsUserID)
        sSQL &= " And HostID=" & SQLString(My.Computer.Name)
        sSQL &= " And FormID= " & SQLString(FormID)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Hoàng Nhân
    '# Created Date: 03/12/2014 11:59:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang tam khi in" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID " & vbCrLf)
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D25F3060") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_TransID).DataField)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_InterviewFileID).DataField)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_CandidateID).DataField)) & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLInsertD09T6666(ByVal dr As DataRow, ByVal FormID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID, Key04ID, Key05ID, Str01, Str02" & vbCrLf)
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(FormID) & COMMA) 'FormID, varchar[20], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_CandidateID).DataField)) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_RecruitmentFileID).DataField)) & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_BlockID).DataField)) & COMMA) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_DepartmentID).DataField)) & COMMA) 'Key04ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_TeamID).DataField)) & COMMA) 'Key05ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_RecPositionID).DataField)) & COMMA) 'Str01, varchar[250], NOT NULL
        sSQL.Append(SQLString(dr.Item(tdbg.Columns(COL_WorkID).DataField))) 'Str02, varchar[250], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P1508
    '# Created User: xuanhoa
    '# Created Date: 19/05/2015 04:05:55
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P1508() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon Nguoi quan ly truc tiep" & vbCrLf)
        sSQL &= "Exec D09P1508 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D25F2060") 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function


End Class
