Imports System
Public Class D13F1035

#Region "Const of tdbg"
    Private Const COL_BlockID As Integer = 0             ' Mã khối
    Private Const COL_BlockName As Integer = 1           ' Tên khối
    Private Const COL_DepartmentID As Integer = 2        ' Phòng ban
    Private Const COL_DepartmentName As Integer = 3      ' Tên phòng ban
    Private Const COL_TeamID As Integer = 4              ' Tổ nhóm
    Private Const COL_TeamName As Integer = 5            ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 6          ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 7        ' Tên nhóm NV
    Private Const COL_EmployeeID As Integer = 8          ' Mã nhân viên
    Private Const COL_FullName As Integer = 9            ' Tên nhân viên
    Private Const COL_IsSub As Integer = 10              ' HSL phụ
    Private Const COL_TaxObjectID As Integer = 11        ' Mã ĐT tính thuế
    Private Const COL_TaxObjectName As Integer = 12      ' Tên ĐT tính thuế
    Private Const COL_BASE01 As Integer = 13             ' BASE01
    Private Const COL_BASE02 As Integer = 14             ' BASE02
    Private Const COL_BASE03 As Integer = 15             ' BASE03
    Private Const COL_BASE04 As Integer = 16             ' BASE04
    Private Const COL_CE01 As Integer = 17               ' CE01
    Private Const COL_CE02 As Integer = 18               ' CE02
    Private Const COL_CE03 As Integer = 19               ' CE03
    Private Const COL_CE04 As Integer = 20               ' CE04
    Private Const COL_CE05 As Integer = 21               ' CE05
    Private Const COL_CE06 As Integer = 22               ' CE06
    Private Const COL_CE07 As Integer = 23               ' CE07
    Private Const COL_CE08 As Integer = 24               ' CE08
    Private Const COL_CE09 As Integer = 25               ' CE09
    Private Const COL_CE10 As Integer = 26               ' CE10
    Private Const COL_OfficalTitleID As Integer = 27     ' OfficalTitleID
    Private Const COL_SalaryLevelID As Integer = 28      ' SalaryLevelID
    Private Const COL_SaCoefficient As Integer = 29      ' SaCoefficient
    Private Const COL_SaCoefficient12 As Integer = 30    ' SaCoefficient12
    Private Const COL_SaCoefficient13 As Integer = 31    ' SaCoefficient13
    Private Const COL_SaCoefficient14 As Integer = 32    ' SaCoefficient14
    Private Const COL_SaCoefficient15 As Integer = 33    ' SaCoefficient15
    Private Const COL_OfficalTitleID2 As Integer = 34    ' OfficalTitleID2
    Private Const COL_SalaryLevelID2 As Integer = 35     ' SalaryLevelID2
    Private Const COL_SaCoefficient2 As Integer = 36     ' SaCoefficient2
    Private Const COL_SaCoefficient22 As Integer = 37    ' SaCoefficient22
    Private Const COL_SaCoefficient23 As Integer = 38    ' SaCoefficient23
    Private Const COL_SaCoefficient24 As Integer = 39    ' SaCoefficient24
    Private Const COL_SaCoefficient25 As Integer = 40    ' SaCoefficient25
    Private Const COL_P01ID As Integer = 41              ' P01ID
    Private Const COL_P02ID As Integer = 42              ' P02ID
    Private Const COL_P03ID As Integer = 43              ' P03ID
    Private Const COL_P04ID As Integer = 44              ' P04ID
    Private Const COL_P05ID As Integer = 45              ' P05ID
    Private Const COL_P06ID As Integer = 46              ' P06ID
    Private Const COL_P07ID As Integer = 47              ' P07ID
    Private Const COL_P08ID As Integer = 48              ' P08ID
    Private Const COL_P09ID As Integer = 49              ' P09ID
    Private Const COL_P10ID As Integer = 50              ' P10ID
    Private Const COL_P11ID As Integer = 51              ' P11ID
    Private Const COL_P12ID As Integer = 52              ' P12ID
    Private Const COL_P13ID As Integer = 53              ' P13ID
    Private Const COL_P14ID As Integer = 54              ' P14ID
    Private Const COL_P15ID As Integer = 55              ' P15ID
    Private Const COL_P16ID As Integer = 56              ' P16ID
    Private Const COL_P17ID As Integer = 57              ' P17ID
    Private Const COL_P18ID As Integer = 58              ' P18ID
    Private Const COL_P19ID As Integer = 59              ' P19ID
    Private Const COL_P20ID As Integer = 60              ' P20ID
    Private Const COL_PaymentMethod As Integer = 61      ' Phương pháp trả lương
    Private Const COL_BankID As Integer = 62             ' Ngân hàng 1
    Private Const COL_BranchName As Integer = 63         ' Chi nhánh1
    Private Const COL_ExchangeDep As Integer = 64        ' Phòng giao dịch1
    Private Const COL_BankAccountNo As Integer = 65      ' Số hiệu tài khoản1
    Private Const COL_AccountHolderName As Integer = 66  ' Tên chủ khoản1
    Private Const COL_BankID2 As Integer = 67            ' Ngân hàng 2
    Private Const COL_BranchName2 As Integer = 68        ' Chi nhánh
    Private Const COL_ExchangeDep2 As Integer = 69       ' Phòng giao dịch
    Private Const COL_BankAccountNo2 As Integer = 70     ' Số hiệu tài khoản
    Private Const COL_AccountHolderName2 As Integer = 71 ' Tên chủ khoản
    Private Const COL_CreateDate As Integer = 72         ' CreateDate
    Private Const COL_CreateUserID As Integer = 73       ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 74     ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 75   ' LastModifyUserID
