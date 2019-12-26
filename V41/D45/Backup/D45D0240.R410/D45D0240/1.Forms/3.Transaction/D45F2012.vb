Imports System
Public Class D45F2012
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
    End Property

    Private Shared _blockID As String
    Public WriteOnly Property BlockID As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

	Dim dtCaptionCols As DataTable

    '#Region "Const of tdbg"
    '    Private Const COL_IsCheck As Integer = 0           ' Đã kiểm tra 
    '    Private Const COL_TransID As Integer = 1           ' TransID
    '    Private Const COL_BlockID As Integer = 2           ' Mã khối
    '    Private Const COL_DepartmentID As Integer = 3      ' Mã phòng ban
    '    Private Const COL_TeamID As Integer = 4            ' Mã tổ nhóm
    '    Private Const COL_EmpGroupID As Integer = 5        ' Nhóm nhân viên
    '    Private Const COL_EmployeeID As Integer = 6        ' Mã nhân viên
    '    Private Const COL_FullName As Integer = 7          ' Họ và tên
    '    Private Const COL_ProductID As Integer = 8         ' Sản phẩm
    '    Private Const COL_ProductName As Integer = 9       ' Tên sản phẩm 
    '    Private Const COL_StageID As Integer = 10          ' Công đoạn
    '    Private Const COL_StageName As Integer = 11        ' Tên công đoạn
    '    Private Const COL_ProductVoucherNo As Integer = 12 ' Số phiếu chấm công
    '    Private Const COL_Quantity01 As Integer = 13       ' Quantity01
    '    Private Const COL_Quantity02 As Integer = 14       ' Quantity02
    '    Private Const COL_Quantity03 As Integer = 15       ' Quantity03
    '    Private Const COL_Quantity04 As Integer = 16       ' Quantity04
    '    Private Const COL_Quantity05 As Integer = 17       ' Quantity05
    '    Private Const COL_Quantity06 As Integer = 18       ' Quantity06
    '    Private Const COL_Quantity07 As Integer = 19       ' Quantity07
    '    Private Const COL_Quantity08 As Integer = 20       ' Quantity08
    '    Private Const COL_Quantity09 As Integer = 21       ' Quantity09
    '    Private Const COL_Quantity10 As Integer = 22       ' Quantity10
    '    Private Const COL_Quantity11 As Integer = 23       ' Quantity11
    '    Private Const COL_Quantity12 As Integer = 24       ' Quantity12
    '    Private Const COL_Quantity13 As Integer = 25       ' Quantity13
    '    Private Const COL_Quantity14 As Integer = 26       ' Quantity14
    '    Private Const COL_Quantity15 As Integer = 27       ' Quantity15
    '    Private Const COL_Quantity16 As Integer = 28       ' Quantity16
    '    Private Const COL_Quantity17 As Integer = 29       ' Quantity17
    '    Private Const COL_Quantity18 As Integer = 30       ' Quantity18
    '    Private Const COL_Quantity19 As Integer = 31       ' Quantity19
    '    Private Const COL_Quantity20 As Integer = 32       ' Quantity20
    '    Private Const COL_UnitPrice01 As Integer = 33      ' UnitPrice01
    '    Private Const COL_UnitPrice02 As Integer = 34      ' UnitPrice02
    '    Private Const COL_UnitPrice03 As Integer = 35      ' UnitPrice03
    '    Private Const COL_UnitPrice04 As Integer = 36      ' UnitPrice04
    '    Private Const COL_UnitPrice05 As Integer = 37      ' UnitPrice05
    '    Private Const COL_Coefficient01 As Integer = 38    ' Coefficient01
    '    Private Const COL_Coefficient02 As Integer = 39    ' Coefficient02
    '    Private Const COL_Coefficient03 As Integer = 40    ' Coefficient03
    '    Private Const COL_Coefficient04 As Integer = 41    ' Coefficient04
    '    Private Const COL_Coefficient05 As Integer = 42    ' Coefficient05
    '    Private Const COL_Permission As Integer = 43       ' Permission
    '#End Region


