Imports System.Text
Imports System
Imports System.Windows.Forms

Public Class D13F2040
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim dtCaptionCols As DataTable
    Private gbEnabledUseFind As Boolean = False


#Region "Const of tdbg"
    Private Const COL_IsChosen As Integer = 0           ' Chọn
    Private Const COL_VoucherDate As Integer = 1        ' Ngày phiếu
    Private Const COL_SalaryVoucherID As Integer = 2    ' Mã phiếu
    Private Const COL_SalaryVoucherNo As Integer = 3    ' Số phiếu
    Private Const COL_PayrollVoucherID As Integer = 4   ' Mã HSL
    Private Const COL_Description As Integer = 5        ' Ghi chú
    Private Const COL_PayrollVoucherNo As Integer = 6   ' Hồ sơ lương
    Private Const COL_TransferMethodID As Integer = 7   ' PP chuyển bút toán
    Private Const COL_PayrollDescription As Integer = 8 ' Diễn giải
    Private Const COL_SalCalMethodName As Integer = 9   ' Phương pháp tính
    Private Const COL_StatusCalcuName As Integer = 10   ' Trạng thái
    Private Const COL_CreateUserID As Integer = 11      ' Người tạo
    Private Const COL_CreateDate As Integer = 12        ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 13  ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 14    ' Ngày cập nhật cuối cùng
    Private Const COL_SalCalMethodID As Integer = 15    ' SalCalMethodID
    Private Const COL_DayVoucherNoFrom As Integer = 16  ' Điều chỉnh thu nhập (từ)
    Private Const COL_DayVoucherNoTo As Integer = 17    ' Điều chỉnh thu nhập (đến)
    Private Const COL_Calculated As Integer = 18        ' Đã tính
    Private Const COL_Updated As Integer = 19           ' Cập nhật HSL
    Private Const COL_IsAdvancedSal As Integer = 20     ' Lương ứng
    Private Const COL_Locked As Integer = 21            ' Đã khóa
    Private Const COL_LockedUserID As Integer = 22      ' LockedUserID
    Private Const COL_LockedDate As Integer = 23        ' LockedDate
