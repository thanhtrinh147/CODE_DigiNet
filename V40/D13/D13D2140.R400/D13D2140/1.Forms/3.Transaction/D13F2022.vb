'#-------------------------------------------------------------------------------------
'# Created Date: 10/05/2007 2:57:34 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 28/05/2010 -- ID33138 ->Tìm kiếm kiểu mới_ko đổ store khi tìm kiếm
'# Modify User: Thanh Huyền
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System
'Imports System.Drawing.Color

Public Class D13F2022
    Private _blockID As String
    Private _sSalaryObjectID As String = ""
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg"
    Private Const COL_EmployeeID As Integer = 0        ' Mã NV
    Private Const COL_FullName As Integer = 1          ' Họ và tên
    Private Const COL_BlockID As Integer = 2           ' Khối
    Private Const COL_BlockName As Integer = 3         ' Tên khối
    Private Const COL_DepartmentID As Integer = 4      ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6            ' Tổ nhóm 
    Private Const COL_TeamName As Integer = 7          ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8        ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 9      ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 10           ' Chức vụ
    Private Const COL_DutyName As Integer = 11         ' Tên chức vụ
    Private Const COL_WorkID As Integer = 12           ' Công việc
    Private Const COL_WorkName As Integer = 13         ' Tên công việc
    Private Const COL_BirthDate As Integer = 14        ' Ngày sinh
    Private Const COL_SexName As Integer = 15          ' Giới tính
    Private Const COL_DateJoined As Integer = 16       ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 17         ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 18              ' Tuổi
    Private Const COL_StatusID As Integer = 19         ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 20       ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 21 ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 22    ' Mã NV phụ
    Private Const COL_BASE01 As Integer = 23           ' Mức lương 1
    Private Const COL_BASE02 As Integer = 24           ' Mức lương 2
    Private Const COL_BASE03 As Integer = 25           ' Mức lương 3
    Private Const COL_BASE04 As Integer = 26           ' Mức lương 4
    Private Const COL_CE01 As Integer = 27             ' Hệ số lương 1
    Private Const COL_CE02 As Integer = 28             ' Hệ số lương 2
    Private Const COL_CE03 As Integer = 29             ' Hệ số lương 3
    Private Const COL_CE04 As Integer = 30             ' Hệ số lương 4
    Private Const COL_CE05 As Integer = 31             ' Hệ số lương 5
    Private Const COL_CE06 As Integer = 32             ' Hệ số lương 6
    Private Const COL_CE07 As Integer = 33             ' Hệ số lương 7
    Private Const COL_CE08 As Integer = 34             ' Hệ số lương 8
    Private Const COL_CE09 As Integer = 35             ' Hệ số lương 9
    Private Const COL_CE10 As Integer = 36             ' Hệ số lương 10
    Private Const COL_AbsentTypeFrom As Integer = 37   ' AbsentTypeFrom
    Private Const COL_AbsentTypeTo As Integer = 38     ' AbsentTypeTo
    Private Const COL_TransID As Integer = 39          ' TransID
    Private Const COL_AbsentTransID As Integer = 40    ' AbsentTransID
    Private Const COL_CreateUserID As Integer = 41     ' CreateUserID
    Private Const COL_CreateDate As Integer = 42       ' CreateDate
    Private Const COL_IsSub As Integer = 43            ' HSL phụ
    Private Const COL_ValidDateFrom As Integer = 44    ' Ngày chấm công (Từ)
    Private Const COL_ValidDateTo As Integer = 45      ' Ngày chấm công (Đến)
    Private Const COL_SalEmpGroupName As Integer = 46  ' Nhóm lương
    Private Const COL_Permission As Integer = 47       ' Permission
    Private Const COL_IsUpdate As Integer = 48         ' IsUpdate

    Private Const COL_Total As Integer = 48 'Vị trí của cột cuối cùng trên lưới
    Private Const SplitCount As Integer = 1
#End Region


#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
#End Region

    Private bBA As SALBA
    Private bCE As SALCE
    Private sAbsentTypeID As String
    Private nTotalAbsentType As Int32

    Private xCheckNum(1000) As Int32 'cho biết cột của grid (động) phải kiểu số k
    Private xCheckMode(1000) As Int32 'cho biết cột của grid load dropdown dạng nào (2 dạng)
    Private xNumberFormat(1000) As String ' cho biết định dạng format số lẻ của cột động
    Private iCountCol As Integer = 0
    Private xFlag(1000) As Int32
    Private xCellTip(1000) As Int32
    Private AbsentTypeID(1000) As String 'Kiểu ngày công: cột ẩn
    Private dtMain As New DataTable
    Private dtType, dtCheck As DataTable
    Private dtAbsentType As New DataTable
    Private sValue1 As String
    Dim sEnabledMenu As String = "1"

    Private IsTransferAbsent As Boolean = False
    Dim dtTeamID As DataTable

#Region "Properties"

    Private _transTypeID As String = ""
    Public Property TransTypeID() As String
        Get
            Return _transTypeID
        End Get
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Private _AbsentVoucherID As String = ""
    Public Property AbsentVoucherID() As String
        Get
            Return _AbsentVoucherID
        End Get
        Set(ByVal Value As String)
            If _AbsentVoucherID = Value Then
                _AbsentVoucherID = ""
                Return
            End If
            _AbsentVoucherID = Value
        End Set
    End Property

    Private _AbsentVoucherNo As String = ""
    Public Property AbsentVoucherNo() As String
        Get
            Return _AbsentVoucherNo
        End Get
        Set(ByVal Value As String)
            If _AbsentVoucherNo = Value Then
                _AbsentVoucherNo = ""
                Return
            End If
            _AbsentVoucherNo = Value
        End Set
    End Property

    Private _DepartmentID As String = ""
    Public Property DepartmentID() As String
        Get
            Return _DepartmentID
        End Get
        Set(ByVal Value As String)
            If _DepartmentID = Value Then
                _DepartmentID = ""
                Return
            End If
            _DepartmentID = Value
        End Set
    End Property

    Private _TeamID As String = ""
    Public Property TeamID() As String
        Get
            Return _TeamID
        End Get
        Set(ByVal Value As String)
            If _TeamID = Value Then
                _TeamID = ""
                Return
            End If
            _TeamID = Value
        End Set
    End Property

    Private _EntryDate As DateTime = Now
    Public Property EntryDate() As DateTime
        Get
            Return _EntryDate
        End Get
        Set(ByVal Value As DateTime)
            _EntryDate = Value
        End Set
    End Property

    Private _Remark As String = ""
    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal Value As String)
            If _Remark = Value Then
                _Remark = ""
                Return
            End If
            _Remark = Value
        End Set
    End Property

    Private _NewPayrollVoucherID As String = ""
    Public Property NewPayrollVoucherID() As String
        Get
            Return _NewPayrollVoucherID
        End Get
        Set(ByVal Value As String)
            If _NewPayrollVoucherID = Value Then
                _NewPayrollVoucherID = ""
                Return
            End If
            _NewPayrollVoucherID = Value
        End Set
    End Property

    Private _OldPayrollVoucherID As String = ""
    Public Property OldPayrollVoucherID() As String
        Get
            Return _OldPayrollVoucherID
        End Get
        Set(ByVal Value As String)
            If _OldPayrollVoucherID = Value Then
                _OldPayrollVoucherID = ""
                Return
            End If
            _OldPayrollVoucherID = Value
        End Set
    End Property

    Private _payrollVoucherNo As String = ""
    Public Property PayrollVoucherNo() As String
        Get
            Return _payrollVoucherNo
        End Get
        Set(ByVal Value As String)
            _payrollVoucherNo = value
        End Set
    End Property

    Private _voucherDate As DateTime = Now()
    Public Property VoucherDate() As DateTime
        Get
            Return _voucherDate
        End Get
        Set(ByVal Value As DateTime)
            _voucherDate = value
        End Set
    End Property


    Public WriteOnly Property sSalaryObjectID As String
        Set(ByVal Value As String)
            _sSalaryObjectID = Value
        End Set
    End Property


    Public WriteOnly Property BlockID As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property



    Private _description As String = ""
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = value
        End Set
    End Property

    Private _calFromF2020 As Boolean = False
    Public WriteOnly Property CalFromF2020() As Boolean
        Set(ByVal Value As Boolean)
            _calFromF2020 = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property
