﻿'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:44:08 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:44:08 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1080

	Private _formIDPermission As String = "D13F1080"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg"
    Private Const COL_RewardID As Integer = 0         ' Mã
    Private Const COL_RewardName As Integer = 1       ' Diễn giải
    Private Const COL_Disabled As Integer = 2         ' Không sử dụng 
    Private Const COL_CreateUserID As Integer = 3     ' Người tạo
    Private Const COL_CreateDate As Integer = 4       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 5 ' Người cập nhật cuối cùng 
    Private Const COL_LastModifyDate As Integer = 6   ' Ngày cập nhật cuối cùng
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub D13F1080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.Text = rl3("Danh_muc_thuong_theo_tham_nien_-_D13F1080") & UnicodeCaption(gbUnicode) 'Danh móc th§êng theo th¡m ni£n - D13F1080
        '================================================================ 
        tdbg.Columns("RewardID").Caption = rL3("Ma") 'Mã
        tdbg.Columns("RewardName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("Disabled").Caption = rL3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL &= "Select RewardID, RewardName" & UnicodeJoin(gbUnicode) & " As RewardName, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate From D13T0301  WITH (NOLOCK) Order by RewardID"
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
            Dim dr() As DataRow = dt1.Select("RewardID = " & SQLString(sKey), dt1.DefaultView.Sort)
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
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_RewardID)
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
        Dim f As New D13F1081
        With f
            .RewardID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid(True, .RewardID)
            End If
            .Dispose()
        End With

    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D13F1081
        With f
            .RewardID = tdbg.Columns(COL_RewardID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D13F1081
        With f
            .RewardID = tdbg.Columns(COL_RewardID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then
                LoadTDBGrid(False, tdbg.Columns(COL_RewardID).Text)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0302 Where RewardID= " & SQLString(tdbg.Columns(COL_RewardID).Text)
        sSQL &= "Delete From D13T0301 Where RewardID= " & SQLString(tdbg.Columns(COL_RewardID).Text)
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult = True Then
            DeleteOK()
            'Audit Log
            Dim sDesc1 As String = tdbg.Columns(COL_RewardID).Text
            Dim sDesc2 As String = tdbg.Columns(COL_RewardName).Text
            Dim sDesc3 As String = ""
            Dim sDesc4 As String = ""
            Dim sDesc5 As String = SQLNumber(tdbg.Columns(COL_Disabled).Value)
            RunAuditLog(AuditCodeSeniorityBonuses, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

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