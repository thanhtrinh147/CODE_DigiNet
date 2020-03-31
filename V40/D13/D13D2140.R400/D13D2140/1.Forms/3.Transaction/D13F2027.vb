'#-------------------------------------------------------------------------------------
'# Created Date: 10/05/2007 2:57:34 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 27/21/2009 
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System
Imports System.Drawing


Public Class D13F2027

#Region "Const of tdbg"

    Private _blockID As String
    Private Const COL_DivisionID As Integer = 0     ' Đơn vị
    Private Const COL_DivisionName As Integer = 1   ' Tên đơn vị
    Private Const COL_BlockID As Integer = 2        ' Khối
    Private Const COL_BlockName As Integer = 3      ' Tên khối
    Private Const COL_DepartmentID As Integer = 4   ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5 ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6         ' Tổ nhóm 
    Private Const COL_TeamName As Integer = 7       ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8     ' Nhóm nhân viên
    Private Const COL_EmpGroupName As Integer = 9   ' Tên nhóm nhân viên
    Private Const COL_NCodeID As Integer = 10       ' Mã PTNS
    Private Const COL_NCodeName As Integer = 11     ' Tên mã PTNS

    Private Const COL_Total As Integer = 11 'Vị trí của cột cuối cùng trên lưới
    Private Const SplitCount As Integer = 1
#End Region

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
#End Region

    Dim _AttMode As String
    Public WriteOnly Property AttMode() As String
        Set(ByVal value As String)
            _AttMode = value
        End Set
    End Property

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
    'Dim sEnabledMenu As String = "1"

    Private IsTransferAbsent As Boolean = False
    Dim dtTeamID As DataTable

#Region "Properties"
    Private _sSalaryObjectID As String = ""
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
            _payrollVoucherNo = Value
        End Set
    End Property

    Private _voucherDate As DateTime = Now()
    Public Property VoucherDate() As DateTime
        Get
            Return _voucherDate
        End Get
        Set(ByVal Value As DateTime)
            _voucherDate = Value
        End Set
    End Property

    Private _description As String = ""
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
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

    Private Sub D13F2022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '***************************************
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If

        If e.Control And e.KeyCode = Keys.F1 Then
            'btnHotKey_Click(sender, e)
            Dim f As New D13F7777
            With f
                .CallShowForm(Me.Name)
                .ShowDialog()
            End With
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.Control And e.KeyCode = Keys.A And mnuFind.Enabled Then
            mnuListAll_Click(sender, Nothing)
        ElseIf e.Control And e.KeyCode = Keys.F And mnuListAll.Enabled Then
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
    End Sub


    Dim dtMain_First As DataTable
    Dim dtCaptionCols As DataTable

    Private gbEnabledUseFind As Boolean = False

    Private Sub D13F2022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        SetShortcutPopupMenu(Me.C1CommandHolder)
        CheckPermission()
        'thiết lập nhấn Enter thì xuống dòng
        tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown

        If Not IsAllowEdit_D13F2022(_AbsentVoucherID) Then
            'btnInheritData.Enabled = False
            btnSave.Enabled = False
            'sEnabledMenu = "0"
        End If

        Loadlanguage()
        'SetBackColorObligatory()
        Me.Cursor = Cursors.WaitCursor

        LoadDropDownDataTable_Mode0()
        'LoadDropDownDataTable_Mode1()
        'tdbg_NumberFormat()
        tdbg_LockedColumns()

        gbEnabledUseFind = False

        LoadMaster()
        AddField()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        ' update 10/9/2013 id 58998
        ' Khối: Phụ thuộc hệ thống (trừ _AttMode = 4, 5) ' u
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D13Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D13Systems.IsUseBlock

        'Update 16/02/2012: Incident 45314
        Select Case _AttMode
            Case "1"
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeName).Visible = False
            Case "2"
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeName).Visible = False
            Case "3"
                tdbg.Splits(0).DisplayColumns(COL_NCodeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeName).Visible = False
            Case "4"
                tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeName).Visible = False
                ' Update 1/8/2012 incident 50402
            Case "5"
                tdbg.Splits(0).DisplayColumns(COL_DivisionID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DivisionName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupName).Visible = False
            Case "6" ' update 10/9/2013 id 58998
                tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_EmpGroupName).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeID).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_NCodeName).Visible = False
        End Select
        '        If _AttMode <> "1" Then
        '            tdbg.Splits(0).DisplayColumns(COL_TeamID).Visible = False
        '            tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = False
        '        End If

        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************
        InputbyUnicode(Me, gbUnicode)
