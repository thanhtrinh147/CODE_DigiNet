Imports System
Imports System.Windows.Forms
Public Class D45F4020
	Dim report As D99C2003

  Private sSQLFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
            sSQLFind = Value
            btnPrint_Click(Nothing, Nothing)
            'ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private dtDepartmentID, dtTeamID, dtBlockID, dtEmpGroupID, dtEmployeeID, dtPeriodID As DataTable
    Dim bHeadClick As Boolean = False
    Dim bLoad As Boolean = False
    'Public iFlag As Boolean = True 'true:goi truc tiep tu menu Bao cao - False: ngc lai
    Private _flag As Boolean = True
    Public WriteOnly Property  Flag() As Boolean 
        Set(ByVal Value As Boolean )
            _flag = Value
        End Set
    End Property
#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0           ' Chọn
    Private Const COL_VoucherDate As Integer = 1      ' Ngày phiếu
    Private Const COL_PSalaryVoucherNo As Integer = 2 ' Số phiếu
    Private Const COL_PSalaryVoucherID As Integer = 3 ' PSalaryVoucherID
    Private Const COL_Description As Integer = 4      ' Diễn giải
#End Region

    Private _sFilter As String
    Public WriteOnly Property sFilter() As String
        Set(ByVal Value As String)
            _sFilter = Value
        End Set
    End Property

    Private _departmentID As String
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _pSalaryVoucherID As String = ""
    Public WriteOnly Property PSalaryVoucherID() As String
        Set(ByVal Value As String)
            _pSalaryVoucherID = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D29F4000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg, 0, COL_IsUsed)
        End If

        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tdbcDivisionID.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            optIsDetail1.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcBlockID.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad4 Or e.KeyCode = Keys.D4) Then
            c1dateExamineDate.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.D5) Then
            tdbg.Col = COL_IsUsed
            tdbg.SplitIndex = 0
            tdbg.Bookmark = 0
            tdbg.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub D29F4000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        tdbg_LockedColumns()
        LoadDefault()
        LoadTDBGrid()
        '-----------------------------------
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateToDate, c1dateFromDate, c1dateExamineDate)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me)
        bLoad = True
        tdbcNameAutoComplete()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        tdbcDivisionID.SelectedValue = gsDivisionID
        tdbcWorkingStatusID.SelectedValue = "%"
        tdbcReportCode.AutoSelect = True

        tdbcPeriodIDFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodIDTo.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        c1dateExamineDate.Value = Date.Today
        c1dateFromDate.Value = Date.Today
        c1dateToDate.Value = Date.Today

        If _flag = False Then
            tdbcDepartmentID.SelectedValue = _departmentID
            tdbcTeamID.SelectedValue = _teamID
            optPeriod.Enabled = False
            optDate.Enabled = False
            ReadOnlyControl(tdbcPeriodIDFrom)
            ReadOnlyControl(tdbcPeriodIDTo)
            tdbg.AllowUpdate = False
        End If

        btnFilter.Visible = _flag
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PSalaryVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_phieu_luong_san_pham_-_D45F4020") & UnicodeCaption(gbUnicode) 'BÀo cÀo phiÕu l§¥ng s¶n phÈm - D45F4020
        '================================================================ 
        lblEmployeeIDFrom.Text = rl3("Nhan_vien") 'Nhân viên
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rL3("To_nhom") 'Tổ nhóm
        lblEmpGroupID.Text = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        lblReportID.Text = rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblCustomizeReport.Text = rl3("Dac_thu") 'Đặc thù
        lblteExamineDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblGroupProductID.Text = rl3("Nhom_san_pham")
        '================================================================ 
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        '================================================================ 
        optIsDetail0.Text = rl3("Tong_hop") 'Tổng hợp
        optIsDetail1.Text = rl3("Chi_tiet") 'Chi tiết
        optPeriod.Text = rl3("Ky") 'Kỳ
        optDate.Text = rl3("Ngay") 'Ngày
        '================================================================ 
        grpDivisionID.Text = "1." & Space(1) & rl3("Don_vi") 'Đơn vị
        grpReport.Text = "2." & Space(1) & rl3("Mau_bao_cao") 'Mẫu báo cáo
        grpFilter.Text = "3." & Space(1) & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        grpTime.Text = "4." & Space(1) & rl3("Thoi_gian") 'Thời gian
        grpPayroll.Text = "5." & Space(1) & rl3("Phieu_luong_san_pham") 'Phiếu lương sản phẩm
        '================================================================ 
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên 
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã 
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rL3("Ma") 'Mã
        tdbcEmpGroupID.Columns("EmpGroupName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcReportCode.Columns("ReportCode").Caption = rl3("Ma") 'Mã
        tdbcReportCode.Columns("ReportTitle").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcPeriodIDTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodIDFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("PSalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcGroupProductID.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        CreateData()

        'Load tdbcDivisionID
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode)

        'LoadtdbcReportID
        sSQL = "SELECT T1.ReportCode, T1.ReportName" & UnicodeJoin(gbUnicode) & " as ReportName, T1.ReportTitle" & UnicodeJoin(gbUnicode) & " as ReportTitle, T1.ReportID, T1.CustomReportID, T2.Title" & UnicodeJoin(gbUnicode) & " as ReportTypeName" & vbCrLf
        sSQL &= "FROM D45T4030 T1  WITH(NOLOCK) LEFT JOIN	D89T1000 T2  WITH(NOLOCK) ON	T1.CustomReportID = T2.ReportID" & vbCrLf
        sSQL &= "WHERE T1.Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY T1.ReportCode"
        LoadDataSource(tdbcReportCode, sSQL, gbUnicode)

        'Load tdbcWorkingStatusID
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)
        'Load tdbcGroupProductID
        sSQL = "Select '%' As GroupProductID, " & IIf(gbUnicode, "N'" & rl3("Tat_caU"), "'" & rl3("Tat_caV")).ToString & "' As GroupProductName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union " & vbCrLf
        sSQL &= "Select GroupProductID, GroupProductName" & UnicodeJoin(gbUnicode) & " As GroupProductName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "From D45T1070 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, GroupProductID"
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)
    End Sub

    Private Sub CreateData()
        Dim sSQL As String = ""

        dtPeriodID = LoadTablePeriodReport("D09")

        'Load tdbcBlockID 
        dtBlockID = ReturnTableBlockID(, , gbUnicode)

        'DepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'TeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'EmpGroupID
        dtEmpGroupID = ReturnTableEmpGroupID(, gbUnicode)

        'tdbcEmployeeID
        dtEmployeeID = ReturnTableEmployeeID(, , gbUnicode)
    End Sub

    Private Sub LoadtdbcBlockID()
        If CbVal(tdbcDivisionID) = "%" Then
            LoadDataSource(tdbcBlockID, ReturnTableFilter(dtBlockID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcBlockID, ReturnTableFilter(dtBlockID, "DivisionID = " & SQLString(CbVal(tdbcDivisionID)) & " or BlockID = '%'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcDepartmentID()
        Dim sDivisionID As String = CbVal(tdbcDivisionID)
        Dim sBlockID As String = CbVal(tdbcBlockID)

        If sDivisionID = "%" Then
            If sBlockID = "%" Then
                LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, ""), gbUnicode)
            Else
                LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID=" & SQLString(sBlockID) & " or DepartmentID = '%'", True), gbUnicode)
            End If
        Else
            If sBlockID = "%" Then
                Dim dt As DataTable = ReturnTableFilter(dtDepartmentID, "DivisionID=" & SQLString(sDivisionID) & " or DepartmentID = '%'", True)
                LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID=" & SQLString(sDivisionID) & " or DepartmentID = '%'", True), gbUnicode)
            Else
                LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID=" & SQLString(sDivisionID) & " And BlockID=" & SQLString(sBlockID) & " or DepartmentID = '%'", True), gbUnicode)
            End If
        End If
    End Sub

    Private Sub LoadtdbcTeamID()
        Dim sDivisionID As String = CbVal(tdbcDivisionID)
        Dim sBlockID As String = CbVal(tdbcBlockID)
        Dim sDepartmentID As String = CbVal(tdbcDepartmentID)

        If sDivisionID = "%" Then
            If sDepartmentID = "%" AndAlso sBlockID = "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
            ElseIf sBlockID = "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & "or TeamID='%'", True), gbUnicode)
            ElseIf sBlockID <> "%" AndAlso sDepartmentID = "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "BlockID=" & SQLString(sBlockID) & "or TeamID='%'", True), gbUnicode)
            ElseIf sBlockID <> "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or TeamID='%'", True), gbUnicode)
            End If
        Else
            If sDepartmentID = "%" AndAlso sBlockID = "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID=" & SQLString(sDivisionID) & "or TeamID='%'", True), gbUnicode)
            ElseIf sBlockID = "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & "or TeamID='%'", True), gbUnicode)
            ElseIf sBlockID <> "%" AndAlso sDepartmentID = "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID=" & SQLString(sDivisionID) & " And BlockID=" & SQLString(sBlockID) & "or TeamID='%'", True), gbUnicode)
            ElseIf sBlockID <> "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or TeamID='%'", True), gbUnicode)
            End If
        End If
    End Sub

    '    Private Sub LoadtdbcEmployeeID()
    '        Dim sDivisionID As String = CbVal(tdbcDivisionID)
    '        Dim sBlockID As String = CbVal(tdbcBlockID)
    '        Dim sDepartmentID As String = CbVal(tdbcDepartmentID)
    '        Dim sTeamID As String = CbVal(tdbcTeamID)
    '        Dim sWorkingStatusID As String = CbVal(tdbcWorkingStatusID)
    '
    '        If sDivisionID = "%" Then
    '            If sBlockID = "%" Then
    '                If sWorkingStatusID = "%" Then
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, ""), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                Else
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                End If
    '
    '            Else
    '                If sWorkingStatusID = "%" Then
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                Else
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                End If
    '            End If
    '
    '        Else
    '            If sBlockID = "%" Then
    '                If sWorkingStatusID = "%" Then
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                Else
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                End If
    '
    '            Else
    '                If sWorkingStatusID = "%" Then
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                Else
    '                    If sDepartmentID = "%" AndAlso sTeamID = "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    Else
    '                        LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DivisionID=" & SQLString(sDivisionID) & " And DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End Sub

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        LoadtdbcBlockID()
        tdbcBlockID.SelectedValue = "%"
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadCboPeriodReport(tdbcPeriodIDFrom, tdbcPeriodIDTo, dtPeriodID, "")
            tdbcPeriodIDFrom.Text = ""
            tdbcPeriodIDTo.Text = ""
        Else
            LoadCboPeriodReport(tdbcPeriodIDFrom, tdbcPeriodIDTo, dtPeriodID, tdbcDivisionID.SelectedValue.ToString)
            tdbcPeriodIDFrom.Text = tdbcPeriodIDFrom.Columns("Period").Text
            tdbcPeriodIDTo.Text = tdbcPeriodIDTo.Columns("Period").Text
        End If
    End Sub

