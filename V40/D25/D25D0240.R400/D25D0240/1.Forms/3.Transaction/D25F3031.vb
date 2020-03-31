Imports System
Public Class D25F3031
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg - Total of Columns: 43"
    Private Const COL_IsUsed As Integer = 0              ' Chọn
    Private Const COL_CandidateID As Integer = 1         ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 2       ' Tên ứng viên
    Private Const COL_InterviewFileName As Integer = 3   ' Lịch phỏng vấn
    Private Const COL_RecruitmentFileID As Integer = 4   ' Kế hoạch tuyển dụng
    Private Const COL_BlockID As Integer = 5             ' BlockID
    Private Const COL_BlockName As Integer = 6           ' Khối
    Private Const COL_DepartmentID As Integer = 7        ' DepartmentID
    Private Const COL_DepartmentName As Integer = 8      ' Phòng ban
    Private Const COL_TeamID As Integer = 9              ' TeamID
    Private Const COL_TeamName As Integer = 10           ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 11      ' RecPositionID
    Private Const COL_RecPositionName As Integer = 12    ' Vị trí
    Private Const COL_SexName As Integer = 13            ' Giới tính
    Private Const COL_Birthdate As Integer = 14          ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 15       ' Ngày nhận HS
    Private Const COL_ReceiverName As Integer = 16       ' Người nhận HS
    Private Const COL_ReceivedPlace As Integer = 17      ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 18      ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 19         ' Loại tiền
    Private Const COL_RecSourceID As Integer = 20        ' RecsourceID
    Private Const COL_RecSourceName As Integer = 21      ' Nguồn tuyển dụng
    Private Const COL_SuggesterName As Integer = 22      ' Người giới thiệu
    Private Const COL_InterviewLevels As Integer = 23    ' Vòng PV
    Private Const COL_InterViewLevelName As Integer = 24 ' InterViewLevelName
    Private Const COL_IntDate As Integer = 25            ' Ngày PV
    Private Const COL_IntTime As Integer = 26            ' Giờ PV
    Private Const COL_Interviewer As Integer = 27        ' Người PV
    Private Const COL_IntStatusID As Integer = 28        ' Kết quả PV
    Private Const COL_NewRecPositionID As Integer = 29   ' Vị trí tuyển mới
    Private Const COL_Content As Integer = 30            ' Nội dung PV
    Private Const COL_Result As Integer = 31             ' Đánh giá
    Private Const COL_EEValue01 As Integer = 32          ' Yếu tố đánh giá 01
    Private Const COL_EEValue02 As Integer = 33          ' Yếu tố đánh giá 02
    Private Const COL_EEValue03 As Integer = 34          ' Yếu tố đánh giá 03
    Private Const COL_EEValue04 As Integer = 35          ' Yếu tố đánh giá 04
    Private Const COL_EEValue05 As Integer = 36          ' Yếu tố đánh giá 05
    Private Const COL_EEValue06 As Integer = 37          ' Yếu tố đánh giá 06
    Private Const COL_EEValue07 As Integer = 38          ' Yếu tố đánh giá 07
    Private Const COL_EEValue08 As Integer = 39          ' Yếu tố đánh giá 08
    Private Const COL_EEValue09 As Integer = 40          ' Yếu tố đánh giá 09
    Private Const COL_EEValue10 As Integer = 41          ' Yếu tố đánh giá 10
    Private Const COL_InterviewFileID As Integer = 42    ' InterviewFileID
