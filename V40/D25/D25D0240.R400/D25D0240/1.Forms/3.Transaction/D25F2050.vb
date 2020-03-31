Imports System.Xml
Imports System
Public Class D25F2050
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim RecDepartmentID, RecTeamID, RecPositionID As String
    Dim sFirstName, sMiddleName, sLastName, sInterviewFileID As String
    Dim IntGroupID As String = ""

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

    Private _candidateID As String
    Public Property CandidateID() As String
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String)
            _candidateID = Value
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

    Private _interviewLevelID As String = ""
    Public WriteOnly Property InterviewLevelID() As String
        Set(ByVal Value As String)
            _interviewLevelID = Value
        End Set
    End Property

    Private _fromDate As String
    Public Property FromDate() As String
        Get
            Return _fromDate
        End Get
        Set(ByVal Value As String)
            _fromDate = value
        End Set
    End Property

    Private _toDate As String
    Public Property ToDate() As String
        Get
            Return _toDate
        End Get
        Set(ByVal Value As String)
            _toDate = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            _bSaved = False
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D25F2050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name <> "txtResult" And Me.ActiveControl.Name <> "txtContent" Then
                UseEnterAsTab(Me)
            End If
        End If
    End Sub


    Private Sub D25F2050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        btnDetailRecruitment.Enabled = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadDefaultValue()
        LoadTDBCombo()
        LoadData()
        LoadRef()
        '*******************
        InputbyUnicode(Me, gbUnicode)
        '*******************
