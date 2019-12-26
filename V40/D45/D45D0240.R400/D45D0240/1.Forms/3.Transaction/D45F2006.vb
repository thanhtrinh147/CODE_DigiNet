Imports System.Windows.Forms
Imports System
Public Class D45F2006
	Dim report As D99C2003
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F2006"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


    Dim dtDepartmentID, dt_TeamID, dtTeamID_Detail, dtGrid As DataTable
    Dim iColQuantityLast As Integer = COL_TeamID 'Lấy cột số lượng cuối cùng
    Dim bSelected As Boolean = False 'Nhấn HeadClick tại cột Điều chỉnh
    '    Dim sAllTransID As String = "" 'Những TransID đã Điều chỉnh=1
    'Khi lưu: 100 dòng lưu 1 lần
    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing
    Dim bRunSQL As Boolean = True
    Dim sRet As New StringBuilder("") 'luu gtri du ra
    '********************************
    Dim dtProductID As DataTable
    Dim dtStage As DataTable 'Giữ lại để kiểm tra Sản phẩm khác có công đoạn này _này không?
    Dim arrayIndex(COL_Total) As Integer 'mang luu giu gtri index sau khi doi cot
    Dim bColMove As Boolean 'ktra xem co doi cot k?
    Dim sFieldSum_Group() As Integer = {COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20}
    Dim bNotInList As Boolean = False


#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0              ' TransID
    Private Const COL_ProductVoucherID As Integer = 1     ' ProductVoucherID
    Private Const COL_IsUpdated As Integer = 2            ' Điều chỉnh
    Private Const COL_IsCheck As Integer = 3              ' Đã kiểm tra
    Private Const COL_OrderNo As Integer = 4              ' STT
    Private Const COL_ProductID As Integer = 5            ' Sản phẩm
    Private Const COL_ProductName As Integer = 6          ' Tên sản phẩm
    Private Const COL_StageID As Integer = 7              ' Công đoạn
    Private Const COL_StageName As Integer = 8            ' Tên công đoạn
    Private Const COL_PieceworkGroupID As Integer = 9     ' Nhóm chấm công
    Private Const COL_RefEmployeeID As Integer = 10       ' Mã nhân viên phụ
    Private Const COL_EmployeeID As Integer = 11          ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 12        ' Họ và tên
    Private Const COL_DepartmentName As Integer = 13      ' Mã phòng ban
    Private Const COL_DepartmentID As Integer = 14        ' DepartmentID
    Private Const COL_TeamName As Integer = 15            ' Mã tổ nhóm
    Private Const COL_TeamID As Integer = 16              ' TeamID
    Private Const COL_WorkingHours As Integer = 17        ' Số giờ làm việc
    Private Const COL_MasterApportionCoef As Integer = 18 ' Tổng số giờ làm việc
    Private Const COL_DetailApportionCoef As Integer = 19 ' Số giờ
    Private Const COL_Spec01ID As Integer = 20            ' Spec01ID
    Private Const COL_Spec02ID As Integer = 21            ' Spec02ID
    Private Const COL_Spec03ID As Integer = 22            ' Spec03ID
    Private Const COL_Spec04ID As Integer = 23            ' Spec04ID
    Private Const COL_Spec05ID As Integer = 24            ' Spec05ID
    Private Const COL_Spec06ID As Integer = 25            ' Spec06ID
    Private Const COL_Spec07ID As Integer = 26            ' Spec07ID
    Private Const COL_Spec08ID As Integer = 27            ' Spec08ID
    Private Const COL_Spec09ID As Integer = 28            ' Spec09ID
    Private Const COL_Spec10ID As Integer = 29            ' Spec10ID
    Private Const COL_Quantity01 As Integer = 30          ' Soá löôïng 01
    Private Const COL_Quantity02 As Integer = 31          ' Soá löôïng 02
    Private Const COL_Quantity03 As Integer = 32          ' Soá löôïng 03
    Private Const COL_Quantity04 As Integer = 33          ' Soá löôïng 04
    Private Const COL_Quantity05 As Integer = 34          ' Soá löôïng 05
    Private Const COL_Quantity06 As Integer = 35          ' Quantity06
    Private Const COL_Quantity07 As Integer = 36          ' Quantity07
    Private Const COL_Quantity08 As Integer = 37          ' Quantity08
    Private Const COL_Quantity09 As Integer = 38          ' Quantity09
    Private Const COL_Quantity10 As Integer = 39          ' Quantity10
    Private Const COL_Quantity11 As Integer = 40          ' Quantity11
    Private Const COL_Quantity12 As Integer = 41          ' Quantity12
    Private Const COL_Quantity13 As Integer = 42          ' Quantity13
    Private Const COL_Quantity14 As Integer = 43          ' Quantity14
    Private Const COL_Quantity15 As Integer = 44          ' Quantity15
    Private Const COL_Quantity16 As Integer = 45          ' Quantity16
    Private Const COL_Quantity17 As Integer = 46          ' Quantity17
    Private Const COL_Quantity18 As Integer = 47          ' Quantity18
    Private Const COL_Quantity19 As Integer = 48          ' Quantity19
    Private Const COL_Quantity20 As Integer = 49          ' ]Quantity05
    Private Const COL_IsLocked As Integer = 50            ' IsLocked
    Private Const COL_UnitPrice01 As Integer = 51         ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 52         ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 53         ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 54         ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 55         ' UnitPrice05
    Private Const COL_CreateUserID As Integer = 56        ' Người tạo
    Private Const COL_CreateDate As Integer = 57          ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 58    ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 59      ' Ngày cập nhật cuối cùng
    Private Const COL_PayrollVoucherID As Integer = 60    ' PayrollVoucherID
    Private Const COL_Apportion As Integer = 61           ' Apportion
    Private Const COL_OProductName As Integer = 62        ' OProductName

    Private Const COL_Total As Integer = 63
#End Region


#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 0, gbUnicode)
            LoadTDBCombo()
            LoadTDBDropDown()


            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

