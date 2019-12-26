Public Class D45F2045

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _dtGridD45F2045 As DataTable = Nothing
    Public Property dtGridD45F2045 As DataTable
        Get
            Return _dtGridD45F2045
        End Get
        Set(ByVal Value As DataTable)
            _dtGridD45F2045 = Value
        End Set
    End Property
    

#Region "Const of tdbg - Total of Columns: 13"
    Private Const COL_IsCheck As String = "IsCheck"                   ' Chọn
    Private Const COL_GroupProductID As String = "GroupProductID"     ' Mã nhóm SP
    Private Const COL_GroupProductName As String = "GroupProductName" ' Nhóm sản phẩm
    Private Const COL_ComponentID As String = "ComponentID"           ' Mã nhóm tiểu tác
    Private Const COL_ComponentName As String = "ComponentName"       ' Nhóm tiểu tác
    Private Const COL_TaskID As String = "TaskID"                     ' Mã cụm tiểu tác
    Private Const COL_TaskName As String = "TaskName"                 ' Cụm tiểu tác
    Private Const COL_PartProductID As String = "PartProductID"       ' Mã tiểu tác
    Private Const COL_PartProductName As String = "PartProductName"   ' Tiểu tác
    Private Const COL_WorkerLevelID As String = "WorkerLevelID"       ' Bậc thợ
    Private Const COL_PriceListID As String = "PriceListID"         ' Bảng giá
    Private Const COL_PPUnitPrice As String = "PPUnitPrice"           ' Đơn giá
    Private Const COL_PPNorm As String = "PPNorm"                     ' Định mức
#End Region

    Private Sub D45F2045_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select

    End Sub

    Private Sub D26F2070_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        gbEnabledUseFind = False
        LoadTDBCombo()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Chon_tieu_tac") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn tiÓu tÀc
        '================================================================ 
        lblTaskID.Text = rl3("Cum_tieu_tac") 'Cụm tiểu tác
        lblComponentID.Text = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        lblGroupProductID.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnChoose.Text = rl3("Chon") 'Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcTaskID.Columns("TaskID").Caption = rl3("Ma") 'Mã
        tdbcTaskID.Columns("TaskName").Caption = rl3("Ten") 'Tên
        tdbcComponentID.Columns("ComponentID").Caption = rl3("Ma") 'Mã
        tdbcComponentID.Columns("ComponentName").Caption = rl3("Ten") 'Tên
        tdbcGroupProductID.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsCheck).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_GroupProductID).Caption = rl3("Ma_nhom_SP") 'Mã nhóm SP
        tdbg.Columns(COL_GroupProductName).Caption = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        tdbg.Columns(COL_ComponentID).Caption = rl3("Ma_nhom_tieu_tac") 'Mã nhóm tiểu tác
        tdbg.Columns(COL_ComponentName).Caption = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        tdbg.Columns(COL_TaskID).Caption = rl3("Ma_cum_tieu_tac") 'Mã cụm tiểu tác
        tdbg.Columns(COL_TaskName).Caption = rl3("Cum_tieu_tac") 'Cụm tiểu tác
        tdbg.Columns(COL_PartProductID).Caption = rl3("Ma_tieu_tac") 'Mã tiểu tác
        tdbg.Columns(COL_PartProductName).Caption = rl3("Tieu_tac") 'Tiểu tác
        tdbg.Columns(COL_WorkerLevelID).Caption = rl3("Bac_tho") 'Bậc thợ
        tdbg.Columns(COL_PriceListID).Caption = rl3("Bang_gia") 'Bảng giá
        tdbg.Columns(COL_PPUnitPrice).Caption = rl3("Don_gia") 'Đơn giá
        tdbg.Columns(COL_PPNorm).Caption = rl3("Dinh_muc") 'Định mức
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcGroupProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcComponentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTaskID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcGroupProductID
        sSQL = "---- Do nguon combo nhom san pham " & vbCrLf
        sSQL &= "	SELECT  		'%' AS GroupProductID, " & AllName & " AS  GroupProductName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "	UNION " & vbCrLf
        sSQL &= "	SELECT 		GroupProductID, GroupProductNameU as GroupProductName, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "	FROM 		D45T1070 WITH(NOLOCK)" & vbCrLf
        sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
        sSQL &= "	ORDER BY DisplayOrder, GroupProductName" & vbCrLf
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)
        tdbcGroupProductID.SelectedValue = "%"
    End Sub

    Dim dtComponentID As DataTable = Nothing
    Private Sub LoadTDBCComponentID(sGroupProductID As String)
        Dim sSQL As String = ""
        'Load tdbcComponentID

        If dtComponentID Is Nothing Then
            sSQL = "-- Combo nhom tieu tac" & vbCrLf
            sSQL &= "	SELECT  		'%' AS ComponentID, " & AllName & " AS  ComponentName, '%' As GroupProductID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT 		ComponentID, ComponentNameU as ComponentName, GroupProductID, 1 AS DisplayOrder" & vbCrLf
            sSQL &= "	FROM 		D45T1090 WITH(NOLOCK)" & vbCrLf
            sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
            sSQL &= "	ORDER BY 	DisplayOrder, ComponentName" & vbCrLf
            dtComponentID = ReturnDataTable(sSQL)
        End If
        '**************************
        LoadDataSource(tdbcComponentID, ReturnTableFilter(dtComponentID, "ComponentID ='%' OR GroupProductID =" & SQLString(sGroupProductID), True), gbUnicode)
        tdbcComponentID.SelectedValue = "%"
    End Sub

    Dim dtTaskID As DataTable = Nothing
    Private Sub LoadTDBCTaskID(sComponentID As String)
        If dtTaskID Is Nothing Then
            Dim sSQL As String = ""
            'Load tdbcTaskID
            sSQL = "-- Combo cum tieu tac" & vbCrLf
            sSQL &= "	SELECT  		'%' AS TaskID, " & AllName & " AS  TaskName, '' As ComponentID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT 		TaskID, TaskNameU as TaskName, ComponentID, 1 AS DisplayOrder" & vbCrLf
            sSQL &= "	FROM 		D45T1100 WITH(NOLOCK)" & vbCrLf
            sSQL &= "	WHERE 		Disabled = 0" & vbCrLf
            sSQL &= "	ORDER BY	DisplayOrder, TaskName " & vbCrLf
            dtTaskID = ReturnDataTable(sSQL)
        End If
        LoadDataSource(tdbcTaskID, ReturnTableFilter(dtTaskID, "TaskID ='%' OR ComponentID =" & SQLString(sComponentID), True), gbUnicode)
        tdbcTaskID.SelectedValue = "%"
    End Sub