InputDateCustomFormat(c1dateIntDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateIntDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcInterviewerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcIntStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_ket_qua_phong_van_-_D25F2050") & UnicodeCaption(gbUnicode) 'CËp nhËt kÕt qu¶ phàng vÊn - D25F2050
        '================================================================ 
        lblTime.Text = rl3("Ket_qua_phong_van") 'Kết quả phỏng vấn
        lblteIntDate.Text = rl3("Ngay_PV") 'Thời gian PV
        lblInTime.Text = rl3("Gio_PV")
        lblInterviewerID.Text = rl3("Nguoi_PV") 'Người PV
        lblContent.Text = rl3("Noi_dung") 'Nội dung
        lblResult.Text = rl3("Danh_gia") 'Đánh giá
        lblIntStatusID.Text = rl3("Ket_qua") 'Kết quả

        lblAttendace.Text = rl3("Danh_gia_tong_quat") 'Đánh giá tổng quát
        lblElementEvaluation.Text = rl3("Yeu_to_danh_gia") 'Yếu tố đánh giá
        lblValue.Text = rl3("Gia_tri_") 'Giá trị
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú

        lblEE01.Text = rl3("Yeu_toV") & " 01"
        lblEE02.Text = rl3("Yeu_toV") & " 02"
        lblEE03.Text = rl3("Yeu_toV") & " 03"
        lblEE04.Text = rl3("Yeu_toV") & " 04"
        lblEE05.Text = rl3("Yeu_toV") & " 05"
        lblEE06.Text = rl3("Yeu_toV") & " 06"
        lblEE07.Text = rl3("Yeu_toV") & " 07"
        lblEE08.Text = rl3("Yeu_toV") & " 08"
        lblEE09.Text = rl3("Yeu_toV") & " 09"
        lblEE10.Text = rl3("Yeu_toV") & " 10"
        lblInterviewLevels.Text = rl3("Vong_PV")
        '================================================================ 
        btnFileRecSource.Text = "&1. " & rl3("Ho_so_ung_vien") 'Hồ sơ ứng viên
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnDetailRecruitment.Text = "&2. " & rl3("Chi_tiet_ket_qua_PV") 'Chi tiết kết quả PV
        '================================================================ 
        tdbcInterviewerID.Columns("InterviewerID").Caption = rl3("Ma") 'Mã
        tdbcInterviewerID.Columns("InterviewerName").Caption = rl3("Ten") 'Tên
        tdbcInterviewLevels.Columns(0).Caption = rl3("Ma") 'Mã
        tdbcInterviewLevels.Columns(1).Caption = rl3("Ten") 'Tên
        tdbcIntStatusID.Columns("IntStatusID").Caption = rl3("Ma") 'Mã
        tdbcIntStatusID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcInterviewerID
        sSQL = "Select InterviewerID, InterviewerName" & UnicodeJoin(gbUnicode) & " AS InterviewerName" & vbCrLf
        sSQL &= "From  D25T1070 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where       Disabled = 0" & vbCrLf
        sSQL &= "Order by    InterviewerID" & vbCrLf
        LoadDataSource(tdbcInterviewerID, sSQL, gbUnicode)
 
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add("IntStatusID", System.Type.GetType("System.String"))
        dt.Columns.Add("Description", System.Type.GetType("System.String"))

        'Đạt
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00001"
        dr.Item("Description") = IIf(gbUnicode, "Đạt", "Ñaït").ToString() 'rl3("Dat_V")
        dt.Rows.Add(dr)

        'Không đạt
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00002"
        dr.Item("Description") = IIf(gbUnicode, "Không đạt", "Khoâng ñaït").ToString() 'rl3("Khong_dat_V")
        dt.Rows.Add(dr)

        'Không tham gia phỏng vấn
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00003"
        dr.Item("Description") = IIf(gbUnicode, "Không tham gia phỏng vấn", "Khoâng tham gia phoûng vaán").ToString() 'rl3("Khong_tham_gia_phong_van_V")
        dt.Rows.Add(dr)

        'Dời lịch phỏng vấn
        dr = dt.NewRow
        dr.Item("IntStatusID") = "00004"
        dr.Item("Description") = IIf(gbUnicode, "Dời lịch phỏng vấn", "Dôøi lòch phoûng vaán").ToString()
        dt.Rows.Add(dr)

        LoadDataSource(tdbcIntStatusID, dt, gbUnicode)

        sSQL = "-- Do nguon Combo Vòng PV: " & vbCrLf & _
            "Select 	InterviewLevel AS InterViewLevels, LevelName" & gsLanguage & UnicodeJoin(gbUnicode) & " AS InterViewLevelName" & vbCrLf & _
            "From 	D25V2015 " & vbCrLf & _
            "Order by 	No"
        LoadDataSource(tdbcInterviewLevels, sSQL, gbUnicode)
    End Sub

    Private Sub RefSetting(ByVal dr As DataRow, ByVal lbl As Label, ByVal txtEEValue As TextBox, ByVal txtEE As TextBox)
        If Not CBool(dr("Disabled")) Then
            lbl.Text = dr("RefCaption" & UnicodeJoin(gbUnicode)).ToString
            lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
        Else
            lbl.Visible = False
            txtEEValue.Visible = False
            txtEE.Visible = False
        End If
    End Sub

    Private Sub LoadRef()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD25P0050("D25T2011"))
        With dt
            If .Rows.Count > 0 Then
                RefSetting(dt.Rows(0), lblEE01, txtEEValue01, txtEE01)
                RefSetting(dt.Rows(1), lblEE02, txtEEValue02, txtEE02)
                RefSetting(dt.Rows(2), lblEE03, txtEEValue03, txtEE03)
                RefSetting(dt.Rows(3), lblEE04, txtEEValue04, txtEE04)
                RefSetting(dt.Rows(4), lblEE05, txtEEValue05, txtEE05)
                RefSetting(dt.Rows(5), lblEE06, txtEEValue06, txtEE06)
                RefSetting(dt.Rows(6), lblEE07, txtEEValue07, txtEE07)
                RefSetting(dt.Rows(7), lblEE08, txtEEValue08, txtEE08)
                RefSetting(dt.Rows(8), lblEE09, txtEEValue09, txtEE09)
                RefSetting(dt.Rows(9), lblEE10, txtEEValue10, txtEE10)
            End If
        End With

    End Sub

#Region "Events tdbcInterviewerID"

    Private Sub tdbcInterviewerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewerID.LostFocus
        If tdbcInterviewerID.FindStringExact(tdbcInterviewerID.Text) = -1 Then tdbcInterviewerID.Text = ""
    End Sub
#End Region

#Region "Events tdbcIntStatusID with txtIntStatusName"

    Private Sub tdbcIntStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIntStatusID.LostFocus, tdbcInterviewLevels.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then
            tdbc.Text = ""
        End If
    End Sub