#Region "Const of tdbg - Total of Columns: 49"
    Private Const COL_IsCheck As Integer = 0           ' Đã kiểm tra 
    Private Const COL_TransID As Integer = 1           ' TransID
    Private Const COL_BlockID As Integer = 2           ' Mã khối
    Private Const COL_DepartmentID As Integer = 3      ' Mã phòng ban
    Private Const COL_TeamID As Integer = 4            ' Mã tổ nhóm
    Private Const COL_EmpGroupID As Integer = 5        ' Nhóm nhân viên
    Private Const COL_EmployeeID As Integer = 6        ' Mã nhân viên
    Private Const COL_FullName As Integer = 7          ' Họ và tên
    Private Const COL_ProductID As Integer = 8         ' Sản phẩm
    Private Const COL_ProductName As Integer = 9       ' Tên sản phẩm 
    Private Const COL_StageID As Integer = 10          ' Công đoạn
    Private Const COL_StageName As Integer = 11        ' Tên công đoạn
    Private Const COL_ProductVoucherNo As Integer = 12 ' Số phiếu chấm công
    Private Const COL_Quantity01 As Integer = 13       ' Quantity01
    Private Const COL_Quantity02 As Integer = 14       ' Quantity02
    Private Const COL_Quantity03 As Integer = 15       ' Quantity03
    Private Const COL_Quantity04 As Integer = 16       ' Quantity04
    Private Const COL_Quantity05 As Integer = 17       ' Quantity05
    Private Const COL_Quantity06 As Integer = 18       ' Quantity06
    Private Const COL_Quantity07 As Integer = 19       ' Quantity07
    Private Const COL_Quantity08 As Integer = 20       ' Quantity08
    Private Const COL_Quantity09 As Integer = 21       ' Quantity09
    Private Const COL_Quantity10 As Integer = 22       ' Quantity10
    Private Const COL_Quantity11 As Integer = 23       ' Quantity11
    Private Const COL_Quantity12 As Integer = 24       ' Quantity12
    Private Const COL_Quantity13 As Integer = 25       ' Quantity13
    Private Const COL_Quantity14 As Integer = 26       ' Quantity14
    Private Const COL_Quantity15 As Integer = 27       ' Quantity15
    Private Const COL_Quantity16 As Integer = 28       ' Quantity16
    Private Const COL_Quantity17 As Integer = 29       ' Quantity17
    Private Const COL_Quantity18 As Integer = 30       ' Quantity18
    Private Const COL_Quantity19 As Integer = 31       ' Quantity19
    Private Const COL_Quantity20 As Integer = 32       ' Quantity20
    Private Const COL_UnitPrice01 As Integer = 33      ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 34      ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 35      ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 36      ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 37      ' UnitPrice05
    Private Const COL_Coefficient01 As Integer = 38    ' Coefficient01
    Private Const COL_Coefficient02 As Integer = 39    ' Coefficient02
    Private Const COL_Coefficient03 As Integer = 40    ' Coefficient03
    Private Const COL_Coefficient04 As Integer = 41    ' Coefficient04
    Private Const COL_Coefficient05 As Integer = 42    ' Coefficient05
    Private Const COL_RefSalProduct01 As Integer = 43  ' RefSalProduct01
    Private Const COL_RefSalProduct02 As Integer = 44  ' RefSalProduct02
    Private Const COL_RefSalProduct03 As Integer = 45  ' RefSalProduct03
    Private Const COL_RefSalProduct04 As Integer = 46  ' RefSalProduct04
    Private Const COL_RefSalProduct05 As Integer = 47  ' RefSalProduct05
    Private Const COL_Permission As Integer = 48       ' Permission
