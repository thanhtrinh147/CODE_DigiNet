﻿Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:32:32 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:32:32 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------

Public Class D13F2012
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Dim dtCaptionCols, dtProject, dtAddress As DataTable

#Region "Const of tdbg - Total of Columns: 291"
Private Const COL_PaymentMethod As Integer = 0          ' PaymentMethod
Private Const COL_EmployeeID As Integer = 1             ' Mã nhân viên
Private Const COL_FullName As Integer = 2               ' Họ và Tên
Private Const COL_BlockID As Integer = 3                ' Khối
Private Const COL_BlockName As Integer = 4              ' Tên khối
Private Const COL_DepartmentID As Integer = 5           ' Phòng ban
Private Const COL_DepartmentName As Integer = 6         ' Tên phòng ban
Private Const COL_TeamID As Integer = 7                 ' Tổ nhóm 
Private Const COL_TeamName As Integer = 8               ' Tên tổ nhóm
Private Const COL_EmpGroupID As Integer = 9             ' Nhóm NV
Private Const COL_EmpGroupName As Integer = 10          ' Tên nhóm NV
Private Const COL_ProjectID As Integer = 11             ' Dự án
Private Const COL_ProjectName As Integer = 12           ' Tên dự án
Private Const COL_PeriodID As Integer = 13              ' Tập phí
Private Const COL_Note As Integer = 14                  ' Diễn giải tập phí
Private Const COL_SubDutyID As Integer = 15             ' Chức vụ
Private Const COL_DutyName As Integer = 16              ' Tên chức vụ
Private Const COL_DutyRef01 As Integer = 17             ' DutyRef01
Private Const COL_DutyRef02 As Integer = 18             ' DutyRef02
Private Const COL_DutyRef03 As Integer = 19             ' DutyRef03
Private Const COL_DutyRef04 As Integer = 20             ' DutyRef04
Private Const COL_DutyRef05 As Integer = 21             ' DutyRef05
Private Const COL_WorkID As Integer = 22                ' Công việc
Private Const COL_WorkName As Integer = 23              ' Tên công việc
Private Const COL_Birthdate As Integer = 24             ' Ngày sinh
Private Const COL_SexName As Integer = 25               ' Giới tính
Private Const COL_DateJoined As Integer = 26            ' Ngày vào làm
Private Const COL_DateLeft As Integer = 27              ' Ngày nghỉ việc
Private Const COL_Age As Integer = 28                   ' Tuổi
Private Const COL_StatusID As Integer = 29              ' Trạng thái làm việc
Private Const COL_StatusName As Integer = 30            ' Tên trạng thái làm việc
Private Const COL_AttendanceCardNo As Integer = 31      ' Mã thẻ chấm công
Private Const COL_RefEmployeeID As Integer = 32         ' Mã NV phụ
Private Const COL_IsSub As Integer = 33                 ' HSL phụ
Private Const COL_StandardAbsentQuan As Integer = 34    ' Ngày công chuẩn
Private Const COL_ValidDateFrom As Integer = 35         ' Ngày chấm công (Từ)
Private Const COL_ValidDateTo As Integer = 36           ' Ngày chấm công (Đến)
Private Const COL_FullSalCycle As Integer = 37          ' Đủ chu kỳ lương
Private Const COL_SalaryRate As Integer = 38            ' Tỷ lệ hưởng lương (%)
Private Const COL_RefNo As Integer = 39                 ' Số tham chiếu
Private Const COL_TaxObjectID As Integer = 40           ' Mã ĐT tính thuế
Private Const COL_TaxObjectName As Integer = 41         ' Tên ĐT tính thuế
Private Const COL_PayrollVoucherNo As Integer = 42      ' Hồ sơ lương tháng
Private Const COL_BASE01 As Integer = 43                ' Lương cơ bản 01
Private Const COL_BaseCurrencyID01 As Integer = 44      ' BaseCurrencyID01
Private Const COL_BASE02 As Integer = 45                ' Lương cơ bản 02
Private Const COL_BaseCurrencyID02 As Integer = 46      ' BaseCurrencyID02
Private Const COL_BASE03 As Integer = 47                ' Lương cơ bản 03
Private Const COL_BaseCurrencyID03 As Integer = 48      ' BaseCurrencyID03
Private Const COL_BASE04 As Integer = 49                ' Lương cơ bản 04
Private Const COL_BaseCurrencyID04 As Integer = 50      ' BaseCurrencyID04
Private Const COL_CE01 As Integer = 51                  ' Hệ số 01
Private Const COL_SalCoeCurrencyID01 As Integer = 52    ' SalCoeCurrencyID01
Private Const COL_CE02 As Integer = 53                  ' Hệ số 02
Private Const COL_SalCoeCurrencyID02 As Integer = 54    ' SalCoeCurrencyID02
Private Const COL_CE03 As Integer = 55                  ' Hệ số 03
Private Const COL_SalCoeCurrencyID03 As Integer = 56    ' SalCoeCurrencyID03
Private Const COL_CE04 As Integer = 57                  ' Hệ số 04
Private Const COL_SalCoeCurrencyID04 As Integer = 58    ' SalCoeCurrencyID04
Private Const COL_CE05 As Integer = 59                  ' Hệ số 05
Private Const COL_SalCoeCurrencyID05 As Integer = 60    ' SalCoeCurrencyID05
Private Const COL_CE06 As Integer = 61                  ' Hệ số 06
Private Const COL_SalCoeCurrencyID06 As Integer = 62    ' SalCoeCurrencyID06
Private Const COL_CE07 As Integer = 63                  ' Hệ số 07
Private Const COL_SalCoeCurrencyID07 As Integer = 64    ' SalCoeCurrencyID07
Private Const COL_CE08 As Integer = 65                  ' Hệ số 08
Private Const COL_SalCoeCurrencyID08 As Integer = 66    ' SalCoeCurrencyID08
Private Const COL_CE09 As Integer = 67                  ' Hệ số 09
Private Const COL_SalCoeCurrencyID09 As Integer = 68    ' SalCoeCurrencyID09
Private Const COL_CE10 As Integer = 69                  ' Hệ số 10
Private Const COL_SalCoeCurrencyID10 As Integer = 70    ' SalCoeCurrencyID10
Private Const COL_CE11 As Integer = 71                  ' CE11
Private Const COL_SalCoeCurrencyID11 As Integer = 72    ' SalCoeCurrencyID11
Private Const COL_CE12 As Integer = 73                  ' CE12
Private Const COL_SalCoeCurrencyID12 As Integer = 74    ' SalCoeCurrencyID12
Private Const COL_CE13 As Integer = 75                  ' CE13
Private Const COL_SalCoeCurrencyID13 As Integer = 76    ' SalCoeCurrencyID13
Private Const COL_CE14 As Integer = 77                  ' CE14
Private Const COL_SalCoeCurrencyID14 As Integer = 78    ' SalCoeCurrencyID14
Private Const COL_CE15 As Integer = 79                  ' CE15
Private Const COL_SalCoeCurrencyID15 As Integer = 80    ' SalCoeCurrencyID15
Private Const COL_CE16 As Integer = 81                  ' CE16
Private Const COL_SalCoeCurrencyID16 As Integer = 82    ' SalCoeCurrencyID16
Private Const COL_CE17 As Integer = 83                  ' CE17
Private Const COL_SalCoeCurrencyID17 As Integer = 84    ' SalCoeCurrencyID17
Private Const COL_CE18 As Integer = 85                  ' CE18
Private Const COL_SalCoeCurrencyID18 As Integer = 86    ' SalCoeCurrencyID18
Private Const COL_CE19 As Integer = 87                  ' CE19
Private Const COL_SalCoeCurrencyID19 As Integer = 88    ' SalCoeCurrencyID19
Private Const COL_CE20 As Integer = 89                  ' CE20
Private Const COL_SalCoeCurrencyID20 As Integer = 90    ' SalCoeCurrencyID20
Private Const COL_INC01 As Integer = 91                 ' Thu nhập 01
Private Const COL_INC02 As Integer = 92                 ' Thu nhập 02
Private Const COL_INC03 As Integer = 93                 ' Thu nhập 03
Private Const COL_INC04 As Integer = 94                 ' Thu nhập 04
Private Const COL_INC05 As Integer = 95                 ' Thu nhập 05
Private Const COL_INC06 As Integer = 96                 ' Thu nhập 06
Private Const COL_INC07 As Integer = 97                 ' Thu nhập 07
Private Const COL_INC08 As Integer = 98                 ' Thu nhập 08
Private Const COL_INC09 As Integer = 99                 ' Thu nhập 09
Private Const COL_INC10 As Integer = 100                ' Thu nhập 10
Private Const COL_INC11 As Integer = 101                ' Thu nhập 11
Private Const COL_INC12 As Integer = 102                ' Thu nhập 12
Private Const COL_INC13 As Integer = 103                ' Thu nhập 13
Private Const COL_INC14 As Integer = 104                ' Thu nhập 14
Private Const COL_INC15 As Integer = 105                ' Thu nhập 15
Private Const COL_INC16 As Integer = 106                ' Thu nhập 16
Private Const COL_INC17 As Integer = 107                ' Thu nhập 17
Private Const COL_INC18 As Integer = 108                ' Thu nhập 18
Private Const COL_INC19 As Integer = 109                ' Thu nhập 19
Private Const COL_INC20 As Integer = 110                ' Thu nhập 20
Private Const COL_INC21 As Integer = 111                ' Thu nhập 21
Private Const COL_INC22 As Integer = 112                ' Thu nhập 22
Private Const COL_INC23 As Integer = 113                ' Thu nhập 23
Private Const COL_INC24 As Integer = 114                ' Thu nhập 24
Private Const COL_INC25 As Integer = 115                ' Thu nhập 25
Private Const COL_INC26 As Integer = 116                ' Thu nhập 26
Private Const COL_INC27 As Integer = 117                ' Thu nhập 27
Private Const COL_INC28 As Integer = 118                ' Thu nhập 28
Private Const COL_INC29 As Integer = 119                ' Thu nhập 29
Private Const COL_INC30 As Integer = 120                ' Thu nhập 30
Private Const COL_N01 As Integer = 121                  ' Mã phân tích 01
Private Const COL_N02 As Integer = 122                  ' Mã phân tích 02
Private Const COL_N03 As Integer = 123                  ' Mã phân tích 03
Private Const COL_N04 As Integer = 124                  ' Mã phân tích 04
Private Const COL_N05 As Integer = 125                  ' Mã phân tích 05
Private Const COL_N06 As Integer = 126                  ' Mã phân tích 06
Private Const COL_N07 As Integer = 127                  ' Mã phân tích 07
Private Const COL_N08 As Integer = 128                  ' Mã phân tích 08
Private Const COL_N09 As Integer = 129                  ' Mã phân tích 09
Private Const COL_N10 As Integer = 130                  ' Mã phân tích 10
Private Const COL_N11 As Integer = 131                  ' Mã phân tích 11
Private Const COL_N12 As Integer = 132                  ' Mã phân tích 12
Private Const COL_N13 As Integer = 133                  ' Mã phân tích 13
Private Const COL_N14 As Integer = 134                  ' Mã phân tích 14
Private Const COL_N15 As Integer = 135                  ' Mã phân tích 15
Private Const COL_N16 As Integer = 136                  ' Mã phân tích 16
Private Const COL_N17 As Integer = 137                  ' Mã phân tích 17
Private Const COL_N18 As Integer = 138                  ' Mã phân tích 18
Private Const COL_N19 As Integer = 139                  ' Mã phân tích 19
Private Const COL_N20 As Integer = 140                  ' Mã phân tích 20
Private Const COL_OfficalTitleID As Integer = 141       ' OfficalTitleID
Private Const COL_OfficialTitleName1 As Integer = 142   ' Tên ngạch lương 1
Private Const COL_SalaryLevelID As Integer = 143        ' SalaryLevelID
Private Const COL_SalaryLevelName1 As Integer = 144     ' Tên bậc lương 1
Private Const COL_SaCoefficient As Integer = 145        ' SaCoefficient
Private Const COL_SaCoefficient12 As Integer = 146      ' SaCoefficient12
Private Const COL_SaCoefficient13 As Integer = 147      ' SaCoefficient13
Private Const COL_SaCoefficient14 As Integer = 148      ' SaCoefficient14
Private Const COL_SaCoefficient15 As Integer = 149      ' SaCoefficient15
Private Const COL_OfficalTitleID2 As Integer = 150      ' OfficalTitleID2
Private Const COL_OfficialTitleName2 As Integer = 151   ' Tên ngạch lương 2
Private Const COL_SalaryLevelID2 As Integer = 152       ' SalaryLevelID2
Private Const COL_SalaryLevelName2 As Integer = 153     ' Tên bậc lương 2
Private Const COL_SaCoefficient2 As Integer = 154       ' SaCoefficient2
Private Const COL_SaCoefficient22 As Integer = 155      ' SaCoefficient22
Private Const COL_SaCoefficient23 As Integer = 156      ' SaCoefficient23
Private Const COL_SaCoefficient24 As Integer = 157      ' SaCoefficient24
Private Const COL_SaCoefficient25 As Integer = 158      ' SaCoefficient25
Private Const COL_CreateUserID As Integer = 159         ' CreateUserID
Private Const COL_CreateDate As Integer = 160           ' CreateDate
Private Const COL_LastModifyUserID As Integer = 161     ' LastModifyUserID
Private Const COL_LastModifyDate As Integer = 162       ' LastModifyDate
Private Const COL_P01 As Integer = 163                  ' Mã phân tích tiền lương 01
Private Const COL_P02 As Integer = 164                  ' Mã phân tích tiền lương 02
Private Const COL_P03 As Integer = 165                  ' Mã phân tích tiền lương 03
Private Const COL_P04 As Integer = 166                  ' Mã phân tích tiền lương 04
Private Const COL_P05 As Integer = 167                  ' Mã phân tích tiền lương 05
Private Const COL_P06 As Integer = 168                  ' Mã phân tích tiền lương 06
Private Const COL_P07 As Integer = 169                  ' Mã phân tích tiền lương 07
Private Const COL_P08 As Integer = 170                  ' Mã phân tích tiền lương 08
Private Const COL_P09 As Integer = 171                  ' Mã phân tích tiền lương 09
Private Const COL_P10 As Integer = 172                  ' Mã phân tích tiền lương 10
Private Const COL_P11 As Integer = 173                  ' Mã phân tích tiền lương 11
Private Const COL_P12 As Integer = 174                  ' Mã phân tích tiền lương 12
Private Const COL_P13 As Integer = 175                  ' Mã phân tích tiền lương 13
Private Const COL_P14 As Integer = 176                  ' Mã phân tích tiền lương 14
Private Const COL_P15 As Integer = 177                  ' Mã phân tích tiền lương 15
Private Const COL_P16 As Integer = 178                  ' Mã phân tích tiền lương 16
Private Const COL_P17 As Integer = 179                  ' Mã phân tích tiền lương 17
Private Const COL_P18 As Integer = 180                  ' Mã phân tích tiền lương 18
Private Const COL_P19 As Integer = 181                  ' Mã phân tích tiền lương 19
Private Const COL_P20 As Integer = 182                  ' Mã phân tích tiền lương 20
Private Const COL_Ref01 As Integer = 183                ' Ref01
Private Const COL_Ref02 As Integer = 184                ' Ref02
Private Const COL_Ref03 As Integer = 185                ' Ref03
Private Const COL_Ref04 As Integer = 186                ' Ref04
Private Const COL_Ref05 As Integer = 187                ' Ref05
Private Const COL_NumRef01 As Integer = 188             ' NumRef01
Private Const COL_NumRef02 As Integer = 189             ' NumRef02
Private Const COL_NumRef03 As Integer = 190             ' NumRef03
Private Const COL_NumRef04 As Integer = 191             ' NumRef04
Private Const COL_NumRef05 As Integer = 192             ' NumRef05
Private Const COL_NumRef06 As Integer = 193             ' NumRef06
Private Const COL_NumRef07 As Integer = 194             ' NumRef07
Private Const COL_NumRef08 As Integer = 195             ' NumRef08
Private Const COL_NumRef09 As Integer = 196             ' NumRef09
Private Const COL_NumRef10 As Integer = 197             ' NumRef10
Private Const COL_BaseSalary01DateEnd As Integer = 198  ' BaseSalary01DateEnd
Private Const COL_BaseSalary02DateEnd As Integer = 199  ' BaseSalary02DateEnd
Private Const COL_BaseSalary03DateEnd As Integer = 200  ' BaseSalary03DateEnd
Private Const COL_BaseSalary04DateEnd As Integer = 201  ' BaseSalary04DateEnd
Private Const COL_BaseSalary01NextDate As Integer = 202 ' BaseSalary01NextDate
Private Const COL_BaseSalary02NextDate As Integer = 203 ' BaseSalary02NextDate
Private Const COL_BaseSalary03NextDate As Integer = 204 ' BaseSalary03NextDate
Private Const COL_BaseSalary04NextDate As Integer = 205 ' BaseSalary04NextDate
Private Const COL_NextBaseSalary01 As Integer = 206     ' NextBaseSalary01
Private Const COL_NextBaseSalary02 As Integer = 207     ' NextBaseSalary02
Private Const COL_NextBaseSalary03 As Integer = 208     ' NextBaseSalary03
Private Const COL_NextBaseSalary04 As Integer = 209     ' NextBaseSalary04
Private Const COL_Sal01DateEnd As Integer = 210         ' Sal01DateEnd
Private Const COL_Sal02DateEnd As Integer = 211         ' Sal0DateEnd
Private Const COL_Sal03DateEnd As Integer = 212         ' Sal03DateEnd
Private Const COL_Sal04DateEnd As Integer = 213         ' Sal04DateEnd
Private Const COL_Sal05DateEnd As Integer = 214         ' Sal05DateEnd
Private Const COL_Sal06DateEnd As Integer = 215         ' Sal06DateEnd
Private Const COL_Sal07DateEnd As Integer = 216         ' Sal07DateEnd
Private Const COL_Sal08DateEnd As Integer = 217         ' Sal08DateEnd
Private Const COL_Sal09DateEnd As Integer = 218         ' Sal09DateEnd
Private Const COL_Sal10DateEnd As Integer = 219         ' Sal10DateEnd
Private Const COL_Sal11DateEnd As Integer = 220         ' Sal11DateEnd
Private Const COL_Sal12DateEnd As Integer = 221         ' Sal12DateEnd
Private Const COL_Sal13DateEnd As Integer = 222         ' Sal13DateEnd
Private Const COL_Sal14DateEnd As Integer = 223         ' Sal14DateEnd
Private Const COL_Sal15DateEnd As Integer = 224         ' Sal15DateEnd
Private Const COL_Sal16DateEnd As Integer = 225         ' Sal16DateEnd
Private Const COL_Sal17DateEnd As Integer = 226         ' Sal17DateEnd
Private Const COL_Sal18DateEnd As Integer = 227         ' Sal18DateEnd
Private Const COL_Sal19DateEnd As Integer = 228         ' Sal19DateEnd
Private Const COL_Sal20DateEnd As Integer = 229         ' Sal20DateEnd
Private Const COL_Sal01NextDate As Integer = 230        ' Sal01NextDate
Private Const COL_Sal02NextDate As Integer = 231        ' Sal02NextDate
Private Const COL_Sal03NextDate As Integer = 232        ' Sal03NextDate
Private Const COL_Sal04NextDate As Integer = 233        ' Sal04NextDate
Private Const COL_Sal05NextDate As Integer = 234        ' Sal05NextDate
Private Const COL_Sal06NextDate As Integer = 235        ' Sal06NextDate
Private Const COL_Sal07NextDate As Integer = 236        ' Sal07NextDate
Private Const COL_Sal08NextDate As Integer = 237        ' Sal08NextDate
Private Const COL_Sal09NextDate As Integer = 238        ' Sal09NextDate
Private Const COL_Sal10NextDate As Integer = 239        ' Sal10NextDate
Private Const COL_Sal11NextDate As Integer = 240        ' Sal11NextDate
Private Const COL_Sal12NextDate As Integer = 241        ' Sal12NextDate
Private Const COL_Sal13NextDate As Integer = 242        ' Sal13NextDate
Private Const COL_Sal14NextDate As Integer = 243        ' Sal14NextDate
Private Const COL_Sal15NextDate As Integer = 244        ' Sal15NextDate
Private Const COL_Sal16NextDate As Integer = 245        ' Sal16NextDate
Private Const COL_Sal17NextDate As Integer = 246        ' Sal17NextDate
Private Const COL_Sal18NextDate As Integer = 247        ' Sal18NextDate
Private Const COL_Sal19NextDate As Integer = 248        ' Sal19NextDate
Private Const COL_Sal20NextDate As Integer = 249        ' Sal20NextDate
Private Const COL_NextSalCoefficient01 As Integer = 250 ' NextSalCoefficient01
Private Const COL_NextSalCoefficient02 As Integer = 251 ' NextSalCoefficient02
Private Const COL_NextSalCoefficient03 As Integer = 252 ' NextSalCoefficient03
Private Const COL_NextSalCoefficient04 As Integer = 253 ' NextSalCoefficient04
Private Const COL_NextSalCoefficient05 As Integer = 254 ' NextSalCoefficient05
Private Const COL_NextSalCoefficient06 As Integer = 255 ' NextSalCoefficient06
Private Const COL_NextSalCoefficient07 As Integer = 256 ' NextSalCoefficient07
Private Const COL_NextSalCoefficient08 As Integer = 257 ' NextSalCoefficient08
Private Const COL_NextSalCoefficient09 As Integer = 258 ' NextSalCoefficient09
Private Const COL_NextSalCoefficient10 As Integer = 259 ' NextSalCoefficient10
Private Const COL_NextSalCoefficient11 As Integer = 260 ' NextSalCoefficient11
Private Const COL_NextSalCoefficient12 As Integer = 261 ' NextSalCoefficient12
Private Const COL_NextSalCoefficient13 As Integer = 262 ' NextSalCoefficient13
Private Const COL_NextSalCoefficient14 As Integer = 263 ' NextSalCoefficient14
Private Const COL_NextSalCoefficient15 As Integer = 264 ' NextSalCoefficient15
Private Const COL_NextSalCoefficient16 As Integer = 265 ' NextSalCoefficient16
Private Const COL_NextSalCoefficient17 As Integer = 266 ' NextSalCoefficient17
Private Const COL_NextSalCoefficient18 As Integer = 267 ' NextSalCoefficient18
Private Const COL_NextSalCoefficient19 As Integer = 268 ' NextSalCoefficient19
Private Const COL_NextSalCoefficient20 As Integer = 269 ' NextSalCoefficient20
Private Const COL_OffSa1DateEnd As Integer = 270        ' OffSa1DateEnd
Private Const COL_OffSa1NextDate As Integer = 271       ' OffSa1NextDate
Private Const COL_NextOfficalTitleID As Integer = 272   ' NextOfficalTitleID
Private Const COL_NextSalaryLevelID As Integer = 273    ' NextSalaryLevelID
Private Const COL_OffSa2DateEnd As Integer = 274        ' OffSa2DateEnd
Private Const COL_OffSa2NextDate As Integer = 275       ' OffSa2NextDate
Private Const COL_NextOfficalTitleID2 As Integer = 276  ' NextOfficalTitleID2
Private Const COL_NextSalaryLevelID2 As Integer = 277   ' NextSalaryLevelID2
Private Const COL_TransID As Integer = 278              ' TransID
Private Const COL_PaymentMethodName As Integer = 279    ' Phương thức trả lương
Private Const COL_BankID As Integer = 280               ' Ngân hàng
Private Const COL_BankName As Integer = 281             ' Tên ngân hàng
Private Const COL_BankAccountNo As Integer = 282        ' Số tài khoản
Private Const COL_ExchangeDep As Integer = 283          ' Phòng giao dịch
Private Const COL_SalEmpGroupName As Integer = 284      ' Tên nhóm lương
Private Const COL_PayrollVoucherID As Integer = 285     ' PayrollVoucherID
Private Const COL_Permission As Integer = 286           ' Permission
Private Const COL_SalaryObjectID As Integer = 287       ' Mã ĐT tính lương
Private Const COL_SalaryObjectName As Integer = 288     ' Tên ĐT tính lương
Private Const COL_StatusMaternityName As Integer = 289  ' Trạng thái thai sản, con nhỏ
Private Const COL_Disabled As Integer = 290             ' Đã nghỉ việc
#End Region

#Region "Const of tdbgRelative - Total of Columns: 45"
    Private Const COL1_IsNewRow As Integer = 0                ' IsNewRow
    Private Const COL1_RelativeID As Integer = 1              ' RelativeID
    Private Const COL1_RelationName As Integer = 2            ' Quan hệ
    Private Const COL1_RelationID As Integer = 3              ' RelationID
    Private Const COL1_RelativeName As Integer = 4            ' Tên người quan hệ
    Private Const COL1_DBirthDate As Integer = 5              ' Ngày sinh
    Private Const COL1_MBirthDate As Integer = 6              ' Tháng sinh
    Private Const COL1_YBirthDate As Integer = 7              ' Năm sinh
    Private Const COL1_CountryTypeID As Integer = 8           ' Quốc gia
    Private Const COL1_BirthPlace As Integer = 9              ' Nơi sinh
    Private Const COL1_ConAddressProvinceName As Integer = 10 ' Tỉnh/Thành phố
    Private Const COL1_ConAddressProvinceID As Integer = 11   ' ConAddressProvinceID
    Private Const COL1_ConAddressDistrictName As Integer = 12 ' Quận/Huyện
    Private Const COL1_ConAddressDistrictID As Integer = 13   ' ConAddressDistrictID
    Private Const COL1_ConAddressWardName As Integer = 14     ' Xã/Phường
    Private Const COL1_ConAddressWardID As Integer = 15       ' ConAddressWardID
    Private Const COL1_ConAddressStreet As Integer = 16       ' Số nhà
    Private Const COL1_IsCreateAddress As Integer = 17        ' Tạo ĐC
    Private Const COL1_Address As Integer = 18                ' Địa chỉ
    Private Const COL1_Occupation As Integer = 19             ' Công việc đang làm
    Private Const COL1_EducationLevelName As Integer = 20     ' Trình độ văn hóa
    Private Const COL1_EducationLevelID As Integer = 21       ' EducationLevelID
    Private Const COL1_SexName As Integer = 22                ' Giới tính
    Private Const COL1_Sex As Integer = 23                    ' Sex
    Private Const COL1_InComeTaxCode As Integer = 24          ' Mã số thuế
    Private Const COL1_IDCardNo As Integer = 25               ' Số CMND
    Private Const COL1_Salary As Integer = 26                 ' Thu nhập
    Private Const COL1_DeductibleDateBegin As Integer = 27    ' Bắt đầu GT
    Private Const COL1_DeductibleDateEnd As Integer = 28      ' Kết thúc GT
    Private Const COL1_ExamineDate As Integer = 29            ' Ngày lập
    Private Const COL1_DeductibleAmount As Integer = 30       ' Mức giảm trừ
    Private Const COL1_Note As Integer = 31                   ' Ghi chú
    Private Const COL1_BirthCertificate As Integer = 32       ' Giấy khai sinh
    Private Const COL1_NumBirthCertificate As Integer = 33    ' Số (Giấy khai sinh)
    Private Const COL1_BookBirthCertificate As Integer = 34   ' Quyển sổ (Giấy khai sinh)
    Private Const COL1_ResidentCertificate As Integer = 35    ' Hộ khẩu
    Private Const COL1_MarriageCertificate As Integer = 36    ' Giấy kết hôn
    Private Const COL1_SchoolConfirmation As Integer = 37     ' Giấy xác nhân đang theo học tại các trường
    Private Const COL1_DisabilityConfirmation As Integer = 38 ' Giấy xác nhận mức độ tàn tật, không có khả năng lao động
    Private Const COL1_BringUpConfirmation As Integer = 39    ' Giấy xác nhận về nghĩa vụ nuôi dưỡng
    Private Const COL1_OtherConfirmations As Integer = 40     ' Các giấy tờ khác
    Private Const COL1_NoteConfirmation As Integer = 41       ' Ghi chú 1
    Private Const COL1_EmployeeID As Integer = 42             ' EmployeeID
    Private Const COL1_IsUpdate As Integer = 43               ' IsUpdate
    Private Const COL1_UndefinedBirthDate As Integer = 44     ' UndefinedBirthDate
