Public Class D13F1200
	Dim dtCaptionCols As DataTable
	'Dim dtCaptionCols As DataTable
    Private _formIDPermission As String = "D13F1200"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Private dtGrid As DataTable
    Dim bKeyPress As Boolean = False
    Dim bChangeRow As Boolean = True 'Kiểm tra xem có được di chuyển qua dòng khác không
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Dim bSavedOK As Boolean = False
    Dim bReLoad As Boolean = False 'Cờ để biết form_load đầu tiên
    Dim iPerMe As Integer

    Dim sTransID As String = ""



#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_OrderNum As Integer = 1               ' STT
    Private Const COL_CurrencyID As Integer = 2        ' Mã
    Private Const COL_CurrencyName As Integer = 3      ' Tên
    Private Const COL_ExchangeRate As Integer = 4      ' Tỷ giá
    Private Const COL_ValidDate As Integer = 5         ' Hiệu lực từ
    Private Const COL_Description As Integer = 6       ' Diễn giải
    Private Const COL_Disabled As Integer = 7          ' KSD
    Private Const COL_CreateUserID As Integer = 8      ' CreateUserID
    Private Const COL_CreateDate As Integer = 9        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 10 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 11   ' LastModifyDate
#End Region


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            InputbyUnicode(Me, gbUnicode)
            iPerMe = ReturnPermission(_formIDPermission)
            InputNumber(cneExchangeRate, SqlDbType.Decimal, DxxFormat.ExchangeRateDecimals, , 28, 8)
            lblExchangeRateText.Text = ""
            LoadTDBCombo()

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
            If txtDescription.Text <> "" Then
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
        '  If dtGrid Is Nothing Then Exit Sub
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
        tdbg_NumberFormat()
        LoadLanguage()

        InputDateInTrueDBGrid(tdbg, COL_ValidDate)
        InputDateCustomFormat(c1dateValidDate, c1dateValidDateFrom, c1dateValidDateTo)
        c1dateValidDateFrom.Value = Date.Now
        c1dateValidDateTo.Value = Date.Now

        ResetGrid()
        ResetColorGrid(tdbg)
        If Not bReLoad Then bReLoad = True
        '**************************
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_ty_giaF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc tú giÀ
        '================================================================ 
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblValidDate.Text = rl3("Hieu_luc_tu") 'Hiệu lực từ
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblExchangeRate.Text = rl3("Ty_gia") 'Tỷ giá
        lblValidDateFrom.Text = rl3("Hieu_luc") 'Hiệu lực
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("CurrencyName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Ma") 'Mã
        tdbg.Columns(COL_CurrencyName).Caption = rl3("Ten") 'Tên
        tdbg.Columns(COL_ExchangeRate).Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_ValidDate).Caption = rl3("Hieu_luc_tu") 'Hiệu lực từ
        tdbg.Columns(COL_Description).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
    End Sub


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcCurrencyID
        sSQL = "--Do nguon combo loai tien" & vbCrLf
        sSQL &= "SELECT	T1.CurrencyID, T1.CurrencyName" & UnicodeJoin(gbUnicode) & " as CurrencyName, T2.BaseCurrencyID, T1.Operator " & vbCrLf
        sSQL &= "FROM 		D91T0010 T1 WITH(NOLOCK)" & vbCrLf
        sSQL &= "CROSS JOIN	D91T0025 T2 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE		T1.CurrencyID <> T2.BaseCurrencyID" & vbCrLf
        sSQL &= "ORDER BY	T1.CurrencyID" & vbCrLf

        LoadDataSource(tdbcCurrencyID, sSQL, gbUnicode)
    End Sub

    Private Sub D56F1400_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            c1dateValidDate.Focus()
        Else
            c1dateValidDateFrom.Focus()
        End If
    End Sub

    Private Sub D56F1400_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
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

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateValidDateFrom, c1dateValidDateTo) Then Return False
        Return True
    End Function


    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If Not AllowFilter() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = ""
        sSQL &= SQLStoreD13P1200()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TransID=" & SQLString(sKey), dt1.DefaultView.Sort)
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
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then LoadEdit()
        End If
    End Sub

    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_CurrencyName)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Events tdbcCurrencyID with txtCurrencyName"

    Private Sub tdbcCurrencyID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.SelectedValueChanged
        If tdbcCurrencyID.SelectedValue Is Nothing Then
            txtCurrencyName.Text = ""
            '   cneExchangeRate.Value = 0
        Else
            txtCurrencyName.Text = ReturnValueC1Combo(tdbcCurrencyID, "CurrencyName")
            '    cneExchangeRate.Value = Number(ReturnValueC1Combo(tdbcCurrencyID, "ExchangeRate"))
        End If
        SetExchangeRateText()
    End Sub

    Private Sub tdbcCurrencyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.LostFocus
        If tdbcCurrencyID.FindStringExact(tdbcCurrencyID.Text) = -1 Then
            tdbcCurrencyID.Text = ""
        End If
    End Sub

    Private Sub cneExchangeRate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneExchangeRate.ValueChanged
        SetExchangeRateText()
    End Sub

    Private Sub SetExchangeRateText()
        If ReturnValueC1Combo(tdbcCurrencyID, "Operator") = "0" Then
            lblExchangeRateText.Text = "1 " & ReturnValueC1Combo(tdbcCurrencyID, "CurrencyID") & " = " & SQLNumber(cneExchangeRate.Value, DxxFormat.ExchangeRateDecimals) & " " & ReturnValueC1Combo(tdbcCurrencyID, "BaseCurrencyID")
        Else
            lblExchangeRateText.Text = "1 " & ReturnValueC1Combo(tdbcCurrencyID, "CurrencyID") & " = 1/" & SQLNumber(cneExchangeRate.Value, DxxFormat.ExchangeRateDecimals) & " " & ReturnValueC1Combo(tdbcCurrencyID, "BaseCurrencyID")
        End If
    End Sub

