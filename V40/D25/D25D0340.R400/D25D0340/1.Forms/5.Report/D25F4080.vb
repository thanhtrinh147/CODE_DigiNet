Imports System.Windows.Forms
Imports System
Public Class D25F4080
	Dim report As D99C2003

#Region "Const of tdbg - Total of Columns: 25"
    Private Const COL_IsUsed As String = "IsUsed"                   ' Chọn
    Private Const COL_CandidateID As String = "CandidateID"         ' Mã ứng viên
    Private Const COL_CandidateName As String = "CandidateName"     ' Tên ứng viên
    Private Const COL_DepartmentID As String = "DepartmentID"       ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName"   ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                   ' Tổ nhóm
    Private Const COL_TeamName As String = "TeamName"               ' Tên tổ nhóm
    Private Const COL_RecPositionID As String = "RecPositionID"     ' Vị trí
    Private Const COL_RecPositionName As String = "RecPositionName" ' Tên vị trí
    Private Const COL_Sex As String = "Sex"                         ' Giới tính
    Private Const COL_BirthDate As String = "BirthDate"             ' Ngày sinh
    Private Const COL_Email As String = "Email"                     ' Địa chỉ Email
    Private Const COL_ReceivedDate As String = "ReceivedDate"       ' Ngày nhận
    Private Const COL_FileReceiver As String = "FileReceiver"       ' Người nhận HS
    Private Const COL_InStatusName As String = "InStatusName"       ' Kết quả
    Private Const COL_InterviewLevels As String = "InterviewLevels" ' Vòng PV
    Private Const COL_IntDate As String = "IntDate"                 ' Ngày PV
    Private Const COL_IntTime As String = "IntTime"                 ' Giờ PV
    Private Const COL_Interviewer As String = "Interviewer"         ' Người PV
    Private Const COL_Content As String = "Content"                 ' Nội dung
    Private Const COL_Result As String = "Result"                   ' Đánh giá
    Private Const COL_IsSendEmail As String = "IsSendEmail"         ' Đã gởi mail
    Private Const COL_InterviewFileID As String = "InterviewFileID" ' InterviewFileID
    Private Const COL_EmailContent As String = "EmailContent"       ' EmailContent
    Private Const COL_Subject As String = "Subject"                 ' Subject
