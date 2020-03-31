Imports System.Windows.Forms
Imports System

'#-------------------------------------------------------------------------------------
'# Created Date: 09/01/2013 4:06:28 PM
'# Created User: VANVINH
'# Modify Date: 09/01/2013 4:06:28 PM
'# Modify User: VANVINH
'# Description: ID 50600
'#-------------------------------------------------------------------------------------
Public Class D25F1056
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 61"
    Private Const COL_BatchID As Integer = 0                 ' BatchID
    Private Const COL_IsUsed As Integer = 1                  ' Chọn
    Private Const COL_CandidateID As Integer = 2             ' Mã
    Private Const COL_LastName As Integer = 3                ' Họ
    Private Const COL_MiddleName As Integer = 4              ' Tên lót
    Private Const COL_FirstName As Integer = 5               ' Tên
    Private Const COL_Sex As Integer = 6                     ' Giới tính
    Private Const COL_DayBD As Integer = 7                   ' Ngày sinh
    Private Const COL_MonthBD As Integer = 8                 ' Tháng sinh
    Private Const COL_YearBD As Integer = 9                  ' Năm sinh
    Private Const COL_IDCardNo As Integer = 10               ' Số CMND
    Private Const COL_IDCardDate As Integer = 11             ' Ngày cấp
    Private Const COL_IDCardPlaceID As Integer = 12          ' Nơi cấp
    Private Const COL_EthnicID As Integer = 13               ' Dân tộc
    Private Const COL_ReligionID As Integer = 14             ' Tôn giáo
    Private Const COL_NationalityID As Integer = 15          ' Quốc tịch
    Private Const COL_Telephone As Integer = 16              ' Điện thoại
    Private Const COL_Email As Integer = 17                  ' Email
    Private Const COL_Mobile As Integer = 18                 ' Di động
    Private Const COL_Fax As Integer = 19                    ' Fax
    Private Const COL_ContactAddress As Integer = 20         ' Địa chỉ liên lạc
    Private Const COL_BPPLabelName As Integer = 21           ' Tỉnh / Thành phố (NS)
    Private Const COL_BPPLabelID As Integer = 22             ' BPPLabelID
    Private Const COL_BirthPlaceProvinceName As Integer = 23 ' CT Tỉnh/ Thành phố (NS)
    Private Const COL_BirthPlaceProvinceID As Integer = 24   ' BirthPlaceProvinceID
    Private Const COL_BPDLabelName As Integer = 25           ' Quận / Huyện (NS)
    Private Const COL_BPDLabelID As Integer = 26             ' BPDLabelID
    Private Const COL_BirthPlaceDistrictID As Integer = 27   ' BirthPlaceDistrictID
    Private Const COL_BirthPlaceDistrictName As Integer = 28 ' CT Quận / Huyện (NS)
    Private Const COL_BPWLabelName As Integer = 29           ' Phường / Xã (NS)
    Private Const COL_BPWLabelID As Integer = 30             ' BPWLabelID
    Private Const COL_BirthPlaceWardID As Integer = 31       ' BirthPlaceWardID
    Private Const COL_BirthPlaceWardName As Integer = 32     ' CT Phường / Xã (NS)
    Private Const COL_ConAddressStreet As Integer = 33       ' Số nhà (Thường trú)
    Private Const COL_CAPLabelName As Integer = 34           ' Tỉnh / Thành phố (Thường trú)
    Private Const COL_CAPLabelID As Integer = 35             ' CAPLabelID
    Private Const COL_ConAddressProvinceName As Integer = 36 ' CT Tỉnh / Thành phố (Thường trú)
    Private Const COL_ConAddressProvinceID As Integer = 37   ' ConAddressProvinceID
    Private Const COL_CADLabelName As Integer = 38           ' Quận / Huyện (Thường trú)
    Private Const COL_CADLabelID As Integer = 39             ' CADLabelID
    Private Const COL_ConAddressDistrictID As Integer = 40   ' ConAddressDistrictID
    Private Const COL_ConAddressDistrictName As Integer = 41 ' CT Quận / Huyện (Thường trú)
    Private Const COL_CAWLabelName As Integer = 42           ' Phường / Xã (Thường trú)
    Private Const COL_CAWLabelID As Integer = 43             ' CAWLabelID
    Private Const COL_ConAddressWardID As Integer = 44       ' ConAddressWardID
    Private Const COL_ConAddressWardName As Integer = 45     ' CT Phường / Xã (Thường trú)
    Private Const COL_ResAddressStreet As Integer = 46       ' Số nhà (Tạm trú)
    Private Const COL_RAPLabelName As Integer = 47           ' Tỉnh / Thành phố (Tạm trú)
    Private Const COL_RAPLabelID As Integer = 48             ' RAPLabelID
    Private Const COL_ResAddressProvinceName As Integer = 49 ' CT Tỉnh / Thành phố (Tạm trú)
    Private Const COL_ResAddressProvinceID As Integer = 50   ' ResAddressProvinceID
    Private Const COL_RADLabelName As Integer = 51           ' Quận / Huyện (Tạm trú)
    Private Const COL_RADLabelID As Integer = 52             ' RADLabelID
    Private Const COL_ResAddressDistrictID As Integer = 53   ' ResAddressDistrictID
    Private Const COL_ResAddressDistrictName As Integer = 54 ' CT Quận / Huyện (Tạm trú)
    Private Const COL_RAWLabelName As Integer = 55           ' Phường / Xã (Tạm trú)
    Private Const COL_RAWLabelID As Integer = 56             ' RAWLabelID
    Private Const COL_ResAddressWardID As Integer = 57       ' ResAddressWardID
    Private Const COL_ResAddressWardName As Integer = 58     ' CT Phường / Xã (Tạm trú)
    Private Const COL_LongBusinesstrip As Integer = 59       ' Chấp nhận đi công tác xa
    Private Const COL_UndefinedBD As Integer = 60            ' UndefinedBD
#End Region

#Region "Const of tdbg2 - Total of Columns: 22"
    Private Const COL2_RelationName As Integer = 0        ' Quan hệ
    Private Const COL2_RelativeName As Integer = 1        ' Tên người quan hệ
    Private Const COL2_RelationSex As Integer = 2         ' Giới tính
    Private Const COL2_DayBD As Integer = 3               ' Ngày sinh
    Private Const COL2_MonthBD As Integer = 4             ' Tháng sinh
    Private Const COL2_YearBD As Integer = 5              ' Năm sinh
    Private Const COL2_RelationBirthPlace As Integer = 6  ' Nơi sinh
    Private Const COL2_RelationAddress As Integer = 7     ' Địa chỉ
    Private Const COL2_IDCardNo As Integer = 8            ' Số CMND
    Private Const COL2_RelationWorkName As Integer = 9    ' Công việc đang làm
    Private Const COL2_EducationLevelName As Integer = 10 ' Trình độ văn hóa
    Private Const COL2_IncomeTaxCode As Integer = 11      ' Mã số thuế
    Private Const COL2_Salary As Integer = 12             ' Thu nhập
    Private Const COL2_Alive As Integer = 13              ' Tình trạng hiện tại
    Private Const COL2_RelationNote As Integer = 14       ' Ghi chú
    Private Const COL2_EffectDate As Integer = 15         ' Ngày hiệu lực
    Private Const COL2_BatchID As Integer = 16            ' BatchID
    Private Const COL2_RelativeID As Integer = 17         ' RelativeID
    Private Const COL2_RelationID As Integer = 18         ' RelationID
    Private Const COL2_RealtionWorkID As Integer = 19     ' RealtionWorkID
    Private Const COL2_EducationLevelID As Integer = 20   ' EducationLevelID
    Private Const COL2_UndefinedBD As Integer = 21        ' UndefinedBD
#End Region

#Region "Const of tdbg3"
    Private Const COL3_ExperienceDateStarted As Integer = 0 ' Bắt đầu
    Private Const COL3_ExperienceDateEnd As Integer = 1     ' Kết thúc
    Private Const COL3_CompanyName As Integer = 2           ' Tên công ty
    Private Const COL3_CountryID As Integer = 3             ' Quốc gia
    Private Const COL3_ExperienceAddress As Integer = 4     ' Địa chỉ
    Private Const COL3_DutyID As Integer = 5                ' Chức vụ
    Private Const COL3_ExperienceWorkName As Integer = 6    ' Công việc
    Private Const COL3_BaseSalary As Integer = 7            ' Mức lương
    Private Const COL3_Allowance As Integer = 8             ' Phụ cấp
    Private Const COL3_CurrencyID As Integer = 9            ' Loại tiền
    Private Const COL3_ColleagueQuan As Integer = 10        ' Số Lượng NV cùng bộ phận
    Private Const COL3_SubordinateQuan As Integer = 11      ' SL NV dưới quyền
    Private Const COL3_LeavingReason As Integer = 12        ' Lý do thôi việc
    Private Const COL3_Reference As Integer = 13            ' Thông tin liên hệ
    Private Const COL3_ExperienceNote As Integer = 14       ' Ghi chú
    Private Const COL3_BatchID As Integer = 15              ' BatchID
    Private Const COL3_ExperienceID As Integer = 16         ' ExperienceID
    Private Const COL3_ExperienceWorkID As Integer = 17     ' ExperienceWorkID
#End Region

#Region "Const of tdbg4"
    Private Const COL4_EducationDescription As Integer = 0 ' Diễn giải
    Private Const COL4_Certificates As Integer = 1         ' Văn bằng
    Private Const COL4_SchoolID As Integer = 2             ' Trường học
    Private Const COL4_MajorID As Integer = 3              ' Ngành học
    Private Const COL4_EducationDateStarted As Integer = 4 ' Bắt đầu
    Private Const COL4_EducationDateEnded As Integer = 5   ' Kết thúc
    Private Const COL4_EducationFormID As Integer = 6      ' Loại hình đào tạo
    Private Const COL4_BatchID As Integer = 7               ' BatchID
    Private Const COL4_TransEducationID As Integer = 8     ' TransEducationID
#End Region

#Region "Const of tdbg5"
    Private Const COL5_LanguageDescription As Integer = 0 ' Diễn giải
    Private Const COL5_LanguageID As Integer = 1          ' Ngoại ngữ
    Private Const COL5_LanguageLevelID As Integer = 2     ' Cấp độ
    Private Const COL5_Listenning As Integer = 3          ' Nghe
    Private Const COL5_Speaking As Integer = 4            ' Nói
    Private Const COL5_Reading As Integer = 5             ' Đọc
    Private Const COL5_Writing As Integer = 6             ' Viết
    Private Const COL5_BatchID As Integer = 7               ' BatchID
    Private Const COL5_TransLanguageID As Integer = 8     ' TransLanguageID
#End Region

#Region "Const of tdbg6"
    Private Const COL6_ComputingDescription As Integer = 0  ' Diễn giải
    Private Const COL6_ComputingCertificates As Integer = 1 ' Văn bằng
    Private Const COL6_ComputingLevelID As Integer = 2      ' Cấp độ
    Private Const COL6_ComputingSchoolID As Integer = 3     ' Trường học
    Private Const COL6_BatchID As Integer = 4               ' BatchID
#End Region

#Region "Const of C1TrueDBGrid1 - Total of Columns: 6"
    Private Const COL7_OrderNum As Integer = 0               ' STT
    Private Const COL7_DocTypeID As String = "DocTypeID"     ' DocTypeID
    Private Const COL7_DocTypeName As String = "DocTypeName" ' Tên loại giấy tờ
    Private Const COL7_IsSubmit As String = "IsSubmit"       ' Đã nộp
    Private Const COL7_DocNotes As String = "DocNotes"       ' Ghi chú
    Private Const COL7_UpdateDate As String = "UpdateDate"   ' Ngày cập nhật
#End Region

    Private _candidateID As String = ""
    Public Property candidateID() As String
        Get
            Return _candidateID
        End Get
        Set(ByVal value As String)
            _candidateID = value
        End Set
    End Property

    Private _autoCandidateID As Integer = 0
    Public WriteOnly Property AutoCandidateID() As Integer
        Set(ByVal Value As Integer)
            _autoCandidateID = Value
        End Set
    End Property

    Private _isMode As Integer = 0
    Public WriteOnly Property IsMode() As Integer
        Set(ByVal Value As Integer)
            _isMode = Value
        End Set
    End Property

    Private _transTypeID As String = ""
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Private _moduleID As String = "25"
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

#Region "Khai bao cac bien toan cuc"
    Private dtGrid, dtGrid1, dtGridDetail2, dtGridDetail3, dtGridDetail4, dtGridDetail5, dtGridDetail6, dtGridDetail7 As DataTable
    Dim iMaxSave As Integer = 0
    Private dtCandidateID As DataTable

