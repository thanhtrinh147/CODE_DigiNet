Imports System
Public Class D45F2040
    Dim dtGrid, dtGrid1, dtGrid2 As DataTable
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Private usrOption_D As New D99U1111()
    Dim dtF12_D As DataTable

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _formIDPermission As String = "D45F2040"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _productAddID As String = ""
    Public Property ProductAddID As String
        Get
            Return _productAddID
        End Get
        Set(ByVal Value As String)
            _productAddID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value

            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 17"
    Private Const COL_ProductAddID As Integer = 0   ' ProductAddID
    Private Const COL_Period As Integer = 1         ' Kỳ
    Private Const COL_ProductAddName As Integer = 2 ' Sản phẩm gộp
    Private Const COL_StageID As Integer = 3        ' Công đoạn
    Private Const COL_StageName As Integer = 4      ' Tên công đoạn
    Private Const COL_TotalPPNorm As Integer = 5    ' Tổng định mức
    Private Const COL_CustomerID As Integer = 6     ' Khách hàng
    Private Const COL_CustomerName As Integer = 7   ' Tên khách hàng
    Private Const COL_ProductNotes As Integer = 8   ' Ghi chú
    Private Const COL_Status As Integer = 9         ' Status
    Private Const COL_Message As Integer = 10       ' Message
    Private Const COL_Message1 As Integer = 11      ' Message1
    Private Const COL_BlockID As Integer = 12       ' BlockID
    Private Const COL_TranMonth As Integer = 13     ' TranMonth
    Private Const COL_TranYear As Integer = 14      ' TranYear
    Private Const COL_AdjType As Integer = 15       ' AdjType
    Private Const COL_AdjRate As Integer = 16       ' AdjRate
#End Region

#Region "Const of tdbg1 - Total of Columns: 13"
    Private Const COL1_OrderNum As Integer = 0                         ' STT
    Private Const COL1_GroupProductID As String = "GroupProductID"     ' Mã nhóm SP
    Private Const COL1_GroupProductName As String = "GroupProductName" ' Nhóm sản phẩm
    Private Const COL1_ComponentID As String = "ComponentID"           ' Mã nhóm tiểu tác
    Private Const COL1_ComponentName As String = "ComponentName"       ' Nhóm tiểu tác
    Private Const COL1_TaskID As String = "TaskID"                     ' Mã cụm tiểu tác
    Private Const COL1_TaskName As String = "TaskName"                 ' Cụm tiểu tác
    Private Const COL1_PartProductID As String = "PartProductID"       ' Mã tiểu tác
    Private Const COL1_PartProductName As String = "PartProductName"   ' Tên tiểu tác
    Private Const COL1_PPUnitPrice As String = "PPUnitPrice"           ' Đơn giá
    Private Const COL1_PPNorm As String = "PPNorm"                     ' Định mức
    Private Const COL1_WorkerLevelID As String = "WorkerLevelID"       ' Bậc thợ
    Private Const COL1_PriceListID As String = "PriceListID"           ' Bảng giá
#End Region


#Region "Const of tdbg2 - Total of Columns: 4"
    Private Const COL2_Choose As String = "Choose"           ' Chọn
    Private Const COL2_ProductID As String = "ProductID"     ' Sản phẩm
    Private Const COL2_ProductName As String = "ProductName" ' Tên sản phẩm
    Private Const COL2_Quantity As String = "Quantity"       ' Số lượng
