Public Class D45F2050
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.'
        'Các control chỉnh theo Anchor là XXX
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, pnlMaster, tdbg2)
        AnchorForControl(EnumAnchorStyles.TopLeftRight, tdbg, grp1)
        AnchorForControl(EnumAnchorStyles.TopRight, lblProductPart, tdbg1, grp2)
        AnchorForControl(EnumAnchorStyles.BottomLeft, pnlA, btnAdd, btnCopy)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnlB, btnSave, btnNotSave)
    End Sub

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 5"
    Private Const COL_ProductAddID As String = "ProductAddID"     ' ProductAddID
    Private Const COL_ProductAddName As String = "ProductAddName" ' Sản phẩm gộp
    Private Const COL_SumQuantity As String = "SumQuantity"       ' Sản lượng
    Private Const COL_CustomerName As String = "CustomerName"     ' Khách hàng
    Private Const COL_TotalPPNorm As String = "TotalPPNorm"       ' Tổng định mức
#End Region


#Region "Const of tdbg1 - Total of Columns: 7"
    Private Const COL1_PartProductID As String = "PartProductID"     ' PartProductID
    Private Const COL1_OrderNum As String = "OrderNum"               ' STT
    Private Const COL1_PartProductName As String = "PartProductName" ' Tên tiểu tác
    Private Const COL1_PPUnitPrice As String = "PPUnitPrice"         ' Đơn giá
    Private Const COL1_PPNorm As String = "PPNorm"                   ' Định mức
    Private Const COL1_Style As String = "Style"                     ' Style
    Private Const COL1_IsEntered As String = "IsEntered"             ' IsEntered
#End Region


#Region "Const of tdbg2 - Total of Columns: 12"
    Private Const COL2_EmpPartProductID As String = "EmpPartProductID"   ' EmpPartProductID
    Private Const COL2_EmployeeID As String = "EmployeeID"               ' Mã NV
    Private Const COL2_EmployeeName As String = "EmployeeName"           ' Họ và tên
    Private Const COL2_DepartmentName As String = "DepartmentName"       ' Phòng ban
    Private Const COL2_TeamName As String = "TeamName"                   ' Tổ nhóm
    Private Const COL2_EmpQuantity As String = "EmpQuantity"             ' Sản lượng
    Private Const COL2_TotalTime As String = "TotalTime"                 ' Tổng thời gian
    Private Const COL2_EmpAmount As String = "EmpAmount"                 ' Thành tiền
    Private Const COL2_IsEmpOutsideStage As String = "IsEmpOutsideStage" ' IsEmpOutsideStage
    Private Const COL2_DepartmentID As String = "DepartmentID"           ' DepartmentID
    Private Const COL2_TeamID As String = "TeamID"                       ' TeamID
    Private Const COL2_PartProductID As String = "PartProductID"         ' PartProductID