#End Region

    Private Sub D25F1056_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F1056_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
        ' Dim dtTemp As DataTable = CType(tdbg6.DataSource, DataTable)
        If e.Alt Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab1
                Application.DoEvents()
                tdbg2.Focus()
                tdbg2.SplitIndex = SPLIT0
                tdbg2.Col = COL2_RelationID
            ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab2
                Application.DoEvents()
                tdbg3.Focus()
                tdbg3.SplitIndex = SPLIT0
                tdbg3.Col = COL3_ExperienceDateStarted
            ElseIf e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab3
                Application.DoEvents()
                tdbg4.Focus()
                tdbg4.SplitIndex = SPLIT0
                tdbg4.Col = COL4_EducationDescription
            ElseIf e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab4
                Application.DoEvents()
                tdbg5.Focus()
                tdbg5.SplitIndex = SPLIT0
                tdbg5.Col = COL5_LanguageDescription
            ElseIf e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab5
                Application.DoEvents()
                tdbg6.Focus()
                tdbg6.SplitIndex = SPLIT0
                tdbg6.Col = COL6_ComputingDescription
            ElseIf e.KeyCode = Keys.D6 Or e.KeyCode = Keys.NumPad6 Then
                Application.DoEvents()
                tabPage.SelectedTab = Tab6
                Application.DoEvents()
                tdbg7.Focus()
                tdbg7.SplitIndex = SPLIT0
                tdbg7.Col = IndexOfColumn(tdbg7, COL7_IsSubmit)
            End If
        End If
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Dim clsCheckValid As Lemon3.Controls.CheckEmptyGrid
    Private Sub D25F1056_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)

        ResetSplitDividerSize(tdbg, tdbg2, tdbg3, tdbg4, tdbg5, tdbg6)
        ResetFooterGrid(tdbg, tdbg2, tdbg3, tdbg4, tdbg5, tdbg6, tdbg7)

        InputDateInTrueDBGrid(tdbg2, COL2_EffectDate)
        InputDateInTrueDBGrid(tdbg3, COL3_ExperienceDateStarted, COL3_ExperienceDateEnd)
        InputDateInTrueDBGrid(tdbg4, COL4_EducationDateStarted, COL4_EducationDateEnded)
        InputDateInTrueDBGrid(tdbg, COL_IDCardDate)
        InputDateInTrueDBGrid(tdbg7, COL7_UpdateDate)
        '**************************
        tdbg.Columns(COL_DayBD).Editor = c1dateDBirthDate
        tdbg.Columns(COL_MonthBD).Editor = c1dateMBirthDate
        tdbg.Columns(COL_YearBD).Editor = c1dateYBirthDate

        tdbg2.Columns(COL2_DayBD).Editor = c1dateDBirthDate
        tdbg2.Columns(COL2_MonthBD).Editor = c1dateMBirthDate
        tdbg2.Columns(COL2_YearBD).Editor = c1dateYBirthDate
        '**************************
        LoadTDBCombo()
        LoadTDBDropDown()
        tdbg2_NumberFormat()
        tdbg3_NumberFormat()
        tdbg7_LockedColumns()
        LoadTableCaption()
        tdbcMethodID.ReadOnly = (_autoCandidateID = 0)
        tdbcMethodID.TabStop = Not tdbcMethodID.ReadOnly
        If _autoCandidateID = 0 Then
            tdbg.Splits(0).DisplayColumns(COL_CandidateID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        Else
            tdbg.Splits(0).DisplayColumns(COL_CandidateID).Locked = True
            tdbg.Splits(0).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(0).DisplayColumns(COL_CandidateID).AllowFocus = False
        End If
        SetBackColorObligatory()
        LoadLanguage()
        LoadDataGrid()
        clsCheckValid = New Lemon3.Controls.CheckEmptyGrid(tdbg, Me.Name)
        CallD99U1111()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

        Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_CandidateID, COL_LastName, COL_FirstName}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        '*********************
        For i As Integer = 0 To dtF12.Rows.Count - 1
            dtF12.Rows(i).Item("Description") = dtF12.Rows(i).Item("Description").ToString.Replace(vbCrLf, " ")
        Next
        '*********************
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        'Me.Text = rL3("Cap_nhat_thong_tin_ung_cua_vien_-_D25F1056") & UnicodeCaption(gbUnicode) 'CËp nhËt th¤ng tin ÷ng cïa vi£n - D25F1056
        Me.Text = rL3("Cap_nhat_thong_tin_ung_cu_vien") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'CËp nhËt th¤ng tin ÷ng cïa vi£n - D25F1056

        '================================================================ 
        lblMethodID.Text = rL3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSave.Text = rL3("_Luu") '&Lưu
        btnNext.Text = rL3("Luu_va_Nhap__tiep") 'Lưu && Nhập &tiếp
        btnF12.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkIsDetail.Text = rL3("Nhap_thong_tin_chi_tiet") 'Nhập thông tin chi tiết
        chkIsAttach.Text = rL3("Dinh_kem")
        '================================================================ 
        Tab1.Text = "1. " & rL3("Quan_he_gia_dinh") 'Quan hệ gia đình
        Tab2.Text = "2. " & rL3("Kinh_nghiem_lam_viec") 'Kinh nghiệm làm việc
        Tab3.Text = "3. " & rL3("Qua_trinh_hoc_tap") 'Quá trình học tập
        Tab4.Text = "4. " & rL3("Trinh_do_ngoai_ngu") 'Trình độ ngoại ngữ
        Tab5.Text = "5. " & rL3("Trinh_do_tin_hoc") 'Trình độ tin học
        Tab6.Text = "6. " & rL3("Giay_to_tuy_than_") 'Giấy tờ tùy thân
        '================================================================ 
        tdbcMethodID.Columns("MethodID").Caption = rL3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdRelationSex.Columns("Sex").Caption = rL3("Ma") 'Mã
        tdbdRelationSex.Columns("SexName").Caption = rL3("Ten") 'Tên
        tdbdAlive.Columns("Alive").Caption = rL3("Ma") 'Mã
        tdbdAlive.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdRealtionWorkID.Columns("RelationWorkID").Caption = rL3("Ma") 'Mã
        tdbdRealtionWorkID.Columns("RelationWorkName").Caption = rL3("Ten") 'Tên
        tdbdEducationLevelID.Columns("EducationLevelID").Caption = rL3("Ma") 'Mã
        tdbdEducationLevelID.Columns("EducationLevelName").Caption = rL3("Ten") 'Tên
        tdbdRelationID.Columns("RelationID").Caption = rL3("Ma") 'Mã
        tdbdRelationID.Columns("RelationName").Caption = rL3("Ten") 'Tên
        tdbdExperienceWorkID.Columns("RelationWorkID").Caption = rL3("Ma") 'Mã
        tdbdExperienceWorkID.Columns("RelationWorkName").Caption = rL3("Ten") 'Tên
        tdbdCountryID.Columns("NationalityID").Caption = rL3("Ma") 'Mã
        tdbdCountryID.Columns("CountryName").Caption = rL3("Ten") 'Tên
        tdbdCurrencyID.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbdDutyID.Columns("DutyID").Caption = rL3("Ma") 'Mã
        tdbdDutyID.Columns("DutyName").Caption = rL3("Ten") 'Tên
        tdbdEducationFormID.Columns("EducationFormID").Caption = rL3("Ma") 'Mã
        tdbdEducationFormID.Columns("EducationFormName").Caption = rL3("Ten") 'Tên
        tdbdMajorID.Columns("MajorID").Caption = rL3("Ma") 'Mã
        tdbdMajorID.Columns("MajorName").Caption = rL3("Ten") 'Tên
        tdbdSchoolID.Columns("SchoolID").Caption = rL3("Ma") 'Mã
        tdbdSchoolID.Columns("SchoolName").Caption = rL3("Ten") 'Tên
        tdbdWriting.Columns("LookupID").Caption = rL3("Ma") 'Mã
        tdbdWriting.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbdReading.Columns("LookupID").Caption = rL3("Ma") 'Mã
        tdbdReading.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbdSpeaking.Columns("LookupID").Caption = rL3("Ma") 'Mã
        tdbdSpeaking.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbdListenning.Columns("LookupID").Caption = rL3("Ma") 'Mã
        tdbdListenning.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbdLanguageLevelID.Columns("LanguageLevelID").Caption = rL3("Ma") 'Mã
        tdbdLanguageLevelID.Columns("LanguageLevelName").Caption = rL3("Ten") 'Tên
        tdbdLanguageID.Columns("LanguageID").Caption = rL3("Ma") 'Mã
        tdbdLanguageID.Columns("LanguageName").Caption = rL3("Ten") 'Tên
        tdbdComputingSchoolID.Columns("SchoolID").Caption = rL3("Ma") 'Mã
        tdbdComputingSchoolID.Columns("SchoolName").Caption = rL3("Ten") 'Tên
        tdbdComputingLevelID.Columns("LookupID").Caption = rL3("Ma") 'Mã
        tdbdComputingLevelID.Columns("Description").Caption = rL3("Ten") 'Tên
        tdbdSex.Columns("Sex").Caption = rL3("Ma") 'Mã
        tdbdSex.Columns("SexName").Caption = rL3("Ten") 'Tên
        tdbdEthnicID.Columns("EthnicID").Caption = rL3("Ma") 'Mã
        tdbdEthnicID.Columns("EthnicName").Caption = rL3("Ten") 'Tên
        tdbdReligionID.Columns("ReligionID").Caption = rL3("Ma") 'Mã
        tdbdReligionID.Columns("ReligionName").Caption = rL3("Ten") 'Tên
        tdbdNationalityID.Columns("NationalityID").Caption = rL3("Ma") 'Mã
        tdbdNationalityID.Columns("CountryName").Caption = rL3("Ten") 'Tên
        tdbdIDCardPlaceID.Columns("IDCardPlaceID").Caption = rL3("Ma") 'Mã
        tdbdIDCardPlaceID.Columns("ZoneName").Caption = rL3("Ten") 'Tên
        tdbdBPPLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBPPLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdBirthPlaceProvinceID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBirthPlaceProvinceID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdBPDLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBPDLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdBirthPlaceDistrictID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBirthPlaceDistrictID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdBPWLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBPWLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdBirthPlaceWardID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdBirthPlaceWardID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdCAPLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdCAPLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdConAddressProvinceID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressProvinceID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdCADLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdCADLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdConAddressDistrictID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressDistrictID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdCAWLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdCAWLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdConAddressWardID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressWardID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdRAPLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdRAPLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdResAddressProvinceID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdResAddressProvinceID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdRADLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdRADLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdResAddressDistrictID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdResAddressDistrictID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdRAWLabelID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdRAWLabelID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdResAddressWardID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdResAddressWardID.Columns("Name").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rL3("Chon")
        tdbg.Columns("CandidateID").Caption = rL3("Ma") 'Mã
        tdbg.Columns("LastName").Caption = rL3("Ho") 'Họ
        tdbg.Columns("MiddleName").Caption = rL3("Ten_lot") 'Tên lót
        tdbg.Columns("FirstName").Caption = rL3("Ten") 'Tên
        tdbg.Columns("Sex").Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns("EthnicID").Caption = rL3("Dan_toc") 'Dân tộc
        tdbg.Columns("ReligionID").Caption = rL3("Ton_giao") 'Tôn giáo
        tdbg.Columns("NationalityID").Caption = rL3("Quoc_tich") 'Quốc tịch
        tdbg.Columns("IDCardNo").Caption = rL3("So_CMND") 'Số CMND
        tdbg.Columns("IDCardDate").Caption = rL3("Ngay_cap") 'Ngày cấp
        tdbg.Columns("IDCardPlaceID").Caption = rL3("Noi_cap") 'Nơi cấp
        tdbg.Columns("LongBusinesstrip").Caption = rL3("Chap_nhan_di_cong_tac_xa") 'Chấp nhận đi công tác xa
        tdbg.Columns(COL_DayBD).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_MonthBD).Caption = rL3("Thang_sinh") 'Tháng sinh
        tdbg.Columns(COL_YearBD).Caption = rL3("Nam_sinh") 'Năm sinh
        tdbg.Columns(COL_Telephone).Caption = rL3("Dien_thoai") ' Điện thoại
        tdbg.Columns(COL_Mobile).Caption = rL3("Di_dong") ' Di động
        tdbg.Columns(COL_ContactAddress).Caption = rL3("Dia_chi_lien_lac") ' Địa chỉ liên lạc
        tdbg.Columns(COL_BPPLabelName).Caption = rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("NS") & ")" ' Tỉnh / Thành phố (NS)
        tdbg.Columns(COL_BirthPlaceProvinceName).Caption = rL3("CT") & Space(1) & rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("NS") & ")" ' CT Tỉnh/ Thành phố (NS)
        tdbg.Columns(COL_BPDLabelName).Caption = rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("NS") & ")" ' Quận / Huyện (NS)
        tdbg.Columns(COL_BirthPlaceDistrictName).Caption = rL3("CT") & Space(1) & rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("NS") & ")" ' CT Quận / Huyện (NS)
        tdbg.Columns(COL_BPWLabelName).Caption = rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("NS") & ")" ' Phường / Xã (NS)
        tdbg.Columns(COL_BirthPlaceWardName).Caption = rL3("CT") & Space(1) & rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("NS") & ")"    ' CT Phường / Xã (NS)
        tdbg.Columns(COL_ConAddressStreet).Caption = rL3("So_nha") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' Số nhà (Thường trú)
        tdbg.Columns(COL_CAPLabelName).Caption = rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' Tỉnh / Thành phố (Thường trú)
        tdbg.Columns(COL_ConAddressProvinceName).Caption = rL3("CT") & Space(1) & rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' CT Tỉnh / Thành phố (Thường trú)
        tdbg.Columns(COL_CADLabelName).Caption = rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' Quận / Huyện (Thường trú)
        tdbg.Columns(COL_ConAddressDistrictName).Caption = rL3("CT") & Space(1) & rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' CT Quận / Huyện (Thường trú)
        tdbg.Columns(COL_CAWLabelName).Caption = rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' Phường / Xã (Thường trú)
        tdbg.Columns(COL_ConAddressWardName).Caption = rL3("CT") & Space(1) & rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("Thuong_tru") & ")" ' CT Phường / Xã (Thường trú)
        tdbg.Columns(COL_ResAddressStreet).Caption = rL3("So_nha") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' Số nhà (Tạm trú)
        tdbg.Columns(COL_RAPLabelName).Caption = rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' Tỉnh / Thành phố (Tạm trú)
        tdbg.Columns(COL_ResAddressProvinceName).Caption = rL3("CT") & Space(1) & rL3("TinhU") & " / " & rL3("Thanh_pho") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' CT Tỉnh / Thành phố (Tạm trú)
        tdbg.Columns(COL_RADLabelName).Caption = rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' Quận / Huyện (Tạm trú)
        tdbg.Columns(COL_ResAddressDistrictName).Caption = rL3("CT") & Space(1) & rL3("Quan") & " / " & rL3("Huyen") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' CT Quận / Huyện (Tạm trú)
        tdbg.Columns(COL_RAWLabelName).Caption = rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("Tam_tru") & ")" ' Phường / Xã (Tạm trú)
        tdbg.Columns(COL_ResAddressWardName).Caption = rL3("CT") & Space(1) & rL3("Phuong") & " / " & rL3("Xa") & vbCrLf & "(" & rL3("Tam_tru") & ")"  ' CT Phường / Xã (Tạm trú)
        '================================================================ 
        tdbg2.Columns("RelationName").Caption = rL3("Quan_he") 'Quan hệ
        tdbg2.Columns("RelativeName").Caption = rL3("Ten_nguoi_quan_he") 'Tên người quan hệ
        tdbg2.Columns("RelationSex").Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg2.Columns("DayBD").Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg2.Columns("MonthBD").Caption = rL3("Thang_sinh") 'Tháng sinh
        tdbg2.Columns("YearBD").Caption = rL3("Nam_sinh") 'Năm sinh
        tdbg2.Columns("RelationBirthPlace").Caption = rL3("Noi_sinh") 'Nơi sinh
        tdbg2.Columns("RelationAddress").Caption = rL3("Dia_chi") 'Địa chỉ
        tdbg2.Columns("IDCardNo").Caption = rL3("So_CMND") 'Số CMND
        tdbg2.Columns("RelationWorkName").Caption = rL3("Cong_viec_dang_lam") 'Công việc đang làm
        tdbg2.Columns("EducationLevelName").Caption = rL3("Trinh_do_van_hoa_U") 'Trình độ văn hóa
        tdbg2.Columns("IncomeTaxCode").Caption = rL3("Ma_so_thue") 'Mã số thuế
        tdbg2.Columns("Salary").Caption = rL3("Thu_nhap") 'Thu nhập
        tdbg2.Columns("Alive").Caption = rL3("Tinh_trang_hien_tai") 'Tình trạng hiện tại
        tdbg2.Columns("RelationNote").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg2.Columns("EffectDate").Caption = rL3("Ngay_hieu_luc") 'Ngày hiệu lực
        '================================================================  
        tdbg3.Columns("ExperienceDateStarted").Caption = rL3("Bat_dau") 'Bắt đầu
        tdbg3.Columns("ExperienceDateEnd").Caption = rL3("Ket_thuc") 'Kết thúc
        tdbg3.Columns("CompanyName").Caption = rL3("Ten_cong_ty") 'Tên công ty
        tdbg3.Columns("CountryID").Caption = rL3("Quoc_gia") 'Quốc gia
        tdbg3.Columns("ExperienceAddress").Caption = rL3("Dia_chi") 'Địa chỉ
        tdbg3.Columns("DutyID").Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg3.Columns("ExperienceWorkName").Caption = rL3("Cong_viec") 'Công việc
        tdbg3.Columns("BaseSalary").Caption = rL3("Muc_luong") 'Mức lương
        tdbg3.Columns("Allowance").Caption = rL3("Phu_cap") 'Phụ cấp
        tdbg3.Columns("CurrencyID").Caption = rL3("Loai_tien") 'Loại tiền
        tdbg3.Columns("ColleagueQuan").Caption = rL3("So_luong_NV_cung_bo_phan") 'SL NV cùng bộ phận
        tdbg3.Columns("SubordinateQuan").Caption = rL3("So_luong_NV_duoi_quyen") 'SL NV dưới quyền
        tdbg3.Columns("LeavingReason").Caption = rL3("Ly_do_thoi_viec") 'Lý do thôi việc
        tdbg3.Columns("Reference").Caption = rL3("Thong_tin_lien_he") 'Thông tin liên hệ
        tdbg3.Columns("ExperienceNote").Caption = rL3("Ghi_chu") 'Ghi chú
        '================================================================  
        tdbg4.Columns("EducationDescription").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg4.Columns("Certificates").Caption = rL3("Van_bang") 'Văn bằng
        tdbg4.Columns("SchoolID").Caption = rL3("Truong_hoc") 'Trường học
        tdbg4.Columns("MajorID").Caption = rL3("Nganh_hoc") 'Ngành học
        tdbg4.Columns("EducationDateStarted").Caption = rL3("Bat_dau") 'Bắt đầu
        tdbg4.Columns("EducationDateEnded").Caption = rL3("Ket_thuc") 'Kết thúc
        tdbg4.Columns("EducationFormID").Caption = rL3("Loai_hinh_dao_tao") 'Loại hình đào tạo
        '================================================================  
        tdbg5.Columns("LanguageDescription").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg5.Columns("LanguageID").Caption = rL3("Ngoai_ngu") 'Ngoại ngữ
        tdbg5.Columns("LanguageLevelID").Caption = rL3("Cap_do") 'Cấp độ
        tdbg5.Columns("Listenning").Caption = rL3("Nghe") 'Nghe
        tdbg5.Columns("Speaking").Caption = rL3("Noi") 'Nói
        tdbg5.Columns("Reading").Caption = rL3("Doc") 'Đọc
        tdbg5.Columns("Writing").Caption = rL3("Viet") 'Viết
        '================================================================  
        tdbg6.Columns("ComputingDescription").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg6.Columns("ComputingCertificates").Caption = rL3("Van_bang") 'Văn bằng
        tdbg6.Columns("ComputingLevelID").Caption = rL3("Cap_do") 'Cấp độ
        tdbg6.Columns("ComputingSchoolID").Caption = rL3("Truong_hoc") 'Trường học
        '================================================================ 
        tdbg7.Columns(COL7_OrderNum).Caption = rL3("STT") 'STT
        tdbg7.Columns(COL7_DocTypeName).Caption = rL3("Ten_loai_giay_to") 'Tên loại giấy tờ
        tdbg7.Columns(COL7_IsSubmit).Caption = rL3("Da_nop") 'Đã nộp
        tdbg7.Columns(COL7_DocNotes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg7.Columns(COL7_UpdateDate).Caption = rL3("Ngay_cap_nhat") 'Ngày cập nhật
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcMethodID
        sSQL = "-- Combo tao ma tu dong" & vbCrLf
        sSQL &= " SELECT 	MethodID, MethodName" & UnicodeJoin(gbUnicode) & " AS MethodName, IsDefault FROM 		D09T1600  WITH(NOLOCK) "
        sSQL &= " WHERE Disabled = 0 And TypeCode = 50"
        sSQL &= " AND (DivisionID = " & SQLString(gsDivisionID) & " Or DivisionID = '') ORDER BY 	MethodName"
        LoadDataSource(tdbcMethodID, sSQL, gbUnicode)
        Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdSex
        sSQL = "-- Dropdown Gioi tinh" & vbCrLf
        sSQL &= "SELECT  1 AS Sex," & IIf(gbUnicode, SQLStringUnicode("Nữ", gbUnicode, True), SQLString("Nöõ")).ToString & " AS SexName UNION SELECT  0 AS Sex," & IIf(gbUnicode, SQLStringUnicode("Nam", gbUnicode, True), SQLString("Nam")).ToString & " As SexName "
        Dim dtSex As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdSex, dtSex.DefaultView.ToTable, gbUnicode)
        'Load tdbdRelationSex
        LoadDataSource(tdbdRelationSex, dtSex.DefaultView.ToTable, gbUnicode)

        'Load tdbdEthnicID
        sSQL = "-- Dropdown Dan toc " & vbCrLf
        sSQL &= " SELECT 	EthnicID, EthnicName" & UnicodeJoin(gbUnicode) & " As EthnicName  FROM	D09T0203 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	EthnicName"
        LoadDataSource(tdbdEthnicID, sSQL, gbUnicode)
        'Load tdbdReligionID
        sSQL = "-- Dropdown Ton giao" & vbCrLf
        sSQL &= "SELECT 	ReligionID, ReligionName" & UnicodeJoin(gbUnicode) & " As ReligionName FROM D09T0204 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	ReligionName"
        LoadDataSource(tdbdReligionID, sSQL, gbUnicode)
        'Load tdbdIDCardPlaceID
        sSQL = "--Dropdown Noi cap CMND" & vbCrLf
        sSQL &= "SELECT ZoneCode As IDCardPlaceID, ZoneName" & UnicodeJoin(gbUnicode) & " As ZoneName FROM   D91T1620 WITH(NOLOCK) "
        sSQL &= " WHERE  ZoneLevelID = 'TINH/THANH' AND Disabled = 0 ORDER BY   	ZoneName"
        LoadDataSource(tdbdIDCardPlaceID, sSQL, gbUnicode)

        'Load tdbdNationalityID
        sSQL = "-- Dropdown Quoc tich " & vbCrLf
        sSQL &= " SELECT CountryID As NationalityID, CountryName" & UnicodeJoin(gbUnicode) & " As CountryName "
        sSQL &= " FROM 	D91T0017 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	CountryName"
        Dim dtCountryID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdNationalityID, dtCountryID.DefaultView.ToTable, gbUnicode)
        'Load tdbdCountryID
        LoadDataSource(tdbdCountryID, dtCountryID.DefaultView.ToTable, gbUnicode)


        'Load tdbdRelationID
        sSQL = "-- Dropdown Quan he" & vbCrLf
        sSQL &= " SELECT " & NewCode & " AS RelationID, " & NewName & " AS  RelationName, 0 AS DisplayOrder "
        sSQL &= " UNION SELECT 	RelationID, RelationName" & UnicodeJoin(gbUnicode) & " AS RelationName, 1 AS DisplayOrder"
        sSQL &= " FROM 	D09T0240 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	DisplayOrder, RelationName "
        tdbdRelationID.Tag = sSQL
        LoadDataSource(tdbdRelationID, sSQL, gbUnicode)

        'Load tdbdRealtionWorkID
        sSQL = "-- Dropdown Cong viec dang lam" & vbCrLf
        sSQL &= " SELECT  '+' as RelationWorkID, " & NewName & " AS  RelationWorkName, 0 AS DisplayOrder  UNION "
        sSQL &= " SELECT WorkID as RelationWorkID, WorkName" & UnicodeJoin(gbUnicode) & " As  RelationWorkName, 1 As DisplayOrder  FROM 	D09T0224  WITH(NOLOCK)  WHERE 	Disabled = 0  ORDER BY 	DisplayOrder, RelationWorkName"
        Dim dtWorkID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdRealtionWorkID, dtWorkID.DefaultView.ToTable, gbUnicode)
        'Load tdbdExperienceWorkID
        LoadDataSource(tdbdExperienceWorkID, dtWorkID.DefaultView.ToTable, gbUnicode)

        'Load tdbdEducationLevelID
        sSQL = "-- Dropdown Trinh do van hoa" & vbCrLf
        sSQL &= " SELECT '+' as EducationLevelID, " & NewName & " AS  EducationLevelName, 0 AS DisplayOrder "
        sSQL &= " UNION  SELECT EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " AS EducationLevelName, 1 AS DisplayOrder"
        sSQL &= " FROM 	D09T0206 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	DisplayOrder, EducationLevelName "
        LoadDataSource(tdbdEducationLevelID, sSQL, gbUnicode)
        'Load tdbdAlive
        sSQL = "-- Dropdown Tinh trang hien tai" & vbCrLf
        sSQL &= "SELECT    '1' as Alive," & IIf(gbUnicode, SQLStringUnicode("Đã mất", gbUnicode, True), SQLString("Ñaõ maát")).ToString & " as Name UNION SELECT    '0' as Alive, " & IIf(gbUnicode, SQLStringUnicode("Còn sống", gbUnicode, True), SQLString("Coøn soáng")).ToString & " as Name"
        LoadDataSource(tdbdAlive, sSQL, gbUnicode)

        'Load tdbdDutyID
        sSQL = "-- Dropdown Chuc vu" & vbCrLf
        sSQL &= " SELECT	DutyID, DutyName" & UnicodeJoin(gbUnicode) & " AS DutyName FROM D09T0211 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DutyName "
        LoadDataSource(tdbdDutyID, sSQL, gbUnicode)

        'Load tdbdCurrencyID
        LoadCurrencyID(tdbdCurrencyID, gbUnicode)
        'Load tdbdSchoolID
        sSQL = "-- Dropdown Truong hoc" & vbCrLf
        sSQL &= " SELECT	SchoolID, SchoolName" & UnicodeJoin(gbUnicode) & " AS SchoolName FROM D09T0213 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY SchoolName "
        Dim dtSchoolID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdSchoolID, dtSchoolID.DefaultView.ToTable, gbUnicode)
        'load tdbdComputingSchoolID
        LoadDataSource(tdbdComputingSchoolID, dtSchoolID.DefaultView.ToTable, gbUnicode)

        'Load tdbdMajorID
        sSQL = "-- Dropdown Nganh hoc" & vbCrLf
        sSQL &= " SELECT 	MajorID, MajorName" & UnicodeJoin(gbUnicode) & " As MajorName FROM D09T0212 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	MajorName "
        LoadDataSource(tdbdMajorID, sSQL, gbUnicode)
        'Load tdbdEducationFormID
        sSQL = "-- Dropdown Loai hinh dao tao" & vbCrLf
        sSQL &= "SELECT	EducationFormID, EducationFormName" & UnicodeJoin(gbUnicode) & "  As EducationFormName FROM 		D09T0223 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	EducationFormName"
        LoadDataSource(tdbdEducationFormID, sSQL, gbUnicode)
        'Load tdbdLanguageID
        sSQL = "-- Dropdown Ngoai ngu" & vbCrLf
        sSQL &= "SELECT	LanguageID, LanguageName" & UnicodeJoin(gbUnicode) & "  As LanguageName FROM 		D09T0207 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	LanguageName"
        LoadDataSource(tdbdLanguageID, sSQL, gbUnicode)
        'Load tdbdLanguageLevelID
        sSQL = "-- Dropdown Dropdown Cap do ngoai ngu" & vbCrLf
        sSQL &= "SELECT	LanguageLevelID, LanguageLevelName" & UnicodeJoin(gbUnicode) & " As LanguageLevelName FROM 		D09T0208 WITH(NOLOCK) "
        sSQL &= " WHERE	Disabled = 0 ORDER BY 	LanguageLevelName"
        LoadDataSource(tdbdLanguageLevelID, sSQL, gbUnicode)

        sSQL = "-- Dropdown Nghe, noi, doc , viet, cap do tin hoc" & vbCrLf
        sSQL &= "SELECT LookupID, Description" & UnicodeJoin(gbUnicode) & " As Description, LookupType"
        sSQL &= " FROM D91T0320 WITH(NOLOCK)  WHERE 	Disabled = 0 "
        sSQL &= " AND LookupType IN ('D09_AssessType', 'D09_ComputingLevel') AND ( DAGroupID = '' "
        sSQL &= " OR DAGroupID In (	SELECT 	DAGroupID FROM 	LemonSys.DBO.D00V0080 WHERE 	UserID= " & SQLString(gsUserID) & ") "
        sSQL &= " OR " & SQLString(gsUserID) & " ='LEMONADMIN')"
        sSQL &= " ORDER BY 	DisplayOrder, Description"
        Dim dtLookupID As DataTable = ReturnDataTable(sSQL)
        Dim dt As DataTable = ReturnTableFilter(dtLookupID, "LookupType= 'D09_AssessType'", True)

        LoadDataSource(tdbdListenning, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdWriting, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdSpeaking, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdReading, dt.DefaultView.ToTable, gbUnicode)

        LoadDataSource(tdbdComputingLevelID, ReturnTableFilter(dtLookupID, "LookupType= 'D09_ComputingLevel'", True), gbUnicode)
        '****************************
        'ID 81526 11/01/2016
        dtPlace = ReturnDataTable(SQLStoreD09P1509)
        'Load tdbdBPPLabelID,tdbdCAPLabelID,tdbdRAPLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='ProvinceLabel'", True)
        LoadDataSource(tdbdBPPLabelID, dt, gbUnicode)
        LoadDataSource(tdbdCAPLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRAPLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbdBPDLabelID,tdbdCADLabelID,tdbdRADLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='DistrictLabel'", True)
        LoadDataSource(tdbdBPDLabelID, dt, gbUnicode)
        LoadDataSource(tdbdCADLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRADLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbdBPWLabelID,tdbdCAWLabelID,tdbdRAWLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='WardLabel'", True)
        LoadDataSource(tdbdBPWLabelID, dt, gbUnicode)
        LoadDataSource(tdbdCAWLabelID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRAWLabelID, dt.DefaultView.ToTable, gbUnicode)

        'Load tdbdBirthPlaceProvinceID,tdbdConAddressProvinceID,tdbdRAWLabelID
        dt = ReturnTableFilter(dtPlace, "SourceName ='TINH/THANH'", True)
        LoadDataSource(tdbdBirthPlaceProvinceID, dt, gbUnicode)
        LoadDataSource(tdbdConAddressProvinceID, dt.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdResAddressProvinceID, dt.DefaultView.ToTable, gbUnicode)
    End Sub

#Region "ID 81526 11/01/2016"
    Dim dtPlace, dtDistrictID, dtWardID As DataTable
    Private Sub LoadTDBDDistrictID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sProvinceID As String)
        If dtDistrictID Is Nothing Then
            dtDistrictID = ReturnTableFilter(dtPlace, "SourceName ='QUAN/HUYEN'", True)
        End If
        LoadDataSource(tdbd, ReturnTableFilter(dtDistrictID, "ParentID = " & SQLString(sProvinceID), True), gbUnicode)
    End Sub

    Private Sub LoadTDBDWardID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sWardID As String)
        If dtWardID Is Nothing Then
            dtWardID = ReturnTableFilter(dtPlace, "SourceName ='XA/PHUONG'", True)
        End If
        LoadDataSource(tdbd, ReturnTableFilter(dtWardID, "ParentID = " & SQLString(sWardID), True), gbUnicode)
    End Sub

    Private Function GetBirthPlace(iRow As Integer) As String
        Dim sBirthPlace As String = ""
        If tdbg(iRow, COL_BirthPlaceWardName).ToString <> "" Then
            If tdbg(iRow, COL_BPWLabelName).ToString <> "" Then
                sBirthPlace &= tdbg(iRow, COL_BPWLabelName).ToString & Space(1) & tdbg(iRow, COL_BirthPlaceWardName).ToString & ", "
            Else
                sBirthPlace &= tdbg(iRow, COL_BirthPlaceWardName).ToString
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        If tdbg(iRow, COL_BirthPlaceDistrictName).ToString <> "" Then
            If tdbg(iRow, COL_BPDLabelName).ToString <> "" Then
                sBirthPlace &= tdbg(iRow, COL_BPDLabelName).ToString & Space(1) & tdbg(iRow, COL_BirthPlaceDistrictName).ToString & ", "
            Else
                sBirthPlace &= tdbg(iRow, COL_BirthPlaceDistrictName).ToString
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        If tdbg(iRow, COL_BirthPlaceProvinceID).ToString <> "" Then
            If tdbg(iRow, COL_BPPLabelName).ToString <> "" Then
                sBirthPlace &= tdbg(iRow, COL_BPPLabelName).ToString & Space(1) & tdbg(iRow, COL_BirthPlaceProvinceName).ToString & ", "
            Else
                sBirthPlace &= tdbg(iRow, COL_BirthPlaceProvinceName).ToString
                If sBirthPlace <> "" Then sBirthPlace &= ", "
            End If
        End If

        sBirthPlace = L3Left(sBirthPlace, sBirthPlace.Length - 2)
        Return sBirthPlace
    End Function

    Private Function GetAddress(sAddressStreet As String, sAPLabelName As String, sAddressProvinceName As String, _
                                sADLabelName As String, sAddressDistrictName As String, sAWLabelName As String, sAddressWardName As String) As String
        Dim sAddress As String = ""
        sAddress &= IIf(sAddressStreet = "", "", sAddressStreet & ", ").ToString

        If sAddressWardName <> "" Then
            If sAWLabelName <> "" Then
                sAddress &= sAWLabelName & Space(1) & sAddressWardName & ", "
            Else
                sAddress &= sAddressWardName
                If sAddress <> "" Then sAddress &= ", "
            End If
        End If

        If sAddressDistrictName <> "" Then
            If sADLabelName <> "" Then
                sAddress &= sADLabelName & Space(1) & sAddressDistrictName & ", "
            Else
                sAddress &= sAddressDistrictName
                If sAddress <> "" Then sAddress &= ", "
            End If
        End If

        If sAddressProvinceName <> "" Then
            If sAPLabelName <> "" Then
                sAddress &= sAPLabelName & Space(1) & sAddressProvinceName & ", "
            Else
                sAddress &= sAddressProvinceName
                If sAddress <> "" Then sAddress &= ", "
            End If
        End If

        sAddress = L3Left(sAddress, sAddress.Length - 2)
        Return sAddress
    End Function
