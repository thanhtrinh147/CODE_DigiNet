Imports System
Public Class D45F2007
    Private _sMethod As String
    Private Shared _blockID As String
    Dim dtDepartmentID, dtTeamID, dtTeamID_Detail, dtGrid, dtEmployeeID, dtEmpGroupID As DataTable

    Dim bUpdated As Boolean = False, bNotInList As Boolean = False
    Dim iColumns() As Integer = {COL_DepartmentID, COL_TeamID} ', COL_TeamName}
    Dim iColumns1() As Integer = {COL_TeamID, COL_EmpGroupID}
    Dim iColumns2() As Integer = {COL_ProductName, COL_OProductName}
    Dim iColumns3() As Integer = {COL_StageID}
    Dim iColumns4() As Integer = {COL_EmpGroupID}
    Dim iLastCol As Integer = -1
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown 'ID 88926  23/01/2017

    Dim arrDelete As String = ""

    Private _createVoucherNo_D45F2020 As Boolean
    Public WriteOnly Property  CreateVoucherNo_D45F2020() As Boolean
        Set(ByVal Value As Boolean)
            _createVoucherNo_D45F2020 = Value
        End Set
    End Property


    Public WriteOnly Property BlockID As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property


    Public WriteOnly Property sMethod As String
        Set(ByVal Value As String)
            _sMethod = Value
        End Set
    End Property


'#Region "Const of tdbg - Total of Columns: 59"
'    Private Const COL_TransID As Integer = 0          ' TransID
'    Private Const COL_OldDepartmentID As Integer = 1  ' OldDepartmentID
'    Private Const COL_OldTeamID As Integer = 2        ' OldTeamID
'    Private Const COL_OldEmpGroupID As Integer = 3    ' OldEmpGroupID
'    Private Const COL_OldEmployeeID As Integer = 4    ' OldEmployeeID
'    Private Const COL_IsOtherModule As Integer = 5    ' IsOtherModule
'    Private Const COL_OldStageID As Integer = 6       ' OldStageID
'    Private Const COL_DepartmentID As Integer = 7     ' Phòng ban
'    Private Const COL_DepartmentName As Integer = 8   ' Phòng ban1
'    Private Const COL_TeamID As Integer = 9           ' Tổ nhóm
'    Private Const COL_TeamName As Integer = 10        ' Tổ nhóm1
'    Private Const COL_EmpGroupID As Integer = 11      ' Nhóm nhân viên
'    Private Const COL_IsEmpStrengthen As Integer = 12 ' NV tăng cường
'    Private Const COL_EmployeeID As Integer = 13      ' Mã nhân viên
'    Private Const COL_ProductID As Integer = 14       ' Mã sản phẩm
'    Private Const COL_ProductName As Integer = 15     ' Tên sản phẩm
'    Private Const COL_StageName As Integer = 16       ' Công đoạn
'    Private Const COL_MachineID As Integer = 17       ' Máy sản xuất
'    Private Const COL_Spec01ID As Integer = 18        ' Spec01ID
'    Private Const COL_Spec02ID As Integer = 19        ' Spec02ID
'    Private Const COL_Spec03ID As Integer = 20        ' Spec03ID
'    Private Const COL_Spec04ID As Integer = 21        ' Spec04ID
'    Private Const COL_Spec05ID As Integer = 22        ' Spec05ID
'    Private Const COL_Spec06ID As Integer = 23        ' Spec06ID
'    Private Const COL_Spec07ID As Integer = 24        ' Spec07ID
'    Private Const COL_Spec08ID As Integer = 25        ' Spec08ID
'    Private Const COL_Spec09ID As Integer = 26        ' Spec09ID
'    Private Const COL_Spec10ID As Integer = 27        ' Spec10ID
'    Private Const COL_Quantity01 As Integer = 28      ' Quantity01
'    Private Const COL_Quantity02 As Integer = 29      ' Quantity02
'    Private Const COL_Quantity03 As Integer = 30      ' Quantity03
'    Private Const COL_Quantity04 As Integer = 31      ' Quantity04
'    Private Const COL_Quantity05 As Integer = 32      ' Quantity05
'    Private Const COL_Quantity06 As Integer = 33      ' Quantity06
'    Private Const COL_Quantity07 As Integer = 34      ' Quantity07
'    Private Const COL_Quantity08 As Integer = 35      ' Quantity08
'    Private Const COL_Quantity09 As Integer = 36      ' Quantity09
'    Private Const COL_Quantity10 As Integer = 37      ' Quantity10
'    Private Const COL_Quantity11 As Integer = 38      ' Quantity11
'    Private Const COL_Quantity12 As Integer = 39      ' Quantity12
'    Private Const COL_Quantity13 As Integer = 40      ' Quantity13
'    Private Const COL_Quantity14 As Integer = 41      ' Quantity14
'    Private Const COL_Quantity15 As Integer = 42      ' Quantity15
'    Private Const COL_Quantity16 As Integer = 43      ' Quantity16
'    Private Const COL_Quantity17 As Integer = 44      ' Quantity17
'    Private Const COL_Quantity18 As Integer = 45      ' Quantity18
'    Private Const COL_Quantity19 As Integer = 46      ' Quantity19
'    Private Const COL_Quantity20 As Integer = 47      ' Quantity20
'    Private Const COL_RefSalProduct01 As Integer = 48 ' RefSalProduct01
'    Private Const COL_RefSalProduct02 As Integer = 49 ' RefSalProduct02
'    Private Const COL_RefSalProduct03 As Integer = 50 ' RefSalProduct03
'    Private Const COL_RefSalProduct04 As Integer = 51 ' RefSalProduct04
'    Private Const COL_RefSalProduct05 As Integer = 52 ' RefSalProduct05
'    Private Const COL_OProductName As Integer = 53    ' OProductName
'    Private Const COL_StageID As Integer = 54         ' StageID
'    Private Const COL_EmployeeList As Integer = 55    ' Danh sách nhân viên
'    Private Const COL_BUTTON As Integer = 56                ' 
'    Private Const COL_Notes As Integer = 57           ' Ghi chú
'    Private Const COL_ProSalTransID As Integer = 58   ' ProSalTransID
'#End Region

