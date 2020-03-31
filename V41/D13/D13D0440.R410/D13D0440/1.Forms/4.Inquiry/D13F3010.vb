Public Class D13F3010

#Region "Const of tdbg"
    Private Const COL_VoucherDate As Integer = 0        ' Ngày phiếu
    Private Const COL_SalaryVoucherNo As Integer = 1    ' Số phiếu
    Private Const COL_PayrollVoucherNo As Integer = 2   ' Hồ sơ lương
    Private Const COL_Description As Integer = 3        ' Diễn giải
    Private Const COL_TransferMethodName As Integer = 4 ' PP chuyển bút toán
    Private Const COL_Transfered As Integer = 5         ' Đã chuyển bút toán
    Private Const COL_CreateUserID As Integer = 6       ' CreateUserID
    Private Const COL_LastModifyUserID As Integer = 7   ' LastModifyUserID
    Private Const COL_CreateDate As Integer = 8         ' CreateDate
    Private Const COL_LastModifyDate As Integer = 9     ' LastModifyDate
    Private Const COL_TransferMethodID As Integer = 10  ' TransferMethodID
    Private Const COL_SalaryVoucherID As Integer = 11   ' SalaryVoucherID
#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "SELECT      T1.VoucherDate,SalaryVoucherID,SalaryVoucherNo, " & vbCrLf
        sSQL &= "           T1.Description,Transfered, " & vbCrLf
        sSQL &= "           PayrollVoucherNo, T1.TransferMethodID, T3.TransferMethodName, " & vbCrLf
        sSQL &= "           T1.CreateUserID, T1.CreateDate, " & vbCrLf
        sSQL &= "           T1.LastModifyUserID, T1.LastModifyDate " & vbCrLf
        sSQL &= "FROM       D13T2600 T1  WITH(NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN  D13T0100 T2  WITH(NOLOCK) On T1.PayrollVoucherID=T2.PayrollVoucherID" & vbCrLf
        sSQL &= "LEFT JOIN  D13T1110 T3  WITH(NOLOCK) On T1.TransferMethodID=T3.TransferMethodID" & vbCrLf
        sSQL &= "LEFT JOIN  D13T1130 T4  WITH(NOLOCK) ON T1.TransTypeID = T4.TransTypeID" & vbCrLf
        sSQL &= "WHERE  T1.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "			AND T1.TranMonth = " & SQLNumber(giTranMonth) & vbCrLf
        sSQL &= "           AND T1.TranYear = " & SQLNumber(giTranYear) & vbCrLf
        sSQL &= "           AND T1.TransferMethodID Is Not Null " & vbCrLf
        sSQL &= "           AND T1.TransferMethodID <>'' " & vbCrLf
        sSQL &= "           AND Calculated=1" & vbCrLf
        sSQL &= "           AND (   Isnull(DAGroupID, '') = ''" & vbCrLf
        sSQL &= "                   OR Isnull(DAGroupID, '') In (   Select  DAGroupID " & vbCrLf
        sSQL &= "                                                   From    LemonSys.dbo.D00V0080" & vbCrLf
        sSQL &= "                                                   Where   UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "                   OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")"
        LoadDataSource(tdbg, sSQL)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        EnabledMenu()
    End Sub

    Private Sub EnabledMenu()
        If tdbg.RowCount = 0 Then
            mnuDetail.Enabled = False
        Else
            mnuDetail.Enabled = True
        End If
    End Sub

    Private Sub D13F3010_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        ResetColorGrid(tdbg)
        mnuDelete.Enabled = False
        gbEnabledUseFind = False
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me, Me.C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDetail_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDetail.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim Bookmark As Integer
        'Xác định form đang ở quyền nào
        Dim per As Integer = ReturnPermission(Me.Name)

        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        Dim f As New D13F3011
        With f
            .SalaryVoucherID = tdbg.Columns(COL_SalaryVoucherID).Text
            .SalaryVoucherNo = tdbg.Columns(COL_SalaryVoucherNo).Text
            .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
            If per = 1 Then
                .FormState = EnumFormState.FormView
            Else
                .FormState = EnumFormState.FormEdit
            End If

            .ShowDialog()
            .Dispose()
            If .bSaved Then
                LoadTDBGrid()
            End If
            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        End With
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If mnuDetail.Enabled Then
            mnuDetail_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Select Case e.KeyCode
            Case Keys.Enter
                If mnuDetail.Enabled Then
                    mnuDetail_Click(sender, Nothing)
                End If
            Case Else
                'HotKeyEnterGrid(tdbg, COL_VoucherDate, e)
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2113
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 05/03/2007 03:43:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2113() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2113 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL &= SQLNumber(0) 'Language, tinyint, NOT NULL
        ElseIf geLanguage = EnumLanguage.English Then
            sSQL &= SQLNumber(1) 'Language, tinyint, NOT NULL
        End If
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2112
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 05/03/2007 03:45:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2112() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2112 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalaryVoucherID).Text) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function CheckBeforeDelete() As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD13P2113()
        Return CheckStore(sSQL)
    End Function

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As String = ""
        Dim bResult As Boolean
        Dim Bookmark As Integer

        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        If Not CheckBeforeDelete() Then Exit Sub
        sSQL = "Select TransferMethodID From D13T2600 Where TransferMethodID=" & SQLString(tdbg.Columns(COL_TransferMethodID))
        If ExistRecord(sSQL) Then
            D99C0008.MsgCanNotDelete()
            Exit Sub
        End If

        sSQL = ""
        'Xóa kết quả chuyển bút toán
        sSQL = SQLStoreD13P2112()
        bResult = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            'Lưu lại vết Audit
            'If CheckAudit("TransTransferMethod") Then
            '    sSQL = ""
            '    sSQL = SQLStoreD91P9106("TransTransferMethod", "13", "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_SalaryVoucherNo).Text, tdbg.Columns(COL_SalaryVoucherID).Text, tdbg.Columns(COL_TransferMethodID).Text, "")
            '    ExecuteSQLNoTransaction(sSQL)
            'End If
            Lemon3.D91.RunAuditLog("13", "TransTransferMethod", "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_SalaryVoucherNo).Text, tdbg.Columns(COL_SalaryVoucherID).Text, tdbg.Columns(COL_TransferMethodID).Text, "")
            LoadTDBGrid()
            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        If tdbg.Columns(COL_Transfered).Text <> "" Then
            If CBool(tdbg.Columns(COL_Transfered).Text) = True Then
                mnuDelete.Enabled = True
            Else
                mnuDelete.Enabled = False
            End If
        End If
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Chuyen_but_toan_-_D13F3010") 'ChuyÓn bòt toÀn - D13F3010
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnAction.Text = rL3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        tdbg.Columns("VoucherDate").Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("SalaryVoucherNo").Caption = rL3("So_phieu") 'Số phiếu
        tdbg.Columns("PayrollVoucherNo").Caption = rL3("Ho_so_luong") 'Hồ sơ lương
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("TransferMethodName").Caption = rL3("PP_chuyen_but_toan") 'PP chuyển bút toán
        tdbg.Columns("Transfered").Caption = rL3("Da_chuyen_but_toan") 'Đã chuyển bút toán
        '================================================================ 
        mnuDelete.Text = rL3("_Xoa_ket_qua_") '&Xóa kết quả 
        mnuSysInfo.Text = rL3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuDetail.Text = rL3("Chi_tiet") 'Chi tiết
    End Sub
End Class