#End Region


    Private dtGrid, dtGrid1, dtGrid2, dtBlockID, dtStageID As DataTable
    Dim bKeyPress As Boolean = False 'Kiểm tra xem lưới sản lượng có thay đổi dữ liệu không
    Private Sub D45F2050_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If dtGrid IsNot Nothing Then dtGrid.Dispose()
        If dtGrid1 IsNot Nothing Then dtGrid1.Dispose()
        If dtGrid2 IsNot Nothing Then dtGrid2.Dispose()

    End Sub
    Private Sub D45F2050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        SetBackColorObligatory()
        LoadLanguage()
        LoadTDBCombo()
        ResetColorGrid(tdbg, tdbg1)
        ResetFooterGrid(tdbg2, 0, tdbg2.Splits.Count - 1)
        tdbg_NumberFormat()
        tdbg1_NumberFormat()
        tdbg2_NumberFormat()
        tdbg2_LockedColumns()
        EnabledButton()
        SetImageButton(btnSave, btnNotSave, imgButton)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub D45F2050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub
    Private Sub SetBackColorObligatory()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_EmployeeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_EmployeeName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_EmpQuantity).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Can_doi_san_pham") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'C¡n ¢çi s¶n phÈm
        '================================================================ 
        lblPeriod.Text = rL3("Ky") 'Kỳ
        lblStageID.Text = rL3("Cong_doan") 'Công đoạn
        lblProductAdd.Text = rL3("Danh_sach_san_pham_gop") 'Danh sách sản phẩm gộp
        lblQuantity.Text = rL3("San_luong_thuc_hien_tieu_tac") 'Sản lượng thực hiện tiểu tác
        lblProductPart.Text = rL3("Danh_sach_tieu_tac_san_pham_gop")
        lblQuantity.Text = rL3("San_luong_thuc_hien_tieu_tac")
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnNotSave.Text = rL3("_Khong_luu") '&Không lưu
        btnAdd.Text = rL3("_Them_nhan_vien") '&Thêm nhân viên
        btnCopy.Text = rL3("_Sao_chep") '&Sao chép
        '================================================================ 
        tdbcStageID.Columns("StageID").Caption = rL3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_ProductAddName).Caption = rL3("San_pham_gop") 'Sản phẩm gộp
        tdbg.Columns(COL_SumQuantity).Caption = rL3("San_luong") 'Sản lượng
        tdbg.Columns(COL_CustomerName).Caption = rL3("Khach_hang") 'Khách hàng
        tdbg.Columns(COL_TotalPPNorm).Caption = rL3("Tong_dinh_muc") 'Tổng định mức
        '================================================================ 
        tdbg1.Columns(COL1_OrderNum).Caption = rL3("STT") 'STT
        tdbg1.Columns(COL1_PartProductName).Caption = rL3("Ten_tieu_tac") 'Tên tiểu tác
        tdbg1.Columns(COL1_PPUnitPrice).Caption = rL3("Don_gia") 'Đơn giá
        tdbg1.Columns(COL1_PPNorm).Caption = rL3("Dinh_muc") 'Định mức
        '================================================================ 
        tdbg2.Columns(COL2_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg2.Columns(COL2_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg2.Columns(COL2_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg2.Columns(COL2_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg2.Columns(COL2_EmpQuantity).Caption = rL3("San_luong") 'Sản lượng
        tdbg2.Columns(COL2_TotalTime).Caption = rL3("Tong_thoi_gian") 'Tổng thời gian
        tdbg2.Columns(COL2_EmpAmount).Caption = rL3("Thanh_tien") 'Thành tiền

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        msnPaste.Text = rL3("Dan") 'Dán
        msnCopy.Text = rL3("Sao_chep") 'Sao chép

        '================================================================ 
        tdbdEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbdEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        tdbdEmployeeName.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbdEmployeeName.Columns("EmployeeName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        msnDeleteE.Text = rL3("Xoa_danh_sach_nhan_vien")

    End Sub
    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_TotalTime).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_EmpAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_SumQuantity).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_TotalPPNorm).NumberFormat = DxxFormat.DefaultNumber2
    End Sub
    Private Sub tdbg1_NumberFormat()
        tdbg1.Columns(COL1_PPUnitPrice).NumberFormat = DxxFormat.DefaultNumber2
        tdbg1.Columns(COL1_PPNorm).NumberFormat = DxxFormat.DefaultNumber2
    End Sub
    Private Sub tdbg2_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddNumberColumns(arr, SqlDbType.Int, COL2_EmpQuantity, DxxFormat.DefaultNumber0)
        AddDecimalColumns(arr, tdbg2.Columns(COL2_TotalTime).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg2.Columns(COL2_EmpAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg2, arr)
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcStageID
        sSQL = SQLStoreD45P1011()
        dtStageID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "DisplayOrder=1 and StageID<>'%'", True), gbUnicode)

        'Load tdbcPeriod
        LoadCboPeriodReport(tdbcPeriod, "D09", gsDivisionID)
        tdbcPeriod.SelectedValue = Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000")
        ReadOnlyControl(tdbcPeriod)

        'dtEmpID = ReturnDataTable(SQLStoreD45P5566)
        dtBlockID = ReturnTableBlockID(True, True, gbUnicode)
        LoadDataSource(tdbcBlockID, dtBlockID, gbUnicode)
        tdbcBlockID.SelectedIndex = 0
    End Sub

#Region "Events tdbcPeriod"
    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcStageID"
    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then tdbcStageID.Text = ""
    End Sub
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStageID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStageID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '************************
        ResetMenuCopy()
        Dim sValue As String = ReturnValueC1Combo(tdbc)
        If tdbc.Tag Is Nothing OrElse tdbc.Tag.ToString <> sValue Then
            ClearColumnsTag()
            LoadTDBDDEmployeeID()
            LoadTDBGrid()
            tdbc.Tag = sValue
        End If

    End Sub
#End Region
    Private Sub LoadTDBDDEmployeeID()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD45P5566)
        'Load tdbdEmployeeID
        LoadDataSource(tdbdEmployeeID, dt.DefaultView.ToTable, gbUnicode)
        'Load tdbdEmployeeName
        LoadDataSource(tdbdEmployeeName, dt.DefaultView.ToTable, gbUnicode)

    End Sub
    Private Sub SetLabled()
        lblProductPart.Text = rL3("Danh_sach_tieu_tac_san_pham_gop") & Space(1) & tdbg.Columns(COL_ProductAddName).Text 'Danh sách tiểu tác sản phẩm gộp
        lblQuantity.Text = rL3("San_luong_thuc_hien_tieu_tac") & Space(1) & tdbg1.Columns(COL1_PartProductName).Text 'Sản lượng thực hiện tiểu tác
    End Sub
    Private Sub ClearColumnsTag()
        tdbg.Columns(COL_ProductAddID).Tag = ""
        tdbg1.Columns(COL1_PartProductID).Tag = ""
        bKeyPress = False
    End Sub
    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2050()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_ProductAddName)
        '****************************
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            If dtGrid1 IsNot Nothing Then
                dtGrid1.Clear()
                ResetGrid1()
            End If
            If dtGrid2 IsNot Nothing Then
                dtGrid2.Clear()
                ResetGrid2()
            End If
        Else
            LoadTDBGrid2(tdbg.Columns(COL_ProductAddID).Text, "")
            LoadTDBGrid1(tdbg.Columns(COL_ProductAddID).Text)
        End If
    End Sub
    Private Sub LoadTDBGrid1(sProductAddID As String, Optional ByVal bPaste As Boolean = False, Optional ByVal sKey As String = "")
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        '************************
        tdbg.Columns(COL_ProductAddID).Tag = tdbg.Columns(COL_ProductAddID).Text
        '************************
        Dim sSQL As String = SQLStoreD45P2052(sProductAddID)
        dtGrid1 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        ResetGrid1()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid1.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("PartProductID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg1.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg1.Focused Then tdbg1.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        '****************************
        LoadTDBGrid2(IIf(bPaste, sProductAddID, "").ToString, tdbg1.Columns(COL1_PartProductID).Text)
        'End If
    End Sub

    Private Sub ResetGrid1()
        UpdateTDBGOrderNum(tdbg1, IndexOfColumn(tdbg1, COL1_OrderNum))
        FooterTotalGrid(tdbg1, COL1_PartProductName)
        FooterSumNew(tdbg1, COL1_PPNorm)
        msnCopy.Enabled = tdbg1.RowCount > 1
    End Sub
    Private Sub LoadTDBGrid2(sProductAddID As String, sPartProductID As String)
        If dtGrid1 Is Nothing AndAlso sProductAddID = "" Then Exit Sub 'Chưa đổ nguồn cho lưới
        '************************
        tdbg1.Columns(COL1_PartProductID).Tag = tdbg1.Columns(COL1_PartProductID).Text
        '************************
        If sProductAddID <> "" Then 'Load lại dữ liệu dưới server của lưới sản phẩm
            ClearColumnsTag()
            Dim sSQL As String = SQLStoreD45P2053(sProductAddID)
            dtGrid2 = ReturnDataTable(sSQL)
        End If
        If sPartProductID <> "" Then
            'dtGrid2 = ReturnTableFilter(dtDataGrid2, COL1_PartProductID & " = " & SQLString(sPartProductID), True)
            dtGrid2.DefaultView.RowFilter = COL1_PartProductID & "='' or " & COL1_PartProductID & " is null Or " & COL1_PartProductID & " = " & SQLString(sPartProductID)
            LoadDataSource(tdbg2, dtGrid2, gbUnicode)
            ResetGrid2()
        End If
        '****************************
        ResetGrid2()
    End Sub
    Private Sub ResetGrid2()
        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        FooterSumNew(tdbg2, COL2_EmpQuantity, COL2_TotalTime, COL2_EmpAmount)
        '****************************
        tdbg2.AllowAddNew = tdbg.RowCount > 0 AndAlso tdbg1.RowCount > 0
        EnabledButton()
        '****************************
        SetLabled()
    End Sub
    Private Sub EnabledButton()
        btnAdd.Enabled = tdbg1.RowCount > 0
        btnSave.Enabled = tdbg1.RowCount > 0
        btnNotSave.Enabled = tdbg1.RowCount > 0
        btnCopy.Enabled = tdbg2.RowCount > 0
    End Sub

    Dim bChangeRow As Boolean = True 'ktra xem co duoc di chuyen qua dong khac k?
    Private Function AllowSave() As Boolean
        bChangeRow = False
        tdbg2.UpdateData()
        dtGrid2.AcceptChanges()
        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_EmployeeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg2.Columns(COL2_EmployeeID).Caption)
                tdbg2.Focus()
                tdbg2.SplitIndex = 0
                tdbg2.Col = IndexOfColumn(tdbg2, COL2_EmployeeID)
                tdbg2.Row = i  'findrowInGrid(tdbg2, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If tdbg2(i, COL2_EmployeeName).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg2.Columns(COL2_EmployeeName).Caption)
                tdbg2.Focus()
                tdbg2.SplitIndex = 0
                tdbg2.Col = IndexOfColumn(tdbg2, COL2_EmployeeName)
                tdbg2.Row = i  'findrowInGrid(tdbg2, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If Number(tdbg2(i, COL2_EmpQuantity)) = 0 Then
                D99C0008.MsgNotYetEnter(tdbg2.Columns(COL2_EmpQuantity).Caption)
                tdbg2.Focus()
                tdbg2.SplitIndex = 0
                tdbg2.Col = IndexOfColumn(tdbg2, COL2_EmpQuantity)
                tdbg2.Row = i  'findrowInGrid(tdbg2, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            '****************************
            For j As Integer = i + 1 To tdbg2.RowCount - 1
                If tdbg2(i, COL2_EmployeeID).ToString = tdbg2(j, COL2_EmployeeID).ToString Then
                    D99C0008.MsgL3(rL3("Ma_nhan_vien_da_ton_tai_tren_luoi_san_luong") & Space(1) & rL3("Ban_vui_long_kiem_tra_laiU"))
                    tdbg2.Focus()
                    tdbg2.SplitIndex = 0
                    tdbg2.Col = IndexOfColumn(tdbg2, COL2_EmployeeID)
                    tdbg2.Row = i  'findrowInGrid(tdbg2, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            Next
        Next
        If tdbg2.RowCount > 0 Then
            If Number(tdbg2.Columns(COL2_EmpQuantity).FooterText, tdbg2.Columns(COL2_EmpQuantity).NumberFormat) <> Number(tdbg.Columns(COL_SumQuantity).Text, tdbg.Columns(COL_SumQuantity).NumberFormat) Then
                D99C0008.MsgL3(rL3("Tong_san_luong_nhan_vien_thuc_hien_phai_bang_san_luong_cua_san_pham_gop_") & vbCrLf & rL3("Ban_vui_long_kiem_tra_laiU"))
                Return False
            End If
        End If
        bChangeRow = True
        Return True
    End Function
    Private Function AllowCopy() As Boolean
        If tdbg2.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg2.Focus()
            Return False
        End If
        If bKeyPress Then 'Tồn tại dòng chưa Lưu
            D99C0008.MsgL3(rL3("Ton_tai_dong_du_lieu_chua_duoc_luu_Ban_khong_duoc_thuc_hien_sao_chep"))
            Return False
        End If
        Return True
    End Function

