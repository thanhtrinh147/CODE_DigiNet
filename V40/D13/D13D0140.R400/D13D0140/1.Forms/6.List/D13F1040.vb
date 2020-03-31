'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:43:18 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:43:18 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------

Public Class D13F1040
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Private _formIDPermission As String = "D13F1040"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg - Total of Columns: 12"
    Private Const COL_OfficialTitleID As Integer = 0   ' Mã
    Private Const COL_OfficialTitleName As Integer = 1 ' Diễn giải
    Private Const COL_NumSalaryLevel As Integer = 2    ' Số bậc lương tối đa
    Private Const COL_DisplayOrder As Integer = 3      ' TT hiển thị
    Private Const COL_DutyID As Integer = 4            ' Chức vụ
    Private Const COL_Official1 As Integer = 5         ' Ngạch 1
    Private Const COL_Official2 As Integer = 6         ' Ngạch 2
    Private Const COL_Disabled As Integer = 7          ' KSD
    Private Const COL_CreateUserID As Integer = 8      ' Người tạo
    Private Const COL_CreateDate As Integer = 9        ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 10 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 11   ' Ngày cập nhật cuối cùng
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Dim bKeyPress As Boolean = False
    Dim bChangeRow As Boolean = True 'Kiểm tra xem có được di chuyển qua dòng khác không
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                    ResizeForm() ' gọi từ Nghiệp vụ
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub ResizeForm()
        ' Cách lấy kích thước
        Dim iTitleHeight As Integer = 22 ' chiều cao TitleHeight
        Dim iLine As Integer = 3 ' 3 đường viền Trái, Phải, Trên
        Dim iWidthControl As Integer = 5 ' khoảng cách các từ viền trái tới GroupBox

        TableToolStrip.Visible = False
        tdbg.Visible = False
        chkDisabled.Visible = False

        GroupBox1.Location = New Point(iWidthControl, iWidthControl)
        Me.Width = GroupBox1.Width + (2 * (iWidthControl + iLine))  ' Khoảng cách cách ra 2 bên
        Me.Height = GroupBox1.Height + GroupBox1.Location.Y + iTitleHeight + iLine + pnlButton.Height + (2 * iWidthControl)

        pnlButton.Location = New Point(Me.Width - pnlButton.Width - (2 * iLine) - iWidthControl, Me.Height - pnlButton.Height - iTitleHeight - iLine - iWidthControl)
    End Sub

    Private Sub D13F1040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F1040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtOfficialTitleID)

        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        'ID 97485 02.06.2017
        LoadCaptionShortBySystem()

        InputNumber(cneNumSalaryLevel, SqlDbType.Int, "N0", False, 28, 8) 'Nhập số âm = True. Default = False
        InputNumber(cneDisplayOrder, SqlDbType.Int, "N0", False) 'Nhập số âm = True. Default = False
        LoadTDBCombo()

        If _FormState <> EnumFormState.FormAdd Then ' gọi từ Nghiệp vụ
            ResetColorGrid(tdbg)
            LoadTDBGrid()
            SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        End If

        SetBackColorObligatory()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadCaptionShortBySystem()
        Dim sSQL As String = ""
        sSQL = "        SELECT Code, T1.ShortU AS CaptionOptionName " & vbCrLf & _
                " FROM D13T9000 T1 WITH(NOLOCK) " & vbCrLf & _
                " WHERE T1.Type = 'OLSC' AND T1.Code IN ('OLSC1','OLSC2')"
        Dim dtCap As DataTable = ReturnDataTable(sSQL)
        If dtCap.Rows.Count = 2 Then
            optUseOfficial1.Text = L3String(dtCap.Rows(0)("CaptionOptionName"))
            optUseOfficial2.Text = L3String(dtCap.Rows(1)("CaptionOptionName"))
            tdbg.Columns("Official1").Caption = L3String(dtCap.Rows(0)("CaptionOptionName"))
            tdbg.Columns("Official2").Caption = L3String(dtCap.Rows(1)("CaptionOptionName"))
        End If
    End Sub

    Private Sub D13F1040_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If tdbg.FilterActive Then
            bKeyPress = False
        Else
            bKeyPress = True
        End If
    End Sub

    Private Sub D13F1040_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bKeyPress Then Exit Sub

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

    Private Sub D13F1040_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then ' gọi từ Nghiệp vụ
            txtOfficialTitleID.Focus()
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_ngach_luong_-_D13F1040") & UnicodeCaption(gbUnicode) 'Danh móc ngÁch l§¥ng - D13F1040
        '================================================================ 
        lblOfficialTitleID.Text = rl3("Ma") 'Mã ngạch lương
        lblOfficialTitleName.Text = rl3("Dien_giai") 'Diễn giải
        lblNumSalaryLevel.Text = rl3("Bac_luong_toi_da") 'Bậc lương tối đa
        lblDutyID.Text = rl3("Chuc_vu")
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu && Nhập &tiếp
        '================================================================ 

        optUseOfficialAll.Text = rL3("Thuoc_2_ngach_luong") 'Thuộc 2 ngạch lương

        optUseOfficial2.Text = rl3("Ngach_luong_2") 'Ngạch lương 2
        optUseOfficial1.Text = rl3("Ngach_luong_1") 'Ngạch lương 1
        '================================================================ 
        tdbg.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("OfficialTitleName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("NumSalaryLevel").Caption = rL3("So_bac_luong_toi_da") 'Số bậc lương tối đa
        tdbg.Columns("DutyID").Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        tdbg.Columns("Official1").Caption = rl3("Ngach") & " 1" 'Ngạch lương 1
        tdbg.Columns("Official2").Caption = rl3("Ngach") & " 2" 'Ngạch lương 2
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        lblDisplayOrder.Text = rL3("TT_hien_thi") 'TT hiển thị
        tdbg.Columns(COL_DisplayOrder).Caption = rL3("TT_hien_thi") 'TT hiển thị
    End Sub

    Private Sub SetBackColorObligatory()
        txtOfficialTitleID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtOfficialTitleName.BackColor = COLOR_BACKCOLOROBLIGATORY
        cneNumSalaryLevel.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        Dim sSQL As String = ""
        sSQL &= "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " As OfficialTitleName, DutyID, " & vbCrLf
        sSQL &= "       NumSalaryLevel, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, DisplayOrder, " & vbCrLf
        sSQL &= " CASE WHEN IsUseOfficial=2 THEN 0 ELSE 1 END AS Official1," & vbCrLf
        sSQL &= " CASE WHEN IsUseOfficial=1 THEN 0 ELSE 1 END AS Official2" & vbCrLf
        sSQL &= "From   D09T0214  WITH (NOLOCK) Order by OfficialTitleID" & vbCrLf
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid(False)
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("OfficialTitleID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If

        LoadEdit()
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        bKeyPress = False

        If bLoadEdit Then LoadEdit()
    End Sub

    Private Sub ResetGrid()
        ' update 27/3/2013 id 55214 - Chuẩn hóa phân quyền menu Import dữ liệu
        ' ImportData phân quyền theo 2 màn hình D13F5603 và PARA_FormIDPermission
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F5603")
        tsbImportData.Enabled = tsbImportData.Enabled And tsbAdd.Enabled
        tsmImportData.Enabled = tsbImportData.Enabled
        mnsImportData.Enabled = tsbImportData.Enabled
        FooterTotalGrid(tdbg, COL_OfficialTitleID)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_OfficialTitleID).Tag = ""
        '********************
        _bSaved = False
        bKeyPress = False
        bTemp = False
        '*******************
        ClearText(GroupBox1)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        optUseOfficialAll.Checked = True
        '*******************
        UnReadOnlyControl(txtOfficialTitleID, True)
        txtOfficialTitleID.Focus()
        '*******************
        btnSave.Enabled = True
        btnSave.Left = btnNext.Left - btnSave.Width - 6
        btnNext.Visible = True
        btnNext.Enabled = True
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu && Nhập &tiếp
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If tdbg.Columns(COL_OfficialTitleID).Tag IsNot Nothing AndAlso tdbg.Columns(COL_OfficialTitleID).Text = tdbg.Columns(COL_OfficialTitleID).Tag.ToString Then
            EnabledSave()
            Exit Sub
        End If
        tdbg.Columns(COL_OfficialTitleID).Tag = tdbg.Columns(COL_OfficialTitleID).Text
        '************************
        'Gán dữ liệu
        txtOfficialTitleID.Text = tdbg.Columns(COL_OfficialTitleID).Text
        txtOfficialTitleName.Text = tdbg.Columns(COL_OfficialTitleName).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        cneNumSalaryLevel.Value = L3Int(tdbg.Columns(COL_NumSalaryLevel).Text)
        cneDisplayOrder.Value = tdbg.Columns(COL_DisplayOrder).Value
        If L3Bool(tdbg.Columns(COL_Official1).Text) And L3Bool(tdbg.Columns(COL_Official2).Text) Then
            optUseOfficialAll.Checked = True
        ElseIf L3Bool(tdbg.Columns(COL_Official1).Text) Then
            optUseOfficial1.Checked = True
        ElseIf L3Bool(tdbg.Columns(COL_Official2).Text) Then
            optUseOfficial2.Checked = True
        End If
        tdbcDutyID.SelectedValue = tdbg.Columns(COL_DutyID).Text
        '************************
        ReadOnlyControl(txtOfficialTitleID)
        '************************

        EnabledSave()
    End Sub

    Private Sub EnabledSave()
        If _FormState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            chkDisabled.Visible = True
            btnNext.Visible = False
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
            btnSave.Enabled = (_FormState <> EnumFormState.FormView)
        End If
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
        sSQL &= "FROM D09T0211  WITH (NOLOCK) "
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
                    D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                Else
                    Dim sKey As String = ""
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "FormCall", Me.Name)
                    SetProperties(arrPro, "FormIDPermission", "D09F0290")
                    SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                    'ID 96109  30.03.2017 rà các dropdown chức vụ có thêm mới nhưng gọi D09F0291
                    Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0290", arrPro)
                    'Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0291", arrPro)
                    If L3Bool(GetProperties(frm, "bSaved")) Then
                        LoadTDBCDutyID()
                        tdbcDutyID.SelectedValue = GetProperties(frm, "DutyID")
                    Else
                        tdbcDutyID.SelectedValue = ""
                    End If
                End If
                tdbcDutyID.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumSalaryLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
            sFind = Value
            _FormState = EnumFormState.FormView
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
	End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_OfficialTitleID, COL_OfficialTitleName, COL_NumSalaryLevel}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        _FormState = EnumFormState.FormView
    '        ReLoadTDBGrid()
    '    End Sub

