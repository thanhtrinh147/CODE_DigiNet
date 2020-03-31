Public Class D13F3080

    Private dtProject As DataTable
    Private _formIDPermission As String = "D13F3080"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 29"
    Private Const COL_TransID As String = "TransID"                     ' Khóa 1
    Private Const COL_Split As String = "Split"                         ' Khóa 2 
    Private Const COL_IsUsed As String = "IsUsed"                       ' Chọn
    Private Const COL_EmployeeID As String = "EmployeeID"               ' Mã NV
    Private Const COL_EmployeeName As String = "EmployeeName"           ' Họ và tên
    Private Const COL_BlockID As String = "BlockID"                     ' Khối
    Private Const COL_BlockName As String = "BlockName"                 ' Tên khối
    Private Const COL_DepartmentID As String = "DepartmentID"           ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName"       ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                       ' Tổ nhóm
    Private Const COL_TeamName As String = "TeamName"                   ' Tên tổ nhóm
    Private Const COL_AttendanceDate As String = "AttendanceDate"       ' Ngày công
    Private Const COL_NormalAmount As String = "NormalAmount"           ' Công HC
    Private Const COL_AfterOTAmount As String = "AfterOTAmount"         ' Công TC
    Private Const COL_CoefficientOT As String = "CoefficientOT"         ' Hệ số TC
    Private Const COL_AfterOTTypeID As String = "AfterOTTypeID"         ' Loại công TC
    Private Const COL_ProjectID As String = "ProjectID"                 ' Dự án
    Private Const COL_ProjectName As String = "ProjectName"             ' Tên dự án
    Private Const COL_TaskID As String = "TaskID"                       ' Hạng mục
    Private Const COL_TaskName As String = "TaskName"                   ' Tên hạng mục
    Private Const COL_WorkID As String = "WorkID"                       ' Công việc
    Private Const COL_WorkName As String = "WorkName"                   ' Tên công việc
    Private Const COL_LevelWorkName As String = "LevelWorkName"         ' Tên cấp độ
    Private Const COL_CoefficientWork As String = "CoefficientWork"     ' Hệ số CV
    Private Const COL_CoefficientALWork As String = "CoefficientALWork" ' Hệ số phụ cấp
    Private Const COL_SalNormalAmount As String = "SalNormalAmount"     ' Tiền công HC
    Private Const COL_SalAfterOTAmount As String = "SalAfterOTAmount"   ' Tiền công TC
    Private Const COL_AllowanceAmount As String = "AllowanceAmount"     ' Phụ cấp CV
    Private Const COL_SalaryAmount As String = "SalaryAmount"           ' Tổng lương
