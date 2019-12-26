﻿'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 3:28:25 PM
'# Created User: Nguyễn Thị Ánh
'# Modify Date: 08/05/2007 3:28:25 PM
'# Modify User: Nguyễn Thị Ánh
'#-------------------------------------------------------------------------------------
Public Class D45F2000
	Dim report As D99C2003
	Private _formIDPermission As String = "D45F2000"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg - Total of Columns: 37"
    Private Const COL_OrderNo As Integer = 0          ' STT
    Private Const COL_ProductVoucherID As Integer = 1  ' Mã phiếu
    Private Const COL_VoucherDate As Integer = 2       ' Ngày phiếu
    Private Const COL_ProductVoucherNo As Integer = 3  ' Số phiếu
    Private Const COL_Note As Integer = 4              ' Diễn giải
    Private Const COL_PayrollVoucherNo As Integer = 5  ' Hồ sơ lương
    Private Const COL_BlockID As Integer = 6           ' Mã khối
    Private Const COL_DepartmentID As Integer = 7      ' Mã phòng ban
    Private Const COL_TeamID As Integer = 8            ' Mã tổ nhóm
    Private Const COL_EmployeeID As Integer = 9        ' Mã nhân viên
    Private Const COL_MethodName As Integer = 10       ' Phương pháp chấm công
    Private Const COL_IsSpec As Integer = 11           ' Quy cách
    Private Const COL_CreateUserID As Integer = 12     ' CreateUserID
    Private Const COL_CreateDate As Integer = 13       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 14 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 15   ' LastModifyDate
    Private Const COL_DateFrom As Integer = 16         ' DateFrom
    Private Const COL_DateTo As Integer = 17           ' DateTo
    Private Const COL_TransTypeID As Integer = 18      ' TransTypeID
    Private Const COL_TransDAGroupID As Integer = 19   ' TransDAGroupID
    Private Const COL_PreparerID As Integer = 20       ' PreparerID
    Private Const COL_ProductID As Integer = 21        ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 22      ' Tên sản phẩm
    Private Const COL_StageID As Integer = 23          ' Mã công đoạn
    Private Const COL_StageName As Integer = 24        ' Tên công đoạn
    Private Const COL_RefEmployeeID As Integer = 25    ' Mã nhân viên phụ
    Private Const COL_EmployeeID1 As Integer = 26       ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 27     ' Họ và tên
    Private Const COL_DepartmentID1 As Integer = 28     ' Mã phòng ban
    Private Const COL_TeamID1 As Integer = 29           ' Mã tổ nhóm
    Private Const COL_Quantity01 As Integer = 30       ' Số lượng 01
    Private Const COL_Quantity02 As Integer = 31       ' Số lượng 02
    Private Const COL_Quantity03 As Integer = 32       ' Số lượng 03
    Private Const COL_Quantity04 As Integer = 33       ' Số lượng 04
    Private Const COL_Quantity05 As Integer = 34       ' Số lượng 05
    Private Const COL_PayrollVoucherID As Integer = 35 ' PayrollVoucherID
    Private Const COL_Method As Integer = 36           ' Method
