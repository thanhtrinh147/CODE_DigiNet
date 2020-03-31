Public Class D13F1010
    Private _taxObjectID As String=""
    Private dtGrid, dtGrid1 As DataTable
    Dim iPerMe As Integer
    Dim dtCaptionCols As DataTable

    Private _formIDPermission As String = "D13F1010"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
    End Property


    Public Property TaxObjectID As String
        Get
            Return _taxObjectID
        End Get
        Set(ByVal Value As String)
            _taxObjectID = Value
        End Set
    End Property
    

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 8"
    Private Const COL_TaxObjectID As Integer = 0      ' Mã đối tượng 
    Private Const COL_TaxObjectName As Integer = 1    ' Tên đối tượng nộp thuế thu nhập
    Private Const COL_IsDefault As Integer = 2        ' Mặc định
    Private Const COL_Disabled As Integer = 3         ' KSD
    Private Const COL_CreateUserID As Integer = 4     ' Người tạo
    Private Const COL_CreateDate As Integer = 5       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 6 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 7   ' Ngày cập nhật cuối cùng
#End Region

#Region "Const of tdbg1 - Total of Columns: 4"
    Private Const COLD_TaxID As Integer = 0        ' Mã chi tiết thuế
    Private Const COLD_MinSalary As Integer = 1    ' > Mức lương
    Private Const COLD_MaxSalary As Integer = 2    ' <= Mức lương
    Private Const COLD_RateOrAmount As Integer = 3 ' Tỷ lệ (%)
