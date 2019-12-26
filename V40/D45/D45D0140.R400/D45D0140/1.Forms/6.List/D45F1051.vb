Imports System
Public Class D45F1051
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private dtDepartmentID, dtTeamID, dtEmployeeID As DataTable
    Dim dtGrid As DataTable 'Bảng chứa dữ liệu của lưới
    Dim dtTemp As DataTable 'Bảng chứa dữ liệu từ câu SQL
    Dim dtOrg As DataTable
    Dim bHeadClick As Boolean = False

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0        ' Chọn
    Private Const COL_BlockID As Integer = 1       ' Khối
    Private Const COL_DepartmentID As Integer = 2  ' Phòng ban
    Private Const COL_TeamID As Integer = 3        ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 4    ' Mã nhân viên
    Private Const COL_RefEmployeeID As Integer = 5 ' Mã NV phụ
    Private Const COL_EmployeeName As Integer = 6  ' Họ và tên
    Private Const COL_DutyName As Integer = 7      ' Chức vụ 
    Private Const COL_Sex As Integer = 8           ' Giới tính
#End Region

    Private _pieceworkGroupID As String
    Public Property PieceworkGroupID() As String
        Get
            Return _pieceworkGroupID
        End Get
        Set(ByVal Value As String)
            _pieceworkGroupID = Value
        End Set
    End Property

    Private _callModuleID As String = "D45"
    Public WriteOnly Property CallModuleID() As String
        Set(ByVal Value As String)
            _callModuleID = Value
        End Set
    End Property

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

    Private Sub D15F1101_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D15F1101_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D15F1101_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        ResetColorGrid(tdbg)

        Loadlanguage()

        tdbcNameAutoComplete()
        LoadDefault()

        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtPieceworkGroupID)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        LoadTDBCombo()
        '
        tdbcWorkingStatusID.SelectedValue = "%"
        tdbcBlockID.SelectedValue = "%"
        If D45Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = False
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Sex).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        txtPieceworkGroupID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPieceworkGroupName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nhom_nhan_vien_cham_cong_Danh_gia_-_D45F1051") & UnicodeCaption(gbUnicode) 'CËp nhËt nhâm nh¡n vi£n chÊm c¤ng/ ˜Ành giÀ - D45F1051
        If _callModuleID = "D39" Then Me.Text = Me.Text.Replace("D45F1051", "D39F1071")
        '================================================================ 
        lbltxtPieceworkGroupID.Text = rl3("Ma") 'Mã 
        lbltxtPieceworkGroupName.Text = rl3("Ten") 'Tên
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblGroupManager.Text = rl3("Truong_nhom") 'Trưởng nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeIDFrom.Text = rl3("Nhan_vien") 'Nhân viên
        lblGroupProductID.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnFilter.Text = rl3("Lo_c") 'Lọ&c
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkView.Text = rl3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        '================================================================ 
        grpList.Text = rl3("Danh_sach_nhan_vien") 'Danh sách nhân viên
        '================================================================ 
        tdbcGroupManager.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcGroupManager.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã 
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcGroupProductID.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ 
        tdbg.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
    End Sub

    Private Sub CreateData()
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtEmployeeID = ReturnTableEmployeeID(True, , gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        CreateData()

        'Load tdbcGroupManager
        LoadDataSource(tdbcGroupManager, dtEmployeeID.Copy, gbUnicode)

        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

        'Load tdbcGroupProductID
        sSQL = "Select D45.GroupProductID, D45.GroupProductName" & UnicodeJoin(gbUnicode) & " as GroupProductName" & vbCrLf
        sSQL &= "From D45T1070 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.Disabled=0" & vbCrLf
        sSQL &= "Order by D45.GroupProductID"
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadtdbcDepartmentID()
        Dim sBlockID As String
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If

        If sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID=" & SQLString(sBlockID) & " or DepartmentID = '%'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcTeamID()
        'Load tdbcTeamID
        Dim sBlockID, sDepartmentID As String
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If

        If tdbcDepartmentID.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentID.SelectedValue.ToString
        End If

        If sDepartmentID = "%" AndAlso sBlockID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
        ElseIf sBlockID = "%" AndAlso sDepartmentID <> "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & "or TeamID='%'", True), gbUnicode)
        ElseIf sBlockID <> "%" AndAlso sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "BlockID=" & SQLString(sBlockID) & "or TeamID='%'", True), gbUnicode)
        ElseIf sBlockID <> "%" AndAlso sDepartmentID <> "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or TeamID='%'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcEmployeeID()
        Dim sBlockID, sDepartmentID, sTeamID, sWorkingStatusID As String
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If

        If tdbcDepartmentID.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentID.SelectedValue.ToString
        End If

        If tdbcTeamID.SelectedValue Is Nothing Then
            sTeamID = ""
        Else
            sTeamID = tdbcTeamID.SelectedValue.ToString
        End If

        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            sWorkingStatusID = ""
        Else
            sWorkingStatusID = tdbcWorkingStatusID.SelectedValue.ToString
        End If

        'K loc theo Khoi
        If sBlockID = "%" Then
            If sWorkingStatusID = "%" Then
                If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, ""), gbUnicode)
                ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " or EmployeeID='%'", True), gbUnicode)
                Else
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'", True), gbUnicode)
                End If
            Else
                If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                Else
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                End If
            End If

        Else
            If sWorkingStatusID = "%" Then
                If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
                Else
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " or EmployeeID='%'", True), gbUnicode)
                End If
            Else
                If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                Else
                    LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID) & " And WorkingStatusID=" & SQLString(sWorkingStatusID) & " or EmployeeID='%'", True), gbUnicode)
                End If
            End If
        End If

    End Sub

    Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcWorkingStatusID.KeyDown, tdbcEmployeeID.KeyDown, tdbcGroupManager.KeyDown
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbc.AutoCompletion = False

            Case Else
                tdbc.AutoCompletion = True
        End Select
    End Sub

    Private Sub tdbcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcTeamID.Leave, tdbcDepartmentID.Leave, tdbcWorkingStatusID.Leave, tdbcEmployeeID.Leave, tdbcGroupManager.Leave
        '  If gbUnicode Then Exit Sub 
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

        If tdbcName.SelectedIndex <> -1 Then
            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        End If
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        txtPieceworkGroupID.Enabled = False
        LoadMaster()
        'Load luoi
        sSQL = SQLStoreD45P1051(txtPieceworkGroupID.Text, 0)
        dtTemp = ReturnDataTable(sSQL)
        dtOrg = dtTemp
        LoadTDBGrid()
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "Select PieceworkGroupID, PieceworkGroupName" & UnicodeJoin(gbUnicode) & " as PieceworkGroupName, Note" & UnicodeJoin(gbUnicode) & " as Note, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, GroupProductID, GroupManagerName" & UnicodeJoin(gbUnicode) & " as GroupManagerName From D45T1050 D50 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D50.PieceworkGroupID = " & SQLString(_pieceworkGroupID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtPieceworkGroupID.Text = dt.Rows(0).Item("PieceworkGroupID").ToString
            txtPieceworkGroupName.Text = dt.Rows(0).Item("PieceworkGroupName").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            tdbcGroupProductID.Text = dt.Rows(0).Item("GroupProductID").ToString
            tdbcGroupManager.Text = dt.Rows(0).Item("GroupManagerName").ToString
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAddNew()
        btnSave.Enabled = True
        btnNext.Enabled = False
        txtPieceworkGroupID.Focus()
    End Sub

    Private Sub LoadAddNew()
        txtPieceworkGroupID.Text = ""
        txtPieceworkGroupName.Text = ""
        chkDisabled.Checked = False
        txtNote.Text = ""
        tdbcGroupProductID.Text = ""

        tdbcWorkingStatusID.SelectedValue = "%"
        tdbcBlockID.SelectedValue = "%"

        'Xoá lưới
        dtGrid.Clear()
        'Load lai luoi
        Dim sSQL As String = SQLStoreD45P1051(txtPieceworkGroupID.Text, 0)
        dtTemp = ReturnDataTable(sSQL)
        dtOrg = dtTemp
        LoadTDBGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtPieceworkGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtPieceworkGroupID.Focus()
            Return False
        End If
        If txtPieceworkGroupName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtPieceworkGroupName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1050", "PieceworkGroupID", txtPieceworkGroupID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPieceworkGroupID.Focus()
                Return False
            End If
        End If

        '-------------------------------------------------
        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next

        If bFlag = False Then
            D99C0008.MsgNotYetChoose(rl3("du_lieu_tren_luoi"))
            tdbg.Focus()
            tdbg.Col = COL_IsUsed
            tdbg.SplitIndex = 0
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
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
                sSQL.Append(SQLInsertD45T1050.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1051s.ToString & vbCrLf)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1050.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1051.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1051s.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _pieceworkGroupID = txtPieceworkGroupID.Text
            _bSaved = True

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
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function SQLInsertD45T1050() As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D45T1050(")
        sSQL.Append("PieceworkGroupID, PieceworkGroupName, PieceworkGroupNameU, Note, NoteU, Disabled, GroupProductID, CreateUserID, ")
        sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate, GroupManagerName, GroupManagerNameU")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtPieceworkGroupID.Text) & COMMA) 'PieceworkGroupID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPieceworkGroupName.Text, gbUnicode, False) & COMMA) 'PieceworkGroupName, varchar[150], NULL
        sSQL.Append(SQLStringUnicode(txtPieceworkGroupName.Text, gbUnicode, True) & COMMA) 'PieceworkGroupName, varchar[150], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[250], NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(tdbcGroupProductID.Text) & COMMA) 'GroupProductID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(tdbcGroupManager.Text, gbUnicode, False) & COMMA) 'GroupManagerName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbcGroupManager.Text, gbUnicode, True)) 'GroupManagerName, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLUpdateD45T1050() As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Update D45T1050 Set ")
        sSQL.Append("PieceworkGroupName = " & SQLStringUnicode(txtPieceworkGroupName.Text, gbUnicode, False) & COMMA) 'varchar[150], NULL
        sSQL.Append("PieceworkGroupNameU = " & SQLStringUnicode(txtPieceworkGroupName.Text, gbUnicode, True) & COMMA) 'varchar[150], NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("GroupProductID = " & SQLString(tdbcGroupProductID.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("GroupManagerName = " & SQLStringUnicode(tdbcGroupManager.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("GroupManagerNameU = " & SQLStringUnicode(tdbcGroupManager.Text, gbUnicode, True)) 'varchar[250], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("PieceworkGroupID = " & SQLString(_pieceworkGroupID))

        Return sSQL
    End Function

    Private Function SQLInsertD45T1051s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append("Insert Into D45T1051(")
                sSQL.Append("PieceworkGroupID, EmployeeID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(txtPieceworkGroupID.Text) & COMMA) 'PieceworkGroupID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID))) 'EmployeeID, varchar[20], NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Function SQLDeleteD45T1051() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1051"
        sSQL &= " Where PieceworkGroupID=" & SQLString(txtPieceworkGroupID.Text)
        Return sSQL
    End Function

    Private Function SQLStoreD45P1051(ByVal sPieceworkGroupID As String, ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1051 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        If tdbcBlockID.SelectedValue Is Nothing Then
            sSQL &= SQLString("") & COMMA 'BlockID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcBlockID.SelectedValue.ToString) & COMMA 'BlockID, varchar[20], NOT NULL
        End If

        If tdbcDepartmentID.SelectedValue Is Nothing Then
            sSQL &= SQLString("") & COMMA 'DepartmentID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcDepartmentID.SelectedValue.ToString) & COMMA 'DepartmentID, varchar[20], NOT NULL
        End If

        If tdbcTeamID.SelectedValue Is Nothing Then
            sSQL &= SQLString("") & COMMA 'TeamID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcTeamID.SelectedValue.ToString) & COMMA 'TeamID, varchar[20], NOT NULL
        End If

        If tdbcEmployeeID.SelectedValue Is Nothing Then
            sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcEmployeeID.SelectedValue.ToString) & COMMA 'EmployeeID, varchar[20], NOT NULL
        End If

        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            sSQL &= SQLString("") & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcWorkingStatusID.SelectedValue.ToString) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        End If

        sSQL &= SQLString(txtPieceworkGroupID.Text) & COMMA 'PieceworkGroupID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        Me.Cursor = Cursors.WaitCursor
        sSQL = SQLStoreD45P1051("", 1)
        dtTemp = ReturnDataTable(sSQL)
        dtOrg = dtTemp
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBGrid()
        If dtTemp Is Nothing Then Exit Sub

        If dtGrid Is Nothing Then
            dtGrid = dtTemp.Copy
        Else
            SaveLastChoose(dtGrid, dtTemp, "BlockID", "DepartmentID", "TeamID", "EmployeeID")
        End If

        If chkView.Checked Then
            LoadDataSource(tdbg, ReturnTableFilter(dtGrid, "IsUsed = True"), gbUnicode)
        Else 'If chkShowIsUsed.Checked = False And bFlagFind = False Then
            LoadDataSource(tdbg, dtGrid, gbUnicode)
        End If
        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub

    'Mục đích: giữ lại ~ dòng đã check, ví dụ kết quả tìm kiếm luôn giữ lại ~ dòng được check trước khi tìm dù các dòng này k thỏa dk tìm kiếm
    'b1. Lọc giữ lại các dòng checked trong dtGrid
    'b2. Insert các dòng mới k trùng trong dtTemp vào dtGrid
    'output: thay đổi dtGrid
    Private Sub SaveLastChoose(ByRef dtGrid As DataTable, ByVal dtTemp As DataTable, ByVal sField1 As String, ByVal sField2 As String, ByVal sField3 As String, ByVal sField4 As String)

        'b1. Lọc giữ lại các dòng checked trong dtGrid
        Dim dtGrid_copy As DataTable = ReturnTableFilter(dtGrid, "IsUsed = True")

        'b2. Insert các dòng mới k trùng trong dtTemp vào dtGrid
        For Each drTemp As DataRow In dtTemp.Rows
            Dim bDup As Boolean = False
            If dtGrid_copy.Select("BlockID = " & SQLString(drTemp(sField1)) & " And DepartmentID = " & SQLString(drTemp(sField2)) & " And TeamID = " & SQLString(drTemp(sField3)) & " And EmployeeID = " & SQLString(drTemp(sField4))).Length > 0 Then
                bDup = True
            End If

            If bDup = False Then
                dtGrid_copy.ImportRow(drTemp)
            End If
        Next

        dtGrid = dtGrid_copy

    End Sub

    Private Sub chkView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkView.Click
        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUsed
                tdbg.UpdateData()

                Dim dr() As DataRow
                dr = dtGrid.Select("BlockID = " & SQLString(tdbg.Columns(COL_BlockID).Text) & " And DepartmentID = " & SQLString(tdbg.Columns(COL_DepartmentID).Text) & " And TeamID = " & SQLString(tdbg.Columns(COL_TeamID).Text) & " And EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text))
                If dr.Length > 0 Then
                    dr(0).BeginEdit()
                    dr(0).Item("IsUsed") = CBool(tdbg.Columns(COL_IsUsed).Value)
                    dr(0).EndEdit()
                End If

                If chkView.Checked Then
                    LoadDataSource(tdbg, ReturnTableFilter(dtGrid, "IsUsed = True", True), gbUnicode)
                End If
                FooterTotalGrid(tdbg, COL_EmployeeID)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then
            Return
        End If
        Select Case e.ColIndex
            Case COL_IsUsed
                CheckedAll()
        End Select
    End Sub

    Private Sub CheckedAll()
        bHeadClick = Not bHeadClick
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_IsUsed) = bHeadClick
        Next
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_Sex Then HotKeyEnterGrid(tdbg, COL_IsUsed, e)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If tdbg.RowCount <= 0 Then
                Return
            End If
            Select Case tdbg.Col
                Case COL_IsUsed
                    CheckedAll()
            End Select
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_IsUsed)
    End Sub

