Public Class D45F2023
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim dtGrid As DataTable
    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Dim bEnableCheck As Boolean

#Region "Const of tdbg - Total of Columns: 17"
    Private Const COL_Choose As Integer = 0          ' Chọn
    Private Const COL_VoucherDate As Integer = 1     ' Ngày phiếu
    Private Const COL_VoucherNo As Integer = 2       ' Số phiếu
    Private Const COL_CreatePerson As Integer = 3    ' Người lập
    Private Const COL_VoucherDesc As Integer = 4     ' Diễn giải
    Private Const COL_PRDate As Integer = 5          ' Ngày thống kê
    Private Const COL_ProductCount As Integer = 6    ' Tổng sản phẩm
    Private Const COL_ProductQuantity As Integer = 7 ' Tổng số lượng
    Private Const COL_Quantity02 As Integer = 8      ' Quantity02
    Private Const COL_ModuleName As Integer = 9      ' Module
    Private Const COL_ObjectID As Integer = 10       ' Mã đối tượng
    Private Const COL_ObjectName As Integer = 11     ' Tên đối tượng
    Private Const COL_WorkCenterID As Integer = 12   ' Bộ phận sản xuất
    Private Const COL_WorkCenterName As Integer = 13 ' Tên bộ phận sản xuất
    Private Const COL_IsInherit As Integer = 14      ' Đã kế thừa
    Private Const COL_VoucherID As Integer = 15      ' VoucherID
    Private Const COL_TransType As Integer = 16      ' TransType
#End Region

#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master

#End Region

    Private Sub D45F2023_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Private Sub D45F2023_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        gbEnabledUseFind = False
        _bSaved = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        tdbg_NumberFormat()
        LoadDefault()

        'ID 106774  22.03.2018
        EnableCheckBox()
        '***************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)
        '***************************
        CallD09U1111_Button(True)
        '***************************
        SetShortcutPopupMenu(C1CommandHolder)
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL_PRDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_du_lieu_-_D45F2023") & UnicodeCaption(gbUnicode) 'KÕ thôa dö liÖu - D45F2023
        '================================================================ 
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblteDateFrom.Text = rl3("Ngay") 'Ngày
        '================================================================ 
        btnFilter.Text = rl3("Loc") & Space(1) & "(F5)" 'Lọc
        btnInherit.Text = rl3("_Ke_thua") '&Kế thừa
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnF12.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkIsTransfer.Text = rl3("Van_chuyen_noi_bo") 'Vận chuyển nội bộ
        chkIsDelivery.Text = rl3("Xuat_kho") 'Xuất kho
        chkIsReceipt.Text = rl3("Nhap_kho_UNI") 'Nhập kho
        'chkIsCreatePieceWork.Text = rL3("Tao_phieu_cham_cong_san_pham") 'Tạo phiếu chấm công sản phẩm
        '================================================================ 
        chkIsCreatePieceWork.Text = rL3("Tao_phieu_thong_ke_san_pham_tinh_luong") 'Tạo phiếu thống kê sản phẩm tính lương
        chkIsUsed.Text = rL3("Chi_hien_thi_nhung_dong_da_chon") 'Chỉ hiển thị những dòng đã chọn
        chkIsInherit.Text = rL3("Hien_thi_du_lieu_da_ke_thua") 'Hiển thị dữ liệu đã kế thừa
        chkIsProStatistic.Text = rL3("Thong_ke_san_xuat") 'Thống kê sản xuất
        '================================================================ 
        grpInfo.Text = rl3("Thong_tin_ke_thuaU") 'Thông tin kế thừa
        '================================================================ 
        '================================================================ 
        tdbg.Columns(COL_Choose).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns(COL_VoucherNo).Caption = rL3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_CreatePerson).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_VoucherDesc).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_PRDate).Caption = rL3("Ngay_thong_ke") 'Ngày thống kê
        tdbg.Columns(COL_ProductCount).Caption = rL3("Tong_san_pham") 'Tổng sản phẩm
        tdbg.Columns(COL_ProductQuantity).Caption = rL3("Tong_so_luong_") 'Tổng số lượng
        tdbg.Columns(COL_ObjectID).Caption = rL3("Ma_doi_tuong") 'Mã đối tượng
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns(COL_WorkCenterID).Caption = rL3("Bo_phan_san_xuat") 'Bộ phận sản xuất
        tdbg.Columns(COL_WorkCenterName).Caption = rL3("Ten_bo_phan_san_xuat") 'Tên bộ phận sản xuất
        tdbg.Columns(COL_IsInherit).Caption = rL3("Da_ke_thua") 'Đã kế thừa
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("_Liet_ke_tat_ca") '&Liệt kê tất cả

    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ProductCount).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_ProductQuantity).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadDefault()
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_Choose}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Function AllowFilter() As Boolean
        If CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) = False Then
            Return False
        End If

        Return True
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2023()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = "Choose = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("VoucherID")}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ResetGrid()
        mnuFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        mnuListAll.Enabled = mnuFind.Enabled 'Mờ khi  chkIsUsed.Checked = True
        FooterTotalGrid(tdbg, COL_VoucherNo)
        FooterSumNew(tdbg, COL_ProductCount, COL_ProductQuantity)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        chkIsUsed.Checked = False
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
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
    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFind As String = ""
        If chkIsUsed.Checked Then
            strFind = "Choose=True"
        Else
            '- Nếu IsInherit =0 : chỉ đổ nguồn cho lưới các dòng dữ liệu trả ra từ store D45P2023 có IsInherit =0
            '- Nếu IsInherit =1 : đổ nguồn cho lưới tất cả các dòng dữ liệu trả ra từ store D45P2023
            strFind = sFind
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString

            If chkIsInherit.Checked = False Then 'ID 95481 20/03/2017
                If strFind <> "" Then
                    strFind &= " AND IsInherit =0"
                Else
                    strFind = "IsInherit =0"
                End If
            End If
            If strFind <> "" Then strFind = "(" & strFind & ") Or Choose =1"
        End If

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
#End Region