#End Region

    Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
    Private Sub tdbg2_NumberFormat()
        arrCol = Nothing
        'tdbg2.Columns(COL2_Salary).NumberFormat = D25Format.DefaultNumber2
        AddDecimalColumns(arrCol, tdbg2.Columns(COL2_Salary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        '**********************
        InputNumber(tdbg2, arrCol)
    End Sub

    Private Sub tdbg3_NumberFormat()
        arrCol = Nothing
        AddDecimalColumns(arrCol, tdbg3.Columns(COL3_Allowance).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arrCol, tdbg3.Columns(COL3_BaseSalary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arrCol, tdbg3.Columns(COL3_ColleagueQuan).DataField, DxxFormat.DefaultNumber0, 28, 8)
        AddDecimalColumns(arrCol, tdbg3.Columns(COL3_SubordinateQuan).DataField, DxxFormat.DefaultNumber0, 28, 8)
        '**********************
        InputNumber(tdbg3, arrCol)
    End Sub

    Private Sub tdbg7_LockedColumns()
        tdbg7.Splits(SPLIT0).DisplayColumns(COL7_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg7.Splits(SPLIT0).DisplayColumns(COL7_DocTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

#Region "Load dropdown dong cho luoi 1"


    Dim iSplitWidth As Integer = 0
    '   Dim iLastAddCol As Integer = -1
    Dim dtCol As DataTable
    Dim sExistRecDepartmentID As Boolean = False
    Dim sExistRecTeamID As Boolean = False
    Private Sub LoadTableCaption()
        iSplitWidth = 0
        '========================================================
        dtCol = ReturnDataTable(SQLStoreD25P1057) 'Đổ nguồn table caption cột động
        Dim dtTemp As DataTable = ReturnTableFilter(dtCol, "FieldName='RecDepartmentID'", True)
        If dtTemp.Rows.Count > 0 Then sExistRecDepartmentID = True
        dtTemp = ReturnTableFilter(dtCol, "FieldName='RecTeamID'", True)
        If dtTemp.Rows.Count > 0 Then sExistRecTeamID = True
        'Add cột động vào lưới
        For i As Integer = 0 To dtCol.Rows.Count - 1
            AddColumns(i, dtCol)
        Next
        'Add cot dau tien
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = rL3("Dinh_kem")
        dc.DataField = "Button"
        If IsExist(dc.DataField) Then Exit Sub
        tdbg.Columns.Add(dc)
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).ButtonText = True
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).ButtonAlways = True
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).Width = 40
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    End Sub

    Private Function IsExist(ByVal sDataField As String) As Boolean
        Try
            If tdbg.Columns.IndexOf(tdbg.Columns(sDataField)) = -1 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Dim dtRecDepartmentID, dtRecTeamID As DataTable
    Dim dtDivision As DataTable
    Private Sub AddColumns(ByVal i As Integer, ByVal dtCol As DataTable)
        arrCol = Nothing
        Dim sField As String = dtCol.Rows(i).Item("FieldName").ToString
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        Dim sFieldCaption As String = dtCol.Rows(i).Item("Caption").ToString
        If giReplacResource <> 0 Then    'Update 16/07/2013: Nếu có thay đổi tên resource
            sFieldCaption = ReplaceResourceCustom(sFieldCaption)
        End If
        dc.Caption = sFieldCaption
        dc.DataField = sField
        tdbg.Columns.Insert(tdbg.Columns.Count, dc)
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        If dtCol.Rows(i).Item("SaveType").ToString = "0" Then 'String
            tdbg.Splits(1).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            tdbg.Columns(sField).DataWidth = L3Int(dtCol.Rows(i).Item("Length").ToString)
        ElseIf dtCol.Rows(i).Item("SaveType").ToString = "2" Then 'DateTime
            tdbg.Splits(1).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            InputDateInTrueDBGrid(tdbg, sField)
        Else  'Number
            tdbg.Splits(1).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            '*************************************************
            AddDecimalColumns(arrCol, sField, DxxFormat.DefaultNumber2, 28, 8)
        End If
        tdbg.Columns(sField).Tag = dtCol.Rows(i).Item("SaveType").ToString

        'Format style
        tdbg.Splits(0).DisplayColumns(sField).Visible = False
        tdbg.Splits(0).DisplayColumns(sField).AllowSizing = False
        tdbg.Splits(1).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(1).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
        'tdbg.Splits(1).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
        tdbg.Splits(1).DisplayColumns(sField).Width = L3Int(dtCol.Rows(i).Item("Length").ToString)
        tdbg.Splits(1).DisplayColumns(sField).Visible = True
        tdbg.Splits(1).DisplayColumns(sField).FetchStyle = True
        '*********************
        If dtCol.Rows(i).Item("FieldType").ToString = "Cmb" Then
            Dim sDivisionID As String = gsDivisionID
            Select Case sField
                Case "RecDepartmentID", "RecTeamID"
                    sDivisionID = "%"
            End Select
            Dim sSQL As String = SQLStoreD25P5050(sField, sDivisionID)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If sField = "DivisionID" Then dtDivision = dt
            Dim sColAdd() As String = Nothing
            If dt.Columns.Count > 2 Then
                ReDim sColAdd(dt.Columns.Count - 3) 'Chỉ tạo thêm từ vị trí cột 3
                For col As Integer = 0 To sColAdd.Length - 1
                    If col >= dt.Columns.Count Then Exit For
                    sColAdd(col) = dt.Columns(col + 2).ColumnName
                Next
            End If
            If sField = "ProjectID" And D25Options.ProjectID <> "" Then
                tdbg.Columns(sField).DefaultValue = D25Options.ProjectID
                tdbg.Splits(1).DisplayColumns(sField).Locked = True
                tdbg.Splits(1).DisplayColumns(sField).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                Exit Sub
            End If
            If sField = "DivisionID" Then tdbg.Splits(1).DisplayColumns(sField).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
            '***********************************************
            'Add dropdown tương ứng với từng field thêm mới
            Dim dd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = CreateDropDownID(Me, i.ToString, "Code", "Name", sColAdd)
            tdbg.Columns(sField).DropDown = dd
            dd.Tag = sSQL
            tdbg.Splits(1).DisplayColumns(sField).AutoDropDown = True
            tdbg.Splits(1).DisplayColumns(sField).AutoComplete = False
            '***********************************************
            dt.Columns.Add(sField)
            LoadDataSource(dd, dt, gbUnicode)
            Select Case sField
                Case "RecDepartmentID"
                    dtRecDepartmentID = dt.DefaultView.ToTable
                Case "RecTeamID"
                    dtRecTeamID = dt.DefaultView.ToTable
            End Select
            If sColAdd Is Nothing Then Exit Sub
            For col As Integer = 0 To sColAdd.Length - 1
                dd.DisplayColumns(sColAdd(col)).Visible = False
            Next
        End If
        '******************************
        'Định dạng các cột số trên lưới
        If arrCol IsNot Nothing Then InputNumber(tdbg, arrCol)
    End Sub
#End Region

    Private Sub LoadDataGrid()
        dtGrid = ReturnDataTable(SQLStoreD25P1051)
        dtGridDetail2 = ReturnDataTable(SQLStoreD25P1058)
        dtGridDetail3 = dtGridDetail2.DefaultView.ToTable
        dtGridDetail4 = dtGridDetail2.DefaultView.ToTable
        dtGridDetail5 = dtGridDetail2.DefaultView.ToTable
        dtGridDetail6 = dtGridDetail2.DefaultView.ToTable
        dtGrid1 = dtGrid.DefaultView.ToTable
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)

        LoadDataSource(tdbg2, dtGridDetail2, gbUnicode)
        LoadDataSource(tdbg3, dtGridDetail3, gbUnicode)
        LoadDataSource(tdbg4, dtGridDetail4, gbUnicode)
        LoadDataSource(tdbg5, dtGridDetail5, gbUnicode)
        LoadDataSource(tdbg6, dtGridDetail6, gbUnicode)

        If dsGrid7 IsNot Nothing Then dsGrid7.Clear()
        LoadTDBGrid7(True)
        '**********************
        btnSend.Enabled = False
        tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible = False
        If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()
    End Sub

    'Private Sub LoadTDBGrid7(bLoadFirst As Boolean, Optional sBatchID As String = "") 'ID 93232 17/01/2017
    '    If bLoadFirst Then
    '        Dim sSQL As String = SQLStoreD25P1059()
    '        dtDataGrid7 = ReturnDataTable(sSQL)
    '        dtGridDetail7 = dtDataGrid7.DefaultView.ToTable
    '    Else
    '        Dim dr() As DataRow = dtGrid.Select("BatchID <>''")
    '        If dr.Length = 1 Then 'Lưới chỉ có 1 dòng
    '            For i As Integer = 0 To dtGridDetail7.Rows.Count - 1
    '                dtGridDetail7.Rows(i).Item("BatchID") = sBatchID
    '            Next
    '            dtGridDetail7.AcceptChanges()
    '        Else
    '            dr = dtGridDetail7.Select("BatchID=" & SQLString(sBatchID))
    '            If dr.Length <= 0 Then 'Chưa có BatchID trong dtGridDetail7
    '                Dim dt As DataTable = dtDataGrid7.DefaultView.ToTable
    '                For i As Integer = 0 To dt.Rows.Count - 1
    '                    dt.Rows(i).Item("BatchID") = sBatchID
    '                Next
    '                dt.AcceptChanges()
    '                dtGridDetail7.Merge(dt)
    '            End If
    '        End If
    '    End If

    '    LoadDataSource(tdbg7, dtGridDetail7, gbUnicode)
    '    If dtGridDetail7 IsNot Nothing Then dtGridDetail7.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
    '    FooterTotalGrid(tdbg7, COL7_DocTypeName)
    'End Sub
    Dim dtDataGrid7 As DataTable
    Dim dsGrid7 As New DataSet
    Private Sub LoadTDBGrid7(bLoadFirst As Boolean, Optional sBatchID As String = "", Optional bRowColChange As Boolean = False) 'ID 93232 17/01/2017
        If bLoadFirst Then
            Dim sSQL As String = SQLStoreD25P1059()
            dtGridDetail7 = ReturnDataTable(sSQL)
            dtGridDetail7.TableName = "Original"

            dtDataGrid7 = dtGridDetail7.Copy()
            If dsGrid7 IsNot Nothing Then dsGrid7.Clear()
            dsGrid7 = dtGridDetail7.DataSet
        Else
            If sBatchID <> "" Then 'dsGrid7.Tables.Count = 1 Then
                If bRowColChange = False Then
                    For i As Integer = 0 To dtGridDetail7.Rows.Count - 1
                        dtGridDetail7.Rows(i).Item("BatchID") = sBatchID
                    Next
                    dtGridDetail7.AcceptChanges() 'dsGrid7.Tables(0).AcceptChanges()
                End If
            Else
                If dsGrid7.Tables.Contains(sBatchID) = False And dsGrid7.Tables.Contains("Original") = False Then 'Chưa có BatchID 
                    Dim dt As DataTable = dtDataGrid7.DefaultView.ToTable
                    dsGrid7.Tables.Add(dt)
                End If
            End If

            If sBatchID <> "" Then
                If bRowColChange = False Then dtGridDetail7.TableName = sBatchID
            Else
                sBatchID = "Original"
            End If
            dtGridDetail7 = dsGrid7.Tables(sBatchID)
        End If

        LoadDataSource(tdbg7, dtGridDetail7, gbUnicode)
        FooterTotalGrid(tdbg7, COL7_DocTypeName)
    End Sub

#Region "tdbg7"
    Private Sub tdbg7_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg7.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.Column.DataColumn.DataField
            Case COL7_IsSubmit
                If L3Bool(tdbg7.Columns(e.ColIndex).Value) Then
                    tdbg7.Columns(COL7_UpdateDate).Value = Now.Date
                Else
                    tdbg7.Columns(COL7_UpdateDate).Value = ""
                End If
            Case COL7_UpdateDate
                tdbg7.Select()
        End Select
    End Sub

    Dim bSelect7 As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick7(ByVal iCol As Integer)
        If tdbg7.RowCount <= 0 Then Exit Sub
        Select Case tdbg7.Columns(iCol).DataField
            Case COL7_IsSubmit
                L3HeadClick(tdbg7, iCol, bSelect7)
                For i As Integer = 0 To tdbg7.RowCount - 1
                    If bSelect7 Then
                        tdbg7(i, COL7_UpdateDate) = Now.Date
                    Else
                        tdbg7(i, COL7_UpdateDate) = ""
                    End If
                Next
                tdbg7.UpdateData()
            Case COL7_DocNotes, COL7_UpdateDate
                CopyColumns(tdbg7, iCol, tdbg7.Columns(iCol).Text, tdbg7.Bookmark)
        End Select
    End Sub
    Private Sub tdbg7_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg7.HeadClick
        HeadClick7(e.ColIndex)
    End Sub

    Private Sub tdbg7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg7.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub

    Private Sub tdbg7_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg7.UnboundColumnFetch
        Select Case e.Col
            Case COL7_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub
#End Region

#Region "Cac cau lenh SQL"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1058
    '# Created User: VANVINH
    '# Created Date: 10/01/2013 09:58:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1058() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi cac tab" & vbCrLf)
        sSQL &= "Exec D25P1058 "
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1051
    '# Created User: VANVINH
    '# Created Date: 10/01/2013 09:58:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi 1 va 2" & vbCrLf)
        sSQL &= "Exec D25P1051 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(_isMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1057
    '# Created User: VANVINH
    '# Created Date: 10/01/2013 09:30:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1057() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho cac cot dong man hinh cap nhat ho so ung vien hang loat" & vbCrLf)
        sSQL &= "Exec D25P1057 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_isMode) & COMMA 'IsMode, tinyint, NOT NULL
        sSQL &= SQLString(_transTypeID) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5050
    '# Created User: VANVINH
    '# Created Date: 10/01/2013 09:53:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5050(ByVal sFieldName As String, ByVal DivisionID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho cac dropdown dong " & vbCrLf)
        sSQL &= "Exec D25P5050 "
        sSQL &= SQLStringUnicode(sFieldName, gbUnicode, False) & COMMA 'FieldName, varchar[250], NOT NULL
        sSQL &= SQLString(DivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 04:21:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If i = 0 Then sSQL.Append("-- Luu du lieu vao bang tam" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, ")
            sSQL.Append("Str01, Str02, Str03, Str04, Str05, Str06, Str07, ")
            sSQL.Append("Num01, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_IDCardNo)) & COMMA) 'Key02ID, varchar[250], NOT NULL

            sSQL.Append(SQLString(tdbg(i, COL_LastName)) & COMMA) 'Str01, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_MiddleName)) & COMMA) 'Str02, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_FirstName)) & COMMA) 'Str03, nvarchar[500], NOT NULL
            Dim sResDepartmentID As String = ""
            Dim sPositionID As String = ""
            Dim sMobile As String = ""
            Dim sTelephone As String = ""
            For k As Integer = 0 To tdbg.Columns.Count - 1
                If tdbg.Columns(k).DataField = "RecDepartmentID" Then
                    sResDepartmentID = tdbg(i, k).ToString
                End If
                If tdbg.Columns(k).DataField = "RecPositionID" Then
                    sPositionID = tdbg(i, k).ToString
                End If
                '----------------
                If tdbg.Columns(k).DataField = "Telephone" Then
                    sTelephone = tdbg(i, k).ToString
                End If
                If tdbg.Columns(k).DataField = "Mobile" Then
                    sMobile = tdbg(i, k).ToString
                End If

            Next
            sSQL.Append(SQLString(sResDepartmentID) & COMMA) 'Str04, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(sPositionID) & COMMA) 'Str05, nvarchar[500], NOT NULL

            sSQL.Append(SQLString(sTelephone) & COMMA) 'Str06, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(sMobile) & COMMA) 'Str07, nvarchar[500], NOT NULL

            sSQL.Append(SQLMoney(i + 1) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLString("D25F1056")) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:27:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu bang tam D09T6666" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= "AND FormID = " & SQLString("D25F1056")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:29:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
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
        sSQL &= SQLNumber(_moduleID) 'ModuleID, tinyint, NOT NULL
        Return sSQL
    End Function
    Private Function SQLInsertD25T1041s() As StringBuilder
        Dim sRet As New StringBuilder
        '---------------------------------
        Dim sFieldSave As String = ""

        For k As Integer = 0 To tdbg.Columns.Count - 1
            If tdbg.Splits(1).DisplayColumns(k).Visible Then
                If tdbg.Columns(k).DataField <> "ExperienceYear"  Then  'ID 101294 
                sFieldSave &= ", " & tdbg.Columns(k).DataField
            End If
            End If
        Next
        Dim drInsertU() As DataRow = dtCol.Select("IsUnicode =1")
        For i As Integer = 0 To drInsertU.Length - 1
            sFieldSave &= ", " & drInsertU(i).Item("FieldName").ToString & "U"
        Next
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("-- Luu thong tin ung vien " & (i + 1) & vbCrLf)
            sSQL.Append("Insert Into D25T1041(")
            sSQL.Append(" CandidateID, Disabled, LastName, LastNameU, ") 'DivisionID,
            sSQL.Append("MiddleName, MiddleNameU, FirstName,FirstNameU, CandidateName, ")
            sSQL.Append("CandidateNameU, Sex, BirthDate, UndefinedBD, ")
            sSQL.Append("EthnicID, ReligionID, NationalityID, IDCardNo, ")
            sSQL.Append("IDCardDate, IDCardPlaceID, IDCardPlace, IDCardPlaceU, ")

            sSQL.Append("Mobile, Telephone, Fax, Email, ContactAddress, ContactAddressU, BirthPlace, BirthPlaceU, BirthPlaceProvinceID, BirthPlaceDistrictID, BirthPlaceWardID, BPPLabelID, BPDLabelID, BPWLabelID, ")
            sSQL.Append("ConAddressProvinceID, ConAddressWardID, ConAddressDistrictID, CAWLabelID, CADLabelID, CAPLabelID, ConAddressStreetU, PermanentAddress, PermanentAddressU, ")
            sSQL.Append("ResAddressWardID, ResAddressDistrictID, ResAddressProvinceID, RAWLabelID, RADLabelID, RAPLabelID, ResAddressStreetU, ProvisionalAddress, ProvisionalAddressU, ")

            sSQL.Append("LongBusinesstrip, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate ")
            sSQL.Append(sFieldSave)
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA)
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, False) & COMMA) 'LastName, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, True) & COMMA) 'LastNameU, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_MiddleName), gbUnicode, False) & COMMA) 'MiddleName, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_MiddleName), gbUnicode, True) & COMMA) 'MiddleNameU, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, False) & COMMA) 'FirstName, varchar[30], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, True) & COMMA) 'FirstNameU, varchar[30], NOT NULL
            '******************************
            If tdbg(i, COL_MiddleName).ToString <> "" Then 'ID 84207 26/01/2016
                sSQL.Append("isnull(" & SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_MiddleName), gbUnicode, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
                sSQL.Append("isnull(" & SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_MiddleName), gbUnicode, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, True) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            Else
                sSQL.Append("isnull(" & SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
                sSQL.Append("isnull(" & SQLStringUnicode(tdbg(i, COL_LastName), gbUnicode, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(tdbg(i, COL_FirstName), gbUnicode, True) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            End If
            '******************************
            sSQL.Append(SQLNumber(tdbg(i, COL_Sex)) & COMMA) 'Sex, tinyint, NULL
            'ID 82099 24/12/2015
            Dim iUndefinedBD As Byte = L3Byte(tdbg(i, COL_UndefinedBD))
            If iUndefinedBD = 3 Then 'Không nhập ngày,tháng, năm
                sSQL.Append(SQLDateSave("") & COMMA) 'BirthDate, datetime, NULL
            Else
                Dim sBirthDate As String = ReturnBirthDate(iUndefinedBD, tdbg(i, COL_DayBD).ToString, tdbg(i, COL_MonthBD).ToString, tdbg(i, COL_YearBD).ToString)
                sSQL.Append(SQLDateSave(sBirthDate) & COMMA) 'BirthDate, datetime, NULL
            End If
            sSQL.Append(SQLNumber(iUndefinedBD) & COMMA) 'UndefinedBirthDate, tinyint, NOT NULL
            '************************
            sSQL.Append(SQLString(tdbg(i, COL_EthnicID)) & COMMA) 'EthnicID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_ReligionID)) & COMMA) 'ReligionID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_NationalityID)) & COMMA) 'NationalityID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_IDCardNo)) & COMMA) 'IDCardNo, varchar[20], NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_IDCardDate)) & COMMA) 'IDCardDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_IDCardPlaceID)) & COMMA) 'IDCardPlaceID, varchar[20], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'IDCardPlace, varchar[20], NOT NULL
            sSQL.Append("N" & SQLString("") & COMMA) 'IDCardPlaceU, varchar[20], NOT NULL
            '************************
            'ID 81526 11/01/2016
            sSQL.Append(SQLString(tdbg(i, COL_Mobile)) & COMMA) 'Mobile, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Telephone)) & COMMA) 'Telephone, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Fax)) & COMMA) 'Fax, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Email)) & COMMA) 'Email, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ContactAddress), gbUnicode, False) & COMMA) 'ContactAddress, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ContactAddress), gbUnicode, True) & COMMA) 'ContactAddressU, nvarchar[1000], NOT NULL

            Dim sBirthPlace As String = GetBirthPlace(i)
            sSQL.Append(SQLStringUnicode(sBirthPlace, gbUnicode, False) & COMMA) 'BirthPlace, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(sBirthPlace, gbUnicode, True) & COMMA) 'BirthPlaceU, varchar[250], NULL
            sSQL.Append(SQLString(tdbg(i, COL_BirthPlaceProvinceID)) & COMMA) 'BirthPlaceProvinceID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BirthPlaceDistrictID)) & COMMA) 'BirthPlaceDistrictID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BirthPlaceWardID)) & COMMA) 'BirthPlaceWardID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BPPLabelID)) & COMMA) 'BPPLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BPDLabelID)) & COMMA) 'BPDLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BPWLabelID)) & COMMA) 'BPWLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ConAddressProvinceID)) & COMMA) 'ConAddressProvinceID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ConAddressWardID)) & COMMA) 'ConAddressWardID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ConAddressDistrictID)) & COMMA) 'ConAddressDistrictID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CAWLabelID)) & COMMA) 'CAWLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CADLabelID)) & COMMA) 'CADLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CAPLabelID)) & COMMA) 'CAPLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ConAddressStreet), gbUnicode, True) & COMMA) 'ConAddressStreetU, nvarchar[1000], NOT NULL
            '-----------------------------
            Dim sAddress As String = GetAddress(tdbg(i, COL_ConAddressStreet).ToString, tdbg(i, COL_CAPLabelName).ToString, tdbg(i, COL_ConAddressProvinceName).ToString, _
                                    tdbg(i, COL_CADLabelName).ToString, tdbg(i, COL_ConAddressDistrictName).ToString, tdbg(i, COL_CAWLabelName).ToString, tdbg(i, COL_ConAddressWardName).ToString)
            sSQL.Append(SQLStringUnicode(sAddress, gbUnicode, True) & COMMA) 'PermanentAddress, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(sAddress, gbUnicode, True) & COMMA) 'PermanentAddressU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ResAddressWardID)) & COMMA) 'ResAddressWardID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ResAddressDistrictID)) & COMMA) 'ResAddressDistrictID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ResAddressProvinceID)) & COMMA) 'ResAddressProvinceID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RAWLabelID)) & COMMA) 'RAWLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RADLabelID)) & COMMA) 'RADLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RAPLabelID)) & COMMA) 'RAPLabelID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ResAddressStreet), gbUnicode, True) & COMMA) 'ResAddressStreetU, nvarchar[1000], NOT NULL
            '-----------------------------
            sAddress = GetAddress(tdbg(i, COL_ResAddressStreet).ToString, tdbg(i, COL_RAPLabelName).ToString, tdbg(i, COL_ResAddressProvinceName).ToString, _
                        tdbg(i, COL_RADLabelName).ToString, tdbg(i, COL_ResAddressDistrictName).ToString, tdbg(i, COL_RAWLabelName).ToString, tdbg(i, COL_ResAddressWardName).ToString)
            sSQL.Append(SQLStringUnicode(sAddress, gbUnicode, True) & COMMA) 'ProvisionalAddress, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(sAddress, gbUnicode, True) & COMMA) 'ProvisionalAddressU, nvarchar[1000], NOT NULL
            '************************
            sSQL.Append(SQLString(tdbg(i, COL_LongBusinesstrip)) & COMMA) 'LongBusinesstrip, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            '----------------------------
            For k As Integer = 0 To tdbg.Columns.Count - 1
                If tdbg.Splits(1).DisplayColumns(k).Visible Then
                    If tdbg.Columns(k).DataField <> "ExperienceYear"  Then  'ID 101294 
                    If tdbg.Columns(k).Tag.ToString = "0" Then
                        sSQL.Append(COMMA & SQLStringUnicode(tdbg(i, k), gbUnicode, False))
                    ElseIf tdbg.Columns(k).Tag.ToString = "1" Then
                        sSQL.Append(COMMA & SQLMoney(tdbg(i, k), tdbg.Columns(k).NumberFormat))
                    Else
                        sSQL.Append(COMMA & SQLDateSave(tdbg(i, k)))
                    End If
                End If
                End If
            Next
            For k As Integer = 0 To drInsertU.Length - 1
                sSQL.Append(COMMA & SQLStringUnicode(tdbg(i, drInsertU(k).Item("FieldName").ToString), gbUnicode, True))
            Next
            '-------------------------------
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            'Lưu du lieu tren cac tab theo BatchID
            '========================================================================
            sRet.Append(SQLInsertD09T0216s(tdbg(i, COL_BatchID).ToString, i).ToString)
            sRet.Append(SQLInsertD25T1052s(tdbg(i, COL_BatchID).ToString, i).ToString)
            sRet.Append(SQLInsertD25T1050s(tdbg(i, COL_BatchID).ToString, i).ToString)
            sRet.Append(SQLInsertD25T1051s(tdbg(i, COL_BatchID).ToString, i).ToString)
            sRet.Append(SQLInsertD25T1054s(tdbg(i, COL_BatchID).ToString, i).ToString)
            sRet.Append(SQLInsertD25T1055s(tdbg(i, COL_BatchID).ToString, i).ToString)

            'ID 101294 Luu ExperienceYear,RecPositionID vào bảng D25T1035(Cột động)
                             Dim bHaveExp as Boolean=dtCol.Select("FieldName='ExperienceYear'").Length=1
         Dim bHavePos as Boolean=dtCol.Select("FieldName='RecPositionID'").Length=1

            If bHaveExp and bHavePos then
                sRet.Append(SQLInsertD25T1035(tdbg(i,"RecPositionID" ).ToString,tdbg(i,COL_CandidateID ).ToString,Number(tdbg(i,"ExperienceYear" ))).ToString  & vbCrLf)
         ElseIf bHaveExp then
 sRet.Append(SQLInsertD25T1035("",tdbg(i,COL_CandidateID ).ToString,Number(tdbg(i,"ExperienceYear" ))).ToString  & vbCrLf)
                ElseIf bHavePos then
                 sRet.Append(SQLInsertD25T1035(tdbg(i,"RecPositionID" ).ToString,tdbg(i,COL_CandidateID ).ToString,0).ToString  & vbCrLf)
   End If

              
            sRet.Append(vbCrLf & vbCrLf)
            '========================================================================
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
'# Title: SQLInsertD25T1035
'# Created User: 
'# Created Date: 25/08/2017 04:34:57
'#---------------------------------------------------------------------------------------------------
Private Function SQLInsertD25T1035(ByVal sRecPos As String,ByVal sCand As String,ByVal iExpY As double) As StringBuilder
	Dim sSQL As New StringBuilder
	sSQL.Append("-- Insert D25T1035 " & vbCrlf )
	sSQL.Append("Insert Into D25T1035(")
	sSQL.Append("RecPositionID, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, "  & vbCrlf)
	sSQL.Append("CandidateID, ExperienceYear")
	sSQL.Append(") Values(" & vbCrlf)
		sSQL.Append(SQLString(sRecPos) & COMMA) 'RecPositionID, nvarchar[2000], NOT NULL
		sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
		sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
		sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
		sSQL.Append("GetDate()" & COMMA & vbCrlf) 'LastModifyDate, datetime, NOT NULL
		sSQL.Append(SQLString(sCand) & COMMA) 'CandidateID, varchar[20], NOT NULL
		sSQL.Append(SQLMoney(iExpY,DxxFormat.DefaultNumber2)) 'ExperienceYear, decimal, NULL
	sSQL.Append(")")

	Return sSQL
