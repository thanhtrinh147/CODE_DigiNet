'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:41:10 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 22/01/2008 4:41:10 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Windows.Forms
Imports System.Text
Imports System

Public Class D13F1031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_PAnaCategoryID As Integer = 0     ' PAnaCategoryID
    Private Const COL_PAnaCategoryName84 As Integer = 1 ' Tên mã loại phân tích
    Private Const COL_PAnaCategoryName01 As Integer = 2 ' Tên mã loại phân tích
    Private Const COL_PAnaID As Integer = 3             ' Mã phân tích
    Private Const COL_PAnaName As Integer = 4           ' Diễn giải
    Private Const COL_Amount01 As Integer = 5           ' Giá trị 01
    Private Const COL_Amount02 As Integer = 6           ' Giá trị 02
    Private Const COL_Amount03 As Integer = 7           ' Giá trị 03
    Private Const COL_Amount04 As Integer = 8           ' Giá trị 04
    Private Const COL_Amount05 As Integer = 9           ' Giá trị 05
    Private Const COL_Amount06 As Integer = 10          ' Giá trị 06
    Private Const COL_Amount07 As Integer = 11          ' Giá trị 07
    Private Const COL_Amount08 As Integer = 12          ' Giá trị 08
    Private Const COL_Amount09 As Integer = 13          ' Giá trị 09
    Private Const COL_Amount10 As Integer = 14          ' Giá trị 10
#End Region

#Region "Const of tdbgRelative"
    Private Const COL1_RelativeID As Integer = 0              ' RelativeID
    Private Const COL1_RelationName As Integer = 1            ' Quan hệ
    Private Const COL1_RelationID As Integer = 2              ' RelationID
    Private Const COL1_RelativeName As Integer = 3            ' Tên người quan hệ
    Private Const COL1_BirthDate As Integer = 4               ' Ngày sinh
    Private Const COL1_BirthPlace As Integer = 5              ' Nơi sinh
    Private Const COL1_Address As Integer = 6                 ' Địa chỉ
    Private Const COL1_Occupation As Integer = 7              ' Công việc đang làm
    Private Const COL1_EducationLevelName As Integer = 8      ' Trình độ văn hóa
    Private Const COL1_EducationLevelID As Integer = 9        ' EducationLevelID
    Private Const COL1_SexName As Integer = 10                ' Giới tính
    Private Const COL1_Sex As Integer = 11                    ' Sex
    Private Const COL1_InComeTaxCode As Integer = 12          ' Mã số thuế
    Private Const COL1_IDCardNo As Integer = 13               ' Số CMND
    Private Const COL1_Salary As Integer = 14                 ' Thu nhập
    Private Const COL1_DeductibleDateBegin As Integer = 15    ' Bắt đầu GT
    Private Const COL1_DeductibleDateEnd As Integer = 16      ' Kết thúc GT
    Private Const COL1_ExamineDate As Integer = 17            ' Ngày lập
    Private Const COL1_DeductibleAmount As Integer = 18       ' Mức giảm trừ
    Private Const COL1_Note As Integer = 19                   ' Ghi chú
    Private Const COL1_BirthCertificate As Integer = 20       ' Giấy khai sinh
    Private Const COL1_ResidentCertificate As Integer = 21    ' Hộ khẩu
    Private Const COL1_MarriageCertificate As Integer = 22    ' Giấy kết hôn
    Private Const COL1_SchoolConfirmation As Integer = 23     ' Giấy xác nhân đang theo học tại các trường
    Private Const COL1_DisabilityConfirmation As Integer = 24 ' Giấy xác nhận mức độ tàn tật, không có khả năng lao động
    Private Const COL1_BringUpConfirmation As Integer = 25    ' Giấy xác nhận về nghĩa vụ nuôi dưỡng
    Private Const COL1_OtherConfirmations As Integer = 26     ' Các giấy tờ khác
    Private Const COL1_NoteConfirmation As Integer = 27       ' Ghi chú 1
#End Region

#Region "Const of tdbgH1"

    Private Const COLH1_FromMonthYear As Integer = 0     ' Từ tháng năm
    Private Const COLH1_ToMonthYear As Integer = 1       ' Đến tháng năm
    Private Const COLH1_MonthTotal As Integer = 2        ' Tổng số tháng
    Private Const COLH1_OldDivision As Integer = 3       ' Cơ quan đơn vị đã làm việc
    Private Const COLH1_OldDutyName As Integer = 4       ' Công việc
    Private Const COLH1_Note As Integer = 5              ' Ghi chú
    Private Const COLH1_BaseSalary01 As Integer = 6      ' BaseSalary01
    Private Const COLH1_BaseSalary02 As Integer = 7      ' BaseSalary02
    Private Const COLH1_BaseSalary03 As Integer = 8      ' BaseSalary03
    Private Const COLH1_BaseSalary04 As Integer = 9      ' BaseSalary04
    Private Const COLH1_SalCoefficient01 As Integer = 10 ' SalCoefficient01
    Private Const COLH1_SalCoefficient02 As Integer = 11 ' SalCoefficient02
    Private Const COLH1_SalCoefficient03 As Integer = 12 ' SalCoefficient03
    Private Const COLH1_SalCoefficient04 As Integer = 13 ' SalCoefficient04
    Private Const COLH1_SalCoefficient05 As Integer = 14 ' SalCoefficient05
    Private Const COLH1_SalCoefficient06 As Integer = 15 ' SalCoefficient06
    Private Const COLH1_SalCoefficient07 As Integer = 16 ' SalCoefficient07
    Private Const COLH1_SalCoefficient08 As Integer = 17 ' SalCoefficient08
    Private Const COLH1_SalCoefficient09 As Integer = 18 ' SalCoefficient09
    Private Const COLH1_SalCoefficient10 As Integer = 19 ' SalCoefficient10

    Private Const COLH1_SalCoefficient11 As Integer = 20 ' SalCoefficient11
    Private Const COLH1_SalCoefficient12 As Integer = 21 ' SalCoefficient12
    Private Const COLH1_SalCoefficient13 As Integer = 22 ' SalCoefficient13
    Private Const COLH1_SalCoefficient14 As Integer = 23 ' SalCoefficient14
    Private Const COLH1_SalCoefficient15 As Integer = 24 ' SalCoefficient15
    Private Const COLH1_SalCoefficient16 As Integer = 25 ' SalCoefficient16
    Private Const COLH1_SalCoefficient17 As Integer = 26 ' SalCoefficient17
    Private Const COLH1_SalCoefficient18 As Integer = 27 ' SalCoefficient18
    Private Const COLH1_SalCoefficient19 As Integer = 28 ' SalCoefficient19
    Private Const COLH1_SalCoefficient20 As Integer = 29 ' SalCoefficient20

    Private Const COLH1_OfficalTitleID As Integer = 30   ' OfficalTitleID
    Private Const COLH1_SalaryLevelID As Integer = 31    ' SalaryLevelID
    Private Const COLH1_SaCoefficient As Integer = 32    ' SaCoefficient
    Private Const COLH1_SaCoefficient12 As Integer = 33  ' SaCoefficient12
    Private Const COLH1_SaCoefficient13 As Integer = 34  ' SaCoefficient13
    Private Const COLH1_SaCoefficient14 As Integer = 35  ' SaCoefficient14
    Private Const COLH1_SaCoefficient15 As Integer = 36  ' SaCoefficient15
    Private Const COLH1_OfficalTitleID2 As Integer = 37  ' OfficalTitleID2
    Private Const COLH1_SalaryLevelID2 As Integer = 38   ' SalaryLevelID2
    Private Const COLH1_SaCoefficient2 As Integer = 39   ' SaCoefficient2
    Private Const COLH1_SaCoefficient22 As Integer = 40  ' SaCoefficient22
    Private Const COLH1_SaCoefficient23 As Integer = 41  ' SaCoefficient23
    Private Const COLH1_SaCoefficient24 As Integer = 42  ' SaCoefficient24
    Private Const COLH1_SaCoefficient25 As Integer = 43  ' SaCoefficient25
    Private Const COLH1_TransID As Integer = 44          ' TransID   
#End Region

#Region "Const of tdbgH2"
    Private Const COLH2_FromMonthYear As Integer = 0     ' Từ tháng năm
    Private Const COLH2_ToMonthYear As Integer = 1       ' Đến tháng năm
    Private Const COLH2_MonthTotal As Integer = 2        ' Tổng số tháng
    Private Const COLH2_OldDivision As Integer = 3       ' Cơ quan đơn vị đã làm việc
    Private Const COLH2_OldDutyName As Integer = 4       ' Công việc
    Private Const COLH2_Note As Integer = 5              ' Ghi chú
    Private Const COLH2_BaseSalary01 As Integer = 6      ' BaseSalary01
    Private Const COLH2_BaseSalary02 As Integer = 7      ' BaseSalary02
    Private Const COLH2_BaseSalary03 As Integer = 8      ' BaseSalary03
    Private Const COLH2_BaseSalary04 As Integer = 9      ' BaseSalary04
    Private Const COLH2_SalCoefficient01 As Integer = 10 ' SalCoefficient01
    Private Const COLH2_SalCoefficient02 As Integer = 11 ' SalCoefficient02
    Private Const COLH2_SalCoefficient03 As Integer = 12 ' SalCoefficient03
    Private Const COLH2_SalCoefficient04 As Integer = 13 ' SalCoefficient04
    Private Const COLH2_SalCoefficient05 As Integer = 14 ' SalCoefficient05
    Private Const COLH2_SalCoefficient06 As Integer = 15 ' SalCoefficient06
    Private Const COLH2_SalCoefficient07 As Integer = 16 ' SalCoefficient07
    Private Const COLH2_SalCoefficient08 As Integer = 17 ' SalCoefficient08
    Private Const COLH2_SalCoefficient09 As Integer = 18 ' SalCoefficient09
    Private Const COLH2_SalCoefficient10 As Integer = 19 ' SalCoefficient10
    Private Const COLH2_SalCoefficient11 As Integer = 20 ' SalCoefficient11
    Private Const COLH2_SalCoefficient12 As Integer = 21 ' SalCoefficient12
    Private Const COLH2_SalCoefficient13 As Integer = 22 ' SalCoefficient13
    Private Const COLH2_SalCoefficient14 As Integer = 23 ' SalCoefficient14
    Private Const COLH2_SalCoefficient15 As Integer = 24 ' SalCoefficient15
    Private Const COLH2_SalCoefficient16 As Integer = 25 ' SalCoefficient16
    Private Const COLH2_SalCoefficient17 As Integer = 26 ' SalCoefficient17
    Private Const COLH2_SalCoefficient18 As Integer = 27 ' SalCoefficient18
    Private Const COLH2_SalCoefficient19 As Integer = 28 ' SalCoefficient19
    Private Const COLH2_SalCoefficient20 As Integer = 29 ' SalCoefficient20
    Private Const COLH2_OfficalTitleID As Integer = 30   ' OfficalTitleID
    Private Const COLH2_SalaryLevelID As Integer = 31    ' SalaryLevelID
    Private Const COLH2_SaCoefficient As Integer = 32    ' SaCoefficient
    Private Const COLH2_SaCoefficient12 As Integer = 33  ' SaCoefficient12
    Private Const COLH2_SaCoefficient13 As Integer = 34  ' SaCoefficient13
    Private Const COLH2_SaCoefficient14 As Integer = 35  ' SaCoefficient14
    Private Const COLH2_SaCoefficient15 As Integer = 36  ' SaCoefficient15
    Private Const COLH2_OfficalTitleID2 As Integer = 37  ' OfficalTitleID2
    Private Const COLH2_SalaryLevelID2 As Integer = 38   ' SalaryLevelID2
    Private Const COLH2_SaCoefficient2 As Integer = 39   ' SaCoefficient2
    Private Const COLH2_SaCoefficient22 As Integer = 40  ' SaCoefficient22
    Private Const COLH2_SaCoefficient23 As Integer = 41  ' SaCoefficient23
    Private Const COLH2_SaCoefficient24 As Integer = 42  ' SaCoefficient24
    Private Const COLH2_SaCoefficient25 As Integer = 43  ' SaCoefficient25
#End Region

#Region "Const of tdbgBankID"
    Private Const COLB_BankID As Integer = 0            ' Ngận hàng
    Private Const COLB_BankName As Integer = 1          ' BankName
    Private Const COLB_BranchName As Integer = 2        ' Chi nhánh
    Private Const COLB_AccountHolderName As Integer = 3 ' Tên tài khoản
    Private Const COLB_BankAccountNo As Integer = 4     ' Số tài khoản
    Private Const COLB_ExchangeDep As Integer = 5       ' Phòng giao dịch
    Private Const COLB_IsDefault As Integer = 6         ' Mặc định
#End Region

    Private Enum ButtonD13F1031
        DeductibleInfo = 0 'Thông tin giảm trừ
        DeductibleFile = 1 'Hồ sơ chứng minh giảm trừ
    End Enum

    Dim dtSalaryLevelID As DataTable
    Dim iLastCol1 As Integer
    Dim iLastCol2 As Integer
    Private _departmentID As String = ""
    Private _teamID As String = ""
    Private _employeeID As String = ""
    Dim dtOfficialTitle As DataTable
    Dim dtBank As DataTable
    Dim dtGridBankID As DataTable
    Dim dtSalary As DataTable
    Dim dtRelativeName As DataTable
    Dim dtNextSalary As DataTable
    Dim dtCaption As DataTable
    Dim dtPCode As New DataTable
    Dim dtSALBA As New DataTable
    Dim dtSALCE As New DataTable
    Dim dtOLSC As New DataTable
    Dim bFlagPaste As Boolean = False
    Dim iColumns() As Integer = {COL1_DeductibleAmount}
    Dim bNotInList As Boolean = False

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

    Private _employeeName As String = ""
    Public WriteOnly Property EmployeeName() As String 
        Set(ByVal Value As String )
            _employeeName = Value
        End Set
    End Property

    Private _callFromModule As String = "D13"
    Public WriteOnly Property CallFromModule() As String 
        Set(ByVal Value As String )
            _callFromModule = Value
        End Set
    End Property

    Private _callFromForm As String = ""
    Public WriteOnly Property CallFromForm() As String 
        Set(ByVal Value As String )
            _callFromForm = Value
        End Set
    End Property

    Private _status As String = "0"
    Public WriteOnly Property Status() As String
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

    Private _dutyID As String = ""
    Public WriteOnly Property DutyID() As String
        Set(ByVal Value As String)
            _dutyID = Value
        End Set
    End Property

    Private _taxObjectID As String = ""
    Public WriteOnly Property TaxObjectID() As String 
        Set(ByVal Value As String )
            _taxObjectID = Value
        End Set
    End Property

    Private _paymentMethod As String = ""
    Public WriteOnly Property PaymentMethod() As String  
        Set(ByVal Value As String  )
            _paymentMethod = Value
        End Set
    End Property

    Private _divisionID As String = ""
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
        End Set
    End Property

    Private sPayrollVoucherID As String = ""
    Private sPayrollVoucherNo As String = ""
    Private sVoucherTypeID As String = ""
    Private sVoucherDate As String = ""
    Private sDescription As String = ""
    Private sCreateUserID As String = ""
    Private sLastModifyUserID As String = ""
    Dim bLoaded As Boolean = False ' Nhân dạng đã load form hay chưa???

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
            LoadInfoGeneral()
            If _divisionID.Trim = "" Then _divisionID = gsDivisionID
            dtCaption = TableD13T9000()
            tdbcSalaryLevelID_NumberFormat()
            GetTableD09T0201() ' Để trước hàm load Combo
            LoadTDBCombo()
            LoadTDBDropDown()

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormView
                    btnSave.Enabled = True
                    btnAutoCal.Enabled = False
                    btnSetDefaultSalary.Enabled = False
                    LoadEdit()
                    ' update 21/8/2012 incident 50758 
                    If (_callFromForm = "D09F1500" Or _callFromForm = "D13F1030") And L3Byte(_status) = 1 Then
                        ReadOnlyControl(tdbcSalaryObjectID)
                    End If
                Case Else 'EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnSetDefaultSalary.Enabled = True
                    LoadEdit()
                    'btnAutoCal.Enabled = _callFromModule = "D09"
                    'btnSetDefaultSalary.Enabled = _callFromModule = "D09"

                    ' update 21/8/2012 incident 50758 
                    If (_callFromForm = "" Or _callFromForm = "D13F1030") And L3Byte(_status) = 1 Then
                        ReadOnlyControl(tdbcSalaryObjectID)
                    End If
            End Select
        End Set
    End Property

    Dim dtD09T0201 As DataTable
    Private Sub GetTableD09T0201()
        'Update 24/11/2011: Incident 43324
        Dim sSQL As String = "Select Email, EmployeeID, DutyID From D09T0201  WITH (NOLOCK) Where EmployeeID = " & SQLString(_employeeID)
        dtD09T0201 = ReturnDataTable(sSQL)
        If _callFromForm <> "D13F1030" Then
            _dutyID = dtD09T0201.Rows(0).Item("DutyID").ToString
        End If
    End Sub


    Private Sub D13F1031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
        If e.Alt Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    If Me.ActiveControl.Name.Contains("tabSalaryCode") OrElse Me.ActiveControl.Parent.Name.Contains("tabSalaryCode") Then
                        tabSalaryCode.SelectedIndex = 0
                        If txtBaseSalary01.Enabled Then txtBaseSalary01.Focus()
                    Else
                        tabMain.SelectedIndex = 0
                        If tdbcTaxObjectID.Enabled Then tdbcTaxObjectID.Focus()
                    End If
                Case Keys.D2, Keys.NumPad2
                    If Me.ActiveControl.Name.Contains("tabSalaryCode") OrElse Me.ActiveControl.Parent.Name.Contains("tabSalaryCode") Then
                        tabSalaryCode.SelectedIndex = 1
                        If txtSalCoefficient01.Enabled Then txtSalCoefficient01.Focus()
                    Else
                        tabMain.SelectedIndex = 1
                        'If tdbcSalaryObjectID.Enabled Then tdbcSalaryObjectID.Focus()
                    End If
                Case Keys.D3, Keys.NumPad3
                    If Me.ActiveControl.Name.Contains("tabSalaryCode") OrElse Me.ActiveControl.Parent.Name.Contains("tabSalaryCode") Then
                        tabSalaryCode.SelectedIndex = 2
                        If tdbcOfficialTitleID.Enabled Then tdbcOfficialTitleID.Focus()
                    Else
                        tabMain.SelectedIndex = 2
                        If tdbgH2.Enabled Then tdbgH2.Focus()
                    End If


                Case Keys.D4, Keys.NumPad4
                    tabMain.SelectedIndex = 3
            End Select
        End If

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.D3, Keys.NumPad3
                    btnSal_Click(Nothing, Nothing)

                Case Keys.D4, Keys.NumPad4
                    btnOfficialTitle_Click(Nothing, Nothing)

                Case Keys.D1, Keys.NumPad1
                    Select Case tabMain.SelectedIndex
                        Case 0
                            btnDeductibleInfo_Click(Nothing, Nothing)
                        Case 2
                            btnSal2_Click(Nothing, Nothing)
                        Case 1
                            tabSalaryCode.SelectedIndex = 0
                            If txtBaseSalary01.Enabled Then txtBaseSalary01.Focus()
                    End Select
                Case Keys.D2, Keys.NumPad2
                    Select Case tabMain.SelectedIndex
                        Case 0
                            btnDeductibleFile_Click(Nothing, Nothing)
                        Case 2
                            btnOfficialTitle2_Click(Nothing, Nothing)
                        Case 1
                            tabSalaryCode.SelectedIndex = 1
                            If tdbcOfficialTitleID.Enabled Then tdbcOfficialTitleID.Focus()
                    End Select
            End Select
        End If
    End Sub

    Private Sub tdbgH1_LockedColumns()
        tdbgH1.Splits(SPLIT0).DisplayColumns(COLH1_MonthTotal).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient12).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient13).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient14).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient15).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient22).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient23).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient24).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgH1.Splits(SPLIT1).DisplayColumns(COLH1_SaCoefficient25).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

#Region "Các hàm tính toán Số tháng giữ, Ngày hiệu lực, Ngày xét tiếp theo"
    Private Structure DateEvent
        Public cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit
        Public c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit
        Public c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit
    End Structure
    Private Sub CallDate(cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit, c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit, c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit)
        'If bLoaded = False Then Exit Sub

        'Khai bảo Struct
        Dim oDateEvent As New DateEvent
        oDateEvent.cneNumMonthBasexx = cneNumMonthBasexx
        oDateEvent.c1dateBaseSalaryxxDateEnd = c1dateBaseSalaryxxDateEnd
        oDateEvent.c1dateBaseSalaryxxNextDate = c1dateBaseSalaryxxNextDate

        'Gán Tag
        cneNumMonthBasexx.Tag = oDateEvent
        c1dateBaseSalaryxxDateEnd.Tag = oDateEvent
        c1dateBaseSalaryxxNextDate.Tag = oDateEvent

        'Add Event
        AddHandler cneNumMonthBasexx.ValueChanged, AddressOf cneNumMonthBasexx_ValueChanged
        AddHandler c1dateBaseSalaryxxDateEnd.ValueChanged, AddressOf c1dateBaseSalaryxxDateEnd_ValueChanged
        AddHandler c1dateBaseSalaryxxNextDate.ValueChanged, AddressOf c1dateBaseSalaryxxNextDate_ValueChanged


    End Sub

    Private Sub CallDateBaseSalaryxxDateEnd(cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit, c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit, c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit)
        If Number(cneNumMonthBasexx.Text) = 0 AndAlso c1dateBaseSalaryxxNextDate.Text = "" Then

        ElseIf Number(cneNumMonthBasexx.Text) <> 0 AndAlso c1dateBaseSalaryxxNextDate.Text = "" Then
            If c1dateBaseSalaryxxDateEnd.Text <> "" Then
                c1dateBaseSalaryxxNextDate.Value = CDate(c1dateBaseSalaryxxDateEnd.Value).AddMonths(L3Int(cneNumMonthBasexx.Value))
            Else
                c1dateBaseSalaryxxNextDate.Value = ""
            End If

        ElseIf Number(cneNumMonthBasexx.Text) = 0 AndAlso c1dateBaseSalaryxxNextDate.Text <> "" Then
            If c1dateBaseSalaryxxDateEnd.Text <> "" Then
                cneNumMonthBasexx.Value = DateDiff(DateInterval.Month, CDate(c1dateBaseSalaryxxDateEnd.Value), CDate(c1dateBaseSalaryxxNextDate.Value))
            Else
                cneNumMonthBasexx.Value = ""
            End If
        Else
            'If c1dateBaseSalaryxxDateEnd.Text <> "" Then
            '    c1dateBaseSalaryxxNextDate.Value = CDate(c1dateBaseSalaryxxDateEnd.Value).AddMonths(L3Int(cneNumMonthBasexx.Value))
            'Else
            '    c1dateBaseSalaryxxNextDate.Value = ""
            'End If
            If c1dateBaseSalaryxxDateEnd.Text <> "" Then
                cneNumMonthBasexx.Value = DateDiff(DateInterval.Month, CDate(c1dateBaseSalaryxxDateEnd.Value), CDate(c1dateBaseSalaryxxNextDate.Value))
            Else
                cneNumMonthBasexx.Value = ""
            End If
        End If
    End Sub

    Private Sub c1dateBaseSalaryxxDateEnd_ValueChanged(sender As Object, e As System.EventArgs)
        If bLoaded = False Then Exit Sub

        Dim oDateEvent As DateEvent = CType(sender.Tag, DateEvent)

        Dim cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit = oDateEvent.cneNumMonthBasexx
        Dim c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxDateEnd
        Dim c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxNextDate
        'If c1dateBaseSalaryxxDateEnd.Text <> "" AndAlso c1dateBaseSalaryxxNextDate.Text <> "" AndAlso CDate(c1dateBaseSalaryxxDateEnd.Text) > CDate(c1dateBaseSalaryxxNextDate.Text) Then
        '    D99C0008.MsgL3(rL3("MSG000013"))
        '    c1dateBaseSalaryxxDateEnd.Focus()
        '    c1dateBaseSalaryxxDateEnd.Value = ""
        '    Exit Sub
        'End If
        bLoaded = False
        CallDateBaseSalaryxxDateEnd(cneNumMonthBasexx, c1dateBaseSalaryxxDateEnd, c1dateBaseSalaryxxNextDate)
        bLoaded = True
    End Sub


    Private Sub CallDateNumMonthBasexx(cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit, c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit, c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit)
        If c1dateBaseSalaryxxDateEnd.Text = "" AndAlso c1dateBaseSalaryxxNextDate.Text = "" Then

        ElseIf c1dateBaseSalaryxxDateEnd.Text <> "" AndAlso c1dateBaseSalaryxxNextDate.Text = "" Then
            If cneNumMonthBasexx.Text <> "" Then
                c1dateBaseSalaryxxNextDate.Value = CDate(c1dateBaseSalaryxxDateEnd.Value).AddMonths(L3Int(cneNumMonthBasexx.Value))
            Else
                c1dateBaseSalaryxxNextDate.Value = ""
            End If

        ElseIf c1dateBaseSalaryxxDateEnd.Text = "" AndAlso c1dateBaseSalaryxxNextDate.Text <> "" Then
            If cneNumMonthBasexx.Text <> "" Then
                c1dateBaseSalaryxxDateEnd.Value = CDate(c1dateBaseSalaryxxNextDate.Value).AddMonths(0 - L3Int(cneNumMonthBasexx.Value))
            Else
                c1dateBaseSalaryxxDateEnd.Value = ""
            End If
        Else
            If cneNumMonthBasexx.Text <> "" Then
                c1dateBaseSalaryxxNextDate.Value = CDate(c1dateBaseSalaryxxDateEnd.Value).AddMonths(L3Int(cneNumMonthBasexx.Value))
            Else
                c1dateBaseSalaryxxNextDate.Value = ""
            End If
        End If
    End Sub

    Private Sub cneNumMonthBasexx_ValueChanged(sender As Object, e As EventArgs)
        If bLoaded = False Then Exit Sub
        bLoaded = False

        Dim oDateEvent As DateEvent = CType(sender.Tag, DateEvent)

        Dim cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit = oDateEvent.cneNumMonthBasexx
        Dim c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxDateEnd
        Dim c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxNextDate
        CallDateNumMonthBasexx(cneNumMonthBasexx, c1dateBaseSalaryxxDateEnd, c1dateBaseSalaryxxNextDate)
        bLoaded = True

    End Sub

    Private Sub CallDateSaseSalaryxxNextDate(cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit, c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit, c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit)
        If Number(cneNumMonthBasexx.Text) = 0 AndAlso c1dateBaseSalaryxxDateEnd.Text = "" Then

        ElseIf Number(cneNumMonthBasexx.Text) <> 0 AndAlso c1dateBaseSalaryxxDateEnd.Text = "" Then
            If c1dateBaseSalaryxxNextDate.Text <> "" Then
                c1dateBaseSalaryxxDateEnd.Value = CDate(c1dateBaseSalaryxxNextDate.Value).AddMonths(0 - L3Int(cneNumMonthBasexx.Value))
            Else
                c1dateBaseSalaryxxDateEnd.Value = ""
            End If
        ElseIf Number(cneNumMonthBasexx.Text) = 0 AndAlso c1dateBaseSalaryxxDateEnd.Text <> "" Then
            If c1dateBaseSalaryxxNextDate.Text <> "" Then
                cneNumMonthBasexx.Value = DateDiff(DateInterval.Month, CDate(c1dateBaseSalaryxxDateEnd.Value), CDate(c1dateBaseSalaryxxNextDate.Value))

            Else
                cneNumMonthBasexx.Value = ""
            End If
        Else
            'If c1dateBaseSalaryxxNextDate.Text <> "" Then
            '    c1dateBaseSalaryxxDateEnd.Value = CDate(c1dateBaseSalaryxxNextDate.Value).AddMonths(0 - L3Int(cneNumMonthBasexx.Value))
            'Else
            '    c1dateBaseSalaryxxDateEnd.Value = ""
            'End If
            If c1dateBaseSalaryxxNextDate.Text <> "" Then
                cneNumMonthBasexx.Value = DateDiff(DateInterval.Month, CDate(c1dateBaseSalaryxxDateEnd.Value), CDate(c1dateBaseSalaryxxNextDate.Value))

            Else
                cneNumMonthBasexx.Value = ""
            End If
        End If
    End Sub
    Private Sub c1dateBaseSalaryxxNextDate_ValueChanged(sender As Object, e As System.EventArgs)
        If bLoaded = False Then Exit Sub
        Dim oDateEvent As DateEvent = CType(sender.Tag, DateEvent)
        Dim cneNumMonthBasexx As C1.Win.C1Input.C1NumericEdit = oDateEvent.cneNumMonthBasexx
        Dim c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxDateEnd
        Dim c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit = oDateEvent.c1dateBaseSalaryxxNextDate
        'If c1dateBaseSalaryxxDateEnd.Text <> "" AndAlso c1dateBaseSalaryxxNextDate.Text <> "" AndAlso CDate(c1dateBaseSalaryxxDateEnd.Text) > CDate(c1dateBaseSalaryxxNextDate.Text) Then
        '    D99C0008.MsgL3(rL3("MSG000013"))
        '    c1dateBaseSalaryxxNextDate.Focus()
        '    c1dateBaseSalaryxxNextDate.Value = ""
        '    Exit Sub
        'End If
        bLoaded = False
        CallDateSaseSalaryxxNextDate(cneNumMonthBasexx, c1dateBaseSalaryxxDateEnd, c1dateBaseSalaryxxNextDate)
        bLoaded = True
    End Sub


