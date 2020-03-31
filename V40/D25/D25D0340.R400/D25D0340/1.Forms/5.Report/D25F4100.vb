Imports System
Public Class D25F4100
    Dim oFilterCheck As Lemon3.Controls.FilterCheckCombo

    Private _formIDPermission As String = "D25F4100"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Dim dtBlockID, dtTeamID, dtDepartmentID, dtPeriodID As New DataTable

    Private Sub D25F4050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If

        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tdbcDivisionID.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tdbcCusReportID.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcBlockID.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad4 Or e.KeyCode = Keys.D4) Then
            If tdbcPeriodFrom.Enabled = True Then
                tdbcPeriodFrom.Focus()
            Else
                c1dateFrom.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub D25F4050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        '*********************
        oFilterCheck = New Lemon3.Controls.FilterCheckCombo
        oFilterCheck.UseFilterCheckCombo(tdbcCandidateID)
        '*********************
        LoadLanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadDefault()
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Bao_cao_ket_qua_phong_van_tong_hop") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'BÀo cÀo kÕt qu¶ phàng vÊn tång híp
        '================================================================ 
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển
        lblCusReportID.Text = rL3("Mau_chuan") 'Mẫu chuẩn
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        lblCandidateID.Text = rL3("Ung_vien") 'Ứng viên
        lblDivisionID1.Text = "1. " & rL3("Don_vi") 'Đơn vị
        lblStandardReport.Text = "2. " & rL3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "3. " & rL3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbltime.Text = "4. " & rL3("Thoi_gian") 'Thời gian
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnPrint.Text = rL3("_In") '&In
        '================================================================ 
        optDate.Text = rL3("Ngay_lap") 'Ngày lập
        optPeriod.Text = rL3("Ky") 'Kỳ
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rL3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rL3("Ky") 'Kỳ
        tdbcRecPositionID.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcCusReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp
        tdbcCandidateID.Columns("CandidateID").Caption = rL3("Ma") 'Mã
        tdbcCandidateID.Columns("CandidateName").Caption = rL3("Ten") 'Tên
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCusReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtCusReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcDivisionID
        LoadCboDivisionIDReportD09(tdbcDivisionID, "D09", gbUnicode)

        'Load tdbcCusReportID
        LoadtdbcCustomizeReport(tdbcCusReportID, "25", Me.Name, txtCusReportName, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868("%", Me.Name, 0)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868("%", Me.Name, 0)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868("%", Me.Name, 0)

        'Load tdbcRecPositionID
        sSQL = "-- Combo Vị tri ung tuyen" & vbCrLf
        sSQL &= "SELECT		0 as DisplayOrder,'%' AS RecPositionID, " & AllName & " AS RecPositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder,DutyID As RecPositionID, DutyNameU AS RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        'Load tdbcCandidateID
        sSQL = "-- Combo Ung vien" & vbCrLf
        sSQL &= "SELECT		0 as DisplayOrder, '%' AS CandidateID, " & AllName & " AS CandidateName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder, CandidateID, CandidateNameU AS CandidateName" & vbCrLf
        sSQL &= "FROM		D25T1041" & vbCrLf
        sSQL &= "WHERE		DISABLED = 0   AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, CandidateID" & vbCrLf
        LoadDataSource(tdbcCandidateID, sSQL, gbUnicode)

        'Load tdbcPeriod
        dtPeriodID = LoadTablePeriodReport("D09")
    End Sub

    Private Sub LoadDefault()
        tdbcDivisionID.SelectedValue = gsDivisionID
        tdbcBlockID.SelectedValue = "%"
        tdbcDepartmentID.SelectedValue = "%"
        tdbcTeamID.SelectedValue = "%"
        tdbcRecPositionID.SelectedValue = "%"
        tdbcCandidateID.SelectedValue = "%"
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
    End Sub

    Private Sub optDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDate.Click
        If optPeriod.Checked Then
            tdbcPeriodFrom.Enabled = True
            tdbcPeriodTo.Enabled = True
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
        Else
            tdbcPeriodFrom.Enabled = False
            tdbcPeriodTo.Enabled = False
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
        End If
    End Sub

    Private Sub optPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPeriod.Click
        If optPeriod.Checked Then
            tdbcPeriodFrom.Enabled = True
            tdbcPeriodTo.Enabled = True
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
        Else
            tdbcPeriodFrom.Enabled = False
            tdbcPeriodTo.Enabled = False
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
        End If
    End Sub

#Region "Combo Events"

#Region "Events tdbcDivisionID with txtDivisionName"
    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            txtDivisionName.Text = ""
            tdbcBlockID.SelectedValue = "%"
            tdbcDepartmentID.SelectedValue = "%"
            tdbcTeamID.SelectedValue = "%"
        Else
            txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
            tdbcBlockID.SelectedValue = "%"

            LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, dtPeriodID, CbVal(tdbcDivisionID))
            tdbcPeriodFrom.SelectedValue = tdbcPeriodFrom.Columns("Period").Text
            tdbcPeriodTo.SelectedValue = tdbcPeriodTo.Columns("Period").Text
        End If
    End Sub
    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.SelectedValue = ""
        End If
    End Sub
