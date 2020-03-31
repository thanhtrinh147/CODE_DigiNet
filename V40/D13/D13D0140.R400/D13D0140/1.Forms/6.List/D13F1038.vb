Imports System.Windows.Forms
Imports System
Public Class D13F1038
	Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0               ' Chọn
    Private Const COL_EmployeeID As Integer = 1           ' Mã NV
    Private Const COL_EmployeeName As Integer = 2         ' Họ và tên
    Private Const COL_RelationName As Integer = 3         ' Quan hệ
    Private Const COL_RelativeName As Integer = 4         ' Tên người quan hệ
    Private Const COL_SexName As Integer = 5              ' Giới tính
    Private Const COL_BirthDate As Integer = 6            ' Ngày sinh
    Private Const COL_BlockID As Integer = 7              ' Khối
    Private Const COL_BlockName As Integer = 8            ' Tên khối
    Private Const COL_DepartmentID As Integer = 9         ' Phòng ban
    Private Const COL_DepartmentName As Integer = 10      ' Tên phòng ban
    Private Const COL_TeamID As Integer = 11              ' Tổ nhóm
    Private Const COL_TeamName As Integer = 12            ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 13          ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 14        ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 15              ' Chức vụ
    Private Const COL_DutyName As Integer = 16            ' Tên chức vụ
    Private Const COL_WorkID As Integer = 17              ' Công việc
    Private Const COL_WorkName As Integer = 18            ' Tên công việc
    Private Const COL_DateJoined As Integer = 19          ' Ngày vào làm
    Private Const COL_DeductibleDateBegin As Integer = 20 ' Bắt đầu GT
    Private Const COL_DeductibleDateEnd As Integer = 21   ' Kết thúc GT
#End Region

    Private dtGrid As DataTable
    Private dtDepartmentID As DataTable
    Private dtTeamID As DataTable
    Private dtEmployeeID As DataTable

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    'Mode = 0: Path1: Module D13/ Danh mục / Hồ sơ lương gốc/ Cập nhật hiệu lực giảm trừ gia cảnh/ 
    'Mode = 1: Path2: Module D13/ Cảnh báo kết thúc giảm trừ khi con đủ 18 tuổi
    Private _mode As Integer = 0
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private Sub D13F1038_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        ResetColorGrid(tdbg)

        LoadTDBCombo()
        LoadDefault()

        gbEnabledUseFind = False
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DeductibleDateBegin, COL_DeductibleDateEnd)

        LoadLanguage()
        If _mode = 1 Then ' User cảnh báo
            btnFilter.Enabled = False
            LoadTDBGrid(True)
        Else
            ResetGrid()
        End If

        CallD99U1111()

        SetBackColorObligatory()
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
InputDateCustomFormat(c1dateDateFrom,c1dateDateTo)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13F1038_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_hieu_luc_giam_tru_gia_canh") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'CËp nhËt hiÖu løc gi¶m trô gia c¶nh
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDateFrom.Text = rl3("Ngay_ket_thuc_GT") 'Ngày kết thúc GT
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblRelationID.Text = rl3("Quan_he") 'Quan hệ
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        btnF12.Text = "F12 ( " & rl3("Hien_thi") & " )" 'Hiển thị (F12)
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcRelationID.Columns("RelationID").Caption = rl3("Ma") 'Mã
        tdbcRelationID.Columns("RelationName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_RelationName).Caption = rl3("Quan_he") 'Quan hệ
        tdbg.Columns(COL_RelativeName).Caption = rl3("Ten_nguoi_quan_he") 'Tên người quan hệ
        tdbg.Columns(COL_SexName).Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_BirthDate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_BlockID).Caption = rl3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_EmpGroupID).Caption = rl3("Nhom_NV") 'Nhóm NV
        tdbg.Columns(COL_EmpGroupName).Caption = rl3("Ten_nhom_NV") 'Tên nhóm NV
        tdbg.Columns(COL_DutyID).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_DutyName).Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns(COL_WorkID).Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns(COL_WorkName).Caption = rl3("Ten_cong_viec") 'Tên công việc
        tdbg.Columns(COL_DateJoined).Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_DeductibleDateBegin).Caption = rl3("Bat_dau_GT") 'Bắt đầu GT
        tdbg.Columns(COL_DeductibleDateEnd).Caption = rl3("Ket_thuc_GT") 'Kết thúc GT
    End Sub


    Private Sub LoadTDBCombo()
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtEmployeeID = ReturnTableEmployeeID(True, , gbUnicode)

        Dim sSQL As String = "--Do nguon combo quan he" & vbCrLf
        sSQL &= "SELECT  	'%' as RelationID, " & AllName & " as RelationName, 0 as DisplayOrder " & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT	 RelationID, RelationName" & UnicodeJoin(gbUnicode) & " As RelationName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM 	D09T0240  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder, RelationName"
        LoadDataSource(tdbcRelationID, sSQL, gbUnicode)

        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date

        tdbcBlockID.SelectedValue = "%"
        tdbcRelationID.SelectedValue = "%"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) Then
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhan_vien"))
            tdbcEmployeeID.Focus()
            Return False
        End If
        If tdbcRelationID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Quan_he"))
            tdbcRelationID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRelationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbg.Splits(SPLIT0).DisplayColumns(COL_DeductibleDateBegin).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DeductibleDateEnd).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True)
        If bLoad Then
            Dim arrColObligatory() As Object = {COL_IsUsed, COL_EmployeeID, COL_EmployeeName, COL_DeductibleDateBegin, COL_DeductibleDateEnd}
            usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        End If
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid(True)

        '    dtF12 = Nothing
        CallD99U1111(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim dt As DataTable = ReturnDataTable(SQLStoreD13P0216)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = "IsUsed = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("RelativeID")}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        ResetGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFind As String = sFind 'TH sFind="" và chkIsUsed.Checked =False
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If chkIsUsed.Checked Then
            strFind = "IsUsed=True"
        Else
            If sFind <> "" Then strFind = "IsUsed=True" & " Or " & strFind
        End If
        dtGrid.DefaultView.RowFilter = strFind

        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        tsbFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        tsbListAll.Enabled = tsbFind.Enabled 'Mờ khi  chkIsUsed.Checked = True
        tsmFind.Enabled = tsbFind.Enabled
        mnsFind.Enabled = tsbFind.Enabled
        tsmListAll.Enabled = tsbListAll.Enabled
        mnsListAll.Enabled = tsbListAll.Enabled

        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub

    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub


#Region "Active Find - List All (Client)"
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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '   If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_IsUsed, COL_EmployeeID, COL_EmployeeName, COL_DeductibleDateBegin, COL_DeductibleDateEnd}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        '   End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcEmployeeID.Close, tdbcRelationID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcEmployeeID.Validated, tdbcRelationID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "Events tdbCombo - G4 Standard"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 OrElse tdbcBlockID.Text = "" Then
            tdbcBlockID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub


    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 OrElse tdbcDepartmentID.Text = "" Then
            tdbcDepartmentID.Text = ""
            tdbcDepartmentID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 OrElse tdbcTeamID.Text = "" Then
            tdbcTeamID.Text = ""
            tdbcTeamID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, "%", gbUnicode)
        Else
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmployeeID.SelectedValue = "%"
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 OrElse tdbcEmployeeID.Text = "" Then
            tdbcEmployeeID.Text = ""
            tdbcEmployeeID.SelectedValue = "%"
        End If
    End Sub