#End Region

    Private Sub D45F2040_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If dtProductAddID IsNot Nothing Then dtProductAddID.Dispose()
        If dtGrid IsNot Nothing Then dtGrid.Dispose()
        If dtGrid1 IsNot Nothing Then dtGrid1.Dispose()
        If dtGrid2 IsNot Nothing Then dtGrid2.Dispose()
    End Sub
    Private Sub D09F0330_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select


        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption_D.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D09F0330_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        gbEnabledUseFind = False
        LoadLanguage()
        SetBackColorObligatory1()
        SetBackColorObligatory()
        tdbg1_LockedColumns()
        tdbg2_LockedColumns()
        tdbg_NumberFormat()
        tdbg1_NumberFormat()
        tdbg2_NumberFormat()
        ResetColorGrid(tdbg)
        ResetFooterGrid(tdbg1, tdbg2)
        LoadDefault()
        '***************
        ResetSplitContainer(SplitContainer1, Color.Blue, 1)
        RotateButton(btnFilterCond)
        SetImageButton(btnSave, btnNotSave, imgButton)
        InputbyUnicode(Me, gbUnicode)
        InputPercent(cneAdjRate)
        CallD99U1111()
        '***************
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        '*********************************
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_muc_ky_thuat") & " - " & Me.Name & UnicodeCaption(gbUnicode) '˜Ünh m÷c kû thuËt
        '================================================================ 
        lblMCustomerID.Text = rl3("Khach_hang") 'Khách hàng
        lblMStageID.Text = rl3("Cong_doan") 'Công đoạn
        lblMProductAddID.Text = rl3("San_pham_gop") 'Sản phẩm gộp
        lblCustomerID.Text = rl3("Khach_hang") 'Khách hàng
        lblStageID.Text = rl3("Cong_doan") 'Công đoạn
        lblProductAddName.Text = rl3("San_pham_gop") 'Sản phẩm gộp
        lblTotalPPNorm.Text = rl3("Tong_dinh_muc") 'Tổng định mức
        lblProductNotes.Text = rl3("Ghi_chu") 'Ghi chú
        lblDetail.Text = rL3("Chi_tiet_bo_dinh_muc_san_pham") 'Chi tiết bộ định mức sản phẩm
        lblAdjType.Text = rL3("Ti_le_dieu_chinh") 'Tỉ lệ điều chỉnh
        '================================================================ 
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        btnFilterCond.Text = rl3("Dieu_kien_loc") 'Điều kiện lọc
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc (F5)
        btnPartProduct.Text = rL3("_Chon_tieu_tac") '&Chọn tiểu tác
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        chkIsUsed.Text = rl3("Hien_thi_tat_ca") 'Hiển thị tất cả
        '================================================================ 
        tdbcMProductAddID.Columns("ProductAddID").Caption = rl3("Ma") 'Mã
        tdbcMProductAddID.Columns("ProductAddName").Caption = rl3("Ten") 'Tên
        tdbcMStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcMStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbcMCustomerID.Columns("CustomerID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbcCustomerID.Columns("CustomerID").Caption = rL3("Ma") 'Mã
        tdbcAdjType.Columns("AdjType").Caption = rL3("Ma") 'Mã
        tdbcAdjType.Columns("AdjTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_ProductAddName).Caption = rL3("San_pham_gop") 'Sản phẩm gộp
        tdbg.Columns(COL_StageID).Caption = rL3("Cong_doan") 'Công đoạn
        tdbg.Columns(COL_StageName).Caption = rL3("Ten_cong_doan") 'Tên công đoạn
        tdbg.Columns(COL_TotalPPNorm).Caption = rL3("Tong_dinh_muc") 'Tổng định mức
        tdbg.Columns(COL_CustomerID).Caption = rL3("Khach_hang") 'Khách hàng
        tdbg.Columns(COL_CustomerName).Caption = rL3("Ten_khach_hang") 'Tên khách hàng
        tdbg.Columns(COL_ProductNotes).Caption = rL3("Ghi_chu") 'Ghi chú
        '================================================================ 
        tdbg1.Columns(COL1_OrderNum).Caption = rL3("STT") 'STT
        tdbg1.Columns(COL1_PartProductName).Caption = rl3("Ten_tieu_tac") 'Tên tiểu tác
        tdbg1.Columns(COL1_PPUnitPrice).Caption = rl3("Don_gia") 'Đơn giá
        tdbg1.Columns(COL1_PPNorm).Caption = rL3("Dinh_muc") 'Định mức
        '================================================================ 
        tdbg1.Columns(COL1_OrderNum).Caption = rL3("STT") 'STT
        tdbg1.Columns(COL1_GroupProductID).Caption = rL3("Ma_nhom_SP") 'Mã nhóm SP
        tdbg1.Columns(COL1_GroupProductName).Caption = rL3("Nhom_san_pham") 'Nhóm sản phẩm
        tdbg1.Columns(COL1_ComponentID).Caption = rL3("Ma_nhom_tieu_tac") 'Mã nhóm tiểu tác
        tdbg1.Columns(COL1_ComponentName).Caption = rL3("Nhom_tieu_tac") 'Nhóm tiểu tác
        tdbg1.Columns(COL1_TaskID).Caption = rL3("Ma_cum_tieu_tac") 'Mã cụm tiểu tác
        tdbg1.Columns(COL1_TaskName).Caption = rL3("Cum_tieu_tac") 'Cụm tiểu tác
        tdbg1.Columns(COL1_WorkerLevelID).Caption = rL3("Bac_tho") 'Bậc thợ
        tdbg1.Columns(COL1_PartProductID).Caption = rL3("Ma_tieu_tac") 'Mã tiểu tác
        tdbg1.Columns(COL1_PartProductName).Caption = rL3("Ten_tieu_tac") 'Tên tiểu tác
        tdbg1.Columns(COL1_PPUnitPrice).Caption = rL3("Don_gia") 'Đơn giá
        tdbg1.Columns(COL1_PPNorm).Caption = rL3("Dinh_muc") 'Định mức
        tdbg1.Columns(COL1_PriceListID).Caption = rL3("Bang_gia") 'Bảng giá
        '================================================================ 
        lblMBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcMBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcMBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblPeriodM.Text = rL3("Ky") 'Kỳ
        lblPeriod.Text = rL3("Ky") 'Kỳ
        '================================================================ 
        tdbg2.Columns(COL2_Quantity).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_Period).Caption = rL3("Ky") 'Kỳ
        '================================================================ 
        tsmInheritNorm.Text = rL3("Dinh_muc_tieu_tac") 'Định mức tiểu tác
        mnsInheritNorm.Text = tsmInheritNorm.Text
        tsmInheritPartProduct.Text = rL3("Tieu_tac") 'Tiểu tác
        mnsInheritPartProduct.Text = tsmInheritPartProduct.Text
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcCustomerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtProductAddName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '***********************************
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_PPUnitPrice).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_PPNorm).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadDefault()
        tdbcMCustomerID.SelectedIndex = 0
        tdbcMBlockID.SelectedIndex = 0
        tdbcMStageID.SelectedIndex = 0

        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString("0000")
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString("0000")

        LoadTDBCMProductAddID()
        '************************
        btnPartProduct.Enabled = ReturnPermission("D45F2040") >= 2 AndAlso btnSave.Enabled 'ID 94509 23/02/2017
        EnableMenu(False, True)
    End Sub
    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_GroupProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_GroupProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_ComponentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_ComponentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_WorkerLevelID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_PartProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_PartProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_PriceListID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_ProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Quantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        InputNumber(cneTotalPPNorm, SqlDbType.Decimal, DxxFormat.DefaultNumber2, , 28, 8)
        '************************
        tdbg.Columns(COL_TotalPPNorm).NumberFormat = DxxFormat.DefaultNumber2
    End Sub
    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg1.Columns(COL1_PPUnitPrice).DataField, DxxFormat.DefaultNumber2, 19, 4)
        AddDecimalColumns(arr, tdbg1.Columns(COL1_PPNorm).DataField, DxxFormat.DefaultNumber2, 19, 4)
        InputNumber(tdbg1, arr)
    End Sub

    Private Sub tdbg2_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg2.Columns(COL2_Quantity).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg2, arr)
    End Sub

    Dim dtProductAddID, dtBlockID, dtStageID As DataTable
    Private Sub LoadTDBCombo()
        Dim dt As DataTable
        Dim sSQL As String = ""

        'Load tdbcMProductAddID
        sSQL = SQLStoreD45P2051()
        dtProductAddID = ReturnDataTable(sSQL)

        'Load tdbcPeriodFromTo
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09", gsDivisionID)

        'Load tdbcPeriod
        LoadCboPeriodReport(tdbcPeriod, "D09", gsDivisionID)

        dtBlockID = ReturnTableBlockID(True, True, gbUnicode)
        LoadDataSource(tdbcMBlockID, dtBlockID, gbUnicode)
        'Load tdbcMStageID

        sSQL = SQLStoreD45P1011()
        dtStageID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcMStageID, dtStageID.DefaultView.ToTable, gbUnicode)

        'Load tdbcStageID
        LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "DisplayOrder=1", True), gbUnicode)
        LoadDataSource(tdbcBlockID, ReturnTableFilter(dtBlockID, "BlockID <>'%'", True), gbUnicode)

        'Load tdbcMCustomerID
        sSQL = SQLStoreD45P1002()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcMCustomerID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbcCustomerID
        LoadDataSource(tdbcCustomerID, ReturnTableFilter(dt, "DisplayOrder=1", True), gbUnicode)
        dt.Dispose()

        'Load tdbcAdjType
        sSQL = "--Do nguon combo Ti le" & vbCrLf
        sSQL &= "SELECT		 '+' AS AdjType, N'" & rL3("Tang_U") & "' AS AdjTypeName" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		 '-' AS AdjType, N'" & rL3("Giam") & "' AS AdjTypeName" & vbCrLf
        LoadDataSource(tdbcAdjType, sSQL, gbUnicode)
    End Sub
    Private Sub LoadTDBCMProductAddID()
        'Load tdbcMProductAddID
        Dim sCustomerID As String = ReturnValueC1Combo(tdbcMCustomerID)
        Dim sStageID As String = ReturnValueC1Combo(tdbcMStageID)
        Dim sFilter As String = ""
        If sCustomerID <> "%" Then sFilter &= "CustomerID =" & SQLString(sCustomerID)
        If sStageID <> "%" Then sFilter &= IIf(sFilter <> "", " And ", "").ToString & "StageID =" & SQLString(sStageID)

        Dim dt As DataTable
        If sFilter = "" Then
            dt = dtProductAddID.DefaultView.ToTable
        Else
            dt = ReturnTableFilter(dtProductAddID, sFilter & " Or DisplayOrder=0", True)
        End If
        LoadDataSource(tdbcMProductAddID, dt, gbUnicode)
        tdbcMProductAddID.SelectedIndex = 0
    End Sub