#Region "Events tdbcGroupProductID"
    Private Sub tdbcGroupProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.LostFocus
        If tdbcGroupProductID.FindStringExact(tdbcGroupProductID.Text) = -1 Then tdbcGroupProductID.Text = ""
    End Sub
    Private Sub tdbcGroupProductID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcGroupProductID.SelectedValueChanged
        LoadTDBCComponentID(ReturnValueC1Combo(tdbcGroupProductID))
    End Sub
#End Region

#Region "Events tdbcComponentID"
    Private Sub tdbcComponentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcComponentID.LostFocus
        If tdbcComponentID.FindStringExact(tdbcComponentID.Text) = -1 Then tdbcComponentID.Text = ""
    End Sub

    Private Sub tdbcComponentID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcComponentID.SelectedValueChanged
        LoadTDBCTaskID(ReturnValueC1Combo(tdbcComponentID))
    End Sub
#End Region

#Region "Events tdbcTaskID"
    Private Sub tdbcTaskID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTaskID.LostFocus
        If tdbcTaskID.FindStringExact(tdbcTaskID.Text) = -1 Then tdbcTaskID.Text = ""
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Close, tdbcComponentID.Close, tdbcTaskID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Validated, tdbcComponentID.Validated, tdbcTaskID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private Function AllowFilter() As Boolean
        If tdbcGroupProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblGroupProductID.Text)
            tdbcGroupProductID.Focus()
            Return False
        End If
        If tdbcComponentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblComponentID.Text)
            tdbcComponentID.Focus()
            Return False
        End If
        If tdbcTaskID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTaskID.Text)
            tdbcTaskID.Focus()
            Return False
        End If
        Return True
    End Function

    Private dtGrid As DataTable
    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)  ' Thêm mới thì gán sFind ="" và gán FilterText =""
        '************************
        Dim sSQL As String = SQLStoreD45P2045()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = COL_IsCheck & " = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns(COL_PartProductID)}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If

        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If chkIsUsed.Checked Then
            strFind = COL_IsCheck & "=1"
        Else
            strFind = ""
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString
            If strFind <> "" Then strFind = "(" & strFind & ") Or " & COL_IsCheck & "=1"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_GroupProductID)
    End Sub
    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim dr() As DataRow = dtGrid.Select(COL_IsCheck & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = IndexOfColumn(tdbg, COL_IsCheck)
            tdbg.Row = 0
            Return False
        End If
        Return True
    End Function
    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        chkIsUsed.Checked = False
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        btnChoose.Focus()
        If btnChoose.Focused = False Then Exit Sub
        If AllowSave() = False Then Exit Sub
        '**********************
        _bSaved = True
        dtGrid.DefaultView.RowFilter = COL_IsCheck & " = True"
        _dtGridD45F2045 = dtGrid.DefaultView.ToTable
        Me.Close()
    End Sub

#Region "tdbg"
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
        If tdbg.FilterActive Then HotKeyCtrlVOnGrid(tdbg, e) : Exit Sub
        If e.Control AndAlso e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.Column.DataColumn.DataField
            Case COL_IsCheck
                tdbg.UpdateData()
                ResetGrid()
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case COL_IsCheck
                L3HeadClick(tdbg, iCol, bSelect)
        End Select
    End Sub
    Private Sub tdbgD_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_IsCheck)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2045
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 23/02/2017 09:03:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2045() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D45P2045 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2040") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupProductID)) & COMMA 'GroupProductID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcComponentID)) & COMMA 'ComponentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTaskID)) 'TaskID, varchar[50], NOT NULL
        Return sSQL
    End Function


    
End Class