#End Region

#Region "Const of tdbgBankID"
    Private Const COLB_IsNewRow As Integer = 0          ' IsNewRow
    Private Const COLB_BankID As Integer = 1            ' Ngân hàng
    Private Const COLB_BankName As Integer = 2          ' BankName
    Private Const COLB_BranchName As Integer = 3        ' Chi nhánh
    Private Const COLB_AccountHolderName As Integer = 4 ' Tên tài khoản
    Private Const COLB_BankAccountNo As Integer = 5     ' Số tài khoản
    Private Const COLB_ExchangeDep As Integer = 6       ' Phòng giao dịch
    Private Const COLB_IsDefault As Integer = 7         ' Mặc định
    Private Const COLB_EmployeeID As Integer = 8        ' EmployeeID
    Private Const COLB_IsUpdate As Integer = 9          ' IsUpdate
#End Region

    Private sTeamID As String = "%"
    Private sEmployeeID As String
    Private AllEmployeeIDs As String
    Private iSub As Integer
    Private dtFind As DataTable
    Private dtBlock, dtTeamID, dtDepartmentID, dtEmpGroupID As DataTable
    Private _payrollVoucherID As String = ""
    Private _payrollVoucherNo As String = ""
    Private _voucherDate As DateTime = Now()
    Private _description As String = ""
    Private bBA As SALBA
    Private bCE As SALCE
    Private bPRMAS As PRMAS
    Private bANA As ANACODE
    Private bANASAL As ANASALARY
    Private bInfoOther As InfoOther
    Private bOL As OLSC
    Private bFlag As Boolean = False
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter, sFilterServer As New System.Text.StringBuilder()

    ' 28/5/2014 id 65377 
    Dim sFormPermisson As String = "D13F2012" '"D13F2010"

    Dim dtGridBankID As DataTable
    Dim dtGridRelative As DataTable

    Dim bUseInfoOther As Boolean = False
    Dim bUseAnaSal As Boolean = False
    Dim bUsePRMAS As Boolean = False
    Dim bUseNextBaseSalary As Boolean = False
    Dim bUseANAD09T0010 As Boolean = False

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    'Private usrOption As D09U1111
    'Private arrMaster As New ArrayList ' Mảng Master