#Region "Parameters"

    Private _productVoucherID As String = ""
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _salaryVoucherID As String = ""
    Public WriteOnly Property SalaryVoucherID() As String
        Set(ByVal Value As String)
            _salaryVoucherID = Value
        End Set
    End Property

    Private _mode As Integer = 0
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _transTypeID As String
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property
#End Region

    Private Sub D45F2006_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", _bSaved.ToString)
    End Sub

    Private Sub D45F2006_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowOption_Click(Nothing, Nothing)
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

    Private Sub D45F2006_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        _bSaved = False
        bColMove = False
        SetShortcutPopupMenu(C1CommandHolder)
        Loadlanguage()

        If _formIDPermission.Substring(0, 3) = D45 Then
            LoadCaptionQuantity() 'Nếu D45 gọi thì ẩn các cột đơn giá
        Else
            LoadCaptionQuantity_UnitPrice()
        End If

        tdbg_NumberFormat()
        tdbg_LockedColumns()
        ResetFooterGrid(tdbg, 0)
        CheckMenuOther()

        'Su dung Enter di chuyen den o duoi o hien hanh
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown

        'Khoi tao mang luu chi so 
        For i As Integer = 0 To tdbg.Columns.Count - 1
            arrayIndex(i) = i
        Next

        tdbcDepartmentName.SelectedValue = "%"
        tdbcProductName.SelectedValue = "%"
        tdbcStageName.SelectedValue = "%"
        'tdbg.Splits(0).DisplayColumns(COL_WorkingHours).Visible = D45Systems.IsWorkingHour

        '*****************************************
        CallD09U1111_Button(True)
        '*****************************************
        tdbcNameAutoComplete()

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_IsCheck}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        'Me.Text = rl3("Dieu_chinh_phieu_cham_cong_san_pham_-_D45F2006") & UnicodeCaption(gbUnicode) '˜iÒu chÙnh phiÕu chÊm c¤ng s¶n phÈm - D45F2006
        Me.Text = rL3("Dieu_chinh_phieu_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) '˜iÒu chÙnh phiÕu thçng k£ s¶n phÈm tÛnh l§¥ng
        '================================================================ 
        lblDepartmentName.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamName.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeName.Text = rl3("Nhan_vien") 'Nhân viên
        lblProductName.Text = rl3("San_pham") 'Sản phẩm
        lblStageName.Text = rl3("Cong_doan") 'Công đoạn
        '================================================================ 
        btnFilter.Text = rl3("Loc") & Space(1) & "(F5)" 'Lọc
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnShowOption.Text = rl3("Hien_thi") & Space(1) & "(F12)"
        '================================================================ 
        tdbcDepartmentName.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentName.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamName.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamName.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeName.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeName.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcProductName.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbcProductName.Columns("ProductName").Caption = rl3("Ten") 'Tên
        tdbcStageName.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageName.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbdEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbdRefEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbdRefEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbdRefEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdProductID.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbdProductID.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdStageID.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbdPieceworkGroupID.Columns("PieceworkGroupID").Caption = rl3("Ma") 'Mã
        tdbdPieceworkGroupID.Columns("PieceworkGroupName").Caption = rl3("Ten") 'Tên
        tdbdSpec01ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec01ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec02ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec02ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec03ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec03ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec04ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec04ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec05ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec05ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec06ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec06ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec07ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec07ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec08ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec08ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec09ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec09ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec10ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec10ID.Columns("SpecName").Caption = rl3("Ten")
        '================================================================ 
        tdbg.Columns("IsUpdated").Caption = rl3("Dieu_chinh") 'Điều chỉnh
        tdbg.Columns("IsCheck").Caption = rl3("Da_kiem_tra") 'Đã kiểm tra
        tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
        tdbg.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("StageID").Caption = rl3("Cong_doan") 'Công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("WorkingHours").Caption = rl3("So_gio_lam_viec") 'Số giờ làm việc
        tdbg.Columns("MasterApportionCoef").Caption = rl3("Tong_so_gio_lam_viec") 'Tổng số giờ làm việc
        tdbg.Columns("DetailApportionCoef").Caption = rl3("So_gio") 'Số giờ
        tdbg.Columns("CreateUserID").Caption = rl3("Nguoi_tao") 'Người tạo
        tdbg.Columns("CreateDate").Caption = rl3("Ngay_tao") 'Ngày tạo
        tdbg.Columns("LastModifyUserID").Caption = rl3("Nguoi_cap_nhat_cuoi_cung") 'Người cập nhật cuối cùng
        tdbg.Columns("LastModifyDate").Caption = rl3("Ngay_cap_nhat_cuoi_cung") 'Ngày cập nhật cuối cùng
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuPrint.Text = rl3("_In") '&In
        mnuExportToExcel.Text = rl3("Xuat__Excel")
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity05).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity06).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity07).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity08).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity09).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity10).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity11).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity12).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity13).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity14).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity15).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity16).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity17).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity18).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity19).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity20).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        '  tdbg.Splits(SPLIT1).DisplayColumns(COL_ProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        ' tdbg.Splits(SPLIT1).DisplayColumns(COL_StageID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkingHours).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CreateDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CreateUserID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_LastModifyDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_LastModifyUserID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_IsCheck).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBGridSpecificationCaption(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Spec01ID As Integer, ByVal Split As Integer, Optional ByVal bUnicode As Boolean = False)
        Dim bUseSpec As Boolean = False

        Dim sSQL As String = "Select SpecTypeID, Caption" & UnicodeJoin(bUnicode) & " as Caption, IsD45, Disabled From D07T0410 Order by SpecTypeID"
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        Dim iIndex As Integer = COL_Spec01ID
        Dim i As Integer

        If dt.Rows.Count > 0 Then
            For i = 0 To 9
                tdbg.Columns(iIndex).Caption = dt.Rows(i).Item("Caption").ToString
                tdbg.Columns(iIndex).Tag = Convert.ToBoolean(dt.Rows(i).Item("IsD45")) AndAlso Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))

                gbArrSpecVisiable(iIndex - COL_Spec01ID) = Convert.ToBoolean(tdbg.Columns(iIndex).Tag)
                If Not bUseSpec And Convert.ToBoolean(tdbg.Columns(iIndex).Tag) = True Then
                    bUseSpec = True
                End If
                tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font = FontUnicode(bUnicode, tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font.Style) 'New System.Drawing.Font("Lemon3", 8.249999!)

                iIndex += 1
            Next
        End If
        dt = Nothing
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        Dim dt As DataTable

        'Load tdbdProductID
        dt = ReturnTableFilter(dtProductID, "ProductID <>'%'", True)
        LoadDataSource(tdbdProductID, dt, gbUnicode)

        'Load tdbdEmployeeID
        sSQL = "Select D13.EmployeeID as EmployeeID, D09.RefEmployeeID as RefEmployeeID, "
        If gbUnicode = False Then
            sSQL &= "Isnull(D09.LastName,'') + ' ' + Isnull(D09.MiddleName,'') + ' ' + Isnull(D09.FirstName,'') as EmployeeName, "
        Else
            sSQL &= "Isnull(D09.LastNameU,'') + ' ' + Isnull(D09.MiddleNameU,'') + ' ' + Isnull(D09.FirstNameU,'') as EmployeeName, "
        End If
        sSQL &= "D13.DepartmentID, D13.TeamID " & vbCrLf
        sSQL &= "From D13T0101 D13  WITH(NOLOCK) Inner join D09T0201 D09  WITH(NOLOCK) On	D13.EmployeeID =  D09.EmployeeID " & vbCrLf
        sSQL &= "Where D13.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " And PayrollVoucherID = " & SQLString(_payrollVoucherID) & vbCrLf
        sSQL &= "Order by	D13.EmployeeID"

        Dim dt_EmployeeID As DataTable
        Dim dt_RefEmployeeID As DataTable

        dt_EmployeeID = ReturnDataTable(sSQL)
        dt_RefEmployeeID = dt_EmployeeID.DefaultView.ToTable

        dt_EmployeeID.DefaultView.Sort = "EmployeeID"
        LoadDataSource(tdbdEmployeeID, dt_EmployeeID, gbUnicode)

        dt_RefEmployeeID.DefaultView.Sort = "RefEmployeeID"
        LoadDataSource(tdbdRefEmployeeID, dt_RefEmployeeID, gbUnicode)

        'Load tdbdPieceworkGroupID
        sSQL = "Select PieceworkGroupID, PieceworkGroupName" & UnicodeJoin(gbUnicode) & " As PieceworkGroupName" & vbCrLf
        sSQL &= "From D45T1050 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by PieceworkGroupID"
        LoadDataSource(tdbdPieceworkGroupID, sSQL, gbUnicode)

        'Load tdbdTeamID
        dtTeamID_Detail = dt_TeamID.DefaultView.ToTable
        dtTeamID_Detail.DefaultView.RowFilter = "TeamID <>'%'"
        dtTeamID_Detail = dtTeamID_Detail.DefaultView.ToTable
        LoadtdbdTeamID("-1")

        'Load tdbdDepartmentID
        dt = dtDepartmentID.DefaultView.ToTable
        dt.DefaultView.RowFilter = "DepartmentID <>'%'"
        dt = dt.DefaultView.ToTable
        LoadDataSource(tdbdDepartmentID, dt, gbUnicode)

        '************************************
        'Load 10 quy cách
        LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01ID, gbUnicode)
    End Sub

    Private Sub LoadtdbdTeamID(ByVal sDepartmentID As String)
        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID_Detail, "DepartmentID  = " & SQLString(sDepartmentID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbdStageID(ByVal ID As String)
        Dim sSQL As String = ""

        If dtGrid.Rows(0).Item("Method").ToString = "1" Then
            sSQL = "Select '*' As StageID, N'<" & IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode = False, "Toång coäng", "Tổng cộng").ToString, "Total").ToString & ">' As StageName, '' As ProductID, 0 as DisplayOrder" & vbCrLf
            sSQL &= "Union" & vbCrLf
        End If

        sSQL &= "Select Distinct D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, D01.ProductID, 1 as DisplayOrder" & vbCrLf
        sSQL &= "From D45T1081 D01  WITH(NOLOCK) Inner join D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "Where ProductID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by DisplayOrder, StageID"
        dtStage = ReturnDataTable(sSQL)
        LoadDataSource(tdbdStageID, dtStage, gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""

        'Load tdbcTeamName
        dt_TeamID = ReturnTableTeamID(True, , gbUnicode)

        'Load tdbcDepartmentName
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadDataSource(tdbcDepartmentName, dtDepartmentID, gbUnicode)

        'Load tdbcProductName
        sSQL = "Select '%' As ProductID, " & AllName & " As ProductName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select D45.ProductID, D45.ProductName" & sUnicode & " As ProductName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "From D45T1000 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order by DisplayOrder, ProductName"
        dtProductID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcProductName, dtProductID, gbUnicode)
    End Sub

    Private Sub LoadtdbcTeamName()
        Dim sDepartmentID As String
        If tdbcDepartmentName.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentName.SelectedValue.ToString
        End If
        If sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamName, dt_TeamID, gbUnicode)
        Else
            LoadDataSource(tdbcTeamName, ReturnTableFilter(dt_TeamID, "DepartmentID = '%' Or DepartmentID = " & SQLString(sDepartmentID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcEmployeeName()
        Dim sDepartmentID As String
        Dim sTeamID As String
        If tdbcDepartmentName.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentName.SelectedValue.ToString
        End If
        If tdbcTeamName.SelectedValue Is Nothing Then
            sTeamID = ""
        Else
            sTeamID = tdbcTeamName.SelectedValue.ToString
        End If
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""
        sSQL = "SELECT DepartmentID,TeamID,EmployeeID , "
        If gbUnicode = False Then
            sSQL &= "Isnull(LastName,'')+' '+Isnull(MiddleName,'')+' ' +  Isnull(FirstName,'') As EmployeeName, " & vbCrLf
        Else
            sSQL &= "Isnull(LastNameU,'')+' '+Isnull(MiddleNameU,'')+' ' +  Isnull(FirstNameU,'') As EmployeeName, " & vbCrLf
        End If
        sSQL &= "1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM	D09T0201 " & vbCrLf
        sSQL &= "WHERE	Disabled = 0 AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "AND CASE WHEN " & SQLString(sDepartmentID) & " <> '%'	THEN DepartmentID ELSE '%' End = " & SQLString(sDepartmentID)
        sSQL &= "AND CASE WHEN " & SQLString(sTeamID) & " <> '%'	THEN TeamID ELSE '%' End = " & SQLString(sTeamID) & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT '%'  As DepartmentID, '%' As TeamID, '%' As EmployeeID , " & sLanguage & " As EmployeeName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, EmployeeName"

        LoadDataSource(tdbcEmployeeName, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcStageName(ByVal sProductID As String)
        Dim sSQL As String = ""
        sSQL = "SELECT Distinct D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM D45T1001 D01  WITH(NOLOCK) INNER JOIN	D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "WHERE D10.Disabled = 0 AND CASE WHEN " & SQLString(sProductID) & " <> '%'	THEN D01.ProductID ELSE '%' End = " & SQLString(sProductID) & vbCrLf
        sSQL &= "UNION " & vbCrLf
        sSQL &= "SELECT '%' As StageID, " & AllName & " As StageName, 0 as DisplayOrder " & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder,D01.StageID"
        LoadDataSource(tdbcStageName, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcDepartmentName"

    Private Sub tdbcDepartmentName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentName.SelectedValueChanged
        LoadtdbcTeamName()
        tdbcTeamName.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamName"

    Private Sub tdbcTeamName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamName.SelectedValueChanged
        LoadtdbcEmployeeName()
        tdbcEmployeeName.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcProductName"

    Private Sub tdbcProductName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProductName.SelectedValueChanged
        LoadtdbcStageName(CbVal(tdbcProductName))
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcDepartmentName.AutoCompletion = False
        tdbcTeamName.AutoCompletion = False
        tdbcEmployeeName.AutoCompletion = False
        tdbcProductName.AutoCompletion = False
        tdbcStageName.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentName.LostFocus, _
                tdbcTeamName.LostFocus, tdbcEmployeeName.LostFocus, tdbcProductName.LostFocus, tdbcStageName.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentName.Close, _
                tdbcTeamName.Close, tdbcEmployeeName.Close, tdbcProductName.Close, tdbcStageName.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentName.Validated, _
                tdbcTeamName.Validated, tdbcEmployeeName.Validated, tdbcProductName.Validated, tdbcStageName.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentName.KeyDown, tdbcTeamName.KeyDown, tdbcEmployeeName.KeyDown, tdbcProductName.KeyDown, tdbcStageName.KeyDown
        If gbUnicode Then Exit Sub
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbcName.AutoCompletion = False
            Case Else
                tdbcName.AutoCompletion = True
        End Select
    End Sub

    Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentName.Leave, tdbcTeamName.Leave, tdbcEmployeeName.Leave, tdbcProductName.LostFocus, tdbcStageName.Leave
        If gbUnicode Then Exit Sub
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

        If tdbcName.SelectedIndex <> -1 Then
            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLStoreD45P2006() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2006 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentName)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamName)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcEmployeeName)) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcProductName)) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcStageName)) & COMMA 'StageID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA  'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2000") 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2006()
        dtGrid = ReturnDataTable(sSQL)

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        CalTotalFooter()
        CheckMenuOther()

        If dtGrid.Rows.Count > 0 Then
            If dtGrid.Rows(0).Item("Mode").ToString = "1" Then 'tu D13
                tdbg.Splits(0).DisplayColumns("IsCheck").Visible = True
            Else 'tu D45
                tdbg.Splits(0).DisplayColumns("IsCheck").Visible = False
            End If

            If dtGrid.Rows(0).Item("Method").ToString = "1" Then 'theo phong ban
                tdbg.Splits(0).DisplayColumns(COL_RefEmployeeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmployeeName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Locked = False
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Locked = False
                tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
            Else 'tu D45
                tdbg.Splits(0).DisplayColumns(COL_RefEmployeeID).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_EmployeeName).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Locked = True
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Locked = True
                tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If

            '***********************
            For i As Integer = COL_Spec01ID To COL_Spec10ID
                tdbg.Splits(0).DisplayColumns(i).Visible = L3Bool(dtGrid.Rows(0).Item("IsSpec").ToString) AndAlso L3Bool(tdbg.Columns(i).Tag)
            Next
        Else
            For i As Integer = COL_Spec01ID To COL_Spec10ID
                tdbg.Splits(0).DisplayColumns(i).Visible = False
            Next
        End If
    End Sub


    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity01 To COL_Quantity20
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                If tdbg.Splits(0).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
        End If
    End Sub

    Private Sub LoadCaptionQuantity_UnitPrice()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity01 To COL_Quantity20
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                If tdbg.Splits(0).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
            For i As Integer = COL_UnitPrice01 To COL_UnitPrice05
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                If tdbg.Splits(0).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
        End If
    End Sub

    Private Sub CheckMenuOther()
        mnuFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnuListAll.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnuPrint.Enabled = tdbg.RowCount > 0
        mnuExportToExcel.Enabled = tdbg.RowCount > 0
    End Sub