#End Region


    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
            LoadInfoGeneral()

            _FormState = value
            iPerMe = ReturnPermission(_formIDPermission)
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
            End Select
        End Set
    End Property
    Private Sub D56F1030_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtTaxObjectID.Text <> "" Then
                If Not _bSaved Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub D56F1030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        tdbg1_NumberFormat()
        tdbg1_LockedColumns()
        SetBackColorObligatory()
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        LoadLanguage()
        If Not _FormState = EnumFormState.FormAdd Then
            ResetColorGrid(tdbg)
            LoadTDBGrid()
            SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        End If
        '**************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTaxObjectID)
        '**************************
        SetResolutionForm(Me, ContextMenuStrip1)
        If tdbg.RowCount = 0 Then UnReadOnlyControl(True, txtTaxObjectID)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D56F1030_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            txtTaxObjectID.Focus()
        Else
            txtTaxObjectName.Focus()
        End If
    End Sub
    Private Sub D56F1030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

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

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_doi_tuong_nop_thue_thu_nhap_-__D13F1010") & UnicodeCaption(gbUnicode) 'Danh móc ¢çi t§íng nèp thuÕ thu nhËp
        '================================================================ 
        lblTaxObjectID.Text = rL3("Ma") 'Mã
        lblTaxObjectName.Text = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnNext.Text = rL3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rL3("_Khong_luu") '&Không Lưu
        btnSave.Text = rL3("_Luu") '&Lưu
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkDisabled.Text = rL3("Khong_su_dung") 'Không sử dụng
        chkIsDefault.Text = rL3("Mac_dinh") 'Mặc định
        '================================================================ 
        grpDetail.Text = rL3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbg.Columns(COL_TaxObjectID).Caption = rL3("Ma_doi_tuong") 'Mã đối tượng 
        tdbg.Columns(COL_TaxObjectName).Caption = rL3("Ten_doi_tuong_nop_thue_thu_nhap") 'Tên đối tượng nộp thuế thu nhập
        tdbg.Columns(COL_IsDefault).Caption = rL3("Mac_dinh") 'Mặc định
        tdbg.Columns(COL_Disabled).Caption = rL3("KSD") 'KSD
        '===============================================================
        tdbg1.Columns(COLD_TaxID).Caption = rL3("Ma_chi_tiet_thue") 'Mã chi tiết thuế
        tdbg1.Columns(COLD_MinSalary).Caption = rL3("_Muc_luong") '> Mức lương
        tdbg1.Columns(COLD_MaxSalary).Caption = rL3("_Muc_luongU") '<= Mức lương
        tdbg1.Columns(COLD_RateOrAmount).Caption = rL3("Ty_le") & " (%)" 'Tỷ lệ (%)
    End Sub

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COLD_TaxID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLD_MinSalary).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        'AddDecimalColumns(arr, tdbg1.Columns(COLD_MinSalary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        'AddDecimalColumns(arr, tdbg1.Columns(COLD_MaxSalary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        'AddDecimalColumns(arr, tdbg1.Columns(COLD_RateOrAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)

        AddNumberColumns(arr, SqlDbType.Money, tdbg1.Columns(COLD_MinSalary).DataField, DxxFormat.DefaultNumber2)
        AddNumberColumns(arr, SqlDbType.Money, tdbg1.Columns(COLD_MaxSalary).DataField, DxxFormat.DefaultNumber2)
        AddNumberColumns(arr, SqlDbType.Money, tdbg1.Columns(COLD_RateOrAmount).DataField, DxxFormat.DefaultNumber2)
        InputNumber(tdbg1, arr)
    End Sub
    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_TaxObjectID).Tag = ""
        '********************
        _bSaved = False
        '*******************
        ClearText(grpDetail)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LoadGridDetail("")
        LockControlDetail(False)
        '*******************
        UnReadOnlyControl(True, txtTaxObjectID)
        txtTaxObjectID.Focus()
    End Sub
    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TaxObjectID).Tag = tdbg.Columns(COL_TaxObjectID).Text
        '************************
        'Gán dữ liệu
        txtTaxObjectID.Text = tdbg.Columns(COL_TaxObjectID).Text
        txtTaxObjectName.Text = tdbg.Columns(COL_TaxObjectName).Text
        chkIsDefault.Checked = L3Bool(tdbg.Columns(COL_IsDefault).Text)
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        chkDisabled.Visible = True
        '************************
        LoadGridDetail(tdbg.Columns(COL_TaxObjectID).Text)
        '************************
        ReadOnlyControl(txtTaxObjectID)
    End Sub
    Private Sub SetBackColorObligatory()
        txtTaxObjectID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTaxObjectName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        Dim sSQL As String
        sSQL = "--Do nguon cho luoi doi tuong thue thu nhap" & vbCrLf
        sSQL &= "Select TaxObjectID, TaxObjectName" & UnicodeJoin(gbUnicode) & " As TaxObjectName," & vbCrLf
        sSQL &= "CONVERT(Bit, IsDefault) as IsDefault, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate " & vbCrLf
        sSQL &= "From   D13T0128  WITH (NOLOCK) Order By TaxObjectID" & vbCrLf
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid(False)
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TaxObjectID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then tsbAdd_Click(Nothing, Nothing) : Exit Sub
        LoadEdit()
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
        ''*************************
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
        FooterTotalGrid(tdbg, COL_TaxObjectID)
    End Sub
    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub
    Private Sub LoadGridDetail(ByVal sTaxObjectID As String)
        Dim sSQL As String = ""
        sSQL &= "Select TaxID, TaxObjectID, MaxSalary, MinSalary, RateOrAmount From D13T0112  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where TaxObjectID = " & SQLString(sTaxObjectID)
        sSQL &= "Order By TaxID"
        dtGrid1 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(txtTaxObjectID)
        _bSaved = False
        chkDisabled.Focus()
    End Sub
    Private Function CheckBeforeDelete() As Boolean
        Dim sSQL As String = ""
        Dim sRet As String
        sSQL &= "Select 1 From D13T0201  WITH (NOLOCK) Where TaxObjectID = '" & tdbg.Columns(COL_TaxObjectID).Text & "'"
        sRet = ReturnScalar(sSQL)
        If sRet <> "" Then
            D99C0008.MsgL3(MsgNotDeleteData)
            Return False
        End If
        Return True
    End Function
    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckBeforeDelete() Then Exit Sub

        Dim sSQL As String
        sSQL = "Delete From D13T0112 Where TaxObjectID = " & SQLString(tdbg.Columns(COL_TaxObjectID).Text) & vbCrLf
        sSQL &= "Delete From D13T0128 Where TaxObjectID = " & SQLString(tdbg.Columns(COL_TaxObjectID).Text)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            RunAuditLog("AuditCodePITObjects", "03", tdbg.Columns(COL_TaxObjectID).Text, tdbg.Columns(COL_TaxObjectName).Text, SQLNumber(L3Bool(tdbg.Columns(COL_Disabled).Text)))
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            If dtGrid.Rows.Count = 0 Then
                ResetGrid()
                tsbAdd_Click(Nothing, Nothing)
            Else
                ReLoadTDBGrid()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub
#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
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
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_TaxObjectID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
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
        If tsbEdit.Enabled Then tsbEdit_Click(sender, Nothing)
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
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        LoadEdit()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.FilterActive Then Exit Sub
        If tdbg.Columns(COL_TaxObjectID).Tag Is Nothing OrElse tdbg.Columns(COL_TaxObjectID).Text <> tdbg.Columns(COL_TaxObjectID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub
#End Region

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        If chkIsDefault.Checked Then
            If CheckStore(SQLStoreD13P5555()) Then
                Dim sSQLUpdateD13T0128 As String = "-- Update ma doi tuong mac dinh ve khong mac dinh" & vbCrLf
                sSQLUpdateD13T0128 &= "UPDATE D13T0128 SET IsDefault = 0 WHERE IsDefault = 1"
                ExecuteSQL(sSQLUpdateD13T0128)
            Else
                btnSave.Enabled = True
                chkIsDefault.Focus()
                Exit Function
            End If
        End If

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T0128() & vbCrLf)
                sSQL.Append(SQLInsertD13T0112s().ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T0128() & vbCrLf)
                sSQL.Append(SQLDeleteD13T0112() & vbCrLf)
                sSQL.Append(SQLInsertD13T0112s())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _taxObjectID = txtTaxObjectID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtTaxObjectID.Text)
                Case EnumFormState.FormEdit
                    RunAuditLog(AuditCodePITObjects, "02", txtTaxObjectID.Text, txtTaxObjectName.Text, SQLNumber(chkDisabled.Checked))
                    LoadTDBGrid(, txtTaxObjectID.Text)
            End Select
            ReadOnlyControl(txtTaxObjectID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        If txtTaxObjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_doi_tuong_nop_thue"))
            txtTaxObjectID.Focus()
            Return False
        End If
        If txtTaxObjectName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_doi_tuong_nop_thue"))
            txtTaxObjectName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T0128", "TaxObjectID", txtTaxObjectID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTaxObjectID.Focus()
                Return False
            End If
        End If
        '***********************
        tdbg1.UpdateData()
        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COLD_MaxSalary).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("_Muc_luongU"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Focus()
                tdbg1.Col = COLD_MaxSalary
                tdbg1.Row = i
                Return False
            End If
            If tdbg1(i, COLD_MaxSalary).ToString <> "" And Val(tdbg1(i, COLD_MaxSalary).ToString) > MaxMoney Then
                D99C0008.MsgL3(rL3("_Muc_luong_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Focus()
                tdbg1.Col = COLD_MaxSalary
                tdbg1.Row = i
                Return False
            End If
            If Number(tdbg1(i, COLD_MaxSalary)) < Number(tdbg1(i, COLD_MinSalary)) Then
                D99C0008.MsgL3(rL3("_Muc_luong_khong_duoc_nho_hon__Muc_luong"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Focus()
                tdbg1.Col = COLD_MaxSalary
                tdbg1.Row = i
                Return False
            End If
            If tdbg1(i, COLD_RateOrAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ty_le_(%)"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Focus()
                tdbg1.Col = COLD_RateOrAmount
                tdbg1.Row = i
                Return False
            End If
            If tdbg1(i, COLD_RateOrAmount).ToString <> "" And Convert.ToDouble(tdbg1(i, COLD_RateOrAmount)) > 100 Then
                D99C0008.MsgL3(rL3("Ty_le_(%)_khong_duoc_vuot_qua_100_%"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Focus()
                tdbg1.Col = COLD_RateOrAmount
                tdbg1.Row = i
                Return False
            End If
        Next
        Return True
    End Function
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
        If AskSave() = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            SetReturnFormView()
            Exit Sub
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtTaxObjectID.Text = "" Then
            If tdbg.RowCount > 0 Then
                LoadEdit()
            End If
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadEdit()
        End If
1:
        SetReturnFormView()
    End Sub

#Region "tdbg1"
    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        tdbg1.UpdateData()
        Select Case e.ColIndex
            Case COLD_MaxSalary
                If tdbg1.Columns(COLD_MaxSalary).Text <> "" Then
                    If tdbg1.RowCount = 1 Then
                        tdbg1(tdbg1.Bookmark, COLD_MinSalary) = "0"
                    Else
                        If tdbg1.Bookmark = 0 Then
                            tdbg1(tdbg1.Bookmark, COLD_MinSalary) = "0"
                            If tdbg1.Bookmark < tdbg1.RowCount - 1 Then
                                tdbg1(tdbg1.Bookmark + 1, COLD_MinSalary) = tdbg1(tdbg1.Bookmark, COLD_MaxSalary)
                            End If
                        ElseIf tdbg1.Bookmark <> 0 And tdbg1.Bookmark < tdbg1.RowCount - 1 Then
                            tdbg1(tdbg1.Bookmark, COLD_MinSalary) = tdbg1(tdbg1.Bookmark - 1, COLD_MaxSalary)
                            tdbg1(tdbg1.Bookmark + 1, COLD_MinSalary) = tdbg1(tdbg1.Bookmark, COLD_MaxSalary)
                        ElseIf tdbg1.Bookmark <> 0 And tdbg1.Bookmark = tdbg1.RowCount - 1 Then
                            tdbg1(tdbg1.Bookmark, COLD_MinSalary) = tdbg1(tdbg1.Bookmark - 1, COLD_MaxSalary)
                        End If
                    End If
                End If
        End Select
    End Sub
    Private Sub tdbg1_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg1.AfterDelete
        If tdbg1.Columns(COLD_MaxSalary).Text <> "" Then
            If tdbg1.Bookmark = 0 Then
                tdbg1(tdbg1.Bookmark, COLD_MinSalary) = "0"
            Else
                tdbg1(tdbg1.Bookmark, COLD_MinSalary) = tdbg1(tdbg1.Bookmark - 1, COLD_MaxSalary)
            End If
        End If
    End Sub
    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                If tdbg1.Col <> COLD_MinSalary Then HotKeyF7(tdbg1)
            Case Keys.S
                If e.Control Then HeadClick(tdbg1.Col)
            Case Keys.Insert
                If e.Shift Then HotKeyShiftInsert(tdbg1)
            Case Keys.Enter
                If tdbg1.Col = COLD_RateOrAmount Then HotKeyEnterGrid(tdbg1, COLD_MaxSalary, e)
            Case Else
                HotKeyDownGrid(e, tdbg1, COLD_MinSalary)
        End Select
    End Sub
    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        HeadClick(e.ColIndex)
    End Sub
#End Region

    Private Sub HeadClick(iCol As Integer)
        Select Case iCol
            Case COLD_RateOrAmount, COLD_MaxSalary
                CopyColumns(tdbg1, iCol, tdbg1.Columns(iCol).Value.ToString, tdbg1.Row)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 04/07/2012 01:39:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "-- Stored kiem tra truoc khi luu " & vbCrLf
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F1011") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(txtTaxObjectID.Text) 'Key01ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0112
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/01/2007 10:50:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0112() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0112"
        sSQL &= " Where "
        sSQL &= "TaxObjectID = " & SQLString(tdbg.Columns(COL_TaxObjectID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0128
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 26/01/2007 02:18:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0128() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0128("
        sSQL &= "TaxObjectID, TaxObjectNameU, IsProgressive, IsMaxSalary, IsPercent, "
        sSQL &= "Disabled, IsDefault, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtTaxObjectID.Text) & COMMA 'TaxObjectID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtTaxObjectName, True) & COMMA 'TaxObjectNameU, varchar[50], NULL
        sSQL &= SQLNumber("1") & COMMA 'IsProgressive, bit, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsMaxSalary, bit, NOT NULL
        sSQL &= SQLNumber("1") & COMMA 'IsPercent, bit, NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLNumber(chkIsDefault.Checked) & COMMA 'IsDefault, bit, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0128
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/01/2007 10:49:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0128() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0128 Set "
        sSQL &= "TaxObjectNameU = " & SQLStringUnicode(txtTaxObjectName, True) & COMMA 'varchar[50], NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "IsDefault = " & SQLNumber(chkIsDefault.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "TaxObjectID = " & SQLString(txtTaxObjectID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0112s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 26/01/2007 02:18:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0112s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim sTaxID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COLD_TaxID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COLD_TaxID).ToString = "" Then
                sTaxID = CreateIGEs("D13T0112", "TaxID", "13", "TL", gsStringKey, sTaxID, iCountIGE)
                tdbg1(i, COLD_TaxID) = sTaxID
            End If
            sSQL = ""
            sSQL &= "Insert Into D13T0112("
            sSQL &= "TaxID, TaxObjectID, MaxSalary, MinSalary, RateOrAmount, TotalAmount"
            sSQL &= ") Values ("
            sSQL &= SQLString(tdbg1(i, COLD_TaxID)) & COMMA 'TaxID [KEY], varchar[20], NOT NULL
            sSQL &= SQLString(txtTaxObjectID.Text) & COMMA 'TaxObjectID [KEY], varchar[20], NOT NULL
            sSQL &= SQLMoney(tdbg1(i, COLD_MaxSalary), tdbg1.Columns(COLD_MaxSalary).NumberFormat) & COMMA 'MaxSalary, money, NULL
            sSQL &= SQLMoney(tdbg1(i, COLD_MinSalary), tdbg1.Columns(COLD_MinSalary).NumberFormat) & COMMA 'MinSalary, money, NULL
            sSQL &= SQLMoney(tdbg1(i, COLD_RateOrAmount), tdbg1.Columns(COLD_RateOrAmount).NumberFormat) & COMMA 'RateOrAmount, money, NULL
            sSQL &= SQLMoney(0) 'TotalAmount, money, NULL
            sSQL &= ")"
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function
End Class