#End Region

    Public Property PayrollVoucherID() As String
        Get
            Return _payrollVoucherID
        End Get
        Set(ByVal value As String)
            If PayrollVoucherID = value Then
                _payrollVoucherID = ""
                Return
            End If
            _payrollVoucherID = value
        End Set
    End Property

    Public Property PayrollVoucherNo() As String
        Get
            Return _payrollVoucherNo
        End Get
        Set(ByVal value As String)
            If PayrollVoucherNo = value Then
                _payrollVoucherNo = ""
                Return
            End If
            _payrollVoucherNo = value
        End Set
    End Property

    Public Property VoucherDate() As DateTime
        Get
            Return _voucherDate
        End Get
        Set(ByVal value As DateTime)
            If VoucherDate = value Then
                _voucherDate = Now()
                Return
            End If
            _voucherDate = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If Description = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private _path As String = ""
    Public WriteOnly Property Path() As String
        Set(ByVal Value As String)
            _path = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2012_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub


    Private Sub D13F2012_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.Enter
                If (txtStrEmployeeID.Text <> "" And Me.ActiveControl.Name = txtStrEmployeeID.Name) OrElse (Me.ActiveControl.Name = txtStrEmployeeName.Name And txtStrEmployeeName.Text <> "") Then Exit Sub
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    btnSalaryCoefficientBase_Click(Nothing, Nothing)
                Case Keys.D2, Keys.NumPad2
                    btnSalaryCoefficientBase_Click(Nothing, Nothing)
                Case Keys.D3, Keys.NumPad3
                    btnNextBaseSalary_Click(Nothing, Nothing)
                Case Keys.D4, Keys.NumPad4
                    btnAnalyseCode_Click(Nothing, Nothing)
                Case Keys.D5, Keys.NumPad4
                    btnBank_Click(Nothing, Nothing)
                Case Keys.D6, Keys.NumPad4
                    btnAnalyseCode_Click(Nothing, Nothing)
                Case Keys.D7, Keys.NumPad4
                    btnAnalyseSalary_Click(Nothing, Nothing)
                Case Keys.D8, Keys.NumPad4
                    btnIncome_Click(Nothing, Nothing)
                Case Keys.D9, Keys.NumPad4
                    btnInfoOther_Click(Nothing, Nothing)
            End Select
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            '            If giRefreshUserControl = 0 Then
            '                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
            '                    usrOption.D09U1111Refresh()
            '                End If
            '            End If
            '            usrOption.Hide()
            usrOption.picClose_Click(Nothing, Nothing)
        End If

        '***************************************
    End Sub

    Public Sub New()
        InitializeComponent()
        AnchorForControl(EnumAnchorStyles.BottomRight, pnl1)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg, grp1)
        AnchorForControl(EnumAnchorStyles.TopRightBottom, tdbgBankID, tdbgRelative)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns, btnCalStandardWorkDay, btnPasswordSetting, btnUpdateReduce)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnClose)
        AnchorForControl(EnumAnchorStyles.TopRight, grpPaymentMethod, btnSalaryCoefficientBase, btnSalaryLevelOfficialTitle, btnNextBaseSalary, btnFamilyDeduction, btnBank, btnAnalyseCode, btnAnalyseSalary, btnIncome, btnInfoOther)
    End Sub

    Private Sub D13F2012_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        iPerD13F1030 = ReturnPermission("D13F1030")
        iPerD13F5613 = ReturnPermission("D13F5613")
        tdbgRelative.Columns(COL1_IsNewRow).DefaultValue = "1" ' Cờ ghi nhận dòng với thêm vào, đẻ khi xoa ding2 trên lưới ko hỏi yes/No
        tdbgBankID.Columns(COLB_IsNewRow).DefaultValue = "1"
        '***********************
        '  c1dateDBirthDate.Value = CDate("31/12/" & Now.Year)
        tdbgRelative.Columns(COL1_DBirthDate).Editor = c1dateDBirthDate
        tdbgRelative.Columns(COL1_MBirthDate).Editor = c1dateMBirthDate
        tdbgRelative.Columns(COL1_YBirthDate).Editor = c1dateYBirthDate

        '***********************
        SetShortcutPopupMenu(Me.C1CommandHolder)
        InputbyUnicode(Me, gbUnicode)
        LoadLanguage()
        txtStrEmployeeID.CharacterCasing = CharacterCasing.Upper
        SetBackColorObligatory()
        If _path = "01" Then sFormPermisson = "D13F2000" ' Hồ sơ lương cá nhân

        ResetGrid()
        'Upadte 21/8/2012 incident 50602
        If Not D13Systems.IsUsedPAna Then
            HideButtonAnalyseSalary()
        End If

        If D13Systems.IsUseBlock Then
            UnReadOnlyControl(True, tdbcBlockID)
        Else
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = False
        End If

        gbEnabledUseFind = False
        '***************
        'Grid Relative
        Dim iColRelative() As Integer = {COL1_Salary, COL1_DeductibleAmount}
        CheckNumberTDBGrid(tdbgRelative, iColRelative)
        ResetFooterGrid(tdbgRelative)
        tdbgRelative_NumberFormat()

        tdbgBankID_LockedColumns()

        ResetColorGrid(tdbg, 0, 1)
        LoadTDBCombo()
        LoadTDBDropDown()
        tdbcDepartmentID.SelectedValue = "%"
        tdbg_InputDate()
        InputDateInTrueDBGrid(tdbgRelative, COL1_DeductibleDateBegin, COL1_DeductibleDateEnd, COL1_ExamineDate)
        Select Case _path
            Case "01"
                tdbg.Splits(SPLIT0).DisplayColumns(COL_PayrollVoucherNo).Visible = True
                mnuEdit.Visible = False
                mnuOpenExtraSalaryFile.Visible = False
                mnuOpenMultiExtraSalaryFile.Visible = False
                btnCalStandardWorkDay.Visible = False
            Case Else
                tdbg.Splits(SPLIT0).DisplayColumns(COL_PayrollVoucherNo).Visible = False
                ' update 21/2/2013 id 53895 chỉnh lại giao diện lưới
                ' tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                'tdbg.Splits(SPLIT1).SplitSize = 138
                '                tdbg.Splits(SPLIT1).SplitSize = 5
                '                tdbg.Splits(SPLIT0).SplitSize = 9
                '   ReadOnlyControl(tdbcPayrollVoucherNo)
        End Select

        ButtonD13T9000()
        ButtonD09T0010()
        ButtonD13T0050()
        ButtonD09T0080()
        'ClickButton(Button.SalaryCoefficientBase)
        tdbg.Splits(1).Caption = rL3("Luong_co_ban_He_so")
        tdbg.Columns(COL_StandardAbsentQuan).NumberFormat = D13Format.DefaultNumber1

        ' CallD09U1111_Button(True)
        CallD99U1111()
        btnPasswordSetting.Enabled = ReturnPermission("D13F5611") >= EnumPermission.View
        SetResolutionForm(Me, Me.C1ContextMenu)
    End Sub

    'Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
    '    'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
    '    If bLoadFirst = True Then
    '        'Những cột bắt buộc nhập
    '        Dim arrColObligatory() As Integer = {COL_EmployeeID}
    '        '-----------------------------------
    '        'Các cột ở SPLIT0
    '        AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
    '        '-----------------------------------
    '        'Các cột ở SPLIT2
    '        'Nút 1
    '        ClickButton(Button.SalaryCoefficientBase, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 2
    '        ClickButton(Button.SalaryLevelOfficialTitle, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 3
    '        ClickButton(Button.NextBaseSalary, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 6
    '        ClickButton(Button.AnalyseCode, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 7
    '        ClickButton(Button.AnalyseSalary, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 8
    '        ClickButton(Button.Income, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        'Nút 9
    '        ClickButton(Button.InfoOther, True)
    '        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
    '        '-----------------------------------
    '        'Bật lại Nút 1 để trở về trạng thái ban đầu
    '        ClickButton(Button.SalaryCoefficientBase, True)
    '    End If

    '    'Dim dtCaptionCols As DataTable
    '    dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
    '    If usrOption IsNot Nothing Then usrOption.Dispose()
    '    usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)

    'End Sub

    Private Sub SetBackColorObligatory()
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmpGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankAccountNo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgRelative.Splits(SPLIT0).DisplayColumns(COL1_DeductibleDateBegin).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgRelative.Splits(SPLIT0).DisplayColumns(COL1_YBirthDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Ho_so_luongf") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Hä s¥ l§¥ng - D13F2012
        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblEmpGroupID.Text = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblStrEmployeeID.Text = rL3("Ma_NV") 'Mã NV
        lblStrEmployeeName.Text = rL3("Ten_NV") 'Tên NV
        '================================================================ 
        btnSalaryCoefficientBase.Text = "1. " & rL3("Luong_co_ban_He_soV") '1. Lương cơ bản/ Hệ số
        btnSalaryLevelOfficialTitle.Text = "2. " & rL3("Ngach_-_bac_luong") '2. Ngạch - Bậc lương
        btnNextBaseSalary.Text = "3. " & rL3("Luong_tiep_theo") '3. Lương tiếp theo
        btnFamilyDeduction.Text = "4. " & rL3("Giam_tru_gia_canh") '4. Giảm trừ gia cảnh
        btnBank.Text = "5. " & rL3("Thong_tin_tra_luong") 'Thông tin trả lương  "5. " & rL3("Ngan_hang") '5. Ngân hàng
        btnAnalyseCode.Text = "6. " & rL3("Ma_phan_tich_nhan_su") '6. Mã phân tích nhân sự
        btnAnalyseSalary.Text = "7. " & rL3("Ma_phan_tich_tien_luong") '7. Mã phân tích tiền lương
        btnIncome.Text = "8. " & rL3("Thu_nhap") '8. Thu nhập
        btnInfoOther.Text = "9. " & rL3("Thong_tin_khac") '9. Thông tin khác
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnCalStandardWorkDay.Text = rL3("Tinh_ngay__cong_chuan") 'Tính ngày &công chuẩn
        btnShowColumns.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        btnFilter.Text = rL3("Loc") & Space(1) & "(F5)" '&Lọc
        btnSave.Text = rL3("_Luu") '&Lưu
        '================================================================ 
        chkIsBelongCicle.Text = rL3("NV_thuoc_chu_ky_luong") ' NV thuộc chu kỳ lương
        chkIsNotBelongCicle.Text = rL3("NV_khong_thuoc_chu_ky_luong") 'NV không thuộc chu kỳ lương
        '================================================================ 
        optPaymentMethod_C.Text = rL3("Tien_mat") 'Tiền mặt
        optPaymentMethod_B.Text = rL3("Chuyen_khoan") 'Chuyển khoản
        optPaymentMethod_O.Text = rL3("Hinh_thuc_khac") 'Hình thức khác

        '================================================================ 
        grpPaymentMethod.Text = rL3("Phuong_thuc_tra_luong") 'Phương thức trả lương

        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rL3("Ma") 'Mã
        tdbcEmpGroupID.Columns("EmpGroupName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblProjectID.Text = rL3("Cong_trinh") 'Dự án
        '================================================================ 
        tdbcProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbcProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên


        '================================================================ 
        tdbdBankID.Columns("BankID").Caption = rL3("Ma") 'Mã
        tdbdBankID.Columns("BankName").Caption = rL3("Ten") 'Tên
        tdbdRelativeName.Columns("RelativeName").Caption = rL3("Ten") 'Tên
        tdbdRelationID.Columns("RelationName").Caption = rL3("Ten") 'Tên
        tdbdSex.Columns("Sex").Caption = rL3("Ma") 'Mã
        tdbdSex.Columns("SexName").Caption = rL3("Ten") 'Tên
        tdbdEducationLevelID.Columns("EducationLevelID").Caption = rL3("Ma") 'Mã
        tdbdEducationLevelID.Columns("EducationLevelName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbgBankID.Columns(COLB_BankID).Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbgBankID.Columns(COLB_BranchName).Caption = rL3("Chi_nhanh") 'Chi nhánh
        tdbgBankID.Columns(COLB_AccountHolderName).Caption = rL3("Ten_tai_khoan") 'Tên tài khoản
        tdbgBankID.Columns(COLB_BankAccountNo).Caption = rL3("So_tai_khoan") 'Số tài khoản
        tdbgBankID.Columns(COLB_ExchangeDep).Caption = rL3("Phong_giao_dich") 'Phòng giao dịch
        tdbgBankID.Columns(COLB_IsDefault).Caption = rL3("Mac_dinh") 'Mặc định
        tdbgRelative.Columns(COL1_RelationName).Caption = rL3("Quan_he") 'Quan hệ
        tdbgRelative.Columns(COL1_RelativeName).Caption = rL3("Ten_nguoi_quan_he") 'Tên người quan hệ
        tdbgRelative.Columns(COL1_DBirthDate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbgRelative.Columns(COL1_MBirthDate).Caption = rL3("Thang_sinh") 'Tháng sinh
        tdbgRelative.Columns(COL1_YBirthDate).Caption = rL3("Nam_sinh") 'Năm sinh
        tdbgRelative.Columns(COL1_CountryTypeID).Caption = rL3("Quoc_gia") 'Quốc gia
        tdbgRelative.Columns(COL1_BirthPlace).Caption = rL3("Noi_sinh") 'Nơi sinh
        tdbgRelative.Columns(COL1_Address).Caption = rL3("Dia_chi") 'Địa chỉ
        tdbgRelative.Columns(COL1_Occupation).Caption = rL3("Cong_viec_dang_lam") 'Công việc đang làm
        tdbgRelative.Columns(COL1_EducationLevelName).Caption = rL3("Trinh_do_van_hoa_U") 'Trình độ văn hóa
        tdbgRelative.Columns(COL1_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbgRelative.Columns(COL1_InComeTaxCode).Caption = rL3("Ma_so_thue") 'Mã số thuế
        tdbgRelative.Columns(COL1_IDCardNo).Caption = rL3("So_CMND") 'Số CMND
        tdbgRelative.Columns(COL1_Salary).Caption = rL3("Thu_nhap") 'Thu nhập
        tdbgRelative.Columns(COL1_DeductibleDateBegin).Caption = rL3("Bat_dau_GT") 'Bắt đầu GT
        tdbgRelative.Columns(COL1_DeductibleDateEnd).Caption = rL3("Ket_thuc_GT") 'Kết thúc GT
        tdbgRelative.Columns(COL1_ExamineDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbgRelative.Columns(COL1_DeductibleAmount).Caption = rL3("Muc_giam_tru") 'Mức giảm trừ
        tdbgRelative.Columns(COL1_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbgRelative.Columns(COL1_BirthCertificate).Caption = rL3("Giay_khai_sinh") 'Giấy khai sinh
        tdbgRelative.Columns(COL1_NumBirthCertificate).Caption = rL3("So") & " (" & rL3("Giay_khai_sinh") & ")" 'Số (Giấy khai sinh)
        tdbgRelative.Columns(COL1_BookBirthCertificate).Caption = rL3("Quyen_so") & " (" & rL3("Giay_khai_sinh") & ")" 'Quyển sổ (Giấy khai sinh)
        tdbgRelative.Columns(COL1_ResidentCertificate).Caption = rL3("Ho_khau") 'Hộ khẩu
        tdbgRelative.Columns(COL1_MarriageCertificate).Caption = rL3("Giay_ket_hon") 'Giấy kết hôn
        tdbgRelative.Columns(COL1_SchoolConfirmation).Caption = rL3("Giay_xac_nhan_dang_theo_hoc_tai_cac_truong") 'Giấy xác nhân đang theo học tại các trường
        tdbgRelative.Columns(COL1_DisabilityConfirmation).Caption = rL3("Giay_xac_nhan_muc_do_tan_tat_khong_co_kha_nang_lao_dong") 'Giấy xác nhận mức độ tàn tật, không có khả năng lao động
        tdbgRelative.Columns(COL1_BringUpConfirmation).Caption = rL3("Giay_xac_nhan_ve_nghia_vu_nuoi_duong") 'Giấy xác nhận về nghĩa vụ nuôi dưỡng
        tdbgRelative.Columns(COL1_OtherConfirmations).Caption = rL3("Cac_giay_to_khac") 'Các giấy tờ khác

        tdbgRelative.Columns(COL1_ConAddressProvinceName).Caption = rL3("TinhThanh_pho") 'Tỉnh/Thành phố
        tdbgRelative.Columns(COL1_ConAddressDistrictName).Caption = rL3("QuanHuyen") 'Quận/Huyện
        tdbgRelative.Columns(COL1_ConAddressWardName).Caption = rL3("XaPhuong") 'Xã/Phường
        tdbgRelative.Columns(COL1_ConAddressStreet).Caption = rL3("So_nha") 'Số nhà
        tdbgRelative.Columns(COL1_IsCreateAddress).Caption = rL3("Tao_DC") 'Tạo ĐC

        '================================================================ 
        tdbgRelative.Columns(COL1_NoteConfirmation).Caption = rL3("Ghi_chu_khac") 'Ghi chú khác




        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_FullName).Caption = rL3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns(COL_BlockID).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm 
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_EmpGroupID).Caption = rL3("Nhom_NV") 'Nhóm NV
        tdbg.Columns(COL_EmpGroupName).Caption = rL3("Ten_nhom_NV") 'Tên nhóm NV
        '---------------------
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns(COL_PeriodID).Caption = rL3("Tap_phi") 'Tập phí
        tdbg.Columns(COL_Note).Caption = rL3("Dien_giai_tap_phi") 'Diễn giải tập phí
        tdbg.Columns(COL_SubDutyID).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_DutyName).Caption = rL3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_WorkName).Caption = rL3("Ten_cong_viec") 'Tên công việc
        tdbg.Columns(COL_Birthdate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_DateJoined).Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_DateLeft).Caption = rL3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbg.Columns(COL_Age).Caption = rL3("Tuoi") 'Tuổi
        tdbg.Columns(COL_StatusID).Caption = rL3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbg.Columns(COL_StatusName).Caption = rL3("Ten_trang_thai_lam_viec") 'Tên trạng thái làm việc
        tdbg.Columns(COL_AttendanceCardNo).Caption = rL3("Ma_the_cham_cong") 'Mã thẻ chấm công
        tdbg.Columns(COL_RefEmployeeID).Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns(COL_IsSub).Caption = rL3("HSL_phu") 'HSL phụ
        tdbg.Columns(COL_StandardAbsentQuan).Caption = rL3("Ngay_cong_chuan") 'Ngày công chuẩn
        tdbg.Columns(COL_ValidDateFrom).Caption = rL3("Ngay_cham_cong_(Tu)") 'Ngày chấm công (Từ)
        tdbg.Columns(COL_ValidDateTo).Caption = rL3("Ngay_cham_cong_(Den)") 'Ngày chấm công (Đến)
        tdbg.Columns(COL_FullSalCycle).Caption = rL3("Du_chu_ky_luong") 'Đủ chu kỳ lương
        tdbg.Columns(COL_SalaryRate).Caption = rL3("Ty_le_huong_luong") & " (%)"  'Tỷ lệ hưởng lương (%)
        tdbg.Columns(COL_RefNo).Caption = rL3("So_tham_chieu") 'Số tham chiếu
        tdbg.Columns(COL_TaxObjectID).Caption = rL3("Ma_DT_tinh_thue") 'Mã ĐT tính thuế
        tdbg.Columns(COL_TaxObjectName).Caption = rL3("Ten_DT_tinh_thue") 'Tên ĐT tính thuế
        tdbg.Columns(COL_PayrollVoucherNo).Caption = rL3("Ho_so_luong_thang") 'Hồ sơ lương tháng
        tdbg.Columns(COL_BASE01).Caption = rL3("Luong_co_ban") & " 01" 'Lương cơ bản 01
        tdbg.Columns(COL_BASE02).Caption = rL3("Luong_co_ban") & " 02" 'Lương cơ bản 02
        tdbg.Columns(COL_BASE03).Caption = rL3("Luong_co_ban") & " 03" 'Lương cơ bản 03
        tdbg.Columns(COL_BASE04).Caption = rL3("Luong_co_ban") & " 04" 'Lương cơ bản 04
        tdbg.Columns(COL_CE01).Caption = rL3("He_so") & " 01" 'Hệ số 01
        tdbg.Columns(COL_CE02).Caption = rL3("He_so") & " 02" 'Hệ số 02
        tdbg.Columns(COL_CE03).Caption = rL3("He_so") & " 03" 'Hệ số 03
        tdbg.Columns(COL_CE04).Caption = rL3("He_so") & " 04" 'Hệ số 04
        tdbg.Columns(COL_CE05).Caption = rL3("He_so") & " 05" 'Hệ số 05
        tdbg.Columns(COL_CE06).Caption = rL3("He_so") & " 06" 'Hệ số 06
        tdbg.Columns(COL_CE07).Caption = rL3("He_so") & " 07" 'Hệ số 07
        tdbg.Columns(COL_CE08).Caption = rL3("He_so") & " 08" 'Hệ số 08
        tdbg.Columns(COL_CE09).Caption = rL3("He_so") & " 09" 'Hệ số 09
        tdbg.Columns(COL_CE10).Caption = rL3("He_so") & " 10" 'Hệ số 10
        tdbg.Columns(COL_INC01).Caption = rL3("Thu_nhap") & " 01" 'Thu nhập 01
        tdbg.Columns(COL_INC02).Caption = rL3("Thu_nhap") & " 02" 'Thu nhập 02
        tdbg.Columns(COL_INC03).Caption = rL3("Thu_nhap") & " 03" 'Thu nhập 03
        tdbg.Columns(COL_INC04).Caption = rL3("Thu_nhap") & " 04" 'Thu nhập 04
        tdbg.Columns(COL_INC05).Caption = rL3("Thu_nhap") & " 05" 'Thu nhập 05
        tdbg.Columns(COL_INC06).Caption = rL3("Thu_nhap") & " 06" 'Thu nhập 06
        tdbg.Columns(COL_INC07).Caption = rL3("Thu_nhap") & " 07" 'Thu nhập 07
        tdbg.Columns(COL_INC08).Caption = rL3("Thu_nhap") & " 08" 'Thu nhập 08
        tdbg.Columns(COL_INC09).Caption = rL3("Thu_nhap") & " 09" 'Thu nhập 09
        tdbg.Columns(COL_INC10).Caption = rL3("Thu_nhap") & " 10" 'Thu nhập 10
        tdbg.Columns(COL_INC11).Caption = rL3("Thu_nhap") & " 11" 'Thu nhập 11
        tdbg.Columns(COL_INC12).Caption = rL3("Thu_nhap") & " 12" 'Thu nhập 12
        tdbg.Columns(COL_INC13).Caption = rL3("Thu_nhap") & " 13" 'Thu nhập 13
        tdbg.Columns(COL_INC14).Caption = rL3("Thu_nhap") & " 14" 'Thu nhập 14
        tdbg.Columns(COL_INC15).Caption = rL3("Thu_nhap") & " 15" 'Thu nhập 15
        tdbg.Columns(COL_INC16).Caption = rL3("Thu_nhap") & " 16" 'Thu nhập 16
        tdbg.Columns(COL_INC17).Caption = rL3("Thu_nhap") & " 17" 'Thu nhập 17
        tdbg.Columns(COL_INC18).Caption = rL3("Thu_nhap") & " 18" 'Thu nhập 18
        tdbg.Columns(COL_INC19).Caption = rL3("Thu_nhap") & " 19" 'Thu nhập 19
        tdbg.Columns(COL_INC20).Caption = rL3("Thu_nhap") & " 20" 'Thu nhập 20
        tdbg.Columns(COL_INC21).Caption = rL3("Thu_nhap") & " 21" 'Thu nhập 21
        tdbg.Columns(COL_INC22).Caption = rL3("Thu_nhap") & " 22" 'Thu nhập 22
        tdbg.Columns(COL_INC23).Caption = rL3("Thu_nhap") & " 23" 'Thu nhập 23
        tdbg.Columns(COL_INC24).Caption = rL3("Thu_nhap") & " 24" 'Thu nhập 24
        tdbg.Columns(COL_INC25).Caption = rL3("Thu_nhap") & " 25" 'Thu nhập 25
        tdbg.Columns(COL_INC26).Caption = rL3("Thu_nhap") & " 26" 'Thu nhập 26
        tdbg.Columns(COL_INC27).Caption = rL3("Thu_nhap") & " 27" 'Thu nhập 27
        tdbg.Columns(COL_INC28).Caption = rL3("Thu_nhap") & " 28" 'Thu nhập 28
        tdbg.Columns(COL_INC29).Caption = rL3("Thu_nhap") & " 29" 'Thu nhập 29
        tdbg.Columns(COL_INC30).Caption = rL3("Thu_nhap") & " 30" 'Thu nhập 30
        tdbg.Columns(COL_N01).Caption = rL3("Ma_phan_tichN") & " 01" 'Mã phân tích 01
        tdbg.Columns(COL_N02).Caption = rL3("Ma_phan_tichN") & " 02" 'Mã phân tích 02
        tdbg.Columns(COL_N03).Caption = rL3("Ma_phan_tichN") & " 03" 'Mã phân tích 03
        tdbg.Columns(COL_N04).Caption = rL3("Ma_phan_tichN") & " 04" 'Mã phân tích 04
        tdbg.Columns(COL_N05).Caption = rL3("Ma_phan_tichN") & " 05" 'Mã phân tích 05
        tdbg.Columns(COL_N06).Caption = rL3("Ma_phan_tichN") & " 06" 'Mã phân tích 06
        tdbg.Columns(COL_N07).Caption = rL3("Ma_phan_tichN") & " 07" 'Mã phân tích 07
        tdbg.Columns(COL_N08).Caption = rL3("Ma_phan_tichN") & " 08" 'Mã phân tích 08
        tdbg.Columns(COL_N09).Caption = rL3("Ma_phan_tichN") & " 09" 'Mã phân tích 09
        tdbg.Columns(COL_N10).Caption = rL3("Ma_phan_tichN") & " 10" 'Mã phân tích 10
        tdbg.Columns(COL_N11).Caption = rL3("Ma_phan_tichN") & " 11" 'Mã phân tích 11
        tdbg.Columns(COL_N12).Caption = rL3("Ma_phan_tichN") & " 12" 'Mã phân tích 12
        tdbg.Columns(COL_N13).Caption = rL3("Ma_phan_tichN") & " 13" 'Mã phân tích 13
        tdbg.Columns(COL_N14).Caption = rL3("Ma_phan_tichN") & " 14" 'Mã phân tích 14
        tdbg.Columns(COL_N15).Caption = rL3("Ma_phan_tichN") & " 15" 'Mã phân tích 15
        tdbg.Columns(COL_N16).Caption = rL3("Ma_phan_tichN") & " 16" 'Mã phân tích 16
        tdbg.Columns(COL_N17).Caption = rL3("Ma_phan_tichN") & " 17" 'Mã phân tích 17
        tdbg.Columns(COL_N18).Caption = rL3("Ma_phan_tichN") & " 18" 'Mã phân tích 18
        tdbg.Columns(COL_N19).Caption = rL3("Ma_phan_tichN") & " 19" 'Mã phân tích 19
        tdbg.Columns(COL_N20).Caption = rL3("Ma_phan_tichN") & " 20" 'Mã phân tích 20
        tdbg.Columns(COL_P01).Caption = rL3("Ma_phan_tich_tien_luong") & " 01" 'Mã phân tích tiền lương 01
        tdbg.Columns(COL_P02).Caption = rL3("Ma_phan_tich_tien_luong") & " 02" 'Mã phân tích tiền lương 02
        tdbg.Columns(COL_P03).Caption = rL3("Ma_phan_tich_tien_luong") & " 03" 'Mã phân tích tiền lương 03
        tdbg.Columns(COL_P04).Caption = rL3("Ma_phan_tich_tien_luong") & " 04" 'Mã phân tích tiền lương 04
        tdbg.Columns(COL_P05).Caption = rL3("Ma_phan_tich_tien_luong") & " 05" 'Mã phân tích tiền lương 05
        tdbg.Columns(COL_P06).Caption = rL3("Ma_phan_tich_tien_luong") & " 06" 'Mã phân tích tiền lương 06
        tdbg.Columns(COL_P07).Caption = rL3("Ma_phan_tich_tien_luong") & " 07" 'Mã phân tích tiền lương 07
        tdbg.Columns(COL_P08).Caption = rL3("Ma_phan_tich_tien_luong") & " 08" 'Mã phân tích tiền lương 08
        tdbg.Columns(COL_P09).Caption = rL3("Ma_phan_tich_tien_luong") & " 09" 'Mã phân tích tiền lương 09
        tdbg.Columns(COL_P10).Caption = rL3("Ma_phan_tich_tien_luong") & " 10" 'Mã phân tích tiền lương 10
        tdbg.Columns(COL_P11).Caption = rL3("Ma_phan_tich_tien_luong") & " 11" 'Mã phân tích tiền lương 11
        tdbg.Columns(COL_P12).Caption = rL3("Ma_phan_tich_tien_luong") & " 12" 'Mã phân tích tiền lương 12
        tdbg.Columns(COL_P13).Caption = rL3("Ma_phan_tich_tien_luong") & " 13" 'Mã phân tích tiền lương 13
        tdbg.Columns(COL_P14).Caption = rL3("Ma_phan_tich_tien_luong") & " 14" 'Mã phân tích tiền lương 14
        tdbg.Columns(COL_P15).Caption = rL3("Ma_phan_tich_tien_luong") & " 15" 'Mã phân tích tiền lương 15
        tdbg.Columns(COL_P16).Caption = rL3("Ma_phan_tich_tien_luong") & " 16" 'Mã phân tích tiền lương 16
        tdbg.Columns(COL_P17).Caption = rL3("Ma_phan_tich_tien_luong") & " 17" 'Mã phân tích tiền lương 17
        tdbg.Columns(COL_P18).Caption = rL3("Ma_phan_tich_tien_luong") & " 18" 'Mã phân tích tiền lương 18
        tdbg.Columns(COL_P19).Caption = rL3("Ma_phan_tich_tien_luong") & " 19" 'Mã phân tích tiền lương 19
        tdbg.Columns(COL_P20).Caption = rL3("Ma_phan_tich_tien_luong") & " 20" 'Mã phân tích tiền lương 20
        tdbg.Columns(COL_PaymentMethodName).Caption = rL3("Phuong_thuc_tra_luong") 'Phương thức trả lương

        tdbg.Columns(COL_BankID).Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbg.Columns(COL_BankName).Caption = rL3("Ten_ngan_hang") 'Tên ngân hàng
        tdbg.Columns(COL_BankAccountNo).Caption = rL3("So_tai_khoan") 'Số tài khoản
        tdbg.Columns(COL_ExchangeDep).Caption = rL3("Phong_giao_dich") 'Phòng giao dịch

        tdbg.Columns(COL_SalEmpGroupName).Caption = rL3("Ten_nhom_luong") 'Tên nhóm lương
        tdbg.Columns(COL_SalaryObjectID).Caption = rL3("Ma_DT_tinh_luong") 'Mã ĐT tính lương
        tdbg.Columns(COL_SalaryObjectName).Caption = rL3("Ten_DT_tinh_luong") 'Tên ĐT tính lương
        tdbg.Columns(COL_StatusMaternityName).Caption = rL3("Trang_thai_thai_san_con_nho") 'Trạng thái thai sản, con nhỏ
        tdbg.Columns(COL_Disabled).Caption = rL3("Da_nghi_viec") 'Đã nghỉ việc
        '120729 - 17 July 2019
        tdbg.Columns(COL_OfficialTitleName1).Caption = rL3("Ten_ngach_luong") & " 1" 'Tên ngạch lương 1
        tdbg.Columns(COL_SalaryLevelName1).Caption = rL3("Ten_bac_luong") & " 1" 'Tên bậc lương 1
        tdbg.Columns(COL_OfficialTitleName2).Caption = rL3("Ten_ngach_luong") & " 2" 'Tên ngạch lương 2
        tdbg.Columns(COL_SalaryLevelName2).Caption = rL3("Ten_bac_luong") & " 2" 'Tên bậc lương 2

        '================================================================ 
        mnuAdd.Text = rL3("_Them") '&Thêm
        mnuEdit.Text = rL3("_Sua") '&Sửa
        mnuDelete.Text = rL3("_Xoa") '&Xóa
        mnuOpenExtraSalaryFile.Text = rL3("Mo_HSL_phu") 'Mở HSL phụ
        mnuFind.Text = rL3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("Liet__ke_tat_ca") 'Liệt &kê tất cả
        mnuSysInfo.Text = rL3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuMultiEdit.Text = rL3("Sua_hang__loat") 'Sửa hàng &loạt
        mnuOpenMultiExtraSalaryFile.Text = rL3("Mo_HSL__phu_hang_loat") 'Mở HSL &phụ hàng loạt
        mnuExportToExcel.Text = rL3("Xuat__Excel") 'Xuất &Excel
        '================================================================ 
        mnuImportData.Text = rL3("Import__du_lieu") 'Import &dữ liệu 
        mnuImportBankInfo.Text = "&1. " & rL3("Thong_tin_ngan_hang") 'Thông tin ngân hàng
        mnuImportImfoRef.Text = "&2. " & rL3("Thong_tin_tham_chieu") 'Thông tin tham chiếu
        '================================================================ 
        tdbgBankID.Splits(0).Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbgRelative.Splits(0).Caption = rL3("Giam_tru_gia_canh") 'Ngân hàng
        tdbg.Splits(0).Caption = rL3("Thong_tin_chinh") 'Thông tin chính
        tdbg.Splits(1).Caption = rL3("Luong_co_ban_He_soV") 'Lương cơ bản/ Hệ số
        '================================================================ 
        btnPasswordSetting.Text = rL3("Thong_tin_gui_mail") 'Thông tin gửi mail

        C1CommandMenu1.Text = rL3("Import_du_lieu") 'Import dữ liệu

        '================================================================ 
        tdbdConAddressDistrictID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressDistrictID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdConAddressWardID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressWardID.Columns("Name").Caption = rL3("Ten") 'Tên
        tdbdConAddressProvinceID.Columns("Code").Caption = rL3("Ma") 'Mã
        tdbdConAddressProvinceID.Columns("Name").Caption = rL3("Ten") 'Tên

        '================================================================ 
        btnUpdateReduce.Text = rL3("Cap_nhat_giam_tru_gia_canh") 'Cập nhật giảm trừ gia cảnh

    End Sub

    Private Sub txtStrEmployeeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStrEmployeeID.KeyDown, txtStrEmployeeName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim txtText As TextBox = CType(sender, TextBox)
            If txtText.Text = "" Then Exit Sub
            btnFilter_Click(sender, Nothing)
            txtText.Focus()
            txtText.SelectAll()
        End If
    End Sub

    Private Sub txtStrEmployeeID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStrEmployeeID.Validated, txtStrEmployeeName.Validated
        Dim txtText As TextBox = CType(sender, TextBox)
        If txtText.Text = "" Then Exit Sub
        btnFilter_Click(sender, Nothing)
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim iMode As Integer = 1
        Dim sKey02 As String = ""

        Select Case _path
            Case "01"
                iMode = 3
                sKey02 = "D13F2012"
            Case Else
                iMode = 1
                sKey02 = "0001"
        End Select

        Dim sSQLDeleteD91T9009 As String = ""
        ' 28/11/2013 id 61701
        sSQLDeleteD91T9009 = "Delete D91T9009 Where UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name) & " and FormID='D13F2000'"
        'sSQLDeleteD91T9009 = "Delete D91T9009 Where UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name) & " and Key02ID = 'D13F2012'"
        ExecuteSQLNoTransaction(sSQLDeleteD91T9009)

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D09F2050")
        SetProperties(arrPro, "FormID", "D13F2000")
        SetProperties(arrPro, "ModuleID", D13)
        SetProperties(arrPro, "Mode", iMode)
        SetProperties(arrPro, "Voucher01ID", gsPayRollVoucherID)
        SetProperties(arrPro, "Key01", "F_EmployeeID")
        SetProperties(arrPro, "Key02", sKey02)
        SetProperties(arrPro, "Key03", "")
        SetProperties(arrPro, "Key04", "")
        SetProperties(arrPro, "Key05", "")
        SetProperties(arrPro, "ShowEmpStopWork", True)
        ' Hiện tại thấy D09 ko nhận formstate
        Dim frm As Form = CallFormShowDialog("D09D2040", "D09F5605", arrPro)

        If L3Bool(GetProperties(frm, "bSaved")) Then
            ExecuteSQLNoTransaction(SQLStoreD13P2017)
            ExecuteSQLNoTransaction(sSQLDeleteD91T9009)

            LoadTDBGrid(True)
        End If

        '        Dim f As New D09F5605
        '        With f
        '            .FormActive = D09E2040Form.D09F5605
        '            .FormPermission = "D09F2050"
        '            ' 28/11/2013 id 61701
        '            .FormID = "D13F2000"
        '            '.FormID = sFormPermisson '"D13F2010"
        '            .ModuleID = "D13"
        '            .Mode = iMode
        '            .Voucher01ID = gsPayRollVoucherID ' _payrollVoucherID
        '            .Key01ID = "F_EmployeeID"
        '            .Key02ID = sKey02
        '            .Key03ID = ""
        '            .Key04ID = ""
        '            .Key05ID = ""
        '            .ShowEmpStopWork = "1"
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '
        '        If CBool(D99C0007.GetOthersSetting("D09", "D09E2040", "ButtonChoose", "False")) Then
        '            'Thuc thi them moi nhan vien vao Ho so luong ca nhan
        '            ' 28/11/2013 id 61701 - Bỏ gọi màn hình D13F2013
        '            ExecuteSQLNoTransaction(SQLStoreD13P2017)
        '            ExecuteSQLNoTransaction(sSQLDeleteD91T9009)
        '            '            Select Case _path
        '            '                Case "01"
        '            '                    ExecuteSQLNoTransaction(SQLStoreD13P2017)
        '            '                    ExecuteSQLNoTransaction(sSQLDeleteD91T9009)
        '            '                Case Else
        '            '                    Dim f1 As New D13F2013
        '            '                    With f1
        '            '                        .PayrollVoucherID = gsPayRollVoucherID '_payrollVoucherID
        '            '                        .PayrollVoucherNo = _payrollVoucherNo
        '            '                        .VoucherDate = _voucherDate
        '            '                        .Description = _description
        '            '                        .FormState = EnumFormState.FormAdd
        '            '                        .ShowDialog()
        '            '                        .Dispose()
        '            '                    End With
        '            '            End Select
        '
        '            LoadTDBGrid(True)
        '        End If

        'If .bSaved Then LoadTDBGrid(True)
    End Sub

    Public Function MyCheckStore(ByVal SQL As String, Optional ByVal bMsgAsk As Boolean = False) As String
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
                dt = Nothing
                Return "0"
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing

                Return "1"
            Else 'YesNo
                If Not bFontMessage Then
                    If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return "1"
                    Else
                        dt = Nothing
                        Return "-1"
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return "1"
                            Else
                                dt = Nothing
                                Return "-1"
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return "1"
                            Else
                                dt = Nothing
                                Return "-1"
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return "1"
                            Else
                                dt = Nothing
                                Return "-1"
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return "-1"
        End If
        Return "0"
    End Function

    Dim sTransList As String
    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sTransList = ""
        'Kiểm tra trước khi sửa
        Dim sSQL As String = ""
        ' update 15/4/2013 id 55205 - đề nghị PROG bỏ đoạn insert vào bảng D91T9009.
        '        sSQL &= SQLDeleteD91T9009()
        '        sSQL &= SQLInsertD91T9009s_B().ToString
        sSQL &= SQLStoreD13P0102(2)

        'If Not MyCheckStore(sSQL) Then
        '    Exit Sub
        'End If

        Dim sStatus As String = "0"
        Select Case MyCheckStore(sSQL, True)
            Case "-1"
                Exit Sub
            Case "0"
                sStatus = "0"
            Case "1"
                sStatus = "1"
        End Select
        sTransList = GetDataSelectRows(COL_TransID, tdbg)
        'Dim sTransID As String = ""
        Dim f As New D13F2013
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .Status = sStatus
            .DepartmentID = GetDataSelectRows(COL_DepartmentID, tdbg)
            .TeamID = GetDataSelectRows(COL_TeamID, tdbg)
            .EmployeeID = GetDataSelectRows(COL_EmployeeID, tdbg)
            .dtEmployee = dtFind.Copy
            'sTransID = GetDataSelectRows(COL_TransID, tdbg)
            '.dtEmployee.DefaultView.RowFilter = "DepartmentID In(" & f.DepartmentID & ") And TeamID In(" & f.TeamID & ") And EmployeeID In(" & f.EmployeeID & ")"


            '.dtEmployee.DefaultView.RowFilter = "TransID In ( " & sTransList & ")"
            .dtEmployee.DefaultView.RowFilter = "EmployeeID =" & GetDataSelectRows(COL_EmployeeID, tdbg)  'ID 101728 17.08.2017
            .PayrollVoucherID = gsPayRollVoucherID '_payrollVoucherID
            .PayrollVoucherNo = _payrollVoucherNo
            .VoucherDate = _voucherDate
            .Description = _description
            ' update 5/3/5013 id 54589 - Khi gọi từ "D13/ Nghiệp vụ/ Hồ sơ lương cá nhân/ DoubleClick một row trên Grid" Thì mờ nút lưu
            If _path <> "01" Then
                .FormState = EnumFormState.FormEdit
            Else
                .FormState = EnumFormState.FormView
            End If

            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With

    End Sub

    ' update 15/4/2013 id 55205
    Private Sub mnuMultiEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMultiEdit.Click
        Dim sSQL As String
        sSQL = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666().ToString & vbCrLf
        sSQL &= SQLStoreD13P0102(2, True)
        Dim sStatus As String = "0"
        Select Case MyCheckStore(sSQL, True)
            Case "-1"
                Exit Sub
            Case "0"
                sStatus = "0"
            Case "1"
                sStatus = "1"
        End Select
        ExecuteSQLNoTransaction(SQLDeleteD09T6666)

        'ID 101728 17.08.2017
        Dim dtSource As DataTable = dtFind.DefaultView.ToTable
        Dim dr() As DataRow = dtFind.Select("IsSub=1")
        If dr.Length > 0 Then
            For Each drScan As DataRow In dr
                If dtSource.Select("EmployeeID=" & SQLString(drScan("EmployeeID"))).Length > 0 And dtSource.Select("EmployeeID=" & SQLString(drScan("EmployeeID")) & " And IsSub=1").Length = 0 Then
                    dtSource.ImportRow(drScan)
                    dtSource.AcceptChanges()
                End If
            Next
        End If
        '***********************************

        Dim f As New D13F2013
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .Status = sStatus
            '            .DepartmentID = GetDataSelectRows(COL_DepartmentID, tdbg)
            '            .TeamID = GetDataSelectRows(COL_TeamID, tdbg)
            '            .EmployeeID = GetDataSelectRows(COL_EmployeeID, tdbg)
            .dtEmployee = dtSource 'dtFind.DefaultView.ToTable
            .PayrollVoucherID = gsPayRollVoucherID '_payrollVoucherID
            .PayrollVoucherNo = _payrollVoucherNo
            .VoucherDate = _voucherDate
            .Description = _description

            .FormState = EnumFormState.FormEditOther
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With

    End Sub
    Private Const TINHTHANH As String = "TINH/THANH"
    Private Const QUANHUYEN As String = "QUAN/HUYEN"
    Private Const XAPHUONG As String = "XA/PHUONG"
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        dtEmpGroupID = ReturnTableEmpGroupID(, gbUnicode)
        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
        tdbcBlockID.SelectedValue = "%"


        Using proj As Lemon3.Data.LoadData.LoadDataG4 = New Lemon3.Data.LoadData.LoadDataG4
            proj.LoadProjectByG4(tdbcProjectID, dtProject, "D13F2010")
            tdbcProjectID.SelectedIndex = 0
        End Using
        dtAddress = ReturnDataTable(SQLStoreD09P1509)
        LoadDataSource(tdbdConAddressProvinceID, ReturnTableFilter(dtAddress, "SourceName = " & SQLString(TINHTHANH), True), gbUnicode)
    End Sub

    Private Sub LoadDrodownAddress(tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, sParrent As String)
        If sParrent = "" Then
            LoadDataSource(tdbd, dtAddress.Clone, gbUnicode)
        Else
            LoadDataSource(tdbd, ReturnTableFilter(dtAddress, "ParentID = " & SQLString(sParrent)), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdRelationID
        sSQL = "SELECT RelationID, RelationName" & UnicodeJoin(gbUnicode) & " as RelationName" & vbCrLf
        sSQL &= "FROM D09T0240 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY RelationName"
        LoadDataSource(tdbdRelationID, sSQL, gbUnicode)

        'Load tdbdRelativeName
        sSQL = "SELECT D2.EmployeeID, RelativeName" & UnicodeJoin(gbUnicode) & " as RelativeName, RelationID, " & vbCrLf
        sSQL &= "convert(varchar(10),D2.BirthDate,103) as BirthDate, D2.BirthPlace" & UnicodeJoin(gbUnicode) & " as BirthPlace, D2.Address" & UnicodeJoin(gbUnicode) & " as Address," & vbCrLf
        sSQL &= "D2.Occupation" & UnicodeJoin(gbUnicode) & " as Occupation, D2.EducationLevelID, " & vbCrLf
        sSQL &= "D2.InComeTaxCode,	D2.IDCardNo, " & vbCrLf
        sSQL &= "D1.EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName,	D2.Sex, " & vbCrLf
        sSQL &= "(Case when D2.Sex = '0' then 'Nam' else " & IIf(gbUnicode, "N'Nữ'", "'Nöõ'").ToString & " end) as SexName" & vbCrLf
        sSQL &= "FROM D09T0216 D2 WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN D09T0206 D1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "ON D2.EducationLevelID = D1.EducationLevelID" & vbCrLf
        '  sSQL &= "WHERE D2.EmployeeID = " & SQLString(_employeeID)

        dtRelativeName = ReturnDataTable(sSQL)
        'Load tdbdEducationLevelID
        sSQL = "Select EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName" & vbCrLf
        sSQL &= "From D09T0206 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order By EducationLevelID"
        LoadDataSource(tdbdEducationLevelID, sSQL, gbUnicode)

        'Load tdbdSex
        sSQL = "Select 0 As Sex, 'Nam' As SexName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 1 As Sex, " & IIf(gbUnicode, "N'Nữ'", "'Nöõ'").ToString & " As SexName"
        LoadDataSource(tdbdSex, sSQL, gbUnicode)

        sSQL = "Select ObjectID BankID, ObjectName" & UnicodeJoin(gbUnicode) & " BankName, BranchName" & UnicodeJoin(gbUnicode) & " as BranchName From Object  WITH (NOLOCK) Where Disabled=0 And ObjectTypeID='NH' Order by ObjectID "
        LoadDataSource(tdbdBankID, sSQL, gbUnicode)

        'Load tdbdCountryTypeID
        sSQL = "--Do nguon cho DD quoc gia" & vbCrLf
        sSQL &= "	SELECT 	ID AS CountryTypeID, " & vbCrLf
        sSQL &= "Name" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString & UnicodeJoin(gbUnicode) & " AS CountryTypeName" & vbCrLf
        sSQL &= "	FROM	D13N5555 ('D13F2012', '', '', '', '')" & vbCrLf
        LoadDataSource(tdbdCountryTypeID, sSQL, gbUnicode)

        tdbgRelative.Columns(COL1_CountryTypeID).DefaultValue = tdbdCountryTypeID.Columns("CountryTypeID").Text
    End Sub

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID).ToString, gsDivisionID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, ReturnValueC1Combo(tdbcTeamID).ToString, gbUnicode)
        tdbcEmpGroupID.SelectedIndex = 0
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcEmpGroupID.Close, tdbcProjectID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcBlockID.Validated, tdbcEmpGroupID.Validated, tdbcProjectID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus, tdbcEmpGroupID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub


#Region "Events tdbcProjectID"

    Private Sub tdbcProjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.LostFocus
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then tdbcProjectID.Text = ""
    End Sub

#End Region

    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        CheckPermissionColGrid()
        LoadTDBGridRelative()
        LoadTDBGridBankID()
    End Sub

    Private iHeight As Integer = 0
    Private Sub tdbg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_FullSalCycle, COL_IsSub, COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar) 'Not ChrW(Keys.Space).Equals(e.KeyChar)
            Case COL_DutyRef01 To COL_DutyRef05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_StandardAbsentQuan
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE01, COL_BASE02, COL_BASE03, COL_BASE04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE01, COL_CE02, COL_CE03, COL_CE04, COL_CE05, COL_CE06, COL_CE07, COL_CE08, COL_CE09, COL_CE10, COL_CE11, COL_CE12, COL_CE13, COL_CE14, COL_CE15, COL_CE16, COL_CE17, COL_CE18, COL_CE19, COL_CE20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_INC01 To COL_INC11
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient To COL_SaCoefficient15, COL_SaCoefficient2 To COL_SaCoefficient25
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Age
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Birthdate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
            Case COL_NextBaseSalary01 To COL_NextBaseSalary04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextSalCoefficient01 To COL_NextSalCoefficient20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalaryRate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NumRef01 To COL_NumRef10
        End Select
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtFind Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter, sFilterServer) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

