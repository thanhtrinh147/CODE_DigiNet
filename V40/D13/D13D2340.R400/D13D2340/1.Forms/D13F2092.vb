Imports System
Public Class D13F2092
	Dim dtCaptionCols As DataTable
	'Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_BackPayTransID As Integer = 0     ' BackPayTransID
    Private Const COL_TransID As Integer = 1            ' TransID
    Private Const COL_SalAdjTransID As Integer = 2      ' SalAdjTransID
    Private Const COL_EmployeeID As Integer = 3         ' Mã NV
    Private Const COL_EmployeeName As Integer = 4       ' Tên NV
    Private Const COL_CalNo As Integer = 5              ' CalNo
    Private Const COL_CalNoName As Integer = 6          ' Khoản thu nhập
    Private Const COL_Period As Integer = 7             ' Kỳ
    Private Const COL_TranMonth As Integer = 8          ' TranMonth
    Private Const COL_TranYear As Integer = 9           ' TranYear
    Private Const COL_SalaryVoucherID As Integer = 10   ' SalaryVoucherID
    Private Const COL_SalaryVoucherNo As Integer = 11   ' SalaryVoucherNo
    Private Const COL_SalaryVoucherName As Integer = 12 ' Phiếu lương
    Private Const COL_OldValue As Integer = 13          ' Mức cũ
    Private Const COL_NewValue As Integer = 14          ' Mức mới
    Private Const COL_BackPayAmount As Integer = 15     ' Kết quả hồi tố
    Private Const COL_IsBackPay As Integer = 16         ' IsBackPay
    Private Const COL_Description As Integer = 17       ' Diễn giải
#End Region

    Private dtGrid As DataTable

    Private _bFromD13F2091 As Boolean = False
    Public WriteOnly Property bFromD13F2091() As Boolean
        Set(ByVal Value As Boolean )
            _bFromD13F2091 = Value
        End Set
    End Property

    Private _sFormatDecimal As String = "N3"
    Public WriteOnly Property sFormatDecimal() As String 
        Set(ByVal Value As String )
            _sFormatDecimal = Value
        End Set
    End Property

    Private Sub D13F2092_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtStrEmployeeID)

        gbEnabledUseFind = False
        tdbg_NumberFormat()
        LoadLanguage()

        ' tdbg_SumbyGroup()
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        ResetColorGrid(tdbg)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13F2092_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Ket_qua_hoi_to_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'KÕt qu¶ häi tç l§¥ng
        '================================================================ 
        lblStrEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblStrEmployeeName.Text = rl3("Ten_nhan_vien") 'Tên nhân viên
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_cac_khoan_thu_nhap_co_hoi_to_luong") 'Chỉ hiển thị các khoản thu nhập có hồi tố lương
        '================================================================ 
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ten_NV") 'Tên NV
        tdbg.Columns(COL_CalNoName).Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns(COL_Period).Caption = rl3("Ky") 'Kỳ
        tdbg.Columns(COL_SalaryVoucherNo).Caption = rl3("Phieu_luong") 'Phiếu lương
        tdbg.Columns(COL_SalaryVoucherName).Caption = rl3("Phieu_luong") 'Phiếu lương
        tdbg.Columns(COL_OldValue).Caption = rl3("Muc_cu") 'Mức cũ
        tdbg.Columns(COL_NewValue).Caption = rl3("Muc_moi") 'Mức mới
        tdbg.Columns(COL_BackPayAmount).Caption = rl3("Ket_qua_hoi_to") 'Kết quả hồi tố
        tdbg.Columns(COL_Description).Caption = rl3("Dien_giai") 'Kết quả hồi tố
    End Sub


    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub chkIsUsed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD13P2092()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        CreateGroup()
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If chkIsUsed.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "IsBackPay = 1"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_Period)
        FooterSumNew(tdbg, COL_OldValue, COL_NewValue, COL_BackPayAmount)
    End Sub

    Private Sub CreateGroup()
        'Mã NV (EmployeeID) -> Khoản thu nhập (CalNo) -> Kỳ (Period) -> Phiếu lương (SalaryVoucherID)
        If tdbg.GroupedColumns.Count <= 0 Then
            tdbg.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal
            tdbg.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy

            tdbg.GroupByAreaVisible = False
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn = tdbg.Columns(COL_EmployeeID)
            tdbg.Columns(dc.DataField).GroupInfo.OutlineMode = C1.Win.C1TrueDBGrid.OutlineModeEnum.StartExpanded
            tdbg.GroupedColumns.Add(dc)

            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc = tdbg.Columns(COL_CalNo)
            tdbg.GroupedColumns.Add(dc)
            tdbg.Columns(dc.DataField).GroupInfo.OutlineMode = C1.Win.C1TrueDBGrid.OutlineModeEnum.StartExpanded

            dc = New C1.Win.C1TrueDBGrid.C1DataColumn
            dc = tdbg.Columns(COL_Period)
            tdbg.GroupedColumns.Add(dc)
            '  tdbg.GroupedColumns(2).GroupInfo.ColumnVisible = True
            tdbg.Columns(dc.DataField).GroupInfo.OutlineMode = C1.Win.C1TrueDBGrid.OutlineModeEnum.StartExpanded
        End If
        dtGrid.DefaultView.Sort = "EmployeeID, CalNo, Period"
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OldValue).NumberFormat = _sFormatDecimal
        tdbg.Columns(COL_NewValue).NumberFormat = _sFormatDecimal
        tdbg.Columns(COL_BackPayAmount).NumberFormat = _sFormatDecimal
    End Sub


#Region "tdbg events"

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False


    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_GroupText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.GroupTextEventArgs) Handles tdbg.GroupText
        Dim str As String = ""
        Select Case e.Col.DataColumn.DataField
            Case tdbg.Columns(COL_EmployeeID).DataField
                str = rl3("Ma_NV") & " - " & rl3("Ten_NV")
                If gbUnicode Then
                    e.Text = str & ": " & e.GroupText & " - " & tdbg(e.StartRowIndex, COL_EmployeeName).ToString
                Else
                    e.Text = str & ": " & e.GroupText & " - " & ConvertVniToUnicode(tdbg(e.StartRowIndex, COL_EmployeeName).ToString)
                End If
            Case tdbg.Columns(COL_CalNo).DataField
                str = rl3("Khoan_thu_nhap")
                If gbUnicode Then
                    e.Text = str & ": " & tdbg(e.StartRowIndex, COL_CalNoName).ToString
                Else
                    e.Text = str & ": " & ConvertVniToUnicode(tdbg(e.StartRowIndex, COL_CalNoName).ToString)
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OldValue, COL_NewValue 'Chặn chỉ nhập Số  
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
            Case COL_Period
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789/")
        End Select
    End Sub


#End Region

#Region "Active Find - List All (Client)"
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

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2092
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 04:30:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2092() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Lod luoi" & vbCrlf)
        sSQL &= "Exec D13P2092 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DisvisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(txtStrEmployeeID.Text) & COMMA 'StrEmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtStrEmployeeName, gbUnicode) & COMMA 'StrEmployeeName, nvarchar[500], NOT NULL
        '-- 0 : gọi từ nơi khác ; 1: gọi từ D13F2091
        sSQL &= SQLString(_bFromD13F2091) & COMMA 'BackPayTransID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D13F2090") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function
 



End Class