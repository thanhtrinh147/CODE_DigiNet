﻿Imports System.Data
Imports System
Imports System.Collections
Imports C1.C1Excel
Imports System.IO
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class D45F2002
	Dim dtCaptionCols As DataTable

    'Dim bFlagShiftInsert As Boolean = False
    Const Quantity01 As Integer = 1
    Dim dtEmployee As DataTable
    Dim dtStage, dtProduct As DataTable
    Dim dtRefEmployee, dtFirstName As DataTable
    Dim dtGrid As DataTable
    Dim bFormLoad As Boolean = False
    Dim iLastCol As Integer
    Dim sOldStageID As String = ""

    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing
    Dim bRunExcute As Boolean = True
    Dim sRet As New StringBuilder("") 'luu gtri du ra
    Dim iOrderNo As Long = 0 'luu lastKey cua OrderNo
    Dim arrayIndex(COL_ToTal - 1) As Integer 'mang luu giu gtri index sau khi doi cot
    Dim bColMove As Boolean 'ktra xem co doi cot k?
    Dim iColCheck As Integer = 0 'ktra xem co copy ca 2 cot EmployeeID va RefEmployeeID k?
    Dim bCopyRef As Boolean = False 'True co copy cot RefEmployeeID
    Dim oData(,) As Object
    Dim oField(,) As Object
    Dim iPrevRow As Integer = 0
    Private iCopyRows As Integer = 0, iCopyCol As Integer = 0
    Private sFirstCol As String = "ProductID"
    Private iCurrentCol As Integer
    Private iFirstColunm As Integer
    Private sLastProductID As String = ""
    Private bPressCopy As Boolean = False
    Friend WithEvents C1XLBook1 As New C1.C1Excel.C1XLBook
    Private iOldFirstRow_CtrlE As Integer = 0, iOldLastRow_CtrlE As Integer = 0, iOldCol_CtrlE As Integer = 0
    Dim bNotInList As Boolean = False
    Dim iCols() As Integer = {COL_ProductName, COL_OProductName}

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_IsLocked As Integer = 1          ' IsLocked
    Private Const COL_OrderNum As Integer = 2          ' STT
    Private Const COL_PieceworkGroupID As Integer = 3  ' Nhóm chấm công
    Private Const COL_EmployeeID As Integer = 4        ' Mã nhân viên
    Private Const COL_RefEmployeeID As Integer = 5     ' Mã nhân viên phụ
    Private Const COL_FirstName As Integer = 6         ' Tên NV
    Private Const COL_EmployeeName As Integer = 7      ' Họ và tên
    Private Const COL_DepartmentID As Integer = 8      ' Mã phòng ban
    Private Const COL_TeamID As Integer = 9            ' Mã tổ nhóm
    Private Const COL_ProductID As Integer = 10        ' Sản phẩm
    Private Const COL_ProductName As Integer = 11      ' Tên sản phẩm
    Private Const COL_StageID As Integer = 12          ' Mã công đoạn
    Private Const COL_StageName As Integer = 13        ' Tên công đoạn
    Private Const COL_Spec01ID As Integer = 14         ' Spec01ID
    Private Const COL_Spec02ID As Integer = 15         ' Spec02ID
    Private Const COL_Spec03ID As Integer = 16         ' Spec03ID
    Private Const COL_Spec04ID As Integer = 17         ' Spec04ID
    Private Const COL_Spec05ID As Integer = 18         ' Spec05ID
    Private Const COL_Spec06ID As Integer = 19         ' Spec06ID
    Private Const COL_Spec07ID As Integer = 20         ' Spec07ID
    Private Const COL_Spec08ID As Integer = 21         ' Spec08ID
    Private Const COL_Spec09ID As Integer = 22         ' Spec09ID
    Private Const COL_Spec10ID As Integer = 23         ' Spec10ID
    Private Const COL_Quantity01 As Integer = 24       ' Số lượng 01
    Private Const COL_Quantity02 As Integer = 25       ' Số lượng 02
    Private Const COL_Quantity03 As Integer = 26       ' Số lượng 03
    Private Const COL_Quantity04 As Integer = 27       ' Số lượng 04
    Private Const COL_Quantity05 As Integer = 28       ' Số lượng 05
    Private Const COL_Quantity06 As Integer = 29       ' Quantity06
    Private Const COL_Quantity07 As Integer = 30       ' Quantity07
    Private Const COL_Quantity08 As Integer = 31       ' Quantity08
    Private Const COL_Quantity09 As Integer = 32       ' Quantity09
    Private Const COL_Quantity10 As Integer = 33       ' Quantity10
    Private Const COL_Quantity11 As Integer = 34       ' Quantity11
    Private Const COL_Quantity12 As Integer = 35       ' Quantity12
    Private Const COL_Quantity13 As Integer = 36       ' Quantity13
    Private Const COL_Quantity14 As Integer = 37       ' Quantity14
    Private Const COL_Quantity15 As Integer = 38       ' Quantity15
    Private Const COL_Quantity16 As Integer = 39       ' Quantity16
    Private Const COL_Quantity17 As Integer = 40       ' Quantity17
    Private Const COL_Quantity18 As Integer = 41       ' Quantity18
    Private Const COL_Quantity19 As Integer = 42       ' Quantity19
    Private Const COL_Quantity20 As Integer = 43       ' Quantity20
    Private Const COL_Notes As Integer = 44            ' Ghi chú
    Private Const COL_CreateUserID As Integer = 45     ' CreateUserID
    Private Const COL_CreateDate As Integer = 46       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 47 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 48   ' LastModifyDate
    Private Const COL_OrderNo As Integer = 49          ' OrderNo
    Private Const COL_Apportion As Integer = 50        ' Apportion
    Private Const COL_OProductName As Integer = 51     ' OProductName
    Private Const COL_Permission As Integer = 52       ' Permission

    Private Const COL_ToTal As Integer = 53