#End Region

#Region "Events tdbcReportID with txtReportName"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCode.SelectedValueChanged
        If tdbcReportCode.SelectedValue Is Nothing Then
            txtReportTitle.Text = ""
            txtCustomReportID.Text = ""
            txtReportTypeName.Text = ""
        Else
            txtReportTitle.Text = tdbcReportCode.Columns("ReportTitle").Value.ToString
            txtCustomReportID.Text = tdbcReportCode.Columns("CustomReportID").Value.ToString
            txtReportTypeName.Text = tdbcReportCode.Columns("ReportTypeName").Value.ToString
        End If
    End Sub

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCode.LostFocus
        If tdbcReportCode.FindStringExact(tdbcReportCode.Text) = -1 Then
            tdbcReportCode.Text = ""
            txtReportTitle.Text = ""
            txtCustomReportID.Text = ""
            txtReportTypeName.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPeriodIDFrom"

    Private Sub tdbcPeriodIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDFrom.LostFocus
        If tdbcPeriodIDFrom.FindStringExact(tdbcPeriodIDFrom.Text) = -1 Then tdbcPeriodIDFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDFrom.SelectedValueChanged
        tdbcPeriodIDTo.Text = tdbcPeriodIDFrom.Text
        If bLoad Then LoadTDBGrid()
    End Sub
