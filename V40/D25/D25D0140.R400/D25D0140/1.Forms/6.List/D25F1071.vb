Imports System
Public Class D25F1071
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Private _interviewerID As String
    Public Property InterviewerID() As String
        Get
            Return _interviewerID
        End Get
        Set(ByVal Value As String)
            _interviewerID = Value
        End Set
    End Property

    Private _InterviewerName As String
    Public Property InterviewerName() As String
        Get
            Return _InterviewerName
        End Get
        Set(ByVal Value As String)
            _InterviewerName = Value
        End Set
    End Property

    Private _disabled As Boolean
    Public Property Disabled() As Boolean
        Get
            Return _disabled
        End Get
        Set(ByVal Value As Boolean)
            _disabled = Value
        End Set
    End Property

    Private _duty As String
    Public Property Duty() As String
        Get
            Return _duty
        End Get
        Set(ByVal Value As String)
            _duty = Value
        End Set
    End Property

    Private _contactPhone As String
    Public Property ContactPhone() As String
        Get
            Return _contactPhone
        End Get
        Set(ByVal Value As String)
            _contactPhone = Value
        End Set
    End Property

    Private _note As String
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(ByVal Value As String)
            _note = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    chkDisabled.Visible = False

                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    LoadEdit()
                    ReadOnlyControl(tdbcEmployeeID)
                    ReadOnlyControl(txtInterviewerID)

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
                    ReadOnlyControl(tdbcEmployeeID)
                    ReadOnlyControl(txtInterviewerID)

            End Select
        End Set
    End Property

    Private Sub D25F1071_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name = txtNote.Name Then Exit Sub
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F1071_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()

        Loadlanguage()
        '*****
        InputbyUnicode(Me, gbUnicode)
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtInterviewerID)
        '***************
        SetResolutionForm(Me)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nguoi_phong_van_-_D25F1071") & UnicodeCaption(gbUnicode) 'CËp nhËt ng§éi phàng vÊn - D25F1071
        '================================================================ 
        lblInfo.Text = rl3("Thong_tin_lien_he") 'Thông tin liên hệ
        lblInterviewerName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblContactPhone.Text = rl3("Dien_thoai") 'Điện thoại
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblInterviewerID.Text = rl3("Ma") 'Mã
        lblDutyID.Text = rl3("Chuc_vu") 'Chức vụ
        lblEmployeeID.Text = rl3("Nhan_vien_ke_thua") 'Nhân viên kế thừa
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcDutyID.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbcDutyID.Columns("DutyName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcEmployeeID
        sSQL = " Select EmployeeID, " & vbCrLf
        sSQL &= " isnull(LastName" & UnicodeJoin(gbUnicode) & ",'') +' '+isnull(MiddleName" & UnicodeJoin(gbUnicode) & ",'') +' '+isnull(FirstName" & UnicodeJoin(gbUnicode) & ",'') As EmployeeName, " & vbCrLf
        sSQL &= " DutyID, Telephone " & vbCrLf
        sSQL &= " From D09T0201 WITH(NOLOCK)  " & vbCrLf
        sSQL &= " Where Disabled=0"
        sSQL &= " Order by EmployeeID"
        LoadDataSource(tdbcEmployeeID, sSQL, gbUnicode)

        'Load tdbcDutyID
        sSQL = " Select DutyID, DutyName" & UnicodeJoin(gbUnicode) & " As DutyName" & vbCrLf
        sSQL &= " From D09T0211 WITH(NOLOCK)  " & vbCrLf
        sSQL &= " Where Disabled=0  Order by DutyID"
        LoadDataSource(tdbcDutyID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadEdit()
        txtInterviewerID.Text = _interviewerID
        txtInterviewerName.Text = _InterviewerName
        chkDisabled.Checked = _disabled
        tdbcDutyID.SelectedValue = _duty
        txtContactPhone.Text = _contactPhone
        txtNote.Text = _note

        btnNext.Visible = False
        btnSave.Left = btnNext.Left

    End Sub

    Private Sub SetBackColorObligatory()
        '  tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDutyID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtInterviewerID.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        If tdbcEmployeeID.SelectedValue Is Nothing Then
            txtInterviewerName.Text = ""
        Else
            If _FormState = EnumFormState.FormAdd Then
                txtInterviewerID.Text = tdbcEmployeeID.Columns("EmployeeID").Text
                txtInterviewerName.Text = tdbcEmployeeID.Columns("EmployeeName").Text
                tdbcDutyID.SelectedValue = tdbcEmployeeID.Columns("DutyID").Text
                txtContactPhone.Text = tdbcEmployeeID.Columns("Telephone").Text
            End If
        End If
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            ' txtInterviewerName.Text = ""
        End If
    End Sub

    'Private Sub tdbcEmployeeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDutyID.KeyDown, tdbcEmployeeID.KeyDown
    '    If bUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False
    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcEmployeeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Leave, tdbcEmployeeID.Leave
    '    If bUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Close, tdbcEmployeeID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#End Region

#Region "Events tdbcDutyID"

    Private Sub tdbcDutyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyID.LostFocus
        If tdbcDutyID.FindStringExact(tdbcDutyID.Text) = -1 Then
            tdbcDutyID.Text = ""
        End If
    End Sub
#End Region

    Private Sub txtContactPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPhone.KeyPress
        If e.KeyChar = Chr(22) Or e.KeyChar = Chr(3) Then Exit Sub 'cho phép dùng Ctr v, Ctr C

        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789-().")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T1070)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1070)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            InterviewerID = txtInterviewerID.Text
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            _bSaved = False
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'tdbcEmployeeID.Text = ""
        'txtInterviewerID.Text = ""
        'txtInterviewerName.Text = ""
        'tdbcDutyID.Text = ""
        'txtContactPhone.Text = ""
        'txtNote.Text = ""
        ClearText(Me)
        chkDisabled.Checked = False

        btnSave.Enabled = True
        btnNext.Enabled = False
        tdbcEmployeeID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        'Bo ngay 8/1/2012 theo ID 53602
        'If tdbcEmployeeID.ReadOnly = False Then
        '    If tdbcEmployeeID.Text.Trim = "" Then
        '        D99C0008.MsgNotYetEnter(rl3("Nhan_vien_ke_thua"))
        '        tdbcEmployeeID.Focus()
        '        Return False
        '    End If
        'End If
        '*************************
        If txtInterviewerID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtInterviewerID.Focus()
            Return False
        End If
        If tdbcDutyID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Chuc_vu"))
            tdbcDutyID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1070", "InterviewerID", txtInterviewerID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtInterviewerID.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1070
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 08/10/2007 08:52:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu trường hợp thêm mới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T1070(")
        sSQL.Append("InterviewerID, InterviewerName, InterviewerNameU, Duty, ContactPhone, Note, NoteU, ")
        sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtInterviewerID.Text) & COMMA) 'InterviewerID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtInterviewerName.Text, gbUnicode, False) & COMMA) 'InterviewName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtInterviewerName.Text, gbUnicode, True) & COMMA) 'InterviewNameU, varchar[50], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDutyID)) & COMMA) 'Duty, varchar[50], NULL
        sSQL.Append(SQLString(txtContactPhone.Text) & COMMA) 'ContactPhone, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'NoteU, varchar[250], NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1070
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 08/10/2007 09:27:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu dữ liệu trường hợp sửa
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1070 Set ")
        sSQL.Append("InterviewerName = " & SQLStringUnicode(txtInterviewerName.Text, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("InterviewerNameU = " & SQLStringUnicode(txtInterviewerName.Text, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("Duty = " & SQLString(ReturnValueC1Combo(tdbcDutyID)) & COMMA) 'varchar[50], NULL
        sSQL.Append("ContactPhone = " & SQLString(txtContactPhone.Text) & COMMA) 'varchar[50], NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("InterviewerID = " & SQLString(txtInterviewerID.Text))

        Return sSQL
    End Function

End Class