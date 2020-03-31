Imports System
Imports System.Threading
Imports System.Xml

'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:40:51 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:40:51 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1030
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

	Private _formIDPermission As String = "D13F1030"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg"
    Private Const COL_EmployeeID As Integer = 0               ' Mã NV
    Private Const COL_FullName As Integer = 1                 ' Họ và Tên
    Private Const COL_BlockID As Integer = 2                  ' Khối
    Private Const COL_BlockName As Integer = 3                ' Tên khối
    Private Const COL_DepartmentID As Integer = 4             ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5           ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6                   ' Tổ nhóm
    Private Const COL_TeamName As Integer = 7                 ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8               ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 9             ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 10                  ' Chức vụ
    Private Const COL_DutyName As Integer = 11                ' Tên chức vụ
    Private Const COL_WorkID As Integer = 12                  ' Công việc
    Private Const COL_WorkName As Integer = 13                ' Tên công việc
    Private Const COL_Birthdate As Integer = 14               ' Ngày sinh
    Private Const COL_SexName As Integer = 15                 ' Giới tính
    Private Const COL_DateJoined As Integer = 16              ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 17                ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 18                     ' Tuổi
    Private Const COL_StatusID As Integer = 19                ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 20              ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 21        ' Mã thẽ chếm công
    Private Const COL_RefEmployeeID As Integer = 22           ' Mã NV phụ
    Private Const COL_IsNew As Integer = 23                   ' Nhân viên mới
    Private Const COL_PaymentMethodName As Integer = 24       ' Phương pháp trả lương
    Private Const COL_BankName As Integer = 25                ' Ngân hàng 1
    Private Const COL_Disabled As Integer = 26                ' Không sử dụng
    Private Const COL_SalEmpGroupName As Integer = 27         ' Nhóm lương
    Private Const COL_BASE01 As Integer = 28                  ' Mức lương 1
    Private Const COL_BASE01_DATE As Integer = 29             ' Ngày nhận mức lương 1
    Private Const COL_BASE02 As Integer = 30                  ' Mức lương  2
    Private Const COL_BASE02_DATE As Integer = 31             ' Ngày nhận mức lương 2
    Private Const COL_BASE03 As Integer = 32                  ' Mức lương 3
    Private Const COL_BASE03_DATE As Integer = 33             ' Ngày nhận mức lương 3
    Private Const COL_BASE04 As Integer = 34                  ' Mức lương 4
    Private Const COL_BASE04_DATE As Integer = 35             ' Ngày nhận mức lương 4
    Private Const COL_CE01 As Integer = 36                    ' Hệ số lương 1
    Private Const COL_CE01_DATE As Integer = 37               ' Ngày nhận hệ số lương 1
    Private Const COL_CE02 As Integer = 38                    ' Hệ số lương 2
    Private Const COL_CE02_DATE As Integer = 39               ' Ngày nhận hệ số lương 2
    Private Const COL_CE03 As Integer = 40                    ' Hệ số lương 3
    Private Const COL_CE03_DATE As Integer = 41               ' Ngày nhận hệ số lương 3
    Private Const COL_CE04 As Integer = 42                    ' Hệ số lương 4
    Private Const COL_CE04_DATE As Integer = 43               ' Ngày nhận hệ số lương 4
    Private Const COL_CE05 As Integer = 44                    ' Hệ số lương 5
    Private Const COL_CE05_DATE As Integer = 45               ' Ngày nhận hệ số lương 5
    Private Const COL_CE06 As Integer = 46                    ' Hệ số lương 6
    Private Const COL_CE06_DATE As Integer = 47               ' Ngày nhận hệ số lương 6
    Private Const COL_CE07 As Integer = 48                    ' Hệ số lương 7
    Private Const COL_CE07_DATE As Integer = 49               ' Ngày nhận hệ số lương 7
    Private Const COL_CE08 As Integer = 50                    ' Hệ số lương 8
    Private Const COL_CE08_DATE As Integer = 51               ' Ngày nhận hệ số lương 8
    Private Const COL_CE09 As Integer = 52                    ' Hệ số lương 9
    Private Const COL_CE09_DATE As Integer = 53               ' Ngày nhận hệ số lương 9
    Private Const COL_CE10 As Integer = 54                    ' Hệ số lương 10
    Private Const COL_CE10_DATE As Integer = 55               ' Ngày nhận hệ số lương 10
    Private Const COL_CE11 As Integer = 56                    ' CE11
    Private Const COL_CE11_DATE As Integer = 57               ' CE11_DATE
    Private Const COL_CE12 As Integer = 58                    ' CE12
    Private Const COL_CE12_DATE As Integer = 59               ' CE12_DATE
    Private Const COL_CE13 As Integer = 60                    ' CE13
    Private Const COL_CE13_DATE As Integer = 61               ' CE13_DATE
    Private Const COL_CE14 As Integer = 62                    ' CE14
    Private Const COL_CE14_DATE As Integer = 63               ' CE14_DATE
    Private Const COL_CE15 As Integer = 64                    ' CE15
    Private Const COL_CE15_DATE As Integer = 65               ' CE15_DATE
    Private Const COL_CE16 As Integer = 66                    ' CE16
    Private Const COL_CE16_DATE As Integer = 67               ' CE16_DATE
    Private Const COL_CE17 As Integer = 68                    ' CE17
    Private Const COL_CE17_DATE As Integer = 69               ' CE17_DATE
    Private Const COL_CE18 As Integer = 70                    ' CE18
    Private Const COL_CE18_DATE As Integer = 71               ' CE18_DATE
    Private Const COL_CE19 As Integer = 72                    ' CE19
    Private Const COL_CE19_DATE As Integer = 73               ' CE19_DATE
    Private Const COL_CE20 As Integer = 74                    ' CE20
    Private Const COL_CE20_DATE As Integer = 75               ' CE20_DATE
    Private Const COL_CreateUserID As Integer = 76            ' Người tạo
    Private Const COL_CreateDate As Integer = 77              ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 78        ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 79          ' Ngày cập nhật cuối cùng
    Private Const COL_NextBaseSalary01 As Integer = 80        ' NextBaseSalary01
    Private Const COL_NextBaseSalary02 As Integer = 81        ' NextBaseSalary02
    Private Const COL_NextBaseSalary03 As Integer = 82        ' NextBaseSalary03
    Private Const COL_NextBaseSalary04 As Integer = 83        ' NextBaseSalary04
    Private Const COL_BaseSalary01DateEnd As Integer = 84     ' BaseSalary01DateEnd
    Private Const COL_BaseSalary01NextDate As Integer = 85    ' BaseSalary01NextDate
    Private Const COL_BaseSalary02DateEnd As Integer = 86     ' BaseSalary02DateEnd
    Private Const COL_BaseSalary02NextDate As Integer = 87    ' BaseSalary02NextDate
    Private Const COL_BaseSalary03DateEnd As Integer = 88     ' BaseSalary03DateEnd
    Private Const COL_BaseSalary03NextDate As Integer = 89    ' BaseSalary03NextDate
    Private Const COL_BaseSalary04DateEnd As Integer = 90     ' BaseSalary04DateEnd
    Private Const COL_BaseSalary04NextDate As Integer = 91    ' BaseSalary04NextDate
    Private Const COL_OfficalTitleID As Integer = 92          ' Ngạch lương 1
    Private Const COL_SalaryLevelID As Integer = 93           ' Bậc lương 1
    Private Const COL_OLSC10_DATE As Integer = 94             ' Ngày nhận bậc lương 1
    Private Const COL_OffSa1DateEnd As Integer = 95           ' OffSa1DateEnd
    Private Const COL_OffSa1NextDate As Integer = 96          ' Ngày nhận bậc lương 1 tiếp theo
    Private Const COL_SaCoefficient As Integer = 97           ' Hệ số lương 01
    Private Const COL_SaCoefficient12 As Integer = 98         ' SaCoefficient12
    Private Const COL_SaCoefficient13 As Integer = 99         ' SaCoefficient13
    Private Const COL_SaCoefficient14 As Integer = 100        ' SaCoefficient14
    Private Const COL_SaCoefficient15 As Integer = 101        ' SaCoefficient15
    Private Const COL_OfficalTitleID2 As Integer = 102        ' Ngạch lương 2
    Private Const COL_SalaryLevelID2 As Integer = 103         ' Bậc lương 2
    Private Const COL_OLSC20_DATE As Integer = 104            ' Ngày nhận bậc lương 2
    Private Const COL_OffSa2DateEnd As Integer = 105          ' OffSa2DateEnd
    Private Const COL_OffSa2NextDate As Integer = 106         ' Ngày nhận bậc lương 2 tiếp theo
    Private Const COL_SaCoefficient2 As Integer = 107         ' Hệ số lương 02
    Private Const COL_SaCoefficient22 As Integer = 108        ' SaCoefficient22
    Private Const COL_SaCoefficient23 As Integer = 109        ' SaCoefficient23
    Private Const COL_SaCoefficient24 As Integer = 110        ' SaCoefficient24
    Private Const COL_SaCoefficient25 As Integer = 111        ' SaCoefficient25
    Private Const COL_NextOfficalTitleID As Integer = 112     ' NextOfficalTitleID
    Private Const COL_NextSalaryLevelID As Integer = 113      ' NextSalaryLevelID
    Private Const COL_NextOfficalTitleID2 As Integer = 114    ' NextOfficalTitleID2
    Private Const COL_NextSalaryLevelID2 As Integer = 115     ' NextSalaryLevelID2
    Private Const COL_NextSalaryCoefficient As Integer = 116  ' NextSalaryCoefficient
    Private Const COL_NextSalaryCoefficient2 As Integer = 117 ' NextSalaryCoefficient2
    Private Const COL_Sal01DateEnd As Integer = 118           ' Sal01DateEnd
    Private Const COL_Sal02DateEnd As Integer = 119           ' Sal02DateEnd
    Private Const COL_Sal03DateEnd As Integer = 120           ' Sal03DateEnd
    Private Const COL_Sal04DateEnd As Integer = 121           ' Sal04DateEnd
    Private Const COL_Sal05DateEnd As Integer = 122           ' Sal05DateEnd
    Private Const COL_Sal06DateEnd As Integer = 123           ' Sal06DateEnd
    Private Const COL_Sal07DateEnd As Integer = 124           ' Sal07DateEnd
    Private Const COL_Sal08DateEnd As Integer = 125           ' Sal08DateEnd
    Private Const COL_Sal09DateEnd As Integer = 126           ' Sal09DateEnd
    Private Const COL_Sal10DateEnd As Integer = 127           ' Sal10DateEnd
    Private Const COL_Sal01NextDate As Integer = 128          ' Sal01NextDate
    Private Const COL_Sal02NextDate As Integer = 129          ' Sal02NextDate
    Private Const COL_Sal03NextDate As Integer = 130          ' Sal03NextDate
    Private Const COL_Sal04NextDate As Integer = 131          ' Sal04NextDate
    Private Const COL_Sal05NextDate As Integer = 132          ' Sal05NextDate
    Private Const COL_Sal06NextDate As Integer = 133          ' Sal06NextDate
    Private Const COL_Sal07NextDate As Integer = 134          ' Sal07NextDate
    Private Const COL_Sal08NextDate As Integer = 135          ' Sal08NextDate
    Private Const COL_Sal09NextDate As Integer = 136          ' Sal09NextDate
    Private Const COL_Sal10NextDate As Integer = 137          ' Sal10NextDate
    Private Const COL_NextSalCoefficient01 As Integer = 138   ' NextSalCoefficient01
    Private Const COL_NextSalCoefficient02 As Integer = 139   ' NextSalCoefficient02
    Private Const COL_NextSalCoefficient03 As Integer = 140   ' NextSalCoefficient03
    Private Const COL_NextSalCoefficient04 As Integer = 141   ' NextSalCoefficient04
    Private Const COL_NextSalCoefficient05 As Integer = 142   ' NextSalCoefficient05
    Private Const COL_NextSalCoefficient06 As Integer = 143   ' NextSalCoefficient06
    Private Const COL_NextSalCoefficient07 As Integer = 144   ' NextSalCoefficient07
    Private Const COL_NextSalCoefficient08 As Integer = 145   ' NextSalCoefficient08
    Private Const COL_NextSalCoefficient09 As Integer = 146   ' NextSalCoefficient09
    Private Const COL_NextSalCoefficient10 As Integer = 147   ' NextSalCoefficient10
    Private Const COL_NumIDCard As Integer = 148              ' NumIDCard
    Private Const COL_Permission As Integer = 149             ' Permission