#End Region

    Private Const COL_Total As Integer = 49


    Dim dtTeamID As DataTable
    Dim iLastCol As Integer
    Dim bSelected As Boolean = False
    Dim bKeyPress As Boolean

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
#End Region

    Private _pSalaryVoucherID As String
    Public WriteOnly Property PSalaryVoucherID() As String
        Set(ByVal Value As String)
            _pSalaryVoucherID = Value
        End Set
    End Property

    Private _pieceworkCalMethodID As String
    Public WriteOnly Property PieceworkCalMethodID() As String
        Set(ByVal Value As String)
            _pieceworkCalMethodID = Value
        End Set
    End Property

    '8/11/2012 52115  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
    Private _pSalaryMode As String = ""
    Public WriteOnly Property PSalaryMode() As String
        Set(ByVal Value As String)
            _pSalaryMode = Value
        End Set
    End Property

    Private Sub D45F2012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bKeyPress Then Exit Sub

        If Not _bSaved Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub D45F2012_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg, 0, COL_IsCheck)
            Exit Sub
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowDetail_Click(Nothing, Nothing)
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

    Private Sub D45F2012_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        bKeyPress = True
    End Sub

    Private Sub D45F2012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        _bSaved = False
        SetShortcutPopupMenu(C1CommandHolder)
        LoadTDBCombo()
        Loadlanguage()
        AddField()
        LoadCaptionColumns() 'ID 88674 13.07.2016
        InputC1NumbericTDBGrid()
        tdbcDepartmentID.SelectedValue = "%"

        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuExportToExcel.Enabled = tdbg.RowCount > 0
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)

        btnSave.Enabled = ReturnPermission("D45F2010") > EnumPermission.View
        '8/11/2012 52115     '28/12/2012 sửa do lổi F12
        If _pSalaryMode <> "0" Then
            tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_FullName).Visible = False
        End If
        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, True, gbUnicode)
        '*****************************************
        If tdbg.Splits.Count > 1 Then
            AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, False, True, gbUnicode)
        End If
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************
        tdbcNameAutoComplete()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Dim arrCol() As FormatColumn
    Private Sub InputC1NumbericTDBGrid()
        '  Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
        'Thêm cột số có kiểu dữ liệu là Decimal
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity01).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity02).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity03).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity04).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity05).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity06).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity07).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity08).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity09).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity10).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity11).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity12).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity13).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity14).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity15).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity16).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity17).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity18).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity19).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Quantity20).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_UnitPrice01).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_UnitPrice02).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_UnitPrice03).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_UnitPrice04).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_UnitPrice05).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Coefficient01).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Coefficient02).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Coefficient03).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Coefficient04).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns.Item(COL_Coefficient05).DataField.ToString, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        'Định dạng các cột số trên lưới
        InputNumber(tdbg, arrCol)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bang_luong_cham_cong_san_pham_-_D45F2012") & UnicodeCaption(gbUnicode) 'B¶ng l§¥ng chÊm c¤ng s¶n phÈm - D45F2012
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnShowDetail.Text = rl3("Hien_thi") & Space(1) & "(F12)"
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã tổ nhóm
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên tổ nhóm
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã phòng ban
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên phòng ban
        '================================================================ 
        tdbg.Columns("IsCheck").Caption = rl3("Da_kiem_tra") 'Đã kiểm tra 
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Ma_nhom_nhan_vien") 'Mã nhóm nhân viên
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và tên

        tdbg.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm 
        tdbg.Columns("StageID").Caption = rl3("Cong_doan")      'Công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan")   'Tên công đoạn

        tdbg.Columns("ProductVoucherNo").Caption = rl3("So_phieu_cham_cong")




        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuExportToExcel.Text = rl3("Xuat__Excel")
        mnuPrint.Text = rL3("_In") '&In

        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub LoadTDBCombo()
        'Dim sSQL As String = ""

        'Load tdbcBlockID
        LoadDataSource(tdbcBlockID, ReturnTableBlockID_D09P6868(gsDivisionID, "D45F2010", 0), gbUnicode)

        'Load tdbcTeamID
        'dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2010", 0)


        'Load tdbcDepartmentID
        'Dim dtDepartment As DataTable = ReturnTableDepartmentID(True, , gbUnicode)
        Dim dtDepartment As DataTable = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2010", 0)
        'LoadDataSource(tdbcDepartmentID, dtDepartment, gbUnicode)
        tdbcBlockID.SelectedValue = _blockID
        If _blockID = "" Or _blockID = "%" Then
            LoadDataSource(tdbcDepartmentID, dtDepartment, gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartment, _blockID, gbUnicode)
        End If

    End Sub

    'Private Sub LoadtdbcTeamID(ByVal ID As String)
    '    If ID = "%" Then
    '        LoadDataSource(tdbcTeamID, dtTeamID, gbUnicode)
    '    Else
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID ='%' Or DepartmentID  = " & SQLString(ID), True), gbUnicode)
    '    End If
    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        'If tdbcDepartmentID.SelectedValue Is Nothing Then
        '    LoadtdbcTeamID("-1")
        'Else
        '    LoadtdbcTeamID(tdbcDepartmentID.SelectedValue.ToString)
        'End If
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, IIf(_blockID <> "", _blockID, "%").ToString, ReturnValueC1Combo(tdbcDepartmentID), gbUnicode)

        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
    'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
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
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClauseClient.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub
#End Region

    Private Function SQLStoreD45P2012() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2012 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_PSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) 'BlockID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadCaptionColumns()
        Dim sSQL As String = ""
        sSQL = "-- Do nguon caption dong cho 5 cot tham chieu " & vbCrLf & _
                " SELECT      RefID, RefCaptionU AS RefCaption, Disabled " & vbCrLf & _
                " FROM        D09T0080        WITH (NOLOCK) " & vbCrLf & _
                " WHERE       Type = '5000'"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            tdbg.Splits(0).DisplayColumns(dt.Rows(i)("RefID").ToString).Visible = Not L3Bool(dt.Rows(i)("Disabled"))
            tdbg.Columns(dt.Rows(i)("RefID").ToString).Caption = L3String(dt.Rows(i)("RefCaption"))
        Next
    End Sub

    Dim dtgrid As DataTable
    Dim sFilter As New System.Text.StringBuilder
    Dim bRefreshFilter As Boolean
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P2012()
        dtgrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtgrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtgrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        FooterSum()
    End Sub

    Private Sub FormatGrid()
        Dim i As Integer = 0

        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        '*****************************
        tdbg.Splits(0).Caption = rl3("Thong_tin_chung")
        tdbg.Splits(0).CaptionStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)
        '*****************************
        If tdbg.Splits.Count >= 2 Then
            tdbg.Splits(1).Caption = rl3("Thong_tin_luong")
            tdbg.Splits(1).CaptionStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)
            For i = COL_Total To tdbg.Columns.Count - 1
                tdbg.Splits(0).DisplayColumns(i).Visible = False
                tdbg.Splits(1).DisplayColumns(i).Locked = True
            Next
        End If

        For i = 0 To COL_Coefficient05
            tdbg.Splits(0).DisplayColumns(i).Visible = True
            If tdbg.Splits.Count >= 2 Then tdbg.Splits(1).DisplayColumns(i).Visible = False
        Next

        tdbg.Splits(0).DisplayColumns(COL_TransID).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        Column_CaptionAndVisible()
    End Sub

    Private Sub CreateSplit()
        If tdbg.Splits.Count > 1 Then tdbg.RemoveHorizontalSplit(1)
        tdbg.InsertHorizontalSplit(1)
        tdbg.Splits(0).SplitSize = 10 '400
        tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable

        tdbg.Splits(1).SplitSize = 7
        tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
        tdbg.Splits(1).RecordSelectors = False
        tdbg.Splits(1).BorderStyle = Border3DStyle.Flat

        tdbg.Splits(1).RecordSelectors = False
    End Sub

    'Add 90 cot luong
    Private Sub AddField()
        Dim sSQL As String
        'Tim xem co su dung khoan thu nhap nao khong?
        sSQL = "SELECT D61.Formula, Case When D61.Disabled is Null Or (D61.IsNotPrint=1) Then 1 Else D61.Disabled End Disabled, " & vbCrLf
        sSQL &= "Case When D61.ShortName" & UnicodeJoin(gbUnicode) & " is not null Then D61.ShortName" & UnicodeJoin(gbUnicode) & " Else D20.ShortName" & UnicodeJoin(gbUnicode) & " +'('+ D20.code +')' End As Short,D61.Decimals" & vbCrLf
        sSQL &= "FROM D45T0020 D20  WITH(NOLOCK) left join D45T1061 D61  WITH(NOLOCK) On D61.PWCalNo = D20.Code And PieceworkCalMethodID = " & SQLString(_pieceworkCalMethodID) & vbCrLf
        sSQL &= "ORDER BY D20.Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dr() As DataRow = dt.Select("Disabled =0")
        If dr.Length > 0 Then 'Có sử dụng khỏan thu nhập
            Try
                Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
                CreateSplit()

                'cac cot phuong phap tinh luong     
                For i As Integer = 0 To dt.Rows.Count - 1
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "Amount" & Format(i + 1, "00")
                    'dc.NumberFormat = "N" & dt.Rows(i).Item("Decimals").ToString 'IncidentID	52134 'DxxFormat.DefaultNumber2
                    dc.NumberFormat = InsertFormat(dt.Rows(i).Item("Decimals").ToString)
                    tdbg.Columns.Add(dc)
                    AddDecimalColumns(arrCol, dc.DataField.ToString, dc.NumberFormat, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.Font = FontUnicode(gbUnicode)
                    '****************************
                    tdbg.Columns(dc.DataField).Caption = dt.Rows(i).Item("Short").ToString
                    tdbg.Columns(COL_Total + i).Tag = dt.Rows(i).Item("Formula").ToString
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        FormatGrid()
    End Sub

    Private Sub Column_CaptionAndVisible()
        Dim sSQL As String = ""
        Dim dt As DataTable
        Dim i As Integer = 0

        'Cac cot so luong
        sSQL = "SELECT Code, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')' As Short " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) WHERE Type='QTY' ORDER BY Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_Quantity01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_Quantity01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_Quantity01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
        '------------------------------------------------------------------------------
        'Cac cot Don gia
        sSQL = "SELECT  Code, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')'  as Short " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) WHERE Type='PRICE' ORDER BY 	Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_UnitPrice01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
        '------------------------------------------------------------------------------
        'Cac cot he so
        sSQL = "SELECT Code, Disabled, Short" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')' Short " & vbCrLf
        sSQL &= "FROM D13T9000  WITH(NOLOCK) WHERE Type='D45T1010' ORDER BY Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_Coefficient01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_Coefficient01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_Coefficient01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If AllowSave() = False Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD45T2012s.ToString)


        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
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

    Private Function SQLUpdateD45T2012s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D45T2012 Set ")
            sSQL.Append("IsCheck = " & SQLNumber(tdbg(i, COL_IsCheck))) 'tinyint, NULL
            sSQL.Append(" Where ")
            sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID))) 'varchar[20], NULL
            sSQL.Append(" And DivisionID = " & SQLString(gsDivisionID)) 'varchar[20], NULL
            sSQL.Append(" And PSalaryVoucherID = " & SQLString(_PSalaryVoucherID)) 'varchar[20], NULL
            sSQL.Append(" And TransID = " & SQLString(tdbg(i, COL_TransID))) 'varchar[20], NULL
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnShowDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDetail.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowDetail.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

