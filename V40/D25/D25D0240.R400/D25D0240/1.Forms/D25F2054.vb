Public Class D25F2054

    Private _sRecPositionID As String
    Private _sDateTo As String
    Private _sDateForm As String
    Private _sBlockID As String
    Private _sTeamID As String
    Private _sDepartmentID As String
    Private _sDivitionID As String
    Private _formIDPermission As String = "D25F2054"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _bSaveOK As Boolean = False
    Public ReadOnly Property bSaveOK() As Boolean
        Get
            Return _bSaveOK
        End Get
    End Property


    Public WriteOnly Property sDivitionID As String
        Set(ByVal Value As String)
            _sDivitionID = Value
        End Set
    End Property

    Public WriteOnly Property sDepartmentID As String
        Set(ByVal Value As String)
            _sDepartmentID = Value
        End Set
    End Property

    Public WriteOnly Property sTeamID As String
        Set(ByVal Value As String)
            _sTeamID = Value
        End Set
    End Property

    Public WriteOnly Property sBlockID As String
        Set(ByVal Value As String)
            _sBlockID = Value
        End Set
    End Property

    Public WriteOnly Property sDateForm As String
        Set(ByVal Value As String)
            _sDateForm = Value
        End Set
    End Property

    Public WriteOnly Property sDateTo As String
        Set(ByVal Value As String)
            _sDateTo = Value
        End Set
    End Property
    
    Public WriteOnly Property sRecPositionID As String
        Set(ByVal Value As String)
            _sRecPositionID = Value
        End Set
    End Property



    '#Region "Const of tdbg - Total of Columns: 108"
    '    Private Const COL_TransID As String = "TransID"                           ' TransID
    '    Private Const COL_IsUsed As String = "IsUsed"                             ' Chọn
    '    Private Const COL_CandidateID As String = "CandidateID"                   ' Mã ứng viên
    '    Private Const COL_CandidateName As String = "CandidateName"               ' Họ và tên
    '    Private Const COL_OtherValue As String = "OtherValue"                     ' OtherValue
    '    Private Const COL_FirstName As String = "FirstName"                       ' FirstName
    '    Private Const COL_MiddleName As String = "MiddleName"                     ' MiddleName
    '    Private Const COL_LastName As String = "LastName"                         ' LastName
    '    Private Const COL_EmployeeID As String = "EmployeeID"                     ' Mã NV
    '    Private Const COL_DivisionID As String = "DivisionID"                     ' Đơn vị
    '    Private Const COL_DepartmentID As String = "DepartmentID"                 ' Phòng ban
    '    Private Const COL_TeamID As String = "TeamID"                             ' Tổ nhóm
    '    Private Const COL_DutyID As String = "DutyID"                             ' Chức vụ
    '    Private Const COL_WorkID As String = "WorkID"                             ' Công việc
    '    Private Const COL_BeginDate As String = "BeginDate"                       ' Ngày vào làm
    '    Private Const COL_Telephone As String = "Telephone"                       ' Điện thoại
    '    Private Const COL_Email As String = "Email"                               ' Email
    '    Private Const COL_NumIDCard As String = "NumIDCard"                       ' Số CMND
    '    Private Const COL_NumIDCardDate As String = "NumIDCardDate"               ' Ngày cấp CMND
    '    Private Const COL_IssuedPlaceID As String = "IssuedPlaceID"               ' Nơi cấp CMND
    '    Private Const COL_BirthDate As String = "BirthDate"                       ' Ngày sinh
    '    Private Const COL_NativePlace As String = "NativePlace"                   ' Quê quán
    '    Private Const COL_EthnicID As String = "EthnicID"                         ' Dân tộc
    '    Private Const COL_ReligionID As String = "ReligionID"                     ' Tốn giáo
    '    Private Const COL_CountryID As String = "CountryID"                       ' Quốc tịch
    '    Private Const COL_Sex As String = "Sex"                                   ' Giới tính
    '    Private Const COL_SexName As String = "SexName"                                   ' Giới tính
    '    Private Const COL_WorkingPlace As String = "WorkingPlace"                 ' Địa điểm làm việc
    '    Private Const COL_EmployeeTypeID As String = "EmployeeTypeID"             ' Đối tượng lao động
    '    Private Const COL_WorkingStatusID As String = "WorkingStatusID"           ' Hình thức làm việc
    '    Private Const COL_StatusID As String = "StatusID"                         ' Trạng thái làm việc
    '    Private Const COL_TrialPeriod As String = "TrialPeriod"                   ' Thời gian thử việc
    '    Private Const COL_TrialDateFrom As String = "TrialDateFrom"               ' Ngày bắt đầu thử việc
    '    Private Const COL_TrialDateTo As String = "TrialDateTo"                   ' Ngày kết thúc thử việc
    '    Private Const COL_NoviciatePeriod As String = "NoviciatePeriod"           ' Thời gian học việc
    '    Private Const COL_NoviciateDateFrom As String = "NoviciateDateFrom"       ' Ngày bắt đầu học việc
    '    Private Const COL_NoviciateDateTo As String = "NoviciateDateTo"           ' Ngày kết thúc học việc
    '    Private Const COL_EducationLevelID As String = "EducationLevelID"         ' Trình độ học vấn
    '    Private Const COL_ProfessionalLevelID As String = "ProfessionalLevelID"   ' Trình độ chuyên môn
    '    Private Const COL_IsForeigner As String = "IsForeigner"                   ' Là người nước ngoài
    '    Private Const COL_AttendanceCardNo As String = "AttendanceCardNo"         ' Mã thẻ chấm công
    '    Private Const COL_EffectiveDateFrom As String = "EffectiveDateFrom"       ' Ngày hiệu lực MTCC
    '    Private Const COL_SalaryObjectID As String = "SalaryObjectID"             ' Đối tượng tính lương
    '    Private Const COL_ShirtSize As String = "ShirtSize"                       ' Kích cỡ áo
    '    Private Const COL_TrousersSize As String = "TrousersSize"                 ' Kích cỡ quần
    '    Private Const COL_ShoesSize As String = "ShoesSize"                       ' Kích cỡ giày
    '    Private Const COL_ClothesSize As String = "ClothesSize"                   ' Kích cỡ đồ sạch
    '    Private Const COL_DirectManagerID As String = "DirectManagerID"           ' Người quản lý trực tiếp
    '    Private Const COL_BPPLabelID As String = "BPPLabelID"                     ' Tỉnh/ Thành phố (NS)
    '    Private Const COL_BirthPlaceProvinceID As String = "BirthPlaceProvinceID" ' CT Tỉnh/ Thành phố (NS)
    '    Private Const COL_BPDLabelID As String = "BPDLabelID"                     ' Quận/ Huyện (NS)
    '    Private Const COL_BirthPlaceDistrictID As String = "BirthPlaceDistrictID" ' CT Quận/ Huyện (NS)
    '    Private Const COL_BPWLabelID As String = "BPWLabelID"                     ' Phường / Xã (NS)
    '    Private Const COL_BirthPlaceWardID As String = "BirthPlaceWardID"         ' CT Phường / Xã (NS)
    '    Private Const COL_BirthPlace As String = "BirthPlace"                     ' Nơi sinh
    '    Private Const COL_CAPLabelID As String = "CAPLabelID"                     ' Tỉnh/ Thành phố (Thường trú)
    '    Private Const COL_ConAddressProvinceID As String = "ConAddressProvinceID" ' CT Tỉnh/ Thành phố (Thường trú)
    '    Private Const COL_CADLabelID As String = "CADLabelID"                     ' Quận/ Huyện (Thường trú)
    '    Private Const COL_ConAddressDistrictID As String = "ConAddressDistrictID" ' CT Quận/ Huyện (Thường trú)
    '    Private Const COL_CAWLabelID As String = "CAWLabelID"                     ' Phường / Xã (Thường trú)
    '    Private Const COL_ConAddressWardID As String = "ConAddressWardID"         ' CT Phường / Xã Thường trú)
    '    Private Const COL_ConAddressStreet As String = "ConAddressStreet"         ' Số nhà (Thường trú)
    '    Private Const COL_RAPLabelID As String = "RAPLabelID"                     ' Tỉnh/ Thành phố (Tạm trú)
    '    Private Const COL_ResAddressProvinceID As String = "ResAddressProvinceID" ' CT Tỉnh/ Thành phố (Tạm trú)
    '    Private Const COL_RADLabelID As String = "RADLabelID"                     ' Quận/ Huyện (Tạm trú)
    '    Private Const COL_ResAddressDistrictID As String = "ResAddressDistrictID" ' CT Quận/ Huyện (Tạm trú)
    '    Private Const COL_RAWLabelID As String = "RAWLabelID"                     ' Phường / Xã (Tạm trú)
    '    Private Const COL_ResAddressWardID As String = "ResAddressWardID"         ' CT Phường / Xã (Tạm trú)
    '    Private Const COL_ResAddressStreet As String = "ResAddressStreet"         ' Số nhà (Tạm trú)
    '    Private Const COL_SalEmpGroupID As String = "SalEmpGroupID"               ' Nhóm lương
    '    Private Const COL_Note01 As String = "Note01"                             ' Ghi chú
    '    Private Const COL_BaseSalary01 As String = "BaseSalary01"                 ' BaseSalary01
    '    Private Const COL_BaseSalary02 As String = "BaseSalary02"                 ' BaseSalary02
    '    Private Const COL_BaseSalary03 As String = "BaseSalary03"                 ' BaseSalary03
    '    Private Const COL_BaseSalary04 As String = "BaseSalary04"                 ' BaseSalary04
    '    Private Const COL_SalCoefficient01 As String = "SalCoefficient01"         ' SalCoefficient01
    '    Private Const COL_SalCoefficient02 As String = "SalCoefficient02"         ' SalCoefficient02
    '    Private Const COL_SalCoefficient03 As String = "SalCoefficient03"         ' SalCoefficient03
    '    Private Const COL_SalCoefficient04 As String = "SalCoefficient04"         ' SalCoefficient04
    '    Private Const COL_SalCoefficient05 As String = "SalCoefficient05"         ' SalCoefficient05
    '    Private Const COL_SalCoefficient06 As String = "SalCoefficient06"         ' SalCoefficient06
    '    Private Const COL_SalCoefficient07 As String = "SalCoefficient07"         ' SalCoefficient07
    '    Private Const COL_SalCoefficient08 As String = "SalCoefficient08"         ' SalCoefficient08
    '    Private Const COL_SalCoefficient09 As String = "SalCoefficient09"         ' SalCoefficient09
    '    Private Const COL_SalCoefficient10 As String = "SalCoefficient10"         ' SalCoefficient10
    '    Private Const COL_SalCoefficient11 As String = "SalCoefficient11"         ' SalCoefficient11
    '    Private Const COL_SalCoefficient12 As String = "SalCoefficient12"         ' SalCoefficient12
    '    Private Const COL_SalCoefficient13 As String = "SalCoefficient13"         ' SalCoefficient13
    '    Private Const COL_SalCoefficient14 As String = "SalCoefficient14"         ' SalCoefficient14
    '    Private Const COL_SalCoefficient15 As String = "SalCoefficient15"         ' SalCoefficient15
    '    Private Const COL_SalCoefficient16 As String = "SalCoefficient16"         ' SalCoefficient16
    '    Private Const COL_SalCoefficient17 As String = "SalCoefficient17"         ' SalCoefficient17
    '    Private Const COL_SalCoefficient18 As String = "SalCoefficient18"         ' SalCoefficient18
    '    Private Const COL_SalCoefficient19 As String = "SalCoefficient19"         ' SalCoefficient19
    '    Private Const COL_SalCoefficient20 As String = "SalCoefficient20"         ' SalCoefficient20
    '    Private Const COL_OfficalTitleID As String = "OfficalTitleID"             ' Ngạch lương 1 
    '    Private Const COL_SalaryLevelID As String = "SalaryLevelID"               ' Bậc lương 1
    '    Private Const COL_SaCoefficient As String = "SaCoefficient"             ' SaCoefficient 
    '    Private Const COL_SaCoefficient12 As String = "SaCoefficient12"           ' SaCoefficient12
    '    Private Const COL_SaCoefficient13 As String = "SaCoefficient13"           ' SaCoefficient13
    '    Private Const COL_SaCoefficient14 As String = "SaCoefficient14"           ' SaCoefficient14
    '    Private Const COL_SaCoefficient15 As String = "SaCoefficient15"           ' SaCoefficient15
    '    Private Const COL_OfficalTitleID2 As String = "OfficalTitleID2"           ' Ngạch lương 2 
    '    Private Const COL_SalaryLevelID2 As String = "SalaryLevelID2"             ' Bậc lương 2
    '    Private Const COL_SaCoefficient2 As String = "SaCoefficient2"             ' SaCoefficient2
    '    Private Const COL_SaCoefficient22 As String = "SaCoefficient22"           ' SaCoefficient22
    '    Private Const COL_SaCoefficient23 As String = "SaCoefficient23"           ' SaCoefficient23
    '    Private Const COL_SaCoefficient24 As String = "SaCoefficient24"           ' SaCoefficient24
    '    Private Const COL_SaCoefficient25 As String = "SaCoefficient25"           ' SaCoefficient25
    '#End Region


