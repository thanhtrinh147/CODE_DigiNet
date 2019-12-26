Imports System
Public Class D45F1130
    Private usrOption_D As New D99U1111()
    Dim dtF12_D As DataTable

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _formIDPermission As String = "D45F1130"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _priceListID As String = ""
    Public WriteOnly Property PriceListID As String
        Set(ByVal Value As String)
            _priceListID = Value
        End Set
    End Property

    Private _TransID As String = ""
    Public WriteOnly Property TransID() As String
        Set(ByVal Value As String)
            _TransID = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 10"
    Private Const COL_OrderNum As Integer = 0         ' STT
    Private Const COL_PriceListID As Integer = 1      ' Mã bảng giá
    Private Const COL_PriceListName As Integer = 2    ' Diễn giải
    Private Const COL_ValidFrom As Integer = 3        ' Hiệu lực từ
    Private Const COL_ValidTo As Integer = 4          ' Hiệu lực đến
    Private Const COL_Disabled As Integer = 5         ' KSD
    Private Const COL_CreateUserID As Integer = 6     ' CreateUserID
    Private Const COL_LastModifyUserID As Integer = 7 ' LastModifyUserID
    Private Const COL_CreateDate As Integer = 8       ' CreateDate
    Private Const COL_LastModifyDate As Integer = 9   ' LastModifyDate
#End Region

#Region "Const of tdbgD - Total of Columns: 14"
    Private Const COLD_TransID As String = "TransID"                   ' TransID
    Private Const COLD_IsCheck As String = "IsCheck"                   ' Chọn
    Private Const COLD_GroupProductID As String = "GroupProductID"     ' Mã nhóm SP
    Private Const COLD_GroupProductName As String = "GroupProductName" ' Nhóm sản phẩm
    Private Const COLD_ComponentID As String = "ComponentID"           ' Mã nhóm tiểu tác
    Private Const COLD_ComponentName As String = "ComponentName"       ' Nhóm tiểu tác
    Private Const COLD_TaskID As String = "TaskID"                     ' Mã cụm tiểu tác
    Private Const COLD_TaskName As String = "TaskName"                 ' Cụm tiểu tác
    Private Const COLD_SubTaskID As String = "SubTaskID"               ' Mã tiểu tác
    Private Const COLD_SubTaskName As String = "SubTaskName"           ' Tiểu tác
    Private Const COLD_WorkerLevelID As String = "WorkerLevelID"       ' Bậc thợ
    Private Const COLD_UnitPrice01 As String = "UnitPrice01"           ' Đơn giá
    Private Const COLD_Norm As String = "Norm"                         ' Định mức
    Private Const COLD_Notes As String = "Notes"                     ' Ghi chú