#End Region


    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Dim iPerD13F5607 As Integer = 0
    Dim iPerD13F5608 As Integer = 0
    Dim iPerD13F2040 As Integer = 0

    Private sSalaryVoucherID As String
    Dim bSalAll As Boolean = False
    Dim dtMain As DataTable
    Dim ArrRow(0) As Integer   'Lưu index các row được check chọn
    Dim bChoose As Boolean = False
    Dim iArr As Integer = 1
    Dim bOnCalculating As Boolean = False
    Dim startDate As DateTime

    Private Sub D13F2040_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bSalAll Then
            CloseCalSalAll()
            Exit Sub
        End If
        If bOnCalculating Then
            e.Cancel = True
        End If
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)
    End Sub


    Private Sub D13F2040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        iPerD13F5607 = ReturnPermission("D13F5607")
        iPerD13F5608 = ReturnPermission("D13F5608")
        iPerD13F2040 = ReturnPermission("D13F2040")
        ReLoadImage(picRunning)
        Loadlanguage()
        tdbg.Splits(0).DisplayColumns(COL_IsChosen).Visible = False
        btnAction.Width = 80
        btnAction.Left = btnAction.Left + 57
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me, Me.C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_phieu_tinh_luong_-__D13F2040") & UnicodeCaption(gbUnicode) 'Danh móc phiÕu tÛnh l§¥ng - D13F2040
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("IsChosen").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("SalaryVoucherID").Caption = rl3("Ma_phieu") 'Mã phiếu
        tdbg.Columns("SalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("PayrollDescription").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("SalCalMethodName").Caption = rl3("Phuong_phap_tinh") 'Phương pháp tính
        tdbg.Columns("StatusCalcuName").Caption = rl3("Trang_thai") 'Trạng thái
        tdbg.Columns("TransferMethodID").Caption = rl3("PP_chuyen_but_toan") 'PP chuyển bút toán
        tdbg.Columns("DayVoucherNoFrom").Caption = rl3("Dieu_chinh_thu_nhap_(tu)") 'Điều chỉnh thu nhập (từ)
        tdbg.Columns("DayVoucherNoTo").Caption = rl3("Dieu_chinh_thu_nhap_(den)") 'Điều chỉnh thu nhập (đến)
        tdbg.Columns("Calculated").Caption = rl3("Da_tinh") 'Đã tính
        tdbg.Columns("Updated").Caption = rl3("Cap_nhat_HSL") 'Cập nhật HSL
        tdbg.Columns("IsAdvancedSal").Caption = rl3("Luong_ung")
        tdbg.Columns("Locked").Caption = rl3("Da_khoa") 'Đã khóa
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        C1CommandLink3.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSalCalculate.Text = rl3("Tinh__luong") 'Tính &lương
        C1CommandLink5.Text = rl3("Tinh__luong") 'Tính &lương
        mnuViewResultSalCalculation.Text = rl3("_Ket_qua_tinh_luong") '&Kết quả tính lương
        C1CommandLink6.Text = rl3("_Ket_qua_tinh_luong") '&Kết quả tính lương
        mnuDeleteResultSalCalculation.Text = rl3("Xoa_ket__qua_tinh_luong") 'Xóa kết &quả tính lương
        C1CommandLink7.Text = rl3("Xoa_ket__qua_tinh_luong") 'Xóa kết &quả tính lương
        mnuSysInfo.Text = rl3("Lich_su_tac_dong") 'Lịch sử tác động
        mnuCalSalAll.Text = rl3("Tinh_luong_hang_l_oat") 'Tính lương hàng l&oạt
        C1CommandLink9.Text = rl3("Tinh_luong_hang_l_oat") 'Tính lương hàng l&oạt
        mnuLockVoucher.Text = rl3("Khoa__phieu_U") 'Khóa &phiếu

        mnuOpenVoucher.Text = rl3("_Mo_phieu") '&Mở phiếu
        C1CommandLink11.Text = rl3("_Mo_phieu") '&Mở phiếu
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kế tất cả

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            'ResetFilter(tdbg, sFilter, bRefreshFilter, sFilterServer)
            sFind = ""
            'sFindServer = "" ' Nếu có sử dụng Lọc để In
        End If

        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2041()
        dtMain = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtMain.Rows.Count > 0

        LoadDataSource(tdbg, dtMain, gbUnicode)
        ReLoadTDBGrid()
        If sSalaryVoucherID <> "" Then
            Dim dt1 As DataTable = dtMain.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("SalaryVoucherID" & " = " & SQLString(sSalaryVoucherID), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Function CheckTransfered() As Boolean
        Dim sSQL As New StringBuilder
        sSQL.Append("Select 1 From D13T2600  WITH(NOLOCK) Where SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & vbCrLf)
        sSQL.Append(" And DivisionID = " & SQLString(gsDivisionID) & " And Transfered = 1 ")
        Dim sRet As String = ReturnScalar(sSQL.ToString)
        If sRet <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "Popup Menu"

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2041
        With f
            '.SalaryVoucherID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            sSalaryVoucherID = .SalaryVoucherID
            If .bSaved Then
                LoadTDBGrid(True)
            End If
            .Dispose()
        End With
       
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLockedVoucher(3, rl3("MSG000006")) Then Exit Sub
        If Not CheckStore(SQLStoreD13P5555(2)) Then Exit Sub

        Dim f As New D13F2041
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .SalaryVoucherID = tdbg.Columns(COL_SalaryVoucherID).Text
            .Calculated = Convert.ToInt16(tdbg.Columns(COL_Calculated).Text)
            .Updated = Convert.ToInt16(tdbg.Columns(COL_Updated).Text)
            .FormCall = Me.Name
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved = True Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        If Not CheckLockedVoucher(1, rl3("MSG000005")) Then Exit Sub

        Dim f As New D13F2041
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .SalaryVoucherID = tdbg.Columns(COL_SalaryVoucherID).Text
            .FormCall = Me.Name
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        If Not CheckLockedVoucher(4, rl3("MSG000007")) Then Exit Sub
        If Not CheckStore(SQLStoreD13P5555(1)) Then Exit Sub

        Dim sSQL As New StringBuilder("")
        Dim iBookmark As Integer
        Dim bResult As Boolean
        '   If AskDelete() = Windows.Forms.DialogResult.Yes Then
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        'Update 23/12/2011: Incident 45363 Không dùng bảng xóa mà dùng store D13P2043
        sSQL.Append(SQLStoreD13P2043().ToString() & vbCrLf)

        'Audit
        sSQL.Append(SQLStoreD09P6210("SalaryCalculation", tdbg.Columns(COL_SalaryVoucherID).Text, "03", tdbg.Columns(COL_SalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text).ToString() & vbCrLf)

        bResult = ExecuteSQL(sSQL.ToString)
        If bResult = True Then
            DeleteOK()
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
        '    End If
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "SalaryCalculation")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_SalaryVoucherID).Text)
        SetProperties(arrPro, "mode", "1")
        '     SetProperties(arrPro, "EventID", tdbg.Columns(COL_EventID).Text)
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)
        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "SalaryCalculation" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_SalaryVoucherID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuSalCalculate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalCalculate.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLockedVoucher(3, rl3("Ban_khong_co_quyen_tinh_luong_tren_chung_tu_cua_nguoi_khac")) Then Exit Sub
        If Not CheckStore(SQLStoreD13P5555(0)) Then Exit Sub

        bP4500 = False
        bP2110 = False
        bP2600 = False

        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        sSalaryVoucherID = tdbg.Columns(COL_SalaryVoucherID).Text

        Me.Cursor = Cursors.WaitCursor
        pnlPic.Visible = True
        pnlPic.BringToFront()
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
        tmr1.Enabled = True
        'pgb1.Value = 50
        bOnCalculating = True
        EnableContextMenu(False)
    End Sub

    Private Sub mnuCalSalAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCalSalAll.Click
        If Not CheckLockedVoucher(3, rl3("Ban_khong_co_quyen_tinh_luong_tren_chung_tu_cua_nguoi_khac")) Then Exit Sub

        bSalAll = True
        tdbg.AllowUpdate = True
        btnAction.Width = 139
        btnAction.Left = btnAction.Left - 57
        ResetColorGrid(tdbg)
        For i As Integer = COL_VoucherDate To COL_SalCalMethodID
            tdbg.Splits(0).DisplayColumns(i).Locked = True
        Next
        For i As Integer = COL_CreateUserID To COL_Updated
            tdbg.Splits(0).DisplayColumns(i).Locked = True
        Next
        btnAction.Text = rl3("Tinh__luong")
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Nothing)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Nothing)
        tdbg.Splits(0).DisplayColumns(COL_IsChosen).Visible = True
        tdbg.Splits(0).DisplayColumns(COL_Updated).Visible = False
    End Sub

    Private Sub mnuViewResultSalCalculation_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuViewResultSalCalculation.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLockedVoucher(1, rl3("MSG000005")) Then Exit Sub

        Dim f As New D13F2042
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        With f
            .SalaryVoucherNo = tdbg.Columns(COL_SalaryVoucherNo).Text
            .PayrollVoucherNo = tdbg.Columns(COL_PayrollVoucherNo).Text
            .SalaryVoucherID = tdbg.Columns(COL_SalaryVoucherID).Text
            '21/11/2013 id 59979 - bo HSL tháng
            .PayrollVoucherID = gsPayRollVoucherID ' tdbg.Columns(COL_PayrollVoucherID).Text
            .SalCalMethodID = tdbg.Columns(COL_SalCalMethodID).Text
            .TransferMethodID = tdbg.Columns(COL_TransferMethodID).Text()
            .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
            .Description = tdbg.Columns(COL_Description).Text
            .ShowDialog()
            .Dispose()
        End With
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    End Sub

    Private Sub mnuDeleteResultSalCalculation_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDeleteResultSalCalculation.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLockedVoucher(4, rl3("Ban_khong_co_quyen_xoa_ket_qua_tinh_luong_tren_chung_tu_cua_nguoi_khac")) Then Exit Sub
        If Not CheckStore(SQLStoreD13P5555(3)) Then Exit Sub

        ' Dim Msg As Windows.Forms.DialogResult
        Dim sSQL As New StringBuilder("")
        Dim bResult As Boolean
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        '        If Convert.ToInt16(tdbg.Columns(COL_Calculated).Text) = 1 Then
        '           
        '            Msg = D99C0008.MsgAsk(rL3("Phieu_nay_da_duoc_tinh_luong_Ban_co_muon_xoa_ket_qua_nay_khong"))
        '            If Msg = Windows.Forms.DialogResult.Yes Then
        '                sSQL.Append(SQLStoreD13P3501(0))
        '                bResult = ExecuteSQL(sSQL.ToString)
        '                If bResult = True Then
        '                    ''Lưu lại vết Audit
        '                    D99C0008.MsgL3(rL3("Xoa_ket_qua_tinh_luong_thanh_cong"))
        '                End If
        '            End If
        '        Else
        '            sSQL.Append(SQLStoreD13P3501(0))
        '            ExecuteSQL(sSQL.ToString)
        '            ''Lưu lại vết Audit
        '            D99C0008.MsgL3(rL3("Xoa_ket_qua_tinh_luong_thanh_cong"))
        '        End If
        ' 7/10/2014 id 69518 - Chỉ xuất thông báo 1 lần trả ra từ Store kiểm tra D13P5555.
        sSQL.Append(SQLStoreD13P3501(0))
        bResult = ExecuteSQL(sSQL.ToString)
        If bResult = True Then
            ''Lưu lại vết Audit
            D99C0008.MsgL3(rL3("Xoa_ket_qua_tinh_luong_thanh_cong"))
        End If
        LoadTDBGrid()
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    End Sub

    Private Sub mnuLockVoucher_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuLockVoucher.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2600 Set ")
        sSQL.Append("Locked = " & SQLNumber(1) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LockedUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LockedDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text))

        Me.Cursor = Cursors.WaitCursor
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub mnuOpenVoucher_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuOpenVoucher.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2600 Set ")
        sSQL.Append("Locked = " & SQLNumber(0) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LockedUserID = " & SQLString("") & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LockedDate = " & SQLDateSave("")) 'datetime, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text))

        Me.Cursor = Cursors.WaitCursor
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            SaveNotOK()
        End If
    End Sub
