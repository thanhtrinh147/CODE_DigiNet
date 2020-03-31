

'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:36:41 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:36:41 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System
Imports System.Windows.Forms
Public Class D13F2042
    Dim report As D99C2003
    Dim dtCaptionCols As DataTable
    Dim sNameGridFocus As String = ""


#Region "Const of tdbg - Total of Columns: 101"
    Private Const COL_IsCheck As Integer = 0            ' Đã kiểm tra
    Private Const COL_EmployeeID As Integer = 1         ' Mã NV
    Private Const COL_FullName As Integer = 2           ' Họ và tên
    Private Const COL_BlockID As Integer = 3            ' Khối
    Private Const COL_BlockName As Integer = 4          ' Tên khối
    Private Const COL_DepartmentID As Integer = 5       ' Phòng ban
    Private Const COL_DepartmentName As Integer = 6     ' Tên phòng ban
    Private Const COL_TeamID As Integer = 7             ' Tổ nhóm
    Private Const COL_TeamName As Integer = 8           ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 9         ' Nhóm nhân viên
    Private Const COL_EmpGroupName As Integer = 10      ' Tên nhóm nhân viên
    Private Const COL_DutyID As Integer = 11            ' Chức vụ
    Private Const COL_DutyName As Integer = 12          ' Tên chức vụ
    Private Const COL_DutyRef01 As Integer = 13         ' DutyRef01
    Private Const COL_DutyRef02 As Integer = 14         ' DutyRef02
    Private Const COL_DutyRef03 As Integer = 15         ' DutyRef03
    Private Const COL_DutyRef04 As Integer = 16         ' DutyRef04
    Private Const COL_DutyRef05 As Integer = 17         ' DutyRef05
    Private Const COL_WorkID As Integer = 18            ' Công việc
    Private Const COL_WorkName As Integer = 19          ' Tên công việc
    Private Const COL_BirthDate As Integer = 20         ' Ngày sinh
    Private Const COL_SexName As Integer = 21           ' Giới tính
    Private Const COL_DateJoined As Integer = 22        ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 23          ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 24               ' Tuổi
    Private Const COL_StatusID As Integer = 25          ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 26        ' Ten trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 27  ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 28     ' Mã nhân viên phụ
    Private Const COL_NumIDCard As Integer = 29         ' Số CMND
    Private Const COL_Mobile As Integer = 30            ' Số mobile
    Private Const COL_Email As Integer = 31             ' Email
    Private Const COL_PaymentMethodName As Integer = 32 ' Phương pháp trả lương
    Private Const COL_BankAccountNo As Integer = 33     ' Số hiệu tài khoản (1)
    Private Const COL_BankID As Integer = 34            ' Ngân hàng
    Private Const COL_BankName As Integer = 35          ' Tên ngân hàng
    Private Const COL_IsSub As Integer = 36             ' HSL phụ
    Private Const COL_ValidDateFrom As Integer = 37     ' Ngày chấm công (Từ)
    Private Const COL_ValidDateTo As Integer = 38       ' Ngày chấm công (Đến)
    Private Const COL_ProjectID As Integer = 39         ' Mã công trình
    Private Const COL_ProjectName As Integer = 40       ' Tên công trình
    Private Const COL_EmployeeTypeID As Integer = 41    ' ĐT lao động
    Private Const COL_EmployeeTypeName As Integer = 42  ' Tên ĐT lao động
    Private Const COL_N01ID As Integer = 43             ' N01ID
    Private Const COL_N02ID As Integer = 44             ' N02ID
    Private Const COL_N03ID As Integer = 45             ' N03ID
    Private Const COL_N04ID As Integer = 46             ' N04ID
    Private Const COL_N05ID As Integer = 47             ' N05ID
    Private Const COL_N06ID As Integer = 48             ' N06ID
    Private Const COL_N07ID As Integer = 49             ' N07ID
    Private Const COL_N08ID As Integer = 50             ' N08ID
    Private Const COL_N09ID As Integer = 51             ' N09ID
    Private Const COL_N10ID As Integer = 52             ' N10ID
    Private Const COL_N11ID As Integer = 53             ' N11ID
    Private Const COL_N12ID As Integer = 54             ' N12ID
    Private Const COL_N13ID As Integer = 55             ' N13ID
    Private Const COL_N14ID As Integer = 56             ' N14ID
    Private Const COL_N15ID As Integer = 57             ' N15ID
    Private Const COL_N16ID As Integer = 58             ' N16ID
    Private Const COL_N17ID As Integer = 59             ' N17ID
    Private Const COL_N18ID As Integer = 60             ' N18ID
    Private Const COL_N19ID As Integer = 61             ' N19ID
    Private Const COL_N20ID As Integer = 62             ' N20ID
    Private Const COL_SalEmpGroupName As Integer = 63   ' Nhóm lương
    Private Const COL_BaseSalary01 As Integer = 64      ' Mức lương cơ bản 1
    Private Const COL_BaseSalary02 As Integer = 65      ' Mức lương cơ bản 2
    Private Const COL_BaseSalary03 As Integer = 66      ' Mức lương cơ bản 3
    Private Const COL_BaseSalary04 As Integer = 67      ' Mức lương cơ bản 4
    Private Const COL_SalCoefficient01 As Integer = 68  ' Hệ số lương 1
    Private Const COL_SalCoefficient02 As Integer = 69  ' Hệ số lương 2
    Private Const COL_SalCoefficient03 As Integer = 70  ' Hệ số lương 3
    Private Const COL_SalCoefficient04 As Integer = 71  ' Hệ số lương 4
    Private Const COL_SalCoefficient05 As Integer = 72  ' Hệ số lương 5
    Private Const COL_SalCoefficient06 As Integer = 73  ' Hệ số lương 6
    Private Const COL_SalCoefficient07 As Integer = 74  ' Hệ số lương 7
    Private Const COL_SalCoefficient08 As Integer = 75  ' Hệ số lương 8
    Private Const COL_SalCoefficient09 As Integer = 76  ' Hệ số lương 9
    Private Const COL_SalCoefficient10 As Integer = 77  ' Hệ số lương 10
    Private Const COL_SalCoefficient11 As Integer = 78  ' SalCoefficient11
    Private Const COL_SalCoefficient12 As Integer = 79  ' SalCoefficient12
    Private Const COL_SalCoefficient13 As Integer = 80  ' SalCoefficient13
    Private Const COL_SalCoefficient14 As Integer = 81  ' SalCoefficient14
    Private Const COL_SalCoefficient15 As Integer = 82  ' SalCoefficient15
    Private Const COL_SalCoefficient16 As Integer = 83  ' SalCoefficient16
    Private Const COL_SalCoefficient17 As Integer = 84  ' SalCoefficient17
    Private Const COL_SalCoefficient18 As Integer = 85  ' SalCoefficient18
    Private Const COL_SalCoefficient19 As Integer = 86  ' SalCoefficient19
    Private Const COL_SalCoefficient20 As Integer = 87  ' SalCoefficient20
    Private Const COL_PaymentDate As Integer = 88       ' Ngày thanh toán
    Private Const COL_BRef01 As Integer = 89            ' BRef01
    Private Const COL_BRef02 As Integer = 90            ' BRef02
    Private Const COL_BRef03 As Integer = 91            ' BRef03
    Private Const COL_BRef04 As Integer = 92            ' BRef04
    Private Const COL_BRef05 As Integer = 93            ' BRef05
    Private Const COL_CreateUserID As Integer = 94      ' Người lập
    Private Const COL_CreateDate As Integer = 95        ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 96  ' Mã người sửa cuối
    Private Const COL_LastModifyDate As Integer = 97    ' Ngày sửa cuối
    Private Const COL_Note As Integer = 98              ' Ghi chú
    Private Const COL_TransID As Integer = 99           ' TransID
    Private Const COL_IsUpdate As Integer = 100         ' IsUpdate
#End Region

#Region "Const of tdbg2"
    Private Const COL2_EmployeeID As Integer = 0           ' Mã
    Private Const COL2_FirstName As Integer = 1            ' Tên
    Private Const COL2_FullName As Integer = 2             ' Họ và tên
    Private Const COL2_PaymentMethodName As Integer = 3    ' Phương pháp trả lương
    Private Const COL2_BankID As Integer = 4               ' BankID
    Private Const COL2_BankName As Integer = 5             ' Ngân hàng
    Private Const COL2_BankAccountNo As Integer = 6        ' Số tài khoản
    Private Const COL2_Note As Integer = 7                 ' Ghi chú
    Private Const COL2_IsUpdateNotBelongDiv As Integer = 8 ' Cập nhật
#End Region


    Private COL_Total As Integer = 100          ' IsUpdate

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D13U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList 'Mảng Detail
    '*****************************************
