Public Class D13F1260
    Dim dtCaptionCols As DataTable
    'Dim dtCaptionCols As DataTable
    Private _formIDPermission As String = "D13F1260"
    Private iPer1250 As Integer = 0
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private dtGrid, dtDetail As DataTable
    Dim bChangeRow As Boolean = True 'Kiểm tra xem có được di chuyển qua dòng khác không
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Dim bSavedOK As Boolean = False
    Dim bReLoad As Boolean = False 'Cờ để biết form_load đầu tiên
    Dim iPerMe As Integer

    Dim sTransID As String = ""

    Dim bLoadFormState As Boolean = False

#Region "Const of tdbg - Total of Columns: 12"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_RefResultID As Integer = 1       ' Mã  tham chiếu
    Private Const COL_RefResultName As Integer = 2     ' Têm tham chiếu
    Private Const COL_ValidDateForm As Integer = 3     ' Hiệu lực từ
    Private Const COL_ValidDateTo As Integer = 4       ' Hiệu lực đến
    Private Const COL_Notes As Integer = 5             ' Ghi chú
    Private Const COL_Disabled As Integer = 6          ' Không sử dụng
    Private Const COL_IsEffective As Integer = 7       ' IsEffective
    Private Const COL_CreateDate As Integer = 8        ' CreateDate
    Private Const COL_CreateUserID As Integer = 9      ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 10   ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 11 ' LastModifyUserID
#End Region


#Region "Const of tdbg1 - Total of Columns: 6"
    Private Const COLD_TransID As Integer = 0    ' TransID
    Private Const COLD_OrderNum As Integer = 1   ' STT
    Private Const COLD_DivisionID As Integer = 2 ' Đơn vị
    Private Const COLD_BlockID As Integer = 3    ' Khối
    Private Const COLD_ProjectID As Integer = 4  ' Dự án
    Private Const COLD_Value As Integer = 5      ' Giá trị