#Region "Const of tdbg - Total of Columns: 60"
    Private Const COL_TransID As Integer = 0          ' TransID
    Private Const COL_OldDepartmentID As Integer = 1  ' OldDepartmentID
    Private Const COL_OldTeamID As Integer = 2        ' OldTeamID
    Private Const COL_OldEmpGroupID As Integer = 3    ' OldEmpGroupID
    Private Const COL_OldEmployeeID As Integer = 4    ' OldEmployeeID
    Private Const COL_IsOtherModule As Integer = 5    ' IsOtherModule
    Private Const COL_OldStageID As Integer = 6       ' OldStageID
    Private Const COL_DepartmentID As Integer = 7     ' Phòng ban
    Private Const COL_DepartmentName As Integer = 8   ' Tên phòng ban
    Private Const COL_TeamID As Integer = 9           ' Tổ nhóm
    Private Const COL_TeamName As Integer = 10        ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 11      ' Nhóm nhân viên
    Private Const COL_IsEmpStrengthen As Integer = 12 ' NV tăng cường
    Private Const COL_EmployeeID As Integer = 13      ' Mã nhân viên
    Private Const COL_ProductID As Integer = 14       ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 15     ' Tên sản phẩm
    Private Const COL_StageName As Integer = 16       ' Công đoạn
    Private Const COL_MachineID As Integer = 17       ' Máy sản xuất
    Private Const COL_Spec01ID As Integer = 18        ' Spec01ID
    Private Const COL_Spec02ID As Integer = 19        ' Spec02ID
    Private Const COL_Spec03ID As Integer = 20        ' Spec03ID
    Private Const COL_Spec04ID As Integer = 21        ' Spec04ID
    Private Const COL_Spec05ID As Integer = 22        ' Spec05ID
    Private Const COL_Spec06ID As Integer = 23        ' Spec06ID
    Private Const COL_Spec07ID As Integer = 24        ' Spec07ID
    Private Const COL_Spec08ID As Integer = 25        ' Spec08ID
    Private Const COL_Spec09ID As Integer = 26        ' Spec09ID
    Private Const COL_Spec10ID As Integer = 27        ' Spec10ID
    Private Const COL_Quantity01 As Integer = 28      ' Quantity01
    Private Const COL_Quantity02 As Integer = 29      ' Quantity02
    Private Const COL_Quantity03 As Integer = 30      ' Quantity03
    Private Const COL_Quantity04 As Integer = 31      ' Quantity04
    Private Const COL_Quantity05 As Integer = 32      ' Quantity05
    Private Const COL_Quantity06 As Integer = 33      ' Quantity06
    Private Const COL_Quantity07 As Integer = 34      ' Quantity07
    Private Const COL_Quantity08 As Integer = 35      ' Quantity08
    Private Const COL_Quantity09 As Integer = 36      ' Quantity09
    Private Const COL_Quantity10 As Integer = 37      ' Quantity10
    Private Const COL_Quantity11 As Integer = 38      ' Quantity11
    Private Const COL_Quantity12 As Integer = 39      ' Quantity12
    Private Const COL_Quantity13 As Integer = 40      ' Quantity13
    Private Const COL_Quantity14 As Integer = 41      ' Quantity14
    Private Const COL_Quantity15 As Integer = 42      ' Quantity15
    Private Const COL_Quantity16 As Integer = 43      ' Quantity16
    Private Const COL_Quantity17 As Integer = 44      ' Quantity17
    Private Const COL_Quantity18 As Integer = 45      ' Quantity18
    Private Const COL_Quantity19 As Integer = 46      ' Quantity19
    Private Const COL_Quantity20 As Integer = 47      ' Quantity20
    Private Const COL_RefSalProduct01 As Integer = 48 ' RefSalProduct01
    Private Const COL_RefSalProduct02 As Integer = 49 ' RefSalProduct02
    Private Const COL_RefSalProduct03 As Integer = 50 ' RefSalProduct03
    Private Const COL_RefSalProduct04 As Integer = 51 ' RefSalProduct04
    Private Const COL_RefSalProduct05 As Integer = 52 ' RefSalProduct05
    Private Const COL_OProductName As Integer = 53    ' OProductName
    Private Const COL_StageID As Integer = 54         ' StageID
    Private Const COL_EmployeeList As Integer = 55    ' Danh sách nhân viên
    Private Const COL_BUTTON As Integer = 56                ' 
    Private Const COL_Notes As Integer = 57           ' Ghi chú
    Private Const COL_Attachment As Integer = 58      ' Đính kèm '120665 - 26 June 2019
    Private Const COL_ProSalTransID As Integer = 59   ' ProSalTransID
#End Region


