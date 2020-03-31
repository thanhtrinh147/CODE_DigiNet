﻿'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:10:02 PM
'# Created User: Lê Văn Phước
'# Modify Date: 01/08/2006 4:10:02 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D25F0000
    Private WithEvents Frames As D25U2224 'D09U2222
    Private Const D25P0030 As String = "\Bitmap\D25P0030.jpg"
    Private Const D25P0031 As String = "\Bitmap\D25P0031.jpg"

#Region "User Control D99U0000 (gồm 5 bước)"
    'UserControl D99U0000 dùng để hiển thị cây menu
    'Chuẩn hóa sử dụng D99U0000 cho form DxxF0000: gồm 5 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D99U0000 B" để tìm các bước chuẩn sử dụng D99U0000
    'Chuẩn hóa D99U0000 B1: đinh nghĩa biến
    Dim t As New D99U0000()
#End Region

    Private Sub LoadStatusStrip()
        sbServerName.Text = gsServer.ToUpper
        sbCompany.Text = gsCompanyID.ToUpper
        sbUserID.Text = gsUserID.ToUpper
        sbCurrentDate.Text = Date.Now.ToShortDateString
    End Sub

    Private Sub LoadBitmap()
        If geLanguage = EnumLanguage.Vietnamese Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D25P0030) Then 'My.Application.Info.DirectoryPath & D25P0030) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D25P0030) 'My.Application.Info.DirectoryPath & D25P0030)
                picMain.BackgroundImage = bmp
            End If
        ElseIf geLanguage = EnumLanguage.English Then
            If My.Computer.FileSystem.FileExists(gsApplicationSetup & D25P0031) Then 'My.Application.Info.DirectoryPath & D25P0031) Then
                Dim bmp As New Bitmap(gsApplicationSetup & D25P0031) 'My.Application.Info.DirectoryPath & D25P0031)
                picMain.BackgroundImage = bmp
            End If
        End If
    End Sub

    Private Sub Loadlanguage(Optional ByVal bLoadFirst As Boolean = False)
        If geLanguage = EnumLanguage.Vietnamese Then
            mnuSystemLanguageVietnamese.Checked = True
            mnuSystemLanguageEnglish.Checked = False
        Else
            mnuSystemLanguageVietnamese.Checked = False
            mnuSystemLanguageEnglish.Checked = True
        End If
        LoadMenuShortcut()
        LoadBitmap()
        MsgAnnouncement = IIf(geLanguage = EnumLanguage.Vietnamese, "Th¤ng bÀo", "Announcement").ToString
        If bLoadFirst = False Then
            SetTextMenu(C1MainMenu) ': mnuListInterviewer.Text = rL3("Nguoi_phong_van")
            C1CommandLink53.Text = mnuListInterviewer.Text
            C1CommandLink47.Text = mnuReportRecruitmentFile.Text
        End If
        
    End Sub

    Private Sub LoadMenuShortcut()

        'Hệ thống
        mnuSystem.Text = rL3("_He_thong") '&Hệ thống
        mnuSystemSetup.Text = rL3("Thiet_lap_he_thong") 'Thiết lập hệ thống
        'IncidentID 50850 Phương pháp tạo mã tự động
        mnuSystemAutoIGEList.Text = rL3("Phuong_phap_tao_ma_tu_dong")  ' Phương pháp tạo mã tự động
        mnuOtherSetup.Text = rL3("Thiet_lap_khac") 'Thiết lập khác
        mnuReferenceInfo.Text = rL3("Thong_tin_tham_chieu") 'Thông tin tham chiếu
        mnuSystemOtherSetupInput.Text = rL3("Kiem_tra_du_lieu_dau_vao")
        mnuSystemOption.Text = rL3("Tuy_chon") 'Tùy chọn
        mnuSystemLanguage.Text = rL3("Ngon_ngu")
        mnuSystemLanguageVietnamese.Text = rL3("Tieng_Viet") 'Tiếng Việt
        mnuSystemLanguageEnglish.Text = rL3("Tieng_Anh") 'Tiếng Anh
        mnuSystemQuit.Text = "&X  " & rL3("Thoat") 'Thoát

        'Nghiệp vụ
        mnuTransaction.Text = rl3("_Nghiep_vu") '&Nghiệp vụ
        mnuTransactionGeneralRecruitmentPlan.Text = rL3("Lap_ke_hoach_tong_the") 'rl3("Lap_ke_hoach_tuyen_dung") 'Lập kế hoạch tuyển dụng tổng thể
        mnuTransaction_MakeRecruitProposalID.Text = rL3("Lap_de_xuat_tuyen_dung") 'Lập đề xuất tuyển dụng
        mnuTransaction_ApproveRecruitProposalID.Text = rL3("Duyet_de_xuat_tuyen_dung") 'Duyệt đề xuất tuyển dụng
        mnuTransaction_MakeRecruitPlan.Text = rL3("Lap_ke_hoach_tong_the") 'rl3("Lap_ke_hoach_tuyen_dung") 'Lập kế hoạch tuyển dụng
        mnuTransaction_MakeRecruitPlan.Visible = False
        mnuTransaction_ApproveRecruitPlan.Text = rL3("Duyet_ke_hoach_tuyen_dung") 'Duyệt kế hoạch tuyển dụng
        mnuTransaction_ApproveRecruitPlan.Visible = False
        mnuTransactionRecruitmentFile.Text = rL3("Lap_ke_hoach_tuyen_dung") 'rl3("Lap_ke_hoach_thuc_hien") 'rl3("Lap_dot_tuyen_dung") 'Lập đợt tuyển dụng
        mnuTransactionMakeRecruitAnnouncement.Text = rL3("Lap_thong_bao_tuyen_dung") 'Lập thông báo tuyển dụng
        mnuTransactionInterviewFile.Text = rL3("Lap_lich_phong_van") 'Lập lịch phỏng vấn
        mnuTransactionRecruitDecision.Text = rL3("Quyet_dinh_tuyen_dung") 'Quyết định tuyển dụng
        mnuTransactionInterviewResult.Text = rL3("Danh_gia_ket_qua_phong_van") 'Đánh giá kết quả phỏng vấn
        mnuTransactionAppRecruitDecision.Text = rL3("Duyet_quyet_dinh_tuyen_dung") 'Duyệt quyết định tuyển dụng
        mnuTransactionRecruitmentCost.Text = rL3("Chi_phi_tuyen_dung_U") 'Chi phí tuyển dụng
        mnuTransactionGeneralApprovedPlan.Text = rL3("Duyet_ke_hoach_tong_the") 'Duyệt kế hoạch tổng thể
        mnuTransaction_FilterCV.Text = rL3("Sang_loc_ho_so_ung_vien")
        'Truy vấn
        mnuInquiry.Text = rl3("_Truy_van") ' &Truy vấn
        mnuInquiryGeneralRecruitmentPlan.Text = rL3("Ke_hoach_tong_the") 'Kế hoạch tuyển dụng tổng thể
        mnuInquiry_RecruitProposalID.Text = rL3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
        mnuInquiry_RecruitPlan.Text = rL3("Ke_hoach_tong_the") 'rl3("Ke_hoach_tuyen_dung") 'Kế hoạch tuyển dụng
        mnuInquiry_RecruitPlan.Visible = False
        mnuInquiryRecruitAnouncement.Text = rL3("Thong_bao_tuyen_dung") 'Thông báo tuyển dụng
        mnuInquiryRecruitmentFile.Text = rL3("Ke_hoach_tuyen_dung") 'rl3("Ke_hoach_thuc_hien") 'rl3("Dot_tuyen_dung") 'Đợt tuyển dụng
        'Mở rem 16/12/2010 - ID35835
        'mnuInquiryInterviewFile.Visible = False
        mnuInquiryInterviewFile.Text = rL3("Lich_phong_van") 'Lịch phỏng vấn
        mnuInquiryResultInterview.Text = rL3("Ket_qua_phong_van") 'Kết quả phỏng vấn
        mnuInquiryRecruitDecision.Text = rL3("Quyet_dinh_tuyen_dung") 'Quyết định tuyển dụng
        mnuInquiryRecruitmentCost.Text = rL3("Chi_phi_tuyen_dung_U") 'Chi phí tuyển dụng
        'mnuInquiryRecruitDecision.Visible = False
        'mnuInquiryRecruitmentCost.Text = "&I  " & rl3("Chi_phi_tuyen_dung_U") 'Chi phí tuyển dụng
        'Thống kê & Phân tích
        mnuStatis.Text = rl3("Thong_ke_____Phan_tich")
        mnuStatisResultEmploy.Text = rL3("Ket_qua_tuyen_dung") 'Kết quả tuyển dụng
        mnuStatisRecFileStatistic.Text = rL3("Thong_ke_ke_hoach_tuyen_dungU") 'Thống kê kế hoạch tuyển dụng
        mnuStatisTime.Text = rL3("Thoi_gian_thuc_hien_tuyen_dungU")
        mnuStatisCompareGeneral.Text = rL3("So_sanh_ke_hoach_tuyen_dung_voi_de_xuat_tuyen_dung_trong_nam") 'So sánh kế hoạch tuyển dụng với đề xuất tuyển dụng trong năm

        'Báo cáo
        mnuReport.Text = rl3("_Bao_cao") '&Báo cáo
        mnuReportGeneralRecruitPlan.Text = rL3("Ke_hoach_tong_the") 'rl3("Ke_hoach_tuyen_dung")
        mnuReportCandidate.Text = rL3("Danh_sach_ung_cu_vienU") 'Danh sách ứng cử viên
        mnuReportInspectRecruit.Text = rL3("De_xuat_tuyen_dung") 'Phiếu đề xuất tuyển dụng
        mnuReportRecruitPlan.Text = rL3("Ke_hoach_tuyen_dung") 'Kế hoạch tuyển dụng
        ' mnuReportRecruitPlan.Visible = False
        mnuReportRecruitAnouncement.Text = rL3("Thong_bao_tuyen_dung") 'Thông báo tuyển dụng
        mnuReportInterviewSchedule.Text = rL3("Lich_phong_van") & "/" & rL3("Thu_moi") 'Lịch phỏng vấn
        mnuReportResultInterview.Text = rL3("Danh_gia_ket_qua_phong_van") 'Đánh giá kết quả phỏng vấn
        mnuReportResultInterview.Visible = False
        mnuReportRecruitmentFile.Text = rL3("Ket_qua_tuyen_dung") 'Kết quả tuyển dụng
        '  C1CommandLink47.Text = rL3("Ket_qua_tuyen_dung") 'Kết quả tuyển dụng
        mnuRecruitCost.Text = rL3("Chi_phi_tuyen_dung_U") 'Chi phí tuyển dụng
        mnuReportCustomized.Text = rL3("Bao_cao_dac_thu") 'Báo cáo đặc thù
        mnuReportEstablish.Text = rL3("Thiet_lap") ' Thiết lập
        mnuReportItem.Text = rL3("Mau_bao_cao") 'Mẫu báo cáo
        mnuReportSyntheticInterview.Text = rL3("Ket_qua_phong_van_tong_hop") 'Kết quả phỏng vấn tổng hợp

        'Danh mục
        mnuList.Text = rl3("_Danh_muc") '&Danh mục
        mnuListCandidate.Text = rL3("Ho_so_ung_cu_vien") 'Hồ sơ ứng cử viên
        mnuListResource.Text = rL3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        mnuListEvaluationCriteria.Text = rL3("Chi_tieu_danh_gia") 'Chỉ tiêu đánh giá
        mnuListRecPosition.Text = rL3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển
        mnuListRecCost.Text = rL3("Chi_phi_tuyen_dung_U") 'Chi phí tuyển dụng
        mnuListInterviewer.Text = rL3("Nguoi_phong_van")
        C1CommandLink53.Text = rL3("Nguoi_phong_van")
        mnuListIntGroup.Text = rL3("Nhom_phong_van")
        mnuListTransactionType.Text = rL3("Loai_nghiep_vu") ' Loại nghiệp vụ
        mnuListCandidateFileTransaction.Text = rL3("Loai_nghiep_vu_HS_ung_cu_vien")
        mnuListWarning.Text = rL3("Canh_bao")
        'Trợ giúp
        mnuHelp.Text = rl3("Tro__giup") ' Trợ &giúp
        mnuHelpContent.Text = rL3("Noi_dung") 'Nội dung
        mnuHelpIndex.Text = rL3("Chi_muc") 'Chỉ mục

        mnuPeriod.Text = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID

        '================================================================ 
        Me.Text = rl3("Tuyen_dung_-_D25F0000") 'TuyÓn dóng - D25F0000
        '================================================================ 
        'sbServerNameCaption.Text = rl3("Ten_may_chu")
        sbCompanyCaption.Text = rl3("Doanh_nghiep")
        sbUserIDCaption.Text = rl3("Nguoi_dung")

        'stbMain.Items(0).Text = rl3("Ten_may_chu")
        'stbMain.Items(2).Text = rl3("Doanh_nghiep")
        'stbMain.Items(4).Text = rl3("Nguoi_dung")
    End Sub

    'Sub này không ảnh hưởng bởi biến gbClosed
    'Private Sub SetMenuPermission()
    '    'Phân quyền cho menu Hệ thống
    '    mnuSystemSetup.Enabled = ReturnPermission("D25F0001") >= EnumPermission.View
    '    mnuSystemOption.Enabled = ReturnPermission("D25F0002") >= EnumPermission.View
    '    mnuPeriod.Enabled = ReturnPermission("D25F0003") >= EnumPermission.View
    '    'C1CommandLink13.Enabled = ReturnPermission("D25F0003") >= EnumPermission.View
    '    mnuOtherSetup.Enabled = ReturnPermission("D25F0050") >= EnumPermission.View

    '    mnuSystemAutoIGEList.Enabled = ReturnPermission("D09F1600") >= EnumPermission.View     'IncidentID 50850 Phương pháp tạo mã tự động

    '    'Phân quyền cho menu Truy vấn
    '    'mnuInquiryXxxxx.Enabled = ReturnPermission("D25Fxxxx") >= EnumPermission.View
    '    mnuInquiry_RecruitProposalID.Enabled = ReturnPermission("D25F2020") >= EnumPermission.View
    '    mnuInquiry_RecruitPlan.Enabled = ReturnPermission("D25F3030") >= EnumPermission.View
    '    mnuInquiryRecruitmentFile.Enabled = ReturnPermission("D25F3010") >= EnumPermission.View
    '    mnuInquiryInterviewFile.Enabled = ReturnPermission("D25F3020") >= EnumPermission.View
    '    mnuInquiryResultInterview.Enabled = ReturnPermission("D25F3040") >= EnumPermission.View
    '    mnuInquiryRecruitAnouncement.Enabled = ReturnPermission("D25F3070") >= EnumPermission.View
    '    mnuInquiryGeneralRecruitmentPlan.Enabled = ReturnPermission("D25F3080") >= EnumPermission.View
    '    mnuInquiryRecruitmentCost.Enabled = ReturnPermission("D25F3090") >= EnumPermission.View
    '    mnuStatisResultEmploy.Enabled = ReturnPermission("D25F3050") >= EnumPermission.View
    '    mnuInquiryRecruitDecision.Enabled = ReturnPermission("D25F3060") >= EnumPermission.View
    '    mnuStatisRecFileStatistic.Enabled = ReturnPermission("D25F3051") >= EnumPermission.View
    '    mnuStatisTime.Enabled = ReturnPermission("D25F3200") >= EnumPermission.View
    '    'Phân quyền cho menu Báo cáo
    '    'mnuReportXxxxx.Enabled = ReturnPermission("D25Fxxxx") >= EnumPermission.View
    '    mnuReportCandidate.Enabled = ReturnPermission("D25F4000") >= EnumPermission.View
    '    mnuReportRecruitmentFile.Enabled = ReturnPermission("D25F4010") >= EnumPermission.View
    '    mnuReportResultInterview.Enabled = ReturnPermission("D25F4020") >= EnumPermission.View
    '    mnuReportInspectRecruit.Enabled = ReturnPermission("D25F4050") >= EnumPermission.View
    '    '        mnuReportRecruitPlan.Enabled = ReturnPermission("D25F4060") >= EnumPermission.View
    '    mnuReportRecruitPlan.Enabled = ReturnPermission("D25F4060") >= EnumPermission.View
    '    mnuReportRecruitAnouncement.Enabled = ReturnPermission("D25F4070") >= EnumPermission.View
    '    mnuReportGeneralRecruitPlan.Enabled = ReturnPermission("D25F4090") >= EnumPermission.View
    '    mnuReportInterviewSchedule.Enabled = ReturnPermission("D25F4080") >= EnumPermission.View
    '    mnuReportCustomized.Enabled = ReturnPermission("D25F9100") >= EnumPermission.View
    '    mnuReportItem.Enabled = ReturnPermission("D25F9101") >= EnumPermission.View
    '    mnuRecruitCost.Enabled = ReturnPermission("D25F4040") >= EnumPermission.View

    '    'Phân quyền cho menu Danh mục
    '    'mnuListXxxxx.Enabled = ReturnPermission("D25Fxxxx") >= EnumPermission.View
    '    mnuListCandidate.Enabled = ReturnPermission("D25F1050") >= EnumPermission.View
    '    mnuListResource.Enabled = ReturnPermission("D25F1010") >= EnumPermission.View
    '    mnuListEvaluationCriteria.Enabled = ReturnPermission("D25F1110") >= EnumPermission.View
    '    mnuListRecPosition.Enabled = ReturnPermission("D25F1020") >= EnumPermission.View
    '    mnuListRecCost.Enabled = ReturnPermission("D25F1030") >= EnumPermission.View
    '    mnuListInterviewer.Enabled = ReturnPermission("D25F1070") >= EnumPermission.View
    '    mnuListTransactionType.Enabled = ReturnPermission("D25F1060") >= EnumPermission.View
    '    mnuListCandidateFileTransaction.Enabled = ReturnPermission("D25F1080") >= EnumPermission.View
    '    mnuListWarning.Enabled = ReturnPermission("D25F5611") >= EnumPermission.View
    '    mnuListIntGroup.Enabled = ReturnPermission("D25F1090") >= EnumPermission.View
    'End Sub

    'Sub này có ảnh hưởng bởi biến gbClosed
    'Private Sub SetMenuPermissionTransaction()
    '    'Phân quyền cho menu Hệ thống phụ thuộc vào biến gbClosed
    '    mnuSystemCloseBook.Enabled = Not gbClosed
    '    mnuSystemNewPeriod.Enabled = True
    '    mnuSystemOpenBook.Enabled = gbClosed
    '    'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
    '    'mnuTransactionXxxxxxx.Enabled = (Not gbClosed) And ReturnPermission("D25Fxxxx") > EnumPermission.View
    '    mnuTransaction_MakeRecruitProposalID.Enabled = (Not gbClosed) And ReturnPermission("D25F3000") > EnumPermission.View
    '    mnuTransaction_ApproveRecruitProposalID.Enabled = (Not gbClosed) And ReturnPermission("D25F2020") > EnumPermission.View
    '    mnuTransaction_MakeRecruitPlan.Enabled = (Not gbClosed) And ReturnPermission("D25F3030") > EnumPermission.View
    '    mnuTransaction_ApproveRecruitPlan.Enabled = (Not gbClosed) And ReturnPermission("D25F3030") > EnumPermission.View
    '    mnuTransactionRecruitmentFile.Enabled = (Not gbClosed) And ReturnPermission("D25F3010") > EnumPermission.View
    '    mnuTransactionInterviewFile.Enabled = (Not gbClosed) And ReturnPermission("D25F3020") > EnumPermission.View
    '    mnuTransactionMakeRecruitAnnouncement.Enabled = (Not gbClosed) And ReturnPermission("D25F2070") > EnumPermission.View
    '    mnuTransactionGeneralRecruitmentPlan.Enabled = (Not gbClosed) And ReturnPermission("D25F3080") > EnumPermission.View
    '    mnuTransactionRecruitmentCost.Enabled = (Not gbClosed) And ReturnPermission("D25F3090") > EnumPermission.View
    '    mnuTransactionRecruitDecision.Enabled = (Not gbClosed) And ReturnPermission("D25F3060") > EnumPermission.View
    '    mnuTransactionInterviewResult.Enabled = (Not gbClosed) And ReturnPermission("D25F3040") > EnumPermission.View
    '    mnuTransactionAppRecruitDecision.Enabled = (Not gbClosed) And ReturnPermission("D25F2100") > EnumPermission.View
    'End Sub

    Private Sub SetMenuPermission()
        'Phân quyền cho menu Hệ thống
        VisibledMenu(mnuSystemSetup, "D25F0001")
        VisibledMenu(mnuSystemOption, "D25F0002")
        mnuPeriod.Enabled = ReturnPermission("D25F0003") >= EnumPermission.View
        VisibledMenu(mnuOtherSetup, "D25F0050")
        VisibledMenu(mnuSystemOtherSetupInput, "D25F0066")

        VisibledMenu(mnuSystemAutoIGEList, "D09F1600")    'IncidentID 50850 Phương pháp tạo mã tự động

        'Phân quyền cho menu Truy vấn
        'mnuInquiryXxxxx, "D25Fxxxx") >= EnumPermission.View
        VisibledMenu(mnuInquiry_RecruitProposalID, "D25F3000")
        VisibledMenu(mnuInquiry_RecruitPlan, "D25F3030")
        VisibledMenu(mnuInquiryRecruitmentFile, "D25F3010")
        VisibledMenu(mnuInquiryInterviewFile, "D25F3020")
        VisibledMenu(mnuInquiryResultInterview, "D25F3040")
        VisibledMenu(mnuInquiryRecruitAnouncement, "D25F3070")
        VisibledMenu(mnuInquiryGeneralRecruitmentPlan, "D25F3080")
        VisibledMenu(mnuInquiryRecruitmentCost, "D25F3090")
        VisibledMenu(mnuStatisResultEmploy, "D25F3050")
        VisibledMenu(mnuInquiryRecruitDecision, "D25F3060")
        VisibledMenu(mnuStatisRecFileStatistic, "D25F3051")
        VisibledMenu(mnuStatisTime, "D25F3200")
        VisibledMenu(mnuStatisCompareGeneral, "D25F3052")

        'Phân quyền cho menu Báo cáo
        'mnuReportXxxxx, "D25Fxxxx") >= EnumPermission.View
        VisibledMenu(mnuReportCandidate, "D25F4000")
        VisibledMenu(mnuReportRecruitmentFile, "D25F4010")
        VisibledMenu(mnuReportResultInterview, "D25F4020")
        VisibledMenu(mnuReportInspectRecruit, "D25F4050")
        '        mnuReportRecruitPlan, "D25F4060") >= EnumPermission.View
        VisibledMenu(mnuReportRecruitPlan, "D25F4060")
        VisibledMenu(mnuReportRecruitAnouncement, "D25F4070")
        VisibledMenu(mnuReportGeneralRecruitPlan, "D25F4090")
        VisibledMenu(mnuReportInterviewSchedule, "D25F4080")
        VisibledMenu(mnuReportCustomized, "D25F9100")
        VisibledMenu(mnuReportItem, "D25F9101")
        VisibledMenu(mnuRecruitCost, "D25F4040")
        VisibledMenu(mnuReportSyntheticInterview, "D25F4100")

        'Phân quyền cho menu Danh mục
        'mnuListXxxxx, "D25Fxxxx") >= EnumPermission.View
        VisibledMenu(mnuListCandidate, "D25F1050")
        VisibledMenu(mnuListResource, "D25F1010")
        VisibledMenu(mnuListEvaluationCriteria, "D25F1110")
        VisibledMenu(mnuListRecPosition, "D25F1020")
        VisibledMenu(mnuListRecCost, "D25F1030")
        VisibledMenu(mnuListInterviewer, "D25F1070")
        VisibledMenu(mnuListTransactionType, "D25F1060")
        VisibledMenu(mnuListCandidateFileTransaction, "D25F1080")
        VisibledMenu(mnuListWarning, "D25F5611")
        VisibledMenu(mnuListIntGroup, "D25F1090")
    End Sub

    Private Sub SetEnableMenuPermissionTransaction()
        mnuSystemCloseBook.Enabled = Not gbClosed
        mnuSystemNewPeriod.Enabled = True
        mnuSystemOpenBook.Enabled = gbClosed
        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        'mnuTransactionXxxxxxx.Enabled = (Not gbClosed) And ReturnPermission("D25Fxxxx") > EnumPermission.View
        mnuTransaction_MakeRecruitProposalID.Enabled = (Not gbClosed)
        mnuTransaction_ApproveRecruitProposalID.Enabled = (Not gbClosed) And Not D25Systems.IsUseAppRecruitProposal
        mnuTransaction_MakeRecruitPlan.Enabled = (Not gbClosed)
        mnuTransaction_ApproveRecruitPlan.Enabled = (Not gbClosed)
        mnuTransactionRecruitmentFile.Enabled = (Not gbClosed)
        mnuTransactionInterviewFile.Enabled = (Not gbClosed)
        mnuTransactionMakeRecruitAnnouncement.Enabled = (Not gbClosed)
        mnuTransactionGeneralRecruitmentPlan.Enabled = (Not gbClosed)
        mnuTransactionRecruitmentCost.Enabled = (Not gbClosed)
        mnuTransactionRecruitDecision.Enabled = (Not gbClosed)
        mnuTransactionInterviewResult.Enabled = (Not gbClosed)
        mnuTransactionAppRecruitDecision.Enabled = (Not gbClosed)
        mnuTransactionGeneralApprovedPlan.Enabled = (Not gbClosed)
        mnuTransaction_FilterCV.Enabled = (Not gbClosed)
    End Sub

    Private Sub SetMenuPermissionTransaction()
        'Phân quyền cho menu Nghiệp vụ phụ thuộc vào biến gbClosed
        'mnuTransactionXxxxxxx, "D25Fxxxx") > EnumPermission.View
        VisibledMenuTrans(mnuTransaction_MakeRecruitProposalID, "D25F3000")
        VisibledMenuTrans(mnuTransaction_ApproveRecruitProposalID, "D25F2020")
        VisibledMenuTrans(mnuTransaction_MakeRecruitPlan, "D25F3030")
        VisibledMenuTrans(mnuTransaction_ApproveRecruitPlan, "D25F3030")
        VisibledMenuTrans(mnuTransactionRecruitmentFile, "D25F3010")
        VisibledMenuTrans(mnuTransactionInterviewFile, "D25F3020")
        VisibledMenuTrans(mnuTransactionMakeRecruitAnnouncement, "D25F2070")
        VisibledMenuTrans(mnuTransactionGeneralRecruitmentPlan, "D25F3080")
        VisibledMenuTrans(mnuTransactionRecruitmentCost, "D25F3090")
        VisibledMenuTrans(mnuTransactionRecruitDecision, "D25F3060")
        VisibledMenuTrans(mnuTransactionInterviewResult, "D25F3040")
        VisibledMenuTrans(mnuTransactionAppRecruitDecision, "D25F2100")
        VisibledMenuTrans(mnuTransactionGeneralApprovedPlan, "D25F5601")
        VisibledMenuTrans(mnuTransaction_FilterCV, "D25F2032")
    End Sub

    Private Sub VisibledMenu(ByVal mnu As C1.Win.C1Command.C1Command, ByVal FormPermission As String)
        If mnu.Visible Then mnu.Visible = ReturnPermission(FormPermission) >= EnumPermission.View
    End Sub
    Private Sub VisibledMenuTrans(ByVal mnu As C1.Win.C1Command.C1Command, ByVal FormPermission As String)
        If mnu.Visible Then mnu.Visible = ReturnPermission(FormPermission) > EnumPermission.View
    End Sub

    Private Sub StandardlizeStatusBar()
        stbMain.Items.Remove(sbServerName)
        sbServerNameCaption.Spring = True
        sbServerNameCaption.Text = ""
    End Sub

    Private Sub D25F0000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage(True)
        LoadStatusStrip()
        StandardlizeStatusBar()

        LoadUserControlTreeview()

        mnuHelp.Visible = False

        giTranMonth = Now.Month
        giTranYear = Now.Year
        mnuSystemCloseBook.Visible = False
        mnuSystemNewPeriod.Visible = False
        mnuSystemOpenBook.Visible = False
        picMain.BackgroundImageLayout = ImageLayout.Stretch
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadUserControlTreeview()
        'Minh Hòa update 29/01/2010
        'Load User control Treeview
        t = New D99U0000()
        t.Dock = DockStyle.Right
        t.Location = New Point(0, 17)
        t.ModuleID = D25
        t.FormPermission = "D25F5699"
        TableLayoutPanel1.Controls.Add(t, 0, 0)
    End Sub

    Private Sub mnuSystemQuit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemQuit.Click
        Me.Close()
    End Sub

    Private Sub mnuSystemSetup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemSetup.Click
        'Dim f As New D25F0001
        'f.FormState = EnumFormState.FormEdit
        'f.ShowDialog()
        'If f.bSaved Then mnuTransaction_ApproveRecruitProposalID.Enabled = Not D25Systems.IsUseAppRecruitProposal
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormEdit)
        Dim frm As Form = CallFormShowDialog("D25D0940", "D25F0001", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            LoadSystems() 'Load các thông số cho phần thiết lập hệ thống
            mnuTransaction_ApproveRecruitProposalID.Enabled = Not D25Systems.IsUseAppRecruitProposal
        End If
     
    End Sub

    Private Sub mnuSystemAutoIGEList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemAutoIGEList.Click  'IncidentID 50850 Phương pháp tạo mã tự động
        'Dim f As New D09M0140
        'With f
        '    .FormActive = D09E0140Form.D09F1600
        '    .FormPermission = "D09F1600"
        '    .Mode = "0"
        '    .FormState = EnumFormState.FormView
        '    .ShowDialog()
        '    .Dispose()
        'End With

        'ID 81168 21/10/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "25")
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        SetProperties(arrPro, "FormIDPermission", "D09F1600")
        CallFormShow(Me, "D09D0140", "D09F1600", arrPro)
    End Sub

    Private Sub OpenFormSystem()
        'Dim f As New D25F0001
        'f.FormState = EnumFormState.FormAdd
        'f.ShowDialog()
        'If f.bSaved Then mnuTransaction_ApproveRecruitProposalID.Enabled = Not D25Systems.IsUseAppRecruitProposal
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormEdit)
        Dim frm As Form = CallFormShowDialog("D25D0940", "D25F0001", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            LoadSystems()
            mnuTransaction_ApproveRecruitProposalID.Enabled = Not D25Systems.IsUseAppRecruitProposal
        End If
        'Lấy đơn vị và kỳ kế tóan
        gsDivisionID = D25Systems.DefaultDivisionID
    End Sub

    Private Sub ShowFormSystemsIfNeed()
        Dim sSQL As String = "Select Top 1 1 From D25T0000 WITH(NOLOCK)"
        If Not ExistRecord(sSQL) Then 'Chưa có dữ liệu ở bảng T0000, hiện thị form Thiết lập hệ thống
            OpenFormSystem()
        Else 'Đã có dữ liệu ở bảng T0000
            If D25Options.DefaultDivisionID = "" Then 'Chưa có đơn vị dưới Registry
                gsDivisionID = D25Systems.DefaultDivisionID
                If Not CheckExistDivision() Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                    'OpenFormSystem()
                    End
                End If

            Else 'Đã có dưới Registry rồi
                gsDivisionID = D25Options.DefaultDivisionID
                'Kiểm tra lại có tồn tại đơn vị này không
                If Not CheckExistDivision(True) Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                    gsDivisionID = D25Systems.DefaultDivisionID
                    If Not CheckExistDivision() Then 'Không Có dữ liệu trong bảng T9999 và D91T0016
                        'OpenFormSystem()
                        End
                    End If
                End If
            End If
        End If
        GetMonthYear()
    End Sub

    Private Function CheckExistDivision(Optional ByVal bNoMessage As Boolean = False) As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD91P9020("09") 'xx: Mã module truyền vào 2 ký tự 
        If bNoMessage Then
            Return CheckStoreNoMessage(sSQL)
        Else
            Return CheckStoreDivision(sSQL)
            '  Return CheckStore(sSQL)
        End If
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
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16 WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
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
        gsDivisionID = D25Systems.DefaultDivisionID
        'gbLockedDivisionID = D09Systems.LockedDivisionID
        sSQL = "Select Top 1 T99.TranMonth, T99.TranYear From D09T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16 WITH(NOLOCK) On T99.DivisionID = T16.DivisionID Where T99.DivisionID = " & SQLString(gsDivisionID) & " And T16.Disabled = 0 Order By TranYear Desc, TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then 'Có dữ liệu trong bảng D09T9999 và D91T0016
            giTranMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth").ToString)
            giTranYear = Convert.ToInt16(dt.Rows(0).Item("TranYear").ToString)
            dt.Dispose()
        End If
    End Sub

    Private Sub D25F0000_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ShowFormSystemsIfNeed()

        mnuPeriod.Text = MakeMenuPeriod()
        If D25Options.ViewFormPeriodWhenAppRun And (ReturnPermission("D25F0003") >= EnumPermission.View) Then
            Dim f As New D25F0003
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then mnuPeriod.Text = MakeMenuPeriod()
            f.Dispose()
        End If
        Call_D09U2222()
        SetMenuPermission()
        SetMenuPermissionTransaction()
        SetEnableMenuPermissionTransaction()
        SetVisibleDelimiter(C1MainMenu) 'Ẩn phân nhóm
        SetTextMenu(C1MainMenu)
        C1CommandLink53.Text = mnuListInterviewer.Text
        C1CommandLink47.Text = mnuReportRecruitmentFile.Text
        mnuTransaction_ApproveRecruitProposalID.Enabled = Not D25Systems.IsUseAppRecruitProposal
        Call_D09U2222()
    End Sub

    Private Sub Call_D09U2222()
        'picMain.Visible = True ' Đưa nền cho khỏi load lên bị dựt

        ''Khởi tạo UserControl
        'Frames = New D09U2222
        'Frames.BringToFront()
        'Frames.Dock = DockStyle.Fill
        'Frames.ModuleID = "25" 'Module gọi

        'TableLayoutPanel1.Controls.Add(Frames, 1, 0)

        'picMain.Visible = False
        'If Frames.IsFrame = False Then
        '    'TableLayoutPanel1.Dispose()
        '    TableLayoutPanel1.Controls.Add(picMain, 1, 0)
        '    picMain.Visible = True
        'End If
        '********************
        picMain.Visible = True ' Đưa nền cho khỏi load lên bị dựt
        'Khởi tạo UserControl
        Dim bNoData As Boolean = False
        Frames = New D25U2224(picMain, "25", bNoData)
        If bNoData Then Exit Sub
        Frames.BringToFront()
        Frames.Dock = DockStyle.Fill
        TableLayoutPanel1.Controls.Add(Frames, 1, 0)
        picMain.Visible = False 'Tắt đi
    End Sub

    Private Sub mnuSystemOption_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOption.Click
        'Dim f As New D25F0002
        'f.ShowDialog()
        'f.Dispose()
        Me.Cursor = Cursors.WaitCursor 'ID 88585 27/06/2016
        CallFormShowDialog("D25D0940", "D25F0002")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPeriod.Click
        Dim f As New D25F0003
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'C1CommandLink13.Text = MakeMenuPeriod()
            mnuPeriod.Text = MakeMenuPeriod()
            'SetMenuPermissionTransaction()
            SetEnableMenuPermissionTransaction()
            If Frames IsNot Nothing Then Frames.Dispose()
            Call_D09U2222()
        End If
        f.Dispose()
    End Sub

    Private Sub mnuSystemCloseBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemCloseBook.Click
        If Not AllowCloseBook() Then Exit Sub
        Dim f As New D25F5554
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'SetMenuPermissionTransaction()
            SetEnableMenuPermissionTransaction()
        End If
        f.Dispose()
    End Sub

    Private Function AllowCloseBook() As Boolean
        If ReturnPermission("D25F5554") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionCloseBook()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemNewPeriod_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemNewPeriod.Click
        If Not AllowNewPeriod() Then Exit Sub
        Dim f As New D25F5556
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Function AllowNewPeriod() As Boolean
        If ReturnPermission("D25F5556") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionNewPeriod()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemOpenBook_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOpenBook.Click
        If Not AllowOpenBook() Then Exit Sub
        Dim f As New D25F5555
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then SetEnableMenuPermissionTransaction() 'SetMenuPermissionTransaction()
        f.Dispose()
    End Sub

    Private Function AllowOpenBook() As Boolean
        If ReturnPermission("D25F5555") <= EnumPermission.View Then
            D99C0008.MsgNoPermissionOpenBook()
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSystemLanguageVietnamese_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageVietnamese.Click
        mnuSystemLanguageVietnamese.Checked = True
        mnuSystemLanguageEnglish.Checked = False
        geLanguage = EnumLanguage.Vietnamese
        gsLanguage = "84"
        D99C0008.Language = geLanguage
        Loadlanguage()

        'If picMain.Visible = False Then
        '    Frames.LoadLanguage_D09U2222()
        'End If

        TableLayoutPanel1.Controls.Remove(t)
        LoadUserControlTreeview()

        'If Frames.IsFrame = False Then
        '    TableLayoutPanel1.Controls.Add(picMain, 1, 0)
        '    picMain.Visible = True
        'End If
        If picMain.Visible = False Then Frames.LoadLanguage(True) 'LoadLanguage_D09U2222()
    End Sub

    Private Sub mnuSystemLanguageEnglish_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemLanguageEnglish.Click
        mnuSystemLanguageVietnamese.Checked = False
        mnuSystemLanguageEnglish.Checked = True
        geLanguage = EnumLanguage.English
        gsLanguage = "01"
        D99C0008.Language = geLanguage
        Loadlanguage()

        'If picMain.Visible = False Then
        '    Frames.LoadLanguage_D09U2222()
        'End If

        TableLayoutPanel1.Controls.Remove(t)
        LoadUserControlTreeview()

        'If Frames.IsFrame = False Then
        '    TableLayoutPanel1.Controls.Add(picMain, 1, 0)
        '    picMain.Visible = True
        'End If
        If picMain.Visible = False Then Frames.LoadLanguage(True) 'LoadLanguage_D09U2222()
    End Sub

    'A. Nghiệp vụ lập kế hoạch tuyển dụng
    Private Sub mnuTransactionGeneralRecruitmentPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionGeneralRecruitmentPlan.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        CallFormThread("D25D0240", "D25F2080", arrPro)
    End Sub

    'B. Nghiệp vụ Lập đề xuất tuyển dụng
    Private Sub mnuTransaction_MakeRecruitProposalID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransaction_MakeRecruitProposalID.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2000
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "IsMSS", 0)
        'SetProperties(arrPro, "FormIDPermission", "D25F2000")  'id 76343 5/6/2015
        CallFormThread("D25D0240", "D25F2000", arrPro)

    End Sub

    'C. Nghiệp vụ Duyệt đề xuất tuyển dụng
    Private Sub mnuTransaction_ApproveRecruitProposalID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransaction_ApproveRecruitProposalID.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2021
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F2021")
    End Sub

    'D. Nghiệp vụ Lập thông báo tuyển dụng
    Private Sub mnuTransactionMakeRecruitAnnoucement_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionMakeRecruitAnnouncement.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2070
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        CallFormThread("D25D0240", "D25F2070", arrPro)
    End Sub

    'Nghiệp vụ -> E. Lập đợt tuyển dụng
    Private Sub mnuTransactionRecruitmentFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionRecruitmentFile.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F1040
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F1040")
    End Sub

    'Nghiệp vụ -> F. Lập lịch phỏng vấn
    Private Sub mnuTransactionInterviewFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionInterviewFile.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2010
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F2010")
    End Sub

    'Nghiệp vụ -> G. Đánh giá kết quả phỏng vấn
    Private Sub mnuTransactionInterviewResult_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionInterviewResult.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3031
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread(Me, "D25D0240", "D25F3031")
    End Sub

    'Nghiệp vụ -> H. Quyết định tuyển dụng
    Private Sub mnuTransactionRecruitDecision_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionRecruitDecision.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2060
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F2060")
    End Sub

    'Nghiệp vụ -> I. Duyệt quyết định tuyển dụng
    Private Sub mnuTransactionAppRecruitDecision_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionAppRecruitDecision.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2100
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "EnumFormState", 0)
        CallFormThread(Me, "D25D0240", "D25F2100", arrPro)
    End Sub

    'Nghiệp vụ -> J. Chi phí tuyển dụng
    Private Sub mnuTransactionRecruitmentCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionRecruitmentCost.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F2090
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F2090")
    End Sub

    Private Sub mnuTransaction_MakeRecruitPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransaction_MakeRecruitPlan.Click
        '********* Form khong su dung ************
        'Dim f As New D25F2030
        'With f
        '    .RecruitPlanID = ""
        '    .FormState = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub mnuTransaction_ApproveRecruitPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransaction_ApproveRecruitPlan.Click
        '********* Form khong su dung ************
        'Dim f As New D25F2040
        'With f
        '    .FormState = EnumFormState.FormAdd
        '    .RecruitPlanID = ""
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    'Truy vấn

    'A. Truy vấn kế hoạch tuyển dụng
    Private Sub mnuInquiryGeneralRecruitmentPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryGeneralRecruitmentPlan.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3080
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3080")
    End Sub

    'B. Đề xuất tuyển dụng
    Private Sub mnuInquiry_RecruitProposalID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiry_RecruitProposalID.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3000
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F3000")
        CallFormThread("D25D0240", "D25F3000", arrPro)
        'CallFormShow(Me, "D25D0240", "Form1")
    End Sub

    'C. Thông báo tuyển dụng
    Private Sub mnuInquiryRecruitAnoucement_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryRecruitAnouncement.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3070
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3070")
    End Sub

    'Truy vấn ->D. Lập đợt tuyển dụng
    Private Sub mnuInquiryRecruitmentFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryRecruitmentFile.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3010
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3010")
    End Sub

    'Truy vấn ->E. Lập lịch phỏng vấn
    Private Sub mnuInquiryInterviewFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryInterviewFile.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3020
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3020")
    End Sub

    'Truy vấn -> F. Kết quả phỏng vấn
    Private Sub mnuInquiryResultInterview_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryResultInterview.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3040
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3040")
    End Sub

    'Truy vấn -> G. Quyết định tuyển dụng
    Private Sub mnuInquiryRecruitDecision_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryRecruitDecision.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3060
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0240", "D25F3060")
    End Sub

    'Thống kê & Phân tích -> H. Kết quả tuyển dụng ' Theo ID 54645 ngày 8/3/2013
    Private Sub mnuStatisResultEmploy_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisResultEmploy.Click
        'Dim f As New D25M0440
        'With f
        '    .FormActive = enumD25E0440Form.D25F3050
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormThread("D25D0440", "D25F3050")
    End Sub

    'Truy vấn -> I. Chi phí tuyển dụng
    Private Sub mnuInquiryRecruitmentCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiryRecruitmentCost.Click
        'Dim f As New D25M0240
        'With f
        '    .FormActive = enumD25E0240Form.D25F3090
        '    .ShowDialog()
        '    .Dispose()
        'End With
        'CallFormThread("D25D0240", "D25F3090")
        CallFormThread("D25D0240", "D25F3090")
    End Sub

    Private Sub mnuInquiry_RecruitPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuInquiry_RecruitPlan.Click
        '*************Form khong su dung *****************
        'Dim f As New D25F3030
        'With f
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub mnuReferenceInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReferenceInfo.Click
        'Dim frm As New DxxMxx40
        'With frm
        '    .exeName = "D25E0940"
        '    .FormActive = "D25F0050"
        '    .FormPermission = "D25F0050"
        '    'Dim sField() As String = {"FormNameCall", "InfoFormCode", "RowIndex"}
        '    'Dim sValue() As Object = {Me.Name, tdbcTranTypeID.Columns("InfoFormCode").Text, tdbgJob.Row.ToString}
        '    '.IDxx(sField) = sValue
        '    '.OutputName = New String() {"Output01"}
        '    .ShowDialog()
        '    '  Dim output() As String = .OutputXX()
        '    .Dispose()
        'End With
        ''Dim f As New D25F0050
        ''With f
        ''    .ShowDialog()
        ''    .Dispose()
        ''End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F0050")
        CallFormThread(Me, "D25D0940", "D25F0050", arrPro)
    End Sub

    'Danh mục -> A. Hồ sơ ứng viên
    Private Sub mnuListCandidate_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCandidate.Click
        ''Dim f As New D25F1050
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1050
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1050")

        ''id 76343 5/6/2015
        'Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "FormIDPermission", "D25F1050")
        'CallFormShow(Me, "D25D0140", "D25F1050", arrPro)
    End Sub

    'Danh mục -> B. Nguồn tuyển dụng
    Private Sub mnuListResource_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListResource.Click
        ''Dim f As New D25F1010
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1010
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1010")
    End Sub

    'Danh mục -> C. Chỉ tiêu đánh giá
    Private Sub mnuListEvaluationCriteria_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListEvaluationCriteria.Click
        ' Call_D39E0140("D39F1000", "D25F1110", False)
        '---------------------
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "25")
        SetProperties(arrPro, "FormIDPermission", "D25F1110")
        CallFormShow("D39D0140", "D39F1000", arrPro)
    End Sub

    'Danh mục -> D. Vị trí ứng tuyển
    Private Sub mnuListRecPosition_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListRecPosition.Click
        'Dim f As New D09F0290
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D09D0140", "D09F0290")
    End Sub

    'Danh mục -> E. Chi phí tuyển dụng
    Private Sub mnuListRecCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListRecCost.Click
        ''Dim f As New D25F1030
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1030
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1030")
    End Sub

    'Danh mục -> F. Người tuyển dụng
    Private Sub mnuListInterviewer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListInterviewer.Click
        ''Dim f As New D25F1070
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1070
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1070")
    End Sub

    'Danh mục -> G. Nhóm phỏng vấn
    Private Sub mnuListIntGroup_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListIntGroup.Click
        ''Dim frm As New D25F1090
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1090
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1090")
    End Sub

    'Danh mục -> H. Loại nghiệp vụ
    Private Sub mnuListTransactionType_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListTransactionType.Click
        ''Dim f As New D25F1060
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1060
        'f.ShowDialog()
        'f.Dispose()

        CallFormThread("D25D0140", "D25F1060")
    End Sub

    'Danh mục -> I. Loại nghiệp vụ HS ứng cử viên
    Private Sub mnuListCandidateFileTransaction_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListCandidateFileTransaction.Click
        ''Dim f As New D25F1080
        'Dim f As New D25M0140
        'f.FormActive = enumD25E0140Form.D25F1080
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D25D0140", "D25F1080")
    End Sub

    'Danh mục -> J. Cảnh báo
    Private Sub mnuListWarning_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListWarning.Click
        'Dim f As New D82F1020
        'With f
        '    .FormName = "D82F1020"
        '    .FormPermission = "D25F5611"
        '    .Key01ID = D25
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F5611")
        SetProperties(arrPro, "ModuleID", "D25") 'Gọi từ module D82 thì truyền vào "", khác D82 thì truyền vào "Dxx"
        CallFormShow("D82D1140", "D82F1020", arrPro)
    End Sub

    'Báo cáo -> A. Kế hoạch tuyển dụng
    Private Sub mnuReportGeneralRecruitPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportGeneralRecruitPlan.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4090
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D25D0340", "D25F4090")
    End Sub

    'Báo cáo -> A. Danh sách ứng cử viên
    Private Sub mnuReportCandidate_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCandidate.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4000
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D25D0340", "D25F4000")
    End Sub

    ' Báo cáo -> Kết quả tuyển dụng
    Private Sub mnuReportRecruitmentFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportRecruitmentFile.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4010
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D25D0340", "D25F4010")
    End Sub

    ' Báo cáo -> C. Kết quả phỏng vấn
    Private Sub mnuReportResultInterview_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportResultInterview.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4020
        'f.ShowDialog()
        'f.Dispose()
        CallFormShow("D25D0340", "D25F4020")
    End Sub

    'Báo cáo -> D. Phiếu đề xuất tuyển dụng
    Private Sub mnuReportInspectRecruit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportInspectRecruit.Click
        'Dim f As New D25M0340
        'f.FormActive = enumD25E0340Form.D25F4050
        'f.ShowDialog()
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "IsMSS", 0)
        CallFormShow("D25D0340", "D25F4050", arrPro)
    End Sub

    'Báo cáo -> E. Kế hoạch tuyển dụng
    Private Sub mnuReportRecruitPlan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportRecruitPlan.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormText", rL3("Ke_hoach_tuyen_dungF") & " - D25F4060")
        CallFormShow("D25D0340", "D25F4050", arrPro)
    End Sub

    Private Sub mnuReportRecruitAnoucement_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportRecruitAnouncement.Click
        CallFormShow("D25D0340", "D25F4070")
    End Sub

    Private Sub mnuReportInterviewSchedule_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportInterviewSchedule.Click
        CallFormShow("D25D0340", "D25F4080")
    End Sub

    'Báo cáo -> F. Chi phí tuyển dụng
    Private Sub mnuRecruitCost_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRecruitCost.Click
        CallFormShow("D25D0340", "D25F4040")
    End Sub

    Private Sub mnuReportCustomized_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportCustomized.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "D25")
        CallFormShow("D89D0140", "D89F9100", arrPro)
    End Sub

    Private Sub mnuReportItem_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportItem.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F9101")
        CallFormShow("D89D4240", "D89F9101", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Frames_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frames.Disposed
        Try
            'TableLayoutPanel1.Dispose()
        Catch ex As Exception

        End Try
        picMain.Show()
    End Sub


    Private Sub mnuStatisRecFileStatistic_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisRecFileStatistic.Click
        CallFormThread("D25D0440", "D25F3051")
    End Sub

    Private Sub mnuStatisTime_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisTime.Click
        CallFormShow("D25D4040", "D25F3200")
    End Sub

    Private Sub mnuSystemOtherSetupInput_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSystemOtherSetupInput.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D25F0066")
        CallFormShowDialog("D91D0840", "D91F0066", arrPro)
    End Sub
    Private Sub mnuStatisCompareGeneral_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuStatisCompareGeneral.Click
        Me.Cursor = Cursors.WaitCursor
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", "D25F3052")
        SetProperties(arrPro, "FormIDPermission", "D25F3052")
        SetProperties(arrPro, "ModuleID", "25")
        CallFormShow("D89D4040", "D89F3000", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuTransactionGeneralApprovedPlan_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionGeneralApprovedPlan.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", "D25F5601")
        SetProperties(arrPro, "FormState", EnumFormState.FormApprove)
        CallFormThread("D25D0240", "D25F2080", arrPro)
    End Sub

    Private Sub mnuReportSyntheticInterview_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportSyntheticInterview.Click
        CallFormShow("D25D0340", "D25F4100")
    End Sub

    Private Sub mnuTransaction_FilterCV_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransaction_FilterCV.Click
        CallFormShow("D25D1040", "D25F2032")
    End Sub
End Class