#Region "Events tdbcMCustomerID"
    Private Sub tdbcMCustomerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMCustomerID.LostFocus
        If tdbcMCustomerID.FindStringExact(tdbcMCustomerID.Text) = -1 Then tdbcMCustomerID.Text = ""
    End Sub
#End Region

#Region "Events tdbcMStageID"
    Private Sub tdbcMStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMStageID.LostFocus
        If tdbcMStageID.FindStringExact(tdbcMStageID.Text) = -1 Then tdbcMStageID.Text = ""
    End Sub

#End Region

#Region "Events tdbcMProductAddID"
    Private Sub tdbcMProductAddID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMProductAddID.LostFocus
        If tdbcMProductAddID.FindStringExact(tdbcMProductAddID.Text) = -1 Then tdbcMProductAddID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCustomerID"
    Private Sub tdbcCustomerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.LostFocus
        If tdbcCustomerID.FindStringExact(tdbcCustomerID.Text) = -1 Then tdbcCustomerID.Text = ""
    End Sub

#End Region

#Region "Events tdbcStageID"
    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then tdbcStageID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcAdjType"
    Private Sub tdbcAdjType_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAdjType.LostFocus
        If tdbcAdjType.FindStringExact(tdbcAdjType.Text) = -1 Then tdbcAdjType.Text = ""
    End Sub

