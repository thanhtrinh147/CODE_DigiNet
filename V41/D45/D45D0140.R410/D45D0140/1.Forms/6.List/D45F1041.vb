Imports System
Public Class D45F1041
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim sEditVoucherTypeID As String = ""


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadAddNew()
                    LoadTDBCombo()
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _transTypeID As String = ""
    Public Property TransTypeID() As String
        Get
            Return _transTypeID
        End Get
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Private Sub D45F1041_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F1041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTransTypeID)
        Loadlanguage()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_loai_nghiep_vu_-_D45F1041") & UnicodeCaption(gbUnicode) 'CËp nhËt loÁi nghiÖp vó - D45F1041
        '================================================================ 
        lblTransTypeID.Text = rl3("Ma") 'Mã
        lblTransTypeName.Text = rl3("Ten") 'Diễn giải
        lblDAGroupID.Text = rl3("Nhom_truy_cap_du_lieu") 'Nhóm truy cập dữ liệu
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblNote.Text = rl3("Ghi_chu") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbcDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbcDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải

        '================================================================ 
        lblVoucher.Text = rL3("Chung_tu") 'Chứng từ
        lblMethod.Text = rL3("Phuong_phap_cham_cong") 'Phương pháp chấm công
        '================================================================ 
        chkIsSpec.Text = rL3("Cham_cong_theo_quy_cach") 'Chấm công theo quy cách
        '================================================================ 
        optMethod0.Text = rL3("Theo_nhan_vien_U") 'Theo nhân viên
        optMethod3.Text = rL3("Theo_nhom_nhan_vien") 'Theo nhóm nhân viên
        optMethod1.Text = rL3("Theo_phong_banto_nhom") 'Theo phòng ban/tổ nhóm
        optMethod2.Text = rL3("Theo_nhom_CCSP") 'Theo nhóm CCSP

    End Sub

    Private Sub SetBackColorObligatory()
        txtTransTypeID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransTypeName.BackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcDAGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


