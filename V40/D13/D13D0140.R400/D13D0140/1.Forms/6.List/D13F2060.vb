Public Class D13F2060


#Region "Const of tdbg"
    Private COL_TransferMethodID As Integer = 0   ' Mã phương pháp
    Private COL_TransferMethodName As Integer = 1 ' Tên phương pháp
    Private COL_Disabled As Integer = 2           ' Không sử dụng
    Private COL_CreateUserID As Integer = 3       ' CreateUserID
    Private COL_CreateDate As Integer = 4         ' CreateDate
    Private COL_LastModifyUserID As Integer = 5   ' LastModifyUserID
    Private COL_LastModifyDate As Integer = 6     ' LastModifyDate
    Private COL_TransferMode As Integer = 7       ' TransferMode
#End Region

    Private sKey As String
    Private sFind As String = ""


    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Try
            Dim f As New D13F2061
            f.FormState = EnumFormState.FormAdd
            f.ShowDialog()
            sKey = f.TransferMethodID
            If f.bSaved Then
                LoadTDBGrid(True)
            End If
            f.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim Bookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        Dim f As New D13F2061
        With f
            .TransferMethodID = tdbg.Columns(COL_TransferMethodID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                LoadTDBGrid()
            End If
            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2061
        f.TransferMethodID = tdbg.Columns(COL_TransferMethodID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As String = ""
        Dim iBookmark As Integer
        Dim bResult As Boolean

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            If CheckBeforeDelete() = False Then Exit Sub
            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
            'Xóa Detail
            sSQL &= "Delete D13T1120 Where TransferMethodID = " & SQLString(tdbg.Columns(COL_TransferMethodID).Text) & vbCrLf
            'Xóa Master
            sSQL &= "Delete D13T1110 Where TransferMethodID = " & SQLString(tdbg.Columns(COL_TransferMethodID).Text) & vbCrLf
            bResult = ExecuteSQL(sSQL)
            If bResult = True Then
                DeleteOK()
                'Lưu lại vết Audit
                'If CheckAudit("TransTransferMethod") Then
                '    sSQL = SQLStoreD91P9106("TransTransferMethod", "13", "03", tdbg.Columns(COL_TransferMethodID).Text, tdbg.Columns(COL_TransferMethodName).Text, tdbg.Columns(COL_TransferMode).Text, "", "")
                '    ExecuteSQLNoTransaction(sSQL)
                'End If
                Lemon3.D91.RunAuditLog("13", "TransTransferMethod", "03", tdbg.Columns(COL_TransferMethodID).Text, tdbg.Columns(COL_TransferMethodName).Text, tdbg.Columns(COL_TransferMode).Text, "", "")
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        Else
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            Else
                mnuView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        Dim sSQL As String = ""
        'sSQL = "Select TransferMethodID, TransferMethodName,Disabled,TransferMode, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate " & vbCrLf
        'sSQL &= "From D13T1110 Order By TransferMethodID"
        sSQL = "Select * from D13T1110  WITH (NOLOCK) order by TransferMethodID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        If FlagAdd Then
            dt.DefaultView.Sort = "TransferMethodID"
            tdbg.Bookmark = dt.DefaultView.Find(sKey)
        End If
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        EnabledControl()
    End Sub

    Private Sub EnabledControl()
        If tdbg.RowCount = 0 Then
            mnuDetail.Enabled = False
        Else
            mnuDetail.Enabled = True
        End If
    End Sub

    Private Sub D13F2060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        UnicodeGridDataField(tdbg, COL_TransferMethodName, gbUnicode)
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBGrid()
        SetResolutionForm(Me, Me.C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDetail_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDetail.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2062
        f.TransferMethodID = tdbg.Columns(COL_TransferMethodID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Function CheckBeforeDelete() As Boolean
        Dim sSQL As String = ""
        'Kiểm tra trong phiếu tính lương
        sSQL &= "Select TransferMethodID From D13T2600  WITH (NOLOCK) Where TransferMethodID = " & SQLString(tdbg.Columns(COL_TransferMethodID).Text)
        Dim sRet As String = ReturnScalar(sSQL)
        If sRet <> "" Then
            D99C0008.MsgL3(MsgNotDeleteData)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_phuong_phap_chuyen_but_toan_-_D13F2060") & UnicodeCaption(gbUnicode) 'Danh móc ph§¥ng phÀp chuyÓn bòt toÀn - D13F2060
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...       
        '================================================================ 
        tdbg.Columns("TransferMethodID").Caption = rl3("Ma") 'Mã 
        tdbg.Columns("TransferMethodName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng       
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuDetail.Text = rl3("Thiet_lap_chi_tiet") 'Thiết lập chi tiết
    End Sub

End Class