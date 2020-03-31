Public Class D25F1011
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Public bFlagSave As Boolean = False
    Dim bUnicode As Boolean = gbUnicode

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    chkDisabled.Visible = False
                    LoadAddNew()

                Case EnumFormState.FormEdit
                    LoadEdit()
                    ReadOnlyControl(txtRecSourceID)

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
                    ReadOnlyControl(txtRecSourceID)

            End Select
        End Set
    End Property

    Dim _RecSourceID As String = ""
    Public Property RecSourceID() As String
        Get
            Return _RecSourceID
        End Get
        Set(ByVal Value As String)
            _RecSourceID = Value
        End Set
    End Property

    Private Sub D25F1011_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name = txtNote.Name Then Exit Sub
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D25F1011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        '*****
        InputbyUnicode(Me, bUnicode)
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtRecSourceID)
        ''***************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nguon_tuyen_dung_-_D25F1011") & UnicodeCaption(bUnicode) 'CËp nhËt nguän tuyÓn dóng - D25F1011
        '================================================================ 
        lblRecSourceID.Text = rl3("Ma") 'Mã
        lblRecSourceName.Text = rl3("Dien_giai") 'Diễn giải
        lblContactPerson.Text = rl3("Ho_va_ten") 'Họ và tên
        lblDuty.Text = rl3("Chuc_vu") 'Chức vụ
        lblContactPhone.Text = rl3("Dien_thoai") 'Điện thoại
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        grpContact.Text = rl3("Nguoi_lien_he") 'Người liên hệ
    End Sub

    Private Sub LoadAddNew()
        txtRecSourceID.Text = ""
        txtRecSourceName.Text = ""
        txtContactPerson.Text = ""
        txtContactPhone.Text = ""
        txtDuty.Text = ""
        txtNote.Text = ""
        chkDisabled.Checked = False
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "Select * From D25T1010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where RecSourceID = " & SQLString(_RecSourceID) & vbCrLf

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtRecSourceID.Text = dt.Rows(0).Item("RecSourceID").ToString
            txtRecSourceName.Text = dt.Rows(0).Item("RecSourceName" & UnicodeJoin(bUnicode)).ToString
            txtContactPerson.Text = dt.Rows(0).Item("ContactPerson" & UnicodeJoin(bUnicode)).ToString
            txtContactPhone.Text = dt.Rows(0).Item("ContactPhone").ToString
            txtDuty.Text = dt.Rows(0).Item("Duty" & UnicodeJoin(bUnicode)).ToString
            txtNote.Text = dt.Rows(0).Item("Note" & UnicodeJoin(bUnicode)).ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
        End If

        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        'txtRecSourceID.Enabled = False
    End Sub

    Private Sub SetBackColorObligatory()
        txtRecSourceID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRecSourceName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub txtContactPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPhone.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789()-")
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
                sSQL.Append(SQLInsertD25T1010())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1010())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _RecSourceID = txtRecSourceID.Text
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
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
        _RecSourceID = ""

        txtRecSourceID.Text = ""
        txtRecSourceName.Text = ""
        txtContactPerson.Text = ""
        txtContactPhone.Text = ""
        txtDuty.Text = ""
        txtNote.Text = ""
        chkDisabled.Checked = False

        btnSave.Enabled = True
        btnNext.Enabled = False
        txtRecSourceID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtRecSourceID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtRecSourceID.Focus()
            Return False
        End If
        If txtRecSourceName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtRecSourceName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1010", "RecSourceID", txtRecSourceID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtRecSourceID.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1010
    '# Created User: Lê Thị Lành
    '# Created Date: 05/10/2007 01:56:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T1010(")
        sSQL.Append("RecSourceID, RecSourceName, RecSourceNameU, ContactPerson, ContactPersonU, ")
        sSQL.Append("Duty, DutyU, ContactPhone, Note, NoteU, Disabled, CreateUserID, CreateDate, LastModifyUserID, ")
        sSQL.Append("LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtRecSourceID.Text) & COMMA) 'RecSourceID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRecSourceName, False) & COMMA) 'RecSourceName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtRecSourceName, True) & COMMA) 'RecSourceNameU, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtContactPerson, False) & COMMA) 'ContactPerson, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtContactPerson, True) & COMMA) 'ContactPersonU, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtDuty, False) & COMMA) 'Duty, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtDuty, True) & COMMA) 'DutyU, varchar[50], NULL
        sSQL.Append(SQLString(txtContactPhone.Text) & COMMA) 'ContactPhone, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'NoteU, varchar[250], NULL
        sSQL.Append(SQLNumber(IIf(chkDisabled.Checked, 1, 0)) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1010
    '# Created User: Lê Thị Lành
    '# Created Date: 05/10/2007 02:01:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1010 Set ")
        sSQL.Append("RecSourceName = " & SQLStringUnicode(txtRecSourceName, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("RecSourceNameU = " & SQLStringUnicode(txtRecSourceName, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ContactPerson = " & SQLStringUnicode(txtContactPerson, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ContactPersonU = " & SQLStringUnicode(txtContactPerson, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("Duty = " & SQLStringUnicode(txtDuty, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("DutyU = " & SQLStringUnicode(txtDuty, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ContactPhone = " & SQLString(txtContactPhone.Text) & COMMA) 'varchar[50], NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Disabled = " & SQLNumber(IIf(chkDisabled.Checked, 1, 0)) & COMMA) 'tinyint, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("RecSourceID = " & SQLString(txtRecSourceID.Text))

        Return sSQL
    End Function

End Class