End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0216s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:33:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0216s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iFirstTrans As Long = 0
        Dim iCountIGE As Integer = 0
        Dim dtTemp As DataTable = CType(tdbg2.DataSource, DataTable)
        Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))
        iCountIGE = dtTemp.Select("RelativeID ='' or RelativeID is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu quan he gia dinh" & vbCrLf)
            If dr(i).Item("RelativeID").ToString = "" Then
                sTransactionID = CreateIGEs("D09T0216", "RelativeID", "25", "DE", gsStringKey, sTransactionID, iCountIGE)
                dr(i).Item("RelativeID") = sTransactionID
            End If
            sSQL.Append("Insert Into D09T0216(")
            sSQL.Append("RelativeID, EmployeeID, RelativeName, RelativeNameU, UndefinedBD, BirthDate1, ")
            sSQL.Append("BirthDate, BirthDateU, BirthPlace, BirthPlaceU, ")
            sSQL.Append("Address, AddressU, Occupation, ")
            sSQL.Append("OccupationU, EducationLevelID, Sex, RelationID, ")
            sSQL.Append("CreateDate,CreateUserID, LastModifyUserID, LastModifyDate, Salary, ")
            sSQL.Append("IncomeTaxCode,IDCardNo,  EffectDate, ") 'IsReduce, IsBenefit,
            sSQL.Append("Alive, Note, NoteU")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(dr(i).Item("RelativeID").ToString) & COMMA) 'RelativeID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelativeName").ToString, gbUnicode, False) & COMMA) 'RelativeName, varchar[50], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelativeName").ToString, gbUnicode, True) & COMMA) 'RelativeNameU, varchar[50], NULL
            '************************
            If dr(i).Item("YearBD").ToString = "" Then 'Không nhập ngày,tháng, năm
                sSQL.Append(SQLNumber(0) & COMMA) 'UndefinedBD, tinyint, NOT NULL
                sSQL.Append(SQLDateSave("") & COMMA) 'BirthDate1, datetime, NULL
                sSQL.Append(SQLStringUnicode("", gbUnicode, False) & COMMA) 'BirthDate, varchar[20], NULL
                sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'BirthDate, varchar[20], NULL
            Else
                Dim iUndefinedBD As Byte = L3Byte(dr(i).Item("UndefinedBD"))
                Dim sBirthDate As String = ReturnBirthDate(iUndefinedBD, dr(i).Item("DayBD").ToString, dr(i).Item("MonthBD").ToString, dr(i).Item("YearBD").ToString)
                sSQL.Append(SQLNumber(iUndefinedBD) & COMMA) 'UndefinedBirthDate, tinyint, NOT NULL
                sSQL.Append(SQLDateSave(sBirthDate) & COMMA) 'BirthDate1, datetime, NULL
                sSQL.Append(SQLStringUnicode(sBirthDate, gbUnicode, False) & COMMA) 'BirthDate, varchar[20], NULL
                sSQL.Append(SQLStringUnicode(sBirthDate, gbUnicode, True) & COMMA) 'BirthDate, varchar[20], NULL
            End If
            '************************
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationBirthPlace").ToString, gbUnicode, False) & COMMA) 'BirthPlace, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationBirthPlace").ToString, gbUnicode, True) & COMMA) 'BirthPlaceU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationAddress").ToString, gbUnicode, False) & COMMA) 'Address, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationAddress").ToString, gbUnicode, True) & COMMA) 'AddressU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RealtionWorkID").ToString, gbUnicode, False) & COMMA) 'Occupation, varchar[100], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RealtionWorkID").ToString, gbUnicode, True) & COMMA) 'Occupation, varchar[100], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("EducationLevelID").ToString, gbUnicode, False) & COMMA) 'EducationLevelID, varchar[100], NULL
            sSQL.Append(SQLNumber(dr(i).Item("RelationSex").ToString) & COMMA) 'Sex, bit, NOT NULL
            sSQL.Append(SQLString(dr(i).Item("RelationID").ToString) & COMMA) 'RelationID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLMoney(dr(i).Item("Salary").ToString, tdbg2.Columns(COL2_Salary).NumberFormat) & COMMA) 'Salary, money, NOT NULL
            sSQL.Append(SQLString(dr(i).Item("IncomeTaxCode").ToString) & COMMA) 'IncomeTaxCode, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("IDCardNo").ToString) & COMMA) 'IDCardNo, varchar[50], NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item("EffectDate").ToString) & COMMA) 'EffectDate, datetime, NULL
            sSQL.Append(SQLNumber(dr(i).Item("Alive").ToString) & COMMA) 'Alive, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationNote").ToString, gbUnicode, False) & COMMA) 'Note, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("RelationNote").ToString, gbUnicode, True)) 'NoteU, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1052s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:33:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1052s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iCountIGE As Integer = 0
        Dim dtTemp As DataTable = CType(tdbg3.DataSource, DataTable)
        Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))
        iCountIGE = dtTemp.Select("ExperienceID ='' or ExperienceID is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu kinh nghiem lam viec" & vbCrLf)
            If dr(i).Item("ExperienceID").ToString = "" Then
                sTransactionID = CreateIGEs("D25T1052", "ExperienceID", "25", "EX", gsStringKey, sTransactionID, iCountIGE)
                dr(i).Item("ExperienceID") = sTransactionID
            End If
            sSQL.Append("Insert Into D25T1052(")
            sSQL.Append("DivisionID, CandidateID, ExperienceID, DateStarted,")
            sSQL.Append("DateEnded, CompanyName, CompanyNameU, ")
            sSQL.Append("Address, AddressU, ColleagueQuan, SubordinateQuan,")
            sSQL.Append("LeavingReason, LeavingReasonU, Reference, ReferenceU,")
            sSQL.Append("Note, NoteU, CreateUserID, LastModifyUserID, ")
            sSQL.Append("CreatedDate, LastModifyDate, CountryID, DutyName, DutyNameU, ")
            sSQL.Append("CurrencyID, JobDescription, JobDescriptionU, BaseSalary, Allowance")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("ExperienceID").ToString) & COMMA) 'ExperienceID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item("ExperienceDateStarted").ToString) & COMMA) 'DateStarted, datetime, NULL
            sSQL.Append(SQLDateSave(dr(i).Item("ExperienceDateEnd").ToString) & COMMA) 'DateEnded, datetime, NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("CompanyName").ToString, gbUnicode, False) & COMMA) 'CompanyName, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("CompanyName").ToString, gbUnicode, True) & COMMA) 'CompanyNameU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceAddress").ToString, gbUnicode, False) & COMMA) 'Address, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceAddress").ToString, gbUnicode, True) & COMMA) 'AddressU, varchar[250], NULL
            sSQL.Append(SQLNumber(dr(i).Item("ColleagueQuan").ToString) & COMMA) 'ColleagueQuan, int, NULL
            sSQL.Append(SQLNumber(dr(i).Item("SubordinateQuan").ToString) & COMMA) 'SubordinateQuan, int, NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("LeavingReason").ToString, gbUnicode, False) & COMMA) 'LeavingReason, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("LeavingReason").ToString, gbUnicode, True) & COMMA) 'LeavingReasonU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("Reference").ToString, gbUnicode, False) & COMMA) 'Reference, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("Reference").ToString, gbUnicode, True) & COMMA) 'Reference, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceNote").ToString, gbUnicode, False) & COMMA) 'Note, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceNote").ToString, gbUnicode, True) & COMMA) 'NoteU, varchar[250], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreatedDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(dr(i).Item("CountryID").ToString) & COMMA) 'CountryID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("DutyID").ToString, gbUnicode, False) & COMMA) 'DutyName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("DutyID").ToString, gbUnicode, True) & COMMA) 'DutyNameU, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("CurrencyID").ToString) & COMMA) 'CurrencyID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceWorkID").ToString, gbUnicode, False) & COMMA) 'JobDescription, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ExperienceWorkID").ToString, gbUnicode, True) & COMMA) 'JobDescriptionU, nvarchar[500], NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item("BaseSalary").ToString, tdbg3.Columns(COL3_BaseSalary).NumberFormat) & COMMA) 'BaseSalary, money, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item("Allowance").ToString, tdbg3.Columns(COL3_Allowance).NumberFormat)) 'Allowance, money, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1050s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:34:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1050s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iCountIGE As Integer = 0
        Dim dtTemp As DataTable = CType(tdbg4.DataSource, DataTable)
        Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))
        iCountIGE = dtTemp.Select("TransEducationID ='' or TransEducationID is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu qua trinh hoc tap" & vbCrLf)
            If dr(i).Item("TransEducationID").ToString = "" Then
                sTransactionID = CreateIGEs("D25T1050", "TransEducationID", "25", "TE", gsStringKey, sTransactionID, iCountIGE)
                dr(i).Item("TransEducationID") = sTransactionID
            End If
            sSQL.Append("Insert Into D25T1050(")
            sSQL.Append("TransEducationID, DivisionID, CandidateID, Description, ")
            sSQL.Append("DescriptionU, Certificates, CertificatesU, SchoolID, MajorID, ")
            sSQL.Append("DateStarted, DateEnded, EducationFormID, ")
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(dr(i).Item("TransEducationID").ToString) & COMMA) 'TransEducationID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("EducationDescription").ToString, gbUnicode, False) & COMMA) 'Description, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("EducationDescription").ToString, gbUnicode, True) & COMMA) 'DescriptionU, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("Certificates").ToString, gbUnicode, False) & COMMA) 'Certificates, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("Certificates").ToString, gbUnicode, True) & COMMA) 'CertificatesU, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("SchoolID").ToString) & COMMA) 'SchoolID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("MajorID").ToString) & COMMA) 'MajorID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item("EducationDateStarted").ToString) & COMMA) 'DateStarted, datetime, NULL
            sSQL.Append(SQLDateSave(dr(i).Item("EducationDateEnded").ToString) & COMMA) 'DateEnded, datetime, NULL
            sSQL.Append(SQLString(dr(i).Item("EducationFormID").ToString) & COMMA) 'EducationFormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1051s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:35:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1051s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iCountIGE As Integer = 0
        Dim dtTemp As DataTable = CType(tdbg5.DataSource, DataTable)
        Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))
        iCountIGE = dtTemp.Select("TransLanguageID ='' or TransLanguageID is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu trinh do ngoai ngu" & vbCrLf)
            If dr(i).Item("TransLanguageID").ToString = "" Then
                sTransactionID = CreateIGEs("D25T1051", "TransLanguageID", "25", "TL", gsStringKey, sTransactionID, iCountIGE)
                dr(i).Item("TransLanguageID") = sTransactionID
            End If
            sSQL.Append("Insert Into D25T1051(")
            sSQL.Append("TransLanguageID, DivisionID, CandidateID, Description, DescriptionU, ")
            sSQL.Append("LanguageID,  LanguageLevelID, Listening, Speaking, Reading, Writing,")
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(dr(i).Item("TransLanguageID").ToString) & COMMA) 'TransLanguageID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("LanguageDescription").ToString, gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("LanguageDescription").ToString, gbUnicode, True) & COMMA) 'DescriptionU, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("LanguageID").ToString) & COMMA) 'LanguageID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("LanguageLevelID").ToString) & COMMA) 'LanguageLevelID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("Listenning").ToString) & COMMA) 'Listening, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("Speaking").ToString) & COMMA) 'Speaking, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("Reading").ToString) & COMMA) 'Reading, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("Writing").ToString) & COMMA) 'Writing, varchar[50], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1054s
    '# Created User: VANVINH
    '# Created Date: 11/01/2013 05:35:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1054s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder

        '---------------------------------
        Dim sSQL As New StringBuilder
        Dim dtTemp As DataTable = CType(tdbg6.DataSource, DataTable)
        Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu trinh do tin hoc" & vbCrLf)
            sSQL.Append("Insert Into D25T1054(")
            sSQL.Append("DivisionID, CandidateID, Description, DescriptionU, ")
            sSQL.Append("ComputingCertificate, ComputingCertificateU, ComputingLevel, ")
            sSQL.Append("SchoolID, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ComputingDescription").ToString, gbUnicode, False) & COMMA) 'Description, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ComputingDescription").ToString, gbUnicode, True) & COMMA) 'DescriptionU, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ComputingCertificates").ToString, gbUnicode, False) & COMMA) 'ComputingCertificate, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item("ComputingCertificates").ToString, gbUnicode, True) & COMMA) 'ComputingCertificateU, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("ComputingLevelID").ToString) & COMMA) 'ComputingLevel, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("ComputingSchoolID").ToString) & COMMA) 'SchoolID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1055s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 17/01/2017 09:01:32
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD25T1055s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
    '    Dim sRet As New StringBuilder
    '    Dim sSQL As New StringBuilder
    '    Dim dtTemp As DataTable = CType(tdbg7.DataSource, DataTable)
    '    Dim dr() As DataRow = dtTemp.Select("BatchID = " & SQLString(sBatchID))

    '    For i As Integer = 0 To dr.Length - 1
    '        If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu giay to tuy than" & vbCrLf)
    '        sSQL.Append("Insert Into D25T1055(")
    '        sSQL.Append("DivisonID, CandidateID, DocTypeID, DocTypeNameU, IsSubmit, " & vbCrLf)
    '        sSQL.Append("DocNotesU, UpdateDate, LastModifyUserID, LastModifyDate")
    '        sSQL.Append(") Values(" & vbCrLf)
    '        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisonID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(dr(i).Item(COL7_DocTypeID).ToString) & COMMA) 'DocTypeID, varchar[20], NOT NULL
    '        sSQL.Append(SQLStringUnicode(dr(i).Item(COL7_DocTypeName).ToString, gbUnicode, True) & COMMA) 'DocTypeNameU, nvarchar[1000], NOT NULL
    '        sSQL.Append(SQLNumber(dr(i).Item(COL7_IsSubmit)) & COMMA & vbCrLf) 'IsSubmit, tinyint, NOT NULL
    '        sSQL.Append(SQLStringUnicode(dr(i).Item(COL7_DocNotes).ToString, gbUnicode, True) & COMMA) 'DocNotesU, nvarchar[1000], NOT NULL
    '        sSQL.Append(SQLDateSave(dr(i).Item(COL7_UpdateDate)) & COMMA) 'UpdateDate, datetime, NOT NULL
    '        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
    '        sSQL.Append("GetDate()" & vbCrLf) 'LastModifyDate, datetime, NOT NULL
    '        sSQL.Append(")")

    '        sRet.Append(sSQL.ToString & vbCrLf)
    '        sSQL.Remove(0, sSQL.Length)
    '    Next
    '    Return sRet
    'End Function

    Private Function SQLInsertD25T1055s(ByVal sBatchID As String, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim dt As DataTable = dsGrid7.Tables(sBatchID)

        For i As Integer = 0 To dt.Rows.Count - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu giay to tuy than" & vbCrLf)
            sSQL.Append("Insert Into D25T1055(")
            sSQL.Append("DivisionID, CandidateID, DocTypeID, DocTypeNameU, IsSubmit, " & vbCrLf)
            sSQL.Append("DocNotesU, UpdateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_CandidateID)) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dt.Rows(i).Item(COL7_DocTypeID).ToString) & COMMA) 'DocTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dt.Rows(i).Item(COL7_DocTypeName).ToString, gbUnicode, True) & COMMA) 'DocTypeNameU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLNumber(dt.Rows(i).Item(COL7_IsSubmit)) & COMMA & vbCrLf) 'IsSubmit, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(dt.Rows(i).Item(COL7_DocNotes).ToString, gbUnicode, True) & COMMA) 'DocNotesU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLDateSave(dt.Rows(i).Item(COL7_UpdateDate)) & COMMA) 'UpdateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & vbCrLf) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

#End Region

    Private Sub chkIsDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsDetail.Click
        If chkIsDetail.Checked Then
            tabPage.Visible = True
            tdbg.Splits(1).SplitSize = 0
            tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Automatic
            tdbg.Width -= tabPage.Width ' 422
            tdbg.Splits(0).HorizontalOffset = 0
            tabPage.SelectedTab = Tab1
            tdbg2.Focus()
            tdbg2.SplitIndex = SPLIT0
            tdbg2.Col = COL2_RelationName
            tdbg2.Bookmark = 1
        Else
            tabPage.Visible = False
            tdbg.Splits(1).SplitSize = 8
            tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Automatic
            tdbg.Width += tabPage.Width '1004
            tdbg.Splits(0).HorizontalOffset = 0
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_LastName
            tdbg.Bookmark = tdbg.Row
        End If
    End Sub

#Region "Cac xu ly tren luoi chinh tdbg"

    Private Function TestData(ByVal sElement As String, ByVal iRow As Integer) As Boolean
        If tdbg.RowCount = 1 Then Return True
        For i As Integer = 0 To tdbg.RowCount - 1
            If i <> iRow Then
                If tdbg(i, COL_CandidateID).ToString = sElement Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        If dtGridDetail2 IsNot Nothing Then dtGridDetail2.DefaultView.RowFilter = "BatchID=" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString)
        If dtGridDetail3 IsNot Nothing Then dtGridDetail3.DefaultView.RowFilter = "BatchID=" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString)
        If dtGridDetail4 IsNot Nothing Then dtGridDetail4.DefaultView.RowFilter = "BatchID=" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString)
        If dtGridDetail5 IsNot Nothing Then dtGridDetail5.DefaultView.RowFilter = "BatchID=" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString)
        If dtGridDetail6 IsNot Nothing Then dtGridDetail6.DefaultView.RowFilter = "BatchID=" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString)
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If dtGridDetail2 IsNot Nothing Then dtGridDetail2 = ReturnTableFilter(dtGridDetail2, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))
        If dtGridDetail3 IsNot Nothing Then dtGridDetail3 = ReturnTableFilter(dtGridDetail3, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))
        If dtGridDetail4 IsNot Nothing Then dtGridDetail4 = ReturnTableFilter(dtGridDetail4, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))
        If dtGridDetail5 IsNot Nothing Then dtGridDetail5 = ReturnTableFilter(dtGridDetail5, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))
        If dtGridDetail6 IsNot Nothing Then dtGridDetail6 = ReturnTableFilter(dtGridDetail6, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))
        If dtGrid1 IsNot Nothing Then dtGrid1 = ReturnTableFilter(dtGrid1, "BatchID <> " & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString, False))

        LoadDataSource(tdbg2, dtGridDetail2, gbUnicode)
        LoadDataSource(tdbg3, dtGridDetail3, gbUnicode)
        LoadDataSource(tdbg4, dtGridDetail4, gbUnicode)
        LoadDataSource(tdbg5, dtGridDetail5, gbUnicode)
        LoadDataSource(tdbg6, dtGridDetail6, gbUnicode)
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
    End Sub