#Region "Active Find - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
    End Property

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    LoadTDBGrid()
    'End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClauseClient.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()
        'LoadGridFind(tdbg, dtGrid, sFind)
        dtGrid.DefaultView.RowFilter = sFind
        CalTotalFooter()
        CheckMenuOther()
    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        sFind = ""
        sFindServer = ""
        LoadTDBGrid()
    End Sub
#End Region

    Private Sub CalTotalFooter()
        Dim dWorkingHours As Double = 0
        Dim dQuantity01 As Double = 0
        Dim dQuantity02 As Double = 0
        Dim dQuantity03 As Double = 0
        Dim dQuantity04 As Double = 0
        Dim dQuantity05 As Double = 0

        Dim dQuantity06 As Double = 0
        Dim dQuantity07 As Double = 0
        Dim dQuantity08 As Double = 0
        Dim dQuantity09 As Double = 0
        Dim dQuantity10 As Double = 0

        Dim dQuantity11 As Double = 0
        Dim dQuantity12 As Double = 0
        Dim dQuantity13 As Double = 0
        Dim dQuantity14 As Double = 0
        Dim dQuantity15 As Double = 0

        Dim dQuantity16 As Double = 0
        Dim dQuantity17 As Double = 0
        Dim dQuantity18 As Double = 0
        Dim dQuantity19 As Double = 0
        Dim dQuantity20 As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dWorkingHours += Number(tdbg(i, COL_WorkingHours))
            dQuantity01 += Number(tdbg(i, COL_Quantity01))
            dQuantity02 += Number(tdbg(i, COL_Quantity02))
            dQuantity03 += Number(tdbg(i, COL_Quantity03))
            dQuantity04 += Number(tdbg(i, COL_Quantity04))
            dQuantity05 += Number(tdbg(i, COL_Quantity05))

            dQuantity06 += Number(tdbg(i, COL_Quantity06))
            dQuantity07 += Number(tdbg(i, COL_Quantity07))
            dQuantity08 += Number(tdbg(i, COL_Quantity08))
            dQuantity09 += Number(tdbg(i, COL_Quantity09))
            dQuantity10 += Number(tdbg(i, COL_Quantity10))

            dQuantity11 += Number(tdbg(i, COL_Quantity11))
            dQuantity12 += Number(tdbg(i, COL_Quantity12))
            dQuantity13 += Number(tdbg(i, COL_Quantity13))
            dQuantity14 += Number(tdbg(i, COL_Quantity14))
            dQuantity15 += Number(tdbg(i, COL_Quantity15))

            dQuantity16 += Number(tdbg(i, COL_Quantity16))
            dQuantity17 += Number(tdbg(i, COL_Quantity17))
            dQuantity18 += Number(tdbg(i, COL_Quantity18))
            dQuantity19 += Number(tdbg(i, COL_Quantity19))
            dQuantity20 += Number(tdbg(i, COL_Quantity20))
        Next

        FooterTotalGrid(tdbg, COL_ProductName)

        tdbg.Columns(COL_WorkingHours).FooterText = Format(dWorkingHours, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity01).FooterText = Format(dQuantity01, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity02).FooterText = Format(dQuantity02, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity03).FooterText = Format(dQuantity03, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity04).FooterText = Format(dQuantity04, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity05).FooterText = Format(dQuantity05, DxxFormat.DefaultNumber2)

        tdbg.Columns(COL_Quantity06).FooterText = Format(dQuantity06, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity07).FooterText = Format(dQuantity07, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity08).FooterText = Format(dQuantity08, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity09).FooterText = Format(dQuantity09, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity10).FooterText = Format(dQuantity10, DxxFormat.DefaultNumber2)

        tdbg.Columns(COL_Quantity11).FooterText = Format(dQuantity11, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity12).FooterText = Format(dQuantity12, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity13).FooterText = Format(dQuantity13, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity14).FooterText = Format(dQuantity14, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity15).FooterText = Format(dQuantity15, DxxFormat.DefaultNumber2)

        tdbg.Columns(COL_Quantity16).FooterText = Format(dQuantity16, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity17).FooterText = Format(dQuantity17, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity18).FooterText = Format(dQuantity18, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity19).FooterText = Format(dQuantity19, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity20).FooterText = Format(dQuantity20, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub CalTotal(ByVal iCol As Integer)
        Dim dQuantity As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dQuantity += Number(tdbg(i, iCol))
        Next

        tdbg.Columns(COL_ProductName).FooterText = tdbg.RowCount.ToString
        tdbg.Columns(iCol).FooterText = Format(dQuantity, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub CalculatorProductNameFromSpec()
        Dim sFullProductName As String
        sFullProductName = ""
        '*****************************
        If tdbg.Columns(COL_ProductID).Text = "" Then
            tdbg.Columns(COL_ProductName).Text = ""
            Exit Sub
        End If
        '*****************************
        sFullProductName = IIf(IsDBNull(tdbg.Columns(COL_OProductName).Text), "", Trim(tdbg.Columns(COL_OProductName).Text)).ToString

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec01ID).Visible And tdbg.Columns(COL_Spec01ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec01ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec02ID).Visible And tdbg.Columns(COL_Spec02ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec02ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec03ID).Visible And tdbg.Columns(COL_Spec03ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec03ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec04ID).Visible And tdbg.Columns(COL_Spec04ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec04ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec05ID).Visible And tdbg.Columns(COL_Spec05ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec05ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec06ID).Visible And tdbg.Columns(COL_Spec06ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec06ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec07ID).Visible And tdbg.Columns(COL_Spec07ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec07ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec08ID).Visible And tdbg.Columns(COL_Spec08ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec08ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec09ID).Visible And tdbg.Columns(COL_Spec09ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec09ID).Text)
        End If

        If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec10ID).Visible And tdbg.Columns(COL_Spec10ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec10ID).Text)
        End If

        tdbg.Columns(COL_ProductName).Text = sFullProductName
    End Sub

    Private Sub CalculatorProductNameFromSpecs(ByVal RowCopy As Integer)
        Dim sFullProductName As String

        For i As Integer = RowCopy + 1 To tdbg.RowCount - 1
            If tdbg(i, COL_ProductID).ToString = "" Then
                tdbg(i, COL_ProductName) = ""
                Continue For
            End If

            sFullProductName = ""

            sFullProductName = IIf(IsDBNull(tdbg(i, COL_OProductName).ToString), "", Trim(tdbg(i, COL_OProductName).ToString)).ToString

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec01ID).Visible And tdbg(i, COL_Spec01ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec01ID, tdbdSpec01ID.DisplayMember, tdbdSpec01ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec01ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec02ID).Visible And tdbg(i, COL_Spec02ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec02ID, tdbdSpec02ID.DisplayMember, tdbdSpec02ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec02ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec03ID).Visible And tdbg(i, COL_Spec03ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec03ID, tdbdSpec03ID.DisplayMember, tdbdSpec03ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec03ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec04ID).Visible And tdbg(i, COL_Spec04ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec04ID, tdbdSpec04ID.DisplayMember, tdbdSpec04ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec04ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec05ID).Visible And tdbg(i, COL_Spec05ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec05ID, tdbdSpec05ID.DisplayMember, tdbdSpec05ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec05ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec06ID).Visible And tdbg(i, COL_Spec06ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec06ID, tdbdSpec06ID.DisplayMember, tdbdSpec06ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec06ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec07ID).Visible And tdbg(i, COL_Spec07ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec07ID, tdbdSpec07ID.DisplayMember, tdbdSpec07ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec07ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec08ID).Visible And tdbg(i, COL_Spec08ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec08ID, tdbdSpec08ID.DisplayMember, tdbdSpec08ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec08ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec09ID).Visible And tdbg(i, COL_Spec09ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec09ID, tdbdSpec09ID.DisplayMember, tdbdSpec09ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec09ID))))
            End If

            If tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec10ID).Visible And tdbg(i, COL_Spec10ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec10ID, tdbdSpec10ID.DisplayMember, tdbdSpec10ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec10ID))))
            End If

            tdbg(i, COL_ProductName) = sFullProductName
        Next
    End Sub

    Private Sub PressHeadClick()
        Dim bChoose As Boolean = Not bSelected
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsCheck)) = False Then
                tdbg(i, COL_IsUpdated) = bChoose
            End If
        Next
        bSelected = bChoose
    End Sub

    Private Sub TestStageID()
        LoadtdbdStageID(tdbg.Columns(COL_ProductID).Text)
        Dim dt As DataTable = dtStage.DefaultView.ToTable
        dt.DefaultView.RowFilter = "StageID=" & SQLString(tdbg.Columns(COL_StageID).Text)
        If dt.DefaultView.Count = 0 Then 'không tồn tại
            tdbg.Columns(COL_StageID).Text = ""
            tdbg.Columns(COL_StageName).Text = ""
        End If
    End Sub