#Region "tdbg"
    'IncidentID	52115
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtgrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message

            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_IsCheck
                If L3Byte(tdbg.Columns(COL_Permission).Text) < 2 Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.ColIndex >= COL_Total Then
            If e.Row >= 0 Then 'Cột không phải Header
                If tdbg.RowCount > 0 Then
                    e.CellTip = tdbg.Columns(e.ColIndex).Tag.ToString
                    e.TipStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                Else
                    e.CellTip = "" 'Không có dữ liệu thì set tooltip =””
                End If
            Else 'Cột Header
                e.CellTip = "" 'Không có dữ liệu thì set tooltip =””
            End If
        Else
            e.CellTip = ""
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        tdbg.AllowSort = False
        Select Case e.ColIndex
            Case COL_IsCheck
                PressHeadClick()
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub PressHeadClick()
        Dim bChoose As Boolean = Not bSelected
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Byte(tdbg(i, COL_Permission)) >= 2 Then
                tdbg(i, COL_IsCheck) = bChoose
            End If
        Next i
        bSelected = bChoose
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_IsCheck
                    PressHeadClick()
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_IsCheck, e, 0)
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsCheck 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub
#End Region


    Public Sub FooterSum()
        Dim dblSum As Double

        For j As Integer = COL_Quantity01 To tdbg.Columns.Count - 1
            dblSum = 0
            If tdbg.Columns(j).NumberFormat <> "" Then
                For i As Integer = 0 To tdbg.RowCount - 1
                    dblSum += Number(tdbg(i, j))
                Next i
                tdbg.Columns(j).FooterText = Format(dblSum, tdbg.Columns(j).NumberFormat)
            End If

        Next j
        If _pSalaryMode <> "0" Then
            FooterTotalGrid(tdbg, COL_ProductID)
        Else
            FooterTotalGrid(tdbg, COL_EmployeeID)
        End If

    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        'Chuẩn hóa D09U1111 B7: Xuất Excel
        Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
	CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        'ResetTableForExcel(tdbg, gdtCaptionExcel)
        'With frm
        '    .FormID = Me.Name
        '    .UseUnicode = gbUnicode
        '    .dtLoadGrid = gdtCaptionExcel
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Dim frm As New D45F4000
        'With frm
        '    .FormActive = D45E0340Form.D45F4020
        '    .FormPermission = "D45F4020"
        '    .DepartmentID = CbVal(tdbcDepartmentID)
        '    .TeamID = CbVal(tdbcTeamID)
        '    .Flag = False
        '    .PSalaryVoucherID = _pSalaryVoucherID
        '    .FindServer = sFindServer
        '    .ShowDialog()
        '    .Dispose()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "FormActive", "D45F4020")
        'SetProperties(arrPro, "FormPermission", "D45F4020")
        SetProperties(arrPro, "DepartmentID", CbVal(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", CbVal(tdbcTeamID))
        SetProperties(arrPro, "Flag", False)
        SetProperties(arrPro, "PSalaryVoucherID", _pSalaryVoucherID)
        SetProperties(arrPro, "sFilter", sFindServer)
        CallFormShow(Me, "D45D0340", "D45F4020", arrPro)
    End Sub


End Class