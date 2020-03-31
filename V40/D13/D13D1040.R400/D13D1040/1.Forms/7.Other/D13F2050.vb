Imports System
Imports System.Text
Imports System.Collections

'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:38:01 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 30/08/2010
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F2050
    Dim report As D99C2003
    Dim dtCaptionCols As DataTable
    Private _formIDPermission As String = "D13F2050"

    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property
    Private sOrders As String = ""

#Region "Const of tdbg"
    Private Const COL_SalCalMethodID As Integer = 0   ' Mã
    Private Const COL_Description As Integer = 1      ' Diễn giải
    Private Const COL_DivisionID As Integer = 2       ' Mã đơn vị
    Private Const COL_DivisionName As Integer = 3     ' Tên đơn vị
    Private Const COL_CreateUserID As Integer = 4     ' Người lập
    Private Const COL_CreateDate As Integer = 5       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 6 ' Mã người sửa cuối
    Private Const COL_LastModifyDate As Integer = 7   ' Ngày sửa cuối
    Private Const COL_Disabled As Integer = 8         ' Không sử dụng
    Private Const COL_Orders As Integer = 9           ' STT
    Private Const COL_Caption As Integer = 10         ' Diễn giải khoản thu nhập
    Private Const COL_ShortName As Integer = 11       ' Tên tắt
    Private Const COL_IsNotPrint As Integer = 12      ' Không in
    Private Const COL_Normal As Integer = 13          ' Bình thường
    Private Const COL_PieceworkSalary As Integer = 14 ' Lương sản phẩm
    Private Const COL_IncomeTax As Integer = 15       ' Thuế thu nhập
    Private Const COL_PreTaxIncome As Integer = 16    ' Thu nhập trước thuế
    Private Const COL_InsurRate As Integer = 17       ' Tỷ lệ BH
    Private Const COL_Formular As Integer = 18        ' Công thức
    Private Const COL_FormularDesc As Integer = 19    ' Diễn giải công thức
    Private Const COL_IsSub As Integer = 20           ' HSL phụ
    Private Const COL_Decimals As Integer = 21        ' Làm tròn
    Private Const COL_SalAccuCheck As Integer = 22    ' Luỹ kế vào HSL
    Private Const COL_SalAccuSign As Integer = 23     ' Luỹ kế
    Private Const COL_SalAccumulator As Integer = 24  ' Luỹ kế vào
    Private Const COL_IsMainAccu As Integer = 25      ' Luỹ kế HSL chính
    Private Const COL_IsLemonWeb As Integer = 26      ' IsLemonWeb
    Private Const COL_IsUsed As Integer = 27          ' IsUsed
