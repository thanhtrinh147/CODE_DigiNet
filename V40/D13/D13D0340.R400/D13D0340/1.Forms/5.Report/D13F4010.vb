
Public Class D13F4010
    Private Const iMaxCol As Integer = 40
    Dim dtMonthYear As DataTable
    Dim dtAbsentVoucherNo As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtEmployeeID As DataTable
    Dim bLoadGrid As Boolean = False

#Region "Const of tdbg"
    Private Const COL_IsUse As Integer = 0           ' Chọn
    Private Const COL_AbsentVoucherID As Integer = 1 ' AbsentVoucherID
    Private Const COL_AbsentVoucherNo As Integer = 2 ' Số phiếu
    Private Const COL_EntryDate As Integer = 3       ' Ngày phiếu
    Private Const COL_Remark As Integer = 4          ' Ghi chú
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F4010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F4010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode)
        SetBackColorObligatory()
        LoadTDBCombo()
        tdbg_LockedColumns()
        InitForm()
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_EntryDate)
InputDateCustomFormat(c1dateExamineDate)

        SetResolutionForm(Me)
        InputbyUnicode(Me, gbUnicode)
        tdbcDivisionID.Font = FontUnicode(gbUnicode)
        tdbcDivisionID.EditorFont = FontUnicode(gbUnicode)
        tdbcReport.Font = FontUnicode(gbUnicode)
        tdbcReport.EditorFont = FontUnicode(gbUnicode)
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Remark}
        Return ArrCOL
    End Function

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        '-------------------------
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '-------------------------

        'Load tdbcReport
        LoadDataSource(tdbcReport, ReturnTableStandardReport("13", "70", gbUnicode))

        'Load EmployeeID
        dtEmployeeID = ReturnTableEmployeeID(, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcMonthYear
        dtMonthYear = LoadTablePeriodReport("D09")

        'Load tdbcDivisionID
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode)

        'Load tdbcCustom
        LoadtdbcCustomizeReport(tdbcCustom, "13", Me.Name, , gbUnicode)
    End Sub

    Private Sub InitForm()
        c1dateExamineDate.Value = Date.Today
        tdbcDivisionID.SelectedValue = gsDivisionID
        bLoadGrid = False
        tdbcMonthYearFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcMonthYearTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        If tdbcMonthYearFrom.Text = "" Then tdbcMonthYearFrom.AutoSelect = True
        If tdbcMonthYearTo.Text = "" Then tdbcMonthYearTo.AutoSelect = True
        bLoadGrid = True
    End Sub

    'Private Sub LoadtdbcDepartmentID(ByVal ID As String)
    '    LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID ='' Or DivisionID = " & SQLString(ID)), gbUnicode)
    'End Sub

    'Private Sub LoadtdbcTeamID(ByVal sDivisionID As String, ByVal sDepartmentID As String)
    '    If sDepartmentID = "%" Then
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DivisionID = '' Or DivisionID= " & SQLString(sDivisionID)), gbUnicode)
    '    Else
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " DivisionID='' Or DivisionID= " & SQLString(sDivisionID) & " And DepartmentID='%' Or DepartmentID = " & SQLString(sDepartmentID)), gbUnicode)
    '    End If
    'End Sub

    'Private Sub LoadtdbcEmployeeID(ByVal sDivisionID As String, ByVal sDepartmentID As String, ByVal sTeamID As String)
    '    Dim dt As DataTable = dtEmployeeID.Copy
    '    Dim sSQL As String = ""

    '    If sDepartmentID = "%" And sTeamID = "%" Then
    '        sSQL = " DivisionID= '' Or DivisionID=" & SQLString(sDivisionID)
    '    ElseIf sDepartmentID = "%" Then
    '        sSQL = "( DivisionID= '' And DepartmentID='%' ) or (DivisionID=" & SQLString(sDivisionID) & " And TeamID = " & SQLString(sTeamID) & ")"
    '    ElseIf sTeamID = "%" Then
    '        sSQL = "( DivisionID= '' And DepartmentID='%') or (DivisionID= " & SQLString(sDivisionID) & " And DepartmentID = " & SQLString(sDepartmentID) & ")"
    '    Else
    '        sSQL = "(DivisionID= '' And DepartmentID='%' And TeamID='%') or (DivisionID= " & SQLString(sDivisionID) & " And  DepartmentID = " & SQLString(sDepartmentID) & " And TeamID = " & SQLString(sTeamID) & ")"
    '    End If
    '    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dt, sSQL), gbUnicode)
    'End Sub