#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPeriod
        LoadCboPeriodReport(tdbcPeriod, "D09", gsDivisionID)
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        'Load tdbcBlockID
        'ReturnTableBlockID_D09P6868(gsDivisionID, Me.Name, 0)
        LoadDataSource(tdbcBlockID, ReturnTableBlockID_D09P6868(gsDivisionID, Me.Name, 0), gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, Me.Name, 0)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, Me.Name, 0)
        Dim obj As New Lemon3.Data.LoadData.LoadDataG4
        obj.LoadProjectByG4(tdbcProjectID, dtProject, Me.Name)
        SetDefaultValue()
    End Sub
    Private Sub SetDefaultValue()
        tdbcBlockID.SelectedValue = "%"
        If dtProject IsNot Nothing AndAlso dtProject.Rows.Count = 1 Then
            tdbcProjectID.SelectedIndex = 0
        Else
            tdbcProjectID.SelectedValue = "%"
        End If
    End Sub

    Private dtGrid, dtTeamID, dtDepartmentID As DataTable
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub D13F3080_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Luong_theo_du_anF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'L§¥ng theo dø Àn
        '================================================================ 
        lblPeriodFrom.Text = rl3("Ky") 'Kỳ
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblAttDateFr.Text = rl3("Ngay_cham_cong") 'Ngày chấm công
        lblStrEmployeeID.Text = rl3("Ma_NV") 'Mã NV
        lblStrEmployeeName.Text = rl3("Ten_NV") 'Tên NV
        lblProjectID.Text = rl3("Cong_trinh") 'Dự án
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnCalc.Text = rl3("Tinh_lai") 'Tính lại
        btnF12.Text = "F12 ( " & rl3("Hien_thi") & " )" 'Hiển thị (F12)
        '================================================================ 
        grpF.Text = rl3("Dieu_kien_loc") 'Điều kiện lọc
        '================================================================ 
        tdbcProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbcProjectID.Columns("ProjectName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_TransID).Caption = rl3("Khoa") & " 1" 'Khóa 1
        tdbg.Columns(COL_Split).Caption = rl3("Khoa_2_") 'Khóa 2 
        tdbg.Columns(COL_IsUsed).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_BlockID).Caption = rl3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_AttendanceDate).Caption = rl3("Ngay_cong") 'Ngày công
        tdbg.Columns(COL_NormalAmount).Caption = rl3("Cong_HC") 'Công HC
        tdbg.Columns(COL_AfterOTAmount).Caption = rL3("Cong_TC") 'Công TC
        tdbg.Columns(COL_CoefficientOT).Caption = rl3("He_so_TC") 'Hệ số TC
        tdbg.Columns(COL_AfterOTTypeID).Caption = rl3("Loai_cong_TC") 'Loại công TC
        tdbg.Columns(COL_ProjectID).Caption = rl3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_ProjectName).Caption = rl3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns(COL_TaskID).Caption = rl3("Hang_muc") 'Hạng mục
        tdbg.Columns(COL_TaskName).Caption = rl3("Ten_hang_muc") 'Tên hạng mục
        tdbg.Columns(COL_WorkID).Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns(COL_WorkName).Caption = rl3("Ten_cong_viec") 'Tên công việc
        tdbg.Columns(COL_LevelWorkName).Caption = rl3("Ten_cap_do") 'Tên cấp độ
        tdbg.Columns(COL_CoefficientWork).Caption = rl3("He_so_CV") 'Hệ số CV
        tdbg.Columns(COL_CoefficientALWork).Caption = rl3("He_so_phu_cap") 'Hệ số phụ cấp
        tdbg.Columns(COL_SalNormalAmount).Caption = rl3("Tien_cong_HC") 'Tiền công HC
        tdbg.Columns(COL_SalAfterOTAmount).Caption = rl3("Tien_cong_TC") 'Tiền công TC
        tdbg.Columns(COL_AllowanceAmount).Caption = rl3("Phu_cap_CV") 'Phụ cấp CV
        tdbg.Columns(COL_SalaryAmount).Caption = rl3("Tong_luong") 'Tổng lương
    End Sub
    Private Sub D13F3080_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        gbEnabledUseFind = False
        tdbg_NumberFormat()
        LoadTDBCombo()
        SetBackColorObligatory()
        LoadLanguage()
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        InputbyUnicode(Me, gbUnicode)
        If D13Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = False
        End If
        CallD99U1111()
        CheckMenu(Me.Name, Nothing, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        btnCalc.Enabled = ReturnPermission(_formIDPermission) >= 2
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_NormalAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_AfterOTAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CoefficientOT).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CoefficientWork).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CoefficientALWork).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalNormalAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalAfterOTAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_AllowanceAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalaryAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg, arr)
    End Sub


    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ComboValue(tdbcBlockID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcDepartmentID"
    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

    Private Sub tdbcPeriod_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcPeriod.SelectedValueChanged
        If ReturnValueC1Combo(tdbcPeriod) = "" Then Exit Sub
        Dim sSQL As String = SQLStoreD29P2001()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub
        c1dateAttDateFr.Value = dt.Rows(0).Item("MinDate")
        c1dateAttDateTo.Value = dt.Rows(0).Item("MaxDate")
    End Sub
#End Region

#Region "Events tdbcProjectID"

    Private Sub tdbcProjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.LostFocus
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then tdbcProjectID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub



    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_EmployeeID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub
    Private Function AllowFilter() As Boolean
        If tdbcPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblPeriodFrom.Text)
            tdbcPeriod.Focus()
            Return False
        End If
        If tdbcBlockID.ReadOnly = False AndAlso tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDepartmentID.Text)
            tdbcDepartmentID.Focus()
            Return False
        End If
        If Not CheckValidDateFromTo(c1dateAttDateFr, c1dateAttDateTo) Then Return False
        If tdbcProjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblProjectID.Text)
            tdbcProjectID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateAttDateFr.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateAttDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If usrOption IsNot Nothing Then usrOption.Visible = False
        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13F3080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F5
                    btnFilter.PerformClick()
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
                Case Keys.F12
                    btnF12_Click(Nothing, Nothing)
                Case Keys.Escape
                    usrOption.picClose_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD13P2004()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If strFind.Trim <> "" Then strFind &= " Or IsUsed =1"
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, Nothing, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_EmployeeID)
        FooterSumNew(tdbg, COL_SalNormalAmount, COL_SalAfterOTAmount, COL_AllowanceAmount, COL_SalaryAmount)
    End Sub
    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""

    Dim dtCaptionCols As DataTable

    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property

    '*****************************
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub

    'DLL không sử dụng sự kiện Finder_FindClick
    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region
    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case COL_IsUsed
                L3HeadClick(tdbg, iCol, bSelect)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
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
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim dr() As DataRow = dtGrid.Select(COL_IsUsed & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = IndexOfColumn(tdbg, COL_IsUsed)
            tdbg.Row = 0
            Return False
        End If

        Return True
    End Function

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        btnCalc.Focus()
        If btnCalc.Focused = False Then Exit Sub
        '************************************
        If Not AllowSave() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim dtData As DataTable = ReturnTableFilter(dtGrid, COL_IsUsed & " = 1", True)
        Dim bRunSQL As Boolean = SetBulkUpload(dtData, "#D13F3080Temp", SQLStoreD13P2005())
        If bRunSQL Then
            D99C0008.MsgL3(rL3("Tinh_lai_thanh_congU"))
            LoadTDBGrid(True)
        Else
            D99C0008.MsgL3(rL3("Co_loi_trong_qua_trinh_tinh_lai"))
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtStrEmployeeID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStrEmployeeID.KeyDown
        If e.KeyCode = Keys.Enter Then btnFilter.PerformClick()
    End Sub

    Private Sub txtStrEmployeeName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStrEmployeeName.KeyDown
        If e.KeyCode = Keys.Enter Then btnFilter.PerformClick()
    End Sub


#Region "SQL function"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD29P2001
    '# Created User: Lê Anh Vũ
    '# Created Date: 01/08/2016 09:21:43
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD29P2001() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh ngay bat dau va ngay ket thuc cua chu ky luong" & vbCrlf)
        sSQL &= "Exec D29P2001 "
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MinDate, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MaxDate, datetime, NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'IsRecordSet, int, NOT NULL
        sSQL &= SQLNumber("") & COMMA 'FromDate, int, NOT NULL
        sSQL &= SQLNumber("") & COMMA 'ToDate, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'LeaveObjectID, varchar[20], NOT NULL
        sSQL &= SQLStringUnicode("", gbUnicode, False) 'TableName, varchar[100], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2004
    '# Created User: Lê Anh Vũ
    '# Created Date: 01/08/2016 09:14:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2004() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi luong theo du an" & vbCrLf)
        sSQL &= "Exec D13P2004 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLDateSave(c1dateAttDateFr.Value) & COMMA 'AttDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateAttDateTo.Value) & COMMA 'AttDateTo, datetime, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtStrEmployeeName.Text, gbUnicode, True) & COMMA 'StrEmployeeName, nvarchar[100], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA 'ProjectID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(_formIDPermission) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2005
    '# Created User: Lê Anh Vũ
    '# Created Date: 01/08/2016 10:08:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2005() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh luong va phu cap " & vbCrlf)
        sSQL &= "Exec D13P2005 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[50], NOT NULL
        Return sSQL
    End Function
#End Region
   

#Region "Builk Copy"


    Private Function GetBulkUpload(ByVal dtData As DataTable, ByVal tableName As String, ByVal SQLStore As String, Optional ByRef sSQLDxxT As StringBuilder = Nothing) As DataTable
        Dim con As New SqlConnection(gsConnectionString)
        Dim trans As SqlTransaction = Nothing
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            trans = con.BeginTransaction
            If sSQLDxxT Is Nothing Then sSQLDxxT = SQLCreate(tableName, dtData)
            Dim cmd As New SqlCommand(sSQLDxxT.ToString, con, trans)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Dim bulkCopy As SqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, trans)
            bulkCopy.BatchSize = dtData.Rows.Count
            bulkCopy.BulkCopyTimeout = 0
            bulkCopy.DestinationTableName = tableName
            bulkCopy.WriteToServer(dtData)
            Dim ds As DataSet = New DataSet()
            cmd = New SqlCommand(SQLStore, con, trans)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            cmd.CommandTimeout = 0
            da.Fill(ds)
            If ds.Tables.Count > 0 Then dt = ds.Tables(0)
            trans.Commit()
            con.Close()
        Catch ex As Exception
            trans.Rollback()
            D99C0008.MsgL3(ex.Message)
            con.Close()
            Return Nothing
        End Try
        Return dt
    End Function

    Private Function ExecuteNonQuery(ByVal sSQL As StringBuilder, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As Integer
        If sSQL Is Nothing OrElse sSQL.Length = 0 OrElse sSQL.ToString.Trim = "" Then Return 0
        Dim cmd As SqlCommand = New SqlCommand(sSQL.ToString, con, trans)
        cmd.CommandTimeout = 0
        Return cmd.ExecuteNonQuery()
    End Function

    Public Function SetBulkUpload(ByVal dtData As DataTable, ByVal tableName As String, ByVal SQLBefore As StringBuilder, ByVal SQLAfter As StringBuilder) As Boolean
        Dim con As New SqlConnection(gsConnectionString)
        Dim trans As SqlTransaction = Nothing
        Try
            con.Open()
            trans = con.BeginTransaction
            ExecuteNonQuery(SQLBefore, con, trans)
            Dim bulkCopy As SqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, trans)
            bulkCopy.BatchSize = dtData.Rows.Count
            bulkCopy.BulkCopyTimeout = 0
            bulkCopy.DestinationTableName = tableName
            Dim dtDes As DataTable = ReturnDataTable("Select Top 0 * From " & tableName)
            For i As Integer = 0 To dtDes.Columns.Count - 1
                If dtData.Columns.Contains(dtDes.Columns(i).ColumnName) Then
                    bulkCopy.ColumnMappings.Add(dtDes.Columns(i).ColumnName, dtDes.Columns(i).ColumnName)
                End If
            Next
            bulkCopy.WriteToServer(dtData)
            ExecuteNonQuery(SQLAfter, con, trans)
            trans.Commit()
            con.Close()
        Catch ex As Exception
            trans.Rollback()
            D99C0008.MsgL3(ex.Message)
            con.Close()
            Return False
        End Try
        Return True
    End Function

    Private Function SetBulkUpload(ByVal dtData As DataTable, ByVal tableName As String, ByVal SQLStore As String, Optional ByRef sSQLDxxT As StringBuilder = Nothing) As Boolean
        Dim con As New SqlConnection(gsConnectionString)
        Dim trans As SqlTransaction = Nothing
        Try
            con.Open()
            trans = con.BeginTransaction
            If sSQLDxxT Is Nothing Then sSQLDxxT = SQLCreate(tableName, dtData)
            Dim cmd As New SqlCommand(sSQLDxxT.ToString, con, trans)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Dim bulkCopy As SqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, trans)
            bulkCopy.BatchSize = dtData.Rows.Count
            bulkCopy.BulkCopyTimeout = 0
            bulkCopy.DestinationTableName = tableName
            Try
                bulkCopy.WriteToServer(dtData)
            Catch ex As Exception
                trans.Rollback()
                con.Close()
                Dim errorMessage As String = GetBulkCopyFailedData(gsConnectionString, dtGrid, bulkCopy.DestinationTableName, SQLStore)
                Return False
            End Try
            cmd = New SqlCommand(SQLStore, con, trans)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            trans.Commit()
            con.Close()
        Catch ex As Exception
            trans.Rollback()
            D99C0008.MsgL3(ex.Message)
            con.Close()
            Return False
        End Try
        Return True
    End Function


    Private Function GetDataType(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sField As String) As String
        Dim width As Integer = 1000
        If tdbg Is Nothing OrElse IndexOfColumn(tdbg, sField) < 0 Then GoTo 1
        Select Case tdbg.Columns(sField).DataType.Name
            Case "String"
                If tdbg IsNot Nothing AndAlso tdbg.Columns(sField).DataWidth > 0 Then width = tdbg.Columns(sField).DataWidth
