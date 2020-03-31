Imports System
Public Class D13F4050
	Dim report As D99C2003

    Dim dtEmpGroupID As DataTable
    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtEmployeeID As DataTable
    Dim dtPITYear As DataTable
    Dim dtBalancaVoucherNo As DataTable
    Dim sFormID As String = ""

    Dim oFilterCheckG4 As Lemon3.Controls.FilterCheckComboG4

    Private _divisionID As String = ""
    Public Property DivisionID() As String
        Get
            Return _divisionID
        End Get
        Set(ByVal Value As String)
            _divisionID = Value
        End Set
    End Property

    Private _blockID As String = ""
    Public Property BlockID() As String
        Get
            Return _blockID
        End Get
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public Property DepartmentID() As String
        Get
            Return _departmentID
        End Get
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public Property TeamID() As String
        Get
            Return _teamID
        End Get
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _empGroupID As String
    Public Property EmpGroupID() As String
        Get
            Return _empGroupID
        End Get
        Set(ByVal Value As String)
            _empGroupID = Value
        End Set
    End Property

    Private _balanceVoucherID As String = ""
    Public Property BalanceVoucherID() As String
        Get
            Return _balanceVoucherID
        End Get
        Set(ByVal Value As String)
            _balanceVoucherID = Value
        End Set
    End Property

    Private _whereClause As String = ""
    Public WriteOnly Property WhereClause() As String
        Set(ByVal Value As String)
            _whereClause = Value
        End Set
    End Property

    Private _strEmployeeID As String = ""
    Public WriteOnly Property StrEmployeeID() As String
        Set(ByVal Value As String)
            _strEmployeeID = Value
        End Set
    End Property

    Private _strEmployeeName As String = ""
    Public WriteOnly Property StrEmployeeName() As String
        Set(ByVal Value As String)
            _strEmployeeName = Value
        End Set
    End Property

    Private _workingStatusID As String = ""
    Public WriteOnly Property WorkingStatusID() As String
        Set(ByVal Value As String)
            _workingStatusID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _callFormID As String = ""
    Public WriteOnly Property CallFormID() As String
        Set(ByVal Value As String)
            _callFormID = Value
        End Set
    End Property

    Private Sub D13F4070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub _Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        If _callFormID = "D13F4090" Then
            sFormID = "D13F4090"
            ' chkIsDDateFrom.Visible = True '  update 9/9/2013 id 56751 - luôn hiện
        Else
            sFormID = "D13F4050"
        End If

        oFilterCheckG4 = New Lemon3.Controls.FilterCheckComboG4
        oFilterCheckG4.UseFilterCheckCombo(tdbcEmployeeID)

        Loadlanguage()
        LoadTDBCombo()
        LoadDefaultValue()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID, txtStrEmployeeID.MaxLength)
        SetBackColorObligatory()
        InputDateCustomFormat(c1dateDDateBegin, c1dateDExamineDateEnd, c1dateDDateEnd, c1dateDExamineDateBegin)
        chkEmpStopWork_CheckedChanged(Nothing, Nothing)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefaultValue()
        tdbcDivisionID.SelectedValue = gsDivisionID
        tdbcBlockID.SelectedValue = IIf(_blockID = "", "%", _blockID).ToString
        tdbcDepartmentID.SelectedValue = IIf(_departmentID = "", "%", _departmentID).ToString
        tdbcTeamID.SelectedValue = IIf(_teamID = "", "%", _teamID).ToString
        tdbcEmpGroupID.SelectedValue = IIf(_empGroupID = "", "%", _empGroupID).ToString
        tdbcWorkingStatusID.SelectedValue = IIf(_workingStatusID = "", "%", _workingStatusID).ToString

        '  tdbcEmployeeID.SelectedValue = IIf(_employeeID = "", "%", _employeeID).ToString
        oFilterCheckG4.SetValue(tdbcEmployeeID, IIf(_employeeID = "", "%", _employeeID).ToString)

        txtStrEmployeeID.Text = _strEmployeeID
        txtStrEmployeeName.Text = _strEmployeeName

        'c1dateExamineDate.Text = SQLDateShow(Now.Date)
        c1dateDExamineDateBegin.Value = Now.Date
        c1dateDExamineDateEnd.Value = Now.Date
        c1dateDDateBegin.Value = Now.Date
        c1dateDDateEnd.Value = Now.Date

        ReadOnlyControl(c1dateDDateBegin)
        ReadOnlyControl(c1dateDDateEnd)


        '*********  ReadOnly Combo khối
        Dim dt As New DataTable
        Dim sSQL As String = ""
        sSQL = "-- kiem tra su dung khoi hay khong" & vbCrLf
        sSQL &= "Select IsUseBlock From D09T0000 WITH (NOLOCK) "
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("IsUseBlock").ToString <> "1" Then
                ReadOnlyControl(tdbcBlockID)
            End If
            dt = Nothing
        End If

        If _callFormID <> "D13F4050" Then
            'Update 13/06/2012 theo Bích Thuận 
            btnFilter.Visible = False
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        If sFormID = "D13F4090" Then
            Me.Text = rl3("Bao_cao_giam_tru_gia_canh") & " - " & sFormID & UnicodeCaption(gbUnicode) 'BÀo cÀo hä s¥ l§¥ng - D13F4050
        Else
            Me.Text = rl3("Bao_cao_ho_so_luong_-_D13F4050") & UnicodeCaption(gbUnicode) 'BÀo cÀo hä s¥ l§¥ng - D13F4050
        End If

        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDivisionID1.Text = "1. " & rl3("Don_vi") 'Đơn vị
        lblReportMode.Text = "2. " & rl3("Phuong_thuc_in") ' Phương thức in
        lblStandardReport.Text = "3. " & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "4. " & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbltime.Text = "5. " & rl3("Thoi_gian") 'Thời gian
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblCustomReportID.Text = rl3("Dac_thu") 'Đặc thù

        lblEmpGroupID.Text = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ho_va_ten") 'Họ và tên
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        btnFilter.Text = rl3("_Loc")
        '================================================================ 
        ' update 9/9/2013 id 56751
        optIsDDate0.Text = rl3("Ngay_lap") 'Ngày lập
        optIsDDate1.Text = rl3("Hieu_luc_giam_tru") 'Hiệu lực giảm trừ
        optReportMode0.Text = rl3("Chi_tiet")
        optReportMode1.Text = rl3("Tong_hop")
        '================================================================ 
        chkIsDDateFrom.Text = rl3("Chi_xet_ngay_hieu_luc_giam_tru_(tu)")  ' update 26/6/2013 id 57651
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcCustomReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rl3("Ma") 'Mã
        tdbcEmpGroupID.Columns("EmpgroupName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblProjectID.Text = rL3("Cong_trinh") 'Dự án
        '================================================================ 
        tdbcProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbcProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        chkEmpStopWork.Text = rL3("Nhan_vien_da_nghi_viec") 'NV đã nghỉ việc

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionIDReportD09(tdbcDivisionID, "D09", gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID(False, , gbUnicode)

        'Load tdbcEmployeeID
        dtEmployeeID = ReturnTableEmployeeID(False, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(False, , gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(False, , gbUnicode)

        'Load tdbcDepartmentID
        dtEmpGroupID = ReturnTableEmpGroupID(True, gbUnicode)


        'Load tdbcWorkingStatusID
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

        Using proj As Lemon3.Data.LoadData.LoadDataG4 = New Lemon3.Data.LoadData.LoadDataG4
            proj.LoadProjectByG4(tdbcProjectID, Me.Name)
            tdbcProjectID.SelectedIndex = 0
        End Using

        ' 12/12/2013 id 
        LoadTDBCReportID(sFormID)
        LoadTDBCCustomReportID(sFormID)
    End Sub

    Private Sub LoadTDBCReportID(ByVal sReportTypeID As String)
        Dim sSQL As String = ""
        sSQL = "Select ReportID, " & CStr(IIf(gsLanguage = "84", IIf(gbUnicode, "ReportNameU as ReportName", "ReportName"), IIf(gbUnicode, "ReportName01U as ReportName", "ReportName01 as ReportName"))) & ", ReportType From D91T0100  WITH (NOLOCK) "
        sSQL &= " Where ModuleID='13' "
        sSQL &= " And Reporttype=" & SQLString(sReportTypeID)
        sSQL &= " Order By ReportID "
        LoadDataSource(tdbcReportID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCCustomReportID(ByVal sReportTypeID As String)
        Dim sSQL As String = ""
        sSQL = "SELECT 		ReportTypeID,FileExt,ReportID, "
        sSQL &= IIf(gbUnicode, "TitleU as Title ", "Title ").ToString & vbCrLf
        sSQL &= " FROM  		D89T1000 WITH (NOLOCK) " & vbCrLf
        sSQL &= " WHERE		ModuleID = '13' " & vbCrLf
        sSQL &= " AND ReportTypeID = " & SQLString(sReportTypeID)

        LoadDataSource(tdbcCustomReportID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, "-1", gbUnicode)
        Else
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, ComboValue(tdbcDivisionID), gbUnicode)
            tdbcBlockID.SelectedIndex = 0
        End If
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ComboValue(tdbcBlockID), ComboValue(tdbcDivisionID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcProjectID"

    Private Sub tdbcProjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.LostFocus
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then tdbcProjectID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcDivisionID), gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        ''If tdbcWorkingStatusID.SelectedValue Is Nothing Then Exit Sub
        'If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
        '    LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), ComboValue(tdbcDivisionID), gbUnicode)
        'Else
        '    LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
        'End If
        'tdbcEmployeeID.SelectedValue = "%"

        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, ReturnValueC1Combo(tdbcBlockID).ToString, ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), gbUnicode)
        Else
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmpGroupID.SelectedValue = "%"

    End Sub

#Region "Events tdbcEmpGroupID"

    Private Sub tdbcEmpGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.LostFocus
        If tdbcEmpGroupID.FindStringExact(tdbcEmpGroupID.Text) = -1 Then tdbcEmpGroupID.Text = ""
    End Sub

    Private Sub tdbcEmpGroupID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.SelectedValueChanged
        ''If tdbcWorkingStatusID.SelectedValue Is Nothing Then Exit Sub
        If Not tdbcEmpGroupID.SelectedValue Is Nothing AndAlso Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), ComboValue(tdbcDivisionID), ComboValue(tdbcEmpGroupID), gbUnicode)
        Else
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", "-1", "-1", gbUnicode)
        End If
        'tdbcEmployeeID.SelectedValue = "%"
        oFilterCheckG4.SetValue(tdbcEmployeeID, "%")
    End Sub
