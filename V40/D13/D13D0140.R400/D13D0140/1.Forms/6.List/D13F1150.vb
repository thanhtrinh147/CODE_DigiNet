﻿'#-------------------------------------------------------------------------------------
'# Created Date: 15/07/2010 8:14:20 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 15/07/2010 8:14:20 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F1150
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_PayrollAdjustMethodID As Integer = 0   ' Mã
    Private Const COL_PayrollAdjustMethodName As Integer = 1 ' Tên
    Private Const COL_Disabled As Integer = 2                ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 3            ' Người lập
    Private Const COL_CreateDate As Integer = 4              ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 5        ' Mã người sửa cuối
    Private Const COL_LastModifyDate As Integer = 6          ' Ngày sửa cuối
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F1150_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        ResetColorGrid(tdbg)
        Loadlanguage()
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_phuong_phap_dieu_chinh_luong_-_D13F1150") & UnicodeCaption(gbUnicode) 'Danh móc ph§¥ng phÀp ¢iÒu chÙnh l§¥ng - D13F1150
        '================================================================ 
        tdbg.Columns("PayrollAdjustMethodID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("PayrollAdjustMethodName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = "SELECT distinct T20.PayrollAdjustMethodID, "
        sSQL &= "T20.PayrollAdjustMethodName" & UnicodeJoin(gbUnicode) & " As PayrollAdjustMethodName, T20.Disabled, T20.CreateUserID, "
        sSQL &= "T20.LastModifyUserID, T20.CreateDate, T20.LastModifyDate" & vbCrLf
        sSQL &= "FROM D13T1150 T20  WITH (NOLOCK) ORDER BY PayrollAdjustMethodID"
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            sFind = ""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("PayrollAdjustMethodID = " & SQLString(sKey), dt1.DefaultView.Sort)
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
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_PayrollAdjustMethodID)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
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
        Dim f As New D13F1151
        With f
            .PayrollAdjustMethodID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved = True Then LoadTDBGrid(True, .PayrollAdjustMethodID)
            .Dispose()
        End With

    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D13F1151
        With f
            .PayrollAdjustMethodID = tdbg.Columns(COL_PayrollAdjustMethodID).Text
            .PayrollAdjustMethodName = tdbg.Columns(COL_PayrollAdjustMethodName).Text
            .Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D13F1151
        With f
            .PayrollAdjustMethodID = tdbg.Columns(COL_PayrollAdjustMethodID).Text
            .PayrollAdjustMethodName = tdbg.Columns(COL_PayrollAdjustMethodName).Text
            .Disabled = L3Bool(tdbg.Columns(COL_Disabled).Text)
            .CreateDate = tdbg.Columns(COL_CreateDate).Text
            .CreateUserID = tdbg.Columns(COL_CreateUserID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_PayrollAdjustMethodID).Text)
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        sSQL = "Delete D13T1150 Where PayrollAdjustMethodID = " & SQLString(tdbg.Columns(COL_PayrollAdjustMethodID).Text) & vbCrLf
        sSQL &= "Delete D13T1152 Where PayrollAdjustMethodID = " & SQLString(tdbg.Columns(COL_PayrollAdjustMethodID).Text)
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

End Class