#End Region

#Region "Events tdbcPeriodIDTo"

    Private Sub tdbcPeriodIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDTo.LostFocus
        If tdbcPeriodIDTo.FindStringExact(tdbcPeriodIDTo.Text) = -1 Then tdbcPeriodIDTo.Text = ""
    End Sub

    Private Sub tdbcPeriodIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDTo.SelectedValueChanged
        If bLoad Then LoadTDBGrid()
    End Sub
#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID()
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID()
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, ReturnValueC1Combo(tdbcTeamID).ToString, gbUnicode)
        tdbcEmpGroupID.SelectedValue = "%"

        '        LoadtdbcEmployeeID()
        '        tdbcEmployeeID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcEmpGroupID"


    Private Sub tdbcEmpGroupID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.SelectedValueChanged
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, ReturnValueC1Combo(tdbcTeamID).ToString, ReturnValueC1Combo(tdbcWorkingStatusID).ToString, gsDivisionID, ReturnValueC1Combo(tdbcEmpGroupID).ToString, gbUnicode)
        tdbcEmployeeID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.SelectedValueChanged
        '        LoadtdbcEmployeeID()
        '        tdbcEmployeeID.SelectedValue = "%"
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, ReturnValueC1Combo(tdbcTeamID).ToString, ReturnValueC1Combo(tdbcWorkingStatusID).ToString, gsDivisionID, ReturnValueC1Combo(tdbcEmpGroupID).ToString, gbUnicode)
        tdbcEmployeeID.SelectedValue = "%"
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcDivisionID.AutoCompletion = False
        tdbcBlockID.AutoCompletion = False
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
        tdbcWorkingStatusID.AutoCompletion = False
        tdbcEmployeeID.AutoCompletion = False
        tdbcGroupProductID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus, _
                tdbcBlockID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus, tdbcWorkingStatusID.LostFocus, _
                tdbcEmployeeID.LostFocus, tdbcGroupProductID.LostFocus, tdbcEmpGroupID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, _
                tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, _
                tdbcEmployeeID.Close, tdbcGroupProductID.Close, tdbcEmpGroupID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, _
                tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, _
                tdbcEmployeeID.Validated, tdbcGroupProductID.Validated, tdbcEmpGroupID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003
		
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        Dim sPSalaryVoucherID As String = GetPSalaryVoucherID()

        If txtCustomReportID.Text = "" Then
            sReportName = tdbcReportCode.Columns("ReportID").Text
            sPathReport = gsApplicationSetup & "\XReports\" & sReportName & ".rpt"
        Else
            sReportName = txtCustomReportID.Text
            sPathReport = gsApplicationSetup & "\Xcustom\" & sReportName & ".rpt"
        End If
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, txtCustomReportID.Text) & sReportName & ".rpt"
        sReportCaption = rL3("Bao_cao_phieu_luong_san_pham") & " - " & sReportName
        sSQL = SQLStoreD45P4030(sPSalaryVoucherID)
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With

        sSQLFind = ""
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportCode.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateExamineDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateFromDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateToDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcReportCode.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Mau_chuan"))
            tdbcReportCode.Focus()
            Return False
        End If

        If optPeriod.Checked Then
            If tdbcPeriodIDFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ky"))
                tdbcPeriodIDFrom.Focus()
                Return False
            End If
            If tdbcPeriodIDTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ky"))
                tdbcPeriodIDTo.Focus()
                Return False
            End If
        End If

        If optDate.Checked Then
            If c1dateFromDate.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay"))
                c1dateFromDate.Focus()
                Return False
            End If
            If c1dateToDate.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay"))
                c1dateToDate.Focus()
                Return False
            End If
            If CDate(SQLDateShow(c1dateFromDate.Text)) > CDate(SQLDateShow(c1dateToDate.Text)) Then
                D99C0008.MsgL3(rL3("Ngay_khong_hop_le"))
                c1dateToDate.Focus()
                Return False
            End If
        End If

        '-----------------------------------------------------------
        'Ktra xem co chon dong nao tren luoi chua?
        Dim bChoose As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bChoose = True
                Exit For
            End If
        Next
        If bChoose = False Then
            D99C0008.MsgNotYetChoose(rL3("du_lieu_tren_luoi")) 'dữ liệu trên lưới
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_IsUsed
            tdbg.Bookmark = 0
            Return False
        End If

        Return True
    End Function

    Private Sub optPeriodMode0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPeriod.Click, optDate.Click
        'Kỳ
        If optPeriod.Checked Then
            UnReadOnlyControl(tdbcPeriodIDFrom, True)
            UnReadOnlyControl(tdbcPeriodIDTo, True)
            ReadOnlyControl(c1dateFromDate)
            ReadOnlyControl(c1dateToDate)
        Else 'Ngày
            ReadOnlyControl(tdbcPeriodIDFrom)
            ReadOnlyControl(tdbcPeriodIDTo)
            UnReadOnlyControl(c1dateFromDate, True)
            UnReadOnlyControl(c1dateToDate, True)
        End If
        If bLoad Then LoadTDBGrid()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""

        If _flag Then 'Chon truc tiep tu Bao ca
            sSQL = "SELECT cast(0 as bit) as IsUsed, D45.PSalaryVoucherNo, D45.PSalaryVoucherID, D45.VoucherDate, D45.Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
            sSQL &= "FROM D45T2010 D45 WITH(NOLOCK) " & vbCrLf
            sSQL &= "WHERE D45.DivisionID = " & SQLString(tdbcDivisionID.SelectedValue)

            If optPeriod.Checked Then
                sSQL &= " And (D45.TranMonth + D45.TranYear *100) BETWEEN " & (Number(tdbcPeriodIDFrom.Columns("TranMonth").Text) + Number(tdbcPeriodIDFrom.Columns("TranYear").Text) * 100) _
                & " And " & (Number(tdbcPeriodIDTo.Columns("TranMonth").Text) + Number(tdbcPeriodIDTo.Columns("TranYear").Text) * 100)
            Else
                sSQL &= "And D45.VoucherDate Between " & SQLDateSave(c1dateFromDate.Text) & " And " & SQLDateSave(c1dateToDate.Text)
            End If
        Else
            sSQL = "SELECT CASE WHEN D42.PSalaryVoucherID IS NOT NULL THEN cast(1 as bit) ELSE cast(0 as bit) END IsUsed, " & vbCrLf
            sSQL &= "D45.PSalaryVoucherNo, D45.PSalaryVoucherID, D45.VoucherDate, D45.Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
            sSQL &= "FROM D45T2010 D45  WITH(NOLOCK) LEFT JOIN D45T2010 D42  WITH(NOLOCK) ON D45.PSalaryVoucherID = D42.PSalaryVoucherID" & vbCrLf
            sSQL &= "AND D42.PSalaryVoucherID = " & SQLString(_pSalaryVoucherID) & vbCrLf
            sSQL &= "WHERE D45.DivisionID = " & SQLString(tdbcDivisionID.SelectedValue)
            sSQL &= " And (D45.TranMonth + D45.TranYear *100) BETWEEN " & (Number(tdbcPeriodIDFrom.Columns("TranMonth").Text) + Number(tdbcPeriodIDFrom.Columns("TranYear").Text) * 100) _
                 & " And " & (Number(tdbcPeriodIDTo.Columns("TranMonth").Text) + Number(tdbcPeriodIDTo.Columns("TranYear").Text) * 100)
        End If
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Function GetPSalaryVoucherID() As String
        Dim sSQL As String
        sSQL = "'"

        If tdbg.RowCount <= 0 Then GetPSalaryVoucherID = "NULL" : Exit Function
        tdbg.UpdateData()

        Dim i As Integer

        For i = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                If sSQL = "'" Then
                    sSQL &= "'" & SQLString(tdbg(i, COL_PSalaryVoucherID)) & "'"
                Else
                    sSQL &= " , '" & SQLString(tdbg(i, COL_PSalaryVoucherID)) & "'"
                End If
            End If
        Next i

        If sSQL = "'" Then
            sSQL = ""
        Else
            sSQL &= "'"
        End If

        GetPSalaryVoucherID = sSQL
    End Function


