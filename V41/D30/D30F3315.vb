Imports System
Public Class D30F3315
    'Bổ sung Lock các cột Model, SL, SL bổ sung, ngày bat đầu, ngày kết thúc, ngay giao hàng 03/07/2009
    'Bổ sung cột ComponentID, ComponentName 12/01/2010

    Dim bSelected1_IsPR As Boolean = False, bSelected1_IsProOrder As Boolean = False
    Dim bSelected1_IsFirm As Boolean = False 'Modify 20/02/2009'Mở ra cho HeadClick cột Xác nhận 20/05/2010 Khoa y/c
    Dim bSelected2 As Boolean = False, bSelected3 As Boolean = False
    Dim dt_LoadTDBGrid1, dt_LoadTDBGrid2, dt_LoadTDBGrid3, dtUnitID, dtSpecID As DataTable
    Dim bFlagSave As Boolean = False
    Dim bPR As Boolean = False 'YCMH
    Dim bWO As Boolean = False 'LSX

    Dim bEnabledUseFind1 As Boolean = False, bEnabledUseFind2 As Boolean = False
    Dim iperD30F3315 As Integer = 0
    Dim iPerD30F2413 As Integer = 0
    Dim sOldVoucherNoPR As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNoPR As Boolean = False '= True: có nhấn F2; = False: không 
    Dim bFirstF2PR As Boolean = False 'Nhấn F2 lần đầu tiên 
    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không
    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên
    Dim iPer_F5558 As Integer = ReturnPermission("D30F5558") 'Phân quyền cho Sửa số phiếu

#Region "Const of tdbg1"
    Private Const COL1_MRPDetailID As Integer = 0       ' MRPDetailID
    Private Const COL1_DetailItemID As Integer = 1      ' DetailItemID
    Private Const COL1_InventoryID As Integer = 2       ' Mã hàng
    Private Const COL1_InventoryName As Integer = 3     ' Tên hàng
    Private Const COL1_Spec01ID As Integer = 4          ' Quy cách 
    Private Const COL1_Spec02ID As Integer = 5          ' Quy cách 
    Private Const COL1_Spec03ID As Integer = 6          ' Quy cách 
    Private Const COL1_Spec04ID As Integer = 7          ' Quy cách 
    Private Const COL1_Spec05ID As Integer = 8          ' Quy cách 
    Private Const COL1_Spec06ID As Integer = 9          ' Quy cách 
    Private Const COL1_Spec07ID As Integer = 10         ' Quy cách 
    Private Const COL1_Spec08ID As Integer = 11         ' Quy cách 
    Private Const COL1_Spec09ID As Integer = 12         ' Quy cách 
    Private Const COL1_Spec10ID As Integer = 13         ' Quy cách 
    Private Const COL1_ICode01ID As Integer = 14        ' ICode01
    Private Const COL1_ICode02ID As Integer = 15        ' ICode02
    Private Const COL1_ICode03ID As Integer = 16        ' ICode03
    Private Const COL1_ICode04ID As Integer = 17        ' ICode04
    Private Const COL1_ICode05ID As Integer = 18        ' ICode05
    Private Const COL1_ICode06ID As Integer = 19        ' ICode06
    Private Const COL1_ICode07ID As Integer = 20        ' ICode07
    Private Const COL1_ICode08ID As Integer = 21        ' ICode08
    Private Const COL1_ICode09ID As Integer = 22        ' ICode09
    Private Const COL1_ICode10ID As Integer = 23        ' ICode10
    Private Const COL1_UnitID As Integer = 24           ' ĐVT
    Private Const COL1_UseFormula As Integer = 25       ' UseFormula
    Private Const COL1_Formula As Integer = 26          ' Formula
    Private Const COL1_ConversionFactor As Integer = 27 ' ConversionFactor
    Private Const COL1_Model As Integer = 28            ' Model
    Private Const COL1_ModelDesc As Integer = 29        ' Diễn giải Model
    Private Const COL1_Quantity As Integer = 30         ' Số lượng
    Private Const COL1_CQuantity As Integer = 31        ' Số lượng QĐ
    Private Const COL1_ExQuantity As Integer = 32       ' SL bổ sung
    Private Const COL1_StartDate As Integer = 33        ' Ngày bắt đầu
    Private Const COL1_EndDate As Integer = 34          ' Ngày kết thúc
    Private Const COL1_ReqDate As Integer = 35          ' Ngày giao hàng
    Private Const COL1_ExcuteDateNum As Integer = 36    ' Số ngày thực hiện
    Private Const COL1_IsFirm As Integer = 37           ' Xác nhận
    Private Const COL1_IsProcessed As Integer = 38      ' Đã xử lý
    Private Const COL1_IsPR As Integer = 39             ' Lập YCMH
    Private Const COL1_IsProOrder As Integer = 40       ' Lập LSX
    Private Const COL1_DetailDesc As Integer = 41       ' Diễn giải chi tiết
    Private Const COL1_DStr01 As Integer = 42           ' DStr01
    Private Const COL1_DStr02 As Integer = 43           ' DStr02
    Private Const COL1_DStr03 As Integer = 44           ' DStr03
    Private Const COL1_DStr04 As Integer = 45           ' DStr04
    Private Const COL1_DStr05 As Integer = 46           ' DStr05
    Private Const COL1_DStr06 As Integer = 47           ' DStr06
    Private Const COL1_DStr07 As Integer = 48           ' DStr07
    Private Const COL1_DStr08 As Integer = 49           ' DStr08
    Private Const COL1_DStr09 As Integer = 50           ' DStr09
    Private Const COL1_DStr10 As Integer = 51           ' DStr10
    Private Const COL1_DNum01 As Integer = 52           ' DNum01
    Private Const COL1_DNum02 As Integer = 53           ' DNum02
    Private Const COL1_DNum03 As Integer = 54           ' DNum03
    Private Const COL1_DNum04 As Integer = 55           ' DNum04
    Private Const COL1_DNum05 As Integer = 56           ' DNum05
    Private Const COL1_DNum06 As Integer = 57           ' DNum06
    Private Const COL1_DNum07 As Integer = 58           ' DNum07
    Private Const COL1_DNum08 As Integer = 59           ' DNum08
    Private Const COL1_DNum09 As Integer = 60           ' DNum09
    Private Const COL1_DNum10 As Integer = 61           ' DNum10
    Private Const COL1_DDat01 As Integer = 62           ' DDat01
    Private Const COL1_DDat02 As Integer = 63           ' DDat02
    Private Const COL1_DDat03 As Integer = 64           ' DDat03
    Private Const COL1_DDat04 As Integer = 65           ' DDat04
    Private Const COL1_DDat05 As Integer = 66           ' DDat05
    Private Const COL1_DDat06 As Integer = 67           ' DDat06
    Private Const COL1_DDat07 As Integer = 68           ' DDat07
    Private Const COL1_DDat08 As Integer = 69           ' DDat08
    Private Const COL1_DDat09 As Integer = 70           ' DDat09
    Private Const COL1_DDat10 As Integer = 71           ' DDat10
    Private Const COL1_MDSVoucherNo As Integer = 72     ' Kế hoạch nhu cầu
    Private Const COL1_SalesOrderNo As Integer = 73     ' Đơn hàng bán
    Private Const COL1_SalesVoucherNo As Integer = 74   ' Đơn hàng (Số CT)
    Private Const COL1_CustomerID As Integer = 75       ' Mã khách hàng
    Private Const COL1_MultiMode As Integer = 76        ' MultiMode
    Private Const COL1_Locked As Integer = 77           ' Locked
    Private Const COL1_SDType As Integer = 78           ' SDType
    Private Const COL1_CustomerName As Integer = 79     ' Tên khách hàng
    Private Const COL1_ProductID As Integer = 80        ' Mã sản phẩm
    Private Const COL1_ProductName As Integer = 81      ' Tên sản phẩm
    Private Const COL1_ProductQuantity As Integer = 82  ' SL sản phẩm
    Private Const COL1_IsBOM As Integer = 83            ' IsBOM
    Private Const COL1_IsRouting As Integer = 84        ' IsRouting
    Private Const COL1_ComponentID As Integer = 85      ' Mã thành phần
    Private Const COL1_ComponentName As Integer = 86    ' Tên thành phần
    Private Const COL1_IsConsolidate As Integer = 87    ' IsConsolidate
    Private Const COL1_OQuantity As Integer = 88        ' OQuantity
#End Region

#Region "Const of tdbg2"
    Private Const COL2_SDTypeName As Integer = 0    ' Loại nghiệp vụ
    Private Const COL2_VoucherNo As Integer = 1     ' Số phiếu
    Private Const COL2_JobNo As Integer = 2         ' Số công việc
    Private Const COL2_MRPDetailID As Integer = 3   ' MRPDetailID
    Private Const COL2_DetailItemID As Integer = 4  ' DetailItemID
    Private Const COL2_InventoryID As Integer = 5   ' Mã hàng
    Private Const COL2_InventoryName As Integer = 6 ' Tên hàng
    Private Const COL2_Spec01ID As Integer = 7      ' Quy cách 
    Private Const COL2_Spec02ID As Integer = 8      ' Quy cách 
    Private Const COL2_Spec03ID As Integer = 9      ' Quy cách 
    Private Const COL2_Spec04ID As Integer = 10     ' Quy cách 
    Private Const COL2_Spec05ID As Integer = 11     ' Quy cách 
    Private Const COL2_Spec06ID As Integer = 12     ' Quy cách 
    Private Const COL2_Spec07ID As Integer = 13     ' Quy cách 
    Private Const COL2_Spec08ID As Integer = 14     ' Quy cách 
    Private Const COL2_Spec09ID As Integer = 15     ' Quy cách 
    Private Const COL2_Spec10ID As Integer = 16     ' Quy cách 
    Private Const COL2_Quantity As Integer = 17     ' Số lượng
    Private Const COL2_OriginalDate As Integer = 18 ' Ngày GH cũ
    Private Const COL2_ReqDate As Integer = 19      ' Ngày giao hàng
    Private Const COL2_IsFirm As Integer = 20       ' Xác nhận
    Private Const COL2_IsProccessed As Integer = 21 ' Đã xử lý
    Private Const COL2_SDType As Integer = 22       ' SDType
    Private Const COL2_IsBOM As Integer = 23        ' IsBOM
#End Region