#Region "tdbgRelative event"

    Dim dtRelativeName As DataTable

    Private Sub LoadtdbdRelativeName(ByVal ID As String)
        LoadDataSource(tdbdRelativeName, ReturnTableFilter(dtRelativeName, " EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text) & " AND RelationID = " & SQLString(ID)), gbUnicode)
    End Sub

    Dim iColumnsRelative() As Integer = {COL1_DeductibleAmount}
    Dim bNotInListRelative As Boolean = False
    Dim bChangeTDBGRelative As Boolean = False
    Private Function CheckBirthDateValid() As Boolean
        If tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then
            If tdbgRelative.Columns(COL1_MBirthDate).Text <> "" Then
                Return True
            Else
                If tdbgRelative.Columns(COL1_DBirthDate).Text = "" Then
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
        Return False
    End Function

    Private Sub CheckStoteValid()
        If CheckBirthDateValid() And tdbgRelative.Columns(COL1_DeductibleDateBegin).Text <> "" Then
            Dim sDate As String = ReturnBirthDate(L3Byte(tdbgRelative.Columns("UndefinedBirthDate").Text), tdbgRelative.Columns("DBirthDate").Value.ToString(), tdbgRelative.Columns("MBirthDate").Value.ToString(), tdbgRelative.Columns("YBirthDate").Value.ToString())
            Dim sSQL As String = SQLStoreD13P5555(sDate, tdbgRelative.Columns(COL1_RelationID).Text, tdbgRelative.Columns(COL1_DeductibleDateBegin).Text)
            If CheckStore(sSQL) = False Then
            End If
        End If
    End Sub
    Private Sub tdbgRelative_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.ButtonClick 'ID 86460 06/06/2016
        Select Case e.ColIndex
            Case COL1_IsCreateAddress 'Tạo ĐC
                If tdbgRelative.Row = tdbgRelative.Bookmark Then CreateAddress()
        End Select
    End Sub
    Private Sub CreateAddress(Optional i As Integer = -1)
        Dim sAddress As String = ""
        If i = -1 Then
            sAddress &= IIf(tdbgRelative.Columns(COL1_ConAddressStreet).Text = "", "", tdbgRelative.Columns(COL1_ConAddressStreet).Text & ", ").ToString
            If tdbgRelative.Columns(COL1_ConAddressWardName).Text <> "" Then
                sAddress &= tdbgRelative.Columns(COL1_ConAddressWardName).Text
                If sAddress <> "" Then sAddress &= ", "
            End If
            If tdbgRelative.Columns(COL1_ConAddressDistrictName).Text <> "" Then
                sAddress &= tdbgRelative.Columns(COL1_ConAddressDistrictName).Text
                If sAddress <> "" Then sAddress &= ", "
            End If
            If tdbgRelative.Columns(COL1_ConAddressProvinceName).Text <> "" Then
                sAddress &= tdbgRelative.Columns(COL1_ConAddressProvinceName).Text
                If sAddress <> "" Then sAddress &= ", "
            End If
            sAddress = L3Left(sAddress, sAddress.Length - 2)
            tdbgRelative.Columns(COL1_Address).Text = sAddress
        Else 'HeadClick
            sAddress &= IIf(tdbgRelative(i, COL1_ConAddressStreet).ToString = "", "", tdbgRelative(i, COL1_ConAddressStreet).ToString & ", ").ToString
            If tdbgRelative(i, COL1_ConAddressWardName).ToString <> "" Then
                sAddress &= tdbgRelative(i, COL1_ConAddressWardName).ToString
                If sAddress <> "" Then sAddress &= ", "
            End If
            If tdbgRelative(i, COL1_ConAddressDistrictName).ToString <> "" Then
                sAddress &= tdbgRelative(i, COL1_ConAddressDistrictName).ToString
                If sAddress <> "" Then sAddress &= ", "
            End If
            If tdbgRelative(i, COL1_ConAddressProvinceName).ToString <> "" Then
                sAddress &= tdbgRelative(i, COL1_ConAddressProvinceName).ToString
                If sAddress <> "" Then sAddress &= ", "
            End If
            sAddress = L3Left(sAddress, sAddress.Length - 2)
            tdbgRelative(i, COL1_Address) = sAddress
        End If
    End Sub
    Private Sub tdbgRelative_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.AfterColUpdate
        bChangeTDBGRelative = True
        tdbgRelative.Columns(COL1_IsUpdate).Text = "1"
        Select Case e.ColIndex
          
            Case COL1_ConAddressProvinceName
                If tdbgRelative.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgRelative.Columns(COL1_ConAddressProvinceID).Text = ""

                    tdbgRelative.Columns(COL1_ConAddressDistrictID).Value = ""
                    tdbgRelative.Columns(COL1_ConAddressDistrictName).Value = ""
                    tdbgRelative.Columns(COL1_ConAddressWardID).Value = ""
                    tdbgRelative.Columns(COL1_ConAddressWardName).Value = ""
                    Exit Select
                End If
                tdbgRelative.Columns(COL1_ConAddressProvinceID).Text = tdbdConAddressProvinceID.Columns("Code").Text

                tdbgRelative.Columns(COL1_ConAddressDistrictID).Value = ""
                tdbgRelative.Columns(COL1_ConAddressDistrictName).Value = ""
                tdbgRelative.Columns(COL1_ConAddressWardID).Value = ""
                tdbgRelative.Columns(COL1_ConAddressWardName).Value = ""

            Case COL1_ConAddressDistrictName
                If tdbgRelative.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgRelative.Columns(COL1_ConAddressDistrictID).Text = ""
                    tdbgRelative.Columns(COL1_ConAddressWardID).Value = ""
                    tdbgRelative.Columns(COL1_ConAddressWardName).Value = ""
                    Exit Select
                End If
                tdbgRelative.Columns(COL1_ConAddressDistrictID).Text = tdbdConAddressDistrictID.Columns("Code").Text
                tdbgRelative.Columns(COL1_ConAddressWardID).Value = ""
                tdbgRelative.Columns(COL1_ConAddressWardName).Value = ""

            Case COL1_ConAddressWardName
                If tdbgRelative.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgRelative.Columns(COL1_ConAddressWardID).Text = ""

                    Exit Select
                End If
                tdbgRelative.Columns(COL1_ConAddressWardID).Text = tdbdConAddressWardID.Columns("Code").Text
            Case COL1_RelationName
                If bNotInListRelative Then
                    bNotInListRelative = False
                    tdbgRelative.Columns(COL1_RelationID).Text = ""
                    tdbgRelative.Columns(COL1_RelationName).Text = ""
                Else
                    tdbgRelative.Columns(COL1_RelationID).Text = tdbdRelationID.Columns("RelationID").Text
                End If
                CheckStoteValid()
            Case COL1_DBirthDate, COL1_MBirthDate, COL1_YBirthDate, COL1_DeductibleDateBegin
                tdbgRelative.Select()
                If e.ColIndex <> COL1_DeductibleDateBegin Then
                    If e.ColIndex = COL1_DBirthDate Then SetDateValue(0)
                    If e.ColIndex = COL1_MBirthDate Then SetDateValue(1)
                    If e.ColIndex = COL1_YBirthDate Then SetDateValue(2)
                End If
                CheckStoteValid()
            Case COL1_CountryTypeID
                If tdbgRelative.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgRelative.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL1_NumBirthCertificate, COL1_BookBirthCertificate
                If tdbgRelative.Columns(e.ColIndex).Text <> "" Then
                    tdbgRelative.Columns(COL1_BirthCertificate).Value = 1
                End If
            Case COL1_BirthCertificate
                If L3Bool(tdbgRelative.Columns(e.ColIndex).Text) = False Then
                    tdbgRelative.Columns(COL1_NumBirthCertificate).Value = ""
                    tdbgRelative.Columns(COL1_BookBirthCertificate).Value = ""
                End If
           
        End Select
        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumnsRelative)
    End Sub

    Private Sub tdbgRelative_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbgRelative.BeforeColEdit
        If e.ColIndex = COL1_DBirthDate Then 'Phải gán mặc định tháng 12 để có thể nhập được ngày 31 tại cột Ngày sinh
            If tdbgRelative.Columns(e.ColIndex).Text = "" Then c1dateDBirthDate.Value = CDate("31/12/2014")
        End If
    End Sub

    Private Sub SetDateValue(ByVal iMode As Byte)
        Dim sDate As String
        Dim iDay, iMonth, iYear As Integer
        If iMode = 0 Then 'Ngày   
            Dim sDay As String = "0"
            iDay = L3Int(tdbgRelative.Columns(COL1_DBirthDate).Text)
            If iDay = 0 Then sDay = ""
            iMonth = L3Int(IIf(tdbgRelative.Columns(COL1_MBirthDate).Text <> "", tdbgRelative.Columns(COL1_MBirthDate).Text, 12).ToString)
            iYear = L3Int(IIf(tdbgRelative.Columns(COL1_YBirthDate).Text <> "", tdbgRelative.Columns(COL1_YBirthDate).Text, Now.Year).ToString)
            sDate = tdbgRelative.Columns(COL1_DBirthDate).Text & "/" & iMonth & "/" & iYear

            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            tdbgRelative.Columns(COL1_DBirthDate).Value = dDate ' CDate(sDate)
            If sDay = "" Then tdbgRelative.Columns(COL1_DBirthDate).Text = ""
            '***************
            If tdbgRelative.Columns(COL1_MBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_MBirthDate).Value = tdbgRelative.Columns(COL1_DBirthDate).Value
            If tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_YBirthDate).Value = tdbgRelative.Columns(COL1_DBirthDate).Value
        ElseIf iMode = 1 Then 'Tháng
            iDay = L3Int(IIf(tdbgRelative.Columns(COL1_DBirthDate).Text <> "", tdbgRelative.Columns(COL1_DBirthDate).Text, Now.Day).ToString)
            iYear = L3Int(IIf(tdbgRelative.Columns(COL1_YBirthDate).Text <> "", tdbgRelative.Columns(COL1_YBirthDate).Text, Now.Year).ToString)
            Dim sMonth As String = "0"
            iMonth = L3Int(tdbgRelative.Columns(COL1_MBirthDate).Text)
            If iMonth = 0 Then
                sMonth = ""
                iMonth = 12
            End If

            sDate = iDay & "/" & iMonth & "/" & iYear

            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            tdbgRelative.Columns(COL1_MBirthDate).Value = dDate 'CDate(sDate)
            If sMonth = "" Then tdbgRelative.Columns(COL1_MBirthDate).Text = ""
            '***************
            If tdbgRelative.Columns(COL1_DBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_DBirthDate).Value = tdbgRelative.Columns(COL1_MBirthDate).Value
            If tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_YBirthDate).Value = tdbgRelative.Columns(COL1_MBirthDate).Value
        Else 'Năm
            iDay = L3Int(IIf(tdbgRelative.Columns(COL1_DBirthDate).Text <> "", tdbgRelative.Columns(COL1_DBirthDate).Text, Now.Day).ToString)
            iMonth = L3Int(IIf(tdbgRelative.Columns(COL1_MBirthDate).Text <> "", tdbgRelative.Columns(COL1_MBirthDate).Text, 12).ToString)
            Dim sYear As String = "0"

            iYear = L3Int(tdbgRelative.Columns(COL1_YBirthDate).Text)
            If iYear = 0 Then
                sYear = ""
            End If

            sDate = iDay & "/" & iMonth & "/" & iYear

            If IsDate(sDate) = False Then iDay = Date.DaysInMonth(iYear, iMonth)
            Dim dDate As New Date(iYear, iMonth, iDay)
            tdbgRelative.Columns(COL1_YBirthDate).Value = dDate 'CDate(sDate)
            If sYear = "" Then tdbgRelative.Columns(COL1_YBirthDate).Text = ""
            '***************
            If tdbgRelative.Columns(COL1_DBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_DBirthDate).Value = tdbgRelative.Columns(COL1_YBirthDate).Value
            If tdbgRelative.Columns(COL1_MBirthDate).Text <> "" Then tdbgRelative.Columns(COL1_MBirthDate).Value = tdbgRelative.Columns(COL1_YBirthDate).Value
        End If
        '******************************
        Dim iUndefinedBirthDate As Byte = 2
        If tdbgRelative.Columns(COL1_DBirthDate).Text <> "" AndAlso tdbgRelative.Columns(COL1_MBirthDate).Text <> "" AndAlso tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then 'Nhap day du ngay ,thang ,nam
            iUndefinedBirthDate = 0
        ElseIf tdbgRelative.Columns(COL1_MBirthDate).Text <> "" AndAlso tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then 'Chi nhap thang,nam
            iUndefinedBirthDate = 1
        ElseIf tdbgRelative.Columns(COL1_YBirthDate).Text <> "" Then 'Chi nhap nam
            iUndefinedBirthDate = 2
        End If

        tdbgRelative.Columns(COL1_UndefinedBirthDate).Value = iUndefinedBirthDate
    End Sub

    Private Sub tdbgRelative_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgRelative.AfterDelete
        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumnsRelative)
    End Sub

    Private Sub tdbgRelative_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgRelative.RowColChange
        Select Case tdbgRelative.Col
            Case COL1_RelativeName
                LoadtdbdRelativeName(tdbgRelative.Columns(COL1_RelationID).Text)
            Case COL1_ConAddressDistrictName
                LoadDrodownAddress(tdbdConAddressDistrictID, L3String(tdbgRelative(tdbgRelative.Row, COL1_ConAddressProvinceID)))
            Case COL1_ConAddressWardName
                LoadDrodownAddress(tdbdConAddressWardID, L3String(tdbgRelative(tdbgRelative.Row, COL1_ConAddressDistrictID)))
        End Select
    End Sub

    Private Sub tdbgRelative_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgRelative.BeforeColUpdate
        Select Case e.ColIndex
            Case COL1_RelationName
                If tdbgRelative.Columns(COL1_RelationName).Text <> tdbdRelationID.Columns("RelationName").Text Then
                    bNotInListRelative = True
                    tdbgRelative.Columns(COL1_RelationID).Text = ""
                    tdbgRelative.Columns(COL1_RelationName).Text = ""
                End If
            Case COL1_EducationLevelName
                If tdbgRelative.Columns(COL1_EducationLevelName).Text <> tdbdEducationLevelID.Columns("EducationLevelName").Text Then
                    tdbgRelative.Columns(COL1_EducationLevelName).Text = ""
                    tdbgRelative.Columns(COL1_EducationLevelID).Text = ""
                End If
            Case COL1_SexName
                If tdbgRelative.Columns(COL1_SexName).Text <> tdbdSex.Columns("SexName").Text Then
                    tdbgRelative.Columns(COL1_SexName).Text = ""
                    tdbgRelative.Columns(COL1_Sex).Text = ""
                End If
            Case COL1_DeductibleAmount
                If Not IsNumeric(tdbgRelative.Columns(COL1_DeductibleAmount).Text) Then tdbgRelative.Columns(COL1_DeductibleAmount).Text = "0"
                '            Case COL1_DeductibleDateBegin, COL1_DeductibleDateEnd
                '                tdbgRelative.Columns(e.ColIndex).Text = L3DateValue(tdbgRelative.Columns(e.ColIndex).Text)
            Case COL1_YBirthDate
                If tdbgRelative.Columns(COL1_YBirthDate).Text = "" Then
                    e.Cancel = True
                    D99C0008.MsgNotYetEnter(tdbgRelative.Columns(COL1_YBirthDate).Caption)
                End If
            Case COL1_InComeTaxCode, COL1_IDCardNo
                e.Cancel = L3IsID(tdbgRelative, e.ColIndex)
            Case COL1_CountryTypeID
                If tdbgRelative.Columns(e.ColIndex).Text <> tdbgRelative.Columns(e.ColIndex).DropDown.Columns(tdbgRelative.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgRelative.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL1_ConAddressDistrictName, COL1_ConAddressWardName, COL1_ConAddressProvinceName
                If tdbgRelative.Columns(e.ColIndex).Text <> tdbgRelative.Columns(e.ColIndex).DropDown.Columns(tdbgRelative.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgRelative.Columns(e.ColIndex).Text = ""
                End If
                'Case COL1_ConAddressProvinceID
                '    If tdbgRelative.Columns(e.ColIndex).Text <> tdbgRelative.Columns(e.ColIndex).DropDown.Columns(tdbgRelative.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                '        tdbgRelative.Columns(e.ColIndex).Text = ""
                '        bNotInList = True
                '    End If
        End Select
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbgRelative_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.ComboSelect
        Select Case e.ColIndex
            Case COL1_RelationName
                'tdbgRelative.Columns(COL1_RelationName).Text = tdbdRelationID.Columns("RelationName").Text
                tdbgRelative.Columns(COL1_RelationID).Text = tdbdRelationID.Columns("RelationID").Text

                LoadtdbdRelativeName(tdbgRelative.Columns(COL1_RelationID).Text)

                If tdbdRelativeName.Columns("RelativeName").Text <> "" Then
                    tdbgRelative.Columns(COL1_RelativeName).Text = tdbdRelativeName.Columns("RelativeName").Text
                End If
                'ANHVU
                'If tdbdRelativeName.Columns("BirthDate").Text <> "" Then
                '    tdbgRelative.Columns(COL1_BirthDate).Text = tdbdRelativeName.Columns("BirthDate").Text
                'End If
                If tdbdRelativeName.Columns("BirthPlace").Text <> "" Then
                    tdbgRelative.Columns(COL1_BirthPlace).Text = tdbdRelativeName.Columns("BirthPlace").Text
                End If
                If tdbdRelativeName.Columns("Address").Text <> "" Then
                    tdbgRelative.Columns(COL1_Address).Text = tdbdRelativeName.Columns("Address").Text
                End If
                If tdbdRelativeName.Columns("Occupation").Text <> "" Then
                    tdbgRelative.Columns(COL1_Occupation).Text = tdbdRelativeName.Columns("Occupation").Text
                End If
                If tdbdRelativeName.Columns("EducationLevelID").Text <> "" Then
                    tdbgRelative.Columns(COL1_EducationLevelID).Text = tdbdRelativeName.Columns("EducationLevelID").Text
                End If
                If tdbdRelativeName.Columns("EducationLevelName").Text <> "" Then
                    tdbgRelative.Columns(COL1_EducationLevelName).Text = tdbdRelativeName.Columns("EducationLevelName").Text
                End If
                If tdbdRelativeName.Columns("Sex").Text = "" Then
                    tdbgRelative.Columns(COL1_Sex).Text = ""
                Else
                    tdbgRelative.Columns(COL1_Sex).Text = IIf(CBool(tdbdRelativeName.Columns("Sex").Value), 1, 0).ToString
                End If
                If tdbdRelativeName.Columns("SexName").Text <> "" Then
                    tdbgRelative.Columns(COL1_SexName).Text = tdbdRelativeName.Columns("SexName").Text
                End If
                If tdbdRelativeName.Columns("InComeTaxCode").Text <> "" Then
                    tdbgRelative.Columns(COL1_InComeTaxCode).Text = tdbdRelativeName.Columns("InComeTaxCode").Text
                End If
                If tdbdRelativeName.Columns("IDCardNo").Text <> "" Then
                    tdbgRelative.Columns(COL1_IDCardNo).Text = tdbdRelativeName.Columns("IDCardNo").Text
                End If
            Case COL1_RelativeName
                tdbgRelative.Columns(COL1_RelativeName).Text = tdbdRelativeName.Columns("RelativeName").Text
                'ANHVU
                'tdbgRelative.Columns(COL1_BirthDate).Text = tdbdRelativeName.Columns("BirthDate").Text
                tdbgRelative.Columns(COL1_BirthPlace).Text = tdbdRelativeName.Columns("BirthPlace").Text
                tdbgRelative.Columns(COL1_Address).Text = tdbdRelativeName.Columns("Address").Text
                tdbgRelative.Columns(COL1_Occupation).Text = tdbdRelativeName.Columns("Occupation").Text
                tdbgRelative.Columns(COL1_EducationLevelID).Text = tdbdRelativeName.Columns("EducationLevelID").Text
                tdbgRelative.Columns(COL1_EducationLevelName).Text = tdbdRelativeName.Columns("EducationLevelName").Text
                If tdbdRelativeName.Columns("Sex").Text = "" Then
                    tdbgRelative.Columns(COL1_Sex).Text = ""
                Else
                    tdbgRelative.Columns(COL1_Sex).Text = IIf(CBool(tdbdRelativeName.Columns("Sex").Value), 1, 0).ToString
                End If
                tdbgRelative.Columns(COL1_SexName).Text = tdbdRelativeName.Columns("SexName").Text
                tdbgRelative.Columns(COL1_InComeTaxCode).Text = tdbdRelativeName.Columns("InComeTaxCode").Text
                tdbgRelative.Columns(COL1_IDCardNo).Text = tdbdRelativeName.Columns("IDCardNo").Text
            Case COL1_EducationLevelName
                tdbgRelative.Columns(COL1_EducationLevelName).Text = tdbdEducationLevelID.Columns("EducationLevelName").Text
                tdbgRelative.Columns(COL1_EducationLevelID).Text = tdbdEducationLevelID.Columns("EducationLevelID").Text
            Case COL1_SexName
                tdbgRelative.Columns(COL1_Sex).Text = tdbdSex.Columns("Sex").Text
                tdbgRelative.Columns(COL1_SexName).Text = tdbdSex.Columns("SexName").Text
        End Select
    End Sub

    Private Sub tdbgRelative_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgRelative.KeyDown
        Try
            If e.KeyCode = Keys.Enter And tdbgRelative.Col = COL1_Note Then
                HotKeyEnterGrid(tdbgRelative, 0, e)
            ElseIf e.KeyCode = Keys.F8 Then
                HotKeyF8(tdbgRelative)
                FooterTotalGrid(tdbgRelative, COL1_RelativeName)
                FooterSum(tdbgRelative, iColumnsRelative)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                HotKeyF7(tdbgRelative)
                Select Case tdbgRelative.Col
                    Case COL1_RelationName, COL1_EducationLevelName, COL1_SexName
                        If tdbgRelative.RowCount < 1 Then Exit Sub
                        tdbgRelative.Columns(tdbgRelative.Col + 1).Text = tdbgRelative(tdbgRelative.Row - 1, tdbgRelative.Col + 1).ToString()
                        tdbgRelative.UpdateData()
                End Select
                FooterTotalGrid(tdbgRelative, COL1_RelativeName)
                FooterSum(tdbgRelative, iColumnsRelative)
                Exit Sub
            ElseIf e.Control And e.KeyCode = Keys.S Then
                HeadClick(tdbgRelative.Col)
            End If

        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub tdbgRelative_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgRelative.KeyPress
        Select Case tdbgRelative.Col
            Case COL1_InComeTaxCode, COL1_IDCardNo
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
            Case COL1_DBirthDate, COL1_MBirthDate, COL1_YBirthDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbgRelative_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbgRelative.BeforeDelete
        'If tdbgRelative.Columns(COL1_IsNewRow).Text = "1" Then Exit Sub ' Đối với dòng mới thêm vào
        'If Not btnSave.Visible Or Not btnSave.Enabled Then e.Cancel = True : Exit Sub
        'If D99C0008.MsgAskDeleteRow = Windows.Forms.DialogResult.No Then e.Cancel = True : Exit Sub
        'If Not ExecuteSQL(SQLDeleteD13T0216(tdbgRelative.Columns(COL1_EmployeeID).Text, L3String(tdbgRelative.Columns(COL1_RelativeID).Value))) Then
        '    DeleteNotOK()
        'End If
    End Sub

#End Region

#Region "tdbgbankID event"

    Dim bNotInListBankID As Boolean = False
    Private Sub tdbgBankID_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgBankID.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLB_BankID
                If tdbgBankID.Columns(e.ColIndex).Text <> tdbgBankID.Columns(e.ColIndex).DropDown.Columns(tdbgBankID.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgBankID.Columns(e.ColIndex).Text = ""
                    bNotInListBankID = True
                End If
            Case COLB_BankAccountNo
                'e.Cancel = L3IsID(tdbgBankID, e.ColIndex) ' Bỏ chặn nhập mã theo ID 79971 07/10/2015
        End Select
    End Sub
    Private Sub UpdateColumn_IsUpdateTo1_ForGridBank()
        If tdbgBankID.RowCount = 0 Then Exit Sub
        tdbgBankID.UpdateData()
        For i As Integer = 0 To tdbgBankID.RowCount - 1
            tdbgBankID(i, COLB_IsUpdate) = 1
        Next
    End Sub

    Dim bChangeTDBGBankID As Boolean = False
    Private Sub tdbgBankID_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgBankID.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        'tdbgBankID.Columns(COLB_IsUpdate).Text = "1"
        UpdateColumn_IsUpdateTo1_ForGridBank() ' ID bổ sung ngày 03/09/2015 : Update hết =1 cho nhân viên đó. 79212 
        bChangeTDBGBankID = True
        Select Case e.ColIndex
            Case COLB_BankID
                Application.DoEvents() 'Sửa lỗi hiển thị Mã khi di chuyển qua dòng khác
                If tdbgBankID.Columns(e.ColIndex).Text = "" OrElse bNotInListBankID Then
                    tdbgBankID.Columns(e.ColIndex).Text = ""
                    bNotInListBankID = False
                    'Gắn rỗng các cột liên quan
                    tdbgBankID.Columns(COLB_BranchName).Text = ""
                    Exit Select
                End If
                '    tdbgBankID.Columns(COLB_BankName).Text = tdbdBankID.Columns("BankName").Text
                tdbgBankID.Columns(COLB_BranchName).Text = tdbdBankID.Columns("BranchName").Text
        End Select
        bNotInListBankID = False
    End Sub

    Private Sub tdbgBankID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgBankID.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbgBankID.Col
            Case COLB_IsDefault
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COLB_BankAccountNo
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Private Sub tdbgBankID_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbgBankID.BeforeDelete
        If tdbgBankID.Columns(COLB_IsNewRow).Text = "1" Then Exit Sub ' Đối với dòng mới thêm vào

        If Not btnSave.Visible Or Not btnSave.Enabled Then e.Cancel = True : Exit Sub
        If D99C0008.MsgAskDeleteRow = Windows.Forms.DialogResult.No Then e.Cancel = True : Exit Sub

        If Not ExecuteSQL(SQLDeleteD13T0202(tdbgBankID.Columns(COLB_EmployeeID).Text, L3String(tdbgBankID.Columns(COLB_BankID).Value))) Then
            DeleteNotOK()
        End If

    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2012
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 24/08/2011 08:15:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2012() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2012 "
        ' update 19/11/2013 - id 61328 -- Truyền biến toàn cục @PayrollVoucherID khi load Form D13F0000
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        '        Select Case _path
        '            Case "01"
        '                sSQL &= SQLString(tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        '            Case Else
        '                sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        '        End Select
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'AllDepartmentID, varchar[1000], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, nvarchar, NOT NULL 'sFindServer
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        ' 28/5/2014 id 65377 - Theo chi Thuận truyền cố định là D13F2012 (do chị còn 1 đường dẫn gọi _path='04')
        sSQL &= SQLString("D13F2010") & COMMA '     sSQL &= SQLString(sFormPermisson) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmpGroupID)) & COMMA 'EmpGroupID, varchar[20], NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtStrEmployeeName.Text, gbUnicode, gbUnicode) & COMMA 'StrEmployeeName, nvarchar[100], NOT NULL
        sSQL &= SQLNumber(chkIsBelongCicle.Checked) & COMMA 'IsBelongPayrollFile, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsNotBelongCicle.Checked) & COMMA 'IsNotBelongPayrollFile, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProjectID)) 'ProjectID, varchar[20], NOT NULL
        Return sSQL
    End Function


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter, sFilterServer)
            sFind = ""
            sFindServer = "" ' Nếu có sử dụng Lọc để In
        End If

        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2012()
        dtFind = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtFind.Rows.Count > 0

        LoadDataSource(tdbg, dtFind, gbUnicode)
        If bFlag Then
            dtFind.DefaultView.Sort = "DepartmentID"
            dtFind.DefaultView.Sort = "TeamID"
            dtFind.DefaultView.Sort = "EmployeeID"
            tdbg.Bookmark = dtFind.DefaultView.Find(sEmployeeID)
        End If
        dtGridRelative = Nothing
        sValueGridRelative = ""
        dtGridBankID = Nothing
        sValueGridBankID = ""
        ReLoadTDBGrid()
        btnSave.Enabled = True
        ResetGrid()
    End Sub

    Dim iPerD13F1030 As Integer = 0
    Dim iPerD13F5613 As Integer = 0

    Private Sub ResetGrid()
        CheckMenu(sFormPermisson, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        CheckMenuOther()

        mnuImportBankInfo.Enabled = mnuAdd.Enabled And iPerD13F1030 >= 2
        mnuImportData.Enabled = mnuImportBankInfo.Enabled
        mnuImportImfoRef.Enabled = mnuAdd.Enabled And iPerD13F5613 >= 2 '16/06/2015 ID75783 Bổ sung menu Thông tin tham chiếu

        'ID 95538 04.04.2017
        'btnUpdateReduce.Enabled = ReturnPermission("D13F2010") >= 2 And ReturnPermission("D09F1500") >= 2 And tdbg.RowCount > 0 And Not gbClosed
        btnUpdateReduce.Enabled = ReturnPermission("D13F2010") >= 2 And tdbg.RowCount > 0 And Not gbClosed
        tdbg_FooterText()
        tdbg_NumberFormat()
    End Sub

    Dim sValueGridRelative As String = ""
    Private Sub LoadTDBGridRelative()
        If sValueGridRelative = tdbg.Columns(COL_EmployeeID).Text Then Exit Sub
        sValueGridRelative = tdbg.Columns(COL_EmployeeID).Text

        tdbgRelative.Columns(COL1_ExamineDate).DefaultValue = Date.Now.ToShortDateString ' update 9/9/2013 id 56751
        tdbgRelative.Columns(COL1_EmployeeID).DefaultValue = tdbg.Columns(COL_EmployeeID).Text

        Dim sSQL As String = ""
        If dtGridRelative Is Nothing Then
            sSQL = SQLStoreD13P1502()
            dtGridRelative = ReturnDataTable(sSQL)
        Else
            If dtGridRelative.Select("EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text)).Length <= 0 Then
                Dim dt As DataTable
                sSQL = SQLStoreD13P1502()
                dt = ReturnDataTable(sSQL)
                dtGridRelative.Merge(dt)
            End If
        End If
        If Not dtGridRelative.Columns.Contains("IsNewRow") Then
            dtGridRelative.Columns.Add("IsNewRow")
        End If
        dtGridRelative.DefaultView.RowFilter = "EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text)
        LoadDataSource(tdbgRelative, dtGridRelative, gbUnicode)

        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumnsRelative)
    End Sub

    Dim sValueGridBankID As String = ""
    Private Sub LoadTDBGridBankID()
        If sValueGridBankID = tdbg.Columns(COL_EmployeeID).Text Then Exit Sub
        sValueGridRelative = tdbg.Columns(COL_EmployeeID).Text

        tdbgBankID.Columns(COLB_AccountHolderName).DefaultValue = tdbg.Columns(COL_FullName).Text
        tdbgBankID.Columns(COLB_EmployeeID).DefaultValue = tdbg.Columns(COL_EmployeeID).Text

        Dim sSQL As String = ""
        sSQL &= "SELECT	T1.BankID, T1.BankAccountNo" & UnicodeJoin(gbUnicode) & " AS BankAccountNo, "
        sSQL &= "T1.AccountHolderName" & UnicodeJoin(gbUnicode) & " AS AccountHolderName, "
        sSQL &= "T1.ExchangeDep" & UnicodeJoin(gbUnicode) & " AS ExchangeDep, "
        sSQL &= "CONVERT(BIT, T1.IsDefault) as IsDefault,"
        sSQL &= "T2.BranchName" & UnicodeJoin(gbUnicode) & " AS BranchName,"
        sSQL &= "T2.ObjectName" & UnicodeJoin(gbUnicode) & " AS BankName,"
        sSQL &= "T1.EmployeeID, 0 AS IsUpdate, 0 as IsNewRow " & vbCrLf
        sSQL &= "FROM	D13T0202 T1  WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN	OBJECT T2  WITH (NOLOCK) " & vbCrLf
        sSQL &= "ON		T1.BankID = T2.ObjectID AND ObjectTypeID = 'NH'" & vbCrLf
        sSQL &= "WHERE	T1.EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text)

        If dtGridBankID Is Nothing Then
            dtGridBankID = ReturnDataTable(sSQL)
        Else
            If dtGridBankID.Select("EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text)).Length <= 0 Then
                Dim dt As DataTable
                dt = ReturnDataTable(sSQL)
                dtGridBankID.Merge(dt)
            End If
        End If
        dtGridBankID.DefaultView.RowFilter = "EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text)
        LoadDataSource(tdbgBankID, dtGridBankID, gbUnicode)
    End Sub

    '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
    Private Sub SetPaymentMethod()
        If tdbg.Columns(COL_PaymentMethod).Text = "C" Then
            optPaymentMethod_C.Checked = True
        ElseIf tdbg.Columns(COL_PaymentMethod).Text = "B" Then
            optPaymentMethod_B.Checked = True
        ElseIf tdbg.Columns(COL_PaymentMethod).Text = "O" Then
            optPaymentMethod_O.Checked = True
        End If
    End Sub

    Private Sub CheckMenuOther()
        bAddEnabled = mnuAdd.Enabled
        bEditEnabled = mnuEdit.Enabled
        bDeleteEnabled = mnuDelete.Enabled
        CheckPermissionColGrid()
        mnuMultiEdit.Enabled = mnuEdit.Enabled
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "MonSalaryFileDetail")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_TransID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)

        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "MonSalaryFileDetail" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_TransID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    ' update 27/12/2012 id 52980
    Private Sub ButtonD09T0080()
        Dim sSQL As String = ""
        sSQL = "-- Do caption dong thong tin tham chieu" & vbCrLf
        sSQL &= "SELECT GroupMode, RefID, RefCaption" & UnicodeJoin(gbUnicode) & " AS RefCaption, Disabled" & vbCrLf
        sSQL &= "FROM D09T0080  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = '8000'" & vbCrLf
        sSQL &= "ORDER BY RefID"
        Dim dtRef As DataTable = ReturnDataTable(sSQL.ToString)
        bUseInfoOther = dtRef.Select("Disabled = 0").Length > 0

        Dim dtRefString As DataTable = ReturnTableFilter(dtRef, "GroupMode=0", True)
        If dtRefString.Rows.Count > 0 And dtRefString.Rows.Count >= 5 Then
            tdbg.Columns(COL_Ref01).Caption = dtRefString.Rows(0).Item("RefCaption").ToString
            bInfoOther.Ref01 = Not L3Bool(dtRefString.Rows(0).Item("Disabled"))
            tdbg.Columns(COL_Ref02).Caption = dtRefString.Rows(1).Item("RefCaption").ToString
            bInfoOther.Ref02 = Not L3Bool(dtRefString.Rows(1).Item("Disabled"))
            tdbg.Columns(COL_Ref03).Caption = dtRefString.Rows(2).Item("RefCaption").ToString
            bInfoOther.Ref03 = Not L3Bool(dtRefString.Rows(2).Item("Disabled"))
            tdbg.Columns(COL_Ref04).Caption = dtRefString.Rows(3).Item("RefCaption").ToString
            bInfoOther.Ref04 = Not L3Bool(dtRefString.Rows(3).Item("Disabled"))
            tdbg.Columns(COL_Ref05).Caption = dtRefString.Rows(4).Item("RefCaption").ToString
            bInfoOther.Ref05 = Not L3Bool(dtRefString.Rows(4).Item("Disabled"))
        End If

        Dim dtRefNum As DataTable = ReturnTableFilter(dtRef, "GroupMode=1", True)
        If dtRefNum.Rows.Count > 0 And dtRefNum.Rows.Count >= 10 Then
            tdbg.Columns(COL_NumRef01).Caption = dtRefNum.Rows(0).Item("RefCaption").ToString
            bInfoOther.NumRef01 = Not L3Bool(dtRefNum.Rows(0).Item("Disabled"))
            tdbg.Columns(COL_NumRef02).Caption = dtRefNum.Rows(1).Item("RefCaption").ToString
            bInfoOther.NumRef02 = Not L3Bool(dtRefNum.Rows(1).Item("Disabled"))
            tdbg.Columns(COL_NumRef03).Caption = dtRefNum.Rows(2).Item("RefCaption").ToString
            bInfoOther.NumRef03 = Not L3Bool(dtRefNum.Rows(2).Item("Disabled"))
            tdbg.Columns(COL_NumRef04).Caption = dtRefNum.Rows(3).Item("RefCaption").ToString
            bInfoOther.NumRef04 = Not L3Bool(dtRefNum.Rows(3).Item("Disabled"))
            tdbg.Columns(COL_NumRef05).Caption = dtRefNum.Rows(4).Item("RefCaption").ToString
            bInfoOther.NumRef05 = Not L3Bool(dtRefNum.Rows(4).Item("Disabled"))
            tdbg.Columns(COL_NumRef06).Caption = dtRefNum.Rows(5).Item("RefCaption").ToString
            bInfoOther.NumRef06 = Not L3Bool(dtRefNum.Rows(5).Item("Disabled"))
            tdbg.Columns(COL_NumRef07).Caption = dtRefNum.Rows(6).Item("RefCaption").ToString
            bInfoOther.NumRef07 = Not L3Bool(dtRefNum.Rows(6).Item("Disabled"))
            tdbg.Columns(COL_NumRef08).Caption = dtRefNum.Rows(7).Item("RefCaption").ToString
            bInfoOther.NumRef08 = Not L3Bool(dtRefNum.Rows(7).Item("Disabled"))
            tdbg.Columns(COL_NumRef09).Caption = dtRefNum.Rows(8).Item("RefCaption").ToString
            bInfoOther.NumRef09 = Not L3Bool(dtRefNum.Rows(8).Item("Disabled"))
            tdbg.Columns(COL_NumRef10).Caption = dtRefNum.Rows(9).Item("RefCaption").ToString
            bInfoOther.NumRef10 = Not L3Bool(dtRefNum.Rows(9).Item("Disabled"))
        End If

        '        For i As Integer = COL_Ref01 To COL_Ref05
        '            tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        '        Next


    End Sub

    Private Sub ButtonD13T9000()
        Dim sDateEnd As String = IIf(gbUnicode, rL3("Ngay_hieu_luc_U"), ConvertUnicodeToVni(rL3("Ngay_hieu_luc_U"))).ToString
        Dim sNextDate As String = IIf(gbUnicode, rL3("Ngay_xet_tiep_theo"), ConvertUnicodeToVni(rL3("Ngay_xet_tiep_theo"))).ToString
        Dim sNext As String = IIf(gbUnicode, rL3("Tiep_theo"), ConvertUnicodeToVni(rL3("Tiep_theo"))).ToString
        Dim sCurrency As String = IIf(gbUnicode, rL3("Nguyen_te"), ConvertUnicodeToVni(rL3("Nguyen_te"))).ToString

        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short, Disabled, Type From D13T9000  WITH(NOLOCK) Order By Code"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable

        ' update 22/2/2013 id 53895 - bổ sung 5 cột DutyRef01 -> DutyRef05 vào Thông tin chính
        dt1 = ReturnTableFilter(dt, "Type='D09T0211'", True)
        ' Dữ liệu đảm bào có 5 dòng
        For i As Integer = 0 To 4
            tdbg.Columns(i + COL_DutyRef01).Caption = dt1.Rows(i).Item("Short").ToString
            tdbg.Splits(SPLIT0).DisplayColumns(i + COL_DutyRef01).Visible = Not L3Bool(dt1.Rows(i).Item("Disabled"))
            tdbg.Splits(SPLIT0).DisplayColumns(i + COL_DutyRef01).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next

        dt1 = ReturnTableFilter(dt, "Type='SALBA'", True)
        For i As Integer = 0 To 3
            tdbg.Columns(COL_BASE01 + (i * 2)).Caption = dt1.Rows(i).Item("Short").ToString
            ' Nguyên tệ (Caption của BASExx)
            ' Tạm thời ẩn
            '   tdbg.Columns(COL_BaseCurrencyID01 + (i * 2)).Caption = sCurrency & vbCrLf & "(" & dt1.Rows(i).Item("Short").ToString & ")"
            tdbg.Columns(COL_BaseSalary01DateEnd + i).Caption = sDateEnd & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COL_BaseSalary01NextDate + i).Caption = sNextDate & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COL_NextBaseSalary01 + i).Caption = dt1.Rows(i).Item("Short").ToString & " " & sNext
        Next
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))

        dt1 = ReturnTableFilter(dt, "Type='SALCE'", True)
        bCE.CE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bCE.CE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bCE.CE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bCE.CE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bCE.CE05 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bCE.CE06 = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bCE.CE07 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))
        bCE.CE08 = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))
        bCE.CE09 = CBool(IIf(dt1.Rows(8).Item("Disabled").ToString = "0", True, False))
        bCE.CE10 = CBool(IIf(dt1.Rows(9).Item("Disabled").ToString = "0", True, False))
        'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
        bCE.CE11 = CBool(IIf(dt1.Rows(10).Item("Disabled").ToString = "0", True, False))
        bCE.CE12 = CBool(IIf(dt1.Rows(11).Item("Disabled").ToString = "0", True, False))
        bCE.CE13 = CBool(IIf(dt1.Rows(12).Item("Disabled").ToString = "0", True, False))
        bCE.CE14 = CBool(IIf(dt1.Rows(13).Item("Disabled").ToString = "0", True, False))
        bCE.CE15 = CBool(IIf(dt1.Rows(14).Item("Disabled").ToString = "0", True, False))
        bCE.CE16 = CBool(IIf(dt1.Rows(15).Item("Disabled").ToString = "0", True, False))
        bCE.CE17 = CBool(IIf(dt1.Rows(16).Item("Disabled").ToString = "0", True, False))
        bCE.CE18 = CBool(IIf(dt1.Rows(17).Item("Disabled").ToString = "0", True, False))
        bCE.CE19 = CBool(IIf(dt1.Rows(18).Item("Disabled").ToString = "0", True, False))
        bCE.CE20 = CBool(IIf(dt1.Rows(19).Item("Disabled").ToString = "0", True, False))

        For i As Integer = 0 To 19
            tdbg.Columns(COL_CE01 + (i * 2)).Caption = dt1.Rows(i).Item("Short").ToString
            ' Nguyên tệ (Caption của CExx)
            ' Tạm thời ẩn
            '            tdbg.Columns(COL_SalCoeCurrencyID01 + (i * 2)).Caption = sCurrency & vbCrLf & "(" & dt1.Rows(i).Item("Short").ToString & ")"
            tdbg.Columns(COL_Sal01DateEnd + i).Caption = sDateEnd & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COL_Sal01NextDate + i).Caption = sNextDate & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COL_NextSalCoefficient01 + i).Caption = dt1.Rows(i).Item("Short").ToString & " " & sNext
            tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next

        dt1 = ReturnTableFilter(dt, "Type='PRMAS'", True)
        bUsePRMAS = dt1.Select("Disabled = 0").Length > 0
        bPRMAS.INC01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC05 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC06 = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC07 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC08 = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC09 = CBool(IIf(dt1.Rows(8).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC10 = CBool(IIf(dt1.Rows(9).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC11 = CBool(IIf(dt1.Rows(10).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC12 = CBool(IIf(dt1.Rows(11).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC13 = CBool(IIf(dt1.Rows(12).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC14 = CBool(IIf(dt1.Rows(13).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC15 = CBool(IIf(dt1.Rows(14).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC16 = CBool(IIf(dt1.Rows(15).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC17 = CBool(IIf(dt1.Rows(16).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC18 = CBool(IIf(dt1.Rows(17).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC19 = CBool(IIf(dt1.Rows(18).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC20 = CBool(IIf(dt1.Rows(19).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC21 = CBool(IIf(dt1.Rows(20).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC22 = CBool(IIf(dt1.Rows(21).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC23 = CBool(IIf(dt1.Rows(22).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC24 = CBool(IIf(dt1.Rows(23).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC25 = CBool(IIf(dt1.Rows(24).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC26 = CBool(IIf(dt1.Rows(25).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC27 = CBool(IIf(dt1.Rows(26).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC28 = CBool(IIf(dt1.Rows(27).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC29 = CBool(IIf(dt1.Rows(28).Item("Disabled").ToString = "0", True, False))
        bPRMAS.INC30 = CBool(IIf(dt1.Rows(29).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_INC01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_INC02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_INC03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_INC04).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_INC05).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_INC06).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_INC07).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_INC08).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_INC09).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_INC10).Caption = dt1.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_INC11).Caption = dt1.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_INC12).Caption = dt1.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_INC13).Caption = dt1.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_INC14).Caption = dt1.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_INC15).Caption = dt1.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_INC16).Caption = dt1.Rows(15).Item("Short").ToString
        tdbg.Columns(COL_INC17).Caption = dt1.Rows(16).Item("Short").ToString
        tdbg.Columns(COL_INC18).Caption = dt1.Rows(17).Item("Short").ToString
        tdbg.Columns(COL_INC19).Caption = dt1.Rows(18).Item("Short").ToString
        tdbg.Columns(COL_INC20).Caption = dt1.Rows(19).Item("Short").ToString
        tdbg.Columns(COL_INC21).Caption = dt1.Rows(20).Item("Short").ToString
        tdbg.Columns(COL_INC22).Caption = dt1.Rows(21).Item("Short").ToString
        tdbg.Columns(COL_INC23).Caption = dt1.Rows(22).Item("Short").ToString
        tdbg.Columns(COL_INC24).Caption = dt1.Rows(23).Item("Short").ToString
        tdbg.Columns(COL_INC25).Caption = dt1.Rows(24).Item("Short").ToString
        tdbg.Columns(COL_INC26).Caption = dt1.Rows(25).Item("Short").ToString
        tdbg.Columns(COL_INC27).Caption = dt1.Rows(26).Item("Short").ToString
        tdbg.Columns(COL_INC28).Caption = dt1.Rows(27).Item("Short").ToString
        tdbg.Columns(COL_INC29).Caption = dt1.Rows(28).Item("Short").ToString
        tdbg.Columns(COL_INC30).Caption = dt1.Rows(29).Item("Short").ToString

        Dim dt3 As DataTable
        dt3 = ReturnTableFilter(dt, "Type = 'OLSC'", True)
        bOL.OLSC1 = CBool(IIf(dt3.Rows(0).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC10 = CBool(IIf(dt3.Rows(1).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC11 = CBool(IIf(dt3.Rows(2).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC12 = CBool(IIf(dt3.Rows(3).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC13 = CBool(IIf(dt3.Rows(4).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC14 = CBool(IIf(dt3.Rows(5).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC15 = CBool(IIf(dt3.Rows(6).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC2 = CBool(IIf(dt3.Rows(7).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC20 = CBool(IIf(dt3.Rows(8).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC21 = CBool(IIf(dt3.Rows(9).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC22 = CBool(IIf(dt3.Rows(10).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC23 = CBool(IIf(dt3.Rows(11).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC24 = CBool(IIf(dt3.Rows(12).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC25 = CBool(IIf(dt3.Rows(13).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_OfficalTitleID).Caption = dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_OffSa1DateEnd).Caption = sDateEnd & " " & dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_OffSa1NextDate).Caption = sNextDate & " " & dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_NextOfficalTitleID).Caption = dt3.Rows(0).Item("Short").ToString & " " & sNext

        tdbg.Columns(COL_SalaryLevelID).Caption = dt3.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_NextSalaryLevelID).Caption = dt3.Rows(1).Item("Short").ToString & " " & sNext

        tdbg.Columns(COL_SaCoefficient).Caption = dt3.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient12).Caption = dt3.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient13).Caption = dt3.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient14).Caption = dt3.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient15).Caption = dt3.Rows(6).Item("Short").ToString

        tdbg.Columns(COL_OfficalTitleID2).Caption = dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_OffSa2DateEnd).Caption = sDateEnd & " " & dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_OffSa2NextDate).Caption = sNextDate & " " & dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_NextOfficalTitleID2).Caption = dt3.Rows(7).Item("Short").ToString & " " & sNext

        tdbg.Columns(COL_SalaryLevelID2).Caption = dt3.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_NextSalaryLevelID2).Caption = dt3.Rows(8).Item("Short").ToString & " " & sNext

        tdbg.Columns(COL_SaCoefficient2).Caption = dt3.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient22).Caption = dt3.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient23).Caption = dt3.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient24).Caption = dt3.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient25).Caption = dt3.Rows(13).Item("Short").ToString

        ' Kiểm tra nếu không sử dụng thì mờ nut btnNextBaseSalary
        Dim dr() As DataRow = dt.Select("(Type = 'OLSC' OR Type='SALCE') AND Disabled = 0")
        bUseNextBaseSalary = dr.Length > 0

    End Sub

    Private Sub ButtonD09T0010()
        Dim sSQL As String = ""
        sSQL &= " Select TypeID Code, Description" & UnicodeJoin(gbUnicode) & " Short, Disabled From D09T0010  WITH(NOLOCK) Order By Code "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        bUseANAD09T0010 = dt.Select("Disabled = 0").Length > 0
        bANA.N01 = CBool(IIf(dt.Rows(0).Item("Disabled").ToString = "0", True, False))
        bANA.N02 = CBool(IIf(dt.Rows(1).Item("Disabled").ToString = "0", True, False))
        bANA.N03 = CBool(IIf(dt.Rows(2).Item("Disabled").ToString = "0", True, False))
        bANA.N04 = CBool(IIf(dt.Rows(3).Item("Disabled").ToString = "0", True, False))
        bANA.N05 = CBool(IIf(dt.Rows(4).Item("Disabled").ToString = "0", True, False))
        bANA.N06 = CBool(IIf(dt.Rows(5).Item("Disabled").ToString = "0", True, False))
        bANA.N07 = CBool(IIf(dt.Rows(6).Item("Disabled").ToString = "0", True, False))
        bANA.N08 = CBool(IIf(dt.Rows(7).Item("Disabled").ToString = "0", True, False))
        bANA.N09 = CBool(IIf(dt.Rows(8).Item("Disabled").ToString = "0", True, False))
        bANA.N10 = CBool(IIf(dt.Rows(9).Item("Disabled").ToString = "0", True, False))
        bANA.N11 = CBool(IIf(dt.Rows(10).Item("Disabled").ToString = "0", True, False))
        bANA.N12 = CBool(IIf(dt.Rows(11).Item("Disabled").ToString = "0", True, False))
        bANA.N13 = CBool(IIf(dt.Rows(12).Item("Disabled").ToString = "0", True, False))
        bANA.N14 = CBool(IIf(dt.Rows(13).Item("Disabled").ToString = "0", True, False))
        bANA.N15 = CBool(IIf(dt.Rows(14).Item("Disabled").ToString = "0", True, False))
        bANA.N16 = CBool(IIf(dt.Rows(15).Item("Disabled").ToString = "0", True, False))
        bANA.N17 = CBool(IIf(dt.Rows(16).Item("Disabled").ToString = "0", True, False))
        bANA.N18 = CBool(IIf(dt.Rows(17).Item("Disabled").ToString = "0", True, False))
        bANA.N19 = CBool(IIf(dt.Rows(18).Item("Disabled").ToString = "0", True, False))
        bANA.N20 = CBool(IIf(dt.Rows(19).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_N01).Caption = dt.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_N02).Caption = dt.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_N03).Caption = dt.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_N04).Caption = dt.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_N05).Caption = dt.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_N06).Caption = dt.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_N07).Caption = dt.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_N08).Caption = dt.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_N09).Caption = dt.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_N10).Caption = dt.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_N11).Caption = dt.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_N12).Caption = dt.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_N13).Caption = dt.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_N14).Caption = dt.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_N15).Caption = dt.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_N16).Caption = dt.Rows(15).Item("Short").ToString
        tdbg.Columns(COL_N17).Caption = dt.Rows(16).Item("Short").ToString
        tdbg.Columns(COL_N18).Caption = dt.Rows(17).Item("Short").ToString
        tdbg.Columns(COL_N19).Caption = dt.Rows(18).Item("Short").ToString
        tdbg.Columns(COL_N20).Caption = dt.Rows(19).Item("Short").ToString

        '        For i As Integer = COL_N01 To COL_N20
        '            tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        '        Next
    End Sub

    Private Sub ButtonD13T0050()
        Dim sSQL As String = ""
        sSQL = "Select PAnaCategoryID as Code, PAnaCategoryShort" & UnicodeJoin(gbUnicode) & " as Short,Disabled From D13T0050  WITH(NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)

        For i As Integer = 0 To 19
            If CBool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False)) Then
                bUseAnaSal = True
                '  Exit For
            End If
        Next
        bANASAL.P01 = CBool(IIf(dt.Rows(0).Item("Disabled").ToString = "0", True, False))
        bANASAL.P02 = CBool(IIf(dt.Rows(1).Item("Disabled").ToString = "0", True, False))
        bANASAL.P03 = CBool(IIf(dt.Rows(2).Item("Disabled").ToString = "0", True, False))
        bANASAL.P04 = CBool(IIf(dt.Rows(3).Item("Disabled").ToString = "0", True, False))
        bANASAL.P05 = CBool(IIf(dt.Rows(4).Item("Disabled").ToString = "0", True, False))
        bANASAL.P06 = CBool(IIf(dt.Rows(5).Item("Disabled").ToString = "0", True, False))
        bANASAL.P07 = CBool(IIf(dt.Rows(6).Item("Disabled").ToString = "0", True, False))
        bANASAL.P08 = CBool(IIf(dt.Rows(7).Item("Disabled").ToString = "0", True, False))
        bANASAL.P09 = CBool(IIf(dt.Rows(8).Item("Disabled").ToString = "0", True, False))
        bANASAL.P10 = CBool(IIf(dt.Rows(9).Item("Disabled").ToString = "0", True, False))
        bANASAL.P11 = CBool(IIf(dt.Rows(10).Item("Disabled").ToString = "0", True, False))
        bANASAL.P12 = CBool(IIf(dt.Rows(11).Item("Disabled").ToString = "0", True, False))
        bANASAL.P13 = CBool(IIf(dt.Rows(12).Item("Disabled").ToString = "0", True, False))
        bANASAL.P14 = CBool(IIf(dt.Rows(13).Item("Disabled").ToString = "0", True, False))
        bANASAL.P15 = CBool(IIf(dt.Rows(14).Item("Disabled").ToString = "0", True, False))
        bANASAL.P16 = CBool(IIf(dt.Rows(15).Item("Disabled").ToString = "0", True, False))
        bANASAL.P17 = CBool(IIf(dt.Rows(16).Item("Disabled").ToString = "0", True, False))
        bANASAL.P18 = CBool(IIf(dt.Rows(17).Item("Disabled").ToString = "0", True, False))
        bANASAL.P19 = CBool(IIf(dt.Rows(18).Item("Disabled").ToString = "0", True, False))
        bANASAL.P20 = CBool(IIf(dt.Rows(19).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_P01).Caption = dt.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_P02).Caption = dt.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_P03).Caption = dt.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_P04).Caption = dt.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_P05).Caption = dt.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_P06).Caption = dt.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_P07).Caption = dt.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_P08).Caption = dt.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_P09).Caption = dt.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_P10).Caption = dt.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_P11).Caption = dt.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_P12).Caption = dt.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_P13).Caption = dt.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_P14).Caption = dt.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_P15).Caption = dt.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_P16).Caption = dt.Rows(15).Item("Short").ToString
        tdbg.Columns(COL_P17).Caption = dt.Rows(16).Item("Short").ToString
        tdbg.Columns(COL_P18).Caption = dt.Rows(17).Item("Short").ToString
        tdbg.Columns(COL_P19).Caption = dt.Rows(18).Item("Short").ToString
        tdbg.Columns(COL_P20).Caption = dt.Rows(19).Item("Short").ToString

        '        For i As Integer = COL_P01 To COL_P20
        '            tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        '        Next
    End Sub

    Private Sub ClickButton(ByVal button As Button, Optional ByVal bFlagLoad As Boolean = False)

        btnSalaryCoefficientBase.Enabled = Math.Abs(button - button.SalaryCoefficientBase) > 0
        btnIncome.Enabled = Math.Abs(button - button.Income) > 0 And bUsePRMAS
        btnAnalyseCode.Enabled = Math.Abs(button - button.AnalyseCode) > 0 And bUseANAD09T0010
        btnNextBaseSalary.Enabled = Math.Abs(button - button.NextBaseSalary) > 0 And bUseNextBaseSalary  ' 13/1/2014 id 60442
        btnFamilyDeduction.Enabled = Math.Abs(button - button.FamilyDeduction) > 0  ' 13/1/2014 id 60442
        btnBank.Enabled = Math.Abs(button - button.Bank) > 0  ' 13/1/2014 id 60442
        btnSalaryLevelOfficialTitle.Enabled = Math.Abs(button - button.SalaryLevelOfficialTitle) > 0
        btnAnalyseSalary.Enabled = Math.Abs(button - button.AnalyseSalary) > 0 And bUseAnaSal And D13Systems.IsUsedPAna
        btnInfoOther.Enabled = Math.Abs(button - button.InfoOther) > 0 And bUseInfoOther

        btnUpdateReduce.Visible = Math.Abs(button - button.FamilyDeduction) = 0
        If Math.Abs(button - button.FamilyDeduction) = 0 Then ' Giảm tr gia cảnh
            tdbgRelative.Visible = True

            grpPaymentMethod.Visible = False '19/8/2015, id 73668- Chuyển phương pháp trả lương sang Tab Ngân hàng
            tdbgBankID.Visible = False
            btnSave.Visible = True
            ' tdbg.Width = 490 'tdbg.Width - (tdbgRelative.Width + 6)
            If tdbg.Right >= tdbgRelative.Right Then tdbg.Width = tdbg.Width - (tdbgRelative.Width + 8)
            If tdbg.Splits.Count >= 2 Then tdbg.RemoveHorizontalSplit(SPLIT1)
            GoTo 1
        ElseIf Math.Abs(button - button.Bank) = 0 Then ' Ngân hàng
            tdbgRelative.Visible = False
            grpPaymentMethod.Visible = True '19/8/2015, id 73668- Chuyển phương pháp trả lương sang Tab Ngân hàng
            tdbgBankID.Visible = True
            btnSave.Visible = True
            '   tdbg.Width = 490 'tdbg.Width - (tdbgRelative.Width + 6)
            If tdbg.Right >= tdbgRelative.Right Then tdbg.Width = tdbg.Width - (tdbgRelative.Width + 8)
            If tdbg.Splits.Count >= 2 Then tdbg.RemoveHorizontalSplit(SPLIT1)
            GoTo 1
        Else
            tdbgRelative.Visible = False
            grpPaymentMethod.Visible = False '19/8/2015, id 73668- Chuyển phương pháp trả lương sang Tab Ngân hàng
            tdbgBankID.Visible = False
            btnSave.Visible = False
            '   tdbg.Width = 995 ' tdbg.Width + (tdbgRelative.Width + 6)
            If tdbg.Right < tdbgRelative.Right Then tdbg.Width = tdbg.Width + (tdbgRelative.Width + 8)


            If tdbg.Splits.Count < 2 Then
                tdbg.InsertHorizontalSplit(SPLIT1)
                tdbg.Splits(SPLIT1).RecordSelectors = False
                'tdbg.Splits(SPLIT1).SplitSize = 13
            End If

            For i As Integer = 0 To tdbg.Columns.Count - 1
                tdbg.Splits(1).DisplayColumns(i).Visible = False
                tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If

        tdbg.Splits(SPLIT1).DisplayColumns(COL_BASE01).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BASE02).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BASE03).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BASE04).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE04

        ' Tạm thời ẩn
        '        For i As Integer = 0 To 3 ' Ẩn hiện tương tự COLS_BASExx
        '            tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseCurrencyID01 + (i * 2)).Visible = tdbg.Splits(SPLIT1).DisplayColumns(COL_BASE01 + (i * 2)).Visible
        '        Next

        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE01).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE02).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE03).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE04).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE05).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE06).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE07).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE08).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE09).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE10).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE11).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE12).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE13).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE14).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE15).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE16).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE17).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE18).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE19).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CE20).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE20

        ' Tạm thời ẩn
        '        For i As Integer = 0 To 19 '  Ẩn hiện tương tự COL_CExx
        '            tdbg.Splits(SPLIT1).DisplayColumns(COL_SalCoeCurrencyID01 + (i * 2)).Visible = tdbg.Splits(SPLIT1).DisplayColumns(COL_CE01 + (i * 2)).Visible
        '        Next
        '
        For i As Integer = COL_BASE01 To COL_CE20
            tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next

        '**************************************
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC01).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC02).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC03).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC04).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC05).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC06).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC07).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC08).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC09).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC10).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC11).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC12).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC13).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC14).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC15).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC16).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC17).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC18).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC19).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC20).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC20
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC21).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC21
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC22).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC22
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC23).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC23
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC24).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC24
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC25).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC25
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC26).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC26
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC27).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC27
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC28).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC28
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC29).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC29
        tdbg.Splits(SPLIT1).DisplayColumns(COL_INC30).Visible = Math.Abs(button - button.Income) = 0 And bPRMAS.INC30
        '***************************************
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N01).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N02).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N03).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N04).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N05).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N06).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N07).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N08).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N09).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N10).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N11).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N12).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N13).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N14).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N15).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N16).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N17).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N18).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N19).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_N20).Visible = Math.Abs(button - button.AnalyseCode) = 0 And bANA.N20
        '*****************************************
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OfficalTitleID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC1
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OfficialTitleName1).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC1
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SalaryLevelID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SalaryLevelName1).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient12).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient13).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient14).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient15).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC15

        tdbg.Splits(SPLIT1).DisplayColumns(COL_OfficalTitleID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC2
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OfficialTitleName2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC2
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SalaryLevelID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC20
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SalaryLevelName2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC20
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC21
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient22).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC22
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient23).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC23
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient24).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC24
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SaCoefficient25).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC25
        '*****************************************
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P01).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P02).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P03).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P04).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P05).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P06).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P07).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P08).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P09).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P10).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P11).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P12).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P13).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P14).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P15).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P16).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P17).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P18).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P19).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_P20).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P20
        '*****************************************
        'update 27/12/2012 id 52980
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref02).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref03).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref04).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref05).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref05

        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef01).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef02).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef03).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef04).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef05).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef06).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef07).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef08).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef09).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NumRef10).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef10

        Dim bButtonNextBaseSalary As Boolean = Math.Abs(button - button.NextBaseSalary) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary01DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary02DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary03DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary04DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary01NextDate).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary02NextDate).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary03NextDate).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BaseSalary04NextDate).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextBaseSalary01).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextBaseSalary02).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextBaseSalary03).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextBaseSalary04).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal01DateEnd).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal02DateEnd).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal03DateEnd).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal04DateEnd).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal05DateEnd).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal06DateEnd).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal07DateEnd).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal08DateEnd).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal09DateEnd).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal10DateEnd).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal11DateEnd).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal12DateEnd).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal13DateEnd).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal14DateEnd).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal15DateEnd).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal16DateEnd).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal17DateEnd).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal18DateEnd).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal19DateEnd).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal20DateEnd).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal01NextDate).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal02NextDate).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal03NextDate).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal04NextDate).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal05NextDate).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal06NextDate).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal07NextDate).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal08NextDate).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal09NextDate).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal10NextDate).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal11NextDate).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal12NextDate).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal13NextDate).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal14NextDate).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal15NextDate).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal16NextDate).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal17NextDate).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal18NextDate).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal19NextDate).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Sal20NextDate).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient01).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient02).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient03).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient04).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient05).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient06).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient07).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient08).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient09).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient10).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient11).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient12).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient13).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient14).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient15).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient16).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient17).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient18).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient19).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalCoefficient20).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(SPLIT1).DisplayColumns(COL_OffSa1DateEnd).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OffSa1NextDate).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextOfficalTitleID).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalaryLevelID).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC11

        tdbg.Splits(SPLIT1).DisplayColumns(COL_OffSa2DateEnd).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OffSa2NextDate).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextOfficalTitleID2).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(SPLIT1).DisplayColumns(COL_NextSalaryLevelID2).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC21

        'Chuẩn hóa D09U1111 B6: Refresh lại lưới