#Region "tdbg"
    Private Sub tdbg_OnAddNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.OnAddNew
        tdbg.Columns(COL_IsUsed).Text = "0"
        '*****************************
        If dtDivision IsNot Nothing Then  'id 72471 17/6/2015
            If L3String(dtDivision.Rows(0).Item("Code")) <> "" AndAlso L3String(dtDivision.Rows(1).Item("Code")) = "" Then
                tdbg.Columns("DivisionID").Text = dtDivision.Rows(0).Item("Code").ToString
            End If
        End If
        '*****************************
        'iD 80009 2/10/2015
        tdbdNationalityID.Text = "VIE"
        tdbg.Columns(COL_NationalityID).Text = tdbdNationalityID.Text
        tdbg.Columns(COL_UndefinedBD).DefaultValue = "3" 'ID 82099 24/12/2015
    End Sub
    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_DayBD 'Phải gán mặc định tháng 12 để có thể nhập được ngày 31 tại cột Ngày sinh
                If tdbg.Columns(e.ColIndex).Text = "" Then c1dateDBirthDate.Value = CDate("31/12/2014")
        End Select
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_BirthPlaceDistrictName, COL_BirthPlaceWardName, COL_ConAddressDistrictName, COL_ConAddressWardName, COL_ResAddressDistrictName, COL_ResAddressWardName, _
                 COL_BPPLabelName, COL_BirthPlaceProvinceName, COL_BPDLabelName, COL_BPWLabelName, COL_CAPLabelName, _
                 COL_ConAddressProvinceName, COL_CADLabelName, COL_CAWLabelName, COL_RAPLabelName, COL_ResAddressProvinceName, COL_RADLabelName, COL_RAWLabelName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_Sex, COL_IDCardPlaceID, COL_EthnicID, COL_ReligionID, COL_NationalityID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_CandidateID
                e.Cancel = L3IsID(tdbg, e.ColIndex)
                If Not TestData(tdbg.Columns(COL_CandidateID).Text, tdbg.Row) Then
                    D99C0008.MsgDuplicatePKey()
                    e.Cancel = True
                End If
            Case COL_IDCardNo
                btnSave.Enabled = True
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                Select Case tdbg.Columns(e.ColIndex).Text.Length
                    Case 9, 12
                    Case Else
                        e.Cancel = True
                        Exit Sub
                End Select
                btnSave.Enabled = CheckIDCardNo(Me.Name, tdbg.Columns(e.ColIndex).Text, tdbg.Columns(COL_CandidateID).Text)
                If btnSave.Enabled = False Then e.Cancel = True 'txtIDCardNo.Focus()
            Case Else
                If Not tdbg.Columns(e.ColIndex).DropDown Is Nothing Then
                    Dim tdbdID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(e.ColIndex).DropDown
                    If tdbg.Columns(e.ColIndex).Text <> tdbdID.Columns(tdbdID.DisplayMember).Text Then bNotInList = True
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_Sex, COL_IDCardPlaceID, COL_EthnicID, COL_ReligionID, COL_NationalityID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_DayBD, COL_MonthBD, COL_YearBD 'ID 82099 24/12/2015
                tdbg.Select()
                If e.ColIndex = COL_DayBD Then SetDateValue(0, tdbg, COL_DayBD, COL_MonthBD, COL_YearBD, COL_UndefinedBD)
                If e.ColIndex = COL_MonthBD Then SetDateValue(1, tdbg, COL_DayBD, COL_MonthBD, COL_YearBD, COL_UndefinedBD)
                If e.ColIndex = COL_YearBD Then SetDateValue(2, tdbg, COL_DayBD, COL_MonthBD, COL_YearBD, COL_UndefinedBD)
                '************************************
                'ID 81526 11/01/2016
            Case COL_BPPLabelName, COL_BPDLabelName, COL_BPWLabelName, COL_CAPLabelName, COL_CADLabelName, _
                 COL_CAWLabelName, COL_RAPLabelName, COL_RADLabelName, COL_RAWLabelName
                Dim sFieldID As String = tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    Exit Select
                End If
                tdbg.Columns(sFieldID).Text = tdbg.Columns(e.ColIndex).DropDown.Columns("Code").Text
            Case COL_BirthPlaceProvinceName
                tdbg.Columns(COL_BirthPlaceDistrictID).Text = ""
                tdbg.Columns(COL_BirthPlaceDistrictName).Text = ""
                tdbg.Columns(COL_BirthPlaceWardID).Text = ""
                tdbg.Columns(COL_BirthPlaceWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(COL_BirthPlaceProvinceID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BirthPlaceProvinceID).Text = tdbdBirthPlaceProvinceID.Columns("Code").Text
            Case COL_BirthPlaceDistrictName
                tdbg.Columns(COL_BirthPlaceWardID).Text = ""
                tdbg.Columns(COL_BirthPlaceWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BirthPlaceDistrictID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BirthPlaceDistrictID).Text = tdbdBirthPlaceDistrictID.Columns("Code").Text
            Case COL_BirthPlaceWardName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BirthPlaceWardID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BirthPlaceWardID).Text = tdbdBirthPlaceWardID.Columns("Code").Text
            Case COL_ConAddressProvinceName
                tdbg.Columns(COL_ConAddressDistrictID).Text = ""
                tdbg.Columns(COL_ConAddressDistrictName).Text = ""
                tdbg.Columns(COL_ConAddressWardID).Text = ""
                tdbg.Columns(COL_ConAddressWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(COL_ConAddressProvinceID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ConAddressProvinceID).Text = tdbdConAddressProvinceID.Columns("Code").Text
            Case COL_ConAddressDistrictName
                tdbg.Columns(COL_ConAddressWardID).Text = ""
                tdbg.Columns(COL_ConAddressWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ConAddressDistrictID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ConAddressDistrictID).Text = tdbdConAddressDistrictID.Columns("Code").Text
            Case COL_ConAddressWardName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ConAddressWardID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ConAddressWardID).Text = tdbdConAddressWardID.Columns("Code").Text
            Case COL_ResAddressProvinceName
                tdbg.Columns(COL_ResAddressDistrictID).Text = ""
                tdbg.Columns(COL_ResAddressDistrictName).Text = ""
                tdbg.Columns(COL_ResAddressWardID).Text = ""
                tdbg.Columns(COL_ResAddressWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(COL_ResAddressProvinceID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ResAddressProvinceID).Text = tdbdResAddressProvinceID.Columns("Code").Text
            Case COL_ResAddressDistrictName
                tdbg.Columns(COL_ResAddressWardID).Text = ""
                tdbg.Columns(COL_ResAddressWardName).Text = ""
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ResAddressDistrictID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ResAddressDistrictID).Text = tdbdResAddressDistrictID.Columns("Code").Text
            Case COL_ResAddressWardName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ResAddressWardID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ResAddressWardID).Text = tdbdResAddressWardID.Columns("Code").Text
            Case Else
                If tdbg.Columns(e.ColIndex).DropDown IsNot Nothing Then
                    If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                        tdbg.Columns(e.ColIndex).Text = ""
                        bNotInList = False
                        Exit Select
                    End If
                    Try
                        Select Case e.Column.DataColumn.DataField
                            Case "DivisionID"
                                If sExistRecDepartmentID Then tdbg.Columns("RecDepartmentID").Text = ""
                                If sExistRecTeamID Then tdbg.Columns("RecTeamID").Text = ""
                            Case "RecDepartmentID"
                                If sExistRecTeamID Then tdbg.Columns("RecTeamID").Text = ""
                        End Select
                    Catch ex As Exception
                        D99C0008.MsgL3(ex.Message)
                    End Try
                    If tdbg.Columns(e.ColIndex).Value.ToString = "+" Then 'Thêm mới
                        tdbg.Columns(e.ColIndex).Text = ""
                        Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(e.ColIndex).DropDown
                        Dim sKey As String = CalExeAddNew(tdbd.Columns("Exe").Text, tdbd.Columns("FormID").Text, tdbd.Columns("FormPermission").Text, tdbd.Columns("FieldID").Text)
                        If sKey <> "" Then
                            LoadDataSource(tdbd, tdbd.Tag.ToString, gbUnicode)
                            tdbg.Columns(e.ColIndex).Text = sKey
                            tdbg.Focus()
                            tdbg.SplitIndex = 1
                            tdbg.Col = e.ColIndex
                        End If
                    End If
                End If
        End Select
        '*******************************
        If tdbg.Columns(COL_BatchID).Text = "" Then
            Dim GetNumber As New Random
            Dim so As Integer = GetNumber.Next(1000, 10000)
            tdbg.Columns(COL_BatchID).Text = "CF" & so & tdbg.RowCount
            tdbg.UpdateData()
            tdbg.Columns(COL_BatchID).Tag = tdbg.Columns(COL_BatchID).Text
            FilterDetail(tdbg.Columns(COL_BatchID).Text)
        End If

        tdbg.UpdateData()
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_CandidateID
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg.Col
                    Case COL_CandidateID To COL_IDCardPlaceID
                        HotKeyF7(tdbg)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg)
        End Select
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub

    Dim bHeadClick As Boolean
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_CandidateID, COL_LastName, COL_MiddleName, COL_FirstName, COL_Sex, COL_EthnicID, COL_ReligionID, COL_NationalityID, COL_IDCardNo, COL_IDCardDate, COL_IDCardPlaceID
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
            Case COL_DayBD, COL_MonthBD, COL_YearBD
                Dim arr() As Integer = {COL_DayBD, COL_MonthBD, COL_YearBD}
                CopyColumnArr(tdbg, iCol, arr)
            Case COL_LongBusinesstrip
                L3HeadClick(tdbg, COL_LongBusinesstrip, bHeadClick)
            Case COL_BPPLabelName, COL_BPDLabelName, COL_BPWLabelName, COL_CAPLabelName, COL_CADLabelName, _
                COL_CAWLabelName, COL_RAPLabelName, COL_RADLabelName, COL_RAWLabelName
                Dim sFieldID As String = tdbg.Columns(iCol).DataField.Replace("Name", "ID")
                Dim arr() As Integer = {IndexOfColumn(tdbg, sFieldID)}
                CopyColumnArr(tdbg, iCol, arr)
            Case COL_BirthPlaceProvinceName, COL_BirthPlaceDistrictName, COL_BirthPlaceWardName
                Dim arr() As Integer = {COL_BirthPlaceProvinceID, COL_BirthPlaceProvinceName, COL_BirthPlaceDistrictID, COL_BirthPlaceDistrictName, COL_BirthPlaceWardID, COL_BirthPlaceWardName}
                CopyColumnArr(tdbg, iCol, arr)
            Case COL_ConAddressDistrictID, COL_ConAddressDistrictName, COL_ConAddressWardName
                Dim arr() As Integer = {COL_ConAddressProvinceID, COL_ConAddressProvinceName, COL_ConAddressDistrictID, COL_ConAddressDistrictName, COL_ConAddressWardID, COL_ConAddressWardName}
                CopyColumnArr(tdbg, iCol, arr)
            Case COL_ResAddressDistrictID, COL_ResAddressDistrictName, COL_ResAddressWardName
                Dim arr() As Integer = {COL_ResAddressProvinceID, COL_ResAddressProvinceName, COL_ResAddressDistrictID, COL_ResAddressDistrictName, COL_ResAddressWardID, COL_ResAddressWardName}
                CopyColumnArr(tdbg, iCol, arr)
            Case Else
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        tdbg2.UpdateData()
        tdbg3.UpdateData()
        tdbg4.UpdateData()
        tdbg5.UpdateData()
        tdbg6.UpdateData()
        tdbg7.UpdateData()
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount <= 0 Then Exit Sub
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case "RecDepartmentID"
                LoadtdbdRecDepartmentID(tdbg(tdbg.Row, "DivisionID").ToString)
            Case "RecTeamID"
                LoadtdbdRecTeamID(tdbg(tdbg.Row, "DivisionID").ToString, tdbg(tdbg.Row, "RecDepartmentID").ToString)
        End Select
        '**************************
        Select Case tdbg.Col ' ID 81526 11/01/2016
            Case COL_BirthPlaceDistrictName
                LoadTDBDDistrictID(tdbdBirthPlaceDistrictID, tdbg(tdbg.Row, COL_BirthPlaceProvinceID).ToString)
            Case COL_BirthPlaceWardName
                LoadTDBDWardID(tdbdBirthPlaceWardID, tdbg(tdbg.Row, COL_BirthPlaceDistrictID).ToString)
            Case COL_ConAddressDistrictName
                LoadTDBDDistrictID(tdbdConAddressDistrictID, tdbg(tdbg.Row, COL_ConAddressProvinceID).ToString)
            Case COL_ConAddressWardName
                LoadTDBDWardID(tdbdConAddressWardID, tdbg(tdbg.Row, COL_ConAddressDistrictID).ToString)
            Case COL_ResAddressDistrictName
                LoadTDBDDistrictID(tdbdResAddressDistrictID, tdbg(tdbg.Row, COL_ResAddressProvinceID).ToString)
            Case COL_ResAddressWardName
                LoadTDBDWardID(tdbdResAddressWardID, tdbg(tdbg.Row, COL_ResAddressDistrictID).ToString)
        End Select
        '**************************
        If e IsNot Nothing AndAlso e.LastRow = tdbg.Row Then Exit Sub
        If tdbg.Columns(COL_BatchID).Tag Is Nothing OrElse tdbg.Columns(COL_BatchID).Tag.ToString <> tdbg(tdbg.Row, COL_BatchID).ToString Then
            FilterDetail(tdbg(tdbg.Row, COL_BatchID).ToString, True)
            Dim dt As DataTable = dtGrid1.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select("BatchID =" & SQLString(tdbg(tdbg.Row, COL_BatchID).ToString), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg1.Row = dt.Rows.IndexOf(dr(0))
            tdbg.Columns(COL_BatchID).Tag = tdbg(tdbg.Row, COL_BatchID).ToString
        End If

    End Sub
#End Region

    Private Sub FilterDetail(sBatchID As String, Optional bRowColChange As Boolean = False)
        If dtGridDetail2 IsNot Nothing Then dtGridDetail2.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        If dtGridDetail3 IsNot Nothing Then dtGridDetail3.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        If dtGridDetail4 IsNot Nothing Then dtGridDetail4.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        If dtGridDetail5 IsNot Nothing Then dtGridDetail5.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        If dtGridDetail6 IsNot Nothing Then dtGridDetail6.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        '*********************
        'If dtGridDetail7 IsNot Nothing Then dtGridDetail7.DefaultView.RowFilter = "BatchID=" & SQLString(sBatchID)
        LoadTDBGrid7(False, sBatchID, bRowColChange)
    End Sub
    Private Sub LoadtdbdRecDepartmentID(ByVal DivisionID As String)
        Dim dtTemp As DataTable = ReturnTableFilter(dtRecDepartmentID, "DivisionID=" & SQLString(DivisionID), True)
        LoadDataSource(tdbg.Columns("RecDepartmentID").DropDown, dtTemp, gbUnicode)
    End Sub

    Private Sub LoadtdbdRecTeamID(ByVal DivisionID As String, ByVal DepartmentID As String)
        Dim dtTemp As DataTable = ReturnTableFilter(dtRecTeamID, "DivisionID=" & SQLString(DivisionID) & " And DepartmentID=" & SQLString(DepartmentID), True)
        LoadDataSource(tdbg.Columns("RecTeamID").DropDown, dtTemp, gbUnicode)
    End Sub
#End Region

#Region "ID 82099 24/12/2015"
    Private Function ReturnBirthDate(ByVal iUndefinedBirthDate As Byte, ByVal sDay As String, ByVal sMonth As String, ByVal sYear As String) As String
        Dim sBirthDate As String = ""
        If iUndefinedBirthDate = 0 Then 'Nhap day du ngay ,thang ,nam
            sBirthDate = CDate(sDay).Day.ToString("00") & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        ElseIf iUndefinedBirthDate = 2 Then 'Chi nhap thang,nam
            'sBirthDate = Date.DaysInMonth(L3Int(CDate(sYear).Year), L3Int(CDate(sMonth).Month)) & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
            sBirthDate = "01/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        Else  'Chi nhap nam
            sBirthDate = "01/01/" & CDate(sYear).Year.ToString("0000") ' "31/12/" & CDate(sYear).Year.ToString("0000")
        End If
        Return sBirthDate
    End Function

    Private Sub SetDateValue(ByVal iMode As Byte, ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_DayBD As Integer, ByVal COL_MonthBD As Integer, ByVal COL_YearBD As Integer, ByVal COL_UndefinedBD As Integer)
        Dim sDate As String
        Dim iDay, iMonth, iYear As Integer
        If iMode = 0 Then 'Ngày   
            Dim sDay As String = "0"
            iDay = L3Int(c1Grid.Columns(COL_DayBD).Text)
            If iDay = 0 Then sDay = ""
            iMonth = L3Int(IIf(c1Grid.Columns(COL_MonthBD).Text <> "", c1Grid.Columns(COL_MonthBD).Text, 12).ToString)
            iYear = L3Int(IIf(c1Grid.Columns(COL_YearBD).Text <> "", c1Grid.Columns(COL_YearBD).Text, Now.Year).ToString)
            sDate = c1Grid.Columns(COL_DayBD).Text & "/" & iMonth & "/" & iYear

            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            c1Grid.Columns(COL_DayBD).Value = dDate
            If sDay = "" Then c1Grid.Columns(COL_DayBD).Text = ""
            '***************
            If c1Grid.Columns(COL_MonthBD).Text <> "" Then c1Grid.Columns(COL_MonthBD).Value = c1Grid.Columns(COL_DayBD).Value
            If c1Grid.Columns(COL_YearBD).Text <> "" Then c1Grid.Columns(COL_YearBD).Value = c1Grid.Columns(COL_DayBD).Value
        ElseIf iMode = 1 Then 'Tháng
            iDay = L3Int(IIf(c1Grid.Columns(COL_DayBD).Text <> "", c1Grid.Columns(COL_DayBD).Text, Now.Day).ToString)
            iYear = L3Int(IIf(c1Grid.Columns(COL_YearBD).Text <> "", c1Grid.Columns(COL_YearBD).Text, Now.Year).ToString)
            Dim sMonth As String = "0"
            iMonth = L3Int(c1Grid.Columns(COL_MonthBD).Text)
            If iMonth = 0 Then
                sMonth = ""
                iMonth = 12
            End If
            '**************
            sDate = iDay & "/" & iMonth & "/" & iYear
            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            c1Grid.Columns(COL_MonthBD).Value = dDate
            If sMonth = "" Then c1Grid.Columns(COL_MonthBD).Text = ""
            '***************
            If c1Grid.Columns(COL_DayBD).Text <> "" Then c1Grid.Columns(COL_DayBD).Value = c1Grid.Columns(COL_MonthBD).Value
            If c1Grid.Columns(COL_YearBD).Text <> "" Then c1Grid.Columns(COL_YearBD).Value = c1Grid.Columns(COL_MonthBD).Value
        Else 'Năm
            iDay = L3Int(IIf(c1Grid.Columns(COL_DayBD).Text <> "", c1Grid.Columns(COL_DayBD).Text, Now.Day).ToString)
            iMonth = L3Int(IIf(c1Grid.Columns(COL_MonthBD).Text <> "", c1Grid.Columns(COL_MonthBD).Text, 12).ToString)
            Dim sYear As String = "0"
            iYear = L3Int(c1Grid.Columns(COL_YearBD).Text)
            If iYear = 0 Then sYear = ""
            '**************
            sDate = iDay & "/" & iMonth & "/" & iYear
            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            c1Grid.Columns(COL_YearBD).Value = dDate
            If sYear = "" Then c1Grid.Columns(COL_YearBD).Text = ""
            '***************
            If c1Grid.Columns(COL_DayBD).Text <> "" Then c1Grid.Columns(COL_DayBD).Value = c1Grid.Columns(COL_YearBD).Value
            If c1Grid.Columns(COL_MonthBD).Text <> "" Then c1Grid.Columns(COL_MonthBD).Value = c1Grid.Columns(COL_YearBD).Value
        End If
        '******************************
        Dim iUndefinedBirthDate As Byte = 3 'Không nhập Ngày/Tháng/Năm
        If c1Grid.Columns(COL_DayBD).Text <> "" AndAlso c1Grid.Columns(COL_MonthBD).Text <> "" AndAlso c1Grid.Columns(COL_YearBD).Text <> "" Then 'Nhap day du ngay ,thang ,nam
            iUndefinedBirthDate = 0
        ElseIf c1Grid.Columns(COL_MonthBD).Text <> "" AndAlso c1Grid.Columns(COL_YearBD).Text <> "" Then 'Chi nhap thang,nam
            iUndefinedBirthDate = 2 '1
        ElseIf c1Grid.Columns(COL_YearBD).Text <> "" Then 'Chi nhap nam
            iUndefinedBirthDate = 1 '2
        End If
        c1Grid.Columns(COL_UndefinedBD).Value = iUndefinedBirthDate
    End Sub
#End Region

#Region "Cac xu ly tren tab Quan he gia dinh"
    Dim bNotInList2 As Boolean = False
    Private Sub tdbg2_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL2_Alive
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                End If
            Case COL2_RelationName
                If tdbg2.Columns(COL2_RelationName).Text <> tdbdRelationID.Columns("RelationName").Text Then
                    tdbg2.Columns(COL2_RelationName).Text = ""
                    tdbg2.Columns(COL2_RelationID).Text = ""
                End If
            Case COL2_RelationWorkName
                If tdbg2.Columns(COL2_RelationWorkName).Text <> tdbdRealtionWorkID.Columns("RelationWorkName").Text Then
                    tdbg2.Columns(COL2_RelationWorkName).Text = ""
                    tdbg2.Columns(COL2_RealtionWorkID).Text = ""
                End If
            Case COL2_EducationLevelName
                If tdbg2.Columns(COL2_EducationLevelName).Text <> tdbdEducationLevelID.Columns("EducationLevelName").Text Then
                    tdbg2.Columns(COL2_EducationLevelName).Text = ""
                    tdbg2.Columns(COL2_EducationLevelID).Text = ""
                End If

            Case COL2_RelationSex
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                    bNotInList2 = True
                End If
        End Select
    End Sub

    Private Sub tdbg2_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg2.BeforeColEdit
        If e.ColIndex = COL2_DayBD Then 'Phải gán mặc định tháng 12 để có thể nhập được ngày 31 tại cột Ngày sinh
            If tdbg2.Columns(e.ColIndex).Text = "" Then c1dateDBirthDate.Value = CDate("31/12/2014")
        End If
    End Sub
    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL2_RelationSex, COL2_Alive
                If tdbg2.Columns(e.ColIndex).Text = "" OrElse bNotInList2 Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                    bNotInList2 = False
                    Exit Select
                End If
            Case COL2_DayBD, COL2_MonthBD, COL2_YearBD
                tdbg2.Select()
                If e.ColIndex = COL2_DayBD Then SetDateValue(0, tdbg2, COL2_DayBD, COL2_MonthBD, COL2_YearBD, COL2_UndefinedBD)
                If e.ColIndex = COL2_MonthBD Then SetDateValue(1, tdbg2, COL2_DayBD, COL2_MonthBD, COL2_YearBD, COL2_UndefinedBD)
                If e.ColIndex = COL2_YearBD Then SetDateValue(2, tdbg2, COL2_DayBD, COL2_MonthBD, COL2_YearBD, COL2_UndefinedBD)
        End Select
        If tdbg2.Columns(COL2_BatchID).Text = "" Then tdbg2.Columns(COL2_BatchID).Text = tdbg.Columns(COL_BatchID).Text

    End Sub

    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        Dim sKeyName As String = ""
        Dim sKeyID As String = ""
        Select Case e.ColIndex
            Case COL2_RelationName
                tdbg2.Columns(COL2_RelationID).Text = tdbdRelationID.Columns("RelationID").Text
                If tdbg2.Columns(COL2_RelationID).Text = "+" Then
                    tdbg2.Columns(COL2_RelationID).Text = ""
                    tdbg2.Columns(e.ColIndex).Text = ""
                    'ID 82836 14/12/2015
                    Dim arrPro() As StructureProperties = Nothing
                    Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0129", arrPro)
                    If L3Bool(GetProperties(frm, "bSaved")) Then
                        sKeyID = GetProperties(frm, "RelationID").ToString
                        sKeyName = GetProperties(frm, "RelationName").ToString
                        LoadDataSource(tdbdRelationID, tdbdRelationID.Tag.ToString, gbUnicode)
                        tdbg2.Columns(COL2_RelationID).Text = sKeyID
                        tdbg2.Columns(e.ColIndex).Text = sKeyName
                    End If

                    tdbg2.UpdateData()
                End If
            Case COL2_EducationLevelName
                tdbg2.Columns(COL2_EducationLevelID).Text = tdbdEducationLevelID.Columns("EducationLevelID").Text
                If tdbg2.Columns(COL2_EducationLevelID).Text = "+" Then
                    tdbg2.Columns(COL2_EducationLevelID).Text = ""
                    tdbg2.Columns(e.ColIndex).Text = ""
                    If ReturnPermission("D09F0240") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "FormIDPermission", "D09F0240")
                        SetProperties(arrPro, "FormState", CByte(1))
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0241", arrPro)
                        sKeyName = L3String(GetProperties(frm, "RelationName"))
                        sKeyID = L3String(GetProperties(frm, "RelationID"))
                        If sKeyName <> "" Then
                            Dim sSQL As String = ""
                            'Load tdbdEducationLevelID
                            sSQL = "-- Dropdown Trinh do van hoa" & vbCrLf
                            sSQL &= " SELECT '+' as EducationLevelID, " & NewName & " AS  EducationLevelName, 0 AS DisplayOrder "
                            sSQL &= " UNION  SELECT EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " AS EducationLevelName, 1 AS DisplayOrder"
                            sSQL &= " FROM 	D09T0206 WITH(NOLOCK)  WHERE 	Disabled = 0 ORDER BY 	DisplayOrder, EducationLevelName "
                            LoadDataSource(tdbdEducationLevelID, sSQL, gbUnicode)
                            tdbg2.Columns(COL2_EducationLevelID).Text = sKeyID
                            tdbg2.Columns(e.ColIndex).Text = sKeyName
                            tdbg2.UpdateData()
                        End If
                    End If
                End If
            Case COL2_RelationWorkName
                tdbg2.Columns(COL2_RealtionWorkID).Text = tdbdRealtionWorkID.Columns("RelationWorkID").Text
                If tdbg2.Columns(COL2_RealtionWorkID).Text = "+" Then
                    tdbg2.Columns(COL2_RealtionWorkID).Text = ""
                    tdbg2.Columns(e.ColIndex).Text = ""
                    If ReturnPermission("D09F0430") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "FormIDPermission", "D09F0430")
                        SetProperties(arrPro, "FormState", CByte(1))
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0431", arrPro)
                        sKeyName = L3String(GetProperties(frm, "RelationName"))
                        sKeyID = L3String(GetProperties(frm, "RelationID"))
                        If sKeyName <> "" Then
                            Dim sSQL As String = ""
                            'Load tdbdRealtionWorkID
                            sSQL = "-- Dropdown Cong viec dang lam" & vbCrLf
                            sSQL &= " SELECT  '+' as RelationWorkID, " & NewName & " AS  RelationWorkName, 0 AS DisplayOrder  UNION "
                            sSQL &= " SELECT WorkID as RelationWorkID, WorkName" & UnicodeJoin(gbUnicode) & " As  RelationWorkName, 1 As DisplayOrder  FROM 	D09T0224  WITH(NOLOCK)  WHERE 	Disabled = 0  ORDER BY 	DisplayOrder, RelationWorkName"
                            Dim dtRelationWorkID As DataTable = ReturnDataTable(sSQL)
                            LoadDataSource(tdbdRealtionWorkID, dtRelationWorkID, gbUnicode)
                            LoadDataSource(tdbdExperienceWorkID, dtRelationWorkID.DefaultView.ToTable, gbUnicode)
                            tdbg2.Columns(COL2_RealtionWorkID).Text = sKeyID
                            tdbg2.Columns(e.ColIndex).Text = sKeyName
                            tdbg2.UpdateData()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub HeadClick2(ByVal iCol As Integer)
        If tdbg2.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL2_RelativeName, COL2_RelationSex, COL2_DayBD, COL2_MonthBD, COL2_YearBD, COL2_RelationBirthPlace, COL2_RelationAddress, COL2_IDCardNo, COL2_IncomeTaxCode, COL2_Salary, COL2_Alive, COL2_RelationNote, COL2_EffectDate
                ' tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg2, iCol, tdbg2.Columns(iCol).Text, tdbg2.Bookmark)
                '****************************************************
            Case COL2_RelationName
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL2_RelationName, COL2_RelationID}
                CopyColumnArr(tdbg2, iCol, iColRelative)
            Case COL2_RelationWorkName
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL2_RelationWorkName, COL2_RealtionWorkID}
                CopyColumnArr(tdbg2, iCol, iColRelative)
            Case COL2_EducationLevelName
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL2_EducationLevelName, COL2_EducationLevelID}
                CopyColumnArr(tdbg2, iCol, iColRelative)
        End Select
    End Sub

    Private Sub tdbg2_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        HeadClick2(e.ColIndex)
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick2(tdbg2.Col)
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg2.Col
                    Case COL2_RelationName To COL2_EffectDate
                        HotKeyF7(tdbg2)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg2)
                ' FooterTotalGrid(tdbg, COL_InventoryID)
        End Select
    End Sub
