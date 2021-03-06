﻿Imports System
Imports System.Drawing
Public Class D13F3020
	Dim report As D99C2003
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _formCall As String = ""
    Public WriteOnly Property FormCall() As String 
        Set(ByVal Value As String )
            _formCall = Value
        End Set
    End Property
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg - Total of Columns: 42"
    Private Const COL_IsReceived As Integer = 0            ' Đã hưởng trợ cấp
    Private Const COL_EmployeeID As Integer = 1            ' Mã NV
    Private Const COL_EmployeeName As Integer = 2          ' Họ và tên
    Private Const COL_BlockID As Integer = 3               ' Khối
    Private Const COL_BlockName As Integer = 4             ' Tên khối
    Private Const COL_DepartmentID As Integer = 5          ' Phòng ban
    Private Const COL_DepartmentName As Integer = 6        ' Tên phòng ban
    Private Const COL_TeamID As Integer = 7                ' Tổ nhóm
    Private Const COL_TeamName As Integer = 8              ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 9            ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 10         ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 11               ' Chức vụ
    Private Const COL_DutyName As Integer = 12             ' Tên chức vụ
    Private Const COL_WorkID As Integer = 13               ' Công việc
    Private Const COL_WorkName As Integer = 14             ' Tên công việc
    Private Const COL_BirthDate As Integer = 15            ' Ngày sinh
    Private Const COL_SexName As Integer = 16              ' Giới tính
    Private Const COL_DateJoined As Integer = 17           ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 18             ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 19                  ' Tuổi
    Private Const COL_StatusID As Integer = 20             ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 21           ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 22     ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 23        ' Mã NV phụ
    Private Const COL_SeniorityYear As Integer = 24        ' Năm
    Private Const COL_SeniorityMonth As Integer = 25       ' Tháng
    Private Const COL_SeverancePayMonthNum As Integer = 26 ' Số tháng hưởng trợ cấp
    Private Const COL_SeverancePay As Integer = 27         ' Lương thôi việc
    Private Const COL_TotalSeverancePay As Integer = 28    ' Tổng tiền trợ cấp thôi việc
    Private Const COL_YTotalSeverancePay As Integer = 29   ' Tổng tiền trợ cấp trong năm
    Private Const COL_Note As Integer = 30                 ' Ghi chú
    Private Const COL_RefU01 As Integer = 31               ' Tham chiếu 01
    Private Const COL_RefU02 As Integer = 32               ' Tham chiếu 02
    Private Const COL_RefU03 As Integer = 33               ' Tham chiếu 03
    Private Const COL_RefU04 As Integer = 34               ' Tham chiếu 04
    Private Const COL_RefU05 As Integer = 35               ' Tham chiếu 05
    Private Const COL_SeverancePayMonth01 As Integer = 36  ' Lương trợ cấp tháng 1
    Private Const COL_SeverancePayMonth02 As Integer = 37  ' Lương trợ cấp tháng 2
    Private Const COL_SeverancePayMonth03 As Integer = 38  ' Lương trợ cấp tháng 3
    Private Const COL_SeverancePayMonth04 As Integer = 39  ' Lương trợ cấp tháng 4
    Private Const COL_SeverancePayMonth05 As Integer = 40  ' Lương trợ cấp tháng 5
    Private Const COL_SeverancePayMonth06 As Integer = 41  ' Lương trợ cấp tháng 6
#End Region

    Dim dt As New DataTable
    Dim dtTeamID As New DataTable
    Dim dtEmployeeID As New DataTable

    Private Sub D13F3020_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ExecuteSQLNoTransaction(SQLDeleteD09T6666) ' update 4/11/2013 id 57976
    End Sub

    Private Sub D13F3020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    btnSeverancePay_Click(Nothing, Nothing)
                Case Keys.D2, Keys.NumPad2
                    btnImformation_Click(Nothing, Nothing)
            End Select
        End If

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
    End Sub