1:      '  If Not bFlagLoad Then Call_D09U1111Refresh()
        tdbg.Refresh()
    End Sub

    '    Private Sub Call_D09U1111Refresh()
    '        'Chuẩn hóa D09U1111 B6: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
    '        'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
    '        If usrOption IsNot Nothing Then
    '            If tdbg.Splits.Count >= 2 Then
    '                usrOption.MarkInvisibleColumn(SPLIT1)
    '            End If
    '            usrOption.D09U1111Refresh()
    '        End If
    '    End Sub

    Private Function AllowPressButton() As Boolean
        If tdbgRelative.Visible Or tdbgBankID.Visible Then
            If bChangeTDBGRelative Or bChangeTDBGBankID Then
                If AskMsgBeforeRowChange() Then
                    If btnSave.Enabled And btnSave.Visible Then
                        bSaveOK = False
                        btnSave_Click(Nothing, Nothing)
                        If Not bSaveOK Then Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function

    Private Sub btnSalaryCoefficientBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryCoefficientBase.Click
        If Not AllowPressButton() Then Exit Sub

        ClickButton(Button.SalaryCoefficientBase)
        tdbg.Splits(SPLIT1).Caption = rL3("Luong_co_ban_He_so")
    End Sub

    Private Sub btnIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncome.Click
        If Not AllowPressButton() Then Exit Sub

        ClickButton(Button.Income)
        tdbg.Splits(SPLIT1).Caption = rL3("Thu_nhap")
    End Sub

    Private Sub btnAnalyseCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyseCode.Click
        If Not AllowPressButton() Then Exit Sub

        '  tdbg.Splits(2).SplitSize = 1
        ClickButton(Button.AnalyseCode)
        tdbg.Splits(SPLIT1).Caption = rL3("Ma_phan_tich")
    End Sub

    ' 14/1/2014 id 60442
    Private Sub btnNextBaseSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextBaseSalary.Click
        If Not AllowPressButton() Then Exit Sub

        ClickButton(Button.NextBaseSalary)
        tdbg.Splits(SPLIT1).Caption = rL3("Luong_tiep_theo")
    End Sub

    ' 14/1/2014 id 60442
    Dim bSaveOK As Boolean = False
    Private Sub btnFamilyDeduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFamilyDeduction.Click
        ClickButton(Button.FamilyDeduction)
    End Sub

    ' 14/1/2014 id 60442
    Private Sub btnBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBank.Click
        ClickButton(Button.Bank)
    End Sub

    Private Sub btnAnalyseSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyseSalary.Click
        If Not AllowPressButton() Then Exit Sub

        ClickButton(Button.AnalyseSalary)
        tdbg.Splits(SPLIT1).Caption = rL3("Ma_phan_tich_tien_luong")
    End Sub

    Private Sub btnSalaryLevelOfficialTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryLevelOfficialTitle.Click
        If Not AllowPressButton() Then Exit Sub

        bFlag = True
        ClickButton(Button.SalaryLevelOfficialTitle)
        tdbg.Splits(SPLIT1).Caption = rL3("Ngach_bac_luong")
    End Sub

    ' update 27/12/2012 id 52980
    Private Sub btnInfoOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfoOther.Click
        If Not AllowPressButton() Then Exit Sub

        ClickButton(Button.InfoOther)
        tdbg.Splits(SPLIT1).Caption = rL3("Thong_tin_khac")
    End Sub

    Private Function AllowSaveBankID() As Boolean
        dtGridBankID.AcceptChanges()

        Dim dtEmp As DataTable = ReturnTableFilter(dtGridBankID, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID")

        For i As Integer = 0 To dtEmp.Rows.Count - 1
            Dim dr() As DataRow = dtGridBankID.Select("EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID").ToString))
            If dr.Length <= 0 Then
                D99C0008.MsgNoDataInGrid()
                btnBank_Click(Nothing, Nothing)
                tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                LoadTDBGridRelative()
                tdbgBankID.Focus()
                Return False
            End If
            For j As Integer = 0 To dr.Length - 1
                If dr(j).Item("BankID").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ngan_hang"))
                    btnBank_Click(Nothing, Nothing)
                    tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                    LoadTDBGridRelative()
                    LoadTDBGridBankID()
                    tdbgBankID.Focus()
                    tdbgBankID.SplitIndex = SPLIT0
                    tdbgBankID.Col = COLB_BankID
                    tdbgBankID.Row = j
                    Return False
                End If
                If dr(j).Item("BankAccountNo").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("So_tai_khoan"))
                    btnBank_Click(Nothing, Nothing)
                    tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                    LoadTDBGridRelative()
                    LoadTDBGridBankID()
                    tdbgBankID.Focus()
                    tdbgBankID.SplitIndex = SPLIT0
                    tdbgBankID.Col = COLB_BankAccountNo
                    tdbgBankID.Row = j
                    Return False
                End If
            Next

            If dtGridBankID.Select("IsDefault=1 AND EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID").ToString)).Length = 0 Then
                D99C0008.MsgNotYetEnter(rL3("Mac_dinh"))
                btnBank_Click(Nothing, Nothing)
                tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                LoadTDBGridRelative()
                LoadTDBGridBankID()
                tdbgBankID.Focus()
                tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                tdbgBankID.Col = COLB_IsDefault 'Tùy theo yêu cầu mỗi Form
                tdbgBankID.Row = 0 'Tùy theo yêu cầu mỗi Form
                Return False
            End If

            For j As Integer = 0 To dr.Length - 2
                For k As Integer = j + 1 To dr.Length - 1
                    If dr(j).Item("BankAccountNo").ToString = dr(k).Item("BankAccountNo").ToString Then
                        D99C0008.MsgL3(rL3("So_tai_khoan_bi_trung") & " " & rL3("Ban_khong_duoc_phep_luu"))
                        btnBank_Click(Nothing, Nothing)
                        tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                        LoadTDBGridRelative()
                        LoadTDBGridBankID()
                        tdbgBankID.Focus()
                        tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                        tdbgBankID.Col = COLB_BankAccountNo 'Tùy theo yêu cầu mỗi Form
                        tdbgBankID.Row = k 'Tùy theo yêu cầu mỗi Form
                        Return False
                    End If
                Next
            Next

            If dtGridBankID.Select("IsDefault=1 AND EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID"))).Length >= 2 Then
                D99C0008.MsgL3(rL3("Ton_tai_2_ngan_hang_mac_dinh") & " " & rL3("Ban_khong_duoc_phep_luu"))
                btnBank_Click(Nothing, Nothing)
                tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                LoadTDBGridRelative()
                LoadTDBGridBankID()
                tdbgBankID.Focus()
                tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                tdbgBankID.Col = COLB_IsDefault 'Tùy theo yêu cầu mỗi Form
                tdbgBankID.Row = 0 'Tùy theo yêu cầu mỗi Form
                tdbgBankID.Bookmark = tdbgBankID.Row
                Return False
            End If
        Next

        Return True
    End Function

    Private Function AllowSaveRelative() As Boolean
        dtGridRelative.AcceptChanges()

        Dim dtEmp As DataTable = ReturnTableFilter(dtGridRelative, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID")

        For i As Integer = 0 To dtEmp.Rows.Count - 1
            Dim dr() As DataRow = dtGridRelative.Select("EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID").ToString))
            For j As Integer = 0 To dr.Length - 1
                If dr(j).Item("YBirthDate").ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbgRelative.Columns(COL1_YBirthDate).Caption)
                    btnFamilyDeduction_Click(Nothing, Nothing)
                    tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                    LoadTDBGridRelative()
                    LoadTDBGridBankID()
                    tdbgRelative.Focus()
                    tdbgRelative.SplitIndex = SPLIT0
                    tdbgRelative.Col = COL1_YBirthDate
                    tdbgRelative.Row = j
                    Return False
                End If
                If dr(j).Item("DBirthDate").ToString <> "" Then
                    If dr(j).Item("MBirthDate").ToString = "" Then
                        D99C0008.MsgNotYetEnter(tdbgRelative.Columns(COL1_MBirthDate).Caption)
                        btnFamilyDeduction_Click(Nothing, Nothing)
                        tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                        LoadTDBGridRelative()
                        LoadTDBGridBankID()
                        tdbgRelative.Focus()
                        tdbgRelative.SplitIndex = SPLIT0
                        tdbgRelative.Col = COL1_MBirthDate
                        tdbgRelative.Row = j
                        Return False
                    End If
                End If
                If dr(j).Item("DeductibleDateBegin").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Bat_dau_GT"))
                    btnFamilyDeduction_Click(Nothing, Nothing)
                    tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                    LoadTDBGridRelative()
                    LoadTDBGridBankID()
                    tdbgRelative.Focus()
                    tdbgRelative.SplitIndex = SPLIT0
                    tdbgRelative.Col = COL1_DeductibleDateBegin
                    tdbgRelative.Row = j
                    Return False
                End If
                If dr(j).Item("DeductibleDateBegin").ToString <> "" And dr(j).Item("DeductibleDateEnd").ToString <> "" Then
                    If CDate(dr(j).Item("DeductibleDateBegin").ToString) > CDate(dr(j).Item("DeductibleDateEnd").ToString) Then
                        D99C0008.MsgL3(rL3("MSG000013"))
                        btnFamilyDeduction_Click(Nothing, Nothing)
                        tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                        LoadTDBGridRelative()
                        LoadTDBGridBankID()
                        tdbgRelative.Focus()
                        tdbgRelative.SplitIndex = SPLIT0
                        tdbgRelative.Col = COL1_DeductibleDateEnd
                        tdbgRelative.Row = j
                        Return False
                    End If
                End If
                ''*********************
                'Dim sDate As String = ReturnBirthDate(L3Byte(dr(j).Item("UndefinedBirthDate")), dr(j).Item("DBirthDate").ToString, dr(j).Item("MBirthDate").ToString, dr(j).Item("YBirthDate").ToString)
                'Dim sSQL As String = SQLStoreD13P5555(sDate, dr(j).Item("RelationID").ToString, dr(j).Item("DeductibleDateBegin").ToString)
                'If CheckStore(sSQL) = False Then
                '    btnFamilyDeduction_Click(Nothing, Nothing)
                '    tdbg.Row = findrowInGrid(tdbg, dtEmp.Rows(i).Item("EmployeeID").ToString, "EmployeeID")
                '    LoadTDBGridRelative()
                '    LoadTDBGridBankID()
                '    tdbgRelative.Focus()
                '    tdbgRelative.SplitIndex = SPLIT0
                '    tdbgRelative.Col = COL1_DeductibleDateBegin
                '    tdbgRelative.Row = j
                '    Return False
                'End If
            Next
        Next

        Return True
    End Function

    Private Function ReturnBirthDate(ByVal iUndefinedBirthDate As Byte, ByVal sDay As String, ByVal sMonth As String, ByVal sYear As String) As String
        Dim sBirthDate As String = ""

        If iUndefinedBirthDate = 0 Then 'Nhap day du ngay ,thang ,nam
            sBirthDate = CDate(sDay).Day.ToString("00") & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        ElseIf iUndefinedBirthDate = 1 Then 'Chi nhap thang,nam
            sBirthDate = Date.DaysInMonth(L3Int(CDate(sYear).Year), L3Int(CDate(sMonth).Month)) & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        Else  'Chi nhap nam
            sBirthDate = "31/12/" & CDate(sYear).Year.ToString("0000")
        End If
        'Dim _sDay, _sMonth, _sYear As String
        '_sDay = tdbgRelative.Columns(COL1_DBirthDate).Text
        '_sMonth = tdbgRelative.Columns(COL1_MBirthDate).Text
        '_sYear = tdbgRelative.Columns(COL1_YBirthDate).Text
        'If _sDay <> "" And _sMonth <> "" And _sYear <> "" Then ' Nhập đầy đủ ngày thang năm
        '    sBirthDate = CDate(sDay).Day.ToString("00") & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        'ElseIf _sMonth <> "" And _sYear <> "" Then ' Chỉ nhập tháng năm
        '    sBirthDate = Date.DaysInMonth(L3Int(CDate(sYear).Year), L3Int(CDate(sMonth).Month)) & "/" & CDate(sMonth).Month.ToString("00") & "/" & CDate(sYear).Year.ToString("0000")
        'Else 'Chi nhập năm
        '    sBirthDate = "31/12/" & CDate(sYear).Year.ToString("0000")
        'End If
        Return sBirthDate
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sender IsNot Nothing Then
            If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        'Dim drRelative() As DataRow = Nothing
        'Dim drBankID() As DataRow = Nothing
        'If Not AllowSaveRelative() Then Exit Sub
        If Not AllowSaveBankID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        btnSave.Enabled = False
        btnClose.Enabled = False
        Dim sSQL As New StringBuilder

        'sSQL.Append(SQLDeleteD13T0216() & vbCrLf)
        'sSQL.Append(SQLInsertD13T0216s().ToString & vbCrLf)
        sSQL.Append(SQLDeleteD13T0202() & vbCrLf)
        sSQL.Append(SQLInsertD13T0202s().ToString & vbCrLf)

        '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
        'Lưu phương thức trả lương
        sSQL.Append(SQLUpdateD13T0101.ToString & vbCrLf)
        If CheckMaxPeriod() Then
            sSQL.Append(SQLUpdateD13T0201) 'varchar[20], NULL
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)

        Me.Cursor = Cursors.Default
        If bRunSQL Then
            bChangeTDBGRelative = False
            bChangeTDBGBankID = False
            SaveOK()
            _bSaved = True
            bSaveOK = _bSaved

            For i As Integer = 0 To dtGridBankID.Rows.Count - 1
                dtGridBankID.Rows(i).Item("IsNewRow") = "0"
                dtGridBankID.Rows(i).Item("IsUpdate") = 0
            Next
            'For i As Integer = 0 To dtGridRelative.Rows.Count - 1
            '    dtGridRelative.Rows(i).Item("IsNewRow") = "0"
            'Next

            '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng

            Dim sPaymentMethod As String = "", sPaymentMethodName As String = ""
            If optPaymentMethod_C.Checked Then
                sPaymentMethod = "C"
                sPaymentMethodName = rL3("Tien_mat") 'Tiền mặt
            ElseIf optPaymentMethod_B.Checked Then
                sPaymentMethod = "B"
                sPaymentMethodName = rL3("Chuyen_khoan") 'Chuyển khoản
            ElseIf optPaymentMethod_O.Checked Then
                sPaymentMethod = "O"
                sPaymentMethodName = rL3("Hinh_thuc_khac") 'Hình thức khác
            End If
            If tdbg.Columns(COL_PaymentMethod).Text <> sPaymentMethod Then
                If gbUnicode = False Then sPaymentMethodName = ConvertUnicodeToVni(sPaymentMethodName)
                tdbg.Columns(COL_PaymentMethod).Text = sPaymentMethod
                tdbg.Columns(COL_PaymentMethodName).Text = sPaymentMethodName
            End If

            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Function SQLInsertSelectedRows() As String
        Dim sSQL As String = ""
        Dim r As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        If r.Count > 0 Then
            For i As Integer = 0 To r.Count - 1
                sSQL &= SQLInsertD91T9009(tdbg(r.Item(i), COL_DepartmentID).ToString, tdbg(r.Item(i), COL_TeamID).ToString, tdbg(r.Item(i), COL_EmployeeID).ToString, tdbg(r.Item(i), COL_TransID).ToString).ToString & vbCrLf
            Next
        Else
            sSQL = SQLInsertD91T9009(tdbg.Columns(COL_DepartmentID).Text, tdbg.Columns(COL_TeamID).Text, tdbg.Columns(COL_EmployeeID).Text, tdbg.Columns(COL_TransID).Text).ToString & vbCrLf
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0101
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 12/02/2007 09:24:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0101(ByVal sDepartmentID As String, ByVal sTeamID As String, ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0101"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & " And "
        sSQL &= "EmployeeID = " & SQLString(sEmployeeID) & " And "
        sSQL &= "DepartmentID = " & SQLString(sDepartmentID) & " And "
        sSQL &= "TeamID = " & SQLString(sTeamID) & " And "
        sSQL &= "TranMonth = " & giTranMonth & " And "
        sSQL &= "TranYear = " & giTranYear
        Return sSQL
    End Function

    'Private Function SQLDeleteD13T0101() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Delete From D13T0101"
    '    sSQL &= " Where "
    '    sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
    '    sSQL &= "PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And "
    '    sSQL &= "EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text) & " And "
    '    sSQL &= "DepartmentID = " & SQLString(tdbg.Columns(COL_DepartmentID).Text) & " And "
    '    sSQL &= "TeamID = " & SQLString(tdbg.Columns(COL_TeamID).Text) & " And "
    '    sSQL &= "TranMonth = " & giTranMonth & " And "
    '    sSQL &= "TranYear = " & giTranYear
    '    Return sSQL
    'End Function

    Private Function CheckBeforeDelete() As Boolean
        Dim sSQL As String = ""
        Dim sSQL1 As String = ""
        Dim sSQL2 As String = ""
        Dim sRet As String
        Dim sRet1 As String
        Dim sRet2 As String

        'Kiểm tra trong danh mục tính phiếu lương
        sSQL &= " Select Top 1 1 From D13T2600  WITH(NOLOCK) Where PayrollVoucherID = " & SQLString(gsPayRollVoucherID)
        sSQL &= " AND Calculated = 1"
        sRet = ReturnScalar(sSQL)
        If sRet <> "" Then
            D99C0008.MsgCanNotDelete()
            Return False
        Else
            'Kiểm tra trong phiếu chấm công nhật
            sSQL1 &= "Select Top 1 1 From D13F0103  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & " And "
            sSQL1 &= "PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & " And "
            sSQL1 &= "EmployeeID = " & tdbg.Columns(COL_EmployeeID).Text
            sRet1 = ReturnScalar(sSQL)
            If sRet1 <> "" Then
                D99C0008.MsgCanNotDelete()
                Return False
            Else
                'Kiểm tra trong phiếu chấm công sản phẩm
                sSQL2 &= "Select Top 1 1 From D13T0107  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & " And "
                sSQL2 &= "PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & " And "
                sSQL2 &= "EmployeeID = " & tdbg.Columns(COL_EmployeeID).Text
                sRet2 = ReturnScalar(sSQL)
                If sRet2 <> "" Then
                    D99C0008.MsgCanNotDelete()
                    Return False
                Else
                    Return True
                End If
            End If
        End If
    End Function

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Dim iBookmark As Integer
        Dim sSQL As String = ""
        Dim bResult As Boolean

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            'If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

            'If CheckStoreD13P0102(SQLStoreD13P0102(L3Int(IIf(_path = "01", 3, 1)))) Then
            If CheckStore(SQLStoreD13P0102(L3Int(IIf(_path = "01", 3, 1)))) Then
                bResult = ExecuteSQL(SQLStoreD13P2015(L3Int(IIf(_path = "01", 1, 0))))
                If bResult Then
                    DeleteOK()
                    _bSaved = True
                    LoadTDBGrid()
                Else
                    DeleteNotOK()
                End If
            End If
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2015
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 24/08/2011 09:17:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2015(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2015 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransID).Text) & COMMA 'TransID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    'Private Function CheckStoreD13P0102(ByVal SQL As String) As Boolean
    '    Dim dt As New DataTable
    '    dt = ReturnDataTable(SQL)
    '    If dt.Rows.Count > 0 Then
    '        If dt.Rows(0).Item("Status").ToString = "0" Then
    '            'Allow Delete Data
    '        ElseIf dt.Rows(0).Item("Status").ToString = "1" Then
    '            Dim sNotice As String = ""
    '            sNotice = rl3("Ban_khong_duoc_phep_xoa_du_lieu_nay") & ":" & vbCrLf
    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                sNotice &= rl3("Ma_NV") & ": " & dt.Rows(i).Item("EmployeeID").ToString & COMMA
    '                sNotice &= " " & rl3("Ten_NV") & ": " & ConvertVniToUnicode(dt.Rows(i).Item("EmployeeName").ToString) & COMMA
    '                sNotice &= " " & rl3("Ma_PB") & ": " & dt.Rows(i).Item("DepartmentID").ToString
    '                If dt.Rows(i).Item("TeamID").ToString.Trim <> "" Then
    '                    sNotice &= COMMA & " " & rl3("Ma_TN") & ": " & dt.Rows(i).Item("TeamID").ToString
    '                End If
    '                sNotice &= vbCrLf
    '            Next

    '            sNotice &= rl3("MSG000021")
    '            If D99C0008.Msg(sNotice, rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
    '                'Allow Delete Data
    '            Else
    '                Return False
    '            End If
    '        ElseIf dt.Rows(0).Item("Status").ToString = "2" Then
    '            D99C0008.MsgL3(rl3("Ban_khong_duoc_phep_xoa_du_lieu_nay"))
    '            Return False
    '        End If

    '        dt = Nothing
    '    Else
    '        D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
    '        Return False
    '    End If
    '    Return True
    'End Function

    Private Function SQLDeleteD13T0101() As String
        Dim sSQL As String = ""
        sSQL &= "DELETE     T1" & vbCrLf
        sSQL &= "FROM       D13T0101 T1" & vbCrLf
        sSQL &= "INNER JOIN D91T9009 T2 ON T1.EmployeeID = T2.Key03ID" & vbCrLf
        sSQL &= "           AND T1.DivisionID = T2.Key01ID" & vbCrLf
        sSQL &= "           AND T1.DepartmentID = T2.Key05ID" & vbCrLf
        sSQL &= "           AND T1.TeamID = T2.Key06ID" & vbCrLf
        sSQL &= "WHERE      T2.UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= "           AND T2.HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "           AND T2.Key02ID = " & SQLString("D13F2012") & vbCrLf
        sSQL &= "           AND T2.Key07ID = " & Number(1) & vbCrLf
        sSQL &= "           AND T1.TranMonth = " & Number(giTranMonth) & vbCrLf
        sSQL &= "           AND T1.TranYear = " & Number(giTranYear) & vbCrLf
        sSQL &= "           AND T1.PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & vbCrLf

        sSQL &= "DELETE     D91T9009" & vbCrLf
        sSQL &= "WHERE      UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= "           AND HostID = " & SQLString(My.Computer.Name)
        Return sSQL
    End Function

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        'Dim strCellTip As String

        'strCellTip = rl3("Ban_chon_F6_de_ke_thua_cho_Luong_co_banhe_so")
        'Select Case e.ColIndex
        '    Case COL_DepartmentID
        '        e.CellTip = tdbg.Columns(COL_DepartmentName).Text
        '    Case COL_TeamID
        '        e.CellTip = tdbg.Columns(COL_TeamName).Text
        '    Case COL_BASE01
        '        e.CellTip = strCellTip
        '    Case COL_BASE02
        '        e.CellTip = strCellTip
        '    Case COL_BASE03
        '        e.CellTip = strCellTip
        '    Case COL_BASE04
        '        e.CellTip = strCellTip
        '    Case COL_CE01
        '        e.CellTip = strCellTip
        '    Case COL_CE02
        '        e.CellTip = strCellTip
        '    Case COL_CE03
        '        e.CellTip = strCellTip
        '    Case COL_CE04
        '        e.CellTip = strCellTip
        '    Case COL_CE05
        '        e.CellTip = strCellTip
        '    Case COL_CE06
        '        e.CellTip = strCellTip
        '    Case COL_CE07
        '        e.CellTip = strCellTip
        '    Case COL_CE08
        '        e.CellTip = strCellTip
        '    Case COL_CE09
        '        e.CellTip = strCellTip
        '    Case COL_CE10
        '        e.CellTip = strCellTip
        '    Case Else
        '        e.CellTip = ""
        'End Select
    End Sub


    Private Sub mnuOpenExtraSalaryFile_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuOpenExtraSalaryFile.Click
        'Mở HSL Phụ
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As String = ""
        Dim sEmployeeIsSub As String = ""
        Dim bFlagSave As Boolean = False
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        If tdbg.SelectedRows.Count = 0 Then
            If CBool(tdbg.Columns(COL_IsSub).Text) Then
                sEmployeeIsSub = tdbg.Columns(COL_EmployeeID).Text
            Else
                bFlagSave = True
            End If
        Else
            For i As Integer = 0 To tdbg.SelectedRows.Count - 1
                If CBool(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_IsSub).ToString) Then
                    If sEmployeeIsSub = "" Then
                        sEmployeeIsSub = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_EmployeeID).ToString
                    Else
                        sEmployeeIsSub = sEmployeeIsSub & "; " & tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_EmployeeID).ToString
                    End If
                Else
                    bFlagSave = True
                End If
            Next
        End If

        If sEmployeeIsSub <> "" Then
            D99C0008.MsgL3(rL3("Nhan_vien") & ": " & sEmployeeIsSub & " " & rL3("dang_la_HSL_phu_Khong_cho_phep_mo_HSL_phu"))
        End If

        If bFlagSave Then
            sSQL = SQLDeleteD91T9009() & vbCrLf
            sSQL &= SQLInsertD91T9009s().ToString
            ExecuteSQL(sSQL)

            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "ParentFormID", "D13F2012")
            'SetProperties(arrPro, "PayrollVoucherID", gsPayRollVoucherID) ' Biến chung D13
            Dim frm As Form = CallFormShowDialog("D13D0140", "D13F2014", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) Then
                LoadTDBGrid(True)
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If

            '            Dim f As New D13F2014
            '            f.CallFromFormID = "D13F2012"
            '            f.PayrollVoucherID = gsPayRollVoucherID ' _payrollVoucherID
            '            f.ShowDialog()
            '            f.Dispose()
        End If
        '        If D99C0007.GetOthersSetting(EXEMODULE, "D13E0140", "SavedOK", "0").ToString = "1" Then
        '            .bSaved = True
        '        End If
        '
        '        If .bSaved Then
        '            LoadTDBGrid(True)
        '            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        '        End If
    End Sub

    Private Sub mnuOpenMultiExtraSalaryFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuOpenMultiExtraSalaryFile.Click
        'Mở HSL phụ hàng loạt
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D09F2050")
        SetProperties(arrPro, "ModuleID", D13)
        SetProperties(arrPro, "Mode", 2)
        SetProperties(arrPro, "Voucher01ID", gsPayRollVoucherID)
        SetProperties(arrPro, "Key01", "")
        SetProperties(arrPro, "Key02", "C_D13F2012")
        SetProperties(arrPro, "Key03", "F_EmployeeID")
        SetProperties(arrPro, "Key04", "F_EmployeeID")
        SetProperties(arrPro, "Key05", "")
        SetProperties(arrPro, "ShowEmpStopWork", True)
        ' Hiện tại thấy D09 ko nhận formstate
        Dim frm As Form = CallFormShowDialog("D09D2040", "D09F5605", arrPro)

        If L3Bool(GetProperties(frm, "bSaved")) Then
            Dim arrPro2() As StructureProperties = Nothing
            SetProperties(arrPro2, "ParentFormID", "D13F2012")
            'SetProperties(arrPro, "PayrollVoucherID", gsPayRollVoucherID) ' Biến chung D13
            Dim frm2 As Form = CallFormShowDialog("D13D0140", "D13F2014", arrPro2)
            If L3Bool(GetProperties(frm2, "bSaved")) Then
                LoadTDBGrid(True)
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
        End If

        '        Dim f As New D09F5605
        '        With f
        '            .FormActive = D09E2040Form.D09F5605
        '            .FormPermission = "D09F2050"
        '            .ModuleID = "D13"
        '            .Mode = 2
        '            .Voucher01ID = gsPayRollVoucherID ' sp _payrollVoucherID
        '            .Key01ID = ""
        '            .Key02ID = "C_D13F2012"
        '            .Key03ID = "F_EmployeeID"
        '            .Key04ID = "F_EmployeeID" 'Update 07/05/2012 incident 48507
        '            .Key05ID = ""
        '            .ShowEmpStopWork = "1"
        '            .ShowDialog()
        '            .Dispose()
        '        End With

        '        If CBool(D99C0007.GetOthersSetting("D09", "D09E2040", "ButtonChoose", "False")) Then
        '            Dim frm As New D13F2014
        '            With frm
        '                .CallFromFormID = "D13F2012"
        '                .PayrollVoucherID = gsPayRollVoucherID ' _payrollVoucherID
        '                .ShowDialog()
        '                .Dispose()
        '            End With
        '        End If
        '
        '        'update 3/10/2012 id 51658
        '        If D99C0007.GetOthersSetting(EXEMODULE, "D13E0140", "SavedOK", "0").ToString = "1" Then
        '            .bSaved = True
        '        End If
        '
        '        If .bSaved Then
        '            LoadTDBGrid(True)
        '            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        '        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 25/02/2009 11:01:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "DELETE FROM D91T9009" & vbCrLf
        sSQL &= "WHERE HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND UserID = " & SQLString(gsUserID)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: DUCTRONG
    '# Created Date: 25/02/2009 11:02:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If tdbg.SelectedRows.Count = 0 Then
            sSQL.Append("Insert Into D91T9009(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("Key04ID, Key05ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_TransID).Text) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("D13F2012") & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("")) 'Key05ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Else
            For i As Integer = 0 To tdbg.SelectedRows.Count - 1
                If Not CBool(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_IsSub).ToString) Then
                    sSQL.Append("Insert Into D91T9009(")
                    sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
                    sSQL.Append("Key04ID, Key05ID")
                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_TransID).ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("D13F2012") & COMMA) 'Key02ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Key03ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_EmployeeID).ToString) & COMMA) 'Key04ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("")) 'Key05ID, varchar[250], NOT NULL
                    sSQL.Append(")")

                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)
                End If
            Next
        End If
        Return sRet
    End Function

    Private Function SQLInsertD91T9009s_B() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder


        If tdbg.SelectedRows.Count = 0 Then
            sSQL.Append("Insert Into D91T9009(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("Key04ID, Key05ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2012") & COMMA)      'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg.Columns(COL_TransID).Text) & COMMA) 'Key03ID, varchar[250], NOT NULL

            sSQL.Append(SQLString("") & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("")) 'Key05ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Else
            For i As Integer = 0 To tdbg.SelectedRows.Count - 1
                If Not CBool(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_IsSub).ToString) Then
                    sSQL.Append("Insert Into D91T9009(")
                    sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
                    sSQL.Append("Key04ID, Key05ID")
                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                    sSQL.Append(SQLString("D13F2012") & COMMA) 'Key01ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_EmployeeID).ToString) & COMMA) 'Key02ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString(tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_TransID).ToString) & COMMA) 'Key03ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Key04ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("")) 'Key05ID, varchar[250], NOT NULL
                    sSQL.Append(")")

                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)
                End If
            Next
        End If
        sRet.Append(vbCrLf)
        Return sRet
    End Function

    Private Sub tdbg_InputDate()
        For i As Integer = 0 To 3
            InputDateInTrueDBGrid(tdbg, COL_BaseSalary01DateEnd + i)
            InputDateInTrueDBGrid(tdbg, COL_BaseSalary01NextDate + i)
        Next
        For i As Integer = 0 To 19
            InputDateInTrueDBGrid(tdbg, COL_Sal01DateEnd + i)
            InputDateInTrueDBGrid(tdbg, COL_Sal01NextDate + i)
        Next

        InputDateInTrueDBGrid(tdbg, COL_ValidDateFrom, COL_ValidDateTo, COL_DateLeft, COL_DateJoined, COL_OffSa1DateEnd, COL_OffSa1NextDate, COL_OffSa2DateEnd, COL_OffSa2NextDate)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BASE01).NumberFormat = Format(tdbg.Columns(COL_BASE01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COL_BASE02).NumberFormat = Format(tdbg.Columns(COL_BASE02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COL_BASE03).NumberFormat = Format(tdbg.Columns(COL_BASE03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COL_BASE04).NumberFormat = Format(tdbg.Columns(COL_BASE04).Text, D13FormatSalary.BASE04)

        tdbg.Columns(COL_NextBaseSalary01).NumberFormat = Format(tdbg.Columns(COL_NextBaseSalary01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COL_NextBaseSalary02).NumberFormat = Format(tdbg.Columns(COL_NextBaseSalary02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COL_NextBaseSalary03).NumberFormat = Format(tdbg.Columns(COL_NextBaseSalary03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COL_NextBaseSalary04).NumberFormat = Format(tdbg.Columns(COL_NextBaseSalary04).Text, D13FormatSalary.BASE04)

        tdbg.Columns(COL_CE01).NumberFormat = Format(tdbg.Columns(COL_CE01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COL_CE02).NumberFormat = Format(tdbg.Columns(COL_CE02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COL_CE03).NumberFormat = Format(tdbg.Columns(COL_CE03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COL_CE04).NumberFormat = Format(tdbg.Columns(COL_CE04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COL_CE05).NumberFormat = Format(tdbg.Columns(COL_CE05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COL_CE06).NumberFormat = Format(tdbg.Columns(COL_CE06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COL_CE07).NumberFormat = Format(tdbg.Columns(COL_CE07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COL_CE08).NumberFormat = Format(tdbg.Columns(COL_CE08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COL_CE09).NumberFormat = Format(tdbg.Columns(COL_CE09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COL_CE10).NumberFormat = Format(tdbg.Columns(COL_CE10).Text, D13FormatSalary.CE10)
        'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
        tdbg.Columns(COL_CE11).NumberFormat = Format(tdbg.Columns(COL_CE01).Text, D13FormatSalary.CE11)
        tdbg.Columns(COL_CE12).NumberFormat = Format(tdbg.Columns(COL_CE02).Text, D13FormatSalary.CE12)
        tdbg.Columns(COL_CE13).NumberFormat = Format(tdbg.Columns(COL_CE03).Text, D13FormatSalary.CE13)
        tdbg.Columns(COL_CE14).NumberFormat = Format(tdbg.Columns(COL_CE04).Text, D13FormatSalary.CE14)
        tdbg.Columns(COL_CE15).NumberFormat = Format(tdbg.Columns(COL_CE05).Text, D13FormatSalary.CE15)
        tdbg.Columns(COL_CE16).NumberFormat = Format(tdbg.Columns(COL_CE06).Text, D13FormatSalary.CE16)
        tdbg.Columns(COL_CE17).NumberFormat = Format(tdbg.Columns(COL_CE07).Text, D13FormatSalary.CE17)
        tdbg.Columns(COL_CE18).NumberFormat = Format(tdbg.Columns(COL_CE08).Text, D13FormatSalary.CE18)
        tdbg.Columns(COL_CE19).NumberFormat = Format(tdbg.Columns(COL_CE09).Text, D13FormatSalary.CE19)
        tdbg.Columns(COL_CE20).NumberFormat = Format(tdbg.Columns(COL_CE10).Text, D13FormatSalary.CE20)

        tdbg.Columns(COL_INC01).NumberFormat = Format(tdbg.Columns(COL_INC01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC02).NumberFormat = Format(tdbg.Columns(COL_INC02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC03).NumberFormat = Format(tdbg.Columns(COL_INC03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC04).NumberFormat = Format(tdbg.Columns(COL_INC04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC05).NumberFormat = Format(tdbg.Columns(COL_INC05).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC06).NumberFormat = Format(tdbg.Columns(COL_INC06).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC07).NumberFormat = Format(tdbg.Columns(COL_INC07).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC08).NumberFormat = Format(tdbg.Columns(COL_INC08).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC09).NumberFormat = Format(tdbg.Columns(COL_INC09).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC10).NumberFormat = Format(tdbg.Columns(COL_INC10).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC11).NumberFormat = Format(tdbg.Columns(COL_INC11).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC12).NumberFormat = Format(tdbg.Columns(COL_INC12).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC13).NumberFormat = Format(tdbg.Columns(COL_INC13).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC14).NumberFormat = Format(tdbg.Columns(COL_INC14).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC15).NumberFormat = Format(tdbg.Columns(COL_INC15).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC16).NumberFormat = Format(tdbg.Columns(COL_INC16).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC17).NumberFormat = Format(tdbg.Columns(COL_INC17).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC18).NumberFormat = Format(tdbg.Columns(COL_INC18).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC19).NumberFormat = Format(tdbg.Columns(COL_INC19).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC20).NumberFormat = Format(tdbg.Columns(COL_INC20).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC21).NumberFormat = Format(tdbg.Columns(COL_INC21).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC22).NumberFormat = Format(tdbg.Columns(COL_INC22).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC23).NumberFormat = Format(tdbg.Columns(COL_INC23).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC24).NumberFormat = Format(tdbg.Columns(COL_INC24).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC25).NumberFormat = Format(tdbg.Columns(COL_INC25).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC26).NumberFormat = Format(tdbg.Columns(COL_INC26).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC27).NumberFormat = Format(tdbg.Columns(COL_INC27).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC28).NumberFormat = Format(tdbg.Columns(COL_INC28).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC29).NumberFormat = Format(tdbg.Columns(COL_INC29).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_INC30).NumberFormat = Format(tdbg.Columns(COL_INC30).Text, D13Format.DefaultNumber2)

        tdbg.Columns(COL_NextSalCoefficient01).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COL_NextSalCoefficient02).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COL_NextSalCoefficient03).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COL_NextSalCoefficient04).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COL_NextSalCoefficient05).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COL_NextSalCoefficient06).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COL_NextSalCoefficient07).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COL_NextSalCoefficient08).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COL_NextSalCoefficient09).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COL_NextSalCoefficient10).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient10).Text, D13FormatSalary.CE10)
        tdbg.Columns(COL_NextSalCoefficient11).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient11).Text, D13FormatSalary.CE11)
        tdbg.Columns(COL_NextSalCoefficient12).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient12).Text, D13FormatSalary.CE12)
        tdbg.Columns(COL_NextSalCoefficient13).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient13).Text, D13FormatSalary.CE13)
        tdbg.Columns(COL_NextSalCoefficient14).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient14).Text, D13FormatSalary.CE14)
        tdbg.Columns(COL_NextSalCoefficient15).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient15).Text, D13FormatSalary.CE15)
        tdbg.Columns(COL_NextSalCoefficient16).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient16).Text, D13FormatSalary.CE16)
        tdbg.Columns(COL_NextSalCoefficient17).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient17).Text, D13FormatSalary.CE17)
        tdbg.Columns(COL_NextSalCoefficient18).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient18).Text, D13FormatSalary.CE18)
        tdbg.Columns(COL_NextSalCoefficient19).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient19).Text, D13FormatSalary.CE19)
        tdbg.Columns(COL_NextSalCoefficient20).NumberFormat = Format(tdbg.Columns(COL_NextSalCoefficient20).Text, D13FormatSalary.CE20)

        tdbg.Columns(COL_SaCoefficient).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient).Text, D13FormatSalary.OLSC11)
        tdbg.Columns(COL_SaCoefficient12).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient12).Text, D13FormatSalary.OLSC12)
        tdbg.Columns(COL_SaCoefficient13).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient13).Text, D13FormatSalary.OLSC13)
        tdbg.Columns(COL_SaCoefficient14).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient14).Text, D13FormatSalary.OLSC14)
        tdbg.Columns(COL_SaCoefficient15).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient15).Text, D13FormatSalary.OLSC15)
        tdbg.Columns(COL_SaCoefficient2).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient2).Text, D13FormatSalary.OLSC21)
        tdbg.Columns(COL_SaCoefficient22).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient22).Text, D13FormatSalary.OLSC22)
        tdbg.Columns(COL_SaCoefficient23).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient23).Text, D13FormatSalary.OLSC23)
        tdbg.Columns(COL_SaCoefficient24).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient24).Text, D13FormatSalary.OLSC24)
        tdbg.Columns(COL_SaCoefficient25).NumberFormat = Format(tdbg.Columns(COL_SaCoefficient25).Text, D13FormatSalary.OLSC25)

        For i As Integer = COL_DutyRef01 To COL_DutyRef05
            tdbg.Columns(i).NumberFormat = D13Format.DefaultNumber2
        Next

        For i As Integer = COL_NumRef01 To COL_NumRef10
            tdbg.Columns(i).NumberFormat = D13Format.DefaultNumber2
        Next
    End Sub

    Private Sub tdbgRelative_NumberFormat()
        tdbgRelative.Columns(COL1_Salary).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub tdbgBankID_LockedColumns()
        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BranchName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Function DataFieldName() As String
        Dim sDataField As String
        Dim sNum As String
        sDataField = tdbg.Columns(tdbg.Col).DataField.Substring(0, 2)
        If sDataField.ToUpper = "BA" Then
            sDataField = "BaseSalary"
            sNum = tdbg.Columns(tdbg.Col).DataField.Substring(4, 2)
            sDataField = sDataField & sNum
        ElseIf sDataField.ToUpper = "CE" Then
            sDataField = "SalCoefficient"
            sNum = tdbg.Columns(tdbg.Col).DataField.Substring(2, 2)
            sDataField = sDataField & sNum
        End If
        Return sDataField
    End Function