#End Region

    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            iPer1250 = ReturnPermission(Me.Name)
            iPerMe = ReturnPermission(_formIDPermission)
            LoadTDBCombo()
            LoadTDBDropDown()
            InputbyUnicode(Me, gbUnicode)

            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
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
            If ReturnValueC1Combo(tdbcRefResultID) <> "" Then
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
        chkIsEffective.Enabled = Not bEnabled
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
        mnsDeleteRefResultID.Enabled = mnsDelete.Enabled
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Bang_tham_chieu_ket_qua_theo_thoi_gian") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'B¶ng tham chiÕu kÕt qu¶ theo théi gian
        '================================================================ 
        lblRefResultID.Text = rl3("Ma_tham_chieu") 'Mã tham chiếu
        lblValidDateForm.Text = rl3("Hieu_luc_tu") 'Hiệu lực từ
        lblNotes.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkIsEffective.Text = rL3("Hien_thi_danh_muc_het_hieu_luc") 'Hiển thị danh mục hết hiệu lực
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcRefResultID.Columns("RefResultID").Caption = rl3("Ma") 'Mã
        tdbcRefResultID.Columns("RefResultName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdProjectID.Columns("ProjectID").Caption = rl3("Ma") 'Mã
        tdbdProjectID.Columns("ProjectName").Caption = rl3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbdDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbdDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg1.Columns(COLD_OrderNum).Caption = rL3("STT") 'STT
        tdbg1.Columns(COLD_DivisionID).Caption = rl3("Don_vi") 'Đơn vị
        tdbg1.Columns(COLD_BlockID).Caption = rl3("Khoi") 'Khối
        tdbg1.Columns(COLD_ProjectID).Caption = rl3("Cong_trinh") 'Dự án
        tdbg1.Columns(COLD_Value).Caption = rl3("Gia_tri_") 'Giá trị
        tdbg.Columns(COL_RefResultID).Caption = rl3("Ma_tham_chieu") 'Mã tham chiếu
        tdbg.Columns(COL_RefResultName).Caption = rl3("Ten_tham_chieu") 'Tên tham chiếu
        tdbg.Columns(COL_ValidDateForm).Caption = rl3("Hieu_luc_tu") 'Hiệu lực từ
        tdbg.Columns(COL_ValidDateTo).Caption = rl3("Hieu_luc_den") 'Hiệu lực đến
        tdbg.Columns(COL_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        mnsDeleteRefResultID.Text = rl3("Xoa_ma_tham_chieu") 'Xóa mã tham chiếu
    End Sub


    Private Sub D13F1250_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        ResetFooterGrid(tdbg1)
        tdbg1_NumberFormat()
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        LoadLanguage()
        LoadOthers()
        LoadTDBGrid()
        ResetColorGrid(tdbg)
        SetBackColorObligatory()
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        If Not bReLoad Then bReLoad = True
        '**************************
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg1.Columns(COLD_Value).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg1, arr)
    End Sub

    Private Const D13_RefResult As String = "D13_RefResult"
    Private dtRefResultID As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcRefResultID
        sSQL = "-- Do nguon Ma tham chieu" & vbCrLf
        sSQL &= "SELECT  '+' as RefResultID, " & NewName & " as RefResultName, 0 As DisplayOrder,  0 AS [Disabled] " & vbCrLf
        sSQL &= "UNION ALL " & vbCrLf
        sSQL &= "SELECT 	LookupID AS RefResultID, DescriptionU AS RefResultName, 1 As DisplayOrder,[Disabled] " & vbCrLf
        sSQL &= "FROM 		D91T0320 " & vbCrLf
        sSQL &= "WHERE 		LookupType =  " & SQLString(D13_RefResult) & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RefResultID"
        dtRefResultID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRefResultID, dtRefResultID, gbUnicode)
    End Sub

    Private dtBlockID As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        LoadDataSource(tdbdDivisionID, ReturnTableDivisionIDD09("D09", True, gbUnicode), gbUnicode)
        'Load tdbdProjectID
        sSQL = "-- Do nguon DD du an " & vbCrLf & _
            "SELECT		'%' AS ProjectID, " & AllName & " AS ProjectName " & vbCrLf & _
            "UNION ALL" & vbCrLf & _
            "SELECT		ProjectID, DescriptionU As ProjectName " & vbCrLf & _
            "FROM		D09T1080 WITH (NOLOCK) " & vbCrLf & _
            "WHERE		Disabled=0 " & vbCrLf & _
            "ORDER BY	ProjectID"
        LoadDataSource(tdbdProjectID, sSQL, gbUnicode)

    End Sub
    Private bIsUseBlockID As Boolean = False
    Private Sub LoadOthers()
        Dim sSQL As String = ""
        sSQL = "-- Kiem tra su dung khoi " & vbCrLf & _
                "SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) "
        bIsUseBlockID = L3Bool(ReturnScalar(sSQL))
        If bIsUseBlockID Then dtBlockID = ReturnTableBlockID(, , gbUnicode)
        tdbg1.Splits(0).DisplayColumns(COLD_BlockID).Visible = bIsUseBlockID
    End Sub
    Private Sub LoadDropdownBlockID(sDivisionID As String)
        If dtBlockID Is Nothing Then Exit Sub
        If sDivisionID = "%" Then
            LoadDataSource(tdbdBlockID, dtBlockID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdBlockID, ReturnTableFilter(dtBlockID, "BlockID = '%' Or DivisionID =" & SQLString(sDivisionID), True), gbUnicode)
        End If
    End Sub
    Private Sub D56F1400_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            tdbcRefResultID.Focus()
        Else
            c1dateValidDateForm.Focus()
        End If
    End Sub

    Private Sub D56F1400_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub
    Private Sub Loadtdbg1()

        Dim sSQL As String = SQLStoreD13P1250(1, "Detail")
        dtDetail = ReturnDataTable(sSQL)
        LoadDataSource(tdbg1, dtDetail, gbUnicode)
        'dtDetail.DefaultView.RowFilter = "TransID = " & SQLString(sTransID)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = ""
        sSQL &= SQLStoreD13P1250(0, "Master")
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TransID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then
                tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            Else
                tdbg.Row = 0
                'LoadEdit()
            End If

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

        If Not chkIsEffective.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "IsEffective =0"
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
        FooterTotalGrid(tdbg, COL_RefResultID)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click, chkIsEffective.Click
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
    Private Sub mnsInherit_Click(sender As Object, e As EventArgs) Handles mnsInherit.Click, tsbInherit.Click
        _FormState = EnumFormState.FormCopy
        EnableMenu(True)
        sTransID = ""
        UnReadOnlyControl(tdbcRefResultID)
        c1dateValidDateForm.Value = ""
        c1dateValidDateTo.Value = ""
        txtNotes.Text = ""
    End Sub


    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit

        EnableMenu(True)
        bSavedOK = False
        c1dateValidDateForm.Focus()
    End Sub
    Private Sub Delete(iMode As Integer, iModeCheckStore As Integer, sTrans As String)
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD13P5555(iModeCheckStore)) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLStoreD13P1251(iMode, sTrans))
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

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        Delete(1, 2, sTransID)
    End Sub
    Private Sub mnsDeleteRefResultID_Click(sender As Object, e As EventArgs) Handles mnsDeleteRefResultID.Click
        Delete(0, 2, tdbg.Columns(COL_TransID).Text)
    End Sub


    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr, )
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
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
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

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#Region "Events tdbcRefResultID with txtRefResultName"

    Private Sub tdbcRefResultID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRefResultID.SelectedValueChanged
        If tdbcRefResultID.SelectedValue Is Nothing Then
            txtRefResultName.Text = ""
        Else

            If tdbcRefResultID.Text = "+" Then
                Dim frm As New D13F1251
                frm.FormState = EnumFormState.FormAdd
                frm.ShowDialog()
                If frm.bSaved Then
                    LoadTDBCombo()
                    tdbcRefResultID.SelectedValue = frm.RefResultID
                Else
                    tdbcRefResultID.SelectedValue = ""
                    txtRefResultName.Text = ""
                End If
                GoTo 1
            End If
            txtRefResultName.Text = tdbcRefResultID.Columns(1).Value.ToString
        End If