#End Region

    Dim dtGrid As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList
    Dim bSavedOK As Boolean = False
    Private dtSalCalMethodID As DataTable

    Private Sub D13F2050_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            Dim sInputUser As String = ""
            If txtSalCalMethodID.Text.Trim <> "" Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D13F2050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnDisplayColumn_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If

        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    optCalculationType0.Focus()
                Case Keys.D2, Keys.NumPad2
                    chkSalAccuCheck.Focus()
            End Select
        End If
        If e.KeyCode = Keys.Enter And Not txtFormularDesc.Focused And Not txtFormular.Focused Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbg1.Enabled = True Then
                HotKeyF11(Me, tdbg1)
            End If
        End If

    End Sub
    Private Sub SplitContainer1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Paint
        Dim splitter As SplitContainer = TryCast(sender, SplitContainer)
        If splitter Is Nothing Then
            Return
        End If
        If splitter.Orientation = Orientation.Horizontal Then
            e.Graphics.DrawLine(Pens.DarkGray, 0, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)), splitter.Width, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)))
            '  e.Graphics.DrawLine(Pens.DarkGray, L3Int(splitter.Width / 2) - 100, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)), L3Int(splitter.Width / 2) + 100, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)))
        Else
            e.Graphics.DrawLine(Pens.DarkGray, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)), 0, L3Int(splitter.SplitterDistance + (splitter.SplitterWidth / 2)), splitter.Height)
        End If
    End Sub
    Private iHeightSpitCon As Integer
    Private Sub AddItemsSalAccuSign()
        Dim _dt As New DataTable
        _dt.Columns.Add("SalAccuSign")
        _dt.Rows.Add("+")
        _dt.Rows.Add("-")
        LoadDataSource(tdbcSalAccuSign, _dt, gbUnicode)
    End Sub


    Private Sub D13F2050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        InputbyUnicode(Me, gbUnicode)
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        CheckIdTextBox(txtSalCalMethodID)
        Loadlanguage()
        ResetColorGrid(tdbg, 0, 2)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadTDBDropDown()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode)
        CallD09U1111_ChkDetail(True)
        ChangSplitByShowDetail()
        InputDateInTrueDBGrid(tdbg, COL_CreateDate)
        UnicodeGridDataField(tdbg1, UnicodeArrayCOL1(), gbUnicode)
        tdbg1_LockedColumns()
        txt_NumberFormat()
        SetBackColorObligatory()
        tdbcSalAccumulator.AutoCompletion = False
        SetResolutionForm(Me, ContextMenuStrip1)
        LoadOthers()
        btnFilter_Click(Nothing, Nothing)
        iHeightSpitCon = SplitContainer1.SplitterDistance
    End Sub

    Private Sub LoadOthers()
        tdbg1.Splits(0).DisplayColumns(COL1_HandAttendanceID).Visible = D13Systems.IsPayrollProject
        tdbg1.Splits(0).DisplayColumns(COL1_IsDistributeProject).Visible = D13Systems.IsPayrollProject
    End Sub
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_phuong_phap_tinh_luong_-_D13F2050") & UnicodeCaption(gbUnicode) 'Danh móc ph§¥ng phÀp tÛnh l§¥ng - D13F2050
        '===================================================Ư============= 
        Label1.Text = rL3("PP_tinh_luong") 'PP tính lương
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)"  'Lọc 
        '***************************************
        btnDisplayColumn.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkShowDetail.Text = rL3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        '================================================================ 
        tdbcSalCalMethodID.Columns("SalCalMethodID").Caption = rL3("Ma") 'Mã
        tdbcSalCalMethodID.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        '================================================================ 
        tdbg.Columns(COL_SalCalMethodID).Caption = rL3("Ma") 'Mã
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_DivisionID).Caption = rL3("Ma_don_vi") 'Mã đơn vị
        tdbg.Columns(COL_DivisionName).Caption = rL3("Ten_don_vi") 'Tên đơn vị
        tdbg.Columns(COL_CreateUserID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_CreateDate).Caption = rL3("Ngay_tao") 'Ngày tạo
        tdbg.Columns(COL_LastModifyUserID).Caption = rL3("Ma_nguoi_sua_cuoi") 'Mã người sửa cuối
        tdbg.Columns(COL_LastModifyDate).Caption = rL3("Ngay_sua_cuoi") 'Ngày sửa cuối
        tdbg.Columns(COL_Disabled).Caption = rL3("Khong_su_dung") 'Không sử dụng
        tdbg.Columns(COL_Orders).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_Caption).Caption = rL3("Dien_giai_khoan_thu_nhap") 'Diễn giải khoản thu nhập
        tdbg.Columns(COL_ShortName).Caption = rL3("Ten_tat") 'Tên tắt
        tdbg.Columns(COL_IsNotPrint).Caption = rL3("Khong_in") 'Không in
        tdbg.Columns(COL_Normal).Caption = rL3("Binh_thuong") 'Bình thường
        tdbg.Columns(COL_PieceworkSalary).Caption = rL3("Luong_san_pham") 'Lương sản phẩm
        tdbg.Columns(COL_IncomeTax).Caption = rL3("Thue_thu_nhap") 'Thuế thu nhập
        tdbg.Columns(COL_PreTaxIncome).Caption = rL3("Thu_nhap_truoc_thue") 'Thu nhập trước thuế
        tdbg.Columns(COL_InsurRate).Caption = rL3("Ty_le_BH") 'Tỷ lệ BH
        tdbg.Columns(COL_Formular).Caption = rL3("Cong_thuc") 'Công thức
        tdbg.Columns(COL_FormularDesc).Caption = rL3("Dien_giai_cong_thuc") 'Diễn giải công thức
        tdbg.Columns(COL_IsSub).Caption = rL3("HSL_phu") 'HSL phụ
        tdbg.Columns(COL_Decimals).Caption = rL3("Lam_tron") 'Làm tròn
        tdbg.Columns(COL_SalAccuCheck).Caption = rL3("Luy_ke_vao_HSLU") 'Luỹ kế vào HSL
        tdbg.Columns(COL_SalAccuSign).Caption = rL3("Luy_keU") 'Luỹ kế
        tdbg.Columns(COL_SalAccumulator).Caption = rL3("Luy_ke_vao") 'Luỹ kế vào
        tdbg.Columns(COL_IsMainAccu).Caption = rL3("Luy_ke_HSL_chinhU") 'Luỹ kế HSL chính
        tdbg.Columns(COL_IsUsed).Caption = rL3("Da_tinh_luong") 'Đã tính lương
        '================================================================ 
        tsmEstablishDetail.Text = rL3("Thiet__lap_chi_tiet") 'Thiết &lập chi tiết
        tsmInheritDetail.Text = rL3("Ke_thu_a_phuong_phap_tinh_luong") 'Kế thừ&a phương pháp tính lương
        mnsInheritDetail.Text = tsmInheritDetail.Text
        tsmBackPay.Text = rL3("Thiet_la_p_hoi_to_luong_va_thu_nhap_he_thong") 'Thiết lậ&p hồi tố lương và thu nhập hệ thống
        mnsBackPay.Text = tsmBackPay.Text
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        chkIsLemonWeb.Text = rL3("Xem_tren_LemonWeb") 'Xem trên LemonWeb
        chkDisabled.Text = rL3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        lblSalCalMethodID.Text = rL3("Ma") 'Mã
        lblDescription.Text = rL3("Dien_giai") 'Diễn giải
        lblMethod.Text = rL3("Phuong_phap_luy_ke") 'Phương pháp lũy kế
        lblIssurRate.Text = rL3("Ty_le_BH") 'Tỷ lệ (BHXH, BHYT)
        '================================================================ 
        btnFormula.Text = rL3("_Cong_thuc") '&Công thức
        lblDecimals.Text = rL3("Lam_tron") 'Làm tròn
        lblFormularDesc.Text = rL3("Dien_giai")
        lblDivisionName.Text = rL3("Don_vi")
        '================================================================ 
        'btnChamCong.Text = rl3("Dieu__chinh_thu_nhap") 'Điều &chỉnh thu nhập
        btnSave.Text = rL3("_Luu") '&Lưu
        btnNotSave.Text = rL3("_Khong_luu") '&Không Luu 
        btnNext.Text = rL3("Luu_va_Nhap__tiep")
        '================================================================ 
        chkListAll.Text = rL3("Hien_thi_tat_ca") 'Hiển thị tất cả
        chkSalAccuCheck.Text = rL3("Luy_ke_vao_HSL") 'Lũy kế vào HSL
        chkIsSub.Text = rL3("HSL_phu") 'HSL phụ
        chkIsSortProcessOrderNum.Text = rL3("Sap_xep_theo_TT_khoan_TN")
        '================================================================ 
        optIsMainAccu0.Text = rL3("Luy_ke_binh_thuong") 'Lũy kế bình thường
        optIsMainAccu1.Text = rL3("Luy_ke_HSL_chinh") 'Lũy kế HSL chính
        optCalculationType3.Text = rL3("Thu_nhap_truoc_thue") 'Thu nhập trước thuế
        optCalculationType2.Text = rL3("Thue_thu_nhap") 'Thuế thu nhập
        optCalculationType1.Text = rL3("Luong_san_pham") 'Lương sản phẩm
        optCalculationType0.Text = rL3("Binh_thuong") 'Bình thường
        '================================================================ 
        grp2.Text = rL3("Thiet_lap_cac_khoan_thu_nhap") 'Thiết lập các khoản thu nhập
        grp4.Text = "2. " & rL3("Luy_ke") 'Lũy kế
        grp3.Text = "1. " & rL3("Loai_thu_nhap") 'Loại thu nhập
        '================================================================ 
        tdbcSalAccumulator.Columns("Short").Caption = rL3("Ma") 'Mã
        tdbcSalAccumulator.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg1.Splits(0).Caption = rL3("Cac_khoan_thu_nhap")
        tdbg1.Columns("Orders").Caption = "   " & rL3("TT_khoan_TN") '  rl3("STT") 'STT ' update 5/6/2013 id 56508
        tdbg1.Columns("ProcessOrderNum").Caption = rL3("TT_xu_ly") ' update 5/6/2013 id 56508
        tdbg1.Columns("CalNo").Caption = rL3("Ma_khoan_thu_nhap_de_tinh_luong") 'Mã khoản thu nhập để tính lương
        tdbg1.Columns("Caption").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg1.Columns("ShortName").Caption = rL3("Ten_tat") 'Tên tắt
        tdbg1.Columns(COL1_SalSystemID).Caption = rL3("Khoan_thu_nhap_he_thong") 'Khoản thu nhập hệ thống
        tdbg1.Columns("IsNotPrint").Caption = rL3("Khong_in") 'Không in
        tdbg1.Columns("IsBackPay").Caption = rL3("Hoi_to_luong") 'Hồi tố lương
        tdbg1.Columns("IsLemonWeb").Caption = rL3("Xem_tren_LemonWeb") 'Xem trên LemonWeb

        tdbg1.Columns("IsDistributeProject").Caption = rL3("Phan_bo_theo_du_an") 'Phân bổ theo dự án
        tdbg1.Columns("HandAttendanceID").Caption = rL3("Loai_cong") 'Loại công

        '================================================================ 
        tdbdHandAttendanceID.Columns("HandAttendanceID").Caption = rL3("Ma") 'Mã
        tdbdHandAttendanceID.Columns("Description").Caption = rL3("Ten") 'Tên

    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Description, COL_Caption, COL_ShortName, COL_FormularDesc, COL_DivisionName}
        Return ArrCOL
    End Function

    Private Sub CallD09U1111_ChkDetail(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_SalCalMethodID, COL_Description}
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, False, False, gbUnicode)
            'không add Split Detail vào
            AddColVisible(tdbg, SPLIT0, arrDetail, arrColObligatory, False, False, gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrDetail, arrColObligatory, False, False, gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrDetail, arrColObligatory, False, False, gbUnicode)
        End If
        'Dim dtCaptionCols As DataTable
        If chkShowDetail.Checked Then
            dtCaptionCols = CreateTableForExcel(tdbg, arrDetail)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "1", , bLoadFirst, , gbUnicode)
        Else
            dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
        End If
    End Sub

    Private Sub ChangSplitByShowDetail()
        If chkShowDetail.Checked Then
            'Thêm Split 1 và 2
            tdbg.InsertHorizontalSplit(1)
            tdbg.InsertHorizontalSplit(2)
            tdbg.Splits(1).RecordSelectors = False
            tdbg.Splits(2).RecordSelectors = False
            'Ẩn hiển cột của Split
            'Split 1
            For i As Integer = tdbg.Columns.IndexOf(tdbg.Columns(COL_SalCalMethodID)) To tdbg.Columns.IndexOf(tdbg.Columns(COL_LastModifyDate))
                tdbg.Splits(1).DisplayColumns(i).Visible = False
                tdbg.Splits(2).DisplayColumns(i).Visible = False
            Next
            For i As Integer = tdbg.Columns.IndexOf(tdbg.Columns(COL_Orders)) To tdbg.Columns.IndexOf(tdbg.Columns(COL_IsNotPrint))
                tdbg.Splits(1).DisplayColumns(i).Visible = True
            Next

            For i As Integer = tdbg.Columns.IndexOf(tdbg.Columns(COL_Normal)) To tdbg.Columns.IndexOf(tdbg.Columns(COL_IsMainAccu))
                tdbg.Splits(2).DisplayColumns(i).Visible = True
            Next
            tdbg.Splits(2).DisplayColumns(COL_IsMainAccu).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Splits(2).DisplayColumns(COL_IsMainAccu).Width = 80

            tdbg.Splits(0).DisplayColumns(COL_Description).Width = 200
            tdbg.Splits(0).DisplayColumns(COL_SalCalMethodID).Width = 110

            tdbg.Splits(0).DisplayColumns(COL_CreateDate).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
            tdbg.Splits(0).DisplayColumns(COL_Disabled).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
        Else
            'Xóa 2 split
            If tdbg.Splits.Count > 2 Then
                tdbg.RemoveHorizontalSplit(tdbg.Splits.Count - 1)
                tdbg.RemoveHorizontalSplit(tdbg.Splits.Count - 1)
            End If

            tdbg.Splits(0).DisplayColumns(COL_Description).Width = 250
            tdbg.Splits(0).DisplayColumns(COL_SalCalMethodID).Width = 140
            tdbg.Splits(0).DisplayColumns(COL_CreateDate).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
            tdbg.Splits(0).DisplayColumns(COL_Disabled).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
    End Sub

    Private Sub chkShowDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDetail.CheckedChanged
        ChangSplitByShowDetail()
        CallD09U1111_ChkDetail(False)
        If dtGrid Is Nothing Then Exit Sub
        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        LoadTDBGrid(True)
        'LoadEdit()
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2051() 'SalCalMethodID
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            sFind = ""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("SalCalMethodID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
        End If
        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        'tdbg_RowColChange(Nothing, Nothing)

    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If dtGrid.Rows.Count = 0 Then
            If dtMain IsNot Nothing Then dtMain.Clear()
        Else
            _FormState = EnumFormState.FormView
            LoadEdit()
        End If
        If dtGrid.Rows.Count = 0 AndAlso tsbAdd.Enabled Then
            tsbAdd_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub ResetGrid()
        EnabledMenu(False)
        FooterTotalGrid(tdbg, COL_SalCalMethodID)
    End Sub

    Private Sub LoadSalCalMethodID()
        If chkShowDisabled.Checked Then
            LoadDataSource(tdbcSalCalMethodID, dtSalCalMethodID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbcSalCalMethodID, ReturnTableFilter(dtSalCalMethodID, "Disabled <>1", True), gbUnicode)
        End If
    End Sub
    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        LoadSalCalMethodID()
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub EnabledMenu(ByVal bEnabled As Boolean)
        'If dtGrid Is Nothing Then Exit Sub
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
            CheckMenu("-1", TableToolStrip, -1, False, False, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F2050")
        End If
        tsmInheritDetail.Enabled = tdbg.RowCount > 0 And ReturnPermission("D13F2050") > 2
        mnsInheritDetail.Enabled = tsmInheritDetail.Enabled
        tsmEstablishDetail.Enabled = tdbg.RowCount > 0 And ReturnPermission("D13F2050") > 2
        tsmBackPay.Enabled = tdbg.RowCount > 0
        mnsBackPay.Enabled = tsmBackPay.Enabled

        ' update 27/3/2013 id 55214 - Chuẩn hóa phân quyền menu Import dữ liệu
        ' ImportData phân quyền theo 2 màn hình D13F5605 và PARA_FormIDPermission
        tsbImportData.Enabled = tsbImportData.Enabled And tsbAdd.Enabled
        tsmImportData.Enabled = tsbImportData.Enabled
        mnsImportData.Enabled = tsbImportData.Enabled
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        tdbg.UpdateData()
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, SQLNumber(chkShowDetail.Checked), gbUnicode)
        '*****************************************
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "Menu bar"

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit
        _bSaved = False
        EnabledMenu(True)
        'tdbcDivisionID.Enabled = CheckStore(SQLStoreD13P5555(1))
        If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
            D99C0008.MsgL3(rL3("Du_lieu_da_duoc_su_dung_Ban_chi_duoc_phep_sua_mot_so_thong_tin"))
        End If
        tdbcDivisionID.Enabled = Not L3Bool(tdbg.Columns(COL_IsUsed).Text)

        tdbg1.AllowUpdate = tdbcDivisionID.Enabled
        grp2.Enabled = tdbcDivisionID.Enabled
        ReadOnlyControl(txtSalCalMethodID)
        txtDescription.Focus()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click

        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        ' update 5/9/2012 incident 50479
        If Not CheckStore(SQLStoreD13P5555(0)) Then Exit Sub
        'If CheckBeforeDelete() = False Then Exit Sub => bỏ câu select này theo Thiên Nghĩa

        Dim sSQL As String = ""
        sSQL = "Delete D13T2501 Where SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text) & vbCrLf
        sSQL &= "Delete D13T2500 Where SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text)
        Dim bResult As Boolean = ExecuteSQL(sSQL)

        If bResult = True Then
            DeleteOK()

            'If CheckAudit("SalaryCalMethod") = True Then
            '    sSQL = SQLStoreD91P9106("SalaryCalMethod", "13", "03", tdbg.Columns(COL_SalCalMethodID).Text, tdbg.Columns(COL_Disabled).Text, "", "", "")
            '    ExecuteSQLNoTransaction(sSQL.ToString)
            'End If

            Lemon3.D91.RunAuditLog("13", "SalaryCalMethod", "03", tdbg.Columns(COL_SalCalMethodID).Text, tdbg.Columns(COL_Disabled).Text, "", "", "")

            LoadTDBCombo()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
    End Sub

    ' update 14/3/2013 id 54314
    Private Sub tsmExportDataScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExportDataScript.Click, mnsExportDataScript.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "sFormName", "D13F2050") ' Tài liệu phân tích
        SetProperties(arrPro, "ModuleID", "D13")
        SetProperties(arrPro, "sStr01", tdbg.Columns(COL_SalCalMethodID).Text) ' Tài liệu phân tích
        CallFormShow(Me, "D80D0040", "D80F2095", arrPro)
    End Sub

    Private Sub tsbImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        If CallShowDialogD80F2090(D13, "D13F5605", "D13F2050") Then
            LoadTDBCombo()
            btnFilter_Click(Nothing, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        'Dim report As New D99C1003
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R2050"
        Dim sSubReportName As String = IIf(gbUnicode, "D91R0000", "D09R6000").ToString
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rL3("Phuong_phap_tinh_luongW") & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, "") & sReportName & ".rpt"
        sSQL = SQLPrint()
        sSQLSub = IIf(gbUnicode, "Select * From D91V0016 Where DivisionID = '%'", "Select * From D09V0009").ToString
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmEstablishDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim EnableSave As Boolean
        Dim sSQL As String = ""
        sSQL = "Select TOP 1 1 FROM D13T2600  WITH(NOLOCK) WHERE SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text) & " And Calculated = 1"
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rL3("Phuong_phap_tinh_luong_nay_da_duoc_su_dung") & vbCrLf & rL3("Ban_khong_duoc_phep_suaU"))
            EnableSave = False
        Else
            EnableSave = True
        End If

        Dim f As New D13F2052
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .DivisionName() = tdbg.Columns(COL_DivisionName).Text
            .EnableSave = EnableSave
            .SalCalMethodID = tdbg.Columns(COL_SalCalMethodID).Text
            .DescriptionID = tdbg.Columns(COL_Description).Text
            .FormState = EnumFormState.FormOther
            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With
    End Sub

    Private Sub tsmInheritDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInheritDetail.Click, mnsInheritDetail.Click
        If ExistRecord("Select TOP 1 1 FROM D13T2600  WITH(NOLOCK)  WHERE SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text) & " And Calculated = 1") Then
            D99C0008.MsgL3(rL3("Phuong_phap_tinh_luong_nay_da_duoc_su_dung_Ban_khong_duoc_phep_ke_thua_chi_tiet"))
        Else
            Dim f As New D13F2053
            Dim iBookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
            With f
                .SalCalMethodID = tdbg.Columns(COL_SalCalMethodID).Text
                .Description = tdbg.Columns(COL_Description).Text
                .ShowDialog()
                If .bSaved = True Then
                    LoadTDBGrid()
                    If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
                End If
                .Dispose()
            End With
        End If
    End Sub

    ' update 1/10/2013 id 59622
    Private Sub tsmBackPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New D13F2055
        f.SalaryMethodID = tdbg.Columns(COL_SalCalMethodID).Text
        f.SalaryMethodName = tdbg.Columns(COL_Description).Text
        f.ShowDialog()
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_SalCalMethodID).Text)
        End If
        f.Dispose()
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region
#Region "Grid"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
            If tdbg.RowCount = 0 Then
                dtMain.Clear()
            End If
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events tdbcSalCalMethodID"

    Private Sub tdbcSalCalMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.LostFocus
        If tdbcSalCalMethodID.FindStringExact(tdbcSalCalMethodID.Text) = -1 Then tdbcSalCalMethodID.Text = ""
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcSalCalMethodID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalCalMethodID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region
    Private Sub btnDisplayColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayColumn.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(btnDisplayColumn.Left + 8, btnDisplayColumn.Bottom + btnDisplayColumn.Height + 8)
        'usrOption.Location = New Point(tdbg1_KeyPress.Left, chkShowDisabled.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Function CheckBeforeDelete() As Boolean
        Dim sSQL As String
        'Kiểm tra trong phiếu tính lương
        sSQL = "Select SalCalMethodID From D13T2600  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text)
        Dim sRet As String = ReturnScalar(sSQL)
        If sRet <> "" Then
            D99C0008.MsgL3(MsgNotDeleteData)
            Return False
        End If
        Return True
    End Function

    Private Function SQLPrint() As String
        Dim sSQL As String = ""
        sSQL &= " SELECT 	D.SalCalMethodID, D.Description, D2.Code, D.DescriptionU, D1.CaptionU, D1.ShortNameU, D1.FormularU, D1.FormularDescU, " & vbCrLf
        sSQL &= " 			CalNo,Caption ,ShortName, CalculationType , Formular, " & vbCrLf
        sSQL &= " 			D1.Decimals, SalAccuCheck, SalAccuSign, SalAccumulator," & vbCrLf
        sSQL &= " InsAccuCheck, InsAccuSign, InsAccumulator, IsSub, " & vbCrLf
        sSQL &= " IsMainAccu, 	InSurRate, Convert(bit,IsNotPrint) as" & vbCrLf
        sSQL &= "  IsNotPrint, FormularDesc" & vbCrLf
        sSQL &= " FROM 		D13T2500 D  WITH(NOLOCK) " & vbCrLf
        sSQL &= " INNER JOIN 	D13T2501 D1  WITH(NOLOCK) " & vbCrLf
        sSQL &= " ON 		D.SalCalMethodID = D1.SalCalMethodID" & vbCrLf
        sSQL &= " LEFT JOIN 	D13T9000 D2  WITH(NOLOCK) " & vbCrLf
        sSQL &= " ON 		D1.CALNo = D2.CODE " & vbCrLf
        sSQL &= " WHERE 	D.SalCalMethodID = " & SQLString(tdbg.Columns(COL_SalCalMethodID).Text) & vbCrLf
        sSQL &= " 			AND D2.Type='PRCAL' " & vbCrLf
        sSQL &= " AND D2.Disabled=0 AND  D1.Disabled =0" & vbCrLf
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2051
    '# Created User: 
    '# Created Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2051() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2051 "
        sSQL &= SQLNumber(chkShowDetail.Checked) & COMMA 'IsDetailDisplay, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalCalMethodID)) 'SalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'AnchorForControl(EnumAnchorStyles.TopLeftRight, GroupBox2, tdbg)

        'AnchorForControl(EnumAnchorStyles.TopRightBottom, grp2, txtFormular)
        'AnchorForControl(EnumAnchorStyles.BottomRight, pnlB, pnlD)
        'AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, grp1, tdbg1)
        'AnchorForControl(EnumAnchorStyles.BottomLeft, chkIsSortProcessOrderNum, chkListAll)
    End Sub

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg1 - Total of Columns: 26"
    Private Const COL1_ProcessOrderNum As Integer = 0     ' TT xử lý
    Private Const COL1_Orders As Integer = 1              ' TT khoản TN
    Private Const COL1_CalNo As Integer = 2               ' Mã khoản thu nhập để tính lương
    Private Const COL1_Enabled As Integer = 3             ' Enabled
    Private Const COL1_Caption As Integer = 4             ' Diễn giải
    Private Const COL1_ShortName As Integer = 5           ' Tên tắt
    Private Const COL1_SalSystemID As Integer = 6         ' Khoản thu nhập hệ thống
    Private Const COL1_IsDistributeProject As Integer = 7 ' Phân bổ theo dự án
    Private Const COL1_HandAttendanceID As Integer = 8    ' Loại công
    Private Const COL1_IsBackPay As Integer = 9           ' Hồi tố lương
    Private Const COL1_CalculationType As Integer = 10    ' Phương pháp tính mỗi khoản thu nhập
    Private Const COL1_Formular As Integer = 11           ' Công thức tính lương
    Private Const COL1_Decimals As Integer = 12           ' Làm tròn thập phân
    Private Const COL1_SalAccuCheck As Integer = 13       ' Có/không lũy kế vào HSL
    Private Const COL1_SalAccuSign As Integer = 14        ' Dấu (+) hoặc (-) khi lũy kế
    Private Const COL1_SalAccumulator As Integer = 15     ' Khoản thu nhập trong HSL được lũy kế
    Private Const COL1_InsAccuCheck As Integer = 16       ' Có/không lũy kế vào HSBH
    Private Const COL1_InsAccuSign As Integer = 17        ' Dấu (+) hoặc (-) khi lũy kế 1
    Private Const COL1_InsAccumulator As Integer = 18     ' Khoản bảo hiểm trong HSL được lũy kế
    Private Const COL1_IsSub As Integer = 19              ' Tính hồ sơ lương phụ
    Private Const COL1_IsMainAccu As Integer = 20         ' Lũy kế HSL chính
    Private Const COL1_InSurRate As Integer = 21          ' Tỷ lệ BH trong phương pháp tính lương Gross
    Private Const COL1_IsNotPrint As Integer = 22         ' Không in
    Private Const COL1_IsLemonWeb As Integer = 23         ' Xem trên LemonWeb
    Private Const COL1_FormularDesc As Integer = 24       ' FormularDesc
    Private Const COL1_IsUpdate As Integer = 25           ' IsUpdate