#End Region

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master

    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private _productVoucherID As String
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _productVoucherNo As String
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private _voucherDate As String
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _note As String
    Public WriteOnly Property Note() As String
        Set(ByVal Value As String)
            _note = Value
        End Set
    End Property

    Private _payrollVoucherID As String
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _departmentID As String
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _employeeID As String
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

    Private _isSpec As Boolean
    Public WriteOnly Property IsSpec() As Boolean
        Set(ByVal Value As Boolean)
            _isSpec = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D45F2002_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
            Exit Sub
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

    Private Sub D45F2002_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        bFormLoad = True

        Loadlanguage()
        LoadTDBCombo()
        LoadTDBDropDown()
        LoadData()
        LoadCaptionQuantity()

        ResetFooterGrid(tdbg)
        tdbg_LockedColumns()
        tdbg_NumberFormat()

        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)

        'Su dung Enter di chuyen den o duoi o hien hanh
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown

        'Khoi tao mang luu chi so 
        For i As Integer = 0 To tdbg.Columns.Count - 1
            arrayIndex(i) = i
        Next

        '*****************************************
        CallD09U1111_Button(True)
        '*****************************************
        InputbyUnicode(Me, gbUnicode)
        '********************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_EmployeeID, COL_ProductID, COL_StageID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)

    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chi tiÕt thçng k£ s¶n phÈm tÛnh l§¥ng
        '================================================================ 
        lblProductID.Text = rl3("Ma_san_pham") 'Mã sản phẩm
        lblStageID.Text = rl3("Ma_cong_doan") 'Mã công đoạn
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        btnAdjust.Text = rl3("_Dieu_chinh_phieu") '&Điều chỉnh phiếu
        btnShowOption.Text = "F12 ( " & rl3("Hien_thi") & " )" 'Hiển thị (F12)
        '================================================================ 
        chkTestDuplicate.Text = rl3("Kiem_tra_trung_ma") 'Kiểm tra trùng mã
        '================================================================ 
        grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã 
        tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdProductID.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbdProductID.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdStageID.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbdEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbdEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdRefEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma") 'Mã 
        tdbdRefEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdRefEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdRefEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbdRefEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdRefEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdPieceworkGroupID.Columns("PieceworkGroupID").Caption = rl3("Ma") 'Mã
        tdbdPieceworkGroupID.Columns("PieceworkGroupName").Caption = rl3("Ten") 'Tên
        tdbdFirstName.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdFirstName.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdFirstName.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdFirstName.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbdFirstName.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdFirstName.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdSpec01ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec01ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec02ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec02ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec03ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec03ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec04ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec04ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec05ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec05ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec06ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec06ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec07ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec07ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec08ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec08ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec09ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec09ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        tdbdSpec10ID.Columns("SpecID").Caption = rl3("Ma") 'Mã
        tdbdSpec10ID.Columns("SpecName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rl3("STT") 'STT
        tdbg.Columns(COL_PieceworkGroupID).Caption = rl3("Nhom_cham_cong") 'Nhóm chấm công
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_RefEmployeeID).Caption = rl3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        tdbg.Columns(COL_FirstName).Caption = rl3("Ten_NV") 'Tên NV
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_ProductID).Caption = rl3("San_pham") 'Sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns(COL_StageID).Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns(COL_StageName).Caption = rl3("Ten_cong_doan") 'Tên công đoạn
        tdbg.Columns(COL_Quantity01).Caption = rl3("So_luong") & " 01" 'Số lượng 01
        tdbg.Columns(COL_Quantity02).Caption = rl3("So_luong") & " 02" 'Số lượng 02
        tdbg.Columns(COL_Quantity03).Caption = rl3("So_luong") & " 03" 'Số lượng 03
        tdbg.Columns(COL_Quantity04).Caption = rl3("So_luong") & " 04" 'Số lượng 04
        tdbg.Columns(COL_Quantity05).Caption = rl3("So_luong") & " 05" 'Số lượng 05
        tdbg.Columns(COL_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub


    'Private Sub Loadlanguage()
    '    '================================================================ 
    '    Me.Text = rl3("Chi_tiet_cham_cong_-_D45F2002") & UnicodeCaption(gbUnicode)  'Chi tiÕt chÊm c¤ng - D45F2002
    '    '================================================================ 
    '    lblProductID.Text = rl3("Ma_san_pham") 'Mã sản phẩm
    '    lblStageID.Text = rl3("Ma_cong_doan") 'Mã công đoạn
    '    '================================================================ 
    '    btnSave.Text = rl3("_Luu") '&Lưu
    '    btnClose.Text = rl3("Do_ng") 'Đó&ng
    '    btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
    '    btnAdjust.Text = rl3("Die_u_chinh_phieu") 'Điề&u chỉnh phiếu
    '    btnShowOption.Text = rl3("Hien_thi") & Space(1) & "(F12)"
    '    '================================================================ 
    '    chkTestDuplicate.Text = rl3("Kiem_tra_trung_ma") 'Kiểm tra trùng mã
    '    '================================================================ 
    '    grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
    '    '================================================================ 
    '    tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
    '    tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
    '    tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã 
    '    tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
    '    '================================================================ 
    '    tdbdEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
    '    tdbdEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
    '    tdbdEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
    '    tdbdEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
    '    tdbdEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
    '    tdbdEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
    '    tdbdProductID.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
    '    tdbdProductID.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
    '    tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
    '    tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdStageID.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
    '    tdbdRefEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
    '    tdbdRefEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
    '    tdbdRefEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
    '    tdbdEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
    '    tdbdPieceworkGroupID.Columns("PieceworkGroupID").Caption = rl3("Ma") 'Mã
    '    tdbdPieceworkGroupID.Columns("PieceworkGroupName").Caption = rl3("Ten") 'Tên
    '    tdbdFirstName.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
    '    tdbdFirstName.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
    '    tdbdFirstName.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
    '    tdbdFirstName.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
    '    tdbdFirstName.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
    '    tdbdSpec01ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec01ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec02ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec02ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec03ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec03ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec04ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec04ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec05ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec05ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec06ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec06ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec07ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec07ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec08ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec08ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec09ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec09ID.Columns("SpecName").Caption = rl3("Ten")
    '    tdbdSpec10ID.Columns("SpecID").Caption = rl3("Ma")
    '    tdbdSpec10ID.Columns("SpecName").Caption = rl3("Ten")
    '    '================================================================ 
    '    tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
    '    tdbg.Columns("PieceworkGroupID").Caption = rl3("Nhom_cham_cong") 'Nhóm chấm công
    '    tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
    '    tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
    '    tdbg.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
    '    tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
    '    tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
    '    tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
    '    tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
    '    tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
    '    tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
    '    tdbg.Columns("StageName").Caption = rL3("Ten_cong_doan") 'Tên công đoạn
    '    tdbg.Columns("Notes").Caption = rL3("Ghi_chu") 'Ghi chú
    '    '================================================================ 
    'End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        If D45Options.CancelEmployeeID Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
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

    End Sub
    Private Sub LoadData()
        txtProductVoucherNo.Text = _productVoucherNo
        txtVoucherDate.Text = _voucherDate
        txtNote.Text = _note
        LoadTDBGrid()
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcProductID
        'NGOCHUY 107016 21/03/2017
        sSQL = "--Do nguon cho Combo Ma san pham" & vbCrLf
        sSQL &= "Select ProductID, ProductName" & UnicodeJoin(gbUnicode) & " As ProductName" & vbCrLf
        sSQL &= " From D45T1000 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 AND StatusID <> '0002'" & vbCrLf
        'sSQL &= "Where Disabled=0 AND StatusID = '0001'" & vbCrLf
        sSQL &= "Order by DisplayOrder, ProductID"
        dtProduct = ReturnDataTable(sSQL)
        LoadDataSource(tdbcProductID, dtProduct, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdEmployeeID
        sSQL = "Select * From " & SQLUDFD45N6666()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        dtEmployee = dt.DefaultView.ToTable
        dtRefEmployee = dt.DefaultView.ToTable
        dtFirstName = dt.DefaultView.ToTable

        If _departmentID <> "%" AndAlso _teamID <> "%" Then
            dtEmployee.DefaultView.RowFilter = "DepartmentID = " & SQLString(_departmentID) & " and TeamID = " & SQLString(_teamID)
        ElseIf _departmentID <> "%" AndAlso _teamID = "%" Then
            dtEmployee.DefaultView.RowFilter = "DepartmentID = " & SQLString(_departmentID)
        ElseIf _departmentID = "%" AndAlso _teamID <> "%" Then
            dtEmployee.DefaultView.RowFilter = "TeamID = " & SQLString(_teamID)
        End If
        dtEmployee.DefaultView.Sort = "EmployeeID"
        dtEmployee = dtEmployee.DefaultView.ToTable
        LoadDataSource(tdbdEmployeeID, dtEmployee, gbUnicode)

        'Load tdbdRefEmployeeID
        dtRefEmployee.DefaultView.Sort = "RefEmployeeID"
        dtRefEmployee = dtRefEmployee.DefaultView.ToTable
        LoadDataSource(tdbdRefEmployeeID, dtRefEmployee, gbUnicode)

        'Load tdbdFirstName
        dtFirstName.DefaultView.Sort = "FirstName"
        dtFirstName = dtFirstName.DefaultView.ToTable
        LoadDataSource(tdbdFirstName, dtFirstName, gbUnicode)

        'Load tdbdProductID
        LoadDataSource(tdbdProductID, ReturnTableFilter(dtProduct, ""), gbUnicode)

        'Load tdbdPieceworkGroupID
        sSQL = "Select PieceworkGroupID, PieceworkGroupName" & UnicodeJoin(gbUnicode) & " As PieceworkGroupName" & vbCrLf
        sSQL &= "From D45T1050 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by PieceworkGroupID"
        LoadDataSource(tdbdPieceworkGroupID, sSQL, gbUnicode)

        '************************************
        If _isSpec Then
            LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 0, gbUnicode)
            'Load 10 quy cách
            LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01ID, gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBGridSpecificationCaption(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Spec01ID As Integer, ByVal Split As Integer, Optional ByVal bUnicode As Boolean = False)
        Dim bUseSpec As Boolean = False

        Dim sSQL As String = "Select SpecTypeID, Caption" & UnicodeJoin(bUnicode) & " as Caption, IsD45, Disabled From D07T0410  WITH(NOLOCK) Order by SpecTypeID"
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
                tdbg.Splits(Split).DisplayColumns(iIndex).Visible = L3Bool(tdbg.Columns(iIndex).Tag)

                iIndex += 1
            Next
        End If
        dt = Nothing
    End Sub

    Private Sub LoadComboStageID(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL = "Select D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, D01.ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner join	D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "Where D10.Disabled = 0 And ProductID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by D01.OrderNo"

        LoadDataSource(tdbcStageID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbdStageID(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL = "Select Distinct D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, D01.ProductID" & vbCrLf
        sSQL &= "From D45T1081 D01  WITH(NOLOCK) Inner join D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "Where D01.ProductID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by D01.StageID"

        LoadDataSource(tdbdStageID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcProductID with txtProductName"

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        If tdbcProductID.SelectedValue Is Nothing Then
            txtProductName.Text = ""
        Else
            txtProductName.Text = tdbcProductID.Columns(1).Value.ToString
        End If

        LoadComboStageID(tdbcProductID.Text)
        tdbcStageID.SelectedValue = sOldStageID
        If tdbcStageID.Text = "" Then sOldStageID = ""
    End Sub

    Private Sub tdbcProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
            txtProductName.Text = ""
            tdbcStageID.Text = ""
            txtStageName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcStageID with txtStageName"

    Private Sub tdbcStageID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.SelectedValueChanged
        If tdbcStageID.SelectedValue Is Nothing Then
            txtStageName.Text = ""
        Else
            txtStageName.Text = tdbcStageID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then
            tdbcStageID.Text = ""
        End If

        sOldStageID = tdbcStageID.Text
    End Sub
#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2002()
        dtGrid = ReturnDataTable(sSQL)

        'Add vao cot STT
        dtGrid.Columns.Add("OrderNum", Type.GetType("System.Single"))

        LoadDataSource(tdbg, dtGrid, gbUnicode)

        CalFooterAndOrderNo()
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled" & vbCrLf
        sSQL &= "From D45T0010  WITH(NOLOCK) Where Type = 'QTY'" & vbCrLf
        sSQL &= "Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity01 To COL_Quantity20
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = Not CBool(dt.Rows(j).Item("Disabled"))
                j += 1
            Next
        End If
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

        If tdbg.Splits(0).DisplayColumns(COL_Spec01ID).Visible And tdbg.Columns(COL_Spec01ID).Text <> "" Then
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

            If tdbg.Splits(0).DisplayColumns(COL_Spec01ID).Visible And tdbg(i, COL_Spec01ID).ToString <> "" Then
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

#Region "Luoi"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_OProductName).Text = ""
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                Else
                    tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Text
                    tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                    tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                    CalculatorProductNameFromSpec()
                End If

            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text.ToUpper <> tdbdStageID.Columns("StageID").Text.ToUpper Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                Else
                    tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                    tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
                End If
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text.ToUpper <> tdbdEmployeeID.Columns("EmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdRefEmployeeID.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
                End If
            Case COL_FirstName
                If tdbg.Columns(COL_FirstName).Text.ToUpper <> tdbdFirstName.Columns("FirstName").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdFirstName.Columns("FirstName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdFirstName.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdFirstName.Columns("TeamID").Text
                End If
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
                CalTotalFooter(CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString))
        End Select

        If tdbg.Columns(COL_OrderNum).Text = "" Then tdbg.Columns(COL_OrderNum).Text = (tdbg.Bookmark + 1).ToString
        FooterTotalGrid(tdbg, COL_PieceworkGroupID)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Dim iCol As Integer = CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        If e.KeyCode = Keys.F7 Then
            If iCol = COL_EmployeeID Or iCol = COL_RefEmployeeID Then
                HotKeyF7(tdbg)
                Dim Dt1 As DataTable
                If tdbg.Columns(COL_EmployeeID).Text = String.Empty OrElse tdbg.Columns(COL_EmployeeID).Text Is Nothing Then
                    Dt1 = ReturnTableFilter(dtRefEmployee.Copy, "RefEmployeeID=" & SQLString(tdbg.Columns(COL_RefEmployeeID).Text))
                Else
                    Dt1 = ReturnTableFilter(dtEmployee.Copy, "EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text))
                End If
                tdbg.Columns(COL_RefEmployeeID).Text = Dt1.Rows(0).Item("RefEmployeeID").ToString
                tdbg.Columns(COL_EmployeeID).Text = Dt1.Rows(0).Item("EmployeeID").ToString
                tdbg.Columns(COL_EmployeeName).Text = Dt1.Rows(0).Item("EmployeeName").ToString
            Else
                HotKeyF7(tdbg)
            End If
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            'Su dung Enter di chuyen den o duoi o hien hanh
            If D45Options.UseEnterMoveDown Then Exit Sub
            If iCol = iLastCol Then HotKeyEnterGrid(tdbg, COL_PieceworkGroupID, e)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            'Select Case iCol
            '    Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05
            '        CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
            '    Case COL_ProductID
            '        CopyColumnArr(tdbg, iCol, iCols)
            '        CalculatorProductNameFromSpecs(tdbg.Row)
            '    Case COL_StageID
            '        CopyColumns(tdbg, iCol, tdbg.Row, 2, tdbg.Columns(iCol).Value.ToString)
            '    Case COL_EmployeeID
            '        CopyColumns_AfterBefore(tdbg, iCol, tdbg.Row, 2, 1, tdbg.Columns(iCol).Value.ToString)
            '    Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
            '        CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
            '        CalculatorProductNameFromSpecs(tdbg.Row)
            'End Select
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            DeleteMultiRows(tdbg)
            CalFooterAndOrderNo()
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.C Then 'Thoại: copy
            'neu k cho cap nhat tren luoi thi cung k cho copy & paste
            If tdbg.AllowUpdate = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            bPressCopy = True
            If bColMove Then
                CtrlC_ColMove()
            Else
                CtrlC()
            End If
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.V Then 'Thoại: copy
            'neu k cho cap nhat tren luoi thi cung k cho copy & paste
            If tdbg.AllowUpdate = False Then Exit Sub

            If Not oData Is Nothing Then
                e.SuppressKeyPress = False
                iCurrentCol = iCol
                Me.Cursor = Cursors.WaitCursor
                If bColMove Then
                    CtrlV_ColMove(e)
                Else
                    CtrlV(e)
                End If

                UpdateTDBGOrderNum(tdbg, COL_OrderNum)
                tdbg.UpdateData()

                e.SuppressKeyPress = True

                Me.Cursor = Cursors.Default
                Exit Sub
            End If


        ElseIf e.Control And e.KeyCode = Keys.E Then 'Created by: Thoại
            If tdbg.AllowUpdate = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            CtrlE()
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.I Then 'Created by: Thoại
            If tdbg.AllowUpdate = False Then Exit Sub

            'If tdbg.Col = iOldCol_CtrlE Then
            Me.Cursor = Cursors.WaitCursor
            CtrlI()
            iCol = iOldCol_CtrlE - 1
            tdbg.Row = iOldFirstRow_CtrlE
            Me.Cursor = Cursors.Default
            'End If

            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.T Then 'Created by: Hoàng Long
            CopyFromClipboard()
            Exit Sub
        ElseIf e.KeyCode = Keys.F6 Then
            Select Case tdbg.Col
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                    If AllowF6() = False Then Exit Sub
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
        HotKeyDownGrid(e, tdbg, COL_RefEmployeeID, 0, 1)
    End Sub


    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)
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
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Text
                tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                CalculatorProductNameFromSpec()
            Case COL_StageID
                tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
            Case COL_EmployeeID
                tdbg.Columns(COL_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text
                If tdbg.Columns(COL_ProductID).Text = "" And tdbcProductID.Text <> "" Then
                    tdbg.Columns(COL_ProductID).Text = tdbcProductID.Text
                    tdbg.Columns(COL_ProductName).Text = tdbcProductID.Columns("ProductName").Text
                    tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                    CalculatorProductNameFromSpec()
                End If
                If tdbg.Columns(COL_StageID).Text = "" And tdbcStageID.Text <> "" Then
                    tdbg.Columns(COL_StageID).Text = tdbcStageID.Text
                    tdbg.Columns(COL_StageName).Text = tdbcStageID.Columns("StageName").Text
                End If
            Case COL_RefEmployeeID
                tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdRefEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
                If tdbg.Columns(COL_ProductID).Text = "" And tdbcProductID.Text <> "" Then
                    tdbg.Columns(COL_ProductID).Text = tdbcProductID.Text
                    tdbg.Columns(COL_ProductName).Text = tdbcProductID.Columns("ProductName").Text
                    tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                    CalculatorProductNameFromSpec()
                End If
                If tdbg.Columns(COL_StageID).Text = "" And tdbcStageID.Text <> "" Then
                    tdbg.Columns(COL_StageID).Text = tdbcStageID.Text
                    tdbg.Columns(COL_StageName).Text = tdbcStageID.Columns("StageName").Text
                End If
            Case COL_FirstName
                tdbg.Columns(COL_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Text
                tdbg.Columns(COL_FirstName).Text = tdbdFirstName.Columns("FirstName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdFirstName.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdFirstName.Columns("TeamID").Text
                If tdbg.Columns(COL_ProductID).Text = "" And tdbcProductID.Text <> "" Then
                    tdbg.Columns(COL_ProductID).Text = tdbcProductID.Text
                    tdbg.Columns(COL_ProductName).Text = tdbcProductID.Columns("ProductName").Text
                    tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                    CalculatorProductNameFromSpec()
                End If
                If tdbg.Columns(COL_StageID).Text = "" And tdbcStageID.Text <> "" Then
                    tdbg.Columns(COL_StageID).Text = tdbcStageID.Text
                    tdbg.Columns(COL_StageName).Text = tdbcStageID.Columns("StageName").Text
                End If
        End Select

        If tdbg.Columns(COL_OrderNum).Text = "" Then tdbg.Columns(COL_OrderNum).Text = (tdbg.Bookmark + 1).ToString
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Dim iIndex As Integer = CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
        '*******************
        Select Case iIndex
            Case COL_StageID
                If tdbg.Columns(COL_IsLocked).Text = "1" Then
                    e.Cancel = True
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_IsLocked).Text = "1" Then
                    e.Cancel = True
                End If
            Case COL_Quantity01, COL_ProductID
                If tdbg.Columns(COL_IsLocked).Text = "1" Then e.Cancel = True
        End Select
        '*******************
        If tdbg.Columns(COL_Permission).Text <> "" AndAlso L3Byte(tdbg.Columns(COL_Permission).Text) < 2 Then e.Cancel = True
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Dim iCol As Integer = CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
        Select Case iCol
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
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
                    tdbg.Columns(COL_FirstName).Text = ""
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                End If
            Case COL_FirstName
                If tdbg.Columns(COL_FirstName).Text.ToUpper <> tdbdFirstName.Columns("FirstName").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
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
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                If L3IsNumeric(tdbg.Columns(iCol).Text, EnumDataType.Money) = False Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Dim iCol As Integer = L3Int(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        '*****************************
        Select Case iCol
            Case COL_StageID
                LoadtdbdStageID(tdbg(tdbg.Row, COL_ProductID).ToString)

                If L3Bool(tdbg(tdbg.Row, COL_IsLocked)) Then
                    tdbg.Columns(COL_StageID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_StageID).DropDown = tdbdStageID
                End If
            Case COL_RefEmployeeID
                If L3Bool(tdbg(tdbg.Row, COL_IsLocked)) Then
                    tdbg.Columns(COL_RefEmployeeID).DropDown = Nothing
                Else
                    tdbg.Columns(COL_RefEmployeeID).DropDown = tdbdRefEmployeeID
                End If
        End Select
        '*****************************
        If tdbg.Columns(iCol).DropDown IsNot Nothing Then
            If tdbg(tdbg.Row, COL_Permission).ToString <> "" AndAlso L3Byte(tdbg(tdbg.Row, COL_Permission).ToString) < 2 Then
                tdbg.Splits(0).DisplayColumns(iCol).Button = False
            Else
                tdbg.Splits(0).DisplayColumns(iCol).Button = True
            End If
        End If
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        'Khong hien thi Tooltip khi re len Caption cot
        If e.Row >= 0 Then
            Select Case e.ColIndex
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                    e.CellTip = ConvertVniToUnicode(rL3("Nhan_F6_thuc_hien_phan_bo_VN"))
                Case Else
                    e.CellTip = ""
            End Select
        Else
            e.CellTip = ""
        End If
    End Sub

    Private Sub tdbg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.Click
        'tdbg.UpdateData()
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

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        CalFooterAndOrderNo()
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
            Case COL_ProductID
                CopyColumnArr(tdbg, iCol, iCols)
                CalculatorProductNameFromSpecs(tdbg.Row)
            Case COL_StageID
                CopyColumns(tdbg, iCol, tdbg.Row, 2, tdbg.Columns(iCol).Value.ToString)
            Case COL_EmployeeID
                CopyColumns_AfterBefore(tdbg, iCol, tdbg.Row, 2, 5, tdbg.Columns(iCol).Value.ToString)
            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
                CalculatorProductNameFromSpecs(tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

#End Region

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim i As Integer = 0
        Dim j As Integer = 0
        For i = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_EmployeeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_NV"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_EmployeeID 'Đã sửa theo Incident 15080
                tdbg.Bookmark = i

                Return False
            End If
            If tdbg(i, COL_ProductID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("San_pham"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ProductID
                tdbg.Bookmark = i

                Return False
            End If

            If i = tdbg.RowCount - 1 Then Exit For
            If chkTestDuplicate.Checked Then
                For j = i + 1 To tdbg.RowCount - 1
                    If tdbg(i, COL_EmployeeID).ToString = tdbg(j, COL_EmployeeID).ToString And tdbg(i, COL_ProductID).ToString = tdbg(j, COL_ProductID).ToString And tdbg(i, COL_StageID).ToString = tdbg(j, COL_StageID).ToString Then
                        D99C0008.MsgDuplicatePKey()
                        tdbg.Focus()
                        tdbg.Row = j
                        Return False
                    End If
                Next
            End If
        Next
        Return True
    End Function

#Region "Active Find Client - List All "
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
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D45V1234 "
        sSQL &= "Where FormID = " & SQLString(Me.Name) & " And Language = " & SQLString(gsLanguage)
        ShowFindDialog(Finder, sSQL)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    Try
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString
    '        If sFind = "" Then Exit Sub
    '        Dim dt As DataTable = ReturnDataTable(SQLStoreD45P2002)
    '        '  dt = ReturnTableFilter(dt, sFind.Replace("N'", "'"))

    '        LoadGridFind(tdbg, dt, sFind)
    '        'If Not dt.DefaultView Is Nothing Then
    '        '    LoadDataSource(tdbg, dt)
    '        'End If

    '    Catch ex As Exception
    '        D99C0008.MsgL3(ex.Message)
    '    End Try

    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD45P2002)
        LoadDataSource(tdbg, dt, gbUnicode)
    End Sub
#End Region

    Private Sub btnHotKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID = "D45F2002"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        '************************
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim frm As New D45F2006
        With frm
            .FormState = _FormState
            .ProductVoucherID = _productVoucherID
            .PayrollVoucherID = _payrollVoucherID
            .TransTypeID = _transTypeID
            .EmployeeID = "%"
            .SalaryVoucherID = ""
            .Mode = 0
            .ShowDialog()
            .Dispose()
        End With
        If frm.bSaved Then LoadTDBGrid()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlE
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Export dữ liệu từ lưới ra Excel
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlE()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols

        If c1Cols.Count < 1 Then Exit Sub

        'lưu lại vị trí dòng, cột trước khi export ra excel
        iOldFirstRow_CtrlE = c1Rows(0)
        iOldLastRow_CtrlE = (c1Rows(c1Rows.Count - 1))
        iOldCol_CtrlE = ReturnCol(c1Cols(0).DataField)

        Dim i As Integer = 0, j As Integer = 0
        Dim k As Integer = 0 'dung de gan gtri ra cac cell o Excel

        Dim font As New System.Drawing.Font("VNI-Times", 10.0!, FontStyle.Regular)

        Dim book As C1XLBook = New C1XLBook()
        Dim sheet As XLSheet = book.Sheets(0)
        Dim cell As XLCell
        Dim style1 As C1.C1Excel.XLStyle
        Dim style As C1.C1Excel.XLStyle

        sheet.Name = "Sheet1"

        Try
            Dim icol As Integer = COL_Quantity01

            For j = 0 To c1Cols.Count - 1 'Định dạng caption
                icol = ReturnCol(c1Cols(j).DataField)
                If tdbg.Splits(0).DisplayColumns(c1Cols(j).DataField).Visible = False Then Continue For 'neu la cot an thi xet qua cot ke

                style1 = New XLStyle(book)
                cell = sheet(0, k) 'sheet(0, j)

                style1.AlignHorz = XLAlignHorzEnum.Center
                If icol = COL_Quantity01 Or icol = COL_Quantity02 Or icol = COL_Quantity03 Or icol = COL_Quantity04 Or icol = COL_Quantity05 Or icol = COL_Quantity06 Or icol = COL_Quantity07 Or icol = COL_Quantity08 Or icol = COL_Quantity09 Or icol = COL_Quantity10 Or icol = COL_Quantity11 Or icol = COL_Quantity12 Or icol = COL_Quantity13 Or icol = COL_Quantity14 Or icol = COL_Quantity15 Or icol = COL_Quantity16 Or icol = COL_Quantity17 Or icol = COL_Quantity18 Or icol = COL_Quantity19 Or icol = COL_Quantity20 Then
                    style1.Font = New System.Drawing.Font("VNI-Times", 11.0!, FontStyle.Bold)
                Else
                    style1.Font = New System.Drawing.Font("Arial", 9.0!, FontStyle.Bold)
                End If

                cell.Style = style1

                cell.Value = tdbg.Columns(c1Cols(j).DataField).Caption

                k += 1
            Next

            For i = 0 To c1Rows.Count - 1 'Định dạng những dòng dữ liệu tiếp theo
                k = 0
                For j = 0 To c1Cols.Count - 1

                    icol = ReturnCol(c1Cols(j).DataField)
                    If tdbg.Splits(0).DisplayColumns(c1Cols(j).DataField).Visible = False Then Continue For 'neu la cot an thi xet qua cot ke

                    cell = sheet(i + 1, k) 'sheet(i + 1, j)

                    If icol = COL_Quantity01 Or icol = COL_Quantity02 Or icol = COL_Quantity03 Or icol = COL_Quantity04 Or icol = COL_Quantity05 Or icol = COL_Quantity06 Or icol = COL_Quantity07 Or icol = COL_Quantity08 Or icol = COL_Quantity09 Or icol = COL_Quantity10 Or icol = COL_Quantity11 Or icol = COL_Quantity12 Or icol = COL_Quantity13 Or icol = COL_Quantity14 Or icol = COL_Quantity15 Or icol = COL_Quantity16 Or icol = COL_Quantity17 Or icol = COL_Quantity18 Or icol = COL_Quantity19 Or icol = COL_Quantity20 Then
                        style = New XLStyle(book)
                        style.Font = font
                        style.AlignHorz = XLAlignHorzEnum.Right
                        style.Format = DxxFormat.DefaultNumber2
                        cell.Style = style
                        cell.Value = tdbg(c1Rows.Item(i), c1Cols.Item(j).DataField)
                    Else
                        style = New XLStyle(book)
                        style.Font = font
                        style.AlignHorz = XLAlignHorzEnum.Left
                        style.Format = ""
                        cell.Style = style
                        cell.Value = tdbg(c1Rows.Item(i), c1Cols.Item(j).DataField).ToString

                    End If
                    k += 1
                Next
            Next

            'Fix the columns's size
            AutoSizeColumns(sheet)

            'Save the file
            Dim fileName As String = gsApplicationPath + "\D45F2002.xls"

            If File.Exists(fileName) Then 'Đóng File excel đang mở
                Dim procName As String = "Excel"
                Dim proc As Process
                Dim processes() As Process
                Dim iprocID As Integer = 0

                processes = Process.GetProcessesByName(procName)

                For Each proc In processes
                    If proc.MainWindowTitle = "Microsoft Excel - D45F2002.xls" Then
                        iprocID = proc.Id

                        If iprocID <> 0 Then
                            Dim tempProc As Process = Process.GetProcessById(iprocID) '3932
                            tempProc.CloseMainWindow()
                            tempProc.Close()

                            Exit For
                        End If

                    End If
                Next
            End If

            Application.DoEvents()

            Thread.Sleep(100)

            book.Save(fileName)

            System.Diagnostics.Process.Start(fileName)

        Catch ex As Exception
            D99C0008.MsgL3("Thuc hien tac vu khong thanh cong")

        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlI
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Import dữ liệu từ excel vào lưới
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlI()
        Dim fileName As String = gsApplicationPath + "\D45F2002.xls"

        Try
            Dim cn As System.Data.OleDb.OleDbConnection
            Dim cmd As System.Data.OleDb.OleDbDataAdapter
            Dim ds As New System.Data.DataSet()
            Dim dtExcel As DataTable
            Dim i, j As Integer

            cn = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" & _
                "data source=" & fileName & ";Extended Properties=Excel 8.0;")

            ' Select the data from Sheet1 of the workbook.
            cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", cn)

            cn.Open()
            cmd.Fill(ds)
            cn.Close()

            dtExcel = ds.Tables(0)

            For i = 0 To dtExcel.Rows.Count - 1
                For j = 0 To dtExcel.Columns.Count - 1
                    'tdbg(i + iOldFirstRow_CtrlE, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
                    tdbg(i + iOldFirstRow_CtrlE, dtExcel.Columns(j).ColumnName) = dtExcel.Rows(i).Item(j)
                Next
            Next

            'If tdbg.Row = iOldFirstRow_CtrlE Then 'chèn vào đúng vị trí cũ
            '    For i = 0 To dtExcel.Rows.Count - 1
            '        For j = 0 To dtExcel.Columns.Count - 1
            '            tdbg(i + iOldFirstRow_CtrlE, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
            '        Next
            '    Next
            'Else 'thêm mới
            '    Dim iRow As Integer = iOldFirstRow_CtrlE

            '    iRow = tdbg.Row

            '    Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            '    If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
            '        If dtExcel.Rows.Count - iAddRows > 0 Then
            '            For i = 0 To dtExcel.Rows.Count - 1 - iAddRows
            '                tdbg.MoveLast()
            '                tdbg.Row = tdbg.Row + 1
            '                tdbg.Columns(COL_TransID).Text = ""
            '            Next
            '        End If
            '    Else 'con trỏ đứng tại dòng mới hoàn toàn
            '        For i = 0 To dtExcel.Rows.Count - 1
            '            tdbg.MoveLast()
            '            tdbg.Row = tdbg.Row + 1
            '            tdbg.Columns(COL_TransID).Text = ""
            '        Next
            '    End If


            '    For i = 0 To dtExcel.Rows.Count - 1
            '        For j = 0 To dtExcel.Columns.Count - 1
            '            tdbg(i + iRow, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
            '        Next
            '    Next

            '    iOldFirstRow_CtrlE = iRow
            'End If

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.ToString)
        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: AutoSizeColumns
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Canh độ rộng của cột trên excel
    '#---------------------------------------------------------------------------------------------------
    Private Sub AutoSizeColumns(ByVal sheet As XLSheet)

        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)

            Dim r As Integer, c As Integer
            For c = 0 To sheet.Columns.Count - 1
                Dim colWidth As Integer = -1
                For r = 0 To sheet.Rows.Count - 1

                    Dim value As Object = sheet(r, c).Value

                    If Not (value Is Nothing) Then
                        ' get value (unformatted at this point)
                        Dim text As String = value.ToString()
                        ' get font (default or style)
                        Dim font As Font = C1XLBook1.DefaultFont
                        Dim s As XLStyle = sheet(r, c).Style
                        If Not (s Is Nothing) Then
                            If Not (s.Font Is Nothing) Then
                                font = s.Font
                            End If
                        End If

                        ' measure string (add a little tolerance)
                        Dim sz As Size = System.Drawing.Size.Ceiling(g.MeasureString(text + "XX", font))

                        ' keep widest so far
                        If sz.Width > colWidth Then
                            colWidth = sz.Width
                        End If
                    End If

                    ' done measuring, set column width
                    If colWidth > -1 Then
                        sheet.Columns(c).Width = C1XLBook.PixelsToTwips(colWidth)
                    End If
                Next
            Next
        End Using
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlC
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Copy từ dòng được chọn (dán vào vị trí con trỏ đang đứng)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlC()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols
        Dim i As Integer = 0, j As Integer = 0

        If c1Cols.Count < 1 Then
            sFirstCol = ""
            Exit Sub
        End If

        If c1Cols(0).DataField = "OrderNo" Or c1Cols(0).DataField = "ProductName" Or c1Cols(0).DataField = "StageName" Or c1Cols(0).DataField = "EmployeeName" Or c1Cols(0).DataField = "DepartmentID" Or c1Cols(0).DataField = "TeamID" Then
            Exit Sub
        End If

        'cot dau tien dc Copy
        sFirstCol = c1Cols(0).DataField

        Dim iAddCols As Integer = 0

        'Quet nhung cot dc copy
        For j = 0 To c1Cols.Count - 1
            If j = c1Cols.Count - 1 Then
                If c1Cols(j).DataField = "ProductID" Then
                    iAddCols += 1
                End If

                If c1Cols(j).DataField = "StageID" Then
                    iAddCols += 1
                End If

                If c1Cols(j).DataField = "RefEmployeeID" Then
                    iAddCols += 4 'copy luon nhung cot lien quan
                End If

                If c1Cols(j).DataField = "EmployeeID" Then
                    iAddCols += 3 'copy luon nhung cot lien quan
                End If

                'Them vao ngay 29/04/09 vi khi chi copy 3 cot Ma NV phu, Ma Nv va Ten NV se bi sai
                If c1Cols(0).DataField = "RefEmployeeID" Then
                    If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" Then
                        iAddCols += 4 'copy luon nhung cot lien quan
                    End If
                ElseIf c1Cols(0).DataField = "EmployeeID" Then
                    If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" Then
                        iAddCols += 3 'copy luon nhung cot lien quan
                    End If
                End If
            End If
        Next

        ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)

        iPrevRow = tdbg.RowCount - 1
        iCopyRows = c1Rows.Count - 1
        iCopyCol = c1Cols.Count - 1

        For i = 0 To c1Rows.Count - 1
            For j = 0 To c1Cols.Count - 1

                If c1Cols(j).DataField <> "ProductName" And c1Cols(j).DataField <> "StageName" And c1Cols(j).DataField <> "EmployeeName" And c1Cols(j).DataField <> "DepartmentID" And c1Cols(j).DataField <> "TeamID" Then
                    oData(i, j) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))

                    'If j = c1Cols.Count - 1 Then
                    If c1Cols(j).DataField = "ProductID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "ProductName"))
                    End If

                    If c1Cols(j).DataField = "StageID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "StageName"))
                    End If

                    If c1Cols(j).DataField = "RefEmployeeID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                        oData(i, j + 2) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                        oData(i, j + 3) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                        oData(i, j + 4) = CObj(tdbg(c1Rows(i), "TeamID"))
                    End If

                    If c1Cols(j).DataField = "EmployeeID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                        oData(i, j + 2) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                        oData(i, j + 3) = CObj(tdbg(c1Rows(i), "TeamID"))
                    End If
                    'End If

                End If
            Next
        Next

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlC
    '# Created User:
    '# Created Date:
    '# Modified User: 
    '# Modified Date: 
    '# Description: Copy từ dòng được chọn (dán vào vị trí con trỏ đang đứng)(da co di chuyen cot)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlC_ColMove()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols

        Dim i As Integer = 0, j As Integer = 0

        Dim bRefEmployeeID As Boolean = False
        Dim bCopyQuan As Boolean = False

        bCopyRef = False

        If c1Cols.Count < 1 Then
            sFirstCol = ""
            Exit Sub
        End If

        If c1Cols(0).DataField = "OrderNo" Or c1Cols(0).DataField = "ProductName" Or c1Cols(0).DataField = "StageName" Or c1Cols(0).DataField = "EmployeeName" Or c1Cols(0).DataField = "DepartmentID" Or c1Cols(0).DataField = "TeamID" Then
            Exit Sub
        End If

        'cot dau tien dc Copy
        sFirstCol = c1Cols(0).DataField

        Dim iAddCols As Integer = 0

        iColCheck = 0
        For j = 0 To c1Cols.Count - 1
            If c1Cols(j).DataField = "RefEmployeeID" Or c1Cols(j).DataField = "EmployeeID" Then
                If c1Cols(j).DataField = "RefEmployeeID" Then
                    iColCheck = iColCheck + 1
                    bCopyRef = True
                Else
                    iColCheck = iColCheck + 1
                    If iColCheck = 2 Then
                        bCopyRef = True
                    End If
                End If
            ElseIf c1Cols(j).DataField = "Quantity01" Or c1Cols(j).DataField = "Quantity02" Or c1Cols(j).DataField = "Quantity03" Or c1Cols(j).DataField = "Quantity04" Or c1Cols(j).DataField = "Quantity05" Then
                bCopyQuan = True
            End If
        Next

        Dim bChooseQuan As Boolean = True

        'Quet nhung cot dc copy
        For j = 0 To c1Cols.Count - 1
            If c1Cols(j).DataField = "ProductID" Then
                iAddCols += 1
                bChooseQuan = False
            End If

            If c1Cols(j).DataField = "StageID" Then
                iAddCols += 1
                bChooseQuan = False
            End If

            If c1Cols(j).DataField = "RefEmployeeID" Then
                If bRefEmployeeID = False Then
                    iAddCols += 4 'copy luon nhung cot lien quan
                    bRefEmployeeID = True
                    bChooseQuan = False
                End If
            End If

            If c1Cols(j).DataField = "EmployeeID" Then
                If bRefEmployeeID = False Then
                    If iColCheck = 2 Then
                        iAddCols += 4 'copy luon nhung cot lien quan
                    Else
                        iAddCols += 3 'copy luon nhung cot lien quan
                    End If
                    bRefEmployeeID = True
                    bChooseQuan = False
                End If
            End If

            If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" OrElse c1Cols(j).DataField = "ProductName" OrElse c1Cols(j).DataField = "StageName" Then
                iAddCols = iAddCols - 1
            End If


        Next

        If bCopyQuan Then 'chi chon nhung cot so luong or k chon 2 cot NV
            If bCopyRef And iColCheck = 2 Then
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
            Else
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            End If
        Else
            If bCopyRef And iColCheck = 2 Then
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            Else
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            End If
        End If

        Dim iColTemp As Integer

        iPrevRow = tdbg.RowCount - 1
        iCopyRows = c1Rows.Count - 1
        iCopyCol = c1Cols.Count - 1

        bRefEmployeeID = False

        For i = 0 To c1Rows.Count - 1
            iColTemp = 0
            bRefEmployeeID = False
            For j = 0 To c1Cols.Count - 1
                If c1Cols(j).DataField <> "ProductName" And c1Cols(j).DataField <> "StageName" And c1Cols(j).DataField <> "EmployeeName" And c1Cols(j).DataField <> "DepartmentID" And c1Cols(j).DataField <> "TeamID" Then
                    If iColCheck = 0 Then 'k chon ca 2 cot NV
                        oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                        oField(0, iColTemp) = c1Cols(j).DataField
                        iColTemp = iColTemp + 1

                        If c1Cols(j).DataField = "ProductID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "ProductName"))
                            oField(0, iColTemp) = "ProductName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "StageID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "StageName"))
                            oField(0, iColTemp) = "StageName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "RefEmployeeID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                            oField(0, iColTemp) = "EmployeeID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                            oField(0, iColTemp) = "EmployeeName"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                            oField(0, iColTemp) = "DepartmentID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                            oField(0, iColTemp) = "TeamID"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "EmployeeID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                            oField(0, iColTemp) = "EmployeeName"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                            oField(0, iColTemp) = "DepartmentID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                            oField(0, iColTemp) = "TeamID"
                            iColTemp = iColTemp + 1
                        End If
                    Else 'chon 1 trong 2 cot EmployeeID va RefEmployeeID
                        If c1Cols(j).DataField = "EmployeeID" Or c1Cols(j).DataField = "RefEmployeeID" Then
                            If bRefEmployeeID = False Then
                                If iColCheck = 2 Then
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "RefEmployeeID"))
                                    oField(0, iColTemp) = "RefEmployeeID"
                                    iColTemp = iColTemp + 1
                                Else
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                                    oField(0, iColTemp) = c1Cols(j).DataField
                                    iColTemp = iColTemp + 1
                                End If
                            End If
                        Else
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                            oField(0, iColTemp) = c1Cols(j).DataField
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "ProductID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "ProductName"))
                            oField(0, iColTemp) = "ProductName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "StageID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "StageName"))
                            oField(0, iColTemp) = "StageName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "RefEmployeeID" Then
                            If bRefEmployeeID = False Then
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                                oField(0, iColTemp) = "EmployeeID"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                oField(0, iColTemp) = "EmployeeName"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                oField(0, iColTemp) = "DepartmentID"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                oField(0, iColTemp) = "TeamID"
                                bRefEmployeeID = True
                                iColTemp = iColTemp + 1
                            End If
                        End If

                        If c1Cols(j).DataField = "EmployeeID" Then
                            If bRefEmployeeID = False Then
                                If iColCheck = 2 Then
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                                    oField(0, iColTemp) = "EmployeeID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                    oField(0, iColTemp) = "EmployeeName"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                    oField(0, iColTemp) = "DepartmentID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                    oField(0, iColTemp) = "TeamID"
                                    bRefEmployeeID = True
                                    iColTemp = iColTemp + 1
                                Else
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                    oField(0, iColTemp) = "EmployeeName"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                    oField(0, iColTemp) = "DepartmentID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                    oField(0, iColTemp) = "TeamID"
                                    bRefEmployeeID = True
                                    iColTemp = iColTemp + 1
                                End If
                            End If
                        End If

                    End If

                End If
            Next
        Next

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlV
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Past vào vị trí con trỏ đang đứng (từ những dòng copy trên)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlV(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer = 0, j As Integer = 0

        If sFirstCol = "" Then Exit Sub
        iFirstColunm = ReturnCol(sFirstCol)

        If iCurrentCol <> iFirstColunm Then Exit Sub

        If iPrevRow <= tdbg.Row - 1 Then
            tdbg.MoveLast()
            'quet so dong dc copy
            For i = 0 To iCopyRows
                If tdbg.Row = tdbg.RowCount Then
                    tdbg.Row = tdbg.Row
                Else
                    tdbg.Row = tdbg.Row + 1
                End If

                tdbg.Columns(COL_TransID).Text = ""
            Next

            tdbg.UpdateData()

            For i = 0 To iCopyRows
                If i + iPrevRow + 1 <= tdbg.RowCount - 1 Then
                    'quet so cot dc copy
                    For j = 0 To iCopyCol
                        If i = iCopyRows And j = 0 Then sLastProductID = oData(i, j).ToString

                        If (j + iFirstColunm) <> COL_ProductName Or (j + iFirstColunm) <> COL_StageName Or (j + iFirstColunm) <> COL_EmployeeName Or (j + iFirstColunm) <> COL_DepartmentID Or (j + iFirstColunm) <> COL_TeamID Then
                            tdbg(i + iPrevRow + 1, j + iFirstColunm) = oData(i, j)

                            'If j = iCopyCol Then
                            If (j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_StageID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_RefEmployeeID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 4) = oData(i, j + 4)
                            End If

                            If (j + iFirstColunm) = COL_EmployeeID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            tdbg.UpdateData()
            bPressCopy = False
            iPrevRow = tdbg.RowCount - 1
        Else
            Dim liPrevRow As Integer = tdbg.Row - 1
            Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
                If iCopyRows + 1 - iAddRows > 0 Then
                    For i = 0 To iCopyRows - iAddRows
                        tdbg.MoveLast()
                        tdbg.Row = tdbg.Row + 1
                        tdbg.Columns(COL_TransID).Text = ""
                    Next
                End If
            End If

            For i = 0 To iCopyRows
                If i + liPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol

                        If (j + iFirstColunm) <> COL_ProductName Or (j + iFirstColunm) <> COL_StageName Or (j + iFirstColunm) <> COL_EmployeeName Or (j + iFirstColunm) <> COL_DepartmentID Or (j + iFirstColunm) <> COL_TeamID Then
                            tdbg(i + liPrevRow + 1, j + iFirstColunm) = oData(i, j)

                            'If j = iCopyCol Then
                            If (j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_StageID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_RefEmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 4) = oData(i, j + 4)
                            End If

                            If (j + iFirstColunm) = COL_EmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            iPrevRow = tdbg.RowCount - 1
        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlV
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Past vào vị trí con trỏ đang đứng (từ những dòng copy trên)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlV_ColMove1(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer = 0, j As Integer = 0
        Dim bRefEmployeeID As Boolean = False
        Dim iIndex As Integer = 0, k As Integer = 0
        Dim iColTemp As Integer = 0

        If sFirstCol = "" Then Exit Sub
        iFirstColunm = ReturnCol(sFirstCol)

        If iColCheck = 2 And sFirstCol = "EmployeeID" Then
        Else
            If iCurrentCol <> iFirstColunm Then Exit Sub
        End If

        If iPrevRow <= tdbg.Row - 1 Then
            tdbg.MoveLast()
            For i = 0 To iCopyRows
                If tdbg.Row = tdbg.RowCount Then
                    tdbg.Row = tdbg.Row
                Else
                    tdbg.Row = tdbg.Row + 1
                End If

                tdbg.Columns(COL_TransID).Text = ""
            Next

            tdbg.UpdateData()

            For i = 0 To iCopyRows
                iColTemp = 0
                If i + iPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol
                        If i = iCopyRows And j = 0 Then sLastProductID = oData(i, iColTemp).ToString

                        If arrayIndex(j + iFirstColunm) <> COL_ProductName Or arrayIndex(j + iFirstColunm) <> COL_StageName Or arrayIndex(j + iFirstColunm) <> COL_EmployeeName Or arrayIndex(j + iFirstColunm) <> COL_DepartmentID Or arrayIndex(j + iFirstColunm) <> COL_TeamID Then
                            For k = 0 To arrayIndex.Length - 1
                                If arrayIndex(k) = arrayIndex(j + iFirstColunm) Then
                                    iIndex = k
                                    Exit For
                                End If
                            Next

                            If iColCheck <> 2 And bCopyRef = False Then
                                tdbg(i + iPrevRow + 1, tdbg.Columns(arrayIndex(iIndex)).DataField) = oData(i, iColTemp)
                            Else
                                If arrayIndex(j + iFirstColunm) = COL_RefEmployeeID Or arrayIndex(j + iFirstColunm) = COL_EmployeeID Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "RefEmployeeID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                    End If
                                Else
                                    tdbg(i + iPrevRow + 1, tdbg.Columns(arrayIndex(iIndex)).DataField) = oData(i, iColTemp)
                                    iColTemp = iColTemp + 1
                                End If

                            End If


                            'If j = iCopyCol Then
                            If arrayIndex(j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + iPrevRow + 1, "ProductName") = oData(i, iColTemp)
                                iColTemp = iColTemp + 1
                            End If

                            If arrayIndex(j + iFirstColunm) = COL_StageID Then
                                tdbg(i + iPrevRow + 1, "StageName") = oData(i, iColTemp)
                                iColTemp = iColTemp + 1
                            End If

                            If arrayIndex(j + iFirstColunm) = COL_RefEmployeeID Then
                                If bRefEmployeeID = False Then
                                    tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, iColTemp)
                                    iColTemp = iColTemp + 1
                                    tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, iColTemp)
                                    iColTemp = iColTemp + 1
                                    tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, iColTemp)
                                    iColTemp = iColTemp + 1
                                    tdbg(i + iPrevRow + 1, "TeamID") = oData(i, iColTemp)
                                    iColTemp = iColTemp + 1
                                    bRefEmployeeID = True
                                End If

                            End If

                            If arrayIndex(j + iFirstColunm) = COL_EmployeeID Then
                                If iColCheck = 2 Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        bRefEmployeeID = True
                                    End If
                                Else
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, iColTemp)
                                        iColTemp = iColTemp + 1
                                        bRefEmployeeID = True
                                    End If

                                End If
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            tdbg.UpdateData()
            bPressCopy = False
            iPrevRow = tdbg.RowCount - 1
        Else
            Dim liPrevRow As Integer = tdbg.Row - 1
            Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
                If iCopyRows + 1 - iAddRows > 0 Then
                    For i = 0 To iCopyRows - iAddRows
                        tdbg.MoveLast()
                        tdbg.Row = tdbg.Row + 1
                        tdbg.Columns(COL_TransID).Text = ""
                    Next
                End If
            End If

            For i = 0 To iCopyRows
                If i + liPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol

                        If (j + iFirstColunm) <> COL_ProductName Or (j + iFirstColunm) <> COL_StageName Or (j + iFirstColunm) <> COL_EmployeeName Or (j + iFirstColunm) <> COL_DepartmentID Or (j + iFirstColunm) <> COL_TeamID Then
                            tdbg(i + liPrevRow + 1, j + iFirstColunm) = oData(i, arrayIndex(j))

                            'If j = iCopyCol Then
                            If (j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, arrayIndex(j + 1))
                            End If

                            If (j + iFirstColunm) = COL_StageID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, arrayIndex(j + 1))
                            End If

                            If (j + iFirstColunm) = COL_RefEmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, arrayIndex(j + 1))
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, arrayIndex(j + 2))
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, arrayIndex(j + 3))
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 4) = oData(i, arrayIndex(j + 4))
                            End If

                            If (j + iFirstColunm) = COL_EmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, arrayIndex(j + 1))
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, arrayIndex(j + 2))
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, arrayIndex(j + 3))
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            iPrevRow = tdbg.RowCount - 1
        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlV
    '# Created User: 
    '# Created Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: Past vào vị trí con trỏ đang đứng (từ những dòng copy trên)(da co di chuyen cot)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlV_ColMove(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer = 0, j As Integer = 0
        Dim bRefEmployeeID As Boolean = False
        Dim iIndex As Integer = 0, k As Integer = 0
        Dim iRowCopy As Integer = 0

        If sFirstCol = "" Then Exit Sub
        iFirstColunm = ReturnCol(sFirstCol)

        If iColCheck = 2 And sFirstCol = "EmployeeID" Then
        Else
            If iCurrentCol <> iFirstColunm Then Exit Sub
        End If

        If iPrevRow <= tdbg.Row - 1 Then
            tdbg.MoveLast()
            For i = 0 To iCopyRows
                If tdbg.Row = tdbg.RowCount Then
                    tdbg.Row = tdbg.Row
                Else
                    tdbg.Row = tdbg.Row + 1
                End If

                tdbg.Columns(COL_TransID).Text = ""
            Next

            tdbg.UpdateData()

            iRowCopy = CInt(oData.Length / (iCopyRows + 1))
            For i = 0 To iCopyRows
                bRefEmployeeID = False
                If i + iPrevRow + 1 <= tdbg.RowCount - 1 Then

                    For j = 0 To iRowCopy - 1 'oData.Length - 1
                        If i = iCopyRows And j = 0 Then sLastProductID = oData(i, j).ToString

                        If oField(0, j).ToString <> "ProductName" Or oField(0, j).ToString <> "StageName" Or oField(0, j).ToString <> "EmployeeName" Or oField(0, j).ToString <> "DepartmentID" Or oField(0, j).ToString <> "TeamID" Then
                            If (iColCheck <> 2 And bCopyRef = False) Or iColCheck = 0 Then
                                tdbg(i + iPrevRow + 1, tdbg.Columns(oField(0, j).ToString).DataField) = oData(i, j)
                            Else
                                If oField(0, j).ToString = "RefEmployeeID" Or oField(0, j).ToString = "EmployeeID" Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "RefEmployeeID") = oData(i, j)
                                    End If
                                Else
                                    tdbg(i + iPrevRow + 1, oField(0, j).ToString) = oData(i, j)
                                End If

                            End If

                            If oField(0, j).ToString = "ProductID" Then
                                tdbg(i + iPrevRow + 1, "ProductName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "StageID" Then
                                tdbg(i + iPrevRow + 1, "StageName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "RefEmployeeID" Then
                                If bRefEmployeeID = False Then
                                    tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                    tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                    tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                    tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 4)
                                    bRefEmployeeID = True
                                End If

                            End If

                            If oField(0, j).ToString = "EmployeeID" Then
                                If iColCheck = 2 Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 4)
                                        bRefEmployeeID = True
                                    End If
                                Else
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 1)
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 2)
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 3)
                                        bRefEmployeeID = True
                                    End If

                                End If
                            End If
                        End If
                    Next
                End If
            Next

            tdbg.UpdateData()
            bPressCopy = False
            iPrevRow = tdbg.RowCount - 1
        Else
            Dim liPrevRow As Integer = tdbg.Row - 1
            Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
                If iCopyRows + 1 - iAddRows > 0 Then
                    For i = 0 To iCopyRows - iAddRows
                        tdbg.MoveLast()
                        tdbg.Row = tdbg.Row + 1
                        tdbg.Columns(COL_TransID).Text = ""
                    Next
                End If
            End If

            For i = 0 To iCopyRows
                bRefEmployeeID = False
                If i + liPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol 'oData.Length - 1
                        If oField(0, j).ToString <> "ProductName" And oField(0, j).ToString <> "StageName" And oField(0, j).ToString <> "EmployeeName" And oField(0, j).ToString <> "DepartmentID" And oField(0, j).ToString <> "TeamID" Then
                            If iColCheck <> 2 And bCopyRef = False Then
                                tdbg(i + liPrevRow + 1, tdbg.Columns(oField(0, j).ToString).DataField) = oData(i, j)
                            Else
                                If oField(0, j).ToString = "RefEmployeeID" Or oField(0, j).ToString = "EmployeeID" Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "RefEmployeeID") = oData(i, j)
                                    End If
                                Else
                                    tdbg(i + liPrevRow + 1, oField(0, j).ToString) = oData(i, j)
                                End If

                            End If

                            If oField(0, j).ToString = "ProductID" Then
                                tdbg(i + liPrevRow + 1, "ProductName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "StageID" Then
                                tdbg(i + liPrevRow + 1, "StageName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "RefEmployeeID" Then
                                If bRefEmployeeID = False Then
                                    tdbg(i + liPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                    tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                    tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                    tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 4)
                                    bRefEmployeeID = True
                                End If

                            End If

                            If oField(0, j).ToString = "EmployeeID" Then
                                If iColCheck = 2 Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                        tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                        tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                        tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 4)
                                        bRefEmployeeID = True
                                    End If
                                Else
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 1)
                                        tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 2)
                                        tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 3)
                                        bRefEmployeeID = True
                                    End If

                                End If
                            End If
                        End If
                    Next
                End If
            Next

            iPrevRow = tdbg.RowCount - 1
        End If

    End Sub

    'Thoại: copy
    Private Function ReturnCol(ByVal sDataField As String) As Integer
        For i As Integer = 0 To tdbg.Columns.Count - 1
            If iColCheck <> 2 Then
                If tdbg.Columns(i).DataField = sDataField Then
                    Return i
                End If
            Else
                If sDataField = "EmployeeID" Then
                    If tdbg.Columns(i).DataField = "RefEmployeeID" Then
                        Return i
                    End If
                Else
                    If tdbg.Columns(i).DataField = sDataField Then
                        Return i
                    End If
                End If
            End If

        Next

        Return -1
    End Function

    Private Function ExecuteSQL1(ByVal strSQL As String) As Boolean
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

                Return True
            Catch
                Clipboard.Clear()
                Clipboard.SetText(strSQL)
                'MsgErr("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard")
                MessageBox.Show("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                WriteLogFile1(strSQL)
                Return False
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        sRet = SQLInsertD45T2001s()

        If sRet.ToString = "-1" Then ' Thực thi không thành công
            trans.Rollback()
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        Else ' Thực thi thành công
            trans.Commit()
            SaveOK()
            btnClose.Enabled = True
            btnClose.Focus()
            btnSave.Enabled = True

            ''Load lai luoi de luoi rong
            'LoadTDBGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetLastKey(Optional ByVal sStringCreateKey As String = "", Optional ByVal sTable As String = "D91T0001") As Integer
        'Kiểm tra bảng D91T0000
        'Nếu tìm thấy then lấy LastKey
        'Nếu không tìm thấy thì insert 1 dòng mới vào


        Dim sSQL As String
        sSQL = "SELECT LastKey FROM D91T0000 WHERE TableName ='" & sTable & "'" _
          & " AND KeyString = '" & sStringCreateKey & "'"
        Dim sLastKey As String
        sLastKey = ReturnScalar(sSQL)

        If sLastKey <> "" Then ' có dữ liệu
            Return CInt(sLastKey) + 1
        Else ' Không có dữ liệu
            sSQL = "INSERT INTO D91T0000 (TableName, KeyString, LastKey) VALUES ('" & sTable & "', '" & sStringCreateKey & "',0)"
            ExecuteSQLNoTransaction(sSQL)
            Return 1
        End If
    End Function

    Private Sub SaveLastKey(ByVal sTable As String, ByVal sString As String, ByVal nLastKey As Long)
        Dim strSQL As String
        strSQL = "UPDATE D91T0000 Set LastKey =" & nLastKey _
        & " WHERE TableName = '" & sTable & "' AND KeyString = '" & sString & "'"

        ExecuteSQLNoTransaction(strSQL)
    End Sub

    Private Function GetOrderNo(ByVal CountIGE As Integer) As Integer
        Dim iOrderNoFrom As Integer
        Dim iOrderNoTo As Integer
        Dim bKey As Boolean = False

        Do
            'Lấy Lastkey
            iOrderNoFrom = GetLastKey(_productVoucherID, "D45T2001")
            iOrderNoTo = iOrderNoFrom + (CountIGE - 1)
            'Lưu Lastkey
            SaveLastKey("D45T2001", _productVoucherID, iOrderNoTo)
            'Kiểm tra trùng khóa
            bKey = IsExistKeyBetween("D45T2001", "OrderNo", iOrderNoFrom.ToString, iOrderNoTo.ToString)

        Loop Until bKey = False

        Return iOrderNoFrom

    End Function

    Private Function IsExistKeyBetween(ByVal TableName As String, ByVal Field As String, ByVal TextFrom As String, ByVal TextTo As String) As Boolean
        Dim sSQL As String
        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field & " Between " & SQLString(TextFrom) & " And " & SQLString(TextTo)
        sSQL &= " And ProductVoucherID=" & SQLString(_productVoucherID)
        Return ExistRecord(sSQL)
    End Function

    Private Function SQLInsertD45T2001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim iCount As Integer = 0 'Đếm số dòng Insert

        Dim i As New Integer

        Dim sTransID As String = ""
        Dim sOrderNo As String = ""
        Dim iCountIGE As Integer = 0

        iCountIGE = tdbg.RowCount

        Dim iOrderNo As Integer = 0
        iOrderNo = GetOrderNo(iCountIGE)

        'mo ket noi
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sRet.Remove(0, sRet.Length)
        '*************************
        sRet.Append(SQLDeleteD45T2001() & vbCrLf)
        '*************************
        For i = 0 To tdbg.RowCount - 1
            'Sinh IGE cho TransID
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D45T2001(")
            sSQL.Append("TransID,DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
            sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID,IsLocked, ")
            sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, ")
            sSQL.Append("Quantity06, Quantity07, Quantity08, Quantity09, Quantity10, ")
            sSQL.Append("Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, ")
            sSQL.Append("Quantity16, Quantity17, Quantity18, Quantity19, Quantity20, ")
            sSQL.Append("Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, ")
            sSQL.Append("Spec07ID, Spec08ID, Spec09ID, Spec10ID, Notes, NotesU,")
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, OrderNo, PieceworkGroupID")
            sSQL.Append(") Values(")

            '*************************
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsLocked)) & COMMA)

            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity01)) & COMMA) 'Quantity01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity02)) & COMMA) 'Quantity02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity03)) & COMMA) 'Quantity03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity04)) & COMMA) 'Quantity04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity05)) & COMMA) 'Quantity05, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity06)) & COMMA) 'Quantity01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity07)) & COMMA) 'Quantity02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity08)) & COMMA) 'Quantity03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity09)) & COMMA) 'Quantity04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity10)) & COMMA) 'Quantity05, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity11)) & COMMA) 'Quantity01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity12)) & COMMA) 'Quantity02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity13)) & COMMA) 'Quantity03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity14)) & COMMA) 'Quantity04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity15)) & COMMA) 'Quantity05, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity16)) & COMMA) 'Quantity01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity17)) & COMMA) 'Quantity02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity18)) & COMMA) 'Quantity03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity19)) & COMMA) 'Quantity04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity20)) & COMMA) 'Quantity05, decimal, NOT NULL

            If _isSpec Then
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
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Notes).ToString, gbUnicode, False) & COMMA) 'Notes, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Notes).ToString, gbUnicode, True) & COMMA) 'NotesU, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL

            sSQL.Append((iOrderNo + i) & COMMA) 'OrderNo, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PieceworkGroupID))) 'PieceworkGroupID, varchar[20], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iCount += 1

            If iCount = 100 OrElse (i = tdbg.RowCount - 1) Then
                bRunExcute = ExecuteSQL1(sRet.ToString)
                iCount = 0
                sRet.Remove(0, sRet.Length)
                If bRunExcute = False Then 'thuc thi k thanh cong
                    sRet.Append("-1")
                    Return sRet
                End If

            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2005s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/10/2009 08:35:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
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
            sSQL.Append("UserID, Hostname")
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
            sSQL.Append(SQLString(My.Computer.Name)) 'Hostname, varchar[20], NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iCount += 1

            If iCount = 100 OrElse (i = tdbg.RowCount - 1) Then
                bRunExcute = ExecuteSQL1(sRet.ToString)
                iCount = 0
                sRet.Remove(0, sRet.Length)
                If bRunExcute = False Then 'thuc thi k thanh cong
                    sRet.Append("-1")
                    Return sRet
                End If

            End If
        Next
        Return sRet
    End Function

    Private Sub CalFooterAndOrderNo()
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
            'tao cot OrderNum de sinh STT ao chi dung de xem
            tdbg(i, COL_OrderNum) = i + 1
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

        tdbg.Columns(COL_Quantity11).FooterText = Format(dQuantity01, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity12).FooterText = Format(dQuantity12, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity13).FooterText = Format(dQuantity13, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity14).FooterText = Format(dQuantity14, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity15).FooterText = Format(dQuantity15, DxxFormat.DefaultNumber2)

        tdbg.Columns(COL_Quantity16).FooterText = Format(dQuantity16, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity17).FooterText = Format(dQuantity17, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity18).FooterText = Format(dQuantity18, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity19).FooterText = Format(dQuantity19, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity20).FooterText = Format(dQuantity20, DxxFormat.DefaultNumber2)

        FooterTotalGrid(tdbg, COL_PieceworkGroupID)
    End Sub

    Private Sub CalTotalFooter(ByVal iCol As Integer)
        Dim dQuantity As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dQuantity += Number(tdbg(i, iCol))
        Next

        tdbg.Columns(iCol).FooterText = Format(dQuantity, DxxFormat.DefaultNumber2)
    End Sub

    'Copy tu file Excel vao
    Private Sub CopyFromClipboard()
        Dim sText As String = Clipboard.GetText(TextDataFormat.UnicodeText)
        If sText = "" Then Exit Sub
        'Tách Clipboard thành từng dòng
        Dim arrRow() As String
        Dim rg As Regex = New Regex(vbCrLf)
        arrRow = rg.Split(sText)
        Dim iRow As Integer = tdbg.Row
        Dim iCol As Integer = tdbg.Col
        For i As Integer = 0 To arrRow.Length - 2
            If tdbg.Row = tdbg.RowCount Then
                tdbg.Row = tdbg.Row + 1
            End If
            'Tách Clipboard thành từng cột
            Dim arrCell() As String
            rg = New Regex(vbTab)
            arrCell = rg.Split(arrRow(i))

            For j As Integer = 0 To arrCell.Length - 1
                If bColMove Then
                    'Có di chuyển cột
                    Try
                        'Kiểm tra xem có đúng là kiểu dữ liệu số hay ko 
                        If tdbg.Columns(arrayIndex(iCol + j)).DataType Is Type.GetType("System.Decimal") Then
                            tdbg.Columns(arrayIndex(iCol + j)).Text = SQLNumber(Decimal.Parse(arrCell(j).ToString()), DxxFormat.DefaultNumber2)
                        Else
                            tdbg.Columns(arrayIndex(iCol + j)).Text = arrCell(j).ToString()
                        End If
                    Catch ex As Exception
                        D99C0008.MsgL3(rL3("MSG000009"))
                        Exit Sub
                    End Try
                Else
                    'Không di chuyển cột
                    If iCol + j < tdbg.Columns.Count Then
                        ' --- Không copy lên các cột ẩn trên lưới ---
                        Do
                            If tdbg.Splits(SPLIT0).DisplayColumns(iCol + j).Visible = False Then
                                iCol += 1
                            Else
                                Exit Do
                            End If
                        Loop Until (iCol + j < tdbg.Columns.Count)

                        ' -------------------------------------------
                        If iCol + j < tdbg.Columns.Count Then
                            Try
                                'Kiểm tra xem có đúng là kiểu dữ liệu số hay ko 
                                If tdbg.Columns(iCol + j).DataType Is Type.GetType("System.Decimal") Then
                                    tdbg.Columns(iCol + j).Text = SQLNumber(Decimal.Parse(arrCell(j).ToString()), DxxFormat.DefaultNumber2)
                                Else
                                    tdbg.Columns(iCol + j).Text = arrCell(j).ToString()
                                End If
                            Catch ex As Exception
                                D99C0008.MsgL3(rL3("MSG000009"))
                                Exit Sub
                            End Try
                        Else
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                End If

            Next
            tdbg.Row = tdbg.Row + 1
        Next
        tdbg.Row = iRow
    End Sub

    Private Function AllowF6() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_EmployeeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_NV"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_EmployeeID
                tdbg.Bookmark = i

                Return False
            End If
        Next
        Return True
    End Function

    Private Sub CalF6(ByVal sQuantity As String, ByVal iMode As Integer)
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        sRet = SQLInsertD45T2005s()

        If sRet.ToString = "-1" Then ' Thực thi không thành công
            trans.Rollback()

            btnClose.Enabled = True
            btnSave.Enabled = True
        Else ' Thực thi thành công
            trans.Commit()

            btnClose.Enabled = True
            btnClose.Focus()
            btnSave.Enabled = True

            'Load lai luoi 
            Dim sSQL As String = SQLStoreD45P0020(sQuantity, iMode)
            dtGrid = ReturnDataTable(sSQL)

            'Add vao cot STT
            If Not dtGrid Is Nothing Then
                dtGrid.Columns.Add("OrderNum", Type.GetType("System.Single"))
            End If
            LoadDataSource(tdbg, dtGrid, gbUnicode)

            CalFooterAndOrderNo()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnShowOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOption.Click
        If bLoadFormChild Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadFormChild = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowOption.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P0020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/10/2009 08:46:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P0020(ByVal sQuantity As String, ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P0020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'Hostname, varchar[20], NOT NULL
        sSQL &= SQLString(sQuantity) & COMMA 'Quantity, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2002
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/05/2007 01:46:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load tdbg khi View, Edit
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2002() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2002 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_departmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_teamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(_ProductVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2000") 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2001
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/05/2007 02:30:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2001"
        sSQL &= " Where "
        sSQL &= " DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "TranMonth = " & SQLNumber(giTranMonth) & " And "
        sSQL &= "TranYear = " & SQLNumber(giTranYear) & " And "
        sSQL &= "ProductVoucherID = " & SQLString(_ProductVoucherID) & " And "
        sSQL &= "(Case when " & SQLString(_departmentID) & " <> '%' then DepartmentID "
        sSQL &= "else '%' end = " & SQLString(_departmentID) & ") and "
        sSQL &= "(Case when " & SQLString(_teamID) & " <> '%' then TeamID "
        sSQL &= "else '%' end = " & SQLString(_teamID) & ") and "
        sSQL &= "(Case when " & SQLString(_employeeID) & " <> '%' then EmployeeID "
        sSQL &= "else '%' end = " & SQLString(_employeeID) & ") "
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD45N6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/02/2012 11:52:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD45N6666() As String
        Dim sSQL As String = ""
        sSQL &= "D45N6666("
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'Date01, datetime, NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'Date02, datetime, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("D45F2000") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function


    
End Class