#Region "Parameters"

    Private _productVoucherID As String = ""
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _productVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private _payrollVoucherID As String
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _voucherDate As String
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _departmentID As String = "%"
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = "%"
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _note As String
    Public WriteOnly Property Note() As String
        Set(ByVal Value As String)
            _note = Value
        End Set
    End Property

    Private _isVisibleEmployeeID As Boolean = False
    Public WriteOnly Property IsVisibleEmployeeID() As Boolean
        Set(ByVal Value As Boolean)
            _isVisibleEmployeeID = Value
        End Set
    End Property

    Private _mode As Integer = 1 '0(Theo nhan vien)'3(Theo nhóm nhân viên)
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private _isSpec As Boolean
    Public WriteOnly Property IsSpec() As Boolean
        Set(ByVal Value As Boolean)
            _isSpec = Value
        End Set
    End Property
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
    Private _bSaved As Boolean = False

    Public Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
        Set(ByVal Value As Boolean)
            _bSaved = Value
        End Set
    End Property
    

    Private Sub D45F2007_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not _bSaved And bUpdated And btnSave.Enabled Then
            If Not AskMsgBeforeClose() Then
                e.Cancel = True : Exit Sub
            End If
            ExecuteSQLNoTransaction(SQLDeleteD45T2070(arrDelete))
            bUpdated = False
        End If
    End Sub

    Private Sub D45F2007_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            btnF12_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
            'Set ẩn hiện lại các nút nhấn trên lưới
            'RefreshButton()
            tdbg.Focus()
        End If

    End Sub

    Private Sub D45F2007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        clsFilterDropdown = New Lemon3.Controls.FilterDropdown() 'ID 88926  23/01/2017
        clsFilterDropdown.CheckD91 = True  'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
        clsFilterDropdown.UseFilterDropdown(tdbg, COL_ProductID)
        '***********************
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadTDBDropDown()
        ResetFooterGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        tdbg_LockedColumns()
        LoadTDBGridQuantityCaption()
        LoadDefault()
        LoadCaptionColumns() 'ID 88674 13.07.2016
        LoadTDBGrid()
        'Su dung Enter di chuyen den o duoi o hien hanh
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)
        '*****************************************
         CallD09U1111_Button(True)
        InputbyUnicode(Me, gbUnicode)
        CheckNumberTDBGrid()
        '********************
        SetResolutionForm(Me)
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
            tdbg.Splits(1).DisplayColumns(dt.Rows(i)("RefID").ToString).Visible = Not L3Bool(dt.Rows(i)("Disabled"))
            tdbg.Columns(dt.Rows(i)("RefID").ToString).Caption = L3String(dt.Rows(i)("RefCaption"))
        Next
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Thong_ke_san_pham_tinh_luong_theo_phong_ban_to_nhom") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Thçng k£ s¶n phÈm tÛnh l§¥ng theo phßng ban tå nhâm
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        btnF12.Text = "F12 (" & rl3("Hien_thi") & ")"
        '================================================================ 
        grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
        grpDetail.Text = rl3("Chi_tiet_cham_cong") 'Chi tiết chấm công
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbdStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbdProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbdProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbdEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
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
        tdbdEmpGroupID.Columns("EmpGroupID").Caption = rl3("Ma") 'Mã
        tdbdEmpGroupID.Columns("EmpGroupName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban")'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom")'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns("IsEmpStrengthen").Caption = rL3("NV_tang_cuong") 'NV tăng cường
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("StageName").Caption = rL3("Cong_doan") 'Công đoạn
        tdbg.Columns(COL_EmployeeList).Caption = rL3("Danh_sach_nhan_vien")
        '================================================================ 
        mnuSplit.Text = rl3("_Tach_so_luong") '&Tách số lượng
        mnuSelect.Text = rL3("Chon__quy_trinh") 'Chọn &quy trình

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        tdbg.Columns(COL_MachineID).Caption = rL3("May_san_xuat") 'Máy sản xuất

        grpDetail.Text = rL3("Chi_tiet_thong_ke_san_pham") 'Chi tiết thống kê sản phẩm

        '================================================================ 
        tdbg.Columns(COL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns("Attachment").Caption = rL3("Dinh_kem") 'Đính kèm
        lblGroupProductID.Text = rL3("Nhom_san_pham") 'Nhóm sản phẩm
        tdbcGroupProductID.Columns("GroupProductID").Caption = rL3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rL3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(1).DisplayColumns(COL_ProductID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeList).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadDefault()
        txtProductVoucherNo.Text = _productVoucherNo
        txtNote.Text = _note
        txtVoucherDate.Text = _voucherDate
        '**********************************
        tdbcBlockID.SelectedValue = _blockID


        'tdbcDepartmentID.SelectedValue = "%"
        'tdbcDepartmentID.Tag = "%"
        'tdbcTeamID.SelectedValue = "%"
        'tdbcTeamID.Tag = "%"


        If _sMethod <> "1" Then
            tdbg.Splits(1).DisplayColumns(COL_EmployeeList).Visible = False
            tdbg.Splits(1).DisplayColumns(COL_BUTTON).Visible = False
        End If


        tdbcDepartmentID.SelectedValue = _departmentID
        tdbcDepartmentID.Tag = _departmentID
        tdbcTeamID.SelectedValue = _teamID
        tdbcTeamID.Tag = _teamID

        If _departmentID <> "%" Then tdbcDepartmentID.Enabled = False
        If _teamID <> "%" Then tdbcTeamID.Enabled = False

        '**********************************
        tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = Not _isVisibleEmployeeID
        tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = (_mode = 3)
        tdbg.Splits(0).DisplayColumns(COL_IsEmpStrengthen).Visible = Not _isVisibleEmployeeID

        'If tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible = False AndAlso tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False Then
        '    tdbg.Splits(0).SplitSize = 379
        '    tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
        'End If
        '**********************************
        If _createVoucherNo_D45F2020 = False Then
            tdbg.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.NoCellTips
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).FetchStyle = False
            tdbg.Splits(0).DisplayColumns(COL_TeamID).FetchStyle = False
            tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).FetchStyle = False
            tdbg.Splits(0).DisplayColumns(COL_EmployeeID).FetchStyle = False
            tdbg.Splits(1).DisplayColumns(COL_StageName).FetchStyle = False
        End If

    End Sub

    Private Sub CheckNumberTDBGrid()
        Dim arrCol() As FormatColumn = Nothing
        'Neu dc goi theo quy trinh tu D45F2022 va cham cong theo Nhan vien thi khong cho nhap so am o các cot SL
        If _mode = 1 Then
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity01).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity02).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity03).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity04).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity05).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity06).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity07).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity08).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity09).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity10).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity11).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity12).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity13).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity14).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity15).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity16).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity17).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity18).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity19).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity20).DataField, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm
        Else
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity01).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity02).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity03).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity04).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity05).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity06).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity07).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity08).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity09).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity10).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity11).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity12).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity13).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity14).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity15).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm

            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity16).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity17).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity18).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity19).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
            AddDecimalColumns(arrCol, tdbg.Columns(COL_Quantity20).DataField, DxxFormat.DefaultNumber2, 18, 4) 'Cột có DataType là Decimal(18,2),k cho nhập số âm
        End If
      
        InputNumber(tdbg, arrCol)
    End Sub

    Public Sub LoadTDBGridQuantityCaption()
        Dim sSQL As String = ""
        sSQL = "Select Type, Code, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Disabled" & vbCrLf
        sSQL &= "From D45T0010  WITH(NOLOCK) Where Type='QTY'" & vbCrLf
        sSQL &= "Order by Type, Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To 19 'dt.Rows.Count - 1
                tdbg.Columns(COL_Quantity01 + i).Caption = dt.Rows(i).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns(COL_Quantity01 + i).Visible = Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))
                tdbg.Splits(1).DisplayColumns(COL_Quantity01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
        'dt = Nothing
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcBlockID

        LoadDataSource(tdbcBlockID, ReturnTableBlockID_D09P6868(gsDivisionID, "D45F2000", 0), gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2000", 0)
        'LoadtdbcTeamID("-1", )
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, gbUnicode)
        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2000", 0)
        LoadTDBCDepartmentID(_blockID)

        'Load tdbcGroupProductID
        sSQL = "Select D45.GroupProductID, D45.GroupProductName" & UnicodeJoin(gbUnicode) & " As GroupProductName" & vbCrLf
        sSQL &= "From D45T1070 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.Disabled=0" & vbCrLf
        sSQL &= "Order by D45.GroupProductID"
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCDepartmentID(ByVal sID As String)
        If sID = "%" Or sID = "" Then
            LoadDataSource(tdbcDepartmentID, dtDepartmentID, gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID='%' or BlockID=" & SQLString(_blockID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDDepartmentID(ByVal sID As String)
        If sID = "%" Or sID = "" Then
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID<>'%'", True), gbUnicode)
        Else
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID=" & SQLString(_blockID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdEmployeeID
        sSQL = "Select D13.EmployeeID as EmployeeID, D09.RefEmployeeID as RefEmployeeID, " & vbCrLf
        If gbUnicode = False Then
            sSQL &= "Isnull(D09.LastName,'') + ' ' + Isnull(D09.MiddleName,'') + ' ' + Isnull(D09.FirstName,'')  as EmployeeName, " & vbCrLf
        Else
            sSQL &= "Isnull(D09.LastNameU,'') + ' ' + Isnull(D09.MiddleNameU,'') + ' ' + Isnull(D09.FirstNameU,'')  as EmployeeName, " & vbCrLf
        End If
        sSQL &= " D09.FirstName" & UnicodeJoin(gbUnicode) & " As FirstName, D13.DepartmentID, D13.TeamID, D13.EmpGroupID" & vbCrLf
        sSQL &= "From D13T0101 D13  WITH(NOLOCK) Inner join D09T0201 D09  WITH(NOLOCK) On D13.EmployeeID =  D09.EmployeeID " & vbCrLf
        sSQL &= "Where D13.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And (Case when " & SQLString(_departmentID) & " <> '%' then D13.DepartmentID " & vbCrLf
        sSQL &= "else '%' end = " & SQLString(_departmentID) & ")" & vbCrLf
        sSQL &= "And (Case when " & SQLString(_teamID) & " <> '%' then D13.TeamID " & vbCrLf
        sSQL &= "else '%' end = " & SQLString(_teamID) & ")" & vbCrLf
        sSQL &= "And PayrollVoucherID = " & SQLString(_payrollVoucherID) & vbCrLf
        dtEmployeeID = ReturnDataTable(sSQL)
        LoadDataSource(tdbdEmployeeID, dtEmployeeID, gbUnicode)

        'Load tdbdEmpGroupID
        dtEmpGroupID = ReturnTableEmpGroupID(False, gbUnicode)
        LoadtdbdEmpGroupID("-1", "-1")

        'Load tdbdTeamID
        dtTeamID_Detail = dtTeamID.DefaultView.ToTable
        dtTeamID_Detail.DefaultView.RowFilter = "TeamID <>'%'"
        dtTeamID_Detail = dtTeamID_Detail.DefaultView.ToTable
        LoadtdbdTeamID(tdbdTeamID, dtTeamID_Detail, ReturnValueC1Combo(tdbcBlockID), tdbg.Columns(COL_DepartmentID).Text, gbUnicode)

        'Load tdbdDepartmentID
        'Dim dt As DataTable = dtDepartmentID.DefaultView.ToTable
        'dt.DefaultView.RowFilter = "DepartmentID <>'%'"
        'dt = dt.DefaultView.ToTable
        'LoadDataSource(tdbdDepartmentID, dt, gbUnicode)
        LoadTDBDDepartmentID(_blockID)

        'Load tdbdMachineID
        sSQL = "-- DropDown May san xuat " & vbCrLf
        sSQL &= "     SELECT MachineID, MachineNameU AS MachineName " & vbCrLf
        sSQL &= "  FROM 	D45T1110 WITH(NOLOCK)" & vbCrLf
        sSQL &= "       WHERE Disabled = 0 " & vbCrLf
        sSQL &= " ORDER BY MachineName"
        LoadDataSource(tdbdMachineID, sSQL, gbUnicode)

        'Load tdbdProductID
        sSQL = "Select ProductID, ProductName" & UnicodeJoin(gbUnicode) & " As ProductName" & vbCrLf
        sSQL &= "From D45T1000  WITH(NOLOCK) Where Disabled=0" & vbCrLf
        sSQL &= "Order by ProductID"
        LoadDataSource(tdbdProductID, sSQL, gbUnicode)

        '************************************
        If _isSpec Then
            LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 1, gbUnicode)
            'Load 10 quy cách
            LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01ID, gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbdStageID(ByVal ID As String)
        Dim sSQL As String = ""

        'Load tdbdStageID
        If _mode <> 0 Then
            sSQL = "Select '*' As StageID, N'<" & IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode = False, "Toång coäng", "Tổng cộng").ToString, "Total").ToString & ">' As StageName, 0 as DisplayOrder" & vbCrLf
            sSQL &= "Union" & vbCrLf
        End If

        sSQL &= "Select Distinct D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "From D45T1081 D01  WITH(NOLOCK) Inner join D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "Where ProductID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by DisplayOrder, StageID"
        LoadDataSource(tdbdStageID, sSQL, gbUnicode)
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

    'Private Sub LoadtdbcTeamID(ByVal sDepartmentID As String)
    '    If sDepartmentID = "%" Then
    '        'LoadDataSource(tdbcTeamID, dtTeamID, gbUnicode)
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID ='%' ", True), gbUnicode)
    '    Else
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID ='%' Or DepartmentID  = " & SQLString(sDepartmentID), True), gbUnicode)
    '    End If
    'End Sub

    'Private Sub LoadtdbdTeamID(ByVal sDepartmentID As String)
    '    If sDepartmentID <> "" Then
    '        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID_Detail, "DepartmentID  = " & SQLString(sDepartmentID), True), gbUnicode)
    '    Else
    '        'LoadDataSource(tdbdTeamID, dtTeamID_Detail, gbUnicode)
    '        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID_Detail, "DepartmentID  = '-1'" & SQLString(sDepartmentID), True), gbUnicode)
    '    End If
    'End Sub

    Private Sub LoadtdbdEmpGroupID(ByVal sDepartmentID As String, ByVal sTeamID As String)
        Dim sFilter As String = ""

        If sDepartmentID <> "" Then
            If sFilter <> "" Then sFilter &= " And "
            sFilter &= "DepartmentID =" & SQLString(sDepartmentID)
        End If
        If sTeamID <> "" Then
            If sFilter <> "" Then sFilter &= " And "
            sFilter &= "TeamID =" & SQLString(sTeamID)
        End If

        Dim dttemp As DataTable = ReturnTableFilter(dtEmpGroupID, sFilter, True)

        LoadDataSource(tdbdEmpGroupID, ReturnTableFilter(dtEmpGroupID, sFilter, True), gbUnicode)
    End Sub

    Private Sub LoadtdbdEmployeeID(ByVal sDepartmentID As String, ByVal sTeamID As String, ByVal sEmpGroupID As String, ByVal bIsEmpStrengthen As Boolean)
        Dim sFilter As String = ""

        If bIsEmpStrengthen Then
            LoadDataSource(tdbdEmployeeID, dtEmployeeID.DefaultView.ToTable, gbUnicode)
        Else
            If sDepartmentID <> "" Then
                If sFilter <> "" Then sFilter &= " And "
                sFilter &= "DepartmentID =" & SQLString(sDepartmentID)
            End If
            If sTeamID <> "" Then
                If sFilter <> "" Then sFilter &= " And "
                sFilter &= "TeamID =" & SQLString(sTeamID)
            End If
            If sEmpGroupID <> "" Then
                If sFilter <> "" Then sFilter &= " And "
                sFilter &= "EmpGroupID =" & SQLString(sEmpGroupID)
            End If

            LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, sFilter, True), gbUnicode)
        End If

    End Sub