#End Region


    Private _EnableSave As Boolean
    Public WriteOnly Property EnableSave() As Boolean
        Set(ByVal value As Boolean)
            _EnableSave = value
        End Set
    End Property

    Private _salCalMethodID As String
    Private _description As String
    Dim dtMain As DataTable

    Public Property SalCalMethodID() As String
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal value As String)
            If SalCalMethodID = value Then
                _salCalMethodID = ""
                Return
            End If
            _salCalMethodID = value
        End Set
    End Property

    Public Property DescriptionID() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If DescriptionID = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private _divisionName As String
    Public WriteOnly Property DivisionName() As String
        Set(ByVal Value As String)
            _divisionName = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                Case EnumFormState.FormOther
            End Select
        End Set
    End Property
    Private Sub LoadEdit()
        txtSalCalMethodID.Text = tdbg.Columns(COL_SalCalMethodID).Text
        tdbg.Columns(COL_SalCalMethodID).Tag = tdbg.Columns(COL_SalCalMethodID).Text
        txtDescription.Text = tdbg.Columns(COL_Description).Text
        tdbcDivisionID.SelectedValue = tdbg.Columns(COL_DivisionID).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        chkIsLemonWeb.Checked = L3Bool(tdbg.Columns(COL_IsLemonWeb).Text)
        LoadGridDataTable()
        LoadTDBGridDetail(True)
        InitControl()
        If dtMain.Rows.Count > 0 Then tdbg1_RowColChange(Nothing, Nothing)
        chkDisabled.Visible = True
        ReadOnlyControl(txtSalCalMethodID)
        tdbcDivisionID.Enabled = True
        grp2.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Function UnicodeArrayCOL1() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL1_Caption, COL1_ShortName, COL1_FormularDesc} ' COL1_Formular
        Return ArrCOL
    End Function


    Private Sub btnChamCong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New D13F2054
        With f
            .FormID = "D13F2054"
            .ShowDialog()
            .Dispose()
            txtFormular.Text &= f.ReturnFormular
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2052
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 25/12/2009 10:53:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2052() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2052 "
        sSQL &= SQLString(txtSalCalMethodID.Text) 'SalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub LoadGridDataTable()
        dtMain = ReturnDataTable(SQLStoreD13P2052)
        Dim col() As DataColumn = {dtMain.Columns("CalNo")}
        dtMain.PrimaryKey = col
    End Sub

    Dim bChangedCheckListAll As Boolean = False
    Private Sub LoadTDBGridDetail(Optional ByVal bFirstLoad As Boolean = False)
        Dim sKey As String = tdbg1.Columns(COL1_Orders).Text
        Dim dtT As DataTable = CType(tdbg1.DataSource, DataTable)
        If Not bFirstLoad AndAlso dtT IsNot Nothing Then
            dtMain.Merge(dtT, False, MissingSchemaAction.AddWithKey)
        End If
        LoadDataSource(tdbg1, dtMain, gbUnicode)
        chkIsSortProcessOrderNum_CheckedChanged(Nothing, Nothing)
        ReLoadTDBGrid1()
    End Sub

    Private Sub ReLoadTDBGrid1()
        dtMain.AcceptChanges()
        Dim sFilter As String = ""
        If Not chkListAll.Checked Then
            sFilter = "Enabled=True"
        End If
        dtMain.DefaultView.RowFilter = sFilter
    End Sub

    Private Sub optCalculationType3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType3.Click
        txtIssurRate.Enabled = True
        txtIssurRate.Focus()
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_CalculationType) = 3
            tdbg1(tdbg1.Row, COL1_InSurRate) = txtIssurRate.Text
        End If
    End Sub

    Private Sub optCalculationType0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType0.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_CalculationType) = 0
        End If
    End Sub

    Private Sub optCalculationType2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType2.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_CalculationType) = 2
        End If
    End Sub

    Private Sub optCalculationType1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType1.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_CalculationType) = 1
        End If
    End Sub
    Private Function InitDataComboDecimals() As DataTable
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("Decimals")
        For i As Integer = -5 To 5
            dataTable.Rows.Add(i)
        Next
        Return dataTable
    End Function

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcSalAccumulator
        sSQL = "Select Short" & UnicodeJoin(gbUnicode) & " as Short, " & IIf(gbUnicode, "DescriptionU", "Description").ToString & " as Description, Code From D13T9000  WITH(NOLOCK) Where Type = 'PRMAS' And Disabled = 0 "
        LoadDataSource(tdbcSalAccumulator, sSQL, gbUnicode)

        'Load tdbcSalCalMethodID
        sSQL = "Select '%' As SalCalMethodID, " & AllName & " As Description, 0 as DisplayOrder, 0 AS Disabled" & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select SalCalMethodID, " & IIf(gbUnicode, "DescriptionU", "Description").ToString & " as Description, 1 as DisplayOrder,Disabled From D13T2500  WITH(NOLOCK) order by DisplayOrder, Description "
        dtSalCalMethodID = ReturnDataTable(sSQL)
        LoadSalCalMethodID() ' 81193  27/10/2015
        tdbcSalCalMethodID.AutoSelect = True

        'Load tdbcDivisionID
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", , gbUnicode)
        LoadDataSource(tdbcDecimal, InitDataComboDecimals, gbUnicode)

        AddItemsSalAccuSign()
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdSalSystemID
        sSQL = "SELECT		Code AS SalSystemID, Short" & UnicodeJoin(gbUnicode) & " AS SalSysShortName "
        sSQL &= "FROM		D13T9000 "
        sSQL &= "WHERE		Disabled = 0 and Type = 'PRSYS' "
        sSQL &= "ORDER BY	Code"
        LoadDataSource(tdbdSalSystemID, sSQL, gbUnicode)

        sSQL = "-- Do nguon DD Loai cong" & vbCrLf & _
                "SELECT 		HandAttendanceID, DescriptionU as Description, Decimals, IsLeaveType " & vbCrLf & _
                "FROM 		D29T1070 WITH (NOLOCK) " & vbCrLf & _
                "WHERE 		Disabled=0 AND IsSalaryType = 1" & vbCrLf & _
                "ORDER BY 	HandAttendanceID"
        LoadDataSource(tdbdHandAttendanceID, sSQL, gbUnicode)
    End Sub

    Private Sub ShowDetailGrid()
        If tdbg1.RowCount >= 1 Then
            If tdbg1.Columns(COL1_CalculationType).Text <> "" Then
                If L3Int(tdbg1.Columns(COL1_CalculationType).Text) = 0 Then
                    optCalculationType0.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False

                ElseIf L3Int(tdbg1.Columns(COL1_CalculationType).Text) = 1 Then
                    optCalculationType1.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False

                ElseIf L3Int(tdbg1.Columns(COL1_CalculationType).Text) = 2 Then
                    optCalculationType2.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False
                Else
                    optCalculationType3.Checked = True
                    txtIssurRate.Enabled = True
                    txtIssurRate.Text = tdbg1.Columns(COL1_InSurRate).Text
                End If
            End If
            txt_NumberFormat()
            txtFormular.Text = tdbg1.Columns(COL1_Formular).Text
            txtFormularDesc.Text = tdbg1.Columns(COL1_FormularDesc).Text
            If tdbg1.Columns(COL1_IsSub).Text <> "" Then
                If L3Int(tdbg1.Columns(COL1_IsSub).Text) = 0 Then
                    chkIsSub.Checked = False
                Else
                    chkIsSub.Checked = True
                End If
            End If

            tdbcDecimal.Text = tdbg1.Columns(COL1_Decimals).Text
            If tdbg1.Columns(COL1_SalAccuCheck).Text <> "" Then
                chkSalAccuCheck.Checked = CBool(Convert.ToInt16(tdbg1.Columns(COL1_SalAccuCheck).Text))
            End If
            If chkSalAccuCheck.Checked = False Then
                tdbcSalAccuSign.Text = ""
                tdbcSalAccumulator.Text = ""
                tdbcSalAccuSign.Enabled = False
                tdbcSalAccumulator.Enabled = False
            Else
                tdbcSalAccuSign.Enabled = True
                tdbcSalAccumulator.Enabled = True
                tdbcSalAccuSign.SelectedValue = tdbg1.Columns(COL1_SalAccuSign).Text
                tdbcSalAccumulator.SelectedValue = tdbg1.Columns(COL1_SalAccumulator).Text
            End If
            If tdbg1.Columns(COL1_IsMainAccu).Text <> "" Then
                If L3Int(tdbg1.Columns(COL1_IsMainAccu).Text) = 1 Then
                    optIsMainAccu1.Checked = True
                Else
                    optIsMainAccu0.Checked = True
                End If
            End If
            If tdbg1(tdbg1.Row, COL1_Enabled).ToString <> "" Then
                If Convert.ToInt16(tdbg1(tdbg1.Row, COL1_Enabled)) = 0 Then
                    EnabledControl(False)
                    txtIssurRate.Enabled = False
                Else
                    EnabledControl(True)
                End If
            End If
        End If
    End Sub
    Private Sub tdbg1_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg1.FetchCellTips
        Select Case e.ColIndex
            Case COL1_Caption
                If Trim(tdbg1.Columns(COL1_Caption).Text).Length > tdbg1.Splits(0).DisplayColumns(COL1_Caption).Width Then
                    e.CellTip = tdbg1.Columns(COL1_Caption).Text
                End If
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Dim sValueCurrent As String = "" ' Lưu giá trị để focus

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        sValueCurrent = tdbg1.Columns(COL1_Orders).Text
        ShowDetailGrid()
        If tdbg1.Col = COL1_HandAttendanceID Then
            tdbg1.Splits(0).DisplayColumns(tdbg1.Col).Button = L3Bool(tdbg1(tdbg1.Row, COL1_IsDistributeProject))
            tdbg1.UpdateData()
        End If
    End Sub

    Private Sub chkSalAccuCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalAccuCheck.Click
        If tdbg1.RowCount >= 1 Then
            If chkSalAccuCheck.Checked = True Then
                tdbcSalAccuSign.Enabled = True
                tdbcSalAccumulator.Enabled = True
                tdbg1(tdbg1.Row, COL1_SalAccuCheck) = 1
                tdbg1(tdbg1.Row, COL1_SalAccuSign) = tdbcSalAccuSign.Text
                tdbg1(tdbg1.Row, COL1_SalAccumulator) = ReturnValueC1Combo(tdbcSalAccumulator, "Code") 'tdbcSalAccumulator.Text
            Else
                tdbcSalAccuSign.SelectedIndex = -1
                tdbcSalAccuSign.Text = ""
                tdbcSalAccumulator.Text = ""
                tdbcSalAccuSign.Enabled = False
                tdbcSalAccumulator.Enabled = False
                tdbg1(tdbg1.Row, COL1_SalAccuCheck) = 0
                tdbg1(tdbg1.Row, COL1_SalAccuSign) = ""
                tdbg1(tdbg1.Row, COL1_SalAccumulator) = ""

            End If
        End If
    End Sub

    Private Sub txt_NumberFormat()
        txtIssurRate.Text = (SQLNumber(txtIssurRate.Text, DxxFormat.DefaultNumber2)).ToString
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2501
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2007 09:20:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2501() As String
        Dim sSQL As String = ""
        'Dim dt As DataTable = CType(tdbg1.DataSource, DataTable).DefaultView.ToTable
        '   Dim dt As DataTable = ReturnTableFilter(dtMain, "IsUpdate=True", True)
        Dim dr As DataRow
        Dim dt As DataTable = dtMain.Copy

        Dim sUnicode As String = UnicodeJoin(gbUnicode)
        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            sSQL &= "Update D13T2501  Set " & vbCrLf
            sSQL &= " Caption = " & SQLStringUnicode(dr("Caption" & sUnicode).ToString, gbUnicode, False) & COMMA 'varchar[150], NOT NULL
            sSQL &= " CaptionU = " & SQLStringUnicode(dr("Caption" & sUnicode).ToString, gbUnicode, True) & COMMA 'varchar[150], NOT NULL
            sSQL &= "Formular = " & SQLString(dr("Formular").ToString) & COMMA 'varchar[2000], NULL
            'sSQL &= "FormularU = " & SQLStringUnicode(dr("FormularU").ToString, gbUnicode, True) & COMMA 'varchar[2000], NULL
            sSQL &= "CalculationType = " & SQLNumber(dr("CalculationType").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "Decimals = " & SQLNumber(dr("Decimals").ToString) & COMMA 'int, NOT NULL
            sSQL &= "SalAccuCheck = " & SQLNumber(dr("SalAccuCheck").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "SalAccuSign = " & SQLString(dr("SalAccuSign").ToString) & COMMA 'varchar[1], NULL'(tdbg1(i, COL1_SalAccuSign)) 
            sSQL &= "SalAccumulator = " & SQLString(dr("SalAccumulator")) & COMMA 'varchar[20], NULL'(tdbg1(i, COL1_SalAccumulator))
            sSQL &= "InsAccuCheck = " & SQLNumber(dr("InsAccuCheck").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "InsAccuSign = " & SQLString(dr("InsAccuSign").ToString) & COMMA 'varchar[1], NULL
            sSQL &= "InsAccumulator = " & SQLString(dr("InsAccumulator").ToString) & COMMA 'varchar[20], NULL
            sSQL &= "Disabled = " & SQLNumber(Not CBool(dr("Enabled"))) & COMMA 'tinyint, NOT NULL

            sSQL &= "IsSub = " & SQLNumber(dr("IsSub").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "ShortName = " & SQLStringUnicode(dr("ShortName" & sUnicode).ToString, gbUnicode, False) & COMMA 'varchar[20], NULL
            sSQL &= "ShortNameU = " & SQLStringUnicode(dr("ShortName" & sUnicode).ToString, gbUnicode, True) & COMMA 'varchar[20], NULL
            sSQL &= "SalSystemID  = " & SQLString(dr("SalSystemID")) & COMMA 'varchar (20), NULL
            sSQL &= "IsMainAccu = " & SQLNumber(dr("IsMainAccu").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "InsurRate = " & SQLMoney(dr("InSurRate").ToString) & COMMA 'money, NOT NULL
            '            sSQL &= "FormularDesc = " & SQLStringUnicode(dr("FormularDesc" & sUnicode).ToString, gbUnicode, False) & COMMA
            '            sSQL &= "FormularDescU = " & SQLStringUnicode(dr("FormularDesc" & sUnicode).ToString, gbUnicode, True) & COMMA
            sSQL &= "FormularDesc = " & SQLString(dr("FormularDesc")) & COMMA
            sSQL &= "FormularDescU = N" & SQLString(dr("FormularDescU")) & COMMA
            sSQL &= "IsNotPrint = " & SQLNumber(dr("IsNotPrint")) & COMMA 'tinyint, NOT NULL
            sSQL &= "IsBackPay = " & SQLNumber(dr("IsBackPay")) & COMMA 'tinyint, NOT NULL' update 1/10/2013 id 59622
            sSQL &= "ProcessOrderNum = " & SQLNumber(dr("ProcessOrderNum")) & COMMA  ', NOT NULL

            sSQL &= "IsDistributeProject = " & SQLNumber(dr("IsDistributeProject")) & COMMA 'tinyint, NOT NULL
            sSQL &= "HandAttendanceID = " & SQLString(dr("HandAttendanceID")) & COMMA 'varchar[50], NOT NULL

            sSQL &= "IsLemonWeb = " & SQLNumber(dr("IsLemonWeb")) 'tinyint, NOT NULL
            sSQL &= "  Where "
            sSQL &= "SalCalMethodID = " & SQLString(txtSalCalMethodID.Text) & " And "
            sSQL &= "CalNo = " & SQLString(dr("CalNo").ToString) & vbCrLf
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:20:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2500() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T2500("
        sSQL &= "SalCalMethodID, Description, DescriptionU, Disabled, CreateUserID, LastModifyUserID, "
        sSQL &= "CreateDate, LastModifyDate, DivisionID, IsLemonWeb"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtSalCalMethodID.Text) & COMMA 'SalCalMethodID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, False) & COMMA 'Description, varchar[150], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, True) & COMMA 'Description, varchar[150], NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID).ToString) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsLemonWeb.Checked) 'Disabled, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:19:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2500 "
        sSQL &= SQLString(txtSalCalMethodID.Text) 'SalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 11:30:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2500() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T2500 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsLemonWeb = " & SQLNumber(chkIsLemonWeb.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID).ToString) 'DivisionID, varchar[20], NOT NULL
        sSQL &= " Where "
        sSQL &= "SalCalMethodID = " & SQLString(txtSalCalMethodID.Text)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 05/09/2012 05:12:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra danh muc PPTL  da duoc su dung trong cac nghiep vu chua?" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2050") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalCalMethodID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

    Private Sub SetBackColorObligatory()
        txtSalCalMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalAccuSign.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalAccumulator.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Function IsExistKey() As Boolean
        Dim sSQL As String = ""
        sSQL = "Select SalCalMethodID From D13T2500  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(txtSalCalMethodID.Text)
        Dim sRet As String = ReturnScalar(sSQL)
        If sRet <> "" Then
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        If txtSalCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma_so"))
            txtSalCalMethodID.Focus()
            Return False
        End If
        If txtSalCalMethodID.Text <> "" Then
            If txtSalCalMethodID.Text.Trim.Length > 20 Then
                D99C0008.MsgL3(rL3("Do_dai_Ma_so_khong_duoc_vuot_qua_20_ky_tu"))
                txtSalCalMethodID.Focus()
                Return False
            End If
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey() = False Then
                D99C0008.MsgDuplicatePKey()
                txtSalCalMethodID.Focus()
                Return False
            End If
        End If
        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If

        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg1.RowCount - 1
            ' update 5/6/2013 id 56508
            If L3Bool(tdbg1(i, COL1_Enabled)) AndAlso (tdbg1(i, COL1_ProcessOrderNum).ToString = "" OrElse L3Int(tdbg1(i, COL1_ProcessOrderNum)) = 0) Then
                D99C0008.MsgNotYetEnter(rL3("TT_xu_ly"))
                tdbg1.Focus()
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL1_ProcessOrderNum
                tdbg1.Row = i
                Return False
            End If
            If tdbg1(i, COL1_Caption).ToString = "" Then 'And tdbg1.Columns(COL1_Enabled).Text = "1" 
                D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL1_Caption
                tdbg1.Row = i
                tdbg1.Focus()
                Return False
            End If
            If tdbg1(i, COL1_ShortName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ten_tat"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL1_ShortName
                tdbg1.Row = i
                tdbg1.Focus()
                Return False
            End If
        Next
        ' update 5/6/2013 id 56508
        For i As Integer = 0 To tdbg1.RowCount - 2
            For j As Integer = i + 1 To tdbg1.RowCount - 1
                If L3Bool(tdbg1(i, COL1_Enabled)) AndAlso L3Bool(tdbg1(j, COL1_Enabled)) AndAlso tdbg1(i, COL1_ProcessOrderNum).ToString = tdbg1(j, COL1_ProcessOrderNum).ToString Then
                    'D99C0008.MsgDuplicatePKey() ' Mã này đã tồn tại.
                    D99C0008.MsgL3(rL3("Khoan_thu_nhap") & Space(1) & tdbg1(i, COL1_Orders).ToString & ", " & tdbg1(j, COL1_Orders).ToString & Space(1) & rL3("trung_thu_tu_xu_ly") & ". " & rL3("Ban_khong_duoc_phep_luu"))
                    tdbg1.Focus()
                    tdbg1.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    tdbg1.Col = COL1_ProcessOrderNum 'Tùy theo yêu cầu mỗi Form
                    tdbg1.Row = i 'Tùy theo yêu cầu mỗi Form
                    Return False
                End If
            Next
        Next
        If tdbg1.Columns(COL1_Caption).Text <> "" Then
            If tdbg1.Columns(COL1_Caption).Text.Trim.Length > 50 Then
                D99C0008.MsgL3(rL3("Do_dai_Dien_giai_khong_duoc_vuot_qua_50_ky_tu"))
                tdbg1.Col = COL1_Caption
                tdbg1.Focus()
                Return False
            End If
        End If
        If tdbg1.Columns(COL1_ShortName).Text <> "" Then
            If tdbg1.Columns(COL1_ShortName).Text.Trim.Length > 50 Then
                D99C0008.MsgL3(rL3("Do_dai_Ten_tat_khong_duoc_vuot_qua") & " 50 " & rL3("ky_tu_U")) 'Độ dài Tên tắt không được vượt quá 20 ký tự.
                tdbg1.Col = COL1_Caption
                tdbg1.Focus()
                Return False
            End If
        End If
        If optCalculationType3.Checked Then
            If txtIssurRate.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ty_le_(BHXH_BHYT)"))
                txtIssurRate.Focus()
                Return False
            Else
                If Convert.ToDouble(txtIssurRate.Text) > 100 Then
                    D99C0008.MsgL3(rL3("Ty_le_(BHXH_BHYT)_khong_duoc_vuot_qua_100%"))
                    txtIssurRate.Focus()
                    Return False
                End If
            End If
        End If
        If txtFormular.Text.Trim <> "" Then
            If txtFormular.Text.Trim.Length > 2000 Then
                D99C0008.MsgL3(rL3("Do_dai_Cong_thuc_khong_duoc_vuot_qua_2000_ky_tu"))
                txtFormular.Focus()
                Return False
            End If
        End If
        If chkSalAccuCheck.Checked Then
            If tdbcSalAccuSign.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Luy_ke_vao_HSL"))
                tdbcSalAccuSign.Focus()
                Return False
            End If
            If tdbcSalAccumulator.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Luy_ke_vao_HSL"))
                tdbcSalAccumulator.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        tdbg1.UpdateData()
        dtMain.AcceptChanges()
        If Not AllowSave() Then Exit Function
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD13T2500()
                sSQL &= SQLStoreD13P2500()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD13T2500()
        End Select
        If _FormState = EnumFormState.FormEdit Then
            If Not L3Bool(tdbg.Columns(COL_IsUsed).Text) Then sSQL &= SQLUpdateD13T2501()
        Else
            sSQL &= SQLUpdateD13T2501()
        End If


        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = False
        If sSQL <> "" Then
            bRunSQL = ExecuteSQL(sSQL)
        Else
            bRunSQL = True
        End If
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True

            'If CheckAudit("SalCalMethodDe") Then
            '    sSQL = SQLStoreD91P9106("SalCalMethodDe", "13", "02", tdbg.Columns(COL_SalCalMethodID).Text, tdbg.Columns(COL_Description).Text, "", "", "")
            '    ExecuteSQLNoTransaction(sSQL)
            'End If

            Lemon3.D91.RunAuditLog("13", "SalCalMethodDe", "02", tdbg.Columns(COL_SalCalMethodID).Text, tdbg.Columns(COL_Description).Text, "", "", "")

            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtSalCalMethodID.Text)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, txtSalCalMethodID.Text)

            End Select
            ReadOnlyControl(txtSalCalMethodID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu

        If AskSave() = Windows.Forms.DialogResult.No Then
            ' SetReturnFormView()
            Exit Sub
        End If
        sOrders = tdbg1.Columns(COL1_Orders).Text
        SaveData(sender)
    End Sub

    Private Sub chkListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkListAll.Click
        bChangedCheckListAll = True
        ReLoadTDBGrid1()
        ShowDetailGrid()
    End Sub

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        tdbg1.Columns(COL1_IsUpdate).Value = True
        tdbg1.UpdateData()
        Select Case e.ColIndex
            Case COL1_Enabled
                If Convert.ToBoolean(tdbg1.Columns(COL1_Enabled).Text) = True Then
                    EnabledControl(True)
                Else
                    EnabledControl(False)
                End If
            Case COL1_SalSystemID
                If tdbg1.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL1_IsDistributeProject
                If Not L3Bool(tdbg1.Columns(e.ColIndex).Text) Then
                    tdbg1.Columns(COL1_HandAttendanceID).Text = ""
                End If
        End Select

    End Sub

    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        tdbg1.UpdateData()
    End Sub

    Private Sub tdbg1_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg1.FetchCellStyle
        Select Case e.Col
            Case COL1_HandAttendanceID
                If Not L3Bool(tdbg1(e.Row, COL1_IsDistributeProject)) Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub


    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        If tdbg1.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex
            Case COL1_IsNotPrint, COL1_IsBackPay
                Dim bVal As Boolean = False
                bVal = Not Convert.ToBoolean(tdbg1(0, e.ColIndex))
                For i As Integer = 0 To tdbg1.RowCount - 1
                    tdbg1(i, e.ColIndex) = bVal
                    tdbg1(i, COL1_IsUpdate) = True
                Next
        End Select
    End Sub

    Private Sub EnabledControl(ByVal bFlag As Boolean)
        optCalculationType0.Enabled = bFlag
        optCalculationType1.Enabled = bFlag
        optCalculationType2.Enabled = bFlag
        optCalculationType3.Enabled = bFlag
        txtFormular.Enabled = bFlag
        txtFormularDesc.Enabled = bFlag
        chkIsSub.Enabled = bFlag
        tdbcDecimal.Enabled = bFlag
        'tdbg2.Enabled = bFlag
        chkSalAccuCheck.Enabled = bFlag
        optIsMainAccu0.Enabled = bFlag
        optIsMainAccu1.Enabled = bFlag
        btnFormula.Enabled = bFlag
    End Sub

    Private Sub InitControl()
        optCalculationType0.Checked = True
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        chkListAll.Checked = False
        chkSalAccuCheck.Checked = False
        If tdbg1.RowCount < 1 Then
            tdbcDecimal.Text = "0"
        End If
        If chkSalAccuCheck.Checked = False Then
            tdbcSalAccuSign.Enabled = False
            tdbcSalAccumulator.Enabled = False
        End If
        optIsMainAccu0.Checked = True
    End Sub

    Private Sub txtIssurRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIssurRate.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        Select Case e.ColIndex
            Case COL1_Orders
                If Not IsNumeric(tdbg1.Columns(COL1_Orders).Text) Then e.Cancel = True
            Case COL1_CalculationType
                If Not IsNumeric(tdbg1.Columns(COL1_CalculationType).Text) Then e.Cancel = True
            Case COL1_Decimals
                If Not IsNumeric(tdbg1.Columns(COL1_Decimals).Text) Then e.Cancel = True
            Case COL1_InSurRate
                If Not IsNumeric(tdbg1.Columns(COL1_InSurRate).Text) Then e.Cancel = True
            Case COL1_HandAttendanceID
                If tdbg1.Columns(e.ColIndex).Text <> tdbg1.Columns(e.ColIndex).DropDown.Columns(tdbg1.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                End If
            Case COL1_SalSystemID
                If tdbg1.Columns(e.ColIndex).Text <> tdbg1.Columns(e.ColIndex).DropDown.Columns(tdbg1.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                Else
                    Dim SalSystemID As String
                    SalSystemID = tdbdSalSystemID.Columns("SalSystemID").Text
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If tdbg1.Row <> i AndAlso SalSystemID = tdbg1(i, COL1_SalSystemID).ToString() Then
                            e.Cancel = True
                            D99C0008.MsgDuplicatePKey()
                            tdbg1.Focus()
                            tdbg1.Col = COL1_SalSystemID
                            Exit For
                        End If
                    Next
                End If
        End Select
    End Sub

    Private Sub PushGridDataToTable()
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        dt.AcceptChanges()
    End Sub

    Private Sub txtFormularDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormularDesc.TextChanged
        If tdbg1.RowCount = 0 Then Exit Sub
        'Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        If gbUnicode Then
            dtMain.DefaultView(tdbg1.Row).Item("FormularDesc") = ConvertUnicodeToVni(txtFormularDesc.Text)
            dtMain.DefaultView(tdbg1.Row).Item("FormularDescU") = txtFormularDesc.Text
        Else 'VNI
            dtMain.DefaultView(tdbg1.Row).Item("FormularDesc") = txtFormularDesc.Text
            dtMain.DefaultView(tdbg1.Row).Item("FormularDescU") = ConvertVniToUnicode(txtFormularDesc.Text)
        End If

        'dtMain.AcceptChanges() : Không dùng chỗ này được sẽ bị giật lưới. -> Chuyển qua luu AcceptChanges


        ' Chú ý: Nếu sau này lưới có Filter thì đoạn này chạy không đúng.
        'If gbUnicode Then
        '    dtMain.Rows(tdbg1.Row).Item("FormularDesc") = ConvertUnicodeToVni(txtFormularDesc.Text)
        '    dtMain.Rows(tdbg1.Row).Item("FormularDescU") = txtFormularDesc.Text
        'Else 'VNI
        '    dtMain.Rows(tdbg1.Row).Item("FormularDesc") = txtFormularDesc.Text
        '    dtMain.Rows(tdbg1.Row).Item("FormularDescU") = ConvertVniToUnicode(txtFormularDesc.Text)
        'End If
    End Sub


    Private Sub chkIsSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsSub.Click
        If tdbg1.RowCount >= 1 Then
            If chkIsSub.Checked = True Then
                tdbg1(tdbg1.Row, COL1_IsSub) = 1
            Else
                tdbg1(tdbg1.Row, COL1_IsSub) = 0
            End If
        End If
    End Sub

    Private Sub tdbcSalAccuSign_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccuSign.SelectedValueChanged
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_SalAccuSign) = tdbcSalAccuSign.Text
        End If
    End Sub

    'Combo Nhập Tên
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccumulator.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    'Combo Nhập Tên
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccumulator.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_SalAccumulator) = ReturnValueC1Combo(tdbcSalAccumulator, "Code") 'tdbcSalAccumulator.Text
        End If

    End Sub

    Private Sub txtIssurRate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssurRate.Validated
        txtIssurRate.Text = (SQLNumber(txtIssurRate.Text, DxxFormat.DefaultNumber2)).ToString
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_InSurRate) = txtIssurRate.Text
        End If
    End Sub

    Private Sub optIsMainAccu0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optIsMainAccu0.Click
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_IsMainAccu) = 0
        End If
    End Sub

    Private Sub optIsMainAccu1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optIsMainAccu1.Click
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_IsMainAccu) = 1
        End If
    End Sub

    Private Sub btnFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormula.Click
        Dim frm As New D13F2054
        frm.FormID = "D13F2054"
        frm.ShowDialog()
        Dim sFormula As String = frm.ReturnFormular
        frm.Dispose()
        Dim iCurrentPos As Integer = txtFormular.SelectionStart
        Dim sFormular As String = txtFormular.Text
        Dim sTextBefore As String = sFormular.Substring(0, iCurrentPos)
        Dim sTextAfter As String = sFormular.Substring(iCurrentPos, sFormular.Length - iCurrentPos)
        txtFormular.Text = sTextBefore & sFormula & sTextAfter

    End Sub

    Private Sub txtFormular_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormular.GotFocus
        txtFormular.SelectionLength = 0
        txtFormular.SelectionStart = txtFormular.Text.Length
    End Sub
    Private Sub txtFormularDesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormularDesc.GotFocus
        txtFormularDesc.SelectionLength = 0
        txtFormularDesc.SelectionStart = txtFormularDesc.Text.Length
    End Sub

    Private Sub txtFormular_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormular.TextChanged
        If tdbg1.RowCount = 0 Then Exit Sub
        ''Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        ''dt.DefaultView(tdbg1.Row).Item("Formular") = txtFormular.Text
        tdbg1(tdbg1.Row, COL1_Formular) = txtFormular.Text
    End Sub

    ' update 5/6/2013 id 56508
    Private Sub chkIsSortProcessOrderNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsSortProcessOrderNum.CheckedChanged
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        Dim dt1 As DataTable = dtMain.Copy
        If chkIsSortProcessOrderNum.Checked Then
            dt1.DefaultView.Sort = "Orders ASC"
        Else
            dt1.DefaultView.Sort = "ProcessOrderNum ASC"
        End If
        dtMain = dt1.DefaultView.ToTable
        LoadDataSource(tdbg1, dtMain, gbUnicode)
        ReLoadTDBGrid1()
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            Case COL1_Enabled, COL1_IsNotPrint, COL1_IsBackPay, COL1_IsLemonWeb
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL1_ProcessOrderNum
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount < 1 Then Exit Sub
        If tdbg.Columns(COL_SalCalMethodID).Tag Is Nothing OrElse tdbg.Columns(COL_SalCalMethodID).Text <> tdbg.Columns(COL_SalCalMethodID).Tag.ToString Then
            LoadEdit()
            sOrders = ""
        End If
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnabledMenu(True)
        LoadAdd()
    End Sub

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        'Master
        txtSalCalMethodID.Text = ""
        txtDescription.Text = ""
        tdbcDivisionID.SelectedValue = ""
        chkIsLemonWeb.Checked = False
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        UnReadOnlyControl(True, txtSalCalMethodID)
        txtSalCalMethodID.Focus()
        tdbg.Columns(COL_SalCalMethodID).Tag = ""
        tdbg1.AllowUpdate = True
        grp2.Enabled = True
        LoadGridDataTable()
        LoadTDBGridDetail(True)
        'Chi tiết bên phải
        ClearText(grp2)
        optCalculationType0.Checked = True
        optIsMainAccu1.Checked = True
        tdbcDecimal.Text = "0"
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtSalCalMethodID.Text = "" Then
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
    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnabledMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grp2)
        Else
            LoadEdit()
            tdbg.Focus()
            If sOrders <> "" Then
                Dim dt1 As DataTable = dtMain.DefaultView.ToTable
                Dim dr() As DataRow = dt1.Select("Orders = " & SQLString(sOrders), dt1.DefaultView.Sort)
                If dr.Length > 0 Then tdbg1.Row = dt1.Rows.IndexOf(dr(0))
            End If
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub tdbcDecimal_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDecimal.SelectedValueChanged
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL1_Decimals) = tdbcDecimal.Text
        End If
    End Sub

    Private Sub mnsBackPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBackPay.Click, mnsBackPay.Click
        Dim f As New D13F2055
        f.SalaryMethodID = tdbg.Columns(COL_SalCalMethodID).Text
        f.SalaryMethodName = tdbg.Columns(COL_Description).Text
        f.ShowDialog()
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_SalCalMethodID).Text)
        End If
        f.Dispose()
    End Sub

    Private Sub btnCCCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SplitContainer1.SplitterDistance <> 0 Then
            SplitContainer1.SplitterDistance = 0
        Else
            SplitContainer1.SplitterDistance = iHeightSpitCon
        End If
    End Sub

    Dim Tooltip As New ToolTip
    Private Sub btnCollasp_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.MouseHover
        Tooltip.SetToolTip(btnCollapse, IIf(L3Bool(btnCollapse.Tag), "Collapse", "Expand").ToString)
    End Sub

    Private Sub btnCollasp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.Click
        If SplitContainer1.SplitterDistance <> 0 Then
            btnCollapse.Image = imgDownUp.Images(0)
            iHeightSpitCon = SplitContainer1.SplitterDistance
            SplitContainer1.SplitterDistance = 0
        Else
            btnCollapse.Image = imgDownUp.Images(1)
            SplitContainer1.SplitterDistance = iHeightSpitCon
        End If
        btnCollapse.Tag = Not L3Bool(btnCollapse.Tag) '0: Collapse, 1: Expand
    End Sub

#Region "Viết lại sự kiện UseEnterAsTab"

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
#End Region

    Private Sub txtFormular_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFormular.Resize
        Dim iTopBegin, iTopEnd, iHeight As Integer
        iTopBegin = btnFormula.Top + btnFormula.Height + 4
        iTopEnd = pnlD.Top - 4
        iHeight = iTopEnd - iTopBegin - 20
        If iHeight > 0 Then
            txtFormular.Height = L3Int(iHeight / 2)
            lblFormularDesc.Top = txtFormular.Top + txtFormular.Height + 4
            GroupBox1.Top = lblFormularDesc.Top + 4
            txtFormularDesc.Top = lblFormularDesc.Top + 20
            txtFormularDesc.Height = txtFormular.Height
        Else
        End If
    End Sub

End Class