#End Region

#Region "Menu bar"

    Private Sub AllowActive()
        If txtOfficialTitleID.Text <> "" And bKeyPress = True Then
            If D99C0008.MsgAsk(rl3("Du_lieu_chua_duoc_luu") & " " & rl3("MSG000028")) = Windows.Forms.DialogResult.Yes Then
                bAskSave = False
                btnSave_Click(Nothing, Nothing)
            End If
            bKeyPress = False
        End If
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        AllowActive()
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If _FormState = EnumFormState.FormAdd Then
            AllowActive()
        End If

        _FormState = EnumFormState.FormEdit
        LoadEdit()
        _bSaved = False
        bKeyPress = False
        txtOfficialTitleName.Focus()
    End Sub

    Private Function AllowDelete() As Boolean
        bChangeRow = False
        '*********************
        If Not CheckStore(SQLStoreD13P5555()) Then
            Return False
        End If
        '******************
        bChangeRow = True
        Return True
    End Function


    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        AllowActive()

        Dim sSQL As String = ""
        Dim bResult As Boolean
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub

        sSQL &= SQLDeleteD09T0214()
        bResult = ExecuteSQL(sSQL)
        If bResult = True Then
            DeleteOK()
            'Audit Log
            Dim sDesc1 As String = tdbg.Columns(COL_OfficialTitleID).Text
            Dim sDesc2 As String = tdbg.Columns(COL_OfficialTitleName).Text
            Dim sDesc3 As String = tdbg.Columns(COL_NumSalaryLevel).Text
            Dim sDesc4 As String = SQLNumber(CBool(tdbg.Columns(COL_Disabled).Text))
            Dim sDesc5 As String = ""
            RunAuditLog(AuditCodeSalaryGrades, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            LoadEdit()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_OfficialTitleID, COL_OfficialTitleName, COL_NumSalaryLevel}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, True, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = dtCaptionCols
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dtGrid
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tsbImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D13, "D13F5603", "D13F1040") Then
            'Load lại dữ liệu
            Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark
        End If
        '        Dim frm As New D80F2090
        '        With frm
        '            .FormActive = "D80F2090"
        '            .FormPermission = "D13F5603"
        '            .ModuleID = D13
        '            .TransTypeID = "D13F1040" 'Theo TL phân tích
        '            .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '            .ShowDialog()
        '            If .OutPut01 Then .bSaved = .OutPut01
        '            .Dispose()
        '        End With
        '        If .bSaved Then
        '            'Load lại dữ liệu
        '            Dim iBookmark As Integer = tdbg.Bookmark
        '            LoadTDBGrid()
        '            tdbg.Bookmark = iBookmark
        '        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid"


    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled, COL_Official1, COL_Official2 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_NumSalaryLevel
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        '  If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        If tdbg.RowCount <= 1 OrElse tdbg.FilterActive OrElse _FormState = EnumFormState.FormView Then Exit Sub
        '*********************
        'Dữ liệu Chi tiết không thay đổi
        If Not bKeyPress Then
            _FormState = EnumFormState.FormView
            EnabledSave()
            Exit Sub
        End If
        '*********************
        'Dữ liệu Chi tiết có thay đổi
        If btnSave.Enabled Then
            '*************
            If AskMsgBeforeRowChange() Then
                bAskSave = False
                '************************************
                _FormState = EnumFormState.FormEdit
                btnSave_Click(sender, e)
                If bChangeRow = False Then 'Vi phạm nên không được di chuyển dòng
                    e.Cancel = True 'neu chua luu dc thi van dung tai dong do
                    bKeyPress = True
                    Exit Sub
                End If
            Else
                LoadEdit()
            End If
        End If

        _FormState = EnumFormState.FormView
        bKeyPress = False
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub

        'Neu o thanh Filter thi k kiem tra va chay su kien RowColChange
        If tdbg.FilterActive Then
            bKeyPress = False
            Exit Sub
        End If

        If tdbg.Columns(COL_OfficialTitleID).Tag Is Nothing OrElse tdbg.Columns(COL_OfficialTitleID).Text <> tdbg.Columns(COL_OfficialTitleID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

#End Region

    Dim bTemp As Boolean = False
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnNext.Focus()
        If btnNext.Focused = False Then Exit Sub
        '************************************
        If btnNext.Text = rl3("Luu_va_Nhap__tiep") Then
            btnSave_Click(Nothing, Nothing)
            If bTemp = False Then Exit Sub
        End If
        btnNext.Text = rl3("Luu_va_Nhap__tiep")
        btnSave.Enabled = True
        '************************************
        LoadAdd()
    End Sub

    Dim bSave As Boolean = False
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chỉ thông báo hỏi khi nhấn nút Lưu. Còn khi du chuyển sang dòng khác thì không hỏi
        If bAskSave Then
            'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
            btnSave.Focus()
            If btnSave.Focused = False Then Exit Sub
            '************************************
            If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Else
            bAskSave = True
        End If
        _bSaved = False

        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        '  D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
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
            bKeyPress = False
            bTemp = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtOfficialTitleID.Text)
                    ' D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "True")
                    If sender IsNot Nothing Then btnNext.Text = rl3("Nhap__tiep")
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtOfficialTitleID.Text
                    Dim sDesc2 As String = txtOfficialTitleName.Text
                    Dim sDesc3 As String = cneNumSalaryLevel.Value.ToString
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeSalaryGrades, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    LoadTDBGrid(, txtOfficialTitleID.Text)

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
        bChangeRow = False
        '*********************
        If txtOfficialTitleID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_ngach_luong"))
            txtOfficialTitleID.Focus()
            Return False
        End If
        If txtOfficialTitleName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_ngach_luong"))
            txtOfficialTitleName.Focus()
            Return False
        End If
        If cneNumSalaryLevel.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Bac_luong_toi_da"))
            cneNumSalaryLevel.Focus()
            Return False
        End If
        If Number(cneNumSalaryLevel.Value) = 0 Then
            D99C0008.MsgL3(rl3("Bac_luong_phai__0_"))
            cneNumSalaryLevel.Focus()
            Return False
        End If
        If Number(cneNumSalaryLevel.Value) >= 100 Then
            D99C0008.MsgL3(rl3("Bac_luong_toi_da_phai__100_"))
            cneNumSalaryLevel.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D09T0214", "OfficialTitleID", txtOfficialTitleID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtOfficialTitleID.Focus()
                Return False
            End If
        End If
        '******************
        bChangeRow = True
        Return True
    End Function

