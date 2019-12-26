Public Class D45F1040
	Private _formIDPermission As String = "D45F1040"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg"
    Private Const COL_TransTypeID As Integer = 0      ' Mã
    Private Const COL_TransTypeName As Integer = 1    ' Diễn giải
    Private Const COL_DAGroupID As Integer = 2        ' DAGroupID
    Private Const COL_DAGroupName As Integer = 3      ' Nhóm truy cập dữ liệu
    Private Const COL_Disabled As Integer = 4         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 5     ' Người tạo
    Private Const COL_CreateDate As Integer = 6       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 7 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 8   ' Ngày cập nhật cuối cùng
#End Region

    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

#Region "Form"

    Private Sub D45F1040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Me.Text = rl3("Danh_muc_loai_nghiep_vu_-_D45F1040") & UnicodeCaption(gbUnicode) 'Danh móc loÁi nghiÖp vó - D45F1040
        '================================================================ 
        tdbg.Columns("TransTypeID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("TransTypeName").Caption = rl3("Ten") 'Diễn giải
        tdbg.Columns("DAGroupName").Caption = rl3("Nhom_truy_cap_du_lieu") 'Nhóm truy cập dữ liệu
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung")

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = " Select TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, D40.Disabled, D40.DAGroupID, D80.DAGroupName" & UnicodeJoin(gbUnicode) & " as DAGroupName, "
        sSQL &= " D40.CreateUserID, D40.CreateDate, D40.LastModifyUserID, D40.LastModifyDate" & vbCrLf
        sSQL &= " From 	D45T1040 D40 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Left join	LEMONSYS.DBO.D00T0080 D80  WITH(NOLOCK) On D80.DAGroupID = D40.DAGroupID" & vbCrLf
        sSQL &= " Order by	TransTypeID"
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
            Dim dr() As DataRow = dt1.Select("TransTypeID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        End If
        If Not tdbg.Focused Then tdbg.Focus()
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
        FooterTotalGrid(tdbg, COL_TransTypeID)
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
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

#Region "Menu"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F1041
        With f
            .TransTypeID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey As String = .TransTypeID
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1041
        f.TransTypeID = tdbg.Columns(COL_TransTypeID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F1041
        f.TransTypeID = tdbg.Columns(COL_TransTypeID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey As String = f.TransTypeID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, sKey)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        sSQL = " Delete	D45T1040"
        sSQL &= " Where TransTypeID = " & SQLString(tdbg.Columns(COL_TransTypeID).Text)
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'RunAuditLog(AuditCodeTransactionTypes, "03", tdbg.Columns(COL_TransTypeID).Text, tdbg.Columns(COL_TransTypeName).Text, tdbg.Columns(COL_DAGroupID).Text, tdbg.Columns(COL_DAGroupName).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodeTransactionTypes, "03", tdbg.Columns(COL_TransTypeID).Text, tdbg.Columns(COL_TransTypeName).Text, tdbg.Columns(COL_DAGroupID).Text, tdbg.Columns(COL_DAGroupName).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_TransTypeID)
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


    Private Function AllowDelete() As Boolean
        If IsExistKey("D45T2000", "TransTypeID", tdbg.Columns(COL_TransTypeID).Text) Then
            D99C0008.MsgCanNotDelete()
            Return False
        End If
        Return True
    End Function

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#End Region

End Class