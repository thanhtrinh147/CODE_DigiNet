Public Class D13F3030
	Dim report As D99C2003
	Dim dtCaptionCols As DataTable

#Region "Const of tdbgD"
    Private Const COL_EmployeeID As Integer = 0        ' Mã NV
    Private Const COL_EmployeeName As Integer = 1      ' Họ và tên
    Private Const COL_BlockID As Integer = 2           ' Khối
    Private Const COL_BlockName As Integer = 3         ' Tên khối
    Private Const COL_DepartmentID As Integer = 4      ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6            ' Tổ nhóm
    Private Const COL_TeamName As Integer = 7          ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8        ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 9      ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 10           ' Chức vụ
    Private Const COL_DutyName As Integer = 11         ' Tên chức vụ
    Private Const COL_WorkID As Integer = 12           ' WorkID
    Private Const COL_WorkName As Integer = 13         ' WorkName
    Private Const COL_Birthdate As Integer = 14        ' Ngày sinh
    Private Const COL_SexName As Integer = 15          ' SexName
    Private Const COL_DateJoined As Integer = 16       ' DateJoined
    Private Const COL_DateLeft As Integer = 17         ' DateLeft
    Private Const COL_Age As Integer = 18              ' Age
    Private Const COL_StatusID As Integer = 19         ' StatusID
    Private Const COL_StatusName As Integer = 20       ' StatusName
    Private Const COL_AttendanceCardNo As Integer = 21 ' AttendanceCardNo
    Private Const COL_RefEmployeeID As Integer = 22    ' RefEmployeeID
    Private Const COL_CreateUserID As Integer = 23     ' CreateUserID
    Private Const COL_CreateDate As Integer = 24       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 25 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 26   ' LastModifyDate
    Private Const COL_FromMonthYear As Integer = 27    ' Từ tháng năm
    Private Const COL_ToMonthYear As Integer = 28      ' Đến tháng năm
    Private Const COL_MonthTotal As Integer = 29       ' Tổng số tháng
    Private Const COL_OldDutyName As Integer = 30      ' Công việc
    Private Const COL_Note As Integer = 31             ' Ghi chú
    Private Const COL_SalEmpGroupName As Integer = 32  ' Nhóm lương
    Private Const COL_BaseSalary01 As Integer = 33     ' BaseSalary01
    Private Const COL_BaseSalary02 As Integer = 34     ' BaseSalary02
    Private Const COL_BaseSalary03 As Integer = 35     ' BaseSalary03
    Private Const COL_BaseSalary04 As Integer = 36     ' BaseSalary04
    Private Const COL_SalCoefficient01 As Integer = 37 ' SalCoefficient01
    Private Const COL_SalCoefficient02 As Integer = 38 ' SalCoefficient02
    Private Const COL_SalCoefficient03 As Integer = 39 ' SalCoefficient03
    Private Const COL_SalCoefficient04 As Integer = 40 ' SalCoefficient04
    Private Const COL_SalCoefficient05 As Integer = 41 ' SalCoefficient05
    Private Const COL_SalCoefficient06 As Integer = 42 ' SalCoefficient06
    Private Const COL_SalCoefficient07 As Integer = 43 ' SalCoefficient07
    Private Const COL_SalCoefficient08 As Integer = 44 ' SalCoefficient08
    Private Const COL_SalCoefficient09 As Integer = 45 ' SalCoefficient09
    Private Const COL_SalCoefficient10 As Integer = 46 ' SalCoefficient10
    Private Const COL_OfficalTitleID As Integer = 47   ' Ngạch lương 1
    Private Const COL_SalaryLevelID As Integer = 48    ' Bậc lương 1
    Private Const COL_SaCoefficient As Integer = 49    ' SaCoefficient
    Private Const COL_SaCoefficient12 As Integer = 50  ' SaCoefficient12
    Private Const COL_SaCoefficient13 As Integer = 51  ' SaCoefficient13
    Private Const COL_SaCoefficient14 As Integer = 52  ' SaCoefficient14
    Private Const COL_SaCoefficient15 As Integer = 53  ' SaCoefficient15
    Private Const COL_OfficalTitleID2 As Integer = 54  ' Ngạch lương 2
    Private Const COL_SalaryLevelID2 As Integer = 55   ' SalaryLevelID2
    Private Const COL_SaCoefficient2 As Integer = 56   ' SaCoefficient2
    Private Const COL_SaCoefficient22 As Integer = 57  ' SaCoefficient22
    Private Const COL_SaCoefficient23 As Integer = 58  ' SaCoefficient23
    Private Const COL_SaCoefficient24 As Integer = 59  ' SaCoefficient24
    Private Const COL_SaCoefficient25 As Integer = 60  ' SaCoefficient25