#Region "tdbg"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_Choose
                tdbg.UpdateData()
                ResetGrid()
        End Select
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.FilterActive Then HotKeyCtrlVOnGrid(tdbg, e) : Exit Sub
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = COL_Choose Then
            HotKeyEnterGrid(tdbg, COL_Choose, e)
        End If
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
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_Choose)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub

#End Region

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Choose
                tdbg.AllowSort = False
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub
    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub
    Private Sub chkIsInherit_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsInherit.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub
    Private Sub btnF12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        '****************************
        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_Choose).DataField & "=1")
        If dr.Length = 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Row = 0
            tdbg.Col = COL_Choose
            Return False
        End If

        Return True
    End Function

    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        btnInherit.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD45P2025.ToString & vbCrLf)

        Dim bRunSQL As Boolean = CheckStorebyTrans(sSQL.ToString) 'ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            _bSaved = True
            '***************************************
            If chkIsCreatePieceWork.Checked Then
                Dim frm As New D45F2022
                With frm
                    .ShowDialog()
                    .Dispose()
                End With
            End If
            Me.Close()
        Else
            'SaveNotOK()
            btnClose.Enabled = True
            btnInherit.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2023
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 22/11/2011 04:11:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2023() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2023 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2020") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLNumber(chkIsReceipt.Checked) & COMMA 'IsReceipt, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsDelivery.Checked) & COMMA 'IsDelivery, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsTransfer.Checked) & COMMA 'IsTransfer, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsProStatistic.Checked) 'IsProStatistic , tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:40:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where HostID=Host_Name() And Key01ID='D45F2020' And UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:42:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("Choose= True")

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Str01, Str02, Num01, Num02")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D45F2020") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("Voucher") & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_VoucherID).DataField).ToString) & COMMA) 'Str01, nvarchar, NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_TransType).DataField).ToString) & COMMA) 'Str02, nvarchar, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item(tdbg.Columns(COL_ProductCount).DataField).ToString, DxxFormat.DefaultNumber2) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item(tdbg.Columns(COL_ProductQuantity).DataField).ToString, DxxFormat.DefaultNumber2)) 'Num02, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2025
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 22/11/2011 04:52:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2025() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2025 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2020") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLNumber(chkIsCreatePieceWork.Checked) 'IsCreatePieceWork, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub EnableCheckBox()
        Dim sSQL As String = ""
        sSQL = "   SELECT Value FROM D91T9130 WHERE Customize = 'IsInformationWorkCenter'"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Select Case L3String(dt.Rows(0)("Value"))
                Case "1"
                    chkIsReceipt.Enabled = False
                    chkIsDelivery.Enabled = False
                    chkIsTransfer.Enabled = False
                Case "2"
                    chkIsProStatistic.Enabled = False
            End Select
        End If
    End Sub
    
    
End Class