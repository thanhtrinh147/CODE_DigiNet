Imports System
Public Class D25F4040
	Dim report As D99C2003

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
        Set(ByVal Value As String)
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
        Set(ByVal Value As String)
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

    Private _voucherDateFrom As Object 
    Public WriteOnly Property VoucherDateFrom() As Object 
        Set(ByVal Value As Object )
            _voucherDateFrom = Value
        End Set
    End Property

    Private _voucherDateTo As Object
    Public WriteOnly Property VoucherDateTo() As Object
        Set(ByVal Value As Object)
            _voucherDateTo = Value
        End Set
    End Property

    'Private _voucherDateFrom As String = ""
    'Public Property VoucherDateFrom() As String 
    '    Get
    '        Return _voucherDateFrom
    '    End Get
    '    Set(ByVal Value As String )
    '        _voucherDateFrom = Value
    '    End Set
    'End Property

    'Private _voucherDateTo As String = ""
    'Public Property VoucherDateTo() As String 
    '    Get
    '        Return _voucherDateTo
    '    End Get
    '    Set(ByVal Value As String )
    '        _voucherDateTo = Value
    '    End Set
    'End Property

    Dim dtBlockID, dtTeamID, dtDepartmentID As New DataTable

    Private Sub D25F4040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            c1dateFrom.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub D25F4040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()

        LoadTDBCombo()
        LoadDefaultvalue()
        InputbyUnicode(Me, gbUnicode)

InputDateCustomFormat(c1dateFrom,c1dateTo)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_phi_tuyen_dung_-_D25F4040") & UnicodeCaption(gbUnicode) 'Chi phÛ tuyÓn dóng - D25F4040
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblCusReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblRecCostID.Text = rl3("Loai_chi_phi") 'Loại chi phí
        lblDate.Text = rl3("Ngay_lap") 'Ngày lập
        '================================================================ 
        lblDivisionID1.Text = "1." & Space(1) & rl3("Don_vi") 'Đơn vị
        lblStandardReport.Text = "2." & Space(1) & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblFilter.Text = "3." & Space(1) & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbltime.Text = "4." & Space(1) & rl3("Thoi_gian") 'Thời gian
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        tdbcRecCostID.Columns("RecCostID").Caption = rl3("Ma") 'Mã
        tdbcRecCostID.Columns("RecCostName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcCusReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCusReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
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
    End Sub

    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

        Dim sSQL As String = ""

        'Load tdbcDivisionID
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode)

        'Load tdbcReportID
        sSQL = "SELECT     ReportID, ReportName" & sUnicode & " As ReportName, ReportType" & vbCrLf
        sSQL &= "FROM       D91T0100 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE      ModuleID = '25'" & vbCrLf
        sSQL &= "           AND ReportType = 'D25F4040'" & vbCrLf
        sSQL &= "ORDER BY   ReportID"

        LoadDataSource(tdbcReportID, sSQL, gbUnicode)

        'Load tdbcCusReportID
        sSQL = "SELECT     ReportID, Title" & sUnicode & " As ReportName" & vbCrLf
        sSQL &= "FROM       D89T1000 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      ModuleID = '25' " & vbCrLf
        sSQL &= "           AND ReportTypeID = 'D25F4040'" & vbCrLf
        sSQL &= "           AND ( Isnull(DAGroupID, '')  = '' " & vbCrLf
        sSQL &= "           OR Isnull(DAGroupID, '')  IN (SELECT 	DAGroupID " & vbCrLf
        sSQL &= "                   FROM 	LEMONSYS.DBO.D00V0080 " & vbCrLf
        sSQL &= "                   WHERE 	UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "                           OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "ORDER BY   ReportID"

        LoadDataSource(tdbcCusReportID, sSQL, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID(, , gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)

        'Load tdbcRecCostID
        sSQL = "SELECT     0 as DisplayOrder,'%' AS RecCostID, " & sLanguage & " AS RecCostName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT    1 as DisplayOrder, RecCostID, RecCostName" & sUnicode & " As RecCostName" & vbCrLf
        sSQL &= "FROM       D25T1030  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY   DisplayOrder, RecCostID"
        LoadDataSource(tdbcRecCostID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefaultvalue()
        tdbcDivisionID.SelectedValue = IIf(_divisionID = "", gsDivisionID, _divisionID)
        tdbcBlockID.SelectedValue = IIf(_blockID = "", "%", _blockID)
        tdbcDepartmentID.SelectedValue = IIf(_departmentID = "", "%", _departmentID)
        tdbcTeamID.SelectedValue = IIf(_teamID = "", "%", _teamID)
        tdbcRecPositionID.SelectedValue = IIf(_recPositionID = "", "%", _recPositionID)
        tdbcRecCostID.SelectedIndex = 0

        If _voucherDateFrom Is Nothing Then
            c1dateFrom.Value = Now
        Else
            c1dateFrom.Value = _voucherDateFrom
        End If
        If _voucherDateTo Is Nothing Then
            c1dateTo.Value = Now
        Else
            c1dateTo.Value = _voucherDateTo
        End If
    End Sub

#Region "Combo Events"

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            txtDivisionName.Text = ""
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        Else
            txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, tdbcDivisionID.Text, gbUnicode)
            tdbcBlockID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
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

#Region "Events tdbcRecCostID"

    Private Sub tdbcRecCostID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecCostID.LostFocus
        If tdbcRecCostID.FindStringExact(tdbcRecCostID.Text) = -1 Then tdbcRecCostID.Text = ""
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

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown, tdbcRecCostID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcRecPositionID.Leave, tdbcRecCostID.Leave
    '    'If gbUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If

    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcRecCostID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcRecCostID.Validated
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

        Return True
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003

		'************************************ 'D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        If tdbcCusReportID.Text = "" Then
            sReportName = tdbcReportID.Text
        Else
            sReportName = tdbcCusReportID.Text
        End If

        sReportCaption = rl3("Bao_cao_chi_phi_tuyen_dung") & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCusReportID.Text) & sReportName & ".rpt"

        sSQL = SQLStoreD25P4040()
        sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(CbVal(tdbcDivisionID))
        UnicodeSubReport(sSubReportName, sSQLSub, CbVal(tdbcDivisionID), gbUnicode)

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P4040
    '# Created User: 
    '# Created Date: 14/07/2010 02:39:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P4040() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P4040 "
        sSQL &= SQLString(CbVal(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcRecCostID)) & COMMA 'RecCostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

End Class