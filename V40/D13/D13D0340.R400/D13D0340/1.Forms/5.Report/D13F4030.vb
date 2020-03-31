'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:39:52 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:39:52 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F4030

#Region "Const of tdbg"
    Private Const COL_ReportCode As Integer = 0       ' Mã báo cáo
    Private Const COL_ReportName As Integer = 1       ' Tên báo cáo
    Private Const COL_ReportTitle As Integer = 2      ' Tiêu đề báo cáo
    Private Const COL_ReportCatelogy As Integer = 3   ' Dạng báo cáo
    Private Const COL_Disabled As Integer = 4         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 5     ' Người tạo
    Private Const COL_CreateDate As Integer = 6       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 7 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 8   ' Ngày cập nhật cuối cùng
#End Region

    Private dtGrid As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F4030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetColorGrid(tdbg, 0, tdbg.Splits.ColCount - 1)
        LoadTDBGrid()
        SetShortcutPopupMenu(Me, tbrTableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_bao_cao_bang_luong_-_D13F4030") & UnicodeCaption(gbUnicode) 'Danh sÀch bÀo cÀo b¶ng l§¥ng - D13F4030
        '================================================================ 
        tdbg.Columns("ReportCode").Caption = rl3("Ma") 'Mã
        tdbg.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("ReportTitle").Caption = rl3("Tieu_de") 'Tiêu đề
        tdbg.Columns("ReportCatelogy").Caption = rl3("Dang_bao_cao") 'Dạng báo cáo
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_sach_khong_su_dung") 'Hiển thị danh sách không sử dụng
    End Sub
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL &= "Select ReportCode, "
        sSQL &= IIf(gbUnicode, "ReportNameU as ReportName, ReportTitleU as ReportTitle", "ReportName, ReportTitle").ToString
        sSQL &= ", ReportCatelogy, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate From D13T4000 Order By ReportCode "
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("ReportCode = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
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
        '  LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
        ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
        tdbg.WrapCellPointer = tdbg.RowCount > 0
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_ReportCode)
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

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D02V1234 "
        sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        '  ShowFindDialogClient(Finder, sSQL)
        ShowFindDialogClient(Finder, sSQL, Me, gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "C1Context Menu"

    Private Sub tsbInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D13F4031
        With f
            .ReportCode = tdbg.Columns(COL_ReportCode).Text
            .isInherit = True
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .ReportCode)
            .Dispose()
        End With
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D13F4031
        With f
            .ReportCode = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            .Dispose()
            If .bSaved Then LoadTDBGrid(True, .ReportCode)
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If tdbg.RowCount <= 0 Then Exit Sub
        Dim f As New D13F4031
        With f
            .ReportCode = tdbg.Columns(COL_ReportCode).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then LoadTDBGrid(False, .ReportCode)
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        If tdbg.RowCount <= 0 Then Exit Sub
        Dim f As New D13F4031
        With f
            .ReportCode = tdbg.Columns(COL_ReportCode).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T4000 Where ReportCode = " & SQLString(tdbg.Columns(COL_ReportCode).Text)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            DeleteOK()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    ' update 14/3/2013 id 54317
    Private Sub tsmExportDataScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExportDataScript.Click, mnsExportDataScript.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "sFormName", "D13F4030") ' Tài liệu phân tích
        SetProperties(arrPro, "ModuleID", "D13")
        SetProperties(arrPro, "sStr01", tdbg.Columns(COL_ReportCode).Text) ' Tài liệu phân tích
        CallFormShow(Me, "D80D0040", "D80F2095", arrPro)
        '        Dim frm As New D80F2095
        '        frm.FormName = "D13F4030" ' Tài liệu phân tích
        '        frm.ModuleID = "D13"
        '        frm.Str01 = tdbg.Columns(COL_ReportCode).Text ' Tài liệu phân tích
        '        frm.ShowDialog()
        '        frm.Dispose()
    End Sub
#End Region

    

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try

    End Sub

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

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

End Class