#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMStageID.Close, tdbcMCustomerID.Close, tdbcMProductAddID.Close, tdbcCustomerID.Close, tdbcStageID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMStageID.Validated, tdbcMCustomerID.Validated, tdbcMProductAddID.Validated, tdbcCustomerID.Validated, tdbcStageID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '************************
        Dim sValue As String = ReturnValueC1Combo(tdbc)
        If tdbc.Tag Is Nothing OrElse tdbc.Tag.ToString <> sValue Then
            Select Case tdbc.Name
                Case tdbcMCustomerID.Name, tdbcMStageID.Name
                    LoadTDBCMProductAddID()
                Case tdbcCustomerID.Name
                    LoadTDBGrid2()
            End Select
            tdbc.Tag = sValue
        End If
    End Sub
    Private Sub LoadAdd()
        _bSaved = False
        UnReadOnlyControl(True, tdbcCustomerID, tdbcStageID, tdbcBlockID, txtProductAddName)
        UnReadOnlyControl(False, tdbcAdjType, cneAdjRate)
        '*******************
        If _FormState = EnumFormState.FormCopy Then 'Kế thừa
            If bInheritNorm Then
                txtProductAddName.Text = ""
                txtProductNotes.Text = ""
            Else
                ClearText(grpDetail)
            End If
            tdbcCustomerID.Tag = ReturnValueC1Combo(tdbcCustomerID)
            LoadTDBGrid1()
            chkIsUsed.Checked = True
            LoadTDBGrid2() 'If dtGrid2 IsNot Nothing Then dtGrid2.Clear()
            _productAddID = "" 'Phải để sau LoadTDBGrid1 do kế thừa
        Else
            _productAddID = ""
            ClearText(grpDetail)
            '*******************
            If dtGrid1 IsNot Nothing Then
                dtGrid1.Clear()
                ResetGrid1()
            Else
                LoadTDBGrid1()
            End If
            chkIsUsed.Checked = True
            LoadTDBGrid2() 'If dtGrid2 IsNot Nothing Then dtGrid2.Clear()
        End If
        '*******************
        LockControlDetail(False)
        '*******************
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString("0000")
        bInheritNorm = False
        tdbcCustomerID.Focus()
    End Sub
    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        '************************
        'If _productAddID = tdbg.Columns(COL_ProductAddID).Text Then Exit Sub
        _productAddID = tdbg.Columns(COL_ProductAddID).Text
        '************************
        'Gán dữ liệu
        tdbcCustomerID.SelectedValue = tdbg.Columns(COL_CustomerID).Text
        tdbcBlockID.SelectedValue = tdbg.Columns(COL_BlockID).Text
        tdbcStageID.SelectedValue = tdbg.Columns(COL_StageID).Text
        tdbcPeriod.SelectedValue = tdbg.Columns(COL_Period).Text
        txtProductAddName.Text = tdbg.Columns(COL_ProductAddName).Text
        cneTotalPPNorm.Value = Number(tdbg.Columns(COL_TotalPPNorm).Text)
        txtProductNotes.Text = tdbg.Columns(COL_ProductNotes).Text
        tdbcAdjType.SelectedValue = tdbg.Columns(COL_AdjType).Text
        cneAdjRate.Value = Number(tdbg.Columns(COL_AdjRate).Value)
        tdbcCustomerID.Tag = ""
        tdbcStageID.Tag = ""
        tdbcBlockID.Tag = ""
        '************************
        chkIsUsed.Checked = False
        ReadOnlyControl(tdbcCustomerID, tdbcStageID, tdbcBlockID, tdbcAdjType, cneAdjRate)
        If txtProductNotes.ReadOnly Then
            txtProductNotes.ReadOnly = False
            tdbg1.Enabled = True
            tdbg2.Enabled = True
            chkIsUsed.Enabled = True
        End If
        '************************
        LoadTDBGridDetail()
        btnPartProduct.Enabled = btnSave.Enabled
    End Sub
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
        End If

        Dim sSQL As String = SQLStoreD45P2040()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: menu Tìm kiếm và Liệt kê tất cả luôn luôn sáng khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid(False)
        If sKey <> "" Then
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_ProductAddID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        '****************************
        tdbg.Columns(COL_ProductAddID).Tag = ""
        LoadEdit()
    End Sub
    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        '**************************
        If _FormState = EnumFormState.FormAdd Then Exit Sub
        If tdbg.RowCount = 0 Then
            _productAddID = ""
            ClearText(grpDetail)
            LockControlDetail(True)
            If dtGrid1 IsNot Nothing Then
                dtGrid1.Clear()
                ResetGrid1()
            End If
            If dtGrid2 IsNot Nothing Then dtGrid2.Clear()
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then LoadEdit()
        End If
    End Sub
    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_ProductAddName)
    End Sub
    Private Sub LoadTDBGridDetail()
        If tdbg.RowCount <= 0 Then
            If dtGrid1 IsNot Nothing Then
                dtGrid1.Clear()
                ResetGrid1()
            End If
            If dtGrid2 IsNot Nothing Then dtGrid2.Clear()
            Exit Sub
        End If
        LoadTDBGrid1()
        LoadTDBGrid2()
    End Sub
    Private Sub LoadTDBGrid1(Optional dt As DataTable = Nothing)
        If dt Is Nothing Then
            Dim sSQL As String = SQLStoreD45P2043()
            dtGrid1 = ReturnDataTable(sSQL)
        Else
            'If dtGrid1 IsNot Nothing Then dtGrid1.Clear()
            If dt.Rows.Count > 0 Then 'ID 94509  23/02/2017
                dtGrid1.PrimaryKey = New DataColumn() {dtGrid1.Columns(COL1_PartProductID)}
                dtGrid1.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
            dtGrid1.Merge(dt)
        End If
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        ResetGrid1()
    End Sub
    Private Sub ResetGrid1()
        FooterTotalGrid(tdbg1, COL1_GroupProductID)
        FooterSumNew(tdbg1, COL1_PPNorm)
        '*********************
        cneTotalPPNorm.Value = Number(tdbg1.Columns(COL1_PPNorm).FooterText, tdbg1.Columns(COL1_PPNorm).NumberFormat)
    End Sub
    Private Sub LoadTDBGrid2()
        ResetFilter(tdbg2, sFilter2, bRefreshFilter)
        Dim sSQL As String = SQLStoreD45P2044()
        dtGrid2 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg2, dtGrid2, gbUnicode)
        ReLoadTDBGrid2()
    End Sub
    Private Sub ReLoadTDBGrid2()
        dtGrid2.AcceptChanges()

        Dim strFind As String = ""
        If sFilter2.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter2.ToString

        If chkIsUsed.Checked = False Then
            strFind = COL2_Choose & "=True"
        Else
            If strFind <> "" Then strFind = COL2_Choose & "=True" & " Or " & strFind
        End If

        dtGrid2.DefaultView.RowFilter = strFind
    End Sub
    Private Sub chkIsUsed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.Click
        If dtGrid2 Is Nothing Then Exit Sub
        ReLoadTDBGrid2()
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) Then Return False
        Return True
    End Function

    Private Sub SetBackColorObligatory1()
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False, True)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            If dtGrid1 IsNot Nothing Then
                dtGrid1.Clear()
                ResetGrid1()
            End If
            LoadTDBGrid2()
        Else
            LoadEdit()
            tdbg.Focus()
        End If
        '***********************
        'LockControlDetail(True)
        chkIsUsed.Checked = False
        chkIsUsed_Click(Nothing, Nothing)
    End Sub
    Private Sub LockControlDetail(ByVal bLock As Boolean) ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
        SplitContainer1.Panel2.Enabled = Not bLock
    End Sub
    Private Sub EnableMenu(ByVal bEnabled As Boolean, Optional ByVal bFromFormLoad As Boolean = False)
        If bFromFormLoad = False Then
            If dtGrid Is Nothing Then Exit Sub
        End If
        '*****************
        'tdbg.Enabled = Not bEnabled
        SplitContainer1.Panel1.Enabled = Not bEnabled
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        btnPartProduct.Enabled = ReturnPermission("D45F2040") >= 2 AndAlso btnSave.Enabled 'ID 94509 23/02/2017
        '*****************
        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, True, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        End If
    End Sub

    Private Function AllowEditDelete(Optional bDelete As Boolean = False) As Boolean
        If bDelete Then
            If L3Byte(tdbg.Columns(COL_Status).Text) = 1 Then
                D99C0008.Msg(tdbg.Columns(COL_Message1).Text)
                Return False
            End If
        End If
        If L3String(tdbg.Columns(COL_Period).Text) <> giTranMonth.ToString("00") & "/" & giTranYear.ToString("0000") Then
            D99C0008.Msg(rL3("Du_lieu_khong_thuoc_ky_nay_Ban_khong_duoc_phep_suaxoa"))
            Return False
        End If
        Return True
    End Function

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True, True)
        LoadAdd()
    End Sub
    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        If AllowEditDelete() = False Then Exit Sub
        Dim bEdit As DialogResult
        If L3Byte(tdbg.Columns(COL_Status).Text) = 1 Then
            bEdit = D99C0008.MsgAsk(tdbg.Columns(COL_Message).Text)
            If bEdit = Windows.Forms.DialogResult.Yes Then
                txtProductNotes.ReadOnly = True
                tdbg1.Enabled = False
                tdbg2.Enabled = False
                chkIsUsed.Enabled = False
            Else
                Exit Sub
            End If
        Else
            UnReadOnlyControl(False, tdbcAdjType, cneAdjRate)
        End If
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        If bEdit = Windows.Forms.DialogResult.Yes Then btnPartProduct.Enabled = False
        'LockControlDetail(False)
        _bSaved = False
    End Sub
    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If AllowEditDelete(True) = False Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T2040() & vbCrLf)
        sSQL.Append(SQLDeleteD45T2041() & vbCrLf)
        sSQL.Append(SQLDeleteD45T2042() & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            LoadEdit()
        Else
            DeleteNotOK()
        End If
    End Sub
    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg)
    End Sub
    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click
        Me.Close()
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
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property

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
    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
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
    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    'Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    'Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
    '    iHeight = e.Location.Y
    'End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.FilterActive Then Exit Sub 'Neu o thanh Filter thi k kiem tra va chay su kien RowColChange
        If _productAddID = "" OrElse tdbg(tdbg.Row, COL_ProductAddID).ToString <> _productAddID Then
            LoadEdit()
            _productAddID = tdbg(tdbg.Row, COL_ProductAddID).ToString
        End If
    End Sub
