'#---------------------------------------------------------------------------------------------------
'# Created User: ?
'# Created Date: ?
'# Modified User: Hoàng Nguyên 
'# Modified Date:04/08/2011 01:13:01 
'# Description: Chuyển Unicode
'#---------------------------------------------------------------------------------------------------

Public Class D13F5557
	Dim dtCaptionCols As DataTable

    Private dtGrid As DataTable

#Region "Const of tdbg"
    Private Const COL_VoucherID As Integer = 0          ' VoucherID
    Private Const COL_VoucherNo As Integer = 1          ' Số phiếu
    Private Const COL_VoucherDate As Integer = 2        ' Ngày phiếu
    Private Const COL_Description As Integer = 3        ' Diễn giải
    Private Const COL_PayrollVoucherName As Integer = 4 ' Hồ sơ lương
    Private Const COL_LockedUserID As Integer = 5       ' Người khóa/ mở phiếu
    Private Const COL_LockedDate As Integer = 6         ' Ngày khóa/ mở phiếu
    Private Const COL_Locked As Integer = 7             ' Khóa
    Private Const COL_IsUpdate As Integer = 8           ' IsUpdate
#End Region

    Private Sub D13F5557_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnClose)
    End Sub

    Private Sub D13F5557_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Dim iPerF5557 As Integer
        iPerF5557 = ReturnPermission("D13F5557")

        chkLockedVouchers.Enabled = iPerF5557 <> 2
        btnSave.Enabled = iPerF5557 >= 2

        SetBackColorObligatory()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL_LockedDate)
        gbEnabledUseFind = False
        LoadTDBCombo()
        LoadTDBGrid(True)
        LoadLanguage()
        ResetColorGrid(tdbg, 0, 1)
        SetShortcutPopupMenu(ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bAddNew As Boolean = False)
        Dim sSQL As String = SQLStoreD13P5557()
        If bAddNew Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTransactionTypeID
        sSQL = "SELECT		ID AS TransactionTypeID, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " AS TransactionTypeName" & vbCrLf
        sSQL &= "FROM		D13N5555 ('D13F5557', 'TransactionTypeID', '', '', '')"
        LoadDataSource(tdbcTransactionTypeID, sSQL, gbUnicode)
        tdbcTransactionTypeID.SelectedIndex = 0
    End Sub

#Region "Events tdbcTransactionTypeID"

    Private Sub tdbcTransactionTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransactionTypeID.LostFocus
        If tdbcTransactionTypeID.FindStringExact(tdbcTransactionTypeID.Text) = -1 Then tdbcTransactionTypeID.Text = ""
        LoadTDBGrid(True)
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionTypeID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionTypeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Khoa_phieuF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Khâa phiÕu
        '================================================================ 
        lblTransactionTypeID.Text = rl3("Nghiep_vu") 'Nghiệp vụ
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkLockedVouchers.Text = rl3("Phieu_da_khoa") 'Phiếu đã khóa
        '================================================================ 
        tdbcTransactionTypeID.Columns("TransactionTypeID").Caption = rl3("Ma") 'Mã
        tdbcTransactionTypeID.Columns("TransactionTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_VoucherNo).Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_VoucherDate).Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns(COL_Description).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_PayrollVoucherName).Caption = rl3("Ho_so_luong") 'Hồ sơ lương
        tdbg.Columns(COL_LockedUserID).Caption = rl3("Nguoi_khoa_mo_phieu") 'Người khóa/ mở phiếu
        tdbg.Columns(COL_LockedDate).Caption = rl3("Ngay_khoa_mo_phieu") 'Ngày khóa/ mở phiếu
        tdbg.Columns(COL_Locked).Caption = rl3("Khoa") 'Khóa
    End Sub



#Region "Active Find - List All (Client-Server)"
    'Dim dtCaptionCols As DataTable

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
		Set(ByVal Value As String)
            sFindServer = Value
            ReLoadTDBGrid()
		End Set
	End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT3, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        sFindServer = ResultWhereClauseServer.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ContextMenuStrip1, tdbg.RowCount, gbEnabledUseFind)
        FooterTotalGrid(tdbg, COL_VoucherNo)
    End Sub
#End Region

    Private Sub chkLockedVouchers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLockedVouchers.Click
        LoadTDBGrid(True)
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_Locked
                tdbg.Columns(COL_IsUpdate).Text = "1"
        End Select
    End Sub

    Dim bSelected As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Locked
                L3HeadClick(tdbg, COL_Locked, bSelected)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Locked 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String
        sSQL = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s(dr).ToString & vbCrLf
        sSQL &= SQLStoreD13P5558()

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)

        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
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

    Private Sub SetBackColorObligatory()
        tdbcTransactionTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        If tdbcTransactionTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose("Nghiệp vụ")
            tdbcTransactionTypeID.Focus()
            Return False
        End If

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        If chkLockedVouchers.Checked Then
            dr = dtGrid.Select("Locked=0")
            If dr.Length <= 0 Then
                D99C0008.MsgL3(rl3("MSG000049"))
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_Locked
                tdbg.Row = 0
                Return False
            End If
        Else
            dr = dtGrid.Select("Locked=1")
            If dr.Length <= 0 Then
                D99C0008.MsgL3(rl3("MSG000048"))
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_Locked
                tdbg.Row = 0
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 30/07/2013 04:38:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang D09T6666" & vbCrlf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D13F5557'"

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Hoàng Nhân
    '# Created Date: 30/07/2013 04:40:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang D09T6666" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID ")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F5557") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("VoucherID")) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("VoucherNo"))) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5557
    '# Created User: Hoàng Nhân
    '# Created Date: 31/07/2013 11:31:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5557() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load du lieu cho form D13F5557 - Khoa phieu" & vbCrlf)
        sSQL &= "Exec D13P5557 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransactionTypeID).ToString) & COMMA 'TransactionTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkLockedVouchers.Checked) & COMMA 'Locked, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5558
    '# Created User: Hoàng Nhân
    '# Created Date: 31/07/2013 11:33:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5558() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu du lieu tai man hinh khoa phieu D13F5557" & vbCrlf)
        sSQL &= "Exec D13P5558 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransactionTypeID).ToString) & COMMA 'TransactionTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(Not chkLockedVouchers.Checked) & COMMA 'Locked, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function



End Class