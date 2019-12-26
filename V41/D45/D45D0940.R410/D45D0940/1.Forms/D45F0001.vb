'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 1:35:52 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 25/07/2006 1:35:52 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D45F0001
    Private bFormClosed As Boolean = False ' Cờ xem form đó đóng = nút X của form không

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
        LoadPeriodNumberAndDefaultPeriod()
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

#End Region

    '    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    '    Public WriteOnly Property FormState() As EnumFormState
    '        Set(ByVal value As EnumFormState)
    '	bLoadFormState = True
    '	LoadInfoGeneral()
    '            _FormState = value
    '        End Set
    '    End Property

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        'LoadDataSource(tdbcDivisionID, sSQL)
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        bFormClosed = True
        If _FormState = EnumFormState.FormAdd Then 'End
        End If
        Me.Close()
    End Sub

    Private Sub D45F0001_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _FormState = EnumFormState.FormAdd And Not bFormClosed Then 'End
        End If
    End Sub

    Private Sub D45F0001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tabSystem.SelectedTab = TabPageMainInfo
            tdbcDivisionID.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tabSystem.SelectedTab = TabPage1
            chkIsQC.Focus()
        End If
    End Sub

    Private Sub D45F0001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If bLoadFormState = False Then FormState = _formState
        If ExistRecord("Select Top 1 1 From D45T0000 WITH(NOLOCK)") Then 'Chưa có dữ liệu ở bảng T0000     
            _FormState = EnumFormState.FormEdit
        Else
            _FormState = EnumFormState.FormAdd
        End If
        LoadInfoGeneral()

        SetBackColorObligatory()
        LoadTDBCombo()
        LoadEdit()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadPeriodNumberAndDefaultPeriod()
        btnSave.Enabled = ReturnPermission("D45F0001") > EnumPermission.View
        SetResolutionForm(Me)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_he_thong_-_D45F0001") & UnicodeCaption(gbUnicode) 'ThiÕt lËp hÖ thçng - D45F0001
        '================================================================ 
        lblDefaultPeriod.Text = rl3("Ky_mac_dinh")  'Kỳ mặc định
        lblNumberPeriod.Text = rl3("So_ky_ke_toan") 'Số kỳ kế toán
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        lblDefaultDivision.Text = rl3("Don_vi_mac_dinh") 'Đơn vị mặc định
        chkIsQC.Text = rl3("Chi_hien_thi_nhung_phieu_ket_qua_SX_sau_khi_da_kiem_tra_chat_luong") 'Chỉ hiển thị những phiếu kết quả SX sau khi đã kiểm tra chất lượng
        chkIsOQuantity.Text = rl3("Chi_ke_thua_so_luong_dat") 'Chỉ kế thừa số lượng đạt
        chkIsWorkingHour.Text = rl3("Cham_cong_san_pham_theo_so_gio_lam_viec") 'Chấm công sản phẩm theo số giờ làm việc
        '================================================================ 
        TabPageMainInfo.Text = "1. " & rl3("Thong_tin_chinh") '1. Thông tin chính
        TabPage1.Text = "2. " & rl3("Mac_dinh") 'Mặc định
        '================================================================ 
        grpInherite.Text = rl3("Ke_thua") 'Kế thừa
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten_don_vi") 'Tên đơn vị
    End Sub

    Private Sub LoadEdit()
        tdbcDivisionID.SelectedValue = D45Systems.DefaultDivisionID
        tdbcDivisionID.Tag = D45Systems.DefaultDivisionID
        chkIsWorkingHour.Checked = D45Systems.IsWorkingHour
        chkIsWorkingHour.Tag = D45Systems.IsWorkingHour
        'Tab Mặc định
        chkIsQC.Checked = D45Systems.IsQC
        chkIsQC.Tag = D45Systems.IsQC
        chkIsOQuantity.Checked = D45Systems.IsOQuantity
        chkIsOQuantity.Tag = D45Systems.IsOQuantity
    End Sub

    Private Sub LoadPeriodNumberAndDefaultPeriod()
        Dim sSQL As String = "Select PeriodNumber From D91T0025 WITH(NOLOCK) "
        txtPeriodNumber.Text = ReturnScalar(sSQL)


        sSQL = "Select Top 1 Replace(Str(TranMonth, 2), ' ', '0') + '/' + LTrim(Str(TranYear)) As DefaultPeriod From D09T9999 D45  WITH(NOLOCK) Where D45.DivisionID = " & SQLString(tdbcDivisionID.SelectedValue) & " Order By (TranYear * 100 + TranMonth) Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtDefaultPeriod.Text = dt.Rows(0).Item("DefaultPeriod").ToString
        End If
        dt.Dispose()
    End Sub

    Private Sub chkDivisionLocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If tdbcDivisionID.Text <> "" Then
        '    tdbcDivisionID.Enabled = Not chkDivisionLocked.Checked
        'Else
        '    If chkDivisionLocked.Checked Then chkDivisionLocked.Checked = False
        'End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sSQL As String = ""
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Select Case _FormState
            Case EnumFormState.FormAdd
                'Dữ liệu trong bảng D45T0000 chỉ có 1 dòng duy nhất
                'Nên trước khi Insert thì xóa dữ liệu rác
                sSQL = SQLDeleteD45T0000() & vbCrLf
                sSQL &= SQLInsertD45T0000()
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD45T0000()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            UpadateSystems()
            If _FormState = EnumFormState.FormEdit Then
                'If Convert.ToBoolean(chkDivisionLocked.Tag) <> chkDivisionLocked.Checked OrElse tdbcDivisionID.Tag.ToString <> tdbcDivisionID.SelectedValue.ToString Then
                If tdbcDivisionID.Tag.ToString <> tdbcDivisionID.SelectedValue.ToString Then
                    D99C0008.MsgSetUpDivision()
                Else
                    SaveOK()

                    ' If gbUseAudit Then
                    'RunAuditLog(AuditCodeSystemSetup, "02", tdbcDivisionID.Text, chkIsQC.Checked.ToString, chkIsOQuantity.Checked.ToString)
                    Lemon3.D91.RunAuditLog("45", AuditCodeSystemSetup, "02", tdbcDivisionID.Text, chkIsQC.Checked.ToString, chkIsOQuantity.Checked.ToString)
                    'End If
                End If
            Else
                SaveOK()
            End If
        Else
            SaveNotOK()
        End If

        bFormClosed = True
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetEnter(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub UpadateSystems()
        With D45Systems
            '            .LockedDivisionID = chkDivisionLocked.Checked
            .DefaultDivisionID = tdbcDivisionID.Text
            .IsQC = chkIsQC.Checked
            .IsOQuantity = chkIsOQuantity.Checked
            .IsWorkingHour = chkIsWorkingHour.Checked
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T0000
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 25/07/2006 01:50:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu xuống bảng D45T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T0000() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D45T0000(" 'DivisionLocked,
        sSQL &= "DivisionID, IsQC, IsOQuantity , IsWorkingHour, LastModifyUserID, LastModifyDate, CreateUserID, "
        sSQL &= "CreateDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(tdbcDivisionID.SelectedValue) & COMMA 'DivisionID, VarChar[20], NOT NULL
        'sSQL &= SQLNumber(chkDivisionLocked.Checked) & COMMA 'DivisionLocked, TinyInt, NOT NULL
        sSQL &= SQLNumber(chkIsQC.Checked) & COMMA 'IsQC, TinyInt, NOT NULL
        sSQL &= SQLNumber(chkIsOQuantity.Checked) & COMMA 'IsOQuantity, TinyInt, NOT NULL
        sSQL &= SQLNumber(chkIsWorkingHour.Checked) & COMMA 'IsWorkingHour, TinyInt, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, VarChar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, DateTime, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, VarChar[20], NOT NULL
        sSQL &= "GetDate()" 'CreateDate, DateTime, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T0000
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 25/07/2006 01:51:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Cập nhật lại bảng D45T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T0000() As String
        Dim sSQL As String = ""
        sSQL &= "Update D45T0000 Set "
        sSQL &= "DivisionID = " & SQLString(tdbcDivisionID.SelectedValue) & COMMA 'VarChar[20], NOT NULL
        ' sSQL &= "DivisionLocked = " & SQLNumber(chkDivisionLocked.Checked) & COMMA 'TinyInt, NOT NULL
        sSQL &= "IsQC = " & SQLNumber(chkIsQC.Checked) & COMMA 'TinyInt, NOT NULL
        sSQL &= "IsOQuantity = " & SQLNumber(chkIsOQuantity.Checked) & COMMA 'TinyInt, NOT NULL
        sSQL &= "IsWorkingHour = " & SQLNumber(chkIsWorkingHour.Checked) & COMMA 'TinyInt, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'VarChar[20], NOT NULL
        sSQL &= "LastModifyDate = GetDate()" 'DateTime, NOT NULL        
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T0000
    '# Create User: Nguyễn Thị Minh Hòa
    '# Create Date: 27/07/2006 09:49:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xóa bảng D45T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T0000() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T0000"
        Return sSQL
    End Function

End Class