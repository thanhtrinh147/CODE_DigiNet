Imports System
Public Class D13F4060
	Dim report As D99C2003


    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtPeriod As DataTable
    Dim dtPITVoucherNo As DataTable

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

    Private _tranMonth As String = ""
    Public Property TranMonth() As String
        Get
            Return _tranMonth
        End Get
        Set(ByVal Value As String)
            _tranMonth = Value
        End Set
    End Property

    Private _tranYear As String = ""
    Public Property TranYear() As String
        Get
            Return _tranYear
        End Get
        Set(ByVal Value As String)
            _tranYear = Value
        End Set
    End Property

    Private _pITVoucherID As String = ""
    Public Property PITVoucherID() As String
        Get
            Return _pITVoucherID
        End Get
        Set(ByVal Value As String)
            _pITVoucherID = Value
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

    Private _deductionLabor As Boolean = True
    Public Property DeductionLabor() As Boolean
        Get
            Return _deductionLabor
        End Get
        Set(ByVal Value As Boolean)
            _deductionLabor = Value
        End Set
    End Property

    Private _nonDeductionLabor As Boolean = False
    Public Property NonDeductionLabor() As Boolean
        Get
            Return _nonDeductionLabor
        End Get
        Set(ByVal Value As Boolean)
            _nonDeductionLabor = Value
        End Set
    End Property

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4060
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 13/08/2009 03:14:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4060() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4060 "
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcPITVoucherNo)) & COMMA 'PITVoucherID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateExamineDate.Text) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(txtReportName.Text) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= "N" & SQLString(_whereClause) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(chkDeductionLabor.Checked) & COMMA 'DeductionLabor, tinyint, NOT NULL
        sSQL &= SQLNumber(chkNonDeductionLabor.Checked) & COMMA 'NonDeductionLabor, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_khai_thue_TNCN_-_D13F4060") & UnicodeCaption(gbUnicode) 'BÀo cÀo khai thuÕ TNCN - D13F4060
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblPITVoucherNo.Text = rl3("Phieu_khai_thue") 'Phiếu khai thuế
        lblteExamineDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblCusReportID.Text = rl3("Dac_thu") 'Đặc thù

        lblDivisionID1.Text = "1. " & rl3("Don_vi") 'Đơn vị
        lblStandardReport.Text = "2. " & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "3. " & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbltime.Text = "4. " & rl3("Thoi_gian") 'Thời gian
        lblTaxDeclare.Text = "5. " & rl3("Khac") 'Khác
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        chkDeductionLabor.Text = rl3("Lao_dong_thuoc_dien_khau_tru_thue") 'Lao động thuộc diện khấu trừ thuế
        chkNonDeductionLabor.Text = rl3("Lao_dong_khong_thuoc_dien_khau_tru_thue") 'Lao động không thuộc diện khấu trừ thuế
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcPeriod.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPITVoucherNo.Columns("PITVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcPITVoucherNo.Columns("Description").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbcCusReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcCusReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp

        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub D13F4060_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D13F4060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        LoadForm()
        SetBackColorObligatory()

        InputDateCustomFormat(c1dateExamineDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadForm()
        tdbcDivisionID.SelectedValue = gsDivisionID
        tdbcBlockID.SelectedValue = _blockID
        tdbcDepartmentID.SelectedValue = _departmentID
        tdbcTeamID.SelectedValue = _teamID
        chkDeductionLabor.Checked = CBool(_deductionLabor)
        chkNonDeductionLabor.Checked = CBool(_nonDeductionLabor)
        tdbcPeriod.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
        If _pITVoucherID = "" Then
            tdbcPITVoucherNo.AutoSelect = True
        Else
            tdbcPITVoucherNo.SelectedValue = _pITVoucherID
        End If

        c1dateExamineDate.Text = SQLDateShow(Now.Date)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionIDReportD09(tdbcDivisionID, "D09", gbUnicode)

        dtBlockID = ReturnTableBlockID(, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcPeriod
        dtPeriod = LoadTablePeriodReport("D09")

        sSQL = "Select T1.PITVoucherID, T1.PITVoucherNo, T1.Description" & UnicodeJoin(gbUnicode) & " as Description, T1.TranMonth, T1.TranYear, DivisionID "
        sSQL &= "From D13T2070 T1  WITH (NOLOCK) " 'Where T1.DivisionID = " & SQLString(tdbcDivisionID.Text)
        dtPITVoucherNo = ReturnDataTable(sSQL)

        'Load tdbcReportID
        LoadtdbcStandardReport(tdbcReportID, "13", Me.Name, txtReportName, gbUnicode)

        'Load tdbcCusReportID
        LoadtdbcCustomizeReport(tdbcCusReportID, "13", Me.Name, txtCusReportName, gbUnicode)
    End Sub

    Private Sub LoadtdbcBlockID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcBlockID, dtBlockID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbcBlockID, ReturnTableFilter(dtBlockID, "DivisionID = '%' Or DivisionID = " & SQLString(ID)), gbUnicode)
        End If
        LoadtdbcDepartmentID("-1", "-1")
        tdbcBlockID.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcDepartmentID(ByVal sDiv As String, ByVal sBlockID As String)
        'Dim sSQL As String = ""

        If sDiv = "%" And sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, dtDepartmentID.Copy, gbUnicode)
        ElseIf sDiv = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID = '%' Or BlockID = " & SQLString(sBlockID)), gbUnicode)
        ElseIf sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID = '%' Or DivisionID = " & SQLString(sDiv)), gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "(BlockID = '%' Or BlockID = " & SQLString(sBlockID) & ")" & " And (DivisionID = '%' Or DivisionID = " & SQLString(sDiv) & ")"), gbUnicode)
        End If
        LoadtdbcTeamID("-1", "-1", "-1")
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcTeamID(ByVal sDiv As String, ByVal sBlockID As String, ByVal sDepartmentID As String)
        'Dim sSQL As String = ""

        If sDiv = "%" And sBlockID = "%" And sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, dtTeamID.Copy, gbUnicode)
        ElseIf sDiv = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " (BlockID = '%' or BlockID=" & SQLString(sBlockID) & ") And (DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID) & ")"), gbUnicode)
        ElseIf sBlockID = "%" And sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID = '%' Or DivisionID = " & SQLString(ComboValue(tdbcDivisionID))), gbUnicode)
        ElseIf sBlockID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "(DivisionID = '%' Or DivisionID = " & SQLString(ComboValue(tdbcDivisionID)) & ")" & " And (DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID) & ")"), gbUnicode)
        ElseIf sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "(DivisionID = '%' Or DivisionID = " & SQLString(ComboValue(tdbcDivisionID)) & ")" & " And (BlockID = '%' or BlockID=" & SQLString(sBlockID) & ")"), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "(DivisionID = '%' Or DivisionID = " & SQLString(ComboValue(tdbcDivisionID)) & ")" & " And (BlockID = '%' or BlockID=" & SQLString(sBlockID) & ") And (DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID) & ")"), gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcPeriod(ByVal ID As String)
        LoadCboPeriodReport(tdbcPeriod, dtPeriod, gsDivisionID)
    End Sub

    Private Sub LoadtdbcPITVoucherNo()
        Dim dt As DataTable = ReturnTableFilter(dtPITVoucherNo, "TranMonth = " & SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & " And TranYear = " & SQLNumber(tdbcPeriod.Columns("TranYear").Text) & IIf(ComboValue(tdbcDivisionID) <> "%", " And DivisionID = " & SQLString(ComboValue(tdbcDivisionID)), "").ToString, True)
        LoadDataSource(tdbcPITVoucherNo, dt, gbUnicode)
    End Sub

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadtdbcBlockID("-1")
        Else
            LoadtdbcPeriod(ComboValue(tdbcDivisionID))
            tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
            LoadtdbcBlockID(ComboValue(tdbcDivisionID))
            tdbcBlockID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcBlockID "

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID("-1", "-1")
        Else
            LoadtdbcDepartmentID(ComboValue(tdbcDivisionID), ComboValue(tdbcBlockID))
            tdbcDepartmentID.SelectedIndex = 0
        End If
    End Sub

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcDepartmentID "

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1", "-1", "-1")
        Else
            LoadtdbcTeamID(ComboValue(tdbcDivisionID), ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID))
            tdbcTeamID.SelectedIndex = 0
        End If
    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcTeamID "

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

    Private Sub tdbcPeriod_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriod.SelectedValueChanged
        LoadtdbcPITVoucherNo()
        'If tdbcPeriod.SelectedValue Is Nothing Then
        '    tdbcPITVoucherNo.Text = ""
        'Else
        '    'Dim sWhere As String = " And T1.TranMonth = " & SQLString(tdbcPeriod.Columns("TranMonth").Text) & " And T1.TranYear = " & SQLString(tdbcPeriod.Columns("TranYear").Text)
        '    LoadtdbcPITVoucherNo()
        'End If
    End Sub
