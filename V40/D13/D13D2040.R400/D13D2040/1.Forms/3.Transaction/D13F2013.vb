Imports System.Windows.Forms
Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:32:55 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:32:55 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F2013
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COLS_DepartmentID As Integer = 0           ' Phòng ban
    Private Const COLS_DepartmentName As Integer = 1         ' DepartmentName
    Private Const COLS_TeamID As Integer = 2                 ' Tổ nhóm
    Private Const COLS_EmpGroupID As Integer = 3             ' Nhóm nhân viên
    Private Const COLS_TeamName As Integer = 4               ' TeamName
    Private Const COLS_EmployeeID As Integer = 5             ' Mã nhân viên
    Private Const COLS_FullName As Integer = 6               ' Họ và Tên
    Private Const COLS_IsSub As Integer = 7                  ' HSL phụ
    Private Const COLS_StandardAbsentQuan As Integer = 8     ' Ngày công chuẩn
    Private Const COLS_ValidDateFrom As Integer = 9          ' Ngày chấm công (Từ)
    Private Const COLS_ValidDateTo As Integer = 10           ' Ngày chấm công (Đến)
    Private Const COLS_SalaryRate As Integer = 11            ' Tỷ lệ hưởng lương (%)
    Private Const COLS_TaxObjectID As Integer = 12           ' Mã ĐT tính thuế 
    Private Const COLS_TaxObjectName As Integer = 13         ' Tên ĐT tính thuế
    Private Const COLS_BASE01 As Integer = 14                ' Lương cơ bản 01
    Private Const COLS_BaseCurrencyID01 As Integer = 15      ' BaseCurrencyID01
    Private Const COLS_BASE02 As Integer = 16                ' Lương cơ bản 02
    Private Const COLS_BaseCurrencyID02 As Integer = 17      ' BaseCurrencyID02
    Private Const COLS_BASE03 As Integer = 18                ' Lương cơ bản 03
    Private Const COLS_BaseCurrencyID03 As Integer = 19      ' BaseCurrencyID03
    Private Const COLS_BASE04 As Integer = 20                ' Lương cơ bản 04
    Private Const COLS_BaseCurrencyID04 As Integer = 21      ' BaseCurrencyID04
    Private Const COLS_CE01 As Integer = 22                  ' Hệ số 01
    Private Const COLS_SalCoeCurrencyID01 As Integer = 23    ' SalCoeCurrencyID01
    Private Const COLS_CE02 As Integer = 24                  ' Hệ số 02
    Private Const COLS_SalCoeCurrencyID02 As Integer = 25    ' SalCoeCurrencyID02
    Private Const COLS_CE03 As Integer = 26                  ' Hệ số 03
    Private Const COLS_SalCoeCurrencyID03 As Integer = 27    ' SalCoeCurrencyID03
    Private Const COLS_CE04 As Integer = 28                  ' Hệ số 04
    Private Const COLS_SalCoeCurrencyID04 As Integer = 29    ' SalCoeCurrencyID04
    Private Const COLS_CE05 As Integer = 30                  ' Hệ số 05
    Private Const COLS_SalCoeCurrencyID05 As Integer = 31    ' SalCoeCurrencyID05
    Private Const COLS_CE06 As Integer = 32                  ' Hệ số 06
    Private Const COLS_SalCoeCurrencyID06 As Integer = 33    ' SalCoeCurrencyID06
    Private Const COLS_CE07 As Integer = 34                  ' Hệ số 07
    Private Const COLS_SalCoeCurrencyID07 As Integer = 35    ' SalCoeCurrencyID07
    Private Const COLS_CE08 As Integer = 36                  ' Hệ số 08
    Private Const COLS_SalCoeCurrencyID08 As Integer = 37    ' SalCoeCurrencyID08
    Private Const COLS_CE09 As Integer = 38                  ' Hệ số 09
    Private Const COLS_SalCoeCurrencyID09 As Integer = 39    ' SalCoeCurrencyID09
    Private Const COLS_CE10 As Integer = 40                  ' Hệ số 10
    Private Const COLS_SalCoeCurrencyID10 As Integer = 41    ' SalCoeCurrencyID10
    Private Const COLS_CE11 As Integer = 42                  ' CE11
    Private Const COLS_SalCoeCurrencyID11 As Integer = 43    ' SalCoeCurrencyID11
    Private Const COLS_CE12 As Integer = 44                  ' CE12
    Private Const COLS_SalCoeCurrencyID12 As Integer = 45    ' SalCoeCurrencyID12
    Private Const COLS_CE13 As Integer = 46                  ' CE13
    Private Const COLS_SalCoeCurrencyID13 As Integer = 47    ' SalCoeCurrencyID13
    Private Const COLS_CE14 As Integer = 48                  ' CE14
    Private Const COLS_SalCoeCurrencyID14 As Integer = 49    ' SalCoeCurrencyID14
    Private Const COLS_CE15 As Integer = 50                  ' CE15
    Private Const COLS_SalCoeCurrencyID15 As Integer = 51    ' SalCoeCurrencyID15
    Private Const COLS_CE16 As Integer = 52                  ' CE16
    Private Const COLS_SalCoeCurrencyID16 As Integer = 53    ' SalCoeCurrencyID16
    Private Const COLS_CE17 As Integer = 54                  ' CE17
    Private Const COLS_SalCoeCurrencyID17 As Integer = 55    ' SalCoeCurrencyID17
    Private Const COLS_CE18 As Integer = 56                  ' CE18
    Private Const COLS_SalCoeCurrencyID18 As Integer = 57    ' SalCoeCurrencyID18
    Private Const COLS_CE19 As Integer = 58                  ' CE19
    Private Const COLS_SalCoeCurrencyID19 As Integer = 59    ' SalCoeCurrencyID19
    Private Const COLS_CE20 As Integer = 60                  ' CE20
    Private Const COLS_SalCoeCurrencyID20 As Integer = 61    ' SalCoeCurrencyID20
    Private Const COLS_INC01 As Integer = 62                 ' Thu nhập 01
    Private Const COLS_INC02 As Integer = 63                 ' Thu nhập 02
    Private Const COLS_INC03 As Integer = 64                 ' Thu nhập 03
    Private Const COLS_INC04 As Integer = 65                 ' Thu nhập 04
    Private Const COLS_INC05 As Integer = 66                 ' Thu nhập 05
    Private Const COLS_INC06 As Integer = 67                 ' Thu nhập 06
    Private Const COLS_INC07 As Integer = 68                 ' Thu nhập 07
    Private Const COLS_INC08 As Integer = 69                 ' Thu nhập 08
    Private Const COLS_INC09 As Integer = 70                 ' Thu nhập 09
    Private Const COLS_INC10 As Integer = 71                 ' Thu nhập 10
    Private Const COLS_INC11 As Integer = 72                 ' Thu nhập 11
    Private Const COLS_INC12 As Integer = 73                 ' Thu nhập 12
    Private Const COLS_INC13 As Integer = 74                 ' Thu nhập 13
    Private Const COLS_INC14 As Integer = 75                 ' Thu nhập 14
    Private Const COLS_INC15 As Integer = 76                 ' Thu nhập 15
    Private Const COLS_INC16 As Integer = 77                 ' Thu nhập 16
    Private Const COLS_INC17 As Integer = 78                 ' Thu nhập 17
    Private Const COLS_INC18 As Integer = 79                 ' Thu nhập 18
    Private Const COLS_INC19 As Integer = 80                 ' Thu nhập 19
    Private Const COLS_INC20 As Integer = 81                 ' Thu nhập 20
    Private Const COLS_INC21 As Integer = 82                 ' Thu nhập 21
    Private Const COLS_INC22 As Integer = 83                 ' Thu nhập 22
    Private Const COLS_INC23 As Integer = 84                 ' Thu nhập 23
    Private Const COLS_INC24 As Integer = 85                 ' Thu nhập 24
    Private Const COLS_INC25 As Integer = 86                 ' Thu nhập 25
    Private Const COLS_INC26 As Integer = 87                 ' Thu nhập 26
    Private Const COLS_INC27 As Integer = 88                 ' Thu nhập 27
    Private Const COLS_INC28 As Integer = 89                 ' Thu nhập 28
    Private Const COLS_INC29 As Integer = 90                 ' Thu nhập 29
    Private Const COLS_INC30 As Integer = 91                 ' Thu nhập 30
    Private Const COLS_N01 As Integer = 92                   ' Mã phân tích 01
    Private Const COLS_N02 As Integer = 93                   ' Mã phân tích 02
    Private Const COLS_N03 As Integer = 94                   ' Mã phân tích 03
    Private Const COLS_N04 As Integer = 95                   ' Mã phân tích 04
    Private Const COLS_N05 As Integer = 96                   ' Mã phân tích 05
    Private Const COLS_N06 As Integer = 97                   ' Mã phân tích 06
    Private Const COLS_N07 As Integer = 98                   ' Mã phân tích 07
    Private Const COLS_N08 As Integer = 99                   ' Mã phân tích 08
    Private Const COLS_N09 As Integer = 100                  ' Mã phân tích 09
    Private Const COLS_N10 As Integer = 101                  ' Mã phân tích 10
    Private Const COLS_N11 As Integer = 102                  ' Mã phân tích 11
    Private Const COLS_N12 As Integer = 103                  ' Mã phân tích 12
    Private Const COLS_N13 As Integer = 104                  ' Mã phân tích 13
    Private Const COLS_N14 As Integer = 105                  ' Mã phân tích 14
    Private Const COLS_N15 As Integer = 106                  ' Mã phân tích 15
    Private Const COLS_N16 As Integer = 107                  ' Mã phân tích 16
    Private Const COLS_N17 As Integer = 108                  ' Mã phân tích 17
    Private Const COLS_N18 As Integer = 109                  ' Mã phân tích 18
    Private Const COLS_N19 As Integer = 110                  ' Mã phân tích 19
    Private Const COLS_N20 As Integer = 111                  ' Mã phân tích 20
    Private Const COLS_OfficalTitleID As Integer = 112       ' Ngạch lương 1
    Private Const COLS_SalaryLevelID As Integer = 113        ' Bậc lương 1
    Private Const COLS_SaCoefficient As Integer = 114        ' Hệ số lương 1
    Private Const COLS_SaCoefficient12 As Integer = 115      ' SaCoefficient12
    Private Const COLS_SaCoefficient13 As Integer = 116      ' SaCoefficient13
    Private Const COLS_SaCoefficient14 As Integer = 117      ' SaCoefficient14
    Private Const COLS_SaCoefficient15 As Integer = 118      ' SaCoefficient15
    Private Const COLS_OfficalTitleID2 As Integer = 119      ' OfficalTitleID2
    Private Const COLS_SalaryLevelID2 As Integer = 120       ' SalaryLevelID2
    Private Const COLS_SaCoefficient2 As Integer = 121       ' SaCoefficient2
    Private Const COLS_SaCoefficient22 As Integer = 122      ' SaCoefficient22
    Private Const COLS_SaCoefficient23 As Integer = 123      ' SaCoefficient23
    Private Const COLS_SaCoefficient24 As Integer = 124      ' SaCoefficient24
    Private Const COLS_SaCoefficient25 As Integer = 125      ' SaCoefficient25
    Private Const COLS_P01 As Integer = 126                  ' Mã phân tích tiền lương 01
    Private Const COLS_P02 As Integer = 127                  ' Mã phân tích tiền lương 02
    Private Const COLS_P03 As Integer = 128                  ' Mã phân tích tiền lương 03
    Private Const COLS_P04 As Integer = 129                  ' Mã phân tích tiền lương 04
    Private Const COLS_P05 As Integer = 130                  ' Mã phân tích tiền lương 05
    Private Const COLS_P06 As Integer = 131                  ' Mã phân tích tiền lương 06
    Private Const COLS_P07 As Integer = 132                  ' Mã phân tích tiền lương 07
    Private Const COLS_P08 As Integer = 133                  ' Mã phân tích tiền lương 08
    Private Const COLS_P09 As Integer = 134                  ' Mã phân tích tiền lương 09
    Private Const COLS_P10 As Integer = 135                  ' Mã phân tích tiền lương 10
    Private Const COLS_P11 As Integer = 136                  ' Mã phân tích tiền lương 11
    Private Const COLS_P12 As Integer = 137                  ' Mã phân tích tiền lương 12
    Private Const COLS_P13 As Integer = 138                  ' Mã phân tích tiền lương 13
    Private Const COLS_P14 As Integer = 139                  ' Mã phân tích tiền lương 14
    Private Const COLS_P15 As Integer = 140                  ' Mã phân tích tiền lương 15
    Private Const COLS_P16 As Integer = 141                  ' Mã phân tích tiền lương 16
    Private Const COLS_P17 As Integer = 142                  ' Mã phân tích tiền lương 17
    Private Const COLS_P18 As Integer = 143                  ' Mã phân tích tiền lương 18
    Private Const COLS_P19 As Integer = 144                  ' Mã phân tích tiền lương 19
    Private Const COLS_P20 As Integer = 145                  ' Mã phân tích tiền lương 20
    Private Const COLS_Ref01 As Integer = 146                ' Ref01
    Private Const COLS_Ref02 As Integer = 147                ' Ref02
    Private Const COLS_Ref03 As Integer = 148                ' Ref03
    Private Const COLS_Ref04 As Integer = 149                ' Ref04
    Private Const COLS_Ref05 As Integer = 150                ' Ref05
    Private Const COLS_NumRef01 As Integer = 151             ' NumRef01
    Private Const COLS_NumRef02 As Integer = 152             ' NumRef02
    Private Const COLS_NumRef03 As Integer = 153             ' NumRef03
    Private Const COLS_NumRef04 As Integer = 154             ' NumRef04
    Private Const COLS_NumRef05 As Integer = 155             ' NumRef05
    Private Const COLS_NumRef06 As Integer = 156             ' NumRef06
    Private Const COLS_NumRef07 As Integer = 157             ' NumRef07
    Private Const COLS_NumRef08 As Integer = 158             ' NumRef08
    Private Const COLS_NumRef09 As Integer = 159             ' NumRef09
    Private Const COLS_NumRef10 As Integer = 160             ' NumRef10
    Private Const COLS_BaseSalary01DateEnd As Integer = 161  ' BaseSalary01DateEnd
    Private Const COLS_BaseSalary02DateEnd As Integer = 162  ' BaseSalary02DateEnd
    Private Const COLS_BaseSalary03DateEnd As Integer = 163  ' BaseSalary03DateEnd
    Private Const COLS_BaseSalary04DateEnd As Integer = 164  ' BaseSalary04DateEnd
    Private Const COLS_BaseSalary01NextDate As Integer = 165 ' BaseSalary01NextDate
    Private Const COLS_BaseSalary02NextDate As Integer = 166 ' BaseSalary02NextDate
    Private Const COLS_BaseSalary03NextDate As Integer = 167 ' BaseSalary03NextDate
    Private Const COLS_BaseSalary04NextDate As Integer = 168 ' BaseSalary04NextDate
    Private Const COLS_NextBaseSalary01 As Integer = 169     ' NextBaseSalary01
    Private Const COLS_NextBaseSalary02 As Integer = 170     ' NextBaseSalary02
    Private Const COLS_NextBaseSalary03 As Integer = 171     ' NextBaseSalary03
    Private Const COLS_NextBaseSalary04 As Integer = 172     ' NextBaseSalary04
    Private Const COLS_Sal01DateEnd As Integer = 173         ' Sal01DateEnd
    Private Const COLS_Sal02DateEnd As Integer = 174         ' Sal02DateEnd
    Private Const COLS_Sal03DateEnd As Integer = 175         ' Sal03DateEnd
    Private Const COLS_Sal04DateEnd As Integer = 176         ' Sal04DateEnd
    Private Const COLS_Sal05DateEnd As Integer = 177         ' Sal05DateEnd
    Private Const COLS_Sal06DateEnd As Integer = 178         ' Sal06DateEnd
    Private Const COLS_Sal07DateEnd As Integer = 179         ' Sal07DateEnd
    Private Const COLS_Sal08DateEnd As Integer = 180         ' Sal08DateEnd
    Private Const COLS_Sal09DateEnd As Integer = 181         ' Sal09DateEnd
    Private Const COLS_Sal10DateEnd As Integer = 182         ' Sal10DateEnd
    Private Const COLS_Sal11DateEnd As Integer = 183         ' Sal11DateEnd
    Private Const COLS_Sal12DateEnd As Integer = 184         ' Sal11DateEnd
    Private Const COLS_Sal13DateEnd As Integer = 185         ' Sal13DateEnd
    Private Const COLS_Sal14DateEnd As Integer = 186         ' Sal14DateEnd
    Private Const COLS_Sal15DateEnd As Integer = 187         ' Sal15DateEnd
    Private Const COLS_Sal16DateEnd As Integer = 188         ' Sal16DateEnd
    Private Const COLS_Sal17DateEnd As Integer = 189         ' Sal17DateEnd
    Private Const COLS_Sal18DateEnd As Integer = 190         ' Sal18DateEnd
    Private Const COLS_Sal19DateEnd As Integer = 191         ' Sal19DateEnd
    Private Const COLS_Sal20DateEnd As Integer = 192         ' Sal20DateEnd
    Private Const COLS_Sal01NextDate As Integer = 193        ' Sal01NextDate
    Private Const COLS_Sal02NextDate As Integer = 194        ' Sal02NextDate
    Private Const COLS_Sal03NextDate As Integer = 195        ' Sal03NextDate
    Private Const COLS_Sal04NextDate As Integer = 196        ' Sal04NextDate
    Private Const COLS_Sal05NextDate As Integer = 197        ' Sal05NextDate
    Private Const COLS_Sal06NextDate As Integer = 198        ' Sal06NextDate
    Private Const COLS_Sal07NextDate As Integer = 199        ' Sal07NextDate
    Private Const COLS_Sal08NextDate As Integer = 200        ' Sal08NextDate
    Private Const COLS_Sal09NextDate As Integer = 201        ' Sal09NextDate
    Private Const COLS_Sal10NextDate As Integer = 202        ' Sal10NextDate
    Private Const COLS_Sal11NextDate As Integer = 203        ' Sal11NextDate
    Private Const COLS_Sal12NextDate As Integer = 204        ' Sal12NextDate
    Private Const COLS_Sal13NextDate As Integer = 205        ' Sal13NextDate
    Private Const COLS_Sal14NextDate As Integer = 206        ' Sal14NextDate
    Private Const COLS_Sal15NextDate As Integer = 207        ' Sal15NextDate
    Private Const COLS_Sal16NextDate As Integer = 208        ' Sal16NextDate
    Private Const COLS_Sal17NextDate As Integer = 209        ' Sal17NextDate
    Private Const COLS_Sal18NextDate As Integer = 210        ' Sal18NextDate
    Private Const COLS_Sal19NextDate As Integer = 211        ' Sal19NextDate
    Private Const COLS_Sal20NextDate As Integer = 212        ' Sal20NextDate
    Private Const COLS_NextSalCoefficient01 As Integer = 213 ' NextSalCoefficient01
    Private Const COLS_NextSalCoefficient02 As Integer = 214 ' NextSalCoefficient02
    Private Const COLS_NextSalCoefficient03 As Integer = 215 ' NextSalCoefficient03
    Private Const COLS_NextSalCoefficient04 As Integer = 216 ' NextSalCoefficient04
    Private Const COLS_NextSalCoefficient05 As Integer = 217 ' NextSalCoefficient05
    Private Const COLS_NextSalCoefficient06 As Integer = 218 ' NextSalCoefficient06
    Private Const COLS_NextSalCoefficient07 As Integer = 219 ' NextSalCoefficient07
    Private Const COLS_NextSalCoefficient08 As Integer = 220 ' NextSalCoefficient08
    Private Const COLS_NextSalCoefficient09 As Integer = 221 ' NextSalCoefficient09
    Private Const COLS_NextSalCoefficient10 As Integer = 222 ' NextSalCoefficient10
    Private Const COLS_NextSalCoefficient11 As Integer = 223 ' NextSalCoefficient11
    Private Const COLS_NextSalCoefficient12 As Integer = 224 ' NextSalCoefficient12
    Private Const COLS_NextSalCoefficient13 As Integer = 225 ' NextSalCoefficient13
    Private Const COLS_NextSalCoefficient14 As Integer = 226 ' NextSalCoefficient14
    Private Const COLS_NextSalCoefficient15 As Integer = 227 ' NextSalCoefficient15
    Private Const COLS_NextSalCoefficient16 As Integer = 228 ' NextSalCoefficient16
    Private Const COLS_NextSalCoefficient17 As Integer = 229 ' NextSalCoefficient17
    Private Const COLS_NextSalCoefficient18 As Integer = 230 ' NextSalCoefficient18
    Private Const COLS_NextSalCoefficient19 As Integer = 231 ' NextSalCoefficient19
    Private Const COLS_NextSalCoefficient20 As Integer = 232 ' NextSalCoefficient20
    Private Const COLS_OffSa1DateEnd As Integer = 233        ' OffSa1DateEnd
    Private Const COLS_OffSa1NextDate As Integer = 234       ' OffSa1NextDate
    Private Const COLS_NextOfficalTitleID As Integer = 235   ' NextOfficalTitleID
    Private Const COLS_NextSalaryLevelID As Integer = 236    ' NextSalaryLevelID
    Private Const COLS_OffSa2DateEnd As Integer = 237        ' OffSa2DateEnd
    Private Const COLS_OffSa2NextDate As Integer = 238       ' OffSa2NextDate
    Private Const COLS_NextOfficalTitleID2 As Integer = 239  ' NextOfficalTitleID2
    Private Const COLS_NextSalaryLevelID2 As Integer = 240   ' NextSalaryLevelID2
    Private Const COLS_TransID As Integer = 241              ' TransID
    Private Const COLS_PaymentMethod As Integer = 242        ' Phương pháp trả lương
