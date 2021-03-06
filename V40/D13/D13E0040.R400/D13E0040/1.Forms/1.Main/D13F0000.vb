'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:10:02 PM
'# Created User: Lê Văn Phước
'# Modify Date: 01/08/2006 4:10:02 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D13F0000

    Private Const D13P0030 As String = "\Bitmap\D13P0030.jpg"
    Private Const D13P0031 As String = "\Bitmap\D13P0031.jpg"

    Dim sNamePicClick As String = ""
    Dim bMouseClickHSLGoc As Boolean = False
    Dim bMouseClickHSLThang As Boolean = False
    Dim bMouseClickChamCongNhat As Boolean = False
    Dim bMouseClickThietLapPPTinhLuong As Boolean = False
    Dim bMouseClickThietLapPPChuyenButToan As Boolean = False
    Dim bMouseClickTinhLuong As Boolean = False
    Dim bMouseClickChuyenButToan As Boolean = False

#Region "UserControl D09U2222 (gồm 5 bước)"
    'UserControl D09U2222 dùng để hiển thị các cảnh báo
    'Chuẩn hóa sử dụng D09U2222 cho form DxxF0000: gồm 5 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U2222 B" để tìm các bước chuẩn sử dụng D09U2222
    'Chuẩn hóa D09U2222 B1: đinh nghĩa biến
    Private WithEvents Frames As D09U2222
