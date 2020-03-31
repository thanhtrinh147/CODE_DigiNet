Imports System.Windows.Forms
Imports System
Public Class D13F2080
	Dim dtCaptionCols As DataTable

    '#Region "Const of tdbg - Total of Columns: 108"
    '    Private Const COL_EmployeeID As Integer = 0                      ' Mã NV
    '    Private Const COL_EmployeeName As Integer = 1                    ' Họ và tên
    '    Private Const COL_BlockID As Integer = 2                         ' Khối
    '    Private Const COL_BlockName As Integer = 3                       ' Tên khối
    '    Private Const COL_DepartmentID As Integer = 4                    ' Phòng ban
    '    Private Const COL_DepartmentName As Integer = 5                  ' Tên phòng ban
    '    Private Const COL_TeamID As Integer = 6                          ' Tổ nhóm
    '    Private Const COL_TeamName As Integer = 7                        ' Tên tổ nhóm
    '    Private Const COL_EmpGroupID As Integer = 8                      ' Nhóm NV
    '    Private Const COL_EmpGroupName As Integer = 9                    ' Tên nhóm NV
    '    Private Const COL_DutyID As Integer = 10                         ' Chức vụ
    '    Private Const COL_DutyName As Integer = 11                       ' Tên chức vụ
    '    Private Const COL_WorkID As Integer = 12                         ' Công việc
    '    Private Const COL_WorkName As Integer = 13                       ' Tên công việc
    '    Private Const COL_Birthdate As Integer = 14                      ' Ngày sinh
    '    Private Const COL_SexName As Integer = 15                        ' Giới tính
    '    Private Const COL_DateJoined As Integer = 16                     ' Ngày vào làm
    '    Private Const COL_DateLeft As Integer = 17                       ' Ngày nghỉ việc
    '    Private Const COL_Age As Integer = 18                            ' Tuổi
    '    Private Const COL_StatusID As Integer = 19                       ' Trạng thái làm việc
    '    Private Const COL_StatusName As Integer = 20                     ' Tên trạng thái làm việc
    '    Private Const COL_AttendanceCardNo As Integer = 21               ' Mã thẽ chấm công
    '    Private Const COL_RefEmployeeID As Integer = 22                  ' Mả NV phụ
    '    Private Const COL_IncomeTaxCode As Integer = 23                  ' Mã số thuế
    '    Private Const COL_ReferenceNo As Integer = 24                    ' Số tham chiếu
    '    Private Const COL_PITDate As Integer = 25                        ' Ngày quyết toán
    '    Private Const COL_PITPeriodFrom As Integer = 26                  ' Kỳ QT từ
    '    Private Const COL_PITPeriodTo As Integer = 27                    ' Kỳ QT đến
    '    Private Const COL_TotalGeneralncomeAmount12m As Integer = 28     ' Tổng thu nhập chịu thuế
    '    Private Const COL_IncreaseGeneralIncomeAmount12m As Integer = 29 ' Tăng thu nhập chịu thuế
    '    Private Const COL_ReduceGeneralIncomeAmount12m As Integer = 30   ' Giảm thu nhập chịu thuế
    '    Private Const COL_TotalGeneralIncomeAmount As Integer = 31       ' Tổng thu nhập chịu thuế thực tính
    '    Private Const COL_TotalIncomeAmount As Integer = 32              ' Tổng thu nhập tính thuế
    '    Private Const COL_TotalMonth As Integer = 33                     ' Số tháng chịu thuế
    '    Private Const COL_TotalMonthDeduct As Integer = 34               ' Số tháng giảm trừ
    '    Private Const COL_IsDependValidDate As Integer = 35              ' Phụ thuộc ngày hiệu lực
    '    Private Const COL_AVGIncomeAmount As Integer = 36                ' Thu nhập bình quân chịu thuế
    '    Private Const COL_PITAmountOnMonth As Integer = 37               ' Thuế phải nộp 1 tháng
    '    Private Const COL_TotalPITAmount As Integer = 38                 ' Tổng thuế
    '    Private Const COL_TotalTempPITAmount As Integer = 39             ' Thuế đã nộp
    '    Private Const COL_BalanceAmount As Integer = 40                  ' Khấu trừ
    '    Private Const COL_IncomeAmount01 As Integer = 41                 ' TN tính thuế Tháng 1
    '    Private Const COL_IncomeAmount02 As Integer = 42                 ' TN tính thuế Tháng 2
    '    Private Const COL_IncomeAmount03 As Integer = 43                 ' TN tính thuế Tháng 3
    '    Private Const COL_IncomeAmount04 As Integer = 44                 ' TN tính thuế Tháng 4
    '    Private Const COL_IncomeAmount05 As Integer = 45                 ' TN tính thuế Tháng 5
    '    Private Const COL_IncomeAmount06 As Integer = 46                 ' TN tính thuế Tháng 6
    '    Private Const COL_IncomeAmount07 As Integer = 47                 ' TN tính thuế Tháng 7
    '    Private Const COL_IncomeAmount08 As Integer = 48                 ' TN tính thuế Tháng 8
    '    Private Const COL_IncomeAmount09 As Integer = 49                 ' TN tính thuế Tháng 9
    '    Private Const COL_IncomeAmount10 As Integer = 50                 ' TN tính thuế Tháng 10
    '    Private Const COL_IncomeAmount11 As Integer = 51                 ' TN tính thuế Tháng 11
    '    Private Const COL_IncomeAmount12 As Integer = 52                 ' TN tính thuế Tháng 12
    '    Private Const COL_TempPITAmount01 As Integer = 53                ' TN tạm khấu trừ Tháng 1
    '    Private Const COL_TempPITAmount02 As Integer = 54                ' TN tạm khấu trừ Tháng 2
    '    Private Const COL_TempPITAmount03 As Integer = 55                ' TN tạm khấu trừ Tháng 3
    '    Private Const COL_TempPITAmount04 As Integer = 56                ' TN tạm khấu trừ Tháng 4
    '    Private Const COL_TempPITAmount05 As Integer = 57                ' TN tạm khấu trừ Tháng 5
    '    Private Const COL_TempPITAmount06 As Integer = 58                ' TN tạm khấu trừ Tháng 6
    '    Private Const COL_TempPITAmount07 As Integer = 59                ' TN tạm khấu trừ Tháng 7
    '    Private Const COL_TempPITAmount08 As Integer = 60                ' TN tạm khấu trừ Tháng 8
    '    Private Const COL_TempPITAmount09 As Integer = 61                ' TN tạm khấu trừ Tháng 9
    '    Private Const COL_TempPITAmount10 As Integer = 62                ' TN tạm khấu trừ Tháng 10
    '    Private Const COL_TempPITAmount11 As Integer = 63                ' TN tạm khấu trừ Tháng 11
    '    Private Const COL_TempPITAmount12 As Integer = 64                ' TN tạm khấu trừ Tháng 12
    '    Private Const COL_SIAmount01 As Integer = 65                     ' BHXH Tháng 1
    '    Private Const COL_SIAmount02 As Integer = 66                     ' BHXH Tháng 2
    '    Private Const COL_SIAmount03 As Integer = 67                     ' BHXH Tháng 3
    '    Private Const COL_SIAmount04 As Integer = 68                     ' BHXH Tháng 4
    '    Private Const COL_SIAmount05 As Integer = 69                     ' BHXH Tháng 5
    '    Private Const COL_SIAmount06 As Integer = 70                     ' BHXH Tháng 6
    '    Private Const COL_SIAmount07 As Integer = 71                     ' BHXH Tháng 7
    '    Private Const COL_SIAmount08 As Integer = 72                     ' BHXH Tháng 8
    '    Private Const COL_SIAmount09 As Integer = 73                     ' BHXH Tháng 9
    '    Private Const COL_SIAmount10 As Integer = 74                     ' BHXH Tháng 10
    '    Private Const COL_SIAmount11 As Integer = 75                     ' BHXH Tháng 11
    '    Private Const COL_SIAmount12 As Integer = 76                     ' BHXH Tháng 12
    '    Private Const COL_TotalSIAmount As Integer = 77                  ' Tổng BHXH
    '    Private Const COL_HIAmount01 As Integer = 78                     ' BHYT Tháng 1
    '    Private Const COL_HIAmount02 As Integer = 79                     ' BHYT Tháng 2
    '    Private Const COL_HIAmount03 As Integer = 80                     ' BHYT Tháng 3
    '    Private Const COL_HIAmount04 As Integer = 81                     ' BHYT Tháng 4
    '    Private Const COL_HIAmount05 As Integer = 82                     ' BHYT Tháng 5
    '    Private Const COL_HIAmount06 As Integer = 83                     ' BHYT Tháng 6
    '    Private Const COL_HIAmount07 As Integer = 84                     ' BHYT Tháng 7
    '    Private Const COL_HIAmount08 As Integer = 85                     ' BHYT Tháng 8
    '    Private Const COL_HIAmount09 As Integer = 86                     ' BHYT Tháng 9
    '    Private Const COL_HIAmount10 As Integer = 87                     ' BHYT Tháng 10
    '    Private Const COL_HIAmount11 As Integer = 88                     ' BHYT Tháng 11
    '    Private Const COL_HIAmount12 As Integer = 89                     ' BHYT Tháng 12
    '    Private Const COL_TotalHIAmount As Integer = 90                  ' Tổng BHYT
    '    Private Const COL_UIAmount01 As Integer = 91                     ' BHTN Tháng 1
    '    Private Const COL_UIAmount02 As Integer = 92                     ' BHTN Tháng 2
    '    Private Const COL_UIAmount03 As Integer = 93                     ' BHTN Tháng 3
    '    Private Const COL_UIAmount04 As Integer = 94                     ' BHTN Tháng 4
    '    Private Const COL_UIAmount05 As Integer = 95                     ' BHTN Tháng 5
    '    Private Const COL_UIAmount06 As Integer = 96                     ' BHTN Tháng 6
    '    Private Const COL_UIAmount07 As Integer = 97                     ' BHTN Tháng 7
    '    Private Const COL_UIAmount08 As Integer = 98                     ' BHTN Tháng 8
    '    Private Const COL_UIAmount09 As Integer = 99                     ' BHTN Tháng 9
    '    Private Const COL_UIAmount10 As Integer = 100                    ' BHTN Tháng 10
    '    Private Const COL_UIAmount11 As Integer = 101                    ' BHTN Tháng 11
    '    Private Const COL_UIAmount12 As Integer = 102                    ' BHTN Tháng 12
    '    Private Const COL_TotalUIAmount As Integer = 103                 ' Tổng BHTN
    '    Private Const COL_CreateUserID As Integer = 104                  ' CreateUserID
    '    Private Const COL_CreateDate As Integer = 105                    ' CreateDate
    '    Private Const COL_LastModifyUserID As Integer = 106              ' LastModifyUserID
    '    Private Const COL_LastModifyDate As Integer = 107                ' LastModifyDate
    '#End Region

