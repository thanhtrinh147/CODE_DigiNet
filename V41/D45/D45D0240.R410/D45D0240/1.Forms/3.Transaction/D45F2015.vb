Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 12/05/2010 08:06:51 AM
'# Created User: Đặng Vũ Minh Quang
'# Modify Date: 12/05/2010 08:06:51 AM
'# Modify User: Đặng Vũ Minh Quang
'#-------------------------------------------------------------------------------------
Public Class D45F2015
	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F2015"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid As DataTable
    'Khai báo biến đổ nguồn combo theo D09 - G4
    Private dtDepartmentID, dtTeamID As DataTable
    Dim sF6 As String

    Dim sFilter, sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

    '#Region "Const of tdbg"
    '    Private Const COL_EmployeeID As Integer = 0           ' Mã nhân viên
    '    Private Const COL_FullName As Integer = 1             ' Tên nhân viên
    '    Private Const COL_BlockID As Integer = 2              ' Khối
    '    Private Const COL_BlockName As Integer = 3            ' Tên khối
    '    Private Const COL_DepartmentID As Integer = 4         ' Phòng ban
    '    Private Const COL_DepartmentName As Integer = 5       ' Tên phòng ban
    '    Private Const COL_TeamID As Integer = 6               ' Tổ nhóm
    '    Private Const COL_TeamName As Integer = 7             ' Tên tổ nhóm
    '    Private Const COL_SumHACoefficient As Integer = 8     ' Tổng GCHS (PB/TN)
    '    Private Const COL_MasterApportionUP As Integer = 9    ' Đơn giá GCHS (PB/TN)
    '    Private Const COL_MasterApportionCoef As Integer = 10 ' Tổng GCHS
    '    Private Const COL_Total As Integer = 11              ' Lương sản phẩm
    '#End Region

#Region "Const of tdbg"
    Private Const COL_EmployeeID As Integer = 0           ' Mã nhân viên
    Private Const COL_FullName As Integer = 1             ' Tên nhân viên
    Private Const COL_BlockID As Integer = 2              ' Khối
    Private Const COL_BlockName As Integer = 3            ' Tên khối
    Private Const COL_DepartmentID As Integer = 4         ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5       ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6               ' Tổ nhóm
    Private Const COL_TeamName As Integer = 7             ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8           ' Mã nhóm NV
    Private Const COL_EmpGroupName As Integer = 9         ' Tên nhóm NV
    Private Const COL_SumHACoefficient As Integer = 10    ' Tổng GCHS (PB/TN)
    Private Const COL_MasterApportionUP As Integer = 11   ' Đơn giá GCHS (PB/TN)
    Private Const COL_MasterApportionCoef As Integer = 12 ' Tổng GCHS
    Private Const COL_Total As Integer = 13             ' Lương sản phẩm
#End Region




#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Private _pSalaryVoucherID As String
    Public WriteOnly Property PSalaryVoucherID() As String
        Set(ByVal Value As String)
            _pSalaryVoucherID = Value
        End Set
    End Property

    Private _pieceworkCalMethodID As String
    Public WriteOnly Property pieceworkCalMethodID() As String
        Set(ByVal Value As String)
            _pieceworkCalMethodID = Value
        End Set
    End Property

    Private Sub D09F2250_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
                Exit Sub
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
                Exit Sub
        End Select
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk(rl3("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Private Sub D09F2250_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        ResetColorGrid(tdbg, SPLIT0, SPLIT1)
        gbEnabledUseFind = False
        LoadTDBCombo()
        LoadDefault()
        tdbg_NumberFormat()
        AddField()
        LoadTDBGrid
        '******************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtEmployeeID)
        '******************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        CallD09U1111_Button(True)
        '******************************
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        'Mac dinh %
        tdbcBlockID.SelectedValue = "%"
        If D45Systems.IsUseBlock Then
            UnReadOnlyControl(tdbcBlockID)
        Else
            ReadOnlyControl(tdbcBlockID)
        End If

        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
        '******************************
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Luong_san_pham_theo_don_gia_gio_cong_he_so_-_D45F2015") & UnicodeCaption(gbUnicode) 'L§¥ng s¶n phÈm theo ¢¥n giÀ gié c¤ng hÖ sç - D45F2015
        '================================================================ 
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rl3("Ma_NV") 'Mã NV
        lblFullName.Text = rl3("Ten_NV") 'Tên NV
        '================================================================ 
        btnFilter.Text = rl3("Loc") & Space(1) & "(F5)" 'Lọc
        btnF12.Text = "F12 (" & rl3("Hien_thi") & ")"
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        'Bổ sung cột - 50254
        tdbg.Columns("EmpGroupID").Caption = rl3("Ma_nhom_NV") 'Mã nhóm NV
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Tên nhóm NV

        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns("SumHACoefficient").Caption = rl3("Tong_GCHS_(PBTN)") 'Tổng GCHS (PB/TN)
        tdbg.Columns("MasterApportionUP").Caption = rl3("Don_gia_GCHS_(PBTN)") 'Đơn giá GCHS (PB/TN)
        tdbg.Columns("MasterApportionCoef").Caption = rl3("Tong_GCHS") 'Tổng GCHS
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_SumHACoefficient).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_MasterApportionUP).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_MasterApportionCoef).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