#End Region

    Dim iPerD13F2020 As Integer

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2022_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SaveReg()
    End Sub

    Private Sub D13F2022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            Dim f As New D13F7777
            With f
                .CallShowForm(Me.Name)
                .ShowDialog()
            End With
            'btnHotKey_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.Control And e.KeyCode = Keys.A Then
            mnuListAll_Click(sender, Nothing)
        ElseIf e.Control And e.KeyCode = Keys.F Then
            mnuFind_Click(sender, Nothing)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShow_Click(Nothing, Nothing)
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
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Dim dtMain_First, dtDepartmentID As DataTable
    Private gbEnabledUseFind As Boolean = False

    Private Sub D13F2022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _formState
        SetShortcutPopupMenu(Me.C1CommandHolder)
        CheckPermission()
        InputbyUnicode(Me, gbUnicode)
        'thiết lập nhấn Enter thì xuống dòng
        '   tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown

        'If Not IsAllowEdit_D13F2022(_AbsentVoucherID) Then
        '    btnInheritData.Enabled = False
        '    btnSave.Enabled = False
        '    sEnabledMenu = "0"
        'End If
        If Not CheckStore(SQLStoreD13P5555) Then
            btnInheritData.Enabled = False
            btnSave.Enabled = False
            ' update  10/6/2013 id 56597
            btnEdit.Enabled = False
            _FormState = EnumFormState.FormView
            sEnabledMenu = "0"
        End If
        '************
        btnHotKey.Left = btnInheritData.Left
        btnInheritData.Left = btnImportExcel.Left
        '************
        tdbcBlockID.Enabled = D13Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D13Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D13Systems.IsUseBlock
        Loadlanguage()
        SetBackColorObligatory()
        Me.Cursor = Cursors.WaitCursor
        LoadTDBCombo()

        'ID 
        'If _DepartmentID <> "%" Then
        '    tdbcDepartmentID.SelectedValue = _DepartmentID
        '    ReadOnlyControl(tdbcBlockID)
        '    ReadOnlyControl(tdbcDepartmentID)
        'End If

        'tdbcBlockID.SelectedValue = _blockID
        'tdbcDepartmentID.SelectedValue = _DepartmentID
        tdbcBlockID.SelectedValue = IIf(_blockID = "", "%", _blockID).ToString
        tdbcDepartmentID.SelectedValue = IIf(_DepartmentID = "", "%", _DepartmentID).ToString
        tdbcTeamID.SelectedValue = IIf(_TeamID = "", "%", _TeamID).ToString

        LoadDropDownDataTable_Mode0()
        LoadDropDownDataTable_Mode1()
        tdbg_NumberFormat()
        tdbg_LockedColumns()

        gbEnabledUseFind = False

        LoadMaster()
        SQLD13T9000()
        ShowColumns()
        '        LoadData()
        AddField()
        btnFilter_Click(Nothing, Nothing)

        CheckMenu("D13F2020", C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True, , "D13F5602")
        Dim FlagEditMode As Boolean = _FormState <> EnumFormState.FormView
        If _calFromF2020 Then
            FlagEditMode = False
        End If
        LoadEditView(FlagEditMode) ' update  10/6/2013 id 56597
        tdbg.Font = FontUnicode(gbUnicode)

        LoadUsercontrol()
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft, COL_AbsentTypeTo, COL_ValidDateFrom, COL_ValidDateTo)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Dim dtCaptionCols As DataTable
    Private Sub LoadUsercontrol()
        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_EmployeeID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************
    End Sub

    Private Sub RemoveColumn_dtMain(ByVal dtMain As DataTable)
        Dim iColumnsCount As Integer = dtMain.Columns.Count - 1
        For i As Integer = iColumnsCount To 0 Step -1
            If IsExistDataField(tdbg, dtMain.Columns(i).ColumnName) = False Then dtMain.Columns.RemoveAt(i)
        Next
    End Sub

    Private Sub CheckPermission()
        iPerD13F2020 = ReturnPermission("D13F2020")
        btnSave.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
        btnEdit.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
        btnMonthlyPayrollFiles.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
        btnImportExcel.Enabled = ReturnPermission("D13F5602") >= 2
    End Sub

    Dim bAddEnabled As Boolean = False
    Dim bDeleteEnabled As Boolean = False
    Private Sub CheckMenuOther()
        bAddEnabled = mnuAdd.Enabled
        bDeleteEnabled = mnuDelete.Enabled
        CheckPermissionColGrid()
    End Sub

    Private Sub CheckPermissionColGrid()
        If tdbg.RowCount > 0 Then
            'Update 07/03/2012: Incident 43636 Kiểm tra thêm cột quyền trên lưới cho các menu: Thêm, Xóa
            Dim iPer As Byte = L3Byte(tdbg.Columns(COL_Permission).Text)

            mnuAdd.Enabled = bAddEnabled And (iPer >= 2)
            mnuDelete.Enabled = bDeleteEnabled And (iPer = 4)
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_FullName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateLeft).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Age).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AttendanceCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_IsSub).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ValidDateFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ValidDateTo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SalEmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub


    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Base01).NumberFormat = Format(tdbg.Columns(COL_Base01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_Base02).NumberFormat = Format(tdbg.Columns(COL_Base02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_Base03).NumberFormat = Format(tdbg.Columns(COL_Base03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_Base04).NumberFormat = Format(tdbg.Columns(COL_Base04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE01).NumberFormat = Format(tdbg.Columns(COL_CE01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE02).NumberFormat = Format(tdbg.Columns(COL_CE02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE03).NumberFormat = Format(tdbg.Columns(COL_CE03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE04).NumberFormat = Format(tdbg.Columns(COL_CE04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE05).NumberFormat = Format(tdbg.Columns(COL_CE05).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE06).NumberFormat = Format(tdbg.Columns(COL_CE06).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE07).NumberFormat = Format(tdbg.Columns(COL_CE07).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE08).NumberFormat = Format(tdbg.Columns(COL_CE08).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE09).NumberFormat = Format(tdbg.Columns(COL_CE09).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_CE10).NumberFormat = Format(tdbg.Columns(COL_CE10).Text, D13Format.DefaultNumber2)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        sSQL = "SELECT 	DISTINCT T1.DepartmentID as DepartmentID, DepartmentName" & sUnicode & " as DepartmentName, T2.BlockID, T2.DepDisplayOrder, 1 as DisplayOrder " & vbCrLf
        sSQL &= "FROM 	D13T0101 T1  WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0012 T2  WITH (NOLOCK) ON T1.DepartmentID = T2.DepartmentID " & vbCrLf
        sSQL &= "LEFT JOIN	D09T1140 T3  WITH (NOLOCK) ON T3.BlockID = T2.BlockID " & vbCrLf
        sSQL &= "WHERE	T1.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "AND T2.Disabled = 0" & vbCrLf
        sSQL &= "AND PayrollVoucherID = " & SQLString(_OldPayrollVoucherID) & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 	'%' As DepartmentID, " & sLanguage & " As DepartmentName, '%' as BlockID, 0 As DepDisplayOrder, 0 as DisplayOrder " & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder, T2.DepDisplayOrder, DepartmentID"
        dtDepartmentID = ReturnDataTable(sSQL)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)
        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
        tdbcBlockID.SelectedValue = "%"
        LoadTdbcDepartmentID(ComboValue(tdbcBlockID))
        LoadtdbcTeamID("%", "%")
    End Sub

    Private Sub LoadTdbcDepartmentID(ByVal sBlockID As String)
        'If D09Systems.IsUseBlockID Then
        If sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, dtDepartmentID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID = '%' Or BlockID = " & SQLString(sBlockID), True), gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub

    Private Sub LoadtdbcTeamID(ByVal sBlockID As String, ByVal sDepartmentID As String)
        If sBlockID = "%" And sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, dtTeamID.Copy, gbUnicode)
        ElseIf sBlockID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID)), gbUnicode)
        ElseIf sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " BlockID = '%' or BlockID=" & SQLString(sBlockID)), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " (BlockID = '%' or BlockID=" & SQLString(sBlockID) & ") And (DepartmentID='%' or DepartmentID=" & SQLString(sDepartmentID) & ")"), gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub

    Private Sub SQLD13T9000()
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short, Disabled, Type From D13T9000  WITH (NOLOCK) Order By Code"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable
        dt1 = ReturnTableFilter(dt, "Type='SALBA'")
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_Base01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_Base02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_Base03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_BASE04).Caption = dt1.Rows(3).Item("Short").ToString

        For i As Integer = COL_BASE01 To COL_BASE04
            tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(i).Style.Font = FontUnicode(gbUnicode)
        Next

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

        For i As Integer = COL_CE01 To COL_CE10
            tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(i).Style.Font = FontUnicode(gbUnicode)
        Next

    End Sub

    Private Sub ShowColumns()
        tdbg.Splits(0).DisplayColumns(COL_BASE01).Visible = bBA.BASE01
        tdbg.Splits(0).DisplayColumns(COL_BASE02).Visible = bBA.BASE02
        tdbg.Splits(0).DisplayColumns(COL_BASE03).Visible = bBA.BASE03
        tdbg.Splits(0).DisplayColumns(COL_BASE04).Visible = bBA.BASE04
        tdbg.Splits(0).DisplayColumns(COL_CE01).Visible = bCE.CE01
        tdbg.Splits(0).DisplayColumns(COL_CE02).Visible = bCE.CE02
        tdbg.Splits(0).DisplayColumns(COL_CE03).Visible = bCE.CE03
        tdbg.Splits(0).DisplayColumns(COL_CE04).Visible = bCE.CE04
        tdbg.Splits(0).DisplayColumns(COL_CE05).Visible = bCE.CE05
        tdbg.Splits(0).DisplayColumns(COL_CE06).Visible = bCE.CE06
        tdbg.Splits(0).DisplayColumns(COL_CE07).Visible = bCE.CE07
        tdbg.Splits(0).DisplayColumns(COL_CE08).Visible = bCE.CE08
        tdbg.Splits(0).DisplayColumns(COL_CE09).Visible = bCE.CE09
        tdbg.Splits(0).DisplayColumns(COL_CE10).Visible = bCE.CE10
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Nhap_phieu_dieu_chinh_thu_nhap_-_D13F2022") & " " & Me.Name & UnicodeCaption(gbUnicode) 'NhËp phiÕu ¢iÒu chÙnh thu nhËp - D13F2027
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblRemark.Text = rl3("Dien_giai")
        '================================================================ 
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnShow.Text = "&" & rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnFilter.Text = rl3("Lo_c") 'Lọ&c
        btnSave.Text = rl3("_Luu") '&Lưu
        btnEdit.Text = rl3("_Sua") '&Sửa ' update  10/6/2013 id 56597
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnMonthlyPayrollFiles.Text = rl3("_Ho_so_luong_ca_nhan")  'rl3("_Ho_so_luong_thang") '&Hồ sơ lương tháng
        btnInheritData.Text = rl3("Ke_thu_a_du_lieu") 'Kế thừ&a dữ liệu
        btnHotKey.Text = rl3("Phim_nong") 'Phím nóng
        btnChooseEmployee.Text = rl3("_Chon_nhan_vien")
        '================================================================ 
        chkShowEmployee.Text = rl3("Chi_hien_thi_nhung_nhan_vien_co_du_lieu_dieu_chinh_thu_nhap")
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm 
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns("ValidDateFrom").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Tu") & ")"
        tdbg.Columns("ValidDateTo").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Den") & ")"
        tdbg.Columns("IsSub").Caption = rl3("HSL_phu")
        tdbg.Columns("SalEmpGroupName").Caption = rl3("Nhom_luong")

        ' update 15/11/2012 id 51174
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Họ và tên
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("DateLeft").Caption = rl3("Ngay_nghi_viec")
        tdbg.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh")
        tdbg.Columns("WorkID").Caption = rl3("Cong_viec")
        tdbg.Columns("WorkName").Caption = rl3("Ten_cong_viec")
        tdbg.Columns("Age").Caption = rl3("Tuoi")
        tdbg.Columns("StatusID").Caption = rl3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rl3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rl3("Ma_the_cham_cong")
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ

        '================================================================ 
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuExportToExcel.Text = rl3("Xuat__Excel")
        mnuImportData.Text = rl3("Import__du_lieu") 'Import &dữ liệu
        mnuSysInfo.Text = rl3("Lich_su_tac_dong") 'Lịch sử tác động
        mnuAdd.Text = rl3("_Them")
        mnuDelete.Text = rl3("_Xoa")
    End Sub

    Private Sub CreateTableType()
        Dim sSQL As String = ""
        'Load tdbdType
        sSQL = "Select Code, ClassificationID, Type, Description" & UnicodeJoin(gbUnicode) & " as Description, Value" & vbCrLf
        sSQL &= "From D13T0120 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 "
        dtType = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadMaster()
        '        txtAbsentVoucherNo.Text = AbsentVoucherNo
        '        c1dateEntryDate.Value = EntryDate
        txtRemark.Text = Remark
    End Sub

    Private Sub AddField2()
        'Tái tạo lại các cột động trên Table
        For i As Integer = 0 To au.Count - 1
            Dim u As AutoColumn = CType(au(i), AutoColumn)
            dtMain.Columns.Add(u.Name, u.DataType)
        Next i
    End Sub

    Private Sub LoadData()
        Dim sSQL As String
        sSQL = SQLStoreD13P2022("", 0)
        dtMain = ReturnDataTable(sSQL)
        _sSalaryObjectID = "%" 'Set %,chỉ đỗ theo ĐT tính lương lần đầu
        RemoveColumn_dtMain(dtMain)
    End Sub

    'Private Function CreateTableCheck(ByVal sAbsentTypeID As String) As DataTable '(ByVal sAbsentTypeID As String, ByVal DepartmentID As String, ByVal TeamID As String) As DataTable
    'Dim sSQL As String

    'sSQL = SQLStoreD13P2022(sAbsentTypeID, 1)
    'dtCheck = ReturnDataTable(sSQL)
    'Return dtCheck
    'End Function

    Private Sub tdbg_FooterText()
        Dim Value As Double = 0

        FooterTotalGrid(tdbg, COL_FullName)

        Dim iFormat As Integer = 0
        Dim iSplit As Int32 = 0
        Dim dSum As Double = 0
        iSplit = SplitCount
        For col As Integer = COL_Total + 1 To COL_Total + (nTotalAbsentType * 2)
            dSum = 0
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, col).ToString <> "" Or tdbg(i, col + 1).ToString <> "" Then
                    dSum += Number(SQLNumber(tdbg(i, col + 1).ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString)))
                End If
            Next
            tdbg.Columns(col + 1).FooterText = SQLNumber(dSum.ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString))
            col = col + 1
            iSplit = iSplit + 1
            iFormat = iFormat + 1
        Next
    End Sub