#End Region

#Region "tdbg1"
    Private Sub tdbg1_AfterDelete(sender As Object, e As EventArgs) Handles tdbg1.AfterDelete
        ResetGrid1()
    End Sub
    'Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
    '    tdbg1.UpdateData()
    '    ResetGrid1()
    'End Sub
    'Private Sub tdbg1_HeadClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
    '    HeadClickGrid1(e.ColIndex)
    'End Sub
    'Private Sub tdbg1_KeyDown(sender As Object, e As KeyEventArgs) Handles tdbg1.KeyDown
    '    If e.Control Then
    '        If e.KeyCode = Keys.V Then
    '            If dtGrid1 Is Nothing Then
    '                e.SuppressKeyPress = True
    '                Exit Sub
    '            End If

    '            If PasteRows(dtGrid1, tdbg1, e) = False Then Exit Sub
    '            ResetGrid1()
    '            Exit Sub
    '        ElseIf e.KeyCode = Keys.S Then
    '            HeadClickGrid1(tdbg1.Col)
    '        End If
    '    ElseIf e.KeyCode = Keys.Enter AndAlso tdbg1.Col = IndexOfColumn(tdbg1, COL1_PPNorm) Then
    '        HotKeyEnterGrid(tdbg1, IndexOfColumn(tdbg1, COL1_PartProductName), e)
    '    ElseIf e.Shift AndAlso e.KeyCode = Keys.Insert Then
    '        HotKeyShiftInsert(tdbg1, COL1_OrderNum)
    '    End If

    '    HotKeyDownGrid(e, tdbg1, IndexOfColumn(tdbg1, COL1_PartProductName), 0)
    'End Sub
    Private Sub tdbg1_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg1.UnboundColumnFetch
        Select Case e.Col
            Case COL1_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub
    'Private Sub HeadClickGrid1(iCol As Integer)
    '    Select Case tdbg1.Columns(iCol).DataField
    '        Case COL1_PPUnitPrice
    '            CopyColumns(tdbg1, iCol, tdbg1.Columns(iCol).Text, tdbg1.Row)
    '    End Select
    'End Sub

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbg1"
    Private Sub tdbg1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbg1.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbg1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbg1.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbg1.PointToClient(New Point(e.X, e.Y))
        tdbg1.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbg1, tdbg1.Bookmark, row, IndexOfColumn(tdbg1, COL1_PartProductName))
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbg1_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbg1.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub
    Private Sub tdbg1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg1.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbg1.Row = Me._dragRow
                ' tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbg1.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub
    Private Sub tdbg1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg1.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbg1.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1 As Integer
    Dim col1 As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbg1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg1.MouseUp
        ResetDragDrop()
        Me.tdbg1.CellContaining(e.X, e.Y, row1, col1)
    End Sub

#End Region

#End Region

