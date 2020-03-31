Imports System

'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:37:46 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:37:46 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F2051
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _salCalMethodID As String
    Private _description As String


    Public Property SalCalMethodID() As String
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal value As String)
            If SalCalMethodID = value Then
                _salCalMethodID = ""
                Return
            End If
            _salCalMethodID = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If Description = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private _divisionID As String
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
        End Set
    End Property

    Private _byStatus As Byte = 0
    Public WriteOnly Property byStatus() As Byte 
        Set(ByVal Value As Byte )
            _byStatus = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            LoadTDBCombo()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnDetail.Enabled = False
                    btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
                    btnNext.Enabled = False
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
                    btnNext.Visible = False
                    btnDetail.Left = btnSave.Left
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnNext.Visible = False
                    btnDetail.Left = btnSave.Left
                    btnSave.Left = btnNext.Left
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub LoadTDBCombo()
        'Load tdbcDivisionID
        ' update 31/7/2013 id 58590 - 	Đổi bảng lấy đơn vị D09T9999, đang là D13T9999
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", , gbUnicode)
        ' LoadCboDivisionIDD09(tdbcDivisionID, "D13", , gbUnicode)
    End Sub

    Private Sub LoadAdd()
        txtSalCalMethodID.Text = ""
        chkDisabled.Visible = False
        txtDescription.Text = ""
        tdbcDivisionID.SelectedValue = gsDivisionID
    End Sub
    Private Sub LoadEdit()
        ReadOnlyControl(txtSalCalMethodID)
        chkDisabled.Visible = True
        txtDescription.Focus()
        If _byStatus = 1 Then ' update 18/10/2012 id 51871
            ReadOnlyControl(tdbcDivisionID)
            btnDetail.Enabled = False
        End If
        LoadMaster()
    End Sub

    Private Sub SetBackColorObligatory()
        txtSalCalMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= "Select SalCalMethodID, Description, DescriptionU, Disabled, IsLemonWeb From D13T2500  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(_salCalMethodID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            txtSalCalMethodID.Text = dt.Rows(i).Item("SalCalMethodID").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(i).Item("Disabled"))
            txtDescription.Text = dt.Rows(i).Item("Description" & UnicodeJoin(gbUnicode)).ToString
            chkIsLemonWeb.Checked = L3Bool(dt.Rows(i).Item("IsLemonWeb"))
        Next

        tdbcDivisionID.SelectedValue = _divisionID
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D13F2051_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        CheckIdTextBox(txtSalCalMethodID)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_phuong_phap_tinh_luong_-_D13F2051") & UnicodeCaption(gbUnicode) 'CËp nhËt ph§¥ng phÀp tÛnh l§¥ng - D13F2051
        '================================================================ 
        lblSalCalMethodID.Text = rl3("Ma") 'Mã
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblDivisionID.Text = rl3("Don_vi")
        '================================================================ 
        btnDetail.Text = rl3("_Chi_tiet") '&Chi tiết
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rL3("Khong_su_dung") 'Không sử dụng
        chkIsLemonWeb.Text = rL3("Xem_tren_LemonWeb") 'Xem trên LemonWeb
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD13T2500()
                sSQL &= SQLStoreD13P2500()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD13T2500()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _salCalMethodID = txtSalCalMethodID.Text
            _description = txtDescription.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    'If CheckAudit("SalaryCalMethod") Then
                    '    sSQL = SQLStoreD91P9106("SalaryCalMethod", "13", "01", txtSalCalMethodID.Text, txtDescription.Text, "", "", "")
                    '    ExecuteSQLNoTransaction(sSQL)
                    'End If
                    btnDetail.Enabled = True
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'If CheckAudit("SalaryCalMethod") Then
                    '    sSQL = SQLStoreD91P9106("SalaryCalMethod", "13", "02", txtSalCalMethodID.Text, txtDescription.Text, "", "", "")
                    '    ExecuteSQLNoTransaction(sSQL)
                    'End If

                    Lemon3.D91.RunAuditLog("13", "SalaryCalMethod", "02", txtSalCalMethodID.Text, txtDescription.Text, "", "", "")
                    btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
            btnClose.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If txtSalCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_so"))
            txtSalCalMethodID.Focus()
            Return False
        End If
        If txtSalCalMethodID.Text <> "" Then
            If txtSalCalMethodID.Text.Trim.Length > 20 Then
                D99C0008.MsgL3(rl3("Do_dai_Ma_so_khong_duoc_vuot_qua_20_ky_tu"))
                txtSalCalMethodID.Focus()
                Return False
            End If
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey() = False Then
                D99C0008.MsgDuplicatePKey()
                txtSalCalMethodID.Focus()
                Return False
            End If
        End If
        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If
        'If txtDescription.Text <> "" Then
        '    If txtDescription.Text.Trim.Length > 50 Then
        '        D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_vuot_qua_50_ky_tu"))
        '        txtDescription.Focus()
        '        Return False
        '    End If
        'End If

        Return True
    End Function

    Private Function IsExistKey() As Boolean
        Dim sSQL As String = ""
        sSQL = "Select SalCalMethodID From D13T2500  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(txtSalCalMethodID.Text)
        Dim sRet As String = ReturnScalar(sSQL)
        If sRet <> "" Then
            Return False
        End If
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:19:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2500 "
        sSQL &= SQLString(txtSalCalMethodID.Text) 'SalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:20:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2500() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T2500("
        sSQL &= "SalCalMethodID, Description, DescriptionU, Disabled, CreateUserID, LastModifyUserID, "
        sSQL &= "CreateDate, LastModifyDate, DivisionID, IsLemonWeb"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtSalCalMethodID.Text) & COMMA 'SalCalMethodID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, False) & COMMA 'Description, varchar[150], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, True) & COMMA 'Description, varchar[150], NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID).ToString) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsLemonWeb.Checked) 'Disabled, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:30:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2500() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T2500 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsLemonWeb = " & SQLNumber(chkIsLemonWeb.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID).ToString) 'DivisionID, varchar[20], NOT NULL
        sSQL &= " Where "
        sSQL &= "SalCalMethodID = " & SQLString(_salCalMethodID)
        Return sSQL
    End Function

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        ' Bỏ theo Thiên Nghĩa , incident 50479 tài liệu form D13F2052
        '  Dim EnableSave As Boolean
        '        Dim sSQL As String = ""
        '        sSQL = "Select TOP 1 1 FROM D13T2600 WHERE SalCalMethodID = " & SQLString(_salCalMethodID) & " And Calculated = 1"
        '        If _FormState <> EnumFormState.FormView And ExistRecord(sSQL) Then
        '            D99C0008.MsgL3(rl3("Phuong_phap_tinh_luong_nay_da_duoc_su_dung") & vbCrLf & rl3("Ban_khong_duoc_phep_suaU"))
        '            EnableSave = False
        '        Else
        '            EnableSave = True
        '        End If

        Dim f As New D13F2052
        With f
            '   .EnableSave = EnableSave
            .DivisionName = tdbcDivisionID.Text
            .SalCalMethodID = _salCalMethodID
            .DescriptionID = _description
            .FormState = _FormState
            'If _FormState = EnumFormState.FormAdd Then
            '    .FormState = EnumFormState.FormAdd
            'ElseIf _FormState = EnumFormState.FormEdit Then
            '    .FormState = EnumFormState.FormEdit
            'ElseIf _FormState = EnumFormState.FormView Then
            '    .FormState = EnumFormState.FormView
            'End If
            Me.Close()
            .ShowDialog()
            .Dispose()
        End With

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        txtSalCalMethodID.Focus()
        btnDetail.Enabled = false
        btnNext.Enabled = False
        btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
    End Sub

    Private Sub txtSalCalMethodID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCalMethodID.KeyPress
        'CheckIdTextBox(txtSalCalMethodID)
    End Sub

#Region "tdbcDivision Event update 5/9/2012 incident 20479"

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region

End Class