Imports System
Public Class D13F2026
	Dim dtCaptionCols As DataTable
	'Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_IsAdjust As Integer = 0        ' Điều chỉnh
    Private Const COL_IsCheck As Integer = 1         ' Đã kiểm tra
    Private Const COL_DepartmentID As Integer = 2    ' Phòng ban
    Private Const COL_TeamID As Integer = 3          ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 4      ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 5    ' Họ và tên
    Private Const COL_RefEmployeeID As Integer = 6   ' Mã nhân viên phụ
    Private Const COL_AbsentVoucherID As Integer = 7 ' AbsentVoucherID
    Private Const COL_Remark As Integer = 8          ' Phiếu điều chỉnh thu nhập
    Private Const COL_TransID As Integer = 9         ' TransID
#End Region
    Private Const COL_Total As Integer = 9

    Private _salaryVoucherID As String = ""
    Public Property SalaryVoucherID() As String 
        Get
            Return _salaryVoucherID
        End Get
        Set(ByVal Value As String )
            _salaryVoucherID = Value
        End Set
    End Property

    Private _transferMethodID As String = ""
    Public Property TransferMethodID() As String 
        Get
            Return _transferMethodID
        End Get
        Set(ByVal Value As String )
            _transferMethodID = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String 
        Get
            Return _payrollVoucherID
        End Get
        Set(ByVal Value As String )
            _payrollVoucherID = Value
        End Set
    End Property

    Private _absentVoucherID As String = ""
    Public Property AbsentVoucherID() As String
        Get
            Return _absentVoucherID
        End Get
        Set(ByVal Value As String)
            _absentVoucherID = Value
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

    Private _departmentID As String = ""
    Public Property DepartmentID() As String 
        Get
            Return _departmentID
        End Get
        Set(ByVal Value As String )
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public Property TeamID() As String 
        Get
            Return _teamID
        End Get
        Set(ByVal Value As String )
            _teamID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public Property EmployeeID() As String 
        Get
            Return _employeeID
        End Get
        Set(ByVal Value As String )
            _employeeID = Value
        End Set
    End Property

    Private _employeeName As String = ""
    Public Property EmployeeName() As String 
        Get
            Return _employeeName
        End Get
        Set(ByVal Value As String )
            _employeeName = Value
        End Set
    End Property

    Private _sFind As String = ""
    Public Property Find() As String
        Get
            Return _sFind
        End Get
        Set(ByVal Value As String)
            _sFind = Value
        End Set
    End Property

    Private _blockID As String = ""
    Public WriteOnly Property BlockID() As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _empGroupID As String = ""
    Public WriteOnly Property EmpGroupID() As String
        Set(ByVal Value As String)
            _empGroupID = Value
        End Set
    End Property


    Private AbsentTypeDateID(1000) As String 'Kiểu ngày công: cột ẩn; để truyền vào Store D13P2026
    Private xNumberFormat(1000) As String ' cho biết định dạng format số lẻ của cột động
    Private xIsClassification(1000) As Int32 'cho biết cột của grid (động) phải kiểu số k
    Private xCheckMode(1000) As Int32 'cho biết cột của grid load dropdown dạng nào (2 dạng)
    Private xCheckIsValue(1000) As Int32 'dùng để ẩn hiện cột Value của Dropdown
    Private iCountCol As Integer = 0 'Tổng số cột trên lưới (kể cả cột động đc Add vào lưới)
    Dim dtMain As DataTable
    Dim dtAbsentType As DataTable
    Dim nTotalAbsentType As Integer

    Private gbEnabledUseFind As Boolean = False
    Private Sub D13F2026_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        tdbg_LockedColumns()
        LoadDropDownDataTable_Mode0()
        LoadDropDownDataTable_Mode1()
        'Load Split 1 và Split 2 cho lưới
        LoadFixData()
        AddField()
        If nTotalAbsentType > 0 Then
            FillDataOnGrid()
        End If
        bAllowRowColChange = True
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        'Me.Text = rl3("Dieu_chinh_phieu_cham_cong_-_D13F2026") '˜iÒu chÙnh phiÕu chÊm c¤ng - D13F2026
        Me.Text = rl3("Cap_nhat_phieu_dieu_chinh_thu_nhap_-_D13F2026") & UnicodeCaption(gbUnicode)
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        '================================================================ 
        tdbdType.Columns("Type").Caption = rl3("Loai") 'Loại
        tdbdType.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdType.Columns("Value").Caption = rl3("Gia_tri_") 'Giá trị
        '================================================================ 
        tdbg.Columns("IsAdjust").Caption = rl3("Dieu_chinh") 'Điều chỉnh
        tdbg.Columns("IsCheck").Caption = rl3("Da_kiem_tra") 'Đã kiểm tra
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Tên nhân viên
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        'tdbg.Columns("AbsentVoucherNo").Caption = rl3("Phieu_cham_cong") 'Phiếu chấm công
        tdbg.Columns("Remark").Caption = rl3("Phieu_dieu_chinh_thu_nhap") 'Phiếu điều chỉnh thu nhập
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_IsCheck).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_IsCheck).Locked = True
        For i As Integer = COL_DepartmentID To COL_Total
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
        Next
    End Sub

    Dim dtDropDown0, dtDropDown1 As DataTable
    Private Sub LoadDropDownDataTable_Mode0()
        Dim sSQL As String = ""
        sSQL = "Select Code, ClassificationID, Type, Description" & UnicodeJoin(gbUnicode) & " as Description, Value From  D13T0120  WITH (NOLOCK) Where Disabled = 0"
        dtDropDown0 = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadDropDownDataTable_Mode1()
        Dim sSQL As String = ""
        sSQL = "Select Code, T71.ClassificationID, T71.EmployeeID, T71.Type,Description" & UnicodeJoin(gbUnicode) & " as Description, T71.Value" & vbCrLf
        sSQL &= "From D13T1071 T71  WITH (NOLOCK) Inner Join D13T0120 T20  WITH (NOLOCK) On T71.ClassificationID = T20.ClassificationID" & vbCrLf
        sSQL &= "And T71.Type = T20.Type Where Disabled = 0" & vbCrLf
        sSQL &= "Order by T71.ClassificationID, EmployeeID, T71.Type"
        dtDropDown1 = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadFixData()
        Dim sSQL As String
        sSQL = SQLStoreD13P2026("", "0")
        dtMain = ReturnDataTable(sSQL)
    End Sub

    Private Sub AddField()
        Dim sSQL As String = ""
        Dim nWidth As Integer
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim i As Integer = 0

        sSQL = SQLStoreD13P2126()
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
                nWidth = 100
            End If

            'Nếu lưới đã có split 3 động thì remove
            If tdbg.Splits.ColCount >= 3 Then
                tdbg.RemoveHorizontalSplit(2)
            End If

            'Add Split 3
            tdbg.InsertHorizontalSplit(2)

            'Set lai kích cỡ các Split
            tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
            tdbg.Splits(SPLIT0).SplitSize = 150
            tdbg.Splits(SPLIT0).Caption = ""
            tdbg.Splits(SPLIT0).ColumnCaptionHeight = 34

            tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.NumberOfColumns
            tdbg.Splits(SPLIT1).SplitSize = 4
            tdbg.Splits(SPLIT1).Caption = ""
            tdbg.Splits(SPLIT1).ColumnCaptionHeight = 34

            tdbg.Splits(SPLIT2).SplitSize = 5
            tdbg.Splits(SPLIT2).Caption = ""
            tdbg.Splits(SPLIT2).ColumnCaptionHeight = 34
            tdbg.Splits(SPLIT2).RecordSelectors = False
            tdbg.Splits(SPLIT2).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg.Splits(SPLIT2).BorderStyle = Border3DStyle.Flat

            'Ẩn các cột tĩnh trên Split 3
            For j As Integer = 0 To COL_Total
                tdbg.Splits(SPLIT2).DisplayColumns(j).Visible = False
            Next

            iCountCol = COL_Total
            For j As Integer = 0 To dtAbsentType.Rows.Count - 1

                'Lưu giá trị vào mảng để truyền vào Store
                AbsentTypeDateID(j) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString & vbCrLf
                'xNumberFormat(iCountCol) = dtAbsentType.Rows(j).Item("Decimals").ToString

                ' Add các cột:Type1-> Typen, Value1-> Valuen((với n là số dòng của dtAbsentType))
                ' Add cột Type vào table
                dtMain.Columns.Add("Type" & (j + 1).ToString, System.Type.GetType("System.String"))
                ' Add cột Type vào lưới
                dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                dc.DataField = "Type" & (j + 1).ToString ' Cột type
                tdbg.Columns.Add(dc)

                iCountCol += 1

                xNumberFormat(iCountCol) = dtAbsentType.Rows(j).Item("Decimals").ToString

                'Gán Caption, thuộc tính cho cột Type vừa đc Add vào lưới
                tdbg.Columns(dc.DataField).Caption = dtAbsentType.Rows(j).Item("Lookup").ToString & vbCrLf
                tdbg.Splits(SPLIT2).DisplayColumns(dc).Width = nWidth - 18
                tdbg.Splits(SPLIT2).DisplayColumns("Type" & (j + 1).ToString).Visible = True
                tdbg.Splits(SPLIT2).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg.Splits(SPLIT2).DisplayColumns(dc).FetchStyle = True

                tdbg.Splits(SPLIT2).DisplayColumns(dc).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT2).DisplayColumns(dc).HeadingStyle.Font.Style)

                ' Add cột Value vào table
                dtMain.Columns.Add("Value" & (j + 1).ToString, System.Type.GetType("System.String"))
                ' Add cột Value vào lưới
                dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                dc.DataField = "Value" & (j + 1).ToString ' Cột Value
                tdbg.Columns.Add(dc)

                iCountCol += 1

                xNumberFormat(iCountCol) = dtAbsentType.Rows(j).Item("Decimals").ToString

                'Gán Caption, thuộc tính cho cột Value vừa đc Add vào lưới
                tdbg.Splits(SPLIT2).DisplayColumns(dc).Width = nWidth - 18
                tdbg.Splits(SPLIT2).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Visible = True
                tdbg.Splits(SPLIT2).DisplayColumns(dc).FetchStyle = True

                tdbg.Columns("Value" & (j + 1).ToString).NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                'End add cột

                ' Add dropdown vao cot nếu IsClassification = 1, trường hợp cho nhập = cách chọn dropdown
                If dtAbsentType.Rows(j).Item("IsClassification").ToString = "1" Then
                    xIsClassification(iCountCol) = 0
                    xCheckMode(iCountCol) = L3Int(dtAbsentType.Rows(j).Item("Mode").ToString)

                    dc.DataField = "Type" & (j + 1).ToString
                    tdbg.Columns(dc.DataField).DropDown = tdbdType
                    tdbg.Columns(dc.DataField).Tag = dtAbsentType.Rows(j).Item("ClassificationID").ToString
                    tdbdType.Columns("Value").NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                    tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).AutoComplete = True
                    tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).AutoDropDown = True

                    'Nếu IsValue = 1 thì cho hiển thị cột Value
                    If dtAbsentType.Rows(j).Item("IsValue").ToString = "1" Then
                        xCheckIsValue(iCountCol) = 1
                        dc.DataField = "Value" & (j + 1).ToString
                        tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Visible = True
                        tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Locked = True
                        tdbg.Splits(SPLIT2).DisplayColumns("Type" & (j + 1).ToString).HeaderDivider = False
                        tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    Else ' ngược lại IsValue = 0 dấu cột Value đi
                        xCheckIsValue(iCountCol) = 0
                        dc.DataField = "Value" & (j + 1).ToString
                        tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Visible = False
                    End If
                Else

                    'IsClassification = 0 Trường hợp này cho nhập(số)
                    xIsClassification(iCountCol) = 1
                    AbsentTypeDateID(iCountCol) = dtAbsentType.Rows(j).Item("AbsentTypeDateID").ToString

                    dc.DataField = "Type" & (j + 1).ToString
                    tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Visible = False
                    dc.DataField = "Value" & (j + 1).ToString
                    tdbg.Splits(SPLIT2).DisplayColumns(dc.DataField).Locked = False
                    tdbg.Columns(dc.DataField).Caption = dtAbsentType.Rows(j).Item("Lookup").ToString & vbCrLf

                    tdbg.Columns("Value" & (j + 1).ToString).DataWidth = 17
                    tdbg.Columns("Value" & (j + 1).ToString).NumberFormat = InsertFormat(dtAbsentType.Rows(j).Item("Decimals").ToString)
                End If
            Next
        End If

        If nTotalAbsentType > 0 Then
            tdbg.Splits(SPLIT2).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        End If

        ResetColorGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        If nTotalAbsentType > 0 Then ResetFooterGrid(tdbg, 0, 2)

        LoadTDBGrid()
        tdbg_FooterText()
    End Sub

    Private Sub LoadTDBGrid()
        LoadDataSource(tdbg, dtMain, gbUnicode)
    End Sub

    Private Sub FillDataOnGrid()

        Dim j As Integer
        Dim iCol As Integer
        Dim sAbsentTypeDateID As String = ""
        Dim dtCheck As DataTable

        For i As Integer = 0 To nTotalAbsentType - 1
            sAbsentTypeDateID = AbsentTypeDateID(i)
            If sAbsentTypeDateID <> "" And (sAbsentTypeDateID Is Nothing = False) Then
                iCol = COL_Total + 1 + (i * 2)
                dtCheck = ReturnDataTable(SQLStoreD13P2026(sAbsentTypeDateID, "1"))
                For j = 0 To tdbg.RowCount - 1
                    If dtCheck.Rows.Count > 0 Then
                        tdbg(j, iCol) = dtCheck.Rows(j).Item("Type").ToString
                        Dim s As String = dtCheck.Rows(j).Item("NumberOfDayS").ToString
                        If s <> "" Then
                            If Number(s) <> 0 Then
                                tdbg(j, iCol + 1) = SQLNumberD13(Number(s), dtAbsentType.Rows(i).Item("Decimals").ToString)
                            Else
                                tdbg(j, iCol + 1) = ""
                            End If
                        Else
                            tdbg(j, iCol + 1) = ""
                        End If
                    End If
                Next
            End If
        Next
        tdbg.Refresh()
        tdbg_FooterText()
    End Sub

    Private Sub tdbg_FooterText()
        Dim Value As Double = 0
        FooterTotalGrid(tdbg, COL_EmployeeName)

        Dim iFormat As Integer = 0
        Dim dSum As Double = 0
        For col As Integer = COL_Total + 1 To COL_Total + (nTotalAbsentType * 2)
            dSum = 0
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, col).ToString <> "" Or tdbg(i, col + 1).ToString <> "" Then
                    dSum += Number(SQLNumber(tdbg(i, col + 1).ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString)))
                End If
            Next
            tdbg.Columns(col + 1).FooterText = SQLNumber(dSum.ToString, InsertFormat(dtAbsentType.Rows(iFormat).Item("Decimals").ToString))
            col = col + 1
            iFormat = iFormat + 1
        Next
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If e.ColIndex <= COL_Total Then
            Exit Sub
        End If
        Dim i As Integer = e.ColIndex
        If xIsClassification(i) = 1 Then
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

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_IsCheck, COL_IsAdjust
                Exit Sub
        End Select
        If xIsClassification(e.ColIndex) = 0 Then 'Đây là TH nhập liệu từ dropdown
            If tdbg.Columns(tdbg.Col).Text <> tdbdType.Columns("Type").Text Then
                tdbg.Columns(tdbg.Col).Text = ""
                tdbg.Columns(tdbg.Col + 1).Text = ""
            End If
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Dim i As Integer = e.ColIndex
        tdbg.Columns(tdbg.Col).Text = tdbdType.Columns("Type").Value.ToString
        tdbg.Columns(tdbg.Col + 1).Text = SQLNumberD13(Number(tdbdType.Columns("Value").Value), xNumberFormat(i + 1))
        tdbg.Update()
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        For i As Int32 = 0 To iCountCol
            If xIsClassification(i) = 1 Then
                If tdbg.Col = i Then
                    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                End If
            End If
        Next
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    If tdbg.Col > COL_Total Then
                        HeadClickTask()
                    End If
            End Select
        End If

        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            tdbg_FooterText()

        End If
    End Sub

    Private Sub HeadClickTask()
        For i As Integer = 0 To 1
            If tdbg.Splits(i).DisplayColumns(tdbg.Col).Locked = False Then
                If xIsClassification(tdbg.Col) = 1 Then
                    CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
                Else
                    CopyColumns(tdbg, tdbg.Col, tdbg.Row, 2, tdbg.Columns(tdbg.Col).Text)
                End If
                tdbg_FooterText()
                Exit Sub
            End If
        Next i
    End Sub

    Dim bVal As Boolean = False
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        'tdbg.Col = e.ColIndex
        If e.ColIndex = COL_IsAdjust Then
            bVal = Not bVal
            For i As Integer = 0 To tdbg.RowCount - 1
                If Not CBool(tdbg(i, COL_IsCheck)) Then
                    tdbg(i, COL_IsAdjust) = bVal
                End If
            Next
        End If
        If e.ColIndex > COL_Total Then
            HeadClickTask()
        End If
    End Sub

    Dim bAllowRowColChange As Boolean = False
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If bAllowRowColChange = False Then
            Exit Sub
        End If

        If tdbg.Col = e.LastCol Then Exit Sub 'RowColChange chạy 2 lần nên vẫn bị load dư 1 lần

        If tdbg.Columns(tdbg.Col).Tag Is Nothing Then Exit Sub

        If xIsClassification(tdbg.Col) = 0 Then
            If xCheckMode(tdbg.Col + 1) = 0 Then
                If dtDropDown0 Is Nothing = False Then
                    Dim dt As DataTable = ReturnTableFilter(dtDropDown0, "ClassificationID = " & SQLString(tdbg.Columns(tdbg.Col).Tag.ToString()))
                    LoadDataSource(tdbdType, dt, gbUnicode)
                End If
            ElseIf xCheckMode(tdbg.Col + 1) = 1 Then
                If dtDropDown1 Is Nothing = False Then
                    Dim dt As DataTable = ReturnTableFilter(dtDropDown1, "ClassificationID = " & SQLString(tdbg.Columns(tdbg.Col).Tag.ToString()) & " And EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text))
                    LoadDataSource(tdbdType, dt, gbUnicode)
                End If
            End If
        End If
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        If tdbg.Col <= COL_Total Then
            If tdbg.Col = COL_IsAdjust Then
                If L3Bool(tdbg.Columns(COL_IsCheck).Text) Then
                    tdbg.Splits(SPLIT0).DisplayColumns(tdbg.Col).Locked = True
                    e.CellStyle.Locked = True
                Else
                    tdbg.Splits(SPLIT0).DisplayColumns(tdbg.Col).Locked = False
                    e.CellStyle.Locked = False
                End If
            End If
            Exit Sub
        End If
        If xCheckIsValue(tdbg.Col) = 1 Then
            Exit Sub
        End If
        Select Case xIsClassification(tdbg.Col)
            Case 1
                If L3Bool(tdbg.Columns(COL_IsAdjust).Text) And Not L3Bool(IIf(tdbg.Columns(COL_IsCheck).Text = "" Or tdbg.Columns(COL_IsCheck).Text = "0" Or tdbg.Columns(COL_IsCheck).Text = "False", 0, 1).ToString) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                    e.CellStyle.Locked = False
                Else
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                    e.CellStyle.Locked = True
                End If
            Case 0
                If L3Bool(tdbg.Columns(COL_IsAdjust).Text) And Not L3Bool(IIf(tdbg.Columns(COL_IsCheck).Text = "" Or tdbg.Columns(COL_IsCheck).Text = "0" Or tdbg.Columns(COL_IsCheck).Text = "False", 0, 1).ToString) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                    e.CellStyle.Locked = False
                    tdbg.Columns(tdbg.Col).DropDown = tdbdType
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = True
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = True
                Else
                    e.CellStyle.Locked = True
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = False
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = False
                End If
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFalg As Boolean = False

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsAdjust).ToString) Then
                bFalg = True
                Exit For
            End If
        Next

        If Not bFalg Then
            D99C0008.MsgNotYetChoose(rl3("Dieu_chinh"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsAdjust
            tdbg.Bookmark = 0
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub
        'If MessageBox.Show(rl3("Nhan_vien_chon_dieu_chinh_phieu_cham_cong_se_duoc_tinh_lai_luong") & " " & rl3("BAn_ca_muçn_tiOp_toc_kh¤ng"), MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLInsertD13T0103s)

        Dim bRunSQL As Boolean
        Me.Cursor = Cursors.Default

        If sSQL.ToString <> "" Then
            bRunSQL = ExecuteSQL(sSQL.ToString)
            If bRunSQL Then
                SaveOK()

                'Audit Log
                Dim sDesc1 As String = _voucherDate
                Dim sDesc2 As String = _absentVoucherID
                Dim sDesc3 As String = _payrollVoucherID
                Dim sDesc4 As String = _description
                Dim sDesc5 As String = ""
                Lemon3.D91.RunAuditLog("13", AuditCodeTimeSheetRecTrans, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            Else
                SaveNotOK()
                btnClose.Enabled = True
                btnSave.Enabled = True
            End If
        Else
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        End If

        'Tinh luong

        ''Insert vào bảng tạm
        'sSQL = New StringBuilder("")
        'sSQL.Append(SQLDeleteD91T9009().ToString & vbCrLf)
        'sSQL.Append(SQLInsertD91T9009s().ToString & vbCrLf)

        ''Xóa kết quả tính lương cũ
        'sSQL.Append(SQLStoreD13P3501().ToString & vbCrLf)

        ''Tính lại bảng lương
        'sSQL.Append(SQLStoreD13P4500().ToString & vbCrLf)

        ''Chuyển bút toán
        'If _transferMethodID <> "" Then
        '    sSQL.Append(SQLStoreD13P2110().ToString & vbCrLf)
        'End If

        ''Cập nhật lại thông tin thay đổi
        'sSQL.Append(SQLUpdateD13T2600().ToString & vbCrLf)

        ''Xóa bảng tạm
        'sSQL.Append(SQLDeleteD91T9009().ToString & vbCrLf)

        'bRunSQL = ExecuteSQL(sSQL.ToString)
        'If bRunSQL = True Then
        '    'Audit Log
        '    Dim sDesc1 As String = _voucherDate
        '    Dim sDesc2 As String = _absentVoucherID
        '    Dim sDesc3 As String = _payrollVoucherID
        '    Dim sDesc4 As String = _description
        '    Dim sDesc5 As String = ""
        '    RunAuditLog(AuditCodeTimeSheetRecTrans, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
        'End If

    End Sub

    Function GetEmployeeID() As String
        Dim sEmployeeID As String = ""
        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsAdjust)) Then
                bFlag = True
                For j As Integer = 0 To i - 1
                    If CBool(tdbg(i, COL_IsAdjust)) And (tdbg(i, COL_EmployeeID).ToString = tdbg(j, COL_EmployeeID).ToString) Then
                        bFlag = False
                    End If
                Next
                If bFlag Then
                    sEmployeeID &= SQLString(tdbg(i, COL_EmployeeID)) & "','"
                End If
            End If
        Next
        If sEmployeeID <> "" Then
            Return sEmployeeID.Substring(0, sEmployeeID.Length - 3)
        End If
        Return sEmployeeID
    End Function

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
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        '  Dim arrColObligatory() As Integer = {COL_DepartmentID, COL_DepartmentName}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)

    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dtMain, sFind)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 12/05/2009 08:34:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where "
        sSQL &= " HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: DUCTRONG
    '# Created Date: 12/05/2009 08:36:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim bFlag As Boolean = False

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsAdjust)) Then
                bFlag = True
                For j As Integer = 0 To i - 1
                    If CBool(tdbg(i, COL_IsAdjust)) And (tdbg(i, COL_EmployeeID).ToString = tdbg(j, COL_EmployeeID).ToString) Then
                        bFlag = False
                    End If
                Next
                If bFlag Then
                    sSQL.Append("Insert Into D91T9009(")
                    sSQL.Append("UserID, HostID, Key01ID, Key02ID")

                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
                    sSQL.Append(SQLString("D13F2026")) 'Key02ID, varchar[250], NOT NULL
                    sSQL.Append(")")

                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)
                End If
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3501
    '# Created User: DUCTRONG
    '# Created Date: 12/05/2009 08:42:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3501() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3501 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
        Return sSQL
    End Function

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
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
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
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
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
    '# Title: SQLInsertD13T0103s
    '# Created User: DUCTRONG
    '# Created Date: 07/05/2009 08:29:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0103s() As String
        Dim i As Integer
        Dim iCount As Int32 = 0
        Dim bResult As Boolean

        Dim sSQL As String = ""
        Dim iCol As Integer
        Dim k As Integer
        Dim sAbsentTypeID As String = ""

        For i = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsAdjust)) Then

                iCount += 1
                sSQL &= SQLDeleteD13T0103s(i) & vbCrLf
                k = 0

                While k < nTotalAbsentType

                    sAbsentTypeID = AbsentTypeDateID(k)
                    iCol = COL_Total + 1 + k * 2
                    If tdbg(i, iCol).ToString <> "" Or tdbg(i, iCol + 1).ToString <> "" Then
                        If Number(tdbg(i, iCol + 1)) <> 0 Then
                            sSQL &= "Insert Into D13T0103(" & vbCrLf
                            sSQL &= " DivisionID, AbsentVoucherID, EmployeeID, DepartmentID, TeamID, AbsentTypeID," & vbCrLf
                            sSQL &= " PayrollVoucherID, TranMonth, TranYear, NumberOfDays, Type, TransID" & vbCrLf
                            sSQL &= ") Values (" & vbCrLf
                            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_AbsentVoucherID)) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_EmployeeID)) & COMMA 'EmployeeID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_DepartmentID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(tdbg(i, COL_TeamID)) & COMMA 'TeamID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(sAbsentTypeID) & COMMA 'AbsentTypeID [KEY], varchar[20], NOT NULL
                            sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NULL
                            sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
                            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
                            If tdbg(i, iCol + 1).ToString = "" Then
                                sSQL &= SQLMoney(0) & COMMA 'NumberOfDays, decimal, NOT NULL
                            Else
                                sSQL &= SQLMoney(tdbg(i, iCol + 1)) & COMMA 'NumberOfDays, decimal, NOT NULL
                            End If
                            sSQL &= SQLString(tdbg(i, iCol)) & COMMA 'Type, varchar[20], NULL
                            sSQL &= SQLString(tdbg(i, COL_TransID)) 'TransID [KEY], varchar[20], NOT NULL
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
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                End If
            End If
        Next

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103s
    '# Created User: DUCTRONG
    '# Created Date: 07/05/2009 08:25:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0103s(ByVal iRow As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String

        sSQL = ""
        sSQL &= "Delete From D13T0103"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "AbsentVoucherID = " & SQLString(tdbg(iRow, COL_AbsentVoucherID)) & " And "
        sSQL &= "EmployeeID = " & SQLString(tdbg(iRow, COL_EmployeeID)) & " And "
        sSQL &= "DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & " And "
        sSQL &= "TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & " And "
        sSQL &= "PayrollVoucherID = " & SQLString(_payrollVoucherID) & " And "
        sSQL &= "TransID = " & SQLString(tdbg(iRow, COL_TransID))
        sRet &= sSQL & vbCrLf

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2026
    '# Created User: DUCTRONG
    '# Created Date: 11/05/2009 02:24:31
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date:  23/12/2011 01:58:42
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2026(ByVal sAbsentTypeDateID As String, ByVal sMode As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2026 "
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_absentVoucherID) & COMMA 'AsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sAbsentTypeDateID) & COMMA 'AbsentTypeDateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(sMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(_departmentID) & COMMA 'DeparmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_teamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[100], NOT NULL
        sSQL &= "N" & SQLString(_employeeName) & COMMA 'EmployeeName, varchar[100], NOT NULL
        sSQL &= "N" & SQLString(_sFind) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_blockID) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(_empGroupID) 'EmpGroupID, varchar[20], NOT NULL
        Return sSQL
    End Function


    ''' <summary>
    ''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="sValue">Giá trị cần copy</param>
    ''' <param name="RowCopy">Dòng đang copy</param>
    ''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>
    <DebuggerStepThrough()> _
    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If CBool(tdbg(i, COL_IsAdjust)) And Not CBool(IIf(tdbg(i, COL_IsCheck).ToString = "" Or tdbg(i, COL_IsCheck).ToString = "0" Or tdbg(i, COL_IsCheck).ToString = "False", 0, 1)) Then
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then c1Grid(i, ColCopy) = sValue
                    End If
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If CBool(tdbg(i, COL_IsAdjust)) And Not CBool(IIf(tdbg(i, COL_IsCheck).ToString = "" Or tdbg(i, COL_IsCheck).ToString = "0" Or tdbg(i, COL_IsCheck).ToString = "False", 0, 1)) Then
                        c1Grid(i, ColCopy) = sValue
                    End If
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
    <DebuggerStepThrough()> _
    Public Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                c1Grid.UpdateData()
                sValue = c1Grid(RowCopy, ColCopy).ToString

                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()

                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        If CBool(tdbg(i, COL_IsAdjust)) And Not CBool(IIf(tdbg(i, COL_IsCheck).ToString = "" Or tdbg(i, COL_IsCheck).ToString = "0" Or tdbg(i, COL_IsCheck).ToString = "False", 0, 1)) Then
                            j = 1
                            If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                                c1Grid(i, ColCopy) = sValue
                                While j < ColumnCount
                                    c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                    j += 1
                                End While
                            End If
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        If CBool(tdbg(i, COL_IsAdjust)) And Not CBool(IIf(tdbg(i, COL_IsCheck).ToString = "" Or tdbg(i, COL_IsCheck).ToString = "0" Or tdbg(i, COL_IsCheck).ToString = "False", 0, 1)) Then
                            j = 1
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2126
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 21/12/2010 02:03:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2126() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2126 "
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

End Class