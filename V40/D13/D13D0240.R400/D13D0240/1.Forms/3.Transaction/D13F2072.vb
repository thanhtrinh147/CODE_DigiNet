Imports System
Public Class D13F2072
	Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_EmployeeID As Integer = 0           ' Mã NV
    Private Const COL_EmployeeName As Integer = 1         ' Tên nhân viên
    Private Const COL_BlockID As Integer = 2              ' Khối
    Private Const COL_BlockName As Integer = 3            ' Tên khối
    Private Const COL_DepartmentID As Integer = 4         ' Phòng ban
    Private Const COL_DepartmentName As Integer = 5       ' Tên phòng ban
    Private Const COL_TeamID As Integer = 6               ' Tổ nhóm
    Private Const COL_TeamName As Integer = 7             ' Tên tổ nhóm
    Private Const COL_EmpGroupID As Integer = 8           ' Nhóm NV
    Private Const COL_EmpGroupName As Integer = 9         ' Tên nhóm NV
    Private Const COL_DutyID As Integer = 10              ' Chức vụ
    Private Const COL_DutyName As Integer = 11            ' Tên chức vụ
    Private Const COL_WorkID As Integer = 12              ' Công việc
    Private Const COL_WorkName As Integer = 13            ' Tên công việc
    Private Const COL_Birthdate As Integer = 14           ' Ngày sinh
    Private Const COL_SexName As Integer = 15             ' Giới tính
    Private Const COL_DateJoined As Integer = 16          ' Ngày vào làm
    Private Const COL_DateLeft As Integer = 17            ' Ngày nghỉ việc
    Private Const COL_Age As Integer = 18                 ' Tuổi
    Private Const COL_StatusID As Integer = 19            ' Trạng thái làm việc
    Private Const COL_StatusName As Integer = 20          ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As Integer = 21    ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As Integer = 22       ' Mã NV phụ
    Private Const COL_IncomeTaxCode As Integer = 23       ' Mã số thuế
    Private Const COL_GeneralIncomeAmount As Integer = 24 ' Tổng thu nhập chịu thuế
    Private Const COL_TaxableIncomeAmount As Integer = 25 ' Thu nhập tính thuế
    Private Const COL_TempPITAmount As Integer = 26       ' Thu nhập tạm khấu trừ
    Private Const COL_NumPersonAmount As Integer = 27     ' Số người phụ thuộc
#End Region

    Private _pITVoucherID As String = ""
    Public Property PITVoucherID() As String
        Get
            Return _pITVoucherID
        End Get
        Set(ByVal Value As String)
            _pITVoucherID = Value
        End Set
    End Property

#Region "Chuẩn hóa D09U1111 B1: đinh nghĩa biến"
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim dtFind As DataTable

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_khai_thue_thu_nhap_ca_nhan_-_D13F2072") & UnicodeCaption(gbUnicode) 'Chi tiÕt khai thuÕ thu nhËp cÀ nh¡n - D13F2072
        '================================================================ 
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        'Chuẩn hóa D09U1111 B5: Tại hàm LoadLanguage: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkDeductionLabor.Text = rl3("Lao_dong_thuoc_dien_khau_tru_thue") 'Lao động thuộc diện khấu trừ thuế
        chkNonDeductionLabor.Text = rl3("Lao_dong_khong_thuoc_dien_khau_tru_thue") 'Lao động không thuộc diện khấu trừ thuế
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Tên nhân viên
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("IncomeTaxCode").Caption = rl3("Ma_so_thue") 'Mã số thuế
        tdbg.Columns("GeneralIncomeAmount").Caption = rl3("Tong_thu_nhap_chiu_thue") 'Tổng thu nhập chịu thuế
        tdbg.Columns("TaxableIncomeAmount").Caption = rl3("Thu_nhap_tinh_thue") 'Thu nhập tính thuế
        tdbg.Columns("TempPITAmount").Caption = rl3("Thu_nhap_tam_khau_tru") 'Thu nhập tạm khấu trừ
        tdbg.Columns("NumPersonAmount").Caption = rl3("So_nguoi_phu_thuoc") 'Số người phụ thuộc
        ' update 15/11/2012 id 51174
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_NV") 'Mã nhân viên
        tdbg.Columns("EmpGroupName").Caption = rl3("Ten_nhom_NV") 'Họ và tên
        tdbg.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
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
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuPrint.Text = rl3("_In") '&In
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_GeneralIncomeAmount).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_TaxableIncomeAmount).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_TempPITAmount).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_NumPersonAmount).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub D13F2072_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select

        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
    End Sub

    Private Sub D13F2072_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, 1)
        SetShortcutPopupMenu(Me.C1CommandHolder)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)

        Dim sSQL As String = "Select IsUseBlock From D09T0000  WITH (NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = CBool(dt.Rows(0).Item(0))
            tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = CBool(dt.Rows(0).Item(0))
            tdbcBlockID.Enabled = CBool(dt.Rows(0).Item(0))
            'txtBlockName.Enabled = CBool(dt.Rows(0).Item(0))
        End If

        chkDeductionLabor.Checked = True
        LoadTDBCombo()
        tdbcBlockID.SelectedValue = "%"
        tdbg_NumberFormat()
        ' update 16/11/2012 id 51174
        CallD09U1111(True)
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft)

        SetResolutionForm(Me, C1ContextMenu)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
    End Sub