#End Region

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
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D13P0030) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D13P0030)
                picMain.BackgroundImage = bmp
            End If
        ElseIf geLanguage = EnumLanguage.English Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D13P0031) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D13P0031)
                picMain.BackgroundImage = bmp
            End If
        End If
    End Sub

    Private Sub LoadLanguage(Optional ByVal bLoadFirst As Boolean = False)
        LoadBitmap()
        If geLanguage = EnumLanguage.Vietnamese Then
            mnuSystemLanguageVietnamese.Checked = True
            mnuSystemLanguageEnglish.Checked = False
        Else
            mnuSystemLanguageVietnamese.Checked = False
            mnuSystemLanguageEnglish.Checked = True
        End If
        LoadMenuShortcut()
        GeneralItems()
        If bLoadFirst = False Then SetTextMenu(C1MainMenu)
        LoadLanguageDiagram()
    End Sub

    Private Sub LoadLanguageDiagram()
        lblHSLGoc.Text = rl3("Ho_so_luong_goc")
        lblHSLThang.Text = rl3("Ho_so_luong_thang")
        lblChamCongNhat.Text = rl3("Cham_cong_nhat")
        lblThietLapPPTinhLuong.Text = rl3("Thiet_lap") & " " & rl3("Phuong_phap_tinh_luong")
        lblThietLapPPChuyenButToan.Text = rl3("Thiet_lap") & " " & rl3("Phuong_phap_chuyen_but_toan")
        lblTinhLuong.Text = rl3("Tinh_luong_Main")
        lblChuyenButToan.Text = rl3("Chuyen_but_toan")
    End Sub

    Private Sub LoadMenuShortcut()
        '================================================================ 
        'Phần chung của các module
        sbCompanyCaption.Text = rL3("Doanh_nghiep")
        sbUserIDCaption.Text = rl3("Nguoi_dung")
        '================================================================ 
        mnuSystem.Text = rl3("_He_thong")
        mnuTransaction.Text = rl3("_Nghiep_vu")
        mnuInquiry.Text = rl3("_Truy_van")
        mnuStatis.Text = rl3("Thong_ke_____Phan_tich")
        mnuReport.Text = rl3("_Bao_cao")
        mnuList.Text = rl3("_Danh_muc")
        mnuHelp.Text = rl3("Tro__giup")

        mnuPeriod.Text = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        '================================================================ 
        Me.Text = rl3("Tien_luong_-_D13F0000") 'TiÒn l§¥ng - D13F0000
        '================================================================ 

        'Hệ thống
        mnuSystemSetup.Text = rl3("Thiet_lap_he_thong") 'Thiết lập hệ thống 
        mnuSystemSetupOther.Text = rl3("Thiet_lap_khac") ' Thiết lập khác

        mnuSystemLockVouchers.Text = rl3("Khoa_phieu") ' Khóa phiếu '  ' update 31/7/2013 id 58217

        MnuSetupOther_UsedCe.Text = rl3("He_so_su_dung") '&1 Hệ số sử dụng
        MnuSetupOther_Salary.Text = rl3("Ho_so_luong") '&2 Hồ sơ lương
        MnuSetupOther_Income.Text = rl3("Cac_khoan_thu_nhap") '&3 Các khoản thu nhập
        mnuSystemSalaryAnalist.Text = rl3("Thiet_lap_ma_loai_phan_tich") 'Thiết lập mã loại phân tích
        MnuSetupOther_Acc.Text = rl3("Tai_khoan_chuyen_but_toan") '&4 Tài khoản chuyển bút toán
        mnuSetupOther_ReferenceData.Text = rl3("Thong_tin_tham_chieu") ' Thông tin tham chiếu

        mnuSystemOption.Text = rl3("Tuy_chon") 'Tùy chọn
        mnuSystemLanguage.Text = rl3("Ngon_ngu") 'Ngôn ngữ 
        mnuSystemLanguageVietnamese.Text = rl3("Tieng_Viet") 'Tiếng Việt
        mnuSystemLanguageEnglish.Text = rl3("Tieng_Anh") 'Tiếng Anh
        mnuSystemQuit.Text = "&X  " & rl3("Thoat") 'Thoát 

        'Nghiệp vụ
        mnuTransactionSalaryPersonalFolder.Text = rl3("Ho_so_luong_ca_nhan") 'Hồ sơ lương cá nhân
        mnuTransactionSalaryMonthFolder.Text = rl3("Ho_so_luong_thang") 'Hồ sơ lương tháng
        ' update 19/11/213 id 61328 
        mnuTransactionSalaryMonthFolder.Visible = False
        mnuTransactionCheckDaily.Text = rl3("Dieu_chinh_thu_nhap")
        'mnuTransactionCheckProduce.Text = "&C  " & rl3("Cham_cong_san_pham") 'Chấm công sản phẩm
        mnuTransasionBackPay.Text = rl3("Hoi_to_luong") 'Hồi tố lương
        mnuTransactionSalaryCalculating.Text = rl3("Tinh_luong_Main") 'Tính lương
        mnuTransactionResultCal.Text = rl3("Ket_qua_chuyen_but_toan")
        mnuTransactionPublicPersonalIncome.Text = rl3("Khai_thue_TNCN")
        mnuTransactionCalculateTaxIncome.Text = rl3("Quyet_toan_thue_TNCN")
        mnuTransForecastAndCalculateSeveranceAllowance.Text = rl3("Du_phong_va_tinh_tro_cap_thoi_viec") ' Dự phòng và tính trợ cấp thôi việc  

        'Truy vấn
        mnuInquiryBackPay.Text = rL3("Danh_sach_nhan_vien_hoi_to_luong") 'Danh sách nhân viên hồi tố lương
        mnuInquiryPayrollByProjects.Text = rL3("Luong_theo_du_an") 'Lương theo dự án
        mnuInquiryTransfer.Text = rl3("Chuyen_but_toan") 'Chuyển bút toán
        mnuSeverancePayFund.Text = rl3("Quy_tro_cap_thoi_viec") 'Quỹ trợ cấp thôi việc
        mnuInquiryIncomeTax.Text = rl3("Khai_thue_TNCN")
        mnuCalculatedTaxIncome.Text = rl3("Quyet_toan_thue_TNCN") 'Khai thuế TNCN
        mnuStatisSalaryHistory.Text = rL3("Lich_su_luong")
        mnuCostPayProjectTask.Text = rL3("Chi_phi_luong_theo_Du_an_-_Hang_muc") 'Chi phí lương theo Dự án - Hạng mục
        '================================================================ 
        mnuStatisCompareDataCalSalary.Text = rL3("Doi_chieu_du_lieu_tinh_luong")
        mnuStatisLibReport.Text = rL3("Thu_vien_bao_caoU")
        mnuStatisticSetting.Text = rL3("Thiet_lap") 'Thiết lập
        mnuStatisticSalary.Text = rL3("Thong_ke_luongU") ' Thống kê lương
        mnuStatisticSalarySetting.Text = rL3("Thong_ke_luongU") ' Thống kê lương

        'Báo cáo
        mnuReportSalaryFolder.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        mnuReportAbsent.Text = rl3("Bang_cham_cong_nhat") 'Bảng chấm công nhật
        mnuReportSalaryCompany.Text = rl3("Bang_luong_cong_ty") 'Bảng lương công ty
        mnuReportTransferByEmail.Text = rl3("Chuyen_bang_luong_qua_e-mail") ' Chuyển bảng lương qua e-mail
        mnuReportPublicIncome.Text = rl3("Khai_thue_TNCN")
        mnuCalculateTaxReport.Text = rl3("Quyet_toan_thue_TNCN")
        mnuReportFamily.Text = rl3("Giam_tru_gia_canh")

        mnuReportCustomized.Text = rl3("Bao_cao_dac_thu") 'Báo cáo đặc thù
        mnuReportEstablish.Text = rl3("Thiet_lap") ' Thiết lập
        mnuReportSalary.Text = rl3("Bang_luong") 'Bảng lương
        mnuReportSample.Text = rl3("Mau_bao_cao")

        mnuReportSalaryFolder.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        mnuReportAbsent.Text = rl3("Bang_dieu_chinh_thu_nhap")
        mnuReportSalaryCompany.Text = rl3("Bang_luong_cong_ty") 'Bảng lương công ty
        mnuReportTransferByEmail.Text = rl3("Chuyen_bang_luong_qua_e-mail") ' Chuyển bảng lương qua e-mail
        mnuReportSpecific.Text = rL3("Bao_cao_dac_thu") 'Báo cáo đặc thù
        mnuReportEstablish.Text = rl3("Thiet_lap") ' Thiết lập
        mnuReportSalary.Text = rl3("Bang_luong") 'Bảng lương
        mnuReportSample.Text = rl3("Mau_bao_cao")

        'Danh mục
        mnuListSalaryFolder.Text = rl3("Ho_so_luong") 'Hồ sơ lương gốc
        mnuSalary.Text = rl3("Nhom_luong") ' Nhóm lương
        mnuListTypeGetWork.Text = rl3("Khoan_dieu_chinh_thu_nhap")
        mnuListTax.Text = rl3("Doi_tuong_thue_thu_nhap") 'Đối tượng thuế thu nhập
        mnuListTransactionAbsentType.Text = rl3("Mau_thiet_lapU")   '21/1/2014 id 60447 rl3("Loai_nghiep_vu") 'Loại nghiệp vụ

        mnuTransactionSalaryCalculation.Text = rl3("Phuong_phap_tinh_luong") 'Phương pháp tính lương
        mnuListPayrollAdjustMethod.Text = rl3("Phuong_phap_dieu_chinh_luong")
        mnuListSalaryObject.Text = rl3("Doi_tuong_tinh_luong")
        mnuListLeaveObjects.Text = rL3("Doi_tuong_tinh_phep") 'Đối tượng tính công /phép
        mnuListCollaborator.Text = rL3("Cong_tac_vien")
        mnuListSalaryScale.Text = rl3("Ngach_luong") 'Ngạch lương
        mnuListSalaryLevel.Text = rl3("Bac_luong") 'Bậc lương
        mnuListSalaryAnalist.Text = rL3("Ma_phan_tich_tien_luong") 'Mã phân tích tiền lương
        mnuListExchangeRate.Text = rL3("Ty_gia") 'Tỷ giá
        mnuListCurrencies.Text = rL3("Nguyen_te") 'Nguyên tệ

        mnuTransactionTransferMethod.Text = rl3("Phuong_phap_chuyen_but_toan") 'Phương pháp chuyển bút toán
        mnuListPolicyID.Text = rl3("Co_che_chuyen_but_toan") 'Cơ chế chuyển bút toán

        mnuListReward.Text = rl3("Thuong_theo_tham_nien") 'Thưởng theo thâm niên
        mnuListEvaluate.Text = rl3("Danh_gia_xep_loai") 'Đánh giá xếp loại
        mnuListResultReference.Text = rL3("Bang_tham_chieu_ket_qua") 'Bảng tham chiếu kết quả
        mnuListRefResult.Text = rL3("Bang_tham_chieu_ket_qua_theo_thoi_gianU") 'Bảng tham chiếu kết quả theo thời gian
        mnuList_TemplateList.Text = rl3("Danh_muc_Templates_tang_thong_so_luong") 'Danh mục Templates tăng thông số lương
        mnuListDefaultSalaryParameters.Text = rl3("Thong_so_luong_mac_dinh") 'Thông số lương mặc định

        mnuListWarning.Text = rl3("Canh_bao") 'Cảnh báo

        'Trợ giúp
        mnuHelpContent.Text = rl3("Noi_dung") 'Nội dung
        mnuHelpIndex.Text = rl3("Chi_muc") 'Chỉ mục
        '  SetTextMenu(C1MainMenu)
    End Sub

    Private Sub VisibledMenu(ByVal mnu As C1.Win.C1Command.C1Command, ByVal FormPermission As Boolean)
        If mnu.Visible Then mnu.Visible = FormPermission
    End Sub

    Private Sub VisibledMenu(ByVal mnu As C1.Win.C1Command.C1Command, ByVal sFormPermission As String)
        If mnu.Visible Then mnu.Visible = ReturnPermission(sFormPermission) >= EnumPermission.View
    End Sub

    Private Sub VisibledMenuTrans(ByVal mnu As C1.Win.C1Command.C1Command, ByVal sFormPermission As String)
        If mnu.Visible Then mnu.Visible = ReturnPermission(sFormPermission) > EnumPermission.View
    End Sub

    'Sub này không ảnh hưởng bởi biến gbClosed
    Private Sub SetMenuPermission()
        'Phân quyền cho menu Hệ thống
        VisibledMenu(mnuSystemNewPeriod, ReturnPermission("D13F5556") >= EnumPermission.View)

        ' Lưu ý: Đối với menu Kỳ không có quyền thì chỉ mờ menu
        'Phân quyền cho menu Kỳ
        mnuPeriod.Enabled = ReturnPermission("D13F0003") >= EnumPermission.View

        VisibledMenu(mnuSystemSetup, ReturnPermission("D13F0001") >= EnumPermission.View)
        ' update 31/7/2013 id 58217
        VisibledMenu(mnuSystemLockVouchers, ReturnPermission("D13F5557") >= EnumPermission.View)
        VisibledMenu(mnuSystemOption, ReturnPermission("D13F0002") >= EnumPermission.View)

        If D13Systems.IsUsedPAna Then ' update 21/8/2012 incident 50602
            VisibledMenu(mnuSystemSalaryAnalist, ReturnPermission("D13F0050") >= EnumPermission.View)
        Else
            mnuSystemSalaryAnalist.Visible = False
        End If

        VisibledMenu(MnuSetupOther_UsedCe, ReturnPermission("D13F0010") >= EnumPermission.View)
        VisibledMenu(MnuSetupOther_Salary, ReturnPermission("D13F0020") >= EnumPermission.View)
        VisibledMenu(MnuSetupOther_Income, ReturnPermission("D13F0030") >= EnumPermission.View)
        VisibledMenu(MnuSetupOther_Acc, ReturnPermission("D13F0040") >= EnumPermission.View)
        VisibledMenu(mnuSetupOther_ReferenceData, ReturnPermission("D13F0060") >= EnumPermission.View)

        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        VisibledMenu(mnuTransactionSalaryPersonalFolder, ReturnPermission("D13F2000") >= EnumPermission.View)
        VisibledMenu(mnuTransactionSalaryMonthFolder, ReturnPermission("D13F2010") >= EnumPermission.View)
        VisibledMenu(mnuTransactionCheckDaily, ReturnPermission("D13F2020") >= EnumPermission.View)
        VisibledMenu(mnuTransactionSalaryCalculating, ReturnPermission("D13F2040") >= EnumPermission.View)

        'Phân quyền cho menu Truy vấn
        If D13Systems.IsNewTransferPolicyMode Then
            VisibledMenu(mnuInquiryTransfer, ReturnPermission("D13F2100") >= EnumPermission.View)
        Else
            VisibledMenu(mnuInquiryTransfer, ReturnPermission("D13F3010") >= EnumPermission.View)
        End If
        VisibledMenu(mnuInquiryIncomeTax, ReturnPermission("D13F2070") >= EnumPermission.View)
        VisibledMenu(mnuCalculatedTaxIncome, ReturnPermission("D13F2080") >= EnumPermission.View)
        VisibledMenu(mnuStatisSalaryHistory, ReturnPermission("D13F3030") >= EnumPermission.View)
        VisibledMenu(mnuCostPayProjectTask, ReturnPermission("D13F3070") >= EnumPermission.View)
        VisibledMenu(mnuStatisCompareDataCalSalary, ReturnPermission("D13F3050") >= EnumPermission.View)
        VisibledMenu(mnuStatisLibReport, ReturnPermission("D09F4120") >= EnumPermission.View)
        VisibledMenu(mnuStatisticSalary, ReturnPermission("D13F4200") >= EnumPermission.View)
        VisibledMenu(mnuStatisticSalarySetting, ReturnPermission("D09F4120") >= EnumPermission.View)
        VisibledMenu(mnuInquiryBackPay, ReturnPermission("D13F2090") >= EnumPermission.View)
        VisibledMenu(mnuInquiryPayrollByProjects, ReturnPermission("D13F3080") >= EnumPermission.View)

        'Phân quyền cho menu Báo cáo

        VisibledMenu(mnuReportSalaryFolder, ReturnPermission("D13F4050") >= EnumPermission.View) 'Mở rem lại theo Bích Thuận
        VisibledMenu(mnuReportAbsent, ReturnPermission("D13F4010") >= EnumPermission.View)
        VisibledMenu(mnuReportSalaryCompany, ReturnPermission("D13F4020") >= EnumPermission.View)
        VisibledMenu(mnuReportSpecific, ReturnPermission("D13F9100") >= EnumPermission.View)
        VisibledMenu(mnuReportEstablish, ReturnPermission("D13F4030") >= EnumPermission.View)
        VisibledMenu(mnuReportSample, ReturnPermission("D13F9101") >= EnumPermission.View)
        VisibledMenu(mnuReportTransferByEmail, ReturnPermission("D13F5609") >= EnumPermission.View)
        VisibledMenu(mnuReportPublicIncome, ReturnPermission("D13F4060") >= EnumPermission.View)
        VisibledMenu(mnuCalculateTaxReport, ReturnPermission("D13F4070") >= EnumPermission.View)
        VisibledMenu(mnuReportFamily, ReturnPermission("D13F4090") >= EnumPermission.View)

        'Phân quyền cho menu Danh mục
        VisibledMenu(mnuListTypeGetWork, ReturnPermission("D13F1000") >= EnumPermission.View)
        VisibledMenu(mnuSalary, ReturnPermission("D13F1180") >= EnumPermission.View)
        VisibledMenu(mnuListTransactionAbsentType, ReturnPermission("D13F1240") >= EnumPermission.View)
        VisibledMenu(mnuListTax, ReturnPermission("D13F1010") >= EnumPermission.View)
        'VisibledMenu(mnuListSalaryFolder, ReturnPermission("D13F2012") >= EnumPermission.View)
        VisibledMenu(mnuListSalaryScale, ReturnPermission("D13F1040") >= EnumPermission.View)
        VisibledMenu(mnuListSalaryLevel, ReturnPermission("D13F1050") >= EnumPermission.View)
        VisibledMenu(mnuList_TemplateList, ReturnPermission("D13F1060") >= EnumPermission.View)
        VisibledMenu(mnuListEvaluate, ReturnPermission("D13F1070") >= EnumPermission.View)
        VisibledMenu(mnuListReward, ReturnPermission("D13F1080") >= EnumPermission.View)
        ' update 21/8/2012 incident 50602
        If D13Systems.IsUsedPAna Then
            VisibledMenu(mnuListSalaryAnalist, ReturnPermission("D13F1090") >= EnumPermission.View)
        Else
            mnuListSalaryAnalist.Visible = False
        End If
        VisibledMenu(mnuListResultReference, ReturnPermission("D13F1100") >= EnumPermission.View)
        VisibledMenu(mnuListRefResult, ReturnPermission("D13F1260") >= EnumPermission.View)
        VisibledMenu(mnuListSalaryObject, ReturnPermission("D13F1140") >= EnumPermission.View)
        VisibledMenu(mnuListDefaultSalaryParameters, ReturnPermission("D13F1160") >= EnumPermission.View)
        VisibledMenu(mnuTransactionSalaryCalculation, ReturnPermission("D13F2050") >= EnumPermission.View)
        If D13Systems.IsNewTransferPolicyMode Then
            VisibledMenu(mnuTransactionTransferMethod, ReturnPermission("D13F2160") >= EnumPermission.View)
        Else
            VisibledMenu(mnuTransactionTransferMethod, ReturnPermission("D13F2060") >= EnumPermission.View)
        End If
        VisibledMenu(mnuListPayrollAdjustMethod, ReturnPermission("D13F1150") >= EnumPermission.View)
        VisibledMenu(mnuListWarning, ReturnPermission("D13F5606") >= EnumPermission.View)
        VisibledMenu(mnuListLeaveObjects, ReturnPermission("D13F1170") >= EnumPermission.View)
        VisibledMenu(mnuListCollaborator, ReturnPermission("D13F1190") >= EnumPermission.View)
        If D13Systems.IsNewTransferPolicyMode Then
            VisibledMenu(mnuListPolicyID, ReturnPermission("D13F2165") >= EnumPermission.View)
        Else
            mnuListPolicyID.Visible = False
        End If
        VisibledMenu(mnuListExchangeRate, ReturnPermission("D13F1200") >= EnumPermission.View)
        VisibledMenu(mnuListCurrencies, ReturnPermission("D13F1210") >= EnumPermission.View)
    End Sub

    'Sub này có ảnh hưởng bởi biến gbClosed
    Private Sub SetMenuPermissionTransaction()
        VisibledMenu(mnuTransactionCheckDaily, ReturnPermission("D13F2020") >= EnumPermission.View)
        VisibledMenu(mnuTransactionSalaryCalculating, ReturnPermission("D13F2040") >= EnumPermission.View)

        VisibledMenu(mnuTransactionPublicPersonalIncome, ReturnPermission("D13F2070") > EnumPermission.View)
        VisibledMenu(mnuTransactionCalculateTaxIncome, ReturnPermission("D13F2080") > EnumPermission.View)
        VisibledMenu(mnuTransactionResultCal, ReturnPermission("D13F2100") > EnumPermission.View)
        VisibledMenu(mnuTransasionBackPay, ReturnPermission("D13F2090") > EnumPermission.View)
        VisibledMenu(mnuTransForecastAndCalculateSeveranceAllowance, ReturnPermission("D13F3020") > EnumPermission.View)
    End Sub

    '  - Ẩn theo phân quyền
    Private Sub SetEnableMenuPermissionTransaction()
        'Phân quyền cho menu Hệ thống phụ thuộc vào biến gbClosed
        mnuSystemCloseBook.Enabled = Not gbClosed
        mnuSystemOpenBook.Enabled = gbClosed

        mnuTransactionCheckDaily.Enabled = (Not gbClosed)
        ' Đặc thù - Khi xóa sổ vẫn cho xem - ID: 71282 02/04/2015
        'mnuTransactionSalaryCalculating.Enabled = (Not gbClosed)
        mnuTransactionPublicPersonalIncome.Enabled = (Not gbClosed)
        mnuTransactionCalculateTaxIncome.Enabled = (Not gbClosed)
        mnuTransactionResultCal.Enabled = (Not gbClosed)
        mnuTransasionBackPay.Enabled = (Not gbClosed)
        mnuTransForecastAndCalculateSeveranceAllowance.Enabled = (Not gbClosed)
    End Sub

    Private Sub D13F0000_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Chuẩn hóa D99U0000 B3: Lưu tham số xuống Registry (dạng cây menu)
        'Minh Hòa update 29/01/2010
        'Save Registry User control Treeview
        D99C0007.SaveModulesSetting(D13, ModuleOption.lmOthers, "MenuTypeTreeview", giMenuType)
        KillChildProcess(MODULED13)
    End Sub

    Private Sub D13F0000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '        SetMenuPermission()
        '        SetMenuPermissionTransaction()
        LoadLanguage(True)
        LoadStatusStrip()

        If D13Options.ShowDiagram Then
            EnabledDiagram(True)
        Else
            EnabledDiagram(False)
        End If
        StandardlizeStatusBar()
        '------------------------------------------
        'Chuẩn hóa D99U0000 B2: Lấy tham số Registry (dạng cây menu) để load cây treeview 
        'Minh Hòa update 29/01/2010
        giMenuType = CInt(D99C0007.GetModulesSetting(D13, ModuleOption.lmOthers, "MenuTypeTreeview", "0"))
        If giMenuType = -1 Then giMenuType = 0

        picMain.Dock = DockStyle.Fill
        LoadUserControlTreeview()
        picMain.BackgroundImageLayout = ImageLayout.Stretch
        '------------------------------------------
    End Sub

    Private Sub StandardlizeStatusBar()
        stbMain.Items.Remove(sbServerName)
        sbServerNameCaption.Spring = True
        sbServerNameCaption.Text = ""
    End Sub

    Private Sub LoadUserControlTreeview()
        'Minh Hòa update 29/01/2010
        'Load User control Treeview
        t = New D99U0000
        t.Dock = DockStyle.Right
        t.Location = New Point(0, 17)
        t.ModuleID = D13
        t.FormPermission = "D13F5699"
        pnlMain.Controls.Add(t, 0, 0)
    End Sub

    Private Sub mnuSystemQuit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemQuit.Click
        Me.Close()
    End Sub

    Private Sub mnuSystemSetup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSetup.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormEdit)
        CallFormShowDialog("D13D0940", "D13F0001", arrPro)
        '        Dim f As New D13F0001
        'f.FormState = EnumFormState.FormEdit
        '        f.ShowDialog()
        '        f.Dispose()
    End Sub

    Private Sub ShowFormSystemsIfNeed()
        Dim sSQL As String = "Select Top 1 1 From D13T0000 WITH (NOLOCK) "
        If Not ExistRecord(sSQL) Then 'Chưa có dữ liệu ở bảng T0000, hiện thị form Thiết lập hệ thống
            OpenFormSystem()
        Else 'Đã có dữ liệu ở bảng T0000
            If D13Options.DefaultDivisionID = "" Then 'Chưa có đơn vị dưới Registry
                'Lấy Đơn vị ở Thiết lập hệ thống
                gsDivisionID = D13Systems.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision() Then 'Đơn vị không hợp lệ
                    End 'Kết thúc chương trình
                End If
            Else 'Đã có dưới Registry rồi
                gsDivisionID = D13Options.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision(True) Then 'Đơn vị không hợp lệ
                    'Lấy Đơn vị ở Thiết lập hệ thống
                    gsDivisionID = D13Systems.DefaultDivisionID
                    'gbLockedDivisionID = D13Systems.LockedDivisionID
                    If Not CheckExistDivision() Then 'Đơn vị không hợp lệ
                        End 'Kết thúc chương trình
                    End If
                End If
            End If
        End If
        GetMonthYear()
    End Sub

    Private Sub OpenFormSystem()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        Dim frm As Form = CallFormShowDialog("D13D0940", "D13F0001", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) = False Then
            End
        End If
        gsDivisionID = D13Systems.DefaultDivisionID
    End Sub

    Private Function CheckExistDivision(Optional ByVal bNoMessage As Boolean = False) As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD91P9020("13") 'xx: Mã module truyền vào 2 ký tự 
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
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
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
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99 WITH (NOLOCK) Inner Join D91T0016 T16  WITH (NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
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
        gsDivisionID = D13Systems.DefaultDivisionID
        'gbLockedDivisionID = D13Systems.LockedDivisionID
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99  WITH (NOLOCK) Inner Join D91T0016 T16  WITH (NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            giTranMonth = Convert.ToInt16(dt.Rows(i).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(i).Item("TranYear").ToString)
        Next

    End Sub

    Private Sub D13F0000_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ShowFormSystemsIfNeed()
        mnuPeriod.Text = MakeMenuPeriod()
        If D13Options.ViewFormPeriodWhenAppRun AndAlso (ReturnPermission("D13F0003") >= EnumPermission.View) Then
            Dim f As New D13F0003
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then mnuPeriod.Text = MakeMenuPeriod()
            f.Dispose()
        End If
        'mnuPeriod.Text = MakeMenuPeriod()

        SetMenuPermission()
        SetMenuPermissionTransaction()
        SetEnableMenuPermissionTransaction()
        SetVisibleDelimiter(C1MainMenu) 'Ẩn phân nhóm
        SetTextMenu(C1MainMenu)

        gsPayRollVoucherID = GetPayRollVoucherID()

        '**********************************************
        'Chuẩn hóa D09U2222 B2: Thêm các Frame cảnh báo.
        Call_D09U2222()
        '**********************************************
        SetResolutionForm(Me)
    End Sub

    Private Sub Call_D09U2222()

        'Update 24/11/2011: Incident 44322
        'Phai remove D09U2222 truoc khi add moi vao
        'Neu k thi se bi du nhung cai cu va cai moi se bi de phia duoi k thay duoc
        For Each ctr As Control In pnlMain.Controls
            If ctr.Name = "D09U2222" Then
                pnlMain.Controls.Remove(ctr)
            End If
        Next

        picMain.Visible = True ' Đưa nền cho khỏi load lên bị dựt
        'Khởi tạo UserControl
        Frames = New D09U2222
        Frames.BringToFront()
        Frames.Dock = DockStyle.Fill
        Frames.ModuleID = "13" 'Module gọi
        Frames.FormPermision = "D09F4000" 'Form phân quyền cho mnuPrint
        pnlMain.Controls.Add(Frames, 1, 0)
        picMain.Visible = False 'Tắt đi
        If Frames.IsFrame = False Then
            pnlMain.Controls.Remove(Frames)
            picMain.Visible = True
        End If
    End Sub

    Private Sub mnuSystemOption_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOption.Click
        Dim f As New D13F0002
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnuPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPeriod.Click
        Dim f As New D13F0003
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mnuPeriod.Text = MakeMenuPeriod()
            SetEnableMenuPermissionTransaction()
            gsPayRollVoucherID = GetPayRollVoucherID()
            Call_D09U2222()
        End If
        f.Dispose()
    End Sub

    Private Sub mnuSystemLanguageVietnamese_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageVietnamese.Click
        mnuSystemLanguageVietnamese.Checked = True
        mnuSystemLanguageEnglish.Checked = False
        geLanguage = EnumLanguage.Vietnamese
        gsLanguage = "84"
        D99C0008.Language = geLanguage
        LoadLanguage()
        '------------------------------------------
        'Chuẩn hóa D99U0000 B4: Load lại cây menu theo ngôn ngữ tiếng Việt
        'Minh Hòa update 29/01/2010
        pnlMain.Controls.Remove(t)
        LoadUserControlTreeview()
        '-----------------------------------------
        '**********************************************
        'Chuẩn hóa D09U2222 B3: Ngôn ngữ cho cảnh báo.
        If picMain.Visible = False Then Frames.LoadLanguage_D09U2222()
        '**********************************************
    End Sub

    Private Sub mnuSystemLanguageEnglish_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageEnglish.Click
        mnuSystemLanguageVietnamese.Checked = False
        mnuSystemLanguageEnglish.Checked = True
        geLanguage = EnumLanguage.English
        gsLanguage = "01"
        D99C0008.Language = geLanguage
        LoadLanguage()
        '------------------------------------------
        'Chuẩn hóa D99U0000 B4: Load lại cây menu theo ngôn ngữ tiếng Việt
        'Minh Hòa update 29/01/2010
        pnlMain.Controls.Remove(t)
        LoadUserControlTreeview()
        '-----------------------------------------

        '**********************************************
        'Chuẩn hóa D09U2222 B4: Ngôn ngữ cho cảnh báo.
        If picMain.Visible = False Then Frames.LoadLanguage_D09U2222()
        '**********************************************
    End Sub

    'Danh mục
    Private Sub MnuSetupOther_UsedCe_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuSetupOther_UsedCe.Click
        CallFormShowDialog("D13D0940", "D13F0010")
       
    End Sub

    Private Sub MnuSetupOther_Salary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuSetupOther_Salary.Click
        CallFormShowDialog("D13D0940", "D13F0020")
       
    End Sub

    Private Sub MnuSetupOther_Income_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuSetupOther_Income.Click
        CallFormShowDialog("D13D0940", "D13F0030")
       
    End Sub

    Private Sub MnuSetupOther_Acc_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuSetupOther_Acc.Click
        CallFormShowDialog("D13D0940", "D13F0040")
      
    End Sub

    'Danh mục ---> A. Hồ sơ lương
    Private Sub mnuListSalaryFolder_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSalaryFolder.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "Path", "04")
        CallFormThread("D13D2040", "D13F2012", arrPro)
    End Sub

    'Danh mục ---> B. Khoản điều chỉnh thu nhập
    Private Sub mnuListTypeGetWork_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListTypeGetWork.Click
        CallFormShow("D13D0140", "D13F1000")
    End Sub

    'Danh mục ---> Mẫu thiết lập
    Private Sub mnuListTransactionAbsentType_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListTransactionAbsentType.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", 3)
        CallFormShow("D13D1140", "D13F1240", arrPro)
      
    End Sub

    'Danh mục ---> D. Đối tượng thuế thu nhập
    Private Sub mnuListTax_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListTax.Click
        CallFormShow("D13D0140", "D13F1010")
      
    End Sub

    'Danh mục ---> E. Đối tượng tính lương
    Private Sub mnuListSalaryObject_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSalaryObject.Click
        CallFormShow("D13D0140", "D13F1140")
        
    End Sub

    'Danh mục ---> F. Thưởng theo thâm niên
    Private Sub mnuListReward_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListReward.Click
        CallFormShow("D13D0140", "D13F1080")
       
    End Sub

    'Danh mục ---> G. Đánh giá xếp loại
    Private Sub mnuListEvaluate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListEvaluate.Click
        CallFormShow("D13D0140", "D13F1070")
       
    End Sub

    'Danh mục ---> H. Ngạch lương
    Private Sub mnuListSalaryScale_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSalaryScale.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D13D0140", "D13F1040", arrPro)
      
    End Sub

    'Danh mục ---> I. Bậc lương
    Private Sub mnuListSalaryLevel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSalaryLevel.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D13D0140", "D13F1050", arrPro)
      
    End Sub

    'Danh mục ---> J. Danh mục template tăng thông số lương
    Private Sub mnuList_TemplateList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuList_TemplateList.Click
        CallFormShow("D13D0140", "D13F1060")
      
    End Sub

    'Danh mục ---> K. Thông số lương mặc định
    Private Sub mnuListDefaultSalaryParameters_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListDefaultSalaryParameters.Click
        CallFormShow("D13D0140", "D13F1160")
      
    End Sub

    'Danh mục ---> L. Mã phân tích tiền lương
    Private Sub mnuListSalaryAnalist_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListSalaryAnalist.Click
        CallFormShow("D13D0140", "D13F1090")
     
    End Sub

    'Danh mục ---> M.Bảng tham chiếu kết quả
    Private Sub mnuListResultReference_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListResultReference.Click
        CallFormShow("D13D0140", "D13F1100")
       
    End Sub

    Private Sub mnuListRefResult_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListRefResult.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D13D1140", "D13F1260", arrPro)
    End Sub


    'Danh mục ---> N. Phương pháp điều chỉnh lương
    Private Sub mnuListPayrollAdjustMethod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPayrollAdjustMethod.Click
        CallFormShow("D13D0140", "D13F1150")
       
    End Sub

    'Danh mục ---> O. Phương pháp tính lương
    Private Sub mnuTransactionSalaryCalculation_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSalaryCalculation.Click
        CallFormShow("D13D1040", "D13F2050")
        '        ' update 27/9/2013 id 60083 
        '  RunEXEDxxExx40("D13E1040", "D13F2050")
    End Sub

    'Danh mục ---> P. Phương pháp chuyển bút toán
    Private Sub mnuTransactionTransferMethod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionTransferMethod.Click
        If D13Systems.IsNewTransferPolicyMode Then
            CallFormShow("D13D0140", "D13F2160")
            '            Dim f As New D13M0140
            '            With f
            '                .FormActive = enumD13E0140Form.D13F2160
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            CallFormShow("D13D0140", "D13F2060")
            '            Dim f As New D13M0140
            '            With f
            '                .FormActive = enumD13E0140Form.D13F2060
            '                .ShowDialog()
            '                .Dispose()
            '  End With
        End If
    End Sub

    'Danh mục ---> Q. Cơ chế chuyển bút toán
    Private Sub mnuListPolicyID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListPolicyID.Click
        CallFormShow("D13D0140", "D13F2165")
       
    End Sub

    'Danh mục ---> R. Cảnh báo
    Private Sub mnuListWarning_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListWarning.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F5606")
        SetProperties(arrPro, "ModuleID", "D13") 'Gọi từ module D82 thì truyền vào "", khác D82 thì truyền vào "Dxx"
        CallFormShow("D82D1140", "D82F1020", arrPro)
       
    End Sub

    Private Sub mnuReportSpecific_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSpecific.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "D13")
        CallFormShow("D89D0140", "D89F9100", arrPro)
    End Sub

    'Báo cáo ---> B. Điều chỉnh thu nhập
    Private Sub mnuReportAbsent_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportAbsent.Click
        CallFormShow("D13D0340", "D13F4010")
      
    End Sub

    'Báo cáo ---> C. Bảng lương công ty
    Private Sub mnuReportSalaryCompany_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSalaryCompany.Click
        CallFormShow("D13D0340", "D13F4020")
      
    End Sub

    'Báo cáo ---> D. Chuyển bảng lương qua Email
    Private Sub mnuReportTransferByEmail_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportTransferByEmail.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "bIsTransferByEmail", True)
        CallFormShow("D13D0340", "D13F4020", arrPro)
    End Sub

    'Báo cáo ---> E. Khai thuế TNCN
    Private Sub mnuReportPublicIncome_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportPublicIncome.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PITVoucherID", "")
        SetProperties(arrPro, "BlockID", "%")
        SetProperties(arrPro, "DepartmentID", "%")
        SetProperties(arrPro, "TeamID", "%")
        SetProperties(arrPro, "DeductionLabor", True)
        SetProperties(arrPro, "NonDeductionLabor", False)
        SetProperties(arrPro, "WhereClause", "")

        CallFormShow("D13D0340", "D13F4060", arrPro)
    End Sub

    'Báo cáo ---> F. Quyết toán thuế TNCN
    Private Sub mnuCalculateTaxReport_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCalculateTaxReport.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PITBalanceVoucherID", "")
        SetProperties(arrPro, "BlockID", "%")
        SetProperties(arrPro, "DepartmentID", "%")
        SetProperties(arrPro, "TeamID", "%")
        SetProperties(arrPro, "WhereClause", "")

        CallFormShow("D13D0340", "D13F4070", arrPro)
       
    End Sub

    'Báo cáo ---> G. Thiết lập bảng lương
    Private Sub mnuReportSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSalary.Click
        CallFormShow("D13D0340", "D13F4030")
    End Sub

    'Truy vấn -->A. Chuyển bút toán
    Private Sub mnuInquiryTransfer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryTransfer.Click
        If D13Systems.IsNewTransferPolicyMode Then
            CallFormThread("D13D0240", "D13F2100")
          
        Else
            CallFormThread("D13D0440", "D13F3010")
         
        End If
    End Sub

    Private Sub mnuInquiryIncomeTax_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryIncomeTax.Click
        CallFormThread("D13D0240", "D13F2070")
    End Sub

    'Truy vấn -->D. Quyết toán thuế TNCN
    Private Sub mnuCalculatedTaxIncome_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCalculatedTaxIncome.Click
        CallFormThread("D13D0240", "D13F2080")
      
    End Sub

    'Truy vấn -->E. Lịch sử lương
    Private Sub mnuStatisSalaryHistory_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisSalaryHistory.Click
        CallFormShow("D13D4040", "D13F3030")
    End Sub

    Private Sub mnuCostPayProjectTask_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCostPayProjectTask.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", "D13F3070")
        SetProperties(arrPro, "FormIDPermission", "D13F3070")
        CallFormShow(Me, "D89D4040", "D89F3000", arrPro)
    End Sub
    'Truy vấn -->F. Đối chiếu dữ liệu tính lương
    Private Sub mnuStatisCompareDataCalSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisCompareDataCalSalary.Click
        CallFormShow("D13D4040", "D13F3050")
    End Sub
    ' Thống kê - PT: Thư viện báo cáo
    Private Sub mnuStatisLibReport_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisLibReport.Click
        'CallFormShow("D09D4140", "D09F4121")
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", D13)
        CallFormShow("D09D4140", "D09F4121", arrPro)
    End Sub


    Private Sub mnuSystemSalaryAnalist_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSalaryAnalist.Click
        CallFormShowDialog("D13D0940", "D13F0050")
    End Sub

    Private Sub mnuReportSample_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSample.Click

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F9101")
        CallFormShow("D89D4240", "D89F9101", arrPro)
        Me.Cursor = Cursors.Default


    End Sub

    '====================================Sơ đồ quy trình====================================

    Private Sub EnabledDiagram(ByVal bDisplay As Boolean)
        picHSLGoc.Visible = bDisplay
        picHSLThang.Visible = bDisplay
        picChamCongNhat.Visible = bDisplay
        picThietLapPPTinhLuong.Visible = bDisplay
        picThietLapPPChuyenButToan.Visible = bDisplay
        picTinhLuong.Visible = bDisplay
        picChuyenButToan.Visible = bDisplay
        lblHSLGoc.Visible = bDisplay
        lblHSLThang.Visible = bDisplay
        lblChamCongNhat.Visible = bDisplay
        lblThietLapPPTinhLuong.Visible = bDisplay
        lblThietLapPPChuyenButToan.Visible = bDisplay
        lblTinhLuong.Visible = bDisplay
        lblChuyenButToan.Visible = bDisplay
        picArrow01.Visible = bDisplay
        picArrow02.Visible = bDisplay
        picArrow03.Visible = bDisplay
        picArrow04.Visible = bDisplay
        picArrow05.Visible = bDisplay
        picArrow06.Visible = bDisplay
        picLine01.Visible = bDisplay
        picLine02.Visible = bDisplay
        picLine03.Visible = bDisplay
        picLine04.Visible = bDisplay
        picLine05.Visible = bDisplay
        picLine06.Visible = bDisplay
        picLine07.Visible = bDisplay
        picLine08.Visible = bDisplay
        picLine09.Visible = bDisplay
    End Sub

    Private Sub LoadImageMouseMove(ByVal sImageName As String)
        Dim sImageMove As String = "yellow"
        Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & sImageMove & ".gif")
        Select Case sImageName
            Case picHSLGoc.Name
                lblHSLGoc.ForeColor = Color.Gold
                lblHSLGoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picHSLThang.Name
                picHSLThang.Image = bmp
                lblHSLThang.ForeColor = Color.Gold
                lblHSLThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picChamCongNhat.Name
                picChamCongNhat.Image = bmp
                lblChamCongNhat.ForeColor = Color.Gold
                lblChamCongNhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picThietLapPPTinhLuong.Name
                picThietLapPPTinhLuong.Image = bmp
                lblThietLapPPTinhLuong.ForeColor = Color.Gold
                lblThietLapPPTinhLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picThietLapPPChuyenButToan.Name
                picThietLapPPChuyenButToan.Image = bmp
                lblThietLapPPChuyenButToan.ForeColor = Color.Gold
                lblThietLapPPChuyenButToan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picTinhLuong.Name
                picTinhLuong.Image = bmp
                lblTinhLuong.ForeColor = Color.Gold
                lblTinhLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
            Case picChuyenButToan.Name
                picChuyenButToan.Image = bmp
                lblChuyenButToan.ForeColor = Color.Gold
                lblChuyenButToan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((FontStyle.Underline Or FontStyle.Bold), System.Drawing.FontStyle), GraphicsUnit.Point, CType(0, Byte))
        End Select
    End Sub

    Private Sub LoadImageMouseLeave(ByVal sImageName As String)
        Dim sImageClick As String = "red"
        Dim sImageLeave As String = "saffron"
        Select Case sImageName
            Case picHSLGoc.Name
                lblHSLGoc.ForeColor = Color.White
                lblHSLGoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picHSLThang.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickHSLThang, sImageClick, sImageLeave).ToString & ".gif")
                picHSLThang.Image = bmp
                lblHSLThang.ForeColor = Color.White
                lblHSLThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picChamCongNhat.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickChamCongNhat, sImageClick, sImageLeave).ToString & ".gif")
                picChamCongNhat.Image = bmp
                lblChamCongNhat.ForeColor = Color.White
                lblChamCongNhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picThietLapPPTinhLuong.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickThietLapPPTinhLuong, sImageClick, sImageLeave).ToString & ".gif")
                picThietLapPPTinhLuong.Image = bmp
                lblThietLapPPTinhLuong.ForeColor = Color.White
                lblThietLapPPTinhLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picThietLapPPChuyenButToan.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickThietLapPPChuyenButToan, sImageClick, sImageLeave).ToString & ".gif")
                picThietLapPPChuyenButToan.Image = bmp
                lblThietLapPPChuyenButToan.ForeColor = Color.White
                lblThietLapPPChuyenButToan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picTinhLuong.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickTinhLuong, sImageClick, sImageLeave).ToString & ".gif")
                picTinhLuong.Image = bmp
                lblTinhLuong.ForeColor = Color.White
                lblTinhLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Case picChuyenButToan.Name
                Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & IIf(bMouseClickChuyenButToan, sImageClick, sImageLeave).ToString & ".gif")
                picChuyenButToan.Image = bmp
                lblChuyenButToan.ForeColor = Color.White
                lblChuyenButToan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        End Select
    End Sub

    Private Sub LoadImageMouseClick(ByVal sImageName As String)
        Dim sImageClick As String = "red"
        Dim bmp As New Bitmap(gsApplicationSetup & "\Bitmap\" & sImageClick & ".gif")
        Select Case sImageName
            Case picHSLGoc.Name
                bMouseClickHSLGoc = True
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = False
            Case picHSLThang.Name
                picHSLThang.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = True
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = False
            Case picChamCongNhat.Name
                picChamCongNhat.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = True
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = False
            Case picThietLapPPTinhLuong.Name
                picThietLapPPTinhLuong.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = True
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = False
            Case picThietLapPPChuyenButToan.Name
                picThietLapPPChuyenButToan.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = True
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = False
            Case picTinhLuong.Name
                picTinhLuong.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = True
                bMouseClickChuyenButToan = False
            Case picChuyenButToan.Name
                picChuyenButToan.Image = bmp
                bMouseClickHSLGoc = False
                bMouseClickHSLThang = False
                bMouseClickChamCongNhat = False
                bMouseClickThietLapPPTinhLuong = False
                bMouseClickThietLapPPChuyenButToan = False
                bMouseClickTinhLuong = False
                bMouseClickChuyenButToan = True
        End Select
    End Sub

    Private Sub picHSLGoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picHSLGoc.Click
        lblHSLGoc_Click(Nothing, Nothing)
    End Sub

    Private Sub picHSLGoc_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picHSLGoc.MouseLeave
        lblHSLGoc_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picHSLGoc_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picHSLGoc.MouseMove
        lblHSLGoc_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picHSLThang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picHSLThang.Click
        lblHSLThang_Click(Nothing, Nothing)
    End Sub

    Private Sub picHSLThang_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picHSLThang.MouseLeave
        lblHSLThang_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picHSLThang_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picHSLThang.MouseMove
        lblHSLThang_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picChamCongNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picChamCongNhat.Click
        lblChamCongNhat_Click(Nothing, Nothing)
    End Sub

    Private Sub picChamCongNhat_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picChamCongNhat.MouseLeave
        lblChamCongNhat_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picChamCongNhat_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picChamCongNhat.MouseMove
        lblChamCongNhat_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPTinhLuong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picThietLapPPTinhLuong.Click
        lblThietLapPPTinhLuong_Click(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPTinhLuong_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picThietLapPPTinhLuong.MouseLeave
        lblThietLapPPTinhLuong_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPTinhLuong_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picThietLapPPTinhLuong.MouseMove
        lblThietLapPPTinhLuong_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPChuyenButToan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picThietLapPPChuyenButToan.Click
        lblThietLapPPChuyenButToan_Click(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPChuyenButToan_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picThietLapPPChuyenButToan.MouseLeave
        lblThietLapPPChuyenButToan_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picThietLapPPChuyenButToan_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picThietLapPPChuyenButToan.MouseMove
        lblThietLapPPChuyenButToan_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picTinhLuong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picTinhLuong.Click
        lblTinhLuong_Click(Nothing, Nothing)
    End Sub

    Private Sub picTinhLuong_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picTinhLuong.MouseLeave
        lblTinhLuong_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picTinhLuong_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picTinhLuong.MouseMove
        lblTinhLuong_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub picChuyenButToan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picChuyenButToan.Click
        lblChuyenButToan_Click(Nothing, Nothing)
    End Sub

    Private Sub picChuyenButToan_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picChuyenButToan.MouseLeave
        lblChuyenButToan_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub picChuyenButToan_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picChuyenButToan.MouseMove
        lblChuyenButToan_MouseMove(Nothing, Nothing)
    End Sub

    Private Sub lblHSLGoc_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHSLGoc.MouseLeave
        LoadImageMouseLeave(picHSLGoc.Name)
    End Sub

    Private Sub lblHSLGoc_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblHSLGoc.MouseMove
        LoadImageMouseMove(picHSLGoc.Name)
    End Sub

    Private Sub lblHSLThang_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHSLThang.MouseLeave
        LoadImageMouseLeave(picHSLThang.Name)
    End Sub

    Private Sub lblHSLThang_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblHSLThang.MouseMove
        LoadImageMouseMove(picHSLThang.Name)
    End Sub

    Private Sub lblChamCongNhat_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChamCongNhat.MouseLeave
        LoadImageMouseLeave(picChamCongNhat.Name)
    End Sub

    Private Sub lblChamCongNhat_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChamCongNhat.MouseMove
        LoadImageMouseMove(picChamCongNhat.Name)
    End Sub

    Private Sub lblThietLapPPTinhLuong_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblThietLapPPTinhLuong.MouseLeave
        LoadImageMouseLeave(picThietLapPPTinhLuong.Name)
    End Sub

    Private Sub lblThietLapPPTinhLuong_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblThietLapPPTinhLuong.MouseMove
        LoadImageMouseMove(picThietLapPPTinhLuong.Name)
    End Sub

    Private Sub lblThietLapPPChuyenButToan_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblThietLapPPChuyenButToan.MouseLeave
        LoadImageMouseLeave(picThietLapPPChuyenButToan.Name)
    End Sub

    Private Sub lblThietLapPPChuyenButToan_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblThietLapPPChuyenButToan.MouseMove
        LoadImageMouseMove(picThietLapPPChuyenButToan.Name)
    End Sub

    Private Sub lblTinhLuong_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTinhLuong.MouseLeave
        LoadImageMouseLeave(picTinhLuong.Name)
    End Sub

    Private Sub lblTinhLuong_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTinhLuong.MouseMove
        LoadImageMouseMove(picTinhLuong.Name)
    End Sub

    Private Sub lblChuyenButToan_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChuyenButToan.MouseLeave
        LoadImageMouseLeave(picChuyenButToan.Name)
    End Sub

    Private Sub lblChuyenButToan_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChuyenButToan.MouseMove
        LoadImageMouseMove(picChuyenButToan.Name)
    End Sub

    Private Sub lblHSLGoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHSLGoc.Click
        If ReturnPermission("D13F2012") >= EnumPermission.View Then
            LoadImageMouseClick(picHSLGoc.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picHSLGoc.Name

            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "Path", "04")
            CallFormThread("D13D2040", "D13F2012", arrPro)

            '            ' 14/1/2014 id 60442
            '            Dim f As New D13M2040
            '            With f
            '                .FormActive = enumD13E2040Form.D13F2012
            '                ' 20/11/2013 id 61095
            '                .ID01 = "04" '   .ID01 = "01"
            '                .PayRollVoucherID = gsPayRollVoucherID
            '                .ShowDialog()
            '                .Dispose()
            '            End With

        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Ho_so_luong_goc"))
        End If
    End Sub

    Private Sub lblHSLThang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHSLThang.Click
        If ReturnPermission("D13F2010") >= EnumPermission.View Then
            LoadImageMouseClick(picHSLThang.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picHSLThang.Name

            CallFormThread("D13D2040", "D13F2010")

            '            Dim f As New D13M2040
            '            With f
            '                .FormActive = enumD13E2040Form.D13F2010
            '                .PayRollVoucherID = gsPayRollVoucherID
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Ho_so_luong_thang"))
        End If
    End Sub

    Private Sub lblChamCongNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChamCongNhat.Click
        If ReturnPermission("D13F2020") >= EnumPermission.View Then
            LoadImageMouseClick(picChamCongNhat.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picChamCongNhat.Name

            CallFormThread("D13D2240", "D13F2040")
            '            Dim f As New D13M2240
            '            With f
            '                .FormActive = enumD13E2240Form.D13F2040
            '                .PayRollVoucherID = gsPayRollVoucherID
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Cham_cong_nhat"))
        End If
    End Sub

    Private Sub lblThietLapPPTinhLuong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblThietLapPPTinhLuong.Click
        If ReturnPermission("D13F2050") >= EnumPermission.View Then
            LoadImageMouseClick(picThietLapPPTinhLuong.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picThietLapPPTinhLuong.Name

            CallFormShow("D13D0140", "D13F2050")
            '            Dim f As New D13M0140
            '            With f
            '                .FormActive = enumD13E0140Form.D13F2050
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Thiet_lap_phuong_phap_tinh_luong"))
        End If
    End Sub

    Private Sub lblThietLapPPChuyenButToan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblThietLapPPChuyenButToan.Click
        If ReturnPermission("D13F2060") >= EnumPermission.View Then
            LoadImageMouseClick(picThietLapPPChuyenButToan.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picThietLapPPChuyenButToan.Name

            CallFormShow("D13D0140", "D13F2060")
            '            Dim f As New D13M0140
            '            With f
            '                .FormActive = enumD13E0140Form.D13F2060
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Thiet_lap_phuong_phap_chuyen_but_toan"))
        End If
    End Sub

    Private Sub lblTinhLuong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTinhLuong.Click
        If ReturnPermission("D13F2040") >= EnumPermission.View Then
            LoadImageMouseClick(picTinhLuong.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picTinhLuong.Name

            CallFormThread("D13D2240", "D13F2040")
            '            Dim f As New D13M2240
            '            With f
            '                .FormActive = enumD13E2240Form.D13F2040
            '                .PayRollVoucherID = gsPayRollVoucherID
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Tinh_luong_Main"))
        End If
    End Sub

    Private Sub lblChuyenButToan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChuyenButToan.Click
        If ReturnPermission("D13F3010") >= EnumPermission.View Then
            LoadImageMouseClick(picChuyenButToan.Name)
            LoadImageMouseLeave(sNamePicClick)
            sNamePicClick = picChuyenButToan.Name

            CallFormThread("D13D0440", "D13F3010")
            '            Dim f As New D13M0440
            '            With f
            '                .FormActive = enumD13E0440Form.D13F3010
            '                .ShowDialog()
            '                .Dispose()
            '            End With
        Else
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao") & " " & rL3("Chuyen_but_toan"))
        End If
    End Sub

    Private Sub mnuReportCustomized_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCustomized.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "D13")
        CallFormShow("D89D0140", "D89F9100", arrPro)

        '        Dim f As New D09F9100
        '        f.ShowDialog()
        '        f.Dispose()
    End Sub

    'Menu không dùng
    'Private Sub mnuStatusCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatusCloseBook.Click
    '    Dim exe As New D90E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
    '    exe.FormActive = D90E0140Form.D90F5553
    '    exe.FormPermission = "D90F5553" 'Không phân quyền nên truyền vào chính nó
    '    exe.ModuleID = D13
    '    exe.Run()
    'End Sub

    Private Sub Frames_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frames.Disposed
        'Chuẩn hóa D09U2222 B5: giải phóng frames
        'TableLayoutPanel1.Controls.Remove(Frames)
        picMain.Visible = True
    End Sub

    'Nghiệp vụ -->A. Hồ sơ lương cá nhân
    Private Sub mnuTransactionSalaryPersonalFolder_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSalaryPersonalFolder.Click
        ' 14/1/2014 id 60442 - chuyển sang Danh mục\Hồ sơ lương
        '        Dim f As New D13M2040
        '        With f
        '            .FormActive = enumD13E2040Form.D13F2012
        '            ' 20/11/2013 id 61095
        '            .ID01 = "04" '   .ID01 = "01"
        '            .PayRollVoucherID = gsPayRollVoucherID
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->A. Hồ sơ lương tháng
    Private Sub mnuTransactionSalaryMonthFolder_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSalaryMonthFolder.Click
        CallFormThread("D13D2040", "D13F2010")
        '        Dim f As New D13M2040
        '        With f
        '            .FormActive = enumD13E2040Form.D13F2010
        '            .PayRollVoucherID = gsPayRollVoucherID
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->B. Điều chỉnh thu nhập
    Private Sub mnuTransactionCheckDaily_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCheckDaily.Click
        CallFormThread("D13D2140", "D13F2020")
        '        Dim f As New D13M2140
        '        With f
        '            .FormActive = enumD13E2140Form.D13F2020
        '            .PayRollVoucherID = gsPayRollVoucherID
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->C. Tính lương
    Private Sub mnuTransactionSalaryCalculating_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionSalaryCalculating.Click
        CallFormThread("D13D2240", "D13F2040")
        '        Dim f As New D13M2240
        '        With f
        '            .FormActive = enumD13E2240Form.D13F2040
        '            .PayRollVoucherID = gsPayRollVoucherID
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->D. Kết quả chuyển bút toán
    Private Sub mnuTransactionResultCal_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionResultCal.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", 0)
        CallFormThread("D13D0240", "D13F2110", arrPro)
        '        Dim f As New D13M0240
        '        With f
        '            .FormActive = enumD13E0240Form.D13F2110
        '            .PayRollVoucherID = gsPayRollVoucherID
        '            .FormState = EnumFormState.FormAdd
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->E. Khai thuế TNCN
    Private Sub mnuTransactionPublicPersonalIncome_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionPublicPersonalIncome.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", 0)
        CallFormThread("D13D0240", "D13F2071", arrPro)
        '        Dim frm As New D13M0240
        '        With frm
        '            .FormActive = enumD13E0240Form.D13F2071
        '            .FormState = EnumFormState.FormAdd
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    'Nghiệp vụ -->F. Quyết toán thuế TNCN
    Private Sub mnuTransactionCalculateTaxIncome_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionCalculateTaxIncome.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", 0)
        CallFormThread("D13D0240", "D13F2081", arrPro)
        '        Dim frm As New D13M0240
        '        With frm
        '            .FormActive = enumD13E0240Form.D13F2081
        '            .FormState = EnumFormState.FormAdd
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuReportSalaryFolder_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSalaryFolder.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CallFormID", "D13F4050")
        CallFormShow("D13D0140", "D13F4050", arrPro)
        '        Dim frm As New D13F4050
        '        With frm
        '            .CallForm = "D13F4050"
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuListLeaveObjects_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListLeaveObjects.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F1170")
        CallFormShow("D15D0140", "D15F1040", arrPro)
        '        Dim f As New D15M0140
        '        With f
        '            .FormActive = enumD15E0140Form.D15F1040
        '            .FormPermission = "D13F1170"
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub


    Private Sub mnuListCollaborator_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCollaborator.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D13D0140", "D13F1190", arrPro)
    End Sub


    Private Sub mnuSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalary.Click
        CallFormShow("D13D0140", "D13F1180")
        '        Dim exe As New D13E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        '        exe.FormActive = enumD13E0140Form.D13F1180
        '        exe.FormPermission = "D13F1180"
        '        exe.Run()
    End Sub

    Private Sub mnuReportFamily_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportFamily.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CallFormID", "D13F4090")
        CallFormShow("D13D0140", "D13F4050", arrPro)
        '        Dim frm As New D13F4050
        '        With frm
        '            .CallForm = "D13F4090"
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    ' Thông tin tham chiếu
    Private Sub mnuSetupOther_ReferenceData_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSetupOther_ReferenceData.Click
        CallFormShow("D09D0940", "D09F0150") ' Kiểm tra bên D09 thấy ko sử dụng các tham số (FormPermission, ModuleID)
        '        Dim exe As New D09E0940(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        '        exe.FormActive = D09E0940Form.D09F0150
        '        exe.FormPermission = "D13F0060"
        '        exe.ModuleID = "13"
        '        exe.Run()
    End Sub

    ' update 31/7/2013 id 58217
    Private Sub mnuSystemLockVouchers_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLockVouchers.Click
        CallFormShowDialog("D13D0940", "D13F5557")
        '        Dim frm As New D13F5557
        '        With frm
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    ' Nghiệp vụ\Hồi tố lương
    Private Sub mnuTransasionBackPay_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransasionBackPay.Click
        CallFormThread("D13D2340", "D13F2090")
        ' RunEXEDxxExx40("D13E2340", "D13F2090")
    End Sub

    'Truy vấn\Danh sách nhân viên hồi tố lương
    Private Sub mnuInquiryBackPay_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryBackPay.Click
        CallFormThread("D13D2340", "D13F2090")
        ' RunEXEDxxExx40("D13E2340", "D13F2090")
    End Sub

    'Truy vấn\Danh sách nhân viên hồi tố lương
    Private Sub mnuInquiryPayrollByProjects_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryPayrollByProjects.Click
        CallFormThread("D13D2340", "D13F3080")
        ' RunEXEDxxExx40("D13E2340", "D13F2090")
    End Sub
    ' 14/1/2014 id 60406
    Private Sub mnuTransForecastAndCalculateSeveranceAllowance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransForecastAndCalculateSeveranceAllowance.Click
        ' RunEXEDxxExx40("D13E2140", "D13F3020")
        CallFormThread("D13D2140", "D13F3020")
    End Sub

    ' Danh mục Tỷ giá
    Private Sub mnuListExchangeRate_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListExchangeRate.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D13D1140", "D13F1200", arrPro)
        '  RunEXEDxxExx40("D13E1140", "D13F1200", EnumFormState.FormView)
    End Sub

    'Danh muc Nguyên tệ
    Private Sub mnuListCurrencies_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCurrencies.Click
        ' RunEXEDxxExx40("D91E1140", "D91F1001", "D13F1210")

        'ID 79394 8/9/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F1210")
        CallFormShow(Me, "D91D1140", "D91F1001", arrPro)
    End Sub

    Private Sub mnuStatisticSalary_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisticSalary.Click
        CallFormShow("D13D4040", "D13F4200")
        '  RunEXEDxxExx40("D13E4040", "D13F4200")
    End Sub

    Private Sub mnuStatisticSalarySetting_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisticSalarySetting.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "13")
        SetProperties(arrPro, "ID01", "D13F4200")
        SetProperties(arrPro, "Type", L3Byte(1))
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormShow("D09D4140", "D09F4120", arrPro)
        '        Dim exe As New DxxExx40("D09E4140", gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        '        With exe
        '            .FormActive = "D09F4120" 'Form cần hiển thị
        '            '  .FormPermission = "D13F4200" 'Mã màn hình phân quyền
        '            .IDxx("ID01") = "D13F4200"
        '            .IDxx("Type") = "1"
        '            .Run()
        '        End With
    End Sub


    Private Sub mnuPlanSalary_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisPlanSalary.Click

    End Sub
End Class