#Region "Const of tdbg - Total of Columns: 129"
    Private Const COL_TransID As String = "TransID"                           ' TransID
    Private Const COL_IsUsed As String = "IsUsed"                             ' Chọn
    Private Const COL_CandidateID As String = "CandidateID"                   ' Mã ứng viên
    Private Const COL_CandidateName As String = "CandidateName"               ' Họ và tên
    Private Const COL_OtherValue As String = "OtherValue"                     ' OtherValue
    Private Const COL_FirstName As String = "FirstName"                       ' FirstName
    Private Const COL_MiddleName As String = "MiddleName"                     ' MiddleName
    Private Const COL_LastName As String = "LastName"                         ' LastName
    Private Const COL_EmployeeID As String = "EmployeeID"                     ' Mã NV
    Private Const COL_DivisionID As String = "DivisionID"                     ' Đơn vị
    Private Const COL_DepartmentID As String = "DepartmentID"                 ' Phòng ban
    Private Const COL_TeamID As String = "TeamID"                             ' Tổ nhóm
    Private Const COL_DutyID As String = "DutyID"                             ' Chức vụ
    Private Const COL_WorkID As String = "WorkID"                             ' Công việc
    Private Const COL_BeginDate As String = "BeginDate"                       ' Ngày vào làm
    Private Const COL_Telephone As String = "Telephone"                       ' Điện thoại
    Private Const COL_Email As String = "Email"                               ' Email
    Private Const COL_NumIDCard As String = "NumIDCard"                       ' Số CMND
    Private Const COL_NumIDCardDate As String = "NumIDCardDate"               ' Ngày cấp CMND
    Private Const COL_IssuedPlaceID As String = "IssuedPlaceID"               ' Nơi cấp CMND
    Private Const COL_BirthDate As String = "BirthDate"                       ' Ngày sinh
    Private Const COL_NativePlace As String = "NativePlace"                   ' Quê quán
    Private Const COL_EthnicID As String = "EthnicID"                         ' Dân tộc
    Private Const COL_ReligionID As String = "ReligionID"                     ' Tốn giáo
    Private Const COL_CountryID As String = "CountryID"                       ' Quốc tịch
    Private Const COL_Sex As String = "Sex"                                   ' Sex
    Private Const COL_SexName As String = "SexName"                           ' Giới tính
    Private Const COL_WorkingPlace As String = "WorkingPlace"                 ' Địa điểm làm việc
    Private Const COL_EmployeeTypeID As String = "EmployeeTypeID"             ' Đối tượng lao động
    Private Const COL_WorkingStatusID As String = "WorkingStatusID"           ' Hình thức làm việc
    Private Const COL_StatusID As String = "StatusID"                         ' Trạng thái làm việc
    Private Const COL_TrialPeriod As String = "TrialPeriod"                   ' Thời gian thử việc
    Private Const COL_TrialDateFrom As String = "TrialDateFrom"               ' Ngày bắt đầu thử việc
    Private Const COL_TrialDateTo As String = "TrialDateTo"                   ' Ngày kết thúc thử việc
    Private Const COL_NoviciatePeriod As String = "NoviciatePeriod"           ' Thời gian học việc
    Private Const COL_NoviciateDateFrom As String = "NoviciateDateFrom"       ' Ngày bắt đầu học việc
    Private Const COL_NoviciateDateTo As String = "NoviciateDateTo"           ' Ngày kết thúc học việc
    Private Const COL_EducationLevelID As String = "EducationLevelID"         ' Trình độ học vấn
    Private Const COL_ProfessionalLevelID As String = "ProfessionalLevelID"   ' Trình độ chuyên môn
    Private Const COL_IsForeigner As String = "IsForeigner"                   ' Là người nước ngoài
    Private Const COL_AttendanceCardNo As String = "AttendanceCardNo"         ' Mã thẻ chấm công
    Private Const COL_EffectiveDateFrom As String = "EffectiveDateFrom"       ' Ngày hiệu lực MTCC
    Private Const COL_SalaryObjectID As String = "SalaryObjectID"             ' Đối tượng tính lương
    Private Const COL_ShirtSize As String = "ShirtSize"                       ' Kích cỡ áo
    Private Const COL_TrousersSize As String = "TrousersSize"                 ' Kích cỡ quần
    Private Const COL_ShoesSize As String = "ShoesSize"                       ' Kích cỡ giày
    Private Const COL_ClothesSize As String = "ClothesSize"                   ' Kích cỡ đồ sạch
    Private Const COL_DirectManagerID As String = "DirectManagerID"           ' Người quản lý trực tiếp
    Private Const COL_BPPLabelID As String = "BPPLabelID"                     ' Tỉnh/ Thành phố (NS)
    Private Const COL_BirthPlaceProvinceID As String = "BirthPlaceProvinceID" ' CT Tỉnh/ Thành phố (NS)
    Private Const COL_BPDLabelID As String = "BPDLabelID"                     ' Quận/ Huyện (NS)
    Private Const COL_BirthPlaceDistrictID As String = "BirthPlaceDistrictID" ' CT Quận/ Huyện (NS)
    Private Const COL_BPWLabelID As String = "BPWLabelID"                     ' Phường / Xã (NS)
    Private Const COL_BirthPlaceWardID As String = "BirthPlaceWardID"         ' CT Phường / Xã (NS)
    Private Const COL_BirthPlace As String = "BirthPlace"                     ' Nơi sinh
    Private Const COL_CAPLabelID As String = "CAPLabelID"                     ' Tỉnh/ Thành phố (Thường trú)
    Private Const COL_ConAddressProvinceID As String = "ConAddressProvinceID" ' CT Tỉnh/ Thành phố (Thường trú)
    Private Const COL_CADLabelID As String = "CADLabelID"                     ' Quận/ Huyện (Thường trú)
    Private Const COL_ConAddressDistrictID As String = "ConAddressDistrictID" ' CT Quận/ Huyện (Thường trú)
    Private Const COL_CAWLabelID As String = "CAWLabelID"                     ' Phường / Xã (Thường trú)
    Private Const COL_ConAddressWardID As String = "ConAddressWardID"         ' CT Phường / Xã Thường trú)
    Private Const COL_ConAddressStreet As String = "ConAddressStreet"         ' Số nhà (Thường trú)
    Private Const COL_RAPLabelID As String = "RAPLabelID"                     ' Tỉnh/ Thành phố (Tạm trú)
    Private Const COL_ResAddressProvinceID As String = "ResAddressProvinceID" ' CT Tỉnh/ Thành phố (Tạm trú)
    Private Const COL_RADLabelID As String = "RADLabelID"                     ' Quận/ Huyện (Tạm trú)
    Private Const COL_ResAddressDistrictID As String = "ResAddressDistrictID" ' CT Quận/ Huyện (Tạm trú)
    Private Const COL_RAWLabelID As String = "RAWLabelID"                     ' Phường / Xã (Tạm trú)
    Private Const COL_ResAddressWardID As String = "ResAddressWardID"         ' CT Phường / Xã (Tạm trú)
    Private Const COL_ResAddressStreet As String = "ResAddressStreet"         ' Số nhà (Tạm trú)
    Private Const COL_SalEmpGroupID As String = "SalEmpGroupID"               ' Nhóm lương
    Private Const COL_Note01 As String = "Note01"                             ' Ghi chú
    Private Const COL_Ref01 As String = "Ref01"                               ' Ref01
    Private Const COL_Ref02 As String = "Ref02"                               ' Ref02
    Private Const COL_Ref03 As String = "Ref03"                               ' Ref03
    Private Const COL_Ref04 As String = "Ref04"                               ' Ref04
    Private Const COL_Ref05 As String = "Ref05"                               ' Ref05
    Private Const COL_Ref06 As String = "Ref06"                               ' Ref06
    Private Const COL_Ref07 As String = "Ref07"                               ' Ref07
    Private Const COL_Ref08 As String = "Ref08"                               ' Ref08
    Private Const COL_Ref09 As String = "Ref09"                               ' Ref09
    Private Const COL_Ref10 As String = "Ref10"                               ' Ref10
    Private Const COL_Ref11 As String = "Ref11"                               ' Ref11
    Private Const COL_Ref12 As String = "Ref12"                               ' Ref12
    Private Const COL_Ref13 As String = "Ref13"                               ' Ref13
    Private Const COL_Ref14 As String = "Ref14"                               ' Ref14
    Private Const COL_Ref15 As String = "Ref15"                               ' Ref15
    Private Const COL_Ref16 As String = "Ref16"                               ' Ref16
    Private Const COL_Ref17 As String = "Ref17"                               ' Ref17
    Private Const COL_Ref18 As String = "Ref18"                               ' Ref18
    Private Const COL_Ref19 As String = "Ref19"                               ' Ref19
    Private Const COL_Ref20 As String = "Ref20"                               ' Ref20
    Private Const COL_BaseSalary01 As String = "BaseSalary01"                 ' BaseSalary01
    Private Const COL_BaseSalary02 As String = "BaseSalary02"                 ' BaseSalary02
    Private Const COL_BaseSalary03 As String = "BaseSalary03"                 ' BaseSalary03
    Private Const COL_BaseSalary04 As String = "BaseSalary04"                 ' BaseSalary04
    Private Const COL_SalCoefficient01 As String = "SalCoefficient01"         ' SalCoefficient01
    Private Const COL_SalCoefficient02 As String = "SalCoefficient02"         ' SalCoefficient02
    Private Const COL_SalCoefficient03 As String = "SalCoefficient03"         ' SalCoefficient03
    Private Const COL_SalCoefficient04 As String = "SalCoefficient04"         ' SalCoefficient04
    Private Const COL_SalCoefficient05 As String = "SalCoefficient05"         ' SalCoefficient05
    Private Const COL_SalCoefficient06 As String = "SalCoefficient06"         ' SalCoefficient06
    Private Const COL_SalCoefficient07 As String = "SalCoefficient07"         ' SalCoefficient07
    Private Const COL_SalCoefficient08 As String = "SalCoefficient08"         ' SalCoefficient08
    Private Const COL_SalCoefficient09 As String = "SalCoefficient09"         ' SalCoefficient09
    Private Const COL_SalCoefficient10 As String = "SalCoefficient10"         ' SalCoefficient10
    Private Const COL_SalCoefficient11 As String = "SalCoefficient11"         ' SalCoefficient11
    Private Const COL_SalCoefficient12 As String = "SalCoefficient12"         ' SalCoefficient12
    Private Const COL_SalCoefficient13 As String = "SalCoefficient13"         ' SalCoefficient13
    Private Const COL_SalCoefficient14 As String = "SalCoefficient14"         ' SalCoefficient14
    Private Const COL_SalCoefficient15 As String = "SalCoefficient15"         ' SalCoefficient15
    Private Const COL_SalCoefficient16 As String = "SalCoefficient16"         ' SalCoefficient16
    Private Const COL_SalCoefficient17 As String = "SalCoefficient17"         ' SalCoefficient17
    Private Const COL_SalCoefficient18 As String = "SalCoefficient18"         ' SalCoefficient18
    Private Const COL_SalCoefficient19 As String = "SalCoefficient19"         ' SalCoefficient19
    Private Const COL_SalCoefficient20 As String = "SalCoefficient20"         ' SalCoefficient20
    Private Const COL_OfficalTitleID As String = "OfficalTitleID"             ' Ngạch lương 1 
    Private Const COL_SalaryLevelID As String = "SalaryLevelID"               ' Bậc lương 1
    Private Const COL_SaCoefficient As String = "SaCoefficient"               ' SaCoefficient
    Private Const COL_SaCoefficient12 As String = "SaCoefficient12"           ' SaCoefficient12
    Private Const COL_SaCoefficient13 As String = "SaCoefficient13"           ' SaCoefficient13
    Private Const COL_SaCoefficient14 As String = "SaCoefficient14"           ' SaCoefficient14
    Private Const COL_SaCoefficient15 As String = "SaCoefficient15"           ' SaCoefficient15
    Private Const COL_OfficalTitleID2 As String = "OfficalTitleID2"           ' Ngạch lương 2 
    Private Const COL_SalaryLevelID2 As String = "SalaryLevelID2"             ' Bậc lương 2
    Private Const COL_SaCoefficient2 As String = "SaCoefficient2"             ' SaCoefficient2
    Private Const COL_SaCoefficient22 As String = "SaCoefficient22"           ' SaCoefficient22
    Private Const COL_SaCoefficient23 As String = "SaCoefficient23"           ' SaCoefficient23
    Private Const COL_SaCoefficient24 As String = "SaCoefficient24"           ' SaCoefficient24
    Private Const COL_SaCoefficient25 As String = "SaCoefficient25"           ' SaCoefficient25
#End Region



#Region "Const of tdbgAlter - Total of Columns: 3"
    Private Const COLA_EmployeeID As Integer = 0       ' Mã nhân viên
    Private Const COLA_EmployeeName As Integer = 1     ' Tên nhân viên
    Private Const COLA_AttendanceCardNo As Integer = 2 ' Mã chấm công