#End Region
    Private Sub D13F1031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        'If _divisionID.Trim = "" Then _divisionID = gsDivisionID
        tdbgBankID.Columns(COLB_AccountHolderName).DefaultValue = _employeeName
        tdbgRelative.Columns(COL1_ExamineDate).DefaultValue = Date.Now.ToShortDateString ' update 9/9/2013 id 56751

        'Update 24/05/2012: Incident 48637 
        tdbgRelative.Splits(1).DisplayColumns(COL1_DeductibleAmount).Visible = False

        'Update 21/08/2012: Incident 50602 
        If Not D13Systems.IsUsedPAna Then grpSalCode.Visible = False

        Loadlanguage()
        SetBackColorObligatory()
        ResetFooterGrid(tdbgRelative, 0, 1)
        tdbgRelative_NumberFormat()
        tdbcSalaryLevelID_NumberFormat()
        InputDateInTrueDBGrid(tdbgRelative, COL1_DeductibleDateBegin, COL1_DeductibleDateEnd, COL1_ExamineDate)

        'Số tháng giữ
        InputNumber(New C1.Win.C1Input.C1NumericEdit() {cneNumMonthBase01, cneNumMonthBase02, cneNumMonthBase03, cneNumMonthBase04}, SqlDbType.Decimal, "N0", False, 28, 8)
        InputNumber(New C1.Win.C1Input.C1NumericEdit() {cneNumMonthSalCoe01, cneNumMonthSalCoe02, cneNumMonthSalCoe03, cneNumMonthSalCoe04, cneNumMonthSalCoe05, cneNumMonthSalCoe06, cneNumMonthSalCoe07, cneNumMonthSalCoe08, cneNumMonthSalCoe09, cneNumMonthSalCoe10}, SqlDbType.Decimal, "N0", False, 28, 8)
        InputNumber(New C1.Win.C1Input.C1NumericEdit() {cneNumMonthSalCoe11, cneNumMonthSalCoe12, cneNumMonthSalCoe13, cneNumMonthSalCoe14, cneNumMonthSalCoe15, cneNumMonthSalCoe16, cneNumMonthSalCoe17, cneNumMonthSalCoe18, cneNumMonthSalCoe19, cneNumMonthSalCoe20}, SqlDbType.Decimal, "N0", False, 28, 8)

        GetBaseSalary()
        GetSalCoefficient()
        GetOLSC()
        InputbyUnicode(Me, gbUnicode)
        btnSal_Click(Nothing, Nothing)
        btnSal2_Click(Nothing, Nothing)
        ResetColorGrid(tdbgH2, 0, 1)
        LoadTdbgH1()
        LoadTdbgH2()
        LoadTDBGBankID()
        txt_NumberFormat1()
        tdbg_LockedColumns()
        tdbgH1_LockedColumns()
        tdbgBankID_LockedColumns()
        CheckNumber()

        LoadCaptiontdbdSalaryLevelID(tdbdSalaryLevelID, dtOLSC, 1, gbUnicode)
        LoadCaptiontdbdSalaryLevelID(tdbdSalaryLevelID2, dtOLSC, 2, gbUnicode)

        'btnDeductibleInfo_Click(Nothing, Nothing)
        ClickButton(ButtonD13F1031.DeductibleInfo)

        If Not ((_callFromModule = "D09" And _FormState = EnumFormState.FormAdd) Or (_callFromModule = "D09" And _status = "0") Or (_callFromModule = "D13" And _status = "0")) Then
            For Each ctrl As Control In grpRank.Controls
                ReadOnlyControl(ctrl)
            Next
            For Each ctrl As Control In grpRank2.Controls
                ReadOnlyControl(ctrl)
            Next

            For Each ctrl As Control In tabSalaryCode1.Controls 'grpSal.Controls
                ReadOnlyControl(ctrl)
            Next
            For Each ctrl As Control In tabSalaryCode2.Controls 'grpCoef.Controls
                ReadOnlyControl(ctrl)
            Next

            btnAutoCal.Enabled = False
            btnSetDefaultSalary.Enabled = False
        End If
        InitCallDate()
        InputDateCustomFormat(c1dateBaseSalary01NextDate, c1dateBaseSalary03NextDate, c1dateBaseSalary01DateEnd, c1dateBaseSalary02NextDate, c1dateBaseSalary04NextDate, c1dateBaseSalary02DateEnd, c1dateBaseSalary04DateEnd, c1dateBaseSalary03DateEnd, c1dateSal13DateEnd, c1dateSal03DateEnd, c1dateSal16NextDate, c1dateSal06NextDate, c1dateSal12DateEnd, c1dateSal02DateEnd, c1dateSal17NextDate, c1dateSal07NextDate, c1dateSal14DateEnd, c1dateSal04DateEnd, c1dateSal15NextDate, c1dateSal05NextDate, c1dateSal11DateEnd, c1dateSal01DateEnd, c1dateSal18NextDate, c1dateSal08NextDate, c1dateSal15DateEnd, c1dateSal05DateEnd, c1dateSal14NextDate, c1dateSal04NextDate, c1dateSal19NextDate, c1dateSal09NextDate, c1dateSal16DateEnd, c1dateSal06DateEnd, c1dateSal13NextDate, c1dateSal03NextDate, c1dateSal20NextDate, c1dateSal10NextDate, c1dateSal17DateEnd, c1dateSal07DateEnd, c1dateSal12NextDate, c1dateSal02NextDate, c1dateSal18DateEnd, c1dateSal11NextDate, c1dateSal08DateEnd, c1dateSal01NextDate, c1dateSal19DateEnd, c1dateSal20DateEnd, c1dateSal09DateEnd, c1dateSal10DateEnd, c1dateOffSa1NextDate2, c1dateOffSa1DateEnd2, c1dateOffSa1NextDate, c1dateOffSa1DateEnd)
        bLoaded = True
        InputDateInTrueDBGrid(tdbgH1, COLH1_FromMonthYear, COLH1_ToMonthYear)
        If _status = "1" Then ReadOnlyAll(TabPage2) 'ReadOnly Tab Thông số lương
        If _callFromForm.Contains("D09U") Then 'ID 81478 07/12/2015
            ReadOnlyAll(TabPage2) 'ReadOnly Tab Thông số lương
            ReadOnlyAll(Tabpage3) 'ReadOnly Tab Lịch sử lương
            ReadOnlyAll(TabPage4) 'ReadOnly Tab Khác
        End If
        SetResolutionForm(Me)
    End Sub

    Private Sub InitCallDate()
        CallDate(cneNumMonthBase01, c1dateBaseSalary01DateEnd, c1dateBaseSalary01NextDate)
        CallDate(cneNumMonthBase02, c1dateBaseSalary02DateEnd, c1dateBaseSalary02NextDate)
        CallDate(cneNumMonthBase03, c1dateBaseSalary03DateEnd, c1dateBaseSalary03NextDate)
        CallDate(cneNumMonthBase04, c1dateBaseSalary04DateEnd, c1dateBaseSalary04NextDate)

        CallDate(cneNumMonthSalCoe01, c1dateSal01DateEnd, c1dateSal01NextDate)
        CallDate(cneNumMonthSalCoe02, c1dateSal02DateEnd, c1dateSal02NextDate)
        CallDate(cneNumMonthSalCoe03, c1dateSal03DateEnd, c1dateSal03NextDate)
        CallDate(cneNumMonthSalCoe04, c1dateSal04DateEnd, c1dateSal04NextDate)
        CallDate(cneNumMonthSalCoe05, c1dateSal05DateEnd, c1dateSal05NextDate)
        CallDate(cneNumMonthSalCoe06, c1dateSal06DateEnd, c1dateSal06NextDate)
        CallDate(cneNumMonthSalCoe07, c1dateSal07DateEnd, c1dateSal07NextDate)
        CallDate(cneNumMonthSalCoe08, c1dateSal08DateEnd, c1dateSal08NextDate)
        CallDate(cneNumMonthSalCoe09, c1dateSal09DateEnd, c1dateSal09NextDate)
        CallDate(cneNumMonthSalCoe10, c1dateSal10DateEnd, c1dateSal10NextDate)
        CallDate(cneNumMonthSalCoe11, c1dateSal11DateEnd, c1dateSal11NextDate)
        CallDate(cneNumMonthSalCoe12, c1dateSal12DateEnd, c1dateSal12NextDate)
        CallDate(cneNumMonthSalCoe13, c1dateSal13DateEnd, c1dateSal13NextDate)
        CallDate(cneNumMonthSalCoe14, c1dateSal14DateEnd, c1dateSal14NextDate)
        CallDate(cneNumMonthSalCoe15, c1dateSal15DateEnd, c1dateSal15NextDate)
        CallDate(cneNumMonthSalCoe16, c1dateSal16DateEnd, c1dateSal16NextDate)
        CallDate(cneNumMonthSalCoe17, c1dateSal17DateEnd, c1dateSal17NextDate)
        CallDate(cneNumMonthSalCoe18, c1dateSal18DateEnd, c1dateSal18NextDate)
        CallDate(cneNumMonthSalCoe19, c1dateSal19DateEnd, c1dateSal19NextDate)
        CallDate(cneNumMonthSalCoe20, c1dateSal20DateEnd, c1dateSal20NextDate)
    End Sub
    Private Sub CheckNumber()

        Dim arrSALBA(3) As Integer
        For i As Integer = 0 To 3
            arrSALBA.SetValue(L3Int(dtSALBA.Rows(i).Item("Decimals")), i)
        Next
        '***************
        Dim arrBaseSalary() As TextBox = {txtBaseSalary01, txtBaseSalary02, txtBaseSalary03, txtBaseSalary04}
        CheckNumberTextBox(arrBaseSalary, arrSALBA)
        '***************
        Dim arrNextBaseSalary() As TextBox = {txtNextBaseSalary01, txtNextBaseSalary02, txtNextBaseSalary03, txtNextBaseSalary04}
        CheckNumberTextBox(arrNextBaseSalary, arrSALBA)
        '***************
        Dim arrSALCE(19) As Integer
        For i As Integer = 0 To 19
            arrSALCE.SetValue(L3Int(dtSALCE.Rows(i).Item("Decimals")), i)
        Next
        '***************
        Dim arrSalCoeffi(19) As TextBox
        For i As Integer = 0 To 9
            arrSalCoeffi.SetValue(tabpageCoefficient1.Controls("txtSalCoefficient" & (i + 1).ToString("00")), i)
        Next
        For i As Integer = 10 To 19
            arrSalCoeffi.SetValue(tabpageCoefficient2.Controls("txtSalCoefficient" & (i + 1).ToString("00")), i)
        Next
        CheckNumberTextBox(arrSalCoeffi, arrSALCE)
        '***************
        Dim arrNextSalCoeffi(19) As TextBox
        For i As Integer = 0 To 9
            arrNextSalCoeffi.SetValue(tabpageCoefficient1.Controls("txtNextSalCoefficient" & (i + 1).ToString("00")), i)
        Next
        For i As Integer = 10 To 19
            arrNextSalCoeffi.SetValue(tabpageCoefficient2.Controls("txtNextSalCoefficient" & (i + 1).ToString("00")), i)
        Next
        CheckNumberTextBox(arrNextSalCoeffi, arrSALCE)
        '***************
        Dim arrTextbox() As TextBox = {txtSalaryCoefficient, txtSalaryCoefficient2, txtNextSalaryCoefficient, txtNextSalaryCoefficient2}
        CheckNumberTextBox(arrTextbox, D13Format.DefaultNumber2)

        '***************
        'Grid Relative
        Dim iColRelative() As Integer = {COL1_Salary, COL1_DeductibleAmount}
        CheckNumberTDBGrid(tdbgRelative, iColRelative)

        'Grid H1
        Dim iarrBaseSalary(COLH1_SalCoefficient20 - COLH1_BaseSalary01) As Integer
        For i As Integer = 0 To iarrBaseSalary.Length - 1
            iarrBaseSalary.SetValue(COLH1_BaseSalary01 + i, i)
        Next
        CheckNumberTDBGrid(tdbgH1, iarrBaseSalary)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Cap_nhat_ho_so_luong_goc_-_D13F1031") & UnicodeCaption(gbUnicode)
        'CËp nhËt hä s¥ l§¥ng gçc - D13F1031
        '================================================================ 
        lblH1.Text = rL3("Lich_su_luong_truoc_khi_vao_cong_ty") 'Lịch sử lương trước khi vào công ty
        lblH2.Text = rL3("Lich_su_luong_tai_cong_ty") 'Lịch sử lương tại công ty

        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rL3("Nhan_vien") 'Nhân viên
        lblEmpGroupID.Text = rL3("Nhom_nhan_vien")
        lblTaxObjectID.Text = rL3("Doi_tuong_tinh_thue") 'Đối tượng tính thuế

        lblGiaTri.Text = rL3("Gia_tri_") 'Giá trị
        lblNgayXetCuoiCung.Text = rL3("Ngay_hieu_luc")
        lblNgayXetTiepTheo.Text = rL3("Ngay_xet_tiep_theo") 'Ngày xét tiếp theo
        lblNgachBacTiepTheo.Text = rL3("Ngach_bac_tiep_theo") 'Ngạch bậc tiếp theo

        lblGiaTri02.Text = rL3("Gia_tri_") 'Giá trị
        lblNgayXetCuoiCung02.Text = rL3("Ngay_hieu_luc")
        lblNgayXetTiepTheo02.Text = rL3("Ngay_xet_tiep_theo") 'Ngày xét tiếp theo
        lblNgachBacTiepTheo02.Text = rL3("Ngach_bac_tiep_theo") 'Ngạch bậc tiếp theo

        'lblNgachBacLuong.Text = rl3("Ngach_bac_luong") 'Ngạch bậc lương
        lblNgachBacLuong.Visible = False
        lblNgachBacLuong02.Visible = False

        lblOfficialTitleID1.Text = rL3("Ngach_luong_1") 'Ngạch lương 1
        lblSalaryLevelID1.Text = rL3("Bac_luong_1") 'Bậc lương 1
        lblSalaryCoefficient1.Text = rL3("He_so_luong_1") 'Hệ số lương 1
        lblOfficialTitleID2.Text = rL3("Ngach_luong_2") 'Ngạch lương 2
        lblSalaryLevelID2.Text = rL3("Bac_luong_2") 'Bậc lương 2
        lblSalaryCoefficient2.Text = rL3("He_so_luong_2") 'Hệ số lương 2
        Label1.Text = rL3("Gia_tri_") 'Giá trị
        Label6.Text = rL3("Luong_co_ban") 'Lương cơ bản
        'Label7.Text = rl3("Ngay_xet_cuoi_cungU") 'Ngày xét cuối cùng
        Label7.Text = rL3("Ngay_hieu_luc") ''Ngày hiệu lực
        Label8.Text = rL3("Ngay_xet_tiep_theo") 'Ngày xét tiếp theo
        Label9.Text = rL3("Muc_luong_tiep_theo") 'Mức lương tiếp theo
        'lblNgayXetCuoiCung2.Text = rl3("Ngay_xet_cuoi_cungU") 'Ngày xét cuối cùng
        lblNgayXetCuoiCung2.Text = rL3("Ngay_hieu_luc") 'Ngày hiệu lực
        lblHeSoLuong.Text = rL3("He_so_luong") 'Hệ số lương
        lblGiaTri2.Text = rL3("Gia_tri_") 'Giá trị
        lblNgayXetTiepTheo2.Text = rL3("Ngay_xet_tiep_theo") 'Ngày xét tiếp theo
        lblHeSoLuongTiepTheo2.Text = rL3("HSL_tiep_theo") 'HSL tiếp theo

        lblNgayXetCuoiCung21.Text = rL3("Ngay_hieu_luc") 'Ngày hiệu lực
        lblHeSoLuong1.Text = rL3("He_so_luong") 'Hệ số lương
        lblGiaTri21.Text = rL3("Gia_tri_") 'Giá trị
        lblNgayXetTiepTheo21.Text = rL3("Ngay_xet_tiep_theo") 'Ngày xét tiếp theo
        lblHeSoLuongTiepTheo21.Text = rL3("HSL_tiep_theo") 'HSL tiếp theo

        lblBankID.Text = rL3("Ngan_hang") 'Ngân hàng

        lblBaseCurrencyID01.Text = rL3("Nguyen_te")
        lblSalCoeCurrencyID01.Text = rL3("Nguyen_te")
        lblSalCoeCurrencyID11.Text = rL3("Nguyen_te")
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSal.Text = "3. " & rL3("Muc_luong_He_so") 'Mức lương/ Hệ số
        btnOfficialTitle.Text = "4. " & rL3("Ngach_bac_luong")
        btnSal2.Text = "1. " & rL3("Muc_luong_He_so") 'Mức lương/ Hệ số
        btnOfficialTitle2.Text = "2. " & rL3("Ngach_bac_luong") 'Ngạch/ Bậc lương
        btnAutoCal.Text = rL3("_Cap_nhat_thong_so_luong_theo_doi_tuong_tinh_luong") '&Cập nhật thông số lương theo đối tượng tính lương
        btnSetDefaultSalary.Text = rL3("_Gan_thong_so_luong_mac_dinh") '&Gán thông số lương mặc định
        btnDeductibleInfo.Text = "1. " & rL3("Thong_tin_giam_tru") 'Thông tin giảm trừ
        btnDeductibleFile.Text = "2. " & rL3("Ho_so_chung_minh_giam_tru") 'Hồ sơ chứng minh giảm trừ
        '================================================================ 
        optPaymentMethodO.Text = rL3("Khac") 'Khác
        optPaymentMethodB.Text = rL3("Chuyen_khoan") 'Chuyển khoản
        optPaymentMethodC.Text = rL3("Tien_mat") 'Tiền mặt
        '================================================================ 
        grp6.Text = rL3("Giam_tru_gia_canh")

        grpRank.Text = rL3("Ngach_bac_luong") & " 1"
        grpRank2.Text = rL3("Ngach_bac_luong") & " 2"
        grpSalCode.Text = rL3("Ma_phan_tich_tien_luong")
        grpSalMethod.Text = rL3("Phuong_phap_tra_luong")
        '================================================================ 
        TabPage1.Text = "1. " & rL3("Thong_tin_chinh") '1. Thông tin chính
        TabPage2.Text = "2. " & rL3("Cac_thong_so_luong")
        Tabpage3.Text = "3. " & rL3("Lich_su_luong") 'Lịch sử lương
        TabPage4.Text = "4. " & rL3("Khac")

        tabSalaryCode1.Text = "1. " & rL3("Muc_luong")
        tabSalaryCode2.Text = "2. " & rL3("He_so")
        tabSalaryCode3.Text = "3. " & rL3("Ngach_bac_luong")

        tabpageCoefficient1.Text = "1. " & rL3("He_so") & " 1 - 10"
        tabpageCoefficient2.Text = "2. " & rL3("He_so") & " 11 - 20"

        '================================================================ 
        tdbcTaxObjectID.Columns("TaxObjectID").Caption = rL3("Ma") 'Mã
        tdbcTaxObjectID.Columns("TaxObjectName").Caption = rL3("Ten") 'Tên
        tdbcSalEmpGroupID.Columns("SalEmpGroupID").Caption = rL3("Ma") 'Mã
        tdbcSalEmpGroupID.Columns("SalEmpGroupName").Caption = rL3("Ten") 'Tên

        tdbcNextSalaryLevelID2.Columns("NumberYearTransfer").Caption = rL3("Thoi_gian_giu_bac") 'Thời gian giữ bậc
        tdbcNextSalaryLevelID2.Columns("Grade").Caption = rL3("Bac_luong")

        tdbcNextSalaryLevelID.Columns("NumberYearTransfer").Caption = rL3("Thoi_gian_giu_bac") 'Thời gian giữ bậc
        tdbcNextSalaryLevelID.Columns("Grade").Caption = rL3("Bac_luong")

        tdbcSalaryLevelID2.Columns("NumberYearTransfer").Caption = rL3("Thoi_gian_giu_bac") 'Thời gian giữ bậc
        tdbcSalaryLevelID2.Columns("Grade").Caption = rL3("Bac_luong")

        tdbcSalaryLevelID.Columns("NumberYearTransfer").Caption = rL3("Thoi_gian_giu_bac") 'Thời gian giữ bậc
        tdbcSalaryLevelID.Columns("Grade").Caption = rL3("Bac_luong")

        tdbcNextOfficialTitleID2.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcNextOfficialTitleID2.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên

        tdbcNextOfficialTitleID.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcNextOfficialTitleID.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên

        tdbcOfficialTitleID2.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcOfficialTitleID2.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên

        tdbcOfficialTitleID.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcOfficialTitleID.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcBaseCurrencyID01.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcBaseCurrencyID01.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcBaseCurrencyID02.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcBaseCurrencyID02.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcBaseCurrencyID03.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcBaseCurrencyID03.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcBaseCurrencyID04.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcBaseCurrencyID04.Columns("CurrencyName").Caption = rL3("Ten") 'Tên

        tdbcSalCoeCurrencyID01.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID01.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID02.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID02.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID03.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID04.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID05.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID05.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID06.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID06.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID07.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID07.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID08.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID08.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID09.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID09.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID10.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID10.Columns("CurrencyName").Caption = rL3("Ten") 'Tên

        tdbcSalCoeCurrencyID11.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID11.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID12.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID12.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID13.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID14.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID15.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID15.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID16.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID16.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID17.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID17.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID18.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID18.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID19.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID19.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbcSalCoeCurrencyID20.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbcSalCoeCurrencyID20.Columns("CurrencyName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        tdbdRelationID.Columns("RelationName").Caption = rL3("Ten") 'Tên
        tdbdRelativeName.Columns("RelativeName").Caption = rL3("Ten") 'Tên
        tdbdSex.Columns("Sex").Caption = rL3("Ma") 'Mã
        tdbdSex.Columns("SexName").Caption = rL3("Ten") 'Tên
        tdbdEducationLevelID.Columns("EducationLevelID").Caption = rL3("Ma") 'Mã
        tdbdEducationLevelID.Columns("EducationLevelName").Caption = rL3("Ten") 'Tên
        tdbdPAnaID.Columns("PAnaID").Caption = rL3("Ma") 'Mã
        tdbdPAnaID.Columns("PAnaName").Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbgRelative.Columns("RelationName").Caption = rL3("Quan_he") 'Quan hệ
        tdbgRelative.Columns("RelativeName").Caption = rL3("Ten_nguoi_quan_he") 'Tên người quan hệ
        tdbgRelative.Columns("BirthDate").Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbgRelative.Columns("BirthPlace").Caption = rL3("Noi_sinh") 'Nơi sinh
        tdbgRelative.Columns("Address").Caption = rL3("Dia_chi") 'Địa chỉ
        tdbgRelative.Columns("Occupation").Caption = rL3("Cong_viec_dang_lam") 'Công việc đang làm
        tdbgRelative.Columns("EducationLevelName").Caption = rL3("Trinh_do_van_hoa_U") 'Trình độ văn hóa
        tdbgRelative.Columns("SexName").Caption = rL3("Gioi_tinh") 'Giới tính
        tdbgRelative.Columns("InComeTaxCode").Caption = rL3("Ma_so_thue") 'Mã số thuế
        tdbgRelative.Columns("IDCardNo").Caption = rL3("So_CMND") 'Số CMND
        tdbgRelative.Columns("Salary").Caption = rL3("Thu_nhap") 'Thu nhập
        tdbgRelative.Columns("DeductibleDateBegin").Caption = rL3("Bat_dau_GT") 'Bắt đầu GT
        tdbgRelative.Columns("DeductibleDateEnd").Caption = rL3("Ket_thuc_GT") 'Kết thúc GT
        tdbgRelative.Columns("ExamineDate").Caption = rL3("Ngay_lap") 'Ngày lập ' update 9/9/2013 id 56751
        tdbgRelative.Columns("DeductibleAmount").Caption = rL3("Muc_giam_tru") 'Mức giảm trừ
        tdbgRelative.Columns("Note").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbgRelative.Columns("BirthCertificate").Caption = rL3("Giay_khai_sinh") 'Giấy khai sinh
        tdbgRelative.Columns("ResidentCertificate").Caption = rL3("Ho_khau") 'Hộ khẩu
        tdbgRelative.Columns("MarriageCertificate").Caption = rL3("Giay_ket_hon") 'Giấy kết hôn
        tdbgRelative.Columns("SchoolConfirmation").Caption = rL3("Giay_xac_nhan_dang_theo_hoc_tai_cac_truong") 'Giấy xác nhân đang theo học tại các trường
        tdbgRelative.Columns("DisabilityConfirmation").Caption = rL3("Giay_xac_nhan_muc_do_tan_tat_khong_co_kha_nang_lao_dong") 'Giấy xác nhận mức độ tàn tật, không có khả năng lao động
        tdbgRelative.Columns("BringUpConfirmation").Caption = rL3("Giay_xac_nhan_ve_nghia_vu_nuoi_duong") 'Giấy xác nhận về nghĩa vụ nuôi dưỡng
        tdbgRelative.Columns("OtherConfirmations").Caption = rL3("Cac_giay_to_khac") 'Các giấy tờ khác
        tdbgRelative.Columns("NoteConfirmation").Caption = rL3("Ghi_chu") 'Ghi chú

        tdbg.Columns("PAnaCategoryName84").Caption = rL3("Ten_ma_loai_phan_tich") 'Tên mã loại phân tích
        tdbg.Columns("PAnaCategoryName01").Caption = rL3("Ten_ma_loai_phan_tich") 'Tên mã loại phân tích
        tdbg.Columns("PAnaID").Caption = rL3("Ma_phan_tich") 'Mã phân tích
        tdbg.Columns("PAnaName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("Amount01").Caption = rL3("Gia_tri_01") 'Giá trị 01
        tdbg.Columns("Amount02").Caption = rL3("Gia_tri_02") 'Giá trị 02
        tdbg.Columns("Amount03").Caption = rL3("Gia_tri_03") 'Giá trị 03
        tdbg.Columns("Amount04").Caption = rL3("Gia_tri_04") 'Giá trị 04
        tdbg.Columns("Amount05").Caption = rL3("Gia_tri_05") 'Giá trị 05
        tdbg.Columns("Amount06").Caption = rL3("Gia_tri_06") 'Giá trị 06
        tdbg.Columns("Amount07").Caption = rL3("Gia_tri_07") 'Giá trị 07
        tdbg.Columns("Amount08").Caption = rL3("Gia_tri_08") 'Giá trị 08
        tdbg.Columns("Amount09").Caption = rL3("Gia_tri_09") 'Giá trị 09
        tdbg.Columns("Amount10").Caption = rL3("Gia_tri_10") 'Giá trị 10

        tdbgH2.Columns("FromMonthYear").Caption = rL3("Tu_thang_nam") 'Từ tháng năm
        tdbgH2.Columns("ToMonthYear").Caption = rL3("Den_thang_nam") 'Đến tháng năm
        tdbgH2.Columns("MonthTotal").Caption = rL3("Tong_so_thang") 'Tổng số tháng
        tdbgH2.Columns("OldDutyName").Caption = rL3("Cong_viec") 'Công việc
        tdbgH2.Splits(0).Caption = rL3("Thong_tin_chinh")

        tdbgH1.Columns("Note").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbgH1.Columns("OldDivision").Caption = rL3("Co_quan__don_vi_da_lam_viec") 'Cơ quan đơn vị đã làm việc
        tdbgH1.Columns("FromMonthYear").Caption = rL3("Tu_thang_nam") 'Từ tháng năm
        tdbgH1.Columns("ToMonthYear").Caption = rL3("Den_thang_nam") 'Đến tháng năm
        tdbgH1.Columns("MonthTotal").Caption = rL3("Tong_so_thang") 'Tổng số tháng
        tdbgH1.Columns("OldDutyName").Caption = rL3("Cong_viec") 'Công việc
        tdbgH1.Splits(0).Caption = rL3("Thong_tin_chinh")

        tdbgBankID.Columns(COLB_BankID).Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbgBankID.Columns(COLB_BranchName).Caption = rL3("Chi_nhanh") 'Chi nhánh
        tdbgBankID.Columns(COLB_AccountHolderName).Caption = rL3("Ten_tai_khoan") 'Tên tài khoản
        tdbgBankID.Columns(COLB_BankAccountNo).Caption = rL3("So_tai_khoan") 'Số tài khoản
        tdbgBankID.Columns(COLB_ExchangeDep).Caption = rL3("Phong_giao_dich") 'Phòng giao dịch
        tdbgBankID.Columns(COLB_IsDefault).Caption = rL3("Mac_dinh") 'Mặc định
        '================================================================ 
        lblSalaryObjectID.Text = rL3("Doi_tuong_tinh_luong") 'Đối tượng tính lương

        '================================================================ 
        lblNumMonthBase.Text = rL3("So_thang_giu") 'Số tháng giữ

        lblNumMonthSalCoe01_10.Text = rL3("So_thang_giu") 'Số tháng giữ
        lblNumMonthSalCoe11_20.Text = rL3("So_thang_giu") 'Số tháng giữ

    End Sub

    Private Sub SetBackColorObligatory()
        tdbcTaxObjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankAccountNo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    ' update 22/6/2013 id 56311 
    Private Sub LoadTDBOfficialTitle(ByVal sDutyID As String)
        Dim sSQL As String = ""
        'Load tdbcOfficialTitleID
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial" & vbCrLf
        sSQL &= "From D09T0214  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 1) " & vbCrLf
        ' update 22/6/2013 id 56311 
        sSQL &= "AND (DutyID = " & SQLString(sDutyID) & " OR DutyID = '' OR  " & SQLString(sDutyID) & " = '') " & vbCrLf
        sSQL &= "Order By OfficialTitleID"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcOfficialTitleID, dt1, gbUnicode)
        LoadDataSource(tdbcNextOfficialTitleID, dt1.DefaultView.ToTable, gbUnicode)

        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial" & vbCrLf
        sSQL &= "From D09T0214 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And (IsUseOfficial = 0 Or IsUseOfficial = 2)" & vbCrLf
        ' update 22/6/2013 id 56311 
        sSQL &= "AND (DutyID = " & SQLString(sDutyID) & " OR DutyID = '' OR " & SQLString(sDutyID) & " = '') " & vbCrLf
        sSQL &= "Order By OfficialTitleID"
        Dim dt2 As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcOfficialTitleID2, dt2, gbUnicode)
        LoadDataSource(tdbcNextOfficialTitleID2, dt2.DefaultView.ToTable, gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTaxObjectID
        LoadTDBCTaxObjectID()

        'Load tdbcSalEmpGroupID
        sSQL = "SELECT 	SalEmpGroupID, SalEmpGroupName84" & UnicodeJoin(gbUnicode) & " As SalEmpGroupName" & vbCrLf
        sSQL &= "FROM       D13T1180 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	SalEmpGroupID" & vbCrLf
        LoadDataSource(tdbcSalEmpGroupID, sSQL, gbUnicode)

        'Load tdbcBankID
        sSQL = "Select ObjectID BankID, ObjectName" & UnicodeJoin(gbUnicode) & " BankName, BranchName" & UnicodeJoin(gbUnicode) & " as BranchName From Object  WITH (NOLOCK) Where Disabled=0 And ObjectTypeID='NH' Order by ObjectID "
        LoadDataSource(tdbdBankID, sSQL, gbUnicode)

        'Load tdbcSalaryLevelID
        sSQL = "Select SalaryLevelID, SalaryCoefficient," & vbCrLf
        sSQL &= "SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05," & vbCrLf
        sSQL &= "OfficialTitleID, NumberYearTransfer, Grade" & vbCrLf
        sSQL &= "From D09T0215 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        sSQL &= "Order By Grade "
        dtSalary = ReturnDataTable(sSQL)

        LoadTDBCSalaryObjectID()

        'Load 24 combo Nguyên tệ
        sSQL = "--Do 24 nguon combo Nguyen te" & vbCrLf
        sSQL &= "SELECT		CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " AS CurrencyName" & vbCrLf
        sSQL &= "FROM 		D91T0010 " & vbCrLf
        sSQL &= "WHERE 	Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	CurrencyID"
        Dim dtCurrencyID As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbcBaseCurrencyID01, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcBaseCurrencyID02, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcBaseCurrencyID03, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcBaseCurrencyID04, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID01, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID02, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID03, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID04, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID05, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID06, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID07, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID08, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID09, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID10, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID11, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID12, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID13, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID14, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID15, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID16, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID17, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID18, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID19, dtCurrencyID.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcSalCoeCurrencyID20, dtCurrencyID.DefaultView.ToTable, gbUnicode)
    End Sub

    Private Sub LoadTDBCSalaryObjectID()
        Dim sSQL As String = ""
        sSQL = "Select '+'  as SalaryObjectID, " & NewName & " as SalaryObjectName Union " & vbCrLf
        sSQL &= " SELECT 		SalaryObjectID," & vbCrLf
        sSQL &= " 			SalaryObjectName" & UnicodeJoin(gbUnicode) & " as SalaryObjectName" & vbCrLf
        sSQL &= " 	FROM		D13T1020 WITH (NOLOCK) " & vbCrLf
        sSQL &= " 	WHERE 		Disabled=0 " & vbCrLf
        'Update 24/11/2011: Incident 43324
        sSQL &= " 	And 	(DutyID = " & SQLString(_dutyID) & " Or DutyID ='') " & vbCrLf
        sSQL &= " 	ORDER BY 	SalaryObjectID" & vbCrLf
        LoadDataSource(tdbcSalaryObjectID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCTaxObjectID()
        Dim sSQL As String = ""
        sSQL = "Select '+'  as TaxObjectID, " & NewName & " as TaxObjectName Union" & vbCrLf
        sSQL &= "Select TaxObjectID, TaxObjectName" & UnicodeJoin(gbUnicode) & " as TaxObjectName From D13T0128  WITH (NOLOCK) Where Disabled=0 Order By TaxObjectID"
        LoadDataSource(tdbcTaxObjectID, sSQL, gbUnicode)
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
        sSQL = "SELECT RelativeName" & UnicodeJoin(gbUnicode) & " as RelativeName, RelationID, " & vbCrLf
        sSQL &= "convert(varchar(10),D2.BirthDate,103) as BirthDate, D2.BirthPlace" & UnicodeJoin(gbUnicode) & " as BirthPlace, D2.Address" & UnicodeJoin(gbUnicode) & " as Address," & vbCrLf
        sSQL &= "D2.Occupation" & UnicodeJoin(gbUnicode) & " as Occupation, D2.EducationLevelID, " & vbCrLf
        sSQL &= "D2.InComeTaxCode,	D2.IDCardNo, " & vbCrLf
        sSQL &= "D1.EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName,	D2.Sex, " & vbCrLf
        sSQL &= "(Case when D2.Sex = '0' then 'Nam' else " & IIf(gbUnicode, "N'Nữ'", "'Nöõ'").ToString & " end) as SexName" & vbCrLf
        sSQL &= "FROM D09T0216 D2 WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN D09T0206 D1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "ON D2.EducationLevelID = D1.EducationLevelID" & vbCrLf
        sSQL &= "WHERE D2.EmployeeID = " & SQLString(_employeeID)
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

        'Load tdbdPAnaID
        'sSQL = "Select * From D13T1050 "
        sSQL = "Select PAnaID, PAnaCategoryID, PAnaName" & UnicodeJoin(gbUnicode) & " as PAnaName," & vbCrLf
        sSQL &= "Disabled, Amount01,Amount02, Amount03, Amount04, Amount05, Amount06," & vbCrLf
        sSQL &= "Amount07, Amount08, Amount09, Amount10" & vbCrLf
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate from D13T1050 WITH (NOLOCK) "
        dtPCode = ReturnDataTable(sSQL)

        Dim dtOfficialTitle As DataTable
        'Load tdbdOfficialTitleID1, 2
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial From D09T0214  WITH (NOLOCK) Where Disabled = 0  Order By OfficialTitleID "
        dtOfficialTitle = ReturnDataTable(sSQL)

        LoadDataSource(tdbdOfficialTitleID, ReturnTableFilter(dtOfficialTitle, "IsUseOfficial = 0 OR IsUseOfficial = 1"), gbUnicode)
        LoadDataSource(tdbdOfficialTitleID2, ReturnTableFilter(dtOfficialTitle, "IsUseOfficial = 0 OR IsUseOfficial = 2"), gbUnicode)

        'Load tdbdSalaryLevelID
        sSQL = "Select SalaryLevelID, SalaryCoefficient,SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, OfficialTitleID, NumberYearTransfer, Grade From D09T0215  WITH (NOLOCK) Where Disabled = 0  Order By Grade "
        dtSalaryLevelID = ReturnDataTable(sSQL)
        LoadtdbdSalaryLevelID(tdbdSalaryLevelID, "-1")
        LoadtdbdSalaryLevelID(tdbdSalaryLevelID2, "-1")
    End Sub

    Private Sub LoadtdbdRelativeName(ByVal ID As String)
        LoadDataSource(tdbdRelativeName, ReturnTableFilter(dtRelativeName, " RelationID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub tdbcSalaryLevelID_NumberFormat()
        For i As Integer = 0 To dtOLSC.Rows.Count - 1
            Select Case dtOLSC.Rows(i).Item("Code").ToString
                Case "OLSC11"
                    tdbcSalaryLevelID.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC12"
                    tdbcSalaryLevelID.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC13"
                    tdbcSalaryLevelID.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC14"
                    tdbcSalaryLevelID.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC15"
                    tdbcSalaryLevelID.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC21"
                    tdbcSalaryLevelID2.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID2.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC22"
                    tdbcSalaryLevelID2.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID2.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC23"
                    tdbcSalaryLevelID2.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID2.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC24"
                    tdbcSalaryLevelID2.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID2.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                Case "OLSC25"
                    tdbcSalaryLevelID2.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                    tdbcNextSalaryLevelID2.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
            End Select
        Next
    End Sub

    Private Sub LoadtdbcSalaryLevelID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sID As String, ByVal sIsUseOfficial As String)
        LoadCaptiontdbcSalaryLevelID(tdbc, sIsUseOfficial)
        LoadDataSource(tdbc, ReturnTableFilter(dtSalary, "OfficialTitleID =" & SQLString(sID)), gbUnicode)
        tdbc.HeadingStyle.Font = FontUnicode(gbUnicode)
        tdbcSalaryLevelID_NumberFormat()
    End Sub

    Private Sub LoadCaptiontdbcSalaryLevelID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sIsUseOfficial As String)
        If sIsUseOfficial = "0" Or sIsUseOfficial = "1" Then
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC10"
                        tdbc.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC11"
                        tdbc.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC12"
                        tdbc.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC13"
                        tdbc.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC14"
                        tdbc.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC15"
                        tdbc.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(gbUnicode)
                End Select
            Next
        Else
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC20"
                        tdbc.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC21"
                        tdbc.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC22"
                        tdbc.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC23"
                        tdbc.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC24"
                        tdbc.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(gbUnicode)
                    Case "OLSC25"
                        tdbc.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbc.Splits(0).DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(gbUnicode)
                End Select
            Next
        End If
        tdbc.HeadingStyle.Font = FontUnicode(gbUnicode)
    End Sub

    Dim BA(3) As Boolean
    Dim CE(19) As Boolean

    Private Function TableD13T9000() As DataTable
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short, Disabled, Type, Decimals From D13T9000  WITH (NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        dtSALBA = ReturnTableFilter(dt, " Type = 'SALBA'")
        dtSALCE = ReturnTableFilter(dt, " Type = 'SALCE'")
        dtOLSC = ReturnTableFilter(dt, " Type = 'OLSC'")

        For i As Integer = 0 To dtSALBA.Rows.Count - 1
            BA(i) = Not CBool(dtSALBA.Rows(i).Item("Disabled"))
            tdbgH1.Columns(COLH1_BaseSalary01 + i).NumberFormat = InsertFormat(dtSALBA.Rows(i).Item("Decimals").ToString)
            tdbgH1.Splits(1).DisplayColumns(COLH1_BaseSalary01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next i

        'Update 03/02/2012: Cập nhật 10 HSL
        For i As Integer = 0 To 19 'dtSALCE.Rows.Count - 1
            CE(i) = Not CBool(dtSALCE.Rows(i).Item("Disabled"))
            tdbgH1.Columns(COLH1_SalCoefficient01 + i).NumberFormat = InsertFormat(dtSALCE.Rows(i).Item("Decimals").ToString)
            tdbgH1.Splits(1).DisplayColumns(COLH1_SalCoefficient01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next i

        For i As Integer = 0 To dtSALBA.Rows.Count - 1
            tdbgH2.Columns(COLH2_BaseSalary01 + i).NumberFormat = InsertFormat(dtSALBA.Rows(i).Item("Decimals").ToString)
            tdbgH2.Splits(1).DisplayColumns(COLH2_BaseSalary01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next i

        For i As Integer = 0 To 19 'dtSALCE.Rows.Count - 1
            tdbgH2.Columns(COLH2_SalCoefficient01 + i).NumberFormat = InsertFormat(dtSALCE.Rows(i).Item("Decimals").ToString)
            tdbgH2.Splits(1).DisplayColumns(COLH2_SalCoefficient01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next i


        With OT
            .OfficialTitleID = Not CBool(dtOLSC.Rows(0).Item("Disabled"))
            .SalaryLevelID = Not CBool(dtOLSC.Rows(1).Item("Disabled"))
            .SaCoefficient = Not CBool(dtOLSC.Rows(2).Item("Disabled"))
            .SaCoefficient12 = Not CBool(dtOLSC.Rows(3).Item("Disabled"))
            .SaCoefficient13 = Not CBool(dtOLSC.Rows(4).Item("Disabled"))
            .SaCoefficient14 = Not CBool(dtOLSC.Rows(5).Item("Disabled"))
            .SaCoefficient15 = Not CBool(dtOLSC.Rows(6).Item("Disabled"))

            .OfficialTitleID2 = Not CBool(dtOLSC.Rows(7).Item("Disabled"))
            .SalaryLevelID2 = Not CBool(dtOLSC.Rows(8).Item("Disabled"))
            .SaCoefficient2 = Not CBool(dtOLSC.Rows(9).Item("Disabled"))
            .SaCoefficient22 = Not CBool(dtOLSC.Rows(10).Item("Disabled"))
            .SaCoefficient23 = Not CBool(dtOLSC.Rows(11).Item("Disabled"))
            .SaCoefficient24 = Not CBool(dtOLSC.Rows(12).Item("Disabled"))
            .SaCoefficient25 = Not CBool(dtOLSC.Rows(13).Item("Disabled"))
        End With

        GetCaptionSalBase(tdbgH1, SPLIT1, COLH1_BaseSalary01)
        GetCaptionSalBase(tdbgH2, SPLIT1, COLH2_BaseSalary01)

        GetCaptionSalCoeff(tdbgH1, SPLIT1, COLH1_SalCoefficient01)
        GetCaptionSalCoeff(tdbgH2, SPLIT1, COLH2_SalCoefficient01)

        LoadCaption_7ColOfficalTitle_Grid(tdbgH1, SPLIT1, dtOLSC, gbUnicode)
        LoadCaption_7ColOfficalTitle_Grid(tdbgH2, SPLIT1, dtOLSC, gbUnicode)
        Return dt
    End Function

    Private Sub LoadEdit()
        LoadMaster()
        LoadCaptiontdbcSalaryLevelID(tdbcSalaryLevelID, "1")
        tdbcSalaryLevelID.HeadingStyle.Font = FontUnicode(gbUnicode)

        LoadCaptiontdbcSalaryLevelID(tdbcSalaryLevelID2, "2")
        tdbcSalaryLevelID2.HeadingStyle.Font = FontUnicode(gbUnicode)

        LoadCaptiontdbcSalaryLevelID(tdbcNextSalaryLevelID, "1")
        tdbcNextSalaryLevelID.HeadingStyle.Font = FontUnicode(gbUnicode)

        LoadCaptiontdbcSalaryLevelID(tdbcNextSalaryLevelID2, "2")
        tdbcNextSalaryLevelID2.HeadingStyle.Font = FontUnicode(gbUnicode)
    End Sub

    Private Sub LoadTdbgH1()
        Dim sSQL As String = ""
        'sSQL &= "Select * From D13T2100 WHERE EmployeeID = " & SQLString(_employeeID)
        sSQL &= "SELECT	EmployeeID, TransID, FromMonthYear, ToMonthYear, MonthTotal," & vbCrLf
        sSQL &= "OldDivision" & UnicodeJoin(gbUnicode) & " As OldDivision, " & vbCrLf
        sSQL &= "OldDutyName" & UnicodeJoin(gbUnicode) & " As OldDutyName , " & vbCrLf
        sSQL &= "Note" & UnicodeJoin(gbUnicode) & " As Note, BaseSalary01, BaseSalary02," & vbCrLf
        sSQL &= "BaseSalary03, BaseSalary04, SalCoefficient01, SalCoefficient02, SalCoefficient03," & vbCrLf
        sSQL &= "SalCoefficient04, SalCoefficient05, SalCoefficient06, SalCoefficient07, " & vbCrLf
        sSQL &= "SalCoefficient08, SalCoefficient09, SalCoefficient10, " & vbCrLf
        sSQL &= "SalCoefficient11, SalCoefficient12, SalCoefficient13, SalCoefficient14, " & vbCrLf
        sSQL &= "SalCoefficient15, SalCoefficient16, SalCoefficient17, SalCoefficient18, " & vbCrLf
        sSQL &= "SalCoefficient19, SalCoefficient20, " & vbCrLf
        sSQL &= "OfficalTitleID," & vbCrLf
        sSQL &= "SalaryLevelID, SaCoefficient, SaCoefficient12, SaCoefficient13, SaCoefficient14," & vbCrLf
        sSQL &= "SaCoefficient15, OfficalTitleID2, SalaryLevelID2, SaCoefficient2, SaCoefficient22," & vbCrLf
        sSQL &= "SaCoefficient23, SaCoefficient24, SaCoefficient25" & vbCrLf
        sSQL &= "FROM D13T2100  WITH (NOLOCK) WHERE EmployeeID = " & SQLString(_employeeID)
        LoadDataSource(tdbgH1, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbgH2()
        LoadDataSource(tdbgH2, SQLStoreD13P0103, gbUnicode)
    End Sub

    Private Sub LoadTDBGBankID()
        Dim sSQL As String = ""
        sSQL &= "SELECT	T1.BankID, T1.BankAccountNo" & UnicodeJoin(gbUnicode) & " AS BankAccountNo, "
        sSQL &= "T1.AccountHolderName" & UnicodeJoin(gbUnicode) & " AS AccountHolderName, "
        sSQL &= "T1.ExchangeDep" & UnicodeJoin(gbUnicode) & " AS ExchangeDep, "
        sSQL &= "CONVERT(BIT, T1.IsDefault) as IsDefault,"
        sSQL &= "T2.BranchName" & UnicodeJoin(gbUnicode) & " AS BranchName,"
        sSQL &= "T2.ObjectName" & UnicodeJoin(gbUnicode) & " AS BankName" & vbCrLf
        sSQL &= "FROM	D13T0202 T1  WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN	OBJECT T2  WITH (NOLOCK) " & vbCrLf
        sSQL &= "ON		T1.BankID = T2.ObjectID AND ObjectTypeID = 'NH'" & vbCrLf
        sSQL &= "WHERE	T1.EmployeeID = " & SQLString(_employeeID)
        dtGridBankID = ReturnDataTable(sSQL)
        LoadDataSource(tdbgBankID, dtGridBankID, gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0103
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 03/11/2009 11:37:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0103() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0103 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'PeriodFrom, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'PeriodTo, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA  'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA  'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        'sSQL &= SQLString(XXXXX) & COMMA 'FormID, varchar[20], NOT NULL
        'sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
        Return sSQL
    End Function


    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD13P0103
    ''# Created User: Đỗ Minh Dũng
    ''# Created Date: 14/10/2009 11:02:45
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD13P0103() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D13P0103 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
    '    sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
    '    sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
    '    sSQL &= SQLNumber(0) & COMMA 'MonthYearFrom, int, NOT NULL
    '    sSQL &= SQLNumber(0) 'MonthYearTo, int, NOT NULL
    '    Return sSQL
    'End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1131
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 18/05/2012 10:47:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1131() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1131 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function


    Private Sub LoadMaster()
        Dim sSQL As String = ""
        'UPdate 18/05/2012: Incident 48360 thay thế câu SQL bằng Store
        sSQL = SQLStoreD13P1131()

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            ' update 22/6/2013 id 56311 
            LoadTDBOfficialTitle(dt.Rows(i).Item("DutyID").ToString)

            'Thông tin chung trên form
            txtDepartmentID.Text = dt.Rows(i).Item("DepartmentID").ToString
            txtDepartmentName.Text = dt.Rows(i).Item("DepartmentName").ToString
            txtTeamID.Text = dt.Rows(i).Item("TeamID").ToString
            txtTeamName.Text = dt.Rows(i).Item("TeamName").ToString
            txtEmployeeID.Text = dt.Rows(i).Item("EmployeeID").ToString
            txtEmployeeName.Text = dt.Rows(i).Item("EmployeeName").ToString
            txtEmpGroupID.Text = dt.Rows(i).Item("EmpGroupID").ToString
            txtEmpGroupName.Text = dt.Rows(i).Item("EmpGroupName").ToString

            'Tab Thông tin chính
            If _FormState = EnumFormState.FormAdd And _taxObjectID <> "" Then ' 25/4/2014 id 64610, 6461, 64612 - Khi xem, sửa bên D09 thì truyền trắng
                tdbcTaxObjectID.SelectedValue = _taxObjectID
            Else
                tdbcTaxObjectID.SelectedValue = dt.Rows(i).Item("TaxObjectID").ToString
            End If

            tdbcSalEmpGroupID.SelectedValue = dt.Rows(i).Item("SalEmpGroupID").ToString
            ' 8/5/2014 id 63987 - Bo group thông tin khác
            '            txtTaxCode.Text = dt.Rows(i).Item("TaxCode").ToString
            '            chkIsTransferEmail.Checked = CBool(dt.Rows(i).Item("IsTransferEmail"))
            'chkSpecialProcess.Checked = CBool(dt.Rows(i).Item("IsSpecialProcessing"))
            tdbcSalaryObjectID.SelectedValue = dt.Rows(i).Item("SalaryObjectID")

            'Ngạch bậc lương
            tdbcOfficialTitleID.Text = dt.Rows(i).Item("OfficalTitleID").ToString
            tdbcSalaryLevelID.Text = dt.Rows(i).Item("SalaryLevelID").ToString
            If Not IsDBNull(dt.Rows(i).Item("SaCoefficient")) Then
                txtSalaryCoefficient.Text = dt.Rows(i).Item("SaCoefficient").ToString
            Else
                txtSalaryCoefficient.Text = "0"
            End If

            tdbcOfficialTitleID2.Text = dt.Rows(i).Item("OfficalTitleID2").ToString
            tdbcSalaryLevelID2.Text = dt.Rows(i).Item("SalaryLevelID2").ToString
            If Not IsDBNull(dt.Rows(i).Item("SaCoefficient2")) Then
                txtSalaryCoefficient2.Text = dt.Rows(i).Item("SaCoefficient2").ToString
            Else
                txtSalaryCoefficient2.Text = "0"
            End If

            tdbcNextOfficialTitleID.Text = dt.Rows(i).Item("NextOfficalTitleID").ToString
            tdbcNextSalaryLevelID.Text = dt.Rows(i).Item("NextSalaryLevelID").ToString
            If Not IsDBNull(dt.Rows(i).Item("NextSalaryCoefficient")) Then
                txtNextSalaryCoefficient.Text = dt.Rows(i).Item("NextSalaryCoefficient").ToString
            Else
                txtNextSalaryCoefficient.Text = "0"
            End If

            tdbcNextOfficialTitleID2.Text = dt.Rows(i).Item("NextOfficalTitleID2").ToString
            tdbcNextSalaryLevelID2.Text = dt.Rows(i).Item("NextSalaryLevelID2").ToString

            If Not IsDBNull(dt.Rows(i).Item("NextSalaryCoefficient2")) Then
                txtNextSalaryCoefficient2.Text = dt.Rows(i).Item("NextSalaryCoefficient2").ToString
            Else
                txtNextSalaryCoefficient2.Text = "0"
            End If
            c1dateOffSa1DateEnd.Value = dt.Rows(i).Item("OffSa1DateEnd")
            c1dateOffSa1NextDate.Value = dt.Rows(i).Item("OffSa1NextDate")
            c1dateOffSa1DateEnd2.Value = dt.Rows(i).Item("OffSa2DateEnd")
            c1dateOffSa1NextDate2.Value = dt.Rows(i).Item("OffSa2NextDate")
            'Lương cơ bản
            If Not IsDBNull(dt.Rows(i).Item("BaseSalary01")) Then
                txtBaseSalary01.Text = dt.Rows(i).Item("BaseSalary01").ToString
            Else
                txtBaseSalary01.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("BaseSalary02")) Then
                txtBaseSalary02.Text = dt.Rows(i).Item("BaseSalary02").ToString
            Else
                txtBaseSalary02.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("BaseSalary03")) Then
                txtBaseSalary03.Text = dt.Rows(i).Item("BaseSalary03").ToString
            Else
                txtBaseSalary03.Text = dt.Rows(i).Item("BaseSalary03").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("BaseSalary04")) Then
                txtBaseSalary04.Text = dt.Rows(i).Item("BaseSalary04").ToString
            Else
                txtBaseSalary04.Text = "0"
            End If

            c1dateBaseSalary01DateEnd.Value = dt.Rows(i).Item("BaseSalary01DateEnd")
            c1dateBaseSalary02DateEnd.Value = dt.Rows(i).Item("BaseSalary02DateEnd")
            c1dateBaseSalary03DateEnd.Value = dt.Rows(i).Item("BaseSalary03DateEnd")
            c1dateBaseSalary04DateEnd.Value = dt.Rows(i).Item("BaseSalary04DateEnd")

            c1dateBaseSalary01NextDate.Value = dt.Rows(i).Item("BaseSalary01NextDate")
            c1dateBaseSalary02NextDate.Value = dt.Rows(i).Item("BaseSalary02NextDate")
            c1dateBaseSalary03NextDate.Value = dt.Rows(i).Item("BaseSalary03NextDate")
            c1dateBaseSalary04NextDate.Value = dt.Rows(i).Item("BaseSalary04NextDate")

            tdbcBaseCurrencyID01.SelectedValue = dt.Rows(i).Item("BaseCurrencyID01")
            tdbcBaseCurrencyID02.SelectedValue = dt.Rows(i).Item("BaseCurrencyID02")
            tdbcBaseCurrencyID03.SelectedValue = dt.Rows(i).Item("BaseCurrencyID03")
            tdbcBaseCurrencyID04.SelectedValue = dt.Rows(i).Item("BaseCurrencyID04")

            cneNumMonthBase01.Value = dt.Rows(i).Item("NumMonthBase01")
            cneNumMonthBase02.Value = dt.Rows(i).Item("NumMonthBase02")
            cneNumMonthBase03.Value = dt.Rows(i).Item("NumMonthBase03")
            cneNumMonthBase04.Value = dt.Rows(i).Item("NumMonthBase04")

            If Not IsDBNull(dt.Rows(i).Item("NextBaseSalary01")) Then
                txtNextBaseSalary01.Text = dt.Rows(i).Item("NextBaseSalary01").ToString
            Else
                txtNextBaseSalary01.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextBaseSalary02")) Then
                txtNextBaseSalary02.Text = dt.Rows(i).Item("NextBaseSalary02").ToString
            Else
                txtNextBaseSalary02.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextBaseSalary03")) Then
                txtNextBaseSalary03.Text = dt.Rows(i).Item("NextBaseSalary03").ToString
            Else
                txtNextBaseSalary03.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextBaseSalary04")) Then
                txtNextBaseSalary04.Text = dt.Rows(i).Item("NextBaseSalary04").ToString
            Else
                txtNextBaseSalary04.Text = "0"
            End If

            'Tab Hệ số lương
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient01")) Then
                txtSalCoefficient01.Text = dt.Rows(i).Item("SalCoefficient01").ToString
            Else
                txtSalCoefficient01.Text = "0" 'dt.Rows(i).Item("SalCoefficient01").ToString
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient02")) Then
                txtSalCoefficient02.Text = dt.Rows(i).Item("SalCoefficient02").ToString
            Else
                txtSalCoefficient02.Text = "0"
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient03")) Then
                txtSalCoefficient03.Text = dt.Rows(i).Item("SalCoefficient03").ToString
            Else
                txtSalCoefficient03.Text = "0"
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient04")) Then
                txtSalCoefficient04.Text = dt.Rows(i).Item("SalCoefficient04").ToString
            Else
                txtSalCoefficient04.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient05")) Then
                txtSalCoefficient05.Text = dt.Rows(i).Item("SalCoefficient05").ToString
            Else
                txtSalCoefficient05.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient06")) Then
                txtSalCoefficient06.Text = dt.Rows(i).Item("SalCoefficient06").ToString
            Else
                txtSalCoefficient06.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient07")) Then
                txtSalCoefficient07.Text = dt.Rows(i).Item("SalCoefficient07").ToString
            Else
                txtSalCoefficient07.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient08")) Then
                txtSalCoefficient08.Text = dt.Rows(i).Item("SalCoefficient08").ToString
            Else
                txtSalCoefficient08.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient09")) Then
                txtSalCoefficient09.Text = dt.Rows(i).Item("SalCoefficient09").ToString
            Else
                txtSalCoefficient09.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient10")) Then
                txtSalCoefficient10.Text = dt.Rows(i).Item("SalCoefficient10").ToString
            Else
                txtSalCoefficient10.Text = "0"
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient11")) Then
                txtSalCoefficient11.Text = dt.Rows(i).Item("SalCoefficient11").ToString
            Else
                txtSalCoefficient11.Text = "0" 'dt.Rows(i).Item("SalCoefficient01").ToString
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient12")) Then
                txtSalCoefficient12.Text = dt.Rows(i).Item("SalCoefficient12").ToString
            Else
                txtSalCoefficient12.Text = "0"
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient13")) Then
                txtSalCoefficient13.Text = dt.Rows(i).Item("SalCoefficient13").ToString
            Else
                txtSalCoefficient13.Text = "0"
            End If

            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient14")) Then
                txtSalCoefficient14.Text = dt.Rows(i).Item("SalCoefficient14").ToString
            Else
                txtSalCoefficient14.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient15")) Then
                txtSalCoefficient15.Text = dt.Rows(i).Item("SalCoefficient15").ToString
            Else
                txtSalCoefficient15.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient16")) Then
                txtSalCoefficient16.Text = dt.Rows(i).Item("SalCoefficient16").ToString
            Else
                txtSalCoefficient16.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient17")) Then
                txtSalCoefficient17.Text = dt.Rows(i).Item("SalCoefficient17").ToString
            Else
                txtSalCoefficient17.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient18")) Then
                txtSalCoefficient18.Text = dt.Rows(i).Item("SalCoefficient18").ToString
            Else
                txtSalCoefficient18.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient19")) Then
                txtSalCoefficient19.Text = dt.Rows(i).Item("SalCoefficient19").ToString
            Else
                txtSalCoefficient19.Text = "0"
            End If
            If Not IsDBNull(dt.Rows(i).Item("SalCoefficient20")) Then
                txtSalCoefficient20.Text = dt.Rows(i).Item("SalCoefficient20").ToString
            Else
                txtSalCoefficient20.Text = "0"
            End If


            c1dateSal01DateEnd.Value = dt.Rows(i).Item("Sal01DateEnd")
            c1dateSal02DateEnd.Value = dt.Rows(i).Item("Sal02DateEnd")
            c1dateSal03DateEnd.Value = dt.Rows(i).Item("Sal03DateEnd")
            c1dateSal04DateEnd.Value = dt.Rows(i).Item("Sal04DateEnd")
            c1dateSal05DateEnd.Value = dt.Rows(i).Item("Sal05DateEnd")
            c1dateSal06DateEnd.Value = dt.Rows(i).Item("Sal06DateEnd")
            c1dateSal07DateEnd.Value = dt.Rows(i).Item("Sal07DateEnd")
            c1dateSal08DateEnd.Value = dt.Rows(i).Item("Sal08DateEnd")
            c1dateSal09DateEnd.Value = dt.Rows(i).Item("Sal09DateEnd")
            c1dateSal10DateEnd.Value = dt.Rows(i).Item("Sal10DateEnd")

            c1dateSal11DateEnd.Value = dt.Rows(i).Item("Sal11DateEnd")
            c1dateSal12DateEnd.Value = dt.Rows(i).Item("Sal12DateEnd")
            c1dateSal13DateEnd.Value = dt.Rows(i).Item("Sal13DateEnd")
            c1dateSal14DateEnd.Value = dt.Rows(i).Item("Sal14DateEnd")
            c1dateSal15DateEnd.Value = dt.Rows(i).Item("Sal15DateEnd")
            c1dateSal16DateEnd.Value = dt.Rows(i).Item("Sal16DateEnd")
            c1dateSal17DateEnd.Value = dt.Rows(i).Item("Sal17DateEnd")
            c1dateSal18DateEnd.Value = dt.Rows(i).Item("Sal18DateEnd")
            c1dateSal19DateEnd.Value = dt.Rows(i).Item("Sal19DateEnd")
            c1dateSal20DateEnd.Value = dt.Rows(i).Item("Sal20DateEnd")


            c1dateSal01NextDate.Value = dt.Rows(i).Item("Sal01NextDate")
            c1dateSal02NextDate.Value = dt.Rows(i).Item("Sal02NextDate")
            c1dateSal03NextDate.Value = dt.Rows(i).Item("Sal03NextDate")
            c1dateSal04NextDate.Value = dt.Rows(i).Item("Sal04NextDate")
            c1dateSal05NextDate.Value = dt.Rows(i).Item("Sal05NextDate")
            c1dateSal06NextDate.Value = dt.Rows(i).Item("Sal06NextDate")
            c1dateSal07NextDate.Value = dt.Rows(i).Item("Sal07NextDate")
            c1dateSal08NextDate.Value = dt.Rows(i).Item("Sal08NextDate")
            c1dateSal09NextDate.Value = dt.Rows(i).Item("Sal09NextDate")
            c1dateSal10NextDate.Value = dt.Rows(i).Item("Sal10NextDate")

            c1dateSal11NextDate.Value = dt.Rows(i).Item("Sal11NextDate")
            c1dateSal12NextDate.Value = dt.Rows(i).Item("Sal12NextDate")
            c1dateSal13NextDate.Value = dt.Rows(i).Item("Sal13NextDate")
            c1dateSal14NextDate.Value = dt.Rows(i).Item("Sal14NextDate")
            c1dateSal15NextDate.Value = dt.Rows(i).Item("Sal15NextDate")
            c1dateSal16NextDate.Value = dt.Rows(i).Item("Sal16NextDate")
            c1dateSal17NextDate.Value = dt.Rows(i).Item("Sal17NextDate")
            c1dateSal18NextDate.Value = dt.Rows(i).Item("Sal18NextDate")
            c1dateSal19NextDate.Value = dt.Rows(i).Item("Sal19NextDate")
            c1dateSal20NextDate.Value = dt.Rows(i).Item("Sal20NextDate")

            tdbcSalCoeCurrencyID01.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID01")
            tdbcSalCoeCurrencyID02.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID02")
            tdbcSalCoeCurrencyID03.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID03")
            tdbcSalCoeCurrencyID04.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID04")
            tdbcSalCoeCurrencyID05.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID05")
            tdbcSalCoeCurrencyID06.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID06")
            tdbcSalCoeCurrencyID07.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID07")
            tdbcSalCoeCurrencyID08.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID08")
            tdbcSalCoeCurrencyID09.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID09")
            tdbcSalCoeCurrencyID10.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID10")

            tdbcSalCoeCurrencyID11.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID11")
            tdbcSalCoeCurrencyID12.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID12")
            tdbcSalCoeCurrencyID13.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID13")
            tdbcSalCoeCurrencyID14.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID14")
            tdbcSalCoeCurrencyID15.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID15")
            tdbcSalCoeCurrencyID16.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID16")
            tdbcSalCoeCurrencyID17.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID17")
            tdbcSalCoeCurrencyID18.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID18")
            tdbcSalCoeCurrencyID19.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID19")
            tdbcSalCoeCurrencyID20.SelectedValue = dt.Rows(i).Item("SalCoeCurrencyID20")

            cneNumMonthSalCoe01.Value = dt.Rows(i).Item("NumMonthSalCoe01")
            cneNumMonthSalCoe02.Value = dt.Rows(i).Item("NumMonthSalCoe02")
            cneNumMonthSalCoe03.Value = dt.Rows(i).Item("NumMonthSalCoe03")
            cneNumMonthSalCoe04.Value = dt.Rows(i).Item("NumMonthSalCoe04")
            cneNumMonthSalCoe05.Value = dt.Rows(i).Item("NumMonthSalCoe05")
            cneNumMonthSalCoe06.Value = dt.Rows(i).Item("NumMonthSalCoe06")
            cneNumMonthSalCoe07.Value = dt.Rows(i).Item("NumMonthSalCoe07")
            cneNumMonthSalCoe08.Value = dt.Rows(i).Item("NumMonthSalCoe08")
            cneNumMonthSalCoe09.Value = dt.Rows(i).Item("NumMonthSalCoe09")
            cneNumMonthSalCoe10.Value = dt.Rows(i).Item("NumMonthSalCoe10")

            cneNumMonthSalCoe11.Value = dt.Rows(i).Item("NumMonthSalCoe11")
            cneNumMonthSalCoe12.Value = dt.Rows(i).Item("NumMonthSalCoe12")
            cneNumMonthSalCoe13.Value = dt.Rows(i).Item("NumMonthSalCoe13")
            cneNumMonthSalCoe14.Value = dt.Rows(i).Item("NumMonthSalCoe14")
            cneNumMonthSalCoe15.Value = dt.Rows(i).Item("NumMonthSalCoe15")
            cneNumMonthSalCoe16.Value = dt.Rows(i).Item("NumMonthSalCoe16")
            cneNumMonthSalCoe17.Value = dt.Rows(i).Item("NumMonthSalCoe17")
            cneNumMonthSalCoe18.Value = dt.Rows(i).Item("NumMonthSalCoe18")
            cneNumMonthSalCoe19.Value = dt.Rows(i).Item("NumMonthSalCoe19")
            cneNumMonthSalCoe20.Value = dt.Rows(i).Item("NumMonthSalCoe20")

            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient01")) Then
                txtNextSalCoefficient01.Text = dt.Rows(i).Item("NextSalCoefficient01").ToString
            Else
                txtNextSalCoefficient01.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient01").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient02")) Then
                txtNextSalCoefficient02.Text = dt.Rows(i).Item("NextSalCoefficient02").ToString
            Else
                txtNextSalCoefficient02.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient02").ToString
            End If

            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient03")) Then
                txtNextSalCoefficient03.Text = dt.Rows(i).Item("NextSalCoefficient03").ToString
            Else
                txtNextSalCoefficient03.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient03").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient04")) Then
                txtNextSalCoefficient04.Text = dt.Rows(i).Item("NextSalCoefficient04").ToString
            Else
                txtNextSalCoefficient04.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient04").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient05")) Then
                txtNextSalCoefficient05.Text = dt.Rows(i).Item("NextSalCoefficient05").ToString
            Else
                txtNextSalCoefficient05.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient05").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient06")) Then
                txtNextSalCoefficient06.Text = dt.Rows(i).Item("NextSalCoefficient06").ToString
            Else
                txtNextSalCoefficient06.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient06").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient07")) Then
                txtNextSalCoefficient07.Text = dt.Rows(i).Item("NextSalCoefficient07").ToString
            Else
                txtNextSalCoefficient07.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient07").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient08")) Then
                txtNextSalCoefficient08.Text = dt.Rows(i).Item("NextSalCoefficient08").ToString
            Else
                txtNextSalCoefficient08.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient08").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient09")) Then
                txtNextSalCoefficient09.Text = dt.Rows(i).Item("NextSalCoefficient09").ToString
            Else
                txtNextSalCoefficient09.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient09").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient10")) Then
                txtNextSalCoefficient10.Text = dt.Rows(i).Item("NextSalCoefficient10").ToString
            Else
                txtNextSalCoefficient10.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient10").ToString
            End If

            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient11")) Then
                txtNextSalCoefficient11.Text = dt.Rows(i).Item("NextSalCoefficient11").ToString
            Else
                txtNextSalCoefficient11.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient10").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient12")) Then
                txtNextSalCoefficient12.Text = dt.Rows(i).Item("NextSalCoefficient12").ToString
            Else
                txtNextSalCoefficient12.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient12").ToString
            End If

            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient13")) Then
                txtNextSalCoefficient13.Text = dt.Rows(i).Item("NextSalCoefficient13").ToString
            Else
                txtNextSalCoefficient13.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient13").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient14")) Then
                txtNextSalCoefficient14.Text = dt.Rows(i).Item("NextSalCoefficient14").ToString
            Else
                txtNextSalCoefficient14.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient14").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient15")) Then
                txtNextSalCoefficient15.Text = dt.Rows(i).Item("NextSalCoefficient15").ToString
            Else
                txtNextSalCoefficient15.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient15").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient16")) Then
                txtNextSalCoefficient16.Text = dt.Rows(i).Item("NextSalCoefficient16").ToString
            Else
                txtNextSalCoefficient16.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient16").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient17")) Then
                txtNextSalCoefficient17.Text = dt.Rows(i).Item("NextSalCoefficient17").ToString
            Else
                txtNextSalCoefficient17.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient17").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient18")) Then
                txtNextSalCoefficient18.Text = dt.Rows(i).Item("NextSalCoefficient18").ToString
            Else
                txtNextSalCoefficient18.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient18").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient19")) Then
                txtNextSalCoefficient19.Text = dt.Rows(i).Item("NextSalCoefficient19").ToString
            Else
                txtNextSalCoefficient19.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient19").ToString
            End If
            If Not IsDBNull(dt.Rows(i).Item("NextSalCoefficient20")) Then
                txtNextSalCoefficient20.Text = dt.Rows(i).Item("NextSalCoefficient20").ToString
            Else
                txtNextSalCoefficient20.Text = "0" 'dt.Rows(i).Item("NextSalCoefficient20").ToString
            End If

            Dim sPaymentMethod As String = ""
            If _FormState = EnumFormState.FormAdd And _paymentMethod <> "" Then ' 25/4/2014 id 64610, 6461, 64612 - Khi xem, sửa bên D09 thì truyền trắng
                sPaymentMethod = _paymentMethod
            Else
                sPaymentMethod = dt.Rows(i).Item("PaymentMethod").ToString
            End If
            If sPaymentMethod = "C" Then
                optPaymentMethodC.Checked = True
                LockControlBank(False)
            ElseIf sPaymentMethod = "B" Then
                optPaymentMethodB.Checked = True
                LockControlBank(True)
            Else
                optPaymentMethodO.Checked = True
                LockControlBank(False)
            End If
            ' update 14/8/2013 id 57455 - Bổ sung lưới ngân hàng 
            '            'Tab Phương pháp trả lương
            '            txtExchangeDep.Text = dt.Rows(i).Item("ExchangeDep").ToString
            '            txtBankAccountNo.Text = dt.Rows(i).Item("BankAccountNo").ToString
            '            txtAccountHolderName.Text = dt.Rows(i).Item("AccountHolderName").ToString
            '            txtExchangeDep2.Text = dt.Rows(i).Item("ExchangeDep2").ToString
            '            txtBankAccountNo2.Text = dt.Rows(i).Item("BankAccountNo2").ToString
            '            txtAccountHolderName2.Text = dt.Rows(i).Item("AccountHolderName2").ToString
            '            If dt.Rows(i).Item("PaymentMethod").ToString = "C" Then
            '                optPaymentMethodC.Checked = True
            '                tdbcBankID.Text = dt.Rows(i).Item("BankID").ToString
            '                txtBankName.Text = dt.Rows(i).Item("BankName").ToString
            '                txtBranchName.Text = dt.Rows(i).Item("BranchName").ToString
            '                txtExchangeDep.Text = dt.Rows(i).Item("ExchangeDep").ToString
            '                txtBankAccountNo.Text = dt.Rows(i).Item("BankAccountNo").ToString
            '                txtAccountHolderName.Text = dt.Rows(i).Item("AccountHolderName").ToString
            '                tdbcBankID2.Text = dt.Rows(i).Item("BankID2").ToString
            '                tdbcBankID2.SelectedValue = tdbcBankID2.Text
            '
            '                txtBankName2.Text = dt.Rows(i).Item("BankName2").ToString
            '                txtBranchName2.Text = dt.Rows(i).Item("BranchName2").ToString
            '                txtExchangeDep2.Text = dt.Rows(i).Item("ExchangeDep2").ToString
            '                txtBankAccountNo2.Text = dt.Rows(i).Item("BankAccountNo2").ToString
            '                txtAccountHolderName2.Text = dt.Rows(i).Item("AccountHolderName2").ToString
            '                LockControlBank(False)
            '            ElseIf dt.Rows(i).Item("PaymentMethod").ToString = "B" Then
            '
            '                optPaymentMethodB.Checked = True
            '                tdbcBankID.Text = dt.Rows(i).Item("BankID").ToString
            '                txtBankName.Text = dt.Rows(i).Item("BankName").ToString
            '                txtBranchName.Text = dt.Rows(i).Item("BranchName").ToString
            '                txtExchangeDep.Text = dt.Rows(i).Item("ExchangeDep").ToString
            '                txtBankAccountNo.Text = dt.Rows(i).Item("BankAccountNo").ToString
            '                txtAccountHolderName.Text = dt.Rows(i).Item("AccountHolderName").ToString
            '
            '                tdbcBankID2.Text = dt.Rows(i).Item("BankID2").ToString
            '                txtBankName2.Text = dt.Rows(i).Item("BankName2").ToString
            '                txtBranchName2.Text = dt.Rows(i).Item("BranchName2").ToString
            '                txtExchangeDep2.Text = dt.Rows(i).Item("ExchangeDep2").ToString
            '                txtBankAccountNo2.Text = dt.Rows(i).Item("BankAccountNo2").ToString
            '                txtAccountHolderName2.Text = dt.Rows(i).Item("AccountHolderName2").ToString
            '                LockControlBank(True)
            '            Else
            '                optPaymentMethodO.Checked = True
            '                tdbcBankID.Text = dt.Rows(i).Item("BankID").ToString
            '                txtBankName.Text = dt.Rows(i).Item("BankName").ToString
            '                txtBranchName.Text = dt.Rows(i).Item("BranchName").ToString
            '                txtExchangeDep.Text = dt.Rows(i).Item("ExchangeDep").ToString
            '                txtBankAccountNo.Text = dt.Rows(i).Item("BankAccountNo").ToString
            '                txtAccountHolderName.Text = dt.Rows(i).Item("AccountHolderName").ToString
            '
            '                tdbcBankID2.Text = dt.Rows(i).Item("BankID2").ToString
            '                txtBankName2.Text = dt.Rows(i).Item("BankName2").ToString
            '                txtBranchName2.Text = dt.Rows(i).Item("BranchName2").ToString
            '                txtExchangeDep2.Text = dt.Rows(i).Item("ExchangeDep2").ToString
            '                txtBankAccountNo2.Text = dt.Rows(i).Item("BankAccountNo2").ToString
            '                txtAccountHolderName2.Text = dt.Rows(i).Item("AccountHolderName2").ToString
            '
            '                LockControlBank(False)
            '            End If

        Next

        'Tab mã phân tích
        sSQL = SQLStoreD13P1032()
        Dim dtPAna As New DataTable
        dtPAna = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtPAna, gbUnicode)

        If gsLanguage = "84" Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_PAnaCategoryName84).Visible = True
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_PAnaCategoryName01).Visible = False
        Else
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_PAnaCategoryName84).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_PAnaCategoryName01).Visible = True
        End If

        'Bổ sung kiểm tra địa chỉ eMail
        '        sSQL = "Select Email, EmployeeID From D09T0201 Where EmployeeID = " & SQLString(_employeeID)
        '        Dim dtEmail As New DataTable
        '        dtEmail = ReturnDataTable(sSQL)
        'Update 24/11/2011: Incident 43324
        ' 8/5/2014 id 63987 - Bo group thông tin khác
        'txtEmail.Text = dtD09T0201.Rows(0).Item("Email").ToString

        'Tab Thông tin chính
        '        sSQL = "SELECT D2.RelativeID, D2.RelationID, D2.RelationName" & UnicodeJoin(gbUnicode) & " as RelationName, D2.RelativeName" & UnicodeJoin(gbUnicode) & " as RelativeName, " & vbCrLf
        '        sSQL &= "convert(varchar(10),D2.BirthDate,103) as BirthDate, D2.BirthPlace" & UnicodeJoin(gbUnicode) & " as BirthPlace, " & vbCrLf
        '        sSQL &= "D2.Address" & UnicodeJoin(gbUnicode) & " as Address, D2.Occupation" & UnicodeJoin(gbUnicode) & " as Occupation, D2.InComeTaxCode, D2.IDCardNo, " & vbCrLf
        '        sSQL &= "D2.EducationLevelID, D4.EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName," & vbCrLf
        '        sSQL &= "D2.Sex, (Case when D2.Sex = '0' then 'Nam' else " & IIf(gbUnicode, "N'Nữ'", "'Nöõ'").ToString & " end) as SexName," & vbCrLf
        '        sSQL &= "D2.Salary," & vbCrLf
        '        sSQL &= "convert(varchar(10),D2.DeductibleDateBegin,103) as DeductibleDateBegin, " & vbCrLf
        '        sSQL &= "convert(varchar(10),D2.DeductibleDateEnd,103) as DeductibleDateEnd, D2.DeductibleAmount, " & vbCrLf
        '        sSQL &= "D2.Note" & UnicodeJoin(gbUnicode) & " AS Note, convert(varchar(10),D2.BirthCertificate,103) as BirthCertificate, " & vbCrLf
        '        sSQL &= "convert(varchar(10),D2.ResidentCertificate,103) as ResidentCertificate, convert(varchar(10),D2.MarriageCertificate,103) as MarriageCertificate, convert(varchar(10),D2.SchoolConfirmation,103) as SchoolConfirmation, " & vbCrLf
        '        sSQL &= "convert(varchar(10),D2.DisabilityConfirmation,103) as DisabilityConfirmation, convert(varchar(10),D2.BringUpConfirmation,103) as BringUpConfirmation, convert(varchar(10),D2.OtherConfirmations,103) as OtherConfirmations, " & vbCrLf
        '        sSQL &= "D2.NoteConfirmation" & UnicodeJoin(gbUnicode) & " AS NoteConfirmation" & vbCrLf
        '        sSQL &= "FROM D13T0216 D2 " & vbCrLf
        '        sSQL &= "LEFT JOIN D13T0201 D1 ON D1.EmployeeID = D2.EmployeeID " & vbCrLf
        '        sSQL &= "LEFT JOIN D09T0206 D4 ON D2.EducationLevelID = D4.EducationLevelID " & vbCrLf
        '        sSQL &= "WHERE D1.EmployeeID = " & SQLString(_employeeID) & vbCrLf
        '        sSQL &= "ORDER BY D2.RelativeID"
        ' update 9/9/2013 id 56751
        sSQL = SQLStoreD13P1502()
        LoadDataSource(tdbgRelative, sSQL, gbUnicode)

        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumns)
    End Sub

    Private Sub LockControlBank(ByVal bFlag As Boolean)
        tdbgBankID.Enabled = bFlag
        '        tdbcBankID.Enabled = bFlag
        '        txtExchangeDep.Enabled = bFlag
        '        txtBankAccountNo.Enabled = bFlag
        '        txtAccountHolderName.Enabled = bFlag
        '
        '        tdbcBankID2.Enabled = bFlag
        '        txtExchangeDep2.Enabled = bFlag
        '        txtBankAccountNo2.Enabled = bFlag
        '        txtAccountHolderName2.Enabled = bFlag
    End Sub

    'Tab luong co ban
    Private Sub GetBaseSalary()
        Dim dt As DataTable = ReturnTableFilter(dtCaption, " Type = 'SALBA'")
        If dt.Rows.Count = 0 Then Exit Sub
        lblBaseSalary01.Text = dt.Rows(0).Item(1).ToString
        lblBaseSalary01.Font = FontUnicode(gbUnicode)
        lblBaseSalary02.Text = dt.Rows(1).Item(1).ToString
        lblBaseSalary02.Font = FontUnicode(gbUnicode)
        lblBaseSalary03.Text = dt.Rows(2).Item(1).ToString
        lblBaseSalary03.Font = FontUnicode(gbUnicode)
        lblBaseSalary04.Text = dt.Rows(3).Item(1).ToString
        lblBaseSalary04.Font = FontUnicode(gbUnicode)
        For i As Integer = 0 To dt.Rows.Count - 1
            If Convert.ToInt32(dt.Rows(i).Item("Disabled").ToString) = 1 Then
                Dim sCode As String
                sCode = dt.Rows(i).Item(0).ToString
                Select Case sCode
                    Case "BASE01"
                        txtBaseSalary01.Enabled = False
                        c1dateBaseSalary01DateEnd.Enabled = False
                        c1dateBaseSalary01NextDate.Enabled = False
                        txtNextBaseSalary01.Enabled = False
                        tdbcBaseCurrencyID01.Enabled = False
                        cneNumMonthBase01.Enabled = False
                    Case "BASE02"
                        txtBaseSalary02.Enabled = False
                        c1dateBaseSalary02DateEnd.Enabled = False
                        c1dateBaseSalary02NextDate.Enabled = False
                        txtNextBaseSalary02.Enabled = False
                        tdbcBaseCurrencyID02.Enabled = False
                        cneNumMonthBase02.Enabled = False
                    Case "BASE03"
                        txtBaseSalary03.Enabled = False
                        c1dateBaseSalary03DateEnd.Enabled = False
                        c1dateBaseSalary03NextDate.Enabled = False
                        txtNextBaseSalary03.Enabled = False
                        tdbcBaseCurrencyID03.Enabled = False
                        cneNumMonthBase03.Enabled = False
                    Case "BASE04"
                        txtBaseSalary04.Enabled = False
                        c1dateBaseSalary04DateEnd.Enabled = False
                        c1dateBaseSalary04NextDate.Enabled = False
                        txtNextBaseSalary04.Enabled = False
                        tdbcBaseCurrencyID04.Enabled = False
                        cneNumMonthBase04.Enabled = False
                End Select
            End If
        Next
    End Sub

    'Tab Hệ số lương
    Public Sub GetSalCoefficient()
        Dim dt As DataTable = ReturnTableFilter(dtCaption, " Type = 'SALCE'")
        If dt.Rows.Count = 0 Then Exit Sub
        lblSalCoefficient01.Text = dt.Rows(0).Item(1).ToString
        lblSalCoefficient01.Font = FontUnicode(gbUnicode)

        lblSalCoefficient02.Text = dt.Rows(1).Item(1).ToString
        lblSalCoefficient02.Font = FontUnicode(gbUnicode)

        lblSalCoefficient03.Text = dt.Rows(2).Item(1).ToString
        lblSalCoefficient03.Font = FontUnicode(gbUnicode)

        lblSalCoefficient04.Text = dt.Rows(3).Item(1).ToString
        lblSalCoefficient04.Font = FontUnicode(gbUnicode)

        lblSalCoefficient05.Text = dt.Rows(4).Item(1).ToString
        lblSalCoefficient05.Font = FontUnicode(gbUnicode)

        lblSalCoefficient06.Text = dt.Rows(5).Item(1).ToString()
        lblSalCoefficient06.Font = FontUnicode(gbUnicode)

        lblSalCoefficient07.Text = dt.Rows(6).Item(1).ToString
        lblSalCoefficient07.Font = FontUnicode(gbUnicode)

        lblSalCoefficient08.Text = dt.Rows(7).Item(1).ToString
        lblSalCoefficient08.Font = FontUnicode(gbUnicode)

        lblSalCoefficient09.Text = dt.Rows(8).Item(1).ToString
        lblSalCoefficient09.Font = FontUnicode(gbUnicode)

        lblSalCoefficient10.Text = dt.Rows(9).Item(1).ToString
        lblSalCoefficient10.Font = FontUnicode(gbUnicode)

        lblSalCoefficient11.Text = dt.Rows(10).Item(1).ToString
        lblSalCoefficient11.Font = FontUnicode(gbUnicode)

        lblSalCoefficient12.Text = dt.Rows(11).Item(1).ToString
        lblSalCoefficient12.Font = FontUnicode(gbUnicode)

        lblSalCoefficient13.Text = dt.Rows(12).Item(1).ToString
        lblSalCoefficient13.Font = FontUnicode(gbUnicode)

        lblSalCoefficient14.Text = dt.Rows(13).Item(1).ToString
        lblSalCoefficient14.Font = FontUnicode(gbUnicode)

        lblSalCoefficient15.Text = dt.Rows(14).Item(1).ToString
        lblSalCoefficient15.Font = FontUnicode(gbUnicode)

        lblSalCoefficient16.Text = dt.Rows(15).Item(1).ToString()
        lblSalCoefficient16.Font = FontUnicode(gbUnicode)

        lblSalCoefficient17.Text = dt.Rows(16).Item(1).ToString
        lblSalCoefficient17.Font = FontUnicode(gbUnicode)

        lblSalCoefficient18.Text = dt.Rows(17).Item(1).ToString
        lblSalCoefficient18.Font = FontUnicode(gbUnicode)

        lblSalCoefficient19.Text = dt.Rows(18).Item(1).ToString
        lblSalCoefficient19.Font = FontUnicode(gbUnicode)

        lblSalCoefficient20.Text = dt.Rows(19).Item(1).ToString
        lblSalCoefficient20.Font = FontUnicode(gbUnicode)

        For i As Integer = 0 To 19 'dt.Rows.Count - 1
            If Convert.ToInt32(dt.Rows(i).Item(2).ToString) = 1 Then
                Dim sCode As String
                sCode = dt.Rows(i).Item(0).ToString
                Select Case sCode
                    Case "CE01"
                        txtSalCoefficient01.Enabled = False
                        c1dateSal01DateEnd.Enabled = False
                        c1dateSal01NextDate.Enabled = False
                        txtNextSalCoefficient01.Enabled = False
                        tdbcSalCoeCurrencyID01.Enabled = False
                        cneNumMonthSalCoe01.Enabled = False
                    Case "CE02"
                        txtSalCoefficient02.Enabled = False
                        c1dateSal02DateEnd.Enabled = False
                        c1dateSal02NextDate.Enabled = False
                        txtNextSalCoefficient02.Enabled = False
                        tdbcSalCoeCurrencyID02.Enabled = False
                        cneNumMonthSalCoe02.Enabled = False
                    Case "CE03"
                        txtSalCoefficient03.Enabled = False
                        c1dateSal03DateEnd.Enabled = False
                        c1dateSal03NextDate.Enabled = False
                        txtNextSalCoefficient03.Enabled = False
                        tdbcSalCoeCurrencyID03.Enabled = False
                        cneNumMonthSalCoe03.Enabled = False
                    Case "CE04"
                        txtSalCoefficient04.Enabled = False
                        c1dateSal04DateEnd.Enabled = False
                        c1dateSal04NextDate.Enabled = False
                        txtNextSalCoefficient04.Enabled = False
                        tdbcSalCoeCurrencyID04.Enabled = False
                        cneNumMonthSalCoe04.Enabled = False
                    Case "CE05"
                        txtSalCoefficient05.Enabled = False
                        c1dateSal05DateEnd.Enabled = False
                        c1dateSal05NextDate.Enabled = False
                        txtNextSalCoefficient05.Enabled = False
                        tdbcSalCoeCurrencyID05.Enabled = False
                        cneNumMonthSalCoe05.Enabled = False
                    Case "CE06"
                        txtSalCoefficient06.Enabled = False
                        c1dateSal06DateEnd.Enabled = False
                        c1dateSal06NextDate.Enabled = False
                        txtNextSalCoefficient06.Enabled = False
                        tdbcSalCoeCurrencyID06.Enabled = False
                        cneNumMonthSalCoe06.Enabled = False
                    Case "CE07"
                        txtSalCoefficient07.Enabled = False
                        c1dateSal07DateEnd.Enabled = False
                        c1dateSal07NextDate.Enabled = False
                        txtNextSalCoefficient07.Enabled = False
                        tdbcSalCoeCurrencyID07.Enabled = False
                        cneNumMonthSalCoe07.Enabled = False
                    Case "CE08"
                        txtSalCoefficient08.Enabled = False
                        c1dateSal08DateEnd.Enabled = False
                        c1dateSal08NextDate.Enabled = False
                        txtNextSalCoefficient08.Enabled = False
                        tdbcSalCoeCurrencyID08.Enabled = False
                        cneNumMonthSalCoe08.Enabled = False
                    Case "CE09"
                        txtSalCoefficient09.Enabled = False
                        c1dateSal09DateEnd.Enabled = False
                        c1dateSal09NextDate.Enabled = False
                        txtNextSalCoefficient09.Enabled = False
                        tdbcSalCoeCurrencyID09.Enabled = False
                        cneNumMonthSalCoe09.Enabled = False
                    Case "CE10"
                        txtSalCoefficient10.Enabled = False
                        c1dateSal10DateEnd.Enabled = False
                        c1dateSal10NextDate.Enabled = False
                        txtNextSalCoefficient10.Enabled = False
                        tdbcSalCoeCurrencyID10.Enabled = False
                        cneNumMonthSalCoe10.Enabled = False
                    Case "CE11"
                        txtSalCoefficient11.Enabled = False
                        c1dateSal11DateEnd.Enabled = False
                        c1dateSal11NextDate.Enabled = False
                        txtNextSalCoefficient11.Enabled = False
                        tdbcSalCoeCurrencyID11.Enabled = False
                        cneNumMonthSalCoe11.Enabled = False
                    Case "CE12"
                        txtSalCoefficient12.Enabled = False
                        c1dateSal12DateEnd.Enabled = False
                        c1dateSal12NextDate.Enabled = False
                        txtNextSalCoefficient12.Enabled = False
                        tdbcSalCoeCurrencyID12.Enabled = False
                        cneNumMonthSalCoe12.Enabled = False
                    Case "CE13"
                        txtSalCoefficient13.Enabled = False
                        c1dateSal13DateEnd.Enabled = False
                        c1dateSal13NextDate.Enabled = False
                        txtNextSalCoefficient13.Enabled = False
                        tdbcSalCoeCurrencyID13.Enabled = False
                        cneNumMonthSalCoe13.Enabled = False
                    Case "CE14"
                        txtSalCoefficient14.Enabled = False
                        c1dateSal14DateEnd.Enabled = False
                        c1dateSal14NextDate.Enabled = False
                        txtNextSalCoefficient14.Enabled = False
                        tdbcSalCoeCurrencyID14.Enabled = False
                        cneNumMonthSalCoe14.Enabled = False
                    Case "CE15"
                        txtSalCoefficient15.Enabled = False
                        c1dateSal15DateEnd.Enabled = False
                        c1dateSal15NextDate.Enabled = False
                        txtNextSalCoefficient15.Enabled = False
                        tdbcSalCoeCurrencyID15.Enabled = False
                        cneNumMonthSalCoe15.Enabled = False
                    Case "CE16"
                        txtSalCoefficient16.Enabled = False
                        c1dateSal16DateEnd.Enabled = False
                        c1dateSal16NextDate.Enabled = False
                        txtNextSalCoefficient16.Enabled = False
                        tdbcSalCoeCurrencyID16.Enabled = False
                        cneNumMonthSalCoe16.Enabled = False
                    Case "CE17"
                        txtSalCoefficient17.Enabled = False
                        c1dateSal17DateEnd.Enabled = False
                        c1dateSal17NextDate.Enabled = False
                        txtNextSalCoefficient17.Enabled = False
                        tdbcSalCoeCurrencyID17.Enabled = False
                        cneNumMonthSalCoe17.Enabled = False
                    Case "CE18"
                        txtSalCoefficient18.Enabled = False
                        c1dateSal18DateEnd.Enabled = False
                        c1dateSal18NextDate.Enabled = False
                        txtNextSalCoefficient18.Enabled = False
                        tdbcSalCoeCurrencyID18.Enabled = False
                        cneNumMonthSalCoe18.Enabled = False
                    Case "CE19"
                        txtSalCoefficient19.Enabled = False
                        c1dateSal19DateEnd.Enabled = False
                        c1dateSal19NextDate.Enabled = False
                        txtNextSalCoefficient19.Enabled = False
                        tdbcSalCoeCurrencyID19.Enabled = False
                        cneNumMonthSalCoe19.Enabled = False
                    Case "CE20"
                        txtSalCoefficient20.Enabled = False
                        c1dateSal20DateEnd.Enabled = False
                        c1dateSal20NextDate.Enabled = False
                        txtNextSalCoefficient20.Enabled = False
                        tdbcSalCoeCurrencyID20.Enabled = False
                        cneNumMonthSalCoe20.Enabled = False

                End Select
            End If
        Next
    End Sub

    Private Sub GetOLSC()
        If dtOLSC.Rows.Count > 0 Then
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                With dtOLSC.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC1" 'Ngạch lương 1
                            lblOfficialTitleID1.Text = .Item("Short").ToString
                            lblOfficialTitleID1.Font = FontUnicode(gbUnicode)
                        Case "OLSC10" 'Bậc lương 1
                            lblSalaryLevelID1.Text = .Item("Short").ToString
                            lblSalaryLevelID1.Font = FontUnicode(gbUnicode)
                        Case "OLSC11" 'Hệ số 1
                            lblSaCoefficient.Text = .Item("Short").ToString
                            lblSaCoefficient.Font = FontUnicode(gbUnicode)
                        Case "OLSC12" 'Hệ số 2
                            lblSaCoefficient02.Text = .Item("Short").ToString
                            lblSaCoefficient02.Font = FontUnicode(gbUnicode)
                        Case "OLSC13" 'Hệ số 3
                            lblSaCoefficient03.Text = .Item("Short").ToString
                            lblSaCoefficient03.Font = FontUnicode(gbUnicode)
                        Case "OLSC14" 'Hệ số 4
                            lblSaCoefficient04.Text = .Item("Short").ToString
                            lblSaCoefficient04.Font = FontUnicode(gbUnicode)
                        Case "OLSC15" 'Hệ số 5
                            lblSaCoefficient05.Text = .Item("Short").ToString
                            lblSaCoefficient05.Font = FontUnicode(gbUnicode)

                        Case "OLSC2" 'Ngạch lương 2
                            lblOfficialTitleID2.Text = .Item("Short").ToString
                            lblOfficialTitleID2.Font = FontUnicode(gbUnicode)
                        Case "OLSC20" 'Bậc lương 2
                            lblSalaryLevelID2.Text = .Item("Short").ToString
                            lblSalaryLevelID2.Font = FontUnicode(gbUnicode)
                        Case "OLSC21" 'Hệ số 1
                            lblSaCoefficient2.Text = .Item("Short").ToString
                            lblSaCoefficient2.Font = FontUnicode(gbUnicode)
                        Case "OLSC22" 'Hệ số 2
                            lblSaCoefficient22.Text = .Item("Short").ToString
                            lblSaCoefficient22.Font = FontUnicode(gbUnicode)
                        Case "OLSC23" 'Hệ số 3
                            lblSaCoefficient23.Text = .Item("Short").ToString
                            lblSaCoefficient23.Font = FontUnicode(gbUnicode)
                        Case "OLSC24" 'Hệ số 4
                            lblSaCoefficient24.Text = .Item("Short").ToString
                            lblSaCoefficient24.Font = FontUnicode(gbUnicode)
                        Case "OLSC25" 'Hệ số 5
                            lblSaCoefficient25.Text = .Item("Short").ToString
                            lblSaCoefficient25.Font = FontUnicode(gbUnicode)

                    End Select
                End With
            Next
        End If
    End Sub