#Region "Chuẩn hóa D09U1111 B1: đinh nghĩa biến"
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region
    Private gbEnabledUseFind As Boolean = False
    Private bFilterEnable As Boolean = True
    Private Sub D13F3020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        LoadCaptionForGird()
        ResetFooterGrid(tdbg, 0, 2)
        ResetSplitDividerSize(tdbg)
        InputC1NumbericTDBGrid()
        tdbg_LockedColumns()
        CreateTableCombo()
        LoadTDBCombo()
        SetDefaultValue()
        chkEmpStopWork_CheckedChanged(Nothing, Nothing)
        '******************************
        ' update 28/11/2012 id 51174
        If Not D13Systems.IsUseBlock Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = False
        End If
        '******************************
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg_FooterText()
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft)
        InputDateCustomFormat(c1dateDateLeftFrom, c1dateDateLeftTo)

        SetResolutionForm(Me, Me.C1ContextMenu)
        CallD09U1111(True)
        If _formCall = "D09F2051" OrElse _formCall.Contains("D09U") Then
            bFilterEnable = False
            btnFilter_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Du_phong_va_tinh_tro_cap_thoi_viecF") & " - " & Me.Name & UnicodeCaption(gbUnicode)
        '================================================================ 
        lblDepsrtmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        'Chuẩn hóa D09U1111 B5: Tại hàm LoadLanguage: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkEmpStopWork.Text = rl3("Nhan_vien_nghi_viec") ' Nhân viên nghỉ việc
        chkIsReceived.Text = rl3("Da_huong_tro_cap") ' Đã hưởng trợ cấp
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcPeriod.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        '================================================================ 
        btnSeverancePay.Text = "1. " & rL3("Thong_tin_du_phong_va_tro_cap_thoi_viec") '1. Thông tin dự phòng và trợ cấp thôi việc
        btnImformation.Text = "2 " & rL3("Thong_tin_tham_khao") '2 Thông tin tham khảo

        tdbg.Columns("IsReceived").Caption = rl3("Da_huong_tro_cap") 'Đã hưởng trợ cấp
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Họ và tên
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("SeniorityYear").Caption = rl3("Nam") 'Năm
        tdbg.Columns("SeniorityMonth").Caption = rl3("Thang_U") 'Tháng
        tdbg.Columns("SeverancePay").Caption = rl3("Luong_thoi_viec") 'Lương thôi việc
        tdbg.Columns("YTotalSeverancePay").Caption = rl3("Tong_tien_tro_cap_trong_nam") 'Tổng tiền trợ cấp trong năm
        tdbg.Columns("TotalSeverancePay").Caption = rl3("Tong_tien_tro_cap_thoi_viec") 'Tổng tiền trợ cấp thôi việc
        ' update 15/11/2012 id 51174
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DutyID").Caption = rl3("Chuc_vu")
        tdbg.Columns("DutyName").Caption = rl3("Ten_chuc_vu")
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh")
        tdbg.Columns("WorkID").Caption = rl3("Cong_viec")
        tdbg.Columns("WorkName").Caption = rl3("Ten_cong_viec")
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh")
        tdbg.Columns("DateLeft").Caption = rl3("Ngay_nghi_viec")
        tdbg.Columns("Age").Caption = rl3("Tuoi")
        tdbg.Columns("StatusID").Caption = rl3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rl3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rl3("Ma_the_cham_cong")
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns("SeverancePayMonthNum").Caption = rl3("So_thang_huong_tro_cap") 'Số tháng hưởng trợ cấp
        tdbg.Columns("Note").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Splits(1).Caption = rL3("Tham_nien")
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuPrint.Text = rl3("_In") '&In
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcWorkingStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateLeft).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Age).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AttendanceCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SeniorityYear).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SeniorityMonth).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePay).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SeverancePayMonth06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetDefaultValue()
        c1dateDateLeftFrom.Value = Date.Now
        c1dateDateLeftTo.Value = Date.Now
        tdbcTeamID.SelectedIndex = 0
        tdbcEmployeeID.SelectedIndex = 0
        tdbcWorkingStatusID.SelectedIndex = 0
        tdbcPeriod.SelectedIndex = 0
        chkIsReceived.Checked = False
        chkIsReceived_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P3020()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg_FooterText()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        Dim dtDepartnentID As DataTable = ReturnTableDepartmentID(True, , gbUnicode)
        LoadDataSource(tdbcDepartmentID, dtDepartnentID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0

        'Load tdbcTeamID
        LoadtdbcTeamID("-1")

        'Load tdbcEmployeeID
        'LoadtdbcEmployeeID("-1", "-1") 'Rem lại,lỗi filter combo 

        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcWorkingStatusID
        sSQL = "Select '%' As WorkingStatusID, " & sLanguage & " As WorkingStatusName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select WorkingStatusID, WorkingStatusName" & sUnicode & " as WorkingStatusName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "From D09T0070 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order By DisplayOrder, WorkingStatusID"
        LoadDataSource(tdbcWorkingStatusID, sSQL, gbUnicode)

        'Load tdbcPeriod, tdbcMonthYear
        sSQL = " Select Distinct (TranMonth + TranYear *100) as MonthYearTemp, REPLACE(STR(TranMonth, 2), ' ', '0') + '/' + STR(TranYear, 4) AS Period, TranMonth, TranYear, DivisionID "
        sSQL &= " From D09T9999  WITH (NOLOCK) "
        sSQL &= " Where DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " Order By TranYear DESC, TranMonth DESC"

        Dim dtMonthYear As DataTable
        dtMonthYear = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPeriod, dtMonthYear.Copy, gbUnicode)
        LoadDataSource(tdbcPeriodFrom, dtMonthYear.Copy, gbUnicode)
        LoadDataSource(tdbcPeriodTo, dtMonthYear.Copy, gbUnicode)
    End Sub

    Private Sub LoadtdbcTeamID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "TeamID = '%' Or DepartmentID = " & SQLString(ID)), gbUnicode)
        End If
        Me.tdbcTeamID.SelectedIndex = 0
    End Sub

    Private Sub LoadtdbcEmployeeID(ByVal sDeptID As String, ByVal sTeamID As String)
        If sDeptID = "%" And sTeamID = "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, ""), gbUnicode)
        End If
        If sDeptID = "%" And sTeamID <> "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or TeamID = " & SQLString(sTeamID)), gbUnicode)
        End If
        If sDeptID <> "%" And sTeamID = "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or DepartmentID = " & SQLString(sDeptID)), gbUnicode)
        End If
        If sDeptID <> "%" And sTeamID <> "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or (DepartmentID = " & SQLString(sDeptID) & " And TeamID = " & SQLString(sTeamID) & ")"), gbUnicode)
        End If
        Me.tdbcEmployeeID.SelectedIndex = 0
    End Sub

    Private Sub CreateTableCombo()
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        LoadDataSource(tdbcTeamID, dtTeamID, gbUnicode)

        dtEmployeeID = ReturnTableEmployeeID(True, , gbUnicode)
        LoadDataSource(tdbcEmployeeID, dtEmployeeID, gbUnicode)
    End Sub