#End Region





    Private dtGrid As DataTable
    Private dtBlockID, dtDepartmentID, dtTeamID As DataTable
    Private dtCaption, dtSalBase, dtSalCoeff, dtOLSC, dtRefID As DataTable
    Private dtOfficialTitleID, dtOfficialTitleID2, dtSalaryLevelID As DataTable
    Private dtDistrict, dtWard As DataTable
    Dim bEmployeeAuto As Boolean = False
    Dim bIsAutoAttCardNo As Boolean = False
    Dim bIsUseBlockID As Boolean = False
    Dim bIsAllDivision As Boolean = False

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub D25F2054_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940

        ResetColorGrid(tdbg)
        ResetSplitDividerSize(tdbg, tdbgAlter)
        gbEnabledUseFind = False

        LoadSystemD09()

        LoadTDBCombo()
        LoadTDBDropDown()
        LoadDefault()

        btnFilter.Focus()
        btnFilter_Click(Nothing, Nothing)

        LoadLanguage()
        '****************************
        dtF12 = Nothing
        CallD99U1111()
        '****************************
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_BeginDate, COL_NumIDCardDate, COL_TrialDateFrom, COL_TrialDateTo, COL_NoviciateDateFrom, COL_NoviciateDateTo, COL_EffectiveDateFrom)
        SetBackColorObligatory()

        tdbg_LockedColumns()
        tdbg_NumberFormat()

        GridCaption()

        SetResolutionForm(Me)


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_thong_tin_trung_tuyen") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'CËp nhËt th¤ng tin tròng tuyÓn
        '================================================================ 
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblDate.Text = rl3("Ngay_quyet_dinh_tuyen_dung") 'Ngày quyết định tuyển dụng
        lblMethodID.Text = rl3("PP_tao_ma_NV_tu_dong") 'PP tạo mã NV tự động
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblAttendCarNoMethodID.Text = rl3("PP_tao_ma_cham_cong_tu_dong") 'PP tạo mã chấm công tự động
        lblMessage2.Text = rl3("Ban_phai_nhap_lai_ma_nhan_vien_khac") 'Bạn phải nhập lại mã nhân viên khác
        lblMessage.Text = rl3("Cac_ma_nhan_vien_da_ton_tai_Ban_khong_duoc_phep_luu") 'Các mã nhân viên đã tồn tại. Bạn không được phép lưu
        lblAlter.Text = rl3("Thong_baoU") 'Thông báo
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnInfoSalary.Text = rl3("Thong_tin_luong") 'Thông tin lương
        btnInfo.Text = rl3("Thong_tin_HSNV") 'Thông tin HSNV
        btnShowColumns.Text = rl3("Hien_thi") 'Hiển thị
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnOK.Text = rl3("_OK") '&OK
        '================================================================ 
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcAttendCarNoMethodID.Columns("MethodID").Caption = rL3("Ma") 'Mã
        tdbcAttendCarNoMethodID.Columns("MethodName").Caption = rL3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên

        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdDivisionID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdDivisionID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbdDutyID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdDutyID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdWorkID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdWorkID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCountryID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdCountryID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdEthnicID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdEthnicID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdReligionID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdReligionID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdEducationLevelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdEducationLevelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdProfessionalLevelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdProfessionalLevelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdEmployeeTypeID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdEmployeeTypeID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdWorkingTypeID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdWorkingTypeID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdStatusID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdStatusID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdSalaryObjectID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdSalaryObjectID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdTrousersSize.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdTrousersSize.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdShirtSize.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdShirtSize.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdShoesSize.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdShoesSize.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdClothesSize.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdClothesSize.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdSalEmpGroupID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdSalEmpGroupID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdSex.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdSex.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdDirectManagerID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdDirectManagerID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBPPLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBPPLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCAPLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdCAPLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdRAPLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdRAPLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBPDLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBPDLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCADLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdCADLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdRADLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdRADLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBPWLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBPWLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCAWLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdCAWLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdRAWLabelID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdRAWLabelID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdPopulationID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdPopulationID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdIssuedPlaceID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdIssuedPlaceID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBirthPlaceProvinceID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBirthPlaceProvinceID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdResAddressProvinceID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdResAddressProvinceID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBirthPlaceDistrictID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBirthPlaceDistrictID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdConAddressDistrictID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdConAddressDistrictID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdResAddressDistrictID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdResAddressDistrictID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdBirthPlaceWardID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdBirthPlaceWardID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdConAddressWardID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdConAddressWardID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdResAddressWardID.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbdResAddressWardID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdOfficialTitleID.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbdOfficialTitleID.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbdOfficialTitleID2.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbdOfficialTitleID2.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbdSalaryLevelID.Columns("SalaryLevelID").Caption = rl3("Ma") 'Mã
        tdbdSalaryLevelID2.Columns("SalaryLevelID").Caption = rl3("Ma") 'Mã
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_CandidateID).Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_DivisionID).Caption = rl3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_DutyID).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_WorkID).Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns(COL_BeginDate).Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_Telephone).Caption = rl3("Dien_thoai") 'Điện thoại
        tdbg.Columns(COL_NumIDCard).Caption = rl3("So_CMND") 'Số CMND
        tdbg.Columns(COL_NumIDCardDate).Caption = rl3("Ngay_cap_CMND") 'Ngày cấp CMND
        tdbg.Columns(COL_IssuedPlaceID).Caption = rl3("Noi_cap_CMND") 'Nơi cấp CMND
        tdbg.Columns(COL_Birthdate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_NativePlace).Caption = rl3("Que_quan") 'Quê quán
        tdbg.Columns(COL_EthnicID).Caption = rl3("Dan_toc") 'Dân tộc
        tdbg.Columns(COL_ReligionID).Caption = rl3("Ton_giaoU") 'Tốn giáo
        tdbg.Columns(COL_CountryID).Caption = rl3("Quoc_tich") 'Quốc tịch
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_WorkingPlace).Caption = rl3("Dia_diem_lam_viec") 'Địa điểm làm việc
        tdbg.Columns(COL_EmployeeTypeID).Caption = rl3("Doi_tuong_lao_dong") 'Đối tượng lao động
        tdbg.Columns(COL_WorkingStatusID).Caption = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        tdbg.Columns(COL_StatusID).Caption = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbg.Columns(COL_TrialPeriod).Caption = rl3("Thoi_gian_thu_viec") 'Thời gian thử việc
        tdbg.Columns(COL_TrialDateFrom).Caption = rl3("Ngay_bat_dau_thu_viec") 'Ngày bắt đầu thử việc
        tdbg.Columns(COL_TrialDateTo).Caption = rl3("Ngay_ket_thuc_thu_viec") 'Ngày kết thúc thử việc
        tdbg.Columns(COL_NoviciatePeriod).Caption = rl3("Thoi_gian_hoc_viec") 'Thời gian học việc
        tdbg.Columns(COL_NoviciateDateFrom).Caption = rl3("Ngay_bat_dau_hoc_viec") 'Ngày bắt đầu học việc
        tdbg.Columns(COL_NoviciateDateTo).Caption = rl3("Ngay_ket_thuc_hoc_viec") 'Ngày kết thúc học việc
        tdbg.Columns(COL_EducationLevelID).Caption = rl3("Trinh_do_van_hoa_U") 'Trình độ học vấn
        tdbg.Columns(COL_ProfessionalLevelID).Caption = rl3("Trinh_do_chuyen_mon_U") 'Trình độ chuyên môn
        tdbg.Columns(COL_IsForeigner).Caption = rl3("La_nguoi_nuoc_ngoai") 'Là người nước ngoài
        tdbg.Columns(COL_AttendanceCardNo).Caption = rl3("Ma_the_cham_cong") 'Mã thẻ chấm công
        tdbg.Columns(COL_EffectiveDateFrom).Caption = rl3("Ngay_hieu_luc_MTCC") 'Ngày hiệu lực MTCC
        tdbg.Columns(COL_SalaryObjectID).Caption = rl3("Doi_tuong_tinh_luongU") 'Đối tượng tính lương
        tdbg.Columns(COL_ShirtSize).Caption = rl3("Kich_co_ao") 'Kích cỡ áo
        tdbg.Columns(COL_TrousersSize).Caption = rl3("Kich_co_quan") 'Kích cỡ quần
        tdbg.Columns(COL_ShoesSize).Caption = rl3("Kich_co_giay") 'Kích cỡ giày
        tdbg.Columns(COL_ClothesSize).Caption = rl3("Kich_co_do_sach") 'Kích cỡ đồ sạch
        tdbg.Columns(COL_DirectManagerID).Caption = rl3("Nguoi_quan_ly_truc_tiepU") 'Người quản lý trực tiếp
        tdbg.Columns(COL_BPPLabelID).Caption = rl3("Tinh_Thanh_pho_(NS)") 'Tỉnh/ Thành phố (NS)
        tdbg.Columns(COL_BirthPlaceProvinceID).Caption = rl3("CT_Tinh_Thanh_pho_(NS)") 'CT Tỉnh/ Thành phố (NS)
        tdbg.Columns(COL_BPDLabelID).Caption = rl3("Quan_Huyen_(NS)") 'Quận/ Huyện (NS)
        tdbg.Columns(COL_BirthPlaceDistrictID).Caption = rl3("CT_Quan_Huyen_(NS)") 'CT Quận/ Huyện (NS)
        tdbg.Columns(COL_BPWLabelID).Caption = rl3("Phuong__Xa_(NS)") 'Phường / Xã (NS)
        tdbg.Columns(COL_BirthPlaceWardID).Caption = rl3("CT_Phuong__Xa_(NS)") 'CT Phường / Xã (NS)
        tdbg.Columns(COL_BirthPlace).Caption = rl3("Noi_sinh") 'Nơi sinh
        tdbg.Columns(COL_CAPLabelID).Caption = rl3("Tinh_Thanh_pho_(Thuong_tru)") 'Tỉnh/ Thành phố (Thường trú)
        tdbg.Columns(COL_ConAddressProvinceID).Caption = rl3("CT_Tinh_Thanh_pho_(Thuong_tru)") 'CT Tỉnh/ Thành phố (Thường trú)
        tdbg.Columns(COL_CADLabelID).Caption = rl3("Quan_Huyen_(Thuong_tru)") 'Quận/ Huyện (Thường trú)
        tdbg.Columns(COL_ConAddressDistrictID).Caption = rl3("CT_Quan_Huyen_(Thuong_tru)") 'CT Quận/ Huyện (Thường trú)
        tdbg.Columns(COL_CAWLabelID).Caption = rl3("Phuong__Xa_(Thuong_tru)") 'Phường / Xã (Thường trú)
        tdbg.Columns(COL_ConAddressWardID).Caption = rl3("CT_Phuong__Xa_Thuong_tru)") 'CT Phường / Xã Thường trú)
        tdbg.Columns(COL_ConAddressStreet).Caption = rl3("So_nha_(Thuong_tru)") 'Số nhà (Thường trú)
        tdbg.Columns(COL_RAPLabelID).Caption = rl3("Tinh_Thanh_pho_(Tam_tru)") 'Tỉnh/ Thành phố (Tạm trú)
        tdbg.Columns(COL_ResAddressProvinceID).Caption = rl3("CT_Tinh_Thanh_pho_(Tam_tru)") 'CT Tỉnh/ Thành phố (Tạm trú)
        tdbg.Columns(COL_RADLabelID).Caption = rl3("Quan_Huyen_(Tam_tru)") 'Quận/ Huyện (Tạm trú)
        tdbg.Columns(COL_ResAddressDistrictID).Caption = rl3("CT_Quan_Huyen_(Tam_tru)") 'CT Quận/ Huyện (Tạm trú)
        tdbg.Columns(COL_RAWLabelID).Caption = rl3("Phuong__Xa_(Tam_tru)") 'Phường / Xã (Tạm trú)
        tdbg.Columns(COL_ResAddressWardID).Caption = rl3("CT_Phuong__Xa_(Tam_tru)") 'CT Phường / Xã (Tạm trú)
        tdbg.Columns(COL_ResAddressStreet).Caption = rl3("So_nha_(Tam_tru)") 'Số nhà (Tạm trú)
        tdbg.Columns(COL_SalEmpGroupID).Caption = rl3("Nhom_luong") 'Nhóm lương
        tdbg.Columns(COL_Note01).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_OfficalTitleID).Caption = rl3("Ngach_luong") & " 1 " 'Ngạch lương 1 
        tdbg.Columns(COL_SalaryLevelID).Caption = rl3("Bac_luong") & " 1" 'Bậc lương 1
        tdbg.Columns(COL_OfficalTitleID2).Caption = rl3("Ngach_luong") & " 2 " 'Ngạch lương 2 
        tdbg.Columns(COL_SalaryLevelID2).Caption = rL3("Bac_luong") & " 2" 'Bậc lương 2

        tdbgAlter.Columns(COLA_EmployeeID).Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbgAlter.Columns(COLA_EmployeeName).Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbgAlter.Columns(COLA_AttendanceCardNo).Caption = rL3("Ma_cham_cong") 'Mã chấm công

    End Sub



    Private Sub LoadSystemD09()
        D09D9940.LoadSystems()
        bEmployeeAuto = D09D9940.D09Systems.EmployeeAuto
        bIsAutoAttCardNo = D09D9940.D09Systems.IsAutoAttCardNo
        bIsUseBlockID = D09D9940.D09Systems.IsUseBlockID
        bIsAllDivision = D09D9940.D09Systems.IsAllDivision
    End Sub


    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient22).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient23).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient24).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient25).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        If bEmployeeAuto Then 'Tạo tự động or NV cũ
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
        If bIsAutoAttCardNo Then 'Tạo tự động or NV cũ
            tdbg.Splits(SPLIT1).DisplayColumns(COL_AttendanceCardNo).Style.Locked = True
            tdbg.Splits(SPLIT1).DisplayColumns(COL_AttendanceCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If

    End Sub

    Private Sub GridCaption()
        Dim sSQL As String
        sSQL = "Select Code, Short" & UnicodeJoin(gbUnicode) & " As Short, Disabled, Type, Decimals,NumValue" & vbCrLf
        sSQL &= "From D13T9000  WITH(NOLOCK) Order By Code "
        dtCaption = ReturnDataTable(sSQL)

        dtSalBase = ReturnTableFilter(dtCaption, "Type='SALBA'", True)
        GetCaptionSalBase(SPLIT1, COL_BaseSalary01)

        dtSalCoeff = ReturnTableFilter(dtCaption, "Type='SALCE'", True)
        GetCaptionSalCoeff(SPLIT1, COL_SalCoefficient01)

        'ID 106276 30.01.2018
        sSQL = "SELECT	RefCaptionU As RefCaption, Disabled, RefID " & vbCrLf & _
            " FROM    D09T0080 WITH (NOLOCK) " & vbCrLf & _
            " WHERE   Type = 'EF'"

        dtRefID = ReturnDataTable(sSQL)
        GetCaptionRefID(SPLIT1, COL_Ref01)
        '*****************************************************************************

        dtOLSC = ReturnTableFilter(dtCaption, " Type = 'OLSC'", True)
        LoadCaption_ColOfficalTitle_Grid(tdbg, dtOLSC, 1)
        LoadCaptiontdbcSalaryLevelID(tdbdSalaryLevelID, dtOLSC, 1)
        LoadCaptiontdbcSalaryLevelID(tdbdSalaryLevelID2, dtOLSC, 2)
    End Sub

    Public Sub LoadCaptiontdbcSalaryLevelID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dtOLSC As DataTable, ByVal sType As Integer)
        If sType = 1 Then
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC10"
                        tdbd.DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                    Case "OLSC11"
                        tdbd.DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC12"
                        tdbd.DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient02").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC13"
                        tdbd.DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(gbUnicode)

                        tdbd.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient03").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC14"
                        tdbd.DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(gbUnicode)

                        tdbd.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient04").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC15"
                        tdbd.DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient05").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                End Select
            Next
        Else
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC20"
                        tdbd.DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                    Case "OLSC21"
                        tdbd.DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC22"
                        tdbd.DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient02").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC23"
                        tdbd.DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient03").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC24"
                        tdbd.DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient04").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC25"
                        tdbd.DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(gbUnicode)
                        tdbd.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient05").NumberFormat = CustomFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                End Select
            Next
        End If
    End Sub
    Private Sub GetCaptionSalBase(ByVal Split As Integer, ByVal colFrom As String)
        Dim arr() As FormatColumn = Nothing

        Dim iCol As Integer = IndexOfColumn(tdbg, colFrom)
        If dtSalBase.Rows.Count > 0 Then
            For i As Integer = 0 To 3 'dtSalBase.Rows.Count - 1
                tdbg.Splits(Split).DisplayColumns(iCol).Visible = Not L3Bool(dtSalBase.Rows(i).Item("Disabled"))
                tdbg.Columns(iCol).Tag = tdbg.Splits(Split).DisplayColumns(iCol).Visible
                tdbg.Splits(Split).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(iCol).Caption = dtSalBase.Rows(i).Item("Short").ToString
                ReFormatNumber(tdbg, "N" & IIf(L3Int(dtSalBase.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtSalBase.Rows(i).Item("Decimals"))).ToString, tdbg.Columns(iCol).DataField)
                iCol += 1
            Next
        End If

        If arr IsNot Nothing Then InputNumber(tdbg, arr)
    End Sub
    Private Sub GetCaptionSalCoeff(ByVal Split As Integer, ByVal colFrom As String)
        Dim arr() As FormatColumn = Nothing

        Dim iCol As Integer = IndexOfColumn(tdbg, colFrom)
        If dtSalCoeff.Rows.Count > 0 Then
            For i As Integer = 0 To 19
                tdbg.Splits(Split).DisplayColumns(iCol).Visible = Not L3Bool(dtSalCoeff.Rows(i).Item("Disabled"))
                tdbg.Columns(iCol).Tag = tdbg.Splits(Split).DisplayColumns(iCol).Visible
                tdbg.Splits(Split).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(iCol).Caption = dtSalCoeff.Rows(i).Item("Short").ToString
                ReFormatNumber(tdbg, "N" & IIf(L3Int(dtSalCoeff.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtSalCoeff.Rows(i).Item("Decimals"))).ToString, tdbg.Columns(iCol).DataField)
                iCol += 1
            Next
        End If
        If arr IsNot Nothing Then InputNumber(tdbg, arr)
    End Sub

    Private Sub GetCaptionRefID(ByVal Split As Integer, ByVal colFrom As String)
        Dim arr() As FormatColumn = Nothing

        Dim iCol As Integer = IndexOfColumn(tdbg, colFrom)
        If dtRefID.Rows.Count > 0 Then
            For i As Integer = 0 To 19
                tdbg.Splits(Split).DisplayColumns(iCol).Visible = Not L3Bool(dtRefID.Rows(i).Item("Disabled"))
                tdbg.Columns(iCol).Tag = tdbg.Splits(Split).DisplayColumns(iCol).Visible
                tdbg.Splits(Split).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(iCol).Caption = dtRefID.Rows(i).Item("RefCaption").ToString
                iCol += 1
            Next
        End If
        If arr IsNot Nothing Then InputNumber(tdbg, arr)
    End Sub
    Private Sub LoadCaption_ColOfficalTitle_Grid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dtOLSC As DataTable, ByVal iSplit As Integer)
        Try
            With tdbg
                For i As Integer = 0 To dtOLSC.Rows.Count - 1
                    Select Case dtOLSC.Rows(i).Item("Code").ToString
                        Case "OLSC1"
                            .Splits(iSplit).DisplayColumns("OfficalTitleID").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("OfficalTitleID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("OfficalTitleID").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("OfficalTitleID").Visible = L3Bool(.Columns("OfficalTitleID").Tag)
                        Case "OLSC10"
                            .Splits(iSplit).DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SalaryLevelID").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SalaryLevelID").Visible = L3Bool(.Columns("SalaryLevelID").Tag)
                        Case "OLSC11"
                            .Splits(iSplit).DisplayColumns(COL_SaCoefficient).HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns(COL_SaCoefficient).Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns(COL_SaCoefficient).Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns(COL_SaCoefficient).Visible = L3Bool(.Columns(COL_SaCoefficient).Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, COL_SaCoefficient)
                        Case "OLSC12"
                            .Splits(iSplit).DisplayColumns("SaCoefficient12").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient12").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient12").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient12").Visible = L3Bool(.Columns("SaCoefficient12").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient12").DataField)
                        Case "OLSC13"
                            .Splits(iSplit).DisplayColumns("SaCoefficient13").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient13").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient13").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient13").Visible = L3Bool(.Columns("SaCoefficient13").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient13").DataField)
                        Case "OLSC14"
                            .Splits(iSplit).DisplayColumns("SaCoefficient14").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient14").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient14").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient14").Visible = L3Bool(.Columns("SaCoefficient14").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient14").DataField)
                        Case "OLSC15"
                            .Splits(iSplit).DisplayColumns("SaCoefficient15").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient15").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient15").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient15").Visible = L3Bool(.Columns("SaCoefficient15").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient15").DataField)
                        Case "OLSC2"
                            .Splits(iSplit).DisplayColumns("OfficalTitleID2").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("OfficalTitleID2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("OfficalTitleID2").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("OfficalTitleID2").Visible = L3Bool(.Columns("OfficalTitleID2").Tag)
                        Case "OLSC20"
                            .Splits(iSplit).DisplayColumns("SalaryLevelID2").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SalaryLevelID2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SalaryLevelID2").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SalaryLevelID2").Visible = L3Bool(.Columns("SalaryLevelID2").Tag)

                        Case "OLSC21"
                            .Splits(iSplit).DisplayColumns("SaCoefficient2").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient2").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient2").Visible = L3Bool(.Columns("SaCoefficient2").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient2").DataField)
                        Case "OLSC22"
                            .Splits(iSplit).DisplayColumns(COL_SaCoefficient22).HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns(COL_SaCoefficient22).Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns(COL_SaCoefficient22).Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns(COL_SaCoefficient22).Visible = L3Bool(.Columns(COL_SaCoefficient22).Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns(COL_SaCoefficient22).DataField)
                        Case "OLSC23"
                            .Splits(iSplit).DisplayColumns("SaCoefficient23").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient23").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient23").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient23").Visible = L3Bool(.Columns("SaCoefficient23").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient23").DataField)
                        Case "OLSC24"
                            .Splits(iSplit).DisplayColumns("SaCoefficient24").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient24").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient24").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient24").Visible = L3Bool(.Columns("SaCoefficient24").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient24").DataField)
                        Case "OLSC25"
                            .Splits(iSplit).DisplayColumns("SaCoefficient25").HeadingStyle.Font = FontUnicode(gbUnicode)
                            .Columns("SaCoefficient25").Caption = dtOLSC.Rows(i).Item("Short").ToString
                            .Columns("SaCoefficient25").Tag = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                            .Splits(iSplit).DisplayColumns("SaCoefficient25").Visible = L3Bool(.Columns("SaCoefficient25").Tag)
                            ReFormatNumber(tdbg, "N" & IIf(L3Int(dtOLSC.Rows(i).Item("Decimals")) < 0, 0, L3Int(dtOLSC.Rows(i).Item("Decimals"))).ToString, tdbg.Columns("SaCoefficient25").DataField)
                    End Select
                Next
            End With
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

    End Sub
    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_TrialPeriod).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_NoviciatePeriod).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary01).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary02).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary03).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_BaseSalary04).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient01).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient02).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient03).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient04).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient05).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient06).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient07).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient08).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient09).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient10).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient11).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient12).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient13).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient14).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient15).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient16).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient17).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient18).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient19).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SalCoefficient20).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient12).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient13).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient14).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient15).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient2).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient22).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient23).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient24).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_SaCoefficient25).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

    Private Sub D25F2054_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F5
                    btnFilter_Click(sender, Nothing)
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
            End Select
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID(, , gbUnicode)
        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(True, gbUnicode), gbUnicode)
        'Load tdbcDivisionID
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", True, gbUnicode)
        'tdbcDivisionID.SelectedIndex = 0 'Value = gsDivisionID

    End Sub

    Private Sub LoadTDBComboMethodID(ByVal sDivisionID As String, ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sTypeCode As String)
        Dim sSQL As String
        'Load tdbcMethodID
        sSQL = "Select MethodID, MethodName" & UnicodeJoin(gbUnicode) & " As MethodName, IsDefault" & vbCrLf
        sSQL &= "From D09T1600 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 And TypeCode=" & SQLString(sTypeCode) & vbCrLf
        If sDivisionID <> "%" Then
            sSQL &= "And (DivisionID =" & SQLString(sDivisionID) & " OR DivisionID = ' ')" & vbCrLf
        End If
        sSQL &= "Order by MethodName"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbc, dt, gbUnicode)
        '*****************************
        'ID 65595 21/07/2014
        Dim dr() As DataRow = dt.Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.SelectedValue = dr(0).Item("MethodID").ToString
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        Dim dt As DataTable

        'Load tdbdDivisionID
        dt = ReturnTableDivisionIDD09("D09", , gbUnicode)
        LoadDataSource(tdbdDivisionID, dt, gbUnicode)

        LoadTDBD(tdbdDivisionID, "Don vi")

        LoadDataSource(tdbdDepartmentID, dtDepartmentID, gbUnicode)
        LoadDataSource(tdbdTeamID, dtTeamID, gbUnicode)

        LoadTDBD(tdbdDutyID, "Chuc vu")
        LoadTDBD(tdbdWorkID, "Công việc")
        LoadTDBD(tdbdCountryID, "Quốc tịch")
        LoadTDBD(tdbdEthnicID, "Dân tộc")
        LoadTDBD(tdbdReligionID, "Tôn giáo")
        LoadTDBD(tdbdEducationLevelID, "Trình độ học vấn")
        LoadTDBD(tdbdProfessionalLevelID, "Trình độ chuyên môn")
        LoadTDBD(tdbdEmployeeTypeID, "Đối tượng lao động")
        LoadTDBD(tdbdWorkingTypeID, "Hình thức làm việc")
        LoadTDBD(tdbdStatusID, "Trạng thái làm việc")
        LoadTDBD(tdbdSalaryObjectID, "Đối tượng tính lương")
        LoadTDBD(tdbdTrousersSize, "Kích cỡ quần")
        LoadTDBD(tdbdShirtSize, "Kích cỡ áo")
        LoadTDBD(tdbdShoesSize, "Kích cỡ giày")
        LoadTDBD(tdbdClothesSize, "Kích cỡ đồ sạch")
        LoadTDBD(tdbdSalEmpGroupID, "Nhóm lương")
        LoadTDBD(tdbdSex, "Giới tính")
        LoadTDBD(tdbdDirectManagerID, "Người quản lý trực tiếp")

        Dim dtPLabel As DataTable = ReturnDataTable(SQLStoreD25P2055("Tỉnh/ thành phố", "BPPLabelID"))
        LoadDataSource(tdbdBPPLabelID, dtPLabel, gbUnicode)
        LoadDataSource(tdbdCAPLabelID, dtPLabel.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRAPLabelID, dtPLabel.DefaultView.ToTable, gbUnicode)

        Dim dtDLabel As DataTable = ReturnDataTable(SQLStoreD25P2055("Quận/ huyện", "BPDLabelID"))
        LoadDataSource(tdbdBPDLabelID, dtDLabel, gbUnicode)
        LoadDataSource(tdbdCADLabelID, dtDLabel.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRADLabelID, dtDLabel.DefaultView.ToTable, gbUnicode)

        Dim dtWLabel As DataTable = ReturnDataTable(SQLStoreD25P2055("Xã/ phường", "BPWLabelID"))
        LoadDataSource(tdbdBPWLabelID, dtWLabel, gbUnicode)
        LoadDataSource(tdbdCAWLabelID, dtWLabel.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdRAWLabelID, dtWLabel.DefaultView.ToTable, gbUnicode)

        LoadTDBD(tdbdPopulationID, "Hộ khẩu( thường trú)")
        LoadTDBD(tdbdIssuedPlaceID, "Nơi cấp CMND")
        LoadTDBD(tdbdBirthPlaceProvinceID, "Tỉnh/ thành phố (noi sinh)")
        LoadTDBD(tdbdResAddressProvinceID, "Tỉnh/ thành phố (tt)")

        dtDistrict = ReturnDataTable(SQLStoreD25P2055("CT Quận/Huyện", "BirthPlaceDistrictID"))
        LoadDataSource(tdbdBirthPlaceDistrictID, dtDistrict.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdResAddressDistrictID, dtDistrict.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdConAddressDistrictID, dtDistrict.DefaultView.ToTable, gbUnicode)

        dtWard = ReturnDataTable(SQLStoreD25P2055("CT Phường/Xã", "BirthPlaceWardID"))

        LoadDataSource(tdbdBirthPlaceWardID, dtWard.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdResAddressWardID, dtWard.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdConAddressWardID, dtWard.DefaultView.ToTable, gbUnicode)

        'Load tdbdOfficialTitleID1, 2
        sSQL = "-- Dropdown ngach luong" & vbCrLf
        sSQL &= "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial, DutyID As FilterName" & vbCrLf
        sSQL &= "From D09T0214  WITH(NOLOCK) Where Disabled = 0  Order By OfficialTitleID "
        dt = ReturnDataTable(sSQL)
        dtOfficialTitleID = ReturnTableFilter(dt, "IsUseOfficial = 0 OR IsUseOfficial = 1", True)
        LoadDataSource(tdbdOfficialTitleID, dtOfficialTitleID, gbUnicode)

        dtOfficialTitleID2 = ReturnTableFilter(dt, "IsUseOfficial = 0 OR IsUseOfficial = 2", True)
        LoadDataSource(tdbdOfficialTitleID2, dtOfficialTitleID2, gbUnicode)

        'Load tdbdSalaryLevelID
        sSQL = "--Dropdown bac luong" & vbCrLf
        sSQL &= "Select SalaryLevelID, SalaryCoefficient,SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, OfficialTitleID, NumberYearTransfer, Grade "
        sSQL &= "From D09T0215  WITH(NOLOCK) Where Disabled = 0 Order By Grade "
        dtSalaryLevelID = ReturnDataTable(sSQL)
        LoadtdbdSalaryLevelID(tdbdSalaryLevelID, "-1")
        LoadtdbdSalaryLevelID(tdbdSalaryLevelID2, "-1")

    End Sub

    Private Sub LoadtdbdSalaryLevelID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal ID As String)
        LoadDataSource(tdbd, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbdOfficialTitleID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dtID As DataTable, ByVal ID As String)
        Dim dt As DataTable
        If ID = "" Then
            dt = dtID.DefaultView.ToTable
        Else
            dt = ReturnTableFilter(dtID, "FilterName ='' Or FilterName=" & SQLString(ID), True)
        End If
        LoadDataSource(tdbd, dt, gbUnicode)
    End Sub

    Private Sub LoadTDBD(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sTitle As String, Optional sFilter As String = "")
        Dim sFieldName As String = tdbd.Name.Substring(4)
        Dim dtSource As DataTable = ReturnDataTable(SQLStoreD25P2055(sTitle, sFieldName))
        If sFilter <> "" Then
            LoadDataSource(tdbd, ReturnTableFilter(dtSource, "FilterName ='' Or FilterName=" & SQLString(sFilter)), gbUnicode)
        Else
            LoadDataSource(tdbd, dtSource, gbUnicode)
        End If

    End Sub

    Private Sub LoadDefault()
        tdbcDivisionID.SelectedValue = IIf(_sDivitionID = "", gsDivisionID, _sDivitionID)
        If bIsUseBlockID = False Then ReadOnlyControl(True, tdbcBlockID)
        If bIsAllDivision Then
            ReadOnlyControl(True, tdbcDivisionID)
            tdbg.Splits(1).DisplayColumns(COL_DivisionID).Visible = False
        End If
        tdbg.Columns(COL_DivisionID).Tag = Not bIsAllDivision
        If _sBlockID <> "" Then
            tdbcBlockID.SelectedValue = _sBlockID
        Else
             tdbcBlockID.SelectedIndex = 0
        End If
        If _sDepartmentID <> "" Then
            tdbcDepartmentID.SelectedValue = _sDepartmentID
        Else
            tdbcDepartmentID.SelectedIndex = 0
        End If
        If _sTeamID <> "" Then
            tdbcTeamID.SelectedValue = _sTeamID
        Else
            tdbcTeamID.SelectedIndex = 0
        End If
        If _sRecPositionID <> "" Then
            tdbcRecPositionID.SelectedValue = _sRecPositionID
        Else
            tdbcRecPositionID.SelectedIndex = 0
        End If
        tdbcMethodID.Enabled = bEmployeeAuto
        tdbcAttendCarNoMethodID.Enabled = bIsAutoAttCardNo
        '********************
        'ID 78934 11/12/2015
        If _sDateForm <> "" Then
            c1dateDateFrom.Value = _sDateForm
        Else
            c1dateDateFrom.Value = "1" & "/" & giTranMonth & "/" & giTranYear 'Default ngày đầu tháng
        End If
        If _sDateTo <> "" Then
            c1dateDateTo.Value = _sDateTo
        Else
            c1dateDateTo.Value = Date.DaysInMonth(giTranYear, giTranMonth) & "/" & giTranMonth & "/" & giTranYear 'Default Ngày cuối tháng
        End If

    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P2054()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_CandidateID)
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) Then Return False
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDepartmentID.Text)
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTeamID.Text)
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblRecPositionID.Text)
            tdbcRecPositionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAttendCarNoMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbg.Splits(SPLIT1).DisplayColumns(COL_DivisionID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BeginDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumIDCard).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Birthdate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SexName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub



    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        'If btnFilter.Focused = False Then Exit Sub
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2054
    '# Created User: Kim Long
    '# Created Date: 27/09/2017 08:35:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2054() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D25P2054 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'PositionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2056
    '# Created User: Kim Long
    '# Created Date: 28/09/2017 03:36:51
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2056() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu Nhan vien" & vbCrlf)
        sSQL &= "Exec D25P2056 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2055
    '# Created User: Kim Long
    '# Created Date: 27/09/2017 01:37:52
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2055(ByVal sTitle As String, ByVal sFieldName As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon Dropdown " & sTitle & vbCrLf)
        sSQL &= "Exec D25P2055 "
        sSQL &= SQLString(sFieldName) & COMMA 'FieldName, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) 'DivisionID, varchar[20], NOT NULL
        Return sSQL
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
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[20], NOT NULL
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



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2026
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/04/2014 09:50:16
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2026(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tao ma NV phu va Ma the cham cong" & vbCrLf)
        sSQL &= "Exec D09P2026 "
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'EmpFileTemplateID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAttendCarNoMethodID)) & COMMA 'AttendCarNoMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0)  'Mode, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P1504
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/02/2014 01:46:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P1504(ByVal sDateJoined As String, ByVal sEmployeeTypeID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Gan gia tri cho TrialSalaryRate, TValidDateEnd " & vbCrLf)
        sSQL &= "Exec D09P1504 "
        sSQL &= SQLDateSave(sDateJoined) & COMMA 'DateJoined, datetime, NOT NULL
        sSQL &= SQLString(sEmployeeTypeID) 'EmployeeTypeID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/05/2014 10:08:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6010(Optional ByVal sDateJoined As String = "") As String
        Dim sSQL As String = ""
        sSQL &= ("-- Gan du lieu cho luoi" & vbCrLf)
        sSQL &= "Exec D09P6010 "
        sSQL &= SQLString("") & COMMA 'Template, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'TableName, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'TranTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLDateSave(sDateJoined) 'DateJoined, datetime, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/07/2010 09:55:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMethodID)) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("25") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name)  'FormID  , varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/07/2010 09:51:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal sLastName As String, ByVal sMiddleName As String, ByVal sFirstName As String, ByVal sDateJoined As String, ByVal sDepartmentID As String, ByVal sSex As String) As StringBuilder
        Dim sSQL As New StringBuilder("")

        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, Str01, Str02, Str03, Str04, Str05, Date01")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString("D09F1500") & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append("N" & SQLString(sLastName) & COMMA) 'Str01, varchar[250], NOT NULL
        sSQL.Append("N" & SQLString(sMiddleName) & COMMA) 'Str02, varchar[250], NOT NULL
        sSQL.Append("N" & SQLString(sFirstName) & COMMA) 'Str03, varchar[250], NOT NULL
        sSQL.Append(SQLString(sDepartmentID) & COMMA) 'Str04, varchar[250], NOT NULL
        sSQL.Append(SQLString(sSex) & COMMA) 'Str05, varchar[250], NOT NULL
        sSQL.Append(SQLDateSave(sDateJoined)) 'Date01, datetime, NULL
        sSQL.Append(")")

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
            sSQL.Append("UserID, HostID, Key01ID,Key02ID,Key03ID,Str01, FormID,Date01")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_CandidateID).DataField).ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_EmployeeID).DataField).ToString) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_AttendanceCardNo).DataField).ToString) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(tdbg.Columns(COL_CandidateName).DataField).ToString, gbUnicode, True) & COMMA) 'Str01, varchar[250], NOT NULL
            sSQL.Append(SQLString("D09F1500") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(dr(i).Item(tdbg.Columns(COL_EffectiveDateFrom).DataField).ToString)) 'Date01, datetime, NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
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

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing OrElse tdbcDivisionID.Text = "" Then
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, "-1", gbUnicode)
        Else
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        End If
        tdbcBlockID.SelectedIndex = 0
        If bEmployeeAuto Then LoadTDBComboMethodID(ReturnValueC1Combo(tdbcDivisionID), tdbcMethodID, "2")
        If bIsAutoAttCardNo Then LoadTDBComboMethodID(ReturnValueC1Combo(tdbcDivisionID), tdbcAttendCarNoMethodID, "6")
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            Exit Sub
        End If
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True, Optional ByVal iButton As Object = 0)
        Dim arrColObligatory() As Object = {COL_CandidateID, COL_CandidateName}
        Dim arrColObligatory1() As Object = {COL_DivisionID, COL_BeginDate, COL_NumIDCard}
        If bLoad Then
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, , arrColObligatory, COL_IsUsed) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, , arrColObligatory1, COL_DivisionID) 'split1
        End If
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, , , , iButton)
    End Sub


    Private Sub tdbg_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_DepartmentID
                LoadtdbdDepartmentID(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "DepartmentID<>'%'", True), "%", IIf(bIsAllDivision, "%", tdbg.Columns(COL_DivisionID).Value).ToString, gbUnicode)
            Case COL_TeamID
                LoadtdbdTeamID(tdbdTeamID, ReturnTableFilter(dtTeamID, "TeamID<>'%'", True), "%", L3String(tdbg.Columns(COL_DepartmentID).Value), IIf(bIsAllDivision, "%", tdbg.Columns(COL_DivisionID).Value).ToString, gbUnicode)
            Case COL_ConAddressDistrictID
                LoadDataSource(tdbdConAddressDistrictID, ReturnTableFilter(dtDistrict, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_ConAddressProvinceID).Value)), True), gbUnicode)
            Case COL_ResAddressDistrictID
                LoadDataSource(tdbdResAddressDistrictID, ReturnTableFilter(dtDistrict, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_ResAddressProvinceID).Value)), True), gbUnicode)
            Case COL_BirthPlaceDistrictID
                LoadDataSource(tdbdBirthPlaceDistrictID, ReturnTableFilter(dtDistrict, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_BirthPlaceProvinceID).Value)), True), gbUnicode)
            Case COL_ConAddressWardID
                LoadDataSource(tdbdConAddressWardID, ReturnTableFilter(dtWard, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_ConAddressDistrictID).Value)), True), gbUnicode)
            Case COL_ResAddressWardID
                LoadDataSource(tdbdResAddressWardID, ReturnTableFilter(dtWard, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_ResAddressDistrictID).Value)), True), gbUnicode)
            Case COL_BirthPlaceWardID
                LoadDataSource(tdbdBirthPlaceWardID, ReturnTableFilter(dtWard, "FilterName ='' Or FilterName=" & SQLString(L3String(tdbg.Columns(COL_BirthPlaceDistrictID).Value)), True), gbUnicode)
            Case COL_SalaryLevelID
                LoadtdbdSalaryLevelID(tdbdSalaryLevelID, L3String(tdbg.Columns(COL_OfficalTitleID).Value))
            Case COL_SalaryLevelID2
                LoadtdbdSalaryLevelID(tdbdSalaryLevelID2, L3String(tdbg.Columns(COL_OfficalTitleID2).Value))
            Case COL_OfficalTitleID
                LoadtdbdOfficialTitleID(tdbdOfficialTitleID, dtOfficialTitleID, L3String(tdbg.Columns(COL_DutyID).Value))
            Case COL_OfficalTitleID2
                LoadtdbdOfficialTitleID(tdbdOfficialTitleID2, dtOfficialTitleID2, L3String(tdbg.Columns(COL_DutyID).Value))
            Case COL_SalaryObjectID
                LoadTDBD(tdbdSalaryObjectID, tdbg.Columns(tdbg.Col).Caption, L3String(tdbg.Columns(COL_DutyID).Value))
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub


    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ

        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_TrialPeriod, COL_NoviciatePeriod, COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04, COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10, COL_SalCoefficient11, COL_SalCoefficient12, COL_SalCoefficient13, COL_SalCoefficient14, COL_SalCoefficient15, COL_SalCoefficient16, COL_SalCoefficient17, COL_SalCoefficient18, COL_SalCoefficient19, COL_SalCoefficient20, COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15, COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_SexName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_DepartmentID, COL_TeamID, COL_DutyID, COL_WorkID, COL_IssuedPlaceID, COL_EthnicID, COL_ReligionID, COL_CountryID, COL_EmployeeTypeID, COL_WorkingStatusID, COL_StatusID, COL_EducationLevelID, COL_ProfessionalLevelID, COL_SalaryObjectID, COL_ShirtSize, COL_TrousersSize, COL_ShoesSize, COL_ClothesSize, COL_DirectManagerID, COL_BPPLabelID, COL_BirthPlaceProvinceID, COL_BPDLabelID, COL_BirthPlaceDistrictID, COL_BPWLabelID, COL_BirthPlaceWardID, COL_CAPLabelID, COL_ConAddressProvinceID, COL_ConAddressDistrictID, COL_CAWLabelID, COL_ConAddressWardID, COL_RAPLabelID, COL_ResAddressProvinceID, COL_RADLabelID, COL_ResAddressDistrictID, COL_RAWLabelID, COL_ResAddressWardID, COL_SalEmpGroupID, COL_OfficalTitleID, COL_OfficalTitleID2
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_EmployeeID, COL_AttendanceCardNo
                e.Cancel = L3IsID(tdbg, e.ColIndex)
            Case COL_DivisionID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_OfficalTitleID
                If tdbg.Columns(e.ColIndex).Text <> tdbdOfficialTitleID.Columns(tdbdOfficialTitleID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_OfficalTitleID2
                If tdbg.Columns(e.ColIndex).Text <> tdbdOfficialTitleID2.Columns(tdbdOfficialTitleID2.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_SalaryLevelID
                If tdbg.Columns(e.ColIndex).Text <> tdbdSalaryLevelID.Columns(tdbdSalaryLevelID.DisplayMember).Text Then
                   bNotInList = True
                End If
            Case COL_SalaryLevelID2
                If tdbg.Columns(e.ColIndex).Text <> tdbdSalaryLevelID2.Columns(tdbdSalaryLevelID2.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_NumIDCard
                If Not CheckStore(SQLStoreD25P5555(1, tdbg.Columns(COL_NumIDCard).Text, tdbg.Columns(COL_CandidateID).Text)) Then
                    e.Cancel = True
                End If
                If tdbg.Columns(e.ColIndex).Text.Trim <> "" AndAlso tdbg.Columns(e.ColIndex).Text.Length > 12 Then  'ID 69123 01/10/2014
                    D99C0008.MsgL3(rL3("So_CMND_chua_hop_le"))
                    e.Cancel = True
                End If
        End Select
    End Sub


    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_EmployeeID
                If bEmployeeAuto = False Then 'Cho phép nhập tay. ID 64609 15/04/2014
                    CreateRefEmpAndAttendCardNo(tdbg.Columns(COL_EmployeeID).Text)
                End If
            Case COL_DivisionID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                End If
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
            Case COL_DepartmentID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                End If
                tdbg.Columns(COL_TeamID).Text = ""
            Case COL_TeamID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_DutyID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
                tdbg.Columns(COL_OfficalTitleID).Text = tdbdDutyID.Columns("OfficialTitleID").Text
                tdbg.Columns(COL_OfficalTitleID2).Text = tdbdDutyID.Columns("OfficialTitleID02").Text
            Case COL_WorkID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
                If tdbg.Columns(COL_OfficalTitleID).Text = "" Then tdbg.Columns(COL_OfficalTitleID).Text = tdbdDutyID.Columns("OfficialTitleID").Text
                If tdbg.Columns(COL_OfficalTitleID2).Text = "" Then tdbg.Columns(COL_OfficalTitleID2).Text = tdbdDutyID.Columns("OfficialTitleID02").Text
            Case COL_BeginDate
                SetDefaultDate()
                SetTValidDateEnd()
                SetFirstSalaryMonth()
            Case COL_SexName
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_Sex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
                tdbg.Columns(COL_Sex).Value = L3Bool(tdbdSex.Columns("ID").Text)
            Case COL_IssuedPlaceID, COL_EthnicID, COL_ReligionID, COL_CountryID, COL_EmployeeTypeID, COL_WorkingStatusID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_StatusID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_OtherValue).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_OtherValue).Value = tdbg.Columns(e.ColIndex).DropDown.Columns("OtherValue").Text
                SetDefaultDate()
            Case COL_TrialPeriod
                If tdbg.Columns(e.ColIndex).Text <> "" Then CalTrialDate()
            Case COL_TrialDateFrom, COL_TrialDateTo
                If tdbg.Columns(e.ColIndex).Text <> "" Then CalTrialPeriod()
            Case COL_NoviciatePeriod
                If tdbg.Columns(e.ColIndex).Text <> "" Then CalNoviciateDate()
            Case COL_NoviciateDateFrom, COL_NoviciateDateTo
                If tdbg.Columns(e.ColIndex).Text <> "" Then CalNoviciatePeriod()
            Case COL_AttendanceCardNo
            Case COL_ShirtSize, COL_TrousersSize, COL_ShoesSize, COL_ClothesSize, COL_DirectManagerID, COL_SalaryObjectID, COL_EducationLevelID, COL_ProfessionalLevelID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_BPPLabelID, COL_BPDLabelID, COL_BPWLabelID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_BirthPlaceProvinceID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    'Exit Select
                End If
                tdbg.Columns(COL_BirthPlaceDistrictID).Text = ""
                tdbg.Columns(COL_BirthPlaceWardID).Text = ""
            Case COL_BirthPlaceDistrictID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    'tdbg.Columns(COL_BirthPlaceWardID).Text = ""
                    'Exit Select
                End If
                tdbg.Columns(COL_BirthPlaceWardID).Text = ""
            Case COL_BirthPlaceWardID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_CAPLabelID, COL_CADLabelID, COL_CAWLabelID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_ConAddressProvinceID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    'Exit Select
                End If
                tdbg.Columns(COL_ConAddressDistrictID).Text = ""
                tdbg.Columns(COL_ConAddressWardID).Text = ""
            Case COL_ConAddressDistrictID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                End If
                tdbg.Columns(COL_ConAddressWardID).Text = ""
            Case COL_ConAddressWardID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_RAPLabelID, COL_RADLabelID, COL_RAWLabelID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_ResAddressProvinceID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                End If
                tdbg.Columns(COL_ResAddressDistrictID).Text = ""
                tdbg.Columns(COL_ResAddressWardID).Text = ""
            Case COL_ResAddressDistrictID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                End If
                tdbg.Columns(COL_ResAddressWardID).Text = ""
            Case COL_ResAddressWardID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_SalEmpGroupID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_OfficalTitleID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                End If
                tdbg.Columns(COL_SalaryLevelID).Text = ""
                tdbg.Columns(COL_SaCoefficient).Text = ""
                tdbg.Columns(COL_SaCoefficient12).Text = ""
                tdbg.Columns(COL_SaCoefficient13).Text = ""
                tdbg.Columns(COL_SaCoefficient14).Text = ""
                tdbg.Columns(COL_SaCoefficient15).Text = ""
            Case COL_SalaryLevelID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_SaCoefficient).Text = ""
                    tdbg.Columns(COL_SaCoefficient12).Text = ""
                    tdbg.Columns(COL_SaCoefficient13).Text = ""
                    tdbg.Columns(COL_SaCoefficient14).Text = ""
                    tdbg.Columns(COL_SaCoefficient15).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_SaCoefficient).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient").Text
                tdbg.Columns(COL_SaCoefficient12).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COL_SaCoefficient13).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COL_SaCoefficient14).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COL_SaCoefficient15).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient05").Text
            Case COL_OfficalTitleID2
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                End If
                tdbg.Columns(COL_SalaryLevelID2).Text = ""
                tdbg.Columns(COL_SaCoefficient2).Text = ""
                tdbg.Columns(COL_SaCoefficient22).Text = ""
                tdbg.Columns(COL_SaCoefficient23).Text = ""
                tdbg.Columns(COL_SaCoefficient24).Text = ""
                tdbg.Columns(COL_SaCoefficient25).Text = ""
            Case COL_SalaryLevelID2
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_SaCoefficient2).Text = ""
                    tdbg.Columns(COL_SaCoefficient22).Text = ""
                    tdbg.Columns(COL_SaCoefficient23).Text = ""
                    tdbg.Columns(COL_SaCoefficient24).Text = ""
                    tdbg.Columns(COL_SaCoefficient25).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_SaCoefficient2).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient").Text
                tdbg.Columns(COL_SaCoefficient22).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COL_SaCoefficient23).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COL_SaCoefficient24).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COL_SaCoefficient25).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient05").Text
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case COL_IsUsed
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case COL_OfficalTitleID, COL_SalaryLevelID
                Dim iColRelative() As Integer = {IndexOfColumn(tdbg, COL_OfficalTitleID), IndexOfColumn(tdbg, COL_SalaryLevelID), IndexOfColumn(tdbg, COL_SaCoefficient), IndexOfColumn(tdbg, COL_SaCoefficient12), IndexOfColumn(tdbg, COL_SaCoefficient13), IndexOfColumn(tdbg, COL_SaCoefficient14), IndexOfColumn(tdbg, COL_SaCoefficient15)}
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed), iColRelative)
            Case COL_OfficalTitleID2, COL_SalaryLevelID2
                Dim iColRelative() As Integer = {IndexOfColumn(tdbg, COL_OfficalTitleID2), IndexOfColumn(tdbg, COL_SalaryLevelID2), IndexOfColumn(tdbg, COL_SaCoefficient2), IndexOfColumn(tdbg, COL_SaCoefficient22), IndexOfColumn(tdbg, COL_SaCoefficient23), IndexOfColumn(tdbg, COL_SaCoefficient24), IndexOfColumn(tdbg, COL_SaCoefficient25)}
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed), iColRelative)
            Case COL_DivisionID, COL_DepartmentID, COL_TeamID
                Dim iCols() As Integer = New Integer() {IndexOfColumn(tdbg, "DivisionID"), IndexOfColumn(tdbg, "DepartmentID"), IndexOfColumn(tdbg, "TeamID")}
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed), iCols)
            Case COL_StatusID
                CopyColumnsStatusID(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Case COL_BeginDate
                CopyColumnsDateJoined(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Case COL_EmployeeTypeID
                CopyColumnsTrialSalaryRate(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Case COL_SexName
                Dim iColRelative() As Integer = {IndexOfColumn(tdbg, COL_Sex)}
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed), iColRelative)
            Case COL_DutyID, COL_WorkID, COL_EthnicID, COL_ReligionID, COL_CountryID, COL_WorkingPlace, COL_EmployeeTypeID, COL_WorkingStatusID, COL_EducationLevelID, COL_ProfessionalLevelID, COL_EffectiveDateFrom
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed))
            Case COL_ShirtSize, COL_TrousersSize, COL_ShoesSize, COL_ClothesSize, COL_DirectManagerID
                CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed))
            Case Else
                Select Case tdbg.Columns(iCol).DataField
                    Case COL_CandidateID, COL_CandidateName, COL_EmployeeID, COL_Telephone, COL_Email, COL_NumIDCard, COL_AttendanceCardNo
                    Case COL_NoviciateDateFrom, COL_NoviciateDateTo, COL_NoviciatePeriod
                    Case COL_TrialDateFrom, COL_TrialDateTo, COL_TrialPeriod
                    Case COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15
                    Case COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25
                    Case Else
                        CopyColumnsArr(tdbg, iCol, IndexOfColumn(tdbg, COL_IsUsed))
                End Select
        End Select

        tdbg.UpdateData()
        dtGrid.AcceptChanges()
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub



    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Columns(e.Col).DataField
            Case "NoviciatePeriod", "NoviciateDateTo", "NoviciateDateFrom"
                Select Case tdbg(e.Row, COL_OtherValue).ToString
                    Case "TV", "LV", "LVTV"
                        e.CellStyle.Locked = True
                        e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End Select
            Case "TrialPeriod", "TrialDateFrom", "TrialDateTo"
                Select Case tdbg(e.Row, COL_OtherValue).ToString
                    Case "HV", "LV"
                        e.CellStyle.Locked = True
                        e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End Select
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_TrialPeriod, COL_NoviciatePeriod, COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04, COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10, COL_SalCoefficient11, COL_SalCoefficient12, COL_SalCoefficient13, COL_SalCoefficient14, COL_SalCoefficient15, COL_SalCoefficient16, COL_SalCoefficient17, COL_SalCoefficient18, COL_SalCoefficient19, COL_SalCoefficient20, COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15, COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NumIDCard, COL_Telephone
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select

        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub




    Private Sub CreateRefEmpAndAttendCardNo(ByVal sEmployeeID As String, Optional ByVal iRow As Integer = -1)
        If bIsAutoAttCardNo Then
            Dim sSQL As String = SQLStoreD09P2026(sEmployeeID)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    If .Item("AttendCardNo").ToString <> "" Then
                        If iRow = -1 Then
                            tdbg.Columns("AttendanceCardNo").Text = .Item("AttendCardNo").ToString
                        Else
                            tdbg(iRow, "AttendanceCardNo") = .Item("AttendCardNo").ToString
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        tdbg.Focus()
        tdbg.SplitIndex = 1
        tdbg.Col = IndexOfColumn(tdbg, COL_DivisionID)
    End Sub

    Private Sub btnInfoSalary_Click(sender As Object, e As EventArgs) Handles btnInfoSalary.Click
        tdbg.Focus()
        tdbg.SplitIndex = 1
        tdbg.Col = IndexOfColumn(tdbg, COL_BaseSalary01)
    End Sub