#Region "Events tdbcSalEmpGroupID"

    Private Sub tdbcSalEmpGroupID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalEmpGroupID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            'tdbcSalEmpGroupID.Text = ""
            'txtTaxObjectName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tdbcSalEmpGroupID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tdbcSalEmpGroupID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            tdbcSalEmpGroupID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
            tdbcSalEmpGroupID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5) Then
            tdbcSalEmpGroupID.AutoDropDown = False
        End If
    End Sub

    Private Sub tdbcSalEmpGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalEmpGroupID.LostFocus
        If tdbcSalEmpGroupID.FindStringExact(tdbcSalEmpGroupID.Text) = -1 Then tdbcSalEmpGroupID.Text = ""
    End Sub

#End Region

#Region "Events tdbcTaxObjectID with txtTaxObjectName"

    Private Sub tdbcTaxObjectID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTaxObjectID.Close
        If tdbcTaxObjectID.FindStringExact(tdbcTaxObjectID.Text) = -1 Then
            tdbcTaxObjectID.Text = ""
        Else
            If tdbcTaxObjectID.Columns(0).Text = "+" Or tdbcTaxObjectID.Columns(1).Text = "<Add new>" Then
                If ReturnPermission("D13F1010") < EnumPermission.Add Then
                    D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                Else
                    Dim sKey As String = ""
                    Dim f As New D13F1010
                    With f
                        .TaxObjectID = ""
                        .FormState = EnumFormState.FormAdd
                        .ShowDialog()
                        sKey = .TaxObjectID
                        If .bSaved Then
                            LoadTDBCTaxObjectID()
                            tdbcTaxObjectID.SelectedValue = sKey
                            _bSaved = False  '  .bSaved = False
                        Else
                            tdbcTaxObjectID.SelectedValue = ""
                        End If
                        .Dispose()
                    End With
                End If
                tdbcTaxObjectID.Focus()
            End If
        End If
    End Sub

    Private Sub tdbcTaxObjectID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTaxObjectID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            'tdbcTaxObjectID.Text = ""
            'txtTaxObjectName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tdbcTaxObjectID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tdbcTaxObjectID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            tdbcTaxObjectID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
            tdbcTaxObjectID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5) Then
            tdbcTaxObjectID.AutoDropDown = False
        End If

        If e.KeyCode = Keys.Enter Then
            If tdbcTaxObjectID.Text = "+" Then
                If ReturnPermission("D13F1010") < EnumPermission.Add Then
                    D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                Else
                    Dim sKey As String = ""
                    Dim f As New D13F1010
                    With f
                        .TaxObjectID = ""
                        '.FormState = EnumFormState.FormAdd
                        .ShowDialog()
                        sKey = .TaxObjectID
                        If .bSaved Then
                            LoadTDBCTaxObjectID()
                            tdbcTaxObjectID.SelectedValue = sKey
                            _bSaved = False '  .bSaved = False
                        Else
                            tdbcTaxObjectID.SelectedValue = ""
                        End If
                        .Dispose()
                    End With
                    
                End If
                tdbcTaxObjectID.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Events tdbcBankID with txtBankName"
    '    Private Sub tdbcBankID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If tdbcBankID.FindStringExact(tdbcBankID.Text) = -1 Then
    '            tdbcBankID.Text = ""
    '            txtBankName.Text = ""
    '            txtBranchName.Text = ""
    '        End If
    '    End Sub
    '
    '    Private Sub tdbcBankID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        txtBankName.Text = tdbcBankID.Columns(1).Value.ToString
    '        txtBranchName.Text = tdbcBankID.Columns(2).Value.ToString
    '    End Sub
    '    Private Sub tdbcBankID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        '    tdbcBankID.Text = ""
    '        '    txtBankName.Text = ""
    '        '    txtBranchName.Text = ""
    '        'End If
    '    End Sub