#Region "Events tdbcBlockID load tdbcDepartmentID"

    Private Sub tdbcBlockID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.GotFocus
        'Dùng phím Enter
        tdbcBlockID.Tag = tdbcBlockID.Text
    End Sub

    Private Sub tdbcBlockID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcBlockID.MouseDown
        'Di chuyển chuột
        tdbcBlockID.Tag = tdbcBlockID.Text
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.Tag.ToString = "" And tdbcBlockID.Text = "" Then Exit Sub
        If tdbcBlockID.Tag.ToString = tdbcBlockID.Text And tdbcBlockID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            LoadtdbcDepartmentID("-1")
            tdbcDepartmentID.Text = ""
            Exit Sub
        End If
        LoadTdbcDepartmentID(ReturnValueC1Combo(tdbcBlockID))
    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.Text = "" Or tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1", "-1")
            Exit Sub
        End If
        LoadtdbcTeamID(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcDepartmentID))
    End Sub

#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "private Hot key functions"

    Public Sub CopyColumn(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""
        Dim Flag As DialogResult
        Flag = D99C0008.MsgCopyColumn()
        If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
            sValue1 = c1Grid(c1Grid.Row, c1Grid.Col + 1).ToString
        End If
        If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

            For i As Integer = 0 To c1Grid.RowCount - 1
                If c1Grid(i, ColCopy).ToString = "" Then
                    c1Grid(i, ColCopy) = sValue
                    If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
                        c1Grid(i, ColCopy + 1) = sValue1
                    End If
                End If
            Next
        ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy nhung dong con trong ' Copy het

            For i As Integer = 0 To c1Grid.RowCount - 1
                c1Grid(i, ColCopy) = sValue
                If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
                    c1Grid(i, ColCopy + 1) = sValue1
                End If
            Next
            c1Grid(0, ColCopy) = sValue
            If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
                c1Grid(0, ColCopy + 1) = sValue1
            End If
        Else
            Exit Sub
        End If
    End Sub

    Public Sub CopyColumnF9(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal sValue As String)

        If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
            sValue1 = c1Grid(c1Grid.Row, c1Grid.Col + 1).ToString
        End If

        For i As Integer = RowCopy To c1Grid.RowCount - 1
            c1Grid(i, ColCopy) = sValue
            If xFlag(ColCopy) = 1 Or xFlag(ColCopy) = 2 Then
                c1Grid(i, ColCopy + 1) = sValue1
            End If
        Next

    End Sub

    Public Sub HotKeyF7(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim iSplit As Integer = 0
        Try
            If c1Grid.RowCount < 1 Then Exit Sub
            iSplit = c1Grid.SplitIndex
            If c1Grid.Splits(iSplit).DisplayColumns(c1Grid.Col).Locked = False Then
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" Then
                    If xCheckNum(c1Grid.Col) = 1 Then
                        c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    Else
                        c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                        c1Grid.Columns(c1Grid.Col + 1).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col + 1).ToString()
                    End If

                ElseIf c1Grid(c1Grid.Row, c1Grid.Col).ToString <> "" Then
                    If Number(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                        If xCheckNum(c1Grid.Col) = 1 Then
                            c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                        Else
                            c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                            c1Grid.Columns(c1Grid.Col + 1).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col + 1).ToString()
                        End If

                    End If
                End If

            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/02/2007 08:48:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0103(ByVal iRow As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String = ""

        ' update 7/6/2013 id 56597
        sSQL = "Delete  D13T0103"
        sSQL &= " Where 	DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " And  	AbsentVoucherID = " & SQLString(AbsentVoucherID)
        sSQL &= " And TransID = " & SQLString(tdbg(iRow, COL_TransID))

        '        If _transTypeID = "" Then
        '            sSQL = "Delete  D13T0103" & vbCrLf
        '            sSQL &= "Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        '            sSQL &= "And  	AbsentVoucherID = " & SQLString(AbsentVoucherID) & vbCrLf
        '            sSQL &= "And 	AbsentTypeID in " & vbCrLf
        '            sSQL &= "       (Select AbsentTypeDateID " & vbCrLf
        '            sSQL &= "       From D13T0118)" & vbCrLf
        '            sSQL &= "And PayrollVoucherID = " & SQLString(_OldPayrollVoucherID) & vbCrLf
        '            'sSQL &= "And DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & vbCrLf
        '            'sSQL &= "And TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & vbCrLf
        '            sSQL &= "And EmployeeID = " & SQLString(tdbg(iRow, COL_EmployeeID)) & vbCrLf
        '            sSQL &= "And TransID = " & SQLString(tdbg(iRow, COL_TransID))
        '        Else
        '            sSQL = "Delete  D13T0103" & vbCrLf
        '            sSQL &= "Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        '            sSQL &= "And  	AbsentVoucherID = " & SQLString(AbsentVoucherID) & vbCrLf
        '            sSQL &= "And 	AbsentTypeID in " & vbCrLf
        '            sSQL &= "       (Select AbsentTypeID" & vbCrLf
        '            sSQL &= "       From D13T1131" & vbCrLf
        '            sSQL &= "       Where TransTypeID = " & SQLString(_transTypeID) & vbCrLf
        '            sSQL &= "       )" & vbCrLf
        '            sSQL &= "And PayrollVoucherID = " & SQLString(_OldPayrollVoucherID) & vbCrLf
        '            'sSQL &= "And DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & vbCrLf
        '            'sSQL &= "And TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & vbCrLf
        '            sSQL &= "And EmployeeID = " & SQLString(tdbg(iRow, COL_EmployeeID)) & vbCrLf
        '            sSQL &= "And TransID = " & SQLString(tdbg(iRow, COL_TransID))
        '        End If
        sRet &= sSQL & vbCrLf
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        Dim sSQL As String = ""
        Dim sSQLAudit As String = ""
        Dim bRunSQL As Boolean
        btnSave.Enabled = False
        btnClose.Enabled = False
        If dtMain.Select("IsUpdate=1").Length > 0 Then
            sSQL = SQLInsertD09T6666s().ToString() & vbCrLf
            sSQL &= SQLStoreD09P6200("D13T0103", "", "", 0, "") & vbCrLf
            If Not ExecuteSQL(sSQL) Then GoTo ErrorSQL


            sRetSQLInsertD13T0105 = New StringBuilder()
            sSQL = SQLInsertD13T0103s().ToString() & vbCrLf
            sSQL &= sRetSQLInsertD13T0105.ToString() & vbCrLf
            If sSQL <> "" Then
                If Not ExecuteSQL(sSQL) Then GoTo ErrorSQL
            End If
            sSQL = SQLStoreD09P6200("D13T0103", "", "", 1, "") & vbCrLf
            sSQL &= SQLStoreD09P6210("TimeSheetRecTrans", "", "02", "", txtRemark.Text) & vbCrLf
            '  sSQL &= SQLStoreD09P6210("TimeSheetRecTrans", "", "02", txtAbsentVoucherNo.Text, txtRemark.Text) & vbCrLf
            sSQL &= SQLDeleteD09T6666("D13F2022") & vbCrLf
            bRunSQL = ExecuteSQL(sSQL)

            If bRunSQL Then
                btnFilter_Click(Nothing, Nothing)
                LoadEditView(False)
                SaveOK()
                '   btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            Else
ErrorSQL:
                SaveNotOK()
                sSQL = ""
                btnSave.Enabled = True
                btnClose.Enabled = True
            End If
        Else
            btnFilter_Click(Nothing, Nothing)
            LoadEditView(False)
            SaveOK()
            '  btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        End If
    End Sub

    Private Structure AutoColumn
        Public Name As String
        Public DataType As Type
    End Structure

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2222
    '# Created User: Thanh Huyền
    '# Created Date: 27/04/2010 09:02:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2222() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2222 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function


    Dim arrLockColSplit2() As String = {} ' Lưu các cột cho phép nhập liệu tại split 2

    Dim au As New ArrayList
    Private Sub AddField()
        Dim sSQL As String = ""
        Dim nWidth As Integer
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim sCaption As String

        Dim i As Integer = 0

        sSQL = SQLStoreD13P2222() 'Modify 27/04/2010 - ID31673
        dtAbsentType = ReturnDataTable(sSQL)

        Dim iCountColiInput As Integer = 0
        'iColNum = dt.Rows.Count
        If dtAbsentType.Rows.Count > 0 Then
            nTotalAbsentType = dtAbsentType.Rows.Count
            If nTotalAbsentType = 1 Then
                nWidth = CInt(140 / nTotalAbsentType)
            ElseIf nTotalAbsentType >= 1 And nTotalAbsentType <= 2 Then
                nWidth = CInt(440 / nTotalAbsentType)
            ElseIf nTotalAbsentType >= 2 And nTotalAbsentType <= 4 Then
                nWidth = CInt(460 / nTotalAbsentType)
            ElseIf nTotalAbsentType >= 4 And nTotalAbsentType <= 10 Then
                nWidth = CInt(1025 / nTotalAbsentType)
            ElseIf nTotalAbsentType >= 10 And nTotalAbsentType <= 20 Then
                nWidth = CInt(1850 / nTotalAbsentType)
            ElseIf nTotalAbsentType >= 20 And nTotalAbsentType <= 32 Then
                nWidth = CInt(2975 / nTotalAbsentType)
            Else
                'nWidth = CInt(4000 / nTotalAbsentType)
                nWidth = 100
            End If

            If tdbg.Splits.ColCount >= 2 Then
                tdbg.RemoveHorizontalSplit(1)
            End If

            tdbg.InsertHorizontalSplit(1)

            'Dim k As Integer
            'k = COL_Total + 2
            While tdbg.Columns.Count >= COL_Total + 2
                tdbg.Columns.RemoveAt(COL_Total + 1)
                'k = COL_Total + 2
            End While

            tdbg.Splits(0).SplitSize = 500
            tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
            tdbg.Splits(0).Caption = ""
            tdbg.Splits(0).ColumnCaptionHeight = 34

            tdbg.Splits(1).SplitSize = 5
            tdbg.Splits(1).Caption = ""
            tdbg.Splits(1).ColumnCaptionHeight = 34
            tdbg.Splits(1).RecordSelectors = False
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg.Splits(1).BorderStyle = Border3DStyle.Flat
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

            For j As Integer = 0 To COL_Total
                tdbg.Splits(1).DisplayColumns(j).Visible = False
            Next
            iCountCol = COL_Total



            For j As Integer = 0 To dtAbsentType.Rows.Count - 1

                AbsentTypeID(j) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString


                ' Add các cột:Type1-> Typen (với n là số dòng của dt), Value1-> Valuen((với n là số dòng của dt))
                ' Add cột Type vào table
                Dim u As New AutoColumn
                u.Name = "Type" & (j + 1).ToString
                u.DataType = System.Type.GetType("System.String")
                dtMain.Columns.Add(u.Name, u.DataType)
                au.Add(u)

                ' Add cột Type vào lưới
                dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                dc.DataField = "T_" & AbsentTypeID(j) ' Cột type

                tdbg.Columns.Add(dc)

                iCountCol += 1
                tdbg.Columns(dc.DataField).Caption = dtAbsentType.Rows(j).Item("Type").ToString
                sCaption = tdbg.Columns(dc.DataField).Caption
                tdbg.Splits(1).DisplayColumns(dc).Width = nWidth - 18
                tdbg.Splits(1).DisplayColumns("T_" & AbsentTypeID(j)).Visible = True
                tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg.Splits(1).DisplayColumns(dc.DataField).Style.Font = FontUnicode(gbUnicode)
                ' Add cột Value vào table
                Dim u1 As New AutoColumn
                u1.Name = "Value" & (j + 1).ToString
                u1.DataType = System.Type.GetType("System.Decimal")
                dtMain.Columns.Add(u1.Name, u1.DataType)
                au.Add(u1)

                'dtMain.Columns.Add("Value" & (j + 1).ToString, System.Type.GetType("System.Double"))
                ' Add cột Value vào lưới
                dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                dc.DataField = "Q_" & AbsentTypeID(j) ' Cột Value
                tdbg.Columns.Add(dc)
                iCountCol += 1
                tdbg.Splits(1).DisplayColumns(dc).Width = nWidth - 18
                tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = True
                tdbg.Splits(1).DisplayColumns(dc.DataField).Locked = True

                '  ReDim Preserve arrLockColSplit2(iCountColiInput + 1)
                Array.Resize(arrLockColSplit2, iCountColiInput + 1)
                'ReDim arrInputColSplit2(iCountColiInput + 1)
                arrLockColSplit2(iCountColiInput) = dc.DataField
                iCountColiInput += 1


                tdbg.Columns("Q_" & AbsentTypeID(j)).NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                xNumberFormat(iCountCol) = dtAbsentType.Rows(j).Item("Decimals").ToString
                'End add cột

                ' Add dropdown vao cot nếu IsClassification=1, trường hợp cho nhập = cách chọn dropdown
                If dtAbsentType.Rows(j).Item("IsClassification").ToString = "1" Then

                    dc.DataField = "T_" & AbsentTypeID(j)
                    xCheckNum(iCountCol) = 0
                    xCheckMode(iCountCol) = L3Int(dtAbsentType.Rows(j).Item("Mode").ToString)

                    tdbg.Columns(dc.DataField).DropDown = tdbdType

                    tdbg.Columns(dc.DataField).Tag = dtAbsentType.Rows(j).Item("ClassificationID").ToString
                    tdbdType.Columns("Value").NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                    xFlag(iCountCol - 1) = j + 1

                    tdbg.Splits(1).DisplayColumns(dc.DataField).AutoComplete = True
                    tdbg.Splits(1).DisplayColumns(dc.DataField).AutoDropDown = True

                    'Nếu IsValue=1 thì cho hiển thị cột, ngược lại dấu cột đi
                    If dtAbsentType.Rows(j).Item("IsValue").ToString = "1" Then
                        dc.DataField = "Q_" & AbsentTypeID(j)
                        tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = True
                        tdbg.Splits(1).DisplayColumns(dc.DataField).Locked = True

                        'tdbg.Splits(1).DisplayColumns("T_C" & (j + 1).ToString).HeaderDivider = False
                        tdbg.Splits(1).DisplayColumns(dc.DataField).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                        'tdbg.Splits(1).DisplayColumns(dc.DataField).HeadingStyle.ForeColor = SystemColors.Control
                        tdbg.Columns(dc.DataField).Caption = dtAbsentType.Rows(j).Item("NumberOfDays").ToString
                        tdbg.Splits(1).DisplayColumns(dc.DataField).Style.Font = FontUnicode(gbUnicode)
                    Else
                        dc.DataField = "Q_" & AbsentTypeID(j)
                        tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = False
                    End If
                    xCellTip(iCountCol) = 0

                Else

                    'Trường hợp này cho nhập(số)
                    AbsentTypeID(iCountCol) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString
                    dc.DataField = "T_" & AbsentTypeID(j)
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = False
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.Font = FontUnicode(gbUnicode)
                    dc.DataField = "Q_" & AbsentTypeID(j)
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Locked = False

                    arrLockColSplit2(iCountColiInput - 1) = "" ' khong lock

                    tdbg.Columns(dc.DataField).Caption = dtAbsentType.Rows(j).Item("Lookup").ToString & vbCrLf
                    xCheckNum(iCountCol) = 1
                    xCellTip(iCountCol) = 1
                    tdbg.Columns("Q_" & AbsentTypeID(j)).DataWidth = 17
                    tdbg.Columns("Q_" & AbsentTypeID(j)).NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                End If
            Next

            ' Add cột Note vào lưới
            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc.DataField = "Note"
            dc.Caption = rL3("Ghi_chu")

            tdbg.Columns.Add(dc)
            tdbg.Splits(1).DisplayColumns(dc).Width = 200
            tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = True
            tdbg.Splits(1).DisplayColumns(dc.DataField).Locked = False

            Array.Resize(arrLockColSplit2, iCountColiInput + 1)
            arrLockColSplit2(iCountColiInput) = dc.DataField
            iCountColiInput += 1

            tdbg.Splits(1).DisplayColumns(dc.DataField).HeadingStyle.Font = New Font("Microsoft Sans Serif", 8.25)

            ' ResetColorGrid(tdbg, 0, 0)

            If nTotalAbsentType > 0 Then
                tdbg.Splits(SPLIT1).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
            End If

            If nTotalAbsentType > 0 Then ResetFooterGrid(tdbg, 1, 1)
        End If
    End Sub

    Private Function IsExistDataField(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal DataField As String) As Boolean
        For Each dc As C1.Win.C1TrueDBGrid.C1DataColumn In C1Grid.Columns
            If dc.DataField = DataField Then Return True
        Next
        Return False
    End Function

    Private Sub LoadTDBGrid(Optional ByVal bRefressGrid As Boolean = False)
        If bRefressGrid Then
            LoadData()
        End If

        LoadDataSource(tdbg, dtMain, gbUnicode)

        ' update 27/03/2013 id 55260 - Theo chi Thảo phân quyền import theo D13F5602
        CheckMenu("D13F2020", C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True, , "D13F5602")
        CheckMenuOther()

        tdbg_FooterText()
    End Sub

    Private Sub FillDataOnGrid()

        'Dim j As Integer
        'Dim iCol As Integer
        'For i As Integer = 0 To nTotalAbsentType - 1
        '    sAbsentTypeID = AbsentTypeID(i)
        '    If sAbsentTypeID <> "" And (sAbsentTypeID Is Nothing = False) Then
        '        iCol = COL_Total + 1 + (i * 2)
        '        dtCheck = CreateTableCheck(sAbsentTypeID)
        '        For j = 0 To tdbg.RowCount - 1
        '            If dtCheck.Rows.Count > 0 Then
        '                tdbg(j, iCol) = dtCheck.Rows(j).Item("Type").ToString
        '                Dim s As String = dtCheck.Rows(j).Item("NumberOfDayS").ToString
        '                If s <> "" Then
        '                    If Number(s) <> 0 Then
        '                        tdbg(j, iCol + 1) = SQLNumberD13(Number(s), dtAbsentType.Rows(i).Item("Decimals").ToString)
        '                    Else
        '                        tdbg(j, iCol + 1) = ""
        '                    End If
        '                Else
        '                    tdbg(j, iCol + 1) = ""
        '                End If
        '            End If
        '        Next
        '    End If
        'Next
        tdbg.Refresh()
        tdbg_FooterText()
        ShowOnlyEmployee()
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '
    '        'LoadData()
    '        'AddField2()
    '
    '        'LoadTDBGrid()
    '
    '        'If nTotalAbsentType > 0 Then
    '        '    FillDataOnGrid()
    '        'End If
    '
    '        'MarkInvisibleColumn(tdbg)
    '        'usrOption.D09U1111Refresh()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim sStrFind As String = ""
        If dtMain.Columns(dtMain.Columns.Count - 1).Caption <> "HaveData" Then
            dtMain.Columns.Add("HaveData", System.Type.GetType("System.String"))
        End If

        If chkShowEmployee.Checked Then
            If sFind <> "" Then
                sStrFind = sFind & " and (HaveData = '1')"
            Else
                sStrFind = "HaveData = '1'"
            End If
        Else
            sStrFind = sFind
        End If

        If sFilter.ToString() <> "" Then
            If sStrFind <> "" Then
                sStrFind &= " And " & sFilter.ToString
            Else
                sStrFind &= sFilter.ToString
            End If
        End If

        'LoadGridFind(tdbg, dtMain, sStrFind)
        dtMain.DefaultView.RowFilter = sStrFind
        dtMain.AcceptChanges()
        tdbg_FooterText()
        CheckMenu("D13F2020", C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False, , "D13F5602")
        CheckMenuOther()
    End Sub

#End Region

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtMain Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub


    Dim dtDropDown0, dtDropDown1 As DataTable
    Private Sub LoadDropDownDataTable_Mode0()
        Dim sSQL As String = ""
        sSQL = "Select Code, ClassificationID, Type, Description" & UnicodeJoin(gbUnicode) & " as Description, Value From  D13T0120  WITH (NOLOCK) Where Disabled = 0 order by Type"
        dtDropDown0 = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadDropDownDataTable_Mode1()
        Dim sSQL As String = ""
        sSQL = "Select Code,T71.ClassificationID,T71.EmployeeID,T71.Type,Description" & UnicodeJoin(gbUnicode) & " as Description,T71.Value" & vbCrLf
        sSQL &= "From D13T1071 T71  WITH (NOLOCK) Inner Join D13T0120 T20  WITH (NOLOCK) On T71.ClassificationID=T20.ClassificationID" & vbCrLf
        sSQL &= "And T71.Type=T20.Type Where Disabled=0" & vbCrLf
        sSQL &= "Order by T71.ClassificationID, EmployeeID, T71.Type"
        dtDropDown1 = ReturnDataTable(sSQL)
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.Update()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0103s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/02/2007 08:55:25
    '# Modify User: Trần Thị Ái Trâm
    '# Modify Date: 06/06/2007 2:00:37 PM
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLInsertD13T0103s() As String
        Dim i As Integer
        Dim iCount As Int32 = 0
        Dim bResult As Boolean

        Dim sSQL As String = ""
        Dim iCol As Integer
        Dim k As Integer

        For i = 0 To tdbg.RowCount - 1
            'Update 07/03/2012: Chỉ insert những dòng có Permission >=2
            ' update 7/6/2013 id 56597 - Chỉ thực hiện cho những dòng có IsUpdate = 1 (Trước đây xét Permission >= 2)
            If L3Bool(tdbg(i, COL_IsUpdate)) Then '  If L3Byte(tdbg(i, COL_Permission)) >= 2 Then
                iCount += 1
                sSQL &= SQLDeleteD13T0103(i) & vbCrLf
                k = 0
                'k = COL_Total + 1
                While k < nTotalAbsentType
                    'While k < nTotalAbsentType + COL_Total + 1
                    sAbsentTypeID = AbsentTypeID(k)
                    iCol = COL_Total + 1 + k * 2
                    If tdbg(i, iCol).ToString <> "" Or tdbg(i, iCol + 1).ToString <> "" Then
                        If Number(tdbg(i, iCol + 1)) <> 0 Or CType(tdbg.Columns(iCol).Tag, String) <> "" Then 'Gia tri khac 0 hoac Cot co Dropdown thi luu
                            sSQL &= "Insert Into D13T0103(" & vbCrLf
                            sSQL &= " TransID, DivisionID, AbsentVoucherID, EmployeeID, DepartmentID, TeamID, AbsentTypeID," & vbCrLf
                            sSQL &= " PayrollVoucherID, TranMonth, TranYear, NumberOfDays, Type" & vbCrLf
                            sSQL &= ") Values (" & vbCrLf
                            sSQL &= SQLString(tdbg(i, COL_TransID)) & COMMA
                            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(AbsentVoucherID) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_EmployeeID)) & COMMA 'EmployeeID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_DepartmentID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_TeamID)) & COMMA 'TeamID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(sAbsentTypeID) & COMMA 'AbsentTypeID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NULL
                            '                            sSQL &= SQLString(_NewPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NULL
                            sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
                            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
                            If tdbg(i, iCol + 1).ToString = "" Then
                                sSQL &= SQLMoney(0) & COMMA 'NumberOfDays, decimal, NOT NULL
                            Else
                                sSQL &= SQLMoney(tdbg(i, iCol + 1)) & COMMA 'NumberOfDays, decimal, NOT NULL
                            End If
                            sSQL &= SQLString(tdbg(i, iCol)) 'Type, varchar[20], NULL
                            sSQL &= ")" & vbCrLf

                        End If
                    End If
                    k += 1
                End While

                'Update 01/11/2011: Trả về chuỗi thực thi cho bảng D13T0105
                sRetSQLInsertD13T0105.Append(SQLInsertD13T0105s(i).ToString)

                If iCount = 10 Then
                    bResult = ExecuteSQL(sSQL)
                    If bResult = True Then
                        iCount = 0
                        sSQL = ""
                        If i = tdbg.RowCount - 1 Then
                            btnSave.Enabled = True
                            btnClose.Enabled = True
                            btnClose.Focus()
                            Exit For
                        End If

                    Else
                        SaveNotOK()
                        btnSave.Enabled = True
                        btnClose.Enabled = True
                        btnClose.Focus()
                        Exit For
                    End If
                End If
            End If
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2022
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/10/2007 08:36:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2022(ByVal sAbsentTypeID As String, ByVal mode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2022 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        'sSQL &= SQLString(_OldPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(sAbsentTypeID) & COMMA 'AbsentTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(mode) & COMMA 'Mode, int, NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA  'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(_sSalaryObjectID) 'SalaryObjectID, varchar[50], NOT NULL
        Return sSQL
    End Function


#Region "tdbg events"

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        If tdbg.FilterActive Then Exit Sub

        If L3Byte(tdbg.Columns(COL_Permission).Text) < 2 Then 'Không cho nhập liệu khi quyền < quyền Thêm
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        For i As Int32 = 0 To iCountCol
            If xCheckNum(i) = 1 Then
                If tdbg.Col = i Then
                    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
                End If
            End If
        Next
    End Sub

    '    Private Sub HotKeyEnterGrid(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal nFirstCol As Integer)
    '        c1Grid.UpdateData()
    '        Try
    '            If c1Grid.Col = CountCol(c1Grid, c1Grid.Splits.Count - 1) Then
    '                With c1Grid
    '                    .SplitIndex = 1
    '                    .Row = CInt(IIf(.RowCount = .Row, 0, .Row + 1))
    '                    .Col = nFirstCol
    '                    .Focus()
    '                End With
    '            End If
    '        Catch ex As Exception
    '
    '        End Try
    '    End Sub

    'Hai hàm này chép từ D99X0000 ra
    '''' <summary>
    '''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    '''' </summary>
    '''' <param name="c1Grid">Lưới C1</param>
    '''' <param name="ColCopy">Cột cần copy</param>
    '''' <param name="sValue">Giá trị cần copy</param>
    '''' <param name="RowCopy">Dòng đang copy</param>
    '''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32, ByVal ColUpdate As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                        c1Grid(i, ColCopy) = sValue
                        c1Grid(i, ColUpdate) = True ' update 24/6/2013 id 56597
                    End If
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    c1Grid(i, ColUpdate) = True ' update 24/6/2013 id 56597
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế nó (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="RowCopy">Dòng cần copy</param>
    ''' <param name="ColumnCount">Số cột liên quan khi cần copy</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String, ByVal iColUpdate As Int32)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy, iColUpdate)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()
                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                            c1Grid(i, ColCopy) = sValue
                            c1Grid(i, iColUpdate) = True
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        c1Grid(i, iColUpdate) = True
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            j += 1
                        End While
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Khi nào chuẩn hóa theo người dùng đơn vị xong thì trở về hàm dùng chung

    Private Sub HeadClickTask(ByVal iCol As Integer)
        For i As Integer = 0 To 1
            If tdbg.Splits(i).DisplayColumns(iCol).Locked = False And tdbg.Splits(i).DisplayColumns(iCol).Visible = True Then
                If xCheckNum(tdbg.Col) = 1 Then
                    CopyColumns(tdbg, iCol, SQLNumberD13(tdbg.Columns(iCol).Text, xNumberFormat(iCol)).ToString, tdbg.Row, COL_IsUpdate)
                Else
                    CopyColumns(tdbg, iCol, tdbg.Row, 2, tdbg.Columns(iCol).Text, COL_IsUpdate)
                End If

                tdbg_FooterText()
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
        'Những cột có CopyColumn thì k cho Sort
        'If e.ColIndex > COL_Total Then
        '    tdbg.AllowSort = False
        'Else
        '    tdbg.AllowSort = True
        'End If
        If e.ColIndex >= COL_Total Then
            HeadClickTask(e.ColIndex)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    HeadClickTask(tdbg.Col)
                    ' update 6/7/2013 id 57814
                    '                Case Keys.C
                    '                    Clipboard.Clear()
                    '                    If tdbg.Columns(tdbg.Col).Text <> "" Then Clipboard.SetText(tdbg.Columns(tdbg.Col).Text)
                    '                Case Keys.V
                    '                    If tdbg.SplitIndex = 0 Then Exit Select
                    '                    Dim sClipBoard As String = Clipboard.GetText
                    '                    If IsNumeric(sClipBoard) Then
                    '                        If tdbg.Columns(tdbg.Col).DropDown Is Nothing Then
                    '                            tdbg.Columns(tdbg.Col).Text = sClipBoard
                    '                            tdbg.UpdateData()
                    '                        End If
                    '                    End If
            End Select
        End If

        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            tdbg_FooterText()
        ElseIf e.Control And e.Alt And e.KeyCode = Keys.C Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                'CopyColumn(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text)
                HeadClickTask(tdbg.Col)
                tdbg_FooterText()
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If

        ElseIf e.Control And e.KeyCode = Keys.Home Then
            tdbg.SplitIndex = 0
            tdbg.Col = COL_DepartmentID
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
                tdbg_FooterText()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            For i As Integer = tdbg.Row To tdbg.RowCount - 1
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    tdbg(i, tdbg.Col) = ""
                    If xFlag(tdbg.Col) = 1 Or xFlag(tdbg.Col) = 2 Then
                        tdbg(i, tdbg.Col + 1) = ""
                    End If
                    tdbg.Focus()
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Return
                End If

            Next
            tdbg_FooterText()
        ElseIf e.KeyCode = Keys.F6 Then
            If xCellTip(tdbg.Col) = 1 Then
                ' update 27/3/2013 id 55260 - Insert dữ liệu hiện có trên lưới vào bảng tạm
                Dim sSQL As String
                sSQL = "-- Delete bang tam" & vbCrLf
                sSQL &= "DELETE D09T6666 "
                sSQL &= "WHERE 	FormID = 'D13F2023' "
                sSQL &= " AND UserID = " & SQLString(gsUserID)
                sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
                sSQL &= SQLInsertD09T6666("D13F2023").ToString
                ExecuteSQLNoTransaction(sSQL)

                Dim f As New D13F2023
                With f
                    .AbsentVoucherID = _AbsentVoucherID
                    Dim k As Integer = CInt((tdbg.Col - COL_Total) / 2 - 1)
                    .AbsentTypeID = AbsentTypeID(k).Trim  'sAbsentTypeID
                    .PayrollVoucherID = gsPayRollVoucherID ' _OldPayrollVoucherID
                    .OldTranMonth = giTranMonth
                    .OldTranYear = giTranYear
                    .ShowDialog()
                    If .bSaved = True Then
                        btnFilter_Click(Nothing, Nothing)
                    End If
                    .Dispose()
                End With

            Else
                Exit Sub
            End If

        ElseIf e.KeyCode = Keys.F9 Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumnF9(tdbg, tdbg.Col, tdbg.Row, tdbg.Columns(tdbg.Col).Text)
                tdbg_FooterText()
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If

        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(COL_IsUpdate).Value = True
        If tdbg.Col = tdbg.Columns.Count - 1 Then Exit Sub
        Dim i As Integer = e.ColIndex
        If xCheckNum(i) = 1 Then
            If tdbg.Columns(i).Text <> "" Then
                If Number(tdbg.Columns(i).Text) <> 0 Then
                    tdbg.Columns(i).Text = (SQLNumberD13(tdbg.Columns(i).Text, xNumberFormat(i))).ToString
                Else
                    tdbg.Columns(i).Text = (SQLNumberD13(0, xNumberFormat(i))).ToString
                End If
            End If
        Else
            If tdbg.Columns(tdbg.Col).Text = tdbdType.Columns("Type").Value.ToString Then
                tdbg.Columns(tdbg.Col + 1).Text = SQLNumberD13(Number(tdbdType.Columns("Value").Value), xNumberFormat(i + 1))
            End If

        End If
        tdbg_FooterText()

    End Sub

    Dim bAllowRowColChange As Boolean = False
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        CheckPermissionColGrid()
        If bAllowRowColChange = False Then
            Exit Sub
        End If

        If tdbg.Col = e.LastCol Then Exit Sub 'RowColChange chạy 2 lần nên vẫn bị load dư 1 lần

        If tdbg.Columns(tdbg.Col).Tag Is Nothing Then Exit Sub

        If xCheckNum(tdbg.Col) = 0 Then
            If xCheckMode(tdbg.Col + 1) = 0 Then
                If tdbg.Splits(1).DisplayColumns(tdbg.Col).Locked Then ' update 10/6/2013 id 56597
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    Exit Sub
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdType
                End If
                If dtDropDown0 Is Nothing = False Then
                    Dim dt As DataTable = ReturnTableFilter(dtDropDown0, "ClassificationID = " & SQLString(tdbg.Columns(tdbg.Col).Tag.ToString()))
                    LoadDataSource(tdbdType, dt, gbUnicode)
                End If

            ElseIf xCheckMode(tdbg.Col + 1) = 1 Then
                If tdbg.Splits(1).DisplayColumns(tdbg.Col).Locked Then ' update 10/6/2013 id 56597
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    Exit Sub
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdType
                End If
                If dtDropDown1 Is Nothing = False Then
                    Dim dt1 As DataTable = ReturnTableFilter(dtDropDown1, "ClassificationID = " & SQLString(tdbg.Columns(tdbg.Col).Tag.ToString()) & " And EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text))
                    LoadDataSource(tdbdType, dt1, gbUnicode)
                End If

            End If

        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        If tdbg.Col = tdbg.Columns.Count - 1 Then Exit Sub

        If xCheckNum(e.ColIndex) = 0 Then 'Đây là TH nhập liệu từ dropdown
            If tdbg.Columns(tdbg.Col).Text <> tdbdType.Columns("Type").Text Then
                tdbg.Columns(tdbg.Col).Text = ""
                tdbg.Columns(tdbg.Col + 1).Text = ""
            End If
        ElseIf xCheckNum(e.ColIndex) = 1 Then ' 22/11/2013 id 60916 - các khoản điều chỉnh thu nhập được phép nhập số âm.
            If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Dim i As Integer = e.ColIndex
        tdbg.Columns(tdbg.Col).Text = tdbdType.Columns("Type").Text
        tdbg.Columns(tdbg.Col + 1).Text = SQLNumberD13(Number(tdbdType.Columns("Value").Value), xNumberFormat(i + 1))
        tdbg.Update()
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.ColIndex = COL_DepartmentID Then
            e.CellTip = tdbg.Columns(COL_DepartmentName).Text
        ElseIf e.ColIndex = COL_TeamID Then
            e.CellTip = tdbg.Columns(COL_TeamName).Text
        Else
            e.CellTip = ""
        End If

        If e.ColIndex > 21 Then
            If xCellTip(e.ColIndex) = 1 Then
                If geLanguage = EnumLanguage.Vietnamese Then
                    e.CellTip = "Bạn chọn F6 để kế thừa dữ liệu."
                ElseIf geLanguage = EnumLanguage.English Then
                    e.CellTip = "Please, Choose F6 to inherit data."
                End If
            Else
                e.CellTip = ""
            End If
        End If
    End Sub
#End Region

    Dim dtMerge As DataTable

    Private Sub ShowOnlyEmployee()

        If chkShowEmployee.Checked Then
            If dtMain.Columns(dtMain.Columns.Count - 1).Caption <> "HaveData" Then
                dtMain.Columns.Add("HaveData", System.Type.GetType("System.String"))
            End If
            For Each dr As DataRow In dtMain.Rows
                Dim bHaveData As Boolean = False
                For i As Integer = 0 To dtMain.Columns.Count - 1
                    Dim s As String = dtMain.Columns(i).Caption
                    If s.StartsWith("T_") AndAlso dr(i).ToString <> "" Then
                        bHaveData = True
                    ElseIf s.StartsWith("Q_") AndAlso Number(dr(i)) <> 0 Then
                        bHaveData = True
                    End If
                Next
                If bHaveData = False Then
                    dr("HaveData") = "0"
                Else
                    dr("HaveData") = "1"
                End If
            Next
            ReLoadTDBGrid()
            '  LoadDataSource(tdbg, ReturnTableFilter(dtMain, "HaveData = '1'", True), gbUnicode)
            tdbg_FooterText()
        Else
            'LoadTDBGrid()
            ReLoadTDBGrid()
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnFilter.Enabled = False
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadData()
        AddField2()
        LoadEditView(False)
        If chkShowEmployee.Checked Then
            If nTotalAbsentType > 0 Then
                FillDataOnGrid()
            End If
        Else
            LoadTDBGrid()
        End If
        'LoadUsercontrol()
        bAllowRowColChange = True
        btnFilter.Enabled = True
        btnEdit.Enabled = _FormState <> EnumFormState.FormView And tdbg.FilterBar And iPerD13F2020 >= 2
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShow.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnMonthlyPayrollFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonthlyPayrollFiles.Click
        Dim arrPro() As StructureProperties = Nothing
        ' SetProperties(arrPro, "Path", "")
        SetProperties(arrPro, "PayrollVoucherID", gsPayRollVoucherID) ' _OldPayrollVoucherID)
        SetProperties(arrPro, "PayrollVoucherNo", _payrollVoucherNo)
        SetProperties(arrPro, "VoucherDate", _voucherDate)
        SetProperties(arrPro, "Description", _description)
        Dim frm As Form = CallFormShowDialog("D13D2040", "D13F2012", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            btnFilter_Click(Nothing, Nothing)
        End If

        '        Dim f As New D13M2040
        '        f.FormActive = enumD13E2040Form.D13F2012
        '        f.ID01 = ""
        '        f.ID02 = _OldPayrollVoucherID
        '        f.ID03 = _payrollVoucherNo
        '        f.ID04 = _voucherDate.ToString
        '        f.ID05 = _description
        '        f.ShowDialog()
        '        f.Dispose()
        '        If .bSaved Then
        '            btnFilter_Click(Nothing, Nothing)
        '            _bSaved = False
        '        End If
    End Sub

    Private Sub btnImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportExcel.Click
        Dim sSQL As String = ""
        sSQL = SQLDeleteD91T9009().ToString & vbCrLf
        sSQL &= SQLInsertD91T9009().ToString
        ExecuteSQL(sSQL)

        Me.Cursor = Cursors.WaitCursor
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D13, "D13F5602", "AbsentList") Then
            'Load lại dữ liệu
            btnFilter_Click(Nothing, Nothing)
        End If

        '        Dim frm As New D80F2090
        '        With frm
        '            .FormActive = "D80F2090"
        '            .FormPermission = "D13F5602"
        '            .ModuleID = D13
        '            .TransTypeID = "AbsentList" 'Theo TL phân tích
        '            .ShowDialog()
        '            If .OutPut01 Then .bSaved = .OutPut01
        '            .Dispose()
        '        End With
        '
        '        If .bSaved Then
        '            'Load lại dữ liệu
        '            btnFilter_Click(Nothing, Nothing)
        '        End If

        'Xoa bang tam
        sSQL = "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " And HostID = " & SQLString(My.Computer.Name)
        ExecuteSQL(sSQL)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnInheritData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInheritData.Click
        ' update 27/3/2013 id 55260 - Insert dữ liệu hiện có trên lưới vào bảng tạm
        Dim sSQL As String
        sSQL = "-- Delete bang tam" & vbCrLf
        sSQL &= "DELETE D09T6666 "
        sSQL &= "WHERE 	FormID = 'D13F2025' "
        sSQL &= " AND UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= SQLInsertD09T6666("D13F2025").ToString
        ExecuteSQLNoTransaction(sSQL)

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TransTypeID", _transTypeID)
        SetProperties(arrPro, "AbsentVoucherID", _AbsentVoucherID)
        Dim frm As Form = CallFormShowDialog("D13D0140", "D13F2025", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            btnFilter_Click(Nothing, Nothing)
        End If

        '        Dim f As New D13F2025
        '        f.AbsentVoucherID = _AbsentVoucherID
        '        f.TransTypeID = _transTypeID
        '        f.ShowDialog()
        '        f.Dispose()
        '        If .bSaved Then
        '            btnFilter_Click(Nothing, Nothing)
        '            .bSaved = False
        '        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 27/03/2013 01:58:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: id 55260 - Insert dữ liệu hiện có trên lưới vào bảng tạm
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal sFormID As String) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If tdbg.RowCount > 0 Then sSQL.Append("--Insert bang tam" & vbCrLf)
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(sFormID) & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmployeeID).ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID).ToString)) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 07/07/2009 08:31:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009" & vbCrLf
        sSQL &= "Where UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= "And HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "And Key02ID = " & SQLString("D13F2022")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 07/07/2009 08:29:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("D13F2022") & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(_AbsentVoucherID)) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    Private Sub chkShowEmployee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowEmployee.CheckedChanged
        If nTotalAbsentType > 0 Then
            ShowOnlyEmployee()
            'FillDataOnGrid()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: DUCTRONG
    '# Created Date: 27/01/2010 03:51:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Dim arrFooterSum() As Integer = {}
    'Dim dtCaptionCols As DataTable
    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Chuẩn hóa D09U1111 B7: Xuất Excel
        For i As Integer = COL_Total To tdbg.Columns.Count - 1
            If tdbg.Splits(1).DisplayColumns(i).Visible = True And tdbg.Splits(1).DisplayColumns(i).AutoDropDown = False Then
                ReDim Preserve arrFooterSum(UBound(arrFooterSum) + 1)
                arrFooterSum(UBound(arrFooterSum)) = i
            End If
        Next
        '*****************************************
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtMain, gsGroupColumns)

        '        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        '        Dim frm As New D99F2222
        '        ResetTableForExcel(tdbg, gdtCaptionExcel)
        '        With frm
        '            .FormID = Me.Name
        '            .dtLoadGrid = gdtCaptionExcel
        '            .GroupColumns = gsGroupColumns
        '            .UseUnicode = gbUnicode
        '            .dtExportTable = dtMain
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D13F7777
        With f
            .CallShowForm(Me.Name)
            .ShowDialog()
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0105s
    '# Created User: 
    '# Created Date: 17/09/2010 09:16:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Dim sRetSQLInsertD13T0105 As New StringBuilder

    Private Function SQLInsertD13T0105s(ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        'Update 01/11/2011: Đưa vòng for thực thi cùng lúc với bảng D13T0103
        'For i As Integer = 0 To tdbg.RowCount - 1
        ' update 10/12/2012 by Hoàng Nhân - id 52810 chỉ insert những dòng có note khác rỗng, nhưng xóa thì all dòng
        sSQL.Append(vbCrLf & "Delete From D13T0105")
        sSQL.Append(" Where AbsentVoucherID = " & SQLString(_AbsentVoucherID))
        sSQL.Append(" AND TransID = " & SQLString(tdbg(iRow, COL_TransID).ToString) & vbCrLf)

        If tdbg(iRow, tdbg.Columns.Count - 1).ToString <> "" Then
            sSQL.Append("Insert Into D13T0105(")
            sSQL.Append("AbsentVoucherID, TransID,Note, NoteU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_AbsentVoucherID) & COMMA) 'AbsentVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(iRow, COL_TransID).ToString) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(iRow, tdbg.Columns.Count - 1).ToString, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(iRow, tdbg.Columns.Count - 1).ToString, gbUnicode, True)) 'Note, varchar[500], NOT NULL
            sSQL.Append(")")
        End If
        Return sSQL
    End Function


    Private Sub mnuImportData_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportData.Click
        Dim sSQL As String = ""
        sSQL = SQLDeleteD91T9009().ToString & vbCrLf
        sSQL &= SQLInsertD91T9009().ToString
        ExecuteSQL(sSQL)

        Me.Cursor = Cursors.WaitCursor

        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D13, "D13F5602", "AbsentList") Then
            'Load lại dữ liệu
            btnFilter_Click(Nothing, Nothing)
        End If
        '        Dim frm As New D80F2090
        '        With frm
        '            .FormActive = "D80F2090"
        '            .FormPermission = "D13F5602"
        '            .ModuleID = D13
        '            .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '            .TransTypeID = "AbsentList" 'Theo TL phân tích
        '            .ShowDialog()
        '            If .OutPut01 Then .bSaved = .OutPut01
        '            .Dispose()
        '        End With
        '
        '        If .bSaved Then
        '            'Load lại dữ liệu
        '            btnFilter_Click(Nothing, Nothing)
        '        End If

        'Xoa bang tam
        sSQL = "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " And HostID = " & SQLString(My.Computer.Name)
        ExecuteSQL(sSQL)

        Me.Cursor = Cursors.Default
    End Sub


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
            'Update 07/03/2012: Chỉ insert những dòng có Permission >=2
            ' update 7/6/2013 id 56597 - Chỉ thực hiện cho những dòng có IsUpdate = 1 (Trước đây xét Permission >= 2)
            If L3Bool(tdbg(i, COL_IsUpdate)) Then 'If L3Byte(tdbg(i, COL_Permission)) >= 2 Then
                sSQL.Append("Insert Into D09T6666(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, Key04ID, Key05ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                sSQL.Append(SQLString("D13F2022") & COMMA) 'Key01ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'Key03ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(_AbsentVoucherID) & COMMA) 'Key04ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(_AbsentVoucherNo)) 'Key04ID, varchar[250], NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
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

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "TimeSheetRecTrans")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_AbsentTransID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)

        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "TimeSheetRecTrans" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_AbsentTransID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        btnChooseEmployee_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As New StringBuilder("")
        Dim iBookmark As Integer

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            Dim sRet As String = ""

            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
            sSQL.Append(SQLStoreD13P2122)

            If ExecuteSQL(sSQL.ToString) Then
                DeleteOK()
                LoadTDBGrid(True)
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            Else
                DeleteNotOK()
            End If
        End If



    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2122
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 10/01/2012 10:20:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2122() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2122 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransID).Value) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Value) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnChooseEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseEmployee.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F2020")
        SetProperties(arrPro, "FormID", "D13F2020")
        SetProperties(arrPro, "ModuleID", D13)
        SetProperties(arrPro, "Mode", 23)
        SetProperties(arrPro, "Voucher01ID", _AbsentVoucherID)
        SetProperties(arrPro, "Key01", "F_EmployeeID")
        SetProperties(arrPro, "Key02", "")
        SetProperties(arrPro, "Key03", "")
        SetProperties(arrPro, "Key04", "")
        SetProperties(arrPro, "Key05", "")
        SetProperties(arrPro, "ShowEmpStopWork", True)
        ' Hiện tại thấy D09 ko nhận formstate
        Dim frm As Form = CallFormShowDialog("D09D2040", "D09F5605", arrPro)

        If L3Bool(GetProperties(frm, "bSaved")) Then
            ExecuteSQLNoTransaction(SQLStoreD13P2029())
            LoadTDBGrid(True)
        End If

        '        Dim f As New D09F5605
        '        With f
        '            .FormActive = D09E2040Form.D09F5605
        '            .FormPermission = "D13F2020"
        '            .FormID = "D13F2020"
        '            .ModuleID = "D13"
        '            .Mode = 23
        '            .Voucher01ID = _AbsentVoucherID
        '            .Key01ID = "F_EmployeeID"
        '            .Key02ID = ""
        '            .Key03ID = ""
        '            .Key04ID = ""
        '            .Key05ID = ""
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '
        '        If CBool(D99C0007.GetOthersSetting("D09", "D09E2040", "ButtonChoose", "False")) Then
        '            ExecuteSQLNoTransaction(SQLStoreD13P2029())
        '            LoadTDBGrid(True)
        '        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2029
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 10/01/2012 11:08:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2029() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2029 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) 'AbsentVoucherID, varchar[20], NOT NULL
        Return sSQL
    End Function


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        LoadEditView(True)
    End Sub

    ' update  10/6/2013 id 56597
    Private Sub LoadEditView(ByVal bEdit As Boolean)
        If bEdit Then
            'dtMain.DefaultView.Sort = "" ' khong co se bi sai khi headclick
            ' update 19/7/2013 id 58339
            Dim dt As DataTable = dtMain.DefaultView.ToTable
            dtMain = dt.DefaultView.ToTable
            LoadTDBGrid()
            '   btnFilter_Click(Nothing, Nothing)

            btnEdit.Visible = False
            btnSave.Visible = True
            '  btnEdit.Enabled = False
            btnSave.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
            btnMonthlyPayrollFiles.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
            btnImportExcel.Enabled = ReturnPermission("D13F5602") >= 2

            For i As Integer = COL_Total + 1 To tdbg.Columns.Count - 1
                tdbg.Splits(1).DisplayColumns(i).Locked = False
                tdbg.Splits(1).DisplayColumns(i).Style.ResetBackColor()
            Next
            For i As Integer = 0 To arrLockColSplit2.Length - 1
                If arrLockColSplit2(i) <> "" And arrLockColSplit2(i) <> "Note" Then
                    tdbg.Splits(1).DisplayColumns(arrLockColSplit2(i)).Locked = True
                    tdbg.Splits(1).DisplayColumns(arrLockColSplit2(i)).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Next

            If nTotalAbsentType > 0 Then
                tdbg.Splits(SPLIT1).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
            End If
            tdbg.FilterBar = False
            tdbg.AllowFilter = True
            tdbg.AllowSort = False
            ResetColorGrid(tdbg, 0, 0)
            btnSave.Focus()
        Else
            If _FormState <> EnumFormState.FormView Then
                btnEdit.Visible = True
                btnSave.Visible = False
            Else
                btnEdit.Visible = False
                btnSave.Visible = True
            End If
            'btnSave.Enabled = False
            btnEdit.Enabled = _FormState <> EnumFormState.FormView And Not bEdit And iPerD13F2020 >= 2
            btnMonthlyPayrollFiles.Enabled = False
            btnImportExcel.Enabled = False

            For i As Integer = COL_Total + 1 To tdbg.Columns.Count - 1
                tdbg.Splits(1).DisplayColumns(i).Locked = True
                tdbg.Splits(1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Next
            If nTotalAbsentType > 0 Then
                tdbg.Splits(SPLIT1).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            End If
            tdbg.FilterBar = True
            tdbg.AllowFilter = False
            tdbg.AllowSort = True
            ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        End If

        '        ResetFilter(tdbg, sFilter, bRefreshFilter)
        '        sFind = ""
        ReLoadTDBGrid()
        btnInheritData.Enabled = btnSave.Enabled And btnSave.Visible ' hiiển thi khi ở mode sửa
        btnChooseEmployee.Enabled = btnSave.Enabled And btnSave.Visible ' hiiển thi khi ở mode sửa

        '  EnableMenu(bEdit)


    End Sub

    '    Private Sub EnableMenu(ByVal bEnable As Boolean)
    '        If bEnable Then
    '            mnuAdd.Enabled = False
    '            mnuDelete.Enabled = False
    '            mnuFind.Enabled = False
    '            mnuListAll.Enabled = False
    '            mnuExportToExcel.Enabled = False
    '            mnuSysInfo.Enabled = False
    '        End If
    '    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        If Not tdbg.FilterBar Then ' Dang mode sửa
            mnuAdd.Enabled = False
            mnuDelete.Enabled = False
            mnuFind.Enabled = False
            mnuListAll.Enabled = False
            mnuExportToExcel.Enabled = False
            mnuSysInfo.Enabled = False
        Else ' Mode xem 
            CheckMenu("D13F2020", C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False, , "D13F5602")
            If _FormState = EnumFormState.FormView Then
                mnuAdd.Enabled = False
                mnuDelete.Enabled = False
                mnuImportData.Enabled = False
            End If
        End If
    End Sub
End Class