#Region "Hàm tính toán thời gian thử việc, thời gian học việc"

    Private Sub SetDefaultDate()
        If tdbg.Columns(COL_BeginDate).Text <> "" Then
            Select Case tdbg.Columns(COL_OtherValue).Text
                Case "TV", "LVTV"
                    'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                    tdbg.Columns("TrialDateFrom").Text = tdbg.Columns(COL_BeginDate).Text
                Case "HV"
                    'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                    tdbg.Columns("NoviciateDateFrom").Text = tdbg.Columns(COL_BeginDate).Text
                Case "TVHV"
                    'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                    tdbg.Columns("TrialDateFrom").Text = tdbg.Columns(COL_BeginDate).Text
                    tdbg.Columns("NoviciateDateFrom").Text = tdbg.Columns(COL_BeginDate).Text
            End Select
        End If
    End Sub

    Private Sub SetDefaultDate(ByVal i As Integer)
        If L3String(tdbg(i, COL_BeginDate)) = "" Then Exit Sub
        Select Case L3String(tdbg(i, COL_OtherValue))
            Case "TV", "LVTV"
                'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                tdbg(i, "TrialDateFrom") = tdbg(i, COL_BeginDate)
            Case "HV"
                'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                tdbg(i, "NoviciateDateFrom") = tdbg(i, COL_BeginDate)
            Case "TVHV"
                'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                tdbg(i, "TrialDateFrom") = tdbg(i, COL_BeginDate)
                tdbg(i, "NoviciateDateFrom") = tdbg(i, COL_BeginDate)
        End Select
    End Sub

    Private Sub CalTrialPeriod()
        If tdbg.Columns("TrialDateFrom").Text <> "" AndAlso tdbg.Columns("TrialDateTo").Text <> "" Then
            'Số tháng thử việc =  Round((Thời gian thử việc đến - Thời gian thử việc từ)/30 , 0)
            Dim iDay As Long = DateDiff(DateInterval.Day, CDate(tdbg.Columns("TrialDateFrom").Text), CDate(tdbg.Columns("TrialDateTo").Text))
            tdbg.Columns("TrialPeriod").Text = Math.Round(iDay / 30, 0, MidpointRounding.AwayFromZero).ToString
        Else
            If tdbg.Columns("TrialPeriod").Text <> "" Then 'Tính lại ngay tu hoac ngay den
                CalTrialDate()
            End If
        End If
    End Sub

    Private Sub CalTrialDate()
        If tdbg.Columns("TrialDateFrom").Text = "" AndAlso tdbg.Columns("TrialDateTo").Text = "" Then Exit Sub
        '*******************************
        Dim dDate As Date
        If tdbg.Columns("TrialDateFrom").Text <> "" Then 'Tính lại ngày đến
            'Thời gian thử việc đến = (Thời gian thử việc từ + Số tháng thử việc) – 1(ngày)
            dDate = DateAdd(DateInterval.Month, Number(tdbg.Columns("TrialPeriod").Text), CDate(tdbg.Columns("TrialDateFrom").Text))
            tdbg.Columns("TrialDateTo").Text = SQLDateShow(DateAdd(DateInterval.Day, -1, dDate))
        Else 'Tính lại ngày từ
            'Thời gian thử việc từ = (Thời gian thử việc đến - Số tháng thử việc) + 1(ngày)
            dDate = DateAdd(DateInterval.Month, -Number(tdbg.Columns("TrialPeriod").Text), CDate(tdbg.Columns("TrialDateTo").Text))
            tdbg.Columns("TrialDateFrom").Text = SQLDateShow(DateAdd(DateInterval.Day, 1, dDate))
        End If
    End Sub

    Private Sub CalNoviciatePeriod()
        If tdbg.Columns("NoviciateDateFrom").Text <> "" AndAlso tdbg.Columns("NoviciateDateTo").Text <> "" Then
            'Số tháng học việc = Round((Thời gian học việc đến - Thời gian học việc từ)/30 , 0)
            Dim iDay As Long = DateDiff(DateInterval.Day, CDate(tdbg.Columns("NoviciateDateFrom").Text), CDate(tdbg.Columns("NoviciateDateTo").Text))
            tdbg.Columns("NoviciatePeriod").Text = Math.Round(iDay / 30, 0, MidpointRounding.AwayFromZero).ToString
        Else
            If tdbg.Columns("NoviciatePeriod").Text <> "" Then 'Tính lại ngay tu hoac ngay den
                CalNoviciateDate()
            End If
        End If
    End Sub

    Private Sub CalNoviciateDate()
        If tdbg.Columns("NoviciateDateFrom").Text = "" AndAlso tdbg.Columns("NoviciateDateTo").Text = "" Then Exit Sub
        '*******************************
        Dim dDate As Date
        If tdbg.Columns("NoviciateDateFrom").Text <> "" Then 'Tính lại ngày đến
            'Thời gian học việc đến = (Thời gian học việc từ + Số tháng học việc) – 1(ngày)
            dDate = DateAdd(DateInterval.Month, Number(tdbg.Columns("NoviciatePeriod").Text), CDate(tdbg.Columns("NoviciateDateFrom").Text))
            tdbg.Columns("NoviciateDateTo").Text = SQLDateShow(DateAdd(DateInterval.Day, -1, dDate))
        Else 'Tính lại ngày từ
            'Thời gian học việc từ = (Thời gian học việc đến - Số tháng học việc) + 1(ngày)
            dDate = DateAdd(DateInterval.Month, -Number(tdbg.Columns("NoviciatePeriod").Text), CDate(tdbg.Columns("NoviciateDateTo").Text))
            tdbg.Columns("NoviciateDateFrom").Text = SQLDateShow(DateAdd(DateInterval.Day, 1, dDate))
        End If
    End Sub

    Private Sub SetTValidDateEnd()
        If tdbg.Columns(COL_BeginDate).Text = "" Then Exit Sub
        '******************
        If tdbg.Columns(COL_OtherValue).Text = "LVTV" OrElse tdbg.Columns(COL_OtherValue).Text = "TVHV" Then
            Dim sSQL As String = SQLStoreD09P1504(tdbg.Columns(COL_BeginDate).Text, L3String(tdbg.Columns(COL_EmployeeID).Text))
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    tdbg.Columns(COL_TrialDateTo).Text = SQLDateShow(.Item("TValidDateEnd"))
                End With
            End If
        End If
    End Sub


    Private Sub SetTValidDateEnd(ByVal i As Integer)
        If tdbg.Columns(COL_BeginDate).Text = "" Then Exit Sub
        '******************
        Select Case L3String(tdbg(i, COL_OtherValue))
            Case "LVTV", "TVHV"
                Dim sSQL As String = SQLStoreD09P1504(L3String(tdbg(i, COL_BeginDate)), L3String(tdbg(i, COL_EmployeeID)))
                Dim dt As DataTable = ReturnDataTable(sSQL)
                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        tdbg(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                    End With
                End If
        End Select
    End Sub

    'ID 64572 07/05/2014 by Bích Thuận
    Private Sub SetFirstSalaryMonth()
        If tdbg.Columns(COL_BeginDate).Text = "" Then Exit Sub
        '**************************************
        Dim sSQL As String = SQLStoreD09P6010(tdbg.Columns(COL_BeginDate).Text)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("TrialDateFrom").ToString <> "" Then tdbg.Columns("TrialDateFrom").Text = SQLDateShow(dt.Rows(0).Item("TrialDateFrom"))
        End If
    End Sub

#End Region


    Private Function AllowSave(ByRef drChoose() As DataRow, ByRef sInsertMaster As StringBuilder) As Boolean
        If bEmployeeAuto AndAlso tdbcMethodID.Enabled Then
            If tdbcMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Phuong_phap_tao_ma_NV_tu_dong"))
                tdbcMethodID.Focus()
                Return False
            End If
        End If
        If bIsAutoAttCardNo AndAlso tdbcAttendCarNoMethodID.Enabled Then
            If tdbcAttendCarNoMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Phương pháp tạo mã chấm công tự động"))
                tdbcAttendCarNoMethodID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            Return False
        End If
        '*****************************
        drChoose = dtGrid.Select("IsUsed =1")
        If drChoose.Length = 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Row = 0
            tdbg.Col = IndexOfColumn(tdbg, COL_IsUsed)
            Return False
        End If
        '*******************************
        'Phải quét dòng trên lưới để kiểm tra vì lưới có những cột ẩn mà dtGrid không có
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                If Not bEmployeeAuto AndAlso tdbg(i, "EmployeeID").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_nhan_vien"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Focus()
                    tdbg.Col = IndexOfColumn(tdbg, COL_EmployeeID)
                    tdbg.Row = i
                    Return False
                End If
                'ID 69976
                If L3Bool(tdbg.Columns(COL_DivisionID).Tag) Then 'Hiển thị cột Đơn vị  ' If _mode = 2 Then
                    If tdbg(i, COL_DivisionID).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Don_vi"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = IndexOfColumn(tdbg, COL_DivisionID)
                        tdbg.Bookmark = i
                        Return False
                    End If
                End If
                If tdbg(i, COL_BeginDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_BeginDate).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 1
                    tdbg.Col = IndexOfColumn(tdbg, COL_BeginDate)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If tdbg(i, COL_NumIDCard).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_NumIDCard).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 1
                    tdbg.Col = IndexOfColumn(tdbg, COL_NumIDCard)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If tdbg(i, COL_BirthDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_BirthDate).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 1
                    tdbg.Col = IndexOfColumn(tdbg, COL_BirthDate)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If tdbg(i, COL_SexName).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_SexName).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 1
                    tdbg.Col = IndexOfColumn(tdbg, COL_SexName)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                'If Not bIsAutoAttCardNo AndAlso tdbg(i, COL_AttendanceCardNo).ToString = "" Then
                '    D99C0008.MsgNotYetEnter(rL3("Ma_cham_cong"))
                '    tdbg.SplitIndex = SPLIT1
                '    tdbg.Focus()
                '    tdbg.Col = IndexOfColumn(tdbg, COL_AttendanceCardNo)
                '    tdbg.Row = i
                '    Return False
                'End If
            End If
        Next

        '*****************************
        For i As Integer = 0 To tdbg.RowCount - 1 'ID 83523 16/02/2016
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                If CreateIGE_EmployeeID(i) = False Then
                    tdbg.SplitIndex = 0
                    tdbg.Focus()
                    tdbg.Col = IndexOfColumn(tdbg, COL_EmployeeID)
                    tdbg.Row = i
                    Return False
                End If
                If CreateIGE_AttendanceCardNo(i) = False Then
                    tdbg.SplitIndex = 1
                    tdbg.Focus()
                    tdbg.Col = IndexOfColumn(tdbg, COL_AttendanceCardNo)
                    tdbg.Row = i
                    Return False
                End If
            End If
        Next

        If bEmployeeAuto = False Then
            If LoadFrameAlter(drChoose) = False Then Return False
            ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name))
        End If
        Return True
    End Function