#Region "tdbg2"
    Dim sFilter2 As New System.Text.StringBuilder()
    Private Sub tdbg2_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        tdbg2.UpdateData()
    End Sub
    Private Sub tdbg2_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.FilterChange
        Try
            If (dtGrid2 Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg2, sFilter2) 'Nếu có Lọc khi In
            ReLoadTDBGrid2()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        If tdbg2.Columns(tdbg2.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg2.Splits(tdbg2.SplitIndex).DisplayColumns(tdbg2.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg2_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg2.FetchRowStyle
        If L3Bool(tdbg2(e.Row, COL2_Choose)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub
    Private Sub tdbg2_HeadClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        HeadClickGrid2(e.ColIndex)
    End Sub
    Private Sub tdbg2_KeyDown(sender As Object, e As KeyEventArgs) Handles tdbg2.KeyDown
        If tdbg2.FilterActive Then HotKeyCtrlVOnGrid(tdbg2, e)
        If e.KeyCode = Keys.Enter AndAlso tdbg2.Col = IndexOfColumn(tdbg2, COL2_Choose) Then
            HotKeyEnterGrid(tdbg2, IndexOfColumn(tdbg2, COL2_Choose), e)
        End If
    End Sub

    Dim bSelect2 As Boolean = False
    Private Sub HeadClickGrid2(iCol As Integer)
        Select Case tdbg2.Columns(iCol).DataField
            Case COL2_Choose
                L3HeadClick(tdbg2, IndexOfColumn(tdbg2, COL2_Choose), bSelect2)
        End Select
    End Sub
#End Region

#Region "Button"
    Private Sub RotateButton(ByRef btn As Button)
        btn.BackgroundImage = Nothing
        Dim iWidth As Integer = btn.Width
        btn.Width = btn.Height
        btn.Height = iWidth

        Dim w As Integer = btn.Width ' Breite des Controls
        Dim h As Integer = btn.Height ' Höhe des Controls

        ' Bitmap für das Abbild des Controls
        Dim myBitmap As New Bitmap(w, h)  'Es wird ein Bild des Labels erzeugt
        btn.DrawToBitmap(myBitmap, Rectangle.FromLTRB(0, 0, w, h))  'hier wird es gemacht
        myBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY)       'und hier gedreht
        btn.BackgroundImage = myBitmap
        btn.Text = ""
        btn.Width = h
        btn.Height = w
    End Sub
    Private Sub btnFilterCond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterCond.Click
        If pnlFilter.Visible Then
            pnlFilter.Visible = False
            tdbg.Left = tdbg.Left - pnlFilter.Width - 5
            tdbg.Width = tdbg.Width + pnlFilter.Width + 5
        Else
            pnlFilter.Visible = True
            tdbg.Left = tdbg.Left + pnlFilter.Width + 5
            tdbg.Width = tdbg.Width - pnlFilter.Width - 5
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        SaveData(sender)
    End Sub
    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso (tdbcCustomerID.Text = "" AndAlso tdbcBlockID.Text = "" AndAlso tdbcStageID.Text = "" AndAlso txtProductAddName.Text = "") Then
            If tdbg.RowCount > 0 Then LoadEdit()
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        End If
1:
        SetReturnFormView()
    End Sub
#End Region
    Private Function AllowSave() As Boolean
        If tdbcPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblPeriod.Text)
            tdbcPeriod.Focus()
            Return False
        End If
        If tdbcCustomerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblCustomerID.Text)
            tdbcCustomerID.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblStageID.Text)
            tdbcStageID.Focus()
            Return False
        End If
        If txtProductAddName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblProductAddName.Text)
            txtProductAddName.Focus()
            Return False
        End If
        'If IsExistKey("D45T2040", "ProductAddName", txtProductAddName.Text) Then
        '    D99C0008.MsgDuplicatePKey()
        '    txtProductAddName.Focus()
        '    Return False
        'End If
        '************************
        tdbg1.UpdateData()
        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_PartProductName).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg1.Columns(COL1_PartProductName).Caption)
                tdbg1.Focus()
                tdbg1.SplitIndex = 0
                tdbg1.Col = IndexOfColumn(tdbg1, COL1_PartProductName)
                tdbg1.Row = i  'findrowInGrid(tdbg1, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If tdbg1(i, COL1_PPUnitPrice).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg1.Columns(COL1_PPUnitPrice).Caption)
                tdbg1.Focus()
                tdbg1.SplitIndex = 0
                tdbg1.Col = IndexOfColumn(tdbg1, COL1_PPUnitPrice)
                tdbg1.Row = i  'findrowInGrid(tdbg1, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If tdbg1(i, COL1_PPNorm).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg1.Columns(COL1_PPNorm).Caption)
                tdbg1.Focus()
                tdbg1.SplitIndex = 0
                tdbg1.Col = IndexOfColumn(tdbg1, COL1_PPNorm)
                tdbg1.Row = i  'findrowInGrid(tdbg1, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
        Next
        '*************************
        tdbg2.UpdateData()
        If tdbg2.RowCount <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg2.Focus()
            Return False
        End If
        Dim dr() As DataRow = dtGrid2.Select(COL2_Choose & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg2.Focus()
            tdbg2.SplitIndex = SPLIT0
            tdbg2.Col = IndexOfColumn(tdbg2, COL2_Choose)
            tdbg2.Row = 0
            Return False
        End If
        Return True
    End Function
    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                If _productAddID = "" Then _productAddID = CreateIGE("D45T2040", "ProductAddID", "45", "PA", gsStringKey)
                sSQL.AppendLine(SQLInsertD45T2040.ToString)
                sSQL.AppendLine(SQLInsertD45T2041s.ToString)
                sSQL.AppendLine(SQLInsertD45T2042s.ToString)
            Case EnumFormState.FormEdit
                sSQL.AppendLine(SQLUpdateD45T2040.ToString)
                sSQL.AppendLine(SQLDeleteD45T2041.ToString)
                sSQL.AppendLine(SQLInsertD45T2041s.ToString)
                sSQL.AppendLine(SQLDeleteD45T2042.ToString)
                sSQL.AppendLine(SQLInsertD45T2042s.ToString)
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    LoadTDBGrid(True, _productAddID)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, _productAddID)
            End Select
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Me.Cursor = Cursors.Default
        Return True
    End Function


