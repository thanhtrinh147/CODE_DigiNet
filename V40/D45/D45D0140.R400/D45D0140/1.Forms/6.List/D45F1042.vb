Imports System
Imports System.Windows.Forms
Public Class D45F1042
	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F1042"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Private dtGrid, dtDetail As DataTable
    'Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Dim bSavedOK As Boolean = False
    Dim iPerMe As Integer
    Dim iStatus As Byte = 0 'Dùng ghi nhận status khi sửa



#Region "Const of tdbg"
    Private Const COL_TransTypeID As Integer = 0      ' Mã
    Private Const COL_TransTypeName As Integer = 1    ' Tên
    Private Const COL_Disabled As Integer = 2         ' KSD
    Private Const COL_VoucherTypeID As Integer = 3    ' VoucherTypeID
    Private Const COL_PreparerID As Integer = 4       ' PreparerID
    Private Const COL_CreateUserID As Integer = 5     ' CreateUserID
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 7 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 8   ' LastModifyDate
#End Region

#Region "Const of tdbgDetail"
    Private Const COLD_IsUsed As String = "IsUsed"                     ' Chọn
    Private Const COLD_HAUnitPrices As String = "HAUnitPrices"         ' HAUnitPrices
    Private Const COLD_HAUnitPricesName As String = "HAUnitPricesName" ' Đơn giá giờ công hệ số
    Private Const COLD_HACoef As String = "HACoef"                     ' HACoef
    Private Const COLD_PWCode As String = "PWCode"                     ' PWCode
    Private Const COLD_IsHANADate As String = "IsHANADate"             ' IsHANADate
    Private Const COLD_IsHAAADate1 As String = "IsHAAADate1"           ' IsHAAADate1
    Private Const COLD_IsHAAADate2 As String = "IsHAAADate2"           ' IsHAAADate2
    Private Const COLD_IsHANHADate As String = "IsHANHADate"           ' IsHANHADate
    Private Const COLD_IsHAAHADate1 As String = "IsHAAHADate1"         ' IsHAAHADate1
    Private Const COLD_IsHAAHADate2 As String = "IsHAAHADate2"         ' IsHAAHADate2
#End Region



    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            iPerMe = ReturnPermission(_formIDPermission)
            LoadTDBCombo()
            LoadTDBDropdown()
            InputbyUnicode(Me, gbUnicode)
            'tdbdNormID_NumberFormat()
            'tdbgDetail_NumberFormat()
            tdbgDetail_LockedColumns()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

#Region "Cac xu ly cua form"

    Private Sub D45F1042_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Not bKeyPress Then Exit Sub
        If _FormState = EnumFormState.FormEdit Then
            If Not bSavedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtTransTypeID.Text <> "" Then
                If Not bSavedOK Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub D45F1042_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            txtTransTypeID.Focus()
        Else
            txtTransTypeName.Focus()
        End If
        LoadCaption()
    End Sub

    Private Sub D45F1042_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorForControl(EnumAnchorStyles.TopRightBottom, grpDetail)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnlB)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F1042_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetBackColorObligatory()
        LoadLanguage()
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        If Not _FormState = EnumFormState.FormAdd Then
            ResetColorGrid(tdbg)
            LoadTDBGrid()
            LoadEdit()

        End If
        '**************************
        CheckIdTextBox(txtTransTypeID)
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub


#Region "Cac ham Load chung"

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Loai_nghiep_vu_tinh_don_gia_gio_cong_he_so") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'LoÁi nghiÖp vó tÛnh ¢¥n giÀ gié c¤ng hÖ sç
        '================================================================ 
        lblPreparerID.Text = rl3("Nguoi_lap") 'Người lập
        lblTransTypeName.Text = rl3("Ten") 'Tên
        lblTransTypeID.Text = rl3("Ma") 'Mã
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        grpDetail.Text = rl3("Thong_tin_chi_tiet") 'Thông tin chi tiết
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        tdbcPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdPWCode.Columns("PWCode").Caption = rl3("Ma") 'Mã
        tdbdPWCode.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdHACoef.Columns("HACoef").Caption = rl3("Ma") 'Mã
        tdbdHACoef.Columns("HACoefName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbgDetail.Columns(COLD_IsUsed).Caption = rl3("Chon") 'Chọn
        tdbgDetail.Columns(COLD_HAUnitPricesName).Caption = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
        tdbgDetail.Columns(COLD_HACoef).Caption = rl3("Gio_cong_he_so") 'Giờ công hệ số
        tdbgDetail.Columns(COLD_PWCode).Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns(COL_TransTypeID).Caption = rl3("Ma") 'Mã
        tdbg.Columns(COL_TransTypeName).Caption = rl3("Ten") 'Tên
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
    End Sub

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
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
            btnNext.Text = rL3("Luu_va_Nhap__tiep")
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

    Private Sub LoadTDBCombo()
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, , gbUnicode)

        'tdbcPreparerID
        LoadCboCreateBy(tdbcPreparerID, gbUnicode)

        tdbcVoucherTypeID.SelectedIndex = 0
        tdbcPreparerID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBDropdown()
        Dim sSQL As String = ""

        'Load tdbcVoucherTypeID
        sSQL = "-- Load Dropdown gio cong he so" & vbCrLf
        sSQL &= "Select Code as HACoef, ShortName" & UnicodeJoin(gbUnicode) & " as HACoefName" & vbCrLf
        sSQL &= "From D29T0080 WITH(NOLOCK) WHERE Type = 'HAC' And IsUsed = 1 ORDER BY HACoef"
        LoadDataSource(tdbdHACoef, sSQL, gbUnicode)

        'Load tdbdPWCode
        sSQL = "-- Load Dropdown khoan thu nhap" & vbCrLf
        sSQL &= "Select Code as PWCode, Name84" & UnicodeJoin(gbUnicode) & " as Name" & vbCrLf
        sSQL &= "From D45T0020 WITH(NOLOCK) WHERE Disabled = 0"
        LoadDataSource(tdbdPWCode, sSQL, gbUnicode)
    End Sub

    Private Sub LoadCaption()
        Dim DtTemp As DataTable = ReturnDataTable(SQLCaption())

        Dim iIndex As Integer = IndexOfColumn(tdbgDetail, COLD_IsHANADate)
        Dim i As Integer
        If DtTemp.Rows.Count > 0 Then
            For i = 0 To DtTemp.Rows.Count - 1
                tdbgDetail.Columns(iIndex).Caption = ConvertVniToUnicode(DtTemp.Rows(i).Item("Caption").ToString)
                iIndex += 1
            Next
        End If
    End Sub

    Private Sub LoadTDBGDetail()
        dtDetail = ReturnDataTable(SQLStoreD45P1043)
        LoadDataSource(tdbgDetail, dtDetail, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        dtGrid = ReturnDataTable(SQLStoreD45P1042)
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
        FooterTotalGrid(tdbg, COL_TransTypeID)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "Menu"

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(txtTransTypeID)
        bSavedOK = False
        txtTransTypeName.Focus()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T1042() & vbCrLf)
        sSQL.Append(SQLDeleteD45T1043())
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
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
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
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

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

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
        'If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub

        If tdbg.Columns(COL_TransTypeID).Tag Is Nothing OrElse tdbg.Columns(COL_TransTypeID).Text <> tdbg.Columns(COL_TransTypeID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

#End Region

#Region "tdbgDetail"

    Private Sub tdbgDetail_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ComboSelect
        tdbgDetail.UpdateData()
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case tdbgDetail.Columns(e.ColIndex).DataField
            Case COLD_HACoef, COLD_PWCode
                If tdbgDetail.Columns(e.ColIndex).Text <> tdbgDetail.Columns(e.ColIndex).DropDown.Columns(tdbgDetail.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub

    Private Function IsExistGridkey(ByVal tdbgCol As Integer, ByVal sSelectedValue As String) As Boolean
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If i <> tdbgDetail.Bookmark Then
                If tdbgDetail(i, tdbgCol).ToString = sSelectedValue Then
                    D99C0008.MsgDuplicatePKey()
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub tdbgDetail_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case tdbgDetail.Columns(e.ColIndex).DataField
            Case COLD_HACoef
                If tdbgDetail.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COLD_PWCode
                If tdbgDetail.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgDetail.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
        End Select
    End Sub

    Private Sub tdbgDetail_LockedColumns()
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COLD_HAUnitPricesName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgDetail.KeyDown
        If e.KeyCode = Keys.Enter And tdbgDetail.Col = IndexOfColumn(tdbgDetail, COLD_IsHAAHADate2) Then
            HotKeyEnterGrid(tdbgDetail, IndexOfColumn(tdbgDetail, COLD_IsUsed), e)
        End If
    End Sub

#End Region

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        bSavedOK = False
        Dim drr() As DataRow = Nothing
        If Not AllowSave(drr) Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState
            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                sSQL.Append(SQLInsertD45T1042.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1043s(drr).ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1042.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1043s(drr).ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            bSavedOK = True
            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    LoadTDBGrid(True, txtTransTypeID.Text)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, txtTransTypeID.Text)
            End Select
            ReadOnlyControl(txtTransTypeID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_TransTypeID).Tag = ""
        '********************
        bSavedOK = False
        '*******************
        ClearText(grpDetail)
        tdbcVoucherTypeID.SelectedIndex = 0
        tdbcPreparerID.SelectedIndex = 0

        'If dtDetail IsNot Nothing Then
        '    dtDetail.Clear()
        'Else
        LoadTDBGDetail()
        'End If

        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        UnReadOnlyControl(True, txtTransTypeID)
        txtTransTypeID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TransTypeID).Tag = tdbg.Columns(COL_TransTypeID).Text
        '************************
        'Gán dữ liệu
        txtTransTypeID.Text = tdbg.Columns(COL_TransTypeID).Text
        txtTransTypeName.Text = tdbg.Columns(COL_TransTypeName).Text
        tdbcVoucherTypeID.SelectedValue = tdbg.Columns(COL_VoucherTypeID).Text
        tdbcPreparerID.SelectedValue = tdbg.Columns(COL_PreparerID).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        LoadTDBGDetail()
        '************************
        ReadOnlyControl(txtTransTypeID)
        chkDisabled.Visible = True
    End Sub

    Private Sub SetBackColorObligatory()
        txtTransTypeID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransTypeName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPreparerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgDetail.Splits(0).DisplayColumns(COLD_HACoef).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgDetail.Splits(0).DisplayColumns(COLD_PWCode).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave(ByRef drr() As DataRow) As Boolean
        If txtTransTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma"))
            txtTransTypeID.Focus()
            Return False
        End If
        If txtTransTypeName.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ten"))
            txtTransTypeName.Focus()
            Return False
        End If
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Loai_phieu"))
            txtTransTypeID.Focus()
            Return False
        End If
        If tdbcPreparerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nguoi_lap"))
            txtTransTypeName.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            Dim sField() As String = {"TransTypeID"}
            Dim sValue() As String = {txtTransTypeID.Text}
            If IsExistKey("D45T1042", sField, sValue) Then
                D99C0008.MsgDuplicatePKey()
                txtTransTypeID.Focus()
                Return False
            End If
        End If

        tdbgDetail.UpdateData()
        If tdbgDetail.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgDetail.Focus()
            Return False
        End If
        drr = dtDetail.Select(COLD_IsUsed & "=1")
        If drr.Length <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgDetail.Focus()
            tdbgDetail.Col = IndexOfColumn(tdbgDetail, COLD_IsUsed)
            Return False
        End If
        For i As Integer = 0 To drr.Length - 1
            If drr(i).Item(COLD_HACoef).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Gio_cong_he_so"))
                tdbgDetail.Focus()
                tdbgDetail.Col = IndexOfColumn(tdbgDetail, COLD_HACoef)
                Return False
            End If
            If drr(i).Item(COLD_PWCode).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Khoan_thu_nhap"))
                tdbgDetail.Focus()
                tdbgDetail.Col = IndexOfColumn(tdbgDetail, COLD_PWCode)
                Return False
            End If
        Next
        'For i As Integer = 0 To tdbgDetail.RowCount - 1
        '    If tdbgDetail(i, COLD_NormID).ToString = "" Then
        '        D99C0008.MsgNotYetEnter(rL3("Ma_chi_tieu"))
        '        tdbgDetail.Focus()
        '        tdbgDetail.Row = i
        '        tdbgDetail.Col = COLD_NormID
        '        Return False
        '    End If
        'Next
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

    'Private Sub tdbgDetail_NumberFormat()
    '    Dim arr() As FormatColumn = Nothing
    '    AddDecimalColumns(arr, tdbgDetail.Columns(COLD_Ratio).DataField, DxxFormat.DefaultNumber0, 28, 8)
    '    InputNumber(tdbgDetail, arr)
    'End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            'SetReturnFormView()
            Exit Sub
        End If
        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtTransTypeID.Text = "" And tdbgDetail.RowCount <= 0 Then
            If tdbg.RowCount > 0 Then
                LoadEdit()
            End If
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        End If
1:
        SetReturnFormView()
    End Sub

  

    'Private Sub tdbdNormID_NumberFormat()
    '    tdbdNormID.Columns(COLD_Ratio).NumberFormat = DxxFormat.DefaultNumber0
    'End Sub


#Region "Câu lệnh SQL"

    Private Function SQLStoreD45P1043() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi Detail" & vbCrLf)
        sSQL &= "Exec D45P1043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(txtTransTypeID.Text) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F1042") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P1042() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi Master" & vbCrlf)
        sSQL &= "Exec D45P1042 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F1042") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function SQLInsertD45T1042() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert du lieu" & vbCrLf)
        sSQL.Append("Insert Into D45T1042(")
        sSQL.Append("TransTypeID, TransTypeName, TransTypeNameU, VoucherTypeID, PreparerID, ")
        sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, False) & COMMA) 'TransTypeName, varchar[1000], NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, True) & COMMA) 'TransTypeNameU, nvarchar[1000], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPreparerID)) & COMMA) 'PreparerID, varchar[20], NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLUpdateD45T1042() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Update du lieu" & vbCrLf)
        sSQL.Append("Update D45T1042 Set ")
        sSQL.Append("TransTypeName = " & SQLStringUnicode(txtTransTypeName, False) & COMMA) 'varchar[1000], NULL
        sSQL.Append("TransTypeNameU = " & SQLStringUnicode(txtTransTypeName, True) & COMMA) 'nvarchar[1000], NULL
        sSQL.Append("VoucherTypeID = " & SQLString(ReturnValueC1Combo(tdbcVoucherTypeID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("PreparerID = " & SQLString(ReturnValueC1Combo(tdbcPreparerID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where TransTypeID = " & SQLString(tdbg.Columns(COL_TransTypeID).Text))
        Return sSQL
    End Function

    Private Function SQLStoreD45P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi xoa" & vbCrLf)
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D45F1042") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransTypeID).Text)  'Key01ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function SQLDeleteD45T1042() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrLf)
        sSQL &= "Delete From D45T1042"
        sSQL &= " Where TransTypeID = " & SQLString(tdbg.Columns(COL_TransTypeID).Text)
        Return sSQL
    End Function

    Private Function SQLDeleteD45T1043() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrLf)
        sSQL &= "Delete From D45T1043"
        sSQL &= " Where TransTypeID = " & SQLString(tdbg.Columns(COL_TransTypeID).Text)
        Return sSQL
    End Function

    Private Function SQLInsertD45T1043s(ByVal drr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        sRet.Append("CREATE TABLE #D45T1043Temp (TransTypeID varchar(20), HAUnitPrices varchar(20), PWCode varchar(20), HACoef varchar(20)")
        sRet.Append(",IsHANADate tinyint, IsHAAADate1 tinyint, IsHAAADate2 tinyint, IsHANHADate tinyint, IsHAAHADate1 tinyint, IsHAAHADate2 tinyint)" & vbCrLf)

        For i As Integer = 0 To drr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu du lieu" & vbCrLf)
            sSQL.Append("Insert Into #D45T1043Temp(")
            sSQL.Append("TransTypeID, HAUnitPrices, PWCode, HACoef, IsHANADate, ")
            sSQL.Append("IsHAAADate1, IsHAAADate2, IsHANHADate, IsHAAHADate1, IsHAAHADate2")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NULL
            sSQL.Append(SQLString(drr(i).Item(COLD_HAUnitPrices)) & COMMA) 'HAUnitPrices, varchar[20], NULL
            sSQL.Append(SQLString(drr(i).Item(COLD_PWCode)) & COMMA) 'PWCode, varchar[20], NULL
            sSQL.Append(SQLString(drr(i).Item(COLD_HACoef)) & COMMA) 'HACoef, varchar[20], NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHANADate)) & COMMA) 'IsHANADate, tinyint, NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHAAADate1)) & COMMA) 'IsHAAADate1, tinyint, NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHAAADate2)) & COMMA) 'IsHAAADate2, tinyint, NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHANHADate)) & COMMA) 'IsHANHADate, tinyint, NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHAAHADate1)) & COMMA) 'IsHAAHADate1, tinyint, NULL
            sSQL.Append(SQLNumber(drr(i).Item(COLD_IsHAAHADate2))) 'IsHAAHADate2, tinyint, NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        sSQL.Append("Exec D45P1044 ")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(gbUnicode) & COMMA) 'CodeTable, tinyint, NOT NULL
        sSQL.Append(SQLString(gsLanguage)) 'Language, varchar[20], NOT NULL
        sRet.Append(sSQL.ToString & vbCrLf)
        sSQL.Remove(0, sSQL.Length)
        Return sRet

        Return sSQL
    End Function

    Private Function SQLCaption() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load Caption" & vbCrLf)
        sSQL &= "SELECT	'IsHA'+ WorkDayType [Field], " & IIf(geLanguage = EnumLanguage.Vietnamese, "WorkDayTypeName", "WorkDayTypeName01").ToString
        sSQL &= UnicodeJoin(gbUnicode) & " [Caption] FROM D29T1142 WITH(NOLOCK) ORDER BY OrderNo"
        Return sSQL
    End Function

#End Region


#Region "Events tdbcVoucherTypeID with txtVoucherTypeName"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing Then
            txtVoucherTypeName.Text = ""
        Else
            txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcPreparerID with txtPreparerName"

    Private Sub tdbcPreparerID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.SelectedValueChanged
        If tdbcPreparerID.SelectedValue Is Nothing Then
            txtPreparerName.Text = ""
        Else
            txtPreparerName.Text = tdbcPreparerID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcPreparerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.LostFocus
        If tdbcPreparerID.FindStringExact(tdbcPreparerID.Text) = -1 Then
            tdbcPreparerID.Text = ""
        End If
    End Sub

#End Region



End Class