#Region "Const of tdbg3"
    Private Const COL3_SDTypeName As Integer = 0    ' Loại nghiệp vụ
    Private Const COL3_VoucherNo As Integer = 1     ' Số phiếu
    Private Const COL3_JobNo As Integer = 2         ' Số công việc
    Private Const COL3_MRPDetailID As Integer = 3   ' MRPDetailID
    Private Const COL3_DetailItemID As Integer = 4  ' DetailItemID
    Private Const COL3_InventoryID As Integer = 5   ' Mã hàng
    Private Const COL3_InventoryName As Integer = 6 ' Tên hàng
    Private Const COL3_Spec01ID As Integer = 7      ' Quy cách 
    Private Const COL3_Spec02ID As Integer = 8      ' Quy cách 
    Private Const COL3_Spec03ID As Integer = 9      ' Quy cách 
    Private Const COL3_Spec04ID As Integer = 10     ' Quy cách 
    Private Const COL3_Spec05ID As Integer = 11     ' Quy cách 
    Private Const COL3_Spec06ID As Integer = 12     ' Quy cách 
    Private Const COL3_Spec07ID As Integer = 13     ' Quy cách 
    Private Const COL3_Spec08ID As Integer = 14     ' Quy cách 
    Private Const COL3_Spec09ID As Integer = 15     ' Quy cách 
    Private Const COL3_Spec10ID As Integer = 16     ' Quy cách 
    Private Const COL3_Quantity As Integer = 17     ' Số lượng
    Private Const COL3_ReqDate As Integer = 18      ' Ngày giao hàng
    Private Const COL3_IsFirm As Integer = 19       ' Xác nhận
    Private Const COL3_IsProccessed As Integer = 20 ' Đã xử lý
    Private Const COL3_SDType As Integer = 21       ' SDType
    Private Const COL3_IsBOM As Integer = 22        ' IsBOM
