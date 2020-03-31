Public Class D13F1090

#Region "Const of tdbg"
    Private Const COL_PAnaCategoryID As Integer = 0    ' Mã loại phân tích
    Private Const COL_PAnaCategoryName As Integer = 1  ' Diễn giải
    Private Const COL_PAnaCategoryShort As Integer = 2 ' Tên tắt
    Private Const COL_CreateUserID As Integer = 3      ' CreateUserID
    Private Const COL_CreateDate As Integer = 4        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 5  ' LastModifyUserID
    Private Const COL_LastModifydate As Integer = 6    ' LastModifydate
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F1090_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        Loadlanguage()
        LoadTDBGrid()
        ResetColorGrid(tdbg)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_ma_phan_tich_tien_luong_-_D13F1090") & UnicodeCaption(gbUnicode) 'Danh móc mº ph¡n tÛch tiÒn l§¥ng - D13F1090
        '================================================================ 
        tdbg.Columns("PAnaCategoryID").Caption = rl3("Ma_loai_phan_tich") 'Mã loại phân tích
        tdbg.Columns("PAnaCategoryName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("PAnaCategoryShort").Caption = rl3("Ten_tat") 'Tên tắt
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL &= "Select PAnaCategoryID, " & IIf(gsLanguage = "84", "PAnaCategoryName84", "PAnaCategoryName01").ToString() & UnicodeJoin(gbUnicode) & " As PAnaCategoryName, " & vbCrLf
        sSQL &= " PAnaCategoryShort" & UnicodeJoin(gbUnicode) & " As PAnaCategoryShort, CreateUserID, CreateDate," & vbCrLf
        sSQL &= " LastModifyUserID, LastModifydate" & vbCrLf
        sSQL &= " From D13T0050 WITH (NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0" & vbCrLf
        sSQL &= " ORDER BY PAnaCategoryID"
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind

        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_PAnaCategoryName)
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

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        If tdbg.RowCount <= 0 Then Exit Sub
        Dim f As New D13F1091
        With f
            .PAnaCategoryID = tdbg.Columns(COL_PAnaCategoryID).Text
            .PAnaCategoryName01 = tdbg.Columns(COL_PAnaCategoryName).Text
            .PAnaCategoryName84 = tdbg.Columns(COL_PAnaCategoryName).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If tdbg.RowCount <= 0 Then Exit Sub

        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        Dim f As New D13F1091
        With f
            .PAnaCategoryID = tdbg.Columns(COL_PAnaCategoryID).Text
            .PAnaCategoryName01 = tdbg.Columns(COL_PAnaCategoryName).Text
            .PAnaCategoryName84 = tdbg.Columns(COL_PAnaCategoryName).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With
       
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifydate).Text)
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