#Region "Hàm tính toán"
    Private Sub CalTotalTime()
        tdbg2.Columns(COL2_TotalTime).Text = SQLNumber(Number(tdbg2.Columns(COL2_EmpQuantity).Text) * Number(tdbg1.Columns(COL1_PPNorm).Text), tdbg2.Columns(COL2_TotalTime).NumberFormat)
    End Sub
    Private Sub CalEmpAmount()
        tdbg2.Columns(COL2_EmpAmount).Text = SQLNumber(Number(tdbg2.Columns(COL2_TotalTime).Text) * Number(tdbg1.Columns(COL1_PPUnitPrice).Text), tdbg2.Columns(COL2_EmpAmount).NumberFormat)
    End Sub

    Private Sub CalTotalTimeNext(ByVal iRow As Integer)
        tdbg2(iRow, COL2_TotalTime) = SQLNumber(Number(tdbg2(iRow, COL2_EmpQuantity)) * Number(tdbg1.Columns(COL1_PPNorm).Text), tdbg2.Columns(COL2_TotalTime).NumberFormat)
    End Sub
    Private Sub CalEmpAmountNext(ByVal iRow As Integer)
        tdbg2(iRow, COL2_EmpAmount) = SQLNumber(Number(tdbg2(iRow, COL2_TotalTime)) * Number(tdbg1.Columns(COL1_PPUnitPrice).Text), tdbg2.Columns(COL2_EmpAmount).NumberFormat)
    End Sub