#End Region

    Private _mRPVoucherID As String = ""
    Public Property MRPVoucherID() As String
        Get
            Return _mRPVoucherID
        End Get
        Set(ByVal Value As String)
            _mRPVoucherID = Value
        End Set
    End Property

    Private _formCall As String = ""
    Public Property FormCall() As String
        Get
            Return _formCall
        End Get
        Set(ByVal Value As String)
            _formCall = Value
        End Set
    End Property

    Private _voucherNo As String = ""
    Public Property VoucherNo() As String
        Get
            Return _voucherNo
        End Get
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _description As String = ""
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private Sub D30F3315_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnAction.Enabled And bFlagSave = False Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub D30F3315_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tab1.SelectedTab = TabPage1
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tab1.SelectedTab = TabPage2
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tab1.SelectedTab = TabPage3
        End If
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnDisplay_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
    End Sub

    Private Sub D30F3315_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iPerD30F2413 = ReturnPermission("D30F2413")
        iperD30F3315 = ReturnPermission(Me.Name)
        gbEnabledUseFind = False
        bEnabledUseFind1 = False
        bEnabledUseFind2 = False
        '*******************************
        SetBackColorObligatory()
        SetShortcutPopupMenu(ContextMenuStrip1)
        ResetSplitDividerSize(tdbg1)
        ResetSplitDividerSize(tdbg2)
        ResetSplitDividerSize(tdbg3)
        ResetColorGrid(tdbg3, 0, 1)
        ResetColorGrid(tdbg2, 0, 1)
        ResetFooterGrid(tdbg1, 0, 1)
        LoadTDBCombo()
        Loadlanguage()
        '*******************************
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        LoadTDBGrid()
        LoadTableUnitID()
        '*******************************
        LoadTDBGridSpecificationCaption(tdbg3, COL3_Spec01ID, SPLIT0, True, gbUnicode, dtSpecID)
        LoadTDBGridSpecificationCaption(tdbg2, COL2_Spec01ID, SPLIT0, True, gbUnicode, dtSpecID)
        LoadTDBGridSpecificationCaption(tdbg1, COL1_Spec01ID, SPLIT0, True, gbUnicode, dtSpecID)
        LoadCaptionInfo(SQLStoreD30P0010(IIf(_formCall = "D30F3300", "D30T2120", "D30T2020").ToString), tdbg1, 1, True)
        LoadCaptionICode()
        '*******************************
        InputDateInTrueDBGrid(tdbg1, COL1_StartDate, COL1_EndDate, COL1_ReqDate)
        InputDateInTrueDBGrid(tdbg2, COL2_ReqDate, COL2_OriginalDate)
        InputDateInTrueDBGrid(tdbg3, COL3_ReqDate)
        '*******************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtPRVoucherNo)
        '*******************************
        LoadDefault()
        CheckOption() '31/08/2009 Kiểm tra phân quyền enable các option lọc dữ liệu
        '*******************************
        CallD09U1111_Button(True)
        '*******************************
        LockColbyPlanOrderLock() '03'07'2009' Đặt cuối vì theo hệ thống Modify 27/01/2010

        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LoadDefault()
        txtVoucherNo.ReadOnly = True
        txtDescription.ReadOnly = True
        txtVoucherNo.Text = _voucherNo
        txtDescription.Text = _description
        '*******************************
        If _formCall = "D30F3300" Then
            grpWO.Visible = False
            tdbg1.Height = tdbg1.Height + grpWO.Height
            tdbg1.Location = New Point(tdbg1.Location.X, grpWO.Location.Y)
            tdbg1.Splits(1).DisplayColumns(COL1_IsProOrder).Visible = False
            chkIsProOrder.Visible = False
        End If
        '*******************************
        Dim sSQL As String = "Select IsExQtyCalc From D30V3200 Where VoucherID=" & SQLString(_mRPVoucherID)
        tdbg1.Splits(1).DisplayColumns(COL1_ExQuantity).Visible = (ReturnScalar(sSQL) = "1")
        txtCosolidateDays.Text = Format(D30Systems.iConsolidateDays, DxxFormat.DefaultNumber0)
        '*******************************
        Dim iperD30F5602 As Integer = 0
        tdbg1.Splits(1).DisplayColumns(COL1_ReqDate).Visible = ShowMPSReqDateCol(iperD30F5602)
        If iperD30F5602 = 1 Then
            tdbg1.Splits(1).DisplayColumns(COL1_ReqDate).Locked = True
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ReqDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Else
            tdbg1.Splits(1).DisplayColumns(COL1_ReqDate).Locked = False
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ReqDate).Style.ResetBackColor()
        End If
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL1_InventoryID, COL1_InventoryName, COL1_UnitID, COL1_Quantity, COL1_CQuantity, COL1_IsFirm, COL1_IsPR, COL1_IsProOrder}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg1.Splits.Count - 1
                AddColVisible(tdbg1, i, Arr, arrColObligatory, False, True, gbUnicode)
            Next
            '*****************************************
            'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
            Dim dtCaptionCols As DataTable
            dtCaptionCols = CreateTableForExcel(tdbg1, Arr)
            usrOption = New D09U1111(tdbg1, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        End If
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg1.Columns(COL1_Quantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg1.Columns(COL1_CQuantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg1.Columns(COL1_ExQuantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg1.Columns(COL1_ProductQuantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg1.Columns(COL1_ExcuteDateNum).NumberFormat = DxxFormat.DefaultNumber0

        tdbg2.Columns(COL2_Quantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg3.Columns(COL3_Quantity).NumberFormat = DxxFormat.D08_QuantityDecimals
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Xu_ly_ket_qua_tinh_ke_hoach_NVL_tong_the_-_D30F3315") & UnicodeCaption(gbUnicode) 'Xõ lü kÕt qu¶ tÛnh kÕ hoÁch NVL tång thÓ - D30F3315
        '================================================================ 
        lblVoucherNo.Text = rl3("So") 'Số:
        lblPRVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPRVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblWOVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblWOVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblPRTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        lblWOTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        lblCosolidateDays.Text = rl3("So_ngay_duoc_phep_gop_giua_cac_ngay_giao_hang") 'Số ngày được phép gộp giữa các ngày giao hàng
        lblPRDescription.Text = rl3("Dien_giai")
        lblWODescription.Text = rl3("Dien_giai")
        '================================================================ 
        chkisSOGroup.Text = rl3("Theo_don_hang") 'Theo đơn hàng
        chkisProductGroup.Text = rl3("Theo_san_pham") 'Theo sản phẩm
        chkisInventoryID.Text = rl3("Theo_ma_hang") 'Theo mã hàng
        chkIsFirm.Text = rl3("Xac_nhan") 'Xác nhận
        chkIsPR.Text = rl3("Lap_YCMH") 'Lập YCMH
        chkIsProOrder.Text = rl3("Lap_lenh") 'Lập lệnh
        chkOnlyInventoryZero.Text = rl3("Khong_hien_thi_mat_hang_co_so_luong_bang_0") 'Không hiển thị mặt hàng có số lượng bằng 0
        '================================================================ 
        btnAction.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnConsoliQty.Text = "&" & rl3("Cong_gop_so_luong") 'Cộng gộp số lượng
        btnOK.Text = rl3("Don_g_y") 'Đồng ý
        btnFirm2.Text = "&" & rl3("Xac_nhan") 'Xác nhận
        btnFirm3.Text = "&" & rl3("Xac_nhan") 'Xác nhận
        btnException.Text = rl3("Ng_oai_le") 'Ng&oại lệ
        btnDisplay.Text = rl3("_Hien_thi") & " (F12)" '&Hiển thị
        '================================================================ 
        grpPR.Text = rl3("Yeu_cau_mua_hang") 'Yêu cầu mua hàng
        grpWO.Text = rl3("Lenh_san_xuat") 'Lệnh sản xuất
        grpConsoliQty.Text = rl3("Cong_gop_so_luong") 'Cộng gộp số lượng
        grpDisplay.Text = rl3("Hien_thi")  'Hiển thị
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Don_hang_du_kien") '1. Đơn hàng dự kiến
        TabPage2.Text = "2. " & rl3("Dieu_chinh_ngay_giao_hang") '2. Điều chỉnh ngày giao hàng
        TabPage3.Text = "3. " & rl3("Huy_don_hang") '3. Hủy đơn hàng
        '================================================================ 
        tdbcPRTransTypeID.Columns("TransTypeID").Caption = rl3("Ma")
        tdbcPRTransTypeID.Columns("TransTypeName").Caption = rl3("Ten")
        tdbcPRVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma")
        tdbcPRVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai")
        tdbcWOTransTypeID.Columns("TranTypeID").Caption = rl3("Ma")
        tdbcWOTransTypeID.Columns("Description").Caption = rl3("Ten")
        tdbcWOVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma")
        tdbcWOVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai")
        '================================================================ 
        tdbdModel.Columns("Model").Caption = rl3("Ma")
        tdbdModel.Columns("Notes").Caption = rl3("Dien_giai")
        tdbdUnitID.Columns("UnitID").Caption = rl3("Ma")
        tdbdUnitID.Columns("UnitName").Caption = rl3("Ten")
        '================================================================ 
        tdbg1.Columns("InventoryID").Caption = rl3("Ma_hang") 'Mã hàng
        tdbg1.Columns("InventoryName").Caption = rl3("Ten_hang") 'Tên hàng
        tdbg1.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbg1.Columns("ModelDesc").Caption = rl3("Dien_giai") & Space(1) & "Model" 'Diễn giải Model
        tdbg1.Columns("Quantity").Caption = rl3("So_luong") 'Số lượng
        tdbg1.Columns("CQuantity").Caption = rl3("So_luong_QD") 'Số lượng QĐ
        tdbg1.Columns("ExQuantity").Caption = rl3("SL_bo_sung") 'SL bổ sung
        tdbg1.Columns("StartDate").Caption = rl3("Ngay_bat_dau") 'Ngày bắt đầu
        tdbg1.Columns("EndDate").Caption = rl3("Ngay_ket_thuc") 'Ngày kết thúc
        tdbg1.Columns("ReqDate").Caption = rl3("Ngay_giao_hang") 'Ngày giao hàng
        tdbg1.Columns("IsFirm").Caption = rl3("Xac_nhan") 'Xác nhận
        tdbg1.Columns("IsPR").Caption = rl3("Lap_YCMH") 'Lập YCMH
        tdbg1.Columns("IsProOrder").Caption = rl3("Lap_LSX") 'Lập LSX
        tdbg1.Columns("IsProcessed").Caption = rl3("Da_xu_ly_") 'Đã xử lý
        tdbg1.Columns("DetailDesc").Caption = rl3("Dien_giai_chi_tiet") 'Diễn giải chi tiết
        tdbg1.Columns("MDSVoucherNo").Caption = rl3("Ke_hoach_nhu_cau") 'Kế hoạch nhu cầu
        tdbg1.Columns("SalesOrderNo").Caption = rl3("Don_hang_ban") 'Đơn hàng bán
        tdbg1.Columns("SalesVoucherNo").Caption = rl3("Don_hang_(So_CT)") ' Đơn hàng (số CT)
        tdbg1.Columns("CustomerID").Caption = rl3("Ma_khach_hang") 'Mã khách hàng
        tdbg1.Columns("CustomerName").Caption = rl3("Ten_khach_hang") 'Tên khách hàng
        tdbg1.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg1.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm 
        tdbg1.Columns(COL1_ProductQuantity).Caption = rl3("SL_san_pham") 'SL sản phẩm 
        tdbg1.Columns(COL1_ComponentID).Caption = rl3("Ma_thanh_phan") 'Mã thành phần
        tdbg1.Columns(COL1_ComponentName).Caption = rl3("Ten_thanh_phan") 'Tên thành phần
        tdbg1.Columns(COL1_ExcuteDateNum).Caption = rl3("So_ngay_thuc_hien")
        '================================================================ 
        tdbg2.Columns("SDTypeName").Caption = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        tdbg2.Columns("VoucherNo").Caption = rl3("So_phieu") 'YCMH / ĐĐH
        tdbg2.Columns("JobNo").Caption = rl3("So_cong_viec") 'Số công việc
        tdbg2.Columns("InventoryID").Caption = rl3("Ma_hang") 'Mã hàng
        tdbg2.Columns("InventoryName").Caption = rl3("Ten_hang") 'Tên hàng
        tdbg2.Columns("Quantity").Caption = rl3("So_luong") 'Số lượng
        tdbg2.Columns("OriginalDate").Caption = rl3("Ngay_GH_cu") 'Ngày GH cũ
        tdbg2.Columns("ReqDate").Caption = rl3("Ngay_GH_moi") 'Ngày GH mới
        tdbg2.Columns("IsFirm").Caption = rl3("Xac_nhan") 'Xác nhận
        tdbg2.Columns("IsProccessed").Caption = rl3("Da_xu_ly_") 'Đã xử lý
        '================================================================ 
        tdbg3.Columns("SDTypeName").Caption = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        tdbg3.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg3.Columns("JobNo").Caption = rl3("So_cong_viec") 'Số công việc
        tdbg3.Columns("InventoryID").Caption = rl3("Ma_hang") 'Mã hàng
        tdbg3.Columns("InventoryName").Caption = rl3("Ten_hang") 'Tên hàng
        tdbg3.Columns("Quantity").Caption = rl3("So_luong") 'Số lượng
        tdbg3.Columns("ReqDate").Caption = rl3("Ngay_giao_hang") 'Ngày giao hàng
        tdbg3.Columns("IsFirm").Caption = rl3("Huy") 'Hủy
        tdbg3.Columns("IsProccessed").Caption = rl3("Da_xu_ly_") 'Đã xử lý
        '================================================================ 
        mnsDetachQuantity.Text = rl3("_Tach_so_luong") '&Tách số lượng
        mnsSalesOrderDetail.Text = "&" & rl3("Chi_tiet_don_hang") '"Chi tiết đơn hàng"
        mnsReplaceMaterial.Text = rl3("Thay_the_NVL") 'Thay thế NVL
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPRVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtWOVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcWOVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtPRVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPRTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcWOTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Spec10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        For i As Integer = COL1_ICode01ID To COL1_ICode10ID
            tdbg1.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Next
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_CQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ModelDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_SalesOrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_SalesVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_CustomerID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_CustomerName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ProductQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_MDSVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ComponentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ComponentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ExcuteDateNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_VoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_OriginalDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MRPDetailID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_DetailItemID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Spec10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Quantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcPRTransTypeID
        sSQL = "Select TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, VoucherTypeID" & vbCrLf
        sSQL &= "From D12T1010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 And TransactionID=0 And (DAGroupID='' Or DAGroupID In (Select DAGroupID From LemonSys.Dbo.D00V0080 Where UserID=" & SQLString(gsUserID) & ") Or 'LEMONADMIN'=" & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "ORDER BY TransTypeID"
        LoadDataSource(tdbcPRTransTypeID, sSQL, gbUnicode)

        'Load tdbcWOTransTypeID
        sSQL = "Select TranTypeID, Description" & UnicodeJoin(gbUnicode) & " as Description, VoucherTypeID" & vbCrLf
        sSQL &= "From D31T1021 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 And TransType='PO' And (DAGroupID='' Or DAGroupID In (Select DAGroupID From LemonSys.Dbo.D00V0080 Where UserID=" & SQLString(gsUserID) & ") Or 'LEMONADMIN'=" & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "ORDER BY TranTypeID"
        LoadDataSource(tdbcWOTransTypeID, sSQL, gbUnicode)

        LoadVoucherTypeID(tdbcPRVoucherTypeID, tdbcWOVoucherTypeID, D30, "", gbUnicode)
    End Sub

#Region "Events tdbcPRVoucherTypeID with txtlblPRVoucherNo"

    Private Sub tdbcPRVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPRVoucherTypeID.Close
        If tdbcPRVoucherTypeID.FindStringExact(tdbcPRVoucherTypeID.Text) = -1 Then
            tdbcPRVoucherTypeID.Text = ""
            txtPRVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcPRVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPRVoucherTypeID.SelectedValueChanged
        bEditVoucherNo = False
        bFirstF2 = False
        If tdbcPRVoucherTypeID.SelectedValue Is Nothing OrElse tdbcPRVoucherTypeID.Text = "" Then
            'txtVoucherNo.Text = ""
            'ReadOnlyControl(txtVoucherNo)
            txtPRVoucherNo.Text = ""
            ReadOnlyControl(txtPRVoucherNo)
            Exit Sub
        End If
        ' If _FormState = EnumFormState.FormAdd Then
        If tdbcPRVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
            'txtVoucherNo.Text = CreateIGEVoucherNo(tdbcPRVoucherTypeID, False)
            'ReadOnlyControl(txtVoucherNo)
            txtPRVoucherNo.Text = CreateIGEVoucherNo(tdbcPRVoucherTypeID, False)
            ReadOnlyControl(txtPRVoucherNo)
        Else 'Không sinh tự động
            'txtVoucherNo.Text = ""
            'UnReadOnlyControl(txtVoucherNo, True)
            txtPRVoucherNo.Text = ""
            UnReadOnlyControl(txtPRVoucherNo, True)
        End If


        ' End If
    End Sub

#End Region

#Region "Events tdbcWOVoucherTypeID with txtWOVoucherNo"

    Private Sub tdbcWOVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWOVoucherTypeID.Close
        If tdbcWOVoucherTypeID.FindStringExact(tdbcWOVoucherTypeID.Text) = -1 Then
            tdbcWOVoucherTypeID.Text = ""
            txtWOVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcWOVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWOVoucherTypeID.SelectedValueChanged
        bEditVoucherNo = False
        bFirstF2 = False
        If tdbcWOVoucherTypeID.SelectedValue Is Nothing OrElse tdbcWOVoucherTypeID.Text = "" Then
            'txtVoucherNo.Text = ""
            'ReadOnlyControl(txtVoucherNo)
            txtWOVoucherNo.Text = ""
            ReadOnlyControl(txtWOVoucherNo)
            Exit Sub
        End If
        ' If _FormState = EnumFormState.FormAdd Then
        If tdbcWOVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
            'txtVoucherNo.Text = CreateIGEVoucherNo(tdbcWOVoucherTypeID, False)
            'ReadOnlyControl(txtVoucherNo)
            txtWOVoucherNo.Text = CreateIGEVoucherNo(tdbcWOVoucherTypeID, False)
            ReadOnlyControl(txtWOVoucherNo)
        Else 'Không sinh tự động
            'txtVoucherNo.Text = ""
            'UnReadOnlyControl(txtVoucherNo, True)
            txtWOVoucherNo.Text = ""
            UnReadOnlyControl(txtWOVoucherNo, True)
        End If
        'End If
    End Sub

#End Region

#Region "Events tdbcPRTransTypeID"

    Private Sub tdbcPRTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPRTransTypeID.Close
        If tdbcPRTransTypeID.FindStringExact(tdbcPRTransTypeID.Text) = -1 Then
            tdbcPRTransTypeID.Text = ""
            tdbcPRVoucherTypeID.Text = ""
            txtPRVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcPRTransTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPRTransTypeID.SelectedValueChanged
        If Not (tdbcPRTransTypeID.Tag Is Nothing OrElse tdbcPRTransTypeID.Tag.ToString = "") Then
            tdbcPRTransTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcPRTransTypeID.Text <> "" Then
            tdbcPRVoucherTypeID.SelectedValue = tdbcPRTransTypeID.Columns("VoucherTypeID").Text
            If tdbcPRVoucherTypeID.Text = "" Then
                txtPRVoucherNo.Text = ""
            End If
        End If
    End Sub

    Private Sub tdbcPRTransTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPRTransTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPRVoucherTypeID.Text = ""
            tdbcPRVoucherTypeID.Text = ""
            txtPRVoucherNo.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcWOTransTypeID"

    Private Sub tdbcWOTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWOTransTypeID.Close
        If tdbcWOTransTypeID.FindStringExact(tdbcWOTransTypeID.Text) = -1 Then
            tdbcWOTransTypeID.Text = ""
            tdbcWOVoucherTypeID.Text = ""
            txtWOVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcWOTransTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWOTransTypeID.SelectedValueChanged
        If Not (tdbcWOTransTypeID.Tag Is Nothing OrElse tdbcWOTransTypeID.Tag.ToString = "") Then
            tdbcWOTransTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcWOTransTypeID.Text <> "" Then
            tdbcWOVoucherTypeID.SelectedValue = tdbcWOTransTypeID.Columns("VoucherTypeID").Text
            If tdbcWOVoucherTypeID.Text = "" Then
                txtWOVoucherNo.Text = ""
            End If
        End If
    End Sub

    Private Sub tdbcWOTransTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcWOTransTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcWOVoucherTypeID.Text = ""
            tdbcWOVoucherTypeID.Text = ""
            txtWOVoucherNo.Text = ""
        End If
    End Sub

#End Region

    'Bổ sung 03/07/2009
    Private Sub LockColbyPlanOrderLock()
        If D30Systems.PlanOrderLock Then
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_Quantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_Quantity).Locked = True

            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ExQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ExQuantity).Locked = True

            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ReqDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_ReqDate).Locked = True

            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_EndDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_EndDate).Locked = True

            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_StartDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT1).DisplayColumns(COL1_StartDate).Locked = True
        End If
    End Sub

    Private Sub LoadTDBGrid()
        LoadTDBGrid1(True)
        LoadTDBGrid23(tdbg2, "2", dt_LoadTDBGrid2, sFindTab2, True)
        LoadTDBGrid23(tdbg3, "3", dt_LoadTDBGrid3, sFindTab3, True)
    End Sub

#Region "Load lưới"
    Private Sub LoadTDBGrid1(ByVal bLoad As Boolean, Optional ByVal sWhere As String = "")
        If bLoad OrElse dt_LoadTDBGrid1 Is Nothing Then dt_LoadTDBGrid1 = ReturnDataTable(SQLStoreD30P3315("1"))
        If Not dt_LoadTDBGrid1.Columns.Contains("OQuantity") Then 'Để kiểm tra Dung sai trước khi lưu
            dt_LoadTDBGrid1.Columns.Add("OQuantity", dt_LoadTDBGrid1.Columns("Quantity").DataType, "Quantity")
        End If
        Dim sFilter As String = sWhere
        If sWhere = "" Then sFilter = " IsFirm = " & SQLNumber(chkIsFirm.Checked) & " and IsPR =" & SQLNumber(chkIsPR.Checked) & " and IsProOrder = " & SQLNumber(chkIsProOrder.Checked)
        sFindTab1 = sFindTab1.Replace("N'", "'")
        If sFindTab1 <> "" Then sFilter &= " and " & sFindTab1
        'Mới bổ sung 21/12/2010
        If chkOnlyInventoryZero.Checked Then sFilter &= " And " & tdbg1.Columns(COL1_Quantity).DataField & "<> 0"
        '*************
        LoadDataSource(tdbg1, ReturnTableFilter(dt_LoadTDBGrid1, sFilter), gbUnicode)
        tdbg_FooterText()
    End Sub

    Private Sub LoadTDBGrid23(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sTabNum As String, ByRef dt As DataTable, ByVal sFind As String, ByVal bLoadStore As Boolean, Optional ByVal sWhere As String = "")
        If bLoadStore OrElse dt Is Nothing Then dt = ReturnDataTable(SQLStoreD30P3315(sTabNum))
        Dim sFilter As String = sWhere
        If sWhere = "" Then sFilter = " IsFirm = " & SQLNumber(chkIsFirm.Checked)
        sFind = sFind.Replace("N'", "'")
        If sFind <> "" Then sFilter &= " and " & sFind
        LoadDataSource(c1Grid, ReturnTableFilter(dt, sFilter), gbUnicode)
    End Sub
#End Region

    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        mnsReplaceMaterial.Visible = False
        mnsSalesOrderDetail.Visible = False
        mnsDetachQuantity.Visible = False
        ToolStripSeparator2.Visible = False
        ToolStripSeparator1.Visible = False

        If tab1.SelectedTab.Name = "TabPage3" Then
            mnsFind.Enabled = bEnabledUseFind2 OrElse tdbg3.RowCount > 0
        ElseIf tab1.SelectedTab.Name = "TabPage2" Then
            mnsFind.Enabled = bEnabledUseFind1 OrElse tdbg2.RowCount > 0
        Else
            mnsReplaceMaterial.Visible = True
            mnsSalesOrderDetail.Visible = True
            mnsDetachQuantity.Visible = True
            ToolStripSeparator2.Visible = True
            ToolStripSeparator1.Visible = True

            mnsFind.Enabled = gbEnabledUseFind OrElse tdbg1.RowCount > 0
            mnsReplaceMaterial.Enabled = iPerD30F2413 > 0 And tdbg1.RowCount > 0 And (Not gbClosed)
        End If

        mnsListAll.Enabled = mnsFind.Enabled
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        If AllowSave() = False Then Exit Sub
        'Xoa roi insert vao bang tam
        sSQL = SQLDeleteD30T9115().ToString() & vbCrLf
        sSQL &= SQLInsertD30T9115s_Tab1().ToString() & vbCrLf
        If ExecuteSQL(sSQL) Then   'Modify 14/09/2009
            If CheckStore2(SQLStoreD30P3314()) Then
                sSQL = SQLStoreD30P3316()

                If bPR Then
                    'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                    'CreateIGEVoucherNo(tdbcPRVoucherTypeID, True)
                    If tdbcPRVoucherTypeID.Columns("Auto").Text <> "0" Then txtPRVoucherNo.Text = CreateIGEVoucherNo(tdbcPRVoucherTypeID, True)
                    If CheckDuplicateVoucherNo("D12", "D12T2010", "", txtPRVoucherNo.Text) Then
                        'Nếu tra trùng Số phiếu thì bật
                        Exit Sub
                    End If
                End If

                If bWO Then
                    If tdbcWOVoucherTypeID.Columns("Auto").Text <> "0" Then txtWOVoucherNo.Text = CreateIGEVoucherNo(tdbcWOVoucherTypeID, True)
                    'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                    If CheckDuplicateVoucherNo("D31", "D31T2300", "", txtWOVoucherNo.Text) Then              'Nếu tra trùng Số phiếu thì bật
                        Exit Sub
                    End If
                End If

                Dim bResult As Boolean = ExecuteSQL(sSQL)
                If bResult = True Then
                    SaveOK()
                    bFlagSave = True
                    tdbcPRTransTypeID.Text = ""
                    tdbcPRVoucherTypeID.Text = ""
                    txtPRVoucherNo.Text = ""
                    tdbcWOTransTypeID.Text = ""
                    tdbcWOVoucherTypeID.Text = ""
                    txtWOVoucherNo.Text = ""
                    txtPRDescription.Text = ""
                    txtWODescription.Text = ""
                    LoadTDBGrid1(True)
                Else
                    SaveNotOK()
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        Try
            Select Case e.ColIndex
                Case COL1_IsPR
                    'Neu cot LapYCMH duoc check thi  cot xac nhan va cot LSX bo check
                    If L3Bool(tdbg1.Columns(COL1_IsPR).Text) = True Then
                        tdbg1.Columns(COL1_IsProOrder).Value = False
                    End If
                Case COL1_IsProOrder
                    'Neu cot LSX duoc check thi  cot xac nhan va cot LapYCMH bo check
                    If L3Bool(tdbg1.Columns(COL1_IsProOrder).Text) = True Then
                        tdbg1.Columns(COL1_IsPR).Value = False
                    End If
                Case COL1_EndDate
                    tdbg1.Select()
                Case COL1_StartDate, COL1_ReqDate
                    tdbg1.Select()
                    CalExcuteDateNum()
                Case COL1_UnitID
                    If L3Bool(tdbg1.Columns(COL1_UseFormula).Text) = False Then
                        tdbg1.Columns(COL1_Quantity).Text = CStr(CDec(tdbg1.Columns(COL1_CQuantity).Text) / CDec(tdbg1.Columns(COL1_ConversionFactor).Text))
                    ElseIf L3Bool(tdbg1.Columns(COL1_UseFormula).Text) = True Then
                        tdbg1.Columns(COL1_Quantity).Text = CStr(CDec(tdbg1.Columns(COL1_CQuantity).Text) / CDec(ConversionFactor()))
                    End If

                Case COL1_Quantity
                    If L3Bool(tdbg1.Columns(COL1_UseFormula).Text) = False Then
                        tdbg1.Columns(COL1_CQuantity).Text = CStr(CDec(tdbg1.Columns(COL1_Quantity).Text) * CDec(tdbg1.Columns(COL1_ConversionFactor).Text))
                    Else
                        tdbg1.Columns(COL1_CQuantity).Text = CStr(CDec(tdbg1.Columns(COL1_Quantity).Text) / CDec(ConversionFactor()))
                    End If
                Case COL1_DDat01 To COL1_DDat10
                    tdbg1.Select()
            End Select
            tdbg_FooterText()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            Case COL1_Quantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL1_ExQuantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL1_DNum01 To COL1_DNum10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg1_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg1.BeforeColEdit
        Select Case e.ColIndex
            Case COL1_Model
                LoadTDBDropDownModel(tdbg1.Columns(COL1_InventoryID).Text, tdbg1.Columns(COL1_MRPDetailID).Text)
            Case COL1_UnitID
                LoadDataSource(tdbdUnitID, ReturnTableFilter(dtUnitID, " InventoryID = " & SQLString(tdbg1.Columns(COL1_InventoryID).Text)), gbUnicode)
        End Select
    End Sub

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        Select Case e.ColIndex
            Case COL1_Model
                If tdbg1.Columns(COL1_Model).Text <> tdbdModel.Columns("Model").Text Then
                    tdbg1.Columns(COL1_Model).Text = ""
                    tdbg1.Columns(COL1_ModelDesc).Text = ""
                End If
            Case COL1_UnitID
                If tdbg1.Columns(COL1_UnitID).Text <> tdbdUnitID.Columns("UnitID").Text Then
                    tdbg1.Columns(COL1_UnitID).Text = ""
                End If
            Case COL1_Formula, COL1_Quantity, COL1_ExQuantity, COL1_ProductQuantity
                If Not L3IsNumeric(tdbg1.Columns(e.ColIndex).Text, EnumDataType.Money) Then e.Cancel = True

            Case COL1_DNum01 To COL1_DNum10
                If Not L3IsNumeric(tdbg1.Columns(e.ColIndex).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL1_StartDate, COL1_ReqDate
                If DateDiff(DateInterval.Day, DateValue(tdbg1.Columns(COL1_StartDate).Text), DateValue(tdbg1.Columns(COL1_ReqDate).Text)) < 0 Then
                    D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
                    e.Cancel = True
                    tdbg1.Col = e.ColIndex
                End If
        End Select
    End Sub

    Private Function ConversionFactor() As String
        Dim sSQL As String = ""
        sSQL = SQLStoreD07P7004()
        Dim sConversionFactor As String = ReturnScalar(sSQL)
        Return sConversionFactor
    End Function

    Private Sub tdbg1_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg1.FetchRowStyle
        Try
            If tdbg1.RowCount = 0 Or _formCall <> "D30F3200" Then Exit Sub
            If L3Int(tdbg1(e.Row, COL1_IsBOM)) = 0 Then
                e.CellStyle.ForeColor = Color.FromArgb(D30Systems.NoBOMColor)
            ElseIf L3Int(tdbg1(e.Row, COL1_IsRouting)) = 0 Then
                e.CellStyle.ForeColor = Color.FromArgb(D30Systems.NoRoutingColor)
            ElseIf tdbg1(e.Row, COL1_MultiMode).ToString = "1" Then
                e.CellStyle.ForeColor = Color.Blue
            Else
                e.CellStyle.ForeColor = Color.Black
            End If
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

    End Sub

    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        If tdbg1.Splits(0).DisplayColumns(e.ColIndex).Locked Or tdbg1.Splits(1).DisplayColumns(e.ColIndex).Locked Then
            tdbg1.AllowSort = True
            Exit Sub
        Else
            tdbg1.AllowSort = False
            Select Case tdbg1.Col
                Case COL1_DStr01 To COL1_DStr10, COL1_DDat01 To COL1_DDat10, COL1_DNum01 To COL1_DNum10
                    CopyColumns(tdbg1, tdbg1.Col, tdbg1.Columns(tdbg1.Col).Text, tdbg1.Row)
                    Exit Sub
            End Select
            HeadClick(e.ColIndex)
        End If
    End Sub

    'Append 19/01/2009: cột Xác nhận độc lập với Lập YCMH, LSX
    Private Sub HeadClick(ByVal iCol As Integer)
        Select Case iCol
            Case COL1_IsPR
                If bSelected1_IsPR = False Then
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = True
                            tdbg1(i, COL1_IsProOrder) = False
                            bSelected1_IsPR = True
                            bSelected1_IsProOrder = False
                        End If
                    Next

                Else
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = False
                            bSelected1_IsPR = False
                        End If
                    Next
                End If
            Case COL1_IsFirm
                If bSelected1_IsFirm = False Then
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = True
                            bSelected1_IsFirm = True
                        End If
                    Next

                Else
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = False
                            bSelected1_IsFirm = False
                        End If
                    Next
                End If
            Case COL1_IsProOrder
                If bSelected1_IsProOrder = False Then
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = True
                            tdbg1(i, COL1_IsPR) = False
                            bSelected1_IsPR = False
                            bSelected1_IsProOrder = True
                        End If

                    Next

                Else
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                            tdbg1(i, iCol) = False
                            bSelected1_IsProOrder = False
                        End If
                    Next

                End If
            Case COL1_DetailDesc, COL1_StartDate, COL1_EndDate, COL1_ReqDate
                CopyColumns(tdbg1, iCol, tdbg1.Columns(COL1_DetailDesc).Text, tdbg1.Row)
        End Select
    End Sub

    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        Select Case e.ColIndex
            Case COL1_Model
                tdbg1.Columns(COL1_ModelDesc).Text = tdbdModel.Columns("Notes").Text
                tdbg1.SplitIndex = SPLIT1
                tdbg1.Col = COL1_ModelDesc
            Case COL1_UnitID
                tdbg1.Columns(COL1_ConversionFactor).Text = tdbdUnitID.Columns("ConversionFactor").Text
                tdbg1.Columns(COL1_Formula).Text = tdbdUnitID.Columns("Formula").Text
                tdbg1.Columns(COL1_UseFormula).Text = tdbdUnitID.Columns("UseFormula").Text
                tdbg1.SplitIndex = SPLIT1
                tdbg1.Col = COL1_Model
                If tdbg1.Columns(COL1_UnitID).Text <> tdbdUnitID.Columns("UnitID").Text Then
                    tdbg1.Columns(COL1_UnitID).Text = ""
                    tdbg1.Columns(COL1_Formula).Text = ""
                    tdbg1.Columns(COL1_UseFormula).Text = ""
                    tdbg1.SplitIndex = SPLIT1
                    tdbg1.Col = COL1_UnitID
                End If
                tdbg_FooterText()
        End Select
    End Sub

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If tdbg1.RowCount = 0 Then Exit Sub 'Or tdbg1.Col = e.LastCol 
        If tdbg1.Columns(COL1_Locked).Text = "1" Then
            tdbg1.AllowUpdate = False
        Else
            tdbg1.AllowUpdate = True
        End If
    End Sub

    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        Select Case e.ColIndex
            Case COL2_ReqDate
                tdbg2.Select()
        End Select
    End Sub

    Private Sub tdbg2_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg2.FetchRowStyle
        Try
            If tdbg2.RowCount = 0 Then Exit Sub
            If L3Int(tdbg2(e.Row, COL2_IsBOM)) = 0 Then
                e.CellStyle.ForeColor = Color.FromArgb(D30Systems.NoBOMColor)
            Else
                e.CellStyle.ForeColor = SystemColors.WindowText
            End If
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub tdbg2_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        If tdbg2.Splits(0).DisplayColumns(e.ColIndex).Locked Then
            tdbg2.AllowSort = True
            Exit Sub
        Else
            tdbg2.AllowSort = False
        End If
        If e.ColIndex = COL2_IsFirm Then
            L3HeadClick(tdbg2, COL2_IsFirm, bSelected2)
        End If
    End Sub

    Private Sub tdbg3_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg3.FetchRowStyle
        Try
            If tdbg3.RowCount = 0 Then Exit Sub
            If L3Int(tdbg3(e.Row, COL3_IsBOM)) = 0 Then
                e.CellStyle.ForeColor = Color.FromArgb(D30Systems.NoBOMColor)
            Else
                e.CellStyle.ForeColor = SystemColors.WindowText
            End If
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub tdbg3_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.HeadClick
        If tdbg3.Splits(0).DisplayColumns(e.ColIndex).Locked Then
            tdbg3.AllowSort = True
            Exit Sub
        Else
            tdbg3.AllowSort = False
        End If
        If e.ColIndex = COL3_IsFirm Then
            L3HeadClick(tdbg3, COL3_IsFirm, bSelected3)
        End If
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        If e.Shift And e.KeyCode = Keys.F3 Then
            Dim sSQL As New StringBuilder
            sSQL.Append(SQLDeleteD07T6155() & vbCrLf)
            sSQL.Append(SQLInsertD07T6155s_1)
            ExecuteSQL(sSQL.ToString)

            Dim frm As New Lemon3.DxxMxx40 'ID 	96376  26/04/2017
            With frm
                .exeName = "D07E3140" 'Exe cần gọi
                .FormActive = "D07F6155" 'Form cần hiển thị
                .FormPermission = "D30F3315" 'Mã màn hình phân quyền
                .AddIDxx("ModuleID") = "D30"
                .ShowDialog()
                .Dispose()
            End With
        ElseIf e.KeyCode = Keys.F3 And tdbg1.Col = COL1_InventoryID Then
            Dim arrPro() As StructureProperties = Nothing 'ID 	96376  26/04/2017
            SetProperties(arrPro, "InventoryID", tdbg1.Columns(COL1_InventoryID).Text)
            SetProperties(arrPro, "FormIDPermission", "D30F3315")
            CallFormThread(Me, "D07D3140", "D30F3315", arrPro)

        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg1.Col)
        End If
        HotKeyCtrlVOnGrid(tdbg1, e)
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If e.Shift And e.KeyCode = Keys.F3 Then
            Dim sSQL As New StringBuilder
            sSQL.Append(SQLDeleteD07T6155() & vbCrLf)
            sSQL.Append(SQLInsertD07T6155s_2)
            ExecuteSQL(sSQL.ToString)

            Dim frm As New Lemon3.DxxMxx40 'ID 	96376  26/04/2017
            With frm
                .exeName = "D07E3140" 'Exe cần gọi
                .FormActive = "D07F6155" 'Form cần hiển thị
                .FormPermission = "D30F3315" 'Mã màn hình phân quyền
                .AddIDxx("ModuleID") = "D30"
                .ShowDialog()
                .Dispose()
            End With

        ElseIf e.KeyCode = Keys.F3 And tdbg2.Col = COL2_InventoryID Then
            Dim arrPro() As StructureProperties = Nothing 'ID 	96376  26/04/2017
            SetProperties(arrPro, "InventoryID", tdbg2.Columns(COL2_InventoryID).Text)
            SetProperties(arrPro, "FormIDPermission", "D30F3315")
            CallFormThread(Me, "D07D3140", "D30F3315", arrPro)
        End If
        HotKeyCtrlVOnGrid(tdbg2, e)
    End Sub

    Private Sub tdbg3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg3.KeyDown
        If e.Shift And e.KeyCode = Keys.F3 Then
            Dim sSQL As New StringBuilder
            sSQL.Append(SQLDeleteD07T6155() & vbCrLf)
            sSQL.Append(SQLInsertD07T6155s_3)
            ExecuteSQL(sSQL.ToString)

            Dim frm As New Lemon3.DxxMxx40 'ID 	96376  26/04/2017
            With frm
                .exeName = "D07E3140" 'Exe cần gọi
                .FormActive = "D07F6155" 'Form cần hiển thị
                .FormPermission = "D30F3315" 'Mã màn hình phân quyền
                .AddIDxx("ModuleID") = "D30"
                .ShowDialog()
                .Dispose()
            End With

        ElseIf e.KeyCode = Keys.F3 And tdbg3.Col = COL3_InventoryID Then
            Dim arrPro() As StructureProperties = Nothing 'ID 	96376  26/04/2017
            SetProperties(arrPro, "InventoryID", tdbg3.Columns(COL3_InventoryID).Text)
            CallFormThread(Me, "D07D3140", "D07F6150", arrPro)
        End If
        HotKeyCtrlVOnGrid(tdbg3, e)
    End Sub

    Private Sub LoadTDBDropDownModel(ByVal sInventory As String, ByVal sMRPDetailID As String)
        Dim sSQL As String = ""
        'Load tdbdModel
        sSQL = SQLStoreD30P3328(sInventory, sMRPDetailID)
        LoadDataSource(tdbdModel, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTableUnitID()
        Dim sSQL As String = ""
        'Load tdbdUnitID
        sSQL = "Select T04.UnitID, T05.UnitName" & UnicodeJoin(gbUnicode) & " as UnitName, T04.ConversionFactor, T04.Formula, T04.UseFormula, T04.InventoryID From D07T0004 T04  WITH(NOLOCK) "
        sSQL &= "Inner join D07T0005 T05 on T04.UnitID = T05.UnitID order by T04.UnitID"
        dtUnitID = ReturnDataTable(sSQL)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD30P3328
    '# Created User: Phan Văn Thông
    '# Created Date: 28/11/2012 09:21:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD30P3328(ByVal sInventory As String, ByVal sMRPDetailID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho Dropdown Model" & vbCrLf)
        sSQL &= "Exec D30P3328 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(MRPVoucherID) & COMMA 'MRPVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(sMRPDetailID) & COMMA 'MRPDetailID, bigint, NOT NULL
        sSQL &= SQLString(sInventory) & COMMA 'InventoryID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub mnsDetachQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsDetachQuantity.Click
        If L3Bool(tdbg1.Columns(COL1_IsProcessed).Text) Then
            D99C0008.MsgL3(rl3("Don_hang_du_kien_nay_da_duoc_xu_ly") & " " & rl3("Ban_khong_the_tach_so_luong")) '"Đơn hàng dự kiến này đã được xử lý." & " " & "Bạn không thể tách số lượng")
            Exit Sub
        End If

        Dim f As New D30F3316
        f.MRPVoucherID = _mRPVoucherID
        f.MRPDetailID = L3Int(tdbg1.Columns(COL1_MRPDetailID).Text)
        f.InventoryID = tdbg1.Columns(COL1_InventoryID).Text
        f.UnitID = tdbg1.Columns(COL1_UnitID).Text
        f.Quantity = Number(tdbg1.Columns(COL1_Quantity).Text)
        f.ShowDialog()
        f.Dispose()

        Dim iBookmark As Integer = tdbg1.Bookmark
        LoadTDBGrid1(True)
        tdbg1.Bookmark = iBookmark
    End Sub

    Private Sub mnsSalesOrderDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsSalesOrderDetail.Click
        Dim f As New D30F3317
        f.sMRPVoucherID = _mRPVoucherID
        f.sMRPDetailID = tdbg1.Columns(COL1_MRPDetailID).Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnsReplaceMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsReplaceMaterial.Click
        Dim f As New D30F3321
        f.MRPVoucherID = _mRPVoucherID
        f.MRPDetailID = tdbg1.Columns(COL1_MRPDetailID).Text
        f.InventoryID = tdbg1.Columns(COL1_InventoryID).Text
        f.InventoryName = tdbg1.Columns(COL1_InventoryName).Text
        f.UnitID = tdbg1.Columns(COL1_UnitID).Text
        f.Quantity = Number(tdbg1.Columns(COL1_Quantity).Text)
        f.ShowDialog()
        f.Dispose()

        If gbSavedOK Then
            Dim bm As Integer = tdbg1.Row
            LoadTDBGrid1(True)
            tdbg1.Row = bm
        End If
    End Sub

    Dim dtCaptionCols1 As DataTable
    Dim dtCaptionCols2 As DataTable
    Dim dtCaptionCols3 As DataTable

    Private Sub mnsFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        If tab1.SelectedTab.Name = "TabPage3" Then
            bEnabledUseFind2 = True
            '*****************************************
            'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
            tdbg3.UpdateData()
            If dtCaptionCols3 Is Nothing OrElse dtCaptionCols3.Rows.Count < 1 Then
                'Những cột bắt buộc nhập
                Dim arrColObligatory() As Integer = {}
                Dim Arr As New ArrayList
                AddColVisible(tdbg3, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
                AddColVisible(tdbg3, SPLIT1, Arr, arrColObligatory, False, False, gbUnicode)
                'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table
                dtCaptionCols3 = CreateTableForExcelOnly(tdbg3, Arr)
            End If
            ShowFindDialogClient(FinderTab3, dtCaptionCols3, Me.Name, "2", gbUnicode)
            '*****************************************
        ElseIf tab1.SelectedTab.Name = "TabPage2" Then
            bEnabledUseFind1 = True
            '*****************************************
            'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
            tdbg2.UpdateData()
            If dtCaptionCols2 Is Nothing OrElse dtCaptionCols2.Rows.Count < 1 Then
                'Những cột bắt buộc nhập
                Dim arrColObligatory() As Integer = {}
                Dim Arr As New ArrayList
                AddColVisible(tdbg2, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
                AddColVisible(tdbg2, SPLIT1, Arr, arrColObligatory, False, False, gbUnicode)
                'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table
                dtCaptionCols2 = CreateTableForExcelOnly(tdbg2, Arr)
            End If
            ShowFindDialogClient(FinderTab2, dtCaptionCols2, Me.Name, "1", gbUnicode)
            '*****************************************
        Else
            gbEnabledUseFind = True
            '*****************************************
            'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
            tdbg1.UpdateData()
            If dtCaptionCols1 Is Nothing OrElse dtCaptionCols1.Rows.Count < 1 Then
                'Những cột bắt buộc nhập
                Dim arrColObligatory() As Integer = {}
                Dim Arr As New ArrayList
                AddColVisible(tdbg1, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
                AddColVisible(tdbg1, SPLIT1, Arr, arrColObligatory, False, False, gbUnicode)
                'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table
                dtCaptionCols1 = CreateTableForExcelOnly(tdbg1, Arr)
            End If
            ShowFindDialogClient(FinderTab1, dtCaptionCols1, Me.Name, "0", gbUnicode)
            '*****************************************
        End If
    End Sub

    Private Sub mnsListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        If tab1.SelectedTab.Name = "TabPage3" Then
            sFindTab3 = ""
            LoadTDBGrid23(tdbg3, "3", dt_LoadTDBGrid3, sFindTab3, False)
        ElseIf tab1.SelectedTab.Name = "TabPage2" Then
            sFindTab2 = ""
            LoadTDBGrid23(tdbg2, "2", dt_LoadTDBGrid2, sFindTab2, False)
        Else
            sFindTab1 = ""
            LoadTDBGrid1(False)
        End If
    End Sub

    ' Tìm kiếm cho Lưới Tab 1 =====================================
#Region "Active Find Client - List All "
    Private WithEvents FinderTab1 As New D99C1001
    Private sFindTab1 As String = ""

    Private Sub Findertab1_FindClick(ByVal ResultWhereClause As Object) Handles FinderTab1.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFindTab1 = ResultWhereClause.ToString()
        LoadTDBGrid1(False)
    End Sub
#End Region

    ' Tìm kiếm cho Lưới Tab 2 =====================================

#Region "Active Find Client - List All "
    Private WithEvents FinderTab2 As New D99C1001
    Private sFindTab2 As String = ""

    Private Sub Findertab2_FindClick(ByVal ResultWhereClause As Object) Handles FinderTab2.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFindTab2 = ResultWhereClause.ToString()
        LoadTDBGrid23(tdbg2, "2", dt_LoadTDBGrid2, sFindTab2, False)
    End Sub

    ' Tìm kiếm trên lưới tab3 =========================================
    Private WithEvents FinderTab3 As New D99C1001
    Private sFindTab3 As String = ""

    Private Sub Findertab3_FindClick(ByVal ResultWhereClause As Object) Handles FinderTab3.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFindTab3 = ResultWhereClause.ToString()
        LoadTDBGrid23(tdbg3, "3", dt_LoadTDBGrid3, sFindTab3, False)
    End Sub
#End Region

    Private Sub btnConsoliQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsoliQty.Click
        pnlConsoli.Visible = Not pnlConsoli.Visible
        pnlConsoli.BringToFront()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If D99C0008.Msg(rl3("Ban_co_muon_cong_gop_so_luong_theo_mat_hang"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        ExecuteSQLNoTransaction(SQLStoreD30P3318)
        pnlConsoli.Visible = False
        LoadTDBGrid1(True, "IsConsolidate <> 0")
        CheckIsProOrder()
    End Sub

    Private Sub CheckIsProOrder()
        For i As Integer = 0 To tdbg1.RowCount - 1
            If L3Int(tdbg1(i, COL1_IsConsolidate)) = 2 Then
                tdbg1(i, COL1_IsProOrder) = True
            End If
        Next
    End Sub

    Private Sub btnFirm3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFirm3.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        'Xoa roi insert vao bang tam
        sSQL = SQLDeleteD30T9115().ToString() & vbCrLf
        sSQL &= SQLInsertD30T9115s_Tab3().ToString() ' & vbCrLf
        sSQL &= SQLStoreD30P3316()

        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult = True Then
            SaveOK()
            bFlagSave = True
            LoadTDBGrid23(tdbg3, "3", dt_LoadTDBGrid3, sFindTab3, True)
            tdbg3.UpdateData()
            dt_LoadTDBGrid3.AcceptChanges()
        Else
            SaveNotOK()
        End If
    End Sub

    'Append 19/01/2009
    Private Sub btnFirm2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFirm2.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        'Xoa roi insert vao bang tam
        sSQL = SQLDeleteD30T9115().ToString() & vbCrLf
        sSQL &= SQLInsertD30T9115s_Tab2().ToString() ' & vbCrLf
        sSQL &= SQLStoreD30P3316()

        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult = True Then
            SaveOK()
            bFlagSave = True
            LoadTDBGrid23(tdbg2, "2", dt_LoadTDBGrid2, sFindTab2, True)
            tdbg2.UpdateData()
            dt_LoadTDBGrid2.AcceptChanges()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub btnException_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnException.Click
        Dim f As New D30F3314
        f.MRPVoucherID = _mRPVoucherID
        f.ShowDialog()
        f.Dispose()
    End Sub

    'Create 31/08/2009 Bổ sung các option lọc dữ liệu --- Phân quyền các option
    Dim dMPSToterance As Double 'Kiểm tra Số lượng trước khi lưu
    Private Sub CheckOption()
        Dim sSQL As String
        sSQL = "Select ShowConfirmItem, ShowPRItem, ShowWOItem, MPSToterance From D30T0039 WITH(NOLOCK) "
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        If dt1.Rows.Count > 0 Then
            dMPSToterance = Number(dt1.Rows(0).Item("MPSToterance"))

            If dt1.Rows(0).Item("ShowConfirmItem").ToString = "1" Then
                chkIsFirm.Enabled = ReturnPermission("D30F5621") > 0
            End If
            If dt1.Rows(0).Item("ShowPRItem").ToString = "1" Then
                chkIsPR.Enabled = ReturnPermission("D30F5622") > 0
            End If
            If dt1.Rows(0).Item("ShowWOItem").ToString = "1" Then
                chkIsProOrder.Enabled = ReturnPermission("D30F5623") > 0
            End If
        End If
    End Sub

    Private Sub chkIsFirm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsFirm.CheckedChanged, chkIsPR.CheckedChanged, chkIsProOrder.CheckedChanged
        ReloadTDBG()
    End Sub

    Private Sub ReloadTDBG()  'Load lại lưới theo các option lọc dữ liệu ---- 24/09/2009
        LoadTDBGrid1(False)
        LoadTDBGrid23(tdbg2, "2", dt_LoadTDBGrid2, sFindTab2, False)
        LoadTDBGrid23(tdbg3, "3", dt_LoadTDBGrid3, sFindTab3, False)
    End Sub

    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg1, COL1_InventoryID)
        FooterSumNew(tdbg1, COL1_Quantity, COL1_CQuantity, COL1_ExQuantity, COL1_ProductQuantity)
    End Sub

    Private Sub LoadCaptionICode()
        Dim sSQL As String
        sSQL = "--Do nguon caption cho 10 Ma phan tich" & vbCrLf
        sSQL &= "Select TypeCodeID, Caption" & UnicodeJoin(gbUnicode) & " AS Caption, Disabled" & vbCrLf
        sSQL &= "From D07T0033 WITH(NOLOCK)  Where TypeCodeID Between '01' And '10' Order By 	TypeCodeID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                tdbg1.Columns(COL1_ICode01ID + i).Caption = dt.Rows(i).Item("Caption").ToString
                tdbg1.Splits(0).DisplayColumns(COL1_ICode01ID + i).Visible = Not (L3Bool(dt.Rows(i).Item("Disabled")))
                tdbg1.Splits(0).DisplayColumns(COL1_ICode01ID + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
    End Sub

    Private usrOption As D09U1111
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        If _formCall = "D30F3200" Then
            usrOption.Location = New Point(tab1.Location.X + btnDisplay.Location.X, btnDisplay.Location.Y + 60 - usrOption.Height)
        Else
            usrOption.Location = New Point(tab1.Location.X + btnDisplay.Location.X, btnDisplay.Location.Y + tdbg1.Location.Y - usrOption.Height - 20)
        End If

        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CalExcuteDateNum() '+ 1 Cancel by Thu Ba 11/01/2011
        tdbg1.Columns(COL1_ExcuteDateNum).Text = (DateDiff(DateInterval.Day, DateValue(tdbg1.Columns(COL1_StartDate).Text), DateValue(tdbg1.Columns(COL1_ReqDate).Text))).ToString
    End Sub

    Private Sub chkOnlyInventoryZero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOnlyInventoryZero.Click
        If dt_LoadTDBGrid1 Is Nothing Then Exit Sub
        LoadTDBGrid1(False)
    End Sub

    Private Sub txtCosolidateDays_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCosolidateDays.Validating
        If L3IsNumeric(txtCosolidateDays.Text, EnumDataType.Int) = False Then e.Cancel = True : txtCosolidateDays.Text = "0"
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg1.UpdateData()
        bPR = False
        bWO = False
        Dim i As Integer = 0
        For i = 0 To tdbg1.RowCount - 1
            If L3Bool(tdbg1(i, COL1_Locked)) = False Then
                If L3Bool(tdbg1(i, COL1_IsPR)) Then bPR = True 'Lập YCMH
                If L3Bool(tdbg1(i, COL1_IsProOrder)) Then bWO = True 'Lập LSX
                If bPR And bWO Then Exit For
            End If
        Next
        If bWO Then
            If tdbcWOTransTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai_nghiep_vu")) 'Loai_nghiep_vu_LSX
                tdbcWOTransTypeID.Focus()
                Return False
            End If
            If tdbcWOVoucherTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
                tdbcWOVoucherTypeID.Focus()
                Return False
            End If
            If txtWOVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_phieu"))
                txtWOVoucherNo.Focus()
                Return False
            End If
        End If
        If bPR Then
            If tdbcPRTransTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai_nghiep_vu"))
                tdbcPRTransTypeID.Focus()
                Return False
            End If
            If tdbcPRVoucherTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
                tdbcPRVoucherTypeID.Focus()
                Return False
            End If
            If txtPRVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_phieu"))
                txtPRVoucherNo.Focus()
                Return False
            End If

        End If
        'Append 29/12/2008
        For i = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_StartDate).ToString <> "" And tdbg1(i, COL1_EndDate).ToString <> "" Then
                If DateDiff(DateInterval.Day, CDate(tdbg1(i, COL1_StartDate)), CDate(tdbg1(i, COL1_EndDate))) < 0 Then
                    D99C0008.MsgL3(rl3("Ngay_bat_dau_khong_duoc_lon_hon_ngay_ket_thuc")) 'Ngày bắt đầu không được lớn hơn ngày kết thúc
                    tab1.SelectedTab = TabPage1
                    tdbg1.Col = COL1_StartDate
                    tdbg1.Bookmark = i
                    tdbg1.Focus()
                    Return False
                End If
            End If
            If tdbg1(i, COL1_ReqDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_giao_hang"))
                tab1.SelectedTab = TabPage1
                tdbg1.SplitIndex = 1
                tdbg1.Col = COL1_ReqDate
                tdbg1.Bookmark = i
                tdbg1.Focus()
                Return False
            End If

            If tdbg1(i, COL1_ReqDate).ToString <> "" And tdbg1(i, COL1_EndDate).ToString <> "" Then
                If DateDiff(DateInterval.Day, CDate(tdbg1(i, COL1_EndDate)), CDate(tdbg1(i, COL1_ReqDate))) < 0 Then
                    D99C0008.MsgL3(rl3("Ngay_ket_thuc_khong_duoc_lon_hon_ngay_giao_hang")) 'Ngày kết thúc không được lớn hơn ngày giao hàng
                    tab1.SelectedTab = TabPage1
                    tdbg1.Col = COL1_EndDate
                    tdbg1.Bookmark = i
                    tdbg1.Focus()
                    Return False
                End If
            End If
            Dim dQuantity As Double = Number(tdbg1(i, COL1_Quantity))
            Dim dOQuantity As Double = Number(tdbg1(i, COL1_OQuantity))
            Dim dCompare1 As Double = dOQuantity * (1 + dMPSToterance)
            Dim dCompare2 As Double = dOQuantity * (1 - dMPSToterance)
            If dQuantity > dCompare1 OrElse dQuantity < dCompare2 Then
                D99C0008.MsgL3(rl3("So_luong_vuot_qua_gioi_han_cho_phep")) 'Ngày kết thúc không được lớn hơn ngày giao hàng
                tab1.SelectedTab = TabPage1
                tdbg1.Col = COL1_Quantity
                tdbg1.Bookmark = i
                tdbg1.Focus()
                Return False
            End If
        Next
        '*****************
        Return True
    End Function

    Private Function SQLInsertD30T9115s_Tab1() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_Locked).ToString <> "1" Then

                sSQL.Append("Insert Into D30T9115(")
                sSQL.Append("UserID, TabNum, MRPDetailID, SDType, DetailItemID, ")
                sSQL.Append("InventoryID, Quantity, ExQuantity, OriginalDate, StartDate, EndDate, ReqDate, IsFirm, IsPR, IsProOrder,")
                sSQL.Append(" Spec01ID, Spec02ID, Spec03ID,Spec04ID, Spec05ID, Spec06ID, Spec07ID, Spec08ID, Spec09ID, Spec10ID,")
                sSQL.Append(" DStr01, DStr02, DStr03,DStr04, DStr05, DStr06, DStr07, DStr08, DStr09, DStr10,")
                sSQL.Append(" DStr01U, DStr02U, DStr03U,DStr04U, DStr05U, DStr06U, DStr07U, DStr08U, DStr09U, DStr10U,")
                sSQL.Append(" DNum01, DNum02, DNum03,DNum04, DNum05, DNum06, DNum07, DNum08, DNum09, DNum10,")
                sSQL.Append(" DDat01, DDat02, DDat03,DDat04, DDat05, DDat06, DDat07, DDat08, DDat09, DDat10,")

                sSQL.Append("Model, UnitID,DetailDesc, DetailDescU ,OQuantity")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
                sSQL.Append(SQLNumber("1") & COMMA) 'TabNum, tinyint, NULL
                sSQL.Append(SQLNumber(tdbg1(i, COL1_MRPDetailID).ToString) & COMMA) 'MRPDetailID, bigint, NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_SDType)) & COMMA) 'SDType, varchar[20], NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_DetailItemID).ToString) & COMMA) 'DetailItemID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_InventoryID).ToString) & COMMA) 'InventoryID, varchar[20], NULL
                sSQL.Append(SQLMoney(tdbg1(i, COL1_CQuantity).ToString, DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal, NULL
                sSQL.Append(SQLMoney(tdbg1(i, COL1_ExQuantity).ToString, DxxFormat.D08_QuantityDecimals) & COMMA) 'ExQuantity, decimal, NULL
                sSQL.Append(SQLDateSave("") & COMMA) 'OriginalDate, datetime, NULL
                sSQL.Append(SQLDateSave(tdbg1(i, COL1_StartDate).ToString) & COMMA) 'StartDate, datetime, NULL
                sSQL.Append(SQLDateSave(tdbg1(i, COL1_EndDate).ToString) & COMMA) 'EndDate, datetime, NULL
                sSQL.Append(SQLDateSave(tdbg1(i, COL1_ReqDate).ToString) & COMMA) 'ReqDate, datetime, NULL
                sSQL.Append(SQLNumber(IIf(tdbg1(i, COL1_IsFirm).ToString = "True", "1", "0")) & COMMA) 'IsFirm, bit, NULL
                sSQL.Append(SQLNumber(IIf(tdbg1(i, COL1_IsPR).ToString = "True", "1", "0")) & COMMA) 'IsPR, bit, NULL
                sSQL.Append(SQLNumber(IIf(tdbg1(i, COL1_IsProOrder).ToString = "True", "1", "0")) & COMMA) 'IsProOrder, bit, NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec01ID).ToString) & COMMA) 'Spec01ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec02ID).ToString) & COMMA) 'Spec02ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec03ID).ToString) & COMMA) 'Spec03ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec04ID).ToString) & COMMA) 'Spec04ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec05ID).ToString) & COMMA) 'Spec05ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec06ID).ToString) & COMMA) 'Spec06ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec07ID).ToString) & COMMA) 'Spec07ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec08ID).ToString) & COMMA) 'Spec08ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec09ID).ToString) & COMMA) 'Spec09ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_Spec10ID).ToString) & COMMA) 'Spec10ID, varchar[20], NOT NULL

                For j As Integer = COL1_DStr01 To COL1_DStr10
                    sSQL.Append(SQLStringUnicode(tdbg1(i, j).ToString, gbUnicode, False) & COMMA) ', varchar[20], NOT NULL
                Next

                For j As Integer = COL1_DStr01 To COL1_DStr10
                    sSQL.Append(SQLStringUnicode(tdbg1(i, j).ToString, gbUnicode, True) & COMMA) ', varchar[20], NOT NULL
                Next

                For j As Integer = COL1_DNum01 To COL1_DNum10
                    sSQL.Append(SQLMoney(tdbg1(i, j), DxxFormat.D08_QuantityDecimals) & COMMA) ', varchar[20], NOT NULL
                Next

                For j As Integer = COL1_DDat01 To COL1_DDat10
                    sSQL.Append(SQLDateSave(tdbg1(i, j)) & COMMA) ', varchar[20], NOT NULL
                Next

                sSQL.Append(SQLString(tdbg1(i, COL1_Model).ToString) & COMMA) 'Model, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg1(i, COL1_UnitID).ToString) & COMMA) 'UnitID, varchar[20], NOT NULL

                sSQL.Append(SQLStringUnicode(tdbg1(i, COL1_DetailDesc).ToString, gbUnicode, False) & COMMA) 'DetailDesc, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg1(i, COL1_DetailDesc).ToString, gbUnicode, True) & COMMA) 'DetailDesc, varchar[20], NOT NULL

                sSQL.Append(SQLMoney(tdbg1(i, COL1_Quantity).ToString, DxxFormat.D08_QuantityDecimals)) 'OQuantity, decimal, NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Function SQLInsertD30T9115s_Tab2() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg2.RowCount - 1
            sSQL.Append("Insert Into D30T9115(")
            sSQL.Append("UserID, TabNum, MRPDetailID, SDType, DetailItemID, ")
            sSQL.Append("InventoryID, Quantity, OriginalDate, ReqDate, IsFirm, ")
            sSQL.Append("IsPR, IsProOrder, Spec01ID, Spec02ID, Spec03ID, ")
            sSQL.Append("Spec04ID, Spec05ID, Spec06ID, Spec07ID, Spec08ID, ")
            sSQL.Append("Spec09ID, Spec10ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber("2") & COMMA) 'TabNum, tinyint, NULL
            sSQL.Append(SQLNumber(tdbg2(i, COL2_MRPDetailID).ToString) & COMMA) 'MRPDetailID, bigint, NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_SDType)) & COMMA) 'SDType, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_DetailItemID).ToString) & COMMA) 'DetailItemID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_InventoryID).ToString) & COMMA) 'InventoryID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_Quantity).ToString, DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal, NULL
            sSQL.Append(SQLDateSave("") & COMMA) 'OriginalDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg2(i, COL2_ReqDate).ToString) & COMMA) 'ReqDate, datetime, NULL
            sSQL.Append(SQLNumber(IIf(tdbg2(i, COL2_IsFirm).ToString = "True", "1", "0")) & COMMA) 'IsFirm, bit, NULL
            sSQL.Append(SQLNumber("0") & COMMA) 'IsPR, bit, NULL
            sSQL.Append(SQLNumber("0") & COMMA) 'IsProOrder, bit, NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec01ID).ToString) & COMMA) 'Spec01ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec02ID).ToString) & COMMA) 'Spec02ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec03ID).ToString) & COMMA) 'Spec03ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec04ID).ToString) & COMMA) 'Spec04ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec05ID).ToString) & COMMA) 'Spec05ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec06ID).ToString) & COMMA) 'Spec06ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec07ID).ToString) & COMMA) 'Spec07ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec08ID).ToString) & COMMA) 'Spec08ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec09ID).ToString) & COMMA) 'Spec09ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec10ID).ToString)) 'Spec10ID, varchar[20], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLInsertD30T9115s_Tab3() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Insert Into D30T9115(")
            sSQL.Append("UserID, TabNum, MRPDetailID, SDType, DetailItemID, ")
            sSQL.Append("InventoryID, Quantity, OriginalDate, ReqDate, IsFirm, ")
            sSQL.Append("IsPR, IsProOrder, Spec01ID, Spec02ID, Spec03ID, ")
            sSQL.Append("Spec04ID, Spec05ID, Spec06ID, Spec07ID, Spec08ID, ")
            sSQL.Append("Spec09ID, Spec10ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber("3") & COMMA) 'TabNum, tinyint, NULL
            sSQL.Append(SQLNumber(tdbg3(i, COL3_MRPDetailID).ToString) & COMMA) 'MRPDetailID, bigint, NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_SDType)) & COMMA) 'SDType, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_DetailItemID).ToString) & COMMA) 'DetailItemID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_InventoryID).ToString) & COMMA) 'InventoryID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg3(i, COL3_Quantity).ToString, DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal, NULL
            sSQL.Append(SQLDateSave("") & COMMA) 'OriginalDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg3(i, COL3_ReqDate).ToString) & COMMA) 'ReqDate, datetime, NULL
            sSQL.Append(SQLNumber(IIf(tdbg3(i, COL3_IsFirm).ToString = "True", "1", "0")) & COMMA) 'IsFirm, bit, NULL
            sSQL.Append(SQLNumber("0") & COMMA) 'IsPR, bit, NULL
            sSQL.Append(SQLNumber("0") & COMMA) 'IsProOrder, bit, NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec01ID).ToString) & COMMA) 'Spec01ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec02ID).ToString) & COMMA) 'Spec02ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec03ID).ToString) & COMMA) 'Spec03ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec04ID).ToString) & COMMA) 'Spec04ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec05ID).ToString) & COMMA) 'Spec05ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec06ID).ToString) & COMMA) 'Spec06ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec07ID).ToString) & COMMA) 'Spec07ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec08ID).ToString) & COMMA) 'Spec08ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec09ID).ToString) & COMMA) 'Spec09ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec10ID).ToString)) 'Spec10ID, varchar[20], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD07T6155s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/10/2008 03:33:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: Khi nhấn Shift + F3
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD07T6155s_1() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            sSQL.Append("Insert Into D07T6155(")
            sSQL.Append("UserID, OrderNo, InventoryID,  ")
            sSQL.Append("Spec01ID, Spec02ID,Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID,Spec08ID, Spec09ID, Spec10ID, ")
            sSQL.Append(" OQuantity, ")
            sSQL.Append(" DebitAccountID, CreditAccountID, KindVoucherID, ModuleID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNo, tinyint, NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_InventoryID)) & COMMA) 'InventoryID, varchar[50], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_Spec10ID)) & COMMA) 'Spec10ID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'OQuantity, decimal, NULL
            sSQL.Append("'','',0,'30'")
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLInsertD07T6155s_2() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg2.RowCount - 1
            sSQL.Append("Insert Into D07T6155(")
            sSQL.Append("UserID, OrderNo, InventoryID, Spec01ID, Spec02ID, ")
            sSQL.Append("Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID, ")
            sSQL.Append("Spec08ID, Spec09ID, Spec10ID, OQuantity, ") 'UnitID,CQuantity,
            sSQL.Append(" DebitAccountID, CreditAccountID, KindVoucherID, ModuleID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNo, tinyint, NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_InventoryID)) & COMMA) 'InventoryID, varchar[50], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_Spec10ID)) & COMMA) 'Spec10ID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'OQuantity, decimal, NULL
            sSQL.Append("'','',0,'30'")
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLInsertD07T6155s_3() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Insert Into D07T6155(")
            sSQL.Append("UserID, OrderNo, InventoryID, Spec01ID, Spec02ID, ")
            sSQL.Append("Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID, ")
            sSQL.Append("Spec08ID, Spec09ID, Spec10ID, OQuantity, ") 'UnitID,CQuantity,
            sSQL.Append(" DebitAccountID, CreditAccountID, KindVoucherID, ModuleID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNo, tinyint, NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_InventoryID)) & COMMA) 'InventoryID, varchar[50], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Spec10ID)) & COMMA) 'Spec10ID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg3(i, COL3_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'OQuantity, decimal, NULL
            sSQL.Append("'','',0,'30'")
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD07T6155
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/10/2008 03:31:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: Khi nhấn Shift + F3
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD07T6155() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D07T6155"
        sSQL &= " Where UserID=" & SQLString(gsUserID) & " And ModuleID='30'"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD07P7004
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 31/08/2009 02:38:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD07P7004() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D07P7004 "
        sSQL &= SQLString(tdbg1.Columns(COL1_InventoryID).Text) & COMMA 'InventoryID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'LocationNo, varchar[30], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec01ID).Text) & COMMA 'Spec01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec02ID).Text) & COMMA 'Spec02ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec03ID).Text) & COMMA 'Spec03ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec04ID).Text) & COMMA 'Spec04ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec05ID).Text) & COMMA 'Spec05ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec06ID).Text) & COMMA 'Spec06ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec07ID).Text) & COMMA 'Spec07ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec08ID).Text) & COMMA 'Spec08ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec09ID).Text) & COMMA 'Spec09ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Spec10ID).Text) & COMMA 'Spec10ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL1_Formula).Text) 'Formula, varchar[500], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD30P3318
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 14/01/2009 08:47:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: Cộng gộp số lượng
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD30P3318() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D30P3318 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_mRPVoucherID) & COMMA 'MRPVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkisProductGroup.Checked) & COMMA 'isProductGroup, tinyint, NOT NULL
        sSQL &= SQLNumber(chkisSOGroup.Checked) & COMMA 'isSOGroup, tinyint, NOT NULL
        sSQL &= SQLNumber(txtCosolidateDays.Text) & COMMA 'ConsolidateDays, int, NOT NULL
        sSQL &= SQLString(sFindTab1)
        Return sSQL
    End Function

    Public Function SQLStoreD30P0010(ByVal sTableName As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D30P0010 "
        sSQL &= SQLString(sTableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD30P3315
    '# Created User: 
    '# Created Date: 12/12/2007 09:46:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD30P3315(ByVal TabNum As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D30P3315 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(MRPVoucherID) & COMMA 'MRPvoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(TabNum) & COMMA  'TabNum, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA   'Language
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD30T9115
    '# Created User: Lê Thị Lành
    '# Created Date: 12/12/2007 11:19:07
    '# Modified User: Lê Thị Lành
    '# Modified Date: 18/02/2008
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD30T9115() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D30T9115" & vbCrLf
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD30P3316
    '# Created User:  Lê Thị Lành
    '# Created Date: 12/12/2007 11:43:12
    '# Modified User: Nguyễn Thị Ánh
    '# Modified Date: 25/09/2008 10:42:53
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD30P3316() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D30P3316 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_mRPVoucherID) & COMMA 'MRPVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcPRVoucherTypeID.Text) & COMMA 'PRVoucherTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtPRVoucherNo.Text) & COMMA 'PRVoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcWOVoucherTypeID.Text) & COMMA 'WOVoucherTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtWOVoucherNo.Text) & COMMA  'WOVoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcPRTransTypeID.Text) & COMMA  'PRTransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcWOTransTypeID.Text) & COMMA 'WOTransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtPRDescription.Text) & COMMA 'PRDescription, varchar[250], NOT NULL
        sSQL &= SQLString(txtWODescription.Text) & COMMA 'WODescription, varchar[250], NOT NULL
        sSQL &= SQLNumber(chkIsFirm.Checked) & COMMA 'IsFirm, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsProOrder.Checked) & COMMA 'IsProOrder, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsPR.Checked) & COMMA 'IsPR, tinyint, NOT NULL
        'ID 87067 12.05.2016
        sSQL &= SQLStringUnicode(txtPRDescription.Text, gbUnicode, True) & COMMA 'PRDescriptionU, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtWODescription.Text, gbUnicode, True) 'WODescriptionU, varchar[250], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD30P3314
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 14/09/2009 09:02:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra dữ liệu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD30P3314() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D30P3314 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_mRPVoucherID) & COMMA 'MRPvoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class