#Region "Events tdbcReport with txtReportName"

    Private Sub tdbcReport_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReport.Close
        If tdbcReport.FindStringExact(tdbcReport.Text) = -1 Then
            tdbcReport.Text = ""
            txtReportName.Text = ""
        End If
    End Sub

    Private Sub tdbcReport_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReport.SelectedValueChanged
        If tdbcReport.SelectedValue Is Nothing Then Exit Sub
        txtReportName.Text = tdbcReport.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcReport.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcReport.Text = ""
    '        txtReportName.Text = ""
    '    End If
    'End Sub
#End Region

#Region "Events tdbcDivisionID with txtDivisionName load tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If Not (tdbcDivisionID.Tag Is Nothing OrElse tdbcDivisionID.Tag.ToString = "") Then
            tdbcDivisionID.Tag = ""
            Exit Sub
        End If
        If tdbcDivisionID.SelectedValue Is Nothing Then
            'LoadtdbcDepartmentID("-1")
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", ComboValue(tdbcDivisionID), gbUnicode)
            bLoadGrid = False
            LoadCboPeriodReport(tdbcMonthYearFrom, tdbcMonthYearTo, dtMonthYear, "-1")
            bLoadGrid = True
            Exit Sub
        End If
        'LoadtdbcDepartmentID(ComboValue(tdbcDivisionID))
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "%", ComboValue(tdbcDivisionID), gbUnicode)

        bLoadGrid = False
        LoadCboPeriodReport(tdbcMonthYearFrom, tdbcMonthYearTo, dtMonthYear, tdbcDivisionID.SelectedValue.ToString)

        'tdbcMonthYearFrom.SelectedValue = tdbcMonthYearFrom.Columns("Period").Text
        'tdbcMonthYearTo.SelectedValue = tdbcMonthYearTo.Columns("Period").Text
        tdbcMonthYearFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcMonthYearTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        If tdbcMonthYearFrom.Text = "" Then tdbcMonthYearFrom.AutoSelect = True
        If tdbcMonthYearTo.Text = "" Then tdbcMonthYearTo.AutoSelect = True

        bLoadGrid = True
        LoadTDBGrid()
        tdbcDepartmentID.AutoSelect = True
    End Sub

#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
            tdbcDepartmentID.Tag = ""
            Exit Sub
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            'LoadtdbcTeamID("-1", "-1")
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
            Exit Sub
        End If
        'LoadtdbcTeamID(ComboValue(tdbcDivisionID), ComboValue(tdbcDepartmentID))
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", ComboValue(tdbcDepartmentID), ComboValue(tdbcDivisionID), gbUnicode)
        tdbcTeamID.AutoSelect = True
    End Sub

#End Region

#Region "Events tdbcTeamID with txtTeamName load tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If Not (tdbcTeamID.Tag Is Nothing OrElse tdbcTeamID.Tag.ToString = "") Then
            tdbcTeamID.Tag = ""
            Exit Sub
        End If
        If tdbcTeamID.SelectedValue Is Nothing Then
            'LoadtdbcEmployeeID("-1", "-1", "-1")
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
            Exit Sub
        End If
        'LoadtdbcEmployeeID(ComboValue(tdbcDivisionID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID))
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "%", ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), "%", gbUnicode)
        tdbcEmployeeID.SelectedIndex = 0
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcMonthYearFrom"

    Private Sub tdbcMonthYearFrom_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearFrom.Close
        If tdbcMonthYearFrom.FindStringExact(tdbcMonthYearFrom.Text) = -1 Then tdbcMonthYearFrom.Text = ""
    End Sub

    'Private Sub tdbcMonthYearFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMonthYearFrom.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcMonthYearFrom.Text = ""
    'End Sub

    Private Sub tdbcMonthYearFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearFrom.SelectedValueChanged
        If Not (tdbcMonthYearFrom.Tag Is Nothing OrElse tdbcMonthYearFrom.Tag.ToString = "") Then
            tdbcMonthYearFrom.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYearFrom.SelectedValue Is Nothing Then
            LoadTDBGrid()
            Exit Sub
        End If
        LoadTDBGrid()
    End Sub
