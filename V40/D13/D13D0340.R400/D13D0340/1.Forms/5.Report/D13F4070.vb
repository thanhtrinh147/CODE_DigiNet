Imports System
Public Class D13F4070
	Dim report As D99C2003

    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtEmployeeID As DataTable
    Dim dtPITYear As DataTable

    Private _blockID As String = "%"
    Public Property BlockID() As String
        Get
            Return _blockID
        End Get
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _departmentID As String = "%"
    Public Property DepartmentID() As String
        Get
            Return _departmentID
        End Get
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = "%"
    Public Property TeamID() As String
        Get
            Return _teamID
        End Get
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _whereClause As String = ""
    Public Property WhereClause() As String
        Get
            Return _whereClause
        End Get
        Set(ByVal Value As String)
            _whereClause = Value
        End Set
    End Property

    Private _pITBalanceVoucherID As String = ""
    Public Property PITBalanceVoucherID() As String
        Get
            Return _pITBalanceVoucherID
        End Get
        Set(ByVal Value As String)
            _pITBalanceVoucherID = Value
        End Set
    End Property

    Private _pITYear As String = ""
    Public WriteOnly Property PITYear() As String
        Set(ByVal Value As String)
            _pITYear = Value
        End Set
    End Property

    Private _strEmployeeID As String = ""
    Public WriteOnly Property StrEmployeeID () As String 
        Set(ByVal Value As String )
            _strEmployeeID = Value
        End Set
    End Property

    Private _strEmployeeName As String = ""
    Public WriteOnly Property StrEmployeeName() As String 
        Set(ByVal Value As String )
            _strEmployeeName = Value
        End Set
    End Property

    Private _workingStatusID As String = ""
    Public WriteOnly Property WorkingStatusID() As String 
        Set(ByVal Value As String )
            _workingStatusID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String 
        Set(ByVal Value As String )
            _employeeID = Value
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
        Loadlanguage()
        LoadTDBCombo()
        LoadDefaultValue()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID, txtStrEmployeeID.MaxLength)
        SetBackColorObligatory()
        
