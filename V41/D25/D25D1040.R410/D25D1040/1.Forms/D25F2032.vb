Public Class D25F2032
    Private dtGrid, dtGrid1 As DataTable

#Region "Const of tdbg"
    Private Const COL_FieldName As Integer = 0   ' FieldName
    Private Const COL_CaptionID As Integer = 1   ' CaptionID
    Private Const COL_CaptionName As Integer = 2 ' Chỉ tiêu
    Private Const COL_IsUsed As Integer = 3      ' Chọn
    Private Const COL_IsGroup As Integer = 4     ' IsGroup
    Private Const COL_IsCover As Integer = 5     ' IsCover
    Private Const COL_TableName As Integer = 6   ' TableName
    Private Const COL_ValueFrom As Integer = 7   ' ValueFrom
#End Region


#Region "Const of tdbgTab1 - Total of Columns: 10"
    Private Const COL_TAB1_Certificates As Integer = 0     ' Văn bằng
    Private Const COL_TAB1_SchoolID As Integer = 1           ' SchoolID
    Private Const COL_TAB1_SchoolName As Integer = 2         ' Trường học
    Private Const COL_TAB1_MajorID As Integer = 3            ' MajorID
    Private Const COL_TAB1_MajorName As Integer = 4          ' Ngành học
    Private Const COL_TAB1_DateStarted As Integer = 5        ' Bắt đầu
    Private Const COL_TAB1_DateEnded As Integer = 6          ' Kết thúc
    Private Const COL_TAB1_TransEducationID As Integer = 7   ' TransEducationID
    Private Const COL_TAB1_TransEducationName As Integer = 8 ' Loại hình đào tạo
    Private Const COL_TAB1_Description As Integer = 9        ' Ghi chú
#End Region

#Region "Const of tdbgTab2 - Total of Columns: 9"
    Private Const COL_TAB2_LanguageID As Integer = 0        ' LanguageID
    Private Const COL_TAB2_LanguageName As Integer = 1      ' Ngoại ngữ
    Private Const COL_TAB2_LanguageLevelID As Integer = 2   ' LanguageLevelID
    Private Const COL_TAB2_LanguageLevelName As Integer = 3 ' Cấp độ
    Private Const COL_TAB2_Listening As Integer = 4         ' Nghe
    Private Const COL_TAB2_Speaking As Integer = 5          ' Nói
    Private Const COL_TAB2_Reading As Integer = 6           ' Đọc
    Private Const COL_TAB2_Writing As Integer = 7           ' Viết
    Private Const COL_TAB2_Description As Integer = 8       ' Ghi chú
#End Region

#Region "Const of tdbgTab3 - Total of Columns: 4"
    Private Const COL_TAB3_ComputingCertificate As Integer = 0 ' Văn bằng
    Private Const COL_TAB3_ComputingLevel As Integer = 1       ' Cấp độ
    Private Const COL_TAB3_SchoolID As Integer = 2             ' Trường học
    Private Const COL_TAB3_Description As Integer = 3          ' Ghi chú
#End Region

#Region "Const of tdbgTab4 - Total of Columns: 4"
    Private Const COL_TAB4_DateFrom As Integer = 0      ' Thời gian đào tạo từ
    Private Const COL_TAB4_DateTo As Integer = 1        ' Thời gian đào tạo đến
    Private Const COL_TAB4_PlaceTraining As Integer = 2 ' Nơi đào tạo
    Private Const COL_TAB4_Certificate As Integer = 3   ' Bằng cấp nhận được
#End Region

#Region "Const of tdbgTab5 - Total of Columns: 9"
    Private Const COL_TAB5_DateFrom As Integer = 0   ' Từ
    Private Const COL_TAB5_DateTo As Integer = 1     ' Đến
    Private Const COL_TAB5_Company As Integer = 2    ' Công ty
    Private Const COL_TAB5_Address As Integer = 3    ' Địa chỉ
    Private Const COL_TAB5_Manager As Integer = 4    ' Người quản lý trực tiếp
    Private Const COL_TAB5_Duty As Integer = 5       ' Chức vụ
    Private Const COL_TAB5_Salary As Integer = 6     ' Mức lương
    Private Const COL_TAB5_Mission As Integer = 7    ' Nhiệm vụ chính
    Private Const COL_TAB5_ReasonLeft As Integer = 8 ' Lý do nghỉ
#End Region

#Region "Const of tdbgTab6 - Total of Columns: 8"
    Private Const COL_TAB6_Project As Integer = 0        ' Dự án/ Sản phẩm
    Private Const COL_TAB6_PeriodFrom As Integer = 1     ' Thời gian từ
    Private Const COL_TAB6_PeriodTo As Integer = 2       ' Thời gian đến
    Private Const COL_TAB6_Duty As Integer = 3           ' Vị trí
    Private Const COL_TAB6_Responsibility As Integer = 4 ' Trách nhiệm
    Private Const COL_TAB6_LanguageCode As Integer = 5   ' Ngôn ngữ lập trình
    Private Const COL_TAB6_Tool As Integer = 6           ' Công cụ
    Private Const COL_TAB6_Information As Integer = 7    ' Thông tin chung về dự án
#End Region

#Region "Const of tdbgTab7 - Total of Columns: 6"
    Private Const COL_TAB7_TypeID As Integer = 0   ' Loại kiến thức
    Private Const COL_TAB7_TypeName As Integer = 1 ' Loại kiến thức
    Private Const COL_TAB7_Tool As Integer = 2     ' Tool
    Private Const COL_TAB7_TimeUser As Integer = 3 ' Used Time
    Private Const COL_TAB7_Level As Integer = 4    ' Level
    Private Const COL_TAB7_Notes As Integer = 5    ' Ghi chú
#End Region

#Region "Const of tdbgTab8 - Total of Columns: 2"
    Private Const COL_TAB8_RecPositionName As Integer = 0 ' Vị trí ứng tuyển
    Private Const COL_TAB8_VoucherDate As Integer = 1   ' Thời gian ứng tuyển
#End Region