#End Region

#Region "Events tdbcBlockID"
    Private Sub tdbcBlockIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = ""
    End Sub
    Private Sub tdbcBlockIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, CbVal(tdbcBlockID), CbVal(tdbcDivisionID), gbUnicode)
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcDepartmentID"
    Private Sub tdbcDepartmentIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub
    Private Sub tdbcDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, CbVal(tdbcBlockID), CbVal(tdbcDepartmentID), CbVal(tdbcDivisionID), gbUnicode)
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamID"
    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionID"
    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCusReportID with txtCusReportName"
    Private Sub tdbcCusReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.SelectedValueChanged
        If tdbcCusReportID.SelectedValue Is Nothing Then
            txtCusReportName.Text = ""
            lblCustomFileExt.Text = "rpt"
        Else
            txtCusReportName.Text = tdbcCusReportID.Columns(1).Value.ToString
            lblCustomFileExt.Text = tdbcCusReportID.Columns("FileExt").Value.ToString 'ID 86443 07/06/2016
        End If
    End Sub

#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Function AllowPrint() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcCusReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Mau_chuan"))
            tdbcCusReportID.Focus()
            Return False
        End If
        If txtCusReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Tieu_de"))
            txtCusReportName.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If

        If optPeriod.Checked Then
            If CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) = False Then Return False
        End If
        If optDate.Checked Then
            If CheckValidDateFromTo(c1dateFrom, c1dateTo) = False Then Return False
        End If

        Return True
    End Function

    Dim report As D99C2003
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()		
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Print(Me, _formIDPermission)
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub
    Private Sub printReport(ByVal sReportPath As String, ByVal sReportName As String, ByVal sSQL As String) 'ID 86443 07/06/2016
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sSubReportName As String = "D91R0000"
        Dim sSQLSub As String = ""
        Dim sReportCaption As String = ""

        sReportCaption = rL3("Bao_cao_ket_qua_phong_van_tong_hop") & " - " & sReportName
        sSQLSub = "SELECT * FROM D91V0016 WHERE DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        UnicodeSubReport(sSubReportName, sSQLSub, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
    End Sub
    Private Sub Print(ByVal form As Form, Optional ByVal sReportTypeID As String = "D25F4100", Optional ByVal sModuleID As String = "25") 'ID 86443 07/06/2016
        Dim sReportName As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""

         sReportName = tdbcCusReportID.Text

        Dim dtReport As DataTable = ReturnTableFilter(D99D0541.ReturnTableReportID(sReportTypeID, sModuleID), "ReportID ='" & sReportName & "'")
        Dim file As String = D99D0541.GetReportPathNew(dtReport, sModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)

        If sReportName = "" Then Exit Sub
        form.Cursor = Cursors.WaitCursor
        Dim sSQL As String = SQLStoreD25P4100()
        Select Case file.ToLower
            Case "rpt"
                printReport(sReportPath, sReportName, sSQL) ' Nếu Caption lấy theo TIêu đề thiết lập bên D89.
            Case "xls", "xlsx"
                Dim sPathFile As String = D99D0541.GetObjectFile(sReportTypeID, sReportName, file, sReportPath)
                If sPathFile = "" Then Exit Select
                MyExcel(sSQL, sPathFile, file, True)
                form.Cursor = Cursors.Default
                If btnPrint IsNot Nothing Then btnPrint.Enabled = True
            Case "doc", "docx"
                Dim sPathFile As String = D99D0541.GetObjectFile(sReportTypeID, sReportName, file, sReportPath)
                If sPathFile = "" Then Exit Select
                CreateWordDocumentCopyTemplate(sPathFile, sSQL)
                OpenFile(sPathFile, False)
            Case Else
                D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
        End Select

        form.Cursor = Cursors.Default
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P4100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/12/2016 03:55:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P4100() As String
        Dim sSQL As String = ""
        sSQL &= ("-- In" & vbCrLf)
        sSQL &= "Exec D25P4100 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(optPeriod.Checked, 0, 1)) & COMMA 'PeriodMode, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'DateFrom, int, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'DateTo, int, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[50], NOT NULL
        sSQL &= SQLString(oFilterCheck.GetValueServer(tdbcCandidateID)) & COMMA 'CandidateID, text, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, int, NOT NULL
        sSQL &= SQLString("D25F4100") 'ReportTypeID, varchar[50], NOT NULL
        Return sSQL
    End Function

End Class