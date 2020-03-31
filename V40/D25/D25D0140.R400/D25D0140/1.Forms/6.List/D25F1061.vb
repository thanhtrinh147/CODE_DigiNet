Public Class D25F1061
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim bUnicode As Boolean = gbUnicode

    Private _sTransactionID As String
    Public Property sTransactionID() As String
        Get
            Return _sTransactionID
        End Get
        Set(ByVal value As String)
            If _sTransactionID = value Then
                Return
            End If
            _sTransactionID = value
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
                    LoadAddNew()
                    chkDisabled.Visible = False

                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    ReadOnlyControl(txtTransactionID)

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    ReadOnlyControl(txtTransactionID)

            End Select
        End Set
    End Property

    Private Sub D25F1061_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then UseEnterAsTab(Me)
    End Sub

    Private Sub D25F1061_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        '*****
        InputbyUnicode(Me, bUnicode)
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtTransactionID)
        '***************
        
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_loai_nghiep_vu_-_D25F1061") & UnicodeCaption(bUnicode) 'CËp nhËt loÁi nghiÖp vó - D25F1061
        '================================================================ 
        lblTransactionID.Text = rl3("Ma") 'Mã
        lblTransactionName.Text = rl3("Ten") 'Tên
        lblCreatorID.Text = rl3("Nguoi_lap") 'Người lập
        lblApproverID.Text = rl3("Nguoi_duyet") 'Người duyệt
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optProposalRecruitment.Text = rl3("Lap_de_xuat_tuyen_dung") 'Lập đề xuất tuyển dụng
        optPlanningRecruitment.Text = rl3("Lap_ke_hoach_tuyen_dung") 'Lập kế hoạch tuyển dụng
        '================================================================ 
        tdbcCreatorID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcCreatorID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcApproverID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcApproverID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("Code").Caption = rl3("Ma")
        tdbcVoucherTypeID.Columns("Description").Caption = rl3("Dien_giai")
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcCreatorID
        'Load tdbcApproverID
        sSQL = "Select EmployeeID, " & vbCrLf
        If bUnicode = False Then
            sSQL &= "Isnull(LastName,'') +' '+Isnull(MiddleName,'') +' '+Isnull(FirstName,'') As EmployeeName " & vbCrLf
        Else
            sSQL &= "Isnull(LastNameU,'') +' '+Isnull(MiddleNameU,'') +' '+Isnull(FirstNameU,'') As EmployeeName " & vbCrLf
        End If
        sSQL &= "From D09T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(gsDivisionID) & " And Disabled = 0" & vbCrLf
        sSQL &= "Order by DivisionID, DepartmentID, TeamID, EmployeeID"
        LoadDataSource(tdbcCreatorID, sSQL, bUnicode)
        LoadDataSource(tdbcApproverID, sSQL, bUnicode)

        'Load tdbcVoucherTypeID
        sSQL = "Select VoucherTypeID as Code," & IIf(bUnicode = False, "VoucherTypeName", "VoucherTypeNameU").ToString & " as Description, "
        sSQL &= "Auto, S1Type, S1, S2Type, S2, S3Type, S3, OutputOrder, OutputLength, Separator " & vbCrLf
        sSQL &= "From D91T0001 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "Where Disabled=0 and UseD25=1 " & vbCrLf
        sSQL &= "Order by VoucherTypeID "
        LoadDataSource(tdbcVoucherTypeID, sSQL, bUnicode)
    End Sub

    Private Sub LoadAddNew()
        txtTransactionID.Focus()
        optProposalRecruitment.Checked = True
        btnNext.Enabled = False
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "Select D60.* From D25T1060 D60 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where TransactionID = " & SQLString(sTransactionID.ToString)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        txtTransactionID.Text = dt.Rows(0).Item("TransactionID").ToString
        txtTransactionName.Text = dt.Rows(0).Item("TransactionName" & UnicodeJoin(bUnicode)).ToString
        chkDisabled.Checked = CBool(dt.Rows(0).Item("Disabled"))
        If dt.Rows(0).Item("Mode").ToString = "1" Then
            optProposalRecruitment.Checked = True
        ElseIf dt.Rows(0).Item("Mode").ToString = "2" Then
            optPlanningRecruitment.Checked = True
        End If
        tdbcCreatorID.SelectedValue = dt.Rows(0).Item("CreatorID").ToString
        tdbcApproverID.SelectedValue = dt.Rows(0).Item("ApproverID").ToString
        tdbcVoucherTypeID.SelectedValue = dt.Rows(0).Item("VoucherTypeID").ToString
        txtDescription.Text = dt.Rows(0).Item("Description" & UnicodeJoin(bUnicode)).ToString
    End Sub

    Private Sub SetBackColorObligatory()
        txtTransactionID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransactionName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCreatorID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcApproverID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then tdbcVoucherTypeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcApproverID"

    Private Sub tdbcApproverID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcApproverID.LostFocus
        If tdbcApproverID.FindStringExact(tdbcApproverID.Text) = -1 Then tdbcApproverID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCreatorID"

    Private Sub tdbcCreatorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
        If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then tdbcCreatorID.Text = ""
    End Sub


    'Private Sub tdbcXXX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown, tdbcCreatorID.KeyDown, tdbcApproverID.KeyDown
    '    If bUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False
    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Leave, tdbcCreatorID.Leave, tdbcApproverID.Leave
    '    If bUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close, tdbcCreatorID.Close, tdbcApproverID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Validated, tdbcCreatorID.Validated, tdbcApproverID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T1060)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1060)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            sTransactionID = txtTransactionID.Text
            SaveOK()
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
        txtTransactionID.Text = ""
        txtTransactionName.Text = ""
        tdbcVoucherTypeID.SelectedValue = ""
        txtDescription.Text = ""
        chkDisabled.Checked = False
        optProposalRecruitment.Checked = True
        tdbcApproverID.Text = ""
        tdbcCreatorID.Text = ""
        btnSave.Enabled = True
        btnNext.Enabled = False
        txtTransactionID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtTransactionID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtTransactionID.Focus()
            Return False
        End If
        If txtTransactionName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtTransactionName.Focus()
            Return False
        End If

        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If

        If tdbcCreatorID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_lap"))
            tdbcCreatorID.Focus()
            Return False
        End If
        If tdbcApproverID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_duyet"))
            tdbcApproverID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1060", "TransactionID", txtTransactionID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTransactionID.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1060
    '# Created User: 
    '# Created Date: 30/01/2008 03:50:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T1060(")
        sSQL.Append("TransactionID, TransactionName, TransactionNameU, CreatorID, ApproverID, Mode, ")
        sSQL.Append("Disabled, VoucherTypeID, Description, DescriptionU, CreateDate, CreateUserID, LastModifyDate, LastModifyUserID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtTransactionID.Text) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransactionName.Text, gbUnicode, False) & COMMA) 'TransactionName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransactionName.Text, gbUnicode, True) & COMMA) 'TransactionNameU, varchar[250], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcApproverID)) & COMMA) 'ApproverID, varchar[20], NOT NULL
        If optProposalRecruitment.Checked Then
            sSQL.Append(SQLNumber(1) & COMMA) 'Mode, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(2) & COMMA) 'Mode, tinyint, NOT NULL
        End If

        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL

        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcVoucherTypeID)) & COMMA)
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'DescriptionU, varchar[250], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID)) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1060
    '# Created User: 
    '# Created Date: 30/01/2008 04:05:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1060 Set ")
        sSQL.Append("TransactionName = " & SQLStringUnicode(txtTransactionName.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("TransactionNameU = " & SQLStringUnicode(txtTransactionName.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("CreatorID = " & SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ApproverID = " & SQLString(ReturnValueC1Combo(tdbcApproverID)) & COMMA) 'varchar[20], NOT NULL
        If optProposalRecruitment.Checked Then
            sSQL.Append("Mode = " & SQLNumber(1) & COMMA) 'tinyint, NOT NULL
        Else
            sSQL.Append("Mode = " & SQLNumber(2) & COMMA) 'tinyint, NOT NULL
        End If
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("VoucherTypeID = " & SQLString(ReturnValueC1Combo(tdbcVoucherTypeID)) & COMMA)
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA)
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA)
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransactionID = " & SQLString(sTransactionID.ToString))

        Return sSQL
    End Function

End Class