#End Region


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
            _divisionID = value
        End Set
    End Property

    Private _candidateID As String = ""
    Public Property CandidateID() As String 
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String )
            _candidateID = Value
        End Set
    End Property

    Private _candidateName As String = ""
    Public Property CandidateName() As String 
        Get
            Return _candidateName
        End Get
        Set(ByVal Value As String )
            _candidateName = Value
        End Set
    End Property

    Private _interviewFileID As String = ""
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property

    Private _voucherNo As String
    Public WriteOnly Property  VoucherNo() As String
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _formCall As String = "D25F4080"
    Public WriteOnly Property FormCall() As String
        Set(ByVal Value As String)
            _formCall = Value
        End Set
    End Property

    Private _dateFrom As String = ""
    Public WriteOnly Property DateFrom() As String
        Set(ByVal Value As String)
            _dateFrom = Value
        End Set
    End Property

    Private _dateTo As String = ""
    Public WriteOnly Property DateTo() As String
        Set(ByVal Value As String)
            _dateTo = Value
        End Set
    End Property

    Private _isPendding As Boolean = False
    Public WriteOnly Property IsPendding() As Boolean
        Set(ByVal Value As Boolean)
            _isPendding = Value
        End Set
    End Property

    Private _isComplete As Boolean = False
    Public WriteOnly Property IsComplete() As Boolean
        Set(ByVal Value As Boolean)
            _isComplete = Value
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

    Private _recPositionID As String = ""
    Public WriteOnly Property RecPositionID() As String
        Set(ByVal Value As String)
            _recPositionID = Value
        End Set
    End Property

    Dim dtInterviewFileID As DataTable
    Dim dtTeamID As DataTable

    Dim bLoad As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRight, Panel1, tdbcDepartmentID, tdbcTeamID, tdbcRecPositionName)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkOnlyShowSelected, rtbEmailContent, btnEmailContent, btnGuestInfo)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSendEmail, btnPrint, btnClose)

    End Sub

    Private Sub D25F4080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And Me.ActiveControl.Name <> rtbEmailContent.Name Then
            If (txtCandidateID.Text <> "" And Me.ActiveControl.Name = txtCandidateID.Name) OrElse (Me.ActiveControl.Name = txtCandidateName.Name And txtCandidateName.Text <> "") Then Exit Sub
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(sender, Nothing)
        End If
    End Sub

    Private Sub D25F4080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        LoadLanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        rtbEmailContent.Font = FontUnicode(gbUnicode)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_IntDate, COL_ReceivedDate)
        '********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtCandidateID)
        '********************
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        LoadDefaultvalue()
        If _formCall = "D25F3031" Or _formCall = "D25F3060" Or _formCall = "D25F3040" Or _formCall = "D25F2010" Then
            btnFilter_Click(Nothing, Nothing)
        End If

        'ID 100088 18.09.2017
        If _formCall = "D25F2060" Or _formCall = "D25F3060" Or _formCall = "D25F2010" Then
            ReadOnlyAll(Panel1, tdbcCusReportID, tdbcReportID)
        End If

        bLoad = True
        '*********************
        btnEmailContent.Enabled = ReturnPermission("D25F4081") >= EnumPermission.View
        '*********************
        btnPrint.Enabled = dtGrid IsNot Nothing AndAlso dtGrid.Rows.Count > 0
        btnSendEmail.Enabled = btnPrint.Enabled

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcInterviewFileID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcIntStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionName.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        dtTeamID = ReturnTableTeamID(True, True, gbUnicode)
        'tdbcDepartmentID
        LoadtdbcDepartmentID(tdbcDepartmentID, ReturnTableDepartmentID(True, True, gbUnicode), "%", gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0

        'Load tdbcReportID
        LoadtdbcStandardReport(tdbcReportID, "25", "D25F4080", , gbUnicode) 'id : 74857 20/4/2015
        'tdbcReportID.SelectedValue = ""

        'Load tdbcCusReportID
        'sSQL = "SELECT     ReportID, Title" & UnicodeJoin(gbUnicode) & " as ReportName" & vbCrLf
        'sSQL &= "FROM       D89T1000 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "WHERE      ModuleID = '25' " & vbCrLf
        'sSQL &= "           AND ReportTypeID = 'D25F4080'" & vbCrLf
        'sSQL &= "           AND ( Isnull(DAGroupID, '')  = '' " & vbCrLf
        'sSQL &= "           OR Isnull(DAGroupID, '')  IN (SELECT 	DAGroupID " & vbCrLf
        'sSQL &= "                   FROM 	LEMONSYS.DBO.D00V0080 " & vbCrLf
        'sSQL &= "                   WHERE 	UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        'sSQL &= "                           OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf
        'sSQL &= "ORDER BY   ReportID"
        'LoadDataSource(tdbcCusReportID, sSQL, gbUnicode)
        LoadtdbcCustomizeReport(tdbcCusReportID, "25", "D25F4080")

        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        sSQL = "Select 1 as DisplayOrder,DutyID as RecPositionID, DutyName" & sUnicode & " as RecPositionName" & vbCrLf
        sSQL &= "From D09T0211 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 0 as DisplayOrder,'%' as RecPositionID, " & sLanguage & " as RecPositionName order by DisplayOrder"
        LoadDataSource(tdbcRecPositionName, sSQL, gbUnicode)
        tdbcRecPositionName.SelectedIndex = 0


        'Load tdbcIntStatusID
        sSQL = "SELECT ID AS IntStatusID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "Name84", "Name01").ToString & UnicodeJoin(gbUnicode) & " as IntStatusName FROM D25N5555 ('D25F4080','ResultRecruiment','','','','')"
        LoadDataSource(tdbcIntStatusID, sSQL, gbUnicode)
        tdbcIntStatusID.SelectedIndex = 0

        'Load tdbcDivision
        LoadCboDivisionIDAll(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedValue = "%"
    End Sub


    Private Sub LoadtdbcInterviewFileID()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""

        'Load tdbcInterviewFileID
        sSQL &= "SELECT  0 as DisplayOrder,'%' AS InterviewFileID, '%' AS VoucherNo, " & sLanguage & " AS InterviewFileName, 20 As StatusID" & vbCrLf
        sSQL &= "UNION all" & vbCrLf
        sSQL &= "SELECT  Distinct  1 as DisplayOrder," & vbCrLf
        sSQL &= " InterviewFileID, VoucherNo, InterviewFileName" & sUnicode & " As InterviewFileName, StatusID" & vbCrLf
        sSQL &= "FROM       D25T2010 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE      VoucherDate BETWEEN " & SQLDateSave(c1dateFrom.Text) & " AND " & SQLDateSave(c1dateTo.Text) & vbCrLf
        sSQL &= "ORDER BY   DisplayOrder, InterviewFileID"

        dtInterviewFileID = ReturnDataTable(sSQL)
        FiltertdbcInterviewFileID()
    End Sub

    Private Sub FiltertdbcInterviewFileID()
        Dim dtTmp As DataTable
        Dim sFilter As String = "StatusID = 20"

        If chkIsPedding.Checked Then
            If sFilter = "" Then
                sFilter = "StatusID = 3"
            Else
                sFilter &= " OR StatusID = 3"
            End If
        End If
        If chkIsComplete.Checked Then
            If sFilter = "" Then
                sFilter = "StatusID = 4"
            Else
                sFilter &= " OR StatusID = 4"
            End If
        End If

        dtTmp = ReturnTableFilter(dtInterviewFileID, sFilter, True)

        LoadDataSource(tdbcInterviewFileID, dtTmp, gbUnicode)
        tdbcInterviewFileID.SelectedValue = "%"
    End Sub

    Private Sub chkBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPedding.Click, chkIsComplete.Click
        FiltertdbcInterviewFileID()
    End Sub

    Private Sub LoadDefaultvalue()
        txtCandidateID.Text = _candidateID
        txtCandidateName.Text = _candidateName
        If _dateFrom <> "" Then
            c1dateFrom.Value = _dateFrom
        Else
            c1dateFrom.Value = Now
        End If
        If _dateTo <> "" Then
            c1dateTo.Value = _dateTo
        Else
            c1dateTo.Value = Now
        End If
        LoadtdbcInterviewFileID()
        tdbcInterviewFileID.SelectedValue = IIf(_interviewFileID = "", "%", _interviewFileID)
        chkIsComplete.Checked = _isComplete
        'chkIsPedding.Checked = _isPendding
        chkIsPedding.Checked = True

        If _divisionID <> "" Then
            tdbcDivisionID.SelectedValue = _divisionID
            'MessageBox.Show(_divisionID)
        End If

        If _departmentID <> "" Then
            tdbcDepartmentID.SelectedValue = _departmentID
        End If

        If _teamID <> "" Then
            tdbcTeamID.SelectedValue = _teamID
        End If
        If _recPositionID <> "" Then
            tdbcRecPositionName.SelectedValue = _recPositionID
        End If

    End Sub

    Private Sub c1dateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateFrom.ValueChanged
        LoadtdbcInterviewFileID()
    End Sub

    Private Sub c1dateTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateTo.ValueChanged
        LoadtdbcInterviewFileID()
    End Sub

#Region "Combo Events"

#Region "Events tdbcReportID with txtReportName"
    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
        End If
    End Sub
    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            lblReportIDFileExt.Text = "rpt"
        Else
            lblReportIDFileExt.Text = tdbcReportID.Columns("FileExt").Value.ToString 'ID 90903 22/11/2016
        End If
    End Sub

#End Region

#Region "Events tdbcCusReportID with txtCusReportName"

    Private Sub tdbcCusReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.LostFocus
        If tdbcCusReportID.FindStringExact(tdbcCusReportID.Text) = -1 Then
            tdbcCusReportID.Text = ""
        End If
    End Sub

    Private Sub tdbcCusReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCusReportID.SelectedValueChanged
        If tdbcCusReportID.SelectedValue Is Nothing Then
            lblCustomFileExt.Text = "rpt"
        Else
            lblCustomFileExt.Text = tdbcCusReportID.Columns("FileExt").Value.ToString 'ID 90903 22/11/2016
        End If
    End Sub

#End Region

#Region "Events tdbcInterviewFileID"

    Private Sub tdbcInterviewFileID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.LostFocus
        If tdbcInterviewFileID.FindStringExact(tdbcInterviewFileID.Text) = -1 Then tdbcInterviewFileID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Close, tdbcRecPositionName.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcIntStatusID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewFileID.Validated, tdbcRecPositionName.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcIntStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", CbVal(tdbcDepartmentID), gbUnicode)
        tdbcTeamID.SelectedIndex = 0
    End Sub


    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#Region "Events tdbcIntStatusID"

    Private Sub tdbcIntStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIntStatusID.LostFocus
        If tdbcIntStatusID.FindStringExact(tdbcIntStatusID.Text) = -1 Then tdbcIntStatusID.Text = ""
    End Sub

#End Region
#End Region

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateFrom, c1dateTo) Then Return False
        If tdbcInterviewFileID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose("Lịch PV")
            tdbcInterviewFileID.Focus()
            Return False
        End If
        If tdbcIntStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ket_qua_PV"))
            tdbcIntStatusID.Focus()
            Return False
        End If
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcRecPositionName.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Vi_tri"))
            tdbcRecPositionName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function AllowPrint(ByRef dr() As DataRow, Optional ByVal bSentMail As Boolean = False) As Boolean
        If Not bSentMail Then
            If tdbcReportID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Mau_chuan"))
                tdbcReportID.Focus()
                Return False
            End If
        End If

        tdbg.UpdateData()
        'If dtGrid Is Nothing Then Exit Function
        dr = dtGrid.Select(COL_IsUsed & "=1")
        If dr.Length <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim sSQL As New StringBuilder
        sSQL.AppendLine(SQLDeleteD09T6666().ToString)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If Not bRunSQL Then Exit Sub
        Me.Close()
    End Sub

    Private Sub txtCandidateID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCandidateID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim txtText As TextBox = CType(sender, TextBox)
            If txtText.Text = "" Then Exit Sub
            btnFilter_Click(sender, Nothing)
            txtText.Focus()
            txtText.SelectAll()
        End If
    End Sub

    Private Sub txtCandidateID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCandidateID.Validated
        Dim txtText As TextBox = CType(sender, TextBox)
        If txtText.Text = "" Then Exit Sub
        btnFilter_Click(sender, Nothing)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P4080
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 01/11/2013 08:27:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P4080(ByVal Mode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Do nguon cho luoi ma hinh D25F4080" & vbCrLf)
        sSQL &= "Exec D25P4080 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(txtCandidateID.Text) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtCandidateName.Text) & COMMA 'CandidateName, varchar[150], NOT NULL
        sSQL &= SQLNumber(chkIsPedding.Checked) & COMMA 'IsPending, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsComplete.Checked) & COMMA 'IsComplete, tinyint, NOT NULL
        sSQL &= SQLString(CbVal(tdbcInterviewFileID)) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(CbVal(tdbcRecPositionName)) & COMMA 'RecPositionID, varchar[50], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA  'UserID, varchar[50], NOT NULL
        'If bLoad Then ' Lọc lần 2
        '    sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        'Else
        '    If _formCall = "D25F3060" Or _formCall = "D25F3040" Then ' 3/12/2014 id 71088
        '        sSQL &= SQLString(_formCall) & COMMA 'FormID, varchar[50], NOT NULL
        '    Else
        '        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        '    End If
        'End If
        sSQL &= SQLString(_formCall) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcIntStatusID)) & COMMA 'IntStatusID, varchar[20], NOT NULL
        sSQL &= SQLNumber(Mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcReportID)) & COMMA 'ReportID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcCusReportID)) 'CustomReportID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P4081
    '# Created User: Kim Long
    '# Created Date: 19/09/2017 11:15:04
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P4081() As String
        Dim sSQL As String = ""
        sSQL &= ("-- UPDATE  D25T2011" & vbCrlf)
        sSQL &= "Exec D25P4081 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(_formCall) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function



    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        If _formCall = "D25F3060" Or _formCall = "D25F3040" Or _formCall = "D25F2010" Then
            dtGrid = ReturnDataTable(SQLStoreD25P4080(1))
        Else
            dtGrid = ReturnDataTable(SQLStoreD25P4080(0))
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub


