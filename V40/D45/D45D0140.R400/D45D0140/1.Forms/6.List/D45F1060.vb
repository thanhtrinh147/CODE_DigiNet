Public Class D45F1060
	Private _formIDPermission As String = "D45F1060"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

#Region "Const of tdbg"
    Private Const COL_PieceworkCalMethodID As Integer = 0 ' Mã
    Private Const COL_Description As Integer = 1          ' Diễn giải
    Private Const COL_IsHACoefUP As Integer = 2           ' Theo ĐG GCHS
    Private Const COL_Disabled As Integer = 3             ' KSD
    Private Const COL_CreateUserID As Integer = 4         ' CreateUserID
    Private Const COL_CreateDate As Integer = 5           ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 6     ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 7       ' LastModifyDate
#End Region

#Region "Form"

    Private Sub D45F1060_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D15F1100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.Text = rl3("Danh_muc_phuong_phap_tinh_luong_san_pham_-_D45F1060") & UnicodeCaption(gbUnicode) 'Danh móc ph§¥ng phÀp tÛnh l§¥ng s¶n phÈm - D45F1060
        '================================================================ 
        tdbg.Columns("PieceworkCalMethodID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("IsHACoefUP").Caption = rl3("Theo_don_gia_GCHS") 'Theo đơn giá GCHS
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung")
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = "SELECT PieceworkCalMethodID, Description" & UnicodeJoin(gbUnicode) & " as Description, IsHACoefUP, Disabled, "
        sSQL &= "CreateUserID, LastModifyUserID, CreateDate, LastModifyDate" & vbCrLf
        sSQL &= "From D45T1060 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order by PieceworkCalMethodID"
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
            Dim dr() As DataRow = dt1.Select("PieceworkCalMethodID = " & SQLString(sKey), dt1.DefaultView.Sort)
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
        FooterTotalGrid(tdbg, COL_PieceworkCalMethodID)
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
            Case COL_Disabled, COL_IsHACoefUP
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
        Dim f As New D45F1061
        With f
            .PieceworkCalMethodID = ""
            .Description = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey As String = .PieceworkCalMethodID
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D45F1061
        f.PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
        f.Description = ""
        f.Disabled = False
        f.FormState = EnumFormState.FormAdd
        f.ShowDialog()
        Dim sKey As String = f.PieceworkCalMethodID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(True, sKey)
        End If
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1061
        f.PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
        f.Description = tdbg.Columns(COL_Description).Text
        f.Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
        f.IsHACoefUP = L3Bool(tdbg.Columns(COL_IsHACoefUP).Text)
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim sSQL As String
        Dim bReadOnly As Boolean = False
        sSQL = "Select Top 1 1 From D45T2010 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.PieceworkCalMethodID= " & SQLString(tdbg.Columns(COL_PieceworkCalMethodID).Text)
        sSQL &= " And D45.Calculated=1"
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Phuong_phap_nay_da_duoc_su_dung") & Space(1) & rl3("Ban_khong_duoc_phep_sua_cac_thong_so_thiet_lap"))
            bReadOnly = True
        End If

        Dim f As New D45F1061
        f.bReadOnly = bReadOnly
        f.PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
        f.Description = tdbg.Columns(COL_Description).Text
        f.Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
        f.IsHACoefUP = L3Bool(tdbg.Columns(COL_IsHACoefUP).Text)
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey As String = f.PieceworkCalMethodID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, sKey)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String
        sSQL = "Select PieceworkCalMethodID From D45T2010  WITH(NOLOCK) Where PieceworkCalMethodID=" & SQLString(tdbg.Columns(COL_PieceworkCalMethodID).Text)
        If ExistRecord(sSQL) Then
            D99C0008.MsgCanNotDelete()
            Exit Sub
        End If
        sSQL = "Delete D45T1061 Where PieceworkCalMethodID = " & SQLString(tdbg.Columns(COL_PieceworkCalMethodID).Text) & vbCrLf
        sSQL &= "Delete D45T1060 Where PieceworkCalMethodID = " & SQLString(tdbg.Columns(COL_PieceworkCalMethodID).Text) & vbCrLf
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'RunAuditLog(AuditCodePieceworkCalMethodID, "03", gsDivisionID, tdbg.Columns(COL_PieceworkCalMethodID).Text, tdbg.Columns(COL_Description).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodePieceworkCalMethodID, "03", gsDivisionID, tdbg.Columns(COL_PieceworkCalMethodID).Text, tdbg.Columns(COL_Description).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_PieceworkCalMethodID)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsmExportDataScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExportDataScript.Click, mnsExportDataScript.Click
        'Dim frm As New D80F2095
        'frm.FormName = Me.Name ' Tài liệu phân tích
        'frm.ModuleID = "45"
        'frm.Str01 = tdbg.Columns(COL_PieceworkCalMethodID).Text ' Tài liệu phân tích
        'frm.ShowDialog()
        'frm.Dispose()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "sFormName", Me.Name) ' Tài liệu phân tích
        SetProperties(arrPro, "ModuleID", D45)
        SetProperties(arrPro, "sStr01", tdbg.Columns(COL_PieceworkCalMethodID).Text) ' Tài liệu phân tích       
        CallFormShow("D80D0040", "D80F2095", arrPro)
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