#End Region

#Region "Grid"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        If bSalAll Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        Else
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If Not bSalAll Then Exit Sub
        If e.ColIndex = COL_IsChosen Then
            tdbg.AllowSort = False
            Dim bFlag As Boolean = Not CBool(tdbg(0, COL_IsChosen))
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsChosen) = bFlag
            Next
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            Else
                mnuView_Click(sender, Nothing)
            End If
        End If
        If e.Control And e.KeyCode = Keys.S Then
            If Not bSalAll Then Exit Sub
            If tdbg.Col = COL_IsChosen Then
                Dim bFlag As Boolean = Not CBool(tdbg(0, COL_IsChosen))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsChosen) = bFlag
                Next
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        If bSalAll Then
            Me.Cursor = Cursors.WaitCursor
            tdbg.Cursor = Cursors.WaitCursor
            tdbg.AllowRowSelect = False
            If ArrRow.Length = 1 Then
                For i As Integer = 0 To tdbg.RowCount - 1
                    If tdbg(i, COL_IsChosen).ToString = "True" Then
                        ReDim Preserve ArrRow(UBound(ArrRow) + 1)
                        ArrRow(UBound(ArrRow)) = i
                    End If
                Next
            End If
            If ArrRow.Length = 1 Then
                D99C0008.MsgL3(rl3("MSG000010"))
                Me.BringToFront()
                Me.Activate()
                ' update 7/11/2012 id 52344
                '      MessageBox.Show(ConvertUnicodeToVietwareF(rl3("MSG000010")), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                Me.Cursor = Cursors.Default
                tdbg.Cursor = Cursors.Default
                Exit Sub
            End If
            If iArr = ArrRow.Length Then
                bOnCalculating = False
                Me.Cursor = Cursors.Default
                tdbg.Cursor = Cursors.Default
                D99C0008.MsgL3(rl3("Thuc_hien_thanh_cong"))
                Me.BringToFront()
                Me.Activate()
                ' update 7/11/2012 id 52344
                '  MessageBox.Show(ConvertUnicodeToVietwareF(rl3("Thuc_hien_thanh_cong")), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                ReDim ArrRow(0)
                iArr = 1
                Exit Sub
            End If
            'For i As Integer = 1 To ArrRow.Length
            bChoose = True
            tdbg.Row = CInt(ArrRow(iArr).ToString)
            tdbg.Bookmark = CInt(ArrRow(iArr).ToString)
            CalSalAll()
        Else
            C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
        End If

        Me.Cursor = Cursors.Default
        tdbg.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If bSalAll Then  '11/02/2010
            If bOnCalculating Then Exit Sub
            CloseCalSalAll()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub CloseCalSalAll()
        bSalAll = False
        tdbg.Splits(0).DisplayColumns(COL_IsChosen).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_Updated).Visible = True
        tdbg.AllowUpdate = False
        btnAction.Width = 80
        btnAction.Left = btnAction.Left + 57
        tmr1.Enabled = False
        btnAction.Text = rL3("_Thuc_hien_") '&Thực hiện...
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        EnableContextMenu(True)
        LoadTDBGrid()
    End Sub

    Dim bP4500 As Boolean
    Dim bP2110 As Boolean
    Dim bP2600 As Boolean
    Dim bResult As Boolean

    Dim b4500 As Boolean = True 'Bien dung de nhan biet tinh luong thanh cong hay ko de xuat thong bao
   

    Private Sub LoadResult()
        If bP2600 Then
            Me.Cursor = Cursors.Default
            bP2600 = False

            Dim sSQL As New StringBuilder("")
            Dim iBookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

            'Mở form D13F2042 để xem kết quả tính lương
            'LoadTDBGrid()
            LoadResultSalCal(tdbg.Columns(COL_SalaryVoucherNo).Text, tdbg.Columns(COL_PayrollVoucherNo).Text, tdbg.Columns(COL_SalaryVoucherID).Text, gsPayRollVoucherID, tdbg.Columns(COL_SalCalMethodID).Text, tdbg.Columns(COL_TransferMethodID).Text, tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_Description).Text)
            'Lưu lại vết Audit
            Lemon3.D91.RunAuditLog("13""SalaryCalTrans", "02", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_SalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text, tdbg.Columns(COL_PayrollVoucherNo).Text, tdbg.Columns(COL_SalCalMethodID).Text)
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark

            tmr1.Enabled = False

            bOnCalculating = False
            EnableContextMenu(True)
        End If
    End Sub
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Dim sSQL As New StringBuilder("")
        bResult = False
        CheckForIllegalCrossThreadCalls = False
        startDate = Now
        'Tính lại bảng lương
        sSQL = New StringBuilder("")
        sSQL.Append(SQLStoreD13P4500())


        b4500 = CheckStoreShowMSGVB(sSQL.ToString)
        If b4500 Then
            'Chuyển bút toán
            If tdbg.Columns(COL_TransferMethodID).Text <> "" Then 'Columns(COL_SalCalMethodID).Text <> "" Then
                sSQL = New StringBuilder("")
                sSQL.Append(SQLStoreD13P2110())
                Dim b2110 As Boolean = ExecuteSQL(sSQL.ToString)
                bP2110 = True
            End If

            'Cập nhật lại thông tin thay đổi
            sSQL = New StringBuilder("")
            sSQL.Append(SQLUpdateD13T2600.ToString & vbCrLf)
            sSQL.Append(SQLStoreD13P4600) '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	
            bResult = ExecuteSQL(sSQL.ToString)
            bP2600 = True
        Else
            tmr1.Enabled = False
            ' pgb1.Value = 0
            pnlPic.Visible = False
            tdbg.BringToFront()
            Me.Cursor = Cursors.Default

            bOnCalculating = False
            EnableContextMenu(True)
        End If

        LoadTDBGrid()
    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        b4500 = True
    End Sub

    Private Sub tmr1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr1.Tick
        If bP2600 Then
            If bSalAll Then   '11/02/2010
                bP4500 = False
                bP2110 = False
                bP2600 = False
                tmr1.Enabled = False
                iArr += 1
                If bChoose Then
                    btnAction_Click(Nothing, Nothing)
                End If
                bOnCalculating = False
                bP2600 = False
                pnlPic.Visible = False
                tdbg.BringToFront()
            Else
                pnlPic.Visible = False
                tdbg.BringToFront()
                LoadResult()
               
            End If
        End If

        'If bP4500 Then
        '    If pgb1.Value >= 5000 Then
        '        bP4500 = False
        '    Else
        '        pgb1.PerformStep()
        '    End If

        'ElseIf bP4500 = False And bP2110 = False And bP2600 = False And pgb1.Value < 5000 Then
        '    Dim v1 As Long = startDate.Hour * 10000 + startDate.Minute * 100 + startDate.Second
        '    Dim v2 As Long = Now.Hour * 10000 + Now.Minute * 100 + Now.Second
        '    If v2 - v1 >= 30 Then
        '        pgb1.PerformStep()
        '        startDate = Now
        '    End If

        'ElseIf bP2110 Then
        '    If pgb1.Value >= 5500 Then
        '        bP2110 = False
        '    Else
        '        pgb1.PerformStep()
        '    End If

        'ElseIf bP2600 Then
        '    If pgb1.Value >= 6000 Then
        '        If bSalAll Then   '11/02/2010
        '            bP4500 = False
        '            bP2110 = False
        '            bP2600 = False
        '            pgb1.Value = 0
        '            tmr1.Enabled = False
        '            iArr += 1
        '            If bChoose Then
        '                btnAction_Click(Nothing, Nothing)
        '            End If
        '            bOnCalculating = False
        '            bP2600 = False
        '        Else
        '            LoadResult()
        '        End If
        '    Else
        '        pgb1.PerformStep()
        '    End If
        'End If
    End Sub

    Private Sub EnableContextMenu(ByVal b As Boolean)
        mnuAdd.Enabled = False
        For Each m As C1.Win.C1Command.C1Command In C1CommandHolder.Commands
            m.Enabled = b
        Next
    End Sub

    Private Function CheckLockedVoucher(ByVal iPer As Integer, ByVal sMessage As String) As Boolean
        If tdbg.Columns(COL_CreateUserID).Text <> gsUserID Then
            If iPerD13F5607 < iPer Then
                D99C0008.MsgL3(sMessage)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)

        If tdbg.RowCount > 0 Then
            mnuViewResultSalCalculation.Enabled = iPerD13F2040 >= 1 And L3Bool(tdbg.Columns(COL_Calculated).Text)
            mnuDeleteResultSalCalculation.Enabled = iPerD13F2040 >= 4 And L3Bool(tdbg.Columns(COL_Locked).Text) = False And L3Bool(tdbg.Columns(COL_Calculated).Text)
            mnuSalCalculate.Enabled = iPerD13F2040 >= 3 And L3Bool(tdbg.Columns(COL_Locked).Text) = False
            mnuCalSalAll.Enabled = iPerD13F2040 >= 3 And L3Bool(tdbg.Columns(COL_Locked).Text) = False

            mnuLockVoucher.Enabled = (iPerD13F5608 > 0 And L3Bool(tdbg.Columns(COL_Locked).Text) = False And (tdbg.Columns(COL_CreateUserID).Text = gsUserID Or iPerD13F5607 = 4))
            mnuOpenVoucher.Enabled = (iPerD13F5608 > 0 And L3Bool(tdbg.Columns(COL_Locked).Text) = True And (tdbg.Columns(COL_CreateUserID).Text = gsUserID Or iPerD13F5607 = 4))

            mnuView.Enabled = iPerD13F2040 >= 1
            mnuEdit.Enabled = iPerD13F2040 >= 3 And L3Bool(tdbg.Columns(COL_Locked).Text) = False
            mnuDelete.Enabled = iPerD13F2040 >= 4 And L3Bool(tdbg.Columns(COL_Locked).Text) = False
        Else
            mnuViewResultSalCalculation.Enabled = False
            mnuDeleteResultSalCalculation.Enabled = False
            mnuCalSalAll.Enabled = False
            mnuSalCalculate.Enabled = False

            mnuLockVoucher.Enabled = False
            mnuOpenVoucher.Enabled = False
        End If
        ' ID bổ sung 71282 - Vẫn xem được tính lương khi khóa sổ
        If gbClosed Then
            mnuAdd.Enabled = False
            mnuEdit.Enabled = False
            mnuDelete.Enabled = False
            mnuLockVoucher.Enabled = False
            mnuOpenVoucher.Enabled = False
            mnuCalSalAll.Enabled = False
            mnuSalCalculate.Enabled = False
            mnuDeleteResultSalCalculation.Enabled = False
        End If
    End Sub

    Private Sub CalSalAll()
        CheckForIllegalCrossThreadCalls = False
        bP4500 = False
        bP2110 = False
        bP2600 = False

        If CheckStore(SQLStoreD13P5555) = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        pnlPic.Visible = True
        pnlPic.BringToFront()
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
        tmr1.Enabled = True
        bOnCalculating = True
        EnableContextMenu(False)
    End Sub

