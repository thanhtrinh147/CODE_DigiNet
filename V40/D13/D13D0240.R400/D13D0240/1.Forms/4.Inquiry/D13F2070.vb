Public Class D13F2070

#Region "Const of tdbg"
    Private Const COL_PITVoucherID As Integer = 0     ' 
    Private Const COL_VoucherDate As Integer = 1      ' Ngày phiếu
    Private Const COL_PITVoucherNo As Integer = 2     ' Số phiếu
    Private Const COL_Description As Integer = 3      ' Diễn giải
    Private Const COL_Calculated As Integer = 4       ' Đã khai thuế
    Private Const COL_CreateUserID As Integer = 5     ' Mã người tạo
    Private Const COL_LastModifyUserID As Integer = 6 ' Mã người sửa cuối
    Private Const COL_CreateDate As Integer = 7       ' Ngày tạo
    Private Const COL_LastModifyDate As Integer = 8   ' Ngày sửa cuối
#End Region

    Private dt As DataTable

    Private Sub D13F2070_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        SetShortcutPopupMenu(Me.C1CommandHolder)
        gbEnabledUseFind = False
        LoadTDBGrid()
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()

        '================================================================ 
        Me.Text = rl3("Danh_sach_phieu_khai_thue_TNCN_-_D13F2070") & UnicodeCaption(gbUnicode) 'Danh sÀch phiÕu khai thuÕ TNCN - D13F2070
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("PITVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Calculated").Caption = rl3("Da_khai_thue") 'Đã khai thuế
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuCalculate.Text = rl3("Ti_nh")
        mnuDisplayResult.Text = rl3("X_em_ket_qua") 'Xem kết quả
        mnuDeleteResult.Text = rl3("Xoa_ket_qu_a") 'Xóa kết quả
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2070
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/08/2009 10:07:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2070() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2071
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/08/2009 10:28:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2071() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2071 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PITVoucherID).Text) 'PITVoucherID, varchar[20], NOT NULL
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2072
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/08/2009 10:28:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2072() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2072 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PITVoucherID).Text) 'PITVoucherID, varchar[20], NOT NULL
        Return sSQL & vbCrLf
    End Function

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKeyID As String = "")
        dt = ReturnDataTable(SQLStoreD13P2070)
        LoadDataSource(tdbg, dt, gbUnicode)
        If FlagAdd Then
            dt.DefaultView.Sort = "PITVoucherID" 'Field của khóa chính
            tdbg.Bookmark = dt.DefaultView.Find(sKeyID)
        End If
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuCalculate.Enabled = tdbg.RowCount > 0 And ReturnPermission(Me.Name) > EnumPermission.View And Not gbClosed
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CheckStore(SQLStoreD13P5555(4)) Then Exit Sub

        Dim frm As New D13F2071

        With frm
            .PITVoucherID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()

            If .bSaved Then
                Dim sKey As String = frm.PITVoucherID
                LoadTDBGrid(True, sKey)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CheckStore(SQLStoreD13P5555(3)) Then Exit Sub

        Dim frm As New D13F2071

        With frm
            .IsCalculated = CBool(tdbg.Columns(COL_Calculated).Text)
            .PITVoucherID = tdbg.Columns(COL_PITVoucherID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()

            If .bSaved Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid()
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        Dim frm As New D13F2071

        With frm
            .IsCalculated = CBool(tdbg.Columns(COL_Calculated).Text)
            .PITVoucherID = tdbg.Columns(COL_PITVoucherID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()

        End With
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CheckStore(SQLStoreD13P5555(2)) Then Exit Sub

        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then

            If CBool(tdbg.Columns(COL_Calculated).Text) Then
                D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_su_dung_Ban_khong_duoc_phep_xoa"))
                Exit Sub
            End If

            sSQL = "Delete D13T2070 Where PITVoucherID = " & SQLString(tdbg.Columns(COL_PITVoucherID).Text) & vbCrLf
            sSQL &= "Delete D13T2074 Where PITVoucherID = " & SQLString(tdbg.Columns(COL_PITVoucherID).Text)
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteOK()
                RunAuditLog(AuditCodePITVoucher, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PITVoucherNo).Text, tdbg.Columns(COL_Description).Text)
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid()
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            Else
                DeleteNotOK()
            End If
        End If

    End Sub


    Private Sub mnuCalculate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCalculate.Click
        Dim sSQL As String = ""
        If CBool(tdbg.Columns(COL_Calculated).Text) Then
            'If ExistRecord("Select Top 1 1 From D13T2084 Where PITVoucherID = " & SQLString(tdbg.Columns(COL_PITVoucherID).Text)) Then
            '    D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_su_dung_Ban_khong_the_tinh_lai"))
            '    Exit Sub
            'End If
            If Not CheckStore(SQLStoreD13P5555(1)) Then Exit Sub

            sSQL &= SQLStoreD13P2072()
            sSQL &= SQLStoreD13P2071()
        Else
            sSQL &= SQLStoreD13P2070()
            sSQL &= SQLStoreD13P2071()
        End If

        If ExecuteSQL(sSQL) Then
            RunAuditLog(AuditCodePITVoucher, "02", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PITVoucherNo).Text, tdbg.Columns(COL_Description).Text)
            D99C0008.MsgL3(rl3("Du_lieu_da_duoc_tinh_thanh_cong"))
            Dim f As New D13F2072
            f.PITVoucherID = tdbg.Columns(COL_PITVoucherID).Text
            f.ShowDialog()
            f.Dispose()

            Dim Bookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
            LoadTDBGrid()
            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        End If

    End Sub

    Private Sub mnuDeleteResult_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDeleteResult.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        'If ExistRecord("Select Top 1 1 From D13T2084 Where PITVoucherID = " & SQLString(tdbg.Columns(COL_PITVoucherID).Text)) Then
        '    D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_su_dung_Ban_khong_the_xoa") & " " & rl3("Ket_qua_tinh"))
        '    Exit Sub
        'End If

        If Not CheckStore(SQLStoreD13P5555(0)) Then Exit Sub

        If ExecuteSQL(SQLStoreD13P2072) Then
            D99C0008.MsgL3(rl3("Ket_qua_tinh_da_duoc_xoa_thanh_cong"))
            RunAuditLog(AuditCodePITVoucher, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PITVoucherNo).Text, tdbg.Columns(COL_Description).Text)
            Dim Bookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
            LoadTDBGrid()
            If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        Else
            DeleteNotOK()
        End If

    End Sub

    Private Sub mnuDisplayResult_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDisplayResult.Click
        Dim f As New D13F2072
        f.PITVoucherID = tdbg.Columns(COL_PITVoucherID).Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If mnuEdit.Enabled Then
            mnuEdit_Click(Nothing, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
    End Sub


    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        If tdbg.RowCount > 0 Then
            mnuDisplayResult.Enabled = CBool(tdbg.Columns(COL_Calculated).Text)
            mnuDeleteResult.Enabled = CBool(tdbg.Columns(COL_Calculated).Text) And (ReturnPermission(Me.Name) > EnumPermission.EditAdd) And Not gbClosed
        Else
            mnuDisplayResult.Enabled = False
            mnuDeleteResult.Enabled = False
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 16/12/2010 01:49:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PITVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class