#End Region

    'Private usrOption_1 As New D09U1111()
    'Dim dtF12_1 As DataTable
    Private usrOption_2 As New D99U1111()
    Dim dtF12_2 As DataTable

    Public isBringToFront As Boolean = False

    '*các giá trị này dùng để in báo cáo diễn giải lương
    Dim sMinDate As String
    Dim sMaxDate As String
    Dim sDepartmentIDFrom As String
    Dim sDepartmentIDTo As String
    Dim sTeamIDFrom As String
    Dim sTeamIDTo As String
    '-*

    Private _salaryVoucherID As String = ""
    Private _payrollVoucherID As String = ""
    Private _salCalMethodID As String = ""
    Private bBA As SALBA
    Private bCE As SALCE
    'Private bTNH As TNH
    Private dt As DataTable
    Private dt1 As DataTable
    '   Private dt2 As DataTable

    Dim dtBlockID, dtDepartmentID, dtTeamID, dtEmpGroupID As DataTable
    Private sCaption As String
    Private Const iColBASEFrom As Integer = 6
    Private Const iColBASETo As Integer = 9
    Private Const iColCEFrom As Integer = 10
    Private Const iColCETo As Integer = 19
    Private Const iColTNHFrom As Integer = 20
    Private Const iColTNHTo As Integer = 99

    Dim dtLoadCaPTION As DataTable

    Dim iPerD13F2040 As Integer
    Dim iPerD13F5607 As Integer = 0

    Public Property SalaryVoucherID() As String
        Get
            Return _salaryVoucherID
        End Get
        Set(ByVal value As String)
            If SalaryVoucherID = value Then
                _salaryVoucherID = ""
                Return
            End If
            _salaryVoucherID = value
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

    Public Property SalCalMethodID() As String
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal value As String)
            If SalCalMethodID = value Then
                _salCalMethodID = ""
                Return
            End If
            _salCalMethodID = value
        End Set
    End Property

    Private _salaryVoucherNo As String = ""
    Public Property SalaryVoucherNo() As String
        Get
            Return _salaryVoucherNo
        End Get
        Set(ByVal Value As String)
            _salaryVoucherNo = Value
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

    Private _transferMethodID As String = ""
    Public Property TransferMethodID() As String
        Get
            Return _transferMethodID
        End Get
        Set(ByVal Value As String)
            _transferMethodID = Value
        End Set
    End Property

    Private _voucherDate As String = ""
    Public Property VoucherDate() As String
        Get
            Return _voucherDate
        End Get
        Set(ByVal Value As String)
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

    Private Sub D13F2042_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsOpenD13F2046 = 0 AndAlso btnComparePaymentData.Enabled Then
            Try
                Dim dtcheck As DataTable = Nothing
                If CheckStore(SQLStoreD13P5555().ToString(), "", dtcheck) Then
                    If L3Int(dtcheck.Rows(0).Item("Status")) = 0 Then Exit Sub
                    IsOpenD13F2046 = 1
                    Dim frm As New D13F2046
                    frm.SalaryVoucherID = _salaryVoucherID
                    frm.StartPosition = FormStartPosition.CenterScreen
                    frm.ShowDialog()
                    e.Cancel = True
                Else

                End If
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub

    '    ' Update 17/6/2012 incident 50067 - xét xem có dang ở usercontrol ko??
    '    Private Function UsrFocused() As Boolean
    '        For Each ctrl As Control In usrOption.Controls
    '            If ctrl.Focused Then
    '                Return True
    '            End If
    '        Next
    '        Return False
    '    End Function

    Private Sub D13F2042_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
            Case Keys.Escape
                ' usrOption_1.picClose_Click(Nothing, Nothing)
                usrOption_2.picClose_Click(Nothing, Nothing)

                If giRefreshUserControl = 0 Then
                    If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                        usrOption.D09U1111Refresh()
                    End If
                End If
                usrOption.Hide()
        End Select

        'If e.KeyCode = Keys.Enter Then
        '    ' Update 17/6/2012 incident 50067
        '    If usrOption IsNot Nothing And usrOption.Active Then ' Nếu usercontrol đang mở và có đang chọn 1 control nào đó của usercontrol
        '        If UsrFocused() Then
        '            usrOption.D09U1111_KeyDown(sender, e)
        '        Else
        '            UseEnterAsTab(Me, True)
        '        End If
        '    Else
        '        UseEnterAsTab(Me, True)
        '    End If
        '    '  UseEnterAsTab(Me, True)
        '    Exit Sub
        'End If


        '        '***************************************
        '        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        '        If e.KeyCode = Keys.F12 Then ' Mở
        '            btnF12_Click(Nothing, Nothing)
        '        ElseIf e.KeyCode = Keys.F5 Then
        '            btnFilter_Click(Nothing, Nothing)
        '        End If
        If e.KeyCode = Keys.Escape Then 'Đóng

        End If
        '***************************************
    End Sub

    Private Sub UseEnterAsTab(ByVal frm As Form, Optional ByVal bForward As Boolean = True)
        Try
            Select Case frm.ActiveControl.GetType.Name
                Case "GridEditor", "C1TrueDBGrid" ' Không làm
                Case "SplitContainer"
                    Dim SplitCon As SplitContainer = CType(frm.ActiveControl, SplitContainer)
                    UseEnterAsTab(SplitCon, bForward)
                Case Else
                    If frm.ActiveControl.GetType.BaseType.Name = "UserControl" Then
                        Dim uc As UserControl = CType(frm.ActiveControl, UserControl)
                        UseEnterAsTab(uc, bForward)
                        Exit Sub
                    End If
                    frm.SelectNextControl(frm.ActiveControl, bForward, True, True, False)
            End Select
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private Sub UseEnterAsTab(ByVal SplitCon As SplitContainer, Optional ByVal bForward As Boolean = True)
        Try
            If (SplitCon.ActiveControl.GetType.Name = "GridEditor") Or (SplitCon.ActiveControl.GetType.Name = "C1TrueDBGrid") Then 'Khong phai luoi
                Exit Sub
            End If
            If SplitCon.ActiveControl.GetType.BaseType.Name = "UserControl" Then
                Dim uc As UserControl = CType(SplitCon.ActiveControl, UserControl)
                UseEnterAsTab(uc, bForward)
            Else
                SplitCon.SelectNextControl(SplitCon.ActiveControl, bForward, True, True, False)
            End If
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private Sub UseEnterAsTab(ByVal uc As UserControl, Optional ByVal bForward As Boolean = True)
        Try
            Select Case uc.ActiveControl.GetType.Name
                Case "GridEditor", "C1TrueDBGrid" ' Không làm
                Case "SplitContainer"
                    Dim SplitCon As SplitContainer = CType(uc.ActiveControl, SplitContainer)
                    UseEnterAsTab(SplitCon, bForward)
                Case Else
                    uc.SelectNextControl(uc.ActiveControl, bForward, True, True, False)
            End Select
        Catch ex As Exception
            D99C0008.Msg("Lỗi UseEnterAsTab: " & ex.Message)
        End Try
    End Sub

    Private gbEnabledUseFind As Boolean = False
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdEmployeeID
        sSQL = SQLStoreD13P2601()
        Dim dtEmployee As DataTable
        dtEmployee = ReturnDataTable(sSQL)
        LoadDataSource(tdbdEmployeeID, dtEmployee.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbdEmployeeFirstName, dtEmployee.DefaultView.ToTable, gbUnicode)
    End Sub
    Dim bIsSalOtherDiv As Boolean = False
    Private Sub IsSalOtherDiv()
        Dim sSQL As String = ""
        sSQL = "SELECT IsSalOtherDiv FROM D13T0000"
        bIsSalOtherDiv = L3Bool(ReturnScalar(sSQL))
    End Sub

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_FullName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_PaymentMethodName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_BankName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_BankAccountNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        If dtGird2 IsNot Nothing Then
            tdbg2.UpdateData()
            mnuC201.Enabled = dtGird2.Rows.Count > 0 And Not gbClosed
        End If
    End Sub

    Private Sub tdbg2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.Click
        sNameGridFocus = tdbg2.Name
    End Sub

    Private Sub tdbg2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.GotFocus
        sNameGridFocus = tdbg2.Name
    End Sub
    Public Function CheckDuplicateRow(ByVal dt As DataTable, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iColumnName As Integer) As Boolean
        'Tại sự kiện tdbgMainProduct_BeforeColUpdate gán e.Cancel = CheckDuplicateRow(dtgrid, tdbg, COL_AccountID)
        Dim sWhereClause As String = tdbg.Columns(iColumnName).DataField.ToString & "=" & SQLString(tdbg.Columns(iColumnName).Text)
        Dim iFind As Integer = dt.Select(sWhereClause).Length
        If iFind > 0 AndAlso dt.Rows.IndexOf(dt.Select(sWhereClause)(0)) <> tdbg.Row Then
            ' "Bạn đã chọn trùng" nối với tên cột kiểm tra
            D99C0008.MsgDuplicatePKey()
            Return True
        End If
        Return False
    End Function

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL2_EmployeeID
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                Else
                    e.Cancel = CheckDuplicateRow(dtGird2, tdbg2, e.ColIndex)

                End If
            Case COL2_FirstName
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                Else
                    Dim strEmploymentID As String
                    strEmploymentID = tdbdEmployeeFirstName.Columns("EmployeeID").Text
                    For i As Integer = 0 To tdbg2.RowCount - 1
                        If tdbg2.Row <> i AndAlso strEmploymentID = tdbg2(i, COL2_EmployeeID).ToString() Then
                            e.Cancel = True
                            D99C0008.MsgDuplicatePKey()
                            tdbg2.Focus()
                            tdbg2.Col = COL2_FirstName
                            Exit For
                        End If
                    Next
                End If
        End Select
    End Sub


    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        tdbg2.Columns(COL2_IsUpdateNotBelongDiv).Text = "1"
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL2_EmployeeID
                If tdbg2.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg2.Columns(COL2_EmployeeID).Text = ""
                    tdbg2.Columns(COL2_FullName).Text = ""
                    tdbg2.Columns(COL2_PaymentMethodName).Text = ""
                    tdbg2.Columns(COL2_BankID).Text = ""
                    tdbg2.Columns(COL2_BankName).Text = ""
                    tdbg2.Columns(COL2_BankAccountNo).Text = ""
                    Exit Select
                End If
                'tdbg2.Columns(COL2_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                tdbg2.Columns(COL2_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                tdbg2.Columns(COL2_FullName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_PaymentMethodName).Text = tdbdEmployeeID.Columns("PaymentMethodName").Text
                tdbg2.Columns(COL2_BankID).Text = tdbdEmployeeID.Columns("BankID").Text
                tdbg2.Columns(COL2_BankName).Text = tdbdEmployeeID.Columns("BankName").Text
                tdbg2.Columns(COL2_BankAccountNo).Text = tdbdEmployeeID.Columns("BankAccountNo").Text
                Exit Select
            Case COL2_FirstName
                If tdbg2.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg2.Columns(COL2_EmployeeID).Text = ""
                    tdbg2.Columns(COL2_FullName).Text = ""
                    tdbg2.Columns(COL2_PaymentMethodName).Text = ""
                    tdbg2.Columns(COL2_BankID).Text = ""
                    tdbg2.Columns(COL2_BankName).Text = ""
                    tdbg2.Columns(COL2_BankAccountNo).Text = ""
                    Exit Select
                End If
                tdbg2.Columns(COL2_EmployeeID).Text = tdbdEmployeeFirstName.Columns("EmployeeID").Text
                'tdbg2.Columns(COL2_FirstName).Text = tdbdEmployeeFirstName.Columns("FirstName").Text
                tdbg2.Columns(COL2_FullName).Text = tdbdEmployeeFirstName.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_PaymentMethodName).Text = tdbdEmployeeFirstName.Columns("PaymentMethodName").Text
                tdbg2.Columns(COL2_BankID).Text = tdbdEmployeeFirstName.Columns("BankID").Text
                tdbg2.Columns(COL2_BankName).Text = tdbdEmployeeFirstName.Columns("BankName").Text
                tdbg2.Columns(COL2_BankAccountNo).Text = tdbdEmployeeFirstName.Columns("BankAccountNo").Text
                Exit Select
            Case COL2_PaymentMethodName
            Case COL2_BankID
            Case COL2_BankName
            Case COL2_BankAccountNo
            Case COL2_Note
            Case COL2_IsUpdateNotBelongDiv
        End Select
        tdbg2_FooterText()
        If dtGird2 IsNot Nothing Then
            mnuC201.Enabled = dtGird2.Rows.Count > 0 And Not gbClosed
        End If
    End Sub



    Private Sub ButtonD09T0010()
        Dim sSQL As String = ""
        sSQL &= " Select TypeID Code, Description" & UnicodeJoin(gbUnicode) & " Short, Disabled From D09T0010  WITH(NOLOCK) Order By Code "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        'bUseANAD09T0010 = dt.Select("Disabled = 0").Length > 0
        tdbg.Columns(COL_N01ID).Tag = L3Bool(IIf(dt.Rows(0).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N02ID).Tag = L3Bool(IIf(dt.Rows(1).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N03ID).Tag = L3Bool(IIf(dt.Rows(2).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N04ID).Tag = L3Bool(IIf(dt.Rows(3).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N05ID).Tag = L3Bool(IIf(dt.Rows(4).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N06ID).Tag = L3Bool(IIf(dt.Rows(5).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N07ID).Tag = L3Bool(IIf(dt.Rows(6).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N08ID).Tag = L3Bool(IIf(dt.Rows(7).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N09ID).Tag = L3Bool(IIf(dt.Rows(8).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N10ID).Tag = L3Bool(IIf(dt.Rows(9).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N11ID).Tag = L3Bool(IIf(dt.Rows(10).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N12ID).Tag = L3Bool(IIf(dt.Rows(11).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N13ID).Tag = L3Bool(IIf(dt.Rows(12).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N14ID).Tag = L3Bool(IIf(dt.Rows(13).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N15ID).Tag = L3Bool(IIf(dt.Rows(14).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N16ID).Tag = L3Bool(IIf(dt.Rows(15).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N17ID).Tag = L3Bool(IIf(dt.Rows(16).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N18ID).Tag = L3Bool(IIf(dt.Rows(17).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N19ID).Tag = L3Bool(IIf(dt.Rows(18).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_N20ID).Tag = L3Bool(IIf(dt.Rows(19).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_N01ID).Caption = dt.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_N02ID).Caption = dt.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_N03ID).Caption = dt.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_N04ID).Caption = dt.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_N05ID).Caption = dt.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_N06ID).Caption = dt.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_N07ID).Caption = dt.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_N08ID).Caption = dt.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_N09ID).Caption = dt.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_N10ID).Caption = dt.Rows(9).Item("Short").ToString
        tdbg.Columns(COL_N11ID).Caption = dt.Rows(10).Item("Short").ToString
        tdbg.Columns(COL_N12ID).Caption = dt.Rows(11).Item("Short").ToString
        tdbg.Columns(COL_N13ID).Caption = dt.Rows(12).Item("Short").ToString
        tdbg.Columns(COL_N14ID).Caption = dt.Rows(13).Item("Short").ToString
        tdbg.Columns(COL_N15ID).Caption = dt.Rows(14).Item("Short").ToString
        tdbg.Columns(COL_N16ID).Caption = dt.Rows(15).Item("Short").ToString
        tdbg.Columns(COL_N17ID).Caption = dt.Rows(16).Item("Short").ToString
        tdbg.Columns(COL_N18ID).Caption = dt.Rows(17).Item("Short").ToString
        tdbg.Columns(COL_N19ID).Caption = dt.Rows(18).Item("Short").ToString
        tdbg.Columns(COL_N20ID).Caption = dt.Rows(19).Item("Short").ToString

        For i As Integer = COL_N01ID To COL_N20ID
            '    'tdbg.Splits(SPLIT1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = L3Bool(tdbg.Columns(i).Tag)
            '    tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True

        Next

    End Sub

    Private Sub D13F2042_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        IsSalOtherDiv()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        CheckPermission()
        Loadlanguage()
        SetBackColorObligatory()
        AddColumnTNH1()
        ButtonD09T0010()
        If bIsSalOtherDiv Then
            tdbg2.Enabled = False
            AddColumnTNH2()
            LoadTDBDropDown()
            ResetSplitDividerSize(tdbg2)
            Panel1.Visible = True
            tdbg2.Visible = True
        Else
            Panel1.Visible = False
            tdbg2.Visible = False
            tdbg.Height = grp1.Height - 20
        End If
        tdbcBlockID.AutoCompletion = False
        tdbcEmpGroupID.AutoCompletion = False
        LoadTDBCombo()
        ResetSplitDividerSize(tdbg)


        tdbg_LockedColumns()
        tdbg2_LockedColumns()
        ShowD13T9000()
        ShowColumns()
        tdbg_NumberFormat()

        LoadDefaultValue()

        If isBringToFront Then Me.TopMost = True
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuEmployeeRecord.Enabled = tdbg.RowCount > 0
        mnuPieceworkRecordingDetail.Enabled = tdbg.RowCount > 0
        mnuTransferByEmail.Enabled = tdbg.RowCount > 0
        mnuUpdateBankID.Enabled = tdbg.RowCount > 0
        sNameGridFocus = tdbg.Name
        mnuPaymentbyProject.Visible = D13Systems.IsPayrollProject
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        CallD09U1111_Button(True)
        '*****************************************
        ' CallD99U1111_1()
        CallD99U1111_2()

        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtEmployeeID)
        '*****************************************
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft, COL_ValidDateFrom, COL_ValidDateTo, COL_PaymentDate)
        tdbg.Enabled = False
        DisabledWhenCallClosed()
        SetResolutionForm(Me, Me.C1ContextMenu)
        Me.TopMost = False
    End Sub

    Private Sub DisabledWhenCallClosed()
        btnSave.Enabled = btnSave.Enabled And Not gbClosed
        'btnAction.Enabled = btnAction.Enabled And Not gbClosed
        btnComparePaymentData.Enabled = btnComparePaymentData.Enabled And Not gbClosed
        btnAdjustAttendance.Enabled = btnAdjustAttendance.Enabled And Not gbClosed
        btnCalculateParoll.Enabled = btnCalculateParoll.Enabled And Not gbClosed
        mnuPieceworkRecordingDetail.Enabled = mnuPieceworkRecordingDetail.Enabled And Not gbClosed
        mnuTransferByEmail.Enabled = mnuTransferByEmail.Enabled And Not gbClosed
        mnuUpdateBankID.Enabled = mnuUpdateBankID.Enabled And Not gbClosed
        mnuC201.Enabled = mnuC201.Enabled And Not gbClosed
        mnuGird2ImportData.Enabled = mnuGird2ImportData.Enabled And Not gbClosed
    End Sub
    'Private Sub CallD99U1111_1()
    '    Dim arrColObligatory() As Object = {COL_IsCheck, COL_EmployeeID}
    '    usrOption_1.AddColVisible(tdbg, dtF12_1, arrColObligatory, 0)
    '    If usrOption_1 IsNot Nothing Then usrOption_1.Dispose()
    '    usrOption_1 = New D09U1111(tdbg, dtF12_1, "D13", Me.Name)
    'End Sub

    Private Sub CallD99U1111_2()
        Dim arrColObligatory() As Object = {COL2_EmployeeID}
        usrOption_2.AddColVisible(tdbg2, dtF12_2, arrColObligatory, 1)
        If usrOption_2 IsNot Nothing Then usrOption_2.Dispose()
        usrOption_2 = New D99U1111(Me, tdbg2, dtF12_2, 1)
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)

        'Dim arrColObligatory() As Object = {COL_IsCheck, COL_EmployeeID}
        'usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        'If usrOption IsNot Nothing Then usrOption.Dispose()
        'usrOption = New D99U1111(Me, tdbg, dtF12)


        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_IsCheck, COL_EmployeeID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            '-----------------------------------
            'Các cột ở SPLIT1
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            'Các cột ở SPLIT2
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
            'Các cột ở SPLIT2
            AddColVisible(tdbg, SPLIT3, arrMaster, arrColObligatory, , , gbUnicode)
            'Các cột ở SPLIT2
            AddColVisible(tdbg, 4, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()

        '   dtCaptionCols.Columns.Add("DisplayTempID")
        usrOption = New D13U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_EmployeeID To COL_EmployeeTypeName
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next

        For i As Integer = COL_N01ID To COL_N20ID
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next


        For i As Integer = COL_BaseSalary01 To COL_SalCoefficient20 'COL_TNH99
            tdbg.Splits(SPLIT2).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT2).DisplayColumns(i).Locked = True
        Next

        For i As Integer = COL_BRef01 To COL_BRef05 'COL_TNH99
            tdbg.Splits(3).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(3).DisplayColumns(i).Locked = True
        Next

    End Sub

    Private Sub LoadDefaultValue()
        Dim dt As New DataTable
        dt = ReturnDataTable("Select IsUseBlock From D09T0000  WITH(NOLOCK) ")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("IsUseBlock").ToString <> "1" Then
                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Visible = False
                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Visible = False
                ReadOnlyControl(tdbcBlockID)
            End If
        End If
        tdbcBlockID.SelectedValue = "%"
        dt = Nothing

        Dim sSQL As String = "--Lay trang thai an hien menu bang luong theo du an" & vbCrLf & _
            "SELECT TOP 1 1 FROM D13T0000 WITH(NOLOCK) WHERE IsPayrollProject = 1"
        mnuPaymentbyProject.Visible = ExistRecord(sSQL)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmpGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Bang_luong_CBCNV_-_D13F2042") & UnicodeCaption(gbUnicode) 'B¶ng l§¥ng CBCNV - D13F2042
        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rL3("Ma_nhan_vien") 'Mã nhân viên có chứa
        lblEmployeeName.Text = rL3("Ho_va_ten") 'Họ và Tên
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblEmpGroupID.Text = rL3("Nhom_nhan_vien") 'Nhóm nhân viên

        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên

        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rL3("Ma") 'Mã
        tdbcEmpGroupID.Columns("EmpGroupName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        btnAction.Text = rL3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        btnCalculateParoll.Text = rL3("Tinh_luon_g") 'Tính lươn&g
        btnAdjustAttendance.Text = rL3("_Cap_nhat_phieu_dieu_chinh_thu_nhap")
        btnAdjustPayroll.Text = rL3("Die_u_chinh_luong") ' Điề&u chỉnh lương
        btnSave.Text = rL3("_Luu") '&Lưu
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnF12.Text = "&" & rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rL3("Khoi") 'Khối
        tdbg.Columns("DepartmentID").Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rL3("Nhom_NV") 'Nhóm nhân viên
        tdbg.Columns("EmpGroupName").Caption = rL3("Ten_nhom_NV") 'Tên nhóm nhân viên
        tdbg.Columns("EmployeeID").Caption = rL3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rL3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns("DateJoined").Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("DateLeft").Caption = rL3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbg.Columns("DutyID").Caption = rL3("Chuc_vu") 'Mã chức vụ
        tdbg.Columns("DutyName").Caption = rL3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns("Mobile").Caption = rL3("So_Mobile") ' Số mobile
        tdbg.Columns("PaymentMethodName").Caption = rL3("Phuong_phap_tra_luong")

        ' update 13/8/2013 id 57965
        tdbg.Columns("BankAccountNo").Caption = rL3("So_tai_khoan")
        tdbg.Columns("BankID").Caption = rL3("Ngan_hang")
        tdbg.Columns("BankName").Caption = rL3("Ten_ngan_hang")
        tdbg.Columns("IsSub").Caption = rL3("HSL_phu") 'HSL phụ
        tdbg.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ

        tdbg.Columns("SalEmpGroupName").Caption = rL3("Nhom_luong") 'Nhóm lương

        tdbg.Columns("BaseSalary01").Caption = rL3("Muc_luong_co_ban_1") 'Mức lương cơ bản 1
        tdbg.Columns("BaseSalary02").Caption = rL3("Muc_luong_co_ban_2") 'Mức lương cơ bản 2
        tdbg.Columns("BaseSalary03").Caption = rL3("Muc_luong_co_ban_3") 'Mức lương cơ bản 3
        tdbg.Columns("BaseSalary04").Caption = rL3("Muc_luong_co_ban_4") 'Mức lương cơ bản 4
        tdbg.Columns("SalCoefficient01").Caption = rL3("He_so_luong_1") 'Hệ số lương 1
        tdbg.Columns("SalCoefficient02").Caption = rL3("He_so_luong_2") 'Hệ số lương 2
        tdbg.Columns("SalCoefficient03").Caption = rL3("He_so_luong_3") 'Hệ số lương 3
        tdbg.Columns("SalCoefficient04").Caption = rL3("He_so_luong_4") 'Hệ số lương 4
        tdbg.Columns("SalCoefficient05").Caption = rL3("He_so_luong_5") 'Hệ số lương 5
        tdbg.Columns("SalCoefficient06").Caption = rL3("He_so_luong_6") 'Hệ số lương 6
        tdbg.Columns("SalCoefficient07").Caption = rL3("He_so_luong_7") 'Hệ số lương 7
        tdbg.Columns("SalCoefficient08").Caption = rL3("He_so_luong_8") 'Hệ số lương 8
        tdbg.Columns("SalCoefficient09").Caption = rL3("He_so_luong_9") 'Hệ số lương 9
        tdbg.Columns("SalCoefficient10").Caption = rL3("He_so_luong_10") 'Hệ số lương 10
        tdbg.Columns("IsCheck").Caption = rL3("Da_kiem_tra") 'Đã kiểm tra
        tdbg.Columns("ValidDateFrom").Caption = rL3("Ngay_cham_cong") & " (" & rL3("Tu") & ")"
        tdbg.Columns("ValidDateto").Caption = rL3("Ngay_cham_cong") & " (" & rL3("Den") & ")"
        tdbg.Columns("PaymentDate").Caption = rL3("Ngay_thanh_toan") 'Ngày thanh toán

        tdbg.Columns("ProjectID").Caption = rL3("Ma_cong_trinh")
        tdbg.Columns("ProjectName").Caption = rL3("Ten_cong_trinh")

        ' update 15/11/2012 id 51174
        tdbg.Columns("BlockName").Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns("Birthdate").Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("SexName").Caption = rL3("Gioi_tinh")
        tdbg.Columns("WorkID").Caption = rL3("Cong_viec")
        tdbg.Columns("WorkName").Caption = rL3("Ten_cong_viec")
        tdbg.Columns("Age").Caption = rL3("Tuoi")
        tdbg.Columns("StatusID").Caption = rL3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rL3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rL3("Ma_the_cham_cong")

        tdbg.Columns("EmployeeTypeID").Caption = rL3("Doi_tuong_lao_dong") ' Đối tượng lao động
        tdbg.Columns("EmployeeTypeName").Caption = rL3("Ten_doi_tuong_lao_dong") ' Tên đối tượng lao động

        'update 27/12/2012 id 53344
        tdbg.Columns("NumIDCard").Caption = rL3("So_CMND")
        '================================================================ 
        mnuEmployeeRecord.Text = rL3("_Ho_so_nhan_vien") '&Hồ sơ nhân viên
        mnuDetailResultSalCalculation.Text = rL3("Chi_tiet_ket_qua_tinh_luong_san_pham") 'Chi tiết kết quả tính lương sản phẩm
        mnuStyle1.Text = rL3("Mau") & " 1" 'Mẫu 1
        mnuStyle2.Text = rL3("Mau") & " 2" 'Mẫu 2
        mnuStyle3.Text = rL3("Mau") & " 3" 'Mẫu 3
        mnuStyle4.Text = rL3("Mau") & " 4" 'Mẫu 4
        mnuStyle5.Text = rL3("Mau") & " 5" 'Mẫu 5
        mnuStyle6.Text = rL3("Mau") & " 6" 'Mẫu 6
        mnuStyle7.Text = rL3("Mau") & " 7" 'Mẫu 7
        mnuStyle8.Text = rL3("Mau") & " 8" 'Mẫu 8
        mnuStyle9.Text = rL3("Mau") & " 9" 'Mẫu 9
        mnuStyle10.Text = rL3("Mau") & " 10" 'Mẫu 10
        mnuSalaryDescription.Text = rL3("Phieu_luong") 'Phiếu lương
        mnuFind.Text = rL3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rL3("Lich_su_tac_dong")
        mnuSalaryCongure.Text = rL3("Thiet_lap_bang_luong")
        mnuMark.Text = rL3("Chi_tiet_cham_cong_san_pham")
        mnuTransferByEmail.Text = rL3("Chuyen_bang_luong_qua_e-_mail") 'Chuyển bảng lương qua e-&mail
        mnuExportToExcel.Text = rL3("Xuat__Excel") 'Xuất &Excel

        mnuPaymentbyProject.Text = "&" & rL3("Bang_luong_theo_du_an")  'Bảng lương theo dự án

        '================================================================ 
        lbl1111.Text = rL3("Luong_ben_ngoai") 'Lương bên ngoài
        '================================================================ 
        tdbdEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbdEmployeeID.Columns("EmployeeName").Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbdEmployeeID.Columns("PaymentMethodName").Caption = rL3("Phuong_phap_tra_luong") 'Phương pháp trả lương
        tdbdEmployeeID.Columns("BankName").Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbdEmployeeID.Columns("BankAccountNo").Caption = rL3("So_tai_khoan") 'Số tài khoản
        '================================================================ 
        tdbg2.Columns(COL2_EmployeeID).Caption = rL3("Ma") 'Mã
        tdbg2.Columns(COL2_FirstName).Caption = rL3("Ten") 'Mã
        tdbg2.Columns(COL2_FullName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg2.Columns(COL2_PaymentMethodName).Caption = rL3("Phuong_phap_tra_luong") 'Phương pháp trả lương
        tdbg2.Columns(COL2_BankName).Caption = rL3("Ngan_hang") 'Ngân hàng
        tdbg2.Columns(COL2_BankAccountNo).Caption = rL3("So_tai_khoan") 'Số tài khoản
        tdbg2.Columns(COL2_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg2.Columns(COL2_IsUpdateNotBelongDiv).Caption = rL3("Cap_nhat") 'Cập nhật
        mnuPieceworkRecordingDetail.Text = rL3("Chi_tiet_cham_cong_san_pham")
        mnuMark1.Text = rL3("Dang") & " 1"
        mnuMark2.Text = rL3("Dang") & " 2"
        mnuUpdateBankID.Text = rL3("_Cap_nhat_ngan_hang_chuyen_khoan")
        mnuC201.Text = rL3("_Cap_nhat_ngan_hang_chuyen_khoan")
        '================================================================ 
        btnComparePaymentData.Text = rL3("Doi_chieu_du_lieu_tinh_luong") 'Đối chiếu dữ liệu tính lương
        mnuGird2ImportData.Text = rL3("Import_du_lieu")


    End Sub

    Private Sub LoadTDBCombo()

        dtEmpGroupID = ReturnTableEmpGroupID(True, gbUnicode)
        dtTeamID = ReturnTableTeamID(True, True, gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, True, gbUnicode)

        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
    End Sub

#Region "Events tdbcBlockID load tdbcDepartmentID"

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = ""
    End Sub


#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        '        If Not tdbcDepartmentID.SelectedValue Is Nothing Then
        '            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        '        Else
        '            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        '        End If
        '        tdbcTeamID.SelectedIndex = 0

        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", gbUnicode)
        End If

        tdbcTeamID.SelectedValue = "%"




    End Sub
#End Region

#Region "Events tdbcTeamID with txtTeamName"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcEmpGroupID"

    Private Sub tdbcEmpGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.LostFocus
        If tdbcEmpGroupID.FindStringExact(tdbcEmpGroupID.Text) = -1 Then tdbcEmpGroupID.Text = ""
    End Sub


    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, "-1", "-1", "-1", gbUnicode)
        End If

        tdbcEmpGroupID.SelectedValue = "%"

    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcBlockID.BeforeOpen, tdbcEmpGroupID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcBlockID.Close, tdbcEmpGroupID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcBlockID.KeyUp, tdbcEmpGroupID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcBlockID.Validated, tdbcEmpGroupID.Validated

        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        btnFilter.Enabled = False
        If Not AllowFilter() Then Exit Sub
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
        btnFilter.Enabled = True
        tdbg2.Enabled = True
        tdbg.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        Return True
    End Function
    Dim dtGird2 As DataTable
    Dim dtGird2Delete As DataTable

    Private Sub LoadTDBGrid(Optional ByVal bFlag As Boolean = False, Optional ByVal imode As Integer = -1)
        Dim sSQL As String = SQLStoreD13P3502()
        Dim dataTable As DataTable
        dataTable = ReturnDataTable(sSQL)
        If imode <> 1 Then
            dtFind = ReturnTableFilter(dataTable, "IsNotBelongDiv = 0", True)
            LoadDataSource(tdbg, dtFind, gbUnicode)
        End If
        If bIsSalOtherDiv Then
            If imode <> 0 Then
                dtGird2 = ReturnTableFilter(dataTable, "IsNotBelongDiv = 1", True)
                LoadDataSource(tdbg2, dtGird2, gbUnicode)
                dtGird2Delete = dtGird2.Clone()
                mnuC201.Enabled = dtGird2.Rows.Count > 0 And Not gbClosed
                tdbg2_FooterText()
            End If
        End If
        ReLoadTDBGrid()
    End Sub

    Dim iColTNH As Integer = 0 ' Tống số cột TNH được add vào
    Private dtColRef As DataTable

    ' update 13/6/2013 id 56314 - bổ sung 100 cột TNH (Chuyển 200 cột TNH sang cột đông)
    Private iColIndexRef As Integer = -1
    Private Sub AddColumnTNH1()
        Dim sSQL As String = "-- Load 200 cot TNH dong" & vbCrLf
        sSQL &= "Select SalCalMethodID, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " +'( '+ CalNo +' )' ShortName, " & vbCrLf
        sSQL &= "IsNotPrint, Decimals, Formular,  FormularDesc" & UnicodeJoin(gbUnicode) & " As FormularDesc, " & vbCrLf
        sSQL &= "ProcessOrderNum, 'TNH' + RTRIM(LTRIM(Substring(CalNo,4, LEN(CalNo)-3))) AS FieldName" & vbCrLf
        sSQL &= "From D13T2501  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(_salCalMethodID) & " AND Disabled = 0 Order By ProcessOrderNum" 'CalNo ") ' update 5/6/2013 id 56508

        Dim dtColTNH As DataTable = ReturnDataTable(sSQL)
        If dtColTNH Is Nothing OrElse dtColTNH.Rows.Count <= 0 Then Exit Sub
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        iColTNH = dtColTNH.Rows.Count
        For iCol As Integer = 0 To dtColTNH.Rows.Count - 1
            ' Add cột Type vào lưới
            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc.DataField = dtColTNH.Rows(iCol).Item("FieldName").ToString
            tdbg.Columns.Add(dc)
            dc.Caption = dtColTNH.Rows(iCol).Item("ShortName").ToString
            tdbg.Splits(2).DisplayColumns(dc).Width = 80
            tdbg.Splits(2).DisplayColumns(dc).Visible = True
            'tdbg.Splits(SPLIT2).DisplayColumns(COL_TNH01 + i).Visible = L3Bool(IIf(dt2.Rows(i).Item("Disabled").ToString = "0" And dt2.Rows(i).Item("IsNotPrint").ToString = "0", True, False))
            tdbg.Splits(2).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Splits(2).DisplayColumns(dc).Style.Font = FontUnicode(gbUnicode)
            tdbg.Splits(2).DisplayColumns(dc).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            tdbg.Columns(dc.DataField).NumberFormat = InsertFormat(dtColTNH.Rows(iCol).Item("Decimals").ToString)
            tdbg.Splits(2).DisplayColumns(dc).Locked = True
            tdbg.Splits(2).DisplayColumns(dc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            'Gan tag Formula
            If D13Options.ShowFormular Then
                tdbg.Columns(dc.DataField).Tag = dtColTNH.Rows(iCol).Item("Formular").ToString
            Else
                tdbg.Columns(dc.DataField).Tag = dtColTNH.Rows(iCol).Item("FormularDesc").ToString
            End If

            ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
            sFieldSum_Group(UBound(sFieldSum_Group)) = COL_Total + iCol + 1
        Next

        sSQL = "-- Do caption dong thong tin tham chieu" & vbCrLf
        sSQL &= "SELECT 		RefID, RefCaptionU AS RefCaption, Disabled " & vbCrLf
        sSQL &= "FROM 		D09T0080 	WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE 		Type = '3000' " & vbCrLf
        sSQL &= "ORDER BY 	RefID" 'CalNo ") ' update 5/6/2013 id 56508

        dtColRef = ReturnDataTable(sSQL)
        If dtColRef Is Nothing OrElse dtColRef.Rows.Count <= 0 Then Exit Sub
        Dim iColRef As Integer = dtColRef.Rows.Count
        For iCol As Integer = 0 To dtColRef.Rows.Count - 1
            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc.DataField = dtColRef.Rows(iCol).Item("RefID").ToString
            tdbg.Columns.Add(dc)
            dc.Caption = dtColRef.Rows(iCol).Item("RefCaption").ToString
            tdbg.Splits(2).DisplayColumns(dc).Width = 80
            tdbg.Splits(2).DisplayColumns(dc).Visible = Not L3Bool(dtColRef.Rows(iCol).Item("Disabled").ToString)
            tdbg.Splits(2).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Splits(2).DisplayColumns(dc).Style.Font = FontUnicode(gbUnicode)
            tdbg.Splits(2).DisplayColumns(dc).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            If iCol = 0 Then
                iColIndexRef = tdbg.Columns.IndexOf(dc)
            End If
        Next
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
    End Sub
    Private iColTNH2 As Integer = 0
    Private Sub AddColumnTNH2()
        Dim sSQL As String = "-- Load 200 cot TNH dong" & vbCrLf
        sSQL &= "Select SalCalMethodID, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " +'( '+ CalNo +' )' ShortName, " & vbCrLf
        sSQL &= "IsNotPrint, Decimals, Formular, FormularDesc" & UnicodeJoin(gbUnicode) & " As FormularDesc, " & vbCrLf
        sSQL &= "ProcessOrderNum, 'TNH' + RTRIM(LTRIM(Substring(CalNo,4, LEN(CalNo)-3))) AS FieldName" & vbCrLf
        sSQL &= "From D13T2501  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(_salCalMethodID) & " AND Disabled = 0 Order By ProcessOrderNum" 'CalNo ") ' update 5/6/2013 id 56508

        Dim dtColTNH As DataTable = ReturnDataTable(sSQL)
        If dtColTNH Is Nothing OrElse dtColTNH.Rows.Count <= 0 Then Exit Sub

        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        iColTNH2 = dtColTNH.Rows.Count
        If iColTNH2 > 0 Then
            tdbg2.InsertHorizontalSplit(SPLIT1)
            tdbg2.Splits(SPLIT1).RecordSelectors = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_EmployeeID).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_FirstName).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_FullName).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_Note).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_PaymentMethodName).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_BankName).Visible = False
            tdbg2.Splits(SPLIT1).DisplayColumns(COL2_BankAccountNo).Visible = False
        End If
        For iCol As Integer = 0 To dtColTNH.Rows.Count - 1
            ' Add cột Type vào lưới
            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc.DataField = dtColTNH.Rows(iCol).Item("FieldName").ToString
            tdbg2.Columns.Add(dc)
            dc.Caption = dtColTNH.Rows(iCol).Item("ShortName").ToString
            tdbg2.Splits(SPLIT1).DisplayColumns(dc).Width = 80
            tdbg2.Splits(SPLIT1).DisplayColumns(dc).Visible = True
            'tdbg.Splits(SPLIT2).DisplayColumns(COL_TNH01 + i).Visible = L3Bool(IIf(dt2.Rows(i).Item("Disabled").ToString = "0" And dt2.Rows(i).Item("IsNotPrint").ToString = "0", True, False))
            tdbg2.Splits(SPLIT1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg2.Splits(SPLIT1).DisplayColumns(dc).Style.Font = FontUnicode(gbUnicode)
            tdbg2.Splits(SPLIT1).DisplayColumns(dc).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            tdbg2.Columns(dc.DataField).NumberFormat = InsertFormat(dtColTNH.Rows(iCol).Item("Decimals").ToString)
            'tdbg2.Splits(1).DisplayColumns(dc).Locked = False
            'tdbg2.Splits(1).DisplayColumns(dc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            'Gan tag Formula
            If D13Options.ShowFormular Then
                tdbg2.Columns(dc.DataField).Tag = dtColTNH.Rows(iCol).Item("Formular").ToString
            Else
                tdbg2.Columns(dc.DataField).Tag = dtColTNH.Rows(iCol).Item("FormularDesc").ToString
            End If

            ReDim Preserve sFieldSum2_Group(UBound(sFieldSum2_Group) + 1)
            sFieldSum2_Group(UBound(sFieldSum2_Group)) = COL2_IsUpdateNotBelongDiv + iCol + 1
        Next
        ResetFooterGrid(tdbg2, 0, tdbg2.Splits.Count - 1)
    End Sub


    Private Sub CheckPermission()
        iPerD13F5607 = ReturnPermission("D13F5607")
        iPerD13F2040 = ReturnPermission("D13F2040")
        If iPerD13F5607 < 3 Then
            btnSave.Enabled = False
            btnAdjustPayroll.Enabled = False
            btnAdjustAttendance.Enabled = False
            btnCalculateParoll.Enabled = False
        Else
            btnSave.Enabled = iPerD13F2040 >= 2
            btnAdjustPayroll.Enabled = iPerD13F2040 >= 2
            btnAdjustAttendance.Enabled = iPerD13F2040 >= 2
            btnCalculateParoll.Enabled = iPerD13F2040 >= 2
        End If
        mnuMark1.Enabled = iPerD13F2040 >= 2
        'ANHVU: Tạm thời rem lại
        btnComparePaymentData.Enabled = ReturnPermission("D13F2046") > 0
        mnuGird2ImportData.Enabled = ReturnPermission("D13F5612") > 0
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub SetDataForReport_D13R3600()
        Dim sSQL As New StringBuilder()
        sSQL.Append(" select DepartmentIDFrom, DepartmentIDTo, TeamIDFrom, TeamIDTo " & vbCrLf)
        sSQL.Append(" from D13T2600  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append(" And TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & vbCrLf)
        sSQL.Append(" And SalaryVoucherID = " & SQLString(_salaryVoucherID) & vbCrLf)


        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            sDepartmentIDFrom = dr("DepartmentIDFrom").ToString
            sDepartmentIDTo = dr("DepartmentIDTo").ToString
            sTeamIDFrom = dr("TeamIDFrom").ToString
            sTeamIDTo = dr("TeamIDTo").ToString
        End If

        dt.Clear()
        dt = ReturnDataTable(SQLStoreD29P2001)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            sMinDate = dr("MinDate").ToString
            sMaxDate = dr("MaxDate").ToString
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2601
    '# Created User: Lê Anh Vũ
    '# Created Date: 11/09/2014 09:32:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2601() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load DD ma nhan vien" & vbCrLf)
        sSQL &= "Exec D13P2601 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function


    Private Sub ShowD13T9000()
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Select Code, Short" & UnicodeJoin(gbUnicode) & "  + '( ' + Code + ' )' Short, Disabled, Type From D13T9000  WITH(NOLOCK) Order By Code")
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)

        dt1 = ReturnTableFilter(dt, "Type='SALBA'")

        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))

        For i As Integer = 0 To 3
            tdbg.Columns(COL_BaseSalary01 + i).Caption = dt1.Rows(i).Item("Short").ToString
            tdbg.Splits(2).DisplayColumns(COL_BaseSalary01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
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
            tdbg.Columns(COL_SalCoefficient01 + i).Caption = dt1.Rows(i).Item("Short").ToString
            tdbg.Splits(2).DisplayColumns(COL_SalCoefficient01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next

        ' update 27/12/2012 id 52980
        sSQL = New StringBuilder("")
        sSQL.Append(" -- Do caption dong thong tin tham chieu" & vbCrLf)
        sSQL.Append("SELECT RefID, RefCaption" & UnicodeJoin(gbUnicode) & " AS RefCaption, Disabled" & vbCrLf)
        sSQL.Append("FROM D09T0080  WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("WHERE Type = '8000'" & vbCrLf)
        sSQL.Append("ORDER BY RefID")
        dt = ReturnDataTable(sSQL.ToString)
        ' Dữ liệu dảm bào có 5 dòng
        For i As Integer = 0 To 4
            tdbg.Columns(i + COL_BRef01).Caption = dt.Rows(i).Item("RefCaption").ToString
            tdbg.Splits(3).DisplayColumns(i + COL_BRef01).Visible = Not L3Bool(dt.Rows(i).Item("Disabled"))
        Next

        ' update 29/1/2013 id 53896
        sSQL = New StringBuilder("")
        sSQL.Append(" -- Do caption dong thong tin he so chuc vu" & vbCrLf)
        sSQL.Append("SELECT Code, Short" & UnicodeJoin(gbUnicode) & " AS Short, Disabled" & vbCrLf)
        sSQL.Append("FROM D13T9000  WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("WHERE Type = 'D09T0211'" & vbCrLf)
        sSQL.Append("ORDER BY Code")
        dt = ReturnDataTable(sSQL.ToString)
        ' Dữ liệu dảm bào có 5 dòng
        For i As Integer = 0 To 4
            tdbg.Columns(i + COL_DutyRef01).Caption = dt.Rows(i).Item("Short").ToString
            tdbg.Splits(1).DisplayColumns(i + COL_DutyRef01).Visible = Not L3Bool(dt.Rows(i).Item("Disabled"))
        Next

        For i As Integer = COL_BRef01 To COL_BRef05 'COL_TNH99
            tdbg.Splits(3).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
        Next

    End Sub

    Private Sub ShowColumns()

        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary01).Visible = bBA.BASE01
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary02).Visible = bBA.BASE02
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary03).Visible = bBA.BASE03
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary04).Visible = bBA.BASE04

        mnuC01.Checked = bCE.CE01
        mnuC01.Enabled = bCE.CE01
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient01).Visible = bCE.CE01
        mnuC02.Checked = bCE.CE02
        mnuC02.Enabled = bCE.CE02
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient02).Visible = bCE.CE02
        mnuC03.Checked = bCE.CE03
        mnuC03.Enabled = bCE.CE03
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient03).Visible = bCE.CE03
        mnuC04.Checked = bCE.CE04
        mnuC04.Enabled = bCE.CE04
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient04).Visible = bCE.CE04
        mnuC05.Checked = bCE.CE05
        mnuC05.Enabled = bCE.CE05
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient05).Visible = bCE.CE05
        mnuC06.Checked = bCE.CE06
        mnuC06.Enabled = bCE.CE06
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient06).Visible = bCE.CE06
        mnuC07.Checked = bCE.CE07
        mnuC07.Enabled = bCE.CE07
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient07).Visible = bCE.CE07
        mnuC08.Checked = bCE.CE08
        mnuC08.Enabled = bCE.CE08
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient08).Visible = bCE.CE08
        mnuC09.Checked = bCE.CE09
        mnuC09.Enabled = bCE.CE09
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient09).Visible = bCE.CE09
        mnuC10.Checked = bCE.CE10
        mnuC10.Enabled = bCE.CE10
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient10).Visible = bCE.CE10
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BaseSalary01).NumberFormat = Format(tdbg.Columns(COL_BaseSalary01).Text, D13FormatSalary.BASE01)
        tdbg.Columns(COL_BaseSalary02).NumberFormat = Format(tdbg.Columns(COL_BaseSalary02).Text, D13FormatSalary.BASE02)
        tdbg.Columns(COL_BaseSalary03).NumberFormat = Format(tdbg.Columns(COL_BaseSalary03).Text, D13FormatSalary.BASE03)
        tdbg.Columns(COL_BaseSalary04).NumberFormat = Format(tdbg.Columns(COL_BaseSalary04).Text, D13FormatSalary.BASE04)
        tdbg.Columns(COL_SalCoefficient01).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COL_SalCoefficient02).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COL_SalCoefficient03).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COL_SalCoefficient04).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COL_SalCoefficient05).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COL_SalCoefficient06).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COL_SalCoefficient07).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COL_SalCoefficient08).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COL_SalCoefficient09).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COL_SalCoefficient10).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient10).Text, D13FormatSalary.CE10)

        tdbg.Columns(COL_SalCoefficient11).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient01).Text, D13FormatSalary.CE01)
        tdbg.Columns(COL_SalCoefficient12).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient02).Text, D13FormatSalary.CE02)
        tdbg.Columns(COL_SalCoefficient13).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient03).Text, D13FormatSalary.CE03)
        tdbg.Columns(COL_SalCoefficient14).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient04).Text, D13FormatSalary.CE04)
        tdbg.Columns(COL_SalCoefficient15).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient05).Text, D13FormatSalary.CE05)
        tdbg.Columns(COL_SalCoefficient16).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient06).Text, D13FormatSalary.CE06)
        tdbg.Columns(COL_SalCoefficient17).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient07).Text, D13FormatSalary.CE07)
        tdbg.Columns(COL_SalCoefficient18).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient08).Text, D13FormatSalary.CE08)
        tdbg.Columns(COL_SalCoefficient19).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient09).Text, D13FormatSalary.CE09)
        tdbg.Columns(COL_SalCoefficient20).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient10).Text, D13FormatSalary.CE10)

        '  If dt2.Rows.Count <= 0 Then Exit Sub

        For i As Integer = COL_DutyRef01 To COL_DutyRef05
            tdbg.Columns(i).NumberFormat = D13Format.DefaultNumber2
        Next
    End Sub

    Private Sub tdbg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.Click
        sNameGridFocus = tdbg.Name
    End Sub

    Private Sub tdbg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.GotFocus
        sNameGridFocus = tdbg.Name
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(COL_IsUpdate).Text = "1"
    End Sub

    'Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
    '    'tdbg.Columns(COL2_IsUpdate).Text = "1"
    'End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_DepartmentID
                e.CellTip = tdbg.Columns(COL_DepartmentName).Text
            Case COL_TeamID
                e.CellTip = tdbg.Columns(COL_TeamName).Text
                ' update 13/6/2013 id 56314 - bổ sung 100 cột TNH (Chuyển 200 cột TNH sang cột đông)
            Case COL_Total + 1 To COL_Total + iColTNH ' 200 cột TNH
                e.CellTip = tdbg.Columns(e.ColIndex).Tag.ToString
                '            Case COL_TNH01, COL_TNH02, COL_TNH03, COL_TNH04, COL_TNH05, COL_TNH06, COL_TNH07, COL_TNH08, COL_TNH09, COL_TNH10, _
                '            COL_TNH11, COL_TNH12, COL_TNH13, COL_TNH14, COL_TNH15, COL_TNH16, COL_TNH17, COL_TNH18, COL_TNH19, COL_TNH20, _
                '            COL_TNH21, COL_TNH22, COL_TNH23, COL_TNH24, COL_TNH25, COL_TNH26, COL_TNH27, COL_TNH28, COL_TNH29, COL_TNH30, _
                '            COL_TNH31, COL_TNH32, COL_TNH33, COL_TNH34, COL_TNH35, COL_TNH36, COL_TNH37, COL_TNH38, COL_TNH39, COL_TNH40, _
                '            COL_TNH41, COL_TNH42, COL_TNH43, COL_TNH44, COL_TNH45, COL_TNH46, COL_TNH47, COL_TNH48, COL_TNH49, COL_TNH50, _
                '            COL_TNH51, COL_TNH52, COL_TNH53, COL_TNH54, COL_TNH55, COL_TNH56, COL_TNH57, COL_TNH58, COL_TNH59, COL_TNH60, _
                '            COL_TNH61, COL_TNH62, COL_TNH63, COL_TNH64, COL_TNH65, COL_TNH66, COL_TNH67, COL_TNH68, COL_TNH69, COL_TNH70, _
                '            COL_TNH71, COL_TNH72, COL_TNH73, COL_TNH74, COL_TNH75, COL_TNH76, COL_TNH77, COL_TNH78, COL_TNH79, COL_TNH80, _
                '            COL_TNH81, COL_TNH82, COL_TNH83, COL_TNH84, COL_TNH85, COL_TNH86, COL_TNH87, COL_TNH88, COL_TNH89, COL_TNH90, _
                '            COL_TNH91, COL_TNH92, COL_TNH93, COL_TNH94, COL_TNH95, COL_TNH96, COL_TNH97, COL_TNH98, COL_TNH99
                '            Case COL_TNH01 To COL_TNH200
                '                e.CellTip = tdbg.Columns(e.ColIndex).Tag.ToString
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub mnuC01_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC01.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE01")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC01.Checked Then
                mnuC01.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient01).Visible = False
            Else
                mnuC01.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient01).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC02_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC02.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE02")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC02.Checked Then
                mnuC02.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient02).Visible = False
            Else
                mnuC02.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient02).Visible = True
            End If
        End If
    End Sub

    Private Function dtCEs(ByVal sCE As String) As DataTable
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Select Code, Disabled, Short" & UnicodeJoin(gbUnicode) & " + '( '+ Code +' )' Short From D13T9000  WITH(NOLOCK) Where Type = 'SALCE' And Code = " & SQLString(sCE))
        Dim dtCE As DataTable = ReturnDataTable(sSQL.ToString)
        Return dtCE
    End Function

    Private Sub mnuC03_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC03.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE03")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC03.Checked Then
                mnuC03.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient03).Visible = False
            Else
                mnuC03.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient03).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC04_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC04.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE04")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC04.Checked Then
                mnuC04.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient04).Visible = False
            Else
                mnuC04.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient04).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC05_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC05.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE05")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC05.Checked Then
                mnuC05.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient05).Visible = False
            Else
                mnuC05.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient05).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC06_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC06.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE06")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC06.Checked Then
                mnuC06.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient06).Visible = False
            Else
                mnuC06.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient06).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC07_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC07.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE07")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC07.Checked Then
                mnuC07.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient07).Visible = False
            Else
                mnuC07.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient07).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC08_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC08.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE08")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC08.Checked Then
                mnuC08.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient08).Visible = False
            Else
                mnuC08.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient08).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC09_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC09.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE09")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC09.Checked Then
                mnuC09.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient09).Visible = False
            Else
                mnuC09.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient09).Visible = True
            End If
        End If
    End Sub

    Private Sub mnuC10_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC10.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtCE As DataTable = dtCEs("CE10")
        If dtCE.Rows(0).Item("Disabled").ToString = "0" Then
            If mnuC10.Checked Then
                mnuC10.Checked = False
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient10).Visible = False
            Else
                mnuC10.Checked = True
                tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient10).Visible = True
            End If
        End If
    End Sub

    ' update 9/8/2013 id 57103 - ẩn 10 menu in
    '    Private Sub mnuStyle1_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle1.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3500")
    '    End Sub
    '
    '    Private Sub mnuStyle2_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle2.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3501")
    '    End Sub
    '
    '    Private Sub mnuStyle3_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle3.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3502")
    '    End Sub
    '
    '    Private Sub mnuStyle4_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle4.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3503")
    '    End Sub
    '
    '    Private Sub mnuStyle5_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle5.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3504")
    '    End Sub
    '
    '    Private Sub mnuStyle6_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle6.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3505")
    '    End Sub
    '
    '    Private Sub mnuStyle7_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle7.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3506")
    '    End Sub
    '
    '    Private Sub mnuStyle8_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle8.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3507")
    '    End Sub
    '
    '    Private Sub mnuStyle9_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle9.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3508")
    '    End Sub
    '
    '    ' update 9/8/2013 id 57103 - ẩn 10 menu in
    '    Private Sub mnuStyle103_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuStyle10.Click
    '        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '        PrintReport("D13R3509")
    '    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD29P2001
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 08/11/2007 09:30:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD29P2001() As String
        Dim sSQL As String = ""

        sSQL &= "Exec D29P2001 "
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MinDate, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MaxDate, datetime, NOT NULL
        sSQL &= SQLNumber(2) & vbCrLf 'IsRecordSet, int, NOT NULL

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD29P4000
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/12/2009 10:29:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD29P4000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D29P4000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'PeriodMode, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString("%") & COMMA 'BlockIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'BlockIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sDepartmentIDFrom) & COMMA 'DepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sDepartmentIDTo) & COMMA 'DepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sTeamIDFrom) & COMMA 'TeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sTeamIDTo) & COMMA 'TeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ShiftIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ShiftIDTo, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'ReportMode, tinyint, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'Title, varchar[500], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeIDTo, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub PrintReport(ByVal sNameReport As String)
        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportCaption As String
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        Dim sPathReport As String = ""
        Dim sSubReportName As String = "D09R6000"
        Dim dt As DataTable


        If sNameReport = "D13R3600" Then
            sReportCaption = rL3("Bang_dien_giai_luong")
        Else
            sReportCaption = rL3("Bang_thanh_toan_luong")
        End If

        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, "") & sNameReport & ".rpt"
        sSQL = SQLStoreD13P3502(0)
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, , gbUnicode)

        With report
            .OpenConnection(conn)
            .AddParameter("MONTHYEAR", rL3("ThangV") & giTranMonth & "/" & giTranYear)

            Dim sSQL1 As String = "Select SalCalMethodID, Disabled, CalNo, Caption, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, ProcessOrderNum From D13T2501  WITH(NOLOCK) Where SalCalMethodID = " & SQLString(_salCalMethodID) & " Order By  ProcessOrderNum " 'CalNo ") ' update 5/6/2013 id 56508
            dt = ReturnDataTable(sSQL1)
            If dt.Rows.Count = 0 Then Exit Sub

            For i As Integer = 0 To dt.Rows.Count - 1
                sCaption = dt.Rows(i).Item("ShortName").ToString
                If i < 9 Then
                    .AddParameter("Colcaption0" & (i + 1), sCaption)
                Else
                    .AddParameter("Colcaption" & (i + 1), sCaption)
                End If
            Next

            .AddSub(sSQLSub, sSubReportName & ".rpt")

            If sNameReport = "D13R3600" Then
                .AddSub(SQLStoreD13P3602().ToString, "D13R3602.rpt")
                SetDataForReport_D13R3600()
                .AddSub(SQLStoreD29P4000().ToString, "D13R3603.rpt")
            End If

            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
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
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
            ReLoadTDBGrid()
        End Set
    End Property

    Private dtFind As DataTable

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_EmployeeID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)

        ' ResetTableForExcel(tdbg, gdtCaptionExcel)
        'ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtFind.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuEmployeeRecord.Enabled = tdbg.RowCount > 0
        mnuPaymentbyProject.Enabled = tdbg.RowCount > 0
        mnuPieceworkRecordingDetail.Enabled = tdbg.RowCount > 0 And Not gbClosed
        mnuTransferByEmail.Enabled = tdbg.RowCount > 0 And Not gbClosed
        mnuUpdateBankID.Enabled = tdbg.RowCount > 0 And Not gbClosed
        tdbg_FooterText()
    End Sub