#End Region


    Private bBA As SALBA
    Private bANASAL As ANASALARY
    Private bInfoOther As InfoOther
    Private bCE As SALCE
    Private bPRMAS As PRMAS
    Private bANA As ANACODE
    Private bOL As OLSC
    Private bFlag As Boolean = False
    Private _payrollVoucherID As String = ""
    Private _payrollVoucherNo As String = ""
    Private _voucherDate As DateTime = Now
    Private _description As String = ""
    Private _departmentID As String = ""
    Private _teamID As String = ""
    Private _employeeID As String = ""
    Private sFind As String = ""
    Public dtEmployee As DataTable
    Dim dtOLSC As New DataTable
    Dim iPer As Integer

    Dim bUseInfoOther As Boolean = False
    Dim bUseAnaSal As Boolean = False
    Dim bUsePRMAS As Boolean = False
    Dim bUseNextBaseSalary As Boolean = False
    Dim bUseANAD09T0010 As Boolean = False

    Dim bMaxPeriod As Boolean = False ' biến kiểm tra có phải đang đứng tại kỳ cao nhất ko? (khi ở kỳ kế toán mới nhất thì mới được cập nhật vào HSL gốc)

    Public Property DepartmentID() As String
        Get
            Return _departmentID
        End Get
        Set(ByVal value As String)
            If DepartmentID = value Then
                _departmentID = ""
                Return
            End If
            _departmentID = value
        End Set
    End Property

    Public Property TeamID() As String
        Get
            Return _teamID
        End Get
        Set(ByVal value As String)
            If TeamID = value Then
                _teamID = ""
                Return
            End If
            _teamID = value
        End Set
    End Property

    Public Property EmployeeID() As String
        Get
            Return _employeeID
        End Get
        Set(ByVal value As String)
            If EmployeeID = value Then
                _employeeID = ""
                Return
            End If
            _employeeID = value
        End Set
    End Property

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

    Private _status As String = "0"
    Public WriteOnly Property Status() As String 
        Set(ByVal Value As String )
            _status = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()

            _FormState = value
            bMaxPeriod = CheckMaxPeriod() 'ID 106046 18.01.2018
            iPer = ReturnPermission("D13F1030")
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnUpdateMasterPayrollFiles.Enabled = False
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    btnUpdateMasterPayrollFiles.Enabled = False
                    LoadTDBGrid(DepartmentID, TeamID, EmployeeID)
                    ' update 15/4/2013 id 55205
                Case EnumFormState.FormEditOther
                    btnUpdateMasterPayrollFiles.Enabled = False
                    LoadTDBGrid(DepartmentID, TeamID, EmployeeID)
                Case EnumFormState.FormView ' update 5/3/5013 id 54589
                    btnSave.Enabled = False
                    btnUpdateMasterPayrollFiles.Enabled = False
                    LoadTDBGrid(DepartmentID, TeamID, EmployeeID)
            End Select
        End Set
    End Property

    Private Sub D13F2013_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        _bSaved = False
        Loadlanguage()
        'ResetColorGrid(tdbg, 0)
        tdbg_LockedColumns()
        ButtonD13T9000()
        ButtonD09T0010()
        ButtonD13T0050()
        ButtonD09T0080()
        ClickButton(Button.SalaryCoefficientBase)
        tdbg_NumberFormat()
        tdbg_InputDate()
        LoadTDBDropDown()

        tdbg.Columns(COLS_ValidDateFrom).Editor = c1dateFrom
        tdbg.Columns(COLS_ValidDateTo).Editor = c1dateTo

        If _FormState = EnumFormState.FormAdd Then
            For iSplit As Integer = 0 To tdbg.Splits.Count - 1
                For iColumns As Integer = 0 To tdbg.Columns.Count - 1
                    If iColumns = COLS_PaymentMethod Then Continue For ' update 5/3/5013 id 54589
                    tdbg.Splits(iSplit).DisplayColumns(iColumns).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    tdbg.Splits(iSplit).DisplayColumns(iColumns).Locked = True
                Next
            Next
        Else
            If _status = "1" Then
                For iSplit As Integer = 0 To tdbg.Splits.Count - 1
                    For iColumns As Integer = 0 To COLS_P20 - 1
                        tdbg.Splits(iSplit).DisplayColumns(iColumns).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                        tdbg.Splits(iSplit).DisplayColumns(iColumns).Locked = True
                    Next
                    For iColumns As Integer = COLS_PaymentMethod + 1 To tdbg.Columns.Count - 1
                        tdbg.Splits(iSplit).DisplayColumns(iColumns).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                        tdbg.Splits(iSplit).DisplayColumns(iColumns).Locked = True
                    Next
                Next
            End If

            tdbg.Splits(SPLIT0).DisplayColumns(COLS_PaymentMethod).Locked = False
        End If

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ho_so_luongf") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Hä s¥ l§¥ng - D13F2013'  Me.Text = rl3("Ho_so_luong_thang_-_D13F2013") & UnicodeCaption(gbUnicode) 'Hä s¥ l§¥ng thÀng - D13F2013
        '================================================================ 
        btnSalaryCoefficientBase.Text = "1. " & rl3("Luong_co_ban_He_soV") ' Lương cơ bản/ Hệ số
        btnSalaryLevelOfficialTitle.Text = "2. " & rl3("Ngach_-_bac_luong") ' Ngạch - Bậc lương
        btnNextBaseSalary.Text = "3. " & rl3("Luong_tiep_theo")
        btnAnalyseCode.Text = "4. " & rl3("Ma_phan_tich_nhan_su") 'Mã phân tích nhân sự
        btnAnalyseSalary.Text = "5. " & rl3("Ma_phan_tich_tien_luong") 'Mã phân tích tiền lương
        btnIncome.Text = "6. " & rl3("Thu_nhap") 'Thu nhập
        btnInfoOther.Text = "7. " & rl3("Thong_tin_khac")

        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnHotKey.Text = rl3("Phim_nong") 'Phím nóng
        btnUpdateMasterPayrollFiles.Text = rl3("_Cap_nhat_HSL_goc") '&Cập nhật HSL gốc
        '================================================================ 
        tdbdSalaryLevelID.Columns("SalaryLevelID").Caption = rl3("Ma") 'Mã
        tdbdSalaryLevelID.Columns("SalaryCoefficient").Caption = rl3("He_so_luong") 'Hệ số lương
        tdbdOfficialTitleID.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbdOfficialTitleID.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbdTaxObjectID.Columns("TaxObjectID").Caption = rl3("Ma") 'Mã 
        tdbdTaxObjectID.Columns("TaxObjectName").Caption = rl3("Ten") 'Tên
        tdbdPaymentMethod.Columns("PaymentMethod").Caption = rl3("Ma") 'Mã 
        tdbdPaymentMethod.Columns("PaymentMethodName").Caption = rl3("Ten") 'Tên

        tdbdPAna01ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna01ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna02ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna02ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna03ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna03ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna04ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna04ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna05ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna05ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna06ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna06ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna07ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna07ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna08ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna08ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna09ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna09ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna10ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna10ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna11ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna11ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna12ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna12ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna13ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna13ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna14ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna14ID.Columns("PAnaID").Caption = rl3("Ma") 'Mã 
        tdbdPAna15ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna15ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna16ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna16ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna17ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna17ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna18ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna18ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna19ID.Columns("PAnaName").Caption = rL3("Ten") 'Tên
        tdbdPAna19ID.Columns("PAnaName").Caption = rL3("Ten") 'Tên
        tdbdPAna20ID.Columns("PAnaName").Caption = rl3("Ten") 'Tên
        tdbdPAna20ID.Columns("PAnaName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdCurrencyID.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("StandardAbsentQuan").Caption = rl3("Ngay_cong_chuan")
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns("IsSub").Caption = rl3("HSL_phu") 'HSL phụ
        tdbg.Columns("TaxObjectID").Caption = rl3("Ma_DT_tinh_thue") 'Mã đt tính thuế 
        tdbg.Columns("TaxObjectName").Caption = rl3("Ten_DT_tinh_thue") 'Tên ĐT tính thuế
        tdbg.Columns("BASE01").Caption = rl3("Luong_co_ban_01") 'Lương cơ bản 01
        tdbg.Columns("BASE02").Caption = rl3("Luong_co_ban_02") 'Lương cơ bản 02
        tdbg.Columns("BASE03").Caption = rl3("Luong_co_ban_03") 'Lương cơ bản 03
        tdbg.Columns("BASE04").Caption = rl3("Luong_co_ban_04") 'Lương cơ bản 04
        tdbg.Columns("CE01").Caption = rl3("He_so_01") 'Hệ số 01
        tdbg.Columns("CE02").Caption = rl3("He_so_02") 'Hệ số 02
        tdbg.Columns("CE03").Caption = rl3("He_so_03") 'Hệ số 03
        tdbg.Columns("CE04").Caption = rl3("He_so_04") 'Hệ số 04
        tdbg.Columns("CE05").Caption = rl3("He_so_05") 'Hệ số 05
        tdbg.Columns("CE06").Caption = rl3("He_so_06") 'Hệ số 06
        tdbg.Columns("CE07").Caption = rl3("He_so_07") 'Hệ số 07
        tdbg.Columns("CE08").Caption = rl3("He_so_08") 'Hệ số 08
        tdbg.Columns("CE09").Caption = rl3("He_so_09") 'Hệ số 09
        tdbg.Columns("CE10").Caption = rl3("He_so_10") 'Hệ số 10
        tdbg.Columns("INC01").Caption = rl3("Thu_nhap_01") 'Thu nhập 01
        tdbg.Columns("INC02").Caption = rl3("Thu_nhap_02") 'Thu nhập 02
        tdbg.Columns("INC03").Caption = rl3("Thu_nhap_03") 'Thu nhập 03
        tdbg.Columns("INC04").Caption = rl3("Thu_nhap_04") 'Thu nhập 04
        tdbg.Columns("INC05").Caption = rl3("Thu_nhap_05") 'Thu nhập 05
        tdbg.Columns("INC06").Caption = rl3("Thu_nhap_06") 'Thu nhập 06
        tdbg.Columns("INC07").Caption = rl3("Thu_nhap_07") 'Thu nhập 07
        tdbg.Columns("INC08").Caption = rl3("Thu_nhap_08") 'Thu nhập 08
        tdbg.Columns("INC09").Caption = rl3("Thu_nhap_09") 'Thu nhập 09
        tdbg.Columns("INC10").Caption = rl3("Thu_nhap_10") 'Thu nhập 10
        tdbg.Columns("INC11").Caption = rl3("Thu_nhap_11") 'Thu nhập 11
        tdbg.Columns("INC12").Caption = rl3("Thu_nhap_12") 'Thu nhập 12
        tdbg.Columns("INC13").Caption = rl3("Thu_nhap_13") 'Thu nhập 13
        tdbg.Columns("INC14").Caption = rl3("Thu_nhap_14") 'Thu nhập 14
        tdbg.Columns("INC15").Caption = rl3("Thu_nhap_15") 'Thu nhập 15
        tdbg.Columns("INC16").Caption = rl3("Thu_nhap_16") 'Thu nhập 16
        tdbg.Columns("INC17").Caption = rl3("Thu_nhap_17") 'Thu nhập 17
        tdbg.Columns("INC18").Caption = rl3("Thu_nhap_18") 'Thu nhập 18
        tdbg.Columns("INC19").Caption = rl3("Thu_nhap_19") 'Thu nhập 19
        tdbg.Columns("INC20").Caption = rl3("Thu_nhap_20") 'Thu nhập 20
        tdbg.Columns("INC21").Caption = rl3("Thu_nhap_21") 'Thu nhập 21
        tdbg.Columns("INC22").Caption = rl3("Thu_nhap_22") 'Thu nhập 22
        tdbg.Columns("INC23").Caption = rl3("Thu_nhap_23") 'Thu nhập 23
        tdbg.Columns("INC24").Caption = rl3("Thu_nhap_24") 'Thu nhập 24
        tdbg.Columns("INC25").Caption = rl3("Thu_nhap_25") 'Thu nhập 25
        tdbg.Columns("INC26").Caption = rl3("Thu_nhap_26") 'Thu nhập 26
        tdbg.Columns("INC27").Caption = rl3("Thu_nhap_27") 'Thu nhập 27
        tdbg.Columns("INC28").Caption = rl3("Thu_nhap_28") 'Thu nhập 28
        tdbg.Columns("INC29").Caption = rl3("Thu_nhap_29") 'Thu nhập 29
        tdbg.Columns("INC30").Caption = rl3("Thu_nhap_30") 'Thu nhập 30
        tdbg.Columns("N01").Caption = rl3("Ma_phan_tich_01") 'Mã phân tích 01
        tdbg.Columns("N02").Caption = rl3("Ma_phan_tich_02") 'Mã phân tích 02
        tdbg.Columns("N03").Caption = rl3("Ma_phan_tich_03") 'Mã phân tích 03
        tdbg.Columns("N04").Caption = rl3("Ma_phan_tich_04") 'Mã phân tích 04
        tdbg.Columns("N05").Caption = rl3("Ma_phan_tich_05") 'Mã phân tích 05
        tdbg.Columns("N06").Caption = rl3("Ma_phan_tich_06") 'Mã phân tích 06
        tdbg.Columns("N07").Caption = rl3("Ma_phan_tich_07") 'Mã phân tích 07
        tdbg.Columns("N08").Caption = rl3("Ma_phan_tich_08") 'Mã phân tích 08
        tdbg.Columns("N09").Caption = rl3("Ma_phan_tich_09") 'Mã phân tích 09
        tdbg.Columns("N10").Caption = rl3("Ma_phan_tich_10") 'Mã phân tích 10
        tdbg.Columns("N11").Caption = rl3("Ma_phan_tich_11") 'Mã phân tích 11
        tdbg.Columns("N12").Caption = rl3("Ma_phan_tich_12") 'Mã phân tích 12
        tdbg.Columns("N13").Caption = rl3("Ma_phan_tich_13") 'Mã phân tích 13
        tdbg.Columns("N14").Caption = rl3("Ma_phan_tich_14") 'Mã phân tích 14
        tdbg.Columns("N15").Caption = rl3("Ma_phan_tich_15") 'Mã phân tích 15
        tdbg.Columns("N16").Caption = rl3("Ma_phan_tich_16") 'Mã phân tích 16
        tdbg.Columns("N17").Caption = rl3("Ma_phan_tich_17") 'Mã phân tích 17
        tdbg.Columns("N18").Caption = rl3("Ma_phan_tich_18") 'Mã phân tích 18
        tdbg.Columns("N19").Caption = rl3("Ma_phan_tich_19") 'Mã phân tích 19
        tdbg.Columns("N20").Caption = rl3("Ma_phan_tich_20") 'Mã phân tích 20
        tdbg.Columns("OfficalTitleID").Caption = rl3("Ngach_luong_1") 'Ngạch lương 1
        tdbg.Columns("SalaryLevelID").Caption = rl3("Bac_luong_1") 'Bậc lương 1
        tdbg.Columns("SaCoefficient").Caption = rl3("He_so_luong_1") 'Hệ số lương 1
        tdbg.Columns("OfficalTitleID2").Caption = rl3("Ngach_luong_2") 'Ngạch lương 2
        tdbg.Columns("SalaryLevelID2").Caption = rl3("Bac_luong_2") 'Bậc lương 2
        tdbg.Columns("SaCoefficient2").Caption = rl3("He_so_luong_2") 'Hệ số lương 2
        tdbg.Columns("ValidDateFrom").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Tu") & ")"
        tdbg.Columns("ValidDateto").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Den") & ")"
        tdbg.Columns("SalaryRate").Caption = rl3("Ty_le_huong_luong") & " (%)"  'Tỷ lệ hưởng lương (%)
        tdbg.Columns("IsSub").Caption = rl3("HSL_phu")
        tdbg.Splits(0).Caption = rl3("Thong_tin_chinh") 'Thông tin chính
        tdbg.Splits(1).Caption = rl3("Doi_tuong_tinh_thue") 'Đối tượng tính thuế
        tdbg.Columns("PaymentMethod").Caption = rl3("Phuong_phap_tra_luong") 'Phương pháp trả lương
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdTaxObjectID
        sSQL = "Select TaxObjectID, TaxObjectName" & UnicodeJoin(gbUnicode) & " as TaxObjectName From D13T0128  WITH(NOLOCK) Where Disabled = 0 Order By TaxObjectID "
        LoadDataSource(tdbdTaxObjectID, sSQL, gbUnicode)
        'Load tdbdOfficialTitleID
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName From D09T0214  WITH(NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 1) Order By OfficialTitleID "
        LoadDataSource(tdbdOfficialTitleID, sSQL, gbUnicode)

        'Load tdbdOfficialTitleID2
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName From D09T0214  WITH(NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 2) Order By OfficialTitleID "
        LoadDataSource(tdbdOfficialTitleID2, sSQL, gbUnicode)

        sSQL = "Select NCodeID, Description" & UnicodeJoin(gbUnicode) & " as Description, TypeID From D09T1010  WITH(NOLOCK) Order by TypeID"
        dtNCodeID = ReturnDataTable(sSQL)

        'Load tdbdPaymentMethod
        sSQL = "Select 'C' As PaymentMethod, " & IIf(gbUnicode, "N'Tiền mặt'", "'Tieàn maët'").ToString & " As PaymentMethodName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 'B' As PaymentMethod," & IIf(gbUnicode, "N'Chuyển khoản'", "'Chuyeån khoaûn'").ToString & " As PaymentMethodName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 'O' As PaymentMethod, " & IIf(gbUnicode, "N'Hình thức khác'", "'Hình thöùc khaùc'").ToString & " As PaymentMethodName" & vbCrLf
        LoadDataSource(tdbdPaymentMethod, sSQL, gbUnicode)

        Load10TDBDropDownPAna()

        'Load tdbdCurrencyID
        sSQL = "--Do nguon combo Nguyen te" & vbCrLf
        sSQL &= "SELECT		CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " AS CurrencyName" & vbCrLf
        sSQL &= "FROM 		D91T0010 " & vbCrLf
        sSQL &= "WHERE 	Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	CurrencyID"

        LoadDataSource(tdbdCurrencyID, sSQL, gbUnicode)
        dtSalaryLevelID = ReturnDataTable("Select SalaryLevelID, SalaryCoefficient, SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, OfficialTitleID, Grade, NumberYearTransfer  From D09T0215  WITH(NOLOCK) Where Disabled = 0 ORDER BY 	Grade ")
    End Sub

    Dim dtNCodeID As DataTable
    Private Sub LoadTdbdNCodeID(ByVal sTypeID As String)
        LoadDataSource(tdbdNCodeID, ReturnTableFilter(dtNCodeID, "TypeID = " & SQLString(sTypeID), True), gbUnicode)
    End Sub

    Private Sub LoadTDBGrid(ByVal sDepartmentID As String, ByVal sTeamID As String, ByVal sEmployeeID As String)
        Dim sSQL As String = ""
        LoadDataSource(tdbg, dtEmployee, gbUnicode)
        dtEmployee.DefaultView.Sort = " IsSub ASC" 'ID 101728 15.08.2017
        ResetFooterGrid(tdbg, 0, 2)
    End Sub

    Private Sub LoadAddNew()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2080.ToString
        LoadDataSource(tdbg, sSQL, gbUnicode)
        ResetFooterGrid(tdbg, 0, 2)
        sSQL = SQLDeleteD91T9009()
        ExecuteSQL(sSQL)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2080
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 11:06:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2080() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2080 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("0001") & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 11:08:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where HostID = " & SQLString(My.Computer.Name)
        sSQL &= " And UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    Private Sub ButtonD13T9000()

        Dim sDateEnd As String = IIf(gbUnicode, rl3("Ngay_hieu_luc_U"), ConvertUnicodeToVni(rl3("Ngay_hieu_luc_U"))).ToString
        Dim sNextDate As String = IIf(gbUnicode, rl3("Ngay_xet_tiep_theo"), ConvertUnicodeToVni(rl3("Ngay_xet_tiep_theo"))).ToString
        Dim sNext As String = IIf(gbUnicode, rL3("Tiep_theo"), ConvertUnicodeToVni(rL3("Tiep_theo"))).ToString
        Dim sCurrency As String = IIf(gbUnicode, rL3("Nguyen_te"), ConvertUnicodeToVni(rL3("Nguyen_te"))).ToString


        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short, Disabled, Type, Decimals From D13T9000  WITH(NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        dtOLSC = ReturnTableFilter(dt, " Type = 'OLSC'")

        Dim dt1 As DataTable

        dt1 = ReturnTableFilter(dt, "Type='SALBA'")
        For i As Integer = 0 To 3
            tdbg.Columns(COLS_BASE01 + (i * 2)).Caption = dt1.Rows(i).Item("Short").ToString
            ' Nguyên tệ (Caption của BASExx)
            tdbg.Columns(COLS_BaseCurrencyID01 + (i * 2)).Caption = sCurrency & vbCrLf & "(" & dt1.Rows(i).Item("Short").ToString & ")"
            tdbg.Columns(COLS_BaseSalary01DateEnd + i).Caption = sDateEnd & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COLS_BaseSalary01NextDate + i).Caption = sNextDate & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COLS_NextBaseSalary01 + i).Caption = dt1.Rows(i).Item("Short").ToString & sNext
        Next
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))

        dt1 = ReturnTableFilter(dt, "Type='SALCE'")
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
            tdbg.Columns(COLS_CE01 + (i * 2)).Caption = dt1.Rows(i).Item("Short").ToString
            ' Nguyên tệ (Caption của CExx)
            tdbg.Columns(COLS_SalCoeCurrencyID01 + (i * 2)).Caption = sCurrency & vbCrLf & "(" & dt1.Rows(i).Item("Short").ToString & ")"
            tdbg.Columns(COLS_Sal01DateEnd + i).Caption = sDateEnd & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COLS_Sal01NextDate + i).Caption = sNextDate & " " & dt1.Rows(i).Item("Short").ToString
            tdbg.Columns(COLS_NextSalCoefficient01 + i).Caption = dt1.Rows(i).Item("Short").ToString & sNext
        Next

        dt1 = ReturnTableFilter(dt, "Type='PRMAS'")
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
        tdbg.Columns(COLS_INC01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_INC02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COLS_INC03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COLS_INC04).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COLS_INC05).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COLS_INC06).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COLS_INC07).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COLS_INC08).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_INC09).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COLS_INC10).Caption = dt1.Rows(9).Item("Short").ToString
        tdbg.Columns(COLS_INC11).Caption = dt1.Rows(10).Item("Short").ToString
        tdbg.Columns(COLS_INC12).Caption = dt1.Rows(11).Item("Short").ToString
        tdbg.Columns(COLS_INC13).Caption = dt1.Rows(12).Item("Short").ToString
        tdbg.Columns(COLS_INC14).Caption = dt1.Rows(13).Item("Short").ToString
        tdbg.Columns(COLS_INC15).Caption = dt1.Rows(14).Item("Short").ToString
        tdbg.Columns(COLS_INC16).Caption = dt1.Rows(15).Item("Short").ToString
        tdbg.Columns(COLS_INC17).Caption = dt1.Rows(16).Item("Short").ToString
        tdbg.Columns(COLS_INC18).Caption = dt1.Rows(17).Item("Short").ToString
        tdbg.Columns(COLS_INC19).Caption = dt1.Rows(18).Item("Short").ToString
        tdbg.Columns(COLS_INC20).Caption = dt1.Rows(19).Item("Short").ToString
        tdbg.Columns(COLS_INC21).Caption = dt1.Rows(20).Item("Short").ToString
        tdbg.Columns(COLS_INC22).Caption = dt1.Rows(21).Item("Short").ToString
        tdbg.Columns(COLS_INC23).Caption = dt1.Rows(22).Item("Short").ToString
        tdbg.Columns(COLS_INC24).Caption = dt1.Rows(23).Item("Short").ToString
        tdbg.Columns(COLS_INC25).Caption = dt1.Rows(24).Item("Short").ToString
        tdbg.Columns(COLS_INC26).Caption = dt1.Rows(25).Item("Short").ToString
        tdbg.Columns(COLS_INC27).Caption = dt1.Rows(26).Item("Short").ToString
        tdbg.Columns(COLS_INC28).Caption = dt1.Rows(27).Item("Short").ToString
        tdbg.Columns(COLS_INC29).Caption = dt1.Rows(28).Item("Short").ToString
        tdbg.Columns(COLS_INC30).Caption = dt1.Rows(29).Item("Short").ToString

        Dim dt3 As DataTable
        dt3 = ReturnTableFilter(dt, "Type = 'OLSC'")
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
        tdbg.Columns(COLS_OfficalTitleID).Caption = dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_OffSa1DateEnd).Caption = sDateEnd & " " & dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_OffSa1NextDate).Caption = sNextDate & " " & dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_NextOfficalTitleID).Caption = dt3.Rows(0).Item("Short").ToString & " " & sNext

        tdbg.Columns(COLS_SalaryLevelID).Caption = dt3.Rows(1).Item("Short").ToString
        tdbg.Columns(COLS_NextSalaryLevelID).Caption = dt3.Rows(1).Item("Short").ToString & " " & sNext


        tdbg.Columns(COLS_SaCoefficient).Caption = dt3.Rows(2).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient12).Caption = dt3.Rows(3).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient13).Caption = dt3.Rows(4).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient14).Caption = dt3.Rows(5).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient15).Caption = dt3.Rows(6).Item("Short").ToString

        tdbg.Columns(COLS_OfficalTitleID2).Caption = dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_OffSa2DateEnd).Caption = sDateEnd & " " & dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_OffSa2NextDate).Caption = sNextDate & " " & dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_NextOfficalTitleID2).Caption = dt3.Rows(7).Item("Short").ToString & " " & sNext

        tdbg.Columns(COLS_SalaryLevelID2).Caption = dt3.Rows(8).Item("Short").ToString
        tdbg.Columns(COLS_NextSalaryLevelID2).Caption = dt3.Rows(8).Item("Short").ToString & " " & sNext

        tdbg.Columns(COLS_SaCoefficient2).Caption = dt3.Rows(9).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient22).Caption = dt3.Rows(10).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient23).Caption = dt3.Rows(11).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient24).Caption = dt3.Rows(12).Item("Short").ToString
        tdbg.Columns(COLS_SaCoefficient25).Caption = dt3.Rows(13).Item("Short").ToString

        ' Kiểm tra nếu không sử dụng thì mờ nut btnNextBaseSalary
        Dim dr() As DataRow = dt.Select("(Type = 'OLSC' OR Type='SALCE') AND Disabled = 0")
        bUseNextBaseSalary = dr.Length > 0

        For i As Integer = 0 To tdbg.Columns.Count - 1
            tdbg.Splits(2).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next
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
        tdbg.Columns(COLS_N01).Caption = dt.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_N02).Caption = dt.Rows(1).Item("Short").ToString
        tdbg.Columns(COLS_N03).Caption = dt.Rows(2).Item("Short").ToString
        tdbg.Columns(COLS_N04).Caption = dt.Rows(3).Item("Short").ToString
        tdbg.Columns(COLS_N05).Caption = dt.Rows(4).Item("Short").ToString
        tdbg.Columns(COLS_N06).Caption = dt.Rows(5).Item("Short").ToString
        tdbg.Columns(COLS_N07).Caption = dt.Rows(6).Item("Short").ToString
        tdbg.Columns(COLS_N08).Caption = dt.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_N09).Caption = dt.Rows(8).Item("Short").ToString
        tdbg.Columns(COLS_N10).Caption = dt.Rows(9).Item("Short").ToString
        tdbg.Columns(COLS_N11).Caption = dt.Rows(10).Item("Short").ToString
        tdbg.Columns(COLS_N12).Caption = dt.Rows(11).Item("Short").ToString
        tdbg.Columns(COLS_N13).Caption = dt.Rows(12).Item("Short").ToString
        tdbg.Columns(COLS_N14).Caption = dt.Rows(13).Item("Short").ToString
        tdbg.Columns(COLS_N15).Caption = dt.Rows(14).Item("Short").ToString
        tdbg.Columns(COLS_N16).Caption = dt.Rows(15).Item("Short").ToString
        tdbg.Columns(COLS_N17).Caption = dt.Rows(16).Item("Short").ToString
        tdbg.Columns(COLS_N18).Caption = dt.Rows(17).Item("Short").ToString
        tdbg.Columns(COLS_N19).Caption = dt.Rows(18).Item("Short").ToString
        tdbg.Columns(COLS_N20).Caption = dt.Rows(19).Item("Short").ToString
    End Sub

    Private Sub ButtonD13T0050()
        Dim sSQL As String = ""
        sSQL = "Select PAnaCategoryID as Code, PAnaCategoryShort" & UnicodeJoin(gbUnicode) & " as Short,Disabled From D13T0050  WITH(NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)

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

        tdbg.Columns(COLS_P01).Caption = dt.Rows(0).Item("Short").ToString
        tdbg.Columns(COLS_P02).Caption = dt.Rows(1).Item("Short").ToString
        tdbg.Columns(COLS_P03).Caption = dt.Rows(2).Item("Short").ToString
        tdbg.Columns(COLS_P04).Caption = dt.Rows(3).Item("Short").ToString
        tdbg.Columns(COLS_P05).Caption = dt.Rows(4).Item("Short").ToString
        tdbg.Columns(COLS_P06).Caption = dt.Rows(5).Item("Short").ToString
        tdbg.Columns(COLS_P07).Caption = dt.Rows(6).Item("Short").ToString
        tdbg.Columns(COLS_P08).Caption = dt.Rows(7).Item("Short").ToString
        tdbg.Columns(COLS_P09).Caption = dt.Rows(8).Item("Short").ToString
        tdbg.Columns(COLS_P10).Caption = dt.Rows(9).Item("Short").ToString
        tdbg.Columns(COLS_P11).Caption = dt.Rows(10).Item("Short").ToString
        tdbg.Columns(COLS_P12).Caption = dt.Rows(11).Item("Short").ToString
        tdbg.Columns(COLS_P13).Caption = dt.Rows(12).Item("Short").ToString
        tdbg.Columns(COLS_P14).Caption = dt.Rows(13).Item("Short").ToString
        tdbg.Columns(COLS_P15).Caption = dt.Rows(14).Item("Short").ToString
        tdbg.Columns(COLS_P16).Caption = dt.Rows(15).Item("Short").ToString
        tdbg.Columns(COLS_P17).Caption = dt.Rows(16).Item("Short").ToString
        tdbg.Columns(COLS_P18).Caption = dt.Rows(17).Item("Short").ToString
        tdbg.Columns(COLS_P19).Caption = dt.Rows(18).Item("Short").ToString
        tdbg.Columns(COLS_P20).Caption = dt.Rows(19).Item("Short").ToString
    End Sub

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
            tdbg.Columns(COLS_Ref01).Caption = dtRefString.Rows(0).Item("RefCaption").ToString
            bInfoOther.Ref01 = Not L3Bool(dtRefString.Rows(0).Item("Disabled"))
            tdbg.Columns(COLS_Ref02).Caption = dtRefString.Rows(1).Item("RefCaption").ToString
            bInfoOther.Ref02 = Not L3Bool(dtRefString.Rows(1).Item("Disabled"))
            tdbg.Columns(COLS_Ref03).Caption = dtRefString.Rows(2).Item("RefCaption").ToString
            bInfoOther.Ref03 = Not L3Bool(dtRefString.Rows(2).Item("Disabled"))
            tdbg.Columns(COLS_Ref04).Caption = dtRefString.Rows(3).Item("RefCaption").ToString
            bInfoOther.Ref04 = Not L3Bool(dtRefString.Rows(3).Item("Disabled"))
            tdbg.Columns(COLS_Ref05).Caption = dtRefString.Rows(4).Item("RefCaption").ToString
            bInfoOther.Ref05 = Not L3Bool(dtRefString.Rows(4).Item("Disabled"))
        End If

        Dim dtRefNum As DataTable = ReturnTableFilter(dtRef, "GroupMode=1", True)
        If dtRefNum.Rows.Count > 0 And dtRefNum.Rows.Count >= 10 Then
            tdbg.Columns(COLS_NumRef01).Caption = dtRefNum.Rows(0).Item("RefCaption").ToString
            bInfoOther.NumRef01 = Not L3Bool(dtRefNum.Rows(0).Item("Disabled"))
            tdbg.Columns(COLS_NumRef02).Caption = dtRefNum.Rows(1).Item("RefCaption").ToString
            bInfoOther.NumRef02 = Not L3Bool(dtRefNum.Rows(1).Item("Disabled"))
            tdbg.Columns(COLS_NumRef03).Caption = dtRefNum.Rows(2).Item("RefCaption").ToString
            bInfoOther.NumRef03 = Not L3Bool(dtRefNum.Rows(2).Item("Disabled"))
            tdbg.Columns(COLS_NumRef04).Caption = dtRefNum.Rows(3).Item("RefCaption").ToString
            bInfoOther.NumRef04 = Not L3Bool(dtRefNum.Rows(3).Item("Disabled"))
            tdbg.Columns(COLS_NumRef05).Caption = dtRefNum.Rows(4).Item("RefCaption").ToString
            bInfoOther.NumRef05 = Not L3Bool(dtRefNum.Rows(4).Item("Disabled"))
            tdbg.Columns(COLS_NumRef06).Caption = dtRefNum.Rows(5).Item("RefCaption").ToString
            bInfoOther.NumRef06 = Not L3Bool(dtRefNum.Rows(5).Item("Disabled"))
            tdbg.Columns(COLS_NumRef07).Caption = dtRefNum.Rows(6).Item("RefCaption").ToString
            bInfoOther.NumRef07 = Not L3Bool(dtRefNum.Rows(6).Item("Disabled"))
            tdbg.Columns(COLS_NumRef08).Caption = dtRefNum.Rows(7).Item("RefCaption").ToString
            bInfoOther.NumRef08 = Not L3Bool(dtRefNum.Rows(7).Item("Disabled"))
            tdbg.Columns(COLS_NumRef09).Caption = dtRefNum.Rows(8).Item("RefCaption").ToString
            bInfoOther.NumRef09 = Not L3Bool(dtRefNum.Rows(8).Item("Disabled"))
            tdbg.Columns(COLS_NumRef10).Caption = dtRefNum.Rows(9).Item("RefCaption").ToString
            bInfoOther.NumRef10 = Not L3Bool(dtRefNum.Rows(9).Item("Disabled"))
        End If


        '        For i As Integer = COLS_Ref01 To COLS_Ref05
        '            tdbg.Splits(2).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        '        Next
    End Sub

    Private Sub ClickButton(ByVal button As Button)
        tdbg.Splits(2).SplitSize = 2

        btnSalaryCoefficientBase.Enabled = Math.Abs(button - button.SalaryCoefficientBase) > 0
        btnIncome.Enabled = Math.Abs(button - button.Income) > 0 And bUsePRMAS
        btnNextBaseSalary.Enabled = Math.Abs(button - button.NextBaseSalary) > 0 And bUseNextBaseSalary  ' 13/1/2014 id 60442
        btnAnalyseCode.Enabled = Math.Abs(button - button.AnalyseCode) > 0 And bUseANAD09T0010
        btnAnalyseSalary.Enabled = Math.Abs(button - button.AnalyseSalary) > 0 And D13Systems.IsUsedPAna
        btnSalaryLevelOfficialTitle.Enabled = Math.Abs(button - button.SalaryLevelOfficialTitle) > 0
        btnInfoOther.Enabled = Math.Abs(button - button.InfoOther) > 0 And bUseInfoOther

        Dim bButtonSalary As Boolean = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(2).DisplayColumns(COLS_BASE01).Visible = bButtonSalary And bBA.BASE01
        tdbg.Splits(2).DisplayColumns(COLS_BASE02).Visible = bButtonSalary And bBA.BASE02
        tdbg.Splits(2).DisplayColumns(COLS_BASE03).Visible = bButtonSalary And bBA.BASE03
        tdbg.Splits(2).DisplayColumns(COLS_BASE04).Visible = bButtonSalary And bBA.BASE04

        For i As Integer = 0 To 3 ' Ẩn hiện tương tự COLS_BASExx
            tdbg.Splits(2).DisplayColumns(COLS_BaseCurrencyID01 + (i * 2)).Visible = tdbg.Splits(2).DisplayColumns(COLS_BASE01 + (i * 2)).Visible
        Next

        tdbg.Splits(2).DisplayColumns(COLS_CE01).Visible = bButtonSalary And bCE.CE01
        tdbg.Splits(2).DisplayColumns(COLS_CE02).Visible = bButtonSalary And bCE.CE02
        tdbg.Splits(2).DisplayColumns(COLS_CE03).Visible = bButtonSalary And bCE.CE03
        tdbg.Splits(2).DisplayColumns(COLS_CE04).Visible = bButtonSalary And bCE.CE04
        tdbg.Splits(2).DisplayColumns(COLS_CE05).Visible = bButtonSalary And bCE.CE05
        tdbg.Splits(2).DisplayColumns(COLS_CE06).Visible = bButtonSalary And bCE.CE06
        tdbg.Splits(2).DisplayColumns(COLS_CE07).Visible = bButtonSalary And bCE.CE07
        tdbg.Splits(2).DisplayColumns(COLS_CE08).Visible = bButtonSalary And bCE.CE08
        tdbg.Splits(2).DisplayColumns(COLS_CE09).Visible = bButtonSalary And bCE.CE09
        tdbg.Splits(2).DisplayColumns(COLS_CE10).Visible = bButtonSalary And bCE.CE10
        tdbg.Splits(2).DisplayColumns(COLS_CE11).Visible = bButtonSalary And bCE.CE11
        tdbg.Splits(2).DisplayColumns(COLS_CE12).Visible = bButtonSalary And bCE.CE12
        tdbg.Splits(2).DisplayColumns(COLS_CE13).Visible = bButtonSalary And bCE.CE13
        tdbg.Splits(2).DisplayColumns(COLS_CE14).Visible = bButtonSalary And bCE.CE14
        tdbg.Splits(2).DisplayColumns(COLS_CE15).Visible = bButtonSalary And bCE.CE15
        tdbg.Splits(2).DisplayColumns(COLS_CE16).Visible = bButtonSalary And bCE.CE16
        tdbg.Splits(2).DisplayColumns(COLS_CE17).Visible = bButtonSalary And bCE.CE17
        tdbg.Splits(2).DisplayColumns(COLS_CE18).Visible = bButtonSalary And bCE.CE18
        tdbg.Splits(2).DisplayColumns(COLS_CE19).Visible = bButtonSalary And bCE.CE19
        tdbg.Splits(2).DisplayColumns(COLS_CE20).Visible = bButtonSalary And bCE.CE20

        For i As Integer = 0 To 19 '  Ẩn hiện tương tự COLS_CExx
            tdbg.Splits(2).DisplayColumns(COLS_SalCoeCurrencyID01 + (i * 2)).Visible = tdbg.Splits(2).DisplayColumns(COLS_CE01 + (i * 2)).Visible
        Next

        Dim bButtonIncome As Boolean = Math.Abs(button - button.Income) = 0
        tdbg.Splits(2).DisplayColumns(COLS_INC01).Visible = bButtonIncome And bPRMAS.INC01
        tdbg.Splits(2).DisplayColumns(COLS_INC02).Visible = bButtonIncome And bPRMAS.INC02
        tdbg.Splits(2).DisplayColumns(COLS_INC03).Visible = bButtonIncome And bPRMAS.INC03
        tdbg.Splits(2).DisplayColumns(COLS_INC04).Visible = bButtonIncome And bPRMAS.INC04
        tdbg.Splits(2).DisplayColumns(COLS_INC05).Visible = bButtonIncome And bPRMAS.INC05
        tdbg.Splits(2).DisplayColumns(COLS_INC06).Visible = bButtonIncome And bPRMAS.INC06
        tdbg.Splits(2).DisplayColumns(COLS_INC07).Visible = bButtonIncome And bPRMAS.INC07
        tdbg.Splits(2).DisplayColumns(COLS_INC08).Visible = bButtonIncome And bPRMAS.INC08
        tdbg.Splits(2).DisplayColumns(COLS_INC09).Visible = bButtonIncome And bPRMAS.INC09
        tdbg.Splits(2).DisplayColumns(COLS_INC10).Visible = bButtonIncome And bPRMAS.INC10
        tdbg.Splits(2).DisplayColumns(COLS_INC11).Visible = bButtonIncome And bPRMAS.INC11
        tdbg.Splits(2).DisplayColumns(COLS_INC12).Visible = bButtonIncome And bPRMAS.INC12
        tdbg.Splits(2).DisplayColumns(COLS_INC13).Visible = bButtonIncome And bPRMAS.INC13
        tdbg.Splits(2).DisplayColumns(COLS_INC14).Visible = bButtonIncome And bPRMAS.INC14
        tdbg.Splits(2).DisplayColumns(COLS_INC15).Visible = bButtonIncome And bPRMAS.INC15
        tdbg.Splits(2).DisplayColumns(COLS_INC16).Visible = bButtonIncome And bPRMAS.INC16
        tdbg.Splits(2).DisplayColumns(COLS_INC17).Visible = bButtonIncome And bPRMAS.INC17
        tdbg.Splits(2).DisplayColumns(COLS_INC18).Visible = bButtonIncome And bPRMAS.INC18
        tdbg.Splits(2).DisplayColumns(COLS_INC19).Visible = bButtonIncome And bPRMAS.INC19
        tdbg.Splits(2).DisplayColumns(COLS_INC20).Visible = bButtonIncome And bPRMAS.INC20
        tdbg.Splits(2).DisplayColumns(COLS_INC21).Visible = bButtonIncome And bPRMAS.INC21
        tdbg.Splits(2).DisplayColumns(COLS_INC22).Visible = bButtonIncome And bPRMAS.INC22
        tdbg.Splits(2).DisplayColumns(COLS_INC23).Visible = bButtonIncome And bPRMAS.INC23
        tdbg.Splits(2).DisplayColumns(COLS_INC24).Visible = bButtonIncome And bPRMAS.INC24
        tdbg.Splits(2).DisplayColumns(COLS_INC25).Visible = bButtonIncome And bPRMAS.INC25
        tdbg.Splits(2).DisplayColumns(COLS_INC26).Visible = bButtonIncome And bPRMAS.INC26
        tdbg.Splits(2).DisplayColumns(COLS_INC27).Visible = bButtonIncome And bPRMAS.INC27
        tdbg.Splits(2).DisplayColumns(COLS_INC28).Visible = bButtonIncome And bPRMAS.INC28
        tdbg.Splits(2).DisplayColumns(COLS_INC29).Visible = bButtonIncome And bPRMAS.INC29
        tdbg.Splits(2).DisplayColumns(COLS_INC30).Visible = bButtonIncome And bPRMAS.INC30

        Dim bButtonAna As Boolean = Math.Abs(button - button.AnalyseCode) = 0
        tdbg.Splits(2).DisplayColumns(COLS_N01).Visible = bButtonAna And bANA.N01
        tdbg.Splits(2).DisplayColumns(COLS_N02).Visible = bButtonAna And bANA.N02
        tdbg.Splits(2).DisplayColumns(COLS_N03).Visible = bButtonAna And bANA.N03
        tdbg.Splits(2).DisplayColumns(COLS_N04).Visible = bButtonAna And bANA.N04
        tdbg.Splits(2).DisplayColumns(COLS_N05).Visible = bButtonAna And bANA.N05
        tdbg.Splits(2).DisplayColumns(COLS_N06).Visible = bButtonAna And bANA.N06
        tdbg.Splits(2).DisplayColumns(COLS_N07).Visible = bButtonAna And bANA.N07
        tdbg.Splits(2).DisplayColumns(COLS_N08).Visible = bButtonAna And bANA.N08
        tdbg.Splits(2).DisplayColumns(COLS_N09).Visible = bButtonAna And bANA.N09
        tdbg.Splits(2).DisplayColumns(COLS_N10).Visible = bButtonAna And bANA.N10
        tdbg.Splits(2).DisplayColumns(COLS_N11).Visible = bButtonAna And bANA.N11
        tdbg.Splits(2).DisplayColumns(COLS_N12).Visible = bButtonAna And bANA.N12
        tdbg.Splits(2).DisplayColumns(COLS_N13).Visible = bButtonAna And bANA.N13
        tdbg.Splits(2).DisplayColumns(COLS_N14).Visible = bButtonAna And bANA.N14
        tdbg.Splits(2).DisplayColumns(COLS_N15).Visible = bButtonAna And bANA.N15
        tdbg.Splits(2).DisplayColumns(COLS_N16).Visible = bButtonAna And bANA.N16
        tdbg.Splits(2).DisplayColumns(COLS_N17).Visible = bButtonAna And bANA.N17
        tdbg.Splits(2).DisplayColumns(COLS_N18).Visible = bButtonAna And bANA.N18
        tdbg.Splits(2).DisplayColumns(COLS_N19).Visible = bButtonAna And bANA.N19
        tdbg.Splits(2).DisplayColumns(COLS_N20).Visible = bButtonAna And bANA.N20

        tdbg.Splits(2).DisplayColumns(COLS_OfficalTitleID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC1
        tdbg.Splits(2).DisplayColumns(COLS_SalaryLevelID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC10
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC11
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient12).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC12
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient13).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC13
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient14).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC14
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient15).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC15

        tdbg.Splits(2).DisplayColumns(COLS_OfficalTitleID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC2
        tdbg.Splits(2).DisplayColumns(COLS_SalaryLevelID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC20
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC21
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient22).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC22
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient23).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC23
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient24).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC24
        tdbg.Splits(2).DisplayColumns(COLS_SaCoefficient25).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC25

        tdbg.Splits(2).DisplayColumns(COLS_P01).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P01
        tdbg.Splits(2).DisplayColumns(COLS_P02).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P02
        tdbg.Splits(2).DisplayColumns(COLS_P03).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P03
        tdbg.Splits(2).DisplayColumns(COLS_P04).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P04
        tdbg.Splits(2).DisplayColumns(COLS_P05).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P05
        tdbg.Splits(2).DisplayColumns(COLS_P06).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P06
        tdbg.Splits(2).DisplayColumns(COLS_P07).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P07
        tdbg.Splits(2).DisplayColumns(COLS_P08).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P08
        tdbg.Splits(2).DisplayColumns(COLS_P09).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P09
        tdbg.Splits(2).DisplayColumns(COLS_P10).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P10
        tdbg.Splits(2).DisplayColumns(COLS_P11).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P11
        tdbg.Splits(2).DisplayColumns(COLS_P12).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P12
        tdbg.Splits(2).DisplayColumns(COLS_P13).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P13
        tdbg.Splits(2).DisplayColumns(COLS_P14).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P14
        tdbg.Splits(2).DisplayColumns(COLS_P15).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P15
        tdbg.Splits(2).DisplayColumns(COLS_P16).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P16
        tdbg.Splits(2).DisplayColumns(COLS_P17).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P17
        tdbg.Splits(2).DisplayColumns(COLS_P18).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P18
        tdbg.Splits(2).DisplayColumns(COLS_P19).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P19
        tdbg.Splits(2).DisplayColumns(COLS_P20).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P20

        'update 27/12/2012 id 52980
        tdbg.Splits(2).DisplayColumns(COLS_Ref01).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref01
        tdbg.Splits(2).DisplayColumns(COLS_Ref02).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref02
        tdbg.Splits(2).DisplayColumns(COLS_Ref03).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref03
        tdbg.Splits(2).DisplayColumns(COLS_Ref04).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref04
        tdbg.Splits(2).DisplayColumns(COLS_Ref05).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.Ref05

        tdbg.Splits(2).DisplayColumns(COLS_NumRef01).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef01
        tdbg.Splits(2).DisplayColumns(COLS_NumRef02).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef02
        tdbg.Splits(2).DisplayColumns(COLS_NumRef03).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef03
        tdbg.Splits(2).DisplayColumns(COLS_NumRef04).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef04
        tdbg.Splits(2).DisplayColumns(COLS_NumRef05).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef05
        tdbg.Splits(2).DisplayColumns(COLS_NumRef06).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef06
        tdbg.Splits(2).DisplayColumns(COLS_NumRef07).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef07
        tdbg.Splits(2).DisplayColumns(COLS_NumRef08).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef08
        tdbg.Splits(2).DisplayColumns(COLS_NumRef09).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef09
        tdbg.Splits(2).DisplayColumns(COLS_NumRef10).Visible = Math.Abs(button - button.InfoOther) = 0 And bInfoOther.NumRef10

        Dim bButtonNextBaseSalary As Boolean = Math.Abs(button - button.NextBaseSalary) = 0
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary01DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary02DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary03DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary04DateEnd).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary01NextDate).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary02NextDate).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary03NextDate).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(2).DisplayColumns(COLS_BaseSalary04NextDate).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(2).DisplayColumns(COLS_NextBaseSalary01).Visible = bButtonNextBaseSalary And bBA.BASE01
        tdbg.Splits(2).DisplayColumns(COLS_NextBaseSalary02).Visible = bButtonNextBaseSalary And bBA.BASE02
        tdbg.Splits(2).DisplayColumns(COLS_NextBaseSalary03).Visible = bButtonNextBaseSalary And bBA.BASE03
        tdbg.Splits(2).DisplayColumns(COLS_NextBaseSalary04).Visible = bButtonNextBaseSalary And bBA.BASE04

        tdbg.Splits(2).DisplayColumns(COLS_Sal01DateEnd).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(2).DisplayColumns(COLS_Sal02DateEnd).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(2).DisplayColumns(COLS_Sal03DateEnd).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(2).DisplayColumns(COLS_Sal04DateEnd).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(2).DisplayColumns(COLS_Sal05DateEnd).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(2).DisplayColumns(COLS_Sal06DateEnd).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(2).DisplayColumns(COLS_Sal07DateEnd).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(2).DisplayColumns(COLS_Sal08DateEnd).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(2).DisplayColumns(COLS_Sal09DateEnd).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(2).DisplayColumns(COLS_Sal10DateEnd).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(2).DisplayColumns(COLS_Sal11DateEnd).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(2).DisplayColumns(COLS_Sal12DateEnd).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(2).DisplayColumns(COLS_Sal13DateEnd).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(2).DisplayColumns(COLS_Sal14DateEnd).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(2).DisplayColumns(COLS_Sal15DateEnd).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(2).DisplayColumns(COLS_Sal16DateEnd).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(2).DisplayColumns(COLS_Sal17DateEnd).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(2).DisplayColumns(COLS_Sal18DateEnd).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(2).DisplayColumns(COLS_Sal19DateEnd).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(2).DisplayColumns(COLS_Sal20DateEnd).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(2).DisplayColumns(COLS_Sal01NextDate).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(2).DisplayColumns(COLS_Sal02NextDate).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(2).DisplayColumns(COLS_Sal03NextDate).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(2).DisplayColumns(COLS_Sal04NextDate).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(2).DisplayColumns(COLS_Sal05NextDate).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(2).DisplayColumns(COLS_Sal06NextDate).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(2).DisplayColumns(COLS_Sal07NextDate).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(2).DisplayColumns(COLS_Sal08NextDate).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(2).DisplayColumns(COLS_Sal09NextDate).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(2).DisplayColumns(COLS_Sal10NextDate).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(2).DisplayColumns(COLS_Sal11NextDate).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(2).DisplayColumns(COLS_Sal12NextDate).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(2).DisplayColumns(COLS_Sal13NextDate).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(2).DisplayColumns(COLS_Sal14NextDate).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(2).DisplayColumns(COLS_Sal15NextDate).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(2).DisplayColumns(COLS_Sal16NextDate).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(2).DisplayColumns(COLS_Sal17NextDate).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(2).DisplayColumns(COLS_Sal18NextDate).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(2).DisplayColumns(COLS_Sal19NextDate).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(2).DisplayColumns(COLS_Sal20NextDate).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient01).Visible = bButtonNextBaseSalary And bCE.CE01
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient02).Visible = bButtonNextBaseSalary And bCE.CE02
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient03).Visible = bButtonNextBaseSalary And bCE.CE03
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient04).Visible = bButtonNextBaseSalary And bCE.CE04
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient05).Visible = bButtonNextBaseSalary And bCE.CE05
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient06).Visible = bButtonNextBaseSalary And bCE.CE06
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient07).Visible = bButtonNextBaseSalary And bCE.CE07
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient08).Visible = bButtonNextBaseSalary And bCE.CE08
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient09).Visible = bButtonNextBaseSalary And bCE.CE09
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient10).Visible = bButtonNextBaseSalary And bCE.CE10
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient11).Visible = bButtonNextBaseSalary And bCE.CE11
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient12).Visible = bButtonNextBaseSalary And bCE.CE12
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient13).Visible = bButtonNextBaseSalary And bCE.CE13
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient14).Visible = bButtonNextBaseSalary And bCE.CE14
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient15).Visible = bButtonNextBaseSalary And bCE.CE15
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient16).Visible = bButtonNextBaseSalary And bCE.CE16
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient17).Visible = bButtonNextBaseSalary And bCE.CE17
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient18).Visible = bButtonNextBaseSalary And bCE.CE18
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient19).Visible = bButtonNextBaseSalary And bCE.CE19
        tdbg.Splits(2).DisplayColumns(COLS_NextSalCoefficient20).Visible = bButtonNextBaseSalary And bCE.CE20

        tdbg.Splits(2).DisplayColumns(COLS_OffSa1DateEnd).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(2).DisplayColumns(COLS_OffSa1NextDate).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(2).DisplayColumns(COLS_NextOfficalTitleID).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC1
        tdbg.Splits(2).DisplayColumns(COLS_NextSalaryLevelID).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC11 'ID 82176 chuyển qua nút Lương tiếp theo

        tdbg.Splits(2).DisplayColumns(COLS_OffSa2DateEnd).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(2).DisplayColumns(COLS_OffSa2NextDate).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(2).DisplayColumns(COLS_NextOfficalTitleID2).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC2
        tdbg.Splits(2).DisplayColumns(COLS_NextSalaryLevelID2).Visible = Math.Abs(button - button.NextBaseSalary) = 0 And bOL.OLSC21 'ID 82176 chuyển qua nút Lương tiếp theo

    End Sub

    Private Sub btnSalaryCoefficientBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryCoefficientBase.Click
        tdbg.Splits(2).Caption = rl3("Luong_co_ban_He_so")
        ClickButton(Button.SalaryCoefficientBase)
    End Sub

    Private Sub btnIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncome.Click
        tdbg.Splits(2).Caption = rl3("Thu_nhap")
        ClickButton(Button.Income)
    End Sub

    Private Sub btnAnalyseCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyseCode.Click
        tdbg.Splits(2).Caption = rl3("Ma_phan_tich")
        ClickButton(Button.AnalyseCode)
    End Sub

    ' 13/1/2014 id 60442
    Private Sub btnNextBaseSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextBaseSalary.Click
        tdbg.Splits(2).Caption = rl3("Luong_tiep_theo")
        ClickButton(Button.NextBaseSalary)
    End Sub

    Private Sub btnAnalyseSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyseSalary.Click
        tdbg.Splits(2).Caption = rl3("Ma_phan_tich_tien_luong")
        ClickButton(Button.AnalyseSalary)
    End Sub

    Private Sub btnSalaryLevelOfficialTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryLevelOfficialTitle.Click
        bFlag = True
        tdbg.Splits(2).Caption = rl3("Ngach_bac_luong")
        ClickButton(Button.SalaryLevelOfficialTitle)
    End Sub

    ' update 27/12/2012 id 52980
    Private Sub btnInfoOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfoOther.Click
        tdbg.Splits(2).Caption = rl3("Thong_tin_khac")
        ClickButton(Button.InfoOther)
    End Sub

    Dim dtSalaryLevelID, dtSal As DataTable
    Private Sub LoadtdbdSalaryLevelID(ByVal ID As String, ByVal sIsUseOfficial As String)
        Dim sSQL As String = ""
        'Load tdbdSalaryLevelID
        LoadCaptiontdbdSalaryLevelID(sIsUseOfficial)
        'sSQL &= "Select SalaryLevelID, SalaryCoefficient, SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, OfficialTitleID, Grade From D09T0215  WITH(NOLOCK) Where Disabled = 0 And OfficialTitleID = " & SQLString(ID) & " ORDER BY 	Grade "
        dtSal = ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID = " & SQLString(ID), True)
        LoadDataSource(tdbdSalaryLevelID, dtSal.DefaultView.ToTable, gbUnicode)
        tdbdSalaryLevelID.HeadingStyle.Font = New Font("Lemon3", 8.249999!)
        tdbdSalaryLevelID_NumberFormat(sIsUseOfficial)
    End Sub

    Private Sub tdbdSalaryLevelID_NumberFormat(ByVal sIsUseOfficial As String)
        For i As Integer = 0 To dtOLSC.Rows.Count - 1
            If sIsUseOfficial = "1" Then
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC11"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC12"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC13"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC14"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC15"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                End Select
            ElseIf sIsUseOfficial = "2" Then
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC21"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC22"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC23"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC24"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    Case "OLSC25"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                End Select
            End If
        Next
    End Sub

    Private Sub LoadCaptiontdbdSalaryLevelID(ByVal sIsUseOfficial As String)
        For i As Integer = 0 To dtOLSC.Rows.Count - 1
            If sIsUseOfficial = "1" Then

                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC10"
                        tdbdSalaryLevelID.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                    Case "OLSC11"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC12"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC13"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC14"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC15"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                End Select
            ElseIf sIsUseOfficial = "2" Then
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC20"
                        tdbdSalaryLevelID.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                    Case "OLSC21"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC22"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC23"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC24"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                    Case "OLSC25"
                        tdbdSalaryLevelID.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbdSalaryLevelID.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                End Select

            End If
        Next
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLS_TaxObjectName
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COLS_TaxObjectID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COLS_TaxObjectID).Text = tdbdTaxObjectID.Columns("TaxObjectID").Text

            Case COLS_OffSa1DateEnd
                'If tdbg.Columns(e.ColIndex).Text <> "" Then
                '    Dim dOffSa1DateEnd As Date
                '    dOffSa1DateEnd = CDate(tdbg.Columns(e.ColIndex).Value)
                '    Dim _dt As DataTable = ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID = " & SQLString(tdbg.Columns(COLS_OfficalTitleID).Text) & " AND SalaryLevelID = " & SQLString(tdbg.Columns(COLS_SalaryLevelID).Text), True)
                '    If _dt IsNot Nothing AndAlso _dt.Rows.Count > 0 Then tdbg.Columns(COLS_OffSa1NextDate).Value = dOffSa1DateEnd.AddMonths(L3Int(_dt.Rows(0)("NumberYearTransfer")))
                'Else
                '    tdbg.Columns(COLS_OffSa1NextDate).Text = ""
                'End If

                CalOffSalDate(COLS_OffSa1NextDate, tdbg.Columns(COLS_OfficalTitleID).Text, tdbg.Columns(COLS_SalaryLevelID).Text)

            Case COLS_OffSa2DateEnd
                'If tdbg.Columns(e.ColIndex).Text <> "" Then
                '    Dim dOffSa1DateEnd As Date
                '    dOffSa1DateEnd = CDate(tdbg.Columns(e.ColIndex).Value)
                '    Dim _dt As DataTable = ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID = " & SQLString(tdbg.Columns(COLS_OfficalTitleID2).Text) & " AND SalaryLevelID = " & SQLString(tdbg.Columns(COLS_SalaryLevelID2).Text), True)
                '    If _dt IsNot Nothing AndAlso _dt.Rows.Count > 0 Then tdbg.Columns(COLS_OffSa2NextDate).Value = dOffSa1DateEnd.AddMonths(L3Int(_dt.Rows(0)("NumberYearTransfer")))
                'Else
                '    tdbg.Columns(COLS_OffSa2NextDate).Text = ""
                'End If
                CalOffSalDate(COLS_OffSa2NextDate, tdbg.Columns(COLS_OfficalTitleID2).Text, tdbg.Columns(COLS_SalaryLevelID2).Text)
        End Select
        bNotInList = False
    End Sub



    Private Sub CalOffSalDate(ByVal sColCal As Integer, ByVal sOfficalTitleID As String, ByVal sSalaryLevelID As String)
        If tdbg.Columns(tdbg.Col).Text <> "" Then
            Dim dOffSa1DateEnd As Date
            dOffSa1DateEnd = CDate(tdbg.Columns(tdbg.Col).Value)
            Dim _dt As DataTable = ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID = " & SQLString(sOfficalTitleID) & " AND SalaryLevelID = " & SQLString(sSalaryLevelID), True)
            If _dt IsNot Nothing AndAlso _dt.Rows.Count > 0 Then
                tdbg.Columns(sColCal).Value = dOffSa1DateEnd.AddMonths(L3Int(_dt.Rows(0)("NumberYearTransfer")))
            Else
                tdbg.Columns(sColCal).Text = ""
            End If
        Else
            tdbg.Columns(sColCal).Text = ""
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect

        Select Case e.ColIndex
            Case COLS_TaxObjectName
                tdbg.Columns(COLS_TaxObjectID).Text = tdbdTaxObjectID.Columns("TaxObjectID").Text
                'tdbg.Columns(COLS_TaxObjectName).Text = tdbdTaxObjectID.Columns("TaxObjectName").Text
            Case COLS_OfficalTitleID
                tdbg.Columns(COLS_OfficalTitleID).Text = tdbdOfficialTitleID.Columns("OfficialTitleID").Text
                tdbg.Columns(COLS_NextOfficalTitleID).Text = tdbdOfficialTitleID.Columns("OfficialTitleID").Text
                tdbg.Columns(COLS_SalaryLevelID).Text = ""
                tdbg.Columns(COLS_SaCoefficient).Text = ""
                tdbg.Columns(COLS_SaCoefficient12).Text = ""
                tdbg.Columns(COLS_SaCoefficient13).Text = ""
                tdbg.Columns(COLS_SaCoefficient14).Text = ""
                tdbg.Columns(COLS_SaCoefficient15).Text = ""
            Case COLS_SalaryLevelID
                tdbg.Columns(COLS_SalaryLevelID).Text = tdbdSalaryLevelID.Columns("SalaryLevelID").Text
                tdbg.Columns(COLS_SaCoefficient).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient").Text
                tdbg.Columns(COLS_SaCoefficient12).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COLS_SaCoefficient13).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COLS_SaCoefficient14).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COLS_SaCoefficient15).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient05").Text
                tdbg.Columns(COLS_NextSalaryLevelID).Text = GetNextSalaryLevelID()
            Case COLS_OfficalTitleID2
                tdbg.Columns(COLS_OfficalTitleID2).Text = tdbdOfficialTitleID2.Columns("OfficialTitleID").Text
                tdbg.Columns(COLS_NextOfficalTitleID2).Text = tdbdOfficialTitleID2.Columns("OfficialTitleID").Text
                tdbg.Columns(COLS_SalaryLevelID2).Text = ""
                tdbg.Columns(COLS_SaCoefficient2).Text = ""
                tdbg.Columns(COLS_SaCoefficient22).Text = ""
                tdbg.Columns(COLS_SaCoefficient23).Text = ""
                tdbg.Columns(COLS_SaCoefficient24).Text = ""
                tdbg.Columns(COLS_SaCoefficient25).Text = ""
            Case COLS_SalaryLevelID2
                tdbg.Columns(COLS_SalaryLevelID2).Text = tdbdSalaryLevelID.Columns("SalaryLevelID").Text
                tdbg.Columns(COLS_SaCoefficient2).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient").Text
                tdbg.Columns(COLS_SaCoefficient22).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COLS_SaCoefficient23).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COLS_SaCoefficient24).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COLS_SaCoefficient25).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient05").Text
                tdbg.Columns(COLS_NextSalaryLevelID2).Text = GetNextSalaryLevelID()
        End Select
    End Sub

    Private Function GetNextSalaryLevelID() As String
        Dim sRet As String = ""
        Try
            Dim iRow As Integer = tdbdSalaryLevelID.Row
            If iRow > dtSal.Rows.Count - 1 OrElse iRow = dtSal.Rows.Count - 1 Then
                Return ""
            Else
                sRet = L3String(dtSal.Rows(iRow + 1)("SalaryLevelID"))
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return sRet
    End Function


    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COLS_DepartmentID
                e.CellTip = tdbg.Columns(COLS_DepartmentName).Text
            Case COLS_TeamID
                e.CellTip = tdbg.Columns(COLS_TeamName).Text
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COLS_N01, COLS_N02, COLS_N03, COLS_N04, COLS_N05, COLS_N06, COLS_N07, COLS_N08, COLS_N09, COLS_N10, _
                            COLS_N11, COLS_N12, COLS_N13, COLS_N14, COLS_N15, COLS_N16, COLS_N17, COLS_N18, COLS_N19, COLS_N20
                If tdbg.Columns(e.ColIndex).Text <> tdbdNCodeID.Columns("NCodeID").Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If

            Case COLS_TaxObjectName
                If tdbg.Columns(COLS_TaxObjectName).Text <> tdbdTaxObjectID.Columns("TaxObjectName").Text Then
                    bNotInList = True
                    tdbg.Columns(COLS_TaxObjectID).Text = ""
                    tdbg.Columns(COLS_TaxObjectName).Text = ""
                End If

            Case COLS_StandardAbsentQuan
                If Not IsNumeric(tdbg.Columns(e.ColIndex).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_BASE01
                If Not IsNumeric(tdbg.Columns(COLS_BASE01).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_BASE02
                If Not IsNumeric(tdbg.Columns(COLS_BASE02).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_BASE03
                If Not IsNumeric(tdbg.Columns(COLS_BASE03).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_BASE04
                If Not IsNumeric(tdbg.Columns(COLS_BASE04).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_CE01, COLS_CE02, COLS_CE03, COLS_CE04, COLS_CE05, COLS_CE06, COLS_CE07, COLS_CE08, COLS_CE09, COLS_CE10, COLS_CE11, COLS_CE12, COLS_CE13, COLS_CE14, COLS_CE15, COLS_CE16, COLS_CE17, COLS_CE18, COLS_CE19, COLS_CE20
                If Not IsNumeric(tdbg.Columns(e.ColIndex).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC01
                If Not IsNumeric(tdbg.Columns(COLS_INC01).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC02
                If Not IsNumeric(tdbg.Columns(COLS_INC02).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC03
                If Not IsNumeric(tdbg.Columns(COLS_INC03).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC04
                If Not IsNumeric(tdbg.Columns(COLS_INC04).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC05
                If Not IsNumeric(tdbg.Columns(COLS_INC05).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC06
                If Not IsNumeric(tdbg.Columns(COLS_INC06).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC07
                If Not IsNumeric(tdbg.Columns(COLS_INC07).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC08
                If Not IsNumeric(tdbg.Columns(COLS_INC08).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC09
                If Not IsNumeric(tdbg.Columns(COLS_INC09).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC10
                If Not IsNumeric(tdbg.Columns(COLS_INC10).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC11
                If Not IsNumeric(tdbg.Columns(COLS_INC11).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC12
                If Not IsNumeric(tdbg.Columns(COLS_INC12).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC13
                If Not IsNumeric(tdbg.Columns(COLS_INC13).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC14
                If Not IsNumeric(tdbg.Columns(COLS_INC14).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC15
                If Not IsNumeric(tdbg.Columns(COLS_INC15).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC16
                If Not IsNumeric(tdbg.Columns(COLS_INC16).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC17
                If Not IsNumeric(tdbg.Columns(COLS_INC17).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC18
                If Not IsNumeric(tdbg.Columns(COLS_INC18).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC19
                If Not IsNumeric(tdbg.Columns(COLS_INC19).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC20
                If Not IsNumeric(tdbg.Columns(COLS_INC20).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC21
                If Not IsNumeric(tdbg.Columns(COLS_INC21).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC22
                If Not IsNumeric(tdbg.Columns(COLS_INC22).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC23
                If Not IsNumeric(tdbg.Columns(COLS_INC23).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC24
            Case COLS_INC25
                If Not IsNumeric(tdbg.Columns(COLS_INC25).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC26
                If Not IsNumeric(tdbg.Columns(COLS_INC26).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC27
                If Not IsNumeric(tdbg.Columns(COLS_INC27).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC28
                If Not IsNumeric(tdbg.Columns(COLS_INC28).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC29
                If Not IsNumeric(tdbg.Columns(COLS_INC29).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_INC30
                If Not IsNumeric(tdbg.Columns(COLS_INC30).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_OfficalTitleID
                If tdbg.Columns(COLS_OfficalTitleID).Text <> tdbdOfficialTitleID.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COLS_OfficalTitleID).Text = ""
                    tdbg.Columns(COLS_SalaryLevelID).Text = ""
                    tdbg.Columns(COLS_SaCoefficient).Text = ""
                    tdbg.Columns(COLS_SaCoefficient12).Text = ""
                    tdbg.Columns(COLS_SaCoefficient13).Text = ""
                    tdbg.Columns(COLS_SaCoefficient14).Text = ""
                    tdbg.Columns(COLS_SaCoefficient15).Text = ""
                End If
            Case COLS_SalaryLevelID
                If tdbg.Columns(COLS_SalaryLevelID).Text <> tdbdSalaryLevelID.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COLS_SalaryLevelID).Text = ""
                    tdbg.Columns(COLS_SaCoefficient).Text = ""
                    tdbg.Columns(COLS_SaCoefficient12).Text = ""
                    tdbg.Columns(COLS_SaCoefficient13).Text = ""
                    tdbg.Columns(COLS_SaCoefficient14).Text = ""
                    tdbg.Columns(COLS_SaCoefficient15).Text = ""
                End If
            Case COLS_SaCoefficient
                If Not IsNumeric(tdbg.Columns(COLS_SaCoefficient).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_OfficalTitleID2
                If tdbg.Columns(COLS_OfficalTitleID2).Text <> tdbdOfficialTitleID2.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COLS_OfficalTitleID2).Text = ""
                    tdbg.Columns(COLS_SalaryLevelID2).Text = ""
                    tdbg.Columns(COLS_SaCoefficient2).Text = ""
                    tdbg.Columns(COLS_SaCoefficient22).Text = ""
                    tdbg.Columns(COLS_SaCoefficient23).Text = ""
                    tdbg.Columns(COLS_SaCoefficient24).Text = ""
                    tdbg.Columns(COLS_SaCoefficient25).Text = ""
                End If
            Case COLS_SalaryLevelID2
                If tdbg.Columns(COLS_SalaryLevelID2).Text <> tdbdSalaryLevelID.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COLS_SalaryLevelID2).Text = ""
                    tdbg.Columns(COLS_SaCoefficient2).Text = ""
                    tdbg.Columns(COLS_SaCoefficient22).Text = ""
                    tdbg.Columns(COLS_SaCoefficient23).Text = ""
                    tdbg.Columns(COLS_SaCoefficient24).Text = ""
                    tdbg.Columns(COLS_SaCoefficient25).Text = ""
                End If
            Case COLS_SaCoefficient2
                If Not IsNumeric(tdbg.Columns(COLS_SaCoefficient2).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_PaymentMethod
                If tdbg.Columns(COLS_PaymentMethod).Text <> tdbdPaymentMethod.Columns("PaymentMethod").Text Then
                    tdbg.Columns(COLS_PaymentMethod).Text = ""
                End If
            Case COLS_P01
                If tdbg.Columns(COLS_P01).Text <> tdbdPAna01ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P01).Text = ""
                End If
            Case COLS_P02
                If tdbg.Columns(COLS_P02).Text <> tdbdPAna02ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P02).Text = ""
                End If
            Case COLS_P03
                If tdbg.Columns(COLS_P03).Text <> tdbdPAna03ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P03).Text = ""
                End If
            Case COLS_P04
                If tdbg.Columns(COLS_P04).Text <> tdbdPAna04ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P04).Text = ""
                End If
            Case COLS_P05
                If tdbg.Columns(COLS_P05).Text <> tdbdPAna05ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P05).Text = ""
                End If
            Case COLS_P06
                If tdbg.Columns(COLS_P06).Text <> tdbdPAna06ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P06).Text = ""
                End If
            Case COLS_P07
                If tdbg.Columns(COLS_P07).Text <> tdbdPAna07ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P07).Text = ""
                End If
            Case COLS_P08
                If tdbg.Columns(COLS_P08).Text <> tdbdPAna08ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P08).Text = ""
                End If
            Case COLS_P09
                If tdbg.Columns(COLS_P09).Text <> tdbdPAna09ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P09).Text = ""
                End If
            Case COLS_P10
                If tdbg.Columns(COLS_P10).Text <> tdbdPAna10ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P10).Text = ""
                End If
            Case COLS_P11
                If tdbg.Columns(COLS_P11).Text <> tdbdPAna11ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P11).Text = ""
                End If
            Case COLS_P12
                If tdbg.Columns(COLS_P12).Text <> tdbdPAna12ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P12).Text = ""
                End If
            Case COLS_P13
                If tdbg.Columns(COLS_P13).Text <> tdbdPAna13ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P13).Text = ""
                End If
            Case COLS_P14
                If tdbg.Columns(COLS_P14).Text <> tdbdPAna14ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P14).Text = ""
                End If
            Case COLS_P15
                If tdbg.Columns(COLS_P15).Text <> tdbdPAna15ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P15).Text = ""
                End If
            Case COLS_P16
                If tdbg.Columns(COLS_P16).Text <> tdbdPAna16ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P16).Text = ""
                End If
            Case COLS_P17
                If tdbg.Columns(COLS_P17).Text <> tdbdPAna17ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P17).Text = ""
                End If
            Case COLS_P18
                If tdbg.Columns(COLS_P18).Text <> tdbdPAna18ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P18).Text = ""
                End If
            Case COLS_P19
                If tdbg.Columns(COLS_P19).Text <> tdbdPAna19ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P19).Text = ""
                End If
            Case COLS_P20
                If tdbg.Columns(COLS_P20).Text <> tdbdPAna20ID.Columns("PAnaID").Text Then
                    tdbg.Columns(COLS_P20).Text = ""
                End If
            Case COLS_NextBaseSalary01 To COLS_NextBaseSalary04
                If Not IsNumeric(tdbg.Columns(e.ColIndex).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_NextSalCoefficient01 To COLS_NextSalCoefficient20
                If Not IsNumeric(tdbg.Columns(e.ColIndex).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_NumRef01 To COLS_NumRef10
                If Not IsNumeric(tdbg.Columns(e.ColIndex).Text) Then tdbg.Columns(e.ColIndex).Text = "0" ' e.Cancel = True
            Case COLS_BaseCurrencyID01, COLS_BaseCurrencyID02, COLS_BaseCurrencyID03, COLS_BaseCurrencyID04, COLS_SalCoeCurrencyID01, COLS_SalCoeCurrencyID02, COLS_SalCoeCurrencyID03, COLS_SalCoeCurrencyID04, COLS_SalCoeCurrencyID05, COLS_SalCoeCurrencyID06, COLS_SalCoeCurrencyID07, COLS_SalCoeCurrencyID08, COLS_SalCoeCurrencyID09, COLS_SalCoeCurrencyID10, COLS_SalCoeCurrencyID11, COLS_SalCoeCurrencyID12, COLS_SalCoeCurrencyID13, COLS_SalCoeCurrencyID14, COLS_SalCoeCurrencyID15, COLS_SalCoeCurrencyID16, COLS_SalCoeCurrencyID17, COLS_SalCoeCurrencyID18, COLS_SalCoeCurrencyID19, COLS_SalCoeCurrencyID20
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If

            Case COLS_NextOfficalTitleID, COLS_NextSalaryLevelID, COLS_NextOfficalTitleID2, COLS_NextSalaryLevelID2
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COLS_SalaryLevelID
                LoadtdbdSalaryLevelID(tdbg.Columns(COLS_OfficalTitleID).Text, "1")
            Case COLS_SalaryLevelID2
                LoadtdbdSalaryLevelID(tdbg.Columns(COLS_OfficalTitleID2).Text, "2")
            Case COLS_NextSalaryLevelID
                LoadtdbdSalaryLevelID(tdbg.Columns(COLS_NextOfficalTitleID).Text, "1")
            Case COLS_NextSalaryLevelID2
                LoadtdbdSalaryLevelID(tdbg.Columns(COLS_NextOfficalTitleID2).Text, "2")

            Case COLS_N01, COLS_N02, COLS_N03, COLS_N04, COLS_N05, COLS_N06, COLS_N07, COLS_N08, COLS_N09, COLS_N10, _
                  COLS_N11, COLS_N12, COLS_N13, COLS_N14, COLS_N15, COLS_N16, COLS_N17, COLS_N18, COLS_N19, COLS_N20
                LoadTdbdNCodeID(tdbg.Columns(tdbg.Col).DataField.ToString)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            '            Case COLS_StandardAbsentQuan
            '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_BASE01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_BASE02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_BASE03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_BASE04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_CE01, COLS_CE02, COLS_CE03, COLS_CE04, COLS_CE05, COLS_CE06, COLS_CE07, COLS_CE08, COLS_CE09, COLS_CE10, COLS_CE11, COLS_CE12, COLS_CE13, COLS_CE14, COLS_CE15, COLS_CE16, COLS_CE17, COLS_CE18, COLS_CE19, COLS_CE20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE02
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE03
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE04
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE05
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE06
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE07
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE08
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE09
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COLS_CE10
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC06
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC07
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC08
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC09
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC11
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC12
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC13
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC14
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC15
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC16
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC17
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC18
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC19
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC21
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC22
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC23
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC24
            Case COLS_INC25
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC26
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC27
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC28
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC29
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_INC30
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_OfficalTitleID
            Case COLS_SalaryLevelID
            Case COLS_SaCoefficient
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_OfficalTitleID2
            Case COLS_SalaryLevelID2
            Case COLS_SaCoefficient2
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_NextBaseSalary01 To COLS_NextBaseSalary01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_NextSalCoefficient01 To COLS_NextSalCoefficient20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_NumRef01 To COLS_NumRef10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub HeadClickOfficalTitleID(sCol As Integer, sColCopy() As Integer)
        Try
            If tdbg.RowCount < 2 OrElse tdbg.Splits(tdbg.SplitIndex).DisplayColumns(sCol).Locked Then Exit Sub
            Dim Flag As DialogResult
            'Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Flag = Windows.Forms.DialogResult.Cancel Then Exit Sub
            tdbg.UpdateData()
            Dim RowCopy As Integer = tdbg.Row
            Dim sValueCopy As String
            sValueCopy = tdbg.Columns(sCol).Text
            For i As Integer = RowCopy + 1 To tdbg.RowCount - 1
                If Flag = Windows.Forms.DialogResult.No Then
                    If L3String(tdbg(i, sCol)) = "" Then
                        For iColRe As Integer = 0 To sColCopy.Length - 1
                            tdbg(i, sColCopy(iColRe)) = ""
                        Next
                        'Copy cột Ngạch lương
                        tdbg(i, sCol) = sValueCopy
                    End If
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then
                    For iColRe As Integer = 0 To sColCopy.Length - 1
                        If L3String(tdbg(i, sCol)) <> sValueCopy Then ' Bằng ngạch lương
                            tdbg(i, sColCopy(iColRe)) = "" 'tdbg(RowCopy, sColCopy(iColRe)) 'Copy những cột có liên quan
                        End If
                    Next
                    'Copy cột Ngạch lương
                    tdbg(i, sCol) = sValueCopy
                End If
            Next
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub HeadClickSalaryLevelID(sCol As Integer, sColRelative As Integer, sColCopy() As Integer)
        Try
            If tdbg.RowCount < 2 OrElse tdbg.Splits(tdbg.SplitIndex).DisplayColumns(sCol).Locked Then Exit Sub
            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Flag = Windows.Forms.DialogResult.Cancel Then Exit Sub
            tdbg.UpdateData()
            Dim RowCopy As Integer = tdbg.Row
            Dim sValueCopy, sValueReletive As String
            sValueCopy = tdbg.Columns(sCol).Text
            sValueReletive = tdbg.Columns(sColRelative).Text
            For i As Integer = RowCopy + 1 To tdbg.RowCount - 1
                If Flag = Windows.Forms.DialogResult.No Then
                    If L3String(tdbg(i, sCol)) = "" AndAlso L3String(tdbg(i, sColRelative)) = sValueReletive Then
                        For iColRe As Integer = 0 To sColCopy.Length - 1
                            tdbg(i, sColCopy(iColRe)) = tdbg(RowCopy, sColCopy(iColRe))
                        Next
                        'Copy cột Ngạch lương
                        tdbg(i, sCol) = sValueCopy
                    End If
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then
                    If L3String(tdbg(i, sColRelative)) = sValueReletive Then
                        For iColRe As Integer = 0 To sColCopy.Length - 1
                            tdbg(i, sColCopy(iColRe)) = tdbg(RowCopy, sColCopy(iColRe))
                        Next
                        'Copy cột Ngạch lương
                        tdbg(i, sCol) = sValueCopy
                    End If
                End If
            Next
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            ' update 15/5/2013 id 56381
            Case COLS_TaxObjectName
                tdbg.Columns(COLS_TaxObjectID).Text = tdbdTaxObjectID.Columns("TaxObjectID").Text
                Dim arr() As Integer = {COLS_TaxObjectID, COLS_TaxObjectName}
                CopyColumnArr(tdbg, iCol, arr)
            Case COLS_StandardAbsentQuan, COLS_ValidDateFrom, COLS_ValidDateTo, COLS_BASE01, COLS_BASE02, COLS_BASE03, COLS_BASE04, COLS_CE01, COLS_CE02, COLS_CE03, COLS_CE04, COLS_CE05, COLS_CE06, COLS_CE07, COLS_CE08, COLS_CE09, COLS_CE10, COLS_CE11, COLS_CE12, COLS_CE13, COLS_CE14, COLS_CE15, COLS_CE16, COLS_CE17, COLS_CE18, COLS_CE19, COLS_CE20, COLS_INC01, COLS_INC02, COLS_INC03, COLS_INC04, COLS_INC05, COLS_INC06, COLS_INC07, COLS_INC08, COLS_INC09, COLS_INC10, COLS_INC11, COLS_INC12, COLS_INC13, COLS_INC14, COLS_INC15, COLS_INC16, COLS_INC17, COLS_INC18, COLS_INC19, COLS_INC20, COLS_INC21, COLS_INC22, COLS_INC23, COLS_INC24, COLS_INC25, COLS_INC26, COLS_INC27, COLS_INC28, COLS_INC29, COLS_INC30, COLS_N01, COLS_N02, COLS_N03, COLS_N04, COLS_N05, COLS_N06, COLS_N07, COLS_N08, COLS_N09, COLS_N10, COLS_N11, COLS_N12, COLS_N13, COLS_N14, COLS_N15, COLS_N16, COLS_N17, COLS_N18, COLS_N19, COLS_N20, COLS_Ref01, COLS_Ref02, COLS_Ref03, COLS_Ref04, COLS_Ref05, COLS_PaymentMethod
                tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
            Case COLS_OfficalTitleID ' ID 84642
                Dim arr() As Integer = {COLS_SalaryLevelID, COLS_SaCoefficient, COLS_SaCoefficient12, COLS_SaCoefficient13, COLS_SaCoefficient14, COLS_SaCoefficient15}
                HeadClickOfficalTitleID(COLS_OfficalTitleID, arr)
            Case COLS_OfficalTitleID2 ' ID 84642
                Dim arr() As Integer = {COLS_SalaryLevelID2, COLS_SaCoefficient2, COLS_SaCoefficient22, COLS_SaCoefficient23, COLS_SaCoefficient24, COLS_SaCoefficient25}
                HeadClickOfficalTitleID(COLS_OfficalTitleID2, arr)

            Case COLS_SalaryLevelID ' ID 84642
                Dim arr() As Integer = {COLS_SaCoefficient, COLS_SaCoefficient12, COLS_SaCoefficient13, COLS_SaCoefficient14, COLS_SaCoefficient15}
                HeadClickSalaryLevelID(COLS_SalaryLevelID, COLS_OfficalTitleID, arr)
            Case COLS_SalaryLevelID2 ' ID 84642
                Dim arr() As Integer = {COLS_SaCoefficient2, COLS_SaCoefficient22, COLS_SaCoefficient23, COLS_SaCoefficient24, COLS_SaCoefficient25}
                HeadClickSalaryLevelID(COLS_SalaryLevelID2, COLS_OfficalTitleID2, arr)

                '****************************************************
            Case COLS_NumRef01 To COLS_NumRef10
                tdbg.AllowSort = False
                'Copy 1 cột
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
                '****************************************************
        End Select
    End Sub

    ' update 22/52/2013 id 56381 - Theo mail chi Thảo - Không cho phép HeadClick, chỉ sử dung Ctrl + S
    'Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
    '    HeadClick(e.ColIndex)
    'End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0101s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 27/02/2007 10:53:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0101s_AddNew() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Update D13T0101 Set "
            sSQL &= "PayrollVoucherID = " & SQLString(_payrollVoucherID) 'varchar[1], NOT NULL
            sSQL &= " Where "
            sSQL &= "TransID = " & SQLString(tdbg(i, COLS_TransID))
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0101s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 27/02/2007 10:53:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0101s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Update D13T0101 Set "
            sSQL &= "IsSub = " & SQLNumber(tdbg(i, COLS_IsSub)) & COMMA 'tinyint, NOT NULL
            sSQL &= "BaseSalary01 = " & SQLMoney(tdbg(i, COLS_BASE01), D13FormatSalary.BASE01) & COMMA 'decimal, NOT NULL
            sSQL &= "BaseSalary02 = " & SQLMoney(tdbg(i, COLS_BASE02), D13FormatSalary.BASE02) & COMMA 'decimal, NOT NULL
            sSQL &= "BaseSalary03 = " & SQLMoney(tdbg(i, COLS_BASE03), D13FormatSalary.BASE03) & COMMA 'decimal, NOT NULL
            sSQL &= "BaseSalary04 = " & SQLMoney(tdbg(i, COLS_BASE04), D13FormatSalary.BASE04) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient01 = " & SQLMoney(tdbg(i, COLS_CE01), D13FormatSalary.CE01) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient02 = " & SQLMoney(tdbg(i, COLS_CE02), D13FormatSalary.CE02) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient03 = " & SQLMoney(tdbg(i, COLS_CE03), D13FormatSalary.CE03) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient04 = " & SQLMoney(tdbg(i, COLS_CE04), D13FormatSalary.CE04) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient05 = " & SQLMoney(tdbg(i, COLS_CE05), D13FormatSalary.CE05) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient06 = " & SQLMoney(tdbg(i, COLS_CE06), D13FormatSalary.CE06) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient07 = " & SQLMoney(tdbg(i, COLS_CE07), D13FormatSalary.CE07) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient08 = " & SQLMoney(tdbg(i, COLS_CE08), D13FormatSalary.CE08) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient09 = " & SQLMoney(tdbg(i, COLS_CE09), D13FormatSalary.CE09) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient10 = " & SQLMoney(tdbg(i, COLS_CE10), D13FormatSalary.CE10) & COMMA 'decimal, NOT NULL
            'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
            sSQL &= "SalCoefficient11 = " & SQLMoney(tdbg(i, COLS_CE11), D13FormatSalary.CE11) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient12 = " & SQLMoney(tdbg(i, COLS_CE12), D13FormatSalary.CE12) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient13 = " & SQLMoney(tdbg(i, COLS_CE13), D13FormatSalary.CE13) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient14 = " & SQLMoney(tdbg(i, COLS_CE14), D13FormatSalary.CE14) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient15 = " & SQLMoney(tdbg(i, COLS_CE15), D13FormatSalary.CE15) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient16 = " & SQLMoney(tdbg(i, COLS_CE16), D13FormatSalary.CE16) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient17 = " & SQLMoney(tdbg(i, COLS_CE17), D13FormatSalary.CE17) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient18 = " & SQLMoney(tdbg(i, COLS_CE18), D13FormatSalary.CE18) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient19 = " & SQLMoney(tdbg(i, COLS_CE19), D13FormatSalary.CE19) & COMMA 'decimal, NOT NULL
            sSQL &= "SalCoefficient20 = " & SQLMoney(tdbg(i, COLS_CE20), D13FormatSalary.CE20) & COMMA 'decimal, NOT NULL

            sSQL &= "TaxObjectID = " & SQLString(tdbg(i, COLS_TaxObjectID)) & COMMA 'varchar[20], NULL
            sSQL &= "SalAmount01 = " & SQLMoney(tdbg(i, COLS_INC01)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount02 = " & SQLMoney(tdbg(i, COLS_INC02)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount03 = " & SQLMoney(tdbg(i, COLS_INC03)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount04 = " & SQLMoney(tdbg(i, COLS_INC04)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount05 = " & SQLMoney(tdbg(i, COLS_INC05)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount06 = " & SQLMoney(tdbg(i, COLS_INC06)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount07 = " & SQLMoney(tdbg(i, COLS_INC07)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount08 = " & SQLMoney(tdbg(i, COLS_INC08)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount09 = " & SQLMoney(tdbg(i, COLS_INC09)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount10 = " & SQLMoney(tdbg(i, COLS_INC10)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount11 = " & SQLMoney(tdbg(i, COLS_INC11)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount12 = " & SQLMoney(tdbg(i, COLS_INC12)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount13 = " & SQLMoney(tdbg(i, COLS_INC13)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount14 = " & SQLMoney(tdbg(i, COLS_INC14)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount15 = " & SQLMoney(tdbg(i, COLS_INC15)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount16 = " & SQLMoney(tdbg(i, COLS_INC16)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount17 = " & SQLMoney(tdbg(i, COLS_INC17)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount18 = " & SQLMoney(tdbg(i, COLS_INC18)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount19 = " & SQLMoney(tdbg(i, COLS_INC19)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount20 = " & SQLMoney(tdbg(i, COLS_INC20)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount21 = " & SQLMoney(tdbg(i, COLS_INC21)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount22 = " & SQLMoney(tdbg(i, COLS_INC22)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount23 = " & SQLMoney(tdbg(i, COLS_INC23)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount24 = " & SQLMoney(tdbg(i, COLS_INC24)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount25 = " & SQLMoney(tdbg(i, COLS_INC25)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount26 = " & SQLMoney(tdbg(i, COLS_INC26)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount27 = " & SQLMoney(tdbg(i, COLS_INC27)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount28 = " & SQLMoney(tdbg(i, COLS_INC28)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount29 = " & SQLMoney(tdbg(i, COLS_INC29)) & COMMA 'decimal, NOT NULL
            sSQL &= "SalAmount30 = " & SQLMoney(tdbg(i, COLS_INC30)) & COMMA 'decimal, NOT NULL
            sSQL &= "N01ID = " & SQLString(tdbg(i, COLS_N01)) & COMMA 'varchar[20], NULL
            sSQL &= "N02ID = " & SQLString(tdbg(i, COLS_N02)) & COMMA 'varchar[20], NULL
            sSQL &= "N03ID = " & SQLString(tdbg(i, COLS_N03)) & COMMA 'varchar[20], NULL
            sSQL &= "N04ID = " & SQLString(tdbg(i, COLS_N04)) & COMMA 'varchar[20], NULL
            sSQL &= "N05ID = " & SQLString(tdbg(i, COLS_N05)) & COMMA 'varchar[20], NULL
            sSQL &= "N06ID = " & SQLString(tdbg(i, COLS_N06)) & COMMA 'varchar[20], NULL
            sSQL &= "N07ID = " & SQLString(tdbg(i, COLS_N07)) & COMMA 'varchar[20], NULL
            sSQL &= "N08ID = " & SQLString(tdbg(i, COLS_N08)) & COMMA 'varchar[20], NULL
            sSQL &= "N09ID = " & SQLString(tdbg(i, COLS_N09)) & COMMA 'varchar[20], NULL
            sSQL &= "N10ID = " & SQLString(tdbg(i, COLS_N10)) & COMMA 'varchar[20], NULL
            sSQL &= "N11ID = " & SQLString(tdbg(i, COLS_N11)) & COMMA 'varchar[20], NULL
            sSQL &= "N12ID = " & SQLString(tdbg(i, COLS_N12)) & COMMA 'varchar[20], NULL
            sSQL &= "N13ID = " & SQLString(tdbg(i, COLS_N13)) & COMMA 'varchar[20], NULL
            sSQL &= "N14ID = " & SQLString(tdbg(i, COLS_N14)) & COMMA 'varchar[20], NULL
            sSQL &= "N15ID = " & SQLString(tdbg(i, COLS_N15)) & COMMA 'varchar[20], NULL
            sSQL &= "N16ID = " & SQLString(tdbg(i, COLS_N16)) & COMMA 'varchar[20], NULL
            sSQL &= "N17ID = " & SQLString(tdbg(i, COLS_N17)) & COMMA 'varchar[20], NULL
            sSQL &= "N18ID = " & SQLString(tdbg(i, COLS_N18)) & COMMA 'varchar[20], NULL
            sSQL &= "N19ID = " & SQLString(tdbg(i, COLS_N19)) & COMMA 'varchar[20], NULL
            sSQL &= "N20ID = " & SQLString(tdbg(i, COLS_N20)) & COMMA 'varchar[20], NULL

            ' Bổ sung theo ID 77333 21/08/2015 Tuấn Vũ yêu cầu chuyển qua lưu bảng D13T0101
            'If L3Bool(tdbg(i, COLS_IsSub)) = False Then
            sSQL &= vbCrLf
            For j As Integer = 0 To 9 ' NumRef  -> 10 
                sSQL &= "NumRef" & (j + 1).ToString("00") & " = " & SQLMoney(tdbg(i, COLS_NumRef01 + j), tdbg.Columns(COLS_NumRef01 + j).NumberFormat) & COMMA 'decimal, NOT NULL
            Next
            'End If

            sSQL &= "ValidDateFrom = " & SQLDateSave(tdbg(i, COLS_ValidDateFrom)) & COMMA
            sSQL &= "ValidDateTo = " & SQLDateSave(tdbg(i, COLS_ValidDateTo)) & COMMA
            sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
            sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
            sSQL &= "StandardAbsentQuan = " & SQLNumber(tdbg(i, COLS_StandardAbsentQuan), tdbg.Columns(COLS_StandardAbsentQuan).NumberFormat) & COMMA
            sSQL &= "OfficalTitleID = " & SQLString(tdbg(i, COLS_OfficalTitleID)) & COMMA 'varchar[20], NOT NULL
            sSQL &= "SalaryLevelID = " & SQLString(tdbg(i, COLS_SalaryLevelID)) & COMMA 'varchar[20], NOT NULL
            sSQL &= "SaCoefficient = " & SQLMoney(tdbg(i, COLS_SaCoefficient)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient12 = " & SQLMoney(tdbg(i, COLS_SaCoefficient12)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient13 = " & SQLMoney(tdbg(i, COLS_SaCoefficient13)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient14 = " & SQLMoney(tdbg(i, COLS_SaCoefficient14)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient15 = " & SQLMoney(tdbg(i, COLS_SaCoefficient15)) & COMMA 'decimal, NOT NULL
            sSQL &= "OfficalTitleID2 = " & SQLString(tdbg(i, COLS_OfficalTitleID2)) & COMMA 'varchar[20], NOT NULL
            sSQL &= "SalaryLevelID2 = " & SQLString(tdbg(i, COLS_SalaryLevelID2)) & COMMA 'varchar[20], NOT NULL
            sSQL &= "SaCoefficient2 = " & SQLMoney(tdbg(i, COLS_SaCoefficient2)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient22 = " & SQLMoney(tdbg(i, COLS_SaCoefficient22)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient23 = " & SQLMoney(tdbg(i, COLS_SaCoefficient23)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient24 = " & SQLMoney(tdbg(i, COLS_SaCoefficient24)) & COMMA 'decimal, NOT NULL
            sSQL &= "SaCoefficient25 = " & SQLMoney(tdbg(i, COLS_SaCoefficient25)) & COMMA 'decimal, NOT NULL
            sSQL &= "PaymentMethod = " & SQLString(tdbg(i, COLS_PaymentMethod)) & COMMA 'varchar[1], NOT NULL
            sSQL &= "Ref01 = " & SQLStringUnicode(tdbg(i, COLS_Ref01), gbUnicode, False) & COMMA
            sSQL &= "Ref02 = " & SQLStringUnicode(tdbg(i, COLS_Ref02), gbUnicode, False) & COMMA
            sSQL &= "Ref03 = " & SQLStringUnicode(tdbg(i, COLS_Ref03), gbUnicode, False) & COMMA
            sSQL &= "Ref04 = " & SQLStringUnicode(tdbg(i, COLS_Ref04), gbUnicode, False) & COMMA
            sSQL &= "Ref05 = " & SQLStringUnicode(tdbg(i, COLS_Ref05), gbUnicode, False) & COMMA
            sSQL &= "Ref01U = " & SQLStringUnicode(tdbg(i, COLS_Ref01), gbUnicode, True) & COMMA
            sSQL &= "Ref02U = " & SQLStringUnicode(tdbg(i, COLS_Ref02), gbUnicode, True) & COMMA
            sSQL &= "Ref03U = " & SQLStringUnicode(tdbg(i, COLS_Ref03), gbUnicode, True) & COMMA
            sSQL &= "Ref04U = " & SQLStringUnicode(tdbg(i, COLS_Ref04), gbUnicode, True) & COMMA
            sSQL &= "Ref05U = " & SQLStringUnicode(tdbg(i, COLS_Ref05), gbUnicode, True)
            sSQL &= " Where "
            'sSQL &= "PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And "
            'sSQL &= "EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)) & " And "
            'sSQL &= "DepartmentID = " & SQLString(tdbg(i, COLS_DepartmentID)) & " And "
            'sSQL &= "TeamID = " & SQLString(tdbg(i, COLS_TeamID)) & " And "
            'sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
            'sSQL &= "TranYear = " & SQLNumber(giTranYear) & " And "
            sSQL &= "TransID = " & SQLString(tdbg(i, COLS_TransID)) & " And "
            sSQL &= "DivisionID = " & SQLString(gsDivisionID)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                'sSQL &= SQLInsertD13T0101s().ToString
                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0100", "PayrollVoucherID", _payrollVoucherID, 0, "PayrollVoucherID") & vbCrLf

                sSQL &= SQLUpdateD13T0101s_AddNew().ToString() & vbCrLf
                sSQL &= SQLUpdateD13T0201s().ToString
                sSQL &= SQLInsertD09T6666s().ToString() & vbCrLf


                sSQL &= SQLStoreD09P6210("MonSalaryFileDetail", "", "01") & vbCrLf

                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0100", "PayrollVoucherID", _payrollVoucherID, 1, "PayrollVoucherID") & vbCrLf
                sSQL &= SQLStoreD09P6210s("MonthlySalaryFile", _payrollVoucherID, "02", _payrollVoucherNo, _description) & vbCrLf
                sSQL &= SQLDeleteD09T6666("D13F2013").ToString & vbCrLf

            Case EnumFormState.FormEdit
                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0101", "TransID", tdbg.Columns(COLS_TransID).Text, 0, "TransID") & vbCrLf
                sSQL &= SQLUpdateD13T0101s().ToString() & vbCrLf

                'ID 106046 17.01.2018
                If bMaxPeriod Then
                    sSQL &= SQLUpdateD13T0201s().ToString & vbCrLf
                End If

                sSQL &= SQLUpdateD13T2010s().ToString() & vbCrLf
                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0101", "TransID", tdbg.Columns(COLS_TransID).Text, 1, "TransID") & vbCrLf
                sSQL &= SQLStoreD09P6210s("MonSalaryFileDetail", tdbg.Columns(COLS_TransID).Text, "02", tdbg.Columns(COLS_EmployeeID).Text, _payrollVoucherNo) & vbCrLf
                'sSQL &= SQLStoreD13P0201() & vbCrLf
                sSQL &= SQLDeleteD09T6666FormID("D21F1000") & vbCrLf
                sSQL &= SQLInsertD09T6666s("D21F1000").ToString() & vbCrLf
                sSQL &= SQLStoreD21P4070("D21F1000", 1) & vbCrLf
            Case EnumFormState.FormEditOther ' update 15/4/2013 id 55205
                sSQL &= SQLDeleteD09T6666("D13F2013") & vbCrLf
                sSQL &= SQLInsertD09T6666s().ToString & vbCrLf
                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0101", "", "", 0, "TransID") & vbCrLf
                sSQL &= SQLUpdateD13T0101s().ToString() & vbCrLf

                'ID 106046 17.01.2018
                If bMaxPeriod Then
                    sSQL &= SQLUpdateD13T0201s().ToString & vbCrLf ' 25/4/2014 id 64564
                End If

                sSQL &= SQLStoreD09P6200s(tdbg, "D13T0101", "", "", 1, "TransID") & vbCrLf
                sSQL &= SQLStoreD09P6210s("MonSalaryFileDetail", "", "02") & vbCrLf
                ' sSQL &= SQLStoreD13P0201() & vbCrLf
                sSQL &= SQLDeleteD09T6666("D13F2013").ToString
                sSQL &= SQLDeleteD09T6666FormID("D21F1000")
                sSQL &= SQLInsertD09T6666s("D21F1000").ToString()
                sSQL &= SQLStoreD21P4070("D21F1000", 1)
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = False
                    btnClose.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = False
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select

            btnUpdateMasterPayrollFiles.Enabled = True And iPer > 2
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Function CheckMaxPeriod() As Boolean
        Dim dtCheck As DataTable = ReturnDataTable(SQLStoreD13P5555())
        If dtCheck IsNot Nothing AndAlso dtCheck.Rows.Count > 0 Then
            Return Not L3Bool(dtCheck.Rows(0)("Status"))
        End If
        Return False
    End Function

    Private Sub tdbg_InputDate()
        For i As Integer = 0 To 3
            InputDateInTrueDBGrid(tdbg, COLS_BaseSalary01DateEnd + i)
            InputDateInTrueDBGrid(tdbg, COLS_BaseSalary01NextDate + i)
        Next
        For i As Integer = 0 To 19
            InputDateInTrueDBGrid(tdbg, COLS_Sal01DateEnd + i)
            InputDateInTrueDBGrid(tdbg, COLS_Sal01NextDate + i)
        Next

        InputDateInTrueDBGrid(tdbg, COLS_ValidDateFrom, COLS_ValidDateTo, COLS_OffSa1DateEnd, COLS_OffSa1NextDate, COLS_OffSa2DateEnd, COLS_OffSa2NextDate)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COLS_StandardAbsentQuan).NumberFormat = D13Format.DefaultNumber1
        tdbg.Columns(COLS_BASE01).NumberFormat = Format(tdbg.Columns(COLS_BASE01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COLS_BASE02).NumberFormat = Format(tdbg.Columns(COLS_BASE02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COLS_BASE03).NumberFormat = Format(tdbg.Columns(COLS_BASE03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COLS_BASE04).NumberFormat = Format(tdbg.Columns(COLS_BASE04).Text, D13FormatSalary.BASE04)

        tdbg.Columns(COLS_NextBaseSalary01).NumberFormat = Format(tdbg.Columns(COLS_NextBaseSalary01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COLS_NextBaseSalary02).NumberFormat = Format(tdbg.Columns(COLS_NextBaseSalary02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COLS_NextBaseSalary03).NumberFormat = Format(tdbg.Columns(COLS_NextBaseSalary03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COLS_NextBaseSalary04).NumberFormat = Format(tdbg.Columns(COLS_NextBaseSalary04).Text, D13FormatSalary.BASE04)

        tdbg.Columns(COLS_CE01).NumberFormat = Format(tdbg.Columns(COLS_CE01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COLS_CE02).NumberFormat = Format(tdbg.Columns(COLS_CE02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COLS_CE03).NumberFormat = Format(tdbg.Columns(COLS_CE03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COLS_CE04).NumberFormat = Format(tdbg.Columns(COLS_CE04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COLS_CE05).NumberFormat = Format(tdbg.Columns(COLS_CE05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COLS_CE06).NumberFormat = Format(tdbg.Columns(COLS_CE06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COLS_CE07).NumberFormat = Format(tdbg.Columns(COLS_CE07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COLS_CE08).NumberFormat = Format(tdbg.Columns(COLS_CE08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COLS_CE09).NumberFormat = Format(tdbg.Columns(COLS_CE09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COLS_CE10).NumberFormat = Format(tdbg.Columns(COLS_CE10).Text, D13FormatSalary.CE10)
        tdbg.Columns(COLS_CE11).NumberFormat = Format(tdbg.Columns(COLS_CE11).Text, D13FormatSalary.CE11)
        tdbg.Columns(COLS_CE12).NumberFormat = Format(tdbg.Columns(COLS_CE12).Text, D13FormatSalary.CE12)
        tdbg.Columns(COLS_CE13).NumberFormat = Format(tdbg.Columns(COLS_CE13).Text, D13FormatSalary.CE13)
        tdbg.Columns(COLS_CE14).NumberFormat = Format(tdbg.Columns(COLS_CE14).Text, D13FormatSalary.CE14)
        tdbg.Columns(COLS_CE15).NumberFormat = Format(tdbg.Columns(COLS_CE15).Text, D13FormatSalary.CE15)
        tdbg.Columns(COLS_CE16).NumberFormat = Format(tdbg.Columns(COLS_CE16).Text, D13FormatSalary.CE16)
        tdbg.Columns(COLS_CE17).NumberFormat = Format(tdbg.Columns(COLS_CE17).Text, D13FormatSalary.CE17)
        tdbg.Columns(COLS_CE18).NumberFormat = Format(tdbg.Columns(COLS_CE18).Text, D13FormatSalary.CE18)
        tdbg.Columns(COLS_CE19).NumberFormat = Format(tdbg.Columns(COLS_CE19).Text, D13FormatSalary.CE19)
        tdbg.Columns(COLS_CE20).NumberFormat = Format(tdbg.Columns(COLS_CE20).Text, D13FormatSalary.CE20)

        tdbg.Columns(COLS_NextSalCoefficient01).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COLS_NextSalCoefficient02).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COLS_NextSalCoefficient03).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COLS_NextSalCoefficient04).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COLS_NextSalCoefficient05).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COLS_NextSalCoefficient06).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COLS_NextSalCoefficient07).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COLS_NextSalCoefficient08).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COLS_NextSalCoefficient09).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COLS_NextSalCoefficient10).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient10).Text, D13FormatSalary.CE10)
        tdbg.Columns(COLS_NextSalCoefficient11).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient11).Text, D13FormatSalary.CE11)
        tdbg.Columns(COLS_NextSalCoefficient12).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient12).Text, D13FormatSalary.CE12)
        tdbg.Columns(COLS_NextSalCoefficient13).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient13).Text, D13FormatSalary.CE13)
        tdbg.Columns(COLS_NextSalCoefficient14).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient14).Text, D13FormatSalary.CE14)
        tdbg.Columns(COLS_NextSalCoefficient15).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient15).Text, D13FormatSalary.CE15)
        tdbg.Columns(COLS_NextSalCoefficient16).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient16).Text, D13FormatSalary.CE16)
        tdbg.Columns(COLS_NextSalCoefficient17).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient17).Text, D13FormatSalary.CE17)
        tdbg.Columns(COLS_NextSalCoefficient18).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient18).Text, D13FormatSalary.CE18)
        tdbg.Columns(COLS_NextSalCoefficient19).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient19).Text, D13FormatSalary.CE19)
        tdbg.Columns(COLS_NextSalCoefficient20).NumberFormat = Format(tdbg.Columns(COLS_NextSalCoefficient20).Text, D13FormatSalary.CE20)

        tdbg.Columns(COLS_INC01).NumberFormat = Format(tdbg.Columns(COLS_INC01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC02).NumberFormat = Format(tdbg.Columns(COLS_INC02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC03).NumberFormat = Format(tdbg.Columns(COLS_INC03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC04).NumberFormat = Format(tdbg.Columns(COLS_INC04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC05).NumberFormat = Format(tdbg.Columns(COLS_INC05).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC06).NumberFormat = Format(tdbg.Columns(COLS_INC06).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC07).NumberFormat = Format(tdbg.Columns(COLS_INC07).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC08).NumberFormat = Format(tdbg.Columns(COLS_INC08).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC09).NumberFormat = Format(tdbg.Columns(COLS_INC09).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC10).NumberFormat = Format(tdbg.Columns(COLS_INC10).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC11).NumberFormat = Format(tdbg.Columns(COLS_INC11).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC12).NumberFormat = Format(tdbg.Columns(COLS_INC12).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC13).NumberFormat = Format(tdbg.Columns(COLS_INC13).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC14).NumberFormat = Format(tdbg.Columns(COLS_INC14).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC15).NumberFormat = Format(tdbg.Columns(COLS_INC15).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC16).NumberFormat = Format(tdbg.Columns(COLS_INC16).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC17).NumberFormat = Format(tdbg.Columns(COLS_INC17).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC18).NumberFormat = Format(tdbg.Columns(COLS_INC18).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC19).NumberFormat = Format(tdbg.Columns(COLS_INC19).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC20).NumberFormat = Format(tdbg.Columns(COLS_INC20).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC21).NumberFormat = Format(tdbg.Columns(COLS_INC21).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC22).NumberFormat = Format(tdbg.Columns(COLS_INC22).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC23).NumberFormat = Format(tdbg.Columns(COLS_INC23).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC24).NumberFormat = Format(tdbg.Columns(COLS_INC24).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC25).NumberFormat = Format(tdbg.Columns(COLS_INC25).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC26).NumberFormat = Format(tdbg.Columns(COLS_INC26).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC27).NumberFormat = Format(tdbg.Columns(COLS_INC27).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC28).NumberFormat = Format(tdbg.Columns(COLS_INC28).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC29).NumberFormat = Format(tdbg.Columns(COLS_INC29).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_INC30).NumberFormat = Format(tdbg.Columns(COLS_INC30).Text, D13Format.DefaultNumber2)

        tdbg.Columns(COLS_SaCoefficient).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient).Text, D13FormatSalary.OLSC11)
        tdbg.Columns(COLS_SaCoefficient12).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient12).Text, D13FormatSalary.OLSC12)
        tdbg.Columns(COLS_SaCoefficient13).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient13).Text, D13FormatSalary.OLSC13)
        tdbg.Columns(COLS_SaCoefficient14).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient14).Text, D13FormatSalary.OLSC14)
        tdbg.Columns(COLS_SaCoefficient15).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient15).Text, D13FormatSalary.OLSC15)
        tdbg.Columns(COLS_SaCoefficient2).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient2).Text, D13FormatSalary.OLSC21)
        tdbg.Columns(COLS_SaCoefficient22).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient22).Text, D13FormatSalary.OLSC22)
        tdbg.Columns(COLS_SaCoefficient23).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient23).Text, D13FormatSalary.OLSC23)
        tdbg.Columns(COLS_SaCoefficient24).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient24).Text, D13FormatSalary.OLSC24)
        tdbg.Columns(COLS_SaCoefficient25).NumberFormat = Format(tdbg.Columns(COLS_SaCoefficient25).Text, D13FormatSalary.OLSC25)

        tdbg.Columns(COLS_NumRef01).NumberFormat = Format(tdbg.Columns(COLS_NumRef01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef02).NumberFormat = Format(tdbg.Columns(COLS_NumRef02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef03).NumberFormat = Format(tdbg.Columns(COLS_NumRef03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef04).NumberFormat = Format(tdbg.Columns(COLS_NumRef04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef05).NumberFormat = Format(tdbg.Columns(COLS_NumRef05).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef06).NumberFormat = Format(tdbg.Columns(COLS_NumRef06).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef07).NumberFormat = Format(tdbg.Columns(COLS_NumRef07).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef08).NumberFormat = Format(tdbg.Columns(COLS_NumRef08).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef09).NumberFormat = Format(tdbg.Columns(COLS_NumRef09).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COLS_NumRef10).NumberFormat = Format(tdbg.Columns(COLS_NumRef10).Text, D13Format.DefaultNumber2)
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D13F7777
        With f
            .CallShowForm(Me.Name)
            .ShowDialog()
        End With
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_FullName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_SalaryRate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLS_IsSub).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC11).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC16).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC17).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC18).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC19).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC20).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC21).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC22).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC23).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC24).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC25).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC26).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC27).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC28).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC29).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_INC30).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        For i As Integer = 0 To 20 - 1
            tdbg.Columns(COLS_N01 + i).DropDown = tdbdNCodeID
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_N01 + i).AutoComplete = True
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_N01 + i).AutoDropDown = True
        Next i

        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient22).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient23).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient24).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_SaCoefficient25).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        If _FormState = EnumFormState.FormAdd Then
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P11).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P16).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P17).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P18).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P19).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COLS_P20).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If

        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P11).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P16).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P17).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P18).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P19).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COLS_P20).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub


    Private Sub D13F2013_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
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
                    btnAnalyseSalary_Click(Nothing, Nothing)
                Case Keys.D6, Keys.NumPad4
                    btnIncome_Click(Nothing, Nothing)
                Case Keys.D7, Keys.NumPad4
                    btnInfoOther_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Public Sub CopyColumn(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""
        Dim sValue2 As String = ""

        Dim Flag As DialogResult
        Flag = D99C0008.MsgCopyColumn()
        If ColCopy = COLS_TaxObjectName Then
            sValue1 = c1Grid.Columns(COLS_TaxObjectID).Text
            sValue2 = c1Grid.Columns(COLS_TaxObjectName).Text
        ElseIf ColCopy = COLS_OfficalTitleID Then
            sValue1 = c1Grid.Columns(COLS_SalaryLevelID).Text
            sValue2 = c1Grid.Columns(COLS_SaCoefficient).Text
        ElseIf ColCopy = COLS_OfficalTitleID2 Then
            sValue1 = c1Grid.Columns(COLS_SalaryLevelID2).Text
            sValue2 = c1Grid.Columns(COLS_SaCoefficient2).Text
        ElseIf ColCopy = COLS_SalaryLevelID Then
            sValue2 = c1Grid.Columns(COLS_SaCoefficient).Text
        ElseIf ColCopy = COLS_SalaryLevelID2 Then
            sValue2 = c1Grid.Columns(COLS_SaCoefficient2).Text

        End If
        If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
            For i As Integer = 0 To c1Grid.RowCount - 1
                If c1Grid(i, ColCopy).ToString = "" Then
                    c1Grid(i, ColCopy) = sValue
                    If ColCopy = COLS_TaxObjectName Then
                        c1Grid(i, COLS_TaxObjectID) = sValue1
                        c1Grid(i, COLS_TaxObjectName) = sValue2
                    ElseIf ColCopy = COLS_OfficalTitleID Then
                        c1Grid(i, COLS_SalaryLevelID) = sValue1
                        c1Grid(i, COLS_SaCoefficient) = sValue2
                    ElseIf ColCopy = COLS_OfficalTitleID2 Then
                        c1Grid(i, COLS_SalaryLevelID2) = sValue1
                        c1Grid(i, COLS_SaCoefficient2) = sValue2
                    ElseIf ColCopy = COLS_SalaryLevelID Then
                        c1Grid(i, COLS_SaCoefficient) = sValue2
                    ElseIf ColCopy = COLS_SalaryLevelID2 Then
                        c1Grid(i, COLS_SaCoefficient2) = sValue2
                    End If
                End If
            Next
        ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy nhung dong con trong ' Copy het

            For i As Integer = 0 To c1Grid.RowCount - 1
                c1Grid(i, ColCopy) = sValue
                If ColCopy = COLS_TaxObjectName Then
                    c1Grid(i, COLS_TaxObjectID) = sValue1
                    c1Grid(i, COLS_TaxObjectName) = sValue2
                ElseIf ColCopy = COLS_OfficalTitleID Then
                    c1Grid(i, COLS_SalaryLevelID) = sValue1
                    c1Grid(i, COLS_SaCoefficient) = sValue2
                ElseIf ColCopy = COLS_OfficalTitleID2 Then
                    c1Grid(i, COLS_SalaryLevelID2) = sValue1
                    c1Grid(i, COLS_SaCoefficient2) = sValue2
                ElseIf ColCopy = COLS_SalaryLevelID Then
                    c1Grid(i, COLS_SaCoefficient) = sValue2
                ElseIf ColCopy = COLS_SalaryLevelID2 Then
                    c1Grid(i, COLS_SaCoefficient2) = sValue2
                End If
            Next
            c1Grid(0, ColCopy) = sValue
            If ColCopy = COLS_TaxObjectName Then
                c1Grid(0, COLS_TaxObjectID) = sValue1
                c1Grid(0, COLS_TaxObjectName) = sValue2
            ElseIf ColCopy = COLS_OfficalTitleID Then
                c1Grid(0, COLS_SalaryLevelID) = sValue1
                c1Grid(0, COLS_SaCoefficient) = sValue2
            ElseIf ColCopy = COLS_OfficalTitleID2 Then
                c1Grid(0, COLS_SalaryLevelID2) = sValue1
                c1Grid(0, COLS_SaCoefficient2) = sValue2
            ElseIf ColCopy = COLS_SalaryLevelID Then
                c1Grid(0, COLS_SaCoefficient) = sValue2
            ElseIf ColCopy = COLS_SalaryLevelID2 Then
                c1Grid(0, COLS_SaCoefficient2) = sValue2
            End If
        Else
            Exit Sub
        End If
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown

        If e.KeyCode = Keys.F7 Then
            HotKeysF7(tdbg)
        ElseIf e.Control And e.Alt And e.KeyCode = Keys.C Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumn(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text)
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If

        ElseIf e.Control And e.KeyCode = Keys.Home Then
            tdbg.SplitIndex = 0
            tdbg.Col = COLS_DepartmentID
            tdbg.Focus()
        ElseIf e.Control And e.KeyCode = Keys.End Then
            If tdbg.Columns.Count >= 1 Then
                tdbg.Col = tdbg.Columns.Count - 1
            Else
                Return
            End If
        ElseIf e.Control And e.KeyCode = Keys.PageUp Then
            If tdbg.RowCount >= 1 Then
                tdbg.Row = 0
                tdbg.Focus()
            End If
        ElseIf e.Control And e.KeyCode = Keys.PageDown Then
            If tdbg.RowCount >= 1 Then
                tdbg.Row = tdbg.RowCount - 1
                tdbg.Focus()
            Else
                Return
            End If
        ElseIf e.Control And e.KeyCode = Keys.Right Then
            If tdbg.SplitIndex < tdbg.Splits.Count - 1 Then
                tdbg.SplitIndex = tdbg.SplitIndex + 1
                tdbg.Focus()
            Else
                Return
            End If
        ElseIf e.Control And e.KeyCode = Keys.Left Then
            If tdbg.SplitIndex >= 1 Then
                tdbg.SplitIndex = tdbg.SplitIndex - 1
                tdbg.Focus()
            Else
                Return
            End If
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            If tdbg.RowCount > 0 Then
                tdbg.Delete(tdbg.Row)
                tdbg.Focus()
            End If
        ElseIf e.Control And e.KeyCode = Keys.S Then
            ' update 15/5/2013 id 56381
            HeadClick(tdbg.Col)
        ElseIf e.KeyCode = Keys.F4 Then
            For i As Integer = tdbg.Row To tdbg.RowCount - 1
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    tdbg(i, tdbg.Col) = ""
                    If tdbg.Col = COLS_TaxObjectName Then
                        tdbg(i, COLS_TaxObjectID) = ""
                        tdbg(i, COLS_TaxObjectName) = ""
                    ElseIf tdbg.Col = COLS_OfficalTitleID Then
                        tdbg(i, COLS_SalaryLevelID) = ""
                        tdbg(i, COLS_SaCoefficient) = ""
                    ElseIf tdbg.Col = COLS_OfficalTitleID2 Then
                        tdbg(i, COLS_SalaryLevelID2) = ""
                        tdbg(i, COLS_SaCoefficient2) = ""
                    ElseIf tdbg.Col = COLS_SalaryLevelID Then
                        tdbg(i, COLS_SaCoefficient) = ""
                    ElseIf tdbg.Col = COLS_SalaryLevelID2 Then
                        tdbg(i, COLS_SaCoefficient2) = ""
                    End If
                    tdbg.Focus()
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Return
                End If
            Next
        ElseIf e.KeyCode = Keys.F9 Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumnF9(tdbg, tdbg.Col, tdbg.Row, tdbg.Columns(tdbg.Col).Text)
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If
        End If
    End Sub
    Public Sub CopyColumnF9(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""
        Dim sValue2 As String = ""
        If ColCopy = COLS_TaxObjectName Then
            sValue1 = c1Grid.Columns(COLS_TaxObjectID).Text
            sValue2 = c1Grid.Columns(COLS_TaxObjectName).Text
        ElseIf ColCopy = COLS_OfficalTitleID Then
            sValue1 = c1Grid.Columns(COLS_SalaryLevelID).Text
            sValue2 = c1Grid.Columns(COLS_SaCoefficient).Text
        ElseIf ColCopy = COLS_OfficalTitleID2 Then
            sValue1 = c1Grid.Columns(COLS_SalaryLevelID2).Text
            sValue2 = c1Grid.Columns(COLS_SaCoefficient2).Text
        ElseIf ColCopy = COLS_SalaryLevelID Then
            sValue2 = c1Grid.Columns(COLS_SaCoefficient).Text
        ElseIf ColCopy = COLS_SalaryLevelID2 Then
            sValue2 = c1Grid.Columns(COLS_SaCoefficient2).Text
        End If

        For i As Integer = RowCopy To c1Grid.RowCount - 1
            c1Grid(i, ColCopy) = sValue
            If ColCopy = COLS_TaxObjectName Then
                c1Grid(i, COLS_TaxObjectID) = sValue1
                c1Grid(i, COLS_TaxObjectName) = sValue2
            ElseIf ColCopy = COLS_OfficalTitleID Then
                c1Grid(i, COLS_SalaryLevelID) = sValue1
                c1Grid(i, COLS_SaCoefficient) = sValue2
            ElseIf ColCopy = COLS_OfficalTitleID2 Then
                c1Grid(i, COLS_SalaryLevelID2) = sValue1
                c1Grid(i, COLS_SaCoefficient2) = sValue2
            ElseIf ColCopy = COLS_SalaryLevelID Then
                c1Grid(i, COLS_SaCoefficient) = sValue2
            ElseIf ColCopy = COLS_SalaryLevelID2 Then
                c1Grid(i, COLS_SaCoefficient2) = sValue2
            End If
        Next

    End Sub
    Public Sub HotKeysF7(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim sValue1 As String = ""
        Dim sValue2 As String = ""

        If c1Grid.Col = COLS_TaxObjectName Then
            sValue1 = c1Grid(c1Grid.Row - 1, COLS_TaxObjectID).ToString
            sValue2 = c1Grid(c1Grid.Row - 1, COLS_TaxObjectName).ToString
        ElseIf c1Grid.Col = COLS_OfficalTitleID Then
            sValue1 = c1Grid(c1Grid.Row - 1, COLS_SalaryLevelID).ToString
            sValue2 = c1Grid(c1Grid.Row - 1, COLS_SaCoefficient).ToString

        ElseIf c1Grid.Col = COLS_OfficalTitleID2 Then
            sValue1 = c1Grid(c1Grid.Row - 1, COLS_SalaryLevelID2).ToString
            sValue2 = c1Grid(c1Grid.Row - 1, COLS_SaCoefficient2).ToString
        ElseIf c1Grid.Col = COLS_SalaryLevelID Then
            sValue2 = c1Grid(c1Grid.Row - 1, COLS_SaCoefficient).ToString

        ElseIf c1Grid.Col = COLS_SalaryLevelID2 Then
            sValue2 = c1Grid(c1Grid.Row - 1, COLS_SaCoefficient2).ToString

        End If

        Dim iSplit As Integer = 0
        If c1Grid.RowCount < 1 Then Exit Sub
        iSplit = c1Grid.SplitIndex
        If c1Grid.Splits(iSplit).DisplayColumns(c1Grid.Col).Locked = False Then
            If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" Then
                c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                If c1Grid.Col = COLS_TaxObjectName Then
                    c1Grid.Columns(COLS_TaxObjectID).Text = sValue1
                    c1Grid.Columns(COLS_TaxObjectName).Text = sValue2
                ElseIf c1Grid.Col = COLS_OfficalTitleID Then
                    c1Grid.Columns(COLS_SalaryLevelID).Text = sValue1
                    c1Grid.Columns(COLS_SaCoefficient).Text = sValue2
                ElseIf c1Grid.Col = COLS_OfficalTitleID2 Then
                    c1Grid.Columns(COLS_SalaryLevelID2).Text = sValue1
                    c1Grid.Columns(COLS_SaCoefficient2).Text = sValue2
                ElseIf c1Grid.Col = COLS_SalaryLevelID Then
                    c1Grid.Columns(COLS_SaCoefficient).Text = sValue2
                ElseIf c1Grid.Col = COLS_SalaryLevelID2 Then
                    c1Grid.Columns(COLS_SaCoefficient2).Text = sValue2

                End If
            Else
                If CDbl(c1Grid(c1Grid.Row, c1Grid.Col)) = 0 Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    If c1Grid.Col = COLS_OfficalTitleID Then
                        c1Grid.Columns(COLS_SalaryLevelID).Text = sValue1
                        c1Grid.Columns(COLS_SaCoefficient).Text = sValue2
                    ElseIf c1Grid.Col = COLS_OfficalTitleID2 Then
                        c1Grid.Columns(COLS_SalaryLevelID2).Text = sValue1
                        c1Grid.Columns(COLS_SaCoefficient2).Text = sValue2
                    ElseIf c1Grid.Col = COLS_SalaryLevelID Then
                        c1Grid.Columns(COLS_SaCoefficient).Text = sValue2
                    ElseIf c1Grid.Col = COLS_SalaryLevelID2 Then
                        c1Grid.Columns(COLS_SaCoefficient2).Text = sValue2
                    End If
                End If

            End If
        Else
            D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
            Return
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLS_PaymentMethod).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Phuong_phap_tra_luong"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COLS_PaymentMethod
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If

            If tdbg(i, COLS_BASE01).ToString <> "" And Val(tdbg(i, COLS_BASE01).ToString) > MaxMoney Then
                D99C0008.MsgL3(rL3("Luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COLS_BASE01
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COLS_BASE02).ToString <> "" And Val(tdbg(i, COLS_BASE02).ToString) > MaxMoney Then
                D99C0008.MsgL3(rL3("Luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COLS_BASE02
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COLS_BASE03).ToString <> "" And Val(tdbg(i, COLS_BASE03).ToString) > MaxMoney Then
                D99C0008.MsgL3(rL3("Luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COLS_BASE03
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COLS_BASE04).ToString <> "" And Val(tdbg(i, COLS_BASE04).ToString) > MaxMoney Then
                D99C0008.MsgL3(rL3("Luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COLS_BASE04
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
            For j As Integer = 0 To 19
                If tdbg(i, COLS_CE01 + j).ToString <> "" And Val(tdbg(i, COLS_CE01 + j).ToString) > MaxMoney Then
                    D99C0008.MsgL3(rL3("He_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COLS_CE01 + j
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            Next
            'Bỏ bắt buộc nhập Chấm công (từ) - đến theo ID: 77659  07/10/2015
            'If _FormState = EnumFormState.FormEdit Then
            '    If tdbg(i, COLS_ValidDateFrom).ToString.Trim = "" Then
            '        D99C0008.MsgNotYetEnter(rl3("Ngay_cham_cong") & " (" & rl3("Tu") & ")")
            '        tdbg.SplitIndex = SPLIT0
            '        tdbg.Col = COLS_ValidDateFrom
            '        tdbg.Bookmark = i
            '        tdbg.Focus()
            '        Return False
            '    End If

            '    If tdbg(i, COLS_ValidDateTo).ToString.Trim = "" Then
            '        D99C0008.MsgNotYetEnter(rl3("Ngay_cham_cong") & " (" & rl3("Den") & ")")
            '        tdbg.SplitIndex = SPLIT0
            '        tdbg.Col = COLS_ValidDateTo
            '        tdbg.Bookmark = i
            '        tdbg.Focus()
            '        Return False
            '    End If
            'End If


            If tdbg(i, COLS_ValidDateFrom).ToString.Trim <> "" And tdbg(i, COLS_ValidDateTo).ToString.Trim <> "" Then
                If CDate(tdbg(i, COLS_ValidDateFrom)) > CDate(tdbg(i, COLS_ValidDateTo)) Then
                    D99C0008.MsgL3(rL3("Gia_tri_Tu_ngay_khong_duoc_lon_hon_gia_tri_Den_ngay"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COLS_ValidDateFrom
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnUpdateMasterPayrollFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateMasterPayrollFiles.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnUpdateMasterPayrollFiles.Enabled = False
        btnClose.Enabled = False

        sSQL &= SQLUpdateD13T0201s().ToString & vbCrLf
        sSQL &= SQLStoreD21P4070s().ToString & vbCrLf

        Dim sThongBao As String = "Th¤ng bÀo"
        If gsLanguage = "84" Then
            sThongBao = "Th¤ng bÀo"
        Else
            sThongBao = "Announcement"
        End If
        If D99C0008.Msg(rL3("Ban_co_muon_cap_nhat_thong_tin_ho_so_bao_hiem_khong"), sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            sSQL &= SQLStoreD21P2000s().ToString
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnUpdateMasterPayrollFiles.Enabled = False
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnUpdateMasterPayrollFiles.Enabled = True And iPer > 2
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201s
    '# Created User: DUCTRONG
    '# Created Date: 28/11/2008 04:04:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim bMaxPeriod As Boolean = CheckMaxPeriod()
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D13T0201 Set ")

            For j As Integer = 0 To 3
                sSQL.Append("BaseSalary" & (j + 1).ToString("00") & " = " & SQLMoney(tdbg(i, COLS_BASE01 + (j * 2)), tdbg.Columns(COLS_BASE01 + (j * 2)).NumberFormat) & COMMA) 'decimal, NOT NULL
                If L3Bool(tdbg(i, COLS_IsSub)) = False Then
                    sSQL.Append("BaseCurrencyID" & (j + 1).ToString("00") & " = " & SQLString(tdbg(i, COLS_BaseCurrencyID01 + (j * 2))) & COMMA)
                End If
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 3 ' BaseSalary01DateEnd  -> 04 
                sSQL.Append("BaseSalary" & (j + 1).ToString("00") & "DateEnd = " & SQLDateSave(tdbg(i, COLS_BaseSalary01DateEnd + j)) & COMMA) 'decimal, NOT NULL
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 3 ' BaseSalary01DateEnd  -> 04 
                sSQL.Append("BaseSalary" & (j + 1).ToString("00") & "NextDate = " & SQLDateSave(tdbg(i, COLS_BaseSalary01NextDate + j)) & COMMA) 'decimal, NOT NULL
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 3 ' NextBaseSalary01  -> 04 
                sSQL.Append("NextBaseSalary" & (j + 1).ToString("00") & " = " & SQLMoney(tdbg(i, COLS_NextBaseSalary01 + j), tdbg.Columns(COLS_NextBaseSalary01 + j).NumberFormat) & COMMA) 'decimal, NOT NULL
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 19 ' SalCoefficient  -> 20 
                sSQL.Append("SalCoefficient" & (j + 1).ToString("00") & " = " & SQLMoney(tdbg(i, COLS_CE01 + (j * 2)), tdbg.Columns(COLS_CE01 + (j * 2)).NumberFormat) & COMMA) 'decimal, NOT NULL
                If L3Bool(tdbg(i, COLS_IsSub)) = False Then
                    sSQL.Append("SalCoeCurrencyID" & (j + 1).ToString("00") & " = " & SQLString(tdbg(i, COLS_SalCoeCurrencyID01 + (j * 2))) & COMMA)
                End If
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 19 ' Sal01DateEnd  -> 20 
                sSQL.Append("Sal" & (j + 1).ToString("00") & "DateEnd = " & SQLDateSave(tdbg(i, COLS_Sal01DateEnd + j)) & COMMA) 'decimal, NOT NULL
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 19 ' Sal01NextDate  -> 20 
                sSQL.Append("Sal" & (j + 1).ToString("00") & "NextDate = " & SQLDateSave(tdbg(i, COLS_Sal01NextDate + j)) & COMMA) 'decimal, NOT NULL
            Next
            sSQL.Append(vbCrLf)
            For j As Integer = 0 To 19 ' NextSalCoefficient01  -> 20 
                sSQL.Append("NextSalCoefficient" & (j + 1).ToString("00") & " = " & SQLMoney(tdbg(i, COLS_NextSalCoefficient01 + j), tdbg.Columns(COLS_NextSalCoefficient01 + j).NumberFormat) & COMMA) 'decimal, NOT NULL
            Next
            
            sSQL.Append(vbCrLf)

            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL

            sSQL.Append("OfficalTitleID = " & SQLString(tdbg(i, COLS_OfficalTitleID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("SalaryLevelID = " & SQLString(tdbg(i, COLS_SalaryLevelID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("SaCoefficient = " & SQLMoney(tdbg(i, COLS_SaCoefficient)) & COMMA) 'decimal, NOT NULL

            sSQL.Append("OfficalTitleID2 = " & SQLString(tdbg(i, COLS_OfficalTitleID2)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("SalaryLevelID2 = " & SQLString(tdbg(i, COLS_SalaryLevelID2)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("SaCoefficient2 = " & SQLMoney(tdbg(i, COLS_SaCoefficient2)) & COMMA) 'decimal, NOT NULL

            sSQL.Append("NextOfficalTitleID = " & SQLString(tdbg(i, COLS_NextOfficalTitleID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("NextSalaryLevelID = " & SQLString(tdbg(i, COLS_NextSalaryLevelID)) & COMMA) 'varchar[20], NOT NULL

            sSQL.Append("OffSa1DateEnd = " & SQLDateSave(tdbg(i, COLS_OffSa1DateEnd)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("OffSa1NextDate = " & SQLDateSave(tdbg(i, COLS_OffSa1NextDate)) & COMMA) 'varchar[20], NOT NULL


            sSQL.Append("OffSa2DateEnd = " & SQLDateSave(tdbg(i, COLS_OffSa2DateEnd)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("OffSa2NextDate = " & SQLDateSave(tdbg(i, COLS_OffSa2NextDate)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("NextOfficalTitleID2 = " & SQLString(tdbg(i, COLS_NextOfficalTitleID2)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("NextSalaryLevelID2 = " & SQLString(tdbg(i, COLS_NextSalaryLevelID2))) 'varchar[20], NOT NULL

            '20/5/2015, id 73668-Chuyển phương pháp trả lương sang Tab Ngân hàng
            If bMaxPeriod Then
                sSQL.Append(COMMA & "PaymentMethod = " & SQLString(tdbg(i, COLS_PaymentMethod))) 'varchar[20], NULL
                sSQL.Append(COMMA & "TaxObjectID  = " & SQLString(tdbg(i, COLS_TaxObjectID))) 'varchar[20], NULL
            End If

            sSQL.Append(" Where ")
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
            sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P4070s
    '# Created User: DUCTRONG
    '# Created Date: 04/12/2008 03:53:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P4070s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Exec D21P4070 "
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COLS_EmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
            sSQL &= SQLNumber(1) & COMMA  'Mode, tinyint, NOT NULL
            sSQL &= SQLString("") & COMMA
            sSQL &= SQLNumber(0) & COMMA
            sSQL &= SQLNumber(0) & COMMA
            sSQL &= SQLString("") & COMMA
            sSQL &= SQLString("") & COMMA
            sSQL &= SQLNumber(gbUnicode)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P2000s
    '# Created User: DUCTRONG
    '# Created Date: 04/12/2008 03:54:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P2000s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Exec D21P2000 "
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
            sSQL &= SQLString("0003") & COMMA 'AdjustTypeID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COLS_EmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
            sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
            sSQL &= SQLNumber(gbUnicode)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0101s
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 11:13:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0101s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim sTransID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLS_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1

            If tdbg(i, COLS_TransID).ToString = "" Then
                sTransID = CreateIGEs("D13T0101", "TransID", "13", "DP", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COLS_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D13T0101(")
            sSQL.Append("DivisionID, PayrollVoucherID, EmployeeID, DepartmentID, TeamID, ")
            sSQL.Append("TranMonth, TranYear, IsSub, BaseSalary01, BaseSalary02, ")
            sSQL.Append("BaseSalary03, BaseSalary04,  ")
            sSQL.Append("SalCoefficient01, SalCoefficient02, SalCoefficient03, SalCoefficient04, SalCoefficient05, ")
            sSQL.Append("SalCoefficient06, SalCoefficient07, SalCoefficient08, SalCoefficient09, SalCoefficient10, ")
            sSQL.Append("SalCoefficient11, SalCoefficient12, SalCoefficient13, SalCoefficient14, SalCoefficient15, ")
            sSQL.Append("SalCoefficient16, SalCoefficient17, SalCoefficient18, SalCoefficient19, SalCoefficient20, ")
            sSQL.Append("TaxObjectID, SalAmount01, SalAmount02, ")
            sSQL.Append("SalAmount03, SalAmount04, SalAmount05, SalAmount06, SalAmount07, ")
            sSQL.Append("SalAmount08, SalAmount09, SalAmount10, SalAmount11, SalAmount12, ")
            sSQL.Append("SalAmount13, SalAmount14, SalAmount15, SalAmount16, SalAmount17, ")
            sSQL.Append("SalAmount18, SalAmount19, SalAmount20, SalAmount21, SalAmount22, ")
            sSQL.Append("SalAmount23, SalAmount24, SalAmount25, SalAmount26, SalAmount27, ")
            sSQL.Append("SalAmount28, SalAmount29, SalAmount30, ")
            sSQL.Append("N01ID, N02ID, N03ID, N04ID, N05ID, N06ID, ")
            sSQL.Append("N07ID, N08ID, N09ID, N10ID, N11ID, ")
            sSQL.Append("N12ID, N13ID, N14ID, N15ID, N16ID, ")
            sSQL.Append("N17ID, N18ID, N19ID, N20ID, ")
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, OfficalTitleID, ")
            sSQL.Append("SalaryLevelID, SaCoefficient, OfficalTitleID2, SalaryLevelID2, SaCoefficient2, ")
            sSQL.Append("TransID, SaCoefficient12, SaCoefficient13, SaCoefficient14, SaCoefficient15, ")
            sSQL.Append("SaCoefficient22, SaCoefficient23, SaCoefficient24, SaCoefficient25, StandardAbsentQuan, ")
            sSQL.Append("ValidDateFrom, ValidDateTo, PaymentMethod")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COLS_IsSub)) & COMMA) 'IsSub, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_BASE01), D13FormatSalary.BASE01) & COMMA) 'BaseSalary01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_BASE02), D13FormatSalary.BASE02) & COMMA) 'BaseSalary02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_BASE03), D13FormatSalary.BASE03) & COMMA) 'BaseSalary03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_BASE04), D13FormatSalary.BASE04) & COMMA) 'BaseSalary04, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbg(i, COLS_CE01), D13FormatSalary.CE01) & COMMA) 'SalCoefficient01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE02), D13FormatSalary.CE02) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE03), D13FormatSalary.CE03) & COMMA) 'SalCoefficient03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE04), D13FormatSalary.CE04) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE05), D13FormatSalary.CE05) & COMMA) 'SalCoefficient05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE06), D13FormatSalary.CE06) & COMMA) 'SalCoefficient06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE07), D13FormatSalary.CE07) & COMMA) 'SalCoefficient07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE08), D13FormatSalary.CE08) & COMMA) 'SalCoefficient08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE09), D13FormatSalary.CE09) & COMMA) 'SalCoefficient09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE10), D13FormatSalary.CE10) & COMMA) 'SalCoefficient10, decimal, NOT NULL
            'Update 10/02/2010: inicident 45882 thêm tiếp 10 HSL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE11), D13FormatSalary.CE11) & COMMA) 'SalCoefficient11, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE12), D13FormatSalary.CE12) & COMMA) 'SalCoefficient12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE13), D13FormatSalary.CE13) & COMMA) 'SalCoefficient13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE14), D13FormatSalary.CE14) & COMMA) 'SalCoefficient14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE15), D13FormatSalary.CE15) & COMMA) 'SalCoefficient15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE16), D13FormatSalary.CE16) & COMMA) 'SalCoefficient16, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE17), D13FormatSalary.CE17) & COMMA) 'SalCoefficient17, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE18), D13FormatSalary.CE18) & COMMA) 'SalCoefficient18, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE19), D13FormatSalary.CE19) & COMMA) 'SalCoefficient19, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_CE20), D13FormatSalary.CE20) & COMMA) 'SalCoefficient20, decimal, NOT NULL

            sSQL.Append(SQLString(tdbg(i, COLS_TaxObjectID)) & COMMA) 'TaxObjectID, varchar[20], NULL

            sSQL.Append(SQLMoney(tdbg(i, COLS_INC01)) & COMMA) 'SalAmount01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC02)) & COMMA) 'SalAmount02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC03)) & COMMA) 'SalAmount03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC04)) & COMMA) 'SalAmount04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC05)) & COMMA) 'SalAmount05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC06)) & COMMA) 'SalAmount06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC07)) & COMMA) 'SalAmount07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC08)) & COMMA) 'SalAmount08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC09)) & COMMA) 'SalAmount09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC10)) & COMMA) 'SalAmount10, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC11)) & COMMA) 'SalAmount11, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC12)) & COMMA) 'SalAmount12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC13)) & COMMA) 'SalAmount13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC14)) & COMMA) 'SalAmount14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC15)) & COMMA) 'SalAmount15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC16)) & COMMA) 'SalAmount16, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC17)) & COMMA) 'SalAmount17, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC18)) & COMMA) 'SalAmount18, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC19)) & COMMA) 'SalAmount19, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC20)) & COMMA) 'SalAmount20, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC21)) & COMMA) 'SalAmount21, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC22)) & COMMA) 'SalAmount22, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC23)) & COMMA) 'SalAmount23, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC24)) & COMMA) 'SalAmount24, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC25)) & COMMA) 'SalAmount25, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC26)) & COMMA) 'SalAmount26, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC27)) & COMMA) 'SalAmount27, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC28)) & COMMA) 'SalAmount28, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC29)) & COMMA) 'SalAmount29, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_INC30)) & COMMA) 'SalAmount30, decimal, NOT NULL

            sSQL.Append(SQLString(tdbg(i, COLS_N01)) & COMMA) 'N01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N02)) & COMMA) 'N02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N03)) & COMMA) 'N03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N04)) & COMMA) 'N04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N05)) & COMMA) 'N05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N06)) & COMMA) 'N06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N07)) & COMMA) 'N07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N08)) & COMMA) 'N08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N09)) & COMMA) 'N09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N10)) & COMMA) 'N10ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N11)) & COMMA) 'N11ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N12)) & COMMA) 'N12ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N13)) & COMMA) 'N13ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N14)) & COMMA) 'N14ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N15)) & COMMA) 'N15ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N16)) & COMMA) 'N16ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N17)) & COMMA) 'N17ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N18)) & COMMA) 'N18ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N19)) & COMMA) 'N19ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COLS_N20)) & COMMA) 'N20ID, varchar[20], NULL

            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COLS_OfficalTitleID)) & COMMA) 'OfficalTitleID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_SalaryLevelID)) & COMMA) 'SalaryLevelID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient)) & COMMA) 'SaCoefficient, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_OfficalTitleID2)) & COMMA) 'OfficalTitleID2, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_SalaryLevelID2)) & COMMA) 'SalaryLevelID2, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient2)) & COMMA) 'SaCoefficient2, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient12)) & COMMA) 'SaCoefficient12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient13)) & COMMA) 'SaCoefficient13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient14)) & COMMA) 'SaCoefficient14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient15)) & COMMA) 'SaCoefficient15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient22)) & COMMA) 'SaCoefficient22, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient23)) & COMMA) 'SaCoefficient23, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient24)) & COMMA) 'SaCoefficient24, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COLS_SaCoefficient25)) & COMMA) 'SaCoefficient25, decimal, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COLS_StandardAbsentQuan)) & COMMA)
            sSQL.Append(SQLDateSave(tdbg(i, COLS_ValidDateFrom)) & COMMA)
            sSQL.Append(SQLDateSave(tdbg(i, COLS_ValidDateTo)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COLS_PaymentMethod))) 'PaymentMethod, varchar[1], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sRet.Append(SQLStoreD13P2014(tdbg(i, COLS_TransID).ToString, tdbg(i, COLS_EmployeeID).ToString) & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLDateSave(ByVal [Date] As Object) As String
        If IsDBNull([Date]) Then Return "NULL"
        If [Date].ToString = MaskFormatDateShort Then Return "NULL"
        If [Date].ToString = MaskFormatDate Then Return "NULL"
        Return SQLDateSave([Date].ToString)
    End Function

    Private Function SQLDateSave(ByVal [Date] As String) As String
        If [Date] = "" Then Return "NULL"
        If [Date] = MaskFormatDateShort Then Return "NULL"
        If [Date] = MaskFormatDate Then Return "NULL"
        Dim dDate As Date = CType([Date], Date)
        Return SQLString(dDate.ToString("MM/dd/yyyy"))

    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2014
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 11:56:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2014(ByVal sTransID As String, ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2014 "
        sSQL &= SQLString(sTransID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(_payrollVoucherID) 'PayrollVoucherID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If _FormState = EnumFormState.FormAdd Then
            For i As Integer = COLS_P01 To COLS_P20
                tdbg.Splits(2).DisplayColumns(i).Locked = True
                tdbg.Splits(2).DisplayColumns(i).AutoDropDown = True
                tdbg.Columns(i).DropDown = Nothing
            Next
            Exit Sub
        End If
        If tdbg.Columns(COLS_IsSub).Text = "1" And _status = "0" Then
            For i As Integer = COLS_P01 To COLS_P20
                tdbg.Splits(2).DisplayColumns(i).Locked = False
                tdbg.Splits(2).DisplayColumns(i).AutoDropDown = True
            Next
            tdbg.Columns(COLS_P01).DropDown = tdbdPAna01ID
            tdbg.Columns(COLS_P02).DropDown = tdbdPAna02ID
            tdbg.Columns(COLS_P03).DropDown = tdbdPAna03ID
            tdbg.Columns(COLS_P04).DropDown = tdbdPAna04ID
            tdbg.Columns(COLS_P05).DropDown = tdbdPAna05ID
            tdbg.Columns(COLS_P06).DropDown = tdbdPAna06ID
            tdbg.Columns(COLS_P07).DropDown = tdbdPAna07ID
            tdbg.Columns(COLS_P08).DropDown = tdbdPAna08ID
            tdbg.Columns(COLS_P09).DropDown = tdbdPAna09ID
            tdbg.Columns(COLS_P10).DropDown = tdbdPAna10ID
            tdbg.Columns(COLS_P11).DropDown = tdbdPAna11ID
            tdbg.Columns(COLS_P12).DropDown = tdbdPAna12ID
            tdbg.Columns(COLS_P13).DropDown = tdbdPAna13ID
            tdbg.Columns(COLS_P14).DropDown = tdbdPAna14ID
            tdbg.Columns(COLS_P15).DropDown = tdbdPAna15ID
            tdbg.Columns(COLS_P16).DropDown = tdbdPAna16ID
            tdbg.Columns(COLS_P17).DropDown = tdbdPAna17ID
            tdbg.Columns(COLS_P18).DropDown = tdbdPAna18ID
            tdbg.Columns(COLS_P19).DropDown = tdbdPAna19ID
            tdbg.Columns(COLS_P20).DropDown = tdbdPAna20ID
        Else
            For i As Integer = COLS_P01 To COLS_P20
                tdbg.Splits(2).DisplayColumns(i).Locked = True
                tdbg.Splits(2).DisplayColumns(i).AutoDropDown = False
                tdbg.Columns(i).DropDown = Nothing
            Next
        End If
    End Sub

    Private Sub Load10TDBDropDownPAna()
        Dim sSQL As String = "Select D13.PAnaID, D13.PAnaName, D13.PAnaCategoryID from D13T1050 D13  WITH(NOLOCK) "
        Dim dtPAna As DataTable = ReturnDataTable(sSQL)
        If dtPAna.Rows.Count > 0 Then
            LoadDataSource(tdbdPAna01ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P01'"), gbUnicode)
            LoadDataSource(tdbdPAna02ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P02'"), gbUnicode)
            LoadDataSource(tdbdPAna03ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P03'"), gbUnicode)
            LoadDataSource(tdbdPAna04ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P04'"), gbUnicode)
            LoadDataSource(tdbdPAna05ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P05'"), gbUnicode)
            LoadDataSource(tdbdPAna06ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P06'"), gbUnicode)
            LoadDataSource(tdbdPAna07ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P07'"), gbUnicode)

            LoadDataSource(tdbdPAna08ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P08'"), gbUnicode)
            LoadDataSource(tdbdPAna09ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P09'"), gbUnicode)
            LoadDataSource(tdbdPAna10ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P10'"), gbUnicode)
            LoadDataSource(tdbdPAna11ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P11'"), gbUnicode)
            LoadDataSource(tdbdPAna12ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P12'"), gbUnicode)
            LoadDataSource(tdbdPAna13ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P13'"), gbUnicode)
            LoadDataSource(tdbdPAna14ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P14'"), gbUnicode)

            LoadDataSource(tdbdPAna15ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P15'"), gbUnicode)
            LoadDataSource(tdbdPAna16ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P16'"), gbUnicode)
            LoadDataSource(tdbdPAna17ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P17'"), gbUnicode)
            LoadDataSource(tdbdPAna18ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P18'"), gbUnicode)
            LoadDataSource(tdbdPAna19ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P19'"), gbUnicode)
            LoadDataSource(tdbdPAna20ID, ReturnTableFilter(dtPAna, "PAnaCategoryID = 'P20'"), gbUnicode)
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2010s
    '# Created User: Thanh Huyền
    '# Created Date: 21/07/2010 11:07:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2010s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLS_IsSub).ToString = "1" Then
                sSQL.Append("Update D13T2010 Set ")
                sSQL.Append("P01ID = " & SQLString(tdbg(i, COLS_P01).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P02ID = " & SQLString(tdbg(i, COLS_P02).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P03ID = " & SQLString(tdbg(i, COLS_P03).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P04ID = " & SQLString(tdbg(i, COLS_P04).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P05ID = " & SQLString(tdbg(i, COLS_P05).ToString)) 'varchar[20], NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And ")
                sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)) & " And ")
                sSQL.Append("TransID = " & SQLString(tdbg(i, COLS_TransID)))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)

                sSQL.Append("Update D13T2020 Set ")
                sSQL.Append("P06ID = " & SQLString(tdbg(i, COLS_P06).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P07ID = " & SQLString(tdbg(i, COLS_P07).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P08ID = " & SQLString(tdbg(i, COLS_P08).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P09ID = " & SQLString(tdbg(i, COLS_P09).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P10ID = " & SQLString(tdbg(i, COLS_P10).ToString)) 'varchar[20], NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And ")
                sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)) & " And ")
                sSQL.Append("TransID = " & SQLString(tdbg(i, COLS_TransID)))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)

                sSQL.Append("Update D13T2030 Set ")
                sSQL.Append("P11ID = " & SQLString(tdbg(i, COLS_P11).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P12ID = " & SQLString(tdbg(i, COLS_P12).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P13ID = " & SQLString(tdbg(i, COLS_P13).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P14ID = " & SQLString(tdbg(i, COLS_P14).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P15ID = " & SQLString(tdbg(i, COLS_P15).ToString)) 'varchar[20], NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And ")
                sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)) & " And ")
                sSQL.Append("TransID = " & SQLString(tdbg(i, COLS_TransID)))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)

                sSQL.Append("Update D13T2040 Set ")
                sSQL.Append("P16ID = " & SQLString(tdbg(i, COLS_P16).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P17ID = " & SQLString(tdbg(i, COLS_P17).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P18ID = " & SQLString(tdbg(i, COLS_P18).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P19ID = " & SQLString(tdbg(i, COLS_P19).ToString) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("P20ID = " & SQLString(tdbg(i, COLS_P20).ToString)) 'varchar[20], NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And ")
                sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COLS_EmployeeID)) & " And ")
                sSQL.Append("TransID = " & SQLString(tdbg(i, COLS_TransID)))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)

                sSQL.Append("Exec D13P0110 ")
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COLS_TransID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
                sSQL.Append(SQLNumber(1)) 'Mode, int, NOT NULL
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/10/2011 09:08:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("Key04ID, Key05ID")

            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2013") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_TransID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_EmployeeID)) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherNo)) 'Key05ID, varchar[250], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLInsertD09T6666s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("Key04ID, Key05ID")

            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2013") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("TransID").ToString) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("EmployeeID").ToString) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherNo)) 'Key05ID, varchar[250], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Lê Anh Vũ
    '# Created Date: 08/12/2014 10:11:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByVal sFormID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert bang tam D09T6666")
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append(vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COLS_EmployeeID).ToString()) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(sFormID)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")
        Next
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0201
    '# Created User: Lê Anh Vũ
    '# Created Date: 16/12/2015 03:08:55
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0201() As String
        Dim sTranID, sEmployeeID As String
        Dim iMode As Integer
        If tdbg.RowCount = 1 Then
            sTranID = L3String(tdbg(0, COLS_TransID))
            sEmployeeID = L3String(tdbg(0, COLS_EmployeeID))
            iMode = 0
        Else
            sTranID = ""
            sEmployeeID = ""
            iMode = 1
        End If
        Dim sSQL As String = ""
        sSQL &= ("-- Xu ly tinh cac ngay hieu luc tiep theo" & vbCrLf)
        sSQL &= "Exec D13P0201 "
        sSQL &= SQLString(sTranID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/07/2011 01:12:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666(ByVal sKey01ID As String) As String
        Dim sSQL As String = ""
        sSQL &= "DELETE From D09T6666" & vbCrLf
        sSQL &= "WHERE	UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND Key01ID = " & SQLString(sKey01ID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Lê Anh Vũ
    '# Created Date: 08/12/2014 10:12:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666FormID(ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= "DELETE From D09T6666" & vbCrLf
        sSQL &= "WHERE	UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND FormID = " & SQLString(sFormID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P4070
    '# Created User: Lê Anh Vũ
    '# Created Date: 08/12/2014 10:14:50
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P4070(ByVal sFormID As String, Optional ByVal iMode As Integer = 1) As String
        Dim sSQL As String = ""
        sSQL &= ("-- tinh muc luong va cac phu cap bao hiem" & vbCrLf)
        sSQL &= "Exec D21P4070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLStringUnicode("", gbUnicode, True) & COMMA 'WhereClause, nvarchar[4000], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'AdjustTypeID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'InsObjectID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(sFormID) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Kim Long
    '# Created Date: 17/01/2018 05:22:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra ky dang dung de cap nhat cho D13T0201" & vbCrlf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Num01ID, int, NOT NULL
        sSQL &= SQLNumber(0) 'IsDesktop, int, NOT NULL
        Return sSQL
    End Function



End Class