#End Region

    Private dtGrid, dtDetail As DataTable

    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
        End Set
    End Property

    Private Sub D31F2130_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption_D IsNot Nothing Then usrOption_D.Dispose()
    End Sub
    Private Sub D26F2070_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetFooterGrid(tdbgD, 0, tdbgD.Splits.Count - 1)
        ResetSplitDividerSize(tdbgD)
        gbEnabledUseFind = False
        '*******************
        Dim arr() As System.Windows.Forms.TextBox = {txtMPriceListID, txtPriceListID}
        CheckIdTextBox(arr)
        '*******************
        SetImageButton(btnSave, btnNotSave, imgButton)
        InputDateInTrueDBGrid(tdbg, COL_ValidFrom, COL_ValidTo)
        LoadTDBCombo()
        tdbgD_LockedColumns()
        tdbgD_NumberFormat()
        SetBackColorObligatory()
        LoadLanguage()
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        InputbyUnicode(Me, gbUnicode)
        CallD99U1111()

        'Nếu form có nút Lọc thì mở ra
        EnableMenu(False)
        ReadOnlyAll(pnlDetailInfo)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub D26F2070_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'C1SplitterPanel3.Width = 315
        Dim dSizeRatio As Double = (200 * 100) / C1SplitContainer2.Width
        C1SplitterPanel3.SizeRatio = dSizeRatio

        C1SplitterPanel5.SizeRatio = (95 * 100) / C1SplitContainer3.Height '(125 * 100) / C1SplitContainer3.Height
        '  C1SplitterPanel5.Height = 119
    End Sub
    Private Sub D26F2070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select

        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption_D.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub UseEnterAsTab(ByVal frm As Form, Optional ByVal bForward As Boolean = True)
        Try
            Select Case frm.ActiveControl.GetType.Name
                Case "GridEditor", "C1TrueDBGrid" ' Không làm
                Case "SplitContainer"
                    Dim SplitCon As SplitContainer = CType(frm.ActiveControl, SplitContainer)
                    UseEnterAsTab(SplitCon, bForward)
                Case Else
                    frm.SelectNextControl(frm.ActiveControl, bForward, True, True, False)
            End Select
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private Sub UseEnterAsTab(ByVal SplitCon As SplitContainer, Optional ByVal bForward As Boolean = True)
        Try
            If (SplitCon.ActiveControl.GetType.Name = "GridEditor") Or (SplitCon.ActiveControl.GetType.Name = "C1TrueDBGrid") Then 'Khong phai luoi
                Exit Sub
            End If
            If SplitCon.ActiveControl.GetType.BaseType.Name = "UserControl" Then
                Dim uc As UserControl = CType(SplitCon.ActiveControl, UserControl)
                UseEnterAsTab(uc, bForward)
            Else
                SplitCon.SelectNextControl(SplitCon.ActiveControl, bForward, True, True, False)
            End If
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private Sub UseEnterAsTab(ByVal uc As UserControl, Optional ByVal bForward As Boolean = True)
        Try
            Select Case uc.ActiveControl.GetType.Name
                Case "GridEditor", "C1TrueDBGrid" ' Không làm
                Case "SplitContainer"
                    Dim SplitCon As SplitContainer = CType(uc.ActiveControl, SplitContainer)
                    UseEnterAsTab(SplitCon, bForward)
                Case Else
                    uc.SelectNextControl(uc.ActiveControl, bForward, True, True, False)
            End Select
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_bang_gia_theo_tieu_tac") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc b¶ng giÀ theo tiÓu tÀc
        '================================================================ 
        lblPriceListName.Text = rl3("Dien_giai") 'Diễn giải
        lblMPriceListID.Text = rl3("Bang_gia") 'Bảng giá
        lblPriceListID.Text = rl3("Ma_bang_gia") 'Mã bảng giá
        lblValidFrom.Text = rl3("Hieu_luc_tu") 'Hiệu lực từ
        lblTaskID.Text = rl3("Cum_tieu_tac") 'Cụm tiểu tác
        lblComponentID.Text = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        lblGroupProductID.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        '================================================================ 
        btnMFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        btnAdjust.Text = rl3("Dieu_chinh_hang_loatU") 'Điều chỉnh hàng loạt
        btnFilter.Text = rL3("Loc")  'Lọc
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        chkIsValidDate.Text = rl3("Ngay_hieu_luc") 'Ngày hiệu lực
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcTaskID.Columns("TaskID").Caption = rl3("Ma") 'Mã
        tdbcTaskID.Columns("TaskName").Caption = rl3("Ten") 'Tên
        tdbcComponentID.Columns("ComponentID").Caption = rl3("Ma") 'Mã
        tdbcComponentID.Columns("ComponentName").Caption = rl3("Ten") 'Tên
        tdbcGroupProductID.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rl3("STT") 'STT
        tdbg.Columns(COL_PriceListID).Caption = rl3("Ma_bang_gia") 'Mã bảng giá
        tdbg.Columns(COL_PriceListName).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_ValidFrom).Caption = rl3("Hieu_luc_tu") 'Hiệu lực từ
        tdbg.Columns(COL_ValidTo).Caption = rl3("Hieu_luc_den") 'Hiệu lực đến
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
        tdbgD.Columns(COLD_IsCheck).Caption = rl3("Chon") 'Chọn
        tdbgD.Columns(COLD_GroupProductID).Caption = rl3("Ma_nhom_SP") 'Mã nhóm SP
        tdbgD.Columns(COLD_GroupProductName).Caption = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        tdbgD.Columns(COLD_ComponentID).Caption = rl3("Ma_nhom_tieu_tac") 'Mã nhóm tiểu tác
        tdbgD.Columns(COLD_ComponentName).Caption = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        tdbgD.Columns(COLD_TaskID).Caption = rl3("Ma_cum_tieu_tac") 'Mã cụm tiểu tác
        tdbgD.Columns(COLD_TaskName).Caption = rl3("Cum_tieu_tac") 'Cụm tiểu tác
        tdbgD.Columns(COLD_SubTaskID).Caption = rl3("Ma_tieu_tac") 'Mã tiểu tác
        tdbgD.Columns(COLD_SubTaskName).Caption = rl3("Tieu_tac") 'Tiểu tác
        tdbgD.Columns(COLD_WorkerLevelID).Caption = rl3("Bac_tho") 'Bậc thợ
        tdbgD.Columns(COLD_UnitPrice01).Caption = rl3("Don_gia") 'Đơn giá
        tdbgD.Columns(COLD_Norm).Caption = rl3("Dinh_muc") 'Định mức
        tdbgD.Columns(COLD_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        mnsAddSubTaskID.Text = rl3("Them_tieu_tac") 'Thêm tiểu tác
        '================================================================ 
        tdbgD.Splits(0).Caption = rl3("Thong_tin_tieu_tac") 'Thông tin tiểu tác
        tdbgD.Splits(1).Caption = rL3("Chi_tiet_bang_gia") 'Chi tiết bảng giá
        '================================================================ 
        C1SplitterPanel3.Text = rL3("Dieu_kien_loc") 'Điều kiện lọc
        C1SplitterPanel4.Text = rL3("Bang_gia") 'Bảng giá
        C1SplitterPanel5.Text = rL3("Chi_tiet") 'Chi tiết
    End Sub
    Private Sub SetBackColorObligatory()
        txtPriceListName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPriceListID.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateValidFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcGroupProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcComponentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTaskID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT1).DisplayColumns(COLD_UnitPrice01).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT1).DisplayColumns(COLD_Norm).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbgD_LockedColumns()
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_GroupProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_GroupProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_ComponentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_ComponentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT1).DisplayColumns(COLD_SubTaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT1).DisplayColumns(COLD_SubTaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgD.Splits(SPLIT1).DisplayColumns(COLD_WorkerLevelID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbgD_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbgD.Columns(COLD_UnitPrice01).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbgD.Columns(COLD_Norm).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbgD, arr)
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcGroupProductID
        sSQL = "---- Do nguon combo nhom san pham " & vbCrLf
        sSQL &= "	SELECT  		'%' AS GroupProductID, " & AllName & " AS  GroupProductName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "	UNION " & vbCrLf
        sSQL &= "	SELECT 		GroupProductID, GroupProductNameU as GroupProductName, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "	FROM 		D45T1070 WITH(NOLOCK)" & vbCrLf
        sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
        sSQL &= "	ORDER BY DisplayOrder, GroupProductName" & vbCrLf
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)
        tdbcGroupProductID.SelectedValue = "%"

        ''Load tdbcComponentID
        'LoadTDBCComponentID(ReturnValueC1Combo(tdbcGroupProductID))

        ''Load tdbcTaskID
        'LoadTDBCTaskID(ReturnValueC1Combo(tdbcComponentID))
    End Sub

    Dim dtComponentID As DataTable = Nothing
    Private Sub LoadTDBCComponentID(sGroupProductID As String)
        Dim sSQL As String = ""
        'Load tdbcComponentID

        If dtComponentID Is Nothing Then
            sSQL = "-- Combo nhom tieu tac" & vbCrLf
            sSQL &= "	SELECT  		'%' AS ComponentID, " & AllName & " AS  ComponentName, '%' As GroupProductID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT 		ComponentID, ComponentNameU as ComponentName, GroupProductID, 1 AS DisplayOrder" & vbCrLf
            sSQL &= "	FROM 		D45T1090 WITH(NOLOCK)" & vbCrLf
            sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
            sSQL &= "	ORDER BY 	DisplayOrder, ComponentName" & vbCrLf
            dtComponentID = ReturnDataTable(sSQL)
        End If
        '**************************
        LoadDataSource(tdbcComponentID, ReturnTableFilter(dtComponentID, "ComponentID ='%' OR GroupProductID =" & SQLString(sGroupProductID), True), gbUnicode)
        tdbcComponentID.SelectedValue = "%"
    End Sub

    Dim dtTaskID As DataTable = Nothing
    Private Sub LoadTDBCTaskID(sComponentID As String)
        If dtTaskID Is Nothing Then
            Dim sSQL As String = ""
            'Load tdbcTaskID
            sSQL = "-- Combo cum tieu tac" & vbCrLf
            sSQL &= "	SELECT  		'%' AS TaskID, " & AllName & " AS  TaskName, '' As ComponentID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT 		TaskID, TaskNameU as TaskName, ComponentID, 1 AS DisplayOrder" & vbCrLf
            sSQL &= "	FROM 		D45T1100 WITH(NOLOCK)" & vbCrLf
            sSQL &= "	WHERE 		Disabled = 0" & vbCrLf
            sSQL &= "	ORDER BY	DisplayOrder, TaskName " & vbCrLf
            dtTaskID = ReturnDataTable(sSQL)
        End If
        LoadDataSource(tdbcTaskID, ReturnTableFilter(dtTaskID, "TaskID ='%' OR ComponentID =" & SQLString(sComponentID), True), gbUnicode)
        tdbcTaskID.SelectedValue = "%"
    End Sub