InputDateCustomFormat(c1dateEntryDate)

        SetResolutionForm(Me, Me.C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function IsAllowEdit_D13F2022(ByVal ID As String) As Boolean
        Dim sSQL As String = "SELECT VoucherID FROM D13T2605 " & vbCrLf
        sSQL &= " WHERE Module = 'D13' AND VoucherID = " & SQLString(ID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_khong_duoc_sua_U"))
            Return False
        End If

        Return True
    End Function

    Private Sub CheckPermission()
        iPerD13F2020 = ReturnPermission("D13F2020")
        btnSave.Enabled = iPerD13F2020 >= 2 And _FormState <> EnumFormState.FormView
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg.Splits(SPLIT0).DisplayColumns(COL_NCodeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_NCodeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Nhap_phieu_dieu_chinh_thu_nhap_-_D13F2022") & " " & Me.Name & UnicodeCaption(gbUnicode) 'NhËp phiÕu ¢iÒu chÙnh thu nhËp - D13F2027
        '================================================================ 
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnShow.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnFilter.Text = rl3("Lo_c") 'Lọ&c
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        GroupBox1.Text = rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbg.Columns("DivisionID").Caption = rl3("Don_vi") 'Đơn vị
        tdbg.Columns("DivisionName").Caption = rl3("Ten_don_vi") 'Tên đơn vị
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm 
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_nhan_vien") 'Tên nhóm nhân viên
        tdbg.Columns("NCodeID").Caption = rl3("Ma_PTNS") ' Mã PTNS
        tdbg.Columns("NCodeName").Caption = rl3("Ten_ma_PTNS") ' Tên mã PTNS
        '================================================================ 
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
    End Sub

    Private Sub CreateTableType()
        Dim sSQL As String = ""
        'Load tdbdType
        sSQL = "Select Code, ClassificationID, Type, Description, Value" & vbCrLf
        sSQL &= "From D13T0120" & vbCrLf
        sSQL &= "Where Disabled=0 "
        dtType = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadMaster()
        txtAbsentVoucherNo.Text = AbsentVoucherNo
        c1dateEntryDate.Value = EntryDate
        txtRemark.Text = Remark
    End Sub

    Private Sub tdbg_FooterText()

        FooterTotalGrid(tdbg, COL_DepartmentName)

        Dim iFormat As Integer = 0
        'Dim iSplit As Int32 = 0
        Dim dSum As Double = 0
        'iSplit = SplitCount
        For col As Integer = COL_Total + 1 To COL_Total + (nTotalAbsentType * 2)
            dSum = 0
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, col).ToString <> "" Or tdbg(i, col + 1).ToString <> "" Then
                    dSum += Number(SQLNumber(tdbg(i, col + 1).ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString)))
                End If
            Next
            tdbg.Columns(col + 1).FooterText = SQLNumber(dSum.ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString))
            col = col + 1
            'iSplit = iSplit + 1
            iFormat = iFormat + 1
        Next
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
    '# Title: SQLStoreD13P2128
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 16/02/2012 01:47:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2128() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2128 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2027") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2028
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 26/11/2009 01:16:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2028() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2028 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_DepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_TeamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        'sSQL &= SQLString(_OldPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_transTypeID) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(_AttMode) & COMMA  'AttMode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(_blockID) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(_sSalaryObjectID)  'SalaryObjectID, varchar[20], NOT NULL
        ' sSQL &= SQLString(sFind) 'WhereClause, varchar[8000], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0104s
    '# Created User: dmd
    '# Created Date: 27/02/2007 08:48:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0104(ByVal iRow As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String = ""

        If _transTypeID = "" Then
            sSQL = "Delete  D13T0104" & vbCrLf
            sSQL &= "Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
            sSQL &= "And  	AbsentVoucherID = " & SQLString(AbsentVoucherID) & vbCrLf
            sSQL &= "And 	AbsentTypeID in " & vbCrLf
            sSQL &= "       (Select AbsentTypeDateID " & vbCrLf
            sSQL &= "       From D13T0118)" & vbCrLf
            sSQL &= "And PayrollVoucherID = " & SQLString(_OldPayrollVoucherID) & vbCrLf
            sSQL &= "And DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & vbCrLf
            sSQL &= "And TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & vbCrLf
            sSQL &= "And NcodeID = " & SQLString(tdbg(iRow, COL_NCodeID)) & vbCrLf ' 3/8/2012 incident 50402 - Theo Bich Thuận (bổ sung thêm where khi xóa)
            sSQL &= "And BlockID = " & SQLString(tdbg(iRow, COL_BlockID)) & vbCrLf ' update 12/9/2013 id 58998 
        Else
            sSQL = "Delete  D13T0104" & vbCrLf
            sSQL &= "Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
            sSQL &= "And  	AbsentVoucherID = " & SQLString(AbsentVoucherID) & vbCrLf
            sSQL &= "And 	AbsentTypeID in " & vbCrLf
            sSQL &= "       (Select AbsentTypeID" & vbCrLf
            sSQL &= "       From D13T1131" & vbCrLf
            sSQL &= "       Where TransTypeID = " & SQLString(_transTypeID) & vbCrLf
            sSQL &= "       )" & vbCrLf
            sSQL &= "And PayrollVoucherID = " & SQLString(_OldPayrollVoucherID) & vbCrLf
            sSQL &= "And DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & vbCrLf
            sSQL &= "And TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & vbCrLf
            sSQL &= "And NcodeID = " & SQLString(tdbg(iRow, COL_NCodeID)) & vbCrLf ' 3/8/2012 incident 50402 - Theo Bich Thuận (bổ sung thêm where khi xóa)
            sSQL &= "And BlockID = " & SQLString(tdbg(iRow, COL_BlockID)) & vbCrLf ' update 12/9/2013 id 58998 
        End If
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

        sSQL = SQLInsertD13T0104s() & vbCrLf
        If sSQL <> "" Then
            bRunSQL = ExecuteSQL(sSQL)
            If bRunSQL Then
                btnFilter_Click(Nothing, Nothing)
                Lemon3.D91.RunAuditLog("13", "TimeSheetRecTrans", "02", c1dateEntryDate.Value.ToString, txtAbsentVoucherNo.Text, _NewPayrollVoucherID, txtRemark.Text, "")
                'Update 16/02/2012: Incident 45314
                ExecuteSQLNoTransaction(SQLStoreD13P2128())

                SaveOK()

                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            Else
                SaveNotOK()
                btnSave.Enabled = True
                btnClose.Enabled = True
            End If

        End If
    End Sub

    Private Structure AutoColumn
        Public Name As String
        Public DataType As Type
    End Structure

    Dim au As New ArrayList

    Dim nWidth As Integer
    Private Function PreSetGrid() As Boolean
        Dim sSQL As String = ""

        If _transTypeID = "" Then
            sSQL = "SELECT      DISTINCT T18.AbsentTypeDateID, T18.AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " as AbsentTypeDateName," & vbCrLf
            sSQL &= "           (Lookup" & UnicodeJoin(gbUnicode) & " +' ('+T18.UnitID" & UnicodeJoin(gbUnicode) & " +')') Lookup ," & vbCrLf
            sSQL &= "           T18.Orders, T18.Unit, T18.UnitID" & UnicodeJoin(gbUnicode) & " as UnitID, T18.IsClassification, " & vbCrLf
            sSQL &= "           T18.ClassificationID, T18.IsValue, T20.Mode, T18.Decimals" & vbCrLf
            sSQL &= "FROM       D13T0118 T18" & vbCrLf
            sSQL &= "LEFT JOIN  D13T0120 T20 " & vbCrLf
            sSQL &= "     ON    T20.ClassificationID = T18.ClassificationID" & vbCrLf
            sSQL &= "WHERE      T18.Disabled = 0 " & vbCrLf
            sSQL &= "           AND IsTimeSheet = 1 " & vbCrLf
            sSQL &= "ORDER BY   T18.Orders"
        Else
            sSQL = "SELECT 		DISTINCT T30.AbsentTypeID AS AbsentTypeDateID, T18.AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " as AbsentTypeDateName," & vbCrLf
            sSQL &= "           (Lookup" & UnicodeJoin(gbUnicode) & " +'('+T18.UnitID" & UnicodeJoin(gbUnicode) & " +')') Lookup, T18.UnitID" & UnicodeJoin(gbUnicode) & " as UnitID, T18.IsClassification, " & vbCrLf
            sSQL &= "        	T18.ClassificationID, T18.IsValue, T20.Mode, T18.Decimals, T30.OrderNo" & vbCrLf
            sSQL &= "FROM       D13T1131 T30" & vbCrLf
            sSQL &= "INNER JOIN D13T0118 T18 ON T30.AbsentTypeID = T18.AbsentTypeDateID" & vbCrLf
            sSQL &= "LEFT JOIN  D13T0120 T20 ON T18.ClassificationID = T20.ClassificationID" & vbCrLf
            sSQL &= "WHERE 		TransTypeID = " & SQLString(_transTypeID) & vbCrLf
            sSQL &= "			AND T18.Disabled = 0 AND T18.IsTimeSheet = 1" & vbCrLf
            sSQL &= "ORDER BY 	T30.OrderNo"
        End If

        dtAbsentType = ReturnDataTable(sSQL)

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
            tdbg.InsertHorizontalSplit(1)

            tdbg.Splits(0).SplitSize = 390
            tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
            tdbg.Splits(0).Caption = ""
            tdbg.Splits(0).ColumnCaptionHeight = 34

            tdbg.Splits(1).SplitSize = 5
            tdbg.Splits(1).Caption = ""
            tdbg.Splits(1).RecordSelectors = False
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg.Splits(1).BorderStyle = Border3DStyle.Flat
            tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg.Splits(1).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(1).ColumnCaptionHeight = 34
            For j As Integer = 0 To COL_Total
                tdbg.Splits(1).DisplayColumns(j).Visible = False
            Next
            iCountCol = COL_Total
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub AddField()
        Dim sCaption As String

        If Not PreSetGrid() Then Exit Sub

        For j As Integer = 0 To dtAbsentType.Rows.Count - 1
            AbsentTypeID(j) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString

            Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
            Dim dcValue As New C1.Win.C1TrueDBGrid.C1DataColumn
            Dim dp As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim dpValue As C1.Win.C1TrueDBGrid.C1DisplayColumn

            ' Add cột Type vào lưới
            dc.DataField = "Type" & "_" & AbsentTypeID(j).ToString ' Cột type
            tdbg.Columns.Add(dc)
            dp = tdbg.Splits(1).DisplayColumns(dc)

            iCountCol += 1
            dc.Caption = dtAbsentType.Rows(j).Item("Lookup").ToString
            sCaption = dc.Caption
            dp.Width = nWidth - 18
            dp.Visible = True
            dp.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ' Add cột Value vào lưới
            dcValue.DataField = "Value" & "_" & AbsentTypeID(j).ToString ' Cột Value
            dcValue.Caption = sCaption & " (2)"
            dc.NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
            tdbg.Columns.Add(dcValue)
            iCountCol += 1
            dpValue = tdbg.Splits(1).DisplayColumns(dcValue)
            dpValue.Width = nWidth - 18
            dpValue.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            dpValue.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            dpValue.Visible = True

            xNumberFormat(iCountCol) = dtAbsentType.Rows(j).Item("Decimals").ToString

            ' Add dropdown vao cot nếu IsClassification=1
            ' trường hợp cho nhập = cách chọn dropdown
            If dtAbsentType.Rows(j).Item("IsClassification").ToString = "1" Then
                xCheckNum(iCountCol) = 0
                xCheckMode(iCountCol) = L3Int(dtAbsentType.Rows(j).Item("Mode").ToString)
                xFlag(iCountCol - 1) = j + 1
                xCellTip(iCountCol) = 0

                dc.DropDown = tdbdType
                dc.Tag = dtAbsentType.Rows(j).Item("ClassificationID").ToString
                dp.AutoComplete = True
                dp.AutoDropDown = True
                tdbdType.Columns("Value").NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)

                'Nếu IsValue=1 thì cho hiển thị cột, ngược lại dấu cột đi
                If dtAbsentType.Rows(j).Item("IsValue").ToString = "1" Then
                    dpValue.Visible = True
                    dpValue.Locked = True
                    dp.HeaderDivider = False
                    dpValue.Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    dpValue.HeadingStyle.ForeColor = SystemColors.Control
                Else
                    dpValue.Visible = False
                End If
            Else
                'Trường hợp này cho nhập(số)
                AbsentTypeID(iCountCol) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString
                dp.Visible = False
                dpValue.Locked = False
                dcValue.Caption = dtAbsentType.Rows(j).Item("Lookup").ToString & vbCrLf
                dcValue.DataWidth = 17
                dcValue.NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                xCheckNum(iCountCol) = 1
                xCellTip(iCountCol) = 1
            End If

        Next

        ResetColorGrid(tdbg, 0, 0)

        If nTotalAbsentType > 0 Then
            tdbg.Splits(SPLIT1).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        End If

        If nTotalAbsentType > 0 Then ResetFooterGrid(tdbg, 1, 1)
    End Sub

    Private Sub LoadTDBGrid()
        dtMain = ReturnDataTable(SQLStoreD13P2028())
        gbEnabledUseFind = dtMain.Rows.Count > 0
        LoadDataSource(tdbg, dtMain, gbUnicode)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg_FooterText()
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
        'Dim sSQL As String = ""
        gbEnabledUseFind = True
        'sSQL = "Select * From D13V1234 "
        'sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        'ShowFindDialogClient(Finder, sSQL)
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_DepartmentID, COL_DepartmentName}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)

    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dtMain, sFind)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        tdbg_FooterText()
    End Sub
