Public Class D45F2052
    Private _DepartmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _DepartmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _dtD45F2052 As DataTable = Nothing
    Public Property dtD45F2052 As DataTable
        Get
            Return _dtD45F2052
        End Get
        Set(ByVal Value As DataTable)
            _dtD45F2052 = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 9"
    Private Const COL_IsUsed As String = "IsUsed"                 ' Chọn
    Private Const COL_EmployeeID As String = "EmployeeID"         ' Mã NV
    Private Const COL_EmployeeName As String = "EmployeeName"     ' Họ và tên
    Private Const COL_DepartmentID As String = "DepartmentID"     ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName" ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                 ' Tổ nhóm
    Private Const COL_TeamName As String = "TeamName"             ' Tên tổ nhóm
    Private Const COL_DutyID As String = "DutyID"                 ' Chức vụ
    Private Const COL_DutyName As String = "DutyName"             ' Tên chức vụ
#End Region

    Private dtGrid As DataTable
    Private Sub D45F2052_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If dtGrid IsNot Nothing Then dtGrid.Dispose()
    End Sub
    Private Sub D45F2052_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        SetBackColorObligatory()
        LoadLanguage()
        LoadTDBCombo()
        tdbg_LockedColumns()
        CheckIdTextBox(txtEmployeeID)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub D45F2052_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Chon_nhan_vienF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn nh¡n vi£n
        '================================================================ 
        lblEmployeeID.Text = rL3("Ma_NV") 'Mã NV
        lblEmployeeName.Text = rL3("Ten_NV") 'Tên NV
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        btnChoose.Text = rL3("Chon") 'Chọn
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_DutyID).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_DutyName).Caption = rL3("Ten_chuc_vu") 'Tên chức vụ
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Dim dtTeamID As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcTeamID
        'sSQL = "--Do nguon To nhom" & vbCrLf
        'sSQL &= "SELECT '%' As TeamID, " & AllName & " As TeamName, '%' As DivisionID, '%' As BlockID, '%' As DepartmentID, 0 As TeamDisplayOrder, 0 As DisplayOrder" & vbCrLf
        'sSQL &= "UNION" & vbCrLf
        'sSQL &= "SELECT D01.TeamID, D01.TeamNameU as TeamName, D02.DivisionID, D02.BlockID, D01.DepartmentID, TeamDisplayOrder, 1 As DisplayOrder" & vbCrLf
        'sSQL &= "FROM D09T0227 D01 WITH(NOLOCK) INNER JOIN 	D91T0012 D02 WITH(NOLOCK) On D02.DepartmentID = D01.DepartmentID" & vbCrLf
        'sSQL &= "WHERE D01.Disabled = 0 And D02.DivisionID =" & SQLString(gsDivisionID) & " AND D01.TeamID <> " & SQLString(_teamID) & vbCrLf
        'sSQL &= "ORDER BY DisplayOrder,TeamDisplayOrder, TeamName"
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2050", 0) 'ReturnDataTable(sSQL)

        'Load tdbcDepartmentID
        'sSQL = "--Do nguon Phong ban" & vbCrLf
        'sSQL &= "SELECT '%' As DepartmentID, " & AllName & " As DepartmentName, '%' As DivisionID, '%' As BlockID, 0 as DepDisplayOrder, 0 as DisplayOrder" & vbCrLf
        'sSQL &= "UNION" & vbCrLf
        'sSQL &= "SELECT D01.DepartmentID, DepartmentNameU As DepartmentName, D01.DivisionID,BlockID, DepDisplayOrder, 1 as DisplayOrder" & vbCrLf
        'sSQL &= "FROM D91T0012 D01 WITH(NOLOCK)" & vbCrLf
        'sSQL &= "WHERE D01.Disabled = 0  And D01.DivisionID =" & SQLString(gsDivisionID) & " AND D01. DepartmentID  <>  " & SQLString(_DepartmentID) & vbCrLf
        'sSQL &= "ORDER BY DisplayOrder, DepDisplayOrder, DepartmentName"
        Dim dt As DataTable = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2050", 0)
        LoadDataSource(tdbcDepartmentID, dt, gbUnicode)
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
    Private Sub LoadTDBCTeamID(sDepartmentID As String)
        Dim dt As DataTable
        If sDepartmentID = "%" Then
            dt = dtTeamID.DefaultView.ToTable
        Else
            dt = ReturnTableFilter(dtTeamID, "DepartmentID =" & SQLString(sDepartmentID) & " Or TeamID ='%'", True)
        End If
        LoadDataSource(tdbcTeamID, dt, gbUnicode)
        tdbcTeamID.SelectedValue = "%"
    End Sub

#Region "Events tdbcDepartmentID load tdbcTeamID"
    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.SelectedValue Is Nothing OrElse tdbcDepartmentID.Text = "" Then
            LoadTDBCTeamID("-1")
            Exit Sub
        End If
        LoadTDBCTeamID(ReturnValueC1Combo(tdbcDepartmentID))
    End Sub
    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)

        Dim sSQL As String = SQLStoreD45P2055()
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
            dtGrid = dt.DefaultView.ToTable
        Else
            dtGrid.DefaultView.RowFilter = COL_IsUsed & " = True"
            dtGrid = dtGrid.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns(COL_EmployeeID)}
                dtGrid.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub
    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If strFind <> "" Then strFind = COL_IsUsed & "=True" & " Or " & strFind

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
    End Sub
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = IndexOfColumn(tdbg, COL_IsUsed) Then HotKeyEnterGrid(tdbg, IndexOfColumn(tdbg, COL_IsUsed), e)
        End If
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_IsUsed)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub
#End Region

    Dim bSelect As Boolean = False
    Private Sub HeadClick(iCol As Integer)
        Select Case tdbg.Columns(iCol).DataField
            Case COL_IsUsed
                L3HeadClick(tdbg, IndexOfColumn(tdbg, COL_IsUsed), bSelect)
        End Select
    End Sub
    Private Function AllowFilter() As Boolean
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDepartmentID.Text)
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTeamID.Text)
            tdbcTeamID.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        dr = dtGrid.Select(COL_IsUsed & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = IndexOfColumn(tdbg, COL_IsUsed)
            tdbg.Row = 0
            Return False
        End If
        Return True
    End Function
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnChoose.Focus()
        If btnChoose.Focused = False Then Exit Sub
        '************************************
        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s(dr).ToString & vbCrLf)
        sSQL.Append(SQLStoreD45P2056.ToString)
        _dtD45F2052 = ReturnDataTable(sSQL.ToString)
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2055
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 05:07:18
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2055() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrLf)
        sSQL &= "Exec D45P2055 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2050") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtEmployeeName.Text, gbUnicode, True) & COMMA 'EmployeeName, nvarchar[250], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 05:08:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 15/03/2016 05:09:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert du lieu vao bang tam" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_EmployeeID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2056
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/03/2016 11:19:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2056() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Thuc thi tra ra du lieu nhan vien duoc chon" & vbCrLf)
        sSQL &= "Exec D45P2056 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2050") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(_DepartmentID) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(_teamID) 'TeamID, varchar[50], NOT NULL
        Return sSQL
    End Function


End Class