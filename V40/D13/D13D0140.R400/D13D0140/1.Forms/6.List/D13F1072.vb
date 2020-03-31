Imports System.Text
'#-------------------------------------------------------------------------------------
'# Created Date: 16/10/2007 02:46:14
'# Created User: Nguyễn Lê Phương
'# Modify Date: 22/01/2008 11:22:43 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F1072
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_DepartmentID As Integer = 0   ' Phòng ban
    Private Const COL_TeamID As Integer = 1         ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 2     ' Mã NV
    Private Const COL_FullName As Integer = 3       ' Tên NV
    Private Const COL_Value As Integer = 4          ' Giá trị
    Private Const COL_DepartmentName As Integer = 5 ' DepartmentName
    Private Const COL_TeamName As Integer = 6       ' TeamName
    Private Const COL_RefEmployeeID As Integer = 7  ' RefEmployeeID
#End Region

    Dim iLastCol As Integer
    Dim dtFind As DataTable


    Private _ClassificationID As String = ""
    Public Property ClassificationID() As String
        Get
            Return _ClassificationID
        End Get
        Set(ByVal value As String)
            _ClassificationID = value
        End Set
    End Property

    Private _Type As String = ""
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    Private _Description As String = ""
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_FullName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Value).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub D13F1072_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKeys_Click(sender, Nothing)
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D13F1072_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        ResetColorGrid(tdbg, 0, 0)
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        UnicodeGridDataField(tdbg, COL_FullName, gbUnicode)
        LoadMaster()
        LoadTDBGrid()
        If (ReturnPermission("D13F1070") - 2 >= 0) And tdbg.RowCount > 0 Then
            btnSave.Enabled = True
        ElseIf (ReturnPermission("D13F1070") < 2) Then
            btnSave.Enabled = False
        End If
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)
        SetResolutionForm(Me, Me.C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_nhan_vien_-_D13F1072") & UnicodeCaption(gbUnicode) 'Chi tiÕt nh¡n vi£n - D13F1072
        '================================================================ 
        lblType.Text = rl3("Ma") 'Mã
        '================================================================ 
        btnHotKeys.Text = rl3("Phim_nong") 'Phím nóng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và Tên
        tdbg.Columns("Value").Caption = rl3("Gia_tri_") 'Giá trị
    End Sub

    Private Sub LoadMaster()
        txtType.Text = _Type
        txtDescription.Text = _Description
    End Sub

    'Thêm trường RefEmployeeID 22/01/08
    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "SELECT * FROM (" & vbCrLf
        sSQL &= "SELECT	T01.DivisionID, T01.DepartmentID, T12.DepartmentName,T01.TeamID, T27.TeamName," & vbCrLf
        sSQL &= "T01.EmployeeID,ISNULL(T01.LastName,'') + ' ' + ISNULL(T01.MiddleName,'') + ' ' + ISNULL(T01.FirstName,'' ) AS FullName, ISNULL(T01.LastNameU,'') + ' ' + ISNULL(T01.MiddleNameU,'') + ' ' + ISNULL(T01.FirstNameU,'' ) AS FullNameU," & vbCrLf
        sSQL &= "T01.DutyID, T11.DutyName,T71.Value, RefEmployeeID" & vbCrLf
        sSQL &= "FROM D09T0201 T01  WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN	D91T0012 T12  WITH (NOLOCK) ON	T12.DepartmentID = T01.DepartmentID " & vbCrLf
        sSQL &= "LEFT JOIN	D09T0227 T27  WITH (NOLOCK) ON	T27.DepartmentID = T01.DepartmentID " & vbCrLf
        sSQL &= "AND T27.TeamID = T01.TeamID" & vbCrLf
        sSQL &= "LEFT JOIN	D09T0211 T11  WITH (NOLOCK) ON	T11.DutyID = T01.DutyID" & vbCrLf
        sSQL &= "LEFT JOIN	D13T1071 T71  WITH (NOLOCK) ON	T71.ClassificationID = " & SQLString(_ClassificationID) & vbCrLf
        sSQL &= "AND T71.Type = " & SQLString(_Type) & vbCrLf
        sSQL &= "AND T71.EmployeeID = T01.EmployeeID" & vbCrLf
        sSQL &= "WHERE T01.DivisionID = " & SQLString(gsDivisionID) & " AND T01.Disabled = 0" & vbCrLf
        sSQL &= ")AS GridView " & vbCrLf
        sSQL &= "ORDER BY DepartmentID,TeamID, EmployeeID"
        dtFind = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtFind, gbUnicode)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        ' If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD13T1071.ToString & vbCrLf)
        sSQL.Append(SQLInsertD13T1071s.ToString & vbCrLf)

        Dim bRunSQL As Boolean
        If sSQL.ToString <> "" Then bRunSQL = ExecuteSQL(sSQL.ToString)

        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1071
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/10/2007 02:45:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1071() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1071"
        sSQL &= " Where "
        sSQL &= "ClassificationID = " & SQLString(_ClassificationID) & " And "
        sSQL &= "Type = " & SQLString(_Type)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1071s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/10/2007 02:46:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1071s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim iCount As Integer = 0
        For i As Integer = 0 To tdbg.RowCount - 1
            If Not IsDBNull(tdbg(i, COL_Value)) Then
                sSQL.Append("Insert Into D13T1071(")
                sSQL.Append("ClassificationID, EmployeeID, Type, Value")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_ClassificationID) & COMMA) 'ClassificationID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(_Type) & COMMA) 'Type [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Value))) 'Value, decimal, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)

                iCount += 1
                If iCount = 100 Then
                    ExecuteSQL(sRet.ToString)
                    iCount = 0
                    sRet.Remove(0, sRet.Length)
                End If
            End If

        Next
        Return sRet
    End Function

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_DepartmentID
                e.CellTip = tdbg.Columns(COL_DepartmentName).Text
            Case COL_TeamID
                e.CellTip = tdbg.Columns(COL_TeamName).Text
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_DepartmentID, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_DepartmentID, 0)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Value
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHotKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKeys.Click
        Dim f As New D13F7777
        With f
            .CallShowForm(Me.Name)
            .ShowDialog()
        End With
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
    'Dim dtCaptionCols As DataTable
    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_DepartmentID, COL_DepartmentName}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, SQLNumber("0"))
        'End If
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.Tostring = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dtFind, sFind)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
    End Sub
#End Region

End Class