#Region "Events tdbcGroupProductID with txtGroupProductName"

    Private Sub tdbcGroupProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.SelectedValueChanged
        If tdbcGroupProductID.SelectedValue Is Nothing Then
            txtGroupProductName.Text = ""
        Else
            txtGroupProductName.Text = tdbcGroupProductID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcGroupProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.LostFocus
        If tdbcGroupProductID.FindStringExact(tdbcGroupProductID.Text) = -1 Then
            tdbcGroupProductID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID()
        If tdbcBlockID.SelectedValue Is Nothing Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        ElseIf tdbcBlockID.Text <> "" Then
            tdbcDepartmentID.SelectedValue = "%"
        End If
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID()
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        ElseIf tdbcDepartmentID.Text <> "" Then
            tdbcTeamID.SelectedValue = "%"
        End If
    End Sub
#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        LoadtdbcEmployeeID()
        If tdbcTeamID.SelectedValue Is Nothing Then
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
        ElseIf tdbcTeamID.Text <> "" Then
            tdbcEmployeeID.SelectedValue = "%"
        End If
    End Sub
#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.SelectedValueChanged
        LoadtdbcEmployeeID()
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            tdbcWorkingStatusID.Text = ""
            tdbcEmployeeID.Text = ""
        ElseIf tdbcWorkingStatusID.Text <> "" Then
            tdbcEmployeeID.SelectedValue = "%"
        End If
    End Sub
#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcGroupManager.AutoCompletion = False
        tdbcBlockID.AutoCompletion = False
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
        tdbcWorkingStatusID.AutoCompletion = False
        tdbcEmployeeID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupManager.LostFocus, _
                tdbcBlockID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus, tdbcWorkingStatusID.LostFocus, tdbcEmployeeID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupManager.Close, _
                tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, tdbcEmployeeID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupManager.Validated, _
                tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

End Class