#End Region



    Dim dtFind, dtCaption, dtCaptionCols As DataTable
    'Dim snewProductVoucherID As String = ""
    Dim iPermision As Integer = -1

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grp1, txtProductID, txtStageID, txtRefEmployeeID, txtEmployeeID)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnCalSalary)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F2000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg, 0, COL_OrderNo)
        End If
    End Sub

    Private Sub D45F2000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        'gsLanguage = "01"
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        iPermision = ReturnPermission("D45F2000")
        SetShortcutPopupMenu(C1CommandHolder)
        Loadlanguage()
        tdbg_NumberFormat()
        ResetColorGrid(tdbg, 0, 0)
        CreateTableCaptionQuantity()
        LoadTDBCombo()

        LoadDefault()



        '*********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo, txtVoucherNo.MaxLength)
        CheckIdTextBox(txtProductID, txtProductID.MaxLength)
        CheckIdTextBox(txtStageID, txtStageID.MaxLength)
        CheckIdTextBox(txtRefEmployeeID, txtRefEmployeeID.MaxLength)
        CheckIdTextBox(txtEmployeeID, txtEmployeeID.MaxLength)
        '*********************
        InputDateCustomFormat(c1dateVoucherDateTo, c1dateVoucherDateFrom)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub




    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Danh_sach_phieu_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh sÀch phiÕu thçng k£ s¶n phÈm tÛnh l§¥ng
        'Me.Text = rl3("Danh_sach_phieu_cham_cong_-_D45F2000") & UnicodeCaption(gbUnicode) 'Danh sÀch phiÕu chÊm c¤ng - D45F2000
        '================================================================ 
        lblVoucherNo.Text = rl3("So_phieu")  'Số phiếu 
        lblPreparerID.Text = rl3("Nguoi_lap") 'Người lập
        lblProductID.Text = rl3("Ma_san_pham") 'Mã sản phẩm 
        lblStageID.Text = rl3("Ma_cong_doan")  'Mã công đoạn
        lblRefEmployeeID.Text = rl3("Ma_nhan_vien_phu")   'Mã nhân viên phụ 
        lblEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên 
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnCalSalary.Text = rl3("Tinh_luon_g") 'Tính lươn&g
        '================================================================ 
        chkVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        chkViewDetail.Text = rl3("Hien_thi_du_lieu_chi_tiet") 'Hiển thị dữ liệu chi tiết
        '================================================================ 
        tdbcPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNo).Caption = rl3("STT") 'STT
        'tdbg.Columns("ProductVoucherID").Caption = rl3("Ma_phieu") 'Mã phiếu
        'tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        'tdbg.Columns("ProductVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        'tdbg.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        'tdbg.Columns("PayrollVoucherNo").Caption = rl3("Ho_so_luong") 'Hồ sơ lương
        'tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Phòng ban
        'tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Tổ nhóm
        'tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Nhân viên
        'tdbg.Columns("MethodName").Caption = rl3("Phuong_phap_cham_cong") 'Phương pháp chấm công
        'tdbg.Columns("IsSpec").Caption = rl3("Quy_cachU") 'Quy cách
        'tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        'tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        'tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        'tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn
        'tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_nhan_vien_phu") 'Mã NV phụ
        'tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã NV
        'tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Tên nhân viên
        'tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Phòng ban
        'tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Tổ nhóm
        '================================================================ 

        '================================================================ 
        tdbg.Columns(COL_ProductVoucherID).Caption = rL3("Ma_phieu") 'Mã phiếu
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns(COL_ProductVoucherNo).Caption = rL3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_Note).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_PayrollVoucherNo).Caption = rL3("Ho_so_luong") 'Hồ sơ lương
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_MethodName).Caption = rL3("Phuong_phap_cham_cong") 'Phương pháp chấm công
        tdbg.Columns(COL_IsSpec).Caption = rL3("Quy_cachU") 'Quy cách
        tdbg.Columns(COL_ProductID).Caption = rL3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rL3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns(COL_StageID).Caption = rL3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns(COL_StageName).Caption = rL3("Ten_cong_doan") 'Tên công đoạn
        tdbg.Columns(COL_RefEmployeeID).Caption = rL3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        tdbg.Columns(COL_EmployeeID1).Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_DepartmentID1).Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_TeamID1).Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
       

        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
        mnuAttendance.Text = rl3("Cham_con_g") 'Chấm côn&g
        mnuInherit.Text = rl3("Ke_thu_a") 'Kế thừa
        mnuAdjust.Text = rl3("Die_u_chinh_phieu") 'Điề&u chỉnh phiếu
        mnuExportToExcel.Text = rl3("Xuat__Excel") 'Xuất &Excel
        mnuImportData.Text = rl3("Import__du_lieu") 'Import &dữ liệu
        mnuImportEmployee.Text = rl3("Theo_nhan_vien_U") 'Theo nhân viên
        mnuImportDepartment.Text = rL3("Theo_phong_ban_to_nhom") 'Theo phòng ban tổ nhóm

        '================================================================ 
      
        tdbg.Columns(COL_BlockID).Caption = rL3("Ma_khoi") 'Mã khối

    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPreparerID
        LoadCboCreateBy(tdbcPreparerID, gbUnicode)
    End Sub