#End Region

    Private Sub mnuSalaryDescription_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalaryDescription.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim arrPro() As StructureProperties = Nothing
        SetDataForReport_D13R3600()
        SetProperties(arrPro, "SQLStoreD13P3602", SQLStoreD13P3602())
        SetProperties(arrPro, "SQLStoreD29P4000", SQLStoreD29P4000())
        SetProperties(arrPro, "sFind", sFindServer)
        SetProperties(arrPro, "SalCalMethodID", _salCalMethodID)
        SetProperties(arrPro, "sSalaryVoucherID", SalaryVoucherID)
        SetProperties(arrPro, "sPayrollVoucherID", PayrollVoucherID)
        SetProperties(arrPro, "EmployeeID", txtEmployeeID.Text)
        SetProperties(arrPro, "EmployeeName", txtEmployeeName.Text)
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID).ToString)
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID).ToString)
        SetProperties(arrPro, "ID11", tdbcBlockID.SelectedValue.ToString)
        SetProperties(arrPro, "ID12", tdbcEmpGroupID.SelectedValue.ToString)

        CallFormShow(Me, "D13D0340", "D13F4040", arrPro)

        '        Dim f As New D13M0340
        '        With f
        '            .FormActive = enumD13E0340Form.D13F4040
        '            .ID01 = SQLStoreD13P3602() 'SQLStoreD13P3602
        '            SetDataForReport_D13R3600()
        '            .ID02 = SQLStoreD29P4000().ToString 'SQLStoreD29P4000
        '            .ID03 = sFindServer 'sFind
        '            .ID04 = _salCalMethodID 'SalCalMethodID
        '            .ID05 = SalaryVoucherID 'sSalaryVoucherID
        '            .ID06 = PayrollVoucherID 'sPayrollVoucherID
        '            'Update 19/12/2011: Incident 45383
        '            .ID07 = txtEmployeeID.Text 'Mã Nhân viên
        '            .ID08 = tdbcDepartmentID.SelectedValue.ToString 'Mã Phòng ban
        '            .ID09 = tdbcTeamID.SelectedValue.ToString 'Mã tổ nhóm
        '            .ID10 = txtEmployeeName.Text 'Tên Nhân viên
        '            .ID11 = tdbcBlockID.SelectedValue.ToString 'Mã khối
        '            .ID12 = tdbcEmpGroupID.SelectedValue.ToString 'Mã nhóm nhân viên
        '
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Dim sFieldSum_Group() As Integer = {}
    'Dim sFieldSum_Group() As Integer = {COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04, COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10}
    Private Sub tdbg_FooterText()
        If sFieldSum_Group.Length = 0 Then
            For i As Integer = COL_BaseSalary01 To COL_BaseSalary04
                ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
                sFieldSum_Group(UBound(sFieldSum_Group)) = i
            Next

            For i As Integer = COL_SalCoefficient01 To COL_SalCoefficient20
                ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
                sFieldSum_Group(UBound(sFieldSum_Group)) = i
            Next

            '            'update 30/11/2012 id 52828
            ' update 13/6/2013 id 56314 - bổ sung 100 cột TNH (Chuyển 200 cột TNH sang cột đông)
            '            If dt2.Rows.Count > 0 Then
            '                For i As Integer = 0 To dt2.Rows.Count - 1
            '                    ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
            '                    sFieldSum_Group(UBound(sFieldSum_Group)) = i + COL_TNH01
            '                Next
            '            End If
        End If

        FooterTotalGrid(tdbg, COL_FullName)
        FooterSumNew(tdbg, sFieldSum_Group)

        '        FootTextColumns(COL_BaseSalary01, D13FormatSalary.BASE01)
        '        FootTextColumns(COL_BaseSalary02, D13FormatSalary.BASE02)
        '        FootTextColumns(COL_BaseSalary03, D13FormatSalary.BASE03)
        '        FootTextColumns(COL_BaseSalary04, D13FormatSalary.BASE04)
        '
        '        FootTextColumns(COL_SalCoefficient01, D13FormatSalary.CE01)
        '        FootTextColumns(COL_SalCoefficient02, D13FormatSalary.CE02)
        '        FootTextColumns(COL_SalCoefficient03, D13FormatSalary.CE03)
        '        FootTextColumns(COL_SalCoefficient04, D13FormatSalary.CE04)
        '        FootTextColumns(COL_SalCoefficient05, D13FormatSalary.CE05)
        '        FootTextColumns(COL_SalCoefficient06, D13FormatSalary.CE06)
        '        FootTextColumns(COL_SalCoefficient07, D13FormatSalary.CE07)
        '        FootTextColumns(COL_SalCoefficient08, D13FormatSalary.CE08)
        '        FootTextColumns(COL_SalCoefficient09, D13FormatSalary.CE09)
        '        FootTextColumns(COL_SalCoefficient10, D13FormatSalary.CE10)
        '
        '        FootTextColumns(COL_SalCoefficient11, D13FormatSalary.CE11)
        '        FootTextColumns(COL_SalCoefficient12, D13FormatSalary.CE12)
        '        FootTextColumns(COL_SalCoefficient13, D13FormatSalary.CE13)
        '        FootTextColumns(COL_SalCoefficient14, D13FormatSalary.CE14)
        '        FootTextColumns(COL_SalCoefficient15, D13FormatSalary.CE15)
        '        FootTextColumns(COL_SalCoefficient16, D13FormatSalary.CE16)
        '        FootTextColumns(COL_SalCoefficient17, D13FormatSalary.CE17)
        '        FootTextColumns(COL_SalCoefficient18, D13FormatSalary.CE18)
        '        FootTextColumns(COL_SalCoefficient19, D13FormatSalary.CE19)
        '        FootTextColumns(COL_SalCoefficient20, D13FormatSalary.CE20)

        '        For i As Integer = COL_TNH01 To COL_TNH80
        '            FootTextColumns(i, InsertFormat(dt2.Rows(i - COL_TNH01).Item("Decimals").ToString))
        '            ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
        '            sFieldSum_Group(UBound(sFieldSum_Group)) = i
        '        Next
        '        For i As Integer = COL_TNH81 To COL_TNH99
        '            FootTextColumns(i, InsertFormat(dt2.Rows(i - COL_TNH01 - 4).Item("Decimals").ToString))
        '            ReDim Preserve sFieldSum_Group(UBound(sFieldSum_Group) + 1)
        '            sFieldSum_Group(UBound(sFieldSum_Group)) = i
        '        Next
    End Sub



    Dim sFieldSum2_Group() As Integer = {}
    Private Sub tdbg2_FooterText()
        If sFieldSum2_Group.Length = 0 Then
        Else
            FooterSumNew(tdbg2, sFieldSum2_Group)
        End If
        FooterTotalGrid(tdbg2, COL2_FullName)
    End Sub



    Private Sub FootTextColumns(ByVal iCol As Integer, ByVal sNumberFormat As String)
        Dim Sum As Double = 0
        For j As Int32 = 0 To tdbg.RowCount - 1
            Sum += Number(SQLNumber(tdbg(j, iCol).ToString, sNumberFormat))
        Next
        tdbg.Columns(iCol).FooterText = SQLNumber(Sum.ToString, sNumberFormat)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3602
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/07/2007 04:32:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3602() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3602 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Lê Anh Vũ
    '# Created Date: 21/10/2014 01:22:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra thiet lap thu nhap he thong" & vbCrlf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(4) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function


    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder("")

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtFind Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
      
        If e.ColIndex = COL_IsCheck Then
            tdbg.AllowSort = False
            Dim bFlag As Boolean = Not CBool(tdbg(0, COL_IsCheck))
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsCheck) = bFlag
                tdbg(i, COL_IsUpdate) = "1"
            Next
        Else
            tdbg.AllowSort = True
        End If
        '20 cột động
        HeadClick20RefDymamic(e.ColIndex)
        'If iColIndexRef <> -1 Then
        '    For i As Integer = iColIndexRef To iColIndexRef + dtColRef.Rows.Count - 1
        '        If e.ColIndex = i Then
        '            tdbg.AllowSort = False
        '            CopyColumns(tdbg, i, tdbg.Columns(i).Text, tdbg.Row)
        '            For j As Integer = tdbg.Row To tdbg.RowCount - 1
        '                tdbg(j, COL_IsUpdate) = "1"
        '            Next
        '            Exit Sub
        '        End If
        '    Next
        'End If
    End Sub
    Private Sub HeadClick20RefDymamic(ByVal iCol As Integer)
        If iColIndexRef <> -1 Then
            For i As Integer = iColIndexRef To iColIndexRef + dtColRef.Rows.Count - 1
                If iCol = i Then
                    tdbg.AllowSort = False
                    CopyColumns(tdbg, i, tdbg.Columns(i).Text, tdbg.Row)
                    For j As Integer = tdbg.Row To tdbg.RowCount - 1
                        tdbg(j, COL_IsUpdate) = "1"
                    Next
                    Exit Sub
                End If
            Next
        End If
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_PaymentDate
                    CopyColumns(tdbg, tdbg.Col, tdbg(tdbg.Row, tdbg.Col).ToString, tdbg.Row)
                    ' update 14/3/2013 id 54989 - Khi ctrl + S thì gán trường IsUpdate = 1
                    For i As Integer = tdbg.Row To tdbg.RowCount - 1
                        tdbg(i, COL_IsUpdate) = "1"
                    Next

            End Select
            ' 20 cột động
            HeadClick20RefDymamic(tdbg.Col)
            'If iColIndexRef <> -1 Then
            '    For i As Integer = iColIndexRef To iColIndexRef + dtColRef.Rows.Count - 1
            '        If tdbg.Col = i Then
            '            tdbg.AllowSort = False
            '            CopyColumns(tdbg, i, tdbg.Columns(i).Text, tdbg.Row)
            '            For j As Integer = tdbg.Row To tdbg.RowCount - 1
            '                tdbg(j, COL_IsUpdate) = "1"
            '            Next
            '            Exit Sub
            '        End If
            '    Next
            'End If
        Else
            HotKeyDownGrid(e, tdbg, COL_IsCheck, 0, 2)
        End If
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    Private Sub mnuSalaryCongure_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalaryCongure.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CallingForm", "D13F2042")
        SetProperties(arrPro, "bIsTransferByEmail", False)
        SetProperties(arrPro, "PayrollVoucherNo", _payrollVoucherNo)
        SetProperties(arrPro, "SalaryVoucherNo", _salaryVoucherNo)
        SetProperties(arrPro, "sFind", sFindServer)
        SetProperties(arrPro, "EmployeeID", txtEmployeeID.Text)
        SetProperties(arrPro, "EmployeeName", txtEmployeeName.Text)
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID).ToString)
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID).ToString)
        SetProperties(arrPro, "EmpGroupID", ReturnValueC1Combo(tdbcEmpGroupID).ToString)
        SetProperties(arrPro, "BlockID", ReturnValueC1Combo(tdbcBlockID).ToString)

        CallFormShow(Me, "D13D0340", "D13F4020", arrPro)

        '        Dim f As New D13M0340 'D13F4020
        '        With f
        '            .FormActive = enumD13E0340Form.D13F4020
        '            .ID01 = "D13F2042" 'CallingForm
        '            .ID02 = CType(False, String) 'bIsTransferByEmail
        '            .ID03 = _payrollVoucherNo 'PayrollVoucherNo
        '            .ID04 = _salaryVoucherNo 'SalaryVoucherNo
        '            'Update 19/12/2011: Incident 45383
        '            .ID06 = sFindServer 'sFind
        '            .ID07 = txtEmployeeID.Text 'Mã Nhân viên
        '            .ID08 = tdbcDepartmentID.SelectedValue.ToString 'Mã Phòng ban
        '            .ID09 = tdbcTeamID.SelectedValue.ToString 'Mã tổ nhóm
        '            .ID10 = txtEmployeeName.Text 'Tên Nhân viên
        '            .ID11 = tdbcBlockID.SelectedValue.ToString 'Mã khối
        '            .ID12 = tdbcEmpGroupID.SelectedValue.ToString 'Mã nhóm nhân viên
        '
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuTransferByEmail_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransferByEmail.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CallingForm", "D13F2042")
        SetProperties(arrPro, "bIsTransferByEmail", True)
        SetProperties(arrPro, "PayrollVoucherNo", _payrollVoucherNo)
        SetProperties(arrPro, "SalaryVoucherNo", _salaryVoucherNo)

        CallFormShow(Me, "D13D0340", "D13F4020", arrPro)

        '        Dim f As New D13M0340 'D13F4020
        '        With f
        '            .FormActive = enumD13E0340Form.D13F4020
        '            .ID01 = "D13F2042" 'CallingForm
        '            .ID02 = CType(True, String) 'bIsTransferByEmail
        '            .ID03 = _payrollVoucherNo 'PayrollVoucherNo
        '            .ID04 = _salaryVoucherNo 'SalaryVoucherNo
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuMark1_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMark1.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Dim f As New D45F2006
        'With f
        '    .FormName = "D45F2006"
        '    .FormPermission = "D13F2042"
        '    .SalaryVoucherID = _salaryVoucherID
        '    .PayrollVoucherID = _payrollVoucherID
        '    .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
        '    .FormState = EnumFormState.FormView
        '    .ShowDialog()
        'End With

        'Lê Anh Vũ: ID 82837 chuyển EXE qua DLL: Không truyền 6 Property qua vì EXE cũng truyền qua nhưng D45X0000 (D45E0240) không lấy 
        'những tham số này, để giữ tính năng như EXE nên không truyền 6 tham số này. Sau này nếu cần thì bỏ REM 6 tham số này ra: 
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D13F2042")

        '*****************6 tham số tạm thời REM lại *******************************
        'SetProperties(arrPro, "SalaryVoucherID", _salaryVoucherID)
        'SetProperties(arrPro, "PayrollVoucherID", _payrollVoucherID)
        'SetProperties(arrPro, "EmployeeID", tdbg.Columns(COL_EmployeeID).Text)
        'SetProperties(arrPro, "Mode", 1)
        'SetProperties(arrPro, "ProductVoucherID", "")
        'SetProperties(arrPro, "FormState", EnumFormState.FormView)
        '************************************************

        CallFormThread(Me, "D45D0240", "D45F2006", arrPro)

    End Sub

    Private Sub mnuMark2_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMark2.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2043
        With f
            .SalaryVoucherID = _salaryVoucherID
            .SalCalMethodID = _salCalMethodID
            .SFind = sFindServer 'sFind
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub mnuEmployeeRecord_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEmployeeRecord.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "EmployeeID", tdbg.Columns(COL_EmployeeID).Text)
        SetProperties(arrPro, "FormIDPermission", "D09F2050")
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        Dim frm As Form = CallFormShowDialog("D09D1040", "D09F1500", arrPro)
        '        If L3Bool(GetProperties(frm, "bSaved")) Then
        '            LoadTDBGrid(, tdbg.Columns(COL_TransID).Text)
        '        End If

        '        ' update 20/8/2013 id 57965 - Chuyển qua gọi exe mới D09E1040
        '        Dim frm As New DxxMxx40
        '        With frm
        '            .exeName = "D09E1040" 'Exe cần gọi
        '            .FormActive = "D09F1500" 'Form cần hiển thị
        '            .FormPermission = "D09F2050" 'Mã màn hình phân quyền
        '            Dim sField() As String = {"EmployeeID","FormState"}
        '            Dim sValue() As String = {tdbg.Columns(COL_EmployeeID).Text, CType(EnumFormState.FormView, Integer).ToString}
        '            .IDxx(sField) = sValue
        '            ' .OutputName = New String() {xxxxx} 'Giá trị trả về
        '            .ShowDialog()
        '            '  Dim output() As String = .OutputXX()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuNote_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim dtChild As New DataTable
        Dim row As DataRow

        Dim dc0 As New DataColumn
        dc0.ColumnName = "IsCheck"
        dtChild.Columns.Add(dc0)
        Dim dc1 As New DataColumn
        dc1.ColumnName = "DepartmentID"
        dtChild.Columns.Add(dc1)
        Dim dc2 As New DataColumn
        dc2.ColumnName = "TeamID"
        dtChild.Columns.Add(dc2)
        Dim dc3 As New DataColumn
        dc3.ColumnName = "EmployeeID"
        dtChild.Columns.Add(dc3)
        Dim dc4 As New DataColumn
        dc4.ColumnName = "FullName"
        dtChild.Columns.Add(dc4)
        Dim dc5 As New DataColumn
        dc5.ColumnName = "Note"
        dtChild.Columns.Add(dc5)
        If tdbg.SelectedRows.Count = 0 Then
            row = dtChild.NewRow
            row("IsCheck") = "0"
            row("DepartmentID") = tdbg.Columns.Item(COL_DepartmentID).Text
            row("TeamID") = tdbg.Columns.Item(COL_TeamID).Text
            row("EmployeeID") = tdbg.Columns.Item(COL_EmployeeID).Text
            row("FullName") = tdbg.Columns.Item(COL_FullName).Text
            row("Note") = tdbg.Columns.Item(COL_Note).Text
            dtChild.Rows.Add(row)
        Else
            For i As Integer = 0 To tdbg.SelectedRows.Count - 1
                row = dtChild.NewRow
                row("IsCheck") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_IsCheck).ToString
                row("DepartmentID") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_DepartmentID).ToString
                row("TeamID") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_TeamID).ToString
                row("EmployeeID") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_EmployeeID).ToString
                row("FullName") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_FullName).ToString
                row("Note") = tdbg(CInt(tdbg.SelectedRows.Item(i).ToString), COL_Note).ToString
                dtChild.Rows.Add(row)
            Next
        End If

        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        Dim f As New D13F2044
        With f
            .GetDataTable = dtChild
            .SalaryVoucherID = _salaryVoucherID
            .ShowDialog()
            .Dispose()
        End With
        LoadTDBGrid()
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_IsCheck, COL_EmployeeID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        CallShowD99F2222(Me, dtCaptionCols, dtFind, gsGroupColumns)
        '        'Gọi form Xuất Excel như sau:
        '        ResetTableForExcel(tdbg, dtCaptionCols)
        '        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtFind, gsGroupColumns)

        '        '*****************************************
        '        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = gdtCaptionExcel
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dtFind
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '        '*****************************************
    End Sub

    Private Sub mnuPaymentbyProject_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuPaymentbyProject.Click
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2048()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "13")
        SetProperties(arrPro, "UseD89P2000", False)
        SetProperties(arrPro, "ReportTypeID", "D13F4020")
        SetProperties(arrPro, "SQLMain", sSQL)
        SetProperties(arrPro, "CaptionForm", rL3("Bang_luong_theo_du_anF"))
        CallFormThread(Me, "D99D0541", "D99F6868", arrPro)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2048
    '# Created User: Lê Anh Vũ
    '# Created Date: 30/03/2016 03:42:00
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2048() As String
        Dim sSQL As String = ""
        sSQL &= ("-- bang luong theo du an" & vbCrlf)
        sSQL &= "Exec D13P2048 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtEmployeeName, gbUnicode) & COMMA 'EmployeeName, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisonID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcEmpGroupID)) & COMMA 'EmpGroupID, varchar[50], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString("@ReportID") 'ReportID, varchar[50], NOT NULL
        Return sSQL
    End Function



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        tdbg2.UpdateData()
        'ANHVU
        'If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLInsertD09T6666s.ToString() & vbCrLf)

        sSQL.Append(SQLStoreD09P6200("D13T2601", "", "", 0, "TransID") & vbCrLf)
        sSQL.Append(SQLUpdateD13T2601s.ToString() & vbCrLf)
        sSQL.Append(SQLStoreD09P6200("D13T2601", "", "", 1, "TransID") & vbCrLf)
        sSQL.Append(SQLStoreD09P6210("SalaryCalTrans", "", "02", _salaryVoucherNo, _description) & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666("D13F2042") & vbCrLf)
        If bIsSalOtherDiv Then
            sSQL.Append(SQLDeleteD13T2601() & vbCrLf)
            sSQL.Append(SQLInsertD13T2601().ToString & vbCrLf)
        End If
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            'Lưu thành công load lại lưới
            LoadTDBGrid()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
        Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Thanh Huyền
    '# Created Date: 16/11/2010 10:18:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2042") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnCalculateParoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateParoll.Click
        Me.Cursor = Cursors.WaitCursor
        If Not CheckStore(SQLStoreD13P5555(0)) Then Exit Sub
        Dim sSQL As New StringBuilder("")
        Dim bResult As Boolean
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        'Xóa kết quả tính lương cũ
        'sSQL.Append(SQLStoreD13P3501())
        'ExecuteSQL(sSQL.ToString)
        'Tính lại bảng lương
        sSQL = New StringBuilder("")
        sSQL.Append(SQLStoreD13P4500())

        'Update 20/12/2011: Incident 42925
        '        If Not My_ExecuteSQLNoTransaction(sSQL.ToString) Then
        '            D99C0008.MsgL3(rl3("Tinh_luong_khong_thanh_cong_Vui_long_kiem_tra_lai_phuong_phap_tinh_luong"))
        '            Exit Sub
        '        End If
        If Not CheckStore(sSQL.ToString) Then
            Exit Sub
        End If

        'Chuyển bút toán
        If _transferMethodID <> "" Then
            sSQL = New StringBuilder("")
            sSQL.Append(SQLStoreD13P2110())
            ExecuteSQL(sSQL.ToString)
        End If
        'Cập nhật lại thông tin thay đổi
        sSQL = New StringBuilder("")
        sSQL.Append(SQLUpdateD13T2600.ToString & vbCrLf)
        sSQL.Append(SQLStoreD13P4600) '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	
        bResult = ExecuteSQL(sSQL.ToString)
        If bResult = True Then
            D99C0008.MsgL3(rL3("Du_lieu_da_duoc_tinh_thanh_cong"))
        End If
        btnFilter_Click(Nothing, Nothing)
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdjustAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustAttendance.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PayrollVoucherID", _payrollVoucherID)
        SetProperties(arrPro, "SalaryVoucherID", _salaryVoucherID)
        SetProperties(arrPro, "VoucherDate", _voucherDate)
        SetProperties(arrPro, "Description", _description)
        SetProperties(arrPro, "TransferMethodID", _transferMethodID)
        SetProperties(arrPro, "BlockID", ComboValue(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ComboValue(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ComboValue(tdbcTeamID))
        SetProperties(arrPro, "EmpGroupID", ComboValue(tdbcEmpGroupID))
        SetProperties(arrPro, "EmployeeID", txtEmployeeID.Text)
        SetProperties(arrPro, "EmployeeName", txtEmployeeName.Text)
        SetProperties(arrPro, "Find", sFindServer)

        CallFormShow("D13D2140", "D13F2026", arrPro)

        '        Dim f As New D13M2140
        '        With f
        '            .FormActive = enumD13E2140Form.D13F2026
        '            .ID01 = _payrollVoucherID
        '            .ID02 = _salaryVoucherID
        '            .ID03 = _voucherDate
        '            .ID04 = _description
        '            .ID05 = _transferMethodID
        '            .ID06 = ComboValue(tdbcDepartmentID)
        '            .ID07 = ComboValue(tdbcTeamID)
        '            .ID08 = txtEmployeeID.Text
        '            .ID09 = txtEmployeeName.Text
        '            .ID10 = sFindServer 'sFind
        '            .ID11 = ComboValue(tdbcBlockID)
        '            .ID12 = ComboValue(tdbcEmpGroupID)
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub btnAdjustPayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustPayroll.Click
        If Not AdjustPayroll() Then Exit Sub

        Dim sSQL As String = ""
        sSQL = SQLDeleteD91T9009() & vbCrLf
        sSQL &= SQLInsertD91T9009s().ToString
        ExecuteSQL(sSQL)

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D09F2021")
        SetProperties(arrPro, "Mode09", 1)
        SetProperties(arrPro, "IsProposal", False)
        Dim frm As Form = CallFormShowDialog("D09D2140", "D09F2021", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            btnFilter_Click(Nothing, Nothing)
        End If

        '        Dim f As New D09F2021
        '        f.ShowDialog()
        '        If f.bSaved Then
        '            btnFilter_Click(Nothing, Nothing)
        '        End If
        '        f.Dispose()
    End Sub

    Private Function AdjustPayroll() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3502
    '# Created User: DUCTRONG
    '# Created Date: 29/04/2009 11:34:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3502() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3502 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(SalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(PayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DeparmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'EmployeeIDTo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now()) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtEmployeeName.Text) & COMMA 'EmployeeName, varchar[20], NOT NULL
        sSQL &= SQLNumber(D13Options.ShowZeroNumber) & COMMA 'ShowzeroNumber, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmpGroupID)) '& COMMA  'EmpGroupID, varchar[20], NOT NULL
        'sSQL &= SQLNumber(iIsNotBelongDiv) & COMMA  'EmpGroupID, varchar[20], NOT NULL
        Return sSQL
    End Function


    '    Private Function SQLStoreD13P3501() As String
    '        Dim sSQL As String = ""
    '        sSQL &= "Exec D13P3501 "
    '        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
    '        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
    '        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
    '        sSQL &= SQLString(_payrollVoucherID) 'PayrollVoucherID, varchar[20], NOT NULL
    '        Return sSQL
    '    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4500
    '# Created User: DUCTRONG
    '# Created Date: 05/05/2009 03:41:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4500 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2110
    '# Created User: DUCTRONG
    '# Created Date: 05/05/2009 03:42:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2110 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_transferMethodID) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(1) 'Mode, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2600
    '# Created User: DUCTRONG
    '# Created Date: 05/05/2009 04:17:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2600() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2600 Set ")
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
        sSQL.Append(" TranMonth = " & giTranMonth & " And ")
        sSQL.Append(" TranYear = " & giTranYear & " And ")
        sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4600
    '# Created User: NGOCTHOAI
    '# Created Date: 14/07/2014 10:32:03
    '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tu dong san cong khi tinh luong" & vbCrLf)
        sSQL &= "Exec D13P4600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL

    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2601s
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2009 11:57:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2601s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsUpdate).ToString() = "1" Then
                sSQL.Append("Update D13T2601 Set ")
                sSQL.Append("Note = " & SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
                sSQL.Append("NoteU = " & SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'varchar[500], NOT NULL
                sSQL.Append("IsCheck = " & SQLNumber(tdbg(i, COL_IsCheck)) & COMMA) 'tinyint, NOT NULL
                sSQL.Append("PaymentDate = " & SQLDateSave(tdbg(i, COL_PaymentDate))) 'datetime, NULL
                If dtColRef.Rows.Count > 0 Then
                    For Each dr As DataRow In dtColRef.Rows
                        sSQL.Append(COMMA & dr("RefID").ToString() & "U = " & SQLStringUnicode(tdbg(i, dr("RefID").ToString), gbUnicode, True)) 'datetime, NULL
                    Next
                End If
                sSQL.Append(" Where ")
                'sSQL.Append("EmployeeID =  " & SQLString(tdbg(i, COL_EmployeeID)))
                'sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID))
                sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID))
                'sSQL.Append("AND DepartmentID = " & SQLString(tdbg(i, COL_DepartmentID)))
                'sSQL.Append("AND TeamID = " & SQLString(tdbg(i, COL_TeamID)))
                sSQL.Append("AND TransID = " & SQLString(tdbg(i, COL_TransID)))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 12/06/2009 07:51:12
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009(Optional ByVal sFormID As String = "", Optional ByVal sKey02ID As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009" & vbCrLf
        sSQL &= "Where HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "And UserID = " & SQLString(gsUserID)
        If sFormID <> "" Then sSQL &= " And FormID=" & SQLString(sFormID)
        If sKey02ID <> "" Then sSQL &= " And Key02ID=" & SQLString(sKey02ID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 12/06/2009 07:51:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009(ByVal i As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
        sSQL.Append("Key04ID, Key05ID, Key06ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("D13F2042") & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'Key04ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'Key05ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(tdbg(i, COL_TeamID))) 'Key06ID, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLInsertD91T9009s() As String
        Dim sResult As String = ""
        Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows

        If aSelectRows.Count > 0 Then
            'If tdbg(tdbg.Row, COL_EmployeeID).ToString <> tdbg(aSelectRows.Item(0), COL_EmployeeID).ToString Then
            '    sResult &= SQLInsertD91T9009(tdbg.Row).ToString() & vbCrLf
            'End If
            For i As Integer = 0 To aSelectRows.Count - 1
                sResult &= SQLInsertD91T9009(aSelectRows.Item(i)).ToString() & vbCrLf
            Next
        Else
            sResult &= SQLInsertD91T9009(tdbg.Row).ToString() & vbCrLf
        End If

        Return sResult
    End Function

    Private Function SQLInsertD91T9009_Import() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[20], NOT NULL
        sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("IMPORT")) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2601 _sQLDeleteD13T2601
    '# Created User: Lê Anh Vũ
    '# Created Date: 11/09/2014 01:30:23
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2601() As String
        Dim sSQL As String = ""
        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_IsUpdateNotBelongDiv).ToString() = "1" Then
                sSQL &= ("-- delete D13T2601" & vbCrLf)
                sSQL &= "Delete From D13T2601" & vbCrLf
                sSQL &= "Where SalaryVoucherID  = " & SQLString(_salaryVoucherID) & vbCrLf
                sSQL &= "And EmployeeID  = " & SQLString(tdbg2(i, COL2_EmployeeID)) & vbCrLf
                sSQL &= "And IsNotBelongDiv   = 1"
                sSQL &= vbCrLf
            End If
        Next
        'Lê Anh Vũ: Chạy thêm những dòng Delete
        For Each _r As DataRow In dtGird2Delete.Rows
            sSQL &= vbCrLf
            sSQL &= ("-- delete D13T2601" & vbCrLf)
            sSQL &= "Delete From D13T2601" & vbCrLf
            sSQL &= "Where SalaryVoucherID  = " & SQLString(_salaryVoucherID) & vbCrLf
            sSQL &= "And EmployeeID  = " & SQLString(_r("EmployeeID")) & vbCrLf
            sSQL &= "And IsNotBelongDiv   = 1"
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2601
    '# Created User: Lê Anh Vũ
    '# Created Date: 11/09/2014 01:52:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2601() As StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_IsUpdateNotBelongDiv).ToString() = "1" And tdbg2(i, COL2_EmployeeID).ToString().Trim().Length > 0 Then
                sSQL.Append("-- Insert D13T2601" & vbCrLf)
                sSQL.Append("Insert Into D13T2601(")
                sSQL.Append("DivisionID, SalaryVoucherID, EmployeeID, Note, IsCheck, ")
                sSQL.Append("NoteU, PaymentDate,TranMonth, TranYear, IsNotBelongDiv,IsSub, BankID, BankAccountNo, BankAccountNoU")
                'ANHVU
                For k As Integer = 1 To iColTNH2
                    sSQL.Append("," & tdbg2.Columns(COL2_IsUpdateNotBelongDiv + k).DataField).Replace("TNH", "Amount")
                Next
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg2(i, COL2_Note), gbUnicode, False) & COMMA) 'Note, varchar[1000], NOT NULL
                sSQL.Append(SQLNumber(1) & COMMA) 'IsCheck, tinyint, NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg2(i, COL2_Note), gbUnicode, True) & COMMA) 'NoteU, nvarchar[1000], NOT NULL
                sSQL.Append(SQLDateSave(_voucherDate) & COMMA) 'PaymentDate, datetime, NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'tinyint, datetime, NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'tinyint, datetime, NULL
                sSQL.Append(SQLNumber(1) & COMMA) 'IsNotBelongDiv, tinyint, NOT NULL
                sSQL.Append(SQLNumber(0) & COMMA) 'IsSub, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbg2(i, COL2_BankID)) & COMMA) 'BankID, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg2(i, COL2_BankAccountNo), gbUnicode, False) & COMMA) 'BankAccountNo, varchar[100], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg2(i, COL2_BankAccountNo), gbUnicode, True)) 'BankAccountNoU, varchar[50], NOT NULL
                For k As Integer = 1 To iColTNH2
                    sSQL.Append(COMMA & SQLNumber(tdbg2(i, COL2_IsUpdateNotBelongDiv + k)))
                Next
                sSQL.Append(")" & vbCrLf)
            End If
        Next
        Return sSQL
    End Function

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        usrOption_2.picClose_Click(Nothing, Nothing)
        usrOption.Hide()

        '        giRefreshUserControl = -1
        '        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        '        Me.Controls.Add(usrOption)
        '        usrOption.BringToFront()
        '        usrOption.Visible = True
        If sNameGridFocus = tdbg2.Name Then
            If usrOption_2 Is Nothing Then Exit Sub 'TH lưới không có cột
            usrOption_2.Location = New Point(tdbg2.Left, btnF12.Top - (usrOption_2.Height + 7))
            Me.Controls.Add(usrOption_2)
            usrOption_2.BringToFront()
            usrOption_2.Visible = True
        Else
            'If usrOption_1 Is Nothing Then Exit Sub 'TH lưới không có cột
            'usrOption_1.Location = New Point(tdbg.Left, btnF12.Top - (usrOption_1.Height + 7))
            'Me.Controls.Add(usrOption_1)
            'usrOption_1.BringToFront()
            'usrOption_1.Visible = True

            giRefreshUserControl = -1
            usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
            Me.Controls.Add(usrOption)
            usrOption.BringToFront()
            usrOption.Visible = True
        End If
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
            If tdbg(i, COL_IsUpdate).ToString() = "1" Then
                sSQL.Append("Insert Into D09T6666(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, Key04ID, Key05ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                sSQL.Append(SQLString("D13F2042") & COMMA) 'Key01ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'Key03ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'Key04ID, varchar[250], NOT NULL
                sSQL.Append(SQLString(_salaryVoucherNo)) 'Key05ID, varchar[250], NOT NULL
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
        SetProperties(arrPro, "AuditCode", "SalaryCalTrans")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_TransID).Text)
        SetProperties(arrPro, "mode", "1")
        '     SetProperties(arrPro, "EventID", tdbg.Columns(COL_EventID).Text)
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)
        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "SalaryCalTrans" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_TransID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            'Case COL_OrderNum 'Chặn nhập liệu trên cột STT tăng tự động trong code
            '    e.Handled = CheckKeyPress(e.KeyChar, True)
            Case COL_IsCheck, COL_IsSub 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_BirthDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
            Case COL_Age
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_DutyRef01 To COL_DutyRef05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalCoefficient11, COL_SalCoefficient12, COL_SalCoefficient13, COL_SalCoefficient14, COL_SalCoefficient15, COL_SalCoefficient16, COL_SalCoefficient17, COL_SalCoefficient18, COL_SalCoefficient19, COL_SalCoefficient20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                ' update 13/6/2013 id 56314 - bổ sung 100 cột TNH (Chuyển 200 cột TNH sang cột đông)
            Case COL_Total + 1 To COL_Total + iColTNH ' 200 cột TNH ' 
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH01, COL_TNH02, COL_TNH03, COL_TNH04, COL_TNH05, COL_TNH06, COL_TNH07, COL_TNH08, COL_TNH09, COL_TNH10, COL_TNH11, COL_TNH12, COL_TNH13, COL_TNH14, COL_TNH15, COL_TNH16, COL_TNH17, COL_TNH18, COL_TNH19, COL_TNH20
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH21, COL_TNH22, COL_TNH23, COL_TNH24, COL_TNH25, COL_TNH26, COL_TNH27, COL_TNH28, COL_TNH29, COL_TNH30, COL_TNH31, COL_TNH32, COL_TNH33, COL_TNH34, COL_TNH35, COL_TNH36, COL_TNH37, COL_TNH38, COL_TNH39, COL_TNH40
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH41, COL_TNH42, COL_TNH43, COL_TNH44, COL_TNH45, COL_TNH46, COL_TNH47, COL_TNH48, COL_TNH49, COL_TNH50, COL_TNH51, COL_TNH52, COL_TNH53, COL_TNH54, COL_TNH55, COL_TNH56, COL_TNH57, COL_TNH58, COL_TNH59, COL_TNH60
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH61, COL_TNH62, COL_TNH63, COL_TNH64, COL_TNH65, COL_TNH66, COL_TNH67, COL_TNH68, COL_TNH69, COL_TNH70, COL_TNH71, COL_TNH72, COL_TNH73, COL_TNH74, COL_TNH75, COL_TNH76, COL_TNH77, COL_TNH78, COL_TNH79, COL_TNH80
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH81, COL_TNH82, COL_TNH83, COL_TNH84, COL_TNH85, COL_TNH86, COL_TNH87, COL_TNH88, COL_TNH89, COL_TNH90, COL_TNH91, COL_TNH92, COL_TNH93, COL_TNH94, COL_TNH95, COL_TNH96, COL_TNH97, COL_TNH98, COL_TNH99
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                '            Case COL_TNH100 To COL_TNH200
                '                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub
    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        Select Case tdbg2.Col
            ' update 13/6/2013 id 56314 - bổ sung 100 cột TNH (Chuyển 200 cột TNH sang cột đông)
            Case COL2_IsUpdateNotBelongDiv + 1 To COL2_IsUpdateNotBelongDiv + iColTNH2 ' 200 cột TNH ' 
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)

        End Select
    End Sub

    Private Sub c1date1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date1.KeyDown
        '        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        '        Try
        '            If e.KeyCode = Keys.Tab Then
        '                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
        '                tdbg.Col = tdbg.Col + 1
        '                Exit Sub
        '            End If
        '        Catch ex As Exception
        '        End Try

    End Sub

    Private Sub c1dateDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1dateDate.KeyDown
        '        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        '        Try
        '            If e.KeyCode = Keys.Tab Then
        '                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
        '                tdbg.Col = tdbg.Col + 1
        '                Exit Sub
        '            End If
        '        Catch ex As Exception
        '        End Try

    End Sub

    ' update 13/8/2013 id 57965
    Private Sub mnuUpdateBankID_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateBankID.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim frm As New D13F2045
        With frm
            .SalaryVoucherID = _salaryVoucherID
            .BankAccountNo = ""
            'Lê Anh Vũ: 11/09/2014 ID 66719
            .Mode = 0
            .EmployeeID = ""
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(, 0)
            End If
        End With
    End Sub

    Private Sub D13F2042_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ' If usrOption IsNot Nothing Then usrOption.Dispose()
        '  If usrOption_1 IsNot Nothing Then usrOption_1.Dispose()
        If usrOption_2 IsNot Nothing Then usrOption_2.Dispose()
        ExecuteSQLNoTransaction(SQLDeleteD91T9009(Me.Name, "IMPORT").ToString)
    End Sub

    Private Sub mnuC201_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuC201.Click
        Dim frm As New D13F2045
        frm.EmployeeID = tdbg2.Columns(COL2_EmployeeID).Text
        frm.BankAccountNo = tdbg2.Columns(COL2_BankAccountNo).Text
        frm.SalaryVoucherID = _salaryVoucherID
        frm.Mode = 1
        frm.BankID = tdbg2.Columns(COL2_BankID).Text
        frm.ShowDialog()
        frm.Dispose()
        If frm.bSaved Then
            LoadTDBGrid(, 1)
        End If
    End Sub

    Private Sub D13F2042_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'AnchorForControl(New AnchorStyles() {AnchorStyles.Top, AnchorStyles.Left, AnchorStyles.Right}, New Control() {GroupBox1})

    End Sub

    Private Sub tdbg2_BeforeDelete(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg2.BeforeDelete
        Dim rowDelete As DataRow
        rowDelete = dtGird2.Rows(tdbg2.Row)
        dtGird2Delete.ImportRow(rowDelete)
    End Sub

    Private Sub tdbg2_AfterDelete(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbg2.AfterDelete
        mnuC201.Enabled = dtGird2.Rows.Count > 0 And Not gbClosed
        tdbg2_FooterText()
    End Sub
    Private IsOpenD13F2046 As Integer = 0
    Private Sub btnComparePaymentData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComparePaymentData.Click
        IsOpenD13F2046 = 1
        Dim frm As New D13F2046
        frm.SalaryVoucherID = _salaryVoucherID
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub mnuGird2ImportData_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuGird2ImportData.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD91T9009(Me.Name, "IMPORT").ToString & vbCrLf)
        sSQL.Append(SQLInsertD91T9009_Import.ToString)
        If ExecuteSQL(sSQL.ToString) Then
            If CallShowDialogD80F2090("D13", "D13F5612", "D13F2042") Then
                LoadTDBGrid(True)
            End If

        End If
        Me.Cursor = Cursors.Default
    End Sub

End Class