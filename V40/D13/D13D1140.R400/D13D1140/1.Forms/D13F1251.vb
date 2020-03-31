Public Class D13F1251

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _refResultID As String = ""
    Public Property RefResultID() As String
        Set(ByVal Value As String)
            _refResultID = Value
        End Set
        Get
            Return _refResultID
        End Get
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            bLoadFormState = True
            LoadInfoGeneral()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    'btnNext.Enabled = False
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    'btnNext.Visible = False
                    'btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    'btnNext.Visible = False
                    'btnSave.Left = btnNext.Left
                    'btnSave.Enabled = False
            End Select
        End Set
    End Property
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAddNew()
    End Sub

    Private Sub EnableMenu(ByVal bEnabled As Boolean)
        btnSave.Enabled = bEnabled
        btnNext.Enabled = bEnabled
        'If _FormState = EnumFormState.FormAdd Then
        '    btnNext.Visible = True
        '    btnNext.Text = rL3("Luu_va_Nhap__tiep")
        'Else
        '    btnNext.Visible = False
        'End If
        'If btnNext.Visible And btnNext.Enabled Then
        '    btnSave.Left = btnNext.Left - btnSave.Width - 6
        'Else
        '    btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
        'End If
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_ma_tham_chieu_theo_thoi_gian") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc mº tham chiÕu theo théi gian
        '================================================================ 
        lblRefResultID.Text = rl3("Ma_tham_chieu") 'Mã tham chiếu
        lblRefResultName.Text = rl3("Ten_tham_chieu") 'Tên tham chiếu
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
    End Sub


    Private Sub D13F1251_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        CheckIdTextBox(txtRefResultID)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13F1251_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
            End Select
        End If
    End Sub

    Private Sub D13F1251_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormAdd AndAlso txtRefResultID.Text <> "" AndAlso Not _bSaved Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If txtRefResultID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblRefResultID.Text)
            txtRefResultID.Focus()
            Return False
        End If
        If txtRefResultName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblRefResultName.Text)
            txtRefResultName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If ExistRecord("SELECT 1 FROM 	D91T0320 WHERE	LookupID = " & SQLString(txtRefResultID.Text.Trim) & " AND LookupType = " & SQLString(D13_RefResult)) Then
                D99C0008.MsgDuplicatePKey()
                txtRefResultID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtRefResultID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRefResultName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
       
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD91T0320().ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD91T0320.ToString())
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _refResultID = txtRefResultID.Text
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Focus()
                    _FormState = EnumFormState.FormEdit
                Case EnumFormState.FormEdit
                 
            End Select
            btnNext.Enabled = True
            '  btnSave.Enabled = True
        Else
            SaveNotOK()
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub LoadAddNew()
        _FormState = EnumFormState.FormAdd
        txtRefResultID.Text = ""
        txtRefResultName.Text = ""
        chkDisabled.Visible = False
        chkDisabled.Checked = False
        btnSave.Enabled = True
        UnReadOnlyControl(True, txtRefResultID)
    End Sub

    Private Const D13_RefResult As String = "D13_RefResult"
    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "SELECT * FROM 	D91T0320 WHERE	LookupID = " & SQLString(_refResultID) & " AND LookupType = " & SQLString(D13_RefResult)
        Dim _dtTmp As DataTable = ReturnDataTable(sSQL)
        If _dtTmp IsNot Nothing AndAlso _dtTmp.Rows.Count > 0 Then
            txtRefResultID.Text = _refResultID
            txtRefResultName.Text = L3String(_dtTmp.Rows(0).Item("DescriptionU"))
            chkDisabled.Checked = L3Bool(_dtTmp.Rows(0).Item("Disabled"))
        End If
        ReadOnlyControl(txtRefResultID)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "SQL function"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T0320
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 02:52:10
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T0320() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert ma tham chieu" & vbCrLf)
        sSQL.Append("Insert Into D91T0320(")
        sSQL.Append("LookupType, LookupID, Description, DisplayOrder, Disabled, " & vbCrLf)
        sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, DAGroupID, " & vbCrLf)
        sSQL.Append("DescriptionU")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(D13_RefResult) & COMMA) 'LookupType [KEY], varchar[100], NOT NULL
        sSQL.Append(SQLString(txtRefResultID.Text) & COMMA) 'LookupID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRefResultName, False) & COMMA) 'Description, varchar[500], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'DisplayOrder, int, NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA & vbCrLf) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString("") & COMMA) 'DAGroupID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRefResultName, True)) 'DescriptionU, nvarchar[500], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD91T0320
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 02:55:13
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD91T0320() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Sua du lieu" & vbCrLf)
        sSQL.Append("Update D91T0320 Set ")
        sSQL.Append("Description = " & SQLStringUnicode(txtRefResultName, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtRefResultName, True)) 'nvarchar[500], NOT NULL
        sSQL.Append(" Where 	LookupID = " & SQLString(txtRefResultID.Text) & " AND LookupType = " & SQLString(D13_RefResult))
        Return sSQL
    End Function



#End Region


End Class