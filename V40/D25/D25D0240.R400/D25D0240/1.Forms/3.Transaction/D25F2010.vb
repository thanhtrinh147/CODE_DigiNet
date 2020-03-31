Imports System
Public Class D25F2010
	Dim dtCaptionCols As DataTable
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0         ' TransID
    Private Const COL_DivisionID As Integer = 1      ' Đơn vị
    Private Const COL_BlockID As Integer = 2         ' BlockID
    Private Const COL_BlockName As Integer = 3       ' Khối
    Private Const COL_DepartmentID As Integer = 4    ' DepartmentID
    Private Const COL_DepartmentName As Integer = 5  ' Phòng ban
    Private Const COL_TeamID As Integer = 6          ' TeamID
    Private Const COL_TeamName As Integer = 7        ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 8   ' RecPositionID
    Private Const COL_RecPositionName As Integer = 9 ' Vị trí
    Private Const COL_Number As Integer = 10         ' Số lượng
    Private Const COL_DateFrom As Integer = 11       ' Từ ngày
    Private Const COL_DateTo As Integer = 12         ' Đến ngày
    Private Const COL_MeetingRoomID As Integer = 13  ' Nơi phỏng vấn
    Private Const COL_NoteDetail As Integer = 14     ' Ghi chú
#End Region


#Region "Const of tdbgInterviewer - Total of Columns: 1"
    Private Const COL_INTERVIEWER_Interviewer As Integer = 0 ' Người PV
#End Region

#Region "Const of tdbgDetail - Total of Columns: 33"
    Private Const COL1_IsUsed As Integer = 0                ' Chọn
    Private Const COL1_CandidateID As Integer = 1           ' Mã ứng viên
    Private Const COL1_CandidateName As Integer = 2         ' Tên ứng viên
    Private Const COL1_RecruitmentFileID As Integer = 3     ' RecruitmentFielID
    Private Const COL1_DivisionName As Integer = 4          ' Đơn vị
    Private Const COL1_BlockID As Integer = 5               ' BlockID
    Private Const COL1_BlockName As Integer = 6             ' Khối
    Private Const COL1_DepartmentID As Integer = 7          ' DepartmentID
    Private Const COL1_DepartmentName As Integer = 8        ' Phòng ban
    Private Const COL1_TeamID As Integer = 9                ' TeamID
    Private Const COL1_TeamName As Integer = 10             ' Tổ nhóm
    Private Const COL1_RecPositionID As Integer = 11        ' RecPositionID
    Private Const COL1_RecPositionName As Integer = 12      ' Vị trí
    Private Const COL1_RecSourceID As Integer = 13          ' RecsourceID
    Private Const COL1_OldInterviewFileID As Integer = 14   ' OldInterviewFileID
    Private Const COL1_OldInterviewFileName As Integer = 15 ' Lịch PV gần nhất
    Private Const COL1_IntOldDate As Integer = 16           ' Ngày PV gần nhất
    Private Const COL1_RecSourceName As Integer = 17        ' Nguồn tuyển dụng
    Private Const COL1_SexName As Integer = 18              ' Giới tính
    Private Const COL1_Birthdate As Integer = 19            ' Ngày sinh
    Private Const COL1_ReceivedDate As Integer = 20         ' Ngày nhận HS
    Private Const COL1_ReceiverName As Integer = 21         ' Người nhận HS
    Private Const COL1_ReceivedPlace As Integer = 22        ' Nơi nhận HS
    Private Const COL1_DesiredSalary As Integer = 23        ' Lương yêu cầu
    Private Const COL1_CurrencyID As Integer = 24           ' Loại tiền
    Private Const COL1_SuggesterName As Integer = 25        ' Người giới thiệu
    Private Const COL1_IntDate As Integer = 26              ' Ngày PV
    Private Const COL1_IntTime As Integer = 27              ' Giờ PV
    Private Const COL1_IntGroupID As Integer = 28           ' IntGroupID
    Private Const COL1_IntGroupName As Integer = 29         ' Nhóm PV
    Private Const COL1_Interviewer As Integer = 30          ' Mã người PV
    Private Const COL1_InterviewerName As Integer = 31      ' Tên người PV
    Private Const COL1_DivisionID As Integer = 32           ' DivisionID
#End Region