#End Region


#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
#End Region

    Dim dtLoadCaPTION As DataTable
    Dim dtEmployeeID As New DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtFind As DataTable
    Dim dtCaption As DataTable
    Dim sFind As String = ""

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcTeamID
        sSQL = "SELECT   	    D01.TeamID,"
        sSQL &= IIf(gbUnicode, "D01.TeamNameU As  TeamName", "D01.TeamName").ToString
        sSQL &= ", D01.DepartmentID, D02.BlockID, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM  	        D09T0227 D01  WITH(NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN 	D91T0012 D02  WITH(NOLOCK) On D02.DepartmentID = D01.DepartmentID " & vbCrLf
        sSQL &= "WHERE      	D01.Disabled = 0 AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "UNION  " & vbCrLf
        sSQL &= "SELECT 	    '%' As TeamID, "
        sSQL &= AllName
        sSQL &= "  As TeamName, '%' As DepartmentID, '%' As BlockID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "ORDER BY	     DisplayOrder, D01.TeamID"
        dtTeamID = ReturnDataTable(sSQL)

        'Load tdbcDepartmentID
        sSQL = "SELECT    	DepartmentID,  "
        sSQL &= IIf(gbUnicode, "DepartmentNameU as DepartmentName,", "DepartmentName,").ToString
        sSQL &= " BlockID, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM 	    D91T0012  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE 	    DivisionID = " & SQLString(gsDivisionID) & " AND Disabled = 0 " & vbCrLf
        sSQL &= "UNION  " & vbCrLf
        sSQL &= "SELECT	    '%' As DepartmentID,  "
        sSQL &= AllName
        sSQL &= "  As DepartmentName, '%' As BlockID, 0 As DisplayOrder " & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder, DepartmentID"

        'LoadDataSource(tdbcDepartmentID, sSQL)
        dtDepartmentID = ReturnDataTable(sSQL)

        sSQL = "Select BlockID, "
        sSQL &= IIf(gbUnicode, "BlockNameU as BlockName", "BlockName").ToString
        sSQL &= ", DivisionID, 1 As DisplayOrder From D09T1140  WITH(NOLOCK) Where Disabled =0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union Select '%' As BlockID, "
        sSQL &= AllName
        sSQL &= " As BlockName, '%' As DivisionID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Order by DisplayOrder, BlockID"
        LoadDataSource(tdbcBlockID, sSQL, gbUnicode)


        sSQL = "Select '%' as WorkingStatusID, "
        sSQL &= AllName
        sSQL &= " As WorkingStatusName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union Select WorkingStatusID, "
        sSQL &= IIf(gbUnicode, "WorkingStatusNameU as WorkingStatusName, 1 As DisplayOrder", "WorkingStatusName, 1 As DisplayOrder").ToString
        sSQL &= " From D09T0070  WITH(NOLOCK) Where Disabled = 0 Order by DisplayOrder, WorkingStatusID"
        LoadDataSource(tdbcWorkingStatusID, sSQL, gbUnicode)

        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")

        sSQL = " SELECT	'%' AS EmployeeID, "
        sSQL &= AllName
        sSQL &= " AS EmployeeName, '%' AS DepartmentID , '%' AS TeamID, '%' AS BlockID, 0 As DisplayOrder " & vbCrLf
        sSQL &= " UNION" & vbCrLf
        sSQL &= " SELECT 		T1.EmployeeID , " & vbCrLf
        If gbUnicode Then
            sSQL &= " Isnull(LastNameU,'') +' '+ Isnull(MiddleNameU,'') +' ' + Isnull(FirstNameU,'')"
        Else
            sSQL &= " Isnull(LastName,'') +' '+ Isnull(MiddleName,'') +' ' + Isnull(FirstName,'')"
        End If
        sSQL &= " As EmployeeName, "
        sSQL &= " T1.DepartmentID, T1.TeamID,  T2.BlockID, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM 		D09T0201 T1  WITH(NOLOCK) " & vbCrLf
        sSQL &= " INNER JOIN	D91T0012 T2  WITH(NOLOCK) ON T1.DepartmentID = T2.DepartmentID" & vbCrLf
        sSQL &= " LEFT JOIN 	D09T0227  T3  WITH(NOLOCK) On T1.TeamID = T3.TeamID" & vbCrLf
        sSQL &= " WHERE 		T1.Disabled = 0 AND T1.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by DisplayOrder, BlockID, DepartmentID, TeamID, EmployeeID"
        dtEmployeeID = ReturnDataTable(sSQL)
        'LoadDataSource(tdbcEmployeeID, dtEmployeeID.Copy)

    End Sub

    '    Private Sub LoadtdbcEmployeeID(ByVal sBlockID As String, ByVal sDeptID As String, ByVal sTeamID As String)
    '        If sBlockID <> "%" And sDeptID <> "%" And sTeamID <> "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or (BlockID = " & SQLString(sBlockID) & " And DepartmentID = " & SQLString(sDeptID) & " And TeamID = " & SQLString(sTeamID) & ")"), gbUnicode)
    '        ElseIf sBlockID <> "%" And sDeptID = "%" And sTeamID = "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or BlockID = " & SQLString(sBlockID)), gbUnicode)
    '        ElseIf sBlockID <> "%" And sDeptID <> "%" And sTeamID = "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or (BlockID = " & SQLString(sBlockID) & " And DepartmentID = " & SQLString(sDeptID) & ")"), gbUnicode)
    '        ElseIf sBlockID <> "%" And sDeptID = "%" And sTeamID <> "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or (BlockID = " & SQLString(sBlockID) & " And TeamID = " & SQLString(sTeamID) & ")"), gbUnicode)
    '        ElseIf sBlockID = "%" And sDeptID <> "%" And sTeamID <> "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or (DepartmentID = " & SQLString(sDeptID) & " And TeamID = " & SQLString(sTeamID) & ")"), gbUnicode)
    '        ElseIf sBlockID = "%" And sDeptID = "%" And sTeamID <> "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or TeamID = " & SQLString(sTeamID)), gbUnicode)
    '        ElseIf sBlockID = "%" And sDeptID <> "%" And sTeamID = "%" Then
    '            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "EmployeeID = '%' Or DepartmentID = " & SQLString(sDeptID)), gbUnicode)
    '        ElseIf sBlockID = "%" And sDeptID = "%" And sTeamID = "%" Then
    '            LoadDataSource(tdbcEmployeeID, dtEmployeeID.Copy, gbUnicode)
    '        End If
    '        Me.tdbcEmployeeID.SelectedIndex = 0
    '    End Sub

    Private Sub D13F3030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShow_Click(Nothing, Nothing)
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

    Private Sub D13F3030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Loadlanguage()
        tdbgM.Splits(0).DisplayColumns(COL_BlockID).Visible = D13Systems.IsUseBlock
        tdbgM.Splits(0).DisplayColumns(COL_BlockName).Visible = D13Systems.IsUseBlock
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID)
        SetShortcutPopupMenu(C1CommandHolder)

        ResetColorGrid(tdbgM)
        ResetColorGrid(tdbgD, 0, 1)

        LoadTDBCombo()
        tdbcBlockID.SelectedValue = "%"
        tdbcWorkingStatusID.SelectedValue = "%"
        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        chkPeriod_CheckedChanged(Nothing, Nothing)
        tdbcDepartmentID.AutoSelect = True

        GridCaption()

        btnSal_Click(Nothing, Nothing)
        tdbcBlockID.Enabled = D13Systems.IsUseBlock

        ResetGrid()
        InputDateInTrueDBGrid(tdbgM, COL_DateJoined, COL_DateLeft, COL_DateJoined, COL_DateLeft)
        InputDateInTrueDBGrid(tdbgD, COL_DateJoined, COL_DateLeft, COL_DateJoined, COL_DateLeft)


        'dtLoadCaPTION = CreateTableForExcel(tdbgM)
        'usrOption = New D09U1111(tdbgM, dtLoadCaPTION.Copy, Me.Name.Substring(1, 2), Me.Name)

        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad
        Dim Arr As New ArrayList
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_EmployeeID}
        AddColVisible(tdbgM, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbgM, Arr)
        usrOption = New D09U1111(tdbgM, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , True, , , gbUnicode)
        '*****************************************
       
        SetResolutionForm(Me, C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_lich_su_luong_-_D13F3030") & UnicodeCaption(gbUnicode) 'Truy vÊn lÜch sõ l§¥ng - D13F3030
        '================================================================ 
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblStrEmployeeID.Text = rL3("Ma_NV")
        lblStrEmployeeName.Text = rL3("Ten_NV")
        '================================================================ 
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnShow.Text = "&" & rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnOfficialTitle.Text = rl3("Ngach_bac_luong") 'Ngạch/ Bậc lương
        btnSal.Text = rl3("Muc_luong_He_so") 'Mức lương/ Hệ số
        btnFilter.Text = rl3("_Loc") '&Lọc
        '================================================================ 
        chkPeriod.Text = rL3("Ky") 'Kỳ
        '================================================================ 
        chkEmpWorking.Text = rL3("Nhan_vien_dang_lam_viec") 'NV đang làm việc
        chkEmpStopWork.Text = rL3("Nhan_vien_da_nghi_viec") 'NV đã nghỉ việc
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ

        '================================================================ 
        tdbgM.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbgM.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbgM.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbgM.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbgM.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbgM.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbgM.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbgM.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgM.Columns("EmpGroupID").Caption = rl3("Nhom_NV") 'Mã nhân viên
        tdbgM.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Họ và tên
        tdbgM.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbgM.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbgM.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh

        tdbgM.Columns("FromMonthYear").Caption = rl3("Tu_thang_nam") 'Từ tháng năm
        tdbgM.Columns("ToMonthYear").Caption = rl3("Den_thang_nam") 'Đến tháng năm
        tdbgM.Columns("MonthTotal").Caption = rl3("Tong_so_thang") 'Tổng số tháng
        tdbgM.Columns("OldDutyName").Caption = rl3("Cong_viec") 'Công việc
        tdbgM.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbgM.Columns("SalEmpGroupName").Caption = rl3("Nhom_luong") 'Nhóm lương
        tdbgM.Splits(0).Caption = rl3("Thong_tin_chinh")
        ' update 15/11/2012 id 51174
        tdbgM.Columns("SexName").Caption = rl3("Gioi_tinh")
        tdbgM.Columns("WorkID").Caption = rl3("Cong_viec")
        tdbgM.Columns("WorkName").Caption = rl3("Ten_cong_viec")
        tdbgM.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbgM.Columns("DateLeft").Caption = rl3("Ngay_nghi_viec")
        tdbgM.Columns("Age").Caption = rl3("Tuoi")
        tdbgM.Columns("StatusID").Caption = rl3("Trang_thai_lam_viec")
        tdbgM.Columns("StatusName").Caption = rl3("Ten_trang_thai_lam_viec")
        tdbgM.Columns("AttendanceCardNo").Caption = rl3("Ma_the_cham_cong")
        tdbgM.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ

        tdbgD.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbgD.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbgD.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbgD.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbgD.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbgD.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbgD.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbgD.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgD.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbgD.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbgD.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh

        tdbgD.Columns("FromMonthYear").Caption = rl3("Tu_thang_nam") 'Từ tháng năm
        tdbgD.Columns("ToMonthYear").Caption = rl3("Den_thang_nam") 'Đến tháng năm
        tdbgD.Columns("MonthTotal").Caption = rl3("Tong_so_thang") 'Tổng số tháng
        tdbgD.Columns("OldDutyName").Caption = rl3("Cong_viec") 'Công việc
        tdbgD.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbgD.Columns("SalEmpGroupName").Caption = rl3("Nhom_luong") 'Nhóm lương
        tdbgD.Splits(0).Caption = rl3("Lich_su")

        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuExportToExcel.Text = rl3("Xuat__Excel") 'Xuất &Excel
        mnuPrint.Text = rl3("_In") '&In
    End Sub



    Public Structure OLSC
        Public OfficialTitleID As Boolean
        Public SalaryLevelID As Boolean
        Public SaCoefficient As Boolean
        Public SaCoefficient12 As Boolean
        Public SaCoefficient13 As Boolean
        Public SaCoefficient14 As Boolean
        Public SaCoefficient15 As Boolean

        Public OfficialTitleID2 As Boolean
        Public SalaryLevelID2 As Boolean
        Public SaCoefficient2 As Boolean
        Public SaCoefficient22 As Boolean
        Public SaCoefficient23 As Boolean
        Public SaCoefficient24 As Boolean
        Public SaCoefficient25 As Boolean

    End Structure

    Private Sub GridCaption()
        Dim sSQL As String
        sSQL = "Select * From D13T9000  WITH(NOLOCK)  Order By Code "
        dtCaption = ReturnDataTable(sSQL)

        GetCaptionSalBase()

        GetCaptionSalCoeff(SPLIT1, COL_SalCoefficient01)

        dtOLSC = ReturnTableFilter(dtCaption, " Type = 'OLSC'")
        LoadCaption_7ColOfficalTitle_Grid(tdbgD, SPLIT1, dtOLSC)

        With OT
            .OfficialTitleID = Not CBool(dtOLSC.Rows(0).Item("Disabled"))
            .SalaryLevelID = Not CBool(dtOLSC.Rows(1).Item("Disabled"))
            .SaCoefficient = Not CBool(dtOLSC.Rows(2).Item("Disabled"))
            .SaCoefficient12 = Not CBool(dtOLSC.Rows(3).Item("Disabled"))
            .SaCoefficient13 = Not CBool(dtOLSC.Rows(4).Item("Disabled"))
            .SaCoefficient14 = Not CBool(dtOLSC.Rows(5).Item("Disabled"))
            .SaCoefficient15 = Not CBool(dtOLSC.Rows(6).Item("Disabled"))

            .OfficialTitleID2 = Not CBool(dtOLSC.Rows(7).Item("Disabled"))
            .SalaryLevelID2 = Not CBool(dtOLSC.Rows(8).Item("Disabled"))
            .SaCoefficient2 = Not CBool(dtOLSC.Rows(9).Item("Disabled"))
            .SaCoefficient22 = Not CBool(dtOLSC.Rows(10).Item("Disabled"))
            .SaCoefficient23 = Not CBool(dtOLSC.Rows(11).Item("Disabled"))
            .SaCoefficient24 = Not CBool(dtOLSC.Rows(12).Item("Disabled"))
            .SaCoefficient25 = Not CBool(dtOLSC.Rows(13).Item("Disabled"))
        End With
    End Sub

    Private Sub GetCaptionSalBase()
        dtSalBase = ReturnTableFilter(dtCaption, "Type='SALBA'")

        For i As Integer = 0 To dtSalBase.Rows.Count - 1
            BA(i) = Not CBool(dtSalBase.Rows(i).Item("Disabled"))
            tdbgD.Columns(COL_BaseSalary01 + i).NumberFormat = InsertFormat(dtSalBase.Rows(i).Item("Decimals").ToString)
            If gbUnicode Then
                tdbgD.Splits(SPLIT1).DisplayColumns(COL_BaseSalary01 + i).HeadingStyle.Font = FontUnicode()
            Else
                tdbgD.Splits(SPLIT1).DisplayColumns(COL_BaseSalary01 + i).HeadingStyle.Font = New System.Drawing.Font("Lemon3", 8.249999!)
            End If
            tdbgD.Columns(COL_BaseSalary01 + i).Caption = dtSalBase.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString

        Next

    End Sub

    Dim dtSalBase As DataTable
    Dim dtSalCoeff As DataTable
    Dim dtOLSC As DataTable
    Dim BA(3) As Boolean
    Dim CE(9) As Boolean
    Dim OT As OLSC

    Private Enum Button
        SalCoeff
        OfficalSalLevel
    End Enum
    Dim iLastCol1 As Integer

    Private Sub GetCaptionSalCoeff(ByVal Split As Integer, ByVal colFrom As Integer)
        dtSalCoeff = ReturnTableFilter(dtCaption, "Type='SALCE'")

        For i As Integer = 0 To 9 'dtSalCoeff.Rows.Count - 1
            CE(i) = Not CBool(dtSalCoeff.Rows(i).Item("Disabled"))
            tdbgD.Columns(COL_SalCoefficient01 + i).NumberFormat = InsertFormat(dtSalCoeff.Rows(i).Item("Decimals").ToString)
            If gbUnicode Then
                tdbgD.Splits(1).DisplayColumns(COL_SalCoefficient01 + i).HeadingStyle.Font = FontUnicode()
            Else
                tdbgD.Splits(1).DisplayColumns(COL_SalCoefficient01 + i).HeadingStyle.Font = New System.Drawing.Font("Lemon3", 8.249999!)
            End If
            tdbgD.Columns(COL_SalCoefficient01 + i).Caption = dtSalCoeff.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
        Next

    End Sub

    Private Sub btnSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSal.Click
        tdbgD.Splits(SPLIT1).Caption = rl3("Muc_luong_He_so")
        ClickButton(Button.SalCoeff)
    End Sub

    Private Sub btnOfficialTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfficialTitle.Click
        tdbgD.Splits(SPLIT1).Caption = rl3("Ngach_bac_luong")
        ClickButton(Button.OfficalSalLevel)
    End Sub

    Private Sub ClickButton(ByVal button As Button)

        btnSal.Enabled = Math.Abs(button - button.SalCoeff) > 0
        btnOfficialTitle.Enabled = Math.Abs(button - button.OfficalSalLevel) > 0

        ' Thông tin điều chuyển lương
        With tdbgD.Splits(1)
            For i As Integer = 0 To 3
                .DisplayColumns(COL_BaseSalary01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And BA(i)
            Next i

            For i As Integer = 0 To 9
                .DisplayColumns(COL_SalCoefficient01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And CE(i)
            Next i


            .DisplayColumns(COL_OfficalTitleID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID
            .DisplayColumns(COL_SalaryLevelID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID
            .DisplayColumns(COL_SaCoefficient).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient
            .DisplayColumns(COL_SaCoefficient12).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient12
            .DisplayColumns(COL_SaCoefficient13).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient13
            .DisplayColumns(COL_SaCoefficient14).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient14
            .DisplayColumns(COL_SaCoefficient15).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient15

            .DisplayColumns(COL_OfficalTitleID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID2
            .DisplayColumns(COL_SalaryLevelID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID2
            .DisplayColumns(COL_SaCoefficient2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient2
            .DisplayColumns(COL_SaCoefficient22).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient22
            .DisplayColumns(COL_SaCoefficient23).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient23
            .DisplayColumns(COL_SaCoefficient24).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient24
            .DisplayColumns(COL_SaCoefficient25).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient25




            For i As Integer = COL_BaseSalary01 To COL_SaCoefficient25
                If tdbgD.Splits(1).DisplayColumns(i).Visible Then
                    tdbgD.Col = i
                    tdbgD.SplitIndex = 1
                    tdbgD.Row = tdbgD.Row
                    'tdbg.Focus()
                    Exit For
                End If
            Next i


        End With

        iLastCol1 = CountCol(tdbgD, SPLIT1)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3030
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 30/10/2009 03:29:49
    '# Modified User: Trần Hoàng Nhân
    '# Modified Date: 22/10/2012 10:07:00
    '# Description: id 51535
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3030() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho Luoi trai " & vbCrLf)
        sSQL &= "Exec D13P3030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcBlockID.Columns("BlockID").Value.ToString) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.Columns("DepartmentID").Value.ToString) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.Columns("TeamID").Value.ToString) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcWorkingStatusID.Columns("WorkingStatusID").Value.ToString) & COMMA 'WorkingSatusID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA ' 22/10/2012 id 51535' sSQL &= SQLString(tdbcEmployeeID.Columns("EmployeeID").Value.ToString) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        ' update 22/10/2012 id 51535' 
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtStrEmployeeName.Text, True, True) & COMMA 'StrEmployeeName, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkEmpWorking.Checked) & COMMA 'EmpWorking, tinyint, NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) 'EmpStopWork, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0103
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 03/11/2009 11:30:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0103() As String
        Dim sSQL As String = ""
        Dim iPeriodFrom, iPeriodTo As Integer
        If chkPeriod.Checked Then
            iPeriodFrom = CInt(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + CInt(tdbcPeriodFrom.Columns("TranMonth").Text)
            iPeriodTo = CInt(tdbcPeriodTo.Columns("TranYear").Text) * 100 + CInt(tdbcPeriodTo.Columns("TranMonth").Text)
        Else
            iPeriodFrom = 0
            iPeriodTo = 0
        End If

        sSQL &= "Exec D13P0103 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbgM.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkPeriod.Checked) & COMMA 'IsPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(iPeriodFrom) & COMMA 'MonthYearFrom, int, NOT NULL
        sSQL &= SQLNumber(iPeriodTo) & COMMA 'MonthYearTo, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)  'CodeTable, tinyint, NOT NULL
       
        Return sSQL
    End Function

    Dim iCol() As Integer = {COL_MonthTotal, COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04, _
     COL_SalCoefficient10, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10, _
     COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15, _
     COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25}

    Private Sub LoadTdbgM()
        dtFind = ReturnDataTable(SQLStoreD13P3030)
        LoadDataSource(tdbgM, dtFind, gbUnicode)
        ResetGrid()
        '        CheckMenu(Me.Name, C1CommandHolder, tdbgM.RowCount, gbEnabledUseFind, True)
        '        FooterTotalGrid(tdbgM, COL_EmployeeName)
        '        FooterSum(tdbgM, iCol)

    End Sub

    Private Sub LoadTdbgD()
        LoadDataSource(tdbgD, SQLStoreD13P0103, gbUnicode)
        'FooterTotalGrid(tdbgD, COL_FromMonthYear)
        FooterSum(tdbgD, iCol)
    End Sub

    Private Function AllowFilter() As Boolean
        If chkPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Tu_ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Den_ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If
            If Not CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub

        sFind = ""
        LoadTdbgM()
        LoadTdbgD()
    End Sub

    Private Sub tdbgM_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgM.RowColChange
        If tdbgM.RowCount < 1 Then Exit Sub
        If e.LastRow <> tdbgM.Row Then
            LoadTdbgD()
        End If

    End Sub

    Private Sub chkPeriod_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPeriod.CheckedChanged
        If chkPeriod.Checked Then
            UnReadOnlyControl(True, tdbcPeriodFrom, tdbcPeriodTo)
        Else
            ' update 22/10/2012 id 51535
            tdbcPeriodFrom.Text = ""
            tdbcPeriodTo.Text = ""
            ReadOnlyControl(tdbcPeriodFrom, tdbcPeriodTo)
        End If

    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbgM, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbgM.UpdateData()
        ResetTableForExcel(tdbgM, dtCaptionCols)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbgM, e) = False Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        'LoadGridFind(tdbgM, dtFind, sFind)
        dtFind.DefaultView.RowFilter = sFind
        ResetGrid()
        LoadTdbgD()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbgM.RowCount, gbEnabledUseFind, True)
        FooterTotalGrid(tdbgM, COL_EmployeeName)
        FooterSum(tdbgM, iCol)
    End Sub

#End Region

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbgM.Left, btnShow.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If CallMenuFromGrid(tdbgM, e) = False Then Exit Sub

        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbgM, dtLoadCaPTION)
        CallShowD99F2222(Me, dtLoadCaPTION, dtFind, gsGroupColumns)

        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = dtLoadCaPTION
        '            .dtExportTable = dtFind 'Bảng Dữ liệu
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        ShowSysInfoDialog(Me, tdbgM.Columns(COL_CreateUserID).Text, tdbgM.Columns(COL_CreateDate).Text, tdbgM.Columns(COL_LastModifyUserID).Text, tdbgM.Columns(COL_LastModifyDate).Text)
    End Sub

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = ""
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Or tdbcBlockID.Text = "" Then
            LoadTdbcDepartmentID("-1")
        Else
            LoadTdbcDepartmentID(tdbcBlockID.Columns("BlockID").Value.ToString)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events TdbcDepartmentID"
    Private Sub LoadTdbcDepartmentID(ByVal sBlockID As String)
        If sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, dtDepartmentID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID = '%' Or BlockID = " & SQLString(sBlockID)), gbUnicode)
        End If

    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.Text = "" Or tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1", "-1")

            Exit Sub
        End If
        LoadtdbcTeamID(tdbcBlockID.Columns("BlockID").Value.ToString, tdbcDepartmentID.SelectedValue.ToString)
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamID "

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If tdbcTeamID.Text = "" Or tdbcTeamID.SelectedValue Is Nothing Then

            ' ' 22/10/2012 id 51535   LoadtdbcEmployeeID("-1", "-1", "-1")
            Exit Sub
        End If
        ' ' 22/10/2012 id 51535  LoadtdbcEmployeeID(tdbcBlockID.Columns("BlockID").Value.ToString, tdbcDepartmentID.Columns("DepartmentID").Value.ToString, tdbcTeamID.Columns("TeamID").Value.ToString)
        '  ' 22/10/2012 id 51535 tdbcEmployeeID.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcTeamID(ByVal sBlockID As String, ByVal sDepartmentID As String)

        If sBlockID = "%" And sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, dtTeamID.Copy, gbUnicode)
        ElseIf sBlockID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID)), gbUnicode)
        ElseIf sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " BlockID = '%' or BlockID=" & SQLString(sBlockID)), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " (BlockID = '%' or BlockID=" & SQLString(sBlockID) & ") And (DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID) & ")"), gbUnicode)
        End If

    End Sub