#Region "Events tdbcDAGroupID with txtDAGroupName"

    Private Sub tdbcDAGroupID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.SelectedValueChanged
        If tdbcDAGroupID.SelectedValue Is Nothing Then
            txtDAGroupName.Text = ""
        Else
            txtDAGroupName.Text = tdbcDAGroupID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcDAGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.LostFocus
        If tdbcDAGroupID.FindStringExact(tdbcDAGroupID.Text) = -1 Then
            tdbcDAGroupID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcVoucherTypeID with txtVoucherTypeName"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing Then
            txtVoucherTypeName.Text = ""
        Else
            txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, sEditVoucherTypeID, gbUnicode)

        'Load tdbcDAGroupID
        sSQL = "Select DAGroupID, DAGroupName" & UnicodeJoin(gbUnicode) & " as DAGroupName From LEMONSYS.DBO.D00T0080 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0	And DAGroupID In (Select 	DAGroupID From LEMONSYS.DBO.D00V0080 " & vbCrLf
        sSQL &= "Where 	UserID = " & SQLString(gsUserID) & " Or  " & SQLString(gsUserID) & " =  'LEMONADMIN') " & vbCrLf
        sSQL &= "Order by 	DAGroupID"
        LoadDataSource(tdbcDAGroupID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadAddNew()
        btnSave.Enabled = True
        btnNext.Enabled = False

        chkDisabled.Checked = False
        txtTransTypeID.Text = ""
        txtTransTypeName.Text = ""
        tdbcDAGroupID.Text = ""
        txtDAGroupName.Text = ""
        tdbcVoucherTypeID.Text = ""
        txtVoucherTypeName.Text = ""
        txtNote.Text = ""
    End Sub

    Private Sub LoadEdit()
        txtTransTypeID.Text = _transTypeID
        ReadOnlyControl(txtTransTypeID)
        Dim sSQL As String = ""
        sSQL &= " Select TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, VoucherTypeID, Note" & UnicodeJoin(gbUnicode) & " as Note, PreparerID, DAGroupID, Disabled,"
        sSQL &= " CreateUserID, CreateDate, LastModifyUserID, LastModifyDate,Method,IsSpec " & vbCrLf
        sSQL &= " From 	D45T1040 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	TransTypeID = " & SQLString(_transTypeID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            sEditVoucherTypeID = dt.Rows(0).Item("VoucherTypeID").ToString
            LoadTDBCombo()
            '---------------------------------------------------
            txtTransTypeName.Text = dt.Rows(0).Item("TransTypeName").ToString
            chkDisabled.Checked = L3Bool(dt.Rows(0).Item("Disabled"))
            tdbcDAGroupID.Text = dt.Rows(0).Item("DAGroupID").ToString
            tdbcVoucherTypeID.Text = dt.Rows(0).Item("VoucherTypeID").ToString
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            'ID 88673 08.09.2016
            chkIsSpec.Checked = L3Bool(dt.Rows(0).Item("IsSpec").ToString)
            If dt.Rows(0).Item("Method").ToString = "0" Then
                optMethod0.Checked = True
            ElseIf dt.Rows(0).Item("Method").ToString = "1" Then
                optMethod1.Checked = True
            ElseIf dt.Rows(0).Item("Method").ToString = "2" Then
                optMethod2.Checked = True
            Else
                optMethod3.Checked = True
            End If
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If D45Options.SaveLastRecent = False Then
            LoadAddNew()
        End If

        txtTransTypeID.Focus()
    End Sub

    Private Function AllowSave() As Boolean
        If txtTransTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtTransTypeID.Focus()
            Return False
        End If
        If txtTransTypeName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtTransTypeName.Focus()
            Return False
        End If
        'If tdbcDAGroupID.Text.Trim = "" Then
        '    D99C0008.MsgNotYetEnter(rl3("Nhom_truy_cap_du_lieu"))
        '    tdbcDAGroupID.Focus()
        '    Return False
        'End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1040", "TransTypeID", txtTransTypeID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTransTypeID.Focus()
                Return False
            End If
        End If
        Return True
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1040
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 24/03/2008 10:52:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1040() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1040(")
        sSQL.Append("TransTypeID, TransTypeName, TransTypeNameU, VoucherTypeID, Note, NoteU, ")
        sSQL.Append("DAGroupID, Disabled, CreateUserID, CreateDate, LastModifyUserID, ")
        sSQL.Append("LastModifyDate,Method,IsSpec ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName.Text, gbUnicode, False) & COMMA) 'TransTypeName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName.Text, gbUnicode, True) & COMMA) 'TransTypeName, varchar[150], NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLString(tdbcDAGroupID.Text) & COMMA) 'DAGroupID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        'ID 88673 08.09.2016
        If optMethod0.Checked Then
            sSQL.Append(SQLNumber(0) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod1.Checked Then
            sSQL.Append(SQLNumber(1) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod2.Checked Then
            sSQL.Append(SQLNumber(2) & COMMA) 'Method, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(3) & COMMA) 'Method, tinyint, NOT NULL
        End If
        sSQL.Append(SQLNumber(chkDisabled.Checked)) 'IsSpec, tinyint, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1040
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 24/03/2008 10:53:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1040() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1040 Set ")
        sSQL.Append("TransTypeName = " & SQLStringUnicode(txtTransTypeName.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("TransTypeNameU = " & SQLStringUnicode(txtTransTypeName.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("VoucherTypeID = " & SQLString(tdbcVoucherTypeID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("DAGroupID = " & SQLString(tdbcDAGroupID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        'ID 88673 08.09.2016
        If optMethod0.Checked Then
            sSQL.Append("Method =" & SQLNumber(0) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod1.Checked Then
            sSQL.Append("Method =" & SQLNumber(1) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod2.Checked Then
            sSQL.Append("Method =" & SQLNumber(2) & COMMA) 'Method, tinyint, NOT NULL
        Else
            sSQL.Append("Method =" & SQLNumber(3) & COMMA) 'Method, tinyint, NOT NULL
        End If
        sSQL.Append("IsSpec = " & SQLNumber(chkDisabled.Checked)) 'IsSpec, tinyint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransTypeID = " & SQLString(txtTransTypeID.Text))

        Return sSQL
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1040.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1040.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            _transTypeID = txtTransTypeID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'RunAuditLog(AuditCodeTransactionTypes, "02", txtTransTypeID.Text, txtTransTypeName.Text, tdbcDAGroupID.Text, txtDAGroupName.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodeTransactionTypes, "02", txtTransTypeID.Text, txtTransTypeName.Text, tdbcDAGroupID.Text, txtDAGroupName.Text)
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

End Class