#Region "Frame Thông báo"

    Private Sub picGroupData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picGroupData.Click
        grpAlter.Visible = False
        '*********************
        Dim dr() As DataRow = dtGrid.Select("EmployeeID= " & SQLString(tdbgAlter(0, COLA_EmployeeID)))
        If dr.Length > 0 Then
            tdbg.SplitIndex = 0
            tdbg.Focus()
            tdbg.Col = IndexOfColumn(tdbg, COL_EmployeeID)
            tdbg.Row = dtGrid.Rows.IndexOf(dr(0))
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name))
        picGroupData_Click(Nothing, Nothing)
    End Sub

    Private Function LoadFrameAlter(ByVal dr() As DataRow) As Boolean
        If bEmployeeAuto Then Return True
        '*********************************
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
            lblMessage.Text = "- " & rL3("Cac_ma_nhan_vien_da_ton_tai") & Space(1) & rL3("MSG000053") 'Các mã nhân viên đã tồn tại. Bạn không được phép lưu
            lblMessage2.Text = "- " & rL3("Ban_phai_nhap_lai_ma_nhan_vien_khac") 'Bạn phải nhập lại mã nhân viên khác
            tdbgAlter.Splits(0).DisplayColumns(COLA_AttendanceCardNo).Visible = False
            LoadDataSource(tdbgAlter, dt, gbUnicode)
            ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name).ToString)
            Return False
        Else
            Dim dt1 As DataTable = ReturnDataTable(SQLStoreD25P5555(2, "", "").ToString)
            'Dim bRunSQL1 As Boolean = CheckStore(SQLStoreD25P5555(2, "", "").ToString, False, , dt1)
            If dt1.Rows.Count > 0 Then
                grpAlter.Visible = True
                grpAlter.BringToFront()
                lblMessage.Text = "- " & rL3("Cac_ma_cham_cong_da_ton_tai") & Space(1) & rL3("MSG000053") 'Các mã nhân viên đã tồn tại. Bạn không được phép lưu
                lblMessage2.Text = "- " & rL3("Ban_phai_nhap_lai_ma_cham_cong_khac") 'Bạn phải nhập lại mã nhân viên khác
                tdbgAlter.Splits(0).DisplayColumns(COLA_AttendanceCardNo).Visible = True
                LoadDataSource(tdbgAlter, dt1, gbUnicode)
                ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name).ToString)
                Return False
            End If
        End If

            Return True
    End Function