InputDateCustomFormat(c1dateExamineDate)

    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub LoadDefaultValue()
        tdbcDivisionID.SelectedValue = gsDivisionID
        tdbcBlockID.SelectedValue = _blockID
        tdbcDepartmentID.SelectedValue = _departmentID
        tdbcTeamID.SelectedValue = _teamID
        tdbcWorkingStatusID.SelectedValue = IIf(_workingStatusID = "", "%", _workingStatusID).ToString
        tdbcEmployeeID.SelectedValue = IIf(_employeeID = "", "%", _employeeID).ToString

        txtStrEmployeeID.Text = _strEmployeeID
        txtStrEmployeeName.Text = _strEmployeeName

        c1dateExamineDate.Text = SQLDateShow(Now.Date)
        If _pITYear <> "" Then
            tdbcPITYear.Text = _pITYear
        Else
            tdbcPITYear.SelectedIndex = 0
        End If
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPITYear.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_quyet_toan_thue_TNCN_-_D13F4070") & UnicodeCaption(gbUnicode) 'BÀo cÀo quyÕt toÀn thuÕ TNCN - D13F4070
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lbltime.Text = "4. " & rl3("Thoi_gian") 'Thời gian
        lblFilter.Text = "3. " & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lblStandardReport.Text = "2. " & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblDivisionID1.Text = "1. " & rl3("Don_vi") 'Đơn vị
        lblteExamineDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblCustomReportID.Text = rl3("Dac_thu") 'Đặc thù

        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblTranYear.Text = rl3("Nam_quyet_toan") 'Năm quyết toán
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbcCustomReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCustomReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp

        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
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

        'Load tdbcWorkingStatusID
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

        'Load tdbcPITYear
        sSQL = "SELECT  	DISTINCT TranYear, DivisionID, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM 	D09T9999   WITH (NOLOCK) " & vbCrLf
        sSQL &= "UNION  " & vbCrLf
        sSQL &= "SELECT 	DISTINCT TranYear, '%' AS DivisionID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "FROM 	D09T9999   WITH (NOLOCK) " & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, DivisionID, TranYear DESC" & vbCrLf

        dtPITYear = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPITYear, dtPITYear, gbUnicode)

        'Load tdbcReportID
        sSQL = "Select ReportID, " & CStr(IIf(gsLanguage = "84", IIf(gbUnicode, "ReportNameU as ReportName", "ReportName"), IIf(gbUnicode, "ReportName01U as ReportName", "ReportName01 as ReportName"))) & ", ReportType From D91T0100  WITH (NOLOCK) Where ModuleID='13' And Reporttype=" & SQLString(Me.Name) & " Order By ReportID "
        LoadDataSource(tdbcReportID, sSQL, gbUnicode)

        'Load tdbcCustomReportID
        sSQL = "SELECT 		ReportID, "
        sSQL &= IIf(gbUnicode, "TitleU as Title ", "Title ").ToString & ",FileExt " & vbCrLf
        sSQL &= "FROM  		D89T1000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE		ModuleID = '13' " & vbCrLf
        sSQL &= "   AND ReportTypeID = 'D13F4070'" & vbCrLf
        LoadDataSource(tdbcCustomReportID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadtdbcPITYear(ByVal sDivision As String)
        LoadDataSource(tdbcPITYear, ReturnTableFilter(dtPITYear, "DivisionID = " & SQLString(ComboValue(tdbcDivisionID)), True), gbUnicode)
        tdbcPITYear.SelectedIndex = 0
    End Sub

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, "-1", gbUnicode)
        Else
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, ComboValue(tdbcDivisionID), gbUnicode)
            LoadtdbcPITYear(ComboValue(tdbcDivisionID))
        End If
        tdbcBlockID.SelectedIndex = 0
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
        'If tdbcWorkingStatusID.SelectedValue Is Nothing Then Exit Sub

        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), ComboValue(tdbcDivisionID), gbUnicode)
        Else
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmployeeID.SelectedValue = "%"
    End Sub
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
        tdbcEmployeeID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
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

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDivisionID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcEmployeeID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcEmployeeID.Close, tdbcWorkingStatusID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcEmployeeID.KeyUp, tdbcWorkingStatusID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcEmployeeID.Validated, tdbcWorkingStatusID.Validated
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

        If tdbcPITYear.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nam_quyet_toan"))
            tdbcPITYear.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub PrintData(ByVal sSQL As String)
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReName As String
        If tdbcCustomReportID.Text <> "" Then
            sReName = tdbcCustomReportID.Text
        Else
            sReName = tdbcReportID.Text
        End If
        Dim sReportName As String = sReName
        Dim sSubReportName As String = IIf(gbUnicode, "D91R0000", "D09R6000").ToString
        Dim sReportCaption As String = rL3("Bao_cao_quyet_toan_thue_TNCN_W")
        Dim sPathReport As String = ""

        Dim sSQLSub As String = ""

        sReportCaption = sReportCaption & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, tdbcCustomReportID.Text) & sReportName & ".rpt"

        ' Update 7/8/2012 incident 41191 - đổi SubReport VNI
        sSQLSub = "-- Đổ nguồn cho subreport vni" & vbCrLf
        sSQLSub &= "SELECT 	CompanyName  as  Company, CompanyAddress as  Address, "
        sSQLSub &= " CompanyPhone  as  Telephone, CompanyFax  as  Fax, BankAccountName as BankAccountName, BankAccountNo,  VATCode"
        sSQLSub &= " FROM D91V0016"
        sSQLSub &= " WHERE   	DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        '   sSQLSub = IIf(gbUnicode, "Select * from D91V0016 Where DivisionID = " & SQLString(ComboValue(tdbcDivisionID)), "Select * from D09V0009").ToString
        UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub

        If Not AllowPrint() Then Exit Sub

        Dim sSQL As String = ""
       
        sSQL = SQLStoreD13P4070()
        If tdbcCustomReportID.Text = "" OrElse tdbcCustomReportID.Columns("FileExt").Text = "rpt" Then
            PrintData(sSQL)
            Exit Sub
        End If
        'Mẫu báo cáo khác

        Dim sReportTypeID As String = Me.Name
        Dim sReportName As String = tdbcCustomReportID.Columns("ReportID").Text
        Dim sReportPath As String = ""
        Dim sReportTitle As String = ""
        Dim sCustomReport As String = ""
        Dim dtReport As DataTable
        dtReport = ReturnTableFilter(ReturnTableReportID(sReportTypeID, "13"), "ReportID ='" & sReportName & "'")
        Dim file As String = GetReportPathNew(dtReport, "13", sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        If file = "" Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        PrintOfficeType(Me.Name, sReportName, sReportPath, file, sSQL)
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
        btnPrint.Focus()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4070
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 31/08/2009 10:47:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4070() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4070 "
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'PITBalanceVoucherID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateExamineDate.Text) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(txtReportName.Text) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= "N" & SQLString(_whereClause) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, int, NOT NULL
        sSQL &= SQLNumber(tdbcPITYear.Text) & COMMA 'PITYear, int, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= "N" & SQLString(txtStrEmployeeName.Text) & COMMA 'StrEmployeeName, nvarchar, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeID)) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class