#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Dim bIsUseBlock As Boolean

    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable

    Private _isMSS As Integer = 0
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Dim dtTeamIDDetail As New DataTable
    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _interviewFileID As String = ""
    Public Property InterviewFileID() As String 
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String )
            _interviewFileID = value
        End Set
    End Property

    Private _mode As Integer = 0
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
            If _mode = 3 Then
                ReadOnlyControl(tdbcInterviewLevel, tdbcRecruitmentFileID)
            End If
        End Set
    End Property

    Private _recruitPhaseNo As String = ""
    Public WriteOnly Property RecruitPhaseNo() As String
        Set(ByVal Value As String)
            _recruitPhaseNo = Value
            txtRecruitPhaseNo.Text = _recruitPhaseNo
        End Set
    End Property

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Dim bLoadFormState As Boolean = False

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            clsFilterDropdown = New Lemon3.Controls.FilterDropdown()
            clsFilterDropdown.SingleLine = True
            clsFilterDropdown.CheckD91 = False 
            clsFilterDropdown.UseFilterDropdown(tdbgDetail, COL1_Interviewer)

            bIsUseBlock = VisibleBlock()
            LoadTDBDropDown()
            LoadTDBCombo()



            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    c1dateVoucherDate.Value = Date.Now()
                    c1dateFromDate.Value = Date.Now()
                    c1dateToDate.Value = Date.Now()
                    btnNext.Enabled = False
                    ReadOnlyControl(tdbcStatusID)
                  '  GetTextCreateByNew(tdbcCreatorID)
                    btnSend.Enabled = False
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    ReadOnlyControl(tdbcStatusID, tdbcMethodID)
                    btnSend.Enabled = ReturnPermission("D25F2010") >= 2
                Case EnumFormState.FormView
                    ReadOnlyControl(tdbcRecruitmentFileID)
                    ReadOnlyAll(Panel1)
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnSend.Enabled = ReturnPermission("D25F2010") >= 2
            End Select
        End Set

    End Property

    Private Sub D25F2010_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOptionD99 IsNot Nothing Then usrOptionD99.Dispose()
    End Sub

    Private Sub D25F2010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If

        If e.Alt Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                tabMain.SelectedIndex = 0
            End If
            If e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                tabMain.SelectedIndex = 1
            End If
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
        If tabMain.SelectedTab Is TabPage2 Then
            Select Case e.KeyCode
                Case Keys.F12
                    btnF12Detail_Click(Nothing, Nothing)
                Case Keys.Escape
                    usrOptionD99.picClose_Click(Nothing, Nothing)
            End Select

        End If
    End Sub

    Dim bIsFirstLoad As Boolean = True

    Private Sub D25F2010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        bIsFirstLoad = True
        LoadLanguage()
        SetBackColorObligatory()

        ResetFooterGrid(tdbg, SPLIT0, SPLIT0)
        ResetFooterGrid(tdbgDetail, SPLIT0, SPLIT1)

        ResetSplitDividerSize(tdbg, tdbgDetail)

        GetTextCreateByG4(tdbcCreatorID, _FormState = EnumFormState.FormAdd)

        tdbgDetail_LockedColumns()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo)
        LoadMaster()

        'ID 103808 02.10.2017
        chkIsApproveCV.Visible = HideShowchkIsApproveCV()

        txtRecruitPhaseNo.ReadOnly = tdbcRecruitmentFileID.Text <> "" And txtRecruitPhaseNo.Text <> ""
        LoadTDBGrid(_interviewFileID)
       
        LoadTDBGridDetail()
        
        ' LoadTDBGridDetail()
        '********************
        'tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).AllowFocus = False
        'tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).AllowFocus = False
        'tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).AllowFocus = False
        'tdbg.Splits(SPLIT0).DisplayColumns(COL_RecPositionName).AllowFocus = False

        bIsFirstLoad = False
        '********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo, txtVoucherNo.MaxLength)
        '********************
        CallD09U1111_Button(True)
        '********************
        dtF12 = Nothing
        CallD99U1111()
        '********************
        InputDateCustomFormat(c1dateToDate, c1dateFromDate, c1dateVoucherDate)
        InputDateInTrueDBGrid(tdbgDetail, COL1_IntOldDate, COL1_Birthdate, COL1_ReceivedDate, COL1_IntDate)
        ResetGrid()
        SetShortcutPopupMenu(ContextMenuStrip1)
        SetResolutionForm(Me)
    End Sub

    Private Sub D25F2010_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If tdbcMethodID.Visible And tdbcMethodID.ReadOnly = False Then
            tdbcMethodID.Focus()
        Else
            txtVoucherNo.Focus()
        End If

    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_BlockName, COL_DepartmentName, COL_Number, COL_DateFrom, COL_DateTo}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Lap_lich_phong_van") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'LËp lÜch phàng vÊn
        '================================================================ 
        lblCreatorID.Text = rl3("Nguoi_lap") 'Người lập
        lblVoucherNo.Text = rl3("Ma") 'Mã
        lblStatusID.Text = rl3("Trang_thai") 'Trạng thái
        lblInterviewFileName.Text = rl3("Dien_giai") 'Diễn giải
        lblteVoucherDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblteFromDate.Text = rl3("Ngay_PV") 'Ngày PV
        lblInterviewLevel.Text = rl3("Vong_PV") 'Vòng PV
        lblRecruitmentFileID.Text = rl3("KH_tuyen_dung") 'KH tuyển dụng
        lblContactPersonID.Text = rl3("Nguoi_lien_he") 'Người liên hệ
        lblInterviewPlace.Text = rl3("Dia_diem") 'Địa điểm
        lblMethodID.Text = rl3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        lblRecruitPhaseNo.Text = rl3("Dot") 'Đợt
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblIntStatusID.Text = rl3("Trang_thai_PV") 'Trạng thái PV
        lblInterviewLevelDetail.Text = rL3("Vong_PV") 'Vòng PV
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        lblGroupInterviewer.Text = rL3("Nhom_phong_van") 'Nhóm phỏng vấn
        lblPreVoucherNo.Text = rL3("LPV_vong_truoc") 'LPV vòng trước
        '================================================================ 
        btnShowColumns.Text = rl3("Hien_thi") & "(F12)" 'Hiển thị
        btnChooseRecruitment.Text = rl3("_Chon_de_xuat") '&Chọn đề xuất
        btnF12Detail.Text = rl3("Hien_thi") & "(F12)" 'Hiển thị
        btnFilter.Text = rl3("Loc") & "(F5)" '&Lọc
        btnChooseCandidate.Text = rl3("Chon_ung__vien") 'Chọn ứng &viên
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rL3("Nhap__tiep") 'Nhập &tiếp

        '================================================================ 
        btnSend.Text = rL3("InGui_mail") 'In/Gửi mail

        'btnSend.Text = rL3("Gui_mail") 'Gửi mail
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        '================================================================ 
        TabPage2.Text = rl3("Thong_tin_chung") 'Thông tin chung
        TabPage1.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        tdbcContactPersonID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcContactPersonID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcRecruitmentFileID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcRecruitmentFileID.Columns("RecruitmentFileName").Caption = rl3("Ten") 'Tên
        tdbcInterviewLevel.Columns("InterviewLevel").Caption = rl3("Ma") 'Mã
        tdbcInterviewLevel.Columns("InterviewName").Caption = rl3("Ten") 'Tên
        tdbcCreatorID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcCreatorID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcStatusID.Columns("StatusID").Caption = rl3("Ma") 'Mã
        tdbcStatusID.Columns("StatusName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcIntStatusID.Columns("IntStatusID").Caption = rl3("Ma") 'Mã
        tdbcIntStatusID.Columns("IntStatusName").Caption = rl3("Ten") 'Tên
        tdbcInterviewLevelDetail.Columns("InterviewLevel").Caption = rl3("Ma") 'Mã
        tdbcInterviewLevelDetail.Columns("InterviewName").Caption = rL3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdIntGroupName.Columns("IntGroupID").Caption = rL3("Ma") 'Mã
        tdbdIntGroupName.Columns("IntGroupName").Caption = rL3("Ten") 'Tên
        tdbdInterviewer.Columns("InterviewerID").Caption = rL3("Ma") 'Mã
        tdbdInterviewer.Columns("InterviewerName").Caption = rL3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbdRecPositionID.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbdRecPositionID.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        tdbdMeetingRoomName.Columns("MeetingRoomID").Caption = rL3("Ma") 'Mã
        tdbdMeetingRoomName.Columns("MeetingRoomName").Caption = rL3("Ten") 'Tên
        tdbdDivisionName.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbdDivisionName.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_DivisionID).Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_BlockName).Caption = rl3("Khoi") 'Khối
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Vi_tri_tuyen_dung") 'Vị trí tuyển dụng
        tdbg.Columns(COL_Number).Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns(COL_DateFrom).Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns(COL_DateTo).Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_MeetingRoomID).Caption = rl3("Noi_phong_van") 'Nơi phỏng vấn
        tdbg.Columns(COL_NoteDetail).Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        tdbgDetail.Columns(COL1_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbgDetail.Columns(COL1_DivisionName).Caption = rL3("Don_vi") 'Đơn vị
        tdbgDetail.Columns(COL1_BlockName).Caption = rl3("Khoi") 'Khối
        tdbgDetail.Columns(COL1_DepartmentName).Caption = rl3("Phong_ban") 'Phòng ban
        tdbgDetail.Columns(COL1_TeamName).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbgDetail.Columns(COL1_RecPositionName).Caption = rL3("Vi_tri") 'Vị trí
        tdbgDetail.Columns(COL1_OldInterviewFileName).Caption = rl3("Lich_PV_gan_nhat")
        tdbgDetail.Columns(COL1_IntOldDate).Caption = rl3("Ngay_PV_gan_nhat")
        tdbgDetail.Columns(COL1_RecSourceName).Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbgDetail.Columns(COL1_CandidateID).Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbgDetail.Columns(COL1_CandidateName).Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbgDetail.Columns(COL1_SexName).Caption = rl3("Gioi_tinh") 'Giới tính
        tdbgDetail.Columns(COL1_Birthdate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbgDetail.Columns(COL1_ReceivedDate).Caption = rl3("Ngay_nhan_HS") 'Ngày nhận HS
        tdbgDetail.Columns(COL1_ReceiverName).Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbgDetail.Columns(COL1_ReceivedPlace).Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbgDetail.Columns(COL1_DesiredSalary).Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbgDetail.Columns(COL1_CurrencyID).Caption = rl3("Loai_tien") 'Loại tiền
        tdbgDetail.Columns(COL1_SuggesterName).Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
        tdbgDetail.Columns(COL1_IntDate).Caption = rl3("Ngay_PV") 'Ngày PV
        tdbgDetail.Columns(COL1_IntTime).Caption = rl3("Gio_PV") 'Giờ PV
        tdbgDetail.Columns(COL1_IntGroupName).Caption = rl3("Nhom_PV") 'Nhóm PV
        tdbgDetail.Columns(COL1_Interviewer).Caption = rL3("Ma_nguoi_PV")
        tdbgDetail.Columns(COL1_InterviewerName).Caption = rL3("Ten_nguoi_PV")
        '================================================================ 
        chkIsApproveCV.Text = rL3("Duyet_CV_ung_vien") 'Duyệt CV ứng viên

    End Sub


    Private Sub SetBackColorObligatory()
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtInterviewFileName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCreatorID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcInterviewLevel.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '*******************************
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_Number).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_DateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_DateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function VisibleBlock() As Boolean
        If D25Systems.IsUseBlock = False Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False

            tdbgDetail.Splits(SPLIT0).DisplayColumns.Item(COL1_BlockID).Visible = False
            tdbgDetail.Splits(SPLIT0).DisplayColumns.Item(COL1_BlockName).Visible = False

            Return False
        End If

        Return True
    End Function

    Private Sub tdbgDetail_LockedColumns()
        For i As Integer = COL1_BlockID To COL1_SuggesterName
            tdbgDetail.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbgDetail.Splits(SPLIT0).DisplayColumns(i).AllowFocus = False
            tdbgDetail.Splits(SPLIT0).DisplayColumns(i).Locked = True
        Next
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_DivisionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_DivisionName).AllowFocus = False
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_DivisionName).Locked = True

        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_InterviewerName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_InterviewerName).AllowFocus = False
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL1_InterviewerName).Locked = True
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868("%", Me.Name, _isMSS)

        dtDepartmentID = ReturnTableDepartmentID_D09P6868("%", Me.Name, _isMSS)
        'Load tdbcDepartmentID
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", "%", gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0

        '        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", tdbcDepartmentID.Text, gbUnicode)

        Dim sUnicode As String = UnicodeJoin(gbUnicode)
        sSQL = "--Combo vị trí:" & vbCrLf
        sSQL &= "SELECT		'%' AS RecPositionID, " & AllName & " AS RecPositionName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName, DutyDisplayOrder as DisplayOrder" & vbCrLf
        sSQL &= "FROM		D09T0211  WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)
        tdbcRecPositionID.SelectedIndex = 0

        '   tdbcInterviewLevelDetail.SelectedIndex = 0
        sSQL = "-- Combo Trạng thái:  Thực thi câu sql sau" & vbCrLf
        sSQL &= " SELECT     IntStatusID, IntStatusName" & IIf(geLanguage = EnumLanguage.English, "01", "").ToString & sUnicode & " AS IntStatusName" & vbCrLf
        sSQL &= " FROM	  D25V2016" & vbCrLf
        sSQL &= " ORDER BY   IntStatusID"
        LoadDataSource(tdbcIntStatusID, sSQL, gbUnicode)
        'tdbcIntStatusID.SelectedIndex = 0
        'Load tdbcStatusID
        sSQL = "SELECT StatusID, " & vbCrLf
        sSQL &= "Case when " & SQLString(gsLanguage) & " = '84' Then StatusName84" & UnicodeJoin(gbUnicode) & " ELSE StatusName01" & UnicodeJoin(gbUnicode) & " END AS StatusName" & vbCrLf
        sSQL &= "FROM D25V2000" & vbCrLf
        sSQL &= "WHERE TypeID = 'IF' " & vbCrLf
        sSQL &= "ORDER BY StatusID"
        LoadDataSource(tdbcStatusID, sSQL, gbUnicode)

        'Load tdbcCreatorID
        'LoadDataSource(tdbcCreatorID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadCboCreateByG4(tdbcCreatorID, Me.Name, _isMSS)

        'Load tdbcInterviewLevel
        sSQL = "-- Combo Vòng PV: Thực thi câu sql sau" & vbCrLf
        sSQL &= "Select InterviewLevel, LevelName" & gsLanguage & UnicodeJoin(gbUnicode) & " as InterviewName" & vbCrLf
        sSQL &= "From D25V2015 " & vbCrLf
        sSQL &= "Order by No"
        Dim dtInterviewLevel As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcInterviewLevelDetail, dtInterviewLevel, gbUnicode)
        LoadDataSource(tdbcInterviewLevel, dtInterviewLevel.DefaultView.ToTable, gbUnicode)

        'Load tdbcRecruitmentFileID
        sSQL = "Select Distinct RecruitmentFileID, VoucherNo, RecruitmentFileName" & UnicodeJoin(gbUnicode) & " As RecruitmentFileName" & vbCrLf
        sSQL &= "From D25T1042 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where RFStatusID = 3" & vbCrLf
        sSQL &= "Order By  RecruitmentFileID Desc"
        LoadDataSource(tdbcRecruitmentFileID, sSQL, gbUnicode)

        'Load tdbcContactPersonID
        LoadDataSource(tdbcContactPersonID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        '**************

        If D25Systems.AutoInterviewFileID And (_FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy) Then
            sSQL = "SELECT 		MethodID, MethodName" & UnicodeJoin(gbUnicode) & " AS MethodName, IsDefault, TypeCode" & vbCrLf
            sSQL &= "FROM 		D09T1600 WITH(NOLOCK)  " & vbCrLf
            sSQL &= "WHERE 		Disabled = 0  AND TypeCode = 52 AND (DivisionID = " & SQLString(gsDivisionID) & " Or DivisionID = '')" & vbCrLf
            sSQL &= "ORDER BY 	MethodName	"
            Dim dtTemp As DataTable = ReturnDataTable(sSQL)
            Dim dr() As DataRow = dtTemp.Select("IsDefault =1")
            LoadDataSource(tdbcMethodID, dtTemp, gbUnicode)
            If dr.Length > 0 Then tdbcMethodID.SelectedValue = dr(0).Item("MethodID").ToString

            ReadOnlyControl(txtVoucherNo)
        Else
            lblMethodID.Visible = False
            tdbcMethodID.Visible = False
            lblStatusID.Left = lblVoucherNo.Left
            tdbcStatusID.Left = txtVoucherNo.Left

            lblVoucherNo.Left = lblMethodID.Left
            txtVoucherNo.Left = tdbcMethodID.Left
        End If

        Dim dtDivisionID As DataTable = ReturnTableDivisionIDD09("D09", True, gbUnicode)
        LoadDataSource(tdbcDivisionID, dtDivisionID, gbUnicode)
        tdbcDivisionID.SelectedIndex = 0
        'tdbdDivisionID
        Dim dtDivision As DataTable = dtDivisionID.DefaultView.ToTable
        dtDivision.Rows.RemoveAt(0)
        LoadDataSource(tdbdDivisionName, dtDivision, gbUnicode)
        'LoadCboDivisionIDAll(tdbcDivisionID, "D09", True, gbUnicode)

    End Sub

    Dim dtInterviewer As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        dtBlockID = ReturnTableBlockID_D09P6868("%", Me.Name, _isMSS)
        'sSQL = "Select BlockID, BlockName" & UnicodeJoin(gbUnicode) & " As BlockName" & vbCrLf
        'sSQL &= "From D09T1140  WITH(NOLOCK) Where Disabled =0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        'sSQL &= "Order by BlockID"
        'LoadDataSource(tdbdBlockID, sSQL, gbUnicode)

        'LoadDataSource(tdbdBlockID, ReturnTableFilter(ReturnTableBlockID_D09P6868("%", Me.Name, _isMSS), "BlockID <>'%'"), gbUnicode)
        'Load tdbdDepartmentID
        'sSQL = "SELECT 	DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " As DepartmentName, BlockID" & vbCrLf
        'sSQL &= "FROM D91T0012 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "WHERE Disabled = 0" & vbCrLf
        'sSQL &= "AND DivisionID = " & SQLString(gsDivisionID)
        'dtDepartmentID = ReturnDataTable(sSQL)
        'dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, Me.Name, _isMSS)

        'sSQL = "SELECT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " As TeamName, D01.DepartmentID, D02.BlockID" & vbCrLf
        'sSQL &= "FROM D09T0227 D01  WITH(NOLOCK) INNER JOIN D91T0012 D02  WITH(NOLOCK) ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        'sSQL &= "WHERE D01.Disabled = 0" & vbCrLf
        'sSQL &= "AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        'dtTeamID = ReturnDataTable(sSQL)
        ' dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, Me.Name, _isMSS)

        'Load tdbdPositionID
        LoadDataSource(tdbdRecPositionID, ReturnTableDutyIDRec(False, gbUnicode), gbUnicode)

        'Load tdbdInterviewer
        sSQL = "SELECT  InterviewerID , InterviewerName" & UnicodeJoin(gbUnicode) & " As InterviewerName" & vbCrLf
        sSQL &= "FROM  D25T1070 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY InterviewerID"
        dtInterviewer = ReturnDataTable(sSQL)
        LoadDataSource(tdbdInterviewer, dtInterviewer, gbUnicode)

        'Load tdbdIntGroupID
        sSQL = "SELECT distinct IntGroupID, IntGroupName" & UnicodeJoin(gbUnicode) & " As IntGroupName " & vbCrLf
        sSQL &= "FROM  D25T1090  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY IntGroupID"
        LoadDataSource(tdbdIntGroupName, sSQL, gbUnicode)

        sSQL = "--Do nguon Noi phong van" & vbCrLf
        sSQL &= "SELECT	MeetingRoomID, MeetingRoomName" & UnicodeJoin(gbUnicode) & " AS MeetingRoomName" & vbCrLf & _
                "	FROM	D55T1000 WITH(NOLOCK)  WHERE Disabled = 0	"
        LoadDataSource(tdbdMeetingRoomName, sSQL, gbUnicode)

    End Sub

    Private Function HideShowchkIsApproveCV() As Boolean
        Dim sSQL As String = ""
        sSQL = "      SELECT	TOP 1 1 " & vbCrLf & _
                " FROM    D09T0009 T1 WITH(NOLOCK) " & vbCrLf & _
                " WHERE   T1.NumValue = 1 " & vbCrLf & _
                " AND FieldName = 'IsApproveCV'"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Return dt.Rows.Count > 0
    End Function
    Private Sub LoadtdbdInterviewer()
        If tdbgDetail.Columns(COL1_IntGroupID).Text = "" Then
            LoadDataSource(tdbdInterviewer, dtInterviewer, gbUnicode)
        Else
            Dim sSQL As String = ""
            sSQL = "SELECT  D70.InterviewerID , D70.InterviewerName" & UnicodeJoin(gbUnicode) & " As InterviewerName" & vbCrLf
            sSQL &= "FROM D25T1070 D70 WITH(NOLOCK) " & vbCrLf
            sSQL &= "WHERE D70.Disabled = 0 AND D70.InterviewerID IN (SELECT InterviewerID FROM D25T1090  WITH(NOLOCK) WHERE IntGroupID = " & SQLString(tdbgDetail.Columns(COL1_IntGroupID).Value) & ") "
            sSQL &= "ORDER BY D70.InterviewerID"
            LoadDataSource(tdbdInterviewer, sSQL, gbUnicode)
        End If
    End Sub

    Private Sub LoadTdbdDepartmentID()
        LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID = " & SQLString(tdbg(tdbg.Row, COL_DivisionID).ToString) & " And DepartmentID <>'%'" & IIf(bIsUseBlock, " And BlockID =  " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString), "").ToString), gbUnicode)
    End Sub

    Private Sub LoadtdbdTeamID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "TeamID  <>'%' And DivisionID = " & SQLString(tdbg(tdbg.Row, COL_DivisionID).ToString) & " And  DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString)), gbUnicode)
        Else
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "TeamID  <>'%' And DivisionID = " & SQLString(tdbg(tdbg.Row, COL_DivisionID).ToString) & " And DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString) & " And BlockID = " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub
    Private Sub LoadTDBGrid(ByVal sVoucherID As String, Optional ByVal iMode As Integer = 0)
        Dim sSQL As String = SQLStoreD25P1041(sVoucherID, iMode)
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_DepartmentName)
    End Sub

    Dim dtGridDetail As DataTable
    Private Sub LoadTDBGridDetail(Optional ByVal bFromFilter As Boolean = False)
        ResetFilter(tdbgDetail, sFilter, bRefreshFilter)
        'IIf(_FormState = EnumFormState.FormAdd, 0, 1)
        Dim iMode As Integer = 0
        If Not bFromFilter Then
            If _FormState = EnumFormState.FormCopy Then
                iMode = 3
            ElseIf _FormState <> EnumFormState.FormAdd Then
                iMode = 1
            End If
        End If
        Dim sSQL As String = SQLStoreD25P2111(iMode)
        If dtGridDetail Is Nothing OrElse dtGridDetail.Rows.Count = 0 Then
            dtGridDetail = ReturnDataTable(sSQL)
        Else
            Dim dtChoose As DataTable = ReturnDataTable(sSQL)
            dtGridDetail.DefaultView.RowFilter = "IsUsed =1"
            dtGridDetail = dtGridDetail.DefaultView.ToTable
            If dtChoose.Rows.Count > 0 Then
                If dtGridDetail.Rows.Count = 0 Then
                    dtGridDetail = dtChoose.DefaultView.ToTable
                Else
                    dtGridDetail.PrimaryKey = New DataColumn() {dtGridDetail.Columns("CandidateID"), dtGridDetail.Columns("InterviewFileID")}
                    dtGridDetail.Merge(dtChoose, True, MissingSchemaAction.AddWithKey)
                End If
            End If
        End If
        gbEnabledUseFind = dtGridDetail.Rows.Count > 0
        LoadDataSource(tdbgDetail, dtGridDetail, gbUnicode)
        ResetGrid()
    End Sub

    'Private Sub ReLoadTDBGridDetail()

    '    dtGridDetail.AcceptChanges()
    '    Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
    '    If chkIsUsed.Checked Then
    '        sFilter = "IsUsed=True"
    '        'Else
    '        '    If sFilter <> "" Then sFilter = "IsUsed=True" & " Or " & sFind
    '    End If
    '    dtGridDetail.DefaultView.RowFilter = sFilter

    'End Sub

    Private Sub ReLoadTDBGridDetail()
        dtGridDetail.AcceptChanges()
        Dim strFind As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsUsed.Checked Then
            strFind = "IsUsed = True"
        Else
            strFind = sFind
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString

            If strFind <> "" Then strFind = "IsUsed = True" & " Or " & strFind
        End If
        dtGridDetail.DefaultView.RowFilter = strFind '.Replace("ApproverID", "ApproverName")

        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        mnsFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind OrElse tdbgDetail.RowCount > 0)
        mnsListAll.Enabled = mnsFind.Enabled
        FooterTotalGrid(tdbgDetail, COL1_DepartmentID)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2014
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/09/2014 01:56:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2014() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load master" & vbCrlf)
        sSQL &= "Exec D25P2014 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(_interviewFileID) & COMMA 'InterviewFileID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'Codetable, tinyint, NOT NULL
        sSQL &= SQLNumber(_mode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub LoadMaster()
        Dim dtMaster As DataTable
        'Dim sSQL As String = ""
        'sSQL = "SELECT	DivisionID, InterviewFileID, InterviewFileName" & UnicodeJoin(gbUnicode) & " AS InterviewFileName, "
        'sSQL &= "Note" & UnicodeJoin(gbUnicode) & " AS Note, FileDate, CreatePerson, FromDate, ToDate, RecruitmentFileID, "
        'sSQL &= "VoucherNo,	VoucherTypeID, VoucherDate, InterviewLevel, "
        'sSQL &= "InterviewPlace" & UnicodeJoin(gbUnicode) & " AS InterviewPlace, GroupInterviewer" & UnicodeJoin(gbUnicode) & " AS GroupInterviewer, TranMonth, TranYear, CreatorID, ContactPersonID, "
        'sSQL &= "Disabled, StatusID, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate" & vbCrLf
        'sSQL &= "FROM D25T2010 WITH(NOLOCK)  WHERE InterviewFileID = " & SQLString(_interviewFileID)
        'dtMaster = ReturnDataTable(sSQL)
        dtMaster = ReturnDataTable(SQLStoreD25P2014)
        If dtMaster.Rows.Count > 0 Then
            With dtMaster.Rows(0)
                txtVoucherNo.Text = .Item("VoucherNo").ToString
                tdbcStatusID.SelectedValue = .Item("StatusID").ToString
                txtInterviewFileName.Text = .Item("InterviewFileName").ToString
                c1dateVoucherDate.Value = SQLDateShow(.Item("VoucherDate").ToString)
                tdbcCreatorID.SelectedValue = .Item("CreatorID").ToString
                GetTextCreateByNew(tdbcCreatorID, False)
                c1dateFromDate.Value = SQLDateShow(.Item("FromDate").ToString)
                c1dateToDate.Value = SQLDateShow(.Item("ToDate").ToString)
                tdbcInterviewLevel.SelectedValue = .Item("InterviewLevel").ToString
                tdbcRecruitmentFileID.SelectedValue = .Item("RecruitmentFileID").ToString
                tdbcContactPersonID.SelectedValue = .Item("ContactPersonID").ToString
                txtInterviewPlace.Text = .Item("InterviewPlace").ToString
                txtGroupInterviewer.Text = .Item("GroupInterviewer").ToString
                txtPreVoucherNo.Text = .Item("PreVoucherNo").ToString
                txtPreVoucherNo.Tag = .Item("PreInterviewFileID").ToString
                chkIsApproveCV.Checked = L3Bool(.Item("IsApproveCV").ToString)
            End With
        End If

        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView Then
            ReadOnlyControl(txtVoucherNo)
        End If
        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy Then
            tdbcStatusID.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadFormChild Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadFormChild = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True

    End Sub

    Private Sub btnChooseCandidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseCandidate.Click
        '************************
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Dim f As New D25F5600
        With f
            .FormID = "D25F2010"
            .VoucherID = _interviewFileID
            .ShowDialog()
            If .DataTableGrid IsNot Nothing Then
                If .DataTableGrid.Rows.Count > 0 Then
                    LoadDataSource(tdbgDetail, .DataTableGrid, gbUnicode)
                    FooterTotalGrid(tdbgDetail, COL_DepartmentName)
                End If
            End If
            .Dispose()
        End With
    End Sub
    Private Sub btnChooseRecruitment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseRecruitment.Click
        '************************
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Dim f As New D25F2020
        With f
            .FormID = "D25F2010"
            .VoucherID = _interviewFileID
            .RecDateFrom = c1dateFromDate.Text
            .RecDateTo = c1dateToDate.Text
            .ShowDialog()
            If .Chose Then
                LoadTDBGrid(ReturnValueC1Combo(tdbcRecruitmentFileID).ToString, 2)
                tdbcRecruitmentFileID.SelectedValue = "" 'ID 80851 02/02/2016
            End If
            .Dispose()
        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        tabMain.SelectedIndex = 0

        tdbg.Delete(0, tdbg.RowCount)
        tdbgDetail.Delete(0, tdbgDetail.RowCount)

        txtVoucherNo.Text = ""
        tdbcStatusID.Text = ""
        txtInterviewFileName.Text = ""
        c1dateVoucherDate.Value = Date.Now()
        'tdbcCreatorID.Text = ""
        tdbcCreatorID.SelectedValue = gsCreateByG4 '  GetTextCreateByNew(tdbcCreatorID)
        c1dateFromDate.Value = Date.Now()
        c1dateToDate.Value = Date.Now()
        tdbcInterviewLevel.Text = ""
        tdbcInterviewLevelDetail.Text = ""
        tdbcRecruitmentFileID.Text = ""
        tdbcDivisionID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        tdbcDepartmentID.SelectedIndex = 0
        tdbcTeamID.SelectedIndex = 0
        tdbcIntStatusID.Text = ""
        tdbcContactPersonID.Text = ""
        txtInterviewPlace.Text = ""
        txtPreVoucherNo.Text = ""
        txtPreVoucherNo.Tag = ""
        _interviewFileID = ""
        tdbcStatusID.SelectedIndex = 0
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnSend.Enabled = False
        If tdbcMethodID.Visible And tdbcMethodID.ReadOnly = False Then
            tdbcMethodID.Focus()
        Else
            txtVoucherNo.Focus()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6600
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/05/2013 03:10:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Phan ra cong thuc sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P6600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMethodID)) & COMMA 'MethodID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMethodID, "TypeCode")) & COMMA 'TypeCode, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/05/2013 03:13:24
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = 'D25F2010'"
        Return sSQL
    End Function



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As New StringBuilder()
        If D25Systems.AutoInterviewFileID And (_FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy) Then
            ' Bước 1: Delete, Insert dữ liệu vào bảng tạm:
            sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
            sSQL.Append("INSERT INTO D09T6666 (UserID, HostID, FormID) VALUES (" & SQLString(gsUserID) & ", " & SQLString(My.Computer.Name) & ", " & SQLString(Me.Name) & ")" & vbCrLf)
            'Bước 2: Thực thi store sinh mã tự động
            sSQL.Append(SQLStoreD09P6600() & vbCrLf)
            sSQL.Append(SQLDeleteD09T6666())
            Dim dtTemp As DataTable = ReturnDataTable(sSQL.ToString)
            If dtTemp.Rows.Count > 0 Then
                If L3Bool(dtTemp.Rows(0).Item("Status")) Then
                    D99C0008.MsgL3(dtTemp.Rows(0).Item("Message").ToString)
                    Exit Sub
                Else
                    txtVoucherNo.Text = dtTemp.Rows(0).Item("ID").ToString
                End If
            End If
        End If
        If Not AllowSave() Then Exit Sub
        Dim dtCheckStore As New DataTable
        If Not CheckStore(SQLStoreD25P5555(0, 0, Me.Name, "Kiem tra cung ke hoach, cung dot, cung vong phong van thi ko cho luu", ReturnValueC1Combo(tdbcRecruitmentFileID).ToString, txtRecruitPhaseNo.Text, ReturnValueC1Combo(tdbcInterviewLevel), txtVoucherNo.Text), "", dtCheckStore) Then
            If L3Int(dtCheckStore.Rows(0).Item("Status")) = 1 Then tdbcInterviewLevel.Focus() : Exit Sub
        End If

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        sSQL = New StringBuilder
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        Select Case _FormState

            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                _interviewFileID = CreateIGE("D25T2010", "InterviewFileID", "25", "IF", gsStringKey)

                sSQL.Append(SQLInsertD25T2010().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2011s.ToString() & vbCrLf)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T2010().ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD25T2040().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD25T2011().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2011s.ToString() & vbCrLf)

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _savedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    btnNext.Enabled = True
                    btnSend.Enabled = ReturnPermission("D25F2010") >= 2
                    btnNext.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tabMain.SelectedIndex = 1
            tdbcDepartmentID.Focus()
            Return False
        End If

        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tabMain.SelectedIndex = 1
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vi_tri"))
            tabMain.SelectedIndex = 1
            tdbcRecPositionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        If tdbcMethodID.Visible And (_FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy) Then
            If tdbcMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Phuong_phap_tao_ma_tu_dong"))
                tabMain.SelectedIndex = 0
                tdbcMethodID.Focus()
                Return False
            End If
        ElseIf txtVoucherNo.ReadOnly = False Then
            If txtVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma"))
                tabMain.SelectedIndex = 0
                txtVoucherNo.Focus()
                Return False
            End If
        End If

        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy Then
            If ExistRecord("SELECT TOP 1 1 FROM D25T2010 WITH(NOLOCK)  WHERE VoucherNo = " & SQLString(txtVoucherNo.Text)) Then
                D99C0008.MsgDuplicatePKey()
                tabMain.SelectedIndex = 0
                txtVoucherNo.Focus()
                Return False
            End If
        End If

        If txtInterviewFileName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            tabMain.SelectedIndex = 0
            txtInterviewFileName.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_lap"))
            tabMain.SelectedIndex = 0
            c1dateVoucherDate.Focus()
            Return False
        End If
        If tdbcCreatorID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_lap"))
            tabMain.SelectedIndex = 0
            tdbcCreatorID.Focus()
            Return False
        End If
        If tdbcInterviewLevel.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vong_PV"))
            tabMain.SelectedIndex = 0
            tdbcInterviewLevel.Focus()
            Return False
        End If
        '***********************
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tabMain.SelectedIndex = 0
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DivisionID).ToString = "" And bIsUseBlock Then
                D99C0008.MsgNotYetEnter(tdbg.Columns(COL_DivisionID).Caption)
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DivisionID
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_BlockName).ToString = "" And bIsUseBlock Then
                D99C0008.MsgNotYetEnter(rL3("Khoi"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_BlockName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DepartmentName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DepartmentName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_Number).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("So_luong"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Number
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DateFrom).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Tu_ngay"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateFrom
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DateTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateTo
                tdbg.Bookmark = i
                Return False
            End If
            If CDate(SQLDateShow(tdbg(i, COL_DateFrom))) > CDate(SQLDateShow(tdbg(i, COL_DateTo))) Then
                D99C0008.MsgL3(rL3("MSG000013"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateFrom
                tdbg.Bookmark = i
                Return False
            End If
        Next
        '***********************
        tdbgDetail.UpdateData()
        If dtGridDetail Is Nothing Then
            D99C0008.MsgNotYetChoose(rl3("Ung_vien"))
            tabMain.SelectedIndex = 1
            btnFilter.Focus()
            Return False
        End If
        Dim drD() As DataRow = dtGridDetail.Select("IsUsed=1")
        If drD.Length <= 0 Then
            D99C0008.MsgNotYetChoose(rl3("Ung_vien"))
            tabMain.SelectedIndex = 1
            tdbgDetail.Col = COL1_IsUsed
            tdbgDetail.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COL1_IntTime).ToString <> "" Then
                If tdbgDetail(i, COL1_IntTime).ToString().Length = 4 Then
                    Dim sHour As String = tdbgDetail(i, COL1_IntTime).ToString().Substring(0, 2)
                    Dim sMinute As String = tdbgDetail(i, COL1_IntTime).ToString().Substring(2, 2)

                    If Number(sHour) > 24 Or Number(sMinute) > 59 Then
                        D99C0008.MsgL3(rl3("Gio_PV") & " " & rl3("khong_hop_le"))
                        tabMain.SelectedIndex = 1
                        tdbgDetail.Focus()
                        tdbgDetail.SplitIndex = SPLIT1
                        tdbgDetail.Col = COL1_IntTime
                        tdbgDetail.Bookmark = i
                        Return False
                    End If
                Else
                    D99C0008.MsgL3(rl3("Gio_PV") & " " & rl3("khong_hop_le"))
                    tabMain.SelectedIndex = 1
                    tdbgDetail.Focus()
                    tdbgDetail.SplitIndex = SPLIT1
                    tdbgDetail.Col = COL1_IntTime
                    tdbgDetail.Bookmark = i
                    Return False
                End If
            End If
        Next

        Return True
    End Function

#Region "Combo Events"

#Region "Events tdbcStatusID"

    Private Sub tdbcStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStatusID.LostFocus
        If tdbcStatusID.FindStringExact(tdbcStatusID.Text) = -1 Then tdbcStatusID.Text = ""
    End Sub

#End Region

#Region "Events tdbcInterviewLevel"

    Private Sub tdbcInterviewLevel_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewLevel.LostFocus
        If tdbcInterviewLevel.FindStringExact(tdbcInterviewLevel.Text) = -1 Then tdbcInterviewLevel.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecruitmentFileID"

    Private Sub tdbcRecruitmentFileID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.LostFocus
        If tdbcRecruitmentFileID.FindStringExact(tdbcRecruitmentFileID.Text) = -1 Then tdbcRecruitmentFileID.Text = "" : txtRecruitPhaseNo.Text = "" : tdbcInterviewLevel.SelectedValue = ""
        txtRecruitPhaseNo.ReadOnly = tdbcRecruitmentFileID.Text <> ""
    End Sub
    Private Sub tdbcRecruitmentFileID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.Close
        tdbcRecruitmentFileID_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcRecruitmentFileID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '*************************
        Dim sRecruitmentFileID As String = ReturnValueC1Combo(tdbcRecruitmentFileID)
        If tdbcRecruitmentFileID.Tag Is Nothing OrElse tdbcRecruitmentFileID.Tag.ToString <> sRecruitmentFileID Then
            If bIsFirstLoad = True Then Exit Sub
            txtRecruitPhaseNo.ReadOnly = tdbcRecruitmentFileID.Text <> ""
            LoadTDBGrid(ReturnValueC1Combo(tdbcRecruitmentFileID))
            If dtGrid.Rows.Count = 0 Then Exit Sub
            txtRecruitPhaseNo.Text = dtGrid.Rows(0).Item("RecruitPhaseNo").ToString  'ReturnValueC1Combo(tdbcRecruitmentFileID, "RecruitPhaseNo").ToString
            tdbcInterviewLevel.SelectedValue = dtGrid.Rows(0).Item("InterviewLevel") 'ReturnValueC1Combo(tdbcRecruitmentFileID, "InterviewLevel").ToString
            '*************************
            tdbcRecruitmentFileID.Tag = sRecruitmentFileID
        End If
    End Sub
#End Region

#Region "Events tdbcCreatorID"

    Private Sub tdbcCreatorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
        If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then tdbcCreatorID.Text = ""
    End Sub

#End Region

#Region "Events tdbcContactPersonID"

    Private Sub tdbcContactPersonID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcContactPersonID.LostFocus
        If tdbcContactPersonID.FindStringExact(tdbcContactPersonID.Text) = -1 Then tdbcContactPersonID.Text = ""
    End Sub

#End Region

#Region "Events tdbcMethodID"

    Private Sub tdbcMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.LostFocus
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub

#End Region
#End Region

#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.Columns(COL_TransID).Text = "" Then tdbg.Columns(COL_TransID).Text = ""
        '************************
        Select Case e.ColIndex
            Case COL_DivisionID
                tdbg.Columns(COL_BlockID).Text = ""
                tdbg.Columns(COL_BlockName).Text = ""
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_MeetingRoomID
                If bNotInList = True Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                End If

            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BlockID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text

            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("RecPositionID").Text

            Case COL_DateFrom, COL_DateTo
                tdbg.Select()
        End Select

        FooterTotalGrid(tdbg, COL_DepartmentName)
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        FooterTotalGrid(tdbg, COL_DepartmentName)
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_MeetingRoomID
                If tdbg.Columns(e.ColIndex).Text <> tdbdMeetingRoomName.Columns("MeetingRoomName").Text Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_DivisionID
                If tdbg.Columns(e.ColIndex).Text <> tdbdDivisionName.Columns(1).Text Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If

            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If

            Case COL_Number
                If Not L3IsNumeric(tdbg.Columns(COL_Number).Text, EnumDataType.Int) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub

        Select Case iCol
            Case COL_DivisionID, COL_BlockName, COL_DepartmentName, COL_TeamName
                Dim iCols() As Integer = {COL_DivisionID, COL_BlockID, COL_BlockName, COL_DepartmentID, COL_DepartmentName, COL_TeamID, COL_TeamName}
                CopyColumnArr(tdbg, tdbg.Col, iCols)
            Case COL_RecPositionName
                Dim iCols() As Integer = {COL_RecPositionName}
                CopyColumnArr(tdbg, tdbg.Col, iCols)
            Case Else
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            Exit Sub
        End If
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg.Col
                    Case COL_DivisionID, COL_BlockName, COL_DepartmentName, COL_TeamName
                        F7More(tdbg, COL_DivisionID, COL_BlockID, COL_BlockName, COL_DepartmentID, COL_TeamID, COL_DepartmentName, COL_TeamName)

                        'Case COL_DepartmentName
                        '    F7More(tdbg, COL_DepartmentID)

                        'Case COL_TeamName
                        '    F7More(tdbg, COL_TeamID)

                    Case COL_RecPositionName
                        F7More(tdbg, COL_RecPositionID)
                    Case Else
                        HotKeyF7(tdbg)
                End Select
            Case Keys.F8
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF8(tdbg)
                    tdbg.Columns(COL_TransID).Text = ""
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Case Keys.Enter
                If tdbg.Col = COL_NoteDetail Then
                    HotKeyEnterGrid(tdbg, COL_BlockName, e, SPLIT0)
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Number
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_BlockName
                LoadtdbdBlockID(tdbdBlockID, dtBlockID, tdbg(tdbg.Row, COL_DivisionID).ToString, gbUnicode)
            Case COL_DepartmentName
                LoadTdbdDepartmentID()
            Case COL_TeamName
                LoadtdbdTeamID()
        End Select
    End Sub

    Private Sub tdbgDetail_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL1_Interviewer
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbgDetail, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbgDetail, e, tdbd)
                AfterColUpdate(e.ColIndex, dr)
                Exit Sub
            Case COL1_IntTime
                If tdbgDetail.Columns(COL1_IntTime).Value.ToString.Length = 4 Then
                    Dim sTime As String = tdbgDetail.Columns(COL1_IntTime).Value.ToString
                    Dim sHour As String = sTime.Substring(0, 2)
                    Dim sMinute As String = sTime.Substring(2, 2)

                    If sHour.Trim = "" Then sHour = "00"
                    If sMinute.Trim = "" Then sMinute = "00"
                    If sHour.Trim.Length = 1 Then sHour = "0" & sHour
                    If sMinute.Trim.Length = 1 Then sMinute = "0" & sMinute

                    tdbgDetail.Columns(COL1_IntTime).Value = sHour & sMinute
                    tdbgDetail.UpdateData()
                    tdbgDetail.Columns(COL1_IntTime).Value = sHour & sMinute
                ElseIf tdbgDetail.Columns(COL1_IntTime).Value.ToString.Length = 3 Then
                    Dim sTime As String = tdbgDetail.Columns(COL1_IntTime).Value.ToString
                    Dim sHour As String = sTime.Substring(0, 2)
                    Dim sMinute As String = sTime.Substring(2, 1)

                    If sHour.Trim = "" Then sHour = "00"
                    If sMinute.Trim = "" Then sMinute = "00"
                    If sHour.Trim.Length = 1 Then sHour = "0" & sHour
                    If sMinute.Trim.Length = 1 Then sMinute = "0" & sMinute

                    tdbgDetail.Columns(COL1_IntTime).Value = sHour & sMinute
                    tdbgDetail.UpdateData()
                    tdbgDetail.Columns(COL1_IntTime).Value = sHour & sMinute
                End If
            Case COL1_IntGroupID
                If bNotInList = True Then
                    tdbgDetail.Columns(COL1_IntGroupID).Text = ""
                    bNotInList = False
                End If
                tdbgDetail.Columns(COL1_Interviewer).Text = ""
            Case COL1_IntDate
                tdbgDetail.Select()
        End Select
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL1_IntGroupID
                If tdbgDetail.Columns(COL1_IntGroupID).Text <> tdbdIntGroupName.Columns("IntGroupName").Text Then
                    'tdbgDetail.Columns(COL1_IntGroupName).Text = ""
                    tdbgDetail.Columns(COL1_IntGroupID).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub

    Private Sub tdbgDetail_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ComboSelect
        tdbgDetail.UpdateData()
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim sAcc As String = "" 'Nếu dùng SingleLine =True thì dùng code này
        Dim sAccName As String = ""
        For Each row As DataRow In dr
            If sAcc <> "" Then sAcc &= ";"
            If sAccName <> "" Then sAccName &= ";"
            sAcc &= L3String(row.Item("InterviewerID"))
            sAccName &= L3String(row.Item("InterviewerName"))
        Next
        tdbgDetail.Columns(iCol).Value = sAcc
        tdbgDetail.Columns(COL1_InterviewerName).Text = sAccName
        tdbgDetail.Focus()
    End Sub

    Dim bSelect As Boolean = False
    Private Sub HeadClickDetail(ByVal col As Integer)
        Select Case col
            Case COL1_IsUsed
                tdbgDetail.AllowSort = False
                L3HeadClick(tdbgDetail, col, bSelect)
            Case COL1_IntDate, COL1_IntTime
                tdbgDetail.AllowSort = False
                CopyColumns(tdbgDetail, col, tdbgDetail.Columns(col).Text, tdbgDetail.Row)
            Case COL1_IntGroupID, COL1_Interviewer, COL1_InterviewerName
                tdbgDetail.AllowSort = False
                CopyColumnArr(tdbgDetail, col, New Integer() {COL1_IntGroupID, COL1_Interviewer, COL1_InterviewerName})
            Case Else
                tdbgDetail.AllowSort = True
        End Select
    End Sub

    Private Sub tdbgDetail_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.HeadClick
        HeadClickDetail(e.ColIndex)
    End Sub

    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgDetail.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbgDetail, e) Then
            Select Case tdbgDetail.Col
                Case COL1_Interviewer
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbgDetail, tdbgDetail.Columns(tdbgDetail.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbgDetail, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbgDetail.Col, dr)
                    Exit Sub
            End Select
        End If

        Select Case tdbgDetail.Col
            Case COL1_Interviewer
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbgDetail.Splits(1).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbgDetail.Splits(1).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbgDetail.Col
                    Case COL1_IntDate, COL1_Interviewer
                        HotKeyF7(tdbgDetail)
                    Case COL1_IntTime
                        tdbgDetail.Columns(tdbgDetail.Col).Text = Now().ToString
                        tdbgDetail.UpdateData()
                        tdbgDetail.Columns(tdbgDetail.Col).Text = tdbgDetail(tdbgDetail.Row - 1, tdbgDetail.Col).ToString().Insert(2, ":")
                        tdbgDetail.UpdateData()
                End Select
            Case Keys.F8
                Select Case tdbgDetail.Col
                    Case COL1_IntDate, COL1_IntTime, COL1_Interviewer
                        HotKeyF8(tdbgDetail)
                End Select
            Case Keys.Enter
                If tdbgDetail.Col = COL1_Interviewer Then
                    HotKeyEnterGrid(tdbgDetail, COL1_IntDate, e, SPLIT1)
                End If
        End Select

        If e.Control And e.KeyCode = Keys.S Then
            HeadClickDetail(tdbgDetail.Col)
        End If
        HotKeyCtrlVOnGrid(tdbgDetail, e)
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1041
    '# Created User: 
    '# Created Date: 05/07/2010 10:13:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1041(ByVal sVoucherID As String, Optional ByVal iMode As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(sVoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("D25F2110") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2111
    '# Created User: 
    '# Created Date: 22/10/2013 01:51:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2111(ByVal Mode As Object) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi chi tiet" & vbCrLf)
        sSQL &= "Exec D25P2111 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_interviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcInterviewLevelDetail)) & COMMA 'InterviewLevel, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcIntStatusID)) & COMMA 'IntStatusID, varchar[20], NOT NULL
        sSQL &= SQLNumber(Mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[20], NOT NULL
        sSQL &= COMMA & SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID))
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2010
    '# Created User: 
    '# Created Date: 05/07/2010 11:26:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T2010(")
        sSQL.Append("DivisionID, InterviewFileID, InterviewFileName, InterviewFileNameU, ")
        sSQL.Append("FromDate, ToDate, CreateUserID, ")
        sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate, RecruitmentFileID, VoucherNo, ")
        sSQL.Append("InterviewLevel, InterviewPlace, InterviewPlaceU, TranMonth, TranYear, ")
        sSQL.Append("StatusID, CreatorID, ContactPersonID, RecruitPhaseNo, GroupInterviewer, GroupInterviewerU, VoucherDate, PreInterviewFileID,IsApproveCV")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(_interviewFileID) & COMMA) 'InterviewFileID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtInterviewFileName, False) & COMMA) 'InterviewFileName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtInterviewFileName, True) & COMMA) 'InterviewFileNameU, varchar[50], NULL
        sSQL.Append(SQLDateSave(c1dateFromDate.Text) & COMMA) 'FromDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateToDate.Text) & COMMA) 'ToDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA) 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcInterviewLevel)) & COMMA) 'InterviewLevel, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtInterviewPlace, False) & COMMA) 'InterviewPlace, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtInterviewPlace, True) & COMMA) 'InterviewPlaceU, varchar[250], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
        sSQL.Append(SQLNumber(ReturnValueC1Combo(tdbcStatusID)) & COMMA) 'StatusID, tinyint, NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcContactPersonID)) & COMMA) 'ContactPersonID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtRecruitPhaseNo.Text) & COMMA)
        sSQL.Append(SQLStringUnicode(txtGroupInterviewer, False) & COMMA) 'InterviewPlace, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtGroupInterviewer, True) & COMMA) 'InterviewPlaceU, varchar[250], NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text)) 'VoucherDate, datetime, NOT NULL
        sSQL.Append(COMMA & SQLString(txtPreVoucherNo.Tag) & COMMA)
        'ID 103808 02.10.2017
        sSQL.Append(SQLNumber(chkIsApproveCV.Checked)) 'IsApproveCV, tinyint, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2010
    '# Created User: 
    '# Created Date: 05/07/2010 11:54:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2010 Set ")
        sSQL.Append("InterviewFileName = " & SQLStringUnicode(txtInterviewFileName, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("InterviewFileNameU = " & SQLStringUnicode(txtInterviewFileName, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("FromDate = " & SQLDateSave(c1dateFromDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("ToDate = " & SQLDateSave(c1dateToDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("RecruitmentFileID = " & SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("InterviewLevel = " & SQLString(ReturnValueC1Combo(tdbcInterviewLevel)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("GroupInterviewer = " & SQLStringUnicode(txtGroupInterviewer, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("GroupInterviewerU = " & SQLStringUnicode(txtGroupInterviewer, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("InterviewPlace = " & SQLStringUnicode(txtInterviewPlace, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("InterviewPlaceU = " & SQLStringUnicode(txtInterviewPlace, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("CreatorID = " & SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ContactPersonID = " & SQLString(ReturnValueC1Combo(tdbcContactPersonID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("RecruitPhaseNo = " & SQLString(txtRecruitPhaseNo.Text) & COMMA)
        sSQL.Append("PreInterviewFileID  = " & SQLString(txtPreVoucherNo.Tag) & COMMA)
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'datetime, NOT NULL
        'ID 103808 02.10.2017
        sSQL.Append("IsApproveCV  = " & SQLNumber(chkIsApproveCV.Checked))
        sSQL.Append(" Where ")
        sSQL.Append("InterviewFileID = " & SQLString(_interviewFileID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2040s
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 11:56:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2040s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTranID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2040", "TransID", "25", "RT", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If

            sSQL.Append("Insert Into D25T2040(")
            sSQL.Append("VoucherID, TransTypeID, TransID, DivisionID, BlockID, DepartmentID, ")
            sSQL.Append("TeamID, RecpositionID, Quantity, FromDate, ToDate, MeetingRoomID,")
            sSQL.Append("Notes, NotesU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_interviewFileID) & COMMA) 'VoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString("RT") & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DivisionID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'RecpositionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Number)) & COMMA) 'Quantity, int, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'FromDate, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'ToDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_MeetingRoomID)) & COMMA) 'RecpositionID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, False) & COMMA) 'Notes, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, True)) 'NotesU, varchar[500], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2011s
    '# Created User: 
    '# Created Date: 05/07/2010 11:36:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2011s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If L3Bool(tdbgDetail(i, COL1_IsUsed)) = False Then Continue For
            sSQL.Append("Insert Into D25T2011(")
            sSQL.Append("DivisionID, InterviewFileID, RecruitmentFileID, CandidateID, ")
            sSQL.Append("IntDate, Interviewer, InterviewPlace, InterviewPlaceU, ")
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ")
            sSQL.Append("InterviewLevels, IntTime, IntGroupID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbgDetail(i, COL1_DivisionID)) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_interviewFileID) & COMMA) 'InterviewFileID, varchar[20], NOT NULL
            'sSQL.Append(SQLString(tdbgDetail(i, COL1_RecruitmentFileID)) & COMMA) 'RecruitmentFileID, varchar[20], NOT NULL
            sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA) 'RecruitmentFileID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgDetail(i, COL1_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbgDetail(i, COL1_IntDate)) & COMMA) 'IntDate, datetime, NULL
            sSQL.Append(SQLString(tdbgDetail(i, COL1_Interviewer)) & COMMA) 'Interviewer, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(txtInterviewPlace, False) & COMMA) 'InterviewPlace, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(txtInterviewPlace, True) & COMMA) 'InterviewPlaceU, varchar[250], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(ReturnValueC1Combo(tdbcInterviewLevel)) & COMMA) 'InterviewLevels, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgDetail(i, COL1_IntTime)) & COMMA) 'IntTime, varchar[4], NOT NULL
            sSQL.Append(SQLString(tdbgDetail(i, COL1_IntGroupID))) 'IntTime, varchar[4], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 04:04:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where "
        sSQL &= "VoucherID = " & SQLString(_interviewFileID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2011
    '# Created User: 
    '# Created Date: 05/07/2010 11:52:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2011() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2011"
        sSQL &= " Where "
        sSQL &= "InterviewFileID = " & SQLString(_interviewFileID)
        Return sSQL
    End Function

#End Region

    Private Sub tdbgDetail_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgDetail.RowColChange
        Select Case tdbgDetail.Col
            Case COL1_Interviewer
                LoadtdbdInterviewer()
        End Select
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcInterviewLevelDetail.Close, tdbcIntStatusID.Close, tdbcCreatorID.Close, tdbcContactPersonID.Close, tdbcStatusID.Close, tdbcInterviewLevel.Close, tdbcMethodID.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcInterviewLevelDetail.Validated, tdbcIntStatusID.Validated, tdbcCreatorID.Validated, tdbcContactPersonID.Validated, tdbcStatusID.Validated, tdbcInterviewLevel.Validated, tdbcMethodID.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

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
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", ReturnValueC1Combo(tdbcDepartmentID), ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        Dim sDivisionID As String = ReturnValueC1Combo(tdbcDivisionID)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", sDivisionID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        LoadTDBGridDetail(True)
        'dtF12 = Nothing
        'CallD99U1111()
    End Sub

    Private Sub chkIsUsed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If tdbgDetail.DataSource Is Nothing Then Exit Sub
        ReLoadTDBGridDetail()
    End Sub

    Private usrOptionD99 As New D99U1111()
    Dim dtF12 As DataTable
    Private Sub btnF12Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12Detail.Click
        usrOptionD99.Location = New Point(tdbgDetail.Left, btnF12Detail.Top - (usrOptionD99.Height + 7))
        Me.Controls.Add(usrOptionD99)
        usrOptionD99.BringToFront()
        usrOptionD99.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL1_IsUsed, COL1_BlockID, COL1_DepartmentID, COL1_TeamID, COL1_CandidateID}
        usrOptionD99.AddColVisible(tdbgDetail, dtF12, arrColObligatory)
        If usrOptionD99 IsNot Nothing Then usrOptionD99.Dispose()
        usrOptionD99 = New D99U1111(Me, tdbgDetail, dtF12)
    End Sub

    Private Sub tdbcInterviewLevel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewLevel.SelectedValueChanged
        If tdbcInterviewLevel.SelectedIndex <= 0 Then
            tdbcInterviewLevelDetail.SelectedValue = ""
            tdbcIntStatusID.SelectedValue = "" : tdbcIntStatusID.Text = ""
        Else
            tdbcInterviewLevelDetail.SelectedIndex = tdbcInterviewLevel.SelectedIndex - 1
            tdbcIntStatusID.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'Dim dtTemp As DataTable = ReturnDataTable(SQLStoreD84P5000)
        'If dtTemp.Rows.Count = 0 Then Exit Sub

        ''Dim f As New D25F5000
        ''f.drData = dtTemp.Rows(0)
        ''f.ShowDialog()
        ''f.Dispose()
        'Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "drData", dtTemp.Rows(0))
        'CallFormShowDialog("D84D1140", "D84F5000", arrPro)

        'ID 104204 02.11.2017
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
        SetProperties(arrPro, "InterviewFileID", _interviewFileID)
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        'Kim Yến yêu cầu
        SetProperties(arrPro, "DateFrom", c1dateFromDate.Text)
        SetProperties(arrPro, "DateTo", c1dateToDate.Text)
        SetProperties(arrPro, "FormCall", Me.Name)
        CallFormShow(Me, "D25D0340", "D25F4080", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowPrinr(ByRef dr() As DataRow) As Boolean
        tdbgDetail.UpdateData()
        If tdbgDetail.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgDetail.Focus()
            Return False
        End If
        dr = dtGridDetail.Select("IsUsed = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbgDetail.Focus()
            tdbgDetail.SplitIndex = SPLIT0
            tdbgDetail.Col = COL1_IsUsed
            tdbgDetail.Row = 0
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD84P5000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/06/2014 04:12:37
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD84P5000() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tra du lieu cho cac bien khi goi form D84P5000" & vbCrLf)
        sSQL &= "Exec D84P5000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(_interviewFileID) 'VoucherID, varchar[50], NOT NULL
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
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbgDetail.Columns(COL1_CandidateID).DataField)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(_interviewFileID) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("D25F4080") & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbgDetail_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgDetail.FilterChange
        Try
            If (dtGridDetail Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgDetail, sFilter) ', sFilterServer) 'Nếu có Lọc khi In
            ReLoadTDBGridDetail()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgDetail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        If tdbgDetail.Columns(tdbgDetail.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgDetail.Splits(tdbgDetail.SplitIndex).DisplayColumns(tdbgDetail.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

#Region "Active Find - List All (Client)"
    Dim dtCaptionDetail As DataTable

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGridDetail()
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbgDetail.UpdateData()
        If dtCaptionDetail Is Nothing OrElse dtCaptionDetail.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbgDetail.Splits.Count - 1
                AddColVisible(tdbgDetail, i, Arr, , False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionDetail = CreateTableForExcelOnly(tdbgDetail, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionDetail, Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbgDetail, sFilter, bRefreshFilter)
        ReLoadTDBGridDetail()
    End Sub
#End Region


    Private Sub tdbgDetail_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ButtonClick
        If tdbgDetail.AllowUpdate = False Then Exit Sub
        If tdbgDetail.Splits(tdbgDetail.SplitIndex).DisplayColumns(tdbgDetail.Col).Locked Then Exit Sub
        Select Case tdbgDetail.Col
            Case COL1_Interviewer
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbgDetail, tdbgDetail.Columns(tdbgDetail.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbgDetail, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbgDetail.Col, dr)
        End Select
    End Sub
End Class