#End Region

#Region "Events tdbcBankID2 with txtBankName"

    '    Private Sub tdbcBankID2_Close(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If tdbcBankID2.FindStringExact(tdbcBankID2.Text) = -1 Then
    '            tdbcBankID2.Text = ""
    '            txtBankName2.Text = ""
    '            txtBranchName2.Text = ""
    '        End If
    '    End Sub
    '
    '    Private Sub tdbcBankID2_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        txtBankName2.Text = tdbcBankID2.Columns(1).Value.ToString
    '        txtBranchName2.Text = tdbcBankID2.Columns(2).Value.ToString
    '    End Sub
    '
    '    Private Sub tdbcBankID2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        '    tdbcBankID2.Text = ""
    '        '    txtBankName2.Text = ""
    '        '    txtBranchName2.Text = ""
    '        'End If
    '    End Sub
#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcSalEmpGroupID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalEmpGroupID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalEmpGroupID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalEmpGroupID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub optPaymentMethodC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPaymentMethodC.Click
        'ClearText()
        LockControlBank(False)
    End Sub

    'Private Sub ClearText()
    '    tdbcBankID.SelectedValue = ""
    '    txtExchangeDep.Text = ""
    '    txtBankAccountNo.Text = ""
    '    txtAccountHolderName.Text = ""

    '    tdbcBankID2.SelectedValue = ""
    '    txtExchangeDep2.Text = ""
    '    txtBankAccountNo2.Text = ""
    '    txtAccountHolderName2.Text = ""
    'End Sub

    Private Sub optPaymentMethodB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPaymentMethodB.Click
        LockControlBank(True)
        '        tdbcBankID.AutoSelect = True
        '        tdbcBankID2.AutoSelect = True

    End Sub

    Private Sub optPaymentMethodO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPaymentMethodO.Click
        'ClearText()
        LockControlBank(False)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Function AllowSaveDate(c1dateBaseSalaryxxDateEnd As C1.Win.C1Input.C1DateEdit, c1dateBaseSalaryxxNextDate As C1.Win.C1Input.C1DateEdit) As Boolean
        If c1dateBaseSalaryxxDateEnd.Enabled = True And c1dateBaseSalaryxxNextDate.Enabled = True Then
            If c1dateBaseSalaryxxDateEnd.Text.ToString <> "" And c1dateBaseSalaryxxNextDate.Text.ToString <> "" Then
                If CDate(c1dateBaseSalaryxxDateEnd.Text) > CDate(c1dateBaseSalaryxxNextDate.Text) Then
                    D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
                    Lemon3.Functions.CommonControl.FocusControlInForm(c1dateBaseSalaryxxDateEnd)
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Function AllowSave() As Boolean
        'Tab 1. Thông tin chính
        If tdbcTaxObjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Doi_tuong_tinh_thue"))
            tabMain.SelectedTab = TabPage1
            tdbcTaxObjectID.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbgRelative.RowCount - 1
            If tdbgRelative(i, COL1_DeductibleDateBegin).ToString = "" Then
                tabMain.SelectedTab = TabPage1
                btnDeductibleInfo_Click(Nothing, Nothing)
                D99C0008.MsgNotYetEnter(rL3("Bat_dau_GT"))
                tdbgRelative.Focus()
                tdbgRelative.SplitIndex = SPLIT1
                tdbgRelative.Col = COL1_DeductibleDateBegin
                tdbgRelative.Bookmark = i
                Return False
            End If
            If tdbgRelative(i, COL1_DeductibleDateBegin).ToString <> "" And tdbgRelative(i, COL1_DeductibleDateEnd).ToString <> "" Then
                If CDate(tdbgRelative(i, COL1_DeductibleDateBegin).ToString) > CDate(tdbgRelative(i, COL1_DeductibleDateEnd).ToString) Then
                    tabMain.SelectedTab = TabPage1
                    btnDeductibleInfo_Click(Nothing, Nothing)
                    D99C0008.MsgL3(rL3("MSG000013"))
                    tdbgRelative.Focus()
                    tdbgRelative.SplitIndex = SPLIT1
                    tdbgRelative.Col = COL1_DeductibleDateEnd
                    tdbgRelative.Bookmark = i
                    Return False
                End If
            End If
        Next

        If _callFromForm.Contains("D09U") = False Then 'ID 81478 07/12/2015
            'Tab 2. Ngạch bậc lương
            If tdbcOfficialTitleID.Text <> "" Then
                If tdbcSalaryLevelID.Text.Trim = "" Then
                    D99C0008.MsgNotYetChoose(rL3("Bac_luong_1"))
                    tabMain.SelectedTab = TabPage2
                    tdbcSalaryLevelID.Focus()
                    Return False
                End If
            End If

            If tdbcOfficialTitleID2.Text <> "" Then
                If tdbcSalaryLevelID2.Text.Trim = "" Then
                    D99C0008.MsgNotYetChoose(rL3("Bac_luong_2"))
                    tabMain.SelectedTab = TabPage2
                    tdbcSalaryLevelID2.Focus()
                    Return False
                End If
            End If
            If tdbcNextOfficialTitleID.Text <> "" Then
                If tdbcNextSalaryLevelID.Text.Trim = "" Then
                    D99C0008.MsgNotYetChoose(rL3("Bac_luong_tiep_theo_1"))
                    tabMain.SelectedTab = TabPage2
                    tdbcNextSalaryLevelID.Focus()
                    Return False
                End If
            End If

            If tdbcNextOfficialTitleID2.Text <> "" Then
                If tdbcNextSalaryLevelID2.Text.Trim = "" Then
                    D99C0008.MsgNotYetChoose(rL3("Bac_luong_tiep_theo_2"))
                    tabMain.SelectedTab = TabPage2
                    tdbcNextSalaryLevelID2.Focus()
                    Return False
                End If
            End If

            If AllowSaveDate(c1dateOffSa1DateEnd, c1dateOffSa1NextDate) = False Then Return False
            If AllowSaveDate(c1dateOffSa1DateEnd2, c1dateOffSa1NextDate2) = False Then Return False

            'If c1dateOffSa1DateEnd.Text.ToString <> "" And c1dateOffSa1NextDate.Text.ToString <> "" Then
            '    If CDate(c1dateOffSa1DateEnd.Text) > CDate(c1dateOffSa1NextDate.Text) Then
            '        D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '        tabMain.SelectedTab = TabPage2
            '        c1dateOffSa1DateEnd.Focus()
            '        Return False
            '    End If
            'End If
            'If c1dateOffSa1DateEnd2.Text.ToString <> "" And c1dateOffSa1NextDate2.Text.ToString <> "" Then
            '    If CDate(c1dateOffSa1DateEnd2.Text) > CDate(c1dateOffSa1NextDate2.Text) Then
            '        D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '        tabMain.SelectedTab = TabPage2
            '        c1dateOffSa1DateEnd2.Focus()
            '        Return False
            '    End If
            'End If
            'Tab 3. Lương cơ bản
            If AllowSaveDate(c1dateBaseSalary01DateEnd, c1dateBaseSalary01NextDate) = False Then Return False
            If AllowSaveDate(c1dateBaseSalary02DateEnd, c1dateBaseSalary02NextDate) = False Then Return False
            If AllowSaveDate(c1dateBaseSalary03DateEnd, c1dateBaseSalary03NextDate) = False Then Return False
            If AllowSaveDate(c1dateBaseSalary04DateEnd, c1dateBaseSalary04NextDate) = False Then Return False

            'If c1dateBaseSalary01DateEnd.Enabled = True And c1dateBaseSalary01NextDate.Enabled = True Then
            '    If c1dateBaseSalary01DateEnd.Text.ToString <> "" And c1dateBaseSalary01NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateBaseSalary01DateEnd.Text) > CDate(c1dateBaseSalary01NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateBaseSalary01DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If
            'If c1dateBaseSalary02DateEnd.Enabled = True And c1dateBaseSalary02NextDate.Enabled = True Then
            '    If c1dateBaseSalary02DateEnd.Text.ToString <> "" And c1dateBaseSalary02NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateBaseSalary02DateEnd.Text) > CDate(c1dateBaseSalary02NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateBaseSalary02DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateBaseSalary03DateEnd.Enabled = True And c1dateBaseSalary03NextDate.Enabled = True Then
            '    If c1dateBaseSalary03DateEnd.Text.ToString <> "" And c1dateBaseSalary03NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateBaseSalary03DateEnd.Text) > CDate(c1dateBaseSalary03NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateBaseSalary03DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateBaseSalary04DateEnd.Enabled = True And c1dateBaseSalary04NextDate.Enabled = True Then
            '    If c1dateBaseSalary04DateEnd.Text.ToString <> "" And c1dateBaseSalary04NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateBaseSalary04DateEnd.Text) > CDate(c1dateBaseSalary04NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateBaseSalary04DateEnd.Focus()
            '            Return False

            '        End If
            '    End If

            'End If

            'Tab 4. Hệ số

            If AllowSaveDate(c1dateSal01DateEnd, c1dateSal01NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal02DateEnd, c1dateSal02NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal03DateEnd, c1dateSal03NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal04DateEnd, c1dateSal04NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal05DateEnd, c1dateSal05NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal06DateEnd, c1dateSal06NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal07DateEnd, c1dateSal07NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal08DateEnd, c1dateSal08NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal09DateEnd, c1dateSal09NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal10DateEnd, c1dateSal10NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal11DateEnd, c1dateSal11NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal12DateEnd, c1dateSal12NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal13DateEnd, c1dateSal13NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal14DateEnd, c1dateSal14NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal15DateEnd, c1dateSal15NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal16DateEnd, c1dateSal16NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal17DateEnd, c1dateSal17NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal18DateEnd, c1dateSal18NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal19DateEnd, c1dateSal19NextDate) = False Then Return False
            If AllowSaveDate(c1dateSal20DateEnd, c1dateSal20NextDate) = False Then Return False

            'If c1dateSal01DateEnd.Enabled = True And c1dateSal01NextDate.Enabled = True Then
            '    If c1dateSal01DateEnd.Text.ToString <> "" And c1dateSal01NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal01DateEnd.Text) > CDate(c1dateSal01NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal01DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateSal02DateEnd.Enabled = True And c1dateSal02NextDate.Enabled = True Then
            '    If c1dateSal02DateEnd.Text.ToString <> "" And c1dateSal02NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal02DateEnd.Text) > CDate(c1dateSal02NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal02DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateSal03DateEnd.Enabled = True And c1dateSal03NextDate.Enabled = True Then
            '    If c1dateSal03DateEnd.Text.ToString <> "" And c1dateSal03NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal03DateEnd.Text) > CDate(c1dateSal03NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal03DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If
            'If c1dateSal04DateEnd.Enabled = True And c1dateSal04NextDate.Enabled = True Then
            '    If c1dateSal04DateEnd.Text.ToString <> "" And c1dateSal04NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal04DateEnd.Text) > CDate(c1dateSal04NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal04DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateSal05DateEnd.Enabled = True And c1dateSal05NextDate.Enabled = True Then
            '    If c1dateSal05DateEnd.Text.ToString <> "" And c1dateSal05NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal05DateEnd.Text) > CDate(c1dateSal05NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal05DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If
            'If c1dateSal06DateEnd.Enabled = True And c1dateSal06NextDate.Enabled = True Then
            '    If c1dateSal06DateEnd.Text.ToString <> "" And c1dateSal06NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal06DateEnd.Text) > CDate(c1dateSal06NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal06DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateSal07DateEnd.Enabled = True And c1dateSal07NextDate.Enabled = True Then
            '    If c1dateSal07DateEnd.Text.ToString <> "" And c1dateSal07NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal07DateEnd.Text) > CDate(c1dateSal07NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal07DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If
            'If c1dateSal08DateEnd.Enabled = True And c1dateSal08NextDate.Enabled = True Then
            '    If c1dateSal08DateEnd.Text.ToString <> "" And c1dateSal08NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal08DateEnd.Text) > CDate(c1dateSal08NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal08DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If
            'If c1dateSal09DateEnd.Enabled = True And c1dateSal09NextDate.Enabled = True Then
            '    If c1dateSal09DateEnd.Text.ToString <> "" And c1dateSal09NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal09DateEnd.Text) > CDate(c1dateSal09NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal09DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            'If c1dateSal10DateEnd.Enabled = True And c1dateSal10NextDate.Enabled = True Then
            '    If c1dateSal10DateEnd.Text.ToString <> "" And c1dateSal10NextDate.Text.ToString <> "" Then
            '        If CDate(c1dateSal10DateEnd.Text) > CDate(c1dateSal10NextDate.Text) Then
            '            D99C0008.MsgL3(rL3("Ngay_xet_cuoi_cung_khong_duoc_lon_hon_Ngay_xet_tiep_theo"))
            '            tabMain.SelectedTab = TabPage2
            '            c1dateSal10DateEnd.Focus()
            '            Return False
            '        End If
            '    End If
            'End If




            If txtBaseSalary01.Text <> "" Then
                If Convert.ToDecimal(txtBaseSalary01.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary01.Focus()
                    Return False
                End If
            End If
            If Convert.ToDecimal(txtBaseSalary02.Text) <> 0 Then
                If Convert.ToDecimal(txtBaseSalary02.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary02.Focus()
                    Return False
                End If
            End If
            If Convert.ToDecimal(txtBaseSalary03.Text) <> 0 Then
                If Convert.ToDecimal(txtBaseSalary03.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary03.Focus()
                    Return False
                End If
            End If
            If Convert.ToDecimal(txtBaseSalary04.Text) <> 0 Then
                If Convert.ToDecimal(txtBaseSalary04.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary04.Focus()
                    Return False
                End If
            End If
            If txtNextBaseSalary01.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextBaseSalary01.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary01.Focus()
                    Return False
                End If
            End If
            If txtNextBaseSalary02.Text.Trim <> "" Then
                If Decimal.Parse(txtNextBaseSalary02.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary02.Focus()
                    Return False
                End If

            End If
            If txtNextBaseSalary03.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextBaseSalary03.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary03.Focus()
                    Return False
                End If
            End If
            If txtNextBaseSalary04.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextBaseSalary04.Text) > MaxMoney Then
                    D99C0008.MsgNotYetEnter(rL3("Muc_luong_co_ban_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtBaseSalary04.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient01.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient01.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient01.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient02.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient02.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient02.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient03.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient03.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient03.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient04.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient04.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient04.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient05.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient05.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient05.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient06.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient06.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient06.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient07.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient07.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient07.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient08.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient08.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient08.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient09.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient09.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient09.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient10.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient10.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient10.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient01.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient01.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient01.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient02.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient02.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient02.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient03.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient03.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient03.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient04.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient04.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient04.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient05.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient05.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient05.Focus()
                    Return False
                End If
            End If
            If txtSalCoefficient06.Text.Trim <> "" Then
                If Convert.ToDecimal(txtSalCoefficient06.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtSalCoefficient06.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient07.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient07.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient07.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient08.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient08.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient08.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient09.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient09.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient09.Focus()
                    Return False
                End If
            End If
            If txtNextSalCoefficient10.Text.Trim <> "" Then
                If Convert.ToDecimal(txtNextSalCoefficient10.Text.Trim.Length) > MaxMoney Then
                    D99C0008.MsgL3(rL3("Gia_tri_he_so_luong_tiep_theo_khong_duoc_vuot_qua_") & MaxMoney)
                    tabMain.SelectedTab = TabPage2
                    txtNextSalCoefficient10.Focus()
                    Return False
                End If
            End If
            'Tab 5. Phương pháp trả lương
            If Not AllowSaveBankID() Then Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbgRelative.UpdateData()
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        sSQL = SQLStoreD09P6200(0).ToString & vbCrLf
        sSQL &= SQLDeleteD13T2100().ToString & vbCrLf
        sSQL &= SQLInsertD13T2100s().ToString & vbCrLf



        sSQL &= SQLUpdateD13T0201() & vbCrLf
        ' update 30/9/2013 id 59822 - chỉ bổ sung thêm câu Update D13T0101 liền sau câu Update D13T0201
        sSQL &= SQLUpdateD13T0101().ToString & vbCrLf
        sSQL &= SQLDeleteD13T0202() & vbCrLf
        sSQL &= SQLInsertD13T0202s().ToString & vbCrLf

        If (_callFromModule = "D09" And _FormState = EnumFormState.FormAdd) Or (_callFromModule = "D09" And _status = "0") Or (_callFromModule = "D13" And _status = "0") Then
            sSQL &= SQLStoreD13P2017().ToString() & vbCrLf
        Else
            'sSQL &= SQLUpdateD13T0101().ToString() & vbCrLf
        End If

        sSQL &= SQLDeleteD13T0216() & vbCrLf
        sSQL &= SQLInsertD13T0216s().ToString & vbCrLf
        If _callFromModule = "D09" Then
            sSQL &= SQLStoreD21P4070() & vbCrLf
        End If
        sSQL &= SQLStoreD09P6200(1).ToString() & vbCrLf
        sSQL &= SQLStoreD09P6210().ToString() & vbCrLf

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)

        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            '  SavedOK = .bSaved
            ' update 18/11/2013 id 61334 - BỎ KIỂM TRA NHÂN VIÊN ĐÃ TỒN TẠI HSL THÁNG
            '            ' update 3/4/2013 id 53610
            '            Dim dtResult As DataTable = Nothing
            '            If CheckStore(SQLStoreD13P5555(), , dtResult) Then
            '                If dtResult.Rows(0).Item("Status").ToString = "1" Then
            '                    Dim frame As New FrameUpdateSalary
            '                    frame.FormID = Me.Name
            '                    frame.EmployeeID = _employeeID
            '                    frame.ShowDialog()
            '                    frame.Dispose()
            '                    ' update 26/6/2013 id 56445
            '                ElseIf dtResult.Rows(0).Item("Status").ToString = "2" Then
            '                    ExecuteSQL(SQLStoreD13P0101)
            '                End If
            '            End If
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2017
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 17/10/2011 07:58:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2017() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2017 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(3) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_employeeID) 'EmployeeID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0110
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 07:58:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0110 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0100
    '# Created User: DUCTRONG
    '# Created Date: 04/05/2009 01:59:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0100() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0100 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherNo) & COMMA 'PayrollVoucherNo, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(sVoucherTypeID) & COMMA 'VoucherTypeID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(sVoucherDate) & COMMA 'VoucherDate, datetime, NOT NULL
        sSQL &= SQLString(sDescription) & COMMA 'Description, varchar[50], NOT NULL
        sSQL &= SQLString(sCreateUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
        sSQL &= SQLString(sLastModifyUserID) & COMMA 'LastModifyUserID, varchar[20], NOT NULL
        sSQL &= SQLString(txtDepartmentID.Text) & COMMA 'AllDepartmentID, varchar[2000], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'OldPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsAddFromMaster, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IgnoreSub, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsSpecialProcessing, tinyint, NOT NULL
        sSQL &= SQLString(_employeeID) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0102
    '# Created User: DUCTRONG
    '# Created Date: 04/05/2009 02:09:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0102() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0102 "
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[8000], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(0) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P4070
    '# Created User: DUCTRONG
    '# Created Date: 12/05/2008 02:15:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P4070() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D21P4070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA
        sSQL &= SQLNumber(0) & COMMA
        sSQL &= SQLNumber(0) & COMMA
        sSQL &= SQLString("") & COMMA
        sSQL &= SQLString("") & COMMA
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P2000
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2008 03:28:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P2000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D21P2000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString("0001") & COMMA 'AdjustTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/02/2007 08:34:57
    '# Modified User: Đỗ MInh Dũng
    '# Modified Date: 20/11/2007
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0201 Set "
        sSQL &= "SalaryObjectID = " & SQLString(tdbcSalaryObjectID.Text) & COMMA
        sSQL &= "BaseSalary01 = " & SQLMoney(txtBaseSalary01.Text, InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary02 = " & SQLMoney(txtBaseSalary02.Text, InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary03 = " & SQLMoney(txtBaseSalary03.Text, InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary04 = " & SQLMoney(txtBaseSalary04.Text, InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "NextBaseSalary01 = " & SQLMoney(txtNextBaseSalary01.Text, InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextBaseSalary02 = " & SQLMoney(txtNextBaseSalary02.Text, InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextBaseSalary03 = " & SQLMoney(txtNextBaseSalary03.Text, InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextBaseSalary04 = " & SQLMoney(txtNextBaseSalary04.Text, InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "BaseCurrencyID01 = " & SQLString(ReturnValueC1Combo(tdbcBaseCurrencyID01)) & COMMA 'varchar[50], NULL
        sSQL &= "BaseCurrencyID02 = " & SQLString(ReturnValueC1Combo(tdbcBaseCurrencyID02)) & COMMA 'varchar[50], NULL
        sSQL &= "BaseCurrencyID03 = " & SQLString(ReturnValueC1Combo(tdbcBaseCurrencyID03)) & COMMA 'varchar[50], NULL
        sSQL &= "BaseCurrencyID04 = " & SQLString(ReturnValueC1Combo(tdbcBaseCurrencyID04)) & COMMA 'varchar[50], NULL
        sSQL &= vbCrLf
        sSQL &= "SalCoefficient01 = " & SQLMoney(txtSalCoefficient01.Text, InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient02 = " & SQLMoney(txtSalCoefficient02.Text, InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient03 = " & SQLMoney(txtSalCoefficient03.Text, InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient04 = " & SQLMoney(txtSalCoefficient04.Text, InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient05 = " & SQLMoney(txtSalCoefficient05.Text, InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient06 = " & SQLMoney(txtSalCoefficient06.Text, InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient07 = " & SQLMoney(txtSalCoefficient07.Text, InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient08 = " & SQLMoney(txtSalCoefficient08.Text, InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient09 = " & SQLMoney(txtSalCoefficient09.Text, InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient10 = " & SQLMoney(txtSalCoefficient10.Text, InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient11 = " & SQLMoney(txtSalCoefficient11.Text, InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient12 = " & SQLMoney(txtSalCoefficient12.Text, InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient13 = " & SQLMoney(txtSalCoefficient13.Text, InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient14 = " & SQLMoney(txtSalCoefficient14.Text, InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient15 = " & SQLMoney(txtSalCoefficient15.Text, InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient16 = " & SQLMoney(txtSalCoefficient16.Text, InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient17 = " & SQLMoney(txtSalCoefficient17.Text, InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient18 = " & SQLMoney(txtSalCoefficient18.Text, InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient19 = " & SQLMoney(txtSalCoefficient19.Text, InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "SalCoefficient20 = " & SQLMoney(txtSalCoefficient20.Text, InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "SalCoeCurrencyID01 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID01)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID02 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID02)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID03 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID03)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID04 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID04)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID05 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID05)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID06 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID06)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID07 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID07)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID08 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID08)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID09 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID09)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID10 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID10)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID11 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID11)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID12 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID12)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID13 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID13)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID14 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID14)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID15 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID15)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID16 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID16)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID17 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID17)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID18 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID18)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID19 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID19)) & COMMA 'varchar[50], NULL
        sSQL &= "SalCoeCurrencyID20 = " & SQLString(ReturnValueC1Combo(tdbcSalCoeCurrencyID20)) & COMMA 'varchar[50], NULL
        sSQL &= vbCrLf
        sSQL &= "TaxObjectID = " & SQLString(tdbcTaxObjectID.SelectedValue) & COMMA 'varchar[20], NULL
        ' 8/5/2014 id 63987 - Bo group thông tin khác
        '  sSQL &= "TaxCode = " & SQLString(txtTaxCode.Text) & COMMA 'varchar[20], NULL
        If optPaymentMethodC.Checked = True Then
            sSQL &= "PaymentMethod = " & SQLString("C") & COMMA 'varchar[1], NOT NULL
        ElseIf optPaymentMethodB.Checked = True Then
            sSQL &= "PaymentMethod = " & SQLString("B") & COMMA 'varchar[1], NOT NULL
        Else
            sSQL &= "PaymentMethod = " & SQLString("O") & COMMA 'varchar[1], NOT NULL
        End If
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "OfficalTitleID = " & SQLString(tdbcOfficialTitleID.Text) & COMMA 'varchar[20], NULL
        sSQL &= "SalaryLevelID = " & SQLString(tdbcSalaryLevelID.Text) & COMMA 'varchar[20], NULL
        sSQL &= "SaCoefficient = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "OfficalTitleID2 = " & SQLString(tdbcOfficialTitleID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SalaryLevelID2 = " & SQLString(tdbcSalaryLevelID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SaCoefficient2 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "OffSa1DateEnd = " & SQLDateSave(c1dateOffSa1DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "OffSa1NextDate = " & SQLDateSave(c1dateOffSa1NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "OffSa2DateEnd = " & SQLDateSave(c1dateOffSa1DateEnd2.Value) & COMMA 'datetime, NULL
        sSQL &= "OffSa2NextDate = " & SQLDateSave(c1dateOffSa1NextDate2.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "BaseSalary01DateEnd = " & SQLDateSave(c1dateBaseSalary01DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary01NextDate = " & SQLDateSave(c1dateBaseSalary01NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary02DateEnd = " & SQLDateSave(c1dateBaseSalary02DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary02NextDate = " & SQLDateSave(c1dateBaseSalary02NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary03DateEnd = " & SQLDateSave(c1dateBaseSalary03DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary03NextDate = " & SQLDateSave(c1dateBaseSalary03NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary04DateEnd = " & SQLDateSave(c1dateBaseSalary04DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "BaseSalary04NextDate = " & SQLDateSave(c1dateBaseSalary04NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "Sal01DateEnd = " & SQLDateSave(c1dateSal01DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal02DateEnd = " & SQLDateSave(c1dateSal02DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal03DateEnd = " & SQLDateSave(c1dateSal03DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal04DateEnd = " & SQLDateSave(c1dateSal04DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal05DateEnd = " & SQLDateSave(c1dateSal05DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal06DateEnd = " & SQLDateSave(c1dateSal06DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal07DateEnd = " & SQLDateSave(c1dateSal07DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal08DateEnd = " & SQLDateSave(c1dateSal08DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal09DateEnd = " & SQLDateSave(c1dateSal09DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal10DateEnd = " & SQLDateSave(c1dateSal10DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "Sal11DateEnd = " & SQLDateSave(c1dateSal11DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal12DateEnd = " & SQLDateSave(c1dateSal12DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal13DateEnd = " & SQLDateSave(c1dateSal13DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal14DateEnd = " & SQLDateSave(c1dateSal14DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal15DateEnd = " & SQLDateSave(c1dateSal15DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal16DateEnd = " & SQLDateSave(c1dateSal16DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal17DateEnd = " & SQLDateSave(c1dateSal17DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal18DateEnd = " & SQLDateSave(c1dateSal18DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal19DateEnd = " & SQLDateSave(c1dateSal19DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal20DateEnd = " & SQLDateSave(c1dateSal20DateEnd.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "Sal01NextDate = " & SQLDateSave(c1dateSal01NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal02NextDate = " & SQLDateSave(c1dateSal02NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal03NextDate = " & SQLDateSave(c1dateSal03NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal04NextDate = " & SQLDateSave(c1dateSal04NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal05NextDate = " & SQLDateSave(c1dateSal05NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal06NextDate = " & SQLDateSave(c1dateSal06NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal07NextDate = " & SQLDateSave(c1dateSal07NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal08NextDate = " & SQLDateSave(c1dateSal08NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal09NextDate = " & SQLDateSave(c1dateSal09NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal10NextDate = " & SQLDateSave(c1dateSal10NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "Sal11NextDate = " & SQLDateSave(c1dateSal11NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal12NextDate = " & SQLDateSave(c1dateSal12NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal13NextDate = " & SQLDateSave(c1dateSal13NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal14NextDate = " & SQLDateSave(c1dateSal14NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal15NextDate = " & SQLDateSave(c1dateSal15NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal16NextDate = " & SQLDateSave(c1dateSal16NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal17NextDate = " & SQLDateSave(c1dateSal17NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal18NextDate = " & SQLDateSave(c1dateSal18NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal19NextDate = " & SQLDateSave(c1dateSal19NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Sal20NextDate = " & SQLDateSave(c1dateSal20NextDate.Value) & COMMA 'datetime, NULL
        sSQL &= vbCrLf
        sSQL &= "NextOfficalTitleID = " & SQLString(tdbcNextOfficialTitleID.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "NextSalaryLevelID = " & SQLString(tdbcNextSalaryLevelID.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "NextOfficalTitleID2 = " & SQLString(tdbcNextOfficialTitleID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "NextSalaryLevelID2 = " & SQLString(tdbcNextSalaryLevelID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "NextSalaryCoefficient = " & SQLMoney(tdbcNextSalaryLevelID.Columns("SalaryCoefficient").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient2 = " & SQLMoney(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient01 = " & SQLMoney(txtNextSalCoefficient01.Text, InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient02 = " & SQLMoney(txtNextSalCoefficient02.Text, InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient03 = " & SQLMoney(txtNextSalCoefficient03.Text, InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient04 = " & SQLMoney(txtNextSalCoefficient04.Text, InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient05 = " & SQLMoney(txtNextSalCoefficient05.Text, InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient06 = " & SQLMoney(txtNextSalCoefficient06.Text, InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient07 = " & SQLMoney(txtNextSalCoefficient07.Text, InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient08 = " & SQLMoney(txtNextSalCoefficient08.Text, InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient09 = " & SQLMoney(txtNextSalCoefficient09.Text, InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient10 = " & SQLMoney(txtNextSalCoefficient10.Text, InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "NextSalCoefficient11 = " & SQLMoney(txtNextSalCoefficient11.Text, InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient12 = " & SQLMoney(txtNextSalCoefficient12.Text, InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient13 = " & SQLMoney(txtNextSalCoefficient13.Text, InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient14 = " & SQLMoney(txtNextSalCoefficient14.Text, InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient15 = " & SQLMoney(txtNextSalCoefficient15.Text, InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient16 = " & SQLMoney(txtNextSalCoefficient16.Text, InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient17 = " & SQLMoney(txtNextSalCoefficient17.Text, InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient18 = " & SQLMoney(txtNextSalCoefficient18.Text, InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient19 = " & SQLMoney(txtNextSalCoefficient19.Text, InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalCoefficient20 = " & SQLMoney(txtNextSalCoefficient20.Text, InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString)) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "P01ID = " & SQLString(ReturnPAnaID("P01")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P02ID = " & SQLString(ReturnPAnaID("P02")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P03ID = " & SQLString(ReturnPAnaID("P03")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P04ID = " & SQLString(ReturnPAnaID("P04")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P05ID = " & SQLString(ReturnPAnaID("P05")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P06ID = " & SQLString(ReturnPAnaID("P06")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P07ID = " & SQLString(ReturnPAnaID("P07")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P08ID = " & SQLString(ReturnPAnaID("P08")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P09ID = " & SQLString(ReturnPAnaID("P09")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P10ID = " & SQLString(ReturnPAnaID("P10")) & COMMA 'varchar[20], NOT NULL
        sSQL &= vbCrLf
        sSQL &= "P11ID = " & SQLString(ReturnPAnaID("P11")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P12ID = " & SQLString(ReturnPAnaID("P12")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P13ID = " & SQLString(ReturnPAnaID("P13")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P14ID = " & SQLString(ReturnPAnaID("P14")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P15ID = " & SQLString(ReturnPAnaID("P15")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P16ID = " & SQLString(ReturnPAnaID("P16")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P17ID = " & SQLString(ReturnPAnaID("P17")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P18ID = " & SQLString(ReturnPAnaID("P18")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P19ID = " & SQLString(ReturnPAnaID("P19")) & COMMA 'varchar[20], NOT NULL
        sSQL &= "P20ID = " & SQLString(ReturnPAnaID("P20")) & COMMA 'varchar[20], NOT NULL
        sSQL &= vbCrLf
        ' 8/5/2014 id 63987 - Bo group thông tin khác
        '   sSQL &= "IsTransferEmail = " & SQLNumber(chkIsTransferEmail.Checked) & COMMA 'tinyint, NOT NULL
        'Update 25/11/2011: Bỏ checkbox này Incident 44587
        'sSQL &= "IsSpecialProcessing = " & SQLNumber(chkSpecialProcess.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "SaCoefficient12 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient02").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient13 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient03").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient14 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient04").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient15 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient05").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient22 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient02").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient23 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient03").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient24 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient04").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SaCoefficient25 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient05").Text) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "NextSalaryCoefficient12 = " & SQLMoney(tdbcNextSalaryLevelID.Columns("SalaryCoefficient02").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient13 = " & SQLMoney(tdbcNextSalaryLevelID.Columns("SalaryCoefficient03").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient14 = " & SQLMoney(tdbcNextSalaryLevelID.Columns("SalaryCoefficient04").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient15 = " & SQLMoney(tdbcNextSalaryLevelID.Columns("SalaryCoefficient05").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient22 = " & SQLMoney(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient02").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient23 = " & SQLMoney(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient03").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient24 = " & SQLMoney(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient04").Text) & COMMA 'decimal, NOT NULL
        sSQL &= "NextSalaryCoefficient25 = " & SQLMoney(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient05").Text) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "SalEmpGroupID = " & SQLString(ComboValue(tdbcSalEmpGroupID)) & COMMA 'varchar[50], NOT NULL

        sSQL &= vbCrLf
        sSQL &= "NumMonthBase01 = " & SQLMoney(cneNumMonthBase01.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthBase02 = " & SQLMoney(cneNumMonthBase02.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthBase03 = " & SQLMoney(cneNumMonthBase03.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthBase04 = " & SQLMoney(cneNumMonthBase04.Value) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "NumMonthSalCoe01 = " & SQLMoney(cneNumMonthSalCoe01.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe02 = " & SQLMoney(cneNumMonthSalCoe02.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe03 = " & SQLMoney(cneNumMonthSalCoe03.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe04 = " & SQLMoney(cneNumMonthSalCoe04.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe05 = " & SQLMoney(cneNumMonthSalCoe05.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe06 = " & SQLMoney(cneNumMonthSalCoe06.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe07 = " & SQLMoney(cneNumMonthSalCoe07.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe08 = " & SQLMoney(cneNumMonthSalCoe08.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe09 = " & SQLMoney(cneNumMonthSalCoe09.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe10 = " & SQLMoney(cneNumMonthSalCoe10.Value) & COMMA 'decimal, NOT NULL
        sSQL &= vbCrLf
        sSQL &= "NumMonthSalCoe11 = " & SQLMoney(cneNumMonthSalCoe11.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe12 = " & SQLMoney(cneNumMonthSalCoe12.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe13 = " & SQLMoney(cneNumMonthSalCoe13.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe14 = " & SQLMoney(cneNumMonthSalCoe14.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe15 = " & SQLMoney(cneNumMonthSalCoe15.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe16 = " & SQLMoney(cneNumMonthSalCoe16.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe17 = " & SQLMoney(cneNumMonthSalCoe17.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe18 = " & SQLMoney(cneNumMonthSalCoe18.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe19 = " & SQLMoney(cneNumMonthSalCoe19.Value) & COMMA 'decimal, NOT NULL
        sSQL &= "NumMonthSalCoe20 = " & SQLMoney(cneNumMonthSalCoe20.Value)  'decimal, NOT NULL
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(_divisionID) & " And "
        sSQL &= "EmployeeID = " & SQLString(_employeeID)
        Return sSQL
    End Function

    Private Function ReturnPAnaID(ByVal PAnaCategoryID As String) As String
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_PAnaCategoryID).ToString = PAnaCategoryID Then
                Return tdbg(i, COL_PAnaID).ToString
            End If
        Next
        Return ""
    End Function

    Private Sub CheckKeyDownForPaste(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.V
                    bFlagPaste = True
                    Exit Sub
            End Select
        End If
        bFlagPaste = False
    End Sub

    Private Function CheckKeyPressPaste(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        If bFlagPaste Then
            If Not IsNumeric(Clipboard.GetText) Then
                Return True
            Else
                Return False
            End If
        Else
            Return CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Function

    Private Sub txt_NumberFormat1()
        txtBaseSalary01.Text = (SQLNumber(txtBaseSalary01.Text, InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString))).ToString
        txtBaseSalary02.Text = (SQLNumber(txtBaseSalary02.Text, InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString))).ToString
        txtBaseSalary03.Text = (SQLNumber(txtBaseSalary03.Text, InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString))).ToString
        txtBaseSalary04.Text = (SQLNumber(txtBaseSalary04.Text, InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString))).ToString
        txtNextBaseSalary01.Text = (SQLNumber(txtNextBaseSalary01.Text, InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString))).ToString
        txtNextBaseSalary02.Text = (SQLNumber(txtNextBaseSalary02.Text, InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString))).ToString
        txtNextBaseSalary03.Text = (SQLNumber(txtNextBaseSalary03.Text, InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString))).ToString
        txtNextBaseSalary04.Text = (SQLNumber(txtNextBaseSalary04.Text, InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString))).ToString

        txtSalaryCoefficient.Text = (SQLNumber(txtSalaryCoefficient.Text, D13Format.DefaultNumber2)).ToString
        txtSalaryCoefficient2.Text = (SQLNumber(txtSalaryCoefficient2.Text, D13Format.DefaultNumber2)).ToString
        txtNextSalaryCoefficient.Text = (SQLNumber(txtNextSalaryCoefficient.Text, D13Format.DefaultNumber2)).ToString
        txtNextSalaryCoefficient2.Text = (SQLNumber(txtNextSalaryCoefficient2.Text, D13Format.DefaultNumber2)).ToString


        txtSalCoefficient01.Text = (SQLNumber(txtSalCoefficient01.Text, InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString))).ToString
        txtSalCoefficient02.Text = (SQLNumber(txtSalCoefficient02.Text, InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString))).ToString
        txtSalCoefficient03.Text = (SQLNumber(txtSalCoefficient03.Text, InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString))).ToString
        txtSalCoefficient04.Text = (SQLNumber(txtSalCoefficient04.Text, InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString))).ToString
        txtSalCoefficient05.Text = (SQLNumber(txtSalCoefficient05.Text, InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString))).ToString
        txtSalCoefficient06.Text = (SQLNumber(txtSalCoefficient06.Text, InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString))).ToString
        txtSalCoefficient07.Text = (SQLNumber(txtSalCoefficient07.Text, InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString))).ToString
        txtSalCoefficient08.Text = (SQLNumber(txtSalCoefficient08.Text, InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString))).ToString
        txtSalCoefficient09.Text = (SQLNumber(txtSalCoefficient09.Text, InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString))).ToString
        txtSalCoefficient10.Text = (SQLNumber(txtSalCoefficient10.Text, InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString))).ToString

        txtSalCoefficient11.Text = (SQLNumber(txtSalCoefficient11.Text, InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString))).ToString
        txtSalCoefficient12.Text = (SQLNumber(txtSalCoefficient12.Text, InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString))).ToString
        txtSalCoefficient13.Text = (SQLNumber(txtSalCoefficient13.Text, InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString))).ToString
        txtSalCoefficient14.Text = (SQLNumber(txtSalCoefficient14.Text, InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString))).ToString
        txtSalCoefficient15.Text = (SQLNumber(txtSalCoefficient15.Text, InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString))).ToString
        txtSalCoefficient16.Text = (SQLNumber(txtSalCoefficient16.Text, InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString))).ToString
        txtSalCoefficient17.Text = (SQLNumber(txtSalCoefficient17.Text, InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString))).ToString
        txtSalCoefficient18.Text = (SQLNumber(txtSalCoefficient18.Text, InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString))).ToString
        txtSalCoefficient19.Text = (SQLNumber(txtSalCoefficient19.Text, InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString))).ToString
        txtSalCoefficient20.Text = (SQLNumber(txtSalCoefficient20.Text, InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString))).ToString

        txtNextSalCoefficient01.Text = (SQLNumber(txtNextSalCoefficient01.Text, InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient02.Text = (SQLNumber(txtNextSalCoefficient02.Text, InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient03.Text = (SQLNumber(txtNextSalCoefficient03.Text, InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient04.Text = (SQLNumber(txtNextSalCoefficient04.Text, InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient05.Text = (SQLNumber(txtNextSalCoefficient05.Text, InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient06.Text = (SQLNumber(txtNextSalCoefficient06.Text, InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient07.Text = (SQLNumber(txtNextSalCoefficient07.Text, InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient08.Text = (SQLNumber(txtNextSalCoefficient08.Text, InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient09.Text = (SQLNumber(txtNextSalCoefficient09.Text, InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient10.Text = (SQLNumber(txtNextSalCoefficient10.Text, InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString))).ToString

        txtNextSalCoefficient11.Text = (SQLNumber(txtNextSalCoefficient11.Text, InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient12.Text = (SQLNumber(txtNextSalCoefficient12.Text, InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient13.Text = (SQLNumber(txtNextSalCoefficient13.Text, InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient14.Text = (SQLNumber(txtNextSalCoefficient14.Text, InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient15.Text = (SQLNumber(txtNextSalCoefficient15.Text, InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient16.Text = (SQLNumber(txtNextSalCoefficient16.Text, InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient17.Text = (SQLNumber(txtNextSalCoefficient17.Text, InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient18.Text = (SQLNumber(txtNextSalCoefficient18.Text, InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient19.Text = (SQLNumber(txtNextSalCoefficient19.Text, InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString))).ToString
        txtNextSalCoefficient20.Text = (SQLNumber(txtNextSalCoefficient20.Text, InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString))).ToString

    End Sub

    Private Sub txt_NumberFormat()
        Try
            txtBaseSalary01.Text = FormatRoundNumber(txtBaseSalary01.Text, CInt(dtSALBA.Rows(0).Item("Decimals").ToString))
            txtBaseSalary02.Text = FormatRoundNumber(txtBaseSalary02.Text, CInt(dtSALBA.Rows(1).Item("Decimals").ToString))
            txtBaseSalary03.Text = FormatRoundNumber(txtBaseSalary03.Text, CInt(dtSALBA.Rows(2).Item("Decimals").ToString))
            txtBaseSalary04.Text = FormatRoundNumber(txtBaseSalary04.Text, CInt(dtSALBA.Rows(3).Item("Decimals").ToString))
            txtNextBaseSalary01.Text = FormatRoundNumber(txtNextBaseSalary01.Text, CInt(dtSALBA.Rows(0).Item("Decimals").ToString))
            txtNextBaseSalary02.Text = FormatRoundNumber(txtNextBaseSalary02.Text, CInt(dtSALBA.Rows(1).Item("Decimals").ToString))
            txtNextBaseSalary03.Text = FormatRoundNumber(txtNextBaseSalary03.Text, CInt(dtSALBA.Rows(2).Item("Decimals").ToString))
            txtNextBaseSalary04.Text = FormatRoundNumber(txtNextBaseSalary04.Text, CInt(dtSALBA.Rows(3).Item("Decimals").ToString))
        Catch ex As Exception
            MessageBox.Show("Loi: " & ex.Message & " - " & ex.Source)
        End Try

        txtSalaryCoefficient.Text = (SQLNumber(txtSalaryCoefficient.Text, D13Format.DefaultNumber2)).ToString
        txtSalaryCoefficient2.Text = (SQLNumber(txtSalaryCoefficient2.Text, D13Format.DefaultNumber2)).ToString
        txtNextSalaryCoefficient.Text = (SQLNumber(txtNextSalaryCoefficient.Text, D13Format.DefaultNumber2)).ToString
        txtNextSalaryCoefficient2.Text = (SQLNumber(txtNextSalaryCoefficient2.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient01.Text = FormatRoundNumber(txtSalCoefficient01.Text, CInt(dtSALCE.Rows(0).Item("Decimals").ToString))
        txtSalCoefficient02.Text = FormatRoundNumber(txtSalCoefficient02.Text, CInt(dtSALCE.Rows(1).Item("Decimals").ToString))
        txtSalCoefficient03.Text = FormatRoundNumber(txtSalCoefficient03.Text, CInt(dtSALCE.Rows(2).Item("Decimals").ToString))
        txtSalCoefficient04.Text = FormatRoundNumber(txtSalCoefficient04.Text, CInt(dtSALCE.Rows(3).Item("Decimals").ToString))
        txtSalCoefficient05.Text = FormatRoundNumber(txtSalCoefficient05.Text, CInt(dtSALCE.Rows(4).Item("Decimals").ToString))
        txtSalCoefficient06.Text = FormatRoundNumber(txtSalCoefficient06.Text, CInt(dtSALCE.Rows(5).Item("Decimals").ToString))
        txtSalCoefficient07.Text = FormatRoundNumber(txtSalCoefficient07.Text, CInt(dtSALCE.Rows(6).Item("Decimals").ToString))
        txtSalCoefficient08.Text = FormatRoundNumber(txtSalCoefficient08.Text, CInt(dtSALCE.Rows(7).Item("Decimals").ToString))
        txtSalCoefficient09.Text = FormatRoundNumber(txtSalCoefficient09.Text, CInt(dtSALCE.Rows(8).Item("Decimals").ToString))
        txtSalCoefficient10.Text = FormatRoundNumber(txtSalCoefficient10.Text, CInt(dtSALCE.Rows(9).Item("Decimals").ToString))

        txtSalCoefficient11.Text = FormatRoundNumber(txtSalCoefficient11.Text, CInt(dtSALCE.Rows(10).Item("Decimals").ToString))
        txtSalCoefficient12.Text = FormatRoundNumber(txtSalCoefficient12.Text, CInt(dtSALCE.Rows(11).Item("Decimals").ToString))
        txtSalCoefficient13.Text = FormatRoundNumber(txtSalCoefficient13.Text, CInt(dtSALCE.Rows(12).Item("Decimals").ToString))
        txtSalCoefficient14.Text = FormatRoundNumber(txtSalCoefficient14.Text, CInt(dtSALCE.Rows(13).Item("Decimals").ToString))
        txtSalCoefficient15.Text = FormatRoundNumber(txtSalCoefficient15.Text, CInt(dtSALCE.Rows(14).Item("Decimals").ToString))
        txtSalCoefficient16.Text = FormatRoundNumber(txtSalCoefficient16.Text, CInt(dtSALCE.Rows(15).Item("Decimals").ToString))
        txtSalCoefficient17.Text = FormatRoundNumber(txtSalCoefficient17.Text, CInt(dtSALCE.Rows(16).Item("Decimals").ToString))
        txtSalCoefficient18.Text = FormatRoundNumber(txtSalCoefficient18.Text, CInt(dtSALCE.Rows(17).Item("Decimals").ToString))
        txtSalCoefficient19.Text = FormatRoundNumber(txtSalCoefficient19.Text, CInt(dtSALCE.Rows(18).Item("Decimals").ToString))
        txtSalCoefficient20.Text = FormatRoundNumber(txtSalCoefficient20.Text, CInt(dtSALCE.Rows(19).Item("Decimals").ToString))

        txtNextSalCoefficient01.Text = FormatRoundNumber(txtNextSalCoefficient01.Text, CInt(dtSALCE.Rows(0).Item("Decimals").ToString))
        txtNextSalCoefficient02.Text = FormatRoundNumber(txtNextSalCoefficient02.Text, CInt(dtSALCE.Rows(1).Item("Decimals").ToString))
        txtNextSalCoefficient03.Text = FormatRoundNumber(txtNextSalCoefficient03.Text, CInt(dtSALCE.Rows(2).Item("Decimals").ToString))
        txtNextSalCoefficient04.Text = FormatRoundNumber(txtNextSalCoefficient04.Text, CInt(dtSALCE.Rows(3).Item("Decimals").ToString))
        txtNextSalCoefficient05.Text = FormatRoundNumber(txtNextSalCoefficient05.Text, CInt(dtSALCE.Rows(4).Item("Decimals").ToString))
        txtNextSalCoefficient06.Text = FormatRoundNumber(txtNextSalCoefficient06.Text, CInt(dtSALCE.Rows(5).Item("Decimals").ToString))
        txtNextSalCoefficient07.Text = FormatRoundNumber(txtNextSalCoefficient07.Text, CInt(dtSALCE.Rows(6).Item("Decimals").ToString))
        txtNextSalCoefficient08.Text = FormatRoundNumber(txtNextSalCoefficient08.Text, CInt(dtSALCE.Rows(7).Item("Decimals").ToString))
        txtNextSalCoefficient09.Text = FormatRoundNumber(txtNextSalCoefficient09.Text, CInt(dtSALCE.Rows(8).Item("Decimals").ToString))
        txtNextSalCoefficient10.Text = FormatRoundNumber(txtNextSalCoefficient10.Text, CInt(dtSALCE.Rows(9).Item("Decimals").ToString))

        txtNextSalCoefficient11.Text = FormatRoundNumber(txtNextSalCoefficient11.Text, CInt(dtSALCE.Rows(10).Item("Decimals").ToString))
        txtNextSalCoefficient12.Text = FormatRoundNumber(txtNextSalCoefficient12.Text, CInt(dtSALCE.Rows(11).Item("Decimals").ToString))
        txtNextSalCoefficient13.Text = FormatRoundNumber(txtNextSalCoefficient13.Text, CInt(dtSALCE.Rows(12).Item("Decimals").ToString))
        txtNextSalCoefficient14.Text = FormatRoundNumber(txtNextSalCoefficient14.Text, CInt(dtSALCE.Rows(13).Item("Decimals").ToString))
        txtNextSalCoefficient15.Text = FormatRoundNumber(txtNextSalCoefficient15.Text, CInt(dtSALCE.Rows(14).Item("Decimals").ToString))
        txtNextSalCoefficient16.Text = FormatRoundNumber(txtNextSalCoefficient16.Text, CInt(dtSALCE.Rows(15).Item("Decimals").ToString))
        txtNextSalCoefficient17.Text = FormatRoundNumber(txtNextSalCoefficient17.Text, CInt(dtSALCE.Rows(16).Item("Decimals").ToString))
        txtNextSalCoefficient18.Text = FormatRoundNumber(txtNextSalCoefficient18.Text, CInt(dtSALCE.Rows(17).Item("Decimals").ToString))
        txtNextSalCoefficient19.Text = FormatRoundNumber(txtNextSalCoefficient19.Text, CInt(dtSALCE.Rows(18).Item("Decimals").ToString))
        txtNextSalCoefficient20.Text = FormatRoundNumber(txtNextSalCoefficient20.Text, CInt(dtSALCE.Rows(19).Item("Decimals").ToString))

    End Sub

#Region "Events tdbcBaseCurrencyIDxx"

    Private Sub tdbcBaseCurrencyIDxx_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBaseCurrencyID01.LostFocus, tdbcBaseCurrencyID02.LostFocus, tdbcBaseCurrencyID03.LostFocus, tdbcBaseCurrencyID04.LostFocus, tdbcSalCoeCurrencyID01.LostFocus, tdbcSalCoeCurrencyID02.LostFocus, tdbcSalCoeCurrencyID03.LostFocus, tdbcSalCoeCurrencyID04.LostFocus, tdbcSalCoeCurrencyID05.LostFocus, tdbcSalCoeCurrencyID06.LostFocus, tdbcSalCoeCurrencyID07.LostFocus, tdbcSalCoeCurrencyID08.LostFocus, tdbcSalCoeCurrencyID09.LostFocus, tdbcSalCoeCurrencyID10.LostFocus, tdbcSalCoeCurrencyID11.LostFocus, tdbcSalCoeCurrencyID12.LostFocus, tdbcSalCoeCurrencyID13.LostFocus, tdbcSalCoeCurrencyID14.LostFocus, tdbcSalCoeCurrencyID15.LostFocus, tdbcSalCoeCurrencyID16.LostFocus, tdbcSalCoeCurrencyID17.LostFocus, tdbcSalCoeCurrencyID18.LostFocus, tdbcSalCoeCurrencyID19.LostFocus, tdbcSalCoeCurrencyID20.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBaseCurrencyID01.Close, tdbcBaseCurrencyID02.Close, tdbcBaseCurrencyID03.Close, tdbcBaseCurrencyID04.Close, tdbcSalCoeCurrencyID01.Close, tdbcSalCoeCurrencyID02.Close, tdbcSalCoeCurrencyID03.Close, tdbcSalCoeCurrencyID04.Close, tdbcSalCoeCurrencyID05.Close, tdbcSalCoeCurrencyID06.Close, tdbcSalCoeCurrencyID07.Close, tdbcSalCoeCurrencyID08.Close, tdbcSalCoeCurrencyID09.Close, tdbcSalCoeCurrencyID10.Close, tdbcSalCoeCurrencyID11.Close, tdbcSalCoeCurrencyID12.Close, tdbcSalCoeCurrencyID13.Close, tdbcSalCoeCurrencyID14.Close, tdbcSalCoeCurrencyID15.Close, tdbcSalCoeCurrencyID16.Close, tdbcSalCoeCurrencyID17.Close, tdbcSalCoeCurrencyID18.Close, tdbcSalCoeCurrencyID19.Close, tdbcSalCoeCurrencyID20.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBaseCurrencyID01.Validated, tdbcBaseCurrencyID02.Validated, tdbcBaseCurrencyID03.Validated, tdbcBaseCurrencyID04.Validated, tdbcSalCoeCurrencyID01.Validated, tdbcSalCoeCurrencyID02.Validated, tdbcSalCoeCurrencyID03.Validated, tdbcSalCoeCurrencyID04.Validated, tdbcSalCoeCurrencyID05.Validated, tdbcSalCoeCurrencyID06.Validated, tdbcSalCoeCurrencyID07.Validated, tdbcSalCoeCurrencyID08.Validated, tdbcSalCoeCurrencyID09.Validated, tdbcSalCoeCurrencyID10.Validated, tdbcSalCoeCurrencyID11.Validated, tdbcSalCoeCurrencyID12.Validated, tdbcSalCoeCurrencyID13.Validated, tdbcSalCoeCurrencyID14.Validated, tdbcSalCoeCurrencyID15.Validated, tdbcSalCoeCurrencyID16.Validated, tdbcSalCoeCurrencyID17.Validated, tdbcSalCoeCurrencyID18.Validated, tdbcSalCoeCurrencyID19.Validated, tdbcSalCoeCurrencyID20.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Events tdbcOfficialTitleID"

    Private Sub tdbcOfficialTitleID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.Close
        If tdbcOfficialTitleID.FindStringExact(tdbcOfficialTitleID.Text) = -1 Then tdbcOfficialTitleID.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcOfficialTitleID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            'tdbcOfficialTitleID.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tdbcOfficialTitleID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tdbcOfficialTitleID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            tdbcOfficialTitleID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
            tdbcOfficialTitleID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5) Then
            tdbcOfficialTitleID.AutoDropDown = False
        End If

    End Sub

    Private Sub tdbcOfficialTitleID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.SelectedValueChanged
        If Not (tdbcOfficialTitleID.Tag Is Nothing OrElse tdbcOfficialTitleID.Tag.ToString = "") Then
            tdbcOfficialTitleID.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID(tdbcSalaryLevelID, "-1", "-1")
            Exit Sub
        End If

        tdbcNextOfficialTitleID.SelectedValue = tdbcOfficialTitleID.Text

        LoadtdbcSalaryLevelID(tdbcSalaryLevelID, tdbcOfficialTitleID.SelectedValue.ToString, tdbcOfficialTitleID.Columns("IsUseOfficial").Text)
        ' update 23/10/2013 id 60852 - Theo chị Thuận, lấy số lẻ trong bảng dtOLSC
        'tdbcSalaryLevelID.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcSalaryLevelID.Text = ""
        txtSalaryCoefficient.Text = ""

    End Sub

#End Region

#Region "Events tdbcOfficialTitleID2"

    Private Sub tdbcOfficialTitleID2_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID2.Close
        If tdbcOfficialTitleID2.FindStringExact(tdbcOfficialTitleID2.Text) = -1 Then tdbcOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcOfficialTitleID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID2.SelectedValueChanged
        If Not (tdbcOfficialTitleID2.Tag Is Nothing OrElse tdbcOfficialTitleID2.Tag.ToString = "") Then
            tdbcOfficialTitleID2.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID2.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID(tdbcSalaryLevelID2, "-1", "-1")
            Exit Sub
        End If

        tdbcNextOfficialTitleID2.SelectedValue = tdbcOfficialTitleID2.Text

        LoadtdbcSalaryLevelID(tdbcSalaryLevelID2, tdbcOfficialTitleID2.SelectedValue.ToString, tdbcOfficialTitleID2.Columns("IsUseOfficial").Text)
        ' update 23/10/2013 id 60852 - Theo chị Thuận, lấy số lẻ trong bảng dtOLSC
        'tdbcSalaryLevelID2.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcSalaryLevelID2.Text = ""
        txtSalaryCoefficient2.Text = ""
        tdbcNextSalaryLevelID2.Text = ""
    End Sub
#End Region

#Region "Events tdbcNextOfficialTitleID"

    Private Sub tdbcNextOfficialTitleID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNextOfficialTitleID.Close
        If tdbcNextOfficialTitleID.FindStringExact(tdbcNextOfficialTitleID.Text) = -1 Then tdbcNextOfficialTitleID.Text = ""
    End Sub

    Private Sub tdbcNextOfficialTitleID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcNextOfficialTitleID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcNextOfficialTitleID.Text = ""
    End Sub

    Private Sub tdbcNextOfficialTitleID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextOfficialTitleID.SelectedValueChanged
        If Not (tdbcNextOfficialTitleID.Tag Is Nothing OrElse tdbcNextOfficialTitleID.Tag.ToString = "") Then
            tdbcNextOfficialTitleID.Tag = ""
            Exit Sub
        End If
        If tdbcNextOfficialTitleID.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID(tdbcNextSalaryLevelID, "-1", "-1")
            Exit Sub
        End If
        LoadtdbcSalaryLevelID(tdbcNextSalaryLevelID, tdbcNextOfficialTitleID.SelectedValue.ToString, tdbcNextOfficialTitleID.Columns("IsUseOfficial").Text)
        ' update 23/10/2013 id 60852 - Theo chị Thuận, lấy số lẻ trong bảng dtOLSC
        'tdbcNextSalaryLevelID.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcNextSalaryLevelID.Text = ""
        txtNextSalaryCoefficient.Text = ""
    End Sub
#End Region

#Region "Events tdbcNextOfficialTitleID2"

    Private Sub tdbcNextOfficialTitleID2_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNextOfficialTitleID2.Close
        If tdbcNextOfficialTitleID2.FindStringExact(tdbcNextOfficialTitleID2.Text) = -1 Then tdbcNextOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcNextOfficialTitleID2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcNextOfficialTitleID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcNextOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcNextOfficialTitleID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextOfficialTitleID2.SelectedValueChanged
        If Not (tdbcNextOfficialTitleID2.Tag Is Nothing OrElse tdbcNextOfficialTitleID2.Tag.ToString = "") Then
            tdbcNextOfficialTitleID2.Tag = ""
            Exit Sub
        End If
        If tdbcNextOfficialTitleID2.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID(tdbcNextSalaryLevelID2, "-1", "-1")
            Exit Sub
        End If
        LoadtdbcSalaryLevelID(tdbcNextSalaryLevelID2, tdbcNextOfficialTitleID2.SelectedValue.ToString, tdbcNextOfficialTitleID2.Columns("IsUseOfficial").Text)
        ' update 23/10/2013 id 60852 - Theo chị Thuận, lấy số lẻ trong bảng dtOLSC
        '   tdbcNextSalaryLevelID2.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcNextSalaryLevelID2.Text = ""
        txtNextSalaryCoefficient2.Text = ""
    End Sub
#End Region

#Region "Events tdbcSalaryLevelID with txtSalaryCoefficient load tdbcSalaryLevelID2 with txtSalaryCoefficient2"

    Private Sub tdbcSalaryLevelID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID.Close
        If tdbcSalaryLevelID.FindStringExact(tdbcSalaryLevelID.Text) = -1 Then
            tdbcSalaryLevelID.Text = ""
            txtSalaryCoefficient.Text = ""
        End If
    End Sub

    Private Sub tdbcSalaryLevelID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID.SelectedValueChanged
        If tdbcSalaryLevelID.SelectedValue Is Nothing Then Exit Sub
        ' CalculateDateNext(tdbcSalaryLevelID, c1dateOffSa1DateEnd, c1dateOffSa1NextDate)
        If bLoaded Then ' Nếu load xong form mà chọn lại thì mới thực thi
            ' update 30/9/2013 id 58973
            Dim sSQL As String = SQLStoreD13P1039(0)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                c1dateOffSa1DateEnd.Value = dt.Rows(0).Item("OffSa1DateEnd")
                c1dateOffSa1NextDate.Value = dt.Rows(0).Item("OffSa1NextDate")
            End If
        End If

        txtSalaryCoefficient.Text = (SQLNumber(tdbcSalaryLevelID.Columns("SalaryCoefficient").Value.ToString, D13Format.DefaultNumber2)).ToString

        If tdbcNextOfficialTitleID.Text = "" Then
            tdbcNextOfficialTitleID.SelectedValue = tdbcOfficialTitleID.SelectedValue
        End If

        Dim bFlag As Boolean = False
        'Tính bậc lương tiếp theo
        For Each dr As DataRow In CType(tdbcNextSalaryLevelID.DataSource, DataTable).Rows
            If SafeCInt(dr("Grade")) > SafeCInt(tdbcSalaryLevelID.Columns("Grade").Text) Then
                tdbcNextSalaryLevelID.SelectedValue = dr("SalaryLevelID")
                bFlag = True
                Exit For
            End If
        Next
        If bFlag = False Then
            tdbcNextOfficialTitleID.Text = ""
            tdbcNextSalaryLevelID.Text = ""
        End If

        'Lấy HSố lương cho ngạch 1
        txtSaCoefficient.Text = tdbcSalaryLevelID.Columns("SalaryCoefficient").Text
        txtSaCoefficient12.Text = tdbcSalaryLevelID.Columns("SalaryCoefficient02").Text
        txtSaCoefficient13.Text = tdbcSalaryLevelID.Columns("SalaryCoefficient03").Text
        txtSaCoefficient14.Text = tdbcSalaryLevelID.Columns("SalaryCoefficient04").Text
        txtSaCoefficient15.Text = tdbcSalaryLevelID.Columns("SalaryCoefficient05").Text


    End Sub

    Private Sub CalculateDateNext(ByVal tdbcSalary As C1.Win.C1List.C1Combo, ByVal c1DateCtrlEnd As C1.Win.C1Input.C1DateEdit, ByVal c1DateCtrlNext As C1.Win.C1Input.C1DateEdit)
        If c1DateCtrlEnd.ValueIsDbNull Or tdbcSalary.Text = "" Then
            c1DateCtrlNext.Value = Nothing
        Else
            Dim DateNext As Date = CDate(c1DateCtrlEnd.Value)
            DateNext = DateNext.AddMonths(SafeCInt(tdbcSalary.Columns("NumberYearTransfer").Value))
            c1DateCtrlNext.Value = DateNext
        End If
    End Sub
    Private Function SafeCInt(ByVal obj As Object) As Integer
        If obj Is Nothing Or obj.ToString = "" Then
            Return 0
        Else
            Return CInt(obj)
        End If
    End Function
    Private Sub tdbcSalaryLevelID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalaryLevelID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            'tdbcSalaryLevelID.Text = ""
            'txtSalaryCoefficient.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tdbcSalaryLevelID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tdbcSalaryLevelID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            tdbcSalaryLevelID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
            tdbcSalaryLevelID.AutoDropDown = False
        ElseIf e.Alt And (e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5) Then
            tdbcSalaryLevelID.AutoDropDown = False
        End If
    End Sub

    Private Sub tdbcSalaryLevelID2_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID2.Close
        If tdbcSalaryLevelID2.FindStringExact(tdbcSalaryLevelID2.Text) = -1 Then
            tdbcSalaryLevelID2.Text = ""
            txtSalaryCoefficient2.Text = ""
        End If
    End Sub

    Private Sub tdbcSalaryLevelID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID2.SelectedValueChanged
        If tdbcSalaryLevelID2 Is Nothing Then Exit Sub
        txtSalaryCoefficient2.Text = (SQLNumber(tdbcSalaryLevelID2.Columns("SalaryCoefficient").Value.ToString, D13Format.DefaultNumber2)).ToString
        ' CalculateDateNext(tdbcSalaryLevelID2, c1dateOffSa1DateEnd2, c1dateOffSa1NextDate2)' update 30/9/2013 id 58973
        If bLoaded Then ' Nếu load xong form mà chọn lại thì mới thực thi
            Dim sSQL As String = SQLStoreD13P1039(1)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                c1dateOffSa1DateEnd2.Value = dt.Rows(0).Item("OffSa2DateEnd")
                c1dateOffSa1NextDate2.Value = dt.Rows(0).Item("OffSa2NextDate")
            End If
        End If

        If tdbcNextOfficialTitleID2.Text = "" Then
            tdbcNextOfficialTitleID2.SelectedValue = ComboValue(tdbcOfficialTitleID2)
        End If

        Dim bFlag As Boolean = False
        'Tính bậc lương tiếp theo
        For Each dr As DataRow In CType(tdbcNextSalaryLevelID2.DataSource, DataTable).Rows
            If SafeCInt(dr("Grade")) > SafeCInt(tdbcSalaryLevelID2.Columns("Grade").Text) Then
                tdbcNextSalaryLevelID2.SelectedValue = dr("SalaryLevelID")
                bFlag = True
                Exit For
            End If
        Next

        If bFlag = False Then
            tdbcNextOfficialTitleID2.Text = ""
            tdbcNextSalaryLevelID2.Text = ""
        End If
        'Lấy HSố lương cho ngạch 1
        txtSaCoefficient2.Text = tdbcSalaryLevelID2.Columns("SalaryCoefficient").Text
        txtSaCoefficient22.Text = tdbcSalaryLevelID2.Columns("SalaryCoefficient02").Text
        txtSaCoefficient23.Text = tdbcSalaryLevelID2.Columns("SalaryCoefficient03").Text
        txtSaCoefficient24.Text = tdbcSalaryLevelID2.Columns("SalaryCoefficient04").Text
        txtSaCoefficient25.Text = tdbcSalaryLevelID2.Columns("SalaryCoefficient05").Text

    End Sub

    Private Sub tdbcSalaryLevelID2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalaryLevelID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcSalaryLevelID2.Text = ""
        '    txtSalaryCoefficient2.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcNextSalaryLevelID with txtNextSalaryCoefficient load tdbcNextSalaryLevelID2 with txtNextSalaryCoefficient2"

    Private Sub tdbcNextSalaryLevelID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextSalaryLevelID.Close
        If tdbcNextSalaryLevelID.FindStringExact(tdbcNextSalaryLevelID.Text) = -1 Then
            tdbcNextSalaryLevelID.Text = ""
            txtNextSalaryCoefficient.Text = ""
        End If
    End Sub

    Private Sub tdbcNextSalaryLevelID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextSalaryLevelID.SelectedValueChanged
        txtNextSalaryCoefficient.Text = (SQLNumber(tdbcNextSalaryLevelID.Columns("SalaryCoefficient").Value.ToString, D13Format.DefaultNumber2)).ToString

    End Sub

    Private Sub tdbcNextSalaryLevelID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcNextSalaryLevelID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcNextSalaryLevelID.Text = ""
        '    txtNextSalaryCoefficient.Text = ""
        'End If
    End Sub

    Private Sub tdbcNextSalaryLevelID2_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextSalaryLevelID2.Close
        If tdbcNextSalaryLevelID2.FindStringExact(tdbcNextSalaryLevelID2.Text) = -1 Then
            tdbcNextSalaryLevelID2.Text = ""
            txtNextSalaryCoefficient2.Text = ""
        End If
    End Sub

    Private Sub tdbcNextSalaryLevelID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNextSalaryLevelID2.SelectedValueChanged
        txtNextSalaryCoefficient2.Text = (SQLNumber(tdbcNextSalaryLevelID2.Columns("SalaryCoefficient").Value.ToString, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub tdbcNextSalaryLevelID2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcNextSalaryLevelID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcNextSalaryLevelID2.Text = ""
        '    txtNextSalaryCoefficient2.Text = ""
        'End If
    End Sub
#End Region

    Private Sub c1dateOffSa1DateEnd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateOffSa1DateEnd.TextChanged
        '  CalculateDateNext(tdbcSalaryLevelID, c1dateOffSa1DateEnd, c1dateOffSa1NextDate)
    End Sub

    Private Sub c1dateOffSa1DateEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateOffSa1DateEnd.ValueChanged
        If c1dateOffSa1DateEnd.Tag IsNot Nothing AndAlso c1dateOffSa1DateEnd.Tag.ToString = c1dateOffSa1DateEnd.Text Then Exit Sub
        c1dateOffSa1DateEnd.Tag = c1dateOffSa1DateEnd.Text
        ' CalculateDateNext(tdbcSalaryLevelID, c1dateOffSa1DateEnd, c1dateOffSa1NextDate)
        If bLoaded Then ' Nếu load xong form mà chọn lại thì mới thực thi
            ' update 30/9/2013 id 58973
            Dim sSQL As String = SQLStoreD13P1039(0)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                c1dateOffSa1NextDate.Value = dt.Rows(0).Item("OffSa1NextDate")
            End If
        End If
    End Sub

    Private Sub c1dateOffSa1DateEnd2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateOffSa1DateEnd2.TextChanged
        'CalculateDateNext(tdbcSalaryLevelID2, c1dateOffSa1DateEnd2, c1dateOffSa1NextDate2)
    End Sub

    Private Sub c1dateOffSa1DateEnd2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateOffSa1DateEnd2.ValueChanged
        If c1dateOffSa1DateEnd2.Tag IsNot Nothing AndAlso c1dateOffSa1DateEnd2.Tag.ToString = c1dateOffSa1DateEnd2.Text Then Exit Sub

        c1dateOffSa1DateEnd2.Tag = c1dateOffSa1DateEnd2.Text
        If bLoaded Then ' Nếu load xong form mà chọn lại thì mới thực thi
            '     CalculateDateNext(tdbcSalaryLevelID2, c1dateOffSa1DateEnd2, c1dateOffSa1NextDate2)
            ' update 30/9/2013 id 58973
            Dim sSQL As String = SQLStoreD13P1039(1)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                c1dateOffSa1NextDate2.Value = dt.Rows(0).Item("OffSa2DateEnd")
            End If
        End If
    End Sub

    Private Function ReturnControl(ByVal grpCtrl As Control, ByVal ID As String) As Control
        For Each ctrl As Control In grpCtrl.Controls
            If ctrl.Name = ID Then
                Return ctrl
            End If
        Next
        D99C0008.Msg("Không tồn tại Control " & ID)
        Return Nothing
    End Function

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_PAnaID
                LoadtdbdPAnaID(tdbg.Columns(COL_PAnaCategoryID).Text)
        End Select
    End Sub

    Private Sub LoadtdbdPAnaID(ByVal ID As String)
        LoadDataSource(tdbdPAnaID, ReturnTableFilter(dtPCode, " PAnaCategoryID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_PAnaID
                If tdbg.Columns(COL_PAnaID).Text <> tdbdPAnaID.Columns(0).Text Then
                    tdbg.Columns(COL_PAnaID).Text = ""
                    tdbg.Columns(COL_PAnaName).Text = ""
                    tdbg.Columns(COL_Amount01).Text = ""
                    tdbg.Columns(COL_Amount02).Text = ""
                    tdbg.Columns(COL_Amount03).Text = ""
                    tdbg.Columns(COL_Amount04).Text = ""
                    tdbg.Columns(COL_Amount05).Text = ""
                    tdbg.Columns(COL_Amount06).Text = ""
                    tdbg.Columns(COL_Amount07).Text = ""
                    tdbg.Columns(COL_Amount08).Text = ""
                    tdbg.Columns(COL_Amount09).Text = ""
                    tdbg.Columns(COL_Amount10).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_PAnaID
                tdbg.Columns(COL_PAnaID).Text = tdbdPAnaID.Columns.Item("PAnaID").Text
                tdbg.Columns(COL_PAnaName).Text = tdbdPAnaID.Columns.Item("PAnaName").Text
                tdbg.Columns(COL_Amount01).Text = tdbdPAnaID.Columns.Item("Amount01").Text
                tdbg.Columns(COL_Amount02).Text = tdbdPAnaID.Columns.Item("Amount02").Text
                tdbg.Columns(COL_Amount03).Text = tdbdPAnaID.Columns.Item("Amount03").Text
                tdbg.Columns(COL_Amount04).Text = tdbdPAnaID.Columns.Item("Amount04").Text
                tdbg.Columns(COL_Amount05).Text = tdbdPAnaID.Columns.Item("Amount05").Text
                tdbg.Columns(COL_Amount06).Text = tdbdPAnaID.Columns.Item("Amount06").Text
                tdbg.Columns(COL_Amount07).Text = tdbdPAnaID.Columns.Item("Amount07").Text
                tdbg.Columns(COL_Amount08).Text = tdbdPAnaID.Columns.Item("Amount08").Text
                tdbg.Columns(COL_Amount09).Text = tdbdPAnaID.Columns.Item("Amount09").Text
                tdbg.Columns(COL_Amount10).Text = tdbdPAnaID.Columns.Item("Amount10").Text
        End Select
    End Sub

    Private Sub tdbg_LockedColumns()
        Dim i As Integer
        For i = COL_PAnaCategoryID To COL_PAnaCategoryName01
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(i).Locked = True
        Next
        For i = COL_PAnaName To COL_Amount10
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(i).Locked = True
        Next
    End Sub

    Private Sub tdbgRelative_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.AfterColUpdate
        Select Case e.ColIndex
            Case COL1_RelationName
                If bNotInList Then
                    bNotInList = False
                    tdbgRelative.Columns(COL1_RelationID).Text = ""
                    tdbgRelative.Columns(COL1_RelationName).Text = ""
                End If
            Case COL1_DeductibleDateBegin, COL1_DeductibleDateEnd
                If tdbgRelative.Columns(e.ColIndex).Text <> "  /  /" Then
                    tdbgRelative.Columns(e.ColIndex).Value = tdbgRelative.Columns(e.ColIndex).Text
                End If
        End Select
        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumns)
    End Sub

    Private Sub tdbgRelative_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgRelative.AfterDelete
        FooterTotalGrid(tdbgRelative, COL1_RelativeName)
        FooterSum(tdbgRelative, iColumns)
    End Sub

    Private Sub tdbgRelative_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgRelative.RowColChange
        Select Case tdbgRelative.Col
            Case COL1_RelativeName
                LoadtdbdRelativeName(tdbgRelative.Columns(COL1_RelationID).Text)
        End Select
    End Sub

    Private Sub tdbgRelative_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgRelative.BeforeColUpdate
        Select Case e.ColIndex
            Case COL1_RelationName
                If tdbgRelative.Columns(COL1_RelationName).Text <> tdbdRelationID.Columns("RelationName").Text Then
                    bNotInList = True
                    tdbgRelative.Columns(COL1_RelationID).Text = ""
                    tdbgRelative.Columns(COL1_RelationName).Text = ""
                End If
            Case COL1_RelativeName

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
            Case COL1_DeductibleDateBegin, COL1_DeductibleDateEnd
                tdbgRelative.Columns(e.ColIndex).Text = L3DateValue(tdbgRelative.Columns(e.ColIndex).Text)
            Case COL1_InComeTaxCode, COL1_IDCardNo
                e.Cancel = L3IsID(tdbgRelative, e.ColIndex)
        End Select
    End Sub

    Private Sub tdbgRelative_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRelative.ComboSelect
        Select Case e.ColIndex
            Case COL1_RelationName
                'tdbgRelative.Columns(COL1_RelationName).Text = tdbdRelationID.Columns("RelationName").Text
                tdbgRelative.Columns(COL1_RelationID).Text = tdbdRelationID.Columns("RelationID").Text

                LoadtdbdRelativeName(tdbgRelative.Columns(COL1_RelationID).Text)

                If tdbdRelativeName.Columns("RelativeName").Text <> "" Then
                    tdbgRelative.Columns(COL1_RelativeName).Text = tdbdRelativeName.Columns("RelativeName").Text
                End If
                If tdbdRelativeName.Columns("BirthDate").Text <> "" Then
                    tdbgRelative.Columns(COL1_BirthDate).Text = tdbdRelativeName.Columns("BirthDate").Text
                End If
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
                tdbgRelative.Columns(COL1_BirthDate).Text = tdbdRelativeName.Columns("BirthDate").Text
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
        'Select Case tdbgRelative.Col
        '    Case COL1_RelationName
        '        Select Case e.KeyCode
        '            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
        '                tdbgRelative.Splits(SPLIT0).DisplayColumns(tdbgRelative.Col).AutoComplete = False
        '            Case Else
        '                tdbgRelative.Splits(SPLIT0).DisplayColumns(tdbgRelative.Col).AutoComplete = True
        '        End Select
        'End Select

        Try
            If e.KeyCode = Keys.Enter And tdbgRelative.Col = COL1_Note Then
                HotKeyEnterGrid(tdbgRelative, 0, e)
            ElseIf e.KeyCode = Keys.F8 Then
                HotKeyF8(tdbgRelative)
                FooterTotalGrid(tdbgRelative, COL1_RelativeName)
                FooterSum(tdbgRelative, iColumns)
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
                FooterSum(tdbgRelative, iColumns)
                Exit Sub
            End If
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub tdbgRelative_NumberFormat()
        tdbgRelative.Columns(COL1_Salary).NumberFormat = D13Format.DefaultNumber2
        'tdbgRelative.Columns(COL1_DeductibleAmount).NumberFormat = D13Format.DefaultNumber2
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1032
    '# Created User: DUCTRONG
    '# Created Date: 12/06/2008 05:00:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1032() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1032 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(EmployeeID) & COMMA  'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
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
        sSQL &= "Delete From D13T0216"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(_employeeID)
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

        For i As Integer = 0 To tdbgRelative.RowCount - 1
            If tdbgRelative(i, COL1_RelativeID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbgRelative.RowCount - 1

            If tdbgRelative(i, COL1_RelativeID).ToString = "" Then
                sRelativeID = CreateIGEs("D13T0216", "RelativeID", "13", "DE", gsStringKey, sRelativeID, iCountIGE)
                tdbgRelative(i, COL1_RelativeID) = sRelativeID
            End If

            sSQL.Append("Insert Into D13T0216(")
            sSQL.Append("RelativeID, EmployeeID, RelationID, RelationName, RelationNameU, RelativeName, RelativeNameU, BirthDate, ")
            sSQL.Append("BirthPlace, BirthPlaceU, Address, AddressU, Occupation, OccupationU, EducationLevelID, Sex, InComeTaxCode, IDCardNo, ")
            sSQL.Append("Salary, DeductibleDateBegin, DeductibleDateEnd, DeductibleAmount, Disabled, ")
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, ")
            sSQL.Append("Note, NoteU, BirthCertificate, ")
            sSQL.Append("ResidentCertificate, MarriageCertificate, SchoolConfirmation, DisabilityConfirmation, BringUpConfirmation, ")
            sSQL.Append("OtherConfirmations, NoteConfirmation, NoteConfirmationU, ExamineDate")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbgRelative(i, COL1_RelativeID)) & COMMA) 'RelativeID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_employeeID) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgRelative(i, COL1_RelationID)) & COMMA) 'RelationID, varchar[20], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_RelationName).ToString, gbUnicode, False) & COMMA) 'RelationName, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_RelationName).ToString, gbUnicode, True) & COMMA) 'RelationName, varchar[50], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_RelativeName).ToString, gbUnicode, False) & COMMA) 'RelativeName, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_RelativeName).ToString, gbUnicode, True) & COMMA) 'RelativeName, varchar[50], NOT NULL

            sSQL.Append(SQLString(tdbgRelative(i, COL1_BirthDate)) & COMMA) 'BirthDate, datetime, NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_BirthPlace).ToString, gbUnicode, False) & COMMA) 'BirthPlace, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_BirthPlace).ToString, gbUnicode, True) & COMMA) 'BirthPlace, varchar[250], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Address).ToString, gbUnicode, False) & COMMA) 'Address, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Address).ToString, gbUnicode, True) & COMMA) 'Address, varchar[250], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Occupation).ToString, gbUnicode, False) & COMMA) 'Occupation, varchar[100], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Occupation).ToString, gbUnicode, True) & COMMA) 'Occupation, varchar[100], NOT NULL

            sSQL.Append(SQLString(tdbgRelative(i, COL1_EducationLevelID)) & COMMA) 'EducationLevelID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_Sex)) & COMMA) 'Sex, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbgRelative(i, COL1_InComeTaxCode)) & COMMA) 'IncomeTaxCode, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbgRelative(i, COL1_IDCardNo)) & COMMA) 'IDCardNo, varchar[50], NOT NULL
            sSQL.Append(SQLMoney(tdbgRelative(i, COL1_Salary), D13Format.DefaultNumber2) & COMMA) 'Salary, money, NOT NULL
            sSQL.Append(SQLDateSave(tdbgRelative(i, COL1_DeductibleDateBegin)) & COMMA) 'DeductibleDateBegin, datetime, NULL
            sSQL.Append(SQLDateSave(tdbgRelative(i, COL1_DeductibleDateEnd)) & COMMA) 'DeductibleDateEnd, datetime, NULL
            sSQL.Append(SQLMoney(tdbgRelative(i, COL1_DeductibleAmount), D13Format.DefaultNumber2) & COMMA) 'DeductibleAmount, money, NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL

            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Note), gbUnicode, False) & COMMA) 'Note, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_Note), gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_BirthCertificate)) & COMMA) 'BirthCertificate, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_ResidentCertificate)) & COMMA) 'ResidentCertificate, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_MarriageCertificate)) & COMMA) 'MarriageCertificate, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_SchoolConfirmation)) & COMMA) 'SchoolConfirmation, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_DisabilityConfirmation)) & COMMA) 'DisabilityConfirmation, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_BringUpConfirmation)) & COMMA) 'BringUpConfirmation, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbgRelative(i, COL1_OtherConfirmations)) & COMMA) 'OtherConfirmations, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_NoteConfirmation), gbUnicode, False) & COMMA) 'NoteConfirmation, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgRelative(i, COL1_NoteConfirmation), gbUnicode, True) & COMMA) 'NoteConfirmationU, nvarchar, NOT NULL
            sSQL.Append(SQLDateSave(tdbgRelative(i, COL1_ExamineDate))) ' update 9/9/2013 id 56751
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD21T2010
    '# Created User: DUCTRONG
    '# Created Date: 22/05/2009 10:32:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD21T2010() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D21T2010"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(txtEmployeeID.Text) & " And "
        sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
        sSQL &= "TranYear = " & SQLNumber(giTranYear)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD21P2001
    '# Created User: DUCTRONG
    '# Created Date: 22/05/2009 10:23:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD21P2001() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D21P2001 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Dim bBA As SALBA
    Dim bCE As SALCE


    Private Sub GetCaptionSalBase(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Split As Integer, ByVal colFrom As Integer)
        Dim iCol As Integer = colFrom 'COL_BaseSalary01
        If dtSALBA.Rows.Count > 0 Then
            For i As Integer = 0 To dtSALBA.Rows.Count - 1
                C1Grid.Splits(Split).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                C1Grid.Columns(iCol).Caption = dtSALBA.Rows(i).Item("Short").ToString
                iCol += 1
            Next
        End If

    End Sub

    Private Sub GetCaptionSalCoeff(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Split As Integer, ByVal colFrom As Integer)
        Dim iCol As Integer = colFrom 'COL_SalCoefficient01

        If dtSALCE.Rows.Count > 0 Then
            For i As Integer = 0 To dtSALCE.Rows.Count - 1
                C1Grid.Splits(Split).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                C1Grid.Columns(iCol).Caption = dtSALCE.Rows(i).Item("Short").ToString
                iCol += 1
            Next
        End If


    End Sub

    Private Enum Button
        SalCoeff
        OfficalSalLevel
    End Enum

    Dim OT As OLSC

    Private Sub ClickButton_H1(ByVal button As Button)

        btnSal.Enabled = Math.Abs(button - button.SalCoeff) > 0
        btnOfficialTitle.Enabled = Math.Abs(button - button.OfficalSalLevel) > 0

        ' Thông tin điều chuyển lương
        With tdbgH1.Splits(1)
            For i As Integer = 0 To 3
                .DisplayColumns(COLH1_BaseSalary01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And BA(i)
            Next i

            For i As Integer = 0 To 19
                .DisplayColumns(COLH1_SalCoefficient01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And CE(i)
            Next i


            .DisplayColumns(COLH1_OfficalTitleID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID
            .DisplayColumns(COLH1_SalaryLevelID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID
            .DisplayColumns(COLH1_SaCoefficient).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient
            .DisplayColumns(COLH1_SaCoefficient12).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient12
            .DisplayColumns(COLH1_SaCoefficient13).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient13
            .DisplayColumns(COLH1_SaCoefficient14).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient14
            .DisplayColumns(COLH1_SaCoefficient15).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient15

            .DisplayColumns(COLH1_OfficalTitleID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID2
            .DisplayColumns(COLH1_SalaryLevelID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID2
            .DisplayColumns(COLH1_SaCoefficient2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient2
            .DisplayColumns(COLH1_SaCoefficient22).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient22
            .DisplayColumns(COLH1_SaCoefficient23).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient23
            .DisplayColumns(COLH1_SaCoefficient24).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient24
            .DisplayColumns(COLH1_SaCoefficient25).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient25




            For i As Integer = COLH1_BaseSalary01 To COLH1_SaCoefficient25
                If tdbgH1.Splits(1).DisplayColumns(i).Visible Then
                    tdbgH1.Focus()
                    tdbgH1.Col = i
                    tdbgH1.SplitIndex = 1
                    tdbgH1.Row = tdbg.Row
                    'tdbgH1.Focus()
                    Exit For
                End If
            Next i


        End With

        iLastCol1 = CountCol(tdbgH1, SPLIT1)
    End Sub

    Private Sub ClickButton_H2(ByVal button As Button)

        btnSal2.Enabled = Math.Abs(button - button.SalCoeff) > 0
        btnOfficialTitle2.Enabled = Math.Abs(button - button.OfficalSalLevel) > 0

        ' Thông tin điều chuyển lương
        With tdbgH2.Splits(1)
            For i As Integer = 0 To 3
                .DisplayColumns(COLH2_BaseSalary01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And BA(i)
            Next i

            For i As Integer = 0 To 19
                .DisplayColumns(COLH2_SalCoefficient01 + i).Visible = Math.Abs(button - button.SalCoeff) = 0 And CE(i)
            Next i

            .DisplayColumns(COLH2_OfficalTitleID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID
            .DisplayColumns(COLH2_SalaryLevelID).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID
            .DisplayColumns(COLH2_SaCoefficient).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient
            .DisplayColumns(COLH2_SaCoefficient12).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient12
            .DisplayColumns(COLH2_SaCoefficient13).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient13
            .DisplayColumns(COLH2_SaCoefficient14).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient14
            .DisplayColumns(COLH2_SaCoefficient15).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient15

            .DisplayColumns(COLH2_OfficalTitleID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.OfficialTitleID2
            .DisplayColumns(COLH2_SalaryLevelID2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SalaryLevelID2
            .DisplayColumns(COLH2_SaCoefficient2).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient2
            .DisplayColumns(COLH2_SaCoefficient22).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient22
            .DisplayColumns(COLH2_SaCoefficient23).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient23
            .DisplayColumns(COLH2_SaCoefficient24).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient24
            .DisplayColumns(COLH2_SaCoefficient25).Visible = Math.Abs(button - button.OfficalSalLevel) = 0 And OT.SaCoefficient25


            For i As Integer = COLH2_BaseSalary01 To COLH2_SaCoefficient25
                If tdbgH2.Splits(1).DisplayColumns(i).Visible Then
                    tdbgH2.Col = i
                    tdbgH2.SplitIndex = 1
                    tdbgH2.Row = tdbg.Row
                    'tdbgH2.Focus()
                    Exit For
                End If
            Next i


        End With

        iLastCol2 = CountCol(tdbgH2, SPLIT1)
    End Sub

    Private Sub btnSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSal.Click
        tdbgH1.Splits(SPLIT1).Caption = rl3("Muc_luong_He_so")
        ClickButton_H1(Button.SalCoeff)
    End Sub

    Private Sub btnOfficialTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOfficialTitle.Click
        tdbgH1.Splits(SPLIT1).Caption = rl3("Ngach_bac_luong")
        ClickButton_H1(Button.OfficalSalLevel)
    End Sub

    Private Sub btnSal2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSal2.Click
        tdbgH2.Splits(SPLIT1).Caption = rl3("Muc_luong_He_so")
        ClickButton_H2(Button.SalCoeff)
    End Sub

    Private Sub btnOfficialTitle2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOfficialTitle2.Click
        tdbgH2.Splits(SPLIT1).Caption = rl3("Ngach_bac_luong")
        ClickButton_H2(Button.OfficalSalLevel)
    End Sub

    Private Sub LoadtdbdSalaryLevelID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal ID As String)
        LoadDataSource(tdbd, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub tdbgH1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgH1.AfterColUpdate
        Select Case e.ColIndex
            Case COLH1_FromMonthYear, COLH1_ToMonthYear
                If tdbgH1.Columns(COLH1_FromMonthYear).Text <> "" And tdbgH1.Columns(COLH1_ToMonthYear).Text <> "" Then
                    Dim d1 As Date = CDate(tdbgH1.Columns(COLH1_FromMonthYear).Text)
                    Dim d2 As Date = CDate(tdbgH1.Columns(COLH1_ToMonthYear).Text)
                    tdbgH1.Columns(COLH1_MonthTotal).Text = (DateDiff(DateInterval.Month, d1, d2) + 1).ToString
                Else
                    tdbgH1.Columns(COLH1_MonthTotal).Text = ""
                End If

                'Case COLH1_FromMonthYear, COLH1_ToMonthYear
                '    tdbgH1.Select()
        End Select
    End Sub

    Private Sub tdbgH1H1_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgH1.BeforeColUpdate
        Select Case e.ColIndex
            Case COLH1_FromMonthYear, COLH1_ToMonthYear
                If tdbgH1.Columns(COLH1_FromMonthYear).Text <> "" And tdbgH1.Columns(COLH1_ToMonthYear).Text <> "" Then
                    Dim d1 As Date = CDate(tdbgH1.Columns(COLH1_FromMonthYear).Text)
                    Dim d2 As Date = CDate(tdbgH1.Columns(COLH1_ToMonthYear).Text)
                    If d1 > d2 Then
                        tdbgH1.Columns(e.ColIndex).Text = ""
                    End If
                End If

                'Case COLH1_BaseSalary01 To COLH1_SalCoefficient10
                '    If Not L3IsNumeric(tdbgH1.Columns(e.ColIndex).Text) Then e.Cancel = True

            Case COLH1_OfficalTitleID
                If tdbgH1.Columns(COLH1_OfficalTitleID).Text <> tdbdOfficialTitleID.Columns("OfficialTitleID").Text Then
                    tdbgH1.Columns(COLH1_OfficalTitleID).Text = ""
                    tdbgH1.Columns(COLH1_SalaryLevelID).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient12).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient13).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient14).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient15).Text = ""
                End If

            Case COLH1_SalaryLevelID
                If tdbgH1.Columns(COLH1_SalaryLevelID).Text <> tdbdSalaryLevelID.Columns("SalaryLevelID").Text Then
                    tdbgH1.Columns(COLH1_SalaryLevelID).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient12).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient13).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient14).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient15).Text = ""
                End If

            Case COLH1_OfficalTitleID2
                If tdbgH1.Columns(COLH1_OfficalTitleID2).Text <> tdbdOfficialTitleID2.Columns("OfficialTitleID").Text Then
                    tdbgH1.Columns(COLH1_OfficalTitleID2).Text = ""
                    tdbgH1.Columns(COLH1_SalaryLevelID2).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient2).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient22).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient23).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient24).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient25).Text = ""
                End If

            Case COLH1_SalaryLevelID2
                If tdbgH1.Columns(COLH1_SalaryLevelID2).Text <> tdbdSalaryLevelID2.Columns("SalaryLevelID").Text Then
                    tdbgH1.Columns(COLH1_SalaryLevelID2).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient2).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient22).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient23).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient24).Text = ""
                    tdbgH1.Columns(COLH1_SaCoefficient25).Text = ""
                End If

        End Select
    End Sub

    Private Sub tdbgH1H1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgH1.ComboSelect
        Select Case e.ColIndex
            Case COLH1_OfficalTitleID
                tdbgH1.Columns(COLH1_SalaryLevelID).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient12).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient13).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient14).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient15).Text = ""

            Case COLH1_OfficalTitleID2
                tdbgH1.Columns(COLH1_SalaryLevelID2).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient2).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient22).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient23).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient24).Text = ""
                tdbgH1.Columns(COLH1_SaCoefficient25).Text = ""


            Case COLH1_SalaryLevelID
                tdbgH1.Columns(COLH1_SaCoefficient).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient").Text
                tdbgH1.Columns(COLH1_SaCoefficient12).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient02").Text
                tdbgH1.Columns(COLH1_SaCoefficient13).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient03").Text
                tdbgH1.Columns(COLH1_SaCoefficient14).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient04").Text
                tdbgH1.Columns(COLH1_SaCoefficient15).Text = tdbdSalaryLevelID.Columns("SalaryCoefficient05").Text


            Case COLH1_SalaryLevelID2
                tdbgH1.Columns(COLH1_SaCoefficient2).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient").Text
                tdbgH1.Columns(COLH1_SaCoefficient22).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient02").Text
                tdbgH1.Columns(COLH1_SaCoefficient23).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient03").Text
                tdbgH1.Columns(COLH1_SaCoefficient24).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient04").Text
                tdbgH1.Columns(COLH1_SaCoefficient25).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient05").Text

                '***
        End Select
    End Sub

    'Private Sub tdbgH1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgH1.KeyPress
    '    Select Case tdbgH1.Col
    '        Case COLH1_BaseSalary01 To COLH1_SalCoefficient10
    '            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    '    End Select
    'End Sub

    Private Sub tdbgH1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgH1.RowColChange
        Select Case tdbgH1.Col

            Case COLH1_SalaryLevelID
                LoadtdbdSalaryLevelID(tdbdSalaryLevelID, tdbgH1.Columns(COLH1_OfficalTitleID).Text)

            Case COLH1_SalaryLevelID2
                LoadtdbdSalaryLevelID(tdbdSalaryLevelID2, tdbgH1.Columns(COLH1_OfficalTitleID2).Text)

        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2100
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/10/2009 11:46:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2100() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2100"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(_employeeID)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2100s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/10/2009 11:46:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2100s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim iCountIGE As Int32 = 0
        Dim sTransID As String = ""

        For i As Integer = 0 To tdbgH1.RowCount - 1
            If tdbgH1(i, COLH1_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbgH1.RowCount - 1
            sSQL.Append("Insert Into D13T2100(")
            sSQL.Append("EmployeeID, TransID, FromMonthYear, ToMonthYear, MonthTotal, ")
            sSQL.Append("OldDivision, OldDivisionU, OldDutyName, OldDutyNameU, Note, NoteU, BaseSalary01, BaseSalary02, ")
            sSQL.Append("BaseSalary03, BaseSalary04, SalCoefficient01, SalCoefficient02, SalCoefficient03, ")
            sSQL.Append("SalCoefficient04, SalCoefficient05, SalCoefficient06, SalCoefficient07, SalCoefficient08, ")
            sSQL.Append("SalCoefficient09, SalCoefficient10, ")
            sSQL.Append("SalCoefficient11, SalCoefficient12, SalCoefficient13, SalCoefficient14, SalCoefficient15, ")
            sSQL.Append("SalCoefficient16, SalCoefficient17, SalCoefficient18, SalCoefficient19, SalCoefficient20, ")
            sSQL.Append(" OfficalTitleID, SalaryLevelID, SaCoefficient, ")
            sSQL.Append("SaCoefficient12, SaCoefficient13, SaCoefficient14, SaCoefficient15, OfficalTitleID2, ")
            sSQL.Append("SalaryLevelID2, SaCoefficient2, SaCoefficient22, SaCoefficient23, SaCoefficient24, ")
            sSQL.Append("SaCoefficient25")
            sSQL.Append(") Values(")

            If tdbgH1(i, COLH1_TransID).ToString = "" Then
                sTransID = CreateIGEs("D13T2100", "TransID", "13", "HS", gsStringKey, sTransID, iCountIGE)
                tdbgH1(i, COLH1_TransID) = sTransID
            End If

            sSQL.Append(SQLString(_employeeID) & COMMA) 'EmployeeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbgH1(i, COLH1_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbgH1(i, COLH1_FromMonthYear)) & COMMA) 'FromMonthYear, datetime, NULL
            sSQL.Append(SQLDateSave(tdbgH1(i, COLH1_ToMonthYear)) & COMMA) 'ToMonthYear, datetime, NULL
            sSQL.Append(SQLNumber(tdbgH1(i, COLH1_MonthTotal)) & COMMA) 'MonthTotal, int, NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_OldDivision).ToString, gbUnicode, False) & COMMA) 'OldDivision, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_OldDivision).ToString, gbUnicode, True) & COMMA) 'OldDivision, varchar[500], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_OldDutyName).ToString, gbUnicode, False) & COMMA) 'OldDutyName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_OldDutyName).ToString, gbUnicode, True) & COMMA) 'OldDutyName, varchar[250], NOT NULL

            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_Note).ToString, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgH1(i, COLH1_Note).ToString, gbUnicode, True) & COMMA) 'Note, varchar[500], NOT NULL

            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_BaseSalary01)) & COMMA) 'BaseSalary01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_BaseSalary02)) & COMMA) 'BaseSalary02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_BaseSalary03)) & COMMA) 'BaseSalary03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_BaseSalary04)) & COMMA) 'BaseSalary04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient01)) & COMMA) 'SalCoefficient01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient02)) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient03)) & COMMA) 'SalCoefficient03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient04)) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient05)) & COMMA) 'SalCoefficient05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient06)) & COMMA) 'SalCoefficient06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient07)) & COMMA) 'SalCoefficient07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient08)) & COMMA) 'SalCoefficient08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient09)) & COMMA) 'SalCoefficient09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient10)) & COMMA) 'SalCoefficient10, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient11)) & COMMA) 'SalCoefficient11, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient12)) & COMMA) 'SalCoefficient12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient13)) & COMMA) 'SalCoefficient13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient14)) & COMMA) 'SalCoefficient14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient15)) & COMMA) 'SalCoefficient15, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient16)) & COMMA) 'SalCoefficient16, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient17)) & COMMA) 'SalCoefficient17, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient18)) & COMMA) 'SalCoefficient18, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient19)) & COMMA) 'SalCoefficient19, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SalCoefficient20)) & COMMA) 'SalCoefficient20, decimal, NOT NULL

            sSQL.Append(SQLString(tdbgH1(i, COLH1_OfficalTitleID)) & COMMA) 'OfficalTitleID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgH1(i, COLH1_SalaryLevelID)) & COMMA) 'SalaryLevelID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient)) & COMMA) 'SaCoefficient, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient12)) & COMMA) 'SaCoefficient12, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient13)) & COMMA) 'SaCoefficient13, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient14)) & COMMA) 'SaCoefficient14, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient15)) & COMMA) 'SaCoefficient15, decimal, NOT NULL
            sSQL.Append(SQLString(tdbgH1(i, COLH1_OfficalTitleID2)) & COMMA) 'OfficalTitleID2, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgH1(i, COLH1_SalaryLevelID2)) & COMMA) 'SalaryLevelID2, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient2)) & COMMA) 'SaCoefficient2, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient22)) & COMMA) 'SaCoefficient22, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient23)) & COMMA) 'SaCoefficient23, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient24)) & COMMA) 'SaCoefficient24, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgH1(i, COLH1_SaCoefficient25))) 'SaCoefficient25, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet

    End Function