#Region "Events tdbcGroupProductID"
    Private Sub tdbcGroupProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.LostFocus
        If tdbcGroupProductID.FindStringExact(tdbcGroupProductID.Text) = -1 Then tdbcGroupProductID.Text = ""
    End Sub
    Private Sub tdbcGroupProductID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcGroupProductID.SelectedValueChanged
        LoadTDBCComponentID(ReturnValueC1Combo(tdbcGroupProductID))
    End Sub
#End Region

#Region "Events tdbcComponentID"
    Private Sub tdbcComponentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcComponentID.LostFocus
        If tdbcComponentID.FindStringExact(tdbcComponentID.Text) = -1 Then tdbcComponentID.Text = ""
    End Sub

    Private Sub tdbcComponentID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcComponentID.SelectedValueChanged
        LoadTDBCTaskID(ReturnValueC1Combo(tdbcComponentID))
    End Sub
#End Region

#Region "Events tdbcTaskID"
    Private Sub tdbcTaskID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTaskID.LostFocus
        If tdbcTaskID.FindStringExact(tdbcTaskID.Text) = -1 Then tdbcTaskID.Text = ""
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Close, tdbcComponentID.Close, tdbcTaskID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Validated, tdbcComponentID.Validated, tdbcTaskID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub LockControlDetail(ByVal bLock As Boolean)   ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
        C1SplitContainer2.Enabled = bLock
    End Sub
    Public Sub EnableMenu(ByVal bEnabled As Boolean)
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        tdbg.Enabled = Not bEnabled
        btnAdjust.Enabled = btnSave.Enabled AndAlso tdbgD.RowCount > 0

        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, True, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        End If
    End Sub
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD45P1130()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid(False)
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_PriceListID).DataField & " = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        LoadEdit()
    End Sub
    Private Sub ReLoadTDBGrid(ByVal bLoadEdit As Boolean)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If _FormState = EnumFormState.FormAdd Then Exit Sub
        If tdbg.RowCount = 0 Then
            _priceListID = ""
            'LockControlDetail(True)
            ClearText(pnlDetailInfo)
            If dtDetail IsNot Nothing Then dtDetail.Clear()
        Else
            'LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then LoadEdit()
        End If

        LockControlDetail(True)
    End Sub
    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_PriceListID)
    End Sub
    Private Sub LoadTDBGridDetail()
        ResetFilter(tdbgD, sFilterD, bRefreshFilter)  ' Thêm mới thì gán sFind ="" và gán FilterText =""
        '************************
        Dim sSQL As String = SQLStoreD45P1131()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dtDetail Is Nothing OrElse dtDetail.Rows.Count = 0 Then
            dtDetail = dt.DefaultView.ToTable
        Else
            dtDetail.DefaultView.RowFilter = COLD_IsCheck & " = True"
            dtDetail = dtDetail.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtDetail.PrimaryKey = New DataColumn() {dtDetail.Columns(COLD_SubTaskID)}
                dtDetail.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If

        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        LoadDataSource(tdbgD, dtDetail, gbUnicode)
        ReLoadTDBGridDetail()
    End Sub
    Private Sub ReLoadTDBGridDetail()
        Dim strFind As String = ""
        If chkIsUsed.Checked Then
            strFind = COLD_IsCheck & "=1"
        Else
            strFind = ""
            If sFilterD.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilterD.ToString
            If strFind <> "" Then strFind = "(" & strFind & ") Or " & COLD_IsCheck & "=1"
        End If
        dtDetail.DefaultView.RowFilter = strFind
        ResetGridD()
    End Sub
    Private Sub ResetGridD()
        btnAdjust.Enabled = btnSave.Enabled AndAlso tdbgD.RowCount > 0
        FooterTotalGrid(tdbgD, COLD_GroupProductID)
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If ReturnValueC1Combo(tdbcGroupProductID) = "%" OrElse ReturnValueC1Combo(tdbcComponentID) = "%" OrElse ReturnValueC1Combo(tdbcTaskID) = "%" Then
            mnsAddSubTaskID.Enabled = False
        Else
            mnsAddSubTaskID.Enabled = ReturnPermission("D45F1120") >= 2 AndAlso ReturnPermission(Me.Name) >= 2
        End If
    End Sub
    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtDetail Is Nothing Then Exit Sub
        ReLoadTDBGridDetail()
    End Sub

    Private Sub LoadAddNew()
        _bSaved = False
        '*******************
        _priceListID = ""
        ClearTag(Me)
        ClearText(C1SplitterPanel2)

        c1dateValidFrom.Value = Date.Now
        c1dateValidTo.Value = Date.Now
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        tdbcGroupProductID.SelectedValue = "%"
        LockControlDetail(False)
        '*******************
        ResetFilter(tdbgD, sFilterD, bRefreshFilter)  ' Thêm mới thì gán sFind ="" và gán FilterText =""
        If _FormState = EnumFormState.FormAdd Then
            If dtDetail Is Nothing Then
                LoadTDBGridDetail()
            Else
                dtDetail.Clear()
                ResetGridD()
            End If
        Else
            dtDetail.DefaultView.RowFilter = COLD_IsCheck & " = True"
            dtDetail = dtDetail.DefaultView.ToTable
            For i As Integer = 0 To dtDetail.Rows.Count - 1
                dtDetail.Rows(i).Item(COLD_TransID) = ""
            Next
            dtDetail.AcceptChanges()
            ResetGridD()
        End If
        '*******************
        UnReadOnlyControl(True, txtPriceListID, c1dateValidFrom, txtPriceListName) ', tdbcGroupProductID, tdbcComponentID, tdbcTaskID)
        UnReadOnlyControl(False, c1dateValidTo)
        txtPriceListID.Focus()
    End Sub
    Private Sub LoadMaster()
        txtPriceListID.Text = tdbg.Columns(COL_PriceListID).Text
        c1dateValidFrom.Value = SQLDateShow(tdbg.Columns(COL_ValidFrom).Value)
        c1dateValidTo.Value = SQLDateShow(tdbg.Columns(COL_ValidTo).Value)
        txtPriceListName.Text = tdbg.Columns(COL_PriceListName).Text
        tdbcGroupProductID.SelectedValue = "%"
        tdbcComponentID.SelectedValue = "%"
        tdbcTaskID.SelectedValue = "%"
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        chkDisabled.Visible = True
    End Sub
    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        '*******************
        ReadOnlyAll(pnlDetailInfo)
        ReadOnlyControl(True, txtPriceListID, c1dateValidFrom, txtPriceListName) ', tdbcGroupProductID, tdbcComponentID, tdbcTaskID)
        '************************
        If _priceListID = tdbg.Columns(COL_PriceListID).Text Then Exit Sub
        _priceListID = tdbg.Columns(COL_PriceListID).Text
        '************************
        LoadMaster() 'Gán dữ liệu
        '*******************
        dtDetail = Nothing
        LoadTDBGridDetail()
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAddNew()
    End Sub
    Private Sub tsbInherit_Click(sender As Object, e As EventArgs) Handles tsbInherit.Click, mnsInherit.Click
        _FormState = EnumFormState.FormCopy
        EnableMenu(True)
        LoadAddNew()
    End Sub
    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        If Not CheckStore(SQLStoreD45P5555("Kiem tra truoc khi sua", 2)) Then Exit Sub
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        LockControlDetail(False)
        _bSaved = False
        UnReadOnlyControl(True, txtMPriceListID, c1dateValidFrom, txtPriceListName) ', tdbcGroupProductID, tdbcComponentID, tdbcTaskID)
        UnReadOnlyControl(c1dateValidTo)
    End Sub
    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xoa", 1)) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T1021.ToString & vbCrLf)
        sSQL.Append(SQLDeleteD45T1020.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            If tdbg.RowCount = 0 Then
                ClearText(pnlDetailInfo)
                dtDetail.Clear()
            Else
                LoadEdit()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub
    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg)
    End Sub
    Private Sub mnsAddSubTaskID_Click(sender As Object, e As EventArgs) Handles mnsAddSubTaskID.Click
        Me.Cursor = Cursors.WaitCursor
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "GroupProductID", ReturnValueC1Combo(tdbcGroupProductID))
        SetProperties(arrPro, "ComponentID", ReturnValueC1Combo(tdbcComponentID))
        SetProperties(arrPro, "TaskID", ReturnValueC1Combo(tdbcTaskID))
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        Dim frm As Form = CallFormShowDialog("D45D1040", "D45F1120", arrPro)

        Dim sOutput01 As String = GetProperties(frm, "SubTaskID").ToString
        If sOutput01 <> "" Then LoadTDBGridDetail()
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid(True) 'Giống sự kiện Finder_FindClick
        End Set
    End Property

    '*****************************
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, Nothing, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub
    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid(True)
    End Sub