#End Region

    Private sPayrollVoucherID As String = ""
    Private sPayrollVoucherNo As String = ""
    Private sVoucherTypeID As String = ""
    Private sVoucherDate As String = ""
    Private sDescription As String = ""
    Private sCreateUserID As String = ""
    Private sLastModifyUserID As String = ""


    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _sFind As String = ""
    Public WriteOnly Property sFind() As String
        Set(ByVal Value As String)
            _sFind = Value
        End Set
    End Property

    Private _showAll As Boolean = False
    Public WriteOnly Property ShowAll() As Boolean
        Set(ByVal Value As Boolean)
            _showAll = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private bBA As SALBA
    Private bCE As SALCE
    Private bOL As OLSC
    Private bANASAL As ANASALARY
    Dim dtPAnaID As DataTable
    Dim dtPAnaCategoryID As DataTable
    Dim bIsNotInList As Boolean

    Private Sub D13F1035_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        LoadCaption()
        'Upadte 23/8/2012 incident 50602
        If Not D13Systems.IsUsedPAna Then
            HideButtonAnalyseSalary()
        End If
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        LoadTDBDropDown()
        LoadTDBGrid()
        btnSalaryCoefficientBase_Click(Nothing, Nothing)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Cap_nhat_hang_loat_ho_so_luong_goc_-_D13F1035") & UnicodeCaption(gbUnicode) 'CËp nhËt hªng loÁt hä s¥ l§¥ng gçc - D13F1035
        '================================================================ 
        btnSalaryPaymentMethod.Text = "4. " & rL3("Phuong_phap_tra_luong") 'Phương pháp trả lương
        btnAnalyseSalary.Text = "3. " & rL3("Ma_phan_tich_tien_luong") 'Mã phân tích tiền lương
        btnSalaryLevelOfficialTitle.Text = "2. " & rL3("Ngach_-_bac_luong") 'Ngạch - Bậc lương
        btnSalaryCoefficientBase.Text = "1. " & rL3("Luong_co_ban_He_so") 'Lương cơ bản/ Hệ số
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdTaxObjectID.Columns("TaxObjectID").Caption = rL3("Ma") 'Mã
        tdbdTaxObjectID.Columns("TaxObjectName").Caption = rL3("Ten") 'Tên
        tdbdOfficialTitleID1.Columns("OfficialTitleID").Caption = rL3("Ma_ngach_luong") 'Mã ngạch lương
        tdbdOfficialTitleID1.Columns("OfficialTitleName").Caption = rL3("Ten_ngach_luong") 'Tên ngạch lương
        tdbdSalaryLevelID1.Columns("SalaryLevelID").Caption = rL3("Ma_bac_luong") 'Mã bậc lương
        tdbdOfficialTitleID2.Columns("OfficialTitleID").Caption = rL3("Ma_ngach_luong") 'Mã ngạch lương
        tdbdOfficialTitleID2.Columns("OfficialTitleName").Caption = rL3("Ten_ngach_luong") 'Tên ngạch lương
        tdbdSalaryLevelID2.Columns("SalaryLevelID").Caption = rL3("Ma_bac_luong") 'Mã bậc lương
        tdbdBankID1.Columns("BankID").Caption = rL3("Ma") 'Mã
        tdbdBankID1.Columns("BankName").Caption = rL3("Ten") 'Tên
        tdbdPAnaID.Columns("PAnaID").Caption = rL3("Ma") 'Mã
        tdbdPAnaID.Columns("PAnaName").Caption = rL3("Ten") 'Tên
        tdbdBankID2.Columns("BankID").Caption = rL3("Ma") 'Mã
        tdbdBankID2.Columns("BankName").Caption = rL3("Ten") 'Tên
        tdbdPaymentMethod.Columns("PaymentMethod").Caption = rL3("Ma") 'Mã
        tdbdPaymentMethod.Columns("Description").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rL3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rL3("Nhom_NV")
        tdbg.Columns("EmployeeID").Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rL3("Ho_va_ten")
        tdbg.Columns("TaxObjectID").Caption = rL3("Ma_DT_tinh_thue") 'Mã ĐT tính thuế
        tdbg.Columns("TaxObjectName").Caption = rL3("Ten_DT_tinh_thue") 'Tên ĐT tính thuế
        tdbg.Columns("PaymentMethod").Caption = rL3("Phuong_phap_tra_luong") 'Phương pháp trả lương
        tdbg.Columns("BankID").Caption = rL3("Ngan_hang_1") 'Ngân hàng 1
        tdbg.Columns("BranchName").Caption = rL3("Chi_nhanh") 'Chi nhánh
        tdbg.Columns("ExchangeDep").Caption = rL3("Phong_giao_dich") 'Phòng giao dịch
        tdbg.Columns("BankAccountNo").Caption = rL3("So_hieu_tai_khoan") 'Số hiệu tài khoản
        tdbg.Columns("AccountHolderName").Caption = rL3("Ten_chu_khoan") 'Tên chủ khoản
        tdbg.Columns("BankID2").Caption = rL3("Ngan_hang_2") 'Ngân hàng 2
        tdbg.Columns("BranchName2").Caption = rL3("Chi_nhanh") 'Chi nhánh
        tdbg.Columns("ExchangeDep2").Caption = rL3("Phong_giao_dich") 'Phòng giao dịch
        tdbg.Columns("BankAccountNo2").Caption = rL3("So_hieu_tai_khoan") 'Số hiệu tài khoản
        tdbg.Columns("AccountHolderName2").Caption = rL3("Ten_chu_khoan") 'Tên chủ khoản
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P4050()
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, ReturnTableFilter(dt, "EmployeeID In (" & _employeeID & ")"), gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_BlockID To COL_FullName
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(i).Locked = True
        Next

        For i As Integer = COL_SaCoefficient To COL_SaCoefficient15
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next
        For i As Integer = COL_SaCoefficient2 To COL_SaCoefficient25
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next

        For i As Integer = COL_SaCoefficient2 To COL_SaCoefficient25
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next

        tdbg.Splits(SPLIT1).DisplayColumns(COL_BranchName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaxObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BranchName).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BranchName2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BranchName2).Locked = True
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BASE01).NumberFormat = Format(tdbg.Columns(COL_BASE01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COL_BASE02).NumberFormat = Format(tdbg.Columns(COL_BASE02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COL_BASE03).NumberFormat = Format(tdbg.Columns(COL_BASE03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COL_BASE04).NumberFormat = Format(tdbg.Columns(COL_BASE04).Text, D13FormatSalary.BASE04)
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
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        Dim dtCombo As DataTable

        'Load tdbdTaxObjectID
        sSQL = "Select TaxObjectID, TaxObjectName" & UnicodeJoin(gbUnicode) & " as TaxObjectName " & vbCrLf
        sSQL &= "From D13T0128 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by TaxObjectID"
        LoadDataSource(tdbdTaxObjectID, sSQL, gbUnicode)

        'Load tdbdOfficialTitleID1
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial" & vbCrLf
        sSQL &= "From D09T0214  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And (IsUseOfficial = 0 Or IsUseOfficial = 1)" & vbCrLf
        sSQL &= "Order By OfficialTitleID"
        LoadDataSource(tdbdOfficialTitleID1, sSQL, gbUnicode)

        'Load tdbdOfficialTitleID2
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, IsUseOfficial" & vbCrLf
        sSQL &= "From D09T0214  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And (IsUseOfficial = 0 Or IsUseOfficial = 2)" & vbCrLf
        sSQL &= "Order By OfficialTitleID"
        LoadDataSource(tdbdOfficialTitleID2, sSQL, gbUnicode)

        'Load tdbdBankID1'Load tdbdBankID2
        sSQL = "Select 		ObjectID BankID, ObjectName" & UnicodeJoin(gbUnicode) & " BankName, BranchName" & UnicodeJoin(gbUnicode) & " as  BranchName" & vbCrLf
        sSQL &= "From 		Object  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where 		Disabled = 0 And ObjectTypeID = 'NH' " & vbCrLf
        sSQL &= "Order by 	ObjectID"
        dtCombo = ReturnDataTable(sSQL)
        LoadDataSource(tdbdBankID1, dtCombo, gbUnicode)
        LoadDataSource(tdbdBankID2, dtCombo.Copy, gbUnicode)

        'Load tdbdPaymentMethod
        sSQL = "SELECT 	'C' AS 'PaymentMethod', " & SQLString(IIf(gsLanguage = "84", "Tieàn maët", "Cash")) & " AS Description" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 	'B' AS 'PaymentMethod', " & SQLString(IIf(gsLanguage = "84", "Chuyeån khoaûn", "Bank Transfer")) & " AS Description " & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 	'O' AS 'PaymentMethod', " & SQLString(IIf(gsLanguage = "84", "Khaùc", "Others")) & " AS Description"
        Dim dtMethod As DataTable = ReturnDataTable(sSQL)
        If gbUnicode Then
            ConvertVniToUnicode(dtMethod)
        End If
        LoadDataSource(tdbdPaymentMethod, dtMethod, gbUnicode)

        'Load tdbdPAnaID
        sSQL = "Select PAnaID, PAnaName" & UnicodeJoin(gbUnicode) & " as PAnaName, PAnaCategoryID From D13T1050 WITH (NOLOCK) "
        dtPAnaID = ReturnDataTable(sSQL)
    End Sub

    Public Sub LoadtdbdSalaryLevelID1(ByVal ID As String)
        Dim sSQL As String
        'Load tdbdSalaryLevelID1
        sSQL = "Select SalaryLevelID, SalaryCoefficient, SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05 " & vbCrLf
        sSQL &= "From D09T0215 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "And OfficialTitleID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by Grade"
        LoadDataSource(tdbdSalaryLevelID1, sSQL, gbUnicode)
    End Sub

    Public Sub LoadtdbdSalaryLevelID2(ByVal ID As String)
        Dim sSQL As String
        'Load tdbdSalaryLevelID1
        sSQL = "Select SalaryLevelID, SalaryCoefficient, SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05 " & vbCrLf
        sSQL &= "From D09T0215 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "And OfficialTitleID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by Grade"
        LoadDataSource(tdbdSalaryLevelID2, sSQL, gbUnicode)
    End Sub

    Public Sub LoadtdbdPAnaID(ByVal ID As String)
        'Load tdbdPAnaID
        LoadDataSource(tdbdPAnaID, ReturnTableFilter(dtPAnaID, "PanaCategoryID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub LoadCaption()
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short , Disabled, Type From D13T9000  WITH (NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable

        dt1 = ReturnTableFilter(dt, "Type='SALBA'")
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_BASE01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_BASE02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_BASE03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_BASE04).Caption = dt1.Rows(3).Item("Short").ToString

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
        tdbg.Columns(COL_CE01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_CE02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_CE03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_CE04).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_CE05).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_CE06).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_CE07).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_CE08).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_CE09).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_CE10).Caption = dt1.Rows(9).Item("Short").ToString

        dt1 = ReturnTableFilter(dt, "Type = 'OLSC'")
        bOL.OLSC1 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC10 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC11 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC12 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC13 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC14 = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC15 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC2 = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC20 = CBool(IIf(dt1.Rows(8).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC21 = CBool(IIf(dt1.Rows(9).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC22 = CBool(IIf(dt1.Rows(10).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC23 = CBool(IIf(dt1.Rows(11).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC24 = CBool(IIf(dt1.Rows(12).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC25 = CBool(IIf(dt1.Rows(13).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_OfficalTitleID).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_SalaryLevelID).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient12).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient13).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient14).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient15).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_OfficalTitleID2).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_SalaryLevelID2).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient2).Caption = dt1.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient22).Caption = dt1.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient23).Caption = dt1.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient24).Caption = dt1.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient25).Caption = dt1.Rows(13).Item("Short").ToString

        sSQL = "Select PAnaCategoryID As Code, PAnaCategoryShort" & UnicodeJoin(gbUnicode) & " As Short, Disabled From D13T0050  WITH (NOLOCK) Order By Code"
        dt1 = ReturnDataTable(sSQL)
        dtPAnaCategoryID = dt1.Copy
        bANASAL.P01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bANASAL.P02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bANASAL.P03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bANASAL.P04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bANASAL.P05 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bANASAL.P06 = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bANASAL.P07 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))
        bANASAL.P08 = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))
        bANASAL.P09 = CBool(IIf(dt1.Rows(8).Item("Disabled").ToString = "0", True, False))
        bANASAL.P10 = CBool(IIf(dt1.Rows(9).Item("Disabled").ToString = "0", True, False))
        bANASAL.P11 = CBool(IIf(dt1.Rows(10).Item("Disabled").ToString = "0", True, False))
        bANASAL.P12 = CBool(IIf(dt1.Rows(11).Item("Disabled").ToString = "0", True, False))
        bANASAL.P13 = CBool(IIf(dt1.Rows(12).Item("Disabled").ToString = "0", True, False))
        bANASAL.P14 = CBool(IIf(dt1.Rows(13).Item("Disabled").ToString = "0", True, False))
        bANASAL.P15 = CBool(IIf(dt1.Rows(14).Item("Disabled").ToString = "0", True, False))
        bANASAL.P16 = CBool(IIf(dt1.Rows(15).Item("Disabled").ToString = "0", True, False))
        bANASAL.P17 = CBool(IIf(dt1.Rows(16).Item("Disabled").ToString = "0", True, False))
        bANASAL.P18 = CBool(IIf(dt1.Rows(17).Item("Disabled").ToString = "0", True, False))
        bANASAL.P19 = CBool(IIf(dt1.Rows(18).Item("Disabled").ToString = "0", True, False))
        bANASAL.P20 = CBool(IIf(dt1.Rows(19).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_P01ID).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_P02ID).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_P03ID).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_P04ID).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_P05ID).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_P06ID).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_P07ID).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_P08ID).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_P09ID).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_P10ID).Caption = dt1.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_P11ID).Caption = dt1.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_P12ID).Caption = dt1.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_P13ID).Caption = dt1.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_P14ID).Caption = dt1.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_P15ID).Caption = dt1.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_P16ID).Caption = dt1.Rows(15).Item("Short").ToString
        tdbg.Columns(COL_P17ID).Caption = dt1.Rows(16).Item("Short").ToString
        tdbg.Columns(COL_P18ID).Caption = dt1.Rows(17).Item("Short").ToString
        tdbg.Columns(COL_P19ID).Caption = dt1.Rows(18).Item("Short").ToString
        tdbg.Columns(COL_P20ID).Caption = dt1.Rows(19).Item("Short").ToString

        For i As Integer = COL_BASE01 To COL_P20ID
            tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next
    End Sub

    Private Sub ClickButton(ByVal button As Button)

        btnSalaryCoefficientBase.Enabled = Math.Abs(button - button.SalaryCoefficientBase) > 0
        btnSalaryLevelOfficialTitle.Enabled = Math.Abs(button - button.SalaryLevelOfficialTitle) > 0
        btnAnalyseSalary.Enabled = Math.Abs(button - button.AnalyseSalary) > 0
        btnSalaryPaymentMethod.Enabled = Math.Abs(button - button.SalaryPaymentMethod) > 0

        tdbg.Splits(1).DisplayColumns(COL_TaxObjectID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(1).DisplayColumns(COL_TaxObjectName).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(1).DisplayColumns(COL_BASE01).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE01
        tdbg.Splits(1).DisplayColumns(COL_BASE02).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE02
        tdbg.Splits(1).DisplayColumns(COL_BASE03).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE03
        tdbg.Splits(1).DisplayColumns(COL_BASE04).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bBA.BASE04
        tdbg.Splits(1).DisplayColumns(COL_CE01).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE01
        tdbg.Splits(1).DisplayColumns(COL_CE02).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE02
        tdbg.Splits(1).DisplayColumns(COL_CE03).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE03
        tdbg.Splits(1).DisplayColumns(COL_CE04).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE04
        tdbg.Splits(1).DisplayColumns(COL_CE05).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE05
        tdbg.Splits(1).DisplayColumns(COL_CE06).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE06
        tdbg.Splits(1).DisplayColumns(COL_CE07).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE07
        tdbg.Splits(1).DisplayColumns(COL_CE08).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE08
        tdbg.Splits(1).DisplayColumns(COL_CE09).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE09
        tdbg.Splits(1).DisplayColumns(COL_CE10).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0 And bCE.CE10

        tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC1
        tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC10
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC11
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient12).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC12
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient13).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC13
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient14).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC14
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient15).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC15

        tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC2
        tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC20
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient2).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC21
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient22).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC22
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient23).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC23
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient24).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC24
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient25).Visible = Math.Abs(button - button.SalaryLevelOfficialTitle) = 0 And bOL.OLSC25

        For i As Integer = COL_TaxObjectID To COL_SaCoefficient25
            tdbg.Splits(1).DisplayColumns(i).Locked = True
            tdbg.Splits(1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Next

        tdbg.Splits(1).DisplayColumns(COL_P01ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P01
        tdbg.Splits(1).DisplayColumns(COL_P02ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P02
        tdbg.Splits(1).DisplayColumns(COL_P03ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P03
        tdbg.Splits(1).DisplayColumns(COL_P04ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P04
        tdbg.Splits(1).DisplayColumns(COL_P05ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P05
        tdbg.Splits(1).DisplayColumns(COL_P06ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P06
        tdbg.Splits(1).DisplayColumns(COL_P07ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P07
        tdbg.Splits(1).DisplayColumns(COL_P08ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P08
        tdbg.Splits(1).DisplayColumns(COL_P09ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P09
        tdbg.Splits(1).DisplayColumns(COL_P10ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P10
        tdbg.Splits(1).DisplayColumns(COL_P11ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P11
        tdbg.Splits(1).DisplayColumns(COL_P12ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P12
        tdbg.Splits(1).DisplayColumns(COL_P13ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P13
        tdbg.Splits(1).DisplayColumns(COL_P14ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P14
        tdbg.Splits(1).DisplayColumns(COL_P15ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P15
        tdbg.Splits(1).DisplayColumns(COL_P16ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P16
        tdbg.Splits(1).DisplayColumns(COL_P17ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P17
        tdbg.Splits(1).DisplayColumns(COL_P18ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P18
        tdbg.Splits(1).DisplayColumns(COL_P19ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P19
        tdbg.Splits(1).DisplayColumns(COL_P20ID).Visible = Math.Abs(button - button.AnalyseSalary) = 0 And bANASAL.P20

        For i As Integer = COL_PaymentMethod To COL_AccountHolderName2
            tdbg.Splits(1).DisplayColumns(i).Visible = Math.Abs(button - button.SalaryPaymentMethod) = 0
        Next

    End Sub

    Private Sub btnSalaryCoefficientBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryCoefficientBase.Click
        tdbg.Splits(1).Caption = rL3("Luong_co_ban_He_so")
        ClickButton(Button.SalaryCoefficientBase)
    End Sub

    Private Sub btnSalaryLevelOfficialTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryLevelOfficialTitle.Click
        tdbg.Splits(1).Caption = rL3("Ngach_bac_luong")
        ClickButton(Button.SalaryLevelOfficialTitle)
    End Sub

    Private Sub btnAnalyseSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyseSalary.Click
        tdbg.Splits(1).Caption = "Maõ phaân tích tieàn löông"
        ClickButton(Button.AnalyseSalary)
    End Sub

    Private Sub btnSalaryPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalaryPaymentMethod.Click
        tdbg.Splits(1).Caption = "Phöông phaùp traû löông"
        ClickButton(Button.SalaryPaymentMethod)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4050
    '# Created User: DUCTRONG
    '# Created Date: 27/04/2009 10:49:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4050 "
        sSQL &= SQLDateSave(Date.Today) & COMMA 'ReportDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(IIf(gbUnicode, ConvertVniToUnicode(rL3("HO_SO_LUONG_NHAN_VIENV")), rL3("HO_SO_LUONG_NHAN_VIENV"))) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_departmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(_sFind) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(_showAll) & COMMA 'ShowAll, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString("%") & COMMA
        sSQL &= SQLString("%") & COMMA
        sSQL &= SQLString(gsLanguage) & COMMA
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_BankID
                If bIsNotInList Then
                    tdbg.Columns(COL_BankID).Text = ""
                    tdbg.Columns(COL_BranchName).Text = ""
                End If
            Case COL_BankID2
                If bIsNotInList Then
                    tdbg.Columns(COL_BankID2).Text = ""
                    tdbg.Columns(COL_BranchName2).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_TaxObjectID
                If tdbg.Columns(COL_TaxObjectID).Text <> tdbdTaxObjectID.Columns("TaxObjectID").Text Then
                    tdbg.Columns(COL_TaxObjectID).Text = ""
                    tdbg.Columns(COL_TaxObjectName).Text = ""
                End If
            Case COL_BASE01
                If Not L3IsNumeric(tdbg.Columns(COL_BASE01).Text) Then e.Cancel = True
            Case COL_BASE02
                If Not L3IsNumeric(tdbg.Columns(COL_BASE02).Text) Then e.Cancel = True
            Case COL_BASE03
                If Not L3IsNumeric(tdbg.Columns(COL_BASE03).Text) Then e.Cancel = True
            Case COL_BASE04
                If Not L3IsNumeric(tdbg.Columns(COL_BASE04).Text) Then e.Cancel = True
            Case COL_CE01
                If Not L3IsNumeric(tdbg.Columns(COL_CE01).Text) Then e.Cancel = True
            Case COL_CE02
                If Not L3IsNumeric(tdbg.Columns(COL_CE02).Text) Then e.Cancel = True
            Case COL_CE03
                If Not L3IsNumeric(tdbg.Columns(COL_CE03).Text) Then e.Cancel = True
            Case COL_CE04
                If Not L3IsNumeric(tdbg.Columns(COL_CE04).Text) Then e.Cancel = True
            Case COL_CE05
                If Not L3IsNumeric(tdbg.Columns(COL_CE05).Text) Then e.Cancel = True
            Case COL_CE06
                If Not L3IsNumeric(tdbg.Columns(COL_CE06).Text) Then e.Cancel = True
            Case COL_CE07
                If Not L3IsNumeric(tdbg.Columns(COL_CE07).Text) Then e.Cancel = True
            Case COL_CE08
                If Not L3IsNumeric(tdbg.Columns(COL_CE08).Text) Then e.Cancel = True
            Case COL_CE09
                If Not L3IsNumeric(tdbg.Columns(COL_CE09).Text) Then e.Cancel = True
            Case COL_CE10
                If Not L3IsNumeric(tdbg.Columns(COL_CE10).Text) Then e.Cancel = True
            Case COL_OfficalTitleID
                If tdbg.Columns(COL_OfficalTitleID).Text <> tdbdOfficialTitleID1.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COL_OfficalTitleID).Text = ""
                    tdbg.Columns(COL_SalaryLevelID).Text = ""
                    tdbg.Columns(COL_SaCoefficient).Text = ""
                    tdbg.Columns(COL_SaCoefficient12).Text = ""
                    tdbg.Columns(COL_SaCoefficient13).Text = ""
                    tdbg.Columns(COL_SaCoefficient14).Text = ""
                    tdbg.Columns(COL_SaCoefficient15).Text = ""
                End If
            Case COL_SalaryLevelID
                If tdbg.Columns(COL_SalaryLevelID).Text <> tdbdSalaryLevelID1.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COL_SalaryLevelID).Text = ""
                    tdbg.Columns(COL_SaCoefficient).Text = ""
                    tdbg.Columns(COL_SaCoefficient12).Text = ""
                    tdbg.Columns(COL_SaCoefficient13).Text = ""
                    tdbg.Columns(COL_SaCoefficient14).Text = ""
                    tdbg.Columns(COL_SaCoefficient15).Text = ""
                End If
            Case COL_OfficalTitleID2
                If tdbg.Columns(COL_OfficalTitleID2).Text <> tdbdOfficialTitleID2.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COL_OfficalTitleID2).Text = ""
                    tdbg.Columns(COL_SalaryLevelID2).Text = ""
                    tdbg.Columns(COL_SaCoefficient2).Text = ""
                    tdbg.Columns(COL_SaCoefficient22).Text = ""
                    tdbg.Columns(COL_SaCoefficient23).Text = ""
                    tdbg.Columns(COL_SaCoefficient24).Text = ""
                    tdbg.Columns(COL_SaCoefficient25).Text = ""
                End If
            Case COL_SalaryLevelID2
                If tdbg.Columns(COL_SalaryLevelID2).Text <> tdbdSalaryLevelID2.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COL_SalaryLevelID2).Text = ""
                    tdbg.Columns(COL_SaCoefficient2).Text = ""
                    tdbg.Columns(COL_SaCoefficient22).Text = ""
                    tdbg.Columns(COL_SaCoefficient23).Text = ""
                    tdbg.Columns(COL_SaCoefficient24).Text = ""
                    tdbg.Columns(COL_SaCoefficient25).Text = ""
                End If
            Case COL_P01ID
                If tdbg.Columns(COL_P01ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P01ID).Text = ""
                End If
            Case COL_P02ID
                If tdbg.Columns(COL_P02ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P02ID).Text = ""
                End If
            Case COL_P03ID
                If tdbg.Columns(COL_P03ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P03ID).Text = ""
                End If
            Case COL_P04ID
                If tdbg.Columns(COL_P04ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P04ID).Text = ""
                End If
            Case COL_P05ID
                If tdbg.Columns(COL_P05ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P05ID).Text = ""
                End If
            Case COL_P06ID
                If tdbg.Columns(COL_P06ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P06ID).Text = ""
                End If
            Case COL_P07ID
                If tdbg.Columns(COL_P07ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P07ID).Text = ""
                End If
            Case COL_P08ID
                If tdbg.Columns(COL_P08ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P08ID).Text = ""
                End If
            Case COL_P09ID
                If tdbg.Columns(COL_P09ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P09ID).Text = ""
                End If
            Case COL_P10ID
                If tdbg.Columns(COL_P10ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P10ID).Text = ""
                End If
            Case COL_P11ID
                If tdbg.Columns(COL_P11ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P11ID).Text = ""
                End If
            Case COL_P12ID
                If tdbg.Columns(COL_P12ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P12ID).Text = ""
                End If
            Case COL_P13ID
                If tdbg.Columns(COL_P13ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P13ID).Text = ""
                End If
            Case COL_P14ID
                If tdbg.Columns(COL_P14ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P14ID).Text = ""
                End If
            Case COL_P15ID
                If tdbg.Columns(COL_P15ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P15ID).Text = ""
                End If
            Case COL_P16ID
                If tdbg.Columns(COL_P16ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P16ID).Text = ""
                End If
            Case COL_P17ID
                If tdbg.Columns(COL_P17ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P17ID).Text = ""
                End If
            Case COL_P18ID
                If tdbg.Columns(COL_P18ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P18ID).Text = ""
                End If
            Case COL_P19ID
                If tdbg.Columns(COL_P19ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P19ID).Text = ""
                End If
            Case COL_P20ID
                If tdbg.Columns(COL_P20ID).Text <> tdbdPAnaID.Columns("PAnaID").Text Then
                    tdbg.Columns(COL_P20ID).Text = ""
                End If
            Case COL_PaymentMethod
                If tdbg.Columns(COL_PaymentMethod).Text <> tdbdPaymentMethod.Columns("PaymentMethod").Text Then
                    tdbg.Columns(COL_PaymentMethod).Text = ""
                End If
            Case COL_BankID
                If tdbg.Columns(COL_BankID).Text <> tdbdBankID1.Columns("BankID").Text Then
                    bIsNotInList = True
                Else
                    bIsNotInList = False
                End If
            Case COL_BankID2
                If tdbg.Columns(COL_BankID2).Text <> tdbdBankID2.Columns("BankID").Text Then
                    bIsNotInList = True
                Else
                    bIsNotInList = False
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_TaxObjectID
                tdbg.Columns(COL_TaxObjectID).Text = tdbdTaxObjectID.Columns("TaxObjectID").Text
                tdbg.Columns(COL_TaxObjectName).Text = tdbdTaxObjectID.Columns("TaxObjectName").Text
            Case COL_OfficalTitleID
                tdbg.Columns(COL_OfficalTitleID).Text = tdbdOfficialTitleID1.Columns("OfficialTitleID").Text
                tdbg.Columns(COL_SalaryLevelID).Text = ""
                tdbg.Columns(COL_SaCoefficient).Text = ""
                tdbg.Columns(COL_SaCoefficient12).Text = ""
                tdbg.Columns(COL_SaCoefficient13).Text = ""
                tdbg.Columns(COL_SaCoefficient14).Text = ""
                tdbg.Columns(COL_SaCoefficient15).Text = ""
            Case COL_SalaryLevelID
                tdbg.Columns(COL_SalaryLevelID).Text = tdbdSalaryLevelID1.Columns("SalaryLevelID").Text
                tdbg.Columns(COL_SaCoefficient).Text = tdbdSalaryLevelID1.Columns("SalaryCoefficient").Text
                tdbg.Columns(COL_SaCoefficient12).Text = tdbdSalaryLevelID1.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COL_SaCoefficient13).Text = tdbdSalaryLevelID1.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COL_SaCoefficient14).Text = tdbdSalaryLevelID1.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COL_SaCoefficient15).Text = tdbdSalaryLevelID1.Columns("SalaryCoefficient05").Text
            Case COL_OfficalTitleID2
                tdbg.Columns(COL_OfficalTitleID2).Text = tdbdOfficialTitleID2.Columns("OfficialTitleID").Text
                tdbg.Columns(COL_SalaryLevelID2).Text = ""
                tdbg.Columns(COL_SaCoefficient2).Text = ""
                tdbg.Columns(COL_SaCoefficient22).Text = ""
                tdbg.Columns(COL_SaCoefficient23).Text = ""
                tdbg.Columns(COL_SaCoefficient24).Text = ""
                tdbg.Columns(COL_SaCoefficient25).Text = ""
            Case COL_SalaryLevelID2
                tdbg.Columns(COL_SalaryLevelID2).Text = tdbdSalaryLevelID2.Columns("SalaryLevelID").Text
                tdbg.Columns(COL_SaCoefficient2).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient").Text
                tdbg.Columns(COL_SaCoefficient22).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient02").Text
                tdbg.Columns(COL_SaCoefficient23).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient03").Text
                tdbg.Columns(COL_SaCoefficient24).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient04").Text
                tdbg.Columns(COL_SaCoefficient25).Text = tdbdSalaryLevelID2.Columns("SalaryCoefficient05").Text
            Case COL_P01ID
                tdbg.Columns(COL_P01ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P02ID
                tdbg.Columns(COL_P02ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P03ID
                tdbg.Columns(COL_P03ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P04ID
                tdbg.Columns(COL_P04ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P05ID
                tdbg.Columns(COL_P05ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P06ID
                tdbg.Columns(COL_P06ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P07ID
                tdbg.Columns(COL_P07ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P08ID
                tdbg.Columns(COL_P08ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P09ID
                tdbg.Columns(COL_P09ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P10ID
                tdbg.Columns(COL_P10ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P11ID
                tdbg.Columns(COL_P11ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P12ID
                tdbg.Columns(COL_P12ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P13ID
                tdbg.Columns(COL_P13ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P14ID
                tdbg.Columns(COL_P14ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P15ID
                tdbg.Columns(COL_P15ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P16ID
                tdbg.Columns(COL_P16ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P17ID
                tdbg.Columns(COL_P17ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P18ID
                tdbg.Columns(COL_P18ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P19ID
                tdbg.Columns(COL_P19ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_P20ID
                tdbg.Columns(COL_P20ID).Text = tdbdPAnaID.Columns("PAnaID").Text
            Case COL_PaymentMethod
                tdbg.Columns(COL_PaymentMethod).Text = tdbdPaymentMethod.Columns("PaymentMethod").Text
            Case COL_BankID
                'tdbg.Columns(COL_BankID).Text = tdbdBankID1.Columns("BankID").Text
                tdbg.Columns(COL_BranchName).Text = tdbdBankID1.Columns("BranchName").Text
            Case COL_BankID2
                'tdbg.Columns(COL_BankID2).Text = tdbdBankID2.Columns("BankID").Text
                tdbg.Columns(COL_BranchName2).Text = tdbdBankID2.Columns("BranchName").Text
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_SalaryLevelID
                LoadtdbdSalaryLevelID1(tdbg(tdbg.Row, COL_OfficalTitleID).ToString)
            Case COL_SalaryLevelID2
                LoadtdbdSalaryLevelID2(tdbg(tdbg.Row, COL_OfficalTitleID2).ToString)
            Case COL_P01ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(0).Item("Code").ToString)
            Case COL_P02ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(1).Item("Code").ToString)
            Case COL_P03ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(2).Item("Code").ToString)
            Case COL_P04ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(3).Item("Code").ToString)
            Case COL_P05ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(4).Item("Code").ToString)
            Case COL_P06ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(5).Item("Code").ToString)
            Case COL_P07ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(6).Item("Code").ToString)
            Case COL_P08ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(7).Item("Code").ToString)
            Case COL_P09ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(8).Item("Code").ToString)
            Case COL_P10ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(9).Item("Code").ToString)
            Case COL_P11ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(10).Item("Code").ToString)
            Case COL_P12ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(11).Item("Code").ToString)
            Case COL_P13ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(12).Item("Code").ToString)
            Case COL_P14ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(13).Item("Code").ToString)
            Case COL_P15ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(14).Item("Code").ToString)
            Case COL_P16ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(15).Item("Code").ToString)
            Case COL_P17ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(16).Item("Code").ToString)
            Case COL_P18ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(17).Item("Code").ToString)
            Case COL_P19ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(18).Item("Code").ToString)
            Case COL_P20ID
                LoadtdbdPAnaID(dtPAnaCategoryID.Rows(19).Item("Code").ToString)
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Col
            Case COL_ExchangeDep, COL_BankAccountNo, COL_AccountHolderName, COL_ExchangeDep2, COL_BankAccountNo2, COL_AccountHolderName2
                If tdbg.Columns(COL_PaymentMethod).Text = "C" Or tdbg.Columns(COL_PaymentMethod).Text = "O" Then
                    tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Locked = True
                    e.CellStyle.Locked = True
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Locked = False
                    e.CellStyle.Locked = False
                End If
            Case COL_BankID
                If tdbg.Columns(COL_PaymentMethod).Text = "C" Or tdbg.Columns(COL_PaymentMethod).Text = "O" Then
                    e.CellStyle.Locked = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).Locked = True
                    tdbg.Columns(COL_BankID).DropDown = Nothing
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).AutoDropDown = False
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).AutoComplete = False
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).Locked = False
                    e.CellStyle.Locked = False
                    tdbg.Columns(COL_BankID).DropDown = tdbdBankID1
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).AutoDropDown = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID).AutoComplete = True
                End If
            Case COL_BankID2
                If tdbg.Columns(COL_PaymentMethod).Text = "C" Or tdbg.Columns(COL_PaymentMethod).Text = "O" Then
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).Locked = True
                    e.CellStyle.Locked = True
                    tdbg.Columns(COL_BankID2).DropDown = Nothing
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).AutoDropDown = False
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).AutoComplete = False
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).Locked = False
                    e.CellStyle.Locked = False
                    tdbg.Columns(COL_BankID2).DropDown = tdbdBankID2
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).AutoDropDown = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_BankID2).AutoComplete = True
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_DepartmentID, COL_DepartmentName, COL_TeamID, COL_TeamName, COL_EmployeeID, COL_FullName, COL_TaxObjectName, COL_BranchName, COL_BranchName2
            Case COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15
            Case COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25
            Case COL_OfficalTitleID, COL_OfficalTitleID2
                CopyColumns(tdbg, tdbg.Col, tdbg.Row, 7, tdbg.Columns(tdbg.Col).Text)
            Case COL_SalaryLevelID, COL_SalaryLevelID2
                CopyColumns(tdbg, tdbg.Col, tdbg.Row, 6, tdbg.Columns(tdbg.Col).Text)
            Case COL_BankID, COL_BankID2, COL_TaxObjectID
                CopyColumns(tdbg, tdbg.Col, tdbg.Row, 2, tdbg.Columns(tdbg.Col).Text)
            Case Else
                CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_BASE01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE06
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE07
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE08
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE09
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_DepartmentID, COL_DepartmentName, COL_TeamID, COL_TeamName, COL_EmployeeID, COL_FullName, COL_TaxObjectName, COL_BranchName, COL_BranchName2
                Case COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15
                Case COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25
                Case COL_OfficalTitleID, COL_OfficalTitleID2
                    CopyColumns(tdbg, tdbg.Col, tdbg.Row, 7, tdbg.Columns(tdbg.Col).Text)
                Case COL_SalaryLevelID, COL_SalaryLevelID2
                    CopyColumns(tdbg, tdbg.Col, tdbg.Row, 6, tdbg.Columns(tdbg.Col).Text)
                Case COL_BankID, COL_BankID2, COL_TaxObjectID
                    CopyColumns(tdbg, tdbg.Col, tdbg.Row, 2, tdbg.Columns(tdbg.Col).Text)
                Case Else
                    CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
            End Select
        End If
    End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
    '    'If Not AllowSave() Then Exit Sub

    '    'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

    '    btnSave.Enabled = False
    '    btnClose.Enabled = False

    '    Me.Cursor = Cursors.WaitCursor
    '    Dim sSQL As String = ""

    '    Dim bRunSQL As Boolean = ExecuteSQL(SQLUpdateD13T0201s.ToString)
    '    Me.Cursor = Cursors.Default

    '    If bRunSQL Then
    '        sSQL = "Select 	 PayrollVoucherID, PayrollVoucherNo, VoucherTypeID, VoucherDate, "
    '        sSQL &= "Description, CreateUserID, LastModifyUserID" & vbCrLf
    '        sSQL &= "From   D13T0100" & vbCrLf
    '        sSQL &= "Where 	 DivisionID = " & SQLString(gsDivisionID) & vbCrLf
    '        sSQL &= "And TranMonth = " & SQLString(giTranMonth) & vbCrLf
    '        sSQL &= "And TranYear = " & SQLString(giTranYear)

    '        Dim dt As DataTable
    '        dt = ReturnDataTable(sSQL)

    '        If dt.Rows.Count > 0 Then
    '            If D99C0008.Msg(rl3("Ban_co_muon_cap_nhat_thong_tin_ho_so_luong_thang_khong"), IIf(gsLanguage = "84", "Th¤ng bÀo", "Announcement").ToString, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                Dim bIsUpdate As Boolean = False
    '                If dt.Rows.Count = 1 Then
    '                    sPayrollVoucherID = dt.Rows(0).Item("PayrollVoucherID").ToString()
    '                    sPayrollVoucherNo = dt.Rows(0).Item("PayrollVoucherNo").ToString()
    '                    sVoucherTypeID = dt.Rows(0).Item("VoucherTypeID").ToString()
    '                    sVoucherDate = dt.Rows(0).Item("VoucherDate").ToString()
    '                    sDescription = dt.Rows(0).Item("Description").ToString()
    '                    sCreateUserID = dt.Rows(0).Item("CreateUserID").ToString()
    '                    sLastModifyUserID = dt.Rows(0).Item("LastModifyUserID").ToString()

    '                    bIsUpdate = True
    '                Else
    '                    Dim f As New D13F1037
    '                    f.ShowDialog()
    '                    f.Dispose()
    '                    sPayrollVoucherID = f.PayrollVoucherID
    '                    sPayrollVoucherNo = f.PayrollVoucherNo
    '                    sVoucherTypeID = f.VoucherTypeID
    '                    sVoucherDate = f.VoucherDate
    '                    sDescription = f.Description
    '                    sCreateUserID = f.CreateUserID
    '                    sLastModifyUserID = f.LastModifyUserID

    '                    If f.IsChoose Then bIsUpdate = True
    '                End If

    '                If bIsUpdate Then
    '                    For i As Integer = 0 To tdbg.RowCount - 1
    '                        If ExistRecord("SELECT TOP 1 1 FROM D13T0101 WHERE EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID)) & "AND PayrollVoucherID = " & SQLString(sPayrollVoucherID)) Then
    '                            ExecuteSQL(SQLStoreD13P0110(tdbg(i, COL_EmployeeID).ToString))
    '                        Else
    '                            ExecuteSQL(SQLStoreD13P0100(tdbg(i, COL_EmployeeID).ToString, tdbg(i, COL_DepartmentID).ToString))
    '                        End If
    '                    Next i
    '                End If
    '            End If
    '        End If

    '        sSQL = ""
    '        'CẬP NHẬT LẠI HSBH GỐC CHO TỪNG NV
    '        For i As Integer = 0 To tdbg.RowCount - 1
    '            sSQL &= SQLStoreD21P4070(tdbg(i, COL_EmployeeID).ToString) & vbCrLf
    '        Next i
    '        ExecuteSQL(sSQL)

    '        'HS BẢO HIỂM THÁNG
    '        sSQL = ""
    '        If ExistRecord("SELECT TOP 1 1 FROM D21T2010 WHERE TranMonth = " & Number(giTranMonth) & " And TranYear = " & Number(giTranYear)) Then
    '            If D99C0008.Msg(rl3("Ban_co_muon_cap_nhat_ho_so_bao_hiem_thang_khong"), IIf(gsLanguage = "84", "Th¤ng bÀo", "Announcement").ToString, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                sSQL &= "Create Table #D21T2001(EmployeeID Varchar(20))" & vbCrLf
    '                For i As Integer = 0 To tdbg.RowCount - 1
    '                    'Xoa Nhan vien trong ho so BH thang
    '                    sSQL &= SQLDeleteD21T2010(tdbg(i, COL_EmployeeID).ToString) & vbCrLf
    '                    'Add lai nhan vien va tinh lai muc nop cho ho so BH thang
    '                    sSQL &= "Insert Into #D21T2001(EmployeeID) Values (" & SQLString(tdbg(i, COL_EmployeeID)) & ")" & vbCrLf
    '                Next i
    '                sSQL &= SQLStoreD21P2001() & vbCrLf
    '                sSQL &= "Drop Table #D21T2001" & vbCrLf
    '                ExecuteSQL(sSQL)
    '            End If
    '        End If




    '        SaveOK()
    '        _bSaved = True
    '        btnClose.Enabled = True

    '        btnSave.Enabled = True
    '        btnClose.Focus()
    '    Else
    '        SaveNotOK()
    '        btnClose.Enabled = True
    '        btnSave.Enabled = True
    '    End If
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False
        Dim sSQL As String = ""

        Me.Cursor = Cursors.WaitCursor

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL &= SQLStoreD09P6200s(0, i).ToString()
            sSQL &= SQLUpdateD13T0201s(i).ToString()
            sSQL &= SQLStoreD09P6200s(1, i).ToString()
            sSQL &= SQLStoreD09P6210s(i).ToString()
        Next

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then

            SaveOK()
            _bSaved = True
            btnClose.Enabled = True

            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

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

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD21T2010
    '# Created User: DUCTRONG
    '# Created Date: 22/05/2009 10:32:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD21T2010(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D21T2010"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(sEmployeeID) & " And "
        sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
        sSQL &= "TranYear = " & SQLNumber(giTranYear)
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
    Private Function SQLStoreD21P4070(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D21P4070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
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
    '# Title: SQLStoreD13P0110
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 07:58:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0110(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0110 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0100
    '# Created User: MINHDUNG
    '# Created Date: 11/11/2009
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0100(ByVal sEmployeeID As String, ByVal sDepartmentID As String) As String
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
        sSQL &= SQLString(sDepartmentID) & COMMA 'AllDepartmentID, varchar[2000], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'OldPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsAddFromMaster, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IgnoreSub, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsSpecialProcessing, tinyint, NOT NULL
        sSQL &= SQLString(sEmployeeID) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201s
    '# Created User: DUCTRONG
    '# Created Date: 28/04/2009 10:43:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201s(ByVal i As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        'For i As Integer = 0 To tdbg.RowCount - 1
        sSQL.Append("Update D13T0201 Set ")
        sSQL.Append("BaseSalary01 = " & SQLMoney(tdbg(i, COL_BASE01), D13FormatSalary.BASE01) & COMMA) 'decimal, NOT NULL
        sSQL.Append("BaseSalary02 = " & SQLMoney(tdbg(i, COL_BASE02), D13FormatSalary.BASE02) & COMMA) 'decimal, NOT NULL
        sSQL.Append("BaseSalary03 = " & SQLMoney(tdbg(i, COL_BASE03), D13FormatSalary.BASE03) & COMMA) 'decimal, NOT NULL
        sSQL.Append("BaseSalary04 = " & SQLMoney(tdbg(i, COL_BASE04), D13FormatSalary.BASE04) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient01 = " & SQLMoney(tdbg(i, COL_CE01), D13FormatSalary.CE01) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient02 = " & SQLMoney(tdbg(i, COL_CE02), D13FormatSalary.CE02) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient03 = " & SQLMoney(tdbg(i, COL_CE03), D13FormatSalary.CE03) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient04 = " & SQLMoney(tdbg(i, COL_CE04), D13FormatSalary.CE04) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient05 = " & SQLMoney(tdbg(i, COL_CE05), D13FormatSalary.CE05) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient06 = " & SQLMoney(tdbg(i, COL_CE06), D13FormatSalary.CE06) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient07 = " & SQLMoney(tdbg(i, COL_CE07), D13FormatSalary.CE07) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient08 = " & SQLMoney(tdbg(i, COL_CE08), D13FormatSalary.CE08) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient09 = " & SQLMoney(tdbg(i, COL_CE09), D13FormatSalary.CE09) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SalCoefficient10 = " & SQLMoney(tdbg(i, COL_CE10), D13FormatSalary.CE10) & COMMA) 'decimal, NOT NULL

        sSQL.Append("TaxObjectID = " & SQLString(tdbg(i, COL_TaxObjectID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("PaymentMethod = " & SQLString(tdbg(i, COL_PaymentMethod)) & COMMA) 'varchar[1], NOT NULL
        sSQL.Append("BankID = " & SQLString(tdbg(i, COL_BankID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("BankAccountNo = " & SQLString(tdbg(i, COL_BankAccountNo)) & COMMA) 'varchar[50], NULL

        sSQL.Append("ExchangeDep = " & SQLStringUnicode(tdbg(i, COL_ExchangeDep).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ExchangeDepU = " & SQLStringUnicode(tdbg(i, COL_ExchangeDep).ToString, gbUnicode, True) & COMMA) 'varchar[250], NULL

        sSQL.Append("AccountHolderName = " & SQLStringUnicode(tdbg(i, COL_AccountHolderName).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("AccountHolderNameU = " & SQLStringUnicode(tdbg(i, COL_AccountHolderName).ToString, gbUnicode, True) & COMMA) 'varchar[250], NULL

        sSQL.Append("BankID2 = " & SQLString(tdbg(i, COL_BankID2)) & COMMA) 'varchar[20], NULL
        sSQL.Append("BankAccountNo2 = " & SQLString(tdbg(i, COL_BankAccountNo2)) & COMMA) 'varchar[50], NULL
        sSQL.Append("ExchangeDep2 = " & SQLStringUnicode(tdbg(i, COL_ExchangeDep2).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ExchangeDep2U = " & SQLStringUnicode(tdbg(i, COL_ExchangeDep2).ToString, gbUnicode, True) & COMMA) 'varchar[250], NULL

        sSQL.Append("AccountHolderName2 = " & SQLStringUnicode(tdbg(i, COL_AccountHolderName2).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("AccountHolderName2U = " & SQLStringUnicode(tdbg(i, COL_AccountHolderName2).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL

        sSQL.Append("OfficalTitleID = " & SQLString(tdbg(i, COL_OfficalTitleID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("SalaryLevelID = " & SQLString(tdbg(i, COL_SalaryLevelID)) & COMMA) 'varchar[20], NULL
        sSQL.Append("SaCoefficient = " & SQLMoney(tdbg(i, COL_SaCoefficient)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("OfficalTitleID2 = " & SQLString(tdbg(i, COL_OfficalTitleID2)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("SalaryLevelID2 = " & SQLString(tdbg(i, COL_SalaryLevelID2)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("SaCoefficient2 = " & SQLMoney(tdbg(i, COL_SaCoefficient2)) & COMMA) 'decimal, NOT NULL

        sSQL.Append("SaCoefficient12 = " & SQLMoney(tdbg(i, COL_SaCoefficient12)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient13 = " & SQLMoney(tdbg(i, COL_SaCoefficient13)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient14 = " & SQLMoney(tdbg(i, COL_SaCoefficient14)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient15 = " & SQLMoney(tdbg(i, COL_SaCoefficient15)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient22 = " & SQLMoney(tdbg(i, COL_SaCoefficient22)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient23 = " & SQLMoney(tdbg(i, COL_SaCoefficient23)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient24 = " & SQLMoney(tdbg(i, COL_SaCoefficient24)) & COMMA) 'decimal, NOT NULL
        sSQL.Append("SaCoefficient25 = " & SQLMoney(tdbg(i, COL_SaCoefficient25)) & COMMA) 'decimal, NOT NULL

        sSQL.Append("P01ID = " & SQLString(tdbg(i, COL_P01ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P02ID = " & SQLString(tdbg(i, COL_P02ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P03ID = " & SQLString(tdbg(i, COL_P03ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P04ID = " & SQLString(tdbg(i, COL_P04ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P05ID = " & SQLString(tdbg(i, COL_P05ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P06ID = " & SQLString(tdbg(i, COL_P06ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P07ID = " & SQLString(tdbg(i, COL_P07ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P08ID = " & SQLString(tdbg(i, COL_P08ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P09ID = " & SQLString(tdbg(i, COL_P09ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P10ID = " & SQLString(tdbg(i, COL_P10ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P11ID = " & SQLString(tdbg(i, COL_P11ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P12ID = " & SQLString(tdbg(i, COL_P12ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P13ID = " & SQLString(tdbg(i, COL_P13ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P14ID = " & SQLString(tdbg(i, COL_P14ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P15ID = " & SQLString(tdbg(i, COL_P15ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P16ID = " & SQLString(tdbg(i, COL_P16ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P17ID = " & SQLString(tdbg(i, COL_P17ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P18ID = " & SQLString(tdbg(i, COL_P18ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P19ID = " & SQLString(tdbg(i, COL_P19ID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("P20ID = " & SQLString(tdbg(i, COL_P20ID)) & COMMA) 'varchar[20], NOT NULL

        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL

        sSQL.Append(" Where ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
        sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID)))

        sRet.Append(sSQL.ToString & vbCrLf)
        sSQL.Remove(0, sSQL.Length)
        'Next
        Return sRet
    End Function

    ' Update 23/8/2012 incident 50602
    Private Sub HideButtonAnalyseSalary()
        btnAnalyseSalary.Visible = False
        btnSalaryLevelOfficialTitle.Left = btnSalaryPaymentMethod.Left - btnSalaryLevelOfficialTitle.Width - 6
        btnSalaryCoefficientBase.Left = btnSalaryLevelOfficialTitle.Left - btnSalaryCoefficientBase.Width - 6

        ' update lại số thứ tự
        btnSalaryPaymentMethod.Text = "3" & btnSalaryPaymentMethod.Text.Substring(1)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 19/08/2011 09:46:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6200s(ByVal iMode As Integer, ByVal i As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String

        sSQL = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13T0201") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString("EmployeeID") & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg(i, COL_EmployeeID).ToString) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("EmployeeID") & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(0) 'CodeTable, tinyint, NOT NULL
        sRet &= sSQL & vbCrLf

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 19/08/2011 09:48:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6210s(ByVal i As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String
        'For i As Integer = 0 To tdbg.RowCount - 1
        sSQL = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateSave(DateTime.Now()) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString("MasterSalaryFile") & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("02") & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg(i, COL_EmployeeID)) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sRet &= sSQL & vbCrLf
        'Next
        Return sRet
    End Function

End Class