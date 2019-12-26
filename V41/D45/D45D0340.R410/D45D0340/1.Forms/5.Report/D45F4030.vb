Public Class D45F4030
	Private _formIDPermission As String = "D45F4030"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid As DataTable
    Dim sFind As String = ""
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

#Region "Const of tdbg"
    Private Const COL_ReportCode As Integer = 0       ' Mã báo cáo
    Private Const COL_ReportName As Integer = 1       ' Tên báo cáo
    Private Const COL_ReportTitle As Integer = 2      ' Tiêu đề báo cáo
    Private Const COL_ReportID As Integer = 3         ' Dạng báo cáo
    Private Const COL_Disabled As Integer = 4         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 5     ' CreateUserID
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 7 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 8   ' LastModifyDate
#End Region

    Private Sub D15F1100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        ResetColorGrid(tdbg)
        LoadLanguage()
        LoadTDBGrid()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_bao_cao_bang_luong_san_pham_-_D45F4030") & UnicodeCaption(gbUnicode) 'Danh sÀch bÀo cÀo b¶ng l§¥ng s¶n phÈm - D45F4030
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_sach_khong_su_dung") 'Hiển thị danh sách không sử dụng
        '================================================================ 
        tdbg.Columns("ReportCode").Caption = rl3("Ma") 'Mã
        tdbg.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("ReportTitle").Caption = rl3("Tieu_de_bao_cao") 'Tiêu đề báo cáo
        tdbg.Columns("ReportID").Caption = rl3("Dang_bao_cao") 'Dạng báo cáo
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD    
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = "Select D45.ReportCode, D45.ReportName" & UnicodeJoin(gbUnicode) & " as ReportName, D45.ReportTitle" & UnicodeJoin(gbUnicode) & " as ReportTitle, D45.ReportID, D45.Disabled, "
        sSQL &= "CreateDate, CreateUserID, LastModifyDate, LastModifyUserID" & vbCrLf
        sSQL &= "From D45T4030 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order by ReportCode"
        dtGrid = ReturnDataTable(sSQL)

        'Cách mới theo chuẩn: menu Tìm kiếm và Liệt kê tất cả luôn luôn sáng khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select("ReportCode=" & SQLString(sKey), dtGrid.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

#Region "tdbg"
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub

        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_ReportName)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F4031
        With f
            .ReportCode = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .ReportCode)
            .Dispose()
        End With

    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F4031
        With f
            .ReportCode = tdbg.Columns(COL_ReportCode).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With
        If f.bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_ReportCode).Text)
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F4031
        With f
            .ReportCode = tdbg.Columns(COL_ReportCode).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL = "Delete From D45T4030 Where ReportCode = " & SQLString(tdbg.Columns(COL_ReportCode).Text)
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            DeleteOK()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub
End Class