#End Region

#Region "Events tdbcRelationID"

    Private Sub tdbcRelationID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRelationID.LostFocus
        If tdbcRelationID.FindStringExact(tdbcRelationID.Text) = -1 Then tdbcRelationID.Text = ""
    End Sub

#End Region


#Region "tdbg event"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUsed
                tdbg.UpdateData()
                ResetGrid()
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsUsed
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case COL_DeductibleDateBegin, COL_DeductibleDateEnd
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
                tdbg.AllowSort = False
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub


    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsUsed 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_BirthDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
        End Select
    End Sub

#End Region

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        dtGrid.AcceptChanges()
        dr = dtGrid.Select("IsUsed=1")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Row = 0
            Return False
        End If
        For i As Integer = 0 To dr.Length - 1
            If dr(i).Item("DeductibleDateBegin").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Bat_dau_GT"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_DeductibleDateBegin
                tdbg.Row = i
                Return False
            End If
            If dr(i).Item("DeductibleDateEnd").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ket_thuc_GT"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_DeductibleDateEnd
                tdbg.Row = i
                Return False
            End If
            If CDate(dr(i).Item("DeductibleDateBegin").ToString) > CDate(dr(i).Item("DeductibleDateEnd").ToString) Then
                D99C0008.MsgNotYetEnter(rl3("MSG000013"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_DeductibleDateEnd
                tdbg.Row = i
                Return False
            End If

        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String
        sSQL = SQLUpdateD09T0216s(dr).ToString & vbCrLf
        sSQL &= SQLUpdateD13T0216s(dr).ToString

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0216
    '# Created User: Hoàng Nhân
    '# Created Date: 16/12/2013 11:27:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0216() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho Grid" & vbCrLf)
        sSQL &= "Exec D13P0216 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcEmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRelationID)) & COMMA 'RelationID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'codeTable, tinyint, NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_mode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0216s
    '# Created User: Hoàng Nhân
    '# Created Date: 19/12/2013 02:25:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0216s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            '  If i = 0 Then sSQL.Append("-- update du lieu" & vbCrLf)
            sSQL.Append("Update D13T0216 Set ")
            sSQL.Append("DeductibleDateBegin = " & SQLDateSave(dr(i).Item("DeductibleDateBegin")) & COMMA) 'datetime, NULL
            sSQL.Append("DeductibleDateEnd = " & SQLDateSave(dr(i).Item("DeductibleDateEnd"))) 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("RelativeID = " & SQLString(dr(i).Item("RelativeID")))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0216s
    '# Created User: Hoàng Nhân
    '# Created Date: 19/12/2013 02:25:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0216s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            '  If i = 0 Then sSQL.Append("-- update du lieu" & vbCrLf)
            sSQL.Append("Update D09T0216 Set ")
            sSQL.Append("DeductibleDateBegin = " & SQLDateSave(dr(i).Item("DeductibleDateBegin")) & COMMA) 'datetime, NULL
            sSQL.Append("DeductibleDateEnd = " & SQLDateSave(dr(i).Item("DeductibleDateEnd"))) 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("RelativeID = " & SQLString(dr(i).Item("RelativeID")))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
End Class