#End Region

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
        c1dateValidDate.Focus()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = SQLDeleteD13T1200()

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            DeleteOK()
            RunAuditLog("ExchangeRate", "03", tdbcCurrencyID.Text, cneExchangeRate.Value.ToString)
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
        Dim arrColObligatory() As Integer = {COL_CurrencyID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr, )
        'End If
        Dim dr() As DataRow = dtCaptionCols.Select("FieldName=''")
        For Each row As DataRow In dr
            dtCaptionCols.Rows.Remove(row)
        Next
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = dtCaptionCols
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dtGrid 'Table load dữ liệu cho lưới
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    '	Cần sửa Tìm kiếm như sau:
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
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_CurrencyID}
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
        HotKeyCtrlVOnGrid(tdbg, e, COL_OrderNum)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNum
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_ExchangeRate 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
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

        If tdbg.Columns(COL_TransID).Tag Is Nothing OrElse tdbg.Columns(COL_TransID).Text <> tdbg.Columns(COL_TransID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        e.Value = (e.Row + 1).ToString
    End Sub
#End Region

    Private Sub chkDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDisabled.Click
        bKeyPress = True
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
                If sTransID = "" Then sTransID = CreateIGE("D13T1200", "TransID", "13", "ER", gsStringKey)
                '****************************************************************
                sSQL.Append(SQLInsertD13T1200)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1200)
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
                    RunAuditLog("ExchangeRate", "02", tdbcCurrencyID.Text, cneExchangeRate.Value.ToString)
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
        bKeyPress = False
        bTemp = False
        '*******************
        ClearText(grpDetail)

        lblExchangeRateText.Text = ""
        cneExchangeRate.Value = 0
        c1dateValidDate.Value = Date.Now
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        UnReadOnlyControl(tdbcCurrencyID, True)


        LockControlDetail(False)
        '*******************
        c1dateValidDate.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TransID).Tag = tdbg.Columns(COL_TransID).Text
        '************************
        'Gán dữ liệu
        sTransID = tdbg.Columns(COL_TransID).Text
        c1dateValidDate.Text = tdbg.Columns(COL_ValidDate).Text
        txtDescription.Text = tdbg.Columns(COL_Description).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        tdbcCurrencyID.SelectedValue = tdbg.Columns(COL_CurrencyID).Text
        cneExchangeRate.Value = Number(tdbg.Columns(COL_ExchangeRate).Text)
        SetExchangeRateText()

        '************************
        ReadOnlyControl(tdbcCurrencyID)
        chkDisabled.Visible = True
        bKeyPress = False
    End Sub

    Private Function AllowSave() As Boolean
        If c1dateValidDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Hieu_luc_tu"))
            c1dateValidDate.Focus()
            Return False
        End If
        If tdbcCurrencyID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_tien"))
            tdbcCurrencyID.Focus()
            Return False
        End If
        If Number(cneExchangeRate.Value) = 0 Then
            D99C0008.MsgNotYetEnter(rL3("Ty_gia"))
            cneExchangeRate.Focus()
            Return False
        End If

        If Not CheckStore(SQLStoreD13P5555) Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateValidDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateValidDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY

        c1dateValidDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCurrencyID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
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
        If _FormState = EnumFormState.FormAdd AndAlso c1dateValidDate.Text = "" Then
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
    '# Title: SQLStoreD13P1200
    '# Created User: Hoàng Nhân
    '# Created Date: 19/03/2014 03:38:24
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1200() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi ty gia" & vbCrLf)
        sSQL &= "Exec D13P1200 "
        sSQL &= SQLDateSave(c1dateValidDateFrom.Value) & COMMA 'ValidDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateValidDateTo.Value) & COMMA 'ValidDateTo, datetime, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1200
    '# Created User: Hoàng Nhân
    '# Created Date: 19/03/2014 04:13:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1200() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa danh muc ty gia" & vbCrlf)
        sSQL &= "Delete From D13T1200"
        sSQL &= " Where "
        sSQL &= "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Hoàng Nhân
    '# Created Date: 19/03/2014 03:57:08
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi sua" & vbCrlf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcCurrencyID)) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString(sTransID) & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateValidDate.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber("") 'Num01ID, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1200
    '# Created User: Hoàng Nhân
    '# Created Date: 19/03/2014 04:00:34
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1200() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu danh muc ty gia" & vbCrlf)
        sSQL.Append("Insert Into D13T1200(")
        sSQL.Append("TransID, ValidDate, CurrencyID, ExchangeRate, Description, ")
        sSQL.Append("DescriptionU, Disabled, CurrencyMode, CreateUserID, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLString(sTransID) & COMMA) 'TransID [KEY], varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1dateValidDate.Value) & COMMA) 'ValidDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[50], NOT NULL
        sSQL.Append(SQLMoney(cneExchangeRate.Value, DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, decimal, NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription, False) & COMMA) 'Description, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription, True) & COMMA) 'DescriptionU, nvarchar[500], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'CurrencyMode, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1200
    '# Created User: Hoàng Nhân
    '# Created Date: 19/03/2014 04:04:06
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1200() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu cap nhat" & vbCrlf)
        sSQL.Append("Update D13T1200 Set ")
        sSQL.Append("ValidDate = " & SQLDateSave(c1dateValidDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("ExchangeRate = " & SQLMoney(cneExchangeRate.Value, DxxFormat.ExchangeRateDecimals) & COMMA) 'decimal, NOT NULL
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransID = " & SQLString(sTransID))

        Return sSQL
    End Function
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grpMaster)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB)
    End Sub


End Class