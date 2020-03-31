Public Class D13F1140
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Private _formIDPermission As String = "D13F1140"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property



#Region "Const of tdbg"
    Private Const COL_SalaryObjectID As Integer = 0     ' Mã
    Private Const COL_SalaryObjectName As Integer = 1   ' Tên
    Private Const COL_ShortSalObjectName As Integer = 2 ' Tên tắt' 
    Private Const COL_DutyName As Integer = 3           ' Chức vụ
    Private Const COL_DutyID As Integer = 4             ' DutyID
    Private Const COL_Disabled As Integer = 5           ' KSD
    Private Const COL_CreateUserID As Integer = 6       ' CreateUserID
    Private Const COL_CreateDate As Integer = 7         ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 8   ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 9     ' LastModifyDate
#End Region


    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F1060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        tdbcDutyName.AutoCompletion = False
        tdbcDutyName.AutoDropDown = True
        ResetColorGrid(tdbg)
        Loadlanguage()
        LoadTDBCombo()
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDutyName
        sSQL = "Select '%' as DutyID, " & AllName & " as DutyName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "SELECT DutyID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "DutyName", "DutyName01").ToString & UnicodeJoin(gbUnicode) & " as DutyName"
        sSQL &= ", 1 AS DisplayOrder " & vbCrLf
        sSQL &= "FROM D09T0211  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, DutyID" & vbCrLf

        LoadDataSource(tdbcDutyName, sSQL, gbUnicode)
        tdbcDutyName.SelectedValue = "%"
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_doi_tuong_tinh_luong_-_D13F1140") & UnicodeCaption(gbUnicode) 'Danh móc ¢çi t§íng tÛnh l§¥ng - D13F1140

        '================================================================ 
        lblDutyName.Text = rl3("Chuc_vu") 'Chức vụ
        '================================================================ 
        tdbcDutyName.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbcDutyName.Columns("DutyName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("SalaryObjectID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("SalaryObjectName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("ShortSalObjectName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = "Select SalaryObjectID, SalaryObjectName" & UnicodeJoin(gbUnicode) & " As SalaryObjectName," & vbCrLf
        sSQL &= " T1.Disabled, T1.CreateUserID, T1.CreateDate, T1.LastModifyUserID, T1.LastModifyDate, " & vbCrLf
        sSQL &= " T1.ShortSalObjectName" & UnicodeJoin(gbUnicode) & " As ShortSalObjectName, T1.DutyID, "
        sSQL &= " T2.DutyName" & UnicodeJoin(gbUnicode) & " As DutyName "
        sSQL &= "From   D13T1020 T1 "
        sSQL &= "LEFT JOIN D09T0211 T2 ON T1.DutyID = T2.DutyID "
        sSQL &= "Order By SalaryObjectID" & vbCrLf
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
            Dim dr() As DataRow = dt1.Select("SalaryObjectID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
        End If

        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        If tdbcDutyName.Text <> "" AndAlso tdbcDutyName.SelectedValue.ToString <> "%" Then
            If strFind <> "" Then strFind &= " And "
            strFind &= " (DutyID ='' or DutyID = " & SQLString(tdbcDutyName.SelectedValue) & ")"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_SalaryObjectID)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    '	Cần sửa Tìm kiếm như sau:
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
        Dim f As New D13F1141
        With f
            If tdbcDutyName.Text <> "" AndAlso tdbcDutyName.SelectedValue.ToString <> "%" Then
                .DutyID = tdbcDutyName.SelectedValue.ToString
            Else
                .DutyID = ""
            End If
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved = True Then LoadTDBGrid(True, .SalaryObjectID)
            .Dispose()
        End With

    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D13F1141
        With f
            .SalaryObjectID = tdbg.Columns(COL_SalaryObjectID).Text
            .SalaryObjectName = tdbg.Columns(COL_SalaryObjectName).Text
            .Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
            .ShortSalObjectName = tdbg.Columns(COL_ShortSalObjectName).Text
            .DutyID = tdbg.Columns(COL_DutyID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D13F1141
        With f
            .SalaryObjectID = tdbg.Columns(COL_SalaryObjectID).Text
            .SalaryObjectName = tdbg.Columns(COL_SalaryObjectName).Text
            .Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
            .ShortSalObjectName = tdbg.Columns(COL_ShortSalObjectName).Text
            .DutyID = tdbg.Columns(COL_DutyID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_SalaryObjectID).Text)
            .Dispose()
        End With

    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL &= "SELECT		Top 1 1" & vbCrLf
        sSQL &= "FROM 		D13T0201 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE 		SalaryObjectID = " & SQLString(tdbg.Columns(COL_SalaryObjectID).Text) & vbCrLf
        If ExistRecord(sSQL) Then
            D99C0008.MsgCanNotDelete()
            Exit Sub
        End If

        sSQL = "DELETE  FROM D13T1021 " & vbCrLf
        sSQL &= "WHERE  SalaryObjectID = " & SQLString(tdbg.Columns(COL_SalaryObjectID).Text) & vbCrLf
        sSQL &= "DELETE FROM D13T1020" & vbCrLf
        sSQL &= "WHERE  SalaryObjectID = " & SQLString(tdbg.Columns(COL_SalaryObjectID).Text) & vbCrLf

        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
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

#Region "Events tdbcDutyName"

    Private Sub tdbcDutyName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyName.Close
        tdbcDutyName_Validated(sender, Nothing)

        If tdbcDutyName.Tag Is Nothing OrElse tdbcDutyName.Tag.ToString <> tdbcDutyName.Text Then
            If (tdbcDutyName.SelectedValue IsNot Nothing AndAlso tdbcDutyName.Text <> "") Then
                tdbcDutyName.Tag = tdbcDutyName.Text
                If dtGrid Is Nothing Then Exit Sub
                ReLoadTDBGrid()
            End If
        End If
    End Sub

    Private Sub tdbcDutyName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyName.LostFocus
        If tdbcDutyName.FindStringExact(tdbcDutyName.Text) = -1 Then tdbcDutyName.Text = ""

    End Sub

    Private Sub tdbcDutyName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyName.Validated
        tdbcDutyName.Text = tdbcDutyName.WillChangeToText
    End Sub
#End Region


End Class