#Region "Events tdbcDepartmentID with txtDepartmentName load tdbcTeamID with txtTeamName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
            tdbcDepartmentID.Tag = ""
            Exit Sub
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Or tdbcDepartmentID.SelectedValue Is DBNull.Value Then
            LoadtdbcTeamID("-1")
            tdbcTeamID.SelectedValue = "%"
            LoadtdbcEmployeeID("-1", "-1")
            tdbcEmployeeID.SelectedValue = "%"
            Exit Sub
        End If
        LoadtdbcTeamID(ComboValue(tdbcDepartmentID))
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If Not (tdbcTeamID.Tag Is Nothing OrElse tdbcTeamID.Tag.ToString = "") Then
            tdbcTeamID.Tag = ""
            Exit Sub
        End If
        If tdbcTeamID.SelectedValue Is Nothing Or tdbcTeamID.SelectedValue Is DBNull.Value Then
            LoadtdbcEmployeeID("-1", "-1")
            tdbcEmployeeID.SelectedValue = "%"
            Exit Sub
        End If
        LoadtdbcEmployeeID(ComboValue(tdbcDepartmentID), tdbcTeamID.SelectedValue.ToString())
    End Sub

#End Region

#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub
#End Region

#Region "Events tdbcWorkingStatusID with txtWorkingStatusName"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then tdbcWorkingStatusID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen, tdbcEmployeeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, tdbcEmployeeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcWorkingStatusID.KeyUp, tdbcEmployeeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.Close
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

    'Private Sub tdbcPeriod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriod.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriod.Text = ""
    'End Sub