#End Region

#Region "Events tdbcPITVoucherNo "

    Private Sub tdbcPITVoucherNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITVoucherNo.LostFocus
        If tdbcPITVoucherNo.FindStringExact(tdbcPITVoucherNo.Text) = -1 Then
            tdbcPITVoucherNo.Text = ""
        End If
    End Sub
#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDivisionID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcPITVoucherNo.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcPITVoucherNo.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcPITVoucherNo.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcPITVoucherNo.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcReportID.Text.Trim = "" And tdbcCusReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Mau_chuan"))
            tdbcReportID.Focus()
            Return False
        End If

        If txtReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Mau_chuan"))
            txtReportName.Focus()
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
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = rL3("Bao_cao_khai_thue_TNCN_W")
        Dim sPathReport As String = ""

        Dim sSQLSub As String = ""


        If tdbcCusReportID.Text = "" Then
            sReportName = tdbcReportID.Text
            sReportCaption = sReportCaption & " - " & sReportName
            sPathReport = gsApplicationSetup & "\XReports\" & sReportName & ".rpt"
        Else
            sReportName = tdbcCusReportID.Text
            sReportCaption = sReportCaption & " - " & sReportName
            sPathReport = gsApplicationSetup & "\XCustom\" & sReportName & ".rpt"
        End If
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, tdbcCusReportID.Text) & sReportName & ".rpt"


        ' Update 7/8/2012 incident 41191 - đổi SubReport VNI
        sSQLSub = "-- Đổ nguồn cho subreport vni" & vbCrLf
        sSQLSub &= "SELECT 	CompanyName  as  Company, CompanyAddress as  Address, "
        sSQLSub &= " CompanyPhone  as  Telephone, CompanyFax  as  Fax, BankAccountName as BankAccountName, BankAccountNo,  VATCode"
        sSQLSub &= " FROM D91V0016"
        sSQLSub &= " WHERE   	DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        'sSQLSub = "Select * From D09V0009"

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
        sSQL = SQLStoreD13P4060()

        If tdbcCusReportID.Text = "" OrElse tdbcCusReportID.Columns("FileExt").Text = "rpt" Then
            PrintData(sSQL)
            Exit Sub
        End If
        'Mẫu báo cáo khác

        Dim sReportTypeID As String = Me.Name
        Dim sReportName As String = tdbcCusReportID.Columns("ReportID").Text
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
#Region "Events tdbcCusReportID with txtCusReportName"

    Private Sub tdbcCusReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.SelectedValueChanged
        If tdbcCusReportID.SelectedValue Is Nothing Then
            txtCusReportName.Text = ""
        Else
            txtCusReportName.Text = tdbcCusReportID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcCusReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.LostFocus
        If tdbcCusReportID.FindStringExact(tdbcCusReportID.Text) = -1 Then
            tdbcCusReportID.Text = ""
        End If
    End Sub

#End Region


#End Region

End Class