#Region "Load tdbCombo"

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
    End Sub
#End Region

#Region "LoadTDBGrid"

    'Add 90 cot luong
    Private Sub AddField()
        Dim sSQL As String
        'Tim xem co su dung khoan thu nhap nao khong?
        sSQL = SQLStoreD45P1061()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dr() As DataRow = dt.Select("Disabled =1")
        If dr.Length > 0 Then 'Có sử dụng khỏan thu nhập
            Try
                Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn

                'cac cot phuong phap tinh luong     
                For i As Integer = 0 To dt.Rows.Count - 1
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "Amount" & Format(i + 1, "00")
                    dc.NumberFormat = InsertFormat(dt.Rows(i).Item("Decimals").ToString) 'IncidentID	52134 'DxxFormat.DefaultNumber2
                    tdbg.Columns.Add(dc)
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.Font = FontUnicode(gbUnicode)
                    '****************************
                    tdbg.Columns(dc.DataField).Caption = dt.Rows(i).Item("ShortName").ToString
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = L3Bool(dt.Rows(i).Item("Disabled"))
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            '********************************
            tdbg.Splits(1).DisplayColumns(COL_SumHACoefficient).Visible() = False
            tdbg.Splits(1).DisplayColumns(COL_MasterApportionUP).Visible() = False
        Else
            tdbg.RemoveHorizontalSplit(1)
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter, sFilterServer)
            sFind = ""
        End If

        sSQL = SQLStoreD45P2015()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("PSalaryVoucherID =" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterSumNew(tdbg, COL_SumHACoefficient, COL_MasterApportionUP, COL_MasterApportionCoef)
        FooterSumAmount()
        FooterTotalGrid(tdbg, COL_FullName)
    End Sub

    Public Sub FooterSumAmount()
        Dim dblSum As Double

        For j As Integer = COL_Total To tdbg.Columns.Count - 1
            dblSum = 0

            For i As Integer = 0 To tdbg.RowCount - 1
                dblSum += Number(tdbg(i, j))
            Next i

            If Not tdbg.Columns(j).NumberFormat Is Nothing Then
                tdbg.Columns(j).FooterText = Format(dblSum, tdbg.Columns(j).NumberFormat)
            End If
        Next j
    End Sub
#End Region

#Region "Events tdbCombo - G4 Standard"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 OrElse tdbcBlockID.Text = "" Then
            tdbcBlockID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub


    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 OrElse tdbcDepartmentID.Text = "" Then
            tdbcDepartmentID.Text = ""
            tdbcDepartmentID.SelectedValue = "%"
        End If
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

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter, sFilterServer)
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

#Region "Events tdbg"

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter, sFilterServer)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_SumHACoefficient, COL_MasterApportionUP, COL_MasterApportionCoef
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Total To tdbg.Columns.Count - 1
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub
#End Region

#Region "Menu"

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        'Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
	CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        'ResetTableForExcel(tdbg, gdtCaptionExcel)
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

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
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
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter, sFilterServer)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
#End Region

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        If bLoadFirst = True Then
            Dim arrColObligatory() As Integer = {}
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, arrMaster, arrColObligatory, , , gbUnicode)
            Next
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2015
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 01/11/2011 08:32:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2015() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2015 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_pSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtFullName.Text) & COMMA 'FullName, varchar[250], NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1061
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/01/2012 11:21:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1061() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1061 "
        sSQL &= SQLString(_pieceworkCalMethodID) & COMMA 'PieceworkCalMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


End Class