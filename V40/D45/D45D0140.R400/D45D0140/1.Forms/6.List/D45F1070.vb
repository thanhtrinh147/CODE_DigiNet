Public Class D45F1070
	Private _formIDPermission As String = "D45F1070"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg"
    Private Const COL_GroupProductID As Integer = 0   ' Mã
    Private Const COL_GroupProductName As Integer = 1 ' Tên
    Private Const COL_GroupProductDesc As Integer = 2 ' Diễn giải
    Private Const COL_Disabled As Integer = 3         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 4     ' CreateUserID
    Private Const COL_CreateDate As Integer = 5       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 6 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 7   ' LastModifyDate
#End Region

    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

#Region "Form"

    Private Sub D45F1070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D15F1070_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        ResetColorGrid(tdbg)

        Loadlanguage()
        LoadTDBGrid()

        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_nhom_san_pham_-_D45F1070") & UnicodeCaption(gbUnicode) 'Danh móc nhâm s¶n phÈm - D45F1070
        '================================================================ 
        tdbg.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("GroupProductDesc").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung")
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = "SELECT GroupProductID, GroupProductName" & UnicodeJoin(gbUnicode) & " as GroupProductName, GroupProductDesc" & UnicodeJoin(gbUnicode) & " as GroupProductDesc, " & vbCrLf
        sSQL &= "Disabled, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate" & vbCrLf
        sSQL &= "From D45T1070 D45  WITH(NOLOCK) Order by D45.GroupProductID"
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("GroupProductID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        End If
        If Not tdbg.Focused Then tdbg.Focus()
    End Sub

#End Region

#Region "tdbg"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        If tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled
                If ChrW(Keys.Space).Equals(e.KeyChar) Then Exit Sub
                e.Handled = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(Nothing, Nothing)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
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
    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()

        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        CheckMyMenu()

    End Sub

    Private Sub CheckMyMenu()
        FooterTotalGrid(tdbg, COL_GroupProductID)
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
    End Sub

#End Region

#Region "Menu"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F1071
        With f
            .GroupProductID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey As String = .GroupProductID
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1071
        f.GroupProductID = tdbg.Columns(COL_GroupProductID).Text
        f.GroupProductName = tdbg.Columns(COL_GroupProductName).Text
        f.GroupProductDesc = tdbg.Columns(COL_GroupProductDesc).Text
        f.Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F1071
        f.GroupProductID = tdbg.Columns(COL_GroupProductID).Text
        f.GroupProductName = tdbg.Columns(COL_GroupProductName).Text
        f.GroupProductDesc = tdbg.Columns(COL_GroupProductDesc).Text
        f.Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey As String = f.GroupProductID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, sKey)
        End If
    End Sub

    Private Function SQLStoreD45P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_GroupProductID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555) Then Exit Sub
        Dim sSQL As String = ""
        sSQL = "Delete D45T1071 Where GroupProductID=" & SQLString(tdbg.Columns(COL_GroupProductID).Text) & vbCrLf
        sSQL &= "Delete D45T1070 Where GroupProductID=" & SQLString(tdbg.Columns(COL_GroupProductID).Text) & vbCrLf
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_GroupProductID)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#End Region

End Class