#Region "Const of tdbg - Total of Columns: 28"
    Private Const COL_EmployeeID As Integer = 0        ' Mã NV
    Private Const COL_EmployeeName As Integer = 1      ' Họ và tên
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
    Private Const COL_Birthdate As Integer = 14        ' Ngày sinh
    Private Const COL_SexName As Integer = 15          ' Giới tính
    Private Const COL_DateJoined As Integer = 16       ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 17         ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 18              ' Tuổi
    Private Const COL_StatusID As Integer = 19         ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 20       ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 21 ' Mã thẽ chấm công
    Private Const COL_RefEmployeeID As Integer = 22    ' Mả NV phụ
    Private Const COL_IncomeTaxCode As Integer = 23    ' Mã số thuế
    Private Const COL_CreateUserID As Integer = 24     ' CreateUserID
    Private Const COL_CreateDate As Integer = 25       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 26 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 27   ' LastModifyDate
#End Region

    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtEmployeeID As New DataTable
    Dim dt As DataTable
    Private sYearChoose As String = ""
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    'Private arrMaster As New ArrayList ' Mảng Master
    ''*****************************************
    Dim bLoadD13F2081 As Boolean = False 'Ktra xem co goi D13F2081 k?

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private _pITBalanceVoucherID As String = ""
    Public Property PITBalanceVoucherID() As String
        Get
            Return _pITBalanceVoucherID
        End Get
        Set(ByVal Value As String)
            _pITBalanceVoucherID = Value
        End Set
    End Property

    Private _pITYear As String = ""
    Public WriteOnly Property PITYear() As String
        Set(ByVal Value As String)
            _pITYear = Value
        End Set
    End Property

    Private _strEmployeeID As String = ""
    Public WriteOnly Property StrEmployeeID() As String
        Set(ByVal Value As String)
            _strEmployeeID = Value
        End Set
    End Property

    Private _strEmployeeName As String = ""
    Public WriteOnly Property StrEmployeeName() As String
        Set(ByVal Value As String)
            _strEmployeeName = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _blockID As String = ""
    Public WriteOnly Property BlockID() As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _workingStatusID As String = ""
    Public WriteOnly Property WorkingStatusID() As String
        Set(ByVal Value As String)
            _workingStatusID = Value
        End Set
    End Property

    Private _callFromD13F2081 As Boolean = False
    Public WriteOnly Property CallFromD13F2081() As Boolean 
        Set(ByVal Value As Boolean )
            _callFromD13F2081 = Value
        End Set
    End Property

    Private Enum Button
        InfoCalculated = 0          ' Thông tin quyết toán
        InfoTaxIncome = 1           ' Thông tin khai thuế  
        InfoInsurance = 2           ' Thông tin bảo hiểm
        Others = 3                  'Thông tin khác
    End Enum

    Private Structure FromTo
        Public ButtonFrom As Integer
        Public ButtonTo As Integer
    End Structure

    Private dicIndexButton As Dictionary(Of Button, FromTo)

    Private dataCaptionForG As DataTable
    Private iColAdd As Integer = 0

    Private TOTAL As Integer
    Public Sub GetIndexButton()
        dicIndexButton = New Dictionary(Of Button, FromTo)
        If dataCaptionForG Is Nothing OrElse dataCaptionForG.Rows.Count = 1 Then Exit Sub
        'Thông tin quyết toán
        Dim _dr() As DataRow
        For e As Button = Button.InfoCalculated To Button.Others
            _dr = dataCaptionForG.Select("TabIndex = " & SQLNumber(e + 1))
            If _dr.Length > 0 Then
                Dim sFromTo As New FromTo
                Dim iFrom As Integer = dataCaptionForG.Rows.IndexOf(_dr(0))
                sFromTo.ButtonFrom = TOTAL + iFrom
                sFromTo.ButtonTo = TOTAL + iFrom + _dr.Length - 1
                If Not dicIndexButton.ContainsKey(e) Then dicIndexButton.Add(e, sFromTo)
            End If
        Next
    End Sub

    Private Sub LoadCaption()
        TOTAL = tdbg.Columns.Count
        Dim sSQL As String = ""
        sSQL = SQLStoreD09P6700()
        dataCaptionForG = ReturnDataTable(sSQL)
        If dataCaptionForG Is Nothing OrElse dataCaptionForG.Rows.Count < 1 Then
            'tdbg.Splits.RemoveAt(1)
            tdbg.RemoveHorizontalSplit(1)
        Else
            Dim sColLang As String
            If geLanguage = EnumLanguage.Vietnamese Then
                sColLang = "Caption84U"
            Else
                sColLang = "Caption01U"
            End If
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            iColAdd = dataCaptionForG.Rows.Count
            For iCol As Integer = 0 To dataCaptionForG.Rows.Count - 1
                'Chỉ ép những cột ở SplitNo = 1
                If L3Int(dataCaptionForG.Rows(iCol).Item("SplitNo")) <> 1 Then Continue For
                ' Add cột Type vào lưới
                dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                dc.DataField = dataCaptionForG.Rows(iCol).Item("FieldName").ToString
                tdbg.Columns.Add(dc)
                dc.Caption = dataCaptionForG.Rows(iCol).Item(sColLang).ToString
                tdbg.Splits(1).DisplayColumns(dc).Width = L3Int(dataCaptionForG.Rows(iCol).Item("Length"))
                tdbg.Splits(1).DisplayColumns(dc).Visible = True

                tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                tdbg.Splits(1).DisplayColumns(dc).Style.Font = FontUnicode(gbUnicode)
                tdbg.Splits(1).DisplayColumns(dc).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                Try
                    Dim sDataFormat As String
                    sDataFormat = L3String(dataCaptionForG.Rows(iCol).Item("DataFormat"))
                    If L3String(dataCaptionForG.Rows(iCol).Item("DataType")) = "N" AndAlso sDataFormat.Length >= 2 AndAlso IsNumeric(sDataFormat.Substring(1, sDataFormat.Length - 1)) Then
                        tdbg.Columns(dc.DataField).NumberFormat = InsertFormat(sDataFormat.Substring(1, sDataFormat.Length - 1))
                    ElseIf L3String(dataCaptionForG.Rows(iCol).Item("DataType")) = "D" Then
                        InputDateInTrueDBGrid(tdbg, dc.DataField)
                    ElseIf L3String(dataCaptionForG.Rows(iCol).Item("ControlType")) = "CH" Then
                        tdbg.Columns(dc.DataField).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                        tdbg.Splits(1).DisplayColumns(dc).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End If
                Catch ex As Exception
                    D99C0008.MsgL3("Error: " & ex.Message)
                End Try
            Next

        End If
        GetIndexButton()
    End Sub


    Private Sub D13F2082_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F11
                HotKeyF11(Me, tdbg, 0, 1)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N 'sua
                    'If tsbAdd.Enabled And tsbAdd.Visible Then tsbAdd.ShowDropDown()
                    If tsbAdd.Enabled And tsbAdd.Visible Then tsbAdd_Click(Nothing, Nothing)
                Case Keys.D 'sua
                    If tsbDelete.Enabled And tsbDelete.Visible Then tsbDelete_Click(Nothing, Nothing)
                Case Keys.I 'sua
                    If tsbSysInfo.Enabled And tsbSysInfo.Visible Then tsbSysInfo_Click(Nothing, Nothing)
                Case Keys.F  'Tìm kiếm
                    If tsbFind.Enabled And tsbFind.Visible Then tsbFind_Click(Nothing, Nothing)
                Case Keys.A 'Liệt kê tất cả
                    If tsbListAll.Enabled And tsbListAll.Visible Then tsbListAll_Click(Nothing, Nothing)
                Case Keys.P 'In
                    If tsbPrint.Enabled And tsbPrint.Visible Then tsbPrint_Click(Nothing, Nothing)
            End Select
        End If
        ' 16/11/2012 id 51174
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub


    'Dim dtCaptionCols As DataTable = 
    Private Sub D13F2082_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, tbrToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        LoadCaption()
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft)

        SetBackColorObligatory()
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, 1)

        CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        VisibleBlock()

        LoadTDBCombo()
        ' CallD09U1111_Button(True) ' update 16/11/2012 id 51174
        CallD99U1111(True)
        LoadDefaultValue()

        '   tdbg.Columns(COL_Birthdate).Editor = c1dateDate

        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID, txtStrEmployeeID.MaxLength)
        InputDateInTrueDBGrid(tdbg, COL_Birthdate)

        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPITYear.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefaultValue()
        If _callFromD13F2081 Then ' update 7/5/5013 id 56081
            tdbcPITYear.SelectedValue = _pITYear
            txtStrEmployeeID.Text = _strEmployeeID
            txtStrEmployeeName.Text = _strEmployeeName
            tdbcBlockID.SelectedValue = _blockID
            tdbcDepartmentID.SelectedValue = _departmentID
            tdbcTeamID.SelectedValue = _teamID
            tdbcWorkingStatusID.SelectedValue = _workingStatusID
            tdbcEmployeeID.SelectedValue = _employeeID

            btnInfoCalculate_Click(Nothing, Nothing)
            btnFilter_Click(Nothing, Nothing)
        Else
            tdbcPITYear.SelectedIndex = 0
            tdbcBlockID.SelectedValue = "%"
            tdbcWorkingStatusID.SelectedValue = "%"
            tdbcEmployeeID.SelectedValue = "%"
            'btnInfoCalculate.Enabled = False
            btnInfoCalculate_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub VisibleBlock()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = CBool(D13Systems.IsUseBlock)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = CBool(D13Systems.IsUseBlock)
        tdbcBlockID.Enabled = CBool(D13Systems.IsUseBlock)
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Quyet_toan_thue_TNCN_-_D13F2080") & UnicodeCaption(gbUnicode) 'QuyÕt toÀn thuÕ TNCN - D13F2080
        '================================================================ 
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblTranYear.Text = rl3("Nam_quyet_toan") 'Năm quyết toán
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnInfoCalculate.Text = "&1. " & rl3("Thong_tin_quyet_toan") 'Thông tin quyết toán
        btnInfoTax.Text = "&2. " & rl3("Thong_tin_khai_thue") 'Thông tin khai thuế
        btnInfoInsurance.Text = "&3. " & rl3("Thong_tin_bao_hiem") 'Thông tin bảo hiểm
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnF12.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        tdbg.Columns("EmployeeID").Caption = rL3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rL3("Ho_va_ten")
        tdbg.Columns("BlockID").Caption = rL3("Khoi") 'Khối
        tdbg.Columns("DepartmentID").Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rL3("Nhom_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupName").Caption = rL3("Ten_nhom_NV") 'Họ và tên
        tdbg.Columns("BirthDate").Caption = rL3("Ngay_sinh") 'Ngày sinh
        ' update 15/11/2012 id 51174
        tdbg.Columns("BlockID").Caption = rL3("Khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns("DutyID").Caption = rL3("Chuc_vu")
        tdbg.Columns("DutyName").Caption = rL3("Ten_chuc_vu")
        tdbg.Columns("SexName").Caption = rL3("Gioi_tinh")
        tdbg.Columns("WorkID").Caption = rL3("Cong_viec")
        tdbg.Columns("WorkName").Caption = rL3("Ten_cong_viec")
        tdbg.Columns("DateJoined").Caption = rL3("Ngay_vao_lam")
        tdbg.Columns("DateLeft").Caption = rL3("Ngay_nghi_viec")
        tdbg.Columns("Age").Caption = rL3("Tuoi")
        tdbg.Columns("StatusID").Caption = rL3("Trang_thai_lam_viec")
        tdbg.Columns("StatusName").Caption = rL3("Ten_trang_thai_lam_viec")
        tdbg.Columns("AttendanceCardNo").Caption = rL3("Ma_the_cham_cong")
        tdbg.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        '================================================================ 
        tdbg.Columns("IncomeTaxCode").Caption = rL3("Ma_so_thue") 'Mã số thuế

    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
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


    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String
        strFind = sFind
        If sFilter.ToString() <> "" Then
            If strFind <> "" Then
                strFind &= " And " & sFilter.ToString
            Else
                strFind &= sFilter.ToString
            End If
        End If

        ' LoadGridFind(tdbg, dt, strFind)
        dt.DefaultView.RowFilter = strFind
        CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        Tdbg_Footer()
    End Sub
#End Region

    'Private Sub Tdbg_Footer()
    '    Dim iCols() As Integer = {COL_TotalIncomeAmount, COL_TotalMonth, COL_TotalMonthDeduct, COL_AVGIncomeAmount, COL_PITAmountOnMonth, COL_TotalPITAmount, COL_TotalTempPITAmount, COL_BalanceAmount, _
    '        COL_IncomeAmount01, COL_IncomeAmount02, COL_IncomeAmount03, COL_IncomeAmount04, COL_IncomeAmount05, COL_IncomeAmount06, COL_IncomeAmount07, COL_IncomeAmount08, COL_IncomeAmount09, COL_IncomeAmount10, COL_IncomeAmount11, COL_IncomeAmount12, _
    '        COL_TempPITAmount01, COL_TempPITAmount02, COL_TempPITAmount03, COL_TempPITAmount04, COL_TempPITAmount05, COL_TempPITAmount06, COL_TempPITAmount07, COL_TempPITAmount08, COL_TempPITAmount09, COL_TempPITAmount10, COL_TempPITAmount11, COL_TempPITAmount12}
    '    'COL_SIAmount01, COL_SIAmount02, COL_SIAmount03, COL_SIAmount04, COL_SIAmount05, COL_SIAmount06, COL_SIAmount07, _
    '    'COL_SIAmount08, COL_SIAmount09, COL_SIAmount10, COL_SIAmount11, COL_SIAmount12, COL_TotalSIAmount, COL_HIAmount01, _
    '    'COL_HIAmount02, COL_HIAmount03, COL_HIAmount04, COL_HIAmount05, COL_HIAmount06, COL_HIAmount07, COL_HIAmount08, _
    '    'COL_HIAmount09, COL_HIAmount10, COL_HIAmount11, COL_HIAmount12, COL_TotalHIAmount, COL_UIAmount01, COL_UIAmount02, _
    '    'COL_UIAmount03, COL_UIAmount04, COL_UIAmount05, COL_UIAmount06, COL_UIAmount07, COL_UIAmount08, COL_UIAmount09, _
    '    'COL_UIAmount10, COL_UIAmount11, COL_UIAmount12, COL_TotalUIAmount}
    '    'ToTalFooter(tdbg, iCols)
    '    FooterSum(tdbg, iCols)
    '    FooterTotalGrid(tdbg, COL_EmployeeName)
    'End Sub
    Private SPLIT_CHAR As Char = ";"c
    Private Function ListControlFormat(ByVal sControlFormat As String) As List(Of String)
        If sControlFormat Is Nothing OrElse sControlFormat = "" Then Return Nothing
        Dim _list As New List(Of String)
        Dim arrCF() As String
        arrCF = sControlFormat.Split(SPLIT_CHAR)
        _list.AddRange(arrCF)
        Return _list
    End Function

    Private Sub Tdbg_Footer()
        Dim iCols() As Integer = {}
        FooterSumNew(tdbg, iCols)
        FooterTotalGrid(tdbg, COL_EmployeeName)
        '10/03/2015 : Bổ sung cột tổng cộng theo cộng động
        For index As Integer = 0 To iColAdd - 1
            Dim _list As List(Of String)
            _list = ListControlFormat(L3String(dataCaptionForG.Rows(index)("ControlFormat")))
            If _list.Contains("SumFooter") Then
                FootTextColumns(COL_LastModifyDate + 1 + index, L3String(dataCaptionForG.Rows(index)("DataFormat")))
            ElseIf _list.Contains("CountFooter") Then
                FooterTotalGrid(tdbg, COL_LastModifyDate + 1 + index)
            End If
        Next
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String
        sYearChoose = tdbcPITYear.Text ' Giữ lại năm quyết toán vừa lọc để xóa.
        sSQL = SQLStoreD13P4070()
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count < 1 Then 'Không có dữ liệu
            gbEnabledUseFind = False
            LoadDataSource(tdbg, dt, gbUnicode)
            CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        Else 'Có dữ liệu
            If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
                LoadDataSource(tdbg, dt, gbUnicode)
                CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
            Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
                ReLoadTDBGrid()
            End If
        End If

        Tdbg_Footer()

    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcPITYear
        sSQL = "SELECT     DISTINCT TranYear" & vbCrLf
        sSQL &= "FROM       D09T9999  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE	    DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY   TranYear DESC" & vbCrLf
        LoadDataSource(tdbcPITYear, sSQL, gbUnicode)

        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcEmployeeID
        dtEmployeeID = ReturnTableEmployeeID(True, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        'Load tdbcWorkingStatusID
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

    End Sub

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ComboValue(tdbcBlockID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then Exit Sub

        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), gbUnicode)
        Else
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
        End If
        tdbcEmployeeID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then
            tdbcWorkingStatusID.Text = ""
        End If
    End Sub

    Private Sub tdbcWorkingStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.SelectedValueChanged
        If tdbcTeamID.SelectedValue Is Nothing Then Exit Sub
        If tdbcWorkingStatusID.SelectedValue Is Nothing Then
            LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", "-1", gbUnicode)

            Exit Sub
        End If
        LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, ComboValue(tdbcBlockID), ComboValue(tdbcDepartmentID), ComboValue(tdbcTeamID), ComboValue(tdbcWorkingStatusID), gbUnicode)
        tdbcEmployeeID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPITYear"

    Private Sub tdbcPITYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITYear.LostFocus
        If tdbcPITYear.FindStringExact(tdbcPITYear.Text) = -1 Then tdbcPITYear.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen, tdbcEmployeeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, tdbcEmployeeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcWorkingStatusID.KeyUp, tdbcEmployeeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub ClickButton(ByVal but As Button, Optional ByVal bFlagLoad As Boolean = False)
        If dicIndexButton Is Nothing Then Exit Sub
        btnInfoCalculate.Enabled = Math.Abs(but - Button.InfoCalculated) > 0
        btnInfoTax.Enabled = Math.Abs(but - Button.InfoTaxIncome) > 0 'And bUseAna
        btnInfoInsurance.Enabled = Math.Abs(but - Button.InfoInsurance) > 0
        btnOthers.Enabled = Math.Abs(but - Button.Others) > 0
        '1. Thông tin chính
        'If dicIndexButton.ContainsKey(Button.InfoCalculated) Then
        '    For i As Integer = dicIndexButton(Button.InfoCalculated).ButtonFrom To dicIndexButton(Button.InfoCalculated).ButtonTo
        '        tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        '    Next
        'End If

        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TotalIncomeAmount).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TotalMonth).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        '' update 18/4/2013 id 55320 - Bổ sung thông tin COL_TotalMonthDeduct, COL_IsDependValidDate
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TotalMonthDeduct).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IsDependValidDate).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_AVGIncomeAmount).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_PITAmountOnMonth).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TotalPITAmount).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TotalTempPITAmount).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_BalanceAmount).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_ReferenceNo).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_PITDate).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_PITPeriodFrom).Visible = Math.Abs(but - Button.InfoCalculated) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_PITPeriodTo).Visible = Math.Abs(but - Button.InfoCalculated) = 0

        '2. Thông tin phụ
        'If dicIndexButton.ContainsKey(Button.InfoTaxIncome) Then
        '    For i As Integer = dicIndexButton(Button.InfoTaxIncome).ButtonFrom To dicIndexButton(Button.InfoTaxIncome).ButtonTo
        '        tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        '    Next
        'End If

        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount01).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount02).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount03).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount04).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount05).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount06).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount07).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount08).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount09).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount10).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount11).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_IncomeAmount12).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0

        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount01).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount02).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount03).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount04).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount05).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount06).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount07).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount08).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount09).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount10).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount11).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TempPITAmount12).Visible = Math.Abs(but - Button.InfoTaxIncome) = 0

        ' Hiện tại đang hiện 2 cột COL_LastModifyDate => Đã hỏi chị Thuận, ko biết lỗi hay do ID nên giữ nguyên
        'If dicIndexButton.ContainsKey(Button.InfoInsurance) Then
        '    For i As Integer = dicIndexButton(Button.InfoInsurance).ButtonFrom To dicIndexButton(Button.InfoInsurance).ButtonTo
        '        tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(but - Button.InfoInsurance) = 0
        '    Next
        'End If
        'If dicIndexButton.ContainsKey(Button.Others) Then
        '    For i As Integer = dicIndexButton(Button.Others).ButtonFrom To dicIndexButton(Button.Others).ButtonTo
        '        tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = Math.Abs(but - Button.Others) = 0
        '    Next
        'End If

        'ID 102757 23.08.2017 Sửa lỗi khi ko có thiết lập tại Tab Khác
        If dicIndexButton.Count =< but then Exit sub

        If bFlagLoad Then Exit Sub 'TH Tìm kiếm và Xuất Excel
        'Chuẩn hóa D09U1111 B6: Refresh lại lưới
        tdbg.Focus()
        tdbg.SplitIndex = 1
        tdbg.Col = dicIndexButton(but).ButtonFrom
        'tdbg.Refresh()
        'CallD99U1111(, but)
    End Sub

    Private Sub btnInfoCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoCalculate.Click
        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp 
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If
        If sender Is Nothing Then
            ClickButton(Button.InfoCalculated, True)
        Else
            ClickButton(Button.InfoCalculated)
        End If

    End Sub

    Private Sub btnInfoTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoTax.Click
        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If
        ClickButton(Button.InfoTaxIncome)
    End Sub

    Private Sub btnInfoInsurance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoInsurance.Click
        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If
        ClickButton(Button.InfoInsurance)
    End Sub


    Private Sub btnOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOthers.Click
        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If
        ClickButton(Button.Others)
    End Sub


    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg, COL_EmployeeName)
        FootTextColumns(COL_EmployeeName, D13Format.DefaultNumber2)
        For index As Integer = 0 To iColAdd - 1
            If L3Int(dataCaptionForG.Rows(index)("TotalColumn")) = 1 Then
                FootTextColumns(COL_LastModifyDate + 1 + index, L3String(dataCaptionForG.Rows(index)("DataFormat")))
            End If
        Next
    End Sub

    Private Sub FootTextColumns(ByVal iCol As Integer, ByVal sNumberFormat As String)
        Dim Sum As Double = 0
        For j As Int32 = 0 To tdbg.RowCount - 1
            Sum += Number(SQLNumber(tdbg(j, iCol).ToString, sNumberFormat))
        Next
        tdbg.Columns(iCol).FooterText = SQLNumber(Sum.ToString, sNumberFormat)
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcPITYear.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nam_quyet_toan"))
            tdbcPITYear.Focus()
            Return False
        End If
        Return True
    End Function

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        btnFilter.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If

        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()

        'CallD09U1111_Button(False)
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        btnFilter.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbcDivisionID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcBlockID.Leave, tdbcEmployeeID.Leave, tdbcWorkingStatusID.Leave
        If gbUnicode Then Exit Sub
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.SelectedIndex <> -1 Then
            tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
        End If
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        If Not CheckStore(SQLStoreD13P5555(2)) Then Exit Sub

        'If Not bLoadD13F2081 Then
        '    vcNewTemp = vcNew
        '    Array.Copy(matrix, matrixTemp, 20)
        'End If
        bLoadD13F2081 = True
        If usrOption.Visible Then usrOption.Hide()

        Dim frm As New D13F2081
        With frm
            .FormState = EnumFormState.FormAdd
            .PITYear = tdbcPITYear.Text
            .CallFromD13F2080 = True ' update 7/5/5013 id 56081
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        'If Not CheckStore(SQLStoreD13P5555(1)) Then Exit Sub

        'Dim sSQL As String = ""
        'Dim bResult As Boolean
        'If AskDelete() = Windows.Forms.DialogResult.Yes Then

        '    Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        '    If aSelectRows.Count > 0 Then
        '        For i As Integer = 0 To aSelectRows.Count - 1
        '            sSQL &= SQLDeleteD13T2083(tdbg(aSelectRows.Item(i), COL_EmployeeID).ToString) & vbCrLf
        '        Next

        '    Else
        '        sSQL = SQLDeleteD13T2083(tdbg.Columns(COL_EmployeeID).Text)
        '    End If

        '    'sSQL = SQLDeleteD13T2083(tdbg.Columns(COL_EmployeeID).Text)
        '    bResult = ExecuteSQL(sSQL)
        '    If bResult Then
        '        DeleteOK()
        '        Dim Bookmark As Integer
        '        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        '        LoadTDBGrid()
        '        If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        '    Else
        '        DeleteNotOK()
        '    End If
        'End If
        If Not CheckStore(SQLStoreD13P5555(1)) Then Exit Sub

        Dim sSQL As String = ""
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
            If aSelectRows.Count > 0 Then
                For i As Integer = 0 To aSelectRows.Count - 1
                    sSQL &= SQLDeleteD13T2083(tdbg(aSelectRows.Item(i), COL_EmployeeID).ToString) & vbCrLf
                    sSQL &= SQLDeleteD13T2085(tdbg(aSelectRows.Item(i), COL_EmployeeID).ToString) & vbCrLf

                Next
            Else
                sSQL = SQLDeleteD13T2083(tdbg.Columns(COL_EmployeeID).Text)
                sSQL &= SQLDeleteD13T2085(tdbg.Columns(COL_EmployeeID).Text)
            End If

            'sSQL = SQLDeleteD13T2083(tdbg.Columns(COL_EmployeeID).Text)
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteOK()
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid()
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        If usrOption IsNot Nothing And bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If

        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        CallD09U1111_Button(True)
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    ''Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    'Private usrOption As D09U1111
    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'Đặt các dòng code sau vào cuối FormLoad
        'Dim arr As New ArrayList ' Mảng Master
        'AddColVisible(tdbg, SPLIT0, arr, , , , gbUnicode)
        'AddColVisible(tdbg, SPLIT1, arr, , , , gbUnicode)
        ''Dim dtCaptionCols As DataTable = CreateTableForExcelOnly(tdbg, arr)
        'usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0")
        '*****************************************

        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        If usrOption IsNot Nothing And bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If

        'Gọi form Xuất Excel như sau:
        CallD09U1111_Button(True)
        ResetTableForExcel(tdbg, dtCaptionCols)

        CallShowD99F2222(Me, dtCaptionCols, dt, gsGroupColumns)
        '        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        '        Dim frm As New D99F2222
        '        ResetTableForExcel(tdbg, gdtCaptionExcel)
        '        With frm
        '            .FormID = Me.Name
        '            .UseUnicode = gbUnicode
        '            .dtLoadGrid = gdtCaptionExcel
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dt
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '*****************************************
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PITBalanceVoucherID", _pITBalanceVoucherID)
        SetProperties(arrPro, "BlockID", ComboValue(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ComboValue(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ComboValue(tdbcTeamID))
        SetProperties(arrPro, "WhereClause", sFind)
        SetProperties(arrPro, "PITYear", tdbcPITYear.Text)

        SetProperties(arrPro, "StrEmployeeID", txtStrEmployeeID.Text)
        SetProperties(arrPro, "StrEmployeeName", txtStrEmployeeName.Text)
        SetProperties(arrPro, "WorkingStatusID", ComboValue(tdbcWorkingStatusID))
        SetProperties(arrPro, "EmployeeID", ComboValue(tdbcEmployeeID))

        CallFormShow(Me, "D13D0340", "D13F4070", arrPro)

        '        Dim f As New D13M0340
        '        With f
        '            .FormActive = enumD13E0340Form.D13F4070
        '            .ID01 = _pITBalanceVoucherID 'PITBalanceVoucherID
        '            .ID02 = ComboValue(tdbcBlockID) 'BlockID
        '            .ID03 = ComboValue(tdbcDepartmentID) 'DepartmentID
        '            .ID04 = ComboValue(tdbcTeamID) 'TeamID
        '            .ID05 = sFind 'WhereClause
        '            .ID06 = tdbcPITYear.Text 'PITYear
        '            .ID07 = txtStrEmployeeID.Text 'StrEmployeeID
        '            .ID08 = txtStrEmployeeName.Text 'StrEmployeeName
        '            .ID09 = ComboValue(tdbcWorkingStatusID) 'WorkingStatusID
        '            .ID10 = ComboValue(tdbcEmployeeID) 'EmployeeID
        '
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dt Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            sFilter = New StringBuilder("")
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            For Each dc In Me.tdbg.Columns
                Select Case dc.DataType.Name
                    Case "DateTime"
                        If dc.FilterText.Length = 10 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            Dim sClause As String = ""
                            sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
                            sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
                            sFilter.Append(sClause)
                        End If

                    Case "Boolean"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
                        End If

                    Case "String"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
                        End If

                    Case "Byte", "Integer", "Int16", "Int32", "Int64"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
                        End If

                    Case "Decimal", "Double", "Single"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
                        End If

                End Select
            Next

            '13/04/2015: Không viết đặc thù. Gọi DLL chung  
            'FilterChangeGrid(tdbg, sFilter)

            'Filter the data 
            If sFilter.ToString() <> "" And sFind <> "" Then
                dt.DefaultView.RowFilter = sFilter.ToString() & " AND " & sFind
            ElseIf sFind <> "" Then
                dt.DefaultView.RowFilter = sFind
            ElseIf sFind = "" Then
                dt.DefaultView.RowFilter = sFilter.ToString()
            End If

            CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
            FooterTotalGrid(tdbg, COL_EmployeeName)

        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress

        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Birthdate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
            Case COL_Age
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_LastModifyDate + 1 To COL_LastModifyDate + iColAdd
                Dim _dr() As DataRow
                _dr = dataCaptionForG.Select("FieldName = " & SQLString(tdbg.Columns(tdbg.Col).DataField))
                If _dr.Length > 0 AndAlso L3String(_dr(0)("DataType")) = "N" Then e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    'Vào sự kiện c1dateDate_KeyDown viết code như sau:
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

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2083
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 09/12/2010 04:27:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2083(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2083 "
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(sEmployeeID) & " And "
        sSQL &= "PITYear = " & SQLNumber(tdbcPITYear.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 21/12/2010 01:25:37
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
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4070
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 31/08/2009 10:34:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4070() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_pITBalanceVoucherID) & COMMA 'PITBalanceVoucherID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, int, NOT NULL
        sSQL &= SQLNumber(tdbcPITYear.Text) & COMMA 'PITYear, int, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= "N" & SQLString(txtStrEmployeeName.Text) & COMMA 'StrEmployeeName, nvarchar, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcEmployeeID)) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6700
    '# Created User: Lê Anh Vũ
    '# Created Date: 10/03/2015 10:41:06
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6700() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do caption dong cho luoi" & vbCrlf)
        sSQL &= "Exec D09P6700 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString("") 'TransType, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2085
    '# Created User: Lê Anh Vũ
    '# Created Date: 19/03/2015 02:47:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2085(ByVal sEmployeeID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Thuc thi xoa D13T2085" & vbCrLf)
        sSQL &= "Delete From D13T2085"
        sSQL &= " Where "
        sSQL &= "EmployeeID = " & SQLString(sEmployeeID) & " And "
        sSQL &= "PITYear = " & SQLNumber(sYearChoose)
        Return sSQL
    End Function



    '' update 16/11/2012 id 51174
    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        Dim arrMaster As New ArrayList ' Mảng Master
        '*****************************************
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_EmployeeID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
           
        End If
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
       

    End Sub
    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = False, Optional ByVal but As Integer = 0)
        If bLoad Then
            Dim arrColObligatory() As Object = {COL_EmployeeID}
            usrOption.AddColVisible(tdbg, 0, dtF12, , arrColObligatory, COL_EmployeeID, COL_IncomeTaxCode)
            'If dicIndexButton IsNot Nothing AndAlso dicIndexButton.ContainsKey(Button.InfoCalculated) Then usrOption.AddColVisible(tdbg, 1, dtF12, , arrColObligatory, dicIndexButton(Button.InfoCalculated).ButtonFrom, dicIndexButton(Button.InfoCalculated).ButtonTo, False, 0)
            'If dicIndexButton IsNot Nothing AndAlso dicIndexButton.ContainsKey(Button.InfoInsurance) Then usrOption.AddColVisible(tdbg, 1, dtF12, , arrColObligatory, dicIndexButton(Button.InfoInsurance).ButtonFrom, dicIndexButton(Button.InfoInsurance).ButtonTo, , 1)
            'If dicIndexButton IsNot Nothing AndAlso dicIndexButton.ContainsKey(Button.InfoTaxIncome) Then usrOption.AddColVisible(tdbg, 1, dtF12, , arrColObligatory, dicIndexButton(Button.InfoTaxIncome).ButtonFrom, dicIndexButton(Button.InfoTaxIncome).ButtonTo, , 2)
            'If dicIndexButton IsNot Nothing AndAlso dicIndexButton.ContainsKey(Button.Others) Then usrOption.AddColVisible(tdbg, 1, dtF12, , arrColObligatory, dicIndexButton(Button.Others).ButtonFrom, dicIndexButton(Button.Others).ButtonTo, , 3)
            usrOption.AddColVisible(tdbg, 1, dtF12, , arrColObligatory)
        End If
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    ' update 16/11/2012 id 51174
    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If bLoadD13F2081 Then
            'vcNew = vcNewTemp
            'Array.Copy(matrixTemp, matrix, 20) 'matrix = matrixTemp
            giRefreshUserControl = 0
            'usrOption.D09U1111Refresh()
            bLoadD13F2081 = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    'Private Sub Call_D09U1111Refresh()
    '    'Chuẩn hóa D09U1111 B6: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
    '    'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
    '    If usrOption IsNot Nothing Then
    '        'usrOption.MarkInvisibleColumn(SPLIT1)
    '        'usrOption.D09U1111Refresh()
    '    End If
    'End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
    End Sub

    Private Sub D13F2080_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub
End Class