#Region "Const of tdbgAlter - Total of Columns: 2"
    Private Const COLA_CandidateID As Integer = 0   ' Mã ứng viên
    Private Const COLA_CandidateName As Integer = 1 ' Tên ứng viên
#End Region

#Region "Const of tdbg1 - Total of Columns: 38"
    Private Const COLE_CandidateIDWeb As String = "CandidateIDWeb"           ' CandidateIDWeb
    Private Const COLE_FirstName As String = "FirstName"                     ' FirstName
    Private Const COLE_MiddleName As String = "MiddleName"                   ' MiddleName
    Private Const COLE_LastName As String = "LastName"                       ' LastName
    Private Const COLE_IsSelected As String = "IsSelected"                   ' Chọn
    Private Const COLE_CandidateID As String = "CandidateID"                 ' Mã ứng viên
    Private Const COLE_CandidateName As String = "CandidateName"             ' Tên ứng viên
    Private Const COLE_Sex As String = "Sex"                                     ' Sex
    Private Const COLE_SexName As String = "SexName"                             ' Giới tính
    Private Const COLE_BirthDate As String = "BirthDate"                     ' Ngày sinh
    Private Const COLE_BirthPlace As String = "BirthPlace"                   ' Nơi sinh
    Private Const COLE_MaritalStatus As String = "MaritalStatus"                 ' MaritalStatus
    Private Const COLE_MaritalName As String = "MaritalName"                     ' Tình trạng hôn nhân
    Private Const COLE_IDCardNo As String = "IDCardNo"                       ' CMND
    Private Const COLE_IDCardDate As String = "IDCardDate"                   ' Ngày cấp CMND
    Private Const COLE_IDCardPlace As String = "IDCardPlace"                 ' Nơi cấp CMND
    Private Const COLE_EthnicID As String = "EthnicID"                           ' EthnicID
    Private Const COLE_EthnicName As String = "EthnicName"                       ' Dân tộc
    Private Const COLE_ReligionID As String = "ReligionID"                       ' ReligionID
    Private Const COLE_ReligionName As String = "ReligionName"                   ' Tôn giáo
    Private Const COLE_NationalityID As String = "NationalityID"                 ' NationalityID
    Private Const COLE_NationalityName As String = "NationalityName"             ' Quốc tịch
    Private Const COLE_NativePlace As String = "NativePlace"                 ' Quê quán
    Private Const COLE_EducationLevelID As String = "EducationLevelID"           ' EducationLevelID
    Private Const COLE_EducationLevelName As String = "EducationLevelName"       ' Trình độ học vấn
    Private Const COLE_PoliticsID As String = "PoliticsID"                       ' PoliticsID
    Private Const COLE_PoliticsName As String = "PoliticsName"                   ' Trình độ chính trị
    Private Const COLE_ProfessionalLevelID As String = "ProfessionalLevelID"     ' ProfessionalLevelID
    Private Const COLE_ProfessionalLevelName As String = "ProfessionalLevelName" ' Trình độ chuyên môn
    Private Const COLE_Height As String = "Height"                           ' Chiều cao
    Private Const COLE_Weight As String = "Weight"                           ' Cân nặng
    Private Const COLE_HealthStatus As String = "HealthStatus"               ' Tình trạng sức khỏe
    Private Const COLE_Mobile As String = "Mobile"                           ' Điện thoại
    Private Const COLE_Email As String = "Email"                             ' Email
    Private Const COLE_ContactAddress As String = "ContactAddress"           ' Địa chỉ liên lạc
    Private Const COLE_ConAddress As String = "ConAddress"                       ' Hộ khẩu
    Private Const COLE_ExpectSalary As String = "ExpectSalary"               ' Mức lương mong muốn
    Private Const COLE_ExpectBeginDate As String = "ExpectBeginDate"         ' Ngày có thể bắt đầu