#Region "Events tdbcSalaryObjectID with txtSalaryObjectName"

    Private Sub tdbcSalaryObjectID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryObjectID.Close
        If tdbcSalaryObjectID.Columns(0).Text = "+" Or tdbcSalaryObjectID.Columns(1).Text = "<Add new>" Then
            If ReturnPermission("D13F1140") < EnumPermission.Add Then
                D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
            Else
                Dim sKey As String = ""
                Dim f As New D13F1141
                With f
                    .FormState = EnumFormState.FormAdd
                    .ShowDialog()
                    sKey = f.SalaryObjectID
                    If .bSaved Then
                        LoadTDBCSalaryObjectID()
                        tdbcSalaryObjectID.SelectedValue = sKey
                        _bSaved = False ' .bSaved = False
                    Else
                        tdbcSalaryObjectID.SelectedValue = ""
                    End If
                    .Dispose()
                End With
              
            End If
            tdbcSalaryObjectID.Focus()
        End If
    End Sub

    Private Sub tdbcSalaryObjectID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalaryObjectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbcSalaryObjectID.Text = "+" Then
                If ReturnPermission("D13F1140") < EnumPermission.Add Then
                    D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                Else
                    Dim sKey As String = ""
                    Dim f As New D13F1141
                    With f
                        .FormState = EnumFormState.FormAdd
                        .ShowDialog()
                        sKey = f.SalaryObjectID
                        If .bSaved Then
                            LoadTDBCSalaryObjectID()
                            tdbcSalaryObjectID.SelectedValue = sKey
                            _bSaved = False '  .bSaved = False
                        Else
                            tdbcSalaryObjectID.SelectedValue = ""
                        End If
                        .Dispose()
                    End With
                    
                End If
                tdbcSalaryObjectID.Focus()
            End If
        End If
    End Sub

    Private Sub tdbcSalaryObjectID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryObjectID.SelectedValueChanged
        If tdbcSalaryObjectID.SelectedValue Is Nothing Then
            txtSalaryObjectName.Text = ""
            Exit Sub
        Else
            txtSalaryObjectName.Text = tdbcSalaryObjectID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcSalaryObjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryObjectID.LostFocus
        If tdbcSalaryObjectID.FindStringExact(tdbcSalaryObjectID.Text) = -1 Then
            tdbcSalaryObjectID.Text = ""
        End If
    End Sub