#Region "Events tdbcDepartmentID"
    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, gbUnicode)
        If CbVal(tdbcDepartmentID) <> "%" Then LoadtdbdTeamID(tdbdTeamID, dtTeamID_Detail, ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcDepartmentID), gbUnicode)
        tdbcTeamID.SelectedValue = "%"
        tdbcGroupProductID.ReadOnly = (ReturnValueC1Combo(tdbcTeamID, "TeamID") = "%" Or ReturnValueC1Combo(tdbcDepartmentID, "DepartmentID") = "%")
        tdbcGroupProductID.Text = ""
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        tdbcGroupProductID.ReadOnly = (ReturnValueC1Combo(tdbcTeamID, "TeamID") = "%" Or ReturnValueC1Combo(tdbcDepartmentID, "DepartmentID") = "%")
        tdbcGroupProductID.Text = ""
    End Sub
#End Region

#Region "53.Sửa lỗi gõ tên trên combo hay dropdown"
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcGroupProductID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcGroupProductID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        If tdbc.Tag Is Nothing OrElse CbVal(tdbc) <> tdbc.Tag.ToString Then
            LoadTDBGrid()
            tdbc.Tag = CbVal(tdbc)
        End If
    End Sub
#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2007()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid.Columns.Contains("DepartmentName") = False Then
            dtGrid.Columns.Add("DepartmentName", Type.GetType("System.String"))
        End If
        If dtGrid.Columns.Contains("TeamName") = False Then
            dtGrid.Columns.Add("TeamName", Type.GetType("System.String"))
        End If
         Dim dc As DataColumn = Nothing
        If dtGrid.Columns.Contains("Attachment") Then
            dc = dtGrid.Columns("Attachment")
        Else
            dc = dtGrid.Columns.Add("Attachment")
        End If
        For i As Integer = 0 To dtGrid.Rows.Count - 1
            dtGrid.Rows(i).Item("Attachment") = "(" & ReturnAttachmentNumber("D45T2001", dtGrid.Rows(i).Item("DepartmentID").ToString(), dtGrid.Rows(i).Item("ProductID").ToString(),txtProductVoucherNo.Text) & ")"  'Đính kèm
        Next
        '*******************
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        If (CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) <> "%") Then
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
            tdbg.Columns(COL_DepartmentID).DefaultValue = CbVal(tdbcDepartmentID)
            tdbg.Columns(COL_TeamID).DefaultValue = CbVal(tdbcTeamID)
            tdbg.Splits(0).SplitSize = 0
            tdbg.Splits(0).HScrollBar.Visible = False

            tdbg.SplitIndex = 1
            tdbg.Col = COL_ProductID
        ElseIf CbVal(tdbcDepartmentID) <> "%" Then
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = True
            tdbg.Columns(COL_DepartmentID).DefaultValue = CbVal(tdbcDepartmentID)
            tdbg.Splits(0).SplitSize = 7
            tdbg.Splits(0).HScrollBar.Visible = True
        ElseIf CbVal(tdbcTeamID) <> "%" Then
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
            tdbg.Columns(COL_TeamID).DefaultValue = CbVal(tdbcTeamID)
            tdbg.Splits(0).SplitSize = 7
            tdbg.Splits(0).HScrollBar.Visible = True
        Else
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = True
            tdbg.Columns(COL_DepartmentID).DefaultValue = ""
            tdbg.Columns(COL_TeamID).DefaultValue = ""
            tdbg.Splits(0).SplitSize = 7
            tdbg.Splits(0).HScrollBar.Visible = True
        End If
        tdbg.Refresh()
        '*************************************
        If tdbg.RowCount > 0 Or (CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) <> "%") Then
            'LoadtdbdTeamID("")
            'LoadtdbdEmpGroupID("", "")
            ReloadTdbdTeamID()
            ReloadTdbdEmpGroupID()
            ReloadTdbdEmployeeID()
        End If
        resetgrid()
    End Sub

    Private Sub resetgrid()
        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterSumNew(tdbg, COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20)
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        mnuSelect.Enabled = tdbg.RowCount > 0
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

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec01ID).Visible And tdbg.Columns(COL_Spec01ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec01ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec02ID).Visible And tdbg.Columns(COL_Spec02ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec02ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec03ID).Visible And tdbg.Columns(COL_Spec03ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec03ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec04ID).Visible And tdbg.Columns(COL_Spec04ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec04ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec05ID).Visible And tdbg.Columns(COL_Spec05ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec05ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec06ID).Visible And tdbg.Columns(COL_Spec06ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec06ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec07ID).Visible And tdbg.Columns(COL_Spec07ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec07ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec08ID).Visible And tdbg.Columns(COL_Spec08ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec08ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec09ID).Visible And tdbg.Columns(COL_Spec09ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec09ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec10ID).Visible And tdbg.Columns(COL_Spec10ID).Text <> "" Then
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

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec01ID).Visible And tdbg(i, COL_Spec01ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec01ID, tdbdSpec01ID.DisplayMember, tdbdSpec01ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec01ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec02ID).Visible And tdbg(i, COL_Spec02ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec02ID, tdbdSpec02ID.DisplayMember, tdbdSpec02ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec02ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec03ID).Visible And tdbg(i, COL_Spec03ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec03ID, tdbdSpec03ID.DisplayMember, tdbdSpec03ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec03ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec04ID).Visible And tdbg(i, COL_Spec04ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec04ID, tdbdSpec04ID.DisplayMember, tdbdSpec04ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec04ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec05ID).Visible And tdbg(i, COL_Spec05ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec05ID, tdbdSpec05ID.DisplayMember, tdbdSpec05ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec05ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec06ID).Visible And tdbg(i, COL_Spec06ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec06ID, tdbdSpec06ID.DisplayMember, tdbdSpec06ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec06ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec07ID).Visible And tdbg(i, COL_Spec07ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec07ID, tdbdSpec07ID.DisplayMember, tdbdSpec07ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec07ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec08ID).Visible And tdbg(i, COL_Spec08ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec08ID, tdbdSpec08ID.DisplayMember, tdbdSpec08ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec08ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec09ID).Visible And tdbg(i, COL_Spec09ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec09ID, tdbdSpec09ID.DisplayMember, tdbdSpec09ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec09ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec10ID).Visible And tdbg(i, COL_Spec10ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec10ID, tdbdSpec10ID.DisplayMember, tdbdSpec10ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec10ID))))
            End If

            tdbg(i, COL_ProductName) = sFullProductName
        Next
    End Sub

