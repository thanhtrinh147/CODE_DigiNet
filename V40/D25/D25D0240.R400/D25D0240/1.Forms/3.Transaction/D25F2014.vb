Imports System
Public Class D25F2014
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Parameters"
    Private _interviewFileID As String
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property

    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _recTeamID As String
    Public Property RecTeamID() As String
        Get
            Return _recTeamID
        End Get
        Set(ByVal Value As String)
            _recTeamID = Value
        End Set
    End Property

    Private _candidate As String
    Public Property Candidate() As String
        Get
            Return _candidate
        End Get
        Set(ByVal Value As String)
            _candidate = Value
        End Set
    End Property

    Private _interviewLevel As String
    Public Property InterviewLevel() As String
        Get
            Return _interviewLevel
        End Get
        Set(ByVal Value As String)
            _interviewLevel = Value
        End Set
    End Property

#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim iInterviewerIDRowCount As Integer = -1

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcInterviewerID
        sSQL = "Select T1.InterviewerID, InterviewerName From D25T2014 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Inner join	D25T1070 	T2  WITH(NOLOCK) On T1.InterviewerID = T2.InterviewerID" & vbCrLf
        sSQL &= " Where	T1.DivisionID 		= " & SQLString(gsDivisionID)
        sSQL &= " And T1.InterviewFileID 	= " & SQLString(InterviewFileID) & vbCrLf
        sSQL &= " Order by	T1.InterviewerID"
        'LoadDataSource(tdbcInterviewerID, sSQL)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 1 Then
            iInterviewerIDRowCount = 1
        End If
        LoadDataSource(tdbcInterviewerID, dt)
        
    End Sub

    Private Sub D25F2014_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F2014_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadData()