#End Region
    Private Function BeforeRowColChange() As Boolean
        If Not bKeyPress Then Return True 'Nếu lưới Sản lượng không có thay đổi dữ liệu thì không cần kiểm tra
        If AskMsgBeforeRowChange() Then
            bAskSave = False
            btnSave_Click(Nothing, Nothing)
            If bChangeRow = False Then Return False
        Else
            LoadTDBGrid2(tdbg(tdbg.Row, COL_ProductAddID).ToString, "") 'Chỉ đổ lại nguồn cho lưới sản phẩm chứ không Filter theo PartProductID
        End If
        Return True
    End Function

#Region "tdbg"
    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        If tdbg.Row = tdbg.DestinationRow Then Exit Sub
        If BeforeRowColChange() = False Then
            e.Cancel = True 'Nếu chưa lưu được thì vẫn đứng tại dòng hiện tại
            bKeyPress = True
        Else
            bKeyPress = False
        End If
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.Columns(COL_ProductAddID).Tag Is Nothing OrElse tdbg.Columns(COL_ProductAddID).Tag.ToString = "" _
            OrElse tdbg(tdbg.Row, COL_ProductAddID).ToString <> tdbg.Columns(COL_ProductAddID).Tag.ToString Then
            LoadTDBGrid2(tdbg.Columns(COL_ProductAddID).Text, "")
            LoadTDBGrid1(tdbg(tdbg.Row, COL_ProductAddID).ToString)
            tdbg.Columns(COL_ProductAddID).Tag = tdbg(tdbg.Row, COL_ProductAddID).ToString
        End If
        ResetMenuCopy()
    End Sub
#End Region

