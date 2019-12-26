'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:34:30 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:34:30 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1000


#Region "Const of tdbg - Total of Columns: 14"
    Private Const COL_OrderNo As Integer = 0           ' STT
    Private Const COL_DisplayOrder As Integer = 1      ' Thứ tự hiển thị
    Private Const COL_ProductID As Integer = 2         ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 3       ' Tên sản phẩm
    Private Const COL_ShortName As Integer = 4         ' Tên tắt
    Private Const COL_CustomerName As Integer = 5      ' Khách hàng
    Private Const COL_ProductionBatch As Integer = 6   ' Lô sản xuất
    Private Const COL_StatusName As Integer = 7        ' Trạng thái
    Private Const COL_TransactionDate As Integer = 8   ' Ngày phát sinh
    Private Const COL_CreateUserID As Integer = 9      ' CreateUserID
    Private Const COL_CreateDate As Integer = 10       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 11 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 12   ' LastModifyDate
    Private Const COL_Disabled As Integer = 13         ' KSD
#End Region


    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F1000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        ResetColorGrid(tdbg)
        Loadlanguage()

        InputDateInTrueDBGrid(tdbg, COL_TransactionDate)
        CreateTableForm()
        dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("ProductID")}
        LoadTDBGrid()

        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_san_pham_-_D45F1000") & UnicodeCaption(gbUnicode) 'Danh móc s¶n phÈm - D45F1000
        '================================================================ 
        tdbg.Columns("DisplayOrder").Caption = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("TransactionDate").Caption = rl3("Ngay_phat_sinh") 'Ngày phát sinh
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không hiển thị
        '================================================================ 
        tsmProcess.Text = rl3("_Quy_trinh") '&Quy trình
        tsmSetStage.Text = "&" & rl3("Gan_cong_doan") '&Gán công đoạn
        tsmSetListStage.Text = rL3("Ga_n_cong_doan_hang_loat") 'Gá&n công đoạn hàng loạt
        tsiNewProduct.Text = rL3("San_pham__moi") 'Sản phẩm &mới
        tsiAllProduct.Text = rL3("_Tat_ca_san_pham") '&Tất cả sản phẩm

        mnsProcess.Text = tsmProcess.Text
        mnsSetStage.Text = tsmSetStage.Text
        mnsSetListStage.Text = tsmSetListStage.Text
        mnsiNewProduct.Text = tsiNewProduct.Text
        mnsiAllProduct.Text = tsiAllProduct.Text
        tsmUpdate.Text = rL3("_Cap_nhat_trang_thai") '&Cập nhật trạng thái
        mnsUpdate.Text = tsmUpdate.Text
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung")
        '================================================================ 
        tdbg.Columns(COL_CustomerName).Caption = rL3("Khach_hang") 'Khách hàng
        tdbg.Columns(COL_ProductionBatch).Caption = rL3("Lenh_san_xuat") 'Lệnh sản xuất
        tdbg.Columns(COL_StatusName).Caption = rL3("Trang_thai") 'Trạng thái


    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If Not tdbg.Focused Then tdbg.Focus()
    End Sub

    Private Sub CreateTableForm()
        Dim sSQL As String =  SQLStoreD45P1001(0)
        dtGrid = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTableAfterSave(ByVal sKeyID() As String, Optional ByVal Type As EnumFormState = EnumFormState.FormAdd)
        Try
            Dim sSQL As String = SQLStoreD45P1001(1)

            Dim dtTmp As DataTable = ReturnDataTable(sSQL)
            If dtTmp IsNot Nothing Then
                dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("ProductID")}
                dtGrid.Merge(dtTmp, False, MissingSchemaAction.AddWithKey)
                If Type = EnumFormState.FormAdd Then
                    LoadTDBGrid(True)
                Else
                    LoadTDBGrid()
                End If
                Select Case Type
                    Case EnumFormState.FormAdd
                        'Modify 10/08/2009
                        Dim sKey() As String = {IIf(dtTmp.Rows.Count > 0, dtTmp.Rows(dtTmp.Rows.Count - 1).Item("DisplayOrder").ToString, "").ToString, IIf(dtTmp.Rows.Count > 0, dtTmp.Rows(dtTmp.Rows.Count - 1).Item("ProductID").ToString, "").ToString}
                        dtGrid.DefaultView.Sort = "DisplayOrder, ProductID"
                        tdbg.Row = dtGrid.DefaultView.Find(sKey)
                    Case EnumFormState.FormEdit
                        'Sort lai vi co su thay doi cua DisplayOrder
                        dtGrid.DefaultView.Sort = "DisplayOrder, ProductID"
                        tdbg.Row = dtGrid.DefaultView.Find(sKeyID)
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub c1dateEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

