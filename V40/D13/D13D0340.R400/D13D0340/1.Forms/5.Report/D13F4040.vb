Imports System
Imports System.Text
Public Class D13F4040
	Dim report As D99C2003

    Private _sQLStoreD13P3602 As String = ""
    Public WriteOnly Property SQLStoreD13P3602() As String
        Set(ByVal Value As String)
            _sQLStoreD13P3602 = Value
        End Set
    End Property

    Private _sQLStoreD29P4000 As String = ""
    Public WriteOnly Property SQLStoreD29P4000() As String
        Set(ByVal Value As String)
            _sQLStoreD29P4000 = Value
        End Set
    End Property

    '    Private _sFind As String = ""
    '    Public Property sFind() As String
    '        Get
    '            Return _sFind
    '        End Get
    '        Set(ByVal value As String)
    '            If _sFind = Value Then
    '                Return
    '            End If
    '            _sFind = Value
    '        End Set
    '    End Property

    Private _salCalMethodID As String = ""
    Public WriteOnly Property SalCalMethodID() As String
        Set(ByVal Value As String)
            _salCalMethodID = Value
        End Set
    End Property

    Private _sSalaryVoucherID As String = ""
    Public Property sSalaryVoucherID() As String
        Get
            Return _sSalaryVoucherID
        End Get
        Set(ByVal value As String)
            If _sSalaryVoucherID = Value Then
                Return
            End If
            _sSalaryVoucherID = Value
        End Set
    End Property

    Private _sPayrollVoucherID As String = ""
    Public Property sPayrollVoucherID() As String
        Get
            Return _sPayrollVoucherID
        End Get
        Set(ByVal value As String)
            If _sPayrollVoucherID = Value Then
                Return
            End If
            _sPayrollVoucherID = Value
        End Set
    End Property

    Private _employeeName As String = ""
    Public WriteOnly Property EmployeeName() As String
        Set(ByVal Value As String)
            _employeeName = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property


    Dim dtDepartment As DataTable
    Dim dtTeam As DataTable
    Dim dtEmployee As DataTable

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_phieu_luong_-_D13F4040") & UnicodeCaption(gbUnicode) 'BÀo cÀo phiÕu l§¥ng - D13F4040
        '================================================================ 
        lblReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblXReport.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeIDFrom.Text = rl3("Nhan_vien") 'Nhân viên
        lblteExamineDate.Text = rl3("Ngay_xet") 'Ngày xét
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        btnFilter.Text = rl3("_Loc") '&Lọc
        '================================================================ 
        grp1.Text = rl3("Thong_so_thiet_lap") 'Thông số thiết lập
        '================================================================ 
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("Title").Caption = rl3("Ten") 'Tên
        tdbcEmployeeIDTo.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeIDTo.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeIDFrom.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeIDFrom.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcTeamIDTo.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamIDTo.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcTeamIDFrom.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamIDFrom.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentIDTo.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentIDTo.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentIDFrom.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentIDFrom.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F4040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        LoadTDBCombo()
        tdbcDepartmentIDFrom.SelectedIndex = 0
        c1dateExamineDate.Value = Now()
        txtXReportName.Text = IIf(gbUnicode = False, "BAÙO CAÙO PHIEÁU LÖÔNG", ConvertVniToUnicode("BAÙO CAÙO PHIEÁU LÖÔNG")).ToString

        If _departmentID <> "" Then tdbcDepartmentIDFrom.SelectedValue = _departmentID
        If _teamID <> "" Then tdbcTeamIDFrom.SelectedValue = _teamID
        If _employeeID <> "" Then
            tdbcEmployeeIDFrom.SelectedValue = _employeeID
        Else
            If _employeeName <> "" Then tdbcEmployeeIDFrom.Text = _employeeName
        End If

        InputbyUnicode(Me, gbUnicode)
