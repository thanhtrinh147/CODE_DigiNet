Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:35:03 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:35:03 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1011
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()

            'Gan caption va sang/mo cac checkboc
            LoadCaptionUP()
            LoadCombo()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    chkDisabled.Visible = False
                    LoadDefaultCheckUP()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _StageID As String
    Public Property StageID() As String
        Get
            Return _StageID
        End Get
        Set(ByVal Value As String)
            If _StageID = Value Then
                _StageID = ""
                Return
            End If
            _StageID = Value
        End Set
    End Property

    Private Sub D45F1011_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F1011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStageID)
        btnInfo.Enabled = ReturnPermission("D45F1010") >= EnumPermission.View
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_cong_doan_-_D45F1011") & UnicodeCaption(gbUnicode) 'CËp nhËt c¤ng ¢ãan - D45F1011
        '================================================================ 
        lblStageID.Text = rl3("Ma_cong_doan") 'Mã công đoạn
        lblStageName.Text = rl3("Dien_giai") 'Diễn giải
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblOrderNo.Text = rl3("STT") 'STT
        lblDesc.Text = rl3("Dien_giai") 'Diễn giải
        lblUse.Text = rl3("Su_dung") 'Sử dụng
        lblDisplayOrder.Text = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnInfo.Text = rl3("Thong_tin__he_so") 'Thông tin &hệ số
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        grpUnitPrice.Text = rL3("Don_gia") 'Đơn giá
        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        lblProductionLineID.Text = rL3("Chuyen_san_xuat") 'Chuyền sản xuất
        '================================================================ 
        tdbcProductionLineID.Columns("ID").Caption = rL3("Ma") 'Mã
        tdbcProductionLineID.Columns("Name").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub LoadEdit()
        txtStageID.ReadOnly = True
        txtStageID.Enabled = False
        LoadMaster()
    End Sub


    Private Sub LoadCombo()
        'Load tdbcProductionLineID
        Dim sSQL As String = ""
        sSQL = "-- Do nguon combo Chuyen san xuat " & vbCrLf & _
                " SELECT       ID, Name " & vbCrLf & _
                " FROM        D45N5555 ('D45F1011', '84', '1') " & vbCrLf & _
                " ORDER BY   Name "
        LoadDataSource(tdbcProductionLineID, sSQL, gbUnicode)

        'Load tdbcDepartmentID
        LoadDataSource(tdbcDepartmentID, ReturnTableFilter(ReturnTableDepartmentID_D09P6868(gsDivisionID, Me.Name, 0), "DepartmentID <>'%'", True), gbUnicode)

        'Load tdbcTeamID
        LoadTeamID("-1")
    End Sub

    Private Sub LoadTeamID(ByVal sDepartmentID As String)
        Dim dtT As DataTable = ReturnTableTeamID_D09P6868(gsDivisionID, Me.Name, 0)
        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtT, "DepartmentID=" & SQLString(sDepartmentID), True), gbUnicode)
    End Sub
    Private Sub LoadMaster()

        Dim sSQL As String = ""
        sSQL &= "SELECT	DisplayOrder,StageID,StageName" & UnicodeJoin(gbUnicode) & " as StageName,	Note" & UnicodeJoin(gbUnicode) & " as Note,Disabled,CreateUserID,CreateDate,LastModifyUserID,LastModifyDate,UP01, UP02, UP03, UP04, UP05,DivisionID, DepartmentID,TeamID,ProductionLineID" & vbCrLf
        sSQL &= "From D45T1010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where StageID = '" & _StageID & "' "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtStageID.Text = dt.Rows(0).Item("StageID").ToString
            txtStageName.Text = dt.Rows(0).Item("StageName").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            txtDisplayOrder.Text = dt.Rows(0).Item("DisplayOrder").ToString
            chkUP01.Checked = Convert.ToBoolean(dt.Rows(0).Item("UP01"))
            chkUP02.Checked = Convert.ToBoolean(dt.Rows(0).Item("UP02"))
            chkUP03.Checked = Convert.ToBoolean(dt.Rows(0).Item("UP03"))
            chkUP04.Checked = Convert.ToBoolean(dt.Rows(0).Item("UP04"))
            chkUP05.Checked = Convert.ToBoolean(dt.Rows(0).Item("UP05"))
            tdbcDepartmentID.SelectedValue = dt.Rows(0).Item("DepartmentID").ToString
            tdbcTeamID.SelectedValue = dt.Rows(0).Item("TeamID").ToString
            tdbcProductionLineID.SelectedValue = dt.Rows(0).Item("ProductionLineID").ToString
        End If
    End Sub

    Private Sub SetBackColorObligatory()
        txtStageID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtStageName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _StageID = txtStageID.Text
        txtStageID.Text = ""
        txtStageName.Text = ""
        txtNote.Text = ""
        tdbcDepartmentID.Text = ""
        tdbcTeamID.Text = ""
        txtDisplayOrder.Text = ""
        chkDisabled.Visible = False
        btnSave.Enabled = True
        btnNext.Enabled = False
        'Gan gtri mac dinh cho cac checkBox
        LoadDefaultCheckUP
        txtStageID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_cong_doan"))
            txtStageID.Focus()
            Return False
        End If
        If txtStageID.Text.Length > 20 Then
            D99C0008.MsgL3(rl3("Ma_cong_doan_khong_duoc_vuot_qua_20_ky_tu"))
            txtStageID.Focus()
            Return False
        End If
        If txtStageName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtStageName.Focus()
            Return False
        End If
        If txtStageName.Text.Length > 150 Then
            D99C0008.MsgL3(rl3("Dien_giai_khong_duoc_vuot_qua_150_ky_tu"))
            txtStageName.Focus()
            Return False
        End If

        'ID 85718 24.03.2016

        'If tdbcDepartmentID.Text.Trim <> "" Then
        '    If tdbcTeamID.Text.Trim = "" Then
        '        D99C0008.MsgNotYetEnter(lblTeamID.Text)
        '        tdbcTeamID.Focus()
        '        Return False
        '    End If
        'End If

        If txtNote.Text.Trim <> "" Then
            If txtNote.Text.Length > 150 Then
                D99C0008.MsgL3(rL3("Ghi_chu_khong_duoc_vuot_qua_150_ky_tu"))
                txtNote.Focus()
                Return False
            End If
        End If
        If _FormState = EnumFormState.FormAdd Then
            Dim sSQL As String
            sSQL = "Select * From D45T1010  WITH(NOLOCK) Where StageID=" & SQLString(txtStageID.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgDuplicatePKey()
                txtStageID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        _StageID = txtStageID.Text

        Dim sSQL As New StringBuilder("")
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1010.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1010.ToString & vbCrLf)
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'If gbUseAudit Then
                    'RunAuditLog(AuditCodeStages, "02", txtStageID.Text, txtStageName.Text, txtNote.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodeStages, "02", txtStageID.Text, txtStageName.Text, txtNote.Text)
                    'End If
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/08/2009 10:50:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1010() As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D45T1010(")
        sSQL.Append("StageID, StageName, StageNameU, Note, NoteU, Disabled, CreateUserID, ")
        sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate, UP01, UP02, ")
        sSQL.Append("UP03, UP04, UP05, DisplayOrder,DivisionID, DepartmentID, TeamID,ProductionLineID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtStageID.Text) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStageName.Text, gbUnicode, False) & COMMA) 'StageName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStageName.Text, gbUnicode, True) & COMMA) 'StageName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLNumber(chkUP01.Checked) & COMMA) 'UP01, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkUP02.Checked) & COMMA) 'UP02, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkUP03.Checked) & COMMA) 'UP03, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkUP04.Checked) & COMMA) 'UP04, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkUP05.Checked) & COMMA) 'UP05, tinyint, NOT NULL
        sSQL.Append(SQLNumber(txtDisplayOrder.Text) & COMMA) 'DisplayOrder, int, NOT NULL
        If tdbcDepartmentID.Text = "" Then
            sSQL.Append(SQLString("") & COMMA) 'DivisionID, varchar[20], NOT NULL
        Else
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        End If
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcProductionLineID))) 'ProductionLineID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/04/2007 08:32:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1010 Set ")
        sSQL.Append("StageName = " & SQLStringUnicode(txtStageName.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("StageNameU = " & SQLStringUnicode(txtStageName.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("DisplayOrder = " & SQLNumber(txtDisplayOrder.Text) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("UP01 = " & SQLNumber(chkUP01.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("UP02 = " & SQLNumber(chkUP02.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("UP03 = " & SQLNumber(chkUP03.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("UP04 = " & SQLNumber(chkUP04.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("UP05 = " & SQLNumber(chkUP05.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        If tdbcDepartmentID.Text = "" Then
            sSQL.Append("DivisionID = " & SQLString("") & COMMA) 'DivisionID, NOT NULL
        Else
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & COMMA) 'DivisionID, NOT NULL
        End If
        sSQL.Append("DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentID, NOT NULL
        sSQL.Append("TeamID = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamID, NOT NULL
        sSQL.Append("ProductionLineID = " & SQLString(ReturnValueC1Combo(tdbcProductionLineID))) 'ProductionLineID, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("StageID = " & SQLString(_StageID))

        Return sSQL
    End Function

    Private Sub LoadCaptionUP()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " AS ShortName, Disabled" & vbCrLf
        sSQL &= "From D45T0010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Type='PRICE' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            lblUP01.Text = dt.Rows(0).Item("ShortName").ToString
            lblUP01.Font = FontUnicode(gbUnicode)

            lblUP02.Text = dt.Rows(1).Item("ShortName").ToString
            lblUP02.Font = FontUnicode(gbUnicode)

            lblUP03.Text = dt.Rows(2).Item("ShortName").ToString
            lblUP03.Font = FontUnicode(gbUnicode)

            lblUP04.Text = dt.Rows(3).Item("ShortName").ToString
            lblUP04.Font = FontUnicode(gbUnicode)

            lblUP05.Text = dt.Rows(4).Item("ShortName").ToString
            lblUP05.Font = FontUnicode(gbUnicode)

            chkUP01.Enabled = Not Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
            chkUP02.Enabled = Not Convert.ToBoolean(dt.Rows(1).Item("Disabled"))
            chkUP03.Enabled = Not Convert.ToBoolean(dt.Rows(2).Item("Disabled"))
            chkUP04.Enabled = Not Convert.ToBoolean(dt.Rows(3).Item("Disabled"))
            chkUP05.Enabled = Not Convert.ToBoolean(dt.Rows(4).Item("Disabled"))
        End If
    End Sub

    Private Sub LoadDefaultCheckUP()
        chkUP01.Checked = chkUP01.Enabled
        chkUP02.Checked = chkUP02.Enabled
        chkUP03.Checked = chkUP03.Enabled
        chkUP04.Checked = chkUP04.Enabled
        chkUP05.Checked = chkUP05.Enabled
    End Sub

    Private Sub txtDisplayOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayOrder.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtDisplayOrder_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisplayOrder.LostFocus
        If L3IsNumeric(txtDisplayOrder.Text, EnumDataType.Int) = False Then
            txtDisplayOrder.Text = ""
        End If
    End Sub

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        Me.Cursor = Cursors.WaitCursor
        'Dim frm As New D13F1110
        'With frm
        '    .Type = "D45T1010"
        '    .DutyID = _StageID
        '    .FormPermision = "D45F1010"
        '    .FormStatus = _FormState
        '    .ShowDialog()

        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "Type", "D45T1010")
        SetProperties(arrPro, "TypeID", "%")
        SetProperties(arrPro, "FormIDPermission", "D45F1010")
        SetProperties(arrPro, "FormState", _FormState)
        CallFormShow(Me, "D13D0140", "D13F1110", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

#Region "Events tdbcDepartmentID load tdbcTeamID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.SelectedValue Is Nothing OrElse tdbcDepartmentID.Text = "" Then
            LoadTeamID("-1")
            tdbcTeamID.Text = ""
            Exit Sub
        End If
        LoadTeamID(tdbcDepartmentID.SelectedValue.ToString())
        tdbcTeamID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcProductionLineID"

    Private Sub tdbcProductionLineID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductionLineID.LostFocus
        If tdbcProductionLineID.FindStringExact(tdbcProductionLineID.Text) = -1 Then tdbcProductionLineID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProductionLineID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProductionLineID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

End Class