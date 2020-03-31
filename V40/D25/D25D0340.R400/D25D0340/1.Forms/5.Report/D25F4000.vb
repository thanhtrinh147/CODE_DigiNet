Imports System
Public Class D25F4000
	Dim report As D99C2003
    Dim dt_LoadDepartmentID As DataTable
    Dim dt_LoadTeamID As DataTable
    Dim dt_LoadRecPositionID As DataTable

    Private _isMSS As Integer = 1
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Private _sFind As String = ""
    Public WriteOnly Property sFind() As String
        Set(ByVal Value As String)
            _sFind = Value
        End Set
    End Property

    Private _visibleFilterButton As String = "1"
    Public WriteOnly Property VisibleFilterButton() As String
        Set(ByVal Value As String)
            _visibleFilterButton = Value
        End Set
    End Property

    Private _divisionID As String = ""
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
            'If _divisionID = "" Then _divisionID = gsDivisionID
        End Set
    End Property

    Private Sub D25F4000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tdbcRecDepartmentIDFrom.Focus()
        ElseIf e.Control And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            c1dateExamineDate.Focus()
        End If
    End Sub

    Private Sub D25F4000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetBackColorObligatory()
        LoadInfoGeneral()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        LoadDefault()
        If _visibleFilterButton = "0" Then
            btnFilter.Visible = False
        End If
        EnablegrpEstablishInfo()
        InputDateCustomFormat(c1dateReceivedDateTo, c1dateReceivedDateFrom, c1dateExamineDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_ung_cu_vien_-_D25F4000") & UnicodeCaption(gbUnicode) 'Danh sÀch ÷ng cõ vi£n - D25F4000
        '================================================================ 
        lblRecDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionIDFrom.Text = rl3("Vi_tri") 'Vị trí
        lblReceivedDateFrom.Text = rl3("Ho_so_nop") 'Hồ sơ nộp
        lblteExamineDate.Text = rl3("Ngay_lap") 'Ngày xét

        lblCustomReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        '================================================================ 
        txtReportName.Text = IIf(gbUnicode, rl3("Danh_sach_ung_cu_vienU"), ConvertUnicodeToVni(rl3("Danh_sach_ung_cu_vienU"))).ToString()
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grpEstablishInfo.Text = rl3("Thiet_lap_thong_so") 'Thiết lập thông số
        '================================================================ 
        tdbcRecPositionIDTo.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDTo.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionIDFrom.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDFrom.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamIDTo.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamIDTo.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamIDFrom.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamIDFrom.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcRecDepartmentIDTo.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDTo.Columns("DepartmentName").Caption = rl3("Ten") 'Tên 
        tdbcRecDepartmentIDFrom.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDFrom.Columns("DepartmentName").Caption = rl3("Ten") 'Tên 
        tdbcCustomReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadDefault()
        tdbcRecDepartmentIDFrom.SelectedValue = "%"
        tdbcRecDepartmentIDTo.SelectedValue = "%"
        tdbcRecPositionIDFrom.SelectedValue = "%"
        tdbcRecPositionIDTo.SelectedValue = "%"
        tdbcRecTeamIDFrom.SelectedValue = "%"
        tdbcRecTeamIDTo.SelectedValue = "%"
        c1dateExamineDate.Value = Now.Date

        If _divisionID = "" Then _divisionID = gsDivisionID

        'Lấy ngày đầu tháng và cuối tháng hiện tại
        c1dateReceivedDateFrom.Value = "01/" & Now.Month & "/" & Now.Year
        Dim datenow As Date = DateAdd(DateInterval.Month, 1, Now)
        c1dateReceivedDateTo.Value = DateAdd(DateInterval.Day, -1, DateValue("01/" & datenow.Month & "/" & datenow.Year))

    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcRecDepartmentIDFrom
        dt_LoadDepartmentID = ReturnTableDepartmentID(, , gbUnicode)
        LoadDataSource(tdbcRecDepartmentIDFrom, ReturnTableFilter(dt_LoadDepartmentID, "", True), gbUnicode)
        LoadDataSource(tdbcRecDepartmentIDTo, ReturnTableFilter(dt_LoadDepartmentID, "", True), gbUnicode)

        'Load tdbcRecTeamIDFrom
        dt_LoadTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcRecPositionIDFrom
        dt_LoadRecPositionID = ReturnTableDutyIDRec(, gbUnicode)
        LoadDataSource(tdbcRecPositionIDFrom, ReturnTableFilter(dt_LoadRecPositionID, "", True), gbUnicode)
        LoadDataSource(tdbcRecPositionIDTo, ReturnTableFilter(dt_LoadRecPositionID, "", True), gbUnicode)

        'Load tdbcCustomReportID
        MyLoadTdbcCustomizeReport(tdbcCustomReportID, Me.Name, gbUnicode)
    End Sub

    Private Sub LoadtdbcRecTeamIDFrom(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcRecTeamIDFrom, ReturnTableFilter(dt_LoadTeamID, "", True), gbUnicode)
        Else
            LoadDataSource(tdbcRecTeamIDFrom, ReturnTableFilter(dt_LoadTeamID, "DepartmentID = '%' Or DepartmentID =" & SQLString(ID), True), gbUnicode)
        End If
        tdbcRecTeamIDFrom.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcRecTeamIDTo(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcRecTeamIDTo, ReturnTableFilter(dt_LoadTeamID, "", True), gbUnicode)
        Else
            LoadDataSource(tdbcRecTeamIDTo, ReturnTableFilter(dt_LoadTeamID, "DepartmentID = '%' Or DepartmentID =" & SQLString(ID), True), gbUnicode)
        End If
        tdbcRecTeamIDTo.SelectedValue = "%"
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcRecPositionIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecTeamIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecTeamIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecDepartmentIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecDepartmentIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcRecDepartmentIDFrom load tdbcRecTeamIDFrom"

    Private Sub tdbcRecDepartmentIDFrom_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.Close
        If tdbcRecDepartmentIDFrom.FindStringExact(tdbcRecDepartmentIDFrom.Text) = -1 Then tdbcRecDepartmentIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.SelectedValueChanged
        If Not (tdbcRecDepartmentIDFrom.Tag Is Nothing OrElse tdbcRecDepartmentIDFrom.Tag.ToString = "") Then
            tdbcRecDepartmentIDFrom.Tag = ""
            Exit Sub
        End If
        If tdbcRecDepartmentIDFrom.SelectedValue Is Nothing Then
            LoadtdbcRecTeamIDFrom("-1")
            Exit Sub
        End If
        LoadtdbcRecTeamIDFrom(ReturnValueC1Combo(tdbcRecDepartmentIDFrom))
        tdbcRecTeamIDFrom.Text = "%"
        'tdbcRecTeamIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDFrom_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDFrom.Close
        If tdbcRecTeamIDFrom.FindStringExact(tdbcRecTeamIDFrom.Text) = -1 Then tdbcRecTeamIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecTeamIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecDepartmentIDTo load tdbcRecTeamIDTo"

    Private Sub tdbcRecDepartmentIDTo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.Close
        If tdbcRecDepartmentIDTo.FindStringExact(tdbcRecDepartmentIDTo.Text) = -1 Then tdbcRecDepartmentIDTo.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.SelectedValueChanged
        If Not (tdbcRecDepartmentIDTo.Tag Is Nothing OrElse tdbcRecDepartmentIDTo.Tag.ToString = "") Then
            tdbcRecDepartmentIDTo.Tag = ""
            Exit Sub
        End If
        If tdbcRecDepartmentIDTo.SelectedValue Is Nothing Then
            LoadtdbcRecTeamIDTo("-1")
            Exit Sub
        End If
        LoadtdbcRecTeamIDTo(ReturnValueC1Combo(tdbcRecDepartmentIDTo))
        tdbcRecTeamIDTo.Text = "%"
    End Sub

    Private Sub tdbcRecDepartmentIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentIDTo.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDTo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDTo.Close
        If tdbcRecTeamIDTo.FindStringExact(tdbcRecTeamIDTo.Text) = -1 Then tdbcRecTeamIDTo.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecTeamIDTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionIDTo"

    Private Sub tdbcRecPositionIDTo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDTo.Close
        If tdbcRecPositionIDTo.FindStringExact(tdbcRecPositionIDTo.Text) = -1 Then tdbcRecPositionIDTo.Text = ""
    End Sub

    Private Sub tdbcRecPositionIDTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecPositionIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecPositionIDTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionIDFrom"

    Private Sub tdbcRecPositionIDFrom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.Close
        If tdbcRecPositionIDFrom.FindStringExact(tdbcRecPositionIDFrom.Text) = -1 Then tdbcRecPositionIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecPositionIDFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecPositionIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecPositionIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcCustomReportID with txtCustomReportName"

    Private Sub tdbcCustomReportID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.Close
        If tdbcCustomReportID.FindStringExact(tdbcCustomReportID.Text) = -1 Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

    Private Sub tdbcCustomReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.SelectedValueChanged
        txtCustomReportName.Text = tdbcCustomReportID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcCustomReportID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCustomReportID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1010
    '# Created User: Lê Thị Lành
    '# Created Date: 01/11/2007 11:53:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1010 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(IIf(tdbcCustomReportID.Text <> "", txtCustomReportName.Text, txtReportName.Text)) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentIDFrom.Text) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentIDTo.Text) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeamIDFrom.Text) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeamIDTo.Text) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionIDFrom.Text) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionIDTo.Text) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateFrom.Text) & COMMA 'ReceivedDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateTo.Text) & COMMA 'ReceivedDateTo, datetime, NOT NULL
        sSQL &= "N" & SQLString(_sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= COMMA & SQLString(gsUserID)
        sSQL &= COMMA & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1011
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 28/05/2014 11:02:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1011() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Sub report" & vbCrlf)
        sSQL &= "Exec D25P1011 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(IIf(tdbcCustomReportID.Text <> "", txtCustomReportName.Text, txtReportName.Text)) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentIDFrom.Text) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecDepartmentIDTo.Text) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeamIDFrom.Text) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecTeamIDTo.Text) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionIDFrom.Text) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRecPositionIDTo.Text) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateFrom.Text) & COMMA 'ReceivedDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateReceivedDateTo.Text) & COMMA 'ReceivedDateTo, datetime, NOT NULL
        sSQL &= "N" & SQLString(_sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= COMMA & SQLString(gsUserID)
        sSQL &= COMMA & SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString("%") 'BlockID, varchar[50], NOT NULL
        Return sSQL
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        'If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003

		'************************************ 'D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D91R0000" '"D09R6000"    IncidentID	51312  Sửa theo mail chị ni 23/11/2012
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        If tdbcCustomReportID.Text = "" Then
            sReportName = txtReportID.Text
        Else
            sReportName = tdbcCustomReportID.Text
        End If

        sReportCaption = rL3("DANH_SACH_UNG_CU_VIEN_W") & " - " & sReportName ''"DANH SÀCH ÷NG Cõ VI™N W"
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCustomReportID.Text) & sReportName & ".rpt"

        sSQL = SQLStoreD25P1010()
        sSQLSub = "Select *" & vbCrLf
        sSQLSub &= " FROM D91V0016 " & vbCrLf
        sSQLSub &= " WHERE   DivisionID = " & SQLString(_divisionID)

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddSub(SQLStoreD25P1011(), "D25R1051.rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
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
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString("D25F1050") & "And Language = " & SQLString(gsLanguage)
        ShowFindDialog(Finder, sSQL, Me, gbUnicode)
        'ShowFindDialog(Finder, sSQL, gbUnicode)
        'btnPrint_Click(Nothing, Nothing)
        '_sFind = ""
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    _sFind = ResultWhereClause.ToString()
    'End Sub

    Private Sub c1dateReceivedDateFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateReceivedDateFrom.Validating
        If c1dateReceivedDateFrom.Text = "" Then
            'Lấy ngày đầu tháng và cuối tháng hiện tại
            c1dateReceivedDateFrom.Value = "01/" & Now.Month & "/" & Now.Year
        End If
    End Sub

    Private Sub c1dateReceivedDateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateReceivedDateTo.Validating
        If c1dateReceivedDateTo.Text = "" Then
            Dim datenow As Date = DateAdd(DateInterval.Month, 1, Now)
            c1dateReceivedDateTo.Value = DateAdd(DateInterval.Day, -1, DateValue("01/" & datenow.Month & "/" & datenow.Year))
        End If
    End Sub

    Private Sub EnablegrpEstablishInfo()
        Dim sSQL As String = "SELECT	TOP 1 1 FROM	D09T6666 WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE	UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = 'D25F1500'"
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        If dtTemp.Rows.Count > 0 Then grpEstablishInfo.Enabled = True
    End Sub
End Class