#End Region

#Region "Cac xu ly tren tab kinh nghiem lam viec"
    Dim bNotInList3 As Boolean = False
    Private Sub tdbg3_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.ComboSelect
        Dim sKeyID As String = ""
        Dim sKey As String = ""
        Select Case e.ColIndex
            Case COL3_ExperienceWorkName
                tdbg3.Columns(COL3_ExperienceWorkID).Text = tdbdExperienceWorkID.Columns("RelationWorkID").Text
                If tdbg3.Columns(COL3_ExperienceWorkID).Text = "+" Then
                    tdbg3.Columns(COL3_ExperienceWorkName).Text = ""
                    tdbg3.Columns(COL3_ExperienceWorkID).Text = ""
                    If ReturnPermission("D09F0430") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "FormIDPermission", "D09F0430")
                        SetProperties(arrPro, "FormState", CByte(1))
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0431", arrPro)
                        sKey = L3String(GetProperties(frm, "RelationName"))
                        sKeyID = L3String(GetProperties(frm, "RelationID"))
                        If sKey <> "" Then
                            Dim sSQL As String = ""
                            'Load tdbdRealtionWorkID
                            sSQL = "-- Dropdown Cong viec dang lam" & vbCrLf
                            sSQL &= " SELECT  '+' as RelationWorkID, " & NewName & " AS  RelationWorkName, 0 AS DisplayOrder  UNION "
                            sSQL &= " SELECT WorkID as RelationWorkID, WorkName" & UnicodeJoin(gbUnicode) & " As  RelationWorkName, 1 As DisplayOrder  FROM 	D09T0224  WITH(NOLOCK)  WHERE 	Disabled = 0  ORDER BY 	DisplayOrder, RelationWorkName"
                            Dim dtRelationWorkID As DataTable = ReturnDataTable(sSQL)
                            LoadDataSource(tdbdRealtionWorkID, dtRelationWorkID, gbUnicode)
                            LoadDataSource(tdbdExperienceWorkID, dtRelationWorkID.DefaultView.ToTable, gbUnicode)
                            tdbg3.Columns(COL3_ExperienceWorkID).Text = sKeyID
                            tdbg3.Columns(COL3_ExperienceWorkName).Text = sKey
                            'tdbg3.UpdateData()
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg3_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg3.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL3_CountryID, COL3_DutyID, COL3_CurrencyID
                If tdbg3.Columns(e.ColIndex).Text <> tdbg3.Columns(e.ColIndex).DropDown.Columns(tdbg3.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg3.Columns(e.ColIndex).Text = ""
                    bNotInList3 = True
                End If
            Case COL3_ExperienceWorkName
                If tdbg3.Columns(COL3_ExperienceWorkName).Text <> tdbdExperienceWorkID.Columns("RelationWorkName").Text Then
                    tdbg3.Columns(COL3_ExperienceWorkName).Text = ""
                    tdbg3.Columns(COL3_ExperienceWorkID).Text = ""
                End If
            Case COL3_ExperienceDateEnd
                If tdbg3.Columns(COL3_ExperienceDateEnd).Text <> "" And tdbg3.Columns(COL3_ExperienceDateStarted).Text <> "" Then
                    If CDate(tdbg3.Columns(COL3_ExperienceDateEnd).Text) < CDate(tdbg3.Columns(COL3_ExperienceDateStarted).Text) Then
                        D99C0008.MsgL3(rL3("Ngay_bat_dau_phai_nho_hon_ngay_ket_thuc"))
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg3_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL3_CountryID, COL3_DutyID, COL3_CurrencyID
                If tdbg3.Columns(e.ColIndex).Text = "" OrElse bNotInList3 Then
                    tdbg3.Columns(e.ColIndex).Text = ""
                    bNotInList3 = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If

        End Select
        If tdbg3.Columns(COL3_BatchID).Text = "" Then tdbg3.Columns(COL3_BatchID).Text = tdbg.Columns(COL_BatchID).Text
    End Sub

    Private Sub HeadClick3(ByVal iCol As Integer)
        If tdbg3.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL3_ExperienceDateStarted, COL3_ExperienceDateEnd, COL3_CompanyName, COL3_CountryID, COL3_ExperienceAddress, COL3_DutyID, COL3_BaseSalary, COL3_Allowance, COL3_CurrencyID, COL3_ColleagueQuan, COL3_SubordinateQuan, COL3_LeavingReason, COL3_Reference, COL3_ExperienceNote
                'tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg3, iCol, tdbg3.Columns(iCol).Text, tdbg3.Bookmark)
                '****************************************************
            Case COL3_ExperienceWorkName
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL3_ExperienceWorkName, COL3_ExperienceWorkID}
                CopyColumnArr(tdbg3, iCol, iColRelative)
        End Select
    End Sub

    Private Sub tdbg3_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.HeadClick
        HeadClick3(e.ColIndex)
    End Sub

    Private Sub tdbg3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg3.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick3(tdbg3.Col)
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg3.Col
                    Case COL3_ExperienceDateStarted To COL3_ExperienceNote
                        HotKeyF7(tdbg3)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg3)
                ' FooterTotalGrid(tdbg, COL_InventoryID)
        End Select
    End Sub

