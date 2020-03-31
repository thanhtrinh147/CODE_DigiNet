'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:43:33 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:43:33 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1041
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bUnicode As Boolean = gbUnicode

    Private _officialTitleID As String
    Public Property OfficialTitleID() As String
        Get
            Return _officialTitleID
        End Get
        Set(ByVal value As String)
            If OfficialTitleID = value Then
                _officialTitleID = ""
                Return
            End If
            _officialTitleID = value
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output01", value)
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
                    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
                    btnNext.Enabled = False
                    btnSave.Enabled = True
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    btnClose.Focus()
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D13F1041_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F1041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        SetBackColorObligatory()
        '*****
        InputbyUnicode(Me, bUnicode)
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtOfficialTitleID)
        '***************
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub SetBackColorObligatory()
        txtOfficialTitleID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtOfficialTitleName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtNumSalaryLevel.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = r("Cap_nhat_ngach_luong_cong_chuc_-_D13F1041") & UnicodeCaption(bUnicode) 'CËp nhËt ngÁch l§¥ng c¤ng ch÷c - D13F1041
        '================================================================ 
        lblOfficialTitleID.Text = r("Ma") 'Mã ngạch lương
        lblOfficialTitleName.Text = r("Dien_giai") 'Diễn giải
        lblNumSalaryLevel.Text = r("Bac_luong_toi_da") 'Bậc lương tối đa
        lblDutyID.Text = r("Chuc_vu")
        '================================================================ 
        btnSave.Text = r("_Luu") '&Lưu
        btnClose.Text = r("Do_ng") 'Đó&ng
        btnNext.Text = r("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = r("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optUseOfficialAll.Text = r("Tat_ca1") 'Tất cả
        optUseOfficial2.Text = r("Ngach_luong_2") 'Ngạch lương 2
        optUseOfficial1.Text = r("Ngach_luong_1") 'Ngạch lương 1
        '================================================================ 
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= "Select OfficialTitleID, OfficialTitleName, OfficialTitleNameU, NumSalaryLevel, Disabled, IsUseOfficial, DutyID From D09T0214 " & vbCrLf
        sSQL &= "Where OfficialTitleID = " & SQLString(_officialTitleID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            txtOfficialTitleID.Text = dt.Rows(i).Item("OfficialTitleID").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(i).Item("Disabled").ToString)
            txtOfficialTitleName.Text = dt.Rows(i).Item("OfficialTitleName" & UnicodeJoin(bUnicode)).ToString
            txtNumSalaryLevel.Text = dt.Rows(i).Item("NumSalaryLevel").ToString
            If dt.Rows(i).Item("IsUseOfficial").ToString = "1" Then
                optUseOfficial1.Checked = True
            ElseIf dt.Rows(i).Item("IsUseOfficial").ToString = "2" Then
                optUseOfficial2.Checked = True
            Else
                optUseOfficialAll.Checked = True
            End If
            tdbcDutyID.SelectedValue = dt.Rows(i).Item("DutyID").ToString
        Next
    End Sub

    Private Sub LoadAdd()
        txtOfficialTitleID.Text = ""
        chkDisabled.Visible = False
        txtOfficialTitleName.Text = ""
        txtNumSalaryLevel.Text = ""
        optUseOfficialAll.Checked = True
        tdbcDutyID.SelectedValue = ""
    End Sub

    Private Sub LoadEdit()
        txtOfficialTitleID.Enabled = False
        chkDisabled.Visible = True
        txtOfficialTitleName.Focus()
        LoadMaster()
    End Sub

    Private Sub LoadTDBCombo()
        LoadTDBCDutyID()
    End Sub

    Private Sub LoadTDBCDutyID()
        Dim sSQL As String = ""
        'Load tdbcDutyID
        sSQL = "-- Do nguon combo DutyID" & vbCrLf
        sSQL &= "SELECT '+' as DutyID, " & NewName & " as DutyName , 0 As DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 	DutyID, DutyName" & IIf(geLanguage = EnumLanguage.English, "01", "").ToString & UnicodeJoin(gbUnicode) & " as DutyName, 1 As DisplayOrder "
        sSQL &= "FROM D09T0211 "
        sSQL &= "WHERE Disabled = 0 "
        sSQL &= "ORDER BY DisplayOrder, DutyName"

        LoadDataSource(tdbcDutyID, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcDutyID"

    Private Sub tdbcDutyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyID.LostFocus
        If tdbcDutyID.FindStringExact(tdbcDutyID.Text) = -1 Then tdbcDutyID.Text = ""
    End Sub

    Private Sub tdbcDutyID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.SelectedValueChanged
       
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        If tdbc.Name = "tdbcDutyID" Then
            If ReturnValueC1Combo(tdbcDutyID).ToString = "+" Then
                If ReturnPermission("D09F0290") < EnumPermission.Add Then
                    D99C0008.MsgL3(r("Ban_khong_co_quyen_them_moi"))
                Else
                    Dim sKey As String = ""
                    Dim f As New DxxMxx40
                    With f
                        .exeName = "D09E0140" 'Exe cần gọi
                        .FormActive = "D09F0291" 'Form cần hiển thị
                        .FormPermission = "D09F0290" 'Mã màn hình phân quyền
                        .OutputName = New String() {"SavedOK", "Output01"} 'Giá trị trả về
                        .ShowDialog()
                        Dim output() As String = .OutputXX()
                        .Dispose()
                        If L3Bool(output(0)) Then
                            LoadTDBCDutyID()
                            tdbcDutyID.SelectedValue = output(1)
                        Else
                            tdbcDutyID.SelectedValue = ""
                        End If
                    End With
                End If
                tdbcDutyID.Focus()
            End If
        End If
    End Sub


    Private Sub txtNumSalaryLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSalaryLevel.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        txtOfficialTitleID.Focus()
        btnNext.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD09T0214()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD09T0214()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _officialTitleID = txtOfficialTitleID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "True")
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtOfficialTitleID.Text
                    Dim sDesc2 As String = txtOfficialTitleName.Text
                    Dim sDesc3 As String = txtNumSalaryLevel.Text
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeSalaryGrades, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

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

    Private Function AllowSave() As Boolean
        If txtOfficialTitleID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(r("Ma_ngach_luong"))
            txtOfficialTitleID.Focus()
            Return False
        End If
        'If txtOfficialTitleID.Text.Trim <> "" And txtOfficialTitleID.Text.Trim.Length > 20 Then
        '    D99C0008.MsgL3(r("Do_dai_Ma_ngach_luong_khong_duoc_vuot_qua_20_ky_tu__"))
        '    txtOfficialTitleID.Focus()
        '    Return False
        'End If
        If txtOfficialTitleName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(r("Ten_ngach_luong"))
            txtOfficialTitleName.Focus()
            Return False
        End If
        'If txtOfficialTitleName.Text.Trim <> "" And txtOfficialTitleName.Text.Trim.Length > 50 Then
        '    D99C0008.MsgL3(r("Do_dai_Ten_ngach_luong_khong_duoc_vuot_qua_50_ky_tu__"))
        '    txtOfficialTitleID.Focus()
        '    Return False
        'End If
        If txtNumSalaryLevel.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(r("Bac_luong_toi_da"))
            txtNumSalaryLevel.Focus()
            Return False
        End If
        If txtNumSalaryLevel.Text.Trim <> "" Then
            If CInt(txtNumSalaryLevel.Text.Trim) = 0 Then
                D99C0008.MsgL3(r("Bac_luong_phai__0_"))
                txtNumSalaryLevel.Focus()
                Return False
            End If
            If CInt(txtNumSalaryLevel.Text) <> 0 And CInt(txtNumSalaryLevel.Text) >= 100 Then
                D99C0008.MsgL3(r("Bac_luong_toi_da_phai__100_"))
                txtNumSalaryLevel.Focus()
                Return False
            End If
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D09T0214", "OfficialTitleID", txtOfficialTitleID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtOfficialTitleID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0214
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 08:34:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0214() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D09T0214("
        sSQL &= "OfficialTitleID, OfficialTitleName, OfficialTitleNameU, NumSalaryLevel, Disabled, IsUseOfficial, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate, DutyID "
        sSQL &= ") Values ("
        sSQL &= SQLString(txtOfficialTitleID.Text) & COMMA 'OfficialTitleID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtOfficialTitleName.Text, bUnicode, False) & COMMA 'OfficialTitleName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtOfficialTitleName.Text, bUnicode, True) & COMMA 'OfficialTitleNameU, varchar[50], NULL
        sSQL &= SQLNumber(txtNumSalaryLevel.Text) & COMMA 'NumSalaryLevel, tinyint, NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NOT NULL
        If optUseOfficial1.Checked Then
            sSQL &= SQLNumber(1) & COMMA 'IsUseOfficial, tinyint, NOT NULL
        ElseIf optUseOfficial2.Checked Then
            sSQL &= SQLNumber(2) & COMMA 'IsUseOfficial, tinyint, NOT NULL
        Else
            sSQL &= SQLNumber(0) & COMMA 'IsUseOfficial, tinyint, NOT NULL
        End If
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDutyID).ToString)
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0214
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 08:36:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0214() As String
        Dim sSQL As String = ""
        sSQL &= "Update D09T0214 Set "
        sSQL &= "OfficialTitleName = " & SQLStringUnicode(txtOfficialTitleName.Text, bUnicode, False) & COMMA 'varchar[50], NULL
        sSQL &= "OfficialTitleNameU = " & SQLStringUnicode(txtOfficialTitleName.Text, bUnicode, True) & COMMA 'varchar[50], NULL
        sSQL &= "NumSalaryLevel = " & SQLNumber(txtNumSalaryLevel.Text) & COMMA 'tinyint, NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NOT NULL
        If optUseOfficial1.Checked Then
            sSQL &= "IsUseOfficial = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        ElseIf optUseOfficial2.Checked Then
            sSQL &= "IsUseOfficial = " & SQLNumber(2) & COMMA 'tinyint, NOT NULL
        Else
            sSQL &= "IsUseOfficial = " & SQLNumber(0) & COMMA 'tinyint, NOT NULL
        End If
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "DutyID = " & SQLString(ReturnValueC1Combo(tdbcDutyID).ToString) 'varchar[20], NULL
        sSQL &= " Where "
        sSQL &= "OfficialTitleID = " & SQLString(_officialTitleID)
        Return sSQL
    End Function

    
End Class