#Region "Active Find Client - List All "

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
            ReLoadTDBGrid()
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        '  ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '        If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClauseClient.ToString()
    '        sFindServer = ResultWhereClauseServer.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
      
        dtFind.DefaultView.RowFilter = strFind
        LoadTDBGridRelative()
        LoadTDBGridBankID()
        ResetGrid()
        SetPaymentMethod() '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
    End Sub

#End Region

    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg, COL_FullName)

        FootTextColumns(COL_BASE01, D13FormatSalary.BASE01)
        FootTextColumns(COL_BASE02, D13FormatSalary.BASE02)
        FootTextColumns(COL_BASE03, D13FormatSalary.BASE03)
        FootTextColumns(COL_BASE04, D13FormatSalary.BASE04)

        FootTextColumns(COL_CE01, D13FormatSalary.CE01)
        FootTextColumns(COL_CE02, D13FormatSalary.CE02)
        FootTextColumns(COL_CE03, D13FormatSalary.CE03)
        FootTextColumns(COL_CE04, D13FormatSalary.CE04)
        FootTextColumns(COL_CE05, D13FormatSalary.CE05)
        FootTextColumns(COL_CE06, D13FormatSalary.CE06)
        FootTextColumns(COL_CE07, D13FormatSalary.CE07)
        FootTextColumns(COL_CE08, D13FormatSalary.CE08)
        FootTextColumns(COL_CE09, D13FormatSalary.CE09)
        FootTextColumns(COL_CE10, D13FormatSalary.CE10)
        FootTextColumns(COL_CE11, D13FormatSalary.CE11) 'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
        FootTextColumns(COL_CE12, D13FormatSalary.CE12)
        FootTextColumns(COL_CE13, D13FormatSalary.CE13)
        FootTextColumns(COL_CE14, D13FormatSalary.CE14)
        FootTextColumns(COL_CE15, D13FormatSalary.CE15)
        FootTextColumns(COL_CE16, D13FormatSalary.CE16)
        FootTextColumns(COL_CE17, D13FormatSalary.CE17)
        FootTextColumns(COL_CE18, D13FormatSalary.CE18)
        FootTextColumns(COL_CE19, D13FormatSalary.CE19)
        FootTextColumns(COL_CE20, D13FormatSalary.CE20)


        FootTextColumns(COL_SaCoefficient, D13FormatSalary.OLSC11)
        FootTextColumns(COL_SaCoefficient12, D13FormatSalary.OLSC12)
        FootTextColumns(COL_SaCoefficient13, D13FormatSalary.OLSC13)
        FootTextColumns(COL_SaCoefficient14, D13FormatSalary.OLSC14)
        FootTextColumns(COL_SaCoefficient15, D13FormatSalary.OLSC15)
        FootTextColumns(COL_SaCoefficient2, D13FormatSalary.OLSC21)
        FootTextColumns(COL_SaCoefficient22, D13FormatSalary.OLSC22)
        FootTextColumns(COL_SaCoefficient23, D13FormatSalary.OLSC23)
        FootTextColumns(COL_SaCoefficient24, D13FormatSalary.OLSC24)
        FootTextColumns(COL_SaCoefficient25, D13FormatSalary.OLSC25)

        For i As Integer = COL_INC01 To COL_INC30
            FootTextColumns(i, D13Format.DefaultNumber2)
        Next

        For i As Integer = COL_NumRef01 To COL_NumRef10
            FootTextColumns(i, D13Format.DefaultNumber2)
        Next
    End Sub

    Dim arrFooterSum() As Integer = {COL_BASE01, COL_BASE02, COL_BASE03, COL_BASE04, COL_CE01, COL_CE02, COL_CE03, COL_CE04, COL_CE05, COL_CE06, COL_CE07, COL_CE08, COL_CE09, COL_CE10, _
    COL_CE11, COL_CE12, COL_CE13, COL_CE14, COL_CE15, COL_CE16, COL_CE17, COL_CE18, COL_CE19, COL_CE20, _
COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15, COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25}

    Private Sub FootTextColumns(ByVal iCol As Integer, ByVal sNumberFormat As String)
        Dim Sum As Double = 0
        For j As Int32 = 0 To tdbg.RowCount - 1
            Sum += Number(SQLNumber(tdbg(j, iCol).ToString, sNumberFormat))
        Next
        tdbg.Columns(iCol).FooterText = SQLNumber(Sum.ToString, sNumberFormat)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 13/07/2009 08:32:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009(ByVal sDepartmentID As String, ByVal sTeamID As String, ByVal sEmployeeID As String, ByVal sTransID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
        sSQL.Append("Key04ID, Key05ID, Key06ID, Key07ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString("D13F2012") & COMMA) 'Key02ID, varchar[250], NULL
        sSQL.Append(SQLString(sEmployeeID) & COMMA) 'Key03ID, varchar[250], NULL
        sSQL.Append(SQLString(gsPayRollVoucherID) & COMMA) 'Key04ID, varchar[250], NULL
        sSQL.Append(SQLString(sDepartmentID) & COMMA) 'Key05ID, varchar[250], NULL
        sSQL.Append(SQLString(sTeamID) & COMMA) 'Key06ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(sTransID))
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0102
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 13/07/2009 10:30:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0102(ByVal iMode As Integer, Optional ByVal bMultiEdit As Boolean = False) As String
        Dim sSQL As String = ""
        If bMultiEdit Then ' update 15/4/2013 id 55205 - Kiem tra truoc khi sua hang loat (@EmployeeID = '',@TransID = '')
            sSQL &= "Exec D13P0102 "
            sSQL &= SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[8000], NOT NULL
            sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
            sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
            sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
            sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
            sSQL &= SQLString("") 'TransID, varchar[20], NOT NULL
        Else
            sSQL &= "Exec D13P0102 "
            sSQL &= SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[8000], NOT NULL
            sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
            sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
            sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
            sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_TransID).Text) 'TransID, varchar[20], NOT NULL
        End If

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD29P2082
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 12/10/2009 02:38:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD29P2082() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D29P2082 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        ' 28/5/2014 id 65377 - Theo chi Thuận truyền cố định là D13F2012 (do chị còn 1 đường dẫn gọi _path='04')
        sSQL &= SQLString("D13F2010") ' sSQL &= SQLString(sFormPermisson) 'FormID, varchar[10], NOT NULL
        Return sSQL
    End Function

    Private Sub btnCalStandardWorkDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalStandardWorkDay.Click
        If ExecuteSQL(SQLStoreD29P2082) Then
            D99C0008.MsgL3(rL3("Du_lieu_da_duoc_tinh_thanh_cong"))
            LoadTDBGrid() 'ComboValue(tdbcDepartmentID)
        End If
    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        ' CreateTableExcel() ' Bị nháy màn hình nên PCHK không chịu 12/11/2015
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Chuẩn hóa D09U1111 B7: Xuất Excel
        For i As Integer = COL_INC01 To COL_INC30
            ReDim Preserve arrFooterSum(UBound(arrFooterSum) + 1)
            arrFooterSum(UBound(arrFooterSum)) = i
        Next
        '	Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        '  CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtFind, gsGroupColumns)
        CallShowD99F2222(Me, dtCaptionCols, dtFind, gsGroupColumns)


    End Sub

    Private Sub mnuImportBankInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportBankInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If CallShowDialogD80F2090(D13, "D13F1030", "D13F1030A") Then
            'Load lại dữ liệu   
            LoadTDBGrid(True)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuImportImfoRef_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportImfoRef.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If CallShowDialogD80F2090(D13, "D13F5613", "D13F2012") Then
            'Load lại dữ liệu   
            LoadTDBGrid(True)
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If btnFilter.Enabled = False Then Exit Sub
        If AllowFilter() = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        If sender Is Nothing Then
            btnFilter.Focus()
            If btnFilter.Focused = False Then Me.Cursor = Cursors.Default : Exit Sub
        End If
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcEmpGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nhom_nhan_vien"))
            tdbcEmpGroupID.Focus()
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2017
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 24/08/2011 09:06:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2017() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2017 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Dim bAddEnabled As Boolean = False
    Dim bEditEnabled As Boolean = False
    Dim bDeleteEnabled As Boolean = False

    Private Sub CheckPermissionColGrid()
        'Update 27/02/2012: Incident 43634 Kiểm tra thêm cột quyền trên lưới cho các menu
        Dim iPer As Byte = L3Byte(tdbg.Columns(COL_Permission).Text)
        If tdbg.RowCount > 0 Then
            mnuAdd.Enabled = bAddEnabled And (iPer >= 2)
        End If
        If _path <> "01" Then
            mnuOpenExtraSalaryFile.Enabled = bAddEnabled And (iPer >= 2)
            mnuOpenMultiExtraSalaryFile.Enabled = mnuOpenExtraSalaryFile.Enabled
            btnCalStandardWorkDay.Enabled = mnuOpenExtraSalaryFile.Enabled
        End If

        mnuEdit.Enabled = bEditEnabled And (iPer >= 3)
        mnuDelete.Enabled = bDeleteEnabled And (iPer > 3)

    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.Row = e.LastRow Then Exit Sub
        CheckPermissionColGrid()
        LoadTDBGridRelative()
        LoadTDBGridBankID()
        SetPaymentMethod() '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
    End Sub

    ' Update 21/8/2012 incident 50602
    Private Sub HideButtonAnalyseSalary()
        '        btnAnalyseSalary.Visible = False
        '        btnAnalyseCode.Left = btnIncome.Left - btnAnalyseCode.Width - 6
        '        btnSalaryLevelOfficialTitle.Left = btnAnalyseCode.Left - btnSalaryLevelOfficialTitle.Width - 6
        '        btnSalaryCoefficientBase.Left = btnSalaryLevelOfficialTitle.Left - btnSalaryCoefficientBase.Width - 6
        '
        '        ' update lại số thứ tự
        '        btnIncome.Text = "4" & btnIncome.Text.Substring(1)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 15/04/2013 11:21:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " WHERE UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID= " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID= 'D13F2012'"

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 15/04/2013 11:23:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert bang tam" & vbCrLf)
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString("D13F2012") & COMMA) 'FormID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg.Columns(COL_TransID).Text) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(tdbg.Columns(COL_EmployeeID).Text)) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1502
    '# Created User: Hoàng Nhân
    '# Created Date: 09/09/2013 09:39:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1502() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi giam tru gia canh" & vbCrLf)
        sSQL &= "Exec D13P1502 "
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0202
    '# Created User: Hoàng Nhân
    '# Created Date: 14/08/2013 09:28:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0202() As String
        Dim dtEmp As DataTable = ReturnTableFilter(dtGridBankID, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID") ' Sửa theo ID 79212  - không xóa theo 

        Dim sSQL As String = ""
        If dtEmp.Rows.Count > 0 Then sSQL = "-- Delete luoi Ngan hang truoc khi insert" & vbCrLf
        For i As Integer = 0 To dtEmp.Rows.Count - 1
            sSQL &= "Delete From D13T0202"
            sSQL &= " Where EmployeeID = " & SQLString(dtEmp.Rows(i).Item("EmployeeID"))
        Next

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0202
    '# Created User: Hoàng Nhân
    '# Created Date: 18/10/2014 12:13:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0202(ByVal sEmployeeID As String, ByVal sBankID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa dong tren luoi Ngan hang" & vbCrLf)
        sSQL &= "Delete From D13T0202"
        sSQL &= " Where  EmployeeID = " & SQLString(sEmployeeID)
        sSQL &= " AND BankID = " & SQLString(sBankID) & vbCrLf
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0202s
    '# Created User: Hoàng Nhân
    '# Created Date: 14/08/2013 09:29:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0202s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim dtEmp As DataTable = ReturnTableFilter(dtGridBankID, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID")

        For i As Integer = 0 To dtEmp.Rows.Count - 1
            Dim dr() As DataRow = dtGridBankID.Select("IsUpdate = 1 And EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID").ToString))
            For j As Integer = 0 To dr.Length - 1
                If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert luoi ngan hang" & vbCrLf)
                sSQL.Append("Insert Into D13T0202(")
                sSQL.Append("EmployeeID, BankID, BankAccountNo, BankAccountNoU, AccountHolderName, ")
                sSQL.Append("AccountHolderNameU, ExchangeDep, ExchangeDepU, IsDefault")
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(dr(j).Item("EmployeeID")) & COMMA) 'EmployeeID, varchar[50], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("BankID")) & COMMA) 'BankID, varchar[50], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("BankAccountNo")) & COMMA) 'BankAccountNo, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("BankAccountNo"), gbUnicode, True) & COMMA) 'BankAccountNoU, nvarchar[100], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("AccountHolderName"), gbUnicode, False) & COMMA) 'AccountHolderName, varchar[500], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("AccountHolderName"), gbUnicode, True) & COMMA) 'AccountHolderNameU, nvarchar[500], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("ExchangeDep"), gbUnicode, False) & COMMA) 'ExchangeDep, varchar[500], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("ExchangeDep"), gbUnicode, True) & COMMA) 'ExchangeDepU, nvarchar[500], NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("IsDefault"))) 'IsDefault, tinyint, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        Next

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0216
    '# Created User: DUCTRONG
    '# Created Date: 25/11/2008 03:47:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0216() As String
        Dim sSQL As String = ""
        Dim dtEmp As DataTable = ReturnTableFilter(dtGridRelative, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID", "RelativeID")

        If dtEmp.Rows.Count > 0 Then sSQL = "-- Delete luoi Giam tru gia canh truoc khi insert" & vbCrLf

        For i As Integer = 0 To dtEmp.Rows.Count - 1
            sSQL &= "Delete From D13T0216 "
            sSQL &= "Where "
            sSQL &= "EmployeeID = " & SQLString(dtEmp.Rows(i).Item("EmployeeID")) & vbCrLf
            sSQL &= " AND RelativeID = " & SQLString(dtEmp.Rows(i).Item("RelativeID")) & vbCrLf
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0216
    '# Created User: Hoàng Nhân
    '# Created Date: 18/10/2014 12:46:16
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0216(ByVal sEmployeeID As String, ByVal sRelativeID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa dong tren luoi Giam tru gia canh " & vbCrLf)
        sSQL &= "Delete From D13T0216"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(sEmployeeID) & vbCrLf
        sSQL &= " AND RelativeID = " & SQLString(sRelativeID) & vbCrLf
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0216s
    '# Created User: DUCTRONG
    '# Created Date: 25/11/2008 03:47:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0216s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim iCountIGE As Int32 = 0
        Dim sRelativeID As String = ""

        Dim dtEmp As DataTable = ReturnTableFilter(dtGridRelative, "IsUpdate = 1", True)
        dtEmp = dtEmp.DefaultView.ToTable(True, "EmployeeID")

        For i As Integer = 0 To dtGridRelative.Rows.Count - 1
            If dtGridRelative.Rows(i).Item("RelativeID").ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To dtEmp.Rows.Count - 1
            Dim dr() As DataRow = dtGridRelative.Select("IsUpdate = 1 And EmployeeID=" & SQLString(dtEmp.Rows(i).Item("EmployeeID").ToString))

            For j As Integer = 0 To dr.Length - 1
                If dr(j).Item("RelativeID").ToString = "" Then
                    sRelativeID = CreateIGEs("D13T0216", "RelativeID", "13", "DE", gsStringKey, sRelativeID, iCountIGE)
                    dr(j).Item("RelativeID") = sRelativeID
                End If
                If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert luoi Giam tru gia canh" & vbCrLf)

                sSQL.Append("Insert Into D13T0216(")
                sSQL.Append("RelativeID, EmployeeID, RelationID, RelationName, RelationNameU, RelativeName, RelativeNameU, ")
                sSQL.Append("BirthPlace, BirthPlaceU, Address, AddressU, Occupation, OccupationU, EducationLevelID, Sex, InComeTaxCode, IDCardNo, ")
                sSQL.Append("Salary, DeductibleDateBegin, DeductibleDateEnd, DeductibleAmount, Disabled, ")
                sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, ")
                sSQL.Append("Note, NoteU, BirthCertificate, ")
                sSQL.Append("ResidentCertificate, MarriageCertificate, SchoolConfirmation, DisabilityConfirmation, BringUpConfirmation, ")
                sSQL.Append("OtherConfirmations, NoteConfirmation, NoteConfirmationU, BirthDate, UndefinedBirthDate, ExamineDate, ")
                sSQL.Append("CountryTypeID, NumBirthCertificateU, BookBirthCertificateU,ConAddressProvinceID, ConAddressDistrictID, ConAddressWardID, ConAddressStreetU")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(dr(j).Item("RelativeID")) & COMMA) 'RelativeID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("EmployeeID")) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("RelationID")) & COMMA) 'RelationID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("RelationName").ToString, gbUnicode, False) & COMMA) 'RelationName, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("RelationName").ToString, gbUnicode, True) & COMMA) 'RelationName, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("RelativeName").ToString, gbUnicode, False) & COMMA) 'RelativeName, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("RelativeName").ToString, gbUnicode, True) & COMMA) 'RelativeName, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("BirthPlace").ToString, gbUnicode, False) & COMMA) 'BirthPlace, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("BirthPlace").ToString, gbUnicode, True) & COMMA) 'BirthPlace, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Address").ToString, gbUnicode, False) & COMMA) 'Address, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Address").ToString, gbUnicode, True) & COMMA) 'Address, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Occupation").ToString, gbUnicode, False) & COMMA) 'Occupation, varchar[100], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Occupation").ToString, gbUnicode, True) & COMMA) 'Occupation, varchar[100], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("EducationLevelID")) & COMMA) 'EducationLevelID, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("Sex")) & COMMA) 'Sex, tinyint, NOT NULL
                sSQL.Append(SQLString(dr(j).Item("InComeTaxCode")) & COMMA) 'IncomeTaxCode, varchar[50], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("IDCardNo")) & COMMA) 'IDCardNo, varchar[50], NOT NULL
                sSQL.Append(SQLMoney(dr(j).Item("Salary"), D13Format.DefaultNumber2) & COMMA) 'Salary, money, NOT NULL
                sSQL.Append(SQLDateSave(dr(j).Item("DeductibleDateBegin")) & COMMA) 'DeductibleDateBegin, datetime, NULL
                sSQL.Append(SQLDateSave(dr(j).Item("DeductibleDateEnd")) & COMMA) 'DeductibleDateEnd, datetime, NULL
                sSQL.Append(SQLMoney(dr(j).Item("DeductibleAmount"), D13Format.DefaultNumber2) & COMMA) 'DeductibleAmount, money, NOT NULL
                sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Note"), gbUnicode, False) & COMMA) 'Note, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("Note"), gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("BirthCertificate")) & COMMA) 'BirthCertificate, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("ResidentCertificate")) & COMMA) 'ResidentCertificate, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("MarriageCertificate")) & COMMA) 'MarriageCertificate, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("SchoolConfirmation")) & COMMA) 'SchoolConfirmation, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("DisabilityConfirmation")) & COMMA) 'DisabilityConfirmation, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("BringUpConfirmation")) & COMMA) 'BringUpConfirmation, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dr(j).Item("OtherConfirmations")) & COMMA) 'OtherConfirmations, tinyint, NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("NoteConfirmation"), gbUnicode, False) & COMMA) 'NoteConfirmation, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("NoteConfirmation"), gbUnicode, True) & COMMA) 'NoteConfirmationU, nvarchar, NOT NULL
                '************************
                Dim iUndefinedBirthDate As Byte = L3Byte(dr(j).Item("UndefinedBirthDate"))
                Dim sBirthDate As String = ReturnBirthDate(iUndefinedBirthDate, dr(j).Item("DBirthDate").ToString, dr(j).Item("MBirthDate").ToString, dr(j).Item("YBirthDate").ToString)
                sSQL.Append(SQLString(sBirthDate) & COMMA) 'BirthDate, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(iUndefinedBirthDate) & COMMA) 'UndefinedBirthDate, tinyint, NOT NULL
                '************************
                sSQL.Append(SQLDateSave(dr(j).Item("ExamineDate")) & COMMA) ' update 9/9/2013 id 56751
                sSQL.Append(SQLString(dr(j).Item("CountryTypeID")) & COMMA) 'CountryTypeID, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("NumBirthCertificate"), gbUnicode, True) & COMMA) 'NumBirthCertificateU, nvarchar[1000], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("BookBirthCertificate"), gbUnicode, True) & COMMA) 'BookBirthCertificateU, nvarchar[1000], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("ConAddressProvinceID")) & COMMA) 'ConAddressProvinceID, varchar[50], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("ConAddressDistrictID")) & COMMA) 'ConAddressDistrictID, varchar[50], NOT NULL
                sSQL.Append(SQLString(dr(j).Item("ConAddressWardID")) & COMMA) 'ConAddressWardID, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(dr(j).Item("ConAddressStreet"), gbUnicode, True)) 'ConAddressStreetU, nvarchar[1000], NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0101
    '# Created User: 
    '# Created Date: 20/05/2015 10:27:41
    '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0101() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu ho so luong thang " & vbCrLf)
        sSQL.Append("Update D13T0101 Set ")
        If optPaymentMethod_C.Checked Then
            sSQL.Append("PaymentMethod = 'C' ") 'varchar[1], NOT NULL
        ElseIf optPaymentMethod_B.Checked Then
            sSQL.Append("PaymentMethod = 'B' ") 'varchar[1], NOT NULL
        ElseIf optPaymentMethod_O.Checked Then
            sSQL.Append("PaymentMethod = 'O' ") 'varchar[1], NOT NULL
        End If
        sSQL.Append(" Where TransID = " & SQLString(tdbg.Columns(COL_TransID).Text) & " AND DivisionID = " & SQLString(gsDivisionID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201
    '# Created User: 
    '# Created Date: 20/05/2015 10:33:04
    '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu ho so luong goc khi Ky lon nhat " & vbCrLf)
        sSQL.Append("Update D13T0201 Set ")
        If optPaymentMethod_C.Checked Then
            sSQL.Append("PaymentMethod = 'C' ") 'varchar[1], NOT NULL
        ElseIf optPaymentMethod_B.Checked Then
            sSQL.Append("PaymentMethod = 'B' ") 'varchar[1], NOT NULL
        ElseIf optPaymentMethod_O.Checked Then
            sSQL.Append("PaymentMethod = 'O' ") 'varchar[1], NOT NULL
        End If
        sSQL.Append(" Where EmployeeID = " & SQLString(tdbg.Columns(COL_EmployeeID).Text) & " AND DivisionID = " & SQLString(gsDivisionID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P1509
    '# Created User: Lê Anh Vũ
    '# Created Date: 06/06/2016 10:02:43
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P1509() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon tinh, quan huyen, xa phuong" & vbCrLf)
        sSQL &= "Exec D09P1509 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[250], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function
    Private Sub btnPasswordSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasswordSetting.Click
        Dim frm As New D13F2017
        Dim pControl As Point = tdbg.PointToScreen(Point.Empty)
        pControl.Y += tdbg.Height
        frm.Show(Me)
        pControl.Y -= frm.Height
        frm.Location = pControl

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/11/2014 11:31:07
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal sKey01ID As String, ByVal sKey02ID As String, ByVal sDateFrom As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra thong tin nguoi giam tru tai dong dang dung" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sKey01ID) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString(sKey02ID) & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(sDateFrom) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub CreateTableExcel(Optional ByVal bLoad As Boolean = True, Optional ByVal iMode As Object = 0)
        Dim arrMaster As New ArrayList
        Dim arrColObligatoryOld() As Integer = {COL_EmployeeID}
        If bLoad Then
            Dim arrColObligatory() As Object = {COL_EmployeeID}
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, iMode, arrColObligatory) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 1
            ClickButton(Button.SalaryCoefficientBase, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 0) 'split1
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 2
            ClickButton(Button.SalaryLevelOfficialTitle, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 1) 'split1
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            '****************************
            'Nút 3
            ClickButton(Button.NextBaseSalary, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 2) '
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 6
            ClickButton(Button.AnalyseCode, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 3) '
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 7
            ClickButton(Button.AnalyseSalary, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 4) '
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 8
            ClickButton(Button.Income, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 5) '
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            'Nút 9
            ClickButton(Button.InfoOther, True)
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, iMode, arrColObligatory, , , , 6) '
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatoryOld, , , gbUnicode)
            '-----------------------------------
            'Bật lại Nút 1 để trở về trạng thái ban đầu
            ClickButton(Button.SalaryCoefficientBase, True)
        End If
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
    End Sub
    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True, Optional ByVal iMode As Object = 0)
        CreateTableExcel(bLoad, iMode)
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, iMode)
    End Sub

    Private Sub tdbgRelative_UnboundColumnFetch(sender As Object, e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgRelative.UnboundColumnFetch
        Select Case e.Col
            Case COL1_IsCreateAddress
                e.Value = "..."
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        tdbgRelative.UpdateData()
        If tdbgRelative.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL1_ConAddressProvinceName, COL1_ConAddressDistrictName, COL1_ConAddressWardName 'ID 86460 06/06/2016
                Dim iColumns() As Integer = {COL1_ConAddressProvinceID, COL1_ConAddressProvinceName, COL1_ConAddressDistrictID, COL1_ConAddressDistrictName, COL1_ConAddressWardID, COL1_ConAddressWardName}
                CopyColumnArr(tdbgRelative, iCol, iColumns)
            Case COL1_ConAddressStreet
                CopyColumns(tdbgRelative, iCol, tdbgRelative.Columns(iCol).Text, tdbgRelative.Row)
            Case COL1_IsCreateAddress
                For i As Integer = 0 To tdbgRelative.RowCount - 1
                    CreateAddress(i)
                Next
        End Select
    End Sub

    Private Sub tdbgRelative_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    'Private Sub tdbgRelative_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgRelative.KeyDown
    '    If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbgRelative.Col)
    'End Sub

    'ID 95538 04.04.2017
    Private Sub btnUpdateReduce_Click(sender As Object, e As EventArgs) Handles btnUpdateReduce.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "EmployeeID", tdbg.Columns(COL_EmployeeID).Text)
        SetProperties(arrPro, "FormCall", Me.Name)
        SetProperties(arrPro, "FormState", 1)
        Dim frm As Form = CallFormShowDialog("D09D1040", "D09F1502", arrPro)
        Dim sKey As Boolean = L3Bool(GetProperties(frm, "bSaved"))

        If sKey Then
            sValueGridRelative = ""
            If dtGridRelative IsNot Nothing Then dtGridRelative.Clear()
            LoadTDBGridRelative()
        End If
    End Sub
End Class