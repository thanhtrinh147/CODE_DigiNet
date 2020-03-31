Imports System
Public Class D25F4050


    Private _isMSS As Integer = 1
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Private _divisionID As String = ""
    Public Property DivisionID() As String
        Get
            Return _divisionID
        End Get
        Set(ByVal value As String)
            _divisionID = Value
        End Set
    End Property

    Private _blockID As String = ""
    Public Property BlockID() As String 
        Get
            Return _blockID
        End Get
        Set(ByVal Value As String )
            _blockID = value
        End Set
    End Property

    Private _departmentID As String = ""
    Public Property DepartmentID() As String
        Get
            Return _departmentID
        End Get
        Set(ByVal value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public Property TeamID() As String
        Get
            Return _teamID
        End Get
        Set(ByVal value As String)
            _teamID = Value
        End Set
    End Property

    Private _recPositionID As String = ""
    Public Property RecPositionID() As String 
        Get
            Return _recPositionID
        End Get
        Set(ByVal Value As String )
            _recPositionID = Value
        End Set
    End Property

    Private _RecruitProposalID As String = ""
    Public Property RecruitProposalID() As String
        Get
            Return _RecruitProposalID
        End Get
        Set(ByVal value As String)
            _RecruitProposalID = Value
        End Set
    End Property

    Private _ProposalDate As String = ""
    Public Property ProposalDate() As String
        Get
            Return _ProposalDate
        End Get
        Set(ByVal value As String)
            _ProposalDate = Value
        End Set
    End Property

    Private _formText As String = ""
    Public WriteOnly Property FormText() As String
        Set(ByVal Value As String)
            _formText = Value
            If _formText <> "" Then _formIDPermission = "D25F4060"
        End Set
    End Property

    Private _formIDPermission As String = "D25F4050"
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
            tdbcReportID.Focus()
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
        Loadlanguage()
        SetBackColorObligatory()

        LoadTDBCombo()
        LoadDefaultvalue()
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        If _formText = "" Then _formText = rL3("Bao_cao_de_xuat_tuyen_dung_-_D25F4050")
        Me.Text = _formText & UnicodeCaption(gbUnicode) 'BÀo cÀo ¢Ò xuÊt tuyÓn dóng - D25F4050
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblCusReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        '================================================================ 
        lblDivisionID1.Text = "1." & Space(1) & rl3("Don_vi") 'Đơn vị
        lblStandardReport.Text = "2." & Space(1) & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "3." & Space(1) & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbltime.Text = "4." & Space(1) & rl3("Thoi_gian") 'Thời gian
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        optDate.Text = rl3("Ngay_lap") 'Ngày lập
        optPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcCusReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCusReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rL3("Ten") 'Tên
        tdbcReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcDivisionID
        LoadCboDivisionIDReportD09(tdbcDivisionID, "D09", gbUnicode)

        'Load tdbcReportID
        LoadtdbcStandardReport(tdbcReportID, "25", _formIDPermission, txtReportName, gbUnicode)

        'Load tdbcCusReportID
        LoadtdbcCustomizeReport(tdbcCusReportID, "25", _formIDPermission, txtCusReportName, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868("%", _formIDPermission, _isMSS)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868("%", _formIDPermission, _isMSS)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868("%", _formIDPermission, _isMSS)
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcRecPositionID
        sSQL = "SELECT		0 as DisplayOrder,'%' AS RecPositionID, " & sLanguage & " AS RecPositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder,DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        'Load tdbcPeriod
        dtPeriodID = LoadTablePeriodReport("D09")
    End Sub

    Private Sub LoadDefaultvalue()
        tdbcDivisionID.SelectedValue = IIf(_divisionID = "", gsDivisionID, _divisionID)
        tdbcBlockID.SelectedValue = IIf(_blockID = "", "%", _blockID)
        tdbcDepartmentID.SelectedValue = IIf(_departmentID = "", "%", _departmentID)
        tdbcTeamID.SelectedValue = IIf(_teamID = "", "%", _teamID)
        tdbcRecPositionID.SelectedValue = IIf(_recPositionID = "", "%", _recPositionID)
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
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
            tdbcPeriodFrom.Text = tdbcPeriodFrom.Columns("Period").Text
            tdbcPeriodTo.Text = tdbcPeriodTo.Columns("Period").Text
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

#Region "Events tdbcReportID with txtReportName"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            txtReportName.Text = ""
            lblReportIDFileExt.Text = "rpt"
        Else
            txtReportName.Text = tdbcReportID.Columns("ReportName").Value.ToString
            lblReportIDFileExt.Text = tdbcReportID.Columns("FileExt").Value.ToString 'ID 86443 07/06/2016
        End If
    End Sub
    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
        End If
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
    Private Sub tdbcCusReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.LostFocus
        'If tdbcCusReportID.FindStringExact(tdbcCusReportID.Text) = -1 Then
        '    tdbcCusReportID.Text = ""
        'End If
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
            D99C0008.MsgNotYetChoose(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Mau_chuan"))
            tdbcReportID.Focus()
            Return False
        End If
        If txtReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Tieu_de"))
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

        If optPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If
        End If

        If optDate.Checked Then
            If c1dateFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay"))
                c1dateFrom.Focus()
                Return False
            End If
            If c1dateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay"))
                c1dateTo.Focus()
                Return False
            End If
            If CDate(SQLDateShow(c1dateFrom.Text)) > CDate(SQLDateShow(c1dateTo.Text)) Then
                D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
                c1dateTo.Focus()
                Return False
            End If
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

        'Dim report As New D99C1003'D99C1004
        'Dim conn As New SqlConnection(gsConnectionString)
        'Dim sReportName As String = ""
        'Dim sSubReportName As String = "D91R0000"
        'Dim sReportCaption As String = ""
        'Dim sPathReport As String = ""
        'Dim sSQL As String = ""
        'Dim sSQLSub As String = ""

        'If tdbcCusReportID.Text = "" Then
        '    sReportName = tdbcReportID.Text
        'Else
        '    sReportName = tdbcCusReportID.Text
        'End If
        'sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCusReportID.Text) & sReportName & ".rpt"
        'sReportCaption = rL3("Phieu_de_xuat_tuyen_dung1") & " - " & sReportName
        'sSQL = SQLStoreD25P4050()
        'sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(CbVal(tdbcDivisionID))
        'UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
        'With report
        '    .OpenConnection(conn)
        '    .AddSub(sSQLSub, sSubReportName & ".rpt")
        '    .AddMain(sSQL)
        '    .PrintReport(sPathReport, sReportCaption)
        'End With

        Print(Me, _formIDPermission) 'ID 86443 07/06/2016
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub
    Private Sub printReport(ByVal sReportPath As String, ByVal sReportName As String, ByVal sSQL As String) 'ID 86443 07/06/2016
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sSubReportName As String = "D91R0000"
        Dim sSQLSub As String = ""
        Dim sReportCaption As String = ""

        sReportCaption = rL3("Bao_cao_ke_hoach_dao_tao") & " - " & sReportName
        sSQLSub = "SELECT * FROM D91V0016 WHERE DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        UnicodeSubReport(sSubReportName, sSQLSub, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
    End Sub
    Private Sub Print(ByVal form As Form, Optional ByVal sReportTypeID As String = "D25F4050", Optional ByVal sModuleID As String = "25") 'ID 86443 07/06/2016
        Dim sReportName As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""

        If tdbcCusReportID.Text = "" Then
            sReportName = tdbcReportID.Text
        Else
            sReportName = tdbcCusReportID.Text
        End If

        Dim dtReport As DataTable = ReturnTableFilter(D99D0541.ReturnTableReportID(sReportTypeID, sModuleID), "ReportID ='" & sReportName & "'")
        Dim file As String = D99D0541.GetReportPathNew(dtReport, sModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)

        If sReportName = "" Then Exit Sub
        form.Cursor = Cursors.WaitCursor
        Dim sSQL As String = SQLStoreD25P4050()
        Select Case file.ToLower
            Case "rpt"
                printReport(sReportPath, sReportName, sSQL) ' Nếu Caption lấy theo TIêu đề thiết lập bên D89.
            Case Else
                D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
        End Select
        form.Cursor = Cursors.Default
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function SQLStoreD25P4050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P4050 "
        sSQL &= SQLString(CbVal(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optPeriod.Checked, 0, 1)) & COMMA 'PeriodMode, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        sSQL &= COMMA & SQLString(_formIDPermission)
        Return sSQL
    End Function

End Class