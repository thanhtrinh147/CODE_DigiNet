﻿Public Class D25F1010

#Region "Const of tdbg"
    Private Const COL_RecSourceID As Integer = 0      ' Mã
    Private Const COL_RecSourceName As Integer = 1    ' Diễn giải
    Private Const COL_Disabled As Integer = 2         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 3     ' Người tạo
    Private Const COL_CreateDate As Integer = 4       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 5 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 6   ' Ngày cập nhật cuối cùng
#End Region

    ' Update 19/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dtGrid As DataTable
    Dim skey As String = ""
    Dim sFind As String = ""
    Dim bUnicode As Boolean = gbUnicode

    Private Sub D25F1010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F1010_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False

        Loadlanguage()
        LoadTDBGrid()

        '*****
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_nguon_tuyen_dung_-_D25F1010") & UnicodeCaption(bUnicode) 'Danh móc nguän tuyÓn dóng - D25F1010
        '================================================================ 
        tdbg.Columns("RecSourceID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("RecSourceName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng        
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'hiển thị danh mục chưa sử dụng

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL &= " SELECT RecSourceID,RecSourceName" & UnicodeJoin(gbUnicode) & " as RecSourceName"
        sSQL &= ", ContactPerson" & UnicodeJoin(gbUnicode) & "  as ContactPerson,Duty" & UnicodeJoin(gbUnicode) & "  as Duty"
        sSQL &= ", ContactPhone,Note,Disabled,CreateUserID,CreateDate,LastModifyUserID,LastModifyDate"
        sSQL &= " FROM D25T1010 WITH(NOLOCK) Order By RecSourceID"
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
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_RecSourceID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
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
        FooterTotalGrid(tdbg, COL_RecSourceID)
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
    End Sub
#End Region

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Try
            Dim f As New D25F1011
            f.RecSourceID = ""
            f.FormState = EnumFormState.FormAdd
            f.ShowDialog()
            skey = f.RecSourceID
            f.Dispose()
            If f.bSaved Then
                LoadTDBGrid(True, skey)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D25F1011
        f.RecSourceID = tdbg.Columns(COL_RecSourceID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D25F1011
        f.RecSourceID = tdbg.Columns(COL_RecSourceID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_RecSourceID).Text)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub

        Dim sSQL As String = ""
        sSQL = "Delete D25T1010 Where RecSourceID = " & SQLString(tdbg.Columns(COL_RecSourceID).Text)
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            DeleteOK()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub


    Private Function AllowDelete() As Boolean
        Dim sSQL As String = ""
        Dim dt As DataTable
        sSQL = "Select RecSourceID From D25T1041  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where RecSourceID = " & SQLString(tdbg.Columns("RecSourceID").Text) & vbCrLf

        sSQL &= "Select RecSourceID From D25T1042  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where RecSourceID = " & SQLString(tdbg.Columns("RecSourceID").Text) & vbCrLf
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rl3("Nguon_tuyen_dung_nay_da_duoc_su_dung_roi"))
            Return False
        End If
        Return True

    End Function

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

End Class