#Region "tdbg"

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If _flag = False OrElse tdbg.RowCount <= 0 Then Exit Sub

        Select Case e.ColIndex
            Case COL_IsUsed
                CheckedAll()
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_IsUsed Then HotKeyEnterGrid(tdbg, COL_IsUsed, e)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If tdbg.RowCount <= 0 Then
                Return
            End If
            Select Case tdbg.Col
                Case COL_IsUsed
                    CheckedAll()
            End Select
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_IsUsed)
    End Sub
#End Region

    Private Sub CheckedAll()
        bHeadClick = Not bHeadClick
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_IsUsed) = bHeadClick
        Next
    End Sub

    Private Sub c1dateFromDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateFromDate.ValueChanged
        If bLoad Then LoadTDBGrid()
    End Sub

    Private Sub c1dateToDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateToDate.ValueChanged
        If bLoad Then LoadTDBGrid()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        sSQL = "Select * From D45V1234 Where FormID ='D45F2012' And Language = " & SQLString(gsLanguage)
        ShowFindDialog(Finder, sSQL, gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause.ToString = "" Then Exit Sub
    '    sSQLFind = ResultWhereClause.ToString
    '    Dim sender As New Object
    '    Dim e As New System.EventArgs
    '    btnPrint_Click(sender, e)
    'End Sub

    Private Function SQLStoreD45P4030(ByVal sStringPSalaryVoucherID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P4030 "
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'PreparedDate, datetime, NOT NULL
        sSQL &= SQLString(CbVal(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcReportCode.Text) & COMMA 'ReportCode, varchar[20], NOT NULL

        If optIsDetail0.Checked Then
            sSQL &= SQLNumber(0) & COMMA 'IsDetail, tinyint, NOT NULL
        Else
            sSQL &= SQLNumber(1) & COMMA 'IsDetail, tinyint, NOT NULL
        End If

        sSQL &= "N" & SQLString(txtReportTitle.Text) & COMMA 'ReportTitle, varchar[100], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= sStringPSalaryVoucherID & COMMA 'StringPSalaryVoucherID, varchar[8000], NOT NULL
        If _flag Then
            sSQL &= "N" & SQLString(sSQLFind) & COMMA   'WhereClause, varchar[8000], NOT NULL
        Else
            sSQL &= "N" & SQLString(_sFilter) & COMMA  'WhereClause, varchar[8000], NOT NULL
        End If
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(CbVal(tdbcGroupProductID)) & COMMA 'GroupProductID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcEmpGroupID)) 'EmpGroupID, varchar[50], NOT NULL
        Return sSQL
    End Function

End Class