Public Class D45F2021
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim dtGrid As DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database


#Region "Const of tdbg"
    Private Const COL_Choose As Integer = 0         ' Chọn
    Private Const COL_TransID As Integer = 1        ' TransID
    Private Const COL_VoucherDate As Integer = 2    ' Ngày phiếu
    Private Const COL_VoucherNo As Integer = 3      ' Số phiếu
    Private Const COL_BlockName As Integer = 4      ' Khối
    Private Const COL_DepartmentID As Integer = 5   ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 6 ' Phòng ban
    Private Const COL_TeamID As Integer = 7         ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 8       ' Tổ nhóm
    Private Const COL_EmpGroupID As Integer = 9     ' Mã nhóm NV
    Private Const COL_EmpGroupName As Integer = 10  ' Nhóm nhân viên
    Private Const COL_EmployeeName As Integer = 11  ' Nhân viên
    Private Const COL_Ana01ID As Integer = 12       ' Ana01ID
    Private Const COL_Ana02ID As Integer = 13       ' Ana02ID
    Private Const COL_Ana03ID As Integer = 14       ' Ana03ID
    Private Const COL_Ana04ID As Integer = 15       ' Ana04ID
    Private Const COL_Ana05ID As Integer = 16       ' Ana05ID
    Private Const COL_Ana06ID As Integer = 17       ' Ana06ID
    Private Const COL_Ana07ID As Integer = 18       ' Ana07ID
    Private Const COL_Ana08ID As Integer = 19       ' Ana08ID
    Private Const COL_Ana09ID As Integer = 20       ' Ana09ID
    Private Const COL_Ana10ID As Integer = 21       ' Ana10ID
    Private Const COL_PeriodID As Integer = 22      ' Tập phí
    Private Const COL_ProOrderNo As Integer = 23    ' Lệnh sản xuất
    Private Const COL_ProductID As Integer = 24     ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 25   ' Tên sản phẩm
    Private Const COL_StageName As Integer = 26     ' Công đoạn
    Private Const COL_UnitID As Integer = 27        ' ĐVT
    Private Const COL_Quantity03 As Integer = 28    ' Số lượng kế hoạch
    Private Const COL_Quantity As Integer = 29      ' Quantity
    Private Const COL_Quantity02 As Integer = 30    ' Quantity02
    Private Const COL_SpecName01 As Integer = 31    ' SpecName01
    Private Const COL_SpecName02 As Integer = 32    ' SpecName02
    Private Const COL_SpecName03 As Integer = 33    ' SpecName03
    Private Const COL_SpecName04 As Integer = 34    ' SpecName04
    Private Const COL_SpecName05 As Integer = 35    ' SpecName05
    Private Const COL_SpecName06 As Integer = 36    ' SpecName06
    Private Const COL_SpecName07 As Integer = 37    ' SpecName07
    Private Const COL_SpecName08 As Integer = 38    ' SpecName08
    Private Const COL_SpecName09 As Integer = 39    ' SpecName09
    Private Const COL_SpecName10 As Integer = 40    ' SpecName10
#End Region




