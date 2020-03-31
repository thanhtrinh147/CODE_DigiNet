Public Class D13F2090
	Dim dtCaptionCols As DataTable
	'Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_BackPayTransID As Integer = 0     ' BackPayTransID
    Private Const COL_TransID As Integer = 1            ' TransID
    Private Const COL_SalaryVoucherID As Integer = 2    ' SalaryVoucherID
    Private Const COL_SalaryAdjustmentID As Integer = 3 ' SalaryAdjustmentID
    Private Const COL_IsSelected As Integer = 4         ' Chọn
    Private Const COL_EmployeeID As Integer = 5         ' Mã NV
    Private Const COL_EmployeeName As Integer = 6       ' Họ và tên
    Private Const COL_BlockID As Integer = 7            ' Khối
    Private Const COL_BlockName As Integer = 8          ' Tên khồi
    Private Const COL_DepartmentID As Integer = 9       ' Phòng ban
    Private Const COL_DepartmentName As Integer = 10    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 11            ' Tổ nhóm
    Private Const COL_TeamName As Integer = 12          ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 13        ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 14      ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 15            ' Chức vụ
    Private Const COL_DutyName As Integer = 16          ' Tên chức vụ
    Private Const COL_WorkID As Integer = 17            ' Công việc
    Private Const COL_WorkName As Integer = 18          ' Tên công việc
    Private Const COL_BirthDate As Integer = 19         ' Ngày sinh
    Private Const COL_SexName As Integer = 20           ' Giới tính
    Private Const COL_DateJoined As Integer = 21        ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 22          ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 23               ' Tuổi
    Private Const COL_StatusID As Integer = 24          ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 25        ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 26  ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 27     ' Mã NV phụ
    Private Const COL_PeriodFrom As Integer = 28        ' Từ kỳ
    Private Const COL_PeriodTo As Integer = 29          ' Đến kỳ
    Private Const COL_IsBackPay As Integer = 30         ' Đã hồi tố
    Private Const COL_BackPayDate As Integer = 31       ' Ngày hồi tố
    Private Const COL_BackPayResult As Integer = 32     ' Kết quả hồi tố
#End Region

    Private dtGrid As DataTable

    Private Sub D13F2090_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID)
        gbEnabledUseFind = False

        LoadLanguage()
        LoadTDBCombo()
        tdbg_NumberFormat()

        ResetGrid()
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 1, 2)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_DateJoined, COL_DateLeft, COL_BackPayDate)

        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13F2090_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
       
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_nhan_vien_hoi_to_luongF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh sÀch nh¡n vi£n häi tç l§¥ng
        '================================================================ 
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ten_nhan_vien") 'Tên nhân viên
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbg.Columns(COL_IsSelected).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
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
        tdbg.Columns(COL_BirthDate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_SexName).Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_DateJoined).Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_DateLeft).Caption = rl3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbg.Columns(COL_Age).Caption = rl3("Tuoi") 'Tuổi
        tdbg.Columns(COL_StatusID).Caption = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbg.Columns(COL_StatusName).Caption = rl3("Ten_trang_thai_lam_viec") 'Tên trạng thái làm việc
        tdbg.Columns(COL_AttendanceCardNo).Caption = rl3("Ma_the_cham_cong") 'Mã thẻ chấm công
        tdbg.Columns(COL_RefEmployeeID).Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns(COL_PeriodFrom).Caption = rl3("Tu_ky") 'Từ kỳ
        tdbg.Columns(COL_PeriodTo).Caption = rl3("Den_ky") 'Đến kỳ
        tdbg.Columns(COL_IsBackPay).Caption = rl3("Da_hoi_to") 'Đã hồi tố
        tdbg.Columns(COL_BackPayDate).Caption = rl3("Ngay_hoi_to") 'Ngày hồi tố
        tdbg.Columns(COL_BackPayResult).Caption = rl3("Ket_qua_hoi_to") 'Kết quả hồi tố
        '================================================================ 
        tsmBackPay.Text = rl3("_Hoi_to_luong") '&Hồi tố lương
        mnsBackPay.Text = tsmBackPay.Text
        tsmViewResult.Text = rl3("_Xem_ket_qua") '&Xem kết quả
        mnsViewResult.Text = tsmViewResult.Text
        tsmCancelResult.Text = rL3("Huy_ket_q_ua") 'Hủy kết q&uả
        mnsCancelResult.Text = tsmCancelResult.Text
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        'Load tdbcPeriod
        LoadCboPeriodReport(tdbcPeriod, "D09", gsDivisionID)
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey1 As String = "", Optional ByVal sKey2 As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD13P2090()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = "IsSelected = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("SalaryAdjustmentID")}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If

        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey1 <> "" And sKey2 <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TransID=" & SQLString(sKey1) & " and BackPayTransID=" & SQLString(sKey2), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If

    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsUsed.Checked Then
            strFilter = "IsSelected=True"
        Else
            If sFind <> "" Then strFilter = "IsSelected=True" & " Or " & sFind
        End If

        If sFilter.ToString <> "" Then
            If strFilter <> "" Then
                strFilter &= " AND " & sFilter.ToString
            Else
                strFilter = sFilter.ToString
            End If
        End If
        dtGrid.DefaultView.RowFilter = strFilter
        ResetGrid()
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BackPayResult).NumberFormat = "N3"
    End Sub

    Private Sub ResetGrid()
        tsbFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        tsbListAll.Enabled = tsbFind.Enabled 'Mờ khi  chkIsUsed.Checked = True
        tsmFind.Enabled = tsbFind.Enabled
        mnsFind.Enabled = tsbFind.Enabled
        tsmListAll.Enabled = tsbFind.Enabled
        mnsListAll.Enabled = tsbFind.Enabled

        tsmBackPay.Enabled = tdbg.RowCount > 0
        mnsBackPay.Enabled = tsmBackPay.Enabled

        tsmViewResult.Enabled = tdbg.RowCount > 0
        mnsViewResult.Enabled = tsmViewResult.Enabled

        tsmCancelResult.Enabled = tdbg.RowCount > 0
        mnsCancelResult.Enabled = tsmCancelResult.Enabled

        FooterTotalGrid(tdbg, COL_EmployeeID)
        FooterSumNew(tdbg, COL_BackPayResult)
    End Sub

    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose("Kỳ")
            tdbcPeriod.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkIsUsed)

    End Sub

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

