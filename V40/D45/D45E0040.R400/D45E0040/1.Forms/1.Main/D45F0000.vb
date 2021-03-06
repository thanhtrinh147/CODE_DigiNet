'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:10:02 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 01/08/2006 4:10:02 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D45F0000

    Private Const D45P0030 As String = "\Bitmap\D45P0030.jpg"
    Private Const D45P0031 As String = "\Bitmap\D45P0031.jpg"

#Region "User Control D99U0000 (gồm 5 bước)"
    'UserControl D99U0000 dùng để hiển thị cây menu
    'Chuẩn hóa sử dụng D99U0000 cho form DxxF0000: gồm 5 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D99U0000 B" để tìm các bước chuẩn sử dụng D99U0000
    'Chuẩn hóa D99U0000 B1: đinh nghĩa biến
    Dim t As New D99U0000
#End Region

    Private Sub LoadStatusStrip()
        sbServerName.Text = gsServer.ToUpper
        sbCompany.Text = gsCompanyID.ToUpper
        sbUserID.Text = gsUserID.ToUpper
        sbCurrentDate.Text = Date.Now.ToShortDateString
    End Sub

    Private Sub LoadBitmap()
        If geLanguage = EnumLanguage.Vietnamese Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D45P0030) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D45P0030)
                picMain.BackgroundImage = bmp
            End If
        ElseIf geLanguage = EnumLanguage.English Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D45P0031) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D45P0031)
                picMain.BackgroundImage = bmp
            End If
        End If
    End Sub

    Private Sub LoadLanguage(Optional ByVal bLoadFirst As Boolean = False)
        LoadMenuShortcut()
        LoadBitmap()
        If bLoadFirst = False Then SetTextMenu(C1MainMenu)
    End Sub

    Private Sub LoadMenuShortcut()
        '================================================================ 
        'Phần chung của các module
        sbCompanyCaption.Text = rl3("Doanh_nghiep")
        sbUserIDCaption.Text = rl3("Nguoi_dung")
        '================================================================ 
        mnuSystem.Text = rl3("_He_thong")
        mnuTransaction.Text = rl3("_Nghiep_vu")
        mnuInquiry.Text = rl3("_Truy_van")
        mnuStatis.Text = rl3("Thong_ke_____Phan_tich") 'Thống kê && &Phân tích
        mnuReport.Text = rl3("_Bao_cao")
        mnuList.Text = rl3("_Danh_muc")
        mnuHelp.Text = rl3("Tro__giup")

        If geLanguage = EnumLanguage.Vietnamese Then
            mnuSystemLanguageVietnamese.Checked = True
            mnuSystemLanguageEnglish.Checked = False
        Else
            mnuSystemLanguageVietnamese.Checked = False
            mnuSystemLanguageEnglish.Checked = True
        End If
        '================================================================ 
        Me.Text = rl3("Luong_san_pham_-_D45F0000") 'L§¥ng s¶n phÈm - D45F0000
        '================================================================ 
     
        'Hệ thống
        mnuSystemSetup.Text = rL3("Thiet_lap_he_thong") 'Thiết lập hệ thống
        mnuSystemAutoIGEList.Text = rL3("Phuong_phap_tao_ma_tu_dong")
        mnuSystemSetupOther.Text = rl3("Thiet_lap_khac") ' Thiết lập khác
        mnuSystemUnitPrice.Text = rl3("Don_gia_So_luong") 'Đơn giá/ Số lượng
        mnuSystemProductSalary.Text = rl3("Dinh_nghia_cac_khoan_thu_nhap_luong_san_pham") 'Định nghĩa các khoản thu nhập lương sản phẩm
        mnuSystemOption.Text = rl3("Tuy_chon") 'Tùy chọn
        mnuSystemLanguage.Text = rl3("Ngon_ngu") 'Ngôn ngữ
        mnuSystemLanguageVietnamese.Text = rl3("Tieng_Viet") 'Tiếng Việt
        mnuSystemLanguageEnglish.Text = rl3("Tieng_Anh") 'Tiếng Anh
        mnuSystemQuit.Text = "&X  " & rl3("Thoat") 'Thoát

        'Nghiệp vụ
        mnuTransactionCheckProduct.Text = rL3("Thong_ke_san_pham_tinh_luong") 'rL3("Cham_cong_san_pham") 'Chấm công sản phẩm

        mnuTransactionCalProductSalary.Text = rl3("Tinh_luong_san_pham") 'Tính lương sản phẩm
        mnuTransactionCost.Text = rL3("Tinh_don_gia_gio_cong_he_so") 'Tính đơn giá giờ công hệ số
        mnuTransactionProductNorm.Text = rL3("Dinh_muc_ky_thuatU") 'Định mức kỹ thuật
        mnuTransactionBalancedProduct.Text = rL3("Can_doi_san_phamU") 'Cân đối sản phẩm
        mnuTransactionIncomeAdjustment.Text = rL3("Dieu_chinh_thu_nhap") 'Điều chỉnh thu nhập

        'Truy vấn
        mnuInquiryCheckProduct.Text = rL3("Thong_ke_san_pham_tinh_luong") ' rl3("Cham_cong_san_pham") 'Chấm công sản phẩm
        mnuInquiryCCSP.Text = rL3("Phieu_TKSPTL_chua_xu_ly") 'rl3("Phieu_CCSP_chua_xu_ly") 'Phiếu CCSP chưa xử lý
        mnuInquiryCost.Text = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số

        'Thống kê & Phân tích
        mnuStatisCalculateResult.Text = rl3("Ket_qua_tinh_luong") 'Kết quả tính lương

        'Báo cáo        
        mnuReportCheck.Text = rL3("Thong_ke_san_pham_tinh_luong") ' rl3("Cham_cong_san_pham") 'Chấm công sản phẩm
        mnuReportPriceList.Text = rl3("Bang_gia") 'Bảng giá
        mnuReportPayrollVoucher.Text = rl3("Phieu_luong_san_pham") 'Phiếu lương sản phẩm
        mnuReportCustomize.Text = rl3("Bao_cao_dac_thu") 'Báo cáo đặc thù
        mnuReportSetup.Text = rl3("Thiet_lap") 'Thiết lập
        mnuReportSetupPayroll.Text = rl3("Bang_luong_san_pham") 'Bảng lương sản phẩm
        mnuReportDefineReport.Text = rl3("Mau_bao_cao")

        'Danh mục
        mnuListProduct.Text = rl3("San_pham") 'Sản phẩm
        mnuListStep.Text = rL3("Cong_doan") 'Công đoạn
        mnuListMachineID.Text = rL3("May_san_xuat") 'Máy sản xuất
        mnuListPriceList.Text = rl3("Bang_gia") 'Bảng giá
        mnuListUnitID.Text = rl3("Don_vi_tinh") 'Đơn vị tính
        mnuListSpecifications.Text = rl3("Quy_cach_san_pham") 'Quy cách sản phẩm
        mnuListGroupProduct.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        mnuListPieceworkGroupID.Text = rl3("Nhom_cham_cong_san_pham") 'Nhóm nhân viên chấm công
        mnuListTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        mnuListProductRouting.Text = rl3("Quy_trinh_san_xuat_san_pham") 'Quy trình sản xuất sản phẩm
        mnuListSRouting.Text = rl3("Quy_trinh_san_xuat_chuan") 'Quy trình sản xuất chuẩn
        mnuListProductSalary.Text = rL3("Phuong_phap_tinh_luong_san_pham") 'Phương pháp tính lương sản phẩm
        mnuHACOEF.Text = rL3("Loai_nghiep_vu_tinh_don_gia_gio_cong_he_soU") 'Loại nghiệp vụ tính đơn giá giờ công hệ số
        mnuIncomeAdjust.Text = rL3("Khoan_dieu_chinh_thu_nhap")
        mnuListGroupPartProduct.Text = rL3("Nhom_tieu_tac") 'Nhóm tiểu tác
        mnuListComponentTask.Text = rL3("Cum_tieu_tac") 'Cụm tiểu tác 
        mnuListComponentSubTask.Text = rL3("Tieu_tac") 'Tiểu tác
        mnuListPriceSubTaskList.Text = rL3("Bang_gia_theo_tieu_tac") 'Bảng giá theo tiểu tác

        'Trợ giúp
        mnuHelpContent.Text = rl3("Noi_dung") 'Nội dung
        mnuHelpIndex.Text = rl3("Chi_muc") 'Chỉ mục
        'Kỳ kế toán
        mnuPeriod.Text = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        '**********************
        mnuStatisBalanceProductSalary.Text = rL3("Bao_cao_can_doi_luong_san_pham_")
        'mnuStatisBalanceProductSalary.Text = rL3("Kiem_tra_du_lieu_dau_vao")
    End Sub

    Private Sub VisibledMenu(ByVal mnu As C1.Win.C1Command.C1Command, ByVal FormPermission As Boolean)
        If mnu.Visible Then mnu.Visible = FormPermission 'kiểm tra giao diện có design nhưng set Visibled = False
    End Sub

    'Sub này không ảnh hưởng bởi biến gbClosed
    Private Sub SetMenuPermission()
        'Phân quyền cho menu Hệ thống
        VisibledMenu(mnuSystemSetup, ReturnPermission("D45F0001") >= EnumPermission.View)
        VisibledMenu(mnuSystemOption, ReturnPermission("D45F0002") >= EnumPermission.View)
        VisibledMenu(mnuSystemUnitPrice, ReturnPermission("D45F0010") >= EnumPermission.View)
        VisibledMenu(mnuSystemProductSalary, ReturnPermission("D45F0020") >= EnumPermission.View)
        VisibledMenu(mnuSystemNewPeriod, ReturnPermission("D45F5556") >= EnumPermission.View)
        VisibledMenu(mnuSystemNewPeriod, ReturnPermission("D45F0066") >= EnumPermission.View)
        VisibledMenu(mnuSystemAutoIGEList, ReturnPermission("D09F1600") >= EnumPermission.View)

        'mnu kỳ kế toán
        mnuPeriod.Enabled = ReturnPermission("D45F0003") >= EnumPermission.View

        'Phân quyền cho menu Truy vấn
        VisibledMenu(mnuInquiryCheckProduct, ReturnPermission("D45F2000") >= EnumPermission.View)
        VisibledMenu(mnuInquiryCCSP, ReturnPermission("D45F2020") >= EnumPermission.View)
        VisibledMenu(mnuInquiryCost, ReturnPermission("D45F2030") >= EnumPermission.View)
        VisibledMenu(mnuStatisCalculateResult, ReturnPermission("D45F3000") >= EnumPermission.View)
        'Phân quyền cho menu Báo cáo
        VisibledMenu(mnuReportCheck, ReturnPermission("D45F4000") >= EnumPermission.View)
        VisibledMenu(mnuReportPriceList, ReturnPermission("D45F4010") >= EnumPermission.View)
        VisibledMenu(mnuReportPayrollVoucher, ReturnPermission("D45F4020") >= EnumPermission.View)
        VisibledMenu(mnuReportCustomize, ReturnPermission("D45F9100") >= EnumPermission.View)
        VisibledMenu(mnuReportDefineReport, ReturnPermission("D45F9101") >= EnumPermission.View)
        VisibledMenu(mnuReportSetupPayroll, ReturnPermission("D45F4030") >= EnumPermission.View)
        VisibledMenu(mnuStatisBalanceProductSalary, ReturnPermission("D45F4040") >= EnumPermission.View)
        'Phân quyền cho menu Danh mục
        VisibledMenu(mnuListProduct, ReturnPermission("D45F1000") >= EnumPermission.View)
        VisibledMenu(mnuListStep, ReturnPermission("D45F1010") >= EnumPermission.View)
        VisibledMenu(mnuListMachineID, ReturnPermission("D45F1013") >= EnumPermission.View)
        VisibledMenu(mnuListUnitID, ReturnPermission("D45F5601") >= EnumPermission.View)
        VisibledMenu(mnuListPriceList, ReturnPermission("D45F1020") >= EnumPermission.View)
        VisibledMenu(mnuListSRouting, ReturnPermission("D45F1030") >= EnumPermission.View)
        VisibledMenu(mnuListTransTypeID, ReturnPermission("D45F1040") >= EnumPermission.View)
        VisibledMenu(mnuListPieceworkGroupID, ReturnPermission("D45F1050") >= EnumPermission.View)
        VisibledMenu(mnuListProductSalary, ReturnPermission("D45F1060") >= EnumPermission.View)
        VisibledMenu(mnuListGroupProduct, ReturnPermission("D45F1070") >= EnumPermission.View)
        VisibledMenu(mnuListProductRouting, ReturnPermission("D45F1080") >= EnumPermission.View)
        VisibledMenu(mnuListSpecifications, ReturnPermission("D45F1090") >= EnumPermission.View)
        VisibledMenu(mnuHACOEF, ReturnPermission("D45F1042") >= EnumPermission.View)
        VisibledMenu(mnuIncomeAdjust, ReturnPermission("D45F1003") >= EnumPermission.View)
        VisibledMenu(mnuListGroupPartProduct, ReturnPermission("D45F1095") >= EnumPermission.View)
        VisibledMenu(mnuListComponentTask, ReturnPermission("D45F1100") >= EnumPermission.View)
        VisibledMenu(mnuListComponentSubTask, ReturnPermission("D45F1120") >= EnumPermission.View)
        VisibledMenu(mnuListPriceSubTaskList, ReturnPermission("D45F1130") >= EnumPermission.View)
    End Sub

    Private Sub SetMenuPermissionTransaction()
        VisibledMenu(mnuTransactionCheckProduct, ReturnPermission("D45F2000") > EnumPermission.View)
        VisibledMenu(mnuTransactionCalProductSalary, ReturnPermission("D45F2010") >= EnumPermission.View)
        VisibledMenu(mnuTransactionCost, ReturnPermission("D45F2030") > EnumPermission.View)
        VisibledMenu(mnuTransactionProductNorm, ReturnPermission("D45F2040") > EnumPermission.View)
        VisibledMenu(mnuTransactionBalancedProduct, ReturnPermission("D45F2050") > EnumPermission.View)
        VisibledMenu(mnuTransactionIncomeAdjustment, ReturnPermission("D45F2060") >= EnumPermission.View)
    End Sub

    'Sub này có ảnh hưởng bởi biến gbClosed
    Private Sub SetEnableMenuPermissionTransaction()
        'Phân quyền cho menu Hệ thống phụ thuộc vào biến gbClosed
        mnuSystemCloseBook.Enabled = Not gbClosed
        mnuSystemOpenBook.Enabled = gbClosed

        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        'mnuTransactionxxxxx.Enabled = (Not gbClosed) And ReturnPermission("D15Fxxxx") > EnumPermission.View
        mnuTransactionCheckProduct.Enabled = (Not gbClosed)
        mnuTransactionCalProductSalary.Enabled = (Not gbClosed)
        mnuTransactionCost.Enabled = (Not gbClosed)
        mnuTransactionProductNorm.Enabled = (Not gbClosed)
        mnuTransactionBalancedProduct.Enabled = (Not gbClosed)
    End Sub

    Private Sub D45F0000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-----------------------
        'an cac mnu nay di de dung chung ky voi D09
        mnuSystemCloseBook.Visible = False
        mnuSystemNewPeriod.Visible = False
        mnuSystemOpenBook.Visible = False
        mnuStatusCloseBook.Visible = False
        '-----------------------
        LoadLanguage(True)
        LoadStatusStrip()
        '-----------------------
        StandardlizeStatusBar()

        LoadUserControlTreeview()
        picMain.BackgroundImageLayout = ImageLayout.Stretch
        SetResolutionForm(Me)
    End Sub

    Private Sub LoadUserControlTreeview()
        'Minh Hòa update 29/01/2010
        'Load User control Treeview
        t = New D99U0000
        t.Dock = DockStyle.Right
        t.Location = New Point(0, 17)
        t.ModuleID = D45
        t.FormPermission = "D45F5699"
        TableLayoutPanel1.Controls.Add(t, 0, 0)
    End Sub

    Private Sub StandardlizeStatusBar()
        stbMain.Items.Remove(sbServerName)
        sbServerNameCaption.Spring = True
        sbServerNameCaption.Text = ""
    End Sub

    Private Sub mnuSystemQuit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemQuit.Click
        Me.Close()
    End Sub

    Private Sub mnuSystemSetup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSetup.Click
        'Dim f As New D45F0001
        'f.FormState = EnumFormState.FormEdit
        'f.ShowDialog()
        'f.Dispose()
        CallFormShowDialog("D45D0940", "D45F0001")
    End Sub

    Private Sub ShowFormSystemsIfNeed()
        Dim sSQL As String = "Select Top 1 1 From D45T0000 WITH(NOLOCK) "
        If Not ExistRecord(sSQL) Then 'Chưa có dữ liệu ở bảng T0000, hiện thị form Thiết lập hệ thống
            OpenFormSystem()
        Else 'Đã có dữ liệu ở bảng T0000
            If D45Options.DefaultDivisionID = "" Then 'Chưa có đơn vị dưới Registry
                'Lấy Đơn vị ở Thiết lập hệ thống
                gsDivisionID = D45Systems.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision() Then 'Đơn vị không hợp lệ
                    End 'Kết thúc chương trình
                End If
            Else 'Đã có dưới Registry rồi
                gsDivisionID = D45Options.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision(True) Then 'Đơn vị không hợp lệ
                    'Lấy Đơn vị ở Thiết lập hệ thống
                    gsDivisionID = D45Systems.DefaultDivisionID
                    If Not CheckExistDivision() Then 'Đơn vị không hợp lệ
                        End 'Kết thúc chương trình
                    End If
                End If
            End If
        End If

        GetMonthYear()
    End Sub

    Private Sub OpenFormSystem()
        'Dim f As New D45F0001
        'f.FormState = EnumFormState.FormAdd
        'f.ShowDialog()
        'f.Dispose()
        CallFormShowDialog("D45D0940", "D45F0001")
        If Not ExistRecord("Select Top 1 1 From D45T0000 WITH(NOLOCK)") Then 'Chưa có dữ liệu ở bảng T0000     
            End
        End If
        'Lấy đơn vị và kỳ kế tóan
        gsDivisionID = D45Systems.DefaultDivisionID
    End Sub

    Private Function CheckExistDivision(Optional ByVal bNoMessage As Boolean = False) As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD91P9020("45") 'xx: Mã module truyền vào 2 ký tự 
        If bNoMessage Then
            Return CheckStoreNoMessage(sSQL)
        Else
            Return CheckStoreDivision(sSQL)
        End If
    End Function

    Private Function CheckStoreNoMessage(ByVal SQL As String) As Boolean
        Dim dt As New DataTable
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString <> "0" Then
                dt = Nothing
                Return False
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function CheckStoreDivision(ByVal SQL As String) As Boolean
        Dim dt As New DataTable
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString <> "0" Then 'Đơn vị không hợp lệ
                'Kiểm tra User này có được quyền sử dụng Đơn vị nào không
                If dt.Rows(0).Item("DivisionID").ToString <> "" Then ' Có: Lấy đơn vị này để làm việc.
                    gsDivisionID = dt.Rows(0).Item("DivisionID").ToString
                    dt = Nothing
                    Return True
                Else 'Không: Thông báo và kết thúc chương trình
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                    dt = Nothing
                    Return False
                End If

            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function SQLStoreD91P9020(ByVal sModuleID As String) As String
        ' Kiểm tra có tồn tại Đơn vị
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID,varchar[20],NOT NULL
        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID,varchar[20],NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function GetMonthYear() As Boolean
        Dim sSQL As String
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then 'Có dữ liệu trong bảng T9999 và D91T0016
            giTranMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(0).Item("TranYear").ToString)
            dt.Dispose()
            Return True
        End If
        Return False
    End Function

    Private Sub GetPeriodFromDivisionT0000()
        Dim sSQL As String
        gsDivisionID = D45Systems.DefaultDivisionID
        ' gbLockedDivisionID = D45Systems.LockedDivisionID
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then 'Có dữ liệu trong bảng D09T9999 và D91T0016
            giTranMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(0).Item("TranYear").ToString)
            dt.Dispose()
        End If
    End Sub

    Private Sub D45F0000_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ShowFormSystemsIfNeed()
        mnuPeriod.Text = MakeMenuPeriod()

        If D45Options.ViewFormPeriodWhenAppRun And (ReturnPermission("D45F0003") >= EnumPermission.View) Then
            Dim f As New D45F0003
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then mnuPeriod.Text = MakeMenuPeriod()
            f.Dispose()
        End If

        SetMenuPermission()
        SetMenuPermissionTransaction()
        SetEnableMenuPermissionTransaction()
        SetVisibleDelimiter(C1MainMenu) 'Ẩn phân nhóm
        SetTextMenu(C1MainMenu)
    End Sub

    Private Sub mnuSystemOption_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOption.Click
        Dim f As New D45F0002
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnuPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPeriod.Click
        Dim f As New D45F0003
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mnuPeriod.Text = MakeMenuPeriod()
            SetEnableMenuPermissionTransaction()
        End If
        f.Dispose()
    End Sub

    Private Sub mnuSystemCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemCloseBook.Click
        If Not AllowCloseBook() Then Exit Sub
        Dim f As New D45F5554
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SetEnableMenuPermissionTransaction()
        End If
        f.Dispose()
    End Sub

    Private Function AllowCloseBook() As Boolean
        If ReturnPermission("D45F5554") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionCloseBook()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemNewPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemNewPeriod.Click
        Dim f As New D45F5556
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Function AllowNewPeriod() As Boolean
        If ReturnPermission("D45F5556") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionNewPeriod()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemOpenBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOpenBook.Click
        If Not AllowOpenBook() Then Exit Sub
        Dim f As New D45F5555
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then SetEnableMenuPermissionTransaction()
        f.Dispose()
    End Sub

    Private Function AllowOpenBook() As Boolean
        If ReturnPermission("D45F5555") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionOpenBook()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemLanguageVietnamese_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageVietnamese.Click
        geLanguage = EnumLanguage.Vietnamese
        gsLanguage = "84"
        D99C0008.Language = geLanguage
        MsgAnnouncement = "Th¤ng bÀo"
        LoadLanguage()

        TableLayoutPanel1.Controls.Remove(t)
        LoadUserControlTreeview()
    End Sub

    Private Sub mnuSystemLanguageEnglish_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageEnglish.Click
        geLanguage = EnumLanguage.English
        gsLanguage = "01"
        D99C0008.Language = geLanguage
        MsgAnnouncement = "Announcement"
        LoadLanguage()

        TableLayoutPanel1.Controls.Remove(t)
        LoadUserControlTreeview()
    End Sub



    Private Sub mnuSystemUnitPrice_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemUnitPrice.Click
        'Dim f As New D45F0010
        'If ReturnPermission("D45F0010") <= EnumPermission.View Then
        '    f.FormState = EnumFormState.FormView
        'Else
        '    f.FormState = EnumFormState.FormEdit
        'End If
        'f.ShowDialog()
        'f.Dispose()
        ' Tham số FormState chuyển về D45F0010 xử lý, do phải chuyển len L3Desktop nên ko care duoc parame
        CallFormThread("D45D0940", "D45F0010")
    End Sub

    Private Sub mnuListStep_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListStep.Click
        'RunEXEDxxExx40("D45E0140", "D45F1010")
        CallFormShow("D45D0140", "D45F1010")
    End Sub

    Private Sub mnuListMachineID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListMachineID.Click
        CallFormShow("D45D1040", "D45F1013")
    End Sub
    Private Sub mnuListProduct_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListProduct.Click
        'RunEXEDxxExx40("D45E0140", "D45F1000")
        CallFormShow("D45D0140", "D45F1000")
    End Sub

    Private Sub mnuListPriceList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPriceList.Click
        'RunEXEDxxExx40("D45E0140", "D45F1020")
        CallFormShow("D45D0140", "D45F1020")
    End Sub

    Private Sub mnuReportCheck_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCheck.Click
        'RunEXEDxxExx40("D45E0340", "D45F4000")
        CallFormShow("D45D0340", "D45F4000")
    End Sub

    Private Sub mnuReportCustomize_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCustomize.Click
        '        Dim exe As New D89E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        '        exe.FormActive = D89E0140Form.D89F9100
        '        exe.FormPermission = "D45F9100"  'Truy?n giá tr? khác nhau t?ng module 
        '        exe.ModuleID = "D45"             'Truy?n giá tr? khác nhau t?ng module 
        '        exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "D45")
        CallFormShow("D89D0140", "D89F9100", arrPro)
    End Sub

    Private Sub mnuReportPriceList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportPriceList.Click
        'RunEXEDxxExx40("D45E0340", "D45F4010")
        CallFormShow("D45D0340", "D45F4010")
    End Sub

    Private Sub mnuListSRouting_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSRouting.Click
        'RunEXEDxxExx40("D45E0140", "D45F1030")
        CallFormShow("D45D0140", "D45F1030")
    End Sub

    Private Sub mnuListTransTypeID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListTransTypeID.Click
        'RunEXEDxxExx40("D45E0140", "D45F1040")
        CallFormShow("D45D0140", "D45F1040")
    End Sub

    Private Sub mnuListProductRouting_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListProductRouting.Click
        'RunEXEDxxExx40("D45E0140", "D45F1080")
        CallFormShow("D45D0140", "D45F1080")
    End Sub

    Private Sub mnuInquiryCheckProduct_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryCheckProduct.Click
        'RunEXEDxxExx40("D45E0240", "D45F2000")
        CallFormThread("D45D0240", "D45F2000")
    End Sub

    Private Sub mnuInquiryCCSP_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryCCSP.Click
        'RunEXEDxxExx40("D45E0240", "D45F2020")
        CallFormThread("D45D0240", "D45F2020")
    End Sub

    Private Sub mnuInquiryCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryCost.Click
        'RunEXEDxxExx40("D45E0240", "D45F2030")
        CallFormThread("D45D0240", "D45F2030")
    End Sub

    Private Sub mnuTransactionCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCost.Click
        'RunEXEDxxExx40("D45E0240", "D45F2031", "D45F2030")
        CallFormThread("D45D0240", "D45F2031")
    End Sub

    Private Sub mnuListUnitID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListUnitID.Click
        '   RunEXEDxxExx40("D07E0140", "D07F0009", "D45F5601")
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D45F5601")
        CallFormShow("D07D1240", "D07F0009", arrPro)
    End Sub

    Private Sub mnuListSpecifications_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSpecifications.Click
        ' RunEXEDxxExx40("D07E0140", "D07F1410", "D45F1090")
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D45F1090")
        CallFormShow("D07D1440", "D07F1410", arrPro)
    End Sub

    Private Sub mnuListPieceworkGroupID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPieceworkGroupID.Click
        'RunEXEDxxExx40("D45E0140", "D45F1050")
        CallFormShow("D45D0140", "D45F1050")
    End Sub

    Private Sub mnuSystemProductSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemProductSalary.Click
        'Dim f As New D45F0020
        'If ReturnPermission("D45F0020") <= EnumPermission.View Then
        '    f.FormState = EnumFormState.FormView
        'Else
        '    f.FormState = EnumFormState.FormEdit
        'End If
        'f.ShowDialog()
        'f.Dispose()

        ' Tham số FormState chuyển về D45F0020 xử lý, do phải chuyển len L3Desktop nên ko care parameter
        CallFormThread("D45D0940", "D45F0020")
    End Sub

    Private Sub mnuListProductSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListProductSalary.Click
        'RunEXEDxxExx40("D45E0140", "D45F1060")
        CallFormShow("D45D0140", "D45F1060")
    End Sub

    Private Sub mnuTransactionCalProductSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCalProductSalary.Click
        'RunEXEDxxExx40("D45E0240", "D45F2010")
        CallFormThread("D45D0240", "D45F2010")
    End Sub

    Private Sub mnuReportDefineReport_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportDefineReport.Click
        '        'IncidentID	52036  	D45\ Báo cáo\ Thiết lập mẫu báo cáo gọi exe D89E4240
        '        Dim exe As New D89E4240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        '        With exe
        '            .FormActive = D89E4240Form.D89F9101
        '            .FormPermission = "D45F9101" 'Mã màn hình phân quyền
        '            .Run()
        '        End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D45F9101")
        CallFormShow("D89D4240", "D89F9101", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuReportSetupPayroll_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSetupPayroll.Click
        'RunEXEDxxExx40("D45E0340", "D45F4030")
        CallFormShow("D45D0340", "D45F4030")
    End Sub

    Private Sub mnuReportPayrollVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportPayrollVoucher.Click
        'Dim exe As New DxxExx40("D45E0340", gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'With exe
        '    .FormActive = "D45F4020" 'Form cần hiển thị
        '    .FormPermission = ("D45F4020") 'Mã màn hình phân quyền
        '    .IDxx("Flag") = "True"
        '    .Run()
        'End With
        ' FormPermission không dùng, Flag mặc định bằng True
        CallFormShow("D45D0340", "D45F4020")
    End Sub

    Private Sub mnuStatusCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatusCloseBook.Click
        'Dim exe As New D90E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        'exe.FormActive = D90E0140Form.D90F5553
        'exe.FormPermission = "D90F5553" 'Không phân quyền nên truyền vào chính nó
        'exe.ModuleID = D45
        'exe.Run()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", D45)
        SetProperties(arrPro, "FormIDPermission", "D90F5553")
        CallFormShow(Me, "D90D0140", "D90F5553", arrPro)
    End Sub

    Private Sub mnuListGroupProduct_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListGroupProduct.Click
        'RunEXEDxxExx40("D45E0140", "D45F1070")
        CallFormShow("D45D0140", "D45F1070")
    End Sub

    Private Sub mnuStatisCalculateResult_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisCalculateResult.Click
        'RunEXEDxxExx40("D45E4040", "D45F3000")
        CallFormShow("D45D4040", "D45F3000")
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P1110
    '# Created User: 
    '# Created Date: 29/07/2010 08:17:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P1110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P1110 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("45") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'CompanyID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) 'Mode, int, NOT NULL
        Return sSQL
    End Function
    Private Sub mnuHACOEF_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuHACOEF.Click
        'RunEXEDxxExx40("D45E0140", "D45F1042")
        CallFormShow("D45D0140", "D45F1042")
    End Sub
    Private Sub mnuTransactionProductNorm_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionProductNorm.Click
        CallFormThread("D45D2040", "D45F2040")
    End Sub
    Private Sub mnuTransactionBalancedProduct_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionBalancedProduct.Click
        CallFormThread("D45D2140", "D45F2050")
    End Sub

    Private Sub mnuStatisBalanceProductSalary_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisBalanceProductSalary.Click
        CallFormThread("D45D4040", "D45F4040")
    End Sub

    Private Sub mnuSystem_CheckInput_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystem_CheckInput.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D45F0066")
        CallFormShow("D91D0840", "D91F0066", arrPro)
    End Sub

    Private Sub mnuIncomeAdjust_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuIncomeAdjust.Click
        CallFormShow("D45D1040", "D45F1003")
    End Sub

    Private Sub mnuTransactionIncomeAdjustment_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionIncomeAdjustment.Click
        CallFormThread("D45D2240", "D45F2060")
    End Sub

    Private Sub mnuSystemAutoIGEList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemAutoIGEList.Click
        Me.Cursor = Cursors.WaitCursor
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "45")
        SetProperties(arrPro, "FormIDPermission", "D09F1600")
        CallFormShowDialog("D09D0140", "D09F1600", arrPro)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub mnuTransactionCheckProduct_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCheckProduct.Click
        'RunEXEDxxExx40("D45E0240", "D45F2001", "D45F2000")
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        CallFormThread("D45D0240", "D45F2001", arrPro)
    End Sub

    Private Sub mnuListGroupPartProduct_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuListGroupPartProduct.Click
        CallFormShow("D45D1040", "D45F1095")
    End Sub

    Private Sub mnuListComponentTask_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuListComponentTask.Click
        CallFormShow("D45D1040", "D45F1100")
    End Sub

    Private Sub mnuListComponentSubTask_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuListComponentSubTask.Click
        CallFormShow("D45D1040", "D45F1120")
    End Sub

    Private Sub mnuListPriceSubTaskList_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPriceSubTaskList.Click
        Dim exe As New Lemon3.DxxExx40("D45E1050", gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = "D45F1130" 'Form cần hiển thị
            .FormPermission = "D45F1130" 'Mã màn hình phân quyền
            .IDxx("ModuleID") = "45"
            .Run()
        End With
    End Sub
End Class