InputDateCustomFormat(c1dateExamineDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub LoadTDBCombo()
        ''Bổ sung Field Unicode
        'Dim sUnicode As String = ""
        'Dim sLanguage As String = ""
        'UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""
        dtEmployee = ReturnTableEmployeeID(, , gbUnicode)
        dtTeam = ReturnTableTeamID(, , gbUnicode)
        dtDepartment = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcDepartmentIDFrom
        LoadDataSource(tdbcDepartmentIDFrom, dtDepartment, gbUnicode)
        LoadDataSource(tdbcDepartmentIDTo, dtDepartment.Copy, gbUnicode)

        'Load tdbcReportID
        LoadtdbcCustomizeReport(tdbcReportID, "13", Me.Name, txtReportName, gbUnicode)
    End Sub

#Region "Events tdbcDepartmentIDFrom load tdbcTeamIDFrom"

    Private Sub tdbcDepartmentIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDFrom.LostFocus
        If tdbcDepartmentIDFrom.FindStringExact(tdbcDepartmentIDTo.Text) = -1 Then
            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            tdbcDepartmentIDFrom.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDFrom.SelectedValueChanged
        If Not (tdbcDepartmentIDFrom.Tag Is Nothing OrElse tdbcDepartmentIDFrom.Tag.ToString = "") Then
            tdbcDepartmentIDFrom.Tag = ""
            Exit Sub
        End If

        If tdbcDepartmentIDFrom.SelectedValue Is Nothing Or IsDBNull(tdbcDepartmentIDFrom.SelectedValue) Then
            'LoadtdbcTeamID("-1")
            LoadtdbcTeamID(tdbcTeamIDFrom, dtTeam, "-1", "-1", gbUnicode)
            LoadtdbcTeamID(tdbcTeamIDTo, dtTeam, "-1", "-1", gbUnicode)

            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            Exit Sub
        End If
        tdbcDepartmentIDTo.SelectedValue = tdbcDepartmentIDFrom.SelectedValue.ToString
        'LoadtdbcTeamID(tdbcDepartmentIDFrom.SelectedValue.ToString())
        LoadtdbcTeamID(tdbcTeamIDFrom, dtTeam, "%", tdbcDepartmentIDFrom.SelectedValue.ToString, gbUnicode)
        LoadtdbcTeamID(tdbcTeamIDTo, dtTeam, "%", tdbcDepartmentIDFrom.SelectedValue.ToString, gbUnicode)

        tdbcTeamIDFrom.SelectedValue = "%"
        tdbcTeamIDTo.SelectedValue = "%"
        tdbcEmployeeIDFrom.SelectedValue = "%"
        tdbcEmployeeIDTo.SelectedValue = "%"

        If tdbcDepartmentIDFrom.SelectedValue.ToString = tdbcDepartmentIDTo.SelectedValue.ToString Then ' And tdbcDepartmentIDFrom.SelectedValue.ToString <> "%" And tdbcDepartmentIDTo.SelectedValue.ToString <> "%" Then
            tdbcTeamIDFrom.Enabled = True
            tdbcTeamIDTo.Enabled = True
            tdbcEmployeeIDFrom.Enabled = True
            tdbcEmployeeIDTo.Enabled = True
        Else
            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
        End If
    End Sub


#End Region

#Region "Events tdbcTeamIDFrom load tdbcEmployeeIDFrom"

    Private Sub tdbcTeamIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamIDFrom.LostFocus
        If tdbcTeamIDFrom.FindStringExact(tdbcTeamIDFrom.Text) = -1 Then
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            tdbcTeamIDFrom.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamIDFrom.SelectedValueChanged
        If Not (tdbcTeamIDFrom.Tag Is Nothing OrElse tdbcTeamIDFrom.Tag.ToString = "") Then
            tdbcTeamIDFrom.Tag = ""
            Exit Sub
        End If
        If tdbcTeamIDFrom.SelectedValue Is Nothing Or IsDBNull(tdbcTeamIDFrom.SelectedValue) Then
            'LoadtdbcEmployeeID("-1", "-1")
            LoadtdbcEmployeeID(tdbcEmployeeIDFrom, dtEmployee, "-1", "-1", "-1", "-1", gbUnicode)
            LoadtdbcEmployeeID(tdbcEmployeeIDTo, dtEmployee, "-1", "-1", "-1", "-1", gbUnicode)

            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            Exit Sub
        End If
        tdbcTeamIDTo.SelectedValue = tdbcTeamIDFrom.SelectedValue.ToString
        'LoadtdbcEmployeeID(IIf(IsDBNull(tdbcDepartmentIDFrom.SelectedValue), "", tdbcDepartmentIDFrom.SelectedValue.ToString()).ToString, tdbcTeamIDFrom.SelectedValue.ToString())
        LoadtdbcEmployeeID(tdbcEmployeeIDFrom, dtEmployee, "%", tdbcDepartmentIDFrom.SelectedValue.ToString, tdbcTeamIDFrom.SelectedValue.ToString, "%", gbUnicode)
        LoadtdbcEmployeeID(tdbcEmployeeIDTo, dtEmployee, "%", tdbcDepartmentIDFrom.SelectedValue.ToString, tdbcTeamIDFrom.SelectedValue.ToString, "%", gbUnicode)

        tdbcEmployeeIDFrom.SelectedValue = "%"
        tdbcEmployeeIDTo.SelectedValue = "%"
        If tdbcTeamIDFrom.SelectedValue.ToString = tdbcTeamIDTo.SelectedValue.ToString Then 'And tdbcTeamIDFrom.SelectedValue.ToString <> "%" And tdbcTeamIDTo.SelectedValue.ToString <> "%" Then
            tdbcEmployeeIDFrom.Enabled = True
            tdbcEmployeeIDTo.Enabled = True
        Else
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
        End If
    End Sub


    Private Sub tdbcEmployeeIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeIDFrom.LostFocus
        If tdbcEmployeeIDFrom.FindStringExact(tdbcEmployeeIDFrom.Text) = -1 Then tdbcEmployeeIDFrom.Text = ""
    End Sub

    Private Sub tdbcEmployeeIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeIDFrom.SelectedValueChanged
        If tdbcEmployeeIDFrom.SelectedValue Is Nothing Or IsDBNull(tdbcEmployeeIDFrom.SelectedValue) Then
            Exit Sub
        End If
        tdbcEmployeeIDTo.SelectedValue = tdbcEmployeeIDFrom.SelectedValue.ToString
    End Sub


#End Region

#Region "Events tdbcDepartmentIDTo load tdbcTeamIDTo"

    Private Sub tdbcDepartmentIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDTo.LostFocus
        If tdbcDepartmentIDTo.FindStringExact(tdbcDepartmentIDTo.Text) = -1 Then
            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            tdbcDepartmentIDTo.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDTo.SelectedValueChanged
        If Not (tdbcDepartmentIDTo.Tag Is Nothing OrElse tdbcDepartmentIDTo.Tag.ToString = "") Then
            tdbcDepartmentIDTo.Tag = ""
            Exit Sub
        End If
        If tdbcDepartmentIDTo.SelectedValue Is Nothing Or IsDBNull(tdbcDepartmentIDTo.SelectedValue) Then
            'LoadtdbcTeamID("-1")
            LoadtdbcTeamID(tdbcTeamIDFrom, dtTeam, "-1", "-1", gbUnicode)
            LoadtdbcTeamID(tdbcTeamIDTo, dtTeam, "-1", "-1", gbUnicode)

            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            Exit Sub
        End If
        'LoadtdbcTeamID(tdbcDepartmentIDTo.SelectedValue.ToString())

        LoadtdbcTeamID(tdbcTeamIDFrom, dtTeam, "%", tdbcDepartmentIDTo.SelectedValue.ToString, gbUnicode)
        LoadtdbcTeamID(tdbcTeamIDTo, dtTeam, "%", tdbcDepartmentIDTo.SelectedValue.ToString, gbUnicode)

        tdbcTeamIDFrom.SelectedValue = "%"
        tdbcTeamIDTo.SelectedValue = "%"
        tdbcEmployeeIDFrom.SelectedValue = "%"
        tdbcEmployeeIDTo.SelectedValue = "%"
        If tdbcDepartmentIDFrom.SelectedValue.ToString = tdbcDepartmentIDTo.SelectedValue.ToString Then 'And tdbcDepartmentIDFrom.SelectedValue.ToString <> "%" And tdbcDepartmentIDTo.SelectedValue.ToString <> "%" Then
            tdbcTeamIDFrom.Enabled = True
            tdbcTeamIDTo.Enabled = True
            tdbcEmployeeIDFrom.Enabled = True
            tdbcEmployeeIDTo.Enabled = True
        Else
            tdbcTeamIDFrom.Enabled = False
            tdbcTeamIDTo.Enabled = False
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
        End If
    End Sub

#End Region

#Region "Events tdbcTeamIDTo load tdbcEmployeeIDTo"

    Private Sub tdbcTeamIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamIDTo.LostFocus
        If tdbcTeamIDTo.FindStringExact(tdbcTeamIDTo.Text) = -1 Then
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            tdbcTeamIDTo.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamIDTo.SelectedValueChanged
        If Not (tdbcTeamIDTo.Tag Is Nothing OrElse tdbcTeamIDTo.Tag.ToString = "") Then
            tdbcTeamIDTo.Tag = ""
            Exit Sub
        End If
        If tdbcTeamIDTo.SelectedValue Is Nothing Or IsDBNull(tdbcTeamIDTo.SelectedValue) Then
            'LoadtdbcEmployeeID("-1", "-1")
            LoadtdbcEmployeeID(tdbcEmployeeIDFrom, dtEmployee, "-1", "-1", "-1", "-1", gbUnicode)
            LoadtdbcEmployeeID(tdbcEmployeeIDTo, dtEmployee, "-1", "-1", "-1", "-1", gbUnicode)

            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
            Exit Sub
        End If
        'LoadtdbcEmployeeID(IIf(IsDBNull(tdbcDepartmentIDFrom.SelectedValue), "", tdbcDepartmentIDFrom.SelectedValue.ToString).ToString, tdbcTeamIDFrom.SelectedValue.ToString())
        LoadtdbcEmployeeID(tdbcEmployeeIDFrom, dtEmployee, "%", tdbcDepartmentIDTo.SelectedValue.ToString, tdbcTeamIDTo.SelectedValue.ToString, "%", gbUnicode)
        LoadtdbcEmployeeID(tdbcEmployeeIDTo, dtEmployee, "%", tdbcDepartmentIDTo.SelectedValue.ToString, tdbcTeamIDTo.SelectedValue.ToString, "%", gbUnicode)

        tdbcEmployeeIDFrom.SelectedValue = "%"
        tdbcEmployeeIDTo.SelectedValue = "%"
        If tdbcTeamIDFrom.SelectedValue.ToString = tdbcTeamIDTo.SelectedValue.ToString Then 'And tdbcTeamIDFrom.SelectedValue.ToString <> "%" And tdbcTeamIDTo.SelectedValue.ToString <> "%" Then
            tdbcEmployeeIDFrom.Enabled = True
            tdbcEmployeeIDTo.Enabled = True
        Else
            tdbcEmployeeIDFrom.Enabled = False
            tdbcEmployeeIDTo.Enabled = False
        End If
    End Sub

    Private Sub tdbcEmployeeIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeIDTo.LostFocus
        If tdbcEmployeeIDTo.FindStringExact(tdbcEmployeeIDTo.Text) = -1 Then tdbcEmployeeIDTo.Text = ""
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

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentIDFrom.BeforeOpen, tdbcDepartmentIDTo.BeforeOpen, tdbcTeamIDFrom.BeforeOpen, tdbcTeamIDTo.BeforeOpen, tdbcEmployeeIDFrom.BeforeOpen, tdbcEmployeeIDTo.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDFrom.Close, tdbcDepartmentIDTo.Close, tdbcTeamIDFrom.Close, tdbcTeamIDTo.Close, tdbcEmployeeIDFrom.Close, tdbcEmployeeIDTo.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentIDFrom.KeyUp, tdbcDepartmentIDTo.KeyUp, tdbcTeamIDFrom.KeyUp, tdbcTeamIDTo.KeyUp, tdbcEmployeeIDFrom.KeyUp, tdbcEmployeeIDTo.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentIDFrom.Validated, tdbcDepartmentIDTo.Validated, tdbcTeamIDFrom.Validated, tdbcTeamIDTo.Validated, tdbcEmployeeIDFrom.Validated, tdbcEmployeeIDTo.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintReport()
    End Sub

    Private Sub PrintReport()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        'Dim report As New D99C1003
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)

        Dim sSQL As New StringBuilder("")
        Dim sReportName As String = ""
        Dim sReportCaption As String = rL3("Bao_cao_phieu_luong")
        Dim sSubReportName As String = "D09R6000"
        Dim sSQLSub As String = ""
        Dim sPathReport As String
        Dim dt As DataTable
        Dim sCaption As String

        If tdbcReportID.Text = "" Then
            sReportName = txtXReport.Text
        Else
            sReportName = tdbcReportID.Text
        End If

        sReportCaption = sReportCaption & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, tdbcReportID.Text) & sReportName & ".rpt"

        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)

        With report
            .OpenConnection(conn)
            .AddParameter("MONTHYEAR", rL3("ThangV") & giTranMonth & "/" & giTranYear)

            sSQL.Append(" Select SalCalMethodID, Disabled, CalNo, Caption" & UnicodeJoin(gbUnicode) & " as Caption, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName From D13T2501 Where SalCalMethodID = " & SQLString(_salCalMethodID) & " Order By CalNo")
            dt = ReturnDataTable(sSQL.ToString)
            If dt.Rows.Count = 0 Then Exit Sub

            For i As Integer = 0 To dt.Rows.Count - 1
                sCaption = dt.Rows(i).Item("ShortName").ToString
                If i < 9 Then
                    .AddParameter("Colcaption0" & (i + 1), sCaption)
                Else
                    .AddParameter("Colcaption" & (i + 1), sCaption)
                End If
            Next

            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddSub(_sQLStoreD13P3602, "D13R3602.rpt")
            .AddSub(_sQLStoreD29P4000, "D13R3603.rpt")
            .AddMain(SQLStoreD13P3502)
            .PrintReport(sPathReport, sReportCaption)
        End With
    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    '	Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            btnPrint_Click(Nothing, Nothing)
            sFind = ""
        End Set
    End Property

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D13V1234 "
        sSQL &= "Where FormID = " & SQLString("D13F2042") & "And Language = " & SQLString(gsLanguage)
        ShowFindDialogClient(Finder, sSQL, Me, gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        btnPrint_Click(Nothing, Nothing)
    '        sFind = ""
    '    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3502
    '# Created User: DUCTRONG
    '# Created Date: 14/05/2008 03:58:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3502() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3502 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(sSalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentIDFrom)) & COMMA 'DepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentIDTo)) & COMMA 'DeparmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamIDFrom)) & COMMA 'TeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamIDTo)) & COMMA 'TeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeIDFrom)) & COMMA 'EmployeeIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeIDTo)) & COMMA 'EmployeeIDTo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeID, varchar[100], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'EmployeeName, nvarchar, NOT NULL
        sSQL &= SQLNumber(D13Options.ShowZeroNumber) & COMMA 'ShowzeroNumber, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2040") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function
    
    



End Class