#Region "SQL"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T0214
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 18/01/2007 05:14:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T0214() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T0214"
        sSQL &= " Where OfficialTitleID = " & SQLString(tdbg.Columns(COL_OfficialTitleID).Text)
        Return sSQL
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
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate, DutyID, DisplayOrder "
        sSQL &= ") Values ("
        sSQL &= SQLString(txtOfficialTitleID.Text) & COMMA 'OfficialTitleID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtOfficialTitleName.Text, gbUnicode, False) & COMMA 'OfficialTitleName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtOfficialTitleName.Text, gbUnicode, True) & COMMA 'OfficialTitleNameU, varchar[50], NULL
        sSQL &= SQLNumber(cneNumSalaryLevel.Value) & COMMA 'NumSalaryLevel, tinyint, NULL
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
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDutyID).ToString) & COMMA
        sSQL &= SQLNumber(cneDisplayOrder.Value, "N0") 'DisplayOrder, int, NOT NULL
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
        sSQL &= "OfficialTitleName = " & SQLStringUnicode(txtOfficialTitleName.Text, gbUnicode, False) & COMMA 'varchar[50], NULL
        sSQL &= "OfficialTitleNameU = " & SQLStringUnicode(txtOfficialTitleName.Text, gbUnicode, True) & COMMA 'varchar[50], NULL
        sSQL &= "NumSalaryLevel = " & SQLNumber(cneNumSalaryLevel.Value) & COMMA 'tinyint, NULL
        sSQL &= "DisplayOrder = " & SQLNumber(cneDisplayOrder.Value, "N0") & COMMA 'int, NULL
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
        sSQL &= "OfficialTitleID = " & SQLString(txtOfficialTitleID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Hoàng Nhân
    '# Created Date: 19/11/2013 01:23:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi xoa" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_OfficialTitleID).Text) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function



#End Region

End Class