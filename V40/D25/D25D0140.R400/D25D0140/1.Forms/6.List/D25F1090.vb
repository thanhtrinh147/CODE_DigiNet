'#-------------------------------------------------------------------------------------
'# Created Date: 23/12/2010 8:45:46 AM
'# Created User: Lê Sơn Long
'# Modify Date: 23/12/2010 8:45:46 AM
'# Modify User: Lê Sơn Long
'#-------------------------------------------------------------------------------------
Public Class D25F1090

#Region "Const of tdbg"
    Private Const COL_IntGroupID As Integer = 0       ' Mã
    Private Const COL_IntGroupName As Integer = 1     ' Tên
    Private Const COL_Description As Integer = 2      ' Diễn giải
    Private Const COL_Disabled As Integer = 3         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 4     ' CreateUserID
    Private Const COL_CreateDate As Integer = 5       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 6 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 7   ' LastModifyDate
#End Region

    ' Update 24/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Private dtGrid As DataTable
    Private sFind As String = ""
    Private skey As String = ""

    Private Sub D25F1090_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.N Then
                tsbAdd_Click(sender, Nothing)
            End If
            If e.KeyCode = Keys.E Then
                tsbEdit_Click(sender, Nothing)
            End If
        End If
    End Sub

    Private Sub D25F1090_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        ResetColorGrid(tdbg)
        Loadlanguage()
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_nhom_phong_van_-_D25F1090") & UnicodeCaption(gbUnicode) 'Danh móc nhâm phàng vÊn - D25F1090
        '================================================================ 
        tdbg.Columns("IntGroupID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("IntGroupName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'hiển thị danh mục chưa sử dụng

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String
        sSQL = " SELECT DISTINCT"
        sSQL &= " IntGroupID, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, "
        sSQL &= " IntGroupName" & UnicodeJoin(gbUnicode) & " AS IntGroupName, "
        sSQL &= " Description" & UnicodeJoin(gbUnicode) & " AS Description,Disabled "
        sSQL &= " FROM D25T1090 WITH(NOLOCK) "
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_IntGroupID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If

    End Sub

#Region "Active FilterChange "
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
             WriteLogFile(ex.Message)
        End Try
    End Sub
    '	Vào sự kiện tdbg_KeyPress viết code như sau:
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        'Select Case tdbg.Col
        '    Case COL_ListID
        '        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        'End Select
    End Sub
    '	Vào sự kiện tdbg_DoubleClick viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub
    '	Vào sự kiện tdbg_KeyDown viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(sender, Nothing)
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind.Equals("") = False Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_IntGroupID)
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
    End Sub
#End Region

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Try
            Dim f As New D25F1091
            f.IntGroupID = ""
            f.FormState = EnumFormState.FormAdd
            f.ShowDialog()
            skey = f.IntGroupID
            f.Dispose()
            If f.bSaved Then
                LoadTDBGrid(True, skey)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D25F1091
        f.IntGroupID = tdbg.Columns(COL_IntGroupID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D25F1091
        f.IntGroupID = tdbg.Columns(COL_IntGroupID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_IntGroupID).Text)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            'If Not AllowDelete() Then Exit Sub
            If Not CheckStore(SQLStoreD25P5555()) Then Exit Sub
            sSQL = "Delete From D25T1090 where IntGroupID = " & SQLString(tdbg.Columns(COL_IntGroupID).Text)
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
                ResetGrid()
                DeleteOK()
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    'Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
    '    Me.Cursor = Cursors.WaitCursor
    '    If tsbEdit.Enabled Then
    '        tsbEdit_Click(sender, Nothing)
    '    ElseIf tsbView.Enabled Then
    '        tsbView_Click(sender, Nothing)
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.KeyCode = Keys.Enter Then
    '        If tsbEdit.Enabled Then
    '            tsbEdit_Click(sender, Nothing)
    '        ElseIf tsbView.Enabled Then
    '            tsbView_Click(sender, Nothing)
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub


    'Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim f As New D25F1091

    '    With f
    '        f.IntGroupID = ""
    '        f.FormState = EnumFormState.FormAdd
    '        f.ShowDialog()

    '        If .bSaved Then
    '            Dim sKey As String = f.IntGroupID
    '            LoadTDBGrid(True, False, sKey)
    '        End If
    '        f.Dispose()
    '    End With
    'End Sub

    'Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim f As New D25F1091
    '    f.IntGroupID = tdbg.Columns(COL_IntGroupID).Text
    '    f.FormState = EnumFormState.FormView
    '    f.ShowDialog()
    '    f.Dispose()
    'End Sub

    'Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim f As New D25F1091
    '    f.IntGroupID = tdbg.Columns(COL_IntGroupID).Text
    '    f.FormState = EnumFormState.FormEdit
    '    f.ShowDialog()
    '    f.Dispose()
    '    If .bSaved Then
    '        Dim Bookmark As Integer
    '        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
    '        LoadTDBGrid(False, True)
    '        If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
    '    End If
    'End Sub

    'Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim sSQL As String
    '    Dim bResult As Boolean
    '    If AskDelete() = Windows.Forms.DialogResult.Yes Then
    '        If Not AllowDelete() Then Exit Sub
    '        sSQL = "Delete From D25T1090 where IntGroupID = " & SQLString(tdbg.Columns(COL_IntGroupID).Text)
    '        bResult = ExecuteSQL(sSQL)
    '        If bResult Then
    '            DeleteOK()
    '            Dim Bookmark As Integer
    '            If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
    '            LoadTDBGrid()
    '            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
    '        Else
    '            DeleteNotOK()
    '        End If
    '    End If
    'End Sub

    'Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Close()
    'End Sub

    'Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
    '    ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    'End Sub

    Private Function AllowDelete() As Boolean
        Return CheckStore(SQLStoreD25P5555)
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Lê Sơn Long
    '# Created Date: 23/12/2010 09:40:08
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_IntGroupID).Text) 'Key01ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

End Class