#Region "tdbg"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate

        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)

            Case COL_ProductID
                TestStageID()
                CalculatorProductNameFromSpec()
            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
                CalculatorProductNameFromSpec()
            Case COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
                CalculatorProductNameFromSpec()
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                CalTotal(L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString))
        End Select

    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Dim iCol As Integer = L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
        Select Case iCol
            Case COL_StageID
                If L3Bool(tdbg.Columns(COL_IsCheck).Text) And tdbg.Splits(0).DisplayColumns("IsCheck").Visible Then
                    e.Cancel = True
                End If
                Exit Sub
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20, COL_UnitPrice01, COL_UnitPrice02, COL_UnitPrice03, COL_UnitPrice04, COL_UnitPrice05
                If L3Bool(tdbg.Columns(COL_IsCheck).Text) And tdbg.Splits(0).DisplayColumns("IsCheck").Visible Then
                    e.Cancel = True
                ElseIf L3Bool(tdbg.Columns(COL_IsUpdated).Text) = False Then
                    e.Cancel = True
                End If
                Exit Sub
            Case Else
                If iCol = COL_IsCheck Then Exit Sub
                If L3Bool(tdbg.Columns(COL_IsCheck).Text) And tdbg.Splits(0).DisplayColumns("IsCheck").Visible Then
                    e.Cancel = True
                End If
                Exit Sub
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_OProductName).Text = ""
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If

            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text.ToUpper <> tdbdStageID.Columns("StageID").Text.ToUpper Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text.ToUpper <> tdbdEmployeeID.Columns("EmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_DepartmentName
                If tdbg.Columns(COL_DepartmentName).Text <> tdbdDepartmentID.Columns(tdbdDepartmentID.DisplayMember).Text Then
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_EmployeeID).Text = ""
                End If
            Case COL_TeamName
                If tdbg.Columns(COL_TeamName).Text <> tdbdTeamID.Columns(tdbdTeamID.DisplayMember).Text Then
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_EmployeeID).Text = ""
                End If
            Case COL_PieceworkGroupID
                If tdbg.Columns(COL_PieceworkGroupID).Text.ToUpper <> tdbdPieceworkGroupID.Columns("PieceworkGroupID").Text.ToUpper Then
                    tdbg.Columns(COL_PieceworkGroupID).Text = ""
                End If
            Case COL_Spec01ID
                If tdbg.Columns(COL_Spec01ID).Text <> tdbdSpec01ID.Columns(tdbdSpec01ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec02ID
                If tdbg.Columns(COL_Spec02ID).Text <> tdbdSpec02ID.Columns(tdbdSpec02ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec03ID
                If tdbg.Columns(COL_Spec03ID).Text <> tdbdSpec03ID.Columns(tdbdSpec03ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec04ID
                If tdbg.Columns(COL_Spec04ID).Text <> tdbdSpec04ID.Columns(tdbdSpec04ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec05ID
                If tdbg.Columns(COL_Spec05ID).Text <> tdbdSpec05ID.Columns(tdbdSpec05ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec06ID
                If tdbg.Columns(COL_Spec06ID).Text <> tdbdSpec06ID.Columns(tdbdSpec06ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec07ID
                If tdbg.Columns(COL_Spec07ID).Text <> tdbdSpec07ID.Columns(tdbdSpec07ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec08ID
                If tdbg.Columns(COL_Spec08ID).Text <> tdbdSpec08ID.Columns(tdbdSpec08ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec09ID
                If tdbg.Columns(COL_Spec09ID).Text <> tdbdSpec09ID.Columns(tdbdSpec09ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec10ID
                If tdbg.Columns(COL_Spec10ID).Text <> tdbdSpec10ID.Columns(tdbdSpec10ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Quantity01
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity01).Text) Then e.Cancel = True
            Case COL_Quantity02
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity02).Text) Then e.Cancel = True
            Case COL_Quantity03
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity03).Text) Then e.Cancel = True
            Case COL_Quantity04
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity04).Text) Then e.Cancel = True
            Case COL_Quantity05
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity05).Text) Then e.Cancel = True
            Case COL_Quantity06
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity06).Text) Then e.Cancel = True
            Case COL_Quantity07
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity07).Text) Then e.Cancel = True
            Case COL_Quantity08
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity08).Text) Then e.Cancel = True
            Case COL_Quantity09
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity09).Text) Then e.Cancel = True
            Case COL_Quantity10
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity10).Text) Then e.Cancel = True
            Case COL_Quantity11
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity11).Text) Then e.Cancel = True
            Case COL_Quantity12
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity12).Text) Then e.Cancel = True
            Case COL_Quantity13
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity13).Text) Then e.Cancel = True
            Case COL_Quantity14
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity14).Text) Then e.Cancel = True
            Case COL_Quantity15
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity15).Text) Then e.Cancel = True
            Case COL_Quantity16
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity16).Text) Then e.Cancel = True
            Case COL_Quantity17
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity17).Text) Then e.Cancel = True
            Case COL_Quantity18
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity18).Text) Then e.Cancel = True
            Case COL_Quantity19
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity19).Text) Then e.Cancel = True
            Case COL_Quantity20
                If Not L3IsNumeric(tdbg.Columns(COL_Quantity20).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)

            Case COL_ProductID
                tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Text
                tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text

            Case COL_StageID
                tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
            Case COL_EmployeeID

                tdbg.Columns(COL_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text

            Case COL_RefEmployeeID

                tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdRefEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
            Case COL_DepartmentName
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                tdbg.Columns(COL_EmployeeID).Text = ""
            Case COL_TeamName
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
                tdbg.Columns(COL_EmployeeID).Text = ""
        End Select
    End Sub

    Private Sub tdbg_ColMove(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColMoveEventArgs) Handles tdbg.ColMove
        Dim iTmp As Integer
        If e.Position < e.ColIndex Then
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position + 1 Step -1
                arrayIndex(i) = arrayIndex(i - 1)
            Next
            arrayIndex(e.Position) = iTmp
        Else
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position - 1
                arrayIndex(i) = arrayIndex(i + 1)
            Next
            arrayIndex(e.Position) = iTmp
        End If

        bColMove = True
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Dim iCol As Integer = L3Int(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        Select Case iCol
            Case COL_EmployeeID
                If L3Bool(tdbg(tdbg.Row, COL_IsCheck)) Then
                    tdbg.Columns(COL_EmployeeID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_EmployeeID).DropDown = tdbdEmployeeID
                End If
            Case COL_RefEmployeeID
                If L3Bool(tdbg(tdbg.Row, COL_IsCheck)) Then
                    tdbg.Columns(COL_RefEmployeeID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_RefEmployeeID).DropDown = tdbdRefEmployeeID
                End If
            Case COL_ProductID
                If L3Bool(tdbg(tdbg.Row, COL_IsCheck)) Then
                    tdbg.Columns(COL_ProductID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_ProductID).DropDown = tdbdProductID
                End If
            Case COL_StageID
                LoadtdbdStageID(tdbg(tdbg.Row, COL_ProductID).ToString)

                If L3Bool(tdbg(tdbg.Row, COL_IsCheck)) Then
                    tdbg.Columns(COL_StageID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_StageID).DropDown = tdbdStageID
                End If

            Case COL_TeamName
                LoadtdbdTeamID(tdbg(tdbg.Row, COL_DepartmentID).ToString)
        End Select
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        'Khong hien thi Tooltip khi re len Caption cot
        If e.Row >= 0 Then
            Select Case e.ColIndex
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                    e.CellTip = IIf(gbUnicode = False, rL3("Nhan_F6_thuc_hien_phan_bo_VN"), ConvertVniToUnicode(rL3("Nhan_F6_thuc_hien_phan_bo_VN"))).ToString
                Case Else
                    e.CellTip = ""
            End Select
        Else
            e.CellTip = ""
        End If
    End Sub


    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString) = COL_IsUpdated Then
            tdbg.AllowSort = False
            PressHeadClick()
        Else
            Select Case e.ColIndex
                Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                    CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
                    CalculatorProductNameFromSpecs(tdbg.Row)
                Case Else
                    tdbg.AllowSort = True
            End Select
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case L3Int(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)
            Case COL_IsUpdated
                If e.Control And e.KeyCode = Keys.S Then
                    PressHeadClick()
                End If
            Case iColQuantityLast
                If e.KeyCode = Keys.Enter Then
                    HotKeyEnterGrid(tdbg, COL_IsUpdated, e)
                    Exit Sub
                End If
        End Select

        If e.KeyCode = Keys.F6 Then
            Select Case tdbg.Col
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                    If AllowSave() = False Then Exit Sub
                    Dim iMode As Integer
                    Dim bResult As DialogResult

                    bResult = MessageBox.Show(rL3("Tinh_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If bResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

                    If bResult = Windows.Forms.DialogResult.Yes Then
                        iMode = 0
                    ElseIf bResult = Windows.Forms.DialogResult.No Then
                        iMode = 1
                    End If

                    CalF6(tdbg.Columns(tdbg.Col).DataField, iMode)
            End Select
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case L3Int(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)
            Case COL_Quantity01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity06
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity07
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity08
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity09
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity11
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity12
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity13
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity14
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity15
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity16
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity17
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity18
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity19
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice01, COL_UnitPrice02, COL_UnitPrice03, COL_UnitPrice04, COL_UnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dr() As DataRow = dtGrid.Select("IsUpdated= True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUpdated)) Then
                If tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible Then
                    If tdbg(i, COL_EmployeeID).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Ma_NV"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_EmployeeID
                        tdbg.Bookmark = i

                        Return False
                    End If
                End If

                If dtGrid.Rows(0).Item("Method").ToString = "1" Then 'theo phong ban
                    If tdbg(i, COL_DepartmentName).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Phong_ban"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_DepartmentName
                        tdbg.Bookmark = i

                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Function SQLDeleteD45T2001(ByVal sTransID As String, ByVal sProductVoucherID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2001" & vbCrLf
        sSQL &= "Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " AND TranMonth = " & SQLNumber(giTranMonth)
        sSQL &= " AND TranYear = " & SQLNumber(giTranYear)
        sSQL &= " AND ProductVoucherID In (" & sProductVoucherID & ")" '& SQLString(_productVoucherID)
        sSQL &= " AND TransID IN (" & sTransID & ")"
        Return sSQL
    End Function

    Private Function SQLInsertD45T2001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        '100 dòng Insert 1 lần
        Dim iCount As Integer = 0 'Đếm số dòng để lưu

        Dim sTransID As String = ""
        Dim sProductVoucherID As String = ""

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUpdated)) Then

                sTransID &= SQLString(tdbg(i, COL_TransID)) & COMMA
                sProductVoucherID &= SQLString(tdbg(i, COL_ProductVoucherID)) & COMMA

                sSQL.Append("Insert Into D45T2001(")
                sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
                sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
                sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, ")
                sSQL.Append("Quantity06, Quantity07, Quantity08, Quantity09, Quantity10, ")
                sSQL.Append("Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, ")
                sSQL.Append("Quantity16, Quantity17, Quantity18, Quantity19, Quantity20, ")
                sSQL.Append("IsLocked, TransID, ")
                sSQL.Append("Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, ")
                sSQL.Append("Spec06ID, Spec07ID, Spec08ID, Spec09ID, Spec10ID, ")
                sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, OrderNo, PieceworkGroupID, ")
                sSQL.Append("WorkingHours, MasterApportionCoef, DetailApportionCoef")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_ProductVoucherID)) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_PayrollVoucherID)) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID, varchar[20], NOT NULL

                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity01), DxxFormat.DefaultNumber2) & COMMA) 'Quantity01, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity02), DxxFormat.DefaultNumber2) & COMMA) 'Quantity02, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity03), DxxFormat.DefaultNumber2) & COMMA) 'Quantity03, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity04), DxxFormat.DefaultNumber2) & COMMA) 'Quantity04, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity05), DxxFormat.DefaultNumber2) & COMMA) 'Quantity05, decimal, NOT NULL

                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity06), DxxFormat.DefaultNumber2) & COMMA) 'Quantity06, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity07), DxxFormat.DefaultNumber2) & COMMA) 'Quantity07, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity08), DxxFormat.DefaultNumber2) & COMMA) 'Quantity08, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity09), DxxFormat.DefaultNumber2) & COMMA) 'Quantity09, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity10), DxxFormat.DefaultNumber2) & COMMA) 'Quantity10, decimal, NOT NULL

                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity11), DxxFormat.DefaultNumber2) & COMMA) 'Quantity11, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity12), DxxFormat.DefaultNumber2) & COMMA) 'Quantity12, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity13), DxxFormat.DefaultNumber2) & COMMA) 'Quantity13, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity14), DxxFormat.DefaultNumber2) & COMMA) 'Quantity14, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity15), DxxFormat.DefaultNumber2) & COMMA) 'Quantity15, decimal, NOT NULL

                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity16), DxxFormat.DefaultNumber2) & COMMA) 'Quantity16, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity17), DxxFormat.DefaultNumber2) & COMMA) 'Quantity17, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity18), DxxFormat.DefaultNumber2) & COMMA) 'Quantity18, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity19), DxxFormat.DefaultNumber2) & COMMA) 'Quantity19, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity20), DxxFormat.DefaultNumber2) & COMMA) 'Quantity20, decimal, NOT NULL

                sSQL.Append(SQLNumber(tdbg(i, COL_IsLocked)) & COMMA) 'IsLocked, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL

                If L3Bool(dtGrid.Rows(0).Item("IsSpec").ToString) Then
                    sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA) 'Spec10ID, varchar[50], NOT NULL
                Else
                    sSQL.Append(SQLString("") & COMMA) 'Spec01ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec02ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec03ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec04ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec05ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec06ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec07ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec08ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec09ID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'Spec10ID, varchar[50], NOT NULL
                End If

                sSQL.Append(SQLString(tdbg(i, COL_CreateUserID)) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append(SQLDateSave(tdbg(i, COL_CreateDate)) & COMMA) 'CreateDate, datetime, NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo)) & COMMA) 'OrderNo, int, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_WorkingHours)) & COMMA) 'WorkingHours, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_MasterApportionCoef)) & COMMA) 'MasterApportionCoef, decimal, NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_DetailApportionCoef))) 'DetailApportionCoef, decimal, NOT NULL
                sSQL.Append(")" & vbCrLf)

                iCount += 1
                If iCount = 100 Then
                    'Bỏ , cuối cùng
                    sTransID = sTransID.Remove(sTransID.LastIndexOf(","), 1)
                    sProductVoucherID = sProductVoucherID.Remove(sProductVoucherID.LastIndexOf(","), 1)
                    '--------------------
                    sRet.Append(SQLDeleteD45T2001(sTransID, sProductVoucherID) & vbCrLf)
                    sRet.Append(sSQL.ToString)

                    sSQL.Remove(0, sSQL.Length)

                    bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                    iCount = 0
                    sRet.Remove(0, sRet.Length)
                End If
                '*****************************
            End If
        Next
        'Thực thi những dòng còn lại
        If sTransID <> "" Then
            sTransID = sTransID.Remove(sTransID.LastIndexOf(","), 1)
            sProductVoucherID = sProductVoucherID.Remove(sProductVoucherID.LastIndexOf(","), 1)

            sRet.Append(SQLDeleteD45T2001(sTransID, sProductVoucherID) & vbCrLf)
            sRet.Append(sSQL.ToString)
            sSQL.Remove(0, sSQL.Length)
        End If
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Dim sSQL As New StringBuilder("")
        Me.Cursor = Cursors.WaitCursor
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sSQL.Append(SQLInsertD45T2001s)

        If sSQL.ToString <> "" Then
            ExecuteSQL_MoreCommand(sSQL.ToString) 'Thực thi những dòng còn lại
        End If

        Me.Cursor = Cursors.Default

        If bRunSQL Then
            trans.Commit()
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()

            Me.Cursor = Cursors.WaitCursor
            LoadTDBGrid()
            Me.Cursor = Cursors.Default
        Else
            trans.Rollback()
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function ExecuteSQL_MoreCommand(ByVal strSQL As String) As Boolean
        If Trim(strSQL) = "" Then Exit Function

        'Update 18/10/2010: Chỉ kiểm tra cho trường hợp nhập liệu Unicode
        'Khi Lưu xuống database nếu chiều dài dữ liệu vượt quá giới hạn cho phép thì không thông báo
        If gbUnicode Then strSQL = "SET ANSI_WARNINGS OFF " & vbCrLf & strSQL

        Dim cmd As New SqlCommand(strSQL, conn)

        If giAppMode = 0 Then

            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                'trans.Commit()
                'conn.Close()
                Return bRunSQL
            Catch
                bRunSQL = False
                'trans.Rollback()
                'conn.Close()
                Clipboard.Clear()
                Clipboard.SetText(strSQL)
                MsgErr("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard")
                WriteLogFile1(strSQL)
                Return bRunSQL
            End Try

        Else
            'Dùng D99D0041 mới
            Dim bCaLlWS As Boolean = False
            bCaLlWS = CallWebService.ExcuteSQLQuery(strSQL, gsCompanyID, gsUserID, True, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
            If Not bCaLlWS Then
                MsgErr(CallWebService.ResultError)
                WriteLogFile1(strSQL)
            End If
            Return bCaLlWS
        End If
    End Function

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim sReportName As String
        Dim sReportPath As String = ""

        sReportName = GetReportPath("D45F2006", "D45R4040", "", sReportPath)

        If sReportName = "" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        'Dim report As New D99C1003
		
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_dieu_chinh_phieu_cham_cong_san_pham") & " - " & sReportName
        sSQL = SQLStoreD45P2006()
        sSQLSub = "Select * From D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub btnShowOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOption.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowOption.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Function SQLStoreD45P0020(ByVal sQuantity As String, ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P0020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'Hostname, varchar[20], NOT NULL
        sSQL &= SQLString(sQuantity) & COMMA 'Quantity, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub CalF6(ByVal sQuantity As String, ByVal iMode As Integer)
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        sRet = SQLInsertD45T2005s()

        If sRet.ToString = "-1" Then ' Thực thi không thành công
            trans.Rollback()
        Else ' Thực thi thành công
            trans.Commit()
            'Load lai luoi 
            Dim sSQL As String = SQLStoreD45P0020(sQuantity, iMode)
            dtGrid = ReturnDataTable(sSQL)
            LoadDataSource(tdbg, dtGrid, gbUnicode)

            CalTotalFooter()
        End If

        btnClose.Enabled = True
        btnClose.Focus()
        If _FormState <> EnumFormState.FormView Then btnSave.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLInsertD45T2005s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")
        Dim iCount As Integer = 0 'Đếm số dòng Insert

        'mo ket noi
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sRet.Remove(0, sRet.Length)
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D45T2005(")
            sSQL.Append("DepartmentID, TeamID, EmployeeID, RefEmployeeID, ProductID, ")
            sSQL.Append("StageID, Quantity01, Quantity02, Quantity03, Quantity04, ")
            sSQL.Append("Quantity05, IsLocked, TransID, OrderNo, CreateUserID, ")
            sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate, PieceworkGroupID, Apportion, ")
            sSQL.Append("UserID, Hostname, UnitPrice01, UnitPrice02, UnitPrice03, ")
            sSQL.Append("UnitPrice04, UnitPrice05, Mode, IsUpdated, IsCheck, ")
            sSQL.Append("Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, ")
            sSQL.Append("Spec06ID, Spec07ID, Spec08ID, Spec09ID, Spec10ID, ")
            sSQL.Append("ProductVoucherID, PayrollVoucherID, WorkingHours, MasterApportionCoef, DetailApportionCoef")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_RefEmployeeID)) & COMMA) 'RefEmployeeID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity01), DxxFormat.DefaultNumber2) & COMMA) 'Quantity01, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity02), DxxFormat.DefaultNumber2) & COMMA) 'Quantity02, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity03), DxxFormat.DefaultNumber2) & COMMA) 'Quantity03, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity04), DxxFormat.DefaultNumber2) & COMMA) 'Quantity04, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity05), DxxFormat.DefaultNumber2) & COMMA) 'Quantity05, decimal, NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsLocked)) & COMMA) 'IsLocked, tinyint, NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo)) & COMMA) 'OrderNo, int, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Apportion)) & COMMA) 'Apportion, int, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'Hostname, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice01), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice02), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice03), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice04), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice05), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice05, decimal, NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Mode, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsUpdated)) & COMMA) 'IsUpdated, bit, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsCheck)) & COMMA) 'IsCheck, bit, NOT NULL

            If L3Bool(dtGrid.Rows(0).Item("IsSpec").ToString) Then
                sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA) 'Spec10ID, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'Spec01ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec02ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec03ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec04ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec05ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec06ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec07ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec08ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec09ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec10ID, varchar[50], NOT NULL
            End If

            sSQL.Append(SQLString(tdbg(i, COL_ProductVoucherID)) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PayrollVoucherID)) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_WorkingHours)) & COMMA) 'WorkingHours, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_MasterApportionCoef)) & COMMA) 'MasterApportionCoef, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_DetailApportionCoef))) 'DetailApportionCoef, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iCount += 1

            If iCount = 100 OrElse (i = tdbg.RowCount - 1) Then
                bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                iCount = 0
                sRet.Remove(0, sRet.Length)
                If bRunSQL = False Then 'thuc thi k thanh cong
                    sRet.Append("-1")
                    Return sRet
                End If

            End If
        Next
        Return sRet
    End Function

    Public Sub WriteLogFile1(ByVal Text As String)
        Dim sLog As String = ""
        Dim sFileName As String = gsApplicationPath & "\Log.log"
        If (My.Computer.FileSystem.FileExists(sFileName) = False) Then My.Computer.FileSystem.WriteAllText(sFileName, "", True)
        Dim lFileSize As Long = My.Computer.FileSystem.GetFileInfo(sFileName).Length
        If lFileSize > 10 * 1028 * 1028 Then My.Computer.FileSystem.DeleteFile(sFileName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        sLog &= Space(20) & Now & vbCrLf
        sLog &= Text & vbCrLf
        sLog &= "--------------------------------------------------------------------------" & vbCrLf
        My.Computer.FileSystem.WriteAllText(sFileName, sLog, True)
    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        'Chuẩn hóa D09U1111 B7: Xuất Excel
        Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols, sFieldSum_Group)
	CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        'ResetTableForExcel(tdbg, gdtCaptionExcel, sFieldSum_Group)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = gdtCaptionExcel
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

End Class