#End Region

    Private Function CreateIGE_EmployeeID(ByVal i As Integer) As Boolean
        Dim dr() As DataRow
        If bEmployeeAuto Then
            If tdbg(i, COL_EmployeeID).ToString = "" Then
                'Sinh Ma NV tu dong
                If bEmployeeAuto Then
                    Dim sSQL As String
                    'Xoa du lieu bang tam
                    sSQL = "Delete D09T6666 Where UserID=" & SQLString(gsUserID) & " And HostID=" & SQLString(My.Computer.Name) & vbCrLf
                    sSQL &= SQLInsertD09T6666(tdbg(i, "LastName").ToString, tdbg(i, "MiddleName").ToString, tdbg(i, "FirstName").ToString, SQLDateShow(tdbg(i, "BeginDate").ToString), tdbg(i, "DepartmentID").ToString, IIf(tdbg(i, "SexName").ToString = "Nam", "0", "1").ToString).ToString & vbCrLf
                    sSQL &= SQLStoreD09P2016() & vbCrLf
                    Dim dt1 As DataTable = ReturnDataTable(sSQL)
                    If dt1.Rows.Count > 0 Then
                        If dt1.Rows(0).Item("Status").ToString = "1" Then
                            D99C0008.MsgL3(ConvertVietwareFToUnicode(dt1.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                            dt1 = Nothing
                            Return False
                        Else
                            tdbg(i, COL_EmployeeID) = dt1.Rows(0).Item("EmployeeID").ToString
                            sSQL = "Delete D09T6666 Where UserID=" & SQLString(gsUserID) & " And HostID=" & SQLString(My.Computer.Name)
                            ExecuteSQLNoTransaction(sSQL)
                        End If
                        dt1 = Nothing
                    Else
                        D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
                        Return False
                    End If
                End If
            End If

        End If
        '****************************
        '-----------Ktra trung Ma NV
        tdbg.UpdateData()
        dr = dtGrid.Select("EmployeeID= " & SQLString(tdbg(i, COL_EmployeeID).ToString))
        If dr.Length > 1 Then
            D99C0008.MsgL3(rL3("Ma_nhan_vien") & Space(1) & tdbg(i, COL_EmployeeID).ToString & Space(1) & rL3("da_ton_tai_tren_luoi"))
            Return False
        End If
        Return True
    End Function

    Private Function CreateIGE_AttendanceCardNo(ByVal i As Integer) As Boolean
        Dim dr() As DataRow
        If bIsAutoAttCardNo Then
            If tdbg(i, COL_AttendanceCardNo).ToString = "" Then
                CreateRefEmpAndAttendCardNo(tdbg(i, COL_EmployeeID).ToString, i)
            End If
        End If
        tdbg.UpdateData()
        dr = dtGrid.Select("AttendanceCardNo <>'' and AttendanceCardNo= " & SQLString(tdbg(i, COL_AttendanceCardNo).ToString))
        If dr.Length > 1 Then
            D99C0008.MsgL3(rL3("Ma_cham_cong") & Space(1) & tdbg(i, COL_AttendanceCardNo).ToString & Space(1) & rL3("da_ton_tai_tren_luoi"))
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        Dim dr() As DataRow = Nothing 'Chỉ những dòng được chọn
        Dim sInsertMaster As New StringBuilder("")
        If Not AllowSave(dr, sInsertMaster) Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaveOK = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Dim bRun As Boolean = False
        Dim oBulkCopy As New Lemon3.Data.SqlClient.SqlBulk() 'Nếu Form viết WPF thì dùng new Lemon3.Data.L3SQLBulkCopy()
        oBulkCopy.AddSQLAfter(SQLStoreD25P2056())
        bRun = oBulkCopy.SaveBulkCopy(dtGrid, "#F2054_" & gsUserID) 'CheckStore có thông báo Lưu thành công

        Me.Cursor = Cursors.Default

        If bRun Then
            SaveOK()
            _bSaveOK = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub D25F2054_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ExecuteSQLNoTransaction(SQLDeleteD09T6666(Me.Name))
    End Sub

    Private Sub CopyColumnsStatusID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Integer, ByVal i As Integer)
        c1Grid(i, ColCopy) = sValue
        c1Grid(i, "StatusID") = c1Grid(RowCopy, "StatusID").ToString 'Dùng cho TH cột StatusID là drop down phụ thuộc
        c1Grid(i, COL_OtherValue) = c1Grid(RowCopy, COL_OtherValue).ToString
        '****************************************
        SetDefaultDate(i)
        SetTValidDateEnd(i)
    End Sub

    Private Sub CopyColumnsStatusID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(ColCopy).Locked Then Exit Sub
            '*****************************
            Dim sEmployeeTypeID As String = ""
            sEmployeeTypeID = c1Grid(RowCopy, "EmployeeTypeID").ToString
            '***************************************
            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                            If L3Bool(c1Grid(i, COL_IsUsed)) Then
                                CopyColumnsStatusID(c1Grid, ColCopy, sValue, RowCopy, i)
                            End If
                        Else
                            CopyColumnsStatusID(c1Grid, ColCopy, sValue, RowCopy, i)
                        End If
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                        If L3Bool(c1Grid(i, COL_IsUsed)) Then
                            CopyColumnsStatusID(c1Grid, ColCopy, sValue, RowCopy, i)
                        End If
                    Else
                        CopyColumnsStatusID(c1Grid, ColCopy, sValue, RowCopy, i)
                    End If
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CopyColumnsDateJoined(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(ColCopy).Locked Then Exit Sub
            '***************************************
            Dim sEmployeeTypeID As String = ""
            sEmployeeTypeID = c1Grid(RowCopy, COL_EmployeeTypeID).ToString
            '***************************************
            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                            If L3Bool(c1Grid(i, COL_IsUsed)) Then
                                c1Grid(i, ColCopy) = sValue
                                '***************************************
                                If c1Grid(i, COL_BeginDate).ToString <> "" Then
                                    '***************************************
                                    Select Case c1Grid(i, COL_OtherValue).ToString
                                        Case "TV"
                                            'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                            c1Grid(i, COL_TrialDateFrom) = sValue
                                        Case "HV"
                                            'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                                            c1Grid(i, COL_NoviciateDateFrom) = sValue
                                        Case "LVTV", "TVHV"
                                            If c1Grid(i, COL_OtherValue).ToString = "LVTV" Then
                                                'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                                c1Grid(i, COL_TrialDateFrom) = sValue
                                            Else
                                                'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                                                c1Grid(i, COL_TrialDateFrom) = sValue
                                                c1Grid(i, COL_NoviciateDateFrom) = sValue
                                            End If
                                            '*******************
                                            Dim sSQL As String = SQLStoreD09P1504(c1Grid(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                            Dim dt As DataTable = ReturnDataTable(sSQL)
                                            If dt.Rows.Count > 0 Then
                                                With dt.Rows(0)
                                                    c1Grid(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                                End With
                                            End If
                                    End Select
                                End If
                            End If
                        Else
                            c1Grid(i, ColCopy) = sValue
                            '***************************************
                            If c1Grid(i, COL_BeginDate).ToString <> "" Then
                                '***************************************
                                Select Case c1Grid(i, COL_OtherValue).ToString
                                    Case "TV"
                                        'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                        c1Grid(i, COL_TrialDateFrom) = sValue
                                    Case "HV"
                                        'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                                        c1Grid(i, COL_NoviciateDateFrom) = sValue
                                    Case "LVTV", "TVHV"
                                        If c1Grid(i, COL_OtherValue).ToString = "LVTV" Then
                                            'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                            c1Grid(i, COL_TrialDateFrom) = sValue
                                        Else
                                            'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                                            c1Grid(i, COL_TrialDateFrom) = sValue
                                            c1Grid(i, COL_NoviciateDateFrom) = sValue
                                        End If
                                        '*******************
                                        Dim sSQL As String = SQLStoreD09P1504(c1Grid(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                        Dim dt As DataTable = ReturnDataTable(sSQL)
                                        If dt.Rows.Count > 0 Then
                                            With dt.Rows(0)
                                                c1Grid(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                            End With
                                        End If
                                End Select
                            End If
                        End If
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                        If L3Bool(c1Grid(i, COL_IsUsed)) Then
                            c1Grid(i, ColCopy) = sValue
                            '****************************************
                            If sValue <> "" Then
                                '***************************************
                                Select Case c1Grid(i, COL_OtherValue).ToString
                                    Case "TV"
                                        'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                        c1Grid(i, COL_TrialDateFrom) = sValue
                                    Case "HV"
                                        'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                                        c1Grid(i, COL_NoviciateDateFrom) = sValue
                                    Case "LVTV", "TVHV"
                                        If c1Grid(i, COL_OtherValue).ToString = "LVTV" Then
                                            'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                            c1Grid(i, COL_TrialDateFrom) = sValue
                                        Else
                                            'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                                            c1Grid(i, COL_TrialDateFrom) = sValue
                                            c1Grid(i, COL_NoviciateDateFrom) = sValue
                                        End If
                                        '*******************
                                        Dim sSQL As String = SQLStoreD09P1504(c1Grid(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                        Dim dt As DataTable = ReturnDataTable(sSQL)
                                        If dt.Rows.Count > 0 Then
                                            With dt.Rows(0)
                                                  c1Grid(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                            End With
                                        End If
                                End Select
                            End If
                        End If
                    Else
                        c1Grid(i, ColCopy) = sValue
                        '****************************************
                        If sValue <> "" Then
                            '***************************************
                            Select Case c1Grid(i, COL_OtherValue).ToString
                                Case "TV"
                                    'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                    c1Grid(i, COL_TrialDateFrom) = sValue
                                Case "HV"
                                    'Gán giá trị thời gian học việc (từ) =  ngày vào làm
                                    c1Grid(i, COL_NoviciateDateFrom) = sValue
                                Case "LVTV", "TVHV"
                                    If c1Grid(i, COL_OtherValue).ToString = "LVTV" Then
                                        'Gán giá trị thời gian thử việc (từ) =  ngày vào làm
                                        c1Grid(i, COL_TrialDateFrom) = sValue
                                    Else
                                        'gắn thời gian học việc (từ) = ngày vào làm, thời gian thử việc = ngày vào làm.(NoviciateDateFrom = DateJoined, TrialDateFrom = DateJoined)
                                        c1Grid(i, COL_TrialDateFrom) = sValue
                                        c1Grid(i, COL_NoviciateDateFrom) = sValue
                                    End If
                                    '*******************
                                    Dim sSQL As String = SQLStoreD09P1504(c1Grid(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                    Dim dt As DataTable = ReturnDataTable(sSQL)
                                    If dt.Rows.Count > 0 Then
                                        With dt.Rows(0)
                                             c1Grid(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                        End With
                                    End If
                            End Select
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyColumnsTrialSalaryRate(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(ColCopy).Locked Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString
            Dim sEmployeeTypeID As String = ""
            sEmployeeTypeID = c1Grid(RowCopy, "EmployeeTypeID").ToString
            '*****************************
            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung c1Grid con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                            If L3Bool(c1Grid(i, COL_IsUsed)) Then
                                c1Grid(i, ColCopy) = sValue
                                '****************************************
                                If tdbg(i, COL_BeginDate).ToString <> "" Then
                                    Select Case tdbg(i, COL_OtherValue).ToString
                                        Case "LVTV", "TVHV"
                                            Dim sSQL As String = SQLStoreD09P1504(tdbg(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                            Dim dt As DataTable = ReturnDataTable(sSQL)
                                            If dt.Rows.Count > 0 Then
                                                With dt.Rows(0)
                                                    tdbg(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                                End With
                                            End If
                                    End Select
                                End If
                            End If
                        Else
                            c1Grid(i, ColCopy) = sValue
                            '****************************************
                            If tdbg(i, COL_BeginDate).ToString <> "" Then
                                Select Case tdbg(i, COL_OtherValue).ToString
                                    Case "LVTV", "TVHV"
                                        Dim sSQL As String = SQLStoreD09P1504(tdbg(i, "DateJoined").ToString, sEmployeeTypeID)
                                        Dim dt As DataTable = ReturnDataTable(sSQL)
                                        If dt.Rows.Count > 0 Then
                                            With dt.Rows(0)
                                                 tdbg(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                            End With
                                        End If
                                End Select
                            End If
                        End If
                    End If
                Next

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If tdbg.Splits(0).DisplayColumns(COL_IsUsed).Visible Then 'ID 75106 24/04/2015
                        If L3Bool(c1Grid(i, COL_IsUsed)) Then
                            c1Grid(i, ColCopy) = sValue
                            '****************************************
                            If tdbg(i, COL_BeginDate).ToString <> "" Then
                                Select Case tdbg(i, COL_OtherValue).ToString
                                    Case "LVTV", "TVHV"
                                        Dim sSQL As String = SQLStoreD09P1504(tdbg(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                        Dim dt As DataTable = ReturnDataTable(sSQL)
                                        If dt.Rows.Count > 0 Then
                                            With dt.Rows(0)
                                               tdbg(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                            End With
                                        End If
                                End Select
                            End If
                        End If
                    Else
                        c1Grid(i, ColCopy) = sValue
                        '****************************************
                        If tdbg(i, COL_BeginDate).ToString <> "" Then
                            Select Case tdbg(i, COL_OtherValue).ToString
                                Case "LVTV", "TVHV"
                                    Dim sSQL As String = SQLStoreD09P1504(tdbg(i, COL_BeginDate).ToString, sEmployeeTypeID)
                                    Dim dt As DataTable = ReturnDataTable(sSQL)
                                    If dt.Rows.Count > 0 Then
                                        With dt.Rows(0)
                                             tdbg(i, COL_TrialDateTo) = SQLDateShow(.Item("TValidDateEnd"))
                                        End With
                                    End If
                            End Select
                        End If
                    End If
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class