InputDateCustomFormat(c1dateBirthDate,c1dateReceivedDate,c1dateIntDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
        btnUpdateResult.Enabled = ReturnPermission("D25F3040") = EnumPermission.DeleteEditAdd
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateIntDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcInterviewerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtInterviewPlace.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_lich_phong_van_-_D25F2014") 'CËp nhËt lÜch phàng vÊn - D25F2014
        '================================================================ 
        lblInfoCandidate.Text = rl3("Thong_tin_ung_vien") 'Thông tin ứng viên
        lblCandidate.Text = rl3("Ung_vien") 'Ứng viên
        lblteBirthDate.Text = rl3("Ngay_sinh") 'Ngày sinh
        lblSex.Text = rl3("Gioi_tinh") 'Giới tính
        lblCountryName.Text = rl3("Quoc_tich") 'Quốc tịch
        lblteReceivedDate.Text = rl3("Ngay_nhan_ho_so") 'Ngày nhận hồ sơ
        lblFileReceivedName.Text = rl3("Nguoi_nhan") 'Người nhận
        lblRecSourceName.Text = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        lblRecCandidate.Text = rl3("Bo_phan_ung_tuyen") 'Bộ phận ứng tuyển
        lblRecDepartmentName.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeamName.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionName.Text = rl3("Vi_tri") 'Vị trí
        lblDesiredSalary.Text = rl3("Luong_yeu_cau") 'Lương yêu cầu
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblInterviewPlace.Text = rl3("Dia_diem") 'Địa điểm
        lblTime.Text = rl3("Lich_phong_van") 'Lịch phỏng vấn
        lblteIntDate.Text = rl3("Ngay_phong_van") 'Thời gian
        lblInTime.Text = rl3("Gio_phong_van")
        lblInterviewerID.Text = rl3("Nguoi_phong_van") 'Người phỏng vấn
        lblContent.Text = rl3("Noi_dung") 'Nội dung
        '================================================================ 
        btnFileRecSource.Text = rl3("_Ho_so_ung_vien") '&Hồ sơ ứng viên
        btnRecruitmentFileID.Text = rl3("Dot__tuyen_dung") 'Đợt &tuyển dụng
        btnUpdateResult.Text = rl3("_Cap_nhat_ket_qua") '&Cập nhật kết quả
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkLongBusinesstrip.Text = rl3("Di_cong_tac_xa") 'Đi công tác xa
        '================================================================ 
        tdbcInterviewerID.Columns("InterviewerID").Caption = rl3("Ma") 'Mã
        tdbcInterviewerID.Columns("InterviewerName").Caption = rl3("Ten") 'Tên
    End Sub

#Region "Events tdbcInterviewerID"

    Private Sub tdbcInterviewerID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewerID.Close
        If tdbcInterviewerID.FindStringExact(tdbcInterviewerID.Text) = -1 Then tdbcInterviewerID.Text = ""
    End Sub

    Private Sub tdbcInterviewerID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcInterviewerID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcInterviewerID.Text = ""
    End Sub

#End Region

    'Hồ sơ ứng viên(chỉ xem)
    Private Sub btnFileRecSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileRecSource.Click
        '    Dim f As New D25M0140
        '    With f
        '        .FormActive = enumD25E0140Form.D25F1051
        '        .ID01 = Candidate
        '        .FormState = EnumFormState.FormView
        '        .ShowDialog()
        '        .Dispose()
        '    End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CandidateID", Candidate)
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormThread(Me, "D25D0140", "D25F1051", arrPro)
    End Sub

    Private Sub btnRecruitmentFileID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecruitmentFileID.Click
        Dim f As New D25F1044
        f.RecruitmentFileID = RecruitmentFileID
        f.CandidateID = Candidate
        f.ShowDialog()
        f.Dispose()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2020
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 03/12/2007 03:13:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load dữ liệu
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD25P2020() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D25P2020 "
    '    sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Title, varchar[250], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString(InterviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecruitPlanID, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(RecTeamID) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString("%") & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(Candidate) & COMMA 'CandidateID, varchar[20], NOT NULL
    '    sSQL &= SQLString("") 'WhereClause, varchar[8000], NOT NULL
    '    Return sSQL
    'End Function

    Private Function SQLStoreD25P2020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2020 "
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA '', " 'TranMonthFrom
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLString(InterviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecruitPlanID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(RecTeamID) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(Candidate) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'WhereClause, varchar[8000], NOT NULL
        Return sSQL
    End Function

    Private Sub LoadImage()
        If Not picImageID.Image Is Nothing Then picImageID.Image.Dispose()
        Dim sSQL As String =  "Select ImageID From D25T1041 WITH(NOLOCK)  Where DivisionID=" & SQLString(gsDivisionID) & " And CandidateID=" & SQLString(_candidate)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then picImageID.Image = ReturnImage(dt.Rows(0).Item(0))
    End Sub

    Private Sub LoadData()
        Try
            Dim sSQL As String = SQLStoreD25P2020()
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                'Thông tin ứng viên
                txtCandidate.Text = Candidate
                txtCandidateName.Text = dt.Rows(0).Item("CandidateName").ToString
                c1dateBirthDate.Value = SQLDateShow(dt.Rows(0).Item("BirthDate"))
                txtSex.Text = dt.Rows(0).Item("Sex").ToString
                txtCountryName.Text = dt.Rows(0).Item("CountryName").ToString
                c1dateReceivedDate.Value = SQLDateShow(dt.Rows(0).Item("ReceivedDate"))
                txtFileReceivedName.Text = dt.Rows(0).Item("FileReceiverName").ToString
                txtRecSourceName.Text = dt.Rows(0).Item("RecSourceName").ToString
                'Bộ phận ứng tuyển
                txtRecDepartmentName.Text = dt.Rows(0).Item("RecDepartmentName").ToString
                txtRecTeamName.Text = dt.Rows(0).Item("RecTeamName").ToString
                txtRecPositionName.Text = dt.Rows(0).Item("RecPositionName").ToString
                txtDesiredSalary.Text = Format(dt.Rows(0).Item("DesiredSalary"), D25Format.DefaultNumber2)
                txtCurrencyID.Text = dt.Rows(0).Item("CurrencyID").ToString
                chkLongBusinesstrip.Checked = CBool(dt.Rows(0).Item("LongBusinesstrip"))
                '--------------------------------------------------------------
                'Lịch phỏng vấn
                'c1dateIntDate.Value = IIf(dt.Rows(0).Item("IntDate").ToString = "", "", Format(Convert.ToDateTime(dt.Rows(0).Item("IntDate")), gsDateTimeShow))
                c1dateIntDate.Value = SQLDateShow(dt.Rows(0).Item("IntDate"))
                If dt.Rows(0).Item("IntTime").ToString <> "" Then
                    Dim d As DateTime = Now.Date
                    d = d.AddHours(CDbl(dt.Rows(0).Item("IntTime").ToString.Substring(0, 2)))
                    d = d.AddMinutes(CDbl(dt.Rows(0).Item("IntTime").ToString.Substring(2)))
                    c1dateIntTime.Value = d
                End If


                txtInterviewPlace.Text = dt.Rows(0).Item("InterviewPlace").ToString
                tdbcInterviewerID.SelectedValue = dt.Rows(0).Item("Interviewer").ToString
                'Nếu có 1 dòng thì mặc định dòng đầu tiên - theo y/c của Thu Thảo 23/10/2008
                If iInterviewerIDRowCount = 1 Then tdbcInterviewerID.SelectedIndex = 0
                txtContent.Text = dt.Rows(0).Item("Content").ToString
                '--------------------------------------------------------------
                LoadImage()
            End If
        Catch ex As Exception

        End Try

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2011
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 04/12/2007 08:34:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2011() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2011 Set ")
        'sSQL.Append("IntDate = " & "'" & Format(c1dateIntDate.Value, gsDateTimeSave) & "'" & COMMA) 'datetime, NULL
        'sSQL.Append("IntDate = " & "'" & Format(c1dateIntDate.Value, "MM/dd/yyyy hh:mm:ss tt") & "'" & COMMA) 'datetime, NULL
        sSQL.Append("IntDate = " & SQLDateSave(c1dateIntDate.Value) & COMMA) 'datetime, NULL
        If c1dateIntTime.Text <> "" Then
            sSQL.Append("IntTime = " & SQLString(Format(c1dateIntTime.Value, "HHmm")) & COMMA) 'varchar[4], NOT NULL
        Else
            sSQL.Append("IntTime = " & SQLString("") & COMMA) 'varchar[4], NOT NULL
        End If
        'sSQL.Append("IntTime = " & SQLString(Format(c1dateIntTime.Value, "HHmm")) & COMMA) 'varchar[4], NOT NULL
        sSQL.Append("Interviewer = " & SQLString(tdbcInterviewerID.SelectedValue) & COMMA) 'varchar[50], NULL
        sSQL.Append("InterviewPlace = " & SQLString(txtInterviewPlace.Text) & COMMA) 'varchar[250], NULL
        sSQL.Append("Content = " & SQLString(txtContent.Text)) 'varchar[500], NULL
        sSQL.Append(" Where ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
        sSQL.Append("InterviewFileID = " & SQLString(InterviewFileID) & " And ")
        sSQL.Append("RecruitmentFileID = " & SQLString(RecruitmentFileID) & " And ")
        sSQL.Append("CandidateID = " & SQLString(Candidate) & " And ")
        sSQL.Append("InterviewLevels = " & SQLString(InterviewLevel))
        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If c1dateIntDate.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Thoi_gian"))
            c1dateIntDate.Focus()
            Return False
        End If
        If txtInterviewPlace.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dia_diem"))
            txtInterviewPlace.Focus()
            Return False
        End If
        If tdbcInterviewerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nguoi_phong_van"))
            tdbcInterviewerID.Focus()
            Return False
        End If
        Return True
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        _bSaved = False
        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD25T2011)


        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnUpdateResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateResult.Click
        Dim f As New D25F2050
        f.InterviewFileID = _interviewFileID
        f.RecruitmentFileID = _recruitmentFileID
        f.CandidateID = txtCandidate.Text
        f.InterviewLevel = _interviewLevel
        f.FormState = _FormState
        f.ShowDialog()
        f.Dispose()
    End Sub
End Class