1:
                Return "NVarchar(" & width & ")"
            Case Else
                Return tdbg.Columns(sField).DataType.Name
        End Select
    End Function
    Private Function SQLCreate(ByVal tableName As String, ByVal dtData As DataTable, Optional ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Nothing) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("CREATE TABLE " & tableName & " (" & vbCrLf)
        For i As Integer = 0 To dtData.Columns.Count - 1
            If i > 0 Then sSQL.Append(", " & vbCrLf)
            Select Case dtData.Columns(i).DataType.Name
                Case "Boolean"
                    sSQL.Append(dtData.Columns(i).ColumnName & " Bit")
                Case "Decimal"
                    sSQL.Append(dtData.Columns(i).ColumnName & " Decimal(28, 8)")
                Case "DateTime"
                    sSQL.Append(dtData.Columns(i).ColumnName & " DateTime")
                Case "Integer", "Int32", "Int16"
                    sSQL.Append(dtData.Columns(i).ColumnName & " Int")
                Case "Byte"
                    sSQL.Append(dtData.Columns(i).ColumnName & " TinyInt")
                Case Else
                    sSQL.Append(dtData.Columns(i).ColumnName & " " & GetDataType(tdbg, dtData.Columns(i).ColumnName)) ', arrNameU
            End Select
        Next
        sSQL.Append(")" & vbCrLf)
        Return sSQL
    End Function


    Private Function GetBulkCopyFailedData(ByVal connectionString As String, ByVal dtGrid As DataTable, ByVal tableName As String, ByVal SQLStore As String) As String
        Dim errorMessage As New StringBuilder("Bulk copy failures:" + Environment.NewLine)
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim bulkCopy As SqlBulkCopy = Nothing
        Dim tmpDataTable As New DataTable
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()
            transaction = connection.BeginTransaction()
            Dim cmd As New SqlCommand(SQLStore, connection, transaction)
            cmd.ExecuteNonQuery()
            bulkCopy = New SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)
            bulkCopy.DestinationTableName = tableName
            For i As Integer = 0 To dtGrid.Rows.Count - 1
                Try
                    tmpDataTable = dtGrid.Clone()
                    tmpDataTable.ImportRow(dtGrid.Rows(i))
                    bulkCopy.WriteToServer(tmpDataTable)
                Catch ex As Exception
                    MessageBox.Show("Error at row: " & i.ToString() & vbCrLf & ex.Message)
                    tdbg.Row = i
                End Try
            Next
        Catch ex As Exception
            Throw New Exception("Unable to document SqlBulkCopy errors. See inner exceptions for details.", ex)
        Finally
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            If connection.State <> ConnectionState.Closed Then
                connection.Close()
            End If
        End Try
        Return errorMessage.ToString()
    End Function

#End Region

End Class