#End Region

#Region "Cac xu ly tren tab qua trinh hoc tap"
    Dim bNotInList4 As Boolean = False
    Private Sub tdbg4_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg4.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL4_SchoolID, COL4_MajorID, COL4_EducationFormID
                If tdbg4.Columns(e.ColIndex).Text <> tdbg4.Columns(e.ColIndex).DropDown.Columns(tdbg4.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg4.Columns(e.ColIndex).Text = ""
                    bNotInList4 = True
                End If
            Case COL4_EducationDateEnded
                If tdbg4.Columns(COL4_EducationDateEnded).Text <> "" And tdbg4.Columns(COL4_EducationDateStarted).Text <> "" Then
                    If CDate(tdbg4.Columns(COL4_EducationDateEnded).Text) < CDate(tdbg4.Columns(COL4_EducationDateStarted).Text) Then
                        D99C0008.MsgL3(rL3("Ngay_bat_dau_phai_nho_hon_ngay_ket_thuc"))
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg4_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg4.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL4_SchoolID, COL4_MajorID, COL4_EducationFormID
                If tdbg4.Columns(e.ColIndex).Text = "" OrElse bNotInList4 Then
                    tdbg4.Columns(e.ColIndex).Text = ""
                    bNotInList4 = False
                    Exit Select
                End If
        End Select
        If tdbg4.Columns(COL4_BatchID).Text = "" Then tdbg4.Columns(COL4_BatchID).Text = tdbg.Columns(COL_BatchID).Text
    End Sub


    Private Sub HeadClick4(ByVal iCol As Integer)
        If tdbg4.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL4_EducationDescription, COL4_Certificates, COL4_SchoolID, COL4_MajorID, COL4_EducationDateStarted, COL4_EducationDateEnded, COL4_EducationFormID
                ' tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg4, iCol, tdbg4.Columns(iCol).Text, tdbg4.Bookmark)
                '****************************************************
        End Select
    End Sub

    Private Sub tdbg4_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg4.HeadClick
        HeadClick4(e.ColIndex)
    End Sub

    Private Sub tdbg4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg4.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick4(tdbg4.Col)
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg4.Col
                    Case COL4_EducationDescription To COL4_EducationFormID
                        HotKeyF7(tdbg4)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg4)
                ' FooterTotalGrid(tdbg, COL_InventoryID)
        End Select
    End Sub


