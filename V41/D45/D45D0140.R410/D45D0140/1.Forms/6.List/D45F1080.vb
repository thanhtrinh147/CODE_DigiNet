Public Class D45F1080
	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F1080"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg"
    Private Const COL_RoutingID As Integer = 0         ' RoutingID
    Private Const COL_ProductID As Integer = 1         ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 2       ' Tên sản phẩm
    Private Const COL_RoutingNum As Integer = 3        ' Mã quy trình
    Private Const COL_RoutingDesc As Integer = 4       ' Tên quy trình
    Private Const COL_StageID As Integer = 5           ' Mã công đoạn
    Private Const COL_StageName As Integer = 6         ' Tên công đoạn
    Private Const COL_Disabled As Integer = 7          ' KSD
    Private Const COL_CreateUserID As Integer = 8      ' CreateUserID
    Private Const COL_CreateDate As Integer = 9        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 10 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 11   ' LastModifyDate
#End Region

    Dim dtData, dtDataDetail As DataTable
    Dim dtGrid As DataTable

    Private _productID As String = ""
    Public WriteOnly Property ProductID() As String
        Set(ByVal Value As String)
            _productID = Value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorForControl(EnumAnchorStyles.TopLeftRight, txtProductName, Panel1)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F1080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F1080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        ResetColorGrid(tdbg, 0, 2)

        Loadlanguage()

        LoadTDBCombo()
        '**************************
        'Khong can goi ham load luoi tai day vi su kien tdbcProductID_SelectedValueChanged se tu dong chay va load luoi
        tdbcProductID.Text = IIf(_productID <> "", _productID, "%").ToString
        'If _productID <> "" Then ReadOnlyControl(tdbcProductID)
        tdbcProductID.Tag = tdbcProductID.Text
        '**************************
        InputbyUnicode(Me, gbUnicode)

        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_quy_trinh_quan_ly_san_pham_-_D45F1080") & UnicodeCaption(gbUnicode) 'Danh móc quy trØnh qu¶n lü s¶n phÈm - D45F1080
        '================================================================ 
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkIsShowDetail.Text = rl3("Hien_thi_du_lieu_chi_tiet") 'Hiển thị dữ liệu chi tiết
        '================================================================ 
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("RoutingNum").Caption = rl3("Ma_quy_trinh") 'Mã quy trình
        tdbg.Columns("RoutingDesc").Caption = rl3("Ten_quy_trinh") 'Tên quy trình
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD

    End Sub

    Private Sub LoadTDBCombo()
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        Dim sSQL As String = ""
        sSQL = "Select '%' as ProductID, " & sLanguage & " as ProductName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION ALL " & vbCrLf
        sSQL &= "Select ProductID, ProductName" & sUnicode & " as ProductName, 1 as DisplayOrder " & vbCrLf
        sSQL &= "From D45T1000   WITH(NOLOCK)  where Disabled = 0  Order by DisplayOrder, ProductID"
        LoadDataSource(tdbcProductID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcProductID with txtProductName"

    Private Sub tdbcProductID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProductID.GotFocus
        tdbcProductID.Tag = tdbcProductID.Text
    End Sub

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        If tdbcProductID.SelectedValue Is Nothing Then
            txtProductName.Text = ""
        Else
            txtProductName.Text = tdbcProductID.Columns(1).Value.ToString
        End If
        LoadTDBGrid()
    End Sub

    Private Sub tdbcProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
        End If
    End Sub
#End Region

#Region "Events of grid"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) OrElse bRefreshFilter Then Exit Sub
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Columns.Count <= 0 Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(sender, e)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub
#End Region

#Region "Tìm kiếm và Liệt kê tất cả"
    Private sSQLFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
            sSQLFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()

        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sSQLFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sSQLFind = ResultWhereClause.ToString
    '    ReLoadTDBGrid()
    'End Sub
#End Region

#Region "Menu click"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F1081
        With f
            .ProductID = IIf(tdbcProductID.Text = "%", "", tdbcProductID.Text).ToString
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .RoutingID)
            .Dispose()
        End With

    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1081
        f.RoutingID = tdbg.Columns(COL_RoutingID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F1081
        With f
            .RoutingID = tdbg.Columns(COL_RoutingID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then LoadTDBGrid(True, tdbg.Columns(COL_RoutingID).Text)
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL = "Delete From D45T1080 where RoutingID = " & SQLString(tdbg.Columns(COL_RoutingID).Text) & vbCrLf
        sSQL &= "Delete From D45T1081 where RoutingID = " & SQLString(tdbg.Columns(COL_RoutingID).Text)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tsmInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D45F1081
        With f
            .RoutingID = tdbg.Columns(COL_RoutingID).Text
            .FormState = EnumFormState.FormCopy
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .RoutingID)
            .Dispose()
        End With
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)

        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        Dim frm As New D99F2222
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
        '       .bSaved = False
        '       Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D45, "D45F5606", "D45F1080") Then
            'Load lại dữ liệu
            Dim iBookmark As Integer = tdbg.Row
            LoadTDBGrid(True)
            tdbg.Bookmark = iBookmark
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5606"
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ModuleID = D45
        '    .TransTypeID = "D45F1080" 'Theo TL phân tích
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With

        'If .bSaved Then
        '    Dim iBookmark As Integer = tdbg.Row
        '    LoadTDBGrid(True)
        '    tdbg.Bookmark = iBookmark
        'End If

        Me.Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D45F5606")
        FooterTotalGrid(tdbg, COL_ProductID)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sSQLFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind.Equals("") = False Then strFind &= " And "
            strFind &= "Disabled =0"
        End If

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub chkIsShowDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsShowDetail.CheckedChanged
        sSQLFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Sub CreateData(Optional ByVal bReLoadData As Boolean = False)
        Dim sSQL As String = ""
        If chkIsShowDetail.Checked = False Then
            If bReLoadData OrElse dtData Is Nothing OrElse tdbcProductID.Tag.ToString <> tdbcProductID.Text Then
                sSQL = "SELECT 	T80.RoutingID, T80.ProductID, T00.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName," & vbCrLf
                sSQL &= "T80.RoutingNum, T80.RoutingDesc" & UnicodeJoin(gbUnicode) & " as RoutingDesc, T80.Disabled, " & vbCrLf
                sSQL &= "T80.CreateUserID, T80.CreateDate, T80.LastModifyUserID, T80.LastModifyDate " & vbCrLf
                sSQL &= "FROM	D45T1080 T80 INNER JOIN	D45T1000 T00 ON	T80.ProductID = T00.ProductID" & vbCrLf
                sSQL &= "WHERE		T80.ProductID LIKE " & SQLString(tdbcProductID.Text) & vbCrLf
                sSQL &= "ORDER BY	T80.ProductID, T80.RoutingNum"
                dtData = ReturnDataTable(sSQL)
            End If
        Else
            If bReLoadData OrElse dtDataDetail Is Nothing OrElse tdbcProductID.Tag.ToString <> tdbcProductID.Text Then
                sSQL = "SELECT 	T80.RoutingID,	T80.ProductID, T00.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName," & vbCrLf
                sSQL &= "T80.RoutingNum, T80.RoutingDesc" & UnicodeJoin(gbUnicode) & " as RoutingDesc,	T80.Disabled," & vbCrLf
                sSQL &= "T80.CreateUserID, T80.CreateDate, T80.LastModifyUserID, T80.LastModifyDate, " & vbCrLf
                sSQL &= "T81.StageID, T10.StageName" & UnicodeJoin(gbUnicode) & " as StageName" & vbCrLf
                sSQL &= "FROM D45T1080 T80  WITH(NOLOCK) INNER JOIN	D45T1000 T00	 WITH(NOLOCK) ON	T80.ProductID = T00.ProductID" & vbCrLf
                sSQL &= "INNER JOIN	D45T1081 T81	 WITH(NOLOCK) ON	T81.RoutingID = T80.RoutingID" & vbCrLf
                sSQL &= "INNER JOIN	D45T1010 T10	 WITH(NOLOCK) ON	T10.StageID = T81.StageID" & vbCrLf
                sSQL &= "WHERE		T80.ProductID LIKE " & SQLString(tdbcProductID.Text) & vbCrLf
                sSQL &= "ORDER BY	T80.ProductID, T80.RoutingNum, T81.OrderNum"
                dtDataDetail = ReturnDataTable(sSQL)
            End If
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        CreateData(bFlagAdd = True)

        If chkIsShowDetail.Checked = False Then
            dtGrid = dtData.DefaultView.ToTable
        Else
            dtGrid = dtDataDetail.DefaultView.ToTable
        End If

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sSQLFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt As DataTable
            dt = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_RoutingID).DataField & " = " & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
        End If
        '********************************
        If tdbcProductID.Text = "%" Then
            tdbg.Splits(0).DisplayColumns(COL_ProductID).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_ProductName).Visible = True
        Else
            tdbg.Splits(0).DisplayColumns(COL_ProductID).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_ProductName).Visible = False
        End If

        HideSplit()
    End Sub

    Private Sub HideSplit()

        If chkIsShowDetail.Checked Then
            If tdbg.Splits.Count <= 2 Then
                tdbg.InsertHorizontalSplit(1)
                tdbg.Splits(1).RecordSelectors = False
                tdbg.Splits(1).FilterBorderStyle = Border3DStyle.Raised

                tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(0).SplitSize = 1

                If tdbcProductID.Text = "%" Then
                    tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.NumberOfColumns
                    tdbg.Splits(1).SplitSize = 2
                Else
                    tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                    tdbg.Splits(1).SplitSize = 1
                End If

                tdbg.Splits(2).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                tdbg.Splits(2).SplitSize = 70

                For i As Integer = COL_ProductID To COL_RoutingDesc
                    tdbg.Splits(1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_StageID To COL_StageName
                    tdbg.Splits(1).DisplayColumns(i).Visible = True
                Next

            End If
        Else
            If tdbg.Splits.Count >= 3 Then tdbg.RemoveHorizontalSplit(1)

            tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg.Splits(0).SplitSize = 1

            tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
            tdbg.Splits(1).SplitSize = 70
        End If
    End Sub


End Class