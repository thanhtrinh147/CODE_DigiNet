Public Class D13F1240
	Dim dtCaptionCols As DataTable
	'Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D13F1240"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Private dtGrid, dtDetail As DataTable
    Dim bKeyPress As Boolean = False
    Dim bChangeRow As Boolean = True 'Kiểm tra xem có được di chuyển qua dòng khác không
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Dim bSavedOK As Boolean = False
    Dim bReLoad As Boolean = False 'Cờ để biết form_load đầu tiên
    Dim iPerMe As Integer

    Dim sTransTypeID As String = ""


#Region "Const of tdbg"
    Private Const COL_TransTypeID As Integer = 0      ' TransTypeID
    Private Const COL_TransTypeName As Integer = 1    ' Diễn giải
    Private Const COL_TransactionID As Integer = 2    ' TransactionID
    Private Const COL_TransactionName As Integer = 3  ' Nghiệp vụ
    Private Const COL_Notes As Integer = 4            ' Ghi chú
    Private Const COL_Disabled As Integer = 5         ' KSD
    Private Const COL_CreateUserID As Integer = 6     ' CreateUserID
    Private Const COL_CreateDate As Integer = 7       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 8 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 9   ' LastModifyDate
    Private Const COL_DAGroupID As Integer = 10       ' DAGroupID
#End Region