1:
        btnEditRef.Enabled = ReturnValueC1Combo(tdbcRefResultID) <> "" AndAlso iPer1250 >= EnumPermission.EditAdd
    End Sub

    Private Sub tdbcRefResultID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRefResultID.LostFocus
        If tdbcRefResultID.FindStringExact(tdbcRefResultID.Text) = -1 Then
            tdbcRefResultID.Text = ""
        End If
    End Sub

#End Region
#End Region

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0

    ' Lấy tọa độ Y của chuột click tới
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
        If tdbg.Columns(COL_TransID).Tag Is Nothing OrElse tdbg.Columns(COL_TransID).Text <> tdbg.Columns(COL_TransID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

#End Region


    Dim bTemp As Boolean = False


    ''' <summary>
    ''' Từ ngày phải nhỏ hơn bằng Đến ngày
    ''' </summary>
    ''' <param name="c1dateFrom"></param>
    ''' <param name="c1dateTo"></param>
    ''' <returns>True : Valid; False: Invalid</returns>
    ''' <remarks></remarks>
    Public Function CheckValidDateFromTo(ByVal c1dateFrom As C1.Win.C1Input.C1DateEdit, ByVal c1dateTo As C1.Win.C1Input.C1DateEdit, Optional ByVal tabSelection As System.Windows.Forms.TabControl = Nothing, Optional ByVal Index As Integer = -1, Optional ByVal bObligatory As Boolean = True) As Boolean
        'Chưa nhập giá trị Từ Đến
        If bObligatory And c1dateFrom.Text = "" And c1dateTo.Text = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ngay"))
            If tabSelection IsNot Nothing AndAlso Index <> -1 Then tabSelection.SelectedIndex = Index
            c1dateFrom.Focus()
            Return False
        ElseIf c1dateTo.Text = "" Then '  Chưa nhập Đến thì gán giá trị của Từ vào 
            'c1dateTo.Text = c1dateFrom.Text
        ElseIf c1dateFrom.Text = "" Then '  Chưa nhập Từ thì gán giá trị của Đến vào 
            ' c1dateFrom.Text = c1dateTo.Text
        Else
            If CDate(c1dateFrom.Text) > CDate(c1dateTo.Text) Then
                D99C0008.MsgL3(rL3("MSG000013"))
                If tabSelection IsNot Nothing AndAlso Index <> -1 Then tabSelection.SelectedIndex = Index
                c1dateTo.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        If tdbcRefResultID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblRefResultID.Text)
            tdbcRefResultID.Focus()
            Return False
        End If
        If c1dateValidDateForm.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(lblValidDateForm.Text)
            c1dateValidDateForm.Focus()
            Return False
        End If

        If Not CheckValidDateFromTo(c1dateValidDateForm, c1dateValidDateTo) Then Return False

        For i As Integer = 0 To tdbg1.RowCount - 2
            For j As Integer = i + 1 To tdbg1.RowCount - 1
                If L3String(tdbg1(i, COLD_DivisionID)) = L3String(tdbg1(j, COLD_DivisionID)) AndAlso L3String(tdbg1(i, COLD_BlockID)) = L3String(tdbg1(j, COLD_BlockID)) AndAlso L3String(tdbg1(i, COLD_ProjectID)) = L3String(tdbg1(j, COLD_ProjectID)) Then
                    D99C0008.MsgL3(rL3("Du_lieu_khong_hop_leU"))
                    tdbg1.Focus()
                    tdbg1.Col = COLD_ProjectID
                    tdbg1.Row = j
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcRefResultID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateValidDateForm.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        bSavedOK = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Dim bRunSQL As Boolean
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666().ToString & vbCrLf)
        bRunSQL = ExecuteSQL(sSQL.ToString)
        If Not bRunSQL Then Me.Cursor = Cursors.Default : Return False
        Dim iMode As Integer = 0
        If _FormState = EnumFormState.FormEdit Then iMode = 1
        If Not CheckStore(SQLStoreD13P5555(iMode)) Then Me.Cursor = Cursors.Default : Return False
        sSQL = New StringBuilder()
        Select Case _FormState
            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                If sTransID = "" Then sTransID = CreateIGE("D13T1250", "TransID", "13", "SE", gsStringKey)
                sSQL.Append(SQLInsertD13T1250().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD13T1251().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1251s.ToString())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1250().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD13T1251().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1251s.ToString())
        End Select

        bRunSQL = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            bSavedOK = True
            bTemp = True
            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    LoadTDBGrid(True, sTransID)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, sTransID)
            End Select
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        sTransID = ""
        tdbg.Columns(COL_TransID).Tag = ""
        '********************
        bSavedOK = False
        bTemp = False
        '*******************
        ClearText(grpDetail)


        Loadtdbg1()
        UnReadOnlyControl(True, tdbcRefResultID)
        dtRefResultID.DefaultView.RowFilter = "Disabled = 0"
        LockControlDetail(False)
        '*******************
        tdbcRefResultID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TransID).Tag = tdbg.Columns(COL_TransID).Text
        '************************
        'Gán dữ liệu
        sTransID = tdbg.Columns(COL_TransID).Text
        tdbcRefResultID.SelectedValue = tdbg.Columns(COL_RefResultID).Text
        c1dateValidDateForm.Value = tdbg.Columns(COL_ValidDateForm).Text
        c1dateValidDateTo.Value = tdbg.Columns(COL_ValidDateTo).Text
        txtNotes.Text = tdbg.Columns(COL_Notes).Text
        dtRefResultID.DefaultView.RowFilter = ""
        Loadtdbg1()
        '************************
        ReadOnlyControl(tdbcRefResultID)
        Me.Refresh()
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
        If _FormState = EnumFormState.FormAdd AndAlso tdbcRefResultID.Text = "" And tdbg1.RowCount > 0 Then
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
    Private Sub tdbg1_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg1.UnboundColumnFetch
        Select Case e.Col
            Case COLD_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub


    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        tdbg1.UpdateData()
    End Sub


    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLD_DivisionID, COLD_BlockID, COLD_ProjectID
                If tdbg1.Columns(e.ColIndex).Text <> tdbg1.Columns(e.ColIndex).DropDown.Columns(tdbg1.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub


    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLD_TransID
            Case COLD_DivisionID
                tdbg1.Columns(COLD_BlockID).Text = ""
            Case COLD_BlockID

            Case COLD_ProjectID

            Case COLD_Value
        End Select
    End Sub


    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg1.Col
            'Case COLD_DivisionID
            '    LoadtdbdDivisionID(tdbg1(tdbg1.Row, COL_).Tostring)
            Case COLD_BlockID
                LoadDropdownBlockID(tdbg1(tdbg1.Row, COLD_DivisionID).ToString)
                'Case COLD_ProjectID
                '    LoadtdbdProjectID(tdbg1(tdbg1.Row, COL_).Tostring)
        End Select
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, pnlchkShow)
        AnchorForControl(EnumAnchorStyles.TopRightBottom, grpDetail, tdbg1)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnlB)
    End Sub


#Region "SQl function"


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1250
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 09:26:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1250(iMode As Integer, sCommand As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi " & sCommand & vbCrLf)
        sSQL &= "Exec D13P1250 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(sTransID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:09:11
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi xoa/luu ma tham chieu" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sTransID) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateValidDateForm.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateValidDateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T0320
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:13:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T0320() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa ma tham chieu" & vbCrLf)
        sSQL &= "Delete From D91T0320"
        sSQL &= " Where "
        sSQL &= "LookupType = " & SQLString(D13_RefResult) & " And "
        sSQL &= "LookupID = " & SQLString(tdbg.Columns(COL_RefResultID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1251
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:27:59
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1251(iMode As Integer, sRefResultID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrLf)
        sSQL &= "Exec D13P1251 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(sRefResultID) & COMMA 'RefResultID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:32:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu vao bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:33:45
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Them du lieu vao bang tam" & vbCrLf)
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, Date01, Date02, " & vbCrLf)
        sSQL.Append("FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRefResultID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLDateSave(c1dateValidDateForm.Value) & COMMA) 'Date01, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateValidDateTo.Value) & COMMA & vbCrLf) 'Date02, datetime, NULL
        sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1250
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:56:24
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1250() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Them du lieu master" & vbCrLf)
        sSQL.Append("Insert Into D13T1250(")
        sSQL.Append("CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, Notes, " & vbCrLf)
        sSQL.Append("TransID, RefResultID, ValidDateForm, ValidDateTo")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes, True) & COMMA & vbCrLf) 'Notes, nvarchar[1000], NOT NULL
        sSQL.Append(SQLString(sTransID) & COMMA) 'TransID [KEY], varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRefResultID)) & COMMA) 'RefResultID, varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1dateValidDateForm.Value) & COMMA & vbCrLf) 'ValidDateForm, datetime, NOT NULL
        sSQL.Append(SQLDateSave(c1dateValidDateTo.Value)) 'ValidDateTo, datetime, NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1250
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 11:05:01
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1250() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Sua lieu luu master" & vbCrLf)
        sSQL.Append("Update D13T1250 Set ")
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("Notes = " & SQLStringUnicode(txtNotes, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("TransID = " & SQLString(sTransID) & COMMA) '[KEY], varchar[50], NOT NULL
        sSQL.Append("ValidDateForm = " & SQLDateSave(c1dateValidDateForm.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("ValidDateTo = " & SQLDateSave(c1dateValidDateTo.Value)) 'datetime, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransID = " & SQLString(sTransID))

        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1251
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 11:02:13
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1251() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang D13T1251" & vbCrLf)
        sSQL &= "Delete From D13T1251"
        sSQL &= " Where TransID = " & SQLString(sTransID)
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1251s
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/05/2016 10:58:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1251s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Them du lieu detail" & vbCrLf)
            sSQL.Append("Insert Into D13T1251(")
            sSQL.Append("TransID, OrderNum, DivisionID, BlockID, ProjectID, " & vbCrLf)
            sSQL.Append("Value")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(sTransID) & COMMA) 'TransID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNum, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COLD_DivisionID)) & COMMA) 'DivisionID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COLD_BlockID)) & COMMA) 'BlockID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COLD_ProjectID)) & COMMA & vbCrLf) 'ProjectID, varchar[50], NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COLD_Value), tdbg1.Columns(COLD_Value).NumberFormat)) 'Value, decimal, NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


#End Region
    Private Sub btnEditRef_Click(sender As Object, e As EventArgs) Handles btnEditRef.Click
        Dim frm As New D13F1251
        frm.RefResultID = ReturnValueC1Combo(tdbcRefResultID)
        frm.FormState = EnumFormState.FormEdit
        frm.ShowDialog()
        If frm.bSaved AndAlso _FormState <> EnumFormState.FormEdit Then
            LoadTDBCombo()

            LoadTDBGrid(, sTransID)
            ' tdbcRefResultID.SelectedValue = frm.RefResultID
        End If
    End Sub

End Class