#End Region

#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then
            tdbcWorkingStatusID.Text = ""
        End If
    End Sub

    Private Sub tdbcWorkingStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.SelectedValueChanged
        If tdbcTeamID.SelectedValue Is Nothing Then Exit Sub
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", "-1", gbUnicode)

            Exit Sub
        End If
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), ComboValue(tdbcDivisionID), gbUnicode)
        'tdbcEmployeeID.SelectedValue = "%"
        oFilterCheckG4.SetValue(tdbcEmployeeID, "%")
    End Sub
#End Region

#Region "Events tdbcEmployeeID"

    'Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
    '    If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    'End Sub
    Private Sub tdbcEmployeeID_Validated(sender As Object, e As EventArgs) Handles tdbcEmployeeID.Validated
        oFilterCheckG4.FilterCheckCombo(tdbcEmployeeID, e)
    End Sub
#End Region

#Region "Events tdbcReportID with txtReportName"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            txtReportName.Text = ""
        Else
            txtReportName.Text = tdbcReportID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcCustomReportID with txtCustomReportName"

    Private Sub tdbcCustomReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.SelectedValueChanged
        If tdbcCustomReportID.SelectedValue Is Nothing Then
            txtCustomReportName.Text = ""
        Else
            txtCustomReportName.Text = tdbcCustomReportID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcCustomReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.LostFocus
        If tdbcCustomReportID.FindStringExact(tdbcCustomReportID.Text) = -1 Then
            tdbcCustomReportID.Text = ""
        End If
    End Sub

