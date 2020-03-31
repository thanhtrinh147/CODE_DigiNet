﻿Imports System.Xml
Imports System
Imports System.IO
Imports System.Drawing
Public Class D25F1051
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dtTeamID As DataTable, dtDepartment As DataTable
    Dim dtEmpGroupID As DataTable
    'Sinh IGE
    Dim eOutputOrder As OutOrderEnum
    Dim sSeparator As String
    Dim bFlag As Boolean

    Dim iOutputLen As Integer
    Dim sImgFileName As String = ""

    Dim orgIGE As String
    Dim bChecked As Boolean = False

    Private _isMSS As Integer = 0
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _parentFrm As String
    Public WriteOnly Property ParentFrm() As String
        Set(ByVal Value As String)
            _parentFrm = Value
        End Set
    End Property

    Private _candidateID As String
    Public Property CandidateID() As String
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String)
            _candidateID = Value
        End Set
    End Property

    Private _divisionID As String = ""
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
            If _divisionID = "" Then _divisionID = gsDivisionID
        End Set
    End Property

    Private _moduleID As String = "25"
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _longBusinessTrip As String
    Public Property LongBusinessTrip() As String
        Get
            Return _longBusinessTrip
        End Get
        Set(ByVal Value As String)
            _longBusinessTrip = Value
        End Set
    End Property

    Private _transferedD09 As String
    Public Property TransferedD09() As String
        Get
            Return _transferedD09
        End Get
        Set(ByVal Value As String)
            _transferedD09 = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            _bSaved = False
            LoadTDBCombo()
            VisibleControl() 'IncidentID	50891
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    LoadAddNew()
                    chkDisabled.Visible = False
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    'btnRelationship.Enabled = ReturnPermission("D25F1050") >= 2
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    btnRelationship.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub VisibleControl()
        If D25Systems.AutoCandidateID Then
            If _FormState = EnumFormState.FormAdd Then ReadOnlyControl(txtCandidateID)
        Else
            tdbcMethodID.Visible = False
            txtCandidateID.Location = tdbcMethodID.Location
            txtCandidateID.Width = txtLastName.Width
            lblMethodID.Visible = False
            lblCandidateID.Location = lblMethodID.Location
        End If

        'IncidentID	50891  Bổ sung theo yêu cầu của BAOTRAN
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView Then
            tdbcMethodID.Visible = False
            txtCandidateID.Location = tdbcMethodID.Location
            txtCandidateID.Width = txtLastName.Width
            lblMethodID.Visible = False
            lblCandidateID.Location = lblMethodID.Location
        End If

    End Sub

    Private Sub D25F1051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            Application.DoEvents()
            tabMain.SelectedTab = TabPage1
            Application.DoEvents()
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            Application.DoEvents()
            tabMain.SelectedTab = tabPage20
            Application.DoEvents()
        ElseIf e.Alt And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            Application.DoEvents()
            tabMain.SelectedTab = TabPage3
            Application.DoEvents()
            txtEquipmentSkill.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
            Application.DoEvents()
            tabMain.SelectedTab = Tabpage4
            Application.DoEvents()
            c1dateMilitaryStatedDate.Focus()
        End If
    End Sub
    Dim clsCheckValid As Lemon3.Controls.CheckEmptyControl

    Private Sub D25F1051_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        If D25Options.ProjectID <> "" Then ReadOnlyControl(tdbcProjectID)
        tabMain.Focus()
        tabPrivate.SelectedTab = TabPage2
        tabMain.SelectedTab = TabPage1
        tabMain.SelectedTab = tabPage20
        tabMain.SelectedTab = TabPage1
        tabMain_Click(Nothing, Nothing)    'IncidentID	50891 Bổ sung
        tdbcMethodID.AutoCompletion = False   'IncidentID	50891 Bổ sung
        CheckIdTextBox(New TextBox() {txtCandidateID, txtDrivingLicenseID})
        CheckIdTextBox(txtIncomeTaxCode, 50)
        CheckIdTextBox(txtEmail, 250)
        txtEmail.CharacterCasing = CharacterCasing.Normal
        CheckIdTextBox(txtIDCardNo, 12)
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateIDCardDate, c1dateBirthDate, c1datePITIssueDate, c1dateIDCardDate, c1dateBirthDate, c1dateReceivedDate, c1dateStartingDate, c1dateMilitaryEndedDate, c1dateMilitaryStatedDate)
        clsCheckValid = New Lemon3.Controls.CheckEmptyControl(pnlDepart, Me.Name)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_danh_muc_ung_cu_vien_-_D25F1051") & UnicodeCaption(gbUnicode) 'CËp nhËt danh móc ÷ng cõ vi£n - D25F1051
        '================================================================ 
        lblHealth.Text = rl3("Suc_khoe") 'Sức khỏe
        lblMilitaryEntra.Text = rl3("Gia_nhap") 'Gia nhập
        lblMilitary.Text = rl3("Quan_ngu") 'Quân ngũ
        lblEmployeeStreet.Text = rL3("Dia_chi")
        lblContactAddress.Text = rl3("Dia_chi_lien_lac") 'Địa chỉ liên lạc
        lblTelephone.Text = rl3("Dien_thoai") 'Điện thoại
        lblPaper.Text = rl3("Di_dong") 'Di động
        lblteBirthDate.Text = rl3("Ngay_sinh") 'Ngày sinh
        lblEthnicID.Text = rl3("Dan_toc") 'Dân tộc
        lblBirthPlace.Text = rl3("Noi_sinh") 'Nơi sinh
        lblCountryName.Text = rl3("Quoc_tich") 'Quốc tịch
        lblReligionName.Text = rl3("Ton_giao") 'Tôn giáo
        lblLastName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblIDCardNo.Text = rl3("So_CMND") 'Số CMND
        lblteIDCardDate.Text = rl3("Ngay_cap") 'Ngày cấp
        lblIDCardPlace.Text = rl3("Noi_cap") 'Nơi cấp
        lblMaritalStatus.Text = rL3("TT_hon_nhan") 'TT hôn nhân
        lblChildrenQuan.Text = rl3("So_con") 'Số con
        lblteMilitaryStatedDate.Text = rl3("Tu") 'Từ
        lblteMilitaryEndedDate.Text = rl3("Den") 'Đến
        lblMilitaryRank.Text = rl3("Quan_ham") 'Quân hàm
        lblHeight.Text = rl3("Chieu_cao") 'Chiều cao
        lblWeight.Text = rl3("Can_nang") 'Cân nặng
        lblHealthStatus.Text = rl3("Tinh_trang") 'Tình trạng
        lblRec.Text = rl3("Bo_phan_ung_tuyen") 'Bộ phận ứng tuyển
        lblteReceivedDate.Text = rL3("Ngay_nhan_ho_so") 'Ngày nhận hồ sơ
        lblReceivedPlace.Text = rl3("Noi_nhan") 'Nơi nhận
        lblFileReceiver.Text = rl3("Nguoi_nhan") 'Người nhận
        lblRecSourceID.Text = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        lblSuggester.Text = rl3("Ho_va_ten") 'Họ và tên
        lblSuggesterDivision.Text = rl3("Don_vi") 'Đơn vị
        lblSuggesterDepartment.Text = rl3("Phong_ban") 'Phòng ban
        lblSuggesterDuty.Text = rl3("Chuc_vu") 'Chức vụ
        lblRelationName.Text = rl3("Quan_he") 'Quan hệ
        lblRecDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblDesiredSalary.Text = rl3("Luong_yeu_cau") 'Lương yêu cầu
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblReason.Text = rl3("Ly_do_ung_tuyen") 'Lý do ứng tuyển
        lblteStartingDate.Text = rl3("Ngay_co_the_bat_dau") 'Ngày có thể bắt đầu
        lblEquipmentSkill.Text = rl3("Su_dung_thiet_bi_van_phong") 'Sử dụng thiết bị văn phòng
        lblRemark.Text = rL3("Danh_gia_truoc_phong_van") 'Đánh giá trước phỏng vấn
        lblOther.Text = rl3("Khac") 'Khác
        lblSkill.Text = rl3("Ky_nang") 'Kỹ năng
        lblAptitude.Text = rL3("Ky_nang_khac") 'Kỹ năng khác
        lblHobby.Text = rl3("So_thich") 'Sở thích
        lblOtherDesire.Text = rl3("De_xuat_cua_ung_cu_vien") 'Đề xuất của ứng cử viên
        lblRemarkID.Text = rL3("Tinh_trang_xu_ly_ho_so") 'Tình trạng xử lý hồ sơ
        lblFileType.Text = rl3("Loai_ho_so") 'Loại hồ sơ
        lblRemarkBeforeInterview.Text = rL3("Ghi_chu") 'Ghi chú
        lblGetPhoto.Text = rl3("Nhan_vao_day") 'Nhấn vào đây
        lblGetPhoto2.Text = rl3("de_chon_hinh") 'để chọn hình
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblEducationLevel_Line.Text = rl3("Trinh_do")
        lblDrivingLicenseID.Text = rl3("Giay_phep_lai_xe")
        lblEducationLevelID.Text = rl3("TD_van_hoa") 'TĐ văn hóa
        lblProfessionalLevelID.Text = rl3("TD_chuyen_mon") 'TĐ chuyên môn
        lblPoliticsID.Text = rl3("TD_chinh_tri") 'TĐ chính trị
        lblShiftID.Text = rl3("Ca_lam_viec")
        lblCandidateID.Text = rL3("Ma_ung_cu_vien") 'Mã ứng cử viên
        lblMethodID.Text = rl3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        lblSuggesterID.Text = rL3("Ma_nhan_vien") 'Mã nhân viên
        lblJob.Text = rl3("Cong_viec")
        lblProvisionalAddress.Text = rL3("Dia_chi")
        lblEmContactName1.Text = rl3("Ten")
        lblEmRelationName1.Text = rl3("Moi_quan_he")
        lblEmContactPhone1.Text = rl3("So_dien_thoai")
        lblEmContactAddress1.Text = rL3("Dia_chi_lien_lac") 'Địa chỉ liên lạc
        lblTrousersSizeName.Text = rl3("Kich_co_quan")
        lblShirtSizeName.Text = rl3("Kich_co_ao")
        lblShoesSizeName.Text = rl3("Kich_co_giay")
        lblWorkName.Text = rl3("Cong_viec_ung_tuyen")
        lblJobDescription.Text = rl3("Mo_ta_cong_viec")
        lblPastRecruits.Text = rl3("Cong_viec_truoc_day")
        lblProjectID.Text = rL3("Du_an_U")
        lblClothesSize.Text = rL3("Kich_co_do_sach")
        lblDivisionID.Text = rL3("Don_vi_ung_tuyen") 'Đơn vị ứng tuyển
        lblGioiTinh.Text = rL3("Gioi_tinh") 'Giới tính
        lblPITIssueDate.Text = rL3("Ngay_cap") 'Ngày cấp
        lblPITIssuePlaceID.Text = rL3("Noi_cap") 'Nơi cấp
        lblIncomeTaxCode.Text = rL3("Ma_so_thue") 'Mã số thuế
        lblNativePlace.Text = rL3("Que_quan") 'Quê quán
        lblPopulationID.Text = rL3("Ho_khau") 'Hộ khẩu
        lblEmpGroupID.Text = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        lblConAddressStreet.Text = rL3("So_nha") 'Số nhà
        lblResAddressStreet.Text = rL3("So_nha") 'Số nhà
        '================================================================ 
        btnQTDT.Text = rL3("_Qua_trinh_dao_tao") '&Quá trình đào tạo
        btnKNLV.Text = "&" & rl3("Kinh_nghiem_lam_viec") 'rl3("_Kinh_nghiep_lam_viec") '&Kinh nghiệm làm việc
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnRelationship.Text = rl3("Quan_he__gia_dinh") 'Quan hệ &gia đình
        btnHisInterview.Text = rL3("Lich__su_phong_van")
        btnDocType.Text = rL3("_Giay_to_tuy_than") '&Giấy tờ tùy thân
        '================================================================ 
        chkLongBusinesstrip.Text = rL3("Chap_nhan_di_cong_tac_xa") 'Chấp nhận đi công tác xa
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optGirl.Text = rl3("Nu_U") 'Nữ
        optBoy.Text = rL3("NamV") 'Nam
        '================================================================ 
        grpSuggest.Text = rL3("Nguoi_gioi_thieu") 'Người giới thiệu
        grpInfoRec.Text = rL3("Thong_tin_tuyen_dung") 'Thông tin tuyển dụng
        grpSize.Text = rL3("Thong_tin_kich_co")
        grpContact.Text = rL3("Lien_he_khan_cap")
        grpInfo.Text = rL3("Thong_tin_lien_lac") 'Thông tin liên lạc
        grpBirthPlace.Text = rL3("Noi_sinh") & Space(1) & " (" & rL3("Noi_cap_giay_khai_sinh") & ")" 'Nơi sinh (Nơi cấp giấy khai sinh)
        grpConAddress.Text = rL3("Dia_chi_thuong_tru") & " (" & rL3("Dia_chi_dang_ky_ho_khau") & ")" 'Địa chỉ thường trú (Địa chỉ đăng ký hộ khẩu)
        grpProvisional.Text = rL3("Dia_chi_tam_tru") & " (" & rL3("Dia_chi_lien_he") & ")" 'Địa chỉ tạm trú (Địa chỉ liên hệ)
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Ca_nhan") ' rl3("1_Ca_nhan") '1. Cá nhân 
        tabPage20.Text = "2. " & rl3("Tuyen_dung") 'rl3("2_Tuyen_dung") '2. Tuyển dụng
        TabPage3.Text = "3. " & rl3("Ky_nang") '3. Kỹ năng
        Tabpage4.Text = "4. " & rl3("Khac")
        TabPage2.Text = "1. " & rl3("Thong_tin_chung")
        TabPage5.Text = "2. " & rl3("Thong_tin_lien_he")
        TabPage6.Text = "3. " & rl3("Trang_thiet_bi")
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        tdbcZoneCode.Columns("ZoneCode").Caption = rl3("Ma")
        tdbcZoneCode.Columns("ZoneName").Caption = rl3("Ten")
        tdbcRelationName.Columns("RelationID").Caption = rl3("Ma")
        tdbcRelationName.Columns("RelationName").Caption = rl3("Ten")
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcMaritalStatus.Columns("Description").Caption = rL3("Ten") 'Tên
        tdbcMilitaryRank.Columns("MilitaryRank").Caption = rl3("Ma") 'Mã
        tdbcMilitaryRank.Columns("MilitaryName").Caption = rl3("Ten") 'Tên
        tdbcReligionID.Columns("ReligionID").Caption = rl3("Ma") 'Mã
        tdbcReligionID.Columns("ReligionName").Caption = rl3("Ten") 'Tên
        tdbcNationalityID.Columns("NationalityID").Caption = rl3("Ma") 'Mã
        tdbcNationalityID.Columns("CountryName").Caption = rl3("Ten") 'Tên
        tdbcEthnicID.Columns("EthnicID").Caption = rl3("Ma") 'Mã
        tdbcEthnicID.Columns("EthnicName").Caption = rl3("Ten") 'Tên
        tdbcCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("CurrencyName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcProjectID.Columns(0).Caption = rl3("Ma") 'Mã
        tdbcProjectID.Columns(1).Caption = rl3("Ten") 'Tên
        tdbcRecDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcRecDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcRecSourceID.Columns("RecSourceID").Caption = rl3("Ma") 'Mã
        tdbcRecSourceID.Columns("RecSourceName").Caption = rl3("Ten") 'Tên
        tdbcFileReceiver.Columns("FileReceiver").Caption = rl3("Ma") 'Mã
        tdbcFileReceiver.Columns("FileReceiverName").Caption = rl3("Ten") 'Tên
        tdbcFileType.Columns("FileTypeName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbcRemarkID.Columns("RemarkName").Caption = rL3("Ten") 'Tên
        tdbcEducationLevelID.Columns("EducationLevelID").Caption = rL3("Ma") 'Mã
        tdbcEducationLevelID.Columns("EducationLevelName").Caption = rl3("Ten") 'Tên
        tdbcProfessionalLevelID.Columns("ProfessionalLevelID").Caption = rl3("Ma") 'Mã
        tdbcProfessionalLevelID.Columns("ProfessionalLevelName").Caption = rl3("Ten") 'Tên
        tdbcPoliticsID.Columns("PoliticsID").Caption = rl3("Ma") 'Mã
        tdbcPoliticsID.Columns("PoliticsName").Caption = rl3("Ten") 'Tên
        tdbcShiftID.Columns("ShiftID").Caption = rL3("Ma")
        tdbcShiftID.Columns("ShiftName").Caption = rl3("Ten")
        tdbcSuggesterID.Columns("SuggesterID").Caption = rL3("Ma")
        tdbcSuggesterID.Columns("Suggester").Caption = rl3("Ten")
        tdbcWorkName.Columns(0).Caption = rL3("Ma")
        tdbcWorkName.Columns(1).Caption = rl3("Ten")
        tdbcEmRelationName1.Columns(0).Caption = rl3("Ma")
        tdbcEmRelationName1.Columns(1).Caption = rl3("Ten")
        tdbcEmRelationName2.Columns(0).Caption = rl3("Ma")
        tdbcEmRelationName2.Columns(1).Caption = rl3("Ten")
        tdbcTrousersSizeName.Columns(0).Caption = rl3("Ma")
        tdbcTrousersSizeName.Columns(1).Caption = rl3("Ten")
        tdbcShirtSizeName.Columns(0).Caption = rl3("Ma")
        tdbcShirtSizeName.Columns(1).Caption = rl3("Ten")
        tdbcShoesSizeName.Columns(0).Caption = rl3("Ma")
        tdbcShoesSizeName.Columns(1).Caption = rl3("Ten")
        tdbcClothesSizeName.Columns(0).Caption = rl3("Ma")
        tdbcClothesSizeName.Columns(1).Caption = rL3("Ten")
        tdbcPopulationID.Columns("PopulationID").Caption = rL3("Ma")
        tdbcPopulationID.Columns("PopulationName").Caption = rL3("Ten")
        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rL3("Ma")
        tdbcEmpGroupID.Columns("EmpGroupName").Caption = rL3("Ten")
        tdbcPITIssuePlaceID.Columns("PITIssuePlaceID").Caption = rL3("Ma")
        tdbcPITIssuePlaceID.Columns("PITIssuePlaceName").Caption = rL3("Ten")
    End Sub

    Private Sub LoadAddNew()

        btnEnclourse.Text = rl3("Dinh_ke_m") 'Đính kè&m
        txtReceivedPlace.Text = D25Systems.IntPlaceDefault
        EnableButton(False)
        c1dateStartingDate.Value = Now()

        SetNew()

        If _parentFrm = "D25F1055" Then
            Dim dt As DataTable = ReturnDataTable(SQLStoreD25P1055)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtLastName.Text = dr("LastName").ToString
                txtMiddleName.Text = dr("Middlename").ToString
                txtFirstName.Text = dr("FirstName").ToString

                If dr("Sex").ToString = "0" Then
                    optBoy.Checked = True
                Else
                    optGirl.Checked = True
                End If
                c1dateBirthDate.Value = SQLDateShow(dr("BirthDate").ToString)
                txtBirthPlace.Text = dr("BirthPlace").ToString
                tdbcEthnicID.SelectedValue = dr("EthnicID").ToString
                tdbcReligionID.SelectedValue = dr("ReligionID").ToString
                txtIDCardNo.Text = dr("IDCardNo").ToString
                tdbcNationalityID.SelectedValue = dr("NationalityID").ToString
                c1dateIDCardDate.Value = dr("IDCardDate").ToString
                tdbcZoneCode.SelectedValue = dr("IDCardPlaceID").ToString
                txtProvisionalAddress.Text = dr("ProvisionalAddress").ToString
                txtEmContactName1.Text = dr("EmContactName1").ToString
                txtEmContactName2.Text = dr("EmContactName2").ToString
                txtEmContactPhone1.Text = dr("EmContactPhone1").ToString
                txtEmContactPhone2.Text = dr("EmContactPhone2").ToString
                txtEmContactAddress1.Text = dr("EmContactAddress1").ToString
                txtEmContactAddress2.Text = dr("EmContactAddress2").ToString
                txtJobDescription.Text = dr("JobDescription").ToString
                txtPastRecruits.Text = dr("PastRecruits").ToString
                tdbcWorkName.SelectedValue = dr("WorkID").ToString
                tdbcEmRelationName1.SelectedValue = dr("EmRelationID1").ToString
                tdbcEmRelationName2.SelectedValue = dr("EmRelationID2").ToString
                tdbcTrousersSizeName.SelectedValue = dr("TrousersSize").ToString
                tdbcShirtSizeName.SelectedValue = dr("ShirtSize").ToString
                tdbcShoesSizeName.SelectedValue = dr("ShoesSize").ToString
                tdbcClothesSizeName.SelectedValue = dr("ClothesSize").ToString
                'Thông tin liên lạc
                txtPermanentAddress.Text = dr("PermanentAddress").ToString
                txtContactAddress.Text = dr("ContactAddress").ToString
                txtTelephone.Text = dr("Telephone").ToString
                txtMobile.Text = dr("Mobile").ToString
                txtEmail.Text = dr("Email").ToString
                txtFax.Text = dr("Fax").ToString
                'Trình độ
                tdbcEducationLevelID.SelectedValue = dr("EducationLevelID").ToString
                tdbcProfessionalLevelID.SelectedValue = dr("ProfessionalLevelID").ToString
                tdbcPoliticsID.SelectedValue = dr("PoliticsID").ToString
                'Quân ngũ
                c1dateMilitaryStatedDate.Value = SQLDateShow(dr("MilitaryStartedDate").ToString)
                c1dateMilitaryEndedDate.Value = SQLDateShow(dr("MilitaryEndedDate").ToString)
                tdbcMilitaryRank.SelectedValue = dr("MilitaryRank").ToString
                'Tab2
                'Thông tin tuyển dụng
                LoadTdbcFileReceiverID(ReturnValueC1Combo(tdbcDepartmentID).ToString)
                'Bộ phận ứng viên
                tdbcRecDepartmentID.SelectedValue = dr("RecDepartmentID").ToString
                tdbcRecTeamID.SelectedValue = dr("RecTeamID").ToString
            End If
        End If
        bFlag = True
    End Sub

    Private Sub SetNew()
        ClearText(Me)
       
        tdbcProjectID.SelectedValue = D25Options.ProjectID
        optBoy.Checked = True
        tdbcMaritalStatus.SelectedIndex = 0
        txtChildrenQuan.Text = "0"
        'Mặc định Dân tộc Kinh, Tôn giáo không, Quốc tịch Việt Nam
        Dim MatchIndex As Integer = tdbcEthnicID.FindString("KINH")
        If MatchIndex <> -1 Then
            tdbcEthnicID.SelectedIndex = MatchIndex
        Else
            tdbcEthnicID.SelectedValue = ""
        End If
        MatchIndex = tdbcReligionID.FindString(IIf(gbUnicode, "KHÔNG", "KHOÂNG").ToString)
        If MatchIndex <> -1 Then
            tdbcReligionID.SelectedIndex = MatchIndex
        Else
            tdbcReligionID.SelectedValue = ""
        End If
        MatchIndex = tdbcNationalityID.FindString(IIf(gbUnicode, "Việt Nam".ToUpper, "VIEÄT NAM").ToString)
        If MatchIndex <> -1 Then
            tdbcNationalityID.SelectedIndex = MatchIndex
        Else
            tdbcNationalityID.SelectedValue = ""
        End If

        'Sức khỏe
        txtHeight.Text = "0.00"
        txtWeight.Text = "0.00"
        txtHealthStatus.Text = ""

        'Tab2
        'Thông tin tuyển dụng
        c1dateReceivedDate.Value = Now.Date
        'Bộ phận ứng viên
        tdbcRecPositionID.SelectedIndex = 0
        txtDesiredSalary.Text = "0.00"
        chkLongBusinesstrip.Checked = False
        ' Đánh giá
     
        tdbcRemarkID.SelectedIndex = 0

        picCandidate.Image = Nothing
        lblGetPhoto.Visible = True
        lblGetPhoto2.Visible = True
        sImgFileName = ""
    End Sub
    Private Sub EnableButton(ByVal bEnable As Boolean)
        btnQTDT.Enabled = bEnable
        btnKNLV.Enabled = bEnable
        btnEnclourse.Enabled = bEnable
        btnHisInterview.Enabled = bEnable
        btnRelationship.Enabled = bEnable AndAlso ReturnPermission("D25F1050") >= 2
        btnDocType.Enabled = bEnable AndAlso ReturnPermission("D25F1050") >= 1
    End Sub
    Private Sub LoadEdit()
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        btnHisInterview.Enabled = True
        LoadEditData()
        btnEnclourse.Text = rL3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")"
        ReadOnlyControl(txtCandidateID)
    End Sub

    Private Sub LoadEditData()
        Dim sImage As String = ""
        Dim sSQL As String = SQLStoreD25P1051()
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count <= 0 Then Exit Sub

        'Tab1
        txtCandidateID.Text = dt.Rows(0).Item("CandidateID").ToString
        txtLastName.Text = dt.Rows(0).Item("LastName").ToString
        txtMiddleName.Text = dt.Rows(0).Item("MiddleName").ToString
        txtFirstName.Text = dt.Rows(0).Item("FirstName").ToString

        If dt.Rows(0).Item("Sex").ToString = "0" Then
            optBoy.Checked = True
        Else
            optGirl.Checked = True
        End If
        c1dateBirthDate.Value = SQLDateShow(dt.Rows(0).Item("BirthDate").ToString)
        txtBirthPlace.Text = dt.Rows(0).Item("BirthPlace").ToString
        tdbcEthnicID.SelectedValue = dt.Rows(0).Item("EthnicID").ToString
        tdbcReligionID.SelectedValue = dt.Rows(0).Item("ReligionID").ToString
        txtIDCardNo.Text = dt.Rows(0).Item("IDCardNo").ToString
        tdbcNationalityID.SelectedValue = dt.Rows(0).Item("NationalityID").ToString
        c1dateIDCardDate.Value = dt.Rows(0).Item("IDCardDate").ToString
        tdbcZoneCode.SelectedValue = dt.Rows(0).Item("IDCardPlaceID").ToString
        tdbcMaritalStatus.SelectedValue = dt.Rows(0).Item("MaritalStatus").ToString
        txtChildrenQuan.Text = dt.Rows(0).Item("ChildrenQuan").ToString
        '****************
        If c1dateBirthDate.Text <> "" Then
            Dim d As Date = CDate(c1dateBirthDate.Text)
            If Number(dt.Rows(0).Item("UnDefinedBD")) = 0 Then 'Load ngay,thang,nam
                txtNumday.Text = d.Day.ToString
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
            ElseIf Number(dt.Rows(0).Item("UnDefinedBD")) = 1 Then 'Chi load nam
                txtNumYear.Text = d.Year.ToString
                txtNumday.Text = ""
                txtNumMonth.Text = ""
            ElseIf Number(dt.Rows(0).Item("UnDefinedBD")) = 2 Then 'Chi load thang,nam
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
                txtNumday.Text = ""
            End If
        Else
            txtNumday.Text = ""
            txtNumMonth.Text = ""
            txtNumYear.Text = ""
        End If
        '*********************
        txtJobDescription.Text = dt.Rows(0).Item("JobDescription").ToString
        txtPastRecruits.Text = dt.Rows(0).Item("PastRecruits").ToString
        tdbcWorkName.SelectedValue = dt.Rows(0).Item("WorkID").ToString
        tdbcEmRelationName1.SelectedValue = dt.Rows(0).Item("EmRelationID1").ToString
        tdbcEmRelationName2.SelectedValue = dt.Rows(0).Item("EmRelationID2").ToString
        tdbcTrousersSizeName.SelectedValue = dt.Rows(0).Item("TrousersSize").ToString
        tdbcShirtSizeName.SelectedValue = dt.Rows(0).Item("ShirtSize").ToString
        tdbcShoesSizeName.SelectedValue = dt.Rows(0).Item("ShoesSize").ToString
        tdbcClothesSizeName.SelectedValue = dt.Rows(0).Item("ClothesSize").ToString
        'Trình độ
        tdbcEducationLevelID.SelectedValue = dt.Rows(0).Item("EducationLevelID").ToString
        tdbcProfessionalLevelID.SelectedValue = dt.Rows(0).Item("ProfessionalLevelID").ToString
        tdbcPoliticsID.SelectedValue = dt.Rows(0).Item("PoliticsID").ToString
        'Quân ngũ
        c1dateMilitaryStatedDate.Value = SQLDateShow(dt.Rows(0).Item("MilitaryStartedDate").ToString)
        c1dateMilitaryEndedDate.Value = SQLDateShow(dt.Rows(0).Item("MilitaryEndedDate").ToString)
        tdbcMilitaryRank.SelectedValue = dt.Rows(0).Item("MilitaryRank").ToString
        'Sức khỏe
        txtHeight.Text = Format(Number(dt.Rows(0).Item("Height")), D25Format.DefaultNumber2)
        txtWeight.Text = Format(Number(dt.Rows(0).Item("Weight")), D25Format.DefaultNumber2)
        txtHealthStatus.Text = dt.Rows(0).Item("HealthStatus").ToString
        'Tab2
        'Thông tin tuyển dụng
        tdbcDivisionID.SelectedValue = dt.Rows(0).Item("DivisionID").ToString
        tdbcDepartmentID.SelectedValue = dt.Rows(0).Item("DepartmentID").ToString
        LoadTdbcFileReceiverID(ReturnValueC1Combo(tdbcDepartmentID).ToString)
        tdbcFileReceiver.SelectedValue = dt.Rows(0).Item("FileReceiver").ToString
        c1dateReceivedDate.Value = SQLDateShow(dt.Rows(0).Item("ReceivedDate").ToString)
        txtReceivedPlace.Text = dt.Rows(0).Item("ReceivedPlace").ToString
        tdbcRecSourceID.SelectedValue = dt.Rows(0).Item("RecSourceID").ToString
        'Người giới thiệu
        txtSuggester.Text = dt.Rows(0).Item("Suggester").ToString
        txtSuggesterDivision.Text = dt.Rows(0).Item("SuggesterDivision").ToString
        txtSuggesterDepartment.Text = dt.Rows(0).Item("SuggesterDepartment").ToString
        txtSuggesterDuty.Text = dt.Rows(0).Item("SuggesterDuty").ToString
        tdbcRelationName.SelectedValue = dt.Rows(0).Item("SuggesterRelationID").ToString

        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        tdbcSuggesterID.Text = dt.Rows(0).Item("SuggesterID").ToString
        'Bộ phận ứng viên
        tdbcRecDepartmentID.SelectedValue = dt.Rows(0).Item("RecDepartmentID").ToString
        tdbcRecTeamID.SelectedValue = dt.Rows(0).Item("RecTeamID").ToString
        tdbcRecPositionID.SelectedValue = dt.Rows(0).Item("RecPositionID").ToString
        cneExperienceYear.Value=L3Int(dt.Rows(0).Item("ExperienceYear"))
        tdbcProjectID.SelectedValue = dt.Rows(0).Item("ProjectID").ToString
        txtDesiredSalary.Text = Format(Number(dt.Rows(0).Item("DesiredSalary").ToString), D25Format.DefaultNumber2)
        tdbcCurrencyID.SelectedValue = dt.Rows(0).Item("CurrencyID").ToString
        chkLongBusinesstrip.Checked = L3Bool(dt.Rows(0).Item("LongBusinesstrip"))
        txtReason.Text = dt.Rows(0).Item("Reason").ToString
        c1dateStartingDate.Value = SQLDateShow(dt.Rows(0).Item("StartingDate").ToString)
        ' Tab 3
        ' Kỷ năng
        txtEquipmentSkill.Text = dt.Rows(0).Item("EquipmentSkill").ToString
        txtAptitude.Text = dt.Rows(0).Item("Aptitude").ToString
        ' Khác
        txtHobby.Text = dt.Rows(0).Item("Hobby").ToString
        txtOtherDesire.Text = dt.Rows(0).Item("OtherDesire").ToString
        txtDrivingLicenseID.Text = dt.Rows(0).Item("DrivingLicenseID").ToString
        tdbcShiftID.SelectedValue = dt.Rows(0).Item("ShiftID")

        ' Đánh giá
        tdbcFileType.SelectedValue = dt.Rows(0).Item("FileType").ToString
        txtRemarkBeforeInterview.Text = dt.Rows(0).Item("RemarkBeforeInterview").ToString
        tdbcRemarkID.SelectedValue = dt.Rows(0).Item("RemarkID").ToString
        chkDisabled.Checked = L3Bool(dt.Rows(0).Item("Disabled"))
        'ID 54204
        txtIncomeTaxCode.Text = dt.Rows(0).Item("IncomeTaxCode").ToString
        c1datePITIssueDate.Value = SQLDateShow(dt.Rows(0).Item("PITIssueDate").ToString)
        tdbcPITIssuePlaceID.SelectedValue = dt.Rows(0).Item("PITIssuePlaceID").ToString
        txtNativePlace.Text = dt.Rows(0).Item("NativePlace").ToString
        tdbcPopulationID.SelectedValue = dt.Rows(0).Item("PopulationID").ToString
        tdbcEmpGroupID.SelectedValue = dt.Rows(0).Item("EmpGroupID").ToString
        '*****************************************
        'Thông tin liên hệ
        txtPermanentAddress.Text = dt.Rows(0).Item("PermanentAddress").ToString
        txtContactAddress.Text = dt.Rows(0).Item("ContactAddress").ToString
        txtTelephone.Text = dt.Rows(0).Item("Telephone").ToString
        txtMobile.Text = dt.Rows(0).Item("Mobile").ToString
        txtEmail.Text = dt.Rows(0).Item("Email").ToString
        txtFax.Text = dt.Rows(0).Item("Fax").ToString
        txtProvisionalAddress.Text = dt.Rows(0).Item("ProvisionalAddress").ToString
        txtEmContactName1.Text = dt.Rows(0).Item("EmContactName1").ToString
        txtEmContactName2.Text = dt.Rows(0).Item("EmContactName2").ToString
        txtEmContactPhone1.Text = dt.Rows(0).Item("EmContactPhone1").ToString
        txtEmContactPhone2.Text = dt.Rows(0).Item("EmContactPhone2").ToString
        txtEmContactAddress1.Text = dt.Rows(0).Item("EmContactAddress1").ToString
        txtEmContactAddress2.Text = dt.Rows(0).Item("EmContactAddress2").ToString
        'ID 81526 11/01/2016
        tdbcBirthPlaceProvinceID.SelectedValue = dt.Rows(0).Item("BirthPlaceProvinceID").ToString
        tdbcBirthPlaceDistrictID.SelectedValue = dt.Rows(0).Item("BirthPlaceDistrictID").ToString
        tdbcBirthPlaceWardID.SelectedValue = dt.Rows(0).Item("BirthPlaceWardID").ToString
        tdbcBPWLabelID.SelectedValue = dt.Rows(0).Item("BPWLabelID").ToString
        tdbcBPDLabelID.SelectedValue = dt.Rows(0).Item("BPDLabelID").ToString
        tdbcBPPLabelID.SelectedValue = dt.Rows(0).Item("BPPLabelID").ToString
        txtConAddressStreet.Text = dt.Rows(0).Item("ConAddressStreet").ToString
        tdbcConAddressProvinceID.SelectedValue = dt.Rows(0).Item("ConAddressProvinceID").ToString
        tdbcConAddressDistrictID.SelectedValue = dt.Rows(0).Item("ConAddressDistrictID").ToString
        tdbcConAddressWardID.SelectedValue = dt.Rows(0).Item("ConAddressWardID").ToString
        tdbcCAWLabelID.SelectedValue = dt.Rows(0).Item("CAWLabelID").ToString
        tdbcCADLabelID.SelectedValue = dt.Rows(0).Item("CADLabelID").ToString
        tdbcCAPLabelID.SelectedValue = dt.Rows(0).Item("CAPLabelID").ToString
        txtResAddressStreet.Text = dt.Rows(0).Item("ResAddressStreet").ToString
        tdbcResAddressProvinceID.SelectedValue = dt.Rows(0).Item("ResAddressProvinceID").ToString
        tdbcResAddressDistrictID.SelectedValue = dt.Rows(0).Item("ResAddressDistrictID").ToString
        tdbcResAddressWardID.SelectedValue = dt.Rows(0).Item("ResAddressWardID").ToString
        tdbcRAWLabelID.SelectedValue = dt.Rows(0).Item("RAWLabelID").ToString
        tdbcRADLabelID.SelectedValue = dt.Rows(0).Item("RADLabelID").ToString
        tdbcRAPLabelID.SelectedValue = dt.Rows(0).Item("RAPLabelID").ToString
        '*****************************************
        picCandidate.Image = ReturnImage(dt.Rows(0).Item("ImageID"))
        If picCandidate.Image IsNot Nothing Then
            lblGetPhoto.Visible = False
            lblGetPhoto2.Visible = False
        End If
        sImgFileName = "Original"
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1051
    '# Created User: Phan Văn Thông
    '# Created Date: 06/09/2012 03:10:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho form " & vbCrLf)
        sSQL &= "Exec D25P1051 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CandidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber("0") 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        Dim sUnicode As String = UnicodeJoin(gbUnicode)
        'Load tdbcZoneCode
        sSQL = "Select     ZoneCode, ZoneName" & sUnicode & " as ZoneName" & vbCrLf
        sSQL &= "From       D91T1620 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where      ZoneLevelID = 'TINH/THANH' And Disabled = 0" & vbCrLf
        sSQL &= "Order By   ZoneName" & vbCrLf
        LoadDataSource(tdbcZoneCode, sSQL, gbUnicode)

        'Load tdbcEthnicID
        sSQL = "Select EthnicID, EthnicName" & UnicodeJoin(gbUnicode) & " as EthnicName From D09T0203 WITH(NOLOCK)  Where Disabled = 0 Order By EthnicID"
        LoadDataSource(tdbcEthnicID, sSQL, gbUnicode)
        'Load tdbcReligionName
        sSQL = "Select ReligionID,ReligionName" & UnicodeJoin(gbUnicode) & " as ReligionName From D09T0204 WITH(NOLOCK)  Where Disabled = 0 Order By ReligionID"
        LoadDataSource(tdbcReligionID, sSQL, gbUnicode)

        'Load tdbcCountryName
        sSQL = "Select CountryID as NationalityID, CountryName" & UnicodeJoin(gbUnicode) & " as CountryName From D91T0017 WITH(NOLOCK)  Where Disabled = 0 Order By CountryID"
        LoadDataSource(tdbcNationalityID, sSQL, gbUnicode)
        'Load tdbcMaritalStatus
        'sSQL = " Select 0 as MaritalStatus, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Ñoäc thaân'", "'Single'").ToString & " as Description" & vbCrLf
        'sSQL &= " Union" & vbCrLf
        'sSQL &= " Select 1 as MaritalStatus, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Ñaõ keát hoân'", "'Married'").ToString & " as Description" & vbCrLf
        'sSQL &= "Order by MaritalStatus"

        sSQL = "Select 0 as MaritalStatus, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Ñoäc thaân'", "'Single'").ToString & " as Description" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 1 as MaritalStatus, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Keát hoân'", "'Married'").ToString & " as Description" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 2 as MaritalStatus, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Ly dò'", "'Divorce'").ToString & " as Description" & vbCrLf
        sSQL &= "Order by MaritalStatus" & vbCrLf
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If gbUnicode Then ConvertVniToUnicode(dt)
        LoadDataSource(tdbcMaritalStatus, dt, gbUnicode)
        'Load tdbcMilitaryRank
        sSQL = "Select ArmyRankID as MilitaryRank,ArmyRankName" & UnicodeJoin(gbUnicode) & " as MilitaryName From D09T1020 WITH(NOLOCK)  Where Disabled = 0 Order By ArmyRankID"
        LoadDataSource(tdbcMilitaryRank, sSQL, gbUnicode)

        'Load tdbcFileReceiver
        LoadTdbcFileReceiverID(ReturnValueC1Combo(tdbcDepartmentID).ToString)

        'Load tdbcRecSourceID
        sSQL = "Select RecSourceID, RecSourceName" & UnicodeJoin(gbUnicode) & " as RecSourceName From D25T1010  WITH(NOLOCK)  Where Disabled = 0 Order by RecSourceID  "
        LoadDataSource(tdbcRecSourceID, sSQL, gbUnicode)

        'Load tdbcRecTeamID
        dtTeamID = ReturnTableTeamID_D09P6868("%", "D25F1050", _isMSS)

        'Load tdbcRecPositionID
        sSQL = "SELECT		DutyID AS RecPositionID, DutyName" & UnicodeJoin(gbUnicode) & " as RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	RecPositionName" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        'Load tdbcCurrencyID
        sSQL = "Select CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " as CurrencyName From  D91T0010 WITH(NOLOCK)  Where Disabled = 0 Order by CurrencyID"
        LoadDataSource(tdbcCurrencyID, sSQL, gbUnicode)

        'Load tdbcRemarkID
        sSQL = "Select RemarkID, RemarkName" & UnicodeJoin(gbUnicode) & " as RemarkName From D25T0030 WITH(NOLOCK)  Where Disabled = 0 Order by RemarkID"
        LoadDataSource(tdbcRemarkID, sSQL, gbUnicode)

        'Load FileType
        sSQL = "Select '00001' as FileType,'" & "Tieáng Vieät" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00002' as FileType,'" & "Tieáng Anh" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00003' as FileType,'" & "Tieáng Hoa" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00004' as FileType,'" & "Tieáng Phaùp" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00005' as FileType,'" & "Tieáng Nhaät" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00006' as FileType,'" & "Tieáng Haøn" & "' As FileTypeName Union" & vbCrLf
        sSQL &= "Select '00007' as FileType,'" & "Tieáng Ñöùc" & "' As FileTypeName " & vbCrLf
        sSQL &= "Order by FileType"
        dt = ReturnDataTable(sSQL)
        If gbUnicode Then ConvertVniToUnicode(dt)
        LoadDataSource(tdbcFileType, dt, gbUnicode)

        'Load tdbcRecDepartmentID
        dtDepartment = ReturnTableDepartmentID_D09P6868("%", "D25F1050", _isMSS)

        'Load tdbcEducationLevelID
        sSQL = " Select	EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName" & vbCrLf
        sSQL &= " 	From	D09T0206 WITH(NOLOCK) "
        sSQL &= " 	Where	Disabled = 0"
        sSQL &= " 	Order by	EducationLevelID"
        LoadDataSource(tdbcEducationLevelID, sSQL, gbUnicode)
        '*Them ngay 12/3/2013 theo ID 54205
        LoadtdbcProfessionalLevelID()
        '****************************
        'Load tdbcPoliticsID
        sSQL = " "
        sSQL &= " Select	PoliticsID,PoliticsName" & UnicodeJoin(gbUnicode) & " as PoliticsName "
        sSQL &= " 	From	D09T0225 WITH(NOLOCK) "
        sSQL &= " 	Where	Disabled = 0"
        sSQL &= " 	Order by	PoliticsID"
        LoadDataSource(tdbcPoliticsID, sSQL, gbUnicode)

        LoadtdbcRelationName()
        LoadTdbcShiftID()

        'Load tdbcMethodID   IncidentID	50891
        sSQL = "SELECT MethodID, MethodName" & UnicodeJoin(gbUnicode) & " AS MethodName, IsDefault " & vbCrLf
        sSQL &= "FROM D09T1600 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "AND TypeCode = 50" & vbCrLf
        sSQL &= "AND (DivisionID =" & SQLString(_divisionID) & " Or DivisionID = '') " & vbCrLf
        sSQL &= "ORDER BY MethodName"
        LoadDataSource(tdbcMethodID, sSQL, gbUnicode)
        Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString

        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        'Load tdbcSuggesterID
        sSQL = SQLStoreD25P1052()
        LoadDataSource(tdbcSuggesterID, sSQL, gbUnicode)

        'ID 54204*************************
        dtEmpGroupID = ReturnTableEmpGroupID_D09P6868("%", "D25F1050", _isMSS)

        sSQL = "-- Combo Noi cap ma so thue" & vbCrLf
        sSQL &= "SELECT LookupID AS PITIssuePlaceID, Description" & UnicodeJoin(gbUnicode) & " AS PITIssuePlaceName" & vbCrLf
        sSQL &= " FROM 	D91T0320  WITH(NOLOCK) " & vbCrLf
        sSQL &= " WHERE LookupType = 'D09_TaxcodePlace' And Disabled = 0 " & vbCrLf
        sSQL &= " AND ( DAGroupID = '' OR DAGroupID In (SELECT 	DAGroupID FROM 	LemonSys.DBO.D00V0080 WHERE UserID= " & SQLString(gsUserID) & ") " & vbCrLf
        sSQL &= " OR " & SQLString(gsUserID) & " ='LEMONADMIN') ORDER BY DisplayOrder,	PITIssuePlaceName" & vbCrLf
        LoadDataSource(tdbcPITIssuePlaceID, sSQL, gbUnicode)

        sSQL = "-- Combo Ho khau" & vbCrLf
        sSQL &= " SELECT ZoneCode AS PopulationID, ZoneName" & UnicodeJoin(gbUnicode) & " AS PopulationName " & vbCrLf
        sSQL &= " FROM D91T1620 WITH(NOLOCK)  WHERE ZoneLevelID = 'TINH/THANH' And Disabled = 0 " & vbCrLf
        sSQL &= " ORDER BY 	PopulationName"
        LoadDataSource(tdbcPopulationID, sSQL, gbUnicode)
        '***********************************
        'Load tdbcWorkName
        LoadtdbcWorkName()
        'Load tdbcEmRelationName
        LoadtdbcEmRelationName()
        'Load tdbcTrousersSizeName
        LoadtdbcSize(tdbcTrousersSizeName, "QUAN", "--Do nguon cho combo Quan")
        'Load tdbcShirtSizeName
        LoadtdbcSize(tdbcShirtSizeName, "AO", "--Do nguon cho combo Ao")
        'Load tdbcShoesSizeName
        LoadtdbcSize(tdbcShoesSizeName, "GIAY", "--Do nguon cho combo Giay")
        'Load tdbcClothesSizeName
        LoadtdbcSize(tdbcClothesSizeName, "DOSACH", "--Do nguon cho combo Do Sach")
        ' 'Load tdbcProjectID
        sSQL = "-- Do nguon combo ProjectID" & vbCrLf & _
        "	SELECT ProjectID, Description" & UnicodeJoin(gbUnicode) & " AS ProjectName" & vbCrLf & _
        "	FROM D09T1080 WITH(NOLOCK)  WHERE Disabled = 0 " & vbCrLf & _
        "	ORDER BY ProjectName	"
        LoadDataSource(tdbcProjectID, sSQL, gbUnicode)
        tdbcProjectID.SelectedValue = D25Options.ProjectID

        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedValue = gsDivisionID
        '****************************
        'ID 81526 11/01/2016
        dtPlace = ReturnDataTable(SQLStoreD09P1509)
        'Load tdbcBPPLabelID,tdbcCAPLabelID,tdbcRAPLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='ProvinceLabel'", True)
        LoadDataSource(tdbcBPPLabelID, dt, gbUnicode)
        LoadDataSource(tdbcCAPLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcRAPLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbcBPDLabelID,tdbcCADLabelID,tdbcRADLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='DistrictLabel'", True)
        LoadDataSource(tdbcBPDLabelID, dt, gbUnicode)
        LoadDataSource(tdbcCADLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcRADLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbcBPWLabelID,tdbcCAWLabelID,tdbcRAWLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='WardLabel'", True)
        LoadDataSource(tdbcBPWLabelID, dt, gbUnicode)
        LoadDataSource(tdbcCAWLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcRAWLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbcBirthPlaceProvinceID,tdbcPopulationID,tdbcRAWLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='TINH/THANH'", True)
        LoadDataSource(tdbcBirthPlaceProvinceID, dt, gbUnicode)
        LoadDataSource(tdbcConAddressProvinceID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcResAddressProvinceID, dt.DefaultView.ToTable, gbUnicode)

        LoadTDBComboDistrictID(tdbcBirthPlaceDistrictID, "-1")
        LoadTDBComboDistrictID(tdbcConAddressDistrictID, "-1")
        LoadTDBComboDistrictID(tdbcResAddressDistrictID, "-1")
        LoadTDBComboWardID(tdbcBirthPlaceWardID, "-1")
        LoadTDBComboWardID(tdbcConAddressWardID, "-1")
        LoadTDBComboWardID(tdbcResAddressWardID, "-1")
    End Sub

#Region "ID 81526 11/01/2016"
    Dim dtPlace, dtDistrictID, dtWardID As DataTable
    Private Sub LoadTDBComboDistrictID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sProvinceID As String)
        If dtDistrictID Is Nothing Then
            dtDistrictID = ReturnTableFilter(dtPlace, "SourceName ='QUAN/HUYEN'", True)
        End If
        LoadDataSource(tdbc, ReturnTableFilter(dtDistrictID, "ParentID = " & SQLString(sProvinceID), True), gbUnicode)
        tdbc.SelectedValue = ""
    End Sub

    Private Sub LoadTDBComboWardID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sWardID As String)
        If dtWardID Is Nothing Then
            dtWardID = ReturnTableFilter(dtPlace, "SourceName ='XA/PHUONG'", True)
        End If
        LoadDataSource(tdbc, ReturnTableFilter(dtWardID, "ParentID = " & SQLString(sWardID), True), gbUnicode)
        tdbc.SelectedValue = ""
    End Sub

#Region "Events tdbcBPPLabelID"

    Private Sub tdbcBPPLabelID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBPPLabelID.LostFocus, tdbcCAPLabelID.LostFocus, tdbcRAPLabelID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub
#End Region

#Region "Events tdbcBPDLabelID"

    Private Sub tdbcBPDLabelID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBPDLabelID.LostFocus, tdbcCADLabelID.LostFocus, tdbcRADLabelID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub
#End Region

#Region "Events tdbcBPWLabelID"

    Private Sub tdbcBPWLabelID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBPWLabelID.LostFocus, tdbcCAWLabelID.LostFocus, tdbcRAWLabelID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub
#End Region

#Region "Events tdbcBirthPlaceWardID"

    Private Sub tdbcBirthPlaceWardID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBirthPlaceWardID.LostFocus, tdbcConAddressWardID.LostFocus, tdbcResAddressWardID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub
#End Region

#Region "Events tdbcBirthPlaceProvinceID"
    Private Sub tdbcBirthPlaceProvinceID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBirthPlaceProvinceID.LostFocus, tdbcPopulationID.LostFocus, tdbcResAddressProvinceID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub

    Private Sub tdbcBirthPlaceProvinceID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBirthPlaceProvinceID.SelectedValueChanged, tdbcConAddressProvinceID.SelectedValueChanged, tdbcResAddressProvinceID.SelectedValueChanged
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case tdbc.Name
            Case tdbcBirthPlaceProvinceID.Name
                LoadTDBComboDistrictID(tdbcBirthPlaceDistrictID, ReturnValueC1Combo(tdbc))
            Case tdbcConAddressProvinceID.Name
                LoadTDBComboDistrictID(tdbcConAddressDistrictID, ReturnValueC1Combo(tdbc))
            Case tdbcResAddressProvinceID.Name
                LoadTDBComboDistrictID(tdbcResAddressDistrictID, ReturnValueC1Combo(tdbc))
        End Select
    End Sub
#End Region

#Region "Events tdbcBirthPlaceDistrictID"

    Private Sub tdbcBirthPlaceDistrictID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBirthPlaceDistrictID.LostFocus, tdbcConAddressDistrictID.LostFocus, tdbcResAddressDistrictID.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub

    Private Sub tdbcBirthPlaceDistrictID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBirthPlaceDistrictID.SelectedValueChanged, tdbcConAddressDistrictID.SelectedValueChanged, tdbcResAddressDistrictID.SelectedValueChanged
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case tdbc.Name
            Case tdbcBirthPlaceDistrictID.Name
                LoadTDBComboWardID(tdbcBirthPlaceWardID, ReturnValueC1Combo(tdbc))
            Case tdbcConAddressDistrictID.Name
                LoadTDBComboWardID(tdbcConAddressWardID, ReturnValueC1Combo(tdbc))
            Case tdbcResAddressDistrictID.Name
                LoadTDBComboWardID(tdbcResAddressWardID, ReturnValueC1Combo(tdbc))
        End Select
    End Sub

#End Region

    Private Sub tdbcBPPLabelID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBPPLabelID.Close, tdbcBirthPlaceProvinceID.Close, tdbcBPDLabelID.Close, tdbcBirthPlaceDistrictID.Close, tdbcBPWLabelID.Close, _
     tdbcBirthPlaceWardID.Close, tdbcCAPLabelID.Close, tdbcConAddressProvinceID.Close, tdbcCADLabelID.Close, tdbcConAddressDistrictID.Close, _
     tdbcCAWLabelID.Close, tdbcConAddressWardID.Close, tdbcRAPLabelID.Close, tdbcResAddressProvinceID.Close, tdbcRADLabelID.Close, _
     tdbcResAddressDistrictID.Close, tdbcRAWLabelID.Close, tdbcResAddressWardID.Close
        tdbcBPPLabelID_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcBPPLabelID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBPPLabelID.Validated, tdbcBirthPlaceProvinceID.Validated, tdbcBPDLabelID.Validated, tdbcBirthPlaceDistrictID.Validated, tdbcBPWLabelID.Validated, _
        tdbcBirthPlaceWardID.Validated, tdbcCAPLabelID.Validated, tdbcConAddressProvinceID.Validated, tdbcCADLabelID.Validated, tdbcConAddressDistrictID.Validated, _
        tdbcCAWLabelID.Validated, tdbcConAddressWardID.Validated, tdbcRAPLabelID.Validated, tdbcResAddressProvinceID.Validated, tdbcRADLabelID.Validated, _
        tdbcResAddressDistrictID.Validated, tdbcRAWLabelID.Validated, tdbcResAddressWardID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Dim sAuto As String = rL3("Sinh_chuoi_tu_dong") 'ID 71984 16/04/2015
    Private Sub btnAuto1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAuto1.MouseMove, btnAuto2.MouseMove, btnAuto3.MouseMove
        Dim btn As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)
        tipAuto.SetToolTip(btn, sAuto)
    End Sub


    Private Sub btnAuto1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto1.Click
        Dim sBirthPlace As String = ""
        If tdbcBirthPlaceWardID.Text <> "" Then
            If tdbcBPWLabelID.Text <> "" Then
                sBirthPlace &= tdbcBPWLabelID.Text & Space(1) & tdbcBirthPlaceWardID.Text & ", "
            Else
                sBirthPlace &= tdbcBirthPlaceWardID.Text
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        If tdbcBirthPlaceDistrictID.Text <> "" Then
            If tdbcBPDLabelID.Text <> "" Then
                sBirthPlace &= tdbcBPDLabelID.Text & Space(1) & tdbcBirthPlaceDistrictID.Text & ", "
            Else
                sBirthPlace &= tdbcBirthPlaceDistrictID.Text
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        If tdbcBirthPlaceProvinceID.Text <> "" Then
            If tdbcBPPLabelID.Text <> "" Then
                sBirthPlace &= tdbcBPPLabelID.Text & Space(1) & tdbcBirthPlaceProvinceID.Text & ", "
            Else
                sBirthPlace &= tdbcBirthPlaceProvinceID.Text
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        sBirthPlace = L3Left(sBirthPlace, sBirthPlace.Length - 2)
        txtBirthPlace.Text = sBirthPlace
    End Sub

    Private Sub btnAuto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto2.Click
        Dim sEmployeeStreet As String = ""
        sEmployeeStreet &= IIf(txtConAddressStreet.Text = "", "", txtConAddressStreet.Text & ", ").ToString

        If tdbcConAddressWardID.Text <> "" Then
            If tdbcCAWLabelID.Text <> "" Then
                sEmployeeStreet &= tdbcCAWLabelID.Text & Space(1) & tdbcConAddressWardID.Text & ", "
            Else
                sEmployeeStreet &= tdbcConAddressWardID.Text
                If sEmployeeStreet <> "" Then sEmployeeStreet &= ", "
            End If
        End If

        If tdbcConAddressDistrictID.Text <> "" Then
            If tdbcCADLabelID.Text <> "" Then
                sEmployeeStreet &= tdbcCADLabelID.Text & Space(1) & tdbcConAddressDistrictID.Text & ", "
            Else
                sEmployeeStreet &= tdbcConAddressDistrictID.Text
                If sEmployeeStreet <> "" Then sEmployeeStreet &= ", "
            End If
        End If

        If tdbcConAddressProvinceID.Text <> "" Then
            If tdbcCAPLabelID.Text <> "" Then
                sEmployeeStreet &= tdbcCAPLabelID.Text & Space(1) & tdbcConAddressProvinceID.Text & ", "
            Else
                sEmployeeStreet &= tdbcConAddressProvinceID.Text
                If sEmployeeStreet <> "" Then sEmployeeStreet &= ", "
            End If
        End If

        sEmployeeStreet = L3Left(sEmployeeStreet, sEmployeeStreet.Length - 2)
        txtPermanentAddress.Text = sEmployeeStreet
    End Sub

    Private Sub btnAuto3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto3.Click
        Dim sProvisionalAddress As String = ""
        sProvisionalAddress &= IIf(txtResAddressStreet.Text = "", "", txtResAddressStreet.Text & ", ").ToString

        If tdbcResAddressWardID.Text <> "" Then
            If tdbcRAWLabelID.Text <> "" Then
                sProvisionalAddress &= tdbcRAWLabelID.Text & Space(1) & tdbcResAddressWardID.Text & ", "
            Else
                sProvisionalAddress &= tdbcResAddressWardID.Text
                If sProvisionalAddress <> "" Then sProvisionalAddress &= ", "
            End If
        End If

        If tdbcResAddressDistrictID.Text <> "" Then
            If tdbcRADLabelID.Text <> "" Then
                sProvisionalAddress &= tdbcRADLabelID.Text & Space(1) & tdbcResAddressDistrictID.Text & ", "
            Else
                sProvisionalAddress &= tdbcResAddressDistrictID.Text
                If sProvisionalAddress <> "" Then sProvisionalAddress &= ", "
            End If
        End If

        If tdbcResAddressProvinceID.Text <> "" Then
            If tdbcRAPLabelID.Text <> "" Then
                sProvisionalAddress &= tdbcRAPLabelID.Text & Space(1) & tdbcResAddressProvinceID.Text & ", "
            Else
                sProvisionalAddress &= tdbcResAddressProvinceID.Text
                If sProvisionalAddress <> "" Then sProvisionalAddress &= ", "
            End If
        End If

        sProvisionalAddress = L3Left(sProvisionalAddress, sProvisionalAddress.Length - 2)
        txtProvisionalAddress.Text = sProvisionalAddress
    End Sub

#End Region

    Private Sub LoadtdbcWorkName()
        Dim sSQL As String = " -- Combo Cong viec ung tuyen" & vbCrLf
        sSQL &= " SELECT  	" & NewCode & " As WorkID, " & NewName & " As WorkName, 0 AS DisplayOrder" & vbCrLf
        sSQL &= " UNION ALL" & vbCrLf
        sSQL &= "SELECT 	WorkID, WorkName" & UnicodeJoin(gbUnicode) & "  As  WorkName, 1 AS DisplayOrder  " & vbCrLf
        sSQL &= "FROM 		D09T0224  WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE 		Disabled = 0  AND (DivisionID =" & SQLString(_divisionID) & " OR DivisionID = ' ')" & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder, WorkName"
        LoadDataSource(tdbcWorkName, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcEmRelationName()
        Dim sSQL As String = "-- Combo Moi quan he 1, 2" & vbCrLf
        sSQL &= " SELECT  	" & NewCode & " As EmRelationID, " & NewName & " As EmRelationName, 0 AS DisplayOrder" & vbCrLf
        sSQL &= " UNION ALL" & vbCrLf
        sSQL &= "SELECT 	RelationID AS EmRelationID, RelationName" & UnicodeJoin(gbUnicode) & "  As  EmRelationName, 1 AS DisplayOrder  " & vbCrLf
        sSQL &= "FROM 		D09T0240 WITH(NOLOCK)   " & vbCrLf
        sSQL &= "WHERE 		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder, EmRelationName"
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcEmRelationName1, dtTemp, gbUnicode)
        LoadDataSource(tdbcEmRelationName2, dtTemp.DefaultView.ToTable, gbUnicode)
    End Sub

    Private Sub LoadtdbcSize(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal SizeGroupID As String, ByVal sNote As String)
        Dim sSQL As String = ""
        sSQL = sNote & vbCrLf
        sSQL &= "SELECT 	SizeID, SizeName" & UnicodeJoin(gbUnicode) & " As SizeName" & vbCrLf
        sSQL &= "FROM 		D51T1610 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE		SizeGroupID = '" & SizeGroupID & "' AND Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY	SizeDisplayOrder, SizeName"
        LoadDataSource(tdbc, sSQL, gbUnicode)
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1052
    '# Created User: Phan Văn Thông
    '# Created Date: 08/10/2012 02:18:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1052() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon combo Nguoi gioi thieu" & vbCrLf)
        sSQL &= "Exec D25P1052 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub LoadtdbcProfessionalLevelID()
        Dim sSQL As String = ""
        sSQL = " --Do nguon cho combo TD chuyen mon" & vbCrLf
        sSQL &= " SELECT '+' As ProfessionalLevelID, " & NewName & "  As  ProfessionalLevelName, 0 As DisplayOrder  " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT	ProfessionalLevelID, ProfessionalLevelName" & UnicodeJoin(gbUnicode) & " as ProfessionalLevelName, 1 As DisplayOrder" & vbCrLf
        sSQL &= " FROM		D09T0205  WITH(NOLOCK) 	WHERE		Disabled = 0 ORDER BY	DisplayOrder, ProfessionalLevelID"
        LoadDataSource(tdbcProfessionalLevelID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbcShiftID()
        Dim sSQL As String = ""
        Dim sLanguage As String = rL3("Them_moiV")
        If gbUnicode And geLanguage = EnumLanguage.Vietnamese Then sLanguage = "Thêm mới"
        sSQL = "Select '+' As ShiftID, N'<" & sLanguage & ">' As ShiftName" & vbCrLf
        sSQL &= "Union " & vbCrLf
        sSQL &= "Select D10.ShiftID, D10.ShiftName" & UnicodeJoin(gbUnicode) & " as ShiftName" & vbCrLf
        sSQL &= "From D29T1010 D10 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D10.Disabled = 0" & vbCrLf
        sSQL &= "Order by ShiftID"
        LoadDataSource(tdbcShiftID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcRelationName()
        Dim sSQL As String = ""
        Dim sLanguage As String = rL3("Them_moiV")
        If gbUnicode And geLanguage = EnumLanguage.Vietnamese Then sLanguage = "Thêm mới"

        sSQL = "Select RelationID, RelationName" & UnicodeJoin(gbUnicode) & " as RelationName From D09T0240 WITH(NOLOCK)  Where Disabled = 0" & vbCrLf
        sSQL &= "Union Select '+' as RelationID, N'<" & sLanguage & ">' as RelationName"
        LoadDataSource(tdbcRelationName, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbcFileReceiverID(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL &= " Select	EmployeeID  As FileReceiver," & vbCrLf
        sSQL &= " 	isnull(LastName" & UnicodeJoin(gbUnicode) & ", '') + ' ' + isnull(MiddleName" & UnicodeJoin(gbUnicode) & ", '') + ' ' + isnull(FirstName" & UnicodeJoin(gbUnicode) & ", '') As "
        sSQL &= " 	FileReceiverName" & vbCrLf
        sSQL &= " 	From	D09T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where	Disabled = 0"
        sSQL &= " 	And DivisionID = " & SQLString(_divisionID) & " And DepartmentID = " & SQLString(ID) & vbCrLf
        sSQL &= " 	Order by	DivisionID, DepartmentID, TeamID, EmployeeID"

        LoadDataSource(tdbcFileReceiver, sSQL, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        txtCandidateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtLastName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtFirstName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY' ID 87778 03/06/2016
    End Sub

#Region "Combo Events"

#Region "Events tdbcZoneCode"

    Private Sub tdbcZoneCode_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcZoneCode.LostFocus
        If tdbcZoneCode.FindStringExact(tdbcZoneCode.Text) = -1 Then tdbcZoneCode.Text = ""
    End Sub

#End Region

#Region "Events tdbcEthnicID"

    Private Sub tdbcEthnicID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEthnicID.Close
        If tdbcEthnicID.FindStringExact(tdbcEthnicID.Text) = -1 Then tdbcEthnicID.Text = ""
    End Sub

    Private Sub tdbcEthnicID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEthnicID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcEthnicID.Text = ""
    End Sub

#End Region

#Region "Events tdbcReligionName"

    Private Sub tdbcReligionName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReligionID.LostFocus
        If tdbcReligionID.FindStringExact(tdbcReligionID.Text) = -1 Then tdbcReligionID.Text = ""
    End Sub
#End Region

#Region "Events tdbcCountryName"

    Private Sub tdbcCountryName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNationalityID.LostFocus
        If tdbcNationalityID.FindStringExact(tdbcNationalityID.Text) = -1 Then tdbcNationalityID.Text = ""
    End Sub
#End Region

#Region "Events tdbcMilitaryRank"

    Private Sub tdbcMilitaryRank_Close(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tdbcMilitaryRank.FindStringExact(tdbcMilitaryRank.Text) = -1 Then tdbcMilitaryRank.Text = ""
    End Sub

    Private Sub tdbcMilitaryRank_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcMilitaryRank.Text = ""
    End Sub

#End Region

#Region "Events tdbcFileReceiver with txtFileReceiverName"

    Private Sub tdbcFileReceiver_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFileReceiver.Close
        If tdbcFileReceiver.FindStringExact(tdbcFileReceiver.Text) = -1 Then
            tdbcFileReceiver.Text = ""
            'txtFileReceiverName.Text = ""
        End If
    End Sub

    Private Sub tdbcFileReceiver_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFileReceiver.SelectedValueChanged
        If tdbcFileReceiver.SelectedValue Is Nothing Then
            'txtFileReceiverName.Text = ""
            Exit Sub
        End If
        'txtFileReceiverName.Text = tdbcFileReceiver.Columns(1).Value.ToString

    End Sub


    Private Sub tdbcFileReceiver_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcFileReceiver.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim sObjectTypeID As String = ""
            'ID 79397 04/09/2015
            Try
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "InListID", "39")
                SetProperties(arrPro, "InWhere", "DepartmentID = " & SQLString(tdbcDepartmentID.SelectedValue.ToString))
                Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                Dim sKey As String = GetProperties(frm, "Output01").ToString
                sObjectTypeID = GetProperties(frm, "Output02").ToString
                If sKey <> "" Then
                    'Load dữ liệu
                    tdbcFileReceiver.SelectedValue = sKey
                End If
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try
        End If

    End Sub

#End Region

#Region "Events tdbcRecSourceID with txtRecSourceName"

    Private Sub tdbcRecSourceID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecSourceID.Close
        If tdbcRecSourceID.FindStringExact(tdbcRecSourceID.Text) = -1 Then
            tdbcRecSourceID.Text = ""
            'txtRecSourceName.Text = ""
        End If
    End Sub

    Private Sub tdbcRecSourceID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecSourceID.SelectedValueChanged
        'txtRecSourceName.Text = tdbcRecSourceID.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcRecSourceID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecSourceID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcRecSourceID.Text = ""
    '        'txtRecSourceName.Text = ""
    '    End If
    'End Sub

#End Region

#Region "Events tdbcRecDepartmentID with txtRecDepartmentName load tdbcRecTeamID with txtRecTeamName"

    Private Sub tdbcRecDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentID.SelectedValueChanged
        If Not (tdbcRecDepartmentID.Tag Is Nothing OrElse tdbcRecDepartmentID.Tag.ToString = "") Then
            tdbcRecDepartmentID.Tag = ""
            Exit Sub
        End If
        'If tdbcRecDepartmentID.SelectedValue Is Nothing Then
        '    'LoadtdbcRecTeamID("-1")
        '    Exit Sub
        'End If
        'txtRecDepartmentName.Text = tdbcRecDepartmentID.Columns(1).Text
        'LoadtdbcRecTeamID(tdbcRecDepartmentID.SelectedValue.ToString())
        'tdbcRecTeamID.Text = ""
        'txtRecTeamName.Text = ""
        Dim dtTemp As DataTable = ReturnTableFilter(dtTeamID, "DivisionID= '%' or DepartmentID=" & SQLString(ReturnValueC1Combo(tdbcRecDepartmentID)), True)
        LoadDataSource(tdbcRecTeamID, dtTemp, gbUnicode)
        '  tdbcRecTeamID.SelectedIndex = 0
        tdbcRecTeamID.SelectedValue = ""
    End Sub

    Private Sub tdbcRecDepartmentID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcRecDepartmentID.Text = ""
        '    'txtRecDepartmentName.Text = ""
        'End If
    End Sub

    Private Sub tdbcRecTeamID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamID.Close
        If tdbcRecTeamID.FindStringExact(tdbcRecTeamID.Text) = -1 Then
            tdbcRecTeamID.Text = ""
            'txtRecTeamName.Text = ""
        End If
    End Sub

    Private Sub tdbcRecTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamID.SelectedValueChanged
        'txtRecTeamName.Text = tdbcRecTeamID.Columns(1).Value.ToString()
        'LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, ReturnValueC1Combo(tdbcRecTeamID).ToString, gbUnicode)
        'LoadDataSource(tdbcEmpGroupID, ReturnTableFilter(dtEmpGroupID, " TeamID = " & SQLString(ReturnValueC1Combo(tdbcRecTeamID).ToString)), gbUnicode)
        LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, "%", ReturnValueC1Combo(tdbcRecDepartmentID), ReturnValueC1Combo(tdbcRecTeamID), ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
    End Sub

    Private Sub tdbcRecTeamID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcRecTeamID.Text = ""
        '    'txtRecTeamName.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcRecPositionID with txtRecPositionName"

    Private Sub tdbcRecPositionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.Close
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then
            tdbcRecPositionID.Text = ""
            'txtRecPositionName.Text = ""
        End If
    End Sub

    Private Sub tdbcRecPositionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.SelectedValueChanged
        'txtRecPositionName.Text = tdbcRecPositionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcRecPositionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecPositionID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcRecPositionID.Text = ""
        '    'txtRecPositionName.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcCurrencyID"

    Private Sub tdbcCurrencyID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.Close
        If tdbcCurrencyID.FindStringExact(tdbcCurrencyID.Text) = -1 Then tdbcCurrencyID.Text = ""
    End Sub

    Private Sub tdbcCurrencyID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCurrencyID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcCurrencyID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRemarkID with txtRemarkName"

    Private Sub tdbcRemarkID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRemarkID.Close
        If tdbcRemarkID.FindStringExact(tdbcRemarkID.Text) = -1 Then
            tdbcRemarkID.Text = ""
            'txtRemarkName.Text = ""
        End If
    End Sub

    Private Sub tdbcRemarkID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRemarkID.SelectedValueChanged
        'txtRemarkName.Text = tdbcRemarkID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcRemarkID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRemarkID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcRemarkID.Text = ""
        '    'txtRemarkName.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcFileType with txtFileTypeName"

    Private Sub tdbcFileType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFileType.SelectedValueChanged
        'txtFileTypeName.Text = tdbcFileType.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcFileType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcFileType.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcFileType.Text = ""
        '    'txtFileTypeName.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcMethodID"
    Private Sub tdbcMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.LostFocus
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub
#End Region

    'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
#Region "Events tdbcSuggesterID with txtSuggester"
    Private Sub tdbcSuggesterID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSuggesterID.SelectedValueChanged

        txtSuggester.Enabled = True
        txtSuggesterDivision.Enabled = True
        txtSuggesterDepartment.Enabled = True
        txtSuggesterDuty.Enabled = True

        If tdbcSuggesterID.SelectedValue Is Nothing Then
            txtSuggester.Text = ""
            txtSuggesterDivision.Text = ""
            txtSuggesterDepartment.Text = ""
            txtSuggesterDuty.Text = ""
        Else
            txtSuggester.Text = tdbcSuggesterID.Columns("Suggester").Value.ToString
            txtSuggesterDivision.Text = tdbcSuggesterID.Columns("SuggesterDivision").Value.ToString
            txtSuggesterDepartment.Text = tdbcSuggesterID.Columns("SuggesterDepartment").Value.ToString
            txtSuggesterDuty.Text = tdbcSuggesterID.Columns("SuggesterDuty").Value.ToString

            txtSuggester.Enabled = False
            txtSuggesterDivision.Enabled = False
            txtSuggesterDepartment.Enabled = False
            txtSuggesterDuty.Enabled = False
        End If
    End Sub

    Private Sub tdbcSuggesterID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSuggesterID.LostFocus
        If tdbcSuggesterID.FindStringExact(tdbcSuggesterID.Text) = -1 Then
            tdbcSuggesterID.Text = ""
        End If
    End Sub

#End Region
    'ID 54204
#Region "Events tdbcPITIssuePlaceID"

    Private Sub tdbcPITIssuePlaceID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITIssuePlaceID.LostFocus
        If tdbcPITIssuePlaceID.FindStringExact(tdbcPITIssuePlaceID.Text) = -1 Then tdbcPITIssuePlaceID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPopulationID"

    Private Sub tdbcPopulationID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPopulationID.LostFocus
        If tdbcPopulationID.FindStringExact(tdbcPopulationID.Text) = -1 Then tdbcPopulationID.Text = ""
    End Sub

#End Region

#Region "Events tdbcEmpGroupID"

    Private Sub tdbcEmpGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.LostFocus
        If tdbcEmpGroupID.FindStringExact(tdbcEmpGroupID.Text) = -1 Then tdbcEmpGroupID.Text = ""
    End Sub

#End Region

    '****************************

    Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcZoneCode.KeyDown
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbc.AutoCompletion = False

            Case Else
                tdbc.AutoCompletion = True
        End Select
    End Sub

#End Region

    Private Function AllowSave() As Boolean
        'IncidentID	50891
        '-------Sinh mã tự động cho ứng cử viên - chỉ thực hiện khi thêm mới và có check sinh mã tự động ở thiết lập hệ thống
        If _FormState = EnumFormState.FormAdd AndAlso D25Systems.AutoCandidateID Then 'If tdbcMethodID.Visible And _FormState = EnumFormState.FormAdd Then
            If tdbcMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Phuong_phap_tao_ma_tu_dong"))
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                tdbcMethodID.Focus()
                Return False
            End If

            Dim sSQL As String = ""
            sSQL = SQLDeleteD09T6666.ToString & vbCrLf
            sSQL &= SQLInsertD09T6666.ToString & vbCrLf
            sSQL &= SQLStoreD09P2016.ToString & vbCrLf
            Dim sGetCandidateID As String = ""
            If Not CheckMyStore(sSQL, sGetCandidateID) Then
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                tdbcMethodID.Focus()
                Return False
            Else
                txtCandidateID.Text = sGetCandidateID
            End If

        End If
        '--------Giá trị sinh ra được gắn vào text mã ứng cử viên, thực hiện các bước tiếp theo như bình thường
        If txtCandidateID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma"))
            tabMain.SelectedTab = TabPage1
            tabPrivate.SelectedTab = TabPage2
            txtCandidateID.Focus()
            Return False
        End If
        If txtIDCardNo.Text <> "" Then
            If txtIDCardNo.Text.Length <> 9 And txtIDCardNo.Text.Length <> 12 Then
                D99C0008.MsgL3(rL3("So_CMND_chua_hop_le"))
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                txtIDCardNo.Focus()
                Return False
            End If
        End If

        If txtLastName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ho_va_ten"))
            tabMain.SelectedTab = TabPage1
            tabPrivate.SelectedTab = TabPage2
            txtLastName.Focus()
            Return False
        End If
        If txtFirstName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ho_va_ten"))
            tabMain.SelectedTab = TabPage1
            tabPrivate.SelectedTab = TabPage2
            txtFirstName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1041", "CandidateID", txtCandidateID.Text) Then
                D99C0008.MsgDuplicatePKey()
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                txtCandidateID.Focus()
                Return False
            End If
        End If

        'Kiem tra ngay sinh
        If txtNumday.Text <> "" Then
            If txtNumMonth.Text = "" Then
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                D99C0008.MsgL3(rL3("MSG000009"))
                txtNumMonth.Focus()
                Return False
            Else
                If txtNumYear.Text = "" Then
                    tabMain.SelectedTab = TabPage1
                    tabPrivate.SelectedTab = TabPage2
                    D99C0008.MsgL3(rL3("MSG000009"))
                    txtNumYear.Focus()
                    Return False
                End If
            End If
        End If
        If txtNumMonth.Text <> "" Then
            If txtNumYear.Text = "" Then
                tabMain.SelectedTab = TabPage1
                tabPrivate.SelectedTab = TabPage2
                D99C0008.MsgL3(rL3("MSG000009"))
                txtNumYear.Focus()
                Return False
            End If
        End If
        '*************
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblDivisionID.Text)
            tabMain.SelectedTab = tabPage20
            tdbcDivisionID.Focus()
            Return False
        End If
        ' ID 87778 03/06/2016
        'If tdbcDepartmentID.Text.Trim = "" Then
        '    D99C0008.MsgNotYetEnter(lblDepartmentID.Text)
        '    tabMain.SelectedTab = tabPage20
        '    tdbcDepartmentID.Focus()
        '    Return False
        'End If
        If Not clsCheckValid.CheckEmpty() Then Return False
        Return True
    End Function

    ''' <summary>
    ''' Kiểm tra dữ liệu bằng Store
    ''' </summary>
    ''' <param name="SQL">Store cần kiểm tra</param>
    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 2 cột là Status và Message</remarks>
    Private Function CheckMyStore(ByVal SQL As String, ByRef Status As String, Optional ByVal bMsgAsk As Boolean = False) As Boolean
        'Update 11/10/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu đối số thứ 2 không truyền vào có nghĩa là False thì xuất Message chỉ có 1 nút Ok
        'Nếu đối số thứ 2 có truyền vào có nghĩa là True thì xuất Message có 2 nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                Status = dt.Rows(0).Item("CandidateID").ToString
                dt = Nothing
                Return True
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:06:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL = "DELETE From D09T6666" & vbCrLf
        sSQL &= "WHERE UserID =" & SQLString(gsUserID) & vbCrLf
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND FormID = " & SQLString("D25F1051")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:11:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Str01, Str02, Str03, Str04, Str05, Num01 , FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        'IncidentID	50891  Bổ sung theo yêu cầu của BAOTRAN
        If gbUnicode Then
            sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'Str01, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA) 'Str02, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'Str03, nvarchar[500], NOT NULL
        Else
            sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'Str01, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA) 'Str02, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'Str03, nvarchar[500], NOT NULL
        End If
        'sSQL.Append(SQLStringUnicode(IIf(tdbcRecDepartmentID.SelectedValue Is Nothing, "", tdbcRecDepartmentID.SelectedValue.ToString).ToString, gbUnicode, True) & COMMA) 'Str04, nvarchar[500], NOT NULL
        'sSQL.Append(SQLStringUnicode(IIf(tdbcRecPositionID.SelectedValue Is Nothing, "", tdbcRecPositionID.SelectedValue.ToString).ToString, gbUnicode, True) & COMMA) 'Str05, nvarchar[500], NOT NULL
        If tdbcRecDepartmentID.SelectedValue Is Nothing Then
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'Str04, nvarchar[500], NOT NULL
        Else
            sSQL.Append(SQLStringUnicode(tdbcRecDepartmentID.SelectedValue.ToString, gbUnicode, True) & COMMA) 'Str04, nvarchar[500], NOT NULL
        End If

        If tdbcRecPositionID.SelectedValue Is Nothing Then
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'Str05, nvarchar[500], NOT NULL
        Else
            sSQL.Append(SQLStringUnicode(tdbcRecPositionID.SelectedValue.ToString, gbUnicode, True) & COMMA) 'Str05, nvarchar[500], NOT NULL
        End If
        sSQL.Append(SQLMoney("1") & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLString("D25F1051")) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:28:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016() As String
        Dim sSQL As String = ""
        sSQL &= ("--Sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcMethodID.SelectedValue.ToString) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber("3") & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_moduleID) 'ModuleID, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
'# Title: SQLInsertD25T1035
'# Created User: 
'# Created Date: 25/08/2017 05:12:21
'#---------------------------------------------------------------------------------------------------
Private Function SQLInsertD25T1035() As StringBuilder
	Dim sSQL As New StringBuilder
	sSQL.Append("-- Insert D25T1035" & vbCrlf )
	sSQL.Append("Insert Into D25T1035(")
	sSQL.Append("RecPositionID, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, "  & vbCrlf)
	sSQL.Append("CandidateID, ExperienceYear")
	sSQL.Append(") Values(" & vbCrlf)
		sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA) 'RecPositionID, nvarchar[2000], NOT NULL
		sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
		sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
		sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
		sSQL.Append("GetDate()" & COMMA & vbCrlf) 'LastModifyDate, datetime, NOT NULL
		sSQL.Append(SQLString(txtCandidateID.Text) & COMMA) 'CandidateID, varchar[20], NOT NULL
		sSQL.Append(SQLMoney(cneExperienceYear.Value)) 'ExperienceYear, decimal, NULL
	sSQL.Append(")")

	Return sSQL
End Function

    '#---------------------------------------------------------------------------------------------------
'# Title: SQLUpdateD25T1035
'# Created User: 
'# Created Date: 25/08/2017 05:15:43
'#---------------------------------------------------------------------------------------------------
Private Function SQLUpdateD25T1035() As StringBuilder
	Dim sSQL As New StringBuilder 
	sSQL.Append("-- Update D25T1035" & vbCrlf )
	sSQL.Append("Update D25T1035 Set ")
		sSQL.Append("RecPositionID = " & SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA) 'nvarchar[2000], NOT NULL
		sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
		sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
		sSQL.Append("ExperienceYear = " & SQLMoney(cneExperienceYear.Value)) 'decimal, NULL
		sSQL.Append(" Where CandidateID = " & SQLString(txtCandidateID.Text))
	Return sSQL
End Function




    Private Function SQLInsertD25T1041(ByVal UndefinedBD As Integer) As StringBuilder
        Dim sSQL As New StringBuilder

        sSQL.Append("Insert Into D25T1041(")
        sSQL.Append(" DivisionID, CandidateID,Disabled, LastName,LastNameU, MiddleName,MiddleNameU,  " & vbCrLf)
        sSQL.Append(" FirstName,FirstNameU, CandidateName,CandidateNameU, Sex, UndefinedBD, BirthDate, BirthPlace,BirthPlaceU, " & vbCrLf)
        sSQL.Append(" EthnicID, ReligionID, NationalityID, IDCardNo, IDCardDate, " & vbCrLf)
        sSQL.Append(" IDCardPlaceID, MaritalStatus, ChildrenQuan, PermanentAddress,PermanentAddressU, ContactAddress,ContactAddressU, " & vbCrLf)
        sSQL.Append(" Telephone, Mobile, Email, Fax, MilitaryStartedDate,  " & vbCrLf)
        sSQL.Append(" MilitaryEndedDate,MilitaryRank,Height, Weight, HealthStatus,HealthStatusU, " & vbCrLf)
        'Thông tin tuyen dung
        sSQL.Append(" ReceivedDate, ReceivedPlace,ReceivedPlaceU, FileReceiver,FileReceiverU, RecSourceID, Suggester,SuggesterU," & vbCrLf)
        sSQL.Append(" SuggesterDivision,SuggesterDivisionU, SuggesterDepartment,SuggesterDepartmentU, SuggesterDuty,SuggesterDutyU, SuggesterRelationID," & vbCrLf)
        sSQL.Append(" DepartmentID, RecDepartmentID, RecTeamID, RecPositionID, DesiredSalary," & vbCrLf)
        sSQL.Append(" CurrencyID, LongBusinesstrip, Reason,ReasonU, StartingDate," & vbCrLf)
        ' kỷ năng
        sSQL.Append(" EquipmentSkill,EquipmentSkillU, Aptitude,AptitudeU,   Hobby,HobbyU,  OtherDesire,OtherDesireU, " & vbCrLf)
        sSQL.Append(" FileType, RemarkID, RemarkBeforeInterview,RemarkBeforeInterviewU, EducationLevelID, ProfessionalLevelID," & vbCrLf)
        sSQL.Append(" PoliticsID, TransferedD09, CreateUserID, CreateDate, LastModifyUserID,  " & vbCrLf)
        sSQL.Append(" DrivingLicenseID, ShiftID, lastModifyDate,SuggesterID, " & vbCrLf)
        'Them ngay 28/2/2013 theo ID 54204 của Phương Thảo bởi Văn Vinh
        sSQL.Append(" IncomeTaxCode, PITIssuePlaceID, PITIssueDate, EmpGroupID, NativePlace, NativePlaceU, PopulationID  ")
        sSQL.Append(", ProvisionalAddress, ProvisionalAddressU,EmContactName1, EmContactName1U, EmContactName2, EmContactName2U, EmRelationID1,")
        sSQL.Append(" EmRelationID2, EmContactPhone1, EmContactPhone2, EmContactAddress1, EmContactAddress1U, EmContactAddress2, EmContactAddress2U, TrousersSize, ShirtSize, ShoesSize, ClothesSize, ")

        sSQL.Append("BirthPlaceProvinceID, BirthPlaceDistrictID, BirthPlaceWardID, BPPLabelID, BPDLabelID, BPWLabelID, ")
        sSQL.Append("ConAddressProvinceID, ConAddressWardID, ConAddressDistrictID, CAWLabelID, CADLabelID, CAPLabelID, ConAddressStreetU, ")
        sSQL.Append("ResAddressWardID, ResAddressDistrictID, ResAddressProvinceID, RAWLabelID, RADLabelID, RAPLabelID, ResAddressStreetU, ")

        sSQL.Append("WorkID, ProjectID, JobDescription, JobDescriptionU, PastRecruits, PastRecruitsU")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(txtCandidateID.Text) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLNumber(IIf(chkDisabled.Checked, 1, 0).ToString) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'LastName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'LastName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA & vbCrLf) 'MiddleName, varchar[60], NOT NULL
        sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA & vbCrLf) 'MiddleName, varchar[60], NOT NULL
        sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'FirstName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'FirstName, varchar[30], NOT NULL
        '******************************
        If txtMiddleName.Text <> "" Then 'ID 84207 26/01/2016
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' +	isnull(" & SQLStringUnicode(txtMiddleName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'CandidateNameU, varchar[50], NULL
        Else
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'CandidateNameU, varchar[50], NULL
        End If
        '******************************
        sSQL.Append(SQLNumber(IIf(optBoy.Checked, "0", "1").ToString) & COMMA) 'Sex, tinyint, NULL
        sSQL.Append(SQLNumber(UndefinedBD) & COMMA)
        sSQL.Append(SQLDateSave(c1dateBirthDate.Value) & COMMA) 'BirthDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtBirthPlace.Text, gbUnicode, False) & COMMA & vbCrLf) 'BirthPlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtBirthPlace.Text, gbUnicode, True) & COMMA & vbCrLf) 'BirthPlace, varchar[250], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcEthnicID)) & COMMA) 'EthnicID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcReligionID)) & COMMA) 'ReligionID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcNationalityID)) & COMMA) 'NationalityID, varchar[20], NULL
        sSQL.Append(SQLString(txtIDCardNo.Text) & COMMA) 'IDCardNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateIDCardDate.Value) & COMMA & vbCrLf) 'IDCardDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcZoneCode)) & COMMA) 'IDCardPlaceID, varchar[250], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcMaritalStatus)) & COMMA) 'MaritalStatus, varchar[50], NULL
        sSQL.Append(SQLNumber(txtChildrenQuan.Text) & COMMA) 'ChildrenQuan, int, NULL
        sSQL.Append(SQLStringUnicode(txtPermanentAddress.Text, gbUnicode, False) & COMMA) 'PermanentAddress, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtPermanentAddress.Text, gbUnicode, True) & COMMA) 'PermanentAddress, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtContactAddress.Text, gbUnicode, False) & COMMA & vbCrLf) 'ContactAddress, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtContactAddress.Text, gbUnicode, True) & COMMA & vbCrLf) 'ContactAddress, varchar[250], NULL
        sSQL.Append(SQLString(txtTelephone.Text) & COMMA) 'Telephone, varchar[20], NULL
        sSQL.Append(SQLString(txtMobile.Text) & COMMA) 'Mobile, varchar[20], NULL
        sSQL.Append(SQLString(txtEmail.Text) & COMMA) 'Email, varchar[20], NULL
        sSQL.Append(SQLString(txtFax.Text) & COMMA) 'Fax, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateMilitaryStatedDate.Text) & COMMA & vbCrLf) 'MilitaryStartedDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateMilitaryEndedDate.Text) & COMMA) 'MilitaryEndedDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcMilitaryRank)) & COMMA) 'MilitaryRank, varchar[100], NULL
        sSQL.Append(SQLMoney(txtHeight.Text) & COMMA) 'Height, money, NOT NULL
        sSQL.Append(SQLMoney(txtWeight.Text) & COMMA) 'Weight, money, NOT NULL
        sSQL.Append(SQLStringUnicode(txtHealthStatus.Text, gbUnicode, False) & COMMA & vbCrLf) 'HealthStatus, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtHealthStatus.Text, gbUnicode, True) & COMMA & vbCrLf) 'HealthStatus, varchar[20], NULL
        ' thong tin tuyen dung
        sSQL.Append(SQLDateSave(c1dateReceivedDate.Value) & COMMA & vbCrLf) 'ReceivedDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtReceivedPlace.Text, gbUnicode, False) & COMMA) 'ReceivedPlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtReceivedPlace.Text, gbUnicode, True) & COMMA) 'ReceivedPlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(ReturnValueC1Combo(tdbcFileReceiver), gbUnicode, False) & COMMA) 'FileReceiver, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(ReturnValueC1Combo(tdbcFileReceiver), gbUnicode, True) & COMMA) 'FileReceiver, varchar[50], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecSourceID)) & COMMA) 'RecSourceID, varchar[20], NULL

        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        If tdbcSuggesterID.Text = "" Then
            sSQL.Append(SQLStringUnicode(txtSuggester.Text, gbUnicode, False) & COMMA) 'Suggester, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(txtSuggester.Text, gbUnicode, True) & COMMA) 'Suggester, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDivision.Text, gbUnicode, False) & COMMA & vbCrLf) 'SuggesterDivision, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDivision.Text, gbUnicode, True) & COMMA & vbCrLf) 'SuggesterDivision, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDepartment.Text, gbUnicode, False) & COMMA) 'SuggesterDepartment, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDepartment.Text, gbUnicode, True) & COMMA) 'SuggesterDepartment, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDuty.Text, gbUnicode, False) & COMMA) 'SuggesterDuty, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtSuggesterDuty.Text, gbUnicode, True) & COMMA) 'SuggesterDuty, varchar[250], NOT NULL
        Else
            sSQL.Append(SQLStringUnicode("", gbUnicode, False) & COMMA) 'Suggester, varchar[50], NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'Suggester, varchar[50], NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, False) & COMMA & vbCrLf) 'SuggesterDivision, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA & vbCrLf) 'SuggesterDivision, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, False) & COMMA) 'SuggesterDepartment, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'SuggesterDepartment, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, False) & COMMA) 'SuggesterDuty, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'SuggesterDuty, varchar[250], NOT NULL
        End If
        'IncidentID	51312   	Lưu không đúng dữ liệu cột quan hệ khi cập nhật danh sách ứng cử viên
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRelationName)) & COMMA) 'SuggesterRelationID, varchar[250], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecDepartmentID)) & COMMA) 'RecDepartmentID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecTeamID)) & COMMA & vbCrLf) 'RecTeamID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA) 'RecPositionID, varchar[20], NULL
        sSQL.Append(SQLMoney(txtDesiredSalary.Text) & COMMA) 'DesiredSalary, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[20], NULL
        sSQL.Append(SQLString(IIf(chkLongBusinesstrip.Checked, "1", "0").ToString) & COMMA) 'LongBusinesstrip, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtReason.Text, gbUnicode, False) & COMMA) 'Reason, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtReason.Text, gbUnicode, True) & COMMA) 'Reason, varchar[250], NULL
        sSQL.Append(SQLDateSave(c1dateStartingDate.Value) & COMMA & vbCrLf) 'StartingDate, datetime, NULL
        ' ky nang
        sSQL.Append(SQLStringUnicode(txtEquipmentSkill.Text, gbUnicode, False) & COMMA) 'EquipmentSkill, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtEquipmentSkill.Text, gbUnicode, True) & COMMA) 'EquipmentSkill, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtAptitude.Text, gbUnicode, False) & COMMA) 'Aptitude, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtAptitude.Text, gbUnicode, True) & COMMA) 'Aptitude, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtHobby.Text, gbUnicode, False) & COMMA) 'Hobby, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtHobby.Text, gbUnicode, True) & COMMA) 'Hobby, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtOtherDesire.Text, gbUnicode, False) & COMMA & vbCrLf) 'OtherDesire, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtOtherDesire.Text, gbUnicode, True) & COMMA & vbCrLf) 'OtherDesire, varchar[250], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcFileType)) & COMMA) 'FileType, varchar[50], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRemarkID)) & COMMA) 'RemarkID, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtRemarkBeforeInterview.Text, gbUnicode, False) & COMMA) 'RemarkBeforeInterview, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtRemarkBeforeInterview.Text, gbUnicode, True) & COMMA) 'RemarkBeforeInterview, varchar[250], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcEducationLevelID)) & COMMA) 'EducationLevelID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcProfessionalLevelID)) & COMMA & vbCrLf) 'ProfessionalLevelID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPoliticsID)) & COMMA) 'PoliticsID, varchar[20], NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'TransferedD09, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrLf) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append(SQLString(txtDrivingLicenseID.Text) & COMMA)
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcShiftID)) & COMMA)
        sSQL.Append("GetDate()" & COMMA) 'lastModifyDate, datetime, NULL
        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        sSQL.Append(SQLString(tdbcSuggesterID.Text) & COMMA)
        'ID 54204
        sSQL.Append(SQLString(txtIncomeTaxCode.Text) & COMMA) 'IncomeTaxCode, varchar[50], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPITIssuePlaceID).ToString) & COMMA) 'PITIssuePlaceID, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1datePITIssueDate.Value) & COMMA) 'PITIssueDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcEmpGroupID).ToString) & COMMA) 'EmpGroupID, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtNativePlace.Text, gbUnicode, False) & COMMA) 'NativePlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNativePlace.Text, gbUnicode, True) & COMMA) 'NativePlaceU, nvarchar[250], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPopulationID).ToString) & COMMA) 'PopulationID, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtProvisionalAddress.Text, gbUnicode, False) & COMMA) 'ProvisionalAddress
        sSQL.Append(SQLStringUnicode(txtProvisionalAddress.Text, gbUnicode, True) & COMMA) 'ProvisionalAddressU
        sSQL.Append(SQLStringUnicode(txtEmContactName1.Text, gbUnicode, False) & COMMA) 'EmContactName1
        sSQL.Append(SQLStringUnicode(txtEmContactName1.Text, gbUnicode, True) & COMMA) 'EmContactName1U
        sSQL.Append(SQLStringUnicode(txtEmContactName2.Text, gbUnicode, False) & COMMA) 'EmContactName2
        sSQL.Append(SQLStringUnicode(txtEmContactName2.Text, gbUnicode, True) & COMMA) 'EmContactName2U
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcEmRelationName1)) & COMMA) 'EmRelationID1
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcEmRelationName2)) & COMMA) 'EmRelationID2
        sSQL.Append(SQLStringUnicode(txtEmContactPhone1.Text) & COMMA) 'EmContactPhone1
        sSQL.Append(SQLStringUnicode(txtEmContactPhone2.Text) & COMMA) 'EmContactPhone2
        sSQL.Append(SQLStringUnicode(txtEmContactAddress1.Text, gbUnicode, False) & COMMA) 'EmContactAddress1
        sSQL.Append(SQLStringUnicode(txtEmContactAddress1.Text, gbUnicode, True) & COMMA) 'EmContactAddress1U
        sSQL.Append(SQLStringUnicode(txtEmContactAddress2.Text, gbUnicode, False) & COMMA) 'EmContactAddress2
        sSQL.Append(SQLStringUnicode(txtEmContactAddress2.Text, gbUnicode, True) & COMMA) 'EmContactAddress2U
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTrousersSizeName)) & COMMA) 'TrousersSize
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcShirtSizeName)) & COMMA) 'ShirtSize
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcShoesSizeName)) & COMMA) 'ShoesSize
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcClothesSizeName)) & COMMA) 'ClothesSize

        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBirthPlaceProvinceID)) & COMMA) 'BirthPlaceProvinceID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBirthPlaceDistrictID)) & COMMA) 'BirthPlaceDistrictID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBirthPlaceWardID)) & COMMA) 'BirthPlaceWardID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBPPLabelID)) & COMMA) 'BPPLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBPDLabelID)) & COMMA) 'BPDLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBPWLabelID)) & COMMA) 'BPWLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcConAddressProvinceID)) & COMMA) 'ConAddressProvinceID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcConAddressWardID)) & COMMA) 'ConAddressWardID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcConAddressDistrictID)) & COMMA) 'ConAddressDistrictID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCAWLabelID)) & COMMA) 'CAWLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCADLabelID)) & COMMA) 'CADLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCAPLabelID)) & COMMA) 'CAPLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtConAddressStreet, True) & COMMA) 'ConAddressStreetU, nvarchar[1000], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcResAddressWardID)) & COMMA) 'ResAddressWardID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcResAddressDistrictID)) & COMMA) 'ResAddressDistrictID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcResAddressProvinceID)) & COMMA) 'ResAddressProvinceID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRAWLabelID)) & COMMA) 'RAWLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRADLabelID)) & COMMA) 'RADLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRAPLabelID)) & COMMA) 'RAPLabelID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtResAddressStreet, True) & COMMA) 'ResAddressStreetU, nvarchar[1000], NOT NULL

        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcWorkName)) & COMMA) 'WorkID
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA) 'ProjectID
        sSQL.Append(SQLStringUnicode(txtJobDescription.Text, gbUnicode, False) & COMMA) 'JobDescription
        sSQL.Append(SQLStringUnicode(txtJobDescription.Text, gbUnicode, True) & COMMA) 'JobDescriptionU
        sSQL.Append(SQLStringUnicode(txtPastRecruits.Text, gbUnicode, False) & COMMA) 'PastRecruits
        sSQL.Append(SQLStringUnicode(txtPastRecruits.Text, gbUnicode, True)) 'PastRecruitsU
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1041
    '# Created User: Lê Thị Lành
    '# Created Date: 02/11/2007 11:25:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1041(ByVal UndefinedBD As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1041 Set ")
        If sImgFileName = "" Then sSQL.Append("ImageID = NULL" & COMMA)
        sSQL.Append("LastName = " & SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("LastNameU = " & SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("MiddleName = " & SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA) 'varchar[60], NOT NULL
        sSQL.Append("MiddleNameU = " & SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA) 'varchar[60], NOT NULL
        sSQL.Append("FirstName = " & SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("FirstNameU = " & SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'varchar[30], NOT NULL
        '******************************
        If txtMiddleName.Text <> "" Then 'ID 84207 26/01/2016
            sSQL.Append("CandidateName = isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'varchar[50], NULL
            sSQL.Append("CandidateNameU = isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'varchar[50], NULL
        Else
            sSQL.Append("CandidateName = isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'varchar[50], NULL
            sSQL.Append("CandidateNameU = isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'varchar[50], NULL
        End If
        '******************************
        sSQL.Append("Sex = " & SQLNumber(IIf(optBoy.Checked, "0", "1").ToString) & COMMA) 'tinyint, NULL
        sSQL.Append("UndefinedBD = " & SQLNumber(UndefinedBD) & COMMA) 'tinyint, NULL
        sSQL.Append("BirthDate = " & SQLDateSave(c1dateBirthDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("BirthPlace = " & SQLStringUnicode(txtBirthPlace.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("BirthPlaceU = " & SQLStringUnicode(txtBirthPlace.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("EthnicID = " & SQLString(ReturnValueC1Combo(tdbcEthnicID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("ReligionID = " & SQLString(ReturnValueC1Combo(tdbcReligionID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("NationalityID = " & SQLString(ReturnValueC1Combo(tdbcNationalityID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("IDCardNo = " & SQLString(txtIDCardNo.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("IDCardDate = " & SQLDateSave(c1dateIDCardDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("IDCardPlaceID = " & SQLString(ReturnValueC1Combo(tdbcZoneCode)) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MaritalStatus = " & SQLString(ReturnValueC1Combo(tdbcMaritalStatus)) & COMMA) 'varchar[50], NULL
        sSQL.Append("ChildrenQuan = " & SQLNumber(txtChildrenQuan.Text) & COMMA) 'int, NULL
        sSQL.Append("PermanentAddress = " & SQLStringUnicode(txtPermanentAddress.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("PermanentAddressU = " & SQLStringUnicode(txtPermanentAddress.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("ContactAddress = " & SQLStringUnicode(txtContactAddress.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ContactAddressU = " & SQLStringUnicode(txtContactAddress.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Telephone = " & SQLString(txtTelephone.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("Mobile = " & SQLString(txtMobile.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("Email = " & SQLString(txtEmail.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("Fax = " & SQLString(txtFax.Text) & COMMA) 'varchar[20], NULL

        sSQL.Append("ProvisionalAddress = " & SQLStringUnicode(txtProvisionalAddress.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("ProvisionalAddressU = " & SQLStringUnicode(txtProvisionalAddress.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactName1 = " & SQLStringUnicode(txtEmContactName1.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactName1U = " & SQLStringUnicode(txtEmContactName1.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactName2 = " & SQLStringUnicode(txtEmContactName2.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactName2U = " & SQLStringUnicode(txtEmContactName2.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmRelationID1 = " & SQLString(ReturnValueC1Combo(tdbcEmRelationName1)) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmRelationID2 = " & SQLString(ReturnValueC1Combo(tdbcEmRelationName2)) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactPhone1 = " & SQLString(txtEmContactPhone1.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactPhone2 = " & SQLString(txtEmContactPhone2.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactAddress1 = " & SQLStringUnicode(txtEmContactAddress1.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactAddress1U = " & SQLStringUnicode(txtEmContactAddress1.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactAddress2 = " & SQLStringUnicode(txtEmContactAddress2.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("EmContactAddress2U = " & SQLStringUnicode(txtEmContactAddress2.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("TrousersSize = " & SQLString(ReturnValueC1Combo(tdbcTrousersSizeName)) & COMMA) 'varchar[20], NULL
        sSQL.Append("ShirtSize = " & SQLString(ReturnValueC1Combo(tdbcShirtSizeName)) & COMMA) 'varchar[20], NULL
        sSQL.Append("ShoesSize = " & SQLString(ReturnValueC1Combo(tdbcShoesSizeName)) & COMMA) 'varchar[20], NULL
        sSQL.Append("ClothesSize = " & SQLString(ReturnValueC1Combo(tdbcClothesSizeName)) & COMMA) 'varchar[20], NULL
        sSQL.Append("WorkID = " & SQLString(ReturnValueC1Combo(tdbcWorkName)) & COMMA) 'varchar[20], NULL
        sSQL.Append("JobDescription = " & SQLStringUnicode(txtJobDescription.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("JobDescriptionU = " & SQLStringUnicode(txtJobDescription.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("PastRecruits = " & SQLStringUnicode(txtPastRecruits.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("PastRecruitsU = " & SQLStringUnicode(txtPastRecruits.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("HealthStatus = " & SQLStringUnicode(txtHealthStatus.Text, gbUnicode, False) & COMMA) 'varchar[20], NULL
        sSQL.Append("HealthStatusU = " & SQLStringUnicode(txtHealthStatus.Text, gbUnicode, True) & COMMA) 'varchar[20], NULL
        sSQL.Append("Height = " & SQLMoney(txtHeight.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Weight = " & SQLMoney(txtWeight.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("EducationLevelID = " & SQLString(ReturnValueC1Combo(tdbcEducationLevelID)) & COMMA)
        sSQL.Append("ProfessionalLevelID = " & SQLString(ReturnValueC1Combo(tdbcProfessionalLevelID)) & COMMA)
        sSQL.Append("PoliticsID = " & SQLString(ReturnValueC1Combo(tdbcPoliticsID)) & COMMA)
        ' thong tin tuyen dung
        sSQL.Append("ReceivedDate = " & SQLDateSave(c1dateReceivedDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("FileReceiver = " & SQLStringUnicode(ReturnValueC1Combo(tdbcFileReceiver), gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("FileReceiverU = " & SQLStringUnicode(ReturnValueC1Combo(tdbcFileReceiver), gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ReceivedPlace = " & SQLStringUnicode(txtReceivedPlace.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ReceivedPlaceU = " & SQLStringUnicode(txtReceivedPlace.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("RecSourceID = " & SQLString(ReturnValueC1Combo(tdbcRecSourceID)) & COMMA) 'varchar[20], NULL
        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        If tdbcSuggesterID.Text = "" Then
            sSQL.Append("Suggester = " & SQLStringUnicode(txtSuggester.Text, gbUnicode, False) & COMMA) 'varchar[50], NULL
            sSQL.Append("SuggesterU = " & SQLStringUnicode(txtSuggester.Text, gbUnicode, True) & COMMA) 'varchar[50], NULL
            sSQL.Append("SuggesterDivision = " & SQLStringUnicode(txtSuggesterDivision.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDivisionU = " & SQLStringUnicode(txtSuggesterDivision.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDepartment = " & SQLStringUnicode(txtSuggesterDepartment.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDepartmentU = " & SQLStringUnicode(txtSuggesterDepartment.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDuty = " & SQLStringUnicode(txtSuggesterDuty.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDutyU = " & SQLStringUnicode(txtSuggesterDuty.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        Else
            sSQL.Append("Suggester = " & SQLStringUnicode("", gbUnicode, False) & COMMA) 'varchar[50], NULL
            sSQL.Append("SuggesterU = " & SQLStringUnicode("", gbUnicode, True) & COMMA) 'varchar[50], NULL
            sSQL.Append("SuggesterDivision = " & SQLStringUnicode("", gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDivisionU = " & SQLStringUnicode("", gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDepartment = " & SQLStringUnicode("", gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDepartmentU = " & SQLStringUnicode("", gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDuty = " & SQLStringUnicode("", gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("SuggesterDutyU = " & SQLStringUnicode("", gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        End If
        sSQL.Append("SuggesterRelationID = " & SQLString(ReturnValueC1Combo(tdbcRelationName)) & COMMA) 'SuggesterRelationID, varchar[250], NOT NULL
        sSQL.Append("DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("RecDepartmentID = " & SQLString(ReturnValueC1Combo(tdbcRecDepartmentID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("RecTeamID = " & SQLString(ReturnValueC1Combo(tdbcRecTeamID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("RecPositionID = " & SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("DesiredSalary = " & SQLMoney(txtDesiredSalary.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("CurrencyID = " & SQLString(ReturnValueC1Combo(tdbcCurrencyID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Reason = " & SQLStringUnicode(txtReason.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ReasonU = " & SQLStringUnicode(txtReason.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("StartingDate = " & SQLDateSave(c1dateStartingDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("LongBusinesstrip = " & SQLString(IIf(chkLongBusinesstrip.Checked, "1", "0").ToString) & COMMA) 'varchar[20], NULL
        'Khác
        sSQL.Append("MilitaryStartedDate = " & SQLDateSave(c1dateMilitaryStatedDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("MilitaryEndedDate = " & SQLDateSave(c1dateMilitaryEndedDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("MilitaryRank = " & SQLString(tdbcMilitaryRank.Columns("MilitaryRank").Text) & COMMA) 'varchar[100], NULL
        sSQL.Append("DrivingLicenseID = " & SQLString(txtDrivingLicenseID.Text) & COMMA)
        ' kỷ năng
        sSQL.Append("EquipmentSkill = " & SQLStringUnicode(txtEquipmentSkill.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("EquipmentSkillU = " & SQLStringUnicode(txtEquipmentSkill.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Aptitude = " & SQLStringUnicode(txtAptitude.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("AptitudeU = " & SQLStringUnicode(txtAptitude.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Hobby = " & SQLStringUnicode(txtHobby.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("HobbyU = " & SQLStringUnicode(txtHobby.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("OtherDesire = " & SQLStringUnicode(txtOtherDesire.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("OtherDesireU = " & SQLStringUnicode(txtOtherDesire.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("FileType = " & SQLString(ReturnValueC1Combo(tdbcFileType)) & COMMA) 'varchar[50], NULL
        sSQL.Append("RemarkBeforeInterview = " & SQLStringUnicode(txtRemarkBeforeInterview.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("RemarkBeforeInterviewU = " & SQLStringUnicode(txtRemarkBeforeInterview.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("RemarkID = " & SQLString(ReturnValueC1Combo(tdbcRemarkID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Disabled = " & SQLNumber(IIf(chkDisabled.Checked, "1", "0").ToString) & COMMA) 'tinyint, NULL
        sSQL.Append("ShiftID = " & SQLString(ReturnValueC1Combo(tdbcShiftID)) & COMMA)
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("lastModifyDate =  getdate()" & COMMA) 'datetime, NULL

        'IncidentID	51206  	Cho đổ combo Người giới thiệu tại màn hình Cập nhật hồ sơ ứng viên
        sSQL.Append("SuggesterID = " & SQLString(ReturnValueC1Combo(tdbcSuggesterID)) & COMMA)
        'ID 54204
        sSQL.Append(" IncomeTaxCode = " & SQLString(txtIncomeTaxCode.Text) & COMMA) 'IncomeTaxCode, varchar[50], NULL
        sSQL.Append(" PITIssuePlaceID = " & SQLString(ReturnValueC1Combo(tdbcPITIssuePlaceID).ToString) & COMMA) 'PITIssuePlaceID, varchar[20], NULL
        sSQL.Append(" PITIssueDate = " & SQLDateSave(c1datePITIssueDate.Value) & COMMA) 'PITIssueDate, datetime, NULL
        sSQL.Append(" EmpGroupID = " & SQLString(ReturnValueC1Combo(tdbcEmpGroupID).ToString) & COMMA) 'EmpGroupID, varchar[20], NULL
        sSQL.Append(" ProjectID = " & SQLString(ReturnValueC1Combo(tdbcProjectID).ToString) & COMMA) 'ProjectID, varchar[20], NULL
        sSQL.Append(" NativePlace = " & SQLStringUnicode(txtNativePlace.Text, gbUnicode, False) & COMMA) 'NativePlace, varchar[250], NULL
        sSQL.Append(" NativePlaceU = " & SQLStringUnicode(txtNativePlace.Text, gbUnicode, True) & COMMA) 'NativePlaceU, nvarchar[250], NULL
        sSQL.Append(" PopulationID = " & SQLString(ReturnValueC1Combo(tdbcPopulationID).ToString) & COMMA) 'PopulationID, varchar[20], NULL
        sSQL.Append("ResAddressStreetU = " & SQLStringUnicode(txtResAddressStreet, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("ResAddressWardID = " & SQLString(ReturnValueC1Combo(tdbcResAddressWardID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ResAddressDistrictID = " & SQLString(ReturnValueC1Combo(tdbcResAddressDistrictID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ResAddressProvinceID = " & SQLString(ReturnValueC1Combo(tdbcResAddressProvinceID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("RAWLabelID = " & SQLString(ReturnValueC1Combo(tdbcRAWLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("RADLabelID = " & SQLString(ReturnValueC1Combo(tdbcRADLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("RAPLabelID = " & SQLString(ReturnValueC1Combo(tdbcRAPLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ConAddressStreetU = " & SQLStringUnicode(txtConAddressStreet, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("ConAddressProvinceID = " & SQLString(ReturnValueC1Combo(tdbcConAddressProvinceID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ConAddressWardID = " & SQLString(ReturnValueC1Combo(tdbcConAddressWardID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ConAddressDistrictID = " & SQLString(ReturnValueC1Combo(tdbcConAddressDistrictID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("CAWLabelID = " & SQLString(ReturnValueC1Combo(tdbcCAWLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("CADLabelID = " & SQLString(ReturnValueC1Combo(tdbcCADLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("CAPLabelID = " & SQLString(ReturnValueC1Combo(tdbcCAPLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BirthPlaceWardID = " & SQLString(ReturnValueC1Combo(tdbcBirthPlaceWardID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BirthPlaceDistrictID = " & SQLString(ReturnValueC1Combo(tdbcBirthPlaceDistrictID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BirthPlaceProvinceID = " & SQLString(ReturnValueC1Combo(tdbcBirthPlaceProvinceID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BPWLabelID = " & SQLString(ReturnValueC1Combo(tdbcBPWLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BPDLabelID = " & SQLString(ReturnValueC1Combo(tdbcBPDLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BPPLabelID = " & SQLString(ReturnValueC1Combo(tdbcBPPLabelID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID)))
        sSQL.Append(" Where ")
        sSQL.Append("CandidateID = " & SQLString(_candidateID))

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1055
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/01/2009 10:54:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1055() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1055 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1056
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/01/2009 10:57:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1056() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1056 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtCandidateID.Text) 'CandidateID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function ReadPhoto(ByVal sFileName As String) As Byte()
        Dim photo As Byte() = {}
        If Not ExistFile(sFileName) Then Return photo
        Dim fs As New FileStream(sFileName, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)

        photo = br.ReadBytes(CInt(fs.Length))
        br.Close()
        fs.Close()
        Return photo
    End Function

    Public Sub SaveImage(ByVal sFileName As String, ByVal sKey As String)

        Dim photo As Byte() = ReadPhoto(sFileName)
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sqlcmd As New SqlCommand("Update D25T1041 Set ImageID = @ImageID  Where CandidateID = @CandidateID", conn)

        Try
            If sqlcmd.Parameters.Count = 0 Then
                sqlcmd.Parameters.Add("@CandidateID", SqlDbType.VarChar, 20, "CandidateID").Value = sKey
                sqlcmd.Parameters.Add("@ImageID", System.Data.SqlDbType.Image, photo.Length).Value = photo 'Lưu ảnh kiểu Image 
            End If

            conn.Open()
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            sqlcmd.Dispose()
            conn.Close()
        End Try
    End Sub

    ''' 
    ''' Kiểm tra có tồn tại file dữ liệu hay không 
    ''' 
    ''' sFileName là chuỗi đường dẫn tên tập tin 
    ''' 
    ''' 
    Public Function ExistFile(ByVal sFileName As String) As Boolean
        ExistFile = True
        If Not File.Exists(sFileName) Then
            ExistFile = False
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        '  If Not bCheckIDCardNo Then Exit Sub 'TH không thỏa CMND 
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        '************************** Ngay sinh
        Dim ngay As Integer = L3Int(txtNumday.Text)
        Dim thang As Integer = L3Int(txtNumMonth.Text)
        Dim nam As Integer = L3Int(txtNumYear.Text)
        Dim iUndefinedBD As Integer = 0
        If nam = 0 Then 'k nhap
            iUndefinedBD = 0
        Else
            If ngay <> 0 AndAlso thang <> 0 Then 'Nhap day du ngay ,thang ,nam
                iUndefinedBD = 0
            ElseIf ngay = 0 AndAlso thang = 0 Then 'Chi nhap nam
                iUndefinedBD = 1
            ElseIf ngay = 0 AndAlso thang <> 0 Then 'Chi nhap thang,nam
                iUndefinedBD = 2
            End If
        End If

        If ngay = 0 Then ngay = 1
        If thang = 0 Then thang = 1

        If nam <> 0 Then
            Dim d As New Date(nam, thang, ngay)
            c1dateBirthDate.Value = SQLDateShow(d)
        Else
            c1dateBirthDate.Value = ""
        End If
        '***********************
        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                sSQL.Append(SQLInsertD25T1041(iUndefinedBD).ToString & vbCrLf)
                If _parentFrm = "D25F1055" Then
                    sSQL.Append(SQLStoreD25P1056 & vbCrLf)
                End If
                'ID 101294 25.08.2017
                   sSQL.Append(SQLInsertD25T1035.ToString )
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1041(iUndefinedBD).ToString & vbCrLf)
                  'ID 101294 25.08.2017
                   sSQL.Append(SQLUpdateD25T1035.ToString )
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            If sImgFileName <> "Original" And sImgFileName <> "" Then
                SaveImage(sImgFileName, txtCandidateID.Text)
            End If
            SaveOK()
            _bSaved = True
            _candidateID = txtCandidateID.Text
            btnClose.Enabled = True
            EnableButton(True)
            If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()

                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()

                    'Bổ sung AuditLog (10/04/2008)
                    Dim Decs1 As String = ""
                    Dim Decs2 As String = ""
                    Dim Decs3 As String = ""
                    Dim Decs4 As String = ""
                    Dim Decs5 As String = ""
                    Decs1 = Trim(_divisionID.ToString)
                    Decs2 = Trim(CandidateID.ToString)
                    Decs3 = Trim(tdbcRecDepartmentID.Text)
                    Decs4 = Trim(tdbcRecTeamID.Text)
                    Decs5 = Trim(tdbcRecPositionID.Text)
                    Call RunAuditLog("CandidateFiles", "02", Decs1, Decs2, Decs3, Decs4, Decs5)

            End Select
        Else
            _bSaved = False
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtChildrenQuan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChildrenQuan.KeyPress
        If e.KeyChar = Chr(22) Or e.KeyChar = Chr(3) Then Exit Sub 'cho phép dùng Ctr v, Ctr C
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtChildrenQuan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChildrenQuan.LostFocus
        Try
            txtChildrenQuan.Text = Format(Number(txtChildrenQuan.Text), D25Format.DefaultNumber0)
        Catch ex As Exception
            txtChildrenQuan.Text = "0"
        End Try

    End Sub

    Private Sub txtDesiredSalary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesiredSalary.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtDesiredSalary_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesiredSalary.LostFocus
        txtDesiredSalary.Text = Format(Number(txtDesiredSalary.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeight.KeyPress
        If e.KeyChar = Chr(22) Or e.KeyChar = Chr(3) Then Exit Sub 'cho phép dùng Ctr v, Ctr C
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtHeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeight.LostFocus
        Try
            txtHeight.Text = Format(Number(txtHeight.Text), D25Format.DefaultNumber2)
        Catch ex As Exception
            txtHeight.Text = "0"
        End Try

    End Sub

    Private Sub txtWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWeight.KeyPress
        If e.KeyChar = Chr(22) Or e.KeyChar = Chr(3) Then Exit Sub 'cho phép dùng Ctr v, Ctr C
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeight.LostFocus
        Try
            txtWeight.Text = Format(Number(txtWeight.Text), D25Format.DefaultNumber2)
        Catch ex As Exception
            txtWeight.Text = "0"
        End Try

    End Sub

    Private Sub txtTelephone_Validated(sender As Object, e As EventArgs) Handles txtTelephone.Validated, txtMobile.Validated
        Dim txt As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
        If txt.Text <> "" Then
            If L3String(txt.Tag) <> txt.Text Then
                txt.Tag = txt.Text
                If txt.Name = txtTelephone.Name Then
                    If CheckStore(SQLStoreD25P5555("D25F1051", txtTelephone.Text, txtCandidateID.Text, 2, 1)) = False Then txtTelephone.Focus()
                ElseIf txt.Name = txtMobile.Name Then
                    If CheckStore(SQLStoreD25P5555("D25F1051", txtMobile.Text, txtCandidateID.Text, 2, 2)) = False Then txtMobile.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub picCandidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picCandidate.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = System.Environment.GetFolderPath _
   (System.Environment.SpecialFolder.Personal)
        openFileDialog1.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*"

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sImgFileName = openFileDialog1.FileName
            If sImgFileName <> "" Then
                Dim myImage As Image = Image.FromFile(sImgFileName)
                If picCandidate.Image Is Nothing = False Then picCandidate.Image.Dispose()

                picCandidate.Image = myImage
            End If
        End If
        If Not picCandidate.Image Is Nothing Then
            lblGetPhoto.Visible = False
            lblGetPhoto2.Visible = False
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not D25Options.SaveLastRecent Then
            c1dateStartingDate.Value = Now()
            SetNew()
        End If
        If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()
        btnNext.Enabled = False
        EnableButton(False)
        btnSave.Enabled = True
        btnEnclourse.Text = rL3("Dinh_ke_m") 'Đính kè&m
        tabMain.SelectedTab = TabPage1
        tabPrivate.SelectedTab = TabPage2
        tdbcDivisionID.SelectedValue = _divisionID
        'IncidentID	50891
        If tdbcMethodID.Visible Then
            Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
            If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString
            tdbcMethodID.Focus()
        Else
            txtCandidateID.Focus()
        End If
    End Sub

    Private Sub btnQTDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQTDT.Click
        Dim f1 As New D25F1052
        f1.CandidateID = txtCandidateID.Text
        f1.FormState = _FormState
        f1.ShowDialog()
        f1.Dispose()
    End Sub

    Private Sub btnKNLV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKNLV.Click
        'Dim frm As New DxxMxx40
        'With frm
        '    .exeName = "D09E1040" 'Exe cần gọi
        '    .FormActive = "D09F0504" 'Form cần hiển thị
        '    Dim sField() As String = {"FormState", "CandidateID"}
        '    Dim sValue() As String = {CInt(_FormState).ToString, txtCandidateID.Text}
        '    .IDxx(sField) = sValue
        '    .ShowDialog()
        '    .Dispose()
        'End With

        'ID 82836 14/12/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", _FormState)
        SetProperties(arrPro, "CandidateID", txtCandidateID.Text)
        SetProperties(arrPro, "ModuleID", "25")
        CallFormShowDialog("D09D1040", "D09F0504", arrPro)
    End Sub

    Private Sub btnEnclourse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnclourse.Click
        'ID 79397 4/9/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormPermission", "D25F1050")
        SetProperties(arrPro, "TableName", "D25T1041")
        SetProperties(arrPro, "Key1ID", txtCandidateID.Text)
        SetProperties(arrPro, "FormState", _FormState)
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
        btnEnclourse.Text = rL3("Dinh_ke_m") & Space(1) & " (" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")" 'Đính kèm
    End Sub

    Private Sub tabMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.Click
        If tabMain.SelectedIndex = 0 Then
            If _FormState = EnumFormState.FormAdd Then
                If tdbcMethodID.Visible Then
                    tdbcMethodID.Focus()
                Else
                    txtCandidateID.Focus()
                End If
            Else
                txtLastName.Focus()
            End If
        ElseIf tabMain.SelectedIndex = 1 Then
            c1dateReceivedDate.Focus()
        ElseIf tabMain.SelectedIndex = 2 Then
            txtEquipmentSkill.Focus()
        ElseIf tabMain.SelectedIndex = 3 Then
            c1dateMilitaryStatedDate.Focus()
        Else
        End If
    End Sub

#Region "Events tdbcDepartmentID with txtDepartmentName"


    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        'If bAllowDepartmentID_SelectedValueChanged = False Then Exit Sub

        If tdbcDepartmentID.SelectedValue Is Nothing Or tdbcDepartmentID.Text = "" Then
            'txtDepartmentName.Text = ""
            LoadTdbcFileReceiverID("-1")
            Exit Sub
        End If
        'txtDepartmentName.Text = tdbcDepartmentID.Columns(1).Value.ToString
        LoadTdbcFileReceiverID(ReturnValueC1Combo(tdbcDepartmentID).ToString)
    End Sub
#End Region

#Region "Events tdbcEducationLevelID"

    Private Sub tdbcEducationLevelID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEducationLevelID.LostFocus
        If tdbcEducationLevelID.FindStringExact(tdbcEducationLevelID.Text) = -1 Then tdbcEducationLevelID.Text = ""
    End Sub
#End Region

#Region "Events tdbcProfessionalLevelID"

    Private Sub ProfessionalLevelIDCombo()
        If ReturnValueC1Combo(tdbcProfessionalLevelID).ToString = "+" Then
            If ReturnPermission("D09F0242") < EnumPermission.Add Then
                MsgNoPermissionAdd()
            Else
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D09F0242")
                SetProperties(arrPro, "FormState", CByte(EnumFormState.FormAdd))
                Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0243", arrPro)

                Dim sKeyID As String = L3String(GetProperties(frm, "ProfessionalLevelID"))
                If sKeyID <> "" Then
                    LoadtdbcProfessionalLevelID()
                    tdbcProfessionalLevelID.SelectedValue = sKeyID
                Else
                    tdbcProfessionalLevelID.SelectedValue = ""
                End If
            End If
            tdbcProfessionalLevelID.Focus()
        End If
    End Sub

    Private Sub tdbcProfessionalLevelID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProfessionalLevelID.Close
        ProfessionalLevelIDCombo()
    End Sub

    Private Sub tdbcProfessionalLevelID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProfessionalLevelID.LostFocus
        If tdbcProfessionalLevelID.FindStringExact(tdbcProfessionalLevelID.Text) = -1 Then tdbcProfessionalLevelID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPoliticsID"

    Private Sub tdbcPoliticsID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPoliticsID.LostFocus, tdbcWorkName.LostFocus, tdbcEmRelationName1.LostFocus, tdbcEmRelationName2.LostFocus, tdbcShirtSizeName.LostFocus, tdbcShoesSizeName.LostFocus, tdbcTrousersSizeName.LostFocus, tdbcClothesSizeName.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub


    Private Sub tdbcWorkName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkName.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = "" : Exit Sub
        ShowFormD09F0431()
    End Sub

    Private Sub tdbcWorkName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkName.Close
        tdbcName_Validated(sender, Nothing)
        ShowFormD09F0431()
    End Sub

    Private Sub tdbcEmRelationName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmRelationName1.LostFocus, tdbcEmRelationName2.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = "" : Exit Sub
        Dim sKey As String = ShowFormD09F0129(tdbc)
        If sKey <> "" Then
            LoadtdbcEmRelationName()
            tdbc.SelectedValue = sKey
        End If
    End Sub

    Private Sub tdbcEmRelationName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmRelationName1.Close, tdbcEmRelationName2.Close
        tdbcName_Validated(sender, Nothing)
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Dim sKey As String = ShowFormD09F0129(tdbc)
        If sKey <> "" Then
            LoadtdbcEmRelationName()
            tdbc.SelectedValue = sKey
        End If
    End Sub

#End Region

    Private Sub lblGetPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGetPhoto.Click
        picCandidate_Click(Nothing, Nothing)
    End Sub

    Private Sub lblGetPhoto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGetPhoto2.Click
        picCandidate_Click(Nothing, Nothing)
    End Sub

    Private Sub btnRemoveImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveImg.Click
        picCandidate.Image = Nothing
        sImgFileName = ""

        lblGetPhoto.Visible = True
        lblGetPhoto2.Visible = True
    End Sub

#Region "Events tdbcRelationName"

    Private Sub tdbcRelationName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRelationName.Close
        'If ReturnValueC1Combo(tdbcRelationName).ToString = "+" Then 'tdbcRelationName.Text = "<Theâm môùi>" Or tdbcRelationName.Text = "<Add new>" Then
        '    Dim sKey As String = CalExeAddNew("D09E0140", "D09F0129", "D09F0128")
        '    LoadtdbcRelationName()
        '    tdbcRelationName.SelectedValue = sKey
        '    tdbcRelationName.Focus()
        'End If
        Dim sKey As String = ShowFormD09F0129(tdbcRelationName)
        If sKey <> "" Then
            LoadtdbcRelationName()
            tdbcRelationName.SelectedValue = sKey
            tdbcRelationName.Focus()
        End If
    End Sub

    Private Sub tdbcRelationName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRelationName.LostFocus
        If tdbcRelationName.FindStringExact(tdbcRelationName.Text) = -1 Then tdbcRelationName.Text = ""
        'If tdbcRelationName.Text = "<Theâm môùi>" Or tdbcRelationName.Text = "<Add new>" Then tdbcRelationName.Text = ""
    End Sub

#End Region

#Region "Events tdbcShiftID"
    Private Sub ShiftCombo()
        If tdbcShiftID.Text = "+" Then
            If ReturnPermission("D29F1010") < EnumPermission.Add Then
                MsgNoPermissionAdd()
            Else
                Dim frm As Form = CallFormShowDialog("D29D0140", "D29F1010")
                Dim skey As Boolean = L3Bool(GetProperties(frm, "bSaved").ToString)
                If skey Then
                    LoadTdbcShiftID()
                    tdbcShiftID.SelectedValue = L3String(GetProperties(frm, "ShiftID").ToString)
                Else
                    tdbcShiftID.SelectedValue = ""
                End If

            End If
            tdbcShiftID.Focus()
        End If
    End Sub

    Private Sub tdbcShiftID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcShiftID.Close
        ShiftCombo()
    End Sub

    Private Sub tdbcShiftID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcShiftID.LostFocus
        If tdbcShiftID.FindStringExact(tdbcShiftID.Text) = -1 Then tdbcShiftID.Text = ""

        If tdbcShiftID.Text = "+" Then tdbcShiftID.Text = ""
    End Sub

#End Region

    Private Sub txtHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHeight.Validating, txtWeight.Validating, txtDesiredSalary.Validating
        Dim txtNum As TextBox = CType(sender, TextBox)
        e.Cancel = Not L3IsNumeric(txtNum.Text)
    End Sub

    Private Sub btnRelationship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelationship.Click
        'ID 82836 14/12/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", _FormState)
        SetProperties(arrPro, "EmployeeID", _candidateID)
        CallFormShowDialog("D09D1040", "D09F1502", arrPro)
    End Sub


    Private Sub txtIDCardNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDCardNo.LostFocus
        btnSave.Enabled = True
        If txtIDCardNo.Text = "" Then Exit Sub
        If txtIDCardNo.Text.Length <> 9 And txtIDCardNo.Text.Length <> 12 Then
            btnSave.Enabled = False
            txtIDCardNo.Focus()
        End If
    End Sub

    Private Sub D25F1051_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If tdbcMethodID.ReadOnly OrElse tdbcMethodID.Enabled = False Then
            txtCandidateID.Focus()
        Else
            tdbcMethodID.Focus()
        End If
    End Sub

    Private Sub ShowFormD09F0431()
        If tdbcWorkName.SelectedValue Is Nothing OrElse tdbcWorkName.SelectedValue.ToString <> "+" Then Exit Sub
        tdbcWorkName.SelectedValue = ""
        If ReturnPermission("D09F0430") > 1 Then
            'ID 82836 14/12/2015
            Dim arrPro() As StructureProperties = Nothing
            Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0431", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) Then
                Dim sKey As String = GetProperties(frm, "WorkID").ToString
                LoadtdbcWorkName()
                tdbcWorkName.SelectedValue = sKey
            End If
        Else
            MsgNoPermissionAdd()
            tdbcWorkName.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtIDCardNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDCardNo.Validated
        If Me.ActiveControl.Name = btnClose.Name Then Exit Sub
        btnSave.Enabled = CheckIDCardNo(Me.Name, txtIDCardNo.Text, txtCandidateID.Text)
        If btnSave.Enabled = False Then txtIDCardNo.Focus()
    End Sub

    Private Sub tdbcProjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.LostFocus
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then tdbcProjectID.Text = ""
    End Sub

#Region "Input BirthDate"
    Private Sub btnBirthDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBirthDate.Click
        c1dateBirthDate.OpenDropDown()
    End Sub

    Private Sub c1dateBirthDate_DropDownClosed(ByVal sender As Object, ByVal e As C1.Win.C1Input.DropDownClosedEventArgs) Handles c1dateBirthDate.DropDownClosed
        Try
            If c1dateBirthDate.Text <> "" Then
                Dim d As Date
                d = CDate(c1dateBirthDate.Text)
                txtNumday.Text = d.Day.ToString
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c1dateBirthDate_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateBirthDate.DropDownOpened
        GetThisFormDate(c1dateBirthDate, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNumday_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumday.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumday, 1, 31, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNumMonth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumMonth.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumMonth, 1, 12, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNumYear_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumYear.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumYear, 1900, Today.Year, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumday.KeyPress, txtNumMonth.KeyPress, txtNumYear.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBirthDate.Click
        c1dateBirthDate.OpenDropDown()
    End Sub
#End Region

    Private Sub btnHisInterview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHisInterview.Click
        Dim f As New D25F1054
        f.CandidateID = txtCandidateID.Text
        f.ShowDialog()
        f.Dispose()
    End Sub

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcPoliticsID.Close, tdbcEducationLevelID.Close, tdbcEthnicID.Close, tdbcReligionID.Close, tdbcNationalityID.Close, tdbcMaritalStatus.Close, tdbcMilitaryRank.Close, tdbcWorkName.Close, tdbcEmRelationName1.Close, tdbcEmRelationName2.Close, tdbcShirtSizeName.Close, tdbcShoesSizeName.Close, tdbcTrousersSizeName.Close, tdbcClothesSizeName.Close, tdbcZoneCode.Close, tdbcPITIssuePlaceID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcFileType.Close, tdbcRecDepartmentID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcProfessionalLevelID.Validated, tdbcPoliticsID.Validated, tdbcEducationLevelID.Validated, tdbcEthnicID.Validated, tdbcReligionID.Validated, tdbcNationalityID.Validated, tdbcMaritalStatus.Validated, tdbcMilitaryRank.Validated, tdbcWorkName.Validated, tdbcEmRelationName1.Validated, tdbcEmRelationName2.Validated, tdbcShirtSizeName.Validated, tdbcShoesSizeName.Validated, tdbcTrousersSizeName.Validated, tdbcClothesSizeName.Validated, tdbcZoneCode.Validated, tdbcPITIssuePlaceID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcFileType.Validated, tdbcRecDepartmentID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        Dim dtTemp As DataTable = ReturnTableFilter(dtDepartment, "DivisionID= '%' or DivisionID=" & SQLString(ReturnValueC1Combo(tdbcDivisionID)), True)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtTemp, "%", gbUnicode)
        LoadtdbcDepartmentID(tdbcRecDepartmentID, dtTemp.DefaultView.ToTable, "%", gbUnicode)
        tdbcDepartmentID.SelectedValue = "" 'An sửa mặc định rỗng
        tdbcRecDepartmentID.SelectedValue = ""
    End Sub

    Private Sub btnDocType_Click(sender As Object, e As EventArgs) Handles btnDocType.Click 'ID 93232 17/01/2017
        Dim f1 As New D25F1057
        f1.CandidateID = txtCandidateID.Text
        f1.FormState = _FormState
        f1.ShowDialog()
        f1.Dispose()
    End Sub


End Class