#Region "Events tdbcRecPositionName"

    Private Sub tdbcRecPositionName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionName.LostFocus
        If tdbcRecPositionName.FindStringExact(tdbcRecPositionName.Text) = -1 Then tdbcRecPositionName.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

#End Region

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        chkOnlyShowSelected.Checked = False
        'If sender Is Nothing Then
        '    btnFilter.Focus()
        '    If btnFilter.Focused = False Then Exit Sub
        'End If
        LoadTDBGrid()
        btnPrint.Enabled = dtGrid IsNot Nothing AndAlso dtGrid.Rows.Count > 0
        btnSendEmail.Enabled = btnPrint.Enabled
       
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Lich_phong_van__thu_moi_ung_vien") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'LÜch phàng vÊn / th§ méi ÷ng vi£n
        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblReportID.Text = rL3("Mau_chuan") 'Mẫu chuẩn
        lblCusReportID.Text = rL3("Dac_thu") 'Đặc thù
        lblCandidateID.Text = rL3("Ma_ung_vien") 'Mã ứng viên
        lblCandidateName.Text = rL3("Ten_ung_vien") 'Tên ứng viên
        lblteFrom.Text = rL3("Ngay_lap") 'Ngày lập
        lblInterviewFileID.Text = rL3("Lich_PV") 'Lịch PV
        lblRecPositionName.Text = rL3("Vi_tri") 'Vị trí
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblIntStatusID.Text = rL3("Ket_qua_PV") 'Kết quả PV
        '================================================================ 
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnPrint.Text = rL3("_In") '&In
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        btnGuestInfo.Text = rL3("Thong_tin_ung_vien") 'Thông tin ứng viên
        btnEmailContent.Text = rL3("_Noi_dung_mail") '&Nội dung mail
        btnSendEmail.Text = rL3("Goi_mail") 'Gởi mail
        '================================================================ 
        chkIsComplete.Text = rL3("Dong_U") 'Đóng
        chkIsPedding.Text = rL3("Dang_thuc_hien") 'Đang thực hiện
        chkOnlyShowSelected.Text = rL3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcRecPositionName.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbcRecPositionName.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        tdbcInterviewFileID.Columns("VoucherNo").Caption = rL3("Ma") 'Mã
        tdbcInterviewFileID.Columns("InterviewFileName").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcCusReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCusReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp
        tdbcReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rL3("Ten") 'Tên
        tdbcReportID.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcIntStatusID.Columns("IntStatusID").Caption = rL3("Ma") 'Mã
        tdbcIntStatusID.Columns("IntStatusName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_CandidateID).Caption = rL3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rL3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_RecPositionID).Caption = rL3("Vi_tri") 'Vị trí
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns(COL_Sex).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_BirthDate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_Email).Caption = rL3("_Dia_chi_Email") 'Địa chỉ Email
        tdbg.Columns(COL_ReceivedDate).Caption = rL3("Ngay_nhan") 'Ngày nhận
        tdbg.Columns(COL_FileReceiver).Caption = rL3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns(COL_InterviewLevels).Caption = rL3("Vong_PV") 'Vòng PV
        tdbg.Columns(COL_IntDate).Caption = rL3("Ngay_PV") 'Ngày PV
        tdbg.Columns(COL_IntTime).Caption = rL3("Gio_PV") 'Giờ PV
        tdbg.Columns(COL_Interviewer).Caption = rL3("Nguoi_PV") 'Người PV
        tdbg.Columns(COL_Content).Caption = rL3("Noi_dung") 'Nội dung
        tdbg.Columns(COL_IsSendEmail).Caption = rL3("Da_goi_mail") 'Đã gởi mail
        tdbg.Columns(COL_Result).Caption = rL3("Danh_gia") 'Đánh giá
        tdbg.Columns(COL_InStatusName).Caption = rL3("Ket_qua") 'Kết quả--> Phải làm Resource sau cột Đánh giá vì Resource Tiếng Anh của cột Kết quả là Result nên sẽ bị sai index 
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 01/11/2013 08:31:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Delete cac dong trong bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " And HostID =" & SQLString(My.Computer.Name)
        'If _formCall = "D25F3060" Then ' 3/12/2014 id 71088
        sSQL &= " And FormID =" & SQLString(_formCall)
        'Else
        'sSQL &= " And FormID =" & SQLString(Me.Name)
        'End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 01/11/2013 08:32:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByVal dr() As DataRow) As StringBuilder
        tdbg.UpdateData()
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID ")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            'If _formCall = "D25F3060" Then ' 3/12/2014 id 71088
            sSQL.Append(SQLString(_formCall) & COMMA) 'FormID, varchar[250], NOT NULL
            'Else
            'sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[250], NOT NULL
            'End If
            sSQL.Append(SQLString(dr(i).Item(COL_CandidateID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_InterviewFileID))) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub ReLoadTDBGrid()

        Dim strFind As String = ""
        If chkOnlyShowSelected.Checked Then
            strFind = COL_IsUsed & "=1"
        Else
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString
            If strFind <> "" Then strFind &= " Or " & COL_IsUsed & "=1"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        LoadEmailContent()

        FooterTotalGrid(tdbg, COL_CandidateID)
    End Sub

    Private Sub chkOnlyShowSelected_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOnlyShowSelected.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Dim dr() As DataRow = Nothing
        If Not AllowPrint(dr) Then Exit Sub
        If dr Is Nothing Then Exit Sub

        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        ''Dim report As New D99C1003
        ''************************************ 'D99C1004
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

        'sReportCaption = rL3("Lich_phong_vanW") & " - " & sReportName
        'sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCusReportID.Text) & sReportName & ".rpt"

        'sSQL = SQLDeleteD09T6666() & vbCrLf
        'sSQL &= SQLInsertD09T6666s(dr).ToString
        'sSQL &= vbCrLf & SQLStoreD25P4080(1)
        'sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        'UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)

        'With report
        '    .OpenConnection(conn)
        '    .AddSub(sSQLSub, sSubReportName & ".rpt")
        '    .AddMain(sSQL)
        '    .PrintReport(sPathReport, sReportCaption)
        'End With

        Print(Me, dr) 'ID 90903 22/11/2016
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