#Region "tdbg1"
    Private Sub tdbg1_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg1.BeforeRowColChange
        If tdbg1.Row = tdbg1.DestinationRow Then Exit Sub
        If BeforeRowColChange() = False Then
            e.Cancel = True 'Nếu chưa lưu được thì vẫn đứng tại dòng hiện tại
            bKeyPress = True
        Else
            bKeyPress = False
        End If
    End Sub
    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        If tdbg1.Columns(COL1_PartProductID).Tag Is Nothing OrElse tdbg1.Columns(COL1_PartProductID).Tag.ToString = "" _
            OrElse tdbg1(tdbg1.Row, COL1_PartProductID).ToString <> tdbg1.Columns(COL1_PartProductID).Tag.ToString Then
            LoadTDBGrid2("", tdbg1(tdbg1.Row, COL1_PartProductID).ToString)
            tdbg1.Columns(COL1_PartProductID).Tag = tdbg1(tdbg1.Row, COL1_PartProductID).ToString
        End If
        MultiSelectGrid(tdbg1)
        msnCopy.Enabled = tdbg2.RowCount > 0 And tdbg1.SelectedRows.Count = 1
    End Sub

    Private Sub MultiSelectGrid(ByVal tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim row As Integer = 0

        'Control key is pressed : Add or delete the row from selection depending on whether the row is in SelectedRows Collection
        If ((Control.ModifierKeys And Keys.Control) <> 0) AndAlso tdbgX.MultiSelect <> C1.Win.C1TrueDBGrid.MultiSelectEnum.None Then
            If tdbgX.SelectedRows.IndexOf(tdbgX.Row) > -1 Then

                tdbgX.SelectedRows.RemoveAt(tdbgX.SelectedRows.IndexOf(tdbgX.Row))
            Else
                tdbgX.SelectedRows.Add(tdbgX.Row)
            End If
        Else
            'Shift key is pressed : selects all rows between the first selected row in selected row collection and the currently clicked row: 
            If ((Control.ModifierKeys And Keys.Shift) <> 0) AndAlso tdbgX.MultiSelect <> C1.Win.C1TrueDBGrid.MultiSelectEnum.None Then
                If tdbgX.SelectedRows.Count <= 0 Then Exit Sub
                Dim SelRowStartindex As Integer = tdbgX.SelectedRows(0)
                tdbgX.SelectedRows.Clear()
                tdbgX.SelectedRows.Add(SelRowStartindex)

                If tdbgX.SelectedRows.Count > 0 Then
                    If tdbgX.SelectedRows(0) > tdbgX.Row Then
                        row = tdbgX.SelectedRows(0)
                        While row >= tdbgX.Row
                            If tdbgX.SelectedRows.IndexOf(row) > -1 Then
                                tdbgX.SelectedRows.RemoveAt(tdbgX.SelectedRows.IndexOf(row))
                            End If
                            tdbgX.SelectedRows.Add(row)
                            row += -1
                        End While
                    Else
                        For row = tdbgX.SelectedRows(0) To tdbgX.Row
                            If tdbgX.SelectedRows.IndexOf(row) > -1 Then
                                tdbgX.SelectedRows.RemoveAt(tdbgX.SelectedRows.IndexOf(row))
                            End If
                            tdbgX.SelectedRows.Add(row)
                        Next
                    End If
                End If
            Else
                tdbgX.SelectedRows.Clear()
                tdbgX.SelectedRows.Add(tdbgX.Row)
            End If
        End If
    End Sub

#End Region

#Region "tdbg2"
    Private Sub tdbg2_AfterDelete(sender As Object, e As EventArgs) Handles tdbg2.AfterDelete
        tdbg2.UpdateData()
        ResetGrid2()
        bKeyPress = True
        Application.DoEvents()
    End Sub
    Private Sub tdbg2_OnAddNew(sender As Object, e As EventArgs) Handles tdbg2.OnAddNew
        tdbg2.Columns(COL2_PartProductID).Text = tdbg1.Columns(COL1_PartProductID).Text
        If tdbg2.RowCount = 1 Then tdbg2.Columns(COL2_EmpQuantity).Value = L3Int(tdbg.Columns(COL_SumQuantity).Value) : GoTo 1 'tdbg.Columns(COL_SumQuantity).Text
        Dim iSum As Integer = 0
        For i As Integer = 0 To tdbg2.Row - 1
            iSum = iSum + L3Int(tdbg2(i, COL2_EmpQuantity))
        Next
        If iSum > L3Int(tdbg.Columns(COL_SumQuantity).Value) Then
            tdbg2.Columns(COL2_EmpQuantity).Value = 0
        Else
            tdbg2.Columns(COL2_EmpQuantity).Value = L3Int(tdbg.Columns(COL_SumQuantity).Value) - iSum
        End If
1:
        CalTotalTime()
        CalEmpAmount()
    End Sub
    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        tdbg2.UpdateData()
    End Sub
    Private Sub tdbg2_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case tdbg2.Columns(e.ColIndex).DataField
            Case COL2_EmployeeID, COL2_EmployeeName
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub
    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown

        Select Case tdbg2.Columns(e.ColIndex).DataField
            Case COL2_EmployeeID, COL2_EmployeeName
                tdbg2.Columns(COL2_IsEmpOutsideStage).Text = "0"
                If tdbg2.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg2.Columns(COL2_EmployeeName).Text = ""
                    tdbg2.Columns(COL2_DepartmentID).Text = ""
                    tdbg2.Columns(COL2_DepartmentName).Text = ""
                    tdbg2.Columns(COL2_TeamID).Text = ""
                    tdbg2.Columns(COL2_TeamName).Text = ""
                    Exit Select
                End If
                '************
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg2.Columns(e.ColIndex).DropDown
                tdbg2.Columns(COL2_EmployeeID).Text = tdbd.Columns("EmployeeID").Text
                tdbg2.Columns(COL2_EmployeeName).Text = tdbd.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_DepartmentID).Text = tdbd.Columns("DepartmentID").Text
                tdbg2.Columns(COL2_DepartmentName).Text = tdbd.Columns("DepartmentName").Text
                tdbg2.Columns(COL2_TeamID).Text = tdbd.Columns("TeamID").Text
                tdbg2.Columns(COL2_TeamName).Text = tdbd.Columns("TeamName").Text
                tdbg2.Columns(COL2_IsEmpOutsideStage).Text = tdbd.Columns("IsEmpOutsideStage").Text
            Case COL2_EmpQuantity

                'If tdbg2.Row <> tdbg2.RowCount - 1 Then
                '    For i As Integer = tdbg2.Row + 1 To tdbg2.RowCount - 1
                '        tdbg2(i, COL2_EmpQuantity) = 0
                '        tdbg2(i, COL2_TotalTime) = 0
                '        tdbg2(i, COL2_EmpAmount) = 0
                '    Next
                'End If
                'If L3Int(tdbg2.Columns(COL2_EmpQuantity).Value) > L3Int(tdbg.Columns(COL_SumQuantity).Value) Then
                '    tdbg2.Columns(COL2_EmpQuantity).Value = 0
                'Else
                '    Dim iSum As Integer = 0
                '    For i As Integer = 0 To tdbg2.RowCount - 1
                '        iSum = iSum + L3Int(tdbg2(i, COL2_EmpQuantity))
                '    Next
                '    If iSum > L3Int(tdbg.Columns(COL_SumQuantity).Value) Then
                '        tdbg2.Columns(COL2_EmpQuantity).Value = 0
                '    End If
                'End If


                CalTotalTime()
                CalEmpAmount()

                'ID 90538 07.09.2016
                If tdbg2.RowCount < 1 Then GoTo 1

                Dim iRow As Integer = 0
                Dim iSum As Double = 0

                For i As Integer = 0 To tdbg2.RowCount - 1
                    iSum = iSum + Number(tdbg2(i, COL2_EmpQuantity))
                Next

                tdbg2.UpdateData()

                For i As Integer = 0 To tdbg2.RowCount - 1
                    If Number(tdbg2(i, COL2_EmpQuantity)) = 0 Then
                        If Number(tdbg.Columns(COL_SumQuantity).Value) > iSum Then
                            tdbg2(i, COL2_EmpQuantity) = Number(tdbg.Columns(COL_SumQuantity).Value) - iSum
                            iRow = i

                            Exit For
                        End If
                    End If
                Next

                CalTotalTimeNext(iRow)
                CalEmpAmountNext(iRow)

        End Select

      