#End Region

#Region "Cac xu ly tren tab trinh do ngoai ngu"
    Dim bNotInList5 As Boolean = False
    Private Sub tdbg5_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg5.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL5_LanguageID, COL5_LanguageLevelID, COL5_Listenning, COL5_Speaking, COL5_Reading, COL5_Writing
                If tdbg5.Columns(e.ColIndex).Text = "" OrElse bNotInList5 Then
                    tdbg5.Columns(e.ColIndex).Text = ""
                    bNotInList5 = False
                    Exit Select
                End If
        End Select
        If tdbg5.Columns(COL5_BatchID).Text = "" Then tdbg5.Columns(COL5_BatchID).Text = tdbg.Columns(COL_BatchID).Text
    End Sub


    Private Sub tdbg5_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg5.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL5_Listenning
                If tdbg5.Columns(e.ColIndex).Text <> tdbg5.Columns(e.ColIndex).DropDown.Columns(tdbg5.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg5.Columns(e.ColIndex).Text = ""
                End If
            Case COL5_LanguageID, COL5_LanguageLevelID, COL5_Speaking, COL5_Reading, COL5_Writing
                If tdbg5.Columns(e.ColIndex).Text <> tdbg5.Columns(e.ColIndex).DropDown.Columns(tdbg5.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg5.Columns(e.ColIndex).Text = ""
                    bNotInList5 = True
                End If
        End Select
    End Sub

    Private Sub HeadClick5(ByVal iCol As Integer)
        If tdbg5.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL5_LanguageDescription, COL5_LanguageID, COL5_LanguageLevelID, COL5_Listenning, COL5_Speaking, COL5_Reading, COL5_Writing
                ' tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg5, iCol, tdbg5.Columns(iCol).Text, tdbg5.Bookmark)
                '****************************************************
        End Select
    End Sub

    Private Sub tdbg5_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg5.HeadClick
        HeadClick5(e.ColIndex)
    End Sub

    Private Sub tdbg5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg5.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick5(tdbg5.Col)
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg5.Col
                    Case COL5_LanguageDescription To COL5_Writing
                        HotKeyF7(tdbg5)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg5)
                ' FooterTotalGrid(tdbg, COL_InventoryID)
        End Select
    End Sub

#End Region

#Region "Cac xu ly tren tab trinh do tin hoc"
    Dim bNotInList6 As Boolean = False
    Private Sub tdbg6_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg6.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ

        Select Case e.ColIndex
            Case COL6_ComputingLevelID, COL6_ComputingSchoolID
                If tdbg6.Columns(e.ColIndex).Text <> tdbg6.Columns(e.ColIndex).DropDown.Columns(tdbg6.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg6.Columns(e.ColIndex).Text = ""
                    bNotInList6 = True
                End If
        End Select
    End Sub

    Private Sub tdbg6_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg6.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL6_ComputingLevelID, COL6_ComputingSchoolID
                If tdbg6.Columns(e.ColIndex).Text = "" OrElse bNotInList6 Then
                    tdbg6.Columns(e.ColIndex).Text = ""
                    bNotInList6 = False
                    Exit Select
                End If
        End Select
        If tdbg6.Columns(COL6_BatchID).Text = "" Then tdbg6.Columns(COL6_BatchID).Value = tdbg.Columns(COL_BatchID).Text
    End Sub

    Private Sub HeadClick6(ByVal iCol As Integer)
        If tdbg6.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL6_ComputingDescription, COL6_ComputingCertificates, COL6_ComputingLevelID, COL6_ComputingSchoolID
                ' tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg6, iCol, tdbg6.Columns(iCol).Text, tdbg6.Bookmark)
                '****************************************************
        End Select
    End Sub

    Private Sub tdbg6_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg6.HeadClick
        HeadClick6(e.ColIndex)
    End Sub

    Private Sub tdbg6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg6.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick6(tdbg6.Col)
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg6.Col
                    Case COL6_ComputingDescription To COL6_ComputingSchoolID
                        HotKeyF7(tdbg6)
                End Select
            Case Keys.F8
                HotKeyF8(tdbg6)
                ' FooterTotalGrid(tdbg, COL_InventoryID)
        End Select
    End Sub

#End Region

    'Viết hàm checkStore riêng vì khi Status = 1 thì cho focus vào cột số CMND, Status = 2 thì focus vào cột Mã
    Private Function CheckStore_(ByVal SQL As String, ByRef iCol As Integer, Optional ByRef dt As DataTable = Nothing) As Boolean
        Dim sMsg As String
        Dim bMsgAsk As Boolean = False
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                ' dt = Nothing
                Return True
            End If
            iCol = L3Int(dt.Rows(0).Item("Status").ToString)
            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True
            If dt.Columns.Contains("MsgAsk") Then
                If L3Byte(dt.Rows(0).Item("MsgAsk")) = 1 Then
                    bMsgAsk = True
                End If
            End If

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
                'dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        'dt = Nothing
                        Return True
                    Else
                        'dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                'dt = Nothing
                                Return True
                            Else
                                'dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                'dt = Nothing
                                Return True
                            Else
                                'dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                'dt = Nothing
                                Return True
                            Else
                                'dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            'dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        tdbg1.UpdateData()
        tdbg2.UpdateData()
        tdbg3.UpdateData()
        tdbg4.UpdateData()
        tdbg5.UpdateData()
        tdbg6.UpdateData()
        dtGridDetail7.AcceptChanges()
        tdbg7.UpdateData()
        If _autoCandidateID = 1 Then
            If tdbcMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Phuong_phap_tao_ma_tu_dong"))
                tdbcMethodID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim row As Integer = -1
        Dim bFlag As Boolean = False 'Kiem tra xem co trung So CMND ko ?
        For i As Integer = 0 To tdbg.RowCount - 1
            If _autoCandidateID = 0 Then
                If tdbg(i, COL_CandidateID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_CandidateID
                    tdbg.Bookmark = i
                    Return False
                End If
            End If

            If tdbg(i, COL_LastName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ho"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_LastName
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_FirstName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ten"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_FirstName
                tdbg.Bookmark = i
                Return False
            End If
            '************************
            'ID 82099 24/12/2015
            If tdbg(i, COL_DayBD).ToString <> "" Then
                If tdbg(i, COL_MonthBD).ToString = "" Then
                    D99C0008.MsgL3(rL3("Du_lieu_ngay_sinh_khong_hop_le"))
                    tdbg.Focus()
                    tdbg.SplitIndex = 0
                    tdbg.Col = COL_MonthBD
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            End If
            If tdbg(i, COL_MonthBD).ToString <> "" Then
                If tdbg(i, COL_YearBD).ToString = "" Then
                    D99C0008.MsgL3(rL3("Du_lieu_ngay_sinh_khong_hop_le"))
                    tdbg.Focus()
                    tdbg.SplitIndex = 0
                    tdbg.Col = COL_YearBD
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            End If
            '************************
            If tdbg(i, COL_IDCardNo).ToString <> "" Then
                If tdbg(i, COL_IDCardNo).ToString.Length <> 9 And tdbg(i, COL_IDCardNo).ToString.Length <> 12 Then
                    D99C0008.MsgL3(rL3("So_CMND_chua_hop_le"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_IDCardNo
                    tdbg.Bookmark = i
                    Return False
                End If
            End If
            Try
                If tdbg(i, "DivisionID").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Don_vi"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = IndexOfColumn(tdbg, "DivisionID")
                    tdbg.Bookmark = i
                    Return False
                End If
            Catch ex As Exception

            End Try
            If tdbg(i, COL_IDCardNo).ToString <> "" Then
                For j As Integer = i + 1 To tdbg.RowCount - 1
                    If tdbg(i, COL_IDCardNo).ToString = tdbg(j, COL_IDCardNo).ToString Then
                        bFlag = True
                        If row = -1 Then row = j ' Giu lai dong dau tien vi pham
                    End If
                Next
            End If
            If Not clsCheckValid.CheckEmpty(i) Then Return False
        Next
        Dim iCol As Integer = 0
        Dim dtCheckStore As DataTable = Nothing
        If bFlag Then
            Dim sMsg As String = rL3("So_CMND_da_bi_trung") & ". " & rL3("MSG000028")
            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim sSQLL As New StringBuilder
                sSQLL.AppendLine(SQLDeleteD09T6666())
                sSQLL.AppendLine(SQLInsertD09T6666s().ToString)
                sSQLL.AppendLine(SQLStoreD25P5555(Me.Name, "", "", 0, 0).ToString)
                If Not CheckStore_(sSQLL.ToString, iCol, dtCheckStore) Then
                    ExecuteSQL(SQLDeleteD09T6666())
                    If iCol = 1 Then
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_IDCardNo
                        tdbg.Bookmark = 0
                    ElseIf iCol = 2 Then
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_CandidateID
                        If dtCheckStore.Rows.Count = 0 Then
                            tdbg.Bookmark = 0
                        Else
                            tdbg.Bookmark = findrowInGrid(tdbg, dtCheckStore.Rows(0).Item("CandidateID"), "CandidateID")
                        End If
                    End If
                    Return False
                End If
            Else
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_IDCardNo
                tdbg.Bookmark = row
                Return False
            End If
        Else
            Dim sSQLL As New StringBuilder
            sSQLL.AppendLine(SQLDeleteD09T6666())
            sSQLL.AppendLine(SQLInsertD09T6666s().ToString)
            sSQLL.AppendLine(SQLStoreD25P5555(Me.Name, "", "", 0, 0).ToString)
            Dim sMsg As String = rL3("MSG000028")
            If Not CheckStore_(sSQLL.ToString, iCol, dtCheckStore) Then
                ExecuteSQL(SQLDeleteD09T6666())
                If iCol = 1 Then
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_IDCardNo
                    tdbg.Bookmark = 0
                ElseIf iCol = 2 Then
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_CandidateID
                    If dtCheckStore.Rows.Count = 0 Then
                        tdbg.Bookmark = 0
                    Else
                        tdbg.Bookmark = findrowInGrid(tdbg, dtCheckStore.Rows(0).Item("CandidateID"), "CandidateID")
                    End If
                    Return False
                End If
            End If
        End If

        '***************************
        tdbg2.UpdateData()
        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_DayBD).ToString <> "" Then
                If tdbg2(i, COL2_MonthBD).ToString = "" Then
                    D99C0008.MsgL3(rL3("MSG000009"))
                    tabPage.SelectedTab = Tab1
                    tdbg2.Focus()
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_MonthBD
                    tdbg2.Bookmark = i
                    Return False
                End If
            End If

            If tdbg2(i, COL2_MonthBD).ToString <> "" Then
                If tdbg2(i, COL2_YearBD).ToString = "" Then
                    D99C0008.MsgL3(rL3("MSG000009"))
                    tabPage.SelectedTab = Tab1
                    tdbg2.Focus()
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_YearBD
                    tdbg2.Bookmark = i
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_LastName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_FirstName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim bAllowSave As Boolean = True
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        bAllowSave = AllowSave()
        If Not bAllowSave Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        '******* Thực thi store sinh mã ứng cử viên tự động ******************************
        If _autoCandidateID = 1 Then
            Dim sSQLL As String = ""
            sSQLL &= SQLStoreD09P2016.ToString & vbCrLf
            dtCandidateID = ReturnDataTable(sSQLL)
            Dim sMsg As String = ""
            If dtCandidateID.Rows.Count > 0 Then
                sMsg = dtCandidateID.Rows(0).Item("Message").ToString
                Dim bFontMessage As Boolean = False
                If dtCandidateID.Columns.Contains("FontMessage") Then bFontMessage = True
                If dtCandidateID.Rows(0).Item("Status").ToString = "0" Then
                    For i As Integer = 0 To dtCandidateID.Rows.Count - 1
                        tdbg(i, COL_CandidateID) = dtCandidateID.Rows(i).Item("CandidateID").ToString
                    Next
                    tdbg.UpdateData()
                    ExecuteSQL(SQLDeleteD09T6666.ToString)
                Else
                    Select Case dtCandidateID.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                    tdbcMethodID.Focus()
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    ExecuteSQL(SQLDeleteD09T6666.ToString)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                btnSave.Enabled = True
                btnClose.Enabled = True
                ExecuteSQL(SQLDeleteD09T6666.ToString)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If
        '*************************************
        sSQL.AppendLine(SQLInsertD25T1041s().ToString & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            btnSend.Enabled = True
            tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible = True
            _bSaved = True
            chkIsAttach.Enabled = True
            btnClose.Enabled = True
            candidateID = tdbg.Columns(COL_CandidateID).Text
            If sender IsNot Nothing Then btnNext.Text = rL3("Nhap__tiep")
            btnNext.Enabled = True
            btnNext.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcMethodID"

    Private Sub tdbcMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.LostFocus
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMethodID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMethodID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Function findrowInGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sValueFind As Object, ByVal sColName As String) As Integer
        ' get the currency manager that the grid is bound to
        Dim cm As CurrencyManager = CType(Me.BindingContext(tdbg.DataSource, tdbg.DataMember), CurrencyManager)
        ' get the property descriptor for the "integer" column
        Dim prop As System.ComponentModel.PropertyDescriptor = cm.GetItemProperties()(sColName)

        ' get the binding list
        Dim blist As System.ComponentModel.IBindingList = CType(cm.List, System.ComponentModel.IBindingList)

        ' find the newly added record
        Return blist.Find(prop, sValueFind)
    End Function '_findrow

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnNext.Focus()
        If btnNext.Focused = False Then Exit Sub
        '************************************
        If btnNext.Text = rL3("Luu_va_Nhap__tiep") Then
            btnSave_Click(Nothing, Nothing)
            If _bSaved = False OrElse bAllowSave = False Then Exit Sub
        End If
        btnNext.Text = rL3("Luu_va_Nhap__tiep")
        btnSave.Enabled = True
        '************************************
        chkIsAttach.Enabled = False
        chkIsAttach.Checked = False
        chkIsAttach_Click(Nothing, Nothing)
        '************************************
        dsGrid7.Clear()
        tdbg.Columns(COL_BatchID).Tag = ""
        '************************************
        LoadDataGrid()
        tdbg.Focus()
        tdbg.SplitIndex = 0
        tdbg.Col = COL_CandidateID
        tdbg.Row = 0
    End Sub

    Private Sub tdbg_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If e.Column.DataColumn.DataField <> "Button" Then Exit Sub
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TableName", "D25T1041")
        SetProperties(arrPro, "Key1ID", tdbg.Columns(COL_CandidateID).Text)
        SetProperties(arrPro, "Status", Convert.ToByte(1))
        SetProperties(arrPro, "bNewDatabase", True)
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
    End Sub

    Private Sub chkIsAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsAttach.Click
        If IsExist("Button") Then tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns("Button").Visible = chkIsAttach.Checked
    End Sub

    Private Function AllowSend() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim dr() As DataRow = dtGrid.Select("IsUsed = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Row = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Not AllowSend() Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s_Send())
        sSQL.Append(vbCrLf & SQLStoreD84P5000())
        Dim dtTemp As DataTable = ReturnDataTable(sSQL.ToString)
        If dtTemp.Rows.Count = 0 Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "drData", dtTemp.Rows(0))
        CallFormShowDialog("D84D1140", "D84F5000", arrPro)
        ExecuteSQL(SQLDeleteD09T6666)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 21/04/2014 08:46:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s_Send() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) = False Then Continue For
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD84P5000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/06/2014 04:12:37
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD84P5000() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tra du lieu cho cac bien khi goi form D84P5000" & vbCrLf)
        sSQL &= "Exec D84P5000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString("") 'VoucherID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1059
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 17/01/2017 08:59:51
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1059() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi giay to tuy than" & vbCrlf)
        sSQL &= "Exec D25P1059 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_SplitChange(sender As Object, e As EventArgs) Handles tdbg.SplitChange

    End Sub
End Class