#Region "ID 90903 22/11/2016"
    Private Sub printReport(ByVal sReportPath As String, ByVal sReportName As String, ByVal sSQL As String) 'ID 90903 22/11/2016
        Dim conn As New SqlConnection(gsConnectionString) '
        Dim sSubReportName As String = "D91R0000"
        Dim sSQLSub As String = ""
        Dim sReportCaption As String = ""

        sReportCaption = rL3("Lich_phong_vanW") & " - " & sReportName
        sSQLSub = "SELECT * FROM D91V0016 WHERE DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        UnicodeSubReport(sSubReportName, sSQLSub, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
    End Sub
    Private Sub Print(ByVal form As Form, dr() As DataRow, Optional ByVal sReportTypeID As String = "D25F4080", Optional ByVal sModuleID As String = "25") 'ID 85631 03/06/2016
        Dim sReportName As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""
        Dim sFileExp As String = lblCustomFileExt.Text

        'ID 100088  19.09.2017
        If tdbcCusReportID.Text = "" Then
            sReportName = tdbcReportID.Text
            sReportTypeID = ReturnValueC1Combo(tdbcReportID, "ReportType")
            sReportPath = UnicodeGetReportPath(gbUnicode, 0, tdbcCusReportID.Text) & sReportName & ".rpt"
        Else
            sReportName = tdbcCusReportID.Text
            sReportTypeID = ReturnValueC1Combo(tdbcCusReportID, "ReportTypeID")
            sReportPath = gsApplicationPath & "\Xcustom\" & sReportName & "." & sFileExp
        End If

        'Dim dtReport As DataTable = ReturnTableFilter(D99D0541.ReturnTableReportID(sReportTypeID, sModuleID), "ReportID ='" & sReportName & "'")
        'Dim file As String = D99D0541.GetReportPathNew(dtReport, sModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)

        If sReportName = "" Then Exit Sub
        form.Cursor = Cursors.WaitCursor
        Dim sSQL As String = ""
        sSQL = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString & vbCrLf
        sSQL &= SQLStoreD25P4080(1)

        Select Case sFileExp.ToLower
            Case "rpt"
                printReport(sReportPath, sReportName, sSQL) ' Nếu Caption cố định theo Resource
            Case Else
                'D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
                Dim sPathFile As String = D99D0541.GetObjectFile(sReportTypeID, sReportName, sFileExp, sReportPath)
                If sPathFile = "" Then Exit Select
                CreateWordDocumentCopyTemplate(sPathFile, sSQL)
                OpenFile(sPathFile, False)
        End Select
        form.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click

        Dim dr() As DataRow = Nothing
        If Not AllowPrint(dr, True) Then Exit Sub
        If dr Is Nothing Then Exit Sub

        btnSendEmail.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Dim report As D99C1004
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

        sReportCaption = rL3("Lich_phong_vanW") & " - " & sReportName
        If tdbcCusReportID.Text <> "" Then
            sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCusReportID.Text) & sReportName & ".rpt"
        End If

        '  sSQL = SQLStoreD25P4080()
        sSQL = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString
        sSQL &= vbCrLf & SQLStoreD25P4080(1) ' & vbCrLf
        'sSQL &= SQLDeleteD09T6666()
        sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)


        Dim dtMail As DataTable = ReturnDataTable(sSQL)
        Dim sCandidateID As String = ""
        Dim iResultSend As Integer = 0
        Dim sErrorStringMail As String = ""
        Dim sListCandidateID As String = ""
        'report = New D99C1003()

        'ID 67714
        Dim sMailContent As String = ""
        Dim sMailSubject As String = tdbg.Columns(COL_Subject).Text

        If sMailSubject = "" Then
            If tdbcCusReportID.Text = "" Then
                sMailSubject = ReturnValueC1Combo(tdbcReportID, "ReportName")
            Else
                sMailSubject = ReturnValueC1Combo(tdbcCusReportID, "Title")
            End If
        End If
     

        Dim sSQL1 As String = "SELECT * FROM D13V4022 Where FormID = " & SQLString(Me.Name)
        Dim dt1 As DataTable = ReturnDataTable(sSQL1)
        If dtMail.Rows.Count <= 0 Then
            D99C0008.MsgL3("Không tồn tại dữ liệu")
            Me.Cursor = Cursors.Default
            btnSendEmail.Enabled = True
            Exit Sub
        End If
        '*********************
        For i As Integer = 0 To dtMail.Rows.Count - 1
            'ID 67714
            sMailContent = rtbEmailContent.Text
            For j As Integer = 0 To dt1.Rows.Count - 1
                Dim sCode As String = dt1.Rows(j).Item("CodeID").ToString
                Dim sFieldName As String = dt1.Rows(j).Item("FieldName").ToString
                If dtMail.Columns.Contains(sFieldName) Then
                    sMailContent = sMailContent.Replace(sCode, dtMail.Rows(i).Item(sFieldName).ToString)
                End If
            Next

            sMailContent = sMailContent.Replace(ChrW(10), "<br>")

            'If dtMail.Rows(i).Item("Email").ToString = "" Then Continue For
            report = New D99C1004()

            sCandidateID = dtMail.Rows(i).Item("CandidateID").ToString
            With report
                .OpenConnection(conn)
                .AddSub(sSQLSub, sSubReportName & ".rpt")
                .AddMain(ReturnTableFilter(dtMail, "CandidateID= " & SQLString(sCandidateID)))
                .KeyIDSendMail = sCandidateID
                If tdbcCusReportID.Text <> "" Then
                    .PrintReport(sPathReport, sReportCaption, , , True) ' Có xuất ra file thì truyền True
                End If
                'Send mail: Nếu Tài liệu ghi Người gởi lấy từ UserAdminEmail thì truyền vào ""
                If dtMail.Rows(i).Item("Email").ToString = "" Then GoTo 1
                If Not .SendMail("", dtMail.Rows(i).Item("Email").ToString, "", "", sMailSubject, sMailContent) Then