#End Region

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid(True)
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
    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        If tdbg.RowCount <= 1 Then Exit Sub
        LoadEdit()
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 OrElse e.LastRow = tdbg.Row Then Exit Sub
        LoadEdit()
    End Sub
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

#End Region

#Region "tdbgD"
    Dim sFilterD As New System.Text.StringBuilder()
    Private Sub tdbgDetail_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgD.FilterChange
        Try
            If (dtDetail Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgD, sFilterD) 'Nếu có Lọc khi In
            ReLoadTDBGridDetail()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgD.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgD, e)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbgDetail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgD.KeyPress
        If tdbgD.Columns(tdbgD.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgD.Splits(tdbgD.SplitIndex).DisplayColumns(tdbgD.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbgD_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.AfterColUpdate
        Select Case e.Column.DataColumn.DataField
            Case COLD_IsCheck
                tdbgD.UpdateData()
                ResetGridD()
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClickD(ByVal iCol As Integer)
        If tdbgD.RowCount <= 0 Then Exit Sub
        Select Case tdbgD.Columns(iCol).DataField
            Case COLD_IsCheck
                L3HeadClick(tdbgD, iCol, bSelect)
        End Select
    End Sub
    Private Sub tdbgD_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.HeadClick
        HeadClickD(e.ColIndex)
    End Sub

#End Region
    Private Sub btnMFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMFilter.Click
        btnMFilter.Focus()
        If btnMFilter.Focused = False Then Exit Sub
        If chkIsValidDate.Checked Then
            If CheckValidDateFromTo(c1dateMValidFrom, c1dateMValidTo) = False Then Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGridDetail()
        Me.Cursor = Cursors.Default
    End Sub
    Private Function AllowFilter() As Boolean
        If tdbcGroupProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblGroupProductID.Text)
            tdbcGroupProductID.Focus()
            Return False
        End If
        If tdbcComponentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblComponentID.Text)
            tdbcComponentID.Focus()
            Return False
        End If
        If tdbcTaskID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTaskID.Text)
            tdbcTaskID.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        If txtPriceListName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblPriceListName.Text)
            txtPriceListName.Focus()
            Return False
        End If
        If txtPriceListID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblPriceListID.Text)
            txtPriceListID.Focus()
            Return False
        End If
        If c1dateValidFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(lblValidFrom.Text)
            c1dateValidFrom.Focus()
            Return False
        End If
        If c1dateValidTo.Value.ToString <> "" Then
            If CheckValidDateFromTo(c1dateValidFrom, c1dateValidTo) = False Then Exit Function
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1020", "PriceListID", txtPriceListID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPriceListID.Focus()
                Return False
            End If
        End If
        '**********************
        tdbgD.UpdateData()
        If tdbgD.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgD.Focus()
            Return False
        End If
        dr = dtDetail.Select(COLD_IsCheck & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbgD.Focus()
            tdbgD.SplitIndex = SPLIT0
            tdbgD.Col = IndexOfColumn(tdbgD, COLD_IsCheck)
            tdbgD.Row = 0
            Return False
        End If
        For i As Integer = 0 To dr.Length - 1
            If Number(dr(i).Item(COLD_UnitPrice01)) = 0 Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_UnitPrice01).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 1
                tdbgD.Col = IndexOfColumn(tdbgD, COLD_UnitPrice01)
                tdbgD.Row = findrowInGrid(tdbgD, dr(i).Item(COLD_TaskID).ToString, COLD_TaskID)
                Return False
            End If
            If Number(dr(i).Item(COLD_Norm)) = 0 Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_Norm).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 1
                tdbgD.Col = IndexOfColumn(tdbgD, COLD_Norm)
                tdbgD.Row = findrowInGrid(tdbgD, dr(i).Item(COLD_TaskID).ToString, COLD_TaskID)
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            '  ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
        LockControlDetail(True)
        ReadOnlyAll(pnlDetailInfo)
    End Sub
    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtMPriceListID.Text = "" Then
            If tdbg.RowCount > 0 Then
                _FormState = EnumFormState.FormView
                LoadEdit()
            End If
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        End If
1:
        SetReturnFormView()
        EnableMenu(False)
    End Sub
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
    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Return False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder("")
        Select Case _FormState
            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                sSQL.Append(SQLInsertD45T1020.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1020.ToString & vbCrLf)
        End Select
        sSQL.Append(SQLDeleteD45T1021.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T1021s(dr).ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _priceListID = txtPriceListID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, _priceListID)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, _priceListID)
            End Select
            SetReturnFormView()
        Else
            SaveNotOK()
            Me.Cursor = Cursors.Default
            Return False
        End If
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Private Sub chkIsQCDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsValidDate.CheckedChanged
        If chkIsValidDate.Checked Then
            UnReadOnlyControl(True, c1dateMValidFrom, c1dateMValidTo)
            c1dateMValidFrom.Value = Now
            c1dateMValidTo.Value = Now
        Else
            ReadOnlyControl(c1dateMValidFrom, c1dateMValidTo)
            c1dateMValidFrom.Value = ""
            c1dateMValidTo.Value = ""
        End If
    End Sub
    Private Sub InputbyUnicode(ByVal control As Control, ByVal bUseUnicode As Boolean, Optional ByVal bGroupBy As Boolean = False)
        'If Not bUseUnicode Then Exit Sub'Update 25/06/2013 bỏ đoạn code này vì khi design có thể là font Microsoft Sans Serif
        For Each ctrl As Control In control.Controls
            If UnicodeConvertFont(ctrl, bUseUnicode) Then
                Continue For
                ' 9/9/2014 id 68726 - Bổ sung thêm C1DockingTab
            ElseIf TypeOf (ctrl) Is TabControl Or TypeOf (ctrl) Is TabPage Or TypeOf (ctrl) Is GroupBox Or TypeOf (ctrl) Is Panel Or TypeOf (ctrl) Is C1.Win.C1Command.C1DockingTabPage Or TypeOf (ctrl) Is C1.Win.C1Command.C1DockingTab Or TypeOf (ctrl) Is SplitContainer Or TypeOf (ctrl) Is SplitterPanel Or TypeOf (ctrl) Is C1.Win.C1SplitContainer.C1SplitContainer Or TypeOf (ctrl) Is C1.Win.C1SplitContainer.C1SplitterPanel Then
                ' AdjustFontChildControl(ctrl)
                InputbyUnicode(ctrl, bUseUnicode, bGroupBy)
            End If
        Next
    End Sub
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption_D Is Nothing Then Exit Sub 'TH lưới không có cột
        'usrOption_D.Location = New Point(tdbgD.Left, btnF12.Top - (usrOption_D.Height + 7))
        'Me.Controls.Add(usrOption_D)
       
        Me.C1SplitterPanel2.Controls.Add(usrOption_D)
        usrOption_D.Height = tdbgD.Height
        usrOption_D.Location = tdbgD.Location
        usrOption_D.BringToFront()
        usrOption_D.Visible = True
    End Sub
    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COLD_IsCheck, COLD_SubTaskID, COLD_UnitPrice01}
        usrOption_D.AddColVisible(tdbgD, dtF12_D, arrColObligatory)
        If usrOption_D IsNot Nothing Then usrOption_D.Dispose()
        usrOption_D = New D99U1111(Me, tdbgD, dtF12_D)
    End Sub

    Private Sub btnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New D45F1131
        f.ShowDialog()
        If f.bSaved Then
            For i As Integer = 0 To tdbgD.RowCount - 1
                If f.IsPrice Then
                    If f.PriceMethod = "0" Then
                        CalByPercent(i, COLD_UnitPrice01, f.Pricevalue)
                    Else
                        CalByValue(i, COLD_UnitPrice01, f.Pricevalue)
                    End If
                End If
                If f.IsNorm Then
                    If f.NormMethod = "0" Then
                        CalByPercent(i, COLD_Norm, f.NormValue)
                    Else
                        CalByValue(i, COLD_Norm, f.NormValue)
                    End If
                End If
            Next
            tdbgD.UpdateData()
        End If
        f.Dispose()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CalByPercent(ByVal row As Integer, COL_Value As String, dPercent As Double)
        tdbgD(row, COL_Value) = SQLNumber(Number(tdbgD(row, COL_Value), tdbgD.Columns(COL_Value).NumberFormat) * dPercent, tdbgD.Columns(COL_Value).NumberFormat)
    End Sub

    Private Sub CalByValue(ByVal row As Integer, COL_Value As String, dValue As Double)
        tdbgD(row, COL_Value) = SQLNumber(Number(tdbgD(row, COL_Value), tdbgD.Columns(COL_Value).NumberFormat) + Number(dValue, tdbgD.Columns(COL_Value).NumberFormat), tdbgD.Columns(COL_Value).NumberFormat)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1130
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:24:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1130() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi Master" & vbCrlf)
        sSQL &= "Exec D45P1130 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsValidDate.Checked) & COMMA 'IsValidDate, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateMValidFrom.Value) & COMMA 'ValidFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateMValidTo.Value) & COMMA 'ValidTo, datetime, NOT NULL
        sSQL &= SQLString(txtMPriceListID.Text) 'PriceListID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1131
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:25:16
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1131() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi chi tiet" & vbCrlf)
        sSQL &= "Exec D45P1131 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(IIf(_FormState = EnumFormState.FormAdd, "", tdbg.Columns(COL_PriceListID).Text)) & COMMA 'PriceListID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupProductID)) & COMMA 'GroupProductID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcComponentID)) & COMMA 'ComponentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTaskID)) 'TaskID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:28:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1020() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrlf)
        sSQL &= "Delete From D45T1020"
        sSQL &= " Where "
        sSQL &= "PriceListID = " & SQLString(txtPriceListID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:29:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu Master" & vbCrlf)
        sSQL.Append("Insert Into D45T1020(")
        sSQL.Append("PriceListID, PriceListNameU, DateFrom, DateTo, " & vbCrLf)
        sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, " & vbCrlf)
        sSQL.Append("ValidFrom, ValidTo, IsSubTask")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPriceListName, True) & COMMA) 'PriceListNameU, nvarchar[500], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrlf) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateValidFrom.Value) & COMMA & vbCrLf) 'ValidFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateValidTo.Value) & COMMA) 'ValidTo, datetime, NULL
        sSQL.Append(SQLNumber(1)) 'IsSubTask, tinyint, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:32:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Cap nhat du lieu Master" & vbCrlf)
        sSQL.Append("Update D45T1020 Set ")
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("PriceListNameU = " & SQLStringUnicode(txtPriceListName, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("ValidFrom = " & SQLDateSave(c1dateValidFrom.Value) & COMMA) 'datetime, NULL
        sSQL.Append("ValidTo = " & SQLDateSave(c1dateValidTo.Value)) 'datetime, NULL
        sSQL.Append(" Where PriceListID =" & SQLString(txtPriceListID.Text))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1021
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:28:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1021() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu chi tiet" & vbCrLf)
        sSQL &= "Delete From D45T1021"
        sSQL &= " Where "
        sSQL &= "PriceListID = " & SQLString(txtPriceListID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1021s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:33:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1021s(dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iFirstTrans As Long = 0
        Dim iCountIGE As Integer = 0
        Dim dtSourceGrid As DataTable = CType(tdbgD.DataSource, DataTable)
        iCountIGE = dtSourceGrid.Select(COLD_TransID & "='' or " & COLD_TransID & " is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu chi tiet" & vbCrLf)
            If dr(i).Item(COLD_TransID).ToString = "" Then
                sTransactionID = CreateIGENewS("D45T1021", "TransID", "45", "PL", gsStringKey, sTransactionID, iCountIGE, iFirstTrans)
                dr(i).Item(COLD_TransID) = sTransactionID
            End If
            sSQL.Append("Insert Into D45T1021(")
            sSQL.Append("PriceListID, UnitPrice01, TransID, GroupProductID, ComponentID, " & vbCrLf)
            sSQL.Append("TaskID, SubTaskID, Norm, NoteU")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item(COLD_UnitPrice01), tdbgD.Columns(COLD_UnitPrice01).NumberFormat) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_GroupProductID)) & COMMA) 'GroupProductID, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_ComponentID)) & COMMA & vbCrLf) 'ComponentID, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_TaskID)) & COMMA) 'TaskID, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_SubTaskID)) & COMMA) 'SubTaskID, varchar[50], NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item(COLD_Norm), tdbgD.Columns(COLD_Norm).NumberFormat) & COMMA) 'Norm, decimal, NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COLD_Notes), gbUnicode, True) & vbCrLf) 'NoteU, nvarchar[2000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/02/2017 01:37:13
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(sComment As String, iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PriceListID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber("") 'Num01, int, NOT NULL
        Return sSQL
    End Function



    
    
End Class