#End Region




    Private _formIDPermission As String = "D25F2032"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property


    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.'
        'Các control chỉnh theo Anchor là XXX
    End Sub

    Private Sub D09F0412_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D09F0412_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        '****************************
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetColorGrid(tdbg1, tdbgTab1, tdbgTab2, tdbgTab3, tdbgTab4, tdbgTab5, tdbgTab6, tdbgTab7, tdbgTab8)
        LoadTDBCombo()
        LoadLanguage()
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
  
        InputDateCustomFormat(c1dateDateLeftFrom, c1dateDateLeftTo)
        tdbg1_LockedColumns()
        tdbg1_NumberFormat()
        '****************

        SetResolutionForm(Me)
        '***************
        LoadDefault() 'Phải để sau SetResolutionForm
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("San_loc_ung_vien") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Sªn lãc ÷ng vi£n
        '================================================================ 
        lblMethodID.Text = rl3("Ma_ung_cu_vien_tu_dong") 'Mã ứng cử viên tự động
        '================================================================ 
        btnCollapse.Text = rl3("_Chi_tieu_thong_ke") '>> Chỉ tiêu thống kê
        btnSave.Text = rL3("_Luu") '&Lưu
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        '================================================================ 
        TabPage1.Text = "1." & rL3("Qua_trinh_hoc_tap") 'Quá trình học tập
        TabPage2.Text = "2." & rL3("Trinh_do_ngoai_ngu") 'Trình độ ngoại ngữ
        TabPage3.Text = "3." & rL3("Trinh_do_tin_hoc") 'Trình độ tin học
        TabPage4.Text = "4." & rL3("Huan_luyen_dao_tao") 'Huấn luyện đào tạo
        TabPage5.Text = "5." & rL3("Qua_trinh_lam_viec") 'Quá trình làm việc
        TabPage6.Text = "6." & rL3("Du_anSan_pham") 'Dự án/Sản phẩm
        TabPage7.Text = "7." & rL3("Kien_thuc_va_ky_nang") 'Kiến thức và kỹ năng
        TabPage8.Text = "8." & rL3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển
        '================================================================ 
        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_CaptionName).Caption = rl3("Chi_tieu") 'Chỉ tiêu
        tdbg.Columns(COL_IsUsed).Caption = rl3("Chon") 'Chọn
        '================================================================ 
        tdbg1.Columns(COLE_IsSelected).Caption = rl3("Chon") 'Chọn
        tdbg1.Columns(COLE_CandidateID).Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg1.Columns(COLE_CandidateName).Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg1.Columns(COLE_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg1.Columns(COLE_BirthDate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg1.Columns(COLE_BirthPlace).Caption = rl3("Noi_sinh") 'Nơi sinh
        tdbg1.Columns(COLE_MaritalName).Caption = rL3("Tinh_trang_hon_nhan") 'Tình trạng hôn nhân
        tdbg1.Columns(COLE_IDCardNo).Caption = rl3("CMND") 'CMND
        tdbg1.Columns(COLE_IDCardDate).Caption = rl3("Ngay_cap_CMND") 'Ngày cấp CMND
        tdbg1.Columns(COLE_IDCardPlace).Caption = rl3("Noi_cap_CMND") 'Nơi cấp CMND
        tdbg1.Columns(COLE_EthnicName).Caption = rL3("Dan_toc") 'Dân tộc
        tdbg1.Columns(COLE_ReligionName).Caption = rL3("Ton_giao") 'Tôn giáo
        tdbg1.Columns(COLE_NationalityName).Caption = rL3("Quoc_tich") 'Quốc tịch
        tdbg1.Columns(COLE_NativePlace).Caption = rl3("Que_quan") 'Quê quán
        tdbg1.Columns(COLE_EducationLevelName).Caption = rL3("Trinh_do_van_hoa_U") 'Trình độ học vấn
        tdbg1.Columns(COLE_PoliticsName).Caption = rL3("Trinh_do_chinh_tri") 'Trình độ chính trị
        tdbg1.Columns(COLE_ProfessionalLevelName).Caption = rL3("Trinh_do_chuyen_mon_U") 'Trình độ chuyên môn
        tdbg1.Columns(COLE_Height).Caption = rl3("Chieu_cao") 'Chiều cao
        tdbg1.Columns(COLE_Weight).Caption = rl3("Can_nang") 'Cân nặng
        tdbg1.Columns(COLE_HealthStatus).Caption = rl3("Tinh_trang_suc_khoeU") 'Tình trạng sức khỏe
        tdbg1.Columns(COLE_Mobile).Caption = rl3("Dien_thoai") 'Điện thoại
        tdbg1.Columns(COLE_ContactAddress).Caption = rl3("Dia_chi_lien_lac") 'Địa chỉ liên lạc
        tdbg1.Columns(COLE_ConAddress).Caption = rL3("Ho_khau") 'Hộ khẩu
        tdbg1.Columns(COLE_ExpectSalary).Caption = rl3("Muc_luong_mong_muon") 'Mức lương mong muốn
        tdbg1.Columns(COLE_ExpectBeginDate).Caption = rl3("Ngay_co_the_bat_dau") 'Ngày có thể bắt đầu



        '================================================================ 
        tdbgTab1.Columns(COL_TAB1_Certificates).Caption = rl3("Van_bang") 'Văn bằng
        tdbgTab1.Columns(COL_TAB1_SchoolName).Caption = rL3("Truong_hoc") 'Trường học
        tdbgTab1.Columns(COL_TAB1_MajorName).Caption = rL3("Nganh_hoc") 'Ngành học
        tdbgTab1.Columns(COL_TAB1_DateStarted).Caption = rl3("ABat_dau") 'Bắt đầu
        tdbgTab1.Columns(COL_TAB1_DateEnded).Caption = rl3("Ket_thuc") 'Kết thúc
        tdbgTab1.Columns(COL_TAB1_TransEducationName).Caption = rL3("Loai_hinh_dao_tao") 'Loại hình đào tạo
        tdbgTab1.Columns(COL_TAB1_Description).Caption = rl3("Ghi_chu") 'Ghi chú

        '================================================================ 
        tdbgTab2.Columns(COL_TAB2_LanguageName).Caption = rL3("Ngoai_ngu") 'Ngoại ngữ
        tdbgTab2.Columns(COL_TAB2_LanguageLevelName).Caption = rL3("Cap_do") 'Cấp độ
        tdbgTab2.Columns(COL_TAB2_Listening).Caption = rl3("Nghe") 'Nghe
        tdbgTab2.Columns(COL_TAB2_Speaking).Caption = rl3("Noi") 'Nói
        tdbgTab2.Columns(COL_TAB2_Reading).Caption = rl3("Doc") 'Đọc
        tdbgTab2.Columns(COL_TAB2_Writing).Caption = rl3("Viet") 'Viết
        tdbgTab2.Columns(COL_TAB2_Description).Caption = rl3("Ghi_chu") 'Ghi chú

        tdbgTab3.Columns(COL_TAB3_ComputingCertificate).Caption = rl3("Van_bang") 'Văn bằng
        tdbgTab3.Columns(COL_TAB3_ComputingLevel).Caption = rl3("Cap_do") 'Cấp độ
        tdbgTab3.Columns(COL_TAB3_SchoolID).Caption = rl3("Truong_hoc") 'Trường học
        tdbgTab3.Columns(COL_TAB3_Description).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbgTab4.Columns(COL_TAB4_DateFrom).Caption = rl3("Thoi_gian_dao_tao_tu_") 'Thời gian đào tạo từ
        tdbgTab4.Columns(COL_TAB4_DateTo).Caption = rl3("Thoi_gian_dao_tao_den") 'Thời gian đào tạo đến
        tdbgTab4.Columns(COL_TAB4_Certificate).Caption = rL3("Bang_cap_nhan_duoc") 'Bằng cấp nhận được
        tdbgTab4.Columns(COL_TAB4_PlaceTraining).Caption = rL3("Noi_dao_tao") 'Nơi đào tạo
        tdbgTab5.Columns(COL_TAB5_DateFrom).Caption = rl3("Tu") 'Từ
        tdbgTab5.Columns(COL_TAB5_DateTo).Caption = rl3("Den") 'Đến
        tdbgTab5.Columns(COL_TAB5_Company).Caption = rl3("Cong_ty") 'Công ty
        tdbgTab5.Columns(COL_TAB5_Address).Caption = rl3("Dia_chi") 'Địa chỉ
        tdbgTab5.Columns(COL_TAB5_Manager).Caption = rl3("Nguoi_quan_ly_truc_tiepU") 'Người quản lý trực tiếp
        tdbgTab5.Columns(COL_TAB5_Duty).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbgTab5.Columns(COL_TAB5_Salary).Caption = rl3("Muc_luong") 'Mức lương
        tdbgTab5.Columns(COL_TAB5_Mission).Caption = rl3("Nhiem_vu_chinh") 'Nhiệm vụ chính
        tdbgTab5.Columns(COL_TAB5_ReasonLeft).Caption = rl3("Ly_do_nghi") 'Lý do nghỉ
        tdbgTab6.Columns(COL_TAB6_Project).Caption = rl3("Du_an_San_pham") 'Dự án/ Sản phẩm
        tdbgTab6.Columns(COL_TAB6_PeriodFrom).Caption = rl3("Thoi_gian_tu") 'Thời gian từ
        tdbgTab6.Columns(COL_TAB6_PeriodTo).Caption = rl3("Thoi_gian_den") 'Thời gian đến
        tdbgTab6.Columns(COL_TAB6_Duty).Caption = rl3("Vi_tri") 'Vị trí
        tdbgTab6.Columns(COL_TAB6_Responsibility).Caption = rl3("Trach_nhiem") 'Trách nhiệm
        tdbgTab6.Columns(COL_TAB6_LanguageCode).Caption = rl3("Ngon_ngu_lap_trinh") 'Ngôn ngữ lập trình
        tdbgTab6.Columns(COL_TAB6_Tool).Caption = rl3("Cong_cu") 'Công cụ
        tdbgTab6.Columns(COL_TAB6_Information).Caption = rl3("Thong_tin_chung_ve_du_an") 'Thông tin chung về dự án
        tdbgTab7.Columns(COL_TAB7_TypeID).Caption = rl3("Loai_kien_thuc") 'Loại kiến thức
        tdbgTab7.Columns(COL_TAB7_TypeName).Caption = rl3("Loai_kien_thuc") 'Loại kiến thức
        tdbgTab7.Columns(COL_TAB7_TimeUser).Caption = rl3("Used_Time") 'Used Time
        tdbgTab7.Columns(COL_TAB7_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbgTab8.Columns(COL_TAB8_RecPositionName).Caption = rL3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển
        tdbgTab8.Columns(COL_TAB8_VoucherDate).Caption = rl3("Thoi_gian_ung_tuyen") 'Thời gian ứng tuyển
    End Sub

    Private Sub tdbg1_LockedColumns()
        If D25Systems.AutoCandidateID Then
            tdbg1.Splits(SPLIT0).DisplayColumns(COLE_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg1.Splits(SPLIT0).DisplayColumns(COLE_CandidateID).Locked = True
        End If
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_BirthPlace).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_MaritalName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_IDCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_IDCardDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_IDCardPlace).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_EthnicName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ReligionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_NationalityName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_NativePlace).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_EducationLevelName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_PoliticsName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ProfessionalLevelName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_Height).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_Weight).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_HealthStatus).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_Mobile).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_Email).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ContactAddress).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ConAddress).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ExpectSalary).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COLE_ExpectBeginDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg1.Columns(COLE_Height).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg1.Columns(COLE_Weight).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg1.Columns(COLE_Mobile).DataField, DxxFormat.DefaultNumber0, 28, 8)
        AddDecimalColumns(arr, tdbg1.Columns(COLE_ExpectSalary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg1, arr)
    End Sub




    Private Sub LoadDefault()
        c1dateDateLeftFrom.Value = Now.Date
        c1dateDateLeftTo.Value = Now.Date

        LoadTDBGrid()
    End Sub

    'Private Sub EnableButton(ByVal bEnabled As Boolean)
    '    SplitContainer1.Panel1.Enabled = Not bEnabled
    '    tdbcMethodID.Enabled = bEnabled And D25Systems.AutoCandidateID
    '    tdbg1.AllowUpdate = bEnabled
    '    btnSave.Enabled = bEnabled
    'End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        sSQL = "  SELECT	 	MethodID, MethodNameU AS MethodName, IsDefault " & vbCrLf & _
                " FROM        D09T1600 WITH(NOLOCK) " & vbCrLf & _
                " WHERE       Disabled = 0 " & vbCrLf & _
                " AND TypeCode = 50 " & vbCrLf & _
                " AND (DivisionID = " & SQLString(gsDivisionID) & " Or DivisionID = '') " & vbCrLf & _
                " ORDER BY    MethodName"
        Dim dtMeThodID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcMethodID, dtMeThodID, gbUnicode)
        Dim dr() As DataRow = dtMeThodID.Select("IsDefault=1")
        If dr.Length > 0 And D25Systems.AutoCandidateID Then tdbcMethodID.SelectedValue = dr(0)("MethodID")
        tdbcMethodID.Enabled = D25Systems.AutoCandidateID
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateDateLeftFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateLeftTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P3422()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_CaptionName)
    End Sub

    Private Sub LoadTDBGrid1()
        Dim sSQL As New StringBuilder
        'Dim dr() As DataRow = dtGrid.Select("IsUsed=1")
        'If dr.Length > 0 Then
        sSQL.Append(" CREATE TABLE #F2302_" & gsUserID & " (Type varchar(50), Value varchar(50)) " & vbCrLf)
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append(" INSERT INTO #F2302_" & gsUserID & " (Type, Value) VALUES (" & SQLString(tdbg(i, COL_FieldName)) & "," & SQLString(tdbg(i, COL_CaptionID)) & ") " & vbCrLf)
            End If
        Next
        'End If
        sSQL.Append(SQLStoreD25P3421)
        dtGrid1 = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        FooterTotalGrid(tdbg1, COLE_CandidateID)
        If tdbg1.RowCount > 0 Then
            LoadTDBGridTab()
            btnSave.Enabled = True
            tdbg1.AllowUpdate = True
        Else
            btnSave.Enabled = False
            tdbg1.AllowUpdate = False
            For i As Integer = 0 To tabMain.TabPages.Count - 1
                Dim ArrCtrl() As Control = tabMain.Controls.Find("tdbgTab" & (i + 1).ToString, True)
                If ArrCtrl.Length > 0 Then
                    Dim c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(ArrCtrl(0), C1.Win.C1TrueDBGrid.C1TrueDBGrid)
                    If c1Grid.DataSource IsNot Nothing Then CType(c1Grid.DataSource, DataTable).Clear() : ResetGridTab(c1Grid)
                End If
            Next
        End If

    End Sub

    Private Sub LoadTDBGridTab()
        For i As Integer = 0 To tabMain.TabPages.Count - 1
            Dim ArrCtrl() As Control = tabMain.Controls.Find("tdbgTab" & (i + 1).ToString, True)
            If ArrCtrl.Length > 0 Then
                Dim c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(ArrCtrl(0), C1.Win.C1TrueDBGrid.C1TrueDBGrid)
                LoadDataSource(c1Grid, SQLStoreD25P3424(i), gbUnicode)
                ReloadTDBGridTab(c1Grid)
            End If
        Next
    End Sub

    Private Sub ReloadTDBGridTab(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim strFind As String = ""

        If (CType(c1Grid.DataSource, DataTable) Is Nothing) Then Exit Sub
        Select Case c1Grid.Name
            Case "tdbgTab1"
                strFind = sFilter1.ToString
            Case "tdbgTab2"
                strFind = sFilter2.ToString
            Case "tdbgTab3"
                strFind = sFilter3.ToString
            Case "tdbgTab4"
                strFind = sFilter4.ToString
            Case "tdbgTab5"
                strFind = sFilter5.ToString
            Case "tdbgTab6"
                strFind = sFilter6.ToString
            Case "tdbgTab7"
                strFind = sFilter7.ToString
            Case "tdbgTab8"
                strFind = sFilter8.ToString
        End Select

        CType(C1Grid.DataSource, DataTable).DefaultView.RowFilter = strFind
        ResetGridTab(C1Grid)
    End Sub

    Private Sub ResetGridTab(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        FooterTotalGrid(C1Grid, 0)
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateDateLeftFrom, c1dateDateLeftTo) Then Return False
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
        If Not AllowFilter() Then Exit Sub
        '************************************
        Me.Cursor = Cursors.WaitCursor
        tdbg1.Columns(COLE_CandidateIDWeb).Tag = ""
        LoadTDBGrid1()
        'EnableButton(True)
        Me.Cursor = Cursors.Default
    End Sub


    'Dim iWidthPanel As Integer = 0, iWidthGridE As Integer = 0, iWidthGridS As Integer = 0
    Private Sub btnCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollapse.Click
        If Not SplitContainer1.Panel1Collapsed Then
            btnCollapse.Text = "<<" & Space(1) & rL3("Chi_tieu_thong_ke") 'Chỉ tiêu thống kê
            SplitContainer1.Panel1Collapsed = True
        Else
            btnCollapse.Text = ">>" & Space(1) & rL3("Chi_tieu_thong_ke") 'Chỉ tiêu thống kê
            SplitContainer1.Panel1Collapsed = False
        End If

    End Sub

#Region "tdbg"
    Dim sRowFilter As String = ""
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUsed
                'Nếu đang đóng thì khi uncheck sẽ xóa dòng
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then
                    Dim dr() As DataRow = dtGrid.Select("IsGroup=0 And FieldName=" & SQLString(tdbg.Columns("FieldName").Text))
                    If L3Bool(dr(0).Item("IsCover")) = False Then tdbg.Delete()
                End If
                tdbg.UpdateData()
                tdbg.Refresh()
        End Select
    End Sub
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If L3Byte(tdbg.Columns(COL_IsGroup).Text) = 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim sFieldName As String = tdbg.Columns(COL_FieldName).Text
        FiltersRow()
        '***********************
        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr1() As DataRow = dt.Select(tdbg.Columns(COL_FieldName).DataField & "=" & SQLString(sFieldName), dt.DefaultView.Sort)
        If dr1.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr1(0))
        If Not tdbg.Focused Then tdbg.Focus()
        '***********************
        FooterTotalGrid(tdbg, COL_CaptionName)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FiltersRow()
        If L3Bool(tdbg.Columns(COL_IsCover).Value) = False Then 'Đang đóng thì mở
            tdbg.Columns(COL_IsCover).Value = True
            '*******************
            Dim sSQL As String = SQLStoreD25P3423()
            Dim dtAdd As DataTable = ReturnDataTable(sSQL)
            '*******************
            Dim dr As DataRow
            Dim dtChild As DataTable = ReturnTableFilter(dtGrid, "IsGroup=1 And FieldName = " & SQLString(tdbg.Columns(COL_FieldName).Text), True)
            If dtChild.Rows.Count <= 0 Then 'Chưa có node con
                'Thêm các node con của dòng đang đứng vào 
                If tdbg.Row <> tdbg.RowCount - 1 Then
                    For i As Integer = 0 To dtAdd.Rows.Count - 1
                        dr = dtGrid.NewRow
                        dtGrid.Rows.InsertAt(dr, tdbg.Row + 1 + i)
                        dr.ItemArray = dtAdd.Rows(i).ItemArray
                    Next
                Else
                    dtGrid.Merge(dtAdd)
                End If
            Else 'Đã có node con
                Dim drIndex() As DataRow = dtGrid.Select("IsUsed=1 And IsGroup=1 And FieldName = " & SQLString(tdbg.Columns(COL_FieldName).Text))
                Dim iRow As Integer = tdbg.Row
                If drIndex.Length > 0 Then iRow = dtGrid.Rows.IndexOf(drIndex(drIndex.Length - 1))
                'Thêm các node con đã bị xóa của dòng đang đứng vào
                For i As Integer = dtAdd.Rows.Count - 1 To 0 Step -1
                    Dim drTemp() As DataRow = dtGrid.Select("CaptionID = " & SQLString(dtAdd.Rows(i).Item("CaptionID").ToString))
                    If drTemp.Length <= 0 Then
                        'Chỉ add các node con chưa có
                        dr = dtGrid.NewRow
                        dtGrid.Rows.InsertAt(dr, iRow + 1)
                        dr.ItemArray = dtAdd.Rows(i).ItemArray
                    End If
                Next
            End If
        Else 'Đang mở thì đóng lại
            tdbg.Columns(COL_IsCover).Value = False
            'Xóa các node con không check chọn của dòng đang đứng
            Dim dr() As DataRow = dtGrid.Select("IsUsed=0 And IsGroup=1 And FieldName = " & SQLString(tdbg.Columns(COL_FieldName).Text))
            For i As Integer = 0 To dr.Length - 1
                dtGrid.Rows.Remove(dr(i))
            Next
        End If
        dtGrid.AcceptChanges()
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_CaptionName
                If L3Byte(tdbg(e.Row, COL_IsGroup)) = 0 Then
                    e.CellStyle.Font = FontUnicode(gbUnicode, FontStyle.Bold)
                End If
            Case COL_IsUsed
                If L3Byte(tdbg(e.Row, COL_IsGroup)) = 0 Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick_Cus(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick_Cus(tdbg.Col)
        End If
    End Sub

    Private Sub HeadClick_Cus(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsUsed
                L3HeadClick_Cus(tdbg, tdbg.Columns(iCol).DataField, bSelect, "IsGroup", "1") 'Có trong D99X0000
        End Select
    End Sub

    Public Sub L3HeadClick_Cus(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Choose As String, ByRef bSelected As Boolean, ByVal Col_Where As String, ByVal sValueWhere As String)
        'Update 18/6/2013 by Minh Hòa
        Dim bSelect As Boolean = Not bSelected
        tdbg.AllowSort = False
        tdbg.UpdateData()

        Dim i As Integer = tdbg.RowCount - 1

        If Col_Where <> "" Then
            While i >= 0
                If tdbg(i, Col_Where).ToString = sValueWhere Then
                    tdbg(i, COL_Choose) = bSelect
                End If
                i -= 1
            End While
        Else
            While i >= 0
                tdbg(i, COL_Choose) = bSelect
                i -= 1
            End While
        End If
        bSelected = bSelected

    End Sub

#End Region

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        tdbg1.UpdateData()
    End Sub

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If dtGrid1 Is Nothing Then Exit Sub
        If L3String(tdbg1.Columns(COLE_CandidateIDWeb).Tag) = "" OrElse L3String(tdbg1.Columns(COLE_CandidateIDWeb).Tag) <> tdbg1.Columns(COLE_CandidateIDWeb).Text Then
            LoadTDBGridTab()
            tdbg1.Columns(COLE_CandidateIDWeb).Tag = tdbg1.Columns(COLE_CandidateIDWeb).Text
        End If
    End Sub

    Dim bSelect1 As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg1.RowCount <= 0 Then Exit Sub
        Select Case tdbg1.Columns(iCol).DataField
            Case COLE_IsSelected
                L3HeadClick(tdbg1, iCol, bSelect1)
            Case Else
                tdbg1.AllowSort = False
        End Select
    End Sub

    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg1.Col)
    End Sub

    Dim sFilter1 As New System.Text.StringBuilder()
    Dim sFilter2 As New System.Text.StringBuilder()
    Dim sFilter3 As New System.Text.StringBuilder()
    Dim sFilter4 As New System.Text.StringBuilder()
    Dim sFilter5 As New System.Text.StringBuilder()
    Dim sFilter6 As New System.Text.StringBuilder()
    Dim sFilter7 As New System.Text.StringBuilder()
    Dim sFilter8 As New System.Text.StringBuilder()
    Private Sub tdbgTab1_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgTab1.FilterChange _
                                                                                                   , tdbgTab2.FilterChange _
                                                                                                      , tdbgTab3.FilterChange _
                                                                                                         , tdbgTab4.FilterChange _
                                                                                                            , tdbgTab5.FilterChange _
                                                                                                               , tdbgTab6.FilterChange _
                                                                                                                  , tdbgTab7.FilterChange _
                                                                                                                  , tdbgTab8.FilterChange
        Dim c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            Dim sFilter As New System.Text.StringBuilder()
            If (CType(c1Grid.DataSource, DataTable) Is Nothing) Then Exit Sub
            Select Case c1Grid.Name
                Case "tdbgTab1"
                    sFilter = sFilter1
                Case "tdbgTab2"
                    sFilter = sFilter2
                Case "tdbgTab3"
                    sFilter = sFilter3
                Case "tdbgTab4"
                    sFilter = sFilter4
                Case "tdbgTab5"
                    sFilter = sFilter5
                Case "tdbgTab6"
                    sFilter = sFilter6
                Case "tdbgTab7"
                    sFilter = sFilter7
                Case "tdbgTab8"
                    sFilter = sFilter8
            End Select
            FilterChangeGrid(c1Grid, sFilter) 'Nếu có Lọc khi In
            ReloadTDBGridTab(c1Grid)
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgTab1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgTab1.KeyPress _
                                                                                                                     , tdbgTab2.KeyPress _
                                                                                                                      , tdbgTab3.KeyPress _
                                                                                                                       , tdbgTab4.KeyPress _
                                                                                                                        , tdbgTab5.KeyPress _
                                                                                                                         , tdbgTab6.KeyPress _
                                                                                                                          , tdbgTab7.KeyPress _
                                                                                                                           , tdbgTab8.KeyPress

        Dim c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        If c1Grid.Columns(c1Grid.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    'Lưu ý: gọi hàm ResetFilter(tdbgTab1, sFilter, bRefreshFilter) tại btnFilter_Click và tsbListAll_Click
    'Bổ sung vào đầu sự kiện tdbgTab1_DoubleClick(nếu có) câu lệnh If tdbgTab1.RowCount <= 0 OrElse tdbgTab1.FilterActive Then Exit Sub




    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3421
    '# Created User: Kim Long
    '# Created Date: 03/10/2017 12:02:23
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3421() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi danh sach nhan vien" & vbCrLf)
        sSQL &= "Exec D25P3421 "
        sSQL &= SQLDateSave(c1dateDateLeftFrom.Value) & COMMA 'DateLeftFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateLeftTo.Value) & COMMA 'DateLeftTo, datetime, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3422
    '# Created User: Kim Long
    '# Created Date: 03/10/2017 01:31:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3422() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi chi tieu thong ke" & vbCrLf)
        sSQL &= "Exec D25P3422 "
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3423
    '# Created User: Kim Long
    '# Created Date: 03/10/2017 01:33:52
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3423() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon chi tieu con" & vbCrLf)
        sSQL &= "Exec D25P3423 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_FieldName).Text) & COMMA 'FieldName, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CaptionID).Text) & COMMA 'CaptionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TableName).Text) 'TableName, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Kim Long
    '# Created Date: 04/10/2017 03:33:15
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMethodID)) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber(3) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber("25") & COMMA 'ModuleID, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3424
    '# Created User: Kim Long
    '# Created Date: 04/10/2017 09:44:08
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3424(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho cac tab " & vbCrLf)
        sSQL &= "Exec D25P3424 "
        sSQL &= SQLString(tdbg1.Columns(COLE_CandidateIDWeb).Text) & COMMA 'CandidateID, varchar[50], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2232
    '# Created User: Kim Long
    '# Created Date: 05/10/2017 02:49:52
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2232() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Thuc thi store luu  du lieu " & vbCrLf)
        sSQL &= "Exec D25P2232 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'TransID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[50], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Kim Long
    '# Created Date: 04/10/2017 02:45:36
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD09T6666s() As StringBuilder
    '    Dim sRet As New StringBuilder
    '    Dim dtSourceGrid As DataTable = CType(tdbg1.DataSource, DataTable)
    '    Dim dr() As DataRow = dtSourceGrid.Select("IsSelected=1")
    '    Dim sSQL As New StringBuilder

    '    For i As Integer = 0 To dr.Length - 1
    '        If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert cac dong duoc check chon tren luoi thong tin ung vien" & vbCrlf)
    '        sSQL.Append("Insert Into D09T6666(")
    '        sSQL.Append("UserID, HostID, Key01ID,Key02ID, Str01, Str02, " & vbCrLf)
    '        sSQL.Append("Str03, Num01, FormID")
    '        sSQL.Append(") Values(" & vbCrlf)
    '        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
    '        sSQL.Append(SQLString(dr(i)(COLE_IDCardNo)) & COMMA) 'Key01ID, varchar[250], NOT NULL
    '        sSQL.Append(SQLString(dr(i)(COLE_CandidateID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
    '        sSQL.Append(SQLStringUnicode(dr(i)("FirstName"), gbUnicode, True) & COMMA) 'Str01, nvarchar[500], NOT NULL
    '        sSQL.Append(SQLStringUnicode(dr(i)("MiddleName"), gbUnicode, True) & COMMA & vbCrLf) 'Str02, nvarchar[4000], NOT NULL
    '        sSQL.Append(SQLStringUnicode(dr(i)("LastName"), gbUnicode, True) & COMMA) 'Str03, nvarchar[500], NOT NULL
    '        sSQL.Append(SQLNumber(i + 1) & COMMA & vbCrLf) 'Num01, decimal, NOT NULL
    '        sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
    '        sSQL.Append(")")

    '        sRet.Append(sSQL.tostring & vbCrLf)
    '        sSQL.Remove(0, sSQL.Length)
    '    Next
    '    Return sRet
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Kim Long
    '# Created Date: 04/10/2017 03:40:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal i As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- abc" & vbCrLf)
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Str01, " & vbCrLf)
        sSQL.Append("Str02, Str03, Num01, FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
        sSQL.Append(SQLString(tdbg1(i, COLE_IDCardNo)) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(tdbg1(i, COLE_CandidateIDWeb)) & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbg1(i, "FirstName"), gbUnicode, True) & COMMA & vbCrLf) 'Str01, nvarchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbg1(i, "MiddleName"), gbUnicode, True) & COMMA) 'Str02, nvarchar[4000], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbg1(i, "LastName"), gbUnicode, True) & COMMA) 'Str03, nvarchar[500], NOT NULL
        sSQL.Append(SQLNumber(1) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLString("D25F1056") & vbCrLf) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/04/2013 11:17:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666(Optional ByVal sFormID As String = "") As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID= " & SQLString(gsUserID) & " AND HostID= " & SQLString(My.Computer.Name)
        If sFormID <> "" Then sSQL &= " AND FormID= " & SQLString(Me.Name)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/04/2013 11:18:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s_Alter(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu bang tam" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID,Str01, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COLE_CandidateID).ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COLE_CandidateName).ToString, gbUnicode, True) & COMMA) 'Str01, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Kim Long
    '# Created Date: 28/09/2017 01:22:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555(ByVal iMode As Integer, ByVal sKey01 As String, ByVal sKey02 As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra" & vbCrLf)
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(sKey01) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(sKey02) & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'Date01, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'Date02, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'Date03, datetime, NOT NULL
        Return sSQL
    End Function

    Private Function CreateIGE_CandidateID(ByVal i As Integer) As Boolean
        Dim dr() As DataRow
        If tdbg1(i, COLE_CandidateID).ToString = "" Then
            Dim sSQL As String
            'Xoa du lieu bang tam
            sSQL = "Delete D09T6666 Where UserID=" & SQLString(gsUserID) & " And HostID=" & SQLString(My.Computer.Name) & " And FormID=" & SQLString("D25F1056") & vbCrLf
            sSQL &= SQLInsertD09T6666(i).ToString() & vbCrLf
            sSQL &= SQLStoreD09P2016() & vbCrLf
            Dim dt1 As DataTable = ReturnDataTable(sSQL)
            If dt1.Rows.Count > 0 Then
                If dt1.Rows(0).Item("Status").ToString = "1" Then
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(dt1.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                    dt1 = Nothing
                    Return False
                Else
                    tdbg1(i, COLE_CandidateID) = dt1.Rows(0).Item("CandidateID").ToString
                    sSQL = "Delete D09T6666 Where UserID=" & SQLString(gsUserID) & " And HostID=" & SQLString(My.Computer.Name) & " And FormID=" & SQLString("D25F1056") & vbCrLf
                    ExecuteSQLNoTransaction(sSQL)
                End If
                dt1 = Nothing
            Else
                D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
                Return False
            End If
        End If

        '****************************
        '-----------Ktra trung Ma NV
        tdbg1.UpdateData()
        dr = dtGrid1.Select("CandidateID= " & SQLString(tdbg1(i, COLE_CandidateID).ToString))
        If dr.Length > 1 Then
            D99C0008.MsgL3(rL3("Ma_ung_vien") & Space(1) & tdbg1(i, COLE_CandidateID).ToString & Space(1) & rL3("da_ton_tai_tren_luoi"))
            Return False
        End If
        Return True
    End Function


    Private Function AllowSave() As Boolean
        If tdbcMethodID.Text.Trim = "" And tdbcMethodID.Enabled Then
            D99C0008.MsgNotYetChoose(lblMethodID.Text)
            tdbcMethodID.Focus()
            Return False
        End If
        tdbg1.UpdateData()
        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If
        Dim dr() As DataRow = dtGrid1.Select("IsSelected = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg1.Focus()
            tdbg1.SplitIndex = SPLIT0
            tdbg1.Col = IndexOfColumn(tdbg1, COLE_IsSelected)
            tdbg1.Row = 0
            Return False
        End If
        For i As Integer = 0 To tdbg1.RowCount - 1
            If Not L3Bool(tdbg1(i, COLE_IsSelected)) Then Continue For
            If D25Systems.AutoCandidateID Then
                If CreateIGE_CandidateID(i) = False Then
                    tdbg1.SplitIndex = 0
                    tdbg1.Focus()
                    tdbg1.Col = IndexOfColumn(tdbg1, COLE_CandidateID)
                    tdbg1.Row = i
                    Return False
                End If
            Else
                If tdbg1(i, COLE_CandidateID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg1.Columns(COLE_CandidateID).Caption)
                    tdbg1.Focus()
                    tdbg1.SplitIndex = 0
                    tdbg1.Col = IndexOfColumn(tdbg1, COLE_CandidateID)
                    tdbg1.Row = i  'findrowInGrid(tdbg1, xxxxKeyValue, xxxxFieldKey)
                    Return False
                Else
                    Dim dr1() As DataRow = dtGrid1.Select("CandidateID= " & SQLString(tdbg1(i, COLE_CandidateID).ToString))
                    If dr1.Length > 1 Then
                        D99C0008.MsgL3(rL3("Ma_ung_vien") & Space(1) & tdbg1(i, COLE_CandidateID).ToString & Space(1) & rL3("da_ton_tai_tren_luoi"))
                        Return False
                    End If
                End If

                If LoadFrameAlter(dr) = False Then Return False
                ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name))
            End If

        Next
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg1.UpdateData()
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        '_bSaveOK = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Dim bRun As Boolean = False
        Dim oBulkCopy As New Lemon3.Data.SqlClient.SqlBulk() 'Nếu Form viết WPF thì dùng new Lemon3.Data.L3SQLBulkCopy()
        oBulkCopy.AddSQLAfter(SQLStoreD25P2232())
        bRun = oBulkCopy.SaveBulkCopy(ReturnTableFilter(dtGrid1, "IsSelected=1", True), "[#F2032_" & gsUserID & "]") 'CheckStore có thông báo Lưu thành công

        Me.Cursor = Cursors.Default

        If bRun Then
            SaveOK()
            '_bSaveOK = True
            tdbg1.AllowUpdate = False
            btnSave.Enabled = False
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Frame Thông báo"

    Private Sub picGroupData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picGroupData.Click
        grpAlter.Visible = False
        '*********************
        Dim dr() As DataRow = dtGrid1.Select("CandidateID= " & SQLString(tdbgAlter(0, COLA_CandidateID)))
        If dr.Length > 0 Then
            tdbg1.SplitIndex = 0
            tdbg1.Focus()
            tdbg1.Col = IndexOfColumn(tdbg1, COLE_CandidateID)
            tdbg1.Row = dtGrid1.Rows.IndexOf(dr(0))
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name))
        picGroupData_Click(Nothing, Nothing)
    End Sub

    Private Function LoadFrameAlter(ByVal dr() As DataRow) As Boolean
        Dim sSQL As New StringBuilder("")
        sSQL.Append("-- Kiem tra ma NV va ma CC ton tai duoi Server" & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666(Me.Name).ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s_Alter(dr).ToString & vbCrLf)
        sSQL.Append("-- Do nguon cho Frame" & vbCrLf)
        sSQL.Append(SQLStoreD25P5555(0, "", "").ToString)
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        'Dim bRunSQL As Boolean = CheckStore(sSQL.ToString, False, , dt)
        If dt.Rows.Count > 0 Then
            grpAlter.Visible = True
            grpAlter.BringToFront()
            lblMessage.Text = "- " & rL3("Cac_ma_ung_vien_da_ton_tai") & Space(1) & rL3("MSG000053") 'Các mã nhân viên đã tồn tại. Bạn không được phép lưu
            lblMessage2.Text = "- " & rL3("Ban_phai_nhap_lai_ma_ung_vien_khac") 'Bạn phải nhập lại mã nhân viên khác
            LoadDataSource(tdbgAlter, dt, gbUnicode)
            ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name).ToString)
            Return False
        End If

        Return True
    End Function
#End Region
End Class