1:
                    iResultSend += 1
                    sErrorStringMail &= dtMail.Rows(i).Item("CandidateID").ToString & " - " & tdbcReportID.Columns(1).Value.ToString & vbCrLf
                    WriteLogFile("Error when send mail for " & dtMail.Rows(i).Item("CandidateID").ToString & " with Subject" & tdbcReportID.Columns(1).Value.ToString, "ErrorSendMail.log")
                Else
                    If sListCandidateID <> "" Then sListCandidateID &= COMMA
                    sListCandidateID &= SQLString(dtMail.Rows(i).Item("CandidateID"))
                End If
            End With
        Next

        If iResultSend = 0 Then
            D99C0008.MsgL3("Gởi mail thành công")
        Else
            D99C0008.MsgL3("Các mail gởi còn lỗi: " & iResultSend & "/" & dtMail.Rows.Count & vbCrLf & sErrorStringMail)
        End If
        report = Nothing
        If sListCandidateID = "" Then
            Me.Cursor = Cursors.Default
            btnSendEmail.Enabled = True
            Exit Sub
        End If
        Dim strSQL As String = "-- Cap nhat trang thai da goi mail" & vbCrLf
        'ID 100088 19.09.2017
        'strSQL = vbCrLf & "UPDATE  D25T2011" & vbCrLf & _
        '                               "SET           IsSendEmail = 1" & vbCrLf & _
        '                               "WHERE   CandidateID+InterviewFileID IN " & vbCrLf & _
        '                               "       (SELECT  Key01ID+Key02ID " & vbCrLf & _
        '                               "       FROM     D09T6666 WITH (NOLOCK)" & vbCrLf & _
        '                               "       WHERE  UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name) & " and FormID = 'D25F4080'" & vbCrLf & _
        '                               ") AND CandidateID in (" & sListCandidateID & ")" & vbCrLf

        strSQL &= SQLStoreD25P4081() & vbCrLf
      
        If ExecuteSQL(strSQL) Then LoadTDBGrid()

        strSQL = "-- Xoa bang tam" & vbCrLf & _
                          "DELETE D09T6666 WHERE UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name) & " and FormID = 'D25F4080'"
        ExecuteSQLNoTransaction(strSQL)
        Me.Cursor = Cursors.Default
        btnSendEmail.Enabled = True
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    'Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
    '    Try
    '        If (dtGrid Is Nothing) Then Exit Sub
    '        If bRefreshFilter Then Exit Sub
    '        FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
    '        ReLoadTDBGrid()
    '    Catch ex As Exception
    '        'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
    '        WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
    '    End Try
    'End Sub

    'Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    '    HotKeyCtrlVOnGrid(tdbg, e)
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
    '    Select Case tdbg.Columns(tdbg.Col).DataField
    '        Case COL_IsUsed, COL_IsSendEmail  'Chặn Ctrl + V trên cột Check
    '            e.Handled = CheckKeyPress(e.KeyChar)
    '    End Select
    'End Sub

    'Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
    '    LoadEmailContent()
    'End Sub
    'Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
    '    HeadClick(e.ColIndex)
    'End Sub

    Dim bSelect As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case COL_IsUsed
                tdbg.AllowSort = False
                L3HeadClick(tdbg, iCol, bSelect)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub
    Private Sub LoadEmailContent()
        rtbEmailContent.Text = tdbg.Columns(COL_EmailContent).Text
    End Sub

    Dim sCodeID As String = ""
    Dim sCodeName As String = ""
    Private Sub btnGuestInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuestInfo.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", Me.Name)
        Dim frm As Form = CallFormShowDialog("D13D0340", "D13F4024", arrPro)
        sCodeID = GetProperties(frm, "CodeID").ToString

        'Gan vo EmailContent
        Dim iCurrentPos As Integer = rtbEmailContent.SelectionStart
        Dim sContent As String = rtbEmailContent.Text
        Dim sTextBefore As String = sContent.Substring(0, iCurrentPos)
        Dim sTextAfter As String = sContent.Substring(iCurrentPos, sContent.Length - iCurrentPos)
        rtbEmailContent.Text = sTextBefore & sCodeID & sTextAfter
    End Sub

    Private Sub btnEmailContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailContent.Click
        Dim frm As New D25F4081
        frm.FormID = Me.Name
        frm.TypeID = ReturnValueC1Combo(tdbcIntStatusID)
        frm.F_Call = Me
        frm.ShowDialog()
        If frm.bSaved Then
            btnFilter_Click(Nothing, Nothing)
        End If
        frm.Dispose()
    End Sub

    'id 71427 12/6/2015
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: xuanhoa
    '# Created Date: 12/06/2015 03:41:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T66661() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete bang tam D09T6666" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID in ('D25F3060', 'D25F3040')"
        Return sSQL
    End Function

    Private Sub D25F4080_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ExecuteSQLNoTransaction(SQLDeleteD09T6666)
    End Sub
End Class