#Region "Luoi"

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_BUTTON 'STT
                e.Value = "..."
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        Select Case e.ColIndex
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
            Case COL_DepartmentID
                '    Application.DoEvents()
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmpGroupID).Text = ""
                Else
                    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")).Value = tdbg.Columns(e.ColIndex).DropDown.Columns("DepartmentName").Text
                End If
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_DepartmentID).Text, tdbg.Columns(COL_ProductID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_TeamID
                '    Application.DoEvents()
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmpGroupID).Text = ""
                Else
                    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")).Value = tdbg.Columns(e.ColIndex).DropDown.Columns("TeamName").Text
                End If
            Case COL_EmpGroupID
                ' Application.DoEvents()
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_EmployeeID).Text = ""
                End If
            Case COL_IsEmpStrengthen
                tdbg.Columns(COL_EmployeeID).Text = ""
            Case COL_ProductID 'ID 88926 23/01/2017
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = Nothing
                    If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 82152
                    AfterColUpdate(e.ColIndex, row)
                End If
        End Select
        UpdataDataGrid()
    End Sub

    Private Sub UpdataDataGrid()
        If _sMethod = "1" Then
            SetValueForColEmployeeList(tdbg.Row)
        End If
        resetgrid()
        bUpdated = True
    End Sub

    Private Sub tdbg_BeforeDelete(sender As Object, e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        ExecuteSQLNoTransaction(SQLDeleteD45T2070)
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        resetgrid()
        bUpdated = True
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DepartmentID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(COL_DepartmentID).DropDown.Columns(tdbdDepartmentID.DisplayMember).Text Then
                    'tdbg.Columns(COL_DepartmentID).Text = ""
                    'tdbg.Columns(COL_DepartmentName).Text = ""
                    'tdbg.Columns(COL_TeamID).Text = ""
                    'tdbg.Columns(COL_TeamName).Text = ""
                    'tdbg.Columns(COL_EmployeeID).Text = ""
                    'tdbg.Columns(COL_EmpGroupID).Text = ""
                    bNotInList = True
                Else
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_TeamID
                If tdbg.Columns(e.ColIndex).Text <> tdbdTeamID.Columns(tdbdTeamID.DisplayMember).Text Then
                    'tdbg.Columns(COL_TeamID).Text = ""
                    'tdbg.Columns(COL_TeamName).Text = ""
                    'tdbg.Columns(COL_EmployeeID).Text = ""
                    'tdbg.Columns(COL_EmpGroupID).Text = ""
                    bNotInList = True
                Else
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_EmpGroupID
                If tdbg.Columns(e.ColIndex).Text <> tdbdEmpGroupID.Columns(tdbdEmpGroupID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text <> tdbdEmployeeID.Columns(tdbdEmployeeID.DisplayMember).Text Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                End If
            Case COL_ProductID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg.Columns(COL_ProductID).Text <> tdbdProductID.Columns(tdbdProductID.DisplayMember).Text Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_OProductName).Text = ""
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If
            Case COL_StageName
                If tdbg.Columns(COL_StageName).Text <> tdbdStageID.Columns(tdbdStageID.DisplayMember).Text Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
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
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then tdbg.Columns(e.ColIndex).Text = "0"
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_StageName
                tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
            Case COL_DepartmentID, COL_ProductID
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_DepartmentID).Text, tdbg.Columns(COL_ProductID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
        End Select
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_DepartmentID
                If tdbg(e.Row, COL_DepartmentID).ToString <> tdbg(e.Row, COL_OldDepartmentID).ToString Then
                    e.CellStyle.ForeColor = Color.Red
                End If
            Case COL_TeamID
                If tdbg(e.Row, COL_TeamID).ToString <> tdbg(e.Row, COL_OldTeamID).ToString Then
                    e.CellStyle.ForeColor = Color.Red
                End If
            Case COL_EmpGroupID
                If tdbg(e.Row, COL_EmpGroupID).ToString <> tdbg(e.Row, COL_OldEmpGroupID).ToString Then
                    e.CellStyle.ForeColor = Color.Red
                End If
            Case COL_EmployeeID
                If tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible AndAlso tdbg(e.Row, COL_EmployeeID).ToString <> tdbg(e.Row, COL_OldEmployeeID).ToString Then
                    e.CellStyle.ForeColor = Color.Red
                End If
            Case COL_StageName
                If tdbg(e.Row, COL_StageID).ToString <> tdbg(e.Row, COL_OldStageID).ToString Then
                    e.CellStyle.ForeColor = Color.Red
                End If
        End Select
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 Then
            Select Case e.ColIndex
                Case COL_DepartmentID
                    e.CellTip = IIf(gbUnicode, rL3("Gia_tri_cu"), ConvertUnicodeToVni(rL3("Gia_tri_cu"))).ToString & ": " & tdbg(e.Row, COL_OldDepartmentID).ToString
                Case COL_TeamID
                    e.CellTip = IIf(gbUnicode, rL3("Gia_tri_cu"), ConvertUnicodeToVni(rL3("Gia_tri_cu"))).ToString & ": " & tdbg(e.Row, COL_OldTeamID).ToString
                Case COL_EmpGroupID
                    e.CellTip = IIf(gbUnicode, rL3("Gia_tri_cu"), ConvertUnicodeToVni(rL3("Gia_tri_cu"))).ToString & ": " & tdbg(e.Row, COL_OldEmpGroupID).ToString
                Case COL_EmployeeID
                    e.CellTip = IIf(gbUnicode, rL3("Gia_tri_cu"), ConvertUnicodeToVni(rL3("Gia_tri_cu"))).ToString & ": " & tdbg(e.Row, COL_OldEmployeeID).ToString
                Case COL_StageName
                    e.CellTip = IIf(gbUnicode, rL3("Gia_tri_cu"), ConvertUnicodeToVni(rL3("Gia_tri_cu"))).ToString & ": " & tdbg(e.Row, COL_OldStageID).ToString
                Case Else
                    e.CellTip = ""
            End Select
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg, e) Then
            Select Case tdbg.Col
                Case COL_ProductID
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
            End Select
        End If
        '*****
        If e.KeyCode = Keys.F7 Then
            If tdbg.Col = COL_DepartmentID Then
                HotKeyF7(tdbg, iColumns)
            ElseIf tdbg.Col = COL_TeamID Then
                HotKeyF7(tdbg, iColumns1)
            ElseIf tdbg.Col = COL_EmpGroupID Then
                HotKeyF7(tdbg, iColumns4)
            ElseIf tdbg.Col = COL_ProductID Then
                HotKeyF7(tdbg, iColumns2)
            ElseIf tdbg.Col = COL_StageName Then
                HotKeyF7(tdbg, iColumns3)
            Else
                HotKeyF7(tdbg)
                resetgrid()
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            resetgrid()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg)
        ElseIf e.KeyCode = Keys.Enter AndAlso tdbg.Col = iLastCol Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg, COL_DepartmentID, e, 0)
        End If

        HotKeyDownGrid(e, tdbg, COL_DepartmentID)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        'Menu Tach so luong chi sang khi dung tai cac cot So luong co gia tri >0
        Select Case tdbg.Col
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                mnuSplit.Enabled = tdbg.RowCount > 0 AndAlso Number(tdbg(tdbg.Row, tdbg.Col)) > 0
            Case COL_Attachment
                If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_Attachment).Button = False
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_Attachment).Button = True
                End If
            Case Else
                mnuSplit.Enabled = False
        End Select

        ''--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_TeamID
                ReloadTdbdTeamID()
            Case COL_EmpGroupID
                ReloadTdbdEmpGroupID()
            Case COL_EmployeeID
                ReloadTdbdEmployeeID()
            Case COL_StageName
                LoadtdbdStageID(tdbg(tdbg.Row, COL_ProductID).ToString)
        End Select
    End Sub

    Private Sub tdbg_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If tdbg.AllowUpdate = False Then Exit Sub
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked Then Exit Sub
        Select Case tdbg.Col

            Case COL_ProductID
                If clsFilterDropdown.IsNewFilter = False Then Exit Sub
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
            Case COL_BUTTON
                If tdbg.RowCount = 0 Then Exit Sub
                If Not AllowSelectEmp() Then Exit Sub
                Dim frm As New D45F2070
                frm.sProSalTransID = L3String(tdbg.Columns(COL_ProSalTransID).Value)
                If ReturnValueC1Combo(tdbcDepartmentID) = "%" Then
                    frm.sDepartmentID = L3String(tdbg.Columns(COL_DepartmentID).Value)
                Else
                    frm.sDepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                End If
                If ReturnValueC1Combo(tdbcTeamID) = "%" Then
                    frm.sTeamID = L3String(tdbg.Columns(COL_TeamID).Value)
                Else
                    frm.sTeamID = ReturnValueC1Combo(tdbcTeamID)
                End If

                frm.sProductVoucherID = _productVoucherID
                If _FormState = EnumFormState.FormView Then
                    frm.FormState = EnumFormState.FormView
                Else
                    frm.FormState = EnumFormState.FormEdit
                End If
                frm.ShowDialog()
                frm.Dispose()
                If frm.bSaved Then
                    SetValueForColEmployeeList(tdbg.Row)
                    bUpdated = True
                End If
            Case COL_Attachment
                If tdbg.Splits(SPLIT1).DisplayColumns(COL_Attachment).Button = False Then Exit Sub
               
                If tdbg.Columns(COL_DepartmentID).Text = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DepartmentID
                    tdbg.Focus()
                    Exit Sub
                End If
                 If tdbg.Columns(COL_ProductID).Text = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_san_pham"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_ProductID
                    tdbg.Focus()
                    Exit Sub
                End If
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "TableName", "D45T2001")
                SetProperties(arrPro, "Key1ID", tdbg.Columns(COL_DepartmentID).Text)
                SetProperties(arrPro, "Key2ID", tdbg.Columns(COL_ProductID).Text)
                SetProperties(arrPro, "Key3ID", txtProductVoucherNo.Text)
                SetProperties(arrPro, "Status", L3Byte(IIf(_FormState = EnumFormState.FormView, 0, 1)))
                'SetProperties(arrPro, "bNewDatabase", TRUE/ FALSE)'Lưu database mới ATT, không phải database hiện tại. Không dùng nữa mà theo thiết lập D91T0025
                CallFormShowDialog("D91D0340", "D91F4010", arrPro)
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_DepartmentID).Text, tdbg.Columns(COL_ProductID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
        End Select
    End Sub
#End Region

    Dim sOldDepartmentID As String = ""
    Private Sub ReloadTdbdTeamID()
        Dim sDepartment As String = ""
        If CbVal(tdbcDepartmentID) <> "%" Then
            sDepartment = CbVal(tdbcDepartmentID)
        Else
            sDepartment = tdbg(tdbg.Row, COL_DepartmentID).ToString
        End If
        If sOldDepartmentID <> "" AndAlso sOldDepartmentID = sDepartment Then Exit Sub
        LoadtdbdTeamID(tdbdTeamID, dtTeamID_Detail, ReturnValueC1Combo(tdbcBlockID), sDepartment, gbUnicode)
        sOldDepartmentID = sDepartment
    End Sub

    Dim sOldTeam As String = ""
    Private Sub ReloadTdbdEmpGroupID()
        Dim sDepartment As String = "", sTeam As String = ""
        If CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) = "%" Then
            sDepartment = CbVal(tdbcDepartmentID)
            sTeam = tdbg(tdbg.Row, COL_TeamID).ToString()
        ElseIf CbVal(tdbcDepartmentID) = "%" And CbVal(tdbcTeamID) <> "%" Then
            sDepartment = tdbg(tdbg.Row, COL_DepartmentID).ToString
            sTeam = CbVal(tdbcTeamID)
        ElseIf CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) <> "%" Then
            sDepartment = CbVal(tdbcDepartmentID)
            sTeam = CbVal(tdbcTeamID)
        Else
            sDepartment = tdbg(tdbg.Row, COL_DepartmentID).ToString
            sTeam = tdbg(tdbg.Row, COL_TeamID).ToString()
        End If
        If sOldTeam <> "" AndAlso sOldTeam = sDepartment & sTeam Then Exit Sub
        LoadtdbdEmpGroupID(sDepartment, sTeam)
        sOldTeam = sDepartment & sTeam
    End Sub

    Dim sOldTeam2 As String = ""
    Dim bOldIsEmpStrengthen As Boolean
    Private Sub ReloadTdbdEmployeeID()
        Dim sDepartment As String = "", sTeam As String = "", sEmpGroupID As String = tdbg(tdbg.Row, COL_EmpGroupID).ToString, bIsEmpStrengthen As Boolean = L3Bool(tdbg(tdbg.Row, COL_IsEmpStrengthen))
        If CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) = "%" Then
            sDepartment = CbVal(tdbcDepartmentID)
            sTeam = tdbg(tdbg.Row, COL_TeamID).ToString()
        ElseIf CbVal(tdbcDepartmentID) = "%" And CbVal(tdbcTeamID) <> "%" Then
            sDepartment = tdbg(tdbg.Row, COL_DepartmentID).ToString
            sTeam = CbVal(tdbcTeamID)
        ElseIf CbVal(tdbcDepartmentID) <> "%" And CbVal(tdbcTeamID) <> "%" Then
            sDepartment = CbVal(tdbcDepartmentID)
            sTeam = CbVal(tdbcTeamID)
        Else
            sDepartment = tdbg(tdbg.Row, COL_DepartmentID).ToString
            sTeam = tdbg(tdbg.Row, COL_TeamID).ToString()
        End If
        If sOldTeam2 <> "" AndAlso sOldTeam2 = sDepartment & sTeam & sEmpGroupID AndAlso bOldIsEmpStrengthen = bIsEmpStrengthen Then Exit Sub
        LoadtdbdEmployeeID(sDepartment, sTeam, sEmpGroupID, bIsEmpStrengthen)
        sOldTeam2 = sDepartment & sTeam & sEmpGroupID
        bOldIsEmpStrengthen = bIsEmpStrengthen
    End Sub

    Dim bSelect As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        tdbg.UpdateData()
        Select Case iCol
            Case COL_DepartmentID
                CopyColumnArr(tdbg, iCol, iColumns)
            Case COL_TeamID, COL_EmployeeID, COL_StageName, COL_EmpGroupID
                'K Headclick cot phu thuoc
            Case COL_IsEmpStrengthen
                L3HeadClick(tdbg, iCol, bSelect)
            Case COL_ProductID
                CopyColumnArr(tdbg, iCol, iColumns2)
                CalculatorProductNameFromSpecs(iCol)
            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
                CalculatorProductNameFromSpecs(tdbg.Row)
            Case Else
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
                resetgrid()
        End Select

    End Sub

    Private Function AllowSelectEmp() As Boolean
        If tdbg(tdbg.Row, COL_DepartmentID).ToString = "" AndAlso CbVal(tdbcDepartmentID) = "%" Then
            D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_DepartmentID
            tdbg.Bookmark = tdbg.Row
            Return False
        End If
        Return True
    End Function

    Private Function AllowSave() As Boolean
        Dim bAllowSave As Boolean = False

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DepartmentID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DepartmentID
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible AndAlso tdbg(i, COL_EmployeeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_nhan_vien"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_EmployeeID
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_ProductID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_san_pham"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ProductID
                tdbg.Bookmark = i
                Return False
            End If
            If _createVoucherNo_D45F2020 AndAlso bAllowSave = False Then
                If tdbg(i, COL_DepartmentID).ToString <> tdbg(i, COL_OldDepartmentID).ToString OrElse tdbg(i, COL_TeamID).ToString <> tdbg(i, COL_OldTeamID).ToString OrElse _
                             tdbg(i, COL_EmpGroupID).ToString <> tdbg(i, COL_OldEmpGroupID).ToString OrElse (tdbg.Splits(0).DisplayColumns(COL_EmployeeID).Visible AndAlso tdbg(i, COL_EmployeeID).ToString <> tdbg(i, COL_OldEmployeeID).ToString) OrElse tdbg(i, COL_StageID).ToString <> tdbg(i, COL_OldStageID).ToString Then
                    If D99C0008.MsgAsk(rL3("Ban_da_thay_doi_thong_tin_so_voi_phieu_CCSP_chua_xu_ly") & Space(1) & rL3("MSG000028")) = Windows.Forms.DialogResult.No Then
                        tdbg.Focus()
                        If tdbg(i, COL_DepartmentID).ToString <> tdbg(i, COL_OldDepartmentID).ToString Then
                            tdbg.SplitIndex = SPLIT0
                            tdbg.Col = COL_DepartmentID
                        ElseIf tdbg(i, COL_TeamID).ToString <> tdbg(i, COL_OldTeamID).ToString Then
                            tdbg.SplitIndex = SPLIT0
                            tdbg.Col = COL_TeamID
                        ElseIf tdbg(i, COL_EmpGroupID).ToString <> tdbg(i, COL_OldEmpGroupID).ToString Then
                            tdbg.SplitIndex = SPLIT0
                            tdbg.Col = COL_EmpGroupID
                        ElseIf tdbg(i, COL_EmployeeID).ToString <> tdbg(i, COL_OldEmployeeID).ToString Then
                            tdbg.SplitIndex = SPLIT0
                            tdbg.Col = COL_EmployeeID
                        Else
                            tdbg.SplitIndex = SPLIT1
                            tdbg.Col = COL_StageName
                        End If

                        tdbg.Bookmark = i
                        Return False
                    Else
                        bAllowSave = True
                    End If
                End If
            End If
        Next
        Return True
    End Function

    'iCol chi co y nghia khi chon mnu Tach so luong vi co nhieu cot So luong
    Private Sub InsertRow(ByVal dtAdd As DataTable, Optional ByVal bSplit As Boolean = False, Optional ByVal iColIndex As Integer = -1)
        tdbg.UpdateData()

        Try
            Dim bm As Integer = tdbg.Row

            'Gan gtri dong dau tien duoc tach
            If dtAdd.Rows.Count > 0 Then
                If bSplit = False Then 'Chon quy trinh
                    tdbg(tdbg.Row, COL_StageID) = dtAdd.Rows(0).Item("StageID").ToString
                    tdbg(tdbg.Row, COL_StageName) = dtAdd.Rows(0).Item("StageName").ToString
                Else 'Tach so luong
                    tdbg(tdbg.Row, iColIndex) = dtAdd.Rows(0).Item("SplitQTY").ToString
                End If
            End If

            'Gan gtri nhung dong du lieu con lai
            For i As Integer = 1 To dtAdd.Rows.Count - 1
                Dim dr As DataRow = dtGrid.NewRow
                dtGrid.Rows.InsertAt(dr, bm + i)
                dr.ItemArray = dtGrid.Rows(tdbg.Row).ItemArray

                'k copy gia tri TransID
                dr.Item(tdbg.Columns(COL_TransID).DataField) = ""

                If bSplit = False Then 'Chon quy trinh
                    dr.Item(tdbg.Columns(COL_StageID).DataField) = dtAdd.Rows(i).Item("StageID").ToString
                    dr.Item(tdbg.Columns(COL_StageName).DataField) = dtAdd.Rows(i).Item("StageName").ToString
                Else 'Tach so luong
                    dr.Item(tdbg.Columns(iColIndex).DataField) = dtAdd.Rows(i).Item("SplitQTY").ToString
                End If
            Next

            dtGrid.AcceptChanges()
            tdbg.UpdateData()
            tdbg.Focus()
            tdbg.SplitIndex = 1
            If bSplit = False Then
                tdbg.Col = COL_StageName
            Else
                tdbg.Col = iColIndex
            End If
            tdbg.Row = bm

        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyShiftInsert: " & ex.Message)
        End Try
    End Sub

#Region "Menu"
    Private Sub mnuSplit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSplit.Click
        tdbg.UpdateData()
        Dim f As New D45F2008
        With f
            .sProductID = tdbg.Columns(COL_ProductID).Text
            .sProductName = tdbg.Columns(COL_ProductName).Text
            .Quantity = tdbg.Columns(tdbg.Col).Text
            .ShowDialog()
            If .bSaved Then InsertRow(.dtGrid.DefaultView.ToTable, True, tdbg.Col)
            .Dispose()
        End With
    End Sub

    Private Sub mnuSelect_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSelect.Click
        tdbg.UpdateData()
        Dim f As New D45F2009
        With f
            .sProductID = tdbg.Columns(COL_ProductID).Text
            .sProductName = tdbg.Columns(COL_ProductName).Text
            .ShowDialog()
            If .bSaved Then InsertRow(.dtGrid.DefaultView.ToTable)
            .Dispose()
        End With
    End Sub
#End Region

    Private Sub btnHotKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID = "D45F2007"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _createVoucherNo_D45F2020 = False

        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD45T2001.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T2001s.ToString & vbCrLf)

        If _sMethod = "1" Then
            sSQL.Append(SQLStoreD45P2070.ToString) 'ID 107229 10.05.2018
        End If


        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            arrDelete = ""
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
    '# Title: SQLStoreD45P2070
    '# Created User: Kim Long
    '# Created Date: 10/05/2018 09:20:08
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2070() As String
        Dim sSQL As String = ""
        sSQL &= ("-- EXEC D45P2070" & vbCrLf)
        sSQL &= "Exec D45P2070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P2071() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do so luong nhan vien" & vbCrLf)
        sSQL &= "Exec D45P2071 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_DepartmentID).Value) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TeamID).Value) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ProSalTransID).Text) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'TransID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2007
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/07/2011 02:10:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2007() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2007 "
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(CbVal(tdbcGroupProductID)) 'GroupProductID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2001
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/07/2011 03:36:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2001"
        sSQL &= " Where "
        sSQL &= "ProductVoucherID = " & SQLString(_productVoucherID) & " And DepartmentID Like " & SQLString(CbVal(tdbcDepartmentID)) & " And TeamID Like " & SQLString(CbVal(tdbcTeamID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2070
    '# Created User: Kim Long
    '# Created Date: 18/05/2018 03:54:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2070(Optional sArrDel As String = "") As String
        Dim sSQL As String = ""
        sSQL &= ("-- Del" & vbCrLf)
        sSQL &= "Delete From D45T2070"
        If sArrDel <> "" Then
            sSQL &= " Where ProSalTransID IN (" & sArrDel & ")"
        Else
            sSQL &= " Where ProSalTransID =" & SQLString(tdbg.Columns(COL_ProSalTransID).Text)
        End If

        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2001s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/08/2011 02:35:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim iCount As Integer = 0 'Đếm số dòng Insert
        Dim sTransID As String = ""
        Dim iCountIGE As Integer = 0
        Dim iFirstIGE As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            'Sinh IGE cho TransID
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGENewS("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGE, iFirstIGE)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D45T2001(")
            sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
            sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
            sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, ")
            sSQL.Append("Quantity06, Quantity07, Quantity08, Quantity09, Quantity10, ")
            sSQL.Append("Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, ")
            sSQL.Append("Quantity16, Quantity17, Quantity18, Quantity19, Quantity20, ")
            sSQL.Append("IsLocked, TransID, Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, ")
            sSQL.Append("Spec07ID, Spec08ID, Spec09ID, Spec10ID, CreateUserID, CreateDate, LastModifyUserID, ")
            sSQL.Append("LastModifyDate, OrderNo, EmpGroupID, PieceworkGroupID, IsEmpStrengthen ,")
            sSQL.Append("RefSalProduct01, RefSalProduct02, RefSalProduct03, RefSalProduct04, RefSalProduct05, MachineID,NotesU, ProSalTransID, GroupProductID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID, varchar[50], NOT NULL
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

            sSQL.Append(SQLNumber(0) & COMMA) 'IsLocked, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL

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
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNo, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmpGroupID)) & COMMA) 'EmpGroupID, varchar[20], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsEmpStrengthen)) & COMMA) 'IsEmpStrengthen, varchar[20], NOT NULL
            'ID 88674 13.07.2016
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefSalProduct01), True, True) & COMMA) 'RefSalProduct01, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefSalProduct02), True, True) & COMMA) 'RefSalProduct02, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefSalProduct03), True, True) & COMMA) 'RefSalProduct03, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefSalProduct04), True, True) & COMMA) 'RefSalProduct04, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_RefSalProduct05), True, True) & COMMA) 'RefSalProduct05, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_MachineID)) & COMMA) 'RefSalProduct05, varchar[20], NOT NULL
            'ID 94408 20.01.2017
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Notes), True, True) & COMMA) 'NoteU, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProSalTransID)) & COMMA) 'ProSalTransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(ReturnValueC1Combo(tdbcGroupProductID, "GroupProductID"))) 'GroupProductID, varchar[20], NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate(iCol, row)
        ElseIf dr.Length = 1 Then
            If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                Dim dr1 As DataRow = dtGrid.NewRow
                dtGrid.Rows.InsertAt(dr1, tdbg.Row)
                SetDefaultValues(tdbg, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
                tdbg.Bookmark = tdbg.Row
            End If
            AfterColUpdate(iCol, dr(0))
        Else
            For Each row As DataRow In dr
                If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                    Dim dr1 As DataRow = dtGrid.NewRow
                    dtGrid.Rows.InsertAt(dr1, tdbg.Row)
                    SetDefaultValues(tdbg, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
                    tdbg.Bookmark = tdbg.Row
                Else
                    tdbg.Row = iRow
                    tdbg.Bookmark = iRow
                End If
                AfterColUpdate(iCol, row)
                tdbg.UpdateData()
                iRow += 1
            Next
            tdbg.Focus()
        End If
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr As DataRow)
        'Gán lại các giá trị phụ thuộc vào Dropdown
        Select Case iCol
            Case COL_ProductID
                tdbg.Columns(COL_StageID).Text = ""
                tdbg.Columns(COL_StageName).Text = ""

                If dr Is Nothing OrElse dr.Item("ProductID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_OProductName).Text = ""
                Else
                    tdbg.Columns(COL_ProductID).Text = dr.Item("ProductID").ToString
                    tdbg.Columns(COL_ProductName).Text = dr.Item("ProductName").ToString
                    tdbg.Columns(COL_OProductName).Text = tdbg.Columns(COL_ProductName).Text
                End If
                CalculatorProductNameFromSpec()
                 tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_DepartmentID).Text, tdbg.Columns(COL_ProductID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
        End Select
        If tdbg.Columns(COL_ProSalTransID).Text = "" Then
            Dim sProSalTransID As String = CreateIGE("D45T2007", "ProSalTransID", "45", "PS", gsStringKey)
            tdbg.Columns(COL_ProSalTransID).Value = sProSalTransID
            If arrDelete <> "" Then arrDelete &= ","
            arrDelete &= SQLString(sProSalTransID)
        End If
        UpdataDataGrid()
    End Sub

    Private Sub tdbg_OnAddNew(sender As Object, e As EventArgs) Handles tdbg.OnAddNew
        If tdbg.Columns(COL_ProSalTransID).Text = "" Then
            Dim sProSalTransID As String = CreateIGE("D45T2007", "ProSalTransID", "45", "PS", gsStringKey)
            tdbg.Columns(COL_ProSalTransID).Value = sProSalTransID
            If arrDelete <> "" Then arrDelete &= ","
            arrDelete &= SQLString(sProSalTransID)
        End If
    End Sub

    Private Sub SetValueForColEmployeeList(ByVal iRow As Integer)
        Dim sSQL As String = SQLStoreD45P2071()
        Dim dtData As DataTable = ReturnDataTable(sSQL)
        If dtData.Rows.Count > 0 Then
            tdbg(iRow, COL_EmployeeList) = Number(dtData.Rows(0)("EmployeeList"))
        End If
        dtData.Dispose()
    End Sub

    #Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList 'Mảng Detail
    Dim dtCaptionCols As DataTable
    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_DepartmentID, COL_EmployeeID, COL_ProductID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
        End If
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub btnF12_Click( sender As Object,  e As EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height))
        Me.Controls.Add(usrOption)
        usrOption.Parent = grpDetail
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

#End Region


End Class