#End Region

#Region "Events tdbcMonthYearTo "

    Private Sub tdbcMonthYearTo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearTo.Close
        If tdbcMonthYearTo.FindStringExact(tdbcMonthYearTo.Text) = -1 Then tdbcMonthYearTo.Text = ""
    End Sub

    Private Sub tdbcMonthYearTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearTo.SelectedValueChanged
        If Not (tdbcMonthYearTo.Tag Is Nothing OrElse tdbcMonthYearTo.Tag.ToString = "") Then
            tdbcMonthYearTo.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYearTo.SelectedValue Is Nothing Then
            LoadTDBGrid()
            Exit Sub
        End If
        LoadTDBGrid()
    End Sub

    'Private Sub tdbcMonthYearTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMonthYearTo.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcMonthYearTo.Text = ""
    'End Sub

#End Region

#Region "Events tdbcCustom with txtCustomName"

    Private Sub tdbcCustom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.Close
        If tdbcCustom.FindStringExact(tdbcCustom.Text) = -1 Then
            tdbcCustom.Text = ""
            txtCustomName.Text = ""
        End If
    End Sub

    Private Sub tdbcCustom_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.SelectedValueChanged
        txtCustomName.Text = tdbcCustom.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcCustom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCustom.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcCustom.Text = ""
    '        txtCustomName.Text = ""
    '    End If
    'End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDivisionID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcEmployeeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcEmployeeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcEmployeeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcEmployeeID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhan_vien"))
            tdbcEmployeeID.Focus()
            Return False
        End If
        If tdbcMonthYearFrom.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tu_ky"))
            tdbcMonthYearFrom.Focus()
            Return False
        End If
        If tdbcMonthYearTo.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Den_ky"))
            tdbcMonthYearTo.Focus()
            Return False
        End If
        If c1dateExamineDate.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_lap"))
            c1dateExamineDate.Focus()
            Return False
        End If
        If tdbcReport.Text = "" And tdbcCustom.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Mau_bao_cao"))
            tdbcReport.Focus()
            Return False
        End If
        If txtReportName.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tieu_de_bao_cao"))
            txtReportName.Focus()
            Return False
        End If
        Dim bChoose As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsUse).ToString = "True" Then
                bChoose = True
                Exit For
            End If
        Next
        If Not bChoose Then
            D99C0008.MsgNoDataInGrid()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUse
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub PrintReport()
        Dim report As New D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sSQLCaption As String = ""
        Dim dtCaption As DataTable
        Dim i As Integer
        Dim iCol As Integer
        Dim sReportCaption As String = rl3("Bang_cham_cong")

        Dim sReportName As String = ""
        Dim sPathReport As String = ""
        Dim sSubReportName As String = ""
        Dim sSQLSub As String = ""

        If tdbcCustom.Text = "" Then
            sReportName = tdbcReport.Text
            sReportCaption &= " - " & tdbcReport.Text
        Else
            sReportName = tdbcCustom.Text
            sReportCaption &= " - " & tdbcCustom.Text
        End If

        If gbUnicode = False Then
            sSubReportName = "D09R6000"

            If tdbcCustom.Text = "" Then
                sPathReport = gsApplicationSetup & "\XReports\" & sReportName & ".rpt"
            Else
                sPathReport = gsApplicationSetup & "\XCustom\" & sReportName & ".rpt"
            End If
            ' Update 7/8/2012 incident 41191 - đổi SubReport VNI
            sSQLSub = "-- Đổ nguồn cho subreport vni" & vbCrLf
            sSQLSub &= "SELECT 	CompanyName  as  Company, CompanyAddress as  Address, "
            sSQLSub &= " CompanyPhone  as  Telephone, CompanyFax  as  Fax, BankAccountName as BankAccountName, BankAccountNo,  VATCode"
            sSQLSub &= " FROM D91V0016"
            sSQLSub &= " WHERE   	DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
            ' sSQLSub = "Select * From D09V0009"
        Else
            sSubReportName = "D91R0000"
            sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, tdbcCustom.Text) & sReportName & ".rpt"
            sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(ComboValue(tdbcDivisionID))
        End If

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddParameter("BANGCHAMCONGTHANGNHANVIEN", txtReportName.Text)
            If tdbcMonthYearFrom.Text <> tdbcMonthYearTo.Text Then
                report.AddParameter("MONTHYEAR", rl3("Tu_") & (tdbcMonthYearFrom.Columns("TranMonth").Text) & "/" & (tdbcMonthYearFrom.Columns("TranYear").Text) & " - " & (tdbcMonthYearTo.Columns(2).Text) & "/" & (tdbcMonthYearTo.Columns(3).Text))
            Else
                report.AddParameter("MONTHYEAR", rl3("ThangV") & (tdbcMonthYearFrom.Columns("TranMonth").Text) & " /" & (tdbcMonthYearFrom.Columns("TranYear").Text))
            End If
            .AddParameter("STT", rl3("So_TTV"))
            sSQLCaption &= SQLCaption()
            dtCaption = ReturnDataTable(sSQLCaption)
            If dtCaption.Rows.Count = 0 Then Exit Sub
            For i = 0 To dtCaption.Rows.Count - 1
                If i < iMaxCol Then
                    .AddParameter("Par" & i, dtCaption.Rows(i).Item("AbsentTypeDateName"), ReportDataType.lmReportString)
                End If
            Next
            If i < iMaxCol Then
                For iCol = i To iMaxCol - 1
                    report.AddParameter("Par" & iCol, "")
                Next iCol
            End If
            Dim sSQL As String = SQLStoreD13P7001()
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowPrint() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        PrintReport()
        Me.Cursor = Cursors.Default
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P7002
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 12/03/2007 11:32:02
    '# Modified User: THANHHUYEN
    '# Modified Date: 05/02/2010
    '# Description: Chỉnh sửa giao diện theo chuẩn
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P7001() As String
        Dim sSQL As String = ""
        Dim sAbsentVoucherID As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsUse).ToString = "True" Then
                sAbsentVoucherID += SQLString(tdbg(i, COL_AbsentVoucherID).ToString) & "','"
            End If
        Next
        If sAbsentVoucherID <> "" Then
            sAbsentVoucherID = sAbsentVoucherID.Remove(sAbsentVoucherID.Length - 3, 3)
        End If
        sSQL &= "Exec D13P7001 "
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.SelectedValue) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.SelectedValue) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranMonth").Value) & COMMA 'TranMonthFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranMonth").Value) & COMMA 'TranMonthTo, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranYear").Value) & COMMA 'TranYearFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranYear").Value) & COMMA 'TranYearTo, int, NOT NULL
        sSQL &= SQLString("") & COMMA
        sSQL &= SQLString("") & COMMA
        sSQL &= SQLString(tdbcEmployeeID.SelectedValue) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= sAbsentVoucherID & COMMA 'StringAbsentVoucherID, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLCaption() As String
        Dim sSQL As String = ""
        sSQL &= "Select  Top 40 AbsentTypeDateID, AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " As AbsentTypeDateName, Disabled, Orders, Unit, UnitID, Lookup, IsDailySheet, " & vbCrLf
        sSQL &= "IsClassification,ClassificationID, IsValue, IsTimeSheet From D13T0118  WITH (NOLOCK) Where Disabled=0 Order by Orders"
        Return sSQL
    End Function

    Private Function SQLLoadReport() As String
        Dim sSQL As String = ""
        sSQL &= "Select * From D13V7001 Order By DepartmentID, TeamID, DutyID "
        Return sSQL
    End Function

    Private Sub SetBackColorObligatory()
        c1dateExamineDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthYearFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthYearTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReport.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_dieu_chinh_thu_nhap_-_D13F4010") & UnicodeCaption(gbUnicode) 'BÀo cÀo ¢iÒu chÙnh thu nhËp - D13F4010
        '================================================================ 
        lblMonthYearFrom.Text = rl3("Ky") 'Kỳ
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblteExamineDate.Text = rl3("Ngay_xet") 'Ngày xét
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblReportID2.Text = rl3("Dac_thu") 'Đặc thù
        lblGrpDivisionID.Text = "1. " & rl3("Don_vi") 'Đơn vị
        lblReport.Text = "2. " & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "3. " & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lblTime.Text = "4. " & rl3("Thoi_gian") 'Thời gian
        lblCorrectIncome.Text = "5. " & rl3("Danh_sach_phieu_dieu_chinh_thu_nhap") 'Danh sách phiếu điều chỉnh thu nhập
        '================================================================ 
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcMonthYearTo.Columns("Period").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbcMonthYearFrom.Columns("Period").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUse").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("AbsentVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("EntryDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("Remark").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    'Append 05/02/1010
    Private Sub LoadTDBGrid()
        If bLoadGrid Then
            Dim sSQl As String = ""
            Dim iMonthYearFrom As Integer = 0
            Dim iMonthYearTo As Integer = 0

            If tdbcMonthYearFrom.SelectedValue Is Nothing Then
                iMonthYearFrom = 0
            Else
                iMonthYearFrom = CInt(Number(tdbcMonthYearFrom.Columns("TempCol").Value))
            End If

            If tdbcMonthYearTo.SelectedValue Is Nothing Then
                iMonthYearTo = 0
            Else
                iMonthYearTo = CInt(Number(tdbcMonthYearTo.Columns("TempCol").Value))
            End If

            sSQl = "SELECT          Cast(0 as bit) as IsUse, AbsentVoucherID, AbsentVoucherNo,EntryDate, Remark, RemarkU" & vbCrLf
            sSQl &= "FROM           D13T0102 T1 WITH (NOLOCK) " & vbCrLf
            sSQl &= "LEFT JOIN      D13T1130 T2  WITH (NOLOCK) ON T1.TransTypeID = T2.TransTypeID" & vbCrLf

            If ComboValue(tdbcDivisionID) = "%" Then
                sSQl &= "WHERE          (TranYear *100 + TranMonth) Between " & SQLNumber(iMonthYearFrom) & " And " & SQLNumber(iMonthYearTo) & vbCrLf
            Else
                sSQl &= "WHERE          DivisionID = " & SQLString(ComboValue(tdbcDivisionID)) & vbCrLf
                sSQl &= "               AND (TranYear *100 + TranMonth) Between " & SQLNumber(iMonthYearFrom) & " And " & SQLNumber(iMonthYearTo) & vbCrLf
            End If

            sSQl &= "			    AND (Isnull(T2.DAGroupID,'') = ''" & vbCrLf
            sSQl &= "               OR  Isnull(T2.DAGroupID,'') IN (Select  DAGroupID " & vbCrLf
            sSQl &= "                                               From    LemonSys.dbo.D00V0080" & vbCrLf
            sSQl &= "                                               Where   UserID = " & SQLString(gsUserID) & ")" & vbCrLf
            sSQl &= "               OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf
            sSQl &= "ORDER BY       EntryDate, AbsentVoucherNo"
            dtAbsentVoucherNo = ReturnDataTable(sSQl)
            LoadDataSource(tdbg, dtAbsentVoucherNo, gbUnicode)
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsUse
                tdbg.AllowSort = False
                Dim bCheck As Boolean = CBool(tdbg(0, COL_IsUse))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsUse) = Not bCheck
                Next i
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Col = COL_IsUse And e.Control And e.KeyCode = Keys.S Then
            Dim bCheck As Boolean = CBool(tdbg(0, COL_IsUse))
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUse) = Not bCheck
            Next i
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AbsentVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EntryDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Remark).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

End Class