#Region "Const of tdbgDetail"
    Private Const COLD_AbsentTypeID As Integer = 0   ' Mã lọai công
    Private Const COLD_AbsentTypeName As Integer = 1 ' Tên loại công
    Private Const COLD_OrderNo As Integer = 2        ' Thứ tự hiển thị
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            iPerMe = ReturnPermission(_formIDPermission)
            LoadTDBCombo()
            LoadTDBDropDown()
            InputbyUnicode(Me, gbUnicode)

            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private Sub D56F1400_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Not bKeyPress Then Exit Sub
        If _FormState = EnumFormState.FormEdit Then
            If Not bSavedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtTransTypeName.Text <> "" Then
                If Not bSavedOK Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub

    'ID 62004
    Private Sub EnableMenu(ByVal bEnabled As Boolean)
        If dtGrid Is Nothing Then Exit Sub
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        btnNext.Enabled = bEnabled
        chkShowDisabled.Enabled = Not bEnabled
        tdbg.Enabled = Not bEnabled

        If _FormState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnNext.Text = rl3("Luu_va_Nhap__tiep")
        Else
            btnNext.Visible = False
        End If
        If btnNext.Visible And btnNext.Enabled Then
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
        End If

        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, False, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        End If
    End Sub

    Private Sub D56F1400_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetBackColorObligatory()
        ResetFooterGrid(tdbgDetail)
        tdbgDetail_LockedColumns()
        'ID 62004
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        LoadLanguage()
        'Gắn ở đây mục đích để co giãn form
        If Not _FormState = EnumFormState.FormAdd Then
            LoadTDBGrid()
        End If
        ResetColorGrid(tdbg)
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        If Not bReLoad Then bReLoad = True
        '**************************
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Mau_thiet_lap") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'MÉu thiÕt lËp
        '================================================================ 
        lblIsObjectTypeCaculateSal.Text = rl3("Doi_tuong") 'Đối tượng
        lblTransTypeName.Text = rl3("Dien_giai") 'Diễn giải
        lblTransactionID.Text = rl3("Nghiep_vu") 'Nghiệp vụ
        lblDAGroupID.Text = rl3("Nhom_truy_cap") 'Nhóm truy cập
        lblNotes.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkIsEmpStopWorking.Text = rl3("Nhan_vien_nghi_viec") 'Nhân viên nghỉ việc
        chkIsEmpWorking.Text = rl3("Nhan_vien_dang_lam_viecU") 'Nhân viên đang làm việc
        chkIsExceptNotAttendence.Text = rl3("Loai_nhan_vien_khong_co_du_lieu_cham_cong_tong_hop") 'Loại nhân viên không có dữ liệu chấm công tổng hợp
        chkIsExceptNotIncomeAdjust.Text = rl3("Loai_nhan_vien_khong_co_du_lieu_dieu_chinh_thu_nhap") 'Loại nhân viên không có dữ liệu điều chỉnh thu nhập
        chkIsExceptMaterity.Text = rl3("Loai_nhan_vien_nghi_thai_san") 'Loại nhân viên nghỉ thai sản
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        optIsObjectTypeCaculateSal2.Text = rl3("Ca_hai_U") 'Cả hai
        optIsObjectTypeCaculateSal1.Text = rl3("Nguoi_nuoc_ngoai") 'Người nước ngoài
        optIsObjectTypeCaculateSal0.Text = rl3("Nguoi_trong_nuoc") 'Người trong nước
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        GroupBox1.Text = rl3("Khoan_dieu_chinh_thu_nhap") 'Khoảng điều chỉnh thu nhập
        grpFilter.Text = rl3("Dieu_kien_loc") 'Điều kiện lọc
        '================================================================ 
        tdbcDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbcDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
        tdbcTransactionID.Columns("TransactionID").Caption = rl3("Ma") 'Mã
        tdbcTransactionID.Columns("TransactionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdAbsentTypeDateID.Columns("AbsentTypeDateID").Caption = rl3("Ma") 'Mã
        tdbdAbsentTypeDateID.Columns("AbsentTypeDateName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbgDetail.Columns(COLD_AbsentTypeID).Caption = rl3("Ma_loai_cong") 'Mã loại công
        tdbgDetail.Columns(COLD_AbsentTypeName).Caption = rl3("Ten_loai_cong") 'Tên loại công
        tdbgDetail.Columns(COLD_OrderNo).Caption = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        tdbg.Columns(COL_TransTypeName).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_TransactionName).Caption = rl3("Nghiep_vu") 'Nghiệp vụ
        tdbg.Columns(COL_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTransactionID
        sSQL = "-- Do nguon combo nghiep vu " & vbCrLf
        sSQL &= "SELECT  	ID as TransactionID, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as TransactionName" & vbCrLf
        sSQL &= "FROM		D09N5555 ('D09F1240', 'Transaction', '', '', '')" & vbCrLf
        LoadDataSource(tdbcTransactionID, sSQL, gbUnicode)

        'Load tdbcDAGroupID
        sSQL = "-- Do nguon combo Nhom truy cap " & vbCrLf
        sSQL &= "SELECT 	DAGroupID, DAGroupName" & UnicodeJoin(gbUnicode) & " As DAGroupName" & vbCrLf
        sSQL &= " FROM 	LEMONSYS.dbo.D00T0080 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE	 Disabled=0 " & vbCrLf
        sSQL &= "And (DAGroupID IN ( Select DAGroupID " & vbCrLf
        sSQL &= "From lemonsys.dbo.D00V0080 " & vbCrLf
        sSQL &= "Where UserID= " & SQLString(gsUserID) & ")  " & vbCrLf
        sSQL &= "OR 'LEMONADMIN' = " & SQLString(gsUserID) & ") " & vbCrLf
        sSQL &= "ORDER BY  DAGroupID" & vbCrLf
        LoadDataSource(tdbcDAGroupID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdAbsentTypeDateID
        sSQL = "-- Do nguon dropdown Ma loai cong " & vbCrLf
        sSQL &= "SELECT  		AbsentTypeDateID,AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " as AbsentTypeDateName " & vbCrLf
        sSQL &= "FROM        	D13T0118 WITH (NOLOCK)  " & vbCrLf
        sSQL &= "WHERE       	Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY   	AbsentTypeDateID"
        LoadDataSource(tdbdAbsentTypeDateID, sSQL, gbUnicode)
    End Sub

    Private Sub D56F1400_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            txtTransTypeName.Focus()
        Else
            chkDisabled.Focus()
        End If
    End Sub

    Private Sub D56F1400_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub D56F1400_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If tdbg.FilterActive Then
            bKeyPress = False
        Else
            If e.KeyChar <> ChrW(Keys.Enter) Then
                bKeyPress = True
            End If
        End If
    End Sub

    Private Sub LoadGroupFilter()
        Dim sSQL As String = SQLStoreD13P1130("Do nguon cho group dieu kien loc", 2, sTransTypeID, "0003")

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            chkIsEmpWorking.Checked = L3Bool(dt.Rows(0).Item("IsEmpWorking"))
            chkIsExceptMaterity.Checked = L3Bool(dt.Rows(0).Item("IsExceptMaterity"))
            chkIsExceptNotIncomeAdjust.Checked = L3Bool(dt.Rows(0).Item("IsExceptNotIncomeAdjust"))
            chkIsExceptNotAttendence.Checked = L3Bool(dt.Rows(0).Item("IsExceptNotAttendence"))
            chkIsEmpStopWorking.Checked = L3Bool(dt.Rows(0).Item("IsEmpStopWorking"))
            If L3Int(dt.Rows(0).Item("IsObjectTypeCaculateSal")) = 0 Then
                optIsObjectTypeCaculateSal0.Checked = True
            ElseIf L3Int(dt.Rows(0).Item("IsObjectTypeCaculateSal")) = 1 Then
                optIsObjectTypeCaculateSal1.Checked = True
            Else
                optIsObjectTypeCaculateSal2.Checked = True
            End If
        End If
    End Sub

    Private Sub LoadTDBGDetail()
        Dim sSQL As String = SQLStoreD13P1130("Do nguon cho Luoi khoan dieu chinh thu nhap", 1, sTransTypeID, "0002")

        dtDetail = ReturnDataTable(sSQL)
        LoadDataSource(tdbgDetail, dtDetail, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = ""
        sSQL &= SQLStoreD13P1130("Do nguon cho Luoi", 0, "", "")
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TransTypeID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then
            tsbAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If _FormState = EnumFormState.FormAdd Then Exit Sub
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            LockControlDetail(True)
            If dtDetail IsNot Nothing Then dtDetail.Clear()
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then LoadEdit()
        End If
    End Sub

    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_TransTypeName)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        'ID 62004
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit

        EnableMenu(True)
        bSavedOK = False
        bKeyPress = False
        chkDisabled.Focus()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        '    If Not CheckStoreCustom(SQLStoreD56P5555("Kiem tra truoc khi xoa", "DELETE")) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD13T1130() & vbCrLf)
        If tdbg.Columns(COL_TransactionID).Text = "0002" Then
            sSQL.Append(SQLDeleteD13T1131())
        Else
            sSQL.Append(SQLDeleteD13T1240)
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            If dtGrid.Rows.Count = 0 Then
                tsbAdd_Click(Nothing, Nothing)
            Else
                LoadEdit()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click
        'Lưới không có nút Hiển thị
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_TransTypeName}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr, )
        'End If
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
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

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        bKeyPress = False
        '
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_TransTypeID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

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
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub

        'Neu o thanh Filter thi k kiem tra va chay su kien RowColChange
        If tdbg.FilterActive Then
            bKeyPress = False
            Exit Sub
        End If

        If tdbg.Columns(COL_TransTypeID).Tag Is Nothing OrElse tdbg.Columns(COL_TransTypeID).Text <> tdbg.Columns(COL_TransTypeID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

#End Region

#Region "tdbgDetail"

    Private Sub tdbgDetail_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgDetail.AfterDelete
        FooterTotalGrid(tdbgDetail, COLD_AbsentTypeID)
    End Sub

    Private Sub tdbgDetail_AfterInsert(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgDetail.AfterInsert
        FooterTotalGrid(tdbgDetail, COLD_AbsentTypeID)
    End Sub

    Private Sub tdbgDetail_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ComboSelect
        tdbgDetail.UpdateData()
    End Sub

    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLD_OrderNo
                If Not L3IsNumeric(tdbgDetail.Columns(e.ColIndex).Text, EnumDataType.Int) Then e.Cancel = True
            Case COLD_AbsentTypeID
                If tdbgDetail.Columns(e.ColIndex).Text <> tdbgDetail.Columns(e.ColIndex).DropDown.Columns(tdbgDetail.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbgDetail_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLD_AbsentTypeID
                If tdbgDetail.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgDetail.Columns(COLD_AbsentTypeName).Text = ""
                    Exit Select
                End If
                tdbgDetail.Columns(COLD_AbsentTypeName).Text = tdbdAbsentTypeDateID.Columns("AbsentTypeDateName").Text
                If tdbgDetail.Columns(COLD_OrderNo).Text = "" Then
                    tdbgDetail.Columns(COLD_OrderNo).Text = (L3Int(dtDetail.Compute("Max(OrderNo)", "")) + 1).ToString
                End If
            Case COLD_AbsentTypeName
            Case COLD_OrderNo
        End Select
    End Sub

    Private Sub tdbgDetail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        Select Case tdbg.Col
            Case COLD_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

#End Region

    Private Sub chkDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDisabled.Click
        bKeyPress = True
    End Sub

    Private Sub chkIsEmpWorking_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsEmpWorking.CheckStateChanged
        If chkIsEmpWorking.Checked Then
            chkIsExceptMaterity.Enabled = True
            chkIsExceptNotAttendence.Enabled = True
            chkIsExceptNotIncomeAdjust.Enabled = True
        Else
            chkIsExceptMaterity.Enabled = False
            chkIsExceptNotAttendence.Enabled = False
            chkIsExceptNotIncomeAdjust.Enabled = False
            chkIsExceptMaterity.Checked = False
            chkIsExceptNotAttendence.Checked = False
            chkIsExceptNotIncomeAdjust.Checked = False
        End If
    End Sub

    Dim bTemp As Boolean = False
    Private Function SaveData(ByVal sender As System.Object) As Boolean
        bSavedOK = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState
            Case EnumFormState.FormAdd
                'Sinh IGE cho khóa của Phiếu trước
                If sTransTypeID = "" Then sTransTypeID = CreateIGE("D13T1130", "TransTypeID", "13", "TT", gsStringKey)
                '****************************************************************
                sSQL.Append(SQLInsertD13T1130.ToString & vbCrLf)
                If ReturnValueC1Combo(tdbcTransactionID).ToString = "0002" Then
                    sSQL.Append(SQLInsertD13T1131s().ToString & vbCrLf)
                Else
                    sSQL.Append(SQLInsertD13T1240("IsEmpWorking", chkIsEmpWorking.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptMaterity", chkIsExceptMaterity.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptNotIncomeAdjust", chkIsExceptNotIncomeAdjust.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptNotAttendence", chkIsExceptNotAttendence.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsEmpStopWorking", chkIsEmpStopWorking.Checked).ToString & vbCrLf)
                    If optIsObjectTypeCaculateSal0.Checked Then
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 0).ToString & vbCrLf)
                    ElseIf optIsObjectTypeCaculateSal1.Checked Then
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 1).ToString & vbCrLf)
                    Else
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 2).ToString & vbCrLf)
                    End If
                End If
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1130().ToString & vbCrLf)
                If ReturnValueC1Combo(tdbcTransactionID).ToString = "0002" Then
                    sSQL.Append(SQLDeleteD13T1131().ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1131s().ToString & vbCrLf)
                Else
                    sSQL.Append(SQLDeleteD13T1240() & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsEmpWorking", chkIsEmpWorking.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptMaterity", chkIsExceptMaterity.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptNotIncomeAdjust", chkIsExceptNotIncomeAdjust.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsExceptNotAttendence", chkIsExceptNotAttendence.Checked).ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1240("IsEmpStopWorking", chkIsEmpStopWorking.Checked).ToString & vbCrLf)
                    If optIsObjectTypeCaculateSal0.Checked Then
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 0).ToString & vbCrLf)
                    ElseIf optIsObjectTypeCaculateSal1.Checked Then
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 1).ToString & vbCrLf)
                    Else
                        sSQL.Append(SQLInsertD13T1240("IsObjectTypeCaculateSal", 2).ToString & vbCrLf)
                    End If
                End If
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            bSavedOK = True
            bKeyPress = False
            bTemp = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, sTransTypeID)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, sTransTypeID)
            End Select
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadDefaultFilter()
        chkIsEmpStopWorking.Checked = True
        chkIsEmpWorking.Checked = True
        chkIsExceptMaterity.Checked = False
        chkIsExceptNotAttendence.Checked = False
        optIsObjectTypeCaculateSal2.Checked = True
    End Sub

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        sTransTypeID = ""
        tdbg.Columns(COL_TransTypeID).Tag = ""
        '********************
        bSavedOK = False
        bKeyPress = False
        bTemp = False
        '*******************
        ClearText(grpDetail)
        '  If dtDetail IsNot Nothing Then dtDetail.Clear()
        If tdbg.RowCount > 0 Then
            tdbcTransactionID.SelectedValue = tdbg.Columns(COL_TransactionID).Text
        Else
            tdbcTransactionID.SelectedIndex = 0 'Default Nghiệp vụ = với Nghiệp vụ mà con trỏ đang đứng ở Grid
        End If

        LoadDefaultFilter()
        LoadTDBGDetail()
        chkDisabled.Checked = False

        UnReadOnlyControl(True, tdbcTransactionID)
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        txtTransTypeName.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TransTypeID).Tag = tdbg.Columns(COL_TransTypeID).Text
        '************************
        'Gán dữ liệu
        sTransTypeID = tdbg.Columns(COL_TransTypeID).Text
        txtTransTypeName.Text = tdbg.Columns(COL_TransTypeName).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        tdbcTransactionID.SelectedValue = tdbg.Columns(COL_TransactionID).Text
        VisibleControlbyransactionID()
        tdbcDAGroupID.SelectedValue = tdbg.Columns(COL_DAGroupID).Text
        txtNotes.Text = tdbg.Columns(COL_Notes).Text

        If tdbg.Columns(COL_TransactionID).Text = "0003" Then
            LoadGroupFilter()
        Else
            LoadTDBGDetail()
        End If
        '************************
        ReadOnlyControl(tdbcTransactionID)
        chkDisabled.Visible = True
        bKeyPress = False
    End Sub

    Private Function AllowSave() As Boolean
        If txtTransTypeName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtTransTypeName.Focus()
            Return False
        End If
        If tdbcTransactionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nghiep_vu"))
            tdbcTransactionID.Focus()
            Return False
        End If
        If ReturnValueC1Combo(tdbcTransactionID).ToString = "0002" Then
            tdbgDetail.UpdateData()
            If tdbgDetail.RowCount <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbgDetail.Focus()
                Return False
            End If
            For i As Integer = 0 To tdbgDetail.RowCount - 1
                If tdbgDetail(i, COLD_AbsentTypeID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ma_loai_cong"))
                    tdbgDetail.Focus()
                    tdbgDetail.SplitIndex = SPLIT0
                    tdbgDetail.Col = COLD_AbsentTypeID
                    tdbgDetail.Bookmark = i
                    Return False
                End If
            Next

            For i As Integer = 0 To tdbgDetail.RowCount - 2
                For j As Integer = i + 1 To tdbgDetail.RowCount - 1
                    If tdbgDetail(i, COLD_AbsentTypeID).ToString = tdbgDetail(j, COLD_AbsentTypeID).ToString Then
                        D99C0008.MsgDuplicatePKey() ' Mã này đã tồn tại.
                        tdbgDetail.Focus()
                        tdbgDetail.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                        tdbgDetail.Col = COLD_AbsentTypeID 'Tùy theo yêu cầu mỗi Form
                        tdbgDetail.Bookmark = j 'Tùy theo yêu cầu mỗi Form
                        Return False
                    End If
                Next
                For j As Integer = i + 1 To tdbgDetail.RowCount - 1
                    If tdbgDetail(i, COLD_OrderNo).ToString = tdbgDetail(j, COLD_OrderNo).ToString Then
                        D99C0008.MsgL3(rL3("Thu_tu_hien_thi_khong_duoc_trung"))
                        tdbgDetail.Focus()
                        tdbgDetail.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                        tdbgDetail.Col = COLD_OrderNo 'Tùy theo yêu cầu mỗi Form
                        tdbgDetail.Bookmark = j 'Tùy theo yêu cầu mỗi Form
                        Return False
                    End If
                Next
            Next
        Else
            If chkIsEmpStopWorking.Checked = False And chkIsEmpWorking.Checked = False Then
                D99C0008.MsgL3(rL3("Ban_phai_chon_dieu_kien_loc"))
                chkIsEmpWorking.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtTransTypeName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTransactionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COLD_AbsentTypeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbgDetail_LockedColumns()
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COLD_AbsentTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
    End Sub

#Region "Events tdbcDAGroupID"

    Private Sub tdbcDAGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.LostFocus
        If tdbcDAGroupID.FindStringExact(tdbcDAGroupID.Text) = -1 Then tdbcDAGroupID.Text = ""
    End Sub

#End Region

#Region "Events tdbcTransactionID"

    Private Sub tdbcTransactionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.LostFocus
        If tdbcTransactionID.FindStringExact(tdbcTransactionID.Text) = -1 Then tdbcTransactionID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Close, tdbcDAGroupID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tdbcTransactionID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tdbcTransactionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.SelectedValueChanged
        VisibleControlbyransactionID()
    End Sub

    Private Sub VisibleControlbyransactionID()
        If ReturnValueC1Combo(tdbcTransactionID).ToString = "0002" Then
            grpFilter.Visible = False
            GroupBox1.Visible = True
        Else 'If ReturnValueC1Combo(tdbcTransactionID).ToString = "0003" Then
            grpFilter.Visible = True
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If bAskSave Then 'Nhấn từ nút Lưu
            If AskSave() = Windows.Forms.DialogResult.No Then
                SetReturnFormView()
                Exit Sub
            End If

        Else 'Nhấn từ nút Không lưu
            bAskSave = True
        End If
        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If bAskSave Then 'Nhấn từ nút Lưu
            If AskSave() = Windows.Forms.DialogResult.No Then
                SetReturnFormView()
                Exit Sub
            End If
        Else 'Nhấn từ nút Không lưu
            bAskSave = True
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtTransTypeName.Text = "" And tdbgDetail.RowCount > 0 Then
            If tdbg.RowCount > 0 Then
                LoadEdit()
            End If
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            bAskSave = False
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadEdit()
        End If
1:
        SetReturnFormView()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1130
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 01:30:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1130(ByVal sComment As String, ByVal iMode As Integer, ByVal sTranTypeID As String, ByVal sTransactionID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D13P1130 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F1240") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sTranTypeID) & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(sTransactionID) & COMMA 'TransactionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1130
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:18:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1130() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu Master" & vbCrLf)
        sSQL.Append("Insert Into D13T1130(")
        sSQL.Append("TransTypeID, TransTypeName, Note, Disabled, CreateUserID, ")
        sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate, ")
        sSQL.Append("TransactionID, DAGroupID, NoteU, TransTypeNameU")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(sTransTypeID) & COMMA) 'TransTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, False) & COMMA) 'TransTypeName, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes, False) & COMMA) 'Note, varchar[500], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTransactionID)) & COMMA) 'TransactionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDAGroupID)) & COMMA) 'DAGroupID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes, True) & COMMA) 'NoteU, nvarchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, True)) 'TransTypeNameU, nvarchar[500], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1131
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:22:02
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1131() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa detail (dieu kien loc)" & vbCrLf)
        sSQL &= "Delete From D13T1131"
        sSQL &= " Where TransTypeID = " & SQLString(sTransTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1131s
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:33:23
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1131s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu detail (dieu kien loc)" & vbCrLf)
            sSQL.Append("Insert Into D13T1131(")
            sSQL.Append("TransTypeID, AbsentTypeID, OrderNo")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(sTransTypeID) & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgDetail(i, COLD_AbsentTypeID)) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbgDetail(i, COLD_OrderNo))) 'OrderNo, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1240
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:35:40
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1240(ByVal sTemplateItemID As String, ByVal sValue As Object) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert detail" & vbCrLf)
        sSQL.Append("Insert Into D13T1240(")
        sSQL.Append("TransTypeID, TemplateItemID, Value")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(sTransTypeID) & COMMA) 'TransTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sTemplateItemID) & COMMA) 'TemplateItemID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(sValue)) 'Value, tinyint, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1240
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:53:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1240() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa D13T1240" & vbCrLf)
        sSQL &= "Delete From D13T1240"
        sSQL &= " Where TransTypeID = " & SQLString(sTransTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1130
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 03:48:53
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1130() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu Edit" & vbCrLf)
        sSQL.Append("Update D13T1130 Set ")
        sSQL.Append("TransTypeName = " & SQLStringUnicode(txtTransTypeName, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNotes, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("DAGroupID = " & SQLString(ReturnValueC1Combo(tdbcDAGroupID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNotes, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("TransTypeNameU = " & SQLStringUnicode(txtTransTypeName, True)) 'nvarchar[500], NOT NULL
        sSQL.Append(" Where TransTypeID = " & SQLString(sTransTypeID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1130
    '# Created User: Hoàng Nhân
    '# Created Date: 21/01/2014 10:39:18
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1130() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa master" & vbCrlf)
        sSQL &= "Delete From D13T1130"
        sSQL &= " Where TransTypeID = " & SQLString(tdbg.Columns(COL_TransTypeID).Text)
        Return sSQL
    End Function
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, pnlchkShow)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB)
    End Sub

End Class