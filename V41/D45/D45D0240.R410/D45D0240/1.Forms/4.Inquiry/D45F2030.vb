Public Class D45F2030
    Dim dtGrid, dtCaptionCols As New DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

#Region "Const of tdbg"
    Private Const COL_VoucherDate As Integer = 0       ' Ngày phiếu
    Private Const COL_VoucherNo As Integer = 1         ' Số phiếu
    Private Const COL_Description As Integer = 2       ' Diễn giải
    Private Const COL_HACoefName As Integer = 3        ' Giờ công hệ số
    Private Const COL_Amount As Integer = 4            ' Khoản thu nhập
    Private Const COL_AttDateFrom As Integer = 5       ' Ngày công từ
    Private Const COL_AttDateTo As Integer = 6         ' Ngày công đến
    Private Const COL_Calculated As Integer = 7        ' Đã tính
    Private Const COL_CreateUserID As Integer = 8      ' CreateUserID
    Private Const COL_CreateDate As Integer = 9        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 10 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 11   ' LastModifyDate
    Private Const COL_AttCoefUPID As Integer = 12      ' AttCoefUPID
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D09F2030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D09F2030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL_AttDateFrom, COL_AttDateTo)
        LoadTDBGrid()
        '***************
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Don_gia_gio_cong_he_soF") & " - D45F2030" & UnicodeCaption(gbUnicode) '˜¥n giÀ gié c¤ng hÖ sç - D45F2030
        '================================================================ 
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("HACoefName").Caption = rl3("Gio_cong_he_so") 'Giờ công hệ số
        tdbg.Columns("Amount").Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns("AttDateFrom").Caption = rl3("Ngay_cong") & Space(1) & rl3("(tu)") 'Ngày công từ
        tdbg.Columns("AttDateTo").Caption = rl3("Ngay_cong") & Space(1) & rl3("(den)") 'Ngày công đến
        tdbg.Columns("Calculated").Caption = rl3("Da_tinh") 'Đã tính
        '================================================================ 
        tsmCalculate.Text = rl3("Tinh_don__gia_gio_cong_he_so") 'Tính đơn &giá giờ công hệ số
        mnsCalculate.Text = rl3("Tinh_don__gia_gio_cong_he_so") 'Tính đơn &giá giờ công hệ số
        tsmCalculateResult.Text = rl3("Ket__qua_tinh") 'Kết &quả tính
        mnsCalculateResult.Text = rl3("Ket__qua_tinh") 'Kết &quả tính
        tsmDeleteResult.Text = rl3("Xoa_ket_q_ua_tinh") 'Xóa kết q&uả tính
        mnsDeleteResult.Text = rl3("Xoa_ket_q_ua_tinh") 'Xóa kết q&uả tính
        mnsCalculateLSP.Text = rl3("Tinh_LSP_th_eo_DG-GCHS") 'Tính LSP th&eo ĐG-GCHS
        tsmCalculateLSP.Text = rl3("Tinh_LSP_th_eo_DG-GCHS") 'Tính LSP th&eo ĐG-GCHS
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = SQLStoreD45P2031()
        dtGrid = ReturnDataTable(sSQL)

        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =''
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("AttCoefUPID =" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        CheckMnuOther(tdbg.Bookmark)
        FooterTotalGrid(tdbg, COL_VoucherNo)
    End Sub

    Private Sub CheckMnuOther(ByVal iRow As Integer)
        If L3Bool(tdbg(iRow, COL_Calculated)) Then
            tsmCalculate.Enabled = False
            tsmCalculateResult.Enabled = tdbg.RowCount > 0
            tsmDeleteResult.Enabled = (ReturnPermission(Me.Name) - 4 >= 0) AndAlso tdbg.RowCount > 0
            tsbDelete.Enabled = False
            tsmCalculateLSP.Enabled = tdbg.RowCount > 0 AndAlso (ReturnPermission(Me.Name) >= EnumPermission.Add)
        Else
            tsmCalculate.Enabled = tdbg.RowCount > 0 AndAlso (ReturnPermission(Me.Name) >= EnumPermission.Add)
            tsmCalculateResult.Enabled = False
            tsmDeleteResult.Enabled = False
            tsbDelete.Enabled = (ReturnPermission(Me.Name) - 4 >= 0) AndAlso tdbg.RowCount > 0 AndAlso Not gbClosed
            tsmCalculateLSP.Enabled = False
        End If

        mnsCalculate.Enabled = tsmCalculate.Enabled
        mnsCalculateResult.Enabled = tsmCalculateResult.Enabled
        mnsDeleteResult.Enabled = tsmDeleteResult.Enabled
        tsmDelete.Enabled = tsbDelete.Enabled
        mnsDelete.Enabled = tsbDelete.Enabled
        mnsCalculateLSP.Enabled = tsmCalculateLSP.Enabled
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

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
#End Region

#Region "Context Menu items"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F2031
        With f
            .AttCoefUPID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .AttCoefUPID)
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If L3Bool(tdbg.Columns(COL_Calculated).Text) Then
            D99C0008.MsgL3(rl3("Phieu_nay_da_tinh_don_gia_gio_cong_he_so_Ban_khong_duoc_sua"))
            Exit Sub
        End If

        Dim f As New D45F2031
        With f
            .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With

        Me.Cursor = Cursors.WaitCursor
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_AttCoefUPID).Text)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New D45F2031
        With f
            .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL = "DELETE D45T2031 Where AttCoefUPID = " & SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & vbCrLf
        sSQL &= "Delete D45T2030 Where AttCoefUPID = " & SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & vbCrLf
        sSQL &= "Delete D45T2033 Where AttCoefUPID =" & SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & vbCrLf
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsmCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmCalculate.Click, mnsCalculate.Click
        Dim sSQL As String = SQLStoreD45P2030()
        If ExecuteSQL(sSQL) Then
            Dim f As New D45F2032
            With f
                .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
                .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
                .ShowDialog()
                .Dispose()
                LoadTDBGrid(, tdbg.Columns(COL_AttCoefUPID).Text)
            End With
        End If
    End Sub

    Private Sub tsmCalculateResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmCalculateResult.Click, mnsCalculateResult.Click
        Dim f As New D45F2032
        With f
            .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
            .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsmDeleteResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmDeleteResult.Click, mnsDeleteResult.Click
        If AllowDeleteResult() = False Then Exit Sub

        Dim sSQL As String = ""
        sSQL = "Delete D45T2032 Where AttCoefUPID = " & SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & vbCrLf
        sSQL &= "Update D45T2030 Set Calculated=0 Where AttCoefUPID = " & SQLString(tdbg.Columns(COL_AttCoefUPID).Text)
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            D99C0008.MsgL3(rl3("Xoa_ket_qua_tinh_thanh_cong")) 'Xóa kết quả tính thành công
            LoadTDBGrid(, tdbg.Columns(COL_AttCoefUPID).Text)
        Else
            D99C0008.MsgL3(rl3("Xoa_ket_qua_tinh_khong_thanh_cong")) 'Xóa kết quả tính không thành công
        End If
    End Sub

    Private Sub tsmCalculateLSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCalculateLSP.Click, mnsCalculateLSP.Click
        Dim f As New D45F2014
        With f
            .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
            .pSalaryVoucherID = ""
            .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
            .Description = tdbg.Columns(COL_Description).Text
            .AttDateFrom = tdbg.Columns(COL_AttDateFrom).Text
            .AttDateTo = tdbg.Columns(COL_AttDateTo).Text
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            .Dispose()
            LoadTDBGrid(, tdbg.Columns(COL_AttCoefUPID).Text)
        End With
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "tdbg"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub

        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Calculated 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_Amount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
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

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        CheckMnuOther(tdbg.Row)
    End Sub
#End Region

    Private Function AllowDeleteResult() As Boolean
        Dim sSQL As String = SQLStoreD45P5555()
        Return CheckStore(sSQL)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2031
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 09:43:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2031() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 10:00:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra phiếu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 10:08:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AttCoefUPID).Text) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function





    

    
End Class