#Region "Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/12/2006 08:27:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2043
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 23/12/2011 02:24:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2043() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2600
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/03/2007 11:41:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2600() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2600"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "TranMonth = " & giTranMonth & " And "
        sSQL &= "TranYear = " & giTranYear & " And "
        sSQL &= "SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2605
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/09/2009 11:34:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2605() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2605"
        sSQL &= " Where SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & vbCrLf
        'sSQL &= " And (Module = 'D29' Or Module = 'D45')" & vbCrLf
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2041
    '# Created User: DUCTRONG
    '# Created Date: 08/06/2009 04:31:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2041() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsCompanyID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Thanh Huyền
    '# Created Date: 16/11/2010 10:18:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3501
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/03/2007 01:56:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3501(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3501 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/03/2007 02:06:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4500 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(Convert.ToInt16(tdbg.Columns(COL_Calculated).Text)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2110
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/03/2007 02:11:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2110 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(Convert.ToInt16(tdbg.Columns(COL_Calculated).Text)) 'Mode, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2600
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/03/2007 02:15:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2600() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2600 Set ")
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
        sSQL.Append(" TranMonth = " & giTranMonth & " And ")
        sSQL.Append(" TranYear = " & giTranYear & " And ")
        sSQL.Append("SalaryVoucherID = " & SQLString(tdbg.Columns(COL_SalaryVoucherID).Text))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4600
    '# Created User: NGOCTHOAI
    '# Created Date: 14/07/2014 10:32:03
    '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tu dong san cong khi tinh luong" & vbCrlf)
        sSQL &= "Exec D13P4600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(Convert.ToInt16(tdbg.Columns(COL_Calculated).Text)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL

    End Function



#End Region


#Region "Active Find - List All (Client)"
    'Dim dtCaptionCols As DataTable

    Private WithEvents Finder As New D99C1001
    'Cần sửa Tìm kiếm như sau:
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

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New System.Text.StringBuilder()


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
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

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtMain.DefaultView.RowFilter = strFind
        ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
        'tdbg.WrapCellPointer = tdbg.RowCount > 0
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        FooterTotalGrid(tdbg, COL_SalaryVoucherNo)
    End Sub
#End Region

    '    ' Update 10/10/2012 id 51772 - Lỗi hiển thị thông báo khi tính lương
    '    ''' <summary>
    '    ''' Kiểm tra dữ liệu bằng Store (HÀM MỚI) dạng thông báo do store tự trả ra
    '    ''' </summary>
    '    ''' <param name="SQL">Store cần kiểm tra</param>
    '    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    '    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 4 cột là Status, Message, FontMessage, MsgAsk</remarks>
    '    Public Function CheckStoreShowMSGVB(ByVal SQL As String) As Boolean
    '        'Update 1/03/2010: sửa lại hàm checkstore có trả ra field FontMessage
    '        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
    '        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
    '        'Nếu store trả ra MsgAsk = 0 thì xuất Message nút Ok,  MsgAsk = 1 thì xuất Message nút Yes, No
    '
    '        Dim dt As New DataTable
    '        Dim sMsg As String
    '        Dim bMsgAsk As Boolean = False
    '        dt = ReturnDataTableMSGVB(SQL, "", False)
    '        If dt Is Nothing Then
    '            MessageBox.Show("Loi", MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '        If dt.Rows.Count > 0 Then
    '            If dt.Rows(0).Item("Status").ToString = "0" Then
    '                dt = Nothing
    '                Return True
    '            End If
    '
    '            sMsg = dt.Rows(0).Item("Message").ToString
    '            Dim bFontMessage As Boolean = False
    '            If dt.Columns.Contains("FontMessage") Then bFontMessage = True
    '            If dt.Columns.Contains("MsgAsk") Then
    '                If L3Byte(dt.Rows(0).Item("MsgAsk")) = 1 Then
    '                    bMsgAsk = True
    '                End If
    '            End If
    '
    '            If Not bMsgAsk Then 'OKOnly
    '                If Not bFontMessage Then
    '                    D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
    '                Else
    '                    Select Case dt.Rows(0).Item("FontMessage").ToString
    '                        Case "0" 'VietwareF
    '                            D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
    '                        Case "1" 'Unicode
    '                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
    '                            ' MessageBox.Show(ConvertUnicodeToVietwareF(sMsg), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
    '                        Case "2" 'Convert Vni To Unicode
    '                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
    '                    End Select
    '                End If
    '                dt = Nothing
    '                Return False
    '            Else 'YesNo
    '                If Not bFontMessage Then
    '                    If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
    '                        'If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
    '                        dt = Nothing
    '                        Return True
    '                    Else
    '                        dt = Nothing
    '                        Return False
    '                    End If
    '                Else
    '                    Select Case dt.Rows(0).Item("FontMessage").ToString
    '                        Case "0" 'VietwareF
    '                            If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                        Case "1" 'Unicode
    '                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                        Case "2" 'Convert Vni To Unicode
    '                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                    End Select
    '                End If
    '                End If
    '            dt = Nothing
    '        Else
    '            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
    '            Return False
    '        End If
    '
    '        '        Me.BringToFront()
    '        '        Me.Activate()
    '        Return True
    '    End Function

    Private Sub D13F2040_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

    End Sub
End Class