#End Region

    Dim dtDropDown0 As DataTable
    Private Sub LoadDropDownDataTable_Mode0()
        Dim sSQL As String = ""
        sSQL = "Select Code, ClassificationID, Type,Description" & UnicodeJoin(gbUnicode) & " As Description, Value From  D13T0120 Where Disabled = 0"
        dtDropDown0 = ReturnDataTable(sSQL)
        LoadDataSource(tdbdType, dtDropDown0.Copy, gbUnicode)
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0104s
    '# Created User: dmd
    '# Created Date: 26/11/2009 08:55:25
    '# Modify User: 
    '# Modify Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLInsertD13T0104s() As String
        Dim i As Integer
        Dim iCount As Int32 = 0
        Dim bResult As Boolean

        Dim sSQL As String = ""
        Dim iCol As Integer
        Dim k As Integer

        For i = 0 To tdbg.RowCount - 1
            iCount += 1
            sSQL &= SQLDeleteD13T0104(i) & vbCrLf
            k = 0

            While k < nTotalAbsentType
                sAbsentTypeID = AbsentTypeID(k)
                iCol = COL_Total + 1 + k * 2
                If tdbg(i, iCol).ToString <> "" Or tdbg(i, iCol + 1).ToString <> "" Then
                    If Number(tdbg(i, iCol + 1)) <> 0 Then
                        sSQL &= "Insert Into D13T0104(" & vbCrLf
                        sSQL &= " DivisionID, AbsentVoucherID, BlockID, DepartmentID, TeamID, EmpGroupID, AbsentTypeID," & vbCrLf
                        sSQL &= " PayrollVoucherID, TranMonth, TranYear,  Type, Value, NCodeID" & vbCrLf
                        sSQL &= ") Values (" & vbCrLf

                        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(AbsentVoucherID) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(tdbg(i, COL_BlockID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(tdbg(i, COL_DepartmentID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(tdbg(i, COL_TeamID)) & COMMA 'TeamID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(tdbg(i, COL_EmpGroupID)) & COMMA 'EmpGroupID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(sAbsentTypeID) & COMMA 'AbsentTypeID [KEY], varchar[20], NOT NULL
                        sSQL &= SQLString(_NewPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NULL
                        sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
                        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
                        sSQL &= SQLString(tdbg(i, iCol)) & COMMA 'Type, varchar[20], NULL
                        sSQL &= SQLMoney(tdbg(i, iCol + 1)) & COMMA 'NumberOfDays, decimal, NOT NULL
                        sSQL &= SQLString(tdbg(i, COL_NCodeID))

                        sSQL &= ")" & vbCrLf
                    End If
                End If
                k += 1
            End While
            If iCount = 10 Then
                bResult = ExecuteSQL(sSQL)
                If bResult = True Then
                    iCount = 0
                    sSQL = ""
                    If i = tdbg.RowCount - 1 Then
                        SaveOK()
                        Lemon3.D91.RunAuditLog("13", "TimeSheetRecTrans", "02", c1dateEntryDate.Value.ToString, txtAbsentVoucherNo.Text, _NewPayrollVoucherID, txtRemark.Text, "")
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
        Next
        Return sSQL
    End Function

#Region "tdbg events"

    Private Sub tdbg_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DataSourceChanged
        'Try

        '    tdbg.Row = tdbg.RowCount - 1
        '    tdbg.Row = 0
        'Catch ex As Exception

        'End Try

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

    Private Sub HotKeyEnterGrid(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal nFirstCol As Integer)
        c1Grid.UpdateData()
        Try
            If c1Grid.Col = CountCol(c1Grid, c1Grid.Splits.Count - 1) Then
                With c1Grid
                    .SplitIndex = 1
                    .Row = CInt(IIf(.RowCount = .Row, 0, .Row + 1))
                    .Col = nFirstCol
                    .Focus()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
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
            If tdbg.Splits(i).DisplayColumns(tdbg.Col).Locked = False And tdbg.Splits(i).DisplayColumns(tdbg.Col).Visible = True Then
                If xCheckNum(tdbg.Col) = 1 Then
                    CopyColumns(tdbg, tdbg.Col, SQLNumberD13(tdbg.Columns(tdbg.Col).Text, xNumberFormat(iCol)).ToString, tdbg.Row)
                Else
                    CopyColumns(tdbg, tdbg.Col, tdbg.Row, 2, tdbg.Columns(tdbg.Col).Text)
                End If
                tdbg_FooterText()
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub

        tdbg.Col = e.ColIndex

        If e.ColIndex <= COL_Total Then
            HeadClickTask(tdbg.Col)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    HeadClickTask(tdbg.Col)
                Case Keys.C
                    Clipboard.Clear()
                    If tdbg.Columns(tdbg.Col).Text <> "" Then Clipboard.SetText(tdbg.Columns(tdbg.Col).Text)
                Case Keys.V
                    If tdbg.SplitIndex = 0 Then Exit Select
                    Dim sClipBoard As String = Clipboard.GetText
                    If IsNumeric(sClipBoard) Then
                        If tdbg.Columns(tdbg.Col).DropDown Is Nothing Then
                            tdbg.Columns(tdbg.Col).Text = sClipBoard
                            tdbg.UpdateData()
                        End If
                    End If
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

        ElseIf e.KeyCode = Keys.F9 Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumnF9(tdbg, tdbg.Col, tdbg.Row, tdbg.Columns(tdbg.Col).Text)
                tdbg_FooterText()
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If

        End If
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Dim i As Integer = e.ColIndex
        If xCheckNum(i) = 1 Then
            If tdbg.Columns(i).Text <> "" Then
                If Number(tdbg.Columns(i).Text) <> 0 Then
                    tdbg.Columns(i).Text = (SQLNumberD13(tdbg.Columns(i).Text, xNumberFormat(i))).ToString
                Else
                    tdbg.Columns(i).Text = ""
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
        If bAllowRowColChange = False Then
            Exit Sub
        End If

        If tdbg.Col = e.LastCol Then Exit Sub 'k cho RowColChange chạy 2 lần

        If tdbg.Columns(tdbg.Col).Tag Is Nothing Then Exit Sub

        If xCheckNum(tdbg.Col) = 0 Then
            If dtDropDown0 Is Nothing = False Then
                Dim dt As DataTable = ReturnTableFilter(dtDropDown0, "ClassificationID = " & SQLString(tdbg.Columns(tdbg.Col).Tag.ToString()))
                LoadDataSource(tdbdType, dt, gbUnicode)
            End If
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
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
        tdbg.Columns(tdbg.Col).Text = tdbdType.Columns("Type").Value.ToString
        tdbg.Columns(tdbg.Col + 1).Text = SQLNumberD13(Number(tdbdType.Columns("Value").Value), xNumberFormat(i + 1))
        'dtMain.AcceptChanges()
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

        'If e.ColIndex > 21 Then
        '    If xCellTip(e.ColIndex) = 1 Then
        '        If geLanguage = EnumLanguage.Vietnamese Then
        '            e.CellTip = "Bạn chọn F6 để kế thừa dữ liệu."
        '        ElseIf geLanguage = EnumLanguage.English Then
        '            e.CellTip = "Please, Choose F6 to inherit data."
        '        End If
        '    Else
        '        e.CellTip = ""
        '    End If
        'End If
    End Sub
#End Region

    Dim dtMerge As DataTable

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnFilter.Enabled = False

        LoadTDBGrid()

        bAllowRowColChange = True
        btnFilter.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
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
        sSQL &= "And Key02ID = " & SQLString("D13F2027")
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
        sSQL.Append(SQLString("D13F2027") & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(_AbsentVoucherID)) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

End Class