#Region "Events tdbcPreparerID"

    Private Sub tdbcPreparerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.LostFocus
        If tdbcPreparerID.FindStringExact(tdbcPreparerID.Text) = -1 Then tdbcPreparerID.Text = ""
    End Sub
#End Region

    Private Sub CreateTableCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled" & vbCrLf
        sSQL &= "From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        dtCaption = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadCaptionQuantity()
        If dtCaption.Rows.Count > 0 Then
            'For i As Integer = 0 To dtCaption.Rows.Count - 1
            For i As Integer = 0 To 4
                'tdbg.Splits(1).DisplayColumns(COL_Quantity01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                'tdbg.Columns(COL_Quantity01 + i).Caption = dtCaption.Rows(i).Item("ShortName").ToString
                'tdbg.Splits(1).DisplayColumns(COL_Quantity01 + i).Visible = Not CBool(dtCaption.Rows(i).Item("Disabled"))
                tdbg.Splits(1).DisplayColumns("Quantity0" + (i + 1).ToString).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns("Quantity0" + (i + 1).ToString).Caption = dtCaption.Rows(i).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns("Quantity0" + (i + 1).ToString).Visible = Not CBool(dtCaption.Rows(i).Item("Disabled"))
            Next
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P2003()
        dtFind = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtFind, gbUnicode)

        If sKey <> "" Then
            Dim dt1 As DataTable = dtFind.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("ProductVoucherID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        End If

        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        If chkViewDetail.Checked Then
            FooterTotalGrid(tdbg, COL_ProductID)
            tdbg.ColumnFooters = True
        Else
            tdbg.Columns(COL_ProductID).FooterText = ""
            tdbg.ColumnFooters = False
        End If

        CheckMenuOther()


    End Sub

    Private Sub LoadDefault()
        c1dateVoucherDateFrom.Enabled = False
        c1dateVoucherDateTo.Enabled = False
        c1dateVoucherDateFrom.Value = Date.Today
        c1dateVoucherDateTo.Value = Date.Today

        'ID 91533 13.10.2016
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = CheckVisibleBlockID()

        CheckMenuOther()
        btnCalSalary.Enabled = iPermision > 0 And Not gbClosed
    End Sub

    Private Sub CheckMenuOther()
        CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True, , "D45F5603")
        mnuAttendance.Enabled = tdbg.RowCount > 0 And Not gbClosed
        mnuAdjust.Enabled = tdbg.RowCount > 0 And Not gbClosed
        mnuInherit.Enabled = iPermision > 1 And (tdbg.RowCount > 0) And Not gbClosed
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim f As New D45F2001
        With f
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bFlagSave Then
                LoadTDBGrid(.ProductVoucherID)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim f As New D45F2001
        f.ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        If Not AllowEdit() Then Exit Sub

        Dim f As New D45F2001
        f.ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        If f.bFlagSave Then
            LoadTDBGrid(tdbg.Columns(COL_ProductVoucherID).Text)
        End If
        f.Dispose()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/05/2007 02:23:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2000() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2000"
        sSQL &= " Where "
        sSQL &= "ProductVoucherID = " & SQLString(tdbg.Columns(COL_ProductVoucherID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2001
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/05/2007 02:23:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2001"
        sSQL &= " Where "
        sSQL &= "ProductVoucherID = " & SQLString(tdbg.Columns(COL_ProductVoucherID).Text)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2001
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/05/2007 02:23:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2002() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2002"
        sSQL &= " Where "
        sSQL &= "ProductVoucherID = " & SQLString(tdbg.Columns(COL_ProductVoucherID).Text)
        Return sSQL
    End Function

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub

        Dim sSQL As String = ""

        sSQL = SQLDeleteD45T2001() & vbCrLf
        sSQL &= SQLDeleteD45T2002() & vbCrLf
        sSQL &= SQLDeleteD45T2000()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            tdbg.Delete()
            dtFind.AcceptChanges()
            '****************************
            DeleteOK()
            'RunAuditLog(AuditCodePieceworkVouchers45, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_ProductVoucherNo).Text, tdbg.Columns(COL_PreparerID).Text, tdbg.Columns(COL_Note).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodePieceworkVouchers45, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_ProductVoucherNo).Text, tdbg.Columns(COL_PreparerID).Text, tdbg.Columns(COL_Note).Text)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub


    Private Sub mnuInherit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInherit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim f As New D45F2005
        With f
            .ShowDialog()
            If .bSaved Then LoadTDBGrid()
            .Dispose()
        End With
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            ElseIf mnuView.Enabled Then
                mnuView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNo 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2003
    '# Created User: 
    '# Created Date: 30/10/2008 10:28:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2003() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2003 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkVoucherDate.Checked) & COMMA 'IsVoucherDate, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Text) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Text) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcPreparerID.Text) & COMMA 'PreparerID, varchar[20], NOT NULL
        sSQL &= SQLString(txtProductID.Text) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= SQLString(txtStageID.Text) & COMMA 'StageID, varchar[20], NOT NULL
        sSQL &= SQLString(txtRefEmployeeID.Text) & COMMA 'RefEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkViewDetail.Checked) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, varchar[4000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowLoadGrid() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        HideSplit()
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowLoadGrid() As Boolean
        If chkVoucherDate.Checked Then
            If c1dateVoucherDateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
                c1dateVoucherDateTo.Focus()
            End If
            If c1dateVoucherDateFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
                c1dateVoucherDateFrom.Focus()
            End If

            If CDate(c1dateVoucherDateFrom.Text) > CDate(c1dateVoucherDateTo.Text) Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_phieu_khong_hop_le"))
                c1dateVoucherDateTo.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub HideSplit()
        Dim i As Integer = 0

        If chkViewDetail.Checked Then 'hien thi split 2
            If tdbg.Splits.Count = 1 Then
                tdbg.InsertHorizontalSplit(1)
                tdbg.Splits(1).RecordSelectors = False
                tdbg.Splits(1).BorderStyle = Border3DStyle.Flat

                tdbg.Splits(1).SplitSize = 2
                tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(0).SplitSize = 1
                tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable

                tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = False

                For i = COL_OrderNo To COL_PreparerID
                    tdbg.Splits(1).DisplayColumns(i).Visible = False
                Next

                For i = COL_ProductID To COL_TeamID1
                    tdbg.Splits(1).DisplayColumns(i).Visible = True
                Next

                LoadCaptionQuantity()
            End If
        Else
            If tdbg.Splits.Count >= 2 Then
                tdbg.RemoveHorizontalSplit(1)

                tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = True
            End If
        End If
    End Sub

    Private Sub txtProductID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductID.KeyDown
        If e.KeyCode = Keys.F2 Then
            Me.Cursor = Cursors.WaitCursor

            'Dim sKey As String = ""
            'Dim f As New D91F6010
            'With f
            '    .InListID = "75"
            '    .InWhere = ""
            '    .WhereValue = ""
            '    .ShowDialog()
            '    sKey = .OutPut01
            '    .Dispose()
            'End With

            'If sKey <> "" Then
            '    txtProductID.Text = sKey
            'End If

            Try
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "InListID", "75")
                SetProperties(arrPro, "InWhere", "")
                SetProperties(arrPro, "WhereValue", "")
                Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                Dim sKey As String = GetProperties(frm, "Output01").ToString
                If sKey <> "" Then
                    'Load dữ liệu
                    txtProductID.Text = sKey
                End If
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub chkVoucherDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVoucherDate.Click
        If chkVoucherDate.Checked Then
            c1dateVoucherDateFrom.Enabled = True
            c1dateVoucherDateTo.Enabled = True
        Else
            c1dateVoucherDateFrom.Enabled = False
            c1dateVoucherDateTo.Enabled = False
        End If
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim sReportName As String = ""
        Dim sReportPath As String = ""

        If chkViewDetail.Checked Then
            sReportName = GetReportPath("D45F3000_D", "D45R4030", "", sReportPath)
        Else
            sReportName = GetReportPath("D45F3000_M", "D45R4031", "", sReportPath)
        End If

        If sReportName = "" Then Exit Sub

        'Dim report As New D99C1003
		
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_cham_cong_san_pham") & " - " & sReportName

        sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(gsDivisionID)

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtFind.DefaultView.ToTable)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub mnuAdjust_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdjust.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Dim iBookmark As Integer = tdbg.Bookmark
        Dim frm As New D45F2006
        With frm

            .ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
            .EmployeeID = "%"
            .SalaryVoucherID = ""
            .Mode = 0
            If AllowAdjust() = False Then
                .FormState = EnumFormState.FormView
            Else
                .FormState = EnumFormState.FormEdit
            End If
            .ShowDialog()
            .Dispose()
        End With

        If frm.bSaved Then
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark
        End If

        Me.Cursor = Cursors.Default
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P0101
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 03/11/2009 04:20:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P0101(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P0101 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ProductVoucherID).Text) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'Form, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function

    Private Function AllowDelete() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P0101(1)
        AllowDelete = CheckStore(sSQL)
    End Function

    Private Function AllowEdit() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P0101(2)
        AllowEdit = CheckStore(sSQL)
    End Function

    Private Function AllowAdjust() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P0101(3)
        AllowAdjust = CheckStore(sSQL)
    End Function

    Private Sub btnCalSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalSalary.Click
        Dim f As New D45F2010
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnuAttendance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAttendance.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If tdbg.Columns(COL_Method).Text = "0" Then
            Dim sSQL As String
            sSQL = "Select PieceWorkMethod From D45T5550  WITH(NOLOCK) Where UserID=" & SQLString(gsUserID)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            Dim iType As Integer

            If dt.Rows.Count > 0 Then
                iType = L3Int(dt.Rows(0).Item("PieceWorkMethod").ToString)
            Else
                iType = 1
            End If

            If iType = 1 Then 'goi D45F2002
                Dim f As New D45F2002
                With f
                    If TestExist(tdbg.Columns(COL_ProductVoucherID).Text) OrElse AllowEdit() = False Then .FormState = EnumFormState.FormView

                    .ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
                    .ProductVoucherNo = tdbg.Columns(COL_ProductVoucherNo).Text
                    .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
                    .Note = tdbg.Columns(COL_Note).Text
                    .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                    .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                    .TeamID = tdbg.Columns(COL_TeamID).Text
                    .EmployeeID = "%"
                    .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
                    .IsSpec = L3Bool(tdbg.Columns(COL_IsSpec).Text)
                    .ShowDialog()
                    .Dispose()
                End With
            Else
                Dim f As New D45F2003 'goi D45F2003
                With f
                    .ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
                    .ProductVoucherNo = tdbg.Columns(COL_ProductVoucherNo).Text
                    .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
                    .Note = tdbg.Columns(COL_Note).Text
                    .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                    .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                    .TeamID = tdbg.Columns(COL_TeamID).Text
                    .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
                    .FromDate = tdbg.Columns(COL_DateFrom).Text
                    .ToDate = tdbg.Columns(COL_DateTo).Text
                    .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
                    If TestExist(tdbg.Columns(COL_ProductVoucherID).Text) OrElse AllowEdit() = False Then
                        .FormState = EnumFormState.FormView
                    End If
                    .ShowDialog()
                    .Dispose()
                End With
            End If

        ElseIf tdbg.Columns(COL_Method).Text = "1" OrElse tdbg.Columns(COL_Method).Text = "3" Then 'goi D45F2007
            Dim f As New D45F2007 'goi D45F2007
            With f
                .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                .ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
                .sMethod = tdbg.Columns(COL_Method).Text
                .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                .TeamID = tdbg.Columns(COL_TeamID).Text
                .BlockID = tdbg.Columns(COL_BlockID).Text
                .ProductVoucherNo = tdbg.Columns(COL_ProductVoucherNo).Text
                .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
                .IsVisibleEmployeeID = True
                .Mode = L3Byte(tdbg.Columns(COL_Method).Text)
                .IsSpec = L3Bool(tdbg.Columns(COL_IsSpec).Text)
                .Note = tdbg.Columns(COL_Note).Text
                If TestExist(tdbg.Columns(COL_ProductVoucherID).Text) OrElse AllowEdit() = False Then
                    .FormState = EnumFormState.FormView
                End If
                .ShowDialog()
                .Dispose()

            End With

        Else 'goi D45F2004
            Dim f As New D45F2004
            With f
                .ProductVoucherID = tdbg.Columns(COL_ProductVoucherID).Text
                .ProductVoucherNo = tdbg.Columns(COL_ProductVoucherNo).Text
                .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
                .Note = tdbg.Columns(COL_Note).Text
                .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                .TeamID = tdbg.Columns(COL_TeamID).Text
                .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
                If TestExist(tdbg.Columns(COL_ProductVoucherID).Text) OrElse AllowEdit() = False Then
                    .FormState = EnumFormState.FormView
                End If

                .ShowDialog()
                .Dispose()
            End With
        End If
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

    Dim ArrFieldExclude() As String = {"OrderNo"}

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList

        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode, ArrFieldExclude)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClauseClient.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        sFind = ""
        sFindServer = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        'LoadGridFind(tdbg, dtFind, sFind)
        dtFind.DefaultView.RowFilter = sFind
        ResetGrid()
    End Sub