#End Region

    '**********ĐẶC THÙ CỦA FORM************
    Private Function ReturnDataTable_1(ByVal SQL As String) As DataTable
        Dim ds As DataSet = ReturnDataSet_1(SQL)
        If ds Is Nothing Then Return Nothing
        Return ds.Tables(0)
    End Function

    Private Function ReturnDataSet_1(ByVal SQL As String) As DataSet
        Dim ds As DataSet = New DataSet()

        Dim conn As SqlConnection = New SqlConnection(gsConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Try
            conn.Open()
            cmd.CommandTimeout = 0
            da.Fill(ds)
            conn.Close()
            Return ds
        Catch
            conn.Close()
            Clipboard.Clear()
            Clipboard.SetText(SQL)
            'MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
            MsgErr(rl3("Thuc_thi_khong_thanh_cong_Ban_vui_long_kiem_tra_lai_cong_thuc"))
            Return Nothing
        End Try

    End Function
    '**********ĐẶC THÙ CỦA FORM************

    Private Sub btnAutoCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoCal.Click
        If tdbcSalaryObjectID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Doi_tuong_tinh_luong"))
            tabMain.SelectedTab = TabPage2
            tdbcSalaryObjectID.Focus()
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL &= SQLInsertD13T1030().ToString
        sSQL &= SQLStoreD13P1033()

        Dim dt As DataTable = ReturnDataTable_1(sSQL)
        If dt Is Nothing Then
            Exit Sub
        End If
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            If dr("Status").ToString = "0" Then
                tdbcSalaryObjectID.SelectedValue = dr("SalaryObjectID")
                txtBaseSalary01.Text = dr("BaseSalary01").ToString
                txtBaseSalary02.Text = dr("BaseSalary02").ToString
                txtBaseSalary03.Text = dr("BaseSalary03").ToString
                txtBaseSalary04.Text = dr("BaseSalary04").ToString

                txtSalCoefficient01.Text = dr("SalCoefficient01").ToString
                txtSalCoefficient02.Text = dr("SalCoefficient02").ToString
                txtSalCoefficient03.Text = dr("SalCoefficient03").ToString
                txtSalCoefficient04.Text = dr("SalCoefficient04").ToString
                txtSalCoefficient05.Text = dr("SalCoefficient05").ToString
                txtSalCoefficient06.Text = dr("SalCoefficient06").ToString
                txtSalCoefficient07.Text = dr("SalCoefficient07").ToString
                txtSalCoefficient08.Text = dr("SalCoefficient08").ToString
                txtSalCoefficient09.Text = dr("SalCoefficient09").ToString
                txtSalCoefficient10.Text = dr("SalCoefficient10").ToString
                ' update 25/10/2012 id 52085
                txtSalCoefficient11.Text = dr("SalCoefficient11").ToString
                txtSalCoefficient12.Text = dr("SalCoefficient12").ToString
                txtSalCoefficient13.Text = dr("SalCoefficient13").ToString
                txtSalCoefficient14.Text = dr("SalCoefficient14").ToString
                txtSalCoefficient15.Text = dr("SalCoefficient15").ToString
                txtSalCoefficient16.Text = dr("SalCoefficient16").ToString
                txtSalCoefficient17.Text = dr("SalCoefficient17").ToString
                txtSalCoefficient18.Text = dr("SalCoefficient18").ToString
                txtSalCoefficient19.Text = dr("SalCoefficient19").ToString
                txtSalCoefficient20.Text = dr("SalCoefficient20").ToString
                ' ======================================
                txt_NumberFormat()

                D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
            Else
                D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
            End If

        End If

        ' update 30/9/2013 id 58973
        sSQL = SQLStoreD13P1039(2)
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            c1dateOffSa1DateEnd.Value = dt.Rows(0).Item("OffSa1DateEnd")
            c1dateOffSa1NextDate.Value = dt.Rows(0).Item("OffSa1NextDate")
            c1dateOffSa1DateEnd2.Value = dt.Rows(0).Item("OffSa1DateEnd")
            c1dateOffSa1NextDate2.Value = dt.Rows(0).Item("OffSa2NextDate")
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1033
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2009 02:56:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1033() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1033 "
        sSQL &= SQLString(gsUserID) & COMMA 'Users, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostName, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'Form, varchar[20], NOT NULL
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear)  'TranYear, int, NOT NULL
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1030
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2009 02:50:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1030(")
        sSQL.Append("Users, HostName, Key01ID, Key02ID, Key03ID, " & vbCrLf)
        sSQL.Append("Num01, Num02, Num03, Num04, " & vbCrLf) 'Num05, 
        sSQL.Append("Num06, Num07, Num08, Num09, Num10, ")
        sSQL.Append("Num11, Num12, Num13, Num14, Num15, " & vbCrLf)
        sSQL.Append("Num16, Num17, Num18, Num19, Num20, ")
        sSQL.Append("Num21, Num22, Num23, Num24, Num25, " & vbCrLf)
        sSQL.Append("Key06ID, Key07ID, Key08ID, Key09ID, " & vbCrLf)
        sSQL.Append("Key10ID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'Users, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostName, varchar[20], NULL
        sSQL.Append(SQLString(_employeeID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(tdbcSalaryObjectID.Text) & COMMA) 'Key02ID, varchar[250], NULL
        sSQL.Append(SQLString(Me.Name) & COMMA & vbCrLf) 'Key03ID, varchar[250], NULL
        sSQL.Append(SQLMoney(txtBaseSalary01.Text) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtBaseSalary02.Text) & COMMA) 'Num02, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtBaseSalary03.Text) & COMMA) 'Num03, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtBaseSalary04.Text) & COMMA & vbCrLf) 'Num04, decimal, NOT NULL
        'sSQL.Append(SQLMoney(txtSalCoefficient01.Text) & COMMA) 'Num05, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient01.Text) & COMMA) 'Num06, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient02.Text) & COMMA) 'Num07, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient03.Text) & COMMA) 'Num08, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient04.Text) & COMMA) 'Num09, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient05.Text) & COMMA) 'Num10, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient06.Text) & COMMA) 'Num11, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient07.Text) & COMMA) 'Num12, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient08.Text) & COMMA) 'Num13, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient09.Text) & COMMA) 'Num14, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient10.Text) & COMMA & vbCrLf) 'Num15, decimal, NOT NULL
        ' update 25/10/2012 id 52085 - bổ sung 10 num (từ  Num16 -> Num25)
        sSQL.Append(SQLMoney(txtSalCoefficient11.Text) & COMMA) 'Num16, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient12.Text) & COMMA) 'Num17, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient13.Text) & COMMA) 'Num18, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient14.Text) & COMMA) 'Num19, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient15.Text) & COMMA) 'Num20, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient16.Text) & COMMA) 'Num21, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient17.Text) & COMMA) 'Num22, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient18.Text) & COMMA) 'Num23, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient19.Text) & COMMA) 'Num24, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtSalCoefficient20.Text) & COMMA & vbCrLf) 'Num25, decimal, NOT NULL
        sSQL.Append(SQLString(ComboValue(tdbcOfficialTitleID)) & COMMA) 'Key06ID, varchar[250], NULL
        sSQL.Append(SQLString(ComboValue(tdbcSalaryLevelID)) & COMMA) 'Key07ID, varchar[250], NULL
        sSQL.Append(SQLString(ComboValue(tdbcOfficialTitleID2)) & COMMA) 'Key08ID, varchar[250], NULL
        sSQL.Append(SQLString(ComboValue(tdbcSalaryLevelID2)) & COMMA & vbCrLf) 'Key09ID, varchar[250], NULL
        sSQL.Append(SQLString(ComboValue(tdbcSalEmpGroupID))) 'Key10ID, varchar[250], NULL
        sSQL.Append(")" & vbCrLf)

        Return sSQL
    End Function

    Private Sub btnSetDefaultSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDefaultSalary.Click
        Dim frm As New D13F1036
        frm.EmployeeID = _employeeID
        'frm.DivisionID = _divisionID
        frm.ShowDialog()
        frm.Dispose()
        If frm.TableDefaultSalary IsNot Nothing Then
            Dim dtDefaultSalary As DataTable = frm.TableDefaultSalary
            If dtDefaultSalary.Rows.Count > 0 Then

                'Ngạch bậc lương
                With dtDefaultSalary.Rows(0)
                    tdbcOfficialTitleID.Text = .Item("OfficalTitleID").ToString
                    tdbcSalaryLevelID.Text = .Item("SalaryLevelID").ToString
                    tdbcOfficialTitleID2.Text = .Item("OfficalTitleID2").ToString
                    tdbcSalaryLevelID2.Text = .Item("SalaryLevelID2").ToString

                    'Lương cơ bản
                    If Not IsDBNull(.Item("BaseSalary01")) Then
                        txtBaseSalary01.Text = SQLNumber(.Item("BaseSalary01").ToString, D13Format.DefaultNumber2)
                    Else
                        txtBaseSalary01.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("BaseSalary02")) Then
                        txtBaseSalary02.Text = SQLNumber(.Item("BaseSalary02").ToString, D13Format.DefaultNumber2)
                    Else
                        txtBaseSalary02.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("BaseSalary03")) Then
                        txtBaseSalary03.Text = SQLNumber(.Item("BaseSalary03").ToString, D13Format.DefaultNumber2)
                    Else
                        txtBaseSalary03.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("BaseSalary04")) Then
                        txtBaseSalary04.Text = SQLNumber(.Item("BaseSalary04").ToString, D13Format.DefaultNumber2)
                    Else
                        txtBaseSalary04.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If

                    'Tab Hệ số lương

                    If Not IsDBNull(.Item("SalCoefficient01")) Then
                        txtSalCoefficient01.Text = SQLNumber(.Item("SalCoefficient01").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient01.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient02")) Then
                        txtSalCoefficient02.Text = SQLNumber(.Item("SalCoefficient02").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient02.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If

                    If Not IsDBNull(.Item("SalCoefficient03")) Then
                        txtSalCoefficient03.Text = SQLNumber(.Item("SalCoefficient03").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient03.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If

                    If Not IsDBNull(.Item("SalCoefficient04")) Then
                        txtSalCoefficient04.Text = SQLNumber(.Item("SalCoefficient04").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient04.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient05")) Then
                        txtSalCoefficient05.Text = SQLNumber(.Item("SalCoefficient05").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient05.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient06")) Then
                        txtSalCoefficient06.Text = SQLNumber(.Item("SalCoefficient06").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient06.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient07")) Then
                        txtSalCoefficient07.Text = SQLNumber(.Item("SalCoefficient07").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient07.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient08")) Then
                        txtSalCoefficient08.Text = SQLNumber(.Item("SalCoefficient08").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient08.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient09")) Then
                        txtSalCoefficient09.Text = SQLNumber(.Item("SalCoefficient09").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient09.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                    If Not IsDBNull(.Item("SalCoefficient10")) Then
                        txtSalCoefficient10.Text = SQLNumber(.Item("SalCoefficient10").ToString, D13Format.DefaultNumber2)
                    Else
                        txtSalCoefficient10.Text = SQLNumber(0, D13Format.DefaultNumber2)
                    End If
                End With

            End If
        End If

        ' update 30/9/2013 id 58973
        Dim sSQL As String = SQLStoreD13P1039(2)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            c1dateOffSa1DateEnd.Value = dt.Rows(0).Item("OffSa1DateEnd")
            c1dateOffSa1NextDate.Value = dt.Rows(0).Item("OffSa2DateEnd")
            c1dateOffSa1DateEnd2.Value = dt.Rows(0).Item("OffSa1DateEnd")
            c1dateOffSa1NextDate2.Value = dt.Rows(0).Item("OffSa2NextDate")
        End If
    End Sub

    Private Sub btnDeductibleInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeductibleInfo.Click
        ClickButton(ButtonD13F1031.DeductibleInfo)
        tdbgRelative.Col = COL1_Salary
        tdbgRelative.SplitIndex = SPLIT1
    End Sub

    Private Sub btnDeductibleFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeductibleFile.Click
        ClickButton(ButtonD13F1031.DeductibleFile)
        tdbgRelative.Col = COL1_BirthCertificate
        tdbgRelative.SplitIndex = SPLIT1
    End Sub

    Private Sub ClickButton(ByVal button As ButtonD13F1031)
        btnDeductibleInfo.Enabled = Math.Abs(button - ButtonD13F1031.DeductibleInfo) > 0
        btnDeductibleFile.Enabled = Math.Abs(button - ButtonD13F1031.DeductibleFile) > 0

        For i As Integer = COL1_Salary To COL1_Note
            tdbgRelative.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(button - ButtonD13F1031.DeductibleInfo) = 0
        Next
        For i As Integer = COL1_BirthCertificate To COL1_NoteConfirmation
            tdbgRelative.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(button - ButtonD13F1031.DeductibleFile) = 0
        Next

        'Ẩn cột này
        tdbgRelative.Splits(SPLIT1).DisplayColumns(COL1_DeductibleAmount).Visible = False

    End Sub

    Private Sub tdbgBankID_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgBankID.ComboSelect
        tdbgBankID.UpdateData()
    End Sub

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
                ' e.Cancel = L3IsID(tdbgBankID, e.ColIndex) 'Bỏ chặn nhập mã theo ID 79971 07/10/2015
        End Select
    End Sub

    Private Sub tdbgBankID_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgBankID.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
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

#End Region

    Private Sub tdbgBankID_LockedColumns()
        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BranchName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Function AllowSaveBankID() As Boolean
        If optPaymentMethodB.Checked = False Then Return True

        tdbgBankID.UpdateData()
        If tdbgBankID.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgBankID.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgBankID.RowCount - 1
            If tdbgBankID(i, COLB_BankID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngan_hang"))
                tabMain.SelectedTab = TabPage4
                tdbgBankID.Focus()
                tdbgBankID.SplitIndex = SPLIT0
                tdbgBankID.Col = COLB_BankID
                tdbgBankID.Bookmark = i
                Return False
            End If
            ' update 12/3/2013 id 59634 - không cần nhập thông tin này
            '            If tdbgBankID(i, COLB_AccountHolderName).ToString = "" Then
            '                D99C0008.MsgNotYetEnter(rl3("Ten_tai_khoan"))
            '                tabMain.SelectedTab = TabPage4
            '                tdbgBankID.Focus()
            '                tdbgBankID.SplitIndex = SPLIT0
            '                tdbgBankID.Col = COLB_AccountHolderName
            '                tdbgBankID.Bookmark = i
            '                Return False
            '            End If
            If tdbgBankID(i, COLB_BankAccountNo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_tai_khoan"))
                tabMain.SelectedTab = TabPage4
                tdbgBankID.Focus()
                tdbgBankID.SplitIndex = SPLIT0
                tdbgBankID.Col = COLB_BankAccountNo
                tdbgBankID.Bookmark = i
                Return False
            End If
        Next

        If dtGridBankID.Select("IsDefault=1").Length = 0 Then
            D99C0008.MsgNotYetEnter(rl3("Mac_dinh"))
            tabMain.SelectedTab = TabPage4
            tdbgBankID.Focus()
            tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
            tdbgBankID.Col = COLB_IsDefault 'Tùy theo yêu cầu mỗi Form
            tdbgBankID.Row = 0 'Tùy theo yêu cầu mỗi Form
            Return False
        End If

        For i As Integer = 0 To tdbgBankID.RowCount - 2
            For j As Integer = i + 1 To tdbgBankID.RowCount - 1
                If tdbgBankID(i, COLB_BankAccountNo).ToString = tdbgBankID(j, COLB_BankAccountNo).ToString Then
                    D99C0008.MsgL3(rl3("So_tai_khoan_bi_trung") & " " & rL3("Ban_khong_duoc_phep_luu"))
                    tabMain.SelectedTab = TabPage4
                    tdbgBankID.Focus()
                    tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    tdbgBankID.Col = COLB_BankAccountNo 'Tùy theo yêu cầu mỗi Form
                    tdbgBankID.Row = j 'Tùy theo yêu cầu mỗi Form
                    Return False
                End If
            Next
        Next
        If dtGridBankID.Select("IsDefault=1").Length >= 2 Then
            D99C0008.MsgL3(rL3("Ton_tai_2_ngan_hang_mac_dinh") & " " & rL3("Ban_khong_duoc_phep_luu"))
            tabMain.SelectedTab = TabPage4
            tdbgBankID.Focus()
            tdbgBankID.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
            tdbgBankID.Col = COLB_IsDefault 'Tùy theo yêu cầu mỗi Form
            tdbgBankID.Row = 0 'Tùy theo yêu cầu mỗi Form
            Return False
        End If
        Return True
    End Function


    '    Private Sub SetBackColorObligatory()
    '        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    '        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_AccountHolderName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    '        tdbgBankID.Splits(SPLIT0).DisplayColumns(COLB_BankAccountNo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    '    End Sub




    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 19/08/2011 09:54:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6200(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13T0201") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString("EmployeeID") & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("EmployeeID") & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 19/08/2011 09:53:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6210() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateSave(DateTime.Now()) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString("MasterSalaryFile") & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("02") & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0101
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/10/2011 02:44:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0101() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("--- Update phuong thuc tra luong vao HSLT" & vbCrLf)
        sSQL.Append("Update D13T0101 Set ")

        If optPaymentMethodC.Checked = True Then
            sSQL.Append("PaymentMethod = " & SQLString("C")) 'varchar[1], NOT NULL
        ElseIf optPaymentMethodB.Checked = True Then
            sSQL.Append("PaymentMethod = " & SQLString("B")) 'varchar[1], NOT NULL
        Else
            sSQL.Append("PaymentMethod = " & SQLString("O")) 'varchar[1], NOT NULL
        End If

        '        sSQL.Append("BaseSalary01 = " & SQLMoney(txtBaseSalary01.Text, InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("BaseSalary02 = " & SQLMoney(txtBaseSalary02.Text, InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("BaseSalary03 = " & SQLMoney(txtBaseSalary03.Text, InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("BaseSalary04 = " & SQLMoney(txtBaseSalary04.Text, InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '
        '        sSQL.Append("SalCoefficient01 = " & SQLMoney(txtSalCoefficient01.Text, InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient02 = " & SQLMoney(txtSalCoefficient02.Text, InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient03 = " & SQLMoney(txtSalCoefficient03.Text, InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient04 = " & SQLMoney(txtSalCoefficient04.Text, InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient05 = " & SQLMoney(txtSalCoefficient05.Text, InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient06 = " & SQLMoney(txtSalCoefficient06.Text, InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient07 = " & SQLMoney(txtSalCoefficient07.Text, InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient08 = " & SQLMoney(txtSalCoefficient08.Text, InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient09 = " & SQLMoney(txtSalCoefficient09.Text, InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient10 = " & SQLMoney(txtSalCoefficient10.Text, InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '
        '        sSQL.Append("SalCoefficient11 = " & SQLMoney(txtSalCoefficient11.Text, InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient12 = " & SQLMoney(txtSalCoefficient12.Text, InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient13 = " & SQLMoney(txtSalCoefficient13.Text, InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient14 = " & SQLMoney(txtSalCoefficient14.Text, InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient15 = " & SQLMoney(txtSalCoefficient15.Text, InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient16 = " & SQLMoney(txtSalCoefficient16.Text, InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient17 = " & SQLMoney(txtSalCoefficient17.Text, InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient18 = " & SQLMoney(txtSalCoefficient18.Text, InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient19 = " & SQLMoney(txtSalCoefficient19.Text, InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SalCoefficient20 = " & SQLMoney(txtSalCoefficient20.Text, InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString)) & COMMA) 'decimal, NOT NULL
        '
        '        sSQL.Append("OfficalTitleID = " & SQLString(tdbcOfficialTitleID.Text) & COMMA) 'varchar[20], NOT NULL
        '        sSQL.Append("SalaryLevelID = " & SQLString(tdbcSalaryLevelID.Text) & COMMA) 'varchar[20], NOT NULL
        '        sSQL.Append("OfficalTitleID2 = " & SQLString(tdbcOfficialTitleID2.Text) & COMMA) 'varchar[20], NOT NULL
        '        sSQL.Append("SalaryLevelID2 = " & SQLString(tdbcSalaryLevelID2.Text) & COMMA) 'varchar[20], NOT NULL
        '
        '        sSQL.Append("SaCoefficient = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient12 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient02").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient13 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient03").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient14 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient04").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient15 = " & SQLMoney(tdbcSalaryLevelID.Columns("SalaryCoefficient05").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient2 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient22 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient02").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient23 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient03").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient24 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient04").Text) & COMMA) 'decimal, NOT NULL
        '        sSQL.Append("SaCoefficient25 = " & SQLMoney(tdbcSalaryLevelID2.Columns("SalaryCoefficient05").Text) & COMMA) 'decimal, NOT NULL
        '
        '        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        '        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL

        sSQL.Append(" Where ")
        sSQL.Append("EmployeeID = " & SQLString(_employeeID)) 'varchar[20], NOT NULL
        sSQL.Append(" And TranMonth = " & SQLNumber(giTranMonth)) 'tinyint, NOT NULL
        sSQL.Append(" And TranYear = " & SQLNumber(giTranYear)) 'smallint, NOT NULL

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Hoàng Nhân
    '# Created Date: 03/04/2013 08:27:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra nhan vien co ton tai HSL thang hay chua" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F1031") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("CheckExistsMonthSalaryFile") & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) 'Key02ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0101
    '# Created User: Hoàng Nhân
    '# Created Date: 27/06/2013 12:01:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0101() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat HSL thang" & vbCrLf)
        sSQL &= "Exec D13P0101 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F1031") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) 'EmployeeID, varchar[20], NOT NULL
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
        Dim sSQL As String = ""
        sSQL &= ("-- Delete luoi Ngan hang truoc khi insert" & vbCrLf)
        sSQL &= "Delete From D13T0202"
        sSQL &= " Where EmployeeID = " & SQLString(_employeeID)
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
        For i As Integer = 0 To tdbgBankID.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert luoi ngan hang" & vbCrLf)
            sSQL.Append("Insert Into D13T0202(")
            sSQL.Append("EmployeeID, BankID, BankAccountNo, BankAccountNoU, AccountHolderName, ")
            sSQL.Append("AccountHolderNameU, ExchangeDep, ExchangeDepU, IsDefault")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(_employeeID) & COMMA) 'EmployeeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbgBankID(i, COLB_BankID)) & COMMA) 'BankID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbgBankID(i, COLB_BankAccountNo)) & COMMA) 'BankAccountNo, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgBankID(i, COLB_BankAccountNo), gbUnicode, True) & COMMA) 'BankAccountNoU, nvarchar[100], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgBankID(i, COLB_AccountHolderName), gbUnicode, False) & COMMA) 'AccountHolderName, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgBankID(i, COLB_AccountHolderName), gbUnicode, True) & COMMA) 'AccountHolderNameU, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgBankID(i, COLB_ExchangeDep), gbUnicode, False) & COMMA) 'ExchangeDep, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgBankID(i, COLB_ExchangeDep), gbUnicode, True) & COMMA) 'ExchangeDepU, nvarchar[500], NOT NULL
            sSQL.Append(SQLNumber(tdbgBankID(i, COLB_IsDefault))) 'IsDefault, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
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
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D13P1502 "
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1039
    '# Created User: Hoàng Nhân
    '# Created Date: 30/09/2013 05:14:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1039(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh toan gia tri Ngay xet tiep theo" & vbCrLf)
        sSQL &= "Exec D13P1039 "
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID.Text) & COMMA 'OfficialTitleID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcSalaryLevelID.Text) & COMMA 'SalaryLevelID, varchar[50], NOT NULL
        sSQL &= SQLDateSave(c1dateOffSa1DateEnd.Value) & COMMA 'OffSa1DateEnd, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateOffSa1NextDate.Value) & COMMA 'OffSa1NextDate, datetime, NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID2.Text) & COMMA 'OfficialTitleID2, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcSalaryLevelID2.Text) & COMMA 'SalaryLevelID2, varchar[50], NOT NULL
        sSQL &= SQLDateSave(c1dateOffSa1DateEnd2.Value) & COMMA 'OffSa2DateEnd, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateOffSa1NextDate2.Value) & COMMA 'OffSa2NextDate, datetime, NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function
    Private Sub tdbgRelative_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgRelative.KeyPress
          Select Case tdbgRelative.Col
            Case COL1_InComeTaxCode, COL1_IDCardNo
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
      
    End Sub
End Class