#Region "Events tdbcBlockID with txtBlockName"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Or tdbcBlockID.Text = "" Then
            LoadTdbcDepartmentID("-1")
        Else
            LoadTdbcDepartmentID(ComboValue(tdbcBlockID))
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events TdbcDepartmentID"

    Private Sub LoadTdbcDepartmentID(ByVal sBlockID As String)
        If sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, dtDepartmentID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID = '%' Or BlockID = " & SQLString(sBlockID)), gbUnicode)
        End If

    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1", "-1")

            Exit Sub
        End If
        LoadtdbcTeamID(ComboValue(tdbcBlockID), tdbcDepartmentID.SelectedValue.ToString)
        tdbcTeamID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcTeamID with txtTeamName"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If tdbcTeamID.SelectedValue Is Nothing Then
            Exit Sub
        End If
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
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SumFooter()
        Dim dblGeneralIncomeAmount As Double = 0
        Dim dblTaxableIncomeAmount As Double = 0
        Dim dblTempPitAmount As Double = 0
        Dim dblNumPersonAmount As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dblGeneralIncomeAmount += Number(tdbg(i, COL_GeneralIncomeAmount))
            dblTaxableIncomeAmount += Number(tdbg(i, COL_TaxableIncomeAmount))
            dblTempPitAmount += Number(tdbg(i, COL_TempPITAmount))
            dblNumPersonAmount += Number(tdbg(i, COL_NumPersonAmount))
        Next i

        tdbg.Columns(COL_GeneralIncomeAmount).FooterText = Format(dblGeneralIncomeAmount, D13Format.DefaultNumber2)
        tdbg.Columns(COL_TaxableIncomeAmount).FooterText = Format(dblTaxableIncomeAmount, D13Format.DefaultNumber2)
        tdbg.Columns(COL_TempPITAmount).FooterText = Format(dblTempPitAmount, D13Format.DefaultNumber2)
        tdbg.Columns(COL_NumPersonAmount).FooterText = Format(dblNumPersonAmount, D13Format.DefaultNumber2)
    End Sub

    Private Sub LoadTdbg()
        dtFind = ReturnDataTable(SQLStoreD13P4060)
        gbEnabledUseFind = dtFind.Rows.Count > 0
        LoadDataSource(tdbg, dtFind, gbUnicode)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        FooterTotalGrid(tdbg, COL_EmployeeName)
        SumFooter()
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4060
    '# Created User: Bùi Thị Thanh Huyền
    '# Created Date: 13/08/2009 03:14:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4060() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4060 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcBlockID.SelectedValue) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.SelectedValue) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.SelectedValue) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_pITVoucherID) & COMMA 'PITVoucherID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now.Date) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(chkDeductionLabor.Checked) & COMMA 'DeductionLabor, tinyint, NOT NULL
        sSQL &= SQLNumber(chkNonDeductionLabor.Checked) & COMMA 'NonDeductionLabor, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTdbg()
    End Sub

    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        'Lưới không có nút Hiển thị
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        'If dtCaptionCols Is Nothing orelse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_EmployeeID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        CallShowD99F2222(Me, dtCaptionCols, dtFind, gsGroupColumns)
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PITVoucherID", _pITVoucherID)
        SetProperties(arrPro, "BlockID", ComboValue(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ComboValue(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ComboValue(tdbcTeamID))
        SetProperties(arrPro, "DeductionLabor", chkDeductionLabor.Checked)
        SetProperties(arrPro, "NonDeductionLabor", chkNonDeductionLabor.Checked)
        SetProperties(arrPro, "WhereClause", sFindServer)
        CallFormShow(Me, "D13D0340", "D13F4060", arrPro)

        '        Dim f As New D13M0340
        '        With f
        '            .FormActive = enumD13E0340Form.D13F4060
        '            .ID01 = _pITVoucherID 'PITVoucherID
        '            .ID02 = ComboValue(tdbcBlockID) 'BlockID
        '            .ID03 = ComboValue(tdbcDepartmentID) 'DepartmentID
        '            .ID04 = ComboValue(tdbcTeamID) 'TeamID
        '            .ID05 = CType(chkDeductionLabor.Checked, String) 'DeductionLabor
        '            .ID06 = CType(chkNonDeductionLabor.Checked, String) 'NonDeductionLabor
        '            .ID07 = sFindServer 'WhereClause
        '            .ShowDialog()
        '            .Dispose()
        '        End With
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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String 
        Set(ByVal Value As String )
            sFindServer = Value
            ReLoadTDBGrid()
        End Set
    End Property
    'Dim dtCaptionCols As DataTable

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '  If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ' End If
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '        If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClauseClient.ToString()
    '        sFindServer = ResultWhereClauseServer.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
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
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        FooterTotalGrid(tdbg, COL_EmployeeName)
        SumFooter()
    End Sub
#End Region

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub


#Region "Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True"
    Private Sub CallD09U1111(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_EmployeeID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            '-----------------------------------
        End If
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub Call_D09U1111Refresh()
        'Chuẩn hóa D09U1111 B6: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
        'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
        If usrOption IsNot Nothing Then
            usrOption.MarkInvisibleColumn(SPLIT1)
            usrOption.D09U1111Refresh()
        End If
    End Sub
#End Region
    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl 
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtFind Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Age, COL_GeneralIncomeAmount, COL_TaxableIncomeAmount, COL_TempPITAmount, COL_NumPersonAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub



End Class