#End Region

    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click

        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then 
        'và truyền đối số cuối cùng là False vào hàm AddColVisible

        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList

        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        '       Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        'dtCaptionCols.Rows.RemoveAt(0)
        CallShowD99F2222(Me, dtCaptionCols, dtFind, gsGroupColumns)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtFind
        '    .ShowDialog()
        '    .Dispose()
        'End With
        '*****************************************
    End Sub

    Private Sub mnuImportDepartment_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportDepartment.Click
        Me.Cursor = Cursors.WaitCursor
        '.bSaved = False
        'Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090("D45", "D45F5603", "D45F2000B") Then
            'Load lại dữ liệu
            LoadTDBGrid()
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5603"
        '    .ModuleID = "D45"
        '    .TransTypeID = "D45F2000B" 'Theo TL phân tích
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With

        'If .bSaved Then
        '    'Load lại dữ liệu
        '    LoadTDBGrid()
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuHorizontal_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuHorizontal.Click
        Me.Cursor = Cursors.WaitCursor
        '       .bSaved = False
        '       Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090("D45", "D45F5603", "D45F2000") Then
            'Load lại dữ liệu
            LoadTDBGrid()
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5603"
        '    .ModuleID = "D45"
        '    .TransTypeID = "D45F2000" 'Theo TL phân tích
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With

        'If .bSaved Then
        '    'Load lại dữ liệu
        '    LoadTDBGrid()
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuVertical_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuVertical.Click
        Me.Cursor = Cursors.WaitCursor
        '       .bSaved = False
        '       Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090("D45", "D45F5603", "D45F2000C") Then
            'Load lại dữ liệu
            LoadTDBGrid()
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5603"
        '    .ModuleID = "D45"
        '    .TransTypeID = "D45F2000C" 'Theo TL phân tích
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With

        'If .bSaved Then
        '    'Load lại dữ liệu
        '    LoadTDBGrid()
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function CheckVisibleBlockID() As Boolean
        Dim sSQL As String = "Select IsUseBlock From D09T0000 "
        Dim dtCheckE As DataTable = ReturnDataTable(sSQL)
        If dtCheckE.Rows.Count > 0 Then
            Return L3Bool(dtCheckE.Rows(0)("IsUseBlock").ToString)
        End If
        Return False
    End Function

End Class