#End Region

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
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

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
            ReLoadTDBGrid()
        End Set
    End Property

    '    Dim dtCaptionCols As DataTable
    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Dim sSQL As String = ""
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        ' update 17/7/2013 id 56969
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '        If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClauseClient.ToString()
    '        sFindServer = ResultWhereClauseServer.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        sFindServer = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dt, sFind)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg_FooterText()
    End Sub
#End Region

    ' update 17/7/2013 id 56969
    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        '*****************************************
        tdbg.UpdateData()
        dt.AcceptChanges()
      
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dt, gsGroupColumns)

        '        ResetTableForExcel(tdbg, gdtCaptionExcel)
        '        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = gdtCaptionExcel
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dt
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '*****************************************

    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        PrintReport()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintReport()
        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R3020"
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sModuleID As String = "13"

        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportName = GetReportPath(Me.Name, sReportName, "", sReportPath, sReportTitle, sModuleID)

        Me.Cursor = Cursors.Default
        If sReportName = "" Then Exit Sub

        sReportCaption = rl3("In_quy_du_phong_tro_cap_thoi_viec") & " - " & sReportName

        sSQL = SQLStoreD13P3020()
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub
    Private dtCaptionG As DataTable
    Private Sub LoadCaptionForGird()
        dtCaptionG = ReturnDataTable(SQLStoreD13P0050())
        If dtCaptionG Is Nothing OrElse dtCaptionG.Rows.Count = 0 Then Exit Sub
        Dim sFieldName As String
        Dim IndexCol As Integer
        For i As Integer = 0 To dtCaptionG.Rows.Count - 1
            sFieldName = L3String(dtCaptionG.Rows(i).Item("FieldName"))
            IndexCol = IndexOfColumn(tdbg, sFieldName)
            If IndexCol > 0 Then
                tdbg.Columns(IndexCol).Caption = L3String(dtCaptionG.Rows(i).Item("Caption"))
                tdbg.Splits(SPLIT2).DisplayColumns(IndexCol).Visible = Not L3Bool(dtCaptionG.Rows(i).Item("Disabled"))
            End If
        Next
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        btnFilter.Enabled = False
        LoadCaptionForGird()
        LoadTDBGrid()
        btnFilter.Enabled = bFilterEnable
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If chkEmpStopWork.Checked Then
            If Not CheckValidDateFromTo(c1dateDateLeftFrom, c1dateDateLeftTo) Then
                Return False
            End If
        End If
        If chkIsReceived.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Tu"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Den"))
                tdbcPeriodTo.Focus()
                Return False
            End If
        End If
        If tdbcPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ky"))
            tdbcPeriod.Focus()
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
        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nhan_vien"))
            tdbcEmployeeID.Focus()
            Return False
        End If
        If tdbcWorkingStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Hinh_thuc_lam_viec"))
            tdbcWorkingStatusID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        If chkIsReceived.Checked Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If Not CBool(tdbg(i, COL_IsReceived)) Then
                    bFlag = True
                    Exit For
                End If
            Next
            If Not bFlag Then
                D99C0008.MsgL3(rL3("MSG000010"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = COL_IsReceived
                tdbg.Row = 0
                Return False
            End If
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                If CBool(tdbg(i, COL_IsReceived)) Then
                    bFlag = True
                    Exit For
                End If
            Next
            If Not bFlag Then
                D99C0008.MsgL3(rL3("MSG000010"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = COL_IsReceived
                tdbg.Row = 0
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        Dim sSQL As String = ""
        If chkIsReceived.Checked Then
            sSQL = SQLDeleteD13T3030s().ToString & vbCrLf
        Else
            sSQL = SQLInsertD13T3030s().ToString & vbCrLf
        End If
        sSQL &= SQLStoreD13P3024() ' update 4/11/2013 id 57976

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnFilter_Click(Nothing, Nothing)
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '    Private Sub tdbg_NumberFormat()
    '        tdbg.Columns(COL_SeverancePay).NumberFormat = D13Format.DefaultNumber2
    '        tdbg.Columns(COL_TotalSeverancePay).NumberFormat = D13Format.DefaultNumber2
    '        tdbg.Columns(COL_YTotalSeverancePay).NumberFormat = D13Format.DefaultNumber2
    '    End Sub
    Private Sub InputC1NumbericTDBGrid()
        Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
        'Thêm cột số có kiểu dữ liệu là Decimal
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePay).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonthNum).DataField, CustomFormat(2), 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_TotalSeverancePay).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_YTotalSeverancePay).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth01).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth02).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth03).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth04).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth05).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SeverancePayMonth06).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        'Định dạng các cột số trên lưới
        InputNumber(tdbg, arrCol)
    End Sub

    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg, COL_EmployeeName)
        FooterSumNew(tdbg, COL_SeverancePayMonth01, COL_SeverancePayMonth02, COL_SeverancePayMonth03, COL_SeverancePayMonth04, COL_SeverancePayMonth05, COL_SeverancePayMonth06)
        FootTextColumns(COL_SeverancePay, D13Format.DefaultNumber2)
        FootTextColumns(COL_TotalSeverancePay, D13Format.DefaultNumber2)
    End Sub

    Private Sub FootTextColumns(ByVal iCol As Integer, ByVal sNumberFormat As String)
        Dim Sum As Double = 0
        For j As Int32 = 0 To tdbg.RowCount - 1
            Sum += Number(SQLNumber(tdbg(j, iCol).ToString, sNumberFormat))
        Next
        tdbg.Columns(iCol).FooterText = SQLNumber(Sum.ToString, sNumberFormat)
    End Sub

    Private Sub chkIsReceived_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsReceived.Click
        tdbcPeriodFrom.Enabled = chkIsReceived.Checked
        tdbcPeriodTo.Enabled = chkIsReceived.Checked
        If chkIsReceived.Checked Then
            tdbcPeriodFrom.AutoSelect = True
            tdbcPeriodTo.AutoSelect = True
        Else
            tdbcPeriodFrom.Text = ""
            tdbcPeriodTo.Text = ""
        End If
    End Sub

    ' 14/2014 id 60406
    Private Sub chkEmpStopWork_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpStopWork.CheckedChanged
        If chkEmpStopWork.Checked Then
            UnReadOnlyControl(True, c1dateDateLeftFrom, c1dateDateLeftTo)
        Else
            ReadOnlyControl(c1dateDateLeftFrom, c1dateDateLeftTo)
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsReceived
                Dim bFlag As Boolean = Not CBool(tdbg(0, COL_IsReceived))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsReceived) = bFlag
                Next
            Case COL_Note
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsReceived
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T3030s
    '# Created User: DUCTRONG
    '# Created Date: 16/06/2009 03:36:10
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date: 07/05/2012 10:05:31
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T3030s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsReceived)) Then
                sSQL.Append("-- Insert du lieu vao bang D13T3030" & vbCrLf)
                sSQL.Append("Insert Into D13T3030(")
                sSQL.Append("EmployeeID, IsReceived, TranMonth, TranYear, CreateUserID, ")
                sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate, SeniorityMonth, SeniorityYear, ")
                sSQL.Append("SeverancePay, TotalSeverancePay, SeverancePayMonthNum, Note, NoteU," & vbCrLf)
                sSQL.Append("RefU01, RefU02, RefU03, RefU04, " & vbCrLf)
                sSQL.Append("RefU05, SeverancePayMonth01, SeverancePayMonth02, SeverancePayMonth03, SeverancePayMonth04, " & vbCrLf)
                sSQL.Append("SeverancePayMonth05, SeverancePayMonth06")
                sSQL.Append(") Values( " & vbCrLf)
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(tdbg(i, COL_IsReceived)) & COMMA) 'IsReceived, tinyint, NOT NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLNumber(tdbg(i, COL_SeniorityMonth)) & COMMA) 'SeniorityMonth, int, NOT NULL
                sSQL.Append(SQLNumber(tdbg(i, COL_SeniorityYear)) & COMMA) 'SeniorityYear, int, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePay), D13Format.DefaultNumber2) & COMMA) 'SeverancePay, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_TotalSeverancePay), tdbg.Columns(COL_TotalSeverancePay).NumberFormat) & COMMA) 'TotalSeverancePay, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonthNum), tdbg.Columns(COL_SeverancePayMonthNum).NumberFormat) & COMMA) 'TotalSeverancePay, decimal, NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'Note
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NoteU
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefU01), gbUnicode, True) & COMMA & vbCrLf) 'RefU01, nvarchar[1000], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefU02), gbUnicode, True) & COMMA) 'RefU02, nvarchar[1000], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefU03), gbUnicode, True) & COMMA) 'RefU03, nvarchar[1000], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefU04), gbUnicode, True) & COMMA) 'RefU04, nvarchar[1000], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefU05), gbUnicode, True) & COMMA & vbCrLf) 'RefU05, nvarchar[1000], NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth01), tdbg.Columns(COL_SeverancePayMonth01).NumberFormat) & COMMA) 'SeverancePayMonth01, money, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth02), tdbg.Columns(COL_SeverancePayMonth02).NumberFormat) & COMMA) 'SeverancePayMonth02, money, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth03), tdbg.Columns(COL_SeverancePayMonth03).NumberFormat) & COMMA) 'SeverancePayMonth03, money, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth04), tdbg.Columns(COL_SeverancePayMonth04).NumberFormat) & COMMA & vbCrLf) 'SeverancePayMonth04, money, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth05), tdbg.Columns(COL_SeverancePayMonth05).NumberFormat) & COMMA) 'SeverancePayMonth05, money, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_SeverancePayMonth06), tdbg.Columns(COL_SeverancePayMonth06).NumberFormat)) 'SeverancePayMonth06, money, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T3030s
    '# Created User: DUCTRONG
    '# Created Date: 16/06/2009 03:38:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T3030s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            If Not CBool(tdbg(i, COL_IsReceived)) Then
                sSQL = ""
                sSQL &= "Delete From D13T3030 "
                sSQL &= " Where EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID))
                sRet &= sSQL & vbCrLf
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3020
    '# Created User: DUCTRONG
    '# Created Date: 14/04/2008 04:54:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3020 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsMode, tinyint, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsReceived.Checked) & COMMA 'IsReceived, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns(0).Value) & COMMA 'PeriodFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns(0).Value) & COMMA 'PeriodTo, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA  'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) & COMMA 'EmpStopWork, varchar[50], NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftFrom.Value) & COMMA 'DateLeftFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftTo.Value) 'DateLeftTo, datetime, NOT NULL
        Return sSQL
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
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub Call_D09U1111Refresh()
        'Chuẩn hóa D09U1111 B6: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
        'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
        If usrOption IsNot Nothing Then
            usrOption.MarkInvisibleColumn(SPLIT1)
            usrOption.D09U1111Refresh()
        End If
    End Sub
#End Region

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl 
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 04/11/2013 04:42:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang tam nhan vien nghi viec" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D13F3020'"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3024
    '# Created User: Hoàng Nhân
    '# Created Date: 04/11/2013 04:45:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3024() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat thong tin da tinh tro cap thoi viec" & vbCrLf)
        sSQL &= "Exec D13P3024 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F3020") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0050
    '# Created User: Lê Anh Vũ
    '# Created Date: 19/05/2015 09:52:59
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0050() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do Caption dong cho luoi" & vbCrLf)
        sSQL &= "Exec D13P0050 "
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[50], NOT NULL
        Return sSQL
    End Function




    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnClose)
    End Sub

    Private Sub btnSeverancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeverancePay.Click
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT2
        tdbg.Col = COL_RefU01
        btnSeverancePay.Enabled = False
        btnImformation.Enabled = True
    End Sub
    Private Sub btnImformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImformation.Click
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT2
        tdbg.Col = COL_SeverancePayMonth01
        btnSeverancePay.Enabled = True
        btnImformation.Enabled = False
    End Sub
End Class