1:
        tdbg2.UpdateData()
        ResetGrid2()
        bKeyPress = True
        Application.DoEvents()
    End Sub
    'Private Sub tdbg2_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg2.FetchCellStyle
    'Select Case tdbg2.Columns(e.Col).DataField
    '    Case COL2_EmployeeID, COL2_EmployeeName
    '        If L3Bool(tdbg2(e.Row, COL2_IsEmpOutsideStage)) Then
    '            e.CellStyle.Locked = True
    '            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '        End If
    'End Select
    'End Sub
    'Private Sub tdbg2_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg2.RowColChange
    '    Select Case tdbg2.Columns(tdbg2.Col).DataField
    '        Case COL2_EmployeeID, COL2_EmployeeName
    '            tdbg2.Splits(0).DisplayColumns(tdbg2.Col).Button = Not L3Bool(tdbg2(tdbg2.Row, COL2_IsEmpOutsideStage))
    '            Application.DoEvents()
    '            tdbg2.UpdateData()
    '    End Select
    'End Sub
#End Region

#Region "Button"
    Dim bAskSave As Boolean = True 'Kiểm tra xem có hỏi khi nhấn Lưu không
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Chỉ hỏi trước khi lưu khi nhấn nút Lưu
        If bAskSave Then
            If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Else
            bAskSave = True
        End If
        SaveData(sender)
    End Sub
    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadTDBGrid2(tdbg.Columns(COL_ProductAddID).Text, tdbg1.Columns(COL1_PartProductID).Text)
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnAdd.Focus()
        If btnAdd.Focused = False Then Exit Sub
        '*********************
        Dim f As New D45F2052
        With f
            .DepartmentID = ReturnValueC1Combo(tdbcStageID, "DepartmentID")
            .TeamID = ReturnValueC1Combo(tdbcStageID, "TeamID")
            .ShowDialog()
            If .dtD45F2052 IsNot Nothing Then
                Dim iRow As Integer = tdbg2.RowCount
                dtGrid2.Merge(.dtD45F2052)
                '**************************
                For i As Integer = iRow To tdbg2.RowCount - 1
                    tdbg2(i, COL2_PartProductID) = tdbg1.Columns(COL1_PartProductID).Text
                Next
                dtGrid2.AcceptChanges()
                tdbg2.UpdateData()
                ResetGrid2()
                bKeyPress = True
            End If
            .Dispose()
        End With
    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        btnCopy.Focus()
        If btnCopy.Focused = False Then Exit Sub
        If AllowCopy() = False Then Exit Sub
        '*********************
        Dim f As New D45F2051
        With f
            .ProductAddID = tdbg.Columns(COL_ProductAddID).Text
            .PartProductID = tdbg1.Columns(COL1_PartProductID).Text
            .PartProductName = tdbg1.Columns(COL1_PartProductName).Text
            .SumQuantity = Number(tdbg.Columns(COL_SumQuantity).Text)
            .dtGrid = CType(tdbg1.DataSource, DataTable).DefaultView.ToTable
            .dtDataDetail = dtGrid2.DefaultView.ToTable
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid2(tdbg(tdbg.Row, COL_ProductAddID).ToString, tdbg1.Columns(COL1_PartProductID).Text)
                LoadTDBGrid1(tdbg.Columns(COL_ProductAddID).Text, True, L3String(tdbg1(tdbg1.SelectedRows(tdbg1.SelectedRows.Count - 1), COL1_PartProductID)))
            End If
         
            .Dispose()
        End With
    End Sub