#Region "Active Find Client - List All "
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

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()

        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        '  LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
        CheckMyMenu()
        FooterTotalGrid(tdbg, COL_ProductID)
    End Sub

    Private Sub CheckMyMenu()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D45F5602")

        tsmSetStage.Enabled = tsbEdit.Enabled And tdbg.RowCount > 0
        tsmSetListStage.Enabled = tsbEdit.Enabled And tdbg.RowCount > 0
        tsmProcess.Enabled = tdbg.RowCount > 0 And ReturnPermission("D45F1080") > EnumPermission.View

        mnsSetStage.Enabled = tsmSetStage.Enabled
        mnsSetListStage.Enabled = tsmSetListStage.Enabled
        mnsProcess.Enabled = tsmProcess.Enabled
        tsmUpdate.Enabled = tsmEdit.Enabled
        mnsUpdate.Enabled = tsmUpdate.Enabled
    End Sub

#End Region

#Region "tdbg"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        If tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_TransactionDate, COL_DisplayOrder
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Disabled
                If ChrW(Keys.Space).Equals(e.KeyChar) Then Exit Sub
                e.Handled = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(Nothing, Nothing)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

#End Region

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F1001
        With f
            .ProductID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey() As String = {.DisplayOrder, .ProductID}
            .Dispose()
            If .bSaved Then
                LoadTableAfterSave(sKey, EnumFormState.FormAdd)
            End If
        End With
    End Sub

    Private Sub tsbInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D45F1002
        With f
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                Dim sKey() As String = {"", ""}
                LoadTableAfterSave(sKey, EnumFormState.FormAdd)
            End If
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1001
        f.ProductID = tdbg.Columns(COL_ProductID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F1001
        f.ProductID = tdbg.Columns(COL_ProductID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey() As String = {f.DisplayOrder, f.ProductID}
        f.Dispose()
        If f.bSaved Then
            LoadTableAfterSave(sKey, EnumFormState.FormEdit)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        sSQL = "Delete D45T1001 Where ProductID = " & SQLString(tdbg.Columns(COL_ProductID).Text) & vbCrLf
        sSQL &= "Delete D45T1000 Where ProductID = " & SQLString(tdbg.Columns(COL_ProductID).Text)
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'RunAuditLog(AuditCodeProducts, "03", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_ProductName).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodeProducts, "03", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_ProductName).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_ProductID)
        Else
            DeleteNotOK()
        End If
    End Sub


    Private Sub tsmProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProcess.Click, mnsProcess.Click
        Dim f As New D45F1080
        f.ProductID = tdbg.Columns(COL_ProductID).Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsmSetStage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmSetStage.Click, mnsSetStage.Click
        Dim bRunSQL As Boolean = ExecuteSQLNoTransaction(SQLStoreD45P1005(tdbg.Columns(COL_ProductID).Text, 0))
        If bRunSQL Then
            SaveOK()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub tsiNewProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsiNewProduct.Click, mnsiNewProduct.Click
        Dim bRunSQL As Boolean = ExecuteSQLNoTransaction(SQLStoreD45P1005("%", 0))
        If bRunSQL Then
            SaveOK()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub tsiAllProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsiAllProduct.Click, mnsiAllProduct.Click
        Dim bRunSQL As Boolean = ExecuteSQLNoTransaction(SQLStoreD45P1005("%", 1))
        If bRunSQL Then
            SaveOK()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_ProductID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        'Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
	CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub tsmImportData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        Me.Cursor = Cursors.WaitCursor
        '        .bSaved = False
        '        Dim frm As New D80F2090
        '	Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D45, "D45F5602", "D45F1000") Then
            CreateTableForm()
            dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("ProductID")}
            LoadTDBGrid(True)
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5602"
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ModuleID = D45
        '    .TransTypeID = "D45F1000" 'Theo TL phân tích
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With
        'If .bSaved Then
        '    CreateTableForm()
        '    dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("ProductID")}
        '    LoadTDBGrid(True)
        'End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub


    Private Function AllowDelete() As Boolean
        Dim sSQL As String = SQLStoreD45P5555()
        Return CheckStore(sSQL)
    End Function

    Private Function SQLStoreD45P1005(ByVal sProductID As String, ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1005 "
        sSQL &= SQLString(sProductID) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P1001(Optional ByVal iStatus As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1001 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(iStatus) & COMMA 'Status, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Function SQLStoreD45P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ProductID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function
    Private Sub tsmUpdate_Click(sender As Object, e As EventArgs) Handles tsmUpdate.Click, mnsUpdate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", Me.Name)
        SetProperties(arrPro, "TableName", "D45T1000")
        SetProperties(arrPro, "StatusFieldName", "StatusID")
        SetProperties(arrPro, "ObjectID", "ProductID")
        SetProperties(arrPro, "ObjectName", "ProductNameU")
        Dim frm As Form = CallFormShowDialog("D09D2040", "D09F2555", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            Dim sKey() As String = {tdbg.Columns(COL_DisplayOrder).Text, tdbg.Columns(COL_ProductID).Text}
            CreateTableForm()
            LoadTDBGrid()
            'tdbg.Row = dtGrid.DefaultView.Find(sKey)
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class