#End Region

    Private Sub tdbcXXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown, tdbcTeamID.KeyDown, tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcEmployeeID.KeyDown, tdbcWorkingStatusID.KeyDown
        If gbUnicode Then Exit Sub
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbc.AutoCompletion = False
            Case Else
                tdbc.AutoCompletion = True
        End Select
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDivisionID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcEmployeeID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcTeamID.Close, tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcWorkingStatusID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyUp, tdbcTeamID.KeyUp, tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcEmployeeID.KeyUp, tdbcWorkingStatusID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcTeamID.Validated, tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcWorkingStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcReportID.Text.Trim = "" And tdbcCustomReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Mau_chuan"))
            tdbcReportID.Focus()
            Return False
        End If
        If txtReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Mau_chuan"))
            txtReportName.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcEmpGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhom_nhan_vien"))
            tdbcEmpGroupID.Focus()
            Return False
        End If

        If chkEmpStopWork.Checked AndAlso Not CheckValidDateFromTo(c1dateDateLeftFrom, c1dateDateLeftTo, , , False) Then Return False

        If tdbcWorkingStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Hinh_thuc_lam_viec"))
            tdbcWorkingStatusID.Focus()
            Return False
        End If

        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhan_vien"))
            tdbcEmployeeID.Focus()
            Return False
        End If

        If optIsDDate0.Checked Then
            If Not CheckValidDateFromTo(c1dateDExamineDateBegin, c1dateDExamineDateEnd) Then Return False
        Else
            If Not CheckValidDateFromTo(c1dateDDateBegin, c1dateDDateEnd) Then Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmpGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcWorkingStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowPrint() Then Exit Sub
        If Not AllowNewD99C2003(report, Me) Then Exit Sub

        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        If tdbcCustomReportID.Text = "" OrElse tdbcCustomReportID.Columns("FileExt").Text = "rpt" Then
            '************************************
            Dim conn As New SqlConnection(gsConnectionString)

            Dim sReportName As String = ""
            Dim sSubReportName As String = "D09R6000" '"D91R0000"

            Dim sReportCaption As String = rL3("Bao_cao_ho_so_luong")
            Dim sPathReport As String = ""
            Dim sSQL As String = ""
            Dim sSQLSub As String = ""

            If tdbcCustomReportID.Text <> "" Then
                sReportName = tdbcCustomReportID.Text
            Else
                sReportName = tdbcReportID.Text
            End If
            sReportCaption = sReportCaption & " - " & sReportName
            sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, tdbcCustomReportID.Text) & sReportName & ".rpt"
            sSQL = SQLStoreD13P4050()
            'sSQLSub = IIf(gbUnicode, "Select * from D91V0016 Where DivisionID = " & SQLString(ComboValue(tdbcDivisionID)), SQLStoreD13P4056()).ToString

            ' Update 7/8/2012 incident 41191 - đổi SubReport VNI
            sSQLSub = "-- Đổ nguồn cho subreport vni" & vbCrLf
            sSQLSub &= "SELECT 	CompanyName  as  Company, CompanyAddress as  Address, "
            sSQLSub &= " CompanyPhone  as  Telephone, CompanyFax  as  Fax, BankAccountName as BankAccountName, BankAccountNo,  VATCode"
            sSQLSub &= " FROM D91V0016"
            sSQLSub &= " WHERE   	DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
            '  sSQLSub = "Select * from D91V0016 Where DivisionID = " & SQLString(ComboValue(tdbcDivisionID))

            UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
            'Report này có 2 sub nên cần truyền vào 2 chuỗi sSQLSub khác nhau
            Dim sSQLSub1 As String = SQLStoreD13P4056()
            With report
                .OpenConnection(conn)
                .AddSub(sSQLSub, sSubReportName & ".rpt")
                .AddSub(sSQLSub1, "D13R4056.rpt")
                .AddMain(sSQL)
                .PrintReport(sPathReport, sReportCaption)
            End With
        Else
            'ID 101285 27.07.2017
            PrintOffice()
        End If
   
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

    Private Sub PrintOffice()
        Dim sReportTypeID As String = tdbcCustomReportID.Columns("ReportTypeID").Text
        Dim sReportName As String = tdbcCustomReportID.Columns("ReportID").Text
        Dim sReportPath As String = ""
        Dim sReportTitle As String = ""
        Dim sCustomReport As String = ""
        Dim dtReport As DataTable

        dtReport = ReturnTableFilter(ReturnTableReportID(sReportTypeID, "13"), "ReportID ='" & sReportName & "'")
        Dim file As String = GetReportPathNew(dtReport, "13", sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, SQLStoreD13P4050())

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        sSQL = "Select * From D13V1234 "
        sSQL &= " Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        sSQL &= " ORDER BY No" ' update 22/7/2013 id 53873
        ShowFindDialog(Finder, sSQL, Me, gbUnicode)
        '        If sFind <> "" Then
        '            _whereClause = sFind
        '            btnPrint_Click(Nothing, Nothing)
        '            sFind = ""
        '            _whereClause = ""
        '        End If
    End Sub

    Private Sub optIsDDate0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIsDDate0.CheckedChanged
        ' update 9/9/2013 id 56751
        EnableControlTime()
    End Sub

    ' 12/12/2013 id 61871
    Private Sub optReportMode0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optReportMode0.CheckedChanged
        If sFormID = "" Then Exit Sub '  Chưa chay qua form load

        'Nếu phương thức in là chi tiết @ReportMode = 0 đổ nguồn như hiện tại.
        'Nếu phương thức in là tổng hợp @ReportMode = 1 thì trong câu đổ nguồn cho combo truyền biến ReportTypeID = ‘D13F4090A’

        If optReportMode0.Checked Then
            LoadTDBCReportID(sFormID)
            LoadTDBCCustomReportID(sFormID)
        Else
            LoadTDBCReportID("D13F4090A")
            LoadTDBCCustomReportID("D13F4090A")
        End If

    End Sub

    ' update 9/9/2013 id 56751
    Private Sub EnableControlTime()
        If optIsDDate0.Checked Then ' Ngày lập
            ReadOnlyControl(c1dateDDateBegin, c1dateDDateEnd)
            UnReadOnlyControl(True, c1dateDExamineDateBegin, c1dateDExamineDateEnd)
            chkIsDDateFrom.Enabled = False
            chkIsDDateFrom.Checked = False
        Else 'Hiệu lực giảm trừ
            ReadOnlyControl(c1dateDExamineDateBegin, c1dateDExamineDateEnd)
            UnReadOnlyControl(True, c1dateDDateBegin, c1dateDDateEnd)
            chkIsDDateFrom.Enabled = True
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
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
            'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
            _whereClause = sFind
            btnPrint_Click(Nothing, Nothing)
            sFind = ""
            _whereClause = ""
		End Set
	End Property

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4050
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 13/12/2010 02:44:36
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date: 18/01/2012 11:10:07
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4050 "
        ' update 9/9/2013 id 56751 - Bỏ control c1dateExamineDate, truyền GetDate() 
        sSQL &= SQLDateSave(Date.Now) & COMMA ' sSQL &= SQLDateSave(c1dateExamineDate.Text) & COMMA 'ReportDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(txtReportName.Text) & COMMA 'Title, nvarchar, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(_whereClause) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ShowAll, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtStrEmployeeName.Text) & COMMA 'StrEmployeeName, nvarchar, NOT NULL
        'Update 18/01/2012: Incident 33443
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[50], NOT NULL
        If optIsDDate0.Checked Then
            sSQL &= SQLNumber(0) & COMMA 'IsDDate, tinyint, NOT NULL
            sSQL &= SQLDateSave(c1dateDExamineDateBegin.Value) & COMMA 'DDateBegin, datetime, NOT NULL
            sSQL &= SQLDateSave(c1dateDExamineDateEnd.Value) & COMMA 'DDateEnd, datetime, NOT NULL
        Else ' Sử dụng chung biến với Option Hiệu lực giảm trừ (1= Check, 0: Uncheck)
            sSQL &= SQLNumber(1) & COMMA 'IsDDate, tinyint, NOT NULL
            sSQL &= SQLDateSave(c1dateDDateBegin.Value) & COMMA 'DDateBegin, datetime, NOT NULL
            sSQL &= SQLDateSave(c1dateDDateEnd.Value) & COMMA 'DDateEnd, datetime, NOT NULL
        End If
        sSQL &= SQLString(ComboValue(tdbcEmpGroupID)) & COMMA
        sSQL &= SQLNumber(chkIsDDateFrom.Checked) & COMMA ' update 26/6/2013 id 57651
        sSQL &= SQLNumber(optReportMode1.Checked) & COMMA 'ReportMode, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA 'ProjectID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) & COMMA 'EmpStopWork, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftFrom.Text) & COMMA 'DateLeftFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftTo.Text) 'DateLeftTo, datetime, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4056
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 10/01/2011 09:04:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4056() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4056 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsShowAll, tinyint, NOT NULL
        sSQL &= "N" & SQLString(_whereClause) & COMMA 'WhereClause, nvarchar, NOT NULL
        If optIsDDate0.Checked Then
            sSQL &= SQLNumber(0) & COMMA 'IsDDate, tinyint, NOT NULL
        Else ' Sử dụng chung biến với Option Hiệu lực giảm trừ (1= Check, 0: Uncheck)
            sSQL &= SQLNumber(1) & COMMA 'IsDDate, tinyint, NOT NULL
        End If
        sSQL &= SQLDateSave(c1dateDDateBegin.Text) & COMMA 'DDateBegin, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDDateEnd.Text) & COMMA 'DDateEnd, datetime, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtStrEmployeeName.Text) 'StrEmployeeName, nvarchar, NOT NULL
        Return sSQL
    End Function

    Private Sub chkEmpStopWork_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmpStopWork.CheckedChanged
        ReadOnlyControl(Not chkEmpStopWork.Checked, c1dateDateLeftFrom, c1dateDateLeftTo)
    End Sub


End Class