#Region "Các hàm di chuyển của lưới"

    Private _ptStartDrag As Point = Point.Empty
    Private _dragRow As Integer = -1
    Private Sub ResetDragDrop()
        ' Turn off drag-and-drop by resetting the highlight and label text.
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        'tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder
    End Sub
    Private Sub MoveRowNew(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iFrom As Integer, ByVal iTo As Integer, Optional ByVal iColKey As Integer = -1)
        'Các sự kiện để di chuyển dòng
        '1. tdbg_MouseUp
        '2. tdbg_MouseDown
        '3. tdbg_MouseMove
        '4. tdbg_QueryContinueDrag()
        '5. tdbg_DragDrop()
        '6. tdbg_DragEnter()
        Dim iRowCount As Integer = 0
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, 0).ToString <> "" Then
                iRowCount += 1
            Else
                Exit For
            End If
        Next
        If iTo >= iRowCount Then Exit Sub
        'End Edit
        If iFrom < iTo Then
            For i As Integer = iFrom To iTo - 1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    Dim sValue As String = tdbg(i, col).ToString
                    'Gán cột là khóa = ""
                    If col = iColKey Then
                        Dim sValueKey As String = tdbg(i + 1, col).ToString
                        tdbg(i + 1, col) = ""
                        tdbg(i, col) = sValueKey
                    Else
                        tdbg(i, col) = tdbg(i + 1, col).ToString
                    End If
                    tdbg(i + 1, col) = sValue
                Next
            Next
        Else
            For i As Integer = iFrom To iTo + 1 Step -1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    Dim sValue As String = tdbg(i - 1, col).ToString
                    'Gán cột là khóa = ""
                    If col = iColKey Then
                        Dim sValueKey As String = tdbg(i, col).ToString
                        tdbg(i, col) = ""
                        tdbg(i - 1, col) = sValueKey
                    Else
                        tdbg(i - 1, col) = tdbg(i, col).ToString
                    End If
                    tdbg(i, col) = sValue
                Next
            Next
        End If
        tdbg.UpdateData()
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1002
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 03:57:32
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1002() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load khach hang" & vbCrLf)
        sSQL &= "Exec D45P1002 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(1) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1011
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 01:51:04
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1011() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load cong doan" & vbCrLf)
        sSQL &= "Exec D45P1011 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2051
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 01:51:44
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load san pham gop" & vbCrLf)
        sSQL &= "Exec D45P2051 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2040
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:06:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2040() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luoi truy van dinh muc ky thuat" & vbCrLf)
        sSQL &= "Exec D45P2040 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMCustomerID)) & COMMA 'CustomerID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMStageID)) & COMMA 'StageID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMProductAddID)) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranMonth")) & COMMA 'TranMonthFrom, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranYear")) & COMMA 'TranYearFrom, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranMonth")) & COMMA 'TranMonthTo, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranYear")) 'TranYearTo, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2043
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:09:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2043() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi tieu tac" & vbCrLf)
        sSQL &= "Exec D45P2043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_productAddID) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormCopy, 2, 0)) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2044
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/03/2016 11:46:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2044() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho cho luoi San pham" & vbCrLf)
        sSQL &= "Exec D45P2044 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(_productAddID) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcCustomerID)) & COMMA 'CustomerID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormAdd, giTranMonth, tdbg.Columns(COL_TranMonth).Text)) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormAdd, giTranYear, tdbg.Columns(COL_TranYear).Text)) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2040
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:38:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2040() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang Master" & vbCrLf)
        sSQL &= "Delete From D45T2040"
        sSQL &= " Where ProductAddID = " & SQLString(_productAddID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2041
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:38:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2041() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang Detail D45T2041" & vbCrLf)
        sSQL &= "Delete From D45T2041"
        sSQL &= " Where ProductAddID = " & SQLString(_productAddID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2041
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:38:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2042() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang Detail D45T2042" & vbCrLf)
        sSQL &= "Delete From D45T2042"
        sSQL &= " Where ProductAddID = " & SQLString(_productAddID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2040
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:45:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2040() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert dinh muc ky thuat Master" & vbCrLf)
        sSQL.Append("Insert Into D45T2040(")
        sSQL.Append("ProductAddID, ProductAddName, CustomerID, StageID, ProductNotes, " & vbCrLf)
        sSQL.Append("TotalPPNorm, AdjType, AdjRate, TranMonth, TranYear, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(_productAddID) & COMMA) 'ProductAddID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtProductAddName, True) & COMMA) 'ProductAddName, nvarchar[1000], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCustomerID)) & COMMA) 'CustomerID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcStageID)) & COMMA) 'StageID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtProductNotes, True) & COMMA & vbCrLf) 'ProductNotes, nvarchar[1000], NOT NULL
        sSQL.Append(SQLMoney(cneTotalPPNorm.Value) & COMMA) 'TotalPPNorm, decimal, NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcAdjType)) & COMMA) 'AdjType, varchar[50], NOT NULL
        sSQL.Append(SQLMoney(cneAdjRate.Value) & COMMA) 'AdjRate, decimal, NOT NULL
        sSQL.Append(SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA) 'TranMonth, decimal, NOT NULL
        sSQL.Append(SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) & COMMA) 'TranYear, decimal, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrLf) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T2040
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:55:56
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T2040() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Update du lieu bang Master D45T2040" & vbCrLf)
        sSQL.Append("Update D45T2040 Set ")
        sSQL.Append("ProductAddName = " & SQLStringUnicode(txtProductAddName, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("ProductNotes = " & SQLStringUnicode(txtProductNotes, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("TotalPPNorm = " & SQLMoney(cneTotalPPNorm.Value) & COMMA) 'decimal, NOT NULL
        sSQL.Append("AdjType = " & SQLString(ReturnValueC1Combo(tdbcAdjType)) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("AdjRate = " & SQLMoney(cneAdjRate.Value) & COMMA) 'decimal, NOT NULL
        sSQL.Append("TranMonth = " & SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA) 'decimal, NOT NULL
        sSQL.Append("TranYear = " & SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) & COMMA) 'decimal, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where ProductAddID =" & SQLString(_productAddID))
        Return sSQL
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD45T2041s
    ''# Created User: Nguyễn Lê Phương
    ''# Created Date: 09/03/2016 02:49:11
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD45T2041s() As StringBuilder
    '    Dim sRet As New StringBuilder
    '    'Sinh IGE chi tiết
    '    Dim sPartProductID As String = ""
    '    Dim iFirstTrans As Long = 0
    '    Dim iCountIGE As Integer = 0
    '    Dim dtSourceGrid As DataTable = CType(tdbg1.DataSource, DataTable)
    '    iCountIGE = dtSourceGrid.Select(COL1_PartProductID & "='' or " & COL1_PartProductID & " is null").Length
    '    '---------------------------------
    '    Dim sSQL As New StringBuilder
    '    For i As Integer = 0 To tdbg1.RowCount - 1
    '        If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert du lieu vao bang Detail D45T2041" & vbCrLf)
    '        If tdbg1(i, COL1_PartProductID).ToString = "" Then
    '            sPartProductID = CreateIGENewS("D45T2041", "PartProductID", "45", "PP", gsStringKey, sPartProductID, iCountIGE, iFirstTrans)
    '            tdbg1(i, COL1_PartProductID) = sPartProductID
    '        End If
    '        sSQL.Append("Insert Into D45T2041(")
    '        sSQL.Append("PartProductID, OrderNum, ProductAddID, PartProductName, PPUnitPrice, " & vbCrLf)
    '        sSQL.Append("PPNorm")
    '        sSQL.Append(") Values(" & vbCrLf)
    '        sSQL.Append(SQLString(tdbg1(i, COL1_PartProductID)) & COMMA) 'PartProductID [KEY], varchar[50], NOT NULL
    '        sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNum, int, NOT NULL
    '        sSQL.Append(SQLString(_productAddID) & COMMA) 'ProductAddID, varchar[50], NOT NULL
    '        sSQL.Append(SQLStringUnicode(tdbg1(i, COL1_PartProductName), gbUnicode, True) & COMMA) 'PartProductName, nvarchar[1000], NOT NULL
    '        sSQL.Append(SQLMoney(tdbg1(i, COL1_PPUnitPrice), tdbg1.Columns(COL1_PPUnitPrice).NumberFormat) & COMMA & vbCrLf) 'PPUnitPrice, decimal, NOT NULL
    '        sSQL.Append(SQLMoney(tdbg1(i, COL1_PPNorm), tdbg1.Columns(COL1_PPNorm).NumberFormat)) 'PPNorm, decimal, NOT NULL
    '        sSQL.Append(")")

    '        sRet.Append(sSQL.ToString & vbCrLf)
    '        sSQL.Remove(0, sSQL.Length)
    '    Next
    '    Return sRet
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2041s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 23/02/2017 10:10:45
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2041s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert du lieu vao bang Detail D45T2041" & vbCrlf)
            sSQL.Append("Insert Into D45T2041(")
            sSQL.Append("PartProductID, OrderNum, ProductAddID, PartProductName, PPUnitPrice, " & vbCrlf)
            sSQL.Append("PPNorm, GroupProductID, ComponentID, TaskID, PriceListID")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(tdbg1(i, COL1_PartProductID)) & COMMA) 'PartProductID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg1(i, COL1_OrderNum)) & COMMA) 'OrderNum, int, NOT NULL
            sSQL.Append(SQLString(_productAddID) & COMMA) 'ProductAddID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg1(i, COL1_PartProductName), gbUnicode, True) & COMMA) 'PartProductName, nvarchar[1000], NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_PPUnitPrice), tdbg1.Columns(COL1_PPUnitPrice).NumberFormat) & COMMA & vbCrlf) 'PPUnitPrice, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_PPNorm), tdbg1.Columns(COL1_PPNorm).NumberFormat) & COMMA) 'PPNorm, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_GroupProductID)) & COMMA) 'GroupProductID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_ComponentID)) & COMMA) 'ComponentID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_TaskID)) & COMMA & vbCrlf) 'TaskID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_PriceListID))) 'PriceListID, varchar[50], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2042s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 02:52:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2042s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim dr() As DataRow = dtGrid2.Select(COL2_Choose & "=True")
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang Detail D45T2042" & vbCrLf)
            sSQL.Append("Insert Into D45T2042(")
            sSQL.Append("ProductID, ProductAddID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(dr(i).Item(COL2_ProductID).ToString) & COMMA) 'ProductID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLString(_productAddID)) 'ProductAddID [KEY], varchar[50], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub tdbcMBlockID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcMBlockID.SelectedValueChanged
        If ReturnValueC1Combo(tdbcMBlockID) = "%" Then
            LoadDataSource(tdbcMStageID, dtStageID, gbUnicode)
        Else
            LoadDataSource(tdbcMStageID, ReturnTableFilter(dtStageID, "BlockID= '%' or BlockID=" & SQLString(ReturnValueC1Combo(tdbcMBlockID)), True), gbUnicode)
        End If
        tdbcMStageID.SelectedIndex = 0
    End Sub

    Private Sub tdbcMBlockID_Validated(sender As Object, e As EventArgs) Handles tdbcMBlockID.Validated
        If tdbcMBlockID.FindStringExact(tdbcMBlockID.Text) = -1 Then
            tdbcMBlockID.Text = ""
            tdbcMStageID.Text = ""
            tdbcMProductAddID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If ReturnValueC1Combo(tdbcBlockID) = "%" Then
            LoadDataSource(tdbcStageID, dtStageID, gbUnicode)
        Else
            LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "BlockID=" & SQLString(ReturnValueC1Combo(tdbcBlockID)), True), gbUnicode)
        End If

    End Sub

    Private Sub tdbcBlockID_Validated(sender As Object, e As EventArgs) Handles tdbcBlockID.Validated
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcStageID.Text = ""
        End If
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption_D Is Nothing Then Exit Sub 'TH lưới không có cột
        'usrOption_D.Location = New Point(tdbgD.Left, btnF12.Top - (usrOption_D.Height + 7))
        'Me.Controls.Add(usrOption_D)

        Me.SplitContainer1.Panel2.Controls.Add(usrOption_D)
        usrOption_D.Height = tdbg1.Height
        usrOption_D.Location = tdbg1.Location
        usrOption_D.BringToFront()
        usrOption_D.Visible = True
    End Sub
    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL1_PartProductID, COL1_PPNorm, COL1_PPUnitPrice}
        usrOption_D.AddColVisible(tdbg1, dtF12_D, arrColObligatory)
        If usrOption_D IsNot Nothing Then usrOption_D.Dispose()
        usrOption_D = New D99U1111(Me, tdbg1, dtF12_D)
    End Sub

#Region "ID 94509 23/02/2017"
    Dim bInheritNorm As Boolean = False 'Kế thừa định mức tiểu tác
    Private Sub tsmInheritNorm_Click(sender As Object, e As EventArgs) Handles tsmInheritNorm.Click, mnsInheritNorm.Click
        bInheritNorm = True
        _FormState = EnumFormState.FormCopy
        EnableMenu(True, True)
        LoadAdd()
    End Sub
    Private Sub tsmInheritPartProduct_Click(sender As Object, e As EventArgs) Handles tsmInheritPartProduct.Click, mnsInheritPartProduct.Click
        _FormState = EnumFormState.FormCopy
        EnableMenu(True, True)
        LoadAdd()
    End Sub
    Private Sub btnPartProduct_Click(sender As Object, e As EventArgs) Handles btnPartProduct.Click
        btnPartProduct.Focus()
        If btnPartProduct.Focused = False Then Exit Sub
        '************************
        Dim f As New D45F2045
        f.ShowDialog()
        If f.bSaved Then LoadTDBGrid1(f.dtGridD45F2045)
        f.Dispose()
    End Sub
#End Region

    

  
End Class