#End Region


    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Dim dtDepartmentID, dtTeamID, dtEmpGroupID As DataTable
    Private bBA As SALBA
    Private bCE As SALCE
    Private bOL As OLSC

    Dim bEditEnabled As Boolean = False 'Lưu Quyền Sửa đầu tiên khi load dữ liệu cho lưới

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master

    Private _employeeeID As String = ""
    Public Property EmployeeeID() As String 
        Get
            Return _employeeeID
        End Get
        Set(ByVal Value As String )
            _employeeeID = Value
        End Set
    End Property

    Private Sub CallD09U1111()
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_EmployeeID}
        AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)

        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , True, , gbUnicode)
    End Sub

    Private Sub D13F1030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnView_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub D13F1030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1, True)
        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg, 0, 1)

        '        'Update(31/7/2012) do gán sai định dạng các cột
        '        For i As Integer = COL_CE01_DATE To (COL_CE20_DATE + 1) Step 2
        '            tdbg.Columns(i).Editor = c1dateDate
        '        Next

        InputDateInTrueDBGrid(tdbg, COL_OffSa1NextDate, COL_OffSa2NextDate)

        LoadTDBCombo()
        SQLD13T9000()
        ShowColumns()
        LoadDefaultValue()
        LoadWhenCallFromD09U2223()

        tdbg_NumberFormat()
        'CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        CheckMenuOther()

        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID, txtStrEmployeeID.MaxLength)

        CallD09U1111()
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft, COL_BASE01_DATE, COL_BASE02_DATE, COL_BASE03_DATE, COL_BASE04_DATE, COL_CE01_DATE, COL_CE02_DATE, COL_CE03_DATE, COL_CE04_DATE, COL_CE05_DATE, COL_CE06_DATE, COL_CE07_DATE, COL_CE08_DATE, COL_CE09_DATE, COL_CE10_DATE, COL_CE11_DATE, COL_CE12_DATE, COL_CE13_DATE, COL_CE14_DATE, COL_CE15_DATE, COL_CE16_DATE, COL_CE17_DATE, COL_CE18_DATE, COL_CE19_DATE, COL_CE20_DATE, COL_BaseSalary01DateEnd, COL_BaseSalary01NextDate, COL_BaseSalary02DateEnd, COL_BaseSalary02NextDate, COL_BaseSalary03DateEnd, COL_BaseSalary03NextDate, COL_BaseSalary04DateEnd, COL_BaseSalary04NextDate, COL_OLSC10_DATE, COL_OffSa1DateEnd, COL_OLSC20_DATE, COL_OffSa2DateEnd, COL_Sal01DateEnd, COL_Sal02DateEnd, COL_Sal03DateEnd, COL_Sal04DateEnd, COL_Sal05DateEnd, COL_Sal06DateEnd, COL_Sal07DateEnd, COL_Sal08DateEnd, COL_Sal09DateEnd, COL_Sal10DateEnd, COL_Sal01NextDate, COL_Sal02NextDate, COL_Sal03NextDate, COL_Sal04NextDate, COL_Sal05NextDate, COL_Sal06NextDate, COL_Sal07NextDate, COL_Sal08NextDate, COL_Sal09NextDate, COL_Sal10NextDate)

        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LoadWhenCallFromD09U2223()
        If _employeeeID <> "" Then
            dtGrid = ReturnDataTable(SQLStoreD13P4050())
            dtGrid.DefaultView.RowFilter = "EmployeeID IN (" & _employeeeID & ")"
            dtGrid = dtGrid.DefaultView.ToTable
            LoadDataSource(tdbg, dtGrid, gbUnicode)
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ho_so_luong_goc_-_D13F1030") & UnicodeCaption(gbUnicode) 'Hä s¥ l§¥ng gçc - D13F1030
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblBlockID.Text = rl3("Ma_khoi") 'Mã khối
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblEmpGroupID.Text = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ten_nhan_vien") 'Tên nhân viên
        '================================================================ 
        btnView.Text = rl3("Hien_thi") 'Hiển thị
        btnFilter.Text = rl3("_Loc") '&Lọc
        '***************************************
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnView.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '***************************************
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_NV")
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV")
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("IsNew").Caption = rl3("Nhan_vien_moi") 'Nhân viên mới
        tdbg.Columns("PaymentMethodName").Caption = rl3("Phuong_phap_tra_luong") 'Phương pháp trả lương
        tdbg.Columns("BankName").Caption = rl3("Ngan_hang_1") 'Ngân hàng 1
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        tdbg.Columns("SalEmpGroupName").Caption = rl3("Nhom_luong") 'Nhom luong
        tdbg.Columns("BASE01").Caption = rl3("Muc_luong_1") 'Mức lương 1
        tdbg.Columns("BASE02").Caption = rl3("Muc_luong__2") 'Mức lương  2
        tdbg.Columns("BASE03").Caption = rl3("Muc_luong_3") 'Mức lương 3
        tdbg.Columns("BASE04").Caption = rl3("Muc_luong_4") 'Mức lương 4
        tdbg.Columns("CE01").Caption = rl3("He_so_luong_1") 'Hệ số lương 1
        tdbg.Columns("CE02").Caption = rl3("He_so_luong_2") 'Hệ số lương 2
        tdbg.Columns("CE03").Caption = rl3("He_so_luong_3") 'Hệ số lương 3
        tdbg.Columns("CE04").Caption = rl3("He_so_luong_4") 'Hệ số lương 4
        tdbg.Columns("CE05").Caption = rl3("He_so_luong_5") 'Hệ số lương 5
        tdbg.Columns("CE06").Caption = rl3("He_so_luong_6") 'Hệ số lương 6
        tdbg.Columns("CE07").Caption = rl3("He_so_luong_7") 'Hệ số lương 7
        tdbg.Columns("CE08").Caption = rl3("He_so_luong_8") 'Hệ số lương 8
        tdbg.Columns("CE09").Caption = rl3("He_so_luong_9") 'Hệ số lương 9
        tdbg.Columns("CE10").Caption = rl3("He_so_luong_10") 'Hệ số lương 10
        tdbg.Columns("CreateUserID").Caption = rl3("Nguoi_tao") 'Người tạo
        tdbg.Columns("CreateDate").Caption = rl3("Ngay_tao") 'Ngày tạo
        tdbg.Columns("LastModifyUserID").Caption = rl3("Nguoi_cap_nhat_cuoi_cung") 'Người cập nhật cuối cùng
        tdbg.Columns("LastModifyDate").Caption = rl3("Ngay_cap_nhat_cuoi_cung") 'Ngày cập nhật cuối cùng
        tdbg.Columns("OfficalTitleID").Caption = rl3("Ngach_luong_1") 'Ngạch lương 1
        tdbg.Columns("SalaryLevelID").Caption = rl3("Bac_luong_1") 'Bậc lương 1
        tdbg.Columns("SaCoefficient").Caption = rl3("He_so_luong_01") 'Hệ số lương 01
        tdbg.Columns("OfficalTitleID2").Caption = rl3("Ngach_luong_2") 'Ngạch lương 2
        tdbg.Columns("SalaryLevelID2").Caption = rl3("Bac_luong_2") 'Bậc lương 2
        tdbg.Columns("SaCoefficient2").Caption = rl3("He_so_luong_02") 'Hệ số lương 02
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Splits(SPLIT0).Caption = rl3("Thong_tin_chung") 'Thông tin chung
        tdbg.Splits(SPLIT1).Caption = rl3("Thong_tin_ve_muc_luong_va_he_so_luong") 'Thông tin về mức lương và hệ số lương
        ' update 15/11/2012 id 51174
        tdbg.Columns("DutyID").Caption = rl3("Chuc_vu")
        tdbg.Columns("DutyName").Caption = rl3("Ten_chuc_vu")
        tdbg.Columns("WorkID").Caption = rl3("Cong_viec")
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh")
        tdbg.Columns("WorkName").Caption = rl3("Ten_cong_viec")
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh")
        tdbg.Columns("DateLeft").Caption = rl3("Ngay_nghi_viec")
        tdbg.Columns("Age").Caption = rl3("Tuoi")
        tdbg.Columns("StatusID").Caption = rl3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rl3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rl3("Ma_the_cham_cong")
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu")
        tdbg.Columns("OffSa1NextDate").Caption = rl3("Ngay_nhan_bac_luong_1_tiep_theo") 'Ngày nhận bậc lương 1 tiếp theo
        tdbg.Columns("OffSa2NextDate").Caption = rl3("Ngay_nhan_bac_luong_2_tiep_theo") 'Ngày nhận bậc lương 2 tiếp theo
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        tsmTransferParameters.Text = rl3("Thong_so_chuyen_but_toan") 'Thông số chuyển bút toán
        tsmMatchTemplateIncreaseSalaryParameters.Text = rl3("Gan_template_tang_thong_so_luong") 'Gán template tăng thông số lương
        tsmAutoCalUpdate.Text = rl3("_Cap_nhat_thong_so_luong_theo_DT_tinh_luong")

        tsbImportTransferInfo.Text = rl3("Thong_tin_chuyen_khoan")
        tsmImportTransferInfo.Text = tsbImportTransferInfo.Text
        mnsImportTransferInfo.Text = tsbImportTransferInfo.Text

        tsmUpdateFamilyDeductionValidationDate.Text = rl3("Cap_nhat__hieu_luc_giam_tru_gia_canh") 'Cập nhật &hiệu lực giảm trừ gia cảnh
        mnsUpdateFamilyDeductionValidationDate.Text = tsmUpdateFamilyDeductionValidationDate.Text
    End Sub

    Private Sub LoadDefaultValue()
        Dim dt As New DataTable
        dt = ReturnDataTable("Select IsUseBlock From D09T0000")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("IsUseBlock").ToString <> "1" Then
                tdbcBlockID.Enabled = False
                tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = False
            End If
            dt = Nothing
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcEmpGroupID

        dtEmpGroupID = ReturnTableEmpGroupID(True, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, True, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, True, gbUnicode)


        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcWorkingStatusID
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcWorkingStatusID
        sSQL = "Select '%' As WorkingStatusID, " & sLanguage & " As WorkingStatusName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select WorkingStatusID, WorkingStatusName" & sUnicode & " as WorkingStatusName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "From D09T0070" & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order By DisplayOrder, WorkingStatusID"
        LoadDataSource(tdbcWorkingStatusID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcDepartmentID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID = " & SQLString(ID) & " Or BlockID = '%'"), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBGrid(ByVal sSQL As String)
        dtGrid = ReturnDataTable(sSQL)
        'LoadDataSource(tdbg, dtGrid.Copy, gbUnicode)

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind

        ' update 27/3/2013 id 55214 - Chuẩn hóa phân quyền menu Import dữ liệu
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F1030")
        CheckMenuOther()
        tdbg_FooterText()
        tdbg_NumberFormat()
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Dim iPerD13F1038 As Integer = 0

    Private Sub CheckMenuOther()
        bEditEnabled = tsbEdit.Enabled
        CheckPermissionColGrid()

        ' Phân quyền Import dữ liệu
        ' update 27/3/2013 id 55214 - Chuẩn hóa phân quyền menu Import dữ liệu
        ' ImportData phân quyền theo 2 màn hình D13F1030 và D13F5610
        tsbImportData.Enabled = tsbImportData.Enabled And ReturnPermission("D13F5610") >= 2
        tsmImportData.Enabled = tsbImportData.Enabled
        mnsImportData.Enabled = tsbImportData.Enabled

        '        tsbEditOther.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '        mnsEditOther.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '        tsmEditOther.Enabled = tsbEdit.Enabled 'tsbEditOther.Enabled
        '
        '        tsmTransferParameters.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '        mnsTransferParameters.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '
        '        tsmMatchTemplateIncreaseSalaryParameters.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '        mnsMatchTemplateIncreaseSalaryParameters.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0
        '
        '        tsmAutoCalUpdate.Enabled = tsbEdit.Enabled ' tdbg.RowCount > 0
        '        mnsAutoCalUpdate.Enabled = tsbEdit.Enabled 'tdbg.RowCount > 0

        'Quyền sửa và D13F1038 > 1
        tsmUpdateFamilyDeductionValidationDate.Enabled = tsbEdit.Enabled And ReturnPermission("D13F1038") > 1
        mnsUpdateFamilyDeductionValidationDate.Enabled = tsmUpdateFamilyDeductionValidationDate.Enabled
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    '	Cần sửa Tìm kiếm như sau:
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
        Set(ByVal Value As String )
            sFindServer = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '        If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClauseClient.ToString()
    '        sFindServer = ResultWhereClauseServer.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

#End Region

#Region "Menu bar"

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        If tdbg.RowCount <= 0 Then Exit Sub
        Call_D13D0140(EnumFormState.FormView)
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If tdbg.RowCount <= 0 Then Exit Sub

        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        Call_D13D0140(EnumFormState.FormEdit)

        If _bSaved Then
            LoadTDBGrid(SQLStoreD13P4050(True))
            If gbEnabledUseFind Then
                ReLoadTDBGrid()
            End If
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        End If
    End Sub

    Private Sub tsbEditOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditOther.Click, tsmEditOther.Click, mnsEditOther.Click
        Dim f As New D13F1035
        With f
            .EmployeeID = ConvertVniToUnicode(GetDataSelectRows(COL_EmployeeID, tdbg))
            .DepartmentID = IIf(tdbcDepartmentID.Text = "", "", tdbcDepartmentID.SelectedValue).ToString
            .sFind = sFindServer
            .ShowAll = chkShowDisabled.Checked
            If .bSaved Then
                Dim iBookMark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then iBookMark = tdbg.Bookmark
                btnFilter_Click(Nothing, Nothing)
                If Not IsDBNull(iBookMark) Then tdbg.Bookmark = iBookMark
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)

        '        ResetTableForExcel(tdbg, gdtCaptionExcel, sFieldSum_Group)
        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = gdtCaptionExcel
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dtGrid
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '        '*****************************************
    End Sub

    Private Sub tsbImportTransferInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportTransferInfo.Click, tsmImportTransferInfo.Click, mnsImportTransferInfo.Click
        Me.Cursor = Cursors.WaitCursor
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D13, "D13F5610", "D13F1030A") Then
            'Load lại dữ liệu
            btnFilter_Click(Nothing, Nothing)
        End If
        Me.Cursor = Cursors.Default
        ' Dim frm As New D80F2090
        '        With frm
        '            .FormActive = "D80F2090"
        '            .FormPermission = "D13F5610"
        '            .ModuleID = D13
        '            .TransTypeID = "D13F1030A" 'Theo TL phân tích
        '            .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString 'VNI-UNICODE: Theo TL phân tích
        '            .ShowDialog()
        '            If .OutPut01 Then .bSaved = .OutPut01
        '            .Dispose()
        '        End With

        '        If .bSaved Then
        '            'Load lại dữ liệu
        '            btnFilter_Click(Nothing, Nothing)
        '        End If

    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        Dim f As New D13F4050
        With f
            .BlockID = ComboValue(tdbcBlockID)
            .DepartmentID = ComboValue(tdbcDepartmentID)
            .TeamID = ComboValue(tdbcTeamID)
            .EmpGroupID = ComboValue(tdbcEmpGroupID)
            .WorkingStatusID = ComboValue(tdbcWorkingStatusID)
            .WhereClause = sFindServer
            .CallFormID = "D13F1030"
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsmTransferParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTransferParameters.Click, mnsTransferParameters.Click
        Dim f As New D13F1032
        Dim iBookmark As Integer
        ' Kiểm tra form đang ở quyền nào
        Dim per As Integer = ReturnPermission(Me.Name)
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
            If per = 1 Then
                .FormState = EnumFormState.FormView
            ElseIf per = 2 Then
                .FormState = EnumFormState.FormAdd
            ElseIf per = 3 Then
                .FormState = EnumFormState.FormEdit
            End If
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid(SQLStoreD13P4050())
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With

       
    End Sub

    Private Sub tsmMatchTemplateIncreaseSalaryParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmMatchTemplateIncreaseSalaryParameters.Click, mnsMatchTemplateIncreaseSalaryParameters.Click
        Dim f As New D13F1033
        Dim iBookmark As Integer
        ' Kiểm tra form đang ở quyền nào
        Dim per As Integer = ReturnPermission(Me.Name)

        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
            If per = 1 Then
                .FormState = EnumFormState.FormView
            ElseIf per = 2 Then
                .FormState = EnumFormState.FormAdd
            ElseIf per = 3 Then
                .FormState = EnumFormState.FormEdit
            End If

            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid(SQLStoreD13P4050())
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With
        
    End Sub

    Private Sub tsmAutoCalUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAutoCalUpdate.Click, mnsAutoCalUpdate.Click
        Dim sSQL As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL &= SQLInsertD13T1030(tdbg(i, COL_EmployeeID).ToString).ToString & vbCrLf
        Next
        sSQL &= SQLStoreD13P1033()
        Dim bResult As Boolean = MyExecuteSQL(sSQL)
        If bResult Then
            D99C0008.MsgL3(rl3("Cap_nhat_thong_so_luong_thanh_cong"))
            LoadTDBGrid(SQLStoreD13P4050())
        Else
            ' D99C0008.Msg(rl3("Thuc_thi_khong_thanh_cong_Ban_vui_long_kiem_tra_lai_cong_thuc_UNI"), rl3("Thong_bao"), L3MessageBoxIcon.Err)
            MsgErr(rl3("Thuc_thi_khong_thanh_cong_Ban_vui_long_kiem_tra_lai_cong_thuc"))
        End If
    End Sub

    '19/12/2013 id 60826
    Private Sub tsmUpdateFamilyDeductionValidationDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmUpdateFamilyDeductionValidationDate.Click, mnsUpdateFamilyDeductionValidationDate.Click
        Dim frm As New D13F1038
        With frm
            .Mode = 0
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F5558")
        SetProperties(arrPro, "AuditCode", "MasterSalaryFile")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_EmployeeID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)
        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D13F5558"  'Màn hình phân quyền
        '            .ID01 = "MasterSalaryFile" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_EmployeeID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_BASE01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BASE04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_CE01, COL_CE02, COL_CE03, COL_CE04, COL_CE05, COL_CE06, COL_CE07, COL_CE08, COL_CE09, COL_CE10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                'Update 13/002/2012: incident 45880 Bổ sung thêm 10 HSL
            Case COL_CE11, COL_CE12, COL_CE13, COL_CE14, COL_CE15, COL_CE16, COL_CE17, COL_CE18, COL_CE19, COL_CE20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextBaseSalary01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextBaseSalary02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextBaseSalary03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextBaseSalary04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient12
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient13
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient14
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient15
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient2
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient22
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient23
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient24
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SaCoefficient25
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Sal03NextDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Sal04NextDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Sal05NextDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Sal06NextDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextSalCoefficient01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NextSalCoefficient02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)

                ' update 15/11/2012 id 51174
            Case COL_Age
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_BirthDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_DepartmentID
                e.CellTip = tdbg.Columns(COL_DepartmentName).Text
            Case COL_TeamID
                e.CellTip = tdbg.Columns(COL_TeamName).Text
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub c1dateDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1dateDate.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid(SQLStoreD13P4050())
        Me.Cursor = Cursors.Default
        btnFilter.Enabled = True
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
        'Update 13/002/2012: incident 45880 Bổ sung thêm 10 HSL
        tdbg.Columns(COL_CE11).NumberFormat = Format(tdbg.Columns(COL_CE11).Text, D13FormatSalary.CE11)
        tdbg.Columns(COL_CE12).NumberFormat = Format(tdbg.Columns(COL_CE12).Text, D13FormatSalary.CE12)
        tdbg.Columns(COL_CE13).NumberFormat = Format(tdbg.Columns(COL_CE13).Text, D13FormatSalary.CE13)
        tdbg.Columns(COL_CE14).NumberFormat = Format(tdbg.Columns(COL_CE14).Text, D13FormatSalary.CE14)
        tdbg.Columns(COL_CE15).NumberFormat = Format(tdbg.Columns(COL_CE15).Text, D13FormatSalary.CE15)
        tdbg.Columns(COL_CE16).NumberFormat = Format(tdbg.Columns(COL_CE16).Text, D13FormatSalary.CE16)
        tdbg.Columns(COL_CE17).NumberFormat = Format(tdbg.Columns(COL_CE17).Text, D13FormatSalary.CE17)
        tdbg.Columns(COL_CE18).NumberFormat = Format(tdbg.Columns(COL_CE18).Text, D13FormatSalary.CE18)
        tdbg.Columns(COL_CE19).NumberFormat = Format(tdbg.Columns(COL_CE19).Text, D13FormatSalary.CE19)
        tdbg.Columns(COL_CE20).NumberFormat = Format(tdbg.Columns(COL_CE20).Text, D13FormatSalary.CE20)

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

    Dim sFieldSum_Group() As Integer = {COL_BASE01, COL_BASE02, COL_BASE03, COL_BASE04, COL_CE01, COL_CE02, COL_CE03, COL_CE04, COL_CE05, COL_CE06, COL_CE07, COL_CE08, COL_CE09, COL_CE10, COL_CE11, COL_CE12, COL_CE13, COL_CE14, COL_CE15, COL_CE16, COL_CE17, COL_CE18, COL_CE19, COL_CE20, COL_SaCoefficient, COL_SaCoefficient12, COL_SaCoefficient13, COL_SaCoefficient14, COL_SaCoefficient15, COL_SaCoefficient2, COL_SaCoefficient22, COL_SaCoefficient23, COL_SaCoefficient24, COL_SaCoefficient25}

    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg, COL_FullName)

        FooterSumNew(tdbg, sFieldSum_Group)
        '
        '        FootTextColumns(COL_BASE01, D13FormatSalary.BASE01)
        '        FootTextColumns(COL_BASE02, D13FormatSalary.BASE02)
        '        FootTextColumns(COL_BASE03, D13FormatSalary.BASE03)
        '        FootTextColumns(COL_BASE04, D13FormatSalary.BASE04)
        '
        '        FootTextColumns(COL_CE01, D13FormatSalary.CE01)
        '        FootTextColumns(COL_CE02, D13FormatSalary.CE02)
        '        FootTextColumns(COL_CE03, D13FormatSalary.CE03)
        '        FootTextColumns(COL_CE04, D13FormatSalary.CE04)
        '        FootTextColumns(COL_CE05, D13FormatSalary.CE05)
        '        FootTextColumns(COL_CE06, D13FormatSalary.CE06)
        '        FootTextColumns(COL_CE07, D13FormatSalary.CE07)
        '        FootTextColumns(COL_CE08, D13FormatSalary.CE08)
        '        FootTextColumns(COL_CE09, D13FormatSalary.CE09)
        '        FootTextColumns(COL_CE10, D13FormatSalary.CE10)
        '
        '        FootTextColumns(COL_CE11, D13FormatSalary.CE11)
        '        FootTextColumns(COL_CE12, D13FormatSalary.CE12)
        '        FootTextColumns(COL_CE13, D13FormatSalary.CE13)
        '        FootTextColumns(COL_CE14, D13FormatSalary.CE14)
        '        FootTextColumns(COL_CE15, D13FormatSalary.CE15)
        '        FootTextColumns(COL_CE16, D13FormatSalary.CE16)
        '        FootTextColumns(COL_CE17, D13FormatSalary.CE17)
        '        FootTextColumns(COL_CE18, D13FormatSalary.CE18)
        '        FootTextColumns(COL_CE19, D13FormatSalary.CE19)
        '        FootTextColumns(COL_CE20, D13FormatSalary.CE20)
        '
        '
        '        FootTextColumns(COL_SaCoefficient, D13FormatSalary.OLSC11)
        '        FootTextColumns(COL_SaCoefficient12, D13FormatSalary.OLSC12)
        '        FootTextColumns(COL_SaCoefficient13, D13FormatSalary.OLSC13)
        '        FootTextColumns(COL_SaCoefficient14, D13FormatSalary.OLSC14)
        '        FootTextColumns(COL_SaCoefficient15, D13FormatSalary.OLSC15)
        '        FootTextColumns(COL_SaCoefficient2, D13FormatSalary.OLSC21)
        '        FootTextColumns(COL_SaCoefficient22, D13FormatSalary.OLSC22)
        '        FootTextColumns(COL_SaCoefficient23, D13FormatSalary.OLSC23)
        '        FootTextColumns(COL_SaCoefficient24, D13FormatSalary.OLSC24)
        '        FootTextColumns(COL_SaCoefficient25, D13FormatSalary.OLSC25)
    End Sub

    Private Sub FootTextColumns(ByVal iCol As Integer, ByVal sNumberFormat As String)
        Dim Sum As Double = 0
        For j As Int32 = 0 To tdbg.RowCount - 1
            Sum += Number(SQLNumber(tdbg(j, iCol).ToString, sNumberFormat))
        Next
        tdbg.Columns(iCol).FooterText = SQLNumber(Sum.ToString, sNumberFormat)
    End Sub

    Private Sub SQLD13T9000()
        Dim sSQL As String = ""
        'sSQL &= "Select Code, Short, Disabled, Type From D13T9000 Order By Code"   'ID32596------05/05/2010
        sSQL = "Exec D13P4051 " & SQLString(gsLanguage) & ", " & SQLNumber(gbUnicode)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable

        dt1 = ReturnTableFilter(dt, "Type='SALBA'")
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))

        bBA.BASE01_DATE = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02_DATE = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03_DATE = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04_DATE = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_BASE01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_BASE02).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_BASE03).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_BASE04).Caption = dt1.Rows(6).Item("Short").ToString

        tdbg.Columns(COL_BASE01_DATE).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_BASE02_DATE).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_BASE03_DATE).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_BASE04_DATE).Caption = dt1.Rows(7).Item("Short").ToString

        Dim dt2 As DataTable
        dt2 = ReturnTableFilter(dt, "Type='SALCE'")
        bCE.CE01 = CBool(IIf(dt2.Rows(0).Item("Disabled").ToString = "0", True, False))
        bCE.CE02 = CBool(IIf(dt2.Rows(2).Item("Disabled").ToString = "0", True, False))
        bCE.CE03 = CBool(IIf(dt2.Rows(4).Item("Disabled").ToString = "0", True, False))
        bCE.CE04 = CBool(IIf(dt2.Rows(6).Item("Disabled").ToString = "0", True, False))
        bCE.CE05 = CBool(IIf(dt2.Rows(8).Item("Disabled").ToString = "0", True, False))
        bCE.CE06 = CBool(IIf(dt2.Rows(10).Item("Disabled").ToString = "0", True, False))
        bCE.CE07 = CBool(IIf(dt2.Rows(12).Item("Disabled").ToString = "0", True, False))
        bCE.CE08 = CBool(IIf(dt2.Rows(14).Item("Disabled").ToString = "0", True, False))
        bCE.CE09 = CBool(IIf(dt2.Rows(16).Item("Disabled").ToString = "0", True, False))
        bCE.CE10 = CBool(IIf(dt2.Rows(18).Item("Disabled").ToString = "0", True, False))
        'Update 13/002/2012: incident 45880 Bổ sung thêm 10 HSL
        bCE.CE11 = CBool(IIf(dt2.Rows(20).Item("Disabled").ToString = "0", True, False))
        bCE.CE12 = CBool(IIf(dt2.Rows(22).Item("Disabled").ToString = "0", True, False))
        bCE.CE13 = CBool(IIf(dt2.Rows(24).Item("Disabled").ToString = "0", True, False))
        bCE.CE14 = CBool(IIf(dt2.Rows(26).Item("Disabled").ToString = "0", True, False))
        bCE.CE15 = CBool(IIf(dt2.Rows(28).Item("Disabled").ToString = "0", True, False))
        bCE.CE16 = CBool(IIf(dt2.Rows(30).Item("Disabled").ToString = "0", True, False))
        bCE.CE17 = CBool(IIf(dt2.Rows(32).Item("Disabled").ToString = "0", True, False))
        bCE.CE18 = CBool(IIf(dt2.Rows(34).Item("Disabled").ToString = "0", True, False))
        bCE.CE19 = CBool(IIf(dt2.Rows(36).Item("Disabled").ToString = "0", True, False))
        bCE.CE20 = CBool(IIf(dt2.Rows(38).Item("Disabled").ToString = "0", True, False))

        bCE.CE01_DATE = CBool(IIf(dt2.Rows(1).Item("Disabled").ToString = "0", True, False))
        bCE.CE02_DATE = CBool(IIf(dt2.Rows(3).Item("Disabled").ToString = "0", True, False))
        bCE.CE03_DATE = CBool(IIf(dt2.Rows(5).Item("Disabled").ToString = "0", True, False))
        bCE.CE04_DATE = CBool(IIf(dt2.Rows(7).Item("Disabled").ToString = "0", True, False))
        bCE.CE05_DATE = CBool(IIf(dt2.Rows(9).Item("Disabled").ToString = "0", True, False))
        bCE.CE06_DATE = CBool(IIf(dt2.Rows(11).Item("Disabled").ToString = "0", True, False))
        bCE.CE07_DATE = CBool(IIf(dt2.Rows(13).Item("Disabled").ToString = "0", True, False))
        bCE.CE08_DATE = CBool(IIf(dt2.Rows(15).Item("Disabled").ToString = "0", True, False))
        bCE.CE09_DATE = CBool(IIf(dt2.Rows(17).Item("Disabled").ToString = "0", True, False))
        bCE.CE10_DATE = CBool(IIf(dt2.Rows(19).Item("Disabled").ToString = "0", True, False))

        bCE.CE11_DATE = CBool(IIf(dt2.Rows(21).Item("Disabled").ToString = "0", True, False))
        bCE.CE12_DATE = CBool(IIf(dt2.Rows(23).Item("Disabled").ToString = "0", True, False))
        bCE.CE13_DATE = CBool(IIf(dt2.Rows(25).Item("Disabled").ToString = "0", True, False))
        bCE.CE14_DATE = CBool(IIf(dt2.Rows(27).Item("Disabled").ToString = "0", True, False))
        bCE.CE15_DATE = CBool(IIf(dt2.Rows(29).Item("Disabled").ToString = "0", True, False))
        bCE.CE16_DATE = CBool(IIf(dt2.Rows(31).Item("Disabled").ToString = "0", True, False))
        bCE.CE17_DATE = CBool(IIf(dt2.Rows(33).Item("Disabled").ToString = "0", True, False))
        bCE.CE18_DATE = CBool(IIf(dt2.Rows(35).Item("Disabled").ToString = "0", True, False))
        bCE.CE19_DATE = CBool(IIf(dt2.Rows(37).Item("Disabled").ToString = "0", True, False))
        bCE.CE20_DATE = CBool(IIf(dt2.Rows(39).Item("Disabled").ToString = "0", True, False))

        'Update 13/002/2012: incident 45880 Bổ sung thêm 10 HSL
        For i As Integer = 0 To 39
            If i Mod 2 = 0 Then
                tdbg.Columns(COL_CE01 + i).Caption = dt2.Rows(i).Item("Short").ToString
            Else 'COL_CE01_DATE
                tdbg.Columns(COL_CE01 + i).Caption = dt2.Rows(i).Item("Short").ToString
            End If
        Next
        '        tdbg.Columns(COL_CE01).Caption = dt2.Rows(0).Item("Short").ToString
        '        tdbg.Columns(COL_CE02).Caption = dt2.Rows(2).Item("Short").ToString
        '        tdbg.Columns(COL_CE03).Caption = dt2.Rows(4).Item("Short").ToString
        '        tdbg.Columns(COL_CE04).Caption = dt2.Rows(6).Item("Short").ToString
        '        tdbg.Columns(COL_CE05).Caption = dt2.Rows(8).Item("Short").ToString
        '        tdbg.Columns(COL_CE06).Caption = dt2.Rows(10).Item("Short").ToString
        '        tdbg.Columns(COL_CE07).Caption = dt2.Rows(12).Item("Short").ToString
        '        tdbg.Columns(COL_CE08).Caption = dt2.Rows(14).Item("Short").ToString
        '        tdbg.Columns(COL_CE09).Caption = dt2.Rows(16).Item("Short").ToString
        '        tdbg.Columns(COL_CE10).Caption = dt2.Rows(18).Item("Short").ToString
        '
        '        tdbg.Columns(COL_CE01_DATE).Caption = dt2.Rows(1).Item("Short").ToString
        '        tdbg.Columns(COL_CE02_DATE).Caption = dt2.Rows(3).Item("Short").ToString
        '        tdbg.Columns(COL_CE03_DATE).Caption = dt2.Rows(5).Item("Short").ToString
        '        tdbg.Columns(COL_CE04_DATE).Caption = dt2.Rows(7).Item("Short").ToString
        '        tdbg.Columns(COL_CE05_DATE).Caption = dt2.Rows(9).Item("Short").ToString
        '        tdbg.Columns(COL_CE06_DATE).Caption = dt2.Rows(11).Item("Short").ToString
        '        tdbg.Columns(COL_CE07_DATE).Caption = dt2.Rows(13).Item("Short").ToString
        '        tdbg.Columns(COL_CE08_DATE).Caption = dt2.Rows(15).Item("Short").ToString
        '        tdbg.Columns(COL_CE09_DATE).Caption = dt2.Rows(17).Item("Short").ToString
        '        tdbg.Columns(COL_CE10_DATE).Caption = dt2.Rows(19).Item("Short").ToString

        Dim dt3 As DataTable
        dt3 = ReturnTableFilter(dt, "Type = 'OLSC'")
        bOL.OLSC1 = CBool(IIf(dt3.Rows(0).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC10 = CBool(IIf(dt3.Rows(1).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC10_DATE = CBool(IIf(dt3.Rows(2).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC11 = CBool(IIf(dt3.Rows(3).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC12 = CBool(IIf(dt3.Rows(4).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC13 = CBool(IIf(dt3.Rows(5).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC14 = CBool(IIf(dt3.Rows(6).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC15 = CBool(IIf(dt3.Rows(7).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC2 = CBool(IIf(dt3.Rows(8).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC20 = CBool(IIf(dt3.Rows(9).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC20_DATE = CBool(IIf(dt3.Rows(10).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC21 = CBool(IIf(dt3.Rows(11).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC22 = CBool(IIf(dt3.Rows(12).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC23 = CBool(IIf(dt3.Rows(13).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC24 = CBool(IIf(dt3.Rows(14).Item("Disabled").ToString = "0", True, False))
        bOL.OLSC25 = CBool(IIf(dt3.Rows(15).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_OfficalTitleID).Caption = dt3.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_SalaryLevelID).Caption = dt3.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_OLSC10_DATE).Caption = dt3.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient).Caption = dt3.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient12).Caption = dt3.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient13).Caption = dt3.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient14).Caption = dt3.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient15).Caption = dt3.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_OfficalTitleID2).Caption = dt3.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_SalaryLevelID2).Caption = dt3.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_OLSC20_DATE).Caption = dt3.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient2).Caption = dt3.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient22).Caption = dt3.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient23).Caption = dt3.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient24).Caption = dt3.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_SaCoefficient25).Caption = dt3.Rows(15).Item("Short").ToString

        For i As Integer = COL_BASE01 To COL_NextSalCoefficient10
            tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next
    End Sub

    Private Sub ShowColumns()
        tdbg.Splits(1).DisplayColumns(COL_BASE01).Visible = bBA.BASE01
        tdbg.Splits(1).DisplayColumns(COL_BASE02).Visible = bBA.BASE02
        tdbg.Splits(1).DisplayColumns(COL_BASE03).Visible = bBA.BASE03
        tdbg.Splits(1).DisplayColumns(COL_BASE04).Visible = bBA.BASE04

        tdbg.Splits(1).DisplayColumns(COL_BASE01_DATE).Visible = bBA.BASE01_DATE
        tdbg.Splits(1).DisplayColumns(COL_BASE02_DATE).Visible = bBA.BASE02_DATE
        tdbg.Splits(1).DisplayColumns(COL_BASE03_DATE).Visible = bBA.BASE03_DATE
        tdbg.Splits(1).DisplayColumns(COL_BASE04_DATE).Visible = bBA.BASE04_DATE

        tdbg.Splits(1).DisplayColumns(COL_CE01).Visible = bCE.CE01
        tdbg.Splits(1).DisplayColumns(COL_CE02).Visible = bCE.CE02
        tdbg.Splits(1).DisplayColumns(COL_CE03).Visible = bCE.CE03
        tdbg.Splits(1).DisplayColumns(COL_CE04).Visible = bCE.CE04
        tdbg.Splits(1).DisplayColumns(COL_CE05).Visible = bCE.CE05
        tdbg.Splits(1).DisplayColumns(COL_CE06).Visible = bCE.CE06
        tdbg.Splits(1).DisplayColumns(COL_CE07).Visible = bCE.CE07
        tdbg.Splits(1).DisplayColumns(COL_CE08).Visible = bCE.CE08
        tdbg.Splits(1).DisplayColumns(COL_CE09).Visible = bCE.CE09
        tdbg.Splits(1).DisplayColumns(COL_CE10).Visible = bCE.CE10
        'Update 13/002/2012: incident 45880 Bổ sung thêm 10 HSL
        tdbg.Splits(1).DisplayColumns(COL_CE11).Visible = bCE.CE11
        tdbg.Splits(1).DisplayColumns(COL_CE12).Visible = bCE.CE12
        tdbg.Splits(1).DisplayColumns(COL_CE13).Visible = bCE.CE13
        tdbg.Splits(1).DisplayColumns(COL_CE14).Visible = bCE.CE14
        tdbg.Splits(1).DisplayColumns(COL_CE15).Visible = bCE.CE15
        tdbg.Splits(1).DisplayColumns(COL_CE16).Visible = bCE.CE16
        tdbg.Splits(1).DisplayColumns(COL_CE17).Visible = bCE.CE17
        tdbg.Splits(1).DisplayColumns(COL_CE18).Visible = bCE.CE18
        tdbg.Splits(1).DisplayColumns(COL_CE19).Visible = bCE.CE19
        tdbg.Splits(1).DisplayColumns(COL_CE20).Visible = bCE.CE20

        tdbg.Splits(1).DisplayColumns(COL_CE01_DATE).Visible = bCE.CE01_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE02_DATE).Visible = bCE.CE02_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE03_DATE).Visible = bCE.CE03_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE04_DATE).Visible = bCE.CE04_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE05_DATE).Visible = bCE.CE05_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE06_DATE).Visible = bCE.CE06_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE07_DATE).Visible = bCE.CE07_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE08_DATE).Visible = bCE.CE08_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE09_DATE).Visible = bCE.CE09_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE10_DATE).Visible = bCE.CE10_DATE

        tdbg.Splits(1).DisplayColumns(COL_CE11_DATE).Visible = bCE.CE11_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE12_DATE).Visible = bCE.CE12_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE13_DATE).Visible = bCE.CE13_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE14_DATE).Visible = bCE.CE14_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE15_DATE).Visible = bCE.CE15_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE16_DATE).Visible = bCE.CE16_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE17_DATE).Visible = bCE.CE17_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE18_DATE).Visible = bCE.CE18_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE19_DATE).Visible = bCE.CE19_DATE
        tdbg.Splits(1).DisplayColumns(COL_CE20_DATE).Visible = bCE.CE20_DATE

        tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID).Visible = bOL.OLSC1
        tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible = bOL.OLSC10
        tdbg.Splits(1).DisplayColumns(COL_OLSC10_DATE).Visible = bOL.OLSC10_DATE
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient).Visible = bOL.OLSC11
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient12).Visible = bOL.OLSC12
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient13).Visible = bOL.OLSC13
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient14).Visible = bOL.OLSC14
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient15).Visible = bOL.OLSC15
        tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID2).Visible = bOL.OLSC2
        tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible = bOL.OLSC20
        tdbg.Splits(1).DisplayColumns(COL_OLSC20_DATE).Visible = bOL.OLSC20_DATE
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient2).Visible = bOL.OLSC21
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient22).Visible = bOL.OLSC22
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient23).Visible = bOL.OLSC23
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient24).Visible = bOL.OLSC24
        tdbg.Splits(1).DisplayColumns(COL_SaCoefficient25).Visible = bOL.OLSC25
    End Sub

    Private Sub mnuAutoCalculateIncreaseSalaryParameters_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F1034
        Dim iBookmark As Integer
        ' Kiểm tra form đang ở quyền nào
        Dim per As Integer = ReturnPermission(Me.Name)

        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            If per = 1 Then
                ._FormState = EnumFormState.FormView
            ElseIf per = 2 Then
                ._FormState = EnumFormState.FormAdd
            ElseIf per = 3 Then
                ._FormState = EnumFormState.FormEdit
            End If
            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid(SQLStoreD13P4050())
                If Not IsDBNull(tdbg.Bookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With

       
    End Sub

    'Gọi form trung gian, form này gọi exe con 
    Private Sub Call_D13D0140(ByVal iMode As EnumFormState)
        Dim f As New D13F1031
        With f
            .Status = IIf(CheckStore(SQLStoreD13P5555(Convert.ToInt16(IIf(iMode = EnumFormState.FormEdit, 0, 1)))), "0", "1").ToString
            .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
            .TeamID = tdbg.Columns(COL_TeamID).Text
            .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
            .EmployeeName = tdbg.Columns(COL_FullName).Text
            .DutyID = tdbg.Columns(COL_DutyID).Text
            .CallFromForm = "D13F1030"
            .FormState = iMode
            .ShowInTaskbar = False
            _bSaved = .bSaved
            .ShowDialog()
        End With
    End Sub

#Region "Events Combo"

#Region "Events tdbcBlockID load tdbcDepartmentID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = ""
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID("-1")
            Exit Sub
        End If
        LoadtdbcDepartmentID(tdbcBlockID.SelectedValue.ToString())
    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 OrElse tdbcTeamID.Text = "" Then
            tdbcTeamID.Text = ""
            tdbcTeamID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, ReturnValueC1Combo(tdbcBlockID).ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmpGroupID.SelectedValue = "%"
    End Sub

    Private Sub tdbcEmpGroupID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.LostFocus
        If tdbcEmpGroupID.FindStringExact(tdbcEmpGroupID.Text) = -1 OrElse tdbcEmpGroupID.Text = "" Then
            tdbcEmpGroupID.Text = ""
            tdbcEmpGroupID.SelectedValue = "%"
        End If
    End Sub
#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then tdbcWorkingStatusID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcEmpGroupID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcWorkingStatusID.Close, tdbcTeamID.Close, tdbcEmpGroupID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcWorkingStatusID.KeyUp, tdbcTeamID.KeyUp, tdbcEmpGroupID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcWorkingStatusID.Validated, tdbcTeamID.Validated, tdbcEmpGroupID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnView.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4050
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/06/2007 03:30:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4050(Optional ByVal FlagEdit As Boolean = False) As String '(ByVal Mode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4050 "
        sSQL &= SQLDateSave(Date.Today) & COMMA 'ReportDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(IIf(gbUnicode, rl3("Ho_so_nhan_vien").ToUpper, rl3("HO_SO_LUONG_NHAN_VIENV"))) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(IIf(FlagEdit, "", sFindServer)) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'chkShowDisabled.Checked
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtStrEmployeeName.Text) & COMMA 'StrEmployeeName, nvarchar, NOT NUL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsDDate, tinyint, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DDateBegin, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DDateEnd, datetime, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmpGroupID)) 'EmpGroupID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/01/2011 11:54:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Int16) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1030
    '# Created User:
    '# Created Date:
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1030(ByVal sEmp As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1030(")
        sSQL.Append("Users, HostName, Key01ID, Key03ID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'Users, varchar[20], NOT NULL
        sSQL.Append("HOST_NAME()" & COMMA) 'HostName, varchar[20], NOT NULL
        sSQL.Append(SQLString(sEmp) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("D13F1030")) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1033
    '# Created User:
    '# Created Date:
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1033() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1033 "
        sSQL &= SQLString(gsUserID) & COMMA 'Users, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostName, varchar[20], NOT NULL
        sSQL &= SQLString("D13F1030") & COMMA 'Form, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    Private Function MyExecuteSQL(ByVal strSQL As String) As Boolean
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand(strSQL, conn)
        Dim trans As SqlTransaction = Nothing
        If Trim(strSQL) = "" Then Exit Function
        'If giAppMode = 0 Then
        Try
            conn.Open()
            trans = conn.BeginTransaction
            cmd.CommandTimeout = 0
            cmd.Transaction = trans
            cmd.ExecuteNonQuery()
            trans.Commit()
            conn.Close()
            Return True
        Catch
            trans.Rollback()
            conn.Close()
            Clipboard.Clear()
            Clipboard.SetText(strSQL)
            Return False
        End Try
    End Function

    Private Sub CheckPermissionColGrid()
        'Update 24/02/2012: Incident 43633 Kiểm tra thêm cột quyền trên lưới cho các menu: Sửa, Sửa khác, Thông số chuyển bút toán, Gán template tăng thông số lương, Cập nhật thông số lương theo ĐT tính lương.
        Dim iPer As Byte = L3Byte(tdbg.Columns(COL_Permission).Text)

        tsbEdit.Enabled = bEditEnabled And (iPer >= 3)
        mnsEdit.Enabled = tsbEdit.Enabled
        tsmEdit.Enabled = tsbEdit.Enabled

        tsbEditOther.Enabled = tsbEdit.Enabled
        mnsEditOther.Enabled = tsbEdit.Enabled
        tsmEditOther.Enabled = tsbEdit.Enabled

        tsmTransferParameters.Enabled = tsbEdit.Enabled
        mnsTransferParameters.Enabled = tsbEdit.Enabled

        tsmMatchTemplateIncreaseSalaryParameters.Enabled = tsbEdit.Enabled
        mnsMatchTemplateIncreaseSalaryParameters.Enabled = tsbEdit.Enabled

        tsmAutoCalUpdate.Enabled = tsbEdit.Enabled
        mnsAutoCalUpdate.Enabled = tsbEdit.Enabled
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        CheckPermissionColGrid()
    End Sub

   
End Class