#End Region

#Region "Events tdbcWorkingStatusID "

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then tdbcWorkingStatusID.Text = ""
    End Sub

#End Region

#Region "Events tdbcEmployeeID"
    ' 22/10/2012 id 51535
    '    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    '    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcWorkingStatusID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    ' update 22/10/2012 id 51535
    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R3030"
        Dim sSubReportName As String = "D91R0000" 'sub report hiện có
        Dim sReportCaption As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""

        sReportName = GetReportPath("D13F3030", sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Me.Cursor = Cursors.Default : Exit Sub

        sReportCaption = rL3("Lich_su_luongF") & " - " & sReportName
        sSQLSub = "Select * From D91V0016 Where DivisionID = " & SQLString(gsDivisionID)
        UnicodeSubReport(sSubReportName, sSQLSub, , gbUnicode)

        sSQL = SQLInsertD09T6666().ToString & vbCrLf
        sSQL &= SQLStoreD13P3031() & vbCrLf
        sSQL &= SQLDeleteD09T6666()

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 22/10/2012 10:36:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If tdbgM.RowCount > 0 Then sSQL.Append("-- Insert bang tam" & vbCrLf)
        For i As Integer = 0 To tdbgM.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID ")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F3030") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgM(i, COL_EmployeeID).ToString))  'Key01ID, varchar[250], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3031
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 22/10/2012 10:42:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3031() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho bao cao" & vbCrLf)
        sSQL &= "Exec D13P3031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranMonth").ToString) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranYear").ToString) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranMonth").ToString) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranYear").ToString) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 22/10/2012 10:45:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= " UserID = " & SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)  'HostID, varchar[20], NOT NULL"
        sSQL &= " AND FormID = " & SQLString("D13F3030")  'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, GroupBox1)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbgM)
        AnchorForControl(EnumAnchorStyles.TopRightBottom, tdbgD)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShow)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnlActiveClose)
        AnchorForControl(EnumAnchorStyles.TopRight, btnSal, btnOfficialTitle)
    End Sub

End Class
