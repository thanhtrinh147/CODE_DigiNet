Imports System.Windows.Forms
Imports System

Public Class D13F2081
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim dtGrid As DataTable 'Bảng chứa dữ liệu của lưới
    Dim dtTemp As DataTable 'Bảng chứa dữ liệu từ câu SQL
    Dim dtFind, dtOrg As DataTable

    Dim dtDepartmentID, dtTeamID, dtEmployeeID As DataTable
    Dim bButtonChoose As Boolean = False
    Dim iLastCol As Integer

#Region "Chuẩn hóa D09U1111 B1: đinh nghĩa biến"
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption1 As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Private _isCallFromAlert As Boolean = False
    Public WriteOnly Property IsCallFromAlert() As Boolean
        Set(ByVal Value As Boolean)
            _isCallFromAlert = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _pITYear As String = ""
    Public WriteOnly Property PITYear() As String
        Set(ByVal Value As String)
            _pITYear = Value
        End Set
    End Property

    '#Region "Const of tdbg"
    '    Private Const COL_IsUsed As Integer = 0         ' Chọn
    '    Private Const COL_DepartmentID As Integer = 1   ' Phòng ban
    '    Private Const COL_TeamID As Integer = 2         ' Tổ nhóm
    '    Private Const COL_EmployeeID As Integer = 3     ' Mã nhân viên
    '    Private Const COL_EmployeeName As Integer = 4   ' Họ và tên
    '    Private Const COL_DateJoined As Integer = 5     ' Ngày vào làm
    '    Private Const COL_IsForeigner As Integer = 6    ' Là người nước ngoài
    '    Private Const COL_FirstDateToVN As Integer = 7  ' Ngày đầu tiên vào Việt Nam
    '    Private Const COL_ResidenceDay As Integer = 8   ' Số ngày cư trú trong năm QT
    '    Private Const COL_ReferenceNo As Integer = 9    ' Số tham chiếu
    '    Private Const COL_PITDate As Integer = 10       ' Ngày quyết toán
    '    Private Const COL_PITPeriodFrom As Integer = 11 ' Kỳ QT từ
    '    Private Const COL_PITPeriodTo As Integer = 12   ' Kỳ QT đến
    '    Private Const COL_PlanPITDate As Integer = 13   ' Ngày QT dự kiến
    '#End Region

    Private _callFromD13F2080 As Boolean = False
    Public WriteOnly Property CallFromD13F2080() As Boolean 
        Set(ByVal Value As Boolean )
            _callFromD13F2080 = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 35"
    Private Const COL_IsUsed As Integer = 0                          ' Chọn
    Private Const COL_EmployeeID As Integer = 1                      ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 2                    ' Họ và tên
    Private Const COL_BlockID As Integer = 3                         ' Khối
    Private Const COL_BlockName As Integer = 4                       ' Tên khối
    Private Const COL_DepartmentID As Integer = 5                    ' Phòng ban
    Private Const COL_DepartmentName As Integer = 6                  ' Tên phòng ban
    Private Const COL_TeamID As Integer = 7                          ' Tổ nhóm
    Private Const COL_TeamName As Integer = 8                        ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 9                      ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 10                   ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 11                         ' Chức vụ
    Private Const COL_DutyName As Integer = 12                       ' Tên chức vụ
    Private Const COL_WorkID As Integer = 13                         ' Công việc
    Private Const COL_WorkName As Integer = 14                       ' Tên công việc
    Private Const COL_BirthDate As Integer = 15                      ' Ngày sinh
    Private Const COL_SexName As Integer = 16                        ' Giới tính
    Private Const COL_DateJoined As Integer = 17                     ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 18                       ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 19                            ' Tuổi
    Private Const COL_StatusID As Integer = 20                       ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 21                     ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 22               ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 23                  ' Mã NV phụ
    Private Const COL_IsForeigner As Integer = 24                    ' Là người nước ngoài
    Private Const COL_FirstDateToVN As Integer = 25                  ' Ngày đầu tiên vào Việt Nam
    Private Const COL_ResidenceDay As Integer = 26                   ' Số ngày cư trú trong năm QT
    Private Const COL_ReferenceNo As Integer = 27                    ' Số tham chiếu
    Private Const COL_PITDate As Integer = 28                        ' Ngày quyết toán
    Private Const COL_PITPeriodFrom As Integer = 29                  ' Kỳ QT từ
    Private Const COL_PITPeriodTo As Integer = 30                    ' Kỳ QT đến
    Private Const COL_PlanPITDate As Integer = 31                    ' Ngày QT dự kiến
    Private Const COL_IncreaseGeneralIncomeAmount12m As Integer = 32 ' Tăng thu nhập chịu thuế
    Private Const COL_ReduceGeneralIncomeAmount12m As Integer = 33   ' Giảm thu nhập chịu thuế
    Private Const COL_DivisionID As Integer = 34                     ' DivisionID
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            _bSaved = False
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private Sub D13F2081_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.F  'Tìm kiếm
                    If tsbFind.Enabled And tsbFind.Visible Then tsbFind_Click(Nothing, Nothing)
                Case Keys.A 'Liệt kê tất cả
                    If tsbListAll.Enabled And tsbListAll.Visible Then tsbListAll_Click(Nothing, Nothing)
            End Select
        End If

        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption1.D09U1111Refresh()
                End If
            End If
            usrOption1.Hide()
        End If
    End Sub

    Private Sub D09F5605_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        LoadInfoGeneral()
        GetPITYear()
        gbEnabledUseFind = False
        SetBackColorObligatory()
        chkIsEmpStopWork_CheckedChanged(Nothing, Nothing)
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft)
        Loadlanguage()
        LoadTDBCombo()
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 1, 1)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadDefault()
        ResetGrid()
        If _isCallFromAlert Then
            chkIsInValid.Checked = True
            btnFilter_Click(Nothing, Nothing)
            If _employeeID <> "" Then
                dtGrid.DefaultView.RowFilter = "EmployeeID IN (" & _employeeID & ")"
                dtGrid = dtGrid.DefaultView.ToTable
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                FooterTotalGrid(tdbg, COL_EmployeeID)
                VisibledButton()
            End If

            LockMaster()
        End If
        '******************************
        'Dim iColRelative() As Integer = {COL_PITPeriodFrom, COL_PITPeriodTo}
        'CheckNumberTDBGrid(tdbg, iColRelative, EnumDataType.Int, EnumKey.Number)
        '******************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBoxG4(txtEmployeeID)
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        '******************************
        ' update 28/11/2012 id 51174
        If Not D13Systems.IsUseBlock Then
            tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Visible = False
            tdbcBlockID.Enabled = False
        End If
        '******************************
        ' update 16/11/2012 id 51174
        CallD09U1111(True)
        InputDateInTrueDBGrid(tdbg, COL_FirstDateToVN, COL_PITDate, COL_PlanPITDate)
        InputDateCustomFormat(c1dateDateLeftTo, c1dateDateLeftFrom)

        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LockMaster()
        tdbcPITYear.Text = ""
        ReadOnlyControl(tdbcPITYear)
        ReadOnlyControl(txtEmployeeID)
        ReadOnlyControl(txtEmployeeName)
        ReadOnlyControl(tdbcBlockID)
        ReadOnlyControl(tdbcDepartmentID)
        ReadOnlyControl(tdbcTeamID)
        ReadOnlyControl(tdbcWorkingStatusID)
        ReadOnlyControl(tdbcEmployeeID)
        chkIsValid.Enabled = False
        chkIsInValid.Enabled = False
        btnFilter.Enabled = False

        chkShowIsUsed.Enabled = False
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Quyet_toan_thue_-_D13F2081") & UnicodeCaption(gbUnicode) 'QuyÕt toÀn thuÕ - D13F2081
        '================================================================ 
        lblEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblEmployeeName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        Label1.Text = rl3("Nhan_vien") 'Nhân viên
        lblPITYear.Text = rl3("Nam_quyet_toan") 'Năm quyết toán
        '================================================================ 
        tsmInOut.Text = rl3("Thoi_gian_vao_-__ra_Viet_Nam") 'Thời gian vào - &ra Việt Nam
        mnsInOut.Text = tsmInOut.Text
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnChoose.Text = rl3("_Quyet_toan") '&Quyết toán
        btnSave.Text = rl3("_Luu") '&Lưu
        'Chuẩn hóa D09U1111 B5: Tại hàm LoadLanguage: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkShowIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        chkIsValid.Text = rl3("Thoa_dieu_kien") 'Thỏa điều kiện
        chkIsInValid.Text = rl3("Khong_thoa_dieu_kien") 'Không thỏa điều kiện
        chkIsEmpStopWork.Text = rl3("Bao_gom_NV_nghi_viec") 'Bao gồm NV nghỉ việc
        ' UPDATE 18/9/2013 ID 55320
        chkIsDependValidDate.Text = rl3("Tinh_so_thang_giam_tru_theo_ngay_hieu_luc") ' Tính số tháng giảm trừ theo ngày hiệu lực
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcPITYear.Columns("Year").Caption = rl3("Nam") 'Năm
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("IsForeigner").Caption = rl3("La_nguoi_nuoc_ngoai") 'Là người nước ngoài
        tdbg.Columns("FirstDateToVN").Caption = rl3("Ngay_dau_tien_vao_Viet_Nam") 'Ngày đầu tiên vào Việt Nam
        tdbg.Columns("ResidenceDay").Caption = rl3("So_ngay_cu_tru_trong_nam_QT") 'Số ngày cư trú trong năm QT
        tdbg.Columns("ReferenceNo").Caption = rl3("So_tham_chieu") 'Số tham chiếu
        tdbg.Columns("PITDate").Caption = rl3("Ngay_quyet_toan") 'Ngày quyết toán
        tdbg.Columns("PITPeriodFrom").Caption = rl3("Ky_QT_tuU") 'Kỳ QT từ
        tdbg.Columns("PITPeriodTo").Caption = rl3("Ky_QT_denU") 'Kỳ QT đến
        tdbg.Columns("PlanPITDate").Caption = rl3("Ngay_QT_du_kien") 'Ngày QT dự kiến

        ' update 15/11/2012 id 51174
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Họ và tên
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("DateLeft").Caption = rl3("Ngay_nghi_viec")
        tdbg.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh")
        tdbg.Columns("WorkID").Caption = rl3("Cong_viec")
        tdbg.Columns("WorkName").Caption = rl3("Ten_cong_viec")
        tdbg.Columns("Age").Caption = rl3("Tuoi")
        tdbg.Columns("StatusID").Caption = rl3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rl3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rl3("Ma_the_cham_cong")
        tdbg.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ

        '================================================================ 
        tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).Caption = rL3("Tang_thu_nhap_chiu_thue") 'Tăng thu nhập chịu thuế
        tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).Caption = rL3("Giam_thu_nhap_chiu_thue") 'Giảm thu nhập chịu thuế

    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPITYear.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_PITDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_PITPeriodFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_PITPeriodTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg, arr)

        'tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).NumberFormat = D13Format.DefaultNumber2
        'tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).NumberFormat = D13Format.DefaultNumber2

    End Sub


    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DateLeft).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Age).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_StatusID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_StatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AttendanceCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_IsForeigner).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_FirstDateToVN).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ResidenceDay).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        dtEmployeeID = ReturnTableEmployeeID(True, , gbUnicode)
        dtTeamID = ReturnTableTeamID(, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcWorkingStatusID
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

        'Load tdbcPITYear
        sSQL = "Select Distinct TranYear as Year From D09T9999  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by TranYear desc"
        LoadDataSource(tdbcPITYear, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        If _pITYear <> "" Then
            tdbcPITYear.Text = _pITYear
        Else
            tdbcPITYear.SelectedIndex = 0
        End If

        tdbcBlockID.SelectedValue = "%"
        tdbcWorkingStatusID.SelectedValue = "%"
        '**************************
        tdbg.Columns(COL_DateJoined).Editor = c1dateDateJoined
        tdbg.Columns(COL_PITDate).Editor = c1datePITDate
        tdbg.Columns(COL_PlanPITDate).Editor = c1datePlanPITDate

        c1dateDateLeftFrom.Value = Date.Now
        c1dateDateLeftTo.Value = Date.Now
    End Sub

#Region "Events tdbcPITYear"

    Private Sub tdbcPITYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITYear.LostFocus
        If tdbcPITYear.FindStringExact(tdbcPITYear.Text) = -1 Then tdbcPITYear.Text = ""
    End Sub

#End Region

#Region "Events tdbcBlockID with txtBlockName load tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcTeamID with txtTeamName"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then Exit Sub

        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, tdbcWorkingStatusID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmployeeID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcWorkingStatusID with txtWorkingStatusName"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then
            tdbcWorkingStatusID.Text = ""
        End If
    End Sub

    Private Sub tdbcWorkingStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.SelectedValueChanged
        If Not (tdbcWorkingStatusID.Tag Is Nothing OrElse tdbcWorkingStatusID.Tag.ToString = "") Then
            tdbcWorkingStatusID.Tag = ""
            Exit Sub
        End If
        If tdbcTeamID.SelectedValue Is Nothing Then Exit Sub
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", "-1", gbUnicode)

            Exit Sub
        End If
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, tdbcWorkingStatusID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        tdbcEmployeeID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen, tdbcEmployeeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, tdbcEmployeeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcWorkingStatusID.KeyUp, tdbcEmployeeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tsmInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInOut.Click, mnsInOut.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        SetProperties(arrPro, "EmployeeID", tdbg.Columns(COL_EmployeeID).Text)
        CallFormShowDialog("D09D1040", "D09F1360", arrPro)

        '        Dim frm As New D09F1360
        '        With frm
        '            .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, 0, Arr, , , , gbUnicode)
        AddColVisible(tdbg, 1, Arr, , , , gbUnicode)
        AddColVisible(tdbg, 2, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
        '*****************************************
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        chkShowIsUsed.Checked = False
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkShowIsUsed.Checked Then
            sFilter = "IsUsed=True"
        Else
            If sFind <> "" Then sFilter = "IsUsed=True" & " Or " & sFind
        End If
        dtGrid.DefaultView.RowFilter = sFilter
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        tsbFind.Enabled = (Not chkShowIsUsed.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        tsmFind.Enabled = tsbFind.Enabled
        mnsFind.Enabled = tsbFind.Enabled
        tsbListAll.Enabled = tsbFind.Enabled
        tsmListAll.Enabled = tsbListAll.Enabled
        mnsListAll.Enabled = tsbListAll.Enabled
        tsmInOut.Enabled = tdbg.RowCount > 0
        mnsInOut.Enabled = tsmInOut.Enabled
        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub
#End Region

    Private Sub LoadTDBGrid()
        '        Dim dtSelected As DataTable = Nothing
        '        If dtGrid IsNot Nothing Then
        '            If bIsSavedPIT = True Then
        '                bIsSavedPIT = False
        '                dtSelected = Nothing
        '            Else
        '                dtSelected = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        '            End If
        '        End If
        '        dtGrid = ReturnDataTable(SQLStoreD13P2084())
        '        For i As Integer = 0 To dtGrid.Rows.Count - 1
        '            dtGrid.Rows(i).Item("IsUsed") = False
        '        Next
        '
        '        If dtSelected IsNot Nothing Then
        '            Dim keyCol() As DataColumn = {dtSelected.Columns("DepartmentID"), dtSelected.Columns("TeamID"), dtSelected.Columns("EmployeeID")}
        '            dtSelected.PrimaryKey = keyCol
        '            Dim keyCol1() As DataColumn = {dtGrid.Columns("DepartmentID"), dtGrid.Columns("TeamID"), dtGrid.Columns("EmployeeID")}
        '            dtGrid.PrimaryKey = keyCol1
        '
        '            dtGrid.Merge(dtSelected, False, MissingSchemaAction.AddWithKey)
        '        End If
        '        gbEnabledUseFind = dtGrid.Rows.Count > 0
        '        LoadDataSource(tdbg, dtGrid, gbUnicode)
        '
        '        CheckMnu()
        '        FooterTotalGrid(tdbg, COL_EmployeeID)
        '        VisibledButton()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD13P2084())
        ' gán IsUsed lại = 0, do stored D13P2084 ko alias được
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("IsUsed") = False
        Next
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = "IsUsed = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("DepartmentID"), dtGrid.Columns("TeamID"), dtGrid.Columns("EmployeeID")}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub CheckMnu()
        'Lay quyen xem sua xoa cua man hinh
        'update 14/1/2013 id 53746
        '  CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        '        Dim per As Integer = ReturnPermission(Me.Name)
        '        tsbFind.Enabled = (gbEnabledUseFind Or tdbg.RowCount > 0) And chkShowIsUsed.Checked = False
        '        tsbListAll.Enabled = (gbEnabledUseFind Or tdbg.RowCount > 0) And chkShowIsUsed.Checked = False
       
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcPITYear.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nam_quyet_toan"))
            tdbcPITYear.Focus()
            Return False
        End If

        If chkIsInValid.Checked = False AndAlso chkIsValid.Checked = False Then
            D99C0008.MsgL3(rl3("MSG000009"))
            chkIsValid.Focus()
            Return False
        End If
        ' update 18/12/2012 by Hoàng Nhân id 53122
        If chkIsEmpStopWork.Checked Then
            If c1dateDateLeftFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                c1dateDateLeftFrom.Focus()
                Return False
            End If
            If c1dateDateLeftTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                c1dateDateLeftTo.Focus()
                Return False
            End If
            If Not CheckOverDate(c1dateDateLeftFrom.Value, c1dateDateLeftTo.Value) Then
                D99C0008.MsgL3(rl3("MSG000013"))
                c1dateDateLeftFrom.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function CheckOverDate(ByVal date1 As Object, ByVal date2 As Object, Optional ByVal Interval As DateInterval = DateInterval.Day) As Boolean
        Return CompareDate(date1, date2, Interval) >= 0 'date2>date1
    End Function

    Private Function CompareDate(ByVal date1 As Object, ByVal date2 As Object, Optional ByVal Interval As DateInterval = DateInterval.Day) As Long
        If date1 Is Nothing OrElse date2 Is Nothing OrElse date1.ToString = "" OrElse date2.ToString = "" Then Return 0
        Return DateDiff(Interval, CDate(date1), CDate(date2))
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        chkShowIsUsed.Checked = False
        LoadTDBGrid()
        VisibledButton()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkShowIsUsed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowIsUsed.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
        '        tdbg.UpdateData()
        '        If dtGrid Is Nothing Then Exit Sub
        '
        '        Dim sFilter As String = ""
        '        If chkShowIsUsed.Checked = True Then
        '            sFilter = "IsUsed = 1"
        '        Else
        '            sFilter = IIf(sFind = "", "", sFind & " or IsUsed = 1").ToString
        '        End If
        '        dtGrid.DefaultView.RowFilter = sFilter
        '
        '        CheckMnu()
        '        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUsed
                tdbg.UpdateData()
                'Dim dr As DataRow
                'dr = dtGrid.Select("DepartmentID = " & SQLString(tdbg.Columns(COL_DepartmentID).Text) & " And TeamID = " & SQLString(tdbg.Columns(COL_TeamID).Text) & " And EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text))(0)
                'dr.BeginEdit()
                'dr("IsUsed") = L3Bool(tdbg.Columns(COL_IsUsed).Value)
                'dr.EndEdit()
                'If chkShowIsUsed.Checked Then
                '    LoadDataSource(tdbg, ReturnTableFilter(dtGrid, "IsUsed = True"), gbUnicode)
                'End If
                VisibledButton()
                ResetGrid()
            Case COL_DateJoined, COL_PITDate, COL_PlanPITDate
                tdbg.Select()
            Case COL_PITPeriodFrom, COL_PITPeriodTo
                If tdbg.Columns(e.ColIndex).Text <> "  /" Then
                    tdbg.Columns(e.ColIndex).Value = tdbg.Columns(e.ColIndex).Text
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_ReferenceNo
                e.Cancel = L3IsID(tdbg, e.ColIndex)
            Case COL_PITPeriodFrom
                tdbg.Columns(e.ColIndex).Text = L3PeriodValue(tdbg.Columns(e.ColIndex).Text)

                Dim sPeriod As String = tdbg.Columns(e.ColIndex).Text
                If sPeriod.Substring(3, 4) <> tdbcPITYear.Text Then
                    D99C0008.MsgL3(rl3("MSG000009"))
                    e.Cancel = True
                End If
            Case COL_PITPeriodTo
                tdbg.Columns(e.ColIndex).Text = L3PeriodValue(tdbg.Columns(e.ColIndex).Text)

                Dim sPeriod As String = tdbg.Columns(e.ColIndex).Text
                If sPeriod.Substring(3, 4) < tdbcPITYear.Text Then
                    D99C0008.MsgL3(rl3("MSG000009"))
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub

        Select Case e.ColIndex
            Case COL_IsUsed
                CheckedAll()
                tdbg.AllowSort = False
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_PlanPITDate Then
                HotKeyEnterGrid(tdbg, COL_ReferenceNo, e, SPLIT2)
            End If
        End If
        If e.Control Then
            If e.KeyCode = Keys.S Then
                If tdbg.Col = COL_IsUsed Then
                    CheckedAll()
                End If
            End If
        End If
        HotKeyDownGrid(e, tdbg, COL_IsUsed, SPLIT0, SPLIT2, True, True, True, -1, "")

    End Sub

    Private Sub CheckedAll()
        Dim bHeadClick As Boolean = Not L3Bool(tdbg(0, COL_IsUsed).ToString)
        For i As Integer = tdbg.RowCount - 1 To 0 Step -1
            tdbg(i, COL_IsUsed) = bHeadClick
        Next

        tdbg.UpdateData()
        dtGrid.AcceptChanges()

        VisibledButton()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        If dtGrid Is Nothing Then

        End If

        If btnSave.Visible = True Then
            Dim dr() As DataRow = dtGrid.Select("PlanPITDate is not null")
            If dr.Length <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_PlanPITDate
                Return False
            End If
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed).ToString) Then
                If tdbg(i, COL_PITDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ngay_quyet_toan"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_PITDate
                    tdbg.Bookmark = i
                    Return False
                End If
                If tdbg(i, COL_PITPeriodFrom).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ky_QT_tuU"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_PITPeriodFrom
                    tdbg.Bookmark = i
                    Return False
                End If
                If tdbg(i, COL_PITPeriodTo).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ky_QT_denU"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_PITPeriodTo
                    tdbg.Bookmark = i
                    Return False
                End If
                If Not CheckPeriod(tdbg(i, COL_PITPeriodFrom).ToString, tdbg(i, COL_PITPeriodTo).ToString) Then
                    D99C0008.MsgL3(rL3("MSG000009"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_PITPeriodTo
                    tdbg.Bookmark = i
                    Return False
                End If

            End If
        Next
        Return True
    End Function

    Private Function CheckPeriod(ByVal sPeriodFrom As String, ByVal sPeriodTo As String) As Boolean
        Dim sYearFrom As String
        Dim sMonthFrom As String
        Dim sYearTo As String
        Dim sMonthTo As String

        sYearFrom = sPeriodFrom.Substring(3, 4)
        sMonthFrom = sPeriodFrom.Substring(0, 2)
        sYearTo = sPeriodTo.Substring(3, 4)
        sMonthTo = sPeriodTo.Substring(0, 2)

        If (Number(sYearTo) - Number(sYearFrom)) * 12 - Number(sMonthFrom) + Number(sMonthTo) + 1 < 12 Then
            Return False
        End If

        Return True
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2084
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/12/2010 04:32:11
    '# Modified User: Trần Hoàng Nhân
    '# Modified Date: 17/12/2012 06:08:40
    '# Description: id 53122
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2084() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2084 "
        sSQL &= SQLNumber(tdbcPITYear.Text) & COMMA 'PITYear, int, NOT NULL
        sSQL &= SQLNumber(chkIsValid.Checked) & COMMA 'IsValid, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsInValid.Checked) & COMMA 'IsInValid, tinyint, NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= "N" & SQLString(txtEmployeeName.Text) & COMMA 'StrEmployeeName, nvarchar, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsEmpStopWork.Checked) & COMMA 'IsEmpStopWork, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftFrom.Value) & COMMA 'DateLeftFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftTo.Value) 'DateLeftTo, datetime, NOT NULL
        Return sSQL
    End Function

    Private Sub VisibledButton()
        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("IsUsed = True")
        If dr.Length > 0 Then
            btnChoose.Visible = True
            btnSave.Visible = False
        Else
            btnChoose.Visible = False
            btnSave.Visible = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2083s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/12/2010 02:33:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2083s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("IsUsed = True")

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("IF NOT EXISTS (SELECT TOP 1 1 FROM D13T2083 ")
            sSQL.Append("WHERE EmployeeID = " & SQLString(dr(i).Item("EmployeeID").ToString) & " AND PITYear = " & SQLPeriodSaveOnlyYear(dr(i).Item("PITPeriodFrom").ToString) & ")" & vbCrLf)

            sSQL.Append("Insert Into D13T2083(")
            sSQL.Append("EmployeeID, PITYear, ReferenceNo, PITDate, PITPeriodFrom, ")
            sSQL.Append("PITPeriodTo, PlanPITDate, IsLiquidation, ")
            sSQL.Append("CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, IsDependValidDate,DivisionID,IncreaseGeneralIncomeAmount12m, ReduceGeneralIncomeAmount12m")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(dr(i).Item("EmployeeID").ToString) & COMMA) 'EmployeeID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLPeriodSaveOnlyYear(dr(i).Item("PITPeriodFrom").ToString) & COMMA) 'PITYear [KEY], int, NOT NULL
            sSQL.Append(SQLString(dr(i).Item("ReferenceNo").ToString) & COMMA) 'ReferenceNo, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item("PITDate").ToString) & COMMA) 'PITDate, datetime, NULL
            sSQL.Append(SQLPeriodSave(dr(i).Item("PITPeriodFrom").ToString) & COMMA) 'PITPeriodFrom, int, NOT NULL
            sSQL.Append(SQLPeriodSave(dr(i).Item("PITPeriodTo").ToString) & COMMA) 'PITPeriodTo, int, NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item("PlanPITDate").ToString) & COMMA) 'PlanPITDate, datetime, NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'IsLiquidation, int, NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(chkIsDependValidDate.Checked) & COMMA)
            sSQL.Append(SQLString(dr(i).Item("DivisionID").ToString) & COMMA) 'DivisionID, varchar[50], NOT NULL
            'Bổ sung 2 cột ngày 24/02/2015
            sSQL.Append(SQLMoney(dr(i).Item("IncreaseGeneralIncomeAmount12m"), tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).NumberFormat) & COMMA) 'IncreaseGeneralIncomeAmount12m, decimal, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item("ReduceGeneralIncomeAmount12m"), tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).NumberFormat)) 'ReduceGeneralIncomeAmount12m, decimal, NOT NULL

            sSQL.Append(")" & vbCrLf)

            sSQL.Append("ELSE" & vbCrLf)
            sSQL.Append("Update D13T2083 Set ")
            sSQL.Append("ReferenceNo = " & SQLString(dr(i).Item("ReferenceNo").ToString) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("PITDate = " & SQLDateSave(dr(i).Item("PITDate").ToString) & COMMA) 'datetime, NULL
            sSQL.Append("PITPeriodFrom = " & SQLPeriodSave(dr(i).Item("PITPeriodFrom").ToString) & COMMA) 'int, NOT NULL
            sSQL.Append("PITPeriodTo = " & SQLPeriodSave(dr(i).Item("PITPeriodTo").ToString) & COMMA) 'int, NOT NULL
            sSQL.Append("PlanPITDate = " & SQLDateSave(dr(i).Item("PlanPITDate").ToString) & COMMA) 'datetime, NULL
            sSQL.Append("IsLiquidation = " & SQLNumber(0) & COMMA) 'int, NOT NULL
            sSQL.Append("CreateDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("CreateUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("IsDependValidDate = " & SQLNumber(chkIsDependValidDate.Checked) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DivisionID = " & SQLString(dr(i).Item("DivisionID").ToString) & COMMA) 'DivisionID, varchar[50], NOT NULL
            'Bổ sung 2 cột ngày 24/02/2015
            sSQL.Append("IncreaseGeneralIncomeAmount12m =" & SQLMoney(dr(i).Item("IncreaseGeneralIncomeAmount12m"), tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).NumberFormat) & COMMA) 'IncreaseGeneralIncomeAmount12m, decimal, NOT NULL
            sSQL.Append("ReduceGeneralIncomeAmount12m = " & SQLMoney(dr(i).Item("ReduceGeneralIncomeAmount12m"), tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).NumberFormat)) 'ReduceGeneralIncomeAmount12m, decimal, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("EmployeeID = " & SQLString(dr(i).Item("EmployeeID").ToString) & " And ")
            sSQL.Append("PITYear = " & SQLPeriodSaveOnlyYear(dr(i).Item("PITPeriodFrom").ToString) & vbCrLf)
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2086
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/12/2010 02:54:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2086() As String
        Dim sSQL As String = ""
        Dim arrPITYear As ArrayList = GetPITYear()
        For i As Integer = 0 To arrPITYear.Count - 1
            sSQL &= "Exec D13P2086 "
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLNumber(arrPITYear(i)) & vbCrLf 'PITYear, int, NOT NULL
        Next
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2083s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/12/2010 02:54:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2083s_PITDate() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")
        dtGrid.AcceptChanges()

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("IsForeigner=1 And IsUsed = False")
        'Dim dr() As DataRow = dt.Select("PlanPITDate = '' OR PlanPITDate = 'NULL' ")

        For i As Integer = 0 To dr.Length - 1
            If Not IsDBNull(dr(i).Item("PlanPITDate")) Or dr(i).Item("PlanPITDate").ToString <> "" Then
                If dr(i).Item("EmployeeID").ToString <> "" OrElse Not IsDBNull(dr(i).Item("EmployeeID")) Then

                    sSQL.Append("DELETE D13T2083 WHERE EmployeeID = " & SQLString(dr(i).Item("EmployeeID").ToString))
                    sSQL.Append(" AND PITYear = " & SQLPeriodSaveOnlyYear(dr(i).Item("PITPeriodFrom").ToString) & vbCrLf)

                    sSQL.Append("Insert Into D13T2083(")
                    sSQL.Append("EmployeeID, PITYear, ReferenceNo, PITDate, PITPeriodFrom, ")
                    sSQL.Append("PITPeriodTo, PlanPITDate, IsLiquidation,DivisionID,IncreaseGeneralIncomeAmount12m, ReduceGeneralIncomeAmount12m")
                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(dr(i).Item("EmployeeID").ToString) & COMMA) 'EmployeeID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLPeriodSaveOnlyYear(dr(i).Item("PITPeriodFrom").ToString) & COMMA) 'PITYear [KEY], int, NOT NULL
                    sSQL.Append(SQLString(dr(i).Item("ReferenceNo").ToString) & COMMA) 'ReferenceNo, varchar[20], NOT NULL
                    sSQL.Append(SQLDateSave(dr(i).Item("PITDate").ToString) & COMMA) 'PITDate, datetime, NULL
                    sSQL.Append(SQLPeriodSave(dr(i).Item("PITPeriodFrom").ToString) & COMMA) 'PITPeriodFrom, int, NOT NULL
                    sSQL.Append(SQLPeriodSave(dr(i).Item("PITPeriodTo").ToString) & COMMA) 'PITPeriodTo, int, NOT NULL
                    sSQL.Append(SQLDateSave(dr(i).Item("PlanPITDate").ToString) & COMMA) 'PlanPITDate, datetime, NULL
                    sSQL.Append(SQLNumber(2) & COMMA) 'IsLiquidation, int, NOT NULL
                    sSQL.Append(SQLString(dr(i).Item("DivisionID").ToString) & COMMA) 'ReferenceNo, varchar[20], NOT NULL
                    'Bổ sung 2 cột ngày 24/02/2015
                    sSQL.Append(SQLMoney(dr(i).Item("IncreaseGeneralIncomeAmount12m"), tdbg.Columns(COL_IncreaseGeneralIncomeAmount12m).NumberFormat) & COMMA) 'IncreaseGeneralIncomeAmount12m, decimal, NOT NULL
                    sSQL.Append(SQLMoney(dr(i).Item("ReduceGeneralIncomeAmount12m"), tdbg.Columns(COL_ReduceGeneralIncomeAmount12m).NumberFormat)) 'ReduceGeneralIncomeAmount12m, decimal, NOT NULL
                    sSQL.Append(")")
                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)
                End If
            End If
        Next
        Return sRet
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLInsertD13T2083s_PITDate)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bIsSavedPIT = True
            Me.Close()
            'btnFilter_Click(Nothing, Nothing)
            'btnSave.Enabled = True
        Else
            If sSQL.ToString = "" Then
                D99C0008.MsgL3(rL3("MSG000009"))
            Else
                SaveNotOK()
            End If
            btnSave.Enabled = True
        End If
    End Sub

    Dim bIsSavedPIT As Boolean = False

    Private Sub btnChoose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnChoose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLInsertD13T2083s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD13P2086.ToString & vbCrLf)
        sSQL.Append(SQLInsertD13T2083s_PITDate.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bIsSavedPIT = True
            'Me.Close()

            ' updat 7/5/2013 id 56081
            If Not _callFromD13F2080 Then
                Dim f As New D13F2080
                With f
                    .PITYear = tdbcPITYear.Text
                    .BlockID = ReturnValueC1Combo(tdbcBlockID).ToString
                    .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID).ToString
                    .TeamID = ReturnValueC1Combo(tdbcTeamID).ToString
                    .WorkingStatusID = ReturnValueC1Combo(tdbcWorkingStatusID).ToString
                    .EmployeeID = ReturnValueC1Combo(tdbcEmployeeID).ToString
                    .StrEmployeeID = txtEmployeeID.Text
                    .StrEmployeeName = txtEmployeeName.Text
                    .CallFromD13F2081 = True
                    Me.Close()
                    .ShowDialog()
                    .Dispose()
                End With
            Else
                Me.Close()
            End If
        Else
            SaveNotOK()
            btnChoose.Enabled = True
        End If
    End Sub

    Private Function GetPITYear() As ArrayList
        Dim arrPITYear As New ArrayList
        For i As Integer = 0 To tdbg.RowCount - 1
            Dim sYear As String = SQLPeriodSaveOnlyYear(tdbg(i, COL_PITPeriodFrom).ToString).Replace("'", "")
            Dim bIsExist As Boolean = False
            For j As Integer = 0 To arrPITYear.Count - 1
                If arrPITYear(j).ToString = sYear Then
                    bIsExist = True
                    Exit For
                End If
            Next
            If bIsExist = False Then
                arrPITYear.Add(sYear)
            End If
        Next
        Return arrPITYear
    End Function

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_PITPeriodFrom, COL_PITPeriodTo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Birthdate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
            Case COL_Age
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_ReferenceNo
                e.KeyChar = UCase(e.KeyChar)
        End Select
    End Sub

    Private Function SQLPeriodSaveOnlyYear(ByVal [Period] As String) As String
        If [Period] = "" Then Return "NULL"
        If [Period] = MaskFormatPeriodShort Then Return "NULL"
        If [Period] = MaskFormatPeriod Then Return "NULL"

        Dim sPeriodYear As String = ""
        sPeriodYear = [Period].Substring(3, 4)
        Return SQLString(sPeriodYear)

    End Function


#Region "Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True"
    Private Sub CallD09U1111(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_EmployeeID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
            '-----------------------------------
        End If
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption1 IsNot Nothing Then usrOption1.Dispose()
        usrOption1 = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub Call_D09U1111Refresh()
        'Chuẩn hóa D09U1111 B6: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
        'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
        If usrOption1 IsNot Nothing Then
            usrOption1.MarkInvisibleColumn(SPLIT1)
            usrOption1.D09U1111Refresh()
        End If
    End Sub
#End Region
    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl 
        giRefreshUserControl = -1
        usrOption1.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption1.Height + 7))
        Me.Controls.Add(usrOption1)
        usrOption1.BringToFront()
        usrOption1.Visible = True
    End Sub

    Private Sub chkIsEmpStopWork_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsEmpStopWork.CheckedChanged
        If chkIsEmpStopWork.Checked Then
            UnReadOnlyControl(True, c1dateDateLeftFrom, c1dateDateLeftTo)
        Else
            ReadOnlyControl(c1dateDateLeftFrom, c1dateDateLeftTo)
        End If
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns, chkShowIsUsed)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave)
    End Sub
End Class