#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Private Sub D45F2021_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
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

    Private Sub D45F2021_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        _bSaved = False
        LoadTDBGridAnalysisCaption("D07", tdbg, COL_Ana01ID, 0, True, gbUnicode)
        LoadTDBGridSpecificationCaption(tdbg, COL_SpecName01, 1, gbUnicode)
        LoadCaptionQuantity()
        ResetColorGrid(tdbg, 0, 1)
        Loadlanguage()
        tdbg_NumberFormat()
        LoadTDBGrid()
        '**************************
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)
        '**************************
        CallD09U1111_Button(True)
        '**************************
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_san_pham_-_D45F2021") & UnicodeCaption(gbUnicode) 'Chãn s¶n phÈm - D45F2021
        '================================================================ 
        btnChoose.Text = rl3("_Chon") '&Chọn
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnF12.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkIsUsed.Text = rL3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("DepartmentName").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Ma_nhom_NV") 'Mã nhóm NV
        tdbg.Columns("EmpGroupName").Caption = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Nhan_vien") 'Nhân viên
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("StageName").Caption = rl3("Cong_doan") 'Công đoạn
        tdbg.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbg.Columns("PeriodID").Caption = rl3("Tap_phi") 'Tập phí
        tdbg.Columns("ProOrderNo").Caption = rL3("Lenh_san_xuat") 'Lệnh sản xuất
        tdbg.Columns(COL_Quantity03).Caption = rL3("So_luong_ke_hoach") 'Số lượng kế hoạch
    End Sub


    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_Choose}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            '-----------------------------------
            'Các cột ở SPLIT1
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2021()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        tsbFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        tsmFind.Enabled = tsbFind.Enabled
        mnsFind.Enabled = tsbFind.Enabled
        tsbListAll.Enabled = tsbFind.Enabled 'Mờ khi  chkIsUsed.Checked = True
        tsmListAll.Enabled = tsbFind.Enabled
        mnsListAll.Enabled = tsbFind.Enabled
        FooterTotalGrid(tdbg, COL_VoucherNo)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        '*******************************
        dtGrid.AcceptChanges()
        Dim sFilter1 As String = "" 'TH sFind="" và chkIsUsed.Checked =False

        If chkIsUsed.Checked Then
            sFilter1 = "Choose=True"
        Else
            If strFind <> "" Then sFilter1 = "Choose=True" & " Or " & strFind
        End If

        dtGrid.DefaultView.RowFilter = sFilter1

        ResetGrid()
    End Sub

    Private Sub chkShowSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
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
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGridSpecificationCaption(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Spec01ID As Integer, ByVal Split As Integer, Optional ByVal bUnicode As Boolean = False)
        Dim bUseSpec As Boolean = False

        Dim sSQL As String = "Select SpecTypeID, Caption" & UnicodeJoin(bUnicode) & " as Caption, IsD45, Disabled From D07T0410  WITH(NOLOCK) Order by SpecTypeID"
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        Dim iIndex As Integer = COL_Spec01ID
        Dim i As Integer

        If dt.Rows.Count > 0 Then
            For i = 0 To 9
                tdbg.Columns(iIndex).Caption = dt.Rows(i).Item("Caption").ToString
                tdbg.Columns(iIndex).Tag = Convert.ToBoolean(dt.Rows(i).Item("IsD45")) AndAlso Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))

                gbArrSpecVisiable(iIndex - COL_Spec01ID) = Convert.ToBoolean(tdbg.Columns(iIndex).Tag)
                If Not bUseSpec And Convert.ToBoolean(tdbg.Columns(iIndex).Tag) = True Then
                    bUseSpec = True
                End If
                tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font = FontUnicode(bUnicode, tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font.Style) 'New System.Drawing.Font("Lemon3", 8.249999!)
                tdbg.Splits(Split).DisplayColumns(iIndex).Visible = L3Bool(tdbg.Columns(iIndex).Tag)

                iIndex += 1
            Next
        End If
        dt = Nothing
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity To COL_Quantity02
                tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                j += 1
            Next
        End If
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Choose
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub c1dateDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

#Region "tdbg"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_Choose
                tdbg.UpdateData()
                ResetGrid()
        End Select
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_Choose Then HotKeyEnterGrid(tdbg, COL_Choose, e)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If

        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Choose 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_VoucherDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Quantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

#End Region

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("Choose= True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_Choose
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        btnChoose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            btnChoose.Enabled = True
            Me.Close()
        Else
            btnChoose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2021
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:13:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2021() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2021 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, int, NOT NULL
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
        sSQL &= " Where HostID=Host_Name() And Key01ID='D45F2020' And Key02ID='Product' And UserID=" & SQLString(gsUserID)
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
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Str01, Str02, Str03, Num01")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D45F2020") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("Product") & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_TransID).DataField).ToString) & COMMA) 'Str01, nvarchar, NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_VoucherNo).DataField).ToString) & COMMA) 'Str02, nvarchar, NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_ProductID).DataField).ToString) & COMMA) 'Str03, nvarchar, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item(tdbg.Columns(COL_Quantity).DataField).ToString, DxxFormat.DefaultNumber2)) 'Num01, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function




    
End Class