#End Region


    Private _interviewFileID As String = ""
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property

    Private _creatorID As String = ""
    Public WriteOnly Property  CreatorID() As String
        Set(ByVal Value As String)
            _creatorID = Value
        End Set
    End Property

    Private _candidateID As String = ""
    Public Property CandidateID() As String 
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String )
            _candidateID = Value
        End Set
    End Property

    Private _voucherDateFrom As Date = Now.Date
    Public WriteOnly Property VoucherDateFrom() As Date
        Set(ByVal Value As Date)
            _voucherDateFrom = Value
        End Set
    End Property

    Private _voucherDateTo As Date = Now.Date
    Public WriteOnly Property VoucherDateTo() As Date
        Set(ByVal Value As Date)
            _voucherDateTo = Value
        End Set
    End Property

    Private _isMSS As Integer = 0
    Public WriteOnly Property  IsMSS() As Integer 
        Set(ByVal Value As Integer )
            _isMSS = Value
        End Set
    End Property

    Private _formCall As String = ""
    Public WriteOnly Property FormCall() As String 
        Set(ByVal Value As String )
            _formCall = Value
        End Set
    End Property

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

    Dim dtGrid As DataTable = Nothing
    Dim dtTeamID As DataTable = Nothing
    Dim dtDepartmentID As DataTable = Nothing

    Dim bIsFilter As Boolean = False

    Private Sub D25F3031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
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
    End Sub

    Private Sub D25F3031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        ResetFooterGrid(tdbg, SPLIT0, SPLIT2)
        ResetSplitDividerSize(tdbg)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadCaption()

        VisibleBlock()
        LoadTDBCombo()
        LoadTDBDropDown()
        InputDateInTrueDBGrid(tdbg, COL_IntDate)

   
        '********************
        '*****Tạo thêm cột đính kèm cho lưới
        CreateColAttach(tdbg)

        CallD09U1111_Button(True)
        '*****************************************
        UseFilterCheckCombo(tdbcInterviewFileID)
        '*******************
        InputbyUnicode(Me, gbUnicode)
        ' CheckIdTextBox(txtCandidateID, txtCandidateID.MaxLength, False)
        '*****************************************
        InputDateCustomFormat(c1dateVoucherDateFrom, c1dateVoucherDateTo)
        InputDateInTrueDBGrid(tdbg, COL_Birthdate, COL_ReceivedDate)
        '****************************************

        'Dim DateLast As String = Date.DaysInMonth(Now.Year, Now.Month).ToString
        '_voucherDateFrom = Date.Parse("01/" & Now.Month & "/" & Now.Year) 'CType(Now.Month & "/1", Date)
        '_voucherDateTo = Date.Parse(DateLast & "/" & Now.Month & "/" & Now.Year)


        '****************************************
        'LoadDefault()

        LoadDefault()
        '********************'
        'id 71427 12/6/2015  Tự động kích hoạt nút lọc khi gọi từ màn hình D25F3040
        If _formCall = "D25F3040" Then
            btnFilter_Click(Nothing, Nothing)
        End If

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_IsUsed}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_DesiredSalary).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue01).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue02).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue03).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue04).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue05).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue06).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue07).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue08).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue09).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue10).NumberFormat = D25Format.DefaultNumber2
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_gia_ket_qua_phong_van_-_D25F3031") & UnicodeCaption(gbUnicode) '˜Ành giÀ kÕt qu¶ phàng vÊn - D25F3031
        '================================================================ 
        lblteVoucherDateFrom.Text = rl3("Ngay_lap") 'Ngày lập
        lblInterviewFileID.Text = rl3("Lich_PV") 'Lịch PV
        ' lblCandidateID.Text = rl3("Ma_ung_vien") 'Mã ứng viên
        'lblCandidateName.Text = rl3("Ten_ung_vien") 'Tên ứng viên
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnEvaluationElement.Text = rl3("Chi_tieu__yeu_cau") 'Chỉ tiêu &yêu cầu
        btnSendEmail.Text = rL3("Gui_mail") 'Gửi mail
        '================================================================ 
        chkShowSelectedDataOnly.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcInterviewFileID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcInterviewFileID.Columns("InterviewFileName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdInterviewerID.Columns("InterviewerID").Caption = rl3("Ma") 'Mã
        tdbdInterviewerID.Columns("InterviewerName").Caption = rl3("Ten") 'Tên
        tdbdIntStatusID.Columns("IntStatusID").Caption = rl3("Ma") 'Mã
        tdbdIntStatusID.Columns("IntStatusName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        lblCreatorID.Text = rL3("Nguoi_lap") 'Người lập
        '================================================================ 
        tdbcCreatorID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbcCreatorID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên


        tdbdInterViewLevelName.Columns(0).Caption = rl3("Ma") 'Mã
        tdbdInterViewLevelName.Columns(1).Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rL3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns("InterviewFileName").Caption = rL3("Lich_phong_van") 'Lịch phỏng vấn
        tdbg.Columns("RecruitmentFileID").Caption = rL3("Ke_hoach_tuyen_dung") 'Kế hoạch tuyển dụng
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Tên vị trí
        tdbg.Columns(COL_InterViewLevels).Caption = rl3("Vong_PV") 'Vòng PV
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ReceivedDate").Caption = rl3("Ngay_nhan_HS") 'Ngày nhận HS
        tdbg.Columns("ReceiverName").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("SuggesterName").Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
        tdbg.Columns("IntDate").Caption = rl3("Ngay_PV") 'Ngày PV
        tdbg.Columns("IntTime").Caption = rl3("Gio_PV") 'Giờ PV
        tdbg.Columns("Interviewer").Caption = rl3("Nguoi_PV") 'Người PV
        tdbg.Columns("IntStatusID").Caption = rl3("Ket_qua_PV") 'Kết quả PV
        tdbg.Columns("Content").Caption = rl3("Noi_dung_PV") 'Nội dung PV
        tdbg.Columns("Result").Caption = rL3("Danh_gia") 'Đánh giá
        tdbg.Columns("NewRecPositionID").Caption = rL3("Vi_tri_tuyen_moi")

        '================================================================ 
        tdbdNewRecPositionID.Columns("NewRecPositionID").Caption = rL3("Ma") 'Mã
        tdbdNewRecPositionID.Columns("NewRecPositionName").Caption = rL3("Ten") 'Tên


    End Sub

    Private Sub SetBackColorObligatory()
        c1dateVoucherDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        ' tdbcInterviewFileID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        ' tdbcCreatorID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_IntStatusID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_CandidateID To COL_SuggesterName
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).AllowFocus = False
        Next
    End Sub

    Private Sub LoadTDBCombo()
        'Load tdbcCreatorID
        LoadCboCreateByG4(tdbcCreatorID, Me.Name, _isMSS)

    End Sub

    'id 72877 22/04/2015
    Private Sub LoadtdbcInterviewFileID()
        'LoadDataSource(tdbcInterviewFileID, ReturnTableFilter(dtInterviewFileID, "CreatorID=" & SQLString(sCreatorID), True), True)

        Dim sSQL As String = ""
        sSQL = "SELECT	InterviewFileID, VoucherNo, InterviewFileName" & UnicodeJoin(gbUnicode) & " AS InterviewFileName, RecruitmentFileID, InterviewLevel" & vbCrLf
        sSQL &= "FROM	D25T2010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE StatusID = 3" & vbCrLf
        sSQL &= "AND VoucherDate BETWEEN " & SQLDateSave(c1dateVoucherDateFrom.Value) & " AND " & SQLDateSave(c1dateVoucherDateTo.Value) & vbCrLf
        'sSQL &= "AND CreatorID = " & SQLString(ReturnValueC1Combo(tdbcCreatorID, "EmployeeID")) & vbCrLf
        sSQL &= "AND CreatorID = CASE WHEN " & SQLString(ReturnValueC1Combo(tdbcCreatorID, "EmployeeID")) & " = " & SQLString("") & "  THEN CreatorID ELSE " & SQLString(ReturnValueC1Combo(tdbcCreatorID, "EmployeeID")) & " END " & vbCrLf
        sSQL &= "ORDER BY InterviewFileName"
        LoadDataSource(tdbcInterviewFileID, sSQL, gbUnicode)
    End Sub

    'Private Sub LoadtdbcInterviewFileID()
    '    Dim sSQL As String = ""
    '    sSQL = "SELECT InterviewFileID, VoucherNo, InterviewFileName" & UnicodeJoin(gbUnicode) & " AS InterviewFileName, RecruitmentFileID, InterviewLevel" & vbCrLf
    '    sSQL &= "FROM D25T2010 WITH(NOLOCK) " & vbCrLf
    '    sSQL &= "WHERE StatusID = 3 And VoucherDate BETWEEN " & SQLDateSave(c1dateVoucherDateFrom.Value) & " AND " & SQLDateSave(c1dateVoucherDateTo.Value) & vbCrLf
    '    sSQL &= "ORDER BY   InterviewFileID"
    '    LoadDataSource(tdbcInterviewFileID, sSQL, gbUnicode)
    '    tdbcInterviewFileID.Text = ""
    'End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdInterviewerID
        sSQL = "SELECT     InterviewerID, InterviewerName" & UnicodeJoin(gbUnicode) & " AS InterviewerName" & vbCrLf
        sSQL &= "FROM       D25T1070  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY   InterviewerID"

        LoadDataSource(tdbdInterviewerID, sSQL, gbUnicode)

        'Load tdbdIntStatusID
        'sSQL = "Select     '00001' as IntStatusID, "
        'sSQL &= IIf(gbUnicode, "N'Đạt'", "'Ñaït'").ToString() & " as IntStatusName " & vbCrLf
        'sSQL &= "Union	" & vbCrLf
        'sSQL &= "Select     '00002' as IntStatusID, "
        'sSQL &= IIf(gbUnicode, "N'Không đạt'", "'Khoâng ñaït'").ToString() & " as IntStatusName" & vbCrLf
        'sSQL &= "Union	" & vbCrLf
        'sSQL &= "Select     '00003' as IntStatusID, "
        'sSQL &= IIf(gbUnicode, "N'Không tham gia phỏng vấn'", "'Khoâng tham gia phoûng vaán'").ToString() & " as IntStatusName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        'sSQL &= "Select     '00004' as IntStatusID, "
        'sSQL &= IIf(gbUnicode, "N'Dời lịch phỏng vấn'", "'Dôøi lòch phoûng vaán'").ToString() & " as IntStatusName" & vbCrLf
        ''sSQL &= "Union" & vbCrLf
        ''sSQL &= "Select     '00005' as IntStatusID, "
        ''sSQL &= IIf(gbUnicode, "N'Đạt nhưng không nhận việc'", "'Ñaït nhöng khoâng nhaän vieäc'").ToString() & " as IntStatusName" & vbCrLf
        'sSQL &= "Order by   IntStatusID"

        LoadDataSource(tdbdIntStatusID, SQLUDFD25N5555, gbUnicode)

        'Load tdbdNewRecPositionID
        LoadDataSource(tdbdNewRecPositionID, SQLStoreD25P0001, gbUnicode)

        sSQL = "-- Do nguon Combo Vòng PV: " & vbCrLf & _
           "Select 	InterviewLevel AS InterviewLevels, LevelName" & gsLanguage & UnicodeJoin(gbUnicode) & " AS InterViewLevelName" & vbCrLf & _
           "From 	D25V2015 " & vbCrLf & _
           "Order by 	No"
        LoadDataSource(tdbdInterViewLevelName, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        If _voucherDateFrom = Now.Date Then
            Dim DateLast As String = Date.DaysInMonth(Now.Year, Now.Month).ToString
            '_voucherDateFrom = Date.Parse("01/" & Now.Month & "/" & Now.Year) 'CType(Now.Month & "/1", Date)
            _voucherDateTo = Date.Parse(DateLast & "/" & Now.Month & "/" & Now.Year)
        End If
        If _voucherDateTo = Now.Date Then
            Dim DateLast As String = Date.DaysInMonth(Now.Year, Now.Month).ToString
            _voucherDateTo = Date.Parse(DateLast & "/" & Now.Month & "/" & Now.Year)
        End If
        c1dateVoucherDateFrom.Value = _voucherDateFrom
        c1dateVoucherDateTo.Value = _voucherDateTo
        ' tdbcInterviewFileID.SelectedValue = _interviewFileID
        If _creatorID <> "" Then
            tdbcCreatorID.SelectedValue = _creatorID
            SetValueCombo(tdbcInterviewFileID, _interviewFileID)
        Else
            GetTextCreateByG4(tdbcCreatorID)
        End If

    End Sub

    Private Sub VisibleBlock()
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim dtSelected As DataTable = Nothing
        If dtGrid IsNot Nothing Then
            dtSelected = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        End If

        dtGrid = ReturnDataTable(SQLStoreD25P3032())

        If dtSelected IsNot Nothing Then
            If dtSelected.Rows.Count > 0 Then
                Dim keyCol() As DataColumn = {dtSelected.Columns("CandidateID"), dtSelected.Columns("InterviewFileID"), dtSelected.Columns("RecruitmentFileID")}
                dtSelected.PrimaryKey = keyCol
                Dim keyCol1() As DataColumn = {dtGrid.Columns("CandidateID"), dtGrid.Columns("InterviewFileID"), dtGrid.Columns("RecruitmentFileID")}
                dtGrid.PrimaryKey = keyCol1
                'Dim dtTmp As DataTable = dtGrid.DefaultView.ToTable(True, "CandidateID")
                dtGrid.Merge(dtSelected, False, MissingSchemaAction.AddWithKey)
            End If
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_DepartmentName)
        If tdbg.RowCount > 0 Then
            btnEvaluationElement.Enabled = L3Bool(tdbg(0, COL_IsUsed))
        Else
            btnEvaluationElement.Enabled = False
        End If
        'CreateColAttach(tdbg)
    End Sub

    Private Sub tdbg_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If e.Column.DataColumn.DataField <> "Button" Then Exit Sub
        Dim tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        CallD91F4010("D25T2011", tdbg.Columns(COL_CandidateID).Text, tdbg.Columns(COL_InterviewFileID).Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowChoose() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next

        If bFlag = False Then
            D99C0008.MsgNotYetChoose(rl3("De_xuat_tuyen_dung"))
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        chkShowSelectedDataOnly.Checked = False
        btnFilter.Enabled = False
        bIsFilter = True
        LoadTDBGrid()
        btnFilter.Enabled = True
    End Sub

    Private Function AllowFilter() As Boolean
        If c1dateVoucherDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_tu"))
            c1dateVoucherDateFrom.Focus()
            Return False
        End If
        If c1dateVoucherDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_den"))
            c1dateVoucherDateTo.Focus()
            Return False
        End If

        'If ReturnValueC1Combo(tdbcCreatorID) = "" Then
        '    D99C0008.MsgNotYetChoose(rL3(lblCreatorID.Text))
        '    tdbcCreatorID.Focus()
        '    Return False
        'End If
        'If ReturnValueC1Combo(tdbcInterviewFileID) = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Lich_PV"))
        '    tdbcInterviewFileID.Focus()
        '    Return False
        'End If
        'If tdbcInterviewFileID.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(lblInterviewFileID.Text)
        '    tdbcInterviewFileID.Focus()
        '    Return False
        'End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next
        If bFlag = False Then
            D99C0008.MsgNotYetEnter(rL3("Chon"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Bookmark = 0
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                If tdbg(i, COL_IntStatusID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ket_qua_PV"))
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = COL_IntStatusID
                    tdbg.Bookmark = i
                    Return False
                End If

                If tdbg(i, COL_IntStatusID).ToString = "00005" And tdbg(i, COL_NewRecPositionID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_NewRecPositionID).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = COL_NewRecPositionID
                    tdbg.Bookmark = i
                    Return False
                End If

                If tdbg(i, COL_IntTime).ToString <> "" Then
                    If tdbg(i, COL_IntTime).ToString().Length >= 4 Then
                        Dim sHour As String = ""
                        Dim sMinute As String = ""

                        If tdbg(i, COL_IntTime).ToString().IndexOf(":") >= 0 Then
                            sHour = tdbg(i, COL_IntTime).ToString().Substring(0, 2)
                            sMinute = tdbg(i, COL_IntTime).ToString().Substring(3, 2)
                        Else
                            sHour = tdbg(i, COL_IntTime).ToString().Substring(0, 2)
                            sMinute = tdbg(i, COL_IntTime).ToString().Substring(2, 2)
                        End If

                        If Number(sHour) > 24 Or Number(sMinute) > 59 Then
                            D99C0008.MsgL3(rL3("Gio_PV") & " " & rL3("khong_hop_le"))
                            tdbg.Focus()
                            tdbg.SplitIndex = SPLIT2
                            tdbg.Col = COL_IntTime
                            tdbg.Bookmark = i
                            Return False
                        End If
                    Else
                        D99C0008.MsgL3(rL3("Gio_PV") & " " & rL3("khong_hop_le"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT2
                        tdbg.Col = COL_IntTime
                        tdbg.Bookmark = i
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Dim bRunSQL As Boolean

        'ID 101634 31.10.2017 Bỏ câu Update,lưu = Bulk Copy
        'sSQL.Append(SQLUpdateD25T2011s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD25P3036.ToString & vbCrLf)

        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD25P3033.ToString & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)

        Dim oBulkCopy As New Lemon3.Data.SqlClient.SqlBulk()
     
        oBulkCopy.AddSQLAfter(sSQL.ToString)
        bRunSQL = oBulkCopy.SaveBulkCopy(dtGrid, "#F3031_" & gsUserID) 'CheckStore có thông báo Lưu thành công
        'bRun = oBulkCopy.SaveBulkCopy(dtGrid, "#DxxTxxxx") 'Lưu bình thường không thông báo

        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSendEmail.Enabled = True
            btnEvaluationElement.Enabled = ReturnPermission("D25F3030") >= 2
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

#Region "Events tdbcInterviewFileID"

    Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcInterviewFileID.KeyDown
        '        If gbUnicode Then Exit Sub
        '        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        '        Select Case e.KeyCode
        '            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
        '                tdbcName.AutoCompletion = False
        '            Case Else
        '                tdbcName.AutoCompletion = True
        '        End Select
    End Sub


    Private Sub tdbcInterviewFileID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Leave
        '        If gbUnicode Then Exit Sub
        '        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        '
        '        If tdbcName.SelectedIndex <> -1 Then
        '            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        '        End If

    End Sub

    Private Sub tdbcInterviewFileID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.SelectedValueChanged
        'If dtGrid IsNot Nothing Then dtGrid.Clear()
    End Sub

#Region "Events tdbcInterviewFileID"

    Private Sub tdbcInterviewFileID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.LostFocus
        '   If tdbcInterviewFileID.FindStringExact(tdbcInterviewFileID.Text) = -1 Then tdbcInterviewFileID.Text = ""
    End Sub

    Private Sub tdbcInterviewFileID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcInterviewFileID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Validated
        '        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        '        tdbc.Text = tdbc.WillChangeToText
        FilterCheckCombo(tdbcInterviewFileID, e)
    End Sub

#End Region

#Region "Events tdbcCreatorID"

    Private Sub tdbcCreatorID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.SelectedValueChanged
        'If tdbcCreatorID.SelectedValue Is Nothing OrElse tdbcCreatorID.Text = "" Then
        '    tdbcInterviewFileID.Text = ""
        '    Exit Sub
        'End If
        LoadtdbcInterviewFileID()
        tdbcInterviewFileID.Text = ""
    End Sub

    'Private Sub tdbcCreatorID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
    '    If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then
    '        tdbcCreatorID.Text = ""
    '        tdbcInterviewFileID.Text = ""
    '        Exit Sub
    '    End If
    'End Sub
#End Region

#Region "Events tdbcCreatorID"

    Private Sub tdbcCreatorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
        If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then tdbcCreatorID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub



    'Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Close
    '    'tdbcName_Validated(sender, Nothing)
    'End Sub

    'Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Validated
    '    'Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    'tdbc.Text = tdbc.WillChangeToText
    '    FilterCheckCombo(tdbcInterviewFileID, e)
    'End Sub

#End Region

#Region "SQL, Store"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3032
    '# Created User: xuanhoa
    '# Created Date: 22/04/2015 10:08:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3032() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D25P3032 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Text) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Text) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLCombo(tdbcInterviewFileID, True) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateName, nvarchar[150], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D25F3040") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcCreatorID)) 'CreatorID, varchar[50], NOT NULL
        ' sSQL &= SQLCombo(tdbcCreatorID, True) 'CreatorID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3036
    '# Created User: Kim Long
    '# Created Date: 31/10/2017 11:03:31
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3036() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Insert Bulk " & vbCrlf)
        sSQL &= "Exec D25P3036 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P0050
    '# Created User: 
    '# Created Date: 05/07/2010 01:56:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P0050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P0050 "
        sSQL &= SQLString("D25T2011") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2011s
    '# Created User: 
    '# Created Date: 05/07/2010 01:57:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2011s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1

            If L3Bool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append("-- Luu khi danh gia ket qua phong van tung lich" & vbCrLf)
                sSQL.Append("Update D25T2011 Set ")

                sSQL.Append("IntDate = " & SQLDateSave(tdbg(i, COL_IntDate)) & COMMA) 'datetime, NULL
                sSQL.Append("IntTime = " & SQLString(tdbg(i, COL_IntTime).ToString().Replace(":", "")) & COMMA) 'varchar[4], NOT NULL
                sSQL.Append("Interviewer = " & SQLString(tdbg(i, COL_Interviewer)) & COMMA) 'varchar[50], NULL
                sSQL.Append("InterViewLevels = " & SQLString(tdbg(i, COL_InterviewLevels)) & COMMA) 'varchar[50], NULL
                'sSQL.Append("InterviewerU = " & SQLStringUnicode(tdbg(i, COL_Interviewer), gbUnicode, True) & COMMA) 'varchar[50], NULL
                sSQL.Append("IntStatusID = " & SQLString(tdbg(i, COL_IntStatusID)) & COMMA) 'varchar[20], NULL
                sSQL.Append("Content = " & SQLStringUnicode(tdbg(i, COL_Content), gbUnicode, False) & COMMA) 'varchar[500], NULL
                sSQL.Append("ContentU = " & SQLStringUnicode(tdbg(i, COL_Content), gbUnicode, True) & COMMA) 'varchar[500], NULL
                sSQL.Append("Result = " & SQLStringUnicode(tdbg(i, COL_Result), gbUnicode, False) & COMMA) 'varchar[500], NULL
                sSQL.Append("ResultU = " & SQLStringUnicode(tdbg(i, COL_Result), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
                sSQL.Append("EEValue01 = " & SQLMoney(tdbg(i, COL_EEValue01)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue02 = " & SQLMoney(tdbg(i, COL_EEValue02)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue03 = " & SQLMoney(tdbg(i, COL_EEValue03)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue04 = " & SQLMoney(tdbg(i, COL_EEValue04)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue05 = " & SQLMoney(tdbg(i, COL_EEValue05)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue06 = " & SQLMoney(tdbg(i, COL_EEValue06)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue07 = " & SQLMoney(tdbg(i, COL_EEValue07)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue08 = " & SQLMoney(tdbg(i, COL_EEValue08)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue09 = " & SQLMoney(tdbg(i, COL_EEValue09)) & COMMA) 'decimal, NOT NULL
                sSQL.Append("EEValue10 = " & SQLMoney(tdbg(i, COL_EEValue10))) 'decimal, NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("InterviewFileID = " & SQLString(tdbg(i, COL_InterviewFileID))) 'varchar[20], NOT NULL
                sSQL.Append(" AND CandidateID = " & SQLString(tdbg(i, COL_CandidateID))) 'varchar[20], NOT NULL
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If

        Next
        Return sRet
    End Function
#End Region

#Region "Grid Events"

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub


    Dim bNotInList As Boolean = False

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_IntStatusID
                tdbg.Columns(COL_NewRecPositionID).Text = ""
            Case COL_IsUsed
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
                btnEvaluationElement.Enabled = L3Bool(tdbg(tdbg.Row, COL_IsUsed))
            Case COL_IntTime
                If tdbg.Columns(COL_IntTime).Value.ToString.Length = 4 Then
                    Dim sTime As String = tdbg.Columns(COL_IntTime).Value.ToString
                    Dim sHour As String = sTime.Substring(0, 2)
                    Dim sMinute As String = sTime.Substring(2, 2)

                    If sHour.Trim = "" Then sHour = "00"
                    If sMinute.Trim = "" Then sMinute = "00"
                    If sHour.Trim.Length = 1 Then sHour = "0" & sHour
                    If sMinute.Trim.Length = 1 Then sMinute = "0" & sMinute

                    tdbg.Columns(COL_IntTime).Value = sHour & sMinute
                    tdbg.UpdateData()
                    tdbg.Columns(COL_IntTime).Value = sHour & sMinute
                ElseIf tdbg.Columns(COL_IntTime).Value.ToString.Length = 3 Then
                    Dim sTime As String = tdbg.Columns(COL_IntTime).Value.ToString
                    Dim sHour As String = sTime.Substring(0, 2)
                    Dim sMinute As String = sTime.Substring(2, 1)

                    If sHour.Trim = "" Then sHour = "00"
                    If sMinute.Trim = "" Then sMinute = "00"
                    If sHour.Trim.Length = 1 Then sHour = "0" & sHour
                    If sMinute.Trim.Length = 1 Then sMinute = "0" & sMinute

                    tdbg.Columns(COL_IntTime).Value = sHour & sMinute
                    tdbg.UpdateData()
                    tdbg.Columns(COL_IntTime).Value = sHour & sMinute
                End If
            Case COL_InterviewLevels
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InterviewLevels).Text = ""
                    tdbg.Columns(COL_InterViewLevelName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_InterViewLevelName).Text = tdbdInterviewerID.Columns("InterviewerName").Text
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_Interviewer
                'If tdbg.Columns(COL_Interviewer).Text <> tdbdInterviewerID.Columns("InterviewerID").Text Then
                '    tdbg.Columns(COL_Interviewer).Text = ""
                'End If
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    'bNotInList = True
                End If
            Case COL_IntStatusID
                If tdbg.Columns(COL_IntStatusID).Value.ToString <> tdbdIntStatusID.Columns("IntStatusID").Text Then
                    tdbg.Columns(COL_IntStatusID).Text = ""
                    tdbg.Columns(COL_NewRecPositionID).Text = ""
                End If
            Case COL_NewRecPositionID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_InterviewLevels
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_EEValue01
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue01).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue02
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue02).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue03
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue03).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue04
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue04).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue05
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue05).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue06
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue06).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue07
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue07).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue08
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue08).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue09
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue09).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_EEValue10
                If Not L3IsNumeric(tdbg.Columns(COL_EEValue10).Text, EnumDataType.Money) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_DesiredSalary
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue06
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue07
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue08
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue09
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EEValue10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_IsUsed, e, SPLIT0)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Dim bSelect As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub

        Select Case iCol
            Case COL_IsUsed
                L3HeadClick(tdbg, COL_IsUsed, bSelect)
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()

            Case COL_IntDate To COL_Interviewer, COL_Content To COL_EEValue10 'Các cột nhập liệu
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
                CopyColumnsArr(tdbg, iCol, COL_IsUsed)
            Case COL_IntStatusID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
                CopyColumnsArr(tdbg, iCol, COL_IsUsed, New Integer() {COL_NewRecPositionID})
            Case COL_NewRecPositionID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
                CopyColumnsArr(tdbg, iCol, COL_IsUsed, New Integer() {COL_IntStatusID})
        End Select
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case tdbg.Col
            Case COL_IsUsed
            Case Else
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Col
            Case COL_Interviewer
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Columns(COL_Interviewer).DropDown = tdbdInterviewerID
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                    'tdbg.Columns(COL_NewRecPositionID).DropDown = tdbdNewRecPositionID
                    'tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                Else
                    tdbg.Columns(COL_Interviewer).DropDown = Nothing
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                End If
                'Case COL_IntStatusID
                '    If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                '        tdbg.Columns(COL_IntStatusID).DropDown = tdbdIntStatusID
                '        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                '    Else
                '        tdbg.Columns(COL_IntStatusID).DropDown = Nothing
                '        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                '    End If
            Case COL_NewRecPositionID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                    If L3String(tdbg.Columns(COL_IntStatusID).Value) <> "00005" Then
                        e.CellStyle.Locked = True
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = False
                    Else
                        e.CellStyle.Locked = False
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = True
                    End If
                Else
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = False
                End If
            Case Else
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                Else
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                End If
        End Select
    End Sub

#End Region

    Private Sub chkShowSelectedDataOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSelectedDataOnly.Click
        If Not bIsFilter Then Exit Sub

        If chkShowSelectedDataOnly.Checked Then
            dtGrid.DefaultView.RowFilter = "IsUsed = True"
        Else
            dtGrid.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub c1dateVoucherDateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateFrom.ValueChanged
        LoadtdbcInterviewFileID()
    End Sub

    Private Sub c1dateVoucherDateTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateTo.ValueChanged
        LoadtdbcInterviewFileID()
    End Sub

    Dim iLastCol As Integer = COL_Result
    Private Sub LoadCaption()
        Dim sSQL As String = ""
        Dim dtSpec As New DataTable

        sSQL = SQLStoreD25P0050()
        dtSpec = ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            If CBool(dtSpec.Rows(i).Item("Disabled").ToString) Then
                tdbg.Splits(SPLIT2).DisplayColumns(COL_EEValue01 + i).Visible = False
            Else
                iLastCol = COL_EEValue01 + i
            End If

            tdbg.Splits(SPLIT2).DisplayColumns(COL_EEValue01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Columns(COL_EEValue01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

    Private Sub btnEvaluationElement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvaluationElement.Click
        Dim frm As New D25F3032
        frm.InterviewFileID = tdbg.Columns(COL_InterviewFileID).Text
        frm.CandidateID = tdbg.Columns(COL_CandidateID).Text
        frm.CandidateName = tdbg.Columns(COL_CandidateName).Text
        frm.SexName = tdbg.Columns(COL_SexName).Text
        frm.BirthDate = tdbg.Columns(COL_Birthdate).Text
        frm.RecPositionID = tdbg.Columns(COL_RecPositionID).Text
        frm.RecPositionName = tdbg.Columns(COL_RecPositionName).Text
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        btnEvaluationElement.Enabled = L3Bool(tdbg(tdbg.Row, COL_IsUsed)) 'And ExistRecord("Select Top 1 1 From D25T2011 Where InterviewFileID = " & SQLString(ReturnValueC1Combo(tdbcInterviewFileID)) & " AND CandidateID = " & SQLString(tdbg(tdbg.Row, COL_CandidateID).ToString))
        Select Case tdbg.Col
            Case COL_IntStatusID
                tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = L3Bool(tdbg.Columns(COL_IsUsed).Text)
                tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = Not tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3033
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 03/09/2013 11:05:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3033() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat trang thai cho ke hoach tuyen dung: 2 bien lay tu combo lich phong van" & vbCrLf)
        sSQL &= "Exec D25P3033 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcInterviewFileID, "RecruitmentFileID").ToString) & COMMA 'RecruitmentFileID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcInterviewFileID, "InterviewLevel").ToString) & COMMA  'InterviewLevel, varchar[10], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL

    End Function

    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4080
        'f.ID03 = ReturnValueC1Combo(tdbcInterviewFileID).ToString
        'f.ID04 = c1dateVoucherDateFrom.Value.ToString
        'f.ID05 = c1dateVoucherDateTo.Value.ToString
        'f.ID06 = Me.Name
        ''.CandidateID = PARA_ID01
        ''.CandidateName = PARA_ID02
        ''.InterviewFileID = PARA_ID03
        ''.DateFrom = PARA_ID04
        ''.DateTo = PARA_ID05
        ''.FormCall = PARA_ID06
        'f.ShowDialog()
        'f.Dispose()
        'id 71427 12/6/2015
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If Not bRunSQL Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "InterviewFileID", ReturnValueC1Combo(tdbcInterviewFileID))
        SetProperties(arrPro, "DateFrom", L3String(c1dateVoucherDateFrom.Value))
        SetProperties(arrPro, "DateTo", L3String(c1dateVoucherDateTo.Value))
        SetProperties(arrPro, "FormCall", "D25F3040")

        CallFormShowDialog("D25D0340", "D25F4080", arrPro)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: xuanhoa
    '# Created Date: 22/04/2015 11:16:13
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim dr() As DataRow = dtGrid.Select("IsUsed=1")
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang tam D09T6666" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, " & vbCrLf)
            sSQL.Append("FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("InterviewFileID").ToString) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("CandidateID")) & COMMA & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            'sSQL.Append(SQLString("D25F3031")) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D25F3040")) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: xuanhoa
    '# Created Date: 22/04/2015 11:24:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete bang tam D09T6666" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        ' sSQL &= "FormID = " & SQLString("D25F3031")
        sSQL &= "FormID = " & SQLString("D25F3040")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD25N5555
    '# Created User: Kim Long
    '# Created Date: 31/10/2017 10:12:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD25N5555() As String
        Dim sSQL As String = ""
        sSQL &= "SELECT ID as IntStatusID,Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as IntStatusName  from D25N5555("
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P0001
    '# Created User: Kim Long
    '# Created Date: 31/10/2017 10:33:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P0001() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Dropdown Vi tri tuyen moi  " & vbCrlf)
        sSQL &= "Exec D25P0001 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function




End Class