#End Region

#Region "Menu"

    Private Function AllowActive(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        dr = dtGrid.Select("IsSelected = 1")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_IsSelected
            tdbg.Row = 0
            Return False
        End If

        Return True
    End Function

    Private Sub tsmBackPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBackPay.Click, mnsBackPay.Click
        Dim dr() As DataRow = Nothing
        ' .bSaved = False
        If Not AllowActive(dr) Then Exit Sub

        Dim sSQL As String = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString & vbCrLf
        sSQL &= SQLStoreD13P5555(0)

        If Not CheckStore(sSQL) Then Exit Sub
        '** Lưu ý: Khi gọi form D13F2091, truyền biến: @PeriodFrom (Min(Grid.PeriodFrom)), @PeriodTo (Max(Grid.PeriodTo)) cho form gọi.
        Dim f As New D13F2091
        Dim sMax As String = dtGrid.Compute("Max(YearMonthTo)", "IsSelected=1").ToString
        Dim sMin As String = dtGrid.Compute("Min(YearMonthFrom)", "IsSelected=1").ToString
        f.PeriodFrom = L3Right(sMin, 2) & "/" & L3Left(sMin, 4)
        f.PeriodTo = L3Right(sMax, 2) & "/" & L3Left(sMax, 4)
        f.ShowDialog()
        If f.bSaved Then
            dtGrid = Nothing
            LoadTDBGrid(True, tdbg.Columns(COL_TransID).Text, tdbg.Columns(COL_BackPayTransID).Text)
        End If
        f.Dispose()
    End Sub

    Private Sub tsmViewResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmViewResult.Click, mnsViewResult.Click
        Dim dr() As DataRow = Nothing
        If Not AllowActive(dr) Then Exit Sub

        Dim sSQL As String = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString & vbCrLf
        sSQL &= SQLStoreD13P5555(1)

        If Not CheckStore(sSQL) Then Exit Sub
        '** Lưu ý: Khi gọi form D13F2091, truyền biến: @PeriodFrom (Min(Grid.PeriodFrom)), @PeriodTo (Max(Grid.PeriodTo)) cho form gọi.
        Dim f As New D13F2092
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsmCancelResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCancelResult.Click, mnsCancelResult.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim dr() As DataRow = Nothing
        If Not AllowActive(dr) Then Exit Sub

        Dim sSQL As String = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString & vbCrLf
        sSQL &= SQLStoreD13P5555(2)

        If Not CheckStore(sSQL) Then Exit Sub
        sSQL = SQLStoreD13P2093()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)

        If bRunSQL Then
            SaveOK()
            dtGrid = Nothing
            LoadTDBGrid(True, tdbg.Columns(COL_TransID).Text, tdbg.Columns(COL_BackPayTransID).Text)
        Else
            SaveNotOK()
        End If
    End Sub

#End Region

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

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
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

#Region "tdbg event"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsSelected
                tdbg.UpdateData()
                ResetGrid()
        End Select
    End Sub


    Dim sFilter As New System.Text.StringBuilder()
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

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsSelected
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            Exit Sub
        End If
        '  If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsSelected, COL_IsBackPay 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_Age, COL_BackPayResult 'Chặn chỉ nhập Số  
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_PeriodFrom, COL_PeriodTo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
        End Select
    End Sub

    'Lưu ý: gọi hàm ResetFilter(tdbg, sFilter, bRefreshFilter) tại btnFilter_Click và tsbListAll_Click
    'Bổ sung vào đầu sự kiện tdbg_DoubleClick(nếu có) câu lệnh If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub

#End Region

#Region "SQL"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:49:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete bang tam truoc khi insert" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D13F2090'"

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:51:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByRef dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If dr.Length > 0 Then sSQL.Append("-- Insert vao bang tam" & vbCrLf)

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("Key04ID, [Num01]")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2090") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("TransID")) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("EmployeeID")) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("SalaryAdjustmentID")) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("BackPayTransID")) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item("IsBackPay"))) 'Num01, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:59:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        '-- 0: Hồi tố lương	; 1: Xem kết quả; 2: Hủy kết quả
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2090") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2090
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 02:09:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2090() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D13P2090 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DisvisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtStrEmployeeName, gbUnicode) & COMMA 'StrEmployeeName, nvarchar[500], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D13F2090") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2093
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 02:11:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2093() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Guy ket qua hoi to" & vbCrlf)
        sSQL &= "Exec D13P2093 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function


#End Region


End Class