#End Region
    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T2050.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T2050s.ToString)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bKeyPress = False
            ClearColumnsTag()
            LoadTDBGrid1(tdbg(tdbg.Row, COL_ProductAddID).ToString, , tdbg1.Columns(COL1_PartProductID).Text)
            ResetMenuCopy()
        Else
            SaveNotOK()
            Return False
        End If
        Me.Cursor = Cursors.Default
        Return True
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
    '# Title: SQLStoreD45P5566
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 10:58:08
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD45P5566() As String
    '    Dim sSQL As String = ""
    '    sSQL &= ("-- Do nguon  MaNV, Ho va ten" & vbCrLf)
    '    sSQL &= "Exec D45P5566 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID, "DepartmentID")) & COMMA 'DepartmentID, varchar[50], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID, "TeamID")) & COMMA 'TeamID, varchar[50], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) 'BlockID, varchar[50], NOT NULL
    '    Return sSQL
    'End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD45P5566
    ''# Created User: KIMLONG
    ''# Created Date: 10/08/2016 03:20:35
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD45P5566() As String
    '    Dim sSQL As String = ""
    '    sSQL &= ("-- -- Do nguon  MaNV, Ho va ten" & vbCrlf)
    '    sSQL &= "Exec D45P5566 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID, "DepartmentID")) & COMMA 'DepartmentID, varchar[50], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID, "TeamID")) & COMMA 'TeamID, varchar[50], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
    '    sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA 'TranMonth, tinyint, NOT NULL
    '    sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) 'TranYear, int, NOT NULL
    '    Return sSQL
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5566
    '# Created User: KIMLONG
    '# Created Date: 28/12/2016 11:35:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5566() As String
        Dim sSQL As String = ""
        sSQL &= ("--  Do nguon  MaNV, Ho va ten" & vbCrlf)
        sSQL &= "Exec D45P5566 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID)) & COMMA 'StageID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) 'TranYear, int, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: KIMLONG
    '# Created Date: 20/06/2016 09:54:44
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- DELETE D09T6666  " & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: KIMLONG
    '# Created Date: 20/06/2016 10:50:14
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.SelectedRows.Count - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- -- Insert bang tam cac tieu tac can dan" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, " & vbCrLf)
            sSQL.Append("Key04ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_ProductAddID).Text) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg1(tdbg1.SelectedRows(i), COL1_PartProductID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg1(tdbg1.SelectedRows(i), COL1_PPUnitPrice)) & COMMA & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg1(tdbg1.SelectedRows(i), COL1_PPNorm)) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2054
    '# Created User: KIMLONG
    '# Created Date: 20/06/2016 10:41:06
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2054() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Store xu ly dan nhan vien cho cac tieu tac" & vbCrLf)
        sSQL &= "Exec D45P2054 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(sArrCopy(0)) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLString(sArrCopy(1)) 'CopyPartProductID, varchar[50], NOT NULL
        Return sSQL
    End Function




    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2050
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 11:19:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2050() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luoi san pham gop" & vbCrLf)
        sSQL &= "Exec D45P2050 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID)) 'StageID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2052
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 11:20:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2052(sProductAddID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luoi tieu tac" & vbCrLf)
        sSQL &= "Exec D45P2052 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(sProductAddID) 'ProductAddID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2053
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 11:22:59
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2053(sProductAddID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luoi san luong" & vbCrLf)
        sSQL &= "Exec D45P2053 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(sProductAddID) 'ProductAddID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2050
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 01:16:56
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2050() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu truoc khi luu" & vbCrLf)
        sSQL &= "Delete From D45T2050"
        sSQL &= " Where  TranMonth =" & giTranMonth & " AND TranYear = " & giTranYear
        sSQL &= " AND PartProductID  = " & SQLString(tdbg1.Columns(COL1_PartProductID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2050s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 01:19:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2050s() As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sEmpPartProductID As String = ""
        Dim iFirstTrans As Long = 0
        Dim iCountIGE As Integer = 0
        Dim dtSourceGrid As DataTable = CType(tdbg2.DataSource, DataTable)
        iCountIGE = dtSourceGrid.Select(COL2_EmpPartProductID & "='' or " & COL2_EmpPartProductID & " is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg2.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert can doi san pham" & vbCrLf)
            If tdbg2(i, COL2_EmpPartProductID).ToString = "" Then
                sEmpPartProductID = CreateIGENewS("D45T2050", "EmpPartProductID", "45", "EP", gsStringKey, sEmpPartProductID, iCountIGE, iFirstTrans)
                tdbg2(i, COL2_EmpPartProductID) = sEmpPartProductID
            End If
            sSQL.Append("Insert Into D45T2050(")
            sSQL.Append("EmpPartProductID, ProductAddID, PartProductID, EmployeeID, DepartmentID, " & vbCrLf)
            sSQL.Append("TeamID, EmpQuantity, TotalTime, UnitPrice, EmpAmount, " & vbCrLf)
            sSQL.Append("TranMonth, TranYear, IsEmpOutsideStage")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(tdbg2(i, COL2_EmpPartProductID)) & COMMA) 'EmpPartProductID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_ProductAddID).Text) & COMMA) 'ProductAddID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1.Columns(COL1_PartProductID).Text) & COMMA) 'PartProductID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_DepartmentID)) & COMMA & vbCrLf) 'DepartmentID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg2(i, COL2_TeamID)) & COMMA) 'TeamID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg2(i, COL2_EmpQuantity)) & COMMA) 'EmpQuantity, int, NOT NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_TotalTime), tdbg2.Columns(COL2_TotalTime).NumberFormat) & COMMA) 'TotalTime, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg1.Columns(COL1_PPUnitPrice).Text, tdbg1.Columns(COL1_PPUnitPrice).NumberFormat) & COMMA & vbCrLf) 'UnitPrice, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_EmpAmount), tdbg2.Columns(COL2_EmpAmount).NumberFormat) & COMMA) 'EmpAmount, decimal, NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
            sSQL.Append(SQLNumber(tdbg2(i, COL2_IsEmpOutsideStage)) & vbCrLf) 'IsEmpOutsideStage, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    'id 86641 20.06.2016
    Dim sSTT As String = ""
    Dim sArrCopy() As String = Nothing
    Private Sub msnCopy_Click(sender As Object, e As EventArgs) Handles msnCopy.Click
        sSTT = tdbg1.Columns(COL1_OrderNum).Text
        sArrCopy = {tdbg.Columns(COL_ProductAddID).Text, tdbg1.Columns(COL1_PartProductID).Text, tdbg1.Columns(COL1_PPUnitPrice).Text, tdbg1.Columns(COL1_PPNorm).Text}
        msnPaste.Enabled = True
        tdbg1.Refresh()
    End Sub

    Private Sub tdbg1_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg1.FetchRowStyle
        If L3Int(tdbg1(e.Row, COL1_IsEntered)) = 1 Then
            e.CellStyle.ForeColor = Color.Blue
        End If
        If L3String(tdbg1(e.Row, COL1_OrderNum)) = sSTT Then
            e.CellStyle.ForeColor = Color.Gray
        End If

    End Sub

    'id 86641 20.06.2016
    Private Sub msnPaste_Click(sender As Object, e As EventArgs) Handles msnPaste.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s().ToString & vbCrLf)
        sSQL.Append(SQLStoreD45P2054() & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666())
        Dim bRunSql As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSql Then
            LoadTDBGrid1(tdbg.Columns(COL_ProductAddID).Text, True, L3String(tdbg1(tdbg1.SelectedRows(tdbg1.SelectedRows.Count - 1), COL1_PartProductID))) 'Focus vao dong cuoi cùng chon sao chep
            ResetMenuCopy()
            msnPaste.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ResetMenuCopy()
        sSTT = ""
        msnPaste.Enabled = False
        tdbg1.Refresh()
    End Sub

    Private Sub tdbg1_SelChange(sender As Object, e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg1.SelChange
        e.Cancel = True
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If ReturnValueC1Combo(tdbcBlockID) = "%" Then
            LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "StageID<>'%'", True), gbUnicode)
        Else
            LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "BlockID=" & SQLString(ReturnValueC1Combo(tdbcBlockID)), True), gbUnicode)
        End If

    End Sub

    Private Sub tdbcBlockID_Validated(sender As Object, e As EventArgs) Handles tdbcBlockID.Validated
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcStageID.Text = ""
        End If
        If dtGrid IsNot Nothing Then dtGrid.Clear()
        If dtGrid1 IsNot Nothing Then dtGrid1.Clear()
        If dtGrid2 IsNot Nothing Then dtGrid2.Clear()

    End Sub


    Private Sub msnDeleteE_Click(sender As Object, e As EventArgs) Handles msnDeleteE.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not CheckStore(SQLStoreD54P5555(2, "DeleteProject")) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T2050() & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg2, dtGrid2, gbEnabledUseFind)
            ResetGrid2()
            LoadTDBGrid2(tdbg.Columns(COL_ProductAddID).Text, tdbg1.Columns(COL1_PartProductID).Text)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tdbg2_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg2.RowColChange

        If Not bDeleteCol Then MultiSelectGrid(tdbg2)
        bDeleteCol = False
    End Sub

    Dim bDeleteCol As Boolean = False
    Private Sub tdbg2_KeyDown(sender As Object, e As KeyEventArgs) Handles tdbg2.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim arr() As String = Nothing
            For i As Integer = 0 To tdbg2.SelectedRows.Count - 1
                ReDim Preserve arr(i)
                arr(i) = tdbg2(tdbg2.SelectedRows(i), COL2_EmpPartProductID).ToString
            Next
            If arr Is Nothing OrElse arr(0) = "" Then Exit Sub
            For j As Integer = 0 To arr.Length - 1
                Dim dr() As DataRow = dtGrid2.Select("EmpPartProductID=" & SQLString(arr(j).ToString))
                If dr.Length > 0 Then
                    dtGrid2.Rows.Remove(dr(0))
                    bDeleteCol = True
                End If
            Next
            ResetGrid2()
            bKeyPress = True
        End If
    End Sub

    Private Sub tdbg2_SelChange(sender As Object, e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg2.SelChange
        e.Cancel = True
    End Sub

    Private Sub D45F2050_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If bKeyPress Then
            'Nếu lưới Sản lượng không có thay đổi dữ liệu thì không cần kiểm tra
            If AskMsgBeforeRowChange() Then
                bAskSave = False
                btnSave.Focus()
                btnSave_Click(Nothing, Nothing)
                e.Cancel = True
            End If
        End If
    End Sub


End Class