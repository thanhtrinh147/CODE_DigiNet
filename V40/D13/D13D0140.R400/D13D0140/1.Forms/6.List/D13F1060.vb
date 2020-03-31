Public Class D13F1060
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_TemplateID As Integer = 0       ' Mã template
    Private Const COL_TemplateName As Integer = 1     ' Tên template
    Private Const COL_DutyName As Integer = 2         ' Chức vụ
    Private Const COL_DateBeginBaseOn As Integer = 3  ' Ngày bắt đầu tính
    Private Const COL_Note As Integer = 4             ' Ghi chú
    Private Const COL_CreateUserID As Integer = 5     ' Người tạo
    Private Const COL_CreateDate As Integer = 6       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 7 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 8   ' Ngày cập nhật cuối cùng
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F1060_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_template_tang_thong_so_luong_-_D13F1060") & UnicodeCaption(gbUnicode) 'Danh móc template tŸng th¤ng sç l§¥ng - D13F1060
        '================================================================ 
        tdbg.Columns("TemplateID").Caption = rl3("Ma") 'Mã 
        tdbg.Columns("TemplateName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("DateBeginBaseOn").Caption = rl3("Ngay_bat_dau_tinh") 'Ngày bắt đầu tính
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub tdbg_FormatText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles tdbg.FormatText
        Select Case tdbg(e.Row, COL_DateBeginBaseOn).ToString.Trim
            Case "ExamineDateEnd"
                e.Value = IIf(gbUnicode, rl3("Ngay_xet_cuoi_cungU"), rl3("Ngay_xet_cuoi_cung")).ToString
            Case "DateJoined"
                e.Value = IIf(gbUnicode, rl3("Ngay_vao"), rl3("Ngay_vaoV")).ToString
            Case "DateRecruited"
                e.Value = IIf(gbUnicode, rl3("Ngay_tuyenU"), rl3("Ngay_tuyen")).ToString
        End Select
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = "" '
        sSQL = "Select TemplateID, TemplateName" & UnicodeJoin(gbUnicode) & " As TemplateName,D0.DutyID, DutyName" & UnicodeJoin(gbUnicode) & " As DutyName, Note, "
        sSQL &= "(Case When DateBeginBaseOn='FixedDate' then convert(varchar(20), DateBegin, 103) "
        sSQL &= " else DateBeginBaseOn end) as DateBeginBaseOn ,"
        sSQL &= " D0.CreateUserID, D0.CreateDate, D0.LastModifyUserID, D0.LastModifyDate "
        sSQL &= "From D13T1060 D0  WITH (NOLOCK) "
        sSQL &= "Left join D09T0211 D1  WITH (NOLOCK) On D1.DutyID=D0.DutyID "
        sSQL &= "Where DivisionID= " & SQLString(gsDivisionID)
        sSQL &= " Order by TemplateID "
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
            Dim dr() As DataRow = dt1.Select("TemplateID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
        End If

        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_TemplateName)
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

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.Tostring = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

#End Region

#Region "Menu bar"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D13F1061()
        With f
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid(True, .TemplateID_D13F1061)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D13F1061()
        With f
            .TemplateID = tdbg.Columns(COL_TemplateID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D13F1061()
        With f
            .TemplateID = tdbg.Columns(COL_TemplateID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid(False, tdbg.Columns(COL_TemplateID).Text)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        Dim sSQL As String = ""
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        sSQL = "Delete From D13T1060 Where TemplateID=" & SQLString(tdbg.Columns(COL_TemplateID).Text)
        bResult = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            'Audit Log
            Dim sDesc1 As String = tdbg.Columns(COL_TemplateID).Text
            Dim sDesc2 As String = tdbg.Columns(COL_TemplateName).Text
            Dim sDesc3 As String = tdbg.Columns(COL_Note).Text
            Dim sDesc4 As String = ""
            Dim sDesc5 As String = ""
            RunAuditLog(AuditCodeSalaryTemplates, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If

    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid"

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
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

#End Region

End Class