#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcInterviewerID.KeyDown, tdbcIntStatusID.KeyDown
    '    If gbUnicode Then Exit Sub
    '    Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbcName.AutoCompletion = False
    '        Case Else
    '            tdbcName.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewerID.Leave, tdbcIntStatusID.Leave
    '    If gbUnicode Then Exit Sub
    '    Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

    '    If tdbcName.SelectedIndex <> -1 Then
    '        tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
    '    End If
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewerID.Close, tdbcIntStatusID.Close, tdbcInterviewLevels.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcInterviewerID.Validated, tdbcIntStatusID.Validated, tdbcInterviewLevels.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    'Hồ sơ ứng viên(chỉ xem)
    Private Sub btnFileRecSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileRecSource.Click
        'Dim f As New D25M0140
        'With f
        '    .FormActive = enumD25E0140Form.D25F1051
        '    .ID01 = CandidateID
        '    .FormState = EnumFormState.FormView
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CandidateID", CandidateID)
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormThread(Me, "D25D0140", "D25F1051", arrPro)
    End Sub

    'Đợt tuyển dụng (chỉ xem)
    Private Sub btnRecruitmentFileID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New D25F1044
        f.RecruitmentFileID = RecruitmentFileID
        f.CandidateID = CandidateID
        f.ShowDialog()
        f.Dispose()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3030
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 06/12/2007 10:45:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load dữ liệu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3030 "
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_interviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString(_RecruitmentFileID) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecTeamID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLString(CandidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'IntStatusID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub LoadData()

        Try
            Dim sSQL As String = SQLStoreD25P3030()
            Dim dt As DataTable = ReturnDataTable(sSQL)

            If dt.Rows.Count > 0 Then
                'Thông tin ứng viên
                sFirstName = dt.Rows(0).Item("FirstName").ToString
                sMiddleName = dt.Rows(0).Item("MiddleName").ToString
                sLastName = dt.Rows(0).Item("LastName").ToString
                sInterviewFileID = dt.Rows(0).Item("InterviewFileID").ToString

                RecDepartmentID = dt.Rows(0).Item("RecDepartmentID").ToString
                RecTeamID = dt.Rows(0).Item("RecTeamID").ToString
                RecPositionID = dt.Rows(0).Item("RecPositionID").ToString
                IntGroupID = dt.Rows(0).Item("IntGroupID").ToString

                '--------------------------------------------------------------
                'Kết quả phỏng vấn
                c1dateIntDate.Value = SQLDateShow(dt.Rows(0).Item("IntDate")) 'IIf(dt.Rows(0).Item("IntDate").ToString = "", "", Format(Convert.ToDateTime(dt.Rows(0).Item("IntDate")), gsDateTimeShow))
                If dt.Rows(0).Item("IntTime").ToString <> "" Then
                    Dim d As DateTime = Now.Date
                    Dim sTime As String = dt.Rows(0).Item("IntTime").ToString
                    If sTime.Length <= 2 Then
                        d = d.AddHours(CDbl(sTime))
                        d = d.AddMinutes(CDbl(0))
                    Else
                        d = d.AddHours(CDbl(sTime.Substring(0, 2)))
                        d = d.AddMinutes(CDbl(sTime.Substring(2)))
                    End If

                    c1dateIntTime.Value = d
                End If

                tdbcInterviewerID.SelectedValue = dt.Rows(0).Item("Interviewer").ToString
                txtContent.Text = dt.Rows(0).Item("Content").ToString
                txtResult.Text = dt.Rows(0).Item("Result").ToString
                tdbcIntStatusID.SelectedValue = dt.Rows(0).Item("IntStatusID").ToString
                tdbcInterviewLevels.SelectedValue = dt.Rows(0).Item("InterviewLevels").ToString

                '--------------------------------------------------------------
                'Tab: Đánh giá chi tiết
                txtEEValue01.Text = Format(dt.Rows(0).Item("EEValue01"), D25Format.DefaultNumber2)
                txtEE01.Text = dt.Rows(0).Item("EE01").ToString
                txtEEValue02.Text = Format(dt.Rows(0).Item("EEValue02"), D25Format.DefaultNumber2)
                txtEE02.Text = dt.Rows(0).Item("EE02").ToString
                txtEEValue03.Text = Format(dt.Rows(0).Item("EEValue03"), D25Format.DefaultNumber2)
                txtEE03.Text = dt.Rows(0).Item("EE03").ToString
                txtEEValue04.Text = Format(dt.Rows(0).Item("EEValue04"), D25Format.DefaultNumber2)
                txtEE04.Text = dt.Rows(0).Item("EE04").ToString
                txtEEValue05.Text = Format(dt.Rows(0).Item("EEValue05"), D25Format.DefaultNumber2)
                txtEE05.Text = dt.Rows(0).Item("EE05").ToString
                txtEEValue06.Text = Format(dt.Rows(0).Item("EEValue06"), D25Format.DefaultNumber2)
                txtEE06.Text = dt.Rows(0).Item("EE06").ToString
                txtEEValue07.Text = Format(dt.Rows(0).Item("EEValue07"), D25Format.DefaultNumber2)
                txtEE07.Text = dt.Rows(0).Item("EE07").ToString
                txtEEValue08.Text = Format(dt.Rows(0).Item("EEValue08"), D25Format.DefaultNumber2)
                txtEE08.Text = dt.Rows(0).Item("EE08").ToString
                txtEEValue09.Text = Format(dt.Rows(0).Item("EEValue09"), D25Format.DefaultNumber2)
                txtEE09.Text = dt.Rows(0).Item("EE09").ToString
                txtEEValue10.Text = Format(dt.Rows(0).Item("EEValue10"), D25Format.DefaultNumber2)
                txtEE10.Text = dt.Rows(0).Item("EE10").ToString
                '--------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
        sSQL.Append("IntDate = " & SQLDateSave(c1dateIntDate.Text) & COMMA) 'datetime, NULL
        If c1dateIntTime.Text <> "" Then
            sSQL.Append("IntTime = " & SQLString(Format(c1dateIntTime.Value, "HHmm")) & COMMA) 'varchar[4], NOT NULL
        Else
            sSQL.Append("IntTime = " & SQLString("") & COMMA) 'varchar[4], NOT NULL
        End If

        sSQL.Append("Interviewer = " & SQLString(tdbcInterviewerID.SelectedValue) & COMMA) 'varchar[50], NULL
        sSQL.Append("InterViewLevels  = " & SQLString(tdbcInterviewLevels.SelectedValue) & COMMA) 'varchar[50], NULL
        sSQL.Append("IntStatusID = " & SQLString(tdbcIntStatusID.Columns("IntStatusID").Text) & COMMA) 'varchar[250], NULL
        sSQL.Append("Content = " & SQLStringUnicode(txtContent.Text, gbUnicode, False) & COMMA) 'varchar[500], NULL
        sSQL.Append("ContentU = " & SQLStringUnicode(txtContent.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Result = " & SQLStringUnicode(txtResult.Text, gbUnicode, False) & COMMA)
        sSQL.Append("ResultU = " & SQLStringUnicode(txtResult.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL

        sSQL.Append("EEValue01 = " & SQLMoney(txtEEValue01.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE01 = " & SQLStringUnicode(txtEE01.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue02 = " & SQLMoney(txtEEValue02.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE02 = " & SQLStringUnicode(txtEE02.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue03 = " & SQLMoney(txtEEValue03.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE03 = " & SQLStringUnicode(txtEE03.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue04= " & SQLMoney(txtEEValue04.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE04 = " & SQLStringUnicode(txtEE04.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue05 = " & SQLMoney(txtEEValue05.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE05 = " & SQLStringUnicode(txtEE05.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue06 = " & SQLMoney(txtEEValue06.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE06 = " & SQLStringUnicode(txtEE06.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue07 = " & SQLMoney(txtEEValue07.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE07 = " & SQLStringUnicode(txtEE07.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue08 = " & SQLMoney(txtEEValue08.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE08 = " & SQLStringUnicode(txtEE08.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue09 = " & SQLMoney(txtEEValue09.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE09 = " & SQLStringUnicode(txtEE09.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EEValue10 = " & SQLMoney(txtEEValue10.Text, D25Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("EE10 = " & SQLStringUnicode(txtEE10.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL

        sSQL.Append("EE01U = " & SQLStringUnicode(txtEE01.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE02U = " & SQLStringUnicode(txtEE02.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE03U = " & SQLStringUnicode(txtEE03.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE04U = " & SQLStringUnicode(txtEE04.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE05U = " & SQLStringUnicode(txtEE05.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE06U = " & SQLStringUnicode(txtEE06.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE07U = " & SQLStringUnicode(txtEE07.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE08U = " & SQLStringUnicode(txtEE08.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE09U = " & SQLStringUnicode(txtEE09.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EE10U = " & SQLStringUnicode(txtEE10.Text, gbUnicode, True)) 'nvarchar, NOT NULL

        sSQL.Append(" Where ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
        sSQL.Append("InterviewFileID = " & SQLString(InterviewFileID) & " And ")
        sSQL.Append("CandidateID = " & SQLString(CandidateID))
        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If c1dateIntDate.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Thoi_gian"))
            c1dateIntDate.Focus()
            Return False
        End If
        If tdbcIntStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ket_qua"))
            tdbcIntStatusID.Focus()
            Return False
        End If
        If tdbcInterviewerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_phong_van"))
            tdbcInterviewerID.Focus()
            Return False
        End If

        If txtEEValue01.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Hoc_van"))
            txtEEValue01.Focus()
            Return False
        ElseIf CDbl(txtEEValue01.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue01.Focus()
            Return False
        End If

        If txtEEValue02.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Kinh_nghiem"))
            txtEEValue02.Focus()
            Return False
        ElseIf CDbl(txtEEValue02.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue02.Focus()
            Return False
        End If

        If txtEEValue03.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngoai_hinh"))
            txtEEValue03.Focus()
            Return False
        ElseIf CDbl(txtEEValue03.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue03.Focus()
            Return False
        End If

        If txtEEValue04.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Thai_do"))
            txtEEValue04.Focus()
            Return False
        ElseIf CDbl(txtEEValue04.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue04.Focus()
            Return False
        End If

        If txtEEValue05.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Tu_duy"))
            txtEEValue05.Focus()
            Return False
        ElseIf CDbl(txtEEValue05.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue05.Focus()
            Return False
        End If

        If txtEEValue06.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Giao_tiep"))
            txtEEValue06.Focus()
            Return False
        ElseIf CDbl(txtEEValue06.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue06.Focus()
            Return False
        End If

        If txtEEValue07.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("An_tuong"))
            txtEEValue07.Focus()
            Return False
        ElseIf CDbl(txtEEValue07.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue07.Focus()
            Return False
        End If

        If txtEEValue08.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Han_che"))
            txtEEValue08.Focus()
            Return False
        ElseIf CDbl(txtEEValue08.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue08.Focus()
            Return False
        End If

        If txtEEValue09.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Toan_dien"))
            txtEEValue09.Focus()
            Return False
        ElseIf CDbl(txtEEValue09.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue09.Focus()
            Return False
        End If

        If txtEEValue10.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Khac"))
            txtEEValue10.Focus()
            Return False
        ElseIf CDbl(txtEEValue10.Text.Trim) > MaxSmallMoney Then
            D99C0008.Msg(rl3("Nhap_so_qua_lon"))
            txtEEValue10.Focus()
            Return False
        End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2011
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/12/2007 03:22:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu AddNew
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2011() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T2011(")
        sSQL.Append("DivisionID, InterviewFileID, RecruitmentFileID, CandidateID, IntStatusID, ")
        sSQL.Append("IntDate, IntTime, Interviewer,  Result, Disabled, ") 'InterviewPlace,
        sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ") 'RecStatusID, ")
        sSQL.Append("InterviewLevels, Content, ")
        sSQL.Append("EEValue01, EE01,  EEValue02, EE02, EEValue03, EE03, EEValue04, EE04, EEValue05, EE05, EEValue06, EE06, EEValue07, EE07, EEValue08, EE08, EEValue09, EE09, EEValue10, EE10, ")
        sSQL.Append("ContentU, ResultU, EE01U, EE02U, EE03U, ")
        sSQL.Append("EE04U, EE05U, EE06U, EE07U, EE08U, ")
        sSQL.Append("EE09U, EE10U")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(_interviewFileID) & COMMA) 'InterviewFileID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(_RecruitmentFileID) & COMMA) 'RecruitmentFileID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(_candidateID) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcIntStatusID.Text) & COMMA) 'IntStatusID, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateIntDate.Text) & COMMA) 'IntDate, datetime, NULL
        If c1dateIntTime.Text <> "" Then
            sSQL.Append(SQLString(Format(c1dateIntTime.Value, "HHmm")) & COMMA) 'varchar[4], NOT NULL
        Else
            sSQL.Append(SQLString("") & COMMA) 'varchar[4], NOT NULL
        End If

        sSQL.Append(SQLString(tdbcInterviewerID.SelectedValue) & COMMA) 'Interviewer, varchar[50], NULL
        'sSQL.Append(SQLString(?????) & COMMA) 'InterviewPlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtResult.Text, gbUnicode, False) & COMMA) 'Result, varchar[500], NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        'sSQL.Append(SQLString(?????) & COMMA) 'RecStatusID, varchar[20], NULL
        sSQL.Append(SQLString(InterviewLevel) & COMMA) 'InterviewLevels [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtContent.Text, gbUnicode, False) & COMMA) 'Content, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue01.Text, D25Format.DefaultNumber2) & COMMA) 'EducationValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE01.Text, gbUnicode, False) & COMMA) 'EducationComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue02.Text, D25Format.DefaultNumber2) & COMMA) 'ExperienceValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE02.Text, gbUnicode, False) & COMMA) 'ExperienceComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue03.Text, D25Format.DefaultNumber2) & COMMA) 'AppearanceValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE03.Text, gbUnicode, False) & COMMA) 'AppearanceComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue04.Text, D25Format.DefaultNumber2) & COMMA) 'AttitudeValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE04.Text, gbUnicode, False) & COMMA) 'AttitudeComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue05.Text, D25Format.DefaultNumber2) & COMMA) 'IntellectualValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE05.Text, gbUnicode, False) & COMMA) 'IntellectualComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue06.Text, D25Format.DefaultNumber2) & COMMA) 'CommunicationValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE06.Text, gbUnicode, False) & COMMA) 'CommunicationComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue07.Text, D25Format.DefaultNumber2) & COMMA) 'ImpressionValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE07.Text, gbUnicode, False) & COMMA) 'ImpressionComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue08.Text, D25Format.DefaultNumber2) & COMMA) 'ProblemValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE08.Text, gbUnicode, False) & COMMA) 'ProblemComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue09.Text, D25Format.DefaultNumber2) & COMMA) 'OverallValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE09.Text, gbUnicode, False) & COMMA) 'OverallComment, varchar[250], NOT NULL

        sSQL.Append(SQLMoney(txtEEValue10.Text, D25Format.DefaultNumber2) & COMMA) 'OtherValue, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE10.Text, gbUnicode, False) & COMMA) 'OtherComment, varchar[250], NOT NULL

        sSQL.Append(SQLStringUnicode(txtContent.Text, gbUnicode, True) & COMMA) 'ContentU, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtResult.Text, gbUnicode, True) & COMMA) 'ResultU, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE01.Text, gbUnicode, True) & COMMA) 'EE01U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE02.Text, gbUnicode, True) & COMMA) 'EE02U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE03.Text, gbUnicode, True) & COMMA) 'EE03U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE04.Text, gbUnicode, True) & COMMA) 'EE04U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE05.Text, gbUnicode, True) & COMMA) 'EE05U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE06.Text, gbUnicode, True) & COMMA) 'EE06U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE07.Text, gbUnicode, True) & COMMA) 'EE07U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE08.Text, gbUnicode, True) & COMMA) 'EE08U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE09.Text, gbUnicode, True) & COMMA) 'EE09U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtEE10.Text, gbUnicode, True)) 'EE10U, nvarchar, NOT NULL

        sSQL.Append(")")
        Return sSQL
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

        sSQL.Append(SQLUpdateD25T2011.ToString & vbCrLf)
        sSQL.Append(SQLStoreD25P3033.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnDetailRecruitment.Enabled = True

            btnClose.Focus()
            Select Case _FormState
                Case EnumFormState.FormEdit
                    'Bổ sung AuditLog (10/04/2008), Analyst: Ngọc Lan

                    Dim Decs1 As String = ""
                    Dim Decs2 As String = ""
                    Dim Decs3 As String = ""
                    Dim Decs4 As String = ""
                    Dim Decs5 As String = ""
                    Decs1 = Trim("")
                    Decs2 = Trim(c1dateIntDate.Text)
                    Decs3 = Trim(tdbcInterviewerID.Text)
                    Decs4 = Trim(tdbcIntStatusID.Text)
                    Decs5 = Trim("")
                    Call RunAuditLog("Result", "02", Decs1, Decs2, Decs3, Decs4, Decs5)

            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    'Kiểm tra button 3,4,5 có bị locked không
    Private Sub EnabledButton345()
        If InterviewLevel = "FL" And tdbcIntStatusID.Columns("IntStatusID").Text = "00001" Then
            btnDetailRecruitment.Enabled = True
        Else
            btnDetailRecruitment.Enabled = False
        End If
    End Sub

    'Chi tiết kết quả PV
    Private Sub btnDetailRecruitment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailRecruitment.Click
        Dim f As New D25F2051
        f.IsOnlyView = Not btnSave.Enabled
        f.InterviewFileID = InterviewFileID
        f.CandidateID = CandidateID
        f.IntGroupID = IntGroupID
        f.ShowDialog()
        f.Dispose()
    End Sub

    ' Bổ sung Tab: Đánh giá chi tiết
    Private Sub LoadDefaultValue()
        txtEEValue01.Text = "0.00"
        txtEEValue02.Text = "0.00"
        txtEEValue03.Text = "0.00"
        txtEEValue04.Text = "0.00"
        txtEEValue05.Text = "0.00"
        txtEEValue06.Text = "0.00"
        txtEEValue07.Text = "0.00"
        txtEEValue08.Text = "0.00"
        txtEEValue09.Text = "0.00"
        txtEEValue10.Text = "0.00"
    End Sub

    Private Sub txtEducationValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue01.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtExperienceValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue02.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAppearanceValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue03.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAttituteValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue04.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIntellectualValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue05.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtCommunicationValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue06.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtImpressionValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue07.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtProblemValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue08.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtOverallValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue09.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtOtherValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEEValue10.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Dim bFlagFocus As Boolean = False
    Private Sub txtEducationValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue01.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue01.Text = Format(CDbl(txtEEValue01.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue01.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtExperienceValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue02.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue02.Text = Format(CDbl(txtEEValue02.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue02.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtAppearanceValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue03.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue03.Text = Format(CDbl(txtEEValue03.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue03.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtAttituteValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue04.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue04.Text = Format(CDbl(txtEEValue04.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue04.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtIntellectualValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue05.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue05.Text = Format(CDbl(txtEEValue05.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue05.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtCommunicationValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue06.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue06.Text = Format(CDbl(txtEEValue06.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue06.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtImpressionValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue07.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue07.Text = Format(CDbl(txtEEValue07.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue07.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtProblemValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue08.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue08.Text = Format(CDbl(txtEEValue08.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue08.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtOverallValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue09.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue09.Text = Format(CDbl(txtEEValue09.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue09.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    Private Sub txtOtherValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEEValue10.LostFocus
        If bFlagFocus Then
            bFlagFocus = False
        Else
            Try
                txtEEValue10.Text = Format(CDbl(txtEEValue10.Text), D25Format.DefaultNumber2)
            Catch ex As Exception
                bFlagFocus = True
                txtEEValue10.Focus()
                D99C0008.Msg(rl3("Gia_tri_nhap_khong_hop_le"))
            End Try
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3033
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 03/09/2013 01:27:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3033() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat trang thai cho ke hoach tuyen dung" & vbCrlf)
        sSQL &= "Exec D25P3033 "
        sSQL &= SQLString(_recruitmentFileID) & COMMA 'RecruitmentFileID, varchar[50], NOT NULL
        sSQL &= SQLString(_interviewLevelID) 'InterviewLevel, varchar[10], NOT NULL
        Return sSQL
    End Function
End Class